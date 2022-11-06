<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequeCollections
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequeCollections))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.ClearingDataSet = New PS_TOOL_DX.ClearingDataSet()
        Me.CHEQUE_COLLECTIONSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CHEQUE_COLLECTIONSTableAdapter = New PS_TOOL_DX.ClearingDataSetTableAdapters.CHEQUE_COLLECTIONSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.ClearingDataSetTableAdapters.TableAdapterManager()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ChequeCollections_Basic_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIncomingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImport_Export_Cheque = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ImportExportRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colChequeCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrencyRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.colChequeAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colExchange_Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChequeAmountEURO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChequeNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colDrawerBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryDrawerBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CountryRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.COUNTRIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colDraweeBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryDraweeBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChequeSettlement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChequeSettlementRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadChequeData_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ChequeFromDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ChequeTillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.RecalculateCreditRiskDropDownButton = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.InterestRateRiskReportsDropDownButton = New DevExpress.XtraEditors.DropDownButton()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CURRENCIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter()
        Me.COUNTRIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.COUNTRIESTableAdapter()
        CType(Me.ClearingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHEQUE_COLLECTIONSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeCollections_Basic_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportExportRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COUNTRIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeSettlementRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeFromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeFromDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeTillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequeTillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClearingDataSet
        '
        Me.ClearingDataSet.DataSetName = "ClearingDataSet"
        Me.ClearingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CHEQUE_COLLECTIONSBindingSource
        '
        Me.CHEQUE_COLLECTIONSBindingSource.DataMember = "CHEQUE_COLLECTIONS"
        Me.CHEQUE_COLLECTIONSBindingSource.DataSource = Me.ClearingDataSet
        '
        'CHEQUE_COLLECTIONSTableAdapter
        '
        Me.CHEQUE_COLLECTIONSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CHEQUE_COLLECTIONSTableAdapter = Me.CHEQUE_COLLECTIONSTableAdapter
        Me.TableAdapterManager.GMPS_PAYMENTS_INTableAdapter = Nothing
        Me.TableAdapterManager.GMPS_PAYMENTS_OUTTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_REMMITANCESTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ClearingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.ImageCollection1.Images.SetKeyName(8, "Calculator.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "save_16x16.png")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.CHEQUE_COLLECTIONSBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.ChequeCollections_Basic_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ImportExportRepositoryItemComboBox, Me.ChequeSettlementRepositoryItemComboBox, Me.CurrencyRepositoryItemLookUpEdit, Me.CountryRepositoryItemLookUpEdit, Me.RepositoryItemTextEdit1, Me.AmountRepositoryItemTextEdit})
        Me.GridControl1.Size = New System.Drawing.Size(1498, 680)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ChequeCollections_Basic_GridView})
        '
        'ChequeCollections_Basic_GridView
        '
        Me.ChequeCollections_Basic_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ChequeCollections_Basic_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ChequeCollections_Basic_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ChequeCollections_Basic_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ChequeCollections_Basic_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ChequeCollections_Basic_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colIncomingDate, Me.colImport_Export_Cheque, Me.colChequeCurrency, Me.colChequeAmount, Me.colExchange_Rate, Me.colChequeAmountEURO, Me.colChequeNo, Me.colDrawerBank, Me.colCountryDrawerBank, Me.colDraweeBank, Me.colCountryDraweeBank, Me.colChequeSettlement})
        Me.ChequeCollections_Basic_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[Obligor Rate] != ?"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[Client No] != ?"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[Counterparty/Issuer/Collateral Name] != ?"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[Contract Collateral ID] != ?"
        Me.ChequeCollections_Basic_GridView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3, StyleFormatCondition4})
        Me.ChequeCollections_Basic_GridView.GridControl = Me.GridControl1
        Me.ChequeCollections_Basic_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}")})
        Me.ChequeCollections_Basic_GridView.Name = "ChequeCollections_Basic_GridView"
        Me.ChequeCollections_Basic_GridView.NewItemRowText = "Add new Cheque Collection"
        Me.ChequeCollections_Basic_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChequeCollections_Basic_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChequeCollections_Basic_GridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.ChequeCollections_Basic_GridView.OptionsCustomization.AllowRowSizing = True
        Me.ChequeCollections_Basic_GridView.OptionsEditForm.EditFormColumnCount = 4
        Me.ChequeCollections_Basic_GridView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChequeCollections_Basic_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ChequeCollections_Basic_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ChequeCollections_Basic_GridView.OptionsFind.AlwaysVisible = True
        Me.ChequeCollections_Basic_GridView.OptionsSelection.MultiSelect = True
        Me.ChequeCollections_Basic_GridView.OptionsView.ColumnAutoWidth = False
        Me.ChequeCollections_Basic_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.ChequeCollections_Basic_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ChequeCollections_Basic_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ChequeCollections_Basic_GridView.OptionsView.ShowAutoFilterRow = True
        Me.ChequeCollections_Basic_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ChequeCollections_Basic_GridView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colIncomingDate
        '
        Me.colIncomingDate.AppearanceCell.Options.UseTextOptions = True
        Me.colIncomingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIncomingDate.FieldName = "IncomingDate"
        Me.colIncomingDate.Name = "colIncomingDate"
        Me.colIncomingDate.Visible = True
        Me.colIncomingDate.VisibleIndex = 0
        Me.colIncomingDate.Width = 99
        '
        'colImport_Export_Cheque
        '
        Me.colImport_Export_Cheque.AppearanceCell.Options.UseTextOptions = True
        Me.colImport_Export_Cheque.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colImport_Export_Cheque.Caption = "Im-Export Cheque"
        Me.colImport_Export_Cheque.ColumnEdit = Me.ImportExportRepositoryItemComboBox
        Me.colImport_Export_Cheque.FieldName = "Import_Export_Cheque"
        Me.colImport_Export_Cheque.Name = "colImport_Export_Cheque"
        Me.colImport_Export_Cheque.Visible = True
        Me.colImport_Export_Cheque.VisibleIndex = 1
        Me.colImport_Export_Cheque.Width = 105
        '
        'ImportExportRepositoryItemComboBox
        '
        Me.ImportExportRepositoryItemComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ImportExportRepositoryItemComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ImportExportRepositoryItemComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ImportExportRepositoryItemComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ImportExportRepositoryItemComboBox.Appearance.Options.UseBackColor = True
        Me.ImportExportRepositoryItemComboBox.Appearance.Options.UseForeColor = True
        Me.ImportExportRepositoryItemComboBox.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.ImportExportRepositoryItemComboBox.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.ImportExportRepositoryItemComboBox.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.ImportExportRepositoryItemComboBox.AppearanceDropDown.Options.UseBackColor = True
        Me.ImportExportRepositoryItemComboBox.AppearanceDropDown.Options.UseForeColor = True
        Me.ImportExportRepositoryItemComboBox.AutoHeight = False
        Me.ImportExportRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImportExportRepositoryItemComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ImportExportRepositoryItemComboBox.DropDownRows = 2
        Me.ImportExportRepositoryItemComboBox.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ImportExportRepositoryItemComboBox.ImmediatePopup = True
        Me.ImportExportRepositoryItemComboBox.Items.AddRange(New Object() {"IMPORT", "EXPORT"})
        Me.ImportExportRepositoryItemComboBox.Name = "ImportExportRepositoryItemComboBox"
        Me.ImportExportRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colChequeCurrency
        '
        Me.colChequeCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.colChequeCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colChequeCurrency.Caption = "Currency"
        Me.colChequeCurrency.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit
        Me.colChequeCurrency.FieldName = "ChequeCurrency"
        Me.colChequeCurrency.Name = "colChequeCurrency"
        Me.colChequeCurrency.OptionsEditForm.StartNewRow = True
        Me.colChequeCurrency.Visible = True
        Me.colChequeCurrency.VisibleIndex = 2
        Me.colChequeCurrency.Width = 55
        '
        'CurrencyRepositoryItemLookUpEdit
        '
        Me.CurrencyRepositoryItemLookUpEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 108, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CurrencyRepositoryItemLookUpEdit.DataSource = Me.CURRENCIESBindingSource
        Me.CurrencyRepositoryItemLookUpEdit.DisplayMember = "CURRENCY CODE"
        Me.CurrencyRepositoryItemLookUpEdit.Name = "CurrencyRepositoryItemLookUpEdit"
        Me.CurrencyRepositoryItemLookUpEdit.NullText = ""
        Me.CurrencyRepositoryItemLookUpEdit.ValueMember = "CURRENCY CODE"
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
        'colChequeAmount
        '
        Me.colChequeAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colChequeAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colChequeAmount.Caption = "Amount"
        Me.colChequeAmount.ColumnEdit = Me.AmountRepositoryItemTextEdit
        Me.colChequeAmount.DisplayFormat.FormatString = "n2"
        Me.colChequeAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colChequeAmount.FieldName = "ChequeAmount"
        Me.colChequeAmount.Name = "colChequeAmount"
        Me.colChequeAmount.Visible = True
        Me.colChequeAmount.VisibleIndex = 3
        Me.colChequeAmount.Width = 122
        '
        'AmountRepositoryItemTextEdit
        '
        Me.AmountRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit.AutoHeight = False
        Me.AmountRepositoryItemTextEdit.DisplayFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit.EditFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit.Name = "AmountRepositoryItemTextEdit"
        Me.AmountRepositoryItemTextEdit.NullValuePromptShowForEmptyValue = True
        '
        'colExchange_Rate
        '
        Me.colExchange_Rate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchange_Rate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchange_Rate.Caption = "Exchange Rate"
        Me.colExchange_Rate.DisplayFormat.FormatString = "n5"
        Me.colExchange_Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchange_Rate.FieldName = "Exchange_Rate"
        Me.colExchange_Rate.Name = "colExchange_Rate"
        Me.colExchange_Rate.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate.Visible = True
        Me.colExchange_Rate.VisibleIndex = 4
        Me.colExchange_Rate.Width = 107
        '
        'colChequeAmountEURO
        '
        Me.colChequeAmountEURO.AppearanceCell.Options.UseTextOptions = True
        Me.colChequeAmountEURO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colChequeAmountEURO.Caption = "Amount in EUR"
        Me.colChequeAmountEURO.ColumnEdit = Me.AmountRepositoryItemTextEdit
        Me.colChequeAmountEURO.DisplayFormat.FormatString = "n2"
        Me.colChequeAmountEURO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colChequeAmountEURO.FieldName = "ChequeAmountEURO"
        Me.colChequeAmountEURO.Name = "colChequeAmountEURO"
        Me.colChequeAmountEURO.OptionsColumn.ReadOnly = True
        Me.colChequeAmountEURO.Visible = True
        Me.colChequeAmountEURO.VisibleIndex = 5
        Me.colChequeAmountEURO.Width = 135
        '
        'colChequeNo
        '
        Me.colChequeNo.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colChequeNo.FieldName = "ChequeNo"
        Me.colChequeNo.Name = "colChequeNo"
        Me.colChequeNo.OptionsEditForm.StartNewRow = True
        Me.colChequeNo.Visible = True
        Me.colChequeNo.VisibleIndex = 6
        Me.colChequeNo.Width = 164
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'colDrawerBank
        '
        Me.colDrawerBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colDrawerBank.FieldName = "DrawerBank"
        Me.colDrawerBank.Name = "colDrawerBank"
        Me.colDrawerBank.OptionsEditForm.StartNewRow = True
        Me.colDrawerBank.Visible = True
        Me.colDrawerBank.VisibleIndex = 7
        Me.colDrawerBank.Width = 260
        '
        'colCountryDrawerBank
        '
        Me.colCountryDrawerBank.AppearanceCell.Options.UseTextOptions = True
        Me.colCountryDrawerBank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCountryDrawerBank.ColumnEdit = Me.CountryRepositoryItemLookUpEdit
        Me.colCountryDrawerBank.FieldName = "CountryDrawerBank"
        Me.colCountryDrawerBank.Name = "colCountryDrawerBank"
        Me.colCountryDrawerBank.Visible = True
        Me.colCountryDrawerBank.VisibleIndex = 8
        Me.colCountryDrawerBank.Width = 127
        '
        'CountryRepositoryItemLookUpEdit
        '
        Me.CountryRepositoryItemLookUpEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CountryRepositoryItemLookUpEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CountryRepositoryItemLookUpEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CountryRepositoryItemLookUpEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CountryRepositoryItemLookUpEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CountryRepositoryItemLookUpEdit.AutoHeight = False
        Me.CountryRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CountryRepositoryItemLookUpEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CountryRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COUNTRY CODE", "COUNTRY CODE", 102, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COUNTRY NAME", "COUNTRY NAME", 89, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CountryRepositoryItemLookUpEdit.DataSource = Me.COUNTRIESBindingSource
        Me.CountryRepositoryItemLookUpEdit.DisplayMember = "COUNTRY CODE"
        Me.CountryRepositoryItemLookUpEdit.Name = "CountryRepositoryItemLookUpEdit"
        Me.CountryRepositoryItemLookUpEdit.NullText = ""
        Me.CountryRepositoryItemLookUpEdit.ValueMember = "COUNTRY CODE"
        '
        'COUNTRIESBindingSource
        '
        Me.COUNTRIESBindingSource.DataMember = "COUNTRIES"
        Me.COUNTRIESBindingSource.DataSource = Me.EXTERNALDataset
        '
        'colDraweeBank
        '
        Me.colDraweeBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colDraweeBank.FieldName = "DraweeBank"
        Me.colDraweeBank.Name = "colDraweeBank"
        Me.colDraweeBank.OptionsEditForm.StartNewRow = True
        Me.colDraweeBank.Visible = True
        Me.colDraweeBank.VisibleIndex = 9
        Me.colDraweeBank.Width = 270
        '
        'colCountryDraweeBank
        '
        Me.colCountryDraweeBank.AppearanceCell.Options.UseTextOptions = True
        Me.colCountryDraweeBank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCountryDraweeBank.ColumnEdit = Me.CountryRepositoryItemLookUpEdit
        Me.colCountryDraweeBank.FieldName = "CountryDraweeBank"
        Me.colCountryDraweeBank.Name = "colCountryDraweeBank"
        Me.colCountryDraweeBank.Visible = True
        Me.colCountryDraweeBank.VisibleIndex = 10
        Me.colCountryDraweeBank.Width = 120
        '
        'colChequeSettlement
        '
        Me.colChequeSettlement.AppearanceCell.Options.UseTextOptions = True
        Me.colChequeSettlement.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colChequeSettlement.ColumnEdit = Me.ChequeSettlementRepositoryItemComboBox
        Me.colChequeSettlement.FieldName = "ChequeSettlement"
        Me.colChequeSettlement.Name = "colChequeSettlement"
        Me.colChequeSettlement.OptionsEditForm.StartNewRow = True
        Me.colChequeSettlement.Visible = True
        Me.colChequeSettlement.VisibleIndex = 11
        Me.colChequeSettlement.Width = 118
        '
        'ChequeSettlementRepositoryItemComboBox
        '
        Me.ChequeSettlementRepositoryItemComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ChequeSettlementRepositoryItemComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ChequeSettlementRepositoryItemComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ChequeSettlementRepositoryItemComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ChequeSettlementRepositoryItemComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ChequeSettlementRepositoryItemComboBox.AutoHeight = False
        Me.ChequeSettlementRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChequeSettlementRepositoryItemComboBox.Items.AddRange(New Object() {"COLLECTION", "BSE", "ISE", "INHOUSE"})
        Me.ChequeSettlementRepositoryItemComboBox.Name = "ChequeSettlementRepositoryItemComboBox"
        Me.ChequeSettlementRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(551, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Date from"
        Me.LabelControl1.Visible = False
        '
        'LoadChequeData_btn
        '
        Me.LoadChequeData_btn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LoadChequeData_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadChequeData_btn.ImageOptions.ImageIndex = 6
        Me.LoadChequeData_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadChequeData_btn.Location = New System.Drawing.Point(829, 43)
        Me.LoadChequeData_btn.Name = "LoadChequeData_btn"
        Me.LoadChequeData_btn.Size = New System.Drawing.Size(111, 22)
        Me.LoadChequeData_btn.TabIndex = 21
        Me.LoadChequeData_btn.Text = "Load Data"
        Me.LoadChequeData_btn.Visible = False
        '
        'ChequeFromDateEdit
        '
        Me.ChequeFromDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ChequeFromDateEdit.EditValue = Nothing
        Me.ChequeFromDateEdit.Location = New System.Drawing.Point(551, 43)
        Me.ChequeFromDateEdit.Name = "ChequeFromDateEdit"
        Me.ChequeFromDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChequeFromDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ChequeFromDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ChequeFromDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ChequeFromDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.ChequeFromDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ChequeFromDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChequeFromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ChequeFromDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.ChequeFromDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ChequeFromDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.ChequeFromDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ChequeFromDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.ChequeFromDateEdit.Size = New System.Drawing.Size(117, 22)
        Me.ChequeFromDateEdit.TabIndex = 20
        Me.ChequeFromDateEdit.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(693, 24)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 24
        Me.LabelControl2.Text = "Date till"
        Me.LabelControl2.Visible = False
        '
        'ChequeTillDateEdit
        '
        Me.ChequeTillDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ChequeTillDateEdit.EditValue = Nothing
        Me.ChequeTillDateEdit.Location = New System.Drawing.Point(693, 43)
        Me.ChequeTillDateEdit.Name = "ChequeTillDateEdit"
        Me.ChequeTillDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChequeTillDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ChequeTillDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ChequeTillDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ChequeTillDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.ChequeTillDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ChequeTillDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChequeTillDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ChequeTillDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.ChequeTillDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ChequeTillDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.ChequeTillDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ChequeTillDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.ChequeTillDateEdit.Size = New System.Drawing.Size(117, 22)
        Me.ChequeTillDateEdit.TabIndex = 23
        Me.ChequeTillDateEdit.Visible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.RecalculateCreditRiskDropDownButton)
        Me.LayoutControl1.Controls.Add(Me.PopupContainerEdit1)
        Me.LayoutControl1.Controls.Add(Me.InterestRateRiskReportsDropDownButton)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1522, 754)
        Me.LayoutControl1.TabIndex = 25
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'RecalculateCreditRiskDropDownButton
        '
        Me.RecalculateCreditRiskDropDownButton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.RecalculateCreditRiskDropDownButton.ImageOptions.ImageIndex = 8
        Me.RecalculateCreditRiskDropDownButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.RecalculateCreditRiskDropDownButton.Location = New System.Drawing.Point(458, 24)
        Me.RecalculateCreditRiskDropDownButton.Name = "RecalculateCreditRiskDropDownButton"
        Me.RecalculateCreditRiskDropDownButton.Size = New System.Drawing.Size(202, 22)
        Me.RecalculateCreditRiskDropDownButton.StyleController = Me.LayoutControl1
        Me.RecalculateCreditRiskDropDownButton.TabIndex = 9
        Me.RecalculateCreditRiskDropDownButton.Text = "Re-calculate Credit Risk"
        Me.RecalculateCreditRiskDropDownButton.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'PopupContainerEdit1
        '
        Me.PopupContainerEdit1.Location = New System.Drawing.Point(111, 62)
        Me.PopupContainerEdit1.Name = "PopupContainerEdit1"
        Me.PopupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit1.Size = New System.Drawing.Size(50, 20)
        Me.PopupContainerEdit1.StyleController = Me.LayoutControl1
        Me.PopupContainerEdit1.TabIndex = 8
        '
        'InterestRateRiskReportsDropDownButton
        '
        Me.InterestRateRiskReportsDropDownButton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.InterestRateRiskReportsDropDownButton.ImageOptions.ImageIndex = 7
        Me.InterestRateRiskReportsDropDownButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.InterestRateRiskReportsDropDownButton.Location = New System.Drawing.Point(197, 24)
        Me.InterestRateRiskReportsDropDownButton.Name = "InterestRateRiskReportsDropDownButton"
        Me.InterestRateRiskReportsDropDownButton.Size = New System.Drawing.Size(257, 22)
        Me.InterestRateRiskReportsDropDownButton.StyleController = Me.LayoutControl1
        Me.InterestRateRiskReportsDropDownButton.TabIndex = 7
        Me.InterestRateRiskReportsDropDownButton.Text = "CREDIT RISK + MAK REPORTS"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(169, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 6
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1304, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(194, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PopupContainerEdit1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(153, 649)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1522, 754)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1502, 684)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem7, Me.LayoutControlItem10})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1502, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1280, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(198, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(640, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(640, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.InterestRateRiskReportsDropDownButton
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(173, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.RecalculateCreditRiskDropDownButton
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(434, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(206, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'CURRENCIESTableAdapter
        '
        Me.CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'COUNTRIESTableAdapter
        '
        Me.COUNTRIESTableAdapter.ClearBeforeFill = True
        '
        'ChequeCollections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1522, 754)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ChequeTillDateEdit)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadChequeData_btn)
        Me.Controls.Add(Me.ChequeFromDateEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChequeCollections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cheque Collections"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClearingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHEQUE_COLLECTIONSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeCollections_Basic_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportExportRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COUNTRIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeSettlementRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeFromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeFromDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeTillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequeTillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClearingDataSet As PS_TOOL_DX.ClearingDataSet
    Friend WithEvents CHEQUE_COLLECTIONSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CHEQUE_COLLECTIONSTableAdapter As PS_TOOL_DX.ClearingDataSetTableAdapters.CHEQUE_COLLECTIONSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.ClearingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadChequeData_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ChequeFromDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ChequeTillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RecalculateCreditRiskDropDownButton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupContainerEdit1 As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents InterestRateRiskReportsDropDownButton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ChequeCollections_Basic_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIncomingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImport_Export_Cheque As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchange_Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeAmountEURO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDrawerBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountryDrawerBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDraweeBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountryDraweeBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeSettlement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImportExportRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ChequeSettlementRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CurrencyRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CURRENCIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter
    Friend WithEvents CountryRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents COUNTRIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COUNTRIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.COUNTRIESTableAdapter
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents AmountRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
