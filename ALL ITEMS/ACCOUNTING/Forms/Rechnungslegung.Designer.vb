<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rechnungslegung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rechnungslegung))
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Rechnungslegung_AdvBandedGridView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colClientNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colClient_Name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colClientType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colZahlungsart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colArt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colBILANZ_POSITION = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colAccountNr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTaeglichFaelligAcc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPrincipal_Täglich_Faellig = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrincipal_till_3M = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrincipal_over_3M_till_1Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrincipal_over_1Y_till_5Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrincipal_over_5Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTOTAL_PRINCIPAL_EUR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colInterest_Täglich_Faellig = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colInterest_till_3M = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colInterest_over_3M_till_1Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colInterest_over_1Y_till_5Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colInterest_over_5Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTOTAL_INTEREST_EUR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colTäglich_Faellig_TOTAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTill_3M_TOTAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colOver_3M_Till_1Y_TOTAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colOver_1Y_Till_5Y = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colOver_5Y_TOTAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCCB_Group = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCCB_Group_OwnID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.RepositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.LayoutView4 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn76 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField52 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn77 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField53 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn78 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField54 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn79 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField55 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn80 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField56 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn81 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField57 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn82 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField58 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn83 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField59 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn84 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField60 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn85 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField61 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn86 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField62 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn87 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField63 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn88 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField64 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn89 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField65 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn90 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField66 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn91 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField67 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn92 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField68 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn93 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField69 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn94 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField70 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn95 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField71 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn96 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField72 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn97 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField73 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn98 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField74 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn99 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField75 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn100 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField76 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Load_LCR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LCR_Date_Comboedit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rechnungslegung_AdvBandedGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField76, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LCR_Date_Comboedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl4
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl4
        '
        Me.GridControl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl4.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Neues Inventar einfügen", "AddNewInventar")})
        Me.GridControl4.Location = New System.Drawing.Point(24, 68)
        Me.GridControl4.MainView = Me.Rechnungslegung_AdvBandedGridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox4, Me.RepositoryItemTextEdit7, Me.RepositoryItemTextEdit8, Me.RepositoryItemTextEdit9, Me.RepositoryItemMemoExEdit4, Me.RepositoryItemImageComboBox3})
        Me.GridControl4.Size = New System.Drawing.Size(1461, 639)
        Me.GridControl4.TabIndex = 129
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Rechnungslegung_AdvBandedGridView, Me.LayoutView4})
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
        Me.ImageCollection1.Images.SetKeyName(8, "Calculator.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("exporttoxlsx_16x16.png", "images/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxlsx_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "exporttoxlsx_16x16.png")
        '
        'Rechnungslegung_AdvBandedGridView
        '
        Me.Rechnungslegung_AdvBandedGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Rechnungslegung_AdvBandedGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Rechnungslegung_AdvBandedGridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Rechnungslegung_AdvBandedGridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Rechnungslegung_AdvBandedGridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Aqua
        Me.Rechnungslegung_AdvBandedGridView.Appearance.GroupFooter.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Rechnungslegung_AdvBandedGridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.Row.Options.UseBackColor = True
        Me.Rechnungslegung_AdvBandedGridView.AppearancePrint.Row.Options.UseForeColor = True
        Me.Rechnungslegung_AdvBandedGridView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand3, Me.gridBand2, Me.gridBand4})
        Me.Rechnungslegung_AdvBandedGridView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colArt, Me.colZahlungsart, Me.colClientNo, Me.colClientType, Me.colClient_Name, Me.colBILANZ_POSITION, Me.colAccountNr, Me.colTaeglichFaelligAcc, Me.colPrincipal_Täglich_Faellig, Me.colPrincipal_till_3M, Me.colPrincipal_over_3M_till_1Y, Me.colPrincipal_over_1Y_till_5Y, Me.colPrincipal_over_5Y, Me.colTOTAL_PRINCIPAL_EUR, Me.colInterest_Täglich_Faellig, Me.colInterest_till_3M, Me.colInterest_over_3M_till_1Y, Me.colInterest_over_1Y_till_5Y, Me.colInterest_over_5Y, Me.colTOTAL_INTEREST_EUR, Me.colTäglich_Faellig_TOTAL, Me.colTill_3M_TOTAL, Me.colOver_3M_Till_1Y_TOTAL, Me.colOver_1Y_Till_5Y, Me.colOver_5Y_TOTAL, Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST, Me.colCCB_Group, Me.colCCB_Group_OwnID})
        Me.Rechnungslegung_AdvBandedGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Rechnungslegung_AdvBandedGridView.GridControl = Me.GridControl4
        Me.Rechnungslegung_AdvBandedGridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Meldebetrag", Nothing, "Sum ={0:c2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Meldebetrag", Me.colPrincipal_over_3M_till_1Y, "Sum ={0:n2}")})
        Me.Rechnungslegung_AdvBandedGridView.Name = "Rechnungslegung_AdvBandedGridView"
        Me.Rechnungslegung_AdvBandedGridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsCustomization.AllowRowSizing = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Rechnungslegung_AdvBandedGridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.Rechnungslegung_AdvBandedGridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsFind.AlwaysVisible = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsFind.SearchInPreview = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsLayout.StoreAllOptions = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsLayout.StoreAppearance = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.Rechnungslegung_AdvBandedGridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Rechnungslegung_AdvBandedGridView.OptionsSelection.MultiSelect = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.ShowAutoFilterRow = True
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Rechnungslegung_AdvBandedGridView.OptionsView.ShowFooter = True
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.GridBand1.AppearanceHeader.Options.UseForeColor = True
        Me.GridBand1.Caption = "Customer - Contract basic data"
        Me.GridBand1.Columns.Add(Me.colClientNo)
        Me.GridBand1.Columns.Add(Me.colClient_Name)
        Me.GridBand1.Columns.Add(Me.colClientType)
        Me.GridBand1.Columns.Add(Me.colZahlungsart)
        Me.GridBand1.Columns.Add(Me.colArt)
        Me.GridBand1.Columns.Add(Me.colBILANZ_POSITION)
        Me.GridBand1.Columns.Add(Me.colAccountNr)
        Me.GridBand1.Columns.Add(Me.colTaeglichFaelligAcc)
        Me.GridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 1308
        '
        'colClientNo
        '
        Me.colClientNo.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colClientNo.AppearanceHeader.Options.UseForeColor = True
        Me.colClientNo.Caption = "ClientNo"
        Me.colClientNo.FieldName = "ClientNo"
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.Width = 185
        '
        'colClient_Name
        '
        Me.colClient_Name.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colClient_Name.AppearanceHeader.Options.UseForeColor = True
        Me.colClient_Name.Caption = "Client Name"
        Me.colClient_Name.FieldName = "Client Name"
        Me.colClient_Name.Name = "colClient_Name"
        Me.colClient_Name.OptionsColumn.AllowEdit = False
        Me.colClient_Name.OptionsColumn.ReadOnly = True
        Me.colClient_Name.Visible = True
        Me.colClient_Name.Width = 275
        '
        'colClientType
        '
        Me.colClientType.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colClientType.AppearanceHeader.Options.UseForeColor = True
        Me.colClientType.Caption = "Client Type"
        Me.colClientType.FieldName = "ClientType"
        Me.colClientType.Name = "colClientType"
        Me.colClientType.OptionsColumn.AllowEdit = False
        Me.colClientType.OptionsColumn.ReadOnly = True
        Me.colClientType.Visible = True
        Me.colClientType.Width = 87
        '
        'colZahlungsart
        '
        Me.colZahlungsart.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colZahlungsart.AppearanceHeader.Options.UseForeColor = True
        Me.colZahlungsart.Caption = "Zahlungsart"
        Me.colZahlungsart.FieldName = "Zahlungsart"
        Me.colZahlungsart.Name = "colZahlungsart"
        Me.colZahlungsart.OptionsColumn.AllowEdit = False
        Me.colZahlungsart.OptionsColumn.ReadOnly = True
        Me.colZahlungsart.Visible = True
        Me.colZahlungsart.Width = 254
        '
        'colArt
        '
        Me.colArt.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colArt.AppearanceHeader.Options.UseForeColor = True
        Me.colArt.Caption = "Art"
        Me.colArt.FieldName = "Art"
        Me.colArt.Name = "colArt"
        Me.colArt.OptionsColumn.AllowEdit = False
        Me.colArt.OptionsColumn.ReadOnly = True
        Me.colArt.Visible = True
        Me.colArt.Width = 248
        '
        'colBILANZ_POSITION
        '
        Me.colBILANZ_POSITION.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colBILANZ_POSITION.AppearanceHeader.Options.UseForeColor = True
        Me.colBILANZ_POSITION.Caption = "Balanceposition"
        Me.colBILANZ_POSITION.FieldName = "BILANZ POSITION"
        Me.colBILANZ_POSITION.Name = "colBILANZ_POSITION"
        Me.colBILANZ_POSITION.OptionsColumn.AllowEdit = False
        Me.colBILANZ_POSITION.OptionsColumn.ReadOnly = True
        Me.colBILANZ_POSITION.Visible = True
        Me.colBILANZ_POSITION.Width = 92
        '
        'colAccountNr
        '
        Me.colAccountNr.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colAccountNr.AppearanceHeader.Options.UseForeColor = True
        Me.colAccountNr.Caption = "Account Nr."
        Me.colAccountNr.FieldName = "Account Nr."
        Me.colAccountNr.Name = "colAccountNr"
        Me.colAccountNr.OptionsColumn.AllowEdit = False
        Me.colAccountNr.OptionsColumn.ReadOnly = True
        Me.colAccountNr.Visible = True
        Me.colAccountNr.Width = 89
        '
        'colTaeglichFaelligAcc
        '
        Me.colTaeglichFaelligAcc.AppearanceCell.Options.UseTextOptions = True
        Me.colTaeglichFaelligAcc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTaeglichFaelligAcc.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colTaeglichFaelligAcc.AppearanceHeader.Options.UseForeColor = True
        Me.colTaeglichFaelligAcc.Caption = "Account (due on demand)"
        Me.colTaeglichFaelligAcc.DisplayFormat.FormatString = "n2"
        Me.colTaeglichFaelligAcc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTaeglichFaelligAcc.FieldName = "TaeglichFaelligAcc"
        Me.colTaeglichFaelligAcc.Name = "colTaeglichFaelligAcc"
        Me.colTaeglichFaelligAcc.OptionsColumn.AllowEdit = False
        Me.colTaeglichFaelligAcc.OptionsColumn.ReadOnly = True
        Me.colTaeglichFaelligAcc.Visible = True
        Me.colTaeglichFaelligAcc.Width = 78
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.gridBand3.AppearanceHeader.Options.UseForeColor = True
        Me.gridBand3.Caption = "Principal"
        Me.gridBand3.Columns.Add(Me.colPrincipal_Täglich_Faellig)
        Me.gridBand3.Columns.Add(Me.colPrincipal_till_3M)
        Me.gridBand3.Columns.Add(Me.colPrincipal_over_3M_till_1Y)
        Me.gridBand3.Columns.Add(Me.colPrincipal_over_1Y_till_5Y)
        Me.gridBand3.Columns.Add(Me.colPrincipal_over_5Y)
        Me.gridBand3.Columns.Add(Me.colTOTAL_PRINCIPAL_EUR)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 496
        '
        'colPrincipal_Täglich_Faellig
        '
        Me.colPrincipal_Täglich_Faellig.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colPrincipal_Täglich_Faellig.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipal_Täglich_Faellig.Caption = "Principal (due on demand)"
        Me.colPrincipal_Täglich_Faellig.DisplayFormat.FormatString = "n2"
        Me.colPrincipal_Täglich_Faellig.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipal_Täglich_Faellig.FieldName = "Principal_Täglich_Faellig"
        Me.colPrincipal_Täglich_Faellig.Name = "colPrincipal_Täglich_Faellig"
        Me.colPrincipal_Täglich_Faellig.OptionsColumn.AllowEdit = False
        Me.colPrincipal_Täglich_Faellig.OptionsColumn.ReadOnly = True
        Me.colPrincipal_Täglich_Faellig.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal_Täglich_Faellig", "Sum={0:n2}")})
        Me.colPrincipal_Täglich_Faellig.Visible = True
        Me.colPrincipal_Täglich_Faellig.Width = 95
        '
        'colPrincipal_till_3M
        '
        Me.colPrincipal_till_3M.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colPrincipal_till_3M.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipal_till_3M.Caption = "Principal (till 3 Months)"
        Me.colPrincipal_till_3M.DisplayFormat.FormatString = "n2"
        Me.colPrincipal_till_3M.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipal_till_3M.FieldName = "Principal_till_3M"
        Me.colPrincipal_till_3M.Name = "colPrincipal_till_3M"
        Me.colPrincipal_till_3M.OptionsColumn.AllowEdit = False
        Me.colPrincipal_till_3M.OptionsColumn.ReadOnly = True
        Me.colPrincipal_till_3M.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal_till_3M", "Sum={0:n2}")})
        Me.colPrincipal_till_3M.Visible = True
        Me.colPrincipal_till_3M.Width = 83
        '
        'colPrincipal_over_3M_till_1Y
        '
        Me.colPrincipal_over_3M_till_1Y.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colPrincipal_over_3M_till_1Y.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipal_over_3M_till_1Y.Caption = "Principal (over 3M till 1Y)"
        Me.colPrincipal_over_3M_till_1Y.DisplayFormat.FormatString = "n2"
        Me.colPrincipal_over_3M_till_1Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipal_over_3M_till_1Y.FieldName = "Principal_over_3M_till_1Y"
        Me.colPrincipal_over_3M_till_1Y.Name = "colPrincipal_over_3M_till_1Y"
        Me.colPrincipal_over_3M_till_1Y.OptionsColumn.AllowEdit = False
        Me.colPrincipal_over_3M_till_1Y.OptionsColumn.ReadOnly = True
        Me.colPrincipal_over_3M_till_1Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal_over_3M_till_1Y", "Sum={0:n2}")})
        Me.colPrincipal_over_3M_till_1Y.Visible = True
        Me.colPrincipal_over_3M_till_1Y.Width = 93
        '
        'colPrincipal_over_1Y_till_5Y
        '
        Me.colPrincipal_over_1Y_till_5Y.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colPrincipal_over_1Y_till_5Y.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipal_over_1Y_till_5Y.Caption = "Principal (over 1Y till 5Y)"
        Me.colPrincipal_over_1Y_till_5Y.DisplayFormat.FormatString = "n2"
        Me.colPrincipal_over_1Y_till_5Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipal_over_1Y_till_5Y.FieldName = "Principal_over_1Y_till_5Y"
        Me.colPrincipal_over_1Y_till_5Y.Name = "colPrincipal_over_1Y_till_5Y"
        Me.colPrincipal_over_1Y_till_5Y.OptionsColumn.AllowEdit = False
        Me.colPrincipal_over_1Y_till_5Y.OptionsColumn.ReadOnly = True
        Me.colPrincipal_over_1Y_till_5Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal_over_1Y_till_5Y", "Sum={0:n2}")})
        Me.colPrincipal_over_1Y_till_5Y.Visible = True
        '
        'colPrincipal_over_5Y
        '
        Me.colPrincipal_over_5Y.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colPrincipal_over_5Y.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipal_over_5Y.Caption = "Principal (over 5Y)"
        Me.colPrincipal_over_5Y.DisplayFormat.FormatString = "n2"
        Me.colPrincipal_over_5Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipal_over_5Y.FieldName = "Principal_over_5Y"
        Me.colPrincipal_over_5Y.Name = "colPrincipal_over_5Y"
        Me.colPrincipal_over_5Y.OptionsColumn.AllowEdit = False
        Me.colPrincipal_over_5Y.OptionsColumn.ReadOnly = True
        Me.colPrincipal_over_5Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal_over_5Y", "Sum={0:n2}")})
        Me.colPrincipal_over_5Y.Visible = True
        '
        'colTOTAL_PRINCIPAL_EUR
        '
        Me.colTOTAL_PRINCIPAL_EUR.AppearanceHeader.ForeColor = System.Drawing.Color.Yellow
        Me.colTOTAL_PRINCIPAL_EUR.AppearanceHeader.Options.UseForeColor = True
        Me.colTOTAL_PRINCIPAL_EUR.Caption = "Principal (TOTAL)"
        Me.colTOTAL_PRINCIPAL_EUR.DisplayFormat.FormatString = "n2"
        Me.colTOTAL_PRINCIPAL_EUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTOTAL_PRINCIPAL_EUR.FieldName = "TOTAL_PRINCIPAL_EUR"
        Me.colTOTAL_PRINCIPAL_EUR.Name = "colTOTAL_PRINCIPAL_EUR"
        Me.colTOTAL_PRINCIPAL_EUR.OptionsColumn.AllowEdit = False
        Me.colTOTAL_PRINCIPAL_EUR.OptionsColumn.ReadOnly = True
        Me.colTOTAL_PRINCIPAL_EUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_PRINCIPAL_EUR", "Sum={0:n2}")})
        Me.colTOTAL_PRINCIPAL_EUR.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridBand2.AppearanceHeader.Options.UseForeColor = True
        Me.gridBand2.Caption = "Interests"
        Me.gridBand2.Columns.Add(Me.colInterest_Täglich_Faellig)
        Me.gridBand2.Columns.Add(Me.colInterest_till_3M)
        Me.gridBand2.Columns.Add(Me.colInterest_over_3M_till_1Y)
        Me.gridBand2.Columns.Add(Me.colInterest_over_1Y_till_5Y)
        Me.gridBand2.Columns.Add(Me.colInterest_over_5Y)
        Me.gridBand2.Columns.Add(Me.colTOTAL_INTEREST_EUR)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 450
        '
        'colInterest_Täglich_Faellig
        '
        Me.colInterest_Täglich_Faellig.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colInterest_Täglich_Faellig.AppearanceHeader.Options.UseForeColor = True
        Me.colInterest_Täglich_Faellig.Caption = "Interest (due on demand)"
        Me.colInterest_Täglich_Faellig.DisplayFormat.FormatString = "n2"
        Me.colInterest_Täglich_Faellig.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterest_Täglich_Faellig.FieldName = "Interest_Täglich_Faellig"
        Me.colInterest_Täglich_Faellig.Name = "colInterest_Täglich_Faellig"
        Me.colInterest_Täglich_Faellig.OptionsColumn.AllowEdit = False
        Me.colInterest_Täglich_Faellig.OptionsColumn.ReadOnly = True
        Me.colInterest_Täglich_Faellig.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interest_Täglich_Faellig", "Sum={0:n2}")})
        Me.colInterest_Täglich_Faellig.Visible = True
        '
        'colInterest_till_3M
        '
        Me.colInterest_till_3M.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colInterest_till_3M.AppearanceHeader.Options.UseForeColor = True
        Me.colInterest_till_3M.Caption = "Interest (till 3 Months)"
        Me.colInterest_till_3M.DisplayFormat.FormatString = "n2"
        Me.colInterest_till_3M.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterest_till_3M.FieldName = "Interest_till_3M"
        Me.colInterest_till_3M.Name = "colInterest_till_3M"
        Me.colInterest_till_3M.OptionsColumn.AllowEdit = False
        Me.colInterest_till_3M.OptionsColumn.ReadOnly = True
        Me.colInterest_till_3M.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interest_till_3M", "Sum={0:n2}")})
        Me.colInterest_till_3M.Visible = True
        '
        'colInterest_over_3M_till_1Y
        '
        Me.colInterest_over_3M_till_1Y.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colInterest_over_3M_till_1Y.AppearanceHeader.Options.UseForeColor = True
        Me.colInterest_over_3M_till_1Y.Caption = "Interest (over 3M till 1Y)"
        Me.colInterest_over_3M_till_1Y.DisplayFormat.FormatString = "n2"
        Me.colInterest_over_3M_till_1Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterest_over_3M_till_1Y.FieldName = "Interest_over_3M_till_1Y"
        Me.colInterest_over_3M_till_1Y.Name = "colInterest_over_3M_till_1Y"
        Me.colInterest_over_3M_till_1Y.OptionsColumn.AllowEdit = False
        Me.colInterest_over_3M_till_1Y.OptionsColumn.ReadOnly = True
        Me.colInterest_over_3M_till_1Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interest_over_3M_till_1Y", "Sum={0:n2}")})
        Me.colInterest_over_3M_till_1Y.Visible = True
        '
        'colInterest_over_1Y_till_5Y
        '
        Me.colInterest_over_1Y_till_5Y.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colInterest_over_1Y_till_5Y.AppearanceHeader.Options.UseForeColor = True
        Me.colInterest_over_1Y_till_5Y.Caption = "Interest (over 1Y till 5Y)"
        Me.colInterest_over_1Y_till_5Y.DisplayFormat.FormatString = "n2"
        Me.colInterest_over_1Y_till_5Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterest_over_1Y_till_5Y.FieldName = "Interest_over_1Y_till_5Y"
        Me.colInterest_over_1Y_till_5Y.Name = "colInterest_over_1Y_till_5Y"
        Me.colInterest_over_1Y_till_5Y.OptionsColumn.AllowEdit = False
        Me.colInterest_over_1Y_till_5Y.OptionsColumn.ReadOnly = True
        Me.colInterest_over_1Y_till_5Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interest_over_1Y_till_5Y", "Sum={0:n2}")})
        Me.colInterest_over_1Y_till_5Y.Visible = True
        '
        'colInterest_over_5Y
        '
        Me.colInterest_over_5Y.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colInterest_over_5Y.AppearanceHeader.Options.UseForeColor = True
        Me.colInterest_over_5Y.Caption = "Interest (over 5Y)"
        Me.colInterest_over_5Y.DisplayFormat.FormatString = "n2"
        Me.colInterest_over_5Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterest_over_5Y.FieldName = "Interest_over_5Y"
        Me.colInterest_over_5Y.Name = "colInterest_over_5Y"
        Me.colInterest_over_5Y.OptionsColumn.AllowEdit = False
        Me.colInterest_over_5Y.OptionsColumn.ReadOnly = True
        Me.colInterest_over_5Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interest_over_5Y", "Sum={0:n2}")})
        Me.colInterest_over_5Y.Visible = True
        '
        'colTOTAL_INTEREST_EUR
        '
        Me.colTOTAL_INTEREST_EUR.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.colTOTAL_INTEREST_EUR.AppearanceHeader.Options.UseForeColor = True
        Me.colTOTAL_INTEREST_EUR.Caption = "Interest (TOTAL)"
        Me.colTOTAL_INTEREST_EUR.DisplayFormat.FormatString = "n2"
        Me.colTOTAL_INTEREST_EUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTOTAL_INTEREST_EUR.FieldName = "TOTAL_INTEREST_EUR"
        Me.colTOTAL_INTEREST_EUR.Name = "colTOTAL_INTEREST_EUR"
        Me.colTOTAL_INTEREST_EUR.OptionsColumn.AllowEdit = False
        Me.colTOTAL_INTEREST_EUR.OptionsColumn.ReadOnly = True
        Me.colTOTAL_INTEREST_EUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_INTEREST_EUR", "Sum={0:n2}")})
        Me.colTOTAL_INTEREST_EUR.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.gridBand4.AppearanceHeader.Options.UseForeColor = True
        Me.gridBand4.Caption = "Principal + Interest (Totals)"
        Me.gridBand4.Columns.Add(Me.colTäglich_Faellig_TOTAL)
        Me.gridBand4.Columns.Add(Me.colTill_3M_TOTAL)
        Me.gridBand4.Columns.Add(Me.colOver_3M_Till_1Y_TOTAL)
        Me.gridBand4.Columns.Add(Me.colOver_1Y_Till_5Y)
        Me.gridBand4.Columns.Add(Me.colOver_5Y_TOTAL)
        Me.gridBand4.Columns.Add(Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 721
        '
        'colTäglich_Faellig_TOTAL
        '
        Me.colTäglich_Faellig_TOTAL.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colTäglich_Faellig_TOTAL.AppearanceHeader.Options.UseForeColor = True
        Me.colTäglich_Faellig_TOTAL.Caption = "Principal + Interest (due on demand) TOTAL"
        Me.colTäglich_Faellig_TOTAL.DisplayFormat.FormatString = "n2"
        Me.colTäglich_Faellig_TOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTäglich_Faellig_TOTAL.FieldName = "Täglich_Faellig_TOTAL"
        Me.colTäglich_Faellig_TOTAL.Name = "colTäglich_Faellig_TOTAL"
        Me.colTäglich_Faellig_TOTAL.OptionsColumn.AllowEdit = False
        Me.colTäglich_Faellig_TOTAL.OptionsColumn.ReadOnly = True
        Me.colTäglich_Faellig_TOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Täglich_Faellig_TOTAL", "Sum={0:n2}")})
        Me.colTäglich_Faellig_TOTAL.Visible = True
        Me.colTäglich_Faellig_TOTAL.Width = 135
        '
        'colTill_3M_TOTAL
        '
        Me.colTill_3M_TOTAL.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colTill_3M_TOTAL.AppearanceHeader.Options.UseForeColor = True
        Me.colTill_3M_TOTAL.Caption = "Principal + Interest (till 3 Months) TOTAL"
        Me.colTill_3M_TOTAL.DisplayFormat.FormatString = "n2"
        Me.colTill_3M_TOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTill_3M_TOTAL.FieldName = "Till_3M_TOTAL"
        Me.colTill_3M_TOTAL.Name = "colTill_3M_TOTAL"
        Me.colTill_3M_TOTAL.OptionsColumn.AllowEdit = False
        Me.colTill_3M_TOTAL.OptionsColumn.ReadOnly = True
        Me.colTill_3M_TOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Till_3M_TOTAL", "Sum={0:n2}")})
        Me.colTill_3M_TOTAL.Visible = True
        Me.colTill_3M_TOTAL.Width = 117
        '
        'colOver_3M_Till_1Y_TOTAL
        '
        Me.colOver_3M_Till_1Y_TOTAL.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colOver_3M_Till_1Y_TOTAL.AppearanceHeader.Options.UseForeColor = True
        Me.colOver_3M_Till_1Y_TOTAL.Caption = "Principal + Interest (over 3M till 1Y) TOTAL"
        Me.colOver_3M_Till_1Y_TOTAL.DisplayFormat.FormatString = "n2"
        Me.colOver_3M_Till_1Y_TOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOver_3M_Till_1Y_TOTAL.FieldName = "Over_3M_Till_1Y_TOTAL"
        Me.colOver_3M_Till_1Y_TOTAL.Name = "colOver_3M_Till_1Y_TOTAL"
        Me.colOver_3M_Till_1Y_TOTAL.OptionsColumn.AllowEdit = False
        Me.colOver_3M_Till_1Y_TOTAL.OptionsColumn.ReadOnly = True
        Me.colOver_3M_Till_1Y_TOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Over_3M_Till_1Y_TOTAL", "Sum={0:n2}")})
        Me.colOver_3M_Till_1Y_TOTAL.Visible = True
        Me.colOver_3M_Till_1Y_TOTAL.Width = 128
        '
        'colOver_1Y_Till_5Y
        '
        Me.colOver_1Y_Till_5Y.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colOver_1Y_Till_5Y.AppearanceHeader.Options.UseForeColor = True
        Me.colOver_1Y_Till_5Y.Caption = "Principal + Interest (over 1Y till 5Y) TOTAL"
        Me.colOver_1Y_Till_5Y.DisplayFormat.FormatString = "n2"
        Me.colOver_1Y_Till_5Y.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOver_1Y_Till_5Y.FieldName = "Over_1Y_Till_5Y"
        Me.colOver_1Y_Till_5Y.Name = "colOver_1Y_Till_5Y"
        Me.colOver_1Y_Till_5Y.OptionsColumn.AllowEdit = False
        Me.colOver_1Y_Till_5Y.OptionsColumn.ReadOnly = True
        Me.colOver_1Y_Till_5Y.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Over_1Y_Till_5Y", "Sum={0:n2}")})
        Me.colOver_1Y_Till_5Y.Visible = True
        Me.colOver_1Y_Till_5Y.Width = 109
        '
        'colOver_5Y_TOTAL
        '
        Me.colOver_5Y_TOTAL.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colOver_5Y_TOTAL.AppearanceHeader.Options.UseForeColor = True
        Me.colOver_5Y_TOTAL.Caption = "Principal + Interest (over 5Y) TOTAL"
        Me.colOver_5Y_TOTAL.DisplayFormat.FormatString = "n2"
        Me.colOver_5Y_TOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOver_5Y_TOTAL.FieldName = "Over_5Y_TOTAL"
        Me.colOver_5Y_TOTAL.Name = "colOver_5Y_TOTAL"
        Me.colOver_5Y_TOTAL.OptionsColumn.AllowEdit = False
        Me.colOver_5Y_TOTAL.OptionsColumn.ReadOnly = True
        Me.colOver_5Y_TOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Over_5Y_TOTAL", "Sum={0:n2}")})
        Me.colOver_5Y_TOTAL.Visible = True
        Me.colOver_5Y_TOTAL.Width = 97
        '
        'colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST
        '
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.AppearanceHeader.Options.UseForeColor = True
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.Caption = "PRINCIPAL + INTEREST (SUM TOTAL)"
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.DisplayFormat.FormatString = "n2"
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.FieldName = "SUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST"
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.Name = "colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST"
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.OptionsColumn.AllowEdit = False
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.OptionsColumn.ReadOnly = True
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST", "Sum={0:n2}")})
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.Visible = True
        Me.colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST.Width = 135
        '
        'colCCB_Group
        '
        Me.colCCB_Group.AppearanceCell.Options.UseTextOptions = True
        Me.colCCB_Group.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCCB_Group.Caption = "CCB Group Client"
        Me.colCCB_Group.FieldName = "CCB_Group"
        Me.colCCB_Group.Name = "colCCB_Group"
        Me.colCCB_Group.OptionsColumn.AllowEdit = False
        Me.colCCB_Group.OptionsColumn.ReadOnly = True
        '
        'colCCB_Group_OwnID
        '
        Me.colCCB_Group_OwnID.AppearanceCell.Options.UseTextOptions = True
        Me.colCCB_Group_OwnID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCCB_Group_OwnID.Caption = "CCB Group Client (Own ID)"
        Me.colCCB_Group_OwnID.FieldName = "CCB_Group_OwnID"
        Me.colCCB_Group_OwnID.Name = "colCCB_Group_OwnID"
        Me.colCCB_Group_OwnID.OptionsColumn.AllowEdit = False
        Me.colCCB_Group_OwnID.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemComboBox4
        '
        Me.RepositoryItemComboBox4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemComboBox4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemComboBox4.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox4.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox4.AppearanceDropDown.Options.UseBackColor = True
        Me.RepositoryItemComboBox4.AppearanceDropDown.Options.UseForeColor = True
        Me.RepositoryItemComboBox4.AutoHeight = False
        Me.RepositoryItemComboBox4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox4.DropDownRows = 2
        Me.RepositoryItemComboBox4.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox4.ImmediatePopup = True
        Me.RepositoryItemComboBox4.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox4.Name = "RepositoryItemComboBox4"
        Me.RepositoryItemComboBox4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemTextEdit7
        '
        Me.RepositoryItemTextEdit7.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit7.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit7.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit7.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit7.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit7.AutoHeight = False
        Me.RepositoryItemTextEdit7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit7.Name = "RepositoryItemTextEdit7"
        '
        'RepositoryItemTextEdit8
        '
        Me.RepositoryItemTextEdit8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit8.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit8.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit8.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit8.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit8.AutoHeight = False
        Me.RepositoryItemTextEdit8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit8.Mask.BeepOnError = True
        Me.RepositoryItemTextEdit8.Mask.EditMask = "[A-Z]{6}[1-9A-Z]{2}"
        Me.RepositoryItemTextEdit8.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit8.Name = "RepositoryItemTextEdit8"
        '
        'RepositoryItemTextEdit9
        '
        Me.RepositoryItemTextEdit9.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit9.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit9.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit9.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit9.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit9.AutoHeight = False
        Me.RepositoryItemTextEdit9.Mask.EditMask = "[1-9A-Z]{3}"
        Me.RepositoryItemTextEdit9.Mask.IgnoreMaskBlank = False
        Me.RepositoryItemTextEdit9.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular
        Me.RepositoryItemTextEdit9.Name = "RepositoryItemTextEdit9"
        '
        'RepositoryItemMemoExEdit4
        '
        Me.RepositoryItemMemoExEdit4.AllowFocused = False
        Me.RepositoryItemMemoExEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit4.AutoHeight = False
        Me.RepositoryItemMemoExEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit4.Name = "RepositoryItemMemoExEdit4"
        Me.RepositoryItemMemoExEdit4.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit4.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RepositoryItemMemoExEdit4.ShowIcon = False
        '
        'RepositoryItemImageComboBox3
        '
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox3.AutoHeight = False
        Me.RepositoryItemImageComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CANCELLED", "N", 3)})
        Me.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3"
        '
        'LayoutView4
        '
        Me.LayoutView4.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn76, Me.LayoutViewColumn77, Me.LayoutViewColumn78, Me.LayoutViewColumn79, Me.LayoutViewColumn80, Me.LayoutViewColumn81, Me.LayoutViewColumn82, Me.LayoutViewColumn83, Me.LayoutViewColumn84, Me.LayoutViewColumn85, Me.LayoutViewColumn86, Me.LayoutViewColumn87, Me.LayoutViewColumn88, Me.LayoutViewColumn89, Me.LayoutViewColumn90, Me.LayoutViewColumn91, Me.LayoutViewColumn92, Me.LayoutViewColumn93, Me.LayoutViewColumn94, Me.LayoutViewColumn95, Me.LayoutViewColumn96, Me.LayoutViewColumn97, Me.LayoutViewColumn98, Me.LayoutViewColumn99, Me.LayoutViewColumn100})
        Me.LayoutView4.GridControl = Me.GridControl4
        Me.LayoutView4.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField73, Me.LayoutViewField72, Me.LayoutViewField70})
        Me.LayoutView4.Name = "LayoutView4"
        Me.LayoutView4.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView4.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView4.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.LayoutView4.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView4.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView4.OptionsCustomization.AllowFilter = False
        Me.LayoutView4.OptionsCustomization.AllowSort = False
        Me.LayoutView4.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView4.OptionsCustomization.ShowGroupView = False
        Me.LayoutView4.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView4.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView4.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView4.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView4.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView4.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView4.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView4.OptionsPrint.PrintSelectedCardsOnly = True
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView4.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn76, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView4.TemplateCard = Me.LayoutViewCard4
        '
        'LayoutViewColumn76
        '
        Me.LayoutViewColumn76.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn76.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn76.FieldName = "Idnr"
        Me.LayoutViewColumn76.LayoutViewField = Me.LayoutViewField52
        Me.LayoutViewColumn76.Name = "LayoutViewColumn76"
        Me.LayoutViewColumn76.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField52
        '
        Me.LayoutViewField52.EditorPreferredWidth = 86
        Me.LayoutViewField52.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField52.Name = "LayoutViewField52"
        Me.LayoutViewField52.Size = New System.Drawing.Size(206, 63)
        Me.LayoutViewField52.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn77
        '
        Me.LayoutViewColumn77.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn77.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn77.FieldName = "TAG"
        Me.LayoutViewColumn77.LayoutViewField = Me.LayoutViewField53
        Me.LayoutViewColumn77.Name = "LayoutViewColumn77"
        '
        'LayoutViewField53
        '
        Me.LayoutViewField53.EditorPreferredWidth = 383
        Me.LayoutViewField53.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField53.Name = "LayoutViewField53"
        Me.LayoutViewField53.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField53.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn78
        '
        Me.LayoutViewColumn78.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn78.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn78.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn78.LayoutViewField = Me.LayoutViewField54
        Me.LayoutViewColumn78.Name = "LayoutViewColumn78"
        '
        'LayoutViewField54
        '
        Me.LayoutViewField54.EditorPreferredWidth = 383
        Me.LayoutViewField54.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField54.Name = "LayoutViewField54"
        Me.LayoutViewField54.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField54.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn79
        '
        Me.LayoutViewColumn79.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn79.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn79.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn79.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn79.ColumnEdit = Me.RepositoryItemTextEdit7
        Me.LayoutViewColumn79.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn79.LayoutViewField = Me.LayoutViewField55
        Me.LayoutViewColumn79.Name = "LayoutViewColumn79"
        '
        'LayoutViewField55
        '
        Me.LayoutViewField55.EditorPreferredWidth = 371
        Me.LayoutViewField55.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField55.Name = "LayoutViewField55"
        Me.LayoutViewField55.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField55.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn80
        '
        Me.LayoutViewColumn80.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn80.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn80.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn80.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn80.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn80.LayoutViewField = Me.LayoutViewField56
        Me.LayoutViewColumn80.Name = "LayoutViewColumn80"
        '
        'LayoutViewField56
        '
        Me.LayoutViewField56.EditorPreferredWidth = 371
        Me.LayoutViewField56.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField56.Name = "LayoutViewField56"
        Me.LayoutViewField56.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField56.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn81
        '
        Me.LayoutViewColumn81.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn81.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn81.FieldName = "CITY HEADING"
        Me.LayoutViewColumn81.LayoutViewField = Me.LayoutViewField57
        Me.LayoutViewColumn81.Name = "LayoutViewColumn81"
        '
        'LayoutViewField57
        '
        Me.LayoutViewField57.EditorPreferredWidth = 371
        Me.LayoutViewField57.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField57.Name = "LayoutViewField57"
        Me.LayoutViewField57.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField57.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn82
        '
        Me.LayoutViewColumn82.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn82.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn82.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn82.LayoutViewField = Me.LayoutViewField58
        Me.LayoutViewColumn82.Name = "LayoutViewColumn82"
        '
        'LayoutViewField58
        '
        Me.LayoutViewField58.EditorPreferredWidth = 86
        Me.LayoutViewField58.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField58.Name = "LayoutViewField58"
        Me.LayoutViewField58.Size = New System.Drawing.Size(206, 20)
        Me.LayoutViewField58.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn83
        '
        Me.LayoutViewColumn83.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn83.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn83.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn83.LayoutViewField = Me.LayoutViewField59
        Me.LayoutViewColumn83.Name = "LayoutViewColumn83"
        '
        'LayoutViewField59
        '
        Me.LayoutViewField59.EditorPreferredWidth = 371
        Me.LayoutViewField59.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField59.Name = "LayoutViewField59"
        Me.LayoutViewField59.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField59.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn84
        '
        Me.LayoutViewColumn84.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn84.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn84.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn84.LayoutViewField = Me.LayoutViewField60
        Me.LayoutViewColumn84.Name = "LayoutViewColumn84"
        '
        'LayoutViewField60
        '
        Me.LayoutViewField60.EditorPreferredWidth = 383
        Me.LayoutViewField60.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField60.Name = "LayoutViewField60"
        Me.LayoutViewField60.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField60.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn85
        '
        Me.LayoutViewColumn85.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn85.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn85.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn85.LayoutViewField = Me.LayoutViewField61
        Me.LayoutViewColumn85.Name = "LayoutViewColumn85"
        '
        'LayoutViewField61
        '
        Me.LayoutViewField61.EditorPreferredWidth = 384
        Me.LayoutViewField61.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField61.Name = "LayoutViewField61"
        Me.LayoutViewField61.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField61.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn86
        '
        Me.LayoutViewColumn86.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn86.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn86.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn86.LayoutViewField = Me.LayoutViewField62
        Me.LayoutViewColumn86.Name = "LayoutViewColumn86"
        '
        'LayoutViewField62
        '
        Me.LayoutViewField62.EditorPreferredWidth = 384
        Me.LayoutViewField62.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField62.Name = "LayoutViewField62"
        Me.LayoutViewField62.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField62.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn87
        '
        Me.LayoutViewColumn87.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn87.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn87.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn87.LayoutViewField = Me.LayoutViewField63
        Me.LayoutViewColumn87.Name = "LayoutViewColumn87"
        '
        'LayoutViewField63
        '
        Me.LayoutViewField63.EditorPreferredWidth = 384
        Me.LayoutViewField63.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField63.Name = "LayoutViewField63"
        Me.LayoutViewField63.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField63.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn88
        '
        Me.LayoutViewColumn88.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn88.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn88.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn88.LayoutViewField = Me.LayoutViewField64
        Me.LayoutViewColumn88.Name = "LayoutViewColumn88"
        '
        'LayoutViewField64
        '
        Me.LayoutViewField64.EditorPreferredWidth = 384
        Me.LayoutViewField64.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField64.Name = "LayoutViewField64"
        Me.LayoutViewField64.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField64.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn89
        '
        Me.LayoutViewColumn89.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn89.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn89.FieldName = "LOCATION"
        Me.LayoutViewColumn89.LayoutViewField = Me.LayoutViewField65
        Me.LayoutViewColumn89.Name = "LayoutViewColumn89"
        '
        'LayoutViewField65
        '
        Me.LayoutViewField65.EditorPreferredWidth = 384
        Me.LayoutViewField65.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField65.Name = "LayoutViewField65"
        Me.LayoutViewField65.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField65.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn90
        '
        Me.LayoutViewColumn90.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn90.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn90.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn90.LayoutViewField = Me.LayoutViewField66
        Me.LayoutViewColumn90.Name = "LayoutViewColumn90"
        '
        'LayoutViewField66
        '
        Me.LayoutViewField66.EditorPreferredWidth = 384
        Me.LayoutViewField66.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField66.Name = "LayoutViewField66"
        Me.LayoutViewField66.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField66.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn91
        '
        Me.LayoutViewColumn91.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn91.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn91.FieldName = "POB NUMBER"
        Me.LayoutViewColumn91.LayoutViewField = Me.LayoutViewField67
        Me.LayoutViewColumn91.Name = "LayoutViewColumn91"
        '
        'LayoutViewField67
        '
        Me.LayoutViewField67.EditorPreferredWidth = 384
        Me.LayoutViewField67.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField67.Name = "LayoutViewField67"
        Me.LayoutViewField67.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField67.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn92
        '
        Me.LayoutViewColumn92.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn92.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn92.FieldName = "POB LOCATION"
        Me.LayoutViewColumn92.LayoutViewField = Me.LayoutViewField68
        Me.LayoutViewColumn92.Name = "LayoutViewColumn92"
        '
        'LayoutViewField68
        '
        Me.LayoutViewField68.EditorPreferredWidth = 384
        Me.LayoutViewField68.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField68.Name = "LayoutViewField68"
        Me.LayoutViewField68.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField68.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn93
        '
        Me.LayoutViewColumn93.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn93.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn93.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn93.LayoutViewField = Me.LayoutViewField69
        Me.LayoutViewColumn93.Name = "LayoutViewColumn93"
        '
        'LayoutViewField69
        '
        Me.LayoutViewField69.EditorPreferredWidth = 384
        Me.LayoutViewField69.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField69.Name = "LayoutViewField69"
        Me.LayoutViewField69.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField69.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn94
        '
        Me.LayoutViewColumn94.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn94.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn94.CustomizationCaption = "USER"
        Me.LayoutViewColumn94.FieldName = "USER"
        Me.LayoutViewColumn94.LayoutViewField = Me.LayoutViewField70
        Me.LayoutViewColumn94.Name = "LayoutViewColumn94"
        Me.LayoutViewColumn94.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField70
        '
        Me.LayoutViewField70.EditorPreferredWidth = 20
        Me.LayoutViewField70.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField70.Name = "LayoutViewField70"
        Me.LayoutViewField70.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField70.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn95
        '
        Me.LayoutViewColumn95.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn95.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn95.ColumnEdit = Me.RepositoryItemComboBox4
        Me.LayoutViewColumn95.FieldName = "VALID"
        Me.LayoutViewColumn95.LayoutViewField = Me.LayoutViewField71
        Me.LayoutViewColumn95.Name = "LayoutViewColumn95"
        '
        'LayoutViewField71
        '
        Me.LayoutViewField71.EditorPreferredWidth = 30
        Me.LayoutViewField71.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField71.Name = "LayoutViewField71"
        Me.LayoutViewField71.Size = New System.Drawing.Size(162, 20)
        Me.LayoutViewField71.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn96
        '
        Me.LayoutViewColumn96.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn96.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn96.CustomizationCaption = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.LayoutViewField = Me.LayoutViewField72
        Me.LayoutViewColumn96.Name = "LayoutViewColumn96"
        Me.LayoutViewColumn96.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField72
        '
        Me.LayoutViewField72.EditorPreferredWidth = 20
        Me.LayoutViewField72.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField72.Name = "LayoutViewField72"
        Me.LayoutViewField72.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField72.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn97
        '
        Me.LayoutViewColumn97.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn97.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn97.CustomizationCaption = "BIC11"
        Me.LayoutViewColumn97.FieldName = "BIC11"
        Me.LayoutViewColumn97.LayoutViewField = Me.LayoutViewField73
        Me.LayoutViewColumn97.Name = "LayoutViewColumn97"
        Me.LayoutViewColumn97.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField73
        '
        Me.LayoutViewField73.EditorPreferredWidth = 20
        Me.LayoutViewField73.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField73.Name = "LayoutViewField73"
        Me.LayoutViewField73.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField73.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn98
        '
        Me.LayoutViewColumn98.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn98.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn98.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn98.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn98.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn98.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn98.ColumnEdit = Me.RepositoryItemTextEdit8
        Me.LayoutViewColumn98.FieldName = "BIC CODE"
        Me.LayoutViewColumn98.LayoutViewField = Me.LayoutViewField74
        Me.LayoutViewColumn98.Name = "LayoutViewColumn98"
        '
        'LayoutViewField74
        '
        Me.LayoutViewField74.EditorPreferredWidth = 93
        Me.LayoutViewField74.ImageOptions.ImageIndex = 0
        Me.LayoutViewField74.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField74.Name = "LayoutViewField74"
        Me.LayoutViewField74.Size = New System.Drawing.Size(225, 20)
        Me.LayoutViewField74.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn99
        '
        Me.LayoutViewColumn99.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn99.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn99.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn99.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn99.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn99.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn99.ColumnEdit = Me.RepositoryItemTextEdit9
        Me.LayoutViewColumn99.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn99.LayoutViewField = Me.LayoutViewField75
        Me.LayoutViewColumn99.Name = "LayoutViewColumn99"
        '
        'LayoutViewField75
        '
        Me.LayoutViewField75.EditorPreferredWidth = 51
        Me.LayoutViewField75.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField75.Name = "LayoutViewField75"
        Me.LayoutViewField75.Size = New System.Drawing.Size(183, 20)
        Me.LayoutViewField75.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn100
        '
        Me.LayoutViewColumn100.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn100.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn100.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn100.FieldName = "COUNTRY"
        Me.LayoutViewColumn100.LayoutViewField = Me.LayoutViewField76
        Me.LayoutViewColumn100.Name = "LayoutViewColumn100"
        Me.LayoutViewColumn100.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField76
        '
        Me.LayoutViewField76.EditorPreferredWidth = 384
        Me.LayoutViewField76.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField76.Name = "LayoutViewField76"
        Me.LayoutViewField76.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField76.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewCard4
        '
        Me.LayoutViewCard4.CaptionImageOptions.Location = DevExpress.Utils.GroupElementLocation.BeforeText
        Me.LayoutViewCard4.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutViewCard4.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard4.Name = "LayoutViewCard1"
        Me.LayoutViewCard4.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard4.Text = "TemplateCard"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl4)
        Me.LayoutControl1.Controls.Add(Me.Load_LCR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.LCR_Date_Comboedit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1509, 731)
        Me.LayoutControl1.TabIndex = 118
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Load_LCR_Details_btn
        '
        Me.Load_LCR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Load_LCR_Details_btn.ImageOptions.ImageIndex = 6
        Me.Load_LCR_Details_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Load_LCR_Details_btn.Location = New System.Drawing.Point(195, 42)
        Me.Load_LCR_Details_btn.Name = "Load_LCR_Details_btn"
        Me.Load_LCR_Details_btn.Size = New System.Drawing.Size(182, 22)
        Me.Load_LCR_Details_btn.StyleController = Me.LayoutControl1
        Me.Load_LCR_Details_btn.TabIndex = 128
        Me.Load_LCR_Details_btn.Text = "Load Rechnungslegung Details"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(381, 42)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(211, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 6
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'LCR_Date_Comboedit
        '
        Me.LCR_Date_Comboedit.Location = New System.Drawing.Point(54, 42)
        Me.LCR_Date_Comboedit.Name = "LCR_Date_Comboedit"
        Me.LCR_Date_Comboedit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LCR_Date_Comboedit.Properties.Appearance.Options.UseFont = True
        Me.LCR_Date_Comboedit.Properties.Appearance.Options.UseTextOptions = True
        Me.LCR_Date_Comboedit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.LCR_Date_Comboedit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LCR_Date_Comboedit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LCR_Date_Comboedit.Properties.MaxLength = 8
        Me.LCR_Date_Comboedit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.LCR_Date_Comboedit.Size = New System.Drawing.Size(137, 22)
        Me.LCR_Date_Comboedit.StyleController = Me.LayoutControl1
        Me.LCR_Date_Comboedit.TabIndex = 128
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1509, 731)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup2.CustomizationFormText = "AfA - Detailbericht"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem4, Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1489, 711)
        Me.LayoutControlGroup2.Text = "Rechnungslegung Details calculation"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(572, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(893, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem7.Control = Me.LCR_Date_Comboedit
        Me.LayoutControlItem7.CustomizationFormText = "Date"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem7.Text = "Date"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(27, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.Load_LCR_Details_btn
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(171, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(186, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(357, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(215, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl4
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1465, 643)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'Rechnungslegung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1509, 731)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Rechnungslegung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rechnungslegung"
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rechnungslegung_AdvBandedGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField76, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LCR_Date_Comboedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Rechnungslegung_AdvBandedGridView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colClient_Name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colClientType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colZahlungsart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colArt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colBILANZ_POSITION As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colAccountNr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTaeglichFaelligAcc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrincipal_Täglich_Faellig As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrincipal_till_3M As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrincipal_over_3M_till_1Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrincipal_over_1Y_till_5Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrincipal_over_5Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTOTAL_PRINCIPAL_EUR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colInterest_Täglich_Faellig As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colInterest_till_3M As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colInterest_over_3M_till_1Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colInterest_over_1Y_till_5Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colInterest_over_5Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTOTAL_INTEREST_EUR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTäglich_Faellig_TOTAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTill_3M_TOTAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colOver_3M_Till_1Y_TOTAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colOver_1Y_Till_5Y As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colOver_5Y_TOTAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSUM_TOTAL_PRINCIPAL_and_TOTAL_INTEREST As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCCB_Group As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCCB_Group_OwnID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutView4 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn76 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField52 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn77 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField53 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn78 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField54 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn79 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField55 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn80 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField56 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn81 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField57 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn82 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField58 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn83 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField59 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn84 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField60 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn85 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField61 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn86 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField62 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn87 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField63 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn88 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField64 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn89 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField65 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn90 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField66 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn91 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField67 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn92 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField68 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn93 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField69 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn94 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField70 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn95 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField71 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn96 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField72 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn97 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField73 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn98 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField74 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn99 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField75 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn100 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField76 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard4 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Load_LCR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LCR_Date_Comboedit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
