<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreditRiskRules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditRiskRules))
        Me.RiskControllingBasicsDataSet = New PS_TOOL_DX.RiskControllingBasicsDataSet()
        Me.CREDIT_RISK_RULESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CREDIT_RISK_RULESTableAdapter = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CREDIT_RISK_RULESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.CreditRiskRulesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractArt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContractArtRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colContractCollateralID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContractIDRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colObligorRatefrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ObligorGrateFromRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colObligorRateto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ObligotGrateToRepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ContractTypesRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CreditRiskRules_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
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
        CType(Me.CREDIT_RISK_RULESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditRiskRulesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractArtRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractIDRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObligorGrateFromRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObligotGrateToRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractTypesRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'CREDIT_RISK_RULESBindingSource
        '
        Me.CREDIT_RISK_RULESBindingSource.DataMember = "CREDIT RISK RULES"
        Me.CREDIT_RISK_RULESBindingSource.DataSource = Me.RiskControllingBasicsDataSet
        '
        'CREDIT_RISK_RULESTableAdapter
        '
        Me.CREDIT_RISK_RULESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CREDIT_RISK_CASH_PLEDGETableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISK_RULESTableAdapter = Me.CREDIT_RISK_RULESTableAdapter
        Me.TableAdapterManager.CUSTOMER_RATINGTableAdapter = Nothing
        Me.TableAdapterManager.Daily_Art13_Kwg_ChineseBanksTableAdapter = Nothing
        Me.TableAdapterManager.INTERNAL_GUARANTEESTableAdapter = Nothing
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
        Me.LayoutControl1.Controls.Add(Me.CreditRiskRules_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1306, 732)
        Me.LayoutControl1.TabIndex = 7
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.CREDIT_RISK_RULESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.CreditRiskRulesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ContractIDRepositoryItemTextEdit1, Me.ContractTypesRepositoryItemTextEdit, Me.ContractArtRepositoryItemComboBox1, Me.ObligorGrateFromRepositoryItemComboBox1, Me.ObligotGrateToRepositoryItemComboBox1})
        Me.GridControl2.Size = New System.Drawing.Size(1282, 682)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CreditRiskRulesBaseView})
        '
        'CreditRiskRulesBaseView
        '
        Me.CreditRiskRulesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CreditRiskRulesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CreditRiskRulesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CreditRiskRulesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CreditRiskRulesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CreditRiskRulesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.GridColumn1, Me.colContractArt, Me.colContractCollateralID, Me.colObligorRatefrom, Me.colObligorRateto, Me.colValid})
        Me.CreditRiskRulesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CreditRiskRulesBaseView.GridControl = Me.GridControl2
        Me.CreditRiskRulesBaseView.Name = "CreditRiskRulesBaseView"
        Me.CreditRiskRulesBaseView.NewItemRowText = "Add new Credit Risk Rule"
        Me.CreditRiskRulesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CreditRiskRulesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CreditRiskRulesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.CreditRiskRulesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CreditRiskRulesBaseView.OptionsFind.AlwaysVisible = True
        Me.CreditRiskRulesBaseView.OptionsSelection.MultiSelect = True
        Me.CreditRiskRulesBaseView.OptionsView.ColumnAutoWidth = False
        Me.CreditRiskRulesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CreditRiskRulesBaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.CreditRiskRulesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.CreditRiskRulesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CreditRiskRulesBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 403
        '
        'colContractArt
        '
        Me.colContractArt.AppearanceCell.Options.UseTextOptions = True
        Me.colContractArt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colContractArt.ColumnEdit = Me.ContractArtRepositoryItemComboBox1
        Me.colContractArt.FieldName = "ContractArt"
        Me.colContractArt.Name = "colContractArt"
        Me.colContractArt.Visible = True
        Me.colContractArt.VisibleIndex = 1
        Me.colContractArt.Width = 137
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
        'colContractCollateralID
        '
        Me.colContractCollateralID.Caption = "Number"
        Me.colContractCollateralID.ColumnEdit = Me.ContractIDRepositoryItemTextEdit1
        Me.colContractCollateralID.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID.Name = "colContractCollateralID"
        Me.colContractCollateralID.Visible = True
        Me.colContractCollateralID.VisibleIndex = 2
        Me.colContractCollateralID.Width = 154
        '
        'ContractIDRepositoryItemTextEdit1
        '
        Me.ContractIDRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ContractIDRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ContractIDRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractIDRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ContractIDRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ContractIDRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.ContractIDRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.ContractIDRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.ContractIDRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ContractIDRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractIDRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ContractIDRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ContractIDRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ContractIDRepositoryItemTextEdit1.AutoHeight = False
        Me.ContractIDRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContractIDRepositoryItemTextEdit1.Mask.EditMask = "d"
        Me.ContractIDRepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ContractIDRepositoryItemTextEdit1.Name = "ContractIDRepositoryItemTextEdit1"
        '
        'colObligorRatefrom
        '
        Me.colObligorRatefrom.AppearanceCell.Options.UseTextOptions = True
        Me.colObligorRatefrom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colObligorRatefrom.Caption = "Obligor Grate from"
        Me.colObligorRatefrom.ColumnEdit = Me.ObligorGrateFromRepositoryItemComboBox1
        Me.colObligorRatefrom.FieldName = "Obligor Rate from"
        Me.colObligorRatefrom.Name = "colObligorRatefrom"
        Me.colObligorRatefrom.Visible = True
        Me.colObligorRatefrom.VisibleIndex = 3
        Me.colObligorRatefrom.Width = 100
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
        'colObligorRateto
        '
        Me.colObligorRateto.AppearanceCell.Options.UseTextOptions = True
        Me.colObligorRateto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colObligorRateto.Caption = "Obligot Grate to"
        Me.colObligorRateto.ColumnEdit = Me.ObligotGrateToRepositoryItemComboBox1
        Me.colObligorRateto.FieldName = "Obligor Rate to"
        Me.colObligorRateto.Name = "colObligorRateto"
        Me.colObligorRateto.Visible = True
        Me.colObligorRateto.VisibleIndex = 4
        Me.colObligorRateto.Width = 94
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
        'colValid
        '
        Me.colValid.AppearanceCell.Options.UseTextOptions = True
        Me.colValid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValid.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colValid.FieldName = "Valid"
        Me.colValid.Name = "colValid"
        Me.colValid.Visible = True
        Me.colValid.VisibleIndex = 5
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
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Y", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N", "N", 3)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
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
        '
        'ContractTypesRepositoryItemTextEdit
        '
        Me.ContractTypesRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ContractTypesRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ContractTypesRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ContractTypesRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.ContractTypesRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.ContractTypesRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.ContractTypesRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ContractTypesRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ContractTypesRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ContractTypesRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ContractTypesRepositoryItemTextEdit.AutoHeight = False
        Me.ContractTypesRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ContractTypesRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ContractTypesRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.ContractTypesRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.ContractTypesRepositoryItemTextEdit.Name = "ContractTypesRepositoryItemTextEdit"
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
        'CreditRiskRules_Print_Export_btn
        '
        Me.CreditRiskRules_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CreditRiskRules_Print_Export_btn.ImageIndex = 2
        Me.CreditRiskRules_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.CreditRiskRules_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.CreditRiskRules_Print_Export_btn.Name = "CreditRiskRules_Print_Export_btn"
        Me.CreditRiskRules_Print_Export_btn.Size = New System.Drawing.Size(141, 22)
        Me.CreditRiskRules_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.CreditRiskRules_Print_Export_btn.TabIndex = 9
        Me.CreditRiskRules_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1306, 732)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(321, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(844, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CreditRiskRules_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(145, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(145, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(176, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1165, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(121, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1286, 686)
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
        'CreditRiskRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1306, 732)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreditRiskRules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Credit Risk Rules"
        CType(Me.RiskControllingBasicsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CREDIT_RISK_RULESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditRiskRulesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractArtRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractIDRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObligorGrateFromRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObligotGrateToRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractTypesRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CREDIT_RISK_RULESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CREDIT_RISK_RULESTableAdapter As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CREDIT_RISK_RULESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CreditRiskRulesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContractTypesRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ContractIDRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CreditRiskRules_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractArt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObligorRatefrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObligorRateto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContractArtRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ObligorGrateFromRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ObligotGrateToRepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
