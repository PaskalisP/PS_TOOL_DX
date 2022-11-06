<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExchangeRatesECB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExchangeRatesECB))
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.EXCHANGE_RATES_ECBBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXCHANGE_RATES_ECBTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.EXCHANGE_RATES_ECBTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LoadExchangeRatesECB_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.FromDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ExchangeRatesECBBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXCHANGERATEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
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
        Me.ExchangeRatesOCBSreport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ExchangeRates_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXCHANGE_RATES_ECBBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRatesECBBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EXCHANGE_RATES_ECBBindingSource
        '
        Me.EXCHANGE_RATES_ECBBindingSource.DataMember = "EXCHANGE RATES ECB"
        Me.EXCHANGE_RATES_ECBBindingSource.DataSource = Me.EXTERNALDataset
        '
        'EXCHANGE_RATES_ECBTableAdapter
        '
        Me.EXCHANGE_RATES_ECBTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Me.EXCHANGE_RATES_ECBTableAdapter
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Nothing
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LoadExchangeRatesECB_btn)
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.FromDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.ExchangeRatesOCBSreport_btn)
        Me.LayoutControl1.Controls.Add(Me.ExchangeRates_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1088, 661)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LoadExchangeRatesECB_btn
        '
        Me.LoadExchangeRatesECB_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadExchangeRatesECB_btn.ImageIndex = 6
        Me.LoadExchangeRatesECB_btn.ImageList = Me.ImageCollection1
        Me.LoadExchangeRatesECB_btn.Location = New System.Drawing.Point(465, 12)
        Me.LoadExchangeRatesECB_btn.Name = "LoadExchangeRatesECB_btn"
        Me.LoadExchangeRatesECB_btn.Size = New System.Drawing.Size(134, 22)
        Me.LoadExchangeRatesECB_btn.StyleController = Me.LayoutControl1
        Me.LoadExchangeRatesECB_btn.TabIndex = 8
        Me.LoadExchangeRatesECB_btn.Text = "Load Exchange Rates"
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
        '
        'TillDateEdit
        '
        Me.TillDateEdit.EditValue = Nothing
        Me.TillDateEdit.Location = New System.Drawing.Point(345, 12)
        Me.TillDateEdit.Name = "TillDateEdit"
        Me.TillDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TillDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TillDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TillDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TillDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TillDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TillDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TillDateEdit.Size = New System.Drawing.Size(116, 20)
        Me.TillDateEdit.StyleController = Me.LayoutControl1
        Me.TillDateEdit.TabIndex = 13
        '
        'FromDateEdit
        '
        Me.FromDateEdit.EditValue = Nothing
        Me.FromDateEdit.Location = New System.Drawing.Point(179, 12)
        Me.FromDateEdit.Name = "FromDateEdit"
        Me.FromDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.FromDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FromDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FromDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FromDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FromDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FromDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDateEdit.Size = New System.Drawing.Size(111, 20)
        Me.FromDateEdit.StyleController = Me.LayoutControl1
        Me.FromDateEdit.TabIndex = 12
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.EXCHANGE_RATES_ECBBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ExchangeRatesECBBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2})
        Me.GridControl2.Size = New System.Drawing.Size(1064, 611)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExchangeRatesECBBaseView, Me.CustomerAccountsDetailView, Me.GridView2})
        '
        'ExchangeRatesECBBaseView
        '
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExchangeRatesECBBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.ExchangeRatesECBBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.ExchangeRatesECBBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colCURRENCYRATE, Me.colEXCHANGERATEDATE, Me.GridColumn1})
        Me.ExchangeRatesECBBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExchangeRatesECBBaseView.GridControl = Me.GridControl2
        Me.ExchangeRatesECBBaseView.GroupCount = 1
        Me.ExchangeRatesECBBaseView.Name = "ExchangeRatesECBBaseView"
        Me.ExchangeRatesECBBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExchangeRatesECBBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExchangeRatesECBBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExchangeRatesECBBaseView.OptionsFind.AlwaysVisible = True
        Me.ExchangeRatesECBBaseView.OptionsSelection.MultiSelect = True
        Me.ExchangeRatesECBBaseView.OptionsView.ColumnAutoWidth = False
        Me.ExchangeRatesECBBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExchangeRatesECBBaseView.OptionsView.ShowAutoFilterRow = True
        Me.ExchangeRatesECBBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExchangeRatesECBBaseView.OptionsView.ShowFooter = True
        Me.ExchangeRatesECBBaseView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colEXCHANGERATEDATE, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.colCURRENCYCODE.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYCODE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYCODE.Visible = True
        Me.colCURRENCYCODE.VisibleIndex = 0
        Me.colCURRENCYCODE.Width = 109
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME.OptionsColumn.ReadOnly = True
        Me.colCURRENCYNAME.Visible = True
        Me.colCURRENCYNAME.VisibleIndex = 1
        Me.colCURRENCYNAME.Width = 412
        '
        'colCURRENCYRATE
        '
        Me.colCURRENCYRATE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYRATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCURRENCYRATE.Caption = "EXCHANGE RATE"
        Me.colCURRENCYRATE.FieldName = "CURRENCY RATE"
        Me.colCURRENCYRATE.Name = "colCURRENCYRATE"
        Me.colCURRENCYRATE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYRATE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYRATE.Visible = True
        Me.colCURRENCYRATE.VisibleIndex = 2
        Me.colCURRENCYRATE.Width = 100
        '
        'colEXCHANGERATEDATE
        '
        Me.colEXCHANGERATEDATE.FieldName = "EXCHANGE RATE DATE"
        Me.colEXCHANGERATEDATE.Name = "colEXCHANGERATEDATE"
        Me.colEXCHANGERATEDATE.OptionsColumn.AllowEdit = False
        Me.colEXCHANGERATEDATE.OptionsColumn.ReadOnly = True
        Me.colEXCHANGERATEDATE.Visible = True
        Me.colEXCHANGERATEDATE.VisibleIndex = 3
        Me.colEXCHANGERATEDATE.Width = 123
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn1.AppearanceCell.Options.UseFont = True
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn1.AppearanceHeader.Options.UseFont = True
        Me.GridColumn1.Caption = "in EURO"
        Me.GridColumn1.DisplayFormat.FormatString = "c4"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn1.FieldName = "GridColumn1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.UnboundExpression = "1/[CURRENCY RATE]"
        Me.GridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 95
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A - ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "C - CLOSE ", 3)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
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
        'ExchangeRatesOCBSreport_btn
        '
        Me.ExchangeRatesOCBSreport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExchangeRatesOCBSreport_btn.ImageIndex = 5
        Me.ExchangeRatesOCBSreport_btn.ImageList = Me.ImageCollection1
        Me.ExchangeRatesOCBSreport_btn.Location = New System.Drawing.Point(932, 12)
        Me.ExchangeRatesOCBSreport_btn.Name = "ExchangeRatesOCBSreport_btn"
        Me.ExchangeRatesOCBSreport_btn.Size = New System.Drawing.Size(144, 22)
        Me.ExchangeRatesOCBSreport_btn.StyleController = Me.LayoutControl1
        Me.ExchangeRatesOCBSreport_btn.TabIndex = 7
        Me.ExchangeRatesOCBSreport_btn.Text = "Exchange Rates Report"
        '
        'ExchangeRates_Print_Export_btn
        '
        Me.ExchangeRates_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExchangeRates_Print_Export_btn.ImageIndex = 2
        Me.ExchangeRates_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.ExchangeRates_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.ExchangeRates_Print_Export_btn.Name = "ExchangeRates_Print_Export_btn"
        Me.ExchangeRates_Print_Export_btn.Size = New System.Drawing.Size(112, 22)
        Me.ExchangeRates_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.ExchangeRates_Print_Export_btn.TabIndex = 9
        Me.ExchangeRates_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1088, 661)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(591, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(327, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ExchangeRates_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ExchangeRatesOCBSreport_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(920, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(918, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1068, 615)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TillDateEdit
        Me.LayoutControlItem6.CustomizationFormText = "Date Till"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(282, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Date till"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LoadExchangeRatesECB_btn
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(453, 0)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.FromDateEdit
        Me.LayoutControlItem5.CustomizationFormText = "Date from"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(116, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Date from"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(48, 13)
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
        'ExchangeRatesECB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 661)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExchangeRatesECB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exchange Rates ECB"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXCHANGE_RATES_ECBBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRatesECBBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents EXCHANGE_RATES_ECBBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EXCHANGE_RATES_ECBTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.EXCHANGE_RATES_ECBTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LoadExchangeRatesECB_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents FromDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExchangeRatesECBBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
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
    Friend WithEvents layoutViewField_colAccountStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOnline1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
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
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ExchangeRatesOCBSreport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ExchangeRates_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXCHANGERATEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
