<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MappingDiverseGL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MappingDiverseGL))
        Me.MappedGLaccounts_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIdNr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemGridLookUpEditGLACCOUNTS = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GL_ACCOUNTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalancesDataset = New PS_TOOL_DX.BalancesDataset()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_Range_From = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_Range_Till = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_ClosingBalanceDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_ClosingBalanceAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ITEM_Mapped = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_CCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchange_Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_ClosingBalanceAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.DIVERSE_GL_ITEMSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.DIVERSE_GLitems_View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ITEM_NR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEditGLITEM = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colGL_ITEM_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.DIVERSE_GL_ITEMSTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.DIVERSE_GL_ITEMSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager()
        Me.DIVERSE_MAPPINGTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.DIVERSE_MAPPINGTableAdapter()
        Me.GL_ACCOUNTSTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.GL_ACCOUNTSTableAdapter()
        Me.DIVERSE_MAPPINGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.MappedGLaccounts_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEditGLACCOUNTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GL_ACCOUNTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIVERSE_GL_ITEMSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIVERSE_GLitems_View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditGLITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIVERSE_MAPPINGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MappedGLaccounts_BaseView
        '
        Me.MappedGLaccounts_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.MappedGLaccounts_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.MappedGLaccounts_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.MappedGLaccounts_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.MappedGLaccounts_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.MappedGLaccounts_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIdNr1, Me.colGL_ACC_Nr, Me.colGL_ACC_Name, Me.colGL_ACC_ClosingBalanceDate, Me.colGL_ACC_ClosingBalanceAmount, Me.colGL_ITEM_Mapped, Me.colGL_ACC_CCY, Me.colExchange_Rate, Me.colGL_ACC_ClosingBalanceAmountEUR})
        Me.MappedGLaccounts_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.MappedGLaccounts_BaseView.GridControl = Me.GridControl1
        Me.MappedGLaccounts_BaseView.Name = "MappedGLaccounts_BaseView"
        Me.MappedGLaccounts_BaseView.NewItemRowText = "Add new General Ledger Account for Mapping"
        Me.MappedGLaccounts_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.MappedGLaccounts_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.MappedGLaccounts_BaseView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.MappedGLaccounts_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.MappedGLaccounts_BaseView.OptionsFind.AlwaysVisible = True
        Me.MappedGLaccounts_BaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.MappedGLaccounts_BaseView.OptionsPrint.PrintDetails = True
        Me.MappedGLaccounts_BaseView.OptionsPrint.PrintFilterInfo = True
        Me.MappedGLaccounts_BaseView.OptionsView.ColumnAutoWidth = False
        Me.MappedGLaccounts_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.MappedGLaccounts_BaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.MappedGLaccounts_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.MappedGLaccounts_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.MappedGLaccounts_BaseView.OptionsView.ShowFooter = True
        Me.MappedGLaccounts_BaseView.ViewCaption = "Mapped GL Accounts"
        '
        'colIdNr1
        '
        Me.colIdNr1.FieldName = "IdNr"
        Me.colIdNr1.Name = "colIdNr1"
        Me.colIdNr1.OptionsColumn.AllowEdit = False
        Me.colIdNr1.OptionsColumn.ReadOnly = True
        '
        'colGL_ACC_Nr
        '
        Me.colGL_ACC_Nr.Caption = "GL Account Nr."
        Me.colGL_ACC_Nr.ColumnEdit = Me.RepositoryItemGridLookUpEditGLACCOUNTS
        Me.colGL_ACC_Nr.FieldName = "GL_ACC_Nr"
        Me.colGL_ACC_Nr.Name = "colGL_ACC_Nr"
        Me.colGL_ACC_Nr.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_Nr.Visible = True
        Me.colGL_ACC_Nr.VisibleIndex = 0
        Me.colGL_ACC_Nr.Width = 103
        '
        'RepositoryItemGridLookUpEditGLACCOUNTS
        '
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.AutoHeight = False
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.DataSource = Me.GL_ACCOUNTSBindingSource
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.DisplayMember = "GL_AC_No"
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.ImmediatePopup = True
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.Name = "RepositoryItemGridLookUpEditGLACCOUNTS"
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.NullText = ""
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.NullValuePrompt = "Enter new GL Account"
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.NullValuePromptShowForEmptyValue = True
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.PopupFormMinSize = New System.Drawing.Size(1500, 300)
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.PopupFormSize = New System.Drawing.Size(1500, 300)
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.ValueMember = "GL_AC_No"
        Me.RepositoryItemGridLookUpEditGLACCOUNTS.View = Me.RepositoryItemGridLookUpEdit1View
        '
        'GL_ACCOUNTSBindingSource
        '
        Me.GL_ACCOUNTSBindingSource.DataMember = "GL_ACCOUNTS"
        Me.GL_ACCOUNTSBindingSource.DataSource = Me.BalancesDataset
        '
        'BalancesDataset
        '
        Me.BalancesDataset.DataSetName = "BalancesDataset"
        Me.BalancesDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colGL_AC_No, Me.colGL_AC_Name, Me.colDescription, Me.colGL_AC_Range_From, Me.colGL_AC_Range_Till})
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemGridLookUpEdit1View.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemGridLookUpEdit1View.OptionsFind.AlwaysVisible = True
        Me.RepositoryItemGridLookUpEdit1View.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowFooter = True
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colGL_AC_No
        '
        Me.colGL_AC_No.Caption = "General Ledger Account Nr."
        Me.colGL_AC_No.FieldName = "GL_AC_No"
        Me.colGL_AC_No.Name = "colGL_AC_No"
        Me.colGL_AC_No.Visible = True
        Me.colGL_AC_No.VisibleIndex = 0
        Me.colGL_AC_No.Width = 150
        '
        'colGL_AC_Name
        '
        Me.colGL_AC_Name.Caption = "General Ledger Account Name"
        Me.colGL_AC_Name.FieldName = "GL_AC_Name"
        Me.colGL_AC_Name.Name = "colGL_AC_Name"
        Me.colGL_AC_Name.Visible = True
        Me.colGL_AC_Name.VisibleIndex = 1
        Me.colGL_AC_Name.Width = 496
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 2
        Me.colDescription.Width = 486
        '
        'colGL_AC_Range_From
        '
        Me.colGL_AC_Range_From.FieldName = "GL_AC_Range_From"
        Me.colGL_AC_Range_From.Name = "colGL_AC_Range_From"
        '
        'colGL_AC_Range_Till
        '
        Me.colGL_AC_Range_Till.FieldName = "GL_AC_Range_Till"
        Me.colGL_AC_Range_Till.Name = "colGL_AC_Range_Till"
        '
        'colGL_ACC_Name
        '
        Me.colGL_ACC_Name.Caption = "GL Account Name"
        Me.colGL_ACC_Name.FieldName = "GL_ACC_Name"
        Me.colGL_ACC_Name.Name = "colGL_ACC_Name"
        Me.colGL_ACC_Name.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_Name.Visible = True
        Me.colGL_ACC_Name.VisibleIndex = 1
        Me.colGL_ACC_Name.Width = 530
        '
        'colGL_ACC_ClosingBalanceDate
        '
        Me.colGL_ACC_ClosingBalanceDate.Caption = "Closing Balance Date"
        Me.colGL_ACC_ClosingBalanceDate.FieldName = "GL_ACC_ClosingBalanceDate"
        Me.colGL_ACC_ClosingBalanceDate.Name = "colGL_ACC_ClosingBalanceDate"
        Me.colGL_ACC_ClosingBalanceDate.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_ClosingBalanceDate.Width = 112
        '
        'colGL_ACC_ClosingBalanceAmount
        '
        Me.colGL_ACC_ClosingBalanceAmount.Caption = "Cloaing Balance Amount"
        Me.colGL_ACC_ClosingBalanceAmount.FieldName = "GL_ACC_ClosingBalanceAmount"
        Me.colGL_ACC_ClosingBalanceAmount.Name = "colGL_ACC_ClosingBalanceAmount"
        Me.colGL_ACC_ClosingBalanceAmount.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_ClosingBalanceAmount.Width = 134
        '
        'colGL_ITEM_Mapped
        '
        Me.colGL_ITEM_Mapped.Caption = "Mapped GL Item"
        Me.colGL_ITEM_Mapped.FieldName = "GL_ITEM_Mapped"
        Me.colGL_ITEM_Mapped.Name = "colGL_ITEM_Mapped"
        Me.colGL_ITEM_Mapped.OptionsColumn.AllowEdit = False
        Me.colGL_ITEM_Mapped.OptionsColumn.ReadOnly = True
        Me.colGL_ITEM_Mapped.Visible = True
        Me.colGL_ITEM_Mapped.VisibleIndex = 2
        Me.colGL_ITEM_Mapped.Width = 97
        '
        'colGL_ACC_CCY
        '
        Me.colGL_ACC_CCY.Caption = "Currency"
        Me.colGL_ACC_CCY.FieldName = "GL_ACC_CCY"
        Me.colGL_ACC_CCY.Name = "colGL_ACC_CCY"
        Me.colGL_ACC_CCY.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_CCY.Width = 237
        '
        'colExchange_Rate
        '
        Me.colExchange_Rate.Caption = "Exchange Rate"
        Me.colExchange_Rate.FieldName = "Exchange_Rate"
        Me.colExchange_Rate.Name = "colExchange_Rate"
        Me.colExchange_Rate.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate.Width = 237
        '
        'colGL_ACC_ClosingBalanceAmountEUR
        '
        Me.colGL_ACC_ClosingBalanceAmountEUR.Caption = "Closing Balance in EUR"
        Me.colGL_ACC_ClosingBalanceAmountEUR.FieldName = "GL_ACC_ClosingBalanceAmountEUR"
        Me.colGL_ACC_ClosingBalanceAmountEUR.Name = "colGL_ACC_ClosingBalanceAmountEUR"
        Me.colGL_ACC_ClosingBalanceAmountEUR.OptionsColumn.ReadOnly = True
        Me.colGL_ACC_ClosingBalanceAmountEUR.Width = 455
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.DIVERSE_GL_ITEMSBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 8
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.ImageIndex = 9
        GridLevelNode1.LevelTemplate = Me.MappedGLaccounts_BaseView
        GridLevelNode1.RelationName = "FK_DIVERSE_GL_ITEMS_MAP_ACC_DIVERSE_GL_ITEMS"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(24, 50)
        Me.GridControl1.MainView = Me.DIVERSE_GLitems_View
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEditGLITEM, Me.RepositoryItemGridLookUpEditGLACCOUNTS})
        Me.GridControl1.Size = New System.Drawing.Size(1283, 657)
        Me.GridControl1.TabIndex = 119
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DIVERSE_GLitems_View, Me.MappedGLaccounts_BaseView})
        '
        'DIVERSE_GL_ITEMSBindingSource
        '
        Me.DIVERSE_GL_ITEMSBindingSource.DataMember = "DIVERSE_GL_ITEMS"
        Me.DIVERSE_GL_ITEMSBindingSource.DataSource = Me.BalancesDataset
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
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "save_16x16.png")
        '
        'DIVERSE_GLitems_View
        '
        Me.DIVERSE_GLitems_View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.DIVERSE_GLitems_View.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.DIVERSE_GLitems_View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.DIVERSE_GLitems_View.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DIVERSE_GLitems_View.Appearance.FocusedRow.Options.UseForeColor = True
        Me.DIVERSE_GLitems_View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIdNr, Me.colGL_ITEM_NR, Me.colGL_ITEM_NAME})
        Me.DIVERSE_GLitems_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.DIVERSE_GLitems_View.GridControl = Me.GridControl1
        Me.DIVERSE_GLitems_View.Images = Me.ImageCollection1
        Me.DIVERSE_GLitems_View.Name = "DIVERSE_GLitems_View"
        Me.DIVERSE_GLitems_View.NewItemRowText = "Add new General Ledger for Mapping"
        Me.DIVERSE_GLitems_View.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DIVERSE_GLitems_View.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DIVERSE_GLitems_View.OptionsBehavior.AllowIncrementalSearch = True
        Me.DIVERSE_GLitems_View.OptionsBehavior.AutoExpandAllGroups = True
        Me.DIVERSE_GLitems_View.OptionsDetail.AllowExpandEmptyDetails = True
        Me.DIVERSE_GLitems_View.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.DIVERSE_GLitems_View.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.DIVERSE_GLitems_View.OptionsFind.AlwaysVisible = True
        Me.DIVERSE_GLitems_View.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.DIVERSE_GLitems_View.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.DIVERSE_GLitems_View.OptionsNavigation.AutoFocusNewRow = True
        Me.DIVERSE_GLitems_View.OptionsPrint.ExpandAllDetails = True
        Me.DIVERSE_GLitems_View.OptionsPrint.PrintDetails = True
        Me.DIVERSE_GLitems_View.OptionsPrint.PrintFilterInfo = True
        Me.DIVERSE_GLitems_View.OptionsPrint.PrintPreview = True
        Me.DIVERSE_GLitems_View.OptionsView.ColumnAutoWidth = False
        Me.DIVERSE_GLitems_View.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.DIVERSE_GLitems_View.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.DIVERSE_GLitems_View.OptionsView.ShowAutoFilterRow = True
        Me.DIVERSE_GLitems_View.OptionsView.ShowChildrenInGroupPanel = True
        Me.DIVERSE_GLitems_View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.DIVERSE_GLitems_View.OptionsView.ShowFooter = True
        Me.DIVERSE_GLitems_View.OptionsView.ShowGroupedColumns = True
        '
        'colIdNr
        '
        Me.colIdNr.FieldName = "IdNr"
        Me.colIdNr.Name = "colIdNr"
        Me.colIdNr.OptionsColumn.AllowEdit = False
        Me.colIdNr.OptionsColumn.ReadOnly = True
        '
        'colGL_ITEM_NR
        '
        Me.colGL_ITEM_NR.Caption = "General Ledger Nr."
        Me.colGL_ITEM_NR.ColumnEdit = Me.RepositoryItemTextEditGLITEM
        Me.colGL_ITEM_NR.FieldName = "GL_ITEM_NR"
        Me.colGL_ITEM_NR.Name = "colGL_ITEM_NR"
        Me.colGL_ITEM_NR.OptionsColumn.ReadOnly = True
        Me.colGL_ITEM_NR.Visible = True
        Me.colGL_ITEM_NR.VisibleIndex = 0
        Me.colGL_ITEM_NR.Width = 108
        '
        'RepositoryItemTextEditGLITEM
        '
        Me.RepositoryItemTextEditGLITEM.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEditGLITEM.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditGLITEM.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditGLITEM.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditGLITEM.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEditGLITEM.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEditGLITEM.AutoHeight = False
        Me.RepositoryItemTextEditGLITEM.Mask.EditMask = "d"
        Me.RepositoryItemTextEditGLITEM.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEditGLITEM.MaxLength = 4
        Me.RepositoryItemTextEditGLITEM.Name = "RepositoryItemTextEditGLITEM"
        Me.RepositoryItemTextEditGLITEM.NullValuePrompt = "Add General Ledger Nr."
        Me.RepositoryItemTextEditGLITEM.NullValuePromptShowForEmptyValue = True
        '
        'colGL_ITEM_NAME
        '
        Me.colGL_ITEM_NAME.Caption = "General Ledger Name"
        Me.colGL_ITEM_NAME.FieldName = "GL_ITEM_NAME"
        Me.colGL_ITEM_NAME.Name = "colGL_ITEM_NAME"
        Me.colGL_ITEM_NAME.OptionsColumn.ReadOnly = True
        Me.colGL_ITEM_NAME.Visible = True
        Me.colGL_ITEM_NAME.VisibleIndex = 1
        Me.colGL_ITEM_NAME.Width = 570
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
        'DIVERSE_GL_ITEMSTableAdapter
        '
        Me.DIVERSE_GL_ITEMSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_VOSTRO_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.DIVERSE_GL_ITEMSTableAdapter = Me.DIVERSE_GL_ITEMSTableAdapter
        Me.TableAdapterManager.DIVERSE_MAPPINGTableAdapter = Me.DIVERSE_MAPPINGTableAdapter
        Me.TableAdapterManager.DIVERSE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Me.GL_ACCOUNTSTableAdapter
        Me.TableAdapterManager.NOSTRO_BALANCESTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_GL_ITEMSTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_MAPPINGTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.SUSPENCE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.SWIFT_ACC_STATEMENTSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DIVERSE_MAPPINGTableAdapter
        '
        Me.DIVERSE_MAPPINGTableAdapter.ClearBeforeFill = True
        '
        'GL_ACCOUNTSTableAdapter
        '
        Me.GL_ACCOUNTSTableAdapter.ClearBeforeFill = True
        '
        'DIVERSE_MAPPINGBindingSource
        '
        Me.DIVERSE_MAPPINGBindingSource.DataMember = "FK_DIVERSE_GL_ITEMS_MAP_ACC_DIVERSE_GL_ITEMS"
        Me.DIVERSE_MAPPINGBindingSource.DataSource = Me.DIVERSE_GL_ITEMSBindingSource
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1331, 731)
        Me.LayoutControl1.TabIndex = 119
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(150, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 10
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1231, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(76, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1331, 731)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1311, 711)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1207, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(80, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(154, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1053, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(154, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1287, 661)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'MappingDiverseGL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 731)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MappingDiverseGL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mapping -Diverse General Ledger"
        CType(Me.MappedGLaccounts_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEditGLACCOUNTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GL_ACCOUNTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIVERSE_GL_ITEMSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIVERSE_GLitems_View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditGLITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIVERSE_MAPPINGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BalancesDataset As PS_TOOL_DX.BalancesDataset
    Friend WithEvents DIVERSE_GL_ITEMSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DIVERSE_GL_ITEMSTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.DIVERSE_GL_ITEMSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager
    Friend WithEvents DIVERSE_MAPPINGTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.DIVERSE_MAPPINGTableAdapter
    Friend WithEvents DIVERSE_MAPPINGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GL_ACCOUNTSTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.GL_ACCOUNTSTableAdapter
    Friend WithEvents GL_ACCOUNTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents MappedGLaccounts_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colIdNr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemGridLookUpEditGLACCOUNTS As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_Range_From As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_Range_Till As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_ClosingBalanceDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_ClosingBalanceAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ITEM_Mapped As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_CCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchange_Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_ClosingBalanceAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DIVERSE_GLitems_View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEditGLITEM As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colIdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ITEM_NR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ITEM_NAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
