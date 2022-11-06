<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrencyRiskCalc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CurrencyRiskCalc))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains1 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains2 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains3 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim GridFormatRule6 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains4 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.colGeneral_Type_Unbund = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CR_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosition_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosition_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCounterpartyName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractColateralID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosition_Currency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosition_Amount_Orig = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosition_Amount_EUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdCurrencyRiskTotals = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.CurrencyRisk_PositionsTotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CurrencyRisk_DateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CurrencyRiskCalcDataSet = New PS_TOOL_DX.CurrencyRiskCalcDataSet()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CR_Totals_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCR_Position_Date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCR_CURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCR_LongPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCR_ShortPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCR_Difference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdCurrencyRiskDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSqlCommand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colSQLCommandShort = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.colGeneral_Type_Unbund1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.CurrencyRisk_PositionsAllDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CR_DetailsAll_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SQL_Run_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_ReRun_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_ReRun_AllDays_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SQL_BS_Run_BarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.CurrencyRisk_DateTableAdapter = New PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_DateTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.TableAdapterManager()
        Me.CurrencyRisk_PositionsAllDetailsTableAdapter = New PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsAllDetailsTableAdapter()
        Me.CurrencyRisk_PositionsDetailsTableAdapter = New PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsDetailsTableAdapter()
        Me.CurrencyRisk_PositionsTotalsTableAdapter = New PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsTotalsTableAdapter()
        Me.CurrencyRisk_PositionsDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadBusinessTypes_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CR_DateEdit_ComboEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.CAR_CALC_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.RiskCapitalCharge_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ShortPositionTOTAL_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LongPositionTOTAL_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CurrencyRiskValue_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.Print_Export_CRSA_Totals_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CurRisk_Calc_Report_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SQL_Commands_Dropdownbutton = New DevExpress.XtraEditors.DropDownButton()
        Me.CAR_CALC_Details_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.DropDownButton1 = New DevExpress.XtraEditors.DropDownButton()
        Me.Print_Export_All_DetailsAll_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CAR_PARAM_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_CAR_Parameters_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_INTERBANKV_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.CAR_Parameter_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCRSA_Position = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCRSA_Name_Position_DE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCRSA_Name_Position_GB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCRSA_Weighting_Factor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colCRSA_Position_SQL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colCRSA_MultipleFactor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIndivMultipleFactor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CurrencyRiskDate_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.CR_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRisk_PositionsTotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRisk_DateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRiskCalcDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CR_Totals_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRisk_PositionsAllDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CR_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRisk_PositionsDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CR_DateEdit_ComboEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.CAR_CALC_XtraTabPage.SuspendLayout()
        Me.CAR_CALC_Details_XtraTabPage.SuspendLayout()
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
        Me.CAR_PARAM_XtraTabPage.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAR_Parameter_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colGeneral_Type_Unbund
        '
        Me.colGeneral_Type_Unbund.Caption = "General Position"
        Me.colGeneral_Type_Unbund.FieldName = "colGeneral_Type_Unbund"
        Me.colGeneral_Type_Unbund.Name = "colGeneral_Type_Unbund"
        Me.colGeneral_Type_Unbund.OptionsColumn.AllowEdit = False
        Me.colGeneral_Type_Unbund.OptionsColumn.ReadOnly = True
        Me.colGeneral_Type_Unbund.UnboundExpression = resources.GetString("colGeneral_Type_Unbund.UnboundExpression")
        Me.colGeneral_Type_Unbund.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colGeneral_Type_Unbund.Visible = True
        Me.colGeneral_Type_Unbund.VisibleIndex = 7
        Me.colGeneral_Type_Unbund.Width = 143
        '
        'CR_Details_GridView
        '
        Me.CR_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CR_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CR_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CR_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CR_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CR_Details_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CR_Details_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CR_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colPosition_Type, Me.colPosition_Name, Me.colClientNr, Me.colCounterpartyName1, Me.colContractColateralID1, Me.colPosition_Currency, Me.colPosition_Amount_Orig, Me.colPosition_Amount_EUR, Me.colRiskDate1, Me.colIdCurrencyRiskTotals, Me.colGeneral_Type_Unbund})
        Me.CR_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Column = Me.colGeneral_Type_Unbund
        GridFormatRule1.ColumnApplyTo = Me.colGeneral_Type_Unbund
        GridFormatRule1.Name = "Activa"
        FormatConditionRuleContains1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains1.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains1.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains1.Values = CType(resources.GetObject("FormatConditionRuleContains1.Values"), System.Collections.IList)
        GridFormatRule1.Rule = FormatConditionRuleContains1
        GridFormatRule2.Column = Me.colGeneral_Type_Unbund
        GridFormatRule2.ColumnApplyTo = Me.colGeneral_Type_Unbund
        GridFormatRule2.Name = "Passiva"
        FormatConditionRuleContains2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains2.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains2.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains2.Values = CType(resources.GetObject("FormatConditionRuleContains2.Values"), System.Collections.IList)
        GridFormatRule2.Rule = FormatConditionRuleContains2
        Me.CR_Details_GridView.FormatRules.Add(GridFormatRule1)
        Me.CR_Details_GridView.FormatRules.Add(GridFormatRule2)
        Me.CR_Details_GridView.GridControl = Me.GridControl1
        Me.CR_Details_GridView.GroupCount = 1
        Me.CR_Details_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", Nothing, "Total Sum={0:n2}", 0R)})
        Me.CR_Details_GridView.Name = "CR_Details_GridView"
        Me.CR_Details_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CR_Details_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CR_Details_GridView.OptionsBehavior.ReadOnly = True
        Me.CR_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CR_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CR_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CR_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.CR_Details_GridView.OptionsSelection.MultiSelect = True
        Me.CR_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.CR_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CR_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.CR_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CR_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CR_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CR_Details_GridView.OptionsView.ShowFooter = True
        Me.CR_Details_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colGeneral_Type_Unbund, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.CR_Details_GridView.ViewCaption = "Currency Risk  Details"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colPosition_Type
        '
        Me.colPosition_Type.Caption = "Type"
        Me.colPosition_Type.FieldName = "Position_Type"
        Me.colPosition_Type.Name = "colPosition_Type"
        Me.colPosition_Type.OptionsColumn.AllowEdit = False
        Me.colPosition_Type.OptionsColumn.ReadOnly = True
        Me.colPosition_Type.Visible = True
        Me.colPosition_Type.VisibleIndex = 0
        Me.colPosition_Type.Width = 89
        '
        'colPosition_Name
        '
        Me.colPosition_Name.Caption = "Position Name"
        Me.colPosition_Name.FieldName = "Position_Name"
        Me.colPosition_Name.Name = "colPosition_Name"
        Me.colPosition_Name.OptionsColumn.AllowEdit = False
        Me.colPosition_Name.OptionsColumn.ReadOnly = True
        Me.colPosition_Name.Width = 318
        '
        'colClientNr
        '
        Me.colClientNr.FieldName = "ClientNr"
        Me.colClientNr.Name = "colClientNr"
        Me.colClientNr.OptionsColumn.AllowEdit = False
        Me.colClientNr.OptionsColumn.ReadOnly = True
        Me.colClientNr.Visible = True
        Me.colClientNr.VisibleIndex = 1
        Me.colClientNr.Width = 236
        '
        'colCounterpartyName1
        '
        Me.colCounterpartyName1.FieldName = "CounterpartyName"
        Me.colCounterpartyName1.Name = "colCounterpartyName1"
        Me.colCounterpartyName1.OptionsColumn.AllowEdit = False
        Me.colCounterpartyName1.OptionsColumn.ReadOnly = True
        Me.colCounterpartyName1.Visible = True
        Me.colCounterpartyName1.VisibleIndex = 2
        Me.colCounterpartyName1.Width = 322
        '
        'colContractColateralID1
        '
        Me.colContractColateralID1.FieldName = "ContractColateralID"
        Me.colContractColateralID1.Name = "colContractColateralID1"
        Me.colContractColateralID1.OptionsColumn.AllowEdit = False
        Me.colContractColateralID1.OptionsColumn.ReadOnly = True
        Me.colContractColateralID1.Visible = True
        Me.colContractColateralID1.VisibleIndex = 3
        Me.colContractColateralID1.Width = 176
        '
        'colPosition_Currency
        '
        Me.colPosition_Currency.Caption = "Currency"
        Me.colPosition_Currency.FieldName = "Position_Currency"
        Me.colPosition_Currency.Name = "colPosition_Currency"
        Me.colPosition_Currency.OptionsColumn.AllowEdit = False
        Me.colPosition_Currency.OptionsColumn.ReadOnly = True
        Me.colPosition_Currency.Visible = True
        Me.colPosition_Currency.VisibleIndex = 4
        Me.colPosition_Currency.Width = 101
        '
        'colPosition_Amount_Orig
        '
        Me.colPosition_Amount_Orig.AppearanceCell.Options.UseTextOptions = True
        Me.colPosition_Amount_Orig.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPosition_Amount_Orig.Caption = "Orig. Amount"
        Me.colPosition_Amount_Orig.DisplayFormat.FormatString = "n2"
        Me.colPosition_Amount_Orig.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPosition_Amount_Orig.FieldName = "Position_Amount_Orig"
        Me.colPosition_Amount_Orig.Name = "colPosition_Amount_Orig"
        Me.colPosition_Amount_Orig.OptionsColumn.AllowEdit = False
        Me.colPosition_Amount_Orig.OptionsColumn.ReadOnly = True
        Me.colPosition_Amount_Orig.Visible = True
        Me.colPosition_Amount_Orig.VisibleIndex = 5
        Me.colPosition_Amount_Orig.Width = 148
        '
        'colPosition_Amount_EUR
        '
        Me.colPosition_Amount_EUR.AppearanceCell.Options.UseTextOptions = True
        Me.colPosition_Amount_EUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPosition_Amount_EUR.Caption = "Amount (EUR)"
        Me.colPosition_Amount_EUR.DisplayFormat.FormatString = "n2"
        Me.colPosition_Amount_EUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPosition_Amount_EUR.FieldName = "Position_Amount_EUR"
        Me.colPosition_Amount_EUR.Name = "colPosition_Amount_EUR"
        Me.colPosition_Amount_EUR.OptionsColumn.AllowEdit = False
        Me.colPosition_Amount_EUR.OptionsColumn.ReadOnly = True
        Me.colPosition_Amount_EUR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", "Sum={0:n2}", 0)})
        Me.colPosition_Amount_EUR.Visible = True
        Me.colPosition_Amount_EUR.VisibleIndex = 6
        Me.colPosition_Amount_EUR.Width = 177
        '
        'colRiskDate1
        '
        Me.colRiskDate1.FieldName = "RiskDate"
        Me.colRiskDate1.Name = "colRiskDate1"
        Me.colRiskDate1.OptionsColumn.AllowEdit = False
        Me.colRiskDate1.OptionsColumn.ReadOnly = True
        '
        'colIdCurrencyRiskTotals
        '
        Me.colIdCurrencyRiskTotals.FieldName = "IdCurrencyRiskTotals"
        Me.colIdCurrencyRiskTotals.Name = "colIdCurrencyRiskTotals"
        Me.colIdCurrencyRiskTotals.OptionsColumn.AllowEdit = False
        Me.colIdCurrencyRiskTotals.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.CurrencyRisk_PositionsTotalsBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.ImageIndex = 5
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 6
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.CR_Details_GridView
        GridLevelNode1.RelationName = "FK_CurrencyRisk_PositionsDetails_CurrencyRisk_PositionsTotals"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 116)
        Me.GridControl1.MainView = Me.CR_Totals_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(1363, 504)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CR_Totals_GridView, Me.LayoutView1, Me.CR_Details_GridView})
        '
        'CurrencyRisk_PositionsTotalsBindingSource
        '
        Me.CurrencyRisk_PositionsTotalsBindingSource.DataMember = "FK_CurrencyRisk_PositionsTotals_CurrencyRisk_Date"
        Me.CurrencyRisk_PositionsTotalsBindingSource.DataSource = Me.CurrencyRisk_DateBindingSource
        '
        'CurrencyRisk_DateBindingSource
        '
        Me.CurrencyRisk_DateBindingSource.DataMember = "CurrencyRisk_Date"
        Me.CurrencyRisk_DateBindingSource.DataSource = Me.CurrencyRiskCalcDataSet
        '
        'CurrencyRiskCalcDataSet
        '
        Me.CurrencyRiskCalcDataSet.DataSetName = "CurrencyRiskCalcDataSet"
        Me.CurrencyRiskCalcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "SQL Runner.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "CrystalReport.ico")
        Me.ImageCollection1.InsertGalleryImage("pivot_16x16.png", "images/grid/pivot_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/pivot_16x16.png"), 4)
        Me.ImageCollection1.Images.SetKeyName(4, "pivot_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "save_16x16.png")
        '
        'CR_Totals_GridView
        '
        Me.CR_Totals_GridView.ActiveFilterString = "[CR_CURRENCY] <> 'EUR'"
        Me.CR_Totals_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CR_Totals_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CR_Totals_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CR_Totals_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CR_Totals_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CR_Totals_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colCR_Position_Date, Me.colCR_CURRENCY, Me.colCR_LongPosition, Me.colCR_ShortPosition, Me.colCR_Difference, Me.colIdCurrencyRiskDate, Me.colSqlCommand, Me.colSQLCommandShort})
        Me.CR_Totals_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule3.Column = Me.colCR_Difference
        GridFormatRule3.ColumnApplyTo = Me.colCR_Difference
        GridFormatRule3.Name = "Activa"
        FormatConditionRuleValue1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue1.Value1 = 0R
        GridFormatRule3.Rule = FormatConditionRuleValue1
        GridFormatRule4.Column = Me.colCR_Difference
        GridFormatRule4.ColumnApplyTo = Me.colCR_Difference
        GridFormatRule4.Name = "Passiva"
        FormatConditionRuleValue2.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual
        FormatConditionRuleValue2.Value1 = 0R
        GridFormatRule4.Rule = FormatConditionRuleValue2
        Me.CR_Totals_GridView.FormatRules.Add(GridFormatRule3)
        Me.CR_Totals_GridView.FormatRules.Add(GridFormatRule4)
        Me.CR_Totals_GridView.GridControl = Me.GridControl1
        Me.CR_Totals_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_LongPosition", Me.colCR_LongPosition, "Sum={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_ShortPosition", Me.colCR_ShortPosition, "Sum={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_Difference", Me.colCR_Difference, "Sum={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", Nothing, "Sum={0:n2}")})
        Me.CR_Totals_GridView.Name = "CR_Totals_GridView"
        Me.CR_Totals_GridView.NewItemRowText = "Add new Business Type"
        Me.CR_Totals_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CR_Totals_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CR_Totals_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CR_Totals_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CR_Totals_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CR_Totals_GridView.OptionsPrint.PrintDetails = True
        Me.CR_Totals_GridView.OptionsSelection.MultiSelect = True
        Me.CR_Totals_GridView.OptionsView.ColumnAutoWidth = False
        Me.CR_Totals_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CR_Totals_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.CR_Totals_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CR_Totals_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CR_Totals_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CR_Totals_GridView.OptionsView.ShowFooter = True
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colCR_Position_Date
        '
        Me.colCR_Position_Date.FieldName = "CR_Position_Date"
        Me.colCR_Position_Date.Name = "colCR_Position_Date"
        Me.colCR_Position_Date.OptionsColumn.AllowEdit = False
        Me.colCR_Position_Date.OptionsColumn.ReadOnly = True
        Me.colCR_Position_Date.Width = 125
        '
        'colCR_CURRENCY
        '
        Me.colCR_CURRENCY.Caption = "Currency"
        Me.colCR_CURRENCY.FieldName = "CR_CURRENCY"
        Me.colCR_CURRENCY.Name = "colCR_CURRENCY"
        Me.colCR_CURRENCY.OptionsColumn.AllowEdit = False
        Me.colCR_CURRENCY.OptionsColumn.ReadOnly = True
        Me.colCR_CURRENCY.Visible = True
        Me.colCR_CURRENCY.VisibleIndex = 0
        Me.colCR_CURRENCY.Width = 91
        '
        'colCR_LongPosition
        '
        Me.colCR_LongPosition.AppearanceCell.Options.UseTextOptions = True
        Me.colCR_LongPosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCR_LongPosition.Caption = "Long position"
        Me.colCR_LongPosition.DisplayFormat.FormatString = "n2"
        Me.colCR_LongPosition.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCR_LongPosition.FieldName = "CR_LongPosition"
        Me.colCR_LongPosition.Name = "colCR_LongPosition"
        Me.colCR_LongPosition.OptionsColumn.AllowEdit = False
        Me.colCR_LongPosition.OptionsColumn.ReadOnly = True
        Me.colCR_LongPosition.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_LongPosition", "Sum={0:n2}")})
        Me.colCR_LongPosition.Visible = True
        Me.colCR_LongPosition.VisibleIndex = 1
        Me.colCR_LongPosition.Width = 147
        '
        'colCR_ShortPosition
        '
        Me.colCR_ShortPosition.AppearanceCell.Options.UseTextOptions = True
        Me.colCR_ShortPosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCR_ShortPosition.Caption = "Short Position"
        Me.colCR_ShortPosition.DisplayFormat.FormatString = "n2"
        Me.colCR_ShortPosition.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCR_ShortPosition.FieldName = "CR_ShortPosition"
        Me.colCR_ShortPosition.Name = "colCR_ShortPosition"
        Me.colCR_ShortPosition.OptionsColumn.AllowEdit = False
        Me.colCR_ShortPosition.OptionsColumn.ReadOnly = True
        Me.colCR_ShortPosition.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_ShortPosition", "Sum={0:n2}")})
        Me.colCR_ShortPosition.Visible = True
        Me.colCR_ShortPosition.VisibleIndex = 2
        Me.colCR_ShortPosition.Width = 150
        '
        'colCR_Difference
        '
        Me.colCR_Difference.AppearanceCell.Options.UseTextOptions = True
        Me.colCR_Difference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colCR_Difference.Caption = "Difference"
        Me.colCR_Difference.DisplayFormat.FormatString = "n2"
        Me.colCR_Difference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCR_Difference.FieldName = "CR_Difference"
        Me.colCR_Difference.Name = "colCR_Difference"
        Me.colCR_Difference.OptionsColumn.AllowEdit = False
        Me.colCR_Difference.OptionsColumn.ReadOnly = True
        Me.colCR_Difference.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CR_Difference", "Sum={0:n2}")})
        Me.colCR_Difference.Visible = True
        Me.colCR_Difference.VisibleIndex = 3
        Me.colCR_Difference.Width = 129
        '
        'colIdCurrencyRiskDate
        '
        Me.colIdCurrencyRiskDate.FieldName = "IdCurrencyRiskDate"
        Me.colIdCurrencyRiskDate.Name = "colIdCurrencyRiskDate"
        Me.colIdCurrencyRiskDate.OptionsColumn.AllowEdit = False
        Me.colIdCurrencyRiskDate.OptionsColumn.ReadOnly = True
        '
        'colSqlCommand
        '
        Me.colSqlCommand.Caption = "SQL Command (LONG Posit.)"
        Me.colSqlCommand.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSqlCommand.FieldName = "CR_Sql_Command"
        Me.colSqlCommand.Name = "colSqlCommand"
        Me.colSqlCommand.Width = 111
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
        'colSQLCommandShort
        '
        Me.colSQLCommandShort.Caption = "SQL Command (SHORT Posit.)"
        Me.colSQLCommandShort.ColumnEdit = Me.RepositoryItemMemoExEdit2
        Me.colSQLCommandShort.FieldName = "CR_Sql_Command1"
        Me.colSQLCommandShort.Name = "colSQLCommandShort"
        Me.colSQLCommandShort.Width = 107
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
        'colGeneral_Type_Unbund1
        '
        Me.colGeneral_Type_Unbund1.Caption = "General Position"
        Me.colGeneral_Type_Unbund1.FieldName = "colGeneral_Type_Unbund1"
        Me.colGeneral_Type_Unbund1.Name = "colGeneral_Type_Unbund1"
        Me.colGeneral_Type_Unbund1.OptionsColumn.AllowEdit = False
        Me.colGeneral_Type_Unbund1.OptionsColumn.ReadOnly = True
        Me.colGeneral_Type_Unbund1.UnboundExpression = resources.GetString("colGeneral_Type_Unbund1.UnboundExpression")
        Me.colGeneral_Type_Unbund1.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.colGeneral_Type_Unbund1.Visible = True
        Me.colGeneral_Type_Unbund1.VisibleIndex = 0
        Me.colGeneral_Type_Unbund1.Width = 139
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
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.CurrencyRisk_PositionsAllDetailsBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(24, 50)
        Me.GridControl3.MainView = Me.CR_DetailsAll_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox3, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3})
        Me.GridControl3.Size = New System.Drawing.Size(1339, 549)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CR_DetailsAll_Gridview, Me.LayoutView5, Me.LayoutView6, Me.LayoutView7})
        '
        'CurrencyRisk_PositionsAllDetailsBindingSource
        '
        Me.CurrencyRisk_PositionsAllDetailsBindingSource.DataMember = "CurrencyRisk_PositionsAllDetails"
        Me.CurrencyRisk_PositionsAllDetailsBindingSource.DataSource = Me.CurrencyRiskCalcDataSet
        '
        'CR_DetailsAll_Gridview
        '
        Me.CR_DetailsAll_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CR_DetailsAll_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CR_DetailsAll_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CR_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CR_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CR_DetailsAll_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CR_DetailsAll_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.CR_DetailsAll_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.colGeneral_Type_Unbund1})
        Me.CR_DetailsAll_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule5.Column = Me.colGeneral_Type_Unbund1
        GridFormatRule5.ColumnApplyTo = Me.colGeneral_Type_Unbund1
        GridFormatRule5.Name = "Activa"
        FormatConditionRuleContains3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains3.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains3.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains3.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains3.Values = CType(resources.GetObject("FormatConditionRuleContains3.Values"), System.Collections.IList)
        GridFormatRule5.Rule = FormatConditionRuleContains3
        GridFormatRule6.Column = Me.colGeneral_Type_Unbund1
        GridFormatRule6.ColumnApplyTo = Me.colGeneral_Type_Unbund1
        GridFormatRule6.Name = "Passiva"
        FormatConditionRuleContains4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains4.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains4.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains4.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains4.Values = CType(resources.GetObject("FormatConditionRuleContains4.Values"), System.Collections.IList)
        GridFormatRule6.Rule = FormatConditionRuleContains4
        Me.CR_DetailsAll_Gridview.FormatRules.Add(GridFormatRule5)
        Me.CR_DetailsAll_Gridview.FormatRules.Add(GridFormatRule6)
        Me.CR_DetailsAll_Gridview.GridControl = Me.GridControl3
        Me.CR_DetailsAll_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", Nothing, "Sum={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", Me.GridColumn9, "Sum={0:n2}")})
        Me.CR_DetailsAll_Gridview.Name = "CR_DetailsAll_Gridview"
        Me.CR_DetailsAll_Gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CR_DetailsAll_Gridview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CR_DetailsAll_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.CR_DetailsAll_Gridview.OptionsBehavior.ReadOnly = True
        Me.CR_DetailsAll_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.CR_DetailsAll_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CR_DetailsAll_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CR_DetailsAll_Gridview.OptionsFind.AlwaysVisible = True
        Me.CR_DetailsAll_Gridview.OptionsMenu.ShowFooterItem = True
        Me.CR_DetailsAll_Gridview.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.CR_DetailsAll_Gridview.OptionsSelection.MultiSelect = True
        Me.CR_DetailsAll_Gridview.OptionsView.ColumnAutoWidth = False
        Me.CR_DetailsAll_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CR_DetailsAll_Gridview.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.CR_DetailsAll_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CR_DetailsAll_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.CR_DetailsAll_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CR_DetailsAll_Gridview.OptionsView.ShowFooter = True
        Me.CR_DetailsAll_Gridview.ViewCaption = "CRSA Position Details"
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
        Me.GridColumn2.Caption = "Type"
        Me.GridColumn2.FieldName = "Position_Type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 89
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Position Name"
        Me.GridColumn3.FieldName = "Position_Name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 318
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "ClientNr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 267
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "CounterpartyName"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 322
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "ContractColateralID"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 176
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Currency"
        Me.GridColumn7.FieldName = "Position_Currency"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 101
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Orig. Amount"
        Me.GridColumn8.DisplayFormat.FormatString = "n2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "Position_Amount_Orig"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_Orig", "Sum={0:n2}")})
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 148
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "Amount (EUR)"
        Me.GridColumn9.DisplayFormat.FormatString = "n2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "Position_Amount_EUR"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Position_Amount_EUR", "Sum={0:n2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 150
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "RiskDate"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        '
        'GridColumn11
        '
        Me.GridColumn11.FieldName = "IdCurrencyRiskTotals"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
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
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Images = Me.ImageCollection1
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SQL_Run_BarButtonItem, Me.SQL_ReRun_BarButtonItem, Me.SQL_ReRun_AllDays_BarButtonItem, Me.SQL_BS_Run_BarButtonItem})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 4
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
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
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
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
        Me.barDockControlTop.Size = New System.Drawing.Size(1417, 49)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 720)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1417, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 49)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 671)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1417, 49)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 671)
        '
        'SQL_Run_BarButtonItem
        '
        Me.SQL_Run_BarButtonItem.Caption = "Currency Risk re-calculation (based on FINRECON)"
        Me.SQL_Run_BarButtonItem.Id = 0
        Me.SQL_Run_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_Run_BarButtonItem.Name = "SQL_Run_BarButtonItem"
        '
        'SQL_ReRun_BarButtonItem
        '
        Me.SQL_ReRun_BarButtonItem.Caption = "Currency Risk re-calculation (Current Day)"
        Me.SQL_ReRun_BarButtonItem.Id = 1
        Me.SQL_ReRun_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_ReRun_BarButtonItem.Name = "SQL_ReRun_BarButtonItem"
        '
        'SQL_ReRun_AllDays_BarButtonItem
        '
        Me.SQL_ReRun_AllDays_BarButtonItem.Caption = "SQL Re-Run (All Days)"
        Me.SQL_ReRun_AllDays_BarButtonItem.Id = 2
        Me.SQL_ReRun_AllDays_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemAppearance.Normal.Options.UseForeColor = True
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemInMenuAppearance.Normal.ForeColor = System.Drawing.Color.Red
        Me.SQL_ReRun_AllDays_BarButtonItem.ItemInMenuAppearance.Normal.Options.UseForeColor = True
        Me.SQL_ReRun_AllDays_BarButtonItem.Name = "SQL_ReRun_AllDays_BarButtonItem"
        '
        'SQL_BS_Run_BarButtonItem
        '
        Me.SQL_BS_Run_BarButtonItem.Caption = "Currency Risk re-calculation (based on BALANCE SHEET)"
        Me.SQL_BS_Run_BarButtonItem.Id = 3
        Me.SQL_BS_Run_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_BS_Run_BarButtonItem.Name = "SQL_BS_Run_BarButtonItem"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_Run_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_BS_Run_BarButtonItem)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'CurrencyRisk_DateTableAdapter
        '
        Me.CurrencyRisk_DateTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CurrencyRisk_DateTableAdapter = Me.CurrencyRisk_DateTableAdapter
        Me.TableAdapterManager.CurrencyRisk_PositionsAllDetailsTableAdapter = Me.CurrencyRisk_PositionsAllDetailsTableAdapter
        Me.TableAdapterManager.CurrencyRisk_PositionsDetailsTableAdapter = Me.CurrencyRisk_PositionsDetailsTableAdapter
        Me.TableAdapterManager.CurrencyRisk_PositionsTotalsTableAdapter = Me.CurrencyRisk_PositionsTotalsTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CurrencyRisk_PositionsAllDetailsTableAdapter
        '
        Me.CurrencyRisk_PositionsAllDetailsTableAdapter.ClearBeforeFill = True
        '
        'CurrencyRisk_PositionsDetailsTableAdapter
        '
        Me.CurrencyRisk_PositionsDetailsTableAdapter.ClearBeforeFill = True
        '
        'CurrencyRisk_PositionsTotalsTableAdapter
        '
        Me.CurrencyRisk_PositionsTotalsTableAdapter.ClearBeforeFill = True
        '
        'CurrencyRisk_PositionsDetailsBindingSource
        '
        Me.CurrencyRisk_PositionsDetailsBindingSource.DataMember = "FK_CurrencyRisk_PositionsDetails_CurrencyRisk_PositionsTotals"
        Me.CurrencyRisk_PositionsDetailsBindingSource.DataSource = Me.CurrencyRisk_PositionsTotalsBindingSource
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(15, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 25
        Me.LabelControl1.Text = "Date"
        '
        'LoadBusinessTypes_btn
        '
        Me.LoadBusinessTypes_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadBusinessTypes_btn.ImageOptions.ImageIndex = 0
        Me.LoadBusinessTypes_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadBusinessTypes_btn.Location = New System.Drawing.Point(241, 27)
        Me.LoadBusinessTypes_btn.Name = "LoadBusinessTypes_btn"
        Me.LoadBusinessTypes_btn.Size = New System.Drawing.Size(97, 22)
        Me.LoadBusinessTypes_btn.TabIndex = 24
        Me.LoadBusinessTypes_btn.Text = "Load Data"
        Me.LoadBusinessTypes_btn.Visible = False
        '
        'CR_DateEdit_ComboEdit
        '
        Me.CR_DateEdit_ComboEdit.Location = New System.Drawing.Point(15, 27)
        Me.CR_DateEdit_ComboEdit.Name = "CR_DateEdit_ComboEdit"
        Me.CR_DateEdit_ComboEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CR_DateEdit_ComboEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CR_DateEdit_ComboEdit.Properties.Appearance.Options.UseFont = True
        Me.CR_DateEdit_ComboEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.CR_DateEdit_ComboEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.CR_DateEdit_ComboEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        EditorButtonImageOptions1.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.CR_DateEdit_ComboEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Reload", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.CR_DateEdit_ComboEdit.Properties.DisplayFormat.FormatString = "d"
        Me.CR_DateEdit_ComboEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CR_DateEdit_ComboEdit.Properties.EditFormat.FormatString = "d"
        Me.CR_DateEdit_ComboEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CR_DateEdit_ComboEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CR_DateEdit_ComboEdit.Size = New System.Drawing.Size(187, 22)
        Me.CR_DateEdit_ComboEdit.TabIndex = 23
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
        Me.XtraTabControl1.Location = New System.Drawing.Point(12, 55)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.CAR_CALC_XtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1393, 651)
        Me.XtraTabControl1.TabIndex = 26
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.CAR_CALC_XtraTabPage, Me.CAR_CALC_Details_XtraTabPage, Me.CAR_PARAM_XtraTabPage})
        '
        'CAR_CALC_XtraTabPage
        '
        Me.CAR_CALC_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_CALC_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.RiskCapitalCharge_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl4)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.ShortPositionTOTAL_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LongPositionTOTAL_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl3)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl2)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.CurrencyRiskValue_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl10)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.Print_Export_CRSA_Totals_Gridview_btn)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.CurRisk_Calc_Report_btn)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.SQL_Commands_Dropdownbutton)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.GridControl1)
        Me.CAR_CALC_XtraTabPage.Name = "CAR_CALC_XtraTabPage"
        Me.CAR_CALC_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_CALC_XtraTabPage.Size = New System.Drawing.Size(1387, 623)
        Me.CAR_CALC_XtraTabPage.Text = "CURRENCY RISK CALCULATION"
        '
        'RiskCapitalCharge_lbl
        '
        Me.RiskCapitalCharge_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.RiskCapitalCharge_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.RiskCapitalCharge_lbl.Appearance.Options.UseFont = True
        Me.RiskCapitalCharge_lbl.Appearance.Options.UseForeColor = True
        Me.RiskCapitalCharge_lbl.Appearance.Options.UseTextOptions = True
        Me.RiskCapitalCharge_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RiskCapitalCharge_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.RiskCapitalCharge_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CurrencyRisk_DateBindingSource, "RiskCapitalCharge", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.RiskCapitalCharge_lbl.Location = New System.Drawing.Point(439, 85)
        Me.RiskCapitalCharge_lbl.Name = "RiskCapitalCharge_lbl"
        Me.RiskCapitalCharge_lbl.Size = New System.Drawing.Size(189, 25)
        ToolTipTitleItem1.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem1.Appearance.Options.UseImage = True
        ToolTipTitleItem1.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem1.Text = "Risk Capital charge"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Parameter " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RISK CONTROLLING/CURRENCY RISK PERCENT"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.RiskCapitalCharge_lbl.SuperTip = SuperToolTip1
        Me.RiskCapitalCharge_lbl.TabIndex = 146
        Me.RiskCapitalCharge_lbl.Text = "0,00"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseTextOptions = True
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl4.LineVisible = True
        Me.LabelControl4.Location = New System.Drawing.Point(439, 62)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(189, 20)
        Me.LabelControl4.TabIndex = 145
        Me.LabelControl4.Text = "Risk Capital Charge"
        '
        'ShortPositionTOTAL_lbl
        '
        Me.ShortPositionTOTAL_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ShortPositionTOTAL_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ShortPositionTOTAL_lbl.Appearance.Options.UseFont = True
        Me.ShortPositionTOTAL_lbl.Appearance.Options.UseForeColor = True
        Me.ShortPositionTOTAL_lbl.Appearance.Options.UseTextOptions = True
        Me.ShortPositionTOTAL_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ShortPositionTOTAL_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.ShortPositionTOTAL_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CurrencyRisk_DateBindingSource, "SHORT_Position", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.ShortPositionTOTAL_lbl.Location = New System.Drawing.Point(217, 85)
        Me.ShortPositionTOTAL_lbl.Name = "ShortPositionTOTAL_lbl"
        Me.ShortPositionTOTAL_lbl.Size = New System.Drawing.Size(189, 25)
        ToolTipTitleItem2.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem2.Appearance.Options.UseImage = True
        ToolTipTitleItem2.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem2.Text = "Net Position (SHORT)"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "The Sum of all negative Differences between LONG and SHORT Position except EUR"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ShortPositionTOTAL_lbl.SuperTip = SuperToolTip2
        Me.ShortPositionTOTAL_lbl.TabIndex = 144
        Me.ShortPositionTOTAL_lbl.Text = "0,00"
        '
        'LongPositionTOTAL_lbl
        '
        Me.LongPositionTOTAL_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LongPositionTOTAL_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LongPositionTOTAL_lbl.Appearance.Options.UseFont = True
        Me.LongPositionTOTAL_lbl.Appearance.Options.UseForeColor = True
        Me.LongPositionTOTAL_lbl.Appearance.Options.UseTextOptions = True
        Me.LongPositionTOTAL_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LongPositionTOTAL_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LongPositionTOTAL_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CurrencyRisk_DateBindingSource, "LONG_Position", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.LongPositionTOTAL_lbl.Location = New System.Drawing.Point(12, 85)
        Me.LongPositionTOTAL_lbl.Name = "LongPositionTOTAL_lbl"
        Me.LongPositionTOTAL_lbl.Size = New System.Drawing.Size(189, 25)
        ToolTipTitleItem3.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem3.Appearance.Options.UseImage = True
        ToolTipTitleItem3.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem3.Text = "Net Position (LONG)"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "The Sum of all positive Differences between LONG and SHORT Position except EUR"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.LongPositionTOTAL_lbl.SuperTip = SuperToolTip3
        Me.LongPositionTOTAL_lbl.TabIndex = 143
        Me.LongPositionTOTAL_lbl.Text = "0,00"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseTextOptions = True
        Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl3.LineVisible = True
        Me.LabelControl3.Location = New System.Drawing.Point(217, 62)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(189, 20)
        Me.LabelControl3.TabIndex = 142
        Me.LabelControl3.Text = "Net Position (SHORT)"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl2.LineVisible = True
        Me.LabelControl2.Location = New System.Drawing.Point(12, 62)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(189, 20)
        Me.LabelControl2.TabIndex = 141
        Me.LabelControl2.Text = "Net Position (LONG)"
        '
        'CurrencyRiskValue_lbl
        '
        Me.CurrencyRiskValue_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencyRiskValue_lbl.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.CurrencyRiskValue_lbl.Appearance.Options.UseFont = True
        Me.CurrencyRiskValue_lbl.Appearance.Options.UseForeColor = True
        Me.CurrencyRiskValue_lbl.Appearance.Options.UseTextOptions = True
        Me.CurrencyRiskValue_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CurrencyRiskValue_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CurrencyRiskValue_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CurrencyRisk_DateBindingSource, "CurrencyRiskAmount", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.CurrencyRiskValue_lbl.Location = New System.Drawing.Point(653, 85)
        Me.CurrencyRiskValue_lbl.Name = "CurrencyRiskValue_lbl"
        Me.CurrencyRiskValue_lbl.Size = New System.Drawing.Size(243, 25)
        ToolTipTitleItem4.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem4.Appearance.Options.UseImage = True
        ToolTipTitleItem4.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem4.Text = "Currency Risk Amount"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Calculattion based on the maximum absolute Amount between LONG and SHORT Net Posi" &
    "tion multiplied by Risk Capital charge"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.CurrencyRiskValue_lbl.SuperTip = SuperToolTip4
        Me.CurrencyRiskValue_lbl.TabIndex = 140
        Me.CurrencyRiskValue_lbl.Text = "0,00"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Appearance.Options.UseTextOptions = True
        Me.LabelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl10.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl10.LineVisible = True
        Me.LabelControl10.Location = New System.Drawing.Point(653, 62)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(243, 20)
        Me.LabelControl10.TabIndex = 139
        Me.LabelControl10.Text = "Currency Risk Amount"
        '
        'Print_Export_CRSA_Totals_Gridview_btn
        '
        Me.Print_Export_CRSA_Totals_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_CRSA_Totals_Gridview_btn.ImageOptions.ImageIndex = 1
        Me.Print_Export_CRSA_Totals_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_CRSA_Totals_Gridview_btn.Location = New System.Drawing.Point(14, 15)
        Me.Print_Export_CRSA_Totals_Gridview_btn.Name = "Print_Export_CRSA_Totals_Gridview_btn"
        Me.Print_Export_CRSA_Totals_Gridview_btn.Size = New System.Drawing.Size(158, 22)
        Me.Print_Export_CRSA_Totals_Gridview_btn.TabIndex = 6
        Me.Print_Export_CRSA_Totals_Gridview_btn.Text = "Print or Export"
        '
        'CurRisk_Calc_Report_btn
        '
        Me.CurRisk_Calc_Report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CurRisk_Calc_Report_btn.ImageOptions.ImageIndex = 3
        Me.CurRisk_Calc_Report_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.CurRisk_Calc_Report_btn.Location = New System.Drawing.Point(184, 15)
        Me.CurRisk_Calc_Report_btn.Name = "CurRisk_Calc_Report_btn"
        Me.CurRisk_Calc_Report_btn.Size = New System.Drawing.Size(231, 22)
        Me.CurRisk_Calc_Report_btn.TabIndex = 5
        Me.CurRisk_Calc_Report_btn.Text = "Currency Risk Calculation Report"
        '
        'SQL_Commands_Dropdownbutton
        '
        Me.SQL_Commands_Dropdownbutton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.SQL_Commands_Dropdownbutton.DropDownControl = Me.PopupMenu1
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageIndex = 4
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageList = Me.ImageCollection1
        Me.SQL_Commands_Dropdownbutton.Location = New System.Drawing.Point(424, 15)
        Me.SQL_Commands_Dropdownbutton.Name = "SQL_Commands_Dropdownbutton"
        Me.SQL_Commands_Dropdownbutton.Size = New System.Drawing.Size(240, 22)
        Me.SQL_Commands_Dropdownbutton.TabIndex = 7
        Me.SQL_Commands_Dropdownbutton.Text = "Currency Risk calculation"
        '
        'CAR_CALC_Details_XtraTabPage
        '
        Me.CAR_CALC_Details_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_CALC_Details_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_CALC_Details_XtraTabPage.Controls.Add(Me.LayoutControl3)
        Me.CAR_CALC_Details_XtraTabPage.Name = "CAR_CALC_Details_XtraTabPage"
        Me.CAR_CALC_Details_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_CALC_Details_XtraTabPage.Size = New System.Drawing.Size(1387, 623)
        Me.CAR_CALC_Details_XtraTabPage.Text = "CURRENCY RISK - ALL DETAILS"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.GridControl3)
        Me.LayoutControl3.Controls.Add(Me.DropDownButton1)
        Me.LayoutControl3.Controls.Add(Me.Print_Export_All_DetailsAll_Gridview_btn)
        Me.LayoutControl3.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl3.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1387, 623)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.DropDownButton1.DropDownControl = Me.PopupMenu1
        Me.DropDownButton1.ImageOptions.ImageIndex = 2
        Me.DropDownButton1.ImageOptions.ImageList = Me.ImageCollection1
        Me.DropDownButton1.Location = New System.Drawing.Point(371, 24)
        Me.DropDownButton1.Name = "DropDownButton1"
        Me.DropDownButton1.Size = New System.Drawing.Size(218, 22)
        Me.DropDownButton1.StyleController = Me.LayoutControl3
        Me.DropDownButton1.TabIndex = 7
        Me.DropDownButton1.Text = "SQL Commands Run"
        '
        'Print_Export_All_DetailsAll_Gridview_btn
        '
        Me.Print_Export_All_DetailsAll_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_All_DetailsAll_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_All_DetailsAll_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_All_DetailsAll_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_All_DetailsAll_Gridview_btn.Name = "Print_Export_All_DetailsAll_Gridview_btn"
        Me.Print_Export_All_DetailsAll_Gridview_btn.Size = New System.Drawing.Size(157, 22)
        Me.Print_Export_All_DetailsAll_Gridview_btn.StyleController = Me.LayoutControl3
        Me.Print_Export_All_DetailsAll_Gridview_btn.TabIndex = 6
        Me.Print_Export_All_DetailsAll_Gridview_btn.Text = "Print or Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton2.ImageOptions.ImageIndex = 3
        Me.SimpleButton2.ImageOptions.ImageList = Me.ImageCollection1
        Me.SimpleButton2.Location = New System.Drawing.Point(185, 24)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(182, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl3
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Business Types Report"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton3.ImageOptions.ImageIndex = 5
        Me.SimpleButton3.Location = New System.Drawing.Point(1292, 24)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(71, 22)
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
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1387, 623)
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.EmptySpaceItem2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem9})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1367, 603)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButton3
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(1268, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem2"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(75, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(569, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(699, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.Print_Export_All_DetailsAll_Gridview_btn
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem4"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(161, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.DropDownButton1
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(347, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem7"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(222, 26)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        Me.LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.SimpleButton2
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(161, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem3"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(186, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        Me.LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridControl3
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1343, 553)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'CAR_PARAM_XtraTabPage
        '
        Me.CAR_PARAM_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_PARAM_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_PARAM_XtraTabPage.Controls.Add(Me.LayoutControl2)
        Me.CAR_PARAM_XtraTabPage.Name = "CAR_PARAM_XtraTabPage"
        Me.CAR_PARAM_XtraTabPage.PageVisible = False
        Me.CAR_PARAM_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_PARAM_XtraTabPage.Size = New System.Drawing.Size(1387, 623)
        Me.CAR_PARAM_XtraTabPage.Text = "CAR CALCULATION PARAMETERS"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.Print_Export_CAR_Parameters_Gridview_btn)
        Me.LayoutControl2.Controls.Add(Me.Edit_INTERBANKV_Details_btn)
        Me.LayoutControl2.Controls.Add(Me.GridControl2)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(550, 102, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(1387, 623)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Print_Export_CAR_Parameters_Gridview_btn
        '
        Me.Print_Export_CAR_Parameters_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_CAR_Parameters_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_CAR_Parameters_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_CAR_Parameters_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_CAR_Parameters_Gridview_btn.Name = "Print_Export_CAR_Parameters_Gridview_btn"
        Me.Print_Export_CAR_Parameters_Gridview_btn.Size = New System.Drawing.Size(157, 22)
        Me.Print_Export_CAR_Parameters_Gridview_btn.StyleController = Me.LayoutControl2
        Me.Print_Export_CAR_Parameters_Gridview_btn.TabIndex = 6
        Me.Print_Export_CAR_Parameters_Gridview_btn.Text = "Print or Export"
        '
        'Edit_INTERBANKV_Details_btn
        '
        Me.Edit_INTERBANKV_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_INTERBANKV_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_INTERBANKV_Details_btn.Location = New System.Drawing.Point(1179, 24)
        Me.Edit_INTERBANKV_Details_btn.Name = "Edit_INTERBANKV_Details_btn"
        Me.Edit_INTERBANKV_Details_btn.Size = New System.Drawing.Size(184, 22)
        Me.Edit_INTERBANKV_Details_btn.StyleController = Me.LayoutControl2
        Me.Edit_INTERBANKV_Details_btn.TabIndex = 4
        Me.Edit_INTERBANKV_Details_btn.Text = "Show Details"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.Location = New System.Drawing.Point(12, 62)
        Me.GridControl2.MainView = Me.CAR_Parameter_GridView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox2, Me.RepositoryItemTextEdit4, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemSpinEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(1363, 549)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CAR_Parameter_GridView})
        '
        'CAR_Parameter_GridView
        '
        Me.CAR_Parameter_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CAR_Parameter_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CAR_Parameter_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CAR_Parameter_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CAR_Parameter_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CAR_Parameter_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCRSA_Position, Me.colCRSA_Name_Position_DE, Me.colCRSA_Name_Position_GB, Me.colCRSA_Weighting_Factor, Me.colCRSA_Position_SQL, Me.colCRSA_MultipleFactor, Me.colIndivMultipleFactor})
        Me.CAR_Parameter_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CAR_Parameter_GridView.GridControl = Me.GridControl2
        Me.CAR_Parameter_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Principal Amount/Value Balance(EUR Equ)", Nothing, "{0:n2}")})
        Me.CAR_Parameter_GridView.Name = "CAR_Parameter_GridView"
        Me.CAR_Parameter_GridView.NewItemRowText = "Add new CRSA Parameter"
        Me.CAR_Parameter_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CAR_Parameter_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CAR_Parameter_GridView.OptionsCustomization.AllowRowSizing = True
        Me.CAR_Parameter_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.CAR_Parameter_GridView.OptionsFind.AlwaysVisible = True
        Me.CAR_Parameter_GridView.OptionsSelection.MultiSelect = True
        Me.CAR_Parameter_GridView.OptionsView.ColumnAutoWidth = False
        Me.CAR_Parameter_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CAR_Parameter_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CAR_Parameter_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.CAR_Parameter_GridView.OptionsView.ShowAutoFilterRow = True
        Me.CAR_Parameter_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CAR_Parameter_GridView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colCRSA_Position
        '
        Me.colCRSA_Position.Caption = "CRSA Position"
        Me.colCRSA_Position.FieldName = "CRSA_Position"
        Me.colCRSA_Position.Name = "colCRSA_Position"
        Me.colCRSA_Position.Visible = True
        Me.colCRSA_Position.VisibleIndex = 0
        Me.colCRSA_Position.Width = 295
        '
        'colCRSA_Name_Position_DE
        '
        Me.colCRSA_Name_Position_DE.Caption = "CRSA Name (DE)"
        Me.colCRSA_Name_Position_DE.FieldName = "CRSA_Name_Position_DE"
        Me.colCRSA_Name_Position_DE.Name = "colCRSA_Name_Position_DE"
        Me.colCRSA_Name_Position_DE.Visible = True
        Me.colCRSA_Name_Position_DE.VisibleIndex = 2
        Me.colCRSA_Name_Position_DE.Width = 315
        '
        'colCRSA_Name_Position_GB
        '
        Me.colCRSA_Name_Position_GB.Caption = "CRSA Name (GB)"
        Me.colCRSA_Name_Position_GB.FieldName = "CRSA_Name_Position_GB"
        Me.colCRSA_Name_Position_GB.Name = "colCRSA_Name_Position_GB"
        Me.colCRSA_Name_Position_GB.Visible = True
        Me.colCRSA_Name_Position_GB.VisibleIndex = 3
        Me.colCRSA_Name_Position_GB.Width = 295
        '
        'colCRSA_Weighting_Factor
        '
        Me.colCRSA_Weighting_Factor.AppearanceCell.Options.UseTextOptions = True
        Me.colCRSA_Weighting_Factor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCRSA_Weighting_Factor.Caption = "CRSA Weighting Factor"
        Me.colCRSA_Weighting_Factor.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colCRSA_Weighting_Factor.DisplayFormat.FormatString = "p2"
        Me.colCRSA_Weighting_Factor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCRSA_Weighting_Factor.FieldName = "CRSA_Weighting_Factor"
        Me.colCRSA_Weighting_Factor.Name = "colCRSA_Weighting_Factor"
        Me.colCRSA_Weighting_Factor.Visible = True
        Me.colCRSA_Weighting_Factor.VisibleIndex = 4
        Me.colCRSA_Weighting_Factor.Width = 89
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepositoryItemSpinEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemSpinEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.EditFormat.FormatString = "n2"
        Me.RepositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "n2"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'colCRSA_Position_SQL
        '
        Me.colCRSA_Position_SQL.Caption = "CRSA Position SQL Command"
        Me.colCRSA_Position_SQL.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colCRSA_Position_SQL.FieldName = "CRSA_Position_SQL"
        Me.colCRSA_Position_SQL.Name = "colCRSA_Position_SQL"
        Me.colCRSA_Position_SQL.Visible = True
        Me.colCRSA_Position_SQL.VisibleIndex = 6
        Me.colCRSA_Position_SQL.Width = 108
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
        'colCRSA_MultipleFactor
        '
        Me.colCRSA_MultipleFactor.AppearanceCell.Options.UseTextOptions = True
        Me.colCRSA_MultipleFactor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCRSA_MultipleFactor.Caption = "CRSA Multiply Factor"
        Me.colCRSA_MultipleFactor.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colCRSA_MultipleFactor.DisplayFormat.FormatString = "p2"
        Me.colCRSA_MultipleFactor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCRSA_MultipleFactor.FieldName = "CRSA_MultipleFactor"
        Me.colCRSA_MultipleFactor.Name = "colCRSA_MultipleFactor"
        Me.colCRSA_MultipleFactor.Visible = True
        Me.colCRSA_MultipleFactor.VisibleIndex = 5
        '
        'colIndivMultipleFactor
        '
        Me.colIndivMultipleFactor.AppearanceCell.Options.UseTextOptions = True
        Me.colIndivMultipleFactor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIndivMultipleFactor.Caption = "Indiv. Multiply Factor"
        Me.colIndivMultipleFactor.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colIndivMultipleFactor.FieldName = "Indiv_MultipleFactor"
        Me.colIndivMultipleFactor.Name = "colIndivMultipleFactor"
        Me.colIndivMultipleFactor.Visible = True
        Me.colIndivMultipleFactor.VisibleIndex = 1
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
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Root"
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1387, 623)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl2
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem1"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1367, 553)
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
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1367, 50)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.Edit_INTERBANKV_Details_btn
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1155, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem2"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(188, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(161, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(994, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.Print_Export_CAR_Parameters_Gridview_btn
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem4"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(161, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'CurrencyRiskDate_lbl
        '
        Me.CurrencyRiskDate_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencyRiskDate_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CurrencyRiskDate_lbl.Appearance.Options.UseFont = True
        Me.CurrencyRiskDate_lbl.Appearance.Options.UseForeColor = True
        Me.CurrencyRiskDate_lbl.Appearance.Options.UseTextOptions = True
        Me.CurrencyRiskDate_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CurrencyRiskDate_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CurrencyRiskDate_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CurrencyRisk_DateBindingSource, "CR_Date", True))
        Me.CurrencyRiskDate_lbl.Location = New System.Drawing.Point(682, 23)
        Me.CurrencyRiskDate_lbl.Name = "CurrencyRiskDate_lbl"
        Me.CurrencyRiskDate_lbl.Size = New System.Drawing.Size(130, 25)
        Me.CurrencyRiskDate_lbl.TabIndex = 142
        Me.CurrencyRiskDate_lbl.Text = "RiskDate"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Appearance.Options.UseTextOptions = True
        Me.LabelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl6.Location = New System.Drawing.Point(575, 26)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(104, 20)
        Me.LabelControl6.TabIndex = 141
        Me.LabelControl6.Text = "Risk Date"
        '
        'CurrencyRiskCalc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1417, 743)
        Me.Controls.Add(Me.CurrencyRiskDate_lbl)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadBusinessTypes_btn)
        Me.Controls.Add(Me.CR_DateEdit_ComboEdit)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CurrencyRiskCalc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Currency Risk Calculation"
        CType(Me.CR_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRisk_PositionsTotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRisk_DateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRiskCalcDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CR_Totals_GridView, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRisk_PositionsAllDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CR_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRisk_PositionsDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CR_DateEdit_ComboEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.CAR_CALC_XtraTabPage.ResumeLayout(False)
        Me.CAR_CALC_Details_XtraTabPage.ResumeLayout(False)
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
        Me.CAR_PARAM_XtraTabPage.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAR_Parameter_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents SQL_BS_Run_BarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents CurrencyRisk_DateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CurrencyRiskCalcDataSet As PS_TOOL_DX.CurrencyRiskCalcDataSet
    Friend WithEvents CurrencyRisk_DateTableAdapter As PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_DateTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CurrencyRisk_PositionsTotalsTableAdapter As PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsTotalsTableAdapter
    Friend WithEvents CurrencyRisk_PositionsTotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CurrencyRisk_PositionsDetailsTableAdapter As PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsDetailsTableAdapter
    Friend WithEvents CurrencyRisk_PositionsDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CurrencyRisk_PositionsAllDetailsTableAdapter As PS_TOOL_DX.CurrencyRiskCalcDataSetTableAdapters.CurrencyRisk_PositionsAllDetailsTableAdapter
    Friend WithEvents CurrencyRisk_PositionsAllDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadBusinessTypes_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CR_DateEdit_ComboEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents CAR_CALC_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CurrencyRiskValue_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Print_Export_CRSA_Totals_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CurRisk_Calc_Report_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SQL_Commands_Dropdownbutton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CR_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CR_Totals_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
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
    Friend WithEvents CAR_CALC_Details_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CR_DetailsAll_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents Print_Export_All_DetailsAll_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CAR_PARAM_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_CAR_Parameters_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_INTERBANKV_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CAR_Parameter_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCRSA_Position As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCRSA_Name_Position_DE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCRSA_Name_Position_GB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCRSA_Weighting_Factor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colCRSA_Position_SQL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colCRSA_MultipleFactor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIndivMultipleFactor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosition_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosition_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCounterpartyName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractColateralID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosition_Currency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosition_Amount_Orig As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosition_Amount_EUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdCurrencyRiskTotals As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_Position_Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_CURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_LongPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_ShortPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_Difference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdCurrencyRiskDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrencyRiskDate_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSqlCommand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colSQLCommandShort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ShortPositionTOTAL_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LongPositionTOTAL_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RiskCapitalCharge_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colGeneral_Type_Unbund As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGeneral_Type_Unbund1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
