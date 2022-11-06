<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LcExportMaturities
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LcExportMaturities))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.ExportLCMaturitiesDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colDocsSendOn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.layoutViewField_colDocsSendOn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colApplicantsBank1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.layoutViewField_colApplicantsBank1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOurReference1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOurReference1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrency1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.CurrencyRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.OWN_CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.layoutViewField_colCurrency1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.AmountRepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.layoutViewField_colAmount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMaturity1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMaturity1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSettlementStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.SettlementStatusRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.layoutViewField_colSettlementStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colNotes1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.NotesRepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.layoutViewField_colNotes1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.LC_EXPORT_MATURITIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ForeignDataset = New PS_TOOL_DX.ForeignDataset()
        Me.ExportLCMaturitiesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocsSendOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colApplicantsBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOurReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSettlementStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLCReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LC_EXPORT_MATURITIESTableAdapter = New PS_TOOL_DX.ForeignDatasetTableAdapters.LC_EXPORT_MATURITIESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.ForeignDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ExportLCMaturitiesreport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ViewEdit_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Print_Export_GridView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OWN_CURRENCIESTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter()
        Me.TableAdapterManager1 = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotesRepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LC_EXPORT_MATURITIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ForeignDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLCMaturitiesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExportLCMaturitiesDetailView
        '
        Me.ExportLCMaturitiesDetailView.CardMinSize = New System.Drawing.Size(741, 448)
        Me.ExportLCMaturitiesDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colDocsSendOn1, Me.colApplicantsBank1, Me.colOurReference1, Me.colCurrency1, Me.colAmount1, Me.colMaturity1, Me.colSettlementStatus1, Me.colNotes1})
        Me.ExportLCMaturitiesDetailView.GridControl = Me.GridControl2
        Me.ExportLCMaturitiesDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.ExportLCMaturitiesDetailView.Name = "ExportLCMaturitiesDetailView"
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowFilter = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowSort = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterEditor = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExportLCMaturitiesDetailView.OptionsFind.AllowFindPanel = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsView.ShowHeaderPanel = False
        Me.ExportLCMaturitiesDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = 20
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(730, 180)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colDocsSendOn1
        '
        Me.colDocsSendOn1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDocsSendOn1.FieldName = "DocsSendOn"
        Me.colDocsSendOn1.LayoutViewField = Me.layoutViewField_colDocsSendOn1
        Me.colDocsSendOn1.Name = "colDocsSendOn1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.ShowWeekNumbers = True
        '
        'layoutViewField_colDocsSendOn1
        '
        Me.layoutViewField_colDocsSendOn1.EditorPreferredWidth = 90
        Me.layoutViewField_colDocsSendOn1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colDocsSendOn1.Name = "layoutViewField_colDocsSendOn1"
        Me.layoutViewField_colDocsSendOn1.Size = New System.Drawing.Size(189, 20)
        Me.layoutViewField_colDocsSendOn1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colApplicantsBank1
        '
        Me.colApplicantsBank1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colApplicantsBank1.FieldName = "ApplicantsBank"
        Me.colApplicantsBank1.LayoutViewField = Me.layoutViewField_colApplicantsBank1
        Me.colApplicantsBank1.Name = "colApplicantsBank1"
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
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'layoutViewField_colApplicantsBank1
        '
        Me.layoutViewField_colApplicantsBank1.EditorPreferredWidth = 622
        Me.layoutViewField_colApplicantsBank1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colApplicantsBank1.Name = "layoutViewField_colApplicantsBank1"
        Me.layoutViewField_colApplicantsBank1.Size = New System.Drawing.Size(721, 20)
        Me.layoutViewField_colApplicantsBank1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colOurReference1
        '
        Me.colOurReference1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colOurReference1.FieldName = "OurReference"
        Me.colOurReference1.LayoutViewField = Me.layoutViewField_colOurReference1
        Me.colOurReference1.Name = "colOurReference1"
        '
        'layoutViewField_colOurReference1
        '
        Me.layoutViewField_colOurReference1.EditorPreferredWidth = 91
        Me.layoutViewField_colOurReference1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colOurReference1.Name = "layoutViewField_colOurReference1"
        Me.layoutViewField_colOurReference1.Size = New System.Drawing.Size(190, 20)
        Me.layoutViewField_colOurReference1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colCurrency1
        '
        Me.colCurrency1.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit1
        Me.colCurrency1.FieldName = "Currency"
        Me.colCurrency1.LayoutViewField = Me.layoutViewField_colCurrency1
        Me.colCurrency1.Name = "colCurrency1"
        '
        'CurrencyRepositoryItemLookUpEdit1
        '
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.CurrencyRepositoryItemLookUpEdit1.DataSource = Me.OWN_CURRENCIESBindingSource
        Me.CurrencyRepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.CurrencyRepositoryItemLookUpEdit1.Name = "CurrencyRepositoryItemLookUpEdit1"
        Me.CurrencyRepositoryItemLookUpEdit1.NullText = ""
        Me.CurrencyRepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'OWN_CURRENCIESBindingSource
        '
        Me.OWN_CURRENCIESBindingSource.DataMember = "OWN_CURRENCIES"
        Me.OWN_CURRENCIESBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'layoutViewField_colCurrency1
        '
        Me.layoutViewField_colCurrency1.EditorPreferredWidth = 40
        Me.layoutViewField_colCurrency1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colCurrency1.Name = "layoutViewField_colCurrency1"
        Me.layoutViewField_colCurrency1.Size = New System.Drawing.Size(139, 20)
        Me.layoutViewField_colCurrency1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colAmount1
        '
        Me.colAmount1.ColumnEdit = Me.AmountRepositoryItemTextEdit2
        Me.colAmount1.FieldName = "Amount"
        Me.colAmount1.LayoutViewField = Me.layoutViewField_colAmount1
        Me.colAmount1.Name = "colAmount1"
        '
        'AmountRepositoryItemTextEdit2
        '
        Me.AmountRepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit2.AutoHeight = False
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit2.Name = "AmountRepositoryItemTextEdit2"
        '
        'layoutViewField_colAmount1
        '
        Me.layoutViewField_colAmount1.EditorPreferredWidth = 123
        Me.layoutViewField_colAmount1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colAmount1.Name = "layoutViewField_colAmount1"
        Me.layoutViewField_colAmount1.Size = New System.Drawing.Size(222, 20)
        Me.layoutViewField_colAmount1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colMaturity1
        '
        Me.colMaturity1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colMaturity1.FieldName = "Maturity"
        Me.colMaturity1.LayoutViewField = Me.layoutViewField_colMaturity1
        Me.colMaturity1.Name = "colMaturity1"
        '
        'layoutViewField_colMaturity1
        '
        Me.layoutViewField_colMaturity1.EditorPreferredWidth = 94
        Me.layoutViewField_colMaturity1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colMaturity1.Name = "layoutViewField_colMaturity1"
        Me.layoutViewField_colMaturity1.Size = New System.Drawing.Size(193, 20)
        Me.layoutViewField_colMaturity1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colSettlementStatus1
        '
        Me.colSettlementStatus1.ColumnEdit = Me.SettlementStatusRepositoryItemImageComboBox1
        Me.colSettlementStatus1.FieldName = "SettlementStatus"
        Me.colSettlementStatus1.LayoutViewField = Me.layoutViewField_colSettlementStatus1
        Me.colSettlementStatus1.Name = "colSettlementStatus1"
        '
        'SettlementStatusRepositoryItemImageComboBox1
        '
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AutoHeight = False
        Me.SettlementStatusRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PENDING", "PENDING", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PAID", "PAID", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNPAID", "UNPAID", 3)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Name = "SettlementStatusRepositoryItemImageComboBox1"
        Me.SettlementStatusRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.Images.SetKeyName(6, "Paid.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "Pending.ico")
        Me.ImageCollection1.InsertGalleryImage("paste_16x16.png", "images/edit/paste_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "paste_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "save_16x16.png")
        '
        'layoutViewField_colSettlementStatus1
        '
        Me.layoutViewField_colSettlementStatus1.EditorPreferredWidth = 62
        Me.layoutViewField_colSettlementStatus1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colSettlementStatus1.Name = "layoutViewField_colSettlementStatus1"
        Me.layoutViewField_colSettlementStatus1.Size = New System.Drawing.Size(161, 20)
        Me.layoutViewField_colSettlementStatus1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colNotes1
        '
        Me.colNotes1.ColumnEdit = Me.NotesRepositoryItemMemoExEdit1
        Me.colNotes1.FieldName = "Notes"
        Me.colNotes1.LayoutViewField = Me.layoutViewField_colNotes1
        Me.colNotes1.Name = "colNotes1"
        '
        'NotesRepositoryItemMemoExEdit1
        '
        Me.NotesRepositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.NotesRepositoryItemMemoExEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.NotesRepositoryItemMemoExEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.NotesRepositoryItemMemoExEdit1.Appearance.Options.UseBackColor = True
        Me.NotesRepositoryItemMemoExEdit1.Appearance.Options.UseForeColor = True
        Me.NotesRepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NotesRepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NotesRepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NotesRepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.NotesRepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.NotesRepositoryItemMemoExEdit1.AutoHeight = False
        Me.NotesRepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NotesRepositoryItemMemoExEdit1.Name = "NotesRepositoryItemMemoExEdit1"
        '
        'layoutViewField_colNotes1
        '
        Me.layoutViewField_colNotes1.EditorPreferredWidth = 622
        Me.layoutViewField_colNotes1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colNotes1.Name = "layoutViewField_colNotes1"
        Me.layoutViewField_colNotes1.Size = New System.Drawing.Size(721, 269)
        Me.layoutViewField_colNotes1.TextSize = New System.Drawing.Size(90, 13)
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.LC_EXPORT_MATURITIESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Hint = "Add new Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 8, True, True, "Duplicate Row", "DuplicateRow")})
        GridLevelNode1.LevelTemplate = Me.ExportLCMaturitiesDetailView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ExportLCMaturitiesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SettlementStatusRepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit, Me.CurrencyRepositoryItemLookUpEdit1, Me.RepositoryItemDateEdit1, Me.NotesRepositoryItemMemoExEdit1, Me.AmountRepositoryItemTextEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1358, 719)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExportLCMaturitiesBaseView, Me.GridView2, Me.ExportLCMaturitiesDetailView})
        '
        'LC_EXPORT_MATURITIESBindingSource
        '
        Me.LC_EXPORT_MATURITIESBindingSource.DataMember = "LC EXPORT MATURITIES"
        Me.LC_EXPORT_MATURITIESBindingSource.DataSource = Me.ForeignDataset
        '
        'ForeignDataset
        '
        Me.ForeignDataset.DataSetName = "ForeignDataset"
        Me.ForeignDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ExportLCMaturitiesBaseView
        '
        Me.ExportLCMaturitiesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExportLCMaturitiesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExportLCMaturitiesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExportLCMaturitiesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExportLCMaturitiesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExportLCMaturitiesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colDocsSendOn, Me.colApplicantsBank, Me.colOurReference, Me.colCurrency, Me.colAmount, Me.colMaturity, Me.colSettlementStatus, Me.colNotes, Me.colBeneficiary, Me.colLCReference})
        Me.ExportLCMaturitiesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExportLCMaturitiesBaseView.GridControl = Me.GridControl2
        Me.ExportLCMaturitiesBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Me.colAmount, "Total: {0:n2}", 0.0R)})
        Me.ExportLCMaturitiesBaseView.Name = "ExportLCMaturitiesBaseView"
        Me.ExportLCMaturitiesBaseView.NewItemRowText = "Add new EXPORT LC Maturity"
        Me.ExportLCMaturitiesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportLCMaturitiesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExportLCMaturitiesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExportLCMaturitiesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExportLCMaturitiesBaseView.OptionsFind.AlwaysVisible = True
        Me.ExportLCMaturitiesBaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.ExportLCMaturitiesBaseView.OptionsSelection.MultiSelect = True
        Me.ExportLCMaturitiesBaseView.OptionsView.ColumnAutoWidth = False
        Me.ExportLCMaturitiesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExportLCMaturitiesBaseView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ExportLCMaturitiesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.ExportLCMaturitiesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExportLCMaturitiesBaseView.OptionsView.ShowFooter = True
        Me.ExportLCMaturitiesBaseView.PaintStyleName = "Skin"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colDocsSendOn
        '
        Me.colDocsSendOn.AppearanceCell.Options.UseTextOptions = True
        Me.colDocsSendOn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDocsSendOn.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDocsSendOn.DisplayFormat.FormatString = "d"
        Me.colDocsSendOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDocsSendOn.FieldName = "DocsSendOn"
        Me.colDocsSendOn.Name = "colDocsSendOn"
        Me.colDocsSendOn.Visible = True
        Me.colDocsSendOn.VisibleIndex = 0
        Me.colDocsSendOn.Width = 94
        '
        'colApplicantsBank
        '
        Me.colApplicantsBank.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colApplicantsBank.FieldName = "ApplicantsBank"
        Me.colApplicantsBank.Name = "colApplicantsBank"
        Me.colApplicantsBank.Visible = True
        Me.colApplicantsBank.VisibleIndex = 2
        Me.colApplicantsBank.Width = 252
        '
        'colOurReference
        '
        Me.colOurReference.AppearanceCell.Options.UseTextOptions = True
        Me.colOurReference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOurReference.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colOurReference.FieldName = "OurReference"
        Me.colOurReference.Name = "colOurReference"
        Me.colOurReference.Visible = True
        Me.colOurReference.VisibleIndex = 4
        Me.colOurReference.Width = 118
        '
        'colCurrency
        '
        Me.colCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrency.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit1
        Me.colCurrency.FieldName = "Currency"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.Visible = True
        Me.colCurrency.VisibleIndex = 5
        Me.colCurrency.Width = 61
        '
        'colAmount
        '
        Me.colAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmount.ColumnEdit = Me.AmountRepositoryItemTextEdit2
        Me.colAmount.DisplayFormat.FormatString = "n2"
        Me.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount.FieldName = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Visible = True
        Me.colAmount.VisibleIndex = 6
        Me.colAmount.Width = 116
        '
        'colMaturity
        '
        Me.colMaturity.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colMaturity.AppearanceCell.Options.UseFont = True
        Me.colMaturity.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturity.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colMaturity.AppearanceHeader.Options.UseFont = True
        Me.colMaturity.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colMaturity.DisplayFormat.FormatString = "d"
        Me.colMaturity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colMaturity.FieldName = "Maturity"
        Me.colMaturity.Name = "colMaturity"
        Me.colMaturity.Visible = True
        Me.colMaturity.VisibleIndex = 7
        Me.colMaturity.Width = 107
        '
        'colSettlementStatus
        '
        Me.colSettlementStatus.ColumnEdit = Me.SettlementStatusRepositoryItemImageComboBox1
        Me.colSettlementStatus.FieldName = "SettlementStatus"
        Me.colSettlementStatus.Name = "colSettlementStatus"
        Me.colSettlementStatus.Visible = True
        Me.colSettlementStatus.VisibleIndex = 8
        Me.colSettlementStatus.Width = 103
        '
        'colNotes
        '
        Me.colNotes.ColumnEdit = Me.NotesRepositoryItemMemoExEdit1
        Me.colNotes.FieldName = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Visible = True
        Me.colNotes.VisibleIndex = 9
        '
        'colBeneficiary
        '
        Me.colBeneficiary.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBeneficiary.FieldName = "Beneficiary"
        Me.colBeneficiary.Name = "colBeneficiary"
        Me.colBeneficiary.Visible = True
        Me.colBeneficiary.VisibleIndex = 3
        Me.colBeneficiary.Width = 271
        '
        'colLCReference
        '
        Me.colLCReference.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colLCReference.FieldName = "LCReference"
        Me.colLCReference.Name = "colLCReference"
        Me.colLCReference.Visible = True
        Me.colLCReference.VisibleIndex = 1
        Me.colLCReference.Width = 124
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
        '
        'BICCODERepositoryItemTextEdit
        '
        Me.BICCODERepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BICCODERepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AutoHeight = False
        Me.BICCODERepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BICCODERepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BICCODERepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.BICCODERepositoryItemTextEdit.Mask.EditMask = "([A-Z]){6}([0-9A-Z]){2}([0-9A-Z]{3})"
        Me.BICCODERepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.BICCODERepositoryItemTextEdit.Name = "BICCODERepositoryItemTextEdit"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colDocsSendOn1, Me.layoutViewField_colApplicantsBank1, Me.layoutViewField_colOurReference1, Me.layoutViewField_colCurrency1, Me.layoutViewField_colAmount1, Me.layoutViewField_colMaturity1, Me.layoutViewField_colSettlementStatus1, Me.layoutViewField_colNotes1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
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
        'LC_EXPORT_MATURITIESTableAdapter
        '
        Me.LC_EXPORT_MATURITIESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EXPORT_LC_DETAILS_ALLTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MONTHTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_YEARTableAdapter = Nothing
        Me.TableAdapterManager.LC_EXPORT_MATURITIESTableAdapter = Me.LC_EXPORT_MATURITIESTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ForeignDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ExportLCMaturitiesreport_btn)
        Me.LayoutControl1.Controls.Add(Me.ViewEdit_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_GridView_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1382, 769)
        Me.LayoutControl1.TabIndex = 6
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ExportLCMaturitiesreport_btn
        '
        Me.ExportLCMaturitiesreport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExportLCMaturitiesreport_btn.ImageIndex = 5
        Me.ExportLCMaturitiesreport_btn.ImageList = Me.ImageCollection1
        Me.ExportLCMaturitiesreport_btn.Location = New System.Drawing.Point(165, 12)
        Me.ExportLCMaturitiesreport_btn.Name = "ExportLCMaturitiesreport_btn"
        Me.ExportLCMaturitiesreport_btn.Size = New System.Drawing.Size(164, 22)
        Me.ExportLCMaturitiesreport_btn.StyleController = Me.LayoutControl1
        Me.ExportLCMaturitiesreport_btn.TabIndex = 10
        Me.ExportLCMaturitiesreport_btn.Text = "Maturities Report"
        '
        'ViewEdit_btn
        '
        Me.ViewEdit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ViewEdit_btn.ImageIndex = 0
        Me.ViewEdit_btn.Location = New System.Drawing.Point(1250, 12)
        Me.ViewEdit_btn.Name = "ViewEdit_btn"
        Me.ViewEdit_btn.Size = New System.Drawing.Size(120, 22)
        Me.ViewEdit_btn.StyleController = Me.LayoutControl1
        Me.ViewEdit_btn.TabIndex = 10
        Me.ViewEdit_btn.Text = "Edit SSIS"
        '
        'Print_Export_GridView_btn
        '
        Me.Print_Export_GridView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_GridView_btn.ImageIndex = 2
        Me.Print_Export_GridView_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_GridView_btn.Location = New System.Drawing.Point(12, 12)
        Me.Print_Export_GridView_btn.Name = "Print_Export_GridView_btn"
        Me.Print_Export_GridView_btn.Size = New System.Drawing.Size(149, 22)
        Me.Print_Export_GridView_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_GridView_btn.TabIndex = 9
        Me.Print_Export_GridView_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1382, 769)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(361, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(875, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Print_Export_GridView_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(153, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(321, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(40, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1236, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1362, 723)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ViewEdit_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1238, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(124, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ExportLCMaturitiesreport_btn
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(153, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(168, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'OWN_CURRENCIESTableAdapter
        '
        Me.OWN_CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager1.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager1.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.BANKTableAdapter = Nothing
        Me.TableAdapterManager1.CalendarTableAdapter = Nothing
        Me.TableAdapterManager1.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager1.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager1.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager1.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager1.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager1.MAK_REPORTTableAdapter = Nothing
        
        Me.TableAdapterManager1.OWN_CURRENCIESTableAdapter = Me.OWN_CURRENCIESTableAdapter
        Me.TableAdapterManager1.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager1.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager1.SSISTableAdapter = Nothing
        Me.TableAdapterManager1.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LcExportMaturities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1382, 769)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LcExportMaturities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Letter of Credits - Maturities"
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotesRepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LC_EXPORT_MATURITIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ForeignDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLCMaturitiesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents ForeignDataset As PS_TOOL_DX.ForeignDataset
    Friend WithEvents LC_EXPORT_MATURITIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LC_EXPORT_MATURITIESTableAdapter As PS_TOOL_DX.ForeignDatasetTableAdapters.LC_EXPORT_MATURITIESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.ForeignDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ExportLCMaturitiesreport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewEdit_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExportLCMaturitiesDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colDocsSendOn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents layoutViewField_colDocsSendOn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colApplicantsBank1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents layoutViewField_colApplicantsBank1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOurReference1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOurReference1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrency1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents CurrencyRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents layoutViewField_colCurrency1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAmount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents AmountRepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents layoutViewField_colAmount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMaturity1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMaturity1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSettlementStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents SettlementStatusRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents layoutViewField_colSettlementStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colNotes1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents NotesRepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents layoutViewField_colNotes1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents ExportLCMaturitiesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocsSendOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colApplicantsBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOurReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSettlementStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLCReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents BICCODERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Print_Export_GridView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents OWN_CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OWN_CURRENCIESTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter
    Friend WithEvents TableAdapterManager1 As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
