<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusinessTypesLiabilities
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusinessTypesLiabilities))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BT_CP_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinessTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractCollateralID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgPrincipalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgInterestAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchangeRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrincipalAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInterestAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalAmountEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBusinessTypeLiabilitiesLive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BusinessTypesLiabilitiesLiveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RiskControllingDataSet = New PS_TOOL_DX.RiskControllingDataSet()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BT_CP_Totals_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinesType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountBusinessTypePrincipalEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountBusinessTypeInterestEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountBusinessTypeTOTAL_EUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientsCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQLBusinessType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colDateMakCrTotals = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
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
        Me.BusinessTypesLiabilitiesLiveTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesLiveTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager()
        Me.BusinessTypesLiabilitiesDetailsAllTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesDetailsAllTableAdapter()
        Me.BusinessTypesLiabilitiesDetailsTableAdapter = New PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesDetailsTableAdapter()
        Me.BusinessTypesLiabilitiesDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BusinessTypesLiabilitiesAllDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.BT_CP_DetailsAll_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinessTypeName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractCollateralID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStartDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgPrincipalAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgInterestAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgTotalAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchangeRate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrincipalAmountEUR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInterestAmountEUR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalAmountEUR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBusinessTypeLiabilitiesLive1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.LayoutView5 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn104 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField26 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn105 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField27 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn106 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField28 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn107 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField29 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn108 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField30 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn109 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField31 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn110 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField32 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn111 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField33 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn112 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField34 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn113 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField35 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn114 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField36 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn115 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField37 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn116 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField38 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn117 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField39 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn118 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField40 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn119 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField41 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn120 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField42 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn121 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField43 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn122 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField44 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn123 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField45 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn124 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField46 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn125 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField47 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn126 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField66 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn127 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField67 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn128 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField68 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn129 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField69 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn130 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField70 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn131 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField71 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn132 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField72 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn133 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField73 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn134 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField74 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn135 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField75 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn136 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField76 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn137 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField77 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn138 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField78 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn139 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField79 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn140 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField80 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn141 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField81 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn142 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField82 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn143 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField83 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn144 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField84 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn145 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField85 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn146 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField86 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn147 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField87 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn148 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField88 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn149 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField89 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn150 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField90 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn151 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField91 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn152 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField92 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn153 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField93 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn154 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField94 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn155 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField95 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn156 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField96 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.LayoutView6 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutView7 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewColumn157 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField97 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn158 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField98 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn159 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField99 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn160 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField100 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn161 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField101 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn162 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField102 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn163 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField103 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn164 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField104 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn165 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField105 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn166 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField106 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn167 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField107 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn168 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField108 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn169 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField109 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn170 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField110 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn171 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField111 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn172 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField112 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn173 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField113 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn174 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField114 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn175 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField115 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn176 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField116 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn177 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField117 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn178 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField118 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn179 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField119 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn180 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField120 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn181 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField121 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadBusinessTypes_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.BT_CP_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SQL_Commands_Dropdownbutton = New DevExpress.XtraEditors.DropDownButton()
        Me.Print_Export_BT_CP_Totals_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.BusinessTyperReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BT_CP_DetailsAll_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.DropDownButton1 = New DevExpress.XtraEditors.DropDownButton()
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.BusinessTypesLiabilitiesDetailsRep_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BT_CP_GEN_PARAM_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_BT_CP_Temp_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_INTERBANKV_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.BT_CP_Temp_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinesType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colAmountBusinessType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSQLBusinessTypeDetails1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
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
        Me.BusinessTypeDateEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.BT_CP_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessTypesLiabilitiesLiveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskControllingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_CP_Totals_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.BusinessTypesLiabilitiesDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessTypesLiabilitiesAllDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_CP_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField47, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutViewField77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField78, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField79, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField80, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField81, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField83, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField84, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField85, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField86, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField87, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField88, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField89, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField90, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField91, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField92, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField93, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField94, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField95, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField96, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField97, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField98, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField99, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField100, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField101, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField102, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField103, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField104, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField105, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField107, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField108, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField109, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField110, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField112, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField113, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField114, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField115, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField116, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField117, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField118, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField119, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField120, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewField121, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.BT_CP_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BT_CP_DetailsAll_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BT_CP_GEN_PARAM_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BT_CP_Temp_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.BusinessTypeDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BT_CP_Details_GridView
        '
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_CP_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_CP_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colBusinessTypeName, Me.colContractType1, Me.colProductType1, Me.GridColumn6, Me.colClientNo, Me.colContractCollateralID, Me.colStartDate, Me.colMaturityDate, Me.colOrgCcy, Me.colOrgPrincipalAmount, Me.colOrgInterestAmount, Me.colOrgTotalAmount, Me.colExchangeRate, Me.colPrincipalAmountEUR, Me.colInterestAmountEUR, Me.colTotalAmountEUR, Me.colRiskDate, Me.colIdBusinessTypeLiabilitiesLive})
        Me.BT_CP_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_CP_Details_GridView.GridControl = Me.GridControl1
        Me.BT_CP_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.Credit Ou" &
                    "tstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.NetCredit" &
                    " Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.NetCredit" &
                    "OutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.CreditRis" &
                    "kAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FK_BusinessTypesCreditPortfolioDetails_BusinessTypesCreditPortfolioLive.NetCredit" &
                    "RiskAmountEUREquER45", Nothing, "{0:n2}")})
        Me.BT_CP_Details_GridView.Name = "BT_CP_Details_GridView"
        Me.BT_CP_Details_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_Details_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_Details_GridView.OptionsBehavior.ReadOnly = True
        Me.BT_CP_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_CP_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.BT_CP_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_CP_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_CP_Details_GridView.OptionsSelection.MultiSelect = True
        Me.BT_CP_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_CP_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BT_CP_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_CP_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_CP_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_CP_Details_GridView.OptionsView.ShowFooter = True
        Me.BT_CP_Details_GridView.ViewCaption = "BUSINESS TYPE DETAILS"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colBusinessTypeName
        '
        Me.colBusinessTypeName.FieldName = "BusinessTypeName"
        Me.colBusinessTypeName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colBusinessTypeName.Name = "colBusinessTypeName"
        Me.colBusinessTypeName.OptionsColumn.AllowEdit = False
        Me.colBusinessTypeName.OptionsColumn.ReadOnly = True
        Me.colBusinessTypeName.Visible = True
        Me.colBusinessTypeName.VisibleIndex = 0
        Me.colBusinessTypeName.Width = 283
        '
        'colContractType1
        '
        Me.colContractType1.FieldName = "Contract Type"
        Me.colContractType1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colContractType1.Name = "colContractType1"
        Me.colContractType1.OptionsColumn.AllowEdit = False
        Me.colContractType1.OptionsColumn.ReadOnly = True
        Me.colContractType1.Visible = True
        Me.colContractType1.VisibleIndex = 1
        Me.colContractType1.Width = 369
        '
        'colProductType1
        '
        Me.colProductType1.FieldName = "Product Type"
        Me.colProductType1.Name = "colProductType1"
        Me.colProductType1.OptionsColumn.AllowEdit = False
        Me.colProductType1.OptionsColumn.ReadOnly = True
        Me.colProductType1.Visible = True
        Me.colProductType1.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 347
        '
        'colClientNo
        '
        Me.colClientNo.AppearanceCell.Options.UseTextOptions = True
        Me.colClientNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientNo.FieldName = "Client No"
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.VisibleIndex = 4
        Me.colClientNo.Width = 236
        '
        'colContractCollateralID
        '
        Me.colContractCollateralID.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID.Name = "colContractCollateralID"
        Me.colContractCollateralID.OptionsColumn.AllowEdit = False
        Me.colContractCollateralID.OptionsColumn.ReadOnly = True
        Me.colContractCollateralID.Visible = True
        Me.colContractCollateralID.VisibleIndex = 5
        Me.colContractCollateralID.Width = 152
        '
        'colStartDate
        '
        Me.colStartDate.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStartDate.Caption = "Start/Open Date"
        Me.colStartDate.FieldName = "StartDate"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.OptionsColumn.AllowEdit = False
        Me.colStartDate.OptionsColumn.ReadOnly = True
        Me.colStartDate.Visible = True
        Me.colStartDate.VisibleIndex = 6
        Me.colStartDate.Width = 88
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
        Me.colMaturityDate.VisibleIndex = 7
        Me.colMaturityDate.Width = 91
        '
        'colOrgCcy
        '
        Me.colOrgCcy.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrgCcy.FieldName = "OrgCcy"
        Me.colOrgCcy.Name = "colOrgCcy"
        Me.colOrgCcy.OptionsColumn.AllowEdit = False
        Me.colOrgCcy.OptionsColumn.ReadOnly = True
        Me.colOrgCcy.Visible = True
        Me.colOrgCcy.VisibleIndex = 8
        Me.colOrgCcy.Width = 62
        '
        'colOrgPrincipalAmount
        '
        Me.colOrgPrincipalAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgPrincipalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgPrincipalAmount.Caption = "Orig. Principal Amount"
        Me.colOrgPrincipalAmount.DisplayFormat.FormatString = "n2"
        Me.colOrgPrincipalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgPrincipalAmount.FieldName = "OrgPrincipalAmount"
        Me.colOrgPrincipalAmount.Name = "colOrgPrincipalAmount"
        Me.colOrgPrincipalAmount.OptionsColumn.AllowEdit = False
        Me.colOrgPrincipalAmount.OptionsColumn.ReadOnly = True
        Me.colOrgPrincipalAmount.Visible = True
        Me.colOrgPrincipalAmount.VisibleIndex = 9
        Me.colOrgPrincipalAmount.Width = 146
        '
        'colOrgInterestAmount
        '
        Me.colOrgInterestAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgInterestAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgInterestAmount.Caption = "Orig. Interest Amount"
        Me.colOrgInterestAmount.DisplayFormat.FormatString = "n2"
        Me.colOrgInterestAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgInterestAmount.FieldName = "OrgInterestAmount"
        Me.colOrgInterestAmount.Name = "colOrgInterestAmount"
        Me.colOrgInterestAmount.OptionsColumn.AllowEdit = False
        Me.colOrgInterestAmount.OptionsColumn.ReadOnly = True
        Me.colOrgInterestAmount.Visible = True
        Me.colOrgInterestAmount.VisibleIndex = 10
        Me.colOrgInterestAmount.Width = 144
        '
        'colOrgTotalAmount
        '
        Me.colOrgTotalAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgTotalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgTotalAmount.Caption = "Orig. Total Amount"
        Me.colOrgTotalAmount.DisplayFormat.FormatString = "n2"
        Me.colOrgTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgTotalAmount.FieldName = "OrgTotalAmount"
        Me.colOrgTotalAmount.Name = "colOrgTotalAmount"
        Me.colOrgTotalAmount.OptionsColumn.AllowEdit = False
        Me.colOrgTotalAmount.OptionsColumn.ReadOnly = True
        Me.colOrgTotalAmount.Visible = True
        Me.colOrgTotalAmount.VisibleIndex = 11
        Me.colOrgTotalAmount.Width = 136
        '
        'colExchangeRate
        '
        Me.colExchangeRate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchangeRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchangeRate.DisplayFormat.FormatString = "n5"
        Me.colExchangeRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchangeRate.FieldName = "ExchangeRate"
        Me.colExchangeRate.Name = "colExchangeRate"
        Me.colExchangeRate.OptionsColumn.AllowEdit = False
        Me.colExchangeRate.OptionsColumn.ReadOnly = True
        Me.colExchangeRate.Visible = True
        Me.colExchangeRate.VisibleIndex = 12
        Me.colExchangeRate.Width = 97
        '
        'colPrincipalAmountEUR
        '
        Me.colPrincipalAmountEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colPrincipalAmountEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPrincipalAmountEUR.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colPrincipalAmountEUR.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipalAmountEUR.DisplayFormat.FormatString = "n2"
        Me.colPrincipalAmountEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipalAmountEUR.FieldName = "PrincipalAmountEUR"
        Me.colPrincipalAmountEUR.Name = "colPrincipalAmountEUR"
        Me.colPrincipalAmountEUR.OptionsColumn.AllowEdit = False
        Me.colPrincipalAmountEUR.OptionsColumn.ReadOnly = True
        Me.colPrincipalAmountEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrincipalAmountEUR", "Sum={0:n2}")})
        Me.colPrincipalAmountEUR.Visible = True
        Me.colPrincipalAmountEUR.VisibleIndex = 13
        Me.colPrincipalAmountEUR.Width = 170
        '
        'colInterestAmountEUR
        '
        Me.colInterestAmountEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestAmountEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colInterestAmountEUR.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colInterestAmountEUR.AppearanceHeader.Options.UseForeColor = True
        Me.colInterestAmountEUR.DisplayFormat.FormatString = "n2"
        Me.colInterestAmountEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestAmountEUR.FieldName = "InterestAmountEUR"
        Me.colInterestAmountEUR.Name = "colInterestAmountEUR"
        Me.colInterestAmountEUR.OptionsColumn.AllowEdit = False
        Me.colInterestAmountEUR.OptionsColumn.ReadOnly = True
        Me.colInterestAmountEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InterestAmountEUR", "Sum={0:n2}")})
        Me.colInterestAmountEUR.Visible = True
        Me.colInterestAmountEUR.VisibleIndex = 14
        Me.colInterestAmountEUR.Width = 155
        '
        'colTotalAmountEUR
        '
        Me.colTotalAmountEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colTotalAmountEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colTotalAmountEUR.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colTotalAmountEUR.AppearanceHeader.Options.UseForeColor = True
        Me.colTotalAmountEUR.DisplayFormat.FormatString = "n2"
        Me.colTotalAmountEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTotalAmountEUR.FieldName = "TotalAmountEUR"
        Me.colTotalAmountEUR.Name = "colTotalAmountEUR"
        Me.colTotalAmountEUR.OptionsColumn.AllowEdit = False
        Me.colTotalAmountEUR.OptionsColumn.ReadOnly = True
        Me.colTotalAmountEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmountEUR", "Sum={0:n2}")})
        Me.colTotalAmountEUR.Visible = True
        Me.colTotalAmountEUR.VisibleIndex = 15
        Me.colTotalAmountEUR.Width = 143
        '
        'colRiskDate
        '
        Me.colRiskDate.FieldName = "RiskDate"
        Me.colRiskDate.Name = "colRiskDate"
        Me.colRiskDate.OptionsColumn.AllowEdit = False
        Me.colRiskDate.OptionsColumn.ReadOnly = True
        '
        'colIdBusinessTypeLiabilitiesLive
        '
        Me.colIdBusinessTypeLiabilitiesLive.FieldName = "IdBusinessTypeLiabilitiesLive"
        Me.colIdBusinessTypeLiabilitiesLive.Name = "colIdBusinessTypeLiabilitiesLive"
        Me.colIdBusinessTypeLiabilitiesLive.OptionsColumn.AllowEdit = False
        Me.colIdBusinessTypeLiabilitiesLive.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.BusinessTypesLiabilitiesLiveBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 4
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 7
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.ImageIndex = 5
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.BT_CP_Details_GridView
        GridLevelNode1.RelationName = "FK_BusinessTypesLiabilitiesDetails_BusinessTypesLiabilitiesLive"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.BT_CP_Totals_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2})
        Me.GridControl1.ShowOnlyPredefinedDetails = True
        Me.GridControl1.Size = New System.Drawing.Size(1275, 571)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BT_CP_Totals_GridView, Me.LayoutView1, Me.BT_CP_Details_GridView})
        '
        'BusinessTypesLiabilitiesLiveBindingSource
        '
        Me.BusinessTypesLiabilitiesLiveBindingSource.DataMember = "BusinessTypesLiabilitiesLive"
        Me.BusinessTypesLiabilitiesLiveBindingSource.DataSource = Me.RiskControllingDataSet
        '
        'RiskControllingDataSet
        '
        Me.RiskControllingDataSet.DataSetName = "RiskControllingDataSet"
        Me.RiskControllingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "SQL Runner.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "CrystalReport.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "save_16x16.png")
        '
        'BT_CP_Totals_GridView
        '
        Me.BT_CP_Totals_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_Totals_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_CP_Totals_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_Totals_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_CP_Totals_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_CP_Totals_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.BT_CP_Totals_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.BT_CP_Totals_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colBusinesType, Me.colAmountBusinessTypePrincipalEUR, Me.colAmountBusinessTypeInterestEUR, Me.colAmountBusinessTypeTOTAL_EUR, Me.colClientsCount, Me.colSQLBusinessType, Me.colDateMakCrTotals})
        Me.BT_CP_Totals_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_CP_Totals_GridView.GridControl = Me.GridControl1
        Me.BT_CP_Totals_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessType", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountER1", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountER2", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClientsCount", Me.colClientsCount, "{0:n0}")})
        Me.BT_CP_Totals_GridView.Name = "BT_CP_Totals_GridView"
        Me.BT_CP_Totals_GridView.NewItemRowText = "Add new Business Type"
        Me.BT_CP_Totals_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Totals_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Totals_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_CP_Totals_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.BT_CP_Totals_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_CP_Totals_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_CP_Totals_GridView.OptionsPrint.PrintDetails = True
        Me.BT_CP_Totals_GridView.OptionsSelection.MultiSelect = True
        Me.BT_CP_Totals_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_CP_Totals_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Totals_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BT_CP_Totals_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_CP_Totals_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_CP_Totals_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_CP_Totals_GridView.OptionsView.ShowFooter = True
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
        Me.colBusinesType.FieldName = "BusinesType"
        Me.colBusinesType.Name = "colBusinesType"
        Me.colBusinesType.OptionsColumn.AllowEdit = False
        Me.colBusinesType.OptionsColumn.ReadOnly = True
        Me.colBusinesType.Visible = True
        Me.colBusinesType.VisibleIndex = 0
        Me.colBusinesType.Width = 686
        '
        'colAmountBusinessTypePrincipalEUR
        '
        Me.colAmountBusinessTypePrincipalEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountBusinessTypePrincipalEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountBusinessTypePrincipalEUR.Caption = "Principal Amount (EUR)"
        Me.colAmountBusinessTypePrincipalEUR.DisplayFormat.FormatString = "n2"
        Me.colAmountBusinessTypePrincipalEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountBusinessTypePrincipalEUR.FieldName = "AmountBusinessTypePrincipalEUR"
        Me.colAmountBusinessTypePrincipalEUR.Name = "colAmountBusinessTypePrincipalEUR"
        Me.colAmountBusinessTypePrincipalEUR.OptionsColumn.AllowEdit = False
        Me.colAmountBusinessTypePrincipalEUR.OptionsColumn.ReadOnly = True
        Me.colAmountBusinessTypePrincipalEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessTypePrincipalEUR", "SUM={0:n2}")})
        Me.colAmountBusinessTypePrincipalEUR.Visible = True
        Me.colAmountBusinessTypePrincipalEUR.VisibleIndex = 1
        Me.colAmountBusinessTypePrincipalEUR.Width = 208
        '
        'colAmountBusinessTypeInterestEUR
        '
        Me.colAmountBusinessTypeInterestEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountBusinessTypeInterestEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountBusinessTypeInterestEUR.Caption = "Interest Amount (EUR)"
        Me.colAmountBusinessTypeInterestEUR.DisplayFormat.FormatString = "n2"
        Me.colAmountBusinessTypeInterestEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountBusinessTypeInterestEUR.FieldName = "AmountBusinessTypeInterestEUR"
        Me.colAmountBusinessTypeInterestEUR.Name = "colAmountBusinessTypeInterestEUR"
        Me.colAmountBusinessTypeInterestEUR.OptionsColumn.AllowEdit = False
        Me.colAmountBusinessTypeInterestEUR.OptionsColumn.ReadOnly = True
        Me.colAmountBusinessTypeInterestEUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessTypeInterestEUR", "SUM={0:n2}")})
        Me.colAmountBusinessTypeInterestEUR.Visible = True
        Me.colAmountBusinessTypeInterestEUR.VisibleIndex = 2
        Me.colAmountBusinessTypeInterestEUR.Width = 192
        '
        'colAmountBusinessTypeTOTAL_EUR
        '
        Me.colAmountBusinessTypeTOTAL_EUR.AppearanceCell.Options.UseTextOptions = True
        Me.colAmountBusinessTypeTOTAL_EUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmountBusinessTypeTOTAL_EUR.Caption = "TOTAL AMOUNT (EUR)"
        Me.colAmountBusinessTypeTOTAL_EUR.DisplayFormat.FormatString = "n2"
        Me.colAmountBusinessTypeTOTAL_EUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountBusinessTypeTOTAL_EUR.FieldName = "AmountBusinessTypeTOTAL_EUR"
        Me.colAmountBusinessTypeTOTAL_EUR.Name = "colAmountBusinessTypeTOTAL_EUR"
        Me.colAmountBusinessTypeTOTAL_EUR.OptionsColumn.AllowEdit = False
        Me.colAmountBusinessTypeTOTAL_EUR.OptionsColumn.ReadOnly = True
        Me.colAmountBusinessTypeTOTAL_EUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountBusinessTypeTOTAL_EUR", "SUM={0:n2}")})
        Me.colAmountBusinessTypeTOTAL_EUR.Visible = True
        Me.colAmountBusinessTypeTOTAL_EUR.VisibleIndex = 3
        Me.colAmountBusinessTypeTOTAL_EUR.Width = 196
        '
        'colClientsCount
        '
        Me.colClientsCount.AppearanceCell.Options.UseTextOptions = True
        Me.colClientsCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientsCount.DisplayFormat.FormatString = "n0"
        Me.colClientsCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colClientsCount.FieldName = "ClientsCount"
        Me.colClientsCount.Name = "colClientsCount"
        Me.colClientsCount.OptionsColumn.AllowEdit = False
        Me.colClientsCount.OptionsColumn.ReadOnly = True
        Me.colClientsCount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ClientsCount", "SUM={0:n0}")})
        Me.colClientsCount.Visible = True
        Me.colClientsCount.VisibleIndex = 4
        Me.colClientsCount.Width = 112
        '
        'colSQLBusinessType
        '
        Me.colSQLBusinessType.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSQLBusinessType.FieldName = "SQLBusinessType"
        Me.colSQLBusinessType.Name = "colSQLBusinessType"
        Me.colSQLBusinessType.OptionsColumn.ReadOnly = True
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
        Me.LayoutView1.TemplateCard = Nothing
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
        'BusinessTypesLiabilitiesLiveTableAdapter
        '
        Me.BusinessTypesLiabilitiesLiveTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioDetailsAllTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioDetailsTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesCreditPortfolioLiveTableAdapter = Nothing
        Me.TableAdapterManager.BusinessTypesLiabilitiesDetailsAllTableAdapter = Me.BusinessTypesLiabilitiesDetailsAllTableAdapter
        Me.TableAdapterManager.BusinessTypesLiabilitiesDetailsTableAdapter = Me.BusinessTypesLiabilitiesDetailsTableAdapter
        Me.TableAdapterManager.BusinessTypesLiabilitiesLiveTableAdapter = Me.BusinessTypesLiabilitiesLiveTableAdapter
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.COUNTRIESTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_CR_TOTALSTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DATETableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DELETIONSTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_DETAILSTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_TOTALSTableAdapter = Nothing
        Me.TableAdapterManager.RISK_LIMIT_DAILY_CONTROLTableAdapter = Nothing
        Me.TableAdapterManager.StressTestLiquid_TempTableAdapter = Nothing
        Me.TableAdapterManager.StressTestsLiquidHOTableAdapter = Nothing
        Me.TableAdapterManager.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DATETableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DetailsALLTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSS_DetailsTableAdapter = Nothing
        Me.TableAdapterManager.UNEXPECTED_LOSSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'BusinessTypesLiabilitiesDetailsAllTableAdapter
        '
        Me.BusinessTypesLiabilitiesDetailsAllTableAdapter.ClearBeforeFill = True
        '
        'BusinessTypesLiabilitiesDetailsTableAdapter
        '
        Me.BusinessTypesLiabilitiesDetailsTableAdapter.ClearBeforeFill = True
        '
        'BusinessTypesLiabilitiesDetailsBindingSource
        '
        Me.BusinessTypesLiabilitiesDetailsBindingSource.DataMember = "FK_BusinessTypesLiabilitiesDetails_BusinessTypesLiabilitiesLive"
        Me.BusinessTypesLiabilitiesDetailsBindingSource.DataSource = Me.BusinessTypesLiabilitiesLiveBindingSource
        '
        'BusinessTypesLiabilitiesAllDetailsBindingSource
        '
        Me.BusinessTypesLiabilitiesAllDetailsBindingSource.DataMember = "BusinessTypesLiabilitiesAllDetails"
        Me.BusinessTypesLiabilitiesAllDetailsBindingSource.DataSource = Me.RiskControllingDataSet
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl3
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.BusinessTypesLiabilitiesAllDetailsBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(24, 50)
        Me.GridControl3.MainView = Me.BT_CP_DetailsAll_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox3, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3})
        Me.GridControl3.Size = New System.Drawing.Size(1251, 571)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BT_CP_DetailsAll_Gridview, Me.LayoutView5, Me.LayoutView6, Me.LayoutView7})
        '
        'BT_CP_DetailsAll_Gridview
        '
        Me.BT_CP_DetailsAll_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_DetailsAll_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_CP_DetailsAll_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_CP_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_CP_DetailsAll_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.BT_CP_DetailsAll_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.BT_CP_DetailsAll_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID3, Me.colBusinessTypeName1, Me.colContractType, Me.colProductType, Me.GridColumn1, Me.colClientNo1, Me.colContractCollateralID1, Me.colStartDate1, Me.colMaturityDate1, Me.colOrgCcy1, Me.colOrgPrincipalAmount1, Me.colOrgInterestAmount1, Me.colOrgTotalAmount1, Me.colExchangeRate1, Me.colPrincipalAmountEUR1, Me.colInterestAmountEUR1, Me.colTotalAmountEUR1, Me.colRiskDate1, Me.colIdBusinessTypeLiabilitiesLive1})
        Me.BT_CP_DetailsAll_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_CP_DetailsAll_Gridview.GridControl = Me.GridControl3
        Me.BT_CP_DetailsAll_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "BusinessTypeName", Me.colBusinessTypeName1, "Count={0:n0}")})
        Me.BT_CP_DetailsAll_Gridview.Name = "BT_CP_DetailsAll_Gridview"
        Me.BT_CP_DetailsAll_Gridview.NewItemRowText = "Add new Business Type"
        Me.BT_CP_DetailsAll_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_DetailsAll_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_DetailsAll_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.BT_CP_DetailsAll_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.BT_CP_DetailsAll_Gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.BT_CP_DetailsAll_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.BT_CP_DetailsAll_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_CP_DetailsAll_Gridview.OptionsFind.AlwaysVisible = True
        Me.BT_CP_DetailsAll_Gridview.OptionsMenu.ShowFooterItem = True
        Me.BT_CP_DetailsAll_Gridview.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.BT_CP_DetailsAll_Gridview.OptionsSelection.MultiSelect = True
        Me.BT_CP_DetailsAll_Gridview.OptionsView.ColumnAutoWidth = False
        Me.BT_CP_DetailsAll_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_DetailsAll_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_CP_DetailsAll_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.BT_CP_DetailsAll_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_CP_DetailsAll_Gridview.OptionsView.ShowFooter = True
        '
        'colID3
        '
        Me.colID3.FieldName = "ID"
        Me.colID3.Name = "colID3"
        Me.colID3.OptionsColumn.AllowEdit = False
        Me.colID3.OptionsColumn.ReadOnly = True
        '
        'colBusinessTypeName1
        '
        Me.colBusinessTypeName1.FieldName = "BusinessTypeName"
        Me.colBusinessTypeName1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colBusinessTypeName1.Name = "colBusinessTypeName1"
        Me.colBusinessTypeName1.OptionsColumn.AllowEdit = False
        Me.colBusinessTypeName1.OptionsColumn.ReadOnly = True
        Me.colBusinessTypeName1.Visible = True
        Me.colBusinessTypeName1.VisibleIndex = 0
        Me.colBusinessTypeName1.Width = 306
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 1
        Me.colContractType.Width = 332
        '
        'colProductType
        '
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.OptionsColumn.AllowEdit = False
        Me.colProductType.OptionsColumn.ReadOnly = True
        Me.colProductType.Visible = True
        Me.colProductType.VisibleIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 296
        '
        'colClientNo1
        '
        Me.colClientNo1.AppearanceCell.Options.UseTextOptions = True
        Me.colClientNo1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientNo1.FieldName = "Client No"
        Me.colClientNo1.Name = "colClientNo1"
        Me.colClientNo1.OptionsColumn.AllowEdit = False
        Me.colClientNo1.OptionsColumn.ReadOnly = True
        Me.colClientNo1.Visible = True
        Me.colClientNo1.VisibleIndex = 4
        Me.colClientNo1.Width = 208
        '
        'colContractCollateralID1
        '
        Me.colContractCollateralID1.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID1.Name = "colContractCollateralID1"
        Me.colContractCollateralID1.OptionsColumn.AllowEdit = False
        Me.colContractCollateralID1.OptionsColumn.ReadOnly = True
        Me.colContractCollateralID1.Visible = True
        Me.colContractCollateralID1.VisibleIndex = 5
        Me.colContractCollateralID1.Width = 121
        '
        'colStartDate1
        '
        Me.colStartDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colStartDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStartDate1.Caption = "Start/Open Date"
        Me.colStartDate1.FieldName = "StartDate"
        Me.colStartDate1.Name = "colStartDate1"
        Me.colStartDate1.OptionsColumn.AllowEdit = False
        Me.colStartDate1.OptionsColumn.ReadOnly = True
        Me.colStartDate1.Visible = True
        Me.colStartDate1.VisibleIndex = 6
        Me.colStartDate1.Width = 86
        '
        'colMaturityDate1
        '
        Me.colMaturityDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colMaturityDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMaturityDate1.FieldName = "Maturity Date"
        Me.colMaturityDate1.Name = "colMaturityDate1"
        Me.colMaturityDate1.OptionsColumn.AllowEdit = False
        Me.colMaturityDate1.OptionsColumn.ReadOnly = True
        Me.colMaturityDate1.Visible = True
        Me.colMaturityDate1.VisibleIndex = 7
        Me.colMaturityDate1.Width = 105
        '
        'colOrgCcy1
        '
        Me.colOrgCcy1.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgCcy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOrgCcy1.FieldName = "OrgCcy"
        Me.colOrgCcy1.Name = "colOrgCcy1"
        Me.colOrgCcy1.OptionsColumn.AllowEdit = False
        Me.colOrgCcy1.OptionsColumn.ReadOnly = True
        Me.colOrgCcy1.Visible = True
        Me.colOrgCcy1.VisibleIndex = 8
        '
        'colOrgPrincipalAmount1
        '
        Me.colOrgPrincipalAmount1.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgPrincipalAmount1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgPrincipalAmount1.Caption = "Orig. Principal Amount"
        Me.colOrgPrincipalAmount1.DisplayFormat.FormatString = "n2"
        Me.colOrgPrincipalAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgPrincipalAmount1.FieldName = "OrgPrincipalAmount"
        Me.colOrgPrincipalAmount1.Name = "colOrgPrincipalAmount1"
        Me.colOrgPrincipalAmount1.OptionsColumn.AllowEdit = False
        Me.colOrgPrincipalAmount1.OptionsColumn.ReadOnly = True
        Me.colOrgPrincipalAmount1.Visible = True
        Me.colOrgPrincipalAmount1.VisibleIndex = 9
        Me.colOrgPrincipalAmount1.Width = 117
        '
        'colOrgInterestAmount1
        '
        Me.colOrgInterestAmount1.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgInterestAmount1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgInterestAmount1.Caption = "Orig. Interest Amount"
        Me.colOrgInterestAmount1.DisplayFormat.FormatString = "n2"
        Me.colOrgInterestAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgInterestAmount1.FieldName = "OrgInterestAmount"
        Me.colOrgInterestAmount1.Name = "colOrgInterestAmount1"
        Me.colOrgInterestAmount1.OptionsColumn.AllowEdit = False
        Me.colOrgInterestAmount1.OptionsColumn.ReadOnly = True
        Me.colOrgInterestAmount1.Visible = True
        Me.colOrgInterestAmount1.VisibleIndex = 10
        Me.colOrgInterestAmount1.Width = 115
        '
        'colOrgTotalAmount1
        '
        Me.colOrgTotalAmount1.AppearanceCell.Options.UseTextOptions = True
        Me.colOrgTotalAmount1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colOrgTotalAmount1.Caption = "Orig. Total Amount"
        Me.colOrgTotalAmount1.DisplayFormat.FormatString = "n2"
        Me.colOrgTotalAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgTotalAmount1.FieldName = "OrgTotalAmount"
        Me.colOrgTotalAmount1.Name = "colOrgTotalAmount1"
        Me.colOrgTotalAmount1.OptionsColumn.AllowEdit = False
        Me.colOrgTotalAmount1.OptionsColumn.ReadOnly = True
        Me.colOrgTotalAmount1.Visible = True
        Me.colOrgTotalAmount1.VisibleIndex = 11
        Me.colOrgTotalAmount1.Width = 103
        '
        'colExchangeRate1
        '
        Me.colExchangeRate1.AppearanceCell.Options.UseTextOptions = True
        Me.colExchangeRate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchangeRate1.DisplayFormat.FormatString = "n5"
        Me.colExchangeRate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchangeRate1.FieldName = "ExchangeRate"
        Me.colExchangeRate1.Name = "colExchangeRate1"
        Me.colExchangeRate1.OptionsColumn.AllowEdit = False
        Me.colExchangeRate1.OptionsColumn.ReadOnly = True
        Me.colExchangeRate1.Visible = True
        Me.colExchangeRate1.VisibleIndex = 12
        '
        'colPrincipalAmountEUR1
        '
        Me.colPrincipalAmountEUR1.AppearanceCell.Options.UseTextOptions = True
        Me.colPrincipalAmountEUR1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPrincipalAmountEUR1.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colPrincipalAmountEUR1.AppearanceHeader.Options.UseForeColor = True
        Me.colPrincipalAmountEUR1.DisplayFormat.FormatString = "n2"
        Me.colPrincipalAmountEUR1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrincipalAmountEUR1.FieldName = "PrincipalAmountEUR"
        Me.colPrincipalAmountEUR1.Name = "colPrincipalAmountEUR1"
        Me.colPrincipalAmountEUR1.OptionsColumn.AllowEdit = False
        Me.colPrincipalAmountEUR1.OptionsColumn.ReadOnly = True
        Me.colPrincipalAmountEUR1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrincipalAmountEUR", "SUM={0:n2}")})
        Me.colPrincipalAmountEUR1.Visible = True
        Me.colPrincipalAmountEUR1.VisibleIndex = 13
        Me.colPrincipalAmountEUR1.Width = 139
        '
        'colInterestAmountEUR1
        '
        Me.colInterestAmountEUR1.AppearanceCell.Options.UseTextOptions = True
        Me.colInterestAmountEUR1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colInterestAmountEUR1.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colInterestAmountEUR1.AppearanceHeader.Options.UseForeColor = True
        Me.colInterestAmountEUR1.DisplayFormat.FormatString = "n2"
        Me.colInterestAmountEUR1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInterestAmountEUR1.FieldName = "InterestAmountEUR"
        Me.colInterestAmountEUR1.Name = "colInterestAmountEUR1"
        Me.colInterestAmountEUR1.OptionsColumn.AllowEdit = False
        Me.colInterestAmountEUR1.OptionsColumn.ReadOnly = True
        Me.colInterestAmountEUR1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InterestAmountEUR", "SUM={0:n2}")})
        Me.colInterestAmountEUR1.Visible = True
        Me.colInterestAmountEUR1.VisibleIndex = 14
        Me.colInterestAmountEUR1.Width = 125
        '
        'colTotalAmountEUR1
        '
        Me.colTotalAmountEUR1.AppearanceCell.Options.UseTextOptions = True
        Me.colTotalAmountEUR1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colTotalAmountEUR1.AppearanceHeader.ForeColor = System.Drawing.Color.Aqua
        Me.colTotalAmountEUR1.AppearanceHeader.Options.UseForeColor = True
        Me.colTotalAmountEUR1.DisplayFormat.FormatString = "n2"
        Me.colTotalAmountEUR1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colTotalAmountEUR1.FieldName = "TotalAmountEUR"
        Me.colTotalAmountEUR1.Name = "colTotalAmountEUR1"
        Me.colTotalAmountEUR1.OptionsColumn.AllowEdit = False
        Me.colTotalAmountEUR1.OptionsColumn.ReadOnly = True
        Me.colTotalAmountEUR1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmountEUR", "SUM={0:n2}")})
        Me.colTotalAmountEUR1.Visible = True
        Me.colTotalAmountEUR1.VisibleIndex = 15
        Me.colTotalAmountEUR1.Width = 136
        '
        'colRiskDate1
        '
        Me.colRiskDate1.FieldName = "RiskDate"
        Me.colRiskDate1.Name = "colRiskDate1"
        Me.colRiskDate1.OptionsColumn.AllowEdit = False
        Me.colRiskDate1.OptionsColumn.ReadOnly = True
        '
        'colIdBusinessTypeLiabilitiesLive1
        '
        Me.colIdBusinessTypeLiabilitiesLive1.FieldName = "IdBusinessTypeLiabilitiesLive"
        Me.colIdBusinessTypeLiabilitiesLive1.Name = "colIdBusinessTypeLiabilitiesLive1"
        Me.colIdBusinessTypeLiabilitiesLive1.OptionsColumn.AllowEdit = False
        Me.colIdBusinessTypeLiabilitiesLive1.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemComboBox3
        '
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox3.AutoHeight = False
        Me.RepositoryItemComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox3.DropDownRows = 2
        Me.RepositoryItemComboBox3.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.RepositoryItemComboBox3.ImmediatePopup = True
        Me.RepositoryItemComboBox3.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        Me.RepositoryItemComboBox3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.RepositoryItemMemoExEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemMemoExEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AutoHeight = False
        Me.RepositoryItemMemoExEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit3.Name = "RepositoryItemMemoExEdit3"
        Me.RepositoryItemMemoExEdit3.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.RepositoryItemMemoExEdit3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'LayoutView5
        '
        Me.LayoutView5.CardMinSize = New System.Drawing.Size(567, 651)
        Me.LayoutView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn104, Me.LayoutViewColumn105, Me.LayoutViewColumn106, Me.LayoutViewColumn107, Me.LayoutViewColumn108, Me.LayoutViewColumn109, Me.LayoutViewColumn110, Me.LayoutViewColumn111, Me.LayoutViewColumn112, Me.LayoutViewColumn113, Me.LayoutViewColumn114, Me.LayoutViewColumn115, Me.LayoutViewColumn116, Me.LayoutViewColumn117, Me.LayoutViewColumn118, Me.LayoutViewColumn119, Me.LayoutViewColumn120, Me.LayoutViewColumn121, Me.LayoutViewColumn122, Me.LayoutViewColumn123, Me.LayoutViewColumn124, Me.LayoutViewColumn125, Me.LayoutViewColumn126, Me.LayoutViewColumn127, Me.LayoutViewColumn128, Me.LayoutViewColumn129, Me.LayoutViewColumn130, Me.LayoutViewColumn131, Me.LayoutViewColumn132, Me.LayoutViewColumn133, Me.LayoutViewColumn134, Me.LayoutViewColumn135, Me.LayoutViewColumn136, Me.LayoutViewColumn137, Me.LayoutViewColumn138, Me.LayoutViewColumn139, Me.LayoutViewColumn140, Me.LayoutViewColumn141, Me.LayoutViewColumn142, Me.LayoutViewColumn143, Me.LayoutViewColumn144, Me.LayoutViewColumn145, Me.LayoutViewColumn146, Me.LayoutViewColumn147, Me.LayoutViewColumn148, Me.LayoutViewColumn149, Me.LayoutViewColumn150, Me.LayoutViewColumn151, Me.LayoutViewColumn152, Me.LayoutViewColumn153, Me.LayoutViewColumn154, Me.LayoutViewColumn155, Me.LayoutViewColumn156})
        Me.LayoutView5.GridControl = Me.GridControl3
        Me.LayoutView5.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField96, Me.LayoutViewField95})
        Me.LayoutView5.Name = "LayoutView5"
        Me.LayoutView5.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView5.OptionsFilter.AllowFilterEditor = False
        Me.LayoutView5.OptionsFilter.AllowMRUFilterList = False
        Me.LayoutView5.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowPanButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView5.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView5.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView5.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView5.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewColumn104
        '
        Me.LayoutViewColumn104.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn104.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn104.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn104.FieldName = "ID"
        Me.LayoutViewColumn104.LayoutViewField = Me.LayoutViewField26
        Me.LayoutViewColumn104.Name = "LayoutViewColumn104"
        Me.LayoutViewColumn104.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn104.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn104.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField26
        '
        Me.LayoutViewField26.EditorPreferredWidth = 113
        Me.LayoutViewField26.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField26.Name = "LayoutViewField26"
        Me.LayoutViewField26.Size = New System.Drawing.Size(137, 20)
        Me.LayoutViewField26.TextSize = New System.Drawing.Size(15, 13)
        '
        'LayoutViewColumn105
        '
        Me.LayoutViewColumn105.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn105.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn105.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn105.FieldName = "Datensatz-nummer"
        Me.LayoutViewColumn105.LayoutViewField = Me.LayoutViewField27
        Me.LayoutViewColumn105.Name = "LayoutViewColumn105"
        Me.LayoutViewColumn105.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn105.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn105.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField27
        '
        Me.LayoutViewField27.EditorPreferredWidth = 85
        Me.LayoutViewField27.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField27.Name = "LayoutViewField27"
        Me.LayoutViewField27.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField27.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn106
        '
        Me.LayoutViewColumn106.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn106.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn106.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn106.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn106.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn106.FieldName = "Bankleitzahl"
        Me.LayoutViewColumn106.LayoutViewField = Me.LayoutViewField28
        Me.LayoutViewColumn106.Name = "LayoutViewColumn106"
        Me.LayoutViewColumn106.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn106.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn106.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField28
        '
        Me.LayoutViewField28.EditorPreferredWidth = 85
        Me.LayoutViewField28.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField28.Name = "LayoutViewField28"
        Me.LayoutViewField28.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField28.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn107
        '
        Me.LayoutViewColumn107.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn107.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn107.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn107.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn107.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn107.FieldName = "BIC"
        Me.LayoutViewColumn107.LayoutViewField = Me.LayoutViewField29
        Me.LayoutViewColumn107.Name = "LayoutViewColumn107"
        Me.LayoutViewColumn107.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn107.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn107.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField29
        '
        Me.LayoutViewField29.EditorPreferredWidth = 85
        Me.LayoutViewField29.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField29.Name = "LayoutViewField29"
        Me.LayoutViewField29.Size = New System.Drawing.Size(287, 20)
        Me.LayoutViewField29.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn108
        '
        Me.LayoutViewColumn108.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn108.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn108.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn108.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn108.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn108.FieldName = "Bezeichnung des Zahlungsdienstleisters"
        Me.LayoutViewColumn108.LayoutViewField = Me.LayoutViewField30
        Me.LayoutViewColumn108.Name = "LayoutViewColumn108"
        Me.LayoutViewColumn108.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn108.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn108.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField30
        '
        Me.LayoutViewField30.EditorPreferredWidth = 321
        Me.LayoutViewField30.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField30.Name = "LayoutViewField30"
        Me.LayoutViewField30.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField30.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn109
        '
        Me.LayoutViewColumn109.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn109.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn109.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn109.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn109.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn109.FieldName = "Ort (Sitz)"
        Me.LayoutViewColumn109.LayoutViewField = Me.LayoutViewField31
        Me.LayoutViewColumn109.Name = "LayoutViewColumn109"
        Me.LayoutViewColumn109.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn109.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn109.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField31
        '
        Me.LayoutViewField31.EditorPreferredWidth = 321
        Me.LayoutViewField31.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField31.Name = "LayoutViewField31"
        Me.LayoutViewField31.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField31.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn110
        '
        Me.LayoutViewColumn110.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn110.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn110.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn110.FieldName = "Änderungs-kennzeichen"
        Me.LayoutViewColumn110.LayoutViewField = Me.LayoutViewField32
        Me.LayoutViewColumn110.Name = "LayoutViewColumn110"
        Me.LayoutViewColumn110.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn110.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn110.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField32
        '
        Me.LayoutViewField32.EditorPreferredWidth = 321
        Me.LayoutViewField32.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField32.Name = "LayoutViewField32"
        Me.LayoutViewField32.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField32.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn111
        '
        Me.LayoutViewColumn111.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn111.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn111.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn111.FieldName = "Termin BLZ-Löschung"
        Me.LayoutViewColumn111.LayoutViewField = Me.LayoutViewField33
        Me.LayoutViewColumn111.Name = "LayoutViewColumn111"
        Me.LayoutViewColumn111.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn111.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn111.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField33
        '
        Me.LayoutViewField33.EditorPreferredWidth = 321
        Me.LayoutViewField33.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField33.Name = "LayoutViewField33"
        Me.LayoutViewField33.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField33.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn112
        '
        Me.LayoutViewColumn112.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn112.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn112.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn112.FieldName = "DSNr-Nachfolgeinstitut"
        Me.LayoutViewColumn112.LayoutViewField = Me.LayoutViewField34
        Me.LayoutViewColumn112.Name = "LayoutViewColumn112"
        Me.LayoutViewColumn112.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn112.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn112.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField34
        '
        Me.LayoutViewField34.EditorPreferredWidth = 321
        Me.LayoutViewField34.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField34.Name = "LayoutViewField34"
        Me.LayoutViewField34.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField34.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn113
        '
        Me.LayoutViewColumn113.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn113.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn113.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn113.FieldName = "Zustelladresse Firma"
        Me.LayoutViewColumn113.LayoutViewField = Me.LayoutViewField35
        Me.LayoutViewColumn113.Name = "LayoutViewColumn113"
        Me.LayoutViewColumn113.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn113.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn113.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField35
        '
        Me.LayoutViewField35.EditorPreferredWidth = 403
        Me.LayoutViewField35.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField35.Name = "LayoutViewField35"
        Me.LayoutViewField35.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField35.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn114
        '
        Me.LayoutViewColumn114.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn114.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn114.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn114.FieldName = "Zustelladresse Ort"
        Me.LayoutViewColumn114.LayoutViewField = Me.LayoutViewField36
        Me.LayoutViewColumn114.Name = "LayoutViewColumn114"
        Me.LayoutViewColumn114.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn114.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn114.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField36
        '
        Me.LayoutViewField36.EditorPreferredWidth = 403
        Me.LayoutViewField36.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField36.Name = "LayoutViewField36"
        Me.LayoutViewField36.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField36.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn115
        '
        Me.LayoutViewColumn115.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn115.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn115.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn115.FieldName = "Zustelladresse Postfach"
        Me.LayoutViewColumn115.LayoutViewField = Me.LayoutViewField37
        Me.LayoutViewColumn115.Name = "LayoutViewColumn115"
        Me.LayoutViewColumn115.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn115.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn115.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField37
        '
        Me.LayoutViewField37.EditorPreferredWidth = 403
        Me.LayoutViewField37.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField37.Name = "LayoutViewField37"
        Me.LayoutViewField37.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField37.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn116
        '
        Me.LayoutViewColumn116.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn116.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn116.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn116.FieldName = "Zustelladresse Postleitzahl"
        Me.LayoutViewColumn116.LayoutViewField = Me.LayoutViewField38
        Me.LayoutViewColumn116.Name = "LayoutViewColumn116"
        Me.LayoutViewColumn116.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn116.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn116.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField38
        '
        Me.LayoutViewField38.EditorPreferredWidth = 403
        Me.LayoutViewField38.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField38.Name = "LayoutViewField38"
        Me.LayoutViewField38.Size = New System.Drawing.Size(542, 20)
        Me.LayoutViewField38.TextSize = New System.Drawing.Size(130, 13)
        '
        'LayoutViewColumn117
        '
        Me.LayoutViewColumn117.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn117.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn117.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn117.FieldName = "Rücksendung Firma"
        Me.LayoutViewColumn117.LayoutViewField = Me.LayoutViewField39
        Me.LayoutViewColumn117.Name = "LayoutViewColumn117"
        Me.LayoutViewColumn117.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn117.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn117.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField39
        '
        Me.LayoutViewField39.EditorPreferredWidth = 597
        Me.LayoutViewField39.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField39.Name = "LayoutViewField39"
        Me.LayoutViewField39.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField39.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn118
        '
        Me.LayoutViewColumn118.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn118.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn118.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn118.FieldName = "Rücksendung Postfach"
        Me.LayoutViewColumn118.LayoutViewField = Me.LayoutViewField40
        Me.LayoutViewColumn118.Name = "LayoutViewColumn118"
        Me.LayoutViewColumn118.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn118.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn118.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField40
        '
        Me.LayoutViewField40.EditorPreferredWidth = 597
        Me.LayoutViewField40.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField40.Name = "LayoutViewField40"
        Me.LayoutViewField40.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField40.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn119
        '
        Me.LayoutViewColumn119.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn119.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn119.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn119.FieldName = "Rücksendung Straße"
        Me.LayoutViewColumn119.LayoutViewField = Me.LayoutViewField41
        Me.LayoutViewColumn119.Name = "LayoutViewColumn119"
        Me.LayoutViewColumn119.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn119.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn119.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField41
        '
        Me.LayoutViewField41.EditorPreferredWidth = 597
        Me.LayoutViewField41.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField41.Name = "LayoutViewField41"
        Me.LayoutViewField41.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField41.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn120
        '
        Me.LayoutViewColumn120.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn120.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn120.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn120.FieldName = "Rücksendung Postleitzahl"
        Me.LayoutViewColumn120.LayoutViewField = Me.LayoutViewField42
        Me.LayoutViewColumn120.Name = "LayoutViewColumn120"
        Me.LayoutViewColumn120.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn120.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn120.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField42
        '
        Me.LayoutViewField42.EditorPreferredWidth = 597
        Me.LayoutViewField42.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField42.Name = "LayoutViewField42"
        Me.LayoutViewField42.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField42.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn121
        '
        Me.LayoutViewColumn121.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn121.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn121.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn121.FieldName = "Rücksendung Ort"
        Me.LayoutViewColumn121.LayoutViewField = Me.LayoutViewField43
        Me.LayoutViewColumn121.Name = "LayoutViewColumn121"
        Me.LayoutViewColumn121.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn121.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn121.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField43
        '
        Me.LayoutViewField43.EditorPreferredWidth = 597
        Me.LayoutViewField43.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField43.Name = "LayoutViewField43"
        Me.LayoutViewField43.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField43.TextSize = New System.Drawing.Size(125, 13)
        '
        'LayoutViewColumn122
        '
        Me.LayoutViewColumn122.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn122.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn122.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn122.FieldName = "Institutstyp"
        Me.LayoutViewColumn122.LayoutViewField = Me.LayoutViewField44
        Me.LayoutViewColumn122.Name = "LayoutViewColumn122"
        Me.LayoutViewColumn122.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn122.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn122.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField44
        '
        Me.LayoutViewField44.EditorPreferredWidth = 321
        Me.LayoutViewField44.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField44.Name = "LayoutViewField44"
        Me.LayoutViewField44.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField44.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn123
        '
        Me.LayoutViewColumn123.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn123.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn123.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn123.FieldName = "BLZ der vorgeschalteten Stelle"
        Me.LayoutViewColumn123.LayoutViewField = Me.LayoutViewField45
        Me.LayoutViewColumn123.Name = "LayoutViewColumn123"
        Me.LayoutViewColumn123.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn123.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn123.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField45
        '
        Me.LayoutViewField45.EditorPreferredWidth = 321
        Me.LayoutViewField45.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField45.Name = "LayoutViewField45"
        Me.LayoutViewField45.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField45.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn124
        '
        Me.LayoutViewColumn124.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn124.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn124.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn124.FieldName = "Avisierung von Zahlungen TEL"
        Me.LayoutViewColumn124.LayoutViewField = Me.LayoutViewField46
        Me.LayoutViewColumn124.Name = "LayoutViewColumn124"
        Me.LayoutViewColumn124.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn124.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn124.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField46
        '
        Me.LayoutViewField46.EditorPreferredWidth = 561
        Me.LayoutViewField46.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField46.Name = "LayoutViewField46"
        Me.LayoutViewField46.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField46.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn125
        '
        Me.LayoutViewColumn125.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn125.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn125.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn125.FieldName = "Avisierung von Zahlungen FAX"
        Me.LayoutViewColumn125.LayoutViewField = Me.LayoutViewField47
        Me.LayoutViewColumn125.Name = "LayoutViewColumn125"
        Me.LayoutViewColumn125.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn125.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn125.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField47
        '
        Me.LayoutViewField47.EditorPreferredWidth = 561
        Me.LayoutViewField47.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField47.Name = "LayoutViewField47"
        Me.LayoutViewField47.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField47.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn126
        '
        Me.LayoutViewColumn126.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn126.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn126.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn126.FieldName = "Avisierung von Zahlungen EMAIL"
        Me.LayoutViewColumn126.LayoutViewField = Me.LayoutViewField66
        Me.LayoutViewColumn126.Name = "LayoutViewColumn126"
        Me.LayoutViewColumn126.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn126.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn126.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField66
        '
        Me.LayoutViewField66.EditorPreferredWidth = 561
        Me.LayoutViewField66.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField66.Name = "LayoutViewField66"
        Me.LayoutViewField66.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField66.TextSize = New System.Drawing.Size(161, 13)
        '
        'LayoutViewColumn127
        '
        Me.LayoutViewColumn127.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn127.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn127.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn127.FieldName = "Überweisungs-nachfragen TEL"
        Me.LayoutViewColumn127.LayoutViewField = Me.LayoutViewField67
        Me.LayoutViewColumn127.Name = "LayoutViewColumn127"
        Me.LayoutViewColumn127.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn127.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn127.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField67
        '
        Me.LayoutViewField67.EditorPreferredWidth = 357
        Me.LayoutViewField67.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField67.Name = "LayoutViewField67"
        Me.LayoutViewField67.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField67.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn128
        '
        Me.LayoutViewColumn128.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn128.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn128.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn128.FieldName = "Überweisungs-nachfragen FAX"
        Me.LayoutViewColumn128.LayoutViewField = Me.LayoutViewField68
        Me.LayoutViewColumn128.Name = "LayoutViewColumn128"
        Me.LayoutViewColumn128.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn128.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn128.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField68
        '
        Me.LayoutViewField68.EditorPreferredWidth = 357
        Me.LayoutViewField68.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField68.Name = "LayoutViewField68"
        Me.LayoutViewField68.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField68.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn129
        '
        Me.LayoutViewColumn129.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn129.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn129.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn129.FieldName = "Überweisungsnachfragen EMAIL"
        Me.LayoutViewColumn129.LayoutViewField = Me.LayoutViewField69
        Me.LayoutViewColumn129.Name = "LayoutViewColumn129"
        Me.LayoutViewColumn129.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn129.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn129.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField69
        '
        Me.LayoutViewField69.EditorPreferredWidth = 357
        Me.LayoutViewField69.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField69.Name = "LayoutViewField69"
        Me.LayoutViewField69.Size = New System.Drawing.Size(525, 20)
        Me.LayoutViewField69.TextSize = New System.Drawing.Size(159, 13)
        '
        'LayoutViewColumn130
        '
        Me.LayoutViewColumn130.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn130.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn130.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn130.FieldName = "Überweisungs-rückruf TEL"
        Me.LayoutViewColumn130.LayoutViewField = Me.LayoutViewField70
        Me.LayoutViewColumn130.Name = "LayoutViewColumn130"
        Me.LayoutViewColumn130.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn130.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn130.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField70
        '
        Me.LayoutViewField70.EditorPreferredWidth = 591
        Me.LayoutViewField70.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField70.Name = "LayoutViewField70"
        Me.LayoutViewField70.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField70.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn131
        '
        Me.LayoutViewColumn131.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn131.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn131.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn131.FieldName = "Überweisungs-rückruf FAX"
        Me.LayoutViewColumn131.LayoutViewField = Me.LayoutViewField71
        Me.LayoutViewColumn131.Name = "LayoutViewColumn131"
        Me.LayoutViewColumn131.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn131.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn131.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField71
        '
        Me.LayoutViewField71.EditorPreferredWidth = 591
        Me.LayoutViewField71.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField71.Name = "LayoutViewField71"
        Me.LayoutViewField71.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField71.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutViewColumn132
        '
        Me.LayoutViewColumn132.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn132.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn132.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn132.FieldName = "Überweisungs-rückfragen TEL"
        Me.LayoutViewColumn132.LayoutViewField = Me.LayoutViewField72
        Me.LayoutViewColumn132.Name = "LayoutViewColumn132"
        Me.LayoutViewColumn132.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn132.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn132.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField72
        '
        Me.LayoutViewField72.EditorPreferredWidth = 566
        Me.LayoutViewField72.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField72.Name = "LayoutViewField72"
        Me.LayoutViewField72.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField72.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn133
        '
        Me.LayoutViewColumn133.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn133.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn133.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn133.FieldName = "Überweisungs-rückfragen FAX"
        Me.LayoutViewColumn133.LayoutViewField = Me.LayoutViewField73
        Me.LayoutViewColumn133.Name = "LayoutViewColumn133"
        Me.LayoutViewColumn133.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn133.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn133.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField73
        '
        Me.LayoutViewField73.EditorPreferredWidth = 566
        Me.LayoutViewField73.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField73.Name = "LayoutViewField73"
        Me.LayoutViewField73.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField73.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn134
        '
        Me.LayoutViewColumn134.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn134.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn134.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn134.FieldName = "Überweisungsrückfragen EMAIL"
        Me.LayoutViewColumn134.LayoutViewField = Me.LayoutViewField74
        Me.LayoutViewColumn134.Name = "LayoutViewColumn134"
        Me.LayoutViewColumn134.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn134.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn134.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField74
        '
        Me.LayoutViewField74.EditorPreferredWidth = 566
        Me.LayoutViewField74.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField74.Name = "LayoutViewField74"
        Me.LayoutViewField74.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField74.TextSize = New System.Drawing.Size(156, 13)
        '
        'LayoutViewColumn135
        '
        Me.LayoutViewColumn135.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn135.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn135.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn135.FieldName = "Scheckanfrage TEL"
        Me.LayoutViewColumn135.LayoutViewField = Me.LayoutViewField75
        Me.LayoutViewColumn135.Name = "LayoutViewColumn135"
        Me.LayoutViewColumn135.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn135.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn135.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField75
        '
        Me.LayoutViewField75.EditorPreferredWidth = 614
        Me.LayoutViewField75.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField75.Name = "LayoutViewField75"
        Me.LayoutViewField75.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField75.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn136
        '
        Me.LayoutViewColumn136.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn136.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn136.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn136.FieldName = "Scheckanfrage FAX"
        Me.LayoutViewColumn136.LayoutViewField = Me.LayoutViewField76
        Me.LayoutViewColumn136.Name = "LayoutViewColumn136"
        Me.LayoutViewColumn136.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn136.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn136.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField76
        '
        Me.LayoutViewField76.EditorPreferredWidth = 614
        Me.LayoutViewField76.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField76.Name = "LayoutViewField76"
        Me.LayoutViewField76.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField76.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn137
        '
        Me.LayoutViewColumn137.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn137.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn137.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn137.FieldName = "Scheckanfrage EMAIL"
        Me.LayoutViewColumn137.LayoutViewField = Me.LayoutViewField77
        Me.LayoutViewColumn137.Name = "LayoutViewColumn137"
        Me.LayoutViewColumn137.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn137.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn137.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField77
        '
        Me.LayoutViewField77.EditorPreferredWidth = 614
        Me.LayoutViewField77.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField77.Name = "LayoutViewField77"
        Me.LayoutViewField77.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField77.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn138
        '
        Me.LayoutViewColumn138.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn138.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn138.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn138.FieldName = "Unbezahlte Schecks/ Lastschriften TEL"
        Me.LayoutViewColumn138.LayoutViewField = Me.LayoutViewField78
        Me.LayoutViewColumn138.Name = "LayoutViewColumn138"
        Me.LayoutViewColumn138.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn138.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn138.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField78
        '
        Me.LayoutViewField78.EditorPreferredWidth = 521
        Me.LayoutViewField78.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField78.Name = "LayoutViewField78"
        Me.LayoutViewField78.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField78.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn139
        '
        Me.LayoutViewColumn139.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn139.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn139.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn139.FieldName = "Unbezahlte Schecks/ Lastschriften FAX"
        Me.LayoutViewColumn139.LayoutViewField = Me.LayoutViewField79
        Me.LayoutViewColumn139.Name = "LayoutViewColumn139"
        Me.LayoutViewColumn139.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn139.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn139.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField79
        '
        Me.LayoutViewField79.EditorPreferredWidth = 521
        Me.LayoutViewField79.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField79.Name = "LayoutViewField79"
        Me.LayoutViewField79.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField79.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn140
        '
        Me.LayoutViewColumn140.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn140.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn140.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn140.FieldName = "Unbezahlte Schecks/ Lastschriften EMAIL"
        Me.LayoutViewColumn140.LayoutViewField = Me.LayoutViewField80
        Me.LayoutViewColumn140.Name = "LayoutViewColumn140"
        Me.LayoutViewColumn140.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn140.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn140.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField80
        '
        Me.LayoutViewField80.EditorPreferredWidth = 521
        Me.LayoutViewField80.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField80.Name = "LayoutViewField80"
        Me.LayoutViewField80.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField80.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn141
        '
        Me.LayoutViewColumn141.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn141.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn141.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn141.FieldName = "Lastschrift-rückruf TEL"
        Me.LayoutViewColumn141.LayoutViewField = Me.LayoutViewField81
        Me.LayoutViewColumn141.Name = "LayoutViewColumn141"
        Me.LayoutViewColumn141.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn141.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn141.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField81
        '
        Me.LayoutViewField81.EditorPreferredWidth = 601
        Me.LayoutViewField81.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField81.Name = "LayoutViewField81"
        Me.LayoutViewField81.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField81.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn142
        '
        Me.LayoutViewColumn142.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn142.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn142.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn142.FieldName = "Lastschrift-rückruf FAX"
        Me.LayoutViewColumn142.LayoutViewField = Me.LayoutViewField82
        Me.LayoutViewColumn142.Name = "LayoutViewColumn142"
        Me.LayoutViewColumn142.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn142.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn142.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField82
        '
        Me.LayoutViewField82.EditorPreferredWidth = 601
        Me.LayoutViewField82.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField82.Name = "LayoutViewField82"
        Me.LayoutViewField82.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField82.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn143
        '
        Me.LayoutViewColumn143.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn143.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn143.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn143.FieldName = "Lastschriftrückruf EMAIL"
        Me.LayoutViewColumn143.LayoutViewField = Me.LayoutViewField83
        Me.LayoutViewColumn143.Name = "LayoutViewColumn143"
        Me.LayoutViewColumn143.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn143.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn143.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField83
        '
        Me.LayoutViewField83.EditorPreferredWidth = 601
        Me.LayoutViewField83.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField83.Name = "LayoutViewField83"
        Me.LayoutViewField83.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField83.TextSize = New System.Drawing.Size(121, 13)
        '
        'LayoutViewColumn144
        '
        Me.LayoutViewColumn144.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn144.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn144.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn144.FieldName = "Wechselrückrufe TEL"
        Me.LayoutViewColumn144.LayoutViewField = Me.LayoutViewField84
        Me.LayoutViewColumn144.Name = "LayoutViewColumn144"
        Me.LayoutViewColumn144.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn144.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn144.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField84
        '
        Me.LayoutViewField84.EditorPreferredWidth = 581
        Me.LayoutViewField84.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField84.Name = "LayoutViewField84"
        Me.LayoutViewField84.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField84.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn145
        '
        Me.LayoutViewColumn145.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn145.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn145.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn145.FieldName = "Wechselrückrufe FAX"
        Me.LayoutViewColumn145.LayoutViewField = Me.LayoutViewField85
        Me.LayoutViewColumn145.Name = "LayoutViewColumn145"
        Me.LayoutViewColumn145.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn145.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn145.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField85
        '
        Me.LayoutViewField85.EditorPreferredWidth = 581
        Me.LayoutViewField85.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField85.Name = "LayoutViewField85"
        Me.LayoutViewField85.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField85.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn146
        '
        Me.LayoutViewColumn146.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn146.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn146.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn146.FieldName = "Wechselrückrufe EMAIL"
        Me.LayoutViewColumn146.LayoutViewField = Me.LayoutViewField86
        Me.LayoutViewColumn146.Name = "LayoutViewColumn146"
        Me.LayoutViewColumn146.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn146.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn146.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField86
        '
        Me.LayoutViewField86.EditorPreferredWidth = 581
        Me.LayoutViewField86.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField86.Name = "LayoutViewField86"
        Me.LayoutViewField86.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField86.TextSize = New System.Drawing.Size(117, 13)
        '
        'LayoutViewColumn147
        '
        Me.LayoutViewColumn147.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn147.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn147.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn147.FieldName = "Unbezahlte Wechsel TEL"
        Me.LayoutViewColumn147.LayoutViewField = Me.LayoutViewField87
        Me.LayoutViewColumn147.Name = "LayoutViewColumn147"
        Me.LayoutViewColumn147.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn147.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn147.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField87
        '
        Me.LayoutViewField87.EditorPreferredWidth = 564
        Me.LayoutViewField87.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField87.Name = "LayoutViewField87"
        Me.LayoutViewField87.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField87.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn148
        '
        Me.LayoutViewColumn148.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn148.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn148.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn148.FieldName = "Unbezahlte Wechsel FAX"
        Me.LayoutViewColumn148.LayoutViewField = Me.LayoutViewField88
        Me.LayoutViewColumn148.Name = "LayoutViewColumn148"
        Me.LayoutViewColumn148.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn148.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn148.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField88
        '
        Me.LayoutViewField88.EditorPreferredWidth = 564
        Me.LayoutViewField88.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField88.Name = "LayoutViewField88"
        Me.LayoutViewField88.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField88.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn149
        '
        Me.LayoutViewColumn149.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn149.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn149.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn149.FieldName = "Unbezahlte Wechsel EMAIL"
        Me.LayoutViewColumn149.LayoutViewField = Me.LayoutViewField89
        Me.LayoutViewColumn149.Name = "LayoutViewColumn149"
        Me.LayoutViewColumn149.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn149.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn149.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField89
        '
        Me.LayoutViewField89.EditorPreferredWidth = 564
        Me.LayoutViewField89.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField89.Name = "LayoutViewField89"
        Me.LayoutViewField89.Size = New System.Drawing.Size(707, 20)
        Me.LayoutViewField89.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutViewColumn150
        '
        Me.LayoutViewColumn150.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn150.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn150.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn150.FieldName = "Vorgeschaltete Stelle TEL"
        Me.LayoutViewColumn150.LayoutViewField = Me.LayoutViewField90
        Me.LayoutViewColumn150.Name = "LayoutViewColumn150"
        Me.LayoutViewColumn150.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn150.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn150.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField90
        '
        Me.LayoutViewField90.EditorPreferredWidth = 584
        Me.LayoutViewField90.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField90.Name = "LayoutViewField90"
        Me.LayoutViewField90.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField90.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn151
        '
        Me.LayoutViewColumn151.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn151.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn151.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn151.FieldName = "Vorgeschaltete Stelle FAX"
        Me.LayoutViewColumn151.LayoutViewField = Me.LayoutViewField91
        Me.LayoutViewColumn151.Name = "LayoutViewColumn151"
        Me.LayoutViewColumn151.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn151.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn151.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField91
        '
        Me.LayoutViewField91.EditorPreferredWidth = 584
        Me.LayoutViewField91.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField91.Name = "LayoutViewField91"
        Me.LayoutViewField91.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField91.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn152
        '
        Me.LayoutViewColumn152.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn152.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn152.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn152.FieldName = "Vorgeschaltete Stelle EMAIL"
        Me.LayoutViewColumn152.LayoutViewField = Me.LayoutViewField92
        Me.LayoutViewColumn152.Name = "LayoutViewColumn152"
        Me.LayoutViewColumn152.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn152.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn152.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField92
        '
        Me.LayoutViewField92.EditorPreferredWidth = 584
        Me.LayoutViewField92.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField92.Name = "LayoutViewField92"
        Me.LayoutViewField92.Size = New System.Drawing.Size(731, 20)
        Me.LayoutViewField92.TextSize = New System.Drawing.Size(138, 13)
        '
        'LayoutViewColumn153
        '
        Me.LayoutViewColumn153.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn153.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn153.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn153.FieldName = "Meldeweg"
        Me.LayoutViewColumn153.LayoutViewField = Me.LayoutViewField93
        Me.LayoutViewColumn153.Name = "LayoutViewColumn153"
        Me.LayoutViewColumn153.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn153.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn153.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField93
        '
        Me.LayoutViewField93.EditorPreferredWidth = 321
        Me.LayoutViewField93.Location = New System.Drawing.Point(0, 200)
        Me.LayoutViewField93.Name = "LayoutViewField93"
        Me.LayoutViewField93.Size = New System.Drawing.Size(523, 20)
        Me.LayoutViewField93.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn154
        '
        Me.LayoutViewColumn154.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn154.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn154.ColumnEdit = Me.RepositoryItemComboBox3
        Me.LayoutViewColumn154.FieldName = "VALID"
        Me.LayoutViewColumn154.LayoutViewField = Me.LayoutViewField94
        Me.LayoutViewColumn154.Name = "LayoutViewColumn154"
        Me.LayoutViewColumn154.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn154.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn154.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField94
        '
        Me.LayoutViewField94.EditorPreferredWidth = 48
        Me.LayoutViewField94.Location = New System.Drawing.Point(0, 220)
        Me.LayoutViewField94.Name = "LayoutViewField94"
        Me.LayoutViewField94.Size = New System.Drawing.Size(250, 20)
        Me.LayoutViewField94.TextSize = New System.Drawing.Size(193, 13)
        '
        'LayoutViewColumn155
        '
        Me.LayoutViewColumn155.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn155.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn155.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn155.FieldName = "USER"
        Me.LayoutViewColumn155.LayoutViewField = Me.LayoutViewField95
        Me.LayoutViewColumn155.Name = "LayoutViewColumn155"
        Me.LayoutViewColumn155.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn155.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn155.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField95
        '
        Me.LayoutViewField95.EditorPreferredWidth = 20
        Me.LayoutViewField95.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField95.Name = "LayoutViewField95"
        Me.LayoutViewField95.Size = New System.Drawing.Size(547, 612)
        Me.LayoutViewField95.TextSize = New System.Drawing.Size(201, 13)
        '
        'LayoutViewColumn156
        '
        Me.LayoutViewColumn156.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn156.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn156.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn156.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn156.LayoutViewField = Me.LayoutViewField96
        Me.LayoutViewColumn156.Name = "LayoutViewColumn156"
        Me.LayoutViewColumn156.OptionsColumn.AllowEdit = False
        Me.LayoutViewColumn156.OptionsFilter.AllowAutoFilter = False
        Me.LayoutViewColumn156.OptionsFilter.AllowFilter = False
        '
        'LayoutViewField96
        '
        Me.LayoutViewField96.EditorPreferredWidth = 20
        Me.LayoutViewField96.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField96.Name = "LayoutViewField96"
        Me.LayoutViewField96.Size = New System.Drawing.Size(547, 612)
        Me.LayoutViewField96.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutViewField96.TextVisible = False
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField26})
        Me.LayoutViewCard1.Name = "LayoutViewCard2"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'LayoutView6
        '
        Me.LayoutView6.GridControl = Me.GridControl3
        Me.LayoutView6.Name = "LayoutView6"
        Me.LayoutView6.TemplateCard = Nothing
        '
        'LayoutView7
        '
        Me.LayoutView7.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView7.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn157, Me.LayoutViewColumn158, Me.LayoutViewColumn159, Me.LayoutViewColumn160, Me.LayoutViewColumn161, Me.LayoutViewColumn162, Me.LayoutViewColumn163, Me.LayoutViewColumn164, Me.LayoutViewColumn165, Me.LayoutViewColumn166, Me.LayoutViewColumn167, Me.LayoutViewColumn168, Me.LayoutViewColumn169, Me.LayoutViewColumn170, Me.LayoutViewColumn171, Me.LayoutViewColumn172, Me.LayoutViewColumn173, Me.LayoutViewColumn174, Me.LayoutViewColumn175, Me.LayoutViewColumn176, Me.LayoutViewColumn177, Me.LayoutViewColumn178, Me.LayoutViewColumn179, Me.LayoutViewColumn180, Me.LayoutViewColumn181})
        Me.LayoutView7.GridControl = Me.GridControl3
        Me.LayoutView7.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField118, Me.LayoutViewField117, Me.LayoutViewField115})
        Me.LayoutView7.Name = "LayoutView7"
        Me.LayoutView7.OptionsBehavior.AllowRuntimeCustomization = False
        Me.LayoutView7.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.LayoutView7.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.LayoutView7.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.LayoutView7.OptionsCustomization.AllowFilter = False
        Me.LayoutView7.OptionsCustomization.AllowSort = False
        Me.LayoutView7.OptionsCustomization.ShowGroupLayoutTreeView = False
        Me.LayoutView7.OptionsCustomization.ShowGroupView = False
        Me.LayoutView7.OptionsCustomization.ShowResetShrinkButtons = False
        Me.LayoutView7.OptionsCustomization.ShowSaveLoadLayoutButtons = False
        Me.LayoutView7.OptionsFilter.AllowColumnMRUFilterList = False
        Me.LayoutView7.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.LayoutView7.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowRowModeButton = False
        Me.LayoutView7.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.LayoutView7.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.LayoutView7.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.LayoutView7.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.LayoutView7.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.LayoutView7.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.LayoutView7.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.LayoutViewColumn157, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.LayoutView7.TemplateCard = Nothing
        '
        'LayoutViewColumn157
        '
        Me.LayoutViewColumn157.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn157.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn157.FieldName = "Idnr"
        Me.LayoutViewColumn157.LayoutViewField = Me.LayoutViewField97
        Me.LayoutViewColumn157.Name = "LayoutViewColumn157"
        Me.LayoutViewColumn157.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField97
        '
        Me.LayoutViewField97.EditorPreferredWidth = 61
        Me.LayoutViewField97.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField97.Name = "LayoutViewField97"
        Me.LayoutViewField97.Size = New System.Drawing.Size(178, 20)
        Me.LayoutViewField97.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn158
        '
        Me.LayoutViewColumn158.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn158.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn158.FieldName = "TAG"
        Me.LayoutViewColumn158.LayoutViewField = Me.LayoutViewField98
        Me.LayoutViewColumn158.Name = "LayoutViewColumn158"
        '
        'LayoutViewField98
        '
        Me.LayoutViewField98.EditorPreferredWidth = 318
        Me.LayoutViewField98.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField98.Name = "LayoutViewField98"
        Me.LayoutViewField98.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField98.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn159
        '
        Me.LayoutViewColumn159.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn159.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn159.FieldName = "MODIFICATION FLAG"
        Me.LayoutViewColumn159.LayoutViewField = Me.LayoutViewField99
        Me.LayoutViewColumn159.Name = "LayoutViewColumn159"
        '
        'LayoutViewField99
        '
        Me.LayoutViewField99.EditorPreferredWidth = 318
        Me.LayoutViewField99.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField99.Name = "LayoutViewField99"
        Me.LayoutViewField99.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField99.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn160
        '
        Me.LayoutViewColumn160.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn160.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn160.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn160.FieldName = "INSTITUTION NAME"
        Me.LayoutViewColumn160.LayoutViewField = Me.LayoutViewField100
        Me.LayoutViewColumn160.Name = "LayoutViewColumn160"
        '
        'LayoutViewField100
        '
        Me.LayoutViewField100.EditorPreferredWidth = 306
        Me.LayoutViewField100.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField100.Name = "LayoutViewField100"
        Me.LayoutViewField100.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField100.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn161
        '
        Me.LayoutViewColumn161.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn161.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn161.FieldName = "BRANCH INFORMATION"
        Me.LayoutViewColumn161.LayoutViewField = Me.LayoutViewField101
        Me.LayoutViewColumn161.Name = "LayoutViewColumn161"
        '
        'LayoutViewField101
        '
        Me.LayoutViewField101.EditorPreferredWidth = 306
        Me.LayoutViewField101.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField101.Name = "LayoutViewField101"
        Me.LayoutViewField101.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField101.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn162
        '
        Me.LayoutViewColumn162.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn162.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn162.FieldName = "CITY HEADING"
        Me.LayoutViewColumn162.LayoutViewField = Me.LayoutViewField102
        Me.LayoutViewColumn162.Name = "LayoutViewColumn162"
        '
        'LayoutViewField102
        '
        Me.LayoutViewField102.EditorPreferredWidth = 306
        Me.LayoutViewField102.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField102.Name = "LayoutViewField102"
        Me.LayoutViewField102.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField102.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn163
        '
        Me.LayoutViewColumn163.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn163.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn163.FieldName = "SUBTYPE INDICATION"
        Me.LayoutViewColumn163.LayoutViewField = Me.LayoutViewField103
        Me.LayoutViewColumn163.Name = "LayoutViewColumn163"
        '
        'LayoutViewField103
        '
        Me.LayoutViewField103.EditorPreferredWidth = 306
        Me.LayoutViewField103.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField103.Name = "LayoutViewField103"
        Me.LayoutViewField103.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField103.TextSize = New System.Drawing.Size(120, 13)
        '
        'LayoutViewColumn164
        '
        Me.LayoutViewColumn164.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn164.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn164.FieldName = "VALUE ADDED SERVICES"
        Me.LayoutViewColumn164.LayoutViewField = Me.LayoutViewField104
        Me.LayoutViewColumn164.Name = "LayoutViewColumn164"
        '
        'LayoutViewField104
        '
        Me.LayoutViewField104.EditorPreferredWidth = 303
        Me.LayoutViewField104.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField104.Name = "LayoutViewField104"
        Me.LayoutViewField104.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField104.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn165
        '
        Me.LayoutViewColumn165.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn165.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn165.FieldName = "EXTRA INFO"
        Me.LayoutViewColumn165.LayoutViewField = Me.LayoutViewField105
        Me.LayoutViewColumn165.Name = "LayoutViewColumn165"
        '
        'LayoutViewField105
        '
        Me.LayoutViewField105.EditorPreferredWidth = 318
        Me.LayoutViewField105.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField105.Name = "LayoutViewField105"
        Me.LayoutViewField105.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField105.TextSize = New System.Drawing.Size(108, 13)
        '
        'LayoutViewColumn166
        '
        Me.LayoutViewColumn166.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn166.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn166.FieldName = "PHYSICAL ADDRESS 1"
        Me.LayoutViewColumn166.LayoutViewField = Me.LayoutViewField106
        Me.LayoutViewColumn166.Name = "LayoutViewColumn166"
        '
        'LayoutViewField106
        '
        Me.LayoutViewField106.EditorPreferredWidth = 316
        Me.LayoutViewField106.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField106.Name = "LayoutViewField106"
        Me.LayoutViewField106.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField106.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn167
        '
        Me.LayoutViewColumn167.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn167.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn167.FieldName = "PHYSICAL ADDRESS 2"
        Me.LayoutViewColumn167.LayoutViewField = Me.LayoutViewField107
        Me.LayoutViewColumn167.Name = "LayoutViewColumn167"
        '
        'LayoutViewField107
        '
        Me.LayoutViewField107.EditorPreferredWidth = 316
        Me.LayoutViewField107.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField107.Name = "LayoutViewField107"
        Me.LayoutViewField107.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField107.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn168
        '
        Me.LayoutViewColumn168.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn168.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn168.FieldName = "PHYSICAL ADDRESS 3"
        Me.LayoutViewColumn168.LayoutViewField = Me.LayoutViewField108
        Me.LayoutViewColumn168.Name = "LayoutViewColumn168"
        '
        'LayoutViewField108
        '
        Me.LayoutViewField108.EditorPreferredWidth = 316
        Me.LayoutViewField108.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField108.Name = "LayoutViewField108"
        Me.LayoutViewField108.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField108.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn169
        '
        Me.LayoutViewColumn169.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn169.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn169.FieldName = "PHYSICAL ADDRESS 4"
        Me.LayoutViewColumn169.LayoutViewField = Me.LayoutViewField109
        Me.LayoutViewColumn169.Name = "LayoutViewColumn169"
        '
        'LayoutViewField109
        '
        Me.LayoutViewField109.EditorPreferredWidth = 316
        Me.LayoutViewField109.Location = New System.Drawing.Point(0, 60)
        Me.LayoutViewField109.Name = "LayoutViewField109"
        Me.LayoutViewField109.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField109.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn170
        '
        Me.LayoutViewColumn170.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn170.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn170.FieldName = "LOCATION"
        Me.LayoutViewColumn170.LayoutViewField = Me.LayoutViewField110
        Me.LayoutViewColumn170.Name = "LayoutViewColumn170"
        '
        'LayoutViewField110
        '
        Me.LayoutViewField110.EditorPreferredWidth = 316
        Me.LayoutViewField110.Location = New System.Drawing.Point(0, 120)
        Me.LayoutViewField110.Name = "LayoutViewField110"
        Me.LayoutViewField110.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField110.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn171
        '
        Me.LayoutViewColumn171.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn171.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn171.FieldName = "COUNTRY NAME"
        Me.LayoutViewColumn171.LayoutViewField = Me.LayoutViewField111
        Me.LayoutViewColumn171.Name = "LayoutViewColumn171"
        '
        'LayoutViewField111
        '
        Me.LayoutViewField111.EditorPreferredWidth = 316
        Me.LayoutViewField111.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField111.Name = "LayoutViewField111"
        Me.LayoutViewField111.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField111.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn172
        '
        Me.LayoutViewColumn172.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn172.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn172.FieldName = "POB NUMBER"
        Me.LayoutViewColumn172.LayoutViewField = Me.LayoutViewField112
        Me.LayoutViewColumn172.Name = "LayoutViewColumn172"
        '
        'LayoutViewField112
        '
        Me.LayoutViewField112.EditorPreferredWidth = 316
        Me.LayoutViewField112.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField112.Name = "LayoutViewField112"
        Me.LayoutViewField112.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField112.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn173
        '
        Me.LayoutViewColumn173.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn173.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn173.FieldName = "POB LOCATION"
        Me.LayoutViewColumn173.LayoutViewField = Me.LayoutViewField113
        Me.LayoutViewColumn173.Name = "LayoutViewColumn173"
        '
        'LayoutViewField113
        '
        Me.LayoutViewField113.EditorPreferredWidth = 316
        Me.LayoutViewField113.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField113.Name = "LayoutViewField113"
        Me.LayoutViewField113.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField113.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn174
        '
        Me.LayoutViewColumn174.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn174.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn174.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn174.LayoutViewField = Me.LayoutViewField114
        Me.LayoutViewColumn174.Name = "LayoutViewColumn174"
        '
        'LayoutViewField114
        '
        Me.LayoutViewField114.EditorPreferredWidth = 316
        Me.LayoutViewField114.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField114.Name = "LayoutViewField114"
        Me.LayoutViewField114.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField114.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn175
        '
        Me.LayoutViewColumn175.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn175.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn175.FieldName = "USER"
        Me.LayoutViewColumn175.LayoutViewField = Me.LayoutViewField115
        Me.LayoutViewColumn175.Name = "LayoutViewColumn175"
        Me.LayoutViewColumn175.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField115
        '
        Me.LayoutViewField115.EditorPreferredWidth = 20
        Me.LayoutViewField115.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField115.Name = "LayoutViewField115"
        Me.LayoutViewField115.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField115.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn176
        '
        Me.LayoutViewColumn176.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn176.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn176.ColumnEdit = Me.RepositoryItemComboBox3
        Me.LayoutViewColumn176.FieldName = "VALID"
        Me.LayoutViewColumn176.LayoutViewField = Me.LayoutViewField116
        Me.LayoutViewColumn176.Name = "LayoutViewColumn176"
        '
        'LayoutViewField116
        '
        Me.LayoutViewField116.EditorPreferredWidth = 70
        Me.LayoutViewField116.Location = New System.Drawing.Point(0, 40)
        Me.LayoutViewField116.Name = "LayoutViewField116"
        Me.LayoutViewField116.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField116.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn177
        '
        Me.LayoutViewColumn177.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn177.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn177.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn177.LayoutViewField = Me.LayoutViewField117
        Me.LayoutViewColumn177.Name = "LayoutViewColumn177"
        Me.LayoutViewColumn177.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField117
        '
        Me.LayoutViewField117.EditorPreferredWidth = 20
        Me.LayoutViewField117.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField117.Name = "LayoutViewField117"
        Me.LayoutViewField117.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField117.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn178
        '
        Me.LayoutViewColumn178.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn178.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn178.FieldName = "BIC11"
        Me.LayoutViewColumn178.LayoutViewField = Me.LayoutViewField118
        Me.LayoutViewColumn178.Name = "LayoutViewColumn178"
        Me.LayoutViewColumn178.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField118
        '
        Me.LayoutViewField118.EditorPreferredWidth = 20
        Me.LayoutViewField118.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField118.Name = "LayoutViewField118"
        Me.LayoutViewField118.Size = New System.Drawing.Size(459, 599)
        Me.LayoutViewField118.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn179
        '
        Me.LayoutViewColumn179.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn179.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn179.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn179.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn179.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn179.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn179.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn179.FieldName = "BIC CODE"
        Me.LayoutViewColumn179.LayoutViewField = Me.LayoutViewField119
        Me.LayoutViewColumn179.Name = "LayoutViewColumn179"
        '
        'LayoutViewField119
        '
        Me.LayoutViewField119.EditorPreferredWidth = 70
        Me.LayoutViewField119.ImageOptions.ImageIndex = 0
        Me.LayoutViewField119.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField119.Name = "LayoutViewField119"
        Me.LayoutViewField119.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField119.TextSize = New System.Drawing.Size(123, 16)
        '
        'LayoutViewColumn180
        '
        Me.LayoutViewColumn180.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn180.AppearanceCell.ForeColor = System.Drawing.Color.Blue
        Me.LayoutViewColumn180.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn180.AppearanceCell.Options.UseForeColor = True
        Me.LayoutViewColumn180.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn180.AppearanceHeader.Options.UseFont = True
        Me.LayoutViewColumn180.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.LayoutViewColumn180.FieldName = "BRANCH CODE"
        Me.LayoutViewColumn180.LayoutViewField = Me.LayoutViewField120
        Me.LayoutViewColumn180.Name = "LayoutViewColumn180"
        '
        'LayoutViewField120
        '
        Me.LayoutViewField120.EditorPreferredWidth = 70
        Me.LayoutViewField120.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField120.Name = "LayoutViewField120"
        Me.LayoutViewField120.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField120.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn181
        '
        Me.LayoutViewColumn181.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn181.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn181.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn181.FieldName = "COUNTRY"
        Me.LayoutViewColumn181.LayoutViewField = Me.LayoutViewField121
        Me.LayoutViewColumn181.Name = "LayoutViewColumn181"
        Me.LayoutViewColumn181.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField121
        '
        Me.LayoutViewField121.EditorPreferredWidth = 316
        Me.LayoutViewField121.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField121.Name = "LayoutViewField121"
        Me.LayoutViewField121.Size = New System.Drawing.Size(435, 20)
        Me.LayoutViewField121.TextSize = New System.Drawing.Size(110, 13)
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(17, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Date"
        '
        'LoadBusinessTypes_btn
        '
        Me.LoadBusinessTypes_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadBusinessTypes_btn.ImageOptions.ImageIndex = 0
        Me.LoadBusinessTypes_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadBusinessTypes_btn.Location = New System.Drawing.Point(226, 28)
        Me.LoadBusinessTypes_btn.Name = "LoadBusinessTypes_btn"
        Me.LoadBusinessTypes_btn.Size = New System.Drawing.Size(97, 22)
        Me.LoadBusinessTypes_btn.TabIndex = 21
        Me.LoadBusinessTypes_btn.Text = "Load Data"
        Me.LoadBusinessTypes_btn.Visible = False
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
        Me.XtraTabControl1.Location = New System.Drawing.Point(6, 58)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.BT_CP_XtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1305, 673)
        Me.XtraTabControl1.TabIndex = 23
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.BT_CP_XtraTabPage, Me.BT_CP_DetailsAll_XtraTabPage, Me.BT_CP_GEN_PARAM_XtraTabPage})
        '
        'BT_CP_XtraTabPage
        '
        Me.BT_CP_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_CP_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BT_CP_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.BT_CP_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BT_CP_XtraTabPage.Controls.Add(Me.LayoutControl1)
        Me.BT_CP_XtraTabPage.Name = "BT_CP_XtraTabPage"
        Me.BT_CP_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_XtraTabPage.Size = New System.Drawing.Size(1299, 645)
        Me.BT_CP_XtraTabPage.Text = "BUSINESS TYPES - LIABILITIES"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SQL_Commands_Dropdownbutton)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_BT_CP_Totals_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.BusinessTyperReport_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1299, 645)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SQL_Commands_Dropdownbutton
        '
        Me.SQL_Commands_Dropdownbutton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageIndex = 2
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageList = Me.ImageCollection1
        Me.SQL_Commands_Dropdownbutton.Location = New System.Drawing.Point(348, 24)
        Me.SQL_Commands_Dropdownbutton.Name = "SQL_Commands_Dropdownbutton"
        Me.SQL_Commands_Dropdownbutton.Size = New System.Drawing.Size(204, 22)
        Me.SQL_Commands_Dropdownbutton.StyleController = Me.LayoutControl1
        Me.SQL_Commands_Dropdownbutton.TabIndex = 7
        Me.SQL_Commands_Dropdownbutton.Text = "SQL Commands Run"
        '
        'Print_Export_BT_CP_Totals_Gridview_btn
        '
        Me.Print_Export_BT_CP_Totals_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_BT_CP_Totals_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_BT_CP_Totals_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_BT_CP_Totals_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_BT_CP_Totals_Gridview_btn.Name = "Print_Export_BT_CP_Totals_Gridview_btn"
        Me.Print_Export_BT_CP_Totals_Gridview_btn.Size = New System.Drawing.Size(147, 22)
        Me.Print_Export_BT_CP_Totals_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_BT_CP_Totals_Gridview_btn.TabIndex = 6
        Me.Print_Export_BT_CP_Totals_Gridview_btn.Text = "Print or Export"
        '
        'BusinessTyperReport_btn
        '
        Me.BusinessTyperReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BusinessTyperReport_btn.ImageOptions.ImageIndex = 3
        Me.BusinessTyperReport_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.BusinessTyperReport_btn.Location = New System.Drawing.Point(175, 24)
        Me.BusinessTyperReport_btn.Name = "BusinessTyperReport_btn"
        Me.BusinessTyperReport_btn.Size = New System.Drawing.Size(169, 22)
        Me.BusinessTyperReport_btn.StyleController = Me.LayoutControl1
        Me.BusinessTyperReport_btn.TabIndex = 5
        Me.BusinessTyperReport_btn.Text = "Business Types Report"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1208, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(67, 22)
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
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1299, 645)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1279, 575)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem7, Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1279, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1184, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(71, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(532, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(652, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_BT_CP_Totals_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SQL_Commands_Dropdownbutton
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(324, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(208, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BusinessTyperReport_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(151, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'BT_CP_DetailsAll_XtraTabPage
        '
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.BT_CP_DetailsAll_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BT_CP_DetailsAll_XtraTabPage.Controls.Add(Me.LayoutControl3)
        Me.BT_CP_DetailsAll_XtraTabPage.Name = "BT_CP_DetailsAll_XtraTabPage"
        Me.BT_CP_DetailsAll_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_DetailsAll_XtraTabPage.Size = New System.Drawing.Size(1299, 645)
        Me.BT_CP_DetailsAll_XtraTabPage.Text = "BUSINESS TYPES - LIABILITIES (ALL DETAILS)"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Controls.Add(Me.DropDownButton1)
        Me.LayoutControl3.Controls.Add(Me.Print_Export_BT_CP_DetailsAll_Gridview_btn)
        Me.LayoutControl3.Controls.Add(Me.BusinessTypesLiabilitiesDetailsRep_btn)
        Me.LayoutControl3.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1299, 645)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.DropDownButton1.ImageOptions.ImageIndex = 2
        Me.DropDownButton1.ImageOptions.ImageList = Me.ImageCollection1
        Me.DropDownButton1.Location = New System.Drawing.Point(348, 24)
        Me.DropDownButton1.Name = "DropDownButton1"
        Me.DropDownButton1.Size = New System.Drawing.Size(204, 22)
        Me.DropDownButton1.StyleController = Me.LayoutControl3
        Me.DropDownButton1.TabIndex = 7
        Me.DropDownButton1.Text = "SQL Commands Run"
        '
        'Print_Export_BT_CP_DetailsAll_Gridview_btn
        '
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.Name = "Print_Export_BT_CP_DetailsAll_Gridview_btn"
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.Size = New System.Drawing.Size(147, 22)
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.StyleController = Me.LayoutControl3
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.TabIndex = 6
        Me.Print_Export_BT_CP_DetailsAll_Gridview_btn.Text = "Print or Export"
        '
        'BusinessTypesLiabilitiesDetailsRep_btn
        '
        Me.BusinessTypesLiabilitiesDetailsRep_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BusinessTypesLiabilitiesDetailsRep_btn.ImageOptions.ImageIndex = 3
        Me.BusinessTypesLiabilitiesDetailsRep_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.BusinessTypesLiabilitiesDetailsRep_btn.Location = New System.Drawing.Point(175, 24)
        Me.BusinessTypesLiabilitiesDetailsRep_btn.Name = "BusinessTypesLiabilitiesDetailsRep_btn"
        Me.BusinessTypesLiabilitiesDetailsRep_btn.Size = New System.Drawing.Size(169, 22)
        Me.BusinessTypesLiabilitiesDetailsRep_btn.StyleController = Me.LayoutControl3
        Me.BusinessTypesLiabilitiesDetailsRep_btn.TabIndex = 5
        Me.BusinessTypesLiabilitiesDetailsRep_btn.Text = "Business Types Report"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton3.ImageOptions.ImageIndex = 5
        Me.SimpleButton3.Location = New System.Drawing.Point(1208, 24)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(67, 22)
        Me.SimpleButton3.StyleController = Me.LayoutControl3
        Me.SimpleButton3.TabIndex = 4
        Me.SimpleButton3.Text = "Edit Details"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Root"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup6})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1299, 645)
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.EmptySpaceItem2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem9})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1279, 625)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButton3
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(1184, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem2"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(71, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(532, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(652, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.Print_Export_BT_CP_DetailsAll_Gridview_btn
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem4"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(151, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.DropDownButton1
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(324, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem7"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(208, 26)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        Me.LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.BusinessTypesLiabilitiesDetailsRep_btn
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(151, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem3"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1255, 575)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'BT_CP_GEN_PARAM_XtraTabPage
        '
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.BT_CP_GEN_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BT_CP_GEN_PARAM_XtraTabPage.Controls.Add(Me.LayoutControl2)
        Me.BT_CP_GEN_PARAM_XtraTabPage.Name = "BT_CP_GEN_PARAM_XtraTabPage"
        Me.BT_CP_GEN_PARAM_XtraTabPage.PageVisible = False
        Me.BT_CP_GEN_PARAM_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.BT_CP_GEN_PARAM_XtraTabPage.Size = New System.Drawing.Size(1299, 645)
        Me.BT_CP_GEN_PARAM_XtraTabPage.Text = "BUSINESS TYPES-CREDIT PORTFOLIO GENERAL SQL COMMANDS"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.Print_Export_BT_CP_Temp_Gridview_btn)
        Me.LayoutControl2.Controls.Add(Me.Edit_INTERBANKV_Details_btn)
        Me.LayoutControl2.Controls.Add(Me.GridControl2)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(1299, 645)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Print_Export_BT_CP_Temp_Gridview_btn
        '
        Me.Print_Export_BT_CP_Temp_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_BT_CP_Temp_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_BT_CP_Temp_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_BT_CP_Temp_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_BT_CP_Temp_Gridview_btn.Name = "Print_Export_BT_CP_Temp_Gridview_btn"
        Me.Print_Export_BT_CP_Temp_Gridview_btn.Size = New System.Drawing.Size(146, 22)
        Me.Print_Export_BT_CP_Temp_Gridview_btn.StyleController = Me.LayoutControl2
        Me.Print_Export_BT_CP_Temp_Gridview_btn.TabIndex = 6
        Me.Print_Export_BT_CP_Temp_Gridview_btn.Text = "Print or Export"
        '
        'Edit_INTERBANKV_Details_btn
        '
        Me.Edit_INTERBANKV_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_INTERBANKV_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_INTERBANKV_Details_btn.Location = New System.Drawing.Point(1103, 24)
        Me.Edit_INTERBANKV_Details_btn.Name = "Edit_INTERBANKV_Details_btn"
        Me.Edit_INTERBANKV_Details_btn.Size = New System.Drawing.Size(172, 22)
        Me.Edit_INTERBANKV_Details_btn.StyleController = Me.LayoutControl2
        Me.Edit_INTERBANKV_Details_btn.TabIndex = 4
        Me.Edit_INTERBANKV_Details_btn.Text = "Show Details"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.Location = New System.Drawing.Point(12, 62)
        Me.GridControl2.MainView = Me.BT_CP_Temp_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(1275, 571)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BT_CP_Temp_GridView, Me.LayoutView4, Me.LayoutView3, Me.LayoutView2})
        '
        'BT_CP_Temp_GridView
        '
        Me.BT_CP_Temp_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BT_CP_Temp_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BT_CP_Temp_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BT_CP_Temp_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BT_CP_Temp_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BT_CP_Temp_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colBusinesType1, Me.colAmountBusinessType1, Me.colSQLBusinessTypeDetails1})
        Me.BT_CP_Temp_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BT_CP_Temp_GridView.GridControl = Me.GridControl2
        Me.BT_CP_Temp_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance(EUR Equ)", Nothing, "{0:n2}")})
        Me.BT_CP_Temp_GridView.Name = "BT_CP_Temp_GridView"
        Me.BT_CP_Temp_GridView.NewItemRowText = "Add new Business Type"
        Me.BT_CP_Temp_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Temp_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BT_CP_Temp_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BT_CP_Temp_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.BT_CP_Temp_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.BT_CP_Temp_GridView.OptionsFind.AlwaysVisible = True
        Me.BT_CP_Temp_GridView.OptionsSelection.MultiSelect = True
        Me.BT_CP_Temp_GridView.OptionsView.ColumnAutoWidth = False
        Me.BT_CP_Temp_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BT_CP_Temp_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.BT_CP_Temp_GridView.OptionsView.ShowAutoFilterRow = True
        Me.BT_CP_Temp_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.BT_CP_Temp_GridView.OptionsView.ShowFooter = True
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
        Me.colBusinesType1.Width = 356
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
        'colAmountBusinessType1
        '
        Me.colAmountBusinessType1.FieldName = "AmountBusinessType"
        Me.colAmountBusinessType1.Name = "colAmountBusinessType1"
        Me.colAmountBusinessType1.Width = 177
        '
        'colSQLBusinessTypeDetails1
        '
        Me.colSQLBusinessTypeDetails1.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colSQLBusinessTypeDetails1.FieldName = "SQLBusinessTypeDetails"
        Me.colSQLBusinessTypeDetails1.Name = "colSQLBusinessTypeDetails1"
        Me.colSQLBusinessTypeDetails1.Visible = True
        Me.colSQLBusinessTypeDetails1.VisibleIndex = 1
        Me.colSQLBusinessTypeDetails1.Width = 150
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
        Me.layoutViewField_colUNTERBEARBEITUNGVON.TextVisible = False
        '
        'LayoutViewCard2
        '
        Me.LayoutViewCard2.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
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
        Me.LayoutViewColumn48.LayoutViewField = Me.LayoutViewField23
        Me.LayoutViewColumn48.Name = "LayoutViewColumn48"
        '
        'LayoutViewField23
        '
        Me.LayoutViewField23.EditorPreferredWidth = 70
        Me.LayoutViewField23.ImageOptions.ImageIndex = 0
        Me.LayoutViewField23.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField23.Name = "LayoutViewField23"
        Me.LayoutViewField23.Size = New System.Drawing.Size(202, 20)
        Me.LayoutViewField23.TextSize = New System.Drawing.Size(123, 16)
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
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Root"
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1299, 645)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl2
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem1"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1279, 575)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1279, 50)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.Edit_INTERBANKV_Details_btn
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1079, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem2"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(176, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(150, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(929, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.Print_Export_BT_CP_Temp_Gridview_btn
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem4"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'BusinessTypeDateEdit
        '
        Me.BusinessTypeDateEdit.Location = New System.Drawing.Point(17, 28)
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
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        EditorButtonImageOptions1.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.BusinessTypeDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Reload", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.BusinessTypeDateEdit.Properties.DisplayFormat.FormatString = "d"
        Me.BusinessTypeDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BusinessTypeDateEdit.Properties.EditFormat.FormatString = "d"
        Me.BusinessTypeDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BusinessTypeDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.BusinessTypeDateEdit.Size = New System.Drawing.Size(190, 22)
        Me.BusinessTypeDateEdit.TabIndex = 20
        '
        'BusinessTypesLiabilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 741)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadBusinessTypes_btn)
        Me.Controls.Add(Me.BusinessTypeDateEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BusinessTypesLiabilities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Business Types - Liabilities"
        CType(Me.BT_CP_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessTypesLiabilitiesLiveBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskControllingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_CP_Totals_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.BusinessTypesLiabilitiesDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessTypesLiabilitiesAllDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_CP_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField47, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutViewField77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField78, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField79, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField80, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField81, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField83, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField84, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField85, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField86, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField87, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField88, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField89, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField90, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField91, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField92, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField93, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField94, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField95, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField96, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField97, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField98, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField99, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField100, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField101, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField102, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField103, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField104, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField105, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField107, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField108, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField109, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField110, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField112, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField113, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField114, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField115, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField116, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField117, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField118, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField119, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField120, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewField121, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.BT_CP_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BT_CP_DetailsAll_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BT_CP_GEN_PARAM_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BT_CP_Temp_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.BusinessTypeDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RiskControllingDataSet As PS_TOOL_DX.RiskControllingDataSet
    Friend WithEvents BusinessTypesLiabilitiesLiveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BusinessTypesLiabilitiesLiveTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesLiveTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.RiskControllingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BusinessTypesLiabilitiesDetailsTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesDetailsTableAdapter
    Friend WithEvents BusinessTypesLiabilitiesDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BusinessTypesLiabilitiesDetailsAllTableAdapter As PS_TOOL_DX.RiskControllingDataSetTableAdapters.BusinessTypesLiabilitiesDetailsAllTableAdapter
    Friend WithEvents BusinessTypesLiabilitiesAllDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadBusinessTypes_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents BT_CP_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SQL_Commands_Dropdownbutton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Print_Export_BT_CP_Totals_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BusinessTyperReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BT_CP_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BT_CP_Totals_GridView As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BT_CP_DetailsAll_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BT_CP_DetailsAll_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents LayoutView5 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn104 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField26 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn105 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField27 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn106 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField28 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn107 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField29 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn108 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField30 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn109 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField31 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn110 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField32 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn111 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField33 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn112 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField34 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn113 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField35 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn114 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField36 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn115 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField37 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn116 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField38 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn117 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField39 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn118 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField40 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn119 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField41 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn120 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField42 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn121 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField43 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn122 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField44 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn123 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField45 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn124 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField46 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn125 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField47 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn126 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField66 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn127 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField67 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn128 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField68 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn129 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField69 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn130 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField70 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn131 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField71 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn132 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField72 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn133 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField73 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn134 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField74 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn135 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField75 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn136 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField76 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn137 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField77 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn138 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField78 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn139 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField79 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn140 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField80 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn141 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField81 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn142 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField82 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn143 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField83 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn144 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField84 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn145 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField85 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn146 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField86 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn147 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField87 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn148 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField88 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn149 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField89 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn150 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField90 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn151 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField91 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn152 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField92 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn153 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField93 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn154 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField94 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn155 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField95 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn156 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField96 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents LayoutView6 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutView7 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewColumn157 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField97 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn158 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField98 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn159 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField99 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn160 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField100 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn161 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField101 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn162 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField102 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn163 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField103 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn164 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField104 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn165 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField105 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn166 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField106 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn167 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField107 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn168 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField108 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn169 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField109 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn170 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField110 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn171 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField111 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn172 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField112 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn173 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField113 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn174 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField114 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn175 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField115 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn176 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField116 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn177 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField117 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn178 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField118 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn179 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField119 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn180 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField120 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn181 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField121 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents DropDownButton1 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Print_Export_BT_CP_DetailsAll_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BusinessTypesLiabilitiesDetailsRep_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BT_CP_GEN_PARAM_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_BT_CP_Temp_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_INTERBANKV_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BT_CP_Temp_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinesType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colAmountBusinessType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessTypeDetails1 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinessTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgPrincipalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgInterestAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgTotalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchangeRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrincipalAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInterestAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalAmountEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBusinessTypeLiabilitiesLive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinesType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountBusinessTypePrincipalEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountBusinessTypeInterestEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountBusinessTypeTOTAL_EUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientsCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSQLBusinessType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateMakCrTotals As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinessTypeName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgPrincipalAmount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgInterestAmount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgTotalAmount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchangeRate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrincipalAmountEUR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInterestAmountEUR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalAmountEUR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBusinessTypeLiabilitiesLive1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colStartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStartDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BusinessTypeDateEdit As DevExpress.XtraEditors.ComboBoxEdit
End Class
