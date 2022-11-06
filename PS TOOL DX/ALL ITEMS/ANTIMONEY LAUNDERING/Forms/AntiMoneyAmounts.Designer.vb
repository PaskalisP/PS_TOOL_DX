<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AntiMoneyAmounts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AntiMoneyAmounts))
        Me.AntiMoneyLaunderingDataset = New PS_TOOL_DX.AntiMoneyLaunderingDataset()
        Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter = New PS_TOOL_DX.AntiMoneyLaunderingDatasetTableAdapters.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.AntiMoneyLaunderingDatasetTableAdapters.TableAdapterManager()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TransactionDate_Till = New DevExpress.XtraEditors.DateEdit()
        Me.TransactionDate_From = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LoadData_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Print_Export_Gridview_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Edit_BICDIR_Details_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AntiMoney_PaymentsAmounts_BasicView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEM00KEY0 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEM00KEY1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEM00KEY2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOURTRANREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINWARDOUTWARD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMETHOD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEIVERBRANCH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEIVERID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEIVERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECEIVERSWIFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSENDERCORBKID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSENDERCORRNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSENDERCORRBR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSENDERCORRST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECRCORRID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECRCORRNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECRCORRBR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRECRCORRSWIFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACWITHINSTID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACWITHINSTNA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACWITHINSTBR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACWITHINSTST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFACNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFCUSTBR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFCUSTID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFCUSTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFCUSTADR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBENEFCUSTADR2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDETOFCHARGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSETOREINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTRANSACTIONDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDealAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXCHANGE_RATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDealAmountEuro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHANDLINGFEE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTBR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTADD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTADD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHOLDFUNC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDERCUSTADD3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSWIFTINREF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIMPORTDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBEMERKUNGEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colACCWITHINSTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.OdasImportProcedureRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEditBIC3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.ValidRepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
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
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        CType(Me.AntiMoneyLaunderingDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDate_Till.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDate_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AntiMoney_PaymentsAmounts_BasicView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AntiMoneyLaunderingDataset
        '
        Me.AntiMoneyLaunderingDataset.DataSetName = "AntiMoneyLaunderingDataset"
        Me.AntiMoneyLaunderingDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource
        '
        Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource.DataMember = "ANTIMONEY_LAUND_PAYMENTS_AMOUNTS"
        Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource.DataSource = Me.AntiMoneyLaunderingDataset
        '
        'ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter
        '
        Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter = Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter
        Me.TableAdapterManager.ANTIMONEY_LAUND_PAYMENTS_ITEMSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.AntiMoneyLaunderingDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(129, 34)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 21)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Date till"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(13, 34)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 20)
        Me.LabelControl2.TabIndex = 20
        Me.LabelControl2.Text = "Date from"
        '
        'TransactionDate_Till
        '
        Me.TransactionDate_Till.EditValue = Nothing
        Me.TransactionDate_Till.Location = New System.Drawing.Point(129, 55)
        Me.TransactionDate_Till.Name = "TransactionDate_Till"
        Me.TransactionDate_Till.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TransactionDate_Till.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TransactionDate_Till.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TransactionDate_Till.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TransactionDate_Till.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TransactionDate_Till.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TransactionDate_Till.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TransactionDate_Till.Size = New System.Drawing.Size(100, 20)
        Me.TransactionDate_Till.TabIndex = 3
        '
        'TransactionDate_From
        '
        Me.TransactionDate_From.EditValue = Nothing
        Me.TransactionDate_From.Location = New System.Drawing.Point(13, 55)
        Me.TransactionDate_From.Name = "TransactionDate_From"
        Me.TransactionDate_From.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TransactionDate_From.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TransactionDate_From.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TransactionDate_From.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TransactionDate_From.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TransactionDate_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TransactionDate_From.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TransactionDate_From.Size = New System.Drawing.Size(100, 20)
        Me.TransactionDate_From.TabIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupControl1.Controls.Add(Me.LoadData_btn)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TransactionDate_Till)
        Me.GroupControl1.Controls.Add(Me.TransactionDate_From)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Location = New System.Drawing.Point(480, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(351, 96)
        Me.GroupControl1.TabIndex = 113
        Me.GroupControl1.Text = "Search by TRANSACTIONDATE"
        '
        'LoadData_btn
        '
        Me.LoadData_btn.ImageOptions.ImageIndex = 6
        Me.LoadData_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.LoadData_btn.Location = New System.Drawing.Point(235, 52)
        Me.LoadData_btn.Name = "LoadData_btn"
        Me.LoadData_btn.Size = New System.Drawing.Size(110, 23)
        Me.LoadData_btn.TabIndex = 8
        Me.LoadData_btn.Text = "Load Data"
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
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_Gridview_btn)
        Me.LayoutControl1.Controls.Add(Me.Edit_BICDIR_Details_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(-4, 114)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1348, 610)
        Me.LayoutControl1.TabIndex = 114
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Print_Export_Gridview_btn
        '
        Me.Print_Export_Gridview_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_Gridview_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_Gridview_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_Gridview_btn.Location = New System.Drawing.Point(24, 24)
        Me.Print_Export_Gridview_btn.Name = "Print_Export_Gridview_btn"
        Me.Print_Export_Gridview_btn.Size = New System.Drawing.Size(152, 22)
        Me.Print_Export_Gridview_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_Gridview_btn.TabIndex = 6
        Me.Print_Export_Gridview_btn.Text = "Print or Export"
        '
        'Edit_BICDIR_Details_btn
        '
        Me.Edit_BICDIR_Details_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Edit_BICDIR_Details_btn.ImageOptions.ImageIndex = 5
        Me.Edit_BICDIR_Details_btn.Location = New System.Drawing.Point(1247, 24)
        Me.Edit_BICDIR_Details_btn.Name = "Edit_BICDIR_Details_btn"
        Me.Edit_BICDIR_Details_btn.Size = New System.Drawing.Size(77, 22)
        Me.Edit_BICDIR_Details_btn.StyleController = Me.LayoutControl1
        Me.Edit_BICDIR_Details_btn.TabIndex = 4
        Me.Edit_BICDIR_Details_btn.Text = "Edit Details"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Location = New System.Drawing.Point(12, 62)
        Me.GridControl1.MainView = Me.AntiMoney_PaymentsAmounts_BasicView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.OdasImportProcedureRepositoryItemTextEdit, Me.RepositoryItemTextEditBIC8, Me.RepositoryItemTextEditBIC3, Me.RepositoryItemMemoExEdit2, Me.ValidRepositoryItemImageComboBox})
        Me.GridControl1.Size = New System.Drawing.Size(1324, 536)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AntiMoney_PaymentsAmounts_BasicView, Me.LayoutView1})
        '
        'AntiMoney_PaymentsAmounts_BasicView
        '
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.AntiMoney_PaymentsAmounts_BasicView.Appearance.GroupRow.Options.UseForeColor = True
        Me.AntiMoney_PaymentsAmounts_BasicView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AntiMoney_PaymentsAmounts_BasicView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AntiMoney_PaymentsAmounts_BasicView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.AntiMoney_PaymentsAmounts_BasicView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.AntiMoney_PaymentsAmounts_BasicView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colEM00KEY0, Me.colClientAccount, Me.colEM00KEY1, Me.colEM00KEY2, Me.colOURTRANREFNO, Me.colINWARDOUTWARD, Me.colMETHOD, Me.colRECEIVERBRANCH, Me.colRECEIVERID, Me.colRECEIVERNAME, Me.colRECEIVERSWIFT, Me.colSENDERCORBKID, Me.colSENDERCORRNAME, Me.colSENDERCORRBR, Me.colSENDERCORRST, Me.colRECRCORRID, Me.colRECRCORRNAME, Me.colRECRCORRBR, Me.colRECRCORRSWIFT, Me.colACWITHINSTID, Me.colACWITHINSTNA, Me.colACWITHINSTBR, Me.colACWITHINSTST, Me.colBENEFACNO, Me.colBENEFCUSTBR, Me.colBENEFCUSTID, Me.colBENEFCUSTNAME, Me.colBENEFCUSTADR1, Me.colBENEFCUSTADR2, Me.colDETOFCHARGE, Me.colSETOREINFO, Me.colCURRENCYCODE, Me.colTRANSACTIONDATE, Me.colVALUEDATE, Me.colDealAmount, Me.colEXCHANGE_RATE, Me.colDealAmountEuro, Me.colHANDLINGFEE, Me.colORDERCUSTBR, Me.colORDERCUSTID, Me.colORDERCUSTNAME, Me.colORDERCUSTADD1, Me.colORDERCUSTADD2, Me.colHOLDFUNC, Me.colORDERCUSTADD3, Me.colSWIFTINREF, Me.colIMPORTDATE, Me.colBEMERKUNGEN, Me.colIdBank, Me.GridColumn1, Me.colACCWITHINSTNAME})
        Me.AntiMoney_PaymentsAmounts_BasicView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.AntiMoney_PaymentsAmounts_BasicView.GridControl = Me.GridControl1
        Me.AntiMoney_PaymentsAmounts_BasicView.GroupCount = 2
        Me.AntiMoney_PaymentsAmounts_BasicView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Deal Amount Euro", Nothing, "Sum in €={0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", Nothing, "Items={0:n0}")})
        Me.AntiMoney_PaymentsAmounts_BasicView.Name = "AntiMoney_PaymentsAmounts_BasicView"
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsBehavior.AllowIncrementalSearch = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsCustomization.AllowRowSizing = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFind.AlwaysVisible = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsFind.SearchInPreview = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsLayout.StoreAllOptions = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsLayout.StoreAppearance = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsSelection.MultiSelect = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.ColumnAutoWidth = False
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.ShowAutoFilterRow = True
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.AntiMoney_PaymentsAmounts_BasicView.OptionsView.ShowFooter = True
        Me.AntiMoney_PaymentsAmounts_BasicView.PaintStyleName = "Skin"
        Me.AntiMoney_PaymentsAmounts_BasicView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colTRANSACTIONDATE, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colORDERCUSTID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.AppearanceHeader.Options.UseFont = True
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        '
        'colEM00KEY0
        '
        Me.colEM00KEY0.AppearanceHeader.Options.UseFont = True
        Me.colEM00KEY0.Caption = "PAYMENT REFERENCE"
        Me.colEM00KEY0.CustomizationCaption = "PAYMENT REFERENCE"
        Me.colEM00KEY0.FieldName = "EM00KEY0"
        Me.colEM00KEY0.Name = "colEM00KEY0"
        Me.colEM00KEY0.OptionsColumn.AllowEdit = False
        Me.colEM00KEY0.Visible = True
        Me.colEM00KEY0.VisibleIndex = 0
        Me.colEM00KEY0.Width = 160
        '
        'colClientAccount
        '
        Me.colClientAccount.AppearanceHeader.Options.UseFont = True
        Me.colClientAccount.Caption = "DEBIT ACCOUNT"
        Me.colClientAccount.CustomizationCaption = "DEBIT ACCOUNT"
        Me.colClientAccount.FieldName = "Client Account"
        Me.colClientAccount.Name = "colClientAccount"
        Me.colClientAccount.OptionsColumn.AllowEdit = False
        Me.colClientAccount.Visible = True
        Me.colClientAccount.VisibleIndex = 1
        Me.colClientAccount.Width = 145
        '
        'colEM00KEY1
        '
        Me.colEM00KEY1.AppearanceHeader.Options.UseFont = True
        Me.colEM00KEY1.FieldName = "EM00KEY1"
        Me.colEM00KEY1.Name = "colEM00KEY1"
        Me.colEM00KEY1.OptionsColumn.AllowEdit = False
        '
        'colEM00KEY2
        '
        Me.colEM00KEY2.AppearanceHeader.Options.UseFont = True
        Me.colEM00KEY2.FieldName = "EM00KEY2"
        Me.colEM00KEY2.Name = "colEM00KEY2"
        Me.colEM00KEY2.OptionsColumn.AllowEdit = False
        '
        'colOURTRANREFNO
        '
        Me.colOURTRANREFNO.AppearanceHeader.Options.UseFont = True
        Me.colOURTRANREFNO.FieldName = "OURTRANREFNO"
        Me.colOURTRANREFNO.Name = "colOURTRANREFNO"
        Me.colOURTRANREFNO.OptionsColumn.AllowEdit = False
        '
        'colINWARDOUTWARD
        '
        Me.colINWARDOUTWARD.AppearanceHeader.Options.UseFont = True
        Me.colINWARDOUTWARD.FieldName = "INWARDOUTWARD"
        Me.colINWARDOUTWARD.Name = "colINWARDOUTWARD"
        Me.colINWARDOUTWARD.OptionsColumn.AllowEdit = False
        '
        'colMETHOD
        '
        Me.colMETHOD.AppearanceHeader.Options.UseFont = True
        Me.colMETHOD.FieldName = "METHOD"
        Me.colMETHOD.Name = "colMETHOD"
        Me.colMETHOD.OptionsColumn.AllowEdit = False
        '
        'colRECEIVERBRANCH
        '
        Me.colRECEIVERBRANCH.AppearanceHeader.Options.UseFont = True
        Me.colRECEIVERBRANCH.FieldName = "RECEIVERBRANCH"
        Me.colRECEIVERBRANCH.Name = "colRECEIVERBRANCH"
        Me.colRECEIVERBRANCH.OptionsColumn.AllowEdit = False
        '
        'colRECEIVERID
        '
        Me.colRECEIVERID.AppearanceHeader.Options.UseFont = True
        Me.colRECEIVERID.FieldName = "RECEIVERID"
        Me.colRECEIVERID.Name = "colRECEIVERID"
        Me.colRECEIVERID.OptionsColumn.AllowEdit = False
        '
        'colRECEIVERNAME
        '
        Me.colRECEIVERNAME.AppearanceHeader.Options.UseFont = True
        Me.colRECEIVERNAME.FieldName = "RECEIVERNAME"
        Me.colRECEIVERNAME.Name = "colRECEIVERNAME"
        Me.colRECEIVERNAME.OptionsColumn.AllowEdit = False
        '
        'colRECEIVERSWIFT
        '
        Me.colRECEIVERSWIFT.AppearanceHeader.Options.UseFont = True
        Me.colRECEIVERSWIFT.FieldName = "RECEIVERSWIFT"
        Me.colRECEIVERSWIFT.Name = "colRECEIVERSWIFT"
        Me.colRECEIVERSWIFT.OptionsColumn.AllowEdit = False
        '
        'colSENDERCORBKID
        '
        Me.colSENDERCORBKID.AppearanceHeader.Options.UseFont = True
        Me.colSENDERCORBKID.FieldName = "SENDERCORBKID"
        Me.colSENDERCORBKID.Name = "colSENDERCORBKID"
        Me.colSENDERCORBKID.OptionsColumn.AllowEdit = False
        '
        'colSENDERCORRNAME
        '
        Me.colSENDERCORRNAME.AppearanceHeader.Options.UseFont = True
        Me.colSENDERCORRNAME.FieldName = "SENDERCORRNAME"
        Me.colSENDERCORRNAME.Name = "colSENDERCORRNAME"
        Me.colSENDERCORRNAME.OptionsColumn.AllowEdit = False
        '
        'colSENDERCORRBR
        '
        Me.colSENDERCORRBR.AppearanceHeader.Options.UseFont = True
        Me.colSENDERCORRBR.FieldName = "SENDERCORRBR"
        Me.colSENDERCORRBR.Name = "colSENDERCORRBR"
        Me.colSENDERCORRBR.OptionsColumn.AllowEdit = False
        '
        'colSENDERCORRST
        '
        Me.colSENDERCORRST.AppearanceHeader.Options.UseFont = True
        Me.colSENDERCORRST.FieldName = "SENDERCORRST"
        Me.colSENDERCORRST.Name = "colSENDERCORRST"
        Me.colSENDERCORRST.OptionsColumn.AllowEdit = False
        '
        'colRECRCORRID
        '
        Me.colRECRCORRID.AppearanceHeader.Options.UseFont = True
        Me.colRECRCORRID.FieldName = "RECRCORRID"
        Me.colRECRCORRID.Name = "colRECRCORRID"
        Me.colRECRCORRID.OptionsColumn.AllowEdit = False
        '
        'colRECRCORRNAME
        '
        Me.colRECRCORRNAME.AppearanceHeader.Options.UseFont = True
        Me.colRECRCORRNAME.FieldName = "RECRCORRNAME"
        Me.colRECRCORRNAME.Name = "colRECRCORRNAME"
        Me.colRECRCORRNAME.OptionsColumn.AllowEdit = False
        '
        'colRECRCORRBR
        '
        Me.colRECRCORRBR.AppearanceHeader.Options.UseFont = True
        Me.colRECRCORRBR.FieldName = "RECRCORRBR"
        Me.colRECRCORRBR.Name = "colRECRCORRBR"
        Me.colRECRCORRBR.OptionsColumn.AllowEdit = False
        '
        'colRECRCORRSWIFT
        '
        Me.colRECRCORRSWIFT.AppearanceHeader.Options.UseFont = True
        Me.colRECRCORRSWIFT.FieldName = "RECRCORRSWIFT"
        Me.colRECRCORRSWIFT.Name = "colRECRCORRSWIFT"
        Me.colRECRCORRSWIFT.OptionsColumn.AllowEdit = False
        '
        'colACWITHINSTID
        '
        Me.colACWITHINSTID.AppearanceHeader.Options.UseFont = True
        Me.colACWITHINSTID.FieldName = "ACWITHINSTID"
        Me.colACWITHINSTID.Name = "colACWITHINSTID"
        Me.colACWITHINSTID.OptionsColumn.AllowEdit = False
        '
        'colACWITHINSTNA
        '
        Me.colACWITHINSTNA.AppearanceHeader.Options.UseFont = True
        Me.colACWITHINSTNA.Caption = "BENEFICIARIES INST."
        Me.colACWITHINSTNA.CustomizationCaption = "BENEFICIARIES INST."
        Me.colACWITHINSTNA.FieldName = "ACWITHINSTNA"
        Me.colACWITHINSTNA.Name = "colACWITHINSTNA"
        Me.colACWITHINSTNA.OptionsColumn.AllowEdit = False
        Me.colACWITHINSTNA.Width = 120
        '
        'colACWITHINSTBR
        '
        Me.colACWITHINSTBR.AppearanceHeader.Options.UseFont = True
        Me.colACWITHINSTBR.FieldName = "ACWITHINSTBR"
        Me.colACWITHINSTBR.Name = "colACWITHINSTBR"
        Me.colACWITHINSTBR.OptionsColumn.AllowEdit = False
        '
        'colACWITHINSTST
        '
        Me.colACWITHINSTST.AppearanceHeader.Options.UseFont = True
        Me.colACWITHINSTST.FieldName = "ACWITHINSTST"
        Me.colACWITHINSTST.Name = "colACWITHINSTST"
        Me.colACWITHINSTST.OptionsColumn.AllowEdit = False
        '
        'colBENEFACNO
        '
        Me.colBENEFACNO.AppearanceHeader.Options.UseFont = True
        Me.colBENEFACNO.Caption = "BENEFICIARIES ACC.NR."
        Me.colBENEFACNO.CustomizationCaption = "BENEFICIARIES ACC.NR."
        Me.colBENEFACNO.FieldName = "BENEFACNO"
        Me.colBENEFACNO.Name = "colBENEFACNO"
        Me.colBENEFACNO.OptionsColumn.AllowEdit = False
        Me.colBENEFACNO.Visible = True
        Me.colBENEFACNO.VisibleIndex = 6
        Me.colBENEFACNO.Width = 141
        '
        'colBENEFCUSTBR
        '
        Me.colBENEFCUSTBR.AppearanceHeader.Options.UseFont = True
        Me.colBENEFCUSTBR.FieldName = "BENEFCUSTBR"
        Me.colBENEFCUSTBR.Name = "colBENEFCUSTBR"
        Me.colBENEFCUSTBR.OptionsColumn.AllowEdit = False
        '
        'colBENEFCUSTID
        '
        Me.colBENEFCUSTID.AppearanceHeader.Options.UseFont = True
        Me.colBENEFCUSTID.FieldName = "BENEFCUSTID"
        Me.colBENEFCUSTID.Name = "colBENEFCUSTID"
        Me.colBENEFCUSTID.OptionsColumn.AllowEdit = False
        '
        'colBENEFCUSTNAME
        '
        Me.colBENEFCUSTNAME.AppearanceHeader.Options.UseFont = True
        Me.colBENEFCUSTNAME.FieldName = "BENEFCUSTNAME"
        Me.colBENEFCUSTNAME.Name = "colBENEFCUSTNAME"
        Me.colBENEFCUSTNAME.OptionsColumn.AllowEdit = False
        '
        'colBENEFCUSTADR1
        '
        Me.colBENEFCUSTADR1.AppearanceHeader.Options.UseFont = True
        Me.colBENEFCUSTADR1.FieldName = "BENEFCUSTADR1"
        Me.colBENEFCUSTADR1.Name = "colBENEFCUSTADR1"
        Me.colBENEFCUSTADR1.OptionsColumn.AllowEdit = False
        '
        'colBENEFCUSTADR2
        '
        Me.colBENEFCUSTADR2.AppearanceHeader.Options.UseFont = True
        Me.colBENEFCUSTADR2.FieldName = "BENEFCUSTADR2"
        Me.colBENEFCUSTADR2.Name = "colBENEFCUSTADR2"
        Me.colBENEFCUSTADR2.OptionsColumn.AllowEdit = False
        '
        'colDETOFCHARGE
        '
        Me.colDETOFCHARGE.AppearanceHeader.Options.UseFont = True
        Me.colDETOFCHARGE.FieldName = "DETOFCHARGE"
        Me.colDETOFCHARGE.Name = "colDETOFCHARGE"
        Me.colDETOFCHARGE.OptionsColumn.AllowEdit = False
        '
        'colSETOREINFO
        '
        Me.colSETOREINFO.AppearanceHeader.Options.UseFont = True
        Me.colSETOREINFO.Caption = "SENDER TO RECEIVER INFO"
        Me.colSETOREINFO.CustomizationCaption = "SENDER TO RECEIVER INFO"
        Me.colSETOREINFO.FieldName = "SETOREINFO"
        Me.colSETOREINFO.Name = "colSETOREINFO"
        Me.colSETOREINFO.OptionsColumn.AllowEdit = False
        Me.colSETOREINFO.Width = 170
        '
        'colCURRENCYCODE
        '
        Me.colCURRENCYCODE.AppearanceHeader.Options.UseFont = True
        Me.colCURRENCYCODE.FieldName = "CURRENCYCODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        '
        'colTRANSACTIONDATE
        '
        Me.colTRANSACTIONDATE.AppearanceCell.Options.UseTextOptions = True
        Me.colTRANSACTIONDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTRANSACTIONDATE.AppearanceHeader.Options.UseFont = True
        Me.colTRANSACTIONDATE.Caption = "TRANSACTION DATE"
        Me.colTRANSACTIONDATE.CustomizationCaption = "TRANSACTION DATE"
        Me.colTRANSACTIONDATE.FieldName = "TRANSACTIONDATE"
        Me.colTRANSACTIONDATE.Name = "colTRANSACTIONDATE"
        Me.colTRANSACTIONDATE.OptionsColumn.AllowEdit = False
        Me.colTRANSACTIONDATE.Visible = True
        Me.colTRANSACTIONDATE.VisibleIndex = 0
        Me.colTRANSACTIONDATE.Width = 123
        '
        'colVALUEDATE
        '
        Me.colVALUEDATE.AppearanceCell.Options.UseTextOptions = True
        Me.colVALUEDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colVALUEDATE.AppearanceHeader.Options.UseFont = True
        Me.colVALUEDATE.Caption = "VALUE DATE"
        Me.colVALUEDATE.CustomizationCaption = "VALUE DATE"
        Me.colVALUEDATE.FieldName = "VALUEDATE"
        Me.colVALUEDATE.Name = "colVALUEDATE"
        Me.colVALUEDATE.OptionsColumn.AllowEdit = False
        Me.colVALUEDATE.Visible = True
        Me.colVALUEDATE.VisibleIndex = 4
        Me.colVALUEDATE.Width = 82
        '
        'colDealAmount
        '
        Me.colDealAmount.AppearanceHeader.Options.UseFont = True
        Me.colDealAmount.DisplayFormat.FormatString = "n2"
        Me.colDealAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDealAmount.FieldName = "Deal Amount"
        Me.colDealAmount.Name = "colDealAmount"
        Me.colDealAmount.OptionsColumn.AllowEdit = False
        '
        'colEXCHANGE_RATE
        '
        Me.colEXCHANGE_RATE.AppearanceHeader.Options.UseFont = True
        Me.colEXCHANGE_RATE.DisplayFormat.FormatString = "n4"
        Me.colEXCHANGE_RATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colEXCHANGE_RATE.FieldName = "EXCHANGE_RATE"
        Me.colEXCHANGE_RATE.Name = "colEXCHANGE_RATE"
        Me.colEXCHANGE_RATE.OptionsColumn.AllowEdit = False
        '
        'colDealAmountEuro
        '
        Me.colDealAmountEuro.AppearanceHeader.Options.UseFont = True
        Me.colDealAmountEuro.Caption = "PAYMENT AMOUNT (In Euro)"
        Me.colDealAmountEuro.CustomizationCaption = "PAYMENT AMOUNT (In Euro)"
        Me.colDealAmountEuro.DisplayFormat.FormatString = "n2"
        Me.colDealAmountEuro.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDealAmountEuro.FieldName = "Deal Amount Euro"
        Me.colDealAmountEuro.Name = "colDealAmountEuro"
        Me.colDealAmountEuro.OptionsColumn.AllowEdit = False
        Me.colDealAmountEuro.Visible = True
        Me.colDealAmountEuro.VisibleIndex = 3
        Me.colDealAmountEuro.Width = 151
        '
        'colHANDLINGFEE
        '
        Me.colHANDLINGFEE.AppearanceHeader.Options.UseFont = True
        Me.colHANDLINGFEE.FieldName = "HANDLINGFEE"
        Me.colHANDLINGFEE.Name = "colHANDLINGFEE"
        Me.colHANDLINGFEE.OptionsColumn.AllowEdit = False
        '
        'colORDERCUSTBR
        '
        Me.colORDERCUSTBR.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTBR.FieldName = "ORDERCUSTBR"
        Me.colORDERCUSTBR.Name = "colORDERCUSTBR"
        Me.colORDERCUSTBR.OptionsColumn.AllowEdit = False
        '
        'colORDERCUSTID
        '
        Me.colORDERCUSTID.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTID.Caption = "CUSTOMER ID"
        Me.colORDERCUSTID.CustomizationCaption = "CUSTOMER ID"
        Me.colORDERCUSTID.FieldName = "ORDERCUSTID"
        Me.colORDERCUSTID.Name = "colORDERCUSTID"
        Me.colORDERCUSTID.OptionsColumn.AllowEdit = False
        Me.colORDERCUSTID.Visible = True
        Me.colORDERCUSTID.VisibleIndex = 3
        Me.colORDERCUSTID.Width = 90
        '
        'colORDERCUSTNAME
        '
        Me.colORDERCUSTNAME.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTNAME.Caption = "ORDERING CUSTOMER NAME"
        Me.colORDERCUSTNAME.CustomizationCaption = "ORDERING CUSTOMER NAME"
        Me.colORDERCUSTNAME.FieldName = "ORDERCUSTNAME"
        Me.colORDERCUSTNAME.Name = "colORDERCUSTNAME"
        Me.colORDERCUSTNAME.OptionsColumn.AllowEdit = False
        Me.colORDERCUSTNAME.Visible = True
        Me.colORDERCUSTNAME.VisibleIndex = 2
        Me.colORDERCUSTNAME.Width = 324
        '
        'colORDERCUSTADD1
        '
        Me.colORDERCUSTADD1.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTADD1.FieldName = "ORDERCUSTADD1"
        Me.colORDERCUSTADD1.Name = "colORDERCUSTADD1"
        Me.colORDERCUSTADD1.OptionsColumn.AllowEdit = False
        '
        'colORDERCUSTADD2
        '
        Me.colORDERCUSTADD2.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTADD2.FieldName = "ORDERCUSTADD2"
        Me.colORDERCUSTADD2.Name = "colORDERCUSTADD2"
        Me.colORDERCUSTADD2.OptionsColumn.AllowEdit = False
        '
        'colHOLDFUNC
        '
        Me.colHOLDFUNC.AppearanceHeader.Options.UseFont = True
        Me.colHOLDFUNC.FieldName = "HOLDFUNC"
        Me.colHOLDFUNC.Name = "colHOLDFUNC"
        Me.colHOLDFUNC.OptionsColumn.AllowEdit = False
        '
        'colORDERCUSTADD3
        '
        Me.colORDERCUSTADD3.AppearanceHeader.Options.UseFont = True
        Me.colORDERCUSTADD3.FieldName = "ORDERCUSTADD3"
        Me.colORDERCUSTADD3.Name = "colORDERCUSTADD3"
        Me.colORDERCUSTADD3.OptionsColumn.AllowEdit = False
        '
        'colSWIFTINREF
        '
        Me.colSWIFTINREF.AppearanceHeader.Options.UseFont = True
        Me.colSWIFTINREF.FieldName = "SWIFTINREF"
        Me.colSWIFTINREF.Name = "colSWIFTINREF"
        Me.colSWIFTINREF.OptionsColumn.AllowEdit = False
        '
        'colIMPORTDATE
        '
        Me.colIMPORTDATE.AppearanceHeader.Options.UseFont = True
        Me.colIMPORTDATE.FieldName = "IMPORT DATE"
        Me.colIMPORTDATE.Name = "colIMPORTDATE"
        Me.colIMPORTDATE.OptionsColumn.AllowEdit = False
        '
        'colBEMERKUNGEN
        '
        Me.colBEMERKUNGEN.AppearanceHeader.Options.UseFont = True
        Me.colBEMERKUNGEN.FieldName = "BEMERKUNGEN"
        Me.colBEMERKUNGEN.Name = "colBEMERKUNGEN"
        Me.colBEMERKUNGEN.OptionsColumn.AllowEdit = False
        '
        'colIdBank
        '
        Me.colIdBank.AppearanceHeader.Options.UseFont = True
        Me.colIdBank.FieldName = "IdBank"
        Me.colIdBank.Name = "colIdBank"
        Me.colIdBank.OptionsColumn.AllowEdit = False
        Me.colIdBank.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Options.UseFont = True
        Me.GridColumn1.Caption = "BENEFICIARY"
        Me.GridColumn1.CustomizationCaption = "BENEFICIARY"
        Me.GridColumn1.FieldName = "GridColumn1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.UnboundExpression = "[BENEFCUSTNAME] +'  ' + [BENEFCUSTADR1] +'  ' + [BENEFCUSTADR2]"
        Me.GridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        Me.GridColumn1.Width = 339
        '
        'colACCWITHINSTNAME
        '
        Me.colACCWITHINSTNAME.Caption = "ACCOUNT WITH INSTITUTION (NAME)"
        Me.colACCWITHINSTNAME.FieldName = "ACWITHINSTNA"
        Me.colACCWITHINSTNAME.Name = "colACCWITHINSTNAME"
        Me.colACCWITHINSTNAME.OptionsColumn.AllowEdit = False
        Me.colACCWITHINSTNAME.Visible = True
        Me.colACCWITHINSTNAME.VisibleIndex = 5
        Me.colACCWITHINSTNAME.Width = 302
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
        Me.LayoutViewColumn4.ColumnEdit = Me.OdasImportProcedureRepositoryItemTextEdit
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
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1348, 610)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(204, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1328, 540)
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
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1328, 50)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Edit_BICDIR_Details_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1223, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(81, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(156, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1067, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Print_Export_Gridview_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(156, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
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
        'AntiMoneyAmounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1339, 720)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AntiMoneyAmounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Anti Money Laundering - Payments Sum as from  EUR 10.000,00 for each Customer (ti" & _
    "ll 08.12.2017)"
        CType(Me.AntiMoneyLaunderingDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDate_Till.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDate_Till.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDate_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDate_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AntiMoney_PaymentsAmounts_BasicView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OdasImportProcedureRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditBIC3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidRepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AntiMoneyLaunderingDataset As PS_TOOL_DX.AntiMoneyLaunderingDataset
    Friend WithEvents ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter As PS_TOOL_DX.AntiMoneyLaunderingDatasetTableAdapters.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.AntiMoneyLaunderingDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TransactionDate_Till As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TransactionDate_From As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LoadData_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Print_Export_Gridview_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Edit_BICDIR_Details_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AntiMoney_PaymentsAmounts_BasicView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents OdasImportProcedureRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ValidRepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
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
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEM00KEY0 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEM00KEY1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEM00KEY2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOURTRANREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINWARDOUTWARD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMETHOD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEIVERBRANCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEIVERID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEIVERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECEIVERSWIFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSENDERCORBKID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSENDERCORRNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSENDERCORRBR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSENDERCORRST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECRCORRID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECRCORRNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECRCORRBR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRECRCORRSWIFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACWITHINSTID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACWITHINSTNA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACWITHINSTBR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACWITHINSTST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFACNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFCUSTBR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFCUSTID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFCUSTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFCUSTADR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBENEFCUSTADR2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDETOFCHARGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSETOREINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTRANSACTIONDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDealAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXCHANGE_RATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDealAmountEuro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHANDLINGFEE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTBR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTADD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTADD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHOLDFUNC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDERCUSTADD3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSWIFTINREF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIMPORTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBEMERKUNGEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colACCWITHINSTNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
