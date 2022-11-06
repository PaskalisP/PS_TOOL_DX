<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StressTests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StressTests))
        Me.BT_ST_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryofRisk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountryofResidence = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInternalCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinessType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCUSTOMERTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractCollateralID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreditExposure = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccruedInterest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEuroEquivalent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStressPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStressNewAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPDAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBusinessTypeLive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.StressTestsLiveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MAK_CR_TOTALSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RiskControllingDataSet = New PS_TOOL_DX.RiskControllingDataSet()
        Me.BT_ST_Totals_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinesType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colPDunderStress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colAmountBusinessType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQLBusinessTypeDefinition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQLBusinessTypeAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStressNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colDateMakCrTotals = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
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
        Me.MAK_CR_TOTALSTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.MAK_CR_TOTALSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager()
        Me.StressTestsLiveDetailsTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsLiveDetailsTableAdapter()
        Me.StressTestsLiveTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsLiveTableAdapter()
        Me.StressTestsTempTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsTempTableAdapter()
        Me.StressTestsLiveDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadBusinessTypes_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BusinessTypeDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.StressTestsTempBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.BT_ST_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SQL_Commands_Dropdownbutton = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.SQL_Run_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_ReRun_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_ReRun_Period_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_ReRun_AllDays_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Print_Export_BT_ST_Totals_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.StressTestsBusinessTyperReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BT_ST_GEN_PARAM_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_BT_ST_Temp_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_INTERBANKV_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.BT_ST_Temp_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinesType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colPDunderStress1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colAmountBusinessType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQLBusinessTypeDefinition1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQLBusinessTypeAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LayoutView4 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn51 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn52 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField49 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn53 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBankleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn54 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBIC = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn55 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn56 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField50 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn57 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField51 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn58 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField52 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn59 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField53 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn60 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladresseFirma = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn61 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladresseOrt = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn62 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladressePostfach = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn63 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colZustelladressePostleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn64 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungFirma = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn65 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungPostfach = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn66 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungStraße = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn67 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungPostleitzahl = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn68 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colRücksendungOrt = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn69 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colInstitutstyp = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn70 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBLZdervorgeschaltetenStelle = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn71 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn72 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn73 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn74 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField54 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn75 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField55 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn76 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn77 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField56 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn78 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField57 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn79 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField58 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn80 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField59 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn81 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn82 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn83 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn84 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colScheckanfrageEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn85 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField60 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn86 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField61 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn87 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField62 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn88 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField63 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn89 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField64 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn90 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colLastschriftrückrufEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn91 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn92 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn93 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colWechselrückrufeEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn94 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn95 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn96 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUnbezahlteWechselEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn97 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleTEL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn98 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleFAX = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn99 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colVorgeschalteteStelleEMAIL = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn100 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMeldeweg = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn101 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField65 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn102 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUSER = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn103 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colUNTERBEARBEITUNGVON = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutView3 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutView2 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn26 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn27 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn28 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn29 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn30 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn31 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn32 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn33 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn34 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn35 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField10 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn36 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField11 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn37 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField12 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn38 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField13 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn39 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField14 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn40 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField15 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn41 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField16 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn42 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField17 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn43 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField18 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn44 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField19 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn45 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField20 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn46 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField21 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn47 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField22 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn48 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField23 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn49 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField24 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn50 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField25 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.BgwSQL_Run = New System.ComponentModel.BackgroundWorker()
        Me.BgwSQL_ReRun = New System.ComponentModel.BackgroundWorker()
        Me.BgwSQL_ReRun_SpecificPeriod = New System.ComponentModel.BackgroundWorker()
        Me.BgwSQL_ReRun_All_Days = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.BT_ST_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StressTestsLiveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAK_CR_TOTALSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskControllingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_ST_Totals_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.StressTestsLiveDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessTypeDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessTypeDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StressTestsTempBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.BT_ST_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BT_ST_GEN_PARAM_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_ST_Temp_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBankleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladresseFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladresseOrt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladressePostfach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colZustelladressePostleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungPostfach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungStraße, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungPostleitzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRücksendungOrt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInstitutstyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBLZdervorgeschaltetenStelle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colÜberweisungsnachfragenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colÜberweisungsrückfragenEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colScheckanfrageEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colLastschriftrückrufEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colWechselrückrufeEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUnbezahlteWechselEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleTEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleFAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleEMAIL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMeldeweg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BT_ST_Details_GridView
        '
        Me.BT_ST_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_ST_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_ST_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_ST_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_ST_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_ST_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colContractType, Me.colProductType, Me.GridColumn1, Me.colAccountType, Me.GridColumn2, Me.colClientNo, Me.colCountryofRisk, Me.colCountryofResidence, Me.GridColumn3, Me.colInternalCode, Me.colBusinessType, Me.colCUSTOMERTYPE, Me.colClientGroup, Me.colContractCollateralID, Me.colStartDate, Me.colMaturityDate, Me.colOrgCcy, Me.colCreditExposure, Me.colAccruedInterest, Me.colEuroEquivalent, Me.colStressPercent, Me.colStressNewAmount, Me.colPDAmount, Me.colRiskDate, Me.colIdBusinessTypeLive})
        Me.BT_ST_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_ST_Details_GridView.GridControl = Me.GridControl1
        Me.BT_ST_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_StressTestsLiveDetails_StressTestsLive.Euro Equivalent", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_StressTestsLiveDetails_StressTestsLive.StressNewAmount", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_StressTestsLiveDetails_StressTestsLive.PDAmount", Nothing, "{0:n2}")})
        Me.BT_ST_Details_GridView.Name = "BT_ST_Details_GridView"
        Me.BT_ST_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_ST_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_ST_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_ST_Details_GridView.OptionsSelection.MultiSelect = True
        Me.BT_ST_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_ST_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BT_ST_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_ST_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_ST_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_ST_Details_GridView.OptionsView.ShowFooter = True
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 3
        Me.colContractType.Width = 82
        '
        'colProductType
        '
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colProductType.Name = "colProductType"
        Me.colProductType.OptionsColumn.AllowEdit = False
        Me.colProductType.OptionsColumn.ReadOnly = True
        Me.colProductType.Visible = True
        Me.colProductType.VisibleIndex = 4
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "GL Master / Account Type"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'colAccountType
        '
        Me.colAccountType.FieldName = "Account Type"
        Me.colAccountType.Name = "colAccountType"
        Me.colAccountType.OptionsColumn.AllowEdit = False
        Me.colAccountType.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "Counterparty/Issuer/Collateral Provider"
        Me.GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 341
        '
        'colClientNo
        '
        Me.colClientNo.AppearanceCell.Options.UseTextOptions = True
        Me.colClientNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientNo.FieldName = "Client No"
        Me.colClientNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.VisibleIndex = 1
        Me.colClientNo.Width = 87
        '
        'colCountryofRisk
        '
        Me.colCountryofRisk.FieldName = "Country of Risk"
        Me.colCountryofRisk.Name = "colCountryofRisk"
        Me.colCountryofRisk.OptionsColumn.AllowEdit = False
        Me.colCountryofRisk.OptionsColumn.ReadOnly = True
        '
        'colCountryofResidence
        '
        Me.colCountryofResidence.FieldName = "Country of Residence"
        Me.colCountryofResidence.Name = "colCountryofResidence"
        Me.colCountryofResidence.OptionsColumn.AllowEdit = False
        Me.colCountryofResidence.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "Industry(HO)"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'colInternalCode
        '
        Me.colInternalCode.AppearanceCell.ForeColor = System.Drawing.Color.Aqua
        Me.colInternalCode.AppearanceCell.Options.UseForeColor = True
        Me.colInternalCode.FieldName = "InternalCode"
        Me.colInternalCode.Name = "colInternalCode"
        Me.colInternalCode.OptionsColumn.AllowEdit = False
        Me.colInternalCode.OptionsColumn.ReadOnly = True
        Me.colInternalCode.Visible = True
        Me.colInternalCode.VisibleIndex = 6
        Me.colInternalCode.Width = 116
        '
        'colBusinessType
        '
        Me.colBusinessType.FieldName = "BusinessType"
        Me.colBusinessType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colBusinessType.Name = "colBusinessType"
        Me.colBusinessType.OptionsColumn.AllowEdit = False
        Me.colBusinessType.OptionsColumn.ReadOnly = True
        Me.colBusinessType.Visible = True
        Me.colBusinessType.VisibleIndex = 0
        Me.colBusinessType.Width = 226
        '
        'colCUSTOMERTYPE
        '
        Me.colCUSTOMERTYPE.FieldName = "CUSTOMER TYPE"
        Me.colCUSTOMERTYPE.Name = "colCUSTOMERTYPE"
        Me.colCUSTOMERTYPE.OptionsColumn.AllowEdit = False
        Me.colCUSTOMERTYPE.OptionsColumn.ReadOnly = True
        Me.colCUSTOMERTYPE.Width = 105
        '
        'colClientGroup
        '
        Me.colClientGroup.FieldName = "Client Group"
        Me.colClientGroup.Name = "colClientGroup"
        Me.colClientGroup.OptionsColumn.AllowEdit = False
        Me.colClientGroup.OptionsColumn.ReadOnly = True
        Me.colClientGroup.Visible = True
        Me.colClientGroup.VisibleIndex = 7
        '
        'colContractCollateralID
        '
        Me.colContractCollateralID.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colContractCollateralID.Name = "colContractCollateralID"
        Me.colContractCollateralID.OptionsColumn.AllowEdit = False
        Me.colContractCollateralID.OptionsColumn.ReadOnly = True
        Me.colContractCollateralID.Visible = True
        Me.colContractCollateralID.VisibleIndex = 5
        Me.colContractCollateralID.Width = 139
        '
        'colStartDate
        '
        Me.colStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStartDate.FieldName = "Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.OptionsColumn.AllowEdit = False
        Me.colStartDate.OptionsColumn.ReadOnly = True
        Me.colStartDate.Visible = True
        Me.colStartDate.VisibleIndex = 8
        '
        'colMaturityDate
        '
        Me.colMaturityDate.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturityDate.FieldName = "Maturity Date"
        Me.colMaturityDate.Name = "colMaturityDate"
        Me.colMaturityDate.OptionsColumn.AllowEdit = False
        Me.colMaturityDate.OptionsColumn.ReadOnly = True
        Me.colMaturityDate.Visible = True
        Me.colMaturityDate.VisibleIndex = 9
        Me.colMaturityDate.Width = 85
        '
        'colOrgCcy
        '
        Me.colOrgCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrgCcy.FieldName = "Org Ccy"
        Me.colOrgCcy.Name = "colOrgCcy"
        Me.colOrgCcy.OptionsColumn.AllowEdit = False
        Me.colOrgCcy.OptionsColumn.ReadOnly = True
        Me.colOrgCcy.Visible = True
        Me.colOrgCcy.VisibleIndex = 10
        '
        'colCreditExposure
        '
        Me.colCreditExposure.AppearanceCell.Options.UseTextOptions = True
        Me.colCreditExposure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCreditExposure.DisplayFormat.FormatString = "n2"
        Me.colCreditExposure.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCreditExposure.FieldName = "Credit Exposure"
        Me.colCreditExposure.Name = "colCreditExposure"
        Me.colCreditExposure.OptionsColumn.AllowEdit = False
        Me.colCreditExposure.OptionsColumn.ReadOnly = True
        Me.colCreditExposure.Visible = True
        Me.colCreditExposure.VisibleIndex = 11
        Me.colCreditExposure.Width = 97
        '
        'colAccruedInterest
        '
        Me.colAccruedInterest.FieldName = "Accrued Interest"
        Me.colAccruedInterest.Name = "colAccruedInterest"
        Me.colAccruedInterest.OptionsColumn.AllowEdit = False
        Me.colAccruedInterest.OptionsColumn.ReadOnly = True
        '
        'colEuroEquivalent
        '
        Me.colEuroEquivalent.AppearanceCell.Options.UseTextOptions = True
        Me.colEuroEquivalent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colEuroEquivalent.DisplayFormat.FormatString = "n2"
        Me.colEuroEquivalent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEuroEquivalent.FieldName = "Euro Equivalent"
        Me.colEuroEquivalent.Name = "colEuroEquivalent"
        Me.colEuroEquivalent.OptionsColumn.AllowEdit = False
        Me.colEuroEquivalent.OptionsColumn.ReadOnly = True
        Me.colEuroEquivalent.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Euro Equivalent", "{0:n2}")})
        Me.colEuroEquivalent.Visible = True
        Me.colEuroEquivalent.VisibleIndex = 12
        Me.colEuroEquivalent.Width = 114
        '
        'colStressPercent
        '
        Me.colStressPercent.AppearanceCell.ForeColor = System.Drawing.Color.Aqua
        Me.colStressPercent.AppearanceCell.Options.UseForeColor = True
        Me.colStressPercent.AppearanceCell.Options.UseTextOptions = True
        Me.colStressPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStressPercent.DisplayFormat.FormatString = "p2"
        Me.colStressPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStressPercent.FieldName = "StressPercent"
        Me.colStressPercent.Name = "colStressPercent"
        Me.colStressPercent.OptionsColumn.AllowEdit = False
        Me.colStressPercent.OptionsColumn.ReadOnly = True
        Me.colStressPercent.Visible = True
        Me.colStressPercent.VisibleIndex = 13
        Me.colStressPercent.Width = 98
        '
        'colStressNewAmount
        '
        Me.colStressNewAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colStressNewAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colStressNewAmount.DisplayFormat.FormatString = "n2"
        Me.colStressNewAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colStressNewAmount.FieldName = "StressNewAmount"
        Me.colStressNewAmount.Name = "colStressNewAmount"
        Me.colStressNewAmount.OptionsColumn.AllowEdit = False
        Me.colStressNewAmount.OptionsColumn.ReadOnly = True
        Me.colStressNewAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StressNewAmount", "{0:n2}")})
        Me.colStressNewAmount.ToolTip = "Euro Equivalent amount after the calculated Cashcover"
        Me.colStressNewAmount.Visible = True
        Me.colStressNewAmount.VisibleIndex = 14
        Me.colStressNewAmount.Width = 114
        '
        'colPDAmount
        '
        Me.colPDAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colPDAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPDAmount.DisplayFormat.FormatString = "n2"
        Me.colPDAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPDAmount.FieldName = "PDAmount"
        Me.colPDAmount.Name = "colPDAmount"
        Me.colPDAmount.OptionsColumn.AllowEdit = False
        Me.colPDAmount.OptionsColumn.ReadOnly = True
        Me.colPDAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PDAmount", "{0:n2}")})
        Me.colPDAmount.ToolTip = "Stress New Amount * Stress Percent"
        Me.colPDAmount.Visible = True
        Me.colPDAmount.VisibleIndex = 15
        Me.colPDAmount.Width = 111
        '
        'colRiskDate
        '
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.OptionsColumn.AllowEdit = False
        Me.colRiskDate.OptionsColumn.ReadOnly = True
        '
        'colIdBusinessTypeLive
        '
        Me.colIdBusinessTypeLive.FieldName = "IdBusinessTypeLive"
        Me.colIdBusinessTypeLive.Name = "colIdBusinessTypeLive"
        Me.colIdBusinessTypeLive.OptionsColumn.AllowEdit = False
        Me.colIdBusinessTypeLive.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.StressTestsLiveBindingSource
        GridLevelNode1.LevelTemplate = Me.BT_ST_Details_GridView
        GridLevelNode1.RelationName = "FK_StressTestsLiveDetails_StressTestsLive"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.BT_ST_Totals_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.RepositoryItemSpinEdit1, Me.RepositoryItemMemoEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1220, 575)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BT_ST_Totals_GridView, Me.LayoutView1, Me.BT_ST_Details_GridView})
        '
        'StressTestsLiveBindingSource
        '
        Me.StressTestsLiveBindingSource.DataMember = "FK_StressTestsLive_MAK CR TOTALS"
        Me.StressTestsLiveBindingSource.DataSource = Me.MAK_CR_TOTALSBindingSource
        '
        'MAK_CR_TOTALSBindingSource
        '
        Me.MAK_CR_TOTALSBindingSource.DataMember = "MAK CR TOTALS"
        Me.MAK_CR_TOTALSBindingSource.DataSource = Me.RiskControllingDataSet
        '
        'RiskControllingDataSet
        '
        Me.RiskControllingDataSet.DataSetName = "RiskControllingDataSet"
        Me.RiskControllingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BT_ST_Totals_GridView
        '
        Me.BT_ST_Totals_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_ST_Totals_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_ST_Totals_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_ST_Totals_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_ST_Totals_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_ST_Totals_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colBusinesType, Me.colPDunderStress, Me.colAmountBusinessType, Me.colSQLBusinessTypeDefinition, Me.colSQLBusinessTypeAmount, Me.colStressNotes, Me.colDateMakCrTotals})
        Me.BT_ST_Totals_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_ST_Totals_GridView.GridControl = Me.GridControl1
        Me.BT_ST_Totals_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessType", Me.colAmountBusinessType, "{0:n2}")})
        Me.BT_ST_Totals_GridView.Name = "BT_ST_Totals_GridView"
        Me.BT_ST_Totals_GridView.NewItemRowText = "Add new Business Type"
        Me.BT_ST_Totals_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_ST_Totals_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_ST_Totals_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_ST_Totals_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_ST_Totals_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_ST_Totals_GridView.OptionsPrint.PrintDetails = True
        Me.BT_ST_Totals_GridView.OptionsSelection.MultiSelect = True
        Me.BT_ST_Totals_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_ST_Totals_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BT_ST_Totals_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_ST_Totals_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.BT_ST_Totals_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_ST_Totals_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_ST_Totals_GridView.OptionsView.ShowFooter = True
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colBusinesType
        '
        Me.colBusinesType.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colBusinesType.FieldName = "BusinesType"
        Me.colBusinesType.Name = "colBusinesType"
        Me.colBusinesType.Visible = True
        Me.colBusinesType.VisibleIndex = 0
        Me.colBusinesType.Width = 379
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
        'colPDunderStress
        '
        Me.colPDunderStress.AppearanceCell.Options.UseTextOptions = True
        Me.colPDunderStress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPDunderStress.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colPDunderStress.DisplayFormat.FormatString = "p2"
        Me.colPDunderStress.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPDunderStress.FieldName = "PDunderStress"
        Me.colPDunderStress.Name = "colPDunderStress"
        Me.colPDunderStress.Visible = True
        Me.colPDunderStress.VisibleIndex = 1
        Me.colPDunderStress.Width = 105
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemSpinEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatString = "n2"
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.EditFormat.FormatString = "n2"
        Me.RepositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "n2"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'colAmountBusinessType
        '
        Me.colAmountBusinessType.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountBusinessType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountBusinessType.DisplayFormat.FormatString = "n2"
        Me.colAmountBusinessType.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountBusinessType.FieldName = "AmountBusinessType"
        Me.colAmountBusinessType.Name = "colAmountBusinessType"
        Me.colAmountBusinessType.OptionsColumn.AllowEdit = False
        Me.colAmountBusinessType.OptionsColumn.ReadOnly = True
        Me.colAmountBusinessType.Visible = True
        Me.colAmountBusinessType.VisibleIndex = 2
        Me.colAmountBusinessType.Width = 120
        '
        'colSQLBusinessTypeDefinition
        '
        Me.colSQLBusinessTypeDefinition.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSQLBusinessTypeDefinition.FieldName = "SQLBusinessTypeDefinition"
        Me.colSQLBusinessTypeDefinition.Name = "colSQLBusinessTypeDefinition"
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
        'colSQLBusinessTypeAmount
        '
        Me.colSQLBusinessTypeAmount.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSQLBusinessTypeAmount.FieldName = "SQLBusinessTypeAmount"
        Me.colSQLBusinessTypeAmount.Name = "colSQLBusinessTypeAmount"
        '
        'colStressNotes
        '
        Me.colStressNotes.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.colStressNotes.FieldName = "StressNotes"
        Me.colStressNotes.Name = "colStressNotes"
        Me.colStressNotes.Visible = True
        Me.colStressNotes.VisibleIndex = 3
        Me.colStressNotes.Width = 638
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        Me.RepositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colDateMakCrTotals
        '
        Me.colDateMakCrTotals.FieldName = "DateMakCrTotals"
        Me.colDateMakCrTotals.Name = "colDateMakCrTotals"
        Me.colDateMakCrTotals.OptionsColumn.AllowEdit = False
        Me.colDateMakCrTotals.OptionsColumn.ReadOnly = True
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
        Me.layoutViewField_colIdnr.TextToControlDistance = 5
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
        Me.layoutViewField_colTAG.TextToControlDistance = 5
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
        Me.layoutViewField_colMODIFICATIONFLAG.TextToControlDistance = 5
        '
        'LayoutViewColumn4
        '
        Me.LayoutViewColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn4.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn4.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn4.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn4.ColumnEdit = Me.RepositoryItemTextEdit1
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
        Me.layoutViewField_colINSTITUTIONNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colBRANCHINFORMATION.TextToControlDistance = 5
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
        Me.layoutViewField_colCITYHEADING.TextToControlDistance = 5
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
        Me.layoutViewField_colSUBTYPEINDICATION.TextToControlDistance = 5
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
        Me.layoutViewField_colVALUEADDEDSERVICES.TextToControlDistance = 5
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
        Me.layoutViewField_colEXTRAINFO.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS1.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS2.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS3.TextToControlDistance = 5
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
        Me.layoutViewField_colPHYSICALADDRESS4.TextToControlDistance = 5
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
        Me.layoutViewField_colLOCATION.TextToControlDistance = 5
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
        Me.layoutViewField_colCOUNTRYNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBNUMBER.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBLOCATION.TextToControlDistance = 5
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
        Me.layoutViewField_colPOBCOUNTRYNAME.TextToControlDistance = 5
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
        Me.layoutViewField_colUSER2.TextToControlDistance = 5
        '
        'LayoutViewColumn20
        '
        Me.LayoutViewColumn20.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn20.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn20.ColumnEdit = Me.RepositoryItemComboBox1
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
        Me.layoutViewField_colVALID.TextToControlDistance = 5
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
        Me.LayoutViewField48.TextToControlDistance = 5
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
        Me.layoutViewField_colBIC112.TextToControlDistance = 5
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
        Me.LayoutViewColumn23.ImageIndex = 0
        Me.LayoutViewColumn23.LayoutViewField = Me.layoutViewField_colBICCODE
        Me.LayoutViewColumn23.Name = "LayoutViewColumn23"
        '
        'layoutViewField_colBICCODE
        '
        Me.layoutViewField_colBICCODE.EditorPreferredWidth = 93
        Me.layoutViewField_colBICCODE.ImageIndex = 0
        Me.layoutViewField_colBICCODE.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colBICCODE.Name = "layoutViewField_colBICCODE"
        Me.layoutViewField_colBICCODE.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colBICCODE.TextSize = New System.Drawing.Size(123, 16)
        Me.layoutViewField_colBICCODE.TextToControlDistance = 5
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
        Me.layoutViewField_colBRANCHCODE.TextToControlDistance = 5
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
        Me.layoutViewField_colCOUNTRY.TextToControlDistance = 5
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'MAK_CR_TOTALSTableAdapter
        '
        Me.MAK_CR_TOTALSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioDetailsAllTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioDetailsTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioLiveTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioTempTableAdapter = Nothing
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.EXCEPTION_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_CR_TOTALSTableAdapter = Me.MAK_CR_TOTALSTableAdapter
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DATETableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DELETIONSTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_TOTALSTableAdapter = Nothing
        Me.TableAdapterManager.RISK_LIMIT_DAILY_CONTROLTableAdapter = Nothing
        Me.TableAdapterManager.StressTestLiquid_TempTableAdapter = Nothing
        Me.TableAdapterManager.StressTestsLiquidHOTableAdapter = Nothing
        Me.TableAdapterManager.StressTestsLiveDetailsTableAdapter = Me.StressTestsLiveDetailsTableAdapter
        Me.TableAdapterManager.StressTestsLiveTableAdapter = Me.StressTestsLiveTableAdapter
        Me.TableAdapterManager.StressTestsTempTableAdapter = Me.StressTestsTempTableAdapter
        Me.TableAdapterManager.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DATETableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DetailsALLTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DetailsTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'StressTestsLiveDetailsTableAdapter
        '
        Me.StressTestsLiveDetailsTableAdapter.ClearBeforeFill = True
        '
        'StressTestsLiveTableAdapter
        '
        Me.StressTestsLiveTableAdapter.ClearBeforeFill = True
        '
        'StressTestsTempTableAdapter
        '
        Me.StressTestsTempTableAdapter.ClearBeforeFill = True
        '
        'StressTestsLiveDetailsBindingSource
        '
        Me.StressTestsLiveDetailsBindingSource.DataMember = "FK_StressTestsLiveDetails_StressTestsLive"
        Me.StressTestsLiveDetailsBindingSource.DataSource = Me.StressTestsLiveBindingSource
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Date"
        '
        'LoadBusinessTypes_btn
        '
        Me.LoadBusinessTypes_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadBusinessTypes_btn.ImageIndex = 6
        Me.LoadBusinessTypes_btn.ImageList = Me.ImageCollection1
        Me.LoadBusinessTypes_btn.Location = New System.Drawing.Point(135, 26)
        Me.LoadBusinessTypes_btn.Name = "LoadBusinessTypes_btn"
        Me.LoadBusinessTypes_btn.Size = New System.Drawing.Size(97, 22)
        Me.LoadBusinessTypes_btn.TabIndex = 21
        Me.LoadBusinessTypes_btn.Text = "Load Data"
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
        Me.ImageCollection1.Images.SetKeyName(8, "SQL Runner.ico")
        '
        'BusinessTypeDateEdit
        '
        Me.BusinessTypeDateEdit.EditValue = Nothing
        Me.BusinessTypeDateEdit.Location = New System.Drawing.Point(12, 26)
        Me.BusinessTypeDateEdit.Name = "BusinessTypeDateEdit"
        Me.BusinessTypeDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BusinessTypeDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BusinessTypeDateEdit.Properties.Appearance.Options.UseFont = True
        Me.BusinessTypeDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.BusinessTypeDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.BusinessTypeDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BusinessTypeDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BusinessTypeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BusinessTypeDateEdit.Size = New System.Drawing.Size(117, 22)
        Me.BusinessTypeDateEdit.TabIndex = 20
        '
        'StressTestsTempBindingSource
        '
        Me.StressTestsTempBindingSource.DataMember = "StressTestsTemp"
        Me.StressTestsTempBindingSource.DataSource = Me.RiskControllingDataSet
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.SystemColors.ControlLight
        Me.XtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = True
        Me.XtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        Me.XtraTabControl1.HeaderButtons = CType((((DevExpress.XtraTab.TabButtons.Prev Or DevExpress.XtraTab.TabButtons.[Next]) _
            Or DevExpress.XtraTab.TabButtons.Close) _
            Or DevExpress.XtraTab.TabButtons.[Default]), DevExpress.XtraTab.TabButtons)
        Me.XtraTabControl1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always
        Me.XtraTabControl1.Location = New System.Drawing.Point(2, 54)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.BT_ST_XtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1250, 677)
        Me.XtraTabControl1.TabIndex = 23
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.BT_ST_XtraTabPage, Me.BT_ST_GEN_PARAM_XtraTabPage})
        '
        'BT_ST_XtraTabPage
        '
        Me.BT_ST_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_ST_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BT_ST_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.BT_ST_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BT_ST_XtraTabPage.Controls.Add(Me.LayoutControl1)
        Me.BT_ST_XtraTabPage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_ST_XtraTabPage.ImageIndex = 0
        Me.BT_ST_XtraTabPage.Name = "BT_ST_XtraTabPage"
        Me.BT_ST_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_ST_XtraTabPage.Size = New System.Drawing.Size(1244, 649)
        Me.BT_ST_XtraTabPage.Text = "BUSINESS TYPES - STRESS TESTS"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SQL_Commands_Dropdownbutton)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_BT_ST_Totals_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.StressTestsBusinessTyperReport_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1244, 649)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SQL_Commands_Dropdownbutton
        '
        Me.SQL_Commands_Dropdownbutton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.SQL_Commands_Dropdownbutton.DropDownControl = Me.PopupMenu1
        Me.SQL_Commands_Dropdownbutton.ImageIndex = 8
        Me.SQL_Commands_Dropdownbutton.ImageList = Me.ImageCollection1
        Me.SQL_Commands_Dropdownbutton.Location = New System.Drawing.Point(334, 24)
        Me.SQL_Commands_Dropdownbutton.Name = "SQL_Commands_Dropdownbutton"
        Me.SQL_Commands_Dropdownbutton.Size = New System.Drawing.Size(195, 22)
        Me.SQL_Commands_Dropdownbutton.StyleController = Me.LayoutControl1
        Me.SQL_Commands_Dropdownbutton.TabIndex = 7
        Me.SQL_Commands_Dropdownbutton.Text = "SQL Commands Run"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_Run_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_ReRun_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_ReRun_Period_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_ReRun_AllDays_BarButtonItem)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'SQL_Run_BarButtonItem
        '
        Me.SQL_Run_BarButtonItem.Caption = "SQL Commants Run (Current Day)"
        Me.SQL_Run_BarButtonItem.Id = 0
        Me.SQL_Run_BarButtonItem.ImageIndex = 8
        Me.SQL_Run_BarButtonItem.Name = "SQL_Run_BarButtonItem"
        '
        'SQL_ReRun_BarButtonItem
        '
        Me.SQL_ReRun_BarButtonItem.Caption = "SQL Re-Run Commands (Current Day)"
        Me.SQL_ReRun_BarButtonItem.Id = 1
        Me.SQL_ReRun_BarButtonItem.ImageIndex = 8
        Me.SQL_ReRun_BarButtonItem.Name = "SQL_ReRun_BarButtonItem"
        '
        'SQL_ReRun_Period_BarButtonItem
        '
        Me.SQL_ReRun_Period_BarButtonItem.Caption = "SQL Re-Run (Specific Period)"
        Me.SQL_ReRun_Period_BarButtonItem.Id = 3
        Me.SQL_ReRun_Period_BarButtonItem.ImageIndex = 8
        Me.SQL_ReRun_Period_BarButtonItem.Name = "SQL_ReRun_Period_BarButtonItem"
        '
        'SQL_ReRun_AllDays_BarButtonItem
        '
        Me.SQL_ReRun_AllDays_BarButtonItem.Caption = "SQL Re-Run (All Days)"
        Me.SQL_ReRun_AllDays_BarButtonItem.Id = 2
        Me.SQL_ReRun_AllDays_BarButtonItem.ImageIndex = 8
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemAppearance.Normal.Options.UseForeColor = True
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemInMenuAppearance.Normal.ForeColor = System.Drawing.Color.Red
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemInMenuAppearance.Normal.Options.UseForeColor = True
        Me.SQL_ReRun_AllDays_BarButtonItem.Name = "SQL_ReRun_AllDays_BarButtonItem"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SQL_Run_BarButtonItem, Me.SQL_ReRun_BarButtonItem, Me.SQL_ReRun_AllDays_BarButtonItem, Me.SQL_ReRun_Period_BarButtonItem})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 4
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 1
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Offset = 334
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
        Me.barDockControlTop.Size = New System.Drawing.Size(1250, 29)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 709)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1250, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 29)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 680)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1250, 29)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 680)
        '
        'Print_Export_BT_ST_Totals_Gridview_btn
        '
        Me.Print_Export_BT_ST_Totals_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_BT_ST_Totals_Gridview_btn.ImageIndex = 2
        Me.Print_Export_BT_ST_Totals_Gridview_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_BT_ST_Totals_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_BT_ST_Totals_Gridview_btn.Name = "Print_Export_BT_ST_Totals_Gridview_btn"
        Me.Print_Export_BT_ST_Totals_Gridview_btn.Size = New System.Drawing.Size(140, 22)
        Me.Print_Export_BT_ST_Totals_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_BT_ST_Totals_Gridview_btn.TabIndex = 6
        Me.Print_Export_BT_ST_Totals_Gridview_btn.Text = "Print or Export"
        '
        'StressTestsBusinessTyperReport_btn
        '
        Me.StressTestsBusinessTyperReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StressTestsBusinessTyperReport_btn.ImageIndex = 7
        Me.StressTestsBusinessTyperReport_btn.ImageList = Me.ImageCollection1
        Me.StressTestsBusinessTyperReport_btn.Location = New System.Drawing.Point(168, 24)
        Me.StressTestsBusinessTyperReport_btn.Name = "StressTestsBusinessTyperReport_btn"
        Me.StressTestsBusinessTyperReport_btn.Size = New System.Drawing.Size(162, 22)
        Me.StressTestsBusinessTyperReport_btn.StyleController = Me.LayoutControl1
        Me.StressTestsBusinessTyperReport_btn.TabIndex = 5
        Me.StressTestsBusinessTyperReport_btn.Text = "Stress Test Report"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1156, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(64, 22)
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
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1244, 649)
        Me.LayoutControlGroup1.Text = "Root"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1224, 579)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem7, Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1224, 50)
        Me.LayoutControlGroup3.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1132, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(68, 26)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(509, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(623, 26)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_BT_ST_Totals_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(144, 26)
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SQL_Commands_Dropdownbutton
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(310, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(199, 26)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StressTestsBusinessTyperReport_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(144, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(166, 26)
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'BT_ST_GEN_PARAM_XtraTabPage
        '
        Me.BT_ST_GEN_PARAM_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_ST_GEN_PARAM_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BT_ST_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.BT_ST_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BT_ST_GEN_PARAM_XtraTabPage.Controls.Add(Me.LayoutControl2)
        Me.BT_ST_GEN_PARAM_XtraTabPage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_ST_GEN_PARAM_XtraTabPage.ImageIndex = 1
        Me.BT_ST_GEN_PARAM_XtraTabPage.Name = "BT_ST_GEN_PARAM_XtraTabPage"
        Me.BT_ST_GEN_PARAM_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_ST_GEN_PARAM_XtraTabPage.Size = New System.Drawing.Size(1244, 649)
        Me.BT_ST_GEN_PARAM_XtraTabPage.Text = "BUSINESS TYPES-STRESS TESTS PARAMETERS"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.Print_Export_BT_ST_Temp_Gridview_btn)
        Me.LayoutControl2.Controls.Add(Me.Edit_INTERBANKV_Details_btn)
        Me.LayoutControl2.Controls.Add(Me.GridControl2)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(1244, 649)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Print_Export_BT_ST_Temp_Gridview_btn
        '
        Me.Print_Export_BT_ST_Temp_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_BT_ST_Temp_Gridview_btn.ImageIndex = 2
        Me.Print_Export_BT_ST_Temp_Gridview_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_BT_ST_Temp_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_BT_ST_Temp_Gridview_btn.Name = "Print_Export_BT_ST_Temp_Gridview_btn"
        Me.Print_Export_BT_ST_Temp_Gridview_btn.Size = New System.Drawing.Size(139, 22)
        Me.Print_Export_BT_ST_Temp_Gridview_btn.StyleController = Me.LayoutControl2
        Me.Print_Export_BT_ST_Temp_Gridview_btn.TabIndex = 6
        Me.Print_Export_BT_ST_Temp_Gridview_btn.Text = "Print or Export"
        '
        'Edit_INTERBANKV_Details_btn
        '
        Me.Edit_INTERBANKV_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_INTERBANKV_Details_btn.ImageIndex = 5
        Me.Edit_INTERBANKV_Details_btn.Location = New System.Drawing.Point(1056, 24)
        Me.Edit_INTERBANKV_Details_btn.Name = "Edit_INTERBANKV_Details_btn"
        Me.Edit_INTERBANKV_Details_btn.Size = New System.Drawing.Size(164, 22)
        Me.Edit_INTERBANKV_Details_btn.StyleController = Me.LayoutControl2
        Me.Edit_INTERBANKV_Details_btn.TabIndex = 4
        Me.Edit_INTERBANKV_Details_btn.Text = "Show Details"
        '
        'GridControl2
        '
        Me.GridControl2.DataSource = Me.StressTestsTempBindingSource
        Me.GridControl2.Location = New System.Drawing.Point(12, 62)
        Me.GridControl2.MainView = Me.BT_ST_Temp_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemSpinEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1220, 575)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BT_ST_Temp_GridView, Me.LayoutView4, Me.LayoutView3, Me.LayoutView2})
        '
        'BT_ST_Temp_GridView
        '
        Me.BT_ST_Temp_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_ST_Temp_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_ST_Temp_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_ST_Temp_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_ST_Temp_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_ST_Temp_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colBusinesType1, Me.colPDunderStress1, Me.colAmountBusinessType1, Me.colSQLBusinessTypeDefinition1, Me.colSQLBusinessTypeAmount1})
        Me.BT_ST_Temp_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_ST_Temp_GridView.GridControl = Me.GridControl2
        Me.BT_ST_Temp_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance(EUR Equ)", Nothing, "{0:n2}")})
        Me.BT_ST_Temp_GridView.Name = "BT_ST_Temp_GridView"
        Me.BT_ST_Temp_GridView.NewItemRowText = "Add new Business Type"
        Me.BT_ST_Temp_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_ST_Temp_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_ST_Temp_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_ST_Temp_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_ST_Temp_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_ST_Temp_GridView.OptionsSelection.MultiSelect = True
        Me.BT_ST_Temp_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_ST_Temp_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_ST_Temp_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.BT_ST_Temp_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_ST_Temp_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_ST_Temp_GridView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colBusinesType1
        '
        Me.colBusinesType1.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.colBusinesType1.FieldName = "BusinesType"
        Me.colBusinesType1.Name = "colBusinesType1"
        Me.colBusinesType1.Visible = True
        Me.colBusinesType1.VisibleIndex = 0
        Me.colBusinesType1.Width = 410
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'colPDunderStress1
        '
        Me.colPDunderStress1.AppearanceCell.Options.UseTextOptions = True
        Me.colPDunderStress1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPDunderStress1.ColumnEdit = Me.RepositoryItemSpinEdit2
        Me.colPDunderStress1.DisplayFormat.FormatString = "p2"
        Me.colPDunderStress1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPDunderStress1.FieldName = "PDunderStress"
        Me.colPDunderStress1.Name = "colPDunderStress1"
        Me.colPDunderStress1.Visible = True
        Me.colPDunderStress1.VisibleIndex = 1
        Me.colPDunderStress1.Width = 114
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemSpinEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit2.EditFormat.FormatString = "n2"
        Me.RepositoryItemSpinEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'colAmountBusinessType1
        '
        Me.colAmountBusinessType1.FieldName = "AmountBusinessType"
        Me.colAmountBusinessType1.Name = "colAmountBusinessType1"
        Me.colAmountBusinessType1.Width = 138
        '
        'colSQLBusinessTypeDefinition1
        '
        Me.colSQLBusinessTypeDefinition1.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQLBusinessTypeDefinition1.FieldName = "SQLBusinessTypeDefinition"
        Me.colSQLBusinessTypeDefinition1.Name = "colSQLBusinessTypeDefinition1"
        Me.colSQLBusinessTypeDefinition1.Visible = True
        Me.colSQLBusinessTypeDefinition1.VisibleIndex = 2
        Me.colSQLBusinessTypeDefinition1.Width = 148
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colSQLBusinessTypeAmount1
        '
        Me.colSQLBusinessTypeAmount1.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQLBusinessTypeAmount1.FieldName = "SQLBusinessTypeAmount"
        Me.colSQLBusinessTypeAmount1.Name = "colSQLBusinessTypeAmount1"
        Me.colSQLBusinessTypeAmount1.Visible = True
        Me.colSQLBusinessTypeAmount1.VisibleIndex = 3
        Me.colSQLBusinessTypeAmount1.Width = 154
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox2.DropDownRows = 2
        Me.RepositoryItemComboBox2.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox2.ImmediatePopup = True
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'LayoutView4
        '
        Me.LayoutView4.CardMinSize = New System.Drawing.Size(567, 651)
        Me.LayoutView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn51, Me.LayoutViewColumn52, Me.LayoutViewColumn53, Me.LayoutViewColumn54, Me.LayoutViewColumn55, Me.LayoutViewColumn56, Me.LayoutViewColumn57, Me.LayoutViewColumn58, Me.LayoutViewColumn59, Me.LayoutViewColumn60, Me.LayoutViewColumn61, Me.LayoutViewColumn62, Me.LayoutViewColumn63, Me.LayoutViewColumn64, Me.LayoutViewColumn65, Me.LayoutViewColumn66, Me.LayoutViewColumn67, Me.LayoutViewColumn68, Me.LayoutViewColumn69, Me.LayoutViewColumn70, Me.LayoutViewColumn71, Me.LayoutViewColumn72, Me.LayoutViewColumn73, Me.LayoutViewColumn74, Me.LayoutViewColumn75, Me.LayoutViewColumn76, Me.LayoutViewColumn77, Me.LayoutViewColumn78, Me.LayoutViewColumn79, Me.LayoutViewColumn80, Me.LayoutViewColumn81, Me.LayoutViewColumn82, Me.LayoutViewColumn83, Me.LayoutViewColumn84, Me.LayoutViewColumn85, Me.LayoutViewColumn86, Me.LayoutViewColumn87, Me.LayoutViewColumn88, Me.LayoutViewColumn89, Me.LayoutViewColumn90, Me.LayoutViewColumn91, Me.LayoutViewColumn92, Me.LayoutViewColumn93, Me.LayoutViewColumn94, Me.LayoutViewColumn95, Me.LayoutViewColumn96, Me.LayoutViewColumn97, Me.LayoutViewColumn98, Me.LayoutViewColumn99, Me.LayoutViewColumn100, Me.LayoutViewColumn101, Me.LayoutViewColumn102, Me.LayoutViewColumn103})
        Me.LayoutView4.GridControl = Me.GridControl2
        Me.LayoutView4.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colUNTERBEARBEITUNGVON, Me.layoutViewField_colUSER})
        Me.LayoutView4.Name = "LayoutView4"
        Me.LayoutView4.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView4.OptionsFilter.AllowFilterEditor = False
        Me.LayoutView4.OptionsFilter.AllowMRUFilterList = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowPanButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView4.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView4.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView4.TemplateCard = Me.LayoutViewCard2
        '
        'LayoutViewColumn51
        '
        Me.LayoutViewColumn51.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn51.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn51.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn51.FieldName = "ID"
        Me.LayoutViewColumn51.LayoutViewField = Me.layoutViewField_colID
        Me.LayoutViewColumn51.Name = "LayoutViewColumn51"
        Me.LayoutViewColumn51.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn51.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn51.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colID
        '
        Me.layoutViewField_colID.EditorPreferredWidth = 113
        Me.layoutViewField_colID.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID.Name = "layoutViewField_colID"
        Me.layoutViewField_colID.Size = New System.Drawing.Size(137, 20)
        Me.layoutViewField_colID.TextSize = New System.Drawing.Size(15, 13)
        Me.layoutViewField_colID.TextToControlDistance = 5
        '
        'LayoutViewColumn52
        '
        Me.LayoutViewColumn52.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn52.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn52.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn52.FieldName = "Datensatz-nummer"
        Me.LayoutViewColumn52.LayoutViewField = Me.LayoutViewField49
        Me.LayoutViewColumn52.Name = "LayoutViewColumn52"
        Me.LayoutViewColumn52.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn52.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn52.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField49
        '
        Me.LayoutViewField49.EditorPreferredWidth = 85
        Me.LayoutViewField49.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField49.Name = "LayoutViewField49"
        Me.LayoutViewField49.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField49.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField49.TextToControlDistance = 5
        '
        'LayoutViewColumn53
        '
        Me.LayoutViewColumn53.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn53.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn53.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn53.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn53.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn53.FieldName = "Bankleitzahl"
        Me.LayoutViewColumn53.LayoutViewField = Me.layoutViewField_colBankleitzahl
        Me.LayoutViewColumn53.Name = "LayoutViewColumn53"
        Me.LayoutViewColumn53.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn53.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn53.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBankleitzahl
        '
        Me.layoutViewField_colBankleitzahl.EditorPreferredWidth = 85
        Me.layoutViewField_colBankleitzahl.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colBankleitzahl.Name = "layoutViewField_colBankleitzahl"
        Me.layoutViewField_colBankleitzahl.Size = New System.Drawing.Size(287, 20)
        Me.layoutViewField_colBankleitzahl.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colBankleitzahl.TextToControlDistance = 5
        '
        'LayoutViewColumn54
        '
        Me.LayoutViewColumn54.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn54.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn54.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn54.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn54.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn54.FieldName = "BIC"
        Me.LayoutViewColumn54.LayoutViewField = Me.layoutViewField_colBIC
        Me.LayoutViewColumn54.Name = "LayoutViewColumn54"
        Me.LayoutViewColumn54.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn54.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn54.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBIC
        '
        Me.layoutViewField_colBIC.EditorPreferredWidth = 85
        Me.layoutViewField_colBIC.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colBIC.Name = "layoutViewField_colBIC"
        Me.layoutViewField_colBIC.Size = New System.Drawing.Size(287, 20)
        Me.layoutViewField_colBIC.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colBIC.TextToControlDistance = 5
        '
        'LayoutViewColumn55
        '
        Me.LayoutViewColumn55.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn55.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn55.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn55.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn55.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn55.FieldName = "Bezeichnung des Zahlungsdienstleisters"
        Me.LayoutViewColumn55.LayoutViewField = Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters
        Me.LayoutViewColumn55.Name = "LayoutViewColumn55"
        Me.LayoutViewColumn55.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn55.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn55.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBezeichnungdesZahlungsdienstleisters
        '
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.EditorPreferredWidth = 321
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Name = "layoutViewField_colBezeichnungdesZahlungsdienstleisters"
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters.TextToControlDistance = 5
        '
        'LayoutViewColumn56
        '
        Me.LayoutViewColumn56.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn56.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn56.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn56.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn56.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn56.FieldName = "Ort (Sitz)"
        Me.LayoutViewColumn56.LayoutViewField = Me.LayoutViewField50
        Me.LayoutViewColumn56.Name = "LayoutViewColumn56"
        Me.LayoutViewColumn56.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn56.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn56.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField50
        '
        Me.LayoutViewField50.EditorPreferredWidth = 321
        Me.LayoutViewField50.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField50.Name = "LayoutViewField50"
        Me.LayoutViewField50.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField50.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField50.TextToControlDistance = 5
        '
        'LayoutViewColumn57
        '
        Me.LayoutViewColumn57.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn57.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn57.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn57.FieldName = "Änderungs-kennzeichen"
        Me.LayoutViewColumn57.LayoutViewField = Me.LayoutViewField51
        Me.LayoutViewColumn57.Name = "LayoutViewColumn57"
        Me.LayoutViewColumn57.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn57.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn57.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField51
        '
        Me.LayoutViewField51.EditorPreferredWidth = 321
        Me.LayoutViewField51.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField51.Name = "LayoutViewField51"
        Me.LayoutViewField51.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField51.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField51.TextToControlDistance = 5
        '
        'LayoutViewColumn58
        '
        Me.LayoutViewColumn58.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn58.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn58.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn58.FieldName = "Termin BLZ-Löschung"
        Me.LayoutViewColumn58.LayoutViewField = Me.LayoutViewField52
        Me.LayoutViewColumn58.Name = "LayoutViewColumn58"
        Me.LayoutViewColumn58.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn58.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn58.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField52
        '
        Me.LayoutViewField52.EditorPreferredWidth = 321
        Me.LayoutViewField52.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField52.Name = "LayoutViewField52"
        Me.LayoutViewField52.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField52.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField52.TextToControlDistance = 5
        '
        'LayoutViewColumn59
        '
        Me.LayoutViewColumn59.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn59.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn59.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn59.FieldName = "DSNr-Nachfolgeinstitut"
        Me.LayoutViewColumn59.LayoutViewField = Me.LayoutViewField53
        Me.LayoutViewColumn59.Name = "LayoutViewColumn59"
        Me.LayoutViewColumn59.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn59.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn59.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField53
        '
        Me.LayoutViewField53.EditorPreferredWidth = 321
        Me.LayoutViewField53.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField53.Name = "LayoutViewField53"
        Me.LayoutViewField53.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField53.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField53.TextToControlDistance = 5
        '
        'LayoutViewColumn60
        '
        Me.LayoutViewColumn60.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn60.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn60.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn60.FieldName = "Zustelladresse Firma"
        Me.LayoutViewColumn60.LayoutViewField = Me.layoutViewField_colZustelladresseFirma
        Me.LayoutViewColumn60.Name = "LayoutViewColumn60"
        Me.LayoutViewColumn60.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn60.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn60.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladresseFirma
        '
        Me.layoutViewField_colZustelladresseFirma.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladresseFirma.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colZustelladresseFirma.Name = "layoutViewField_colZustelladresseFirma"
        Me.layoutViewField_colZustelladresseFirma.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladresseFirma.TextSize = New System.Drawing.Size(130, 13)
        Me.layoutViewField_colZustelladresseFirma.TextToControlDistance = 5
        '
        'LayoutViewColumn61
        '
        Me.LayoutViewColumn61.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn61.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn61.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn61.FieldName = "Zustelladresse Ort"
        Me.LayoutViewColumn61.LayoutViewField = Me.layoutViewField_colZustelladresseOrt
        Me.LayoutViewColumn61.Name = "LayoutViewColumn61"
        Me.LayoutViewColumn61.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn61.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn61.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladresseOrt
        '
        Me.layoutViewField_colZustelladresseOrt.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladresseOrt.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colZustelladresseOrt.Name = "layoutViewField_colZustelladresseOrt"
        Me.layoutViewField_colZustelladresseOrt.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladresseOrt.TextSize = New System.Drawing.Size(130, 13)
        Me.layoutViewField_colZustelladresseOrt.TextToControlDistance = 5
        '
        'LayoutViewColumn62
        '
        Me.LayoutViewColumn62.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn62.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn62.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn62.FieldName = "Zustelladresse Postfach"
        Me.LayoutViewColumn62.LayoutViewField = Me.layoutViewField_colZustelladressePostfach
        Me.LayoutViewColumn62.Name = "LayoutViewColumn62"
        Me.LayoutViewColumn62.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn62.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn62.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladressePostfach
        '
        Me.layoutViewField_colZustelladressePostfach.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladressePostfach.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colZustelladressePostfach.Name = "layoutViewField_colZustelladressePostfach"
        Me.layoutViewField_colZustelladressePostfach.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladressePostfach.TextSize = New System.Drawing.Size(130, 13)
        Me.layoutViewField_colZustelladressePostfach.TextToControlDistance = 5
        '
        'LayoutViewColumn63
        '
        Me.LayoutViewColumn63.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn63.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn63.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn63.FieldName = "Zustelladresse Postleitzahl"
        Me.LayoutViewColumn63.LayoutViewField = Me.layoutViewField_colZustelladressePostleitzahl
        Me.LayoutViewColumn63.Name = "LayoutViewColumn63"
        Me.LayoutViewColumn63.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn63.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn63.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colZustelladressePostleitzahl
        '
        Me.layoutViewField_colZustelladressePostleitzahl.EditorPreferredWidth = 403
        Me.layoutViewField_colZustelladressePostleitzahl.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colZustelladressePostleitzahl.Name = "layoutViewField_colZustelladressePostleitzahl"
        Me.layoutViewField_colZustelladressePostleitzahl.Size = New System.Drawing.Size(542, 20)
        Me.layoutViewField_colZustelladressePostleitzahl.TextSize = New System.Drawing.Size(130, 13)
        Me.layoutViewField_colZustelladressePostleitzahl.TextToControlDistance = 5
        '
        'LayoutViewColumn64
        '
        Me.LayoutViewColumn64.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn64.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn64.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn64.FieldName = "Rücksendung Firma"
        Me.LayoutViewColumn64.LayoutViewField = Me.layoutViewField_colRücksendungFirma
        Me.LayoutViewColumn64.Name = "LayoutViewColumn64"
        Me.LayoutViewColumn64.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn64.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn64.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungFirma
        '
        Me.layoutViewField_colRücksendungFirma.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungFirma.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colRücksendungFirma.Name = "layoutViewField_colRücksendungFirma"
        Me.layoutViewField_colRücksendungFirma.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungFirma.TextSize = New System.Drawing.Size(125, 13)
        Me.layoutViewField_colRücksendungFirma.TextToControlDistance = 5
        '
        'LayoutViewColumn65
        '
        Me.LayoutViewColumn65.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn65.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn65.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn65.FieldName = "Rücksendung Postfach"
        Me.LayoutViewColumn65.LayoutViewField = Me.layoutViewField_colRücksendungPostfach
        Me.LayoutViewColumn65.Name = "LayoutViewColumn65"
        Me.LayoutViewColumn65.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn65.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn65.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungPostfach
        '
        Me.layoutViewField_colRücksendungPostfach.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungPostfach.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colRücksendungPostfach.Name = "layoutViewField_colRücksendungPostfach"
        Me.layoutViewField_colRücksendungPostfach.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungPostfach.TextSize = New System.Drawing.Size(125, 13)
        Me.layoutViewField_colRücksendungPostfach.TextToControlDistance = 5
        '
        'LayoutViewColumn66
        '
        Me.LayoutViewColumn66.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn66.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn66.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn66.FieldName = "Rücksendung Straße"
        Me.LayoutViewColumn66.LayoutViewField = Me.layoutViewField_colRücksendungStraße
        Me.LayoutViewColumn66.Name = "LayoutViewColumn66"
        Me.LayoutViewColumn66.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn66.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn66.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungStraße
        '
        Me.layoutViewField_colRücksendungStraße.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungStraße.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colRücksendungStraße.Name = "layoutViewField_colRücksendungStraße"
        Me.layoutViewField_colRücksendungStraße.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungStraße.TextSize = New System.Drawing.Size(125, 13)
        Me.layoutViewField_colRücksendungStraße.TextToControlDistance = 5
        '
        'LayoutViewColumn67
        '
        Me.LayoutViewColumn67.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn67.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn67.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn67.FieldName = "Rücksendung Postleitzahl"
        Me.LayoutViewColumn67.LayoutViewField = Me.layoutViewField_colRücksendungPostleitzahl
        Me.LayoutViewColumn67.Name = "LayoutViewColumn67"
        Me.LayoutViewColumn67.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn67.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn67.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungPostleitzahl
        '
        Me.layoutViewField_colRücksendungPostleitzahl.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungPostleitzahl.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colRücksendungPostleitzahl.Name = "layoutViewField_colRücksendungPostleitzahl"
        Me.layoutViewField_colRücksendungPostleitzahl.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungPostleitzahl.TextSize = New System.Drawing.Size(125, 13)
        Me.layoutViewField_colRücksendungPostleitzahl.TextToControlDistance = 5
        '
        'LayoutViewColumn68
        '
        Me.LayoutViewColumn68.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn68.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn68.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn68.FieldName = "Rücksendung Ort"
        Me.LayoutViewColumn68.LayoutViewField = Me.layoutViewField_colRücksendungOrt
        Me.LayoutViewColumn68.Name = "LayoutViewColumn68"
        Me.LayoutViewColumn68.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn68.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn68.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colRücksendungOrt
        '
        Me.layoutViewField_colRücksendungOrt.EditorPreferredWidth = 597
        Me.layoutViewField_colRücksendungOrt.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colRücksendungOrt.Name = "layoutViewField_colRücksendungOrt"
        Me.layoutViewField_colRücksendungOrt.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colRücksendungOrt.TextSize = New System.Drawing.Size(125, 13)
        Me.layoutViewField_colRücksendungOrt.TextToControlDistance = 5
        '
        'LayoutViewColumn69
        '
        Me.LayoutViewColumn69.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn69.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn69.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn69.FieldName = "Institutstyp"
        Me.LayoutViewColumn69.LayoutViewField = Me.layoutViewField_colInstitutstyp
        Me.LayoutViewColumn69.Name = "LayoutViewColumn69"
        Me.LayoutViewColumn69.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn69.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn69.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colInstitutstyp
        '
        Me.layoutViewField_colInstitutstyp.EditorPreferredWidth = 321
        Me.layoutViewField_colInstitutstyp.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colInstitutstyp.Name = "layoutViewField_colInstitutstyp"
        Me.layoutViewField_colInstitutstyp.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colInstitutstyp.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colInstitutstyp.TextToControlDistance = 5
        '
        'LayoutViewColumn70
        '
        Me.LayoutViewColumn70.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn70.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn70.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn70.FieldName = "BLZ der vorgeschalteten Stelle"
        Me.LayoutViewColumn70.LayoutViewField = Me.layoutViewField_colBLZdervorgeschaltetenStelle
        Me.LayoutViewColumn70.Name = "LayoutViewColumn70"
        Me.LayoutViewColumn70.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn70.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn70.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colBLZdervorgeschaltetenStelle
        '
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.EditorPreferredWidth = 321
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Name = "layoutViewField_colBLZdervorgeschaltetenStelle"
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colBLZdervorgeschaltetenStelle.TextToControlDistance = 5
        '
        'LayoutViewColumn71
        '
        Me.LayoutViewColumn71.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn71.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn71.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn71.FieldName = "Avisierung von Zahlungen TEL"
        Me.LayoutViewColumn71.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenTEL
        Me.LayoutViewColumn71.Name = "LayoutViewColumn71"
        Me.LayoutViewColumn71.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn71.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn71.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenTEL
        '
        Me.layoutViewField_colAvisierungvonZahlungenTEL.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Name = "layoutViewField_colAvisierungvonZahlungenTEL"
        Me.layoutViewField_colAvisierungvonZahlungenTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenTEL.TextSize = New System.Drawing.Size(161, 13)
        Me.layoutViewField_colAvisierungvonZahlungenTEL.TextToControlDistance = 5
        '
        'LayoutViewColumn72
        '
        Me.LayoutViewColumn72.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn72.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn72.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn72.FieldName = "Avisierung von Zahlungen FAX"
        Me.LayoutViewColumn72.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenFAX
        Me.LayoutViewColumn72.Name = "LayoutViewColumn72"
        Me.LayoutViewColumn72.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn72.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn72.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenFAX
        '
        Me.layoutViewField_colAvisierungvonZahlungenFAX.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Name = "layoutViewField_colAvisierungvonZahlungenFAX"
        Me.layoutViewField_colAvisierungvonZahlungenFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenFAX.TextSize = New System.Drawing.Size(161, 13)
        Me.layoutViewField_colAvisierungvonZahlungenFAX.TextToControlDistance = 5
        '
        'LayoutViewColumn73
        '
        Me.LayoutViewColumn73.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn73.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn73.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn73.FieldName = "Avisierung von Zahlungen EMAIL"
        Me.LayoutViewColumn73.LayoutViewField = Me.layoutViewField_colAvisierungvonZahlungenEMAIL
        Me.LayoutViewColumn73.Name = "LayoutViewColumn73"
        Me.LayoutViewColumn73.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn73.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn73.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colAvisierungvonZahlungenEMAIL
        '
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.EditorPreferredWidth = 561
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Name = "layoutViewField_colAvisierungvonZahlungenEMAIL"
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.TextSize = New System.Drawing.Size(161, 13)
        Me.layoutViewField_colAvisierungvonZahlungenEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn74
        '
        Me.LayoutViewColumn74.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn74.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn74.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn74.FieldName = "Überweisungs-nachfragen TEL"
        Me.LayoutViewColumn74.LayoutViewField = Me.LayoutViewField54
        Me.LayoutViewColumn74.Name = "LayoutViewColumn74"
        Me.LayoutViewColumn74.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn74.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn74.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField54
        '
        Me.LayoutViewField54.EditorPreferredWidth = 357
        Me.LayoutViewField54.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField54.Name = "LayoutViewField54"
        Me.LayoutViewField54.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField54.TextSize = New System.Drawing.Size(159, 13)
        Me.LayoutViewField54.TextToControlDistance = 5
        '
        'LayoutViewColumn75
        '
        Me.LayoutViewColumn75.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn75.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn75.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn75.FieldName = "Überweisungs-nachfragen FAX"
        Me.LayoutViewColumn75.LayoutViewField = Me.LayoutViewField55
        Me.LayoutViewColumn75.Name = "LayoutViewColumn75"
        Me.LayoutViewColumn75.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn75.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn75.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField55
        '
        Me.LayoutViewField55.EditorPreferredWidth = 357
        Me.LayoutViewField55.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField55.Name = "LayoutViewField55"
        Me.LayoutViewField55.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField55.TextSize = New System.Drawing.Size(159, 13)
        Me.LayoutViewField55.TextToControlDistance = 5
        '
        'LayoutViewColumn76
        '
        Me.LayoutViewColumn76.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn76.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn76.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn76.FieldName = "Überweisungsnachfragen EMAIL"
        Me.LayoutViewColumn76.LayoutViewField = Me.layoutViewField_colÜberweisungsnachfragenEMAIL
        Me.LayoutViewColumn76.Name = "LayoutViewColumn76"
        Me.LayoutViewColumn76.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn76.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn76.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colÜberweisungsnachfragenEMAIL
        '
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.EditorPreferredWidth = 357
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Name = "layoutViewField_colÜberweisungsnachfragenEMAIL"
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.Size = New System.Drawing.Size(525, 20)
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.TextSize = New System.Drawing.Size(159, 13)
        Me.layoutViewField_colÜberweisungsnachfragenEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn77
        '
        Me.LayoutViewColumn77.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn77.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn77.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn77.FieldName = "Überweisungs-rückruf TEL"
        Me.LayoutViewColumn77.LayoutViewField = Me.LayoutViewField56
        Me.LayoutViewColumn77.Name = "LayoutViewColumn77"
        Me.LayoutViewColumn77.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn77.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn77.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField56
        '
        Me.LayoutViewField56.EditorPreferredWidth = 591
        Me.LayoutViewField56.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField56.Name = "LayoutViewField56"
        Me.LayoutViewField56.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField56.TextSize = New System.Drawing.Size(131, 13)
        Me.LayoutViewField56.TextToControlDistance = 5
        '
        'LayoutViewColumn78
        '
        Me.LayoutViewColumn78.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn78.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn78.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn78.FieldName = "Überweisungs-rückruf FAX"
        Me.LayoutViewColumn78.LayoutViewField = Me.LayoutViewField57
        Me.LayoutViewColumn78.Name = "LayoutViewColumn78"
        Me.LayoutViewColumn78.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn78.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn78.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField57
        '
        Me.LayoutViewField57.EditorPreferredWidth = 591
        Me.LayoutViewField57.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField57.Name = "LayoutViewField57"
        Me.LayoutViewField57.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField57.TextSize = New System.Drawing.Size(131, 13)
        Me.LayoutViewField57.TextToControlDistance = 5
        '
        'LayoutViewColumn79
        '
        Me.LayoutViewColumn79.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn79.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn79.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn79.FieldName = "Überweisungs-rückfragen TEL"
        Me.LayoutViewColumn79.LayoutViewField = Me.LayoutViewField58
        Me.LayoutViewColumn79.Name = "LayoutViewColumn79"
        Me.LayoutViewColumn79.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn79.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn79.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField58
        '
        Me.LayoutViewField58.EditorPreferredWidth = 566
        Me.LayoutViewField58.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField58.Name = "LayoutViewField58"
        Me.LayoutViewField58.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField58.TextSize = New System.Drawing.Size(156, 13)
        Me.LayoutViewField58.TextToControlDistance = 5
        '
        'LayoutViewColumn80
        '
        Me.LayoutViewColumn80.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn80.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn80.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn80.FieldName = "Überweisungs-rückfragen FAX"
        Me.LayoutViewColumn80.LayoutViewField = Me.LayoutViewField59
        Me.LayoutViewColumn80.Name = "LayoutViewColumn80"
        Me.LayoutViewColumn80.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn80.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn80.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField59
        '
        Me.LayoutViewField59.EditorPreferredWidth = 566
        Me.LayoutViewField59.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField59.Name = "LayoutViewField59"
        Me.LayoutViewField59.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField59.TextSize = New System.Drawing.Size(156, 13)
        Me.LayoutViewField59.TextToControlDistance = 5
        '
        'LayoutViewColumn81
        '
        Me.LayoutViewColumn81.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn81.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn81.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn81.FieldName = "Überweisungsrückfragen EMAIL"
        Me.LayoutViewColumn81.LayoutViewField = Me.layoutViewField_colÜberweisungsrückfragenEMAIL
        Me.LayoutViewColumn81.Name = "LayoutViewColumn81"
        Me.LayoutViewColumn81.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn81.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn81.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colÜberweisungsrückfragenEMAIL
        '
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.EditorPreferredWidth = 566
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Name = "layoutViewField_colÜberweisungsrückfragenEMAIL"
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.TextSize = New System.Drawing.Size(156, 13)
        Me.layoutViewField_colÜberweisungsrückfragenEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn82
        '
        Me.LayoutViewColumn82.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn82.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn82.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn82.FieldName = "Scheckanfrage TEL"
        Me.LayoutViewColumn82.LayoutViewField = Me.layoutViewField_colScheckanfrageTEL
        Me.LayoutViewColumn82.Name = "LayoutViewColumn82"
        Me.LayoutViewColumn82.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn82.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn82.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageTEL
        '
        Me.layoutViewField_colScheckanfrageTEL.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colScheckanfrageTEL.Name = "layoutViewField_colScheckanfrageTEL"
        Me.layoutViewField_colScheckanfrageTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageTEL.TextSize = New System.Drawing.Size(108, 13)
        Me.layoutViewField_colScheckanfrageTEL.TextToControlDistance = 5
        '
        'LayoutViewColumn83
        '
        Me.LayoutViewColumn83.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn83.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn83.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn83.FieldName = "Scheckanfrage FAX"
        Me.LayoutViewColumn83.LayoutViewField = Me.layoutViewField_colScheckanfrageFAX
        Me.LayoutViewColumn83.Name = "LayoutViewColumn83"
        Me.LayoutViewColumn83.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn83.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn83.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageFAX
        '
        Me.layoutViewField_colScheckanfrageFAX.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colScheckanfrageFAX.Name = "layoutViewField_colScheckanfrageFAX"
        Me.layoutViewField_colScheckanfrageFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageFAX.TextSize = New System.Drawing.Size(108, 13)
        Me.layoutViewField_colScheckanfrageFAX.TextToControlDistance = 5
        '
        'LayoutViewColumn84
        '
        Me.LayoutViewColumn84.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn84.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn84.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn84.FieldName = "Scheckanfrage EMAIL"
        Me.LayoutViewColumn84.LayoutViewField = Me.layoutViewField_colScheckanfrageEMAIL
        Me.LayoutViewColumn84.Name = "LayoutViewColumn84"
        Me.LayoutViewColumn84.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn84.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn84.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colScheckanfrageEMAIL
        '
        Me.layoutViewField_colScheckanfrageEMAIL.EditorPreferredWidth = 614
        Me.layoutViewField_colScheckanfrageEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colScheckanfrageEMAIL.Name = "layoutViewField_colScheckanfrageEMAIL"
        Me.layoutViewField_colScheckanfrageEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colScheckanfrageEMAIL.TextSize = New System.Drawing.Size(108, 13)
        Me.layoutViewField_colScheckanfrageEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn85
        '
        Me.LayoutViewColumn85.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn85.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn85.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn85.FieldName = "Unbezahlte Schecks/ Lastschriften TEL"
        Me.LayoutViewColumn85.LayoutViewField = Me.LayoutViewField60
        Me.LayoutViewColumn85.Name = "LayoutViewColumn85"
        Me.LayoutViewColumn85.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn85.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn85.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField60
        '
        Me.LayoutViewField60.EditorPreferredWidth = 521
        Me.LayoutViewField60.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField60.Name = "LayoutViewField60"
        Me.LayoutViewField60.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField60.TextSize = New System.Drawing.Size(201, 13)
        Me.LayoutViewField60.TextToControlDistance = 5
        '
        'LayoutViewColumn86
        '
        Me.LayoutViewColumn86.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn86.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn86.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn86.FieldName = "Unbezahlte Schecks/ Lastschriften FAX"
        Me.LayoutViewColumn86.LayoutViewField = Me.LayoutViewField61
        Me.LayoutViewColumn86.Name = "LayoutViewColumn86"
        Me.LayoutViewColumn86.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn86.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn86.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField61
        '
        Me.LayoutViewField61.EditorPreferredWidth = 521
        Me.LayoutViewField61.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField61.Name = "LayoutViewField61"
        Me.LayoutViewField61.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField61.TextSize = New System.Drawing.Size(201, 13)
        Me.LayoutViewField61.TextToControlDistance = 5
        '
        'LayoutViewColumn87
        '
        Me.LayoutViewColumn87.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn87.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn87.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn87.FieldName = "Unbezahlte Schecks/ Lastschriften EMAIL"
        Me.LayoutViewColumn87.LayoutViewField = Me.LayoutViewField62
        Me.LayoutViewColumn87.Name = "LayoutViewColumn87"
        Me.LayoutViewColumn87.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn87.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn87.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField62
        '
        Me.LayoutViewField62.EditorPreferredWidth = 521
        Me.LayoutViewField62.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField62.Name = "LayoutViewField62"
        Me.LayoutViewField62.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField62.TextSize = New System.Drawing.Size(201, 13)
        Me.LayoutViewField62.TextToControlDistance = 5
        '
        'LayoutViewColumn88
        '
        Me.LayoutViewColumn88.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn88.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn88.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn88.FieldName = "Lastschrift-rückruf TEL"
        Me.LayoutViewColumn88.LayoutViewField = Me.LayoutViewField63
        Me.LayoutViewColumn88.Name = "LayoutViewColumn88"
        Me.LayoutViewColumn88.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn88.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn88.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField63
        '
        Me.LayoutViewField63.EditorPreferredWidth = 601
        Me.LayoutViewField63.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField63.Name = "LayoutViewField63"
        Me.LayoutViewField63.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField63.TextSize = New System.Drawing.Size(121, 13)
        Me.LayoutViewField63.TextToControlDistance = 5
        '
        'LayoutViewColumn89
        '
        Me.LayoutViewColumn89.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn89.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn89.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn89.FieldName = "Lastschrift-rückruf FAX"
        Me.LayoutViewColumn89.LayoutViewField = Me.LayoutViewField64
        Me.LayoutViewColumn89.Name = "LayoutViewColumn89"
        Me.LayoutViewColumn89.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn89.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn89.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField64
        '
        Me.LayoutViewField64.EditorPreferredWidth = 601
        Me.LayoutViewField64.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField64.Name = "LayoutViewField64"
        Me.LayoutViewField64.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField64.TextSize = New System.Drawing.Size(121, 13)
        Me.LayoutViewField64.TextToControlDistance = 5
        '
        'LayoutViewColumn90
        '
        Me.LayoutViewColumn90.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn90.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn90.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn90.FieldName = "Lastschriftrückruf EMAIL"
        Me.LayoutViewColumn90.LayoutViewField = Me.layoutViewField_colLastschriftrückrufEMAIL
        Me.LayoutViewColumn90.Name = "LayoutViewColumn90"
        Me.LayoutViewColumn90.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn90.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn90.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colLastschriftrückrufEMAIL
        '
        Me.layoutViewField_colLastschriftrückrufEMAIL.EditorPreferredWidth = 601
        Me.layoutViewField_colLastschriftrückrufEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colLastschriftrückrufEMAIL.Name = "layoutViewField_colLastschriftrückrufEMAIL"
        Me.layoutViewField_colLastschriftrückrufEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colLastschriftrückrufEMAIL.TextSize = New System.Drawing.Size(121, 13)
        Me.layoutViewField_colLastschriftrückrufEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn91
        '
        Me.LayoutViewColumn91.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn91.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn91.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn91.FieldName = "Wechselrückrufe TEL"
        Me.LayoutViewColumn91.LayoutViewField = Me.layoutViewField_colWechselrückrufeTEL
        Me.LayoutViewColumn91.Name = "LayoutViewColumn91"
        Me.LayoutViewColumn91.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn91.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn91.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeTEL
        '
        Me.layoutViewField_colWechselrückrufeTEL.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colWechselrückrufeTEL.Name = "layoutViewField_colWechselrückrufeTEL"
        Me.layoutViewField_colWechselrückrufeTEL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeTEL.TextSize = New System.Drawing.Size(117, 13)
        Me.layoutViewField_colWechselrückrufeTEL.TextToControlDistance = 5
        '
        'LayoutViewColumn92
        '
        Me.LayoutViewColumn92.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn92.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn92.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn92.FieldName = "Wechselrückrufe FAX"
        Me.LayoutViewColumn92.LayoutViewField = Me.layoutViewField_colWechselrückrufeFAX
        Me.LayoutViewColumn92.Name = "LayoutViewColumn92"
        Me.LayoutViewColumn92.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn92.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn92.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeFAX
        '
        Me.layoutViewField_colWechselrückrufeFAX.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colWechselrückrufeFAX.Name = "layoutViewField_colWechselrückrufeFAX"
        Me.layoutViewField_colWechselrückrufeFAX.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeFAX.TextSize = New System.Drawing.Size(117, 13)
        Me.layoutViewField_colWechselrückrufeFAX.TextToControlDistance = 5
        '
        'LayoutViewColumn93
        '
        Me.LayoutViewColumn93.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn93.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn93.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn93.FieldName = "Wechselrückrufe EMAIL"
        Me.LayoutViewColumn93.LayoutViewField = Me.layoutViewField_colWechselrückrufeEMAIL
        Me.LayoutViewColumn93.Name = "LayoutViewColumn93"
        Me.LayoutViewColumn93.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn93.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn93.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colWechselrückrufeEMAIL
        '
        Me.layoutViewField_colWechselrückrufeEMAIL.EditorPreferredWidth = 581
        Me.layoutViewField_colWechselrückrufeEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colWechselrückrufeEMAIL.Name = "layoutViewField_colWechselrückrufeEMAIL"
        Me.layoutViewField_colWechselrückrufeEMAIL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colWechselrückrufeEMAIL.TextSize = New System.Drawing.Size(117, 13)
        Me.layoutViewField_colWechselrückrufeEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn94
        '
        Me.LayoutViewColumn94.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn94.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn94.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn94.FieldName = "Unbezahlte Wechsel TEL"
        Me.LayoutViewColumn94.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselTEL
        Me.LayoutViewColumn94.Name = "LayoutViewColumn94"
        Me.LayoutViewColumn94.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn94.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn94.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselTEL
        '
        Me.layoutViewField_colUnbezahlteWechselTEL.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUnbezahlteWechselTEL.Name = "layoutViewField_colUnbezahlteWechselTEL"
        Me.layoutViewField_colUnbezahlteWechselTEL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselTEL.TextSize = New System.Drawing.Size(134, 13)
        Me.layoutViewField_colUnbezahlteWechselTEL.TextToControlDistance = 5
        '
        'LayoutViewColumn95
        '
        Me.LayoutViewColumn95.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn95.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn95.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn95.FieldName = "Unbezahlte Wechsel FAX"
        Me.LayoutViewColumn95.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselFAX
        Me.LayoutViewColumn95.Name = "LayoutViewColumn95"
        Me.LayoutViewColumn95.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn95.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn95.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselFAX
        '
        Me.layoutViewField_colUnbezahlteWechselFAX.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colUnbezahlteWechselFAX.Name = "layoutViewField_colUnbezahlteWechselFAX"
        Me.layoutViewField_colUnbezahlteWechselFAX.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselFAX.TextSize = New System.Drawing.Size(134, 13)
        Me.layoutViewField_colUnbezahlteWechselFAX.TextToControlDistance = 5
        '
        'LayoutViewColumn96
        '
        Me.LayoutViewColumn96.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn96.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn96.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn96.FieldName = "Unbezahlte Wechsel EMAIL"
        Me.LayoutViewColumn96.LayoutViewField = Me.layoutViewField_colUnbezahlteWechselEMAIL
        Me.LayoutViewColumn96.Name = "LayoutViewColumn96"
        Me.LayoutViewColumn96.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn96.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn96.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUnbezahlteWechselEMAIL
        '
        Me.layoutViewField_colUnbezahlteWechselEMAIL.EditorPreferredWidth = 564
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Name = "layoutViewField_colUnbezahlteWechselEMAIL"
        Me.layoutViewField_colUnbezahlteWechselEMAIL.Size = New System.Drawing.Size(707, 20)
        Me.layoutViewField_colUnbezahlteWechselEMAIL.TextSize = New System.Drawing.Size(134, 13)
        Me.layoutViewField_colUnbezahlteWechselEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn97
        '
        Me.LayoutViewColumn97.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn97.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn97.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn97.FieldName = "Vorgeschaltete Stelle TEL"
        Me.LayoutViewColumn97.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleTEL
        Me.LayoutViewColumn97.Name = "LayoutViewColumn97"
        Me.LayoutViewColumn97.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn97.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn97.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleTEL
        '
        Me.layoutViewField_colVorgeschalteteStelleTEL.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleTEL.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colVorgeschalteteStelleTEL.Name = "layoutViewField_colVorgeschalteteStelleTEL"
        Me.layoutViewField_colVorgeschalteteStelleTEL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleTEL.TextSize = New System.Drawing.Size(138, 13)
        Me.layoutViewField_colVorgeschalteteStelleTEL.TextToControlDistance = 5
        '
        'LayoutViewColumn98
        '
        Me.LayoutViewColumn98.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn98.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn98.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn98.FieldName = "Vorgeschaltete Stelle FAX"
        Me.LayoutViewColumn98.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleFAX
        Me.LayoutViewColumn98.Name = "LayoutViewColumn98"
        Me.LayoutViewColumn98.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn98.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn98.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleFAX
        '
        Me.layoutViewField_colVorgeschalteteStelleFAX.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleFAX.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colVorgeschalteteStelleFAX.Name = "layoutViewField_colVorgeschalteteStelleFAX"
        Me.layoutViewField_colVorgeschalteteStelleFAX.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleFAX.TextSize = New System.Drawing.Size(138, 13)
        Me.layoutViewField_colVorgeschalteteStelleFAX.TextToControlDistance = 5
        '
        'LayoutViewColumn99
        '
        Me.LayoutViewColumn99.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn99.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn99.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn99.FieldName = "Vorgeschaltete Stelle EMAIL"
        Me.LayoutViewColumn99.LayoutViewField = Me.layoutViewField_colVorgeschalteteStelleEMAIL
        Me.LayoutViewColumn99.Name = "LayoutViewColumn99"
        Me.LayoutViewColumn99.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn99.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn99.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colVorgeschalteteStelleEMAIL
        '
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.EditorPreferredWidth = 584
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Name = "layoutViewField_colVorgeschalteteStelleEMAIL"
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.Size = New System.Drawing.Size(731, 20)
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.TextSize = New System.Drawing.Size(138, 13)
        Me.layoutViewField_colVorgeschalteteStelleEMAIL.TextToControlDistance = 5
        '
        'LayoutViewColumn100
        '
        Me.LayoutViewColumn100.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn100.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn100.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn100.FieldName = "Meldeweg"
        Me.LayoutViewColumn100.LayoutViewField = Me.layoutViewField_colMeldeweg
        Me.LayoutViewColumn100.Name = "LayoutViewColumn100"
        Me.LayoutViewColumn100.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn100.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn100.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colMeldeweg
        '
        Me.layoutViewField_colMeldeweg.EditorPreferredWidth = 321
        Me.layoutViewField_colMeldeweg.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colMeldeweg.Name = "layoutViewField_colMeldeweg"
        Me.layoutViewField_colMeldeweg.Size = New System.Drawing.Size(523, 20)
        Me.layoutViewField_colMeldeweg.TextSize = New System.Drawing.Size(193, 13)
        Me.layoutViewField_colMeldeweg.TextToControlDistance = 5
        '
        'LayoutViewColumn101
        '
        Me.LayoutViewColumn101.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn101.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn101.ColumnEdit = Me.RepositoryItemComboBox2
        Me.LayoutViewColumn101.FieldName = "VALID"
        Me.LayoutViewColumn101.LayoutViewField = Me.LayoutViewField65
        Me.LayoutViewColumn101.Name = "LayoutViewColumn101"
        Me.LayoutViewColumn101.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn101.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn101.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField65
        '
        Me.LayoutViewField65.EditorPreferredWidth = 48
        Me.LayoutViewField65.Location = New System.Drawing.Point(0, 220)
        Me.LayoutViewField65.Name = "LayoutViewField65"
        Me.LayoutViewField65.Size = New System.Drawing.Size(250, 20)
        Me.LayoutViewField65.TextSize = New System.Drawing.Size(193, 13)
        Me.LayoutViewField65.TextToControlDistance = 5
        '
        'LayoutViewColumn102
        '
        Me.LayoutViewColumn102.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn102.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn102.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn102.FieldName = "USER"
        Me.LayoutViewColumn102.LayoutViewField = Me.layoutViewField_colUSER
        Me.LayoutViewColumn102.Name = "LayoutViewColumn102"
        Me.LayoutViewColumn102.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn102.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn102.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUSER
        '
        Me.layoutViewField_colUSER.EditorPreferredWidth = 20
        Me.layoutViewField_colUSER.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUSER.Name = "layoutViewField_colUSER"
        Me.layoutViewField_colUSER.Size = New System.Drawing.Size(547, 612)
        Me.layoutViewField_colUSER.TextSize = New System.Drawing.Size(201, 13)
        Me.layoutViewField_colUSER.TextToControlDistance = 5
        '
        'LayoutViewColumn103
        '
        Me.LayoutViewColumn103.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn103.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn103.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn103.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn103.LayoutViewField = Me.layoutViewField_colUNTERBEARBEITUNGVON
        Me.LayoutViewColumn103.Name = "LayoutViewColumn103"
        Me.LayoutViewColumn103.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn103.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn103.OptionsFilter.AllowFilter = False
        '
        'layoutViewField_colUNTERBEARBEITUNGVON
        '
        Me.layoutViewField_colUNTERBEARBEITUNGVON.EditorPreferredWidth = 20
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Name = "layoutViewField_colUNTERBEARBEITUNGVON"
        Me.layoutViewField_colUNTERBEARBEITUNGVON.Size = New System.Drawing.Size(547, 612)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextToControlDistance = 0
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextVisible = False
        '
        'LayoutViewCard2
        '
        Me.LayoutViewCard2.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard2.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID})
        Me.LayoutViewCard2.Name = "LayoutViewCard2"
        Me.LayoutViewCard2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard2.Text = "TemplateCard"
        '
        'LayoutView3
        '
        Me.LayoutView3.GridControl = Me.GridControl2
        Me.LayoutView3.Name = "LayoutView3"
        Me.LayoutView3.TemplateCard = Nothing
        '
        'LayoutView2
        '
        Me.LayoutView2.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn26, Me.LayoutViewColumn27, Me.LayoutViewColumn28, Me.LayoutViewColumn29, Me.LayoutViewColumn30, Me.LayoutViewColumn31, Me.LayoutViewColumn32, Me.LayoutViewColumn33, Me.LayoutViewColumn34, Me.LayoutViewColumn35, Me.LayoutViewColumn36, Me.LayoutViewColumn37, Me.LayoutViewColumn38, Me.LayoutViewColumn39, Me.LayoutViewColumn40, Me.LayoutViewColumn41, Me.LayoutViewColumn42, Me.LayoutViewColumn43, Me.LayoutViewColumn44, Me.LayoutViewColumn45, Me.LayoutViewColumn46, Me.LayoutViewColumn47, Me.LayoutViewColumn48, Me.LayoutViewColumn49, Me.LayoutViewColumn50})
        Me.LayoutView2.GridControl = Me.GridControl2
        Me.LayoutView2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField22, Me.LayoutViewField21, Me.LayoutViewField19})
        Me.LayoutView2.Name = "LayoutView2"
        Me.LayoutView2.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView2.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsCustomization.AllowFilter = False
        Me.LayoutView2.OptionsCustomization.AllowSort = False
        Me.LayoutView2.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView2.OptionsCustomization.ShowGroupView = False
        Me.LayoutView2.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView2.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView2.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView2.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView2.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView2.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView2.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn26, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView2.TemplateCard = Nothing
        '
        'LayoutViewColumn26
        '
        Me.LayoutViewColumn26.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn26.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn26.FieldName = "Idnr"
        Me.LayoutViewColumn26.LayoutViewField = Me.LayoutViewField1
        Me.LayoutViewColumn26.Name = "LayoutViewColumn26"
        Me.LayoutViewColumn26.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField1
        '
        Me.LayoutViewField1.EditorPreferredWidth = 61
        Me.LayoutViewField1.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField1.Name = "LayoutViewField1"
        Me.LayoutViewField1.Size = New System.Drawing.Size(178, 20)
        Me.LayoutViewField1.TextSize = New System.Drawing.Size(108, 13)
        Me.LayoutViewField1.TextToControlDistance = 5
        '
        'LayoutViewColumn27
        '
        Me.LayoutViewColumn27.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn27.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn27.FieldName = "TAG"
        Me.LayoutViewColumn27.LayoutViewField = Me.LayoutViewField2
        Me.LayoutViewColumn27.Name = "LayoutViewColumn27"
        '
        'LayoutViewField2
        '
        Me.LayoutViewField2.EditorPreferredWidth = 318
        Me.LayoutViewField2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField2.Name = "LayoutViewField2"
        Me.LayoutViewField2.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField2.TextSize = New System.Drawing.Size(108, 13)
        Me.LayoutViewField2.TextToControlDistance = 5
        '
        'LayoutViewColumn28
        '
        Me.LayoutViewColumn28.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn28.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn28.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn28.LayoutViewField = Me.LayoutViewField3
        Me.LayoutViewColumn28.Name = "LayoutViewColumn28"
        '
        'LayoutViewField3
        '
        Me.LayoutViewField3.EditorPreferredWidth = 318
        Me.LayoutViewField3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField3.Name = "LayoutViewField3"
        Me.LayoutViewField3.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField3.TextSize = New System.Drawing.Size(108, 13)
        Me.LayoutViewField3.TextToControlDistance = 5
        '
        'LayoutViewColumn29
        '
        Me.LayoutViewColumn29.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn29.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn29.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn29.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn29.LayoutViewField = Me.LayoutViewField4
        Me.LayoutViewColumn29.Name = "LayoutViewColumn29"
        '
        'LayoutViewField4
        '
        Me.LayoutViewField4.EditorPreferredWidth = 306
        Me.LayoutViewField4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField4.Name = "LayoutViewField4"
        Me.LayoutViewField4.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField4.TextSize = New System.Drawing.Size(120, 13)
        Me.LayoutViewField4.TextToControlDistance = 5
        '
        'LayoutViewColumn30
        '
        Me.LayoutViewColumn30.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn30.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn30.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn30.LayoutViewField = Me.LayoutViewField5
        Me.LayoutViewColumn30.Name = "LayoutViewColumn30"
        '
        'LayoutViewField5
        '
        Me.LayoutViewField5.EditorPreferredWidth = 306
        Me.LayoutViewField5.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField5.Name = "LayoutViewField5"
        Me.LayoutViewField5.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField5.TextSize = New System.Drawing.Size(120, 13)
        Me.LayoutViewField5.TextToControlDistance = 5
        '
        'LayoutViewColumn31
        '
        Me.LayoutViewColumn31.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn31.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn31.FieldName = "CITY HEADING"
        Me.LayoutViewColumn31.LayoutViewField = Me.LayoutViewField6
        Me.LayoutViewColumn31.Name = "LayoutViewColumn31"
        '
        'LayoutViewField6
        '
        Me.LayoutViewField6.EditorPreferredWidth = 306
        Me.LayoutViewField6.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField6.Name = "LayoutViewField6"
        Me.LayoutViewField6.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField6.TextSize = New System.Drawing.Size(120, 13)
        Me.LayoutViewField6.TextToControlDistance = 5
        '
        'LayoutViewColumn32
        '
        Me.LayoutViewColumn32.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn32.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn32.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn32.LayoutViewField = Me.LayoutViewField7
        Me.LayoutViewColumn32.Name = "LayoutViewColumn32"
        '
        'LayoutViewField7
        '
        Me.LayoutViewField7.EditorPreferredWidth = 306
        Me.LayoutViewField7.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField7.Name = "LayoutViewField7"
        Me.LayoutViewField7.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField7.TextSize = New System.Drawing.Size(120, 13)
        Me.LayoutViewField7.TextToControlDistance = 5
        '
        'LayoutViewColumn33
        '
        Me.LayoutViewColumn33.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn33.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn33.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn33.LayoutViewField = Me.LayoutViewField8
        Me.LayoutViewColumn33.Name = "LayoutViewColumn33"
        '
        'LayoutViewField8
        '
        Me.LayoutViewField8.EditorPreferredWidth = 303
        Me.LayoutViewField8.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField8.Name = "LayoutViewField8"
        Me.LayoutViewField8.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField8.TextSize = New System.Drawing.Size(123, 13)
        Me.LayoutViewField8.TextToControlDistance = 5
        '
        'LayoutViewColumn34
        '
        Me.LayoutViewColumn34.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn34.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn34.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn34.LayoutViewField = Me.LayoutViewField9
        Me.LayoutViewColumn34.Name = "LayoutViewColumn34"
        '
        'LayoutViewField9
        '
        Me.LayoutViewField9.EditorPreferredWidth = 318
        Me.LayoutViewField9.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField9.Name = "LayoutViewField9"
        Me.LayoutViewField9.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField9.TextSize = New System.Drawing.Size(108, 13)
        Me.LayoutViewField9.TextToControlDistance = 5
        '
        'LayoutViewColumn35
        '
        Me.LayoutViewColumn35.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn35.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn35.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn35.LayoutViewField = Me.LayoutViewField10
        Me.LayoutViewColumn35.Name = "LayoutViewColumn35"
        '
        'LayoutViewField10
        '
        Me.LayoutViewField10.EditorPreferredWidth = 316
        Me.LayoutViewField10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField10.Name = "LayoutViewField10"
        Me.LayoutViewField10.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField10.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField10.TextToControlDistance = 5
        '
        'LayoutViewColumn36
        '
        Me.LayoutViewColumn36.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn36.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn36.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn36.LayoutViewField = Me.LayoutViewField11
        Me.LayoutViewColumn36.Name = "LayoutViewColumn36"
        '
        'LayoutViewField11
        '
        Me.LayoutViewField11.EditorPreferredWidth = 316
        Me.LayoutViewField11.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField11.Name = "LayoutViewField11"
        Me.LayoutViewField11.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField11.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField11.TextToControlDistance = 5
        '
        'LayoutViewColumn37
        '
        Me.LayoutViewColumn37.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn37.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn37.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn37.LayoutViewField = Me.LayoutViewField12
        Me.LayoutViewColumn37.Name = "LayoutViewColumn37"
        '
        'LayoutViewField12
        '
        Me.LayoutViewField12.EditorPreferredWidth = 316
        Me.LayoutViewField12.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField12.Name = "LayoutViewField12"
        Me.LayoutViewField12.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField12.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField12.TextToControlDistance = 5
        '
        'LayoutViewColumn38
        '
        Me.LayoutViewColumn38.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn38.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn38.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn38.LayoutViewField = Me.LayoutViewField13
        Me.LayoutViewColumn38.Name = "LayoutViewColumn38"
        '
        'LayoutViewField13
        '
        Me.LayoutViewField13.EditorPreferredWidth = 316
        Me.LayoutViewField13.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField13.Name = "LayoutViewField13"
        Me.LayoutViewField13.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField13.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField13.TextToControlDistance = 5
        '
        'LayoutViewColumn39
        '
        Me.LayoutViewColumn39.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn39.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn39.FieldName = "LOCATION"
        Me.LayoutViewColumn39.LayoutViewField = Me.LayoutViewField14
        Me.LayoutViewColumn39.Name = "LayoutViewColumn39"
        '
        'LayoutViewField14
        '
        Me.LayoutViewField14.EditorPreferredWidth = 316
        Me.LayoutViewField14.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField14.Name = "LayoutViewField14"
        Me.LayoutViewField14.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField14.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField14.TextToControlDistance = 5
        '
        'LayoutViewColumn40
        '
        Me.LayoutViewColumn40.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn40.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn40.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn40.LayoutViewField = Me.LayoutViewField15
        Me.LayoutViewColumn40.Name = "LayoutViewColumn40"
        '
        'LayoutViewField15
        '
        Me.LayoutViewField15.EditorPreferredWidth = 316
        Me.LayoutViewField15.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField15.Name = "LayoutViewField15"
        Me.LayoutViewField15.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField15.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField15.TextToControlDistance = 5
        '
        'LayoutViewColumn41
        '
        Me.LayoutViewColumn41.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn41.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn41.FieldName = "POB NUMBER"
        Me.LayoutViewColumn41.LayoutViewField = Me.LayoutViewField16
        Me.LayoutViewColumn41.Name = "LayoutViewColumn41"
        '
        'LayoutViewField16
        '
        Me.LayoutViewField16.EditorPreferredWidth = 316
        Me.LayoutViewField16.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField16.Name = "LayoutViewField16"
        Me.LayoutViewField16.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField16.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField16.TextToControlDistance = 5
        '
        'LayoutViewColumn42
        '
        Me.LayoutViewColumn42.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn42.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn42.FieldName = "POB LOCATION"
        Me.LayoutViewColumn42.LayoutViewField = Me.LayoutViewField17
        Me.LayoutViewColumn42.Name = "LayoutViewColumn42"
        '
        'LayoutViewField17
        '
        Me.LayoutViewField17.EditorPreferredWidth = 316
        Me.LayoutViewField17.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField17.Name = "LayoutViewField17"
        Me.LayoutViewField17.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField17.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField17.TextToControlDistance = 5
        '
        'LayoutViewColumn43
        '
        Me.LayoutViewColumn43.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn43.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn43.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn43.LayoutViewField = Me.LayoutViewField18
        Me.LayoutViewColumn43.Name = "LayoutViewColumn43"
        '
        'LayoutViewField18
        '
        Me.LayoutViewField18.EditorPreferredWidth = 316
        Me.LayoutViewField18.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField18.Name = "LayoutViewField18"
        Me.LayoutViewField18.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField18.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField18.TextToControlDistance = 5
        '
        'LayoutViewColumn44
        '
        Me.LayoutViewColumn44.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn44.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn44.FieldName = "USER"
        Me.LayoutViewColumn44.LayoutViewField = Me.LayoutViewField19
        Me.LayoutViewColumn44.Name = "LayoutViewColumn44"
        Me.LayoutViewColumn44.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField19
        '
        Me.LayoutViewField19.EditorPreferredWidth = 20
        Me.LayoutViewField19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField19.Name = "LayoutViewField19"
        Me.LayoutViewField19.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField19.TextSize = New System.Drawing.Size(133, 20)
        Me.LayoutViewField19.TextToControlDistance = 5
        '
        'LayoutViewColumn45
        '
        Me.LayoutViewColumn45.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn45.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn45.ColumnEdit = Me.RepositoryItemComboBox2
        Me.LayoutViewColumn45.FieldName = "VALID"
        Me.LayoutViewColumn45.LayoutViewField = Me.LayoutViewField20
        Me.LayoutViewColumn45.Name = "LayoutViewColumn45"
        '
        'LayoutViewField20
        '
        Me.LayoutViewField20.EditorPreferredWidth = 70
        Me.LayoutViewField20.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField20.Name = "LayoutViewField20"
        Me.LayoutViewField20.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField20.TextSize = New System.Drawing.Size(123, 13)
        Me.LayoutViewField20.TextToControlDistance = 5
        '
        'LayoutViewColumn46
        '
        Me.LayoutViewColumn46.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn46.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn46.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn46.LayoutViewField = Me.LayoutViewField21
        Me.LayoutViewColumn46.Name = "LayoutViewColumn46"
        Me.LayoutViewColumn46.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField21
        '
        Me.LayoutViewField21.EditorPreferredWidth = 20
        Me.LayoutViewField21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField21.Name = "LayoutViewField21"
        Me.LayoutViewField21.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField21.TextSize = New System.Drawing.Size(133, 20)
        Me.LayoutViewField21.TextToControlDistance = 5
        '
        'LayoutViewColumn47
        '
        Me.LayoutViewColumn47.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn47.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn47.FieldName = "BIC11"
        Me.LayoutViewColumn47.LayoutViewField = Me.LayoutViewField22
        Me.LayoutViewColumn47.Name = "LayoutViewColumn47"
        Me.LayoutViewColumn47.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField22
        '
        Me.LayoutViewField22.EditorPreferredWidth = 20
        Me.LayoutViewField22.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField22.Name = "LayoutViewField22"
        Me.LayoutViewField22.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField22.TextSize = New System.Drawing.Size(133, 20)
        Me.LayoutViewField22.TextToControlDistance = 5
        '
        'LayoutViewColumn48
        '
        Me.LayoutViewColumn48.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn48.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn48.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn48.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn48.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn48.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn48.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn48.FieldName = "BIC CODE"
        Me.LayoutViewColumn48.ImageIndex = 0
        Me.LayoutViewColumn48.LayoutViewField = Me.LayoutViewField23
        Me.LayoutViewColumn48.Name = "LayoutViewColumn48"
        '
        'LayoutViewField23
        '
        Me.LayoutViewField23.EditorPreferredWidth = 70
        Me.LayoutViewField23.ImageIndex = 0
        Me.LayoutViewField23.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField23.Name = "LayoutViewField23"
        Me.LayoutViewField23.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField23.TextSize = New System.Drawing.Size(123, 16)
        Me.LayoutViewField23.TextToControlDistance = 5
        '
        'LayoutViewColumn49
        '
        Me.LayoutViewColumn49.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn49.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn49.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn49.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn49.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn49.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn49.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.LayoutViewColumn49.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn49.LayoutViewField = Me.LayoutViewField24
        Me.LayoutViewColumn49.Name = "LayoutViewColumn49"
        '
        'LayoutViewField24
        '
        Me.LayoutViewField24.EditorPreferredWidth = 70
        Me.LayoutViewField24.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField24.Name = "LayoutViewField24"
        Me.LayoutViewField24.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField24.TextSize = New System.Drawing.Size(123, 13)
        Me.LayoutViewField24.TextToControlDistance = 5
        '
        'LayoutViewColumn50
        '
        Me.LayoutViewColumn50.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn50.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn50.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn50.FieldName = "COUNTRY"
        Me.LayoutViewColumn50.LayoutViewField = Me.LayoutViewField25
        Me.LayoutViewColumn50.Name = "LayoutViewColumn50"
        Me.LayoutViewColumn50.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField25
        '
        Me.LayoutViewField25.EditorPreferredWidth = 316
        Me.LayoutViewField25.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField25.Name = "LayoutViewField25"
        Me.LayoutViewField25.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField25.TextSize = New System.Drawing.Size(110, 13)
        Me.LayoutViewField25.TextToControlDistance = 5
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Root"
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1244, 649)
        Me.LayoutControlGroup4.Text = "Root"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl2
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem1"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1224, 579)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "LayoutControlItem1"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1224, 50)
        Me.LayoutControlGroup5.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.Edit_INTERBANKV_Details_btn
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1032, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem2"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(168, 26)
        Me.LayoutControlItem6.Text = "LayoutControlItem2"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(143, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(889, 26)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.Print_Export_BT_ST_Temp_Gridview_btn
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem4"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(143, 26)
        Me.LayoutControlItem8.Text = "LayoutControlItem4"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextToControlDistance = 0
        Me.LayoutControlItem8.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl2
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'BgwSQL_Run
        '
        Me.BgwSQL_Run.WorkerReportsProgress = True
        Me.BgwSQL_Run.WorkerSupportsCancellation = True
        '
        'BgwSQL_ReRun
        '
        Me.BgwSQL_ReRun.WorkerReportsProgress = True
        Me.BgwSQL_ReRun.WorkerSupportsCancellation = True
        '
        'BgwSQL_ReRun_SpecificPeriod
        '
        Me.BgwSQL_ReRun_SpecificPeriod.WorkerReportsProgress = True
        Me.BgwSQL_ReRun_SpecificPeriod.WorkerSupportsCancellation = True
        '
        'BgwSQL_ReRun_All_Days
        '
        Me.BgwSQL_ReRun_All_Days.WorkerReportsProgress = True
        Me.BgwSQL_ReRun_All_Days.WorkerSupportsCancellation = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelControl7, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelControl4, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(238, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(181, 35)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Location = New System.Drawing.Point(3, 3)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(105, 13)
        Me.LabelControl7.TabIndex = 15
        Me.LabelControl7.Text = "WORKING CAPITAL"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAK_CR_TOTALSBindingSource, "WorkingCapital", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.LabelControl4.Location = New System.Drawing.Point(3, 18)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(110, 13)
        Me.LabelControl4.TabIndex = 17
        Me.LabelControl4.Text = "WorkingCapitalAmt"
        '
        'StressTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 732)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadBusinessTypes_btn)
        Me.Controls.Add(Me.BusinessTypeDateEdit)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StressTests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stress Tests"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BT_ST_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StressTestsLiveBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAK_CR_TOTALSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskControllingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_ST_Totals_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.StressTestsLiveDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessTypeDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessTypeDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StressTestsTempBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.BT_ST_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BT_ST_GEN_PARAM_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_ST_Temp_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBankleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBezeichnungdesZahlungsdienstleisters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladresseFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladresseOrt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladressePostfach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colZustelladressePostleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungPostfach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungStraße, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungPostleitzahl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRücksendungOrt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInstitutstyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBLZdervorgeschaltetenStelle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAvisierungvonZahlungenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colÜberweisungsnachfragenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colÜberweisungsrückfragenEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colScheckanfrageEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colLastschriftrückrufEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colWechselrückrufeEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUnbezahlteWechselEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleTEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleFAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colVorgeschalteteStelleEMAIL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMeldeweg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUSER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colUNTERBEARBEITUNGVON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RiskControllingDataSet As PS_TOOL_DX.RiskControllingDataSet
    Friend WithEvents MAK_CR_TOTALSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAK_CR_TOTALSTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.MAK_CR_TOTALSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents StressTestsLiveTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsLiveTableAdapter
    Friend WithEvents StressTestsLiveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StressTestsLiveDetailsTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsLiveDetailsTableAdapter
    Friend WithEvents StressTestsLiveDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadBusinessTypes_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BusinessTypeDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents StressTestsTempTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.StressTestsTempTableAdapter
    Friend WithEvents StressTestsTempBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents BT_ST_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SQL_Commands_Dropdownbutton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Print_Export_BT_ST_Totals_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents StressTestsBusinessTyperReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BT_ST_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BT_ST_Totals_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
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
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BT_ST_GEN_PARAM_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_BT_ST_Temp_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_INTERBANKV_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BT_ST_Temp_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LayoutView4 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn51 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn52 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField49 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn53 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBankleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn54 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBIC As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn55 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBezeichnungdesZahlungsdienstleisters As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn56 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField50 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn57 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField51 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn58 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField52 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn59 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField53 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn60 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladresseFirma As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn61 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladresseOrt As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn62 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladressePostfach As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn63 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colZustelladressePostleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn64 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungFirma As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn65 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungPostfach As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn66 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungStraße As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn67 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungPostleitzahl As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn68 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colRücksendungOrt As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn69 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colInstitutstyp As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn70 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colBLZdervorgeschaltetenStelle As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn71 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn72 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn73 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAvisierungvonZahlungenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn74 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField54 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn75 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField55 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn76 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colÜberweisungsnachfragenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn77 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField56 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn78 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField57 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn79 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField58 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn80 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField59 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn81 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colÜberweisungsrückfragenEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn82 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn83 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn84 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colScheckanfrageEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn85 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField60 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn86 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField61 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn87 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField62 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn88 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField63 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn89 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField64 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn90 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colLastschriftrückrufEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn91 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn92 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn93 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colWechselrückrufeEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn94 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn95 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn96 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUnbezahlteWechselEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn97 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleTEL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn98 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleFAX As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn99 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colVorgeschalteteStelleEMAIL As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn100 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMeldeweg As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn101 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField65 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn102 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUSER As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn103 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colUNTERBEARBEITUNGVON As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard2 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutView3 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutView2 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn26 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn27 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn28 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn29 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn30 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn31 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn32 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn33 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn34 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn35 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField10 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn36 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField11 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn37 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField12 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn38 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField13 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn39 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField14 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn40 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField15 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn41 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField16 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn42 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField17 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn43 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField18 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn44 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField19 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn45 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField20 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn46 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField21 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn47 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField22 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn48 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField23 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn49 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField24 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn50 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField25 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents SQL_Run_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_ReRun_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_ReRun_AllDays_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SQL_ReRun_Period_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinesType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPDunderStress1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountBusinessType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessTypeDefinition1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessTypeAmount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountryofRisk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountryofResidence As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInternalCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinessType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCUSTOMERTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreditExposure As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccruedInterest As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEuroEquivalent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStressPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStressNewAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPDAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBusinessTypeLive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinesType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPDunderStress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountBusinessType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessTypeDefinition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessTypeAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStressNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateMakCrTotals As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BgwSQL_Run As System.ComponentModel.BackgroundWorker
    Friend WithEvents BgwSQL_ReRun As System.ComponentModel.BackgroundWorker
    Friend WithEvents BgwSQL_ReRun_SpecificPeriod As System.ComponentModel.BackgroundWorker
    Friend WithEvents BgwSQL_ReRun_All_Days As System.ComponentModel.BackgroundWorker
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
