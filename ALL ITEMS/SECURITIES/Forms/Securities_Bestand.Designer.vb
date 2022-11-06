<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Securities_Bestand
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Securities_Bestand))
        Me.SecuritiesBestandDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBestandCreationDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBestandCreationDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBestandDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBestandDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colISIN_Code1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colISIN_Code1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSecurityName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSecurityName1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCcy1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCcy1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPrincipalEuroAmt1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPrincipalEuroAmt1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMaturityDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMaturityDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPurchase_price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPurchase_price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStartofYear_price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStartofYear_price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMarket_Price1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMarket_Price1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAmt_Paid1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAmt_Paid1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStartofYear_Amt1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStartofYear_Amt1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colValueAsOfDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colValueAsOfDate1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOCBS_Booked_Later1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOCBS_Booked_Later1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBuchwert1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBuchwert1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBuchwertAbgrenzungen1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBuchwertAbgrenzungen1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAenderungLfdJahr1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAenderungLfdJahr1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colKursReserve1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colKursReserve1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClientNr1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.SECURITIES_BESTANDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SECURITIESDataset = New PS_TOOL_DX.SECURITIESDataset()
        Me.SecuritiesBestandBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBestandCreationDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBestandDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colISIN_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSecurityName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrincipalEuroAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPurchase_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartofYear_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarket_Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmt_Paid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartofYear_Amt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueAsOfDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOCBS_Booked_Later = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBuchwert = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBuchwertAbgrenzungen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAenderungLfdJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKursReserve = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetsType = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.SECURITIES_BESTANDTableAdapter = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_BESTANDTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SecuritiesBestandReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CreateNewBestand_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.TillDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.BestandDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SecuritiesBestandDetailView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Securities_Bestand_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
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
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.SecuritiesBestandDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBestandCreationDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBestandDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colISIN_Code1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSecurityName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCcy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPrincipalEuroAmt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMaturityDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPurchase_price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStartofYear_price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMarket_Price1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAmt_Paid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStartofYear_Amt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colValueAsOfDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOCBS_Booked_Later1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBuchwert1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBuchwertAbgrenzungen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAenderungLfdJahr1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colKursReserve1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SECURITIES_BESTANDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecuritiesBestandBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestandDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestandDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SecuritiesBestandDetailView
        '
        Me.SecuritiesBestandDetailView.Appearance.FieldValue.ForeColor = System.Drawing.Color.Aqua
        Me.SecuritiesBestandDetailView.Appearance.FieldValue.Options.UseForeColor = True
        Me.SecuritiesBestandDetailView.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Navy
        Me.SecuritiesBestandDetailView.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.SecuritiesBestandDetailView.CardMinSize = New System.Drawing.Size(210, 480)
        Me.SecuritiesBestandDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colBestandCreationDate1, Me.colBestandDate1, Me.colISIN_Code1, Me.colSecurityName1, Me.colCcy1, Me.colPrincipalEuroAmt1, Me.colMaturityDate1, Me.colPurchase_price1, Me.colStartofYear_price1, Me.colMarket_Price1, Me.colAmt_Paid1, Me.colStartofYear_Amt1, Me.colValueAsOfDate1, Me.colOCBS_Booked_Later1, Me.colBuchwert1, Me.colBuchwertAbgrenzungen1, Me.colAenderungLfdJahr1, Me.colKursReserve1, Me.colClientNr1})
        Me.SecuritiesBestandDetailView.GridControl = Me.GridControl2
        Me.SecuritiesBestandDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1, Me.layoutViewField_colBestandCreationDate1})
        Me.SecuritiesBestandDetailView.Name = "SecuritiesBestandDetailView"
        Me.SecuritiesBestandDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.SecuritiesBestandDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.SecuritiesBestandDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.SecuritiesBestandDetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.SecuritiesBestandDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.SecuritiesBestandDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.SecuritiesBestandDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.SecuritiesBestandDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.SecuritiesBestandDetailView.OptionsCustomization.AllowFilter = False
        Me.SecuritiesBestandDetailView.OptionsCustomization.AllowSort = False
        Me.SecuritiesBestandDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.SecuritiesBestandDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.SecuritiesBestandDetailView.OptionsFilter.AllowFilterEditor = False
        Me.SecuritiesBestandDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.SecuritiesBestandDetailView.OptionsFind.AllowFindPanel = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.SecuritiesBestandDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.SecuritiesBestandDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.SecuritiesBestandDetailView.OptionsView.ShowHeaderPanel = False
        Me.SecuritiesBestandDetailView.TemplateCard = Me.LayoutViewCard1
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
        Me.layoutViewField_colID1.EditorPreferredWidth = 20
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(466, 442)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(122, 13)
        '
        'colBestandCreationDate1
        '
        Me.colBestandCreationDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colBestandCreationDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBestandCreationDate1.FieldName = "BestandCreationDate"
        Me.colBestandCreationDate1.LayoutViewField = Me.layoutViewField_colBestandCreationDate1
        Me.colBestandCreationDate1.Name = "colBestandCreationDate1"
        Me.colBestandCreationDate1.OptionsColumn.AllowEdit = False
        Me.colBestandCreationDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBestandCreationDate1
        '
        Me.layoutViewField_colBestandCreationDate1.EditorPreferredWidth = 20
        Me.layoutViewField_colBestandCreationDate1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBestandCreationDate1.Name = "layoutViewField_colBestandCreationDate1"
        Me.layoutViewField_colBestandCreationDate1.Size = New System.Drawing.Size(466, 442)
        Me.layoutViewField_colBestandCreationDate1.TextSize = New System.Drawing.Size(122, 13)
        '
        'colBestandDate1
        '
        Me.colBestandDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colBestandDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBestandDate1.FieldName = "BestandDate"
        Me.colBestandDate1.LayoutViewField = Me.layoutViewField_colBestandDate1
        Me.colBestandDate1.Name = "colBestandDate1"
        Me.colBestandDate1.OptionsColumn.AllowEdit = False
        Me.colBestandDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBestandDate1
        '
        Me.layoutViewField_colBestandDate1.EditorPreferredWidth = 256
        Me.layoutViewField_colBestandDate1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBestandDate1.Name = "layoutViewField_colBestandDate1"
        Me.layoutViewField_colBestandDate1.Size = New System.Drawing.Size(416, 24)
        Me.layoutViewField_colBestandDate1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colISIN_Code1
        '
        Me.colISIN_Code1.AppearanceCell.Options.UseTextOptions = True
        Me.colISIN_Code1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colISIN_Code1.Caption = "ISIN Code"
        Me.colISIN_Code1.FieldName = "ISIN_Code"
        Me.colISIN_Code1.LayoutViewField = Me.layoutViewField_colISIN_Code1
        Me.colISIN_Code1.Name = "colISIN_Code1"
        Me.colISIN_Code1.OptionsColumn.AllowEdit = False
        Me.colISIN_Code1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colISIN_Code1
        '
        Me.layoutViewField_colISIN_Code1.EditorPreferredWidth = 315
        Me.layoutViewField_colISIN_Code1.Location = New System.Drawing.Point(0, 24)
        Me.layoutViewField_colISIN_Code1.Name = "layoutViewField_colISIN_Code1"
        Me.layoutViewField_colISIN_Code1.Size = New System.Drawing.Size(475, 24)
        Me.layoutViewField_colISIN_Code1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colSecurityName1
        '
        Me.colSecurityName1.AppearanceCell.Options.UseTextOptions = True
        Me.colSecurityName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSecurityName1.FieldName = "SecurityName"
        Me.colSecurityName1.LayoutViewField = Me.layoutViewField_colSecurityName1
        Me.colSecurityName1.Name = "colSecurityName1"
        Me.colSecurityName1.OptionsColumn.AllowEdit = False
        Me.colSecurityName1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colSecurityName1
        '
        Me.layoutViewField_colSecurityName1.EditorPreferredWidth = 651
        Me.layoutViewField_colSecurityName1.Location = New System.Drawing.Point(0, 72)
        Me.layoutViewField_colSecurityName1.Name = "layoutViewField_colSecurityName1"
        Me.layoutViewField_colSecurityName1.Size = New System.Drawing.Size(811, 24)
        Me.layoutViewField_colSecurityName1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colCcy1
        '
        Me.colCcy1.AppearanceCell.Options.UseTextOptions = True
        Me.colCcy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCcy1.FieldName = "Ccy"
        Me.colCcy1.LayoutViewField = Me.layoutViewField_colCcy1
        Me.colCcy1.Name = "colCcy1"
        Me.colCcy1.OptionsColumn.AllowEdit = False
        Me.colCcy1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCcy1
        '
        Me.layoutViewField_colCcy1.EditorPreferredWidth = 160
        Me.layoutViewField_colCcy1.Location = New System.Drawing.Point(0, 96)
        Me.layoutViewField_colCcy1.Name = "layoutViewField_colCcy1"
        Me.layoutViewField_colCcy1.Size = New System.Drawing.Size(320, 24)
        Me.layoutViewField_colCcy1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colPrincipalEuroAmt1
        '
        Me.colPrincipalEuroAmt1.AppearanceCell.Options.UseTextOptions = True
        Me.colPrincipalEuroAmt1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colPrincipalEuroAmt1.Caption = "Principal Euro Amount"
        Me.colPrincipalEuroAmt1.DisplayFormat.FormatString = "n2"
        Me.colPrincipalEuroAmt1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipalEuroAmt1.FieldName = "PrincipalEuroAmt"
        Me.colPrincipalEuroAmt1.LayoutViewField = Me.layoutViewField_colPrincipalEuroAmt1
        Me.colPrincipalEuroAmt1.Name = "colPrincipalEuroAmt1"
        Me.colPrincipalEuroAmt1.OptionsColumn.AllowEdit = False
        Me.colPrincipalEuroAmt1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPrincipalEuroAmt1
        '
        Me.layoutViewField_colPrincipalEuroAmt1.EditorPreferredWidth = 308
        Me.layoutViewField_colPrincipalEuroAmt1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colPrincipalEuroAmt1.Name = "layoutViewField_colPrincipalEuroAmt1"
        Me.layoutViewField_colPrincipalEuroAmt1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colPrincipalEuroAmt1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colMaturityDate1
        '
        Me.colMaturityDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colMaturityDate1.FieldName = "MaturityDate"
        Me.colMaturityDate1.LayoutViewField = Me.layoutViewField_colMaturityDate1
        Me.colMaturityDate1.Name = "colMaturityDate1"
        Me.colMaturityDate1.OptionsColumn.AllowEdit = False
        Me.colMaturityDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colMaturityDate1
        '
        Me.layoutViewField_colMaturityDate1.EditorPreferredWidth = 231
        Me.layoutViewField_colMaturityDate1.Location = New System.Drawing.Point(0, 144)
        Me.layoutViewField_colMaturityDate1.Name = "layoutViewField_colMaturityDate1"
        Me.layoutViewField_colMaturityDate1.Size = New System.Drawing.Size(391, 24)
        Me.layoutViewField_colMaturityDate1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colPurchase_price1
        '
        Me.colPurchase_price1.AppearanceCell.Options.UseTextOptions = True
        Me.colPurchase_price1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colPurchase_price1.Caption = "Preis Einstand"
        Me.colPurchase_price1.DisplayFormat.FormatString = "n4"
        Me.colPurchase_price1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPurchase_price1.FieldName = "Purchase_price"
        Me.colPurchase_price1.LayoutViewField = Me.layoutViewField_colPurchase_price1
        Me.colPurchase_price1.Name = "colPurchase_price1"
        Me.colPurchase_price1.OptionsColumn.AllowEdit = False
        Me.colPurchase_price1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPurchase_price1
        '
        Me.layoutViewField_colPurchase_price1.EditorPreferredWidth = 231
        Me.layoutViewField_colPurchase_price1.Location = New System.Drawing.Point(0, 168)
        Me.layoutViewField_colPurchase_price1.Name = "layoutViewField_colPurchase_price1"
        Me.layoutViewField_colPurchase_price1.Size = New System.Drawing.Size(391, 24)
        Me.layoutViewField_colPurchase_price1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colStartofYear_price1
        '
        Me.colStartofYear_price1.AppearanceCell.Options.UseTextOptions = True
        Me.colStartofYear_price1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colStartofYear_price1.Caption = "Preis Jahresanfang"
        Me.colStartofYear_price1.DisplayFormat.FormatString = "n4"
        Me.colStartofYear_price1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStartofYear_price1.FieldName = "StartofYear_price"
        Me.colStartofYear_price1.LayoutViewField = Me.layoutViewField_colStartofYear_price1
        Me.colStartofYear_price1.Name = "colStartofYear_price1"
        Me.colStartofYear_price1.OptionsColumn.AllowEdit = False
        Me.colStartofYear_price1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colStartofYear_price1
        '
        Me.layoutViewField_colStartofYear_price1.EditorPreferredWidth = 231
        Me.layoutViewField_colStartofYear_price1.Location = New System.Drawing.Point(0, 192)
        Me.layoutViewField_colStartofYear_price1.Name = "layoutViewField_colStartofYear_price1"
        Me.layoutViewField_colStartofYear_price1.Size = New System.Drawing.Size(391, 24)
        Me.layoutViewField_colStartofYear_price1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colMarket_Price1
        '
        Me.colMarket_Price1.AppearanceCell.Options.UseTextOptions = True
        Me.colMarket_Price1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colMarket_Price1.Caption = "Preis Aktuell"
        Me.colMarket_Price1.DisplayFormat.FormatString = "n4"
        Me.colMarket_Price1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMarket_Price1.FieldName = "Market_Price"
        Me.colMarket_Price1.LayoutViewField = Me.layoutViewField_colMarket_Price1
        Me.colMarket_Price1.Name = "colMarket_Price1"
        Me.colMarket_Price1.OptionsColumn.AllowEdit = False
        Me.colMarket_Price1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colMarket_Price1
        '
        Me.layoutViewField_colMarket_Price1.EditorPreferredWidth = 231
        Me.layoutViewField_colMarket_Price1.Location = New System.Drawing.Point(0, 216)
        Me.layoutViewField_colMarket_Price1.Name = "layoutViewField_colMarket_Price1"
        Me.layoutViewField_colMarket_Price1.Size = New System.Drawing.Size(391, 24)
        Me.layoutViewField_colMarket_Price1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colAmt_Paid1
        '
        Me.colAmt_Paid1.AppearanceCell.Options.UseTextOptions = True
        Me.colAmt_Paid1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAmt_Paid1.Caption = "Einstandswert"
        Me.colAmt_Paid1.DisplayFormat.FormatString = "n2"
        Me.colAmt_Paid1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmt_Paid1.FieldName = "Amt_Paid"
        Me.colAmt_Paid1.LayoutViewField = Me.layoutViewField_colAmt_Paid1
        Me.colAmt_Paid1.Name = "colAmt_Paid1"
        Me.colAmt_Paid1.OptionsColumn.AllowEdit = False
        Me.colAmt_Paid1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAmt_Paid1
        '
        Me.layoutViewField_colAmt_Paid1.EditorPreferredWidth = 308
        Me.layoutViewField_colAmt_Paid1.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_colAmt_Paid1.Name = "layoutViewField_colAmt_Paid1"
        Me.layoutViewField_colAmt_Paid1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colAmt_Paid1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colStartofYear_Amt1
        '
        Me.colStartofYear_Amt1.AppearanceCell.Options.UseTextOptions = True
        Me.colStartofYear_Amt1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colStartofYear_Amt1.Caption = "Jahresanfangswert"
        Me.colStartofYear_Amt1.DisplayFormat.FormatString = "n2"
        Me.colStartofYear_Amt1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStartofYear_Amt1.FieldName = "StartofYear_Amt"
        Me.colStartofYear_Amt1.LayoutViewField = Me.layoutViewField_colStartofYear_Amt1
        Me.colStartofYear_Amt1.Name = "colStartofYear_Amt1"
        Me.colStartofYear_Amt1.OptionsColumn.AllowEdit = False
        Me.colStartofYear_Amt1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colStartofYear_Amt1
        '
        Me.layoutViewField_colStartofYear_Amt1.EditorPreferredWidth = 308
        Me.layoutViewField_colStartofYear_Amt1.Location = New System.Drawing.Point(0, 264)
        Me.layoutViewField_colStartofYear_Amt1.Name = "layoutViewField_colStartofYear_Amt1"
        Me.layoutViewField_colStartofYear_Amt1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colStartofYear_Amt1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colValueAsOfDate1
        '
        Me.colValueAsOfDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colValueAsOfDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colValueAsOfDate1.Caption = "Aktueller Wert"
        Me.colValueAsOfDate1.DisplayFormat.FormatString = "n2"
        Me.colValueAsOfDate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValueAsOfDate1.FieldName = "ValueAsOfDate"
        Me.colValueAsOfDate1.LayoutViewField = Me.layoutViewField_colValueAsOfDate1
        Me.colValueAsOfDate1.Name = "colValueAsOfDate1"
        Me.colValueAsOfDate1.OptionsColumn.AllowEdit = False
        Me.colValueAsOfDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colValueAsOfDate1
        '
        Me.layoutViewField_colValueAsOfDate1.EditorPreferredWidth = 308
        Me.layoutViewField_colValueAsOfDate1.Location = New System.Drawing.Point(0, 288)
        Me.layoutViewField_colValueAsOfDate1.Name = "layoutViewField_colValueAsOfDate1"
        Me.layoutViewField_colValueAsOfDate1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colValueAsOfDate1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colOCBS_Booked_Later1
        '
        Me.colOCBS_Booked_Later1.AppearanceCell.Options.UseTextOptions = True
        Me.colOCBS_Booked_Later1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colOCBS_Booked_Later1.Caption = "Gebuchte Abschrbg."
        Me.colOCBS_Booked_Later1.DisplayFormat.FormatString = "n2"
        Me.colOCBS_Booked_Later1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOCBS_Booked_Later1.FieldName = "OCBS_Booked_Later"
        Me.colOCBS_Booked_Later1.LayoutViewField = Me.layoutViewField_colOCBS_Booked_Later1
        Me.colOCBS_Booked_Later1.Name = "colOCBS_Booked_Later1"
        Me.colOCBS_Booked_Later1.OptionsColumn.AllowEdit = False
        Me.colOCBS_Booked_Later1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colOCBS_Booked_Later1
        '
        Me.layoutViewField_colOCBS_Booked_Later1.EditorPreferredWidth = 308
        Me.layoutViewField_colOCBS_Booked_Later1.Location = New System.Drawing.Point(0, 312)
        Me.layoutViewField_colOCBS_Booked_Later1.Name = "layoutViewField_colOCBS_Booked_Later1"
        Me.layoutViewField_colOCBS_Booked_Later1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colOCBS_Booked_Later1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colBuchwert1
        '
        Me.colBuchwert1.AppearanceCell.Options.UseTextOptions = True
        Me.colBuchwert1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBuchwert1.DisplayFormat.FormatString = "n2"
        Me.colBuchwert1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBuchwert1.FieldName = "Buchwert"
        Me.colBuchwert1.LayoutViewField = Me.layoutViewField_colBuchwert1
        Me.colBuchwert1.Name = "colBuchwert1"
        Me.colBuchwert1.OptionsColumn.AllowEdit = False
        Me.colBuchwert1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBuchwert1
        '
        Me.layoutViewField_colBuchwert1.EditorPreferredWidth = 308
        Me.layoutViewField_colBuchwert1.Location = New System.Drawing.Point(0, 336)
        Me.layoutViewField_colBuchwert1.Name = "layoutViewField_colBuchwert1"
        Me.layoutViewField_colBuchwert1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colBuchwert1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colBuchwertAbgrenzungen1
        '
        Me.colBuchwertAbgrenzungen1.AppearanceCell.Options.UseTextOptions = True
        Me.colBuchwertAbgrenzungen1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBuchwertAbgrenzungen1.Caption = "Buchwert + Zinsabgrenzungen"
        Me.colBuchwertAbgrenzungen1.DisplayFormat.FormatString = "n2"
        Me.colBuchwertAbgrenzungen1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBuchwertAbgrenzungen1.FieldName = "BuchwertAbgrenzungen"
        Me.colBuchwertAbgrenzungen1.LayoutViewField = Me.layoutViewField_colBuchwertAbgrenzungen1
        Me.colBuchwertAbgrenzungen1.Name = "colBuchwertAbgrenzungen1"
        Me.colBuchwertAbgrenzungen1.OptionsColumn.AllowEdit = False
        Me.colBuchwertAbgrenzungen1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBuchwertAbgrenzungen1
        '
        Me.layoutViewField_colBuchwertAbgrenzungen1.EditorPreferredWidth = 308
        Me.layoutViewField_colBuchwertAbgrenzungen1.Location = New System.Drawing.Point(0, 360)
        Me.layoutViewField_colBuchwertAbgrenzungen1.Name = "layoutViewField_colBuchwertAbgrenzungen1"
        Me.layoutViewField_colBuchwertAbgrenzungen1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colBuchwertAbgrenzungen1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colAenderungLfdJahr1
        '
        Me.colAenderungLfdJahr1.AppearanceCell.Options.UseTextOptions = True
        Me.colAenderungLfdJahr1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAenderungLfdJahr1.Caption = "Änderungs Lfd. Jahr"
        Me.colAenderungLfdJahr1.DisplayFormat.FormatString = "n2"
        Me.colAenderungLfdJahr1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAenderungLfdJahr1.FieldName = "AenderungLfdJahr"
        Me.colAenderungLfdJahr1.LayoutViewField = Me.layoutViewField_colAenderungLfdJahr1
        Me.colAenderungLfdJahr1.Name = "colAenderungLfdJahr1"
        Me.colAenderungLfdJahr1.OptionsColumn.AllowEdit = False
        Me.colAenderungLfdJahr1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAenderungLfdJahr1
        '
        Me.layoutViewField_colAenderungLfdJahr1.EditorPreferredWidth = 308
        Me.layoutViewField_colAenderungLfdJahr1.Location = New System.Drawing.Point(0, 384)
        Me.layoutViewField_colAenderungLfdJahr1.Name = "layoutViewField_colAenderungLfdJahr1"
        Me.layoutViewField_colAenderungLfdJahr1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colAenderungLfdJahr1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colKursReserve1
        '
        Me.colKursReserve1.AppearanceCell.Options.UseTextOptions = True
        Me.colKursReserve1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colKursReserve1.DisplayFormat.FormatString = "n2"
        Me.colKursReserve1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colKursReserve1.FieldName = "KursReserve"
        Me.colKursReserve1.LayoutViewField = Me.layoutViewField_colKursReserve1
        Me.colKursReserve1.Name = "colKursReserve1"
        Me.colKursReserve1.OptionsColumn.AllowEdit = False
        Me.colKursReserve1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colKursReserve1
        '
        Me.layoutViewField_colKursReserve1.EditorPreferredWidth = 308
        Me.layoutViewField_colKursReserve1.Location = New System.Drawing.Point(0, 408)
        Me.layoutViewField_colKursReserve1.Name = "layoutViewField_colKursReserve1"
        Me.layoutViewField_colKursReserve1.Size = New System.Drawing.Size(468, 24)
        Me.layoutViewField_colKursReserve1.TextSize = New System.Drawing.Size(151, 13)
        '
        'colClientNr1
        '
        Me.colClientNr1.Caption = "Client Nr."
        Me.colClientNr1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.colClientNr1.Name = "colClientNr1"
        Me.colClientNr1.OptionsColumn.AllowEdit = False
        Me.colClientNr1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 160
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 48)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(320, 24)
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(151, 13)
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.SECURITIES_BESTANDBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.SecuritiesBestandDetailView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(12, 109)
        Me.GridControl2.MainView = Me.SecuritiesBestandBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2})
        Me.GridControl2.Size = New System.Drawing.Size(1460, 610)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SecuritiesBestandBaseView, Me.GridView2, Me.SecuritiesBestandDetailView})
        '
        'SECURITIES_BESTANDBindingSource
        '
        Me.SECURITIES_BESTANDBindingSource.DataMember = "SECURITIES_BESTAND"
        Me.SECURITIES_BESTANDBindingSource.DataSource = Me.SECURITIESDataset
        '
        'SECURITIESDataset
        '
        Me.SECURITIESDataset.DataSetName = "SECURITIESDataset"
        Me.SECURITIESDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SecuritiesBestandBaseView
        '
        Me.SecuritiesBestandBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.SecuritiesBestandBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.SecuritiesBestandBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.SecuritiesBestandBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.SecuritiesBestandBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.SecuritiesBestandBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.SecuritiesBestandBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.SecuritiesBestandBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colBestandCreationDate, Me.colBestandDate, Me.colISIN_Code, Me.colClientNr, Me.colSecurityName, Me.colCcy, Me.colPrincipalEuroAmt, Me.colMaturityDate, Me.colPurchase_price, Me.colStartofYear_price, Me.colMarket_Price, Me.colAmt_Paid, Me.colStartofYear_Amt, Me.colValueAsOfDate, Me.colOCBS_Booked_Later, Me.colBuchwert, Me.colBuchwertAbgrenzungen, Me.colAenderungLfdJahr, Me.colKursReserve, Me.colAssetsType})
        Me.SecuritiesBestandBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SecuritiesBestandBaseView.GridControl = Me.GridControl2
        Me.SecuritiesBestandBaseView.GroupCount = 2
        Me.SecuritiesBestandBaseView.Name = "SecuritiesBestandBaseView"
        Me.SecuritiesBestandBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.SecuritiesBestandBaseView.OptionsCustomization.AllowRowSizing = True
        Me.SecuritiesBestandBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SecuritiesBestandBaseView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.SecuritiesBestandBaseView.OptionsFind.AlwaysVisible = True
        Me.SecuritiesBestandBaseView.OptionsSelection.MultiSelect = True
        Me.SecuritiesBestandBaseView.OptionsView.ColumnAutoWidth = False
        Me.SecuritiesBestandBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.SecuritiesBestandBaseView.OptionsView.ShowAutoFilterRow = True
        Me.SecuritiesBestandBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SecuritiesBestandBaseView.OptionsView.ShowFooter = True
        Me.SecuritiesBestandBaseView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colBestandDate, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colAssetsType, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colBestandCreationDate
        '
        Me.colBestandCreationDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBestandCreationDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBestandCreationDate.FieldName = "BestandCreationDate"
        Me.colBestandCreationDate.Name = "colBestandCreationDate"
        Me.colBestandCreationDate.OptionsColumn.AllowEdit = False
        Me.colBestandCreationDate.OptionsColumn.ReadOnly = True
        Me.colBestandCreationDate.Width = 115
        '
        'colBestandDate
        '
        Me.colBestandDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBestandDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBestandDate.FieldName = "BestandDate"
        Me.colBestandDate.Name = "colBestandDate"
        Me.colBestandDate.OptionsColumn.AllowEdit = False
        Me.colBestandDate.OptionsColumn.ReadOnly = True
        Me.colBestandDate.Visible = True
        Me.colBestandDate.VisibleIndex = 0
        Me.colBestandDate.Width = 80
        '
        'colISIN_Code
        '
        Me.colISIN_Code.Caption = "ISIN Code"
        Me.colISIN_Code.FieldName = "ISIN_Code"
        Me.colISIN_Code.Name = "colISIN_Code"
        Me.colISIN_Code.OptionsColumn.AllowEdit = False
        Me.colISIN_Code.OptionsColumn.ReadOnly = True
        Me.colISIN_Code.Visible = True
        Me.colISIN_Code.VisibleIndex = 0
        Me.colISIN_Code.Width = 135
        '
        'colClientNr
        '
        Me.colClientNr.Caption = "Client Nr."
        Me.colClientNr.FieldName = "ClientNr"
        Me.colClientNr.Name = "colClientNr"
        Me.colClientNr.OptionsColumn.AllowEdit = False
        Me.colClientNr.OptionsColumn.ReadOnly = True
        Me.colClientNr.Visible = True
        Me.colClientNr.VisibleIndex = 1
        Me.colClientNr.Width = 251
        '
        'colSecurityName
        '
        Me.colSecurityName.Caption = "Security Name"
        Me.colSecurityName.FieldName = "SecurityName"
        Me.colSecurityName.Name = "colSecurityName"
        Me.colSecurityName.OptionsColumn.AllowEdit = False
        Me.colSecurityName.OptionsColumn.ReadOnly = True
        Me.colSecurityName.Visible = True
        Me.colSecurityName.VisibleIndex = 2
        Me.colSecurityName.Width = 288
        '
        'colCcy
        '
        Me.colCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCcy.FieldName = "Ccy"
        Me.colCcy.Name = "colCcy"
        Me.colCcy.OptionsColumn.AllowEdit = False
        Me.colCcy.OptionsColumn.ReadOnly = True
        Me.colCcy.Visible = True
        Me.colCcy.VisibleIndex = 3
        Me.colCcy.Width = 33
        '
        'colPrincipalEuroAmt
        '
        Me.colPrincipalEuroAmt.AppearanceCell.Options.UseTextOptions = True
        Me.colPrincipalEuroAmt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPrincipalEuroAmt.Caption = "Nominalwert"
        Me.colPrincipalEuroAmt.DisplayFormat.FormatString = "n2"
        Me.colPrincipalEuroAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipalEuroAmt.FieldName = "PrincipalEuroAmt"
        Me.colPrincipalEuroAmt.Name = "colPrincipalEuroAmt"
        Me.colPrincipalEuroAmt.OptionsColumn.AllowEdit = False
        Me.colPrincipalEuroAmt.OptionsColumn.ReadOnly = True
        Me.colPrincipalEuroAmt.Visible = True
        Me.colPrincipalEuroAmt.VisibleIndex = 4
        Me.colPrincipalEuroAmt.Width = 104
        '
        'colMaturityDate
        '
        Me.colMaturityDate.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturityDate.Caption = "Fälligkeit"
        Me.colMaturityDate.FieldName = "MaturityDate"
        Me.colMaturityDate.Name = "colMaturityDate"
        Me.colMaturityDate.OptionsColumn.AllowEdit = False
        Me.colMaturityDate.OptionsColumn.ReadOnly = True
        Me.colMaturityDate.Visible = True
        Me.colMaturityDate.VisibleIndex = 5
        Me.colMaturityDate.Width = 99
        '
        'colPurchase_price
        '
        Me.colPurchase_price.AppearanceCell.Options.UseTextOptions = True
        Me.colPurchase_price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPurchase_price.Caption = "Preis Einstand"
        Me.colPurchase_price.DisplayFormat.FormatString = "n10"
        Me.colPurchase_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPurchase_price.FieldName = "Purchase_price"
        Me.colPurchase_price.Name = "colPurchase_price"
        Me.colPurchase_price.OptionsColumn.AllowEdit = False
        Me.colPurchase_price.OptionsColumn.ReadOnly = True
        Me.colPurchase_price.Visible = True
        Me.colPurchase_price.VisibleIndex = 6
        Me.colPurchase_price.Width = 85
        '
        'colStartofYear_price
        '
        Me.colStartofYear_price.AppearanceCell.Options.UseTextOptions = True
        Me.colStartofYear_price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colStartofYear_price.Caption = "Preis Jahresanfang"
        Me.colStartofYear_price.DisplayFormat.FormatString = "n10"
        Me.colStartofYear_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStartofYear_price.FieldName = "StartofYear_price"
        Me.colStartofYear_price.Name = "colStartofYear_price"
        Me.colStartofYear_price.OptionsColumn.AllowEdit = False
        Me.colStartofYear_price.OptionsColumn.ReadOnly = True
        Me.colStartofYear_price.Visible = True
        Me.colStartofYear_price.VisibleIndex = 7
        Me.colStartofYear_price.Width = 117
        '
        'colMarket_Price
        '
        Me.colMarket_Price.AppearanceCell.Options.UseTextOptions = True
        Me.colMarket_Price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colMarket_Price.Caption = "Preis Aktuell"
        Me.colMarket_Price.DisplayFormat.FormatString = "n4"
        Me.colMarket_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMarket_Price.FieldName = "Market_Price"
        Me.colMarket_Price.Name = "colMarket_Price"
        Me.colMarket_Price.OptionsColumn.AllowEdit = False
        Me.colMarket_Price.OptionsColumn.ReadOnly = True
        Me.colMarket_Price.Visible = True
        Me.colMarket_Price.VisibleIndex = 8
        Me.colMarket_Price.Width = 92
        '
        'colAmt_Paid
        '
        Me.colAmt_Paid.AppearanceCell.Options.UseTextOptions = True
        Me.colAmt_Paid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmt_Paid.Caption = "Einstandswert"
        Me.colAmt_Paid.DisplayFormat.FormatString = "n2"
        Me.colAmt_Paid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmt_Paid.FieldName = "Amt_Paid"
        Me.colAmt_Paid.Name = "colAmt_Paid"
        Me.colAmt_Paid.OptionsColumn.AllowEdit = False
        Me.colAmt_Paid.OptionsColumn.ReadOnly = True
        Me.colAmt_Paid.Visible = True
        Me.colAmt_Paid.VisibleIndex = 9
        Me.colAmt_Paid.Width = 97
        '
        'colStartofYear_Amt
        '
        Me.colStartofYear_Amt.AppearanceCell.Options.UseTextOptions = True
        Me.colStartofYear_Amt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colStartofYear_Amt.Caption = "Jahresanfangswert"
        Me.colStartofYear_Amt.DisplayFormat.FormatString = "n2"
        Me.colStartofYear_Amt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStartofYear_Amt.FieldName = "StartofYear_Amt"
        Me.colStartofYear_Amt.Name = "colStartofYear_Amt"
        Me.colStartofYear_Amt.OptionsColumn.AllowEdit = False
        Me.colStartofYear_Amt.OptionsColumn.ReadOnly = True
        Me.colStartofYear_Amt.Visible = True
        Me.colStartofYear_Amt.VisibleIndex = 10
        Me.colStartofYear_Amt.Width = 113
        '
        'colValueAsOfDate
        '
        Me.colValueAsOfDate.AppearanceCell.Options.UseTextOptions = True
        Me.colValueAsOfDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colValueAsOfDate.Caption = "Aktueller Wert"
        Me.colValueAsOfDate.DisplayFormat.FormatString = "n2"
        Me.colValueAsOfDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValueAsOfDate.FieldName = "ValueAsOfDate"
        Me.colValueAsOfDate.Name = "colValueAsOfDate"
        Me.colValueAsOfDate.OptionsColumn.AllowEdit = False
        Me.colValueAsOfDate.OptionsColumn.ReadOnly = True
        Me.colValueAsOfDate.Visible = True
        Me.colValueAsOfDate.VisibleIndex = 11
        Me.colValueAsOfDate.Width = 94
        '
        'colOCBS_Booked_Later
        '
        Me.colOCBS_Booked_Later.AppearanceCell.Options.UseTextOptions = True
        Me.colOCBS_Booked_Later.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOCBS_Booked_Later.Caption = "Gebuchte Abschreibungen"
        Me.colOCBS_Booked_Later.DisplayFormat.FormatString = "n2"
        Me.colOCBS_Booked_Later.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOCBS_Booked_Later.FieldName = "OCBS_Booked_Later"
        Me.colOCBS_Booked_Later.Name = "colOCBS_Booked_Later"
        Me.colOCBS_Booked_Later.OptionsColumn.AllowEdit = False
        Me.colOCBS_Booked_Later.OptionsColumn.ReadOnly = True
        Me.colOCBS_Booked_Later.Visible = True
        Me.colOCBS_Booked_Later.VisibleIndex = 12
        Me.colOCBS_Booked_Later.Width = 136
        '
        'colBuchwert
        '
        Me.colBuchwert.AppearanceCell.Options.UseTextOptions = True
        Me.colBuchwert.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colBuchwert.DisplayFormat.FormatString = "n2"
        Me.colBuchwert.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBuchwert.FieldName = "Buchwert"
        Me.colBuchwert.Name = "colBuchwert"
        Me.colBuchwert.OptionsColumn.AllowEdit = False
        Me.colBuchwert.OptionsColumn.ReadOnly = True
        Me.colBuchwert.Visible = True
        Me.colBuchwert.VisibleIndex = 13
        Me.colBuchwert.Width = 111
        '
        'colBuchwertAbgrenzungen
        '
        Me.colBuchwertAbgrenzungen.AppearanceCell.Options.UseTextOptions = True
        Me.colBuchwertAbgrenzungen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colBuchwertAbgrenzungen.Caption = "Buchwert+ Zinsabgrenzung"
        Me.colBuchwertAbgrenzungen.DisplayFormat.FormatString = "n2"
        Me.colBuchwertAbgrenzungen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBuchwertAbgrenzungen.FieldName = "BuchwertAbgrenzungen"
        Me.colBuchwertAbgrenzungen.Name = "colBuchwertAbgrenzungen"
        Me.colBuchwertAbgrenzungen.OptionsColumn.AllowEdit = False
        Me.colBuchwertAbgrenzungen.OptionsColumn.ReadOnly = True
        Me.colBuchwertAbgrenzungen.Visible = True
        Me.colBuchwertAbgrenzungen.VisibleIndex = 14
        Me.colBuchwertAbgrenzungen.Width = 155
        '
        'colAenderungLfdJahr
        '
        Me.colAenderungLfdJahr.AppearanceCell.Options.UseTextOptions = True
        Me.colAenderungLfdJahr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAenderungLfdJahr.Caption = "Änderung Lfd. Jahr"
        Me.colAenderungLfdJahr.DisplayFormat.FormatString = "n2"
        Me.colAenderungLfdJahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAenderungLfdJahr.FieldName = "AenderungLfdJahr"
        Me.colAenderungLfdJahr.Name = "colAenderungLfdJahr"
        Me.colAenderungLfdJahr.OptionsColumn.AllowEdit = False
        Me.colAenderungLfdJahr.OptionsColumn.ReadOnly = True
        Me.colAenderungLfdJahr.Visible = True
        Me.colAenderungLfdJahr.VisibleIndex = 15
        Me.colAenderungLfdJahr.Width = 126
        '
        'colKursReserve
        '
        Me.colKursReserve.AppearanceCell.Options.UseTextOptions = True
        Me.colKursReserve.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colKursReserve.Caption = "Kurs Reserve"
        Me.colKursReserve.DisplayFormat.FormatString = "n2"
        Me.colKursReserve.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colKursReserve.FieldName = "KursReserve"
        Me.colKursReserve.Name = "colKursReserve"
        Me.colKursReserve.OptionsColumn.AllowEdit = False
        Me.colKursReserve.OptionsColumn.ReadOnly = True
        Me.colKursReserve.Visible = True
        Me.colKursReserve.VisibleIndex = 16
        Me.colKursReserve.Width = 120
        '
        'colAssetsType
        '
        Me.colAssetsType.Caption = "Assets Type"
        Me.colAssetsType.FieldName = "AssetType"
        Me.colAssetsType.Name = "colAssetsType"
        Me.colAssetsType.Visible = True
        Me.colAssetsType.VisibleIndex = 16
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
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colBestandDate1, Me.layoutViewField_colISIN_Code1, Me.layoutViewField_colSecurityName1, Me.layoutViewField_colCcy1, Me.layoutViewField_colPrincipalEuroAmt1, Me.layoutViewField_colMaturityDate1, Me.layoutViewField_colPurchase_price1, Me.layoutViewField_colStartofYear_price1, Me.layoutViewField_colMarket_Price1, Me.layoutViewField_colAmt_Paid1, Me.layoutViewField_colStartofYear_Amt1, Me.layoutViewField_colValueAsOfDate1, Me.layoutViewField_colOCBS_Booked_Later1, Me.layoutViewField_colBuchwert1, Me.layoutViewField_colBuchwertAbgrenzungen1, Me.layoutViewField_colAenderungLfdJahr1, Me.layoutViewField_colKursReserve1, Me.item1, Me.item2, Me.item3, Me.item4, Me.item5, Me.item6, Me.item7, Me.item8, Me.item9, Me.item10, Me.item11, Me.item12, Me.item13, Me.item14, Me.item15, Me.item16, Me.item17, Me.item18, Me.layoutViewField_LayoutViewColumn1, Me.item19})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'item1
        '
        Me.item1.AllowHotTrack = False
        Me.item1.CustomizationFormText = "item1"
        Me.item1.Location = New System.Drawing.Point(416, 0)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(413, 24)
        Me.item1.TextSize = New System.Drawing.Size(0, 0)
        '
        'item2
        '
        Me.item2.AllowHotTrack = False
        Me.item2.CustomizationFormText = "item2"
        Me.item2.Location = New System.Drawing.Point(475, 24)
        Me.item2.Name = "item2"
        Me.item2.Size = New System.Drawing.Size(354, 24)
        Me.item2.TextSize = New System.Drawing.Size(0, 0)
        '
        'item3
        '
        Me.item3.AllowHotTrack = False
        Me.item3.CustomizationFormText = "item3"
        Me.item3.Location = New System.Drawing.Point(811, 48)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(18, 48)
        Me.item3.TextSize = New System.Drawing.Size(0, 0)
        '
        'item4
        '
        Me.item4.AllowHotTrack = False
        Me.item4.CustomizationFormText = "item4"
        Me.item4.Location = New System.Drawing.Point(320, 96)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(509, 24)
        Me.item4.TextSize = New System.Drawing.Size(0, 0)
        '
        'item5
        '
        Me.item5.AllowHotTrack = False
        Me.item5.CustomizationFormText = "item5"
        Me.item5.Location = New System.Drawing.Point(468, 120)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(361, 24)
        Me.item5.TextSize = New System.Drawing.Size(0, 0)
        '
        'item6
        '
        Me.item6.AllowHotTrack = False
        Me.item6.CustomizationFormText = "item6"
        Me.item6.Location = New System.Drawing.Point(391, 144)
        Me.item6.Name = "item6"
        Me.item6.Size = New System.Drawing.Size(438, 24)
        Me.item6.TextSize = New System.Drawing.Size(0, 0)
        '
        'item7
        '
        Me.item7.AllowHotTrack = False
        Me.item7.CustomizationFormText = "item7"
        Me.item7.Location = New System.Drawing.Point(391, 168)
        Me.item7.Name = "item7"
        Me.item7.Size = New System.Drawing.Size(438, 24)
        Me.item7.TextSize = New System.Drawing.Size(0, 0)
        '
        'item8
        '
        Me.item8.AllowHotTrack = False
        Me.item8.CustomizationFormText = "item8"
        Me.item8.Location = New System.Drawing.Point(391, 192)
        Me.item8.Name = "item8"
        Me.item8.Size = New System.Drawing.Size(438, 24)
        Me.item8.TextSize = New System.Drawing.Size(0, 0)
        '
        'item9
        '
        Me.item9.AllowHotTrack = False
        Me.item9.CustomizationFormText = "item9"
        Me.item9.Location = New System.Drawing.Point(391, 216)
        Me.item9.Name = "item9"
        Me.item9.Size = New System.Drawing.Size(438, 24)
        Me.item9.TextSize = New System.Drawing.Size(0, 0)
        '
        'item10
        '
        Me.item10.AllowHotTrack = False
        Me.item10.CustomizationFormText = "item10"
        Me.item10.Location = New System.Drawing.Point(468, 240)
        Me.item10.Name = "item10"
        Me.item10.Size = New System.Drawing.Size(361, 24)
        Me.item10.TextSize = New System.Drawing.Size(0, 0)
        '
        'item11
        '
        Me.item11.AllowHotTrack = False
        Me.item11.CustomizationFormText = "item11"
        Me.item11.Location = New System.Drawing.Point(468, 264)
        Me.item11.Name = "item11"
        Me.item11.Size = New System.Drawing.Size(361, 24)
        Me.item11.TextSize = New System.Drawing.Size(0, 0)
        '
        'item12
        '
        Me.item12.AllowHotTrack = False
        Me.item12.CustomizationFormText = "item12"
        Me.item12.Location = New System.Drawing.Point(468, 288)
        Me.item12.Name = "item12"
        Me.item12.Size = New System.Drawing.Size(361, 24)
        Me.item12.TextSize = New System.Drawing.Size(0, 0)
        '
        'item13
        '
        Me.item13.AllowHotTrack = False
        Me.item13.CustomizationFormText = "item13"
        Me.item13.Location = New System.Drawing.Point(468, 312)
        Me.item13.Name = "item13"
        Me.item13.Size = New System.Drawing.Size(361, 24)
        Me.item13.TextSize = New System.Drawing.Size(0, 0)
        '
        'item14
        '
        Me.item14.AllowHotTrack = False
        Me.item14.CustomizationFormText = "item14"
        Me.item14.Location = New System.Drawing.Point(468, 336)
        Me.item14.Name = "item14"
        Me.item14.Size = New System.Drawing.Size(361, 24)
        Me.item14.TextSize = New System.Drawing.Size(0, 0)
        '
        'item15
        '
        Me.item15.AllowHotTrack = False
        Me.item15.CustomizationFormText = "item15"
        Me.item15.Location = New System.Drawing.Point(468, 360)
        Me.item15.Name = "item15"
        Me.item15.Size = New System.Drawing.Size(361, 24)
        Me.item15.TextSize = New System.Drawing.Size(0, 0)
        '
        'item16
        '
        Me.item16.AllowHotTrack = False
        Me.item16.CustomizationFormText = "item16"
        Me.item16.Location = New System.Drawing.Point(468, 384)
        Me.item16.Name = "item16"
        Me.item16.Size = New System.Drawing.Size(361, 24)
        Me.item16.TextSize = New System.Drawing.Size(0, 0)
        '
        'item17
        '
        Me.item17.AllowHotTrack = False
        Me.item17.CustomizationFormText = "item17"
        Me.item17.Location = New System.Drawing.Point(0, 432)
        Me.item17.Name = "item17"
        Me.item17.Size = New System.Drawing.Size(829, 104)
        Me.item17.TextSize = New System.Drawing.Size(0, 0)
        '
        'item18
        '
        Me.item18.AllowHotTrack = False
        Me.item18.CustomizationFormText = "item18"
        Me.item18.Location = New System.Drawing.Point(468, 408)
        Me.item18.Name = "item18"
        Me.item18.Size = New System.Drawing.Size(361, 24)
        Me.item18.TextSize = New System.Drawing.Size(0, 0)
        '
        'item19
        '
        Me.item19.AllowHotTrack = False
        Me.item19.CustomizationFormText = "item19"
        Me.item19.Location = New System.Drawing.Point(320, 48)
        Me.item19.Name = "item19"
        Me.item19.Size = New System.Drawing.Size(491, 24)
        Me.item19.TextSize = New System.Drawing.Size(0, 0)
        '
        'SECURITIES_BESTANDTableAdapter
        '
        Me.SECURITIES_BESTANDTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.SECURITIES_BESTANDTableAdapter = Me.SECURITIES_BESTANDTableAdapter
        Me.TableAdapterManager.SECURITIES_BOOKINGSTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_DailyPriceTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_DEPRECIATIONSTableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_LIQUIDITYRESERVETableAdapter = Nothing
        Me.TableAdapterManager.SECURITIES_OURTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SecuritiesBestandReport_btn)
        Me.LayoutControl1.Controls.Add(Me.CreateNewBestand_btn)
        Me.LayoutControl1.Controls.Add(Me.TillDateEdit)
        Me.LayoutControl1.Controls.Add(Me.BestandDateEdit)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.SecuritiesBestandDetailView_btn)
        Me.LayoutControl1.Controls.Add(Me.Securities_Bestand_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem6})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(911, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1484, 731)
        Me.LayoutControl1.TabIndex = 7
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SecuritiesBestandReport_btn
        '
        Me.SecuritiesBestandReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SecuritiesBestandReport_btn.ImageOptions.ImageIndex = 5
        Me.SecuritiesBestandReport_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SecuritiesBestandReport_btn.Location = New System.Drawing.Point(128, 12)
        Me.SecuritiesBestandReport_btn.Name = "SecuritiesBestandReport_btn"
        Me.SecuritiesBestandReport_btn.Size = New System.Drawing.Size(197, 22)
        Me.SecuritiesBestandReport_btn.StyleController = Me.LayoutControl1
        Me.SecuritiesBestandReport_btn.TabIndex = 14
        Me.SecuritiesBestandReport_btn.Text = "Securities Bestand Report"
        Me.SecuritiesBestandReport_btn.ToolTip = "Creates the Securities report based on the Liquidity Date"
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
        Me.ImageCollection1.Images.SetKeyName(7, "New.ico")
        '
        'CreateNewBestand_btn
        '
        Me.CreateNewBestand_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CreateNewBestand_btn.ImageOptions.ImageIndex = 7
        Me.CreateNewBestand_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.CreateNewBestand_btn.Location = New System.Drawing.Point(615, 83)
        Me.CreateNewBestand_btn.Name = "CreateNewBestand_btn"
        Me.CreateNewBestand_btn.Size = New System.Drawing.Size(174, 22)
        Me.CreateNewBestand_btn.StyleController = Me.LayoutControl1
        Me.CreateNewBestand_btn.TabIndex = 8
        Me.CreateNewBestand_btn.Text = "Create New Bestand"
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
        'BestandDateEdit
        '
        Me.BestandDateEdit.EditValue = Nothing
        Me.BestandDateEdit.Location = New System.Drawing.Point(615, 54)
        Me.BestandDateEdit.Name = "BestandDateEdit"
        Me.BestandDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BestandDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BestandDateEdit.Properties.Appearance.Options.UseFont = True
        Me.BestandDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.BestandDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BestandDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BestandDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BestandDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BestandDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.BestandDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.BestandDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.BestandDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BestandDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BestandDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BestandDateEdit.Size = New System.Drawing.Size(174, 22)
        Me.BestandDateEdit.StyleController = Me.LayoutControl1
        Me.BestandDateEdit.TabIndex = 12
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
        'SecuritiesBestandDetailView_btn
        '
        Me.SecuritiesBestandDetailView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SecuritiesBestandDetailView_btn.ImageOptions.ImageIndex = 0
        Me.SecuritiesBestandDetailView_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SecuritiesBestandDetailView_btn.Location = New System.Drawing.Point(1328, 12)
        Me.SecuritiesBestandDetailView_btn.Name = "SecuritiesBestandDetailView_btn"
        Me.SecuritiesBestandDetailView_btn.Size = New System.Drawing.Size(144, 22)
        Me.SecuritiesBestandDetailView_btn.StyleController = Me.LayoutControl1
        Me.SecuritiesBestandDetailView_btn.TabIndex = 7
        Me.SecuritiesBestandDetailView_btn.Text = "View Details"
        '
        'Securities_Bestand_Print_Export_btn
        '
        Me.Securities_Bestand_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Securities_Bestand_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.Securities_Bestand_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Securities_Bestand_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.Securities_Bestand_Print_Export_btn.Name = "Securities_Bestand_Print_Export_btn"
        Me.Securities_Bestand_Print_Export_btn.Size = New System.Drawing.Size(112, 22)
        Me.Securities_Bestand_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.Securities_Bestand_Print_Export_btn.TabIndex = 9
        Me.Securities_Bestand_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.EmptySpaceItem8, Me.EmptySpaceItem9, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1484, 731)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(317, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(997, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Securities_Bestand_Print_Export_btn
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
        Me.LayoutControlItem3.Control = Me.SecuritiesBestandDetailView_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1316, 0)
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
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1314, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 97)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1464, 614)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.CustomizationFormText = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(781, 26)
        Me.EmptySpaceItem8.MinSize = New System.Drawing.Size(104, 24)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(683, 71)
        Me.EmptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.CustomizationFormText = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(603, 71)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem5.Control = Me.BestandDateEdit
        Me.LayoutControlItem5.CustomizationFormText = "Date from"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(603, 26)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(178, 45)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(178, 45)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(178, 45)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Date"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(23, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.CreateNewBestand_btn
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(603, 71)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.SecuritiesBestandReport_btn
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(116, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(201, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl2
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'Securities_Bestand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1484, 731)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Securities_Bestand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Securities-Bestand"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SecuritiesBestandDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBestandCreationDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBestandDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colISIN_Code1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSecurityName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCcy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPrincipalEuroAmt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMaturityDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPurchase_price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStartofYear_price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMarket_Price1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAmt_Paid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStartofYear_Amt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colValueAsOfDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOCBS_Booked_Later1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBuchwert1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBuchwertAbgrenzungen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAenderungLfdJahr1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colKursReserve1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SECURITIES_BESTANDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SECURITIESDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecuritiesBestandBaseView, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TillDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestandDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestandDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SECURITIESDataset As PS_TOOL_DX.SECURITIESDataset
    Friend WithEvents SECURITIES_BESTANDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SECURITIES_BESTANDTableAdapter As PS_TOOL_DX.SECURITIESDatasetTableAdapters.SECURITIES_BESTANDTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.SECURITIESDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SecuritiesBestandReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CreateNewBestand_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TillDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BestandDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents SecuritiesBestandDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents SecuritiesBestandBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SecuritiesBestandDetailView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Securities_Bestand_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBestandCreationDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBestandDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colISIN_Code1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSecurityName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCcy1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colPrincipalEuroAmt1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colMaturityDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colPurchase_price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStartofYear_price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colMarket_Price1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAmt_Paid1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStartofYear_Amt1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colValueAsOfDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colOCBS_Booked_Later1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBuchwert1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBuchwertAbgrenzungen1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAenderungLfdJahr1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colKursReserve1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBestandCreationDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBestandDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colISIN_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSecurityName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrincipalEuroAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPurchase_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartofYear_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarket_Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmt_Paid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartofYear_Amt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueAsOfDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOCBS_Booked_Later As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBuchwert As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBuchwertAbgrenzungen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAenderungLfdJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKursReserve As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetsType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBestandCreationDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBestandDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colISIN_Code1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSecurityName1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCcy1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colPrincipalEuroAmt1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colMaturityDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colPurchase_price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStartofYear_price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colMarket_Price1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAmt_Paid1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStartofYear_Amt1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colValueAsOfDate1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colOCBS_Booked_Later1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBuchwert1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBuchwertAbgrenzungen1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAenderungLfdJahr1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colKursReserve1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientNr1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientNr As DevExpress.XtraGrid.Columns.GridColumn
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
End Class
