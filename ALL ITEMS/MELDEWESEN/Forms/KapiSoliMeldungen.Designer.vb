<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KapiSoliMeldungen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KapiSoliMeldungen))
        Me.KapiSoliMonat_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZinsertragsmonat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSummeKapErSt1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSummeSoli1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdZinsertragJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZinsertragsmonatDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ZINSERTRAG_KUNDEN_JAHRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MeldewesenDataSet = New PS_TOOL_DX.MeldewesenDataSet()
        Me.KapiSoliJahr_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colErtragsJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSummeKapErSt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSummeSoli = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BUNDESLANDRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TEXTERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.DEFINITIONRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.KAPITALSTPFLRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colIdnr = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTAG = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn3 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMODIFICATIONFLAG = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn4 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colINSTITUTIONNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn5 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBRANCHINFORMATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn6 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCITYHEADING = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn7 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSUBTYPEINDICATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn8 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALUEADDEDSERVICES = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn9 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colEXTRAINFO = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn10 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn11 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn12 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn13 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPHYSICALADDRESS4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn14 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLOCATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn15 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCOUNTRYNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn16 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBNUMBER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn17 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBLOCATION = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn18 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPOBCOUNTRYNAME = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn19 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUSER2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn20 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVALID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn21 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField48 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn22 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC112 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn23 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBICCODE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn24 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBRANCHCODE = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn25 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCOUNTRY = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.KapiSoliDetails_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValDateFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegistrationCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContract = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchangeRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountEuro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKapertstG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSoli = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKAPISTPFLICHTIG1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBUNDESLAND1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdValueCustomer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdZinsertragsMonat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdErtragJahr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdKDSTAMM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZINSERTRAG_KUNDEN_JAHRTableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_JAHRTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.TableAdapterManager()
        Me.ZINSERTRAG_KUNDEN_DETAILSTableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_DETAILSTableAdapter()
        Me.ZINSERTRAG_KUNDEN_MONATTableAdapter = New PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_MONATTableAdapter()
        Me.ZINSERTRAG_KUNDEN_MONATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZINSERTRAG_KUNDEN_DETAILSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PopupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.SteuerbescheinigungenReportsDropDownButton = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.MeldungKapiSoli_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.KapiSoliReportMonatlich_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.KapiSoliMeldung_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.InterestRateRiskHUMPBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.KapiSoliMonat_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZINSERTRAG_KUNDEN_JAHRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeldewesenDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KapiSoliJahr_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BUNDESLANDRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEXTERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFINITIONRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KAPITALSTPFLRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colIdnr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTAG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMODIFICATIONFLAG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colINSTITUTIONNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBRANCHINFORMATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCITYHEADING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSUBTYPEINDICATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALUEADDEDSERVICES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colEXTRAINFO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLOCATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRYNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBNUMBER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBLOCATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPOBCOUNTRYNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUSER2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVALID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBICCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBRANCHCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCOUNTRY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KapiSoliDetails_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZINSERTRAG_KUNDEN_MONATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZINSERTRAG_KUNDEN_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KapiSoliMonat_BasicView
        '
        Me.KapiSoliMonat_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.KapiSoliMonat_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.KapiSoliMonat_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.KapiSoliMonat_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.KapiSoliMonat_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.KapiSoliMonat_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colZinsertragsmonat, Me.colSummeKapErSt1, Me.colSummeSoli1, Me.colIdZinsertragJahr, Me.colZinsertragsmonatDATE})
        Me.KapiSoliMonat_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.KapiSoliMonat_BasicView.GridControl = Me.GridControl1
        Me.KapiSoliMonat_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KDDETAIL_FK00.KapertstG", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KDDETAIL_FK00.Soli", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KUNDEN MONAT_FK00.SummeKapErSt", Me.colSummeKapErSt1, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KUNDEN MONAT_FK00.SummeSoli", Me.colSummeSoli1, "{0:n2}")})
        Me.KapiSoliMonat_BasicView.Name = "KapiSoliMonat_BasicView"
        Me.KapiSoliMonat_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.KapiSoliMonat_BasicView.OptionsFind.AlwaysVisible = True
        Me.KapiSoliMonat_BasicView.OptionsView.ColumnAutoWidth = False
        Me.KapiSoliMonat_BasicView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.KapiSoliMonat_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.KapiSoliMonat_BasicView.OptionsView.ShowFooter = True
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colZinsertragsmonat
        '
        Me.colZinsertragsmonat.Caption = "Meldemonat"
        Me.colZinsertragsmonat.FieldName = "Zinsertragsmonat"
        Me.colZinsertragsmonat.Name = "colZinsertragsmonat"
        Me.colZinsertragsmonat.OptionsColumn.AllowEdit = False
        Me.colZinsertragsmonat.OptionsColumn.ReadOnly = True
        Me.colZinsertragsmonat.Visible = True
        Me.colZinsertragsmonat.VisibleIndex = 0
        Me.colZinsertragsmonat.Width = 170
        '
        'colSummeKapErSt1
        '
        Me.colSummeKapErSt1.AppearanceCell.Options.UseTextOptions = True
        Me.colSummeKapErSt1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSummeKapErSt1.Caption = "Summe Kapitalertragsteuer"
        Me.colSummeKapErSt1.DisplayFormat.FormatString = "n2"
        Me.colSummeKapErSt1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSummeKapErSt1.FieldName = "SummeKapErSt"
        Me.colSummeKapErSt1.Name = "colSummeKapErSt1"
        Me.colSummeKapErSt1.OptionsColumn.AllowEdit = False
        Me.colSummeKapErSt1.OptionsColumn.ReadOnly = True
        Me.colSummeKapErSt1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SummeKapErSt", "{0:n2}")})
        Me.colSummeKapErSt1.Visible = True
        Me.colSummeKapErSt1.VisibleIndex = 1
        Me.colSummeKapErSt1.Width = 157
        '
        'colSummeSoli1
        '
        Me.colSummeSoli1.AppearanceCell.Options.UseTextOptions = True
        Me.colSummeSoli1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSummeSoli1.Caption = "Summe SOLI"
        Me.colSummeSoli1.DisplayFormat.FormatString = "n2"
        Me.colSummeSoli1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSummeSoli1.FieldName = "SummeSoli"
        Me.colSummeSoli1.Name = "colSummeSoli1"
        Me.colSummeSoli1.OptionsColumn.AllowEdit = False
        Me.colSummeSoli1.OptionsColumn.ReadOnly = True
        Me.colSummeSoli1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SummeSoli", "{0:n2}")})
        Me.colSummeSoli1.Visible = True
        Me.colSummeSoli1.VisibleIndex = 2
        Me.colSummeSoli1.Width = 111
        '
        'colIdZinsertragJahr
        '
        Me.colIdZinsertragJahr.FieldName = "IdZinsertragJahr"
        Me.colIdZinsertragJahr.Name = "colIdZinsertragJahr"
        Me.colIdZinsertragJahr.OptionsColumn.AllowEdit = False
        Me.colIdZinsertragJahr.OptionsColumn.ReadOnly = True
        '
        'colZinsertragsmonatDATE
        '
        Me.colZinsertragsmonatDATE.FieldName = "ZinsertragsmonatDATE"
        Me.colZinsertragsmonatDATE.Name = "colZinsertragsmonatDATE"
        Me.colZinsertragsmonatDATE.OptionsColumn.AllowEdit = False
        Me.colZinsertragsmonatDATE.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.ZINSERTRAG_KUNDEN_JAHRBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.KapiSoliMonat_BasicView
        GridLevelNode2.LevelTemplate = Me.KapiSoliDetails_BasicView
        GridLevelNode2.RelationName = "ZINSERTRAG KUNDEN DETAILS_FK00"
        GridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        GridLevelNode1.RelationName = "ZINSERTRAG KUNDEN MONAT_FK00"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.KapiSoliJahr_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BUNDESLANDRepositoryItemComboBox, Me.TEXTERepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemPopupContainerEdit1, Me.DEFINITIONRepositoryItemImageComboBox, Me.KAPITALSTPFLRepositoryItemComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1241, 610)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.KapiSoliJahr_BasicView, Me.LayoutView1, Me.KapiSoliDetails_BasicView, Me.KapiSoliMonat_BasicView})
        '
        'ZINSERTRAG_KUNDEN_JAHRBindingSource
        '
        Me.ZINSERTRAG_KUNDEN_JAHRBindingSource.DataMember = "ZINSERTRAG KUNDEN JAHR"
        Me.ZINSERTRAG_KUNDEN_JAHRBindingSource.DataSource = Me.MeldewesenDataSet
        '
        'MeldewesenDataSet
        '
        Me.MeldewesenDataSet.DataSetName = "MeldewesenDataSet"
        Me.MeldewesenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KapiSoliJahr_BasicView
        '
        Me.KapiSoliJahr_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.KapiSoliJahr_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.KapiSoliJahr_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.KapiSoliJahr_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.KapiSoliJahr_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.KapiSoliJahr_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colErtragsJahr, Me.colSummeKapErSt, Me.colSummeSoli, Me.colIdBank})
        Me.KapiSoliJahr_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.KapiSoliJahr_BasicView.GridControl = Me.GridControl1
        Me.KapiSoliJahr_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEuro", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KDDETAIL_FK00.Soli", Nothing, "{0:n2}")})
        Me.KapiSoliJahr_BasicView.Name = "KapiSoliJahr_BasicView"
        Me.KapiSoliJahr_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.KapiSoliJahr_BasicView.OptionsFind.AlwaysVisible = True
        Me.KapiSoliJahr_BasicView.OptionsView.ColumnAutoWidth = False
        Me.KapiSoliJahr_BasicView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.KapiSoliJahr_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.KapiSoliJahr_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.KapiSoliJahr_BasicView.OptionsView.ShowFooter = True
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colErtragsJahr
        '
        Me.colErtragsJahr.Caption = "Ertragsjahr"
        Me.colErtragsJahr.FieldName = "ErtragsJahr"
        Me.colErtragsJahr.Name = "colErtragsJahr"
        Me.colErtragsJahr.OptionsColumn.AllowEdit = False
        Me.colErtragsJahr.OptionsColumn.ReadOnly = True
        Me.colErtragsJahr.Visible = True
        Me.colErtragsJahr.VisibleIndex = 0
        '
        'colSummeKapErSt
        '
        Me.colSummeKapErSt.AppearanceCell.Options.UseTextOptions = True
        Me.colSummeKapErSt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSummeKapErSt.Caption = "Summe Kapitalertragsteuer"
        Me.colSummeKapErSt.DisplayFormat.FormatString = "n2"
        Me.colSummeKapErSt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSummeKapErSt.FieldName = "SummeKapErSt"
        Me.colSummeKapErSt.Name = "colSummeKapErSt"
        Me.colSummeKapErSt.OptionsColumn.AllowEdit = False
        Me.colSummeKapErSt.OptionsColumn.ReadOnly = True
        Me.colSummeKapErSt.Visible = True
        Me.colSummeKapErSt.VisibleIndex = 1
        Me.colSummeKapErSt.Width = 137
        '
        'colSummeSoli
        '
        Me.colSummeSoli.AppearanceCell.Options.UseTextOptions = True
        Me.colSummeSoli.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSummeSoli.Caption = "Summe SOLI"
        Me.colSummeSoli.DisplayFormat.FormatString = "n2"
        Me.colSummeSoli.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSummeSoli.FieldName = "SummeSoli"
        Me.colSummeSoli.Name = "colSummeSoli"
        Me.colSummeSoli.OptionsColumn.AllowEdit = False
        Me.colSummeSoli.OptionsColumn.ReadOnly = True
        Me.colSummeSoli.Visible = True
        Me.colSummeSoli.VisibleIndex = 2
        Me.colSummeSoli.Width = 119
        '
        'colIdBank
        '
        Me.colIdBank.FieldName = "IdBank"
        Me.colIdBank.Name = "colIdBank"
        Me.colIdBank.OptionsColumn.AllowEdit = False
        Me.colIdBank.OptionsColumn.ReadOnly = True
        '
        'BUNDESLANDRepositoryItemComboBox
        '
        Me.BUNDESLANDRepositoryItemComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BUNDESLANDRepositoryItemComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.BUNDESLANDRepositoryItemComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.BUNDESLANDRepositoryItemComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BUNDESLANDRepositoryItemComboBox.Appearance.Options.UseBackColor = True
        Me.BUNDESLANDRepositoryItemComboBox.Appearance.Options.UseForeColor = True
        Me.BUNDESLANDRepositoryItemComboBox.AppearanceDropDown.BackColor = System.Drawing.Color.Yellow
        Me.BUNDESLANDRepositoryItemComboBox.AppearanceDropDown.BackColor2 = System.Drawing.Color.Yellow
        Me.BUNDESLANDRepositoryItemComboBox.AppearanceDropDown.ForeColor = System.Drawing.Color.Black
        Me.BUNDESLANDRepositoryItemComboBox.AppearanceDropDown.Options.UseBackColor = True
        Me.BUNDESLANDRepositoryItemComboBox.AppearanceDropDown.Options.UseForeColor = True
        Me.BUNDESLANDRepositoryItemComboBox.AutoHeight = False
        Me.BUNDESLANDRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BUNDESLANDRepositoryItemComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BUNDESLANDRepositoryItemComboBox.DropDownRows = 2
        Me.BUNDESLANDRepositoryItemComboBox.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BUNDESLANDRepositoryItemComboBox.ImmediatePopup = True
        Me.BUNDESLANDRepositoryItemComboBox.Items.AddRange(New Object() {"BADEN-WÜRTTEMBERG ", "BAYERN ", "BERLIN ", "BRANDENBURG ", "BREMEN ", "HAMBURG ", "HESSEN ", "MECKLENBURG-VORPOMMERN ", "NIEDERSACHSEN ", "NORDRHEIN-WESTFALEN ", "RHEINLAND-PFALZ ", "SAARLAND ", "SACHSEN ", "SACHSEN-ANHALT ", "FEDERAL STATE: SCHLESWIG-HOLSTEIN ", "FEDERAL STATE: THÜRINGEN "})
        Me.BUNDESLANDRepositoryItemComboBox.Name = "BUNDESLANDRepositoryItemComboBox"
        Me.BUNDESLANDRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'TEXTERepositoryItemTextEdit
        '
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.TEXTERepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.TEXTERepositoryItemTextEdit.AutoHeight = False
        Me.TEXTERepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TEXTERepositoryItemTextEdit.Name = "TEXTERepositoryItemTextEdit"
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
        'RepositoryItemPopupContainerEdit1
        '
        Me.RepositoryItemPopupContainerEdit1.AutoHeight = False
        Me.RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        '
        'DEFINITIONRepositoryItemImageComboBox
        '
        Me.DEFINITIONRepositoryItemImageComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.Options.UseFont = True
        Me.DEFINITIONRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.DEFINITIONRepositoryItemImageComboBox.AutoHeight = False
        Me.DEFINITIONRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFINITIONRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MONEY MARKET KUNDE", "MM", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NORMAL", "N", -1)})
        Me.DEFINITIONRepositoryItemImageComboBox.Name = "DEFINITIONRepositoryItemImageComboBox"
        '
        'KAPITALSTPFLRepositoryItemComboBox
        '
        Me.KAPITALSTPFLRepositoryItemComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.Options.UseFont = True
        Me.KAPITALSTPFLRepositoryItemComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.KAPITALSTPFLRepositoryItemComboBox.AutoHeight = False
        Me.KAPITALSTPFLRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.KAPITALSTPFLRepositoryItemComboBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.KAPITALSTPFLRepositoryItemComboBox.Items.AddRange(New Object() {"Y", "N"})
        Me.KAPITALSTPFLRepositoryItemComboBox.Name = "KAPITALSTPFLRepositoryItemComboBox"
        Me.KAPITALSTPFLRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LayoutView1
        '
        Me.LayoutView1.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn1, Me.LayoutViewColumn2, Me.LayoutViewColumn3, Me.LayoutViewColumn4, Me.LayoutViewColumn5, Me.LayoutViewColumn6, Me.LayoutViewColumn7, Me.LayoutViewColumn8, Me.LayoutViewColumn9, Me.LayoutViewColumn10, Me.LayoutViewColumn11, Me.LayoutViewColumn12, Me.LayoutViewColumn13, Me.LayoutViewColumn14, Me.LayoutViewColumn15, Me.LayoutViewColumn16, Me.LayoutViewColumn17, Me.LayoutViewColumn18, Me.LayoutViewColumn19, Me.LayoutViewColumn20, Me.LayoutViewColumn21, Me.LayoutViewColumn22, Me.LayoutViewColumn23, Me.LayoutViewColumn24, Me.LayoutViewColumn25})
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colBIC112, Me.LayoutViewField48, Me.layoutViewField_colUSER2})
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsCustomization.AllowFilter = False
        Me.LayoutView1.OptionsCustomization.AllowSort = False
        Me.LayoutView1.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView1.OptionsCustomization.ShowGroupView = False
        Me.LayoutView1.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView1.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView1.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView1.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsPrint.PrintSelectedCardsOnly = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn1.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn1.FieldName = "Idnr"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_colIdnr
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        Me.LayoutViewColumn1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colIdnr
        '
        Me.layoutViewField_colIdnr.EditorPreferredWidth = 86
        Me.layoutViewField_colIdnr.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colIdnr.Name = "layoutViewField_colIdnr"
        Me.layoutViewField_colIdnr.Size = New System.Drawing.Size(206, 63)
        Me.layoutViewField_colIdnr.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn2
        '
        Me.LayoutViewColumn2.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn2.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn2.FieldName = "TAG"
        Me.LayoutViewColumn2.LayoutViewField = Me.layoutViewField_colTAG
        Me.LayoutViewColumn2.Name = "LayoutViewColumn2"
        '
        'layoutViewField_colTAG
        '
        Me.layoutViewField_colTAG.EditorPreferredWidth = 383
        Me.layoutViewField_colTAG.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colTAG.Name = "layoutViewField_colTAG"
        Me.layoutViewField_colTAG.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colTAG.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn3
        '
        Me.LayoutViewColumn3.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn3.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn3.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn3.LayoutViewField = Me.layoutViewField_colMODIFICATIONFLAG
        Me.LayoutViewColumn3.Name = "LayoutViewColumn3"
        '
        'layoutViewField_colMODIFICATIONFLAG
        '
        Me.layoutViewField_colMODIFICATIONFLAG.EditorPreferredWidth = 383
        Me.layoutViewField_colMODIFICATIONFLAG.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colMODIFICATIONFLAG.Name = "layoutViewField_colMODIFICATIONFLAG"
        Me.layoutViewField_colMODIFICATIONFLAG.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colMODIFICATIONFLAG.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn4.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn4.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn4.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn4.ColumnEdit = Me.TEXTERepositoryItemTextEdit
        Me.LayoutViewColumn4.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn4.LayoutViewField = Me.layoutViewField_colINSTITUTIONNAME
        Me.LayoutViewColumn4.Name = "LayoutViewColumn4"
        '
        'layoutViewField_colINSTITUTIONNAME
        '
        Me.layoutViewField_colINSTITUTIONNAME.EditorPreferredWidth = 371
        Me.layoutViewField_colINSTITUTIONNAME.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colINSTITUTIONNAME.Name = "layoutViewField_colINSTITUTIONNAME"
        Me.layoutViewField_colINSTITUTIONNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colINSTITUTIONNAME.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn5
        '
        Me.LayoutViewColumn5.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn5.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn5.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn5.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn5.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn5.LayoutViewField = Me.layoutViewField_colBRANCHINFORMATION
        Me.LayoutViewColumn5.Name = "LayoutViewColumn5"
        '
        'layoutViewField_colBRANCHINFORMATION
        '
        Me.layoutViewField_colBRANCHINFORMATION.EditorPreferredWidth = 371
        Me.layoutViewField_colBRANCHINFORMATION.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colBRANCHINFORMATION.Name = "layoutViewField_colBRANCHINFORMATION"
        Me.layoutViewField_colBRANCHINFORMATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colBRANCHINFORMATION.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn6
        '
        Me.LayoutViewColumn6.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn6.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn6.FieldName = "CITY HEADING"
        Me.LayoutViewColumn6.LayoutViewField = Me.layoutViewField_colCITYHEADING
        Me.LayoutViewColumn6.Name = "LayoutViewColumn6"
        '
        'layoutViewField_colCITYHEADING
        '
        Me.layoutViewField_colCITYHEADING.EditorPreferredWidth = 371
        Me.layoutViewField_colCITYHEADING.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colCITYHEADING.Name = "layoutViewField_colCITYHEADING"
        Me.layoutViewField_colCITYHEADING.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCITYHEADING.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn7
        '
        Me.LayoutViewColumn7.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn7.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn7.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn7.LayoutViewField = Me.layoutViewField_colSUBTYPEINDICATION
        Me.LayoutViewColumn7.Name = "LayoutViewColumn7"
        '
        'layoutViewField_colSUBTYPEINDICATION
        '
        Me.layoutViewField_colSUBTYPEINDICATION.EditorPreferredWidth = 86
        Me.layoutViewField_colSUBTYPEINDICATION.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colSUBTYPEINDICATION.Name = "layoutViewField_colSUBTYPEINDICATION"
        Me.layoutViewField_colSUBTYPEINDICATION.Size = New System.Drawing.Size(206, 20)
        Me.layoutViewField_colSUBTYPEINDICATION.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn8
        '
        Me.LayoutViewColumn8.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn8.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn8.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn8.LayoutViewField = Me.layoutViewField_colVALUEADDEDSERVICES
        Me.LayoutViewColumn8.Name = "LayoutViewColumn8"
        '
        'layoutViewField_colVALUEADDEDSERVICES
        '
        Me.layoutViewField_colVALUEADDEDSERVICES.EditorPreferredWidth = 371
        Me.layoutViewField_colVALUEADDEDSERVICES.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colVALUEADDEDSERVICES.Name = "layoutViewField_colVALUEADDEDSERVICES"
        Me.layoutViewField_colVALUEADDEDSERVICES.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colVALUEADDEDSERVICES.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn9
        '
        Me.LayoutViewColumn9.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn9.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn9.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn9.LayoutViewField = Me.layoutViewField_colEXTRAINFO
        Me.LayoutViewColumn9.Name = "LayoutViewColumn9"
        '
        'layoutViewField_colEXTRAINFO
        '
        Me.layoutViewField_colEXTRAINFO.EditorPreferredWidth = 383
        Me.layoutViewField_colEXTRAINFO.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colEXTRAINFO.Name = "layoutViewField_colEXTRAINFO"
        Me.layoutViewField_colEXTRAINFO.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colEXTRAINFO.TextSize = New System.Drawing.Size(111, 13)
        '
        'LayoutViewColumn10
        '
        Me.LayoutViewColumn10.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn10.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn10.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn10.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS1
        Me.LayoutViewColumn10.Name = "LayoutViewColumn10"
        '
        'layoutViewField_colPHYSICALADDRESS1
        '
        Me.layoutViewField_colPHYSICALADDRESS1.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colPHYSICALADDRESS1.Name = "layoutViewField_colPHYSICALADDRESS1"
        Me.layoutViewField_colPHYSICALADDRESS1.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS1.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn11
        '
        Me.LayoutViewColumn11.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn11.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn11.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn11.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS2
        Me.LayoutViewColumn11.Name = "LayoutViewColumn11"
        '
        'layoutViewField_colPHYSICALADDRESS2
        '
        Me.layoutViewField_colPHYSICALADDRESS2.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS2.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colPHYSICALADDRESS2.Name = "layoutViewField_colPHYSICALADDRESS2"
        Me.layoutViewField_colPHYSICALADDRESS2.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS2.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn12
        '
        Me.LayoutViewColumn12.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn12.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn12.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn12.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS3
        Me.LayoutViewColumn12.Name = "LayoutViewColumn12"
        '
        'layoutViewField_colPHYSICALADDRESS3
        '
        Me.layoutViewField_colPHYSICALADDRESS3.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS3.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colPHYSICALADDRESS3.Name = "layoutViewField_colPHYSICALADDRESS3"
        Me.layoutViewField_colPHYSICALADDRESS3.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS3.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn13
        '
        Me.LayoutViewColumn13.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn13.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn13.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn13.LayoutViewField = Me.layoutViewField_colPHYSICALADDRESS4
        Me.LayoutViewColumn13.Name = "LayoutViewColumn13"
        '
        'layoutViewField_colPHYSICALADDRESS4
        '
        Me.layoutViewField_colPHYSICALADDRESS4.EditorPreferredWidth = 384
        Me.layoutViewField_colPHYSICALADDRESS4.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colPHYSICALADDRESS4.Name = "layoutViewField_colPHYSICALADDRESS4"
        Me.layoutViewField_colPHYSICALADDRESS4.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPHYSICALADDRESS4.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn14
        '
        Me.LayoutViewColumn14.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn14.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn14.FieldName = "LOCATION"
        Me.LayoutViewColumn14.LayoutViewField = Me.layoutViewField_colLOCATION
        Me.LayoutViewColumn14.Name = "LayoutViewColumn14"
        '
        'layoutViewField_colLOCATION
        '
        Me.layoutViewField_colLOCATION.EditorPreferredWidth = 384
        Me.layoutViewField_colLOCATION.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colLOCATION.Name = "layoutViewField_colLOCATION"
        Me.layoutViewField_colLOCATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colLOCATION.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn15
        '
        Me.LayoutViewColumn15.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn15.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn15.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn15.LayoutViewField = Me.layoutViewField_colCOUNTRYNAME
        Me.LayoutViewColumn15.Name = "LayoutViewColumn15"
        '
        'layoutViewField_colCOUNTRYNAME
        '
        Me.layoutViewField_colCOUNTRYNAME.EditorPreferredWidth = 384
        Me.layoutViewField_colCOUNTRYNAME.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colCOUNTRYNAME.Name = "layoutViewField_colCOUNTRYNAME"
        Me.layoutViewField_colCOUNTRYNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCOUNTRYNAME.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn16
        '
        Me.LayoutViewColumn16.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn16.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn16.FieldName = "POB NUMBER"
        Me.LayoutViewColumn16.LayoutViewField = Me.layoutViewField_colPOBNUMBER
        Me.LayoutViewColumn16.Name = "LayoutViewColumn16"
        '
        'layoutViewField_colPOBNUMBER
        '
        Me.layoutViewField_colPOBNUMBER.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBNUMBER.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colPOBNUMBER.Name = "layoutViewField_colPOBNUMBER"
        Me.layoutViewField_colPOBNUMBER.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBNUMBER.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn17
        '
        Me.LayoutViewColumn17.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn17.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn17.FieldName = "POB LOCATION"
        Me.LayoutViewColumn17.LayoutViewField = Me.layoutViewField_colPOBLOCATION
        Me.LayoutViewColumn17.Name = "LayoutViewColumn17"
        '
        'layoutViewField_colPOBLOCATION
        '
        Me.layoutViewField_colPOBLOCATION.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBLOCATION.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colPOBLOCATION.Name = "layoutViewField_colPOBLOCATION"
        Me.layoutViewField_colPOBLOCATION.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBLOCATION.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn18
        '
        Me.LayoutViewColumn18.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn18.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn18.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn18.LayoutViewField = Me.layoutViewField_colPOBCOUNTRYNAME
        Me.LayoutViewColumn18.Name = "LayoutViewColumn18"
        '
        'layoutViewField_colPOBCOUNTRYNAME
        '
        Me.layoutViewField_colPOBCOUNTRYNAME.EditorPreferredWidth = 384
        Me.layoutViewField_colPOBCOUNTRYNAME.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colPOBCOUNTRYNAME.Name = "layoutViewField_colPOBCOUNTRYNAME"
        Me.layoutViewField_colPOBCOUNTRYNAME.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colPOBCOUNTRYNAME.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn19
        '
        Me.LayoutViewColumn19.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn19.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn19.CustomizationCaption = "USER"
        Me.LayoutViewColumn19.FieldName = "USER"
        Me.LayoutViewColumn19.LayoutViewField = Me.layoutViewField_colUSER2
        Me.LayoutViewColumn19.Name = "LayoutViewColumn19"
        Me.LayoutViewColumn19.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colUSER2
        '
        Me.layoutViewField_colUSER2.EditorPreferredWidth = 20
        Me.layoutViewField_colUSER2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUSER2.Name = "layoutViewField_colUSER2"
        Me.layoutViewField_colUSER2.Size = New System.Drawing.Size(527, 612)
        Me.layoutViewField_colUSER2.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn20
        '
        Me.LayoutViewColumn20.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn20.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn20.ColumnEdit = Me.BUNDESLANDRepositoryItemComboBox
        Me.LayoutViewColumn20.FieldName = "VALID"
        Me.LayoutViewColumn20.LayoutViewField = Me.layoutViewField_colVALID
        Me.LayoutViewColumn20.Name = "LayoutViewColumn20"
        '
        'layoutViewField_colVALID
        '
        Me.layoutViewField_colVALID.EditorPreferredWidth = 30
        Me.layoutViewField_colVALID.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colVALID.Name = "layoutViewField_colVALID"
        Me.layoutViewField_colVALID.Size = New System.Drawing.Size(162, 20)
        Me.layoutViewField_colVALID.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn21
        '
        Me.LayoutViewColumn21.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn21.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn21.CustomizationCaption = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn21.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn21.LayoutViewField = Me.LayoutViewField48
        Me.LayoutViewColumn21.Name = "LayoutViewColumn21"
        Me.LayoutViewColumn21.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField48
        '
        Me.LayoutViewField48.EditorPreferredWidth = 20
        Me.LayoutViewField48.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField48.Name = "LayoutViewField48"
        Me.LayoutViewField48.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField48.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn22
        '
        Me.LayoutViewColumn22.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn22.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn22.CustomizationCaption = "BIC11"
        Me.LayoutViewColumn22.FieldName = "BIC11"
        Me.LayoutViewColumn22.LayoutViewField = Me.layoutViewField_colBIC112
        Me.LayoutViewColumn22.Name = "LayoutViewColumn22"
        Me.LayoutViewColumn22.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBIC112
        '
        Me.layoutViewField_colBIC112.EditorPreferredWidth = 20
        Me.layoutViewField_colBIC112.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBIC112.Name = "layoutViewField_colBIC112"
        Me.layoutViewField_colBIC112.Size = New System.Drawing.Size(527, 612)
        Me.layoutViewField_colBIC112.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn23
        '
        Me.LayoutViewColumn23.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn23.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn23.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn23.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn23.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn23.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn23.ColumnEdit = Me.RepositoryItemTextEditBIC8
        Me.LayoutViewColumn23.FieldName = "BIC CODE"
        Me.LayoutViewColumn23.LayoutViewField = Me.layoutViewField_colBICCODE
        Me.LayoutViewColumn23.Name = "LayoutViewColumn23"
        '
        'layoutViewField_colBICCODE
        '
        Me.layoutViewField_colBICCODE.EditorPreferredWidth = 93
        Me.layoutViewField_colBICCODE.ImageOptions.ImageIndex = 0
        Me.layoutViewField_colBICCODE.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBICCODE.Name = "layoutViewField_colBICCODE"
        Me.layoutViewField_colBICCODE.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colBICCODE.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn24
        '
        Me.LayoutViewColumn24.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn24.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn24.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn24.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn24.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn24.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn24.ColumnEdit = Me.RepositoryItemTextEditBIC3
        Me.LayoutViewColumn24.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn24.LayoutViewField = Me.layoutViewField_colBRANCHCODE
        Me.LayoutViewColumn24.Name = "LayoutViewColumn24"
        '
        'layoutViewField_colBRANCHCODE
        '
        Me.layoutViewField_colBRANCHCODE.EditorPreferredWidth = 51
        Me.layoutViewField_colBRANCHCODE.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colBRANCHCODE.Name = "layoutViewField_colBRANCHCODE"
        Me.layoutViewField_colBRANCHCODE.Size = New System.Drawing.Size(183, 20)
        Me.layoutViewField_colBRANCHCODE.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn25
        '
        Me.LayoutViewColumn25.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn25.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn25.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn25.FieldName = "COUNTRY"
        Me.LayoutViewColumn25.LayoutViewField = Me.layoutViewField_colCOUNTRY
        Me.LayoutViewColumn25.Name = "LayoutViewColumn25"
        Me.LayoutViewColumn25.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCOUNTRY
        '
        Me.layoutViewField_colCOUNTRY.EditorPreferredWidth = 384
        Me.layoutViewField_colCOUNTRY.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colCOUNTRY.Name = "layoutViewField_colCOUNTRY"
        Me.layoutViewField_colCOUNTRY.Size = New System.Drawing.Size(503, 20)
        Me.layoutViewField_colCOUNTRY.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CaptionImageOptions.Location = DevExpress.Utils.GroupElementLocation.BeforeText
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'KapiSoliDetails_BasicView
        '
        Me.KapiSoliDetails_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.KapiSoliDetails_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.KapiSoliDetails_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.KapiSoliDetails_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.KapiSoliDetails_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.KapiSoliDetails_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.colValDateFrom, Me.colValDate, Me.colCustomer, Me.colValYear, Me.colCustomerName, Me.colAccount, Me.colRegistrationCountry, Me.colContract, Me.colCCY, Me.colProduct, Me.colAmount, Me.colExchangeRate, Me.colAmountEuro, Me.colDB, Me.colKapertstG, Me.colRemark, Me.colSoli, Me.colKAPISTPFLICHTIG1, Me.colBUNDESLAND1, Me.colIdValueCustomer, Me.colIdZinsertragsMonat, Me.colIdErtragJahr, Me.colIdKDSTAMM})
        Me.KapiSoliDetails_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.KapiSoliDetails_BasicView.GridControl = Me.GridControl1
        Me.KapiSoliDetails_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KUNDEN MONAT_FK00.ZINSERTRAG KUNDEN DETAILS_FK00.KapertstG", Me.colKapertstG, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ZINSERTRAG KUNDEN MONAT_FK00.ZINSERTRAG KUNDEN DETAILS_FK00.Soli", Me.colSoli, "{0:n2}")})
        Me.KapiSoliDetails_BasicView.Name = "KapiSoliDetails_BasicView"
        Me.KapiSoliDetails_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.KapiSoliDetails_BasicView.OptionsFind.AlwaysVisible = True
        Me.KapiSoliDetails_BasicView.OptionsView.ColumnAutoWidth = False
        Me.KapiSoliDetails_BasicView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.KapiSoliDetails_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.KapiSoliDetails_BasicView.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Width = 67
        '
        'colValDateFrom
        '
        Me.colValDateFrom.AppearanceCell.Options.UseTextOptions = True
        Me.colValDateFrom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValDateFrom.Caption = "Zeitraum von"
        Me.colValDateFrom.FieldName = "ValDateFrom"
        Me.colValDateFrom.Name = "colValDateFrom"
        Me.colValDateFrom.OptionsColumn.AllowEdit = False
        Me.colValDateFrom.OptionsColumn.ReadOnly = True
        Me.colValDateFrom.Width = 80
        '
        'colValDate
        '
        Me.colValDate.AppearanceCell.Options.UseTextOptions = True
        Me.colValDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValDate.Caption = "Zeitraum bis"
        Me.colValDate.FieldName = "ValDate"
        Me.colValDate.Name = "colValDate"
        Me.colValDate.OptionsColumn.AllowEdit = False
        Me.colValDate.OptionsColumn.ReadOnly = True
        Me.colValDate.Width = 80
        '
        'colCustomer
        '
        Me.colCustomer.AppearanceCell.Options.UseTextOptions = True
        Me.colCustomer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCustomer.Caption = "Stamm Nr."
        Me.colCustomer.FieldName = "Customer"
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.OptionsColumn.AllowEdit = False
        Me.colCustomer.OptionsColumn.ReadOnly = True
        Me.colCustomer.Visible = True
        Me.colCustomer.VisibleIndex = 1
        Me.colCustomer.Width = 229
        '
        'colValYear
        '
        Me.colValYear.AppearanceCell.Options.UseTextOptions = True
        Me.colValYear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValYear.Caption = "Jahr"
        Me.colValYear.FieldName = "ValYear"
        Me.colValYear.Name = "colValYear"
        Me.colValYear.OptionsColumn.AllowEdit = False
        Me.colValYear.OptionsColumn.ReadOnly = True
        Me.colValYear.Width = 51
        '
        'colCustomerName
        '
        Me.colCustomerName.Caption = "Kundenname"
        Me.colCustomerName.FieldName = "CustomerName"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.OptionsColumn.AllowEdit = False
        Me.colCustomerName.OptionsColumn.ReadOnly = True
        Me.colCustomerName.Visible = True
        Me.colCustomerName.VisibleIndex = 2
        Me.colCustomerName.Width = 379
        '
        'colAccount
        '
        Me.colAccount.Caption = "Konto Nr."
        Me.colAccount.FieldName = "Account"
        Me.colAccount.Name = "colAccount"
        Me.colAccount.OptionsColumn.AllowEdit = False
        Me.colAccount.OptionsColumn.ReadOnly = True
        Me.colAccount.Width = 116
        '
        'colRegistrationCountry
        '
        Me.colRegistrationCountry.AppearanceCell.Options.UseTextOptions = True
        Me.colRegistrationCountry.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRegistrationCountry.Caption = "Registrierungsland"
        Me.colRegistrationCountry.FieldName = "RegistrationCountry"
        Me.colRegistrationCountry.Name = "colRegistrationCountry"
        Me.colRegistrationCountry.OptionsColumn.AllowEdit = False
        Me.colRegistrationCountry.OptionsColumn.ReadOnly = True
        Me.colRegistrationCountry.Width = 101
        '
        'colContract
        '
        Me.colContract.AppearanceCell.Options.UseTextOptions = True
        Me.colContract.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colContract.FieldName = "Contract"
        Me.colContract.Name = "colContract"
        Me.colContract.OptionsColumn.AllowEdit = False
        Me.colContract.OptionsColumn.ReadOnly = True
        Me.colContract.Width = 63
        '
        'colCCY
        '
        Me.colCCY.FieldName = "CCY"
        Me.colCCY.Name = "colCCY"
        Me.colCCY.OptionsColumn.AllowEdit = False
        Me.colCCY.OptionsColumn.ReadOnly = True
        Me.colCCY.Width = 50
        '
        'colProduct
        '
        Me.colProduct.AppearanceCell.Options.UseTextOptions = True
        Me.colProduct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colProduct.FieldName = "Product"
        Me.colProduct.Name = "colProduct"
        Me.colProduct.OptionsColumn.AllowEdit = False
        Me.colProduct.OptionsColumn.ReadOnly = True
        Me.colProduct.Width = 62
        '
        'colAmount
        '
        Me.colAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmount.Caption = "Zinsertrag"
        Me.colAmount.DisplayFormat.FormatString = "n2"
        Me.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount.FieldName = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.OptionsColumn.AllowEdit = False
        Me.colAmount.OptionsColumn.ReadOnly = True
        Me.colAmount.Width = 67
        '
        'colExchangeRate
        '
        Me.colExchangeRate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchangeRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchangeRate.Caption = "Wechselkurs"
        Me.colExchangeRate.DisplayFormat.FormatString = "n5"
        Me.colExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchangeRate.FieldName = "ExchangeRate"
        Me.colExchangeRate.Name = "colExchangeRate"
        Me.colExchangeRate.OptionsColumn.AllowEdit = False
        Me.colExchangeRate.OptionsColumn.ReadOnly = True
        Me.colExchangeRate.Width = 70
        '
        'colAmountEuro
        '
        Me.colAmountEuro.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountEuro.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountEuro.Caption = "Zinsertrag in Euro"
        Me.colAmountEuro.DisplayFormat.FormatString = "n2"
        Me.colAmountEuro.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountEuro.FieldName = "AmountEuro"
        Me.colAmountEuro.Name = "colAmountEuro"
        Me.colAmountEuro.OptionsColumn.AllowEdit = False
        Me.colAmountEuro.OptionsColumn.ReadOnly = True
        Me.colAmountEuro.Width = 95
        '
        'colDB
        '
        Me.colDB.FieldName = "DB"
        Me.colDB.Name = "colDB"
        Me.colDB.OptionsColumn.AllowEdit = False
        Me.colDB.OptionsColumn.ReadOnly = True
        Me.colDB.Width = 50
        '
        'colKapertstG
        '
        Me.colKapertstG.AppearanceCell.Options.UseTextOptions = True
        Me.colKapertstG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colKapertstG.Caption = "Kapitalertragssteuer"
        Me.colKapertstG.DisplayFormat.FormatString = "n2"
        Me.colKapertstG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colKapertstG.FieldName = "KapertstG"
        Me.colKapertstG.Name = "colKapertstG"
        Me.colKapertstG.OptionsColumn.AllowEdit = False
        Me.colKapertstG.OptionsColumn.ReadOnly = True
        Me.colKapertstG.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KapertstG", "{0:n2}")})
        Me.colKapertstG.Visible = True
        Me.colKapertstG.VisibleIndex = 4
        Me.colKapertstG.Width = 111
        '
        'colRemark
        '
        Me.colRemark.Caption = "Info"
        Me.colRemark.FieldName = "Remark"
        Me.colRemark.Name = "colRemark"
        Me.colRemark.OptionsColumn.AllowEdit = False
        Me.colRemark.OptionsColumn.ReadOnly = True
        Me.colRemark.Visible = True
        Me.colRemark.VisibleIndex = 6
        Me.colRemark.Width = 274
        '
        'colSoli
        '
        Me.colSoli.AppearanceCell.Options.UseTextOptions = True
        Me.colSoli.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colSoli.Caption = "Solidaritätszuschlag"
        Me.colSoli.DisplayFormat.FormatString = "n2"
        Me.colSoli.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSoli.FieldName = "Soli"
        Me.colSoli.Name = "colSoli"
        Me.colSoli.OptionsColumn.AllowEdit = False
        Me.colSoli.OptionsColumn.ReadOnly = True
        Me.colSoli.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Soli", "{0:n2}")})
        Me.colSoli.Visible = True
        Me.colSoli.VisibleIndex = 5
        Me.colSoli.Width = 104
        '
        'colKAPISTPFLICHTIG1
        '
        Me.colKAPISTPFLICHTIG1.FieldName = "KAPISTPFLICHTIG"
        Me.colKAPISTPFLICHTIG1.Name = "colKAPISTPFLICHTIG1"
        Me.colKAPISTPFLICHTIG1.OptionsColumn.AllowEdit = False
        Me.colKAPISTPFLICHTIG1.OptionsColumn.ReadOnly = True
        Me.colKAPISTPFLICHTIG1.Visible = True
        Me.colKAPISTPFLICHTIG1.VisibleIndex = 7
        Me.colKAPISTPFLICHTIG1.Width = 118
        '
        'colBUNDESLAND1
        '
        Me.colBUNDESLAND1.FieldName = "BUNDESLAND"
        Me.colBUNDESLAND1.Name = "colBUNDESLAND1"
        Me.colBUNDESLAND1.OptionsColumn.AllowEdit = False
        Me.colBUNDESLAND1.OptionsColumn.ReadOnly = True
        Me.colBUNDESLAND1.Visible = True
        Me.colBUNDESLAND1.VisibleIndex = 3
        Me.colBUNDESLAND1.Width = 275
        '
        'colIdValueCustomer
        '
        Me.colIdValueCustomer.FieldName = "IdValueCustomer"
        Me.colIdValueCustomer.Name = "colIdValueCustomer"
        Me.colIdValueCustomer.OptionsColumn.AllowEdit = False
        Me.colIdValueCustomer.OptionsColumn.ReadOnly = True
        Me.colIdValueCustomer.Width = 50
        '
        'colIdZinsertragsMonat
        '
        Me.colIdZinsertragsMonat.Caption = "Meldemonat"
        Me.colIdZinsertragsMonat.FieldName = "IdZinsertragsMonat"
        Me.colIdZinsertragsMonat.Name = "colIdZinsertragsMonat"
        Me.colIdZinsertragsMonat.OptionsColumn.AllowEdit = False
        Me.colIdZinsertragsMonat.OptionsColumn.ReadOnly = True
        Me.colIdZinsertragsMonat.Visible = True
        Me.colIdZinsertragsMonat.VisibleIndex = 0
        Me.colIdZinsertragsMonat.Width = 165
        '
        'colIdErtragJahr
        '
        Me.colIdErtragJahr.FieldName = "IdErtragJahr"
        Me.colIdErtragJahr.Name = "colIdErtragJahr"
        Me.colIdErtragJahr.OptionsColumn.AllowEdit = False
        Me.colIdErtragJahr.OptionsColumn.ReadOnly = True
        Me.colIdErtragJahr.Width = 50
        '
        'colIdKDSTAMM
        '
        Me.colIdKDSTAMM.FieldName = "IdKDSTAMM"
        Me.colIdKDSTAMM.Name = "colIdKDSTAMM"
        Me.colIdKDSTAMM.OptionsColumn.AllowEdit = False
        Me.colIdKDSTAMM.OptionsColumn.ReadOnly = True
        Me.colIdKDSTAMM.Width = 100
        '
        'ZINSERTRAG_KUNDEN_JAHRTableAdapter
        '
        Me.ZINSERTRAG_KUNDEN_JAHRTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_DETAILSTableAdapter = Me.ZINSERTRAG_KUNDEN_DETAILSTableAdapter
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_JAHRTableAdapter = Me.ZINSERTRAG_KUNDEN_JAHRTableAdapter
        Me.TableAdapterManager.ZINSERTRAG_KUNDEN_MONATTableAdapter = Me.ZINSERTRAG_KUNDEN_MONATTableAdapter
        Me.TableAdapterManager.ZVSTA_FormsTill2013TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTA_ProdTill2013TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Details_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_MeldeJahr_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Meldepositionen_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Meldeschemas_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTAT_Parameters_from2014TableAdapter = Nothing
        Me.TableAdapterManager.ZVSTATill2013TableAdapter = Nothing
        '
        'ZINSERTRAG_KUNDEN_DETAILSTableAdapter
        '
        Me.ZINSERTRAG_KUNDEN_DETAILSTableAdapter.ClearBeforeFill = True
        '
        'ZINSERTRAG_KUNDEN_MONATTableAdapter
        '
        Me.ZINSERTRAG_KUNDEN_MONATTableAdapter.ClearBeforeFill = True
        '
        'ZINSERTRAG_KUNDEN_MONATBindingSource
        '
        Me.ZINSERTRAG_KUNDEN_MONATBindingSource.DataMember = "ZINSERTRAG KUNDEN MONAT_FK00"
        Me.ZINSERTRAG_KUNDEN_MONATBindingSource.DataSource = Me.ZINSERTRAG_KUNDEN_JAHRBindingSource
        '
        'ZINSERTRAG_KUNDEN_DETAILSBindingSource
        '
        Me.ZINSERTRAG_KUNDEN_DETAILSBindingSource.DataMember = "ZINSERTRAG KUNDEN DETAILS_FK00"
        Me.ZINSERTRAG_KUNDEN_DETAILSBindingSource.DataSource = Me.ZINSERTRAG_KUNDEN_MONATBindingSource
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PopupContainerEdit1)
        Me.LayoutControl1.Controls.Add(Me.SteuerbescheinigungenReportsDropDownButton)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_KapiSoliMeldungen_BasicView_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1265, 684)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PopupContainerEdit1
        '
        Me.PopupContainerEdit1.Location = New System.Drawing.Point(111, 62)
        Me.PopupContainerEdit1.Name = "PopupContainerEdit1"
        Me.PopupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit1.Size = New System.Drawing.Size(50, 20)
        Me.PopupContainerEdit1.StyleController = Me.LayoutControl1
        Me.PopupContainerEdit1.TabIndex = 8
        '
        'SteuerbescheinigungenReportsDropDownButton
        '
        Me.SteuerbescheinigungenReportsDropDownButton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.SteuerbescheinigungenReportsDropDownButton.DropDownControl = Me.PopupMenu1
        Me.SteuerbescheinigungenReportsDropDownButton.ImageOptions.ImageIndex = 7
        Me.SteuerbescheinigungenReportsDropDownButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.SteuerbescheinigungenReportsDropDownButton.Location = New System.Drawing.Point(168, 24)
        Me.SteuerbescheinigungenReportsDropDownButton.Name = "SteuerbescheinigungenReportsDropDownButton"
        Me.SteuerbescheinigungenReportsDropDownButton.Size = New System.Drawing.Size(211, 22)
        Me.SteuerbescheinigungenReportsDropDownButton.StyleController = Me.LayoutControl1
        Me.SteuerbescheinigungenReportsDropDownButton.TabIndex = 7
        Me.SteuerbescheinigungenReportsDropDownButton.Text = "MELDUNGEN + REPORTS"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MeldungKapiSoli_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.KapiSoliReportMonatlich_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'MeldungKapiSoli_BarButtonItem
        '
        Me.MeldungKapiSoli_BarButtonItem.Caption = "Kapi/Soli Meldung generieren"
        Me.MeldungKapiSoli_BarButtonItem.Id = 3
        Me.MeldungKapiSoli_BarButtonItem.ImageOptions.ImageIndex = 8
        Me.MeldungKapiSoli_BarButtonItem.Name = "MeldungKapiSoli_BarButtonItem"
        '
        'KapiSoliReportMonatlich_BarButtonItem
        '
        Me.KapiSoliReportMonatlich_BarButtonItem.Caption = "Kapi/Soli-Monatlicher Report"
        Me.KapiSoliReportMonatlich_BarButtonItem.Id = 1
        Me.KapiSoliReportMonatlich_BarButtonItem.ImageOptions.ImageIndex = 7
        Me.KapiSoliReportMonatlich_BarButtonItem.Name = "KapiSoliReportMonatlich_BarButtonItem"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Kapi/Soli-Jährlicher Report"
        Me.BarSubItem1.Id = 5
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Images = Me.ImageCollection1
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.KapiSoliMeldung_BarButtonItem, Me.KapiSoliReportMonatlich_BarButtonItem, Me.InterestRateRiskHUMPBarButtonItem, Me.MeldungKapiSoli_BarButtonItem, Me.BarSubItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 6
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 1
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Offset = 848
        Me.Bar1.Text = "Tools"
        Me.Bar1.Visible = False
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.Text = "Main menu"
        Me.Bar2.Visible = False
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1265, 29)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 713)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1265, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 29)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 684)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1265, 29)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 684)
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
        Me.ImageCollection1.Images.SetKeyName(8, "PDF.ico")
        '
        'KapiSoliMeldung_BarButtonItem
        '
        Me.KapiSoliMeldung_BarButtonItem.Caption = "MELDUNG ERSTELLEN"
        Me.KapiSoliMeldung_BarButtonItem.Id = 0
        Me.KapiSoliMeldung_BarButtonItem.ImageOptions.ImageIndex = 8
        Me.KapiSoliMeldung_BarButtonItem.Name = "KapiSoliMeldung_BarButtonItem"
        '
        'InterestRateRiskHUMPBarButtonItem
        '
        Me.InterestRateRiskHUMPBarButtonItem.Caption = "INTEREST RATE RISK (HUMP-TWIST1 - TWIST2)"
        Me.InterestRateRiskHUMPBarButtonItem.Id = 2
        Me.InterestRateRiskHUMPBarButtonItem.ImageOptions.ImageIndex = 7
        Me.InterestRateRiskHUMPBarButtonItem.Name = "InterestRateRiskHUMPBarButtonItem"
        Me.InterestRateRiskHUMPBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'Print_Export_KapiSoliMeldungen_BasicView_btn
        '
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.Name = "Print_Export_KapiSoliMeldungen_BasicView_btn"
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.Size = New System.Drawing.Size(140, 22)
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.TabIndex = 6
        Me.Print_Export_KapiSoliMeldungen_BasicView_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1061, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(180, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PopupContainerEdit1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(153, 649)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1265, 684)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1245, 614)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem7})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1245, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1037, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(184, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(359, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(678, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_KapiSoliMeldungen_BasicView_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(144, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SteuerbescheinigungenReportsDropDownButton
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(144, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(215, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
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
        'KapiSoliMeldungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 736)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "KapiSoliMeldungen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kapitalertragsteuer und Soli Meldungen"
        CType(Me.KapiSoliMonat_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZINSERTRAG_KUNDEN_JAHRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeldewesenDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KapiSoliJahr_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BUNDESLANDRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEXTERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFINITIONRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KAPITALSTPFLRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colIdnr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTAG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMODIFICATIONFLAG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colINSTITUTIONNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBRANCHINFORMATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCITYHEADING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSUBTYPEINDICATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALUEADDEDSERVICES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colEXTRAINFO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPHYSICALADDRESS4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLOCATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRYNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBNUMBER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBLOCATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPOBCOUNTRYNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUSER2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVALID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBICCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBRANCHCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCOUNTRY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KapiSoliDetails_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZINSERTRAG_KUNDEN_MONATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZINSERTRAG_KUNDEN_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MeldewesenDataSet As PS_TOOL_DX.MeldewesenDataSet
    Friend WithEvents ZINSERTRAG_KUNDEN_JAHRBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZINSERTRAG_KUNDEN_JAHRTableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_JAHRTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.MeldewesenDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ZINSERTRAG_KUNDEN_MONATTableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_MONATTableAdapter
    Friend WithEvents ZINSERTRAG_KUNDEN_MONATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZINSERTRAG_KUNDEN_DETAILSTableAdapter As PS_TOOL_DX.MeldewesenDataSetTableAdapters.ZINSERTRAG_KUNDEN_DETAILSTableAdapter
    Friend WithEvents ZINSERTRAG_KUNDEN_DETAILSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PopupContainerEdit1 As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents SteuerbescheinigungenReportsDropDownButton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Print_Export_KapiSoliMeldungen_BasicView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents KapiSoliJahr_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BUNDESLANDRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents TEXTERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents DEFINITIONRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents KAPITALSTPFLRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents KapiSoliMonat_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colIdnr As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colTAG As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn3 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMODIFICATIONFLAG As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn4 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colINSTITUTIONNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn5 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBRANCHINFORMATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn6 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCITYHEADING As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn7 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSUBTYPEINDICATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn8 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALUEADDEDSERVICES As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn9 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colEXTRAINFO As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn10 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn11 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn12 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn13 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPHYSICALADDRESS4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn14 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLOCATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn15 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCOUNTRYNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn16 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBNUMBER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn17 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBLOCATION As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn18 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPOBCOUNTRYNAME As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn19 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUSER2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn20 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVALID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn21 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField48 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn22 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC112 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn23 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBICCODE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn24 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBRANCHCODE As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn25 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCOUNTRY As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents KapiSoliMeldung_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents KapiSoliReportMonatlich_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents InterestRateRiskHUMPBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZinsertragsmonat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSummeKapErSt1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSummeSoli1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdZinsertragJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZinsertragsmonatDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KapiSoliDetails_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValDateFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRegistrationCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContract As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchangeRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountEuro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKapertstG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSoli As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKAPISTPFLICHTIG1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBUNDESLAND1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdValueCustomer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdZinsertragsMonat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdErtragJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdKDSTAMM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colErtragsJahr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSummeKapErSt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSummeSoli As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MeldungKapiSoli_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
