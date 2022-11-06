<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SwiftStatementsAll
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains1 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SwiftStatementsAll))
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains2 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleContains3 As DevExpress.XtraEditors.FormatConditionRuleContains = New DevExpress.XtraEditors.FormatConditionRuleContains()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.Nostro_Balances_DetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colSwiftFileName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSenderBIC1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colMessageType1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colReceivedDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colOSN1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colOSN_ReceivedDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRef201 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colAccountIdentification1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colInternalAccount2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colStatementNr1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colPageNr1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSwiftTag1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSwiftTagName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colDebitCreditMark1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colFundsCode1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colBookingDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colValueDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colCUR1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colTransactionTypeID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colReferenceAccountOwner1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colReferenceServiInstitution1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colSupplementaryDetails1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colNostro_Name2 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.SWIFT_ACC_STATEMENTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalancesDataset = New PS_TOOL_DX.BalancesDataset()
        Me.Nostro_Balances_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSwiftFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSenderBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMessageType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReceivedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOSN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOSN_ReceivedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRef20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountIdentification = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInternalAccount1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNostro_Name1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatementNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPageNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSwiftTag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSwiftTagName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDebitCreditMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFundsCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBookingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTransactionTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReferenceAccountOwner = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReferenceServiInstitution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSupplementaryDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.OdasImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.SWIFT_ACC_STATEMENTSTableAdapter = New PS_TOOL_DX.BalancesDatasetTableAdapters.SWIFT_ACC_STATEMENTSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.NostroAccountNamelbl = New DevExpress.XtraEditors.LabelControl()
        Me.CURlbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_LookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colExternalAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSenderBICCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInstitutionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoadOCBS_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.OCBS_BookingDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.OCBS_BookingDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
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
        Me.colReconciled = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReconciled_IB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEntryStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUETR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_DebtorAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_DebtorName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_DebtorBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_CreditorAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_CreditorName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedParty_CreditorBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedAgent_InstructingAgent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedAgent_InstructedAgent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLocalInstrument = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRelatedDetails_InterbankSettlementDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReconciled1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colReconciled_IB1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colEntryStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colUETR1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_DebtorAcc1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_CreditorAcc1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_DebtorName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_DebtorBIC1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_CreditorName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedParty_CreditorBIC1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedAgent_InstructingAgent1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedAgent_InstructedAgent1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colLocalInstrument1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.colRelatedDetails_InterbankSettlementDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.layoutViewField_colSwiftFileName2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSenderBIC2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colReceivedDate2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colRef202 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colAccountIdentification2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colStatementNr2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSwiftTag2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colDebitCreditMark2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colBookingDate2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colCUR2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colTransactionTypeID2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colReferenceAccountOwner2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colReferenceServiInstitution2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSupplementaryDetails2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colNostro_Name1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colMessageType2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colOSN2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_colInternalAccount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colPageNr2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colSwiftTagName2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colFundsCode2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_colValueDate2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colAmount2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.item4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_5 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_10 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_12 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_6 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_7 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_8 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_9 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_11 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_LayoutViewColumn1_13 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colID2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.layoutViewField_colOSN_ReceivedDate2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        CType(Me.Nostro_Balances_DetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SWIFT_ACC_STATEMENTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nostro_Balances_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
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
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSwiftFileName2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSenderBIC2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colReceivedDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colRef202, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccountIdentification2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStatementNr2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSwiftTag2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDebitCreditMark2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBookingDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCUR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTransactionTypeID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colReferenceAccountOwner2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colReferenceServiInstitution2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSupplementaryDetails2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNostro_Name1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMessageType2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOSN2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colInternalAccount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPageNr2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSwiftTagName2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFundsCode2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colValueDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAmount2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1_13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOSN_ReceivedDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nostro_Balances_DetailView
        '
        Me.Nostro_Balances_DetailView.Appearance.FieldValue.ForeColor = System.Drawing.Color.Aqua
        Me.Nostro_Balances_DetailView.Appearance.FieldValue.Options.UseForeColor = True
        Me.Nostro_Balances_DetailView.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Nostro_Balances_DetailView.AppearancePrint.FieldValue.Options.UseForeColor = True
        Me.Nostro_Balances_DetailView.CardMinSize = New System.Drawing.Size(1044, 527)
        Me.Nostro_Balances_DetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colSwiftFileName1, Me.colSenderBIC1, Me.colID1, Me.colMessageType1, Me.colReceivedDate1, Me.colOSN1, Me.colOSN_ReceivedDate1, Me.colRef201, Me.colAccountIdentification1, Me.colInternalAccount2, Me.colStatementNr1, Me.colPageNr1, Me.colSwiftTag1, Me.colSwiftTagName1, Me.colDebitCreditMark1, Me.colFundsCode1, Me.colBookingDate1, Me.colValueDate1, Me.colCUR1, Me.colAmount1, Me.colTransactionTypeID1, Me.colReferenceAccountOwner1, Me.colReferenceServiInstitution1, Me.colSupplementaryDetails1, Me.colNostro_Name2, Me.colReconciled1, Me.colReconciled_IB1, Me.colEntryStatus1, Me.colUETR1, Me.colRelatedParty_DebtorAcc1, Me.colRelatedParty_CreditorAcc1, Me.colRelatedParty_DebtorName1, Me.colRelatedParty_DebtorBIC1, Me.colRelatedParty_CreditorName1, Me.colRelatedParty_CreditorBIC1, Me.colRelatedAgent_InstructingAgent1, Me.colRelatedAgent_InstructedAgent1, Me.colLocalInstrument1, Me.colRelatedDetails_InterbankSettlementDate1})
        Me.Nostro_Balances_DetailView.GridControl = Me.GridControl1
        Me.Nostro_Balances_DetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID2, Me.layoutViewField_colOSN_ReceivedDate2})
        Me.Nostro_Balances_DetailView.Name = "Nostro_Balances_DetailView"
        Me.Nostro_Balances_DetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.Nostro_Balances_DetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.Nostro_Balances_DetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.Nostro_Balances_DetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.Nostro_Balances_DetailView.OptionsBehavior.ReadOnly = True
        Me.Nostro_Balances_DetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.Nostro_Balances_DetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.Nostro_Balances_DetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.Nostro_Balances_DetailView.OptionsCustomization.AllowFilter = False
        Me.Nostro_Balances_DetailView.OptionsCustomization.AllowSort = False
        Me.Nostro_Balances_DetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.Nostro_Balances_DetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.Nostro_Balances_DetailView.OptionsFilter.AllowFilterEditor = False
        Me.Nostro_Balances_DetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.Nostro_Balances_DetailView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Nostro_Balances_DetailView.OptionsFind.AlwaysVisible = True
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.Nostro_Balances_DetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.Nostro_Balances_DetailView.OptionsView.ShowHeaderPanel = False
        Me.Nostro_Balances_DetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colSwiftFileName1
        '
        Me.colSwiftFileName1.AppearanceCell.Options.UseTextOptions = True
        Me.colSwiftFileName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSwiftFileName1.Caption = "Swift File Name"
        Me.colSwiftFileName1.CustomizationCaption = "Swift File Name"
        Me.colSwiftFileName1.FieldName = "SwiftFileName"
        Me.colSwiftFileName1.LayoutViewField = Me.layoutViewField_colSwiftFileName2
        Me.colSwiftFileName1.Name = "colSwiftFileName1"
        Me.colSwiftFileName1.OptionsColumn.ReadOnly = True
        '
        'colSenderBIC1
        '
        Me.colSenderBIC1.AppearanceCell.Options.UseTextOptions = True
        Me.colSenderBIC1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSenderBIC1.CustomizationCaption = "Sender BIC"
        Me.colSenderBIC1.FieldName = "SenderBIC"
        Me.colSenderBIC1.LayoutViewField = Me.layoutViewField_colSenderBIC2
        Me.colSenderBIC1.Name = "colSenderBIC1"
        Me.colSenderBIC1.OptionsColumn.ReadOnly = True
        '
        'colID1
        '
        Me.colID1.AppearanceCell.Options.UseTextOptions = True
        Me.colID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colID1.CustomizationCaption = "ID"
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID2
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colMessageType1
        '
        Me.colMessageType1.AppearanceCell.Options.UseTextOptions = True
        Me.colMessageType1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colMessageType1.CustomizationCaption = "Message Type"
        Me.colMessageType1.FieldName = "MessageType"
        Me.colMessageType1.LayoutViewField = Me.layoutViewField_colMessageType2
        Me.colMessageType1.Name = "colMessageType1"
        Me.colMessageType1.OptionsColumn.ReadOnly = True
        '
        'colReceivedDate1
        '
        Me.colReceivedDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colReceivedDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colReceivedDate1.CustomizationCaption = "Received Date"
        Me.colReceivedDate1.FieldName = "ReceivedDate"
        Me.colReceivedDate1.LayoutViewField = Me.layoutViewField_colReceivedDate2
        Me.colReceivedDate1.Name = "colReceivedDate1"
        Me.colReceivedDate1.OptionsColumn.ReadOnly = True
        '
        'colOSN1
        '
        Me.colOSN1.AppearanceCell.Options.UseTextOptions = True
        Me.colOSN1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colOSN1.CustomizationCaption = "OSN"
        Me.colOSN1.FieldName = "OSN"
        Me.colOSN1.LayoutViewField = Me.layoutViewField_colOSN2
        Me.colOSN1.Name = "colOSN1"
        Me.colOSN1.OptionsColumn.ReadOnly = True
        '
        'colOSN_ReceivedDate1
        '
        Me.colOSN_ReceivedDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colOSN_ReceivedDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colOSN_ReceivedDate1.CustomizationCaption = "OSN_Received Date"
        Me.colOSN_ReceivedDate1.FieldName = "OSN_ReceivedDate"
        Me.colOSN_ReceivedDate1.LayoutViewField = Me.layoutViewField_colOSN_ReceivedDate2
        Me.colOSN_ReceivedDate1.Name = "colOSN_ReceivedDate1"
        Me.colOSN_ReceivedDate1.OptionsColumn.ReadOnly = True
        '
        'colRef201
        '
        Me.colRef201.AppearanceCell.Options.UseTextOptions = True
        Me.colRef201.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colRef201.CustomizationCaption = "Ref20"
        Me.colRef201.FieldName = "Ref20"
        Me.colRef201.LayoutViewField = Me.layoutViewField_colRef202
        Me.colRef201.Name = "colRef201"
        Me.colRef201.OptionsColumn.ReadOnly = True
        '
        'colAccountIdentification1
        '
        Me.colAccountIdentification1.AppearanceCell.Options.UseTextOptions = True
        Me.colAccountIdentification1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAccountIdentification1.CustomizationCaption = "Account Identification"
        Me.colAccountIdentification1.FieldName = "AccountIdentification"
        Me.colAccountIdentification1.LayoutViewField = Me.layoutViewField_colAccountIdentification2
        Me.colAccountIdentification1.Name = "colAccountIdentification1"
        Me.colAccountIdentification1.OptionsColumn.ReadOnly = True
        '
        'colInternalAccount2
        '
        Me.colInternalAccount2.AppearanceCell.Options.UseTextOptions = True
        Me.colInternalAccount2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colInternalAccount2.CustomizationCaption = "Internal Account"
        Me.colInternalAccount2.FieldName = "InternalAccount"
        Me.colInternalAccount2.LayoutViewField = Me.layoutViewField_colInternalAccount1
        Me.colInternalAccount2.Name = "colInternalAccount2"
        Me.colInternalAccount2.OptionsColumn.ReadOnly = True
        '
        'colStatementNr1
        '
        Me.colStatementNr1.AppearanceCell.Options.UseTextOptions = True
        Me.colStatementNr1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colStatementNr1.CustomizationCaption = "Statement Nr"
        Me.colStatementNr1.FieldName = "StatementNr"
        Me.colStatementNr1.LayoutViewField = Me.layoutViewField_colStatementNr2
        Me.colStatementNr1.Name = "colStatementNr1"
        Me.colStatementNr1.OptionsColumn.ReadOnly = True
        '
        'colPageNr1
        '
        Me.colPageNr1.AppearanceCell.Options.UseTextOptions = True
        Me.colPageNr1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colPageNr1.CustomizationCaption = "Page Nr"
        Me.colPageNr1.FieldName = "PageNr"
        Me.colPageNr1.LayoutViewField = Me.layoutViewField_colPageNr2
        Me.colPageNr1.Name = "colPageNr1"
        Me.colPageNr1.OptionsColumn.ReadOnly = True
        '
        'colSwiftTag1
        '
        Me.colSwiftTag1.AppearanceCell.Options.UseTextOptions = True
        Me.colSwiftTag1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSwiftTag1.CustomizationCaption = "Swift Tag"
        Me.colSwiftTag1.FieldName = "SwiftTag"
        Me.colSwiftTag1.LayoutViewField = Me.layoutViewField_colSwiftTag2
        Me.colSwiftTag1.Name = "colSwiftTag1"
        Me.colSwiftTag1.OptionsColumn.ReadOnly = True
        '
        'colSwiftTagName1
        '
        Me.colSwiftTagName1.AppearanceCell.Options.UseTextOptions = True
        Me.colSwiftTagName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSwiftTagName1.CustomizationCaption = "Swift Tag Name"
        Me.colSwiftTagName1.FieldName = "SwiftTagName"
        Me.colSwiftTagName1.LayoutViewField = Me.layoutViewField_colSwiftTagName2
        Me.colSwiftTagName1.Name = "colSwiftTagName1"
        Me.colSwiftTagName1.OptionsColumn.ReadOnly = True
        '
        'colDebitCreditMark1
        '
        Me.colDebitCreditMark1.AppearanceCell.Options.UseTextOptions = True
        Me.colDebitCreditMark1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colDebitCreditMark1.CustomizationCaption = "Debit Credit Mark"
        Me.colDebitCreditMark1.FieldName = "DebitCreditMark"
        Me.colDebitCreditMark1.LayoutViewField = Me.layoutViewField_colDebitCreditMark2
        Me.colDebitCreditMark1.Name = "colDebitCreditMark1"
        Me.colDebitCreditMark1.OptionsColumn.ReadOnly = True
        '
        'colFundsCode1
        '
        Me.colFundsCode1.AppearanceCell.Options.UseTextOptions = True
        Me.colFundsCode1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colFundsCode1.CustomizationCaption = "Funds Code"
        Me.colFundsCode1.FieldName = "FundsCode"
        Me.colFundsCode1.LayoutViewField = Me.layoutViewField_colFundsCode2
        Me.colFundsCode1.Name = "colFundsCode1"
        Me.colFundsCode1.OptionsColumn.ReadOnly = True
        '
        'colBookingDate1
        '
        Me.colBookingDate1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colBookingDate1.AppearanceCell.Options.UseFont = True
        Me.colBookingDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colBookingDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBookingDate1.CustomizationCaption = "Booking Date"
        Me.colBookingDate1.FieldName = "BookingDate"
        Me.colBookingDate1.LayoutViewField = Me.layoutViewField_colBookingDate2
        Me.colBookingDate1.Name = "colBookingDate1"
        Me.colBookingDate1.OptionsColumn.ReadOnly = True
        '
        'colValueDate1
        '
        Me.colValueDate1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colValueDate1.AppearanceCell.Options.UseFont = True
        Me.colValueDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colValueDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colValueDate1.CustomizationCaption = "Value Date"
        Me.colValueDate1.FieldName = "ValueDate"
        Me.colValueDate1.LayoutViewField = Me.layoutViewField_colValueDate2
        Me.colValueDate1.Name = "colValueDate1"
        Me.colValueDate1.OptionsColumn.ReadOnly = True
        '
        'colCUR1
        '
        Me.colCUR1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colCUR1.AppearanceCell.Options.UseFont = True
        Me.colCUR1.AppearanceCell.Options.UseTextOptions = True
        Me.colCUR1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colCUR1.CustomizationCaption = "CUR"
        Me.colCUR1.FieldName = "CUR"
        Me.colCUR1.LayoutViewField = Me.layoutViewField_colCUR2
        Me.colCUR1.Name = "colCUR1"
        Me.colCUR1.OptionsColumn.ReadOnly = True
        '
        'colAmount1
        '
        Me.colAmount1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAmount1.AppearanceCell.Options.UseFont = True
        Me.colAmount1.AppearanceCell.Options.UseTextOptions = True
        Me.colAmount1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colAmount1.CustomizationCaption = "Amount"
        Me.colAmount1.DisplayFormat.FormatString = "n2"
        Me.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount1.FieldName = "Amount"
        Me.colAmount1.LayoutViewField = Me.layoutViewField_colAmount2
        Me.colAmount1.Name = "colAmount1"
        Me.colAmount1.OptionsColumn.ReadOnly = True
        '
        'colTransactionTypeID1
        '
        Me.colTransactionTypeID1.AppearanceCell.Options.UseTextOptions = True
        Me.colTransactionTypeID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colTransactionTypeID1.Caption = "Transaction Type ID"
        Me.colTransactionTypeID1.CustomizationCaption = "Transaction Type ID"
        Me.colTransactionTypeID1.FieldName = "TransactionTypeID"
        Me.colTransactionTypeID1.LayoutViewField = Me.layoutViewField_colTransactionTypeID2
        Me.colTransactionTypeID1.Name = "colTransactionTypeID1"
        Me.colTransactionTypeID1.OptionsColumn.ReadOnly = True
        '
        'colReferenceAccountOwner1
        '
        Me.colReferenceAccountOwner1.AppearanceCell.Options.UseTextOptions = True
        Me.colReferenceAccountOwner1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colReferenceAccountOwner1.Caption = "Reference for Account Owner"
        Me.colReferenceAccountOwner1.CustomizationCaption = "Reference for Account Owner"
        Me.colReferenceAccountOwner1.FieldName = "ReferenceAccountOwner"
        Me.colReferenceAccountOwner1.LayoutViewField = Me.layoutViewField_colReferenceAccountOwner2
        Me.colReferenceAccountOwner1.Name = "colReferenceAccountOwner1"
        Me.colReferenceAccountOwner1.OptionsColumn.ReadOnly = True
        '
        'colReferenceServiInstitution1
        '
        Me.colReferenceServiInstitution1.AppearanceCell.Options.UseTextOptions = True
        Me.colReferenceServiInstitution1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colReferenceServiInstitution1.Caption = "Reference Servicing Intitution"
        Me.colReferenceServiInstitution1.CustomizationCaption = "Reference Servicing Intitution"
        Me.colReferenceServiInstitution1.FieldName = "ReferenceServiInstitution"
        Me.colReferenceServiInstitution1.LayoutViewField = Me.layoutViewField_colReferenceServiInstitution2
        Me.colReferenceServiInstitution1.Name = "colReferenceServiInstitution1"
        Me.colReferenceServiInstitution1.OptionsColumn.ReadOnly = True
        '
        'colSupplementaryDetails1
        '
        Me.colSupplementaryDetails1.AppearanceCell.Options.UseTextOptions = True
        Me.colSupplementaryDetails1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colSupplementaryDetails1.Caption = "Supplementary Details"
        Me.colSupplementaryDetails1.CustomizationCaption = "Supplementary Details"
        Me.colSupplementaryDetails1.FieldName = "SupplementaryDetails"
        Me.colSupplementaryDetails1.LayoutViewField = Me.layoutViewField_colSupplementaryDetails2
        Me.colSupplementaryDetails1.Name = "colSupplementaryDetails1"
        Me.colSupplementaryDetails1.OptionsColumn.ReadOnly = True
        '
        'colNostro_Name2
        '
        Me.colNostro_Name2.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colNostro_Name2.AppearanceCell.Options.UseFont = True
        Me.colNostro_Name2.AppearanceCell.Options.UseTextOptions = True
        Me.colNostro_Name2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colNostro_Name2.Caption = "Nostro Account Name"
        Me.colNostro_Name2.CustomizationCaption = "Nostro Account Name"
        Me.colNostro_Name2.FieldName = "Nostro_Name"
        Me.colNostro_Name2.LayoutViewField = Me.layoutViewField_colNostro_Name1
        Me.colNostro_Name2.Name = "colNostro_Name2"
        Me.colNostro_Name2.OptionsColumn.ReadOnly = True
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.SWIFT_ACC_STATEMENTSBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.Nostro_Balances_DetailView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(12, 82)
        Me.GridControl1.MainView = Me.Nostro_Balances_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1373, 498)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Nostro_Balances_BasicView, Me.Nostro_Balances_DetailView})
        '
        'SWIFT_ACC_STATEMENTSBindingSource
        '
        Me.SWIFT_ACC_STATEMENTSBindingSource.DataMember = "SWIFT_ACC_STATEMENTS"
        Me.SWIFT_ACC_STATEMENTSBindingSource.DataSource = Me.BalancesDataset
        '
        'BalancesDataset
        '
        Me.BalancesDataset.DataSetName = "BalancesDataset"
        Me.BalancesDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Nostro_Balances_BasicView
        '
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Nostro_Balances_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Nostro_Balances_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.Nostro_Balances_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Nostro_Balances_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colSwiftFileName, Me.colSenderBIC, Me.colMessageType, Me.colReceivedDate, Me.colOSN, Me.colOSN_ReceivedDate, Me.colRef20, Me.colAccountIdentification, Me.colInternalAccount1, Me.colNostro_Name1, Me.colStatementNr, Me.colPageNr, Me.colSwiftTag, Me.colSwiftTagName, Me.colDebitCreditMark, Me.colFundsCode, Me.colBookingDate, Me.colValueDate, Me.colCUR, Me.colAmount, Me.colTransactionTypeID, Me.colReferenceAccountOwner, Me.colReferenceServiInstitution, Me.colSupplementaryDetails, Me.colReconciled, Me.colReconciled_IB, Me.colEntryStatus, Me.colUETR, Me.colRelatedParty_DebtorAcc, Me.colRelatedParty_DebtorName, Me.colRelatedParty_DebtorBIC, Me.colRelatedParty_CreditorAcc, Me.colRelatedParty_CreditorName, Me.colRelatedParty_CreditorBIC, Me.colRelatedAgent_InstructingAgent, Me.colRelatedAgent_InstructedAgent, Me.colLocalInstrument, Me.colRelatedDetails_InterbankSettlementDate})
        Me.Nostro_Balances_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.colSwiftTag
        GridFormatRule1.ColumnApplyTo = Me.colSwiftTagName
        GridFormatRule1.Name = "OpeningBalance"
        FormatConditionRuleContains1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleContains1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleContains1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleContains1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains1.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains1.Appearance.Options.UseFont = True
        FormatConditionRuleContains1.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains1.Appearance.Options.UseTextOptions = True
        FormatConditionRuleContains1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleContains1.Values = CType(resources.GetObject("FormatConditionRuleContains1.Values"), System.Collections.IList)
        GridFormatRule1.Rule = FormatConditionRuleContains1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.colSwiftTag
        GridFormatRule2.ColumnApplyTo = Me.colSwiftTag
        GridFormatRule2.Name = "AvailableFunds"
        FormatConditionRuleContains2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleContains2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleContains2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains2.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains2.Appearance.Options.UseFont = True
        FormatConditionRuleContains2.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains2.Appearance.Options.UseTextOptions = True
        FormatConditionRuleContains2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleContains2.Values = CType(resources.GetObject("FormatConditionRuleContains2.Values"), System.Collections.IList)
        GridFormatRule2.Rule = FormatConditionRuleContains2
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Column = Me.colSwiftTag
        GridFormatRule3.ColumnApplyTo = Me.colSwiftTag
        GridFormatRule3.Name = "IntermediateBalances"
        FormatConditionRuleContains3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleContains3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        FormatConditionRuleContains3.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleContains3.Appearance.Options.UseBackColor = True
        FormatConditionRuleContains3.Appearance.Options.UseFont = True
        FormatConditionRuleContains3.Appearance.Options.UseForeColor = True
        FormatConditionRuleContains3.Values = CType(resources.GetObject("FormatConditionRuleContains3.Values"), System.Collections.IList)
        GridFormatRule3.Rule = FormatConditionRuleContains3
        GridFormatRule4.ApplyToRow = True
        GridFormatRule4.Column = Me.colSwiftTag
        GridFormatRule4.ColumnApplyTo = Me.colSwiftTag
        GridFormatRule4.Name = "ClosingBalance"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Cyan
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.Cyan
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Appearance.Options.UseTextOptions = True
        FormatConditionRuleValue1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = "62F"
        GridFormatRule4.Rule = FormatConditionRuleValue1
        GridFormatRule5.ApplyToRow = True
        GridFormatRule5.Column = Me.colSwiftTag
        GridFormatRule5.ColumnApplyTo = Me.colSwiftTag
        GridFormatRule5.Name = "ForwardAvailableBalance"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Teal
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "65"
        GridFormatRule5.Rule = FormatConditionRuleValue2
        Me.Nostro_Balances_BasicView.FormatRules.Add(GridFormatRule1)
        Me.Nostro_Balances_BasicView.FormatRules.Add(GridFormatRule2)
        Me.Nostro_Balances_BasicView.FormatRules.Add(GridFormatRule3)
        Me.Nostro_Balances_BasicView.FormatRules.Add(GridFormatRule4)
        Me.Nostro_Balances_BasicView.FormatRules.Add(GridFormatRule5)
        Me.Nostro_Balances_BasicView.GridControl = Me.GridControl1
        Me.Nostro_Balances_BasicView.GroupCount = 1
        Me.Nostro_Balances_BasicView.Name = "Nostro_Balances_BasicView"
        Me.Nostro_Balances_BasicView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Nostro_Balances_BasicView.OptionsBehavior.Editable = False
        Me.Nostro_Balances_BasicView.OptionsBehavior.ReadOnly = True
        Me.Nostro_Balances_BasicView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.Nostro_Balances_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Nostro_Balances_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Nostro_Balances_BasicView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.[True]
        Me.Nostro_Balances_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Nostro_Balances_BasicView.OptionsFind.AlwaysVisible = True
        Me.Nostro_Balances_BasicView.OptionsLayout.StoreAllOptions = True
        Me.Nostro_Balances_BasicView.OptionsLayout.StoreAppearance = True
        Me.Nostro_Balances_BasicView.OptionsSelection.MultiSelect = True
        Me.Nostro_Balances_BasicView.OptionsView.ColumnAutoWidth = False
        Me.Nostro_Balances_BasicView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Nostro_Balances_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.Nostro_Balances_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.Nostro_Balances_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Nostro_Balances_BasicView.OptionsView.ShowFooter = True
        Me.Nostro_Balances_BasicView.OptionsView.ShowGroupedColumns = True
        Me.Nostro_Balances_BasicView.OptionsView.ShowGroupPanel = False
        Me.Nostro_Balances_BasicView.PaintStyleName = "Skin"
        Me.Nostro_Balances_BasicView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colReceivedDate, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.Nostro_Balances_BasicView.ViewCaption = "Results by GL Item"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colSwiftFileName
        '
        Me.colSwiftFileName.FieldName = "SwiftFileName"
        Me.colSwiftFileName.Name = "colSwiftFileName"
        Me.colSwiftFileName.Width = 91
        '
        'colSenderBIC
        '
        Me.colSenderBIC.FieldName = "SenderBIC"
        Me.colSenderBIC.Name = "colSenderBIC"
        Me.colSenderBIC.Width = 105
        '
        'colMessageType
        '
        Me.colMessageType.AppearanceCell.Options.UseTextOptions = True
        Me.colMessageType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMessageType.Caption = "Message Type"
        Me.colMessageType.FieldName = "MessageType"
        Me.colMessageType.Name = "colMessageType"
        Me.colMessageType.Visible = True
        Me.colMessageType.VisibleIndex = 0
        Me.colMessageType.Width = 69
        '
        'colReceivedDate
        '
        Me.colReceivedDate.AppearanceCell.Options.UseTextOptions = True
        Me.colReceivedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colReceivedDate.Caption = "Received Date"
        Me.colReceivedDate.FieldName = "ReceivedDate"
        Me.colReceivedDate.Name = "colReceivedDate"
        Me.colReceivedDate.Visible = True
        Me.colReceivedDate.VisibleIndex = 1
        Me.colReceivedDate.Width = 88
        '
        'colOSN
        '
        Me.colOSN.FieldName = "OSN"
        Me.colOSN.Name = "colOSN"
        '
        'colOSN_ReceivedDate
        '
        Me.colOSN_ReceivedDate.FieldName = "OSN_ReceivedDate"
        Me.colOSN_ReceivedDate.Name = "colOSN_ReceivedDate"
        '
        'colRef20
        '
        Me.colRef20.FieldName = "Ref20"
        Me.colRef20.Name = "colRef20"
        '
        'colAccountIdentification
        '
        Me.colAccountIdentification.AppearanceCell.Options.UseTextOptions = True
        Me.colAccountIdentification.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAccountIdentification.Caption = "External Account"
        Me.colAccountIdentification.FieldName = "AccountIdentification"
        Me.colAccountIdentification.Name = "colAccountIdentification"
        Me.colAccountIdentification.Visible = True
        Me.colAccountIdentification.VisibleIndex = 2
        Me.colAccountIdentification.Width = 149
        '
        'colInternalAccount1
        '
        Me.colInternalAccount1.FieldName = "InternalAccount"
        Me.colInternalAccount1.Name = "colInternalAccount1"
        '
        'colNostro_Name1
        '
        Me.colNostro_Name1.Caption = "Nostro Account Name"
        Me.colNostro_Name1.FieldName = "Nostro_Name"
        Me.colNostro_Name1.Name = "colNostro_Name1"
        Me.colNostro_Name1.Width = 347
        '
        'colStatementNr
        '
        Me.colStatementNr.AppearanceCell.Options.UseTextOptions = True
        Me.colStatementNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colStatementNr.Caption = "Statement Nr."
        Me.colStatementNr.FieldName = "StatementNr"
        Me.colStatementNr.Name = "colStatementNr"
        Me.colStatementNr.Visible = True
        Me.colStatementNr.VisibleIndex = 3
        Me.colStatementNr.Width = 81
        '
        'colPageNr
        '
        Me.colPageNr.AppearanceCell.Options.UseTextOptions = True
        Me.colPageNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colPageNr.Caption = "Page Nr."
        Me.colPageNr.FieldName = "PageNr"
        Me.colPageNr.Name = "colPageNr"
        Me.colPageNr.Visible = True
        Me.colPageNr.VisibleIndex = 4
        Me.colPageNr.Width = 61
        '
        'colSwiftTag
        '
        Me.colSwiftTag.AppearanceCell.Options.UseTextOptions = True
        Me.colSwiftTag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSwiftTag.Caption = "Tag"
        Me.colSwiftTag.FieldName = "SwiftTag"
        Me.colSwiftTag.Name = "colSwiftTag"
        Me.colSwiftTag.Visible = True
        Me.colSwiftTag.VisibleIndex = 5
        Me.colSwiftTag.Width = 50
        '
        'colSwiftTagName
        '
        Me.colSwiftTagName.Caption = "Tag Name"
        Me.colSwiftTagName.FieldName = "SwiftTagName"
        Me.colSwiftTagName.Name = "colSwiftTagName"
        Me.colSwiftTagName.Visible = True
        Me.colSwiftTagName.VisibleIndex = 6
        Me.colSwiftTagName.Width = 238
        '
        'colDebitCreditMark
        '
        Me.colDebitCreditMark.AppearanceCell.Options.UseTextOptions = True
        Me.colDebitCreditMark.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDebitCreditMark.Caption = "D/C Mark"
        Me.colDebitCreditMark.FieldName = "DebitCreditMark"
        Me.colDebitCreditMark.Name = "colDebitCreditMark"
        Me.colDebitCreditMark.Visible = True
        Me.colDebitCreditMark.VisibleIndex = 7
        Me.colDebitCreditMark.Width = 61
        '
        'colFundsCode
        '
        Me.colFundsCode.FieldName = "FundsCode"
        Me.colFundsCode.Name = "colFundsCode"
        '
        'colBookingDate
        '
        Me.colBookingDate.AppearanceCell.Options.UseTextOptions = True
        Me.colBookingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colBookingDate.Caption = "Booking Date"
        Me.colBookingDate.FieldName = "BookingDate"
        Me.colBookingDate.Name = "colBookingDate"
        Me.colBookingDate.Visible = True
        Me.colBookingDate.VisibleIndex = 8
        Me.colBookingDate.Width = 88
        '
        'colValueDate
        '
        Me.colValueDate.AppearanceCell.Options.UseTextOptions = True
        Me.colValueDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValueDate.Caption = "Value Date"
        Me.colValueDate.FieldName = "ValueDate"
        Me.colValueDate.Name = "colValueDate"
        Me.colValueDate.Visible = True
        Me.colValueDate.VisibleIndex = 9
        Me.colValueDate.Width = 79
        '
        'colCUR
        '
        Me.colCUR.AppearanceCell.Options.UseTextOptions = True
        Me.colCUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCUR.FieldName = "CUR"
        Me.colCUR.Name = "colCUR"
        Me.colCUR.Visible = True
        Me.colCUR.VisibleIndex = 10
        Me.colCUR.Width = 59
        '
        'colAmount
        '
        Me.colAmount.AppearanceCell.Options.UseTextOptions = True
        Me.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colAmount.DisplayFormat.FormatString = "n2"
        Me.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAmount.FieldName = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Visible = True
        Me.colAmount.VisibleIndex = 11
        Me.colAmount.Width = 134
        '
        'colTransactionTypeID
        '
        Me.colTransactionTypeID.Caption = "Transaction Type ID"
        Me.colTransactionTypeID.FieldName = "TransactionTypeID"
        Me.colTransactionTypeID.Name = "colTransactionTypeID"
        Me.colTransactionTypeID.Visible = True
        Me.colTransactionTypeID.VisibleIndex = 12
        Me.colTransactionTypeID.Width = 85
        '
        'colReferenceAccountOwner
        '
        Me.colReferenceAccountOwner.Caption = "Reference for Account owner"
        Me.colReferenceAccountOwner.FieldName = "ReferenceAccountOwner"
        Me.colReferenceAccountOwner.Name = "colReferenceAccountOwner"
        Me.colReferenceAccountOwner.Visible = True
        Me.colReferenceAccountOwner.VisibleIndex = 13
        Me.colReferenceAccountOwner.Width = 166
        '
        'colReferenceServiInstitution
        '
        Me.colReferenceServiInstitution.Caption = "Reference for servicing Institution"
        Me.colReferenceServiInstitution.FieldName = "ReferenceServiInstitution"
        Me.colReferenceServiInstitution.Name = "colReferenceServiInstitution"
        Me.colReferenceServiInstitution.Visible = True
        Me.colReferenceServiInstitution.VisibleIndex = 14
        Me.colReferenceServiInstitution.Width = 159
        '
        'colSupplementaryDetails
        '
        Me.colSupplementaryDetails.Caption = "Supplementary Details"
        Me.colSupplementaryDetails.FieldName = "SupplementaryDetails"
        Me.colSupplementaryDetails.Name = "colSupplementaryDetails"
        Me.colSupplementaryDetails.Visible = True
        Me.colSupplementaryDetails.VisibleIndex = 15
        Me.colSupplementaryDetails.Width = 326
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
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'SWIFT_ACC_STATEMENTSTableAdapter
        '
        Me.SWIFT_ACC_STATEMENTSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUSTOMER_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_VOSTRO_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.NOSTRO_BALANCESTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.SUSPENCE_VOLUMESTableAdapter = Nothing
        Me.TableAdapterManager.SWIFT_ACC_STATEMENTSTableAdapter = Me.SWIFT_ACC_STATEMENTSTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupControl2.Controls.Add(Me.NostroAccountNamelbl)
        Me.GroupControl2.Controls.Add(Me.CURlbl)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.OCBS_LookUpEdit)
        Me.GroupControl2.Controls.Add(Me.LoadOCBS_btn)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_Till)
        Me.GroupControl2.Controls.Add(Me.OCBS_BookingDate_From)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Location = New System.Drawing.Point(481, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(440, 134)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Search Statements MT940/950 by External Nostro Accounts"
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
        Me.NostroAccountNamelbl.Size = New System.Drawing.Size(403, 22)
        Me.NostroAccountNamelbl.TabIndex = 31
        '
        'CURlbl
        '
        Me.CURlbl.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CURlbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CURlbl.Appearance.Options.UseFont = True
        Me.CURlbl.Appearance.Options.UseForeColor = True
        Me.CURlbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.CURlbl.Location = New System.Drawing.Point(349, 43)
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
        Me.LabelControl11.Text = "External Nostro Account"
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
        Me.OCBS_LookUpEdit.Properties.DisplayMember = "INTERNAL ACCOUNT"
        Me.OCBS_LookUpEdit.Properties.NullText = ""
        Me.OCBS_LookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(800, 650)
        Me.OCBS_LookUpEdit.Properties.PopupView = Me.GridView1
        Me.OCBS_LookUpEdit.Properties.ValueMember = "INTERNAL ACCOUNT"
        Me.OCBS_LookUpEdit.Size = New System.Drawing.Size(329, 20)
        Me.OCBS_LookUpEdit.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colExternalAccount, Me.colCCY, Me.colSenderBICCODE, Me.colInstitutionName})
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
        'colExternalAccount
        '
        Me.colExternalAccount.Caption = "External Account Nr."
        Me.colExternalAccount.FieldName = "External Account Nr."
        Me.colExternalAccount.Name = "colExternalAccount"
        Me.colExternalAccount.OptionsColumn.AllowEdit = False
        Me.colExternalAccount.OptionsColumn.ReadOnly = True
        Me.colExternalAccount.Visible = True
        Me.colExternalAccount.VisibleIndex = 0
        Me.colExternalAccount.Width = 249
        '
        'colCCY
        '
        Me.colCCY.Caption = "CCY"
        Me.colCCY.FieldName = "CCY"
        Me.colCCY.Name = "colCCY"
        Me.colCCY.OptionsColumn.AllowEdit = False
        Me.colCCY.OptionsColumn.ReadOnly = True
        Me.colCCY.Visible = True
        Me.colCCY.VisibleIndex = 1
        Me.colCCY.Width = 49
        '
        'colSenderBICCODE
        '
        Me.colSenderBICCODE.Caption = "Sender BIC"
        Me.colSenderBICCODE.FieldName = "Sender BIC"
        Me.colSenderBICCODE.Name = "colSenderBICCODE"
        Me.colSenderBICCODE.OptionsColumn.AllowEdit = False
        Me.colSenderBICCODE.OptionsColumn.ReadOnly = True
        Me.colSenderBICCODE.Visible = True
        Me.colSenderBICCODE.VisibleIndex = 2
        Me.colSenderBICCODE.Width = 124
        '
        'colInstitutionName
        '
        Me.colInstitutionName.Caption = "Institution Name"
        Me.colInstitutionName.FieldName = "Sender BIC Name"
        Me.colInstitutionName.Name = "colInstitutionName"
        Me.colInstitutionName.OptionsColumn.AllowEdit = False
        Me.colInstitutionName.OptionsColumn.ReadOnly = True
        Me.colInstitutionName.Visible = True
        Me.colInstitutionName.VisibleIndex = 3
        Me.colInstitutionName.Width = 686
        '
        'LoadOCBS_btn
        '
        Me.LoadOCBS_btn.ImageOptions.ImageIndex = 6
        Me.LoadOCBS_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadOCBS_btn.Location = New System.Drawing.Point(256, 101)
        Me.LoadOCBS_btn.Name = "LoadOCBS_btn"
        Me.LoadOCBS_btn.Size = New System.Drawing.Size(161, 23)
        Me.LoadOCBS_btn.TabIndex = 9
        Me.LoadOCBS_btn.Text = "Load postings + Balances"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl12.Appearance.Options.UseFont = True
        Me.LabelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl12.Location = New System.Drawing.Point(139, 83)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(100, 21)
        Me.LabelControl12.TabIndex = 7
        Me.LabelControl12.Text = "Received till"
        '
        'OCBS_BookingDate_Till
        '
        Me.OCBS_BookingDate_Till.EditValue = Nothing
        Me.OCBS_BookingDate_Till.Location = New System.Drawing.Point(139, 104)
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
        Me.LabelControl14.Size = New System.Drawing.Size(100, 20)
        Me.LabelControl14.TabIndex = 5
        Me.LabelControl14.Text = "Received from"
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
        Me.LayoutControl1.Location = New System.Drawing.Point(-1, 146)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1397, 592)
        Me.LayoutControl1.TabIndex = 121
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
        Me.SearchText_lbl.Size = New System.Drawing.Size(1373, 16)
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
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(156, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 10
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 0
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1272, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(101, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "View Details"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1397, 592)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1377, 502)
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
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1377, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1248, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(105, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(160, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1088, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(160, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchText_lbl
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1377, 20)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'colReconciled
        '
        Me.colReconciled.Caption = "Reconciled"
        Me.colReconciled.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colReconciled.FieldName = "Reconciled"
        Me.colReconciled.Name = "colReconciled"
        Me.colReconciled.OptionsColumn.ReadOnly = True
        Me.colReconciled.Visible = True
        Me.colReconciled.VisibleIndex = 16
        Me.colReconciled.Width = 93
        '
        'colReconciled_IB
        '
        Me.colReconciled_IB.Caption = "Reconciled ID"
        Me.colReconciled_IB.FieldName = "Reconciled_IB"
        Me.colReconciled_IB.Name = "colReconciled_IB"
        Me.colReconciled_IB.OptionsColumn.AllowEdit = False
        Me.colReconciled_IB.OptionsColumn.ReadOnly = True
        Me.colReconciled_IB.Visible = True
        Me.colReconciled_IB.VisibleIndex = 17
        Me.colReconciled_IB.Width = 96
        '
        'colEntryStatus
        '
        Me.colEntryStatus.AppearanceCell.Options.UseTextOptions = True
        Me.colEntryStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEntryStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.colEntryStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEntryStatus.Caption = "Entry Status"
        Me.colEntryStatus.FieldName = "EntryStatus"
        Me.colEntryStatus.Name = "colEntryStatus"
        '
        'colUETR
        '
        Me.colUETR.Caption = "UETR"
        Me.colUETR.FieldName = "UETR"
        Me.colUETR.Name = "colUETR"
        '
        'colRelatedParty_DebtorAcc
        '
        Me.colRelatedParty_DebtorAcc.Caption = "Related Party - Debtor Acc."
        Me.colRelatedParty_DebtorAcc.FieldName = "RelatedParty_DebtorAcc"
        Me.colRelatedParty_DebtorAcc.Name = "colRelatedParty_DebtorAcc"
        '
        'colRelatedParty_DebtorName
        '
        Me.colRelatedParty_DebtorName.Caption = "Related Party - Debtor Name"
        Me.colRelatedParty_DebtorName.FieldName = "RelatedParty_DebtorName"
        Me.colRelatedParty_DebtorName.Name = "colRelatedParty_DebtorName"
        '
        'colRelatedParty_DebtorBIC
        '
        Me.colRelatedParty_DebtorBIC.Caption = "Related Party - Debtor BIC"
        Me.colRelatedParty_DebtorBIC.FieldName = "RelatedParty_DebtorBIC"
        Me.colRelatedParty_DebtorBIC.Name = "colRelatedParty_DebtorBIC"
        '
        'colRelatedParty_CreditorAcc
        '
        Me.colRelatedParty_CreditorAcc.Caption = "Related Party - Creditor Acc."
        Me.colRelatedParty_CreditorAcc.FieldName = "RelatedParty_CreditorAcc"
        Me.colRelatedParty_CreditorAcc.Name = "colRelatedParty_CreditorAcc"
        '
        'colRelatedParty_CreditorName
        '
        Me.colRelatedParty_CreditorName.Caption = "Related Party - Creditor Name"
        Me.colRelatedParty_CreditorName.FieldName = "RelatedParty_CreditorName"
        Me.colRelatedParty_CreditorName.Name = "colRelatedParty_CreditorName"
        '
        'colRelatedParty_CreditorBIC
        '
        Me.colRelatedParty_CreditorBIC.Caption = "Related Party - Creditor BIC"
        Me.colRelatedParty_CreditorBIC.FieldName = "RelatedParty_CreditorBIC"
        Me.colRelatedParty_CreditorBIC.Name = "colRelatedParty_CreditorBIC"
        '
        'colRelatedAgent_InstructingAgent
        '
        Me.colRelatedAgent_InstructingAgent.Caption = "Related Agent - Instructing Agent"
        Me.colRelatedAgent_InstructingAgent.FieldName = "RelatedAgent_InstructingAgent"
        Me.colRelatedAgent_InstructingAgent.Name = "colRelatedAgent_InstructingAgent"
        '
        'colRelatedAgent_InstructedAgent
        '
        Me.colRelatedAgent_InstructedAgent.Caption = "Related Agent - Instructed Agent"
        Me.colRelatedAgent_InstructedAgent.FieldName = "RelatedAgent_InstructedAgent"
        Me.colRelatedAgent_InstructedAgent.Name = "colRelatedAgent_InstructedAgent"
        '
        'colLocalInstrument
        '
        Me.colLocalInstrument.Caption = "Local Instrument"
        Me.colLocalInstrument.FieldName = "LocalInstrument"
        Me.colLocalInstrument.Name = "colLocalInstrument"
        Me.colLocalInstrument.Visible = True
        Me.colLocalInstrument.VisibleIndex = 18
        '
        'colRelatedDetails_InterbankSettlementDate
        '
        Me.colRelatedDetails_InterbankSettlementDate.AppearanceCell.Options.UseTextOptions = True
        Me.colRelatedDetails_InterbankSettlementDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRelatedDetails_InterbankSettlementDate.AppearanceHeader.Options.UseTextOptions = True
        Me.colRelatedDetails_InterbankSettlementDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRelatedDetails_InterbankSettlementDate.Caption = "Relaited Details - Interbank Settlement Date"
        Me.colRelatedDetails_InterbankSettlementDate.DisplayFormat.FormatString = "d"
        Me.colRelatedDetails_InterbankSettlementDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colRelatedDetails_InterbankSettlementDate.FieldName = "RelatedDetails_InterbankSettlementDate"
        Me.colRelatedDetails_InterbankSettlementDate.Name = "colRelatedDetails_InterbankSettlementDate"
        '
        'colReconciled1
        '
        Me.colReconciled1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colReconciled1.AppearanceCell.Options.UseFont = True
        Me.colReconciled1.AppearanceCell.Options.UseTextOptions = True
        Me.colReconciled1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colReconciled1.Caption = "Reconciled"
        Me.colReconciled1.ColumnEdit = Me.ValidRepositoryItemImageComboBox
        Me.colReconciled1.FieldName = "Reconciled"
        Me.colReconciled1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.colReconciled1.Name = "colReconciled1"
        Me.colReconciled1.OptionsColumn.ReadOnly = True
        '
        'colReconciled_IB1
        '
        Me.colReconciled_IB1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colReconciled_IB1.AppearanceCell.Options.UseFont = True
        Me.colReconciled_IB1.AppearanceCell.Options.UseTextOptions = True
        Me.colReconciled_IB1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colReconciled_IB1.Caption = "Reconciled IB"
        Me.colReconciled_IB1.FieldName = "Reconciled_IB"
        Me.colReconciled_IB1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_1
        Me.colReconciled_IB1.Name = "colReconciled_IB1"
        Me.colReconciled_IB1.OptionsColumn.ReadOnly = True
        '
        'colEntryStatus1
        '
        Me.colEntryStatus1.Caption = "Entry Status"
        Me.colEntryStatus1.FieldName = "EntryStatus"
        Me.colEntryStatus1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_2
        Me.colEntryStatus1.Name = "colEntryStatus1"
        Me.colEntryStatus1.OptionsColumn.ReadOnly = True
        '
        'colUETR1
        '
        Me.colUETR1.Caption = "UETR"
        Me.colUETR1.FieldName = "UETR"
        Me.colUETR1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_3
        Me.colUETR1.Name = "colUETR1"
        Me.colUETR1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_DebtorAcc1
        '
        Me.colRelatedParty_DebtorAcc1.Caption = "Related Party -Debtor Acc."
        Me.colRelatedParty_DebtorAcc1.FieldName = "RelatedParty_DebtorAcc"
        Me.colRelatedParty_DebtorAcc1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_4
        Me.colRelatedParty_DebtorAcc1.Name = "colRelatedParty_DebtorAcc1"
        Me.colRelatedParty_DebtorAcc1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_CreditorAcc1
        '
        Me.colRelatedParty_CreditorAcc1.Caption = "Related Party - Creditor Acc."
        Me.colRelatedParty_CreditorAcc1.FieldName = "RelatedParty_CreditorAcc"
        Me.colRelatedParty_CreditorAcc1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_5
        Me.colRelatedParty_CreditorAcc1.Name = "colRelatedParty_CreditorAcc1"
        Me.colRelatedParty_CreditorAcc1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_DebtorName1
        '
        Me.colRelatedParty_DebtorName1.Caption = "Related Party - Debtor Name"
        Me.colRelatedParty_DebtorName1.FieldName = "RelatedParty_DebtorName"
        Me.colRelatedParty_DebtorName1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_6
        Me.colRelatedParty_DebtorName1.Name = "colRelatedParty_DebtorName1"
        Me.colRelatedParty_DebtorName1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_DebtorBIC1
        '
        Me.colRelatedParty_DebtorBIC1.Caption = "Related Party - Debtor BIC"
        Me.colRelatedParty_DebtorBIC1.FieldName = "RelatedParty_DebtorBIC"
        Me.colRelatedParty_DebtorBIC1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_7
        Me.colRelatedParty_DebtorBIC1.Name = "colRelatedParty_DebtorBIC1"
        Me.colRelatedParty_DebtorBIC1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_CreditorName1
        '
        Me.colRelatedParty_CreditorName1.Caption = "Related Party - Creditor Name"
        Me.colRelatedParty_CreditorName1.FieldName = "RelatedParty_CreditorName"
        Me.colRelatedParty_CreditorName1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_8
        Me.colRelatedParty_CreditorName1.Name = "colRelatedParty_CreditorName1"
        Me.colRelatedParty_CreditorName1.OptionsColumn.ReadOnly = True
        '
        'colRelatedParty_CreditorBIC1
        '
        Me.colRelatedParty_CreditorBIC1.Caption = "Related Party - Creditor BIC"
        Me.colRelatedParty_CreditorBIC1.FieldName = "RelatedParty_CreditorBIC"
        Me.colRelatedParty_CreditorBIC1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_9
        Me.colRelatedParty_CreditorBIC1.Name = "colRelatedParty_CreditorBIC1"
        Me.colRelatedParty_CreditorBIC1.OptionsColumn.ReadOnly = True
        '
        'colRelatedAgent_InstructingAgent1
        '
        Me.colRelatedAgent_InstructingAgent1.Caption = "Related Agent - Instructing Agent"
        Me.colRelatedAgent_InstructingAgent1.FieldName = "RelatedAgent_InstructingAgent"
        Me.colRelatedAgent_InstructingAgent1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_10
        Me.colRelatedAgent_InstructingAgent1.Name = "colRelatedAgent_InstructingAgent1"
        Me.colRelatedAgent_InstructingAgent1.OptionsColumn.ReadOnly = True
        '
        'colRelatedAgent_InstructedAgent1
        '
        Me.colRelatedAgent_InstructedAgent1.Caption = "Related Agent - Instructed Agent"
        Me.colRelatedAgent_InstructedAgent1.FieldName = "RelatedAgent_InstructedAgent"
        Me.colRelatedAgent_InstructedAgent1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_11
        Me.colRelatedAgent_InstructedAgent1.Name = "colRelatedAgent_InstructedAgent1"
        Me.colRelatedAgent_InstructedAgent1.OptionsColumn.ReadOnly = True
        '
        'colLocalInstrument1
        '
        Me.colLocalInstrument1.Caption = "Local Instrument"
        Me.colLocalInstrument1.FieldName = "LocalInstrument"
        Me.colLocalInstrument1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_12
        Me.colLocalInstrument1.Name = "colLocalInstrument1"
        Me.colLocalInstrument1.OptionsColumn.ReadOnly = True
        '
        'colRelatedDetails_InterbankSettlementDate1
        '
        Me.colRelatedDetails_InterbankSettlementDate1.Caption = "Related Details -Interbank Settlement Date"
        Me.colRelatedDetails_InterbankSettlementDate1.DisplayFormat.FormatString = "d"
        Me.colRelatedDetails_InterbankSettlementDate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colRelatedDetails_InterbankSettlementDate1.FieldName = "RelatedDetails_InterbankSettlementDate"
        Me.colRelatedDetails_InterbankSettlementDate1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1_13
        Me.colRelatedDetails_InterbankSettlementDate1.Name = "colRelatedDetails_InterbankSettlementDate1"
        Me.colRelatedDetails_InterbankSettlementDate1.OptionsColumn.ReadOnly = True
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colSwiftFileName2, Me.layoutViewField_colSenderBIC2, Me.layoutViewField_colReceivedDate2, Me.layoutViewField_colRef202, Me.layoutViewField_colAccountIdentification2, Me.layoutViewField_colStatementNr2, Me.layoutViewField_colSwiftTag2, Me.layoutViewField_colDebitCreditMark2, Me.layoutViewField_colBookingDate2, Me.layoutViewField_colCUR2, Me.layoutViewField_colTransactionTypeID2, Me.layoutViewField_colReferenceAccountOwner2, Me.layoutViewField_colReferenceServiInstitution2, Me.layoutViewField_colSupplementaryDetails2, Me.layoutViewField_colNostro_Name1, Me.layoutViewField_colMessageType2, Me.layoutViewField_colOSN2, Me.item1, Me.layoutViewField_colInternalAccount1, Me.layoutViewField_colPageNr2, Me.layoutViewField_colSwiftTagName2, Me.layoutViewField_colFundsCode2, Me.item3, Me.layoutViewField_colValueDate2, Me.layoutViewField_colAmount2, Me.item4, Me.item5, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_LayoutViewColumn1_1, Me.layoutViewField_LayoutViewColumn1_2, Me.layoutViewField_LayoutViewColumn1_4, Me.layoutViewField_LayoutViewColumn1_5, Me.layoutViewField_LayoutViewColumn1_10, Me.layoutViewField_LayoutViewColumn1_12, Me.layoutViewField_LayoutViewColumn1_3, Me.layoutViewField_LayoutViewColumn1_6, Me.layoutViewField_LayoutViewColumn1_7, Me.layoutViewField_LayoutViewColumn1_8, Me.layoutViewField_LayoutViewColumn1_9, Me.layoutViewField_LayoutViewColumn1_11, Me.layoutViewField_LayoutViewColumn1_13})
        Me.LayoutViewCard1.Name = "layoutViewTemplateCard"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'layoutViewField_colSwiftFileName2
        '
        Me.layoutViewField_colSwiftFileName2.EditorPreferredWidth = 216
        Me.layoutViewField_colSwiftFileName2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colSwiftFileName2.Name = "layoutViewField_colSwiftFileName2"
        Me.layoutViewField_colSwiftFileName2.Size = New System.Drawing.Size(437, 24)
        Me.layoutViewField_colSwiftFileName2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colSenderBIC2
        '
        Me.layoutViewField_colSenderBIC2.EditorPreferredWidth = 216
        Me.layoutViewField_colSenderBIC2.Location = New System.Drawing.Point(0, 24)
        Me.layoutViewField_colSenderBIC2.Name = "layoutViewField_colSenderBIC2"
        Me.layoutViewField_colSenderBIC2.Size = New System.Drawing.Size(437, 24)
        Me.layoutViewField_colSenderBIC2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colReceivedDate2
        '
        Me.layoutViewField_colReceivedDate2.EditorPreferredWidth = 201
        Me.layoutViewField_colReceivedDate2.Location = New System.Drawing.Point(0, 48)
        Me.layoutViewField_colReceivedDate2.Name = "layoutViewField_colReceivedDate2"
        Me.layoutViewField_colReceivedDate2.Size = New System.Drawing.Size(422, 24)
        Me.layoutViewField_colReceivedDate2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colRef202
        '
        Me.layoutViewField_colRef202.EditorPreferredWidth = 804
        Me.layoutViewField_colRef202.Location = New System.Drawing.Point(0, 72)
        Me.layoutViewField_colRef202.Name = "layoutViewField_colRef202"
        Me.layoutViewField_colRef202.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colRef202.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colAccountIdentification2
        '
        Me.layoutViewField_colAccountIdentification2.EditorPreferredWidth = 283
        Me.layoutViewField_colAccountIdentification2.Location = New System.Drawing.Point(0, 96)
        Me.layoutViewField_colAccountIdentification2.Name = "layoutViewField_colAccountIdentification2"
        Me.layoutViewField_colAccountIdentification2.Size = New System.Drawing.Size(504, 24)
        Me.layoutViewField_colAccountIdentification2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colStatementNr2
        '
        Me.layoutViewField_colStatementNr2.EditorPreferredWidth = 283
        Me.layoutViewField_colStatementNr2.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colStatementNr2.Name = "layoutViewField_colStatementNr2"
        Me.layoutViewField_colStatementNr2.Size = New System.Drawing.Size(504, 24)
        Me.layoutViewField_colStatementNr2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colSwiftTag2
        '
        Me.layoutViewField_colSwiftTag2.EditorPreferredWidth = 105
        Me.layoutViewField_colSwiftTag2.Location = New System.Drawing.Point(0, 144)
        Me.layoutViewField_colSwiftTag2.Name = "layoutViewField_colSwiftTag2"
        Me.layoutViewField_colSwiftTag2.Size = New System.Drawing.Size(326, 24)
        Me.layoutViewField_colSwiftTag2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colDebitCreditMark2
        '
        Me.layoutViewField_colDebitCreditMark2.EditorPreferredWidth = 105
        Me.layoutViewField_colDebitCreditMark2.Location = New System.Drawing.Point(0, 168)
        Me.layoutViewField_colDebitCreditMark2.Name = "layoutViewField_colDebitCreditMark2"
        Me.layoutViewField_colDebitCreditMark2.Size = New System.Drawing.Size(326, 24)
        Me.layoutViewField_colDebitCreditMark2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colBookingDate2
        '
        Me.layoutViewField_colBookingDate2.EditorPreferredWidth = 105
        Me.layoutViewField_colBookingDate2.Location = New System.Drawing.Point(0, 192)
        Me.layoutViewField_colBookingDate2.Name = "layoutViewField_colBookingDate2"
        Me.layoutViewField_colBookingDate2.Size = New System.Drawing.Size(326, 24)
        Me.layoutViewField_colBookingDate2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colCUR2
        '
        Me.layoutViewField_colCUR2.EditorPreferredWidth = 105
        Me.layoutViewField_colCUR2.Location = New System.Drawing.Point(0, 216)
        Me.layoutViewField_colCUR2.Name = "layoutViewField_colCUR2"
        Me.layoutViewField_colCUR2.Size = New System.Drawing.Size(326, 24)
        Me.layoutViewField_colCUR2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colTransactionTypeID2
        '
        Me.layoutViewField_colTransactionTypeID2.EditorPreferredWidth = 804
        Me.layoutViewField_colTransactionTypeID2.Location = New System.Drawing.Point(0, 240)
        Me.layoutViewField_colTransactionTypeID2.Name = "layoutViewField_colTransactionTypeID2"
        Me.layoutViewField_colTransactionTypeID2.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colTransactionTypeID2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colReferenceAccountOwner2
        '
        Me.layoutViewField_colReferenceAccountOwner2.EditorPreferredWidth = 804
        Me.layoutViewField_colReferenceAccountOwner2.Location = New System.Drawing.Point(0, 264)
        Me.layoutViewField_colReferenceAccountOwner2.Name = "layoutViewField_colReferenceAccountOwner2"
        Me.layoutViewField_colReferenceAccountOwner2.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colReferenceAccountOwner2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colReferenceServiInstitution2
        '
        Me.layoutViewField_colReferenceServiInstitution2.EditorPreferredWidth = 804
        Me.layoutViewField_colReferenceServiInstitution2.Location = New System.Drawing.Point(0, 288)
        Me.layoutViewField_colReferenceServiInstitution2.Name = "layoutViewField_colReferenceServiInstitution2"
        Me.layoutViewField_colReferenceServiInstitution2.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colReferenceServiInstitution2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colSupplementaryDetails2
        '
        Me.layoutViewField_colSupplementaryDetails2.EditorPreferredWidth = 804
        Me.layoutViewField_colSupplementaryDetails2.Location = New System.Drawing.Point(0, 312)
        Me.layoutViewField_colSupplementaryDetails2.Name = "layoutViewField_colSupplementaryDetails2"
        Me.layoutViewField_colSupplementaryDetails2.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colSupplementaryDetails2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colNostro_Name1
        '
        Me.layoutViewField_colNostro_Name1.EditorPreferredWidth = 804
        Me.layoutViewField_colNostro_Name1.Location = New System.Drawing.Point(0, 336)
        Me.layoutViewField_colNostro_Name1.Name = "layoutViewField_colNostro_Name1"
        Me.layoutViewField_colNostro_Name1.Size = New System.Drawing.Size(1026, 24)
        Me.layoutViewField_colNostro_Name1.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colMessageType2
        '
        Me.layoutViewField_colMessageType2.EditorPreferredWidth = 226
        Me.layoutViewField_colMessageType2.Location = New System.Drawing.Point(437, 0)
        Me.layoutViewField_colMessageType2.Name = "layoutViewField_colMessageType2"
        Me.layoutViewField_colMessageType2.Size = New System.Drawing.Size(309, 24)
        Me.layoutViewField_colMessageType2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colMessageType2.TextSize = New System.Drawing.Size(73, 13)
        Me.layoutViewField_colMessageType2.TextToControlDistance = 5
        '
        'layoutViewField_colOSN2
        '
        Me.layoutViewField_colOSN2.EditorPreferredWidth = 554
        Me.layoutViewField_colOSN2.Location = New System.Drawing.Point(437, 24)
        Me.layoutViewField_colOSN2.Name = "layoutViewField_colOSN2"
        Me.layoutViewField_colOSN2.Size = New System.Drawing.Size(589, 24)
        Me.layoutViewField_colOSN2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colOSN2.TextSize = New System.Drawing.Size(25, 13)
        Me.layoutViewField_colOSN2.TextToControlDistance = 5
        '
        'item1
        '
        Me.item1.AllowHotTrack = False
        Me.item1.CustomizationFormText = "item1"
        Me.item1.Location = New System.Drawing.Point(746, 0)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(280, 24)
        Me.item1.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_colInternalAccount1
        '
        Me.layoutViewField_colInternalAccount1.EditorPreferredWidth = 428
        Me.layoutViewField_colInternalAccount1.Location = New System.Drawing.Point(504, 96)
        Me.layoutViewField_colInternalAccount1.Name = "layoutViewField_colInternalAccount1"
        Me.layoutViewField_colInternalAccount1.Size = New System.Drawing.Size(522, 24)
        Me.layoutViewField_colInternalAccount1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colInternalAccount1.TextSize = New System.Drawing.Size(84, 13)
        Me.layoutViewField_colInternalAccount1.TextToControlDistance = 5
        '
        'layoutViewField_colPageNr2
        '
        Me.layoutViewField_colPageNr2.EditorPreferredWidth = 470
        Me.layoutViewField_colPageNr2.Location = New System.Drawing.Point(504, 120)
        Me.layoutViewField_colPageNr2.Name = "layoutViewField_colPageNr2"
        Me.layoutViewField_colPageNr2.Size = New System.Drawing.Size(522, 24)
        Me.layoutViewField_colPageNr2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colPageNr2.TextSize = New System.Drawing.Size(42, 13)
        Me.layoutViewField_colPageNr2.TextToControlDistance = 5
        '
        'layoutViewField_colSwiftTagName2
        '
        Me.layoutViewField_colSwiftTagName2.EditorPreferredWidth = 611
        Me.layoutViewField_colSwiftTagName2.Location = New System.Drawing.Point(326, 144)
        Me.layoutViewField_colSwiftTagName2.Name = "layoutViewField_colSwiftTagName2"
        Me.layoutViewField_colSwiftTagName2.Size = New System.Drawing.Size(700, 24)
        Me.layoutViewField_colSwiftTagName2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colSwiftTagName2.TextSize = New System.Drawing.Size(79, 13)
        Me.layoutViewField_colSwiftTagName2.TextToControlDistance = 5
        '
        'layoutViewField_colFundsCode2
        '
        Me.layoutViewField_colFundsCode2.EditorPreferredWidth = 194
        Me.layoutViewField_colFundsCode2.Location = New System.Drawing.Point(326, 168)
        Me.layoutViewField_colFundsCode2.Name = "layoutViewField_colFundsCode2"
        Me.layoutViewField_colFundsCode2.Size = New System.Drawing.Size(264, 24)
        Me.layoutViewField_colFundsCode2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colFundsCode2.TextSize = New System.Drawing.Size(61, 13)
        Me.layoutViewField_colFundsCode2.TextToControlDistance = 5
        '
        'item3
        '
        Me.item3.AllowHotTrack = False
        Me.item3.CustomizationFormText = "item3"
        Me.item3.Location = New System.Drawing.Point(590, 168)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(436, 24)
        Me.item3.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_colValueDate2
        '
        Me.layoutViewField_colValueDate2.EditorPreferredWidth = 199
        Me.layoutViewField_colValueDate2.Location = New System.Drawing.Point(326, 192)
        Me.layoutViewField_colValueDate2.Name = "layoutViewField_colValueDate2"
        Me.layoutViewField_colValueDate2.Size = New System.Drawing.Size(264, 24)
        Me.layoutViewField_colValueDate2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colValueDate2.TextSize = New System.Drawing.Size(56, 13)
        Me.layoutViewField_colValueDate2.TextToControlDistance = 5
        '
        'layoutViewField_colAmount2
        '
        Me.layoutViewField_colAmount2.EditorPreferredWidth = 336
        Me.layoutViewField_colAmount2.Location = New System.Drawing.Point(326, 216)
        Me.layoutViewField_colAmount2.Name = "layoutViewField_colAmount2"
        Me.layoutViewField_colAmount2.Size = New System.Drawing.Size(387, 24)
        Me.layoutViewField_colAmount2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_colAmount2.TextSize = New System.Drawing.Size(41, 13)
        Me.layoutViewField_colAmount2.TextToControlDistance = 5
        '
        'item4
        '
        Me.item4.AllowHotTrack = False
        Me.item4.CustomizationFormText = "item4"
        Me.item4.Location = New System.Drawing.Point(590, 192)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(436, 24)
        Me.item4.TextSize = New System.Drawing.Size(0, 0)
        '
        'item5
        '
        Me.item5.AllowHotTrack = False
        Me.item5.CustomizationFormText = "item5"
        Me.item5.Location = New System.Drawing.Point(713, 216)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(313, 24)
        Me.item5.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 200
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(422, 48)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(264, 24)
        Me.layoutViewField_LayoutViewColumn1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(55, 13)
        Me.layoutViewField_LayoutViewColumn1.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_1
        '
        Me.layoutViewField_LayoutViewColumn1_1.EditorPreferredWidth = 262
        Me.layoutViewField_LayoutViewColumn1_1.Location = New System.Drawing.Point(686, 48)
        Me.layoutViewField_LayoutViewColumn1_1.Name = "layoutViewField_LayoutViewColumn1_1"
        Me.layoutViewField_LayoutViewColumn1_1.Size = New System.Drawing.Size(340, 24)
        Me.layoutViewField_LayoutViewColumn1_1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_1.TextSize = New System.Drawing.Size(68, 13)
        Me.layoutViewField_LayoutViewColumn1_1.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_2
        '
        Me.layoutViewField_LayoutViewColumn1_2.EditorPreferredWidth = 216
        Me.layoutViewField_LayoutViewColumn1_2.Location = New System.Drawing.Point(0, 360)
        Me.layoutViewField_LayoutViewColumn1_2.Name = "layoutViewField_LayoutViewColumn1_2"
        Me.layoutViewField_LayoutViewColumn1_2.Size = New System.Drawing.Size(437, 24)
        Me.layoutViewField_LayoutViewColumn1_2.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_LayoutViewColumn1_4
        '
        Me.layoutViewField_LayoutViewColumn1_4.EditorPreferredWidth = 215
        Me.layoutViewField_LayoutViewColumn1_4.Location = New System.Drawing.Point(0, 384)
        Me.layoutViewField_LayoutViewColumn1_4.Name = "layoutViewField_LayoutViewColumn1_4"
        Me.layoutViewField_LayoutViewColumn1_4.Size = New System.Drawing.Size(436, 24)
        Me.layoutViewField_LayoutViewColumn1_4.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_LayoutViewColumn1_5
        '
        Me.layoutViewField_LayoutViewColumn1_5.EditorPreferredWidth = 216
        Me.layoutViewField_LayoutViewColumn1_5.Location = New System.Drawing.Point(0, 408)
        Me.layoutViewField_LayoutViewColumn1_5.Name = "layoutViewField_LayoutViewColumn1_5"
        Me.layoutViewField_LayoutViewColumn1_5.Size = New System.Drawing.Size(437, 24)
        Me.layoutViewField_LayoutViewColumn1_5.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_LayoutViewColumn1_10
        '
        Me.layoutViewField_LayoutViewColumn1_10.EditorPreferredWidth = 370
        Me.layoutViewField_LayoutViewColumn1_10.Location = New System.Drawing.Point(0, 432)
        Me.layoutViewField_LayoutViewColumn1_10.Name = "layoutViewField_LayoutViewColumn1_10"
        Me.layoutViewField_LayoutViewColumn1_10.Size = New System.Drawing.Size(591, 24)
        Me.layoutViewField_LayoutViewColumn1_10.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_LayoutViewColumn1_12
        '
        Me.layoutViewField_LayoutViewColumn1_12.EditorPreferredWidth = 291
        Me.layoutViewField_LayoutViewColumn1_12.Location = New System.Drawing.Point(0, 456)
        Me.layoutViewField_LayoutViewColumn1_12.Name = "layoutViewField_LayoutViewColumn1_12"
        Me.layoutViewField_LayoutViewColumn1_12.Size = New System.Drawing.Size(512, 24)
        Me.layoutViewField_LayoutViewColumn1_12.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_LayoutViewColumn1_3
        '
        Me.layoutViewField_LayoutViewColumn1_3.EditorPreferredWidth = 549
        Me.layoutViewField_LayoutViewColumn1_3.Location = New System.Drawing.Point(437, 360)
        Me.layoutViewField_LayoutViewColumn1_3.Name = "layoutViewField_LayoutViewColumn1_3"
        Me.layoutViewField_LayoutViewColumn1_3.Size = New System.Drawing.Size(589, 24)
        Me.layoutViewField_LayoutViewColumn1_3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_3.TextSize = New System.Drawing.Size(30, 13)
        Me.layoutViewField_LayoutViewColumn1_3.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_6
        '
        Me.layoutViewField_LayoutViewColumn1_6.EditorPreferredWidth = 154
        Me.layoutViewField_LayoutViewColumn1_6.Location = New System.Drawing.Point(436, 384)
        Me.layoutViewField_LayoutViewColumn1_6.Name = "layoutViewField_LayoutViewColumn1_6"
        Me.layoutViewField_LayoutViewColumn1_6.Size = New System.Drawing.Size(307, 24)
        Me.layoutViewField_LayoutViewColumn1_6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_6.TextSize = New System.Drawing.Size(143, 13)
        Me.layoutViewField_LayoutViewColumn1_6.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_7
        '
        Me.layoutViewField_LayoutViewColumn1_7.EditorPreferredWidth = 141
        Me.layoutViewField_LayoutViewColumn1_7.Location = New System.Drawing.Point(743, 384)
        Me.layoutViewField_LayoutViewColumn1_7.Name = "layoutViewField_LayoutViewColumn1_7"
        Me.layoutViewField_LayoutViewColumn1_7.Size = New System.Drawing.Size(283, 24)
        Me.layoutViewField_LayoutViewColumn1_7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_7.TextSize = New System.Drawing.Size(133, 13)
        Me.layoutViewField_LayoutViewColumn1_7.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_8
        '
        Me.layoutViewField_LayoutViewColumn1_8.EditorPreferredWidth = 150
        Me.layoutViewField_LayoutViewColumn1_8.Location = New System.Drawing.Point(437, 408)
        Me.layoutViewField_LayoutViewColumn1_8.Name = "layoutViewField_LayoutViewColumn1_8"
        Me.layoutViewField_LayoutViewColumn1_8.Size = New System.Drawing.Size(309, 24)
        Me.layoutViewField_LayoutViewColumn1_8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_8.TextSize = New System.Drawing.Size(149, 13)
        Me.layoutViewField_LayoutViewColumn1_8.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_9
        '
        Me.layoutViewField_LayoutViewColumn1_9.EditorPreferredWidth = 132
        Me.layoutViewField_LayoutViewColumn1_9.Location = New System.Drawing.Point(746, 408)
        Me.layoutViewField_LayoutViewColumn1_9.Name = "layoutViewField_LayoutViewColumn1_9"
        Me.layoutViewField_LayoutViewColumn1_9.Size = New System.Drawing.Size(280, 24)
        Me.layoutViewField_LayoutViewColumn1_9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_9.TextSize = New System.Drawing.Size(139, 13)
        Me.layoutViewField_LayoutViewColumn1_9.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_11
        '
        Me.layoutViewField_LayoutViewColumn1_11.EditorPreferredWidth = 260
        Me.layoutViewField_LayoutViewColumn1_11.Location = New System.Drawing.Point(591, 432)
        Me.layoutViewField_LayoutViewColumn1_11.Name = "layoutViewField_LayoutViewColumn1_11"
        Me.layoutViewField_LayoutViewColumn1_11.Size = New System.Drawing.Size(435, 24)
        Me.layoutViewField_LayoutViewColumn1_11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.layoutViewField_LayoutViewColumn1_11.TextSize = New System.Drawing.Size(165, 13)
        Me.layoutViewField_LayoutViewColumn1_11.TextToControlDistance = 5
        '
        'layoutViewField_LayoutViewColumn1_13
        '
        Me.layoutViewField_LayoutViewColumn1_13.EditorPreferredWidth = 293
        Me.layoutViewField_LayoutViewColumn1_13.Location = New System.Drawing.Point(512, 456)
        Me.layoutViewField_LayoutViewColumn1_13.Name = "layoutViewField_LayoutViewColumn1_13"
        Me.layoutViewField_LayoutViewColumn1_13.Size = New System.Drawing.Size(514, 24)
        Me.layoutViewField_LayoutViewColumn1_13.TextSize = New System.Drawing.Size(211, 13)
        '
        'layoutViewField_colID2
        '
        Me.layoutViewField_colID2.EditorPreferredWidth = 20
        Me.layoutViewField_colID2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID2.Name = "layoutViewField_colID2"
        Me.layoutViewField_colID2.Size = New System.Drawing.Size(1024, 480)
        Me.layoutViewField_colID2.TextSize = New System.Drawing.Size(133, 13)
        '
        'layoutViewField_colOSN_ReceivedDate2
        '
        Me.layoutViewField_colOSN_ReceivedDate2.EditorPreferredWidth = 20
        Me.layoutViewField_colOSN_ReceivedDate2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colOSN_ReceivedDate2.Name = "layoutViewField_colOSN_ReceivedDate2"
        Me.layoutViewField_colOSN_ReceivedDate2.Size = New System.Drawing.Size(1024, 480)
        Me.layoutViewField_colOSN_ReceivedDate2.TextSize = New System.Drawing.Size(148, 13)
        '
        'SwiftStatementsAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1392, 733)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.IconOptions.Icon = CType(resources.GetObject("SwiftStatementsAll.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "SwiftStatementsAll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Swift Account Statemenst (All external Nostro Accounts)"
        CType(Me.Nostro_Balances_DetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SWIFT_ACC_STATEMENTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalancesDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nostro_Balances_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
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
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSwiftFileName2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSenderBIC2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colReceivedDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colRef202, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccountIdentification2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStatementNr2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSwiftTag2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDebitCreditMark2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBookingDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCUR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTransactionTypeID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colReferenceAccountOwner2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colReferenceServiInstitution2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSupplementaryDetails2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNostro_Name1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMessageType2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOSN2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colInternalAccount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPageNr2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSwiftTagName2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFundsCode2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colValueDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAmount2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1_13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOSN_ReceivedDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BalancesDataset As PS_TOOL_DX.BalancesDataset
    Friend WithEvents SWIFT_ACC_STATEMENTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SWIFT_ACC_STATEMENTSTableAdapter As PS_TOOL_DX.BalancesDatasetTableAdapters.SWIFT_ACC_STATEMENTSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.BalancesDatasetTableAdapters.TableAdapterManager
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents NostroAccountNamelbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CURlbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OCBS_LookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents Nostro_Balances_DetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colSwiftFileName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSenderBIC1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colMessageType1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colReceivedDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colOSN1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colOSN_ReceivedDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colRef201 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAccountIdentification1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colInternalAccount2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStatementNr1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colPageNr1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSwiftTag1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSwiftTagName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colDebitCreditMark1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFundsCode1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBookingDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colValueDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCUR1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colAmount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTransactionTypeID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colReferenceAccountOwner1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colReferenceServiInstitution1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colSupplementaryDetails1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colNostro_Name2 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents Nostro_Balances_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSwiftFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSenderBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMessageType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOSN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOSN_ReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRef20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountIdentification As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInternalAccount1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNostro_Name1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatementNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPageNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSwiftTag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSwiftTagName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDebitCreditMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFundsCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBookingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTransactionTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReferenceAccountOwner As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReferenceServiInstitution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSupplementaryDetails As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents colExternalAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSenderBICCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInstitutionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents layoutViewField_colSwiftFileName2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSenderBIC2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colID2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colMessageType2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colReceivedDate2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colOSN2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colOSN_ReceivedDate2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colRef202 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAccountIdentification2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colInternalAccount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStatementNr2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colPageNr2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSwiftTag2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSwiftTagName2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colDebitCreditMark2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFundsCode2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBookingDate2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colValueDate2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCUR2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colAmount2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTransactionTypeID2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colReferenceAccountOwner2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colReferenceServiInstitution2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colSupplementaryDetails2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colNostro_Name1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colReconciled1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colReconciled_IB1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colEntryStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colUETR1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_DebtorAcc1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_CreditorAcc1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_5 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_DebtorName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_6 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_DebtorBIC1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_7 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_CreditorName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_8 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedParty_CreditorBIC1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_9 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedAgent_InstructingAgent1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_10 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedAgent_InstructedAgent1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_11 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colLocalInstrument1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_12 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colRelatedDetails_InterbankSettlementDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_LayoutViewColumn1_13 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colReconciled As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReconciled_IB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEntryStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUETR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_DebtorAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_DebtorName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_DebtorBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_CreditorAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_CreditorName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedParty_CreditorBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedAgent_InstructingAgent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedAgent_InstructedAgent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLocalInstrument As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelatedDetails_InterbankSettlementDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents item1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item5 As DevExpress.XtraLayout.EmptySpaceItem
End Class
