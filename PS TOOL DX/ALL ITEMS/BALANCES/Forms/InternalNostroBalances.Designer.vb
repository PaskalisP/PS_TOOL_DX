<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalNostroBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalNostroBalances))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.colLedgerBalanceEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueBalanceEUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBatchNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.SSISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SSISTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.SSISTableAdapter()
        Me.TableAdapterManager1 = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.BalancesDataset = New PS_TOOL_DX.BalancesDataset()
        Me.NOSTRO_BALANCESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NOSTRO_BALANCESTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.NOSTRO_BALANCESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.Nostro_Balances_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNostroCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNostroName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGLCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLedgerBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBalanceDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchange_Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.OdasImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.OCBS_Balances_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIdNr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSequenceNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGLBook1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountingCentre1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_No1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTransactionTime1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEventType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCCY1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDR_CR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPortfolioCode1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNarrativeCode1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReferenceCode1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChequeNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAP1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRNAccountingCentre1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCheckerID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannel1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOtherSystemKey1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGeneratedType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReversalFlag1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Rep_Date1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Item_Nr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_No_Name1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExchange_Rate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountInEuro1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OCBS_Postings_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientName2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LoadOCBS_PostingsBalances_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.NostroAccountNamelbl = New DevExpress.XtraEditors.LabelControl()
        Me.CURlbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_LookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINTERNALACCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINTERNALIBAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRESPONDENTBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOSTRO_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRESPONDENTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXTERNALACCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINTERMEDIARYBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINTERMEDIARYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox_Valid = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.LoadOCBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_BookingDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.OCBS_BookingDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.SearchText_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NOSTRO_BALANCESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nostro_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_Postings_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.OCBS_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox_Valid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colLedgerBalanceEUR
        '
        Me.colLedgerBalanceEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colLedgerBalanceEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLedgerBalanceEUR.AppearanceHeader.ForeColor = System.Drawing.Color.Cyan
        Me.colLedgerBalanceEUR.AppearanceHeader.Options.UseForeColor = True
        Me.colLedgerBalanceEUR.DisplayFormat.FormatString = "n2"
        Me.colLedgerBalanceEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLedgerBalanceEUR.FieldName = "Ledger Balance EUR"
        Me.colLedgerBalanceEUR.Name = "colLedgerBalanceEUR"
        Me.colLedgerBalanceEUR.OptionsColumn.AllowEdit = False
        Me.colLedgerBalanceEUR.OptionsColumn.ReadOnly = True
        Me.colLedgerBalanceEUR.Visible = True
        Me.colLedgerBalanceEUR.VisibleIndex = 7
        Me.colLedgerBalanceEUR.Width = 121
        '
        'colValueBalanceEUR
        '
        Me.colValueBalanceEUR.AppearanceCell.Options.UseTextOptions = True
        Me.colValueBalanceEUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colValueBalanceEUR.AppearanceHeader.ForeColor = System.Drawing.Color.Cyan
        Me.colValueBalanceEUR.AppearanceHeader.Options.UseForeColor = True
        Me.colValueBalanceEUR.DisplayFormat.FormatString = "n2"
        Me.colValueBalanceEUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValueBalanceEUR.FieldName = "Value Balance EUR"
        Me.colValueBalanceEUR.Name = "colValueBalanceEUR"
        Me.colValueBalanceEUR.OptionsColumn.AllowEdit = False
        Me.colValueBalanceEUR.OptionsColumn.ReadOnly = True
        Me.colValueBalanceEUR.Visible = True
        Me.colValueBalanceEUR.VisibleIndex = 8
        Me.colValueBalanceEUR.Width = 117
        '
        'colBatchNo1
        '
        Me.colBatchNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colBatchNo1.AppearanceHeader.Options.UseFont = True
        Me.colBatchNo1.FieldName = "BatchNo"
        Me.colBatchNo1.Name = "colBatchNo1"
        Me.colBatchNo1.OptionsColumn.AllowEdit = False
        Me.colBatchNo1.OptionsColumn.ReadOnly = True
        Me.colBatchNo1.Visible = True
        Me.colBatchNo1.VisibleIndex = 2
        Me.colBatchNo1.Width = 200
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "BatchNo"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 273
        '
        'GridColumn17
        '
        Me.GridColumn17.DisplayFormat.FormatString = "n2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "Amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 4
        Me.GridColumn17.Width = 105
        '
        'GridColumn37
        '
        Me.GridColumn37.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn37.AppearanceHeader.Options.UseBorderColor = True
        Me.GridColumn37.AppearanceHeader.Options.UseFont = True
        Me.GridColumn37.AppearanceHeader.Options.UseImage = True
        Me.GridColumn37.CustomizationCaption = "Amount in EUR"
        Me.GridColumn37.DisplayFormat.FormatString = "n2"
        Me.GridColumn37.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn37.FieldName = "AmountInEuro"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.OptionsColumn.ReadOnly = True
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 6
        Me.GridColumn37.Width = 152
        '
        'GridColumn14
        '
        Me.GridColumn14.FieldName = "Product Type"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'GridColumn34
        '
        Me.GridColumn34.CustomizationCaption = "Amount in EUR"
        Me.GridColumn34.FieldName = "GL_Item_Nr"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SSISBindingSource
        '
        Me.SSISBindingSource.DataMember = "SSIS"
        Me.SSISBindingSource.DataSource = Me.PSTOOLDataset
        '
        'SSISTableAdapter
        '
        Me.SSISTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager1.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager1.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.BANKTableAdapter = Nothing
        Me.TableAdapterManager1.CalendarTableAdapter = Nothing
        Me.TableAdapterManager1.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager1.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager1.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager1.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTS_BAISTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTS_NEWGTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager1.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager1.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager1.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager1.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager1.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager1.SSISTableAdapter = Me.SSISTableAdapter
        Me.TableAdapterManager1.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'BalancesDataset
        '
        Me.BalancesDataset.DataSetName = "BalancesDataset"
        Me.BalancesDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'NOSTRO_BALANCESBindingSource
        '
        Me.NOSTRO_BALANCESBindingSource.DataMember = "NOSTRO BALANCES"
        Me.NOSTRO_BALANCESBindingSource.DataSource = Me.BalancesDataset
        '
        'NOSTRO_BALANCESTableAdapter
        '
        Me.NOSTRO_BALANCESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_VOSTRO_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.NOSTRO_BALANCESTableAdapter = Me.NOSTRO_BALANCESTableAdapter
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.SUSPENCE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.SWIFT_ACC_STATEMENTSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "cancel_16x16.png")
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
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(12, 82)
        Me.GridControl1.MainView = Me.Nostro_Balances_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1436, 483)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Nostro_Balances_BasicView, Me.OCBS_Balances_BasicView, Me.OCBS_Postings_BasicView})
        '
        'Nostro_Balances_BasicView
        '
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Nostro_Balances_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Nostro_Balances_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Nostro_Balances_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIdNr, Me.colCurrency, Me.colNostroCode, Me.colNostroName, Me.colGLCode, Me.colLedgerBalance, Me.colValueBalance, Me.colBalanceDate, Me.colExchange_Rate, Me.colLedgerBalanceEUR, Me.colValueBalanceEUR})
        Me.Nostro_Balances_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Cyan
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Cyan
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Column = Me.colLedgerBalanceEUR
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[Ledger Balance EUR] != ?"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Cyan
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.Cyan
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Column = Me.colValueBalanceEUR
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[Value Balance EUR] != ?"
        Me.Nostro_Balances_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.Nostro_Balances_BasicView.GridControl = Me.GridControl1
        Me.Nostro_Balances_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ledger Balance", Me.colLedgerBalance, "SUM={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value Balance", Me.colValueBalance, "SUM={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Ledger Balance EUR", Me.colLedgerBalanceEUR, "SUM={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value Balance EUR", Me.colValueBalanceEUR, "SUM={0:n2}")})
        Me.Nostro_Balances_BasicView.Name = "Nostro_Balances_BasicView"
        Me.Nostro_Balances_BasicView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Nostro_Balances_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Nostro_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Nostro_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Nostro_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.Nostro_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.Nostro_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.Nostro_Balances_BasicView.OptionsMenu.ShowFooterItem = True
        Me.Nostro_Balances_BasicView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Nostro_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.Nostro_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.Nostro_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.Nostro_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.Nostro_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Nostro_Balances_BasicView.OptionsView.ShowFooter = True
        Me.Nostro_Balances_BasicView.OptionsView.ShowGroupPanel = False
        Me.Nostro_Balances_BasicView.PaintStyleName = "Skin"
        Me.Nostro_Balances_BasicView.ViewCaption = "Results by GL Item"
        '
        'colIdNr
        '
        Me.colIdNr.FieldName = "IdNr"
        Me.colIdNr.Name = "colIdNr"
        Me.colIdNr.OptionsColumn.AllowEdit = False
        Me.colIdNr.OptionsColumn.ReadOnly = True
        '
        'colCurrency
        '
        Me.colCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.colCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCurrency.FieldName = "Currency"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.OptionsColumn.AllowEdit = False
        Me.colCurrency.OptionsColumn.ReadOnly = True
        Me.colCurrency.Visible = True
        Me.colCurrency.VisibleIndex = 1
        Me.colCurrency.Width = 57
        '
        'colNostroCode
        '
        Me.colNostroCode.Caption = "Nostro Account"
        Me.colNostroCode.FieldName = "Nostro Code"
        Me.colNostroCode.Name = "colNostroCode"
        Me.colNostroCode.OptionsColumn.AllowEdit = False
        Me.colNostroCode.OptionsColumn.ReadOnly = True
        Me.colNostroCode.Visible = True
        Me.colNostroCode.VisibleIndex = 2
        Me.colNostroCode.Width = 108
        '
        'colNostroName
        '
        Me.colNostroName.Caption = "Account Name"
        Me.colNostroName.FieldName = "Nostro Name"
        Me.colNostroName.Name = "colNostroName"
        Me.colNostroName.OptionsColumn.AllowEdit = False
        Me.colNostroName.OptionsColumn.ReadOnly = True
        Me.colNostroName.Visible = True
        Me.colNostroName.VisibleIndex = 3
        Me.colNostroName.Width = 364
        '
        'colGLCode
        '
        Me.colGLCode.FieldName = "GL Code"
        Me.colGLCode.Name = "colGLCode"
        Me.colGLCode.OptionsColumn.AllowEdit = False
        Me.colGLCode.OptionsColumn.ReadOnly = True
        Me.colGLCode.Width = 89
        '
        'colLedgerBalance
        '
        Me.colLedgerBalance.AppearanceCell.Options.UseTextOptions = True
        Me.colLedgerBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLedgerBalance.DisplayFormat.FormatString = "n2"
        Me.colLedgerBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLedgerBalance.FieldName = "Ledger Balance"
        Me.colLedgerBalance.Name = "colLedgerBalance"
        Me.colLedgerBalance.OptionsColumn.AllowEdit = False
        Me.colLedgerBalance.OptionsColumn.ReadOnly = True
        Me.colLedgerBalance.Visible = True
        Me.colLedgerBalance.VisibleIndex = 4
        Me.colLedgerBalance.Width = 117
        '
        'colValueBalance
        '
        Me.colValueBalance.AppearanceCell.Options.UseTextOptions = True
        Me.colValueBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colValueBalance.DisplayFormat.FormatString = "n2"
        Me.colValueBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValueBalance.FieldName = "Value Balance"
        Me.colValueBalance.Name = "colValueBalance"
        Me.colValueBalance.OptionsColumn.AllowEdit = False
        Me.colValueBalance.OptionsColumn.ReadOnly = True
        Me.colValueBalance.Visible = True
        Me.colValueBalance.VisibleIndex = 5
        Me.colValueBalance.Width = 117
        '
        'colBalanceDate
        '
        Me.colBalanceDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBalanceDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBalanceDate.Caption = "Booking Date"
        Me.colBalanceDate.FieldName = "BalanceDate"
        Me.colBalanceDate.Name = "colBalanceDate"
        Me.colBalanceDate.OptionsColumn.AllowEdit = False
        Me.colBalanceDate.OptionsColumn.ReadOnly = True
        Me.colBalanceDate.Visible = True
        Me.colBalanceDate.VisibleIndex = 0
        Me.colBalanceDate.Width = 90
        '
        'colExchange_Rate
        '
        Me.colExchange_Rate.AppearanceCell.Options.UseTextOptions = True
        Me.colExchange_Rate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colExchange_Rate.Caption = "Exchange Rate"
        Me.colExchange_Rate.DisplayFormat.FormatString = "n5"
        Me.colExchange_Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchange_Rate.FieldName = "Exchange_Rate"
        Me.colExchange_Rate.Name = "colExchange_Rate"
        Me.colExchange_Rate.OptionsColumn.AllowEdit = False
        Me.colExchange_Rate.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate.Visible = True
        Me.colExchange_Rate.VisibleIndex = 6
        Me.colExchange_Rate.Width = 97
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
        'OdasImportProcedureRepositoryItemTextEdit
        '
        Me.OdasImportProcedureRepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseFont = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.OdasImportProcedureRepositoryItemTextEdit.AutoHeight = False
        Me.OdasImportProcedureRepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OdasImportProcedureRepositoryItemTextEdit.Name = "OdasImportProcedureRepositoryItemTextEdit"
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
        Me.RepositoryItemMemoExEdit2.ShowIcon = False
        '
        'ValidRepositoryItemImageComboBox
        '
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.ValidRepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.ValidRepositoryItemImageComboBox.AutoHeight = False
        Me.ValidRepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidRepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CANCELLED", "N", 3)})
        Me.ValidRepositoryItemImageComboBox.Name = "ValidRepositoryItemImageComboBox"
        '
        'OCBS_Balances_BasicView
        '
        Me.OCBS_Balances_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_Balances_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_Balances_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.OCBS_Balances_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.OCBS_Balances_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.OCBS_Balances_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIdNr1, Me.colBatchNo1, Me.colSequenceNo1, Me.colGLBook1, Me.colAccountingCentre1, Me.colGL_AC_No1, Me.colValueDate1, Me.colTransactionTime1, Me.colAccountNo1, Me.colContractType1, Me.colProductType1, Me.colEventType1, Me.colCCY1, Me.colAmount1, Me.colDR_CR1, Me.colGroupNo1, Me.colClientNo1, Me.colPortfolioCode1, Me.colNarrativeCode1, Me.colReferenceCode1, Me.colChequeNo1, Me.colAP1, Me.colTRNAccountingCentre1, Me.colCheckerID1, Me.colChannel1, Me.colOtherSystemKey1, Me.colGeneratedType1, Me.colReversalFlag1, Me.colDescription1, Me.colGL_Rep_Date1, Me.colGL_Item_Nr1, Me.colGL_AC_No_Name1, Me.colExchange_Rate1, Me.colAmountInEuro1})
        Me.OCBS_Balances_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Aqua
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseFont = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Appearance.Options.UseTextOptions = True
        StyleFormatCondition3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Column = Me.colBatchNo1
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition3.Expression = "OPENING BALANCE OCBS ACC."
        StyleFormatCondition3.Value1 = "OPENING BALANCE OCBS ACC."
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Aqua
        StyleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.Cyan
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseFont = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Appearance.Options.UseTextOptions = True
        StyleFormatCondition4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        StyleFormatCondition4.ApplyToRow = True
        StyleFormatCondition4.Column = Me.colBatchNo1
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition4.Expression = "CLOSING BALANCE OCBS ACC."
        StyleFormatCondition4.Value1 = "CLOSING BALANCE OCBS ACC."
        Me.OCBS_Balances_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4})
        Me.OCBS_Balances_BasicView.GridControl = Me.GridControl1
        Me.OCBS_Balances_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Me.colAmount1, "SUM={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountInEuro", Me.colAmountInEuro1, "SUM={0:n2}")})
        Me.OCBS_Balances_BasicView.Name = "OCBS_Balances_BasicView"
        Me.OCBS_Balances_BasicView.OptionsBehavior.AutoExpandAllGroups = True
        Me.OCBS_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.OCBS_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.OCBS_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.OCBS_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.OCBS_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.OCBS_Balances_BasicView.OptionsMenu.ShowFooterItem = True
        Me.OCBS_Balances_BasicView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.OCBS_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.OCBS_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.OCBS_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.OCBS_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.OCBS_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OCBS_Balances_BasicView.OptionsView.ShowFooter = True
        Me.OCBS_Balances_BasicView.OptionsView.ShowGroupPanel = False
        '
        'colIdNr1
        '
        Me.colIdNr1.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control
        Me.colIdNr1.AppearanceHeader.BackColor2 = System.Drawing.SystemColors.Control
        Me.colIdNr1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colIdNr1.AppearanceHeader.ForeColor = System.Drawing.Color.Navy
        Me.colIdNr1.AppearanceHeader.Options.UseBackColor = True
        Me.colIdNr1.AppearanceHeader.Options.UseFont = True
        Me.colIdNr1.AppearanceHeader.Options.UseForeColor = True
        Me.colIdNr1.FieldName = "IdNr"
        Me.colIdNr1.Name = "colIdNr1"
        Me.colIdNr1.OptionsColumn.AllowEdit = False
        Me.colIdNr1.OptionsColumn.ReadOnly = True
        '
        'colSequenceNo1
        '
        Me.colSequenceNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colSequenceNo1.AppearanceHeader.Options.UseFont = True
        Me.colSequenceNo1.FieldName = "SequenceNo"
        Me.colSequenceNo1.Name = "colSequenceNo1"
        Me.colSequenceNo1.OptionsColumn.AllowEdit = False
        Me.colSequenceNo1.OptionsColumn.ReadOnly = True
        '
        'colGLBook1
        '
        Me.colGLBook1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGLBook1.AppearanceHeader.Options.UseFont = True
        Me.colGLBook1.FieldName = "GL Book"
        Me.colGLBook1.Name = "colGLBook1"
        Me.colGLBook1.OptionsColumn.AllowEdit = False
        Me.colGLBook1.OptionsColumn.ReadOnly = True
        '
        'colAccountingCentre1
        '
        Me.colAccountingCentre1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colAccountingCentre1.AppearanceHeader.Options.UseFont = True
        Me.colAccountingCentre1.FieldName = "Accounting Centre"
        Me.colAccountingCentre1.Name = "colAccountingCentre1"
        Me.colAccountingCentre1.OptionsColumn.AllowEdit = False
        Me.colAccountingCentre1.OptionsColumn.ReadOnly = True
        '
        'colGL_AC_No1
        '
        Me.colGL_AC_No1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGL_AC_No1.AppearanceHeader.Options.UseFont = True
        Me.colGL_AC_No1.Caption = "OCBS Account Nr."
        Me.colGL_AC_No1.FieldName = "GL_AC_No"
        Me.colGL_AC_No1.Name = "colGL_AC_No1"
        Me.colGL_AC_No1.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No1.OptionsColumn.ReadOnly = True
        '
        'colValueDate1
        '
        Me.colValueDate1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colValueDate1.AppearanceHeader.Options.UseFont = True
        Me.colValueDate1.FieldName = "Value Date"
        Me.colValueDate1.Name = "colValueDate1"
        Me.colValueDate1.OptionsColumn.AllowEdit = False
        Me.colValueDate1.OptionsColumn.ReadOnly = True
        Me.colValueDate1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.colValueDate1.Visible = True
        Me.colValueDate1.VisibleIndex = 1
        Me.colValueDate1.Width = 95
        '
        'colTransactionTime1
        '
        Me.colTransactionTime1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colTransactionTime1.AppearanceHeader.Options.UseFont = True
        Me.colTransactionTime1.FieldName = "Transaction Time"
        Me.colTransactionTime1.Name = "colTransactionTime1"
        Me.colTransactionTime1.OptionsColumn.AllowEdit = False
        Me.colTransactionTime1.OptionsColumn.ReadOnly = True
        '
        'colAccountNo1
        '
        Me.colAccountNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colAccountNo1.AppearanceHeader.Options.UseFont = True
        Me.colAccountNo1.FieldName = "AccountNo"
        Me.colAccountNo1.Name = "colAccountNo1"
        Me.colAccountNo1.OptionsColumn.AllowEdit = False
        Me.colAccountNo1.OptionsColumn.ReadOnly = True
        Me.colAccountNo1.Width = 86
        '
        'colContractType1
        '
        Me.colContractType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colContractType1.AppearanceHeader.Options.UseFont = True
        Me.colContractType1.FieldName = "Contract Type"
        Me.colContractType1.Name = "colContractType1"
        Me.colContractType1.OptionsColumn.AllowEdit = False
        Me.colContractType1.OptionsColumn.ReadOnly = True
        '
        'colProductType1
        '
        Me.colProductType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colProductType1.AppearanceHeader.Options.UseFont = True
        Me.colProductType1.FieldName = "Product Type"
        Me.colProductType1.Name = "colProductType1"
        Me.colProductType1.OptionsColumn.AllowEdit = False
        Me.colProductType1.OptionsColumn.ReadOnly = True
        '
        'colEventType1
        '
        Me.colEventType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colEventType1.AppearanceHeader.Options.UseFont = True
        Me.colEventType1.FieldName = "Event Type"
        Me.colEventType1.Name = "colEventType1"
        Me.colEventType1.OptionsColumn.AllowEdit = False
        Me.colEventType1.OptionsColumn.ReadOnly = True
        '
        'colCCY1
        '
        Me.colCCY1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colCCY1.AppearanceHeader.Options.UseFont = True
        Me.colCCY1.FieldName = "CCY"
        Me.colCCY1.Name = "colCCY1"
        Me.colCCY1.OptionsColumn.AllowEdit = False
        Me.colCCY1.OptionsColumn.ReadOnly = True
        Me.colCCY1.Visible = True
        Me.colCCY1.VisibleIndex = 3
        Me.colCCY1.Width = 44
        '
        'colAmount1
        '
        Me.colAmount1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colAmount1.AppearanceHeader.Options.UseFont = True
        Me.colAmount1.DisplayFormat.FormatString = "#,##0.00"
        Me.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount1.FieldName = "Amount"
        Me.colAmount1.Name = "colAmount1"
        Me.colAmount1.OptionsColumn.AllowEdit = False
        Me.colAmount1.OptionsColumn.ReadOnly = True
        Me.colAmount1.Visible = True
        Me.colAmount1.VisibleIndex = 4
        Me.colAmount1.Width = 99
        '
        'colDR_CR1
        '
        Me.colDR_CR1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colDR_CR1.AppearanceHeader.Options.UseFont = True
        Me.colDR_CR1.FieldName = "DR_CR"
        Me.colDR_CR1.Name = "colDR_CR1"
        Me.colDR_CR1.OptionsColumn.AllowEdit = False
        Me.colDR_CR1.OptionsColumn.ReadOnly = True
        '
        'colGroupNo1
        '
        Me.colGroupNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGroupNo1.AppearanceHeader.Options.UseFont = True
        Me.colGroupNo1.FieldName = "GroupNo"
        Me.colGroupNo1.Name = "colGroupNo1"
        Me.colGroupNo1.OptionsColumn.AllowEdit = False
        Me.colGroupNo1.OptionsColumn.ReadOnly = True
        '
        'colClientNo1
        '
        Me.colClientNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colClientNo1.AppearanceHeader.Options.UseFont = True
        Me.colClientNo1.FieldName = "ClientNo"
        Me.colClientNo1.Name = "colClientNo1"
        Me.colClientNo1.OptionsColumn.AllowEdit = False
        Me.colClientNo1.OptionsColumn.ReadOnly = True
        '
        'colPortfolioCode1
        '
        Me.colPortfolioCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colPortfolioCode1.AppearanceHeader.Options.UseFont = True
        Me.colPortfolioCode1.FieldName = "Portfolio Code"
        Me.colPortfolioCode1.Name = "colPortfolioCode1"
        Me.colPortfolioCode1.OptionsColumn.AllowEdit = False
        Me.colPortfolioCode1.OptionsColumn.ReadOnly = True
        '
        'colNarrativeCode1
        '
        Me.colNarrativeCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colNarrativeCode1.AppearanceHeader.Options.UseFont = True
        Me.colNarrativeCode1.FieldName = "Narrative Code"
        Me.colNarrativeCode1.Name = "colNarrativeCode1"
        Me.colNarrativeCode1.OptionsColumn.AllowEdit = False
        Me.colNarrativeCode1.OptionsColumn.ReadOnly = True
        '
        'colReferenceCode1
        '
        Me.colReferenceCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colReferenceCode1.AppearanceHeader.Options.UseFont = True
        Me.colReferenceCode1.FieldName = "Reference Code"
        Me.colReferenceCode1.Name = "colReferenceCode1"
        Me.colReferenceCode1.OptionsColumn.AllowEdit = False
        Me.colReferenceCode1.OptionsColumn.ReadOnly = True
        '
        'colChequeNo1
        '
        Me.colChequeNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colChequeNo1.AppearanceHeader.Options.UseFont = True
        Me.colChequeNo1.FieldName = "ChequeNo"
        Me.colChequeNo1.Name = "colChequeNo1"
        Me.colChequeNo1.OptionsColumn.AllowEdit = False
        Me.colChequeNo1.OptionsColumn.ReadOnly = True
        '
        'colAP1
        '
        Me.colAP1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colAP1.AppearanceHeader.Options.UseFont = True
        Me.colAP1.FieldName = "AP"
        Me.colAP1.Name = "colAP1"
        Me.colAP1.OptionsColumn.AllowEdit = False
        Me.colAP1.OptionsColumn.ReadOnly = True
        '
        'colTRNAccountingCentre1
        '
        Me.colTRNAccountingCentre1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colTRNAccountingCentre1.AppearanceHeader.Options.UseFont = True
        Me.colTRNAccountingCentre1.FieldName = "TRN Accounting Centre"
        Me.colTRNAccountingCentre1.Name = "colTRNAccountingCentre1"
        Me.colTRNAccountingCentre1.OptionsColumn.AllowEdit = False
        Me.colTRNAccountingCentre1.OptionsColumn.ReadOnly = True
        '
        'colCheckerID1
        '
        Me.colCheckerID1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colCheckerID1.AppearanceHeader.Options.UseFont = True
        Me.colCheckerID1.FieldName = "Checker ID"
        Me.colCheckerID1.Name = "colCheckerID1"
        Me.colCheckerID1.OptionsColumn.AllowEdit = False
        Me.colCheckerID1.OptionsColumn.ReadOnly = True
        '
        'colChannel1
        '
        Me.colChannel1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colChannel1.AppearanceHeader.Options.UseFont = True
        Me.colChannel1.FieldName = "Channel"
        Me.colChannel1.Name = "colChannel1"
        Me.colChannel1.OptionsColumn.AllowEdit = False
        Me.colChannel1.OptionsColumn.ReadOnly = True
        '
        'colOtherSystemKey1
        '
        Me.colOtherSystemKey1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colOtherSystemKey1.AppearanceHeader.Options.UseFont = True
        Me.colOtherSystemKey1.FieldName = "Other System Key"
        Me.colOtherSystemKey1.Name = "colOtherSystemKey1"
        Me.colOtherSystemKey1.OptionsColumn.AllowEdit = False
        Me.colOtherSystemKey1.OptionsColumn.ReadOnly = True
        '
        'colGeneratedType1
        '
        Me.colGeneratedType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGeneratedType1.AppearanceHeader.Options.UseFont = True
        Me.colGeneratedType1.FieldName = "Generated Type"
        Me.colGeneratedType1.Name = "colGeneratedType1"
        Me.colGeneratedType1.OptionsColumn.AllowEdit = False
        Me.colGeneratedType1.OptionsColumn.ReadOnly = True
        '
        'colReversalFlag1
        '
        Me.colReversalFlag1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colReversalFlag1.AppearanceHeader.Options.UseFont = True
        Me.colReversalFlag1.FieldName = "Reversal Flag"
        Me.colReversalFlag1.Name = "colReversalFlag1"
        Me.colReversalFlag1.OptionsColumn.AllowEdit = False
        Me.colReversalFlag1.OptionsColumn.ReadOnly = True
        '
        'colDescription1
        '
        Me.colDescription1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colDescription1.AppearanceHeader.Options.UseFont = True
        Me.colDescription1.FieldName = "Description"
        Me.colDescription1.Name = "colDescription1"
        Me.colDescription1.OptionsColumn.AllowEdit = False
        Me.colDescription1.OptionsColumn.ReadOnly = True
        Me.colDescription1.Visible = True
        Me.colDescription1.VisibleIndex = 7
        Me.colDescription1.Width = 234
        '
        'colGL_Rep_Date1
        '
        Me.colGL_Rep_Date1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGL_Rep_Date1.AppearanceHeader.Options.UseFont = True
        Me.colGL_Rep_Date1.Caption = "Booking Date"
        Me.colGL_Rep_Date1.FieldName = "GL_Rep_Date"
        Me.colGL_Rep_Date1.Name = "colGL_Rep_Date1"
        Me.colGL_Rep_Date1.OptionsColumn.AllowEdit = False
        Me.colGL_Rep_Date1.OptionsColumn.ReadOnly = True
        Me.colGL_Rep_Date1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.colGL_Rep_Date1.Visible = True
        Me.colGL_Rep_Date1.VisibleIndex = 0
        Me.colGL_Rep_Date1.Width = 92
        '
        'colGL_Item_Nr1
        '
        Me.colGL_Item_Nr1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGL_Item_Nr1.AppearanceHeader.Options.UseFont = True
        Me.colGL_Item_Nr1.Caption = "GL Item"
        Me.colGL_Item_Nr1.FieldName = "GL_Item_Nr"
        Me.colGL_Item_Nr1.Name = "colGL_Item_Nr1"
        Me.colGL_Item_Nr1.OptionsColumn.AllowEdit = False
        Me.colGL_Item_Nr1.OptionsColumn.ReadOnly = True
        Me.colGL_Item_Nr1.Visible = True
        Me.colGL_Item_Nr1.VisibleIndex = 8
        Me.colGL_Item_Nr1.Width = 86
        '
        'colGL_AC_No_Name1
        '
        Me.colGL_AC_No_Name1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colGL_AC_No_Name1.AppearanceHeader.Options.UseFont = True
        Me.colGL_AC_No_Name1.Caption = "OCBS Acc. Name"
        Me.colGL_AC_No_Name1.FieldName = "GL_AC_No_Name"
        Me.colGL_AC_No_Name1.Name = "colGL_AC_No_Name1"
        Me.colGL_AC_No_Name1.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No_Name1.OptionsColumn.ReadOnly = True
        '
        'colExchange_Rate1
        '
        Me.colExchange_Rate1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colExchange_Rate1.AppearanceHeader.Options.UseFont = True
        Me.colExchange_Rate1.Caption = "Exchange Rate"
        Me.colExchange_Rate1.DisplayFormat.FormatString = "#,##0.0000"
        Me.colExchange_Rate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchange_Rate1.FieldName = "Exchange_Rate"
        Me.colExchange_Rate1.Name = "colExchange_Rate1"
        Me.colExchange_Rate1.OptionsColumn.AllowEdit = False
        Me.colExchange_Rate1.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate1.Visible = True
        Me.colExchange_Rate1.VisibleIndex = 5
        Me.colExchange_Rate1.Width = 97
        '
        'colAmountInEuro1
        '
        Me.colAmountInEuro1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.colAmountInEuro1.AppearanceHeader.Options.UseFont = True
        Me.colAmountInEuro1.DisplayFormat.FormatString = "#,##0.00"
        Me.colAmountInEuro1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountInEuro1.FieldName = "AmountInEuro"
        Me.colAmountInEuro1.Name = "colAmountInEuro1"
        Me.colAmountInEuro1.OptionsColumn.AllowEdit = False
        Me.colAmountInEuro1.OptionsColumn.ReadOnly = True
        Me.colAmountInEuro1.Visible = True
        Me.colAmountInEuro1.VisibleIndex = 6
        Me.colAmountInEuro1.Width = 97
        '
        'OCBS_Postings_BasicView
        '
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.OCBS_Postings_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.OCBS_Postings_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.OCBS_Postings_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.colClientName2})
        Me.OCBS_Postings_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.GridColumn5
        GridFormatRule1.Name = "OpeningBalance"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = "OPENING VALUE BALANCE NOSTRO ACCOUNT"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.GridColumn5
        GridFormatRule2.Name = "ClosingBalance"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Aqua
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.Aqua
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "CLOSING VALUE BALANCE NOSTRO ACCOUNT"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.OCBS_Postings_BasicView.FormatRules.Add(GridFormatRule1)
        Me.OCBS_Postings_BasicView.FormatRules.Add(GridFormatRule2)
        Me.OCBS_Postings_BasicView.GridControl = Me.GridControl1
        Me.OCBS_Postings_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Me.GridColumn17, "SUM={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountInEuro", Me.GridColumn37, "SUM={0:n2}")})
        Me.OCBS_Postings_BasicView.Name = "OCBS_Postings_BasicView"
        Me.OCBS_Postings_BasicView.OptionsBehavior.AutoExpandAllGroups = True
        Me.OCBS_Postings_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.OCBS_Postings_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.OCBS_Postings_BasicView.OptionsFind.AlwaysVisible = True
        Me.OCBS_Postings_BasicView.OptionsLayout.StoreAllOptions = True
        Me.OCBS_Postings_BasicView.OptionsLayout.StoreAppearance = True
        Me.OCBS_Postings_BasicView.OptionsMenu.ShowFooterItem = True
        Me.OCBS_Postings_BasicView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.OCBS_Postings_BasicView.OptionsSelection.MultiSelect = True
        Me.OCBS_Postings_BasicView.OptionsView.ColumnAutoWidth = False
        Me.OCBS_Postings_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.OCBS_Postings_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.OCBS_Postings_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OCBS_Postings_BasicView.OptionsView.ShowFooter = True
        Me.OCBS_Postings_BasicView.OptionsView.ShowGroupPanel = False
        Me.OCBS_Postings_BasicView.PaintStyleName = "Skin"
        Me.OCBS_Postings_BasicView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn33, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.OCBS_Postings_BasicView.ViewCaption = "Results by GL Item"
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "IdNr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "SequenceNo"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "GL Book"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "Accounting Centre"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "OCBS GL Account Nr."
        Me.GridColumn9.FieldName = "GL_AC_No"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Width = 104
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "Value Date"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        Me.GridColumn10.Width = 89
        '
        'GridColumn11
        '
        Me.GridColumn11.DisplayFormat.FormatString = "t"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "Transaction Time"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Width = 115
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "AccountNo"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 8
        Me.GridColumn12.Width = 139
        '
        'GridColumn13
        '
        Me.GridColumn13.FieldName = "Contract Type"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Width = 109
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "Event Type"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        '
        'GridColumn16
        '
        Me.GridColumn16.FieldName = "CCY"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 3
        Me.GridColumn16.Width = 38
        '
        'GridColumn18
        '
        Me.GridColumn18.FieldName = "DR_CR"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "GroupNo"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "ClientNo"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "Portfolio Code"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "Narrative Code"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.FieldName = "Reference Code"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        '
        'GridColumn24
        '
        Me.GridColumn24.FieldName = "ChequeNo"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        '
        'GridColumn25
        '
        Me.GridColumn25.FieldName = "AP"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        '
        'GridColumn26
        '
        Me.GridColumn26.FieldName = "TRN Accounting Centre"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        '
        'GridColumn27
        '
        Me.GridColumn27.FieldName = "Checker ID"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        '
        'GridColumn28
        '
        Me.GridColumn28.FieldName = "Channel"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        '
        'GridColumn29
        '
        Me.GridColumn29.FieldName = "Other System Key"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        '
        'GridColumn30
        '
        Me.GridColumn30.FieldName = "Generated Type"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        '
        'GridColumn31
        '
        Me.GridColumn31.FieldName = "Reversal Flag"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        '
        'GridColumn32
        '
        Me.GridColumn32.FieldName = "Description"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 7
        Me.GridColumn32.Width = 284
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Booking Date"
        Me.GridColumn33.FieldName = "GL_Rep_Date"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        Me.GridColumn33.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 0
        Me.GridColumn33.Width = 91
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "OCBS GL Account Name"
        Me.GridColumn35.FieldName = "GL_AC_No_Name"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        Me.GridColumn35.Width = 308
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Exchange Rate"
        Me.GridColumn36.DisplayFormat.FormatString = "#,##0.0000"
        Me.GridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn36.FieldName = "Exchange_Rate"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.OptionsColumn.ReadOnly = True
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 5
        Me.GridColumn36.Width = 92
        '
        'colClientName2
        '
        Me.colClientName2.Caption = "Client Name"
        Me.colClientName2.FieldName = "ClientName"
        Me.colClientName2.Name = "colClientName2"
        Me.colClientName2.OptionsColumn.AllowEdit = False
        Me.colClientName2.OptionsColumn.ReadOnly = True
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_PostingsBalances_btn)
        Me.GroupControl2.Controls.Add(Me.NostroAccountNamelbl)
        Me.GroupControl2.Controls.Add(Me.CURlbl)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.OCBS_LookUpEdit)
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_btn)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_Till)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_From)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Location = New System.Drawing.Point(458, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(625, 134)
        Me.GroupControl2.TabIndex = 5
        Me.GroupControl2.Text = "Search by Internal Nostro Accounts"
        '
        'LoadOCBS_PostingsBalances_btn
        '
        Me.LoadOCBS_PostingsBalances_btn.ImageOptions.Image = CType(resources.GetObject("LoadOCBS_PostingsBalances_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.LoadOCBS_PostingsBalances_btn.ImageOptions.ImageIndex = 6
        Me.LoadOCBS_PostingsBalances_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadOCBS_PostingsBalances_btn.Location = New System.Drawing.Point(423, 101)
        Me.LoadOCBS_PostingsBalances_btn.Name = "LoadOCBS_PostingsBalances_btn"
        Me.LoadOCBS_PostingsBalances_btn.Size = New System.Drawing.Size(180, 23)
        Me.LoadOCBS_PostingsBalances_btn.TabIndex = 32
        Me.LoadOCBS_PostingsBalances_btn.Text = "Load Postings+Value Balances"
        '
        'NostroAccountNamelbl
        '
        Me.NostroAccountNamelbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.NostroAccountNamelbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.NostroAccountNamelbl.Appearance.Options.UseFont = True
        Me.NostroAccountNamelbl.Appearance.Options.UseForeColor = True
        Me.NostroAccountNamelbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.NostroAccountNamelbl.Location = New System.Drawing.Point(14, 62)
        Me.NostroAccountNamelbl.Name = "NostroAccountNamelbl"
        Me.NostroAccountNamelbl.Size = New System.Drawing.Size(457, 22)
        Me.NostroAccountNamelbl.TabIndex = 31
        '
        'CURlbl
        '
        Me.CURlbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CURlbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CURlbl.Appearance.Options.UseFont = True
        Me.CURlbl.Appearance.Options.UseForeColor = True
        Me.CURlbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CURlbl.Location = New System.Drawing.Point(206, 43)
        Me.CURlbl.Name = "CURlbl"
        Me.CURlbl.Size = New System.Drawing.Size(66, 13)
        Me.CURlbl.TabIndex = 3
        Me.CURlbl.Text = "Currency"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl11.Location = New System.Drawing.Point(14, 24)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(186, 14)
        Me.LabelControl11.TabIndex = 1
        Me.LabelControl11.Text = "Internal Nostro Account"
        '
        'OCBS_LookUpEdit
        '
        Me.OCBS_LookUpEdit.Location = New System.Drawing.Point(14, 39)
        Me.OCBS_LookUpEdit.Name = "OCBS_LookUpEdit"
        Me.OCBS_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OCBS_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OCBS_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OCBS_LookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.OCBS_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OCBS_LookUpEdit.Properties.DataSource = Me.SSISBindingSource
        Me.OCBS_LookUpEdit.Properties.DisplayMember = "INTERNAL ACCOUNT"
        Me.OCBS_LookUpEdit.Properties.NullText = ""
        Me.OCBS_LookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(500, 650)
        Me.OCBS_LookUpEdit.Properties.PopupView = Me.GridView1
        Me.OCBS_LookUpEdit.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox_Valid})
        Me.OCBS_LookUpEdit.Properties.ValueMember = "INTERNAL ACCOUNT"
        Me.OCBS_LookUpEdit.Size = New System.Drawing.Size(186, 20)
        Me.OCBS_LookUpEdit.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colINTERNALACCOUNT, Me.colINTERNALIBAN, Me.colCORRESPONDENTBIC, Me.colNOSTRO_NAME, Me.colCORRESPONDENTNAME, Me.colEXTERNALACCOUNT, Me.colIBAN, Me.colINTERMEDIARYBIC, Me.colINTERMEDIARYNAME, Me.colVALID})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colCURRENCYCODE
        '
        Me.colCURRENCYCODE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYCODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCURRENCYCODE.Caption = "CCY"
        Me.colCURRENCYCODE.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYCODE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYCODE.Visible = True
        Me.colCURRENCYCODE.VisibleIndex = 1
        Me.colCURRENCYCODE.Width = 58
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME.OptionsColumn.ReadOnly = True
        '
        'colINTERNALACCOUNT
        '
        Me.colINTERNALACCOUNT.AppearanceCell.Options.UseTextOptions = True
        Me.colINTERNALACCOUNT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colINTERNALACCOUNT.Caption = "NOSTRO ACCOUNT (INTERN)"
        Me.colINTERNALACCOUNT.FieldName = "INTERNAL ACCOUNT"
        Me.colINTERNALACCOUNT.Name = "colINTERNALACCOUNT"
        Me.colINTERNALACCOUNT.OptionsColumn.AllowEdit = False
        Me.colINTERNALACCOUNT.OptionsColumn.ReadOnly = True
        Me.colINTERNALACCOUNT.Visible = True
        Me.colINTERNALACCOUNT.VisibleIndex = 0
        Me.colINTERNALACCOUNT.Width = 133
        '
        'colINTERNALIBAN
        '
        Me.colINTERNALIBAN.FieldName = "INTERNAL IBAN"
        Me.colINTERNALIBAN.Name = "colINTERNALIBAN"
        Me.colINTERNALIBAN.OptionsColumn.AllowEdit = False
        Me.colINTERNALIBAN.OptionsColumn.ReadOnly = True
        '
        'colCORRESPONDENTBIC
        '
        Me.colCORRESPONDENTBIC.FieldName = "CORRESPONDENT BIC"
        Me.colCORRESPONDENTBIC.Name = "colCORRESPONDENTBIC"
        Me.colCORRESPONDENTBIC.OptionsColumn.AllowEdit = False
        Me.colCORRESPONDENTBIC.OptionsColumn.ReadOnly = True
        Me.colCORRESPONDENTBIC.Width = 153
        '
        'colNOSTRO_NAME
        '
        Me.colNOSTRO_NAME.Caption = "INTERNAL NAME"
        Me.colNOSTRO_NAME.FieldName = "NOSTRO_NAME"
        Me.colNOSTRO_NAME.Name = "colNOSTRO_NAME"
        Me.colNOSTRO_NAME.OptionsColumn.AllowEdit = False
        Me.colNOSTRO_NAME.OptionsColumn.ReadOnly = True
        Me.colNOSTRO_NAME.Visible = True
        Me.colNOSTRO_NAME.VisibleIndex = 2
        Me.colNOSTRO_NAME.Width = 402
        '
        'colCORRESPONDENTNAME
        '
        Me.colCORRESPONDENTNAME.Caption = "NAME"
        Me.colCORRESPONDENTNAME.FieldName = "CORRESPONDENT NAME"
        Me.colCORRESPONDENTNAME.Name = "colCORRESPONDENTNAME"
        Me.colCORRESPONDENTNAME.OptionsColumn.AllowEdit = False
        Me.colCORRESPONDENTNAME.OptionsColumn.ReadOnly = True
        Me.colCORRESPONDENTNAME.Width = 324
        '
        'colEXTERNALACCOUNT
        '
        Me.colEXTERNALACCOUNT.FieldName = "EXTERNAL ACCOUNT"
        Me.colEXTERNALACCOUNT.Name = "colEXTERNALACCOUNT"
        Me.colEXTERNALACCOUNT.OptionsColumn.AllowEdit = False
        Me.colEXTERNALACCOUNT.OptionsColumn.ReadOnly = True
        Me.colEXTERNALACCOUNT.Width = 166
        '
        'colIBAN
        '
        Me.colIBAN.FieldName = "IBAN"
        Me.colIBAN.Name = "colIBAN"
        Me.colIBAN.OptionsColumn.AllowEdit = False
        Me.colIBAN.OptionsColumn.ReadOnly = True
        '
        'colINTERMEDIARYBIC
        '
        Me.colINTERMEDIARYBIC.FieldName = "INTERMEDIARY BIC"
        Me.colINTERMEDIARYBIC.Name = "colINTERMEDIARYBIC"
        Me.colINTERMEDIARYBIC.OptionsColumn.AllowEdit = False
        Me.colINTERMEDIARYBIC.OptionsColumn.ReadOnly = True
        '
        'colINTERMEDIARYNAME
        '
        Me.colINTERMEDIARYNAME.FieldName = "INTERMEDIARY NAME"
        Me.colINTERMEDIARYNAME.Name = "colINTERMEDIARYNAME"
        Me.colINTERMEDIARYNAME.OptionsColumn.AllowEdit = False
        Me.colINTERMEDIARYNAME.OptionsColumn.ReadOnly = True
        '
        'colVALID
        '
        Me.colVALID.AppearanceCell.Options.UseTextOptions = True
        Me.colVALID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colVALID.ColumnEdit = Me.RepositoryItemImageComboBox_Valid
        Me.colVALID.FieldName = "VALID"
        Me.colVALID.Name = "colVALID"
        Me.colVALID.OptionsColumn.AllowEdit = False
        Me.colVALID.OptionsColumn.ReadOnly = True
        Me.colVALID.Visible = True
        Me.colVALID.VisibleIndex = 3
        '
        'RepositoryItemImageComboBox_Valid
        '
        Me.RepositoryItemImageComboBox_Valid.AutoHeight = False
        Me.RepositoryItemImageComboBox_Valid.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox_Valid.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Y", "Y", 8), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("N", "N", 9)})
        Me.RepositoryItemImageComboBox_Valid.Name = "RepositoryItemImageComboBox_Valid"
        Me.RepositoryItemImageComboBox_Valid.SmallImages = Me.ImageCollection1
        '
        'LoadOCBS_btn
        '
        Me.LoadOCBS_btn.ImageOptions.Image = CType(resources.GetObject("LoadOCBS_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.LoadOCBS_btn.ImageOptions.ImageIndex = 6
        Me.LoadOCBS_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadOCBS_btn.Location = New System.Drawing.Point(247, 101)
        Me.LoadOCBS_btn.Name = "LoadOCBS_btn"
        Me.LoadOCBS_btn.Size = New System.Drawing.Size(170, 23)
        Me.LoadOCBS_btn.TabIndex = 9
        Me.LoadOCBS_btn.Text = "Load Ledger + Value Balance"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl12.Location = New System.Drawing.Point(130, 83)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(52, 21)
        Me.LabelControl12.TabIndex = 7
        Me.LabelControl12.Text = "Date till"
        '
        'OCBS_BookingDate_Till
        '
        Me.OCBS_BookingDate_Till.EditValue = Nothing
        Me.OCBS_BookingDate_Till.Location = New System.Drawing.Point(130, 104)
        Me.OCBS_BookingDate_Till.Name = "OCBS_BookingDate_Till"
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OCBS_BookingDate_Till.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OCBS_BookingDate_Till.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.OCBS_BookingDate_Till.Size = New System.Drawing.Size(100, 20)
        Me.OCBS_BookingDate_Till.TabIndex = 8
        '
        'OCBS_BookingDate_From
        '
        Me.OCBS_BookingDate_From.EditValue = Nothing
        Me.OCBS_BookingDate_From.Location = New System.Drawing.Point(14, 104)
        Me.OCBS_BookingDate_From.Name = "OCBS_BookingDate_From"
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OCBS_BookingDate_From.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OCBS_BookingDate_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.OCBS_BookingDate_From.Size = New System.Drawing.Size(100, 20)
        Me.OCBS_BookingDate_From.TabIndex = 6
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl14.Appearance.Options.UseFont = True
        Me.LabelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl14.Location = New System.Drawing.Point(14, 83)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(60, 20)
        Me.LabelControl14.TabIndex = 5
        Me.LabelControl14.Text = "Date from"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.ProgressPanel1)
        Me.LayoutControl1.Controls.Add(Me.SearchText_lbl)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(-7, 152)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1460, 577)
        Me.LayoutControl1.TabIndex = 119
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.Aqua
        Me.ProgressPanel1.AppearanceCaption.Options.UseFont = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseForeColor = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseTextOptions = True
        Me.ProgressPanel1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ProgressPanel1.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.ProgressPanel1.AutoWidth = True
        Me.ProgressPanel1.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration
        Me.ProgressPanel1.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Triangle
        Me.ProgressPanel1.Location = New System.Drawing.Point(192, 24)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(116, 16)
        Me.ProgressPanel1.StyleController = Me.LayoutControl1
        Me.ProgressPanel1.TabIndex = 127
        Me.ProgressPanel1.Text = "ProgressPanel1"
        '
        'SearchText_lbl
        '
        Me.SearchText_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SearchText_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.SearchText_lbl.Appearance.Options.UseFont = True
        Me.SearchText_lbl.Appearance.Options.UseForeColor = True
        Me.SearchText_lbl.Appearance.Options.UseTextOptions = True
        Me.SearchText_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SearchText_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.SearchText_lbl.Location = New System.Drawing.Point(12, 62)
        Me.SearchText_lbl.Name = "SearchText_lbl"
        Me.SearchText_lbl.Size = New System.Drawing.Size(1436, 16)
        Me.SearchText_lbl.StyleController = Me.LayoutControl1
        Me.SearchText_lbl.TabIndex = 117
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(164, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 10
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1353, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(83, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1460, 577)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1440, 487)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1440, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1329, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(87, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(1311, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(18, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(168, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ProgressPanel1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(168, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1143, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchText_lbl
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1440, 20)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'InternalNostroBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1445, 721)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.IconOptions.Icon = CType(resources.GetObject("InternalNostroBalances.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "InternalNostroBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Internal Nostro Accounts Balances"
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NOSTRO_BALANCESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nostro_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_Postings_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.OCBS_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox_Valid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BalancesDataset As PS_TOOL_DX.BalancesDataset
    Friend WithEvents NOSTRO_BALANCESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NOSTRO_BALANCESTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.NOSTRO_BALANCESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents SSISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SSISTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.SSISTableAdapter
    Friend WithEvents TableAdapterManager1 As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents NostroAccountNamelbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CURlbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_LookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINTERNALACCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINTERNALIBAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRESPONDENTBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRESPONDENTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXTERNALACCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINTERMEDIARYBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINTERMEDIARYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LoadOCBS_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_BookingDate_Till As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OCBS_BookingDate_From As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchText_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Nostro_Balances_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colIdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNostroCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNostroName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGLCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLedgerBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBalanceDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchange_Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLedgerBalanceEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueBalanceEUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents OdasImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents OCBS_Balances_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colIdNr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBatchNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSequenceNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGLBook1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountingCentre1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_No1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTransactionTime1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEventType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCCY1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDR_CR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPortfolioCode1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNarrativeCode1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReferenceCode1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAP1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRNAccountingCentre1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCheckerID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannel1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOtherSystemKey1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGeneratedType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReversalFlag1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Rep_Date1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Item_Nr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_No_Name1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchange_Rate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountInEuro1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OCBS_Postings_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents RepositoryItemImageComboBox_Valid As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colNOSTRO_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LoadOCBS_PostingsBalances_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientName2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
