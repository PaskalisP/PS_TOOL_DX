<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Securities_AddNewDailyPrice
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Securities_AddNewDailyPrice))
        Me.colMarket_Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LiquidityDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.SecuritiesDailyPriceBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractNrOCBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISIN_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrincipalOrigAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPurchase_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Cancel_Button = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.DailyPrice_import_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LiquidityDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiquidityDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecuritiesDailyPriceBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colMarket_Price
        '
        Me.colMarket_Price.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colMarket_Price.AppearanceCell.Options.UseFont = True
        Me.colMarket_Price.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colMarket_Price.AppearanceHeader.ForeColor = System.Drawing.Color.Navy
        Me.colMarket_Price.AppearanceHeader.Options.UseFont = True
        Me.colMarket_Price.AppearanceHeader.Options.UseForeColor = True
        Me.colMarket_Price.Caption = "Market Price"
        Me.colMarket_Price.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colMarket_Price.DisplayFormat.FormatString = "n6"
        Me.colMarket_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMarket_Price.FieldName = "Market_Price"
        Me.colMarket_Price.Name = "colMarket_Price"
        Me.colMarket_Price.Visible = True
        Me.colMarket_Price.VisibleIndex = 7
        Me.colMarket_Price.Width = 139
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "n6"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatString = "n6"
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "n6"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.LiquidityDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1308, 599)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LiquidityDateEdit
        '
        Me.LiquidityDateEdit.EditValue = Nothing
        Me.LiquidityDateEdit.Location = New System.Drawing.Point(581, 12)
        Me.LiquidityDateEdit.Name = "LiquidityDateEdit"
        Me.LiquidityDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.LiquidityDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LiquidityDateEdit.Properties.Appearance.Options.UseFont = True
        Me.LiquidityDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.LiquidityDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiquidityDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LiquidityDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LiquidityDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LiquidityDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LiquidityDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LiquidityDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.LiquidityDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiquidityDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LiquidityDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.LiquidityDateEdit.Size = New System.Drawing.Size(152, 22)
        Me.LiquidityDateEdit.StyleController = Me.LayoutControl1
        Me.LiquidityDateEdit.TabIndex = 13
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 8, True, True, "Add new Daily Prices", "Add")})
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.SecuritiesDailyPriceBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(1284, 549)
        Me.GridControl2.TabIndex = 12
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SecuritiesDailyPriceBaseView})
        '
        'SecuritiesDailyPriceBaseView
        '
        Me.SecuritiesDailyPriceBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SecuritiesDailyPriceBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SecuritiesDailyPriceBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SecuritiesDailyPriceBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SecuritiesDailyPriceBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SecuritiesDailyPriceBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SecuritiesDailyPriceBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SecuritiesDailyPriceBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colContractNrOCBS, Me.colISIN_Code, Me.colName, Me.colCcy, Me.colPrincipalOrigAmt, Me.colPurchase_price, Me.colMarket_Price, Me.colAssetType, Me.colMaturityDate})
        Me.SecuritiesDailyPriceBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Column = Me.colMarket_Price
        GridFormatRule1.ColumnApplyTo = Me.colMarket_Price
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue1.Expression = "[Market_Price] = 0"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.SecuritiesDailyPriceBaseView.FormatRules.Add(GridFormatRule1)
        Me.SecuritiesDailyPriceBaseView.GridControl = Me.GridControl2
        Me.SecuritiesDailyPriceBaseView.Name = "SecuritiesDailyPriceBaseView"
        Me.SecuritiesDailyPriceBaseView.NewItemRowText = "Add new Security Depreciation"
        Me.SecuritiesDailyPriceBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SecuritiesDailyPriceBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.SecuritiesDailyPriceBaseView.OptionsCustomization.AllowFilter = False
        Me.SecuritiesDailyPriceBaseView.OptionsCustomization.AllowRowSizing = True
        Me.SecuritiesDailyPriceBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SecuritiesDailyPriceBaseView.OptionsSelection.MultiSelect = True
        Me.SecuritiesDailyPriceBaseView.OptionsView.ColumnAutoWidth = False
        Me.SecuritiesDailyPriceBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SecuritiesDailyPriceBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.SecuritiesDailyPriceBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.SecuritiesDailyPriceBaseView.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colContractNrOCBS
        '
        Me.colContractNrOCBS.Caption = "Contract Nr."
        Me.colContractNrOCBS.FieldName = "ContractNrOCBS"
        Me.colContractNrOCBS.Name = "colContractNrOCBS"
        Me.colContractNrOCBS.OptionsColumn.AllowEdit = False
        Me.colContractNrOCBS.OptionsColumn.ReadOnly = True
        Me.colContractNrOCBS.Visible = True
        Me.colContractNrOCBS.VisibleIndex = 0
        Me.colContractNrOCBS.Width = 110
        '
        'colISIN_Code
        '
        Me.colISIN_Code.Caption = "ISIN Code"
        Me.colISIN_Code.FieldName = "ISIN"
        Me.colISIN_Code.Name = "colISIN_Code"
        Me.colISIN_Code.OptionsColumn.AllowEdit = False
        Me.colISIN_Code.OptionsColumn.ReadOnly = True
        Me.colISIN_Code.Visible = True
        Me.colISIN_Code.VisibleIndex = 1
        Me.colISIN_Code.Width = 170
        '
        'colName
        '
        Me.colName.FieldName = "SecurityName"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 2
        Me.colName.Width = 260
        '
        'colCcy
        '
        Me.colCcy.FieldName = "Currency"
        Me.colCcy.Name = "colCcy"
        Me.colCcy.OptionsColumn.AllowEdit = False
        Me.colCcy.OptionsColumn.ReadOnly = True
        Me.colCcy.Visible = True
        Me.colCcy.VisibleIndex = 3
        Me.colCcy.Width = 68
        '
        'colPrincipalOrigAmt
        '
        Me.colPrincipalOrigAmt.Caption = "Principal Orig. Amount"
        Me.colPrincipalOrigAmt.DisplayFormat.FormatString = "n2"
        Me.colPrincipalOrigAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipalOrigAmt.FieldName = "PrincipalOrigAmt"
        Me.colPrincipalOrigAmt.Name = "colPrincipalOrigAmt"
        Me.colPrincipalOrigAmt.OptionsColumn.AllowEdit = False
        Me.colPrincipalOrigAmt.OptionsColumn.ReadOnly = True
        Me.colPrincipalOrigAmt.Visible = True
        Me.colPrincipalOrigAmt.VisibleIndex = 4
        Me.colPrincipalOrigAmt.Width = 122
        '
        'colPurchase_price
        '
        Me.colPurchase_price.Caption = "Purchase price"
        Me.colPurchase_price.DisplayFormat.FormatString = "n6"
        Me.colPurchase_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPurchase_price.FieldName = "Purchase_Price"
        Me.colPurchase_price.Name = "colPurchase_price"
        Me.colPurchase_price.OptionsColumn.AllowEdit = False
        Me.colPurchase_price.OptionsColumn.ReadOnly = True
        Me.colPurchase_price.Visible = True
        Me.colPurchase_price.VisibleIndex = 6
        Me.colPurchase_price.Width = 122
        '
        'colAssetType
        '
        Me.colAssetType.Caption = "Asset Type"
        Me.colAssetType.FieldName = "AssetType"
        Me.colAssetType.Name = "colAssetType"
        Me.colAssetType.OptionsColumn.AllowEdit = False
        Me.colAssetType.OptionsColumn.ReadOnly = True
        Me.colAssetType.Visible = True
        Me.colAssetType.VisibleIndex = 8
        Me.colAssetType.Width = 121
        '
        'colMaturityDate
        '
        Me.colMaturityDate.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturityDate.Caption = "Maturity Date"
        Me.colMaturityDate.FieldName = "MaturityDate"
        Me.colMaturityDate.Name = "colMaturityDate"
        Me.colMaturityDate.OptionsColumn.AllowEdit = False
        Me.colMaturityDate.OptionsColumn.ReadOnly = True
        Me.colMaturityDate.Visible = True
        Me.colMaturityDate.VisibleIndex = 5
        Me.colMaturityDate.Width = 115
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.EmptySpaceItem2})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1308, 599)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl2
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1288, 553)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(725, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(563, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.Control = Me.LiquidityDateEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(450, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(275, 26)
        Me.LayoutControlItem2.Text = "Date of Market Price"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(116, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(450, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_Button.ImageOptions.ImageIndex = 9
        Me.Cancel_Button.ImageOptions.ImageList = Me.ImageCollection1
        Me.Cancel_Button.Location = New System.Drawing.Point(1094, 603)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(192, 22)
        Me.Cancel_Button.TabIndex = 12
        Me.Cancel_Button.Text = "Cancel"
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
        Me.ImageCollection1.Images.SetKeyName(6, "Folder New1.ico")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "cancel_16x16.png")
        '
        'DailyPrice_import_btn
        '
        Me.DailyPrice_import_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DailyPrice_import_btn.ImageOptions.ImageIndex = 8
        Me.DailyPrice_import_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.DailyPrice_import_btn.Location = New System.Drawing.Point(12, 603)
        Me.DailyPrice_import_btn.Name = "DailyPrice_import_btn"
        Me.DailyPrice_import_btn.Size = New System.Drawing.Size(192, 22)
        Me.DailyPrice_import_btn.TabIndex = 12
        Me.DailyPrice_import_btn.Text = "Import Daily price"
        '
        'Securities_AddNewDailyPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1308, 633)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DailyPrice_import_btn)
        Me.Controls.Add(Me.Cancel_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "The Bezier"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.Name = "Securities_AddNewDailyPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Daily Price"
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LiquidityDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiquidityDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecuritiesDailyPriceBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SecuritiesDailyPriceBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISIN_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarket_Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPurchase_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractNrOCBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrincipalOrigAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LiquidityDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Cancel_Button As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DailyPrice_import_btn As DevExpress.XtraEditors.SimpleButton
End Class
