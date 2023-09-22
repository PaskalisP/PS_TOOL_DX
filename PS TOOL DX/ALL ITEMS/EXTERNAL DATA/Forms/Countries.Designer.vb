<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Countries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Countries))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.CountriesDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colCOUNTRYCODE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCOUNTRYNAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCOUNTRYNAMEDE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.CountryNameDE_RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colLANDKZBUBA1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCURRENCYCODE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.CurrencyRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.colCURRENCYNAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colEUEEA1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.EURepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colIBANCOUNTRY1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.IBANCountryRepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colVALID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.ValidCountryRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colGleichAufsicht1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.AufsichtRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colIBAN_MAX_LENGHT = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.CountryFlag_LayoutViewCol = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemPictureEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colIBAN_CALC_LayoutViewCol = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCountryRating1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RatingRepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RatingRepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStufe = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CountryRatingDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colEWU1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCRS_Comply1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCountry_Limit_Mio_USD1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.CountryLimit_RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.COUNTRIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CountriesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOUNTRYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOUNTRYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOUNTRYNAMEDE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLANDKZBUBA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEUEEA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEWU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBANCOUNTRY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBANMAX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBANCALC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryRatingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGleichAufsicht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCountryFlag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colCRS_Comply = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountry_Limit_Mio_USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CountryLimit_RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.COUNTRIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.COUNTRIESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ViewEdit_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Countries_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.CURRENCIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter()
        Me.colNEWG_COUNTRY_CODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNEWG_COUNTRY_CODE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.layoutViewField_colCOUNTRYCODE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCOUNTRYNAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCOUNTRYNAMEDE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCURRENCYCODE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCURRENCYNAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colEUEEA1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colIBANCOUNTRY1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colVALID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item5 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.item6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_colLANDKZBUBA1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1_1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1_2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1_5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item12 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item13 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1_8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item14 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item15 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1_9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        CType(Me.CountriesDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryNameDE_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EURepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IBANCountryRepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidCountryRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AufsichtRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RatingRepositoryItemGridLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RatingRepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryLimit_RepositoryItemSpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COUNTRIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountriesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryLimit_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRYCODE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRYNAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRYNAMEDE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCURRENCYCODE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCURRENCYNAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colEUEEA1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colIBANCOUNTRY1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLANDKZBUBA1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CountriesDetailView
        '
        Me.CountriesDetailView.Appearance.FieldValue.ForeColor = System.Drawing.Color.Aqua
        Me.CountriesDetailView.Appearance.FieldValue.Options.UseForeColor = True
        Me.CountriesDetailView.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Navy
        Me.CountriesDetailView.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.CountriesDetailView.CardMinSize = New System.Drawing.Size(372, 446)
        Me.CountriesDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colCOUNTRYCODE1, Me.colCOUNTRYNAME1, Me.colCOUNTRYNAMEDE1, Me.colLANDKZBUBA1, Me.colNEWG_COUNTRY_CODE1, Me.colCURRENCYCODE1, Me.colCURRENCYNAME1, Me.colEUEEA1, Me.colIBANCOUNTRY1, Me.colVALID1, Me.colGleichAufsicht1, Me.colIBAN_MAX_LENGHT, Me.CountryFlag_LayoutViewCol, Me.colIBAN_CALC_LayoutViewCol, Me.colCountryRating1, Me.CountryRatingDate1, Me.colEWU1, Me.colCRS_Comply1, Me.colCountry_Limit_Mio_USD1})
        Me.CountriesDetailView.GridControl = Me.GridControl2
        Me.CountriesDetailView.Name = "CountriesDetailView"
        Me.CountriesDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CountriesDetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CountriesDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.CountriesDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.CountriesDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.CountriesDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.CountriesDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.CountriesDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.CountriesDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.CountriesDetailView.OptionsCustomization.AllowFilter = False
        Me.CountriesDetailView.OptionsCustomization.AllowSort = False
        Me.CountriesDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.CountriesDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.CountriesDetailView.OptionsFilter.AllowFilterEditor = False
        Me.CountriesDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.CountriesDetailView.OptionsFind.AllowFindPanel = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.CountriesDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.CountriesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.CountriesDetailView.OptionsView.ShowHeaderPanel = False
        Me.CountriesDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colCOUNTRYCODE1
        '
        Me.colCOUNTRYCODE1.AppearanceCell.Options.UseTextOptions = True
        Me.colCOUNTRYCODE1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCOUNTRYCODE1.FieldName = "COUNTRY CODE"
        Me.colCOUNTRYCODE1.LayoutViewField = Me.layoutViewField_colCOUNTRYCODE1
        Me.colCOUNTRYCODE1.Name = "colCOUNTRYCODE1"
        Me.colCOUNTRYCODE1.OptionsColumn.AllowEdit = False
        '
        'colCOUNTRYNAME1
        '
        Me.colCOUNTRYNAME1.AppearanceCell.Options.UseTextOptions = True
        Me.colCOUNTRYNAME1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCOUNTRYNAME1.FieldName = "COUNTRY NAME"
        Me.colCOUNTRYNAME1.LayoutViewField = Me.layoutViewField_colCOUNTRYNAME1
        Me.colCOUNTRYNAME1.Name = "colCOUNTRYNAME1"
        Me.colCOUNTRYNAME1.OptionsColumn.AllowEdit = False
        '
        'colCOUNTRYNAMEDE1
        '
        Me.colCOUNTRYNAMEDE1.AppearanceCell.Options.UseTextOptions = True
        Me.colCOUNTRYNAMEDE1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCOUNTRYNAMEDE1.ColumnEdit = Me.CountryNameDE_RepositoryItemTextEdit
        Me.colCOUNTRYNAMEDE1.FieldName = "COUNTRY NAME DE"
        Me.colCOUNTRYNAMEDE1.LayoutViewField = Me.layoutViewField_colCOUNTRYNAMEDE1
        Me.colCOUNTRYNAMEDE1.Name = "colCOUNTRYNAMEDE1"
        '
        'CountryNameDE_RepositoryItemTextEdit
        '
        Me.CountryNameDE_RepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CountryNameDE_RepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CountryNameDE_RepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CountryNameDE_RepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.CountryNameDE_RepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.CountryNameDE_RepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CountryNameDE_RepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CountryNameDE_RepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CountryNameDE_RepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CountryNameDE_RepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CountryNameDE_RepositoryItemTextEdit.AutoHeight = False
        Me.CountryNameDE_RepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CountryNameDE_RepositoryItemTextEdit.Name = "CountryNameDE_RepositoryItemTextEdit"
        '
        'colLANDKZBUBA1
        '
        Me.colLANDKZBUBA1.AppearanceCell.Options.UseTextOptions = True
        Me.colLANDKZBUBA1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colLANDKZBUBA1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colLANDKZBUBA1.FieldName = "LANDKZ BUBA"
        Me.colLANDKZBUBA1.LayoutViewField = Me.layoutViewField_colLANDKZBUBA1
        Me.colLANDKZBUBA1.Name = "colLANDKZBUBA1"
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
        Me.RepositoryItemTextEdit1.Mask.EditMask = "[0-9]+"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'colCURRENCYCODE1
        '
        Me.colCURRENCYCODE1.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYCODE1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCURRENCYCODE1.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit1
        Me.colCURRENCYCODE1.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE1.LayoutViewField = Me.layoutViewField_colCURRENCYCODE1
        Me.colCURRENCYCODE1.Name = "colCURRENCYCODE1"
        '
        'CurrencyRepositoryItemLookUpEdit1
        '
        Me.CurrencyRepositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VALID", "VALID", 39, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CurrencyRepositoryItemLookUpEdit1.DataSource = Me.CURRENCIESBindingSource
        Me.CurrencyRepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.CurrencyRepositoryItemLookUpEdit1.Name = "CurrencyRepositoryItemLookUpEdit1"
        Me.CurrencyRepositoryItemLookUpEdit1.NullText = "[Select Currencyl]"
        Me.CurrencyRepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'CURRENCIESBindingSource
        '
        Me.CURRENCIESBindingSource.DataMember = "CURRENCIES"
        Me.CURRENCIESBindingSource.DataSource = Me.EXTERNALDataset
        '
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colCURRENCYNAME1
        '
        Me.colCURRENCYNAME1.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYNAME1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCURRENCYNAME1.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME1.LayoutViewField = Me.layoutViewField_colCURRENCYNAME1
        Me.colCURRENCYNAME1.Name = "colCURRENCYNAME1"
        Me.colCURRENCYNAME1.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME1.OptionsColumn.ReadOnly = True
        '
        'colEUEEA1
        '
        Me.colEUEEA1.AppearanceCell.Options.UseTextOptions = True
        Me.colEUEEA1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colEUEEA1.ColumnEdit = Me.EURepositoryItemImageComboBox1
        Me.colEUEEA1.FieldName = "EU EEA"
        Me.colEUEEA1.LayoutViewField = Me.layoutViewField_colEUEEA1
        Me.colEUEEA1.Name = "colEUEEA1"
        '
        'EURepositoryItemImageComboBox1
        '
        Me.EURepositoryItemImageComboBox1.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.EURepositoryItemImageComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.EURepositoryItemImageComboBox1.AutoHeight = False
        Me.EURepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EURepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EU", "EU", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EEA", "EEA", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 10)})
        Me.EURepositoryItemImageComboBox1.Name = "EURepositoryItemImageComboBox1"
        Me.EURepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.Images.SetKeyName(6, "EU.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "EWG.ico")
        Me.ImageCollection1.Images.SetKeyName(8, "IBAN.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "cancel_16x16.png")
        '
        'colIBANCOUNTRY1
        '
        Me.colIBANCOUNTRY1.AppearanceCell.Options.UseTextOptions = True
        Me.colIBANCOUNTRY1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colIBANCOUNTRY1.ColumnEdit = Me.IBANCountryRepositoryItemImageComboBox2
        Me.colIBANCOUNTRY1.FieldName = "IBAN COUNTRY"
        Me.colIBANCOUNTRY1.LayoutViewField = Me.layoutViewField_colIBANCOUNTRY1
        Me.colIBANCOUNTRY1.Name = "colIBANCOUNTRY1"
        '
        'IBANCountryRepositoryItemImageComboBox2
        '
        Me.IBANCountryRepositoryItemImageComboBox2.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.IBANCountryRepositoryItemImageComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.IBANCountryRepositoryItemImageComboBox2.AutoHeight = False
        Me.IBANCountryRepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.IBANCountryRepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 10)})
        Me.IBANCountryRepositoryItemImageComboBox2.Name = "IBANCountryRepositoryItemImageComboBox2"
        Me.IBANCountryRepositoryItemImageComboBox2.SmallImages = Me.ImageCollection1
        '
        'colVALID1
        '
        Me.colVALID1.AppearanceCell.Options.UseTextOptions = True
        Me.colVALID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colVALID1.ColumnEdit = Me.ValidCountryRepositoryItemImageComboBox1
        Me.colVALID1.FieldName = "VALID"
        Me.colVALID1.LayoutViewField = Me.layoutViewField_colVALID1
        Me.colVALID1.Name = "colVALID1"
        '
        'ValidCountryRepositoryItemImageComboBox1
        '
        Me.ValidCountryRepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ValidCountryRepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidCountryRepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ValidCountryRepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.ValidCountryRepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.ValidCountryRepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidCountryRepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidCountryRepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidCountryRepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.ValidCountryRepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.ValidCountryRepositoryItemImageComboBox1.AutoHeight = False
        Me.ValidCountryRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidCountryRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 10)})
        Me.ValidCountryRepositoryItemImageComboBox1.Name = "ValidCountryRepositoryItemImageComboBox1"
        Me.ValidCountryRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colGleichAufsicht1
        '
        Me.colGleichAufsicht1.AppearanceCell.Options.UseTextOptions = True
        Me.colGleichAufsicht1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colGleichAufsicht1.Caption = "GLEICHWERTIGE AUFSICHTSPFLICHT"
        Me.colGleichAufsicht1.ColumnEdit = Me.AufsichtRepositoryItemImageComboBox
        Me.colGleichAufsicht1.FieldName = "GLEICHWERTIGKEIT_AUFSICHT"
        Me.colGleichAufsicht1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.colGleichAufsicht1.Name = "colGleichAufsicht1"
        '
        'AufsichtRepositoryItemImageComboBox
        '
        Me.AufsichtRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AufsichtRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AufsichtRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AufsichtRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.AufsichtRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.AufsichtRepositoryItemImageComboBox.AutoHeight = False
        Me.AufsichtRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AufsichtRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 10)})
        Me.AufsichtRepositoryItemImageComboBox.Name = "AufsichtRepositoryItemImageComboBox"
        Me.AufsichtRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colIBAN_MAX_LENGHT
        '
        Me.colIBAN_MAX_LENGHT.AppearanceCell.Options.UseTextOptions = True
        Me.colIBAN_MAX_LENGHT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colIBAN_MAX_LENGHT.Caption = "IBAN MAX LENGHT"
        Me.colIBAN_MAX_LENGHT.FieldName = "IBAN MAX"
        Me.colIBAN_MAX_LENGHT.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_1
        Me.colIBAN_MAX_LENGHT.Name = "colIBAN_MAX_LENGHT"
        Me.colIBAN_MAX_LENGHT.OptionsColumn.AllowEdit = False
        '
        'CountryFlag_LayoutViewCol
        '
        Me.CountryFlag_LayoutViewCol.AppearanceCell.Options.UseTextOptions = True
        Me.CountryFlag_LayoutViewCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CountryFlag_LayoutViewCol.Caption = "Flag"
        Me.CountryFlag_LayoutViewCol.ColumnEdit = Me.RepositoryItemPictureEdit2
        Me.CountryFlag_LayoutViewCol.FieldName = "CountryFlag_LayoutViewCol"
        Me.CountryFlag_LayoutViewCol.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_2
        Me.CountryFlag_LayoutViewCol.Name = "CountryFlag_LayoutViewCol"
        Me.CountryFlag_LayoutViewCol.OptionsColumn.ReadOnly = True
        Me.CountryFlag_LayoutViewCol.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        '
        'RepositoryItemPictureEdit2
        '
        Me.RepositoryItemPictureEdit2.Name = "RepositoryItemPictureEdit2"
        Me.RepositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        '
        'colIBAN_CALC_LayoutViewCol
        '
        Me.colIBAN_CALC_LayoutViewCol.AppearanceCell.Options.UseTextOptions = True
        Me.colIBAN_CALC_LayoutViewCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colIBAN_CALC_LayoutViewCol.Caption = "IBAN Calculation Parameter"
        Me.colIBAN_CALC_LayoutViewCol.ColumnEdit = Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit
        Me.colIBAN_CALC_LayoutViewCol.FieldName = "IBAN CALC"
        Me.colIBAN_CALC_LayoutViewCol.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_3
        Me.colIBAN_CALC_LayoutViewCol.Name = "colIBAN_CALC_LayoutViewCol"
        '
        'IBAN_Calculation_Parameter_RepositoryItemTextEdit
        '
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.AutoHeight = False
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Mask.EditMask = "[Y,N]{3}-[N,L,X,0]{1,}[0-9]{0,}-[N,L,X,0]{1,}[0-9]{0,}-[N,L,X,0]{1,}[0-9]{0,}-[A-" & _
    "Z]*"
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit.Name = "IBAN_Calculation_Parameter_RepositoryItemTextEdit"
        '
        'colCountryRating1
        '
        Me.colCountryRating1.Caption = "Rating"
        Me.colCountryRating1.ColumnEdit = Me.RatingRepositoryItemGridLookUpEdit
        Me.colCountryRating1.FieldName = "CountryRating"
        Me.colCountryRating1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_4
        Me.colCountryRating1.Name = "colCountryRating1"
        '
        'RatingRepositoryItemGridLookUpEdit
        '
        Me.RatingRepositoryItemGridLookUpEdit.AutoHeight = False
        Me.RatingRepositoryItemGridLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RatingRepositoryItemGridLookUpEdit.Name = "RatingRepositoryItemGridLookUpEdit"
        Me.RatingRepositoryItemGridLookUpEdit.NullText = ""
        Me.RatingRepositoryItemGridLookUpEdit.PopupFormSize = New System.Drawing.Size(0, 500)
        Me.RatingRepositoryItemGridLookUpEdit.View = Me.RatingRepositoryItemGridLookUpEdit1View
        '
        'RatingRepositoryItemGridLookUpEdit1View
        '
        Me.RatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.RatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.RatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = True
        Me.RatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = True
        Me.RatingRepositoryItemGridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRating, Me.colStufe})
        Me.RatingRepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RatingRepositoryItemGridLookUpEdit1View.Name = "RatingRepositoryItemGridLookUpEdit1View"
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsBehavior.AllowIncrementalSearch = True
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsFind.AlwaysVisible = True
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = False
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.RatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colRating
        '
        Me.colRating.Caption = "Rating"
        Me.colRating.FieldName = "Rating"
        Me.colRating.Name = "colRating"
        Me.colRating.OptionsColumn.AllowEdit = False
        Me.colRating.OptionsColumn.ReadOnly = True
        Me.colRating.Visible = True
        Me.colRating.VisibleIndex = 0
        Me.colRating.Width = 82
        '
        'colStufe
        '
        Me.colStufe.Caption = "Stufe"
        Me.colStufe.FieldName = "Stufe"
        Me.colStufe.Name = "colStufe"
        Me.colStufe.OptionsColumn.AllowEdit = False
        Me.colStufe.OptionsColumn.ReadOnly = True
        Me.colStufe.Width = 99
        '
        'CountryRatingDate1
        '
        Me.CountryRatingDate1.Caption = "Country Rating Date"
        Me.CountryRatingDate1.DisplayFormat.FormatString = "d"
        Me.CountryRatingDate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CountryRatingDate1.FieldName = "CountryRatingDate"
        Me.CountryRatingDate1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_5
        Me.CountryRatingDate1.Name = "CountryRatingDate1"
        '
        'colEWU1
        '
        Me.colEWU1.AppearanceCell.Options.UseTextOptions = True
        Me.colEWU1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colEWU1.Caption = "EWU"
        Me.colEWU1.ColumnEdit = Me.ValidCountryRepositoryItemImageComboBox1
        Me.colEWU1.FieldName = "EWU"
        Me.colEWU1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_6
        Me.colEWU1.Name = "colEWU1"
        Me.colEWU1.OptionsColumn.AllowEdit = False
        '
        'colCRS_Comply1
        '
        Me.colCRS_Comply1.AppearanceCell.Options.UseTextOptions = True
        Me.colCRS_Comply1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCRS_Comply1.Caption = "CRS Comply"
        Me.colCRS_Comply1.ColumnEdit = Me.AufsichtRepositoryItemImageComboBox
        Me.colCRS_Comply1.FieldName = "CRS_Comply"
        Me.colCRS_Comply1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_7
        Me.colCRS_Comply1.Name = "colCRS_Comply1"
        '
        'colCountry_Limit_Mio_USD1
        '
        Me.colCountry_Limit_Mio_USD1.AppearanceCell.Options.UseTextOptions = True
        Me.colCountry_Limit_Mio_USD1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCountry_Limit_Mio_USD1.Caption = "Country Limit (in Mio USD)"
        Me.colCountry_Limit_Mio_USD1.ColumnEdit = Me.CountryLimit_RepositoryItemSpinEdit
        Me.colCountry_Limit_Mio_USD1.DisplayFormat.FormatString = "n0"
        Me.colCountry_Limit_Mio_USD1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCountry_Limit_Mio_USD1.FieldName = "Country_Limit_Mio_USD"
        Me.colCountry_Limit_Mio_USD1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_8
        Me.colCountry_Limit_Mio_USD1.Name = "colCountry_Limit_Mio_USD1"
        '
        'CountryLimit_RepositoryItemSpinEdit
        '
        Me.CountryLimit_RepositoryItemSpinEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CountryLimit_RepositoryItemSpinEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CountryLimit_RepositoryItemSpinEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CountryLimit_RepositoryItemSpinEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CountryLimit_RepositoryItemSpinEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CountryLimit_RepositoryItemSpinEdit.AutoHeight = False
        Me.CountryLimit_RepositoryItemSpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CountryLimit_RepositoryItemSpinEdit.DisplayFormat.FormatString = "n0"
        Me.CountryLimit_RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CountryLimit_RepositoryItemSpinEdit.EditFormat.FormatString = "n0"
        Me.CountryLimit_RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CountryLimit_RepositoryItemSpinEdit.Mask.EditMask = "n0"
        Me.CountryLimit_RepositoryItemSpinEdit.Name = "CountryLimit_RepositoryItemSpinEdit"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.COUNTRIESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.CountriesDetailView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.CountriesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ValidCountryRepositoryItemImageComboBox1, Me.IBANCountryRepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit, Me.EURepositoryItemImageComboBox1, Me.CurrencyRepositoryItemLookUpEdit1, Me.AufsichtRepositoryItemImageComboBox, Me.CountryNameDE_RepositoryItemTextEdit, Me.RepositoryItemPictureEdit1, Me.RepositoryItemPictureEdit2, Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit, Me.RatingRepositoryItemGridLookUpEdit, Me.CountryLimit_RepositoryItemTextEdit, Me.CountryLimit_RepositoryItemSpinEdit})
        Me.GridControl2.Size = New System.Drawing.Size(1519, 681)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CountriesBaseView, Me.GridView2, Me.CountriesDetailView})
        '
        'COUNTRIESBindingSource
        '
        Me.COUNTRIESBindingSource.DataMember = "COUNTRIES"
        Me.COUNTRIESBindingSource.DataSource = Me.EXTERNALDataset
        '
        'CountriesBaseView
        '
        Me.CountriesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CountriesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CountriesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CountriesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CountriesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CountriesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCOUNTRYCODE, Me.colCOUNTRYNAME, Me.colCOUNTRYNAMEDE, Me.colLANDKZBUBA, Me.colNEWG_COUNTRY_CODE, Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colEUEEA, Me.colEWU, Me.colIBANCOUNTRY, Me.colIBANMAX, Me.colIBANCALC, Me.colVALID, Me.colCountryRating, Me.colCountryRatingDate, Me.colGleichAufsicht, Me.ColCountryFlag, Me.colCRS_Comply, Me.colCountry_Limit_Mio_USD})
        Me.CountriesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CountriesBaseView.GridControl = Me.GridControl2
        Me.CountriesBaseView.Name = "CountriesBaseView"
        Me.CountriesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CountriesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CountriesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.CountriesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CountriesBaseView.OptionsFind.AlwaysVisible = True
        Me.CountriesBaseView.OptionsSelection.MultiSelect = True
        Me.CountriesBaseView.OptionsView.ColumnAutoWidth = False
        Me.CountriesBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CountriesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CountriesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.CountriesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CountriesBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        Me.colID.Width = 52
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
        Me.colCOUNTRYCODE.Width = 95
        '
        'colCOUNTRYNAME
        '
        Me.colCOUNTRYNAME.FieldName = "COUNTRY NAME"
        Me.colCOUNTRYNAME.Name = "colCOUNTRYNAME"
        Me.colCOUNTRYNAME.OptionsColumn.AllowEdit = False
        Me.colCOUNTRYNAME.OptionsColumn.ReadOnly = True
        Me.colCOUNTRYNAME.Visible = True
        Me.colCOUNTRYNAME.VisibleIndex = 2
        Me.colCOUNTRYNAME.Width = 281
        '
        'colCOUNTRYNAMEDE
        '
        Me.colCOUNTRYNAMEDE.FieldName = "COUNTRY NAME DE"
        Me.colCOUNTRYNAMEDE.Name = "colCOUNTRYNAMEDE"
        Me.colCOUNTRYNAMEDE.OptionsColumn.AllowEdit = False
        Me.colCOUNTRYNAMEDE.OptionsColumn.ReadOnly = True
        Me.colCOUNTRYNAMEDE.Width = 136
        '
        'colLANDKZBUBA
        '
        Me.colLANDKZBUBA.AppearanceCell.Options.UseTextOptions = True
        Me.colLANDKZBUBA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLANDKZBUBA.Caption = "Länderkenz. Bundesbank"
        Me.colLANDKZBUBA.FieldName = "LANDKZ BUBA"
        Me.colLANDKZBUBA.Name = "colLANDKZBUBA"
        Me.colLANDKZBUBA.OptionsColumn.AllowEdit = False
        Me.colLANDKZBUBA.OptionsColumn.ReadOnly = True
        Me.colLANDKZBUBA.Visible = True
        Me.colLANDKZBUBA.VisibleIndex = 3
        Me.colLANDKZBUBA.Width = 89
        '
        'colCURRENCYCODE
        '
        Me.colCURRENCYCODE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYCODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCURRENCYCODE.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYCODE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYCODE.Visible = True
        Me.colCURRENCYCODE.VisibleIndex = 5
        Me.colCURRENCYCODE.Width = 74
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME.OptionsColumn.ReadOnly = True
        Me.colCURRENCYNAME.Visible = True
        Me.colCURRENCYNAME.VisibleIndex = 6
        Me.colCURRENCYNAME.Width = 268
        '
        'colEUEEA
        '
        Me.colEUEEA.AppearanceCell.Options.UseTextOptions = True
        Me.colEUEEA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEUEEA.ColumnEdit = Me.EURepositoryItemImageComboBox1
        Me.colEUEEA.FieldName = "EU EEA"
        Me.colEUEEA.Name = "colEUEEA"
        Me.colEUEEA.OptionsColumn.AllowEdit = False
        Me.colEUEEA.OptionsColumn.ReadOnly = True
        Me.colEUEEA.ToolTip = "Indicates if Country belongs to EU or EEA"
        Me.colEUEEA.Visible = True
        Me.colEUEEA.VisibleIndex = 7
        '
        'colEWU
        '
        Me.colEWU.ColumnEdit = Me.ValidCountryRepositoryItemImageComboBox1
        Me.colEWU.FieldName = "EWU"
        Me.colEWU.Name = "colEWU"
        Me.colEWU.OptionsColumn.ReadOnly = True
        Me.colEWU.ToolTip = "European Monetary Union (Europäische Währungs Union)"
        Me.colEWU.Visible = True
        Me.colEWU.VisibleIndex = 8
        '
        'colIBANCOUNTRY
        '
        Me.colIBANCOUNTRY.AppearanceCell.Options.UseTextOptions = True
        Me.colIBANCOUNTRY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIBANCOUNTRY.ColumnEdit = Me.IBANCountryRepositoryItemImageComboBox2
        Me.colIBANCOUNTRY.FieldName = "IBAN COUNTRY"
        Me.colIBANCOUNTRY.Name = "colIBANCOUNTRY"
        Me.colIBANCOUNTRY.OptionsColumn.AllowEdit = False
        Me.colIBANCOUNTRY.OptionsColumn.ReadOnly = True
        Me.colIBANCOUNTRY.ToolTip = "Indicates if Country has IBAN"
        Me.colIBANCOUNTRY.Visible = True
        Me.colIBANCOUNTRY.VisibleIndex = 9
        Me.colIBANCOUNTRY.Width = 84
        '
        'colIBANMAX
        '
        Me.colIBANMAX.Caption = "IBAN Lenght"
        Me.colIBANMAX.FieldName = "IBAN MAX"
        Me.colIBANMAX.Name = "colIBANMAX"
        Me.colIBANMAX.OptionsColumn.AllowEdit = False
        Me.colIBANMAX.OptionsColumn.ReadOnly = True
        Me.colIBANMAX.Width = 62
        '
        'colIBANCALC
        '
        Me.colIBANCALC.Caption = "IBAN Calculation Parameter"
        Me.colIBANCALC.FieldName = "IBAN CALC"
        Me.colIBANCALC.Name = "colIBANCALC"
        Me.colIBANCALC.OptionsColumn.AllowEdit = False
        Me.colIBANCALC.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[True]
        Me.colIBANCALC.Width = 137
        '
        'colVALID
        '
        Me.colVALID.AppearanceCell.Options.UseTextOptions = True
        Me.colVALID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colVALID.ColumnEdit = Me.ValidCountryRepositoryItemImageComboBox1
        Me.colVALID.FieldName = "VALID"
        Me.colVALID.Name = "colVALID"
        Me.colVALID.OptionsColumn.AllowEdit = False
        Me.colVALID.OptionsColumn.ReadOnly = True
        '
        'colCountryRating
        '
        Me.colCountryRating.AppearanceCell.Options.UseTextOptions = True
        Me.colCountryRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCountryRating.Caption = "Country Rating"
        Me.colCountryRating.FieldName = "CountryRating"
        Me.colCountryRating.Name = "colCountryRating"
        Me.colCountryRating.OptionsColumn.AllowEdit = False
        Me.colCountryRating.OptionsColumn.ReadOnly = True
        Me.colCountryRating.Visible = True
        Me.colCountryRating.VisibleIndex = 11
        Me.colCountryRating.Width = 73
        '
        'colCountryRatingDate
        '
        Me.colCountryRatingDate.AppearanceCell.Options.UseTextOptions = True
        Me.colCountryRatingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCountryRatingDate.DisplayFormat.FormatString = "d"
        Me.colCountryRatingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colCountryRatingDate.FieldName = "CountryRatingDate"
        Me.colCountryRatingDate.Name = "colCountryRatingDate"
        '
        'colGleichAufsicht
        '
        Me.colGleichAufsicht.AppearanceCell.Options.UseTextOptions = True
        Me.colGleichAufsicht.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colGleichAufsicht.Caption = "Gleichwertige Aufsichtspflicht"
        Me.colGleichAufsicht.ColumnEdit = Me.AufsichtRepositoryItemImageComboBox
        Me.colGleichAufsicht.FieldName = "GLEICHWERTIGKEIT_AUFSICHT"
        Me.colGleichAufsicht.Name = "colGleichAufsicht"
        Me.colGleichAufsicht.Visible = True
        Me.colGleichAufsicht.VisibleIndex = 12
        Me.colGleichAufsicht.Width = 95
        '
        'ColCountryFlag
        '
        Me.ColCountryFlag.Caption = "Flag"
        Me.ColCountryFlag.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.ColCountryFlag.FieldName = "ColCountryFlag"
        Me.ColCountryFlag.Name = "ColCountryFlag"
        Me.ColCountryFlag.OptionsColumn.ReadOnly = True
        Me.ColCountryFlag.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.ColCountryFlag.Visible = True
        Me.ColCountryFlag.VisibleIndex = 0
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.NullText = "       "
        '
        'colCRS_Comply
        '
        Me.colCRS_Comply.Caption = "CRS Comply"
        Me.colCRS_Comply.ColumnEdit = Me.AufsichtRepositoryItemImageComboBox
        Me.colCRS_Comply.FieldName = "CRS_Comply"
        Me.colCRS_Comply.Name = "colCRS_Comply"
        Me.colCRS_Comply.ToolTip = "Common Reporting Standard (CRS)"
        Me.colCRS_Comply.Visible = True
        Me.colCRS_Comply.VisibleIndex = 13
        '
        'colCountry_Limit_Mio_USD
        '
        Me.colCountry_Limit_Mio_USD.Caption = "Country Limit (in Mio USD)"
        Me.colCountry_Limit_Mio_USD.ColumnEdit = Me.CountryLimit_RepositoryItemSpinEdit
        Me.colCountry_Limit_Mio_USD.FieldName = "Country_Limit_Mio_USD"
        Me.colCountry_Limit_Mio_USD.Name = "colCountry_Limit_Mio_USD"
        Me.colCountry_Limit_Mio_USD.Visible = True
        Me.colCountry_Limit_Mio_USD.VisibleIndex = 10
        Me.colCountry_Limit_Mio_USD.Width = 97
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
        'CountryLimit_RepositoryItemTextEdit
        '
        Me.CountryLimit_RepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CountryLimit_RepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CountryLimit_RepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CountryLimit_RepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CountryLimit_RepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CountryLimit_RepositoryItemTextEdit.AutoHeight = False
        Me.CountryLimit_RepositoryItemTextEdit.DisplayFormat.FormatString = "n0"
        Me.CountryLimit_RepositoryItemTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CountryLimit_RepositoryItemTextEdit.EditFormat.FormatString = "n0"
        Me.CountryLimit_RepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CountryLimit_RepositoryItemTextEdit.Name = "CountryLimit_RepositoryItemTextEdit"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'COUNTRIESTableAdapter
        '
        Me.COUNTRIESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Me.COUNTRIESTableAdapter
        Me.TableAdapterManager.CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Nothing
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Nothing
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ViewEdit_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Countries_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1543, 731)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ViewEdit_btn
        '
        Me.ViewEdit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ViewEdit_btn.ImageOptions.ImageIndex = 0
        Me.ViewEdit_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.ViewEdit_btn.Location = New System.Drawing.Point(1370, 12)
        Me.ViewEdit_btn.Name = "ViewEdit_btn"
        Me.ViewEdit_btn.Size = New System.Drawing.Size(161, 22)
        Me.ViewEdit_btn.StyleController = Me.LayoutControl1
        Me.ViewEdit_btn.TabIndex = 10
        Me.ViewEdit_btn.Text = "Edit Country Data"
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
        'Countries_Print_Export_btn
        '
        Me.Countries_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Countries_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Countries_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Countries_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Countries_Print_Export_btn.Name = "Countries_Print_Export_btn"
        Me.Countries_Print_Export_btn.Size = New System.Drawing.Size(168, 22)
        Me.Countries_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Countries_Print_Export_btn.TabIndex = 9
        Me.Countries_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1543, 731)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(380, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(976, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Countries_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(172, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(172, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(208, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1356, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1523, 685)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ViewEdit_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1358, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(165, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl2
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'CURRENCIESTableAdapter
        '
        Me.CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'colNEWG_COUNTRY_CODE
        '
        Me.colNEWG_COUNTRY_CODE.Caption = "NEWG Country Code"
        Me.colNEWG_COUNTRY_CODE.FieldName = "NEWG_COUNTRY_CODE"
        Me.colNEWG_COUNTRY_CODE.Name = "colNEWG_COUNTRY_CODE"
        Me.colNEWG_COUNTRY_CODE.OptionsColumn.AllowEdit = False
        Me.colNEWG_COUNTRY_CODE.OptionsColumn.ReadOnly = True
        Me.colNEWG_COUNTRY_CODE.Visible = True
        Me.colNEWG_COUNTRY_CODE.VisibleIndex = 4
        Me.colNEWG_COUNTRY_CODE.Width = 86
        '
        'colNEWG_COUNTRY_CODE1
        '
        Me.colNEWG_COUNTRY_CODE1.Caption = "NEWG Country Code"
        Me.colNEWG_COUNTRY_CODE1.FieldName = "NEWG_COUNTRY_CODE"
        Me.colNEWG_COUNTRY_CODE1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_9
        Me.colNEWG_COUNTRY_CODE1.Name = "colNEWG_COUNTRY_CODE1"
        Me.colNEWG_COUNTRY_CODE1.OptionsColumn.AllowEdit = False
        Me.colNEWG_COUNTRY_CODE1.OptionsColumn.ReadOnly = True
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colCOUNTRYCODE1, Me.layoutViewField_colCOUNTRYNAME1, Me.layoutViewField_colCOUNTRYNAMEDE1, Me.layoutViewField_colCURRENCYCODE1, Me.layoutViewField_colCURRENCYNAME1, Me.layoutViewField_colEUEEA1, Me.layoutViewField_colIBANCOUNTRY1, Me.layoutViewField_colVALID1, Me.item1, Me.item2, Me.item3, Me.item4, Me.item5, Me.item6, Me.layoutViewField_colLANDKZBUBA1, Me.item7, Me.layoutViewField_LayoutViewColumn1_1, Me.item8, Me.layoutViewField_LayoutViewColumn1_2, Me.layoutViewField_LayoutViewColumn1_3, Me.layoutViewField_LayoutViewColumn1_4, Me.item9, Me.layoutViewField_LayoutViewColumn1_5, Me.layoutViewField_LayoutViewColumn1_6, Me.item10, Me.item11, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_LayoutViewColumn1_7, Me.item12, Me.item13, Me.layoutViewField_LayoutViewColumn1_8, Me.item14, Me.item15, Me.layoutViewField_LayoutViewColumn1_9})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'layoutViewField_colCOUNTRYCODE1
        '
        Me.layoutViewField_colCOUNTRYCODE1.EditorPreferredWidth = 43
        Me.layoutViewField_colCOUNTRYCODE1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colCOUNTRYCODE1.Name = "layoutViewField_colCOUNTRYCODE1"
        Me.layoutViewField_colCOUNTRYCODE1.Size = New System.Drawing.Size(238, 26)
        Me.layoutViewField_colCOUNTRYCODE1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colCOUNTRYNAME1
        '
        Me.layoutViewField_colCOUNTRYNAME1.EditorPreferredWidth = 610
        Me.layoutViewField_colCOUNTRYNAME1.Location = New System.Drawing.Point(0, 26)
        Me.layoutViewField_colCOUNTRYNAME1.Name = "layoutViewField_colCOUNTRYNAME1"
        Me.layoutViewField_colCOUNTRYNAME1.Size = New System.Drawing.Size(805, 24)
        Me.layoutViewField_colCOUNTRYNAME1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colCOUNTRYNAMEDE1
        '
        Me.layoutViewField_colCOUNTRYNAMEDE1.EditorPreferredWidth = 610
        Me.layoutViewField_colCOUNTRYNAMEDE1.Location = New System.Drawing.Point(0, 50)
        Me.layoutViewField_colCOUNTRYNAMEDE1.Name = "layoutViewField_colCOUNTRYNAMEDE1"
        Me.layoutViewField_colCOUNTRYNAMEDE1.Size = New System.Drawing.Size(805, 24)
        Me.layoutViewField_colCOUNTRYNAMEDE1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colCURRENCYCODE1
        '
        Me.layoutViewField_colCURRENCYCODE1.EditorPreferredWidth = 43
        Me.layoutViewField_colCURRENCYCODE1.Location = New System.Drawing.Point(0, 122)
        Me.layoutViewField_colCURRENCYCODE1.Name = "layoutViewField_colCURRENCYCODE1"
        Me.layoutViewField_colCURRENCYCODE1.Size = New System.Drawing.Size(238, 24)
        Me.layoutViewField_colCURRENCYCODE1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colCURRENCYNAME1
        '
        Me.layoutViewField_colCURRENCYNAME1.EditorPreferredWidth = 610
        Me.layoutViewField_colCURRENCYNAME1.Location = New System.Drawing.Point(0, 146)
        Me.layoutViewField_colCURRENCYNAME1.Name = "layoutViewField_colCURRENCYNAME1"
        Me.layoutViewField_colCURRENCYNAME1.Size = New System.Drawing.Size(805, 24)
        Me.layoutViewField_colCURRENCYNAME1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colEUEEA1
        '
        Me.layoutViewField_colEUEEA1.EditorPreferredWidth = 96
        Me.layoutViewField_colEUEEA1.Location = New System.Drawing.Point(0, 170)
        Me.layoutViewField_colEUEEA1.Name = "layoutViewField_colEUEEA1"
        Me.layoutViewField_colEUEEA1.Size = New System.Drawing.Size(291, 24)
        Me.layoutViewField_colEUEEA1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colIBANCOUNTRY1
        '
        Me.layoutViewField_colIBANCOUNTRY1.EditorPreferredWidth = 96
        Me.layoutViewField_colIBANCOUNTRY1.Location = New System.Drawing.Point(0, 194)
        Me.layoutViewField_colIBANCOUNTRY1.Name = "layoutViewField_colIBANCOUNTRY1"
        Me.layoutViewField_colIBANCOUNTRY1.Size = New System.Drawing.Size(291, 24)
        Me.layoutViewField_colIBANCOUNTRY1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_colVALID1
        '
        Me.layoutViewField_colVALID1.EditorPreferredWidth = 63
        Me.layoutViewField_colVALID1.Location = New System.Drawing.Point(0, 338)
        Me.layoutViewField_colVALID1.Name = "layoutViewField_colVALID1"
        Me.layoutViewField_colVALID1.Size = New System.Drawing.Size(258, 24)
        Me.layoutViewField_colVALID1.TextSize = New System.Drawing.Size(186, 13)
        '
        'item1
        '
        Me.item1.AllowHotTrack = False
        Me.item1.CustomizationFormText = "item1"
        Me.item1.Location = New System.Drawing.Point(411, 0)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(394, 26)
        Me.item1.TextSize = New System.Drawing.Size(0, 0)
        '
        'item2
        '
        Me.item2.AllowHotTrack = False
        Me.item2.CustomizationFormText = "item2"
        Me.item2.Location = New System.Drawing.Point(238, 122)
        Me.item2.Name = "item2"
        Me.item2.Size = New System.Drawing.Size(567, 24)
        Me.item2.TextSize = New System.Drawing.Size(0, 0)
        '
        'item3
        '
        Me.item3.AllowHotTrack = False
        Me.item3.CustomizationFormText = "item3"
        Me.item3.Location = New System.Drawing.Point(426, 170)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(379, 24)
        Me.item3.TextSize = New System.Drawing.Size(0, 0)
        '
        'item4
        '
        Me.item4.AllowHotTrack = False
        Me.item4.CustomizationFormText = "item4"
        Me.item4.Location = New System.Drawing.Point(291, 194)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(514, 24)
        Me.item4.TextSize = New System.Drawing.Size(0, 0)
        '
        'item5
        '
        Me.item5.AllowHotTrack = False
        Me.item5.CustomizationFormText = "item5"
        Me.item5.Location = New System.Drawing.Point(0, 362)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(805, 2)
        '
        'item6
        '
        Me.item6.AllowHotTrack = False
        Me.item6.CustomizationFormText = "item6"
        Me.item6.Location = New System.Drawing.Point(258, 338)
        Me.item6.Name = "item6"
        Me.item6.Size = New System.Drawing.Size(547, 24)
        Me.item6.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_colLANDKZBUBA1
        '
        Me.layoutViewField_colLANDKZBUBA1.EditorPreferredWidth = 43
        Me.layoutViewField_colLANDKZBUBA1.Location = New System.Drawing.Point(0, 98)
        Me.layoutViewField_colLANDKZBUBA1.Name = "layoutViewField_colLANDKZBUBA1"
        Me.layoutViewField_colLANDKZBUBA1.Size = New System.Drawing.Size(238, 24)
        Me.layoutViewField_colLANDKZBUBA1.TextSize = New System.Drawing.Size(186, 13)
        '
        'item7
        '
        Me.item7.AllowHotTrack = False
        Me.item7.CustomizationFormText = "item7"
        Me.item7.Location = New System.Drawing.Point(402, 98)
        Me.item7.Name = "item7"
        Me.item7.Size = New System.Drawing.Size(403, 24)
        Me.item7.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1_1
        '
        Me.layoutViewField_LayoutViewColumn1_1.EditorPreferredWidth = 43
        Me.layoutViewField_LayoutViewColumn1_1.Location = New System.Drawing.Point(0, 218)
        Me.layoutViewField_LayoutViewColumn1_1.Name = "layoutViewField_LayoutViewColumn1_1"
        Me.layoutViewField_LayoutViewColumn1_1.Size = New System.Drawing.Size(238, 24)
        Me.layoutViewField_LayoutViewColumn1_1.TextSize = New System.Drawing.Size(186, 13)
        '
        'item8
        '
        Me.item8.AllowHotTrack = False
        Me.item8.CustomizationFormText = "item8"
        Me.item8.Location = New System.Drawing.Point(238, 218)
        Me.item8.Name = "item8"
        Me.item8.Size = New System.Drawing.Size(567, 24)
        Me.item8.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1_2
        '
        Me.layoutViewField_LayoutViewColumn1_2.EditorPreferredWidth = 169
        Me.layoutViewField_LayoutViewColumn1_2.Location = New System.Drawing.Point(238, 0)
        Me.layoutViewField_LayoutViewColumn1_2.Name = "layoutViewField_LayoutViewColumn1_2"
        Me.layoutViewField_LayoutViewColumn1_2.Size = New System.Drawing.Size(173, 26)
        Me.layoutViewField_LayoutViewColumn1_2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_LayoutViewColumn1_2.TextToControlDistance = 0
        Me.layoutViewField_LayoutViewColumn1_2.TextVisible = False
        '
        'layoutViewField_LayoutViewColumn1_3
        '
        Me.layoutViewField_LayoutViewColumn1_3.EditorPreferredWidth = 207
        Me.layoutViewField_LayoutViewColumn1_3.Location = New System.Drawing.Point(0, 242)
        Me.layoutViewField_LayoutViewColumn1_3.Name = "layoutViewField_LayoutViewColumn1_3"
        Me.layoutViewField_LayoutViewColumn1_3.Size = New System.Drawing.Size(402, 24)
        Me.layoutViewField_LayoutViewColumn1_3.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_LayoutViewColumn1_4
        '
        Me.layoutViewField_LayoutViewColumn1_4.EditorPreferredWidth = 43
        Me.layoutViewField_LayoutViewColumn1_4.Location = New System.Drawing.Point(0, 74)
        Me.layoutViewField_LayoutViewColumn1_4.Name = "layoutViewField_LayoutViewColumn1_4"
        Me.layoutViewField_LayoutViewColumn1_4.Size = New System.Drawing.Size(238, 24)
        Me.layoutViewField_LayoutViewColumn1_4.TextSize = New System.Drawing.Size(186, 13)
        '
        'item9
        '
        Me.item9.AllowHotTrack = False
        Me.item9.CustomizationFormText = "item9"
        Me.item9.Location = New System.Drawing.Point(469, 74)
        Me.item9.Name = "item9"
        Me.item9.Size = New System.Drawing.Size(336, 24)
        Me.item9.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1_5
        '
        Me.layoutViewField_LayoutViewColumn1_5.EditorPreferredWidth = 124
        Me.layoutViewField_LayoutViewColumn1_5.Location = New System.Drawing.Point(238, 74)
        Me.layoutViewField_LayoutViewColumn1_5.Name = "layoutViewField_LayoutViewColumn1_5"
        Me.layoutViewField_LayoutViewColumn1_5.Size = New System.Drawing.Size(231, 24)
        Me.layoutViewField_LayoutViewColumn1_5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_5.TextSize = New System.Drawing.Size(103, 13)
        Me.layoutViewField_LayoutViewColumn1_5.TextToControlDistance = 0
        '
        'layoutViewField_LayoutViewColumn1_6
        '
        Me.layoutViewField_LayoutViewColumn1_6.EditorPreferredWidth = 99
        Me.layoutViewField_LayoutViewColumn1_6.Location = New System.Drawing.Point(291, 170)
        Me.layoutViewField_LayoutViewColumn1_6.Name = "layoutViewField_LayoutViewColumn1_6"
        Me.layoutViewField_LayoutViewColumn1_6.Size = New System.Drawing.Size(135, 24)
        Me.layoutViewField_LayoutViewColumn1_6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_6.TextSize = New System.Drawing.Size(27, 13)
        Me.layoutViewField_LayoutViewColumn1_6.TextToControlDistance = 5
        '
        'item10
        '
        Me.item10.AllowHotTrack = False
        Me.item10.CustomizationFormText = "item10"
        Me.item10.Location = New System.Drawing.Point(0, 374)
        Me.item10.Name = "item10"
        Me.item10.Size = New System.Drawing.Size(805, 34)
        Me.item10.TextSize = New System.Drawing.Size(0, 0)
        '
        'item11
        '
        Me.item11.AllowHotTrack = False
        Me.item11.CustomizationFormText = "item11"
        Me.item11.Location = New System.Drawing.Point(0, 364)
        Me.item11.Name = "item11"
        Me.item11.Size = New System.Drawing.Size(805, 10)
        Me.item11.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 63
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 290)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(258, 24)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(186, 13)
        '
        'layoutViewField_LayoutViewColumn1_7
        '
        Me.layoutViewField_LayoutViewColumn1_7.EditorPreferredWidth = 63
        Me.layoutViewField_LayoutViewColumn1_7.Location = New System.Drawing.Point(0, 314)
        Me.layoutViewField_LayoutViewColumn1_7.Name = "layoutViewField_LayoutViewColumn1_7"
        Me.layoutViewField_LayoutViewColumn1_7.Size = New System.Drawing.Size(258, 24)
        Me.layoutViewField_LayoutViewColumn1_7.TextSize = New System.Drawing.Size(186, 13)
        '
        'item12
        '
        Me.item12.AllowHotTrack = False
        Me.item12.CustomizationFormText = "item12"
        Me.item12.Location = New System.Drawing.Point(258, 314)
        Me.item12.Name = "item12"
        Me.item12.Size = New System.Drawing.Size(547, 24)
        Me.item12.TextSize = New System.Drawing.Size(0, 0)
        '
        'item13
        '
        Me.item13.AllowHotTrack = False
        Me.item13.CustomizationFormText = "item13"
        Me.item13.Location = New System.Drawing.Point(258, 290)
        Me.item13.Name = "item13"
        Me.item13.Size = New System.Drawing.Size(547, 24)
        Me.item13.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1_8
        '
        Me.layoutViewField_LayoutViewColumn1_8.EditorPreferredWidth = 139
        Me.layoutViewField_LayoutViewColumn1_8.Location = New System.Drawing.Point(0, 266)
        Me.layoutViewField_LayoutViewColumn1_8.Name = "layoutViewField_LayoutViewColumn1_8"
        Me.layoutViewField_LayoutViewColumn1_8.Size = New System.Drawing.Size(334, 24)
        Me.layoutViewField_LayoutViewColumn1_8.TextSize = New System.Drawing.Size(186, 13)
        '
        'item14
        '
        Me.item14.AllowHotTrack = False
        Me.item14.CustomizationFormText = "item14"
        Me.item14.Location = New System.Drawing.Point(334, 266)
        Me.item14.Name = "item14"
        Me.item14.Size = New System.Drawing.Size(471, 24)
        Me.item14.TextSize = New System.Drawing.Size(0, 0)
        '
        'item15
        '
        Me.item15.AllowHotTrack = False
        Me.item15.CustomizationFormText = "item15"
        Me.item15.Location = New System.Drawing.Point(402, 242)
        Me.item15.Name = "item15"
        Me.item15.Size = New System.Drawing.Size(403, 24)
        Me.item15.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1_9
        '
        Me.layoutViewField_LayoutViewColumn1_9.EditorPreferredWidth = 51
        Me.layoutViewField_LayoutViewColumn1_9.Location = New System.Drawing.Point(238, 98)
        Me.layoutViewField_LayoutViewColumn1_9.Name = "layoutViewField_LayoutViewColumn1_9"
        Me.layoutViewField_LayoutViewColumn1_9.Size = New System.Drawing.Size(164, 24)
        Me.layoutViewField_LayoutViewColumn1_9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_9.TextSize = New System.Drawing.Size(104, 13)
        Me.layoutViewField_LayoutViewColumn1_9.TextToControlDistance = 5
        '
        'Countries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1543, 731)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Countries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Countries"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CountriesDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryNameDE_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EURepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IBANCountryRepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidCountryRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AufsichtRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IBAN_Calculation_Parameter_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RatingRepositoryItemGridLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RatingRepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryLimit_RepositoryItemSpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COUNTRIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountriesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryLimit_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRYCODE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRYNAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRYNAMEDE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCURRENCYCODE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCURRENCYNAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colEUEEA1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colIBANCOUNTRY1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLANDKZBUBA1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents COUNTRIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COUNTRIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.COUNTRIESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ViewEdit_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CountriesDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BICCODERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ValidCountryRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents CountriesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IBANCountryRepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Countries_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colCOUNTRYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOUNTRYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOUNTRYNAMEDE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLANDKZBUBA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEUEEA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBANCOUNTRY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOUNTRYCODE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCOUNTRYNAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCOUNTRYNAMEDE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colLANDKZBUBA1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCURRENCYCODE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCURRENCYNAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colEUEEA1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colIBANCOUNTRY1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colVALID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents EURepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents CurrencyRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CURRENCIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colGleichAufsicht1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents AufsichtRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colGleichAufsicht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CountryNameDE_RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colIBANMAX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN_MAX_LENGHT As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents ColCountryFlag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents CountryFlag_LayoutViewCol As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemPictureEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents colIBAN_CALC_LayoutViewCol As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents IBAN_Calculation_Parameter_RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colIBANCALC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountryRating1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCountryRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RatingRepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RatingRepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStufe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CountryRatingDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCountryRatingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEWU1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colEWU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCRS_Comply1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCRS_Comply As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountry_Limit_Mio_USD1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents CountryLimit_RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colCountry_Limit_Mio_USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CountryLimit_RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents layoutViewField_colCOUNTRYCODE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCOUNTRYNAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCOUNTRYNAMEDE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colLANDKZBUBA1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colNEWG_COUNTRY_CODE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCURRENCYCODE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCURRENCYNAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colEUEEA1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colIBANCOUNTRY1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colVALID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1_8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colNEWG_COUNTRY_CODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents item1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item5 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents item6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item12 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item13 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item14 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item15 As DevExpress.XtraLayout.EmptySpaceItem
End Class
