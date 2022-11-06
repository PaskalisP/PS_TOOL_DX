<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ZvStatistikParameter
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZvStatistikParameter))
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.ZVSTAT_Parameters_from2014BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZvStatistik_Dataset = New PS_TOOL_DX.ZvStatistik_DataSet()
        Me.ZVSTAT_Meldeschemas_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLfdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MemoEdit_Default = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colPositionNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandkontext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Landcontext_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colLandCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LandCode_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colPayCardSystem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PayCardSystem_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colSumPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumPosition_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colAnzahl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AnzahlWert_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colWert = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionSQLcommand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionInfo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PositionStatus_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colZVSTA_Schema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PopupContainerEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.popupContainerControl = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BbiSqlReload = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddNewZvParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiSave = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiPrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.Meldeschemas_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ZvSta_Meldeschema_Param_BarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.NewMeldeschemaFromCurrent_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.NewMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.RenameCurrentMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.DeleteCurrentMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.FindAndReplaceText_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameterCurrentPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameterNextPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoNextPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiChangeSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDeactivateFormNr = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiActivateFormNr = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup7 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
        Me.RepositoryItemRichEditFontSizeEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit()
        Me.DisplayForReviewModeComboBox1 = New DevExpress.XtraRichEdit.UI.DisplayForReviewModeComboBox()
        Me.RepositoryItemBorderLineStyle1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle()
        Me.RepositoryItemBorderLineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight()
        Me.RepositoryItemFloatingObjectOutlineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight()
        Me.ChangeParameterPosition_SpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RichTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit()
        Me.MemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LandCode2021_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SqlParameterGridviewPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ZVSTAT_Parameters_from2014TableAdapter = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.ZVSTAT_Parameters_from2014TableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_Parameters_from2014BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_Meldeschemas_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit_Default, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Landcontext_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandCode_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PositionStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl.SuspendLayout()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEditView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisplayForReviewModeComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChangeParameterPosition_SpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RichTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AutoHeight = False
        Me.RepositoryItemMemoExEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit3.Name = "RepositoryItemMemoExEdit3"
        Me.RepositoryItemMemoExEdit3.PopupFormSize = New System.Drawing.Size(514, 260)
        Me.RepositoryItemMemoExEdit3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.ZVSTAT_Parameters_from2014BindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.ImageIndex = 4
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(12, 12)
        Me.GridControl3.MainView = Me.ZVSTAT_Meldeschemas_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3, Me.RepositoryItemSpinEdit1, Me.Landcontext_ImageComboBox, Me.RepositoryItemDateEdit1, Me.PopupContainerEdit2, Me.RichTextEdit2, Me.MemoEdit1, Me.LandCode_ImageComboBox, Me.AnzahlWert_RepositoryItemImageComboBox, Me.LandCode2021_ImageComboBox, Me.PayCardSystem_ImageComboBox, Me.MemoEdit_Default, Me.SumPosition_ImageComboBox, Me.PositionStatus_RepositoryItemImageComboBox})
        Me.GridControl3.Size = New System.Drawing.Size(1412, 492)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ZVSTAT_Meldeschemas_Gridview})
        '
        'ZVSTAT_Parameters_from2014BindingSource
        '
        Me.ZVSTAT_Parameters_from2014BindingSource.DataMember = "ZVSTAT_Parameters_from2014"
        Me.ZVSTAT_Parameters_from2014BindingSource.DataSource = Me.ZvStatistik_Dataset
        '
        'ZvStatistik_Dataset
        '
        Me.ZvStatistik_Dataset.DataSetName = "ZvStatistik_Dataset"
        Me.ZvStatistik_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZVSTAT_Meldeschemas_Gridview
        '
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.GroupButton.ForeColor = System.Drawing.Color.Navy
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.GroupButton.Options.UseForeColor = True
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.ZVSTAT_Meldeschemas_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.ZVSTAT_Meldeschemas_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colLfdNr, Me.colFormNr, Me.colFormName, Me.colPositionNr, Me.colPositionName, Me.colLandkontext, Me.colLandCode, Me.colPayCardSystem, Me.colSumPosition, Me.colAnzahl, Me.colWert, Me.colPositionSQLcommand, Me.colPositionInfo, Me.colPositionStatus, Me.colZVSTA_Schema, Me.colLastAction, Me.colLastUpdateDate, Me.colLastUpdateUser})
        Me.ZVSTAT_Meldeschemas_Gridview.DetailHeight = 303
        Me.ZVSTAT_Meldeschemas_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ZVSTAT_Meldeschemas_Gridview.GridControl = Me.GridControl3
        Me.ZVSTAT_Meldeschemas_Gridview.GroupCount = 1
        Me.ZVSTAT_Meldeschemas_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "FormName", Nothing, "")})
        Me.ZVSTAT_Meldeschemas_Gridview.Name = "ZVSTAT_Meldeschemas_Gridview"
        Me.ZVSTAT_Meldeschemas_Gridview.NewItemRowText = "Add new ZV Statistik Parameter"
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsDetail.AllowExpandEmptyDetails = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsDetail.AutoZoomDetail = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsFind.AlwaysVisible = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsFind.SearchInPreview = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsNavigation.AutoFocusNewRow = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsSelection.MultiSelect = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.AutoCalcPreviewLineCount = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ColumnAutoWidth = False
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.RowAutoHeight = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowChildrenInGroupPanel = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowFooter = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowGroupedColumns = True
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowGroupPanel = False
        Me.ZVSTAT_Meldeschemas_Gridview.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        Me.ZVSTAT_Meldeschemas_Gridview.PreviewFieldName = "PositionSQLcommand"
        Me.ZVSTAT_Meldeschemas_Gridview.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridMergedColumnSortInfo(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFormNr, Me.colFormName}, New DevExpress.Data.ColumnSortOrder() {DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Data.ColumnSortOrder.Ascending})})
        Me.ZVSTAT_Meldeschemas_Gridview.ViewCaption = "ZV Statistik Parameter"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 17
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        Me.colID.Width = 64
        '
        'colLfdNr
        '
        Me.colLfdNr.FieldName = "LfdNr"
        Me.colLfdNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLfdNr.MinWidth = 17
        Me.colLfdNr.Name = "colLfdNr"
        Me.colLfdNr.OptionsColumn.AllowEdit = False
        Me.colLfdNr.OptionsColumn.ReadOnly = True
        Me.colLfdNr.Visible = True
        Me.colLfdNr.VisibleIndex = 0
        Me.colLfdNr.Width = 74
        '
        'colFormNr
        '
        Me.colFormNr.AppearanceCell.Options.UseTextOptions = True
        Me.colFormNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFormNr.FieldName = "FormNr"
        Me.colFormNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colFormNr.MinWidth = 17
        Me.colFormNr.Name = "colFormNr"
        Me.colFormNr.OptionsEditForm.ColumnSpan = 2
        Me.colFormNr.OptionsEditForm.UseEditorColRowSpan = False
        Me.colFormNr.Visible = True
        Me.colFormNr.VisibleIndex = 1
        Me.colFormNr.Width = 81
        '
        'colFormName
        '
        Me.colFormName.ColumnEdit = Me.MemoEdit_Default
        Me.colFormName.FieldName = "FormName"
        Me.colFormName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colFormName.MinWidth = 17
        Me.colFormName.Name = "colFormName"
        Me.colFormName.OptionsEditForm.ColumnSpan = 3
        Me.colFormName.OptionsEditForm.StartNewRow = True
        Me.colFormName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colFormName.Width = 248
        '
        'MemoEdit_Default
        '
        Me.MemoEdit_Default.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit_Default.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit_Default.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit_Default.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit_Default.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit_Default.Name = "MemoEdit_Default"
        '
        'colPositionNr
        '
        Me.colPositionNr.FieldName = "PositionNr"
        Me.colPositionNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colPositionNr.MinWidth = 17
        Me.colPositionNr.Name = "colPositionNr"
        Me.colPositionNr.OptionsEditForm.ColumnSpan = 2
        Me.colPositionNr.OptionsEditForm.StartNewRow = True
        Me.colPositionNr.OptionsEditForm.UseEditorColRowSpan = False
        Me.colPositionNr.Visible = True
        Me.colPositionNr.VisibleIndex = 2
        Me.colPositionNr.Width = 120
        '
        'colPositionName
        '
        Me.colPositionName.ColumnEdit = Me.MemoEdit_Default
        Me.colPositionName.FieldName = "PositionName"
        Me.colPositionName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colPositionName.MinWidth = 17
        Me.colPositionName.Name = "colPositionName"
        Me.colPositionName.OptionsEditForm.ColumnSpan = 3
        Me.colPositionName.OptionsEditForm.StartNewRow = True
        Me.colPositionName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colPositionName.Visible = True
        Me.colPositionName.VisibleIndex = 3
        Me.colPositionName.Width = 312
        '
        'colLandkontext
        '
        Me.colLandkontext.AppearanceCell.Options.UseTextOptions = True
        Me.colLandkontext.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLandkontext.ColumnEdit = Me.Landcontext_ImageComboBox
        Me.colLandkontext.FieldName = "Landkontext"
        Me.colLandkontext.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLandkontext.MinWidth = 17
        Me.colLandkontext.Name = "colLandkontext"
        Me.colLandkontext.OptionsEditForm.StartNewRow = True
        Me.colLandkontext.Visible = True
        Me.colLandkontext.VisibleIndex = 4
        Me.colLandkontext.Width = 111
        '
        'Landcontext_ImageComboBox
        '
        Me.Landcontext_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Landcontext_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Landcontext_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Landcontext_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.Landcontext_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.Landcontext_ImageComboBox.AutoHeight = False
        Me.Landcontext_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Landcontext_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Not relevant", "N", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("TO - NACH", "TO", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FROM - VON", "FROM", 1)})
        Me.Landcontext_ImageComboBox.Name = "Landcontext_ImageComboBox"
        Me.Landcontext_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "pagenext_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "pageprev_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "Germany.png")
        Me.ImageCollection1.Images.SetKeyName(3, "bolocalization_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(4, "EU Icon.jpg")
        Me.ImageCollection1.Images.SetKeyName(5, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(6, "summary_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(7, "country_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(8, "apply_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(9, "delete_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(10, "EWG.jpg")
        Me.ImageCollection1.Images.SetKeyName(11, "COUNTRIES.jpg")
        Me.ImageCollection1.Images.SetKeyName(12, "formatnumbercurrency_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(13, "currency_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(14, "credit-card.png")
        Me.ImageCollection1.Images.SetKeyName(15, "boorderitem_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(16, "apply_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "cancel_16x16.png")
        '
        'colLandCode
        '
        Me.colLandCode.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLandCode.AppearanceHeader.Options.UseTextOptions = True
        Me.colLandCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLandCode.ColumnEdit = Me.LandCode_ImageComboBox
        Me.colLandCode.FieldName = "LandCode"
        Me.colLandCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLandCode.MinWidth = 17
        Me.colLandCode.Name = "colLandCode"
        Me.colLandCode.Visible = True
        Me.colLandCode.VisibleIndex = 5
        Me.colLandCode.Width = 232
        '
        'LandCode_ImageComboBox
        '
        Me.LandCode_ImageComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.LandCode_ImageComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.LandCode_ImageComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LandCode_ImageComboBox.Appearance.Options.UseBackColor = True
        Me.LandCode_ImageComboBox.Appearance.Options.UseForeColor = True
        Me.LandCode_ImageComboBox.AutoHeight = False
        Me.LandCode_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LandCode_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DE - INLAND", "DE", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("A1 - INSGESAMT", "A1", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("U9 - AUSSERHALB EU", "U9", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EU - INNERHALB", "EU", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Z9 - AUSLAND", "Z9", 7)})
        Me.LandCode_ImageComboBox.Name = "LandCode_ImageComboBox"
        Me.LandCode_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colPayCardSystem
        '
        Me.colPayCardSystem.Caption = "Payment-Card System"
        Me.colPayCardSystem.ColumnEdit = Me.PayCardSystem_ImageComboBox
        Me.colPayCardSystem.FieldName = "PayCardSystem"
        Me.colPayCardSystem.Name = "colPayCardSystem"
        Me.colPayCardSystem.Visible = True
        Me.colPayCardSystem.VisibleIndex = 6
        Me.colPayCardSystem.Width = 133
        '
        'PayCardSystem_ImageComboBox
        '
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.PayCardSystem_ImageComboBox.AutoHeight = False
        Me.PayCardSystem_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PayCardSystem_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Not Relevant", "N", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PAYMENTS ALL", "PAY_ALL", 12), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DIRECT DEBITS ALL", "DD_ALL", 13), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CARDS ALL", "CARDS_ALL", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MCC CODES", "MCC_CODES", 15)})
        Me.PayCardSystem_ImageComboBox.Name = "PayCardSystem_ImageComboBox"
        Me.PayCardSystem_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colSumPosition
        '
        Me.colSumPosition.AppearanceCell.Options.UseTextOptions = True
        Me.colSumPosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSumPosition.AppearanceHeader.Options.UseTextOptions = True
        Me.colSumPosition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSumPosition.Caption = "Summen Position"
        Me.colSumPosition.ColumnEdit = Me.SumPosition_ImageComboBox
        Me.colSumPosition.FieldName = "SumPosition"
        Me.colSumPosition.MinWidth = 17
        Me.colSumPosition.Name = "colSumPosition"
        Me.colSumPosition.Visible = True
        Me.colSumPosition.VisibleIndex = 7
        Me.colSumPosition.Width = 147
        '
        'SumPosition_ImageComboBox
        '
        Me.SumPosition_ImageComboBox.AutoHeight = False
        Me.SumPosition_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SumPosition_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FIRST SUM", "1", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - INTERMEDIARY SUM", "2", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FINAL SUM", "3", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.SumPosition_ImageComboBox.Name = "SumPosition_ImageComboBox"
        Me.SumPosition_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colAnzahl
        '
        Me.colAnzahl.AppearanceCell.Options.UseTextOptions = True
        Me.colAnzahl.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnzahl.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnzahl.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnzahl.Caption = "Anzahl erforderlich"
        Me.colAnzahl.ColumnEdit = Me.AnzahlWert_RepositoryItemImageComboBox
        Me.colAnzahl.FieldName = "Anzahl"
        Me.colAnzahl.MinWidth = 17
        Me.colAnzahl.Name = "colAnzahl"
        Me.colAnzahl.OptionsEditForm.StartNewRow = True
        Me.colAnzahl.Visible = True
        Me.colAnzahl.VisibleIndex = 8
        Me.colAnzahl.Width = 86
        '
        'AnzahlWert_RepositoryItemImageComboBox
        '
        Me.AnzahlWert_RepositoryItemImageComboBox.AutoHeight = False
        Me.AnzahlWert_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Name = "AnzahlWert_RepositoryItemImageComboBox"
        Me.AnzahlWert_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colWert
        '
        Me.colWert.AppearanceCell.Options.UseTextOptions = True
        Me.colWert.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colWert.AppearanceHeader.Options.UseTextOptions = True
        Me.colWert.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colWert.Caption = "Wert erforderlich"
        Me.colWert.ColumnEdit = Me.AnzahlWert_RepositoryItemImageComboBox
        Me.colWert.FieldName = "Wert"
        Me.colWert.MinWidth = 17
        Me.colWert.Name = "colWert"
        Me.colWert.Visible = True
        Me.colWert.VisibleIndex = 9
        Me.colWert.Width = 85
        '
        'colPositionSQLcommand
        '
        Me.colPositionSQLcommand.AppearanceHeader.Options.UseTextOptions = True
        Me.colPositionSQLcommand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPositionSQLcommand.Caption = "SQL Command for ZVSTA Position"
        Me.colPositionSQLcommand.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colPositionSQLcommand.FieldName = "PositionSQLcommand"
        Me.colPositionSQLcommand.MinWidth = 17
        Me.colPositionSQLcommand.Name = "colPositionSQLcommand"
        Me.colPositionSQLcommand.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colPositionSQLcommand.Visible = True
        Me.colPositionSQLcommand.VisibleIndex = 10
        Me.colPositionSQLcommand.Width = 83
        '
        'colPositionInfo
        '
        Me.colPositionInfo.AppearanceHeader.Options.UseTextOptions = True
        Me.colPositionInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPositionInfo.Caption = "Position Info"
        Me.colPositionInfo.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colPositionInfo.FieldName = "PositionInfo"
        Me.colPositionInfo.Name = "colPositionInfo"
        Me.colPositionInfo.Visible = True
        Me.colPositionInfo.VisibleIndex = 12
        '
        'colPositionStatus
        '
        Me.colPositionStatus.Caption = "Position Status"
        Me.colPositionStatus.ColumnEdit = Me.PositionStatus_RepositoryItemImageComboBox
        Me.colPositionStatus.FieldName = "PositionStatus"
        Me.colPositionStatus.Name = "colPositionStatus"
        Me.colPositionStatus.Visible = True
        Me.colPositionStatus.VisibleIndex = 11
        '
        'PositionStatus_RepositoryItemImageComboBox
        '
        Me.PositionStatus_RepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.PositionStatus_RepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.PositionStatus_RepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.PositionStatus_RepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.PositionStatus_RepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.PositionStatus_RepositoryItemImageComboBox.AutoHeight = False
        Me.PositionStatus_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PositionStatus_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 16), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEACTIVATED", "N", 17)})
        Me.PositionStatus_RepositoryItemImageComboBox.Name = "PositionStatus_RepositoryItemImageComboBox"
        Me.PositionStatus_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colZVSTA_Schema
        '
        Me.colZVSTA_Schema.FieldName = "ZVSTA_Schema"
        Me.colZVSTA_Schema.MinWidth = 17
        Me.colZVSTA_Schema.Name = "colZVSTA_Schema"
        Me.colZVSTA_Schema.OptionsColumn.ReadOnly = True
        Me.colZVSTA_Schema.Width = 64
        '
        'colLastAction
        '
        Me.colLastAction.AppearanceCell.Options.UseTextOptions = True
        Me.colLastAction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastAction.FieldName = "LastAction"
        Me.colLastAction.MinWidth = 17
        Me.colLastAction.Name = "colLastAction"
        Me.colLastAction.OptionsColumn.ReadOnly = True
        Me.colLastAction.Width = 64
        '
        'colLastUpdateDate
        '
        Me.colLastUpdateDate.AppearanceCell.Options.UseTextOptions = True
        Me.colLastUpdateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastUpdateDate.DisplayFormat.FormatString = "d"
        Me.colLastUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLastUpdateDate.FieldName = "LastUpdateDate"
        Me.colLastUpdateDate.MinWidth = 17
        Me.colLastUpdateDate.Name = "colLastUpdateDate"
        Me.colLastUpdateDate.OptionsColumn.ReadOnly = True
        Me.colLastUpdateDate.Width = 64
        '
        'colLastUpdateUser
        '
        Me.colLastUpdateUser.AppearanceCell.Options.UseTextOptions = True
        Me.colLastUpdateUser.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastUpdateUser.FieldName = "LastUpdateUser"
        Me.colLastUpdateUser.MinWidth = 17
        Me.colLastUpdateUser.Name = "colLastUpdateUser"
        Me.colLastUpdateUser.OptionsColumn.ReadOnly = True
        Me.colLastUpdateUser.Width = 64
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Mask.BeepOnError = True
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "[1-9]{1,1}[0-9]{0,50}"
        Me.RepositoryItemSpinEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'PopupContainerEdit2
        '
        Me.PopupContainerEdit2.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupContainerEdit2.Appearance.Options.UseFont = True
        Me.PopupContainerEdit2.AutoHeight = False
        Me.PopupContainerEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit2.Name = "PopupContainerEdit2"
        Me.PopupContainerEdit2.PopupControl = Me.popupContainerControl
        '
        'popupContainerControl
        '
        Me.popupContainerControl.Controls.Add(Me.RichEditControl1)
        Me.popupContainerControl.Location = New System.Drawing.Point(1034, 40)
        Me.popupContainerControl.Name = "popupContainerControl"
        Me.popupContainerControl.Size = New System.Drawing.Size(162, 38)
        Me.popupContainerControl.TabIndex = 10
        '
        'RichEditControl1
        '
        Me.RichEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl1.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl1.Appearance.Text.Options.UseFont = True
        Me.RichEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl1.Location = New System.Drawing.Point(0, 0)
        Me.RichEditControl1.MenuManager = Me.RibbonControl
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl1.TabIndex = 2
        '
        'RibbonControl
        '
        Me.RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.BbiSqlReload, Me.BbiAddNewZvParameter, Me.BbiSave, Me.BbiDelete, Me.BbiPrintExport, Me.BbiClose, Me.BbiDuplicateSQLParameter, Me.BbiAddSQLtoPosition, Me.Meldeschemas_BarEditItem, Me.ZvSta_Meldeschema_Param_BarSubItem, Me.BbiDuplicateSQLParameterCurrentPosition, Me.BbiDuplicateSQLParameterNextPosition, Me.BbiAddSQLtoNextPosition, Me.BarSubItem1, Me.NewMeldeschemaFromCurrent_btn, Me.NewMeldeschema_btn, Me.RenameCurrentMeldeschema_btn, Me.DeleteCurrentMeldeschema_btn, Me.BbiChangeSQLtoPosition, Me.FindAndReplaceText_bbi, Me.BbiDeactivateFormNr, Me.BbiActivateFormNr})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 295
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1, Me.Meldeschemas_RepositoryItemSearchLookUpEdit, Me.RepositoryItemFontEdit1, Me.RepositoryItemRichEditFontSizeEdit1, Me.DisplayForReviewModeComboBox1, Me.RepositoryItemBorderLineStyle1, Me.RepositoryItemBorderLineWeight1, Me.RepositoryItemFloatingObjectOutlineWeight1, Me.ChangeParameterPosition_SpinEdit})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowSearchItem = True
        Me.RibbonControl.Size = New System.Drawing.Size(1436, 94)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BbiSqlReload
        '
        Me.BbiSqlReload.Caption = "Reload"
        Me.BbiSqlReload.Id = 1
        Me.BbiSqlReload.ImageOptions.SvgImage = CType(resources.GetObject("BbiSqlReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiSqlReload.Name = "BbiSqlReload"
        '
        'BbiAddNewZvParameter
        '
        Me.BbiAddNewZvParameter.Caption = "Add new ZV Statistik Parameter Position"
        Me.BbiAddNewZvParameter.Id = 2
        Me.BbiAddNewZvParameter.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddNewZvParameter.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddNewZvParameter.Name = "BbiAddNewZvParameter"
        '
        'BbiSave
        '
        Me.BbiSave.Caption = "Save"
        Me.BbiSave.Id = 3
        Me.BbiSave.ImageOptions.ImageUri.Uri = "Save"
        Me.BbiSave.Name = "BbiSave"
        '
        'BbiDelete
        '
        Me.BbiDelete.Caption = "Delete Parameter Position"
        Me.BbiDelete.Id = 4
        Me.BbiDelete.ImageOptions.ImageUri.Uri = "Cancel"
        Me.BbiDelete.ImageOptions.SvgImage = CType(resources.GetObject("BbiDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiDelete.Name = "BbiDelete"
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
        Me.BbiDuplicateSQLParameter.Caption = "Duplicate ZV Statistic Parameter (New Row)"
        Me.BbiDuplicateSQLParameter.Id = 2
        Me.BbiDuplicateSQLParameter.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.Name = "BbiDuplicateSQLParameter"
        '
        'BbiAddSQLtoPosition
        '
        Me.BbiAddSQLtoPosition.Caption = "Add new ZV Statistic Parameter to current Position"
        Me.BbiAddSQLtoPosition.Id = 3
        Me.BbiAddSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddSQLtoPosition.Name = "BbiAddSQLtoPosition"
        '
        'Meldeschemas_BarEditItem
        '
        Me.Meldeschemas_BarEditItem.Caption = "Meldeschema"
        Me.Meldeschemas_BarEditItem.Edit = Me.Meldeschemas_RepositoryItemSearchLookUpEdit
        Me.Meldeschemas_BarEditItem.EditWidth = 120
        Me.Meldeschemas_BarEditItem.Id = 4
        Me.Meldeschemas_BarEditItem.Name = "Meldeschemas_BarEditItem"
        '
        'Meldeschemas_RepositoryItemSearchLookUpEdit
        '
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.AutoHeight = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Name = "Meldeschemas_RepositoryItemSearchLookUpEdit"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.NullText = ""
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.PopupView = Me.Meldeschemas_RepositoryItemSearchLookUpEditView
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ShowClearButton = False
        '
        'Meldeschemas_RepositoryItemSearchLookUpEditView
        '
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.Name = "Meldeschemas_RepositoryItemSearchLookUpEditView"
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.OptionsView.ShowGroupPanel = False
        '
        'ZvSta_Meldeschema_Param_BarSubItem
        '
        Me.ZvSta_Meldeschema_Param_BarSubItem.Caption = "Meldeschema Configurations"
        Me.ZvSta_Meldeschema_Param_BarSubItem.Id = 281
        Me.ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.Image = CType(resources.GetObject("ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.LargeImage = CType(resources.GetObject("ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZvSta_Meldeschema_Param_BarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.RenameCurrentMeldeschema_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteCurrentMeldeschema_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.FindAndReplaceText_bbi, True)})
        Me.ZvSta_Meldeschema_Param_BarSubItem.Name = "ZvSta_Meldeschema_Param_BarSubItem"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Add new ZV Statistic Meldeschema"
        Me.BarSubItem1.Id = 285
        Me.BarSubItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarSubItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.NewMeldeschemaFromCurrent_btn), New DevExpress.XtraBars.LinkPersistInfo(Me.NewMeldeschema_btn, True)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'NewMeldeschemaFromCurrent_btn
        '
        Me.NewMeldeschemaFromCurrent_btn.Caption = "New Meldeschema based on current"
        Me.NewMeldeschemaFromCurrent_btn.Id = 286
        Me.NewMeldeschemaFromCurrent_btn.ImageOptions.SvgImage = CType(resources.GetObject("NewMeldeschemaFromCurrent_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.NewMeldeschemaFromCurrent_btn.Name = "NewMeldeschemaFromCurrent_btn"
        '
        'NewMeldeschema_btn
        '
        Me.NewMeldeschema_btn.Caption = "New Meldeschema"
        Me.NewMeldeschema_btn.Id = 287
        Me.NewMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("NewMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.NewMeldeschema_btn.Name = "NewMeldeschema_btn"
        '
        'RenameCurrentMeldeschema_btn
        '
        Me.RenameCurrentMeldeschema_btn.Caption = "Rename current Meldeschema"
        Me.RenameCurrentMeldeschema_btn.Id = 288
        Me.RenameCurrentMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("RenameCurrentMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.RenameCurrentMeldeschema_btn.Name = "RenameCurrentMeldeschema_btn"
        '
        'DeleteCurrentMeldeschema_btn
        '
        Me.DeleteCurrentMeldeschema_btn.Caption = "Delete current Meldeschema"
        Me.DeleteCurrentMeldeschema_btn.Id = 289
        Me.DeleteCurrentMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("DeleteCurrentMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.DeleteCurrentMeldeschema_btn.Name = "DeleteCurrentMeldeschema_btn"
        '
        'FindAndReplaceText_bbi
        '
        Me.FindAndReplaceText_bbi.Caption = "Find and Replace"
        Me.FindAndReplaceText_bbi.Id = 292
        Me.FindAndReplaceText_bbi.ImageOptions.Image = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.ImageOptions.LargeImage = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.Name = "FindAndReplaceText_bbi"
        '
        'BbiDuplicateSQLParameterCurrentPosition
        '
        Me.BbiDuplicateSQLParameterCurrentPosition.Caption = "Duplicate ZV Statistic Parameter (Current Position)"
        Me.BbiDuplicateSQLParameterCurrentPosition.Id = 282
        Me.BbiDuplicateSQLParameterCurrentPosition.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameterCurrentPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterCurrentPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameterCurrentPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterCurrentPosition.Name = "BbiDuplicateSQLParameterCurrentPosition"
        '
        'BbiDuplicateSQLParameterNextPosition
        '
        Me.BbiDuplicateSQLParameterNextPosition.Caption = "Duplicate ZV Statistic Parameter (Next Position)"
        Me.BbiDuplicateSQLParameterNextPosition.Id = 283
        Me.BbiDuplicateSQLParameterNextPosition.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameterNextPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterNextPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameterNextPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterNextPosition.Name = "BbiDuplicateSQLParameterNextPosition"
        '
        'BbiAddSQLtoNextPosition
        '
        Me.BbiAddSQLtoNextPosition.Caption = "Add new ZV Statistic Parameter to next Position"
        Me.BbiAddSQLtoNextPosition.Id = 284
        Me.BbiAddSQLtoNextPosition.ImageOptions.Image = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.Name = "BbiAddSQLtoNextPosition"
        '
        'BbiChangeSQLtoPosition
        '
        Me.BbiChangeSQLtoPosition.Caption = "Change ZV Parameter Position"
        Me.BbiChangeSQLtoPosition.Id = 291
        Me.BbiChangeSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiChangeSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiChangeSQLtoPosition.Name = "BbiChangeSQLtoPosition"
        '
        'BbiDeactivateFormNr
        '
        Me.BbiDeactivateFormNr.Caption = "Deactivate ZV Statistic FormNr"
        Me.BbiDeactivateFormNr.Id = 293
        Me.BbiDeactivateFormNr.ImageOptions.SvgImage = CType(resources.GetObject("BbiDeactivateFormNr.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiDeactivateFormNr.Name = "BbiDeactivateFormNr"
        '
        'BbiActivateFormNr
        '
        Me.BbiActivateFormNr.Caption = "Activate ZV Statistic FormNr"
        Me.BbiActivateFormNr.Id = 294
        Me.BbiActivateFormNr.ImageOptions.SvgImage = CType(resources.GetObject("BbiActivateFormNr.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiActivateFormNr.Name = "BbiActivateFormNr"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup4, Me.RibbonPageGroup5, Me.RibbonPageGroup6, Me.RibbonPageGroup1, Me.RibbonPageGroup7})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.Meldeschemas_BarEditItem)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiSqlReload)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ZvSta_Meldeschema_Param_BarSubItem)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BbiAddNewZvParameter)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "RibbonPageGroup3"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BbiSave)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "RibbonPageGroup4"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BbiDelete)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "RibbonPageGroup5"
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
        'RibbonPageGroup7
        '
        Me.RibbonPageGroup7.Name = "RibbonPageGroup7"
        Me.RibbonPageGroup7.Text = "RibbonPageGroup7"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemFontEdit1
        '
        Me.RepositoryItemFontEdit1.AutoHeight = False
        Me.RepositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFontEdit1.Name = "RepositoryItemFontEdit1"
        '
        'RepositoryItemRichEditFontSizeEdit1
        '
        Me.RepositoryItemRichEditFontSizeEdit1.AutoHeight = False
        Me.RepositoryItemRichEditFontSizeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemRichEditFontSizeEdit1.Control = Me.RichEditControl1
        Me.RepositoryItemRichEditFontSizeEdit1.Name = "RepositoryItemRichEditFontSizeEdit1"
        '
        'DisplayForReviewModeComboBox1
        '
        Me.DisplayForReviewModeComboBox1.AutoHeight = False
        Me.DisplayForReviewModeComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisplayForReviewModeComboBox1.Name = "DisplayForReviewModeComboBox1"
        Me.DisplayForReviewModeComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemBorderLineStyle1
        '
        Me.RepositoryItemBorderLineStyle1.AutoHeight = False
        Me.RepositoryItemBorderLineStyle1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBorderLineStyle1.Control = Me.RichEditControl1
        Me.RepositoryItemBorderLineStyle1.Name = "RepositoryItemBorderLineStyle1"
        '
        'RepositoryItemBorderLineWeight1
        '
        Me.RepositoryItemBorderLineWeight1.AutoHeight = False
        Me.RepositoryItemBorderLineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBorderLineWeight1.Control = Me.RichEditControl1
        Me.RepositoryItemBorderLineWeight1.Name = "RepositoryItemBorderLineWeight1"
        '
        'RepositoryItemFloatingObjectOutlineWeight1
        '
        Me.RepositoryItemFloatingObjectOutlineWeight1.AutoHeight = False
        Me.RepositoryItemFloatingObjectOutlineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFloatingObjectOutlineWeight1.Control = Me.RichEditControl1
        Me.RepositoryItemFloatingObjectOutlineWeight1.Name = "RepositoryItemFloatingObjectOutlineWeight1"
        '
        'ChangeParameterPosition_SpinEdit
        '
        Me.ChangeParameterPosition_SpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ChangeParameterPosition_SpinEdit.AutoHeight = False
        Me.ChangeParameterPosition_SpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChangeParameterPosition_SpinEdit.Mask.EditMask = "[1-9]{1,10}"
        Me.ChangeParameterPosition_SpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.ChangeParameterPosition_SpinEdit.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.ChangeParameterPosition_SpinEdit.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ChangeParameterPosition_SpinEdit.Name = "ChangeParameterPosition_SpinEdit"
        Me.ChangeParameterPosition_SpinEdit.NullText = "Add new LfdNr"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 610)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1436, 22)
        '
        'RichTextEdit2
        '
        Me.RichTextEdit2.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextEdit2.Appearance.Options.UseFont = True
        Me.RichTextEdit2.Name = "RichTextEdit2"
        Me.RichTextEdit2.ShowCaretInReadOnly = False
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoEdit1.Appearance.Options.UseFont = True
        Me.MemoEdit1.Name = "MemoEdit1"
        '
        'LandCode2021_ImageComboBox
        '
        Me.LandCode2021_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LandCode2021_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LandCode2021_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LandCode2021_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.LandCode2021_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.LandCode2021_ImageComboBox.AutoHeight = False
        Me.LandCode2021_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LandCode2021_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DE - INLAND", "DE", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("W0 - INSGESAMT", "W0", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EU-EWG (SEPARAT)", "EU_EEA_SEPARAT", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("G1 - REST DER WELT (INSGESAMT)", "G1", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("G3 - EU-EWG (INSGESAMT)", "G3", 10), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JEDES LAND SEPARAT", "JEDES_LAND", 11)})
        Me.LandCode2021_ImageComboBox.Name = "LandCode2021_ImageComboBox"
        Me.LandCode2021_ImageComboBox.SmallImages = Me.ImageCollection1
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
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 650, 526)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1436, 516)
        Me.LayoutControl3.TabIndex = 4
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1436, 516)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1416, 496)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
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
        Me.PrintableComponentLink1.Component = Me.GridControl3
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'SqlParameterGridviewPopupMenu
        '
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiAddNewZvParameter)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDelete)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDuplicateSQLParameterCurrentPosition, True)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDuplicateSQLParameterNextPosition)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDuplicateSQLParameter)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiAddSQLtoPosition, True)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiAddSQLtoNextPosition)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiChangeSQLtoPosition)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDeactivateFormNr, True)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiActivateFormNr)
        Me.SqlParameterGridviewPopupMenu.Name = "SqlParameterGridviewPopupMenu"
        Me.SqlParameterGridviewPopupMenu.Ribbon = Me.RibbonControl
        '
        'ZVSTAT_Parameters_from2014TableAdapter
        '
        Me.ZVSTAT_Parameters_from2014TableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.ZVSTAT_Parameters_from2014TableAdapter = Me.ZVSTAT_Parameters_from2014TableAdapter
        Me.TableAdapterManager.ZVSTAT_Pay_Cards_ParametersTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_ProofingRules_ParameterTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_ReportingTableAdapter = Nothing
        '
        'ZvStatistikParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1436, 632)
        Me.Controls.Add(Me.popupContainerControl)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.ShowIcon = False
        Me.KeyPreview = True
        Me.Name = "ZvStatistikParameter"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "ZV Statistik - Meldeschemas Parameter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_Parameters_from2014BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_Meldeschemas_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit_Default, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Landcontext_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandCode_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PositionStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl.ResumeLayout(False)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEditView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisplayForReviewModeComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChangeParameterPosition_SpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RichTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemMemoExEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Landcontext_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZVSTAT_Meldeschemas_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    'Friend WithEvents EDP_DataSet As EDP_DataSet
    Friend WithEvents BbiSqlReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddNewZvParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiPrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents RichTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit
    Friend WithEvents PopupContainerEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Private WithEvents popupContainerControl As DevExpress.XtraEditors.PopupContainerControl
    Private WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BbiDuplicateSQLParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SqlParameterGridviewPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BbiAddSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZvStatistik_Dataset As ZvStatistik_Dataset
    Friend WithEvents Meldeschemas_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Meldeschemas_RepositoryItemSearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents Meldeschemas_RepositoryItemSearchLookUpEditView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ZVSTAT_Parameters_from2014BindingSource As BindingSource
    Friend WithEvents ZVSTAT_Parameters_from2014TableAdapter As ZvStatistik_DatasetTableAdapters.ZVSTAT_Parameters_from2014TableAdapter
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLfdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandkontext As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnzahl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWert As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionSQLcommand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZVSTA_Schema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TableAdapterManager As ZvStatistik_DatasetTableAdapters.TableAdapterManager
    Friend WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
    Friend WithEvents RepositoryItemRichEditFontSizeEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
    Friend WithEvents DisplayForReviewModeComboBox1 As DevExpress.XtraRichEdit.UI.DisplayForReviewModeComboBox
    Friend WithEvents RepositoryItemBorderLineStyle1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle
    Friend WithEvents RepositoryItemBorderLineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight
    Friend WithEvents RepositoryItemFloatingObjectOutlineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight
    Friend WithEvents colLastAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZvSta_Meldeschema_Param_BarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents RibbonPageGroup7 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BbiDuplicateSQLParameterCurrentPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDuplicateSQLParameterNextPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddSQLtoNextPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents NewMeldeschemaFromCurrent_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NewMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RenameCurrentMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DeleteCurrentMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ChangeParameterPosition_SpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents BbiChangeSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LandCode_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents AnzahlWert_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colSumPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LandCode2021_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colPayCardSystem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PayCardSystem_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents MemoEdit_Default As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents colPositionInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumPosition_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents FindAndReplaceText_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colPositionStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PositionStatus_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents BbiDeactivateFormNr As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiActivateFormNr As DevExpress.XtraBars.BarButtonItem
End Class
