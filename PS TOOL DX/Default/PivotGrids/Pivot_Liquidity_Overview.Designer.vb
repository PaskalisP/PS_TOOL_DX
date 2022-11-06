<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pivot_Liquidity_Overview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pivot_Liquidity_Overview))
        Dim PivotGridCustomTotal1 As DevExpress.XtraPivotGrid.PivotGridCustomTotal = New DevExpress.XtraPivotGrid.PivotGridCustomTotal()
        Dim PivotGridFormatRule1 As DevExpress.XtraPivotGrid.PivotGridFormatRule = New DevExpress.XtraPivotGrid.PivotGridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim FormatRuleTotalTypeSettings1 As DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings = New DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings()
        Dim PivotGridFormatRule2 As DevExpress.XtraPivotGrid.PivotGridFormatRule = New DevExpress.XtraPivotGrid.PivotGridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim FormatRuleTotalTypeSettings2 As DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings = New DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings()
        Dim PivotGridGroup1 As DevExpress.XtraPivotGrid.PivotGridGroup = New DevExpress.XtraPivotGrid.PivotGridGroup()
        Me.PivotGridField17 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField11 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.FieldFinalMaturityDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldNextEventDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldNextEventType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCustomerName = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldContract_Account = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldClientNr = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldCURRENCY = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldPERIOD = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldContractType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldProductType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldGLMasterAccountType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldPrincipalAmountValueBalance = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldPrincipalAmountValueBalanceEUREqu = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldRISKDATE = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldClientType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCOUNTRY_OF_REGISTRATION = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCOUNTRY_OF_RESIDENCE = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldINDUSTRIAL_CLASS_CN = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCCB_Group = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCCB_Group_OwnID = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldEU_EEA = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldEWU = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldIsBank = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldLANDKZ_BUBA = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCOUNTRY_NAME = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldStartDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldBusinessType = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldInterestRate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldInterestAmountOrigCur = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldInterestAmountEuro = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.UB_FieldSumInOutflowEUR = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.UB_FieldSumInOutflowCUR = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.UB_PrincipalInterestEUR = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldINDUSTRIAL_CLASS_LOCAL = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldAccruedInterestAmountEUR = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldAccruedInterestAmountOrigCur = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldAverageDuration = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldDaysToEventDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldPERIOD_Additional = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldDaysToMaturity = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldPERIOD_MaturityDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldALMMPeriod_MaturityDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.FieldCIC_Group = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.GroupRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PivotGridControl2 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.PivotGridField4 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField5 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField8 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField9 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BS_DateFrom_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.BS_Date_From_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BS_DateTill_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemSearchLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.BS_Date_Till_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoadDate_BarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.LoadDataFromTill_Bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.LoadDataSelectedDate_Bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.LoadDataFromList_Bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.CompareData_Bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.LayoutTemplatesMenu_SubItem = New DevExpress.XtraBars.BarSubItem()
        Me.bbiLoadLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiSaveLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDeleteLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiLoadDefaultLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportTemplateName_BarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.bbiPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.FieldPERIOD_ALMM_MaturityDate = New DevExpress.XtraPivotGrid.PivotGridField()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PivotGridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_Date_From_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_Date_Till_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PivotGridField17
        '
        Me.PivotGridField17.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField17.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PivotGridField17.Appearance.Header.Options.UseFont = True
        Me.PivotGridField17.Appearance.Header.Options.UseForeColor = True
        Me.PivotGridField17.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField17.AreaIndex = 2
        Me.PivotGridField17.Caption = "Difference"
        Me.PivotGridField17.CellFormat.FormatString = "n2"
        Me.PivotGridField17.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField17.FieldName = "Difference_Max_Min"
        Me.PivotGridField17.Name = "PivotGridField17"
        Me.PivotGridField17.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.PivotGridField17.ValueFormat.FormatString = "n2"
        Me.PivotGridField17.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'PivotGridField11
        '
        Me.PivotGridField11.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField11.Appearance.Header.Options.UseFont = True
        Me.PivotGridField11.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField11.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField11.AreaIndex = 0
        Me.PivotGridField11.Caption = "Business Date"
        Me.PivotGridField11.CellFormat.FormatString = "d"
        Me.PivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PivotGridField11.FieldName = "BSDate"
        Me.PivotGridField11.Name = "PivotGridField11"
        Me.PivotGridField11.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.PivotGridField11.Options.ShowUnboundExpressionMenu = True
        Me.PivotGridField11.UnboundFieldName = "PivotGridField11"
        Me.PivotGridField11.ValueFormat.FormatString = "d"
        Me.PivotGridField11.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
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
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(10, "EU-FLAG.jpg")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.PivotGridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = True
        Me.PivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseForeColor = True
        Me.PivotGridControl1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.PivotGridControl1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.PivotGridControl1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.FocusedCell.Options.UseFont = True
        Me.PivotGridControl1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.PivotGridControl1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PivotGridControl1.Appearance.GrandTotalCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl1.Appearance.GrandTotalCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl1.Appearance.GrandTotalCell.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = True
        Me.PivotGridControl1.Appearance.GrandTotalCell.Options.UseForeColor = True
        Me.PivotGridControl1.Appearance.SelectedCell.BackColor = System.Drawing.Color.Yellow
        Me.PivotGridControl1.Appearance.SelectedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.PivotGridControl1.Appearance.SelectedCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl1.Appearance.SelectedCell.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.SelectedCell.Options.UseForeColor = True
        Me.PivotGridControl1.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridControl1.Appearance.TotalCell.Options.UseBackColor = True
        Me.PivotGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.FieldFinalMaturityDate, Me.FieldNextEventDate, Me.FieldNextEventType, Me.FieldCustomerName, Me.FieldContract_Account, Me.FieldClientNr, Me.fieldCURRENCY, Me.fieldPERIOD, Me.fieldContractType, Me.fieldProductType, Me.fieldGLMasterAccountType, Me.FieldType, Me.fieldPrincipalAmountValueBalance, Me.fieldPrincipalAmountValueBalanceEUREqu, Me.fieldRISKDATE, Me.FieldClientType, Me.FieldCOUNTRY_OF_REGISTRATION, Me.FieldCOUNTRY_OF_RESIDENCE, Me.FieldINDUSTRIAL_CLASS_CN, Me.FieldCCB_Group, Me.FieldCCB_Group_OwnID, Me.FieldEU_EEA, Me.FieldEWU, Me.FieldIsBank, Me.FieldLANDKZ_BUBA, Me.FieldCOUNTRY_NAME, Me.FieldStartDate, Me.FieldBusinessType, Me.FieldInterestRate, Me.FieldInterestAmountOrigCur, Me.FieldInterestAmountEuro, Me.UB_FieldSumInOutflowEUR, Me.UB_FieldSumInOutflowCUR, Me.UB_PrincipalInterestEUR, Me.FieldINDUSTRIAL_CLASS_LOCAL, Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME, Me.FieldAccruedInterestAmountEUR, Me.FieldAccruedInterestAmountOrigCur, Me.FieldAverageDuration, Me.FieldDaysToEventDate, Me.FieldPERIOD_Additional, Me.FieldDaysToMaturity, Me.FieldPERIOD_MaturityDate, Me.FieldALMMPeriod_MaturityDate, Me.FieldCIC_Group})
        Me.PivotGridControl1.Location = New System.Drawing.Point(24, 75)
        Me.PivotGridControl1.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.PivotGridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.OptionsBehavior.CopyToClipboardWithFieldValues = True
        Me.PivotGridControl1.OptionsCustomization.AllowSortInCustomizationForm = True
        Me.PivotGridControl1.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.PivotGridControl1.OptionsFilterPopup.FieldFilterPopupMode = DevExpress.XtraPivotGrid.FieldFilterPopupMode.Excel
        Me.PivotGridControl1.OptionsPrint.MergeColumnFieldValues = False
        Me.PivotGridControl1.OptionsPrint.MergeRowFieldValues = False
        Me.PivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = True
        Me.PivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.PivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.PivotGridControl1.OptionsSelection.EnableAppearanceFocusedCell = True
        Me.PivotGridControl1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.PivotGridControl1.OptionsView.ShowColumnGrandTotals = False
        Me.PivotGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.GroupRepositoryItemImageComboBox})
        Me.PivotGridControl1.Size = New System.Drawing.Size(1397, 447)
        Me.PivotGridControl1.TabIndex = 0
        '
        'FieldFinalMaturityDate
        '
        Me.FieldFinalMaturityDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldFinalMaturityDate.Appearance.Header.Options.UseFont = True
        Me.FieldFinalMaturityDate.AreaIndex = 8
        Me.FieldFinalMaturityDate.Caption = "Final Maturity Date"
        Me.FieldFinalMaturityDate.CellFormat.FormatString = "d"
        Me.FieldFinalMaturityDate.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FieldFinalMaturityDate.FieldName = "Final Maturity Date"
        Me.FieldFinalMaturityDate.Name = "FieldFinalMaturityDate"
        Me.FieldFinalMaturityDate.ValueFormat.FormatString = "d"
        Me.FieldFinalMaturityDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'FieldNextEventDate
        '
        Me.FieldNextEventDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldNextEventDate.Appearance.Header.Options.UseFont = True
        Me.FieldNextEventDate.AreaIndex = 7
        Me.FieldNextEventDate.Caption = "Next EventDate"
        Me.FieldNextEventDate.CellFormat.FormatString = "d"
        Me.FieldNextEventDate.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FieldNextEventDate.FieldName = "Next EventDate"
        Me.FieldNextEventDate.Name = "FieldNextEventDate"
        Me.FieldNextEventDate.ValueFormat.FormatString = "d"
        Me.FieldNextEventDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'FieldNextEventType
        '
        Me.FieldNextEventType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldNextEventType.Appearance.Header.Options.UseFont = True
        Me.FieldNextEventType.AreaIndex = 6
        Me.FieldNextEventType.Caption = "Next EventType"
        Me.FieldNextEventType.FieldName = "Next EventType"
        Me.FieldNextEventType.Name = "FieldNextEventType"
        '
        'FieldCustomerName
        '
        Me.FieldCustomerName.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCustomerName.Appearance.Header.Options.UseFont = True
        Me.FieldCustomerName.AreaIndex = 4
        Me.FieldCustomerName.Caption = "Customer Name"
        Me.FieldCustomerName.FieldName = "Counterparty/Issuer"
        Me.FieldCustomerName.Name = "FieldCustomerName"
        '
        'FieldContract_Account
        '
        Me.FieldContract_Account.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldContract_Account.Appearance.Header.Options.UseFont = True
        Me.FieldContract_Account.AreaIndex = 3
        Me.FieldContract_Account.Caption = "Contract/Account"
        Me.FieldContract_Account.FieldName = "Contract/Account"
        Me.FieldContract_Account.Name = "FieldContract_Account"
        '
        'FieldClientNr
        '
        Me.FieldClientNr.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldClientNr.Appearance.Header.Options.UseFont = True
        Me.FieldClientNr.AreaIndex = 16
        Me.FieldClientNr.Caption = "ClientNr"
        Me.FieldClientNr.FieldName = "ClientNr"
        Me.FieldClientNr.Name = "FieldClientNr"
        '
        'fieldCURRENCY
        '
        Me.fieldCURRENCY.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldCURRENCY.Appearance.CellTotal.Options.UseFont = True
        Me.fieldCURRENCY.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldCURRENCY.Appearance.Header.Options.UseFont = True
        Me.fieldCURRENCY.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldCURRENCY.AreaIndex = 0
        Me.fieldCURRENCY.Caption = "Currency"
        Me.fieldCURRENCY.FieldName = "CURRENCY"
        Me.fieldCURRENCY.Name = "fieldCURRENCY"
        Me.fieldCURRENCY.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldCURRENCY.Options.ShowUnboundExpressionMenu = True
        Me.fieldCURRENCY.Width = 148
        '
        'fieldPERIOD
        '
        Me.fieldPERIOD.Appearance.CellGrandTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPERIOD.Appearance.CellGrandTotal.Options.UseFont = True
        Me.fieldPERIOD.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPERIOD.Appearance.CellTotal.Options.UseFont = True
        Me.fieldPERIOD.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPERIOD.Appearance.Header.Options.UseFont = True
        Me.fieldPERIOD.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPERIOD.Appearance.Value.Options.UseFont = True
        Me.fieldPERIOD.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldPERIOD.AreaIndex = 1
        Me.fieldPERIOD.Caption = "Period (Next Event Date)"
        Me.fieldPERIOD.FieldName = "PERIOD"
        Me.fieldPERIOD.Name = "fieldPERIOD"
        Me.fieldPERIOD.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldPERIOD.Options.ShowUnboundExpressionMenu = True
        Me.fieldPERIOD.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
        Me.fieldPERIOD.ToolTips.HeaderText = "Calculated PERIOD based on the contracts next event Date"
        Me.fieldPERIOD.Width = 82
        '
        'fieldContractType
        '
        Me.fieldContractType.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldContractType.Appearance.CellTotal.Options.UseFont = True
        Me.fieldContractType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldContractType.Appearance.Header.Options.UseFont = True
        Me.fieldContractType.AreaIndex = 0
        Me.fieldContractType.Caption = "Contract Type"
        Me.fieldContractType.FieldName = "Contract Type"
        Me.fieldContractType.Name = "fieldContractType"
        Me.fieldContractType.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldContractType.Options.ShowUnboundExpressionMenu = True
        Me.fieldContractType.Width = 112
        '
        'fieldProductType
        '
        Me.fieldProductType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldProductType.Appearance.Header.Options.UseFont = True
        Me.fieldProductType.AreaIndex = 1
        Me.fieldProductType.Caption = "Product Type"
        Me.fieldProductType.FieldName = "ProductType"
        Me.fieldProductType.Name = "fieldProductType"
        Me.fieldProductType.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldProductType.Options.ShowUnboundExpressionMenu = True
        Me.fieldProductType.Width = 381
        '
        'fieldGLMasterAccountType
        '
        Me.fieldGLMasterAccountType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldGLMasterAccountType.Appearance.Header.Options.UseFont = True
        Me.fieldGLMasterAccountType.AreaIndex = 4
        Me.fieldGLMasterAccountType.Caption = "GLMaster / Account Type"
        Me.fieldGLMasterAccountType.FieldName = "GLMaster / Account Type"
        Me.fieldGLMasterAccountType.Name = "fieldGLMasterAccountType"
        Me.fieldGLMasterAccountType.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldGLMasterAccountType.Options.ShowUnboundExpressionMenu = True
        Me.fieldGLMasterAccountType.Visible = False
        '
        'FieldType
        '
        Me.FieldType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldType.Appearance.Header.Options.UseFont = True
        Me.FieldType.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.FieldType.AreaIndex = 1
        Me.FieldType.Caption = "Type"
        Me.FieldType.FieldName = "Type"
        Me.FieldType.Name = "FieldType"
        Me.FieldType.UnboundFieldName = "PivotGridField3"
        '
        'fieldPrincipalAmountValueBalance
        '
        Me.fieldPrincipalAmountValueBalance.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPrincipalAmountValueBalance.Appearance.CellTotal.Options.UseFont = True
        Me.fieldPrincipalAmountValueBalance.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPrincipalAmountValueBalance.Appearance.Header.Options.UseFont = True
        Me.fieldPrincipalAmountValueBalance.AreaIndex = 0
        Me.fieldPrincipalAmountValueBalance.Caption = "Principal Amount (Orig CUR)"
        Me.fieldPrincipalAmountValueBalance.CellFormat.FormatString = "n2"
        Me.fieldPrincipalAmountValueBalance.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldPrincipalAmountValueBalance.EmptyCellText = "0,00"
        Me.fieldPrincipalAmountValueBalance.EmptyValueText = "0,00"
        Me.fieldPrincipalAmountValueBalance.FieldName = "Principal Amount/Value Balance"
        Me.fieldPrincipalAmountValueBalance.Name = "fieldPrincipalAmountValueBalance"
        Me.fieldPrincipalAmountValueBalance.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldPrincipalAmountValueBalance.Options.ShowUnboundExpressionMenu = True
        Me.fieldPrincipalAmountValueBalance.Visible = False
        Me.fieldPrincipalAmountValueBalance.Width = 174
        '
        'fieldPrincipalAmountValueBalanceEUREqu
        '
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.CellTotal.Options.UseFont = True
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.Header.Options.UseFont = True
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.Header.Options.UseTextOptions = True
        Me.fieldPrincipalAmountValueBalanceEUREqu.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.fieldPrincipalAmountValueBalanceEUREqu.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldPrincipalAmountValueBalanceEUREqu.AreaIndex = 0
        Me.fieldPrincipalAmountValueBalanceEUREqu.Caption = "Principal Amount (EUR Equ)"
        Me.fieldPrincipalAmountValueBalanceEUREqu.CellFormat.FormatString = "n2"
        Me.fieldPrincipalAmountValueBalanceEUREqu.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldPrincipalAmountValueBalanceEUREqu.EmptyCellText = "0,00"
        Me.fieldPrincipalAmountValueBalanceEUREqu.EmptyValueText = "0,00"
        Me.fieldPrincipalAmountValueBalanceEUREqu.FieldName = "Principal Amount/Value Balance(EUR Equ)"
        Me.fieldPrincipalAmountValueBalanceEUREqu.Name = "fieldPrincipalAmountValueBalanceEUREqu"
        Me.fieldPrincipalAmountValueBalanceEUREqu.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldPrincipalAmountValueBalanceEUREqu.RunningTotal = True
        Me.fieldPrincipalAmountValueBalanceEUREqu.TotalCellFormat.FormatString = "n2"
        Me.fieldPrincipalAmountValueBalanceEUREqu.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldPrincipalAmountValueBalanceEUREqu.Width = 193
        '
        'fieldRISKDATE
        '
        Me.fieldRISKDATE.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldRISKDATE.Appearance.Header.Options.UseFont = True
        Me.fieldRISKDATE.Appearance.Header.Options.UseTextOptions = True
        Me.fieldRISKDATE.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.fieldRISKDATE.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fieldRISKDATE.Appearance.Value.Options.UseFont = True
        Me.fieldRISKDATE.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldRISKDATE.AreaIndex = 0
        Me.fieldRISKDATE.Caption = "Business Date"
        Me.fieldRISKDATE.CellFormat.FormatString = "d"
        Me.fieldRISKDATE.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fieldRISKDATE.FieldName = "RISK DATE"
        Me.fieldRISKDATE.Name = "fieldRISKDATE"
        Me.fieldRISKDATE.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.fieldRISKDATE.Options.ShowGrandTotal = False
        Me.fieldRISKDATE.Options.ShowUnboundExpressionMenu = True
        Me.fieldRISKDATE.ValueFormat.FormatString = "d"
        Me.fieldRISKDATE.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'FieldClientType
        '
        Me.FieldClientType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldClientType.Appearance.Header.Options.UseFont = True
        Me.FieldClientType.AreaIndex = 9
        Me.FieldClientType.Caption = "Client Type"
        Me.FieldClientType.FieldName = "ClientType"
        Me.FieldClientType.Name = "FieldClientType"
        '
        'FieldCOUNTRY_OF_REGISTRATION
        '
        Me.FieldCOUNTRY_OF_REGISTRATION.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCOUNTRY_OF_REGISTRATION.Appearance.Header.Options.UseFont = True
        Me.FieldCOUNTRY_OF_REGISTRATION.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldCOUNTRY_OF_REGISTRATION.AreaIndex = 3
        Me.FieldCOUNTRY_OF_REGISTRATION.Caption = "Country of Registration"
        Me.FieldCOUNTRY_OF_REGISTRATION.FieldName = "COUNTRY_OF_REGISTRATION"
        Me.FieldCOUNTRY_OF_REGISTRATION.Name = "FieldCOUNTRY_OF_REGISTRATION"
        Me.FieldCOUNTRY_OF_REGISTRATION.Visible = False
        '
        'FieldCOUNTRY_OF_RESIDENCE
        '
        Me.FieldCOUNTRY_OF_RESIDENCE.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCOUNTRY_OF_RESIDENCE.Appearance.Header.Options.UseFont = True
        Me.FieldCOUNTRY_OF_RESIDENCE.AreaIndex = 10
        Me.FieldCOUNTRY_OF_RESIDENCE.Caption = "Country of Residence"
        Me.FieldCOUNTRY_OF_RESIDENCE.FieldName = "COUNTRY_OF_RESIDENCE"
        Me.FieldCOUNTRY_OF_RESIDENCE.Name = "FieldCOUNTRY_OF_RESIDENCE"
        Me.FieldCOUNTRY_OF_RESIDENCE.Visible = False
        '
        'FieldINDUSTRIAL_CLASS_CN
        '
        Me.FieldINDUSTRIAL_CLASS_CN.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldINDUSTRIAL_CLASS_CN.Appearance.Header.Options.UseFont = True
        Me.FieldINDUSTRIAL_CLASS_CN.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldINDUSTRIAL_CLASS_CN.AreaIndex = 4
        Me.FieldINDUSTRIAL_CLASS_CN.Caption = "Industrial Class (CHINA)"
        Me.FieldINDUSTRIAL_CLASS_CN.FieldName = "INDUSTRIAL_CLASS_CN"
        Me.FieldINDUSTRIAL_CLASS_CN.Name = "FieldINDUSTRIAL_CLASS_CN"
        Me.FieldINDUSTRIAL_CLASS_CN.Visible = False
        '
        'FieldCCB_Group
        '
        Me.FieldCCB_Group.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCCB_Group.Appearance.Header.Options.UseFont = True
        Me.FieldCCB_Group.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCCB_Group.Appearance.Value.Options.UseFont = True
        Me.FieldCCB_Group.Appearance.Value.Options.UseTextOptions = True
        Me.FieldCCB_Group.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldCCB_Group.AreaIndex = 10
        Me.FieldCCB_Group.Caption = "CCB Group"
        Me.FieldCCB_Group.FieldName = "CCB_Group"
        Me.FieldCCB_Group.Name = "FieldCCB_Group"
        Me.FieldCCB_Group.Options.ReadOnly = True
        '
        'FieldCCB_Group_OwnID
        '
        Me.FieldCCB_Group_OwnID.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCCB_Group_OwnID.Appearance.Header.Options.UseFont = True
        Me.FieldCCB_Group_OwnID.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCCB_Group_OwnID.Appearance.Value.Options.UseFont = True
        Me.FieldCCB_Group_OwnID.Appearance.Value.Options.UseTextOptions = True
        Me.FieldCCB_Group_OwnID.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldCCB_Group_OwnID.AreaIndex = 12
        Me.FieldCCB_Group_OwnID.Caption = "CCB Group (Own ID)"
        Me.FieldCCB_Group_OwnID.FieldName = "CCB_Group_OwnID"
        Me.FieldCCB_Group_OwnID.Name = "FieldCCB_Group_OwnID"
        '
        'FieldEU_EEA
        '
        Me.FieldEU_EEA.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldEU_EEA.Appearance.Header.Options.UseFont = True
        Me.FieldEU_EEA.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldEU_EEA.Appearance.Value.Options.UseFont = True
        Me.FieldEU_EEA.Appearance.Value.Options.UseTextOptions = True
        Me.FieldEU_EEA.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldEU_EEA.AreaIndex = 13
        Me.FieldEU_EEA.Caption = "EU Country"
        Me.FieldEU_EEA.FieldName = "EU EEA"
        Me.FieldEU_EEA.Name = "FieldEU_EEA"
        '
        'FieldEWU
        '
        Me.FieldEWU.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldEWU.Appearance.Header.Options.UseFont = True
        Me.FieldEWU.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldEWU.Appearance.Value.Options.UseFont = True
        Me.FieldEWU.Appearance.Value.Options.UseTextOptions = True
        Me.FieldEWU.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldEWU.AreaIndex = 14
        Me.FieldEWU.Caption = "EWU Country"
        Me.FieldEWU.FieldName = "EWU"
        Me.FieldEWU.Name = "FieldEWU"
        '
        'FieldIsBank
        '
        Me.FieldIsBank.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldIsBank.Appearance.Header.Options.UseFont = True
        Me.FieldIsBank.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldIsBank.Appearance.Value.Options.UseFont = True
        Me.FieldIsBank.Appearance.Value.Options.UseTextOptions = True
        Me.FieldIsBank.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldIsBank.AreaIndex = 15
        Me.FieldIsBank.Caption = "Bank / No Bank"
        Me.FieldIsBank.FieldName = "Is Bank"
        Me.FieldIsBank.Name = "FieldIsBank"
        '
        'FieldLANDKZ_BUBA
        '
        Me.FieldLANDKZ_BUBA.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldLANDKZ_BUBA.Appearance.Header.Options.UseFont = True
        Me.FieldLANDKZ_BUBA.AreaIndex = 18
        Me.FieldLANDKZ_BUBA.Caption = "Landkennz. Bundesbank"
        Me.FieldLANDKZ_BUBA.FieldName = "LANDKZ BUBA"
        Me.FieldLANDKZ_BUBA.Name = "FieldLANDKZ_BUBA"
        Me.FieldLANDKZ_BUBA.Visible = False
        '
        'FieldCOUNTRY_NAME
        '
        Me.FieldCOUNTRY_NAME.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCOUNTRY_NAME.Appearance.Header.Options.UseFont = True
        Me.FieldCOUNTRY_NAME.AreaIndex = 16
        Me.FieldCOUNTRY_NAME.Caption = "Country Name"
        Me.FieldCOUNTRY_NAME.FieldName = "COUNTRY NAME"
        Me.FieldCOUNTRY_NAME.Name = "FieldCOUNTRY_NAME"
        Me.FieldCOUNTRY_NAME.Visible = False
        '
        'FieldStartDate
        '
        Me.FieldStartDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldStartDate.Appearance.Header.Options.UseFont = True
        Me.FieldStartDate.AreaIndex = 5
        Me.FieldStartDate.Caption = "Start Date"
        Me.FieldStartDate.CellFormat.FormatString = "d"
        Me.FieldStartDate.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FieldStartDate.FieldName = "StartDate"
        Me.FieldStartDate.Name = "FieldStartDate"
        Me.FieldStartDate.ValueFormat.FormatString = "d"
        Me.FieldStartDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'FieldBusinessType
        '
        Me.FieldBusinessType.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldBusinessType.Appearance.Header.Options.UseFont = True
        Me.FieldBusinessType.AreaIndex = 2
        Me.FieldBusinessType.Caption = "Business Type"
        Me.FieldBusinessType.FieldName = "BusinessType"
        Me.FieldBusinessType.Name = "FieldBusinessType"
        '
        'FieldInterestRate
        '
        Me.FieldInterestRate.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestRate.Appearance.CellTotal.Options.UseFont = True
        Me.FieldInterestRate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestRate.Appearance.Header.Options.UseFont = True
        Me.FieldInterestRate.AreaIndex = 17
        Me.FieldInterestRate.Caption = "Interest Rate"
        Me.FieldInterestRate.CellFormat.FormatString = "n6"
        Me.FieldInterestRate.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        PivotGridCustomTotal1.CellFormat.FormatString = "n6"
        PivotGridCustomTotal1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        PivotGridCustomTotal1.Format.FormatString = "n6"
        PivotGridCustomTotal1.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        PivotGridCustomTotal1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
        Me.FieldInterestRate.CustomTotals.AddRange(New DevExpress.XtraPivotGrid.PivotGridCustomTotal() {PivotGridCustomTotal1})
        Me.FieldInterestRate.EmptyCellText = "0"
        Me.FieldInterestRate.EmptyValueText = "0"
        Me.FieldInterestRate.FieldName = "InterestRate"
        Me.FieldInterestRate.Name = "FieldInterestRate"
        Me.FieldInterestRate.Options.AllowEdit = False
        Me.FieldInterestRate.Options.ReadOnly = True
        Me.FieldInterestRate.Options.ShowGrandTotal = False
        Me.FieldInterestRate.Options.ShowTotals = False
        Me.FieldInterestRate.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
        Me.FieldInterestRate.ToolTips.HeaderText = "Imported from FRISTEN Report"
        Me.FieldInterestRate.ToolTips.ValueText = "Imported from FRISTEN Report"
        Me.FieldInterestRate.ValueFormat.FormatString = "n6"
        Me.FieldInterestRate.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'FieldInterestAmountOrigCur
        '
        Me.FieldInterestAmountOrigCur.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestAmountOrigCur.Appearance.CellTotal.Options.UseFont = True
        Me.FieldInterestAmountOrigCur.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestAmountOrigCur.Appearance.Header.Options.UseFont = True
        Me.FieldInterestAmountOrigCur.AreaIndex = 18
        Me.FieldInterestAmountOrigCur.Caption = "Interest Amount (OrigCur)"
        Me.FieldInterestAmountOrigCur.CellFormat.FormatString = "n2"
        Me.FieldInterestAmountOrigCur.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldInterestAmountOrigCur.EmptyCellText = "0"
        Me.FieldInterestAmountOrigCur.EmptyValueText = "0"
        Me.FieldInterestAmountOrigCur.FieldName = "InterestAmountOrigCur"
        Me.FieldInterestAmountOrigCur.Name = "FieldInterestAmountOrigCur"
        Me.FieldInterestAmountOrigCur.Options.AllowEdit = False
        Me.FieldInterestAmountOrigCur.Options.ReadOnly = True
        Me.FieldInterestAmountOrigCur.ToolTips.HeaderText = "Imported from FRISTEN Report (Amount Type:Interest)-EURO Equivalent"
        Me.FieldInterestAmountOrigCur.ToolTips.ValueText = "Imported from FRISTEN Report (Amount Type:Interest)-EURO Equivalent"
        Me.FieldInterestAmountOrigCur.ValueFormat.FormatString = "n2"
        Me.FieldInterestAmountOrigCur.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldInterestAmountOrigCur.Visible = False
        '
        'FieldInterestAmountEuro
        '
        Me.FieldInterestAmountEuro.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestAmountEuro.Appearance.CellTotal.Options.UseFont = True
        Me.FieldInterestAmountEuro.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldInterestAmountEuro.Appearance.Header.Options.UseFont = True
        Me.FieldInterestAmountEuro.AreaIndex = 18
        Me.FieldInterestAmountEuro.Caption = "Interest Amount (Euro)"
        Me.FieldInterestAmountEuro.CellFormat.FormatString = "n2"
        Me.FieldInterestAmountEuro.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldInterestAmountEuro.EmptyCellText = "0"
        Me.FieldInterestAmountEuro.EmptyValueText = "0"
        Me.FieldInterestAmountEuro.FieldName = "InterestAmountEuro"
        Me.FieldInterestAmountEuro.Name = "FieldInterestAmountEuro"
        Me.FieldInterestAmountEuro.Options.AllowEdit = False
        Me.FieldInterestAmountEuro.Options.ReadOnly = True
        Me.FieldInterestAmountEuro.ValueFormat.FormatString = "n2"
        Me.FieldInterestAmountEuro.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'UB_FieldSumInOutflowEUR
        '
        Me.UB_FieldSumInOutflowEUR.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowEUR.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UB_FieldSumInOutflowEUR.Appearance.Cell.Options.UseFont = True
        Me.UB_FieldSumInOutflowEUR.Appearance.Cell.Options.UseForeColor = True
        Me.UB_FieldSumInOutflowEUR.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowEUR.Appearance.CellTotal.Options.UseFont = True
        Me.UB_FieldSumInOutflowEUR.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowEUR.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.UB_FieldSumInOutflowEUR.Appearance.Header.Options.UseFont = True
        Me.UB_FieldSumInOutflowEUR.Appearance.Header.Options.UseForeColor = True
        Me.UB_FieldSumInOutflowEUR.AreaIndex = 19
        Me.UB_FieldSumInOutflowEUR.Caption = "Sum In- Outflow (EUR)"
        Me.UB_FieldSumInOutflowEUR.CellFormat.FormatString = "n2"
        Me.UB_FieldSumInOutflowEUR.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UB_FieldSumInOutflowEUR.EmptyCellText = "0"
        Me.UB_FieldSumInOutflowEUR.EmptyValueText = "0"
        Me.UB_FieldSumInOutflowEUR.Name = "UB_FieldSumInOutflowEUR"
        Me.UB_FieldSumInOutflowEUR.Options.AllowEdit = False
        Me.UB_FieldSumInOutflowEUR.Options.ReadOnly = True
        Me.UB_FieldSumInOutflowEUR.Options.ShowUnboundExpressionMenu = True
        Me.UB_FieldSumInOutflowEUR.ToolTips.HeaderText = "[Principal Amount (EUR Equ)] + [Interest Amount Euro]"
        Me.UB_FieldSumInOutflowEUR.UnboundExpression = "[Principal Amount/Value Balance(EUR Equ)] + [InterestAmountEuro]"
        Me.UB_FieldSumInOutflowEUR.UnboundFieldName = "UB_FieldSumInOutflow"
        Me.UB_FieldSumInOutflowEUR.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.UB_FieldSumInOutflowEUR.ValueFormat.FormatString = "n2"
        Me.UB_FieldSumInOutflowEUR.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'UB_FieldSumInOutflowCUR
        '
        Me.UB_FieldSumInOutflowCUR.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowCUR.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UB_FieldSumInOutflowCUR.Appearance.Cell.Options.UseFont = True
        Me.UB_FieldSumInOutflowCUR.Appearance.Cell.Options.UseForeColor = True
        Me.UB_FieldSumInOutflowCUR.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowCUR.Appearance.CellTotal.Options.UseFont = True
        Me.UB_FieldSumInOutflowCUR.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_FieldSumInOutflowCUR.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.UB_FieldSumInOutflowCUR.Appearance.Header.Options.UseFont = True
        Me.UB_FieldSumInOutflowCUR.Appearance.Header.Options.UseForeColor = True
        Me.UB_FieldSumInOutflowCUR.AreaIndex = 20
        Me.UB_FieldSumInOutflowCUR.Caption = "Sum In- Outflow (Orig.CUR)"
        Me.UB_FieldSumInOutflowCUR.CellFormat.FormatString = "n2"
        Me.UB_FieldSumInOutflowCUR.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UB_FieldSumInOutflowCUR.EmptyCellText = "0,00"
        Me.UB_FieldSumInOutflowCUR.EmptyValueText = "0,00"
        Me.UB_FieldSumInOutflowCUR.Name = "UB_FieldSumInOutflowCUR"
        Me.UB_FieldSumInOutflowCUR.Options.AllowEdit = False
        Me.UB_FieldSumInOutflowCUR.Options.ReadOnly = True
        Me.UB_FieldSumInOutflowCUR.Options.ShowUnboundExpressionMenu = True
        Me.UB_FieldSumInOutflowCUR.ToolTips.HeaderText = "[Principal Amount (Orig CUR)] + [Interest Amount Orig Cur]"
        Me.UB_FieldSumInOutflowCUR.UnboundExpression = "[Principal Amount/Value Balance] + [InterestAmountOrigCur]"
        Me.UB_FieldSumInOutflowCUR.UnboundFieldName = "UB_FieldSumInOutflowCUR"
        Me.UB_FieldSumInOutflowCUR.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.UB_FieldSumInOutflowCUR.ValueFormat.FormatString = "n2"
        Me.UB_FieldSumInOutflowCUR.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UB_FieldSumInOutflowCUR.Visible = False
        '
        'UB_PrincipalInterestEUR
        '
        Me.UB_PrincipalInterestEUR.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_PrincipalInterestEUR.Appearance.CellTotal.Options.UseFont = True
        Me.UB_PrincipalInterestEUR.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UB_PrincipalInterestEUR.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.UB_PrincipalInterestEUR.Appearance.Header.Options.UseFont = True
        Me.UB_PrincipalInterestEUR.Appearance.Header.Options.UseForeColor = True
        Me.UB_PrincipalInterestEUR.AreaIndex = 23
        Me.UB_PrincipalInterestEUR.Caption = "Sum Principal + Accrueds (EUR)"
        Me.UB_PrincipalInterestEUR.CellFormat.FormatString = "n2"
        Me.UB_PrincipalInterestEUR.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UB_PrincipalInterestEUR.Name = "UB_PrincipalInterestEUR"
        Me.UB_PrincipalInterestEUR.Options.AllowEdit = False
        Me.UB_PrincipalInterestEUR.Options.ReadOnly = True
        Me.UB_PrincipalInterestEUR.Options.ShowUnboundExpressionMenu = True
        Me.UB_PrincipalInterestEUR.ToolTips.HeaderText = "If [Next EventType]<>'IS' (INTEREST AMOUNT) then [Principal Amount (EUR Equ)] + [" &
    "Accrued Interest Amount (EUR)] else 0"
        Me.UB_PrincipalInterestEUR.UnboundExpression = "Iif([Next EventType] <> 'IS', [Principal Amount/Value Balance(EUR Equ)] + [Accrue" &
    "dInterestAmountEUR], 0)"
        Me.UB_PrincipalInterestEUR.UnboundFieldName = "UB_PrincipalInterestEUR"
        Me.UB_PrincipalInterestEUR.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.UB_PrincipalInterestEUR.ValueFormat.FormatString = "n2"
        Me.UB_PrincipalInterestEUR.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'FieldINDUSTRIAL_CLASS_LOCAL
        '
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Appearance.CellTotal.Options.UseFont = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Appearance.Header.Options.UseFont = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL.AreaIndex = 13
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Caption = "Industrial Class Code (Local)"
        Me.FieldINDUSTRIAL_CLASS_LOCAL.FieldName = "INDUSTRIAL_CLASS_LOCAL"
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Name = "FieldINDUSTRIAL_CLASS_LOCAL"
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Options.AllowEdit = False
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Options.ReadOnly = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL.Visible = False
        '
        'FieldINDUSTRIAL_CLASS_LOCAL_NAME
        '
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Appearance.CellTotal.Options.UseFont = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Appearance.Header.Options.UseFont = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.AreaIndex = 13
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Caption = "Industrial Class Name (Local)"
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.FieldName = "INDUSTRIAL_CLASS_LOCAL_NAME"
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Name = "FieldINDUSTRIAL_CLASS_LOCAL_NAME"
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Options.AllowEdit = False
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Options.ReadOnly = True
        Me.FieldINDUSTRIAL_CLASS_LOCAL_NAME.Visible = False
        '
        'FieldAccruedInterestAmountEUR
        '
        Me.FieldAccruedInterestAmountEUR.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldAccruedInterestAmountEUR.Appearance.Cell.Options.UseForeColor = True
        Me.FieldAccruedInterestAmountEUR.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAccruedInterestAmountEUR.Appearance.CellTotal.Options.UseFont = True
        Me.FieldAccruedInterestAmountEUR.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAccruedInterestAmountEUR.Appearance.Header.Options.UseFont = True
        Me.FieldAccruedInterestAmountEUR.Appearance.Value.ForeColor = System.Drawing.Color.Navy
        Me.FieldAccruedInterestAmountEUR.Appearance.Value.Options.UseForeColor = True
        Me.FieldAccruedInterestAmountEUR.AreaIndex = 20
        Me.FieldAccruedInterestAmountEUR.Caption = "Accrued Interest Amount (EUR)"
        Me.FieldAccruedInterestAmountEUR.CellFormat.FormatString = "n2"
        Me.FieldAccruedInterestAmountEUR.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldAccruedInterestAmountEUR.EmptyCellText = "0,00"
        Me.FieldAccruedInterestAmountEUR.EmptyValueText = "0,00"
        Me.FieldAccruedInterestAmountEUR.FieldName = "AccruedInterestAmountEUR"
        Me.FieldAccruedInterestAmountEUR.Name = "FieldAccruedInterestAmountEUR"
        Me.FieldAccruedInterestAmountEUR.Options.AllowEdit = False
        Me.FieldAccruedInterestAmountEUR.Options.ReadOnly = True
        Me.FieldAccruedInterestAmountEUR.ValueFormat.FormatString = "n2"
        Me.FieldAccruedInterestAmountEUR.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'FieldAccruedInterestAmountOrigCur
        '
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Cell.Options.UseForeColor = True
        Me.FieldAccruedInterestAmountOrigCur.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAccruedInterestAmountOrigCur.Appearance.CellTotal.Options.UseFont = True
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Header.Options.UseFont = True
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Value.ForeColor = System.Drawing.Color.Navy
        Me.FieldAccruedInterestAmountOrigCur.Appearance.Value.Options.UseForeColor = True
        Me.FieldAccruedInterestAmountOrigCur.AreaIndex = 21
        Me.FieldAccruedInterestAmountOrigCur.Caption = "Accrued Interest Amount (OrigCur)"
        Me.FieldAccruedInterestAmountOrigCur.CellFormat.FormatString = "n2"
        Me.FieldAccruedInterestAmountOrigCur.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldAccruedInterestAmountOrigCur.EmptyCellText = "0,00"
        Me.FieldAccruedInterestAmountOrigCur.EmptyValueText = "0,00"
        Me.FieldAccruedInterestAmountOrigCur.FieldName = "AccruedInterestAmountOrigCur"
        Me.FieldAccruedInterestAmountOrigCur.Name = "FieldAccruedInterestAmountOrigCur"
        Me.FieldAccruedInterestAmountOrigCur.Options.AllowEdit = False
        Me.FieldAccruedInterestAmountOrigCur.Options.ReadOnly = True
        Me.FieldAccruedInterestAmountOrigCur.ValueFormat.FormatString = "n2"
        Me.FieldAccruedInterestAmountOrigCur.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldAccruedInterestAmountOrigCur.Visible = False
        '
        'FieldAverageDuration
        '
        Me.FieldAverageDuration.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAverageDuration.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldAverageDuration.Appearance.Cell.Options.UseFont = True
        Me.FieldAverageDuration.Appearance.Cell.Options.UseForeColor = True
        Me.FieldAverageDuration.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAverageDuration.Appearance.CellTotal.Options.UseFont = True
        Me.FieldAverageDuration.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAverageDuration.Appearance.Header.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FieldAverageDuration.Appearance.Header.Options.UseFont = True
        Me.FieldAverageDuration.Appearance.Header.Options.UseForeColor = True
        Me.FieldAverageDuration.Appearance.Header.Options.UseImage = True
        Me.FieldAverageDuration.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldAverageDuration.Appearance.Value.Options.UseFont = True
        Me.FieldAverageDuration.AreaIndex = 21
        Me.FieldAverageDuration.Caption = "Average Duration"
        Me.FieldAverageDuration.CellFormat.FormatString = "n2"
        Me.FieldAverageDuration.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldAverageDuration.EmptyCellText = "0,00"
        Me.FieldAverageDuration.EmptyValueText = "0,00"
        Me.FieldAverageDuration.FieldName = "AverageDuration"
        Me.FieldAverageDuration.Name = "FieldAverageDuration"
        Me.FieldAverageDuration.Options.AllowEdit = False
        Me.FieldAverageDuration.Options.ReadOnly = True
        Me.FieldAverageDuration.ToolTips.HeaderText = "AVERAGE DURATION Calculation:Days Count from Business Date till Next Event Date x" &
    " Principal Amount(EUR)/Sum Principal Amount EUR by Currency, Period and Type"
        Me.FieldAverageDuration.ToolTips.ValueText = "Calculation:Days Count from Business Date till Next Event Date x Principal Amount" &
    "(EUR)/Sum Principal Amount EUR by Currency, Period and Type"
        Me.FieldAverageDuration.ValueFormat.FormatString = "n2"
        Me.FieldAverageDuration.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'FieldDaysToEventDate
        '
        Me.FieldDaysToEventDate.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToEventDate.Appearance.Cell.Options.UseFont = True
        Me.FieldDaysToEventDate.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToEventDate.Appearance.CellTotal.Options.UseFont = True
        Me.FieldDaysToEventDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToEventDate.Appearance.Header.Options.UseFont = True
        Me.FieldDaysToEventDate.Appearance.Header.Options.UseImage = True
        Me.FieldDaysToEventDate.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToEventDate.Appearance.Value.Options.UseFont = True
        Me.FieldDaysToEventDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldDaysToEventDate.AreaIndex = 2
        Me.FieldDaysToEventDate.Caption = "Days Count till next Event Date"
        Me.FieldDaysToEventDate.CellFormat.FormatString = "n0"
        Me.FieldDaysToEventDate.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldDaysToEventDate.EmptyCellText = "0"
        Me.FieldDaysToEventDate.EmptyValueText = "0"
        Me.FieldDaysToEventDate.FieldName = "DaysToEventDate"
        Me.FieldDaysToEventDate.Name = "FieldDaysToEventDate"
        Me.FieldDaysToEventDate.Options.AllowEdit = False
        Me.FieldDaysToEventDate.Options.ReadOnly = True
        Me.FieldDaysToEventDate.ToolTips.HeaderText = "Days Count from current Business Date till Next Event Date"
        Me.FieldDaysToEventDate.ToolTips.ValueText = "Days Count from current Business Date till Next Event Date"
        Me.FieldDaysToEventDate.Visible = False
        '
        'FieldPERIOD_Additional
        '
        Me.FieldPERIOD_Additional.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_Additional.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FieldPERIOD_Additional.Appearance.Cell.Options.UseFont = True
        Me.FieldPERIOD_Additional.Appearance.Cell.Options.UseForeColor = True
        Me.FieldPERIOD_Additional.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_Additional.Appearance.CellTotal.Options.UseFont = True
        Me.FieldPERIOD_Additional.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_Additional.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.FieldPERIOD_Additional.Appearance.Header.Options.UseFont = True
        Me.FieldPERIOD_Additional.Appearance.Header.Options.UseForeColor = True
        Me.FieldPERIOD_Additional.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_Additional.Appearance.Value.Options.UseFont = True
        Me.FieldPERIOD_Additional.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldPERIOD_Additional.AreaIndex = 2
        Me.FieldPERIOD_Additional.Caption = "Additional Period (Next Event Date)"
        Me.FieldPERIOD_Additional.FieldName = "PERIOD_Additional"
        Me.FieldPERIOD_Additional.Name = "FieldPERIOD_Additional"
        Me.FieldPERIOD_Additional.Options.AllowEdit = False
        Me.FieldPERIOD_Additional.Options.ReadOnly = True
        Me.FieldPERIOD_Additional.ToolTips.HeaderText = "Additional Maturity Periods (According to AMM Report)"
        Me.FieldPERIOD_Additional.ToolTips.ValueText = "Additional Maturity Periods (According to AMM Report)"
        Me.FieldPERIOD_Additional.Visible = False
        '
        'FieldDaysToMaturity
        '
        Me.FieldDaysToMaturity.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToMaturity.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FieldDaysToMaturity.Appearance.Cell.Options.UseFont = True
        Me.FieldDaysToMaturity.Appearance.Cell.Options.UseForeColor = True
        Me.FieldDaysToMaturity.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToMaturity.Appearance.CellTotal.Options.UseFont = True
        Me.FieldDaysToMaturity.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToMaturity.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.FieldDaysToMaturity.Appearance.Header.Options.UseFont = True
        Me.FieldDaysToMaturity.Appearance.Header.Options.UseForeColor = True
        Me.FieldDaysToMaturity.Appearance.Header.Options.UseImage = True
        Me.FieldDaysToMaturity.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldDaysToMaturity.Appearance.Value.Options.UseFont = True
        Me.FieldDaysToMaturity.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldDaysToMaturity.AreaIndex = 2
        Me.FieldDaysToMaturity.Caption = "Days To Maturity"
        Me.FieldDaysToMaturity.CellFormat.FormatString = "n0"
        Me.FieldDaysToMaturity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldDaysToMaturity.FieldName = "DaysToMaturity"
        Me.FieldDaysToMaturity.Name = "FieldDaysToMaturity"
        Me.FieldDaysToMaturity.Options.AllowEdit = False
        Me.FieldDaysToMaturity.Options.ReadOnly = True
        Me.FieldDaysToMaturity.ToolTips.HeaderText = "Days Count from current Business Date till Final Maturity (If Final Maturity is n" &
    "ot NULL)"
        Me.FieldDaysToMaturity.ToolTips.ValueText = "Days Count from current Business Date till Final Maturity (If Final Maturity is n" &
    "ot NULL)"
        Me.FieldDaysToMaturity.ValueFormat.FormatString = "n0"
        Me.FieldDaysToMaturity.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FieldDaysToMaturity.Visible = False
        '
        'FieldPERIOD_MaturityDate
        '
        Me.FieldPERIOD_MaturityDate.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_MaturityDate.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldPERIOD_MaturityDate.Appearance.Cell.Options.UseFont = True
        Me.FieldPERIOD_MaturityDate.Appearance.Cell.Options.UseForeColor = True
        Me.FieldPERIOD_MaturityDate.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_MaturityDate.Appearance.CellTotal.Options.UseFont = True
        Me.FieldPERIOD_MaturityDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_MaturityDate.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.FieldPERIOD_MaturityDate.Appearance.Header.Options.UseFont = True
        Me.FieldPERIOD_MaturityDate.Appearance.Header.Options.UseForeColor = True
        Me.FieldPERIOD_MaturityDate.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldPERIOD_MaturityDate.Appearance.Value.Options.UseFont = True
        Me.FieldPERIOD_MaturityDate.AreaIndex = 22
        Me.FieldPERIOD_MaturityDate.Caption = "PERIOD (Maturity Date)"
        Me.FieldPERIOD_MaturityDate.FieldName = "PERIOD_MaturityDate"
        Me.FieldPERIOD_MaturityDate.Name = "FieldPERIOD_MaturityDate"
        Me.FieldPERIOD_MaturityDate.Options.AllowEdit = False
        Me.FieldPERIOD_MaturityDate.Options.ReadOnly = True
        Me.FieldPERIOD_MaturityDate.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
        Me.FieldPERIOD_MaturityDate.ToolTips.HeaderText = "Calculated PERIOD based on the contracts Maturity Date"
        '
        'FieldALMMPeriod_MaturityDate
        '
        Me.FieldALMMPeriod_MaturityDate.Appearance.Cell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldALMMPeriod_MaturityDate.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldALMMPeriod_MaturityDate.Appearance.Cell.Options.UseFont = True
        Me.FieldALMMPeriod_MaturityDate.Appearance.Cell.Options.UseForeColor = True
        Me.FieldALMMPeriod_MaturityDate.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldALMMPeriod_MaturityDate.Appearance.CellTotal.Options.UseFont = True
        Me.FieldALMMPeriod_MaturityDate.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldALMMPeriod_MaturityDate.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.FieldALMMPeriod_MaturityDate.Appearance.Header.Options.UseFont = True
        Me.FieldALMMPeriod_MaturityDate.Appearance.Header.Options.UseForeColor = True
        Me.FieldALMMPeriod_MaturityDate.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldALMMPeriod_MaturityDate.Appearance.Value.Options.UseFont = True
        Me.FieldALMMPeriod_MaturityDate.AreaIndex = 24
        Me.FieldALMMPeriod_MaturityDate.Caption = "ALMM Period (Maturity Date)"
        Me.FieldALMMPeriod_MaturityDate.FieldName = "PERIOD_ALMM_MaturityDate"
        Me.FieldALMMPeriod_MaturityDate.Name = "FieldALMMPeriod_MaturityDate"
        Me.FieldALMMPeriod_MaturityDate.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
        Me.FieldALMMPeriod_MaturityDate.ToolTips.HeaderText = "Calculated ALMM PERIOD based on the contracts Maturity Date"
        '
        'FieldCIC_Group
        '
        Me.FieldCIC_Group.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCIC_Group.Appearance.Header.Options.UseFont = True
        Me.FieldCIC_Group.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FieldCIC_Group.Appearance.Value.Options.UseFont = True
        Me.FieldCIC_Group.Appearance.Value.Options.UseTextOptions = True
        Me.FieldCIC_Group.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FieldCIC_Group.AreaIndex = 11
        Me.FieldCIC_Group.Caption = "CIC Group"
        Me.FieldCIC_Group.FieldName = "CIC_Group"
        Me.FieldCIC_Group.Name = "FieldCIC_Group"
        Me.FieldCIC_Group.Options.ReadOnly = True
        Me.FieldCIC_Group.ToolTips.HeaderText = "Member of the CHINA INVESTMENT CORP."
        '
        'GroupRepositoryItemImageComboBox
        '
        Me.GroupRepositoryItemImageComboBox.AutoHeight = False
        Me.GroupRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GroupRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 9)})
        Me.GroupRepositoryItemImageComboBox.Name = "GroupRepositoryItemImageComboBox"
        Me.GroupRepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.PivotGridControl2
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'PivotGridControl2
        '
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseBackColor = True
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseFont = True
        Me.PivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseForeColor = True
        Me.PivotGridControl2.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.PivotGridControl2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.PivotGridControl2.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl2.Appearance.FocusedCell.Options.UseBackColor = True
        Me.PivotGridControl2.Appearance.FocusedCell.Options.UseFont = True
        Me.PivotGridControl2.Appearance.FocusedCell.Options.UseForeColor = True
        Me.PivotGridControl2.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PivotGridControl2.Appearance.GrandTotalCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridControl2.Appearance.GrandTotalCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl2.Appearance.GrandTotalCell.Options.UseBackColor = True
        Me.PivotGridControl2.Appearance.GrandTotalCell.Options.UseFont = True
        Me.PivotGridControl2.Appearance.GrandTotalCell.Options.UseForeColor = True
        Me.PivotGridControl2.Appearance.SelectedCell.BackColor = System.Drawing.Color.Yellow
        Me.PivotGridControl2.Appearance.SelectedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.PivotGridControl2.Appearance.SelectedCell.ForeColor = System.Drawing.Color.Black
        Me.PivotGridControl2.Appearance.SelectedCell.Options.UseBackColor = True
        Me.PivotGridControl2.Appearance.SelectedCell.Options.UseForeColor = True
        Me.PivotGridControl2.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridControl2.Appearance.TotalCell.Options.UseBackColor = True
        Me.PivotGridControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PivotGridControl2.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.PivotGridField4, Me.PivotGridField5, Me.PivotGridField8, Me.PivotGridField9, Me.PivotGridField11, Me.PivotGridField17, Me.PivotGridField1})
        PivotGridFormatRule1.Measure = Me.PivotGridField17
        PivotGridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue1.Value1 = 0R
        PivotGridFormatRule1.Rule = FormatConditionRuleValue1
        PivotGridFormatRule1.Settings = FormatRuleTotalTypeSettings1
        PivotGridFormatRule2.Measure = Me.PivotGridField17
        PivotGridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = 0R
        PivotGridFormatRule2.Rule = FormatConditionRuleValue2
        PivotGridFormatRule2.Settings = FormatRuleTotalTypeSettings2
        Me.PivotGridControl2.FormatRules.Add(PivotGridFormatRule1)
        Me.PivotGridControl2.FormatRules.Add(PivotGridFormatRule2)
        PivotGridGroup1.Fields.Add(Me.PivotGridField11)
        Me.PivotGridControl2.Groups.AddRange(New DevExpress.XtraPivotGrid.PivotGridGroup() {PivotGridGroup1})
        Me.PivotGridControl2.Location = New System.Drawing.Point(24, 75)
        Me.PivotGridControl2.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.PivotGridControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PivotGridControl2.Name = "PivotGridControl2"
        Me.PivotGridControl2.OptionsBehavior.CopyToClipboardWithFieldValues = True
        Me.PivotGridControl2.OptionsFilterPopup.FieldFilterPopupMode = DevExpress.XtraPivotGrid.FieldFilterPopupMode.Excel
        Me.PivotGridControl2.OptionsPrint.MergeColumnFieldValues = False
        Me.PivotGridControl2.OptionsPrint.MergeRowFieldValues = False
        Me.PivotGridControl2.OptionsPrint.PrintColumnAreaOnEveryPage = True
        Me.PivotGridControl2.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.PivotGridControl2.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.PivotGridControl2.OptionsSelection.EnableAppearanceFocusedCell = True
        Me.PivotGridControl2.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.PivotGridControl2.Size = New System.Drawing.Size(1397, 447)
        Me.PivotGridControl2.TabIndex = 2
        '
        'PivotGridField4
        '
        Me.PivotGridField4.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField4.Appearance.Header.Options.UseFont = True
        Me.PivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField4.AreaIndex = 1
        Me.PivotGridField4.Caption = "Period"
        Me.PivotGridField4.FieldName = "Period"
        Me.PivotGridField4.Name = "PivotGridField4"
        Me.PivotGridField4.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.PivotGridField4.Options.ShowUnboundExpressionMenu = True
        Me.PivotGridField4.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
        Me.PivotGridField4.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.PivotGridField4.Width = 112
        '
        'PivotGridField5
        '
        Me.PivotGridField5.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField5.Appearance.Header.Options.UseFont = True
        Me.PivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField5.AreaIndex = 0
        Me.PivotGridField5.Caption = "Currency"
        Me.PivotGridField5.FieldName = "CUR"
        Me.PivotGridField5.Name = "PivotGridField5"
        Me.PivotGridField5.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.PivotGridField5.Options.ShowUnboundExpressionMenu = True
        Me.PivotGridField5.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.PivotGridField5.Width = 464
        '
        'PivotGridField8
        '
        Me.PivotGridField8.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField8.Appearance.Header.Options.UseFont = True
        Me.PivotGridField8.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField8.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField8.AreaIndex = 0
        Me.PivotGridField8.Caption = "Balance Min"
        Me.PivotGridField8.CellFormat.FormatString = "n2"
        Me.PivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField8.EmptyCellText = "0,00"
        Me.PivotGridField8.EmptyValueText = "0,00"
        Me.PivotGridField8.FieldName = "Balance_Min"
        Me.PivotGridField8.Name = "PivotGridField8"
        Me.PivotGridField8.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.PivotGridField8.Options.ShowUnboundExpressionMenu = True
        Me.PivotGridField8.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.PivotGridField8.Width = 167
        '
        'PivotGridField9
        '
        Me.PivotGridField9.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField9.Appearance.Header.Options.UseFont = True
        Me.PivotGridField9.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField9.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField9.AreaIndex = 1
        Me.PivotGridField9.Caption = "Balance Max"
        Me.PivotGridField9.CellFormat.FormatString = "n2"
        Me.PivotGridField9.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField9.EmptyCellText = "0,00"
        Me.PivotGridField9.EmptyValueText = "0,00"
        Me.PivotGridField9.FieldName = "Balance_Max"
        Me.PivotGridField9.Name = "PivotGridField9"
        Me.PivotGridField9.Options.GroupFilterMode = DevExpress.XtraPivotGrid.PivotGroupFilterMode.Tree
        Me.PivotGridField9.Options.ShowUnboundExpressionMenu = True
        Me.PivotGridField9.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.PivotGridField9.Width = 151
        '
        'PivotGridField1
        '
        Me.PivotGridField1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PivotGridField1.Appearance.Header.Options.UseFont = True
        Me.PivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField1.AreaIndex = 2
        Me.PivotGridField1.Caption = "Type"
        Me.PivotGridField1.FieldName = "Type"
        Me.PivotGridField1.Name = "PivotGridField1"
        Me.PivotGridField1.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl1.Controls.Add(Me.PivotGridControl2)
        Me.LayoutControl1.Controls.Add(Me.PivotGridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 159)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(427, 535, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1445, 546)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.Aqua
        Me.ProgressPanel1.AppearanceCaption.Options.UseFont = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseForeColor = True
        Me.ProgressPanel1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(1421, 16)
        Me.ProgressPanel1.StyleController = Me.LayoutControl1
        Me.ProgressPanel1.TabIndex = 11
        Me.ProgressPanel1.Text = "ProgressPanel1"
        Me.ProgressPanel1.Visible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1, Me.LayoutControlItem9, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1445, 546)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Aqua
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 30)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1425, 496)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup4})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1401, 451)
        Me.LayoutControlGroup2.Text = "All Business Dates"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PivotGridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1401, 451)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1401, 451)
        Me.LayoutControlGroup4.Text = "Compare 2 Business Dates"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.PivotGridControl2
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1401, 451)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ProgressPanel1
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1425, 20)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 20)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1425, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BS_DateFrom_BarEditItem, Me.BS_DateTill_BarEditItem, Me.LoadDate_BarSubItem, Me.LoadDataFromTill_Bbi, Me.LoadDataSelectedDate_Bbi, Me.LoadDataFromList_Bbi, Me.CompareData_Bbi, Me.LayoutTemplatesMenu_SubItem, Me.bbiLoadLayout, Me.bbiSaveLayout, Me.bbiDeleteLayout, Me.bbiLoadDefaultLayout, Me.ReportTemplateName_BarStaticItem, Me.bbiPreview, Me.bbiClose})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 17
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemSearchLookUpEdit1, Me.RepositoryItemSearchLookUpEdit2})
        Me.RibbonControl1.Size = New System.Drawing.Size(1445, 159)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'BS_DateFrom_BarEditItem
        '
        Me.BS_DateFrom_BarEditItem.Caption = "Date from:"
        Me.BS_DateFrom_BarEditItem.Edit = Me.RepositoryItemSearchLookUpEdit1
        Me.BS_DateFrom_BarEditItem.EditWidth = 150
        Me.BS_DateFrom_BarEditItem.Id = 2
        Me.BS_DateFrom_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BS_DateFrom_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.BS_DateFrom_BarEditItem.Name = "BS_DateFrom_BarEditItem"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemSearchLookUpEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemSearchLookUpEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemSearchLookUpEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemSearchLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSearchLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSearchLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSearchLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSearchLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.PopupView = Me.BS_Date_From_GridView
        Me.RepositoryItemSearchLookUpEdit1.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        '
        'BS_Date_From_GridView
        '
        Me.BS_Date_From_GridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BS_Date_From_GridView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BS_Date_From_GridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.BS_Date_From_GridView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BS_Date_From_GridView.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BS_Date_From_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BS_Date_From_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BS_Date_From_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BS_Date_From_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BS_Date_From_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BS_Date_From_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1})
        Me.BS_Date_From_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BS_Date_From_GridView.Name = "BS_Date_From_GridView"
        Me.BS_Date_From_GridView.OptionsBehavior.ReadOnly = True
        Me.BS_Date_From_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BS_Date_From_GridView.OptionsView.ColumnAutoWidth = False
        Me.BS_Date_From_GridView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Input Dates"
        Me.GridColumn1.FieldName = "BUSINESS_DATE"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 123
        '
        'BS_DateTill_BarEditItem
        '
        Me.BS_DateTill_BarEditItem.Caption = "Date Till:   "
        Me.BS_DateTill_BarEditItem.Edit = Me.RepositoryItemSearchLookUpEdit2
        Me.BS_DateTill_BarEditItem.EditWidth = 150
        Me.BS_DateTill_BarEditItem.Id = 3
        Me.BS_DateTill_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BS_DateTill_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.BS_DateTill_BarEditItem.Name = "BS_DateTill_BarEditItem"
        '
        'RepositoryItemSearchLookUpEdit2
        '
        Me.RepositoryItemSearchLookUpEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemSearchLookUpEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemSearchLookUpEdit2.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemSearchLookUpEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemSearchLookUpEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSearchLookUpEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSearchLookUpEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSearchLookUpEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSearchLookUpEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSearchLookUpEdit2.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit2.Name = "RepositoryItemSearchLookUpEdit2"
        Me.RepositoryItemSearchLookUpEdit2.PopupView = Me.BS_Date_Till_GridView
        Me.RepositoryItemSearchLookUpEdit2.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        '
        'BS_Date_Till_GridView
        '
        Me.BS_Date_Till_GridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BS_Date_Till_GridView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BS_Date_Till_GridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.BS_Date_Till_GridView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BS_Date_Till_GridView.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BS_Date_Till_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BS_Date_Till_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BS_Date_Till_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BS_Date_Till_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BS_Date_Till_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BS_Date_Till_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2})
        Me.BS_Date_Till_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BS_Date_Till_GridView.Name = "BS_Date_Till_GridView"
        Me.BS_Date_Till_GridView.OptionsBehavior.ReadOnly = True
        Me.BS_Date_Till_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BS_Date_Till_GridView.OptionsView.ColumnAutoWidth = False
        Me.BS_Date_Till_GridView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Input Dates"
        Me.GridColumn2.FieldName = "BUSINESS_DATE"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 123
        '
        'LoadDate_BarSubItem
        '
        Me.LoadDate_BarSubItem.Caption = "Load Data"
        Me.LoadDate_BarSubItem.Id = 4
        Me.LoadDate_BarSubItem.ImageOptions.SvgImage = CType(resources.GetObject("LoadDate_BarSubItem.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LoadDate_BarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.LoadDataFromTill_Bbi), New DevExpress.XtraBars.LinkPersistInfo(Me.LoadDataSelectedDate_Bbi, True), New DevExpress.XtraBars.LinkPersistInfo(Me.LoadDataFromList_Bbi, True), New DevExpress.XtraBars.LinkPersistInfo(Me.CompareData_Bbi, True)})
        Me.LoadDate_BarSubItem.Name = "LoadDate_BarSubItem"
        '
        'LoadDataFromTill_Bbi
        '
        Me.LoadDataFromTill_Bbi.Caption = "Load Data from Date till Date"
        Me.LoadDataFromTill_Bbi.Id = 5
        Me.LoadDataFromTill_Bbi.ImageOptions.Image = CType(resources.GetObject("LoadDataFromTill_Bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.LoadDataFromTill_Bbi.ImageOptions.LargeImage = CType(resources.GetObject("LoadDataFromTill_Bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LoadDataFromTill_Bbi.Name = "LoadDataFromTill_Bbi"
        '
        'LoadDataSelectedDate_Bbi
        '
        Me.LoadDataSelectedDate_Bbi.Caption = "Load Data only from entered Dates"
        Me.LoadDataSelectedDate_Bbi.Id = 6
        Me.LoadDataSelectedDate_Bbi.ImageOptions.Image = CType(resources.GetObject("LoadDataSelectedDate_Bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.LoadDataSelectedDate_Bbi.ImageOptions.LargeImage = CType(resources.GetObject("LoadDataSelectedDate_Bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LoadDataSelectedDate_Bbi.Name = "LoadDataSelectedDate_Bbi"
        '
        'LoadDataFromList_Bbi
        '
        Me.LoadDataFromList_Bbi.Caption = "Load Data from List"
        Me.LoadDataFromList_Bbi.Id = 7
        Me.LoadDataFromList_Bbi.ImageOptions.Image = CType(resources.GetObject("LoadDataFromList_Bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.LoadDataFromList_Bbi.ImageOptions.LargeImage = CType(resources.GetObject("LoadDataFromList_Bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.LoadDataFromList_Bbi.Name = "LoadDataFromList_Bbi"
        '
        'CompareData_Bbi
        '
        Me.CompareData_Bbi.Caption = "Compare Data for the Selected Dates"
        Me.CompareData_Bbi.Id = 8
        Me.CompareData_Bbi.ImageOptions.Image = CType(resources.GetObject("CompareData_Bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.CompareData_Bbi.ImageOptions.LargeImage = CType(resources.GetObject("CompareData_Bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.CompareData_Bbi.Name = "CompareData_Bbi"
        Me.CompareData_Bbi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'LayoutTemplatesMenu_SubItem
        '
        Me.LayoutTemplatesMenu_SubItem.Caption = "Layouts"
        Me.LayoutTemplatesMenu_SubItem.Id = 9
        Me.LayoutTemplatesMenu_SubItem.ImageOptions.SvgImage = CType(resources.GetObject("LayoutTemplatesMenu_SubItem.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LayoutTemplatesMenu_SubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiLoadLayout), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiSaveLayout, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiDeleteLayout, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiLoadDefaultLayout, True)})
        Me.LayoutTemplatesMenu_SubItem.Name = "LayoutTemplatesMenu_SubItem"
        '
        'bbiLoadLayout
        '
        Me.bbiLoadLayout.Caption = "Load Layout Templates"
        Me.bbiLoadLayout.Id = 10
        Me.bbiLoadLayout.ImageOptions.SvgImage = CType(resources.GetObject("bbiLoadLayout.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiLoadLayout.Name = "bbiLoadLayout"
        '
        'bbiSaveLayout
        '
        Me.bbiSaveLayout.Caption = "Save current Layout"
        Me.bbiSaveLayout.Id = 11
        Me.bbiSaveLayout.ImageOptions.SvgImage = CType(resources.GetObject("bbiSaveLayout.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiSaveLayout.Name = "bbiSaveLayout"
        '
        'bbiDeleteLayout
        '
        Me.bbiDeleteLayout.Caption = "Delete Layout"
        Me.bbiDeleteLayout.Id = 12
        Me.bbiDeleteLayout.ImageOptions.SvgImage = CType(resources.GetObject("bbiDeleteLayout.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiDeleteLayout.Name = "bbiDeleteLayout"
        '
        'bbiLoadDefaultLayout
        '
        Me.bbiLoadDefaultLayout.Caption = "Load default Layout"
        Me.bbiLoadDefaultLayout.Id = 13
        Me.bbiLoadDefaultLayout.ImageOptions.SvgImage = CType(resources.GetObject("bbiLoadDefaultLayout.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiLoadDefaultLayout.Name = "bbiLoadDefaultLayout"
        '
        'ReportTemplateName_BarStaticItem
        '
        Me.ReportTemplateName_BarStaticItem.Caption = "Default Layout"
        Me.ReportTemplateName_BarStaticItem.Id = 14
        Me.ReportTemplateName_BarStaticItem.ImageOptions.SvgImage = CType(resources.GetObject("ReportTemplateName_BarStaticItem.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.ReportTemplateName_BarStaticItem.Name = "ReportTemplateName_BarStaticItem"
        Me.ReportTemplateName_BarStaticItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiPreview
        '
        Me.bbiPreview.Caption = "Print or Export"
        Me.bbiPreview.Id = 15
        Me.bbiPreview.ImageOptions.SvgImage = CType(resources.GetObject("bbiPreview.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiPreview.Name = "bbiPreview"
        '
        'bbiClose
        '
        Me.bbiClose.Caption = "Close"
        Me.bbiClose.Id = 16
        Me.bbiClose.ImageOptions.SvgImage = CType(resources.GetObject("bbiClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiClose.Name = "bbiClose"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup4})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BS_DateFrom_BarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BS_DateTill_BarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.LoadDate_BarSubItem, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Liquidity Overview Data"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.LayoutTemplatesMenu_SubItem)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ReportTemplateName_BarStaticItem)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Layouts Configuration"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.bbiPreview)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Print/Export"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.bbiClose)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemButtonEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemButtonEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemButtonEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemButtonEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemButtonEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemButtonEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemButtonEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemButtonEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemButtonEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemButtonEdit2.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemButtonEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemButtonEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemButtonEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemButtonEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemButtonEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemButtonEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 705)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1445, 22)
        Me.RibbonStatusBar1.Visible = False
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'FieldPERIOD_ALMM_MaturityDate
        '
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Cell.ForeColor = System.Drawing.Color.Navy
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Cell.Options.UseForeColor = True
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.CellTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.CellTotal.Options.UseFont = True
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Header.ForeColor = System.Drawing.Color.Navy
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Header.Options.UseForeColor = True
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Value.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldPERIOD_ALMM_MaturityDate.Appearance.Value.Options.UseFont = True
        Me.FieldPERIOD_ALMM_MaturityDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.FieldPERIOD_ALMM_MaturityDate.AreaIndex = 2
        Me.FieldPERIOD_ALMM_MaturityDate.Caption = "ALMM Period (Maturity Date)"
        Me.FieldPERIOD_ALMM_MaturityDate.FieldName = "PERIOD_ALMM_MaturityDate"
        Me.FieldPERIOD_ALMM_MaturityDate.Name = "FieldPERIOD_ALMM_MaturityDate"
        Me.FieldPERIOD_ALMM_MaturityDate.ToolTips.HeaderText = "Calculated ALMM PERIOD based on the contracts Maturity Date"
        '
        'Pivot_Liquidity_Overview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1445, 727)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("Pivot_Liquidity_Overview.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "Pivot_Liquidity_Overview"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Liquidity Overview - Pivot"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PivotGridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_Date_From_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_Date_Till_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PivotGridControl2 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents PivotGridField4 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField5 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField8 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField9 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField11 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField17 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents fieldCURRENCY As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldPERIOD As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldContractType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldProductType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldPrincipalAmountValueBalanceEUREqu As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldRISKDATE As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldPrincipalAmountValueBalance As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldGLMasterAccountType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents FieldType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldFinalMaturityDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldNextEventDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldNextEventType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCustomerName As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldContract_Account As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldClientType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCOUNTRY_OF_REGISTRATION As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCOUNTRY_OF_RESIDENCE As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldINDUSTRIAL_CLASS_CN As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCCB_Group As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCCB_Group_OwnID As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldEU_EEA As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldEWU As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldIsBank As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldClientNr As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldLANDKZ_BUBA As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCOUNTRY_NAME As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldStartDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldBusinessType As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldInterestRate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldInterestAmountOrigCur As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldInterestAmountEuro As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents UB_FieldSumInOutflowEUR As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents UB_FieldSumInOutflowCUR As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldINDUSTRIAL_CLASS_LOCAL As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldINDUSTRIAL_CLASS_LOCAL_NAME As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldAccruedInterestAmountEUR As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldAccruedInterestAmountOrigCur As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldAverageDuration As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldDaysToEventDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldPERIOD_Additional As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldDaysToMaturity As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldPERIOD_MaturityDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldCIC_Group As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents GroupRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents UB_PrincipalInterestEUR As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BS_DateFrom_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BS_DateTill_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LoadDate_BarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents LoadDataFromTill_Bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LoadDataSelectedDate_Bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LoadDataFromList_Bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CompareData_Bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutTemplatesMenu_SubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents bbiLoadLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiSaveLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDeleteLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiLoadDefaultLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportTemplateName_BarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BS_Date_From_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BS_Date_Till_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents bbiPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents FieldALMMPeriod_MaturityDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents FieldPERIOD_ALMM_MaturityDate As DevExpress.XtraPivotGrid.PivotGridField
End Class
