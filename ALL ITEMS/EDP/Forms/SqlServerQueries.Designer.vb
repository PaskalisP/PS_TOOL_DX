<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlServerQueries
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SqlServerQueries))
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Gridview1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colDataTypeALL = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colCOLUMN_DEFAULT = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colIS_NULLABLE = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ALL_TABLE_COLUMNSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EDPDataSet = New PS_TOOL_DX.EDPDataSet()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.NewSqlQueryForm_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SqlLoad_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SqlSave_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SqlClear_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SqlExecute_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.SplitterControl2 = New DevExpress.XtraEditors.SplitterControl()
        Me.ALL_TABLE_COLUMNSTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.ALL_TABLE_COLUMNSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.BgwSqlExecute = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALL_TABLE_COLUMNSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutView1
        '
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutView1.OptionsBehavior.Editable = False
        Me.LayoutView1.OptionsFind.AlwaysVisible = True
        Me.LayoutView1.TemplateCard = Nothing
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(2, "Print or Export results"), New DevExpress.XtraEditors.NavigatorCustomButton(14, "Show/Hide Tables")})
        GridLevelNode1.LevelTemplate = Me.LayoutView1
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(379, 296)
        Me.GridControl1.MainView = Me.Gridview1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1124, 426)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gridview1, Me.LayoutView1})
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
        Me.ImageCollection1.Images.SetKeyName(8, "Datacolumn.ico")
        Me.ImageCollection1.Images.SetKeyName(9, "Datatable.ico")
        Me.ImageCollection1.Images.SetKeyName(10, "SQL.png")
        Me.ImageCollection1.Images.SetKeyName(11, "Recycle.ico")
        Me.ImageCollection1.Images.SetKeyName(12, "save.ico")
        Me.ImageCollection1.Images.SetKeyName(13, "Folder Open.ico")
        Me.ImageCollection1.InsertGalleryImage("cards_16x16.png", "images/grid/cards_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/cards_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "cards_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("addfile_16x16.png", "images/actions/addfile_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/addfile_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "addfile_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("formatnumbergeneral_16x16.png", "images/spreadsheet/formatnumbergeneral_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/formatnumbergeneral_16x16.png"), 16)
        Me.ImageCollection1.Images.SetKeyName(16, "formatnumbergeneral_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("linenumbering_16x16.png", "images/richedit/linenumbering_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/richedit/linenumbering_16x16.png"), 17)
        Me.ImageCollection1.Images.SetKeyName(17, "linenumbering_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("increasedecimal_16x16.png", "images/number%20formats/increasedecimal_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/number%20formats/increasedecimal_16x16.png"), 18)
        Me.ImageCollection1.Images.SetKeyName(18, "increasedecimal_16x16.png")
        '
        'Gridview1
        '
        Me.Gridview1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Gridview1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Gridview1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Gridview1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Gridview1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Gridview1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Gridview1.Appearance.GroupRow.Options.UseForeColor = True
        Me.Gridview1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Gridview1.GridControl = Me.GridControl1
        Me.Gridview1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessType", Nothing, "{0:n2}")})
        Me.Gridview1.Name = "Gridview1"
        Me.Gridview1.NewItemRowText = "Add new Manual Import Procedure"
        Me.Gridview1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Gridview1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Gridview1.OptionsBehavior.AllowIncrementalSearch = True
        Me.Gridview1.OptionsBehavior.AutoExpandAllGroups = True
        Me.Gridview1.OptionsBehavior.ReadOnly = True
        Me.Gridview1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.Gridview1.OptionsCustomization.AllowRowSizing = True
        Me.Gridview1.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Gridview1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Gridview1.OptionsFind.AlwaysVisible = True
        Me.Gridview1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.Gridview1.OptionsMenu.ShowFooterItem = True
        Me.Gridview1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Gridview1.OptionsPrint.PrintDetails = True
        Me.Gridview1.OptionsSelection.MultiSelect = True
        Me.Gridview1.OptionsView.ColumnAutoWidth = False
        Me.Gridview1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Gridview1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.Gridview1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Gridview1.OptionsView.ShowAutoFilterRow = True
        Me.Gridview1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Gridview1.OptionsView.ShowFooter = True
        '
        'TreeList1
        '
        Me.TreeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TreeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TreeList1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.TreeList1.Appearance.FocusedCell.Options.UseFont = True
        Me.TreeList1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.TreeList1.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TreeList1.Appearance.FocusedRow.Options.UseFont = True
        Me.TreeList1.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TreeList1.Appearance.SelectedRow.Options.UseFont = True
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1, Me.TreeListColumn2, Me.colDataTypeALL, Me.colCOLUMN_DEFAULT, Me.colIS_NULLABLE})
        Me.TreeList1.ColumnsImageList = Me.ImageCollection1
        Me.TreeList1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeList1.CustomizationFormBounds = New System.Drawing.Rectangle(1468, 660, 250, 200)
        Me.TreeList1.DataSource = Me.ALL_TABLE_COLUMNSBindingSource
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsBehavior.PopulateServiceColumns = True
        Me.TreeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart
        Me.TreeList1.OptionsFilter.ShowAllValuesInFilterPopup = True
        Me.TreeList1.OptionsFind.AlwaysVisible = True
        Me.TreeList1.OptionsView.AutoWidth = False
        Me.TreeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeList1.OptionsView.ShowAutoFilterRow = True
        Me.TreeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways
        Me.TreeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid
        Me.TreeList1.ParentFieldName = "ID"
        Me.TreeList1.PreviewFieldName = "ID"
        Me.TreeList1.Size = New System.Drawing.Size(374, 722)
        Me.TreeList1.TabIndex = 0
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "TABLE NAMES"
        Me.TreeListColumn1.FieldName = "TABLE_NAME"
        Me.TreeListColumn1.ImageOptions.ImageIndex = 9
        Me.TreeListColumn1.MinWidth = 34
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.TreeListColumn1.OptionsFilter.ImmediateUpdatePopupDateFilter = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        Me.TreeListColumn1.Width = 156
        '
        'TreeListColumn2
        '
        Me.TreeListColumn2.Caption = "COLUMN NAMES"
        Me.TreeListColumn2.FieldName = "COLUMN_NAME"
        Me.TreeListColumn2.ImageOptions.ImageIndex = 8
        Me.TreeListColumn2.Name = "TreeListColumn2"
        Me.TreeListColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.TreeListColumn2.Visible = True
        Me.TreeListColumn2.VisibleIndex = 1
        Me.TreeListColumn2.Width = 197
        '
        'colDataTypeALL
        '
        Me.colDataTypeALL.Caption = "COLUMN DATA TYPE"
        Me.colDataTypeALL.FieldName = "DataTypeALL"
        Me.colDataTypeALL.ImageOptions.ImageIndex = 16
        Me.colDataTypeALL.Name = "colDataTypeALL"
        Me.colDataTypeALL.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.colDataTypeALL.Width = 127
        '
        'colCOLUMN_DEFAULT
        '
        Me.colCOLUMN_DEFAULT.Caption = "COLUMN DEFAULT VALUE"
        Me.colCOLUMN_DEFAULT.FieldName = "COLUMN_DEFAULT"
        Me.colCOLUMN_DEFAULT.ImageOptions.ImageIndex = 17
        Me.colCOLUMN_DEFAULT.Name = "colCOLUMN_DEFAULT"
        Me.colCOLUMN_DEFAULT.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        '
        'colIS_NULLABLE
        '
        Me.colIS_NULLABLE.Caption = "IS NULLABLE"
        Me.colIS_NULLABLE.FieldName = "IS_NULLABLE"
        Me.colIS_NULLABLE.ImageOptions.ImageIndex = 18
        Me.colIS_NULLABLE.Name = "colIS_NULLABLE"
        Me.colIS_NULLABLE.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Equals
        '
        'ALL_TABLE_COLUMNSBindingSource
        '
        Me.ALL_TABLE_COLUMNSBindingSource.DataMember = "ALL_TABLE_COLUMNS"
        Me.ALL_TABLE_COLUMNSBindingSource.DataSource = Me.EDPDataSet
        '
        'EDPDataSet
        '
        Me.EDPDataSet.DataSetName = "EDPDataSet"
        Me.EDPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.NewSqlQueryForm_btn)
        Me.LayoutControl1.Controls.Add(Me.SqlLoad_btn)
        Me.LayoutControl1.Controls.Add(Me.SqlSave_btn)
        Me.LayoutControl1.Controls.Add(Me.SqlClear_btn)
        Me.LayoutControl1.Controls.Add(Me.SqlExecute_btn)
        Me.LayoutControl1.Controls.Add(Me.MemoEdit1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(374, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1129, 291)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'NewSqlQueryForm_btn
        '
        Me.NewSqlQueryForm_btn.ImageOptions.ImageIndex = 15
        Me.NewSqlQueryForm_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.NewSqlQueryForm_btn.Location = New System.Drawing.Point(973, 24)
        Me.NewSqlQueryForm_btn.Name = "NewSqlQueryForm_btn"
        Me.NewSqlQueryForm_btn.Size = New System.Drawing.Size(132, 22)
        Me.NewSqlQueryForm_btn.StyleController = Me.LayoutControl1
        Me.NewSqlQueryForm_btn.TabIndex = 9
        Me.NewSqlQueryForm_btn.Text = "New SQL Query Form"
        '
        'SqlLoad_btn
        '
        Me.SqlLoad_btn.ImageOptions.ImageIndex = 13
        Me.SqlLoad_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SqlLoad_btn.Location = New System.Drawing.Point(662, 24)
        Me.SqlLoad_btn.Name = "SqlLoad_btn"
        Me.SqlLoad_btn.Size = New System.Drawing.Size(171, 22)
        Me.SqlLoad_btn.StyleController = Me.LayoutControl1
        Me.SqlLoad_btn.TabIndex = 8
        Me.SqlLoad_btn.Text = "Load SQL Command"
        '
        'SqlSave_btn
        '
        Me.SqlSave_btn.ImageOptions.ImageIndex = 12
        Me.SqlSave_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SqlSave_btn.Location = New System.Drawing.Point(431, 24)
        Me.SqlSave_btn.Name = "SqlSave_btn"
        Me.SqlSave_btn.Size = New System.Drawing.Size(227, 22)
        Me.SqlSave_btn.StyleController = Me.LayoutControl1
        Me.SqlSave_btn.TabIndex = 7
        Me.SqlSave_btn.Text = "Save Current SQL Command"
        '
        'SqlClear_btn
        '
        Me.SqlClear_btn.ImageOptions.ImageIndex = 11
        Me.SqlClear_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SqlClear_btn.Location = New System.Drawing.Point(209, 24)
        Me.SqlClear_btn.Name = "SqlClear_btn"
        Me.SqlClear_btn.Size = New System.Drawing.Size(218, 22)
        Me.SqlClear_btn.StyleController = Me.LayoutControl1
        Me.SqlClear_btn.TabIndex = 6
        Me.SqlClear_btn.Text = "Clear Current SQL Command"
        '
        'SqlExecute_btn
        '
        Me.SqlExecute_btn.ImageOptions.ImageIndex = 10
        Me.SqlExecute_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SqlExecute_btn.Location = New System.Drawing.Point(24, 24)
        Me.SqlExecute_btn.Name = "SqlExecute_btn"
        Me.SqlExecute_btn.Size = New System.Drawing.Size(181, 22)
        Me.SqlExecute_btn.StyleController = Me.LayoutControl1
        Me.SqlExecute_btn.TabIndex = 5
        Me.SqlExecute_btn.Text = "Execute SQL Command"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(24, 50)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MemoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.MemoEdit1.Properties.Appearance.Options.UseFont = True
        Me.MemoEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.MemoEdit1.Size = New System.Drawing.Size(1081, 217)
        Me.MemoEdit1.StyleController = Me.LayoutControl1
        Me.MemoEdit1.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1129, 291)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem3, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1109, 271)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(813, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(136, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MemoEdit1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1085, 221)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SqlExecute_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(185, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SqlClear_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(185, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(222, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SqlSave_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(407, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(231, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SqlLoad_btn
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(638, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(175, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.NewSqlQueryForm_btn
        Me.LayoutControlItem6.Location = New System.Drawing.Point(949, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(136, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Location = New System.Drawing.Point(374, 291)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(5, 431)
        Me.SplitterControl1.TabIndex = 3
        Me.SplitterControl1.TabStop = False
        '
        'SplitterControl2
        '
        Me.SplitterControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitterControl2.Location = New System.Drawing.Point(379, 291)
        Me.SplitterControl2.Name = "SplitterControl2"
        Me.SplitterControl2.Size = New System.Drawing.Size(1124, 5)
        Me.SplitterControl2.TabIndex = 4
        Me.SplitterControl2.TabStop = False
        '
        'ALL_TABLE_COLUMNSTableAdapter
        '
        Me.ALL_TABLE_COLUMNSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_TABLE_COLUMNSTableAdapter = Me.ALL_TABLE_COLUMNSTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CLIENT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.CURRENT_USERSTableAdapter = Nothing
        Me.TableAdapterManager.FILES_IMPORTTableAdapter = Nothing
        Me.TableAdapterManager.IMPORT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.MANUAL_IMPORTSTableAdapter = Nothing
        Me.TableAdapterManager.OCBS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_SECONDTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        'BgwSqlExecute
        '
        Me.BgwSqlExecute.WorkerReportsProgress = True
        Me.BgwSqlExecute.WorkerSupportsCancellation = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SqlServerQueries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1503, 722)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SplitterControl2)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.TreeList1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SqlServerQueries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sql Server Queries"
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALL_TABLE_COLUMNSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents SplitterControl2 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Gridview1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EDPDataSet As PS_TOOL_DX.EDPDataSet
    Friend WithEvents ALL_TABLE_COLUMNSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ALL_TABLE_COLUMNSTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.ALL_TABLE_COLUMNSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents SqlSave_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SqlClear_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SqlExecute_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SqlLoad_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BgwSqlExecute As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents NewSqlQueryForm_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colDataTypeALL As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colCOLUMN_DEFAULT As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colIS_NULLABLE As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
