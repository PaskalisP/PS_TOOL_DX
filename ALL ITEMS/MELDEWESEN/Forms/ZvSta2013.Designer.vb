<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZvSta2013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZvSta2013))
        Me.ZVSTA_Forms_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormSchema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFormSchemaName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdZVSTA_Meldejahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ZVSTATill2013BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MeldewesenDataSet = New PS_TOOL_DX.MeldewesenDataSet()
        Me.ZvStatistic_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZVSTAMeldeJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeldeJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBemerkungen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUSER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.T2DetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBIC111 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC111 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colADDRESSEE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colADDRESSEE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colADDRESSEE_NAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colADDRESSEE_NAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colACCOUNT_HOLDER1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colACCOUNT_HOLDER1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colACCOUNT_HOLDER_NAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colINSTITUTION_NAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colINSTITUTION_NAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCITY_HEADING1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCITY_HEADING1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSORTCODE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSORTCODE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMAIN_BIC_FLAG1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMAIN_BIC_FLAG1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTYPE_OF_CHANGE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTYPE_OF_CHANGE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colVALID_FROM1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALID_FROM1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colVALID_TILL1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALID_TILL1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPARTICIPATION_TYPE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPARTICIPATION_TYPE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPARTICIPATION_TYPE_NAME1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colRESERVE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRESERVE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.ZVSTA_Prod_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldposition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldeinheit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFelddim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldSQLcommand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldvalueRep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldSQLcommandSum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFeldmemo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdZVSTA_Forms = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZVSTATill2013TableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTATill2013TableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.TableAdapterManager()
        Me.ZVSTA_FormsTill2013TableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTA_FormsTill2013TableAdapter()
        Me.ZVSTA_ProdTill2013TableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTA_ProdTill2013TableAdapter()
        Me.ZVSTA_FormsTill2013BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZVSTA_ProdTill2013BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ZVSTA_Rep_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ZVSTA_Forms_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTATill2013BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeldewesenDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvStatistic_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2DetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colADDRESSEE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colADDRESSEE_NAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colACCOUNT_HOLDER1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colACCOUNT_HOLDER_NAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colINSTITUTION_NAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCITY_HEADING1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSORTCODE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMAIN_BIC_FLAG1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTYPE_OF_CHANGE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALID_FROM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALID_TILL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPARTICIPATION_TYPE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPARTICIPATION_TYPE_NAME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRESERVE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTA_Prod_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTA_FormsTill2013BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZVSTA_ProdTill2013BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ZVSTA_Forms_BasicView
        '
        Me.ZVSTA_Forms_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colFormSchema, Me.colFormSchemaName, Me.colIdZVSTA_Meldejahr})
        Me.ZVSTA_Forms_BasicView.GridControl = Me.GridControl2
        Me.ZVSTA_Forms_BasicView.Name = "ZVSTA_Forms_BasicView"
        Me.ZVSTA_Forms_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZVSTA_Forms_BasicView.OptionsPrint.PrintDetails = True
        Me.ZVSTA_Forms_BasicView.OptionsPrint.PrintFilterInfo = True
        Me.ZVSTA_Forms_BasicView.OptionsView.ColumnAutoWidth = False
        Me.ZVSTA_Forms_BasicView.ViewCaption = "ZVSTA Forms"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colFormSchema
        '
        Me.colFormSchema.FieldName = "FormSchema"
        Me.colFormSchema.Name = "colFormSchema"
        Me.colFormSchema.OptionsColumn.AllowEdit = False
        Me.colFormSchema.OptionsColumn.ReadOnly = True
        Me.colFormSchema.Visible = True
        Me.colFormSchema.VisibleIndex = 0
        Me.colFormSchema.Width = 111
        '
        'colFormSchemaName
        '
        Me.colFormSchemaName.FieldName = "FormSchemaName"
        Me.colFormSchemaName.Name = "colFormSchemaName"
        Me.colFormSchemaName.OptionsColumn.AllowEdit = False
        Me.colFormSchemaName.OptionsColumn.ReadOnly = True
        Me.colFormSchemaName.Visible = True
        Me.colFormSchemaName.VisibleIndex = 1
        Me.colFormSchemaName.Width = 815
        '
        'colIdZVSTA_Meldejahr
        '
        Me.colIdZVSTA_Meldejahr.FieldName = "IdZVSTA_Meldejahr"
        Me.colIdZVSTA_Meldejahr.Name = "colIdZVSTA_Meldejahr"
        Me.colIdZVSTA_Meldejahr.OptionsColumn.AllowEdit = False
        Me.colIdZVSTA_Meldejahr.OptionsColumn.ReadOnly = True
        Me.colIdZVSTA_Meldejahr.Width = 129
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.ZVSTATill2013BindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.ZVSTA_Forms_BasicView
        GridLevelNode2.LevelTemplate = Me.ZVSTA_Prod_BasicView
        GridLevelNode2.RelationName = "FK_ZVSTA_Prodtill2013_ZVSTA_Formstill2013"
        GridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        GridLevelNode1.RelationName = "FK_ZVSTA_Formstill2013_ZVSTAtill2013"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ZvStatistic_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit})
        Me.GridControl2.Size = New System.Drawing.Size(1364, 716)
        Me.GridControl2.TabIndex = 23
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ZvStatistic_BaseView, Me.T2DetailView, Me.ZVSTA_Prod_BasicView, Me.ZVSTA_Forms_BasicView})
        '
        'ZVSTATill2013BindingSource
        '
        Me.ZVSTATill2013BindingSource.DataMember = "ZVSTATill2013"
        Me.ZVSTATill2013BindingSource.DataSource = Me.MeldewesenDataSet
        '
        'MeldewesenDataSet
        '
        Me.MeldewesenDataSet.DataSetName = "MeldewesenDataSet"
        Me.MeldewesenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZvStatistic_BaseView
        '
        Me.ZvStatistic_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ZvStatistic_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ZvStatistic_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ZvStatistic_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ZvStatistic_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ZvStatistic_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colZVSTAMeldeJahr, Me.colMeldeJahr, Me.colBemerkungen, Me.colUSER, Me.colIdBank})
        Me.ZvStatistic_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ZvStatistic_BaseView.GridControl = Me.GridControl2
        Me.ZvStatistic_BaseView.Name = "ZvStatistic_BaseView"
        Me.ZvStatistic_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZvStatistic_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ZvStatistic_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.ZvStatistic_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZvStatistic_BaseView.OptionsFind.AlwaysVisible = True
        Me.ZvStatistic_BaseView.OptionsPrint.PrintDetails = True
        Me.ZvStatistic_BaseView.OptionsPrint.PrintFilterInfo = True
        Me.ZvStatistic_BaseView.OptionsSelection.MultiSelect = True
        Me.ZvStatistic_BaseView.OptionsView.ColumnAutoWidth = False
        Me.ZvStatistic_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ZvStatistic_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.ZvStatistic_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ZvStatistic_BaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colZVSTAMeldeJahr
        '
        Me.colZVSTAMeldeJahr.FieldName = "ZVSTAMeldeJahr"
        Me.colZVSTAMeldeJahr.Name = "colZVSTAMeldeJahr"
        Me.colZVSTAMeldeJahr.OptionsColumn.AllowEdit = False
        Me.colZVSTAMeldeJahr.OptionsColumn.ReadOnly = True
        Me.colZVSTAMeldeJahr.Width = 113
        '
        'colMeldeJahr
        '
        Me.colMeldeJahr.FieldName = "MeldeJahr"
        Me.colMeldeJahr.Name = "colMeldeJahr"
        Me.colMeldeJahr.OptionsColumn.AllowEdit = False
        Me.colMeldeJahr.OptionsColumn.ReadOnly = True
        Me.colMeldeJahr.Visible = True
        Me.colMeldeJahr.VisibleIndex = 0
        Me.colMeldeJahr.Width = 101
        '
        'colBemerkungen
        '
        Me.colBemerkungen.FieldName = "Bemerkungen"
        Me.colBemerkungen.Name = "colBemerkungen"
        Me.colBemerkungen.OptionsColumn.AllowEdit = False
        Me.colBemerkungen.OptionsColumn.ReadOnly = True
        '
        'colUSER
        '
        Me.colUSER.FieldName = "USER"
        Me.colUSER.Name = "colUSER"
        Me.colUSER.OptionsColumn.AllowEdit = False
        Me.colUSER.OptionsColumn.ReadOnly = True
        '
        'colIdBank
        '
        Me.colIdBank.FieldName = "IdBank"
        Me.colIdBank.Name = "colIdBank"
        Me.colIdBank.OptionsColumn.AllowEdit = False
        Me.colIdBank.OptionsColumn.ReadOnly = True
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
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.Images.SetKeyName(7, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(8, "CrystalReport.jpg")
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Mask.EditMask = "[A-Z0-9]+"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'BICCODERepositoryItemTextEdit
        '
        Me.BICCODERepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BICCODERepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AutoHeight = False
        Me.BICCODERepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BICCODERepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BICCODERepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.BICCODERepositoryItemTextEdit.Mask.EditMask = "([A-Z]){6}([0-9A-Z]){2}([0-9A-Z]{3})"
        Me.BICCODERepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.BICCODERepositoryItemTextEdit.Name = "BICCODERepositoryItemTextEdit"
        '
        'T2DetailView
        '
        Me.T2DetailView.CardMinSize = New System.Drawing.Size(951, 573)
        Me.T2DetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colBIC111, Me.colADDRESSEE1, Me.colADDRESSEE_NAME1, Me.colACCOUNT_HOLDER1, Me.colACCOUNT_HOLDER_NAME1, Me.colINSTITUTION_NAME1, Me.colCITY_HEADING1, Me.colSORTCODE1, Me.colMAIN_BIC_FLAG1, Me.colTYPE_OF_CHANGE1, Me.colVALID_FROM1, Me.colVALID_TILL1, Me.colPARTICIPATION_TYPE1, Me.colPARTICIPATION_TYPE_NAME1, Me.colRESERVE1})
        Me.T2DetailView.GridControl = Me.GridControl2
        Me.T2DetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.T2DetailView.Name = "T2DetailView"
        Me.T2DetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.T2DetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.T2DetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.T2DetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.T2DetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.T2DetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.T2DetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.T2DetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.T2DetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.T2DetailView.OptionsCustomization.AllowFilter = False
        Me.T2DetailView.OptionsCustomization.AllowSort = False
        Me.T2DetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.T2DetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.T2DetailView.OptionsFilter.AllowFilterEditor = False
        Me.T2DetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.T2DetailView.OptionsFind.AllowFindPanel = False
        Me.T2DetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.T2DetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.T2DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.T2DetailView.OptionsView.ShowHeaderPanel = False
        Me.T2DetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = 20
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(177, 320)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colBIC111
        '
        Me.colBIC111.AppearanceCell.ForeColor = System.Drawing.Color.Yellow
        Me.colBIC111.AppearanceCell.Options.UseForeColor = True
        Me.colBIC111.Caption = "Participant BIC"
        Me.colBIC111.ColumnEdit = Me.BICCODERepositoryItemTextEdit
        Me.colBIC111.FieldName = "BIC11"
        Me.colBIC111.LayoutViewField = Me.layoutViewField_colBIC111
        Me.colBIC111.Name = "colBIC111"
        Me.colBIC111.OptionsColumn.AllowEdit = False
        Me.colBIC111.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBIC111
        '
        Me.layoutViewField_colBIC111.EditorPreferredWidth = 102
        Me.layoutViewField_colBIC111.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBIC111.Name = "layoutViewField_colBIC111"
        Me.layoutViewField_colBIC111.Size = New System.Drawing.Size(231, 20)
        Me.layoutViewField_colBIC111.TextSize = New System.Drawing.Size(120, 13)
        '
        'colADDRESSEE1
        '
        Me.colADDRESSEE1.AppearanceCell.ForeColor = System.Drawing.Color.Aqua
        Me.colADDRESSEE1.AppearanceCell.Options.UseForeColor = True
        Me.colADDRESSEE1.Caption = "Addressee BIC"
        Me.colADDRESSEE1.ColumnEdit = Me.BICCODERepositoryItemTextEdit
        Me.colADDRESSEE1.FieldName = "ADDRESSEE"
        Me.colADDRESSEE1.LayoutViewField = Me.layoutViewField_colADDRESSEE1
        Me.colADDRESSEE1.Name = "colADDRESSEE1"
        '
        'layoutViewField_colADDRESSEE1
        '
        Me.layoutViewField_colADDRESSEE1.EditorPreferredWidth = 102
        Me.layoutViewField_colADDRESSEE1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colADDRESSEE1.Name = "layoutViewField_colADDRESSEE1"
        Me.layoutViewField_colADDRESSEE1.Size = New System.Drawing.Size(231, 20)
        Me.layoutViewField_colADDRESSEE1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colADDRESSEE_NAME1
        '
        Me.colADDRESSEE_NAME1.Caption = "Addressee Name"
        Me.colADDRESSEE_NAME1.FieldName = "ADDRESSEE_NAME"
        Me.colADDRESSEE_NAME1.LayoutViewField = Me.layoutViewField_colADDRESSEE_NAME1
        Me.colADDRESSEE_NAME1.Name = "colADDRESSEE_NAME1"
        Me.colADDRESSEE_NAME1.OptionsColumn.AllowEdit = False
        Me.colADDRESSEE_NAME1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colADDRESSEE_NAME1
        '
        Me.layoutViewField_colADDRESSEE_NAME1.EditorPreferredWidth = 802
        Me.layoutViewField_colADDRESSEE_NAME1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colADDRESSEE_NAME1.Name = "layoutViewField_colADDRESSEE_NAME1"
        Me.layoutViewField_colADDRESSEE_NAME1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colADDRESSEE_NAME1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colACCOUNT_HOLDER1
        '
        Me.colACCOUNT_HOLDER1.AppearanceCell.ForeColor = System.Drawing.Color.Aqua
        Me.colACCOUNT_HOLDER1.AppearanceCell.Options.UseForeColor = True
        Me.colACCOUNT_HOLDER1.Caption = "Account Holder BIC"
        Me.colACCOUNT_HOLDER1.ColumnEdit = Me.BICCODERepositoryItemTextEdit
        Me.colACCOUNT_HOLDER1.FieldName = "ACCOUNT_HOLDER"
        Me.colACCOUNT_HOLDER1.LayoutViewField = Me.layoutViewField_colACCOUNT_HOLDER1
        Me.colACCOUNT_HOLDER1.Name = "colACCOUNT_HOLDER1"
        '
        'layoutViewField_colACCOUNT_HOLDER1
        '
        Me.layoutViewField_colACCOUNT_HOLDER1.EditorPreferredWidth = 102
        Me.layoutViewField_colACCOUNT_HOLDER1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colACCOUNT_HOLDER1.Name = "layoutViewField_colACCOUNT_HOLDER1"
        Me.layoutViewField_colACCOUNT_HOLDER1.Size = New System.Drawing.Size(231, 20)
        Me.layoutViewField_colACCOUNT_HOLDER1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colACCOUNT_HOLDER_NAME1
        '
        Me.colACCOUNT_HOLDER_NAME1.Caption = "Account Holder Name"
        Me.colACCOUNT_HOLDER_NAME1.FieldName = "ACCOUNT_HOLDER_NAME"
        Me.colACCOUNT_HOLDER_NAME1.LayoutViewField = Me.layoutViewField_colACCOUNT_HOLDER_NAME1
        Me.colACCOUNT_HOLDER_NAME1.Name = "colACCOUNT_HOLDER_NAME1"
        Me.colACCOUNT_HOLDER_NAME1.OptionsColumn.AllowEdit = False
        Me.colACCOUNT_HOLDER_NAME1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colACCOUNT_HOLDER_NAME1
        '
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1.EditorPreferredWidth = 802
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1.Name = "layoutViewField_colACCOUNT_HOLDER_NAME1"
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colACCOUNT_HOLDER_NAME1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colINSTITUTION_NAME1
        '
        Me.colINSTITUTION_NAME1.AppearanceCell.ForeColor = System.Drawing.Color.Yellow
        Me.colINSTITUTION_NAME1.AppearanceCell.Options.UseForeColor = True
        Me.colINSTITUTION_NAME1.Caption = "Participant Name"
        Me.colINSTITUTION_NAME1.FieldName = "INSTITUTION_NAME"
        Me.colINSTITUTION_NAME1.LayoutViewField = Me.layoutViewField_colINSTITUTION_NAME1
        Me.colINSTITUTION_NAME1.Name = "colINSTITUTION_NAME1"
        Me.colINSTITUTION_NAME1.OptionsColumn.AllowEdit = False
        Me.colINSTITUTION_NAME1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colINSTITUTION_NAME1
        '
        Me.layoutViewField_colINSTITUTION_NAME1.EditorPreferredWidth = 802
        Me.layoutViewField_colINSTITUTION_NAME1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colINSTITUTION_NAME1.Name = "layoutViewField_colINSTITUTION_NAME1"
        Me.layoutViewField_colINSTITUTION_NAME1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colINSTITUTION_NAME1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colCITY_HEADING1
        '
        Me.colCITY_HEADING1.Caption = "City Heading"
        Me.colCITY_HEADING1.FieldName = "CITY_HEADING"
        Me.colCITY_HEADING1.LayoutViewField = Me.layoutViewField_colCITY_HEADING1
        Me.colCITY_HEADING1.Name = "colCITY_HEADING1"
        Me.colCITY_HEADING1.OptionsColumn.AllowEdit = False
        Me.colCITY_HEADING1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCITY_HEADING1
        '
        Me.layoutViewField_colCITY_HEADING1.EditorPreferredWidth = 802
        Me.layoutViewField_colCITY_HEADING1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colCITY_HEADING1.Name = "layoutViewField_colCITY_HEADING1"
        Me.layoutViewField_colCITY_HEADING1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colCITY_HEADING1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colSORTCODE1
        '
        Me.colSORTCODE1.Caption = "Sort Code"
        Me.colSORTCODE1.FieldName = "SORTCODE"
        Me.colSORTCODE1.LayoutViewField = Me.layoutViewField_colSORTCODE1
        Me.colSORTCODE1.Name = "colSORTCODE1"
        Me.colSORTCODE1.OptionsColumn.AllowEdit = False
        Me.colSORTCODE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colSORTCODE1
        '
        Me.layoutViewField_colSORTCODE1.EditorPreferredWidth = 802
        Me.layoutViewField_colSORTCODE1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colSORTCODE1.Name = "layoutViewField_colSORTCODE1"
        Me.layoutViewField_colSORTCODE1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colSORTCODE1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colMAIN_BIC_FLAG1
        '
        Me.colMAIN_BIC_FLAG1.Caption = "Main BIC Flag"
        Me.colMAIN_BIC_FLAG1.FieldName = "MAIN_BIC_FLAG"
        Me.colMAIN_BIC_FLAG1.LayoutViewField = Me.layoutViewField_colMAIN_BIC_FLAG1
        Me.colMAIN_BIC_FLAG1.Name = "colMAIN_BIC_FLAG1"
        Me.colMAIN_BIC_FLAG1.OptionsColumn.AllowEdit = False
        Me.colMAIN_BIC_FLAG1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colMAIN_BIC_FLAG1
        '
        Me.layoutViewField_colMAIN_BIC_FLAG1.EditorPreferredWidth = 802
        Me.layoutViewField_colMAIN_BIC_FLAG1.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colMAIN_BIC_FLAG1.Name = "layoutViewField_colMAIN_BIC_FLAG1"
        Me.layoutViewField_colMAIN_BIC_FLAG1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colMAIN_BIC_FLAG1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colTYPE_OF_CHANGE1
        '
        Me.colTYPE_OF_CHANGE1.Caption = "Type of Change"
        Me.colTYPE_OF_CHANGE1.FieldName = "TYPE_OF_CHANGE"
        Me.colTYPE_OF_CHANGE1.LayoutViewField = Me.layoutViewField_colTYPE_OF_CHANGE1
        Me.colTYPE_OF_CHANGE1.Name = "colTYPE_OF_CHANGE1"
        Me.colTYPE_OF_CHANGE1.OptionsColumn.AllowEdit = False
        Me.colTYPE_OF_CHANGE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colTYPE_OF_CHANGE1
        '
        Me.layoutViewField_colTYPE_OF_CHANGE1.EditorPreferredWidth = 802
        Me.layoutViewField_colTYPE_OF_CHANGE1.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colTYPE_OF_CHANGE1.Name = "layoutViewField_colTYPE_OF_CHANGE1"
        Me.layoutViewField_colTYPE_OF_CHANGE1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colTYPE_OF_CHANGE1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colVALID_FROM1
        '
        Me.colVALID_FROM1.Caption = "Valid from"
        Me.colVALID_FROM1.FieldName = "VALID_FROM"
        Me.colVALID_FROM1.LayoutViewField = Me.layoutViewField_colVALID_FROM1
        Me.colVALID_FROM1.Name = "colVALID_FROM1"
        Me.colVALID_FROM1.OptionsColumn.AllowEdit = False
        Me.colVALID_FROM1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colVALID_FROM1
        '
        Me.layoutViewField_colVALID_FROM1.EditorPreferredWidth = 802
        Me.layoutViewField_colVALID_FROM1.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colVALID_FROM1.Name = "layoutViewField_colVALID_FROM1"
        Me.layoutViewField_colVALID_FROM1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colVALID_FROM1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colVALID_TILL1
        '
        Me.colVALID_TILL1.Caption = "Valid Till"
        Me.colVALID_TILL1.FieldName = "VALID_TILL"
        Me.colVALID_TILL1.LayoutViewField = Me.layoutViewField_colVALID_TILL1
        Me.colVALID_TILL1.Name = "colVALID_TILL1"
        '
        'layoutViewField_colVALID_TILL1
        '
        Me.layoutViewField_colVALID_TILL1.EditorPreferredWidth = 802
        Me.layoutViewField_colVALID_TILL1.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_colVALID_TILL1.Name = "layoutViewField_colVALID_TILL1"
        Me.layoutViewField_colVALID_TILL1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colVALID_TILL1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colPARTICIPATION_TYPE1
        '
        Me.colPARTICIPATION_TYPE1.Caption = "Participation Type"
        Me.colPARTICIPATION_TYPE1.FieldName = "PARTICIPATION_TYPE"
        Me.colPARTICIPATION_TYPE1.LayoutViewField = Me.layoutViewField_colPARTICIPATION_TYPE1
        Me.colPARTICIPATION_TYPE1.Name = "colPARTICIPATION_TYPE1"
        Me.colPARTICIPATION_TYPE1.OptionsColumn.AllowEdit = False
        Me.colPARTICIPATION_TYPE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPARTICIPATION_TYPE1
        '
        Me.layoutViewField_colPARTICIPATION_TYPE1.EditorPreferredWidth = 802
        Me.layoutViewField_colPARTICIPATION_TYPE1.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_colPARTICIPATION_TYPE1.Name = "layoutViewField_colPARTICIPATION_TYPE1"
        Me.layoutViewField_colPARTICIPATION_TYPE1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colPARTICIPATION_TYPE1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colPARTICIPATION_TYPE_NAME1
        '
        Me.colPARTICIPATION_TYPE_NAME1.Caption = "Participation Type Name"
        Me.colPARTICIPATION_TYPE_NAME1.FieldName = "PARTICIPATION_TYPE_NAME"
        Me.colPARTICIPATION_TYPE_NAME1.LayoutViewField = Me.layoutViewField_colPARTICIPATION_TYPE_NAME1
        Me.colPARTICIPATION_TYPE_NAME1.Name = "colPARTICIPATION_TYPE_NAME1"
        Me.colPARTICIPATION_TYPE_NAME1.OptionsColumn.AllowEdit = False
        Me.colPARTICIPATION_TYPE_NAME1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPARTICIPATION_TYPE_NAME1
        '
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1.EditorPreferredWidth = 802
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1.Location = New System.Drawing.Point(0, 260)
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1.Name = "layoutViewField_colPARTICIPATION_TYPE_NAME1"
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colPARTICIPATION_TYPE_NAME1.TextSize = New System.Drawing.Size(120, 13)
        '
        'colRESERVE1
        '
        Me.colRESERVE1.Caption = "Reserve"
        Me.colRESERVE1.FieldName = "RESERVE"
        Me.colRESERVE1.LayoutViewField = Me.layoutViewField_colRESERVE1
        Me.colRESERVE1.Name = "colRESERVE1"
        Me.colRESERVE1.OptionsColumn.AllowEdit = False
        Me.colRESERVE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colRESERVE1
        '
        Me.layoutViewField_colRESERVE1.EditorPreferredWidth = 802
        Me.layoutViewField_colRESERVE1.Location = New System.Drawing.Point(0, 280)
        Me.layoutViewField_colRESERVE1.Name = "layoutViewField_colRESERVE1"
        Me.layoutViewField_colRESERVE1.Size = New System.Drawing.Size(931, 20)
        Me.layoutViewField_colRESERVE1.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colBIC111, Me.layoutViewField_colADDRESSEE1, Me.layoutViewField_colADDRESSEE_NAME1, Me.layoutViewField_colACCOUNT_HOLDER1, Me.layoutViewField_colACCOUNT_HOLDER_NAME1, Me.layoutViewField_colSORTCODE1, Me.layoutViewField_colMAIN_BIC_FLAG1, Me.layoutViewField_colTYPE_OF_CHANGE1, Me.layoutViewField_colVALID_FROM1, Me.layoutViewField_colVALID_TILL1, Me.layoutViewField_colPARTICIPATION_TYPE1, Me.layoutViewField_colPARTICIPATION_TYPE_NAME1, Me.layoutViewField_colRESERVE1, Me.layoutViewField_colINSTITUTION_NAME1, Me.layoutViewField_colCITY_HEADING1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'ZVSTA_Prod_BasicView
        '
        Me.ZVSTA_Prod_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID3, Me.colFeldname, Me.colFeldposition, Me.colFeldeinheit, Me.colFelddim, Me.colFeldvalue, Me.colFeldSQLcommand, Me.colFeldvalueRep, Me.colFeldSQLcommandSum, Me.colFeldmemo, Me.colIdZVSTA_Forms})
        Me.ZVSTA_Prod_BasicView.GridControl = Me.GridControl2
        Me.ZVSTA_Prod_BasicView.Name = "ZVSTA_Prod_BasicView"
        Me.ZVSTA_Prod_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ZVSTA_Prod_BasicView.OptionsPrint.PrintDetails = True
        Me.ZVSTA_Prod_BasicView.OptionsPrint.PrintFilterInfo = True
        Me.ZVSTA_Prod_BasicView.OptionsView.ColumnAutoWidth = False
        Me.ZVSTA_Prod_BasicView.ViewCaption = "ZVSTA Daten"
        '
        'colID3
        '
        Me.colID3.FieldName = "ID"
        Me.colID3.Name = "colID3"
        Me.colID3.OptionsColumn.AllowEdit = False
        Me.colID3.OptionsColumn.ReadOnly = True
        '
        'colFeldname
        '
        Me.colFeldname.FieldName = "Feldname"
        Me.colFeldname.Name = "colFeldname"
        Me.colFeldname.OptionsColumn.AllowEdit = False
        Me.colFeldname.OptionsColumn.ReadOnly = True
        Me.colFeldname.Visible = True
        Me.colFeldname.VisibleIndex = 0
        Me.colFeldname.Width = 430
        '
        'colFeldposition
        '
        Me.colFeldposition.FieldName = "Feldposition"
        Me.colFeldposition.Name = "colFeldposition"
        Me.colFeldposition.OptionsColumn.AllowEdit = False
        Me.colFeldposition.OptionsColumn.ReadOnly = True
        Me.colFeldposition.Visible = True
        Me.colFeldposition.VisibleIndex = 1
        Me.colFeldposition.Width = 94
        '
        'colFeldeinheit
        '
        Me.colFeldeinheit.FieldName = "Feldeinheit"
        Me.colFeldeinheit.Name = "colFeldeinheit"
        Me.colFeldeinheit.OptionsColumn.AllowEdit = False
        Me.colFeldeinheit.OptionsColumn.ReadOnly = True
        Me.colFeldeinheit.Visible = True
        Me.colFeldeinheit.VisibleIndex = 2
        Me.colFeldeinheit.Width = 83
        '
        'colFelddim
        '
        Me.colFelddim.FieldName = "Felddim"
        Me.colFelddim.Name = "colFelddim"
        Me.colFelddim.OptionsColumn.AllowEdit = False
        Me.colFelddim.OptionsColumn.ReadOnly = True
        Me.colFelddim.Visible = True
        Me.colFelddim.VisibleIndex = 3
        '
        'colFeldvalue
        '
        Me.colFeldvalue.AppearanceCell.Options.UseTextOptions = True
        Me.colFeldvalue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colFeldvalue.DisplayFormat.FormatString = "n2"
        Me.colFeldvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colFeldvalue.FieldName = "Feldvalue"
        Me.colFeldvalue.Name = "colFeldvalue"
        Me.colFeldvalue.OptionsColumn.AllowEdit = False
        Me.colFeldvalue.OptionsColumn.ReadOnly = True
        Me.colFeldvalue.Visible = True
        Me.colFeldvalue.VisibleIndex = 4
        Me.colFeldvalue.Width = 140
        '
        'colFeldSQLcommand
        '
        Me.colFeldSQLcommand.FieldName = "FeldSQLcommand"
        Me.colFeldSQLcommand.Name = "colFeldSQLcommand"
        Me.colFeldSQLcommand.OptionsColumn.AllowEdit = False
        Me.colFeldSQLcommand.OptionsColumn.ReadOnly = True
        Me.colFeldSQLcommand.Width = 105
        '
        'colFeldvalueRep
        '
        Me.colFeldvalueRep.AppearanceCell.Options.UseTextOptions = True
        Me.colFeldvalueRep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colFeldvalueRep.DisplayFormat.FormatString = "n0"
        Me.colFeldvalueRep.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colFeldvalueRep.FieldName = "FeldvalueRep"
        Me.colFeldvalueRep.Name = "colFeldvalueRep"
        Me.colFeldvalueRep.OptionsColumn.AllowEdit = False
        Me.colFeldvalueRep.OptionsColumn.ReadOnly = True
        Me.colFeldvalueRep.Visible = True
        Me.colFeldvalueRep.VisibleIndex = 5
        Me.colFeldvalueRep.Width = 108
        '
        'colFeldSQLcommandSum
        '
        Me.colFeldSQLcommandSum.FieldName = "FeldSQLcommandSum"
        Me.colFeldSQLcommandSum.Name = "colFeldSQLcommandSum"
        Me.colFeldSQLcommandSum.OptionsColumn.AllowEdit = False
        Me.colFeldSQLcommandSum.OptionsColumn.ReadOnly = True
        Me.colFeldSQLcommandSum.Width = 154
        '
        'colFeldmemo
        '
        Me.colFeldmemo.FieldName = "Feldmemo"
        Me.colFeldmemo.Name = "colFeldmemo"
        Me.colFeldmemo.OptionsColumn.AllowEdit = False
        Me.colFeldmemo.OptionsColumn.ReadOnly = True
        Me.colFeldmemo.Width = 106
        '
        'colIdZVSTA_Forms
        '
        Me.colIdZVSTA_Forms.FieldName = "IdZVSTA_Forms"
        Me.colIdZVSTA_Forms.Name = "colIdZVSTA_Forms"
        Me.colIdZVSTA_Forms.OptionsColumn.AllowEdit = False
        Me.colIdZVSTA_Forms.OptionsColumn.ReadOnly = True
        Me.colIdZVSTA_Forms.Width = 116
        '
        'ZVSTATill2013TableAdapter
        '
        Me.ZVSTATill2013TableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AWVz10POSTENTableAdapter = Nothing
        Me.TableAdapterManager.AWVz11POSTENTableAdapter = Nothing
        Me.TableAdapterManager.AWVz1415RelevantDataTableAdapter = Nothing
        Me.TableAdapterManager.AWVz14TableAdapter = Nothing
        Me.TableAdapterManager.AWVz14z15TableAdapter = Nothing
        Me.TableAdapterManager.AWVz15TableAdapter = Nothing
        Me.TableAdapterManager.AWVz4DIKAPPOSTENTableAdapter = Nothing
        Me.TableAdapterManager.AWVz4DIRINVPOSTENTableAdapter = Nothing
        Me.TableAdapterManager.AWVz4TRANSITPOSTENTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.EMPLOYES_YEAR_AVERAGETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.MeldewesenDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_JAHRTableAdapter = Nothing
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_MONATTableAdapter = Nothing
        Me.TableAdapterManager.ZVSTA_FormsTill2013TableAdapter = Me.ZVSTA_FormsTill2013TableAdapter
        Me.TableAdapterManager.ZVSTA_ProdTill2013TableAdapter = Me.ZVSTA_ProdTill2013TableAdapter
        Me.TableAdapterManager.ZVSTAT_Details_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_MeldeJahr_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Meldepositionen_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Meldeschemas_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Parameters_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTATill2013TableAdapter = Me.ZVSTATill2013TableAdapter
        '
        'ZVSTA_FormsTill2013TableAdapter
        '
        Me.ZVSTA_FormsTill2013TableAdapter.ClearBeforeFill = True
        '
        'ZVSTA_ProdTill2013TableAdapter
        '
        Me.ZVSTA_ProdTill2013TableAdapter.ClearBeforeFill = True
        '
        'ZVSTA_FormsTill2013BindingSource
        '
        Me.ZVSTA_FormsTill2013BindingSource.DataMember = "FK_ZVSTA_Formstill2013_ZVSTAtill2013"
        Me.ZVSTA_FormsTill2013BindingSource.DataSource = Me.ZVSTATill2013BindingSource
        '
        'ZVSTA_ProdTill2013BindingSource
        '
        Me.ZVSTA_ProdTill2013BindingSource.DataMember = "FK_ZVSTA_Prodtill2013_ZVSTA_Formstill2013"
        Me.ZVSTA_ProdTill2013BindingSource.DataSource = Me.ZVSTA_FormsTill2013BindingSource
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ZVSTA_Rep_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1388, 766)
        Me.LayoutControl1.TabIndex = 6
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ZVSTA_Rep_btn
        '
        Me.ZVSTA_Rep_btn.ImageIndex = 8
        Me.ZVSTA_Rep_btn.ImageList = Me.ImageCollection1
        Me.ZVSTA_Rep_btn.Location = New System.Drawing.Point(166, 12)
        Me.ZVSTA_Rep_btn.Name = "ZVSTA_Rep_btn"
        Me.ZVSTA_Rep_btn.Size = New System.Drawing.Size(242, 22)
        Me.ZVSTA_Rep_btn.StyleController = Me.LayoutControl1
        Me.ZVSTA_Rep_btn.TabIndex = 24
        Me.ZVSTA_Rep_btn.Text = "ZV STATISTIC Analysis Report"
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
        'Print_Export_btn
        '
        Me.Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_btn.ImageIndex = 2
        Me.Print_Export_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Print_Export_btn.Name = "Print_Export_btn"
        Me.Print_Export_btn.Size = New System.Drawing.Size(150, 22)
        Me.Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_btn.TabIndex = 20
        Me.Print_Export_btn.Text = "Print or Export"
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
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1388, 766)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(829, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(411, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(154, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(400, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(429, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1240, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(128, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1368, 720)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ZVSTA_Rep_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(154, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(246, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'ZvSta2013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1388, 766)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ZvSta2013"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ZV-STATISTIC till 2013"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ZVSTA_Forms_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTATill2013BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeldewesenDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvStatistic_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2DetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colADDRESSEE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colADDRESSEE_NAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colACCOUNT_HOLDER1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colACCOUNT_HOLDER_NAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colINSTITUTION_NAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCITY_HEADING1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSORTCODE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMAIN_BIC_FLAG1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTYPE_OF_CHANGE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALID_FROM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALID_TILL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPARTICIPATION_TYPE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPARTICIPATION_TYPE_NAME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRESERVE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTA_Prod_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTA_FormsTill2013BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZVSTA_ProdTill2013BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MeldewesenDataSet As PS_TOOL_DX.MeldewesenDataSet
    Friend WithEvents ZVSTATill2013BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZVSTATill2013TableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTATill2013TableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.MeldewesenDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ZVSTA_FormsTill2013TableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTA_FormsTill2013TableAdapter
    Friend WithEvents ZVSTA_FormsTill2013BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZVSTA_ProdTill2013TableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZVSTA_ProdTill2013TableAdapter
    Friend WithEvents ZVSTA_ProdTill2013BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ZvStatistic_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZVSTAMeldeJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeldeJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBemerkungen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUSER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BICCODERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents T2DetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colBIC111 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC111 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colADDRESSEE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colADDRESSEE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colADDRESSEE_NAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colADDRESSEE_NAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colACCOUNT_HOLDER1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colACCOUNT_HOLDER1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colACCOUNT_HOLDER_NAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colACCOUNT_HOLDER_NAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colINSTITUTION_NAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colINSTITUTION_NAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCITY_HEADING1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCITY_HEADING1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSORTCODE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSORTCODE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMAIN_BIC_FLAG1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMAIN_BIC_FLAG1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colTYPE_OF_CHANGE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colTYPE_OF_CHANGE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colVALID_FROM1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALID_FROM1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colVALID_TILL1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALID_TILL1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPARTICIPATION_TYPE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPARTICIPATION_TYPE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPARTICIPATION_TYPE_NAME1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPARTICIPATION_TYPE_NAME1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRESERVE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRESERVE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZVSTA_Forms_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormSchema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFormSchemaName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdZVSTA_Meldejahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZVSTA_Prod_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldposition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldeinheit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFelddim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldvalue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldSQLcommand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldvalueRep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldSQLcommandSum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFeldmemo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdZVSTA_Forms As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZVSTA_Rep_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
