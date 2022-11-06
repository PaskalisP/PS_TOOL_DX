<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductTypesOCBS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductTypesOCBS))
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.ProductTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductTypeTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ProductTypeTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.ContractTypeTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ContractTypeTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ProductTypesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCoreSystem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CoreSystemRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colProductGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ProductTypesRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTrade_Finance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TradeFinanceRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ContractTypesRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ContractTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ProductTypesOCBS_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductTypesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CoreSystemRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductTypesRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TradeFinanceRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractTypesRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ProductTypeBindingSource
        '
        Me.ProductTypeBindingSource.DataMember = "ProductType"
        Me.ProductTypeBindingSource.DataSource = Me.PSTOOLDataset
        '
        'ProductTypeTableAdapter
        '
        Me.ProductTypeTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ContractTypeTableAdapter = Me.ContractTypeTableAdapter
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
        Me.TableAdapterManager.GL_ACCOUNTS_NEWGTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Me.ProductTypeTableAdapter
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ContractTypeTableAdapter
        '
        Me.ContractTypeTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.ProductTypesOCBS_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1464, 728)
        Me.LayoutControl1.TabIndex = 7
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.ProductTypeBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 6
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ProductTypesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ProductTypesRepositoryItemTextEdit, Me.ContractTypesRepositoryItemLookUpEdit1, Me.CoreSystemRepositoryItemImageComboBox1, Me.TradeFinanceRepositoryItemImageComboBox})
        Me.GridControl2.Size = New System.Drawing.Size(1440, 678)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ProductTypesBaseView})
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
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("servermode_16x16.png", "images/data/servermode_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/servermode_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "servermode_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("documentmap_16x16.png", "office2013/navigation/documentmap_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/navigation/documentmap_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "documentmap_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "cancel_16x16.png")
        '
        'ProductTypesBaseView
        '
        Me.ProductTypesBaseView.ActiveFilterString = "[CoreSystem] = 'NEWG'"
        Me.ProductTypesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ProductTypesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ProductTypesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ProductTypesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ProductTypesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ProductTypesBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.ProductTypesBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.ProductTypesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCoreSystem, Me.colProductType, Me.colProductTypeName, Me.colTrade_Finance, Me.colProductGroup, Me.colContractType})
        Me.ProductTypesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ProductTypesBaseView.GridControl = Me.GridControl2
        Me.ProductTypesBaseView.Name = "ProductTypesBaseView"
        Me.ProductTypesBaseView.NewItemRowText = "Add new Product Type"
        Me.ProductTypesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ProductTypesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ProductTypesBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.ProductTypesBaseView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow
        Me.ProductTypesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ProductTypesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ProductTypesBaseView.OptionsFind.AlwaysVisible = True
        Me.ProductTypesBaseView.OptionsSelection.MultiSelect = True
        Me.ProductTypesBaseView.OptionsView.ColumnAutoWidth = False
        Me.ProductTypesBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ProductTypesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ProductTypesBaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ProductTypesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.ProductTypesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ProductTypesBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colCoreSystem
        '
        Me.colCoreSystem.Caption = "Core System"
        Me.colCoreSystem.ColumnEdit = Me.CoreSystemRepositoryItemImageComboBox1
        Me.colCoreSystem.FieldName = "CoreSystem"
        Me.colCoreSystem.Name = "colCoreSystem"
        Me.colCoreSystem.Visible = True
        Me.colCoreSystem.VisibleIndex = 0
        Me.colCoreSystem.Width = 126
        '
        'CoreSystemRepositoryItemImageComboBox1
        '
        Me.CoreSystemRepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CoreSystemRepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CoreSystemRepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CoreSystemRepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.CoreSystemRepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.CoreSystemRepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CoreSystemRepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CoreSystemRepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CoreSystemRepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.CoreSystemRepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.CoreSystemRepositoryItemImageComboBox1.AutoHeight = False
        Me.CoreSystemRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CoreSystemRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("OCBS", "OCBS", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEWG", "NEWG", 10)})
        Me.CoreSystemRepositoryItemImageComboBox1.Name = "CoreSystemRepositoryItemImageComboBox1"
        Me.CoreSystemRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colProductGroup
        '
        Me.colProductGroup.ColumnEdit = Me.ProductTypesRepositoryItemTextEdit
        Me.colProductGroup.FieldName = "Product Group"
        Me.colProductGroup.Name = "colProductGroup"
        Me.colProductGroup.Visible = True
        Me.colProductGroup.VisibleIndex = 4
        Me.colProductGroup.Width = 220
        '
        'ProductTypesRepositoryItemTextEdit
        '
        Me.ProductTypesRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ProductTypesRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ProductTypesRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ProductTypesRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ProductTypesRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ProductTypesRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.ProductTypesRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.ProductTypesRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.ProductTypesRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ProductTypesRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ProductTypesRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ProductTypesRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ProductTypesRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ProductTypesRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ProductTypesRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.ProductTypesRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.ProductTypesRepositoryItemTextEdit.Name = "ProductTypesRepositoryItemTextEdit"
        '
        'colProductType
        '
        Me.colProductType.ColumnEdit = Me.ProductTypesRepositoryItemTextEdit
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.Visible = True
        Me.colProductType.VisibleIndex = 1
        Me.colProductType.Width = 133
        '
        'colProductTypeName
        '
        Me.colProductTypeName.ColumnEdit = Me.ProductTypesRepositoryItemTextEdit
        Me.colProductTypeName.FieldName = "Product Type Name"
        Me.colProductTypeName.Name = "colProductTypeName"
        Me.colProductTypeName.OptionsEditForm.StartNewRow = True
        Me.colProductTypeName.Visible = True
        Me.colProductTypeName.VisibleIndex = 2
        Me.colProductTypeName.Width = 638
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Name = "colContractType"
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 5
        Me.colContractType.Width = 181
        '
        'colTrade_Finance
        '
        Me.colTrade_Finance.Caption = "Trade Finance"
        Me.colTrade_Finance.ColumnEdit = Me.TradeFinanceRepositoryItemImageComboBox
        Me.colTrade_Finance.FieldName = "Trade_Finance"
        Me.colTrade_Finance.Name = "colTrade_Finance"
        Me.colTrade_Finance.OptionsEditForm.StartNewRow = True
        Me.colTrade_Finance.Visible = True
        Me.colTrade_Finance.VisibleIndex = 3
        Me.colTrade_Finance.Width = 80
        '
        'TradeFinanceRepositoryItemImageComboBox
        '
        Me.TradeFinanceRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TradeFinanceRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TradeFinanceRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TradeFinanceRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.TradeFinanceRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.TradeFinanceRepositoryItemImageComboBox.AutoHeight = False
        Me.TradeFinanceRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TradeFinanceRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 11), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 12)})
        Me.TradeFinanceRepositoryItemImageComboBox.Name = "TradeFinanceRepositoryItemImageComboBox"
        Me.TradeFinanceRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'ContractTypesRepositoryItemLookUpEdit1
        '
        Me.ContractTypesRepositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ContractTypesRepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ContractTypesRepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.ContractTypesRepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.ContractTypesRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ContractTypesRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ContractTypesRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ContractTypesRepositoryItemLookUpEdit1.AutoHeight = False
        Me.ContractTypesRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractTypesRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContractTypesRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contract Type", "Contract Type", 79, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contract Type Name(English)", "Contract Type Name(English)", 150, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.ContractTypesRepositoryItemLookUpEdit1.DataSource = Me.ContractTypeBindingSource
        Me.ContractTypesRepositoryItemLookUpEdit1.DisplayMember = "Contract Type"
        Me.ContractTypesRepositoryItemLookUpEdit1.Name = "ContractTypesRepositoryItemLookUpEdit1"
        Me.ContractTypesRepositoryItemLookUpEdit1.NullText = "[Select Contract Typel]"
        Me.ContractTypesRepositoryItemLookUpEdit1.ValueMember = "Contract Type"
        '
        'ContractTypeBindingSource
        '
        Me.ContractTypeBindingSource.DataMember = "ContractType"
        Me.ContractTypeBindingSource.DataSource = Me.PSTOOLDataset
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
        'ProductTypesOCBS_Print_Export_btn
        '
        Me.ProductTypesOCBS_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ProductTypesOCBS_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.ProductTypesOCBS_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.ProductTypesOCBS_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.ProductTypesOCBS_Print_Export_btn.Name = "ProductTypesOCBS_Print_Export_btn"
        Me.ProductTypesOCBS_Print_Export_btn.Size = New System.Drawing.Size(158, 22)
        Me.ProductTypesOCBS_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.ProductTypesOCBS_Print_Export_btn.TabIndex = 9
        Me.ProductTypesOCBS_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1464, 728)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(359, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(949, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ProductTypesOCBS_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(162, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(162, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(197, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1308, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(136, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1444, 682)
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
        'ProductTypesOCBS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 728)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProductTypesOCBS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Product Types (Core System)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductTypesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CoreSystemRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductTypesRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TradeFinanceRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractTypesRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ProductTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductTypeTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ProductTypeTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents ContractTypeTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ContractTypeTableAdapter
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ProductTypesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProductTypesRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ContractTypesRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ProductTypesOCBS_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ContractTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colCoreSystem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CoreSystemRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colTrade_Finance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TradeFinanceRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
End Class
