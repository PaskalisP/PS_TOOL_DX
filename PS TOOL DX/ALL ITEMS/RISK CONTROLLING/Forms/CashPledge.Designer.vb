<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashPledge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashPledge))
        Me.RiskControllingBasicsDataSet = New PS_TOOL_DX.RiskControllingBasicsDataSet()
        Me.CREDIT_RISK_CASH_PLEDGEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CREDIT_RISK_CASH_PLEDGETableAdapter = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CREDIT_RISK_CASH_PLEDGETableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Cashpledge_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ClientNoRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCashpledgeAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CashpledgeAmountRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colObligorRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditRiskPledgeAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colValidTill = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContractArtRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ObligorGrateFromRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ObligotGrateToRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Cashpledge_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.RiskControllingBasicsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CREDIT_RISK_CASH_PLEDGEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cashpledge_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientNoRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashpledgeAmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractArtRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObligorGrateFromRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObligotGrateToRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'RiskControllingBasicsDataSet
        '
        Me.RiskControllingBasicsDataSet.DataSetName = "RiskControllingBasicsDataSet"
        Me.RiskControllingBasicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CREDIT_RISK_CASH_PLEDGEBindingSource
        '
        Me.CREDIT_RISK_CASH_PLEDGEBindingSource.DataMember = "CREDIT RISK CASH PLEDGE"
        Me.CREDIT_RISK_CASH_PLEDGEBindingSource.DataSource = Me.RiskControllingBasicsDataSet
        '
        'CREDIT_RISK_CASH_PLEDGETableAdapter
        '
        Me.CREDIT_RISK_CASH_PLEDGETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CREDIT_RISK_CASH_PLEDGETableAdapter = Me.CREDIT_RISK_CASH_PLEDGETableAdapter
        Me.TableAdapterManager.CUSTOMER_RATING_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_RATINGTableAdapter = Nothing
        Me.TableAdapterManager.Daily_Art13_Kwg_ChineseBanksTableAdapter = Nothing
        Me.TableAdapterManager.NEW_CREDIT_BUSINESSTableAdapter = Nothing
        Me.TableAdapterManager.PD_EXTERNALTableAdapter = Nothing
        Me.TableAdapterManager.PDTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_BC_WFTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Cashpledge_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1312, 728)
        Me.LayoutControl1.TabIndex = 8
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.CREDIT_RISK_CASH_PLEDGEBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 6
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 9
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.Cashpledge_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ClientNoRepositoryItemTextEdit1, Me.CashpledgeAmountRepositoryItemTextEdit, Me.ContractArtRepositoryItemComboBox1, Me.ObligorGrateFromRepositoryItemComboBox1, Me.ObligotGrateToRepositoryItemComboBox1})
        Me.GridControl2.Size = New System.Drawing.Size(1288, 678)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Cashpledge_BaseView})
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
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "save_16x16.png")
        '
        'Cashpledge_BaseView
        '
        Me.Cashpledge_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Cashpledge_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Cashpledge_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Cashpledge_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Cashpledge_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Cashpledge_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCustomerName, Me.colCustomerNr, Me.colCashpledgeAmount, Me.colObligorRate, Me.colCreditRiskPledgeAmount, Me.colValid, Me.colValidTill})
        Me.Cashpledge_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Cashpledge_BaseView.GridControl = Me.GridControl2
        Me.Cashpledge_BaseView.Name = "Cashpledge_BaseView"
        Me.Cashpledge_BaseView.NewItemRowText = "Add new Cash pledge"
        Me.Cashpledge_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.Cashpledge_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Cashpledge_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.Cashpledge_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Cashpledge_BaseView.OptionsFind.AlwaysVisible = True
        Me.Cashpledge_BaseView.OptionsSelection.MultiSelect = True
        Me.Cashpledge_BaseView.OptionsView.ColumnAutoWidth = False
        Me.Cashpledge_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Cashpledge_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Cashpledge_BaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.Cashpledge_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.Cashpledge_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Cashpledge_BaseView.OptionsView.ShowFooter = True
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
        Me.colCustomerName.FieldName = "CustomerName"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.OptionsColumn.AllowEdit = False
        Me.colCustomerName.OptionsColumn.ReadOnly = True
        Me.colCustomerName.Visible = True
        Me.colCustomerName.VisibleIndex = 1
        Me.colCustomerName.Width = 402
        '
        'colCustomerNr
        '
        Me.colCustomerNr.ColumnEdit = Me.ClientNoRepositoryItemTextEdit1
        Me.colCustomerNr.FieldName = "CustomerNr"
        Me.colCustomerNr.Name = "colCustomerNr"
        Me.colCustomerNr.Visible = True
        Me.colCustomerNr.VisibleIndex = 0
        Me.colCustomerNr.Width = 233
        '
        'ClientNoRepositoryItemTextEdit1
        '
        Me.ClientNoRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ClientNoRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ClientNoRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ClientNoRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ClientNoRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ClientNoRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.ClientNoRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.ClientNoRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.ClientNoRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ClientNoRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ClientNoRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ClientNoRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ClientNoRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ClientNoRepositoryItemTextEdit1.AutoHeight = False
        Me.ClientNoRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ClientNoRepositoryItemTextEdit1.Name = "ClientNoRepositoryItemTextEdit1"
        '
        'colCashpledgeAmount
        '
        Me.colCashpledgeAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colCashpledgeAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCashpledgeAmount.ColumnEdit = Me.CashpledgeAmountRepositoryItemTextEdit
        Me.colCashpledgeAmount.DisplayFormat.FormatString = "n2"
        Me.colCashpledgeAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCashpledgeAmount.FieldName = "CashpledgeAmount"
        Me.colCashpledgeAmount.Name = "colCashpledgeAmount"
        Me.colCashpledgeAmount.Visible = True
        Me.colCashpledgeAmount.VisibleIndex = 2
        Me.colCashpledgeAmount.Width = 122
        '
        'CashpledgeAmountRepositoryItemTextEdit
        '
        Me.CashpledgeAmountRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.CashpledgeAmountRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.CashpledgeAmountRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CashpledgeAmountRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CashpledgeAmountRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CashpledgeAmountRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CashpledgeAmountRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CashpledgeAmountRepositoryItemTextEdit.AutoHeight = False
        Me.CashpledgeAmountRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CashpledgeAmountRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CashpledgeAmountRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.CashpledgeAmountRepositoryItemTextEdit.Mask.EditMask = "n2"
        Me.CashpledgeAmountRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.CashpledgeAmountRepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.CashpledgeAmountRepositoryItemTextEdit.Name = "CashpledgeAmountRepositoryItemTextEdit"
        '
        'colObligorRate
        '
        Me.colObligorRate.FieldName = "ObligorRate"
        Me.colObligorRate.Name = "colObligorRate"
        Me.colObligorRate.Width = 96
        '
        'colCreditRiskPledgeAmount
        '
        Me.colCreditRiskPledgeAmount.FieldName = "CreditRiskPledgeAmount"
        Me.colCreditRiskPledgeAmount.Name = "colCreditRiskPledgeAmount"
        Me.colCreditRiskPledgeAmount.Width = 164
        '
        'colValid
        '
        Me.colValid.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colValid.FieldName = "Valid"
        Me.colValid.Name = "colValid"
        Me.colValid.Visible = True
        Me.colValid.VisibleIndex = 3
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Y", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N", "N", 8)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colValidTill
        '
        Me.colValidTill.AppearanceCell.Options.UseTextOptions = True
        Me.colValidTill.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValidTill.Caption = "Valid till"
        Me.colValidTill.DisplayFormat.FormatString = "d"
        Me.colValidTill.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colValidTill.FieldName = "ValidTill"
        Me.colValidTill.Name = "colValidTill"
        Me.colValidTill.Visible = True
        Me.colValidTill.VisibleIndex = 4
        Me.colValidTill.Width = 99
        '
        'ContractArtRepositoryItemComboBox1
        '
        Me.ContractArtRepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ContractArtRepositoryItemComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ContractArtRepositoryItemComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractArtRepositoryItemComboBox1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ContractArtRepositoryItemComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ContractArtRepositoryItemComboBox1.Appearance.Options.UseBackColor = True
        Me.ContractArtRepositoryItemComboBox1.Appearance.Options.UseFont = True
        Me.ContractArtRepositoryItemComboBox1.Appearance.Options.UseForeColor = True
        Me.ContractArtRepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ContractArtRepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractArtRepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ContractArtRepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.ContractArtRepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.ContractArtRepositoryItemComboBox1.AutoHeight = False
        Me.ContractArtRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractArtRepositoryItemComboBox1.Items.AddRange(New Object() {"Client No", "Contract ID"})
        Me.ContractArtRepositoryItemComboBox1.Name = "ContractArtRepositoryItemComboBox1"
        Me.ContractArtRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'ObligorGrateFromRepositoryItemComboBox1
        '
        Me.ObligorGrateFromRepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.Options.UseBackColor = True
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.Options.UseFont = True
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.Options.UseForeColor = True
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.Options.UseTextOptions = True
        Me.ObligorGrateFromRepositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ObligorGrateFromRepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ObligorGrateFromRepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ObligorGrateFromRepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ObligorGrateFromRepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.ObligorGrateFromRepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.ObligorGrateFromRepositoryItemComboBox1.AutoHeight = False
        Me.ObligorGrateFromRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ObligorGrateFromRepositoryItemComboBox1.Items.AddRange(New Object() {"U", "1A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.ObligorGrateFromRepositoryItemComboBox1.Name = "ObligorGrateFromRepositoryItemComboBox1"
        Me.ObligorGrateFromRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'ObligotGrateToRepositoryItemComboBox1
        '
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.Options.UseBackColor = True
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.Options.UseFont = True
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.Options.UseForeColor = True
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.Options.UseTextOptions = True
        Me.ObligotGrateToRepositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ObligotGrateToRepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ObligotGrateToRepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ObligotGrateToRepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ObligotGrateToRepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.ObligotGrateToRepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.ObligotGrateToRepositoryItemComboBox1.AutoHeight = False
        Me.ObligotGrateToRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ObligotGrateToRepositoryItemComboBox1.Items.AddRange(New Object() {"1A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"})
        Me.ObligotGrateToRepositoryItemComboBox1.Name = "ObligotGrateToRepositoryItemComboBox1"
        Me.ObligotGrateToRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
        'Cashpledge_Print_Export_btn
        '
        Me.Cashpledge_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cashpledge_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Cashpledge_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Cashpledge_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Cashpledge_Print_Export_btn.Name = "Cashpledge_Print_Export_btn"
        Me.Cashpledge_Print_Export_btn.Size = New System.Drawing.Size(142, 22)
        Me.Cashpledge_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Cashpledge_Print_Export_btn.TabIndex = 9
        Me.Cashpledge_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1312, 728)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(323, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(847, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Cashpledge_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(146, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(146, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(177, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1170, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(122, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1292, 682)
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
        'CashPledge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1312, 728)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CashPledge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cash pledge"
        CType(Me.RiskControllingBasicsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CREDIT_RISK_CASH_PLEDGEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cashpledge_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientNoRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashpledgeAmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractArtRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObligorGrateFromRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObligotGrateToRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RiskControllingBasicsDataSet As PS_TOOL_DX.RiskControllingBasicsDataSet
    Friend WithEvents CREDIT_RISK_CASH_PLEDGEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CREDIT_RISK_CASH_PLEDGETableAdapter As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CREDIT_RISK_CASH_PLEDGETableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Cashpledge_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContractArtRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ClientNoRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ObligorGrateFromRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ObligotGrateToRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents CashpledgeAmountRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Cashpledge_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents colCustomerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCashpledgeAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObligorRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditRiskPledgeAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colValidTill As DevExpress.XtraGrid.Columns.GridColumn
End Class
