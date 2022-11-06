<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZvStatistikReporting
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZvStatistikReporting))
        Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
        Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Me.colSubdivisionOfCountryCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colLastAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnzahl_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Anzahl_SpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colWert_Value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Wert_SpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.ZVSTAT_ReportingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZvStatistik_Dataset = New PS_TOOL_DX.ZvStatistik_DataSet()
        Me.ZVSTAT_ReportingALL_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLfdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZVSTA_Schema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReportingPeriod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PositionName_MemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colLandkontext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Landcontext_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colLandCode_ALL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandCode_Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubdivisionOfCountryCode_ALL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubdivisionOfCountryName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandCodeT_ALL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandCode_T = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLandCode_T_Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubdivisionOfCountryCodeT_ALL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubdivisionOfCountryCode_T = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubdivisionOfCountryName_T = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPayCardSystem_ALL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPayCardSystem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPayCardSystem_Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnzahl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AnzahlWert_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colWert = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSumPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumPosition_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colPositionSQLcommand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPositionInfo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PopupContainerEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.popupContainerControl = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BbiSqlReload = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddNewZvReport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiSave = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiPrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.MeldeschemasReportingPeriod_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.ZvReportings_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZVSTA_ProcessingMenu_BarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.ZVSTA_Execute_ALL_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_Execute_Commands_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_FirstDataCards_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_FraudelentPayments_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_FraudelentCards_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_Sums_Calculate_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_Finalize_Commands_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_Validate_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.ZVSTA_XML_Create_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameterCurrentPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameterNextPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoNextPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BbiChangeSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportStatus_BarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.ZVSTA_XML_Fehlanzeige_Create_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDeleteCurrentZVSTA_Form = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemFontEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemFontEdit()
        Me.RepositoryItemRichEditFontSizeEdit1 = New DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit()
        Me.DisplayForReviewModeComboBox1 = New DevExpress.XtraRichEdit.UI.DisplayForReviewModeComboBox()
        Me.RepositoryItemBorderLineStyle1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle()
        Me.RepositoryItemBorderLineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight()
        Me.RepositoryItemFloatingObjectOutlineWeight1 = New DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight()
        Me.ChangeParameterPosition_SpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RichTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit()
        Me.MemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LandCode_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.LandCode2021_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.PayCardSystem_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ZVSTA_LoadingPanel_LayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SqlParameterGridviewPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.TableAdapterManager = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager()
        Me.ZVSTAT_ReportingTableAdapter = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.ZVSTAT_ReportingTableAdapter()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Anzahl_SpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Wert_SpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_ReportingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_ReportingALL_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PositionName_MemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Landcontext_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl.SuspendLayout()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvReportings_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisplayForReviewModeComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChangeParameterPosition_SpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RichTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandCode_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTA_LoadingPanel_LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colSubdivisionOfCountryCode
        '
        Me.colSubdivisionOfCountryCode.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryCode.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryCode.FieldName = "SubdivisionOfCountryCode"
        Me.colSubdivisionOfCountryCode.Name = "colSubdivisionOfCountryCode"
        Me.colSubdivisionOfCountryCode.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryCode.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemTextEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'colLastAction
        '
        Me.colLastAction.AppearanceCell.Options.UseTextOptions = True
        Me.colLastAction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastAction.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colLastAction.FieldName = "LastAction"
        Me.colLastAction.Name = "colLastAction"
        Me.colLastAction.OptionsColumn.AllowEdit = False
        Me.colLastAction.OptionsColumn.ReadOnly = True
        Me.colLastAction.OptionsEditForm.StartNewRow = True
        Me.colLastAction.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colAnzahl_Value
        '
        Me.colAnzahl_Value.Caption = "Anzahl (Value)"
        Me.colAnzahl_Value.ColumnEdit = Me.Anzahl_SpinEdit
        Me.colAnzahl_Value.FieldName = "Anzahl_Value"
        Me.colAnzahl_Value.Name = "colAnzahl_Value"
        Me.colAnzahl_Value.Visible = True
        Me.colAnzahl_Value.VisibleIndex = 10
        Me.colAnzahl_Value.Width = 152
        '
        'Anzahl_SpinEdit
        '
        Me.Anzahl_SpinEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Anzahl_SpinEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Anzahl_SpinEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Anzahl_SpinEdit.AppearanceFocused.Options.UseBackColor = True
        Me.Anzahl_SpinEdit.AppearanceFocused.Options.UseForeColor = True
        Me.Anzahl_SpinEdit.AutoHeight = False
        Me.Anzahl_SpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Anzahl_SpinEdit.DisplayFormat.FormatString = "n0"
        Me.Anzahl_SpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Anzahl_SpinEdit.EditFormat.FormatString = "n0"
        Me.Anzahl_SpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Anzahl_SpinEdit.Mask.EditMask = "n0"
        Me.Anzahl_SpinEdit.Name = "Anzahl_SpinEdit"
        '
        'colWert_Value
        '
        Me.colWert_Value.Caption = "Wert (Value)"
        Me.colWert_Value.ColumnEdit = Me.Wert_SpinEdit
        Me.colWert_Value.DisplayFormat.FormatString = "n2"
        Me.colWert_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colWert_Value.FieldName = "Wert_Value"
        Me.colWert_Value.Name = "colWert_Value"
        Me.colWert_Value.Visible = True
        Me.colWert_Value.VisibleIndex = 11
        Me.colWert_Value.Width = 144
        '
        'Wert_SpinEdit
        '
        Me.Wert_SpinEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Wert_SpinEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Wert_SpinEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Wert_SpinEdit.AppearanceFocused.Options.UseBackColor = True
        Me.Wert_SpinEdit.AppearanceFocused.Options.UseForeColor = True
        Me.Wert_SpinEdit.AutoHeight = False
        Me.Wert_SpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Wert_SpinEdit.DisplayFormat.FormatString = "n2"
        Me.Wert_SpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Wert_SpinEdit.EditFormat.FormatString = "n2"
        Me.Wert_SpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Wert_SpinEdit.Mask.EditMask = "n2"
        Me.Wert_SpinEdit.Name = "Wert_SpinEdit"
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AutoHeight = False
        Me.RepositoryItemMemoExEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit3.Name = "RepositoryItemMemoExEdit3"
        Me.RepositoryItemMemoExEdit3.PopupFormSize = New System.Drawing.Size(514, 260)
        Me.RepositoryItemMemoExEdit3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.ZVSTAT_ReportingBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.ImageIndex = 4
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(24, 110)
        Me.GridControl3.MainView = Me.ZVSTAT_ReportingALL_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3, Me.RepositoryItemSpinEdit1, Me.Landcontext_ImageComboBox, Me.RepositoryItemDateEdit1, Me.PopupContainerEdit2, Me.RichTextEdit2, Me.MemoEdit1, Me.LandCode_ImageComboBox, Me.AnzahlWert_RepositoryItemImageComboBox, Me.LandCode2021_ImageComboBox, Me.PayCardSystem_ImageComboBox, Me.PositionName_MemoEdit, Me.Anzahl_SpinEdit, Me.Wert_SpinEdit, Me.SumPosition_ImageComboBox})
        Me.GridControl3.Size = New System.Drawing.Size(1347, 355)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ZVSTAT_ReportingALL_Gridview})
        '
        'ZVSTAT_ReportingBindingSource
        '
        Me.ZVSTAT_ReportingBindingSource.DataMember = "ZVSTAT_Reporting"
        Me.ZVSTAT_ReportingBindingSource.DataSource = Me.ZvStatistik_Dataset
        '
        'ZvStatistik_Dataset
        '
        Me.ZvStatistik_Dataset.DataSetName = "ZvStatistik_Dataset"
        Me.ZvStatistik_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZVSTAT_ReportingALL_Gridview
        '
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.GroupButton.ForeColor = System.Drawing.Color.Navy
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.GroupButton.Options.UseForeColor = True
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.ZVSTAT_ReportingALL_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.ZVSTAT_ReportingALL_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colLfdNr, Me.colZVSTA_Schema, Me.colReportingPeriod, Me.colFormNr, Me.colFormName, Me.colPositionNr, Me.colPositionName, Me.colLandkontext, Me.colLandCode_ALL, Me.colLandCode, Me.colLandCode_Description, Me.colSubdivisionOfCountryCode_ALL, Me.colSubdivisionOfCountryCode, Me.colSubdivisionOfCountryName, Me.colLandCodeT_ALL, Me.colLandCode_T, Me.colLandCode_T_Description, Me.colSubdivisionOfCountryCodeT_ALL, Me.colSubdivisionOfCountryCode_T, Me.colSubdivisionOfCountryName_T, Me.colPayCardSystem_ALL, Me.colPayCardSystem, Me.colPayCardSystem_Description, Me.colAnzahl, Me.colWert, Me.colSumPosition, Me.colAnzahl_Value, Me.colWert_Value, Me.colPositionSQLcommand, Me.colPositionInfo, Me.colLastAction, Me.colLastUpdateUser, Me.colLastUpdateDate, Me.colReportStatus})
        Me.ZVSTAT_ReportingALL_Gridview.DetailHeight = 303
        Me.ZVSTAT_ReportingALL_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.colSubdivisionOfCountryCode
        GridFormatRule1.ColumnApplyTo = Me.colSubdivisionOfCountryCode
        GridFormatRule1.Name = "FormatSubdivisionCountries"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue1.Expression = "[SubdivisionOfCountryCode] <> null"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.colLastAction
        GridFormatRule2.ColumnApplyTo = Me.colLastAction
        GridFormatRule2.Name = "FormatModification"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "Modification"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.Column = Me.colAnzahl_Value
        GridFormatRule3.ColumnApplyTo = Me.colAnzahl_Value
        GridFormatRule3.Name = "FormatAnzahlValue"
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue3.Value1 = 0R
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.Column = Me.colWert_Value
        GridFormatRule4.ColumnApplyTo = Me.colWert_Value
        GridFormatRule4.Name = "FormatWertValue"
        FormatConditionRuleValue4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue4.Appearance.Options.UseFont = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue4.Value1 = 0R
        GridFormatRule4.Rule = FormatConditionRuleValue4
        Me.ZVSTAT_ReportingALL_Gridview.FormatRules.Add(GridFormatRule1)
        Me.ZVSTAT_ReportingALL_Gridview.FormatRules.Add(GridFormatRule2)
        Me.ZVSTAT_ReportingALL_Gridview.FormatRules.Add(GridFormatRule3)
        Me.ZVSTAT_ReportingALL_Gridview.FormatRules.Add(GridFormatRule4)
        Me.ZVSTAT_ReportingALL_Gridview.GridControl = Me.GridControl3
        Me.ZVSTAT_ReportingALL_Gridview.GroupCount = 1
        Me.ZVSTAT_ReportingALL_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "FormName", Nothing, "")})
        Me.ZVSTAT_ReportingALL_Gridview.Name = "ZVSTAT_ReportingALL_Gridview"
        Me.ZVSTAT_ReportingALL_Gridview.NewItemRowText = "Add new ZV Statistik Parameter"
        Me.ZVSTAT_ReportingALL_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.ZVSTAT_ReportingALL_Gridview.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsDetail.AllowExpandEmptyDetails = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsDetail.AutoZoomDetail = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFind.AlwaysVisible = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsFind.SearchInPreview = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsNavigation.AutoFocusNewRow = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsSelection.MultiSelect = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.AutoCalcPreviewLineCount = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ColumnAutoWidth = False
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.RowAutoHeight = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowChildrenInGroupPanel = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowFooter = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowGroupedColumns = True
        Me.ZVSTAT_ReportingALL_Gridview.OptionsView.ShowGroupPanel = False
        Me.ZVSTAT_ReportingALL_Gridview.PreviewFieldName = "PositionSQLcommand"
        Me.ZVSTAT_ReportingALL_Gridview.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridMergedColumnSortInfo(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFormNr, Me.colFormName, Me.colZVSTA_Schema}, New DevExpress.Data.ColumnSortOrder() {DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Data.ColumnSortOrder.Ascending})})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        Me.colID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colLfdNr
        '
        Me.colLfdNr.FieldName = "LfdNr"
        Me.colLfdNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLfdNr.Name = "colLfdNr"
        Me.colLfdNr.OptionsColumn.AllowEdit = False
        Me.colLfdNr.OptionsColumn.ReadOnly = True
        Me.colLfdNr.Visible = True
        Me.colLfdNr.VisibleIndex = 0
        '
        'colZVSTA_Schema
        '
        Me.colZVSTA_Schema.Caption = "ZVSTA Schema"
        Me.colZVSTA_Schema.FieldName = "ZVSTA_Schema"
        Me.colZVSTA_Schema.Name = "colZVSTA_Schema"
        Me.colZVSTA_Schema.OptionsColumn.AllowEdit = False
        Me.colZVSTA_Schema.OptionsColumn.ReadOnly = True
        Me.colZVSTA_Schema.OptionsEditForm.StartNewRow = True
        Me.colZVSTA_Schema.Width = 130
        '
        'colReportingPeriod
        '
        Me.colReportingPeriod.FieldName = "ReportingPeriod"
        Me.colReportingPeriod.Name = "colReportingPeriod"
        Me.colReportingPeriod.OptionsColumn.AllowEdit = False
        Me.colReportingPeriod.OptionsColumn.ReadOnly = True
        Me.colReportingPeriod.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colFormNr
        '
        Me.colFormNr.FieldName = "FormNr"
        Me.colFormNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colFormNr.Name = "colFormNr"
        Me.colFormNr.OptionsColumn.AllowEdit = False
        Me.colFormNr.OptionsColumn.ReadOnly = True
        Me.colFormNr.OptionsEditForm.ColumnSpan = 2
        Me.colFormNr.OptionsEditForm.UseEditorColRowSpan = False
        Me.colFormNr.Visible = True
        Me.colFormNr.VisibleIndex = 1
        '
        'colFormName
        '
        Me.colFormName.FieldName = "FormName"
        Me.colFormName.Name = "colFormName"
        Me.colFormName.OptionsColumn.AllowEdit = False
        Me.colFormName.OptionsColumn.ReadOnly = True
        Me.colFormName.OptionsEditForm.ColumnSpan = 3
        Me.colFormName.OptionsEditForm.StartNewRow = True
        Me.colFormName.OptionsEditForm.UseEditorColRowSpan = False
        '
        'colPositionNr
        '
        Me.colPositionNr.FieldName = "PositionNr"
        Me.colPositionNr.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colPositionNr.Name = "colPositionNr"
        Me.colPositionNr.OptionsColumn.AllowEdit = False
        Me.colPositionNr.OptionsColumn.ReadOnly = True
        Me.colPositionNr.OptionsEditForm.ColumnSpan = 2
        Me.colPositionNr.OptionsEditForm.StartNewRow = True
        Me.colPositionNr.OptionsEditForm.UseEditorColRowSpan = False
        Me.colPositionNr.Visible = True
        Me.colPositionNr.VisibleIndex = 2
        Me.colPositionNr.Width = 102
        '
        'colPositionName
        '
        Me.colPositionName.AppearanceCell.Options.UseTextOptions = True
        Me.colPositionName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colPositionName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colPositionName.ColumnEdit = Me.PositionName_MemoEdit
        Me.colPositionName.FieldName = "PositionName"
        Me.colPositionName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colPositionName.Name = "colPositionName"
        Me.colPositionName.OptionsColumn.AllowEdit = False
        Me.colPositionName.OptionsColumn.ReadOnly = True
        Me.colPositionName.OptionsEditForm.ColumnSpan = 3
        Me.colPositionName.OptionsEditForm.RowSpan = 3
        Me.colPositionName.OptionsEditForm.StartNewRow = True
        Me.colPositionName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colPositionName.Visible = True
        Me.colPositionName.VisibleIndex = 3
        Me.colPositionName.Width = 293
        '
        'PositionName_MemoEdit
        '
        Me.PositionName_MemoEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.PositionName_MemoEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.PositionName_MemoEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.PositionName_MemoEdit.AppearanceFocused.Options.UseBackColor = True
        Me.PositionName_MemoEdit.AppearanceFocused.Options.UseForeColor = True
        Me.PositionName_MemoEdit.Name = "PositionName_MemoEdit"
        '
        'colLandkontext
        '
        Me.colLandkontext.ColumnEdit = Me.Landcontext_ImageComboBox
        Me.colLandkontext.FieldName = "Landkontext"
        Me.colLandkontext.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLandkontext.Name = "colLandkontext"
        Me.colLandkontext.OptionsColumn.AllowEdit = False
        Me.colLandkontext.OptionsColumn.ReadOnly = True
        Me.colLandkontext.OptionsEditForm.StartNewRow = True
        Me.colLandkontext.Visible = True
        Me.colLandkontext.VisibleIndex = 4
        Me.colLandkontext.Width = 98
        '
        'Landcontext_ImageComboBox
        '
        Me.Landcontext_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Landcontext_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Landcontext_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Landcontext_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.Landcontext_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.Landcontext_ImageComboBox.AutoHeight = False
        Me.Landcontext_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Landcontext_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Not relevant", "N", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("TO - NACH", "TO", 0), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FROM - VON", "FROM", 1)})
        Me.Landcontext_ImageComboBox.Name = "Landcontext_ImageComboBox"
        Me.Landcontext_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "pagenext_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "pageprev_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "Germany.png")
        Me.ImageCollection1.Images.SetKeyName(3, "bolocalization_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(4, "EU Icon.jpg")
        Me.ImageCollection1.Images.SetKeyName(5, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(6, "summary_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(7, "country_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(8, "apply_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(9, "delete_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(10, "EWG.jpg")
        Me.ImageCollection1.Images.SetKeyName(11, "COUNTRIES.jpg")
        Me.ImageCollection1.Images.SetKeyName(12, "formatnumbercurrency_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(13, "currency_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(14, "credit-card.png")
        Me.ImageCollection1.Images.SetKeyName(15, "boorderitem_16x16.png")
        '
        'colLandCode_ALL
        '
        Me.colLandCode_ALL.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode_ALL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colLandCode_ALL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCode_ALL.Caption = "Land Code"
        Me.colLandCode_ALL.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCode_ALL.FieldName = "colLandCode_ALL"
        Me.colLandCode_ALL.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colLandCode_ALL.Name = "colLandCode_ALL"
        Me.colLandCode_ALL.OptionsColumn.AllowEdit = False
        Me.colLandCode_ALL.OptionsColumn.ReadOnly = True
        Me.colLandCode_ALL.OptionsEditForm.StartNewRow = True
        Me.colLandCode_ALL.UnboundExpression = "[LandCode] + ' - ' + [LandCode_Description]"
        Me.colLandCode_ALL.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colLandCode_ALL.Visible = True
        Me.colLandCode_ALL.VisibleIndex = 5
        Me.colLandCode_ALL.Width = 133
        '
        'colLandCode
        '
        Me.colLandCode.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCode.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCode.FieldName = "LandCode"
        Me.colLandCode.Name = "colLandCode"
        Me.colLandCode.OptionsColumn.AllowEdit = False
        Me.colLandCode.OptionsColumn.ReadOnly = True
        '
        'colLandCode_Description
        '
        Me.colLandCode_Description.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode_Description.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCode_Description.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCode_Description.FieldName = "LandCode_Description"
        Me.colLandCode_Description.Name = "colLandCode_Description"
        Me.colLandCode_Description.OptionsColumn.AllowEdit = False
        Me.colLandCode_Description.OptionsColumn.ReadOnly = True
        '
        'colSubdivisionOfCountryCode_ALL
        '
        Me.colSubdivisionOfCountryCode_ALL.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryCode_ALL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colSubdivisionOfCountryCode_ALL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryCode_ALL.Caption = "Subdivision of Country"
        Me.colSubdivisionOfCountryCode_ALL.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryCode_ALL.FieldName = "colSubdivisionOfCountryCode_ALL"
        Me.colSubdivisionOfCountryCode_ALL.Name = "colSubdivisionOfCountryCode_ALL"
        Me.colSubdivisionOfCountryCode_ALL.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryCode_ALL.OptionsColumn.ReadOnly = True
        Me.colSubdivisionOfCountryCode_ALL.UnboundExpression = "Iif([SubdivisionOfCountryCode] = null, null, [SubdivisionOfCountryCode] + ' - ' +" &
    " [SubdivisionOfCountryName])"
        Me.colSubdivisionOfCountryCode_ALL.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colSubdivisionOfCountryCode_ALL.Visible = True
        Me.colSubdivisionOfCountryCode_ALL.VisibleIndex = 6
        Me.colSubdivisionOfCountryCode_ALL.Width = 114
        '
        'colSubdivisionOfCountryName
        '
        Me.colSubdivisionOfCountryName.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryName.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryName.FieldName = "SubdivisionOfCountryName"
        Me.colSubdivisionOfCountryName.Name = "colSubdivisionOfCountryName"
        Me.colSubdivisionOfCountryName.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryName.OptionsColumn.ReadOnly = True
        '
        'colLandCodeT_ALL
        '
        Me.colLandCodeT_ALL.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCodeT_ALL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colLandCodeT_ALL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCodeT_ALL.Caption = "Land Code (T)"
        Me.colLandCodeT_ALL.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCodeT_ALL.FieldName = "colLandCodeT_ALL"
        Me.colLandCodeT_ALL.Name = "colLandCodeT_ALL"
        Me.colLandCodeT_ALL.OptionsColumn.AllowEdit = False
        Me.colLandCodeT_ALL.OptionsColumn.ReadOnly = True
        Me.colLandCodeT_ALL.OptionsEditForm.StartNewRow = True
        Me.colLandCodeT_ALL.UnboundExpression = "Iif([LandCode_T] = null, null, [LandCode_T] + ' - ' + [LandCode_T_Description])"
        Me.colLandCodeT_ALL.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colLandCodeT_ALL.Visible = True
        Me.colLandCodeT_ALL.VisibleIndex = 7
        '
        'colLandCode_T
        '
        Me.colLandCode_T.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode_T.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCode_T.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCode_T.FieldName = "LandCode_T"
        Me.colLandCode_T.Name = "colLandCode_T"
        Me.colLandCode_T.OptionsColumn.AllowEdit = False
        Me.colLandCode_T.OptionsColumn.ReadOnly = True
        '
        'colLandCode_T_Description
        '
        Me.colLandCode_T_Description.AppearanceCell.Options.UseTextOptions = True
        Me.colLandCode_T_Description.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colLandCode_T_Description.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colLandCode_T_Description.FieldName = "LandCode_T_Description"
        Me.colLandCode_T_Description.Name = "colLandCode_T_Description"
        Me.colLandCode_T_Description.OptionsColumn.AllowEdit = False
        Me.colLandCode_T_Description.OptionsColumn.ReadOnly = True
        '
        'colSubdivisionOfCountryCodeT_ALL
        '
        Me.colSubdivisionOfCountryCodeT_ALL.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryCodeT_ALL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colSubdivisionOfCountryCodeT_ALL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryCodeT_ALL.Caption = "Subdivision of Country (T)"
        Me.colSubdivisionOfCountryCodeT_ALL.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryCodeT_ALL.FieldName = "colSubdivisionOfCountryCodeT_ALL"
        Me.colSubdivisionOfCountryCodeT_ALL.Name = "colSubdivisionOfCountryCodeT_ALL"
        Me.colSubdivisionOfCountryCodeT_ALL.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryCodeT_ALL.OptionsColumn.ReadOnly = True
        Me.colSubdivisionOfCountryCodeT_ALL.UnboundExpression = "Iif([SubdivisionOfCountryCode_T] = null, null, [SubdivisionOfCountryCode_T] + ' -" &
    " ' + [SubdivisionOfCountryName_T])"
        Me.colSubdivisionOfCountryCodeT_ALL.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colSubdivisionOfCountryCodeT_ALL.Visible = True
        Me.colSubdivisionOfCountryCodeT_ALL.VisibleIndex = 8
        '
        'colSubdivisionOfCountryCode_T
        '
        Me.colSubdivisionOfCountryCode_T.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryCode_T.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryCode_T.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryCode_T.FieldName = "SubdivisionOfCountryCode_T"
        Me.colSubdivisionOfCountryCode_T.Name = "colSubdivisionOfCountryCode_T"
        Me.colSubdivisionOfCountryCode_T.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryCode_T.OptionsColumn.ReadOnly = True
        '
        'colSubdivisionOfCountryName_T
        '
        Me.colSubdivisionOfCountryName_T.AppearanceCell.Options.UseTextOptions = True
        Me.colSubdivisionOfCountryName_T.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colSubdivisionOfCountryName_T.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colSubdivisionOfCountryName_T.FieldName = "SubdivisionOfCountryName_T"
        Me.colSubdivisionOfCountryName_T.Name = "colSubdivisionOfCountryName_T"
        Me.colSubdivisionOfCountryName_T.OptionsColumn.AllowEdit = False
        Me.colSubdivisionOfCountryName_T.OptionsColumn.ReadOnly = True
        '
        'colPayCardSystem_ALL
        '
        Me.colPayCardSystem_ALL.AppearanceCell.Options.UseTextOptions = True
        Me.colPayCardSystem_ALL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colPayCardSystem_ALL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colPayCardSystem_ALL.Caption = "Payment - Card System"
        Me.colPayCardSystem_ALL.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colPayCardSystem_ALL.FieldName = "colPayCardSystem_ALL"
        Me.colPayCardSystem_ALL.Name = "colPayCardSystem_ALL"
        Me.colPayCardSystem_ALL.OptionsColumn.AllowEdit = False
        Me.colPayCardSystem_ALL.OptionsColumn.ReadOnly = True
        Me.colPayCardSystem_ALL.OptionsEditForm.ColumnSpan = 2
        Me.colPayCardSystem_ALL.OptionsEditForm.UseEditorColRowSpan = False
        Me.colPayCardSystem_ALL.UnboundExpression = "Iif([PayCardSystem] = 'N', 'NOT RELEVANT', [PayCardSystem] + ' - ' + [PayCardSyst" &
    "em_Description])"
        Me.colPayCardSystem_ALL.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.colPayCardSystem_ALL.Visible = True
        Me.colPayCardSystem_ALL.VisibleIndex = 9
        Me.colPayCardSystem_ALL.Width = 123
        '
        'colPayCardSystem
        '
        Me.colPayCardSystem.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colPayCardSystem.FieldName = "PayCardSystem"
        Me.colPayCardSystem.Name = "colPayCardSystem"
        Me.colPayCardSystem.OptionsColumn.AllowEdit = False
        Me.colPayCardSystem.OptionsColumn.ReadOnly = True
        '
        'colPayCardSystem_Description
        '
        Me.colPayCardSystem_Description.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colPayCardSystem_Description.FieldName = "PayCardSystem_Description"
        Me.colPayCardSystem_Description.Name = "colPayCardSystem_Description"
        Me.colPayCardSystem_Description.OptionsColumn.AllowEdit = False
        Me.colPayCardSystem_Description.OptionsColumn.ReadOnly = True
        '
        'colAnzahl
        '
        Me.colAnzahl.Caption = "Anzahl erforderlich"
        Me.colAnzahl.ColumnEdit = Me.AnzahlWert_RepositoryItemImageComboBox
        Me.colAnzahl.FieldName = "Anzahl"
        Me.colAnzahl.Name = "colAnzahl"
        Me.colAnzahl.OptionsColumn.AllowEdit = False
        Me.colAnzahl.OptionsColumn.ReadOnly = True
        Me.colAnzahl.OptionsEditForm.StartNewRow = True
        Me.colAnzahl.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.colAnzahl.Width = 91
        '
        'AnzahlWert_RepositoryItemImageComboBox
        '
        Me.AnzahlWert_RepositoryItemImageComboBox.AutoHeight = False
        Me.AnzahlWert_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Name = "AnzahlWert_RepositoryItemImageComboBox"
        Me.AnzahlWert_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colWert
        '
        Me.colWert.Caption = "Wert erforderlich"
        Me.colWert.ColumnEdit = Me.AnzahlWert_RepositoryItemImageComboBox
        Me.colWert.FieldName = "Wert"
        Me.colWert.Name = "colWert"
        Me.colWert.OptionsColumn.AllowEdit = False
        Me.colWert.OptionsColumn.ReadOnly = True
        Me.colWert.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.colWert.Width = 89
        '
        'colSumPosition
        '
        Me.colSumPosition.ColumnEdit = Me.SumPosition_ImageComboBox
        Me.colSumPosition.FieldName = "SumPosition"
        Me.colSumPosition.Name = "colSumPosition"
        Me.colSumPosition.OptionsColumn.AllowEdit = False
        Me.colSumPosition.OptionsColumn.ReadOnly = True
        Me.colSumPosition.Visible = True
        Me.colSumPosition.VisibleIndex = 12
        Me.colSumPosition.Width = 193
        '
        'SumPosition_ImageComboBox
        '
        Me.SumPosition_ImageComboBox.AutoHeight = False
        Me.SumPosition_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SumPosition_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FIRST SUM", "1", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - INTERMEDIARY SUM", "2", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FINAL SUM", "3", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.SumPosition_ImageComboBox.Name = "SumPosition_ImageComboBox"
        Me.SumPosition_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colPositionSQLcommand
        '
        Me.colPositionSQLcommand.Caption = "SQL Command for Position"
        Me.colPositionSQLcommand.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colPositionSQLcommand.FieldName = "PositionSQLcommand"
        Me.colPositionSQLcommand.Name = "colPositionSQLcommand"
        Me.colPositionSQLcommand.OptionsEditForm.StartNewRow = True
        Me.colPositionSQLcommand.Visible = True
        Me.colPositionSQLcommand.VisibleIndex = 13
        '
        'colPositionInfo
        '
        Me.colPositionInfo.AppearanceHeader.Options.UseTextOptions = True
        Me.colPositionInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPositionInfo.Caption = "Position Info"
        Me.colPositionInfo.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colPositionInfo.FieldName = "PositionInfo"
        Me.colPositionInfo.Name = "colPositionInfo"
        Me.colPositionInfo.OptionsColumn.ReadOnly = True
        Me.colPositionInfo.Visible = True
        Me.colPositionInfo.VisibleIndex = 14
        '
        'colLastUpdateUser
        '
        Me.colLastUpdateUser.AppearanceCell.Options.UseTextOptions = True
        Me.colLastUpdateUser.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colLastUpdateUser.FieldName = "LastUpdateUser"
        Me.colLastUpdateUser.Name = "colLastUpdateUser"
        Me.colLastUpdateUser.OptionsColumn.AllowEdit = False
        Me.colLastUpdateUser.OptionsColumn.ReadOnly = True
        Me.colLastUpdateUser.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colLastUpdateDate
        '
        Me.colLastUpdateDate.AppearanceCell.Options.UseTextOptions = True
        Me.colLastUpdateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colLastUpdateDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colLastUpdateDate.DisplayFormat.FormatString = "d"
        Me.colLastUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colLastUpdateDate.FieldName = "LastUpdateDate"
        Me.colLastUpdateDate.Name = "colLastUpdateDate"
        Me.colLastUpdateDate.OptionsColumn.AllowEdit = False
        Me.colLastUpdateDate.OptionsColumn.ReadOnly = True
        Me.colLastUpdateDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colReportStatus
        '
        Me.colReportStatus.FieldName = "ReportStatus"
        Me.colReportStatus.Name = "colReportStatus"
        Me.colReportStatus.OptionsColumn.ReadOnly = True
        Me.colReportStatus.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Mask.BeepOnError = True
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "[1-9]{1,1}[0-9]{0,50}"
        Me.RepositoryItemSpinEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'PopupContainerEdit2
        '
        Me.PopupContainerEdit2.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupContainerEdit2.Appearance.Options.UseFont = True
        Me.PopupContainerEdit2.AutoHeight = False
        Me.PopupContainerEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit2.Name = "PopupContainerEdit2"
        Me.PopupContainerEdit2.PopupControl = Me.popupContainerControl
        '
        'popupContainerControl
        '
        Me.popupContainerControl.Controls.Add(Me.RichEditControl1)
        Me.popupContainerControl.Location = New System.Drawing.Point(1034, 40)
        Me.popupContainerControl.Name = "popupContainerControl"
        Me.popupContainerControl.Size = New System.Drawing.Size(162, 38)
        Me.popupContainerControl.TabIndex = 10
        '
        'RichEditControl1
        '
        Me.RichEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.RichEditControl1.Appearance.Text.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichEditControl1.Appearance.Text.Options.UseFont = True
        Me.RichEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
        Me.RichEditControl1.Location = New System.Drawing.Point(0, 0)
        Me.RichEditControl1.MenuManager = Me.RibbonControl
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.ReadOnly = True
        Me.RichEditControl1.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl1.TabIndex = 2
        '
        'RibbonControl
        '
        Me.RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.BbiSqlReload, Me.BbiAddNewZvReport, Me.BbiSave, Me.BbiDelete, Me.BbiPrintExport, Me.BbiClose, Me.BbiDuplicateSQLParameter, Me.BbiAddSQLtoPosition, Me.MeldeschemasReportingPeriod_BarEditItem, Me.ZVSTA_ProcessingMenu_BarSubItem, Me.BbiDuplicateSQLParameterCurrentPosition, Me.BbiDuplicateSQLParameterNextPosition, Me.BbiAddSQLtoNextPosition, Me.BarSubItem1, Me.ZVSTA_Execute_Commands_btn, Me.ZVSTA_Finalize_Commands_btn, Me.ZVSTA_Execute_ALL_btn, Me.ZVSTA_XML_Create_btn, Me.BbiChangeSQLtoPosition, Me.ReportStatus_BarStaticItem, Me.ZVSTA_Validate_btn, Me.ZVSTA_XML_Fehlanzeige_Create_btn, Me.ZVSTA_FirstDataCards_btn, Me.ZVSTA_FraudelentPayments_btn, Me.ZVSTA_FraudelentCards_btn, Me.ZVSTA_Sums_Calculate_btn, Me.BbiDeleteCurrentZVSTA_Form})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 300
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageHeaderItemLinks.Add(Me.ReportStatus_BarStaticItem)
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1, Me.Meldeschemas_RepositoryItemSearchLookUpEdit, Me.RepositoryItemFontEdit1, Me.RepositoryItemRichEditFontSizeEdit1, Me.DisplayForReviewModeComboBox1, Me.RepositoryItemBorderLineStyle1, Me.RepositoryItemBorderLineWeight1, Me.RepositoryItemFloatingObjectOutlineWeight1, Me.ChangeParameterPosition_SpinEdit})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowSearchItem = True
        Me.RibbonControl.Size = New System.Drawing.Size(1395, 94)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BbiSqlReload
        '
        Me.BbiSqlReload.Caption = "Reload"
        Me.BbiSqlReload.Id = 1
        Me.BbiSqlReload.ImageOptions.SvgImage = CType(resources.GetObject("BbiSqlReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiSqlReload.Name = "BbiSqlReload"
        '
        'BbiAddNewZvReport
        '
        Me.BbiAddNewZvReport.Caption = "Add new ZV Statistik Report"
        Me.BbiAddNewZvReport.Id = 2
        Me.BbiAddNewZvReport.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddNewZvReport.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddNewZvReport.Name = "BbiAddNewZvReport"
        '
        'BbiSave
        '
        Me.BbiSave.Caption = "Save"
        Me.BbiSave.Id = 3
        Me.BbiSave.ImageOptions.ImageUri.Uri = "Save"
        Me.BbiSave.Name = "BbiSave"
        '
        'BbiDelete
        '
        Me.BbiDelete.Caption = "Delete current ZV Statistik Report"
        Me.BbiDelete.Id = 4
        Me.BbiDelete.ImageOptions.ImageUri.Uri = "Cancel"
        Me.BbiDelete.ImageOptions.SvgImage = CType(resources.GetObject("BbiDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiDelete.Name = "BbiDelete"
        '
        'BbiPrintExport
        '
        Me.BbiPrintExport.Caption = "Print preview"
        Me.BbiPrintExport.Id = 5
        Me.BbiPrintExport.ImageOptions.ImageUri.Uri = "Preview"
        Me.BbiPrintExport.Name = "BbiPrintExport"
        '
        'BbiClose
        '
        Me.BbiClose.Caption = "Close"
        Me.BbiClose.Id = 1
        Me.BbiClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BbiClose.Name = "BbiClose"
        '
        'BbiDuplicateSQLParameter
        '
        Me.BbiDuplicateSQLParameter.Caption = "Duplicate ZV Statistic Parameter (New Row)"
        Me.BbiDuplicateSQLParameter.Id = 2
        Me.BbiDuplicateSQLParameter.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameter.Name = "BbiDuplicateSQLParameter"
        '
        'BbiAddSQLtoPosition
        '
        Me.BbiAddSQLtoPosition.Caption = "Add new ZV Statistic Parameter to current Position"
        Me.BbiAddSQLtoPosition.Id = 3
        Me.BbiAddSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddSQLtoPosition.Name = "BbiAddSQLtoPosition"
        '
        'MeldeschemasReportingPeriod_BarEditItem
        '
        Me.MeldeschemasReportingPeriod_BarEditItem.Caption = "Meldeschema - Reporting Period"
        Me.MeldeschemasReportingPeriod_BarEditItem.Edit = Me.Meldeschemas_RepositoryItemSearchLookUpEdit
        Me.MeldeschemasReportingPeriod_BarEditItem.EditWidth = 270
        Me.MeldeschemasReportingPeriod_BarEditItem.Id = 4
        Me.MeldeschemasReportingPeriod_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeldeschemasReportingPeriod_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.MeldeschemasReportingPeriod_BarEditItem.Name = "MeldeschemasReportingPeriod_BarEditItem"
        '
        'Meldeschemas_RepositoryItemSearchLookUpEdit
        '
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Appearance.Options.UseTextOptions = True
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.AutoHeight = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Name = "Meldeschemas_RepositoryItemSearchLookUpEdit"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.NullText = ""
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.PopupFormSize = New System.Drawing.Size(300, 300)
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.PopupView = Me.ZvReportings_GridView
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ShowClearButton = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        '
        'ZvReportings_GridView
        '
        Me.ZvReportings_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.ZvReportings_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ZvReportings_GridView.Name = "ZvReportings_GridView"
        Me.ZvReportings_GridView.OptionsBehavior.Editable = False
        Me.ZvReportings_GridView.OptionsBehavior.ReadOnly = True
        Me.ZvReportings_GridView.OptionsFind.AlwaysVisible = True
        Me.ZvReportings_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ZvReportings_GridView.OptionsView.ColumnAutoWidth = False
        Me.ZvReportings_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZvReportings_GridView.OptionsView.ShowAutoFilterRow = True
        Me.ZvReportings_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ZvReportings_GridView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ZV_MELDUNG"
        Me.GridColumn1.FieldName = "ZV_MELDUNG"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Meldeschema - Reporting Period"
        Me.GridColumn2.FieldName = "ZV_SCHEMA_PERIOD"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 232
        '
        'ZVSTA_ProcessingMenu_BarSubItem
        '
        Me.ZVSTA_ProcessingMenu_BarSubItem.Caption = "ZV Statistik Processing"
        Me.ZVSTA_ProcessingMenu_BarSubItem.Id = 281
        Me.ZVSTA_ProcessingMenu_BarSubItem.ImageOptions.Image = CType(resources.GetObject("ZVSTA_ProcessingMenu_BarSubItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_ProcessingMenu_BarSubItem.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_ProcessingMenu_BarSubItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_ProcessingMenu_BarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_Execute_ALL_btn), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_Execute_Commands_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_FirstDataCards_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_FraudelentPayments_btn), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_FraudelentCards_btn), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_Sums_Calculate_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_Finalize_Commands_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_Validate_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ZVSTA_XML_Create_btn, True)})
        Me.ZVSTA_ProcessingMenu_BarSubItem.Name = "ZVSTA_ProcessingMenu_BarSubItem"
        '
        'ZVSTA_Execute_ALL_btn
        '
        Me.ZVSTA_Execute_ALL_btn.Caption = "Execute all ZVSTA Processings Steps"
        Me.ZVSTA_Execute_ALL_btn.Id = 288
        Me.ZVSTA_Execute_ALL_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_Execute_ALL_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_Execute_ALL_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_Execute_ALL_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_Execute_ALL_btn.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZVSTA_Execute_ALL_btn.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Navy
        Me.ZVSTA_Execute_ALL_btn.ItemAppearance.Normal.Options.UseFont = True
        Me.ZVSTA_Execute_ALL_btn.ItemAppearance.Normal.Options.UseForeColor = True
        Me.ZVSTA_Execute_ALL_btn.Name = "ZVSTA_Execute_ALL_btn"
        '
        'ZVSTA_Execute_Commands_btn
        '
        Me.ZVSTA_Execute_Commands_btn.Caption = "Execute current ZVSTA Report"
        Me.ZVSTA_Execute_Commands_btn.Id = 286
        Me.ZVSTA_Execute_Commands_btn.ImageOptions.SvgImage = CType(resources.GetObject("ZVSTA_Execute_Commands_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.ZVSTA_Execute_Commands_btn.Name = "ZVSTA_Execute_Commands_btn"
        '
        'ZVSTA_FirstDataCards_btn
        '
        Me.ZVSTA_FirstDataCards_btn.Caption = "Add FIRST DATA Cards to ZVSTA Report"
        Me.ZVSTA_FirstDataCards_btn.Id = 295
        Me.ZVSTA_FirstDataCards_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_FirstDataCards_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_FirstDataCards_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_FirstDataCards_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_FirstDataCards_btn.Name = "ZVSTA_FirstDataCards_btn"
        Me.ZVSTA_FirstDataCards_btn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ZVSTA_FraudelentPayments_btn
        '
        Me.ZVSTA_FraudelentPayments_btn.Caption = "Add FRAUDELENT PAYMENT TRANSACTIONS (NO CARDS)"
        Me.ZVSTA_FraudelentPayments_btn.Id = 296
        Me.ZVSTA_FraudelentPayments_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_FraudelentPayments_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_FraudelentPayments_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_FraudelentPayments_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_FraudelentPayments_btn.Name = "ZVSTA_FraudelentPayments_btn"
        '
        'ZVSTA_FraudelentCards_btn
        '
        Me.ZVSTA_FraudelentCards_btn.Caption = "Add FRAUDELENT CARD TRANSACTIONS (ONLY CARDS)"
        Me.ZVSTA_FraudelentCards_btn.Id = 297
        Me.ZVSTA_FraudelentCards_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_FraudelentCards_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_FraudelentCards_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_FraudelentCards_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_FraudelentCards_btn.Name = "ZVSTA_FraudelentCards_btn"
        Me.ZVSTA_FraudelentCards_btn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ZVSTA_Sums_Calculate_btn
        '
        Me.ZVSTA_Sums_Calculate_btn.Caption = "Calculate ZVSTA Sum Positions"
        Me.ZVSTA_Sums_Calculate_btn.Id = 298
        Me.ZVSTA_Sums_Calculate_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_Sums_Calculate_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_Sums_Calculate_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_Sums_Calculate_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_Sums_Calculate_btn.Name = "ZVSTA_Sums_Calculate_btn"
        '
        'ZVSTA_Finalize_Commands_btn
        '
        Me.ZVSTA_Finalize_Commands_btn.Caption = "Finalize current ZVSTA Report"
        Me.ZVSTA_Finalize_Commands_btn.Id = 287
        Me.ZVSTA_Finalize_Commands_btn.ImageOptions.SvgImage = CType(resources.GetObject("ZVSTA_Finalize_Commands_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.ZVSTA_Finalize_Commands_btn.Name = "ZVSTA_Finalize_Commands_btn"
        '
        'ZVSTA_Validate_btn
        '
        Me.ZVSTA_Validate_btn.Caption = "Validate ZVSTA Report"
        Me.ZVSTA_Validate_btn.Id = 293
        Me.ZVSTA_Validate_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_Validate_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_Validate_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_Validate_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_Validate_btn.Name = "ZVSTA_Validate_btn"
        '
        'ZVSTA_XML_Create_btn
        '
        Me.ZVSTA_XML_Create_btn.Caption = "Create ZVSTA XML Reporting File"
        Me.ZVSTA_XML_Create_btn.Id = 289
        Me.ZVSTA_XML_Create_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_XML_Create_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_XML_Create_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_XML_Create_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_XML_Create_btn.Name = "ZVSTA_XML_Create_btn"
        '
        'BbiDuplicateSQLParameterCurrentPosition
        '
        Me.BbiDuplicateSQLParameterCurrentPosition.Caption = "Duplicate ZV Statistic Parameter (Current Position)"
        Me.BbiDuplicateSQLParameterCurrentPosition.Id = 282
        Me.BbiDuplicateSQLParameterCurrentPosition.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameterCurrentPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterCurrentPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameterCurrentPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterCurrentPosition.Name = "BbiDuplicateSQLParameterCurrentPosition"
        '
        'BbiDuplicateSQLParameterNextPosition
        '
        Me.BbiDuplicateSQLParameterNextPosition.Caption = "Duplicate ZV Statistic Parameter (Next Position)"
        Me.BbiDuplicateSQLParameterNextPosition.Id = 283
        Me.BbiDuplicateSQLParameterNextPosition.ImageOptions.Image = CType(resources.GetObject("BbiDuplicateSQLParameterNextPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterNextPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiDuplicateSQLParameterNextPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDuplicateSQLParameterNextPosition.Name = "BbiDuplicateSQLParameterNextPosition"
        '
        'BbiAddSQLtoNextPosition
        '
        Me.BbiAddSQLtoNextPosition.Caption = "Add new ZV Statistic Parameter to next Position"
        Me.BbiAddSQLtoNextPosition.Id = 284
        Me.BbiAddSQLtoNextPosition.ImageOptions.Image = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.Name = "BbiAddSQLtoNextPosition"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Add new ZV Statistic Meldeschema"
        Me.BarSubItem1.Id = 285
        Me.BarSubItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarSubItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BbiChangeSQLtoPosition
        '
        Me.BbiChangeSQLtoPosition.Caption = "Change ZV Parameter Position"
        Me.BbiChangeSQLtoPosition.Id = 291
        Me.BbiChangeSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiChangeSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiChangeSQLtoPosition.Name = "BbiChangeSQLtoPosition"
        '
        'ReportStatus_BarStaticItem
        '
        Me.ReportStatus_BarStaticItem.Caption = "Report Status"
        Me.ReportStatus_BarStaticItem.Id = 292
        Me.ReportStatus_BarStaticItem.ImageOptions.Image = CType(resources.GetObject("ReportStatus_BarStaticItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ReportStatus_BarStaticItem.ImageOptions.LargeImage = CType(resources.GetObject("ReportStatus_BarStaticItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ReportStatus_BarStaticItem.ItemAppearance.Normal.BackColor = System.Drawing.SystemColors.Control
        Me.ReportStatus_BarStaticItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportStatus_BarStaticItem.ItemAppearance.Normal.Options.UseBackColor = True
        Me.ReportStatus_BarStaticItem.ItemAppearance.Normal.Options.UseFont = True
        Me.ReportStatus_BarStaticItem.Name = "ReportStatus_BarStaticItem"
        Me.ReportStatus_BarStaticItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'ZVSTA_XML_Fehlanzeige_Create_btn
        '
        Me.ZVSTA_XML_Fehlanzeige_Create_btn.Caption = "Create ZVSTA XML Fehlanzeige File"
        Me.ZVSTA_XML_Fehlanzeige_Create_btn.Id = 294
        Me.ZVSTA_XML_Fehlanzeige_Create_btn.ImageOptions.Image = CType(resources.GetObject("ZVSTA_XML_Fehlanzeige_Create_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ZVSTA_XML_Fehlanzeige_Create_btn.ImageOptions.LargeImage = CType(resources.GetObject("ZVSTA_XML_Fehlanzeige_Create_btn.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZVSTA_XML_Fehlanzeige_Create_btn.Name = "ZVSTA_XML_Fehlanzeige_Create_btn"
        '
        'BbiDeleteCurrentZVSTA_Form
        '
        Me.BbiDeleteCurrentZVSTA_Form.Caption = "Delete ZVSTA FormNr in the current Report "
        Me.BbiDeleteCurrentZVSTA_Form.Id = 299
        Me.BbiDeleteCurrentZVSTA_Form.ImageOptions.Image = CType(resources.GetObject("BbiDeleteCurrentZVSTA_Form.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDeleteCurrentZVSTA_Form.ImageOptions.LargeImage = CType(resources.GetObject("BbiDeleteCurrentZVSTA_Form.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDeleteCurrentZVSTA_Form.Name = "BbiDeleteCurrentZVSTA_Form"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup4, Me.RibbonPageGroup6, Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.MeldeschemasReportingPeriod_BarEditItem)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiSqlReload)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiAddNewZvReport, True)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiDelete, True)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ZVSTA_ProcessingMenu_BarSubItem, True)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BbiSave)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "RibbonPageGroup4"
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BbiPrintExport)
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Text = "RibbonPageGroup6"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BbiClose)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemFontEdit1
        '
        Me.RepositoryItemFontEdit1.AutoHeight = False
        Me.RepositoryItemFontEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFontEdit1.Name = "RepositoryItemFontEdit1"
        '
        'RepositoryItemRichEditFontSizeEdit1
        '
        Me.RepositoryItemRichEditFontSizeEdit1.AutoHeight = False
        Me.RepositoryItemRichEditFontSizeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemRichEditFontSizeEdit1.Control = Me.RichEditControl1
        Me.RepositoryItemRichEditFontSizeEdit1.Name = "RepositoryItemRichEditFontSizeEdit1"
        '
        'DisplayForReviewModeComboBox1
        '
        Me.DisplayForReviewModeComboBox1.AutoHeight = False
        Me.DisplayForReviewModeComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisplayForReviewModeComboBox1.Name = "DisplayForReviewModeComboBox1"
        Me.DisplayForReviewModeComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemBorderLineStyle1
        '
        Me.RepositoryItemBorderLineStyle1.AutoHeight = False
        Me.RepositoryItemBorderLineStyle1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBorderLineStyle1.Control = Me.RichEditControl1
        Me.RepositoryItemBorderLineStyle1.Name = "RepositoryItemBorderLineStyle1"
        '
        'RepositoryItemBorderLineWeight1
        '
        Me.RepositoryItemBorderLineWeight1.AutoHeight = False
        Me.RepositoryItemBorderLineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBorderLineWeight1.Control = Me.RichEditControl1
        Me.RepositoryItemBorderLineWeight1.Name = "RepositoryItemBorderLineWeight1"
        '
        'RepositoryItemFloatingObjectOutlineWeight1
        '
        Me.RepositoryItemFloatingObjectOutlineWeight1.AutoHeight = False
        Me.RepositoryItemFloatingObjectOutlineWeight1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemFloatingObjectOutlineWeight1.Control = Me.RichEditControl1
        Me.RepositoryItemFloatingObjectOutlineWeight1.Name = "RepositoryItemFloatingObjectOutlineWeight1"
        '
        'ChangeParameterPosition_SpinEdit
        '
        Me.ChangeParameterPosition_SpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ChangeParameterPosition_SpinEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ChangeParameterPosition_SpinEdit.AutoHeight = False
        Me.ChangeParameterPosition_SpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChangeParameterPosition_SpinEdit.Mask.EditMask = "[1-9]{1,10}"
        Me.ChangeParameterPosition_SpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.ChangeParameterPosition_SpinEdit.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.ChangeParameterPosition_SpinEdit.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ChangeParameterPosition_SpinEdit.Name = "ChangeParameterPosition_SpinEdit"
        Me.ChangeParameterPosition_SpinEdit.NullText = "Add new LfdNr"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 583)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1395, 22)
        '
        'RichTextEdit2
        '
        Me.RichTextEdit2.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextEdit2.Appearance.Options.UseFont = True
        Me.RichTextEdit2.Name = "RichTextEdit2"
        Me.RichTextEdit2.ShowCaretInReadOnly = False
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoEdit1.Appearance.Options.UseFont = True
        Me.MemoEdit1.Appearance.Options.UseTextOptions = True
        Me.MemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.MemoEdit1.Name = "MemoEdit1"
        '
        'LandCode_ImageComboBox
        '
        Me.LandCode_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LandCode_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LandCode_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LandCode_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.LandCode_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.LandCode_ImageComboBox.AutoHeight = False
        Me.LandCode_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LandCode_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DE - INLAND", "DE", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("A1 - INSGESAMT", "A1", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("U9 - AUSSERHALB EU", "U9", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EU - INNERHALB", "EU", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Z9 - AUSLAND", "Z9", 7)})
        Me.LandCode_ImageComboBox.Name = "LandCode_ImageComboBox"
        Me.LandCode_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'LandCode2021_ImageComboBox
        '
        Me.LandCode2021_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LandCode2021_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LandCode2021_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LandCode2021_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.LandCode2021_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.LandCode2021_ImageComboBox.AutoHeight = False
        Me.LandCode2021_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LandCode2021_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DE - INLAND", "DE", 2), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("W0 - INSGESAMT", "W0", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EU-EWG (SEPARAT)", "EU_EEA_SEPARAT", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("G1 - REST DER WELT (INSGESAMT)", "G1", 3), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("G3 - EU-EWG (INSGESAMT)", "G3", 10), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JEDES LAND SEPARAT", "JEDES_LAND", 11)})
        Me.LandCode2021_ImageComboBox.Name = "LandCode2021_ImageComboBox"
        Me.LandCode2021_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'PayCardSystem_ImageComboBox
        '
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.PayCardSystem_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.PayCardSystem_ImageComboBox.AutoHeight = False
        Me.PayCardSystem_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PayCardSystem_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Not Relevant", "N", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PAYMENTS ALL", "PAY_ALL", 12), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DIRECT DEBITS ALL", "DD_ALL", 13), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CARDS ALL", "CARDS_ALL", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MCC CODES", "MCC_CODES", 15)})
        Me.PayCardSystem_ImageComboBox.Name = "PayCardSystem_ImageComboBox"
        Me.PayCardSystem_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "PDataTool.Settings.DataConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        CustomSqlQuery1.Name = "Query"
        QueryParameter1.Name = "SchemaReporting"
        QueryParameter1.Type = GetType(String)
        QueryParameter1.ValueInfo = "ZVSTA_2022_Q202201"
        CustomSqlQuery1.Parameters.Add(QueryParameter1)
        CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'SharedImageCollection1
        '
        '
        '
        '
        Me.SharedImageCollection1.ImageSource.ImageStream = CType(resources.GetObject("SharedImageCollection1.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(0, "usergroup_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(1, "add_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(2, "BankABCLogoN.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(3, "properties_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(4, "closeheaderandfooter_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(5, "apply_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(6, "cancel_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(7, "table_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(8, "columnsthree_16x16.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(9, "Windows-Cascade-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(10, "application-tile-horizontal-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(11, "application-tile-vertical-icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(12, "warning_16x16.png")
        Me.SharedImageCollection1.ParentControl = Me
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 650, 526)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1395, 489)
        Me.LayoutControl3.TabIndex = 4
        Me.LayoutControl3.Text = "LayoutControl3"
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
        Me.ProgressPanel1.StyleController = Me.LayoutControl3
        Me.ProgressPanel1.TabIndex = 13
        Me.ProgressPanel1.Text = "ProgressPanel1"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup1, Me.ZVSTA_LoadingPanel_LayoutControlGroup})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1395, 489)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Aqua
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 65)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1375, 404)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1351, 359)
        Me.LayoutControlGroup1.Text = "All reporting positions"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1351, 359)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'ZVSTA_LoadingPanel_LayoutControlGroup
        '
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Name = "ZVSTA_LoadingPanel_LayoutControlGroup"
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Size = New System.Drawing.Size(1375, 65)
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Text = "Meldeschema - Reporting Period loading"
        Me.ZVSTA_LoadingPanel_LayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ProgressPanel1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1351, 20)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'bbiReload
        '
        Me.bbiReload.Caption = "Reload"
        Me.bbiReload.Id = 3
        Me.bbiReload.ImageOptions.SvgImage = CType(resources.GetObject("bbiReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.bbiReload.Name = "bbiReload"
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl3
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'SqlParameterGridviewPopupMenu
        '
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDeleteCurrentZVSTA_Form)
        Me.SqlParameterGridviewPopupMenu.Name = "SqlParameterGridviewPopupMenu"
        Me.SqlParameterGridviewPopupMenu.Ribbon = Me.RibbonControl
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.ZVSTAT_Parameters_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Pay_Cards_ParametersTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_ProofingRules_ParameterTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_ReportingTableAdapter = Me.ZVSTAT_ReportingTableAdapter
        '
        'ZVSTAT_ReportingTableAdapter
        '
        Me.ZVSTAT_ReportingTableAdapter.ClearBeforeFill = True
        '
        'ZvStatistikReporting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1395, 605)
        Me.Controls.Add(Me.popupContainerControl)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.ShowIcon = False
        Me.KeyPreview = True
        Me.Name = "ZvStatistikReporting"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "ZV Statistik - Reporting"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Anzahl_SpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Wert_SpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_ReportingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_ReportingALL_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PositionName_MemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Landcontext_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl.ResumeLayout(False)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvReportings_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFontEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRichEditFontSizeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisplayForReviewModeComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBorderLineStyle1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBorderLineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFloatingObjectOutlineWeight1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChangeParameterPosition_SpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RichTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandCode_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTA_LoadingPanel_LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemMemoExEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Landcontext_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZVSTAT_ReportingALL_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BbiSqlReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddNewZvReport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiPrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents RichTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit
    Friend WithEvents PopupContainerEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Private WithEvents popupContainerControl As DevExpress.XtraEditors.PopupContainerControl
    Private WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BbiDuplicateSQLParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SqlParameterGridviewPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BbiAddSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZvStatistik_Dataset As ZvStatistik_Dataset
    Friend WithEvents MeldeschemasReportingPeriod_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Meldeschemas_RepositoryItemSearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLfdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandkontext As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnzahl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWert As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionSQLcommand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZVSTA_Schema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TableAdapterManager As ZvStatistik_DatasetTableAdapters.TableAdapterManager
    Friend WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
    Friend WithEvents RepositoryItemRichEditFontSizeEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
    Friend WithEvents DisplayForReviewModeComboBox1 As DevExpress.XtraRichEdit.UI.DisplayForReviewModeComboBox
    Friend WithEvents RepositoryItemBorderLineStyle1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle
    Friend WithEvents RepositoryItemBorderLineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight
    Friend WithEvents RepositoryItemFloatingObjectOutlineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight
    Friend WithEvents colLastAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZVSTA_ProcessingMenu_BarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BbiDuplicateSQLParameterCurrentPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDuplicateSQLParameterNextPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddSQLtoNextPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ZVSTA_Execute_Commands_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_Finalize_Commands_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_Execute_ALL_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_XML_Create_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ChangeParameterPosition_SpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents BbiChangeSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LandCode_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents AnzahlWert_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colSumPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LandCode2021_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colPayCardSystem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PayCardSystem_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZVSTAT_ReportingBindingSource As BindingSource
    Friend WithEvents ZVSTAT_ReportingTableAdapter As ZvStatistik_DatasetTableAdapters.ZVSTAT_ReportingTableAdapter
    Friend WithEvents ZvReportings_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents colReportingPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode_Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPayCardSystem_Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnzahl_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWert_Value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode_ALL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPayCardSystem_ALL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryCode_ALL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPositionInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents ZVSTA_LoadingPanel_LayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PositionName_MemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents Anzahl_SpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Wert_SpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents SumPosition_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReportStatus_BarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents ZVSTA_Validate_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colLandCodeT_ALL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode_T As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLandCode_T_Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryCodeT_ALL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryCode_T As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubdivisionOfCountryName_T As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZVSTA_XML_Fehlanzeige_Create_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_FirstDataCards_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_FraudelentPayments_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_FraudelentCards_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTA_Sums_Calculate_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDeleteCurrentZVSTA_Form As DevExpress.XtraBars.BarButtonItem
End Class
