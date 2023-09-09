<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManualImport))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.EDPDataSet = New PS_TOOL_DX.EDPDataSet()
        Me.MANUAL_IMPORTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MANUAL_IMPORTSTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.MANUAL_IMPORTSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager()
        Me.IMPORT_EVENTSTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.IMPORT_EVENTSTableAdapter()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.MANUAL_Procedures_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ManualImportProcedures_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colProcName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManualImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colExectutionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExecutionType_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colImportance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ImportanceRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colStrartImportNOTBINDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StartImportButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileDirImport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrentFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SelectFileButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colMultiselect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colFileConvertion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FileCoversionRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colFileExtraction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRequestBusinessDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDeleteFileAfterImport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInternalNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colLastAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastImportDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastImportTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastImportUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ImportEvents_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.IMPORT_EVENTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MANUALImportEvents_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSystemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem_ProgressPanel = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.XtraSaveFileDialog1 = New DevExpress.XtraEditors.XtraSaveFileDialog(Me.components)
        Me.XtraFolderBrowserDialog1 = New DevExpress.XtraEditors.XtraFolderBrowserDialog(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.Add_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.Save_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.Delete_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.Preview_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.Close_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANUAL_IMPORTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.MANUAL_Procedures_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManualImportProcedures_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManualImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExecutionType_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportanceRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartImportButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectFileButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileCoversionRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ImportEvents_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPORT_EVENTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANUALImportEvents_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem_ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colEvent
        '
        Me.colEvent.AppearanceCell.Options.UseTextOptions = True
        Me.colEvent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colEvent.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colEvent.FieldName = "Event"
        Me.colEvent.Name = "colEvent"
        Me.colEvent.OptionsColumn.ReadOnly = True
        Me.colEvent.Visible = True
        Me.colEvent.VisibleIndex = 2
        Me.colEvent.Width = 683
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RepositoryItemMemoExEdit1.ShowIcon = False
        '
        'EDPDataSet
        '
        Me.EDPDataSet.DataSetName = "EDPDataSet"
        Me.EDPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MANUAL_IMPORTSBindingSource
        '
        Me.MANUAL_IMPORTSBindingSource.DataMember = "MANUAL IMPORTS"
        Me.MANUAL_IMPORTSBindingSource.DataSource = Me.EDPDataSet
        '
        'MANUAL_IMPORTSTableAdapter
        '
        Me.MANUAL_IMPORTSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_TABLE_COLUMNSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BAIS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.BAISFORMS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.CLIENT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.CURRENT_USERSTableAdapter = Nothing
        Me.TableAdapterManager.FILES_IMPORTTableAdapter = Nothing
        Me.TableAdapterManager.IMPORT_EVENTSTableAdapter = Me.IMPORT_EVENTSTableAdapter
        Me.TableAdapterManager.MANUAL_IMPORTSTableAdapter = Me.MANUAL_IMPORTSTableAdapter
        Me.TableAdapterManager.OCBS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.PSTOOL_CLIENT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_SECONDTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_THIRDTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'IMPORT_EVENTSTableAdapter
        '
        Me.IMPORT_EVENTSTableAdapter.ClearBeforeFill = True
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.SystemColors.ControlLight
        Me.XtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = True
        Me.XtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderButtons = CType((((DevExpress.XtraTab.TabButtons.Prev Or DevExpress.XtraTab.TabButtons.[Next]) _
            Or DevExpress.XtraTab.TabButtons.Close) _
            Or DevExpress.XtraTab.TabButtons.[Default]), DevExpress.XtraTab.TabButtons)
        Me.XtraTabControl1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 94)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.MANUAL_Procedures_XtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1411, 465)
        Me.XtraTabControl1.TabIndex = 22
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.MANUAL_Procedures_XtraTabPage, Me.ImportEvents_XtraTabPage})
        '
        'MANUAL_Procedures_XtraTabPage
        '
        Me.MANUAL_Procedures_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MANUAL_Procedures_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.MANUAL_Procedures_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.MANUAL_Procedures_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.MANUAL_Procedures_XtraTabPage.Controls.Add(Me.LayoutControl1)
        Me.MANUAL_Procedures_XtraTabPage.Name = "MANUAL_Procedures_XtraTabPage"
        Me.MANUAL_Procedures_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.MANUAL_Procedures_XtraTabPage.Size = New System.Drawing.Size(1409, 442)
        Me.MANUAL_Procedures_XtraTabPage.Text = "MANUAL IMPORT PROCEDURES"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1409, 442)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.MANUAL_IMPORTSBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.ImageIndex = 11
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 12
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, True, False, "Remove", "Remove")})
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.ManualImportProcedures_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.ManualImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox, Me.StartImportButtonEdit, Me.SelectFileButtonEdit, Me.RepositoryItemSpinEdit1, Me.ExecutionType_RepositoryItemImageComboBox, Me.RepositoryItemMemoEdit1, Me.ImportanceRepositoryItemImageComboBox, Me.FileCoversionRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1385, 418)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ManualImportProcedures_BasicView})
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
        Me.ImageCollection1.Images.SetKeyName(8, "save.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("edit_16x16.png", "images/edit/edit_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "edit_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("info_16x16.png", "images/support/info_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/info_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "info_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(14, "apply_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(15, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(16, "download_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "scripts_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(18, "hyperlink_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(19, "checkbox_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(20, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(21, "exporttoxlsx_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(22, "exporttocsv_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(23, "warning_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(24, "viewonweb_16x16.png")
        '
        'ManualImportProcedures_BasicView
        '
        Me.ManualImportProcedures_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ManualImportProcedures_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ManualImportProcedures_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ManualImportProcedures_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ManualImportProcedures_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ManualImportProcedures_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colProcNr, Me.colProcName, Me.colExectutionType, Me.colImportance, Me.colStrartImportNOTBINDED, Me.colFileName, Me.colFileDirImport, Me.colCurrentFileName, Me.colMultiselect, Me.colFileConvertion, Me.colFileExtraction, Me.colRequestBusinessDate, Me.colDeleteFileAfterImport, Me.colInternalNotes, Me.colLastAction, Me.colLastImportDate, Me.colLastImportTime, Me.colLastImportUser})
        Me.ManualImportProcedures_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ManualImportProcedures_BasicView.GridControl = Me.GridControl1
        Me.ManualImportProcedures_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessType", Nothing, "{0:n2}")})
        Me.ManualImportProcedures_BasicView.Name = "ManualImportProcedures_BasicView"
        Me.ManualImportProcedures_BasicView.NewItemRowText = "Add new Manual Import Procedure"
        Me.ManualImportProcedures_BasicView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ManualImportProcedures_BasicView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ManualImportProcedures_BasicView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow
        Me.ManualImportProcedures_BasicView.OptionsCustomization.AllowRowSizing = True
        Me.ManualImportProcedures_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ManualImportProcedures_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ManualImportProcedures_BasicView.OptionsFind.AlwaysVisible = True
        Me.ManualImportProcedures_BasicView.OptionsPrint.PrintDetails = True
        Me.ManualImportProcedures_BasicView.OptionsSelection.MultiSelect = True
        Me.ManualImportProcedures_BasicView.OptionsView.ColumnAutoWidth = False
        Me.ManualImportProcedures_BasicView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.ManualImportProcedures_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ManualImportProcedures_BasicView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ManualImportProcedures_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.ManualImportProcedures_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ManualImportProcedures_BasicView.OptionsView.ShowFooter = True
        Me.ManualImportProcedures_BasicView.OptionsView.ShowGroupPanel = False
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colProcNr
        '
        Me.colProcNr.AppearanceCell.Options.UseTextOptions = True
        Me.colProcNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colProcNr.Caption = "Procedure Nr."
        Me.colProcNr.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colProcNr.DisplayFormat.FormatString = "n0"
        Me.colProcNr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colProcNr.FieldName = "ProcNr"
        Me.colProcNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colProcNr.Name = "colProcNr"
        Me.colProcNr.Visible = True
        Me.colProcNr.VisibleIndex = 0
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
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatString = "n0"
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.EditFormat.FormatString = "n0"
        Me.RepositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "n0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'colProcName
        '
        Me.colProcName.Caption = "Procedure Name"
        Me.colProcName.ColumnEdit = Me.ManualImportProcedureRepositoryItemTextEdit
        Me.colProcName.FieldName = "ProcName"
        Me.colProcName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colProcName.Name = "colProcName"
        Me.colProcName.OptionsEditForm.ColumnSpan = 3
        Me.colProcName.OptionsEditForm.StartNewRow = True
        Me.colProcName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colProcName.Visible = True
        Me.colProcName.VisibleIndex = 1
        Me.colProcName.Width = 310
        '
        'ManualImportProcedureRepositoryItemTextEdit
        '
        Me.ManualImportProcedureRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.ManualImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ManualImportProcedureRepositoryItemTextEdit.AutoHeight = False
        Me.ManualImportProcedureRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ManualImportProcedureRepositoryItemTextEdit.Name = "ManualImportProcedureRepositoryItemTextEdit"
        '
        'colExectutionType
        '
        Me.colExectutionType.ColumnEdit = Me.ExecutionType_RepositoryItemImageComboBox
        Me.colExectutionType.FieldName = "ExectutionType"
        Me.colExectutionType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colExectutionType.Name = "colExectutionType"
        Me.colExectutionType.OptionsEditForm.StartNewRow = True
        Me.colExectutionType.Visible = True
        Me.colExectutionType.VisibleIndex = 2
        Me.colExectutionType.Width = 140
        '
        'ExecutionType_RepositoryItemImageComboBox
        '
        Me.ExecutionType_RepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExecutionType_RepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExecutionType_RepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExecutionType_RepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ExecutionType_RepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ExecutionType_RepositoryItemImageComboBox.AutoHeight = False
        Me.ExecutionType_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExecutionType_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FILE IMPORT", "IMPORT", 16), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEB IMPORT", "WEB", 18), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("SCRIPT EXECUTION", "SCRIPT", 17)})
        Me.ExecutionType_RepositoryItemImageComboBox.Name = "ExecutionType_RepositoryItemImageComboBox"
        Me.ExecutionType_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colImportance
        '
        Me.colImportance.ColumnEdit = Me.ImportanceRepositoryItemImageComboBox
        Me.colImportance.FieldName = "Importance"
        Me.colImportance.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colImportance.Name = "colImportance"
        Me.colImportance.Visible = True
        Me.colImportance.VisibleIndex = 3
        Me.colImportance.Width = 118
        '
        'ImportanceRepositoryItemImageComboBox
        '
        Me.ImportanceRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ImportanceRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ImportanceRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ImportanceRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ImportanceRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ImportanceRepositoryItemImageComboBox.AutoHeight = False
        Me.ImportanceRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImportanceRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MANDATORY", "MANDATORY", 19), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO MANDATORY", "NONE", 20)})
        Me.ImportanceRepositoryItemImageComboBox.Name = "ImportanceRepositoryItemImageComboBox"
        Me.ImportanceRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colStrartImportNOTBINDED
        '
        Me.colStrartImportNOTBINDED.Caption = "Start Import"
        Me.colStrartImportNOTBINDED.ColumnEdit = Me.StartImportButtonEdit
        Me.colStrartImportNOTBINDED.FieldName = "colStrartImportNOTBINDED"
        Me.colStrartImportNOTBINDED.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colStrartImportNOTBINDED.Name = "colStrartImportNOTBINDED"
        Me.colStrartImportNOTBINDED.OptionsColumn.ReadOnly = True
        Me.colStrartImportNOTBINDED.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colStrartImportNOTBINDED.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colStrartImportNOTBINDED.Visible = True
        Me.colStrartImportNOTBINDED.VisibleIndex = 4
        Me.colStrartImportNOTBINDED.Width = 118
        '
        'StartImportButtonEdit
        '
        Me.StartImportButtonEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Red
        Me.StartImportButtonEdit.AppearanceFocused.Options.UseForeColor = True
        Me.StartImportButtonEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        EditorButtonImageOptions1.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        SerializableAppearanceObject3.ForeColor = System.Drawing.Color.Red
        SerializableAppearanceObject3.Options.UseForeColor = True
        Me.StartImportButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Start Import", 30, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.StartImportButtonEdit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.StartImportButtonEdit.LookAndFeel.SkinName = "Office 2019 Colorful"
        Me.StartImportButtonEdit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.StartImportButtonEdit.Name = "StartImportButtonEdit"
        Me.StartImportButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colFileName
        '
        Me.colFileName.FieldName = "FileName"
        Me.colFileName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colFileName.Name = "colFileName"
        Me.colFileName.OptionsEditForm.ColumnSpan = 3
        Me.colFileName.OptionsEditForm.StartNewRow = True
        Me.colFileName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colFileName.Visible = True
        Me.colFileName.VisibleIndex = 5
        Me.colFileName.Width = 254
        '
        'colFileDirImport
        '
        Me.colFileDirImport.Caption = "File Directory Import"
        Me.colFileDirImport.FieldName = "FileDirImport"
        Me.colFileDirImport.Name = "colFileDirImport"
        Me.colFileDirImport.Width = 289
        '
        'colCurrentFileName
        '
        Me.colCurrentFileName.Caption = "Current Imported File Name"
        Me.colCurrentFileName.ColumnEdit = Me.SelectFileButtonEdit
        Me.colCurrentFileName.FieldName = "CurrentFileName"
        Me.colCurrentFileName.Name = "colCurrentFileName"
        Me.colCurrentFileName.OptionsEditForm.ColumnSpan = 3
        Me.colCurrentFileName.OptionsEditForm.StartNewRow = True
        Me.colCurrentFileName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colCurrentFileName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        Me.colCurrentFileName.Visible = True
        Me.colCurrentFileName.VisibleIndex = 6
        Me.colCurrentFileName.Width = 451
        '
        'SelectFileButtonEdit
        '
        Me.SelectFileButtonEdit.AutoHeight = False
        EditorButtonImageOptions2.Image = CType(resources.GetObject("EditorButtonImageOptions2.Image"), System.Drawing.Image)
        EditorButtonImageOptions2.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.SelectFileButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 50, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.SelectFileButtonEdit.Name = "SelectFileButtonEdit"
        Me.SelectFileButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colMultiselect
        '
        Me.colMultiselect.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colMultiselect.FieldName = "Multiselect"
        Me.colMultiselect.Name = "colMultiselect"
        Me.colMultiselect.OptionsEditForm.StartNewRow = True
        Me.colMultiselect.Visible = True
        Me.colMultiselect.VisibleIndex = 8
        Me.colMultiselect.Width = 108
        '
        'ValidRepositoryItemImageComboBox
        '
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ValidRepositoryItemImageComboBox.AutoHeight = False
        Me.ValidRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 15)})
        Me.ValidRepositoryItemImageComboBox.Name = "ValidRepositoryItemImageComboBox"
        Me.ValidRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colFileConvertion
        '
        Me.colFileConvertion.ColumnEdit = Me.FileCoversionRepositoryItemImageComboBox
        Me.colFileConvertion.FieldName = "FileConvertion"
        Me.colFileConvertion.Name = "colFileConvertion"
        Me.colFileConvertion.Visible = True
        Me.colFileConvertion.VisibleIndex = 7
        Me.colFileConvertion.Width = 94
        '
        'FileCoversionRepositoryItemImageComboBox
        '
        Me.FileCoversionRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FileCoversionRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FileCoversionRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FileCoversionRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.FileCoversionRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.FileCoversionRepositoryItemImageComboBox.AutoHeight = False
        Me.FileCoversionRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FileCoversionRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 15), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("XLS_TO_XLSX", "XLS_TO_XLSX", 21), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CSV_TO_XLSX", "CSV_TO_XLSX", 22), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEBXLS_TO_XLSX", "WEBXLS_TO_XLSX", 24)})
        Me.FileCoversionRepositoryItemImageComboBox.Name = "FileCoversionRepositoryItemImageComboBox"
        Me.FileCoversionRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colFileExtraction
        '
        Me.colFileExtraction.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colFileExtraction.FieldName = "FileExtraction"
        Me.colFileExtraction.Name = "colFileExtraction"
        Me.colFileExtraction.Visible = True
        Me.colFileExtraction.VisibleIndex = 9
        Me.colFileExtraction.Width = 114
        '
        'colRequestBusinessDate
        '
        Me.colRequestBusinessDate.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colRequestBusinessDate.FieldName = "RequestBusinessDate"
        Me.colRequestBusinessDate.Name = "colRequestBusinessDate"
        Me.colRequestBusinessDate.Visible = True
        Me.colRequestBusinessDate.VisibleIndex = 10
        Me.colRequestBusinessDate.Width = 127
        '
        'colDeleteFileAfterImport
        '
        Me.colDeleteFileAfterImport.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colDeleteFileAfterImport.FieldName = "DeleteFileAfterImport"
        Me.colDeleteFileAfterImport.Name = "colDeleteFileAfterImport"
        Me.colDeleteFileAfterImport.Visible = True
        Me.colDeleteFileAfterImport.VisibleIndex = 11
        Me.colDeleteFileAfterImport.Width = 130
        '
        'colInternalNotes
        '
        Me.colInternalNotes.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colInternalNotes.FieldName = "InternalNotes"
        Me.colInternalNotes.Name = "colInternalNotes"
        Me.colInternalNotes.OptionsEditForm.UseEditorColRowSpan = False
        Me.colInternalNotes.Visible = True
        Me.colInternalNotes.VisibleIndex = 16
        Me.colInternalNotes.Width = 224
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.AllowFocused = False
        Me.RepositoryItemMemoExEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AutoHeight = False
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        Me.RepositoryItemMemoExEdit2.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colLastAction
        '
        Me.colLastAction.FieldName = "LastAction"
        Me.colLastAction.Name = "colLastAction"
        Me.colLastAction.OptionsColumn.ReadOnly = True
        Me.colLastAction.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colLastAction.Visible = True
        Me.colLastAction.VisibleIndex = 14
        Me.colLastAction.Width = 148
        '
        'colLastImportDate
        '
        Me.colLastImportDate.AppearanceCell.Options.UseTextOptions = True
        Me.colLastImportDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastImportDate.DisplayFormat.FormatString = "d"
        Me.colLastImportDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLastImportDate.FieldName = "LastImportDate"
        Me.colLastImportDate.Name = "colLastImportDate"
        Me.colLastImportDate.OptionsColumn.AllowEdit = False
        Me.colLastImportDate.OptionsColumn.ReadOnly = True
        Me.colLastImportDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colLastImportDate.Visible = True
        Me.colLastImportDate.VisibleIndex = 12
        Me.colLastImportDate.Width = 124
        '
        'colLastImportTime
        '
        Me.colLastImportTime.AppearanceCell.Options.UseTextOptions = True
        Me.colLastImportTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastImportTime.DisplayFormat.FormatString = "HH:mm:ss"
        Me.colLastImportTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLastImportTime.FieldName = "LastImportTime"
        Me.colLastImportTime.Name = "colLastImportTime"
        Me.colLastImportTime.OptionsColumn.AllowEdit = False
        Me.colLastImportTime.OptionsColumn.ReadOnly = True
        Me.colLastImportTime.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colLastImportTime.Visible = True
        Me.colLastImportTime.VisibleIndex = 13
        Me.colLastImportTime.Width = 122
        '
        'colLastImportUser
        '
        Me.colLastImportUser.FieldName = "LastImportUser"
        Me.colLastImportUser.Name = "colLastImportUser"
        Me.colLastImportUser.OptionsColumn.ReadOnly = True
        Me.colLastImportUser.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colLastImportUser.Visible = True
        Me.colLastImportUser.VisibleIndex = 15
        Me.colLastImportUser.Width = 136
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceDropDown.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceDropDown.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.DropDownRows = 2
        Me.RepositoryItemComboBox1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox1.ImmediatePopup = True
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEditBIC8
        '
        Me.RepositoryItemTextEditBIC8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEditBIC8.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEditBIC8.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEditBIC8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC8.AutoHeight = False
        Me.RepositoryItemTextEditBIC8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEditBIC8.Mask.BeepOnError = True
        Me.RepositoryItemTextEditBIC8.Mask.EditMask = "[A-Z]{6}[1-9A-Z]{2}"
        Me.RepositoryItemTextEditBIC8.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEditBIC8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEditBIC8.Name = "RepositoryItemTextEditBIC8"
        '
        'RepositoryItemTextEditBIC3
        '
        Me.RepositoryItemTextEditBIC3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEditBIC3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC3.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEditBIC3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEditBIC3.AutoHeight = False
        Me.RepositoryItemTextEditBIC3.Mask.EditMask = "[1-9A-Z]{3}"
        Me.RepositoryItemTextEditBIC3.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEditBIC3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEditBIC3.Name = "RepositoryItemTextEditBIC3"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1409, 442)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1389, 422)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'ImportEvents_XtraTabPage
        '
        Me.ImportEvents_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ImportEvents_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.ImportEvents_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.ImportEvents_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.ImportEvents_XtraTabPage.Controls.Add(Me.LayoutControl2)
        Me.ImportEvents_XtraTabPage.Name = "ImportEvents_XtraTabPage"
        Me.ImportEvents_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.ImportEvents_XtraTabPage.Size = New System.Drawing.Size(1409, 442)
        Me.ImportEvents_XtraTabPage.Text = "IMPORT EVENTS"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl2.Controls.Add(Me.GridControl2)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(1409, 442)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
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
        Me.ProgressPanel1.Location = New System.Drawing.Point(24, 44)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(116, 16)
        Me.ProgressPanel1.StyleController = Me.LayoutControl2
        Me.ProgressPanel1.TabIndex = 23
        Me.ProgressPanel1.Text = "ProgressPanel1"
        '
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.IMPORT_EVENTSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 76)
        Me.GridControl2.MainView = Me.MANUALImportEvents_BasicView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(1385, 354)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MANUALImportEvents_BasicView})
        '
        'IMPORT_EVENTSBindingSource
        '
        Me.IMPORT_EVENTSBindingSource.DataMember = "IMPORT EVENTS"
        Me.IMPORT_EVENTSBindingSource.DataSource = Me.EDPDataSet
        '
        'MANUALImportEvents_BasicView
        '
        Me.MANUALImportEvents_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.MANUALImportEvents_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.MANUALImportEvents_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.MANUALImportEvents_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.MANUALImportEvents_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.MANUALImportEvents_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colProcDate, Me.colProcTime, Me.colEvent, Me.GridColumn1, Me.colSystemName})
        Me.MANUALImportEvents_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.White
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Column = Me.colEvent
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "StartsWith([Event], 'ERROR')"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[Client No] != ?"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[Counterparty/Issuer/Collateral Name] != ?"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[Contract Collateral ID] != ?"
        Me.MANUALImportEvents_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3, StyleFormatCondition4})
        Me.MANUALImportEvents_BasicView.GridControl = Me.GridControl2
        Me.MANUALImportEvents_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}")})
        Me.MANUALImportEvents_BasicView.Name = "MANUALImportEvents_BasicView"
        Me.MANUALImportEvents_BasicView.OptionsCustomization.AllowRowSizing = True
        Me.MANUALImportEvents_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.MANUALImportEvents_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.MANUALImportEvents_BasicView.OptionsFind.AlwaysVisible = True
        Me.MANUALImportEvents_BasicView.OptionsSelection.MultiSelect = True
        Me.MANUALImportEvents_BasicView.OptionsView.ColumnAutoWidth = False
        Me.MANUALImportEvents_BasicView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.MANUALImportEvents_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.MANUALImportEvents_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.MANUALImportEvents_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.MANUALImportEvents_BasicView.OptionsView.ShowFooter = True
        Me.MANUALImportEvents_BasicView.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colProcDate
        '
        Me.colProcDate.AppearanceCell.Options.UseTextOptions = True
        Me.colProcDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colProcDate.Caption = "Date"
        Me.colProcDate.DisplayFormat.FormatString = "d"
        Me.colProcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colProcDate.FieldName = "ProcDate"
        Me.colProcDate.Name = "colProcDate"
        Me.colProcDate.OptionsColumn.AllowEdit = False
        Me.colProcDate.OptionsColumn.ReadOnly = True
        Me.colProcDate.Visible = True
        Me.colProcDate.VisibleIndex = 0
        '
        'colProcTime
        '
        Me.colProcTime.AppearanceCell.Options.UseTextOptions = True
        Me.colProcTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colProcTime.Caption = "Time"
        Me.colProcTime.DisplayFormat.FormatString = "HH:mm:ss"
        Me.colProcTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colProcTime.FieldName = "ProcTime"
        Me.colProcTime.Name = "colProcTime"
        Me.colProcTime.OptionsColumn.AllowEdit = False
        Me.colProcTime.OptionsColumn.ReadOnly = True
        Me.colProcTime.Visible = True
        Me.colProcTime.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Procedure Name"
        Me.GridColumn1.FieldName = "ProcName"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 506
        '
        'colSystemName
        '
        Me.colSystemName.Caption = "System"
        Me.colSystemName.FieldName = "SystemName"
        Me.colSystemName.Name = "colSystemName"
        Me.colSystemName.OptionsColumn.AllowEdit = False
        Me.colSystemName.OptionsColumn.ReadOnly = True
        Me.colSystemName.Visible = True
        Me.colSystemName.VisibleIndex = 4
        Me.colSystemName.Width = 156
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox2.DropDownRows = 2
        Me.RepositoryItemComboBox2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox2.ImmediatePopup = True
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Root"
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1409, 442)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl2
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem1"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1389, 358)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem_ProgressPanel, Me.LayoutControlItem2})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1389, 64)
        Me.LayoutControlGroup5.TextVisible = False
        Me.LayoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem_ProgressPanel
        '
        Me.EmptySpaceItem_ProgressPanel.AllowHotTrack = False
        Me.EmptySpaceItem_ProgressPanel.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmptySpaceItem_ProgressPanel.AppearanceItemCaption.Options.UseFont = True
        Me.EmptySpaceItem_ProgressPanel.CustomizationFormText = "EmptySpaceItem_ProgressPanel"
        Me.EmptySpaceItem_ProgressPanel.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem_ProgressPanel.Name = "EmptySpaceItem_ProgressPanel"
        Me.EmptySpaceItem_ProgressPanel.Size = New System.Drawing.Size(1365, 20)
        Me.EmptySpaceItem_ProgressPanel.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.EmptySpaceItem_ProgressPanel.TextSize = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem_ProgressPanel.TextVisible = True
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ProgressPanel1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 20)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1365, 20)
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl2
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.FileName = "XtraOpenFileDialog1"
        '
        'XtraSaveFileDialog1
        '
        Me.XtraSaveFileDialog1.FileName = "XtraSaveFileDialog1"
        '
        'XtraFolderBrowserDialog1
        '
        Me.XtraFolderBrowserDialog1.SelectedPath = "XtraFolderBrowserDialog1"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.bbiReload, Me.Add_bbi, Me.Save_bbi, Me.Delete_bbi, Me.Preview_bbi, Me.Close_bbi})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 8
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowSearchItem = True
        Me.RibbonControl1.Size = New System.Drawing.Size(1411, 94)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'bbiReload
        '
        Me.bbiReload.Caption = "Reload"
        Me.bbiReload.Id = 1
        Me.bbiReload.ImageOptions.Image = CType(resources.GetObject("bbiReload.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiReload.ImageOptions.LargeImage = CType(resources.GetObject("bbiReload.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiReload.Name = "bbiReload"
        '
        'Add_bbi
        '
        Me.Add_bbi.Caption = "Add new Import Procedure"
        Me.Add_bbi.Id = 2
        Me.Add_bbi.ImageOptions.Image = CType(resources.GetObject("Add_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Add_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Add_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Add_bbi.Name = "Add_bbi"
        '
        'Save_bbi
        '
        Me.Save_bbi.Caption = "Save"
        Me.Save_bbi.Id = 3
        Me.Save_bbi.ImageOptions.Image = CType(resources.GetObject("Save_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Save_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Save_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Save_bbi.Name = "Save_bbi"
        '
        'Delete_bbi
        '
        Me.Delete_bbi.Caption = "Delete"
        Me.Delete_bbi.Id = 4
        Me.Delete_bbi.ImageOptions.Image = CType(resources.GetObject("Delete_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Delete_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Delete_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Delete_bbi.Name = "Delete_bbi"
        '
        'Preview_bbi
        '
        Me.Preview_bbi.Caption = "Print Preview"
        Me.Preview_bbi.Id = 5
        Me.Preview_bbi.ImageOptions.Image = CType(resources.GetObject("Preview_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Preview_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Preview_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Preview_bbi.Name = "Preview_bbi"
        '
        'Close_bbi
        '
        Me.Close_bbi.Caption = "Close"
        Me.Close_bbi.Id = 7
        Me.Close_bbi.ImageOptions.Image = CType(resources.GetObject("Close_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Close_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Close_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Close_bbi.Name = "Close_bbi"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiReload)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Add_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Save_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Delete_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Preview_bbi, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Close_bbi, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 559)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1411, 22)
        Me.RibbonStatusBar1.Visible = False
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'ManualImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1411, 581)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("ManualImport.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "ManualImport"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Manual Imports"
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANUAL_IMPORTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.MANUAL_Procedures_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManualImportProcedures_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManualImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExecutionType_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportanceRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartImportButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectFileButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileCoversionRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ImportEvents_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPORT_EVENTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANUALImportEvents_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem_ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EDPDataSet As PS_TOOL_DX.EDPDataSet
    Friend WithEvents MANUAL_IMPORTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MANUAL_IMPORTSTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.MANUAL_IMPORTSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager
    Friend WithEvents IMPORT_EVENTSTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.IMPORT_EVENTSTableAdapter
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents MANUAL_Procedures_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ManualImportProcedures_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ManualImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImportEvents_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents MANUALImportEvents_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSystemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem_ProgressPanel As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents IMPORT_EVENTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFileDirImport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrentFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastImportDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastImportTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInternalNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStrartImportNOTBINDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StartImportButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents SelectFileButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colProcNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents XtraSaveFileDialog1 As DevExpress.XtraEditors.XtraSaveFileDialog
    Friend WithEvents XtraFolderBrowserDialog1 As DevExpress.XtraEditors.XtraFolderBrowserDialog
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Add_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Save_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Delete_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Preview_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Close_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colExectutionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMultiselect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFileConvertion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRequestBusinessDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDeleteFileAfterImport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastImportUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExecutionType_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents colImportance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImportanceRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents FileCoversionRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFileExtraction As DevExpress.XtraGrid.Columns.GridColumn
End Class
