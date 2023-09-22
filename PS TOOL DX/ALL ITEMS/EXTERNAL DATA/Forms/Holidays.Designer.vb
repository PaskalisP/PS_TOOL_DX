<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Holidays
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
        Me.HOLIDAYSTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.HOLIDAYSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbi_LoadData = New DevExpress.XtraBars.BarButtonItem()
        Me.bbi_PrintOrExport = New DevExpress.XtraBars.BarButtonItem()
        Me.bbi_Close = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HOLIDAYSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Holidays_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GridControl2.Location = New System.Drawing.Point(12, 12)
        Me.GridControl2.MainView = Me.Holidays_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.StatusRepositoryItemImageComboBox})
        Me.GridControl2.Size = New System.Drawing.Size(1293, 450)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Holidays_GridView})
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
        Me.Holidays_GridView.OptionsView.ShowGroupPanel = False
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
        'HOLIDAYSTableAdapter
        '
        Me.HOLIDAYSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BIC_HISTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Nothing
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Me.HOLIDAYSTableAdapter
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1317, 474)
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1317, 474)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1297, 454)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Images = Me.ImageCollection1
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.bbi_LoadData, Me.bbi_PrintOrExport, Me.bbi_Close})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 4
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowSearchItem = True
        Me.RibbonControl1.Size = New System.Drawing.Size(1317, 94)
        '
        'bbi_LoadData
        '
        Me.bbi_LoadData.Caption = "Load data"
        Me.bbi_LoadData.Id = 1
        Me.bbi_LoadData.ImageOptions.Image = CType(resources.GetObject("bbi_LoadData.ImageOptions.Image"), System.Drawing.Image)
        Me.bbi_LoadData.ImageOptions.LargeImage = CType(resources.GetObject("bbi_LoadData.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbi_LoadData.Name = "bbi_LoadData"
        '
        'bbi_PrintOrExport
        '
        Me.bbi_PrintOrExport.Caption = "Print or Export"
        Me.bbi_PrintOrExport.Id = 2
        Me.bbi_PrintOrExport.ImageOptions.ImageIndex = 2
        Me.bbi_PrintOrExport.Name = "bbi_PrintOrExport"
        '
        'bbi_Close
        '
        Me.bbi_Close.Caption = "Close"
        Me.bbi_Close.Id = 3
        Me.bbi_Close.ImageOptions.Image = CType(resources.GetObject("bbi_Close.ImageOptions.Image"), System.Drawing.Image)
        Me.bbi_Close.ImageOptions.LargeImage = CType(resources.GetObject("bbi_Close.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbi_Close.Name = "bbi_Close"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_LoadData)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_PrintOrExport, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_Close, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'Holidays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 568)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("Holidays.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "Holidays"
        Me.Ribbon = Me.RibbonControl1
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents bbi_LoadData As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbi_PrintOrExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbi_Close As DevExpress.XtraBars.BarButtonItem
End Class
