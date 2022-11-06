<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyProfitLossSheets
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
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyProfitLossSheets))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.IncomeDetailsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.DailyPLSheetIncomeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.IncomeBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiCodeIncome = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiNameIncome = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExpensesDetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReleatedAccountNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Account_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Account_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrig_CUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrig_Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBalance_EUR_CR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBalance_EUR_DR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotal_Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBSDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRepDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBalanceSheets = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.DailyPLSheetExpensesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExpensesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item_Number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBalanceEUREqu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBSDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRepDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBSDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiCodeExpenses = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiNameExpenses = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ZipCodeRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.OtherRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.DailyPLSheetExpensesTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyPLSheetExpensesTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.DailyBalanceSheetsTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyBalanceSheetsTableAdapter()
        Me.DailyPLSheetIncomeTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyPLSheetIncomeTableAdapter()
        Me.DailyBalanceSheetsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ReconciliationsPL_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PLSheetCR_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PLDifferenceTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.SumIncomesTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SumExpensesTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.DailyPLSheet_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.FromDateEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.DailyBalanceDetailsSheetsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailyBalanceDetailsSheetsTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyBalanceDetailsSheetsTableAdapter()
        CType(Me.IncomeDetailsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyPLSheetIncomeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncomeBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyPLSheetExpensesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyBalanceSheetsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLDifferenceTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumIncomesTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumExpensesTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyBalanceDetailsSheetsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IncomeDetailsView
        '
        Me.IncomeDetailsView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.IncomeDetailsView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.IncomeDetailsView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.IncomeDetailsView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.IncomeDetailsView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.IncomeDetailsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.IncomeDetailsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.IncomeDetailsView.GridControl = Me.GridControl1
        Me.IncomeDetailsView.Name = "IncomeDetailsView"
        Me.IncomeDetailsView.OptionsBehavior.AllowIncrementalSearch = True
        Me.IncomeDetailsView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.IncomeDetailsView.OptionsPrint.PrintFilterInfo = True
        Me.IncomeDetailsView.OptionsSelection.MultiSelect = True
        Me.IncomeDetailsView.OptionsView.ColumnAutoWidth = False
        Me.IncomeDetailsView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.IncomeDetailsView.OptionsView.ShowAutoFilterRow = True
        Me.IncomeDetailsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.IncomeDetailsView.OptionsView.ShowFooter = True
        Me.IncomeDetailsView.ViewCaption = "Activa Details"
        '
        'GridColumn9
        '
        Me.GridColumn9.FieldName = "ID"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GL Item"
        Me.GridColumn10.FieldName = "GL_Item"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Width = 78
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Related Acc.Nr."
        Me.GridColumn11.FieldName = "ReleatedAccountNr"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 127
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GL Acc. Nr."
        Me.GridColumn12.FieldName = "GL_Account_Nr"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 111
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GL Acc. Name"
        Me.GridColumn13.FieldName = "GL_Account_Name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 299
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Currency"
        Me.GridColumn14.FieldName = "Orig_CUR"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 69
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn15.Caption = "Orig. Balance"
        Me.GridColumn15.DisplayFormat.FormatString = "n2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "Orig_Balance"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Orig_Balance", "Sum={0:n2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        Me.GridColumn15.Width = 162
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.Caption = "Credit Balance (EUR)"
        Me.GridColumn16.DisplayFormat.FormatString = "n2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "Balance_EUR_CR"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance_EUR_CR", "Sum={0:n2}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 5
        Me.GridColumn16.Width = 154
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Debit Balance (EUR)"
        Me.GridColumn17.DisplayFormat.FormatString = "n2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "Balance_EUR_DR"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance_EUR_DR", "Sum={0:n2}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 6
        Me.GridColumn17.Width = 143
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn18.Caption = "Total Balance"
        Me.GridColumn18.DisplayFormat.FormatString = "n2"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "Total_Balance"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        Me.GridColumn18.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", "Sum={0:n2}")})
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 7
        Me.GridColumn18.Width = 150
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "BSDate"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "RepDate"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "IdBalanceSheets"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.DailyPLSheetIncomeBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.IncomeDetailsView
        GridLevelNode1.RelationName = "FK_DailyBalanceDetailsSheets_DailyBalanceSheets3"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(764, 85)
        Me.GridControl1.MainView = Me.IncomeBaseView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(768, 584)
        Me.GridControl1.TabIndex = 12
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.IncomeBaseView, Me.IncomeDetailsView})
        '
        'DailyPLSheetIncomeBindingSource
        '
        Me.DailyPLSheetIncomeBindingSource.DataMember = "DailyPLSheetIncome"
        Me.DailyPLSheetIncomeBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IncomeBaseView
        '
        Me.IncomeBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.IncomeBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.IncomeBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.IncomeBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.IncomeBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.IncomeBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.colRilibiCodeIncome, Me.colRilibiNameIncome})
        Me.IncomeBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.IncomeBaseView.GridControl = Me.GridControl1
        Me.IncomeBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceEUREqu", Me.GridColumn5, "Active Sum = {0:C2}", New Decimal(New Integer() {0, 0, 0, 0}))})
        Me.IncomeBaseView.Name = "IncomeBaseView"
        Me.IncomeBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.IncomeBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.IncomeBaseView.OptionsCustomization.AllowRowSizing = True
        Me.IncomeBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.IncomeBaseView.OptionsFind.AlwaysVisible = True
        Me.IncomeBaseView.OptionsSelection.MultiSelect = True
        Me.IncomeBaseView.OptionsView.ColumnAutoWidth = False
        Me.IncomeBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.IncomeBaseView.OptionsView.ShowAutoFilterRow = True
        Me.IncomeBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.IncomeBaseView.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GL Item"
        Me.GridColumn2.FieldName = "GL_Item"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "GL_Item_Number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GL Item Name"
        Me.GridColumn4.FieldName = "GL_Item_Name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 363
        '
        'GridColumn5
        '
        Me.GridColumn5.DisplayFormat.FormatString = "c2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn5.FieldName = "BalanceEUREqu"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 139
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "BSDate"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "RepDate"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "IdBSDate"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.OptionsColumn.ShowInCustomizationForm = False
        '
        'colRilibiCodeIncome
        '
        Me.colRilibiCodeIncome.Caption = "Rilibi Code"
        Me.colRilibiCodeIncome.FieldName = "RilibiCode"
        Me.colRilibiCodeIncome.Name = "colRilibiCodeIncome"
        Me.colRilibiCodeIncome.OptionsColumn.AllowEdit = False
        Me.colRilibiCodeIncome.OptionsColumn.ReadOnly = True
        Me.colRilibiCodeIncome.Visible = True
        Me.colRilibiCodeIncome.VisibleIndex = 3
        '
        'colRilibiNameIncome
        '
        Me.colRilibiNameIncome.Caption = "Rilibi Name"
        Me.colRilibiNameIncome.FieldName = "RilibiName"
        Me.colRilibiNameIncome.Name = "colRilibiNameIncome"
        Me.colRilibiNameIncome.OptionsColumn.AllowEdit = False
        Me.colRilibiNameIncome.OptionsColumn.ReadOnly = True
        Me.colRilibiNameIncome.Visible = True
        Me.colRilibiNameIncome.VisibleIndex = 4
        Me.colRilibiNameIncome.Width = 356
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Mask.EditMask = "[0-9]{5}"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemTextEdit2.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.RepositoryItemTextEdit2.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'ExpensesDetailView
        '
        Me.ExpensesDetailView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExpensesDetailView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExpensesDetailView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExpensesDetailView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExpensesDetailView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExpensesDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colGL_Item1, Me.colReleatedAccountNr, Me.colGL_Account_Nr, Me.colGL_Account_Name, Me.colOrig_CUR, Me.colOrig_Balance, Me.colBalance_EUR_CR, Me.colBalance_EUR_DR, Me.colTotal_Balance, Me.colBSDate1, Me.colRepDate1, Me.colIdBalanceSheets})
        Me.ExpensesDetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExpensesDetailView.GridControl = Me.GridControl2
        Me.ExpensesDetailView.Name = "ExpensesDetailView"
        Me.ExpensesDetailView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExpensesDetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExpensesDetailView.OptionsPrint.PrintFilterInfo = True
        Me.ExpensesDetailView.OptionsSelection.MultiSelect = True
        Me.ExpensesDetailView.OptionsView.ColumnAutoWidth = False
        Me.ExpensesDetailView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExpensesDetailView.OptionsView.ShowAutoFilterRow = True
        Me.ExpensesDetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExpensesDetailView.OptionsView.ShowFooter = True
        Me.ExpensesDetailView.ViewCaption = "Activa Details"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colGL_Item1
        '
        Me.colGL_Item1.Caption = "GL Item"
        Me.colGL_Item1.FieldName = "GL_Item"
        Me.colGL_Item1.Name = "colGL_Item1"
        Me.colGL_Item1.OptionsColumn.AllowEdit = False
        Me.colGL_Item1.OptionsColumn.ReadOnly = True
        Me.colGL_Item1.Width = 78
        '
        'colReleatedAccountNr
        '
        Me.colReleatedAccountNr.Caption = "Related Acc.Nr."
        Me.colReleatedAccountNr.FieldName = "ReleatedAccountNr"
        Me.colReleatedAccountNr.Name = "colReleatedAccountNr"
        Me.colReleatedAccountNr.OptionsColumn.AllowEdit = False
        Me.colReleatedAccountNr.OptionsColumn.ReadOnly = True
        Me.colReleatedAccountNr.Visible = True
        Me.colReleatedAccountNr.VisibleIndex = 0
        Me.colReleatedAccountNr.Width = 127
        '
        'colGL_Account_Nr
        '
        Me.colGL_Account_Nr.Caption = "GL Acc. Nr."
        Me.colGL_Account_Nr.FieldName = "GL_Account_Nr"
        Me.colGL_Account_Nr.Name = "colGL_Account_Nr"
        Me.colGL_Account_Nr.OptionsColumn.AllowEdit = False
        Me.colGL_Account_Nr.OptionsColumn.ReadOnly = True
        Me.colGL_Account_Nr.Visible = True
        Me.colGL_Account_Nr.VisibleIndex = 1
        Me.colGL_Account_Nr.Width = 111
        '
        'colGL_Account_Name
        '
        Me.colGL_Account_Name.Caption = "GL Acc. Name"
        Me.colGL_Account_Name.FieldName = "GL_Account_Name"
        Me.colGL_Account_Name.Name = "colGL_Account_Name"
        Me.colGL_Account_Name.OptionsColumn.AllowEdit = False
        Me.colGL_Account_Name.OptionsColumn.ReadOnly = True
        Me.colGL_Account_Name.Visible = True
        Me.colGL_Account_Name.VisibleIndex = 2
        Me.colGL_Account_Name.Width = 299
        '
        'colOrig_CUR
        '
        Me.colOrig_CUR.AppearanceCell.Options.UseTextOptions = True
        Me.colOrig_CUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrig_CUR.Caption = "Currency"
        Me.colOrig_CUR.FieldName = "Orig_CUR"
        Me.colOrig_CUR.Name = "colOrig_CUR"
        Me.colOrig_CUR.OptionsColumn.AllowEdit = False
        Me.colOrig_CUR.OptionsColumn.ReadOnly = True
        Me.colOrig_CUR.Visible = True
        Me.colOrig_CUR.VisibleIndex = 3
        Me.colOrig_CUR.Width = 69
        '
        'colOrig_Balance
        '
        Me.colOrig_Balance.AppearanceCell.Options.UseTextOptions = True
        Me.colOrig_Balance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrig_Balance.Caption = "Orig. Balance"
        Me.colOrig_Balance.DisplayFormat.FormatString = "n2"
        Me.colOrig_Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrig_Balance.FieldName = "Orig_Balance"
        Me.colOrig_Balance.Name = "colOrig_Balance"
        Me.colOrig_Balance.OptionsColumn.AllowEdit = False
        Me.colOrig_Balance.OptionsColumn.ReadOnly = True
        Me.colOrig_Balance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Orig_Balance", "Sum={0:n2}")})
        Me.colOrig_Balance.Visible = True
        Me.colOrig_Balance.VisibleIndex = 4
        Me.colOrig_Balance.Width = 162
        '
        'colBalance_EUR_CR
        '
        Me.colBalance_EUR_CR.AppearanceCell.Options.UseTextOptions = True
        Me.colBalance_EUR_CR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colBalance_EUR_CR.Caption = "Credit Balance (EUR)"
        Me.colBalance_EUR_CR.DisplayFormat.FormatString = "n2"
        Me.colBalance_EUR_CR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBalance_EUR_CR.FieldName = "Balance_EUR_CR"
        Me.colBalance_EUR_CR.Name = "colBalance_EUR_CR"
        Me.colBalance_EUR_CR.OptionsColumn.AllowEdit = False
        Me.colBalance_EUR_CR.OptionsColumn.ReadOnly = True
        Me.colBalance_EUR_CR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance_EUR_CR", "Sum={0:n2}")})
        Me.colBalance_EUR_CR.Visible = True
        Me.colBalance_EUR_CR.VisibleIndex = 5
        Me.colBalance_EUR_CR.Width = 154
        '
        'colBalance_EUR_DR
        '
        Me.colBalance_EUR_DR.AppearanceCell.Options.UseTextOptions = True
        Me.colBalance_EUR_DR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colBalance_EUR_DR.Caption = "Debit Balance (EUR)"
        Me.colBalance_EUR_DR.DisplayFormat.FormatString = "n2"
        Me.colBalance_EUR_DR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBalance_EUR_DR.FieldName = "Balance_EUR_DR"
        Me.colBalance_EUR_DR.Name = "colBalance_EUR_DR"
        Me.colBalance_EUR_DR.OptionsColumn.AllowEdit = False
        Me.colBalance_EUR_DR.OptionsColumn.ReadOnly = True
        Me.colBalance_EUR_DR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance_EUR_DR", "Sum={0:n2}")})
        Me.colBalance_EUR_DR.Visible = True
        Me.colBalance_EUR_DR.VisibleIndex = 6
        Me.colBalance_EUR_DR.Width = 143
        '
        'colTotal_Balance
        '
        Me.colTotal_Balance.AppearanceCell.Options.UseTextOptions = True
        Me.colTotal_Balance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colTotal_Balance.Caption = "Total Balance"
        Me.colTotal_Balance.DisplayFormat.FormatString = "n2"
        Me.colTotal_Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTotal_Balance.FieldName = "Total_Balance"
        Me.colTotal_Balance.Name = "colTotal_Balance"
        Me.colTotal_Balance.OptionsColumn.AllowEdit = False
        Me.colTotal_Balance.OptionsColumn.ReadOnly = True
        Me.colTotal_Balance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", "Sum={0:n2}")})
        Me.colTotal_Balance.Visible = True
        Me.colTotal_Balance.VisibleIndex = 7
        Me.colTotal_Balance.Width = 150
        '
        'colBSDate1
        '
        Me.colBSDate1.FieldName = "BSDate"
        Me.colBSDate1.Name = "colBSDate1"
        Me.colBSDate1.OptionsColumn.AllowEdit = False
        Me.colBSDate1.OptionsColumn.ReadOnly = True
        '
        'colRepDate1
        '
        Me.colRepDate1.FieldName = "RepDate"
        Me.colRepDate1.Name = "colRepDate1"
        Me.colRepDate1.OptionsColumn.AllowEdit = False
        Me.colRepDate1.OptionsColumn.ReadOnly = True
        '
        'colIdBalanceSheets
        '
        Me.colIdBalanceSheets.FieldName = "IdBalanceSheets"
        Me.colIdBalanceSheets.Name = "colIdBalanceSheets"
        Me.colIdBalanceSheets.OptionsColumn.AllowEdit = False
        Me.colIdBalanceSheets.OptionsColumn.ReadOnly = True
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.DailyPLSheetExpensesBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode2.LevelTemplate = Me.ExpensesDetailView
        GridLevelNode2.RelationName = "FK_DailyBalanceDetailsSheets_DailyBalanceSheets4"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.GridControl2.Location = New System.Drawing.Point(12, 85)
        Me.GridControl2.MainView = Me.ExpensesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ZipCodeRepositoryItemTextEdit1, Me.OtherRepositoryItemTextEdit})
        Me.GridControl2.Size = New System.Drawing.Size(743, 584)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExpensesBaseView, Me.ExpensesDetailView})
        '
        'DailyPLSheetExpensesBindingSource
        '
        Me.DailyPLSheetExpensesBindingSource.DataMember = "DailyPLSheetExpenses"
        Me.DailyPLSheetExpensesBindingSource.DataSource = Me.PSTOOLDataset
        '
        'ExpensesBaseView
        '
        Me.ExpensesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExpensesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExpensesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExpensesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExpensesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExpensesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colGL_Item, Me.colGL_Item_Number, Me.colGL_Item_Name, Me.colBalanceEUREqu, Me.colBSDate, Me.colRepDate, Me.colIdBSDate, Me.colRilibiCodeExpenses, Me.colRilibiNameExpenses})
        Me.ExpensesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExpensesBaseView.GridControl = Me.GridControl2
        Me.ExpensesBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceEUREqu", Me.colBalanceEUREqu, "Active Sum = {0:C2}", New Decimal(New Integer() {0, 0, 0, 0}))})
        Me.ExpensesBaseView.Name = "ExpensesBaseView"
        Me.ExpensesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExpensesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExpensesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExpensesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExpensesBaseView.OptionsFind.AlwaysVisible = True
        Me.ExpensesBaseView.OptionsSelection.MultiSelect = True
        Me.ExpensesBaseView.OptionsView.ColumnAutoWidth = False
        Me.ExpensesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExpensesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.ExpensesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExpensesBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        Me.colID.OptionsColumn.ShowInCustomizationForm = False
        '
        'colGL_Item
        '
        Me.colGL_Item.Caption = "GL Item"
        Me.colGL_Item.FieldName = "GL_Item"
        Me.colGL_Item.Name = "colGL_Item"
        Me.colGL_Item.OptionsColumn.AllowEdit = False
        Me.colGL_Item.OptionsColumn.ReadOnly = True
        Me.colGL_Item.Visible = True
        Me.colGL_Item.VisibleIndex = 0
        '
        'colGL_Item_Number
        '
        Me.colGL_Item_Number.FieldName = "GL_Item_Number"
        Me.colGL_Item_Number.Name = "colGL_Item_Number"
        Me.colGL_Item_Number.OptionsColumn.AllowEdit = False
        Me.colGL_Item_Number.OptionsColumn.ReadOnly = True
        Me.colGL_Item_Number.OptionsColumn.ShowInCustomizationForm = False
        '
        'colGL_Item_Name
        '
        Me.colGL_Item_Name.Caption = "GL Item Name"
        Me.colGL_Item_Name.FieldName = "GL_Item_Name"
        Me.colGL_Item_Name.Name = "colGL_Item_Name"
        Me.colGL_Item_Name.OptionsColumn.AllowEdit = False
        Me.colGL_Item_Name.OptionsColumn.ReadOnly = True
        Me.colGL_Item_Name.Visible = True
        Me.colGL_Item_Name.VisibleIndex = 1
        Me.colGL_Item_Name.Width = 363
        '
        'colBalanceEUREqu
        '
        Me.colBalanceEUREqu.DisplayFormat.FormatString = "c2"
        Me.colBalanceEUREqu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colBalanceEUREqu.FieldName = "BalanceEUREqu"
        Me.colBalanceEUREqu.Name = "colBalanceEUREqu"
        Me.colBalanceEUREqu.OptionsColumn.AllowEdit = False
        Me.colBalanceEUREqu.OptionsColumn.ReadOnly = True
        Me.colBalanceEUREqu.Visible = True
        Me.colBalanceEUREqu.VisibleIndex = 2
        Me.colBalanceEUREqu.Width = 139
        '
        'colBSDate
        '
        Me.colBSDate.FieldName = "BSDate"
        Me.colBSDate.Name = "colBSDate"
        Me.colBSDate.OptionsColumn.AllowEdit = False
        Me.colBSDate.OptionsColumn.ReadOnly = True
        Me.colBSDate.OptionsColumn.ShowInCustomizationForm = False
        '
        'colRepDate
        '
        Me.colRepDate.FieldName = "RepDate"
        Me.colRepDate.Name = "colRepDate"
        Me.colRepDate.OptionsColumn.AllowEdit = False
        Me.colRepDate.OptionsColumn.ReadOnly = True
        Me.colRepDate.OptionsColumn.ShowInCustomizationForm = False
        '
        'colIdBSDate
        '
        Me.colIdBSDate.FieldName = "IdBSDate"
        Me.colIdBSDate.Name = "colIdBSDate"
        Me.colIdBSDate.OptionsColumn.AllowEdit = False
        Me.colIdBSDate.OptionsColumn.ReadOnly = True
        Me.colIdBSDate.OptionsColumn.ShowInCustomizationForm = False
        '
        'colRilibiCodeExpenses
        '
        Me.colRilibiCodeExpenses.Caption = "Rilibi Code"
        Me.colRilibiCodeExpenses.FieldName = "RilibiCode"
        Me.colRilibiCodeExpenses.Name = "colRilibiCodeExpenses"
        Me.colRilibiCodeExpenses.OptionsColumn.AllowEdit = False
        Me.colRilibiCodeExpenses.OptionsColumn.ReadOnly = True
        Me.colRilibiCodeExpenses.Visible = True
        Me.colRilibiCodeExpenses.VisibleIndex = 3
        '
        'colRilibiNameExpenses
        '
        Me.colRilibiNameExpenses.Caption = "Rilibi Name"
        Me.colRilibiNameExpenses.FieldName = "RilibiName"
        Me.colRilibiNameExpenses.Name = "colRilibiNameExpenses"
        Me.colRilibiNameExpenses.OptionsColumn.AllowEdit = False
        Me.colRilibiNameExpenses.OptionsColumn.ReadOnly = True
        Me.colRilibiNameExpenses.Visible = True
        Me.colRilibiNameExpenses.VisibleIndex = 4
        Me.colRilibiNameExpenses.Width = 339
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        '
        'ZipCodeRepositoryItemTextEdit1
        '
        Me.ZipCodeRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.ZipCodeRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.ZipCodeRepositoryItemTextEdit1.AutoHeight = False
        Me.ZipCodeRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ZipCodeRepositoryItemTextEdit1.Mask.EditMask = "[0-9]{5}"
        Me.ZipCodeRepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.ZipCodeRepositoryItemTextEdit1.Name = "ZipCodeRepositoryItemTextEdit1"
        '
        'OtherRepositoryItemTextEdit
        '
        Me.OtherRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.OtherRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OtherRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.OtherRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.OtherRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.OtherRepositoryItemTextEdit.AutoHeight = False
        Me.OtherRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OtherRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.OtherRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.OtherRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.OtherRepositoryItemTextEdit.Name = "OtherRepositoryItemTextEdit"
        '
        'DailyPLSheetExpensesTableAdapter
        '
        Me.DailyPLSheetExpensesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
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
        Me.TableAdapterManager.DailyBalanceSheetsTableAdapter = Me.DailyBalanceSheetsTableAdapter
        Me.TableAdapterManager.DailyPLSheetExpensesTableAdapter = Me.DailyPLSheetExpensesTableAdapter
        Me.TableAdapterManager.DailyPLSheetIncomeTableAdapter = Me.DailyPLSheetIncomeTableAdapter
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
        'DailyBalanceSheetsTableAdapter
        '
        Me.DailyBalanceSheetsTableAdapter.ClearBeforeFill = True
        '
        'DailyPLSheetIncomeTableAdapter
        '
        Me.DailyPLSheetIncomeTableAdapter.ClearBeforeFill = True
        '
        'DailyBalanceSheetsBindingSource
        '
        Me.DailyBalanceSheetsBindingSource.DataMember = "DailyBalanceSheets"
        Me.DailyBalanceSheetsBindingSource.DataSource = Me.PSTOOLDataset
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ReconciliationsPL_btn)
        Me.LayoutControl1.Controls.Add(Me.PLSheetCR_btn)
        Me.LayoutControl1.Controls.Add(Me.LabelControl2)
        Me.LayoutControl1.Controls.Add(Me.PLDifferenceTextEdit)
        Me.LayoutControl1.Controls.Add(Me.SumIncomesTextEdit)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.SumExpensesTextEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.DailyPLSheet_Print_Export_btn)
        Me.LayoutControl1.Controls.Add(Me.FromDateEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(376, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1544, 771)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ReconciliationsPL_btn
        '
        Me.ReconciliationsPL_btn.ImageIndex = 7
        Me.ReconciliationsPL_btn.ImageList = Me.ImageCollection1
        Me.ReconciliationsPL_btn.Location = New System.Drawing.Point(180, 38)
        Me.ReconciliationsPL_btn.Name = "ReconciliationsPL_btn"
        Me.ReconciliationsPL_btn.Size = New System.Drawing.Size(181, 22)
        Me.ReconciliationsPL_btn.StyleController = Me.LayoutControl1
        Me.ReconciliationsPL_btn.TabIndex = 20
        Me.ReconciliationsPL_btn.Text = "Reconciliations"
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
        '
        'PLSheetCR_btn
        '
        Me.PLSheetCR_btn.ImageIndex = 7
        Me.PLSheetCR_btn.ImageList = Me.ImageCollection1
        Me.PLSheetCR_btn.Location = New System.Drawing.Point(180, 12)
        Me.PLSheetCR_btn.Name = "PLSheetCR_btn"
        Me.PLSheetCR_btn.Size = New System.Drawing.Size(181, 22)
        Me.PLSheetCR_btn.StyleController = Me.LayoutControl1
        Me.PLSheetCR_btn.TabIndex = 19
        Me.PLSheetCR_btn.Text = "P+ L Sheet Report"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.Location = New System.Drawing.Point(1402, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(130, 17)
        Me.LabelControl2.StyleController = Me.LayoutControl1
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "I N C O M E "
        '
        'PLDifferenceTextEdit
        '
        Me.PLDifferenceTextEdit.Location = New System.Drawing.Point(658, 731)
        Me.PLDifferenceTextEdit.Name = "PLDifferenceTextEdit"
        Me.PLDifferenceTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PLDifferenceTextEdit.Properties.Appearance.Options.UseFont = True
        Me.PLDifferenceTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.PLDifferenceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PLDifferenceTextEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Yellow
        Me.PLDifferenceTextEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.PLDifferenceTextEdit.Properties.DisplayFormat.FormatString = "c2"
        Me.PLDifferenceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.PLDifferenceTextEdit.Properties.Mask.EditMask = "c2"
        Me.PLDifferenceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.PLDifferenceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.PLDifferenceTextEdit.Properties.ReadOnly = True
        Me.PLDifferenceTextEdit.Size = New System.Drawing.Size(225, 22)
        Me.PLDifferenceTextEdit.StyleController = Me.LayoutControl1
        Me.PLDifferenceTextEdit.TabIndex = 17
        '
        'SumIncomesTextEdit
        '
        Me.SumIncomesTextEdit.Location = New System.Drawing.Point(775, 689)
        Me.SumIncomesTextEdit.Name = "SumIncomesTextEdit"
        Me.SumIncomesTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SumIncomesTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.SumIncomesTextEdit.Properties.Appearance.Options.UseFont = True
        Me.SumIncomesTextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.SumIncomesTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.SumIncomesTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SumIncomesTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SumIncomesTextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SumIncomesTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SumIncomesTextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.SumIncomesTextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SumIncomesTextEdit.Properties.DisplayFormat.FormatString = "c2"
        Me.SumIncomesTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.SumIncomesTextEdit.Properties.Mask.EditMask = "c2"
        Me.SumIncomesTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SumIncomesTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SumIncomesTextEdit.Properties.ReadOnly = True
        Me.SumIncomesTextEdit.Size = New System.Drawing.Size(224, 22)
        Me.SumIncomesTextEdit.StyleController = Me.LayoutControl1
        Me.SumIncomesTextEdit.TabIndex = 16
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(743, 17)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "E X P E N S E S"
        '
        'SumExpensesTextEdit
        '
        Me.SumExpensesTextEdit.Location = New System.Drawing.Point(535, 689)
        Me.SumExpensesTextEdit.Name = "SumExpensesTextEdit"
        Me.SumExpensesTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SumExpensesTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.OrangeRed
        Me.SumExpensesTextEdit.Properties.Appearance.Options.UseFont = True
        Me.SumExpensesTextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.SumExpensesTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.SumExpensesTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SumExpensesTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SumExpensesTextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SumExpensesTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SumExpensesTextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.SumExpensesTextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SumExpensesTextEdit.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SumExpensesTextEdit.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SumExpensesTextEdit.Properties.DisplayFormat.FormatString = "c2"
        Me.SumExpensesTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.SumExpensesTextEdit.Properties.Mask.EditMask = "c2"
        Me.SumExpensesTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.SumExpensesTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.SumExpensesTextEdit.Properties.ReadOnly = True
        Me.SumExpensesTextEdit.Size = New System.Drawing.Size(220, 22)
        Me.SumExpensesTextEdit.StyleController = Me.LayoutControl1
        Me.SumExpensesTextEdit.TabIndex = 14
        '
        'DailyPLSheet_Print_Export_btn
        '
        Me.DailyPLSheet_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DailyPLSheet_Print_Export_btn.ImageIndex = 2
        Me.DailyPLSheet_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.DailyPLSheet_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.DailyPLSheet_Print_Export_btn.Name = "DailyPLSheet_Print_Export_btn"
        Me.DailyPLSheet_Print_Export_btn.Size = New System.Drawing.Size(164, 22)
        Me.DailyPLSheet_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.DailyPLSheet_Print_Export_btn.TabIndex = 9
        Me.DailyPLSheet_Print_Export_btn.Text = "Print or Export"
        '
        'FromDateEdit
        '
        Me.FromDateEdit.Location = New System.Drawing.Point(650, 28)
        Me.FromDateEdit.Name = "FromDateEdit"
        Me.FromDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.FromDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FromDateEdit.Properties.Appearance.Options.UseFont = True
        Me.FromDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.FromDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FromDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FromDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FromDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FromDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FromDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FromDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Reload", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleLeft, CType(resources.GetObject("FromDateEdit.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.FromDateEdit.Properties.DisplayFormat.FormatString = "d"
        Me.FromDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDateEdit.Properties.EditFormat.FormatString = "d"
        Me.FromDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.FromDateEdit.Size = New System.Drawing.Size(223, 22)
        Me.FromDateEdit.StyleController = Me.LayoutControl1
        Me.FromDateEdit.TabIndex = 13
        '
        'LayoutControlItem2
        '
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.EmptySpaceItem3, Me.EmptySpaceItem7, Me.EmptySpaceItem8, Me.LayoutControlItem11, Me.EmptySpaceItem9, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem9, Me.SplitterItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1544, 771)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(865, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(503, 52)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DailyPLSheet_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(168, 52)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(353, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(285, 52)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1368, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(156, 52)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 73)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(747, 588)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridControl1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(752, 73)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(203, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(772, 588)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem5.Control = Me.FromDateEdit
        Me.LayoutControlItem5.CustomizationFormText = "Date"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(638, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(227, 52)
        Me.LayoutControlItem5.Text = "Date"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(69, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SumExpensesTextEdit
        Me.LayoutControlItem7.CustomizationFormText = "Sum Activa"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(523, 661)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(224, 42)
        Me.LayoutControlItem7.Text = "Sum Expenses"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.CustomizationFormText = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 661)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(523, 42)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.CustomizationFormText = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(747, 52)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(643, 21)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem8.Control = Me.LabelControl1
        Me.LayoutControlItem8.CustomizationFormText = "A C T I V A"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(747, 21)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "A C T I V A"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SumIncomesTextEdit
        Me.LayoutControlItem10.CustomizationFormText = "Sum Passiva"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(763, 661)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(228, 42)
        Me.LayoutControlItem10.Text = "Sum Income"
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(747, 661)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(16, 42)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.CustomizationFormText = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(991, 661)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(533, 42)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.CustomizationFormText = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(875, 703)
        Me.EmptySpaceItem8.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(649, 48)
        Me.EmptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem11.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem11.Control = Me.PLDifferenceTextEdit
        Me.LayoutControlItem11.CustomizationFormText = "Difference"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(646, 703)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(63, 42)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(229, 48)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.Text = "Profit/Loss"
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(69, 13)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.CustomizationFormText = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(0, 703)
        Me.EmptySpaceItem9.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(646, 48)
        Me.EmptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem12.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem12.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem12.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem12.Control = Me.LabelControl2
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(1390, 52)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(134, 21)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.PLSheetCR_btn
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(168, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(185, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ReconciliationsPL_btn
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(168, 26)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(185, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Inverted = False
        Me.SplitterItem1.Location = New System.Drawing.Point(747, 73)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 588)
        '
        'DailyBalanceDetailsSheetsBindingSource
        '
        Me.DailyBalanceDetailsSheetsBindingSource.DataMember = "FK_DailyBalanceDetailsSheets_DailyBalanceSheets"
        Me.DailyBalanceDetailsSheetsBindingSource.DataSource = Me.DailyBalanceSheetsBindingSource
        '
        'DailyBalanceDetailsSheetsTableAdapter
        '
        Me.DailyBalanceDetailsSheetsTableAdapter.ClearBeforeFill = True
        '
        'DailyProfitLossSheets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1544, 771)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DailyProfitLossSheets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Daily Profit + Loss Sheets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.IncomeDetailsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyPLSheetIncomeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncomeBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyPLSheetExpensesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyBalanceSheetsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLDifferenceTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumIncomesTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumExpensesTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyBalanceDetailsSheetsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents DailyPLSheetExpensesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyPLSheetExpensesTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyPLSheetExpensesTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents DailyPLSheetIncomeTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyPLSheetIncomeTableAdapter
    Friend WithEvents DailyPLSheetIncomeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyBalanceSheetsTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyBalanceSheetsTableAdapter
    Friend WithEvents DailyBalanceSheetsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PLSheetCR_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PLDifferenceTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SumIncomesTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SumExpensesTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents IncomeBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExpensesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZipCodeRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents OtherRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DailyPLSheet_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item_Number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBalanceEUREqu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBSDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRepDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBSDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReconciliationsPL_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DailyBalanceDetailsSheetsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyBalanceDetailsSheetsTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.DailyBalanceDetailsSheetsTableAdapter
    Friend WithEvents IncomeDetailsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpensesDetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReleatedAccountNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Account_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Account_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrig_CUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrig_Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBalance_EUR_CR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBalance_EUR_DR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotal_Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBSDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRepDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBalanceSheets As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents colRilibiCodeIncome As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRilibiNameIncome As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRilibiCodeExpenses As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRilibiNameExpenses As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FromDateEdit As DevExpress.XtraEditors.ComboBoxEdit
End Class
