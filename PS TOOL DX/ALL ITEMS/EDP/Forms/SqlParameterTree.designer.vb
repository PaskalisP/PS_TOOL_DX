<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlParameterTree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SqlParameterTree))
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.Script_ImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BbiSqlReload = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddNewSqlParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiPrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateCurrentSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateNextSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSearchAndReplace = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExportCurrentSqlParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.colSQL_TREE_ID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_PARENTID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_NAME1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_NAME2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_NAME3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_NAME4 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_PARAMETER1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQL_TREE_COMMAND_PARAMETER2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_PARAMETER3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_COMMAND_PARAMETER4 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_FLOAT_1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_FLOAT_2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_FLOAT_3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_FLOAT_4 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_DATE_1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_DATE_2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_STATUS = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.Status_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colSQL_TREE_SCRIPT_TYPE_1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ScriptType_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colSQL_TREE_SCRIPT_TYPE_2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_SCRIPT_TYPE_3 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_SCRIPT_TYPE_4 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_LAST_ACTION = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_LAST_UPDATE_USER = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_LAST_UPDATE_DATE = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colSQL_TREE_TABLE_LEVEL = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.PopupContainerEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.PopupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl2 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.MemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Script_ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScriptType_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl1.SuspendLayout()
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SharedImageCollection1
        '
        '
        '
        '
        Me.SharedImageCollection1.ImageSource.ImageStream = CType(resources.GetObject("SharedImageCollection1.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(0, "usergroup_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(1, "add_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(2, "BankABCLogoN.png")
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
        Me.SharedImageCollection1.ParentControl = Me
        '
        'Script_ImageCollection
        '
        Me.Script_ImageCollection.ImageStream = CType(resources.GetObject("Script_ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.Script_ImageCollection.Images.SetKeyName(0, "sql-server.png")
        Me.Script_ImageCollection.Images.SetKeyName(1, "vb_16x16.png")
        Me.Script_ImageCollection.Images.SetKeyName(2, "index_16x16.png")
        '
        'RibbonControl
        '
        Me.RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.BbiSqlReload, Me.BbiAddNewSqlParameter, Me.BbiPrintExport, Me.BbiClose, Me.BbiDuplicateSQLParameter, Me.BbiAddSQLtoPosition, Me.BbiDuplicateCurrentSQLParameter, Me.BbiDuplicateNextSQLParameter, Me.bbiSearchAndReplace, Me.bbiExportCurrentSqlParameter})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 10
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowSearchItem = True
        Me.RibbonControl.Size = New System.Drawing.Size(1383, 94)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BbiSqlReload
        '
        Me.BbiSqlReload.Caption = "Reload"
        Me.BbiSqlReload.Id = 1
        Me.BbiSqlReload.ImageOptions.SvgImage = CType(resources.GetObject("BbiSqlReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiSqlReload.Name = "BbiSqlReload"
        '
        'BbiAddNewSqlParameter
        '
        Me.BbiAddNewSqlParameter.Caption = "Add new SQL Parameter"
        Me.BbiAddNewSqlParameter.Id = 2
        Me.BbiAddNewSqlParameter.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddNewSqlParameter.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddNewSqlParameter.Name = "BbiAddNewSqlParameter"
        '
        'BbiPrintExport
        '
        Me.BbiPrintExport.Caption = "Print preview"
        Me.BbiPrintExport.Id = 5
        Me.BbiPrintExport.ImageOptions.ImageUri.Uri = "Preview"
        Me.BbiPrintExport.Name = "BbiPrintExport"
        '
        'BbiClose
        '
        Me.BbiClose.Caption = "Close"
        Me.BbiClose.Id = 1
        Me.BbiClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BbiClose.Name = "BbiClose"
        '
        'BbiDuplicateSQLParameter
        '
        Me.BbiDuplicateSQLParameter.Caption = "Duplicate SQL Parameter (New Position)"
        Me.BbiDuplicateSQLParameter.Id = 2
        Me.BbiDuplicateSQLParameter.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.Name = "BbiDuplicateSQLParameter"
        '
        'BbiAddSQLtoPosition
        '
        Me.BbiAddSQLtoPosition.Caption = "Add new SQL Command to current Position"
        Me.BbiAddSQLtoPosition.Id = 3
        Me.BbiAddSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddSQLtoPosition.Name = "BbiAddSQLtoPosition"
        '
        'BbiDuplicateCurrentSQLParameter
        '
        Me.BbiDuplicateCurrentSQLParameter.Caption = "Duplicate SQL Parameter (Current Position)"
        Me.BbiDuplicateCurrentSQLParameter.Id = 4
        Me.BbiDuplicateCurrentSQLParameter.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateCurrentSQLParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateCurrentSQLParameter.Name = "BbiDuplicateCurrentSQLParameter"
        '
        'BbiDuplicateNextSQLParameter
        '
        Me.BbiDuplicateNextSQLParameter.Caption = "Duplicate SQL Parameter (Next Position)"
        Me.BbiDuplicateNextSQLParameter.Id = 5
        Me.BbiDuplicateNextSQLParameter.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateNextSQLParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateNextSQLParameter.Name = "BbiDuplicateNextSQLParameter"
        '
        'bbiSearchAndReplace
        '
        Me.bbiSearchAndReplace.Caption = "Search and Replace"
        Me.bbiSearchAndReplace.Id = 6
        Me.bbiSearchAndReplace.ImageOptions.Image = CType(resources.GetObject("bbiSearchAndReplace.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiSearchAndReplace.ImageOptions.LargeImage = CType(resources.GetObject("bbiSearchAndReplace.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiSearchAndReplace.Name = "bbiSearchAndReplace"
        '
        'bbiExportCurrentSqlParameter
        '
        Me.bbiExportCurrentSqlParameter.Caption = "Export current SQL Parameter"
        Me.bbiExportCurrentSqlParameter.Id = 9
        Me.bbiExportCurrentSqlParameter.ImageOptions.Image = CType(resources.GetObject("bbiExportCurrentSqlParameter.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiExportCurrentSqlParameter.ImageOptions.LargeImage = CType(resources.GetObject("bbiExportCurrentSqlParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiExportCurrentSqlParameter.Name = "bbiExportCurrentSqlParameter"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup6, Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiSqlReload)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BbiPrintExport)
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Text = "RibbonPageGroup6"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BbiClose)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 570)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1383, 22)
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.TreeList1)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1383, 476)
        Me.LayoutControl3.TabIndex = 4
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'TreeList1
        '
        Me.TreeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TreeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TreeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.TreeList1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.TreeList1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.TreeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.TreeList1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.TreeList1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.TreeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.TreeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.TreeList1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.TreeList1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colSQL_TREE_ID, Me.colSQL_TREE_PARENTID, Me.colSQL_TREE_COMMAND_NAME1, Me.colSQL_TREE_COMMAND_NAME2, Me.colSQL_TREE_COMMAND_NAME3, Me.colSQL_TREE_COMMAND_NAME4, Me.colSQL_TREE_COMMAND_PARAMETER1, Me.colSQL_TREE_COMMAND_PARAMETER2, Me.colSQL_TREE_COMMAND_PARAMETER3, Me.colSQL_TREE_COMMAND_PARAMETER4, Me.colSQL_TREE_FLOAT_1, Me.colSQL_TREE_FLOAT_2, Me.colSQL_TREE_FLOAT_3, Me.colSQL_TREE_FLOAT_4, Me.colSQL_TREE_DATE_1, Me.colSQL_TREE_DATE_2, Me.colSQL_TREE_STATUS, Me.colSQL_TREE_SCRIPT_TYPE_1, Me.colSQL_TREE_SCRIPT_TYPE_2, Me.colSQL_TREE_SCRIPT_TYPE_3, Me.colSQL_TREE_SCRIPT_TYPE_4, Me.colSQL_TREE_LAST_ACTION, Me.colSQL_TREE_LAST_UPDATE_USER, Me.colSQL_TREE_LAST_UPDATE_DATE, Me.colSQL_TREE_TABLE_LEVEL})
        Me.TreeList1.CustomizationFormBounds = New System.Drawing.Rectangle(1179, 425, 252, 266)
        Me.TreeList1.HierarchyColumn = Me.colSQL_TREE_FLOAT_1
        Me.TreeList1.HierarchyFieldName = "SQL_Float_1"
        Me.TreeList1.Location = New System.Drawing.Point(12, 12)
        Me.TreeList1.MenuManager = Me.RibbonControl
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.AllowExpandAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeList1.OptionsBehavior.PopulateServiceColumns = True
        Me.TreeList1.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeList1.OptionsFilter.ExpandNodesOnFiltering = True
        Me.TreeList1.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.EntireBranch
        Me.TreeList1.OptionsFind.AllowIncrementalSearch = True
        Me.TreeList1.OptionsFind.AlwaysVisible = True
        Me.TreeList1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter
        Me.TreeList1.OptionsFind.ExpandNodesOnIncrementalSearch = True
        Me.TreeList1.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always
        Me.TreeList1.OptionsView.AutoWidth = False
        Me.TreeList1.OptionsView.ShowAutoFilterRow = True
        Me.TreeList1.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.ShowAlways
        Me.TreeList1.OptionsView.ShowIndentAsRowStyle = True
        Me.TreeList1.ParentFieldName = "PARENTID"
        Me.TreeList1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoExEdit1, Me.PopupContainerEdit3, Me.ScriptType_ImageComboBox, Me.Status_ImageComboBox, Me.MemoEdit1})
        Me.TreeList1.Size = New System.Drawing.Size(1359, 452)
        Me.TreeList1.TabIndex = 26
        '
        'colSQL_TREE_ID
        '
        Me.colSQL_TREE_ID.FieldName = "ID"
        Me.colSQL_TREE_ID.Name = "colSQL_TREE_ID"
        Me.colSQL_TREE_ID.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_ID.Visible = True
        Me.colSQL_TREE_ID.VisibleIndex = 0
        '
        'colSQL_TREE_PARENTID
        '
        Me.colSQL_TREE_PARENTID.FieldName = "PARENTID"
        Me.colSQL_TREE_PARENTID.Name = "colSQL_TREE_PARENTID"
        Me.colSQL_TREE_PARENTID.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_PARENTID.Visible = True
        Me.colSQL_TREE_PARENTID.VisibleIndex = 1
        '
        'colSQL_TREE_COMMAND_NAME1
        '
        Me.colSQL_TREE_COMMAND_NAME1.Caption = "SQL Name 1"
        Me.colSQL_TREE_COMMAND_NAME1.FieldName = "SQL_Name_1"
        Me.colSQL_TREE_COMMAND_NAME1.Name = "colSQL_TREE_COMMAND_NAME1"
        Me.colSQL_TREE_COMMAND_NAME1.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_COMMAND_NAME1.Visible = True
        Me.colSQL_TREE_COMMAND_NAME1.VisibleIndex = 3
        Me.colSQL_TREE_COMMAND_NAME1.Width = 607
        '
        'colSQL_TREE_COMMAND_NAME2
        '
        Me.colSQL_TREE_COMMAND_NAME2.Caption = "SQL Name 2"
        Me.colSQL_TREE_COMMAND_NAME2.FieldName = "SQL_Name_2"
        Me.colSQL_TREE_COMMAND_NAME2.Name = "colSQL_TREE_COMMAND_NAME2"
        Me.colSQL_TREE_COMMAND_NAME2.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_COMMAND_NAME3
        '
        Me.colSQL_TREE_COMMAND_NAME3.Caption = "SQL Name 3"
        Me.colSQL_TREE_COMMAND_NAME3.FieldName = "SQL_Name_3"
        Me.colSQL_TREE_COMMAND_NAME3.Name = "colSQL_TREE_COMMAND_NAME3"
        Me.colSQL_TREE_COMMAND_NAME3.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_COMMAND_NAME4
        '
        Me.colSQL_TREE_COMMAND_NAME4.Caption = "SQL Name 4"
        Me.colSQL_TREE_COMMAND_NAME4.FieldName = "SQL_Name_4"
        Me.colSQL_TREE_COMMAND_NAME4.Name = "colSQL_TREE_COMMAND_NAME4"
        Me.colSQL_TREE_COMMAND_NAME4.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_COMMAND_PARAMETER1
        '
        Me.colSQL_TREE_COMMAND_PARAMETER1.Caption = "SQL Command 1"
        Me.colSQL_TREE_COMMAND_PARAMETER1.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQL_TREE_COMMAND_PARAMETER1.FieldName = "SQL_Command_1"
        Me.colSQL_TREE_COMMAND_PARAMETER1.Name = "colSQL_TREE_COMMAND_PARAMETER1"
        Me.colSQL_TREE_COMMAND_PARAMETER1.Visible = True
        Me.colSQL_TREE_COMMAND_PARAMETER1.VisibleIndex = 5
        Me.colSQL_TREE_COMMAND_PARAMETER1.Width = 100
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colSQL_TREE_COMMAND_PARAMETER2
        '
        Me.colSQL_TREE_COMMAND_PARAMETER2.Caption = "SQL Command 2"
        Me.colSQL_TREE_COMMAND_PARAMETER2.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQL_TREE_COMMAND_PARAMETER2.FieldName = "SQL_Command_2"
        Me.colSQL_TREE_COMMAND_PARAMETER2.Name = "colSQL_TREE_COMMAND_PARAMETER2"
        '
        'colSQL_TREE_COMMAND_PARAMETER3
        '
        Me.colSQL_TREE_COMMAND_PARAMETER3.Caption = "SQL Command 3"
        Me.colSQL_TREE_COMMAND_PARAMETER3.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQL_TREE_COMMAND_PARAMETER3.FieldName = "SQL_Command_3"
        Me.colSQL_TREE_COMMAND_PARAMETER3.Name = "colSQL_TREE_COMMAND_PARAMETER3"
        '
        'colSQL_TREE_COMMAND_PARAMETER4
        '
        Me.colSQL_TREE_COMMAND_PARAMETER4.Caption = "SQL Command 4"
        Me.colSQL_TREE_COMMAND_PARAMETER4.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQL_TREE_COMMAND_PARAMETER4.FieldName = "SQL_Command_4"
        Me.colSQL_TREE_COMMAND_PARAMETER4.Name = "colSQL_TREE_COMMAND_PARAMETER4"
        '
        'colSQL_TREE_FLOAT_1
        '
        Me.colSQL_TREE_FLOAT_1.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_FLOAT_1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_FLOAT_1.Caption = "Float 1"
        Me.colSQL_TREE_FLOAT_1.FieldName = "SQL_Float_1"
        Me.colSQL_TREE_FLOAT_1.Name = "colSQL_TREE_FLOAT_1"
        Me.colSQL_TREE_FLOAT_1.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_FLOAT_1.Visible = True
        Me.colSQL_TREE_FLOAT_1.VisibleIndex = 2
        Me.colSQL_TREE_FLOAT_1.Width = 109
        '
        'colSQL_TREE_FLOAT_2
        '
        Me.colSQL_TREE_FLOAT_2.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_FLOAT_2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_FLOAT_2.Caption = "Float 2"
        Me.colSQL_TREE_FLOAT_2.FieldName = "SQL_Float_2"
        Me.colSQL_TREE_FLOAT_2.Name = "colSQL_TREE_FLOAT_2"
        Me.colSQL_TREE_FLOAT_2.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_FLOAT_3
        '
        Me.colSQL_TREE_FLOAT_3.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_FLOAT_3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_FLOAT_3.Caption = "Float 3"
        Me.colSQL_TREE_FLOAT_3.FieldName = "SQL_Float_3"
        Me.colSQL_TREE_FLOAT_3.Name = "colSQL_TREE_FLOAT_3"
        Me.colSQL_TREE_FLOAT_3.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_FLOAT_4
        '
        Me.colSQL_TREE_FLOAT_4.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_FLOAT_4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_FLOAT_4.Caption = "Float 4"
        Me.colSQL_TREE_FLOAT_4.FieldName = "SQL_Float_4"
        Me.colSQL_TREE_FLOAT_4.Name = "colSQL_TREE_FLOAT_4"
        Me.colSQL_TREE_FLOAT_4.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_DATE_1
        '
        Me.colSQL_TREE_DATE_1.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_DATE_1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_DATE_1.Caption = "Date 1"
        Me.colSQL_TREE_DATE_1.FieldName = "SQL_Date1"
        Me.colSQL_TREE_DATE_1.Name = "colSQL_TREE_DATE_1"
        Me.colSQL_TREE_DATE_1.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_DATE_2
        '
        Me.colSQL_TREE_DATE_2.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_DATE_2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_DATE_2.Caption = "Date 2"
        Me.colSQL_TREE_DATE_2.FieldName = "SQL_Date2"
        Me.colSQL_TREE_DATE_2.Name = "colSQL_TREE_DATE_2"
        Me.colSQL_TREE_DATE_2.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_STATUS
        '
        Me.colSQL_TREE_STATUS.Caption = "Status"
        Me.colSQL_TREE_STATUS.ColumnEdit = Me.Status_ImageComboBox
        Me.colSQL_TREE_STATUS.FieldName = "SQL_Status"
        Me.colSQL_TREE_STATUS.Name = "colSQL_TREE_STATUS"
        Me.colSQL_TREE_STATUS.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_STATUS.Visible = True
        Me.colSQL_TREE_STATUS.VisibleIndex = 6
        Me.colSQL_TREE_STATUS.Width = 134
        '
        'Status_ImageComboBox
        '
        Me.Status_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Status_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Status_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Status_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.Status_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.Status_ImageComboBox.AutoHeight = False
        Me.Status_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Status_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEACTIVATED", "N", 6)})
        Me.Status_ImageComboBox.Name = "Status_ImageComboBox"
        Me.Status_ImageComboBox.SmallImages = Me.SharedImageCollection1
        '
        'colSQL_TREE_SCRIPT_TYPE_1
        '
        Me.colSQL_TREE_SCRIPT_TYPE_1.Caption = "Script Type 1"
        Me.colSQL_TREE_SCRIPT_TYPE_1.ColumnEdit = Me.ScriptType_ImageComboBox
        Me.colSQL_TREE_SCRIPT_TYPE_1.FieldName = "SQL_ScriptType_1"
        Me.colSQL_TREE_SCRIPT_TYPE_1.Name = "colSQL_TREE_SCRIPT_TYPE_1"
        Me.colSQL_TREE_SCRIPT_TYPE_1.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_SCRIPT_TYPE_1.Visible = True
        Me.colSQL_TREE_SCRIPT_TYPE_1.VisibleIndex = 4
        Me.colSQL_TREE_SCRIPT_TYPE_1.Width = 118
        '
        'ScriptType_ImageComboBox
        '
        Me.ScriptType_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ScriptType_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ScriptType_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ScriptType_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ScriptType_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ScriptType_ImageComboBox.AutoHeight = False
        Me.ScriptType_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ScriptType_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("SQL", "SQL", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VB.NET", "VB", 1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO SCRIPT", "N", 2)})
        Me.ScriptType_ImageComboBox.Name = "ScriptType_ImageComboBox"
        Me.ScriptType_ImageComboBox.SmallImages = Me.Script_ImageCollection
        '
        'colSQL_TREE_SCRIPT_TYPE_2
        '
        Me.colSQL_TREE_SCRIPT_TYPE_2.Caption = "Script Type 2"
        Me.colSQL_TREE_SCRIPT_TYPE_2.ColumnEdit = Me.ScriptType_ImageComboBox
        Me.colSQL_TREE_SCRIPT_TYPE_2.FieldName = "SQL_ScriptType_2"
        Me.colSQL_TREE_SCRIPT_TYPE_2.Name = "colSQL_TREE_SCRIPT_TYPE_2"
        Me.colSQL_TREE_SCRIPT_TYPE_2.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_SCRIPT_TYPE_3
        '
        Me.colSQL_TREE_SCRIPT_TYPE_3.Caption = "Script Type 3"
        Me.colSQL_TREE_SCRIPT_TYPE_3.ColumnEdit = Me.ScriptType_ImageComboBox
        Me.colSQL_TREE_SCRIPT_TYPE_3.FieldName = "SQL_ScriptType_3"
        Me.colSQL_TREE_SCRIPT_TYPE_3.Name = "colSQL_TREE_SCRIPT_TYPE_3"
        Me.colSQL_TREE_SCRIPT_TYPE_3.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_SCRIPT_TYPE_4
        '
        Me.colSQL_TREE_SCRIPT_TYPE_4.Caption = "Script Type 4"
        Me.colSQL_TREE_SCRIPT_TYPE_4.ColumnEdit = Me.ScriptType_ImageComboBox
        Me.colSQL_TREE_SCRIPT_TYPE_4.FieldName = "SQL_ScriptType_4"
        Me.colSQL_TREE_SCRIPT_TYPE_4.Name = "colSQL_TREE_SCRIPT_TYPE_4"
        Me.colSQL_TREE_SCRIPT_TYPE_4.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_LAST_ACTION
        '
        Me.colSQL_TREE_LAST_ACTION.Caption = "Last Action"
        Me.colSQL_TREE_LAST_ACTION.FieldName = "LastAction"
        Me.colSQL_TREE_LAST_ACTION.Name = "colSQL_TREE_LAST_ACTION"
        Me.colSQL_TREE_LAST_ACTION.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_LAST_UPDATE_USER
        '
        Me.colSQL_TREE_LAST_UPDATE_USER.Caption = "Last Update User"
        Me.colSQL_TREE_LAST_UPDATE_USER.FieldName = "LastUpdateUser"
        Me.colSQL_TREE_LAST_UPDATE_USER.Name = "colSQL_TREE_LAST_UPDATE_USER"
        Me.colSQL_TREE_LAST_UPDATE_USER.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_LAST_UPDATE_DATE
        '
        Me.colSQL_TREE_LAST_UPDATE_DATE.Caption = "Last Update Date"
        Me.colSQL_TREE_LAST_UPDATE_DATE.FieldName = "LastUpdateDate"
        Me.colSQL_TREE_LAST_UPDATE_DATE.Name = "colSQL_TREE_LAST_UPDATE_DATE"
        Me.colSQL_TREE_LAST_UPDATE_DATE.OptionsColumn.ReadOnly = True
        '
        'colSQL_TREE_TABLE_LEVEL
        '
        Me.colSQL_TREE_TABLE_LEVEL.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colSQL_TREE_TABLE_LEVEL.AppearanceCell.Options.UseFont = True
        Me.colSQL_TREE_TABLE_LEVEL.AppearanceCell.Options.UseTextOptions = True
        Me.colSQL_TREE_TABLE_LEVEL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSQL_TREE_TABLE_LEVEL.Caption = "Table Level"
        Me.colSQL_TREE_TABLE_LEVEL.FieldName = "Table_Level"
        Me.colSQL_TREE_TABLE_LEVEL.Name = "colSQL_TREE_TABLE_LEVEL"
        Me.colSQL_TREE_TABLE_LEVEL.OptionsColumn.ReadOnly = True
        Me.colSQL_TREE_TABLE_LEVEL.Visible = True
        Me.colSQL_TREE_TABLE_LEVEL.VisibleIndex = 7
        '
        'PopupContainerEdit3
        '
        Me.PopupContainerEdit3.Appearance.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupContainerEdit3.Appearance.Options.UseFont = True
        Me.PopupContainerEdit3.AutoHeight = False
        Me.PopupContainerEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit3.Name = "PopupContainerEdit3"
        Me.PopupContainerEdit3.PopupControl = Me.PopupContainerControl1
        '
        'PopupContainerControl1
        '
        Me.PopupContainerControl1.Controls.Add(Me.RichEditControl2)
        Me.PopupContainerControl1.Location = New System.Drawing.Point(966, 50)
        Me.PopupContainerControl1.Name = "PopupContainerControl1"
        Me.PopupContainerControl1.Size = New System.Drawing.Size(162, 38)
        Me.PopupContainerControl1.TabIndex = 13
        '
        'RichEditControl2
        '
        Me.RichEditControl2.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl2.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl2.Appearance.Text.Options.UseFont = True
        Me.RichEditControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl2.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl2.Location = New System.Drawing.Point(0, 0)
        Me.RichEditControl2.MenuManager = Me.RibbonControl
        Me.RichEditControl2.Name = "RichEditControl2"
        Me.RichEditControl2.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl2.TabIndex = 2
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Appearance.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoEdit1.Appearance.Options.UseFont = True
        Me.MemoEdit1.Name = "MemoEdit1"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1383, 476)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TreeList1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1363, 456)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'bbiReload
        '
        Me.bbiReload.Caption = "Reload"
        Me.bbiReload.Id = 3
        Me.bbiReload.ImageOptions.SvgImage = CType(resources.GetObject("bbiReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiReload.Name = "bbiReload"
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.TreeList1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'SqlParameterTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1383, 592)
        Me.Controls.Add(Me.PopupContainerControl1)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.ShowIcon = False
        Me.KeyPreview = True
        Me.Name = "SqlParameterTree"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Sql Parameter Tree"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Script_ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScriptType_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupContainerControl1.ResumeLayout(False)
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BbiSqlReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddNewSqlParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiPrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents BbiDuplicateSQLParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDuplicateCurrentSQLParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDuplicateNextSQLParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSearchAndReplace As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExportCurrentSqlParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Script_ImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colSQL_TREE_ID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_PARENTID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_NAME1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_TABLE_LEVEL As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_NAME2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_NAME3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_NAME4 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_PARAMETER1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_PARAMETER2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_PARAMETER3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_COMMAND_PARAMETER4 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_FLOAT_1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_FLOAT_2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_FLOAT_3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_FLOAT_4 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_DATE_1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_DATE_2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_STATUS As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_SCRIPT_TYPE_1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_SCRIPT_TYPE_2 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_SCRIPT_TYPE_3 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_SCRIPT_TYPE_4 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_LAST_ACTION As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_LAST_UPDATE_USER As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colSQL_TREE_LAST_UPDATE_DATE As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Private WithEvents PopupContainerControl1 As DevExpress.XtraEditors.PopupContainerControl
    Private WithEvents RichEditControl2 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents PopupContainerEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Status_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ScriptType_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
