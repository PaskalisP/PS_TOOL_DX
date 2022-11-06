<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuspenceBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SuspenceBalances))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.SUSPENCE_VOLUMESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalancesDataset = New PS_TOOL_DX.BalancesDataset()
        Me.Suspence_Balances_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colExchange_Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSuspence_Acc_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSuspence_Acc_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLedger_Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBalanceDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLedger_Balance_EUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.OdasImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SUSPENCE_VOLUMESTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.SUSPENCE_VOLUMESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LoadOCBS_PostingsBalances_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CustomerAccountNamelbl = New DevExpress.XtraEditors.LabelControl()
        Me.AccountStatusLbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.Account_LookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.CUSTOMERACCOUNTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDealCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colOnline = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEnglishName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRD_TYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOPEN_DATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLOSE_DATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoadOCBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_BookingDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.OCBS_BookingDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.CUSTOMER_ACCOUNTSTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.CUSTOMER_ACCOUNTSTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchText_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUSPENCE_VOLUMESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Suspence_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.Account_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMERACCOUNTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ImageCollection1.Images.SetKeyName(6, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "CrystalReport.jpg")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "cancel_16x16.png")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.SUSPENCE_VOLUMESBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(12, 82)
        Me.GridControl1.MainView = Me.Suspence_Balances_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1409, 454)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Suspence_Balances_BasicView})
        '
        'SUSPENCE_VOLUMESBindingSource
        '
        Me.SUSPENCE_VOLUMESBindingSource.DataMember = "SUSPENCE_VOLUMES"
        Me.SUSPENCE_VOLUMESBindingSource.DataSource = Me.BalancesDataset
        '
        'BalancesDataset
        '
        Me.BalancesDataset.DataSetName = "BalancesDataset"
        Me.BalancesDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Suspence_Balances_BasicView
        '
        Me.Suspence_Balances_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Suspence_Balances_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Suspence_Balances_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Suspence_Balances_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Suspence_Balances_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Suspence_Balances_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Suspence_Balances_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Suspence_Balances_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colExchange_Rate, Me.colID1, Me.colCurrency, Me.colSuspence_Acc_Nr, Me.colSuspence_Acc_Name, Me.colLedger_Balance, Me.colBalanceDate, Me.colLedger_Balance_EUR})
        Me.Suspence_Balances_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Aqua
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Aqua
        StyleFormatCondition1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseFont = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Expression = "CLOSING BALANCE"
        StyleFormatCondition1.Value1 = "CLOSING BALANCE"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Aqua
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseFont = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.ApplyToRow = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Expression = "OPENING BALANCE"
        StyleFormatCondition2.Value1 = "OPENING BALANCE"
        Me.Suspence_Balances_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.Suspence_Balances_BasicView.GridControl = Me.GridControl1
        Me.Suspence_Balances_BasicView.Name = "Suspence_Balances_BasicView"
        Me.Suspence_Balances_BasicView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Suspence_Balances_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Suspence_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Suspence_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Suspence_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.Suspence_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.Suspence_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.Suspence_Balances_BasicView.OptionsMenu.ShowFooterItem = True
        Me.Suspence_Balances_BasicView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Suspence_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.Suspence_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.Suspence_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.Suspence_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.Suspence_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Suspence_Balances_BasicView.OptionsView.ShowFooter = True
        Me.Suspence_Balances_BasicView.PaintStyleName = "Skin"
        Me.Suspence_Balances_BasicView.ViewCaption = "Results by GL Item"
        '
        'colExchange_Rate
        '
        Me.colExchange_Rate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchange_Rate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchange_Rate.Caption = "Exchange Rate"
        Me.colExchange_Rate.DisplayFormat.FormatString = "n4"
        Me.colExchange_Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchange_Rate.FieldName = "Exchange_Rate"
        Me.colExchange_Rate.Name = "colExchange_Rate"
        Me.colExchange_Rate.OptionsColumn.AllowEdit = False
        Me.colExchange_Rate.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate.Visible = True
        Me.colExchange_Rate.VisibleIndex = 5
        Me.colExchange_Rate.Width = 106
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colCurrency
        '
        Me.colCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrency.Caption = "CUR"
        Me.colCurrency.FieldName = "Currency"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.OptionsColumn.AllowEdit = False
        Me.colCurrency.OptionsColumn.ReadOnly = True
        Me.colCurrency.Visible = True
        Me.colCurrency.VisibleIndex = 3
        '
        'colSuspence_Acc_Nr
        '
        Me.colSuspence_Acc_Nr.Caption = "Account Nr."
        Me.colSuspence_Acc_Nr.FieldName = "Suspence_Acc_Nr"
        Me.colSuspence_Acc_Nr.Name = "colSuspence_Acc_Nr"
        Me.colSuspence_Acc_Nr.OptionsColumn.ReadOnly = True
        Me.colSuspence_Acc_Nr.Visible = True
        Me.colSuspence_Acc_Nr.VisibleIndex = 1
        Me.colSuspence_Acc_Nr.Width = 173
        '
        'colSuspence_Acc_Name
        '
        Me.colSuspence_Acc_Name.Caption = "Account Name"
        Me.colSuspence_Acc_Name.FieldName = "Suspence_Acc_Name"
        Me.colSuspence_Acc_Name.Name = "colSuspence_Acc_Name"
        Me.colSuspence_Acc_Name.OptionsColumn.AllowEdit = False
        Me.colSuspence_Acc_Name.OptionsColumn.ReadOnly = True
        Me.colSuspence_Acc_Name.Visible = True
        Me.colSuspence_Acc_Name.VisibleIndex = 2
        Me.colSuspence_Acc_Name.Width = 479
        '
        'colLedger_Balance
        '
        Me.colLedger_Balance.AppearanceCell.Options.UseTextOptions = True
        Me.colLedger_Balance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLedger_Balance.Caption = "Ledger Balance"
        Me.colLedger_Balance.DisplayFormat.FormatString = "n2"
        Me.colLedger_Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLedger_Balance.FieldName = "Ledger_Balance"
        Me.colLedger_Balance.Name = "colLedger_Balance"
        Me.colLedger_Balance.OptionsColumn.AllowEdit = False
        Me.colLedger_Balance.OptionsColumn.ReadOnly = True
        Me.colLedger_Balance.Visible = True
        Me.colLedger_Balance.VisibleIndex = 4
        Me.colLedger_Balance.Width = 162
        '
        'colBalanceDate
        '
        Me.colBalanceDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBalanceDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBalanceDate.FieldName = "BalanceDate"
        Me.colBalanceDate.Name = "colBalanceDate"
        Me.colBalanceDate.OptionsColumn.AllowEdit = False
        Me.colBalanceDate.OptionsColumn.ReadOnly = True
        Me.colBalanceDate.Visible = True
        Me.colBalanceDate.VisibleIndex = 0
        Me.colBalanceDate.Width = 113
        '
        'colLedger_Balance_EUR
        '
        Me.colLedger_Balance_EUR.AppearanceCell.Options.UseTextOptions = True
        Me.colLedger_Balance_EUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLedger_Balance_EUR.Caption = "Ledger Balance (EUR)"
        Me.colLedger_Balance_EUR.DisplayFormat.FormatString = "n2"
        Me.colLedger_Balance_EUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLedger_Balance_EUR.FieldName = "Ledger_Balance_EUR"
        Me.colLedger_Balance_EUR.Name = "colLedger_Balance_EUR"
        Me.colLedger_Balance_EUR.OptionsColumn.AllowEdit = False
        Me.colLedger_Balance_EUR.OptionsColumn.ReadOnly = True
        Me.colLedger_Balance_EUR.Visible = True
        Me.colLedger_Balance_EUR.VisibleIndex = 6
        Me.colLedger_Balance_EUR.Width = 182
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceDropDown.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceDropDown.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.DropDownRows = 2
        Me.RepositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox1.ImmediatePopup = True
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'OdasImportProcedureRepositoryItemTextEdit
        '
        Me.OdasImportProcedureRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AutoHeight = False
        Me.OdasImportProcedureRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OdasImportProcedureRepositoryItemTextEdit.Name = "OdasImportProcedureRepositoryItemTextEdit"
        '
        'RepositoryItemTextEditBIC8
        '
        Me.RepositoryItemTextEditBIC8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEditBIC8.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC8.AutoHeight = False
        Me.RepositoryItemTextEditBIC8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEditBIC8.Mask.BeepOnError = True
        Me.RepositoryItemTextEditBIC8.Mask.EditMask = "[A-Z]{6}[1-9A-Z]{2}"
        Me.RepositoryItemTextEditBIC8.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEditBIC8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEditBIC8.Name = "RepositoryItemTextEditBIC8"
        '
        'RepositoryItemTextEditBIC3
        '
        Me.RepositoryItemTextEditBIC3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEditBIC3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC3.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC3.AutoHeight = False
        Me.RepositoryItemTextEditBIC3.Mask.EditMask = "[1-9A-Z]{3}"
        Me.RepositoryItemTextEditBIC3.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEditBIC3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEditBIC3.Name = "RepositoryItemTextEditBIC3"
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.AllowFocused = False
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AutoHeight = False
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        Me.RepositoryItemMemoExEdit2.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RepositoryItemMemoExEdit2.ShowIcon = False
        '
        'ValidRepositoryItemImageComboBox
        '
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ValidRepositoryItemImageComboBox.AutoHeight = False
        Me.ValidRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CANCELLED", "N", 3)})
        Me.ValidRepositoryItemImageComboBox.Name = "ValidRepositoryItemImageComboBox"
        '
        'SUSPENCE_VOLUMESTableAdapter
        '
        Me.SUSPENCE_VOLUMESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_VOSTRO_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.NOSTRO_BALANCESTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.SUSPENCE_VOLUMESTableAdapter = Me.SUSPENCE_VOLUMESTableAdapter
        Me.TableAdapterManager.SWIFT_ACC_STATEMENTSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_PostingsBalances_btn)
        Me.GroupControl2.Controls.Add(Me.CustomerAccountNamelbl)
        Me.GroupControl2.Controls.Add(Me.AccountStatusLbl)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.Account_LookUpEdit)
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_btn)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_Till)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_From)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Location = New System.Drawing.Point(490, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(587, 151)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Search by Suspence Accounts"
        '
        'LoadOCBS_PostingsBalances_btn
        '
        Me.LoadOCBS_PostingsBalances_btn.ImageOptions.ImageIndex = 6
        Me.LoadOCBS_PostingsBalances_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadOCBS_PostingsBalances_btn.Location = New System.Drawing.Point(394, 118)
        Me.LoadOCBS_PostingsBalances_btn.Name = "LoadOCBS_PostingsBalances_btn"
        Me.LoadOCBS_PostingsBalances_btn.Size = New System.Drawing.Size(184, 23)
        Me.LoadOCBS_PostingsBalances_btn.TabIndex = 32
        Me.LoadOCBS_PostingsBalances_btn.Text = "Load Postings + Ledger Balances"
        Me.LoadOCBS_PostingsBalances_btn.Visible = False
        '
        'CustomerAccountNamelbl
        '
        Me.CustomerAccountNamelbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CustomerAccountNamelbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerAccountNamelbl.Appearance.Options.UseFont = True
        Me.CustomerAccountNamelbl.Appearance.Options.UseForeColor = True
        Me.CustomerAccountNamelbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CustomerAccountNamelbl.Location = New System.Drawing.Point(14, 73)
        Me.CustomerAccountNamelbl.Name = "CustomerAccountNamelbl"
        Me.CustomerAccountNamelbl.Size = New System.Drawing.Size(457, 22)
        Me.CustomerAccountNamelbl.TabIndex = 31
        '
        'AccountStatusLbl
        '
        Me.AccountStatusLbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AccountStatusLbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.AccountStatusLbl.Appearance.Options.UseFont = True
        Me.AccountStatusLbl.Appearance.Options.UseForeColor = True
        Me.AccountStatusLbl.Appearance.Options.UseTextOptions = True
        Me.AccountStatusLbl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.AccountStatusLbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.AccountStatusLbl.Location = New System.Drawing.Point(206, 24)
        Me.AccountStatusLbl.Name = "AccountStatusLbl"
        Me.AccountStatusLbl.Size = New System.Drawing.Size(265, 43)
        Me.AccountStatusLbl.TabIndex = 3
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl11.Location = New System.Drawing.Point(13, 32)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(186, 14)
        Me.LabelControl11.TabIndex = 1
        Me.LabelControl11.Text = "Suspence Account"
        '
        'Account_LookUpEdit
        '
        Me.Account_LookUpEdit.Location = New System.Drawing.Point(13, 47)
        Me.Account_LookUpEdit.Name = "Account_LookUpEdit"
        Me.Account_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Account_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Account_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Account_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Account_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Account_LookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.Account_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Account_LookUpEdit.Properties.DataSource = Me.CUSTOMERACCOUNTSBindingSource
        Me.Account_LookUpEdit.Properties.DisplayMember = "Client Account"
        Me.Account_LookUpEdit.Properties.NullText = ""
        Me.Account_LookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(500, 650)
        Me.Account_LookUpEdit.Properties.PopupView = Me.GridView1
        Me.Account_LookUpEdit.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1})
        Me.Account_LookUpEdit.Properties.ValueMember = "Client Account"
        Me.Account_LookUpEdit.Size = New System.Drawing.Size(186, 20)
        Me.Account_LookUpEdit.TabIndex = 2
        '
        'CUSTOMERACCOUNTSBindingSource
        '
        Me.CUSTOMERACCOUNTSBindingSource.DataMember = "CUSTOMER_ACCOUNTS"
        Me.CUSTOMERACCOUNTSBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colClientNo2, Me.colClientAccount, Me.colDealCurrency, Me.colAccountStatus, Me.colOnline, Me.colEnglishName, Me.colProductCode, Me.colCurrencyStatus, Me.colCountry, Me.colPRD_TYPE, Me.colOPEN_DATE, Me.colCLOSE_DATE})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colClientNo2
        '
        Me.colClientNo2.FieldName = "ClientNo"
        Me.colClientNo2.Name = "colClientNo2"
        Me.colClientNo2.OptionsColumn.AllowEdit = False
        Me.colClientNo2.OptionsColumn.ReadOnly = True
        Me.colClientNo2.Visible = True
        Me.colClientNo2.VisibleIndex = 3
        '
        'colClientAccount
        '
        Me.colClientAccount.Caption = "Account"
        Me.colClientAccount.FieldName = "Client Account"
        Me.colClientAccount.Name = "colClientAccount"
        Me.colClientAccount.OptionsColumn.AllowEdit = False
        Me.colClientAccount.OptionsColumn.ReadOnly = True
        Me.colClientAccount.Visible = True
        Me.colClientAccount.VisibleIndex = 0
        Me.colClientAccount.Width = 124
        '
        'colDealCurrency
        '
        Me.colDealCurrency.Caption = "Currency"
        Me.colDealCurrency.FieldName = "Deal Currency"
        Me.colDealCurrency.Name = "colDealCurrency"
        Me.colDealCurrency.OptionsColumn.AllowEdit = False
        Me.colDealCurrency.OptionsColumn.ReadOnly = True
        Me.colDealCurrency.Visible = True
        Me.colDealCurrency.VisibleIndex = 1
        Me.colDealCurrency.Width = 92
        '
        'colAccountStatus
        '
        Me.colAccountStatus.Caption = "Status"
        Me.colAccountStatus.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colAccountStatus.FieldName = "Account Status"
        Me.colAccountStatus.Name = "colAccountStatus"
        Me.colAccountStatus.OptionsColumn.AllowEdit = False
        Me.colAccountStatus.OptionsColumn.ReadOnly = True
        Me.colAccountStatus.Visible = True
        Me.colAccountStatus.VisibleIndex = 4
        Me.colAccountStatus.Width = 99
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("A - ACTIVE", "A - ACTIVE", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("C - CLOSE", "C - CLOSE", 9)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colOnline
        '
        Me.colOnline.FieldName = "Online"
        Me.colOnline.Name = "colOnline"
        Me.colOnline.OptionsColumn.AllowEdit = False
        Me.colOnline.OptionsColumn.ReadOnly = True
        Me.colOnline.Visible = True
        Me.colOnline.VisibleIndex = 5
        '
        'colEnglishName
        '
        Me.colEnglishName.Caption = "Customer Name"
        Me.colEnglishName.FieldName = "English Name"
        Me.colEnglishName.Name = "colEnglishName"
        Me.colEnglishName.OptionsColumn.AllowEdit = False
        Me.colEnglishName.OptionsColumn.ReadOnly = True
        Me.colEnglishName.Visible = True
        Me.colEnglishName.VisibleIndex = 2
        Me.colEnglishName.Width = 346
        '
        'colProductCode
        '
        Me.colProductCode.FieldName = "ProductCode"
        Me.colProductCode.Name = "colProductCode"
        Me.colProductCode.OptionsColumn.AllowEdit = False
        Me.colProductCode.OptionsColumn.ReadOnly = True
        '
        'colCurrencyStatus
        '
        Me.colCurrencyStatus.FieldName = "Currency Status"
        Me.colCurrencyStatus.Name = "colCurrencyStatus"
        Me.colCurrencyStatus.OptionsColumn.AllowEdit = False
        Me.colCurrencyStatus.OptionsColumn.ReadOnly = True
        '
        'colCountry
        '
        Me.colCountry.FieldName = "Country"
        Me.colCountry.Name = "colCountry"
        Me.colCountry.OptionsColumn.AllowEdit = False
        Me.colCountry.OptionsColumn.ReadOnly = True
        Me.colCountry.Visible = True
        Me.colCountry.VisibleIndex = 6
        '
        'colPRD_TYPE
        '
        Me.colPRD_TYPE.FieldName = "PRD_TYPE"
        Me.colPRD_TYPE.Name = "colPRD_TYPE"
        Me.colPRD_TYPE.OptionsColumn.AllowEdit = False
        Me.colPRD_TYPE.OptionsColumn.ReadOnly = True
        '
        'colOPEN_DATE
        '
        Me.colOPEN_DATE.Caption = "Opened on"
        Me.colOPEN_DATE.FieldName = "OPEN_DATE"
        Me.colOPEN_DATE.Name = "colOPEN_DATE"
        Me.colOPEN_DATE.OptionsColumn.AllowEdit = False
        Me.colOPEN_DATE.OptionsColumn.ReadOnly = True
        Me.colOPEN_DATE.Visible = True
        Me.colOPEN_DATE.VisibleIndex = 7
        '
        'colCLOSE_DATE
        '
        Me.colCLOSE_DATE.Caption = "Closed on"
        Me.colCLOSE_DATE.FieldName = "CLOSE_DATE"
        Me.colCLOSE_DATE.Name = "colCLOSE_DATE"
        Me.colCLOSE_DATE.OptionsColumn.AllowEdit = False
        Me.colCLOSE_DATE.OptionsColumn.ReadOnly = True
        Me.colCLOSE_DATE.Visible = True
        Me.colCLOSE_DATE.VisibleIndex = 8
        '
        'LoadOCBS_btn
        '
        Me.LoadOCBS_btn.ImageOptions.ImageIndex = 6
        Me.LoadOCBS_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadOCBS_btn.Location = New System.Drawing.Point(246, 118)
        Me.LoadOCBS_btn.Name = "LoadOCBS_btn"
        Me.LoadOCBS_btn.Size = New System.Drawing.Size(142, 23)
        Me.LoadOCBS_btn.TabIndex = 9
        Me.LoadOCBS_btn.Text = "Load Ledger Balances"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl12.Location = New System.Drawing.Point(129, 100)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(52, 21)
        Me.LabelControl12.TabIndex = 7
        Me.LabelControl12.Text = "Date till"
        '
        'OCBS_BookingDate_Till
        '
        Me.OCBS_BookingDate_Till.EditValue = Nothing
        Me.OCBS_BookingDate_Till.Location = New System.Drawing.Point(129, 121)
        Me.OCBS_BookingDate_Till.Name = "OCBS_BookingDate_Till"
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OCBS_BookingDate_Till.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.OCBS_BookingDate_Till.Size = New System.Drawing.Size(100, 20)
        Me.OCBS_BookingDate_Till.TabIndex = 8
        '
        'OCBS_BookingDate_From
        '
        Me.OCBS_BookingDate_From.EditValue = Nothing
        Me.OCBS_BookingDate_From.Location = New System.Drawing.Point(13, 121)
        Me.OCBS_BookingDate_From.Name = "OCBS_BookingDate_From"
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OCBS_BookingDate_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.OCBS_BookingDate_From.Size = New System.Drawing.Size(100, 20)
        Me.OCBS_BookingDate_From.TabIndex = 6
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl14.Appearance.Options.UseFont = True
        Me.LabelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl14.Location = New System.Drawing.Point(13, 100)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(60, 20)
        Me.LabelControl14.TabIndex = 5
        Me.LabelControl14.Text = "Date from"
        '
        'CUSTOMER_ACCOUNTSTableAdapter
        '
        Me.CUSTOMER_ACCOUNTSTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.SearchText_lbl)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 169)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1433, 548)
        Me.LayoutControl1.TabIndex = 121
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SearchText_lbl
        '
        Me.SearchText_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SearchText_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.SearchText_lbl.Appearance.Options.UseFont = True
        Me.SearchText_lbl.Appearance.Options.UseForeColor = True
        Me.SearchText_lbl.Appearance.Options.UseTextOptions = True
        Me.SearchText_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SearchText_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.SearchText_lbl.Location = New System.Drawing.Point(12, 62)
        Me.SearchText_lbl.Name = "SearchText_lbl"
        Me.SearchText_lbl.Size = New System.Drawing.Size(1409, 16)
        Me.SearchText_lbl.StyleController = Me.LayoutControl1
        Me.SearchText_lbl.TabIndex = 117
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(161, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 10
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1328, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(81, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1433, 548)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1413, 458)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1413, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1304, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(85, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(165, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1139, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(165, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchText_lbl
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1413, 20)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SuspenceBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 711)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SuspenceBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suspence Accounts Balances"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUSPENCE_VOLUMESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Suspence_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.Account_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMERACCOUNTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BalancesDataset As PS_TOOL_DX.BalancesDataset
    Friend WithEvents SUSPENCE_VOLUMESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUSPENCE_VOLUMESTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.SUSPENCE_VOLUMESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CustomerAccountNamelbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents AccountStatusLbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Account_LookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDealCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOnline As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEnglishName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRD_TYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOPEN_DATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLOSE_DATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LoadOCBS_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_BookingDate_Till As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OCBS_BookingDate_From As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents CUSTOMERACCOUNTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUSTOMER_ACCOUNTSTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.CUSTOMER_ACCOUNTSTableAdapter
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchText_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Suspence_Balances_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents OdasImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colExchange_Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSuspence_Acc_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSuspence_Acc_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLedger_Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBalanceDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLedger_Balance_EUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LoadOCBS_PostingsBalances_btn As DevExpress.XtraEditors.SimpleButton
End Class
