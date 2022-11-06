<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiqV_Calc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LiqV_Calc))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression1 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression2 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression3 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression4 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression5 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule6 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression6 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim GridFormatRule7 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression7 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
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
        Me.LiqV_Details_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZeilenNr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZahlungsart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBusinessType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractCollateralID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEventDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFactor1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLaufzeitband = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaturityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrgCcyAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colId_LiqV_Totals = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnrechnungsBetrag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountEurWithoutInterest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.LiqV_Details_TotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LiqV_Dataset = New PS_TOOL_DX.LiqV_Dataset()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LiqV_Totals_BandedGridView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
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
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.LiqV_Details_All1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LiqV_DetailsAll_Gridview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupName2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZeilenNr2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountEurWithoutInterest1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFactor2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnrechnungsBetrag1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colId_LiqV_Totals1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRiskDate2 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.PrintableComponentLink3 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.LiquidityCalculation_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.LayoutViewField1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn91 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn92 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn93 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn94 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn95 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn96 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn97 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn98 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn99 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField10 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn100 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField11 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn96 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn97 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn98 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn99 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn100 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn101 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn102 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn103 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn104 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn105 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn106 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn107 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn108 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn109 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn110 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn111 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn112 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn113 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn114 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn115 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn116 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn117 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn118 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn119 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn120 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn121 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn122 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn123 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn124 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn125 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn126 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn127 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LoadBusinessTypes_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LiqV_DateEdit_ComboEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.CAR_CALC_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.LiqV_Value_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.CapitalSurplus_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.MaxLendingLimit_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.MultipleFactor_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.CapitalForSolvV_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Print_Export_LiqV_Totals_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CAR_Calc_Report_btn = New DevExpress.XtraEditors.SimpleButton()
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Load_LiqV_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LiqV_Date_Comboedit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LiqV_Details_TotalsTableAdapter = New PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_TotalsTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.LiqV_DatasetTableAdapters.TableAdapterManager()
        Me.LiqV_Details_All1TableAdapter = New PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_All1TableAdapter()
        Me.LiqV_Details_AllTableAdapter = New PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_AllTableAdapter()
        Me.LiqV_Details_AllBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.LiqV_Details_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_Details_TotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_Dataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_Totals_BandedGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LiqV_Details_All1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiquidityCalculation_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_DateEdit_ComboEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LiqV_Date_Comboedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LiqV_Details_AllBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LiqV_Details_GridView
        '
        Me.LiqV_Details_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.LiqV_Details_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.LiqV_Details_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.LiqV_Details_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.LiqV_Details_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.LiqV_Details_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.LiqV_Details_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.LiqV_Details_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colZeilenNr1, Me.colGroupName1, Me.colZahlungsart, Me.colBusinessType, Me.colClientNo, Me.colContractCollateralID, Me.colContractType, Me.GridColumn1, Me.colProductType, Me.colEventDate, Me.colFactor1, Me.colDays, Me.colLaufzeitband, Me.colMaturityDate, Me.colOrgCcy, Me.colOrgCcyAmount, Me.colRiskDate1, Me.colId_LiqV_Totals, Me.colAnrechnungsBetrag, Me.colAmountEurWithoutInterest})
        Me.LiqV_Details_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.LiqV_Details_GridView.GridControl = Me.GridControl1
        Me.LiqV_Details_GridView.Name = "LiqV_Details_GridView"
        Me.LiqV_Details_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.LiqV_Details_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.LiqV_Details_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.LiqV_Details_GridView.OptionsBehavior.ReadOnly = True
        Me.LiqV_Details_GridView.OptionsCustomization.AllowRowSizing = True
        Me.LiqV_Details_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.LiqV_Details_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.LiqV_Details_GridView.OptionsFind.AlwaysVisible = True
        Me.LiqV_Details_GridView.OptionsSelection.MultiSelect = True
        Me.LiqV_Details_GridView.OptionsView.ColumnAutoWidth = False
        Me.LiqV_Details_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_Details_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.LiqV_Details_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.LiqV_Details_GridView.OptionsView.ShowAutoFilterRow = True
        Me.LiqV_Details_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.LiqV_Details_GridView.OptionsView.ShowFooter = True
        Me.LiqV_Details_GridView.ViewCaption = "Liquidity Ratio Calculation Details"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colZeilenNr1
        '
        Me.colZeilenNr1.FieldName = "ZeilenNr"
        Me.colZeilenNr1.Name = "colZeilenNr1"
        Me.colZeilenNr1.OptionsColumn.AllowEdit = False
        Me.colZeilenNr1.OptionsColumn.ReadOnly = True
        Me.colZeilenNr1.Visible = True
        Me.colZeilenNr1.VisibleIndex = 0
        '
        'colGroupName1
        '
        Me.colGroupName1.FieldName = "GroupName"
        Me.colGroupName1.Name = "colGroupName1"
        Me.colGroupName1.OptionsColumn.AllowEdit = False
        Me.colGroupName1.OptionsColumn.ReadOnly = True
        '
        'colZahlungsart
        '
        Me.colZahlungsart.FieldName = "Zahlungsart"
        Me.colZahlungsart.Name = "colZahlungsart"
        Me.colZahlungsart.OptionsColumn.AllowEdit = False
        Me.colZahlungsart.OptionsColumn.ReadOnly = True
        Me.colZahlungsart.Visible = True
        Me.colZahlungsart.VisibleIndex = 1
        Me.colZahlungsart.Width = 342
        '
        'colBusinessType
        '
        Me.colBusinessType.FieldName = "BusinessType"
        Me.colBusinessType.Name = "colBusinessType"
        Me.colBusinessType.OptionsColumn.AllowEdit = False
        Me.colBusinessType.OptionsColumn.ReadOnly = True
        Me.colBusinessType.Visible = True
        Me.colBusinessType.VisibleIndex = 2
        Me.colBusinessType.Width = 409
        '
        'colClientNo
        '
        Me.colClientNo.FieldName = "Client No"
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.VisibleIndex = 3
        '
        'colContractCollateralID
        '
        Me.colContractCollateralID.FieldName = "Contract Collateral ID"
        Me.colContractCollateralID.Name = "colContractCollateralID"
        Me.colContractCollateralID.OptionsColumn.AllowEdit = False
        Me.colContractCollateralID.OptionsColumn.ReadOnly = True
        Me.colContractCollateralID.Visible = True
        Me.colContractCollateralID.VisibleIndex = 5
        Me.colContractCollateralID.Width = 162
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Visible = True
        Me.colContractType.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "Counterparty/Issuer/Collateral Provider"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 352
        '
        'colProductType
        '
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.OptionsColumn.AllowEdit = False
        Me.colProductType.OptionsColumn.ReadOnly = True
        Me.colProductType.Visible = True
        Me.colProductType.VisibleIndex = 7
        '
        'colEventDate
        '
        Me.colEventDate.FieldName = "Event Date"
        Me.colEventDate.Name = "colEventDate"
        Me.colEventDate.OptionsColumn.AllowEdit = False
        Me.colEventDate.OptionsColumn.ReadOnly = True
        Me.colEventDate.Visible = True
        Me.colEventDate.VisibleIndex = 8
        '
        'colFactor1
        '
        Me.colFactor1.DisplayFormat.FormatString = "p0"
        Me.colFactor1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colFactor1.FieldName = "Factor"
        Me.colFactor1.Name = "colFactor1"
        Me.colFactor1.OptionsColumn.AllowEdit = False
        Me.colFactor1.OptionsColumn.ReadOnly = True
        Me.colFactor1.Visible = True
        Me.colFactor1.VisibleIndex = 15
        '
        'colDays
        '
        Me.colDays.FieldName = "Days"
        Me.colDays.Name = "colDays"
        Me.colDays.OptionsColumn.AllowEdit = False
        Me.colDays.OptionsColumn.ReadOnly = True
        Me.colDays.Visible = True
        Me.colDays.VisibleIndex = 10
        '
        'colLaufzeitband
        '
        Me.colLaufzeitband.FieldName = "Laufzeitband"
        Me.colLaufzeitband.Name = "colLaufzeitband"
        Me.colLaufzeitband.OptionsColumn.AllowEdit = False
        Me.colLaufzeitband.OptionsColumn.ReadOnly = True
        Me.colLaufzeitband.Visible = True
        Me.colLaufzeitband.VisibleIndex = 11
        Me.colLaufzeitband.Width = 95
        '
        'colMaturityDate
        '
        Me.colMaturityDate.FieldName = "Maturity Date"
        Me.colMaturityDate.Name = "colMaturityDate"
        Me.colMaturityDate.OptionsColumn.AllowEdit = False
        Me.colMaturityDate.OptionsColumn.ReadOnly = True
        Me.colMaturityDate.Visible = True
        Me.colMaturityDate.VisibleIndex = 9
        '
        'colOrgCcy
        '
        Me.colOrgCcy.FieldName = "Org Ccy"
        Me.colOrgCcy.Name = "colOrgCcy"
        Me.colOrgCcy.OptionsColumn.AllowEdit = False
        Me.colOrgCcy.OptionsColumn.ReadOnly = True
        Me.colOrgCcy.Visible = True
        Me.colOrgCcy.VisibleIndex = 12
        '
        'colOrgCcyAmount
        '
        Me.colOrgCcyAmount.DisplayFormat.FormatString = "n2"
        Me.colOrgCcyAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colOrgCcyAmount.FieldName = "OrgCcyAmount"
        Me.colOrgCcyAmount.Name = "colOrgCcyAmount"
        Me.colOrgCcyAmount.OptionsColumn.AllowEdit = False
        Me.colOrgCcyAmount.OptionsColumn.ReadOnly = True
        Me.colOrgCcyAmount.Visible = True
        Me.colOrgCcyAmount.VisibleIndex = 13
        '
        'colRiskDate1
        '
        Me.colRiskDate1.FieldName = "RiskDate"
        Me.colRiskDate1.Name = "colRiskDate1"
        Me.colRiskDate1.OptionsColumn.AllowEdit = False
        Me.colRiskDate1.OptionsColumn.ReadOnly = True
        '
        'colId_LiqV_Totals
        '
        Me.colId_LiqV_Totals.FieldName = "Id_LiqV_Totals"
        Me.colId_LiqV_Totals.Name = "colId_LiqV_Totals"
        Me.colId_LiqV_Totals.OptionsColumn.AllowEdit = False
        Me.colId_LiqV_Totals.OptionsColumn.ReadOnly = True
        '
        'colAnrechnungsBetrag
        '
        Me.colAnrechnungsBetrag.DisplayFormat.FormatString = "n2"
        Me.colAnrechnungsBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAnrechnungsBetrag.FieldName = "AnrechnungsBetrag"
        Me.colAnrechnungsBetrag.Name = "colAnrechnungsBetrag"
        Me.colAnrechnungsBetrag.OptionsColumn.AllowEdit = False
        Me.colAnrechnungsBetrag.OptionsColumn.ReadOnly = True
        Me.colAnrechnungsBetrag.Visible = True
        Me.colAnrechnungsBetrag.VisibleIndex = 16
        Me.colAnrechnungsBetrag.Width = 104
        '
        'colAmountEurWithoutInterest
        '
        Me.colAmountEurWithoutInterest.DisplayFormat.FormatString = "n2"
        Me.colAmountEurWithoutInterest.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountEurWithoutInterest.FieldName = "AmountEurWithoutInterest"
        Me.colAmountEurWithoutInterest.Name = "colAmountEurWithoutInterest"
        Me.colAmountEurWithoutInterest.OptionsColumn.AllowEdit = False
        Me.colAmountEurWithoutInterest.OptionsColumn.ReadOnly = True
        Me.colAmountEurWithoutInterest.Visible = True
        Me.colAmountEurWithoutInterest.VisibleIndex = 14
        Me.colAmountEurWithoutInterest.Width = 107
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.LiqV_Details_TotalsBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.ImageIndex = 5
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 6
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.LiqV_Details_GridView
        GridLevelNode1.RelationName = "FK_LiqV_Details_All_LiqV_Details_Totals"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 102)
        Me.GridControl1.MainView = Me.LiqV_Totals_BandedGridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.RepositoryItemMemoEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1454, 536)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LiqV_Totals_BandedGridView, Me.LayoutView1, Me.LiqV_Details_GridView})
        '
        'LiqV_Details_TotalsBindingSource
        '
        Me.LiqV_Details_TotalsBindingSource.DataMember = "LiqV_Details_Totals"
        Me.LiqV_Details_TotalsBindingSource.DataSource = Me.LiqV_Dataset
        '
        'LiqV_Dataset
        '
        Me.LiqV_Dataset.DataSetName = "LiqV_Dataset"
        Me.LiqV_Dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.ImageCollection1.InsertGalleryImage("exporttoxlsx_16x16.png", "images/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxlsx_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "exporttoxlsx_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("boresume_16x16.png", "images/business%20objects/boresume_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boresume_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "boresume_16x16.png")
        '
        'LiqV_Totals_BandedGridView
        '
        Me.LiqV_Totals_BandedGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.LiqV_Totals_BandedGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.LiqV_Totals_BandedGridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.LiqV_Totals_BandedGridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.LiqV_Totals_BandedGridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.LiqV_Totals_BandedGridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.LiqV_Totals_BandedGridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.LiqV_Totals_BandedGridView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5})
        Me.LiqV_Totals_BandedGridView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11})
        Me.LiqV_Totals_BandedGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.BandedGridColumn3
        GridFormatRule1.ColumnApplyTo = Me.BandedGridColumn3
        GridFormatRule1.Name = "SumRows"
        FormatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleExpression1.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression1.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression1.Expression = "[ZeilenNr] Like '%0'"
        GridFormatRule1.Rule = FormatConditionRuleExpression1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.BandedGridColumn4
        GridFormatRule2.ColumnApplyTo = Me.BandedGridColumn4
        GridFormatRule2.Name = "TotalSumsRows"
        FormatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleExpression2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleExpression2.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression2.Appearance.Options.UseFont = True
        FormatConditionRuleExpression2.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression2.Expression = "[ZeilenNr] In ('200', '400')"
        GridFormatRule2.Rule = FormatConditionRuleExpression2
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Column = Me.BandedGridColumn3
        GridFormatRule3.ColumnApplyTo = Me.BandedGridColumn3
        GridFormatRule3.Name = "SumsBerechnungen"
        FormatConditionRuleExpression3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleExpression3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleExpression3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression3.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleExpression3.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression3.Appearance.Options.UseFont = True
        FormatConditionRuleExpression3.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression3.Expression = "[ZeilenNr] Like '%b'"
        GridFormatRule3.Rule = FormatConditionRuleExpression3
        GridFormatRule4.Column = Me.BandedGridColumn3
        GridFormatRule4.ColumnApplyTo = Me.BandedGridColumn7
        GridFormatRule4.Name = "LiqV_Ratio"
        FormatConditionRuleExpression4.Appearance.BackColor = System.Drawing.Color.Navy
        FormatConditionRuleExpression4.Appearance.BackColor2 = System.Drawing.Color.Navy
        FormatConditionRuleExpression4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression4.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleExpression4.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression4.Appearance.Options.UseFont = True
        FormatConditionRuleExpression4.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression4.Expression = "[ZeilenNr] In ('350b')"
        GridFormatRule4.Rule = FormatConditionRuleExpression4
        GridFormatRule5.Column = Me.BandedGridColumn3
        GridFormatRule5.ColumnApplyTo = Me.BandedGridColumn8
        GridFormatRule5.Name = "Beobachtung_LaufzeitBand2"
        FormatConditionRuleExpression5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression5.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression5.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleExpression5.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression5.Appearance.Options.UseFont = True
        FormatConditionRuleExpression5.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression5.Expression = "[ZeilenNr] In ('370b')"
        GridFormatRule5.Rule = FormatConditionRuleExpression5
        GridFormatRule6.Column = Me.BandedGridColumn3
        GridFormatRule6.ColumnApplyTo = Me.BandedGridColumn9
        GridFormatRule6.Name = "Beobachtung_LaufzeitBand3"
        FormatConditionRuleExpression6.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression6.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression6.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleExpression6.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression6.Appearance.Options.UseFont = True
        FormatConditionRuleExpression6.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression6.Expression = "[ZeilenNr] In ('370b')"
        GridFormatRule6.Rule = FormatConditionRuleExpression6
        GridFormatRule7.Column = Me.BandedGridColumn3
        GridFormatRule7.ColumnApplyTo = Me.BandedGridColumn10
        GridFormatRule7.Name = "Beobachtung_LaufzeitBand4"
        FormatConditionRuleExpression7.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression7.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleExpression7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleExpression7.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleExpression7.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression7.Appearance.Options.UseFont = True
        FormatConditionRuleExpression7.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression7.Expression = "[ZeilenNr] In ('370b')"
        GridFormatRule7.Rule = FormatConditionRuleExpression7
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule1)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule2)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule3)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule4)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule5)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule6)
        Me.LiqV_Totals_BandedGridView.FormatRules.Add(GridFormatRule7)
        Me.LiqV_Totals_BandedGridView.GridControl = Me.GridControl1
        Me.LiqV_Totals_BandedGridView.GroupCount = 1
        Me.LiqV_Totals_BandedGridView.Name = "LiqV_Totals_BandedGridView"
        Me.LiqV_Totals_BandedGridView.NewItemRowText = "Add new Business Type"
        Me.LiqV_Totals_BandedGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_Totals_BandedGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_Totals_BandedGridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.LiqV_Totals_BandedGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.LiqV_Totals_BandedGridView.OptionsCustomization.AllowRowSizing = True
        Me.LiqV_Totals_BandedGridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.LiqV_Totals_BandedGridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.LiqV_Totals_BandedGridView.OptionsFind.AlwaysVisible = True
        Me.LiqV_Totals_BandedGridView.OptionsPrint.PrintDetails = True
        Me.LiqV_Totals_BandedGridView.OptionsSelection.MultiSelect = True
        Me.LiqV_Totals_BandedGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_Totals_BandedGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.LiqV_Totals_BandedGridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.LiqV_Totals_BandedGridView.OptionsView.ShowAutoFilterRow = True
        Me.LiqV_Totals_BandedGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.LiqV_Totals_BandedGridView.OptionsView.ShowFooter = True
        Me.LiqV_Totals_BandedGridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn2, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 862
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.FieldName = "ID"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn1.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.BandedGridColumn1.Width = 95
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.FieldName = "GroupName"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn2.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.BandedGridColumn2.Width = 200
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.FieldName = "ZeilenNr"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn3.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Beschreibung"
        Me.BandedGridColumn4.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.BandedGridColumn4.FieldName = "ZeilenNrName"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn4.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 612
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        Me.RepositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Kontrollsumme"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.FieldName = "KontrollSumme"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn5.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 121
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.DisplayFormat.FormatString = "p0"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "Factor"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn6.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 54
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.FieldName = "RiskDate"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn11.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn11.Width = 107
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gridBand2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand2.Caption = "täglich fällig bis zu einem Monat"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.RowCount = 2
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 119
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn7.Caption = "Laufzeitband 1"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "LaufzeitBand_1"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn7.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 119
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand3.Caption = "über 1 Monat bis zu 3 Monaten"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.RowCount = 2
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 111
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn8.Caption = "Laufzeitband 2"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "LaufzeitBand_2"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn8.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 111
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand4.Caption = "über 3 Monaten bis zu 6 Monaten"
        Me.gridBand4.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 115
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn9.Caption = "Laufzeitband 3"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "LaufzeitBand_3"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn9.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 115
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "über 6 Monaten bis zu 12 Monaten"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn10)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 4
        Me.gridBand5.Width = 115
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn10.Caption = "Laufzeitband 4"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "LaufzeitBand_4"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridColumn10.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 115
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
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2, Me.PrintableComponentLink3})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
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
        Me.GridControl3.DataSource = Me.LiqV_Details_All1BindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.Location = New System.Drawing.Point(24, 50)
        Me.GridControl3.MainView = Me.LiqV_DetailsAll_Gridview
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox3, Me.RepositoryItemTextEdit2, Me.RepositoryItemMemoExEdit3})
        Me.GridControl3.Size = New System.Drawing.Size(1430, 567)
        Me.GridControl3.TabIndex = 25
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LiqV_DetailsAll_Gridview, Me.LayoutView5})
        '
        'LiqV_Details_All1BindingSource
        '
        Me.LiqV_Details_All1BindingSource.DataMember = "LiqV_Details_All1"
        Me.LiqV_Details_All1BindingSource.DataSource = Me.LiqV_Dataset
        '
        'LiqV_DetailsAll_Gridview
        '
        Me.LiqV_DetailsAll_Gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.LiqV_DetailsAll_Gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.LiqV_DetailsAll_Gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.LiqV_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseBackColor = True
        Me.LiqV_DetailsAll_Gridview.Appearance.FocusedRow.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Aqua
        Me.LiqV_DetailsAll_Gridview.Appearance.GroupFooter.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.LiqV_DetailsAll_Gridview.Appearance.GroupRow.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.Row.Options.UseBackColor = True
        Me.LiqV_DetailsAll_Gridview.AppearancePrint.Row.Options.UseForeColor = True
        Me.LiqV_DetailsAll_Gridview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colGroupName2, Me.colZeilenNr2, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.colAmountEurWithoutInterest1, Me.colFactor2, Me.colAnrechnungsBetrag1, Me.colId_LiqV_Totals1, Me.colRiskDate2})
        Me.LiqV_DetailsAll_Gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.LiqV_DetailsAll_Gridview.GridControl = Me.GridControl3
        Me.LiqV_DetailsAll_Gridview.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEurWithoutInterest", Nothing, "Sum Amount(EUR) without Interest={0:c2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEurWithoutInterest", Me.colAmountEurWithoutInterest1, "Sum={0:c2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AnrechnungsBetrag", Nothing, "Sum Anrechnungsbetrag={0:c2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AnrechnungsBetrag", Me.colAnrechnungsBetrag1, "Sum={0:c2}")})
        Me.LiqV_DetailsAll_Gridview.Name = "LiqV_DetailsAll_Gridview"
        Me.LiqV_DetailsAll_Gridview.OptionsBehavior.AllowIncrementalSearch = True
        Me.LiqV_DetailsAll_Gridview.OptionsBehavior.AutoExpandAllGroups = True
        Me.LiqV_DetailsAll_Gridview.OptionsCustomization.AllowRowSizing = True
        Me.LiqV_DetailsAll_Gridview.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.LiqV_DetailsAll_Gridview.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.LiqV_DetailsAll_Gridview.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.LiqV_DetailsAll_Gridview.OptionsFilter.UseNewCustomFilterDialog = True
        Me.LiqV_DetailsAll_Gridview.OptionsFind.AlwaysVisible = True
        Me.LiqV_DetailsAll_Gridview.OptionsFind.SearchInPreview = True
        Me.LiqV_DetailsAll_Gridview.OptionsLayout.StoreAllOptions = True
        Me.LiqV_DetailsAll_Gridview.OptionsLayout.StoreAppearance = True
        Me.LiqV_DetailsAll_Gridview.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_DetailsAll_Gridview.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.LiqV_DetailsAll_Gridview.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.LiqV_DetailsAll_Gridview.OptionsSelection.MultiSelect = True
        Me.LiqV_DetailsAll_Gridview.OptionsView.ColumnAutoWidth = False
        Me.LiqV_DetailsAll_Gridview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiqV_DetailsAll_Gridview.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.LiqV_DetailsAll_Gridview.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.LiqV_DetailsAll_Gridview.OptionsView.ShowAutoFilterRow = True
        Me.LiqV_DetailsAll_Gridview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.LiqV_DetailsAll_Gridview.OptionsView.ShowFooter = True
        Me.LiqV_DetailsAll_Gridview.OptionsView.ShowGroupedColumns = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colGroupName2
        '
        Me.colGroupName2.FieldName = "GroupName"
        Me.colGroupName2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colGroupName2.Name = "colGroupName2"
        Me.colGroupName2.OptionsColumn.AllowEdit = False
        Me.colGroupName2.OptionsColumn.ReadOnly = True
        Me.colGroupName2.Visible = True
        Me.colGroupName2.VisibleIndex = 0
        Me.colGroupName2.Width = 126
        '
        'colZeilenNr2
        '
        Me.colZeilenNr2.FieldName = "ZeilenNr"
        Me.colZeilenNr2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colZeilenNr2.Name = "colZeilenNr2"
        Me.colZeilenNr2.OptionsColumn.AllowEdit = False
        Me.colZeilenNr2.OptionsColumn.ReadOnly = True
        Me.colZeilenNr2.Visible = True
        Me.colZeilenNr2.VisibleIndex = 1
        Me.colZeilenNr2.Width = 64
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Zahlungsart"
        Me.GridColumn17.FieldName = "Zahlungsart"
        Me.GridColumn17.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 2
        Me.GridColumn17.Width = 272
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Business Type"
        Me.GridColumn18.FieldName = "BusinessType"
        Me.GridColumn18.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 3
        Me.GridColumn18.Width = 287
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Contract Type"
        Me.GridColumn19.FieldName = "Contract Type"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        Me.GridColumn19.Width = 87
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Product Type"
        Me.GridColumn20.FieldName = "Product Type"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 5
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Customer Name"
        Me.GridColumn21.FieldName = "Counterparty/Issuer/Collateral Provider"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 6
        Me.GridColumn21.Width = 321
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.Caption = "Client No"
        Me.GridColumn22.FieldName = "Client No"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 7
        Me.GridColumn22.Width = 180
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Contract Collateral ID"
        Me.GridColumn23.FieldName = "Contract Collateral ID"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 8
        Me.GridColumn23.Width = 146
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn24.Caption = "Event Date"
        Me.GridColumn24.FieldName = "Event Date"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 9
        Me.GridColumn24.Width = 81
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn25.Caption = "Maturity Date"
        Me.GridColumn25.DisplayFormat.FormatString = "d"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn25.FieldName = "Maturity Date"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 10
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.Caption = "Days"
        Me.GridColumn26.DisplayFormat.FormatString = "n0"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "Days"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 11
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.Caption = "Laufzeitband"
        Me.GridColumn27.FieldName = "Laufzeitband"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 12
        Me.GridColumn27.Width = 102
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Original Currency"
        Me.GridColumn28.FieldName = "Org Ccy"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 13
        '
        'GridColumn29
        '
        Me.GridColumn29.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn29.Caption = "Orig.Cur Amount"
        Me.GridColumn29.DisplayFormat.FormatString = "n2"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn29.FieldName = "OrgCcyAmount"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 14
        Me.GridColumn29.Width = 134
        '
        'colAmountEurWithoutInterest1
        '
        Me.colAmountEurWithoutInterest1.Caption = "Amount (EUR) without Interest"
        Me.colAmountEurWithoutInterest1.DisplayFormat.FormatString = "n2"
        Me.colAmountEurWithoutInterest1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountEurWithoutInterest1.FieldName = "AmountEurWithoutInterest"
        Me.colAmountEurWithoutInterest1.Name = "colAmountEurWithoutInterest1"
        Me.colAmountEurWithoutInterest1.OptionsColumn.AllowEdit = False
        Me.colAmountEurWithoutInterest1.OptionsColumn.ReadOnly = True
        Me.colAmountEurWithoutInterest1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountEurWithoutInterest", "SUM={0:n2}")})
        Me.colAmountEurWithoutInterest1.Visible = True
        Me.colAmountEurWithoutInterest1.VisibleIndex = 15
        Me.colAmountEurWithoutInterest1.Width = 162
        '
        'colFactor2
        '
        Me.colFactor2.Caption = "Gewichtung"
        Me.colFactor2.DisplayFormat.FormatString = "p0"
        Me.colFactor2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colFactor2.FieldName = "Factor"
        Me.colFactor2.Name = "colFactor2"
        Me.colFactor2.OptionsColumn.AllowEdit = False
        Me.colFactor2.OptionsColumn.ReadOnly = True
        Me.colFactor2.Visible = True
        Me.colFactor2.VisibleIndex = 16
        '
        'colAnrechnungsBetrag1
        '
        Me.colAnrechnungsBetrag1.Caption = "Anrechnungsbetrag"
        Me.colAnrechnungsBetrag1.DisplayFormat.FormatString = "n2"
        Me.colAnrechnungsBetrag1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAnrechnungsBetrag1.FieldName = "AnrechnungsBetrag"
        Me.colAnrechnungsBetrag1.Name = "colAnrechnungsBetrag1"
        Me.colAnrechnungsBetrag1.OptionsColumn.AllowEdit = False
        Me.colAnrechnungsBetrag1.OptionsColumn.ReadOnly = True
        Me.colAnrechnungsBetrag1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AnrechnungsBetrag", "SUM={0:n2}")})
        Me.colAnrechnungsBetrag1.Visible = True
        Me.colAnrechnungsBetrag1.VisibleIndex = 17
        Me.colAnrechnungsBetrag1.Width = 126
        '
        'colId_LiqV_Totals1
        '
        Me.colId_LiqV_Totals1.FieldName = "Id_LiqV_Totals"
        Me.colId_LiqV_Totals1.Name = "colId_LiqV_Totals1"
        Me.colId_LiqV_Totals1.OptionsColumn.AllowEdit = False
        Me.colId_LiqV_Totals1.OptionsColumn.ReadOnly = True
        '
        'colRiskDate2
        '
        Me.colRiskDate2.FieldName = "RiskDate"
        Me.colRiskDate2.Name = "colRiskDate2"
        Me.colRiskDate2.OptionsColumn.AllowEdit = False
        Me.colRiskDate2.OptionsColumn.ReadOnly = True
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
        'PrintableComponentLink3
        '
        Me.PrintableComponentLink3.Component = Me.GridControl4
        Me.PrintableComponentLink3.Landscape = True
        Me.PrintableComponentLink3.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink3.PrintingSystemBase = Me.PrintingSystem1
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
        Me.GridControl4.MainView = Me.LiquidityCalculation_GridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox4, Me.RepositoryItemTextEdit7, Me.RepositoryItemTextEdit8, Me.RepositoryItemTextEdit9, Me.RepositoryItemMemoExEdit4, Me.RepositoryItemImageComboBox3})
        Me.GridControl4.Size = New System.Drawing.Size(1430, 549)
        Me.GridControl4.TabIndex = 129
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LiquidityCalculation_GridView, Me.LayoutView4, Me.GridView4})
        '
        'LiquidityCalculation_GridView
        '
        Me.LiquidityCalculation_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.LiquidityCalculation_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.LiquidityCalculation_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.LiquidityCalculation_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.LiquidityCalculation_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Aqua
        Me.LiquidityCalculation_GridView.Appearance.GroupFooter.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.LiquidityCalculation_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiquidityCalculation_GridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LiquidityCalculation_GridView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.LiquidityCalculation_GridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.LiquidityCalculation_GridView.AppearancePrint.Row.Options.UseBackColor = True
        Me.LiquidityCalculation_GridView.AppearancePrint.Row.Options.UseForeColor = True
        Me.LiquidityCalculation_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.colCustomerName, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.LiquidityCalculation_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.LiquidityCalculation_GridView.GridControl = Me.GridControl4
        Me.LiquidityCalculation_GridView.GroupCount = 2
        Me.LiquidityCalculation_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount EUR Without Interest", Nothing, "Sum={0:c2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount EUR Without Interest", Me.GridColumn16, "Sum={0:c2}")})
        Me.LiquidityCalculation_GridView.Name = "LiquidityCalculation_GridView"
        Me.LiquidityCalculation_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.LiquidityCalculation_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.LiquidityCalculation_GridView.OptionsCustomization.AllowRowSizing = True
        Me.LiquidityCalculation_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.LiquidityCalculation_GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.LiquidityCalculation_GridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.LiquidityCalculation_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.LiquidityCalculation_GridView.OptionsFind.AlwaysVisible = True
        Me.LiquidityCalculation_GridView.OptionsFind.SearchInPreview = True
        Me.LiquidityCalculation_GridView.OptionsLayout.StoreAllOptions = True
        Me.LiquidityCalculation_GridView.OptionsLayout.StoreAppearance = True
        Me.LiquidityCalculation_GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiquidityCalculation_GridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.LiquidityCalculation_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.LiquidityCalculation_GridView.OptionsSelection.MultiSelect = True
        Me.LiquidityCalculation_GridView.OptionsView.ColumnAutoWidth = False
        Me.LiquidityCalculation_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.LiquidityCalculation_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.LiquidityCalculation_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.LiquidityCalculation_GridView.OptionsView.ShowAutoFilterRow = True
        Me.LiquidityCalculation_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.LiquidityCalculation_GridView.OptionsView.ShowFooter = True
        Me.LiquidityCalculation_GridView.OptionsView.ShowGroupedColumns = True
        Me.LiquidityCalculation_GridView.PaintStyleName = "Skin"
        Me.LiquidityCalculation_GridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ZeilenNr. in LV1"
        Me.GridColumn3.FieldName = "ZeilenNr. in LV1"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Zahlungsart"
        Me.GridColumn4.FieldName = "Zahlungsart"
        Me.GridColumn4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 272
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Business Type"
        Me.GridColumn5.FieldName = "BusinessType"
        Me.GridColumn5.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 287
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Contract Type"
        Me.GridColumn6.FieldName = "Contract Type"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Product Type"
        Me.GridColumn7.FieldName = "Product Type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'colCustomerName
        '
        Me.colCustomerName.Caption = "Customer Name"
        Me.colCustomerName.FieldName = "Counterparty/Issuer/Collateral Provider"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.OptionsColumn.AllowEdit = False
        Me.colCustomerName.OptionsColumn.ReadOnly = True
        Me.colCustomerName.Visible = True
        Me.colCustomerName.VisibleIndex = 4
        Me.colCustomerName.Width = 321
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Client No"
        Me.GridColumn8.FieldName = "Client No"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Contract Collateral ID"
        Me.GridColumn9.FieldName = "Contract Collateral ID"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 6
        Me.GridColumn9.Width = 146
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.Caption = "Event Date"
        Me.GridColumn10.FieldName = "Event Date"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        Me.GridColumn10.Width = 81
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.Caption = "Maturity Date"
        Me.GridColumn11.DisplayFormat.FormatString = "d"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "Maturity Date"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 8
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.Caption = "Days"
        Me.GridColumn12.DisplayFormat.FormatString = "n0"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "Days"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 9
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Laufzeitband"
        Me.GridColumn13.FieldName = "Laufzeitband"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Original Currency"
        Me.GridColumn14.FieldName = "Org Ccy"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 10
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn15.Caption = "Orig.Cur Amount"
        Me.GridColumn15.DisplayFormat.FormatString = "n2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "OrgCcyAmount"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 11
        Me.GridColumn15.Width = 134
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.Caption = "Amount EUR without Interest"
        Me.GridColumn16.DisplayFormat.FormatString = "n2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "Amount EUR Without Interest"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 12
        Me.GridColumn16.Width = 151
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
        Me.LayoutView4.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField8, Me.LayoutViewField7, Me.LayoutViewField5})
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
        Me.LayoutViewColumn90.LayoutViewField = Me.LayoutViewField1
        Me.LayoutViewColumn90.Name = "LayoutViewColumn90"
        '
        'LayoutViewField1
        '
        Me.LayoutViewField1.EditorPreferredWidth = 384
        Me.LayoutViewField1.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField1.Name = "LayoutViewField1"
        Me.LayoutViewField1.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField1.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn91
        '
        Me.LayoutViewColumn91.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn91.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn91.FieldName = "POB NUMBER"
        Me.LayoutViewColumn91.LayoutViewField = Me.LayoutViewField2
        Me.LayoutViewColumn91.Name = "LayoutViewColumn91"
        '
        'LayoutViewField2
        '
        Me.LayoutViewField2.EditorPreferredWidth = 384
        Me.LayoutViewField2.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField2.Name = "LayoutViewField2"
        Me.LayoutViewField2.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField2.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn92
        '
        Me.LayoutViewColumn92.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn92.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn92.FieldName = "POB LOCATION"
        Me.LayoutViewColumn92.LayoutViewField = Me.LayoutViewField3
        Me.LayoutViewColumn92.Name = "LayoutViewColumn92"
        '
        'LayoutViewField3
        '
        Me.LayoutViewField3.EditorPreferredWidth = 384
        Me.LayoutViewField3.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField3.Name = "LayoutViewField3"
        Me.LayoutViewField3.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField3.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn93
        '
        Me.LayoutViewColumn93.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn93.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn93.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn93.LayoutViewField = Me.LayoutViewField4
        Me.LayoutViewColumn93.Name = "LayoutViewColumn93"
        '
        'LayoutViewField4
        '
        Me.LayoutViewField4.EditorPreferredWidth = 384
        Me.LayoutViewField4.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField4.Name = "LayoutViewField4"
        Me.LayoutViewField4.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField4.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn94
        '
        Me.LayoutViewColumn94.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn94.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn94.CustomizationCaption = "USER"
        Me.LayoutViewColumn94.FieldName = "USER"
        Me.LayoutViewColumn94.LayoutViewField = Me.LayoutViewField5
        Me.LayoutViewColumn94.Name = "LayoutViewColumn94"
        Me.LayoutViewColumn94.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField5
        '
        Me.LayoutViewField5.EditorPreferredWidth = 20
        Me.LayoutViewField5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField5.Name = "LayoutViewField5"
        Me.LayoutViewField5.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField5.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn95
        '
        Me.LayoutViewColumn95.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn95.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn95.ColumnEdit = Me.RepositoryItemComboBox4
        Me.LayoutViewColumn95.FieldName = "VALID"
        Me.LayoutViewColumn95.LayoutViewField = Me.LayoutViewField6
        Me.LayoutViewColumn95.Name = "LayoutViewColumn95"
        '
        'LayoutViewField6
        '
        Me.LayoutViewField6.EditorPreferredWidth = 30
        Me.LayoutViewField6.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField6.Name = "LayoutViewField6"
        Me.LayoutViewField6.Size = New System.Drawing.Size(162, 20)
        Me.LayoutViewField6.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn96
        '
        Me.LayoutViewColumn96.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn96.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn96.CustomizationCaption = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.LayoutViewField = Me.LayoutViewField7
        Me.LayoutViewColumn96.Name = "LayoutViewColumn96"
        Me.LayoutViewColumn96.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField7
        '
        Me.LayoutViewField7.EditorPreferredWidth = 20
        Me.LayoutViewField7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField7.Name = "LayoutViewField7"
        Me.LayoutViewField7.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField7.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn97
        '
        Me.LayoutViewColumn97.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn97.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn97.CustomizationCaption = "BIC11"
        Me.LayoutViewColumn97.FieldName = "BIC11"
        Me.LayoutViewColumn97.LayoutViewField = Me.LayoutViewField8
        Me.LayoutViewColumn97.Name = "LayoutViewColumn97"
        Me.LayoutViewColumn97.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField8
        '
        Me.LayoutViewField8.EditorPreferredWidth = 20
        Me.LayoutViewField8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField8.Name = "LayoutViewField8"
        Me.LayoutViewField8.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField8.TextSize = New System.Drawing.Size(133, 20)
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
        Me.LayoutViewColumn98.LayoutViewField = Me.LayoutViewField9
        Me.LayoutViewColumn98.Name = "LayoutViewColumn98"
        '
        'LayoutViewField9
        '
        Me.LayoutViewField9.EditorPreferredWidth = 93
        Me.LayoutViewField9.ImageOptions.ImageIndex = 0
        Me.LayoutViewField9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField9.Name = "LayoutViewField9"
        Me.LayoutViewField9.Size = New System.Drawing.Size(225, 20)
        Me.LayoutViewField9.TextSize = New System.Drawing.Size(123, 16)
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
        Me.LayoutViewColumn99.LayoutViewField = Me.LayoutViewField10
        Me.LayoutViewColumn99.Name = "LayoutViewColumn99"
        '
        'LayoutViewField10
        '
        Me.LayoutViewField10.EditorPreferredWidth = 51
        Me.LayoutViewField10.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField10.Name = "LayoutViewField10"
        Me.LayoutViewField10.Size = New System.Drawing.Size(183, 20)
        Me.LayoutViewField10.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn100
        '
        Me.LayoutViewColumn100.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn100.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn100.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn100.FieldName = "COUNTRY"
        Me.LayoutViewColumn100.LayoutViewField = Me.LayoutViewField11
        Me.LayoutViewColumn100.Name = "LayoutViewColumn100"
        Me.LayoutViewColumn100.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField11
        '
        Me.LayoutViewField11.EditorPreferredWidth = 384
        Me.LayoutViewField11.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField11.Name = "LayoutViewField11"
        Me.LayoutViewField11.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField11.TextSize = New System.Drawing.Size(110, 13)
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
        'GridView4
        '
        Me.GridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn96, Me.GridColumn97, Me.GridColumn98, Me.GridColumn99, Me.GridColumn100, Me.GridColumn101, Me.GridColumn102, Me.GridColumn103, Me.GridColumn104, Me.GridColumn105, Me.GridColumn106, Me.GridColumn107, Me.GridColumn108, Me.GridColumn109, Me.GridColumn110, Me.GridColumn111, Me.GridColumn112, Me.GridColumn113, Me.GridColumn114, Me.GridColumn115, Me.GridColumn116, Me.GridColumn117, Me.GridColumn118, Me.GridColumn119, Me.GridColumn120, Me.GridColumn121, Me.GridColumn122, Me.GridColumn123, Me.GridColumn124, Me.GridColumn125, Me.GridColumn126, Me.GridColumn127})
        Me.GridView4.GridControl = Me.GridControl4
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView4.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView4.OptionsView.ShowFooter = True
        Me.GridView4.ViewCaption = "CREDIT RISK DETAILS"
        '
        'GridColumn96
        '
        Me.GridColumn96.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn96.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn96.DisplayFormat.FormatString = "n2"
        Me.GridColumn96.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn96.FieldName = "ID"
        Me.GridColumn96.Name = "GridColumn96"
        Me.GridColumn96.OptionsColumn.AllowEdit = False
        Me.GridColumn96.OptionsColumn.ReadOnly = True
        '
        'GridColumn97
        '
        Me.GridColumn97.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn97.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn97.FieldName = "Obligor Rate"
        Me.GridColumn97.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn97.Name = "GridColumn97"
        Me.GridColumn97.OptionsColumn.AllowEdit = False
        Me.GridColumn97.OptionsColumn.ReadOnly = True
        Me.GridColumn97.Visible = True
        Me.GridColumn97.VisibleIndex = 2
        Me.GridColumn97.Width = 94
        '
        'GridColumn98
        '
        Me.GridColumn98.FieldName = "Contract Type"
        Me.GridColumn98.Name = "GridColumn98"
        Me.GridColumn98.OptionsColumn.AllowEdit = False
        Me.GridColumn98.OptionsColumn.ReadOnly = True
        Me.GridColumn98.Visible = True
        Me.GridColumn98.VisibleIndex = 3
        Me.GridColumn98.Width = 86
        '
        'GridColumn99
        '
        Me.GridColumn99.FieldName = "Product Type"
        Me.GridColumn99.Name = "GridColumn99"
        Me.GridColumn99.OptionsColumn.AllowEdit = False
        Me.GridColumn99.OptionsColumn.ReadOnly = True
        Me.GridColumn99.Visible = True
        Me.GridColumn99.VisibleIndex = 4
        Me.GridColumn99.Width = 93
        '
        'GridColumn100
        '
        Me.GridColumn100.FieldName = "GL Master / Account Type"
        Me.GridColumn100.Name = "GridColumn100"
        Me.GridColumn100.OptionsColumn.AllowEdit = False
        Me.GridColumn100.OptionsColumn.ReadOnly = True
        Me.GridColumn100.Width = 148
        '
        'GridColumn101
        '
        Me.GridColumn101.FieldName = "Counterparty/Issuer/Collateral Name"
        Me.GridColumn101.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn101.Name = "GridColumn101"
        Me.GridColumn101.OptionsColumn.AllowEdit = False
        Me.GridColumn101.OptionsColumn.ReadOnly = True
        Me.GridColumn101.Visible = True
        Me.GridColumn101.VisibleIndex = 1
        Me.GridColumn101.Width = 221
        '
        'GridColumn102
        '
        Me.GridColumn102.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn102.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn102.FieldName = "Client No"
        Me.GridColumn102.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn102.Name = "GridColumn102"
        Me.GridColumn102.OptionsColumn.AllowEdit = False
        Me.GridColumn102.OptionsColumn.ReadOnly = True
        Me.GridColumn102.Visible = True
        Me.GridColumn102.VisibleIndex = 0
        Me.GridColumn102.Width = 89
        '
        'GridColumn103
        '
        Me.GridColumn103.FieldName = "Contract Collateral ID"
        Me.GridColumn103.Name = "GridColumn103"
        Me.GridColumn103.OptionsColumn.AllowEdit = False
        Me.GridColumn103.OptionsColumn.ReadOnly = True
        Me.GridColumn103.Width = 137
        '
        'GridColumn104
        '
        Me.GridColumn104.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn104.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn104.FieldName = "Maturity Date"
        Me.GridColumn104.Name = "GridColumn104"
        Me.GridColumn104.OptionsColumn.AllowEdit = False
        Me.GridColumn104.OptionsColumn.ReadOnly = True
        Me.GridColumn104.Visible = True
        Me.GridColumn104.VisibleIndex = 5
        Me.GridColumn104.Width = 81
        '
        'GridColumn105
        '
        Me.GridColumn105.FieldName = "Remaining Year(s) to Maturity"
        Me.GridColumn105.Name = "GridColumn105"
        Me.GridColumn105.OptionsColumn.AllowEdit = False
        Me.GridColumn105.OptionsColumn.ReadOnly = True
        Me.GridColumn105.Width = 83
        '
        'GridColumn106
        '
        Me.GridColumn106.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn106.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn106.FieldName = "Org Ccy"
        Me.GridColumn106.Name = "GridColumn106"
        Me.GridColumn106.OptionsColumn.AllowEdit = False
        Me.GridColumn106.OptionsColumn.ReadOnly = True
        Me.GridColumn106.Visible = True
        Me.GridColumn106.VisibleIndex = 6
        Me.GridColumn106.Width = 47
        '
        'GridColumn107
        '
        Me.GridColumn107.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn107.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn107.DisplayFormat.FormatString = "n2"
        Me.GridColumn107.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn107.FieldName = "Credit Outstanding (Org Ccy)"
        Me.GridColumn107.Name = "GridColumn107"
        Me.GridColumn107.OptionsColumn.AllowEdit = False
        Me.GridColumn107.OptionsColumn.ReadOnly = True
        Me.GridColumn107.Visible = True
        Me.GridColumn107.VisibleIndex = 7
        Me.GridColumn107.Width = 159
        '
        'GridColumn108
        '
        Me.GridColumn108.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn108.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn108.DisplayFormat.FormatString = "n2"
        Me.GridColumn108.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn108.FieldName = "Credit Outstanding (EUR Equ)"
        Me.GridColumn108.Name = "GridColumn108"
        Me.GridColumn108.OptionsColumn.AllowEdit = False
        Me.GridColumn108.OptionsColumn.ReadOnly = True
        Me.GridColumn108.ToolTip = "without consideration of CASHPLEDGE"
        Me.GridColumn108.Visible = True
        Me.GridColumn108.VisibleIndex = 8
        Me.GridColumn108.Width = 158
        '
        'GridColumn109
        '
        Me.GridColumn109.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn109.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn109.DisplayFormat.FormatString = "n2"
        Me.GridColumn109.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn109.FieldName = "NetCreditOutstandingAmountEUR"
        Me.GridColumn109.Name = "GridColumn109"
        Me.GridColumn109.OptionsColumn.AllowEdit = False
        Me.GridColumn109.OptionsColumn.ReadOnly = True
        Me.GridColumn109.ToolTip = "CASHPLEDGE Consideration"
        Me.GridColumn109.Visible = True
        Me.GridColumn109.VisibleIndex = 9
        Me.GridColumn109.Width = 196
        '
        'GridColumn110
        '
        Me.GridColumn110.FieldName = "InternalInfo"
        Me.GridColumn110.Name = "GridColumn110"
        Me.GridColumn110.OptionsColumn.AllowEdit = False
        Me.GridColumn110.OptionsColumn.ReadOnly = True
        Me.GridColumn110.Visible = True
        Me.GridColumn110.VisibleIndex = 10
        Me.GridColumn110.Width = 104
        '
        'GridColumn111
        '
        Me.GridColumn111.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn111.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn111.FieldName = "PD"
        Me.GridColumn111.Name = "GridColumn111"
        Me.GridColumn111.OptionsColumn.AllowEdit = False
        Me.GridColumn111.OptionsColumn.ReadOnly = True
        Me.GridColumn111.Visible = True
        Me.GridColumn111.VisibleIndex = 11
        Me.GridColumn111.Width = 59
        '
        'GridColumn112
        '
        Me.GridColumn112.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn112.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn112.Caption = "(ER1)"
        Me.GridColumn112.DisplayFormat.FormatString = "p2"
        Me.GridColumn112.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn112.FieldName = "(1-ER)"
        Me.GridColumn112.Name = "GridColumn112"
        Me.GridColumn112.OptionsColumn.AllowEdit = False
        Me.GridColumn112.OptionsColumn.ReadOnly = True
        Me.GridColumn112.Width = 61
        '
        'GridColumn113
        '
        Me.GridColumn113.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn113.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn113.Caption = "Credit Risk (ER1)"
        Me.GridColumn113.DisplayFormat.FormatString = "n2"
        Me.GridColumn113.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn113.FieldName = "Credit Risk Amount(EUR Equ)"
        Me.GridColumn113.Name = "GridColumn113"
        Me.GridColumn113.OptionsColumn.AllowEdit = False
        Me.GridColumn113.OptionsColumn.ReadOnly = True
        Me.GridColumn113.Width = 150
        '
        'GridColumn114
        '
        Me.GridColumn114.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn114.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn114.Caption = "Net Credit Risk (ER1)"
        Me.GridColumn114.DisplayFormat.FormatString = "n2"
        Me.GridColumn114.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn114.FieldName = "NetCredit Risk Amount(EUR Equ)"
        Me.GridColumn114.Name = "GridColumn114"
        Me.GridColumn114.OptionsColumn.AllowEdit = False
        Me.GridColumn114.OptionsColumn.ReadOnly = True
        Me.GridColumn114.Width = 172
        '
        'GridColumn115
        '
        Me.GridColumn115.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn115.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn115.Caption = "(ER2)"
        Me.GridColumn115.DisplayFormat.FormatString = "p2"
        Me.GridColumn115.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn115.FieldName = "(1-ER_45)"
        Me.GridColumn115.Name = "GridColumn115"
        Me.GridColumn115.OptionsColumn.AllowEdit = False
        Me.GridColumn115.OptionsColumn.ReadOnly = True
        Me.GridColumn115.Visible = True
        Me.GridColumn115.VisibleIndex = 12
        Me.GridColumn115.Width = 61
        '
        'GridColumn116
        '
        Me.GridColumn116.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn116.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn116.Caption = "Credit Risk (ER2)"
        Me.GridColumn116.DisplayFormat.FormatString = "n2"
        Me.GridColumn116.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn116.FieldName = "CreditRiskAmountEUREquER45"
        Me.GridColumn116.Name = "GridColumn116"
        Me.GridColumn116.OptionsColumn.AllowEdit = False
        Me.GridColumn116.OptionsColumn.ReadOnly = True
        Me.GridColumn116.Visible = True
        Me.GridColumn116.VisibleIndex = 13
        Me.GridColumn116.Width = 181
        '
        'GridColumn117
        '
        Me.GridColumn117.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn117.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn117.Caption = "Net Credit Risk (ER2)"
        Me.GridColumn117.DisplayFormat.FormatString = "n2"
        Me.GridColumn117.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn117.FieldName = "NetCreditRiskAmountEUREquER45"
        Me.GridColumn117.Name = "GridColumn117"
        Me.GridColumn117.OptionsColumn.AllowEdit = False
        Me.GridColumn117.OptionsColumn.ReadOnly = True
        Me.GridColumn117.Visible = True
        Me.GridColumn117.VisibleIndex = 14
        Me.GridColumn117.Width = 192
        '
        'GridColumn118
        '
        Me.GridColumn118.FieldName = "CoreDefinition"
        Me.GridColumn118.Name = "GridColumn118"
        Me.GridColumn118.OptionsColumn.AllowEdit = False
        Me.GridColumn118.OptionsColumn.ReadOnly = True
        Me.GridColumn118.Visible = True
        Me.GridColumn118.VisibleIndex = 15
        Me.GridColumn118.Width = 85
        '
        'GridColumn119
        '
        Me.GridColumn119.FieldName = "ClientGroup"
        Me.GridColumn119.Name = "GridColumn119"
        Me.GridColumn119.OptionsColumn.AllowEdit = False
        Me.GridColumn119.OptionsColumn.ReadOnly = True
        '
        'GridColumn120
        '
        Me.GridColumn120.FieldName = "ClientGroupName"
        Me.GridColumn120.Name = "GridColumn120"
        Me.GridColumn120.OptionsColumn.AllowEdit = False
        Me.GridColumn120.OptionsColumn.ReadOnly = True
        Me.GridColumn120.Width = 78
        '
        'GridColumn121
        '
        Me.GridColumn121.Caption = "Maturity(without cap, floor)"
        Me.GridColumn121.FieldName = "MaturityWithoutCapFloor"
        Me.GridColumn121.Name = "GridColumn121"
        Me.GridColumn121.OptionsColumn.AllowEdit = False
        Me.GridColumn121.OptionsColumn.ReadOnly = True
        Me.GridColumn121.ToolTip = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" &
    "m else Maturity Date-RiskDate/365,25"
        Me.GridColumn121.Visible = True
        Me.GridColumn121.VisibleIndex = 16
        Me.GridColumn121.Width = 145
        '
        'GridColumn122
        '
        Me.GridColumn122.Caption = "EaD weighted maturity (without cap, floor)"
        Me.GridColumn122.DisplayFormat.FormatString = "n2"
        Me.GridColumn122.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn122.FieldName = "EaDweigthedMaturityWithoutCapFloor"
        Me.GridColumn122.Name = "GridColumn122"
        Me.GridColumn122.OptionsColumn.AllowEdit = False
        Me.GridColumn122.OptionsColumn.ReadOnly = True
        Me.GridColumn122.ToolTip = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
        Me.GridColumn122.Visible = True
        Me.GridColumn122.VisibleIndex = 17
        Me.GridColumn122.Width = 230
        '
        'GridColumn123
        '
        Me.GridColumn123.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn123.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn123.Caption = "PD * Final EaD"
        Me.GridColumn123.DisplayFormat.FormatString = "n2"
        Me.GridColumn123.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn123.FieldName = "PDxFinalEaD"
        Me.GridColumn123.Name = "GridColumn123"
        Me.GridColumn123.OptionsColumn.AllowEdit = False
        Me.GridColumn123.OptionsColumn.ReadOnly = True
        Me.GridColumn123.ToolTip = "PD * Net Credit outstanding Amount EUR"
        Me.GridColumn123.Visible = True
        Me.GridColumn123.VisibleIndex = 18
        Me.GridColumn123.Width = 108
        '
        'GridColumn124
        '
        Me.GridColumn124.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn124.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn124.Caption = "LGD (final EaD weigthed)"
        Me.GridColumn124.DisplayFormat.FormatString = "n2"
        Me.GridColumn124.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn124.FieldName = "LGDfinalEaDweighted"
        Me.GridColumn124.Name = "GridColumn124"
        Me.GridColumn124.OptionsColumn.AllowEdit = False
        Me.GridColumn124.OptionsColumn.ReadOnly = True
        Me.GridColumn124.ToolTip = "(ER2) * Net Credit Outstanding Amount EUR"
        Me.GridColumn124.Visible = True
        Me.GridColumn124.VisibleIndex = 19
        Me.GridColumn124.Width = 154
        '
        'GridColumn125
        '
        Me.GridColumn125.FieldName = "RiskDate"
        Me.GridColumn125.Name = "GridColumn125"
        Me.GridColumn125.OptionsColumn.AllowEdit = False
        Me.GridColumn125.OptionsColumn.ReadOnly = True
        Me.GridColumn125.Width = 93
        '
        'GridColumn126
        '
        Me.GridColumn126.FieldName = "IdClientGroup"
        Me.GridColumn126.Name = "GridColumn126"
        Me.GridColumn126.OptionsColumn.AllowEdit = False
        Me.GridColumn126.OptionsColumn.ReadOnly = True
        Me.GridColumn126.Width = 148
        '
        'GridColumn127
        '
        Me.GridColumn127.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn127.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn127.Caption = "Projection Year"
        Me.GridColumn127.DisplayFormat.FormatString = "n0"
        Me.GridColumn127.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn127.FieldName = "ProjectionYear"
        Me.GridColumn127.Name = "GridColumn127"
        Me.GridColumn127.OptionsColumn.AllowEdit = False
        Me.GridColumn127.OptionsColumn.ReadOnly = True
        Me.GridColumn127.Visible = True
        Me.GridColumn127.VisibleIndex = 20
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SQL_Run_BarButtonItem, Me.SQL_ReRun_BarButtonItem, Me.SQL_ReRun_AllDays_BarButtonItem, Me.BarButtonItem1})
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
        Me.barDockControlTop.Size = New System.Drawing.Size(1496, 49)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 723)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1496, 23)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 49)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 674)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1496, 49)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 674)
        '
        'SQL_Run_BarButtonItem
        '
        Me.SQL_Run_BarButtonItem.Caption = "LiqV Calculation (Current Day)"
        Me.SQL_Run_BarButtonItem.Id = 0
        Me.SQL_Run_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_Run_BarButtonItem.Name = "SQL_Run_BarButtonItem"
        '
        'SQL_ReRun_BarButtonItem
        '
        Me.SQL_ReRun_BarButtonItem.Caption = "SQL Re-Run Commands (Current Day)"
        Me.SQL_ReRun_BarButtonItem.Id = 1
        Me.SQL_ReRun_BarButtonItem.ImageOptions.ImageIndex = 2
        Me.SQL_ReRun_BarButtonItem.Name = "SQL_ReRun_BarButtonItem"
        Me.SQL_ReRun_BarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "SQL Re-Run (Specific Period)"
        Me.BarButtonItem1.Id = 3
        Me.BarButtonItem1.ImageOptions.ImageIndex = 2
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_Run_BarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SQL_ReRun_BarButtonItem)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(32, 8)
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
        Me.LoadBusinessTypes_btn.Location = New System.Drawing.Point(155, 27)
        Me.LoadBusinessTypes_btn.Name = "LoadBusinessTypes_btn"
        Me.LoadBusinessTypes_btn.Size = New System.Drawing.Size(97, 22)
        Me.LoadBusinessTypes_btn.TabIndex = 24
        Me.LoadBusinessTypes_btn.Text = "Load Data"
        Me.LoadBusinessTypes_btn.Visible = False
        '
        'LiqV_DateEdit_ComboEdit
        '
        Me.LiqV_DateEdit_ComboEdit.Location = New System.Drawing.Point(32, 27)
        Me.LiqV_DateEdit_ComboEdit.Name = "LiqV_DateEdit_ComboEdit"
        Me.LiqV_DateEdit_ComboEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.LiqV_DateEdit_ComboEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LiqV_DateEdit_ComboEdit.Properties.Appearance.Options.UseFont = True
        Me.LiqV_DateEdit_ComboEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.LiqV_DateEdit_ComboEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.LiqV_DateEdit_ComboEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiqV_DateEdit_ComboEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LiqV_DateEdit_ComboEdit.Properties.DisplayFormat.FormatString = "d"
        Me.LiqV_DateEdit_ComboEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.LiqV_DateEdit_ComboEdit.Properties.EditFormat.FormatString = "d"
        Me.LiqV_DateEdit_ComboEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.LiqV_DateEdit_ComboEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.LiqV_DateEdit_ComboEdit.Size = New System.Drawing.Size(117, 22)
        Me.LiqV_DateEdit_ComboEdit.TabIndex = 23
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
        Me.XtraTabControl1.Location = New System.Drawing.Point(6, 55)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.CAR_CALC_XtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1484, 669)
        Me.XtraTabControl1.TabIndex = 26
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.CAR_CALC_XtraTabPage, Me.CAR_CALC_Details_XtraTabPage, Me.CAR_PARAM_XtraTabPage})
        '
        'CAR_CALC_XtraTabPage
        '
        Me.CAR_CALC_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_CALC_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.CAR_CALC_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_CALC_XtraTabPage.AutoScroll = True
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LiqV_Value_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl10)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.CapitalSurplus_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl9)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.MaxLendingLimit_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl8)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.MultipleFactor_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl7)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.CapitalForSolvV_lbl)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.LabelControl5)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.Print_Export_LiqV_Totals_Gridview_btn)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.CAR_Calc_Report_btn)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.SQL_Commands_Dropdownbutton)
        Me.CAR_CALC_XtraTabPage.Controls.Add(Me.GridControl1)
        Me.CAR_CALC_XtraTabPage.Name = "CAR_CALC_XtraTabPage"
        Me.CAR_CALC_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_CALC_XtraTabPage.Size = New System.Drawing.Size(1478, 641)
        Me.CAR_CALC_XtraTabPage.Text = "LiqV - Calculation"
        '
        'LiqV_Value_lbl
        '
        Me.LiqV_Value_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LiqV_Value_lbl.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.LiqV_Value_lbl.Appearance.Options.UseFont = True
        Me.LiqV_Value_lbl.Appearance.Options.UseForeColor = True
        Me.LiqV_Value_lbl.Appearance.Options.UseTextOptions = True
        Me.LiqV_Value_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiqV_Value_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LiqV_Value_lbl.Location = New System.Drawing.Point(12, 70)
        Me.LiqV_Value_lbl.Name = "LiqV_Value_lbl"
        Me.LiqV_Value_lbl.Size = New System.Drawing.Size(243, 25)
        ToolTipTitleItem1.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem1.Appearance.Options.UseImage = True
        ToolTipTitleItem1.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem1.Text = "Liquidity " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Key figure"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "See position 350b"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.LiqV_Value_lbl.SuperTip = SuperToolTip1
        Me.LiqV_Value_lbl.TabIndex = 140
        Me.LiqV_Value_lbl.Text = "LiqV"
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
        Me.LabelControl10.Location = New System.Drawing.Point(12, 47)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(243, 20)
        Me.LabelControl10.TabIndex = 139
        Me.LabelControl10.Text = "Liquidity Ratio"
        '
        'CapitalSurplus_lbl
        '
        Me.CapitalSurplus_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapitalSurplus_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CapitalSurplus_lbl.Appearance.Options.UseFont = True
        Me.CapitalSurplus_lbl.Appearance.Options.UseForeColor = True
        Me.CapitalSurplus_lbl.Appearance.Options.UseTextOptions = True
        Me.CapitalSurplus_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CapitalSurplus_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CapitalSurplus_lbl.Location = New System.Drawing.Point(808, 67)
        Me.CapitalSurplus_lbl.Name = "CapitalSurplus_lbl"
        Me.CapitalSurplus_lbl.Size = New System.Drawing.Size(181, 22)
        ToolTipTitleItem2.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem2.Appearance.Options.UseImage = True
        ToolTipTitleItem2.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem2.Text = "Capital Surplus"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Capital for Solv" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Sum of [Amount (xMF)]"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.CapitalSurplus_lbl.SuperTip = SuperToolTip2
        Me.CapitalSurplus_lbl.TabIndex = 138
        Me.CapitalSurplus_lbl.Text = "CapitalSurplus"
        Me.CapitalSurplus_lbl.Visible = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Appearance.Options.UseTextOptions = True
        Me.LabelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl9.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl9.LineVisible = True
        Me.LabelControl9.Location = New System.Drawing.Point(808, 48)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(181, 20)
        Me.LabelControl9.TabIndex = 137
        Me.LabelControl9.Text = "Capital Surplus"
        Me.LabelControl9.Visible = False
        '
        'MaxLendingLimit_lbl
        '
        Me.MaxLendingLimit_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxLendingLimit_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.MaxLendingLimit_lbl.Appearance.Options.UseFont = True
        Me.MaxLendingLimit_lbl.Appearance.Options.UseForeColor = True
        Me.MaxLendingLimit_lbl.Appearance.Options.UseTextOptions = True
        Me.MaxLendingLimit_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MaxLendingLimit_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.MaxLendingLimit_lbl.Location = New System.Drawing.Point(621, 67)
        Me.MaxLendingLimit_lbl.Name = "MaxLendingLimit_lbl"
        Me.MaxLendingLimit_lbl.Size = New System.Drawing.Size(181, 22)
        ToolTipTitleItem3.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem3.Appearance.Options.UseImage = True
        ToolTipTitleItem3.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem3.Text = "Maximum Lending Limit"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Capital for SolvV x Multiple Factor"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.MaxLendingLimit_lbl.SuperTip = SuperToolTip3
        Me.MaxLendingLimit_lbl.TabIndex = 136
        Me.MaxLendingLimit_lbl.Text = "MaxLendingLimit"
        Me.MaxLendingLimit_lbl.Visible = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Appearance.Options.UseTextOptions = True
        Me.LabelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl8.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl8.LineVisible = True
        Me.LabelControl8.Location = New System.Drawing.Point(621, 48)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(181, 20)
        Me.LabelControl8.TabIndex = 135
        Me.LabelControl8.Text = "Maximum Lending Limit"
        Me.LabelControl8.Visible = False
        '
        'MultipleFactor_lbl
        '
        Me.MultipleFactor_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultipleFactor_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.MultipleFactor_lbl.Appearance.Options.UseFont = True
        Me.MultipleFactor_lbl.Appearance.Options.UseForeColor = True
        Me.MultipleFactor_lbl.Appearance.Options.UseTextOptions = True
        Me.MultipleFactor_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MultipleFactor_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.MultipleFactor_lbl.Location = New System.Drawing.Point(474, 67)
        Me.MultipleFactor_lbl.Name = "MultipleFactor_lbl"
        Me.MultipleFactor_lbl.Size = New System.Drawing.Size(129, 22)
        Me.MultipleFactor_lbl.TabIndex = 134
        Me.MultipleFactor_lbl.Text = "MultipleFactor"
        Me.MultipleFactor_lbl.Visible = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Appearance.Options.UseTextOptions = True
        Me.LabelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl7.LineVisible = True
        Me.LabelControl7.Location = New System.Drawing.Point(474, 48)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(129, 20)
        Me.LabelControl7.TabIndex = 133
        Me.LabelControl7.Text = "Multiple Factor"
        Me.LabelControl7.Visible = False
        '
        'CapitalForSolvV_lbl
        '
        Me.CapitalForSolvV_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapitalForSolvV_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CapitalForSolvV_lbl.Appearance.Options.UseFont = True
        Me.CapitalForSolvV_lbl.Appearance.Options.UseForeColor = True
        Me.CapitalForSolvV_lbl.Appearance.Options.UseTextOptions = True
        Me.CapitalForSolvV_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CapitalForSolvV_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CapitalForSolvV_lbl.Location = New System.Drawing.Point(294, 67)
        Me.CapitalForSolvV_lbl.Name = "CapitalForSolvV_lbl"
        Me.CapitalForSolvV_lbl.Size = New System.Drawing.Size(174, 22)
        ToolTipTitleItem4.Appearance.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem4.Appearance.Options.UseImage = True
        ToolTipTitleItem4.ImageOptions.Image = Global.PS_TOOL_DX.My.Resources.Resources.Info
        ToolTipTitleItem4.Text = "Capital for SolvV"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "    Dotation Capital" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "+ Specific Retained Earnings" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-  Intangible Assets (BAIS)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    ""
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.CapitalForSolvV_lbl.SuperTip = SuperToolTip4
        Me.CapitalForSolvV_lbl.TabIndex = 132
        Me.CapitalForSolvV_lbl.Text = "CapitalForSolvV"
        Me.CapitalForSolvV_lbl.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseTextOptions = True
        Me.LabelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.LineColor = System.Drawing.Color.Aqua
        Me.LabelControl5.LineVisible = True
        Me.LabelControl5.Location = New System.Drawing.Point(294, 48)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(174, 20)
        Me.LabelControl5.TabIndex = 131
        Me.LabelControl5.Text = "Capital for SolvV"
        Me.LabelControl5.Visible = False
        '
        'Print_Export_LiqV_Totals_Gridview_btn
        '
        Me.Print_Export_LiqV_Totals_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_LiqV_Totals_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_LiqV_Totals_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_LiqV_Totals_Gridview_btn.Location = New System.Drawing.Point(14, 15)
        Me.Print_Export_LiqV_Totals_Gridview_btn.Name = "Print_Export_LiqV_Totals_Gridview_btn"
        Me.Print_Export_LiqV_Totals_Gridview_btn.Size = New System.Drawing.Size(158, 22)
        Me.Print_Export_LiqV_Totals_Gridview_btn.TabIndex = 6
        Me.Print_Export_LiqV_Totals_Gridview_btn.Text = "Print or Export"
        '
        'CAR_Calc_Report_btn
        '
        Me.CAR_Calc_Report_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CAR_Calc_Report_btn.ImageOptions.ImageIndex = 3
        Me.CAR_Calc_Report_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.CAR_Calc_Report_btn.Location = New System.Drawing.Point(424, 15)
        Me.CAR_Calc_Report_btn.Name = "CAR_Calc_Report_btn"
        Me.CAR_Calc_Report_btn.Size = New System.Drawing.Size(231, 22)
        Me.CAR_Calc_Report_btn.TabIndex = 5
        Me.CAR_Calc_Report_btn.Text = "CAR Calculation Report"
        Me.CAR_Calc_Report_btn.Visible = False
        '
        'SQL_Commands_Dropdownbutton
        '
        Me.SQL_Commands_Dropdownbutton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.SQL_Commands_Dropdownbutton.DropDownControl = Me.PopupMenu1
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageIndex = 2
        Me.SQL_Commands_Dropdownbutton.ImageOptions.ImageList = Me.ImageCollection1
        Me.SQL_Commands_Dropdownbutton.Location = New System.Drawing.Point(178, 15)
        Me.SQL_Commands_Dropdownbutton.Name = "SQL_Commands_Dropdownbutton"
        Me.SQL_Commands_Dropdownbutton.Size = New System.Drawing.Size(240, 22)
        Me.SQL_Commands_Dropdownbutton.TabIndex = 7
        Me.SQL_Commands_Dropdownbutton.Text = "LiqV Calculation"
        '
        'CAR_CALC_Details_XtraTabPage
        '
        Me.CAR_CALC_Details_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_CALC_Details_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.CAR_CALC_Details_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_CALC_Details_XtraTabPage.Controls.Add(Me.LayoutControl3)
        Me.CAR_CALC_Details_XtraTabPage.Name = "CAR_CALC_Details_XtraTabPage"
        Me.CAR_CALC_Details_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_CALC_Details_XtraTabPage.Size = New System.Drawing.Size(1478, 641)
        Me.CAR_CALC_Details_XtraTabPage.Text = "LiqV - ALL DETAILS"
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
        Me.LayoutControl3.Size = New System.Drawing.Size(1478, 641)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.DropDownButton1.DropDownControl = Me.PopupMenu1
        Me.DropDownButton1.ImageOptions.ImageIndex = 2
        Me.DropDownButton1.ImageOptions.ImageList = Me.ImageCollection1
        Me.DropDownButton1.Location = New System.Drawing.Point(396, 24)
        Me.DropDownButton1.Name = "DropDownButton1"
        Me.DropDownButton1.Size = New System.Drawing.Size(233, 22)
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
        Me.Print_Export_All_DetailsAll_Gridview_btn.Size = New System.Drawing.Size(169, 22)
        Me.Print_Export_All_DetailsAll_Gridview_btn.StyleController = Me.LayoutControl3
        Me.Print_Export_All_DetailsAll_Gridview_btn.TabIndex = 6
        Me.Print_Export_All_DetailsAll_Gridview_btn.Text = "Print or Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton2.ImageOptions.ImageIndex = 3
        Me.SimpleButton2.ImageOptions.ImageList = Me.ImageCollection1
        Me.SimpleButton2.Location = New System.Drawing.Point(197, 24)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(195, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl3
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Business Types Report"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton3.ImageOptions.ImageIndex = 5
        Me.SimpleButton3.Location = New System.Drawing.Point(1378, 24)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(76, 22)
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
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1478, 641)
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.EmptySpaceItem2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem9})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1458, 621)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButton3
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(1354, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem2"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(80, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(609, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(745, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.Print_Export_All_DetailsAll_Gridview_btn
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem4"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.DropDownButton1
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(372, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem7"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        Me.LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.SimpleButton2
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(173, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem3"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(199, 26)
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
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1434, 571)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'CAR_PARAM_XtraTabPage
        '
        Me.CAR_PARAM_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CAR_PARAM_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.CAR_PARAM_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.CAR_PARAM_XtraTabPage.Controls.Add(Me.LayoutControl1)
        Me.CAR_PARAM_XtraTabPage.Name = "CAR_PARAM_XtraTabPage"
        Me.CAR_PARAM_XtraTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAR_PARAM_XtraTabPage.Size = New System.Drawing.Size(1478, 641)
        Me.CAR_PARAM_XtraTabPage.Text = "LiqV Details Calculation"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl4)
        Me.LayoutControl1.Controls.Add(Me.Load_LiqV_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.LiqV_Date_Comboedit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1478, 641)
        Me.LayoutControl1.TabIndex = 118
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Load_LiqV_Details_btn
        '
        Me.Load_LiqV_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Load_LiqV_Details_btn.ImageOptions.ImageIndex = 0
        Me.Load_LiqV_Details_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Load_LiqV_Details_btn.Location = New System.Drawing.Point(192, 42)
        Me.Load_LiqV_Details_btn.Name = "Load_LiqV_Details_btn"
        Me.Load_LiqV_Details_btn.Size = New System.Drawing.Size(174, 22)
        Me.Load_LiqV_Details_btn.StyleController = Me.LayoutControl1
        Me.Load_LiqV_Details_btn.TabIndex = 128
        Me.Load_LiqV_Details_btn.Text = "Calculate LiqV Details"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(370, 42)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(208, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 6
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'LiqV_Date_Comboedit
        '
        Me.LiqV_Date_Comboedit.Location = New System.Drawing.Point(54, 42)
        Me.LiqV_Date_Comboedit.Name = "LiqV_Date_Comboedit"
        Me.LiqV_Date_Comboedit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LiqV_Date_Comboedit.Properties.Appearance.Options.UseFont = True
        Me.LiqV_Date_Comboedit.Properties.Appearance.Options.UseTextOptions = True
        Me.LiqV_Date_Comboedit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.LiqV_Date_Comboedit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LiqV_Date_Comboedit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LiqV_Date_Comboedit.Properties.MaxLength = 8
        Me.LiqV_Date_Comboedit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.LiqV_Date_Comboedit.Size = New System.Drawing.Size(134, 22)
        Me.LiqV_Date_Comboedit.StyleController = Me.LayoutControl1
        Me.LiqV_Date_Comboedit.TabIndex = 128
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1478, 641)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.LayoutControlGroup3.CustomizationFormText = "AfA - Detailbericht"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem2})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1458, 621)
        Me.LayoutControlGroup3.Text = "LiqV Details calculation"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(558, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(876, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem7.Control = Me.LiqV_Date_Comboedit
        Me.LayoutControlItem7.CustomizationFormText = "Date"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(168, 26)
        Me.LayoutControlItem7.Text = "Date"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(27, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Load_LiqV_Details_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(168, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem9"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(346, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(212, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl4
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem1"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1434, 553)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LiqV_Details_TotalsTableAdapter
        '
        Me.LiqV_Details_TotalsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.LiqV_Details_All1TableAdapter = Me.LiqV_Details_All1TableAdapter
        Me.TableAdapterManager.LiqV_Details_AllTableAdapter = Me.LiqV_Details_AllTableAdapter
        Me.TableAdapterManager.LiqV_Details_TotalsTableAdapter = Me.LiqV_Details_TotalsTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.LiqV_DatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LiqV_Details_All1TableAdapter
        '
        Me.LiqV_Details_All1TableAdapter.ClearBeforeFill = True
        '
        'LiqV_Details_AllTableAdapter
        '
        Me.LiqV_Details_AllTableAdapter.ClearBeforeFill = True
        '
        'LiqV_Details_AllBindingSource
        '
        Me.LiqV_Details_AllBindingSource.DataMember = "FK_LiqV_Details_All_LiqV_Details_Totals"
        Me.LiqV_Details_AllBindingSource.DataSource = Me.LiqV_Details_TotalsBindingSource
        '
        'LiqV_Calc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1496, 746)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LoadBusinessTypes_btn)
        Me.Controls.Add(Me.LiqV_DateEdit_ComboEdit)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LiqV_Calc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LiqV (Liquidity Ratio) Calculation"
        CType(Me.LiqV_Details_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_Details_TotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_Dataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_Totals_BandedGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LiqV_Details_All1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_DetailsAll_Gridview, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiquidityCalculation_GridView, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_DateEdit_ComboEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LiqV_Date_Comboedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LiqV_Details_AllBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadBusinessTypes_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LiqV_DateEdit_ComboEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents CAR_CALC_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LiqV_Value_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CapitalSurplus_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MaxLendingLimit_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MultipleFactor_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CapitalForSolvV_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Print_Export_LiqV_Totals_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CAR_Calc_Report_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SQL_Commands_Dropdownbutton As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents LiqV_Details_GridView As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents LiqV_DetailsAll_Gridview As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents LiqV_Details_TotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LiqV_Dataset As PS_TOOL_DX.LiqV_Dataset
    Friend WithEvents LiqV_Details_TotalsTableAdapter As PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_TotalsTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.LiqV_DatasetTableAdapters.TableAdapterManager
    Friend WithEvents LiqV_Details_AllTableAdapter As PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_AllTableAdapter
    Friend WithEvents LiqV_Details_AllBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LiqV_Details_All1TableAdapter As PS_TOOL_DX.LiqV_DatasetTableAdapters.LiqV_Details_All1TableAdapter
    Friend WithEvents LiqV_Details_All1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZeilenNr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZahlungsart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBusinessType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractCollateralID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEventDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFactor1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLaufzeitband As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaturityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrgCcyAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colId_LiqV_Totals As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnrechnungsBetrag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountEurWithoutInterest As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LiqV_Totals_BandedGridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents LiquidityCalculation_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCustomerName As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents LayoutViewField1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn91 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn92 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn93 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn94 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn95 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn96 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn97 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn98 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn99 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField10 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn100 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField11 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard4 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn96 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn97 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn98 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn99 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn100 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn101 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn102 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn103 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn104 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn105 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn106 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn107 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn108 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn109 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn110 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn111 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn112 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn113 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn114 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn115 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn116 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn117 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn118 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn119 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn120 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn121 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn122 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn123 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn124 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn125 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn126 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn127 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Load_LiqV_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LiqV_Date_Comboedit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink3 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupName2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZeilenNr2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountEurWithoutInterest1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFactor2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnrechnungsBetrag1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colId_LiqV_Totals1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRiskDate2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
End Class
