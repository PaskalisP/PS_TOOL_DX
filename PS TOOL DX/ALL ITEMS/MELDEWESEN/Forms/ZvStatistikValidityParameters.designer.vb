<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ZvStatistikValidityParameters
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZvStatistikValidityParameters))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.colValidityTermStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ValidityRuleStatus_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.ZVSTAT_ProofingRules_ParameterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZvStatistik_Dataset = New PS_TOOL_DX.ZvStatistik_DataSet()
        Me.ZVSTAT_ValidityRules_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZVSTA_Schema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colValidity_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colValidityType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ValidityType_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colReportingFormLeft = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReportingFormRight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValidityTerm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MemoEdit_Default = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colValidityTermDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValiditySqlParameter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdateUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PopupContainerEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.popupContainerControl = New DevExpress.XtraEditors.PopupContainerControl()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BbiSqlReload = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddNewZvParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiSave = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiPrintExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiClose = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDuplicateSQLParameter = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.Meldeschemas_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ZvSta_Meldeschema_Param_BarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.NewMeldeschemaFromCurrent_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.NewMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.RenameCurrentMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.DeleteCurrentMeldeschema_btn = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiActivateAllValidityParameters = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiDeactivateAllValidityParameters = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiAddSQLtoNextPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.BbiChangeSQLtoPosition = New DevExpress.XtraBars.BarButtonItem()
        Me.FindAndReplaceText_bbi = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup7 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
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
        Me.AnzahlWert_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.LandCode2021_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.PayCardSystem_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SumPosition_ImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bbiReload = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SqlParameterGridviewPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.TableAdapterManager = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager()
        Me.ZVSTAT_ProofingRules_ParameterTableAdapter = New PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.ZVSTAT_ProofingRules_ParameterTableAdapter()
        CType(Me.ValidityRuleStatus_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_ProofingRules_ParameterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTAT_ValidityRules_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTA_Schema_RepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidityType_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit_Default, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupContainerControl.SuspendLayout()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEditView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SqlParameterGridviewPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colValidityTermStatus
        '
        Me.colValidityTermStatus.Caption = "Validity Term Status"
        Me.colValidityTermStatus.ColumnEdit = Me.ValidityRuleStatus_ImageComboBox
        Me.colValidityTermStatus.FieldName = "ValidityTermStatus"
        Me.colValidityTermStatus.Name = "colValidityTermStatus"
        Me.colValidityTermStatus.Visible = True
        Me.colValidityTermStatus.VisibleIndex = 8
        Me.colValidityTermStatus.Width = 99
        '
        'ValidityRuleStatus_ImageComboBox
        '
        Me.ValidityRuleStatus_ImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidityRuleStatus_ImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidityRuleStatus_ImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidityRuleStatus_ImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ValidityRuleStatus_ImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ValidityRuleStatus_ImageComboBox.AutoHeight = False
        Me.ValidityRuleStatus_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidityRuleStatus_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 16), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INVALID", "N", 5)})
        Me.ValidityRuleStatus_ImageComboBox.Name = "ValidityRuleStatus_ImageComboBox"
        Me.ValidityRuleStatus_ImageComboBox.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.Images.SetKeyName(16, "apply_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "summary_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(18, "salesthankyou_16x16.png")
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemMemoExEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseForeColor = True
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
        Me.GridControl3.DataSource = Me.ZVSTAT_ProofingRules_ParameterBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.ImageIndex = 4
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.ImageIndex = 7
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(12, 12)
        Me.GridControl3.MainView = Me.ZVSTAT_ValidityRules_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3, Me.RepositoryItemSpinEdit1, Me.ValidityRuleStatus_ImageComboBox, Me.RepositoryItemDateEdit1, Me.PopupContainerEdit2, Me.RichTextEdit2, Me.MemoEdit1, Me.ValidityType_ImageComboBox, Me.AnzahlWert_RepositoryItemImageComboBox, Me.LandCode2021_ImageComboBox, Me.PayCardSystem_ImageComboBox, Me.MemoEdit_Default, Me.SumPosition_ImageComboBox, Me.ZVSTA_Schema_RepositoryItemLookUpEdit})
        Me.GridControl3.Size = New System.Drawing.Size(1384, 445)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ZVSTAT_ValidityRules_Gridview})
        '
        'ZVSTAT_ProofingRules_ParameterBindingSource
        '
        Me.ZVSTAT_ProofingRules_ParameterBindingSource.DataMember = "ZVSTAT_ProofingRules_Parameter"
        Me.ZVSTAT_ProofingRules_ParameterBindingSource.DataSource = Me.ZvStatistik_Dataset
        '
        'ZvStatistik_Dataset
        '
        Me.ZvStatistik_Dataset.DataSetName = "ZvStatistik_Dataset"
        Me.ZvStatistik_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZVSTAT_ValidityRules_Gridview
        '
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.GroupButton.ForeColor = System.Drawing.Color.Navy
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.GroupButton.Options.UseForeColor = True
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Navy
        Me.ZVSTAT_ValidityRules_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.ZVSTAT_ValidityRules_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colZVSTA_Schema, Me.colValidity_ID, Me.colValidityType, Me.colReportingFormLeft, Me.colReportingFormRight, Me.colValidityTerm, Me.colValidityTermDescription, Me.colValiditySqlParameter, Me.colValidityTermStatus, Me.colLastAction, Me.colLastUpdateDate, Me.colLastUpdateUser})
        Me.ZVSTAT_ValidityRules_Gridview.DetailHeight = 303
        Me.ZVSTAT_ValidityRules_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.colValidityTermStatus
        GridFormatRule1.ColumnApplyTo = Me.colValidityTermStatus
        GridFormatRule1.Name = "FormatStatus"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = "N"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.ZVSTAT_ValidityRules_Gridview.FormatRules.Add(GridFormatRule1)
        Me.ZVSTAT_ValidityRules_Gridview.GridControl = Me.GridControl3
        Me.ZVSTAT_ValidityRules_Gridview.Name = "ZVSTAT_ValidityRules_Gridview"
        Me.ZVSTAT_ValidityRules_Gridview.NewItemRowText = "Add new Validity Rule Parameter"
        Me.ZVSTAT_ValidityRules_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ValidityRules_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ValidityRules_Gridview.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ValidityRules_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.ZVSTAT_ValidityRules_Gridview.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ValidityRules_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsDetail.AllowExpandEmptyDetails = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsDetail.AutoZoomDetail = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZVSTAT_ValidityRules_Gridview.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.ZVSTAT_ValidityRules_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsFind.AlwaysVisible = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsFind.SearchInPreview = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsNavigation.AutoFocusNewRow = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsSelection.MultiSelect = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.AutoCalcPreviewLineCount = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ColumnAutoWidth = False
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.RowAutoHeight = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowChildrenInGroupPanel = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowFooter = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowGroupedColumns = True
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowGroupPanel = False
        Me.ZVSTAT_ValidityRules_Gridview.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        Me.ZVSTAT_ValidityRules_Gridview.PreviewFieldName = "ValiditySqlParameter"
        Me.ZVSTAT_ValidityRules_Gridview.ViewCaption = "ZV Statistik Parameter"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colZVSTA_Schema
        '
        Me.colZVSTA_Schema.Caption = "ZVSTA Schema"
        Me.colZVSTA_Schema.ColumnEdit = Me.ZVSTA_Schema_RepositoryItemLookUpEdit
        Me.colZVSTA_Schema.FieldName = "ZVSTA_Schema"
        Me.colZVSTA_Schema.Name = "colZVSTA_Schema"
        Me.colZVSTA_Schema.Visible = True
        Me.colZVSTA_Schema.VisibleIndex = 0
        Me.colZVSTA_Schema.Width = 121
        '
        'ZVSTA_Schema_RepositoryItemLookUpEdit
        '
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.AutoHeight = False
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ZVSTA_Schema", "ZVSTA Schema")})
        Me.ZVSTA_Schema_RepositoryItemLookUpEdit.Name = "ZVSTA_Schema_RepositoryItemLookUpEdit"
        '
        'colValidity_ID
        '
        Me.colValidity_ID.AppearanceCell.Options.UseTextOptions = True
        Me.colValidity_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValidity_ID.Caption = "Validity ID"
        Me.colValidity_ID.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colValidity_ID.FieldName = "Validity_ID"
        Me.colValidity_ID.Name = "colValidity_ID"
        Me.colValidity_ID.Visible = True
        Me.colValidity_ID.VisibleIndex = 1
        Me.colValidity_ID.Width = 113
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'colValidityType
        '
        Me.colValidityType.AppearanceCell.Options.UseTextOptions = True
        Me.colValidityType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValidityType.Caption = "Validity Type"
        Me.colValidityType.ColumnEdit = Me.ValidityType_ImageComboBox
        Me.colValidityType.FieldName = "ValidityType"
        Me.colValidityType.Name = "colValidityType"
        Me.colValidityType.Visible = True
        Me.colValidityType.VisibleIndex = 2
        Me.colValidityType.Width = 101
        '
        'ValidityType_ImageComboBox
        '
        Me.ValidityType_ImageComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.ValidityType_ImageComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidityType_ImageComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ValidityType_ImageComboBox.Appearance.Options.UseBackColor = True
        Me.ValidityType_ImageComboBox.Appearance.Options.UseForeColor = True
        Me.ValidityType_ImageComboBox.AutoHeight = False
        Me.ValidityType_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidityType_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("SUM", "SUM", 17), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("LOGICAL", "LOGICAL", 18), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("TECHNICAL", "TECHNICAL", 7)})
        Me.ValidityType_ImageComboBox.Name = "ValidityType_ImageComboBox"
        Me.ValidityType_ImageComboBox.SmallImages = Me.ImageCollection1
        '
        'colReportingFormLeft
        '
        Me.colReportingFormLeft.AppearanceCell.Options.UseTextOptions = True
        Me.colReportingFormLeft.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colReportingFormLeft.Caption = "Reporting Form - Left"
        Me.colReportingFormLeft.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colReportingFormLeft.FieldName = "ReportingFormLeft"
        Me.colReportingFormLeft.Name = "colReportingFormLeft"
        Me.colReportingFormLeft.OptionsEditForm.StartNewRow = True
        Me.colReportingFormLeft.Visible = True
        Me.colReportingFormLeft.VisibleIndex = 3
        Me.colReportingFormLeft.Width = 100
        '
        'colReportingFormRight
        '
        Me.colReportingFormRight.AppearanceCell.Options.UseTextOptions = True
        Me.colReportingFormRight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colReportingFormRight.Caption = "Reporting Form - Right"
        Me.colReportingFormRight.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colReportingFormRight.FieldName = "ReportingFormRight"
        Me.colReportingFormRight.Name = "colReportingFormRight"
        Me.colReportingFormRight.Visible = True
        Me.colReportingFormRight.VisibleIndex = 4
        Me.colReportingFormRight.Width = 102
        '
        'colValidityTerm
        '
        Me.colValidityTerm.AppearanceCell.Options.UseTextOptions = True
        Me.colValidityTerm.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colValidityTerm.Caption = "Validity Term"
        Me.colValidityTerm.ColumnEdit = Me.MemoEdit_Default
        Me.colValidityTerm.FieldName = "ValidityTerm"
        Me.colValidityTerm.Name = "colValidityTerm"
        Me.colValidityTerm.Visible = True
        Me.colValidityTerm.VisibleIndex = 5
        Me.colValidityTerm.Width = 276
        '
        'MemoEdit_Default
        '
        Me.MemoEdit_Default.Appearance.Options.UseTextOptions = True
        Me.MemoEdit_Default.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MemoEdit_Default.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MemoEdit_Default.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MemoEdit_Default.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MemoEdit_Default.AppearanceFocused.Options.UseBackColor = True
        Me.MemoEdit_Default.AppearanceFocused.Options.UseForeColor = True
        Me.MemoEdit_Default.Name = "MemoEdit_Default"
        '
        'colValidityTermDescription
        '
        Me.colValidityTermDescription.AppearanceCell.Options.UseTextOptions = True
        Me.colValidityTermDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colValidityTermDescription.Caption = "Validity Term Description"
        Me.colValidityTermDescription.ColumnEdit = Me.MemoEdit_Default
        Me.colValidityTermDescription.FieldName = "ValidityTermDescription"
        Me.colValidityTermDescription.Name = "colValidityTermDescription"
        Me.colValidityTermDescription.Visible = True
        Me.colValidityTermDescription.VisibleIndex = 6
        Me.colValidityTermDescription.Width = 515
        '
        'colValiditySqlParameter
        '
        Me.colValiditySqlParameter.Caption = "Validity SQL Parameter"
        Me.colValiditySqlParameter.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.colValiditySqlParameter.FieldName = "ValiditySqlParameter"
        Me.colValiditySqlParameter.Name = "colValiditySqlParameter"
        Me.colValiditySqlParameter.Visible = True
        Me.colValiditySqlParameter.VisibleIndex = 7
        Me.colValiditySqlParameter.Width = 95
        '
        'colLastAction
        '
        Me.colLastAction.FieldName = "LastAction"
        Me.colLastAction.Name = "colLastAction"
        Me.colLastAction.OptionsColumn.ReadOnly = True
        Me.colLastAction.OptionsEditForm.StartNewRow = True
        Me.colLastAction.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colLastUpdateDate
        '
        Me.colLastUpdateDate.FieldName = "LastUpdateDate"
        Me.colLastUpdateDate.Name = "colLastUpdateDate"
        Me.colLastUpdateDate.OptionsColumn.ReadOnly = True
        Me.colLastUpdateDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colLastUpdateUser
        '
        Me.colLastUpdateUser.FieldName = "LastUpdateUser"
        Me.colLastUpdateUser.Name = "colLastUpdateUser"
        Me.colLastUpdateUser.OptionsColumn.ReadOnly = True
        Me.colLastUpdateUser.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
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
        Me.RichEditControl1.Size = New System.Drawing.Size(162, 38)
        Me.RichEditControl1.TabIndex = 2
        '
        'RibbonControl
        '
        Me.RibbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.RibbonControl.SearchEditItem, Me.BbiSqlReload, Me.BbiAddNewZvParameter, Me.BbiSave, Me.BbiDelete, Me.BbiPrintExport, Me.BbiClose, Me.BbiDuplicateSQLParameter, Me.BbiAddSQLtoPosition, Me.Meldeschemas_BarEditItem, Me.ZvSta_Meldeschema_Param_BarSubItem, Me.BbiActivateAllValidityParameters, Me.BbiDeactivateAllValidityParameters, Me.BbiAddSQLtoNextPosition, Me.BarSubItem1, Me.NewMeldeschemaFromCurrent_btn, Me.NewMeldeschema_btn, Me.RenameCurrentMeldeschema_btn, Me.DeleteCurrentMeldeschema_btn, Me.BbiChangeSQLtoPosition, Me.FindAndReplaceText_bbi})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 293
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1, Me.Meldeschemas_RepositoryItemSearchLookUpEdit, Me.RepositoryItemFontEdit1, Me.RepositoryItemRichEditFontSizeEdit1, Me.DisplayForReviewModeComboBox1, Me.RepositoryItemBorderLineStyle1, Me.RepositoryItemBorderLineWeight1, Me.RepositoryItemFloatingObjectOutlineWeight1, Me.ChangeParameterPosition_SpinEdit})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowSearchItem = True
        Me.RibbonControl.Size = New System.Drawing.Size(1408, 94)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BbiSqlReload
        '
        Me.BbiSqlReload.Caption = "Reload"
        Me.BbiSqlReload.Id = 1
        Me.BbiSqlReload.ImageOptions.SvgImage = CType(resources.GetObject("BbiSqlReload.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiSqlReload.Name = "BbiSqlReload"
        '
        'BbiAddNewZvParameter
        '
        Me.BbiAddNewZvParameter.Caption = "Add new ZV Statistik Validity Rule Parameter"
        Me.BbiAddNewZvParameter.Id = 2
        Me.BbiAddNewZvParameter.ImageOptions.SvgImage = CType(resources.GetObject("BbiAddNewZvParameter.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiAddNewZvParameter.Name = "BbiAddNewZvParameter"
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
        Me.BbiDelete.Caption = "Delete Validity Rule Parameter"
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
        'Meldeschemas_BarEditItem
        '
        Me.Meldeschemas_BarEditItem.Caption = "Meldeschema"
        Me.Meldeschemas_BarEditItem.Edit = Me.Meldeschemas_RepositoryItemSearchLookUpEdit
        Me.Meldeschemas_BarEditItem.EditWidth = 150
        Me.Meldeschemas_BarEditItem.Id = 4
        Me.Meldeschemas_BarEditItem.Name = "Meldeschemas_BarEditItem"
        '
        'Meldeschemas_RepositoryItemSearchLookUpEdit
        '
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.AutoHeight = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.Name = "Meldeschemas_RepositoryItemSearchLookUpEdit"
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.NullText = ""
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.PopupView = Me.Meldeschemas_RepositoryItemSearchLookUpEditView
        Me.Meldeschemas_RepositoryItemSearchLookUpEdit.ShowClearButton = False
        '
        'Meldeschemas_RepositoryItemSearchLookUpEditView
        '
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.Name = "Meldeschemas_RepositoryItemSearchLookUpEditView"
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Meldeschemas_RepositoryItemSearchLookUpEditView.OptionsView.ShowGroupPanel = False
        '
        'ZvSta_Meldeschema_Param_BarSubItem
        '
        Me.ZvSta_Meldeschema_Param_BarSubItem.Caption = "Meldeschema Configurations"
        Me.ZvSta_Meldeschema_Param_BarSubItem.Id = 281
        Me.ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.Image = CType(resources.GetObject("ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.LargeImage = CType(resources.GetObject("ZvSta_Meldeschema_Param_BarSubItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ZvSta_Meldeschema_Param_BarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.RenameCurrentMeldeschema_btn, True), New DevExpress.XtraBars.LinkPersistInfo(Me.DeleteCurrentMeldeschema_btn, True)})
        Me.ZvSta_Meldeschema_Param_BarSubItem.Name = "ZvSta_Meldeschema_Param_BarSubItem"
        Me.ZvSta_Meldeschema_Param_BarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Add new ZV Statistic Meldeschema"
        Me.BarSubItem1.Id = 285
        Me.BarSubItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarSubItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.NewMeldeschemaFromCurrent_btn), New DevExpress.XtraBars.LinkPersistInfo(Me.NewMeldeschema_btn, True)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'NewMeldeschemaFromCurrent_btn
        '
        Me.NewMeldeschemaFromCurrent_btn.Caption = "New Meldeschema based on current"
        Me.NewMeldeschemaFromCurrent_btn.Id = 286
        Me.NewMeldeschemaFromCurrent_btn.ImageOptions.SvgImage = CType(resources.GetObject("NewMeldeschemaFromCurrent_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.NewMeldeschemaFromCurrent_btn.Name = "NewMeldeschemaFromCurrent_btn"
        '
        'NewMeldeschema_btn
        '
        Me.NewMeldeschema_btn.Caption = "New Meldeschema"
        Me.NewMeldeschema_btn.Id = 287
        Me.NewMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("NewMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.NewMeldeschema_btn.Name = "NewMeldeschema_btn"
        '
        'RenameCurrentMeldeschema_btn
        '
        Me.RenameCurrentMeldeschema_btn.Caption = "Rename current Meldeschema"
        Me.RenameCurrentMeldeschema_btn.Id = 288
        Me.RenameCurrentMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("RenameCurrentMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.RenameCurrentMeldeschema_btn.Name = "RenameCurrentMeldeschema_btn"
        '
        'DeleteCurrentMeldeschema_btn
        '
        Me.DeleteCurrentMeldeschema_btn.Caption = "Delete current Meldeschema"
        Me.DeleteCurrentMeldeschema_btn.Id = 289
        Me.DeleteCurrentMeldeschema_btn.ImageOptions.SvgImage = CType(resources.GetObject("DeleteCurrentMeldeschema_btn.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.DeleteCurrentMeldeschema_btn.Name = "DeleteCurrentMeldeschema_btn"
        '
        'BbiActivateAllValidityParameters
        '
        Me.BbiActivateAllValidityParameters.Caption = "Activate all Validity Parameters"
        Me.BbiActivateAllValidityParameters.Id = 282
        Me.BbiActivateAllValidityParameters.ImageOptions.Image = CType(resources.GetObject("BbiActivateAllValidityParameters.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiActivateAllValidityParameters.ImageOptions.LargeImage = CType(resources.GetObject("BbiActivateAllValidityParameters.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiActivateAllValidityParameters.Name = "BbiActivateAllValidityParameters"
        '
        'BbiDeactivateAllValidityParameters
        '
        Me.BbiDeactivateAllValidityParameters.Caption = "Deactivate all Validity Parameters"
        Me.BbiDeactivateAllValidityParameters.Id = 283
        Me.BbiDeactivateAllValidityParameters.ImageOptions.Image = CType(resources.GetObject("BbiDeactivateAllValidityParameters.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiDeactivateAllValidityParameters.ImageOptions.LargeImage = CType(resources.GetObject("BbiDeactivateAllValidityParameters.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiDeactivateAllValidityParameters.Name = "BbiDeactivateAllValidityParameters"
        '
        'BbiAddSQLtoNextPosition
        '
        Me.BbiAddSQLtoNextPosition.Caption = "Add new ZV Statistic Parameter to next Position"
        Me.BbiAddSQLtoNextPosition.Id = 284
        Me.BbiAddSQLtoNextPosition.ImageOptions.Image = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.Image"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.ImageOptions.LargeImage = CType(resources.GetObject("BbiAddSQLtoNextPosition.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BbiAddSQLtoNextPosition.Name = "BbiAddSQLtoNextPosition"
        '
        'BbiChangeSQLtoPosition
        '
        Me.BbiChangeSQLtoPosition.Caption = "Change ZV Parameter Position"
        Me.BbiChangeSQLtoPosition.Id = 291
        Me.BbiChangeSQLtoPosition.ImageOptions.SvgImage = CType(resources.GetObject("BbiChangeSQLtoPosition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BbiChangeSQLtoPosition.Name = "BbiChangeSQLtoPosition"
        '
        'FindAndReplaceText_bbi
        '
        Me.FindAndReplaceText_bbi.Caption = "Find and Replace"
        Me.FindAndReplaceText_bbi.Id = 292
        Me.FindAndReplaceText_bbi.ImageOptions.Image = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.Image"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.ImageOptions.LargeImage = CType(resources.GetObject("FindAndReplaceText_bbi.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.FindAndReplaceText_bbi.Name = "FindAndReplaceText_bbi"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup3, Me.RibbonPageGroup4, Me.RibbonPageGroup5, Me.RibbonPageGroup6, Me.RibbonPageGroup1, Me.RibbonPageGroup7})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.Meldeschemas_BarEditItem)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BbiSqlReload)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ZvSta_Meldeschema_Param_BarSubItem)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BbiAddNewZvParameter)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "RibbonPageGroup3"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BbiSave)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "RibbonPageGroup4"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BbiDelete)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.FindAndReplaceText_bbi, True)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "RibbonPageGroup5"
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
        'RibbonPageGroup7
        '
        Me.RibbonPageGroup7.Name = "RibbonPageGroup7"
        Me.RibbonPageGroup7.Text = "RibbonPageGroup7"
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
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 563)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1408, 22)
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
        Me.MemoEdit1.Name = "MemoEdit1"
        '
        'AnzahlWert_RepositoryItemImageComboBox
        '
        Me.AnzahlWert_RepositoryItemImageComboBox.AutoHeight = False
        Me.AnzahlWert_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.AnzahlWert_RepositoryItemImageComboBox.Name = "AnzahlWert_RepositoryItemImageComboBox"
        Me.AnzahlWert_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
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
        'SumPosition_ImageComboBox
        '
        Me.SumPosition_ImageComboBox.AutoHeight = False
        Me.SumPosition_ImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SumPosition_ImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FIRST SUM", "1", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - INTERMEDIARY SUM", "2", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("JA - FINAL SUM", "3", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NEIN", "N", 9)})
        Me.SumPosition_ImageComboBox.Name = "SumPosition_ImageComboBox"
        Me.SumPosition_ImageComboBox.SmallImages = Me.ImageCollection1
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
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(13, "BankABCLogoFra.png")
        Me.SharedImageCollection1.ParentControl = Me
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 650, 526)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1408, 469)
        Me.LayoutControl3.TabIndex = 4
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1408, 469)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1388, 449)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
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
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiAddNewZvParameter, True)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDelete)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiActivateAllValidityParameters, True)
        Me.SqlParameterGridviewPopupMenu.ItemLinks.Add(Me.BbiDeactivateAllValidityParameters)
        Me.SqlParameterGridviewPopupMenu.Name = "SqlParameterGridviewPopupMenu"
        Me.SqlParameterGridviewPopupMenu.Ribbon = Me.RibbonControl
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ZvStatistik_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.ZVSTAT_Parameters_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Pay_Cards_ParametersTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_ProofingRules_ParameterTableAdapter = Me.ZVSTAT_ProofingRules_ParameterTableAdapter
        Me.TableAdapterManager.ZVSTAT_ReportingTableAdapter = Nothing
        '
        'ZVSTAT_ProofingRules_ParameterTableAdapter
        '
        Me.ZVSTAT_ProofingRules_ParameterTableAdapter.ClearBeforeFill = True
        '
        'ZvStatistikValidityParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1408, 585)
        Me.Controls.Add(Me.popupContainerControl)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IconOptions.ShowIcon = False
        Me.KeyPreview = True
        Me.Name = "ZvStatistikValidityParameters"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "ZV Statistik - Validity Parameter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ValidityRuleStatus_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_ProofingRules_ParameterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvStatistik_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTAT_ValidityRules_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTA_Schema_RepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidityType_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit_Default, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popupContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupContainerControl.ResumeLayout(False)
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meldeschemas_RepositoryItemSearchLookUpEditView, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.AnzahlWert_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LandCode2021_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayCardSystem_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SumPosition_ImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ValidityRuleStatus_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ZVSTAT_ValidityRules_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    'Friend WithEvents EDP_DataSet As EDP_DataSet
    Friend WithEvents BbiSqlReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddNewZvParameter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiPrintExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiReload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
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
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZvStatistik_Dataset As ZvStatistik_Dataset
    Friend WithEvents Meldeschemas_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Meldeschemas_RepositoryItemSearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents Meldeschemas_RepositoryItemSearchLookUpEditView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableAdapterManager As ZvStatistik_DatasetTableAdapters.TableAdapterManager
    Friend WithEvents RepositoryItemFontEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemFontEdit
    Friend WithEvents RepositoryItemRichEditFontSizeEdit1 As DevExpress.XtraRichEdit.Design.RepositoryItemRichEditFontSizeEdit
    Friend WithEvents DisplayForReviewModeComboBox1 As DevExpress.XtraRichEdit.UI.DisplayForReviewModeComboBox
    Friend WithEvents RepositoryItemBorderLineStyle1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineStyle
    Friend WithEvents RepositoryItemBorderLineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemBorderLineWeight
    Friend WithEvents RepositoryItemFloatingObjectOutlineWeight1 As DevExpress.XtraRichEdit.Forms.Design.RepositoryItemFloatingObjectOutlineWeight
    Friend WithEvents ZvSta_Meldeschema_Param_BarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents RibbonPageGroup7 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BbiActivateAllValidityParameters As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiDeactivateAllValidityParameters As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BbiAddSQLtoNextPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents NewMeldeschemaFromCurrent_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NewMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RenameCurrentMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DeleteCurrentMeldeschema_btn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ChangeParameterPosition_SpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents BbiChangeSQLtoPosition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ValidityType_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents AnzahlWert_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LandCode2021_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents PayCardSystem_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents MemoEdit_Default As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents SumPosition_ImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents FindAndReplaceText_bbi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ZVSTAT_ProofingRules_ParameterBindingSource As BindingSource
    Friend WithEvents ZVSTAT_ProofingRules_ParameterTableAdapter As ZvStatistik_DatasetTableAdapters.ZVSTAT_ProofingRules_ParameterTableAdapter
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValidity_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValidityType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReportingFormLeft As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReportingFormRight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValidityTerm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValidityTermDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValiditySqlParameter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValidityTermStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdateUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZVSTA_Schema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZVSTA_Schema_RepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
