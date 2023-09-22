<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Currencies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Currencies))
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CURRENCIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CurrenciesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrencyCodeRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrencyNameRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colLZB_CurrencyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LZB_CurrencyCode_RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colNEWG_CurrencyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VALDIRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Currencies_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrenciesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyCodeRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyNameRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LZB_CurrencyCode_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VALDIRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CURRENCIESBindingSource
        '
        Me.CURRENCIESBindingSource.DataMember = "CURRENCIES"
        Me.CURRENCIESBindingSource.DataSource = Me.EXTERNALDataset
        '
        'CURRENCIESTableAdapter
        '
        Me.CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CURRENCIESTableAdapter = Me.CURRENCIESTableAdapter
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Nothing
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Nothing
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Currencies_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1082, 677)
        Me.LayoutControl1.TabIndex = 8
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.CURRENCIESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 6
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 10
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 9
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.CurrenciesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CurrencyCodeRepositoryItemTextEdit, Me.CurrencyNameRepositoryItemTextEdit, Me.VALDIRepositoryItemImageComboBox, Me.LZB_CurrencyCode_RepositoryItemTextEdit})
        Me.GridControl2.Size = New System.Drawing.Size(1058, 627)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CurrenciesBaseView})
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
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "save_16x16.png")
        '
        'CurrenciesBaseView
        '
        Me.CurrenciesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CurrenciesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrenciesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CurrenciesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CurrenciesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CurrenciesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colLZB_CurrencyCode, Me.colNEWG_CurrencyCode, Me.colVALID})
        Me.CurrenciesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CurrenciesBaseView.GridControl = Me.GridControl2
        Me.CurrenciesBaseView.Name = "CurrenciesBaseView"
        Me.CurrenciesBaseView.NewItemRowText = "Add new Currency"
        Me.CurrenciesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CurrenciesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CurrenciesBaseView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow
        Me.CurrenciesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.CurrenciesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CurrenciesBaseView.OptionsFind.AlwaysVisible = True
        Me.CurrenciesBaseView.OptionsSelection.MultiSelect = True
        Me.CurrenciesBaseView.OptionsView.ColumnAutoWidth = False
        Me.CurrenciesBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CurrenciesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CurrenciesBaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.CurrenciesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.CurrenciesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CurrenciesBaseView.OptionsView.ShowFooter = True
        '
        'colCURRENCYCODE
        '
        Me.colCURRENCYCODE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYCODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCURRENCYCODE.ColumnEdit = Me.CurrencyCodeRepositoryItemTextEdit
        Me.colCURRENCYCODE.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYCODE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYCODE.Visible = True
        Me.colCURRENCYCODE.VisibleIndex = 0
        Me.colCURRENCYCODE.Width = 99
        '
        'CurrencyCodeRepositoryItemTextEdit
        '
        Me.CurrencyCodeRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.CurrencyCodeRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.CurrencyCodeRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyCodeRepositoryItemTextEdit.AutoHeight = False
        Me.CurrencyCodeRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyCodeRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CurrencyCodeRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None
        Me.CurrencyCodeRepositoryItemTextEdit.Mask.EditMask = "[A-Z]{3}"
        Me.CurrencyCodeRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.CurrencyCodeRepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.CurrencyCodeRepositoryItemTextEdit.Name = "CurrencyCodeRepositoryItemTextEdit"
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.ColumnEdit = Me.CurrencyNameRepositoryItemTextEdit
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsEditForm.StartNewRow = True
        Me.colCURRENCYNAME.Visible = True
        Me.colCURRENCYNAME.VisibleIndex = 1
        Me.colCURRENCYNAME.Width = 524
        '
        'CurrencyNameRepositoryItemTextEdit
        '
        Me.CurrencyNameRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.CurrencyNameRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.CurrencyNameRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyNameRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyNameRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyNameRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyNameRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyNameRepositoryItemTextEdit.AutoHeight = False
        Me.CurrencyNameRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyNameRepositoryItemTextEdit.Name = "CurrencyNameRepositoryItemTextEdit"
        '
        'colLZB_CurrencyCode
        '
        Me.colLZB_CurrencyCode.AppearanceCell.Options.UseTextOptions = True
        Me.colLZB_CurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLZB_CurrencyCode.Caption = "LZB Currency Code"
        Me.colLZB_CurrencyCode.ColumnEdit = Me.LZB_CurrencyCode_RepositoryItemTextEdit
        Me.colLZB_CurrencyCode.FieldName = "LZB_CurrencyCode"
        Me.colLZB_CurrencyCode.Name = "colLZB_CurrencyCode"
        Me.colLZB_CurrencyCode.OptionsEditForm.StartNewRow = True
        Me.colLZB_CurrencyCode.Visible = True
        Me.colLZB_CurrencyCode.VisibleIndex = 2
        Me.colLZB_CurrencyCode.Width = 101
        '
        'LZB_CurrencyCode_RepositoryItemTextEdit
        '
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.AutoHeight = False
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.Mask.EditMask = "[0-9]{1,3}"
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.MaxLength = 3
        Me.LZB_CurrencyCode_RepositoryItemTextEdit.Name = "LZB_CurrencyCode_RepositoryItemTextEdit"
        '
        'colNEWG_CurrencyCode
        '
        Me.colNEWG_CurrencyCode.AppearanceCell.Options.UseTextOptions = True
        Me.colNEWG_CurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNEWG_CurrencyCode.Caption = "NEWG Currency Code"
        Me.colNEWG_CurrencyCode.ColumnEdit = Me.LZB_CurrencyCode_RepositoryItemTextEdit
        Me.colNEWG_CurrencyCode.FieldName = "NEWG_CurrencyCode"
        Me.colNEWG_CurrencyCode.Name = "colNEWG_CurrencyCode"
        Me.colNEWG_CurrencyCode.Visible = True
        Me.colNEWG_CurrencyCode.VisibleIndex = 3
        Me.colNEWG_CurrencyCode.Width = 83
        '
        'colVALID
        '
        Me.colVALID.AppearanceCell.Options.UseTextOptions = True
        Me.colVALID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colVALID.ColumnEdit = Me.VALDIRepositoryItemImageComboBox
        Me.colVALID.FieldName = "VALID"
        Me.colVALID.Name = "colVALID"
        Me.colVALID.OptionsEditForm.StartNewRow = True
        Me.colVALID.Visible = True
        Me.colVALID.VisibleIndex = 4
        '
        'VALDIRepositoryItemImageComboBox
        '
        Me.VALDIRepositoryItemImageComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.VALDIRepositoryItemImageComboBox.AutoHeight = False
        Me.VALDIRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VALDIRepositoryItemImageComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.VALDIRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 8)})
        Me.VALDIRepositoryItemImageComboBox.Name = "VALDIRepositoryItemImageComboBox"
        Me.VALDIRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
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
        'Currencies_Print_Export_btn
        '
        Me.Currencies_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Currencies_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Currencies_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Currencies_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Currencies_Print_Export_btn.Name = "Currencies_Print_Export_btn"
        Me.Currencies_Print_Export_btn.Size = New System.Drawing.Size(115, 22)
        Me.Currencies_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Currencies_Print_Export_btn.TabIndex = 9
        Me.Currencies_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1082, 677)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(265, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(697, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Currencies_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(119, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(119, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(146, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(962, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(100, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1062, 631)
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
        'Currencies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 677)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Currencies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Currencies"
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrenciesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyCodeRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyNameRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LZB_CurrencyCode_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VALDIRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CURRENCIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CurrenciesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CurrencyCodeRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Currencies_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrencyNameRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents VALDIRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colLZB_CurrencyCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LZB_CurrencyCode_RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colNEWG_CurrencyCode As DevExpress.XtraGrid.Columns.GridColumn
End Class
