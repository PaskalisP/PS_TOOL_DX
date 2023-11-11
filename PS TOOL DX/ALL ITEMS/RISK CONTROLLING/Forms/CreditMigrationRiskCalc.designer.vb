<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreditMigrationRiskCalc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditMigrationRiskCalc))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Me.colExpectedValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CMR_Details_GridControl = New DevExpress.XtraGrid.GridControl()
        Me.CreditMigrationRisk_DetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditMigrationRiskDataSet = New PS_TOOL_DX.CreditMigrationRiskDataSet()
        Me.CMR_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDowngradeStatus2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink_AllDates = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.CSR_AllDates_GridControl = New DevExpress.XtraGrid.GridControl()
        Me.CreditMigrationRisk_DATEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CMR_AllDates_GridView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colID2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCreditMigrationRisk = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.PrintableComponentLink_SingleDate = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CMR_Groups_GridControl = New DevExpress.XtraGrid.GridControl()
        Me.CreditMigrationRisk_GroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CMR_Groups_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDowngradeStatus1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroupName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubBorrowersCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFinalEadTotalSum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLGD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD_EaD_weighted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD_3bps_floor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIndicatorOfFloor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityEADweigthed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colR_CoefficientOfColleration = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colb_MaturityAdjustment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRW_RiskWeightedExposure = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUL_UnexpectedLoss = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVLGDi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGAn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox9 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox10 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.CMR_Totals_GridControl = New DevExpress.XtraGrid.GridControl()
        Me.CreditMigrationRisk_TotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CMR_Totals_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDowngradeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLevelOfConfidence = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumUL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSummeFinalEADTotalSum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnu_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colp_alpha_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colb_beta_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGamma_inv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDelta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colK_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumGA_rel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumGA_Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalRisk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskAdjustment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalRisk_Adjusted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colImpactOnTotalRisk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPropability = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox5 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox6 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.Delta_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.GAMMAINV_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.nu_Value_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.p_alpha_value_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CreditMigrationRisk_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.b_beta_value_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LevelOfConfidence_TextEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CreditSpreadRisk_PortfolioRiskCalculationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RibbonControl2 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.DailyRiskTable_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LoanStructureTable_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.InterestRateRiskHUMPBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RecalculateCreditRiskCurrentDateBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RecalculateCreditRiskSpecificPeriodBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.CreditMigrationRisk_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_Daten_Kunden_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_Meldedatei_Erstellung_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Gesetzliche_Einlagensicherung_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_Laden_BASIS_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EAEG_Laden_ERWEITERT_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.CreditMigrationRiskExcel_BarbuttonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BusinessDate_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.BusinessDate_SearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.BusinessDates_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBusinessDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.Reports_BarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.Reload_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.Print_Export_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.ViewDetails_SwitchItem = New DevExpress.XtraBars.BarToggleSwitchItem()
        Me.bbi_Close = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter = New PS_TOOL_DX.CreditSpreadRiskDataSetTableAdapters.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter()
        Me.CreditSpreadRisk_SegmentRiskCalculationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditSpreadRisk_SegmentRiskCalculationTableAdapter = New PS_TOOL_DX.CreditSpreadRiskDataSetTableAdapters.CreditSpreadRisk_SegmentRiskCalculationTableAdapter()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.CreditMigrationRisk_DATETableAdapter = New PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_DATETableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.TableAdapterManager()
        Me.CreditMigrationRisk_DetailsTableAdapter = New PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_DetailsTableAdapter()
        Me.CreditMigrationRisk_GroupsTableAdapter = New PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_GroupsTableAdapter()
        Me.CreditMigrationRisk_TotalsTableAdapter = New PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_TotalsTableAdapter()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_Details_GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRisk_DetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRiskDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSR_AllDates_GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRisk_DATEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_AllDates_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CMR_Groups_GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRisk_GroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_Groups_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_Totals_GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRisk_TotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMR_Totals_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.Delta_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAMMAINV_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nu_Value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p_alpha_value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditMigrationRisk_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.b_beta_value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LevelOfConfidence_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditSpreadRisk_PortfolioRiskCalculationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessDate_SearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessDates_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditSpreadRisk_SegmentRiskCalculationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colExpectedValue
        '
        Me.colExpectedValue.Caption = "Expected Value"
        Me.colExpectedValue.DisplayFormat.FormatString = "n2"
        Me.colExpectedValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExpectedValue.FieldName = "ExpectedValue"
        Me.colExpectedValue.Name = "colExpectedValue"
        Me.colExpectedValue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpectedValue", "CMR={0:n2}")})
        Me.colExpectedValue.ToolTip = "Impact on Total Risk x Propability"
        Me.colExpectedValue.Visible = True
        Me.colExpectedValue.VisibleIndex = 9
        Me.colExpectedValue.Width = 149
        '
        'ToolTipController1
        '
        Me.ToolTipController1.AutoPopDelay = 60000
        Me.ToolTipController1.CloseOnClick = DevExpress.Utils.DefaultBoolean.[True]
        Me.ToolTipController1.ImageIndex = 13
        Me.ToolTipController1.ImageList = Me.ImageCollection1
        Me.ToolTipController1.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7
        Me.ToolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Valid.ico")
        Me.ImageCollection1.Images.SetKeyName(5, "Eheleute.ico")
        Me.ImageCollection1.Images.SetKeyName(6, "Frau.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "Herr.ico")
        Me.ImageCollection1.Images.SetKeyName(8, "HerrUndFrau.ico")
        Me.ImageCollection1.Images.SetKeyName(9, "Firma.ico")
        Me.ImageCollection1.Images.SetKeyName(10, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(11, "CrystalReport.jpg")
        Me.ImageCollection1.Images.SetKeyName(12, "Folder New1.ico")
        Me.ImageCollection1.Images.SetKeyName(13, "Info.ico")
        Me.ImageCollection1.InsertGalleryImage("chartsshowlegend_16x16.png", "images/chart/chartsshowlegend_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/chartsshowlegend_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "chartsshowlegend_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("bodetails_16x16.png", "images/business%20objects/bodetails_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bodetails_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "bodetails_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 16)
        Me.ImageCollection1.Images.SetKeyName(16, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("export_16x16.png", "devav/actions/export_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/export_16x16.png"), 17)
        Me.ImageCollection1.Images.SetKeyName(17, "export_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(18, "exporttoxlsx_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(19, "boreport2_16x16.png")
        '
        'CMR_Details_GridControl
        '
        Me.CMR_Details_GridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMR_Details_GridControl.DataSource = Me.CreditMigrationRisk_DetailsBindingSource
        Me.CMR_Details_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.CMR_Details_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.CMR_Details_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.CMR_Details_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.CMR_Details_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.CMR_Details_GridControl.Location = New System.Drawing.Point(24, 369)
        Me.CMR_Details_GridControl.MainView = Me.CMR_Details_GridView
        Me.CMR_Details_GridControl.Name = "CMR_Details_GridControl"
        Me.CMR_Details_GridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox3, Me.RepositoryItemImageComboBox4})
        Me.CMR_Details_GridControl.ShowOnlyPredefinedDetails = True
        Me.CMR_Details_GridControl.Size = New System.Drawing.Size(1813, 500)
        Me.CMR_Details_GridControl.TabIndex = 15
        Me.CMR_Details_GridControl.ToolTipController = Me.ToolTipController1
        Me.CMR_Details_GridControl.UseEmbeddedNavigator = True
        Me.CMR_Details_GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CMR_Details_GridView})
        '
        'CreditMigrationRisk_DetailsBindingSource
        '
        Me.CreditMigrationRisk_DetailsBindingSource.DataMember = "CreditMigrationRisk_Details"
        Me.CreditMigrationRisk_DetailsBindingSource.DataSource = Me.CreditMigrationRiskDataSet
        '
        'CreditMigrationRiskDataSet
        '
        Me.CreditMigrationRiskDataSet.DataSetName = "CreditMigrationRiskDataSet"
        Me.CreditMigrationRiskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CMR_Details_GridView
        '
        Me.CMR_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CMR_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CMR_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CMR_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CMR_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CMR_Details_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.CMR_Details_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CMR_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn41, Me.colDowngradeStatus2, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69, Me.GridColumn70})
        Me.CMR_Details_GridView.GridControl = Me.CMR_Details_GridControl
        Me.CMR_Details_GridView.GroupCount = 1
        Me.CMR_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "Expected Loss={0:n2}")})
        Me.CMR_Details_GridView.Name = "CMR_Details_GridView"
        Me.CMR_Details_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CMR_Details_GridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Details_GridView.OptionsBehavior.ReadOnly = True
        Me.CMR_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CMR_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.CMR_Details_GridView.OptionsSelection.MultiSelect = True
        Me.CMR_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.CMR_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CMR_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CMR_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CMR_Details_GridView.OptionsView.ShowFooter = True
        Me.CMR_Details_GridView.OptionsView.ShowGroupedColumns = True
        Me.CMR_Details_GridView.OptionsView.ShowGroupPanel = False
        Me.CMR_Details_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDowngradeStatus2, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.CMR_Details_GridView.ViewCaption = "CREDIT RISK DETAILS"
        '
        'GridColumn41
        '
        Me.GridColumn41.FieldName = "ID"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        '
        'colDowngradeStatus2
        '
        Me.colDowngradeStatus2.FieldName = "DowngradeStatus"
        Me.colDowngradeStatus2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colDowngradeStatus2.Name = "colDowngradeStatus2"
        Me.colDowngradeStatus2.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.colDowngradeStatus2.Visible = True
        Me.colDowngradeStatus2.VisibleIndex = 0
        Me.colDowngradeStatus2.Width = 249
        '
        'GridColumn42
        '
        Me.GridColumn42.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn42.Caption = "Obligor Grade"
        Me.GridColumn42.FieldName = "Obligor Rate"
        Me.GridColumn42.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 3
        Me.GridColumn42.Width = 94
        '
        'GridColumn43
        '
        Me.GridColumn43.FieldName = "Contract Type"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 5
        Me.GridColumn43.Width = 86
        '
        'GridColumn44
        '
        Me.GridColumn44.FieldName = "Product Type"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 6
        Me.GridColumn44.Width = 93
        '
        'GridColumn45
        '
        Me.GridColumn45.FieldName = "GL Master / Account Type"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        Me.GridColumn45.Width = 148
        '
        'GridColumn46
        '
        Me.GridColumn46.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn46.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.OptionsColumn.ReadOnly = True
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 2
        Me.GridColumn46.Width = 271
        '
        'GridColumn47
        '
        Me.GridColumn47.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn47.FieldName = "Client No"
        Me.GridColumn47.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.OptionsColumn.ReadOnly = True
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 1
        Me.GridColumn47.Width = 293
        '
        'GridColumn48
        '
        Me.GridColumn48.FieldName = "Contract Collateral ID"
        Me.GridColumn48.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.OptionsColumn.ReadOnly = True
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 4
        Me.GridColumn48.Width = 137
        '
        'GridColumn49
        '
        Me.GridColumn49.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn49.FieldName = "Maturity Date"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.OptionsColumn.ReadOnly = True
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 7
        Me.GridColumn49.Width = 81
        '
        'GridColumn50
        '
        Me.GridColumn50.FieldName = "Remaining Year(s) to Maturity"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.OptionsColumn.ReadOnly = True
        Me.GridColumn50.Width = 83
        '
        'GridColumn51
        '
        Me.GridColumn51.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn51.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn51.FieldName = "Org Ccy"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.OptionsColumn.ReadOnly = True
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 8
        Me.GridColumn51.Width = 47
        '
        'GridColumn52
        '
        Me.GridColumn52.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn52.DisplayFormat.FormatString = "n2"
        Me.GridColumn52.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn52.FieldName = "Credit Outstanding (Org Ccy)"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsColumn.AllowEdit = False
        Me.GridColumn52.OptionsColumn.ReadOnly = True
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 9
        Me.GridColumn52.Width = 159
        '
        'GridColumn53
        '
        Me.GridColumn53.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn53.DisplayFormat.FormatString = "n2"
        Me.GridColumn53.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn53.FieldName = "Credit Outstanding (EUR Equ)"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.OptionsColumn.ReadOnly = True
        Me.GridColumn53.ToolTip = "without consideration of CASHPLEDGE"
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 10
        Me.GridColumn53.Width = 158
        '
        'GridColumn54
        '
        Me.GridColumn54.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn54.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn54.DisplayFormat.FormatString = "n2"
        Me.GridColumn54.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn54.FieldName = "NetCreditOutstandingAmountEUR"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsColumn.AllowEdit = False
        Me.GridColumn54.OptionsColumn.ReadOnly = True
        Me.GridColumn54.ToolTip = "CASHPLEDGE Consideration"
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 11
        Me.GridColumn54.Width = 196
        '
        'GridColumn55
        '
        Me.GridColumn55.FieldName = "InternalInfo"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsColumn.AllowEdit = False
        Me.GridColumn55.OptionsColumn.ReadOnly = True
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 12
        Me.GridColumn55.Width = 104
        '
        'GridColumn56
        '
        Me.GridColumn56.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn56.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn56.FieldName = "PD"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.OptionsColumn.AllowEdit = False
        Me.GridColumn56.OptionsColumn.ReadOnly = True
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 13
        Me.GridColumn56.Width = 59
        '
        'GridColumn57
        '
        Me.GridColumn57.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn57.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn57.Caption = "(ER1)"
        Me.GridColumn57.DisplayFormat.FormatString = "p2"
        Me.GridColumn57.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn57.FieldName = "(1-ER)"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.OptionsColumn.AllowEdit = False
        Me.GridColumn57.OptionsColumn.ReadOnly = True
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 14
        Me.GridColumn57.Width = 61
        '
        'GridColumn58
        '
        Me.GridColumn58.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn58.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn58.Caption = "Credit Risk (ER1)"
        Me.GridColumn58.DisplayFormat.FormatString = "n2"
        Me.GridColumn58.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn58.FieldName = "Credit Risk Amount(EUR Equ)"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsColumn.AllowEdit = False
        Me.GridColumn58.OptionsColumn.ReadOnly = True
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 15
        Me.GridColumn58.Width = 150
        '
        'GridColumn59
        '
        Me.GridColumn59.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn59.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn59.Caption = "Net Credit Risk (ER1)"
        Me.GridColumn59.DisplayFormat.FormatString = "n2"
        Me.GridColumn59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn59.FieldName = "NetCredit Risk Amount(EUR Equ)"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.OptionsColumn.AllowEdit = False
        Me.GridColumn59.OptionsColumn.ReadOnly = True
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 16
        Me.GridColumn59.Width = 172
        '
        'GridColumn60
        '
        Me.GridColumn60.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn60.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn60.Caption = "(ER2)"
        Me.GridColumn60.DisplayFormat.FormatString = "p2"
        Me.GridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn60.FieldName = "(1-ER_45)"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.OptionsColumn.AllowEdit = False
        Me.GridColumn60.OptionsColumn.ReadOnly = True
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 17
        Me.GridColumn60.Width = 61
        '
        'GridColumn61
        '
        Me.GridColumn61.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn61.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn61.Caption = "Credit Risk (ER2)"
        Me.GridColumn61.DisplayFormat.FormatString = "n2"
        Me.GridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn61.FieldName = "CreditRiskAmountEUREquER45"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.OptionsColumn.AllowEdit = False
        Me.GridColumn61.OptionsColumn.ReadOnly = True
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 18
        Me.GridColumn61.Width = 181
        '
        'GridColumn62
        '
        Me.GridColumn62.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn62.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn62.Caption = "Net Credit Risk (ER2)"
        Me.GridColumn62.DisplayFormat.FormatString = "n2"
        Me.GridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn62.FieldName = "NetCreditRiskAmountEUREquER45"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.OptionsColumn.AllowEdit = False
        Me.GridColumn62.OptionsColumn.ReadOnly = True
        Me.GridColumn62.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", "Expected Loss={0:n2}")})
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 19
        Me.GridColumn62.Width = 242
        '
        'GridColumn63
        '
        Me.GridColumn63.FieldName = "CoreDefinition"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.OptionsColumn.AllowEdit = False
        Me.GridColumn63.OptionsColumn.ReadOnly = True
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 20
        Me.GridColumn63.Width = 85
        '
        'GridColumn64
        '
        Me.GridColumn64.FieldName = "ClientGroup"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.OptionsColumn.AllowEdit = False
        Me.GridColumn64.OptionsColumn.ReadOnly = True
        '
        'GridColumn65
        '
        Me.GridColumn65.FieldName = "ClientGroupName"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.OptionsColumn.AllowEdit = False
        Me.GridColumn65.OptionsColumn.ReadOnly = True
        Me.GridColumn65.Width = 78
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "Maturity(without cap, floor)"
        Me.GridColumn66.FieldName = "MaturityWithoutCapFloor"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.OptionsColumn.AllowEdit = False
        Me.GridColumn66.OptionsColumn.ReadOnly = True
        Me.GridColumn66.ToolTip = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" &
    "m else Maturity Date-RiskDate/365,25"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 21
        Me.GridColumn66.Width = 145
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "EaD weighted maturity (without cap, floor)"
        Me.GridColumn67.DisplayFormat.FormatString = "n2"
        Me.GridColumn67.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn67.FieldName = "EaDweigthedMaturityWithoutCapFloor"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.OptionsColumn.AllowEdit = False
        Me.GridColumn67.OptionsColumn.ReadOnly = True
        Me.GridColumn67.ToolTip = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 22
        Me.GridColumn67.Width = 230
        '
        'GridColumn68
        '
        Me.GridColumn68.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn68.Caption = "PD * Final EaD"
        Me.GridColumn68.DisplayFormat.FormatString = "n2"
        Me.GridColumn68.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn68.FieldName = "PDxFinalEaD"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.OptionsColumn.AllowEdit = False
        Me.GridColumn68.OptionsColumn.ReadOnly = True
        Me.GridColumn68.ToolTip = "PD * Net Credit outstanding Amount EUR"
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 23
        Me.GridColumn68.Width = 108
        '
        'GridColumn69
        '
        Me.GridColumn69.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.Caption = "LGD (final EaD weigthed)"
        Me.GridColumn69.DisplayFormat.FormatString = "n2"
        Me.GridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn69.FieldName = "LGDfinalEaDweighted"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.OptionsColumn.AllowEdit = False
        Me.GridColumn69.OptionsColumn.ReadOnly = True
        Me.GridColumn69.ToolTip = "(ER2) * Net Credit Outstanding Amount EUR"
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 24
        Me.GridColumn69.Width = 154
        '
        'GridColumn70
        '
        Me.GridColumn70.FieldName = "RiskDate"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.OptionsColumn.AllowEdit = False
        Me.GridColumn70.OptionsColumn.ReadOnly = True
        Me.GridColumn70.Width = 93
        '
        'RepositoryItemImageComboBox3
        '
        Me.RepositoryItemImageComboBox3.AutoHeight = False
        Me.RepositoryItemImageComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A - ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "C - CLOSE ", 3)})
        Me.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3"
        '
        'RepositoryItemImageComboBox4
        '
        Me.RepositoryItemImageComboBox4.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox4.AutoHeight = False
        Me.RepositoryItemImageComboBox4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox4.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox4.Name = "RepositoryItemImageComboBox4"
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink_AllDates, Me.PrintableComponentLink_SingleDate})
        '
        'PrintableComponentLink_AllDates
        '
        Me.PrintableComponentLink_AllDates.Component = Me.CSR_AllDates_GridControl
        Me.PrintableComponentLink_AllDates.Landscape = True
        Me.PrintableComponentLink_AllDates.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink_AllDates.PrintingSystemBase = Me.PrintingSystem1
        '
        'CSR_AllDates_GridControl
        '
        Me.CSR_AllDates_GridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CSR_AllDates_GridControl.DataSource = Me.CreditMigrationRisk_DATEBindingSource
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.CSR_AllDates_GridControl.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 16, True, False, "Neue EAEG Stichtag erstellung", "NeuStichtag")})
        Me.CSR_AllDates_GridControl.Location = New System.Drawing.Point(24, 24)
        Me.CSR_AllDates_GridControl.MainView = Me.CMR_AllDates_GridView
        Me.CSR_AllDates_GridControl.Name = "CSR_AllDates_GridControl"
        Me.CSR_AllDates_GridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1})
        Me.CSR_AllDates_GridControl.Size = New System.Drawing.Size(1623, 20)
        Me.CSR_AllDates_GridControl.TabIndex = 6
        Me.CSR_AllDates_GridControl.UseEmbeddedNavigator = True
        Me.CSR_AllDates_GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CMR_AllDates_GridView})
        '
        'CreditMigrationRisk_DATEBindingSource
        '
        Me.CreditMigrationRisk_DATEBindingSource.DataMember = "CreditMigrationRisk_DATE"
        Me.CreditMigrationRisk_DATEBindingSource.DataSource = Me.CreditMigrationRiskDataSet
        '
        'CMR_AllDates_GridView
        '
        Me.CMR_AllDates_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CMR_AllDates_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CMR_AllDates_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CMR_AllDates_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CMR_AllDates_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CMR_AllDates_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.CMR_AllDates_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CMR_AllDates_GridView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.CMR_AllDates_GridView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colID2, Me.colCreditMigrationRisk, Me.colRiskDate})
        Me.CMR_AllDates_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CMR_AllDates_GridView.GridControl = Me.CSR_AllDates_GridControl
        Me.CMR_AllDates_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumEURequ", Nothing, "{0:n2}", "1"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmount", Nothing, "{0:n2}", "2"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountTill1Jear", Nothing, "{0:n2}", "3"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver1Till2Years", Nothing, "{0:n2}", "4"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver2Years", Nothing, "{0:n2}", "5")})
        Me.CMR_AllDates_GridView.Name = "CMR_AllDates_GridView"
        Me.CMR_AllDates_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CMR_AllDates_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CMR_AllDates_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CMR_AllDates_GridView.OptionsBehavior.Editable = False
        Me.CMR_AllDates_GridView.OptionsBehavior.ReadOnly = True
        Me.CMR_AllDates_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CMR_AllDates_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CMR_AllDates_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CMR_AllDates_GridView.OptionsFind.AlwaysVisible = True
        Me.CMR_AllDates_GridView.OptionsPrint.PrintDetails = True
        Me.CMR_AllDates_GridView.OptionsSelection.MultiSelect = True
        Me.CMR_AllDates_GridView.OptionsView.ColumnAutoWidth = False
        Me.CMR_AllDates_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_AllDates_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.CMR_AllDates_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CMR_AllDates_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CMR_AllDates_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CMR_AllDates_GridView.OptionsView.ShowFooter = True
        Me.CMR_AllDates_GridView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Basic Data"
        Me.GridBand1.Columns.Add(Me.colID2)
        Me.GridBand1.Columns.Add(Me.colRiskDate)
        Me.GridBand1.Columns.Add(Me.colCreditMigrationRisk)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.OptionsBand.AllowSize = False
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 238
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        '
        'colRiskDate
        '
        Me.colRiskDate.Caption = "Business Dates"
        Me.colRiskDate.DisplayFormat.FormatString = "d"
        Me.colRiskDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.Visible = True
        Me.colRiskDate.Width = 106
        '
        'colCreditMigrationRisk
        '
        Me.colCreditMigrationRisk.Caption = "Credit Migration Risk"
        Me.colCreditMigrationRisk.DisplayFormat.FormatString = "n0"
        Me.colCreditMigrationRisk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditMigrationRisk.FieldName = "CreditMigrationRisk"
        Me.colCreditMigrationRisk.Name = "colCreditMigrationRisk"
        Me.colCreditMigrationRisk.Visible = True
        Me.colCreditMigrationRisk.Width = 132
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemComboBox2.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.AppearanceDropDown.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.AppearanceDropDown.Options.UseForeColor = True
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
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit3.Mask.BeepOnError = True
        Me.RepositoryItemTextEdit3.Mask.EditMask = "[A-Z]{6}[1-9A-Z]{2}"
        Me.RepositoryItemTextEdit3.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.Mask.EditMask = "[1-9A-Z]{3}"
        Me.RepositoryItemTextEdit4.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AllowFocused = False
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
        '
        'PrintableComponentLink_SingleDate
        '
        Me.PrintableComponentLink_SingleDate.Component = Me.LayoutControl1
        Me.PrintableComponentLink_SingleDate.Landscape = True
        Me.PrintableComponentLink_SingleDate.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink_SingleDate.PrintingSystemBase = Me.PrintingSystem1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CMR_Groups_GridControl)
        Me.LayoutControl1.Controls.Add(Me.CMR_Totals_GridControl)
        Me.LayoutControl1.Controls.Add(Me.GroupControl2)
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.CMR_Details_GridControl)
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6, Me.LayoutControlGroup4})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 158)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(475, 100, 861, 628)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1861, 893)
        Me.LayoutControl1.TabIndex = 10
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CMR_Groups_GridControl
        '
        Me.CMR_Groups_GridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMR_Groups_GridControl.DataSource = Me.CreditMigrationRisk_GroupsBindingSource
        Me.CMR_Groups_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.CMR_Groups_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.CMR_Groups_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.CMR_Groups_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.CMR_Groups_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.CMR_Groups_GridControl.Location = New System.Drawing.Point(24, 369)
        Me.CMR_Groups_GridControl.MainView = Me.CMR_Groups_GridView
        Me.CMR_Groups_GridControl.Name = "CMR_Groups_GridControl"
        Me.CMR_Groups_GridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox9, Me.RepositoryItemImageComboBox10})
        Me.CMR_Groups_GridControl.Size = New System.Drawing.Size(1813, 500)
        Me.CMR_Groups_GridControl.TabIndex = 30
        Me.CMR_Groups_GridControl.ToolTipController = Me.ToolTipController1
        Me.CMR_Groups_GridControl.UseEmbeddedNavigator = True
        Me.CMR_Groups_GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CMR_Groups_GridView})
        '
        'CreditMigrationRisk_GroupsBindingSource
        '
        Me.CreditMigrationRisk_GroupsBindingSource.DataMember = "CreditMigrationRisk_Groups"
        Me.CreditMigrationRisk_GroupsBindingSource.DataSource = Me.CreditMigrationRiskDataSet
        '
        'CMR_Groups_GridView
        '
        Me.CMR_Groups_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CMR_Groups_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CMR_Groups_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CMR_Groups_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CMR_Groups_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CMR_Groups_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CMR_Groups_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CMR_Groups_GridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CMR_Groups_GridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMR_Groups_GridView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.CMR_Groups_GridView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.CMR_Groups_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colDowngradeStatus1, Me.colClientGroup, Me.colClientGroupName, Me.colSubBorrowersCounter, Me.colFinalEadTotalSum, Me.colLGD, Me.colPD_EaD_weighted, Me.colPD_3bps_floor, Me.colIndicatorOfFloor, Me.colMaturityEADweigthed, Me.colR_CoefficientOfColleration, Me.colb_MaturityAdjustment, Me.colRW_RiskWeightedExposure, Me.colUL_UnexpectedLoss, Me.GridColumn1, Me.colSi, Me.colKi, Me.colRi, Me.colVLGDi, Me.colCi, Me.colGAn})
        Me.CMR_Groups_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CMR_Groups_GridView.GridControl = Me.CMR_Groups_GridControl
        Me.CMR_Groups_GridView.GroupCount = 1
        Me.CMR_Groups_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FinalEadTotalSum", Nothing, "Sum Final EAD Total Sum={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UL_UnexpectedLoss", Nothing, "Unexpected Loss={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubBorrowersCounter", Nothing, "Total Count={0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GA_n", Nothing, "GA rel={0:n12}")})
        Me.CMR_Groups_GridView.Name = "CMR_Groups_GridView"
        Me.CMR_Groups_GridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Groups_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CMR_Groups_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CMR_Groups_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CMR_Groups_GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.CMR_Groups_GridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.CMR_Groups_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CMR_Groups_GridView.OptionsFind.AlwaysVisible = True
        Me.CMR_Groups_GridView.OptionsFind.SearchInPreview = True
        Me.CMR_Groups_GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Groups_GridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.CMR_Groups_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CMR_Groups_GridView.OptionsSelection.MultiSelect = True
        Me.CMR_Groups_GridView.OptionsView.ColumnAutoWidth = False
        Me.CMR_Groups_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Groups_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CMR_Groups_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CMR_Groups_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CMR_Groups_GridView.OptionsView.ShowFooter = True
        Me.CMR_Groups_GridView.OptionsView.ShowGroupedColumns = True
        Me.CMR_Groups_GridView.OptionsView.ShowGroupPanel = False
        Me.CMR_Groups_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDowngradeStatus1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colDowngradeStatus1
        '
        Me.colDowngradeStatus1.FieldName = "DowngradeStatus"
        Me.colDowngradeStatus1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colDowngradeStatus1.Name = "colDowngradeStatus1"
        Me.colDowngradeStatus1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.colDowngradeStatus1.Visible = True
        Me.colDowngradeStatus1.VisibleIndex = 0
        Me.colDowngradeStatus1.Width = 234
        '
        'colClientGroup
        '
        Me.colClientGroup.AppearanceCell.Options.UseTextOptions = True
        Me.colClientGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientGroup.FieldName = "ClientGroup"
        Me.colClientGroup.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientGroup.Name = "colClientGroup"
        Me.colClientGroup.OptionsColumn.AllowEdit = False
        Me.colClientGroup.OptionsColumn.ReadOnly = True
        Me.colClientGroup.Visible = True
        Me.colClientGroup.VisibleIndex = 1
        Me.colClientGroup.Width = 173
        '
        'colClientGroupName
        '
        Me.colClientGroupName.FieldName = "ClientGroupName"
        Me.colClientGroupName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientGroupName.Name = "colClientGroupName"
        Me.colClientGroupName.OptionsColumn.AllowEdit = False
        Me.colClientGroupName.OptionsColumn.ReadOnly = True
        Me.colClientGroupName.Visible = True
        Me.colClientGroupName.VisibleIndex = 2
        Me.colClientGroupName.Width = 287
        '
        'colSubBorrowersCounter
        '
        Me.colSubBorrowersCounter.AppearanceCell.Options.UseTextOptions = True
        Me.colSubBorrowersCounter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSubBorrowersCounter.DisplayFormat.FormatString = "n0"
        Me.colSubBorrowersCounter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSubBorrowersCounter.FieldName = "SubBorrowersCounter"
        Me.colSubBorrowersCounter.Name = "colSubBorrowersCounter"
        Me.colSubBorrowersCounter.OptionsColumn.AllowEdit = False
        Me.colSubBorrowersCounter.OptionsColumn.ReadOnly = True
        Me.colSubBorrowersCounter.ToolTip = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
        Me.colSubBorrowersCounter.Visible = True
        Me.colSubBorrowersCounter.VisibleIndex = 3
        Me.colSubBorrowersCounter.Width = 125
        '
        'colFinalEadTotalSum
        '
        Me.colFinalEadTotalSum.AppearanceCell.Options.UseTextOptions = True
        Me.colFinalEadTotalSum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colFinalEadTotalSum.Caption = "Final EaD (Total Sum for Each Group)"
        Me.colFinalEadTotalSum.DisplayFormat.FormatString = "n2"
        Me.colFinalEadTotalSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colFinalEadTotalSum.FieldName = "FinalEadTotalSum"
        Me.colFinalEadTotalSum.Name = "colFinalEadTotalSum"
        Me.colFinalEadTotalSum.OptionsColumn.AllowEdit = False
        Me.colFinalEadTotalSum.OptionsColumn.ReadOnly = True
        Me.colFinalEadTotalSum.ToolTip = "Sum of Net credit outstanding amount for each Client Group"
        Me.colFinalEadTotalSum.Visible = True
        Me.colFinalEadTotalSum.VisibleIndex = 4
        Me.colFinalEadTotalSum.Width = 188
        '
        'colLGD
        '
        Me.colLGD.AppearanceCell.Options.UseTextOptions = True
        Me.colLGD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLGD.DisplayFormat.FormatString = "p2"
        Me.colLGD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLGD.FieldName = "LGD"
        Me.colLGD.Name = "colLGD"
        Me.colLGD.OptionsColumn.AllowEdit = False
        Me.colLGD.OptionsColumn.ReadOnly = True
        Me.colLGD.ToolTip = "from (ER1)"
        Me.colLGD.Visible = True
        Me.colLGD.VisibleIndex = 5
        Me.colLGD.Width = 63
        '
        'colPD_EaD_weighted
        '
        Me.colPD_EaD_weighted.AppearanceCell.Options.UseTextOptions = True
        Me.colPD_EaD_weighted.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPD_EaD_weighted.Caption = "PD (EaD weigthed)"
        Me.colPD_EaD_weighted.DisplayFormat.FormatString = "n5"
        Me.colPD_EaD_weighted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPD_EaD_weighted.FieldName = "PD_EaD_weighted"
        Me.colPD_EaD_weighted.Name = "colPD_EaD_weighted"
        Me.colPD_EaD_weighted.OptionsColumn.AllowEdit = False
        Me.colPD_EaD_weighted.OptionsColumn.ReadOnly = True
        Me.colPD_EaD_weighted.ToolTip = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credi" &
    "t outstanding Amount for each Client Group"
        Me.colPD_EaD_weighted.Visible = True
        Me.colPD_EaD_weighted.VisibleIndex = 6
        Me.colPD_EaD_weighted.Width = 101
        '
        'colPD_3bps_floor
        '
        Me.colPD_3bps_floor.AppearanceCell.Options.UseTextOptions = True
        Me.colPD_3bps_floor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPD_3bps_floor.Caption = "PD (3bps floor)"
        Me.colPD_3bps_floor.DisplayFormat.FormatString = "n5"
        Me.colPD_3bps_floor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPD_3bps_floor.FieldName = "PD_3bps_floor"
        Me.colPD_3bps_floor.Name = "colPD_3bps_floor"
        Me.colPD_3bps_floor.OptionsColumn.AllowEdit = False
        Me.colPD_3bps_floor.OptionsColumn.ReadOnly = True
        Me.colPD_3bps_floor.ToolTip = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)" &
    ""
        Me.colPD_3bps_floor.Visible = True
        Me.colPD_3bps_floor.VisibleIndex = 7
        Me.colPD_3bps_floor.Width = 92
        '
        'colIndicatorOfFloor
        '
        Me.colIndicatorOfFloor.AppearanceCell.Options.UseTextOptions = True
        Me.colIndicatorOfFloor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colIndicatorOfFloor.FieldName = "IndicatorOfFloor"
        Me.colIndicatorOfFloor.Name = "colIndicatorOfFloor"
        Me.colIndicatorOfFloor.OptionsColumn.AllowEdit = False
        Me.colIndicatorOfFloor.OptionsColumn.ReadOnly = True
        Me.colIndicatorOfFloor.ToolTip = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
        Me.colIndicatorOfFloor.Visible = True
        Me.colIndicatorOfFloor.VisibleIndex = 8
        Me.colIndicatorOfFloor.Width = 96
        '
        'colMaturityEADweigthed
        '
        Me.colMaturityEADweigthed.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityEADweigthed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colMaturityEADweigthed.Caption = "Maturity (EaD weigthed)"
        Me.colMaturityEADweigthed.FieldName = "MaturityEADweigthed"
        Me.colMaturityEADweigthed.Name = "colMaturityEADweigthed"
        Me.colMaturityEADweigthed.OptionsColumn.AllowEdit = False
        Me.colMaturityEADweigthed.OptionsColumn.ReadOnly = True
        Me.colMaturityEADweigthed.ToolTip = "Variable 1: Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)" &
    "-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and V" &
    "ariable 2"
        Me.colMaturityEADweigthed.Visible = True
        Me.colMaturityEADweigthed.VisibleIndex = 9
        Me.colMaturityEADweigthed.Width = 136
        '
        'colR_CoefficientOfColleration
        '
        Me.colR_CoefficientOfColleration.AppearanceCell.Options.UseTextOptions = True
        Me.colR_CoefficientOfColleration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colR_CoefficientOfColleration.Caption = "R (Coefficient Of Colleration)"
        Me.colR_CoefficientOfColleration.DisplayFormat.FormatString = "n15"
        Me.colR_CoefficientOfColleration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colR_CoefficientOfColleration.FieldName = "R_CoefficientOfColleration"
        Me.colR_CoefficientOfColleration.Name = "colR_CoefficientOfColleration"
        Me.colR_CoefficientOfColleration.OptionsColumn.AllowEdit = False
        Me.colR_CoefficientOfColleration.OptionsColumn.ReadOnly = True
        Me.colR_CoefficientOfColleration.ToolTip = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where" &
    " EXP=e=2.71828182845904"
        Me.colR_CoefficientOfColleration.Visible = True
        Me.colR_CoefficientOfColleration.VisibleIndex = 10
        Me.colR_CoefficientOfColleration.Width = 153
        '
        'colb_MaturityAdjustment
        '
        Me.colb_MaturityAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.colb_MaturityAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colb_MaturityAdjustment.Caption = "b (Maturity Adjustment)"
        Me.colb_MaturityAdjustment.DisplayFormat.FormatString = "n15"
        Me.colb_MaturityAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colb_MaturityAdjustment.FieldName = "b_MaturityAdjustment"
        Me.colb_MaturityAdjustment.Name = "colb_MaturityAdjustment"
        Me.colb_MaturityAdjustment.OptionsColumn.AllowEdit = False
        Me.colb_MaturityAdjustment.OptionsColumn.ReadOnly = True
        Me.colb_MaturityAdjustment.ToolTip = "b=(0,11852-0,05478*Log(PD))^2"
        Me.colb_MaturityAdjustment.Visible = True
        Me.colb_MaturityAdjustment.VisibleIndex = 11
        Me.colb_MaturityAdjustment.Width = 128
        '
        'colRW_RiskWeightedExposure
        '
        Me.colRW_RiskWeightedExposure.AppearanceCell.Options.UseTextOptions = True
        Me.colRW_RiskWeightedExposure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colRW_RiskWeightedExposure.Caption = "RW (Risk weigthed Exposure)"
        Me.colRW_RiskWeightedExposure.DisplayFormat.FormatString = "n15"
        Me.colRW_RiskWeightedExposure.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colRW_RiskWeightedExposure.FieldName = "RW_RiskWeightedExposure"
        Me.colRW_RiskWeightedExposure.Name = "colRW_RiskWeightedExposure"
        Me.colRW_RiskWeightedExposure.OptionsColumn.AllowEdit = False
        Me.colRW_RiskWeightedExposure.OptionsColumn.ReadOnly = True
        Me.colRW_RiskWeightedExposure.ToolTip = resources.GetString("colRW_RiskWeightedExposure.ToolTip")
        Me.colRW_RiskWeightedExposure.Visible = True
        Me.colRW_RiskWeightedExposure.VisibleIndex = 12
        Me.colRW_RiskWeightedExposure.Width = 157
        '
        'colUL_UnexpectedLoss
        '
        Me.colUL_UnexpectedLoss.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colUL_UnexpectedLoss.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colUL_UnexpectedLoss.AppearanceCell.ForeColor = System.Drawing.Color.Black
        Me.colUL_UnexpectedLoss.AppearanceCell.Options.UseBackColor = True
        Me.colUL_UnexpectedLoss.AppearanceCell.Options.UseForeColor = True
        Me.colUL_UnexpectedLoss.AppearanceCell.Options.UseTextOptions = True
        Me.colUL_UnexpectedLoss.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colUL_UnexpectedLoss.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colUL_UnexpectedLoss.AppearanceHeader.Options.UseFont = True
        Me.colUL_UnexpectedLoss.Caption = "UL (Unexpected Loss)"
        Me.colUL_UnexpectedLoss.DisplayFormat.FormatString = "n2"
        Me.colUL_UnexpectedLoss.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colUL_UnexpectedLoss.FieldName = "UL_UnexpectedLoss"
        Me.colUL_UnexpectedLoss.Name = "colUL_UnexpectedLoss"
        Me.colUL_UnexpectedLoss.OptionsColumn.AllowEdit = False
        Me.colUL_UnexpectedLoss.OptionsColumn.ReadOnly = True
        Me.colUL_UnexpectedLoss.ToolTip = "RW*Final EaD*8,00%"
        Me.colUL_UnexpectedLoss.Visible = True
        Me.colUL_UnexpectedLoss.VisibleIndex = 13
        Me.colUL_UnexpectedLoss.Width = 150
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "RiskDate"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'colSi
        '
        Me.colSi.AppearanceCell.Options.UseTextOptions = True
        Me.colSi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSi.Caption = "s_i"
        Me.colSi.DisplayFormat.FormatString = "n10"
        Me.colSi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSi.FieldName = "s_i"
        Me.colSi.Name = "colSi"
        Me.colSi.OptionsColumn.AllowEdit = False
        Me.colSi.OptionsColumn.ReadOnly = True
        Me.colSi.ToolTip = "Final EAD/Sum Final EaD"
        Me.colSi.Visible = True
        Me.colSi.VisibleIndex = 14
        Me.colSi.Width = 106
        '
        'colKi
        '
        Me.colKi.AppearanceCell.Options.UseTextOptions = True
        Me.colKi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colKi.Caption = "K_i"
        Me.colKi.DisplayFormat.FormatString = "n10"
        Me.colKi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colKi.FieldName = "K_i"
        Me.colKi.Name = "colKi"
        Me.colKi.OptionsColumn.AllowEdit = False
        Me.colKi.OptionsColumn.ReadOnly = True
        Me.colKi.ToolTip = "Unexpected Loss/Final EaD"
        Me.colKi.Visible = True
        Me.colKi.VisibleIndex = 15
        Me.colKi.Width = 113
        '
        'colRi
        '
        Me.colRi.AppearanceCell.Options.UseTextOptions = True
        Me.colRi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colRi.Caption = "R_i"
        Me.colRi.FieldName = "R_i"
        Me.colRi.Name = "colRi"
        Me.colRi.OptionsColumn.AllowEdit = False
        Me.colRi.OptionsColumn.ReadOnly = True
        Me.colRi.ToolTip = "LGD * PD"
        Me.colRi.Visible = True
        Me.colRi.VisibleIndex = 16
        Me.colRi.Width = 102
        '
        'colVLGDi
        '
        Me.colVLGDi.AppearanceCell.Options.UseTextOptions = True
        Me.colVLGDi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colVLGDi.Caption = "VLGD_i"
        Me.colVLGDi.FieldName = "VLGD_i"
        Me.colVLGDi.Name = "colVLGDi"
        Me.colVLGDi.OptionsColumn.AllowEdit = False
        Me.colVLGDi.OptionsColumn.ReadOnly = True
        Me.colVLGDi.ToolTip = "nü value * LGD * (1 - LGD)"
        Me.colVLGDi.Visible = True
        Me.colVLGDi.VisibleIndex = 17
        Me.colVLGDi.Width = 101
        '
        'colCi
        '
        Me.colCi.AppearanceCell.Options.UseTextOptions = True
        Me.colCi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCi.Caption = "C_i"
        Me.colCi.FieldName = "C_i"
        Me.colCi.Name = "colCi"
        Me.colCi.OptionsColumn.AllowEdit = False
        Me.colCi.OptionsColumn.ReadOnly = True
        Me.colCi.ToolTip = "Power(LGD,2) + VLGD/LGD"
        Me.colCi.Visible = True
        Me.colCi.VisibleIndex = 18
        Me.colCi.Width = 107
        '
        'colGAn
        '
        Me.colGAn.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colGAn.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colGAn.AppearanceCell.ForeColor = System.Drawing.Color.Black
        Me.colGAn.AppearanceCell.Options.UseBackColor = True
        Me.colGAn.AppearanceCell.Options.UseForeColor = True
        Me.colGAn.AppearanceCell.Options.UseTextOptions = True
        Me.colGAn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colGAn.Caption = "GA_n Related"
        Me.colGAn.DisplayFormat.FormatString = "n12"
        Me.colGAn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colGAn.FieldName = "GA_n"
        Me.colGAn.Name = "colGAn"
        Me.colGAn.OptionsColumn.AllowEdit = False
        Me.colGAn.OptionsColumn.ReadOnly = True
        Me.colGAn.ToolTip = "S_i^2*(  (Delta*C_i*(K_i+R_i) +Delta* (K_i+R_i)^2 * (VLGD^2)/(LGD^2) )  - K_i*( C" &
    "_i+2* (K_i+R_i) * (VLGD^2)/(LGD^2)  ) "
        Me.colGAn.Visible = True
        Me.colGAn.VisibleIndex = 19
        Me.colGAn.Width = 140
        '
        'RepositoryItemImageComboBox9
        '
        Me.RepositoryItemImageComboBox9.AutoHeight = False
        Me.RepositoryItemImageComboBox9.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox9.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox9.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A - ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "C - CLOSE ", 3)})
        Me.RepositoryItemImageComboBox9.Name = "RepositoryItemImageComboBox9"
        '
        'RepositoryItemImageComboBox10
        '
        Me.RepositoryItemImageComboBox10.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox10.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox10.AutoHeight = False
        Me.RepositoryItemImageComboBox10.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox10.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox10.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox10.Name = "RepositoryItemImageComboBox10"
        '
        'CMR_Totals_GridControl
        '
        Me.CMR_Totals_GridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMR_Totals_GridControl.DataSource = Me.CreditMigrationRisk_TotalsBindingSource
        Me.CMR_Totals_GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.CMR_Totals_GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.CMR_Totals_GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.CMR_Totals_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.CMR_Totals_GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.CMR_Totals_GridControl.Location = New System.Drawing.Point(332, 12)
        Me.CMR_Totals_GridControl.MainView = Me.CMR_Totals_GridView
        Me.CMR_Totals_GridControl.Name = "CMR_Totals_GridControl"
        Me.CMR_Totals_GridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox5, Me.RepositoryItemImageComboBox6})
        Me.CMR_Totals_GridControl.Size = New System.Drawing.Size(1517, 310)
        Me.CMR_Totals_GridControl.TabIndex = 30
        Me.CMR_Totals_GridControl.ToolTipController = Me.ToolTipController1
        Me.CMR_Totals_GridControl.UseEmbeddedNavigator = True
        Me.CMR_Totals_GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CMR_Totals_GridView})
        '
        'CreditMigrationRisk_TotalsBindingSource
        '
        Me.CreditMigrationRisk_TotalsBindingSource.DataMember = "CreditMigrationRisk_Totals"
        Me.CreditMigrationRisk_TotalsBindingSource.DataSource = Me.CreditMigrationRiskDataSet
        '
        'CMR_Totals_GridView
        '
        Me.CMR_Totals_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CMR_Totals_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CMR_Totals_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CMR_Totals_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CMR_Totals_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CMR_Totals_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID3, Me.colDowngradeStatus, Me.colLevelOfConfidence, Me.colSumEL, Me.colSumUL, Me.colSummeFinalEADTotalSum, Me.colnu_Value, Me.colp_alpha_Value, Me.colb_beta_value, Me.colGamma_inv, Me.colDelta, Me.colK_Value, Me.colSumGA_rel, Me.colSumGA_Total, Me.colTotalRisk, Me.colRiskAdjustment, Me.colTotalRisk_Adjusted, Me.colImpactOnTotalRisk, Me.colPropability, Me.colExpectedValue, Me.colRiskDate1})
        Me.CMR_Totals_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.colExpectedValue
        GridFormatRule1.ColumnApplyTo = Me.colExpectedValue
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue1.Value1 = 0R
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "Y"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.CMR_Totals_GridView.FormatRules.Add(GridFormatRule1)
        Me.CMR_Totals_GridView.FormatRules.Add(GridFormatRule2)
        Me.CMR_Totals_GridView.GridControl = Me.CMR_Totals_GridControl
        Me.CMR_Totals_GridView.Name = "CMR_Totals_GridView"
        Me.CMR_Totals_GridView.OptionsBehavior.ReadOnly = True
        Me.CMR_Totals_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CMR_Totals_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.CMR_Totals_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CMR_Totals_GridView.OptionsFind.AlwaysVisible = True
        Me.CMR_Totals_GridView.OptionsPrint.PrintDetails = True
        Me.CMR_Totals_GridView.OptionsPrint.PrintFilterInfo = True
        Me.CMR_Totals_GridView.OptionsSelection.MultiSelect = True
        Me.CMR_Totals_GridView.OptionsView.ColumnAutoWidth = False
        Me.CMR_Totals_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CMR_Totals_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CMR_Totals_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CMR_Totals_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CMR_Totals_GridView.OptionsView.ShowFooter = True
        Me.CMR_Totals_GridView.OptionsView.ShowGroupPanel = False
        Me.CMR_Totals_GridView.OptionsView.ShowViewCaption = True
        Me.CMR_Totals_GridView.ViewCaption = "Expected, Unexpected Loss and Granularity Approach (for all Downgrade Notches)"
        '
        'colID3
        '
        Me.colID3.FieldName = "ID"
        Me.colID3.Name = "colID3"
        '
        'colDowngradeStatus
        '
        Me.colDowngradeStatus.FieldName = "DowngradeStatus"
        Me.colDowngradeStatus.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colDowngradeStatus.Name = "colDowngradeStatus"
        Me.colDowngradeStatus.Visible = True
        Me.colDowngradeStatus.VisibleIndex = 0
        Me.colDowngradeStatus.Width = 215
        '
        'colLevelOfConfidence
        '
        Me.colLevelOfConfidence.DisplayFormat.FormatString = "p2"
        Me.colLevelOfConfidence.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLevelOfConfidence.FieldName = "LevelOfConfidence"
        Me.colLevelOfConfidence.Name = "colLevelOfConfidence"
        Me.colLevelOfConfidence.Width = 102
        '
        'colSumEL
        '
        Me.colSumEL.Caption = "Expected Loss"
        Me.colSumEL.DisplayFormat.FormatString = "n2"
        Me.colSumEL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSumEL.FieldName = "SumEL"
        Me.colSumEL.Name = "colSumEL"
        Me.colSumEL.Visible = True
        Me.colSumEL.VisibleIndex = 1
        Me.colSumEL.Width = 126
        '
        'colSumUL
        '
        Me.colSumUL.Caption = "Unexpected Loss"
        Me.colSumUL.DisplayFormat.FormatString = "n2"
        Me.colSumUL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSumUL.FieldName = "SumUL"
        Me.colSumUL.Name = "colSumUL"
        Me.colSumUL.Visible = True
        Me.colSumUL.VisibleIndex = 2
        Me.colSumUL.Width = 122
        '
        'colSummeFinalEADTotalSum
        '
        Me.colSummeFinalEADTotalSum.Caption = "Final EAD Total Sum (SUM)"
        Me.colSummeFinalEADTotalSum.DisplayFormat.FormatString = "n2"
        Me.colSummeFinalEADTotalSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSummeFinalEADTotalSum.FieldName = "SummeFinalEADTotalSum"
        Me.colSummeFinalEADTotalSum.Name = "colSummeFinalEADTotalSum"
        Me.colSummeFinalEADTotalSum.ToolTip = "Sum of Net Credit Outstanding Amount (all Groups) for each Downgrade Status"
        Me.colSummeFinalEADTotalSum.Width = 130
        '
        'colnu_Value
        '
        Me.colnu_Value.Caption = "γ (nü)"
        Me.colnu_Value.DisplayFormat.FormatString = "n2"
        Me.colnu_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colnu_Value.FieldName = "nu_Value"
        Me.colnu_Value.Name = "colnu_Value"
        Me.colnu_Value.Width = 101
        '
        'colp_alpha_Value
        '
        Me.colp_alpha_Value.Caption = "p alpha value"
        Me.colp_alpha_Value.DisplayFormat.FormatString = "n2"
        Me.colp_alpha_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colp_alpha_Value.FieldName = "p_alpha_Value"
        Me.colp_alpha_Value.Name = "colp_alpha_Value"
        Me.colp_alpha_Value.Width = 94
        '
        'colb_beta_value
        '
        Me.colb_beta_value.Caption = "b beta value"
        Me.colb_beta_value.DisplayFormat.FormatString = "n2"
        Me.colb_beta_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colb_beta_value.FieldName = "b_beta_value"
        Me.colb_beta_value.Name = "colb_beta_value"
        Me.colb_beta_value.Width = 99
        '
        'colGamma_inv
        '
        Me.colGamma_inv.Caption = "GAMMAINV Value"
        Me.colGamma_inv.DisplayFormat.FormatString = "n10"
        Me.colGamma_inv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colGamma_inv.FieldName = "Gamma_inv"
        Me.colGamma_inv.Name = "colGamma_inv"
        Me.colGamma_inv.ToolTip = "GAMMAINV (p, alpha, 1/beta), p=Level of Confidence, Returns the inverse of the ga" &
    "mma comulative distribution"
        Me.colGamma_inv.Width = 139
        '
        'colDelta
        '
        Me.colDelta.Caption = "Delta Value"
        Me.colDelta.DisplayFormat.FormatString = "n10"
        Me.colDelta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDelta.FieldName = "Delta"
        Me.colDelta.Name = "colDelta"
        Me.colDelta.ToolTip = "Calculated as: (GAMMAINV-1)*(p_alpha_value +1(1 - p_alpha_value)/GAMMAINV)"
        Me.colDelta.Width = 156
        '
        'colK_Value
        '
        Me.colK_Value.Caption = "K Value"
        Me.colK_Value.DisplayFormat.FormatString = "n10"
        Me.colK_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colK_Value.FieldName = "K_Value"
        Me.colK_Value.Name = "colK_Value"
        Me.colK_Value.ToolTip = "Sum of (s_i * K_i)"
        Me.colK_Value.Width = 150
        '
        'colSumGA_rel
        '
        Me.colSumGA_rel.Caption = "Sum GA_n Related"
        Me.colSumGA_rel.DisplayFormat.FormatString = "n12"
        Me.colSumGA_rel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSumGA_rel.FieldName = "SumGA_rel"
        Me.colSumGA_rel.Name = "colSumGA_rel"
        Me.colSumGA_rel.ToolTip = "Sum of GA rel/2 * K Value"
        Me.colSumGA_rel.Width = 138
        '
        'colSumGA_Total
        '
        Me.colSumGA_Total.Caption = "Granularity Approach"
        Me.colSumGA_Total.DisplayFormat.FormatString = "n2"
        Me.colSumGA_Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSumGA_Total.FieldName = "SumGA_Total"
        Me.colSumGA_Total.Name = "colSumGA_Total"
        Me.colSumGA_Total.Visible = True
        Me.colSumGA_Total.VisibleIndex = 3
        Me.colSumGA_Total.Width = 123
        '
        'colTotalRisk
        '
        Me.colTotalRisk.Caption = "Total Risk"
        Me.colTotalRisk.DisplayFormat.FormatString = "n2"
        Me.colTotalRisk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTotalRisk.FieldName = "TotalRisk"
        Me.colTotalRisk.Name = "colTotalRisk"
        Me.colTotalRisk.ToolTip = "Expected Loss + Unexpected Loss + Granularity Approach"
        Me.colTotalRisk.Visible = True
        Me.colTotalRisk.VisibleIndex = 4
        Me.colTotalRisk.Width = 131
        '
        'colRiskAdjustment
        '
        Me.colRiskAdjustment.Caption = "Risk Adjustment"
        Me.colRiskAdjustment.DisplayFormat.FormatString = "n2"
        Me.colRiskAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colRiskAdjustment.FieldName = "RiskAdjustment"
        Me.colRiskAdjustment.Name = "colRiskAdjustment"
        Me.colRiskAdjustment.ToolTip = "Sum of Credit Risk (ER2) only for Contracts with PD=1"
        Me.colRiskAdjustment.Visible = True
        Me.colRiskAdjustment.VisibleIndex = 5
        Me.colRiskAdjustment.Width = 121
        '
        'colTotalRisk_Adjusted
        '
        Me.colTotalRisk_Adjusted.Caption = "Total Risk (Adjusted)"
        Me.colTotalRisk_Adjusted.DisplayFormat.FormatString = "n2"
        Me.colTotalRisk_Adjusted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTotalRisk_Adjusted.FieldName = "TotalRisk_Adjusted"
        Me.colTotalRisk_Adjusted.Name = "colTotalRisk_Adjusted"
        Me.colTotalRisk_Adjusted.ToolTip = "Total Risk - Risk Adjustment"
        Me.colTotalRisk_Adjusted.Visible = True
        Me.colTotalRisk_Adjusted.VisibleIndex = 6
        Me.colTotalRisk_Adjusted.Width = 142
        '
        'colImpactOnTotalRisk
        '
        Me.colImpactOnTotalRisk.Caption = "Impact on Total Risk"
        Me.colImpactOnTotalRisk.DisplayFormat.FormatString = "n2"
        Me.colImpactOnTotalRisk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colImpactOnTotalRisk.FieldName = "ImpactOnTotalRisk"
        Me.colImpactOnTotalRisk.Name = "colImpactOnTotalRisk"
        Me.colImpactOnTotalRisk.ToolTip = "Total Risk (Adjusted) - BASIS Total Risk (Adjusted)"
        Me.colImpactOnTotalRisk.Visible = True
        Me.colImpactOnTotalRisk.VisibleIndex = 7
        Me.colImpactOnTotalRisk.Width = 117
        '
        'colPropability
        '
        Me.colPropability.Caption = "Probability"
        Me.colPropability.DisplayFormat.FormatString = "p2"
        Me.colPropability.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPropability.FieldName = "Propability"
        Me.colPropability.Name = "colPropability"
        Me.colPropability.ToolTip = "The calculated downgrade propability for the relevant year (see under RISK CONTRO" &
    "LING, Obligor Grades-Ratings-Downgrade Propabilities)"
        Me.colPropability.Visible = True
        Me.colPropability.VisibleIndex = 8
        Me.colPropability.Width = 94
        '
        'colRiskDate1
        '
        Me.colRiskDate1.FieldName = "RiskDate"
        Me.colRiskDate1.Name = "colRiskDate1"
        '
        'RepositoryItemImageComboBox5
        '
        Me.RepositoryItemImageComboBox5.AutoHeight = False
        Me.RepositoryItemImageComboBox5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox5.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox5.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A - ACTIVE", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "C - CLOSE ", 3)})
        Me.RepositoryItemImageComboBox5.Name = "RepositoryItemImageComboBox5"
        '
        'RepositoryItemImageComboBox6
        '
        Me.RepositoryItemImageComboBox6.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox6.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox6.AutoHeight = False
        Me.RepositoryItemImageComboBox6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox6.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox6.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox6.Name = "RepositoryItemImageComboBox6"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.Delta_TextEdit)
        Me.GroupControl2.Controls.Add(Me.GAMMAINV_TextEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.nu_Value_TextEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.p_alpha_value_TextEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.CreditMigrationRisk_TextEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.b_beta_value_TextEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl15)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.LevelOfConfidence_TextEdit)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(306, 310)
        Me.GroupControl2.TabIndex = 17
        Me.GroupControl2.Text = "Credit Migration Risk results"
        '
        'Delta_TextEdit
        '
        Me.Delta_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "Delta", True))
        Me.Delta_TextEdit.EditValue = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.Delta_TextEdit.Location = New System.Drawing.Point(138, 195)
        Me.Delta_TextEdit.Name = "Delta_TextEdit"
        Me.Delta_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Delta_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Delta_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Delta_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Delta_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.Delta_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Delta_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Delta_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Delta_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Delta_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Delta_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Delta_TextEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.Delta_TextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Delta_TextEdit.Properties.DisplayFormat.FormatString = "n10"
        Me.Delta_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Delta_TextEdit.Properties.EditFormat.FormatString = "n10"
        Me.Delta_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Delta_TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Delta_TextEdit.Properties.Mask.EditMask = "n10"
        Me.Delta_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.Delta_TextEdit.Properties.NullValuePrompt = "Please input a nummeric Value between 0 and 1"
        Me.Delta_TextEdit.Properties.ReadOnly = True
        Me.Delta_TextEdit.Size = New System.Drawing.Size(97, 20)
        Me.Delta_TextEdit.TabIndex = 35
        Me.Delta_TextEdit.ToolTip = "Calculated as follows:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(GAMMAINV-1)*(p_alpha_Value+(1-p_alpha_Value)/GAMMAINV)"
        Me.Delta_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.Delta_TextEdit.ToolTipTitle = "DELTA Value"
        '
        'GAMMAINV_TextEdit
        '
        Me.GAMMAINV_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "Gamma_inv", True))
        Me.GAMMAINV_TextEdit.EditValue = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.GAMMAINV_TextEdit.Location = New System.Drawing.Point(138, 167)
        Me.GAMMAINV_TextEdit.Name = "GAMMAINV_TextEdit"
        Me.GAMMAINV_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GAMMAINV_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.GAMMAINV_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.GAMMAINV_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.GAMMAINV_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.GAMMAINV_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.GAMMAINV_TextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GAMMAINV_TextEdit.Properties.DisplayFormat.FormatString = "n10"
        Me.GAMMAINV_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMMAINV_TextEdit.Properties.EditFormat.FormatString = "n10"
        Me.GAMMAINV_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMMAINV_TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.GAMMAINV_TextEdit.Properties.Mask.EditMask = "n10"
        Me.GAMMAINV_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.GAMMAINV_TextEdit.Properties.NullValuePrompt = "Please input a nummeric Value between 0 and 1"
        Me.GAMMAINV_TextEdit.Properties.ReadOnly = True
        Me.GAMMAINV_TextEdit.Size = New System.Drawing.Size(97, 20)
        Me.GAMMAINV_TextEdit.TabIndex = 34
        Me.GAMMAINV_TextEdit.ToolTip = "GAMMAINV(p, alpha, 1/beta)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "p=Level of Confidence" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Returns the inverse of the gam" &
    "ma " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "cumulative distribution" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.GAMMAINV_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.GAMMAINV_TextEdit.ToolTipTitle = "GAMMAINV"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Options.UseTextOptions = True
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl4.Location = New System.Drawing.Point(61, 198)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl4.TabIndex = 33
        Me.LabelControl4.Text = "(δ) Delta Value"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.Location = New System.Drawing.Point(49, 170)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl1.TabIndex = 32
        Me.LabelControl1.Text = "GAMMAINV Value"
        '
        'nu_Value_TextEdit
        '
        Me.nu_Value_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "nu_Value", True))
        Me.nu_Value_TextEdit.Location = New System.Drawing.Point(138, 110)
        Me.nu_Value_TextEdit.Name = "nu_Value_TextEdit"
        Me.nu_Value_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.nu_Value_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.nu_Value_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.nu_Value_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.nu_Value_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.nu_Value_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.nu_Value_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.nu_Value_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.nu_Value_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.nu_Value_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.nu_Value_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.nu_Value_TextEdit.Properties.Mask.EditMask = "n5"
        Me.nu_Value_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.nu_Value_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.nu_Value_TextEdit.Properties.ReadOnly = True
        Me.nu_Value_TextEdit.Size = New System.Drawing.Size(83, 20)
        Me.nu_Value_TextEdit.TabIndex = 31
        Me.nu_Value_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Options.UseTextOptions = True
        Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl3.Location = New System.Drawing.Point(102, 113)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl3.TabIndex = 30
        Me.LabelControl3.Text = "γ (nü)"
        '
        'p_alpha_value_TextEdit
        '
        Me.p_alpha_value_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "p_alpha_Value", True))
        Me.p_alpha_value_TextEdit.Location = New System.Drawing.Point(138, 84)
        Me.p_alpha_value_TextEdit.Name = "p_alpha_value_TextEdit"
        Me.p_alpha_value_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.p_alpha_value_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.p_alpha_value_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.p_alpha_value_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.p_alpha_value_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.p_alpha_value_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.p_alpha_value_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.p_alpha_value_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.p_alpha_value_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.p_alpha_value_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.p_alpha_value_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.p_alpha_value_TextEdit.Properties.DisplayFormat.FormatString = "n5"
        Me.p_alpha_value_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.p_alpha_value_TextEdit.Properties.EditFormat.FormatString = "n5"
        Me.p_alpha_value_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.p_alpha_value_TextEdit.Properties.Mask.EditMask = "n5"
        Me.p_alpha_value_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.p_alpha_value_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.p_alpha_value_TextEdit.Properties.ReadOnly = True
        Me.p_alpha_value_TextEdit.Size = New System.Drawing.Size(83, 20)
        Me.p_alpha_value_TextEdit.TabIndex = 29
        Me.p_alpha_value_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl2.Location = New System.Drawing.Point(67, 87)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl2.TabIndex = 28
        Me.LabelControl2.Text = "p alpha Value"
        '
        'CreditMigrationRisk_TextEdit
        '
        Me.CreditMigrationRisk_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_DATEBindingSource, "CreditMigrationRisk", True))
        Me.CreditMigrationRisk_TextEdit.Location = New System.Drawing.Point(138, 32)
        Me.CreditMigrationRisk_TextEdit.Name = "CreditMigrationRisk_TextEdit"
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.CreditMigrationRisk_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CreditMigrationRisk_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CreditMigrationRisk_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CreditMigrationRisk_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CreditMigrationRisk_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CreditMigrationRisk_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CreditMigrationRisk_TextEdit.Properties.DisplayFormat.FormatString = "c0"
        Me.CreditMigrationRisk_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CreditMigrationRisk_TextEdit.Properties.EditFormat.FormatString = "c0"
        Me.CreditMigrationRisk_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CreditMigrationRisk_TextEdit.Properties.Mask.EditMask = "c0"
        Me.CreditMigrationRisk_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.CreditMigrationRisk_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.CreditMigrationRisk_TextEdit.Properties.ReadOnly = True
        Me.CreditMigrationRisk_TextEdit.Size = New System.Drawing.Size(157, 22)
        ToolTipTitleItem1.ImageOptions.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        ToolTipTitleItem1.Text = "Credit Migration Risk"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "The calculated Credit Migration Risk for the4 specified Business Date"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.CreditMigrationRisk_TextEdit.SuperTip = SuperToolTip1
        Me.CreditMigrationRisk_TextEdit.TabIndex = 16
        Me.CreditMigrationRisk_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.Appearance.Options.UseTextOptions = True
        Me.LabelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl12.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(119, 13)
        Me.LabelControl12.TabIndex = 6
        Me.LabelControl12.Text = "Credit Migration Risk"
        '
        'b_beta_value_TextEdit
        '
        Me.b_beta_value_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "b_beta_value", True))
        Me.b_beta_value_TextEdit.Location = New System.Drawing.Point(138, 138)
        Me.b_beta_value_TextEdit.Name = "b_beta_value_TextEdit"
        Me.b_beta_value_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.b_beta_value_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.b_beta_value_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.b_beta_value_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.b_beta_value_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.b_beta_value_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.b_beta_value_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.b_beta_value_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.b_beta_value_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.b_beta_value_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.b_beta_value_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.b_beta_value_TextEdit.Properties.Mask.EditMask = "n5"
        Me.b_beta_value_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.b_beta_value_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.b_beta_value_TextEdit.Properties.ReadOnly = True
        Me.b_beta_value_TextEdit.Size = New System.Drawing.Size(83, 20)
        ToolTipTitleItem2.ImageOptions.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
        ToolTipTitleItem2.Text = "b beta value" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        Me.b_beta_value_TextEdit.SuperTip = SuperToolTip2
        Me.b_beta_value_TextEdit.TabIndex = 22
        Me.b_beta_value_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Options.UseTextOptions = True
        Me.LabelControl15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl15.Location = New System.Drawing.Point(72, 141)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl15.TabIndex = 14
        Me.LabelControl15.Text = "b beta value"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Options.UseTextOptions = True
        Me.LabelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl13.Location = New System.Drawing.Point(37, 61)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl13.TabIndex = 12
        Me.LabelControl13.Text = "Level of Confidence"
        '
        'LevelOfConfidence_TextEdit
        '
        Me.LevelOfConfidence_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CreditMigrationRisk_TotalsBindingSource, "LevelOfConfidence", True))
        Me.LevelOfConfidence_TextEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LevelOfConfidence_TextEdit.Location = New System.Drawing.Point(138, 58)
        Me.LevelOfConfidence_TextEdit.Name = "LevelOfConfidence_TextEdit"
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.LevelOfConfidence_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LevelOfConfidence_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LevelOfConfidence_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LevelOfConfidence_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LevelOfConfidence_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LevelOfConfidence_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LevelOfConfidence_TextEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LevelOfConfidence_TextEdit.Properties.DisplayFormat.FormatString = "p2"
        Me.LevelOfConfidence_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LevelOfConfidence_TextEdit.Properties.EditFormat.FormatString = "p2"
        Me.LevelOfConfidence_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LevelOfConfidence_TextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.LevelOfConfidence_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.LevelOfConfidence_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.LevelOfConfidence_TextEdit.Properties.ReadOnly = True
        Me.LevelOfConfidence_TextEdit.Size = New System.Drawing.Size(74, 20)
        Me.LevelOfConfidence_TextEdit.TabIndex = 17
        Me.LevelOfConfidence_TextEdit.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
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
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup4.CustomizationFormText = "B - Sätze Ausschlusskennzeichen"
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1442, 314)
        Me.LayoutControlGroup4.Text = "B - Sätze Ausschlusskennzeichen"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1, Me.LayoutControlItem3, Me.SplitterItem1, Me.SplitterItem2, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1861, 893)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 324)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1841, 549)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup2.CustomizationFormText = "Clients Groups"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1817, 504)
        Me.LayoutControlGroup2.Text = "Clients Groups for each Downgrade Notch (Unexpected Loss)"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.CMR_Groups_GridControl
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(1817, 504)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup3.CustomizationFormText = "Credit Risk Details"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1817, 504)
        Me.LayoutControlGroup3.Text = "All Credit Risk Details (for all Downgrade Notches) - Expected Loss"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.CMR_Details_GridControl
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem11"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(1817, 504)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GroupControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(310, 314)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(310, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings
        Me.SplitterItem1.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.[True]
        Me.SplitterItem1.Size = New System.Drawing.Size(10, 314)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 314)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings
        Me.SplitterItem2.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.[True]
        Me.SplitterItem2.Size = New System.Drawing.Size(1841, 10)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CMR_Totals_GridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(320, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1521, 314)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'RibbonControl2
        '
        Me.RibbonControl2.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl2.ExpandCollapseItem.Id = 0
        Me.RibbonControl2.Images = Me.ImageCollection1
        Me.RibbonControl2.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl2.ExpandCollapseItem, Me.RibbonControl2.SearchEditItem, Me.DailyRiskTable_BarButtonItem, Me.LoanStructureTable_BarButtonItem, Me.InterestRateRiskHUMPBarButtonItem, Me.RecalculateCreditRiskCurrentDateBarButtonItem, Me.RecalculateCreditRiskSpecificPeriodBarButtonItem, Me.CreditMigrationRisk_BarButtonItem, Me.EAEG_Daten_Kunden_BarButtonItem, Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem, Me.EAEG_Meldedatei_Erstellung_BarButtonItem, Me.Gesetzliche_Einlagensicherung_BarButtonItem, Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem, Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem, Me.EAEG_Laden_BASIS_BarButtonItem, Me.EAEG_Laden_ERWEITERT_BarButtonItem, Me.CreditMigrationRiskExcel_BarbuttonItem, Me.BusinessDate_BarEditItem, Me.BarSubItem1, Me.Reports_BarSubItem, Me.Reload_bbi, Me.Print_Export_bbi, Me.ViewDetails_SwitchItem, Me.bbi_Close})
        Me.RibbonControl2.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl2.MaxItemId = 74
        Me.RibbonControl2.Name = "RibbonControl2"
        Me.RibbonControl2.PageHeaderItemLinks.Add(Me.ViewDetails_SwitchItem)
        Me.RibbonControl2.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage3})
        Me.RibbonControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BusinessDate_SearchLookUpEdit})
        Me.RibbonControl2.Size = New System.Drawing.Size(1860, 94)
        '
        'DailyRiskTable_BarButtonItem
        '
        Me.DailyRiskTable_BarButtonItem.Caption = "DAILY RISK TABLE"
        Me.DailyRiskTable_BarButtonItem.Id = 0
        Me.DailyRiskTable_BarButtonItem.ImageOptions.ImageIndex = 7
        Me.DailyRiskTable_BarButtonItem.Name = "DailyRiskTable_BarButtonItem"
        '
        'LoanStructureTable_BarButtonItem
        '
        Me.LoanStructureTable_BarButtonItem.Caption = "LOAN STRUCTURE TABLE"
        Me.LoanStructureTable_BarButtonItem.Id = 1
        Me.LoanStructureTable_BarButtonItem.ImageOptions.ImageIndex = 7
        Me.LoanStructureTable_BarButtonItem.Name = "LoanStructureTable_BarButtonItem"
        '
        'InterestRateRiskHUMPBarButtonItem
        '
        Me.InterestRateRiskHUMPBarButtonItem.Caption = "INTEREST RATE RISK (HUMP-TWIST1 - TWIST2)"
        Me.InterestRateRiskHUMPBarButtonItem.Id = 2
        Me.InterestRateRiskHUMPBarButtonItem.ImageOptions.ImageIndex = 7
        Me.InterestRateRiskHUMPBarButtonItem.Name = "InterestRateRiskHUMPBarButtonItem"
        Me.InterestRateRiskHUMPBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RecalculateCreditRiskCurrentDateBarButtonItem
        '
        Me.RecalculateCreditRiskCurrentDateBarButtonItem.Caption = "Current Date"
        Me.RecalculateCreditRiskCurrentDateBarButtonItem.Id = 3
        Me.RecalculateCreditRiskCurrentDateBarButtonItem.ImageOptions.ImageIndex = 8
        Me.RecalculateCreditRiskCurrentDateBarButtonItem.Name = "RecalculateCreditRiskCurrentDateBarButtonItem"
        '
        'RecalculateCreditRiskSpecificPeriodBarButtonItem
        '
        Me.RecalculateCreditRiskSpecificPeriodBarButtonItem.Caption = "Specific Period"
        Me.RecalculateCreditRiskSpecificPeriodBarButtonItem.Id = 4
        Me.RecalculateCreditRiskSpecificPeriodBarButtonItem.ImageOptions.ImageIndex = 8
        Me.RecalculateCreditRiskSpecificPeriodBarButtonItem.Name = "RecalculateCreditRiskSpecificPeriodBarButtonItem"
        '
        'CreditMigrationRisk_BarButtonItem
        '
        Me.CreditMigrationRisk_BarButtonItem.Caption = "Credit Migration Risk Report"
        Me.CreditMigrationRisk_BarButtonItem.Id = 6
        Me.CreditMigrationRisk_BarButtonItem.ImageOptions.ImageIndex = 11
        Me.CreditMigrationRisk_BarButtonItem.Name = "CreditMigrationRisk_BarButtonItem"
        '
        'EAEG_Daten_Kunden_BarButtonItem
        '
        Me.EAEG_Daten_Kunden_BarButtonItem.Caption = "EAEG Daten (Kunden)"
        Me.EAEG_Daten_Kunden_BarButtonItem.Id = 7
        Me.EAEG_Daten_Kunden_BarButtonItem.ImageOptions.ImageIndex = 11
        Me.EAEG_Daten_Kunden_BarButtonItem.Name = "EAEG_Daten_Kunden_BarButtonItem"
        '
        'EAEG_EinreicherDatei_Erstellung_BarButtonItem
        '
        Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem.Caption = "EAEG Einreicher Datei erstellung (Version 4.1 - ERWEITERT)"
        Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem.Id = 8
        Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem.ImageOptions.ImageIndex = 17
        Me.EAEG_EinreicherDatei_Erstellung_BarButtonItem.Name = "EAEG_EinreicherDatei_Erstellung_BarButtonItem"
        '
        'EAEG_Meldedatei_Erstellung_BarButtonItem
        '
        Me.EAEG_Meldedatei_Erstellung_BarButtonItem.Caption = "EAEG Meldedatei erstellung (Version 2.1 - ERWEITERT)"
        Me.EAEG_Meldedatei_Erstellung_BarButtonItem.Id = 9
        Me.EAEG_Meldedatei_Erstellung_BarButtonItem.ImageOptions.ImageIndex = 17
        Me.EAEG_Meldedatei_Erstellung_BarButtonItem.Name = "EAEG_Meldedatei_Erstellung_BarButtonItem"
        '
        'Gesetzliche_Einlagensicherung_BarButtonItem
        '
        Me.Gesetzliche_Einlagensicherung_BarButtonItem.Caption = "Gesetzliche Einlagensicherung (Kundenliste)"
        Me.Gesetzliche_Einlagensicherung_BarButtonItem.Id = 10
        Me.Gesetzliche_Einlagensicherung_BarButtonItem.ImageOptions.ImageIndex = 11
        Me.Gesetzliche_Einlagensicherung_BarButtonItem.Name = "Gesetzliche_Einlagensicherung_BarButtonItem"
        '
        'EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem
        '
        Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem.Caption = "EAEG Einreicher Datei erstellung (Version 4.1 - BASIS)"
        Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem.Id = 11
        Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem.ImageOptions.ImageIndex = 17
        Me.EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem.Name = "EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem"
        '
        'EAEG_MeldeDateiErstellung_BASIS_BarButtonItem
        '
        Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem.Caption = "EAEG Meldedatei erstellung (Version 2.1 - BASIS)"
        Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem.Id = 12
        Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem.ImageOptions.ImageIndex = 17
        Me.EAEG_MeldeDateiErstellung_BASIS_BarButtonItem.Name = "EAEG_MeldeDateiErstellung_BASIS_BarButtonItem"
        '
        'EAEG_Laden_BASIS_BarButtonItem
        '
        Me.EAEG_Laden_BASIS_BarButtonItem.Caption = "EAEG Daten erneut laden (BASIS)"
        Me.EAEG_Laden_BASIS_BarButtonItem.Id = 13
        Me.EAEG_Laden_BASIS_BarButtonItem.ImageOptions.ImageIndex = 10
        Me.EAEG_Laden_BASIS_BarButtonItem.Name = "EAEG_Laden_BASIS_BarButtonItem"
        '
        'EAEG_Laden_ERWEITERT_BarButtonItem
        '
        Me.EAEG_Laden_ERWEITERT_BarButtonItem.Caption = "EAEG Daten Laden (ERWEITERT)"
        Me.EAEG_Laden_ERWEITERT_BarButtonItem.Id = 14
        Me.EAEG_Laden_ERWEITERT_BarButtonItem.ImageOptions.ImageIndex = 10
        Me.EAEG_Laden_ERWEITERT_BarButtonItem.Name = "EAEG_Laden_ERWEITERT_BarButtonItem"
        Me.EAEG_Laden_ERWEITERT_BarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'CreditMigrationRiskExcel_BarbuttonItem
        '
        Me.CreditMigrationRiskExcel_BarbuttonItem.Caption = "Load data to Excel file"
        Me.CreditMigrationRiskExcel_BarbuttonItem.Id = 15
        Me.CreditMigrationRiskExcel_BarbuttonItem.ImageOptions.ImageIndex = 18
        Me.CreditMigrationRiskExcel_BarbuttonItem.Name = "CreditMigrationRiskExcel_BarbuttonItem"
        '
        'BusinessDate_BarEditItem
        '
        Me.BusinessDate_BarEditItem.Caption = "Business Date"
        Me.BusinessDate_BarEditItem.CaptionToEditorIndent = 10
        Me.BusinessDate_BarEditItem.Edit = Me.BusinessDate_SearchLookUpEdit
        Me.BusinessDate_BarEditItem.EditWidth = 150
        Me.BusinessDate_BarEditItem.Id = 6
        Me.BusinessDate_BarEditItem.ImageOptions.Image = CType(resources.GetObject("BusinessDate_BarEditItem.ImageOptions.Image"), System.Drawing.Image)
        Me.BusinessDate_BarEditItem.ImageOptions.LargeImage = CType(resources.GetObject("BusinessDate_BarEditItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BusinessDate_BarEditItem.Name = "BusinessDate_BarEditItem"
        '
        'BusinessDate_SearchLookUpEdit
        '
        Me.BusinessDate_SearchLookUpEdit.Appearance.Options.UseTextOptions = True
        Me.BusinessDate_SearchLookUpEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BusinessDate_SearchLookUpEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BusinessDate_SearchLookUpEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BusinessDate_SearchLookUpEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BusinessDate_SearchLookUpEdit.AppearanceFocused.Options.UseBackColor = True
        Me.BusinessDate_SearchLookUpEdit.AppearanceFocused.Options.UseForeColor = True
        Me.BusinessDate_SearchLookUpEdit.AutoHeight = False
        Me.BusinessDate_SearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BusinessDate_SearchLookUpEdit.Name = "BusinessDate_SearchLookUpEdit"
        Me.BusinessDate_SearchLookUpEdit.PopupView = Me.BusinessDates_GridView
        Me.BusinessDate_SearchLookUpEdit.ShowClearButton = False
        Me.BusinessDate_SearchLookUpEdit.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        '
        'BusinessDates_GridView
        '
        Me.BusinessDates_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BusinessDates_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BusinessDates_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BusinessDates_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BusinessDates_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BusinessDates_GridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.BusinessDates_GridView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BusinessDates_GridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BusinessDates_GridView.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BusinessDates_GridView.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BusinessDates_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBusinessDate})
        Me.BusinessDates_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BusinessDates_GridView.Name = "BusinessDates_GridView"
        Me.BusinessDates_GridView.OptionsFind.AlwaysVisible = True
        Me.BusinessDates_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BusinessDates_GridView.OptionsView.ColumnAutoWidth = False
        Me.BusinessDates_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BusinessDates_GridView.OptionsView.ShowGroupPanel = False
        '
        'colBusinessDate
        '
        Me.colBusinessDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBusinessDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBusinessDate.Caption = "Business Dates"
        Me.colBusinessDate.DisplayFormat.FormatString = "d"
        Me.colBusinessDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colBusinessDate.FieldName = "BusinessDate"
        Me.colBusinessDate.Name = "colBusinessDate"
        Me.colBusinessDate.OptionsColumn.ReadOnly = True
        Me.colBusinessDate.Visible = True
        Me.colBusinessDate.VisibleIndex = 0
        Me.colBusinessDate.Width = 133
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "EAEG DATEI REPORTS"
        Me.BarSubItem1.Id = 7
        Me.BarSubItem1.ImageOptions.ImageIndex = 11
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.CreditMigrationRisk_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EAEG_Daten_Kunden_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.Gesetzliche_Einlagensicherung_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.CreditMigrationRiskExcel_BarbuttonItem)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'Reports_BarSubItem
        '
        Me.Reports_BarSubItem.Caption = "REPORTS"
        Me.Reports_BarSubItem.Id = 12
        Me.Reports_BarSubItem.ImageOptions.ImageIndex = 19
        Me.Reports_BarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.CreditMigrationRisk_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.CreditMigrationRiskExcel_BarbuttonItem, True)})
        Me.Reports_BarSubItem.Name = "Reports_BarSubItem"
        '
        'Reload_bbi
        '
        Me.Reload_bbi.Caption = "Reload all Business Dates"
        Me.Reload_bbi.Id = 15
        Me.Reload_bbi.ImageOptions.Image = CType(resources.GetObject("Reload_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Reload_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Reload_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Reload_bbi.Name = "Reload_bbi"
        '
        'Print_Export_bbi
        '
        Me.Print_Export_bbi.Caption = "Print or Export"
        Me.Print_Export_bbi.Id = 17
        Me.Print_Export_bbi.ImageOptions.Image = CType(resources.GetObject("Print_Export_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.Print_Export_bbi.ImageOptions.LargeImage = CType(resources.GetObject("Print_Export_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.Print_Export_bbi.Name = "Print_Export_bbi"
        '
        'ViewDetails_SwitchItem
        '
        Me.ViewDetails_SwitchItem.Caption = "View Details"
        Me.ViewDetails_SwitchItem.Id = 18
        Me.ViewDetails_SwitchItem.ImageOptions.Image = CType(resources.GetObject("ViewDetails_SwitchItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ViewDetails_SwitchItem.ImageOptions.LargeImage = CType(resources.GetObject("ViewDetails_SwitchItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ViewDetails_SwitchItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewDetails_SwitchItem.ItemAppearance.Normal.Options.UseFont = True
        Me.ViewDetails_SwitchItem.Name = "ViewDetails_SwitchItem"
        '
        'bbi_Close
        '
        Me.bbi_Close.Caption = "Close"
        Me.bbi_Close.Id = 20
        Me.bbi_Close.ImageOptions.Image = CType(resources.GetObject("bbi_Close.ImageOptions.Image"), System.Drawing.Image)
        Me.bbi_Close.ImageOptions.LargeImage = CType(resources.GetObject("bbi_Close.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbi_Close.Name = "bbi_Close"
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3, Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "Home"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BusinessDate_BarEditItem)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.Reports_BarSubItem, True)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Tools"
        Me.RibbonPageGroup3.Visible = False
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.Reload_bbi)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.Print_Export_bbi)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbi_Close, True)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.CSR_AllDates_GridControl)
        Me.LayoutControl2.Location = New System.Drawing.Point(12, 99)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(383, 102, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup5
        Me.LayoutControl2.Size = New System.Drawing.Size(1688, 65)
        Me.LayoutControl2.TabIndex = 28
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "Root"
        Me.LayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup5.GroupBordersVisible = False
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup8})
        Me.LayoutControlGroup5.Name = "Root"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1671, 68)
        '
        'LayoutControlGroup8
        '
        Me.LayoutControlGroup8.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup8.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup8.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup8.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15})
        Me.LayoutControlGroup8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup8.Name = "LayoutControlGroup8"
        Me.LayoutControlGroup8.Size = New System.Drawing.Size(1651, 48)
        Me.LayoutControlGroup8.Text = "FX PAIRS"
        Me.LayoutControlGroup8.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.CSR_AllDates_GridControl
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(1627, 24)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'CreditSpreadRisk_PortfolioRiskCalculationTableAdapter
        '
        Me.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter.ClearBeforeFill = True
        '
        'CreditSpreadRisk_SegmentRiskCalculationTableAdapter
        '
        Me.CreditSpreadRisk_SegmentRiskCalculationTableAdapter.ClearBeforeFill = True
        '
        'CreditMigrationRisk_DATETableAdapter
        '
        Me.CreditMigrationRisk_DATETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CreditMigrationRisk_DATETableAdapter = Me.CreditMigrationRisk_DATETableAdapter
        Me.TableAdapterManager.CreditMigrationRisk_DetailsTableAdapter = Me.CreditMigrationRisk_DetailsTableAdapter
        Me.TableAdapterManager.CreditMigrationRisk_GroupsTableAdapter = Me.CreditMigrationRisk_GroupsTableAdapter
        Me.TableAdapterManager.CreditMigrationRisk_TotalsTableAdapter = Me.CreditMigrationRisk_TotalsTableAdapter
        Me.TableAdapterManager.PD_Downgrade_PropabilitiesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.CreditMigrationRiskDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CreditMigrationRisk_DetailsTableAdapter
        '
        Me.CreditMigrationRisk_DetailsTableAdapter.ClearBeforeFill = True
        '
        'CreditMigrationRisk_GroupsTableAdapter
        '
        Me.CreditMigrationRisk_GroupsTableAdapter.ClearBeforeFill = True
        '
        'CreditMigrationRisk_TotalsTableAdapter
        '
        Me.CreditMigrationRisk_TotalsTableAdapter.ClearBeforeFill = True
        '
        'CreditMigrationRiskCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1860, 1053)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl2)
        Me.IconOptions.Icon = CType(resources.GetObject("CreditMigrationRiskCalc.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "CreditMigrationRiskCalc"
        Me.Ribbon = Me.RibbonControl2
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Credit Migration Risk Calculations"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_Details_GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRisk_DetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRiskDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSR_AllDates_GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRisk_DATEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_AllDates_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CMR_Groups_GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRisk_GroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_Groups_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_Totals_GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRisk_TotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMR_Totals_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.Delta_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAMMAINV_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nu_Value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p_alpha_value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditMigrationRisk_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.b_beta_value_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LevelOfConfidence_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditSpreadRisk_PortfolioRiskCalculationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessDate_SearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessDates_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditSpreadRisk_SegmentRiskCalculationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents DailyRiskTable_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LoanStructureTable_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents InterestRateRiskHUMPBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RecalculateCreditRiskCurrentDateBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RecalculateCreditRiskSpecificPeriodBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CreditMigrationRisk_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_Daten_Kunden_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents b_beta_value_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CreditMigrationRisk_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CMR_Details_GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMR_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents CSR_AllDates_GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EAEG_EinreicherDatei_Erstellung_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_Meldedatei_Erstellung_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Gesetzliche_Einlagensicherung_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_EinreicherDateiErstellung_BASIS_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_MeldeDateiErstellung_BASIS_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_Laden_BASIS_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EAEG_Laden_ERWEITERT_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CreditMigrationRiskExcel_BarbuttonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonControl2 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BusinessDate_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BusinessDate_SearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents Reports_BarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BusinessDates_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colBusinessDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Reload_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Print_Export_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ViewDetails_SwitchItem As DevExpress.XtraBars.BarToggleSwitchItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbi_Close As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CMR_AllDates_GridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents nu_Value_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents p_alpha_value_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CreditSpreadRisk_PortfolioRiskCalculationBindingSource As BindingSource
    Friend WithEvents CreditSpreadRisk_PortfolioRiskCalculationTableAdapter As CreditSpreadRiskDataSetTableAdapters.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter
    Friend WithEvents CreditSpreadRisk_SegmentRiskCalculationBindingSource As BindingSource
    Friend WithEvents CreditSpreadRisk_SegmentRiskCalculationTableAdapter As CreditSpreadRiskDataSetTableAdapters.CreditSpreadRisk_SegmentRiskCalculationTableAdapter
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents CMR_Totals_GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMR_Totals_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox5 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox6 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LevelOfConfidence_TextEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents CMR_Groups_GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMR_Groups_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox9 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox10 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents PrintableComponentLink_AllDates As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink_SingleDate As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents CreditMigrationRiskDataSet As CreditMigrationRiskDataSet
    Friend WithEvents CreditMigrationRisk_DATEBindingSource As BindingSource
    Friend WithEvents CreditMigrationRisk_DATETableAdapter As CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_DATETableAdapter
    Friend WithEvents TableAdapterManager As CreditMigrationRiskDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CreditMigrationRisk_DetailsTableAdapter As CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_DetailsTableAdapter
    Friend WithEvents CreditMigrationRisk_DetailsBindingSource As BindingSource
    Friend WithEvents CreditMigrationRisk_GroupsTableAdapter As CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_GroupsTableAdapter
    Friend WithEvents CreditMigrationRisk_GroupsBindingSource As BindingSource
    Friend WithEvents CreditMigrationRisk_TotalsTableAdapter As CreditMigrationRiskDataSetTableAdapters.CreditMigrationRisk_TotalsTableAdapter
    Friend WithEvents CreditMigrationRisk_TotalsBindingSource As BindingSource
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colID2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCreditMigrationRisk As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDowngradeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLevelOfConfidence As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSumEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSumUL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSummeFinalEADTotalSum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnu_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colp_alpha_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colb_beta_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGamma_inv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDelta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colK_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSumGA_rel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSumGA_Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalRisk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskAdjustment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalRisk_Adjusted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colImpactOnTotalRisk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPropability As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExpectedValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroupName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubBorrowersCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFinalEadTotalSum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLGD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD_EaD_weighted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD_3bps_floor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIndicatorOfFloor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityEADweigthed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colR_CoefficientOfColleration As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colb_MaturityAdjustment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRW_RiskWeightedExposure As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUL_UnexpectedLoss As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDowngradeStatus1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVLGDi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGAn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDowngradeStatus2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GAMMAINV_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Delta_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
End Class
