<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankPhones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankPhones))
        Me.EDPDataSet = New PS_TOOL_DX.EDPDataSet()
        Me.BANK_PhonesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BANK_PhonesTableAdapter = New PS_TOOL_DX.EDPDataSetTableAdapters.BANK_PhonesTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BankPhones_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKundenkonto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OdasImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colKartenNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTelefonNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRahmenvertragNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeschreibung = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSonstiges = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colProvider = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BT_CP_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinessTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colObligorRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractCollateralID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNetCreditOutstandingAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBusinessTypeLive = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BANK_PhonesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintableComponentLink1.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankPhones_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_CP_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EDPDataSet
        '
        Me.EDPDataSet.DataSetName = "EDPDataSet"
        Me.EDPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BANK_PhonesBindingSource
        '
        Me.BANK_PhonesBindingSource.DataMember = "BANK_Phones"
        Me.BANK_PhonesBindingSource.DataSource = Me.EDPDataSet
        '
        'BANK_PhonesTableAdapter
        '
        Me.BANK_PhonesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_TABLE_COLUMNSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BAISLastProcFileTableAdapter = Nothing
        Me.TableAdapterManager.BANK_PhonesTableAdapter = Me.BANK_PhonesTableAdapter
        Me.TableAdapterManager.CLIENT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.IMPORT_EVENTSTableAdapter = Nothing
        Me.TableAdapterManager.MANUAL_IMPORTSTableAdapter = Nothing
        Me.TableAdapterManager.OCBS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.OCBSLastProcFileTableAdapter = Nothing
        Me.TableAdapterManager.ODAS_IMPORT_PROCEDURESTableAdapter = Nothing
        Me.TableAdapterManager.ODASLastProcFileTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        '
        '
        '
        Me.PrintableComponentLink1.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.BANK_PhonesBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.BankPhones_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1132, 628)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BankPhones_BasicView, Me.BT_CP_Details_GridView, Me.LayoutView1})
        '
        'BankPhones_BasicView
        '
        Me.BankPhones_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BankPhones_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BankPhones_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BankPhones_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BankPhones_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BankPhones_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colKundenkonto, Me.colKartenNr, Me.colTelefonNr, Me.colRahmenvertragNr, Me.colBeschreibung, Me.colSonstiges, Me.colProvider, Me.colValid})
        Me.BankPhones_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BankPhones_BasicView.GridControl = Me.GridControl1
        Me.BankPhones_BasicView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BankPhones_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessType", Nothing, "{0:n2}")})
        Me.BankPhones_BasicView.Name = "BankPhones_BasicView"
        Me.BankPhones_BasicView.NewItemRowText = "Add new Phone"
        Me.BankPhones_BasicView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BankPhones_BasicView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BankPhones_BasicView.OptionsCustomization.AllowRowSizing = True
        Me.BankPhones_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BankPhones_BasicView.OptionsFind.AlwaysVisible = True
        Me.BankPhones_BasicView.OptionsPrint.PrintDetails = True
        Me.BankPhones_BasicView.OptionsSelection.MultiSelect = True
        Me.BankPhones_BasicView.OptionsView.ColumnAutoWidth = False
        Me.BankPhones_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BankPhones_BasicView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.BankPhones_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.BankPhones_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BankPhones_BasicView.OptionsView.ShowFooter = True
        Me.BankPhones_BasicView.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colKundenkonto
        '
        Me.colKundenkonto.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colKundenkonto.FieldName = "Kundenkonto"
        Me.colKundenkonto.Name = "colKundenkonto"
        Me.colKundenkonto.Visible = True
        Me.colKundenkonto.VisibleIndex = 1
        Me.colKundenkonto.Width = 120
        '
        'OdasImportProcedureRepositoryItemTextEdit
        '
        Me.OdasImportProcedureRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AutoHeight = False
        Me.OdasImportProcedureRepositoryItemTextEdit.Name = "OdasImportProcedureRepositoryItemTextEdit"
        '
        'colKartenNr
        '
        Me.colKartenNr.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colKartenNr.FieldName = "KartenNr"
        Me.colKartenNr.Name = "colKartenNr"
        Me.colKartenNr.Visible = True
        Me.colKartenNr.VisibleIndex = 2
        Me.colKartenNr.Width = 116
        '
        'colTelefonNr
        '
        Me.colTelefonNr.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colTelefonNr.FieldName = "TelefonNr"
        Me.colTelefonNr.Name = "colTelefonNr"
        Me.colTelefonNr.Visible = True
        Me.colTelefonNr.VisibleIndex = 3
        Me.colTelefonNr.Width = 137
        '
        'colRahmenvertragNr
        '
        Me.colRahmenvertragNr.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colRahmenvertragNr.FieldName = "RahmenvertragNr"
        Me.colRahmenvertragNr.Name = "colRahmenvertragNr"
        Me.colRahmenvertragNr.Visible = True
        Me.colRahmenvertragNr.VisibleIndex = 4
        Me.colRahmenvertragNr.Width = 115
        '
        'colBeschreibung
        '
        Me.colBeschreibung.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colBeschreibung.FieldName = "Beschreibung"
        Me.colBeschreibung.Name = "colBeschreibung"
        Me.colBeschreibung.Visible = True
        Me.colBeschreibung.VisibleIndex = 5
        Me.colBeschreibung.Width = 292
        '
        'colSonstiges
        '
        Me.colSonstiges.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSonstiges.FieldName = "Sonstiges"
        Me.colSonstiges.Name = "colSonstiges"
        Me.colSonstiges.Visible = True
        Me.colSonstiges.VisibleIndex = 6
        Me.colSonstiges.Width = 299
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.AllowFocused = False
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit2.Appearance.Options.UseForeColor = True
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
        Me.RepositoryItemMemoExEdit2.ShowIcon = False
        '
        'colProvider
        '
        Me.colProvider.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
        Me.colProvider.FieldName = "Provider"
        Me.colProvider.Name = "colProvider"
        Me.colProvider.Visible = True
        Me.colProvider.VisibleIndex = 0
        Me.colProvider.Width = 111
        '
        'colValid
        '
        Me.colValid.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colValid.FieldName = "Valid"
        Me.colValid.Name = "colValid"
        Me.colValid.Visible = True
        Me.colValid.VisibleIndex = 7
        Me.colValid.Width = 105
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
        Me.ValidRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CANCELLED", "N", 3)})
        Me.ValidRepositoryItemImageComboBox.Name = "ValidRepositoryItemImageComboBox"
        Me.ValidRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
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
        'BT_CP_Details_GridView
        '
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_CP_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colBusinessTypeName, Me.colObligorRate, Me.colContractType1, Me.colProductType1, Me.GridColumn6, Me.colAccountType, Me.GridColumn7, Me.colClientNo, Me.colContractCollateralID, Me.colMaturityDate, Me.GridColumn8, Me.colOrgCcy, Me.GridColumn9, Me.GridColumn10, Me.colNetCreditOutstandingAmountEUR, Me.colPD, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.colRiskDate, Me.colIdBusinessTypeLive})
        Me.BT_CP_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_CP_Details_GridView.GridControl = Me.GridControl1
        Me.BT_CP_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BT_CP_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.Credit Ou" & _
                    "tstanding (EUR Equ)", Me.GridColumn10, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.NetCredit" & _
                    " Risk Amount(EUR Equ)", Me.GridColumn12, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.NetCredit" & _
                    "OutstandingAmountEUR", Me.GridColumn13, "{0:n2}")})
        Me.BT_CP_Details_GridView.Name = "BT_CP_Details_GridView"
        Me.BT_CP_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_CP_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_CP_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_CP_Details_GridView.OptionsSelection.MultiSelect = True
        Me.BT_CP_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_CP_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_CP_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_CP_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_CP_Details_GridView.OptionsView.ShowFooter = True
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colBusinessTypeName
        '
        Me.colBusinessTypeName.FieldName = "BusinessTypeName"
        Me.colBusinessTypeName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colBusinessTypeName.Name = "colBusinessTypeName"
        Me.colBusinessTypeName.OptionsColumn.AllowEdit = False
        Me.colBusinessTypeName.OptionsColumn.ReadOnly = True
        Me.colBusinessTypeName.Visible = True
        Me.colBusinessTypeName.VisibleIndex = 0
        Me.colBusinessTypeName.Width = 267
        '
        'colObligorRate
        '
        Me.colObligorRate.FieldName = "Obligor Rate"
        Me.colObligorRate.Name = "colObligorRate"
        Me.colObligorRate.OptionsColumn.AllowEdit = False
        Me.colObligorRate.OptionsColumn.ReadOnly = True
        Me.colObligorRate.Visible = True
        Me.colObligorRate.VisibleIndex = 4
        Me.colObligorRate.Width = 91
        '
        'colContractType1
        '
        Me.colContractType1.FieldName = "Contract Type"
        Me.colContractType1.Name = "colContractType1"
        Me.colContractType1.OptionsColumn.AllowEdit = False
        Me.colContractType1.OptionsColumn.ReadOnly = True
        Me.colContractType1.Visible = True
        Me.colContractType1.VisibleIndex = 5
        Me.colContractType1.Width = 132
        '
        'colProductType1
        '
        Me.colProductType1.FieldName = "Product Type"
        Me.colProductType1.Name = "colProductType1"
        Me.colProductType1.OptionsColumn.AllowEdit = False
        Me.colProductType1.OptionsColumn.ReadOnly = True
        Me.colProductType1.Visible = True
        Me.colProductType1.VisibleIndex = 6
        Me.colProductType1.Width = 118
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "GL Master / Account Type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        Me.GridColumn6.Width = 145
        '
        'colAccountType
        '
        Me.colAccountType.FieldName = "Account Type"
        Me.colAccountType.Name = "colAccountType"
        Me.colAccountType.OptionsColumn.AllowEdit = False
        Me.colAccountType.OptionsColumn.ReadOnly = True
        Me.colAccountType.Visible = True
        Me.colAccountType.VisibleIndex = 8
        Me.colAccountType.Width = 99
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn7.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 331
        '
        'colClientNo
        '
        Me.colClientNo.FieldName = "Client No"
        Me.colClientNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.VisibleIndex = 1
        Me.colClientNo.Width = 90
        '
        'colContractCollateralID
        '
        Me.colContractCollateralID.AppearanceCell.Options.UseTextOptions = True
        Me.colContractCollateralID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colContractCollateralID.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID.Name = "colContractCollateralID"
        Me.colContractCollateralID.OptionsColumn.AllowEdit = False
        Me.colContractCollateralID.OptionsColumn.ReadOnly = True
        Me.colContractCollateralID.Visible = True
        Me.colContractCollateralID.VisibleIndex = 3
        Me.colContractCollateralID.Width = 122
        '
        'colMaturityDate
        '
        Me.colMaturityDate.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturityDate.FieldName = "Maturity Date"
        Me.colMaturityDate.Name = "colMaturityDate"
        Me.colMaturityDate.OptionsColumn.AllowEdit = False
        Me.colMaturityDate.OptionsColumn.ReadOnly = True
        Me.colMaturityDate.Visible = True
        Me.colMaturityDate.VisibleIndex = 9
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.FieldName = "Remaining Year(s) to Maturity"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 10
        Me.GridColumn8.Width = 163
        '
        'colOrgCcy
        '
        Me.colOrgCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrgCcy.FieldName = "Org Ccy"
        Me.colOrgCcy.Name = "colOrgCcy"
        Me.colOrgCcy.OptionsColumn.AllowEdit = False
        Me.colOrgCcy.OptionsColumn.ReadOnly = True
        Me.colOrgCcy.Visible = True
        Me.colOrgCcy.VisibleIndex = 11
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.DisplayFormat.FormatString = "n2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "Credit Outstanding (Org Ccy)"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 12
        Me.GridColumn9.Width = 163
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.DisplayFormat.FormatString = "n2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "Credit Outstanding (EUR Equ)"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", "{0:n2}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 13
        Me.GridColumn10.Width = 167
        '
        'colNetCreditOutstandingAmountEUR
        '
        Me.colNetCreditOutstandingAmountEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colNetCreditOutstandingAmountEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNetCreditOutstandingAmountEUR.DisplayFormat.FormatString = "n2"
        Me.colNetCreditOutstandingAmountEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colNetCreditOutstandingAmountEUR.FieldName = "NetCreditOutstandingAmountEUR"
        Me.colNetCreditOutstandingAmountEUR.Name = "colNetCreditOutstandingAmountEUR"
        Me.colNetCreditOutstandingAmountEUR.OptionsColumn.AllowEdit = False
        Me.colNetCreditOutstandingAmountEUR.OptionsColumn.ReadOnly = True
        Me.colNetCreditOutstandingAmountEUR.Visible = True
        Me.colNetCreditOutstandingAmountEUR.VisibleIndex = 14
        Me.colNetCreditOutstandingAmountEUR.Width = 202
        '
        'colPD
        '
        Me.colPD.AppearanceCell.Options.UseTextOptions = True
        Me.colPD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPD.FieldName = "PD"
        Me.colPD.Name = "colPD"
        Me.colPD.OptionsColumn.AllowEdit = False
        Me.colPD.OptionsColumn.ReadOnly = True
        Me.colPD.Visible = True
        Me.colPD.VisibleIndex = 15
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.FieldName = "(1-ER)"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 16
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.DisplayFormat.FormatString = "n2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "Credit Risk Amount(EUR Equ)"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", "{0:n2}")})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 17
        Me.GridColumn12.Width = 162
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.DisplayFormat.FormatString = "n2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "NetCredit Risk Amount(EUR Equ)"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", "{0:n2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 18
        Me.GridColumn13.Width = 177
        '
        'colRiskDate
        '
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.OptionsColumn.AllowEdit = False
        Me.colRiskDate.OptionsColumn.ReadOnly = True
        '
        'colIdBusinessTypeLive
        '
        Me.colIdBusinessTypeLive.FieldName = "IdBusinessTypeLive"
        Me.colIdBusinessTypeLive.Name = "colIdBusinessTypeLive"
        Me.colIdBusinessTypeLive.OptionsColumn.AllowEdit = False
        Me.colIdBusinessTypeLive.OptionsColumn.ReadOnly = True
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
        Me.layoutViewField_colIdnr.TextToControlDistance = 5
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
        Me.layoutViewField_colTAG.TextToControlDistance = 5
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
        Me.layoutViewField_colMODIFICATIONFLAG.TextToControlDistance = 5
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn4.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn4.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn4.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn4.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
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
        Me.layoutViewField_colINSTITUTIONNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colBRANCHINFORMATION.TextToControlDistance = 5
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
        Me.layoutViewField_colCITYHEADING.TextToControlDistance = 5
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
        Me.layoutViewField_colSUBTYPEINDICATION.TextToControlDistance = 5
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
        Me.layoutViewField_colVALUEADDEDSERVICES.TextToControlDistance = 5
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
        Me.layoutViewField_colEXTRAINFO.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS1.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS2.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS3.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS4.TextToControlDistance = 5
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
        Me.layoutViewField_colLOCATION.TextToControlDistance = 5
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
        Me.layoutViewField_colCOUNTRYNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBNUMBER.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBLOCATION.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBCOUNTRYNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colUSER2.TextToControlDistance = 5
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
        Me.layoutViewField_colVALID.TextToControlDistance = 5
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
        Me.LayoutViewField48.TextToControlDistance = 5
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
        Me.layoutViewField_colBIC112.TextToControlDistance = 5
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
        Me.layoutViewField_colBICCODE.TextToControlDistance = 5
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
        Me.layoutViewField_colBRANCHCODE.TextToControlDistance = 5
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
        Me.layoutViewField_colCOUNTRY.TextToControlDistance = 5
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1156, 702)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(129, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 6
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1068, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(64, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1156, 702)
        Me.LayoutControlGroup1.Text = "Root"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1136, 632)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1136, 50)
        Me.LayoutControlGroup3.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1044, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(68, 26)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(133, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(911, 26)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(133, 26)
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'BankPhones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 702)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BankPhones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bank Phones"
        CType(Me.EDPDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BANK_PhonesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintableComponentLink1.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankPhones_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_CP_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EDPDataSet As PS_TOOL_DX.EDPDataSet
    Friend WithEvents BANK_PhonesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BANK_PhonesTableAdapter As PS_TOOL_DX.EDPDataSetTableAdapters.BANK_PhonesTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EDPDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BankPhones_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKundenkonto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OdasImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colKartenNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTelefonNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRahmenvertragNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeschreibung As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSonstiges As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colProvider As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BT_CP_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinessTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObligorRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNetCreditOutstandingAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBusinessTypeLive As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
