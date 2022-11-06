<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class German_ZIP_Codes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(German_ZIP_Codes))
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.PLZ_BUNDESLANDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PLZ_BUNDESLANDTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.PLZ_BUNDESLANDTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PLZBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPLZ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZipCodeRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OtherRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colBUNDESLAND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PLZ_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.BUNDESLAND_RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLZ_BUNDESLANDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLZBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.BUNDESLAND_RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PLZ_BUNDESLANDBindingSource
        '
        Me.PLZ_BUNDESLANDBindingSource.DataMember = "PLZ_BUNDESLAND"
        Me.PLZ_BUNDESLANDBindingSource.DataSource = Me.EXTERNALDataset
        '
        'PLZ_BUNDESLANDTableAdapter
        '
        Me.PLZ_BUNDESLANDTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Nothing
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Nothing
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Me.PLZ_BUNDESLANDTableAdapter
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.PLZ_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1014, 676)
        Me.LayoutControl1.TabIndex = 7
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.PLZ_BUNDESLANDBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 6
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.PLZBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ZipCodeRepositoryItemTextEdit1, Me.OtherRepositoryItemTextEdit, Me.BUNDESLAND_RepositoryItemComboBox1})
        Me.GridControl2.Size = New System.Drawing.Size(990, 626)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PLZBaseView})
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
        'PLZBaseView
        '
        Me.PLZBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.PLZBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.PLZBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.PLZBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.PLZBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.PLZBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.PLZBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.PLZBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colPLZ, Me.colORT, Me.colBUNDESLAND})
        Me.PLZBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.PLZBaseView.GridControl = Me.GridControl2
        Me.PLZBaseView.Name = "PLZBaseView"
        Me.PLZBaseView.NewItemRowText = "Add new ZIP Code"
        Me.PLZBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.PLZBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.PLZBaseView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow
        Me.PLZBaseView.OptionsCustomization.AllowRowSizing = True
        Me.PLZBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.PLZBaseView.OptionsFind.AlwaysVisible = True
        Me.PLZBaseView.OptionsSelection.MultiSelect = True
        Me.PLZBaseView.OptionsView.ColumnAutoWidth = False
        Me.PLZBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.PLZBaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.PLZBaseView.OptionsView.ShowAutoFilterRow = True
        Me.PLZBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.PLZBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colPLZ
        '
        Me.colPLZ.AppearanceCell.Options.UseTextOptions = True
        Me.colPLZ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPLZ.Caption = "ZIP CODE"
        Me.colPLZ.ColumnEdit = Me.ZipCodeRepositoryItemTextEdit1
        Me.colPLZ.FieldName = "PLZ"
        Me.colPLZ.Name = "colPLZ"
        Me.colPLZ.Visible = True
        Me.colPLZ.VisibleIndex = 0
        Me.colPLZ.Width = 118
        '
        'ZipCodeRepositoryItemTextEdit1
        '
        Me.ZipCodeRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AutoHeight = False
        Me.ZipCodeRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ZipCodeRepositoryItemTextEdit1.Mask.EditMask = "[0-9]{5}"
        Me.ZipCodeRepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.ZipCodeRepositoryItemTextEdit1.Name = "ZipCodeRepositoryItemTextEdit1"
        '
        'colORT
        '
        Me.colORT.Caption = "CITY"
        Me.colORT.ColumnEdit = Me.OtherRepositoryItemTextEdit
        Me.colORT.FieldName = "ORT"
        Me.colORT.Name = "colORT"
        Me.colORT.Visible = True
        Me.colORT.VisibleIndex = 1
        Me.colORT.Width = 318
        '
        'OtherRepositoryItemTextEdit
        '
        Me.OtherRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.OtherRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OtherRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.OtherRepositoryItemTextEdit.AutoHeight = False
        Me.OtherRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OtherRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.OtherRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.OtherRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.OtherRepositoryItemTextEdit.Name = "OtherRepositoryItemTextEdit"
        '
        'colBUNDESLAND
        '
        Me.colBUNDESLAND.Caption = "FEDERAL STATE"
        Me.colBUNDESLAND.ColumnEdit = Me.BUNDESLAND_RepositoryItemComboBox1
        Me.colBUNDESLAND.FieldName = "BUNDESLAND"
        Me.colBUNDESLAND.Name = "colBUNDESLAND"
        Me.colBUNDESLAND.OptionsEditForm.StartNewRow = True
        Me.colBUNDESLAND.Visible = True
        Me.colBUNDESLAND.VisibleIndex = 2
        Me.colBUNDESLAND.Width = 225
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
        Me.RepositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
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
        'PLZ_Print_Export_btn
        '
        Me.PLZ_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PLZ_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.PLZ_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.PLZ_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.PLZ_Print_Export_btn.Name = "PLZ_Print_Export_btn"
        Me.PLZ_Print_Export_btn.Size = New System.Drawing.Size(108, 22)
        Me.PLZ_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.PLZ_Print_Export_btn.TabIndex = 9
        Me.PLZ_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1014, 676)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(248, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(653, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PLZ_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(112, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(136, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(901, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(93, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(994, 630)
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
        'BUNDESLAND_RepositoryItemComboBox1
        '
        Me.BUNDESLAND_RepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BUNDESLAND_RepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BUNDESLAND_RepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BUNDESLAND_RepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.BUNDESLAND_RepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.BUNDESLAND_RepositoryItemComboBox1.AutoHeight = False
        Me.BUNDESLAND_RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BUNDESLAND_RepositoryItemComboBox1.Items.AddRange(New Object() {"BADEN-WÜRTTEMBERG", "BAYERN", "BERLIN", "BRANDENBURG", "BREMEN", "HAMBURG", "HESSEN", "MECKLENBURG-VORPOMMERN", "NIEDERSACHSEN", "NORDRHEIN-WESTFALEN", "RHEINLAND-PFALZ", "SAARLAND", "SACHSEN", "SACHSEN-ANHALT", "SCHLESWIG-HOLSTEIN", "THÜRINGEN"})
        Me.BUNDESLAND_RepositoryItemComboBox1.Name = "BUNDESLAND_RepositoryItemComboBox1"
        Me.BUNDESLAND_RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'German_ZIP_Codes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 676)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "German_ZIP_Codes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "German ZIP Codes"
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLZ_BUNDESLANDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLZBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.BUNDESLAND_RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents PLZ_BUNDESLANDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PLZ_BUNDESLANDTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.PLZ_BUNDESLANDTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents PLZBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents OtherRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZipCodeRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PLZ_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents colPLZ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBUNDESLAND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents BUNDESLAND_RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
