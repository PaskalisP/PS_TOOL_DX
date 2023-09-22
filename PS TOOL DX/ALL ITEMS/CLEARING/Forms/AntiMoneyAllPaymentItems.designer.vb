<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AntiMoneyAllPaymentItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AntiMoneyAllPaymentItems))
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Payments_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOur_Client_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOurClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOur_Client_Account_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymentFlow = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymentReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSendersReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOriginalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingCustomerAccountNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingCustomerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingBankBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingBankCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderingBankCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesAccountNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesBankBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesBankCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBeneficiariesBankCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.InOut_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.DateFrom_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.DateFrom_DateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateTill_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.DateTill_DateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.bbi_Load = New DevExpress.XtraBars.BarButtonItem()
        Me.bbi_PrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.bbi_Close = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Payments_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InOut_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom_DateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom_DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTill_DateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTill_DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl4
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl4
        '
        Me.GridControl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl4.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Neues Inventar einfügen", "AddNewInventar")})
        Me.GridControl4.Location = New System.Drawing.Point(24, 65)
        Me.GridControl4.MainView = Me.Payments_Details_GridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox4, Me.RepositoryItemTextEdit7, Me.RepositoryItemTextEdit8, Me.RepositoryItemTextEdit9, Me.RepositoryItemMemoExEdit4, Me.InOut_ImageComboBox})
        Me.GridControl4.Size = New System.Drawing.Size(1333, 556)
        Me.GridControl4.TabIndex = 129
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Payments_Details_GridView})
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
        Me.ImageCollection1.Images.SetKeyName(8, "Calculator.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("exporttoxlsx_16x16.png", "images/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxlsx_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "exporttoxlsx_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(14, "group2_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(15, "listbullets_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(16, "moveup_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "movedown_16x16.png")
        '
        'Payments_Details_GridView
        '
        Me.Payments_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Payments_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Payments_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Payments_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Payments_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Payments_Details_GridView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Aqua
        Me.Payments_Details_GridView.Appearance.GroupFooter.Options.UseForeColor = True
        Me.Payments_Details_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Payments_Details_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Payments_Details_GridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Payments_Details_GridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Payments_Details_GridView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.Payments_Details_GridView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.Payments_Details_GridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Payments_Details_GridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.Payments_Details_GridView.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.Payments_Details_GridView.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.Payments_Details_GridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Payments_Details_GridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.Payments_Details_GridView.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.Payments_Details_GridView.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.Payments_Details_GridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.Payments_Details_GridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.Payments_Details_GridView.AppearancePrint.Row.Options.UseBackColor = True
        Me.Payments_Details_GridView.AppearancePrint.Row.Options.UseForeColor = True
        Me.Payments_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOur_Client_Nr, Me.colOurClientName, Me.colOur_Client_Account_Nr, Me.colPaymentFlow, Me.colPaymentReference, Me.colSendersReference, Me.colValueDate, Me.colCurrency, Me.colOriginalAmount, Me.colAmountEUR, Me.colOrderingCustomerAccountNr, Me.colOrderingCustomerName, Me.colOrderingBankBIC, Me.colOrderingBankName, Me.colOrderingBankCity, Me.colOrderingBankCountry, Me.colBeneficiariesAccountNr, Me.colBeneficiariesName, Me.colBeneficiariesBankBIC, Me.colBeneficiariesBankName, Me.colBeneficiariesBankCity, Me.colBeneficiariesBankCountry})
        Me.Payments_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Payments_Details_GridView.GridControl = Me.GridControl4
        Me.Payments_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEUR", Nothing, "Sum TOTAL={0:n2}", ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "PaymentReference", Nothing, "Payments Count={0:n0}", ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEUR", Me.colAmountEUR, "Sum={0:n2}", ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "PaymentReference", Me.colPaymentReference, "Count={0:n0}", "")})
        Me.Payments_Details_GridView.Name = "Payments_Details_GridView"
        Me.Payments_Details_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Payments_Details_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Payments_Details_GridView.OptionsBehavior.ReadOnly = True
        Me.Payments_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.Payments_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Payments_Details_GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.Payments_Details_GridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Payments_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Payments_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.Payments_Details_GridView.OptionsFind.SearchInPreview = True
        Me.Payments_Details_GridView.OptionsLayout.StoreAllOptions = True
        Me.Payments_Details_GridView.OptionsLayout.StoreAppearance = True
        Me.Payments_Details_GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.Payments_Details_GridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Payments_Details_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Payments_Details_GridView.OptionsSelection.MultiSelect = True
        Me.Payments_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.Payments_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Payments_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.Payments_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Payments_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.Payments_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Payments_Details_GridView.OptionsView.ShowFooter = True
        Me.Payments_Details_GridView.OptionsView.ShowGroupedColumns = True
        Me.Payments_Details_GridView.OptionsView.ShowGroupPanel = False
        Me.Payments_Details_GridView.PaintStyleName = "Skin"
        '
        'colOur_Client_Nr
        '
        Me.colOur_Client_Nr.Caption = "Client Nr."
        Me.colOur_Client_Nr.FieldName = "ClientNr"
        Me.colOur_Client_Nr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colOur_Client_Nr.Name = "colOur_Client_Nr"
        Me.colOur_Client_Nr.Visible = True
        Me.colOur_Client_Nr.VisibleIndex = 0
        Me.colOur_Client_Nr.Width = 153
        '
        'colOurClientName
        '
        Me.colOurClientName.Caption = "Client Name"
        Me.colOurClientName.FieldName = "ClientName"
        Me.colOurClientName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colOurClientName.Name = "colOurClientName"
        Me.colOurClientName.Visible = True
        Me.colOurClientName.VisibleIndex = 1
        Me.colOurClientName.Width = 280
        '
        'colOur_Client_Account_Nr
        '
        Me.colOur_Client_Account_Nr.Caption = "Client Account Nr."
        Me.colOur_Client_Account_Nr.FieldName = "ClientAccountNr"
        Me.colOur_Client_Account_Nr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colOur_Client_Account_Nr.Name = "colOur_Client_Account_Nr"
        Me.colOur_Client_Account_Nr.Visible = True
        Me.colOur_Client_Account_Nr.VisibleIndex = 2
        Me.colOur_Client_Account_Nr.Width = 126
        '
        'colPaymentFlow
        '
        Me.colPaymentFlow.Caption = "Payment Flow"
        Me.colPaymentFlow.ColumnEdit = Me.InOut_ImageComboBox
        Me.colPaymentFlow.FieldName = "PaymentFlow"
        Me.colPaymentFlow.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colPaymentFlow.Name = "colPaymentFlow"
        Me.colPaymentFlow.Visible = True
        Me.colPaymentFlow.VisibleIndex = 3
        Me.colPaymentFlow.Width = 101
        '
        'colPaymentReference
        '
        Me.colPaymentReference.Caption = "Payment Reference"
        Me.colPaymentReference.FieldName = "PaymentReference"
        Me.colPaymentReference.Name = "colPaymentReference"
        Me.colPaymentReference.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Payment Reference", "Count={0:n0}")})
        Me.colPaymentReference.Visible = True
        Me.colPaymentReference.VisibleIndex = 4
        Me.colPaymentReference.Width = 144
        '
        'colSendersReference
        '
        Me.colSendersReference.Caption = "Senders Reference"
        Me.colSendersReference.FieldName = "SendersReference"
        Me.colSendersReference.Name = "colSendersReference"
        Me.colSendersReference.Visible = True
        Me.colSendersReference.VisibleIndex = 5
        Me.colSendersReference.Width = 146
        '
        'colValueDate
        '
        Me.colValueDate.AppearanceCell.Options.UseTextOptions = True
        Me.colValueDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValueDate.Caption = "Value Date"
        Me.colValueDate.DisplayFormat.FormatString = "d"
        Me.colValueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colValueDate.FieldName = "ValueDate"
        Me.colValueDate.Name = "colValueDate"
        Me.colValueDate.Visible = True
        Me.colValueDate.VisibleIndex = 6
        Me.colValueDate.Width = 115
        '
        'colCurrency
        '
        Me.colCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrency.Caption = "Currency"
        Me.colCurrency.FieldName = "Currency"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.Visible = True
        Me.colCurrency.VisibleIndex = 7
        Me.colCurrency.Width = 82
        '
        'colOriginalAmount
        '
        Me.colOriginalAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colOriginalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOriginalAmount.Caption = "Original Amount"
        Me.colOriginalAmount.DisplayFormat.FormatString = "n2"
        Me.colOriginalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOriginalAmount.FieldName = "OriginalAmount"
        Me.colOriginalAmount.Name = "colOriginalAmount"
        Me.colOriginalAmount.Visible = True
        Me.colOriginalAmount.VisibleIndex = 8
        Me.colOriginalAmount.Width = 166
        '
        'colAmountEUR
        '
        Me.colAmountEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountEUR.Caption = "Amount in EUR"
        Me.colAmountEUR.DisplayFormat.FormatString = "n2"
        Me.colAmountEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountEUR.FieldName = "AmountEUR"
        Me.colAmountEUR.Name = "colAmountEUR"
        Me.colAmountEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount in EUR", "Sum={0:n2}")})
        Me.colAmountEUR.Visible = True
        Me.colAmountEUR.VisibleIndex = 9
        Me.colAmountEUR.Width = 186
        '
        'colOrderingCustomerAccountNr
        '
        Me.colOrderingCustomerAccountNr.Caption = "Ordering Customer AccountNr."
        Me.colOrderingCustomerAccountNr.FieldName = "OrderingCustomerAccountNr"
        Me.colOrderingCustomerAccountNr.Name = "colOrderingCustomerAccountNr"
        Me.colOrderingCustomerAccountNr.Visible = True
        Me.colOrderingCustomerAccountNr.VisibleIndex = 10
        Me.colOrderingCustomerAccountNr.Width = 182
        '
        'colOrderingCustomerName
        '
        Me.colOrderingCustomerName.Caption = "Ordering Customer Name"
        Me.colOrderingCustomerName.FieldName = "OrderingCustomerName"
        Me.colOrderingCustomerName.Name = "colOrderingCustomerName"
        Me.colOrderingCustomerName.Visible = True
        Me.colOrderingCustomerName.VisibleIndex = 11
        Me.colOrderingCustomerName.Width = 252
        '
        'colOrderingBankBIC
        '
        Me.colOrderingBankBIC.Caption = "Ordering Bank BIC"
        Me.colOrderingBankBIC.FieldName = "OrderingBankBIC"
        Me.colOrderingBankBIC.Name = "colOrderingBankBIC"
        Me.colOrderingBankBIC.Visible = True
        Me.colOrderingBankBIC.VisibleIndex = 12
        Me.colOrderingBankBIC.Width = 105
        '
        'colOrderingBankName
        '
        Me.colOrderingBankName.Caption = "Ordering Bank Name"
        Me.colOrderingBankName.FieldName = "OrderingBankName"
        Me.colOrderingBankName.Name = "colOrderingBankName"
        Me.colOrderingBankName.Visible = True
        Me.colOrderingBankName.VisibleIndex = 13
        Me.colOrderingBankName.Width = 293
        '
        'colOrderingBankCity
        '
        Me.colOrderingBankCity.Caption = "Ordering Bank City"
        Me.colOrderingBankCity.FieldName = "OrderingBankCity"
        Me.colOrderingBankCity.Name = "colOrderingBankCity"
        Me.colOrderingBankCity.Visible = True
        Me.colOrderingBankCity.VisibleIndex = 14
        Me.colOrderingBankCity.Width = 123
        '
        'colOrderingBankCountry
        '
        Me.colOrderingBankCountry.AppearanceCell.Options.UseTextOptions = True
        Me.colOrderingBankCountry.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrderingBankCountry.Caption = "Ordering Bank Country"
        Me.colOrderingBankCountry.FieldName = "OrderingBankCountry"
        Me.colOrderingBankCountry.Name = "colOrderingBankCountry"
        Me.colOrderingBankCountry.Visible = True
        Me.colOrderingBankCountry.VisibleIndex = 15
        Me.colOrderingBankCountry.Width = 136
        '
        'colBeneficiariesAccountNr
        '
        Me.colBeneficiariesAccountNr.Caption = "Beneficiaries Account Nr."
        Me.colBeneficiariesAccountNr.FieldName = "BeneficiariesAccountNr"
        Me.colBeneficiariesAccountNr.Name = "colBeneficiariesAccountNr"
        Me.colBeneficiariesAccountNr.Visible = True
        Me.colBeneficiariesAccountNr.VisibleIndex = 16
        Me.colBeneficiariesAccountNr.Width = 189
        '
        'colBeneficiariesName
        '
        Me.colBeneficiariesName.Caption = "Beneficiaries Name"
        Me.colBeneficiariesName.FieldName = "BeneficiariesName"
        Me.colBeneficiariesName.Name = "colBeneficiariesName"
        Me.colBeneficiariesName.Visible = True
        Me.colBeneficiariesName.VisibleIndex = 17
        Me.colBeneficiariesName.Width = 389
        '
        'colBeneficiariesBankBIC
        '
        Me.colBeneficiariesBankBIC.Caption = "Beneficiaries Bank BIC"
        Me.colBeneficiariesBankBIC.FieldName = "BeneficiariesBankBIC"
        Me.colBeneficiariesBankBIC.Name = "colBeneficiariesBankBIC"
        Me.colBeneficiariesBankBIC.Visible = True
        Me.colBeneficiariesBankBIC.VisibleIndex = 18
        Me.colBeneficiariesBankBIC.Width = 124
        '
        'colBeneficiariesBankName
        '
        Me.colBeneficiariesBankName.Caption = "Beneficiaries Bank Name"
        Me.colBeneficiariesBankName.FieldName = "BeneficiariesBankName"
        Me.colBeneficiariesBankName.Name = "colBeneficiariesBankName"
        Me.colBeneficiariesBankName.Visible = True
        Me.colBeneficiariesBankName.VisibleIndex = 19
        Me.colBeneficiariesBankName.Width = 284
        '
        'colBeneficiariesBankCity
        '
        Me.colBeneficiariesBankCity.Caption = "Beneficiaries Bank City"
        Me.colBeneficiariesBankCity.FieldName = "BeneficiariesBankCity"
        Me.colBeneficiariesBankCity.Name = "colBeneficiariesBankCity"
        Me.colBeneficiariesBankCity.Visible = True
        Me.colBeneficiariesBankCity.VisibleIndex = 20
        Me.colBeneficiariesBankCity.Width = 158
        '
        'colBeneficiariesBankCountry
        '
        Me.colBeneficiariesBankCountry.AppearanceCell.Options.UseTextOptions = True
        Me.colBeneficiariesBankCountry.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBeneficiariesBankCountry.Caption = "Beneficiaries Bank Country"
        Me.colBeneficiariesBankCountry.FieldName = "BeneficiariesBankCountry"
        Me.colBeneficiariesBankCountry.Name = "colBeneficiariesBankCountry"
        Me.colBeneficiariesBankCountry.Visible = True
        Me.colBeneficiariesBankCountry.VisibleIndex = 21
        Me.colBeneficiariesBankCountry.Width = 129
        '
        'RepositoryItemComboBox4
        '
        Me.RepositoryItemComboBox4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemComboBox4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemComboBox4.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox4.AppearanceDropDown.Options.UseBackColor = True
        Me.RepositoryItemComboBox4.AppearanceDropDown.Options.UseForeColor = True
        Me.RepositoryItemComboBox4.AutoHeight = False
        Me.RepositoryItemComboBox4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox4.DropDownRows = 2
        Me.RepositoryItemComboBox4.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox4.ImmediatePopup = True
        Me.RepositoryItemComboBox4.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox4.Name = "RepositoryItemComboBox4"
        Me.RepositoryItemComboBox4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit7
        '
        Me.RepositoryItemTextEdit7.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit7.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit7.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit7.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit7.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit7.AutoHeight = False
        Me.RepositoryItemTextEdit7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit7.Name = "RepositoryItemTextEdit7"
        '
        'RepositoryItemTextEdit8
        '
        Me.RepositoryItemTextEdit8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit8.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit8.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit8.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit8.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit8.AutoHeight = False
        Me.RepositoryItemTextEdit8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit8.Mask.BeepOnError = True
        Me.RepositoryItemTextEdit8.Mask.EditMask = "[A-Z]{6}[1-9A-Z]{2}"
        Me.RepositoryItemTextEdit8.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit8.Name = "RepositoryItemTextEdit8"
        '
        'RepositoryItemTextEdit9
        '
        Me.RepositoryItemTextEdit9.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit9.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit9.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit9.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit9.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit9.AutoHeight = False
        Me.RepositoryItemTextEdit9.Mask.EditMask = "[1-9A-Z]{3}"
        Me.RepositoryItemTextEdit9.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit9.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit9.Name = "RepositoryItemTextEdit9"
        '
        'RepositoryItemMemoExEdit4
        '
        Me.RepositoryItemMemoExEdit4.AllowFocused = False
        Me.RepositoryItemMemoExEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit4.AutoHeight = False
        Me.RepositoryItemMemoExEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit4.Name = "RepositoryItemMemoExEdit4"
        Me.RepositoryItemMemoExEdit4.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit4.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RepositoryItemMemoExEdit4.ShowIcon = False
        '
        'InOut_ImageComboBox
        '
        Me.InOut_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.InOut_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.InOut_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.InOut_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.InOut_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.InOut_ImageComboBox.AutoHeight = False
        Me.InOut_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InOut_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INCOMING", "INCOMING", 17), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("OUTGOING", "OUTGOING", 16)})
        Me.InOut_ImageComboBox.Name = "InOut_ImageComboBox"
        Me.InOut_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl1.Controls.Add(Me.GridControl4)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 778, 547)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1381, 645)
        Me.LayoutControl1.TabIndex = 117
        Me.LayoutControl1.Text = "LayoutControl1"
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
        Me.ProgressPanel1.Location = New System.Drawing.Point(24, 45)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(116, 16)
        Me.ProgressPanel1.StyleController = Me.LayoutControl1
        Me.ProgressPanel1.TabIndex = 120
        Me.ProgressPanel1.Text = "ProgressPanel1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1381, 645)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.ForeColor = System.Drawing.Color.Aqua
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseForeColor = True
        Me.LayoutControlGroup2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Aqua
        Me.LayoutControlGroup2.AppearanceItemCaption.Options.UseForeColor = True
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup2.CustomizationFormText = "Customers Payments"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1361, 625)
        Me.LayoutControlGroup2.Text = "Customers Payments"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl4
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 20)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1337, 560)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ProgressPanel1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1337, 20)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'ToolTipController1
        '
        Me.ToolTipController1.ImageIndex = 7
        Me.ToolTipController1.ImageList = Me.ImageCollection1
        Me.ToolTipController1.Rounded = True
        Me.ToolTipController1.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Images = Me.ImageCollection1
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.DateFrom_BarEditItem, Me.DateTill_BarEditItem, Me.bbi_Load, Me.bbi_PrintExport, Me.bbi_Close})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 8
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DateFrom_DateEdit, Me.DateTill_DateEdit})
        Me.RibbonControl1.ShowSearchItem = True
        Me.RibbonControl1.Size = New System.Drawing.Size(1381, 94)
        '
        'DateFrom_BarEditItem
        '
        Me.DateFrom_BarEditItem.Caption = "Date from:"
        Me.DateFrom_BarEditItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateFrom_BarEditItem.CaptionToEditorIndent = 10
        Me.DateFrom_BarEditItem.Edit = Me.DateFrom_DateEdit
        Me.DateFrom_BarEditItem.EditHeight = 30
        Me.DateFrom_BarEditItem.EditWidth = 120
        Me.DateFrom_BarEditItem.Id = 1
        Me.DateFrom_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateFrom_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.DateFrom_BarEditItem.Name = "DateFrom_BarEditItem"
        '
        'DateFrom_DateEdit
        '
        Me.DateFrom_DateEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateFrom_DateEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateFrom_DateEdit.Appearance.Options.UseFont = True
        Me.DateFrom_DateEdit.Appearance.Options.UseTextOptions = True
        Me.DateFrom_DateEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateFrom_DateEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateFrom_DateEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateFrom_DateEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateFrom_DateEdit.AppearanceFocused.Options.UseBackColor = True
        Me.DateFrom_DateEdit.AppearanceFocused.Options.UseForeColor = True
        Me.DateFrom_DateEdit.AutoHeight = False
        Me.DateFrom_DateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom_DateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom_DateEdit.Name = "DateFrom_DateEdit"
        '
        'DateTill_BarEditItem
        '
        Me.DateTill_BarEditItem.Caption = "Date till:"
        Me.DateTill_BarEditItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateTill_BarEditItem.CaptionToEditorIndent = 10
        Me.DateTill_BarEditItem.Edit = Me.DateTill_DateEdit
        Me.DateTill_BarEditItem.EditHeight = 40
        Me.DateTill_BarEditItem.EditWidth = 120
        Me.DateTill_BarEditItem.Id = 2
        Me.DateTill_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTill_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.DateTill_BarEditItem.Name = "DateTill_BarEditItem"
        '
        'DateTill_DateEdit
        '
        Me.DateTill_DateEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateTill_DateEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTill_DateEdit.Appearance.Options.UseFont = True
        Me.DateTill_DateEdit.Appearance.Options.UseTextOptions = True
        Me.DateTill_DateEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateTill_DateEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateTill_DateEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateTill_DateEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateTill_DateEdit.AppearanceFocused.Options.UseBackColor = True
        Me.DateTill_DateEdit.AppearanceFocused.Options.UseForeColor = True
        Me.DateTill_DateEdit.AutoHeight = False
        Me.DateTill_DateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTill_DateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTill_DateEdit.Name = "DateTill_DateEdit"
        '
        'bbi_Load
        '
        Me.bbi_Load.Caption = "Load Payments"
        Me.bbi_Load.Id = 3
        Me.bbi_Load.ImageOptions.Image = CType(resources.GetObject("bbi_Load.ImageOptions.Image"), System.Drawing.Image)
        Me.bbi_Load.ImageOptions.LargeImage = CType(resources.GetObject("bbi_Load.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbi_Load.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bbi_Load.ItemAppearance.Normal.Options.UseFont = True
        Me.bbi_Load.Name = "bbi_Load"
        '
        'bbi_PrintExport
        '
        Me.bbi_PrintExport.Caption = "Print or Export"
        Me.bbi_PrintExport.Id = 6
        Me.bbi_PrintExport.ImageOptions.ImageIndex = 2
        Me.bbi_PrintExport.Name = "bbi_PrintExport"
        '
        'bbi_Close
        '
        Me.bbi_Close.Caption = "Close"
        Me.bbi_Close.Id = 7
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.DateFrom_BarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.DateTill_BarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_Load)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_PrintExport, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbi_Close, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'AntiMoneyAllPaymentItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1381, 739)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("AntiMoneyAllPaymentItems.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "AntiMoneyAllPaymentItems"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CUSTOMER PAYMENTS - (INCOMING/OUTGOING)"
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Payments_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InOut_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom_DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom_DateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTill_DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTill_DateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Payments_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents InOut_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colPaymentFlow As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOur_Client_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOur_Client_Account_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOurClientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymentReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOriginalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderingBankBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderingBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderingBankCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderingCustomerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesBankBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesBankCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesAccountNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colSendersReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents DateFrom_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents DateFrom_DateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DateTill_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents DateTill_DateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents bbi_Load As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbi_PrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbi_Close As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colOrderingCustomerAccountNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderingBankCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeneficiariesBankCountry As DevExpress.XtraGrid.Columns.GridColumn
End Class
