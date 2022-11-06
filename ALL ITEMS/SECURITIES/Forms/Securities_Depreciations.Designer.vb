<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Securities_Depreciations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Securities_Depreciations))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.colBooked_Depreciation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SECURITIESDataset = New PS_TOOL_DX.SECURITIESDataset()
        Me.SECURITIES_DEPRECIATIONSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SECURITIES_DEPRECIATIONSTableAdapter = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_DEPRECIATIONSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SecuritiesDepreciationsBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISIN_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ISINRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SampleTextRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CURRENCYRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.OWNCURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.colDepreciation_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEPRECIATION_TYPERepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colActual_Depreciation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colActual_Appreciation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDepreciation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAppreciation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOCBS_Booked_Before = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOCBS_Booked_Later = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.COUNTRIESRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.STATUSRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Securities_Deprec_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.OWN_CURRENCIESTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter()
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SECURITIES_DEPRECIATIONSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecuritiesDepreciationsBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ISINRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SampleTextRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCYRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OWNCURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPRECIATION_TYPERepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COUNTRIESRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STATUSRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colBooked_Depreciation
        '
        Me.colBooked_Depreciation.AppearanceCell.Options.UseTextOptions = True
        Me.colBooked_Depreciation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colBooked_Depreciation.Caption = "Booked Depreciation(-)/Appreciation(+)"
        Me.colBooked_Depreciation.DisplayFormat.FormatString = "n2"
        Me.colBooked_Depreciation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBooked_Depreciation.FieldName = "Booked_Depreciation"
        Me.colBooked_Depreciation.Name = "colBooked_Depreciation"
        Me.colBooked_Depreciation.Visible = True
        Me.colBooked_Depreciation.VisibleIndex = 5
        Me.colBooked_Depreciation.Width = 190
        '
        'SECURITIESDataset
        '
        Me.SECURITIESDataset.DataSetName = "SECURITIESDataset"
        Me.SECURITIESDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SECURITIES_DEPRECIATIONSBindingSource
        '
        Me.SECURITIES_DEPRECIATIONSBindingSource.DataMember = "SECURITIES_DEPRECIATIONS"
        Me.SECURITIES_DEPRECIATIONSBindingSource.DataSource = Me.SECURITIESDataset
        '
        'SECURITIES_DEPRECIATIONSTableAdapter
        '
        Me.SECURITIES_DEPRECIATIONSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.SECURITIES_BESTANDTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_BOOKINGSTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_DailyPriceTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_DEPRECIATIONSTableAdapter = Me.SECURITIES_DEPRECIATIONSTableAdapter
        Me.TableAdapterManager.SECURITIES_LIQUIDITYRESERVETableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_OURTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Securities_Deprec_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1538, 724)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton1.ImageOptions.ImageIndex = 2
        Me.SimpleButton1.Location = New System.Drawing.Point(1364, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(160, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 10
        Me.SimpleButton1.Text = "Print or Export"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.SECURITIES_DEPRECIATIONSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 6
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.SecuritiesDepreciationsBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ISINRepositoryItemTextEdit, Me.CURRENCYRepositoryItemLookUpEdit1, Me.DEPRECIATION_TYPERepositoryItemComboBox, Me.COUNTRIESRepositoryItemLookUpEdit, Me.STATUSRepositoryItemImageComboBox, Me.SampleTextRepositoryItemTextEdit})
        Me.GridControl2.Size = New System.Drawing.Size(1514, 674)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SecuritiesDepreciationsBaseView})
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
        '
        'SecuritiesDepreciationsBaseView
        '
        Me.SecuritiesDepreciationsBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SecuritiesDepreciationsBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SecuritiesDepreciationsBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SecuritiesDepreciationsBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SecuritiesDepreciationsBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SecuritiesDepreciationsBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SecuritiesDepreciationsBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SecuritiesDepreciationsBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colDate, Me.colISIN_Code, Me.colName, Me.colCcy, Me.colDepreciation_Type, Me.colBooked_Depreciation, Me.colActual_Depreciation, Me.colActual_Appreciation, Me.colDepreciation, Me.colAppreciation, Me.colOCBS_Booked_Before, Me.colOCBS_Booked_Later})
        Me.SecuritiesDepreciationsBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Column = Me.colBooked_Depreciation
        GridFormatRule1.ColumnApplyTo = Me.colBooked_Depreciation
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue1.Value1 = 0R
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Column = Me.colBooked_Depreciation
        GridFormatRule2.ColumnApplyTo = Me.colBooked_Depreciation
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = 0R
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.SecuritiesDepreciationsBaseView.FormatRules.Add(GridFormatRule1)
        Me.SecuritiesDepreciationsBaseView.FormatRules.Add(GridFormatRule2)
        Me.SecuritiesDepreciationsBaseView.GridControl = Me.GridControl2
        Me.SecuritiesDepreciationsBaseView.GroupCount = 2
        Me.SecuritiesDepreciationsBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Actual_Depreciation", Me.colActual_Depreciation, "SUM={0:n2}")})
        Me.SecuritiesDepreciationsBaseView.Name = "SecuritiesDepreciationsBaseView"
        Me.SecuritiesDepreciationsBaseView.NewItemRowText = "Add new Security Depreciation"
        Me.SecuritiesDepreciationsBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SecuritiesDepreciationsBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.SecuritiesDepreciationsBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.SecuritiesDepreciationsBaseView.OptionsBehavior.Editable = False
        Me.SecuritiesDepreciationsBaseView.OptionsCustomization.AllowRowSizing = True
        Me.SecuritiesDepreciationsBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SecuritiesDepreciationsBaseView.OptionsFind.AlwaysVisible = True
        Me.SecuritiesDepreciationsBaseView.OptionsMenu.ShowFooterItem = True
        Me.SecuritiesDepreciationsBaseView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.SecuritiesDepreciationsBaseView.OptionsSelection.MultiSelect = True
        Me.SecuritiesDepreciationsBaseView.OptionsView.ColumnAutoWidth = False
        Me.SecuritiesDepreciationsBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SecuritiesDepreciationsBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.SecuritiesDepreciationsBaseView.OptionsView.ShowAutoFilterRow = True
        Me.SecuritiesDepreciationsBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SecuritiesDepreciationsBaseView.OptionsView.ShowFooter = True
        Me.SecuritiesDepreciationsBaseView.OptionsView.ShowGroupedColumns = True
        Me.SecuritiesDepreciationsBaseView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDate, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDepreciation_Type, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colDate
        '
        Me.colDate.AppearanceCell.Options.UseTextOptions = True
        Me.colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDate.FieldName = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.Visible = True
        Me.colDate.VisibleIndex = 0
        Me.colDate.Width = 128
        '
        'colISIN_Code
        '
        Me.colISIN_Code.Caption = "ISIN Code"
        Me.colISIN_Code.ColumnEdit = Me.ISINRepositoryItemTextEdit
        Me.colISIN_Code.FieldName = "ISIN_Code"
        Me.colISIN_Code.Name = "colISIN_Code"
        Me.colISIN_Code.Visible = True
        Me.colISIN_Code.VisibleIndex = 1
        Me.colISIN_Code.Width = 145
        '
        'ISINRepositoryItemTextEdit
        '
        Me.ISINRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ISINRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ISINRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ISINRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ISINRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ISINRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.ISINRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.ISINRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.ISINRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ISINRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ISINRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ISINRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ISINRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ISINRepositoryItemTextEdit.AutoHeight = False
        Me.ISINRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ISINRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ISINRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.ISINRepositoryItemTextEdit.Mask.EditMask = "[A-Z]{2}[0-9]{10}"
        Me.ISINRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.ISINRepositoryItemTextEdit.Name = "ISINRepositoryItemTextEdit"
        '
        'colName
        '
        Me.colName.ColumnEdit = Me.SampleTextRepositoryItemTextEdit
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 2
        Me.colName.Width = 276
        '
        'SampleTextRepositoryItemTextEdit
        '
        Me.SampleTextRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.SampleTextRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.SampleTextRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SampleTextRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.SampleTextRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.SampleTextRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SampleTextRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SampleTextRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SampleTextRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.SampleTextRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.SampleTextRepositoryItemTextEdit.AutoHeight = False
        Me.SampleTextRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SampleTextRepositoryItemTextEdit.Name = "SampleTextRepositoryItemTextEdit"
        '
        'colCcy
        '
        Me.colCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCcy.Caption = "Currency"
        Me.colCcy.ColumnEdit = Me.CURRENCYRepositoryItemLookUpEdit1
        Me.colCcy.FieldName = "Ccy"
        Me.colCcy.Name = "colCcy"
        Me.colCcy.OptionsColumn.AllowEdit = False
        Me.colCcy.OptionsColumn.ReadOnly = True
        Me.colCcy.Visible = True
        Me.colCcy.VisibleIndex = 3
        '
        'CURRENCYRepositoryItemLookUpEdit1
        '
        Me.CURRENCYRepositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CURRENCYRepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CURRENCYRepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CURRENCYRepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CURRENCYRepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.CURRENCYRepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.CURRENCYRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CURRENCYRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CURRENCYRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CURRENCYRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.CURRENCYRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.CURRENCYRepositoryItemLookUpEdit1.AutoHeight = False
        Me.CURRENCYRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CURRENCYRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CURRENCYRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CURRENCYRepositoryItemLookUpEdit1.DataSource = Me.OWNCURRENCIESBindingSource
        Me.CURRENCYRepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.CURRENCYRepositoryItemLookUpEdit1.Name = "CURRENCYRepositoryItemLookUpEdit1"
        Me.CURRENCYRepositoryItemLookUpEdit1.NullText = ""
        Me.CURRENCYRepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'OWNCURRENCIESBindingSource
        '
        Me.OWNCURRENCIESBindingSource.DataMember = "OWN_CURRENCIES"
        Me.OWNCURRENCIESBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colDepreciation_Type
        '
        Me.colDepreciation_Type.AppearanceCell.Options.UseTextOptions = True
        Me.colDepreciation_Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDepreciation_Type.Caption = "Assets Type"
        Me.colDepreciation_Type.ColumnEdit = Me.DEPRECIATION_TYPERepositoryItemComboBox
        Me.colDepreciation_Type.CustomizationCaption = "Assets Type"
        Me.colDepreciation_Type.FieldName = "Depreciation_Type"
        Me.colDepreciation_Type.Name = "colDepreciation_Type"
        Me.colDepreciation_Type.OptionsColumn.AllowEdit = False
        Me.colDepreciation_Type.OptionsColumn.ReadOnly = True
        Me.colDepreciation_Type.Visible = True
        Me.colDepreciation_Type.VisibleIndex = 4
        Me.colDepreciation_Type.Width = 122
        '
        'DEPRECIATION_TYPERepositoryItemComboBox
        '
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Appearance.Options.UseBackColor = True
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Appearance.Options.UseForeColor = True
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.DEPRECIATION_TYPERepositoryItemComboBox.AutoHeight = False
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPRECIATION_TYPERepositoryItemComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Items.AddRange(New Object() {"CURRENT", "FIXED"})
        Me.DEPRECIATION_TYPERepositoryItemComboBox.Name = "DEPRECIATION_TYPERepositoryItemComboBox"
        Me.DEPRECIATION_TYPERepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colActual_Depreciation
        '
        Me.colActual_Depreciation.AppearanceCell.Options.UseTextOptions = True
        Me.colActual_Depreciation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colActual_Depreciation.Caption = "Actual Depreciation"
        Me.colActual_Depreciation.DisplayFormat.FormatString = "n2"
        Me.colActual_Depreciation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colActual_Depreciation.FieldName = "Actual_Depreciation"
        Me.colActual_Depreciation.Name = "colActual_Depreciation"
        Me.colActual_Depreciation.Visible = True
        Me.colActual_Depreciation.VisibleIndex = 6
        Me.colActual_Depreciation.Width = 131
        '
        'colActual_Appreciation
        '
        Me.colActual_Appreciation.Caption = "Actual Appreciation"
        Me.colActual_Appreciation.DisplayFormat.FormatString = "n2"
        Me.colActual_Appreciation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colActual_Appreciation.FieldName = "Actual_Appreciation"
        Me.colActual_Appreciation.Name = "colActual_Appreciation"
        Me.colActual_Appreciation.Visible = True
        Me.colActual_Appreciation.VisibleIndex = 7
        Me.colActual_Appreciation.Width = 135
        '
        'colDepreciation
        '
        Me.colDepreciation.DisplayFormat.FormatString = "n2"
        Me.colDepreciation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDepreciation.FieldName = "Depreciation"
        Me.colDepreciation.Name = "colDepreciation"
        Me.colDepreciation.Width = 103
        '
        'colAppreciation
        '
        Me.colAppreciation.DisplayFormat.FormatString = "n2"
        Me.colAppreciation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAppreciation.FieldName = "Appreciation"
        Me.colAppreciation.Name = "colAppreciation"
        Me.colAppreciation.Width = 103
        '
        'colOCBS_Booked_Before
        '
        Me.colOCBS_Booked_Before.AppearanceCell.Options.UseTextOptions = True
        Me.colOCBS_Booked_Before.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOCBS_Booked_Before.Caption = "OCBS Booked Before"
        Me.colOCBS_Booked_Before.DisplayFormat.FormatString = "n2"
        Me.colOCBS_Booked_Before.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOCBS_Booked_Before.FieldName = "OCBS_Booked_Before"
        Me.colOCBS_Booked_Before.Name = "colOCBS_Booked_Before"
        Me.colOCBS_Booked_Before.Width = 144
        '
        'colOCBS_Booked_Later
        '
        Me.colOCBS_Booked_Later.AppearanceCell.Options.UseTextOptions = True
        Me.colOCBS_Booked_Later.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOCBS_Booked_Later.Caption = "Security Booked Value"
        Me.colOCBS_Booked_Later.DisplayFormat.FormatString = "n2"
        Me.colOCBS_Booked_Later.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOCBS_Booked_Later.FieldName = "OCBS_Booked_Later"
        Me.colOCBS_Booked_Later.Name = "colOCBS_Booked_Later"
        Me.colOCBS_Booked_Later.Visible = True
        Me.colOCBS_Booked_Later.VisibleIndex = 8
        Me.colOCBS_Booked_Later.Width = 131
        '
        'COUNTRIESRepositoryItemLookUpEdit
        '
        Me.COUNTRIESRepositoryItemLookUpEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.COUNTRIESRepositoryItemLookUpEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.COUNTRIESRepositoryItemLookUpEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.COUNTRIESRepositoryItemLookUpEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.COUNTRIESRepositoryItemLookUpEdit.Appearance.Options.UseBackColor = True
        Me.COUNTRIESRepositoryItemLookUpEdit.Appearance.Options.UseForeColor = True
        Me.COUNTRIESRepositoryItemLookUpEdit.AutoHeight = False
        Me.COUNTRIESRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.COUNTRIESRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COUNTRY CODE", "COUNTRY CODE", 102, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COUNTRY NAME", "COUNTRY NAME", 89, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.COUNTRIESRepositoryItemLookUpEdit.DisplayMember = "COUNTRY CODE"
        Me.COUNTRIESRepositoryItemLookUpEdit.Name = "COUNTRIESRepositoryItemLookUpEdit"
        Me.COUNTRIESRepositoryItemLookUpEdit.NullText = ""
        Me.COUNTRIESRepositoryItemLookUpEdit.ValueMember = "COUNTRY CODE"
        '
        'STATUSRepositoryItemImageComboBox
        '
        Me.STATUSRepositoryItemImageComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.STATUSRepositoryItemImageComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.STATUSRepositoryItemImageComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.STATUSRepositoryItemImageComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.STATUSRepositoryItemImageComboBox.Appearance.Options.UseBackColor = True
        Me.STATUSRepositoryItemImageComboBox.Appearance.Options.UseForeColor = True
        Me.STATUSRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.STATUSRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.STATUSRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.STATUSRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.STATUSRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.STATUSRepositoryItemImageComboBox.AutoHeight = False
        Me.STATUSRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.STATUSRepositoryItemImageComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.STATUSRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXPIRED", "EXPIRED", 3)})
        Me.STATUSRepositoryItemImageComboBox.Name = "STATUSRepositoryItemImageComboBox"
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
        'Securities_Deprec_Print_Export_btn
        '
        Me.Securities_Deprec_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Securities_Deprec_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Securities_Deprec_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Securities_Deprec_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Securities_Deprec_Print_Export_btn.Name = "Securities_Deprec_Print_Export_btn"
        Me.Securities_Deprec_Print_Export_btn.Size = New System.Drawing.Size(162, 22)
        Me.Securities_Deprec_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Securities_Deprec_Print_Export_btn.TabIndex = 9
        Me.Securities_Deprec_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1538, 724)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(375, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(977, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Securities_Deprec_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(166, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(209, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1516, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1518, 678)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1352, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(164, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        'OWN_CURRENCIESTableAdapter
        '
        Me.OWN_CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'Securities_Depreciations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1538, 724)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Securities_Depreciations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Securities Depreciations + Appreciations"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SECURITIES_DEPRECIATIONSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecuritiesDepreciationsBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ISINRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SampleTextRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCYRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OWNCURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPRECIATION_TYPERepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COUNTRIESRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STATUSRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SECURITIESDataset As PS_TOOL_DX.SECURITIESDataset
    Friend WithEvents SECURITIES_DEPRECIATIONSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SECURITIES_DEPRECIATIONSTableAdapter As PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_DEPRECIATIONSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SecuritiesDepreciationsBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ISINRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SampleTextRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CURRENCYRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents DEPRECIATION_TYPERepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents COUNTRIESRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents STATUSRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Securities_Deprec_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISIN_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepreciation_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBooked_Depreciation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colActual_Depreciation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOCBS_Booked_Before As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOCBS_Booked_Later As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents OWNCURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OWN_CURRENCIESTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colActual_Appreciation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepreciation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAppreciation As DevExpress.XtraGrid.Columns.GridColumn
End Class
