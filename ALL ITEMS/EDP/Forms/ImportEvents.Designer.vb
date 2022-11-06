<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportEvents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportEvents))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.EDPDataSet = New PS_TOOL_DX.EDPDataSet()
        Me.IMPORT_EVENTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMPORT_EVENTSTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.IMPORT_EVENTSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadImportEvents_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ImportEventsDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PopupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.Print_Export_ImportEvents_GridView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LoadEvents_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ImportEvents_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSystemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colIdnr = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTAG = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMODIFICATIONFLAG = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colINSTITUTIONNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn5 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBRANCHINFORMATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn6 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCITYHEADING = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn7 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSUBTYPEINDICATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn8 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALUEADDEDSERVICES = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn9 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colEXTRAINFO = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn10 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn11 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn12 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn13 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn14 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLOCATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn15 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCOUNTRYNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn16 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBNUMBER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn17 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBLOCATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn18 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBCOUNTRYNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn19 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUSER2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn20 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn21 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField48 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn22 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC112 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn23 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBICCODE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn24 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBRANCHCODE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn25 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCOUNTRY = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPORT_EVENTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportEventsDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportEventsDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportEvents_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colIdnr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTAG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMODIFICATIONFLAG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colINSTITUTIONNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBRANCHINFORMATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCITYHEADING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSUBTYPEINDICATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALUEADDEDSERVICES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colEXTRAINFO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLOCATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRYNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBNUMBER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBLOCATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBCOUNTRYNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUSER2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBICCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBRANCHCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RepositoryItemMemoExEdit1.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(650, 200)
        Me.RepositoryItemMemoExEdit1.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RepositoryItemMemoExEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick
        Me.RepositoryItemMemoExEdit1.ShowIcon = False
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'EDPDataSet
        '
        Me.EDPDataSet.DataSetName = "EDPDataSet"
        Me.EDPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IMPORT_EVENTSBindingSource
        '
        Me.IMPORT_EVENTSBindingSource.DataMember = "IMPORT EVENTS"
        Me.IMPORT_EVENTSBindingSource.DataSource = Me.EDPDataSet
        '
        'IMPORT_EVENTSTableAdapter
        '
        Me.IMPORT_EVENTSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_TABLE_COLUMNSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CLIENT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.CURRENT_USERSTableAdapter = Nothing
        Me.TableAdapterManager.IMPORT_EVENTSTableAdapter = Me.IMPORT_EVENTSTableAdapter
        Me.TableAdapterManager.MANUAL_IMPORTSTableAdapter = Nothing
        Me.TableAdapterManager.OCBS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILS_SECONDTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETER_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.SQL_PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(19, 6)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Date"
        Me.LabelControl1.Visible = False
        '
        'LoadImportEvents_btn
        '
        Me.LoadImportEvents_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadImportEvents_btn.ImageIndex = 6
        Me.LoadImportEvents_btn.ImageList = Me.ImageCollection1
        Me.LoadImportEvents_btn.Location = New System.Drawing.Point(142, 25)
        Me.LoadImportEvents_btn.Name = "LoadImportEvents_btn"
        Me.LoadImportEvents_btn.Size = New System.Drawing.Size(97, 22)
        Me.LoadImportEvents_btn.TabIndex = 21
        Me.LoadImportEvents_btn.Text = "Load Data"
        Me.LoadImportEvents_btn.Visible = False
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
        '
        'ImportEventsDateEdit
        '
        Me.ImportEventsDateEdit.EditValue = Nothing
        Me.ImportEventsDateEdit.Location = New System.Drawing.Point(19, 25)
        Me.ImportEventsDateEdit.Name = "ImportEventsDateEdit"
        Me.ImportEventsDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ImportEventsDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ImportEventsDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ImportEventsDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ImportEventsDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.ImportEventsDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ImportEventsDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImportEventsDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ImportEventsDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.ImportEventsDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ImportEventsDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.ImportEventsDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ImportEventsDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.ImportEventsDateEdit.Size = New System.Drawing.Size(117, 22)
        Me.ImportEventsDateEdit.TabIndex = 20
        Me.ImportEventsDateEdit.Visible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PopupContainerEdit1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_ImportEvents_GridView_btn)
        Me.LayoutControl1.Controls.Add(Me.LoadEvents_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1481, 728)
        Me.LayoutControl1.TabIndex = 23
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PopupContainerEdit1
        '
        Me.PopupContainerEdit1.Location = New System.Drawing.Point(111, 62)
        Me.PopupContainerEdit1.Name = "PopupContainerEdit1"
        Me.PopupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit1.Size = New System.Drawing.Size(50, 20)
        Me.PopupContainerEdit1.StyleController = Me.LayoutControl1
        Me.PopupContainerEdit1.TabIndex = 8
        '
        'Print_Export_ImportEvents_GridView_btn
        '
        Me.Print_Export_ImportEvents_GridView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_ImportEvents_GridView_btn.ImageIndex = 2
        Me.Print_Export_ImportEvents_GridView_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_ImportEvents_GridView_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_ImportEvents_GridView_btn.Name = "Print_Export_ImportEvents_GridView_btn"
        Me.Print_Export_ImportEvents_GridView_btn.Size = New System.Drawing.Size(164, 22)
        Me.Print_Export_ImportEvents_GridView_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_ImportEvents_GridView_btn.TabIndex = 6
        Me.Print_Export_ImportEvents_GridView_btn.Text = "Print or Export"
        '
        'LoadEvents_btn
        '
        Me.LoadEvents_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadEvents_btn.ImageIndex = 6
        Me.LoadEvents_btn.ImageList = Me.ImageCollection1
        Me.LoadEvents_btn.Location = New System.Drawing.Point(1245, 24)
        Me.LoadEvents_btn.Name = "LoadEvents_btn"
        Me.LoadEvents_btn.Size = New System.Drawing.Size(212, 22)
        Me.LoadEvents_btn.StyleController = Me.LayoutControl1
        Me.LoadEvents_btn.TabIndex = 4
        Me.LoadEvents_btn.Text = "Load Events"
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.IMPORT_EVENTSBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.ImportEvents_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemPopupContainerEdit1, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoExEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1457, 654)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ImportEvents_BasicView, Me.LayoutView1})
        '
        'ImportEvents_BasicView
        '
        Me.ImportEvents_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ImportEvents_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ImportEvents_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ImportEvents_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ImportEvents_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ImportEvents_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colProcDate, Me.colProcTime, Me.colEvent, Me.colProcName, Me.colSystemName})
        Me.ImportEvents_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
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
        Me.ImportEvents_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3, StyleFormatCondition4})
        Me.ImportEvents_BasicView.GridControl = Me.GridControl1
        Me.ImportEvents_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}")})
        Me.ImportEvents_BasicView.Name = "ImportEvents_BasicView"
        Me.ImportEvents_BasicView.OptionsCustomization.AllowRowSizing = True
        Me.ImportEvents_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ImportEvents_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ImportEvents_BasicView.OptionsFind.AlwaysVisible = True
        Me.ImportEvents_BasicView.OptionsSelection.MultiSelect = True
        Me.ImportEvents_BasicView.OptionsView.ColumnAutoWidth = False
        Me.ImportEvents_BasicView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.ImportEvents_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ImportEvents_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.ImportEvents_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ImportEvents_BasicView.OptionsView.ShowFooter = True
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
        'colProcName
        '
        Me.colProcName.AppearanceCell.Options.UseTextOptions = True
        Me.colProcName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colProcName.Caption = "Procedure Name"
        Me.colProcName.FieldName = "ProcName"
        Me.colProcName.Name = "colProcName"
        Me.colProcName.OptionsColumn.AllowEdit = False
        Me.colProcName.OptionsColumn.ReadOnly = True
        Me.colProcName.Visible = True
        Me.colProcName.VisibleIndex = 3
        Me.colProcName.Width = 329
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
        Me.colSystemName.Width = 111
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
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
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
        'RepositoryItemPopupContainerEdit1
        '
        Me.RepositoryItemPopupContainerEdit1.AutoHeight = False
        Me.RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        '
        'LayoutView1
        '
        Me.LayoutView1.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4, Me.LayoutViewColumn5, Me.LayoutViewColumn6, Me.LayoutViewColumn7, Me.LayoutViewColumn8, Me.LayoutViewColumn9, Me.LayoutViewColumn10, Me.LayoutViewColumn11, Me.LayoutViewColumn12, Me.LayoutViewColumn13, Me.LayoutViewColumn14, Me.LayoutViewColumn15, Me.LayoutViewColumn16, Me.LayoutViewColumn17, Me.LayoutViewColumn18, Me.LayoutViewColumn19, Me.LayoutViewColumn20, Me.LayoutViewColumn21, Me.LayoutViewColumn22, Me.LayoutViewColumn23, Me.LayoutViewColumn24, Me.LayoutViewColumn25})
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colBIC112, Me.LayoutViewField48, Me.layoutViewField_colUSER2})
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsCustomization.AllowFilter = False
        Me.LayoutView1.OptionsCustomization.AllowSort = False
        Me.LayoutView1.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView1.OptionsCustomization.ShowGroupView = False
        Me.LayoutView1.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView1.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView1.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsPrint.PrintSelectedCardsOnly = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn1.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn1.FieldName = "Idnr"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_colIdnr
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colIdnr
        '
        Me.layoutViewField_colIdnr.EditorPreferredWidth = 86
        Me.layoutViewField_colIdnr.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colIdnr.Name = "layoutViewField_colIdnr"
        Me.layoutViewField_colIdnr.Size = New System.Drawing.Size(206, 63)
        Me.layoutViewField_colIdnr.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn2.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn2.FieldName = "TAG"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_colTAG
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        '
        'layoutViewField_colTAG
        '
        Me.layoutViewField_colTAG.EditorPreferredWidth = 383
        Me.layoutViewField_colTAG.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colTAG.Name = "layoutViewField_colTAG"
        Me.layoutViewField_colTAG.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colTAG.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn3.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn3.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_colMODIFICATIONFLAG
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        '
        'layoutViewField_colMODIFICATIONFLAG
        '
        Me.layoutViewField_colMODIFICATIONFLAG.EditorPreferredWidth = 383
        Me.layoutViewField_colMODIFICATIONFLAG.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colMODIFICATIONFLAG.Name = "layoutViewField_colMODIFICATIONFLAG"
        Me.layoutViewField_colMODIFICATIONFLAG.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colMODIFICATIONFLAG.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn4.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn4.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn4.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn4.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn4.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn4.LayoutViewField = Me.layoutViewField_colINSTITUTIONNAME
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        '
        'layoutViewField_colINSTITUTIONNAME
        '
        Me.layoutViewField_colINSTITUTIONNAME.EditorPreferredWidth = 371
        Me.layoutViewField_colINSTITUTIONNAME.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colINSTITUTIONNAME.Name = "layoutViewField_colINSTITUTIONNAME"
        Me.layoutViewField_colINSTITUTIONNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colINSTITUTIONNAME.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn5
        '
        Me.LayoutViewColumn5.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn5.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn5.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn5.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn5.LayoutViewField = Me.layoutViewField_colBRANCHINFORMATION
        Me.LayoutViewColumn5.Name = "LayoutViewColumn5"
        '
        'layoutViewField_colBRANCHINFORMATION
        '
        Me.layoutViewField_colBRANCHINFORMATION.EditorPreferredWidth = 371
        Me.layoutViewField_colBRANCHINFORMATION.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colBRANCHINFORMATION.Name = "layoutViewField_colBRANCHINFORMATION"
        Me.layoutViewField_colBRANCHINFORMATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colBRANCHINFORMATION.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn6
        '
        Me.LayoutViewColumn6.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn6.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn6.FieldName = "CITY HEADING"
        Me.LayoutViewColumn6.LayoutViewField = Me.layoutViewField_colCITYHEADING
        Me.LayoutViewColumn6.Name = "LayoutViewColumn6"
        '
        'layoutViewField_colCITYHEADING
        '
        Me.layoutViewField_colCITYHEADING.EditorPreferredWidth = 371
        Me.layoutViewField_colCITYHEADING.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colCITYHEADING.Name = "layoutViewField_colCITYHEADING"
        Me.layoutViewField_colCITYHEADING.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCITYHEADING.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn7
        '
        Me.LayoutViewColumn7.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn7.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn7.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn7.LayoutViewField = Me.layoutViewField_colSUBTYPEINDICATION
        Me.LayoutViewColumn7.Name = "LayoutViewColumn7"
        '
        'layoutViewField_colSUBTYPEINDICATION
        '
        Me.layoutViewField_colSUBTYPEINDICATION.EditorPreferredWidth = 86
        Me.layoutViewField_colSUBTYPEINDICATION.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colSUBTYPEINDICATION.Name = "layoutViewField_colSUBTYPEINDICATION"
        Me.layoutViewField_colSUBTYPEINDICATION.Size = New System.Drawing.Size(206, 20)
        Me.layoutViewField_colSUBTYPEINDICATION.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn8
        '
        Me.LayoutViewColumn8.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn8.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn8.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn8.LayoutViewField = Me.layoutViewField_colVALUEADDEDSERVICES
        Me.LayoutViewColumn8.Name = "LayoutViewColumn8"
        '
        'layoutViewField_colVALUEADDEDSERVICES
        '
        Me.layoutViewField_colVALUEADDEDSERVICES.EditorPreferredWidth = 371
        Me.layoutViewField_colVALUEADDEDSERVICES.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colVALUEADDEDSERVICES.Name = "layoutViewField_colVALUEADDEDSERVICES"
        Me.layoutViewField_colVALUEADDEDSERVICES.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colVALUEADDEDSERVICES.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn9
        '
        Me.LayoutViewColumn9.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn9.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn9.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn9.LayoutViewField = Me.layoutViewField_colEXTRAINFO
        Me.LayoutViewColumn9.Name = "LayoutViewColumn9"
        '
        'layoutViewField_colEXTRAINFO
        '
        Me.layoutViewField_colEXTRAINFO.EditorPreferredWidth = 383
        Me.layoutViewField_colEXTRAINFO.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colEXTRAINFO.Name = "layoutViewField_colEXTRAINFO"
        Me.layoutViewField_colEXTRAINFO.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colEXTRAINFO.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn10
        '
        Me.LayoutViewColumn10.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn10.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn10.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn10.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS1
        Me.LayoutViewColumn10.Name = "LayoutViewColumn10"
        '
        'layoutViewField_colPHYSICALADDRESS1
        '
        Me.layoutViewField_colPHYSICALADDRESS1.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colPHYSICALADDRESS1.Name = "layoutViewField_colPHYSICALADDRESS1"
        Me.layoutViewField_colPHYSICALADDRESS1.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS1.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn11
        '
        Me.LayoutViewColumn11.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn11.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn11.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn11.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS2
        Me.LayoutViewColumn11.Name = "LayoutViewColumn11"
        '
        'layoutViewField_colPHYSICALADDRESS2
        '
        Me.layoutViewField_colPHYSICALADDRESS2.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS2.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colPHYSICALADDRESS2.Name = "layoutViewField_colPHYSICALADDRESS2"
        Me.layoutViewField_colPHYSICALADDRESS2.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS2.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn12
        '
        Me.LayoutViewColumn12.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn12.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn12.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn12.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS3
        Me.LayoutViewColumn12.Name = "LayoutViewColumn12"
        '
        'layoutViewField_colPHYSICALADDRESS3
        '
        Me.layoutViewField_colPHYSICALADDRESS3.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS3.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colPHYSICALADDRESS3.Name = "layoutViewField_colPHYSICALADDRESS3"
        Me.layoutViewField_colPHYSICALADDRESS3.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS3.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn13
        '
        Me.LayoutViewColumn13.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn13.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn13.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn13.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS4
        Me.LayoutViewColumn13.Name = "LayoutViewColumn13"
        '
        'layoutViewField_colPHYSICALADDRESS4
        '
        Me.layoutViewField_colPHYSICALADDRESS4.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS4.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colPHYSICALADDRESS4.Name = "layoutViewField_colPHYSICALADDRESS4"
        Me.layoutViewField_colPHYSICALADDRESS4.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS4.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn14
        '
        Me.LayoutViewColumn14.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn14.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn14.FieldName = "LOCATION"
        Me.LayoutViewColumn14.LayoutViewField = Me.layoutViewField_colLOCATION
        Me.LayoutViewColumn14.Name = "LayoutViewColumn14"
        '
        'layoutViewField_colLOCATION
        '
        Me.layoutViewField_colLOCATION.EditorPreferredWidth = 384
        Me.layoutViewField_colLOCATION.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colLOCATION.Name = "layoutViewField_colLOCATION"
        Me.layoutViewField_colLOCATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colLOCATION.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn15
        '
        Me.LayoutViewColumn15.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn15.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn15.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn15.LayoutViewField = Me.layoutViewField_colCOUNTRYNAME
        Me.LayoutViewColumn15.Name = "LayoutViewColumn15"
        '
        'layoutViewField_colCOUNTRYNAME
        '
        Me.layoutViewField_colCOUNTRYNAME.EditorPreferredWidth = 384
        Me.layoutViewField_colCOUNTRYNAME.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colCOUNTRYNAME.Name = "layoutViewField_colCOUNTRYNAME"
        Me.layoutViewField_colCOUNTRYNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCOUNTRYNAME.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn16
        '
        Me.LayoutViewColumn16.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn16.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn16.FieldName = "POB NUMBER"
        Me.LayoutViewColumn16.LayoutViewField = Me.layoutViewField_colPOBNUMBER
        Me.LayoutViewColumn16.Name = "LayoutViewColumn16"
        '
        'layoutViewField_colPOBNUMBER
        '
        Me.layoutViewField_colPOBNUMBER.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBNUMBER.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colPOBNUMBER.Name = "layoutViewField_colPOBNUMBER"
        Me.layoutViewField_colPOBNUMBER.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBNUMBER.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn17
        '
        Me.LayoutViewColumn17.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn17.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn17.FieldName = "POB LOCATION"
        Me.LayoutViewColumn17.LayoutViewField = Me.layoutViewField_colPOBLOCATION
        Me.LayoutViewColumn17.Name = "LayoutViewColumn17"
        '
        'layoutViewField_colPOBLOCATION
        '
        Me.layoutViewField_colPOBLOCATION.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBLOCATION.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colPOBLOCATION.Name = "layoutViewField_colPOBLOCATION"
        Me.layoutViewField_colPOBLOCATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBLOCATION.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn18
        '
        Me.LayoutViewColumn18.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn18.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn18.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn18.LayoutViewField = Me.layoutViewField_colPOBCOUNTRYNAME
        Me.LayoutViewColumn18.Name = "LayoutViewColumn18"
        '
        'layoutViewField_colPOBCOUNTRYNAME
        '
        Me.layoutViewField_colPOBCOUNTRYNAME.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBCOUNTRYNAME.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colPOBCOUNTRYNAME.Name = "layoutViewField_colPOBCOUNTRYNAME"
        Me.layoutViewField_colPOBCOUNTRYNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBCOUNTRYNAME.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn19
        '
        Me.LayoutViewColumn19.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn19.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn19.CustomizationCaption = "USER"
        Me.LayoutViewColumn19.FieldName = "USER"
        Me.LayoutViewColumn19.LayoutViewField = Me.layoutViewField_colUSER2
        Me.LayoutViewColumn19.Name = "LayoutViewColumn19"
        Me.LayoutViewColumn19.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colUSER2
        '
        Me.layoutViewField_colUSER2.EditorPreferredWidth = 20
        Me.layoutViewField_colUSER2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUSER2.Name = "layoutViewField_colUSER2"
        Me.layoutViewField_colUSER2.Size = New System.Drawing.Size(527, 612)
        Me.layoutViewField_colUSER2.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn20
        '
        Me.LayoutViewColumn20.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn20.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn20.ColumnEdit = Me.RepositoryItemComboBox1
        Me.LayoutViewColumn20.FieldName = "VALID"
        Me.LayoutViewColumn20.LayoutViewField = Me.layoutViewField_colVALID
        Me.LayoutViewColumn20.Name = "LayoutViewColumn20"
        '
        'layoutViewField_colVALID
        '
        Me.layoutViewField_colVALID.EditorPreferredWidth = 30
        Me.layoutViewField_colVALID.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colVALID.Name = "layoutViewField_colVALID"
        Me.layoutViewField_colVALID.Size = New System.Drawing.Size(162, 20)
        Me.layoutViewField_colVALID.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn21
        '
        Me.LayoutViewColumn21.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn21.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn21.CustomizationCaption = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn21.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn21.LayoutViewField = Me.LayoutViewField48
        Me.LayoutViewColumn21.Name = "LayoutViewColumn21"
        Me.LayoutViewColumn21.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField48
        '
        Me.LayoutViewField48.EditorPreferredWidth = 20
        Me.LayoutViewField48.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField48.Name = "LayoutViewField48"
        Me.LayoutViewField48.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField48.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn22
        '
        Me.LayoutViewColumn22.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn22.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn22.CustomizationCaption = "BIC11"
        Me.LayoutViewColumn22.FieldName = "BIC11"
        Me.LayoutViewColumn22.LayoutViewField = Me.layoutViewField_colBIC112
        Me.LayoutViewColumn22.Name = "LayoutViewColumn22"
        Me.LayoutViewColumn22.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBIC112
        '
        Me.layoutViewField_colBIC112.EditorPreferredWidth = 20
        Me.layoutViewField_colBIC112.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBIC112.Name = "layoutViewField_colBIC112"
        Me.layoutViewField_colBIC112.Size = New System.Drawing.Size(527, 612)
        Me.layoutViewField_colBIC112.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn23
        '
        Me.LayoutViewColumn23.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn23.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn23.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn23.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn23.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn23.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn23.ColumnEdit = Me.RepositoryItemTextEditBIC8
        Me.LayoutViewColumn23.FieldName = "BIC CODE"
        Me.LayoutViewColumn23.ImageIndex = 0
        Me.LayoutViewColumn23.LayoutViewField = Me.layoutViewField_colBICCODE
        Me.LayoutViewColumn23.Name = "LayoutViewColumn23"
        '
        'layoutViewField_colBICCODE
        '
        Me.layoutViewField_colBICCODE.EditorPreferredWidth = 93
        Me.layoutViewField_colBICCODE.ImageIndex = 0
        Me.layoutViewField_colBICCODE.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBICCODE.Name = "layoutViewField_colBICCODE"
        Me.layoutViewField_colBICCODE.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colBICCODE.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn24
        '
        Me.LayoutViewColumn24.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn24.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn24.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn24.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn24.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn24.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn24.ColumnEdit = Me.RepositoryItemTextEditBIC3
        Me.LayoutViewColumn24.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn24.LayoutViewField = Me.layoutViewField_colBRANCHCODE
        Me.LayoutViewColumn24.Name = "LayoutViewColumn24"
        '
        'layoutViewField_colBRANCHCODE
        '
        Me.layoutViewField_colBRANCHCODE.EditorPreferredWidth = 51
        Me.layoutViewField_colBRANCHCODE.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colBRANCHCODE.Name = "layoutViewField_colBRANCHCODE"
        Me.layoutViewField_colBRANCHCODE.Size = New System.Drawing.Size(183, 20)
        Me.layoutViewField_colBRANCHCODE.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn25
        '
        Me.LayoutViewColumn25.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn25.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn25.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn25.FieldName = "COUNTRY"
        Me.LayoutViewColumn25.LayoutViewField = Me.layoutViewField_colCOUNTRY
        Me.LayoutViewColumn25.Name = "LayoutViewColumn25"
        Me.LayoutViewColumn25.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCOUNTRY
        '
        Me.layoutViewField_colCOUNTRY.EditorPreferredWidth = 384
        Me.layoutViewField_colCOUNTRY.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colCOUNTRY.Name = "layoutViewField_colCOUNTRY"
        Me.layoutViewField_colCOUNTRY.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCOUNTRY.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PopupContainerEdit1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(153, 649)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1481, 728)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1461, 658)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1461, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LoadEvents_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1221, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(216, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(168, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1053, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_ImportEvents_GridView_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(168, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
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
        'ImportEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1481, 728)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadImportEvents_btn)
        Me.Controls.Add(Me.ImportEventsDateEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportEvents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Events"
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPORT_EVENTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportEventsDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportEventsDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportEvents_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colIdnr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTAG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMODIFICATIONFLAG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colINSTITUTIONNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBRANCHINFORMATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCITYHEADING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSUBTYPEINDICATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALUEADDEDSERVICES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colEXTRAINFO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLOCATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRYNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBNUMBER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBLOCATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBCOUNTRYNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUSER2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBICCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBRANCHCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EDPDataSet As PS_TOOL_DX.EDPDataSet
    Friend WithEvents IMPORT_EVENTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IMPORT_EVENTSTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.IMPORT_EVENTSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadImportEvents_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImportEventsDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PopupContainerEdit1 As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents Print_Export_ImportEvents_GridView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LoadEvents_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ImportEvents_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colIdnr As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colTAG As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMODIFICATIONFLAG As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colINSTITUTIONNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn5 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBRANCHINFORMATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn6 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCITYHEADING As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn7 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSUBTYPEINDICATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn8 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALUEADDEDSERVICES As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn9 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colEXTRAINFO As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn10 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn11 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn12 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn13 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn14 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLOCATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn15 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCOUNTRYNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn16 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBNUMBER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn17 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBLOCATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn18 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBCOUNTRYNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn19 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUSER2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn20 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn21 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField48 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn22 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC112 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn23 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBICCODE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn24 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBRANCHCODE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn25 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCOUNTRY As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSystemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
