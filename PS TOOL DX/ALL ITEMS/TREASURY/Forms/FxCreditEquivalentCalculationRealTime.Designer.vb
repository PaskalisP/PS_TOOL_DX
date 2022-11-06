<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FxCreditEquivalentCalculationRealTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FxCreditEquivalentCalculationRealTime))
        Me.FX_DetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContract = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroup1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroupName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTradeDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colModifiedStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFinal_Maturity_Date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colModified_Final_Maturity_Date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMonthToEventStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMonthToEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colYearToEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcyAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEURequ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPercentCalculation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEURequCalculated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdFX_CRED_EQU_BASIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClient_No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClient_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchangeRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInputType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TreasuryDataSet = New PS_TOOL_DX.TreasuryDataSet()
        Me.FX_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroupName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumEURequ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditEquivelantAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditEquivelantAmountTill1Jear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditEquivelantAmountOver1Till2Years = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditEquivelantAmountOver2Years = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditRiskAmountSUM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.LoadData_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Status_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.CCB_Fx_Credit_Equiv_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.CCB_Guarantees_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadCurrentDateData_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.FxDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.FXReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter = New PS_TOOL_DX.TreasuryDataSetTableAdapters.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.TreasuryDataSetTableAdapters.TableAdapterManager()
        Me.CUSTOMER_RATINGTableAdapter = New PS_TOOL_DX.TreasuryDataSetTableAdapters.CUSTOMER_RATINGTableAdapter()
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter = New PS_TOOL_DX.TreasuryDataSetTableAdapters.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter()
        Me.OWN_CURRENCIESTableAdapter = New PS_TOOL_DX.TreasuryDataSetTableAdapters.OWN_CURRENCIESTableAdapter()
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CUSTOMER_RATINGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OWN_CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.ClientName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.ClientGroupNr_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.ClientGroupName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.ClientGroup_LookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.ReloadList_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.AddNewFxDeal_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CurrencyName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Currencies_LookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.NominalAmount_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.StartDate_DateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.FinalMaturityDate_DateEdit = New DevExpress.XtraEditors.DateEdit()
        CType(Me.FX_DetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreasuryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FX_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FxDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FxDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMER_RATINGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ClientGroup_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Currencies_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NominalAmount_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartDate_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartDate_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinalMaturityDate_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinalMaturityDate_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FX_DetailView
        '
        Me.FX_DetailView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.FX_DetailView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.FX_DetailView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.FX_DetailView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.FX_DetailView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.FX_DetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colContract, Me.colContractType, Me.colClientGroup1, Me.colClientGroupName1, Me.colTradeDate, Me.colStartDate, Me.colModifiedStartDate, Me.colFinal_Maturity_Date, Me.colModified_Final_Maturity_Date, Me.colMonthToEventStartDate, Me.colMonthToEvent, Me.colYearToEvent, Me.colOrgCcy, Me.colOrgCcyAmount, Me.colEURequ, Me.colPercentCalculation, Me.colEURequCalculated, Me.colRiskDate, Me.colIdFX_CRED_EQU_BASIC, Me.colClient_No, Me.colClient_Name, Me.colExchangeRate, Me.colInputType})
        Me.FX_DetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.FX_DetailView.GridControl = Me.GridControl1
        Me.FX_DetailView.Name = "FX_DetailView"
        Me.FX_DetailView.OptionsCustomization.AllowRowSizing = True
        Me.FX_DetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.FX_DetailView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.FX_DetailView.OptionsFind.AlwaysVisible = True
        Me.FX_DetailView.OptionsSelection.MultiSelect = True
        Me.FX_DetailView.OptionsView.ColumnAutoWidth = False
        Me.FX_DetailView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.FX_DetailView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.FX_DetailView.OptionsView.ShowAutoFilterRow = True
        Me.FX_DetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.FX_DetailView.OptionsView.ShowFooter = True
        Me.FX_DetailView.ViewCaption = "FX DEALS DETAILS"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colContract
        '
        Me.colContract.FieldName = "Contract"
        Me.colContract.Name = "colContract"
        Me.colContract.OptionsColumn.AllowEdit = False
        Me.colContract.OptionsColumn.ReadOnly = True
        Me.colContract.Visible = True
        Me.colContract.VisibleIndex = 4
        Me.colContract.Width = 136
        '
        'colContractType
        '
        Me.colContractType.FieldName = "ContractType"
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 5
        Me.colContractType.Width = 89
        '
        'colClientGroup1
        '
        Me.colClientGroup1.FieldName = "ClientGroup"
        Me.colClientGroup1.Name = "colClientGroup1"
        Me.colClientGroup1.OptionsColumn.AllowEdit = False
        Me.colClientGroup1.OptionsColumn.ReadOnly = True
        Me.colClientGroup1.Visible = True
        Me.colClientGroup1.VisibleIndex = 2
        Me.colClientGroup1.Width = 96
        '
        'colClientGroupName1
        '
        Me.colClientGroupName1.FieldName = "ClientGroupName"
        Me.colClientGroupName1.Name = "colClientGroupName1"
        Me.colClientGroupName1.OptionsColumn.AllowEdit = False
        Me.colClientGroupName1.OptionsColumn.ReadOnly = True
        Me.colClientGroupName1.Visible = True
        Me.colClientGroupName1.VisibleIndex = 3
        Me.colClientGroupName1.Width = 260
        '
        'colTradeDate
        '
        Me.colTradeDate.AppearanceCell.Options.UseTextOptions = True
        Me.colTradeDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTradeDate.FieldName = "TradeDate"
        Me.colTradeDate.Name = "colTradeDate"
        Me.colTradeDate.OptionsColumn.AllowEdit = False
        Me.colTradeDate.OptionsColumn.ReadOnly = True
        Me.colTradeDate.Visible = True
        Me.colTradeDate.VisibleIndex = 6
        '
        'colStartDate
        '
        Me.colStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStartDate.FieldName = "StartDate"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.OptionsColumn.AllowEdit = False
        Me.colStartDate.OptionsColumn.ReadOnly = True
        Me.colStartDate.Visible = True
        Me.colStartDate.VisibleIndex = 7
        '
        'colModifiedStartDate
        '
        Me.colModifiedStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colModifiedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colModifiedStartDate.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colModifiedStartDate.AppearanceHeader.Options.UseForeColor = True
        Me.colModifiedStartDate.Caption = "Modified Start Date"
        Me.colModifiedStartDate.FieldName = "ModifiedStartDate"
        Me.colModifiedStartDate.Name = "colModifiedStartDate"
        Me.colModifiedStartDate.OptionsColumn.AllowEdit = False
        Me.colModifiedStartDate.OptionsColumn.ReadOnly = True
        Me.colModifiedStartDate.Visible = True
        Me.colModifiedStartDate.VisibleIndex = 8
        Me.colModifiedStartDate.Width = 103
        '
        'colFinal_Maturity_Date
        '
        Me.colFinal_Maturity_Date.AppearanceCell.Options.UseTextOptions = True
        Me.colFinal_Maturity_Date.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFinal_Maturity_Date.FieldName = "Final_Maturity_Date"
        Me.colFinal_Maturity_Date.Name = "colFinal_Maturity_Date"
        Me.colFinal_Maturity_Date.OptionsColumn.AllowEdit = False
        Me.colFinal_Maturity_Date.OptionsColumn.ReadOnly = True
        Me.colFinal_Maturity_Date.Visible = True
        Me.colFinal_Maturity_Date.VisibleIndex = 9
        Me.colFinal_Maturity_Date.Width = 127
        '
        'colModified_Final_Maturity_Date
        '
        Me.colModified_Final_Maturity_Date.AppearanceCell.Options.UseTextOptions = True
        Me.colModified_Final_Maturity_Date.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colModified_Final_Maturity_Date.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colModified_Final_Maturity_Date.AppearanceHeader.Options.UseForeColor = True
        Me.colModified_Final_Maturity_Date.Caption = "Modified Final Maturity Date"
        Me.colModified_Final_Maturity_Date.FieldName = "Modified_Final_Maturity_Date"
        Me.colModified_Final_Maturity_Date.Name = "colModified_Final_Maturity_Date"
        Me.colModified_Final_Maturity_Date.OptionsColumn.AllowEdit = False
        Me.colModified_Final_Maturity_Date.OptionsColumn.ReadOnly = True
        Me.colModified_Final_Maturity_Date.Visible = True
        Me.colModified_Final_Maturity_Date.VisibleIndex = 10
        Me.colModified_Final_Maturity_Date.Width = 149
        '
        'colMonthToEventStartDate
        '
        Me.colMonthToEventStartDate.Caption = "Years to Event"
        Me.colMonthToEventStartDate.FieldName = "MonthToEventStartDate"
        Me.colMonthToEventStartDate.Name = "colMonthToEventStartDate"
        Me.colMonthToEventStartDate.OptionsColumn.AllowEdit = False
        Me.colMonthToEventStartDate.OptionsColumn.ReadOnly = True
        Me.colMonthToEventStartDate.Visible = True
        Me.colMonthToEventStartDate.VisibleIndex = 11
        Me.colMonthToEventStartDate.Width = 86
        '
        'colMonthToEvent
        '
        Me.colMonthToEvent.AppearanceCell.Options.UseTextOptions = True
        Me.colMonthToEvent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMonthToEvent.Caption = "Days to Event (Start Date)"
        Me.colMonthToEvent.FieldName = "MonthToEvent"
        Me.colMonthToEvent.Name = "colMonthToEvent"
        Me.colMonthToEvent.OptionsColumn.AllowEdit = False
        Me.colMonthToEvent.OptionsColumn.ReadOnly = True
        Me.colMonthToEvent.Width = 94
        '
        'colYearToEvent
        '
        Me.colYearToEvent.FieldName = "YearToEvent"
        Me.colYearToEvent.Name = "colYearToEvent"
        Me.colYearToEvent.OptionsColumn.AllowEdit = False
        Me.colYearToEvent.OptionsColumn.ReadOnly = True
        '
        'colOrgCcy
        '
        Me.colOrgCcy.FieldName = "OrgCcy"
        Me.colOrgCcy.Name = "colOrgCcy"
        Me.colOrgCcy.OptionsColumn.AllowEdit = False
        Me.colOrgCcy.OptionsColumn.ReadOnly = True
        Me.colOrgCcy.Visible = True
        Me.colOrgCcy.VisibleIndex = 12
        '
        'colOrgCcyAmount
        '
        Me.colOrgCcyAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcyAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgCcyAmount.DisplayFormat.FormatString = "n2"
        Me.colOrgCcyAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgCcyAmount.FieldName = "OrgCcyAmount"
        Me.colOrgCcyAmount.Name = "colOrgCcyAmount"
        Me.colOrgCcyAmount.OptionsColumn.AllowEdit = False
        Me.colOrgCcyAmount.OptionsColumn.ReadOnly = True
        Me.colOrgCcyAmount.Visible = True
        Me.colOrgCcyAmount.VisibleIndex = 13
        Me.colOrgCcyAmount.Width = 114
        '
        'colEURequ
        '
        Me.colEURequ.AppearanceCell.Options.UseTextOptions = True
        Me.colEURequ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colEURequ.DisplayFormat.FormatString = "n2"
        Me.colEURequ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEURequ.FieldName = "EURequ"
        Me.colEURequ.Name = "colEURequ"
        Me.colEURequ.OptionsColumn.AllowEdit = False
        Me.colEURequ.OptionsColumn.ReadOnly = True
        Me.colEURequ.Visible = True
        Me.colEURequ.VisibleIndex = 15
        Me.colEURequ.Width = 105
        '
        'colPercentCalculation
        '
        Me.colPercentCalculation.AppearanceCell.Options.UseTextOptions = True
        Me.colPercentCalculation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPercentCalculation.DisplayFormat.FormatString = "p2"
        Me.colPercentCalculation.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPercentCalculation.FieldName = "PercentCalculation"
        Me.colPercentCalculation.Name = "colPercentCalculation"
        Me.colPercentCalculation.OptionsColumn.AllowEdit = False
        Me.colPercentCalculation.OptionsColumn.ReadOnly = True
        Me.colPercentCalculation.Visible = True
        Me.colPercentCalculation.VisibleIndex = 16
        Me.colPercentCalculation.Width = 102
        '
        'colEURequCalculated
        '
        Me.colEURequCalculated.AppearanceCell.Options.UseTextOptions = True
        Me.colEURequCalculated.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colEURequCalculated.DisplayFormat.FormatString = "n2"
        Me.colEURequCalculated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEURequCalculated.FieldName = "EURequCalculated"
        Me.colEURequCalculated.Name = "colEURequCalculated"
        Me.colEURequCalculated.OptionsColumn.AllowEdit = False
        Me.colEURequCalculated.OptionsColumn.ReadOnly = True
        Me.colEURequCalculated.Visible = True
        Me.colEURequCalculated.VisibleIndex = 17
        Me.colEURequCalculated.Width = 113
        '
        'colRiskDate
        '
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.OptionsColumn.AllowEdit = False
        Me.colRiskDate.OptionsColumn.ReadOnly = True
        '
        'colIdFX_CRED_EQU_BASIC
        '
        Me.colIdFX_CRED_EQU_BASIC.FieldName = "IdFX_CRED_EQU_BASIC"
        Me.colIdFX_CRED_EQU_BASIC.Name = "colIdFX_CRED_EQU_BASIC"
        Me.colIdFX_CRED_EQU_BASIC.OptionsColumn.AllowEdit = False
        Me.colIdFX_CRED_EQU_BASIC.OptionsColumn.ReadOnly = True
        '
        'colClient_No
        '
        Me.colClient_No.Caption = "Client Nr."
        Me.colClient_No.FieldName = "Client_No"
        Me.colClient_No.Name = "colClient_No"
        Me.colClient_No.OptionsColumn.AllowEdit = False
        Me.colClient_No.OptionsColumn.ReadOnly = True
        Me.colClient_No.Visible = True
        Me.colClient_No.VisibleIndex = 0
        Me.colClient_No.Width = 181
        '
        'colClient_Name
        '
        Me.colClient_Name.Caption = "Client Name"
        Me.colClient_Name.FieldName = "Client_Name"
        Me.colClient_Name.Name = "colClient_Name"
        Me.colClient_Name.OptionsColumn.AllowEdit = False
        Me.colClient_Name.OptionsColumn.ReadOnly = True
        Me.colClient_Name.Visible = True
        Me.colClient_Name.VisibleIndex = 1
        Me.colClient_Name.Width = 304
        '
        'colExchangeRate
        '
        Me.colExchangeRate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchangeRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchangeRate.DisplayFormat.FormatString = "n5"
        Me.colExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchangeRate.FieldName = "ExchangeRate"
        Me.colExchangeRate.Name = "colExchangeRate"
        Me.colExchangeRate.OptionsColumn.AllowEdit = False
        Me.colExchangeRate.OptionsColumn.ReadOnly = True
        Me.colExchangeRate.Visible = True
        Me.colExchangeRate.VisibleIndex = 14
        Me.colExchangeRate.Width = 94
        '
        'colInputType
        '
        Me.colInputType.FieldName = "InputType"
        Me.colInputType.Name = "colInputType"
        Me.colInputType.OptionsColumn.AllowEdit = False
        Me.colInputType.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 6, True, False, "Add new FX Deal", Nothing)})
        GridLevelNode1.LevelTemplate = Me.FX_DetailView
        GridLevelNode1.RelationName = "FK_FX CREDIT EQUIVALENT Details REAL TIME_FX CREDIT EQUIVALENT Basic REAL TIME"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 158)
        Me.GridControl1.MainView = Me.FX_BaseView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(1458, 572)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FX_BaseView, Me.FX_DetailView})
        '
        'FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource
        '
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource.DataMember = "FX CREDIT EQUIVALENT Basic REAL TIME"
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource.DataSource = Me.TreasuryDataSet
        '
        'TreasuryDataSet
        '
        Me.TreasuryDataSet.DataSetName = "TreasuryDataSet"
        Me.TreasuryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FX_BaseView
        '
        Me.FX_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.FX_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.FX_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.FX_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.FX_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.FX_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colRiskDate1, Me.colClientGroup, Me.colClientGroupName, Me.colSumEURequ, Me.colCreditEquivelantAmount, Me.colCreditEquivelantAmountTill1Jear, Me.colCreditEquivelantAmountOver1Till2Years, Me.colCreditEquivelantAmountOver2Years, Me.colCreditRiskAmountSUM})
        Me.FX_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.FX_BaseView.GridControl = Me.GridControl1
        Me.FX_BaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumEURequ", Me.colSumEURequ, "{0:n2}", "1"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmount", Me.colCreditEquivelantAmount, "{0:n2}", "2"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountTill1Jear", Me.colCreditEquivelantAmountTill1Jear, "{0:n2}", "3"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver1Till2Years", Me.colCreditEquivelantAmountOver1Till2Years, "{0:n2}", "4"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver2Years", Me.colCreditEquivelantAmountOver2Years, "{0:n2}", "5")})
        Me.FX_BaseView.Name = "FX_BaseView"
        Me.FX_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.FX_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.FX_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.FX_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.FX_BaseView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.FX_BaseView.OptionsFind.AlwaysVisible = True
        Me.FX_BaseView.OptionsPrint.PrintDetails = True
        Me.FX_BaseView.OptionsSelection.MultiSelect = True
        Me.FX_BaseView.OptionsView.ColumnAutoWidth = False
        Me.FX_BaseView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.FX_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.FX_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.FX_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.FX_BaseView.OptionsView.ShowFooter = True
        Me.FX_BaseView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colSumEURequ, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colRiskDate1
        '
        Me.colRiskDate1.FieldName = "RiskDate"
        Me.colRiskDate1.Name = "colRiskDate1"
        Me.colRiskDate1.OptionsColumn.AllowEdit = False
        Me.colRiskDate1.OptionsColumn.ReadOnly = True
        '
        'colClientGroup
        '
        Me.colClientGroup.FieldName = "ClientGroup"
        Me.colClientGroup.Name = "colClientGroup"
        Me.colClientGroup.OptionsColumn.AllowEdit = False
        Me.colClientGroup.OptionsColumn.ReadOnly = True
        Me.colClientGroup.Visible = True
        Me.colClientGroup.VisibleIndex = 0
        '
        'colClientGroupName
        '
        Me.colClientGroupName.FieldName = "ClientGroupName"
        Me.colClientGroupName.Name = "colClientGroupName"
        Me.colClientGroupName.OptionsColumn.AllowEdit = False
        Me.colClientGroupName.OptionsColumn.ReadOnly = True
        Me.colClientGroupName.Visible = True
        Me.colClientGroupName.VisibleIndex = 1
        Me.colClientGroupName.Width = 316
        '
        'colSumEURequ
        '
        Me.colSumEURequ.AppearanceCell.Options.UseTextOptions = True
        Me.colSumEURequ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSumEURequ.Caption = "Sum EURO Equivalent"
        Me.colSumEURequ.DisplayFormat.FormatString = "n2"
        Me.colSumEURequ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSumEURequ.FieldName = "SumEURequ"
        Me.colSumEURequ.Name = "colSumEURequ"
        Me.colSumEURequ.OptionsColumn.AllowEdit = False
        Me.colSumEURequ.OptionsColumn.ReadOnly = True
        Me.colSumEURequ.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumEURequ", "{0:n2}", "1")})
        Me.colSumEURequ.Visible = True
        Me.colSumEURequ.VisibleIndex = 2
        Me.colSumEURequ.Width = 166
        '
        'colCreditEquivelantAmount
        '
        Me.colCreditEquivelantAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colCreditEquivelantAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCreditEquivelantAmount.Caption = "Credit Equivelant Amount"
        Me.colCreditEquivelantAmount.DisplayFormat.FormatString = "n2"
        Me.colCreditEquivelantAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditEquivelantAmount.FieldName = "CreditEquivelantAmount"
        Me.colCreditEquivelantAmount.Name = "colCreditEquivelantAmount"
        Me.colCreditEquivelantAmount.OptionsColumn.AllowEdit = False
        Me.colCreditEquivelantAmount.OptionsColumn.ReadOnly = True
        Me.colCreditEquivelantAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmount", "{0:n2}", "2")})
        Me.colCreditEquivelantAmount.Visible = True
        Me.colCreditEquivelantAmount.VisibleIndex = 3
        Me.colCreditEquivelantAmount.Width = 164
        '
        'colCreditEquivelantAmountTill1Jear
        '
        Me.colCreditEquivelantAmountTill1Jear.AppearanceCell.Options.UseTextOptions = True
        Me.colCreditEquivelantAmountTill1Jear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCreditEquivelantAmountTill1Jear.Caption = "Credit Equivelant till 1 Year"
        Me.colCreditEquivelantAmountTill1Jear.DisplayFormat.FormatString = "n2"
        Me.colCreditEquivelantAmountTill1Jear.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditEquivelantAmountTill1Jear.FieldName = "CreditEquivelantAmountTill1Jear"
        Me.colCreditEquivelantAmountTill1Jear.Name = "colCreditEquivelantAmountTill1Jear"
        Me.colCreditEquivelantAmountTill1Jear.OptionsColumn.AllowEdit = False
        Me.colCreditEquivelantAmountTill1Jear.OptionsColumn.ReadOnly = True
        Me.colCreditEquivelantAmountTill1Jear.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountTill1Jear", "{0:n2}", "3")})
        Me.colCreditEquivelantAmountTill1Jear.Visible = True
        Me.colCreditEquivelantAmountTill1Jear.VisibleIndex = 4
        Me.colCreditEquivelantAmountTill1Jear.Width = 181
        '
        'colCreditEquivelantAmountOver1Till2Years
        '
        Me.colCreditEquivelantAmountOver1Till2Years.AppearanceCell.Options.UseTextOptions = True
        Me.colCreditEquivelantAmountOver1Till2Years.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCreditEquivelantAmountOver1Till2Years.Caption = "Credit Equivelant Amount over 1 till 2 Years"
        Me.colCreditEquivelantAmountOver1Till2Years.DisplayFormat.FormatString = "n2"
        Me.colCreditEquivelantAmountOver1Till2Years.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditEquivelantAmountOver1Till2Years.FieldName = "CreditEquivelantAmountOver1Till2Years"
        Me.colCreditEquivelantAmountOver1Till2Years.Name = "colCreditEquivelantAmountOver1Till2Years"
        Me.colCreditEquivelantAmountOver1Till2Years.OptionsColumn.AllowEdit = False
        Me.colCreditEquivelantAmountOver1Till2Years.OptionsColumn.ReadOnly = True
        Me.colCreditEquivelantAmountOver1Till2Years.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver1Till2Years", "{0:n2}", "4")})
        Me.colCreditEquivelantAmountOver1Till2Years.Visible = True
        Me.colCreditEquivelantAmountOver1Till2Years.VisibleIndex = 5
        Me.colCreditEquivelantAmountOver1Till2Years.Width = 220
        '
        'colCreditEquivelantAmountOver2Years
        '
        Me.colCreditEquivelantAmountOver2Years.AppearanceCell.Options.UseTextOptions = True
        Me.colCreditEquivelantAmountOver2Years.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCreditEquivelantAmountOver2Years.Caption = "Credit Equivelant Amount over 2 Years"
        Me.colCreditEquivelantAmountOver2Years.DisplayFormat.FormatString = "n2"
        Me.colCreditEquivelantAmountOver2Years.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditEquivelantAmountOver2Years.FieldName = "CreditEquivelantAmountOver2Years"
        Me.colCreditEquivelantAmountOver2Years.Name = "colCreditEquivelantAmountOver2Years"
        Me.colCreditEquivelantAmountOver2Years.OptionsColumn.AllowEdit = False
        Me.colCreditEquivelantAmountOver2Years.OptionsColumn.ReadOnly = True
        Me.colCreditEquivelantAmountOver2Years.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditEquivelantAmountOver2Years", "{0:n2}", "5")})
        Me.colCreditEquivelantAmountOver2Years.Visible = True
        Me.colCreditEquivelantAmountOver2Years.VisibleIndex = 6
        Me.colCreditEquivelantAmountOver2Years.Width = 203
        '
        'colCreditRiskAmountSUM
        '
        Me.colCreditRiskAmountSUM.FieldName = "CreditRiskAmountSUM"
        Me.colCreditRiskAmountSUM.Name = "colCreditRiskAmountSUM"
        Me.colCreditRiskAmountSUM.OptionsColumn.AllowEdit = False
        Me.colCreditRiskAmountSUM.OptionsColumn.ReadOnly = True
        Me.colCreditRiskAmountSUM.Width = 145
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
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
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
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "SQL Runner.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "CrystalReport.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Info.ico")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'LoadData_btn
        '
        Me.LoadData_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadData_btn.ImageOptions.ImageIndex = 0
        Me.LoadData_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadData_btn.Location = New System.Drawing.Point(369, 24)
        Me.LoadData_btn.Name = "LoadData_btn"
        Me.LoadData_btn.Size = New System.Drawing.Size(79, 22)
        Me.LoadData_btn.StyleController = Me.LayoutControl1
        Me.LoadData_btn.TabIndex = 0
        Me.LoadData_btn.Text = "Load Data"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Status_lbl)
        Me.LayoutControl1.Controls.Add(Me.CCB_Fx_Credit_Equiv_lbl)
        Me.LayoutControl1.Controls.Add(Me.LabelControl10)
        Me.LayoutControl1.Controls.Add(Me.CCB_Guarantees_lbl)
        Me.LayoutControl1.Controls.Add(Me.LabelControl9)
        Me.LayoutControl1.Controls.Add(Me.LoadCurrentDateData_btn)
        Me.LayoutControl1.Controls.Add(Me.LoadData_btn)
        Me.LayoutControl1.Controls.Add(Me.FxDateEdit)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_btn)
        Me.LayoutControl1.Controls.Add(Me.FXReport_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1482, 742)
        Me.LayoutControl1.TabIndex = 26
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Status_lbl
        '
        Me.Status_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Status_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Status_lbl.Appearance.Options.UseFont = True
        Me.Status_lbl.Appearance.Options.UseForeColor = True
        Me.Status_lbl.Location = New System.Drawing.Point(635, 80)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.Size = New System.Drawing.Size(823, 16)
        Me.Status_lbl.StyleController = Me.LayoutControl1
        Me.Status_lbl.TabIndex = 10
        '
        'CCB_Fx_Credit_Equiv_lbl
        '
        Me.CCB_Fx_Credit_Equiv_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CCB_Fx_Credit_Equiv_lbl.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.CCB_Fx_Credit_Equiv_lbl.Appearance.Options.UseFont = True
        Me.CCB_Fx_Credit_Equiv_lbl.Appearance.Options.UseForeColor = True
        Me.CCB_Fx_Credit_Equiv_lbl.Location = New System.Drawing.Point(345, 80)
        Me.CCB_Fx_Credit_Equiv_lbl.Name = "CCB_Fx_Credit_Equiv_lbl"
        Me.CCB_Fx_Credit_Equiv_lbl.Size = New System.Drawing.Size(186, 16)
        Me.CCB_Fx_Credit_Equiv_lbl.StyleController = Me.LayoutControl1
        Me.CCB_Fx_Credit_Equiv_lbl.TabIndex = 9
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Location = New System.Drawing.Point(24, 80)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(317, 16)
        Me.LabelControl10.StyleController = Me.LayoutControl1
        Me.LabelControl10.TabIndex = 8
        Me.LabelControl10.Text = "CCB FX CREDIT EQUIV. AMOUNT (Incl. Guarantees)"
        '
        'CCB_Guarantees_lbl
        '
        Me.CCB_Guarantees_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CCB_Guarantees_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CCB_Guarantees_lbl.Appearance.Options.UseFont = True
        Me.CCB_Guarantees_lbl.Appearance.Options.UseForeColor = True
        Me.CCB_Guarantees_lbl.Location = New System.Drawing.Point(196, 60)
        Me.CCB_Guarantees_lbl.Name = "CCB_Guarantees_lbl"
        Me.CCB_Guarantees_lbl.Size = New System.Drawing.Size(336, 16)
        Me.CCB_Guarantees_lbl.StyleController = Me.LayoutControl1
        Me.CCB_Guarantees_lbl.TabIndex = 7
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Location = New System.Drawing.Point(24, 60)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(168, 16)
        Me.LabelControl9.StyleController = Me.LayoutControl1
        Me.LabelControl9.TabIndex = 6
        Me.LabelControl9.Text = "CCB GUARANTEES AMOUNT"
        '
        'LoadCurrentDateData_btn
        '
        Me.LoadCurrentDateData_btn.ImageOptions.ImageIndex = 0
        Me.LoadCurrentDateData_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadCurrentDateData_btn.Location = New System.Drawing.Point(452, 24)
        Me.LoadCurrentDateData_btn.Name = "LoadCurrentDateData_btn"
        Me.LoadCurrentDateData_btn.Size = New System.Drawing.Size(175, 22)
        Me.LoadCurrentDateData_btn.StyleController = Me.LayoutControl1
        Me.LoadCurrentDateData_btn.TabIndex = 2
        Me.LoadCurrentDateData_btn.Text = "Calculate FX Credit.Equivalent"
        '
        'FxDateEdit
        '
        Me.FxDateEdit.EditValue = Nothing
        Me.FxDateEdit.Location = New System.Drawing.Point(231, 24)
        Me.FxDateEdit.Name = "FxDateEdit"
        Me.FxDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.FxDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FxDateEdit.Properties.Appearance.Options.UseFont = True
        Me.FxDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.FxDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FxDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FxDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FxDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FxDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FxDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FxDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.FxDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FxDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FxDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FxDateEdit.Size = New System.Drawing.Size(134, 22)
        Me.FxDateEdit.StyleController = Me.LayoutControl1
        Me.FxDateEdit.TabIndex = 1
        '
        'Print_Export_btn
        '
        Me.Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_btn.Location = New System.Drawing.Point(24, 110)
        Me.Print_Export_btn.Name = "Print_Export_btn"
        Me.Print_Export_btn.Size = New System.Drawing.Size(169, 22)
        Me.Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_btn.TabIndex = 3
        Me.Print_Export_btn.Text = "Print or Export"
        '
        'FXReport_btn
        '
        Me.FXReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FXReport_btn.ImageOptions.ImageIndex = 3
        Me.FXReport_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.FXReport_btn.Location = New System.Drawing.Point(197, 110)
        Me.FXReport_btn.Name = "FXReport_btn"
        Me.FXReport_btn.Size = New System.Drawing.Size(224, 22)
        Me.FXReport_btn.StyleController = Me.LayoutControl1
        Me.FXReport_btn.TabIndex = 4
        Me.FXReport_btn.Text = "FX Credit Equiv. Calculations Report"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1383, 110)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(75, 22)
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
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1482, 742)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 146)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1462, 576)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.EmptySpaceItem7, Me.LayoutControlItem12, Me.EmptySpaceItem6})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1462, 146)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1359, 86)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(79, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(401, 86)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(958, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 86)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.FXReport_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(173, 86)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(228, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(607, 0)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(831, 26)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem6.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem6.Control = Me.FxDateEdit
        Me.LayoutControlItem6.CustomizationFormText = "Date"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(345, 26)
        Me.LayoutControlItem6.Text = "Projection Date (FX Deal Start Date)"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(204, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LoadData_btn
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(345, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(83, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(512, 36)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(926, 20)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LoadCurrentDateData_btn
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(428, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(179, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.LabelControl9
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 36)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(172, 20)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(1438, 10)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.CustomizationFormText = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 76)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(1438, 10)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.CCB_Guarantees_lbl
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(172, 36)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(340, 20)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.LabelControl10
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(321, 20)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.CCB_Fx_Credit_Equiv_lbl
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem11"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(321, 56)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(190, 20)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.CustomizationFormText = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 112)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(1438, 10)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.Status_lbl
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(611, 56)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(76, 17)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(827, 20)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.CustomizationFormText = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(511, 56)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(100, 20)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter
        '
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_RATINGTableAdapter = Me.CUSTOMER_RATINGTableAdapter
        Me.TableAdapterManager.FX_ALLTableAdapter = Nothing
        Me.TableAdapterManager.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter = Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter
        Me.TableAdapterManager.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter = Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Me.OWN_CURRENCIESTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.TreasuryDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CUSTOMER_RATINGTableAdapter
        '
        Me.CUSTOMER_RATINGTableAdapter.ClearBeforeFill = True
        '
        'FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter
        '
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.ClearBeforeFill = True
        '
        'OWN_CURRENCIESTableAdapter
        '
        Me.OWN_CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource
        '
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource.DataMember = "FK_FX CREDIT EQUIVALENT Details REAL TIME_FX CREDIT EQUIVALENT Basic REAL TIME"
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource.DataSource = Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource
        '
        'CUSTOMER_RATINGBindingSource
        '
        Me.CUSTOMER_RATINGBindingSource.DataMember = "CUSTOMER_RATING"
        Me.CUSTOMER_RATINGBindingSource.DataSource = Me.TreasuryDataSet
        '
        'OWN_CURRENCIESBindingSource
        '
        Me.OWN_CURRENCIESBindingSource.DataMember = "OWN_CURRENCIES"
        Me.OWN_CURRENCIESBindingSource.DataSource = Me.TreasuryDataSet
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.ClientName_lbl)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.ClientGroupNr_lbl)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.ClientGroupName_lbl)
        Me.GroupControl1.Controls.Add(Me.ClientGroup_LookUpEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.ReloadList_btn)
        Me.GroupControl1.Controls.Add(Me.AddNewFxDeal_btn)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.CurrencyName_lbl)
        Me.GroupControl1.Controls.Add(Me.Currencies_LookUpEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.NominalAmount_TextEdit)
        Me.GroupControl1.Controls.Add(Me.StartDate_DateEdit)
        Me.GroupControl1.Controls.Add(Me.FinalMaturityDate_DateEdit)
        Me.GroupControl1.Location = New System.Drawing.Point(312, 40)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(864, 419)
        Me.GroupControl1.TabIndex = 27
        Me.GroupControl1.Text = "New FX Deal"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Location = New System.Drawing.Point(254, 125)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(117, 16)
        Me.LabelControl8.TabIndex = 12
        Me.LabelControl8.Text = "Client Group Name"
        '
        'ClientName_lbl
        '
        Me.ClientName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientName_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ClientName_lbl.Appearance.Options.UseFont = True
        Me.ClientName_lbl.Appearance.Options.UseForeColor = True
        Me.ClientName_lbl.Location = New System.Drawing.Point(391, 80)
        Me.ClientName_lbl.Name = "ClientName_lbl"
        Me.ClientName_lbl.Size = New System.Drawing.Size(0, 16)
        Me.ClientName_lbl.TabIndex = 9
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Location = New System.Drawing.Point(296, 81)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(75, 16)
        Me.LabelControl7.TabIndex = 8
        Me.LabelControl7.Text = "Client Name"
        '
        'ClientGroupNr_lbl
        '
        Me.ClientGroupNr_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientGroupNr_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ClientGroupNr_lbl.Appearance.Options.UseFont = True
        Me.ClientGroupNr_lbl.Appearance.Options.UseForeColor = True
        Me.ClientGroupNr_lbl.Location = New System.Drawing.Point(390, 103)
        Me.ClientGroupNr_lbl.Name = "ClientGroupNr_lbl"
        Me.ClientGroupNr_lbl.Size = New System.Drawing.Size(0, 16)
        Me.ClientGroupNr_lbl.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Location = New System.Drawing.Point(271, 103)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(100, 16)
        Me.LabelControl6.TabIndex = 10
        Me.LabelControl6.Text = "Client Group Nr."
        '
        'ClientGroupName_lbl
        '
        Me.ClientGroupName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientGroupName_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ClientGroupName_lbl.Appearance.Options.UseFont = True
        Me.ClientGroupName_lbl.Appearance.Options.UseForeColor = True
        Me.ClientGroupName_lbl.Location = New System.Drawing.Point(390, 127)
        Me.ClientGroupName_lbl.Name = "ClientGroupName_lbl"
        Me.ClientGroupName_lbl.Size = New System.Drawing.Size(0, 16)
        Me.ClientGroupName_lbl.TabIndex = 13
        '
        'ClientGroup_LookUpEdit
        '
        Me.ClientGroup_LookUpEdit.Location = New System.Drawing.Point(387, 50)
        Me.ClientGroup_LookUpEdit.Name = "ClientGroup_LookUpEdit"
        Me.ClientGroup_LookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ClientGroup_LookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientGroup_LookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.ClientGroup_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ClientGroup_LookUpEdit.Properties.AutoHeight = False
        Me.ClientGroup_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ClientGroup_LookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClientNo", "Client No", 66, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClientGroup", "Client Group", 88, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClientGroupName", "Client Group Name", 127, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ClientName", "Client Name", 85, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.ClientGroup_LookUpEdit.Properties.DataSource = Me.CUSTOMER_RATINGBindingSource
        Me.ClientGroup_LookUpEdit.Properties.DisplayMember = "ClientNo"
        Me.ClientGroup_LookUpEdit.Properties.NullText = "[Select Client Nr.]"
        Me.ClientGroup_LookUpEdit.Properties.PopupFormMinSize = New System.Drawing.Size(100, 100)
        Me.ClientGroup_LookUpEdit.Properties.PopupWidth = 100
        Me.ClientGroup_LookUpEdit.Properties.ValueMember = "ClientNo"
        Me.ClientGroup_LookUpEdit.Size = New System.Drawing.Size(160, 22)
        Me.ClientGroup_LookUpEdit.TabIndex = 7
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(315, 53)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(56, 16)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Client No"
        '
        'ReloadList_btn
        '
        Me.ReloadList_btn.Location = New System.Drawing.Point(768, 386)
        Me.ReloadList_btn.Name = "ReloadList_btn"
        Me.ReloadList_btn.Size = New System.Drawing.Size(75, 23)
        Me.ReloadList_btn.TabIndex = 23
        Me.ReloadList_btn.Text = "Reload List"
        '
        'AddNewFxDeal_btn
        '
        Me.AddNewFxDeal_btn.Location = New System.Drawing.Point(31, 386)
        Me.AddNewFxDeal_btn.Name = "AddNewFxDeal_btn"
        Me.AddNewFxDeal_btn.Size = New System.Drawing.Size(160, 23)
        Me.AddNewFxDeal_btn.TabIndex = 22
        Me.AddNewFxDeal_btn.Text = "Add new FX Deal and Calculate"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(387, 305)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(123, 16)
        Me.LabelControl4.TabIndex = 20
        Me.LabelControl4.Text = "Final Maturity Date"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(389, 245)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(148, 16)
        Me.LabelControl3.TabIndex = 18
        Me.LabelControl3.Text = "Start Date/Value Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(215, 209)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(156, 16)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Nominal Original Amount"
        '
        'CurrencyName_lbl
        '
        Me.CurrencyName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencyName_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CurrencyName_lbl.Appearance.Options.UseFont = True
        Me.CurrencyName_lbl.Appearance.Options.UseForeColor = True
        Me.CurrencyName_lbl.Location = New System.Drawing.Point(568, 178)
        Me.CurrencyName_lbl.Name = "CurrencyName_lbl"
        Me.CurrencyName_lbl.Size = New System.Drawing.Size(0, 16)
        Me.CurrencyName_lbl.TabIndex = 2
        '
        'Currencies_LookUpEdit
        '
        Me.Currencies_LookUpEdit.Location = New System.Drawing.Point(387, 175)
        Me.Currencies_LookUpEdit.Name = "Currencies_LookUpEdit"
        Me.Currencies_LookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Currencies_LookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Currencies_LookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Currencies_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Currencies_LookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[True]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 120, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[True])})
        Me.Currencies_LookUpEdit.Properties.DataSource = Me.OWN_CURRENCIESBindingSource
        Me.Currencies_LookUpEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.Currencies_LookUpEdit.Properties.NullText = "[Select Currency Code]"
        Me.Currencies_LookUpEdit.Properties.ValueMember = "CURRENCY CODE"
        Me.Currencies_LookUpEdit.Size = New System.Drawing.Size(174, 22)
        Me.Currencies_LookUpEdit.TabIndex = 15
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(276, 178)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 16)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Currency Code"
        '
        'NominalAmount_TextEdit
        '
        Me.NominalAmount_TextEdit.Location = New System.Drawing.Point(387, 206)
        Me.NominalAmount_TextEdit.Name = "NominalAmount_TextEdit"
        Me.NominalAmount_TextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.NominalAmount_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NominalAmount_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.NominalAmount_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.NominalAmount_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.NominalAmount_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.NominalAmount_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NominalAmount_TextEdit.Properties.DisplayFormat.FormatString = "n2"
        Me.NominalAmount_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NominalAmount_TextEdit.Properties.EditFormat.FormatString = "n2"
        Me.NominalAmount_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NominalAmount_TextEdit.Properties.Mask.EditMask = "n2"
        Me.NominalAmount_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.NominalAmount_TextEdit.Size = New System.Drawing.Size(174, 22)
        Me.NominalAmount_TextEdit.TabIndex = 17
        '
        'StartDate_DateEdit
        '
        Me.StartDate_DateEdit.EditValue = Nothing
        Me.StartDate_DateEdit.Location = New System.Drawing.Point(387, 265)
        Me.StartDate_DateEdit.Name = "StartDate_DateEdit"
        Me.StartDate_DateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.StartDate_DateEdit.Properties.Appearance.Options.UseFont = True
        Me.StartDate_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.StartDate_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StartDate_DateEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.StartDate_DateEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.StartDate_DateEdit.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.StartDate_DateEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StartDate_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.StartDate_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.StartDate_DateEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.StartDate_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.StartDate_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.StartDate_DateEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.StartDate_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.StartDate_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartDate_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.StartDate_DateEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.StartDate_DateEdit.Properties.ReadOnly = True
        Me.StartDate_DateEdit.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.StartDate_DateEdit.Size = New System.Drawing.Size(135, 22)
        Me.StartDate_DateEdit.TabIndex = 19
        '
        'FinalMaturityDate_DateEdit
        '
        Me.FinalMaturityDate_DateEdit.EditValue = ""
        Me.FinalMaturityDate_DateEdit.Location = New System.Drawing.Point(388, 325)
        Me.FinalMaturityDate_DateEdit.Name = "FinalMaturityDate_DateEdit"
        Me.FinalMaturityDate_DateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FinalMaturityDate_DateEdit.Properties.Appearance.Options.UseFont = True
        Me.FinalMaturityDate_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.FinalMaturityDate_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.FinalMaturityDate_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FinalMaturityDate_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FinalMaturityDate_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FinalMaturityDate_DateEdit.Size = New System.Drawing.Size(134, 22)
        Me.FinalMaturityDate_DateEdit.TabIndex = 21
        '
        'FxCreditEquivalentCalculationRealTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 742)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FxCreditEquivalentCalculationRealTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PROJECTIONS OF FX CREDIT EQUIVELANT "
        CType(Me.FX_DetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreasuryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FX_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FxDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FxDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMER_RATINGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ClientGroup_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Currencies_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NominalAmount_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartDate_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartDate_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinalMaturityDate_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinalMaturityDate_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LoadData_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FxDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TreasuryDataSet As PS_TOOL_DX.TreasuryDataSet
    Friend WithEvents FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter As PS_TOOL_DX.TreasuryDataSetTableAdapters.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.TreasuryDataSetTableAdapters.TableAdapterManager
    Friend WithEvents FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter As PS_TOOL_DX.TreasuryDataSetTableAdapters.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter
    Friend WithEvents FX_CREDIT_EQUIVALENT_Details_REAL_TIMEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUSTOMER_RATINGTableAdapter As PS_TOOL_DX.TreasuryDataSetTableAdapters.CUSTOMER_RATINGTableAdapter
    Friend WithEvents CUSTOMER_RATINGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OWN_CURRENCIESTableAdapter As PS_TOOL_DX.TreasuryDataSetTableAdapters.OWN_CURRENCIESTableAdapter
    Friend WithEvents OWN_CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FXReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FX_DetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FX_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ReloadList_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AddNewFxDeal_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CurrencyName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Currencies_LookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ClientGroupName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ClientGroup_LookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ClientGroupNr_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ClientName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents NominalAmount_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents StartDate_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents FinalMaturityDate_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LoadCurrentDateData_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroup1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroupName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFinal_Maturity_Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMonthToEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colYearToEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcyAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEURequ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPercentCalculation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEURequCalculated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdFX_CRED_EQU_BASIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClient_No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClient_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchangeRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInputType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroupName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSumEURequ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditEquivelantAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditEquivelantAmountTill1Jear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditEquivelantAmountOver1Till2Years As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditEquivelantAmountOver2Years As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditRiskAmountSUM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents CCB_Fx_Credit_Equiv_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CCB_Guarantees_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Status_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colTradeDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContract As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colModified_Final_Maturity_Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMonthToEventStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colModifiedStartDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
