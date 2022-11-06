<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SwiftMessagesAll
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
        Dim Label12 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim SwiftFileName_lbl As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim ReceivedDate_lbl As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim OSN_lbl As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim OSN_ReceivedDateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SwiftMessagesAll))
        Me.ALL_SWIFT_MESSAGESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LcDataset = New PS_TOOL_DX.LcDataset()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.AllSwiftMessages_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSwiftFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRef20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRef21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMessageType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMessageTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSenderBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSenderName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSenderBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReceivedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOSN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOSN_ReceivedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSwift_Message = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SwiftMessageText_RepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.SettlementStatusRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CurrencyRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.AmountRepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExportLCMaturitiesDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colDocsSendOn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colDocsSendOn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colApplicantsBank1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colApplicantsBank1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOurReference1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOurReference1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrency1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrency1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAmount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMaturity1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMaturity1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSettlementStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSettlementStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colNotes1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colNotes1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ChangeSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPageMarginsItem()
        Me.SetNormalSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetNormalSectionPageMarginsItem()
        Me.SetNarrowSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetNarrowSectionPageMarginsItem()
        Me.SetModerateSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetModerateSectionPageMarginsItem()
        Me.SetWideSectionPageMarginsItem1 = New DevExpress.XtraRichEdit.UI.SetWideSectionPageMarginsItem()
        Me.ShowPageMarginsSetupFormItem1 = New DevExpress.XtraRichEdit.UI.ShowPageMarginsSetupFormItem()
        Me.ChangeSectionPageOrientationItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPageOrientationItem()
        Me.SetPortraitPageOrientationItem1 = New DevExpress.XtraRichEdit.UI.SetPortraitPageOrientationItem()
        Me.SetLandscapePageOrientationItem1 = New DevExpress.XtraRichEdit.UI.SetLandscapePageOrientationItem()
        Me.ChangeSectionPaperKindItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionPaperKindItem()
        Me.ChangeSectionColumnsItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionColumnsItem()
        Me.SetSectionOneColumnItem1 = New DevExpress.XtraRichEdit.UI.SetSectionOneColumnItem()
        Me.SetSectionTwoColumnsItem1 = New DevExpress.XtraRichEdit.UI.SetSectionTwoColumnsItem()
        Me.SetSectionThreeColumnsItem1 = New DevExpress.XtraRichEdit.UI.SetSectionThreeColumnsItem()
        Me.ShowColumnsSetupFormItem1 = New DevExpress.XtraRichEdit.UI.ShowColumnsSetupFormItem()
        Me.InsertBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertBreakItem()
        Me.InsertPageBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertPageBreakItem()
        Me.InsertColumnBreakItem1 = New DevExpress.XtraRichEdit.UI.InsertColumnBreakItem()
        Me.InsertSectionBreakNextPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakNextPageItem()
        Me.InsertSectionBreakEvenPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakEvenPageItem()
        Me.InsertSectionBreakOddPageItem1 = New DevExpress.XtraRichEdit.UI.InsertSectionBreakOddPageItem()
        Me.ChangeSectionLineNumberingItem1 = New DevExpress.XtraRichEdit.UI.ChangeSectionLineNumberingItem()
        Me.SetSectionLineNumberingNoneItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingNoneItem()
        Me.SetSectionLineNumberingContinuousItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingContinuousItem()
        Me.SetSectionLineNumberingRestartNewPageItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewPageItem()
        Me.SetSectionLineNumberingRestartNewSectionItem1 = New DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewSectionItem()
        Me.ToggleParagraphSuppressLineNumbersItem1 = New DevExpress.XtraRichEdit.UI.ToggleParagraphSuppressLineNumbersItem()
        Me.ShowLineNumberingFormItem1 = New DevExpress.XtraRichEdit.UI.ShowLineNumberingFormItem()
        Me.ChangePageColorItem1 = New DevExpress.XtraRichEdit.UI.ChangePageColorItem()
        Me.ALL_SWIFT_MESSAGESTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.ALL_SWIFT_MESSAGESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.BASIC_DATAXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SwiftMessageFormated_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.OSN_ReceivedDateLabel1 = New System.Windows.Forms.Label()
        Me.AllMsg_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ID_lbl = New System.Windows.Forms.Label()
        Me.SwiftMsgPrint_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Ref21_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Ref20_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.SenderBranchName_textedit = New DevExpress.XtraEditors.TextEdit()
        Me.MsgType_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.SenderBicName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.SenderBIC_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.MsgTypeName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.OurReferenceSearch_GridLookUpEdit = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.EXPORT_LC_MT700_BDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OurReferenceSearch_GridLookUpEditView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLfdNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOurReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLC_Nr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MatchSwiftMessage_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SWIFT_ROW_TEXT_XtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SwiftText_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchMessages_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ViewEdit_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Print_Export_GridView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.DateFrom_DateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DateTill_DateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.RichEditBarController1 = New DevExpress.XtraRichEdit.UI.RichEditBarController(Me.components)
        Me.EXPORT_LC_MT700_BD_TableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_MT700_BD_TableAdapter()
        Label12 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        SwiftFileName_lbl = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        ReceivedDate_lbl = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        OSN_lbl = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        OSN_ReceivedDateLabel = New System.Windows.Forms.Label()
        CType(Me.ALL_SWIFT_MESSAGESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllSwiftMessages_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwiftMessageText_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.BASIC_DATAXtraTabPage.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.Ref21_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ref20_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SenderBranchName_textedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MsgType_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SenderBicName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SenderBIC_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MsgTypeName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.OurReferenceSearch_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXPORT_LC_MT700_BDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OurReferenceSearch_GridLookUpEditView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SWIFT_ROW_TEXT_XtraTabPage.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SwiftText_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTill_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTill_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label12.Location = New System.Drawing.Point(43, 133)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(50, 13)
        Label12.TabIndex = 11
        Label12.Text = "Sender:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label1.Location = New System.Drawing.Point(3, 34)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(92, 13)
        Label1.TabIndex = 4
        Label1.Text = "Received Date:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label3.Location = New System.Drawing.Point(3, 78)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(91, 13)
        Label3.TabIndex = 8
        Label3.Text = "Message Type:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label2.Location = New System.Drawing.Point(34, 12)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(60, 13)
        Label2.TabIndex = 0
        Label2.Text = "Swift File:"
        '
        'SwiftFileName_lbl
        '
        SwiftFileName_lbl.AutoSize = True
        SwiftFileName_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "SwiftFileName", True))
        SwiftFileName_lbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SwiftFileName_lbl.Location = New System.Drawing.Point(93, 12)
        SwiftFileName_lbl.Name = "SwiftFileName_lbl"
        SwiftFileName_lbl.Size = New System.Drawing.Size(92, 13)
        SwiftFileName_lbl.TabIndex = 1
        SwiftFileName_lbl.Text = "Swift File Name"
        '
        'ALL_SWIFT_MESSAGESBindingSource
        '
        Me.ALL_SWIFT_MESSAGESBindingSource.DataMember = "ALL_SWIFT_MESSAGES"
        Me.ALL_SWIFT_MESSAGESBindingSource.DataSource = Me.LcDataset
        '
        'LcDataset
        '
        Me.LcDataset.DataSetName = "LcDataset"
        Me.LcDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label4.Location = New System.Drawing.Point(9, 218)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(114, 13)
        Label4.TabIndex = 15
        Label4.Text = "Reference Field 20:"
        '
        'ReceivedDate_lbl
        '
        ReceivedDate_lbl.AutoSize = True
        ReceivedDate_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "ReceivedDate", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
        ReceivedDate_lbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ReceivedDate_lbl.Location = New System.Drawing.Point(93, 34)
        ReceivedDate_lbl.Name = "ReceivedDate_lbl"
        ReceivedDate_lbl.Size = New System.Drawing.Size(89, 13)
        ReceivedDate_lbl.TabIndex = 5
        ReceivedDate_lbl.Text = "Received Date"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label6.Location = New System.Drawing.Point(61, 54)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(32, 13)
        Label6.TabIndex = 6
        Label6.Text = "OSN:"
        '
        'OSN_lbl
        '
        OSN_lbl.AutoSize = True
        OSN_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "OSN", True))
        OSN_lbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        OSN_lbl.Location = New System.Drawing.Point(93, 54)
        OSN_lbl.Name = "OSN_lbl"
        OSN_lbl.Size = New System.Drawing.Size(29, 13)
        OSN_lbl.TabIndex = 7
        OSN_lbl.Text = "OSN"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label5.Location = New System.Drawing.Point(9, 242)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(114, 13)
        Label5.TabIndex = 17
        Label5.Text = "Reference Field 21:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Location = New System.Drawing.Point(6, 635)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(22, 13)
        IDLabel.TabIndex = 27
        IDLabel.Text = "ID:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(7, 38)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(236, 23)
        Label7.TabIndex = 67
        Label7.Text = "Matching LC Reference:"
        '
        'OSN_ReceivedDateLabel
        '
        OSN_ReceivedDateLabel.AutoSize = True
        OSN_ReceivedDateLabel.Location = New System.Drawing.Point(5, 25)
        OSN_ReceivedDateLabel.Name = "OSN_ReceivedDateLabel"
        OSN_ReceivedDateLabel.Size = New System.Drawing.Size(105, 13)
        OSN_ReceivedDateLabel.TabIndex = 49
        OSN_ReceivedDateLabel.Text = "OSN Received Date:"
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
        Me.ImageCollection1.Images.SetKeyName(6, "Paid.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "Pending.ico")
        Me.ImageCollection1.InsertGalleryImage("paste_16x16.png", "images/edit/paste_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "paste_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("grid_16x16.png", "images/grid/grid_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/grid_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "grid_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("find_16x16.png", "images/find/find_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/find_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "find_16x16.png")
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl2
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.ALL_SWIFT_MESSAGESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Hint = "Add new Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 8, True, False, "Duplicate Row", "DuplicateRow")})
        Me.GridControl2.Location = New System.Drawing.Point(12, 122)
        Me.GridControl2.MainView = Me.AllSwiftMessages_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SettlementStatusRepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit, Me.CurrencyRepositoryItemLookUpEdit1, Me.RepositoryItemDateEdit1, Me.SwiftMessageText_RepositoryItemMemoExEdit, Me.AmountRepositoryItemTextEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1452, 605)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AllSwiftMessages_BaseView, Me.ExportLCMaturitiesDetailView, Me.GridView2})
        '
        'AllSwiftMessages_BaseView
        '
        Me.AllSwiftMessages_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.AllSwiftMessages_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.AllSwiftMessages_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.AllSwiftMessages_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.AllSwiftMessages_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.AllSwiftMessages_BaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.AllSwiftMessages_BaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.AllSwiftMessages_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colSwiftFileName, Me.colRef20, Me.colRef21, Me.colMessageType, Me.colMessageTypeName, Me.colSenderBIC, Me.colSenderName, Me.colSenderBranch, Me.colReceivedDate, Me.colOSN, Me.colOSN_ReceivedDate, Me.colSwift_Message})
        Me.AllSwiftMessages_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.AllSwiftMessages_BaseView.GridControl = Me.GridControl2
        Me.AllSwiftMessages_BaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0R)})
        Me.AllSwiftMessages_BaseView.Name = "AllSwiftMessages_BaseView"
        Me.AllSwiftMessages_BaseView.NewItemRowText = "Add new EXPORT LC Maturity"
        Me.AllSwiftMessages_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AllSwiftMessages_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AllSwiftMessages_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.AllSwiftMessages_BaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.AllSwiftMessages_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.AllSwiftMessages_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.AllSwiftMessages_BaseView.OptionsFind.AlwaysVisible = True
        Me.AllSwiftMessages_BaseView.OptionsMenu.ShowFooterItem = True
        Me.AllSwiftMessages_BaseView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.AllSwiftMessages_BaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.AllSwiftMessages_BaseView.OptionsSelection.MultiSelect = True
        Me.AllSwiftMessages_BaseView.OptionsView.ColumnAutoWidth = False
        Me.AllSwiftMessages_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.AllSwiftMessages_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.AllSwiftMessages_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.AllSwiftMessages_BaseView.OptionsView.ShowFooter = True
        Me.AllSwiftMessages_BaseView.PaintStyleName = "Skin"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colSwiftFileName
        '
        Me.colSwiftFileName.FieldName = "SwiftFileName"
        Me.colSwiftFileName.Name = "colSwiftFileName"
        Me.colSwiftFileName.OptionsColumn.AllowEdit = False
        Me.colSwiftFileName.Visible = True
        Me.colSwiftFileName.VisibleIndex = 0
        Me.colSwiftFileName.Width = 98
        '
        'colRef20
        '
        Me.colRef20.Caption = "Reference Field 20"
        Me.colRef20.FieldName = "Ref20"
        Me.colRef20.Name = "colRef20"
        Me.colRef20.OptionsColumn.AllowEdit = False
        Me.colRef20.Visible = True
        Me.colRef20.VisibleIndex = 3
        Me.colRef20.Width = 132
        '
        'colRef21
        '
        Me.colRef21.Caption = "Reference Field 21"
        Me.colRef21.FieldName = "Ref21"
        Me.colRef21.Name = "colRef21"
        Me.colRef21.OptionsColumn.AllowEdit = False
        Me.colRef21.Visible = True
        Me.colRef21.VisibleIndex = 4
        Me.colRef21.Width = 127
        '
        'colMessageType
        '
        Me.colMessageType.FieldName = "MessageType"
        Me.colMessageType.Name = "colMessageType"
        Me.colMessageType.OptionsColumn.AllowEdit = False
        Me.colMessageType.Visible = True
        Me.colMessageType.VisibleIndex = 1
        Me.colMessageType.Width = 87
        '
        'colMessageTypeName
        '
        Me.colMessageTypeName.FieldName = "MessageTypeName"
        Me.colMessageTypeName.Name = "colMessageTypeName"
        Me.colMessageTypeName.OptionsColumn.AllowEdit = False
        Me.colMessageTypeName.Visible = True
        Me.colMessageTypeName.VisibleIndex = 2
        Me.colMessageTypeName.Width = 267
        '
        'colSenderBIC
        '
        Me.colSenderBIC.FieldName = "SenderBIC"
        Me.colSenderBIC.Name = "colSenderBIC"
        Me.colSenderBIC.OptionsColumn.AllowEdit = False
        Me.colSenderBIC.Visible = True
        Me.colSenderBIC.VisibleIndex = 5
        Me.colSenderBIC.Width = 93
        '
        'colSenderName
        '
        Me.colSenderName.FieldName = "SenderName"
        Me.colSenderName.Name = "colSenderName"
        Me.colSenderName.OptionsColumn.AllowEdit = False
        Me.colSenderName.Visible = True
        Me.colSenderName.VisibleIndex = 6
        Me.colSenderName.Width = 246
        '
        'colSenderBranch
        '
        Me.colSenderBranch.FieldName = "SenderBranch"
        Me.colSenderBranch.Name = "colSenderBranch"
        Me.colSenderBranch.OptionsColumn.AllowEdit = False
        Me.colSenderBranch.Visible = True
        Me.colSenderBranch.VisibleIndex = 7
        Me.colSenderBranch.Width = 151
        '
        'colReceivedDate
        '
        Me.colReceivedDate.FieldName = "ReceivedDate"
        Me.colReceivedDate.Name = "colReceivedDate"
        Me.colReceivedDate.OptionsColumn.AllowEdit = False
        Me.colReceivedDate.Visible = True
        Me.colReceivedDate.VisibleIndex = 8
        Me.colReceivedDate.Width = 121
        '
        'colOSN
        '
        Me.colOSN.FieldName = "OSN"
        Me.colOSN.Name = "colOSN"
        Me.colOSN.OptionsColumn.AllowEdit = False
        '
        'colOSN_ReceivedDate
        '
        Me.colOSN_ReceivedDate.FieldName = "OSN_ReceivedDate"
        Me.colOSN_ReceivedDate.Name = "colOSN_ReceivedDate"
        Me.colOSN_ReceivedDate.OptionsColumn.AllowEdit = False
        '
        'colSwift_Message
        '
        Me.colSwift_Message.Caption = "Swift Message Text"
        Me.colSwift_Message.ColumnEdit = Me.SwiftMessageText_RepositoryItemMemoExEdit
        Me.colSwift_Message.FieldName = "Swift_Message"
        Me.colSwift_Message.Name = "colSwift_Message"
        Me.colSwift_Message.OptionsColumn.ReadOnly = True
        Me.colSwift_Message.Visible = True
        Me.colSwift_Message.VisibleIndex = 9
        Me.colSwift_Message.Width = 159
        '
        'SwiftMessageText_RepositoryItemMemoExEdit
        '
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Appearance.Options.UseBackColor = True
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Appearance.Options.UseForeColor = True
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AppearanceFocused.Options.UseBackColor = True
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AppearanceFocused.Options.UseForeColor = True
        Me.SwiftMessageText_RepositoryItemMemoExEdit.AutoHeight = False
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SwiftMessageText_RepositoryItemMemoExEdit.Name = "SwiftMessageText_RepositoryItemMemoExEdit"
        Me.SwiftMessageText_RepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 500)
        Me.SwiftMessageText_RepositoryItemMemoExEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'SettlementStatusRepositoryItemImageComboBox1
        '
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AutoHeight = False
        Me.SettlementStatusRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PENDING", "PENDING", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PAID", "PAID", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNPAID", "UNPAID", 3)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Name = "SettlementStatusRepositoryItemImageComboBox1"
        Me.SettlementStatusRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'BICCODERepositoryItemTextEdit
        '
        Me.BICCODERepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BICCODERepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AutoHeight = False
        Me.BICCODERepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BICCODERepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BICCODERepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.BICCODERepositoryItemTextEdit.Mask.EditMask = "([A-Z]){6}([0-9A-Z]){2}([0-9A-Z]{3})"
        Me.BICCODERepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.BICCODERepositoryItemTextEdit.Name = "BICCODERepositoryItemTextEdit"
        '
        'CurrencyRepositoryItemLookUpEdit1
        '
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CurrencyRepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.CurrencyRepositoryItemLookUpEdit1.Name = "CurrencyRepositoryItemLookUpEdit1"
        Me.CurrencyRepositoryItemLookUpEdit1.NullText = ""
        Me.CurrencyRepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.ShowWeekNumbers = True
        '
        'AmountRepositoryItemTextEdit2
        '
        Me.AmountRepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit2.AutoHeight = False
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit2.Name = "AmountRepositoryItemTextEdit2"
        '
        'ExportLCMaturitiesDetailView
        '
        Me.ExportLCMaturitiesDetailView.CardMinSize = New System.Drawing.Size(741, 448)
        Me.ExportLCMaturitiesDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colDocsSendOn1, Me.colApplicantsBank1, Me.colOurReference1, Me.colCurrency1, Me.colAmount1, Me.colMaturity1, Me.colSettlementStatus1, Me.colNotes1})
        Me.ExportLCMaturitiesDetailView.GridControl = Me.GridControl2
        Me.ExportLCMaturitiesDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.ExportLCMaturitiesDetailView.Name = "ExportLCMaturitiesDetailView"
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowFilter = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowSort = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterEditor = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.ExportLCMaturitiesDetailView.OptionsFind.AllowFindPanel = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsView.ShowHeaderPanel = False
        Me.ExportLCMaturitiesDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = 20
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(730, 180)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colDocsSendOn1
        '
        Me.colDocsSendOn1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDocsSendOn1.FieldName = "DocsSendOn"
        Me.colDocsSendOn1.LayoutViewField = Me.layoutViewField_colDocsSendOn1
        Me.colDocsSendOn1.Name = "colDocsSendOn1"
        '
        'layoutViewField_colDocsSendOn1
        '
        Me.layoutViewField_colDocsSendOn1.EditorPreferredWidth = 90
        Me.layoutViewField_colDocsSendOn1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colDocsSendOn1.Name = "layoutViewField_colDocsSendOn1"
        Me.layoutViewField_colDocsSendOn1.Size = New System.Drawing.Size(189, 20)
        Me.layoutViewField_colDocsSendOn1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colApplicantsBank1
        '
        Me.colApplicantsBank1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colApplicantsBank1.FieldName = "ApplicantsBank"
        Me.colApplicantsBank1.LayoutViewField = Me.layoutViewField_colApplicantsBank1
        Me.colApplicantsBank1.Name = "colApplicantsBank1"
        '
        'layoutViewField_colApplicantsBank1
        '
        Me.layoutViewField_colApplicantsBank1.EditorPreferredWidth = 622
        Me.layoutViewField_colApplicantsBank1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colApplicantsBank1.Name = "layoutViewField_colApplicantsBank1"
        Me.layoutViewField_colApplicantsBank1.Size = New System.Drawing.Size(721, 20)
        Me.layoutViewField_colApplicantsBank1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colOurReference1
        '
        Me.colOurReference1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colOurReference1.FieldName = "OurReference"
        Me.colOurReference1.LayoutViewField = Me.layoutViewField_colOurReference1
        Me.colOurReference1.Name = "colOurReference1"
        '
        'layoutViewField_colOurReference1
        '
        Me.layoutViewField_colOurReference1.EditorPreferredWidth = 91
        Me.layoutViewField_colOurReference1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colOurReference1.Name = "layoutViewField_colOurReference1"
        Me.layoutViewField_colOurReference1.Size = New System.Drawing.Size(190, 20)
        Me.layoutViewField_colOurReference1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colCurrency1
        '
        Me.colCurrency1.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit1
        Me.colCurrency1.FieldName = "Currency"
        Me.colCurrency1.LayoutViewField = Me.layoutViewField_colCurrency1
        Me.colCurrency1.Name = "colCurrency1"
        '
        'layoutViewField_colCurrency1
        '
        Me.layoutViewField_colCurrency1.EditorPreferredWidth = 40
        Me.layoutViewField_colCurrency1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colCurrency1.Name = "layoutViewField_colCurrency1"
        Me.layoutViewField_colCurrency1.Size = New System.Drawing.Size(139, 20)
        Me.layoutViewField_colCurrency1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colAmount1
        '
        Me.colAmount1.ColumnEdit = Me.AmountRepositoryItemTextEdit2
        Me.colAmount1.FieldName = "Amount"
        Me.colAmount1.LayoutViewField = Me.layoutViewField_colAmount1
        Me.colAmount1.Name = "colAmount1"
        '
        'layoutViewField_colAmount1
        '
        Me.layoutViewField_colAmount1.EditorPreferredWidth = 123
        Me.layoutViewField_colAmount1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colAmount1.Name = "layoutViewField_colAmount1"
        Me.layoutViewField_colAmount1.Size = New System.Drawing.Size(222, 20)
        Me.layoutViewField_colAmount1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colMaturity1
        '
        Me.colMaturity1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colMaturity1.FieldName = "Maturity"
        Me.colMaturity1.LayoutViewField = Me.layoutViewField_colMaturity1
        Me.colMaturity1.Name = "colMaturity1"
        '
        'layoutViewField_colMaturity1
        '
        Me.layoutViewField_colMaturity1.EditorPreferredWidth = 94
        Me.layoutViewField_colMaturity1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colMaturity1.Name = "layoutViewField_colMaturity1"
        Me.layoutViewField_colMaturity1.Size = New System.Drawing.Size(193, 20)
        Me.layoutViewField_colMaturity1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colSettlementStatus1
        '
        Me.colSettlementStatus1.ColumnEdit = Me.SettlementStatusRepositoryItemImageComboBox1
        Me.colSettlementStatus1.FieldName = "SettlementStatus"
        Me.colSettlementStatus1.LayoutViewField = Me.layoutViewField_colSettlementStatus1
        Me.colSettlementStatus1.Name = "colSettlementStatus1"
        '
        'layoutViewField_colSettlementStatus1
        '
        Me.layoutViewField_colSettlementStatus1.EditorPreferredWidth = 62
        Me.layoutViewField_colSettlementStatus1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colSettlementStatus1.Name = "layoutViewField_colSettlementStatus1"
        Me.layoutViewField_colSettlementStatus1.Size = New System.Drawing.Size(161, 20)
        Me.layoutViewField_colSettlementStatus1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colNotes1
        '
        Me.colNotes1.ColumnEdit = Me.SwiftMessageText_RepositoryItemMemoExEdit
        Me.colNotes1.FieldName = "Notes"
        Me.colNotes1.LayoutViewField = Me.layoutViewField_colNotes1
        Me.colNotes1.Name = "colNotes1"
        '
        'layoutViewField_colNotes1
        '
        Me.layoutViewField_colNotes1.EditorPreferredWidth = 622
        Me.layoutViewField_colNotes1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colNotes1.Name = "layoutViewField_colNotes1"
        Me.layoutViewField_colNotes1.Size = New System.Drawing.Size(721, 269)
        Me.layoutViewField_colNotes1.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colDocsSendOn1, Me.layoutViewField_colApplicantsBank1, Me.layoutViewField_colOurReference1, Me.layoutViewField_colCurrency1, Me.layoutViewField_colAmount1, Me.layoutViewField_colMaturity1, Me.layoutViewField_colSettlementStatus1, Me.layoutViewField_colNotes1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ChangeSectionPageMarginsItem1, Me.SetNormalSectionPageMarginsItem1, Me.SetNarrowSectionPageMarginsItem1, Me.SetModerateSectionPageMarginsItem1, Me.SetWideSectionPageMarginsItem1, Me.ShowPageMarginsSetupFormItem1, Me.ChangeSectionPageOrientationItem1, Me.SetPortraitPageOrientationItem1, Me.SetLandscapePageOrientationItem1, Me.ChangeSectionPaperKindItem1, Me.ChangeSectionColumnsItem1, Me.SetSectionOneColumnItem1, Me.SetSectionTwoColumnsItem1, Me.SetSectionThreeColumnsItem1, Me.ShowColumnsSetupFormItem1, Me.InsertBreakItem1, Me.InsertPageBreakItem1, Me.InsertColumnBreakItem1, Me.InsertSectionBreakNextPageItem1, Me.InsertSectionBreakEvenPageItem1, Me.InsertSectionBreakOddPageItem1, Me.ChangeSectionLineNumberingItem1, Me.SetSectionLineNumberingNoneItem1, Me.SetSectionLineNumberingContinuousItem1, Me.SetSectionLineNumberingRestartNewPageItem1, Me.SetSectionLineNumberingRestartNewSectionItem1, Me.ToggleParagraphSuppressLineNumbersItem1, Me.ShowLineNumberingFormItem1, Me.ChangePageColorItem1})
        Me.BarManager1.MaxItemId = 29
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1476, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 739)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1476, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 739)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1476, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 739)
        '
        'ChangeSectionPageMarginsItem1
        '
        Me.ChangeSectionPageMarginsItem1.Caption = "Margins"
        Me.ChangeSectionPageMarginsItem1.Enabled = False
        Me.ChangeSectionPageMarginsItem1.Id = 0
        Me.ChangeSectionPageMarginsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetNormalSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetNarrowSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetModerateSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetWideSectionPageMarginsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowPageMarginsSetupFormItem1)})
        Me.ChangeSectionPageMarginsItem1.Name = "ChangeSectionPageMarginsItem1"
        '
        'SetNormalSectionPageMarginsItem1
        '
        Me.SetNormalSectionPageMarginsItem1.Caption = "Normal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Top:" & Global.Microsoft.VisualBasic.ChrW(9) & "     0,79""" & Global.Microsoft.VisualBasic.ChrW(9) & "Bottom:" & Global.Microsoft.VisualBasic.ChrW(9) & "     0,79""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left:" & Global.Microsoft.VisualBasic.ChrW(9) & "     1,18""" & Global.Microsoft.VisualBasic.ChrW(9) & "Right:" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "     0,59"""
        Me.SetNormalSectionPageMarginsItem1.Enabled = False
        Me.SetNormalSectionPageMarginsItem1.Id = 1
        Me.SetNormalSectionPageMarginsItem1.Name = "SetNormalSectionPageMarginsItem1"
        '
        'SetNarrowSectionPageMarginsItem1
        '
        Me.SetNarrowSectionPageMarginsItem1.Caption = "Narrow" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Top:" & Global.Microsoft.VisualBasic.ChrW(9) & "      0,5""" & Global.Microsoft.VisualBasic.ChrW(9) & "Bottom:" & Global.Microsoft.VisualBasic.ChrW(9) & "      0,5""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left:" & Global.Microsoft.VisualBasic.ChrW(9) & "      0,5""" & Global.Microsoft.VisualBasic.ChrW(9) & "Right:" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "      0,5"""
        Me.SetNarrowSectionPageMarginsItem1.Enabled = False
        Me.SetNarrowSectionPageMarginsItem1.Id = 2
        Me.SetNarrowSectionPageMarginsItem1.Name = "SetNarrowSectionPageMarginsItem1"
        '
        'SetModerateSectionPageMarginsItem1
        '
        Me.SetModerateSectionPageMarginsItem1.Caption = "Moderate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Top:" & Global.Microsoft.VisualBasic.ChrW(9) & "        1""" & Global.Microsoft.VisualBasic.ChrW(9) & "Bottom:" & Global.Microsoft.VisualBasic.ChrW(9) & "        1""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left:" & Global.Microsoft.VisualBasic.ChrW(9) & "     0,75""" & Global.Microsoft.VisualBasic.ChrW(9) & "Right:" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "     0,75""" &
    ""
        Me.SetModerateSectionPageMarginsItem1.Enabled = False
        Me.SetModerateSectionPageMarginsItem1.Id = 3
        Me.SetModerateSectionPageMarginsItem1.Name = "SetModerateSectionPageMarginsItem1"
        '
        'SetWideSectionPageMarginsItem1
        '
        Me.SetWideSectionPageMarginsItem1.Caption = "Wide" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Top:" & Global.Microsoft.VisualBasic.ChrW(9) & "        1""" & Global.Microsoft.VisualBasic.ChrW(9) & "Bottom:" & Global.Microsoft.VisualBasic.ChrW(9) & "        1""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left:" & Global.Microsoft.VisualBasic.ChrW(9) & "        2""" & Global.Microsoft.VisualBasic.ChrW(9) & "Right:" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "        2"""
        Me.SetWideSectionPageMarginsItem1.Enabled = False
        Me.SetWideSectionPageMarginsItem1.Id = 4
        Me.SetWideSectionPageMarginsItem1.Name = "SetWideSectionPageMarginsItem1"
        '
        'ShowPageMarginsSetupFormItem1
        '
        Me.ShowPageMarginsSetupFormItem1.Caption = "Custom M&argins..."
        Me.ShowPageMarginsSetupFormItem1.Enabled = False
        Me.ShowPageMarginsSetupFormItem1.Id = 5
        Me.ShowPageMarginsSetupFormItem1.Name = "ShowPageMarginsSetupFormItem1"
        '
        'ChangeSectionPageOrientationItem1
        '
        Me.ChangeSectionPageOrientationItem1.Caption = "Orientation"
        Me.ChangeSectionPageOrientationItem1.Enabled = False
        Me.ChangeSectionPageOrientationItem1.Id = 6
        Me.ChangeSectionPageOrientationItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetPortraitPageOrientationItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetLandscapePageOrientationItem1)})
        Me.ChangeSectionPageOrientationItem1.Name = "ChangeSectionPageOrientationItem1"
        '
        'SetPortraitPageOrientationItem1
        '
        Me.SetPortraitPageOrientationItem1.Caption = "Portrait"
        Me.SetPortraitPageOrientationItem1.Enabled = False
        Me.SetPortraitPageOrientationItem1.Id = 7
        Me.SetPortraitPageOrientationItem1.Name = "SetPortraitPageOrientationItem1"
        '
        'SetLandscapePageOrientationItem1
        '
        Me.SetLandscapePageOrientationItem1.Caption = "Landscape"
        Me.SetLandscapePageOrientationItem1.Enabled = False
        Me.SetLandscapePageOrientationItem1.Id = 8
        Me.SetLandscapePageOrientationItem1.Name = "SetLandscapePageOrientationItem1"
        '
        'ChangeSectionPaperKindItem1
        '
        Me.ChangeSectionPaperKindItem1.Caption = "Size"
        Me.ChangeSectionPaperKindItem1.Enabled = False
        Me.ChangeSectionPaperKindItem1.Id = 9
        Me.ChangeSectionPaperKindItem1.Name = "ChangeSectionPaperKindItem1"
        '
        'ChangeSectionColumnsItem1
        '
        Me.ChangeSectionColumnsItem1.Caption = "Columns"
        Me.ChangeSectionColumnsItem1.Enabled = False
        Me.ChangeSectionColumnsItem1.Id = 10
        Me.ChangeSectionColumnsItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionOneColumnItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionTwoColumnsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionThreeColumnsItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowColumnsSetupFormItem1)})
        Me.ChangeSectionColumnsItem1.Name = "ChangeSectionColumnsItem1"
        '
        'SetSectionOneColumnItem1
        '
        Me.SetSectionOneColumnItem1.Caption = "One"
        Me.SetSectionOneColumnItem1.Enabled = False
        Me.SetSectionOneColumnItem1.Id = 11
        Me.SetSectionOneColumnItem1.Name = "SetSectionOneColumnItem1"
        '
        'SetSectionTwoColumnsItem1
        '
        Me.SetSectionTwoColumnsItem1.Caption = "Two"
        Me.SetSectionTwoColumnsItem1.Enabled = False
        Me.SetSectionTwoColumnsItem1.Id = 12
        Me.SetSectionTwoColumnsItem1.Name = "SetSectionTwoColumnsItem1"
        '
        'SetSectionThreeColumnsItem1
        '
        Me.SetSectionThreeColumnsItem1.Caption = "Three"
        Me.SetSectionThreeColumnsItem1.Enabled = False
        Me.SetSectionThreeColumnsItem1.Id = 13
        Me.SetSectionThreeColumnsItem1.Name = "SetSectionThreeColumnsItem1"
        '
        'ShowColumnsSetupFormItem1
        '
        Me.ShowColumnsSetupFormItem1.Caption = "More &Columns..."
        Me.ShowColumnsSetupFormItem1.Enabled = False
        Me.ShowColumnsSetupFormItem1.Id = 14
        Me.ShowColumnsSetupFormItem1.Name = "ShowColumnsSetupFormItem1"
        '
        'InsertBreakItem1
        '
        Me.InsertBreakItem1.Caption = "Breaks"
        Me.InsertBreakItem1.Enabled = False
        Me.InsertBreakItem1.Id = 15
        Me.InsertBreakItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InsertPageBreakItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertColumnBreakItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakNextPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakEvenPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.InsertSectionBreakOddPageItem1)})
        Me.InsertBreakItem1.Name = "InsertBreakItem1"
        '
        'InsertPageBreakItem1
        '
        Me.InsertPageBreakItem1.Caption = "Page"
        Me.InsertPageBreakItem1.Enabled = False
        Me.InsertPageBreakItem1.Id = 16
        Me.InsertPageBreakItem1.Name = "InsertPageBreakItem1"
        '
        'InsertColumnBreakItem1
        '
        Me.InsertColumnBreakItem1.Caption = "Column"
        Me.InsertColumnBreakItem1.Enabled = False
        Me.InsertColumnBreakItem1.Id = 17
        Me.InsertColumnBreakItem1.Name = "InsertColumnBreakItem1"
        '
        'InsertSectionBreakNextPageItem1
        '
        Me.InsertSectionBreakNextPageItem1.Caption = "Section (Next Page)"
        Me.InsertSectionBreakNextPageItem1.Enabled = False
        Me.InsertSectionBreakNextPageItem1.Id = 18
        Me.InsertSectionBreakNextPageItem1.Name = "InsertSectionBreakNextPageItem1"
        '
        'InsertSectionBreakEvenPageItem1
        '
        Me.InsertSectionBreakEvenPageItem1.Caption = "Section (Even Page)"
        Me.InsertSectionBreakEvenPageItem1.Enabled = False
        Me.InsertSectionBreakEvenPageItem1.Id = 19
        Me.InsertSectionBreakEvenPageItem1.Name = "InsertSectionBreakEvenPageItem1"
        '
        'InsertSectionBreakOddPageItem1
        '
        Me.InsertSectionBreakOddPageItem1.Caption = "Section (Odd Page)"
        Me.InsertSectionBreakOddPageItem1.Enabled = False
        Me.InsertSectionBreakOddPageItem1.Id = 20
        Me.InsertSectionBreakOddPageItem1.Name = "InsertSectionBreakOddPageItem1"
        '
        'ChangeSectionLineNumberingItem1
        '
        Me.ChangeSectionLineNumberingItem1.Caption = "Line Numbers"
        Me.ChangeSectionLineNumberingItem1.Enabled = False
        Me.ChangeSectionLineNumberingItem1.Id = 21
        Me.ChangeSectionLineNumberingItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingNoneItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingContinuousItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingRestartNewPageItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.SetSectionLineNumberingRestartNewSectionItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ToggleParagraphSuppressLineNumbersItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ShowLineNumberingFormItem1)})
        Me.ChangeSectionLineNumberingItem1.Name = "ChangeSectionLineNumberingItem1"
        '
        'SetSectionLineNumberingNoneItem1
        '
        Me.SetSectionLineNumberingNoneItem1.Caption = "None"
        Me.SetSectionLineNumberingNoneItem1.Enabled = False
        Me.SetSectionLineNumberingNoneItem1.Id = 22
        Me.SetSectionLineNumberingNoneItem1.Name = "SetSectionLineNumberingNoneItem1"
        '
        'SetSectionLineNumberingContinuousItem1
        '
        Me.SetSectionLineNumberingContinuousItem1.Caption = "Continuous"
        Me.SetSectionLineNumberingContinuousItem1.Enabled = False
        Me.SetSectionLineNumberingContinuousItem1.Id = 23
        Me.SetSectionLineNumberingContinuousItem1.Name = "SetSectionLineNumberingContinuousItem1"
        '
        'SetSectionLineNumberingRestartNewPageItem1
        '
        Me.SetSectionLineNumberingRestartNewPageItem1.Caption = "Restart Each Page"
        Me.SetSectionLineNumberingRestartNewPageItem1.Enabled = False
        Me.SetSectionLineNumberingRestartNewPageItem1.Id = 24
        Me.SetSectionLineNumberingRestartNewPageItem1.Name = "SetSectionLineNumberingRestartNewPageItem1"
        '
        'SetSectionLineNumberingRestartNewSectionItem1
        '
        Me.SetSectionLineNumberingRestartNewSectionItem1.Caption = "Restart Each Section"
        Me.SetSectionLineNumberingRestartNewSectionItem1.Enabled = False
        Me.SetSectionLineNumberingRestartNewSectionItem1.Id = 25
        Me.SetSectionLineNumberingRestartNewSectionItem1.Name = "SetSectionLineNumberingRestartNewSectionItem1"
        '
        'ToggleParagraphSuppressLineNumbersItem1
        '
        Me.ToggleParagraphSuppressLineNumbersItem1.Caption = "Suppress for Current Paragraph"
        Me.ToggleParagraphSuppressLineNumbersItem1.Enabled = False
        Me.ToggleParagraphSuppressLineNumbersItem1.Id = 26
        Me.ToggleParagraphSuppressLineNumbersItem1.Name = "ToggleParagraphSuppressLineNumbersItem1"
        '
        'ShowLineNumberingFormItem1
        '
        Me.ShowLineNumberingFormItem1.Caption = "&Line Numbering Options..."
        Me.ShowLineNumberingFormItem1.Enabled = False
        Me.ShowLineNumberingFormItem1.Id = 27
        Me.ShowLineNumberingFormItem1.Name = "ShowLineNumberingFormItem1"
        '
        'ChangePageColorItem1
        '
        Me.ChangePageColorItem1.Caption = "Page Color"
        Me.ChangePageColorItem1.Enabled = False
        Me.ChangePageColorItem1.Id = 28
        Me.ChangePageColorItem1.Name = "ChangePageColorItem1"
        '
        'ALL_SWIFT_MESSAGESTableAdapter
        '
        Me.ALL_SWIFT_MESSAGESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_SWIFT_MESSAGESTableAdapter = Me.ALL_SWIFT_MESSAGESTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERSTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_BD_TableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_RMTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl2.Location = New System.Drawing.Point(9, 24)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.BASIC_DATAXtraTabPage
        Me.XtraTabControl2.Size = New System.Drawing.Size(1455, 691)
        Me.XtraTabControl2.TabIndex = 17
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.BASIC_DATAXtraTabPage, Me.SWIFT_ROW_TEXT_XtraTabPage})
        '
        'BASIC_DATAXtraTabPage
        '
        Me.BASIC_DATAXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BASIC_DATAXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.BASIC_DATAXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.BASIC_DATAXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.BASIC_DATAXtraTabPage.AutoScroll = True
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.GroupControl2)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.AllMsg_btn)
        Me.BASIC_DATAXtraTabPage.Controls.Add(IDLabel)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.ID_lbl)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.SwiftMsgPrint_btn)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.Ref21_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label5)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.Ref20_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(OSN_lbl)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label6)
        Me.BASIC_DATAXtraTabPage.Controls.Add(ReceivedDate_lbl)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label4)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.SenderBranchName_textedit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(SwiftFileName_lbl)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label2)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.MsgType_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.SenderBicName_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.SenderBIC_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label12)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.MsgTypeName_TextEdit)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label1)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Label3)
        Me.BASIC_DATAXtraTabPage.Controls.Add(Me.GroupControl3)
        Me.BASIC_DATAXtraTabPage.Name = "BASIC_DATAXtraTabPage"
        Me.BASIC_DATAXtraTabPage.Size = New System.Drawing.Size(1449, 663)
        Me.BASIC_DATAXtraTabPage.Text = "SWIFT MESSAGE DETAILS"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.SwiftMessageFormated_RichTextBox)
        Me.GroupControl2.Controls.Add(Me.OSN_ReceivedDateLabel1)
        Me.GroupControl2.Controls.Add(OSN_ReceivedDateLabel)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupControl2.Location = New System.Drawing.Point(679, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(770, 663)
        Me.GroupControl2.TabIndex = 29
        Me.GroupControl2.Text = "Swift Message Text Block"
        '
        'SwiftMessageFormated_RichTextBox
        '
        Me.SwiftMessageFormated_RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SwiftMessageFormated_RichTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "Swift_Message_Formated", True))
        Me.SwiftMessageFormated_RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SwiftMessageFormated_RichTextBox.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwiftMessageFormated_RichTextBox.ForeColor = System.Drawing.Color.White
        Me.SwiftMessageFormated_RichTextBox.Location = New System.Drawing.Point(2, 20)
        Me.SwiftMessageFormated_RichTextBox.Name = "SwiftMessageFormated_RichTextBox"
        Me.SwiftMessageFormated_RichTextBox.ReadOnly = True
        Me.SwiftMessageFormated_RichTextBox.Size = New System.Drawing.Size(766, 641)
        Me.SwiftMessageFormated_RichTextBox.TabIndex = 0
        Me.SwiftMessageFormated_RichTextBox.Text = ""
        '
        'OSN_ReceivedDateLabel1
        '
        Me.OSN_ReceivedDateLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "OSN_ReceivedDate", True))
        Me.OSN_ReceivedDateLabel1.Location = New System.Drawing.Point(116, 25)
        Me.OSN_ReceivedDateLabel1.Name = "OSN_ReceivedDateLabel1"
        Me.OSN_ReceivedDateLabel1.Size = New System.Drawing.Size(100, 23)
        Me.OSN_ReceivedDateLabel1.TabIndex = 50
        Me.OSN_ReceivedDateLabel1.Text = "Label8"
        '
        'AllMsg_btn
        '
        Me.AllMsg_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AllMsg_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AllMsg_btn.ImageOptions.ImageIndex = 12
        Me.AllMsg_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.AllMsg_btn.Location = New System.Drawing.Point(419, 12)
        Me.AllMsg_btn.Name = "AllMsg_btn"
        Me.AllMsg_btn.Size = New System.Drawing.Size(118, 22)
        Me.AllMsg_btn.TabIndex = 2
        Me.AllMsg_btn.Text = "Show all Messages"
        '
        'ID_lbl
        '
        Me.ID_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ID_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "ID", True))
        Me.ID_lbl.Location = New System.Drawing.Point(34, 635)
        Me.ID_lbl.Name = "ID_lbl"
        Me.ID_lbl.Size = New System.Drawing.Size(627, 23)
        Me.ID_lbl.TabIndex = 28
        Me.ID_lbl.Text = "Label7"
        '
        'SwiftMsgPrint_btn
        '
        Me.SwiftMsgPrint_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SwiftMsgPrint_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SwiftMsgPrint_btn.ImageOptions.ImageIndex = 2
        Me.SwiftMsgPrint_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SwiftMsgPrint_btn.Location = New System.Drawing.Point(543, 12)
        Me.SwiftMsgPrint_btn.Name = "SwiftMsgPrint_btn"
        Me.SwiftMsgPrint_btn.Size = New System.Drawing.Size(118, 22)
        Me.SwiftMsgPrint_btn.TabIndex = 3
        Me.SwiftMsgPrint_btn.Text = "Print Message"
        '
        'Ref21_TextEdit
        '
        Me.Ref21_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "Ref21", True))
        Me.Ref21_TextEdit.Location = New System.Drawing.Point(129, 241)
        Me.Ref21_TextEdit.Name = "Ref21_TextEdit"
        Me.Ref21_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Ref21_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.Ref21_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Ref21_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Ref21_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Ref21_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Ref21_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Ref21_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Ref21_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Ref21_TextEdit.Properties.ReadOnly = True
        Me.Ref21_TextEdit.Size = New System.Drawing.Size(259, 22)
        Me.Ref21_TextEdit.TabIndex = 18
        '
        'Ref20_TextEdit
        '
        Me.Ref20_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "Ref20", True))
        Me.Ref20_TextEdit.Location = New System.Drawing.Point(129, 213)
        Me.Ref20_TextEdit.Name = "Ref20_TextEdit"
        Me.Ref20_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Ref20_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.Ref20_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Ref20_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Ref20_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Ref20_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Ref20_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Ref20_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Ref20_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Ref20_TextEdit.Properties.ReadOnly = True
        Me.Ref20_TextEdit.Size = New System.Drawing.Size(259, 22)
        Me.Ref20_TextEdit.TabIndex = 16
        '
        'SenderBranchName_textedit
        '
        Me.SenderBranchName_textedit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "SenderBranch", True))
        Me.SenderBranchName_textedit.Location = New System.Drawing.Point(96, 177)
        Me.SenderBranchName_textedit.Name = "SenderBranchName_textedit"
        Me.SenderBranchName_textedit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SenderBranchName_textedit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.SenderBranchName_textedit.Properties.Appearance.Options.UseFont = True
        Me.SenderBranchName_textedit.Properties.Appearance.Options.UseForeColor = True
        Me.SenderBranchName_textedit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SenderBranchName_textedit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SenderBranchName_textedit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SenderBranchName_textedit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.SenderBranchName_textedit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SenderBranchName_textedit.Properties.ReadOnly = True
        Me.SenderBranchName_textedit.Size = New System.Drawing.Size(532, 22)
        Me.SenderBranchName_textedit.TabIndex = 14
        '
        'MsgType_TextEdit
        '
        Me.MsgType_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "MessageType", True))
        Me.MsgType_TextEdit.Location = New System.Drawing.Point(96, 74)
        Me.MsgType_TextEdit.Name = "MsgType_TextEdit"
        Me.MsgType_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MsgType_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.MsgType_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.MsgType_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.MsgType_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MsgType_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MsgType_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MsgType_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MsgType_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MsgType_TextEdit.Properties.ReadOnly = True
        Me.MsgType_TextEdit.Size = New System.Drawing.Size(74, 22)
        Me.MsgType_TextEdit.TabIndex = 9
        '
        'SenderBicName_TextEdit
        '
        Me.SenderBicName_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "SenderName", True))
        Me.SenderBicName_TextEdit.Location = New System.Drawing.Point(96, 153)
        Me.SenderBicName_TextEdit.Name = "SenderBicName_TextEdit"
        Me.SenderBicName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SenderBicName_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.SenderBicName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.SenderBicName_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.SenderBicName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SenderBicName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SenderBicName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SenderBicName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.SenderBicName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SenderBicName_TextEdit.Properties.ReadOnly = True
        Me.SenderBicName_TextEdit.Size = New System.Drawing.Size(532, 22)
        Me.SenderBicName_TextEdit.TabIndex = 13
        '
        'SenderBIC_TextEdit
        '
        Me.SenderBIC_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "SenderBIC", True))
        Me.SenderBIC_TextEdit.Location = New System.Drawing.Point(96, 130)
        Me.SenderBIC_TextEdit.Name = "SenderBIC_TextEdit"
        Me.SenderBIC_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SenderBIC_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.SenderBIC_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.SenderBIC_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.SenderBIC_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SenderBIC_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SenderBIC_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SenderBIC_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.SenderBIC_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SenderBIC_TextEdit.Properties.ReadOnly = True
        Me.SenderBIC_TextEdit.Size = New System.Drawing.Size(130, 22)
        Me.SenderBIC_TextEdit.TabIndex = 12
        '
        'MsgTypeName_TextEdit
        '
        Me.MsgTypeName_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "MessageTypeName", True))
        Me.MsgTypeName_TextEdit.Location = New System.Drawing.Point(96, 97)
        Me.MsgTypeName_TextEdit.Name = "MsgTypeName_TextEdit"
        Me.MsgTypeName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MsgTypeName_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.MsgTypeName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.MsgTypeName_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.MsgTypeName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MsgTypeName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MsgTypeName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MsgTypeName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MsgTypeName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MsgTypeName_TextEdit.Properties.ReadOnly = True
        Me.MsgTypeName_TextEdit.Size = New System.Drawing.Size(532, 22)
        Me.MsgTypeName_TextEdit.TabIndex = 10
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.OurReferenceSearch_GridLookUpEdit)
        Me.GroupControl3.Controls.Add(Label7)
        Me.GroupControl3.Controls.Add(Me.MatchSwiftMessage_btn)
        Me.GroupControl3.Location = New System.Drawing.Point(12, 293)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(496, 127)
        Me.GroupControl3.TabIndex = 49
        Me.GroupControl3.Text = "Matching Swift Message with related EXPORT LC MT700"
        Me.GroupControl3.Visible = False
        '
        'OurReferenceSearch_GridLookUpEdit
        '
        Me.OurReferenceSearch_GridLookUpEdit.EditValue = ""
        Me.OurReferenceSearch_GridLookUpEdit.Location = New System.Drawing.Point(247, 35)
        Me.OurReferenceSearch_GridLookUpEdit.Name = "OurReferenceSearch_GridLookUpEdit"
        Me.OurReferenceSearch_GridLookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OurReferenceSearch_GridLookUpEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.OurReferenceSearch_GridLookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.OurReferenceSearch_GridLookUpEdit.Properties.Appearance.Options.UseForeColor = True
        Me.OurReferenceSearch_GridLookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OurReferenceSearch_GridLookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OurReferenceSearch_GridLookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OurReferenceSearch_GridLookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OurReferenceSearch_GridLookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OurReferenceSearch_GridLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OurReferenceSearch_GridLookUpEdit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.OurReferenceSearch_GridLookUpEdit.Properties.DataSource = Me.EXPORT_LC_MT700_BDBindingSource
        Me.OurReferenceSearch_GridLookUpEdit.Properties.DisplayMember = "OurReference"
        Me.OurReferenceSearch_GridLookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(800, 400)
        Me.OurReferenceSearch_GridLookUpEdit.Properties.PopupView = Me.OurReferenceSearch_GridLookUpEditView
        Me.OurReferenceSearch_GridLookUpEdit.Properties.ValueMember = "OurReference"
        Me.OurReferenceSearch_GridLookUpEdit.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        Me.OurReferenceSearch_GridLookUpEdit.Size = New System.Drawing.Size(205, 30)
        Me.OurReferenceSearch_GridLookUpEdit.TabIndex = 68
        '
        'EXPORT_LC_MT700_BDBindingSource
        '
        Me.EXPORT_LC_MT700_BDBindingSource.DataMember = "EXPORT_LC_MT700_BD"
        Me.EXPORT_LC_MT700_BDBindingSource.DataSource = Me.LcDataset
        '
        'OurReferenceSearch_GridLookUpEditView
        '
        Me.OurReferenceSearch_GridLookUpEditView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLfdNr, Me.colOurReference, Me.colLC_Nr})
        Me.OurReferenceSearch_GridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.OurReferenceSearch_GridLookUpEditView.Name = "OurReferenceSearch_GridLookUpEditView"
        Me.OurReferenceSearch_GridLookUpEditView.OptionsBehavior.AllowIncrementalSearch = True
        Me.OurReferenceSearch_GridLookUpEditView.OptionsFind.AlwaysVisible = True
        Me.OurReferenceSearch_GridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.OurReferenceSearch_GridLookUpEditView.OptionsView.ColumnAutoWidth = False
        Me.OurReferenceSearch_GridLookUpEditView.OptionsView.ShowAutoFilterRow = True
        Me.OurReferenceSearch_GridLookUpEditView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.OurReferenceSearch_GridLookUpEditView.OptionsView.ShowGroupPanel = False
        '
        'colLfdNr
        '
        Me.colLfdNr.FieldName = "LfdNr"
        Me.colLfdNr.Name = "colLfdNr"
        Me.colLfdNr.OptionsColumn.AllowEdit = False
        Me.colLfdNr.OptionsColumn.ReadOnly = True
        Me.colLfdNr.Visible = True
        Me.colLfdNr.VisibleIndex = 2
        Me.colLfdNr.Width = 90
        '
        'colOurReference
        '
        Me.colOurReference.Caption = "Our Reference"
        Me.colOurReference.FieldName = "OurReference"
        Me.colOurReference.Name = "colOurReference"
        Me.colOurReference.OptionsColumn.AllowEdit = False
        Me.colOurReference.OptionsColumn.ReadOnly = True
        Me.colOurReference.Visible = True
        Me.colOurReference.VisibleIndex = 0
        Me.colOurReference.Width = 131
        '
        'colLC_Nr
        '
        Me.colLC_Nr.Caption = "LC Nr."
        Me.colLC_Nr.FieldName = "LC_Nr"
        Me.colLC_Nr.Name = "colLC_Nr"
        Me.colLC_Nr.OptionsColumn.AllowEdit = False
        Me.colLC_Nr.OptionsColumn.ReadOnly = True
        Me.colLC_Nr.Visible = True
        Me.colLC_Nr.VisibleIndex = 1
        Me.colLC_Nr.Width = 234
        '
        'MatchSwiftMessage_btn
        '
        Me.MatchSwiftMessage_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MatchSwiftMessage_btn.ImageOptions.ImageIndex = 13
        Me.MatchSwiftMessage_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.MatchSwiftMessage_btn.Location = New System.Drawing.Point(189, 82)
        Me.MatchSwiftMessage_btn.Name = "MatchSwiftMessage_btn"
        Me.MatchSwiftMessage_btn.Size = New System.Drawing.Size(140, 22)
        Me.MatchSwiftMessage_btn.TabIndex = 66
        Me.MatchSwiftMessage_btn.Text = "Match Message"
        '
        'SWIFT_ROW_TEXT_XtraTabPage
        '
        Me.SWIFT_ROW_TEXT_XtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWIFT_ROW_TEXT_XtraTabPage.Appearance.Header.Options.UseFont = True
        Me.SWIFT_ROW_TEXT_XtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.SWIFT_ROW_TEXT_XtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.SWIFT_ROW_TEXT_XtraTabPage.Controls.Add(Me.GroupControl1)
        Me.SWIFT_ROW_TEXT_XtraTabPage.Name = "SWIFT_ROW_TEXT_XtraTabPage"
        Me.SWIFT_ROW_TEXT_XtraTabPage.Size = New System.Drawing.Size(1449, 663)
        Me.SWIFT_ROW_TEXT_XtraTabPage.Text = "SWIFT MESSAGE (ROW TEXT)"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SwiftText_MemoEdit)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1449, 663)
        Me.GroupControl1.TabIndex = 17
        Me.GroupControl1.Text = "Swift Message Text Block"
        '
        'SwiftText_MemoEdit
        '
        Me.SwiftText_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ALL_SWIFT_MESSAGESBindingSource, "Swift_Message", True))
        Me.SwiftText_MemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SwiftText_MemoEdit.Location = New System.Drawing.Point(2, 20)
        Me.SwiftText_MemoEdit.Name = "SwiftText_MemoEdit"
        Me.SwiftText_MemoEdit.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.SwiftText_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwiftText_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SwiftText_MemoEdit.Properties.Appearance.Options.UseBackColor = True
        Me.SwiftText_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.SwiftText_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.SwiftText_MemoEdit.Properties.ReadOnly = True
        Me.SwiftText_MemoEdit.Size = New System.Drawing.Size(1445, 641)
        Me.SwiftText_MemoEdit.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SearchMessages_btn)
        Me.LayoutControl1.Controls.Add(Me.ViewEdit_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_GridView_btn)
        Me.LayoutControl1.Controls.Add(Me.DateFrom_DateEdit)
        Me.LayoutControl1.Controls.Add(Me.DateTill_DateEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1476, 739)
        Me.LayoutControl1.TabIndex = 18
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SearchMessages_btn
        '
        Me.SearchMessages_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchMessages_btn.ImageOptions.ImageIndex = 13
        Me.SearchMessages_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SearchMessages_btn.Location = New System.Drawing.Point(269, 58)
        Me.SearchMessages_btn.Name = "SearchMessages_btn"
        Me.SearchMessages_btn.Size = New System.Drawing.Size(113, 22)
        Me.SearchMessages_btn.StyleController = Me.LayoutControl1
        Me.SearchMessages_btn.TabIndex = 10
        Me.SearchMessages_btn.Text = "Search"
        '
        'ViewEdit_btn
        '
        Me.ViewEdit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ViewEdit_btn.ImageOptions.ImageIndex = 0
        Me.ViewEdit_btn.Location = New System.Drawing.Point(1321, 12)
        Me.ViewEdit_btn.Name = "ViewEdit_btn"
        Me.ViewEdit_btn.Size = New System.Drawing.Size(143, 22)
        Me.ViewEdit_btn.StyleController = Me.LayoutControl1
        Me.ViewEdit_btn.TabIndex = 10
        Me.ViewEdit_btn.Text = "Edit SSIS"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(124, 69)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(804, 535)
        Me.GridControl1.TabIndex = 10
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'Print_Export_GridView_btn
        '
        Me.Print_Export_GridView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_GridView_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_GridView_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_GridView_btn.Location = New System.Drawing.Point(12, 96)
        Me.Print_Export_GridView_btn.Name = "Print_Export_GridView_btn"
        Me.Print_Export_GridView_btn.Size = New System.Drawing.Size(160, 22)
        Me.Print_Export_GridView_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_GridView_btn.TabIndex = 9
        Me.Print_Export_GridView_btn.Text = "Print or Export"
        '
        'DateFrom_DateEdit
        '
        Me.DateFrom_DateEdit.EditValue = Nothing
        Me.DateFrom_DateEdit.Location = New System.Drawing.Point(24, 58)
        Me.DateFrom_DateEdit.Name = "DateFrom_DateEdit"
        Me.DateFrom_DateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateFrom_DateEdit.Properties.Appearance.Options.UseFont = True
        Me.DateFrom_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.DateFrom_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.DateFrom_DateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateFrom_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom_DateEdit.Properties.MaxLength = 8
        Me.DateFrom_DateEdit.Size = New System.Drawing.Size(122, 22)
        Me.DateFrom_DateEdit.StyleController = Me.LayoutControl1
        Me.DateFrom_DateEdit.TabIndex = 19
        '
        'DateTill_DateEdit
        '
        Me.DateTill_DateEdit.EditValue = Nothing
        Me.DateTill_DateEdit.Location = New System.Drawing.Point(150, 58)
        Me.DateTill_DateEdit.Name = "DateTill_DateEdit"
        Me.DateTill_DateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateTill_DateEdit.Properties.Appearance.Options.UseFont = True
        Me.DateTill_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.DateTill_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateTill_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateTill_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateTill_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateTill_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateTill_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateTill_DateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.DateTill_DateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateTill_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTill_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTill_DateEdit.Properties.MaxLength = 8
        Me.DateTill_DateEdit.Size = New System.Drawing.Size(115, 22)
        Me.DateTill_DateEdit.StyleController = Me.LayoutControl1
        Me.DateTill_DateEdit.TabIndex = 19
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(908, 539)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1476, 739)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(386, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(921, 110)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Print_Export_GridView_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(164, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(164, 84)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(222, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1307, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 110)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 110)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1456, 609)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ViewEdit_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1309, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(147, 110)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Search for SWIFT Messages"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(386, 84)
        Me.LayoutControlGroup2.Text = "Search for SWIFT Messages"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.DateFrom_DateEdit
        Me.LayoutControlItem6.CustomizationFormText = "Date from"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(126, 42)
        Me.LayoutControlItem6.Text = "Date from"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.DateTill_DateEdit
        Me.LayoutControlItem7.CustomizationFormText = "Date Till"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(126, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(119, 42)
        Me.LayoutControlItem7.Text = "Date Till"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SearchMessages_btn
        Me.LayoutControlItem5.CustomizationFormText = "   "
        Me.LayoutControlItem5.Location = New System.Drawing.Point(245, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(117, 42)
        Me.LayoutControlItem5.Text = "   "
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(48, 13)
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane"})
        '
        'RichEditBarController1
        '
        Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPageMarginsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetNormalSectionPageMarginsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetNarrowSectionPageMarginsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetModerateSectionPageMarginsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetWideSectionPageMarginsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ShowPageMarginsSetupFormItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPageOrientationItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetPortraitPageOrientationItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetLandscapePageOrientationItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionPaperKindItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionColumnsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionOneColumnItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionTwoColumnsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionThreeColumnsItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ShowColumnsSetupFormItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertBreakItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertPageBreakItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertColumnBreakItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakNextPageItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakEvenPageItem1)
        Me.RichEditBarController1.BarItems.Add(Me.InsertSectionBreakOddPageItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ChangeSectionLineNumberingItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingNoneItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingContinuousItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingRestartNewPageItem1)
        Me.RichEditBarController1.BarItems.Add(Me.SetSectionLineNumberingRestartNewSectionItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ToggleParagraphSuppressLineNumbersItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ShowLineNumberingFormItem1)
        Me.RichEditBarController1.BarItems.Add(Me.ChangePageColorItem1)
        '
        'EXPORT_LC_MT700_BD_TableAdapter
        '
        Me.EXPORT_LC_MT700_BD_TableAdapter.ClearBeforeFill = True
        '
        'SwiftMessagesAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1476, 739)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.XtraTabControl2)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SwiftMessagesAll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Swift Messages (Incoming)"
        CType(Me.ALL_SWIFT_MESSAGESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllSwiftMessages_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwiftMessageText_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.BASIC_DATAXtraTabPage.ResumeLayout(False)
        Me.BASIC_DATAXtraTabPage.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.Ref21_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ref20_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SenderBranchName_textedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MsgType_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SenderBicName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SenderBIC_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MsgTypeName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.OurReferenceSearch_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXPORT_LC_MT700_BDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OurReferenceSearch_GridLookUpEditView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SWIFT_ROW_TEXT_XtraTabPage.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.SwiftText_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTill_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTill_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RichEditBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LcDataset As PS_TOOL_DX.LcDataset
    Friend WithEvents ALL_SWIFT_MESSAGESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ALL_SWIFT_MESSAGESTableAdapter As PS_TOOL_DX.LcDatasetTableAdapters.ALL_SWIFT_MESSAGESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents BASIC_DATAXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Ref21_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Ref20_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SenderBranchName_textedit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MsgType_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SenderBicName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SenderBIC_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MsgTypeName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ID_lbl As System.Windows.Forms.Label
    Friend WithEvents SwiftMsgPrint_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AllMsg_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchMessages_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewEdit_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AllSwiftMessages_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSwiftFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRef20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRef21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMessageType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMessageTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSenderBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSenderName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSenderBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOSN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOSN_ReceivedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSwift_Message As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SettlementStatusRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BICCODERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CurrencyRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents SwiftMessageText_RepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents AmountRepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ExportLCMaturitiesDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colDocsSendOn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colDocsSendOn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colApplicantsBank1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colApplicantsBank1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOurReference1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOurReference1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrency1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrency1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAmount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAmount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMaturity1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMaturity1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSettlementStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSettlementStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colNotes1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colNotes1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Print_Export_GridView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateFrom_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateTill_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents SWIFT_ROW_TEXT_XtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ChangeSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPageMarginsItem
    Friend WithEvents SetNormalSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetNormalSectionPageMarginsItem
    Friend WithEvents SetNarrowSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetNarrowSectionPageMarginsItem
    Friend WithEvents SetModerateSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetModerateSectionPageMarginsItem
    Friend WithEvents SetWideSectionPageMarginsItem1 As DevExpress.XtraRichEdit.UI.SetWideSectionPageMarginsItem
    Friend WithEvents ShowPageMarginsSetupFormItem1 As DevExpress.XtraRichEdit.UI.ShowPageMarginsSetupFormItem
    Friend WithEvents ChangeSectionPageOrientationItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPageOrientationItem
    Friend WithEvents SetPortraitPageOrientationItem1 As DevExpress.XtraRichEdit.UI.SetPortraitPageOrientationItem
    Friend WithEvents SetLandscapePageOrientationItem1 As DevExpress.XtraRichEdit.UI.SetLandscapePageOrientationItem
    Friend WithEvents ChangeSectionPaperKindItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionPaperKindItem
    Friend WithEvents ChangeSectionColumnsItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionColumnsItem
    Friend WithEvents SetSectionOneColumnItem1 As DevExpress.XtraRichEdit.UI.SetSectionOneColumnItem
    Friend WithEvents SetSectionTwoColumnsItem1 As DevExpress.XtraRichEdit.UI.SetSectionTwoColumnsItem
    Friend WithEvents SetSectionThreeColumnsItem1 As DevExpress.XtraRichEdit.UI.SetSectionThreeColumnsItem
    Friend WithEvents ShowColumnsSetupFormItem1 As DevExpress.XtraRichEdit.UI.ShowColumnsSetupFormItem
    Friend WithEvents InsertBreakItem1 As DevExpress.XtraRichEdit.UI.InsertBreakItem
    Friend WithEvents InsertPageBreakItem1 As DevExpress.XtraRichEdit.UI.InsertPageBreakItem
    Friend WithEvents InsertColumnBreakItem1 As DevExpress.XtraRichEdit.UI.InsertColumnBreakItem
    Friend WithEvents InsertSectionBreakNextPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakNextPageItem
    Friend WithEvents InsertSectionBreakEvenPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakEvenPageItem
    Friend WithEvents InsertSectionBreakOddPageItem1 As DevExpress.XtraRichEdit.UI.InsertSectionBreakOddPageItem
    Friend WithEvents ChangeSectionLineNumberingItem1 As DevExpress.XtraRichEdit.UI.ChangeSectionLineNumberingItem
    Friend WithEvents SetSectionLineNumberingNoneItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingNoneItem
    Friend WithEvents SetSectionLineNumberingContinuousItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingContinuousItem
    Friend WithEvents SetSectionLineNumberingRestartNewPageItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewPageItem
    Friend WithEvents SetSectionLineNumberingRestartNewSectionItem1 As DevExpress.XtraRichEdit.UI.SetSectionLineNumberingRestartNewSectionItem
    Friend WithEvents ToggleParagraphSuppressLineNumbersItem1 As DevExpress.XtraRichEdit.UI.ToggleParagraphSuppressLineNumbersItem
    Friend WithEvents ShowLineNumberingFormItem1 As DevExpress.XtraRichEdit.UI.ShowLineNumberingFormItem
    Friend WithEvents ChangePageColorItem1 As DevExpress.XtraRichEdit.UI.ChangePageColorItem
    Friend WithEvents RichEditBarController1 As DevExpress.XtraRichEdit.UI.RichEditBarController
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SwiftText_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SwiftMessageFormated_RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MatchSwiftMessage_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OurReferenceSearch_GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents OurReferenceSearch_GridLookUpEditView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLfdNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOurReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLC_Nr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OSN_ReceivedDateLabel1 As System.Windows.Forms.Label
    Friend WithEvents EXPORT_LC_MT700_BDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EXPORT_LC_MT700_BD_TableAdapter As PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_MT700_BD_TableAdapter
End Class
