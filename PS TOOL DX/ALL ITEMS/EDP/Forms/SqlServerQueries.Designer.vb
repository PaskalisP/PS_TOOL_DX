<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlServerQueries
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Me.Gridview1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BbiExecuteSqlCommand = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClearCurrentSqlCommand = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiSaveSqlCommand = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiLoadSqlCommand = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiNewSqlQueryForm = New DevExpress.XtraBars.BarButtonItem()
        Me.Bts_TreelistVisibility = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.BbiPrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSearchReplace = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiReloadTreeList = New DevExpress.XtraBars.BarButtonItem()
        Me.SqlCommandSaved_BarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.TreeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colDataTypeALL = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colCOLUMN_DEFAULT = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colIS_NULLABLE = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SqlExecute_LayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterControl2 = New DevExpress.XtraEditors.SplitterControl()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.BgwSqlExecute = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TreeList_PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlExecute_LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList_PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutView1
        '
        Me.LayoutView1.DetailHeight = 303
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
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 2, True, False, "Print or Export results", Nothing), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 14, True, False, "Show/Hide Tables", Nothing)})
        GridLevelNode1.LevelTemplate = Me.LayoutView1
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.Gridview1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(868, 225)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gridview1, Me.LayoutView1})
        '
        'Gridview1
        '
        Me.Gridview1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Gridview1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Gridview1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.Gridview1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.Gridview1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.Gridview1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Gridview1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Gridview1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Gridview1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Gridview1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Gridview1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Gridview1.Appearance.GroupRow.Options.UseForeColor = True
        Me.Gridview1.DetailHeight = 303
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
        Me.Gridview1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.Gridview1.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.[True]
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
        'RibbonControl
        '
        Me.RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.BbiExecuteSqlCommand, Me.BbiClearCurrentSqlCommand, Me.BbiSaveSqlCommand, Me.BbiLoadSqlCommand, Me.BbiNewSqlQueryForm, Me.Bts_TreelistVisibility, Me.BbiPrintExport, Me.BbiClose, Me.bbiSearchReplace, Me.bbiReloadTreeList, Me.SqlCommandSaved_BarStaticItem})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 12
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.SqlCommandSaved_BarStaticItem)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.bbiReloadTreeList)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.Bts_TreelistVisibility)
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.BbiNewSqlQueryForm)
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.Size = New System.Drawing.Size(1230, 94)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BbiExecuteSqlCommand
        '
        Me.BbiExecuteSqlCommand.Caption = "Execute SQL Command"
        Me.BbiExecuteSqlCommand.Id = 1
        Me.BbiExecuteSqlCommand.ImageOptions.Image = CType(resources.GetObject("BbiExecuteSqlCommand.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiExecuteSqlCommand.ImageOptions.LargeImage = CType(resources.GetObject("BbiExecuteSqlCommand.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiExecuteSqlCommand.Name = "BbiExecuteSqlCommand"
        '
        'BbiClearCurrentSqlCommand
        '
        Me.BbiClearCurrentSqlCommand.Caption = "Clear SQL Command"
        Me.BbiClearCurrentSqlCommand.Id = 2
        Me.BbiClearCurrentSqlCommand.ImageOptions.Image = CType(resources.GetObject("BbiClearCurrentSqlCommand.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiClearCurrentSqlCommand.ImageOptions.LargeImage = CType(resources.GetObject("BbiClearCurrentSqlCommand.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiClearCurrentSqlCommand.Name = "BbiClearCurrentSqlCommand"
        '
        'BbiSaveSqlCommand
        '
        Me.BbiSaveSqlCommand.Caption = "Save SQL Command"
        Me.BbiSaveSqlCommand.Id = 3
        Me.BbiSaveSqlCommand.ImageOptions.Image = CType(resources.GetObject("BbiSaveSqlCommand.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiSaveSqlCommand.ImageOptions.LargeImage = CType(resources.GetObject("BbiSaveSqlCommand.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiSaveSqlCommand.Name = "BbiSaveSqlCommand"
        '
        'BbiLoadSqlCommand
        '
        Me.BbiLoadSqlCommand.Caption = "Load SQL Command"
        Me.BbiLoadSqlCommand.Id = 4
        Me.BbiLoadSqlCommand.ImageOptions.Image = CType(resources.GetObject("BbiLoadSqlCommand.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiLoadSqlCommand.ImageOptions.LargeImage = CType(resources.GetObject("BbiLoadSqlCommand.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiLoadSqlCommand.Name = "BbiLoadSqlCommand"
        '
        'BbiNewSqlQueryForm
        '
        Me.BbiNewSqlQueryForm.Caption = "New SQL Query Form"
        Me.BbiNewSqlQueryForm.Id = 5
        Me.BbiNewSqlQueryForm.ImageOptions.Image = CType(resources.GetObject("BbiNewSqlQueryForm.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiNewSqlQueryForm.ImageOptions.LargeImage = CType(resources.GetObject("BbiNewSqlQueryForm.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiNewSqlQueryForm.Name = "BbiNewSqlQueryForm"
        '
        'Bts_TreelistVisibility
        '
        Me.Bts_TreelistVisibility.BindableChecked = True
        Me.Bts_TreelistVisibility.Caption = "Hide Treelist"
        Me.Bts_TreelistVisibility.Checked = True
        Me.Bts_TreelistVisibility.Id = 6
        Me.Bts_TreelistVisibility.Name = "Bts_TreelistVisibility"
        '
        'BbiPrintExport
        '
        Me.BbiPrintExport.Caption = "Print or Export"
        Me.BbiPrintExport.Id = 7
        Me.BbiPrintExport.ImageOptions.ImageUri.Uri = "Print"
        Me.BbiPrintExport.Name = "BbiPrintExport"
        '
        'BbiClose
        '
        Me.BbiClose.Caption = "Close"
        Me.BbiClose.Id = 8
        Me.BbiClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BbiClose.Name = "BbiClose"
        '
        'bbiSearchReplace
        '
        Me.bbiSearchReplace.Caption = "Search + Replace"
        Me.bbiSearchReplace.Id = 9
        Me.bbiSearchReplace.ImageOptions.SvgImage = CType(resources.GetObject("bbiSearchReplace.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiSearchReplace.Name = "bbiSearchReplace"
        '
        'bbiReloadTreeList
        '
        Me.bbiReloadTreeList.Caption = "Reload Treelist"
        Me.bbiReloadTreeList.Id = 10
        Me.bbiReloadTreeList.ImageOptions.SvgImage = CType(resources.GetObject("bbiReloadTreeList.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiReloadTreeList.Name = "bbiReloadTreeList"
        '
        'SqlCommandSaved_BarStaticItem
        '
        Me.SqlCommandSaved_BarStaticItem.Id = 11
        Me.SqlCommandSaved_BarStaticItem.ImageOptions.Image = CType(resources.GetObject("SqlCommandSaved_BarStaticItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SqlCommandSaved_BarStaticItem.ImageOptions.LargeImage = CType(resources.GetObject("SqlCommandSaved_BarStaticItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Navy
        Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.Options.UseFont = True
        Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.Options.UseForeColor = True
        Me.SqlCommandSaved_BarStaticItem.Name = "SqlCommandSaved_BarStaticItem"
        Me.SqlCommandSaved_BarStaticItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.SqlCommandSaved_BarStaticItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3, Me.RibbonPageGroup4, Me.RibbonPageGroup5, Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup6})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BbiExecuteSqlCommand)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "RibbonPageGroup3"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BbiClearCurrentSqlCommand)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.bbiSearchReplace, True)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "RibbonPageGroup4"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BbiSaveSqlCommand)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "RibbonPageGroup5"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BbiLoadSqlCommand)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiPrintExport)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BbiClose)
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Text = "RibbonPageGroup6"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 539)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1230, 22)
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
        Me.TreeList1.ColumnsImageList = Me.SharedImageCollection1
        Me.TreeList1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeList1.CustomizationFormBounds = New System.Drawing.Rectangle(1468, 660, 250, 200)
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeList1.Location = New System.Drawing.Point(0, 94)
        Me.TreeList1.MinWidth = 17
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsBehavior.PopulateServiceColumns = True
        Me.TreeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Matches
        Me.TreeList1.OptionsFilter.ShowAllValuesInFilterPopup = True
        Me.TreeList1.OptionsFind.AlwaysVisible = True
        Me.TreeList1.OptionsView.AutoWidth = False
        Me.TreeList1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeList1.OptionsView.ShowAutoFilterRow = True
        Me.TreeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways
        Me.TreeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid
        Me.TreeList1.ParentFieldName = "ID"
        Me.TreeList1.PreviewFieldName = "ID"
        Me.TreeList1.Size = New System.Drawing.Size(326, 445)
        Me.TreeList1.TabIndex = 2
        Me.TreeList1.TreeLevelWidth = 15
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.AppearanceCell.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeListColumn1.AppearanceCell.Options.UseFont = True
        Me.TreeListColumn1.Caption = "TABLE NAMES"
        Me.TreeListColumn1.FieldName = "TABLE_NAME"
        Me.TreeListColumn1.ImageOptions.ImageIndex = 7
        Me.TreeListColumn1.MinWidth = 29
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.TreeListColumn1.OptionsFilter.ImmediateUpdatePopupDateFilter = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        Me.TreeListColumn1.Width = 134
        '
        'TreeListColumn2
        '
        Me.TreeListColumn2.AppearanceCell.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeListColumn2.AppearanceCell.Options.UseFont = True
        Me.TreeListColumn2.Caption = "COLUMN NAMES"
        Me.TreeListColumn2.FieldName = "COLUMN_NAME"
        Me.TreeListColumn2.ImageOptions.ImageIndex = 8
        Me.TreeListColumn2.MinWidth = 17
        Me.TreeListColumn2.Name = "TreeListColumn2"
        Me.TreeListColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.TreeListColumn2.Visible = True
        Me.TreeListColumn2.VisibleIndex = 1
        Me.TreeListColumn2.Width = 169
        '
        'colDataTypeALL
        '
        Me.colDataTypeALL.AppearanceCell.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDataTypeALL.AppearanceCell.Options.UseFont = True
        Me.colDataTypeALL.Caption = "COLUMN DATA TYPE"
        Me.colDataTypeALL.FieldName = "DATA_TYPE"
        Me.colDataTypeALL.ImageOptions.ImageIndex = 16
        Me.colDataTypeALL.MinWidth = 17
        Me.colDataTypeALL.Name = "colDataTypeALL"
        Me.colDataTypeALL.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.colDataTypeALL.Width = 109
        '
        'colCOLUMN_DEFAULT
        '
        Me.colCOLUMN_DEFAULT.AppearanceCell.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCOLUMN_DEFAULT.AppearanceCell.Options.UseFont = True
        Me.colCOLUMN_DEFAULT.Caption = "COLUMN DEFAULT VALUE"
        Me.colCOLUMN_DEFAULT.FieldName = "COLUMN_DEFAULT"
        Me.colCOLUMN_DEFAULT.ImageOptions.ImageIndex = 17
        Me.colCOLUMN_DEFAULT.MinWidth = 17
        Me.colCOLUMN_DEFAULT.Name = "colCOLUMN_DEFAULT"
        Me.colCOLUMN_DEFAULT.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.BeginsWith
        Me.colCOLUMN_DEFAULT.Width = 64
        '
        'colIS_NULLABLE
        '
        Me.colIS_NULLABLE.AppearanceCell.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colIS_NULLABLE.AppearanceCell.Options.UseFont = True
        Me.colIS_NULLABLE.Caption = "IS NULLABLE"
        Me.colIS_NULLABLE.FieldName = "IS_NULLABLE"
        Me.colIS_NULLABLE.ImageOptions.ImageIndex = 18
        Me.colIS_NULLABLE.MinWidth = 17
        Me.colIS_NULLABLE.Name = "colIS_NULLABLE"
        Me.colIS_NULLABLE.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Equals
        Me.colIS_NULLABLE.Width = 64
        '
        'SharedImageCollection1
        '
        '
        '
        '
        Me.SharedImageCollection1.ImageSource.ImageStream = CType(resources.GetObject("SharedImageCollection1.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(0, "usergroup_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(1, "add_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(2, "BankABCLogoFra.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(3, "properties_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(4, "closeheaderandfooter_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(5, "apply_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(6, "cancel_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(7, "table_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(8, "columnsthree_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(9, "Windows-Cascade-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(10, "application-tile-horizontal-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(11, "application-tile-vertical-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(12, "warning_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(13, "cancel_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(14, "about_16x16.png")
        Me.SharedImageCollection1.ParentControl = Me
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl1.Controls.Add(Me.RichEditControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(326, 94)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(904, 184)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.Aqua
        Me.ProgressPanel1.AppearanceCaption.Options.UseFont = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseForeColor = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseTextOptions = True
        Me.ProgressPanel1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ProgressPanel1.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.ProgressPanel1.AutoWidth = True
        Me.ProgressPanel1.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration
        Me.ProgressPanel1.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Triangle
        Me.ProgressPanel1.Location = New System.Drawing.Point(24, 45)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(116, 16)
        Me.ProgressPanel1.StyleController = Me.LayoutControl1
        Me.ProgressPanel1.TabIndex = 8
        Me.ProgressPanel1.Text = "ProgressPanel1"
        '
        'RichEditControl1
        '
        Me.RichEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl1.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl1.Appearance.Text.Options.UseFont = True
        Me.RichEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl1.Location = New System.Drawing.Point(12, 77)
        Me.RichEditControl1.MenuManager = Me.RibbonControl
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Size = New System.Drawing.Size(880, 95)
        Me.RichEditControl1.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.SqlExecute_LayoutControlGroup})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(904, 184)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.RichEditControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 65)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(884, 99)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SqlExecute_LayoutControlGroup
        '
        Me.SqlExecute_LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.SqlExecute_LayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.SqlExecute_LayoutControlGroup.Name = "SqlExecute_LayoutControlGroup"
        Me.SqlExecute_LayoutControlGroup.Size = New System.Drawing.Size(884, 65)
        Me.SqlExecute_LayoutControlGroup.Text = "Executing SQL Command"
        Me.SqlExecute_LayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ProgressPanel1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(860, 20)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SplitterControl2
        '
        Me.SplitterControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitterControl2.Appearance.Options.UseBackColor = True
        Me.SplitterControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitterControl2.Location = New System.Drawing.Point(326, 278)
        Me.SplitterControl2.LookAndFeel.SkinName = "Office 2013"
        Me.SplitterControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SplitterControl2.Name = "SplitterControl2"
        Me.SplitterControl2.Size = New System.Drawing.Size(904, 12)
        Me.SplitterControl2.TabIndex = 7
        Me.SplitterControl2.TabStop = False
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitterControl1.Appearance.Options.UseBackColor = True
        Me.SplitterControl1.Location = New System.Drawing.Point(326, 290)
        Me.SplitterControl1.LookAndFeel.SkinName = "Office 2013"
        Me.SplitterControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(12, 249)
        Me.SplitterControl1.TabIndex = 8
        Me.SplitterControl1.TabStop = False
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GridControl1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(338, 290)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.Root
        Me.LayoutControl2.Size = New System.Drawing.Size(892, 249)
        Me.LayoutControl2.TabIndex = 9
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(892, 249)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(872, 229)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
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
        'TreeList_PopupMenu
        '
        Me.TreeList_PopupMenu.Name = "TreeList_PopupMenu"
        Me.TreeList_PopupMenu.Ribbon = Me.RibbonControl
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "adateoccurring_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "formatnumberdecreasedecimal_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "formatnumberincreasedecimal_16x16.png")
        '
        'SqlServerQueries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 561)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.SplitterControl2)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.ShowIcon = False
        Me.KeyPreview = True
        Me.Name = "SqlServerQueries"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Sql Queries"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SqlExecute_LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList_PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BbiExecuteSqlCommand As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiClearCurrentSqlCommand As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiSaveSqlCommand As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiLoadSqlCommand As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiNewSqlQueryForm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents TreeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colDataTypeALL As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colCOLUMN_DEFAULT As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colIS_NULLABLE As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents Gridview1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitterControl2 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BgwSqlExecute As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Bts_TreelistVisibility As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents BbiPrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents BbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SqlExecute_LayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TreeList_PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiSearchReplace As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiReloadTreeList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents SqlCommandSaved_BarStaticItem As DevExpress.XtraBars.BarStaticItem
End Class
