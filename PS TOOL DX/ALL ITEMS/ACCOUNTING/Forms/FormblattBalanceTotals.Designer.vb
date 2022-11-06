<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormblattBalanceTotals
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormblattBalanceTotals))
        Me.PassivaDetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FormblattBalanceDataset = New PS_TOOL_DX.FormblattBalanceDataset()
        Me.PassivaBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ActivaDetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReleatedAccountNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Account_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Account_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotal_Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBSDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRilibiName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdFormblattBALANCE_TOTALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ActivaBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBilanzposition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colBilanzpositionArt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountCurrentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountCurrentDate_UP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountLastYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountLastYear_UP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountManualBooking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colSQLcommandCurrentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQLcommandLastYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ZipCodeRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter = New PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.TableAdapterManager()
        Me.Formblatt_BILANZ_DetailsTableAdapter = New PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_DetailsTableAdapter()
        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter = New PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter()
        Me.Formblatt_BILANZ_DetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Formblatt_BILANZ_DetailsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ReconciliationBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.BalanceSheetCR_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadDailyBalanceSheets_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.FromDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DailyBalanceSheet_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.PassivaDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormblattBalanceDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassivaBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivaDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivaBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Formblatt_BILANZ_DetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Formblatt_BILANZ_DetailsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PassivaDetailView
        '
        Me.PassivaDetailView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.PassivaDetailView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.PassivaDetailView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.PassivaDetailView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.PassivaDetailView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.PassivaDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.PassivaDetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.PassivaDetailView.GridControl = Me.GridControl1
        Me.PassivaDetailView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", Me.GridColumn17, "Sum={0:n2}", "1")})
        Me.PassivaDetailView.Name = "PassivaDetailView"
        Me.PassivaDetailView.OptionsBehavior.AllowIncrementalSearch = True
        Me.PassivaDetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.PassivaDetailView.OptionsPrint.PrintFilterInfo = True
        Me.PassivaDetailView.OptionsSelection.MultiSelect = True
        Me.PassivaDetailView.OptionsView.ColumnAutoWidth = False
        Me.PassivaDetailView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.PassivaDetailView.OptionsView.ShowAutoFilterRow = True
        Me.PassivaDetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.PassivaDetailView.OptionsView.ShowFooter = True
        Me.PassivaDetailView.ViewCaption = "Activa Details"
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "ID"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GL Item"
        Me.GridColumn13.FieldName = "GL_Item"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Related Account Nr."
        Me.GridColumn14.FieldName = "ReleatedAccountNr"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        Me.GridColumn14.Width = 127
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "GL Account Nr."
        Me.GridColumn15.FieldName = "GL_Account_Nr"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        Me.GridColumn15.Width = 107
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "GL Account Name"
        Me.GridColumn16.FieldName = "GL_Account_Name"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 3
        Me.GridColumn16.Width = 192
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Total Balance"
        Me.GridColumn17.DisplayFormat.FormatString = "n2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "Total_Balance"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", "Sum={0:n2}", "1")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 4
        Me.GridColumn17.Width = 127
        '
        'GridColumn18
        '
        Me.GridColumn18.FieldName = "BSDate"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "RilibiCode"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 5
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "RilibiName"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 6
        Me.GridColumn20.Width = 375
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "IdFormblattBALANCE_TOTALS"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.PassivaDetailView
        GridLevelNode1.RelationName = "FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS2"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(753, 98)
        Me.GridControl1.MainView = Me.PassivaBaseView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox2, Me.AmountRepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoEdit2, Me.RepositoryItemMemoExEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(758, 694)
        Me.GridControl1.TabIndex = 12
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PassivaBaseView, Me.PassivaDetailView})
        '
        'Formblatt_BILANZ_TOTALS_PASSIVABindingSource
        '
        Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource.DataMember = "Formblatt_BILANZ_TOTALS_PASSIVA"
        Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource.DataSource = Me.FormblattBalanceDataset
        '
        'FormblattBalanceDataset
        '
        Me.FormblattBalanceDataset.DataSetName = "FormblattBalanceDataset"
        Me.FormblattBalanceDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PassivaBaseView
        '
        Me.PassivaBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.PassivaBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.PassivaBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.PassivaBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.PassivaBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.PassivaBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11})
        Me.PassivaBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.PassivaBaseView.GridControl = Me.GridControl1
        Me.PassivaBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", Me.GridColumn4, "Summe Passiva={0:n2}", "0"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountLastYear", Me.GridColumn6, "Summe Passiva (Vorjahr)={0:n0}", "1"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", Me.GridColumn4, "Billanzdifferenz={0:n2}", "2")})
        Me.PassivaBaseView.Name = "PassivaBaseView"
        Me.PassivaBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.PassivaBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.PassivaBaseView.OptionsCustomization.AllowRowSizing = True
        Me.PassivaBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.PassivaBaseView.OptionsFind.AlwaysVisible = True
        Me.PassivaBaseView.OptionsPrint.PrintDetails = True
        Me.PassivaBaseView.OptionsPrint.PrintFilterInfo = True
        Me.PassivaBaseView.OptionsSelection.MultiSelect = True
        Me.PassivaBaseView.OptionsView.ColumnAutoWidth = False
        Me.PassivaBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.PassivaBaseView.OptionsView.RowAutoHeight = True
        Me.PassivaBaseView.OptionsView.ShowAutoFilterRow = True
        Me.PassivaBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.PassivaBaseView.OptionsView.ShowFooter = True
        Me.PassivaBaseView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GridColumn2.FieldName = "Bilanzposition"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 329
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "BilanzpositionArt"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Width = 119
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Euro"
        Me.GridColumn4.DisplayFormat.FormatString = "n2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "AmountCurrentDate"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", "Summe Passiva={0:n2}", "0"), New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", "Billanzdifferenz={0:n2}", "2")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 219
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Betrag Unterposition"
        Me.GridColumn5.DisplayFormat.FormatString = "n2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "AmountCurrentDate_UP"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 133
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.Caption = "Vorj.TEuro"
        Me.GridColumn6.DisplayFormat.FormatString = "n0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "AmountLastYear"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountLastYear", "Summe Passiva (Vorjahr)={0:n0}", "1")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 219
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.DisplayFormat.FormatString = "n2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "AmountLastYear_UP"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Width = 124
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Manuelle Buchung"
        Me.GridColumn8.ColumnEdit = Me.AmountRepositoryItemTextEdit1
        Me.GridColumn8.DisplayFormat.FormatString = "n2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "AmountManualBooking"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 167
        '
        'AmountRepositoryItemTextEdit1
        '
        Me.AmountRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit1.AutoHeight = False
        Me.AmountRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AmountRepositoryItemTextEdit1.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit1.Name = "AmountRepositoryItemTextEdit1"
        '
        'GridColumn9
        '
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.GridColumn9.FieldName = "SQLcommandCurrentDate"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AutoHeight = False
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        Me.RepositoryItemMemoExEdit2.PopupFormSize = New System.Drawing.Size(600, 600)
        '
        'GridColumn10
        '
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.GridColumn10.FieldName = "SQLcommandLastYear"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.FieldName = "RiskDate"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
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
        'ActivaDetailView
        '
        Me.ActivaDetailView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ActivaDetailView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ActivaDetailView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ActivaDetailView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ActivaDetailView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ActivaDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colGL_Item, Me.colReleatedAccountNr, Me.colGL_Account_Nr, Me.colGL_Account_Name, Me.colTotal_Balance, Me.colBSDate, Me.colRilibiCode, Me.colRilibiName, Me.colIdFormblattBALANCE_TOTALS})
        Me.ActivaDetailView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ActivaDetailView.GridControl = Me.GridControl2
        Me.ActivaDetailView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", Me.colTotal_Balance, "Sum={0:n2}", "1")})
        Me.ActivaDetailView.Name = "ActivaDetailView"
        Me.ActivaDetailView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ActivaDetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ActivaDetailView.OptionsPrint.PrintFilterInfo = True
        Me.ActivaDetailView.OptionsSelection.MultiSelect = True
        Me.ActivaDetailView.OptionsView.ColumnAutoWidth = False
        Me.ActivaDetailView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ActivaDetailView.OptionsView.ShowAutoFilterRow = True
        Me.ActivaDetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ActivaDetailView.OptionsView.ShowFooter = True
        Me.ActivaDetailView.ViewCaption = "Activa Details"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
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
        'colReleatedAccountNr
        '
        Me.colReleatedAccountNr.Caption = "Related Account Nr."
        Me.colReleatedAccountNr.FieldName = "ReleatedAccountNr"
        Me.colReleatedAccountNr.Name = "colReleatedAccountNr"
        Me.colReleatedAccountNr.OptionsColumn.AllowEdit = False
        Me.colReleatedAccountNr.OptionsColumn.ReadOnly = True
        Me.colReleatedAccountNr.Visible = True
        Me.colReleatedAccountNr.VisibleIndex = 1
        Me.colReleatedAccountNr.Width = 127
        '
        'colGL_Account_Nr
        '
        Me.colGL_Account_Nr.Caption = "GL Account Nr."
        Me.colGL_Account_Nr.FieldName = "GL_Account_Nr"
        Me.colGL_Account_Nr.Name = "colGL_Account_Nr"
        Me.colGL_Account_Nr.OptionsColumn.AllowEdit = False
        Me.colGL_Account_Nr.OptionsColumn.ReadOnly = True
        Me.colGL_Account_Nr.Visible = True
        Me.colGL_Account_Nr.VisibleIndex = 2
        Me.colGL_Account_Nr.Width = 107
        '
        'colGL_Account_Name
        '
        Me.colGL_Account_Name.Caption = "GL Account Name"
        Me.colGL_Account_Name.FieldName = "GL_Account_Name"
        Me.colGL_Account_Name.Name = "colGL_Account_Name"
        Me.colGL_Account_Name.OptionsColumn.AllowEdit = False
        Me.colGL_Account_Name.OptionsColumn.ReadOnly = True
        Me.colGL_Account_Name.Visible = True
        Me.colGL_Account_Name.VisibleIndex = 3
        Me.colGL_Account_Name.Width = 192
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
        Me.colTotal_Balance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Balance", "Sum={0:n2}", "1")})
        Me.colTotal_Balance.Visible = True
        Me.colTotal_Balance.VisibleIndex = 4
        Me.colTotal_Balance.Width = 127
        '
        'colBSDate
        '
        Me.colBSDate.FieldName = "BSDate"
        Me.colBSDate.Name = "colBSDate"
        Me.colBSDate.OptionsColumn.AllowEdit = False
        Me.colBSDate.OptionsColumn.ReadOnly = True
        '
        'colRilibiCode
        '
        Me.colRilibiCode.FieldName = "RilibiCode"
        Me.colRilibiCode.Name = "colRilibiCode"
        Me.colRilibiCode.OptionsColumn.AllowEdit = False
        Me.colRilibiCode.OptionsColumn.ReadOnly = True
        Me.colRilibiCode.Visible = True
        Me.colRilibiCode.VisibleIndex = 5
        '
        'colRilibiName
        '
        Me.colRilibiName.FieldName = "RilibiName"
        Me.colRilibiName.Name = "colRilibiName"
        Me.colRilibiName.OptionsColumn.AllowEdit = False
        Me.colRilibiName.OptionsColumn.ReadOnly = True
        Me.colRilibiName.Visible = True
        Me.colRilibiName.VisibleIndex = 6
        Me.colRilibiName.Width = 375
        '
        'colIdFormblattBALANCE_TOTALS
        '
        Me.colIdFormblattBALANCE_TOTALS.FieldName = "IdFormblattBALANCE_TOTALS"
        Me.colIdFormblattBALANCE_TOTALS.Name = "colIdFormblattBALANCE_TOTALS"
        Me.colIdFormblattBALANCE_TOTALS.OptionsColumn.AllowEdit = False
        Me.colIdFormblattBALANCE_TOTALS.OptionsColumn.ReadOnly = True
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode2.LevelTemplate = Me.ActivaDetailView
        GridLevelNode2.RelationName = "FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.GridControl2.Location = New System.Drawing.Point(12, 98)
        Me.GridControl2.MainView = Me.ActivaBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ZipCodeRepositoryItemTextEdit1, Me.AmountRepositoryItemTextEdit, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoExEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(732, 694)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ActivaBaseView, Me.ActivaDetailView})
        '
        'Formblatt_BILANZ_TOTALS_ACTIVABindingSource
        '
        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.DataMember = "Formblatt_BILANZ_TOTALS_ACTIVA"
        Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource.DataSource = Me.FormblattBalanceDataset
        '
        'ActivaBaseView
        '
        Me.ActivaBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ActivaBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ActivaBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ActivaBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ActivaBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ActivaBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colBilanzposition, Me.colBilanzpositionArt, Me.colAmountCurrentDate, Me.colAmountCurrentDate_UP, Me.colAmountLastYear, Me.colAmountLastYear_UP, Me.colAmountManualBooking, Me.colSQLcommandCurrentDate, Me.colSQLcommandLastYear, Me.colRiskDate})
        Me.ActivaBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ActivaBaseView.GridControl = Me.GridControl2
        Me.ActivaBaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", Me.colAmountCurrentDate, "Summe Aktiva = {0:n2}", New Decimal(New Integer() {0, 0, 0, 0})), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", Me.colAmountCurrentDate, "Bilanzdifferenz = {0:n2}", "1"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountLastYear", Me.colAmountLastYear, "Summe Aktiva (Vorjahr)={0:n0}", "2")})
        Me.ActivaBaseView.Name = "ActivaBaseView"
        Me.ActivaBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ActivaBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ActivaBaseView.OptionsCustomization.AllowRowSizing = True
        Me.ActivaBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ActivaBaseView.OptionsFind.AlwaysVisible = True
        Me.ActivaBaseView.OptionsPrint.PrintDetails = True
        Me.ActivaBaseView.OptionsPrint.PrintFilterInfo = True
        Me.ActivaBaseView.OptionsSelection.MultiSelect = True
        Me.ActivaBaseView.OptionsView.ColumnAutoWidth = False
        Me.ActivaBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ActivaBaseView.OptionsView.RowAutoHeight = True
        Me.ActivaBaseView.OptionsView.ShowAutoFilterRow = True
        Me.ActivaBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ActivaBaseView.OptionsView.ShowFooter = True
        Me.ActivaBaseView.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colBilanzposition
        '
        Me.colBilanzposition.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.colBilanzposition.FieldName = "Bilanzposition"
        Me.colBilanzposition.Name = "colBilanzposition"
        Me.colBilanzposition.OptionsColumn.AllowEdit = False
        Me.colBilanzposition.OptionsColumn.ReadOnly = True
        Me.colBilanzposition.Visible = True
        Me.colBilanzposition.VisibleIndex = 0
        Me.colBilanzposition.Width = 328
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'colBilanzpositionArt
        '
        Me.colBilanzpositionArt.FieldName = "BilanzpositionArt"
        Me.colBilanzpositionArt.Name = "colBilanzpositionArt"
        Me.colBilanzpositionArt.OptionsColumn.AllowEdit = False
        Me.colBilanzpositionArt.OptionsColumn.ReadOnly = True
        Me.colBilanzpositionArt.Width = 119
        '
        'colAmountCurrentDate
        '
        Me.colAmountCurrentDate.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountCurrentDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountCurrentDate.Caption = "Euro"
        Me.colAmountCurrentDate.DisplayFormat.FormatString = "n2"
        Me.colAmountCurrentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountCurrentDate.FieldName = "AmountCurrentDate"
        Me.colAmountCurrentDate.Name = "colAmountCurrentDate"
        Me.colAmountCurrentDate.OptionsColumn.ReadOnly = True
        Me.colAmountCurrentDate.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", "Summe Aktiva={0:n2}", "0"), New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountCurrentDate", "Bilanzdifferenz={0:n2}", "1")})
        Me.colAmountCurrentDate.Visible = True
        Me.colAmountCurrentDate.VisibleIndex = 2
        Me.colAmountCurrentDate.Width = 202
        '
        'colAmountCurrentDate_UP
        '
        Me.colAmountCurrentDate_UP.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountCurrentDate_UP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountCurrentDate_UP.Caption = "Betrag Unterposition"
        Me.colAmountCurrentDate_UP.DisplayFormat.FormatString = "n2"
        Me.colAmountCurrentDate_UP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountCurrentDate_UP.FieldName = "AmountCurrentDate_UP"
        Me.colAmountCurrentDate_UP.Name = "colAmountCurrentDate_UP"
        Me.colAmountCurrentDate_UP.OptionsColumn.ReadOnly = True
        Me.colAmountCurrentDate_UP.Visible = True
        Me.colAmountCurrentDate_UP.VisibleIndex = 1
        Me.colAmountCurrentDate_UP.Width = 129
        '
        'colAmountLastYear
        '
        Me.colAmountLastYear.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountLastYear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountLastYear.Caption = "Vorj.TEuro"
        Me.colAmountLastYear.DisplayFormat.FormatString = "n0"
        Me.colAmountLastYear.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountLastYear.FieldName = "AmountLastYear"
        Me.colAmountLastYear.Name = "colAmountLastYear"
        Me.colAmountLastYear.OptionsColumn.ReadOnly = True
        Me.colAmountLastYear.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AmountLastYear", "Summe Aktiva (Vorjahr)={0:n0}", "2")})
        Me.colAmountLastYear.Visible = True
        Me.colAmountLastYear.VisibleIndex = 3
        Me.colAmountLastYear.Width = 193
        '
        'colAmountLastYear_UP
        '
        Me.colAmountLastYear_UP.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountLastYear_UP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountLastYear_UP.DisplayFormat.FormatString = "n2"
        Me.colAmountLastYear_UP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountLastYear_UP.FieldName = "AmountLastYear_UP"
        Me.colAmountLastYear_UP.Name = "colAmountLastYear_UP"
        Me.colAmountLastYear_UP.OptionsColumn.ReadOnly = True
        Me.colAmountLastYear_UP.Width = 124
        '
        'colAmountManualBooking
        '
        Me.colAmountManualBooking.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountManualBooking.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountManualBooking.Caption = "Manuelle Buchung"
        Me.colAmountManualBooking.ColumnEdit = Me.AmountRepositoryItemTextEdit
        Me.colAmountManualBooking.DisplayFormat.FormatString = "n2"
        Me.colAmountManualBooking.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountManualBooking.FieldName = "AmountManualBooking"
        Me.colAmountManualBooking.Name = "colAmountManualBooking"
        Me.colAmountManualBooking.Width = 167
        '
        'AmountRepositoryItemTextEdit
        '
        Me.AmountRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit.AutoHeight = False
        Me.AmountRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AmountRepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.AmountRepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.AmountRepositoryItemTextEdit.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.AmountRepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit.Name = "AmountRepositoryItemTextEdit"
        '
        'colSQLcommandCurrentDate
        '
        Me.colSQLcommandCurrentDate.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQLcommandCurrentDate.FieldName = "SQLcommandCurrentDate"
        Me.colSQLcommandCurrentDate.Name = "colSQLcommandCurrentDate"
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(600, 600)
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colSQLcommandLastYear
        '
        Me.colSQLcommandLastYear.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQLcommandLastYear.FieldName = "SQLcommandLastYear"
        Me.colSQLcommandLastYear.Name = "colSQLcommandLastYear"
        '
        'colRiskDate
        '
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.OptionsColumn.AllowEdit = False
        Me.colRiskDate.OptionsColumn.ReadOnly = True
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
        'Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter
        '
        Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Formblatt_BILANZ_DetailsTableAdapter = Me.Formblatt_BILANZ_DetailsTableAdapter
        Me.TableAdapterManager.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter = Me.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter
        Me.TableAdapterManager.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter = Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter
        Me.TableAdapterManager.Formblatt_BILANZ_TOTALSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Formblatt_BILANZ_DetailsTableAdapter
        '
        Me.Formblatt_BILANZ_DetailsTableAdapter.ClearBeforeFill = True
        '
        'Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter
        '
        Me.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter.ClearBeforeFill = True
        '
        'Formblatt_BILANZ_DetailsBindingSource
        '
        Me.Formblatt_BILANZ_DetailsBindingSource.DataMember = "FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS1"
        Me.Formblatt_BILANZ_DetailsBindingSource.DataSource = Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource
        '
        'Formblatt_BILANZ_DetailsBindingSource1
        '
        Me.Formblatt_BILANZ_DetailsBindingSource1.DataMember = "FK_Formblatt_BILANZ_Details_Formblatt_BILANZ_TOTALS2"
        Me.Formblatt_BILANZ_DetailsBindingSource1.DataSource = Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ReconciliationBS_btn)
        Me.LayoutControl1.Controls.Add(Me.BalanceSheetCR_btn)
        Me.LayoutControl1.Controls.Add(Me.LabelControl2)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.LoadDailyBalanceSheets_btn)
        Me.LayoutControl1.Controls.Add(Me.FromDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.DailyBalanceSheet_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(408, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1523, 804)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ReconciliationBS_btn
        '
        Me.ReconciliationBS_btn.ImageIndex = 7
        Me.ReconciliationBS_btn.ImageList = Me.ImageCollection1
        Me.ReconciliationBS_btn.Location = New System.Drawing.Point(177, 38)
        Me.ReconciliationBS_btn.Name = "ReconciliationBS_btn"
        Me.ReconciliationBS_btn.Size = New System.Drawing.Size(178, 22)
        Me.ReconciliationBS_btn.StyleController = Me.LayoutControl1
        Me.ReconciliationBS_btn.TabIndex = 20
        Me.ReconciliationBS_btn.Text = "Reconciliations"
        '
        'BalanceSheetCR_btn
        '
        Me.BalanceSheetCR_btn.ImageIndex = 7
        Me.BalanceSheetCR_btn.ImageList = Me.ImageCollection1
        Me.BalanceSheetCR_btn.Location = New System.Drawing.Point(177, 12)
        Me.BalanceSheetCR_btn.Name = "BalanceSheetCR_btn"
        Me.BalanceSheetCR_btn.Size = New System.Drawing.Size(178, 22)
        Me.BalanceSheetCR_btn.StyleController = Me.LayoutControl1
        Me.BalanceSheetCR_btn.TabIndex = 19
        Me.BalanceSheetCR_btn.Text = "Balance Sheet Report"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.Location = New System.Drawing.Point(1383, 80)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(128, 14)
        Me.LabelControl2.StyleController = Me.LayoutControl1
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "P A S S I V S E I T E"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 80)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(732, 14)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "A K T I V S E I T E"
        '
        'LoadDailyBalanceSheets_btn
        '
        Me.LoadDailyBalanceSheets_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadDailyBalanceSheets_btn.ImageIndex = 6
        Me.LoadDailyBalanceSheets_btn.ImageList = Me.ImageCollection1
        Me.LoadDailyBalanceSheets_btn.Location = New System.Drawing.Point(667, 54)
        Me.LoadDailyBalanceSheets_btn.Name = "LoadDailyBalanceSheets_btn"
        Me.LoadDailyBalanceSheets_btn.Size = New System.Drawing.Size(166, 22)
        Me.LoadDailyBalanceSheets_btn.StyleController = Me.LayoutControl1
        Me.LoadDailyBalanceSheets_btn.TabIndex = 9
        Me.LoadDailyBalanceSheets_btn.Text = "Load Balance Sheet"
        '
        'FromDateEdit
        '
        Me.FromDateEdit.EditValue = Nothing
        Me.FromDateEdit.Location = New System.Drawing.Point(667, 28)
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
        Me.FromDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDateEdit.Size = New System.Drawing.Size(166, 22)
        Me.FromDateEdit.StyleController = Me.LayoutControl1
        Me.FromDateEdit.TabIndex = 13
        '
        'DailyBalanceSheet_Print_Export_btn
        '
        Me.DailyBalanceSheet_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DailyBalanceSheet_Print_Export_btn.ImageIndex = 2
        Me.DailyBalanceSheet_Print_Export_btn.ImageList = Me.ImageCollection1
        Me.DailyBalanceSheet_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.DailyBalanceSheet_Print_Export_btn.Name = "DailyBalanceSheet_Print_Export_btn"
        Me.DailyBalanceSheet_Print_Export_btn.Size = New System.Drawing.Size(161, 22)
        Me.DailyBalanceSheet_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.DailyBalanceSheet_Print_Export_btn.TabIndex = 9
        Me.DailyBalanceSheet_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.EmptySpaceItem6, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.SplitterItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1523, 804)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(825, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(524, 68)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DailyBalanceSheet_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(165, 68)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(347, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(308, 68)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1349, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(154, 68)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 86)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(736, 698)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridControl1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(741, 86)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(203, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(762, 698)
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
        Me.LayoutControlItem5.Location = New System.Drawing.Point(655, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(170, 42)
        Me.LayoutControlItem5.Text = "Date"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(23, 13)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.CustomizationFormText = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(736, 68)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(635, 18)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem8.Control = Me.LabelControl1
        Me.LayoutControlItem8.CustomizationFormText = "A C T I V A"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(736, 18)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "A C T I V A"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LoadDailyBalanceSheets_btn
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(655, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(170, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem12.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem12.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem12.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem12.Control = Me.LabelControl2
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(1371, 68)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(132, 18)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.BalanceSheetCR_btn
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(165, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(182, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.ReconciliationBS_btn
        Me.LayoutControlItem14.CustomizationFormText = "LayoutControlItem14"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(165, 26)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(182, 42)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.CustomizationFormText = "SplitterItem1"
        Me.SplitterItem1.Inverted = False
        Me.SplitterItem1.Location = New System.Drawing.Point(736, 86)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 698)
        '
        'FormblattBalanceTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1523, 804)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormblattBalanceTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formblatt BILANZ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PassivaDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Formblatt_BILANZ_TOTALS_PASSIVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormblattBalanceDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassivaBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivaDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Formblatt_BILANZ_TOTALS_ACTIVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivaBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZipCodeRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Formblatt_BILANZ_DetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Formblatt_BILANZ_DetailsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FromDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents FormblattBalanceDataset As PS_TOOL_DX.FormblattBalanceDataset
    Friend WithEvents Formblatt_BILANZ_TOTALS_ACTIVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter As PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_TOTALS_ACTIVA_TableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.TableAdapterManager
    Friend WithEvents Formblatt_BILANZ_DetailsTableAdapter As PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_DetailsTableAdapter
    Friend WithEvents Formblatt_BILANZ_DetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter As PS_TOOL_DX.FormblattBalanceDatasetTableAdapters.Formblatt_BILANZ_TOTALS_PASSIVA_TableAdapter
    Friend WithEvents Formblatt_BILANZ_TOTALS_PASSIVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Formblatt_BILANZ_DetailsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ReconciliationBS_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BalanceSheetCR_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadDailyBalanceSheets_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FromDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents PassivaDetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PassivaBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents AmountRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ActivaDetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ActivaBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZipCodeRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents AmountRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents DailyBalanceSheet_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReleatedAccountNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Account_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Account_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotal_Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBSDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRilibiCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRilibiName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdFormblattBALANCE_TOTALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBilanzposition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBilanzpositionArt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountCurrentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountCurrentDate_UP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountLastYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountLastYear_UP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountManualBooking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLcommandCurrentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLcommandLastYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
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
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
