<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bank_Data
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bank_Data))
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.BANKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BANKTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.BANKTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colNameBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colBranchBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colStrasseBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colPLZBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colNUTS_3_Code = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colOrtBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colLandBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colBANKLOGO = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSteuerNr = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colUstID = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colWebsiteBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colTelBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFaxBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colBICBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colBLZBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colTELEXBank = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colHRB = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSEPACreditorID = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colLEI_Code = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colBAK_Nr = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCorep_ID = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colKreditgeber_ID = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colMFI_Code = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularRechtsDE = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularRechtsGB = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularRechtsGR = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularLinksDE = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularLinksGB = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFormularLinksGR = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colUNTERBEARBEITUNGVON = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colUSER = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.Printbtn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colSubbranchCodeHO = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.layoutViewField_colNameBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBranchBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colStrasseBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colPLZBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colOrtBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colLandBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSteuerNr = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colUstID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_GridColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colWebsiteBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colTelBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFaxBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBICBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBLZBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colTELEXBank = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colHRB = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSEPACreditorID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBAK_Nr = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCorep_ID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colKreditgeber_ID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colMFI_Code = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colNUTS_3_Code = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSubbranchCodeHO = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularRechtsDE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularRechtsGB = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularRechtsGR = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularLinksDE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularLinksGB = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFormularLinksGR = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colUNTERBEARBEITUNGVON = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBANKLOGO = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colUSER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BANKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNameBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBranchBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStrasseBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPLZBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOrtBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLandBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSteuerNr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUstID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_GridColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWebsiteBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTelBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFaxBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBICBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBLZBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTELEXBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colHRB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSEPACreditorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBAK_Nr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCorep_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colKreditgeber_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMFI_Code, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNUTS_3_Code, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSubbranchCodeHO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularRechtsDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularRechtsGB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularRechtsGR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularLinksDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularLinksGB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFormularLinksGR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBANKLOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BANKBindingSource
        '
        Me.BANKBindingSource.DataMember = "BANK"
        Me.BANKBindingSource.DataSource = Me.PSTOOLDataset
        '
        'BANKTableAdapter
        '
        Me.BANKTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Me.BANKTableAdapter
        Me.TableAdapterManager.CalendarTableAdapter = Nothing
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.BANKBindingSource
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.LayoutView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(925, 622)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LayoutView1})
        '
        'LayoutView1
        '
        Me.LayoutView1.ActiveFilterEnabled = False
        Me.LayoutView1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Cyan
        Me.LayoutView1.Appearance.FieldValue.Options.UseForeColor = True
        Me.LayoutView1.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Navy
        Me.LayoutView1.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.LayoutView1.CardMinSize = New System.Drawing.Size(277, 658)
        Me.LayoutView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID, Me.colNameBank, Me.colBranchBank, Me.colStrasseBank, Me.colPLZBank, Me.colNUTS_3_Code, Me.colOrtBank, Me.colLandBank, Me.colBANKLOGO, Me.colSteuerNr, Me.colUstID, Me.GridColumn1, Me.colWebsiteBank, Me.colTelBank, Me.colFaxBank, Me.colBICBank, Me.colBLZBank, Me.colTELEXBank, Me.colHRB, Me.colSEPACreditorID, Me.colLEI_Code, Me.colBAK_Nr, Me.colCorep_ID, Me.colKreditgeber_ID, Me.colMFI_Code, Me.colSubbranchCodeHO, Me.colFormularRechtsDE, Me.colFormularRechtsGB, Me.colFormularRechtsGR, Me.colFormularLinksDE, Me.colFormularLinksGB, Me.colFormularLinksGR, Me.colUNTERBEARBEITUNGVON, Me.colUSER})
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID, Me.layoutViewField_colFormularRechtsDE, Me.layoutViewField_colFormularRechtsGB, Me.layoutViewField_colFormularRechtsGR, Me.layoutViewField_colFormularLinksDE, Me.layoutViewField_colFormularLinksGB, Me.layoutViewField_colFormularLinksGR, Me.layoutViewField_colUNTERBEARBEITUNGVON, Me.layoutViewField_colBANKLOGO, Me.layoutViewField_colUSER})
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutView1.OptionsBehavior.AllowPanCards = False
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsCustomization.AllowFilter = False
        Me.LayoutView1.OptionsCustomization.AllowSort = False
        Me.LayoutView1.OptionsCustomization.ShowGroupCardCaptions = False
        Me.LayoutView1.OptionsCustomization.ShowGroupCardIndents = False
        Me.LayoutView1.OptionsCustomization.ShowGroupCards = False
        Me.LayoutView1.OptionsCustomization.ShowGroupFields = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnablePanButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowPanButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.LayoutViewField = Me.layoutViewField_colID
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colNameBank
        '
        Me.colNameBank.Caption = "Name"
        Me.colNameBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colNameBank.FieldName = "Name Bank"
        Me.colNameBank.LayoutViewField = Me.layoutViewField_colNameBank
        Me.colNameBank.Name = "colNameBank"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'colBranchBank
        '
        Me.colBranchBank.Caption = "Branch"
        Me.colBranchBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBranchBank.FieldName = "Branch Bank"
        Me.colBranchBank.LayoutViewField = Me.layoutViewField_colBranchBank
        Me.colBranchBank.Name = "colBranchBank"
        '
        'colStrasseBank
        '
        Me.colStrasseBank.Caption = "Strasse"
        Me.colStrasseBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colStrasseBank.FieldName = "Strasse Bank"
        Me.colStrasseBank.LayoutViewField = Me.layoutViewField_colStrasseBank
        Me.colStrasseBank.Name = "colStrasseBank"
        '
        'colPLZBank
        '
        Me.colPLZBank.Caption = "PLZ"
        Me.colPLZBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colPLZBank.FieldName = "PLZ Bank"
        Me.colPLZBank.LayoutViewField = Me.layoutViewField_colPLZBank
        Me.colPLZBank.Name = "colPLZBank"
        '
        'colNUTS_3_Code
        '
        Me.colNUTS_3_Code.Caption = "NUTS 3 Code"
        Me.colNUTS_3_Code.FieldName = "NUTS_3_Code"
        Me.colNUTS_3_Code.LayoutViewField = Me.layoutViewField_colNUTS_3_Code
        Me.colNUTS_3_Code.Name = "colNUTS_3_Code"
        Me.colNUTS_3_Code.OptionsColumn.AllowEdit = False
        Me.colNUTS_3_Code.OptionsColumn.ReadOnly = True
        '
        'colOrtBank
        '
        Me.colOrtBank.Caption = "Ort"
        Me.colOrtBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colOrtBank.FieldName = "Ort Bank"
        Me.colOrtBank.LayoutViewField = Me.layoutViewField_colOrtBank
        Me.colOrtBank.Name = "colOrtBank"
        '
        'colLandBank
        '
        Me.colLandBank.Caption = "Land"
        Me.colLandBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colLandBank.FieldName = "Land Bank"
        Me.colLandBank.LayoutViewField = Me.layoutViewField_colLandBank
        Me.colLandBank.Name = "colLandBank"
        '
        'colBANKLOGO
        '
        Me.colBANKLOGO.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBANKLOGO.FieldName = "BANK LOGO"
        Me.colBANKLOGO.LayoutViewField = Me.layoutViewField_colBANKLOGO
        Me.colBANKLOGO.Name = "colBANKLOGO"
        '
        'colSteuerNr
        '
        Me.colSteuerNr.Caption = "Steuer Nr"
        Me.colSteuerNr.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colSteuerNr.FieldName = "SteuerNr"
        Me.colSteuerNr.LayoutViewField = Me.layoutViewField_colSteuerNr
        Me.colSteuerNr.Name = "colSteuerNr"
        '
        'colUstID
        '
        Me.colUstID.Caption = "Umsatzsteuer ID"
        Me.colUstID.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colUstID.FieldName = "UstID"
        Me.colUstID.LayoutViewField = Me.layoutViewField_colUstID
        Me.colUstID.Name = "colUstID"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "E-Mail"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn1.FieldName = "E-Mail Bank"
        Me.GridColumn1.LayoutViewField = Me.layoutViewField_GridColumn1
        Me.GridColumn1.Name = "GridColumn1"
        '
        'colWebsiteBank
        '
        Me.colWebsiteBank.Caption = "Webseite"
        Me.colWebsiteBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colWebsiteBank.FieldName = "Website Bank"
        Me.colWebsiteBank.LayoutViewField = Me.layoutViewField_colWebsiteBank
        Me.colWebsiteBank.Name = "colWebsiteBank"
        '
        'colTelBank
        '
        Me.colTelBank.Caption = "Tel."
        Me.colTelBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colTelBank.FieldName = "Tel Bank"
        Me.colTelBank.LayoutViewField = Me.layoutViewField_colTelBank
        Me.colTelBank.Name = "colTelBank"
        '
        'colFaxBank
        '
        Me.colFaxBank.Caption = "Fax"
        Me.colFaxBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFaxBank.FieldName = "Fax Bank"
        Me.colFaxBank.LayoutViewField = Me.layoutViewField_colFaxBank
        Me.colFaxBank.Name = "colFaxBank"
        '
        'colBICBank
        '
        Me.colBICBank.Caption = "BIC"
        Me.colBICBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBICBank.FieldName = "BIC Bank"
        Me.colBICBank.LayoutViewField = Me.layoutViewField_colBICBank
        Me.colBICBank.Name = "colBICBank"
        '
        'colBLZBank
        '
        Me.colBLZBank.Caption = "BLZ"
        Me.colBLZBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBLZBank.FieldName = "BLZ Bank"
        Me.colBLZBank.LayoutViewField = Me.layoutViewField_colBLZBank
        Me.colBLZBank.Name = "colBLZBank"
        '
        'colTELEXBank
        '
        Me.colTELEXBank.Caption = "TELEX"
        Me.colTELEXBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colTELEXBank.FieldName = "TELEX Bank"
        Me.colTELEXBank.LayoutViewField = Me.layoutViewField_colTELEXBank
        Me.colTELEXBank.Name = "colTELEXBank"
        '
        'colHRB
        '
        Me.colHRB.Caption = "HandelsregisterNr."
        Me.colHRB.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colHRB.FieldName = "HRB"
        Me.colHRB.LayoutViewField = Me.layoutViewField_colHRB
        Me.colHRB.Name = "colHRB"
        '
        'colSEPACreditorID
        '
        Me.colSEPACreditorID.Caption = "SEPA Creditor ID"
        Me.colSEPACreditorID.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colSEPACreditorID.FieldName = "SEPA Creditor ID"
        Me.colSEPACreditorID.LayoutViewField = Me.layoutViewField_colSEPACreditorID
        Me.colSEPACreditorID.Name = "colSEPACreditorID"
        '
        'colLEI_Code
        '
        Me.colLEI_Code.Caption = "LEI Code (Head Office)"
        Me.colLEI_Code.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colLEI_Code.FieldName = "LEI_Code"
        Me.colLEI_Code.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.colLEI_Code.Name = "colLEI_Code"
        Me.colLEI_Code.OptionsColumn.ReadOnly = True
        '
        'colBAK_Nr
        '
        Me.colBAK_Nr.Caption = "BAK Nr."
        Me.colBAK_Nr.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBAK_Nr.FieldName = "BAK_Nr"
        Me.colBAK_Nr.LayoutViewField = Me.layoutViewField_colBAK_Nr
        Me.colBAK_Nr.Name = "colBAK_Nr"
        '
        'colCorep_ID
        '
        Me.colCorep_ID.Caption = "COREP ID:"
        Me.colCorep_ID.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colCorep_ID.FieldName = "Corep_ID"
        Me.colCorep_ID.LayoutViewField = Me.layoutViewField_colCorep_ID
        Me.colCorep_ID.Name = "colCorep_ID"
        '
        'colKreditgeber_ID
        '
        Me.colKreditgeber_ID.Caption = "Kreditgeber ID:"
        Me.colKreditgeber_ID.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colKreditgeber_ID.FieldName = "Kreditgeber_ID"
        Me.colKreditgeber_ID.LayoutViewField = Me.layoutViewField_colKreditgeber_ID
        Me.colKreditgeber_ID.Name = "colKreditgeber_ID"
        '
        'colMFI_Code
        '
        Me.colMFI_Code.Caption = "MFI Code"
        Me.colMFI_Code.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colMFI_Code.FieldName = "MFI_Code"
        Me.colMFI_Code.LayoutViewField = Me.layoutViewField_colMFI_Code
        Me.colMFI_Code.Name = "colMFI_Code"
        '
        'colFormularRechtsDE
        '
        Me.colFormularRechtsDE.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularRechtsDE.FieldName = "Formular Rechts DE"
        Me.colFormularRechtsDE.LayoutViewField = Me.layoutViewField_colFormularRechtsDE
        Me.colFormularRechtsDE.Name = "colFormularRechtsDE"
        '
        'colFormularRechtsGB
        '
        Me.colFormularRechtsGB.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularRechtsGB.FieldName = "Formular Rechts GB"
        Me.colFormularRechtsGB.LayoutViewField = Me.layoutViewField_colFormularRechtsGB
        Me.colFormularRechtsGB.Name = "colFormularRechtsGB"
        '
        'colFormularRechtsGR
        '
        Me.colFormularRechtsGR.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularRechtsGR.FieldName = "Formular Rechts GR"
        Me.colFormularRechtsGR.LayoutViewField = Me.layoutViewField_colFormularRechtsGR
        Me.colFormularRechtsGR.Name = "colFormularRechtsGR"
        '
        'colFormularLinksDE
        '
        Me.colFormularLinksDE.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularLinksDE.FieldName = "Formular Links DE"
        Me.colFormularLinksDE.LayoutViewField = Me.layoutViewField_colFormularLinksDE
        Me.colFormularLinksDE.Name = "colFormularLinksDE"
        '
        'colFormularLinksGB
        '
        Me.colFormularLinksGB.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularLinksGB.FieldName = "Formular Links GB"
        Me.colFormularLinksGB.LayoutViewField = Me.layoutViewField_colFormularLinksGB
        Me.colFormularLinksGB.Name = "colFormularLinksGB"
        '
        'colFormularLinksGR
        '
        Me.colFormularLinksGR.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colFormularLinksGR.FieldName = "Formular Links GR"
        Me.colFormularLinksGR.LayoutViewField = Me.layoutViewField_colFormularLinksGR
        Me.colFormularLinksGR.Name = "colFormularLinksGR"
        '
        'colUNTERBEARBEITUNGVON
        '
        Me.colUNTERBEARBEITUNGVON.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colUNTERBEARBEITUNGVON.FieldName = "UNTER BEARBEITUNG VON"
        Me.colUNTERBEARBEITUNGVON.LayoutViewField = Me.layoutViewField_colUNTERBEARBEITUNGVON
        Me.colUNTERBEARBEITUNGVON.Name = "colUNTERBEARBEITUNGVON"
        '
        'colUSER
        '
        Me.colUSER.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colUSER.FieldName = "USER"
        Me.colUSER.LayoutViewField = Me.layoutViewField_colUSER
        Me.colUSER.Name = "colUSER"
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(New DevExpress.XtraPrinting.PageHeaderArea(New String() {"", "BANK DATA", "[Date Printed]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[Time Printed]"}, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), DevExpress.XtraPrinting.BrickAlignment.Near), Nothing)
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        Me.PrintableComponentLink1.RtfReportHeader = "{\rtf1\ansi\ansicpg1252\deff0\deflang2057{\fonttbl{\f0\fnil\fcharset0 Calibri;}{\" & _
    "f1\fnil\fcharset0 Times New Roman;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\b\f0\fs20 BANK DATA\b0" & _
    "\f1\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Printbtn
        '
        Me.Printbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Printbtn.ImageOptions.ImageIndex = 2
        Me.Printbtn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Printbtn.Location = New System.Drawing.Point(814, 6)
        Me.Printbtn.Name = "Printbtn"
        Me.Printbtn.Size = New System.Drawing.Size(103, 18)
        Me.Printbtn.TabIndex = 1
        Me.Printbtn.Text = "Print"
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
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "save_16x16.png")
        '
        'colSubbranchCodeHO
        '
        Me.colSubbranchCodeHO.Caption = "Subbranch Code H.O."
        Me.colSubbranchCodeHO.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colSubbranchCodeHO.FieldName = "SubbranchCodeHO"
        Me.colSubbranchCodeHO.LayoutViewField = Me.layoutViewField_colSubbranchCodeHO
        Me.colSubbranchCodeHO.Name = "colSubbranchCodeHO"
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colNameBank, Me.layoutViewField_colBranchBank, Me.layoutViewField_colStrasseBank, Me.layoutViewField_colPLZBank, Me.layoutViewField_colOrtBank, Me.layoutViewField_colLandBank, Me.layoutViewField_colSteuerNr, Me.layoutViewField_colUstID, Me.layoutViewField_GridColumn1, Me.layoutViewField_colWebsiteBank, Me.layoutViewField_colTelBank, Me.layoutViewField_colFaxBank, Me.layoutViewField_colBICBank, Me.layoutViewField_colBLZBank, Me.layoutViewField_colTELEXBank, Me.layoutViewField_colHRB, Me.layoutViewField_colSEPACreditorID, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_colBAK_Nr, Me.layoutViewField_colCorep_ID, Me.layoutViewField_colKreditgeber_ID, Me.layoutViewField_colMFI_Code, Me.layoutViewField_colNUTS_3_Code, Me.layoutViewField_colSubbranchCodeHO})
        Me.LayoutViewCard1.Name = "layoutViewTemplateCard"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'layoutViewField_colNameBank
        '
        Me.layoutViewField_colNameBank.EditorPreferredWidth = 670
        Me.layoutViewField_colNameBank.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colNameBank.Name = "layoutViewField_colNameBank"
        Me.layoutViewField_colNameBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colNameBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colNameBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colBranchBank
        '
        Me.layoutViewField_colBranchBank.EditorPreferredWidth = 670
        Me.layoutViewField_colBranchBank.Location = New System.Drawing.Point(0, 28)
        Me.layoutViewField_colBranchBank.Name = "layoutViewField_colBranchBank"
        Me.layoutViewField_colBranchBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colBranchBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colBranchBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colStrasseBank
        '
        Me.layoutViewField_colStrasseBank.EditorPreferredWidth = 670
        Me.layoutViewField_colStrasseBank.Location = New System.Drawing.Point(0, 56)
        Me.layoutViewField_colStrasseBank.Name = "layoutViewField_colStrasseBank"
        Me.layoutViewField_colStrasseBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colStrasseBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colStrasseBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colPLZBank
        '
        Me.layoutViewField_colPLZBank.EditorPreferredWidth = 271
        Me.layoutViewField_colPLZBank.Location = New System.Drawing.Point(0, 84)
        Me.layoutViewField_colPLZBank.Name = "layoutViewField_colPLZBank"
        Me.layoutViewField_colPLZBank.Size = New System.Drawing.Size(412, 28)
        Me.layoutViewField_colPLZBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colPLZBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colOrtBank
        '
        Me.layoutViewField_colOrtBank.EditorPreferredWidth = 670
        Me.layoutViewField_colOrtBank.Location = New System.Drawing.Point(0, 112)
        Me.layoutViewField_colOrtBank.Name = "layoutViewField_colOrtBank"
        Me.layoutViewField_colOrtBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colOrtBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colOrtBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colLandBank
        '
        Me.layoutViewField_colLandBank.EditorPreferredWidth = 670
        Me.layoutViewField_colLandBank.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colLandBank.Name = "layoutViewField_colLandBank"
        Me.layoutViewField_colLandBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colLandBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colLandBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colSteuerNr
        '
        Me.layoutViewField_colSteuerNr.EditorPreferredWidth = 670
        Me.layoutViewField_colSteuerNr.Location = New System.Drawing.Point(0, 168)
        Me.layoutViewField_colSteuerNr.Name = "layoutViewField_colSteuerNr"
        Me.layoutViewField_colSteuerNr.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colSteuerNr.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colSteuerNr.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colUstID
        '
        Me.layoutViewField_colUstID.EditorPreferredWidth = 670
        Me.layoutViewField_colUstID.Location = New System.Drawing.Point(0, 196)
        Me.layoutViewField_colUstID.Name = "layoutViewField_colUstID"
        Me.layoutViewField_colUstID.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colUstID.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colUstID.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_GridColumn1
        '
        Me.layoutViewField_GridColumn1.EditorPreferredWidth = 670
        Me.layoutViewField_GridColumn1.Location = New System.Drawing.Point(0, 224)
        Me.layoutViewField_GridColumn1.Name = "layoutViewField_GridColumn1"
        Me.layoutViewField_GridColumn1.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_GridColumn1.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_GridColumn1.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colWebsiteBank
        '
        Me.layoutViewField_colWebsiteBank.EditorPreferredWidth = 670
        Me.layoutViewField_colWebsiteBank.Location = New System.Drawing.Point(0, 252)
        Me.layoutViewField_colWebsiteBank.Name = "layoutViewField_colWebsiteBank"
        Me.layoutViewField_colWebsiteBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colWebsiteBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colWebsiteBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colTelBank
        '
        Me.layoutViewField_colTelBank.EditorPreferredWidth = 670
        Me.layoutViewField_colTelBank.Location = New System.Drawing.Point(0, 280)
        Me.layoutViewField_colTelBank.Name = "layoutViewField_colTelBank"
        Me.layoutViewField_colTelBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colTelBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colTelBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colFaxBank
        '
        Me.layoutViewField_colFaxBank.EditorPreferredWidth = 670
        Me.layoutViewField_colFaxBank.Location = New System.Drawing.Point(0, 308)
        Me.layoutViewField_colFaxBank.Name = "layoutViewField_colFaxBank"
        Me.layoutViewField_colFaxBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colFaxBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFaxBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colBICBank
        '
        Me.layoutViewField_colBICBank.EditorPreferredWidth = 670
        Me.layoutViewField_colBICBank.Location = New System.Drawing.Point(0, 336)
        Me.layoutViewField_colBICBank.Name = "layoutViewField_colBICBank"
        Me.layoutViewField_colBICBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colBICBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colBICBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colBLZBank
        '
        Me.layoutViewField_colBLZBank.EditorPreferredWidth = 670
        Me.layoutViewField_colBLZBank.Location = New System.Drawing.Point(0, 364)
        Me.layoutViewField_colBLZBank.Name = "layoutViewField_colBLZBank"
        Me.layoutViewField_colBLZBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colBLZBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colBLZBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colTELEXBank
        '
        Me.layoutViewField_colTELEXBank.EditorPreferredWidth = 670
        Me.layoutViewField_colTELEXBank.Location = New System.Drawing.Point(0, 392)
        Me.layoutViewField_colTELEXBank.Name = "layoutViewField_colTELEXBank"
        Me.layoutViewField_colTELEXBank.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colTELEXBank.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colTELEXBank.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colHRB
        '
        Me.layoutViewField_colHRB.EditorPreferredWidth = 670
        Me.layoutViewField_colHRB.Location = New System.Drawing.Point(0, 420)
        Me.layoutViewField_colHRB.Name = "layoutViewField_colHRB"
        Me.layoutViewField_colHRB.Size = New System.Drawing.Size(811, 28)
        Me.layoutViewField_colHRB.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colHRB.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colSEPACreditorID
        '
        Me.layoutViewField_colSEPACreditorID.EditorPreferredWidth = 264
        Me.layoutViewField_colSEPACreditorID.Location = New System.Drawing.Point(0, 448)
        Me.layoutViewField_colSEPACreditorID.Name = "layoutViewField_colSEPACreditorID"
        Me.layoutViewField_colSEPACreditorID.Size = New System.Drawing.Size(405, 28)
        Me.layoutViewField_colSEPACreditorID.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colSEPACreditorID.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 674
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 476)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.OptionsToolTip.ToolTip = "Legal Entity Identifier from Head Office (PCBCCNBJXXX)"
        Me.layoutViewField_LayoutViewColumn1.OptionsToolTip.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.layoutViewField_LayoutViewColumn1.OptionsToolTip.ToolTipTitle = "LEI:"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(811, 24)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colBAK_Nr
        '
        Me.layoutViewField_colBAK_Nr.EditorPreferredWidth = 674
        Me.layoutViewField_colBAK_Nr.Location = New System.Drawing.Point(0, 500)
        Me.layoutViewField_colBAK_Nr.Name = "layoutViewField_colBAK_Nr"
        Me.layoutViewField_colBAK_Nr.Size = New System.Drawing.Size(811, 24)
        Me.layoutViewField_colBAK_Nr.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colCorep_ID
        '
        Me.layoutViewField_colCorep_ID.EditorPreferredWidth = 674
        Me.layoutViewField_colCorep_ID.Location = New System.Drawing.Point(0, 524)
        Me.layoutViewField_colCorep_ID.Name = "layoutViewField_colCorep_ID"
        Me.layoutViewField_colCorep_ID.Size = New System.Drawing.Size(811, 24)
        Me.layoutViewField_colCorep_ID.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colKreditgeber_ID
        '
        Me.layoutViewField_colKreditgeber_ID.EditorPreferredWidth = 674
        Me.layoutViewField_colKreditgeber_ID.Location = New System.Drawing.Point(0, 548)
        Me.layoutViewField_colKreditgeber_ID.Name = "layoutViewField_colKreditgeber_ID"
        Me.layoutViewField_colKreditgeber_ID.Size = New System.Drawing.Size(811, 24)
        Me.layoutViewField_colKreditgeber_ID.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colMFI_Code
        '
        Me.layoutViewField_colMFI_Code.EditorPreferredWidth = 674
        Me.layoutViewField_colMFI_Code.Location = New System.Drawing.Point(0, 572)
        Me.layoutViewField_colMFI_Code.Name = "layoutViewField_colMFI_Code"
        Me.layoutViewField_colMFI_Code.Size = New System.Drawing.Size(811, 48)
        Me.layoutViewField_colMFI_Code.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colNUTS_3_Code
        '
        Me.layoutViewField_colNUTS_3_Code.EditorPreferredWidth = 323
        Me.layoutViewField_colNUTS_3_Code.Location = New System.Drawing.Point(412, 84)
        Me.layoutViewField_colNUTS_3_Code.Name = "layoutViewField_colNUTS_3_Code"
        Me.layoutViewField_colNUTS_3_Code.Size = New System.Drawing.Size(399, 28)
        Me.layoutViewField_colNUTS_3_Code.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colNUTS_3_Code.TextSize = New System.Drawing.Size(67, 13)
        Me.layoutViewField_colNUTS_3_Code.TextToControlDistance = 5
        '
        'layoutViewField_colSubbranchCodeHO
        '
        Me.layoutViewField_colSubbranchCodeHO.EditorPreferredWidth = 269
        Me.layoutViewField_colSubbranchCodeHO.Location = New System.Drawing.Point(405, 448)
        Me.layoutViewField_colSubbranchCodeHO.Name = "layoutViewField_colSubbranchCodeHO"
        Me.layoutViewField_colSubbranchCodeHO.Size = New System.Drawing.Size(406, 28)
        Me.layoutViewField_colSubbranchCodeHO.TextSize = New System.Drawing.Size(115, 13)
        '
        'layoutViewField_colID
        '
        Me.layoutViewField_colID.EditorPreferredWidth = 20
        Me.layoutViewField_colID.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID.Name = "layoutViewField_colID"
        Me.layoutViewField_colID.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colID.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colID.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colID.TextVisible = False
        '
        'layoutViewField_colFormularRechtsDE
        '
        Me.layoutViewField_colFormularRechtsDE.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularRechtsDE.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularRechtsDE.Name = "layoutViewField_colFormularRechtsDE"
        Me.layoutViewField_colFormularRechtsDE.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularRechtsDE.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularRechtsDE.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularRechtsDE.TextVisible = False
        '
        'layoutViewField_colFormularRechtsGB
        '
        Me.layoutViewField_colFormularRechtsGB.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularRechtsGB.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularRechtsGB.Name = "layoutViewField_colFormularRechtsGB"
        Me.layoutViewField_colFormularRechtsGB.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularRechtsGB.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularRechtsGB.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularRechtsGB.TextVisible = False
        '
        'layoutViewField_colFormularRechtsGR
        '
        Me.layoutViewField_colFormularRechtsGR.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularRechtsGR.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularRechtsGR.Name = "layoutViewField_colFormularRechtsGR"
        Me.layoutViewField_colFormularRechtsGR.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularRechtsGR.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularRechtsGR.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularRechtsGR.TextVisible = False
        '
        'layoutViewField_colFormularLinksDE
        '
        Me.layoutViewField_colFormularLinksDE.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularLinksDE.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularLinksDE.Name = "layoutViewField_colFormularLinksDE"
        Me.layoutViewField_colFormularLinksDE.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularLinksDE.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularLinksDE.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularLinksDE.TextVisible = False
        '
        'layoutViewField_colFormularLinksGB
        '
        Me.layoutViewField_colFormularLinksGB.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularLinksGB.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularLinksGB.Name = "layoutViewField_colFormularLinksGB"
        Me.layoutViewField_colFormularLinksGB.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularLinksGB.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularLinksGB.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularLinksGB.TextVisible = False
        '
        'layoutViewField_colFormularLinksGR
        '
        Me.layoutViewField_colFormularLinksGR.EditorPreferredWidth = 20
        Me.layoutViewField_colFormularLinksGR.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFormularLinksGR.Name = "layoutViewField_colFormularLinksGR"
        Me.layoutViewField_colFormularLinksGR.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colFormularLinksGR.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colFormularLinksGR.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFormularLinksGR.TextVisible = False
        '
        'layoutViewField_colUNTERBEARBEITUNGVON
        '
        Me.layoutViewField_colUNTERBEARBEITUNGVON.EditorPreferredWidth = 20
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Name = "layoutViewField_colUNTERBEARBEITUNGVON"
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextVisible = False
        '
        'layoutViewField_colBANKLOGO
        '
        Me.layoutViewField_colBANKLOGO.EditorPreferredWidth = 20
        Me.layoutViewField_colBANKLOGO.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBANKLOGO.Name = "layoutViewField_colBANKLOGO"
        Me.layoutViewField_colBANKLOGO.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colBANKLOGO.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colBANKLOGO.TextSize = New System.Drawing.Size(133, 13)
        '
        'layoutViewField_colUSER
        '
        Me.layoutViewField_colUSER.EditorPreferredWidth = 20
        Me.layoutViewField_colUSER.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUSER.Name = "layoutViewField_colUSER"
        Me.layoutViewField_colUSER.Size = New System.Drawing.Size(811, 620)
        Me.layoutViewField_colUSER.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.layoutViewField_colUSER.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colUSER.TextVisible = False
        '
        'Bank_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 622)
        Me.Controls.Add(Me.Printbtn)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Bank_Data"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bank Data"
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BANKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNameBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBranchBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStrasseBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPLZBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOrtBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLandBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSteuerNr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUstID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_GridColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWebsiteBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTelBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFaxBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBICBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBLZBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTELEXBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colHRB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSEPACreditorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBAK_Nr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCorep_ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colKreditgeber_ID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMFI_Code, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNUTS_3_Code, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSubbranchCodeHO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularRechtsDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularRechtsGB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularRechtsGR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularLinksDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularLinksGB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFormularLinksGR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBANKLOGO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents BANKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BANKTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.BANKTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colNameBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBranchBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStrasseBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colPLZBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colOrtBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colLandBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBANKLOGO As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSteuerNr As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colUstID As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colWebsiteBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTelBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFaxBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBICBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBLZBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTELEXBank As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colHRB As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSEPACreditorID As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularRechtsDE As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularRechtsGB As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularRechtsGR As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularLinksDE As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularLinksGB As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFormularLinksGR As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colUNTERBEARBEITUNGVON As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colUSER As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents Printbtn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents colLEI_Code As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBAK_Nr As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCorep_ID As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colKreditgeber_ID As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colMFI_Code As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colNUTS_3_Code As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colNameBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBranchBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStrasseBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colPLZBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colNUTS_3_Code As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colOrtBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colLandBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBANKLOGO As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSteuerNr As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colUstID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_GridColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colWebsiteBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTelBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFaxBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBICBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBLZBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTELEXBank As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colHRB As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSEPACreditorID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBAK_Nr As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCorep_ID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colKreditgeber_ID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colMFI_Code As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSubbranchCodeHO As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSubbranchCodeHO As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularRechtsDE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularRechtsGB As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularRechtsGR As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularLinksDE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularLinksGB As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFormularLinksGR As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colUNTERBEARBEITUNGVON As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colUSER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
End Class
