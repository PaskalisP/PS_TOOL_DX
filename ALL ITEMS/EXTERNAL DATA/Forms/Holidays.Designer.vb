<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Holidays
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Holidays))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.HOLIDAYSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.Holidays_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTAG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMODIFICATIONFLAG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StatusRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colCOUNTRYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOUNTRYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHOLYDAYTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHOLYDAY_TYPE_Definition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSPECIALHOLIDAYINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BLZLayoutView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colBankleitzahl1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBankleitzahl1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMerkmal1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMerkmal1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBezeichnung1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBezeichnung1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPLZ1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPLZ1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOrt1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOrt1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colKurzbezeichnung1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colKurzbezeichnung1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPAN1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPAN1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBIC1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn5 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.HOLIDAYSTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.HOLIDAYSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BLZViews_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Holiday_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HOLIDAYSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Holidays_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BLZLayoutView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBankleitzahl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMerkmal1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBezeichnung1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPLZ1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOrt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colKurzbezeichnung1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPAN1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "Valid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "NonValid.ico")
        Me.ImageCollection1.InsertGalleryImage("exporttotxt_16x16.png", "images/export/exporttotxt_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttotxt_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "exporttotxt_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "cancel_16x16.png")
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
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.HOLIDAYSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.Holidays_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.StatusRepositoryItemImageComboBox})
        Me.GridControl2.Size = New System.Drawing.Size(1292, 698)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Holidays_GridView, Me.BLZLayoutView})
        '
        'HOLIDAYSBindingSource
        '
        Me.HOLIDAYSBindingSource.DataMember = "HOLIDAYS"
        Me.HOLIDAYSBindingSource.DataSource = Me.EXTERNALDataset
        '
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Holidays_GridView
        '
        Me.Holidays_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Holidays_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Holidays_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Holidays_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Holidays_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Holidays_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colTAG, Me.colMODIFICATIONFLAG, Me.colCOUNTRYCODE, Me.colCOUNTRYNAME, Me.colDATE, Me.colHOLYDAYTYPE, Me.colHOLYDAY_TYPE_Definition, Me.colSPECIALHOLIDAYINFO})
        Me.Holidays_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Holidays_GridView.GridControl = Me.GridControl2
        Me.Holidays_GridView.Name = "Holidays_GridView"
        Me.Holidays_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Holidays_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Holidays_GridView.OptionsCustomization.AllowRowSizing = True
        Me.Holidays_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Holidays_GridView.OptionsFind.AlwaysVisible = True
        Me.Holidays_GridView.OptionsSelection.MultiSelect = True
        Me.Holidays_GridView.OptionsView.ColumnAutoWidth = False
        Me.Holidays_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Holidays_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Holidays_GridView.OptionsView.ShowAutoFilterRow = True
        Me.Holidays_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colTAG
        '
        Me.colTAG.FieldName = "TAG"
        Me.colTAG.Name = "colTAG"
        Me.colTAG.OptionsColumn.AllowEdit = False
        Me.colTAG.OptionsColumn.ReadOnly = True
        Me.colTAG.Width = 49
        '
        'colMODIFICATIONFLAG
        '
        Me.colMODIFICATIONFLAG.ColumnEdit = Me.StatusRepositoryItemImageComboBox
        Me.colMODIFICATIONFLAG.FieldName = "MODIFICATION FLAG"
        Me.colMODIFICATIONFLAG.Name = "colMODIFICATIONFLAG"
        Me.colMODIFICATIONFLAG.OptionsColumn.AllowEdit = False
        Me.colMODIFICATIONFLAG.OptionsColumn.ReadOnly = True
        Me.colMODIFICATIONFLAG.Visible = True
        Me.colMODIFICATIONFLAG.VisibleIndex = 6
        Me.colMODIFICATIONFLAG.Width = 102
        '
        'StatusRepositoryItemImageComboBox
        '
        Me.StatusRepositoryItemImageComboBox.AutoHeight = False
        Me.StatusRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StatusRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNCHANGED", "U", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DELETED", "D", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MODIFIED", "M", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ADDED", "A", 6)})
        Me.StatusRepositoryItemImageComboBox.Name = "StatusRepositoryItemImageComboBox"
        Me.StatusRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colCOUNTRYCODE
        '
        Me.colCOUNTRYCODE.AppearanceCell.Options.UseTextOptions = True
        Me.colCOUNTRYCODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCOUNTRYCODE.FieldName = "COUNTRY CODE"
        Me.colCOUNTRYCODE.Name = "colCOUNTRYCODE"
        Me.colCOUNTRYCODE.OptionsColumn.AllowEdit = False
        Me.colCOUNTRYCODE.OptionsColumn.ReadOnly = True
        Me.colCOUNTRYCODE.Visible = True
        Me.colCOUNTRYCODE.VisibleIndex = 1
        Me.colCOUNTRYCODE.Width = 72
        '
        'colCOUNTRYNAME
        '
        Me.colCOUNTRYNAME.FieldName = "COUNTRY NAME"
        Me.colCOUNTRYNAME.Name = "colCOUNTRYNAME"
        Me.colCOUNTRYNAME.OptionsColumn.AllowEdit = False
        Me.colCOUNTRYNAME.OptionsColumn.ReadOnly = True
        Me.colCOUNTRYNAME.Visible = True
        Me.colCOUNTRYNAME.VisibleIndex = 2
        Me.colCOUNTRYNAME.Width = 223
        '
        'colDATE
        '
        Me.colDATE.AppearanceCell.Options.UseTextOptions = True
        Me.colDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDATE.Caption = "HOLIDAY DATE"
        Me.colDATE.FieldName = "DATE"
        Me.colDATE.Name = "colDATE"
        Me.colDATE.OptionsColumn.AllowEdit = False
        Me.colDATE.OptionsColumn.ReadOnly = True
        Me.colDATE.Visible = True
        Me.colDATE.VisibleIndex = 0
        Me.colDATE.Width = 102
        '
        'colHOLYDAYTYPE
        '
        Me.colHOLYDAYTYPE.FieldName = "HOLYDAY TYPE"
        Me.colHOLYDAYTYPE.Name = "colHOLYDAYTYPE"
        Me.colHOLYDAYTYPE.OptionsColumn.AllowEdit = False
        Me.colHOLYDAYTYPE.OptionsColumn.ReadOnly = True
        Me.colHOLYDAYTYPE.Visible = True
        Me.colHOLYDAYTYPE.VisibleIndex = 3
        Me.colHOLYDAYTYPE.Width = 91
        '
        'colHOLYDAY_TYPE_Definition
        '
        Me.colHOLYDAY_TYPE_Definition.Caption = "HOLIDAY TYPE DEFINITION"
        Me.colHOLYDAY_TYPE_Definition.FieldName = "HOLYDAY_TYPE_Definition"
        Me.colHOLYDAY_TYPE_Definition.Name = "colHOLYDAY_TYPE_Definition"
        Me.colHOLYDAY_TYPE_Definition.OptionsColumn.AllowEdit = False
        Me.colHOLYDAY_TYPE_Definition.OptionsColumn.ReadOnly = True
        Me.colHOLYDAY_TYPE_Definition.Visible = True
        Me.colHOLYDAY_TYPE_Definition.VisibleIndex = 4
        Me.colHOLYDAY_TYPE_Definition.Width = 328
        '
        'colSPECIALHOLIDAYINFO
        '
        Me.colSPECIALHOLIDAYINFO.FieldName = "SPECIAL HOLIDAY INFO"
        Me.colSPECIALHOLIDAYINFO.Name = "colSPECIALHOLIDAYINFO"
        Me.colSPECIALHOLIDAYINFO.OptionsColumn.AllowEdit = False
        Me.colSPECIALHOLIDAYINFO.OptionsColumn.ReadOnly = True
        Me.colSPECIALHOLIDAYINFO.Visible = True
        Me.colSPECIALHOLIDAYINFO.VisibleIndex = 5
        Me.colSPECIALHOLIDAYINFO.Width = 511
        '
        'BLZLayoutView
        '
        Me.BLZLayoutView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colBankleitzahl1, Me.colMerkmal1, Me.colBezeichnung1, Me.colPLZ1, Me.colOrt1, Me.colKurzbezeichnung1, Me.colPAN1, Me.colBIC1, Me.LayoutViewColumn1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4, Me.LayoutViewColumn5})
        Me.BLZLayoutView.GridControl = Me.GridControl2
        Me.BLZLayoutView.Name = "BLZLayoutView"
        Me.BLZLayoutView.OptionsBehavior.AllowExpandCollapse = False
        Me.BLZLayoutView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.BLZLayoutView.OptionsBehavior.AllowSwitchViewModes = False
        Me.BLZLayoutView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.BLZLayoutView.OptionsBehavior.Editable = False
        Me.BLZLayoutView.OptionsBehavior.ReadOnly = True
        Me.BLZLayoutView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.BLZLayoutView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.BLZLayoutView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.BLZLayoutView.OptionsCustomization.AllowFilter = False
        Me.BLZLayoutView.OptionsCustomization.AllowSort = False
        Me.BLZLayoutView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.BLZLayoutView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.BLZLayoutView.OptionsFilter.AllowFilterEditor = False
        Me.BLZLayoutView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.BLZLayoutView.OptionsFind.AllowFindPanel = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnablePanButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowPanButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.BLZLayoutView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.BLZLayoutView.OptionsView.ShowHeaderPanel = False
        Me.BLZLayoutView.TemplateCard = Me.LayoutViewCard1
        '
        'colBankleitzahl1
        '
        Me.colBankleitzahl1.FieldName = "Bankleitzahl"
        Me.colBankleitzahl1.LayoutViewField = Me.layoutViewField_colBankleitzahl1
        Me.colBankleitzahl1.Name = "colBankleitzahl1"
        Me.colBankleitzahl1.OptionsColumn.AllowEdit = False
        Me.colBankleitzahl1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBankleitzahl1
        '
        Me.layoutViewField_colBankleitzahl1.EditorPreferredWidth = 93
        Me.layoutViewField_colBankleitzahl1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBankleitzahl1.Name = "layoutViewField_colBankleitzahl1"
        Me.layoutViewField_colBankleitzahl1.Size = New System.Drawing.Size(263, 24)
        Me.layoutViewField_colBankleitzahl1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colMerkmal1
        '
        Me.colMerkmal1.FieldName = "Merkmal"
        Me.colMerkmal1.LayoutViewField = Me.layoutViewField_colMerkmal1
        Me.colMerkmal1.Name = "colMerkmal1"
        Me.colMerkmal1.OptionsColumn.AllowEdit = False
        Me.colMerkmal1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colMerkmal1
        '
        Me.layoutViewField_colMerkmal1.EditorPreferredWidth = 36
        Me.layoutViewField_colMerkmal1.Location = New System.Drawing.Point(0, 24)
        Me.layoutViewField_colMerkmal1.Name = "layoutViewField_colMerkmal1"
        Me.layoutViewField_colMerkmal1.Size = New System.Drawing.Size(206, 24)
        Me.layoutViewField_colMerkmal1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colBezeichnung1
        '
        Me.colBezeichnung1.FieldName = "Bezeichnung"
        Me.colBezeichnung1.LayoutViewField = Me.layoutViewField_colBezeichnung1
        Me.colBezeichnung1.Name = "colBezeichnung1"
        Me.colBezeichnung1.OptionsColumn.AllowEdit = False
        Me.colBezeichnung1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBezeichnung1
        '
        Me.layoutViewField_colBezeichnung1.EditorPreferredWidth = 526
        Me.layoutViewField_colBezeichnung1.Location = New System.Drawing.Point(0, 48)
        Me.layoutViewField_colBezeichnung1.Name = "layoutViewField_colBezeichnung1"
        Me.layoutViewField_colBezeichnung1.Size = New System.Drawing.Size(696, 24)
        Me.layoutViewField_colBezeichnung1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colPLZ1
        '
        Me.colPLZ1.FieldName = "PLZ"
        Me.colPLZ1.LayoutViewField = Me.layoutViewField_colPLZ1
        Me.colPLZ1.Name = "colPLZ1"
        Me.colPLZ1.OptionsColumn.AllowEdit = False
        Me.colPLZ1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPLZ1
        '
        Me.layoutViewField_colPLZ1.EditorPreferredWidth = 52
        Me.layoutViewField_colPLZ1.Location = New System.Drawing.Point(0, 72)
        Me.layoutViewField_colPLZ1.Name = "layoutViewField_colPLZ1"
        Me.layoutViewField_colPLZ1.Size = New System.Drawing.Size(222, 24)
        Me.layoutViewField_colPLZ1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colOrt1
        '
        Me.colOrt1.FieldName = "Ort"
        Me.colOrt1.LayoutViewField = Me.layoutViewField_colOrt1
        Me.colOrt1.Name = "colOrt1"
        Me.colOrt1.OptionsColumn.AllowEdit = False
        Me.colOrt1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colOrt1
        '
        Me.layoutViewField_colOrt1.EditorPreferredWidth = 526
        Me.layoutViewField_colOrt1.Location = New System.Drawing.Point(0, 96)
        Me.layoutViewField_colOrt1.Name = "layoutViewField_colOrt1"
        Me.layoutViewField_colOrt1.Size = New System.Drawing.Size(696, 24)
        Me.layoutViewField_colOrt1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colKurzbezeichnung1
        '
        Me.colKurzbezeichnung1.FieldName = "Kurzbezeichnung"
        Me.colKurzbezeichnung1.LayoutViewField = Me.layoutViewField_colKurzbezeichnung1
        Me.colKurzbezeichnung1.Name = "colKurzbezeichnung1"
        Me.colKurzbezeichnung1.OptionsColumn.AllowEdit = False
        Me.colKurzbezeichnung1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colKurzbezeichnung1
        '
        Me.layoutViewField_colKurzbezeichnung1.EditorPreferredWidth = 526
        Me.layoutViewField_colKurzbezeichnung1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colKurzbezeichnung1.Name = "layoutViewField_colKurzbezeichnung1"
        Me.layoutViewField_colKurzbezeichnung1.Size = New System.Drawing.Size(696, 24)
        Me.layoutViewField_colKurzbezeichnung1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colPAN1
        '
        Me.colPAN1.FieldName = "PAN"
        Me.colPAN1.LayoutViewField = Me.layoutViewField_colPAN1
        Me.colPAN1.Name = "colPAN1"
        Me.colPAN1.OptionsColumn.AllowEdit = False
        Me.colPAN1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPAN1
        '
        Me.layoutViewField_colPAN1.EditorPreferredWidth = 526
        Me.layoutViewField_colPAN1.Location = New System.Drawing.Point(0, 144)
        Me.layoutViewField_colPAN1.Name = "layoutViewField_colPAN1"
        Me.layoutViewField_colPAN1.Size = New System.Drawing.Size(696, 24)
        Me.layoutViewField_colPAN1.TextSize = New System.Drawing.Size(161, 13)
        '
        'colBIC1
        '
        Me.colBIC1.FieldName = "BIC"
        Me.colBIC1.LayoutViewField = Me.layoutViewField_colBIC1
        Me.colBIC1.Name = "colBIC1"
        Me.colBIC1.OptionsColumn.AllowEdit = False
        Me.colBIC1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBIC1
        '
        Me.layoutViewField_colBIC1.EditorPreferredWidth = 94
        Me.layoutViewField_colBIC1.Location = New System.Drawing.Point(0, 168)
        Me.layoutViewField_colBIC1.Name = "layoutViewField_colBIC1"
        Me.layoutViewField_colBIC1.Size = New System.Drawing.Size(264, 24)
        Me.layoutViewField_colBIC1.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.FieldName = "Prüfziffer-berechnungs-methode"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 31
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 192)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(201, 24)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.FieldName = "Datensatz-nummer"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_LayoutViewColumn2
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        Me.LayoutViewColumn2.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn2.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn2
        '
        Me.layoutViewField_LayoutViewColumn2.EditorPreferredWidth = 87
        Me.layoutViewField_LayoutViewColumn2.Location = New System.Drawing.Point(0, 216)
        Me.layoutViewField_LayoutViewColumn2.Name = "layoutViewField_LayoutViewColumn2"
        Me.layoutViewField_LayoutViewColumn2.Size = New System.Drawing.Size(257, 24)
        Me.layoutViewField_LayoutViewColumn2.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.Caption = "Status"
        Me.LayoutViewColumn3.ColumnEdit = Me.StatusRepositoryItemImageComboBox
        Me.LayoutViewColumn3.FieldName = "Änderungs-kennzeichen"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_LayoutViewColumn3
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        Me.LayoutViewColumn3.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn3.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn3
        '
        Me.layoutViewField_LayoutViewColumn3.EditorPreferredWidth = 33
        Me.layoutViewField_LayoutViewColumn3.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_LayoutViewColumn3.Name = "layoutViewField_LayoutViewColumn3"
        Me.layoutViewField_LayoutViewColumn3.Size = New System.Drawing.Size(203, 24)
        Me.layoutViewField_LayoutViewColumn3.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.Caption = "BLZ Löschung Kz."
        Me.LayoutViewColumn4.FieldName = "Bankleitzahl-löschung"
        Me.LayoutViewColumn4.LayoutViewField = Me.layoutViewField_LayoutViewColumn4
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        Me.LayoutViewColumn4.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn4.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn4
        '
        Me.layoutViewField_LayoutViewColumn4.EditorPreferredWidth = 87
        Me.layoutViewField_LayoutViewColumn4.Location = New System.Drawing.Point(0, 264)
        Me.layoutViewField_LayoutViewColumn4.Name = "layoutViewField_LayoutViewColumn4"
        Me.layoutViewField_LayoutViewColumn4.Size = New System.Drawing.Size(257, 20)
        Me.layoutViewField_LayoutViewColumn4.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn5
        '
        Me.LayoutViewColumn5.FieldName = "Nachfolge-Bankleitzahl"
        Me.LayoutViewColumn5.LayoutViewField = Me.layoutViewField_LayoutViewColumn5
        Me.LayoutViewColumn5.Name = "LayoutViewColumn5"
        Me.LayoutViewColumn5.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn5.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn5
        '
        Me.layoutViewField_LayoutViewColumn5.EditorPreferredWidth = 98
        Me.layoutViewField_LayoutViewColumn5.Location = New System.Drawing.Point(0, 284)
        Me.layoutViewField_LayoutViewColumn5.Name = "layoutViewField_LayoutViewColumn5"
        Me.layoutViewField_LayoutViewColumn5.Size = New System.Drawing.Size(268, 24)
        Me.layoutViewField_LayoutViewColumn5.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colBankleitzahl1, Me.layoutViewField_colMerkmal1, Me.layoutViewField_colBezeichnung1, Me.layoutViewField_colPLZ1, Me.layoutViewField_colOrt1, Me.layoutViewField_colKurzbezeichnung1, Me.layoutViewField_colPAN1, Me.layoutViewField_colBIC1, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_LayoutViewColumn2, Me.layoutViewField_LayoutViewColumn3, Me.layoutViewField_LayoutViewColumn4, Me.layoutViewField_LayoutViewColumn5})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'HOLIDAYSTableAdapter
        '
        Me.HOLIDAYSTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Me.HOLIDAYSTableAdapter
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.BLZViews_btn)
        Me.LayoutControl1.Controls.Add(Me.Holiday_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1316, 748)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
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
        'BLZViews_btn
        '
        Me.BLZViews_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BLZViews_btn.ImageIndex = 0
        Me.BLZViews_btn.ImageList = Me.ImageCollection1
        Me.BLZViews_btn.Location = New System.Drawing.Point(1180, 12)
        Me.BLZViews_btn.Name = "BLZViews_btn"
        Me.BLZViews_btn.Size = New System.Drawing.Size(124, 22)
        Me.BLZViews_btn.StyleController = Me.LayoutControl1
        Me.BLZViews_btn.TabIndex = 7
        Me.BLZViews_btn.Text = "View Detail"
        '
        'Holiday_Print_Export_btn
        '
        Me.Holiday_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Holiday_Print_Export_btn.ImageIndex = 2
        Me.Holiday_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.Holiday_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Holiday_Print_Export_btn.Name = "Holiday_Print_Export_btn"
        Me.Holiday_Print_Export_btn.Size = New System.Drawing.Size(145, 22)
        Me.Holiday_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Holiday_Print_Export_btn.TabIndex = 9
        Me.Holiday_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1316, 748)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(463, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(703, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Holiday_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(149, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(149, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(314, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BLZViews_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1168, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(128, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1166, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1296, 702)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'Holidays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 748)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Holidays"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Holidays"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HOLIDAYSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Holidays_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BLZLayoutView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBankleitzahl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMerkmal1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBezeichnung1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPLZ1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOrt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colKurzbezeichnung1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPAN1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents HOLIDAYSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HOLIDAYSTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.HOLIDAYSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Holidays_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTAG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMODIFICATIONFLAG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StatusRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colCOUNTRYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOUNTRYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHOLYDAYTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHOLYDAY_TYPE_Definition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSPECIALHOLIDAYINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BLZLayoutView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colBankleitzahl1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBankleitzahl1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMerkmal1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMerkmal1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colBezeichnung1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBezeichnung1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPLZ1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPLZ1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOrt1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOrt1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colKurzbezeichnung1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colKurzbezeichnung1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPAN1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPAN1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colBIC1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn5 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BLZViews_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Holiday_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
