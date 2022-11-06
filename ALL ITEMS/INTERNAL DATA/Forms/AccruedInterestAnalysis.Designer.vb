<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccruedInterestAnalysis
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccruedInterestAnalysis))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.AccruedInterestAnalysisDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClass1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colClass1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colContractType1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colContractType1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colProductType1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colProductType1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colContract1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colContract1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCounterpartyName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCounterpartyName1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCounterpartyNo1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCounterpartyNo1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTradeDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTradeDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStartDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStartDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colFinalMaturityDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colFinalMaturityDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOrgCcy1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOrgCcy1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
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
        Me.colDatadate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colDatadate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ACCRUED_INTEREST_ANALYSISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.AccruedInterestAnalysisBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContract = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCounterpartyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCounterpartyNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTradeDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFinalMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrentInterestRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrentInterestCouponPeriodStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrentInterestCouponPeriodEndDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccruedInterestCouponOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccruedInterestCouponEUREqu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInterestCouponamountOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInterestCouponAmountEUREqu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDatadate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.item1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item12 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item13 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item14 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item15 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item16 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item17 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item18 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item19 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item20 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item21 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ACCRUED_INTEREST_ANALYSISTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.ACCRUED_INTEREST_ANALYSISTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Load_AccruedInterestAnalysis_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AccruedInterestAnalysisViewDetails_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.AccruedInterestAnalysis_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.AccruedInterestAnalysisDateEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.AccruedInterestAnalysisDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colClass1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colContractType1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colProductType1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colContract1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCounterpartyName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCounterpartyNo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTradeDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStartDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFinalMaturityDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOrgCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestRate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccruedInterestCouponOrgCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccruedInterestCouponEUREqu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInterestCouponamountOrgCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInterestCouponAmountEUREqu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDatadate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACCRUED_INTEREST_ANALYSISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccruedInterestAnalysisBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccruedInterestAnalysisDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccruedInterestAnalysisDetailView
        '
        Me.AccruedInterestAnalysisDetailView.Appearance.FieldValue.ForeColor = System.Drawing.Color.Aqua
        Me.AccruedInterestAnalysisDetailView.Appearance.FieldValue.Options.UseForeColor = True
        Me.AccruedInterestAnalysisDetailView.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Navy
        Me.AccruedInterestAnalysisDetailView.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.AccruedInterestAnalysisDetailView.CardMinSize = New System.Drawing.Size(847, 595)
        Me.AccruedInterestAnalysisDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colClass1, Me.colContractType1, Me.colProductType1, Me.LayoutViewColumn1, Me.colContract1, Me.colCounterpartyName1, Me.colCounterpartyNo1, Me.colTradeDate1, Me.colStartDate1, Me.colFinalMaturityDate1, Me.colOrgCcy1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.colCurrentInterestRate1, Me.colCurrentInterestCouponPeriodStartDate1, Me.colCurrentInterestCouponPeriodEndDate1, Me.colAccruedInterestCouponOrgCcy1, Me.colAccruedInterestCouponEUREqu1, Me.colInterestCouponamountOrgCcy1, Me.colInterestCouponAmountEUREqu1, Me.colDatadate1})
        Me.AccruedInterestAnalysisDetailView.GridControl = Me.GridControl2
        Me.AccruedInterestAnalysisDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1, Me.layoutViewField_colDatadate1})
        Me.AccruedInterestAnalysisDetailView.Name = "AccruedInterestAnalysisDetailView"
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.AccruedInterestAnalysisDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.AccruedInterestAnalysisDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.AccruedInterestAnalysisDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.AccruedInterestAnalysisDetailView.OptionsCustomization.AllowFilter = False
        Me.AccruedInterestAnalysisDetailView.OptionsCustomization.AllowSort = False
        Me.AccruedInterestAnalysisDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.AccruedInterestAnalysisDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.AccruedInterestAnalysisDetailView.OptionsFilter.AllowFilterEditor = False
        Me.AccruedInterestAnalysisDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.AccruedInterestAnalysisDetailView.OptionsFind.AllowFindPanel = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.AccruedInterestAnalysisDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.AccruedInterestAnalysisDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.AccruedInterestAnalysisDetailView.OptionsView.ShowHeaderPanel = False
        Me.AccruedInterestAnalysisDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.AppearanceCell.Options.UseTextOptions = True
        Me.colID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = -14
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(204, 440)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colClass1
        '
        Me.colClass1.AppearanceCell.Options.UseTextOptions = True
        Me.colClass1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colClass1.FieldName = "Class"
        Me.colClass1.LayoutViewField = Me.layoutViewField_colClass1
        Me.colClass1.Name = "colClass1"
        Me.colClass1.OptionsColumn.AllowEdit = False
        Me.colClass1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colClass1
        '
        Me.layoutViewField_colClass1.EditorPreferredWidth = 121
        Me.layoutViewField_colClass1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colClass1.Name = "layoutViewField_colClass1"
        Me.layoutViewField_colClass1.Size = New System.Drawing.Size(339, 20)
        Me.layoutViewField_colClass1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colContractType1
        '
        Me.colContractType1.AppearanceCell.Options.UseTextOptions = True
        Me.colContractType1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colContractType1.FieldName = "Contract Type"
        Me.colContractType1.LayoutViewField = Me.layoutViewField_colContractType1
        Me.colContractType1.Name = "colContractType1"
        Me.colContractType1.OptionsColumn.AllowEdit = False
        Me.colContractType1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colContractType1
        '
        Me.layoutViewField_colContractType1.EditorPreferredWidth = 121
        Me.layoutViewField_colContractType1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colContractType1.Name = "layoutViewField_colContractType1"
        Me.layoutViewField_colContractType1.Size = New System.Drawing.Size(339, 20)
        Me.layoutViewField_colContractType1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colProductType1
        '
        Me.colProductType1.AppearanceCell.Options.UseTextOptions = True
        Me.colProductType1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colProductType1.FieldName = "Product Type"
        Me.colProductType1.LayoutViewField = Me.layoutViewField_colProductType1
        Me.colProductType1.Name = "colProductType1"
        Me.colProductType1.OptionsColumn.AllowEdit = False
        Me.colProductType1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colProductType1
        '
        Me.layoutViewField_colProductType1.EditorPreferredWidth = 121
        Me.layoutViewField_colProductType1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colProductType1.Name = "layoutViewField_colProductType1"
        Me.layoutViewField_colProductType1.Size = New System.Drawing.Size(339, 20)
        Me.layoutViewField_colProductType1.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.LayoutViewColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutViewColumn1.FieldName = "GL Master / Account Type"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 162
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(380, 20)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colContract1
        '
        Me.colContract1.AppearanceCell.Options.UseTextOptions = True
        Me.colContract1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colContract1.FieldName = "Contract"
        Me.colContract1.LayoutViewField = Me.layoutViewField_colContract1
        Me.colContract1.Name = "colContract1"
        Me.colContract1.OptionsColumn.AllowEdit = False
        Me.colContract1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colContract1
        '
        Me.layoutViewField_colContract1.EditorPreferredWidth = 213
        Me.layoutViewField_colContract1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colContract1.Name = "layoutViewField_colContract1"
        Me.layoutViewField_colContract1.Size = New System.Drawing.Size(431, 20)
        Me.layoutViewField_colContract1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCounterpartyName1
        '
        Me.colCounterpartyName1.AppearanceCell.Options.UseTextOptions = True
        Me.colCounterpartyName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCounterpartyName1.FieldName = "Counterparty Name"
        Me.colCounterpartyName1.LayoutViewField = Me.layoutViewField_colCounterpartyName1
        Me.colCounterpartyName1.Name = "colCounterpartyName1"
        Me.colCounterpartyName1.OptionsColumn.AllowEdit = False
        Me.colCounterpartyName1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCounterpartyName1
        '
        Me.layoutViewField_colCounterpartyName1.EditorPreferredWidth = 450
        Me.layoutViewField_colCounterpartyName1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colCounterpartyName1.Name = "layoutViewField_colCounterpartyName1"
        Me.layoutViewField_colCounterpartyName1.Size = New System.Drawing.Size(668, 20)
        Me.layoutViewField_colCounterpartyName1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCounterpartyNo1
        '
        Me.colCounterpartyNo1.AppearanceCell.Options.UseTextOptions = True
        Me.colCounterpartyNo1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCounterpartyNo1.FieldName = "Counterparty No"
        Me.colCounterpartyNo1.LayoutViewField = Me.layoutViewField_colCounterpartyNo1
        Me.colCounterpartyNo1.Name = "colCounterpartyNo1"
        Me.colCounterpartyNo1.OptionsColumn.AllowEdit = False
        Me.colCounterpartyNo1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCounterpartyNo1
        '
        Me.layoutViewField_colCounterpartyNo1.EditorPreferredWidth = 194
        Me.layoutViewField_colCounterpartyNo1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colCounterpartyNo1.Name = "layoutViewField_colCounterpartyNo1"
        Me.layoutViewField_colCounterpartyNo1.Size = New System.Drawing.Size(412, 20)
        Me.layoutViewField_colCounterpartyNo1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colTradeDate1
        '
        Me.colTradeDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colTradeDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colTradeDate1.FieldName = "Trade Date"
        Me.colTradeDate1.LayoutViewField = Me.layoutViewField_colTradeDate1
        Me.colTradeDate1.Name = "colTradeDate1"
        Me.colTradeDate1.OptionsColumn.AllowEdit = False
        Me.colTradeDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colTradeDate1
        '
        Me.layoutViewField_colTradeDate1.EditorPreferredWidth = 112
        Me.layoutViewField_colTradeDate1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colTradeDate1.Name = "layoutViewField_colTradeDate1"
        Me.layoutViewField_colTradeDate1.Size = New System.Drawing.Size(330, 20)
        Me.layoutViewField_colTradeDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colStartDate1
        '
        Me.colStartDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colStartDate1.FieldName = "Start Date"
        Me.colStartDate1.LayoutViewField = Me.layoutViewField_colStartDate1
        Me.colStartDate1.Name = "colStartDate1"
        Me.colStartDate1.OptionsColumn.AllowEdit = False
        Me.colStartDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colStartDate1
        '
        Me.layoutViewField_colStartDate1.EditorPreferredWidth = 112
        Me.layoutViewField_colStartDate1.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colStartDate1.Name = "layoutViewField_colStartDate1"
        Me.layoutViewField_colStartDate1.Size = New System.Drawing.Size(330, 20)
        Me.layoutViewField_colStartDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colFinalMaturityDate1
        '
        Me.colFinalMaturityDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colFinalMaturityDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colFinalMaturityDate1.FieldName = "Final Maturity Date"
        Me.colFinalMaturityDate1.LayoutViewField = Me.layoutViewField_colFinalMaturityDate1
        Me.colFinalMaturityDate1.Name = "colFinalMaturityDate1"
        Me.colFinalMaturityDate1.OptionsColumn.AllowEdit = False
        Me.colFinalMaturityDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colFinalMaturityDate1
        '
        Me.layoutViewField_colFinalMaturityDate1.EditorPreferredWidth = 112
        Me.layoutViewField_colFinalMaturityDate1.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colFinalMaturityDate1.Name = "layoutViewField_colFinalMaturityDate1"
        Me.layoutViewField_colFinalMaturityDate1.Size = New System.Drawing.Size(330, 20)
        Me.layoutViewField_colFinalMaturityDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colOrgCcy1
        '
        Me.colOrgCcy1.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colOrgCcy1.FieldName = "Org Ccy"
        Me.colOrgCcy1.LayoutViewField = Me.layoutViewField_colOrgCcy1
        Me.colOrgCcy1.Name = "colOrgCcy1"
        Me.colOrgCcy1.OptionsColumn.AllowEdit = False
        Me.colOrgCcy1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colOrgCcy1
        '
        Me.layoutViewField_colOrgCcy1.EditorPreferredWidth = 50
        Me.layoutViewField_colOrgCcy1.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colOrgCcy1.Name = "layoutViewField_colOrgCcy1"
        Me.layoutViewField_colOrgCcy1.Size = New System.Drawing.Size(268, 20)
        Me.layoutViewField_colOrgCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.LayoutViewColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutViewColumn2.DisplayFormat.FormatString = "n2"
        Me.LayoutViewColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LayoutViewColumn2.FieldName = "Principal (Org  Ccy)"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_LayoutViewColumn2
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        Me.LayoutViewColumn2.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn2.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn2
        '
        Me.layoutViewField_LayoutViewColumn2.EditorPreferredWidth = 188
        Me.layoutViewField_LayoutViewColumn2.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_LayoutViewColumn2.Name = "layoutViewField_LayoutViewColumn2"
        Me.layoutViewField_LayoutViewColumn2.Size = New System.Drawing.Size(406, 20)
        Me.layoutViewField_LayoutViewColumn2.TextSize = New System.Drawing.Size(209, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.LayoutViewColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutViewColumn3.DisplayFormat.FormatString = "n2"
        Me.LayoutViewColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LayoutViewColumn3.FieldName = "Principal (EUR Equivalent)"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_LayoutViewColumn3
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        Me.LayoutViewColumn3.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn3.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn3
        '
        Me.layoutViewField_LayoutViewColumn3.EditorPreferredWidth = 188
        Me.layoutViewField_LayoutViewColumn3.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_LayoutViewColumn3.Name = "layoutViewField_LayoutViewColumn3"
        Me.layoutViewField_LayoutViewColumn3.Size = New System.Drawing.Size(406, 20)
        Me.layoutViewField_LayoutViewColumn3.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestRate1
        '
        Me.colCurrentInterestRate1.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestRate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCurrentInterestRate1.DisplayFormat.FormatString = "n4"
        Me.colCurrentInterestRate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCurrentInterestRate1.FieldName = "Current Interest Rate"
        Me.colCurrentInterestRate1.LayoutViewField = Me.layoutViewField_colCurrentInterestRate1
        Me.colCurrentInterestRate1.Name = "colCurrentInterestRate1"
        Me.colCurrentInterestRate1.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestRate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrentInterestRate1
        '
        Me.layoutViewField_colCurrentInterestRate1.EditorPreferredWidth = 188
        Me.layoutViewField_colCurrentInterestRate1.Location = New System.Drawing.Point(0, 260)
        Me.layoutViewField_colCurrentInterestRate1.Name = "layoutViewField_colCurrentInterestRate1"
        Me.layoutViewField_colCurrentInterestRate1.Size = New System.Drawing.Size(406, 20)
        Me.layoutViewField_colCurrentInterestRate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestCouponPeriodStartDate1
        '
        Me.colCurrentInterestCouponPeriodStartDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestCouponPeriodStartDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCurrentInterestCouponPeriodStartDate1.FieldName = "Current Interest Coupon Period Start Date"
        Me.colCurrentInterestCouponPeriodStartDate1.LayoutViewField = Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1
        Me.colCurrentInterestCouponPeriodStartDate1.Name = "colCurrentInterestCouponPeriodStartDate1"
        Me.colCurrentInterestCouponPeriodStartDate1.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestCouponPeriodStartDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrentInterestCouponPeriodStartDate1
        '
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.EditorPreferredWidth = 107
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Location = New System.Drawing.Point(0, 280)
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Name = "layoutViewField_colCurrentInterestCouponPeriodStartDate1"
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.Size = New System.Drawing.Size(325, 20)
        Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colCurrentInterestCouponPeriodEndDate1
        '
        Me.colCurrentInterestCouponPeriodEndDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestCouponPeriodEndDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCurrentInterestCouponPeriodEndDate1.FieldName = "Current Interest Coupon Period End Date"
        Me.colCurrentInterestCouponPeriodEndDate1.LayoutViewField = Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1
        Me.colCurrentInterestCouponPeriodEndDate1.Name = "colCurrentInterestCouponPeriodEndDate1"
        Me.colCurrentInterestCouponPeriodEndDate1.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestCouponPeriodEndDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrentInterestCouponPeriodEndDate1
        '
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.EditorPreferredWidth = 106
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Location = New System.Drawing.Point(0, 300)
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Name = "layoutViewField_colCurrentInterestCouponPeriodEndDate1"
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.Size = New System.Drawing.Size(324, 20)
        Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colAccruedInterestCouponOrgCcy1
        '
        Me.colAccruedInterestCouponOrgCcy1.AppearanceCell.Options.UseTextOptions = True
        Me.colAccruedInterestCouponOrgCcy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAccruedInterestCouponOrgCcy1.DisplayFormat.FormatString = "n2"
        Me.colAccruedInterestCouponOrgCcy1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAccruedInterestCouponOrgCcy1.FieldName = "Accrued Interest Coupon Org Ccy"
        Me.colAccruedInterestCouponOrgCcy1.LayoutViewField = Me.layoutViewField_colAccruedInterestCouponOrgCcy1
        Me.colAccruedInterestCouponOrgCcy1.Name = "colAccruedInterestCouponOrgCcy1"
        Me.colAccruedInterestCouponOrgCcy1.OptionsColumn.AllowEdit = False
        Me.colAccruedInterestCouponOrgCcy1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAccruedInterestCouponOrgCcy1
        '
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.EditorPreferredWidth = 186
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Location = New System.Drawing.Point(0, 320)
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Name = "layoutViewField_colAccruedInterestCouponOrgCcy1"
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.Size = New System.Drawing.Size(404, 20)
        Me.layoutViewField_colAccruedInterestCouponOrgCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colAccruedInterestCouponEUREqu1
        '
        Me.colAccruedInterestCouponEUREqu1.AppearanceCell.Options.UseTextOptions = True
        Me.colAccruedInterestCouponEUREqu1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAccruedInterestCouponEUREqu1.DisplayFormat.FormatString = "n2"
        Me.colAccruedInterestCouponEUREqu1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAccruedInterestCouponEUREqu1.FieldName = "Accrued Interest Coupon EUR Equ"
        Me.colAccruedInterestCouponEUREqu1.LayoutViewField = Me.layoutViewField_colAccruedInterestCouponEUREqu1
        Me.colAccruedInterestCouponEUREqu1.Name = "colAccruedInterestCouponEUREqu1"
        Me.colAccruedInterestCouponEUREqu1.OptionsColumn.AllowEdit = False
        Me.colAccruedInterestCouponEUREqu1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAccruedInterestCouponEUREqu1
        '
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.EditorPreferredWidth = 185
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Location = New System.Drawing.Point(0, 340)
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Name = "layoutViewField_colAccruedInterestCouponEUREqu1"
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.Size = New System.Drawing.Size(403, 20)
        Me.layoutViewField_colAccruedInterestCouponEUREqu1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colInterestCouponamountOrgCcy1
        '
        Me.colInterestCouponamountOrgCcy1.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestCouponamountOrgCcy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colInterestCouponamountOrgCcy1.DisplayFormat.FormatString = "n2"
        Me.colInterestCouponamountOrgCcy1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestCouponamountOrgCcy1.FieldName = "Interest Coupon amount Org Ccy"
        Me.colInterestCouponamountOrgCcy1.LayoutViewField = Me.layoutViewField_colInterestCouponamountOrgCcy1
        Me.colInterestCouponamountOrgCcy1.Name = "colInterestCouponamountOrgCcy1"
        Me.colInterestCouponamountOrgCcy1.OptionsColumn.AllowEdit = False
        Me.colInterestCouponamountOrgCcy1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colInterestCouponamountOrgCcy1
        '
        Me.layoutViewField_colInterestCouponamountOrgCcy1.EditorPreferredWidth = 185
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Location = New System.Drawing.Point(0, 360)
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Name = "layoutViewField_colInterestCouponamountOrgCcy1"
        Me.layoutViewField_colInterestCouponamountOrgCcy1.Size = New System.Drawing.Size(403, 20)
        Me.layoutViewField_colInterestCouponamountOrgCcy1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colInterestCouponAmountEUREqu1
        '
        Me.colInterestCouponAmountEUREqu1.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestCouponAmountEUREqu1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colInterestCouponAmountEUREqu1.DisplayFormat.FormatString = "n2"
        Me.colInterestCouponAmountEUREqu1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestCouponAmountEUREqu1.FieldName = "Interest Coupon Amount EUR Equ"
        Me.colInterestCouponAmountEUREqu1.LayoutViewField = Me.layoutViewField_colInterestCouponAmountEUREqu1
        Me.colInterestCouponAmountEUREqu1.Name = "colInterestCouponAmountEUREqu1"
        Me.colInterestCouponAmountEUREqu1.OptionsColumn.AllowEdit = False
        Me.colInterestCouponAmountEUREqu1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colInterestCouponAmountEUREqu1
        '
        Me.layoutViewField_colInterestCouponAmountEUREqu1.EditorPreferredWidth = 185
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Location = New System.Drawing.Point(0, 380)
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Name = "layoutViewField_colInterestCouponAmountEUREqu1"
        Me.layoutViewField_colInterestCouponAmountEUREqu1.Size = New System.Drawing.Size(403, 20)
        Me.layoutViewField_colInterestCouponAmountEUREqu1.TextSize = New System.Drawing.Size(209, 13)
        '
        'colDatadate1
        '
        Me.colDatadate1.AppearanceCell.Options.UseTextOptions = True
        Me.colDatadate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colDatadate1.FieldName = "Datadate"
        Me.colDatadate1.LayoutViewField = Me.layoutViewField_colDatadate1
        Me.colDatadate1.Name = "colDatadate1"
        Me.colDatadate1.OptionsColumn.AllowEdit = False
        Me.colDatadate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colDatadate1
        '
        Me.layoutViewField_colDatadate1.EditorPreferredWidth = -14
        Me.layoutViewField_colDatadate1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colDatadate1.Name = "layoutViewField_colDatadate1"
        Me.layoutViewField_colDatadate1.Size = New System.Drawing.Size(204, 440)
        Me.layoutViewField_colDatadate1.TextSize = New System.Drawing.Size(209, 13)
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.ACCRUED_INTEREST_ANALYSISBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.AccruedInterestAnalysisDetailView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(12, 106)
        Me.GridControl2.MainView = Me.AccruedInterestAnalysisBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2})
        Me.GridControl2.Size = New System.Drawing.Size(1495, 603)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AccruedInterestAnalysisBaseView, Me.GridView2, Me.AccruedInterestAnalysisDetailView})
        '
        'ACCRUED_INTEREST_ANALYSISBindingSource
        '
        Me.ACCRUED_INTEREST_ANALYSISBindingSource.DataMember = "ACCRUED INTEREST ANALYSIS"
        Me.ACCRUED_INTEREST_ANALYSISBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AccruedInterestAnalysisBaseView
        '
        Me.AccruedInterestAnalysisBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.AccruedInterestAnalysisBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.AccruedInterestAnalysisBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.AccruedInterestAnalysisBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.AccruedInterestAnalysisBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.AccruedInterestAnalysisBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.AccruedInterestAnalysisBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.AccruedInterestAnalysisBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colClass, Me.colContractType, Me.colProductType, Me.GridColumn1, Me.colContract, Me.colCounterpartyName, Me.colCounterpartyNo, Me.colTradeDate, Me.colStartDate, Me.colFinalMaturityDate, Me.colOrgCcy, Me.GridColumn2, Me.GridColumn3, Me.colCurrentInterestRate, Me.colCurrentInterestCouponPeriodStartDate, Me.colCurrentInterestCouponPeriodEndDate, Me.colAccruedInterestCouponOrgCcy, Me.colAccruedInterestCouponEUREqu, Me.colInterestCouponamountOrgCcy, Me.colInterestCouponAmountEUREqu, Me.colDatadate})
        Me.AccruedInterestAnalysisBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.AccruedInterestAnalysisBaseView.GridControl = Me.GridControl2
        Me.AccruedInterestAnalysisBaseView.Name = "AccruedInterestAnalysisBaseView"
        Me.AccruedInterestAnalysisBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.AccruedInterestAnalysisBaseView.OptionsCustomization.AllowRowSizing = True
        Me.AccruedInterestAnalysisBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.AccruedInterestAnalysisBaseView.OptionsFind.AlwaysVisible = True
        Me.AccruedInterestAnalysisBaseView.OptionsMenu.ShowFooterItem = True
        Me.AccruedInterestAnalysisBaseView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.AccruedInterestAnalysisBaseView.OptionsSelection.MultiSelect = True
        Me.AccruedInterestAnalysisBaseView.OptionsView.ColumnAutoWidth = False
        Me.AccruedInterestAnalysisBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.AccruedInterestAnalysisBaseView.OptionsView.ShowAutoFilterRow = True
        Me.AccruedInterestAnalysisBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.AccruedInterestAnalysisBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colClass
        '
        Me.colClass.FieldName = "Class"
        Me.colClass.Name = "colClass"
        Me.colClass.OptionsColumn.AllowEdit = False
        Me.colClass.OptionsColumn.ReadOnly = True
        Me.colClass.Visible = True
        Me.colClass.VisibleIndex = 0
        Me.colClass.Width = 92
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 1
        Me.colContractType.Width = 87
        '
        'colProductType
        '
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.OptionsColumn.AllowEdit = False
        Me.colProductType.OptionsColumn.ReadOnly = True
        Me.colProductType.Visible = True
        Me.colProductType.VisibleIndex = 2
        Me.colProductType.Width = 89
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "GL Master / Account Type"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 132
        '
        'colContract
        '
        Me.colContract.FieldName = "Contract"
        Me.colContract.Name = "colContract"
        Me.colContract.OptionsColumn.AllowEdit = False
        Me.colContract.OptionsColumn.ReadOnly = True
        Me.colContract.Visible = True
        Me.colContract.VisibleIndex = 4
        Me.colContract.Width = 140
        '
        'colCounterpartyName
        '
        Me.colCounterpartyName.FieldName = "Counterparty Name"
        Me.colCounterpartyName.Name = "colCounterpartyName"
        Me.colCounterpartyName.OptionsColumn.AllowEdit = False
        Me.colCounterpartyName.OptionsColumn.ReadOnly = True
        Me.colCounterpartyName.Visible = True
        Me.colCounterpartyName.VisibleIndex = 5
        Me.colCounterpartyName.Width = 337
        '
        'colCounterpartyNo
        '
        Me.colCounterpartyNo.FieldName = "Counterparty No"
        Me.colCounterpartyNo.Name = "colCounterpartyNo"
        Me.colCounterpartyNo.OptionsColumn.AllowEdit = False
        Me.colCounterpartyNo.OptionsColumn.ReadOnly = True
        Me.colCounterpartyNo.Visible = True
        Me.colCounterpartyNo.VisibleIndex = 6
        Me.colCounterpartyNo.Width = 237
        '
        'colTradeDate
        '
        Me.colTradeDate.AppearanceCell.Options.UseTextOptions = True
        Me.colTradeDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTradeDate.FieldName = "Trade Date"
        Me.colTradeDate.Name = "colTradeDate"
        Me.colTradeDate.OptionsColumn.AllowEdit = False
        Me.colTradeDate.OptionsColumn.ReadOnly = True
        Me.colTradeDate.Visible = True
        Me.colTradeDate.VisibleIndex = 7
        '
        'colStartDate
        '
        Me.colStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStartDate.FieldName = "Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.OptionsColumn.AllowEdit = False
        Me.colStartDate.OptionsColumn.ReadOnly = True
        Me.colStartDate.Visible = True
        Me.colStartDate.VisibleIndex = 8
        '
        'colFinalMaturityDate
        '
        Me.colFinalMaturityDate.AppearanceCell.Options.UseTextOptions = True
        Me.colFinalMaturityDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFinalMaturityDate.FieldName = "Final Maturity Date"
        Me.colFinalMaturityDate.Name = "colFinalMaturityDate"
        Me.colFinalMaturityDate.OptionsColumn.AllowEdit = False
        Me.colFinalMaturityDate.OptionsColumn.ReadOnly = True
        Me.colFinalMaturityDate.Visible = True
        Me.colFinalMaturityDate.VisibleIndex = 9
        Me.colFinalMaturityDate.Width = 105
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
        Me.colOrgCcy.VisibleIndex = 10
        Me.colOrgCcy.Width = 57
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.DisplayFormat.FormatString = "n2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "Principal (Org  Ccy)"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 11
        Me.GridColumn2.Width = 131
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.DisplayFormat.FormatString = "n2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "Principal (EUR Equivalent)"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 12
        Me.GridColumn3.Width = 147
        '
        'colCurrentInterestRate
        '
        Me.colCurrentInterestRate.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCurrentInterestRate.DisplayFormat.FormatString = "n4"
        Me.colCurrentInterestRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCurrentInterestRate.FieldName = "Current Interest Rate"
        Me.colCurrentInterestRate.Name = "colCurrentInterestRate"
        Me.colCurrentInterestRate.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestRate.OptionsColumn.ReadOnly = True
        Me.colCurrentInterestRate.Visible = True
        Me.colCurrentInterestRate.VisibleIndex = 13
        Me.colCurrentInterestRate.Width = 133
        '
        'colCurrentInterestCouponPeriodStartDate
        '
        Me.colCurrentInterestCouponPeriodStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestCouponPeriodStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrentInterestCouponPeriodStartDate.FieldName = "Current Interest Coupon Period Start Date"
        Me.colCurrentInterestCouponPeriodStartDate.Name = "colCurrentInterestCouponPeriodStartDate"
        Me.colCurrentInterestCouponPeriodStartDate.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestCouponPeriodStartDate.OptionsColumn.ReadOnly = True
        Me.colCurrentInterestCouponPeriodStartDate.Visible = True
        Me.colCurrentInterestCouponPeriodStartDate.VisibleIndex = 14
        Me.colCurrentInterestCouponPeriodStartDate.Width = 230
        '
        'colCurrentInterestCouponPeriodEndDate
        '
        Me.colCurrentInterestCouponPeriodEndDate.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrentInterestCouponPeriodEndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrentInterestCouponPeriodEndDate.FieldName = "Current Interest Coupon Period End Date"
        Me.colCurrentInterestCouponPeriodEndDate.Name = "colCurrentInterestCouponPeriodEndDate"
        Me.colCurrentInterestCouponPeriodEndDate.OptionsColumn.AllowEdit = False
        Me.colCurrentInterestCouponPeriodEndDate.OptionsColumn.ReadOnly = True
        Me.colCurrentInterestCouponPeriodEndDate.Visible = True
        Me.colCurrentInterestCouponPeriodEndDate.VisibleIndex = 15
        Me.colCurrentInterestCouponPeriodEndDate.Width = 217
        '
        'colAccruedInterestCouponOrgCcy
        '
        Me.colAccruedInterestCouponOrgCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colAccruedInterestCouponOrgCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAccruedInterestCouponOrgCcy.DisplayFormat.FormatString = "n2"
        Me.colAccruedInterestCouponOrgCcy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAccruedInterestCouponOrgCcy.FieldName = "Accrued Interest Coupon Org Ccy"
        Me.colAccruedInterestCouponOrgCcy.Name = "colAccruedInterestCouponOrgCcy"
        Me.colAccruedInterestCouponOrgCcy.OptionsColumn.AllowEdit = False
        Me.colAccruedInterestCouponOrgCcy.OptionsColumn.ReadOnly = True
        Me.colAccruedInterestCouponOrgCcy.Visible = True
        Me.colAccruedInterestCouponOrgCcy.VisibleIndex = 16
        Me.colAccruedInterestCouponOrgCcy.Width = 182
        '
        'colAccruedInterestCouponEUREqu
        '
        Me.colAccruedInterestCouponEUREqu.AppearanceCell.Options.UseTextOptions = True
        Me.colAccruedInterestCouponEUREqu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAccruedInterestCouponEUREqu.DisplayFormat.FormatString = "n2"
        Me.colAccruedInterestCouponEUREqu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAccruedInterestCouponEUREqu.FieldName = "Accrued Interest Coupon EUR Equ"
        Me.colAccruedInterestCouponEUREqu.Name = "colAccruedInterestCouponEUREqu"
        Me.colAccruedInterestCouponEUREqu.OptionsColumn.AllowEdit = False
        Me.colAccruedInterestCouponEUREqu.OptionsColumn.ReadOnly = True
        Me.colAccruedInterestCouponEUREqu.Visible = True
        Me.colAccruedInterestCouponEUREqu.VisibleIndex = 17
        Me.colAccruedInterestCouponEUREqu.Width = 178
        '
        'colInterestCouponamountOrgCcy
        '
        Me.colInterestCouponamountOrgCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestCouponamountOrgCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colInterestCouponamountOrgCcy.DisplayFormat.FormatString = "n2"
        Me.colInterestCouponamountOrgCcy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestCouponamountOrgCcy.FieldName = "Interest Coupon amount Org Ccy"
        Me.colInterestCouponamountOrgCcy.Name = "colInterestCouponamountOrgCcy"
        Me.colInterestCouponamountOrgCcy.OptionsColumn.AllowEdit = False
        Me.colInterestCouponamountOrgCcy.OptionsColumn.ReadOnly = True
        Me.colInterestCouponamountOrgCcy.Visible = True
        Me.colInterestCouponamountOrgCcy.VisibleIndex = 18
        Me.colInterestCouponamountOrgCcy.Width = 175
        '
        'colInterestCouponAmountEUREqu
        '
        Me.colInterestCouponAmountEUREqu.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestCouponAmountEUREqu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colInterestCouponAmountEUREqu.DisplayFormat.FormatString = "n2"
        Me.colInterestCouponAmountEUREqu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestCouponAmountEUREqu.FieldName = "Interest Coupon Amount EUR Equ"
        Me.colInterestCouponAmountEUREqu.Name = "colInterestCouponAmountEUREqu"
        Me.colInterestCouponAmountEUREqu.OptionsColumn.AllowEdit = False
        Me.colInterestCouponAmountEUREqu.OptionsColumn.ReadOnly = True
        Me.colInterestCouponAmountEUREqu.Visible = True
        Me.colInterestCouponAmountEUREqu.VisibleIndex = 19
        Me.colInterestCouponAmountEUREqu.Width = 179
        '
        'colDatadate
        '
        Me.colDatadate.AppearanceCell.Options.UseTextOptions = True
        Me.colDatadate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDatadate.FieldName = "Datadate"
        Me.colDatadate.Name = "colDatadate"
        Me.colDatadate.OptionsColumn.AllowEdit = False
        Me.colDatadate.OptionsColumn.ReadOnly = True
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
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colClass1, Me.layoutViewField_colContractType1, Me.layoutViewField_colProductType1, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_colContract1, Me.layoutViewField_colCounterpartyName1, Me.layoutViewField_colCounterpartyNo1, Me.layoutViewField_colTradeDate1, Me.layoutViewField_colStartDate1, Me.layoutViewField_colFinalMaturityDate1, Me.layoutViewField_colOrgCcy1, Me.layoutViewField_LayoutViewColumn2, Me.layoutViewField_LayoutViewColumn3, Me.layoutViewField_colCurrentInterestRate1, Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, Me.layoutViewField_colAccruedInterestCouponOrgCcy1, Me.layoutViewField_colAccruedInterestCouponEUREqu1, Me.layoutViewField_colInterestCouponamountOrgCcy1, Me.layoutViewField_colInterestCouponAmountEUREqu1, Me.item1, Me.item2, Me.item3, Me.item4, Me.item5, Me.item6, Me.item7, Me.item8, Me.item9, Me.item10, Me.item11, Me.item12, Me.item13, Me.item14, Me.item15, Me.item16, Me.item17, Me.item18, Me.item19, Me.item20, Me.item21})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'item1
        '
        Me.item1.AllowHotTrack = False
        Me.item1.CustomizationFormText = "item1"
        Me.item1.Location = New System.Drawing.Point(0, 400)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(827, 156)
        Me.item1.TextSize = New System.Drawing.Size(0, 0)
        '
        'item2
        '
        Me.item2.AllowHotTrack = False
        Me.item2.CustomizationFormText = "item2"
        Me.item2.Location = New System.Drawing.Point(339, 0)
        Me.item2.Name = "item2"
        Me.item2.Size = New System.Drawing.Size(488, 20)
        Me.item2.TextSize = New System.Drawing.Size(0, 0)
        '
        'item3
        '
        Me.item3.AllowHotTrack = False
        Me.item3.CustomizationFormText = "item3"
        Me.item3.Location = New System.Drawing.Point(339, 20)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(488, 20)
        Me.item3.TextSize = New System.Drawing.Size(0, 0)
        '
        'item4
        '
        Me.item4.AllowHotTrack = False
        Me.item4.CustomizationFormText = "item4"
        Me.item4.Location = New System.Drawing.Point(339, 40)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(488, 20)
        Me.item4.TextSize = New System.Drawing.Size(0, 0)
        '
        'item5
        '
        Me.item5.AllowHotTrack = False
        Me.item5.CustomizationFormText = "item5"
        Me.item5.Location = New System.Drawing.Point(380, 60)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(447, 20)
        Me.item5.TextSize = New System.Drawing.Size(0, 0)
        '
        'item6
        '
        Me.item6.AllowHotTrack = False
        Me.item6.CustomizationFormText = "item6"
        Me.item6.Location = New System.Drawing.Point(431, 80)
        Me.item6.Name = "item6"
        Me.item6.Size = New System.Drawing.Size(396, 20)
        Me.item6.TextSize = New System.Drawing.Size(0, 0)
        '
        'item7
        '
        Me.item7.AllowHotTrack = False
        Me.item7.CustomizationFormText = "item7"
        Me.item7.Location = New System.Drawing.Point(668, 100)
        Me.item7.Name = "item7"
        Me.item7.Size = New System.Drawing.Size(159, 20)
        Me.item7.TextSize = New System.Drawing.Size(0, 0)
        '
        'item8
        '
        Me.item8.AllowHotTrack = False
        Me.item8.CustomizationFormText = "item8"
        Me.item8.Location = New System.Drawing.Point(412, 120)
        Me.item8.Name = "item8"
        Me.item8.Size = New System.Drawing.Size(415, 20)
        Me.item8.TextSize = New System.Drawing.Size(0, 0)
        '
        'item9
        '
        Me.item9.AllowHotTrack = False
        Me.item9.CustomizationFormText = "item9"
        Me.item9.Location = New System.Drawing.Point(330, 140)
        Me.item9.Name = "item9"
        Me.item9.Size = New System.Drawing.Size(497, 20)
        Me.item9.TextSize = New System.Drawing.Size(0, 0)
        '
        'item10
        '
        Me.item10.AllowHotTrack = False
        Me.item10.CustomizationFormText = "item10"
        Me.item10.Location = New System.Drawing.Point(330, 160)
        Me.item10.Name = "item10"
        Me.item10.Size = New System.Drawing.Size(497, 20)
        Me.item10.TextSize = New System.Drawing.Size(0, 0)
        '
        'item11
        '
        Me.item11.AllowHotTrack = False
        Me.item11.CustomizationFormText = "item11"
        Me.item11.Location = New System.Drawing.Point(330, 180)
        Me.item11.Name = "item11"
        Me.item11.Size = New System.Drawing.Size(497, 20)
        Me.item11.TextSize = New System.Drawing.Size(0, 0)
        '
        'item12
        '
        Me.item12.AllowHotTrack = False
        Me.item12.CustomizationFormText = "item12"
        Me.item12.Location = New System.Drawing.Point(268, 200)
        Me.item12.Name = "item12"
        Me.item12.Size = New System.Drawing.Size(559, 20)
        Me.item12.TextSize = New System.Drawing.Size(0, 0)
        '
        'item13
        '
        Me.item13.AllowHotTrack = False
        Me.item13.CustomizationFormText = "item13"
        Me.item13.Location = New System.Drawing.Point(406, 220)
        Me.item13.Name = "item13"
        Me.item13.Size = New System.Drawing.Size(421, 20)
        Me.item13.TextSize = New System.Drawing.Size(0, 0)
        '
        'item14
        '
        Me.item14.AllowHotTrack = False
        Me.item14.CustomizationFormText = "item14"
        Me.item14.Location = New System.Drawing.Point(406, 240)
        Me.item14.Name = "item14"
        Me.item14.Size = New System.Drawing.Size(421, 20)
        Me.item14.TextSize = New System.Drawing.Size(0, 0)
        '
        'item15
        '
        Me.item15.AllowHotTrack = False
        Me.item15.CustomizationFormText = "item15"
        Me.item15.Location = New System.Drawing.Point(406, 260)
        Me.item15.Name = "item15"
        Me.item15.Size = New System.Drawing.Size(421, 20)
        Me.item15.TextSize = New System.Drawing.Size(0, 0)
        '
        'item16
        '
        Me.item16.AllowHotTrack = False
        Me.item16.CustomizationFormText = "item16"
        Me.item16.Location = New System.Drawing.Point(325, 280)
        Me.item16.Name = "item16"
        Me.item16.Size = New System.Drawing.Size(502, 20)
        Me.item16.TextSize = New System.Drawing.Size(0, 0)
        '
        'item17
        '
        Me.item17.AllowHotTrack = False
        Me.item17.CustomizationFormText = "item17"
        Me.item17.Location = New System.Drawing.Point(324, 300)
        Me.item17.Name = "item17"
        Me.item17.Size = New System.Drawing.Size(503, 20)
        Me.item17.TextSize = New System.Drawing.Size(0, 0)
        '
        'item18
        '
        Me.item18.AllowHotTrack = False
        Me.item18.CustomizationFormText = "item18"
        Me.item18.Location = New System.Drawing.Point(404, 320)
        Me.item18.Name = "item18"
        Me.item18.Size = New System.Drawing.Size(423, 20)
        Me.item18.TextSize = New System.Drawing.Size(0, 0)
        '
        'item19
        '
        Me.item19.AllowHotTrack = False
        Me.item19.CustomizationFormText = "item19"
        Me.item19.Location = New System.Drawing.Point(403, 340)
        Me.item19.Name = "item19"
        Me.item19.Size = New System.Drawing.Size(424, 20)
        Me.item19.TextSize = New System.Drawing.Size(0, 0)
        '
        'item20
        '
        Me.item20.AllowHotTrack = False
        Me.item20.CustomizationFormText = "item20"
        Me.item20.Location = New System.Drawing.Point(403, 360)
        Me.item20.Name = "item20"
        Me.item20.Size = New System.Drawing.Size(424, 20)
        Me.item20.TextSize = New System.Drawing.Size(0, 0)
        '
        'item21
        '
        Me.item21.AllowHotTrack = False
        Me.item21.CustomizationFormText = "item21"
        Me.item21.Location = New System.Drawing.Point(403, 380)
        Me.item21.Name = "item21"
        Me.item21.Size = New System.Drawing.Size(424, 20)
        Me.item21.TextSize = New System.Drawing.Size(0, 0)
        '
        'ACCRUED_INTEREST_ANALYSISTableAdapter
        '
        Me.ACCRUED_INTEREST_ANALYSISTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Me.ACCRUED_INTEREST_ANALYSISTableAdapter
        Me.TableAdapterManager.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
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
        Me.TableAdapterManager.GL_ACCOUNTS_NEWGTableAdapter = Nothing
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Load_AccruedInterestAnalysis_btn)
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.AccruedInterestAnalysisViewDetails_btn)
        Me.LayoutControl1.Controls.Add(Me.AccruedInterestAnalysis_Print_Export_btn)
        Me.LayoutControl1.Controls.Add(Me.AccruedInterestAnalysisDateEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(911, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1519, 721)
        Me.LayoutControl1.TabIndex = 6
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Load_AccruedInterestAnalysis_btn
        '
        Me.Load_AccruedInterestAnalysis_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Load_AccruedInterestAnalysis_btn.ImageOptions.ImageIndex = 6
        Me.Load_AccruedInterestAnalysis_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Load_AccruedInterestAnalysis_btn.Location = New System.Drawing.Point(651, 80)
        Me.Load_AccruedInterestAnalysis_btn.Name = "Load_AccruedInterestAnalysis_btn"
        Me.Load_AccruedInterestAnalysis_btn.Size = New System.Drawing.Size(200, 22)
        Me.Load_AccruedInterestAnalysis_btn.StyleController = Me.LayoutControl1
        Me.Load_AccruedInterestAnalysis_btn.TabIndex = 8
        Me.Load_AccruedInterestAnalysis_btn.Text = "Load Accrued Interest Analysis"
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
        'AccruedInterestAnalysisViewDetails_btn
        '
        Me.AccruedInterestAnalysisViewDetails_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AccruedInterestAnalysisViewDetails_btn.ImageOptions.ImageIndex = 0
        Me.AccruedInterestAnalysisViewDetails_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.AccruedInterestAnalysisViewDetails_btn.Location = New System.Drawing.Point(1363, 12)
        Me.AccruedInterestAnalysisViewDetails_btn.Name = "AccruedInterestAnalysisViewDetails_btn"
        Me.AccruedInterestAnalysisViewDetails_btn.Size = New System.Drawing.Size(144, 22)
        Me.AccruedInterestAnalysisViewDetails_btn.StyleController = Me.LayoutControl1
        Me.AccruedInterestAnalysisViewDetails_btn.TabIndex = 7
        Me.AccruedInterestAnalysisViewDetails_btn.Text = "View Details"
        '
        'AccruedInterestAnalysis_Print_Export_btn
        '
        Me.AccruedInterestAnalysis_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AccruedInterestAnalysis_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.AccruedInterestAnalysis_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.AccruedInterestAnalysis_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.AccruedInterestAnalysis_Print_Export_btn.Name = "AccruedInterestAnalysis_Print_Export_btn"
        Me.AccruedInterestAnalysis_Print_Export_btn.Size = New System.Drawing.Size(112, 22)
        Me.AccruedInterestAnalysis_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.AccruedInterestAnalysis_Print_Export_btn.TabIndex = 9
        Me.AccruedInterestAnalysis_Print_Export_btn.Text = "Print or Export"
        '
        'AccruedInterestAnalysisDateEdit
        '
        Me.AccruedInterestAnalysisDateEdit.Location = New System.Drawing.Point(651, 54)
        Me.AccruedInterestAnalysisDateEdit.Name = "AccruedInterestAnalysisDateEdit"
        Me.AccruedInterestAnalysisDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AccruedInterestAnalysisDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AccruedInterestAnalysisDateEdit.Properties.Appearance.Options.UseFont = True
        Me.AccruedInterestAnalysisDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.AccruedInterestAnalysisDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.AccruedInterestAnalysisDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        EditorButtonImageOptions1.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.AccruedInterestAnalysisDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Reload", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.AccruedInterestAnalysisDateEdit.Properties.DisplayFormat.FormatString = "d"
        Me.AccruedInterestAnalysisDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccruedInterestAnalysisDateEdit.Properties.EditFormat.FormatString = "d"
        Me.AccruedInterestAnalysisDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccruedInterestAnalysisDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.AccruedInterestAnalysisDateEdit.Size = New System.Drawing.Size(200, 22)
        Me.AccruedInterestAnalysisDateEdit.StyleController = Me.LayoutControl1
        Me.AccruedInterestAnalysisDateEdit.TabIndex = 12
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
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.EmptySpaceItem8, Me.EmptySpaceItem9, Me.LayoutControlItem5, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1519, 721)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(116, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1233, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.AccruedInterestAnalysis_Print_Export_btn
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
        Me.LayoutControlItem3.Control = Me.AccruedInterestAnalysisViewDetails_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1351, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(148, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1349, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1499, 607)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.CustomizationFormText = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(843, 26)
        Me.EmptySpaceItem8.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(656, 68)
        Me.EmptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.CustomizationFormText = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(639, 68)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem5.Control = Me.AccruedInterestAnalysisDateEdit
        Me.LayoutControlItem5.CustomizationFormText = "Date from"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(639, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(204, 42)
        Me.LayoutControlItem5.Text = "Accrued Interest Analysis Date"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(149, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.Load_AccruedInterestAnalysis_btn
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(639, 68)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(204, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        'AccruedInterestAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1519, 721)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AccruedInterestAnalysis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accrued Interest Analysis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AccruedInterestAnalysisDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colClass1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colContractType1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colProductType1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colContract1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCounterpartyName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCounterpartyNo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTradeDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStartDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFinalMaturityDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOrgCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestRate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodStartDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentInterestCouponPeriodEndDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccruedInterestCouponOrgCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccruedInterestCouponEUREqu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInterestCouponamountOrgCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInterestCouponAmountEUREqu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDatadate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACCRUED_INTEREST_ANALYSISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccruedInterestAnalysisBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccruedInterestAnalysisDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents ACCRUED_INTEREST_ANALYSISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ACCRUED_INTEREST_ANALYSISTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.ACCRUED_INTEREST_ANALYSISTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Load_AccruedInterestAnalysis_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AccruedInterestAnalysisDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents AccruedInterestAnalysisBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AccruedInterestAnalysisViewDetails_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccruedInterestAnalysis_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContract As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCounterpartyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCounterpartyNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTradeDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFinalMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrentInterestRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrentInterestCouponPeriodStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrentInterestCouponPeriodEndDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccruedInterestCouponOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccruedInterestCouponEUREqu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInterestCouponamountOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInterestCouponAmountEUREqu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDatadate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colClass1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colContractType1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colProductType1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colContract1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCounterpartyName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCounterpartyNo1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTradeDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStartDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFinalMaturityDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colOrgCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCurrentInterestRate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCurrentInterestCouponPeriodStartDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCurrentInterestCouponPeriodEndDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAccruedInterestCouponOrgCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAccruedInterestCouponEUREqu1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colInterestCouponamountOrgCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colInterestCouponAmountEUREqu1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colDatadate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colClass1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colContractType1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colProductType1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colContract1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCounterpartyName1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCounterpartyNo1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTradeDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStartDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFinalMaturityDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colOrgCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCurrentInterestRate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCurrentInterestCouponPeriodStartDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCurrentInterestCouponPeriodEndDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAccruedInterestCouponOrgCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAccruedInterestCouponEUREqu1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colInterestCouponamountOrgCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colInterestCouponAmountEUREqu1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colDatadate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents item1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item5 As DevExpress.XtraLayout.EmptySpaceItem
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
    Friend WithEvents item16 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item17 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item18 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item19 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item20 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item21 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents AccruedInterestAnalysisDateEdit As DevExpress.XtraEditors.ComboBoxEdit
End Class
