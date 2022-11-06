<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Securities_Bookings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Securities_Bookings))
        Me.SECURITIESDataset = New PS_TOOL_DX.SECURITIESDataset()
        Me.SECURITIES_BOOKINGSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SECURITIES_BOOKINGSTableAdapter = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_BOOKINGSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.SecuritiesBookingsBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBookingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBookingText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SecuritiesLiquidDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colLiquidityCreationDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLiquidityCreationDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colLiquidityDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLiquidityDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colISIN_Code1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colISIN_Code1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSecurityName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSecurityName1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCcy1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCcy1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPrincipalEuroAmt1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPrincipalEuroAmt1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colContractNrOCBS1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colContractNrOCBS1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTradeDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTradeDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStartDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStartDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMaturityDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMaturityDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSektor1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSektor1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSektorCountry1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSektorCountry1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAssetType1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAssetType1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBooked_Depreciation1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBooked_Depreciation1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colActual_Depreciation1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colActual_Depreciation1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOCBS_Booked_Before1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOCBS_Booked_Before1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOCBS_Booked_Later1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOCBS_Booked_Later1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrentInterestRate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrentInterestRate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrentInterestCouponPeriodStartDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrentInterestCouponPeriodEndDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAccruedInterestCouponOrgCcy1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAccruedInterestCouponEUREqu1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAccruedInterestCouponEUREqu1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colInterestCouponamountOrgCcy1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colInterestCouponamountOrgCcy1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colInterestCouponAmountEUREqu1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colInterestCouponAmountEUREqu1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colRIC1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRIC1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMarket_Price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMarket_Price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSwap_Price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSwap_Price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPurchase_price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPurchase_price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colindustry1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colindustry1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colFixedratecoupon1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colFixedratecoupon1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colpurchasingyield1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colpurchasingyield1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colbondtype1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colbondtype1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colwithswapornot1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colwithswapornot1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FristenViewDetails_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Securities_Bookings_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.colContractNr = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SECURITIES_BOOKINGSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecuritiesBookingsBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecuritiesLiquidDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLiquidityCreationDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLiquidityDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colISIN_Code1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSecurityName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPrincipalEuroAmt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colContractNrOCBS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTradeDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStartDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMaturityDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSektor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSektorCountry1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAssetType1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBooked_Depreciation1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colActual_Depreciation1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOCBS_Booked_Before1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOCBS_Booked_Later1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestRate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccruedInterestCouponOrgCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccruedInterestCouponEUREqu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInterestCouponamountOrgCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInterestCouponAmountEUREqu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRIC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMarket_Price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSwap_Price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPurchase_price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colindustry1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFixedratecoupon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colpurchasingyield1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colbondtype1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colwithswapornot1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SECURITIESDataset
        '
        Me.SECURITIESDataset.DataSetName = "SECURITIESDataset"
        Me.SECURITIESDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SECURITIES_BOOKINGSBindingSource
        '
        Me.SECURITIES_BOOKINGSBindingSource.DataMember = "SECURITIES_BOOKINGS"
        Me.SECURITIES_BOOKINGSBindingSource.DataSource = Me.SECURITIESDataset
        '
        'SECURITIES_BOOKINGSTableAdapter
        '
        Me.SECURITIES_BOOKINGSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.SECURITIES_BESTANDTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_BOOKINGSTableAdapter = Me.SECURITIES_BOOKINGSTableAdapter
        Me.TableAdapterManager.SECURITIES_DailyPriceTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_DEPRECIATIONSTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_LIQUIDITYRESERVETableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_OURTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.FristenViewDetails_btn)
        Me.LayoutControl1.Controls.Add(Me.Securities_Bookings_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(911, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1134, 698)
        Me.LayoutControl1.TabIndex = 7
        Me.LayoutControl1.Text = "LayoutControl1"
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
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.SECURITIES_BOOKINGSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.SecuritiesBookingsBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2})
        Me.GridControl2.Size = New System.Drawing.Size(1110, 648)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SecuritiesBookingsBaseView, Me.SecuritiesLiquidDetailView, Me.GridView2})
        '
        'SecuritiesBookingsBaseView
        '
        Me.SecuritiesBookingsBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SecuritiesBookingsBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SecuritiesBookingsBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SecuritiesBookingsBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SecuritiesBookingsBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SecuritiesBookingsBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.SecuritiesBookingsBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SecuritiesBookingsBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colBookingDate, Me.colValueDate, Me.colReference, Me.colContractNr, Me.colCcy, Me.GridColumn1, Me.GridColumn2, Me.colBookingText})
        Me.SecuritiesBookingsBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SecuritiesBookingsBaseView.GridControl = Me.GridControl2
        Me.SecuritiesBookingsBaseView.Name = "SecuritiesBookingsBaseView"
        Me.SecuritiesBookingsBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.SecuritiesBookingsBaseView.OptionsCustomization.AllowRowSizing = True
        Me.SecuritiesBookingsBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SecuritiesBookingsBaseView.OptionsFind.AlwaysVisible = True
        Me.SecuritiesBookingsBaseView.OptionsMenu.ShowFooterItem = True
        Me.SecuritiesBookingsBaseView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.SecuritiesBookingsBaseView.OptionsSelection.MultiSelect = True
        Me.SecuritiesBookingsBaseView.OptionsView.ColumnAutoWidth = False
        Me.SecuritiesBookingsBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.SecuritiesBookingsBaseView.OptionsView.ShowAutoFilterRow = True
        Me.SecuritiesBookingsBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SecuritiesBookingsBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colBookingDate
        '
        Me.colBookingDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBookingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBookingDate.FieldName = "BookingDate"
        Me.colBookingDate.Name = "colBookingDate"
        Me.colBookingDate.OptionsColumn.AllowEdit = False
        Me.colBookingDate.OptionsColumn.ReadOnly = True
        Me.colBookingDate.Visible = True
        Me.colBookingDate.VisibleIndex = 0
        Me.colBookingDate.Width = 89
        '
        'colValueDate
        '
        Me.colValueDate.AppearanceCell.Options.UseTextOptions = True
        Me.colValueDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValueDate.FieldName = "ValueDate"
        Me.colValueDate.Name = "colValueDate"
        Me.colValueDate.OptionsColumn.AllowEdit = False
        Me.colValueDate.OptionsColumn.ReadOnly = True
        Me.colValueDate.Visible = True
        Me.colValueDate.VisibleIndex = 1
        Me.colValueDate.Width = 92
        '
        'colReference
        '
        Me.colReference.Caption = "ISIN Reference"
        Me.colReference.FieldName = "Reference"
        Me.colReference.Name = "colReference"
        Me.colReference.OptionsColumn.AllowEdit = False
        Me.colReference.OptionsColumn.ReadOnly = True
        Me.colReference.Visible = True
        Me.colReference.VisibleIndex = 2
        Me.colReference.Width = 126
        '
        'colCcy
        '
        Me.colCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCcy.FieldName = "Ccy"
        Me.colCcy.Name = "colCcy"
        Me.colCcy.OptionsColumn.AllowEdit = False
        Me.colCcy.OptionsColumn.ReadOnly = True
        Me.colCcy.Visible = True
        Me.colCcy.VisibleIndex = 4
        Me.colCcy.Width = 54
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.DisplayFormat.FormatString = "n2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "Debit-Appreciation"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        Me.GridColumn1.Width = 137
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.DisplayFormat.FormatString = "n2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "Credit-Depreciation"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 6
        Me.GridColumn2.Width = 132
        '
        'colBookingText
        '
        Me.colBookingText.FieldName = "BookingText"
        Me.colBookingText.Name = "colBookingText"
        Me.colBookingText.OptionsColumn.AllowEdit = False
        Me.colBookingText.OptionsColumn.ReadOnly = True
        Me.colBookingText.Visible = True
        Me.colBookingText.VisibleIndex = 7
        Me.colBookingText.Width = 567
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
        'SecuritiesLiquidDetailView
        '
        Me.SecuritiesLiquidDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colLiquidityCreationDate1, Me.colLiquidityDate1, Me.colISIN_Code1, Me.colSecurityName1, Me.colCcy1, Me.colPrincipalEuroAmt1, Me.colContractNrOCBS1, Me.colTradeDate1, Me.colStartDate1, Me.colMaturityDate1, Me.colSektor1, Me.colSektorCountry1, Me.colAssetType1, Me.colBooked_Depreciation1, Me.colActual_Depreciation1, Me.colOCBS_Booked_Before1, Me.colOCBS_Booked_Later1, Me.colCurrentInterestRate1, Me.colCurrentInterestCouponPeriodStartDate1, Me.colCurrentInterestCouponPeriodEndDate1, Me.colAccruedInterestCouponOrgCcy1, Me.colAccruedInterestCouponEUREqu1, Me.colInterestCouponamountOrgCcy1, Me.colInterestCouponAmountEUREqu1, Me.colRIC1, Me.colMarket_Price1, Me.colSwap_Price1, Me.colPurchase_price1, Me.colindustry1, Me.colFixedratecoupon1, Me.LayoutViewColumn1, Me.colpurchasingyield1, Me.colbondtype1, Me.colwithswapornot1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4})
        Me.SecuritiesLiquidDetailView.GridControl = Me.GridControl2
        Me.SecuritiesLiquidDetailView.Name = "SecuritiesLiquidDetailView"
        Me.SecuritiesLiquidDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.SecuritiesLiquidDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.SecuritiesLiquidDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.SecuritiesLiquidDetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.SecuritiesLiquidDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.SecuritiesLiquidDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.SecuritiesLiquidDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.SecuritiesLiquidDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.SecuritiesLiquidDetailView.OptionsCustomization.AllowFilter = False
        Me.SecuritiesLiquidDetailView.OptionsCustomization.AllowSort = False
        Me.SecuritiesLiquidDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.SecuritiesLiquidDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.SecuritiesLiquidDetailView.OptionsFilter.AllowFilterEditor = False
        Me.SecuritiesLiquidDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.SecuritiesLiquidDetailView.OptionsFind.AllowFindPanel = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.SecuritiesLiquidDetailView.OptionsView.ShowHeaderPanel = False
        Me.SecuritiesLiquidDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = -14
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colLiquidityCreationDate1
        '
        Me.colLiquidityCreationDate1.FieldName = "LiquidityCreationDate"
        Me.colLiquidityCreationDate1.LayoutViewField = Me.layoutViewField_colLiquidityCreationDate1
        Me.colLiquidityCreationDate1.Name = "colLiquidityCreationDate1"
        '
        'layoutViewField_colLiquidityCreationDate1
        '
        Me.layoutViewField_colLiquidityCreationDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colLiquidityCreationDate1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colLiquidityCreationDate1.Name = "layoutViewField_colLiquidityCreationDate1"
        Me.layoutViewField_colLiquidityCreationDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colLiquidityCreationDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colLiquidityDate1
        '
        Me.colLiquidityDate1.FieldName = "LiquidityDate"
        Me.colLiquidityDate1.LayoutViewField = Me.layoutViewField_colLiquidityDate1
        Me.colLiquidityDate1.Name = "colLiquidityDate1"
        '
        'layoutViewField_colLiquidityDate1
        '
        Me.layoutViewField_colLiquidityDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colLiquidityDate1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colLiquidityDate1.Name = "layoutViewField_colLiquidityDate1"
        Me.layoutViewField_colLiquidityDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colLiquidityDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colISIN_Code1
        '
        Me.colISIN_Code1.FieldName = "ISIN_Code"
        Me.colISIN_Code1.LayoutViewField = Me.layoutViewField_colISIN_Code1
        Me.colISIN_Code1.Name = "colISIN_Code1"
        '
        'layoutViewField_colISIN_Code1
        '
        Me.layoutViewField_colISIN_Code1.EditorPreferredWidth = -14
        Me.layoutViewField_colISIN_Code1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colISIN_Code1.Name = "layoutViewField_colISIN_Code1"
        Me.layoutViewField_colISIN_Code1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colISIN_Code1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colSecurityName1
        '
        Me.colSecurityName1.FieldName = "SecurityName"
        Me.colSecurityName1.LayoutViewField = Me.layoutViewField_colSecurityName1
        Me.colSecurityName1.Name = "colSecurityName1"
        '
        'layoutViewField_colSecurityName1
        '
        Me.layoutViewField_colSecurityName1.EditorPreferredWidth = -14
        Me.layoutViewField_colSecurityName1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colSecurityName1.Name = "layoutViewField_colSecurityName1"
        Me.layoutViewField_colSecurityName1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colSecurityName1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCcy1
        '
        Me.colCcy1.FieldName = "Ccy"
        Me.colCcy1.LayoutViewField = Me.layoutViewField_colCcy1
        Me.colCcy1.Name = "colCcy1"
        '
        'layoutViewField_colCcy1
        '
        Me.layoutViewField_colCcy1.EditorPreferredWidth = -14
        Me.layoutViewField_colCcy1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colCcy1.Name = "layoutViewField_colCcy1"
        Me.layoutViewField_colCcy1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colPrincipalEuroAmt1
        '
        Me.colPrincipalEuroAmt1.FieldName = "PrincipalEuroAmt"
        Me.colPrincipalEuroAmt1.LayoutViewField = Me.layoutViewField_colPrincipalEuroAmt1
        Me.colPrincipalEuroAmt1.Name = "colPrincipalEuroAmt1"
        '
        'layoutViewField_colPrincipalEuroAmt1
        '
        Me.layoutViewField_colPrincipalEuroAmt1.EditorPreferredWidth = -14
        Me.layoutViewField_colPrincipalEuroAmt1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colPrincipalEuroAmt1.Name = "layoutViewField_colPrincipalEuroAmt1"
        Me.layoutViewField_colPrincipalEuroAmt1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colPrincipalEuroAmt1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colContractNrOCBS1
        '
        Me.colContractNrOCBS1.FieldName = "ContractNrOCBS"
        Me.colContractNrOCBS1.LayoutViewField = Me.layoutViewField_colContractNrOCBS1
        Me.colContractNrOCBS1.Name = "colContractNrOCBS1"
        '
        'layoutViewField_colContractNrOCBS1
        '
        Me.layoutViewField_colContractNrOCBS1.EditorPreferredWidth = -14
        Me.layoutViewField_colContractNrOCBS1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colContractNrOCBS1.Name = "layoutViewField_colContractNrOCBS1"
        Me.layoutViewField_colContractNrOCBS1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colContractNrOCBS1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colTradeDate1
        '
        Me.colTradeDate1.FieldName = "TradeDate"
        Me.colTradeDate1.LayoutViewField = Me.layoutViewField_colTradeDate1
        Me.colTradeDate1.Name = "colTradeDate1"
        '
        'layoutViewField_colTradeDate1
        '
        Me.layoutViewField_colTradeDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colTradeDate1.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colTradeDate1.Name = "layoutViewField_colTradeDate1"
        Me.layoutViewField_colTradeDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colTradeDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colStartDate1
        '
        Me.colStartDate1.FieldName = "StartDate"
        Me.colStartDate1.LayoutViewField = Me.layoutViewField_colStartDate1
        Me.colStartDate1.Name = "colStartDate1"
        '
        'layoutViewField_colStartDate1
        '
        Me.layoutViewField_colStartDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colStartDate1.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colStartDate1.Name = "layoutViewField_colStartDate1"
        Me.layoutViewField_colStartDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colStartDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colMaturityDate1
        '
        Me.colMaturityDate1.FieldName = "MaturityDate"
        Me.colMaturityDate1.LayoutViewField = Me.layoutViewField_colMaturityDate1
        Me.colMaturityDate1.Name = "colMaturityDate1"
        '
        'layoutViewField_colMaturityDate1
        '
        Me.layoutViewField_colMaturityDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colMaturityDate1.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colMaturityDate1.Name = "layoutViewField_colMaturityDate1"
        Me.layoutViewField_colMaturityDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colMaturityDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colSektor1
        '
        Me.colSektor1.FieldName = "Sektor"
        Me.colSektor1.LayoutViewField = Me.layoutViewField_colSektor1
        Me.colSektor1.Name = "colSektor1"
        '
        'layoutViewField_colSektor1
        '
        Me.layoutViewField_colSektor1.EditorPreferredWidth = -14
        Me.layoutViewField_colSektor1.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_colSektor1.Name = "layoutViewField_colSektor1"
        Me.layoutViewField_colSektor1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colSektor1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colSektorCountry1
        '
        Me.colSektorCountry1.FieldName = "SektorCountry"
        Me.colSektorCountry1.LayoutViewField = Me.layoutViewField_colSektorCountry1
        Me.colSektorCountry1.Name = "colSektorCountry1"
        '
        'layoutViewField_colSektorCountry1
        '
        Me.layoutViewField_colSektorCountry1.EditorPreferredWidth = -14
        Me.layoutViewField_colSektorCountry1.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_colSektorCountry1.Name = "layoutViewField_colSektorCountry1"
        Me.layoutViewField_colSektorCountry1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colSektorCountry1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colAssetType1
        '
        Me.colAssetType1.FieldName = "AssetType"
        Me.colAssetType1.LayoutViewField = Me.layoutViewField_colAssetType1
        Me.colAssetType1.Name = "colAssetType1"
        '
        'layoutViewField_colAssetType1
        '
        Me.layoutViewField_colAssetType1.EditorPreferredWidth = -14
        Me.layoutViewField_colAssetType1.Location = New System.Drawing.Point(0, 260)
        Me.layoutViewField_colAssetType1.Name = "layoutViewField_colAssetType1"
        Me.layoutViewField_colAssetType1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colAssetType1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colBooked_Depreciation1
        '
        Me.colBooked_Depreciation1.FieldName = "Booked_Depreciation"
        Me.colBooked_Depreciation1.LayoutViewField = Me.layoutViewField_colBooked_Depreciation1
        Me.colBooked_Depreciation1.Name = "colBooked_Depreciation1"
        '
        'layoutViewField_colBooked_Depreciation1
        '
        Me.layoutViewField_colBooked_Depreciation1.EditorPreferredWidth = -14
        Me.layoutViewField_colBooked_Depreciation1.Location = New System.Drawing.Point(0, 280)
        Me.layoutViewField_colBooked_Depreciation1.Name = "layoutViewField_colBooked_Depreciation1"
        Me.layoutViewField_colBooked_Depreciation1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colBooked_Depreciation1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colActual_Depreciation1
        '
        Me.colActual_Depreciation1.FieldName = "Actual_Depreciation"
        Me.colActual_Depreciation1.LayoutViewField = Me.layoutViewField_colActual_Depreciation1
        Me.colActual_Depreciation1.Name = "colActual_Depreciation1"
        '
        'layoutViewField_colActual_Depreciation1
        '
        Me.layoutViewField_colActual_Depreciation1.EditorPreferredWidth = -14
        Me.layoutViewField_colActual_Depreciation1.Location = New System.Drawing.Point(0, 300)
        Me.layoutViewField_colActual_Depreciation1.Name = "layoutViewField_colActual_Depreciation1"
        Me.layoutViewField_colActual_Depreciation1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colActual_Depreciation1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colOCBS_Booked_Before1
        '
        Me.colOCBS_Booked_Before1.FieldName = "OCBS_Booked_Before"
        Me.colOCBS_Booked_Before1.LayoutViewField = Me.layoutViewField_colOCBS_Booked_Before1
        Me.colOCBS_Booked_Before1.Name = "colOCBS_Booked_Before1"
        '
        'layoutViewField_colOCBS_Booked_Before1
        '
        Me.layoutViewField_colOCBS_Booked_Before1.EditorPreferredWidth = -14
        Me.layoutViewField_colOCBS_Booked_Before1.Location = New System.Drawing.Point(0, 320)
        Me.layoutViewField_colOCBS_Booked_Before1.Name = "layoutViewField_colOCBS_Booked_Before1"
        Me.layoutViewField_colOCBS_Booked_Before1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colOCBS_Booked_Before1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colOCBS_Booked_Later1
        '
        Me.colOCBS_Booked_Later1.FieldName = "OCBS_Booked_Later"
        Me.colOCBS_Booked_Later1.LayoutViewField = Me.layoutViewField_colOCBS_Booked_Later1
        Me.colOCBS_Booked_Later1.Name = "colOCBS_Booked_Later1"
        '
        'layoutViewField_colOCBS_Booked_Later1
        '
        Me.layoutViewField_colOCBS_Booked_Later1.EditorPreferredWidth = -14
        Me.layoutViewField_colOCBS_Booked_Later1.Location = New System.Drawing.Point(0, 340)
        Me.layoutViewField_colOCBS_Booked_Later1.Name = "layoutViewField_colOCBS_Booked_Later1"
        Me.layoutViewField_colOCBS_Booked_Later1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colOCBS_Booked_Later1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestRate1
        '
        Me.colCurrentInterestRate1.FieldName = "Current Interest Rate"
        Me.colCurrentInterestRate1.LayoutViewField = Me.layoutViewField_colCurrentInterestRate1
        Me.colCurrentInterestRate1.Name = "colCurrentInterestRate1"
        '
        'layoutViewField_colCurrentInterestRate1
        '
        Me.layoutViewField_colCurrentInterestRate1.EditorPreferredWidth = -14
        Me.layoutViewField_colCurrentInterestRate1.Location = New System.Drawing.Point(0, 360)
        Me.layoutViewField_colCurrentInterestRate1.Name = "layoutViewField_colCurrentInterestRate1"
        Me.layoutViewField_colCurrentInterestRate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colCurrentInterestRate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestCouponPeriodStartDate1
        '
        Me.colCurrentInterestCouponPeriodStartDate1.FieldName = "Current Interest Coupon Period Start Date"
        Me.colCurrentInterestCouponPeriodStartDate1.LayoutViewField = Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1
        Me.colCurrentInterestCouponPeriodStartDate1.Name = "colCurrentInterestCouponPeriodStartDate1"
        '
        'layoutViewField_colCurrentInterestCouponPeriodStartDate1
        '
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Location = New System.Drawing.Point(0, 380)
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Name = "layoutViewField_colCurrentInterestCouponPeriodStartDate1"
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestCouponPeriodEndDate1
        '
        Me.colCurrentInterestCouponPeriodEndDate1.FieldName = "Current Interest Coupon Period End Date"
        Me.colCurrentInterestCouponPeriodEndDate1.LayoutViewField = Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1
        Me.colCurrentInterestCouponPeriodEndDate1.Name = "colCurrentInterestCouponPeriodEndDate1"
        '
        'layoutViewField_colCurrentInterestCouponPeriodEndDate1
        '
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.EditorPreferredWidth = -14
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Location = New System.Drawing.Point(0, 400)
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Name = "layoutViewField_colCurrentInterestCouponPeriodEndDate1"
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colAccruedInterestCouponOrgCcy1
        '
        Me.colAccruedInterestCouponOrgCcy1.FieldName = "Accrued Interest Coupon Org Ccy"
        Me.colAccruedInterestCouponOrgCcy1.LayoutViewField = Me.layoutViewField_colAccruedInterestCouponOrgCcy1
        Me.colAccruedInterestCouponOrgCcy1.Name = "colAccruedInterestCouponOrgCcy1"
        '
        'layoutViewField_colAccruedInterestCouponOrgCcy1
        '
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.EditorPreferredWidth = -14
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Location = New System.Drawing.Point(0, 420)
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Name = "layoutViewField_colAccruedInterestCouponOrgCcy1"
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colAccruedInterestCouponEUREqu1
        '
        Me.colAccruedInterestCouponEUREqu1.FieldName = "Accrued Interest Coupon EUR Equ"
        Me.colAccruedInterestCouponEUREqu1.LayoutViewField = Me.layoutViewField_colAccruedInterestCouponEUREqu1
        Me.colAccruedInterestCouponEUREqu1.Name = "colAccruedInterestCouponEUREqu1"
        '
        'layoutViewField_colAccruedInterestCouponEUREqu1
        '
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.EditorPreferredWidth = -14
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Location = New System.Drawing.Point(0, 440)
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Name = "layoutViewField_colAccruedInterestCouponEUREqu1"
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colInterestCouponamountOrgCcy1
        '
        Me.colInterestCouponamountOrgCcy1.FieldName = "Interest Coupon amount Org Ccy"
        Me.colInterestCouponamountOrgCcy1.LayoutViewField = Me.layoutViewField_colInterestCouponamountOrgCcy1
        Me.colInterestCouponamountOrgCcy1.Name = "colInterestCouponamountOrgCcy1"
        '
        'layoutViewField_colInterestCouponamountOrgCcy1
        '
        Me.layoutViewField_colInterestCouponamountOrgCcy1.EditorPreferredWidth = -14
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Location = New System.Drawing.Point(0, 460)
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Name = "layoutViewField_colInterestCouponamountOrgCcy1"
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colInterestCouponamountOrgCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colInterestCouponAmountEUREqu1
        '
        Me.colInterestCouponAmountEUREqu1.FieldName = "Interest Coupon Amount EUR Equ"
        Me.colInterestCouponAmountEUREqu1.LayoutViewField = Me.layoutViewField_colInterestCouponAmountEUREqu1
        Me.colInterestCouponAmountEUREqu1.Name = "colInterestCouponAmountEUREqu1"
        '
        'layoutViewField_colInterestCouponAmountEUREqu1
        '
        Me.layoutViewField_colInterestCouponAmountEUREqu1.EditorPreferredWidth = -14
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Location = New System.Drawing.Point(0, 480)
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Name = "layoutViewField_colInterestCouponAmountEUREqu1"
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colInterestCouponAmountEUREqu1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colRIC1
        '
        Me.colRIC1.FieldName = "RIC"
        Me.colRIC1.LayoutViewField = Me.layoutViewField_colRIC1
        Me.colRIC1.Name = "colRIC1"
        '
        'layoutViewField_colRIC1
        '
        Me.layoutViewField_colRIC1.EditorPreferredWidth = -14
        Me.layoutViewField_colRIC1.Location = New System.Drawing.Point(0, 500)
        Me.layoutViewField_colRIC1.Name = "layoutViewField_colRIC1"
        Me.layoutViewField_colRIC1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colRIC1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colMarket_Price1
        '
        Me.colMarket_Price1.FieldName = "Market_Price"
        Me.colMarket_Price1.LayoutViewField = Me.layoutViewField_colMarket_Price1
        Me.colMarket_Price1.Name = "colMarket_Price1"
        '
        'layoutViewField_colMarket_Price1
        '
        Me.layoutViewField_colMarket_Price1.EditorPreferredWidth = -14
        Me.layoutViewField_colMarket_Price1.Location = New System.Drawing.Point(0, 520)
        Me.layoutViewField_colMarket_Price1.Name = "layoutViewField_colMarket_Price1"
        Me.layoutViewField_colMarket_Price1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colMarket_Price1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colSwap_Price1
        '
        Me.colSwap_Price1.FieldName = "Swap_Price"
        Me.colSwap_Price1.LayoutViewField = Me.layoutViewField_colSwap_Price1
        Me.colSwap_Price1.Name = "colSwap_Price1"
        '
        'layoutViewField_colSwap_Price1
        '
        Me.layoutViewField_colSwap_Price1.EditorPreferredWidth = -14
        Me.layoutViewField_colSwap_Price1.Location = New System.Drawing.Point(0, 540)
        Me.layoutViewField_colSwap_Price1.Name = "layoutViewField_colSwap_Price1"
        Me.layoutViewField_colSwap_Price1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colSwap_Price1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colPurchase_price1
        '
        Me.colPurchase_price1.FieldName = "Purchase_price"
        Me.colPurchase_price1.LayoutViewField = Me.layoutViewField_colPurchase_price1
        Me.colPurchase_price1.Name = "colPurchase_price1"
        '
        'layoutViewField_colPurchase_price1
        '
        Me.layoutViewField_colPurchase_price1.EditorPreferredWidth = -14
        Me.layoutViewField_colPurchase_price1.Location = New System.Drawing.Point(0, 560)
        Me.layoutViewField_colPurchase_price1.Name = "layoutViewField_colPurchase_price1"
        Me.layoutViewField_colPurchase_price1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colPurchase_price1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colindustry1
        '
        Me.colindustry1.FieldName = "industry"
        Me.colindustry1.LayoutViewField = Me.layoutViewField_colindustry1
        Me.colindustry1.Name = "colindustry1"
        '
        'layoutViewField_colindustry1
        '
        Me.layoutViewField_colindustry1.EditorPreferredWidth = -14
        Me.layoutViewField_colindustry1.Location = New System.Drawing.Point(0, 580)
        Me.layoutViewField_colindustry1.Name = "layoutViewField_colindustry1"
        Me.layoutViewField_colindustry1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colindustry1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colFixedratecoupon1
        '
        Me.colFixedratecoupon1.FieldName = "Fixed rate coupon"
        Me.colFixedratecoupon1.LayoutViewField = Me.layoutViewField_colFixedratecoupon1
        Me.colFixedratecoupon1.Name = "colFixedratecoupon1"
        '
        'layoutViewField_colFixedratecoupon1
        '
        Me.layoutViewField_colFixedratecoupon1.EditorPreferredWidth = -14
        Me.layoutViewField_colFixedratecoupon1.Location = New System.Drawing.Point(0, 600)
        Me.layoutViewField_colFixedratecoupon1.Name = "layoutViewField_colFixedratecoupon1"
        Me.layoutViewField_colFixedratecoupon1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colFixedratecoupon1.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.FieldName = "Floating(leg) spread "
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = -14
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 620)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colpurchasingyield1
        '
        Me.colpurchasingyield1.FieldName = "purchasing yield"
        Me.colpurchasingyield1.LayoutViewField = Me.layoutViewField_colpurchasingyield1
        Me.colpurchasingyield1.Name = "colpurchasingyield1"
        '
        'layoutViewField_colpurchasingyield1
        '
        Me.layoutViewField_colpurchasingyield1.EditorPreferredWidth = -14
        Me.layoutViewField_colpurchasingyield1.Location = New System.Drawing.Point(0, 640)
        Me.layoutViewField_colpurchasingyield1.Name = "layoutViewField_colpurchasingyield1"
        Me.layoutViewField_colpurchasingyield1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colpurchasingyield1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colbondtype1
        '
        Me.colbondtype1.FieldName = "bond type"
        Me.colbondtype1.LayoutViewField = Me.layoutViewField_colbondtype1
        Me.colbondtype1.Name = "colbondtype1"
        '
        'layoutViewField_colbondtype1
        '
        Me.layoutViewField_colbondtype1.EditorPreferredWidth = -14
        Me.layoutViewField_colbondtype1.Location = New System.Drawing.Point(0, 660)
        Me.layoutViewField_colbondtype1.Name = "layoutViewField_colbondtype1"
        Me.layoutViewField_colbondtype1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colbondtype1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colwithswapornot1
        '
        Me.colwithswapornot1.FieldName = "with swap or not"
        Me.colwithswapornot1.LayoutViewField = Me.layoutViewField_colwithswapornot1
        Me.colwithswapornot1.Name = "colwithswapornot1"
        '
        'layoutViewField_colwithswapornot1
        '
        Me.layoutViewField_colwithswapornot1.EditorPreferredWidth = -14
        Me.layoutViewField_colwithswapornot1.Location = New System.Drawing.Point(0, 680)
        Me.layoutViewField_colwithswapornot1.Name = "layoutViewField_colwithswapornot1"
        Me.layoutViewField_colwithswapornot1.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_colwithswapornot1.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.FieldName = "Moody-Rating"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_LayoutViewColumn2
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        '
        'layoutViewField_LayoutViewColumn2
        '
        Me.layoutViewField_LayoutViewColumn2.EditorPreferredWidth = -14
        Me.layoutViewField_LayoutViewColumn2.Location = New System.Drawing.Point(0, 700)
        Me.layoutViewField_LayoutViewColumn2.Name = "layoutViewField_LayoutViewColumn2"
        Me.layoutViewField_LayoutViewColumn2.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_LayoutViewColumn2.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.FieldName = "S & P"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_LayoutViewColumn3
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        '
        'layoutViewField_LayoutViewColumn3
        '
        Me.layoutViewField_LayoutViewColumn3.EditorPreferredWidth = -14
        Me.layoutViewField_LayoutViewColumn3.Location = New System.Drawing.Point(0, 720)
        Me.layoutViewField_LayoutViewColumn3.Name = "layoutViewField_LayoutViewColumn3"
        Me.layoutViewField_LayoutViewColumn3.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_LayoutViewColumn3.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.FieldName = "Fitch-Rating"
        Me.LayoutViewColumn4.LayoutViewField = Me.layoutViewField_LayoutViewColumn4
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        '
        'layoutViewField_LayoutViewColumn4
        '
        Me.layoutViewField_LayoutViewColumn4.EditorPreferredWidth = -14
        Me.layoutViewField_LayoutViewColumn4.Location = New System.Drawing.Point(0, 740)
        Me.layoutViewField_LayoutViewColumn4.Name = "layoutViewField_LayoutViewColumn4"
        Me.layoutViewField_LayoutViewColumn4.Size = New System.Drawing.Size(204, 20)
        Me.layoutViewField_LayoutViewColumn4.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1, Me.layoutViewField_colLiquidityCreationDate1, Me.layoutViewField_colLiquidityDate1, Me.layoutViewField_colISIN_Code1, Me.layoutViewField_colSecurityName1, Me.layoutViewField_colCcy1, Me.layoutViewField_colPrincipalEuroAmt1, Me.layoutViewField_colContractNrOCBS1, Me.layoutViewField_colTradeDate1, Me.layoutViewField_colStartDate1, Me.layoutViewField_colMaturityDate1, Me.layoutViewField_colSektor1, Me.layoutViewField_colSektorCountry1, Me.layoutViewField_colAssetType1, Me.layoutViewField_colBooked_Depreciation1, Me.layoutViewField_colActual_Depreciation1, Me.layoutViewField_colOCBS_Booked_Before1, Me.layoutViewField_colOCBS_Booked_Later1, Me.layoutViewField_colCurrentInterestRate1, Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, Me.layoutViewField_colAccruedInterestCouponOrgCcy1, Me.layoutViewField_colAccruedInterestCouponEUREqu1, Me.layoutViewField_colInterestCouponamountOrgCcy1, Me.layoutViewField_colInterestCouponAmountEUREqu1, Me.layoutViewField_colRIC1, Me.layoutViewField_colMarket_Price1, Me.layoutViewField_colSwap_Price1, Me.layoutViewField_colPurchase_price1, Me.layoutViewField_colindustry1, Me.layoutViewField_colFixedratecoupon1, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_colpurchasingyield1, Me.layoutViewField_colbondtype1, Me.layoutViewField_colwithswapornot1, Me.layoutViewField_LayoutViewColumn2, Me.layoutViewField_LayoutViewColumn3, Me.layoutViewField_LayoutViewColumn4})
        Me.LayoutViewCard1.Name = "layoutViewTemplateCard"
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
        'FristenViewDetails_btn
        '
        Me.FristenViewDetails_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FristenViewDetails_btn.ImageOptions.ImageIndex = 0
        Me.FristenViewDetails_btn.Location = New System.Drawing.Point(978, 12)
        Me.FristenViewDetails_btn.Name = "FristenViewDetails_btn"
        Me.FristenViewDetails_btn.Size = New System.Drawing.Size(144, 22)
        Me.FristenViewDetails_btn.StyleController = Me.LayoutControl1
        Me.FristenViewDetails_btn.TabIndex = 7
        Me.FristenViewDetails_btn.Text = "View Details"
        '
        'Securities_Bookings_Print_Export_btn
        '
        Me.Securities_Bookings_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Securities_Bookings_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Securities_Bookings_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Securities_Bookings_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Securities_Bookings_Print_Export_btn.Name = "Securities_Bookings_Print_Export_btn"
        Me.Securities_Bookings_Print_Export_btn.Size = New System.Drawing.Size(112, 22)
        Me.Securities_Bookings_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Securities_Bookings_Print_Export_btn.TabIndex = 9
        Me.Securities_Bookings_Print_Export_btn.Text = "Print or Export"
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
        Me.ImageCollection1.Images.SetKeyName(7, "New.ico")
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1134, 698)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(116, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(849, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Securities_Bookings_Print_Export_btn
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
        Me.LayoutControlItem3.Control = Me.FristenViewDetails_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(966, 0)
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
        Me.SimpleSeparator1.Location = New System.Drawing.Point(965, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1114, 652)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
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
        'colContractNr
        '
        Me.colContractNr.FieldName = "ContractNr"
        Me.colContractNr.Name = "colContractNr"
        Me.colContractNr.OptionsColumn.AllowEdit = False
        Me.colContractNr.OptionsColumn.ReadOnly = True
        Me.colContractNr.Visible = True
        Me.colContractNr.VisibleIndex = 3
        Me.colContractNr.Width = 120
        '
        'Securities_Bookings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 698)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("Securities_Bookings.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Securities_Bookings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Securities - Bookings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SECURITIES_BOOKINGSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecuritiesBookingsBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecuritiesLiquidDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLiquidityCreationDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLiquidityDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colISIN_Code1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSecurityName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPrincipalEuroAmt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colContractNrOCBS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTradeDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStartDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMaturityDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSektor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSektorCountry1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAssetType1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBooked_Depreciation1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colActual_Depreciation1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOCBS_Booked_Before1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOCBS_Booked_Later1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestRate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccruedInterestCouponOrgCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccruedInterestCouponEUREqu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInterestCouponamountOrgCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInterestCouponAmountEUREqu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRIC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMarket_Price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSwap_Price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPurchase_price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colindustry1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFixedratecoupon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colpurchasingyield1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colbondtype1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colwithswapornot1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SECURITIESDataset As PS_TOOL_DX.SECURITIESDataset
    Friend WithEvents SECURITIES_BOOKINGSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SECURITIES_BOOKINGSTableAdapter As PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_BOOKINGSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SecuritiesBookingsBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBookingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBookingText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents SecuritiesLiquidDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colLiquidityCreationDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLiquidityCreationDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colLiquidityDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLiquidityDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colISIN_Code1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colISIN_Code1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSecurityName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSecurityName1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPrincipalEuroAmt1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPrincipalEuroAmt1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colContractNrOCBS1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colContractNrOCBS1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colTradeDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colTradeDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colStartDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colStartDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMaturityDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMaturityDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSektor1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSektor1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSektorCountry1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSektorCountry1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAssetType1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAssetType1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colBooked_Depreciation1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBooked_Depreciation1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colActual_Depreciation1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colActual_Depreciation1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOCBS_Booked_Before1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOCBS_Booked_Before1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOCBS_Booked_Later1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOCBS_Booked_Later1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrentInterestRate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrentInterestRate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrentInterestCouponPeriodStartDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrentInterestCouponPeriodStartDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrentInterestCouponPeriodEndDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrentInterestCouponPeriodEndDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAccruedInterestCouponOrgCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAccruedInterestCouponOrgCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAccruedInterestCouponEUREqu1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAccruedInterestCouponEUREqu1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colInterestCouponamountOrgCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colInterestCouponamountOrgCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colInterestCouponAmountEUREqu1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colInterestCouponAmountEUREqu1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRIC1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRIC1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMarket_Price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMarket_Price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSwap_Price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSwap_Price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPurchase_price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPurchase_price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colindustry1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colindustry1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colFixedratecoupon1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colFixedratecoupon1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colpurchasingyield1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colpurchasingyield1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colbondtype1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colbondtype1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colwithswapornot1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colwithswapornot1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FristenViewDetails_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Securities_Bookings_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colContractNr As DevExpress.XtraGrid.Columns.GridColumn
End Class
