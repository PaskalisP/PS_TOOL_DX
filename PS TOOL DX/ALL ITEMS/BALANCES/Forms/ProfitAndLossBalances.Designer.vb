<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfitAndLossBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfitAndLossBalances))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition5 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition6 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.colBatchNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBatchNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountInEuro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountInEuro1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BalancesDataset = New PS_TOOL_DX.BalancesDataset()
        Me.PROFIT_and_LOSS_VOLUMESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PROFIT_and_LOSS_VOLUMESTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_VOLUMESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager()
        Me.PROFIT_and_LOSS_MAPPINGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PROFIT_and_LOSS_MAPPINGTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_MAPPINGTableAdapter()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.PL_Balances_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSequenceNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGLBook = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountingCentre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTransactionTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContractType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEventType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDR_CR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPortfolioCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNarrativeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReferenceCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChequeNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRNAccountingCentre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCheckerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOtherSystemKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGeneratedType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReversalFlag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_Rep_Date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_AC_No_Name = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.OCBS_Postings_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.GL_LookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.PROFIT_and_LOSS_GL_ITEMSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colGL_ITEM_NR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ITEM_NAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoadGL_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GL_BookingDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.GL_BookingDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_LookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colGL_ACC_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ACC_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGL_ITEM_Mapped = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoadOCBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_BookingDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.OCBS_BookingDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.PROFIT_and_LOSS_GL_ITEMSTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_GL_ITEMSTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchText_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROFIT_and_LOSS_VOLUMESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROFIT_and_LOSS_MAPPINGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PL_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_Postings_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GL_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROFIT_and_LOSS_GL_ITEMSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GL_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GL_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GL_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GL_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OCBS_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colBatchNo
        '
        Me.colBatchNo.FieldName = "BatchNo"
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.OptionsColumn.AllowEdit = False
        Me.colBatchNo.OptionsColumn.ReadOnly = True
        Me.colBatchNo.Visible = True
        Me.colBatchNo.VisibleIndex = 1
        Me.colBatchNo.Width = 226
        '
        'colBatchNo1
        '
        Me.colBatchNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colBatchNo1.AppearanceHeader.Options.UseFont = True
        Me.colBatchNo1.FieldName = "BatchNo"
        Me.colBatchNo1.Name = "colBatchNo1"
        Me.colBatchNo1.OptionsColumn.AllowEdit = False
        Me.colBatchNo1.OptionsColumn.ReadOnly = True
        Me.colBatchNo1.Visible = True
        Me.colBatchNo1.VisibleIndex = 2
        Me.colBatchNo1.Width = 200
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn14.AppearanceHeader.Options.UseFont = True
        Me.GridColumn14.DisplayFormat.FormatString = "#,##0.00"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "Amount"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        Me.GridColumn14.Width = 105
        '
        'GridColumn34
        '
        Me.GridColumn34.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn34.AppearanceHeader.Options.UseBorderColor = True
        Me.GridColumn34.AppearanceHeader.Options.UseFont = True
        Me.GridColumn34.AppearanceHeader.Options.UseImage = True
        Me.GridColumn34.CustomizationCaption = "Amount in EUR"
        Me.GridColumn34.DisplayFormat.FormatString = "#,##0.00"
        Me.GridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn34.FieldName = "AmountInEuro"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 8
        Me.GridColumn34.Width = 103
        '
        'colAmount
        '
        Me.colAmount.DisplayFormat.FormatString = "#,##0.00"
        Me.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount.FieldName = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.OptionsColumn.AllowEdit = False
        Me.colAmount.OptionsColumn.ReadOnly = True
        Me.colAmount.Visible = True
        Me.colAmount.VisibleIndex = 3
        Me.colAmount.Width = 105
        '
        'colAmountInEuro
        '
        Me.colAmountInEuro.AppearanceHeader.Options.UseBorderColor = True
        Me.colAmountInEuro.AppearanceHeader.Options.UseImage = True
        Me.colAmountInEuro.CustomizationCaption = "Amount in EUR"
        Me.colAmountInEuro.DisplayFormat.FormatString = "#,##0.00"
        Me.colAmountInEuro.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmountInEuro.FieldName = "AmountInEuro"
        Me.colAmountInEuro.Name = "colAmountInEuro"
        Me.colAmountInEuro.OptionsColumn.AllowEdit = False
        Me.colAmountInEuro.OptionsColumn.ReadOnly = True
        Me.colAmountInEuro.Visible = True
        Me.colAmountInEuro.VisibleIndex = 5
        Me.colAmountInEuro.Width = 101
        '
        'colAmount1
        '
        Me.colAmount1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'colAmountInEuro1
        '
        Me.colAmountInEuro1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'BalancesDataset
        '
        Me.BalancesDataset.DataSetName = "BalancesDataset"
        Me.BalancesDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PROFIT_and_LOSS_VOLUMESBindingSource
        '
        Me.PROFIT_and_LOSS_VOLUMESBindingSource.DataMember = "PROFIT and LOSS VOLUMES"
        Me.PROFIT_and_LOSS_VOLUMESBindingSource.DataSource = Me.BalancesDataset
        '
        'PROFIT_and_LOSS_VOLUMESTableAdapter
        '
        Me.PROFIT_and_LOSS_VOLUMESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_VOSTRO_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.DIVERSE_GL_ITEMSTableAdapter = Nothing
        Me.TableAdapterManager.DIVERSE_MAPPINGTableAdapter = Nothing
        Me.TableAdapterManager.DIVERSE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.NOSTRO_BALANCESTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_GL_ITEMSTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_MAPPINGTableAdapter = Nothing
        Me.TableAdapterManager.PROFIT_and_LOSS_VOLUMESTableAdapter = Me.PROFIT_and_LOSS_VOLUMESTableAdapter
        Me.TableAdapterManager.SUSPENCE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.SWIFT_ACC_STATEMENTSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PROFIT_and_LOSS_MAPPINGBindingSource
        '
        Me.PROFIT_and_LOSS_MAPPINGBindingSource.DataMember = "PROFIT and LOSS MAPPING"
        Me.PROFIT_and_LOSS_MAPPINGBindingSource.DataSource = Me.BalancesDataset
        '
        'PROFIT_and_LOSS_MAPPINGTableAdapter
        '
        Me.PROFIT_and_LOSS_MAPPINGTableAdapter.ClearBeforeFill = True
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
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
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
        Me.GridControl1.MainView = Me.PL_Balances_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1298, 392)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PL_Balances_BasicView, Me.OCBS_Balances_BasicView, Me.OCBS_Postings_BasicView})
        '
        'PL_Balances_BasicView
        '
        Me.PL_Balances_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.PL_Balances_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.PL_Balances_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.PL_Balances_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.PL_Balances_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.PL_Balances_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.PL_Balances_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.PL_Balances_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIdNr, Me.colBatchNo, Me.colSequenceNo, Me.colGLBook, Me.colAccountingCentre, Me.colGL_AC_No, Me.colValueDate, Me.colTransactionTime, Me.colAccountNo, Me.colContractType, Me.colProductType, Me.colEventType, Me.colCCY, Me.colAmount, Me.colDR_CR, Me.colGroupNo, Me.colClientNo, Me.colPortfolioCode, Me.colNarrativeCode, Me.colReferenceCode, Me.colChequeNo, Me.colAP, Me.colTRNAccountingCentre, Me.colCheckerID, Me.colChannel, Me.colOtherSystemKey, Me.colGeneratedType, Me.colReversalFlag, Me.colDescription, Me.colGL_Rep_Date, Me.GridColumn1, Me.colGL_AC_No_Name, Me.colExchange_Rate, Me.colAmountInEuro})
        Me.PL_Balances_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.colBatchNo
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaptionText
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Aqua
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = "OPENING BALANCE OCBS ACC."
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.colBatchNo
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Aqua
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.Aqua
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "CLOSING BALANCE OCBS ACC."
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Column = Me.colBatchNo
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Aqua
        FormatConditionRuleValue3.Appearance.BackColor2 = System.Drawing.Color.Aqua
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue3.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Appearance.Options.UseTextOptions = True
        FormatConditionRuleValue3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = "GL ITEM CLOSING BALANCE"
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.ApplyToRow = True
        GridFormatRule4.Column = Me.colBatchNo
        GridFormatRule4.Name = "Format3"
        FormatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.Black
        FormatConditionRuleValue4.Appearance.BackColor2 = System.Drawing.Color.Black
        FormatConditionRuleValue4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Aqua
        FormatConditionRuleValue4.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue4.Appearance.Options.UseFont = True
        FormatConditionRuleValue4.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue4.Appearance.Options.UseTextOptions = True
        FormatConditionRuleValue4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = "GL ITEM OPENING BALANCE"
        GridFormatRule4.Rule = FormatConditionRuleValue4
        Me.PL_Balances_BasicView.FormatRules.Add(GridFormatRule1)
        Me.PL_Balances_BasicView.FormatRules.Add(GridFormatRule2)
        Me.PL_Balances_BasicView.FormatRules.Add(GridFormatRule3)
        Me.PL_Balances_BasicView.FormatRules.Add(GridFormatRule4)
        Me.PL_Balances_BasicView.GridControl = Me.GridControl1
        Me.PL_Balances_BasicView.Name = "PL_Balances_BasicView"
        Me.PL_Balances_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.PL_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.PL_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.PL_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.PL_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.PL_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.PL_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.PL_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.PL_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.PL_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.PL_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.PL_Balances_BasicView.OptionsView.ShowFooter = True
        Me.PL_Balances_BasicView.PaintStyleName = "Skin"
        Me.PL_Balances_BasicView.ViewCaption = "Results by GL Item"
        '
        'colIdNr
        '
        Me.colIdNr.FieldName = "IdNr"
        Me.colIdNr.Name = "colIdNr"
        Me.colIdNr.OptionsColumn.AllowEdit = False
        Me.colIdNr.OptionsColumn.ReadOnly = True
        '
        'colSequenceNo
        '
        Me.colSequenceNo.FieldName = "SequenceNo"
        Me.colSequenceNo.Name = "colSequenceNo"
        Me.colSequenceNo.OptionsColumn.AllowEdit = False
        Me.colSequenceNo.OptionsColumn.ReadOnly = True
        '
        'colGLBook
        '
        Me.colGLBook.FieldName = "GL Book"
        Me.colGLBook.Name = "colGLBook"
        Me.colGLBook.OptionsColumn.AllowEdit = False
        Me.colGLBook.OptionsColumn.ReadOnly = True
        '
        'colAccountingCentre
        '
        Me.colAccountingCentre.FieldName = "Accounting Centre"
        Me.colAccountingCentre.Name = "colAccountingCentre"
        Me.colAccountingCentre.OptionsColumn.AllowEdit = False
        Me.colAccountingCentre.OptionsColumn.ReadOnly = True
        '
        'colGL_AC_No
        '
        Me.colGL_AC_No.Caption = "OCBS Account Nr."
        Me.colGL_AC_No.FieldName = "GL_AC_No"
        Me.colGL_AC_No.Name = "colGL_AC_No"
        Me.colGL_AC_No.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No.OptionsColumn.ReadOnly = True
        Me.colGL_AC_No.Visible = True
        Me.colGL_AC_No.VisibleIndex = 7
        Me.colGL_AC_No.Width = 104
        '
        'colValueDate
        '
        Me.colValueDate.FieldName = "Value Date"
        Me.colValueDate.Name = "colValueDate"
        Me.colValueDate.OptionsColumn.AllowEdit = False
        Me.colValueDate.OptionsColumn.ReadOnly = True
        Me.colValueDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.colValueDate.Visible = True
        Me.colValueDate.VisibleIndex = 0
        Me.colValueDate.Width = 89
        '
        'colTransactionTime
        '
        Me.colTransactionTime.DisplayFormat.FormatString = "t"
        Me.colTransactionTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colTransactionTime.FieldName = "Transaction Time"
        Me.colTransactionTime.Name = "colTransactionTime"
        Me.colTransactionTime.OptionsColumn.AllowEdit = False
        Me.colTransactionTime.OptionsColumn.ReadOnly = True
        Me.colTransactionTime.Width = 115
        '
        'colAccountNo
        '
        Me.colAccountNo.FieldName = "AccountNo"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.OptionsColumn.AllowEdit = False
        Me.colAccountNo.OptionsColumn.ReadOnly = True
        Me.colAccountNo.Width = 105
        '
        'colContractType
        '
        Me.colContractType.FieldName = "Contract Type"
        Me.colContractType.Name = "colContractType"
        Me.colContractType.OptionsColumn.AllowEdit = False
        Me.colContractType.OptionsColumn.ReadOnly = True
        Me.colContractType.Width = 109
        '
        'colProductType
        '
        Me.colProductType.FieldName = "Product Type"
        Me.colProductType.Name = "colProductType"
        Me.colProductType.OptionsColumn.AllowEdit = False
        Me.colProductType.OptionsColumn.ReadOnly = True
        '
        'colEventType
        '
        Me.colEventType.FieldName = "Event Type"
        Me.colEventType.Name = "colEventType"
        Me.colEventType.OptionsColumn.AllowEdit = False
        Me.colEventType.OptionsColumn.ReadOnly = True
        '
        'colCCY
        '
        Me.colCCY.FieldName = "CCY"
        Me.colCCY.Name = "colCCY"
        Me.colCCY.OptionsColumn.AllowEdit = False
        Me.colCCY.OptionsColumn.ReadOnly = True
        Me.colCCY.Visible = True
        Me.colCCY.VisibleIndex = 2
        Me.colCCY.Width = 38
        '
        'colDR_CR
        '
        Me.colDR_CR.FieldName = "DR_CR"
        Me.colDR_CR.Name = "colDR_CR"
        Me.colDR_CR.OptionsColumn.AllowEdit = False
        Me.colDR_CR.OptionsColumn.ReadOnly = True
        '
        'colGroupNo
        '
        Me.colGroupNo.FieldName = "GroupNo"
        Me.colGroupNo.Name = "colGroupNo"
        Me.colGroupNo.OptionsColumn.AllowEdit = False
        Me.colGroupNo.OptionsColumn.ReadOnly = True
        '
        'colClientNo
        '
        Me.colClientNo.FieldName = "ClientNo"
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        '
        'colPortfolioCode
        '
        Me.colPortfolioCode.FieldName = "Portfolio Code"
        Me.colPortfolioCode.Name = "colPortfolioCode"
        Me.colPortfolioCode.OptionsColumn.AllowEdit = False
        Me.colPortfolioCode.OptionsColumn.ReadOnly = True
        '
        'colNarrativeCode
        '
        Me.colNarrativeCode.FieldName = "Narrative Code"
        Me.colNarrativeCode.Name = "colNarrativeCode"
        Me.colNarrativeCode.OptionsColumn.AllowEdit = False
        Me.colNarrativeCode.OptionsColumn.ReadOnly = True
        '
        'colReferenceCode
        '
        Me.colReferenceCode.FieldName = "Reference Code"
        Me.colReferenceCode.Name = "colReferenceCode"
        Me.colReferenceCode.OptionsColumn.AllowEdit = False
        Me.colReferenceCode.OptionsColumn.ReadOnly = True
        '
        'colChequeNo
        '
        Me.colChequeNo.FieldName = "ChequeNo"
        Me.colChequeNo.Name = "colChequeNo"
        Me.colChequeNo.OptionsColumn.AllowEdit = False
        Me.colChequeNo.OptionsColumn.ReadOnly = True
        '
        'colAP
        '
        Me.colAP.FieldName = "AP"
        Me.colAP.Name = "colAP"
        Me.colAP.OptionsColumn.AllowEdit = False
        Me.colAP.OptionsColumn.ReadOnly = True
        '
        'colTRNAccountingCentre
        '
        Me.colTRNAccountingCentre.FieldName = "TRN Accounting Centre"
        Me.colTRNAccountingCentre.Name = "colTRNAccountingCentre"
        Me.colTRNAccountingCentre.OptionsColumn.AllowEdit = False
        Me.colTRNAccountingCentre.OptionsColumn.ReadOnly = True
        '
        'colCheckerID
        '
        Me.colCheckerID.FieldName = "Checker ID"
        Me.colCheckerID.Name = "colCheckerID"
        Me.colCheckerID.OptionsColumn.AllowEdit = False
        Me.colCheckerID.OptionsColumn.ReadOnly = True
        '
        'colChannel
        '
        Me.colChannel.FieldName = "Channel"
        Me.colChannel.Name = "colChannel"
        Me.colChannel.OptionsColumn.AllowEdit = False
        Me.colChannel.OptionsColumn.ReadOnly = True
        '
        'colOtherSystemKey
        '
        Me.colOtherSystemKey.FieldName = "Other System Key"
        Me.colOtherSystemKey.Name = "colOtherSystemKey"
        Me.colOtherSystemKey.OptionsColumn.AllowEdit = False
        Me.colOtherSystemKey.OptionsColumn.ReadOnly = True
        '
        'colGeneratedType
        '
        Me.colGeneratedType.FieldName = "Generated Type"
        Me.colGeneratedType.Name = "colGeneratedType"
        Me.colGeneratedType.OptionsColumn.AllowEdit = False
        Me.colGeneratedType.OptionsColumn.ReadOnly = True
        '
        'colReversalFlag
        '
        Me.colReversalFlag.FieldName = "Reversal Flag"
        Me.colReversalFlag.Name = "colReversalFlag"
        Me.colReversalFlag.OptionsColumn.AllowEdit = False
        Me.colReversalFlag.OptionsColumn.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.OptionsColumn.ReadOnly = True
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 6
        Me.colDescription.Width = 266
        '
        'colGL_Rep_Date
        '
        Me.colGL_Rep_Date.Caption = "Booking Date"
        Me.colGL_Rep_Date.FieldName = "GL_Rep_Date"
        Me.colGL_Rep_Date.Name = "colGL_Rep_Date"
        Me.colGL_Rep_Date.OptionsColumn.AllowEdit = False
        Me.colGL_Rep_Date.OptionsColumn.ReadOnly = True
        Me.colGL_Rep_Date.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.colGL_Rep_Date.Width = 91
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "GL_Item_Nr"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'colGL_AC_No_Name
        '
        Me.colGL_AC_No_Name.Caption = "OCBS Account Name"
        Me.colGL_AC_No_Name.FieldName = "GL_AC_No_Name"
        Me.colGL_AC_No_Name.Name = "colGL_AC_No_Name"
        Me.colGL_AC_No_Name.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No_Name.OptionsColumn.ReadOnly = True
        Me.colGL_AC_No_Name.Visible = True
        Me.colGL_AC_No_Name.VisibleIndex = 8
        Me.colGL_AC_No_Name.Width = 308
        '
        'colExchange_Rate
        '
        Me.colExchange_Rate.Caption = "Exchange Rate"
        Me.colExchange_Rate.DisplayFormat.FormatString = "#,##0.0000"
        Me.colExchange_Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colExchange_Rate.FieldName = "Exchange_Rate"
        Me.colExchange_Rate.Name = "colExchange_Rate"
        Me.colExchange_Rate.OptionsColumn.AllowEdit = False
        Me.colExchange_Rate.OptionsColumn.ReadOnly = True
        Me.colExchange_Rate.Visible = True
        Me.colExchange_Rate.VisibleIndex = 4
        Me.colExchange_Rate.Width = 92
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
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Aqua
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseFont = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Appearance.Options.UseTextOptions = True
        StyleFormatCondition1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Column = Me.colBatchNo1
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Expression = "OPENING BALANCE OCBS ACC."
        StyleFormatCondition1.Value1 = "OPENING BALANCE OCBS ACC."
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Aqua
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.Cyan
        StyleFormatCondition2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseFont = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Appearance.Options.UseTextOptions = True
        StyleFormatCondition2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        StyleFormatCondition2.ApplyToRow = True
        StyleFormatCondition2.Column = Me.colBatchNo1
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Expression = "CLOSING BALANCE OCBS ACC."
        StyleFormatCondition2.Value1 = "CLOSING BALANCE OCBS ACC."
        Me.OCBS_Balances_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2})
        Me.OCBS_Balances_BasicView.GridControl = Me.GridControl1
        Me.OCBS_Balances_BasicView.Name = "OCBS_Balances_BasicView"
        Me.OCBS_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.OCBS_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.OCBS_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.OCBS_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.OCBS_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.OCBS_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.OCBS_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.OCBS_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.OCBS_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.OCBS_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OCBS_Balances_BasicView.OptionsView.ShowFooter = True
        '
        'colIdNr1
        '
        Me.colIdNr1.AppearanceHeader.BackColor = System.Drawing.SystemColors.Control
        Me.colIdNr1.AppearanceHeader.BackColor2 = System.Drawing.SystemColors.Control
        Me.colIdNr1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.colSequenceNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colSequenceNo1.AppearanceHeader.Options.UseFont = True
        Me.colSequenceNo1.FieldName = "SequenceNo"
        Me.colSequenceNo1.Name = "colSequenceNo1"
        Me.colSequenceNo1.OptionsColumn.AllowEdit = False
        Me.colSequenceNo1.OptionsColumn.ReadOnly = True
        '
        'colGLBook1
        '
        Me.colGLBook1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colGLBook1.AppearanceHeader.Options.UseFont = True
        Me.colGLBook1.FieldName = "GL Book"
        Me.colGLBook1.Name = "colGLBook1"
        Me.colGLBook1.OptionsColumn.AllowEdit = False
        Me.colGLBook1.OptionsColumn.ReadOnly = True
        '
        'colAccountingCentre1
        '
        Me.colAccountingCentre1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colAccountingCentre1.AppearanceHeader.Options.UseFont = True
        Me.colAccountingCentre1.FieldName = "Accounting Centre"
        Me.colAccountingCentre1.Name = "colAccountingCentre1"
        Me.colAccountingCentre1.OptionsColumn.AllowEdit = False
        Me.colAccountingCentre1.OptionsColumn.ReadOnly = True
        '
        'colGL_AC_No1
        '
        Me.colGL_AC_No1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colGL_AC_No1.AppearanceHeader.Options.UseFont = True
        Me.colGL_AC_No1.Caption = "OCBS Account Nr."
        Me.colGL_AC_No1.FieldName = "GL_AC_No"
        Me.colGL_AC_No1.Name = "colGL_AC_No1"
        Me.colGL_AC_No1.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No1.OptionsColumn.ReadOnly = True
        '
        'colValueDate1
        '
        Me.colValueDate1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.colTransactionTime1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTransactionTime1.AppearanceHeader.Options.UseFont = True
        Me.colTransactionTime1.FieldName = "Transaction Time"
        Me.colTransactionTime1.Name = "colTransactionTime1"
        Me.colTransactionTime1.OptionsColumn.AllowEdit = False
        Me.colTransactionTime1.OptionsColumn.ReadOnly = True
        '
        'colAccountNo1
        '
        Me.colAccountNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colAccountNo1.AppearanceHeader.Options.UseFont = True
        Me.colAccountNo1.FieldName = "AccountNo"
        Me.colAccountNo1.Name = "colAccountNo1"
        Me.colAccountNo1.OptionsColumn.AllowEdit = False
        Me.colAccountNo1.OptionsColumn.ReadOnly = True
        Me.colAccountNo1.Width = 86
        '
        'colContractType1
        '
        Me.colContractType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colContractType1.AppearanceHeader.Options.UseFont = True
        Me.colContractType1.FieldName = "Contract Type"
        Me.colContractType1.Name = "colContractType1"
        Me.colContractType1.OptionsColumn.AllowEdit = False
        Me.colContractType1.OptionsColumn.ReadOnly = True
        '
        'colProductType1
        '
        Me.colProductType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colProductType1.AppearanceHeader.Options.UseFont = True
        Me.colProductType1.FieldName = "Product Type"
        Me.colProductType1.Name = "colProductType1"
        Me.colProductType1.OptionsColumn.AllowEdit = False
        Me.colProductType1.OptionsColumn.ReadOnly = True
        '
        'colEventType1
        '
        Me.colEventType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colEventType1.AppearanceHeader.Options.UseFont = True
        Me.colEventType1.FieldName = "Event Type"
        Me.colEventType1.Name = "colEventType1"
        Me.colEventType1.OptionsColumn.AllowEdit = False
        Me.colEventType1.OptionsColumn.ReadOnly = True
        '
        'colCCY1
        '
        Me.colCCY1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCCY1.AppearanceHeader.Options.UseFont = True
        Me.colCCY1.FieldName = "CCY"
        Me.colCCY1.Name = "colCCY1"
        Me.colCCY1.OptionsColumn.AllowEdit = False
        Me.colCCY1.OptionsColumn.ReadOnly = True
        Me.colCCY1.Visible = True
        Me.colCCY1.VisibleIndex = 3
        Me.colCCY1.Width = 44
        '
        'colDR_CR1
        '
        Me.colDR_CR1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDR_CR1.AppearanceHeader.Options.UseFont = True
        Me.colDR_CR1.FieldName = "DR_CR"
        Me.colDR_CR1.Name = "colDR_CR1"
        Me.colDR_CR1.OptionsColumn.AllowEdit = False
        Me.colDR_CR1.OptionsColumn.ReadOnly = True
        '
        'colGroupNo1
        '
        Me.colGroupNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colGroupNo1.AppearanceHeader.Options.UseFont = True
        Me.colGroupNo1.FieldName = "GroupNo"
        Me.colGroupNo1.Name = "colGroupNo1"
        Me.colGroupNo1.OptionsColumn.AllowEdit = False
        Me.colGroupNo1.OptionsColumn.ReadOnly = True
        '
        'colClientNo1
        '
        Me.colClientNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colClientNo1.AppearanceHeader.Options.UseFont = True
        Me.colClientNo1.FieldName = "ClientNo"
        Me.colClientNo1.Name = "colClientNo1"
        Me.colClientNo1.OptionsColumn.AllowEdit = False
        Me.colClientNo1.OptionsColumn.ReadOnly = True
        '
        'colPortfolioCode1
        '
        Me.colPortfolioCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colPortfolioCode1.AppearanceHeader.Options.UseFont = True
        Me.colPortfolioCode1.FieldName = "Portfolio Code"
        Me.colPortfolioCode1.Name = "colPortfolioCode1"
        Me.colPortfolioCode1.OptionsColumn.AllowEdit = False
        Me.colPortfolioCode1.OptionsColumn.ReadOnly = True
        '
        'colNarrativeCode1
        '
        Me.colNarrativeCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNarrativeCode1.AppearanceHeader.Options.UseFont = True
        Me.colNarrativeCode1.FieldName = "Narrative Code"
        Me.colNarrativeCode1.Name = "colNarrativeCode1"
        Me.colNarrativeCode1.OptionsColumn.AllowEdit = False
        Me.colNarrativeCode1.OptionsColumn.ReadOnly = True
        '
        'colReferenceCode1
        '
        Me.colReferenceCode1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colReferenceCode1.AppearanceHeader.Options.UseFont = True
        Me.colReferenceCode1.FieldName = "Reference Code"
        Me.colReferenceCode1.Name = "colReferenceCode1"
        Me.colReferenceCode1.OptionsColumn.AllowEdit = False
        Me.colReferenceCode1.OptionsColumn.ReadOnly = True
        '
        'colChequeNo1
        '
        Me.colChequeNo1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colChequeNo1.AppearanceHeader.Options.UseFont = True
        Me.colChequeNo1.FieldName = "ChequeNo"
        Me.colChequeNo1.Name = "colChequeNo1"
        Me.colChequeNo1.OptionsColumn.AllowEdit = False
        Me.colChequeNo1.OptionsColumn.ReadOnly = True
        '
        'colAP1
        '
        Me.colAP1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colAP1.AppearanceHeader.Options.UseFont = True
        Me.colAP1.FieldName = "AP"
        Me.colAP1.Name = "colAP1"
        Me.colAP1.OptionsColumn.AllowEdit = False
        Me.colAP1.OptionsColumn.ReadOnly = True
        '
        'colTRNAccountingCentre1
        '
        Me.colTRNAccountingCentre1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTRNAccountingCentre1.AppearanceHeader.Options.UseFont = True
        Me.colTRNAccountingCentre1.FieldName = "TRN Accounting Centre"
        Me.colTRNAccountingCentre1.Name = "colTRNAccountingCentre1"
        Me.colTRNAccountingCentre1.OptionsColumn.AllowEdit = False
        Me.colTRNAccountingCentre1.OptionsColumn.ReadOnly = True
        '
        'colCheckerID1
        '
        Me.colCheckerID1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCheckerID1.AppearanceHeader.Options.UseFont = True
        Me.colCheckerID1.FieldName = "Checker ID"
        Me.colCheckerID1.Name = "colCheckerID1"
        Me.colCheckerID1.OptionsColumn.AllowEdit = False
        Me.colCheckerID1.OptionsColumn.ReadOnly = True
        '
        'colChannel1
        '
        Me.colChannel1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colChannel1.AppearanceHeader.Options.UseFont = True
        Me.colChannel1.FieldName = "Channel"
        Me.colChannel1.Name = "colChannel1"
        Me.colChannel1.OptionsColumn.AllowEdit = False
        Me.colChannel1.OptionsColumn.ReadOnly = True
        '
        'colOtherSystemKey1
        '
        Me.colOtherSystemKey1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colOtherSystemKey1.AppearanceHeader.Options.UseFont = True
        Me.colOtherSystemKey1.FieldName = "Other System Key"
        Me.colOtherSystemKey1.Name = "colOtherSystemKey1"
        Me.colOtherSystemKey1.OptionsColumn.AllowEdit = False
        Me.colOtherSystemKey1.OptionsColumn.ReadOnly = True
        '
        'colGeneratedType1
        '
        Me.colGeneratedType1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colGeneratedType1.AppearanceHeader.Options.UseFont = True
        Me.colGeneratedType1.FieldName = "Generated Type"
        Me.colGeneratedType1.Name = "colGeneratedType1"
        Me.colGeneratedType1.OptionsColumn.AllowEdit = False
        Me.colGeneratedType1.OptionsColumn.ReadOnly = True
        '
        'colReversalFlag1
        '
        Me.colReversalFlag1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colReversalFlag1.AppearanceHeader.Options.UseFont = True
        Me.colReversalFlag1.FieldName = "Reversal Flag"
        Me.colReversalFlag1.Name = "colReversalFlag1"
        Me.colReversalFlag1.OptionsColumn.AllowEdit = False
        Me.colReversalFlag1.OptionsColumn.ReadOnly = True
        '
        'colDescription1
        '
        Me.colDescription1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.colGL_Rep_Date1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.colGL_Item_Nr1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.colGL_AC_No_Name1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colGL_AC_No_Name1.AppearanceHeader.Options.UseFont = True
        Me.colGL_AC_No_Name1.Caption = "OCBS Acc. Name"
        Me.colGL_AC_No_Name1.FieldName = "GL_AC_No_Name"
        Me.colGL_AC_No_Name1.Name = "colGL_AC_No_Name1"
        Me.colGL_AC_No_Name1.OptionsColumn.AllowEdit = False
        Me.colGL_AC_No_Name1.OptionsColumn.ReadOnly = True
        '
        'colExchange_Rate1
        '
        Me.colExchange_Rate1.AppearanceHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'OCBS_Postings_BasicView
        '
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.OCBS_Postings_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.OCBS_Postings_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn35, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34})
        Me.OCBS_Postings_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.LimeGreen
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Column = Me.GridColumn14
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.GreaterOrEqual
        StyleFormatCondition3.Expression = "0"
        StyleFormatCondition3.Value1 = "0"
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.OrangeRed
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Column = Me.GridColumn14
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Less
        StyleFormatCondition4.Expression = "0"
        StyleFormatCondition4.Value1 = "0"
        StyleFormatCondition5.Appearance.ForeColor = System.Drawing.Color.LimeGreen
        StyleFormatCondition5.Appearance.Options.UseForeColor = True
        StyleFormatCondition5.Column = Me.GridColumn34
        StyleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.GreaterOrEqual
        StyleFormatCondition5.Expression = "0"
        StyleFormatCondition5.Value1 = "0"
        StyleFormatCondition6.Appearance.ForeColor = System.Drawing.Color.OrangeRed
        StyleFormatCondition6.Appearance.Options.UseForeColor = True
        StyleFormatCondition6.Column = Me.GridColumn34
        StyleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Less
        StyleFormatCondition6.Expression = "0"
        StyleFormatCondition6.Value1 = "0"
        Me.OCBS_Postings_BasicView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3, StyleFormatCondition4, StyleFormatCondition5, StyleFormatCondition6})
        Me.OCBS_Postings_BasicView.GridControl = Me.GridControl1
        Me.OCBS_Postings_BasicView.Name = "OCBS_Postings_BasicView"
        Me.OCBS_Postings_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.OCBS_Postings_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.OCBS_Postings_BasicView.OptionsFind.AlwaysVisible = True
        Me.OCBS_Postings_BasicView.OptionsLayout.StoreAllOptions = True
        Me.OCBS_Postings_BasicView.OptionsLayout.StoreAppearance = True
        Me.OCBS_Postings_BasicView.OptionsSelection.MultiSelect = True
        Me.OCBS_Postings_BasicView.OptionsView.ColumnAutoWidth = False
        Me.OCBS_Postings_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.OCBS_Postings_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.OCBS_Postings_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OCBS_Postings_BasicView.OptionsView.ShowFooter = True
        Me.OCBS_Postings_BasicView.PaintStyleName = "Skin"
        Me.OCBS_Postings_BasicView.ViewCaption = "Results by GL Item"
        '
        'GridColumn35
        '
        Me.GridColumn35.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn35.AppearanceHeader.Options.UseFont = True
        Me.GridColumn35.FieldName = "IdNr"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn2.AppearanceHeader.Options.UseFont = True
        Me.GridColumn2.FieldName = "BatchNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 259
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn3.AppearanceHeader.Options.UseFont = True
        Me.GridColumn3.FieldName = "SequenceNo"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn4.AppearanceHeader.Options.UseFont = True
        Me.GridColumn4.FieldName = "GL Book"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn5.AppearanceHeader.Options.UseFont = True
        Me.GridColumn5.FieldName = "Accounting Centre"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn6.AppearanceHeader.Options.UseFont = True
        Me.GridColumn6.Caption = "OCBS Account Nr."
        Me.GridColumn6.FieldName = "GL_AC_No"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 101
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn7.AppearanceHeader.Options.UseFont = True
        Me.GridColumn7.FieldName = "Value Date"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 95
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn8.AppearanceHeader.Options.UseFont = True
        Me.GridColumn8.FieldName = "Transaction Time"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Width = 115
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn9.AppearanceHeader.Options.UseFont = True
        Me.GridColumn9.FieldName = "AccountNo"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 11
        Me.GridColumn9.Width = 113
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn10.AppearanceHeader.Options.UseFont = True
        Me.GridColumn10.FieldName = "Contract Type"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Width = 109
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn11.AppearanceHeader.Options.UseFont = True
        Me.GridColumn11.FieldName = "Product Type"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn12.AppearanceHeader.Options.UseFont = True
        Me.GridColumn12.FieldName = "Event Type"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn13.AppearanceHeader.Options.UseFont = True
        Me.GridColumn13.FieldName = "CCY"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 49
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn15.AppearanceHeader.Options.UseFont = True
        Me.GridColumn15.FieldName = "DR_CR"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn16.AppearanceHeader.Options.UseFont = True
        Me.GridColumn16.FieldName = "GroupNo"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn17.AppearanceHeader.Options.UseFont = True
        Me.GridColumn17.FieldName = "ClientNo"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn18.AppearanceHeader.Options.UseFont = True
        Me.GridColumn18.FieldName = "Portfolio Code"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn19.AppearanceHeader.Options.UseFont = True
        Me.GridColumn19.FieldName = "Narrative Code"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn20.AppearanceHeader.Options.UseFont = True
        Me.GridColumn20.FieldName = "Reference Code"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn21.AppearanceHeader.Options.UseFont = True
        Me.GridColumn21.FieldName = "ChequeNo"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn22.AppearanceHeader.Options.UseFont = True
        Me.GridColumn22.FieldName = "AP"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn23.AppearanceHeader.Options.UseFont = True
        Me.GridColumn23.FieldName = "TRN Accounting Centre"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn24.AppearanceHeader.Options.UseFont = True
        Me.GridColumn24.FieldName = "Checker ID"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn25.AppearanceHeader.Options.UseFont = True
        Me.GridColumn25.FieldName = "Channel"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn26.AppearanceHeader.Options.UseFont = True
        Me.GridColumn26.FieldName = "Other System Key"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn27.AppearanceHeader.Options.UseFont = True
        Me.GridColumn27.FieldName = "Generated Type"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn28.AppearanceHeader.Options.UseFont = True
        Me.GridColumn28.FieldName = "Reversal Flag"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        '
        'GridColumn29
        '
        Me.GridColumn29.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn29.AppearanceHeader.Options.UseFont = True
        Me.GridColumn29.FieldName = "Description"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 9
        Me.GridColumn29.Width = 253
        '
        'GridColumn30
        '
        Me.GridColumn30.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn30.AppearanceHeader.Options.UseFont = True
        Me.GridColumn30.Caption = "Booking Date"
        Me.GridColumn30.FieldName = "GL_Rep_Date"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        Me.GridColumn30.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        Me.GridColumn30.Width = 87
        '
        'GridColumn31
        '
        Me.GridColumn31.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn31.AppearanceHeader.Options.UseFont = True
        Me.GridColumn31.Caption = "GL Item"
        Me.GridColumn31.FieldName = "GL_Item_Nr"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 10
        '
        'GridColumn32
        '
        Me.GridColumn32.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn32.AppearanceHeader.Options.UseFont = True
        Me.GridColumn32.Caption = "OCBS Account Name"
        Me.GridColumn32.FieldName = "GL_AC_No_Name"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 3
        Me.GridColumn32.Width = 257
        '
        'GridColumn33
        '
        Me.GridColumn33.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn33.AppearanceHeader.Options.UseFont = True
        Me.GridColumn33.Caption = "Exchange Rate"
        Me.GridColumn33.DisplayFormat.FormatString = "#,##0.0000"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn33.FieldName = "Exchange_Rate"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 7
        Me.GridColumn33.Width = 92
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.GL_LookUpEdit)
        Me.GroupControl1.Controls.Add(Me.LoadGL_btn)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.GL_BookingDate_Till)
        Me.GroupControl1.Controls.Add(Me.GL_BookingDate_From)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(482, 221)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Search by GL PROFIT + LOSS ITEM"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl10.Appearance.Options.UseFont = True
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl10.Location = New System.Drawing.Point(206, 130)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(186, 69)
        Me.LabelControl10.TabIndex = 33
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Appearance.Options.UseForeColor = True
        Me.LabelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl9.Location = New System.Drawing.Point(14, 130)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(186, 69)
        Me.LabelControl9.TabIndex = 32
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl8.Location = New System.Drawing.Point(14, 62)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(457, 22)
        Me.LabelControl8.TabIndex = 31
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl7.Location = New System.Drawing.Point(14, 24)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(186, 14)
        Me.LabelControl7.TabIndex = 1
        Me.LabelControl7.Text = "GL Item"
        '
        'GL_LookUpEdit
        '
        Me.GL_LookUpEdit.Location = New System.Drawing.Point(14, 39)
        Me.GL_LookUpEdit.Name = "GL_LookUpEdit"
        Me.GL_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.GL_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.GL_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.GL_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.GL_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.GL_LookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GL_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GL_LookUpEdit.Properties.DataSource = Me.PROFIT_and_LOSS_GL_ITEMSBindingSource
        Me.GL_LookUpEdit.Properties.DisplayMember = "GL_ITEM_NR"
        Me.GL_LookUpEdit.Properties.NullText = ""
        Me.GL_LookUpEdit.Properties.ValueMember = "GL_ITEM_NR"
        Me.GL_LookUpEdit.Properties.View = Me.GridView4
        Me.GL_LookUpEdit.Size = New System.Drawing.Size(186, 20)
        Me.GL_LookUpEdit.TabIndex = 2
        '
        'PROFIT_and_LOSS_GL_ITEMSBindingSource
        '
        Me.PROFIT_and_LOSS_GL_ITEMSBindingSource.DataMember = "PROFIT and LOSS GL ITEMS"
        Me.PROFIT_and_LOSS_GL_ITEMSBindingSource.DataSource = Me.BalancesDataset
        '
        'GridView4
        '
        Me.GridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGL_ITEM_NR, Me.colGL_ITEM_NAME})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView4.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView4.OptionsFind.AlwaysVisible = True
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'colGL_ITEM_NR
        '
        Me.colGL_ITEM_NR.Caption = "GL ITEM"
        Me.colGL_ITEM_NR.FieldName = "GL_ITEM_NR"
        Me.colGL_ITEM_NR.Name = "colGL_ITEM_NR"
        Me.colGL_ITEM_NR.Visible = True
        Me.colGL_ITEM_NR.VisibleIndex = 0
        Me.colGL_ITEM_NR.Width = 61
        '
        'colGL_ITEM_NAME
        '
        Me.colGL_ITEM_NAME.Caption = "GL ITEM NAME"
        Me.colGL_ITEM_NAME.FieldName = "GL_ITEM_NAME"
        Me.colGL_ITEM_NAME.Name = "colGL_ITEM_NAME"
        Me.colGL_ITEM_NAME.Visible = True
        Me.colGL_ITEM_NAME.VisibleIndex = 1
        Me.colGL_ITEM_NAME.Width = 395
        '
        'LoadGL_btn
        '
        Me.LoadGL_btn.ImageIndex = 6
        Me.LoadGL_btn.ImageList = Me.ImageCollection1
        Me.LoadGL_btn.Location = New System.Drawing.Point(236, 101)
        Me.LoadGL_btn.Name = "LoadGL_btn"
        Me.LoadGL_btn.Size = New System.Drawing.Size(110, 23)
        Me.LoadGL_btn.TabIndex = 9
        Me.LoadGL_btn.Text = "Load Data"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(130, 83)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 21)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Date till"
        '
        'GL_BookingDate_Till
        '
        Me.GL_BookingDate_Till.EditValue = Nothing
        Me.GL_BookingDate_Till.Location = New System.Drawing.Point(130, 104)
        Me.GL_BookingDate_Till.Name = "GL_BookingDate_Till"
        Me.GL_BookingDate_Till.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.GL_BookingDate_Till.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.GL_BookingDate_Till.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.GL_BookingDate_Till.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.GL_BookingDate_Till.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.GL_BookingDate_Till.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GL_BookingDate_Till.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GL_BookingDate_Till.Size = New System.Drawing.Size(100, 20)
        Me.GL_BookingDate_Till.TabIndex = 8
        '
        'GL_BookingDate_From
        '
        Me.GL_BookingDate_From.EditValue = Nothing
        Me.GL_BookingDate_From.Location = New System.Drawing.Point(14, 104)
        Me.GL_BookingDate_From.Name = "GL_BookingDate_From"
        Me.GL_BookingDate_From.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.GL_BookingDate_From.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.GL_BookingDate_From.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.GL_BookingDate_From.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.GL_BookingDate_From.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.GL_BookingDate_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GL_BookingDate_From.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.GL_BookingDate_From.Size = New System.Drawing.Size(100, 20)
        Me.GL_BookingDate_From.TabIndex = 6
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(14, 83)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 20)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Date from"
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl2.Controls.Add(Me.SimpleButton1)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.ComboBoxEdit1)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.OCBS_LookUpEdit)
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_btn)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_Till)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_From)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Location = New System.Drawing.Point(820, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(492, 221)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Search by OCBS PROFIT + LOSS Accounts"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageIndex = 6
        Me.SimpleButton1.ImageList = Me.ImageCollection1
        Me.SimpleButton1.Location = New System.Drawing.Point(352, 101)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(127, 23)
        Me.SimpleButton1.TabIndex = 34
        Me.SimpleButton1.Text = "Load All OCBS Acc."
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.Location = New System.Drawing.Point(239, 130)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(186, 69)
        Me.LabelControl3.TabIndex = 33
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.Location = New System.Drawing.Point(14, 130)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(186, 69)
        Me.LabelControl4.TabIndex = 32
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl5.Location = New System.Drawing.Point(14, 62)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(457, 22)
        Me.LabelControl5.TabIndex = 31
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(206, 39)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ComboBoxEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ComboBoxEdit1.Properties.Appearance.Options.UseFont = True
        Me.ComboBoxEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ComboBoxEdit1.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ComboBoxEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ComboBoxEdit1.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.Items.AddRange(New Object() {"***", "EUR", "USD", "GBP", "JPY", "CHF", "CNY"})
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(66, 20)
        Me.ComboBoxEdit1.TabIndex = 4
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl6.Location = New System.Drawing.Point(206, 25)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl6.TabIndex = 3
        Me.LabelControl6.Text = "Currency"
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
        Me.LabelControl11.Text = "OCBS Account"
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
        Me.OCBS_LookUpEdit.Properties.DataSource = Me.PROFIT_and_LOSS_MAPPINGBindingSource
        Me.OCBS_LookUpEdit.Properties.DisplayMember = "GL_ACC_Nr"
        Me.OCBS_LookUpEdit.Properties.NullText = ""
        Me.OCBS_LookUpEdit.Properties.ValueMember = "GL_ACC_Nr"
        Me.OCBS_LookUpEdit.Properties.View = Me.GridView1
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGL_ACC_Nr, Me.colGL_ACC_Name, Me.colGL_ITEM_Mapped})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colGL_ACC_Nr
        '
        Me.colGL_ACC_Nr.Caption = "OCBS Account Nr."
        Me.colGL_ACC_Nr.FieldName = "GL_ACC_Nr"
        Me.colGL_ACC_Nr.Name = "colGL_ACC_Nr"
        Me.colGL_ACC_Nr.Visible = True
        Me.colGL_ACC_Nr.VisibleIndex = 0
        Me.colGL_ACC_Nr.Width = 103
        '
        'colGL_ACC_Name
        '
        Me.colGL_ACC_Name.Caption = "OCBS Account Name"
        Me.colGL_ACC_Name.FieldName = "GL_ACC_Name"
        Me.colGL_ACC_Name.Name = "colGL_ACC_Name"
        Me.colGL_ACC_Name.Visible = True
        Me.colGL_ACC_Name.VisibleIndex = 1
        Me.colGL_ACC_Name.Width = 474
        '
        'colGL_ITEM_Mapped
        '
        Me.colGL_ITEM_Mapped.Caption = "Mapped GL Item"
        Me.colGL_ITEM_Mapped.FieldName = "GL_ITEM_Mapped"
        Me.colGL_ITEM_Mapped.Name = "colGL_ITEM_Mapped"
        Me.colGL_ITEM_Mapped.Visible = True
        Me.colGL_ITEM_Mapped.VisibleIndex = 2
        Me.colGL_ITEM_Mapped.Width = 93
        '
        'LoadOCBS_btn
        '
        Me.LoadOCBS_btn.ImageIndex = 6
        Me.LoadOCBS_btn.ImageList = Me.ImageCollection1
        Me.LoadOCBS_btn.Location = New System.Drawing.Point(236, 101)
        Me.LoadOCBS_btn.Name = "LoadOCBS_btn"
        Me.LoadOCBS_btn.Size = New System.Drawing.Size(110, 23)
        Me.LoadOCBS_btn.TabIndex = 9
        Me.LoadOCBS_btn.Text = "Load Data"
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
        'PROFIT_and_LOSS_GL_ITEMSTableAdapter
        '
        Me.PROFIT_and_LOSS_GL_ITEMSTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.SearchText_lbl)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(1, 239)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1322, 486)
        Me.LayoutControl1.TabIndex = 117
        Me.LayoutControl1.Text = "LayoutControl1"
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
        Me.SearchText_lbl.Size = New System.Drawing.Size(1298, 16)
        Me.SearchText_lbl.StyleController = Me.LayoutControl1
        Me.SearchText_lbl.TabIndex = 117
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(149, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 10
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1223, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(75, 22)
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
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1322, 486)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1302, 396)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1302, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1199, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(79, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(153, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1046, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(153, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchText_lbl
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1302, 20)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'ProfitAndLossBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 727)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProfitAndLossBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profit + Loss Balances"
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROFIT_and_LOSS_VOLUMESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROFIT_and_LOSS_MAPPINGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PL_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_Postings_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GL_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROFIT_and_LOSS_GL_ITEMSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GL_BookingDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GL_BookingDate_Till.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GL_BookingDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GL_BookingDate_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OCBS_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BalancesDataset As PS_TOOL_DX.BalancesDataset
    Friend WithEvents PROFIT_and_LOSS_VOLUMESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROFIT_and_LOSS_VOLUMESTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_VOLUMESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager
    Friend WithEvents PROFIT_and_LOSS_MAPPINGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROFIT_and_LOSS_MAPPINGTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_MAPPINGTableAdapter
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GL_LookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LoadGL_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GL_BookingDate_Till As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GL_BookingDate_From As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_LookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LoadOCBS_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_BookingDate_Till As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OCBS_BookingDate_From As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PROFIT_and_LOSS_GL_ITEMSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROFIT_and_LOSS_GL_ITEMSTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.PROFIT_and_LOSS_GL_ITEMSTableAdapter
    Friend WithEvents colGL_ITEM_NR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ITEM_NAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ACC_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_ITEM_Mapped As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchText_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents PL_Balances_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colIdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBatchNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSequenceNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGLBook As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountingCentre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTransactionTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContractType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEventType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDR_CR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPortfolioCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNarrativeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReferenceCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChequeNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRNAccountingCentre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCheckerID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOtherSystemKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGeneratedType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReversalFlag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_Rep_Date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGL_AC_No_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExchange_Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountInEuro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents OdasImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEditBIC3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
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
End Class
