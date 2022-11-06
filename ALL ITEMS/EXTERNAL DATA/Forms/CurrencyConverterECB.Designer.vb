<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrencyConverterECB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CurrencyConverterECB))
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CurrencyFromComboBoxEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SecondCurrencyName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.FirstCurrencyName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.ConvertedAmount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.ConvertedCurrency_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CrossRateCurrencies_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.CrossCurrencies_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.SecondCurrencyToEURrate_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.SecondCurrencyToEUR_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.FirstCurrencyToEURrate_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.FirstCurrencyToEUR_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Convert_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.RateSecondCurrencyComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RateSecondCurrencyTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RateFirstCurrencyTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RateFirstCurrencyComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.AmountToConvertTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LoadExchangeRatesOCBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.ExchangeRateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.EXCHANGE_RATES_ECBBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExchangeRatesECBBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXCHANGERATEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.CustomerAccountsDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClientNo1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colClientNo1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClientAccount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colClientAccount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colDealCurrency1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colDealCurrency1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAccountStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAccountStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOnline1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOnline1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colEnglishName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colEnglishName1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colProductCode1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colProductCode1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrencyStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrencyStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCountry1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCountry1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPRD_TYPE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPRD_TYPE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOPEN_DATE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOPEN_DATE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCLOSE_DATE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCLOSE_DATE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ExchangeRatesOCBSreport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CurrenciesConvert_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CurrencyToComboBoxEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem12 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem13 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem14 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem15 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem16 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem17 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem18 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem19 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem20 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem22 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem21 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.EXCHANGE_RATES_ECBTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.EXCHANGE_RATES_ECBTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager()
        Me.CURRENCIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyFromComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.RateSecondCurrencyComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RateSecondCurrencyTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RateFirstCurrencyTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RateFirstCurrencyComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountToConvertTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXCHANGE_RATES_ECBBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRatesECBBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerAccountsDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colClientNo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colClientAccount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDealCurrency1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccountStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOnline1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colEnglishName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colProductCode1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrencyStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCountry1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPRD_TYPE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOPEN_DATE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCLOSE_DATE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyToComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 17)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(283, 24)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CurrencyFromComboBoxEdit
        Me.LayoutControlItem8.CustomizationFormText = "Currency"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(283, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(128, 41)
        Me.LayoutControlItem8.Text = "Currency"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(99, 13)
        '
        'CurrencyFromComboBoxEdit
        '
        Me.CurrencyFromComboBoxEdit.Location = New System.Drawing.Point(307, 335)
        Me.CurrencyFromComboBoxEdit.Name = "CurrencyFromComboBoxEdit"
        Me.CurrencyFromComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyFromComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyFromComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyFromComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyFromComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyFromComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyFromComboBoxEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 108, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VALID", "VALID", 39, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.CurrencyFromComboBoxEdit.Properties.DataSource = Me.CURRENCIESBindingSource
        Me.CurrencyFromComboBoxEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.CurrencyFromComboBoxEdit.Properties.NullText = ""
        Me.CurrencyFromComboBoxEdit.Properties.PopupSizeable = False
        Me.CurrencyFromComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CurrencyFromComboBoxEdit.Properties.ValueMember = "CURRENCY CODE"
        Me.CurrencyFromComboBoxEdit.Size = New System.Drawing.Size(124, 20)
        Me.CurrencyFromComboBoxEdit.StyleController = Me.LayoutControl1
        Me.CurrencyFromComboBoxEdit.TabIndex = 14
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SecondCurrencyName_lbl)
        Me.LayoutControl1.Controls.Add(Me.FirstCurrencyName_lbl)
        Me.LayoutControl1.Controls.Add(Me.ConvertedAmount_lbl)
        Me.LayoutControl1.Controls.Add(Me.ConvertedCurrency_lbl)
        Me.LayoutControl1.Controls.Add(Me.PanelControl1)
        Me.LayoutControl1.Controls.Add(Me.Convert_btn)
        Me.LayoutControl1.Controls.Add(Me.RateSecondCurrencyComboBoxEdit)
        Me.LayoutControl1.Controls.Add(Me.RateSecondCurrencyTextEdit)
        Me.LayoutControl1.Controls.Add(Me.RateFirstCurrencyTextEdit)
        Me.LayoutControl1.Controls.Add(Me.RateFirstCurrencyComboBoxEdit)
        Me.LayoutControl1.Controls.Add(Me.AmountToConvertTextEdit)
        Me.LayoutControl1.Controls.Add(Me.LoadExchangeRatesOCBS_btn)
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.ExchangeRateDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.ExchangeRatesOCBSreport_btn)
        Me.LayoutControl1.Controls.Add(Me.CurrenciesConvert_Print_Export_btn)
        Me.LayoutControl1.Controls.Add(Me.CurrencyFromComboBoxEdit)
        Me.LayoutControl1.Controls.Add(Me.CurrencyToComboBoxEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(911, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1125, 703)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SecondCurrencyName_lbl
        '
        Me.SecondCurrencyName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SecondCurrencyName_lbl.Appearance.Options.UseFont = True
        Me.SecondCurrencyName_lbl.Appearance.Options.UseTextOptions = True
        Me.SecondCurrencyName_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SecondCurrencyName_lbl.Location = New System.Drawing.Point(757, 319)
        Me.SecondCurrencyName_lbl.Name = "SecondCurrencyName_lbl"
        Me.SecondCurrencyName_lbl.Size = New System.Drawing.Size(344, 13)
        Me.SecondCurrencyName_lbl.StyleController = Me.LayoutControl1
        Me.SecondCurrencyName_lbl.TabIndex = 26
        '
        'FirstCurrencyName_lbl
        '
        Me.FirstCurrencyName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FirstCurrencyName_lbl.Appearance.Options.UseFont = True
        Me.FirstCurrencyName_lbl.Appearance.Options.UseTextOptions = True
        Me.FirstCurrencyName_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FirstCurrencyName_lbl.Location = New System.Drawing.Point(24, 319)
        Me.FirstCurrencyName_lbl.Name = "FirstCurrencyName_lbl"
        Me.FirstCurrencyName_lbl.Size = New System.Drawing.Size(279, 13)
        Me.FirstCurrencyName_lbl.StyleController = Me.LayoutControl1
        Me.FirstCurrencyName_lbl.TabIndex = 25
        '
        'ConvertedAmount_lbl
        '
        Me.ConvertedAmount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ConvertedAmount_lbl.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.ConvertedAmount_lbl.Appearance.Options.UseFont = True
        Me.ConvertedAmount_lbl.Appearance.Options.UseForeColor = True
        Me.ConvertedAmount_lbl.Location = New System.Drawing.Point(515, 492)
        Me.ConvertedAmount_lbl.Name = "ConvertedAmount_lbl"
        Me.ConvertedAmount_lbl.Size = New System.Drawing.Size(237, 21)
        Me.ConvertedAmount_lbl.StyleController = Me.LayoutControl1
        Me.ConvertedAmount_lbl.TabIndex = 24
        '
        'ConvertedCurrency_lbl
        '
        Me.ConvertedCurrency_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ConvertedCurrency_lbl.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.ConvertedCurrency_lbl.Appearance.Options.UseFont = True
        Me.ConvertedCurrency_lbl.Appearance.Options.UseForeColor = True
        Me.ConvertedCurrency_lbl.Appearance.Options.UseTextOptions = True
        Me.ConvertedCurrency_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ConvertedCurrency_lbl.Location = New System.Drawing.Point(435, 492)
        Me.ConvertedCurrency_lbl.Name = "ConvertedCurrency_lbl"
        Me.ConvertedCurrency_lbl.Size = New System.Drawing.Size(66, 21)
        Me.ConvertedCurrency_lbl.StyleController = Me.LayoutControl1
        Me.ConvertedCurrency_lbl.TabIndex = 23
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GroupControl1)
        Me.PanelControl1.Controls.Add(Me.SecondCurrencyToEURrate_lbl)
        Me.PanelControl1.Controls.Add(Me.SecondCurrencyToEUR_lbl)
        Me.PanelControl1.Controls.Add(Me.FirstCurrencyToEURrate_lbl)
        Me.PanelControl1.Controls.Add(Me.FirstCurrencyToEUR_lbl)
        Me.PanelControl1.Location = New System.Drawing.Point(304, 539)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(447, 152)
        Me.PanelControl1.TabIndex = 22
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.Controls.Add(Me.CrossRateCurrencies_lbl)
        Me.GroupControl1.Controls.Add(Me.CrossCurrencies_lbl)
        Me.GroupControl1.Location = New System.Drawing.Point(81, 64)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(295, 75)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "CROSS RATE"
        '
        'CrossRateCurrencies_lbl
        '
        Me.CrossRateCurrencies_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CrossRateCurrencies_lbl.Appearance.Options.UseFont = True
        Me.CrossRateCurrencies_lbl.Location = New System.Drawing.Point(151, 39)
        Me.CrossRateCurrencies_lbl.Name = "CrossRateCurrencies_lbl"
        Me.CrossRateCurrencies_lbl.Size = New System.Drawing.Size(78, 13)
        Me.CrossRateCurrencies_lbl.TabIndex = 5
        Me.CrossRateCurrencies_lbl.Text = "LabelControl7"
        '
        'CrossCurrencies_lbl
        '
        Me.CrossCurrencies_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CrossCurrencies_lbl.Appearance.Options.UseFont = True
        Me.CrossCurrencies_lbl.Location = New System.Drawing.Point(60, 39)
        Me.CrossCurrencies_lbl.Name = "CrossCurrencies_lbl"
        Me.CrossCurrencies_lbl.Size = New System.Drawing.Size(78, 13)
        Me.CrossCurrencies_lbl.TabIndex = 4
        Me.CrossCurrencies_lbl.Text = "LabelControl6"
        '
        'SecondCurrencyToEURrate_lbl
        '
        Me.SecondCurrencyToEURrate_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SecondCurrencyToEURrate_lbl.Appearance.Options.UseFont = True
        Me.SecondCurrencyToEURrate_lbl.Location = New System.Drawing.Point(232, 45)
        Me.SecondCurrencyToEURrate_lbl.Name = "SecondCurrencyToEURrate_lbl"
        Me.SecondCurrencyToEURrate_lbl.Size = New System.Drawing.Size(78, 13)
        Me.SecondCurrencyToEURrate_lbl.TabIndex = 3
        Me.SecondCurrencyToEURrate_lbl.Text = "LabelControl4"
        '
        'SecondCurrencyToEUR_lbl
        '
        Me.SecondCurrencyToEUR_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SecondCurrencyToEUR_lbl.Appearance.Options.UseFont = True
        Me.SecondCurrencyToEUR_lbl.Location = New System.Drawing.Point(145, 45)
        Me.SecondCurrencyToEUR_lbl.Name = "SecondCurrencyToEUR_lbl"
        Me.SecondCurrencyToEUR_lbl.Size = New System.Drawing.Size(78, 13)
        Me.SecondCurrencyToEUR_lbl.TabIndex = 2
        Me.SecondCurrencyToEUR_lbl.Text = "LabelControl5"
        '
        'FirstCurrencyToEURrate_lbl
        '
        Me.FirstCurrencyToEURrate_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FirstCurrencyToEURrate_lbl.Appearance.Options.UseFont = True
        Me.FirstCurrencyToEURrate_lbl.Location = New System.Drawing.Point(232, 26)
        Me.FirstCurrencyToEURrate_lbl.Name = "FirstCurrencyToEURrate_lbl"
        Me.FirstCurrencyToEURrate_lbl.Size = New System.Drawing.Size(78, 13)
        Me.FirstCurrencyToEURrate_lbl.TabIndex = 1
        Me.FirstCurrencyToEURrate_lbl.Text = "LabelControl3"
        '
        'FirstCurrencyToEUR_lbl
        '
        Me.FirstCurrencyToEUR_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FirstCurrencyToEUR_lbl.Appearance.Options.UseFont = True
        Me.FirstCurrencyToEUR_lbl.Location = New System.Drawing.Point(145, 26)
        Me.FirstCurrencyToEUR_lbl.Name = "FirstCurrencyToEUR_lbl"
        Me.FirstCurrencyToEUR_lbl.Size = New System.Drawing.Size(78, 13)
        Me.FirstCurrencyToEUR_lbl.TabIndex = 0
        Me.FirstCurrencyToEUR_lbl.Text = "LabelControl2"
        '
        'Convert_btn
        '
        Me.Convert_btn.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Convert_btn.Appearance.Options.UseFont = True
        Me.Convert_btn.ImageIndex = 6
        Me.Convert_btn.ImageList = Me.ImageCollection1
        Me.Convert_btn.Location = New System.Drawing.Point(435, 466)
        Me.Convert_btn.Name = "Convert_btn"
        Me.Convert_btn.Size = New System.Drawing.Size(189, 22)
        Me.Convert_btn.StyleController = Me.LayoutControl1
        Me.Convert_btn.TabIndex = 20
        Me.Convert_btn.Text = "Convert"
        '
        'RateSecondCurrencyComboBoxEdit
        '
        Me.RateSecondCurrencyComboBoxEdit.EditValue = "MIDDLE"
        Me.RateSecondCurrencyComboBoxEdit.Location = New System.Drawing.Point(628, 418)
        Me.RateSecondCurrencyComboBoxEdit.Name = "RateSecondCurrencyComboBoxEdit"
        Me.RateSecondCurrencyComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RateSecondCurrencyComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RateSecondCurrencyComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RateSecondCurrencyComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.RateSecondCurrencyComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.RateSecondCurrencyComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RateSecondCurrencyComboBoxEdit.Properties.Items.AddRange(New Object() {"MIDDLE", "Custom"})
        Me.RateSecondCurrencyComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.RateSecondCurrencyComboBoxEdit.Size = New System.Drawing.Size(125, 20)
        Me.RateSecondCurrencyComboBoxEdit.StyleController = Me.LayoutControl1
        Me.RateSecondCurrencyComboBoxEdit.TabIndex = 19
        '
        'RateSecondCurrencyTextEdit
        '
        Me.RateSecondCurrencyTextEdit.Location = New System.Drawing.Point(628, 442)
        Me.RateSecondCurrencyTextEdit.Name = "RateSecondCurrencyTextEdit"
        Me.RateSecondCurrencyTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RateSecondCurrencyTextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RateSecondCurrencyTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RateSecondCurrencyTextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.RateSecondCurrencyTextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.RateSecondCurrencyTextEdit.Properties.ReadOnly = True
        Me.RateSecondCurrencyTextEdit.Size = New System.Drawing.Size(125, 20)
        Me.RateSecondCurrencyTextEdit.StyleController = Me.LayoutControl1
        Me.RateSecondCurrencyTextEdit.TabIndex = 18
        '
        'RateFirstCurrencyTextEdit
        '
        Me.RateFirstCurrencyTextEdit.Location = New System.Drawing.Point(307, 442)
        Me.RateFirstCurrencyTextEdit.Name = "RateFirstCurrencyTextEdit"
        Me.RateFirstCurrencyTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RateFirstCurrencyTextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RateFirstCurrencyTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RateFirstCurrencyTextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.RateFirstCurrencyTextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.RateFirstCurrencyTextEdit.Properties.ReadOnly = True
        Me.RateFirstCurrencyTextEdit.Size = New System.Drawing.Size(124, 20)
        Me.RateFirstCurrencyTextEdit.StyleController = Me.LayoutControl1
        Me.RateFirstCurrencyTextEdit.TabIndex = 17
        '
        'RateFirstCurrencyComboBoxEdit
        '
        Me.RateFirstCurrencyComboBoxEdit.EditValue = "MIDDLE"
        Me.RateFirstCurrencyComboBoxEdit.Location = New System.Drawing.Point(307, 418)
        Me.RateFirstCurrencyComboBoxEdit.Name = "RateFirstCurrencyComboBoxEdit"
        Me.RateFirstCurrencyComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RateFirstCurrencyComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RateFirstCurrencyComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RateFirstCurrencyComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.RateFirstCurrencyComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.RateFirstCurrencyComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RateFirstCurrencyComboBoxEdit.Properties.Items.AddRange(New Object() {"MIDDLE", "Custom"})
        Me.RateFirstCurrencyComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.RateFirstCurrencyComboBoxEdit.Size = New System.Drawing.Size(124, 20)
        Me.RateFirstCurrencyComboBoxEdit.StyleController = Me.LayoutControl1
        Me.RateFirstCurrencyComboBoxEdit.TabIndex = 15
        '
        'AmountToConvertTextEdit
        '
        Me.AmountToConvertTextEdit.EditValue = "0,00"
        Me.AmountToConvertTextEdit.Location = New System.Drawing.Point(435, 376)
        Me.AmountToConvertTextEdit.Name = "AmountToConvertTextEdit"
        Me.AmountToConvertTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AmountToConvertTextEdit.Properties.Appearance.Options.UseFont = True
        Me.AmountToConvertTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.AmountToConvertTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AmountToConvertTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountToConvertTextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountToConvertTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountToConvertTextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.AmountToConvertTextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n2"
        Me.AmountToConvertTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountToConvertTextEdit.Size = New System.Drawing.Size(189, 22)
        Me.AmountToConvertTextEdit.StyleController = Me.LayoutControl1
        Me.AmountToConvertTextEdit.TabIndex = 16
        '
        'LoadExchangeRatesOCBS_btn
        '
        Me.LoadExchangeRatesOCBS_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadExchangeRatesOCBS_btn.ImageIndex = 6
        Me.LoadExchangeRatesOCBS_btn.Location = New System.Drawing.Point(128, 12)
        Me.LoadExchangeRatesOCBS_btn.Name = "LoadExchangeRatesOCBS_btn"
        Me.LoadExchangeRatesOCBS_btn.Size = New System.Drawing.Size(134, 22)
        Me.LoadExchangeRatesOCBS_btn.StyleController = Me.LayoutControl1
        Me.LoadExchangeRatesOCBS_btn.TabIndex = 8
        Me.LoadExchangeRatesOCBS_btn.Text = "Load Exchange Rates"
        '
        'TillDateEdit
        '
        Me.TillDateEdit.EditValue = Nothing
        Me.TillDateEdit.Location = New System.Drawing.Point(233, 12)
        Me.TillDateEdit.Name = "TillDateEdit"
        Me.TillDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TillDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TillDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TillDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TillDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TillDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TillDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TillDateEdit.Size = New System.Drawing.Size(62, 20)
        Me.TillDateEdit.StyleController = Me.LayoutControl1
        Me.TillDateEdit.TabIndex = 13
        '
        'ExchangeRateDateEdit
        '
        Me.ExchangeRateDateEdit.EditValue = Nothing
        Me.ExchangeRateDateEdit.Location = New System.Drawing.Point(487, 54)
        Me.ExchangeRateDateEdit.Name = "ExchangeRateDateEdit"
        Me.ExchangeRateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExchangeRateDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ExchangeRateDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ExchangeRateDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ExchangeRateDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExchangeRateDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExchangeRateDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExchangeRateDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExchangeRateDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ExchangeRateDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ExchangeRateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExchangeRateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ExchangeRateDateEdit.Size = New System.Drawing.Size(126, 22)
        Me.ExchangeRateDateEdit.StyleController = Me.LayoutControl1
        Me.ExchangeRateDateEdit.TabIndex = 12
        '
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.EXCHANGE_RATES_ECBBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 82)
        Me.GridControl2.MainView = Me.ExchangeRatesECBBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2})
        Me.GridControl2.Size = New System.Drawing.Size(1101, 203)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExchangeRatesECBBaseView, Me.CustomerAccountsDetailView, Me.GridView2})
        '
        'EXCHANGE_RATES_ECBBindingSource
        '
        Me.EXCHANGE_RATES_ECBBindingSource.DataMember = "EXCHANGE RATES ECB"
        Me.EXCHANGE_RATES_ECBBindingSource.DataSource = Me.EXTERNALDataset
        '
        'ExchangeRatesECBBaseView
        '
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExchangeRatesECBBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExchangeRatesECBBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colCURRENCYRATE, Me.colEXCHANGERATEDATE, Me.GridColumn1})
        Me.ExchangeRatesECBBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExchangeRatesECBBaseView.GridControl = Me.GridControl2
        Me.ExchangeRatesECBBaseView.Name = "ExchangeRatesECBBaseView"
        Me.ExchangeRatesECBBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExchangeRatesECBBaseView.OptionsFilter.AllowFilterEditor = False
        Me.ExchangeRatesECBBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExchangeRatesECBBaseView.OptionsSelection.MultiSelect = True
        Me.ExchangeRatesECBBaseView.OptionsView.ColumnAutoWidth = False
        Me.ExchangeRatesECBBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExchangeRatesECBBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
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
        Me.colCURRENCYCODE.VisibleIndex = 0
        Me.colCURRENCYCODE.Width = 104
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME.OptionsColumn.ReadOnly = True
        Me.colCURRENCYNAME.Visible = True
        Me.colCURRENCYNAME.VisibleIndex = 1
        Me.colCURRENCYNAME.Width = 402
        '
        'colCURRENCYRATE
        '
        Me.colCURRENCYRATE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYRATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCURRENCYRATE.Caption = "EXCHANGE RATE"
        Me.colCURRENCYRATE.FieldName = "CURRENCY RATE"
        Me.colCURRENCYRATE.Name = "colCURRENCYRATE"
        Me.colCURRENCYRATE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYRATE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYRATE.Visible = True
        Me.colCURRENCYRATE.VisibleIndex = 2
        Me.colCURRENCYRATE.Width = 125
        '
        'colEXCHANGERATEDATE
        '
        Me.colEXCHANGERATEDATE.FieldName = "EXCHANGE RATE DATE"
        Me.colEXCHANGERATEDATE.Name = "colEXCHANGERATEDATE"
        Me.colEXCHANGERATEDATE.OptionsColumn.AllowEdit = False
        Me.colEXCHANGERATEDATE.OptionsColumn.ReadOnly = True
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn1.AppearanceCell.Options.UseFont = True
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "in EURO"
        Me.GridColumn1.DisplayFormat.FormatString = "c4"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn1.FieldName = "GridColumn1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.UnboundExpression = "1/[CURRENCY RATE]"
        Me.GridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 95
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A - ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "C - CLOSE ", 3)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
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
        'CustomerAccountsDetailView
        '
        Me.CustomerAccountsDetailView.CardMinSize = New System.Drawing.Size(615, 282)
        Me.CustomerAccountsDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colClientNo1, Me.colClientAccount1, Me.colDealCurrency1, Me.colAccountStatus1, Me.colOnline1, Me.colEnglishName1, Me.colProductCode1, Me.colCurrencyStatus1, Me.colCountry1, Me.colPRD_TYPE1, Me.colOPEN_DATE1, Me.colCLOSE_DATE1})
        Me.CustomerAccountsDetailView.GridControl = Me.GridControl2
        Me.CustomerAccountsDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.CustomerAccountsDetailView.Name = "CustomerAccountsDetailView"
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CustomerAccountsDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.CustomerAccountsDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.CustomerAccountsDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.CustomerAccountsDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.CustomerAccountsDetailView.OptionsCustomization.AllowFilter = False
        Me.CustomerAccountsDetailView.OptionsCustomization.AllowSort = False
        Me.CustomerAccountsDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowFilterEditor = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.CustomerAccountsDetailView.OptionsFind.AllowFindPanel = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.CustomerAccountsDetailView.OptionsView.ShowHeaderPanel = False
        Me.CustomerAccountsDetailView.TemplateCard = Me.LayoutViewCard1
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
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(595, 240)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colClientNo1
        '
        Me.colClientNo1.FieldName = "ClientNo"
        Me.colClientNo1.LayoutViewField = Me.layoutViewField_colClientNo1
        Me.colClientNo1.Name = "colClientNo1"
        Me.colClientNo1.OptionsColumn.AllowEdit = False
        Me.colClientNo1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colClientNo1
        '
        Me.layoutViewField_colClientNo1.EditorPreferredWidth = 82
        Me.layoutViewField_colClientNo1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colClientNo1.Name = "layoutViewField_colClientNo1"
        Me.layoutViewField_colClientNo1.Size = New System.Drawing.Size(173, 20)
        Me.layoutViewField_colClientNo1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colClientAccount1
        '
        Me.colClientAccount1.FieldName = "Client Account"
        Me.colClientAccount1.LayoutViewField = Me.layoutViewField_colClientAccount1
        Me.colClientAccount1.Name = "colClientAccount1"
        Me.colClientAccount1.OptionsColumn.AllowEdit = False
        Me.colClientAccount1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colClientAccount1
        '
        Me.layoutViewField_colClientAccount1.EditorPreferredWidth = 134
        Me.layoutViewField_colClientAccount1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colClientAccount1.Name = "layoutViewField_colClientAccount1"
        Me.layoutViewField_colClientAccount1.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colClientAccount1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colDealCurrency1
        '
        Me.colDealCurrency1.FieldName = "Deal Currency"
        Me.colDealCurrency1.LayoutViewField = Me.layoutViewField_colDealCurrency1
        Me.colDealCurrency1.Name = "colDealCurrency1"
        Me.colDealCurrency1.OptionsColumn.AllowEdit = False
        Me.colDealCurrency1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colDealCurrency1
        '
        Me.layoutViewField_colDealCurrency1.EditorPreferredWidth = 47
        Me.layoutViewField_colDealCurrency1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colDealCurrency1.Name = "layoutViewField_colDealCurrency1"
        Me.layoutViewField_colDealCurrency1.Size = New System.Drawing.Size(138, 20)
        Me.layoutViewField_colDealCurrency1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colAccountStatus1
        '
        Me.colAccountStatus1.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colAccountStatus1.FieldName = "Account Status"
        Me.colAccountStatus1.LayoutViewField = Me.layoutViewField_colAccountStatus1
        Me.colAccountStatus1.Name = "colAccountStatus1"
        Me.colAccountStatus1.OptionsColumn.AllowEdit = False
        Me.colAccountStatus1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAccountStatus1
        '
        Me.layoutViewField_colAccountStatus1.EditorPreferredWidth = 32
        Me.layoutViewField_colAccountStatus1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colAccountStatus1.Name = "layoutViewField_colAccountStatus1"
        Me.layoutViewField_colAccountStatus1.Size = New System.Drawing.Size(123, 20)
        Me.layoutViewField_colAccountStatus1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colOnline1
        '
        Me.colOnline1.ColumnEdit = Me.RepositoryItemImageComboBox2
        Me.colOnline1.FieldName = "Online"
        Me.colOnline1.LayoutViewField = Me.layoutViewField_colOnline1
        Me.colOnline1.Name = "colOnline1"
        Me.colOnline1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        '
        'layoutViewField_colOnline1
        '
        Me.layoutViewField_colOnline1.EditorPreferredWidth = 32
        Me.layoutViewField_colOnline1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colOnline1.Name = "layoutViewField_colOnline1"
        Me.layoutViewField_colOnline1.Size = New System.Drawing.Size(123, 20)
        Me.layoutViewField_colOnline1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colEnglishName1
        '
        Me.colEnglishName1.FieldName = "English Name"
        Me.colEnglishName1.LayoutViewField = Me.layoutViewField_colEnglishName1
        Me.colEnglishName1.Name = "colEnglishName1"
        Me.colEnglishName1.OptionsColumn.AllowEdit = False
        Me.colEnglishName1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colEnglishName1
        '
        Me.layoutViewField_colEnglishName1.EditorPreferredWidth = 487
        Me.layoutViewField_colEnglishName1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colEnglishName1.Name = "layoutViewField_colEnglishName1"
        Me.layoutViewField_colEnglishName1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colEnglishName1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colProductCode1
        '
        Me.colProductCode1.FieldName = "ProductCode"
        Me.colProductCode1.LayoutViewField = Me.layoutViewField_colProductCode1
        Me.colProductCode1.Name = "colProductCode1"
        Me.colProductCode1.OptionsColumn.AllowEdit = False
        Me.colProductCode1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colProductCode1
        '
        Me.layoutViewField_colProductCode1.EditorPreferredWidth = 93
        Me.layoutViewField_colProductCode1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colProductCode1.Name = "layoutViewField_colProductCode1"
        Me.layoutViewField_colProductCode1.Size = New System.Drawing.Size(184, 20)
        Me.layoutViewField_colProductCode1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCurrencyStatus1
        '
        Me.colCurrencyStatus1.FieldName = "Currency Status"
        Me.colCurrencyStatus1.LayoutViewField = Me.layoutViewField_colCurrencyStatus1
        Me.colCurrencyStatus1.Name = "colCurrencyStatus1"
        Me.colCurrencyStatus1.OptionsColumn.AllowEdit = False
        Me.colCurrencyStatus1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrencyStatus1
        '
        Me.layoutViewField_colCurrencyStatus1.EditorPreferredWidth = 93
        Me.layoutViewField_colCurrencyStatus1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colCurrencyStatus1.Name = "layoutViewField_colCurrencyStatus1"
        Me.layoutViewField_colCurrencyStatus1.Size = New System.Drawing.Size(184, 20)
        Me.layoutViewField_colCurrencyStatus1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCountry1
        '
        Me.colCountry1.FieldName = "Country"
        Me.colCountry1.LayoutViewField = Me.layoutViewField_colCountry1
        Me.colCountry1.Name = "colCountry1"
        Me.colCountry1.OptionsColumn.AllowEdit = False
        Me.colCountry1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCountry1
        '
        Me.layoutViewField_colCountry1.EditorPreferredWidth = 487
        Me.layoutViewField_colCountry1.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colCountry1.Name = "layoutViewField_colCountry1"
        Me.layoutViewField_colCountry1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colCountry1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colPRD_TYPE1
        '
        Me.colPRD_TYPE1.Caption = "PRD TYPE"
        Me.colPRD_TYPE1.FieldName = "PRD_TYPE"
        Me.colPRD_TYPE1.LayoutViewField = Me.layoutViewField_colPRD_TYPE1
        Me.colPRD_TYPE1.Name = "colPRD_TYPE1"
        Me.colPRD_TYPE1.OptionsColumn.AllowEdit = False
        Me.colPRD_TYPE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPRD_TYPE1
        '
        Me.layoutViewField_colPRD_TYPE1.EditorPreferredWidth = 487
        Me.layoutViewField_colPRD_TYPE1.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colPRD_TYPE1.Name = "layoutViewField_colPRD_TYPE1"
        Me.layoutViewField_colPRD_TYPE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colPRD_TYPE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colOPEN_DATE1
        '
        Me.colOPEN_DATE1.Caption = "OPEN DATE"
        Me.colOPEN_DATE1.FieldName = "OPEN_DATE"
        Me.colOPEN_DATE1.LayoutViewField = Me.layoutViewField_colOPEN_DATE1
        Me.colOPEN_DATE1.Name = "colOPEN_DATE1"
        Me.colOPEN_DATE1.OptionsColumn.AllowEdit = False
        Me.colOPEN_DATE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colOPEN_DATE1
        '
        Me.layoutViewField_colOPEN_DATE1.EditorPreferredWidth = 487
        Me.layoutViewField_colOPEN_DATE1.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colOPEN_DATE1.Name = "layoutViewField_colOPEN_DATE1"
        Me.layoutViewField_colOPEN_DATE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colOPEN_DATE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCLOSE_DATE1
        '
        Me.colCLOSE_DATE1.Caption = "CLOSE DATE"
        Me.colCLOSE_DATE1.FieldName = "CLOSE_DATE"
        Me.colCLOSE_DATE1.LayoutViewField = Me.layoutViewField_colCLOSE_DATE1
        Me.colCLOSE_DATE1.Name = "colCLOSE_DATE1"
        Me.colCLOSE_DATE1.OptionsColumn.AllowEdit = False
        Me.colCLOSE_DATE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCLOSE_DATE1
        '
        Me.layoutViewField_colCLOSE_DATE1.EditorPreferredWidth = 487
        Me.layoutViewField_colCLOSE_DATE1.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_colCLOSE_DATE1.Name = "layoutViewField_colCLOSE_DATE1"
        Me.layoutViewField_colCLOSE_DATE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colCLOSE_DATE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colClientNo1, Me.layoutViewField_colClientAccount1, Me.layoutViewField_colDealCurrency1, Me.layoutViewField_colAccountStatus1, Me.layoutViewField_colOnline1, Me.layoutViewField_colEnglishName1, Me.layoutViewField_colProductCode1, Me.layoutViewField_colCurrencyStatus1, Me.layoutViewField_colCountry1, Me.layoutViewField_colPRD_TYPE1, Me.layoutViewField_colOPEN_DATE1, Me.layoutViewField_colCLOSE_DATE1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
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
        'ExchangeRatesOCBSreport_btn
        '
        Me.ExchangeRatesOCBSreport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExchangeRatesOCBSreport_btn.ImageIndex = 5
        Me.ExchangeRatesOCBSreport_btn.Location = New System.Drawing.Point(969, 12)
        Me.ExchangeRatesOCBSreport_btn.Name = "ExchangeRatesOCBSreport_btn"
        Me.ExchangeRatesOCBSreport_btn.Size = New System.Drawing.Size(144, 22)
        Me.ExchangeRatesOCBSreport_btn.StyleController = Me.LayoutControl1
        Me.ExchangeRatesOCBSreport_btn.TabIndex = 7
        Me.ExchangeRatesOCBSreport_btn.Text = "Exchange Rates Report"
        '
        'CurrenciesConvert_Print_Export_btn
        '
        Me.CurrenciesConvert_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CurrenciesConvert_Print_Export_btn.ImageIndex = 2
        Me.CurrenciesConvert_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.CurrenciesConvert_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.CurrenciesConvert_Print_Export_btn.Name = "CurrenciesConvert_Print_Export_btn"
        Me.CurrenciesConvert_Print_Export_btn.Size = New System.Drawing.Size(112, 22)
        Me.CurrenciesConvert_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.CurrenciesConvert_Print_Export_btn.TabIndex = 9
        Me.CurrenciesConvert_Print_Export_btn.Text = "Print or Export"
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
        Me.ImageCollection1.InsertGalleryImage("convert_16x16.png", "images/actions/convert_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/convert_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "convert_16x16.png")
        '
        'CurrencyToComboBoxEdit
        '
        Me.CurrencyToComboBoxEdit.Location = New System.Drawing.Point(628, 335)
        Me.CurrencyToComboBoxEdit.Name = "CurrencyToComboBoxEdit"
        Me.CurrencyToComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyToComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyToComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyToComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyToComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyToComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyToComboBoxEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 108, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VALID", "VALID", 39, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.CurrencyToComboBoxEdit.Properties.DataSource = Me.CURRENCIESBindingSource
        Me.CurrencyToComboBoxEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.CurrencyToComboBoxEdit.Properties.NullText = ""
        Me.CurrencyToComboBoxEdit.Properties.PopupSizeable = False
        Me.CurrencyToComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CurrencyToComboBoxEdit.Properties.ValueMember = "CURRENCY CODE"
        Me.CurrencyToComboBoxEdit.Size = New System.Drawing.Size(125, 20)
        Me.CurrencyToComboBoxEdit.StyleController = Me.LayoutControl1
        Me.CurrencyToComboBoxEdit.TabIndex = 15
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
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TillDateEdit
        Me.LayoutControlItem6.CustomizationFormText = "Date Till"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(116, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Date till"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.LayoutControlGroup2, Me.LayoutControlItem17, Me.EmptySpaceItem21, Me.LayoutControlItem5, Me.EmptySpaceItem8, Me.EmptySpaceItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1125, 703)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(254, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(701, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CurrenciesConvert_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(116, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ExchangeRatesOCBSreport_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(957, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(955, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1105, 207)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LoadExchangeRatesOCBS_btn
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(116, 0)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(743, 527)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(362, 156)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem9, Me.EmptySpaceItem4, Me.EmptySpaceItem3, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.LayoutControlItem10, Me.EmptySpaceItem7, Me.EmptySpaceItem10, Me.LayoutControlItem11, Me.EmptySpaceItem11, Me.LayoutControlItem12, Me.EmptySpaceItem12, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.EmptySpaceItem13, Me.EmptySpaceItem14, Me.EmptySpaceItem15, Me.EmptySpaceItem16, Me.LayoutControlItem15, Me.EmptySpaceItem17, Me.EmptySpaceItem18, Me.EmptySpaceItem19, Me.EmptySpaceItem20, Me.LayoutControlItem16, Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.EmptySpaceItem22})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 277)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1105, 250)
        Me.LayoutControlGroup2.Text = "Currencies Convertion"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.CurrencyToComboBoxEdit
        Me.LayoutControlItem9.CustomizationFormText = "Currency"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(604, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(129, 41)
        Me.LayoutControlItem9.Text = "Currency"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(99, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(411, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(193, 41)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.CustomizationFormText = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(733, 17)
        Me.EmptySpaceItem5.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(348, 24)
        Me.EmptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.CustomizationFormText = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(604, 41)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(477, 42)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.AmountToConvertTextEdit
        Me.LayoutControlItem10.CustomizationFormText = "Amount"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(411, 41)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(193, 42)
        Me.LayoutControlItem10.Text = "Amount"
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(99, 13)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.CustomizationFormText = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 41)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(411, 42)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.CustomizationFormText = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(733, 83)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(348, 40)
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.RateFirstCurrencyComboBoxEdit
        Me.LayoutControlItem11.CustomizationFormText = "Rate"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(283, 83)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(128, 40)
        Me.LayoutControlItem11.Text = "Rate"
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(99, 13)
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.CustomizationFormText = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(0, 83)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(283, 40)
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.RateFirstCurrencyTextEdit
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(283, 123)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(128, 24)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem12
        '
        Me.EmptySpaceItem12.AllowHotTrack = False
        Me.EmptySpaceItem12.CustomizationFormText = "EmptySpaceItem12"
        Me.EmptySpaceItem12.Location = New System.Drawing.Point(0, 123)
        Me.EmptySpaceItem12.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem12.Size = New System.Drawing.Size(283, 24)
        Me.EmptySpaceItem12.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.RateSecondCurrencyTextEdit
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(604, 123)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(129, 24)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.RateSecondCurrencyComboBoxEdit
        Me.LayoutControlItem14.CustomizationFormText = "Rate"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(604, 83)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(129, 40)
        Me.LayoutControlItem14.Text = "Rate"
        Me.LayoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(99, 13)
        '
        'EmptySpaceItem13
        '
        Me.EmptySpaceItem13.AllowHotTrack = False
        Me.EmptySpaceItem13.CustomizationFormText = "EmptySpaceItem13"
        Me.EmptySpaceItem13.Location = New System.Drawing.Point(411, 83)
        Me.EmptySpaceItem13.Name = "EmptySpaceItem13"
        Me.EmptySpaceItem13.Size = New System.Drawing.Size(193, 40)
        Me.EmptySpaceItem13.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem14
        '
        Me.EmptySpaceItem14.AllowHotTrack = False
        Me.EmptySpaceItem14.CustomizationFormText = "EmptySpaceItem14"
        Me.EmptySpaceItem14.Location = New System.Drawing.Point(411, 123)
        Me.EmptySpaceItem14.Name = "EmptySpaceItem14"
        Me.EmptySpaceItem14.Size = New System.Drawing.Size(193, 24)
        Me.EmptySpaceItem14.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem15
        '
        Me.EmptySpaceItem15.AllowHotTrack = False
        Me.EmptySpaceItem15.CustomizationFormText = "EmptySpaceItem15"
        Me.EmptySpaceItem15.Location = New System.Drawing.Point(733, 123)
        Me.EmptySpaceItem15.Name = "EmptySpaceItem15"
        Me.EmptySpaceItem15.Size = New System.Drawing.Size(348, 24)
        Me.EmptySpaceItem15.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem16
        '
        Me.EmptySpaceItem16.AllowHotTrack = False
        Me.EmptySpaceItem16.CustomizationFormText = "EmptySpaceItem16"
        Me.EmptySpaceItem16.Location = New System.Drawing.Point(604, 147)
        Me.EmptySpaceItem16.Name = "EmptySpaceItem16"
        Me.EmptySpaceItem16.Size = New System.Drawing.Size(477, 26)
        Me.EmptySpaceItem16.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.Convert_btn
        Me.LayoutControlItem15.CustomizationFormText = "LayoutControlItem15"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(411, 147)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(193, 26)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'EmptySpaceItem17
        '
        Me.EmptySpaceItem17.AllowHotTrack = False
        Me.EmptySpaceItem17.CustomizationFormText = "EmptySpaceItem17"
        Me.EmptySpaceItem17.Location = New System.Drawing.Point(0, 147)
        Me.EmptySpaceItem17.Name = "EmptySpaceItem17"
        Me.EmptySpaceItem17.Size = New System.Drawing.Size(411, 26)
        Me.EmptySpaceItem17.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem18
        '
        Me.EmptySpaceItem18.AllowHotTrack = False
        Me.EmptySpaceItem18.CustomizationFormText = "EmptySpaceItem18"
        Me.EmptySpaceItem18.Location = New System.Drawing.Point(732, 173)
        Me.EmptySpaceItem18.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem18.Name = "EmptySpaceItem18"
        Me.EmptySpaceItem18.Size = New System.Drawing.Size(349, 25)
        Me.EmptySpaceItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem18.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem19
        '
        Me.EmptySpaceItem19.AllowHotTrack = False
        Me.EmptySpaceItem19.CustomizationFormText = "EmptySpaceItem19"
        Me.EmptySpaceItem19.Location = New System.Drawing.Point(0, 173)
        Me.EmptySpaceItem19.Name = "EmptySpaceItem19"
        Me.EmptySpaceItem19.Size = New System.Drawing.Size(411, 25)
        Me.EmptySpaceItem19.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem20
        '
        Me.EmptySpaceItem20.AllowHotTrack = False
        Me.EmptySpaceItem20.CustomizationFormText = "EmptySpaceItem20"
        Me.EmptySpaceItem20.Location = New System.Drawing.Point(0, 198)
        Me.EmptySpaceItem20.Name = "EmptySpaceItem20"
        Me.EmptySpaceItem20.Size = New System.Drawing.Size(1081, 10)
        Me.EmptySpaceItem20.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.ConvertedCurrency_lbl
        Me.LayoutControlItem16.CustomizationFormText = "LayoutControlItem16"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(411, 173)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(70, 25)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.ConvertedAmount_lbl
        Me.LayoutControlItem18.CustomizationFormText = "LayoutControlItem18"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(491, 173)
        Me.LayoutControlItem18.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(241, 25)
        Me.LayoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem19.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem19.Control = Me.FirstCurrencyName_lbl
        Me.LayoutControlItem19.CustomizationFormText = "LayoutControlItem19"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem19.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(283, 17)
        Me.LayoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem20.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem20.Control = Me.SecondCurrencyName_lbl
        Me.LayoutControlItem20.CustomizationFormText = "LayoutControlItem20"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(733, 0)
        Me.LayoutControlItem20.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(348, 17)
        Me.LayoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'EmptySpaceItem22
        '
        Me.EmptySpaceItem22.AllowHotTrack = False
        Me.EmptySpaceItem22.CustomizationFormText = "EmptySpaceItem22"
        Me.EmptySpaceItem22.Location = New System.Drawing.Point(481, 173)
        Me.EmptySpaceItem22.Name = "EmptySpaceItem22"
        Me.EmptySpaceItem22.Size = New System.Drawing.Size(10, 25)
        Me.EmptySpaceItem22.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.PanelControl1
        Me.LayoutControlItem17.CustomizationFormText = "LayoutControlItem17"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(292, 527)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(451, 156)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'EmptySpaceItem21
        '
        Me.EmptySpaceItem21.AllowHotTrack = False
        Me.EmptySpaceItem21.CustomizationFormText = "EmptySpaceItem21"
        Me.EmptySpaceItem21.Location = New System.Drawing.Point(0, 527)
        Me.EmptySpaceItem21.Name = "EmptySpaceItem21"
        Me.EmptySpaceItem21.Size = New System.Drawing.Size(292, 156)
        Me.EmptySpaceItem21.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem5.Control = Me.ExchangeRateDateEdit
        Me.LayoutControlItem5.CustomizationFormText = "Date from"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(475, 26)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(103, 40)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(130, 44)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Exchange Rate Date"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(99, 13)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.CustomizationFormText = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(605, 26)
        Me.EmptySpaceItem8.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(500, 44)
        Me.EmptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.CustomizationFormText = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(475, 44)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.LayoutControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'EXCHANGE_RATES_ECBTableAdapter
        '
        Me.EXCHANGE_RATES_ECBTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BIC_DIRECTORY_PLUSTableAdapter = Nothing
        Me.TableAdapterManager.BIC_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.BLZTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CURRENCIESTableAdapter = Me.CURRENCIESTableAdapter
        Me.TableAdapterManager.EXCHANGE_RATES_ECBTableAdapter = Me.EXCHANGE_RATES_ECBTableAdapter
        Me.TableAdapterManager.HOLIDAYSTableAdapter = Nothing
        Me.TableAdapterManager.PLZ_BUNDESLANDTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORY_FULLTableAdapter = Nothing
        Me.TableAdapterManager.SEPA_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.T2_DIRECTORYTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CURRENCIESTableAdapter
        '
        Me.CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'CurrencyConverterECB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 703)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CurrencyConverterECB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Currency Converter (ECB Rates)"
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyFromComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.RateSecondCurrencyComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RateSecondCurrencyTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RateFirstCurrencyTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RateFirstCurrencyComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountToConvertTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXCHANGE_RATES_ECBBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRatesECBBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerAccountsDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colClientNo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colClientAccount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDealCurrency1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccountStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOnline1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colEnglishName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colProductCode1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrencyStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCountry1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPRD_TYPE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOPEN_DATE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCLOSE_DATE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyToComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CurrencyFromComboBoxEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ConvertedAmount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ConvertedCurrency_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CrossRateCurrencies_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CrossCurrencies_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SecondCurrencyToEURrate_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SecondCurrencyToEUR_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FirstCurrencyToEURrate_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FirstCurrencyToEUR_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Convert_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RateSecondCurrencyComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RateSecondCurrencyTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RateFirstCurrencyTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RateFirstCurrencyComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents AmountToConvertTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LoadExchangeRatesOCBS_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ExchangeRateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExchangeRatesECBBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents CustomerAccountsDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientNo1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colClientNo1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientAccount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colClientAccount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colDealCurrency1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colDealCurrency1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAccountStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAccountStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOnline1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOnline1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colEnglishName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colEnglishName1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colProductCode1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colProductCode1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrencyStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrencyStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCountry1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCountry1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPRD_TYPE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPRD_TYPE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOPEN_DATE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOPEN_DATE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCLOSE_DATE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCLOSE_DATE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ExchangeRatesOCBSreport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CurrenciesConvert_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CurrencyToComboBoxEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem12 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem13 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem14 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem15 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem16 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem17 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem18 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem19 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem20 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem21 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents EXCHANGE_RATES_ECBBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EXCHANGE_RATES_ECBTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.EXCHANGE_RATES_ECBTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.EXTERNALDatasetTableAdapters.TableAdapterManager
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXCHANGERATEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CURRENCIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter
    Friend WithEvents CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents FirstCurrencyName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SecondCurrencyName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem22 As DevExpress.XtraLayout.EmptySpaceItem
End Class
