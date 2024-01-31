<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerRating
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerRating))
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue5 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule6 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue6 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.CustomerRating_DetailView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRatingType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRating1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCoreDefinition1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid_From = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid_Till = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIDNr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.CUSTOMER_RATINGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RiskControllingBasicsDataSet = New PS_TOOL_DX.RiskControllingBasicsDataSet()
        Me.CustomerRating_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RatingStatus_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colExternalRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCoreDefinition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStandardPoorsRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colER_25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colER_45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMainlandBranchRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMoodysRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFitchRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colActiveRating = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RatesRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.ER1_RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ExternalRatingRepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colExternalRating1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStufe1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCentralGov1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInstitutOver = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInstitutLess = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCorporates1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRating2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPopupContainerEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.PopupContainerControl2 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.CUSTOMER_RATING_DETAILSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DeleteRatingDetails_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.RATING_GridLookUpEdit = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.CancelRatingDetails_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.SaveRatingDetails_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit8 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit12 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.ValidFrom_TextEdit = New DevExpress.XtraEditors.DateEdit()
        Me.ValidTill_TextEdit = New DevExpress.XtraEditors.DateEdit()
        Me.IDNr_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.PDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CUSTOMER_RATINGTableAdapter = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CUSTOMER_RATINGTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager()
        Me.CUSTOMER_RATING_DETAILSTableAdapter = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CUSTOMER_RATING_DETAILSTableAdapter()
        Me.PDTableAdapter = New PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.PDTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.Ratings_All_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemPopupContainerEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemGridLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CustomerRating_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.CustomerRatingDetailsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClientNo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRatingType1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLGD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid_From1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValid_Till1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIDNr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCoreDefinition2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.ImageComboBoxEdit1 = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.DisplayAllCustomers_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.ClientName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RatingClientNr_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Label3 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        CType(Me.CustomerRating_DetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMER_RATINGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskControllingBasicsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerRating_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RatingStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RatesRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ER1_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExternalRatingRepositoryItemGridLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExternalRatingRepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl2.SuspendLayout()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMER_RATING_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RATING_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidFrom_TextEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidFrom_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidTill_TextEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidTill_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ratings_All_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerRatingDetailsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RatingClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label3.Location = New System.Drawing.Point(43, 12)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(57, 13)
        Label3.TabIndex = 13
        Label3.Text = "Client Nr:"
        '
        'Label11
        '
        Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label11.Location = New System.Drawing.Point(22, 36)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(77, 13)
        Label11.TabIndex = 50
        Label11.Text = "Client Name:"
        '
        'Label13
        '
        Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Label13.Location = New System.Drawing.Point(329, 8)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(73, 13)
        Label13.TabIndex = 52
        Label13.Text = "Client Type:"
        '
        'CustomerRating_DetailView
        '
        Me.CustomerRating_DetailView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CustomerRating_DetailView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CustomerRating_DetailView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.CustomerRating_DetailView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.CustomerRating_DetailView.Appearance.FocusedCell.Options.UseForeColor = True
        Me.CustomerRating_DetailView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CustomerRating_DetailView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerRating_DetailView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CustomerRating_DetailView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CustomerRating_DetailView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CustomerRating_DetailView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerRating_DetailView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CustomerRating_DetailView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.CustomerRating_DetailView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerRating_DetailView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.CustomerRating_DetailView.Appearance.SelectedRow.Options.UseBackColor = True
        Me.CustomerRating_DetailView.Appearance.SelectedRow.Options.UseForeColor = True
        Me.CustomerRating_DetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colClientNo1, Me.colRatingType, Me.colRating1, Me.colCoreDefinition1, Me.colPD1, Me.colValid_From, Me.colValid_Till, Me.colIDNr})
        Me.CustomerRating_DetailView.GridControl = Me.GridControl2
        Me.CustomerRating_DetailView.GroupCount = 1
        Me.CustomerRating_DetailView.Name = "CustomerRating_DetailView"
        Me.CustomerRating_DetailView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CustomerRating_DetailView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CustomerRating_DetailView.OptionsBehavior.Editable = False
        Me.CustomerRating_DetailView.OptionsFind.AlwaysVisible = True
        Me.CustomerRating_DetailView.OptionsView.ColumnAutoWidth = False
        Me.CustomerRating_DetailView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CustomerRating_DetailView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colRatingType, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.CustomerRating_DetailView.ViewCaption = "Customers Rating Details"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        '
        'colClientNo1
        '
        Me.colClientNo1.Caption = "Client Nr."
        Me.colClientNo1.FieldName = "ClientNo"
        Me.colClientNo1.Name = "colClientNo1"
        '
        'colRatingType
        '
        Me.colRatingType.Caption = "Rating Type"
        Me.colRatingType.FieldName = "RatingType"
        Me.colRatingType.Name = "colRatingType"
        Me.colRatingType.Visible = True
        Me.colRatingType.VisibleIndex = 0
        Me.colRatingType.Width = 110
        '
        'colRating1
        '
        Me.colRating1.AppearanceCell.Options.UseTextOptions = True
        Me.colRating1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRating1.Caption = "Rating"
        Me.colRating1.FieldName = "Rating"
        Me.colRating1.Name = "colRating1"
        Me.colRating1.Visible = True
        Me.colRating1.VisibleIndex = 0
        Me.colRating1.Width = 91
        '
        'colCoreDefinition1
        '
        Me.colCoreDefinition1.Caption = "Core Definition"
        Me.colCoreDefinition1.FieldName = "CoreDefinition"
        Me.colCoreDefinition1.Name = "colCoreDefinition1"
        Me.colCoreDefinition1.Visible = True
        Me.colCoreDefinition1.VisibleIndex = 4
        '
        'colPD1
        '
        Me.colPD1.Caption = "PD"
        Me.colPD1.DisplayFormat.FormatString = "p3"
        Me.colPD1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPD1.FieldName = "PD"
        Me.colPD1.Name = "colPD1"
        Me.colPD1.Visible = True
        Me.colPD1.VisibleIndex = 1
        '
        'colValid_From
        '
        Me.colValid_From.AppearanceCell.Options.UseTextOptions = True
        Me.colValid_From.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValid_From.Caption = "Valid from"
        Me.colValid_From.FieldName = "Valid_From"
        Me.colValid_From.Name = "colValid_From"
        Me.colValid_From.Visible = True
        Me.colValid_From.VisibleIndex = 2
        Me.colValid_From.Width = 94
        '
        'colValid_Till
        '
        Me.colValid_Till.AppearanceCell.Options.UseTextOptions = True
        Me.colValid_Till.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValid_Till.Caption = "Valid till"
        Me.colValid_Till.FieldName = "Valid_Till"
        Me.colValid_Till.Name = "colValid_Till"
        Me.colValid_Till.Visible = True
        Me.colValid_Till.VisibleIndex = 3
        Me.colValid_Till.Width = 98
        '
        'colIDNr
        '
        Me.colIDNr.FieldName = "IDNr"
        Me.colIDNr.Name = "colIDNr"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.CUSTOMER_RATINGBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridLevelNode1.LevelTemplate = Me.CustomerRating_DetailView
        GridLevelNode1.RelationName = "FK_CUSTOMER_RATING_DETAILS_CUSTOMER_RATING_DETAILS"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(24, 71)
        Me.GridControl2.MainView = Me.CustomerRating_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RatesRepositoryItemTextEdit1, Me.RepositoryItemPopupContainerEdit1, Me.ER1_RepositoryItemTextEdit, Me.RepositoryItemCheckEdit1, Me.ExternalRatingRepositoryItemGridLookUpEdit, Me.RatingStatus_RepositoryItemImageComboBox})
        Me.GridControl2.Size = New System.Drawing.Size(1496, 652)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CustomerRating_BaseView, Me.CustomerRating_DetailView})
        '
        'CUSTOMER_RATINGBindingSource
        '
        Me.CUSTOMER_RATINGBindingSource.DataMember = "CUSTOMER_RATING"
        Me.CUSTOMER_RATINGBindingSource.DataSource = Me.RiskControllingBasicsDataSet
        '
        'RiskControllingBasicsDataSet
        '
        Me.RiskControllingBasicsDataSet.DataSetName = "RiskControllingBasicsDataSet"
        Me.RiskControllingBasicsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomerRating_BaseView
        '
        Me.CustomerRating_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CustomerRating_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerRating_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CustomerRating_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CustomerRating_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CustomerRating_BaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerRating_BaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CustomerRating_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colClientNo, Me.colClientName, Me.colClientType, Me.colRating, Me.colExternalRating, Me.colCoreDefinition, Me.colStandardPoorsRating, Me.colPD, Me.colER_25, Me.colER_45, Me.ColMainlandBranchRating, Me.colMoodysRating, Me.colFitchRating, Me.colActiveRating, Me.colValid})
        Me.CustomerRating_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Column = Me.colActiveRating
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = CType(1, Byte)
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Column = Me.colActiveRating
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.White
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = CType(0, Byte)
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.Column = Me.colExternalRating
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue3.Value1 = "No Rating"
        GridFormatRule3.Rule = FormatConditionRuleValue3
        Me.CustomerRating_BaseView.FormatRules.Add(GridFormatRule1)
        Me.CustomerRating_BaseView.FormatRules.Add(GridFormatRule2)
        Me.CustomerRating_BaseView.FormatRules.Add(GridFormatRule3)
        Me.CustomerRating_BaseView.GridControl = Me.GridControl2
        Me.CustomerRating_BaseView.Name = "CustomerRating_BaseView"
        Me.CustomerRating_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CustomerRating_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CustomerRating_BaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CustomerRating_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.CustomerRating_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CustomerRating_BaseView.OptionsFind.AlwaysVisible = True
        Me.CustomerRating_BaseView.OptionsPrint.PrintDetails = True
        Me.CustomerRating_BaseView.OptionsSelection.MultiSelect = True
        Me.CustomerRating_BaseView.OptionsView.ColumnAutoWidth = False
        Me.CustomerRating_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CustomerRating_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CustomerRating_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.CustomerRating_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CustomerRating_BaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colClientNo
        '
        Me.colClientNo.AppearanceCell.Options.UseTextOptions = True
        Me.colClientNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colClientNo.FieldName = "ClientNo"
        Me.colClientNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientNo.Name = "colClientNo"
        Me.colClientNo.OptionsColumn.AllowEdit = False
        Me.colClientNo.OptionsColumn.ReadOnly = True
        Me.colClientNo.Visible = True
        Me.colClientNo.VisibleIndex = 0
        Me.colClientNo.Width = 159
        '
        'colClientName
        '
        Me.colClientName.FieldName = "ClientName"
        Me.colClientName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientName.Name = "colClientName"
        Me.colClientName.OptionsColumn.AllowEdit = False
        Me.colClientName.OptionsColumn.ReadOnly = True
        Me.colClientName.Visible = True
        Me.colClientName.VisibleIndex = 3
        Me.colClientName.Width = 403
        '
        'colClientType
        '
        Me.colClientType.Caption = "Client Type"
        Me.colClientType.FieldName = "ClientType"
        Me.colClientType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colClientType.Name = "colClientType"
        Me.colClientType.OptionsColumn.AllowEdit = False
        Me.colClientType.OptionsColumn.ReadOnly = True
        Me.colClientType.Visible = True
        Me.colClientType.VisibleIndex = 1
        Me.colClientType.Width = 105
        '
        'colRating
        '
        Me.colRating.AppearanceCell.Options.UseTextOptions = True
        Me.colRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRating.Caption = "Rating Status"
        Me.colRating.ColumnEdit = Me.RatingStatus_RepositoryItemImageComboBox
        Me.colRating.FieldName = "Rating"
        Me.colRating.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colRating.Name = "colRating"
        Me.colRating.OptionsColumn.ReadOnly = True
        Me.colRating.Visible = True
        Me.colRating.VisibleIndex = 4
        Me.colRating.Width = 91
        '
        'RatingStatus_RepositoryItemImageComboBox
        '
        Me.RatingStatus_RepositoryItemImageComboBox.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RatingStatus_RepositoryItemImageComboBox.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RatingStatus_RepositoryItemImageComboBox.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RatingStatus_RepositoryItemImageComboBox.Appearance.Options.UseBackColor = True
        Me.RatingStatus_RepositoryItemImageComboBox.Appearance.Options.UseForeColor = True
        Me.RatingStatus_RepositoryItemImageComboBox.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RatingStatus_RepositoryItemImageComboBox.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RatingStatus_RepositoryItemImageComboBox.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RatingStatus_RepositoryItemImageComboBox.AppearanceFocused.Options.UseBackColor = True
        Me.RatingStatus_RepositoryItemImageComboBox.AppearanceFocused.Options.UseForeColor = True
        Me.RatingStatus_RepositoryItemImageComboBox.AutoHeight = False
        Me.RatingStatus_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RatingStatus_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNDEFINED", "U", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEFINED", "Y", 7)})
        Me.RatingStatus_RepositoryItemImageComboBox.Name = "RatingStatus_RepositoryItemImageComboBox"
        Me.RatingStatus_RepositoryItemImageComboBox.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("boperson_16x16.png", "images/business%20objects/boperson_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boperson_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "boperson_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("addfile_16x16.png", "images/actions/addfile_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/addfile_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "addfile_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("listbullets_16x16.png", "images/format/listbullets_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/format/listbullets_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "listbullets_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("question_16x16.png", "images/support/question_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/question_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "question_16x16.png")
        '
        'colExternalRating
        '
        Me.colExternalRating.AppearanceCell.Options.UseTextOptions = True
        Me.colExternalRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colExternalRating.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colExternalRating.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colExternalRating.AppearanceHeader.Options.UseFont = True
        Me.colExternalRating.AppearanceHeader.Options.UseForeColor = True
        Me.colExternalRating.AppearanceHeader.Options.UseTextOptions = True
        Me.colExternalRating.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colExternalRating.Caption = "External Rating-NOT USED"
        Me.colExternalRating.FieldName = "ExternalRating"
        Me.colExternalRating.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.colExternalRating.Name = "colExternalRating"
        Me.colExternalRating.Width = 87
        '
        'colCoreDefinition
        '
        Me.colCoreDefinition.Caption = "Core definition-NOT USED"
        Me.colCoreDefinition.FieldName = "CoreDefinition"
        Me.colCoreDefinition.Name = "colCoreDefinition"
        Me.colCoreDefinition.OptionsColumn.AllowEdit = False
        Me.colCoreDefinition.OptionsColumn.ReadOnly = True
        Me.colCoreDefinition.Width = 116
        '
        'colStandardPoorsRating
        '
        Me.colStandardPoorsRating.Caption = "Standard + Poors - NOT USED"
        Me.colStandardPoorsRating.FieldName = "StandardPoorsRating"
        Me.colStandardPoorsRating.Name = "colStandardPoorsRating"
        Me.colStandardPoorsRating.OptionsColumn.AllowEdit = False
        Me.colStandardPoorsRating.OptionsColumn.ReadOnly = True
        Me.colStandardPoorsRating.Width = 107
        '
        'colPD
        '
        Me.colPD.Caption = "PD-NOT USED"
        Me.colPD.DisplayFormat.FormatString = "p3"
        Me.colPD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPD.FieldName = "PD"
        Me.colPD.Name = "colPD"
        Me.colPD.OptionsColumn.AllowEdit = False
        Me.colPD.OptionsColumn.ReadOnly = True
        Me.colPD.Width = 73
        '
        'colER_25
        '
        Me.colER_25.Caption = "ER (1)-NOT USED"
        Me.colER_25.DisplayFormat.FormatString = "p2"
        Me.colER_25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colER_25.FieldName = "ER_25"
        Me.colER_25.Name = "colER_25"
        Me.colER_25.Width = 67
        '
        'colER_45
        '
        Me.colER_45.Caption = "LGD-NOT USED"
        Me.colER_45.DisplayFormat.FormatString = "p2"
        Me.colER_45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colER_45.FieldName = "ER_45"
        Me.colER_45.Name = "colER_45"
        Me.colER_45.OptionsColumn.AllowEdit = False
        Me.colER_45.OptionsColumn.ReadOnly = True
        Me.colER_45.Width = 63
        '
        'ColMainlandBranchRating
        '
        Me.ColMainlandBranchRating.AppearanceCell.Options.UseTextOptions = True
        Me.ColMainlandBranchRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColMainlandBranchRating.Caption = "Mainlandbranch Rating-NOT USED"
        Me.ColMainlandBranchRating.FieldName = "MainlandBranchRating"
        Me.ColMainlandBranchRating.Name = "ColMainlandBranchRating"
        Me.ColMainlandBranchRating.OptionsColumn.AllowEdit = False
        Me.ColMainlandBranchRating.OptionsColumn.ReadOnly = True
        Me.ColMainlandBranchRating.Width = 117
        '
        'colMoodysRating
        '
        Me.colMoodysRating.AppearanceCell.Options.UseTextOptions = True
        Me.colMoodysRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMoodysRating.Caption = "Moodys-NOT USED"
        Me.colMoodysRating.FieldName = "MoodysRating"
        Me.colMoodysRating.Name = "colMoodysRating"
        Me.colMoodysRating.OptionsColumn.AllowEdit = False
        Me.colMoodysRating.OptionsColumn.ReadOnly = True
        Me.colMoodysRating.Width = 103
        '
        'colFitchRating
        '
        Me.colFitchRating.AppearanceCell.Options.UseTextOptions = True
        Me.colFitchRating.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFitchRating.Caption = "Fitch-NOT USED"
        Me.colFitchRating.FieldName = "FitchRating"
        Me.colFitchRating.Name = "colFitchRating"
        Me.colFitchRating.OptionsColumn.AllowEdit = False
        Me.colFitchRating.OptionsColumn.ReadOnly = True
        Me.colFitchRating.Width = 111
        '
        'colActiveRating
        '
        Me.colActiveRating.Caption = "Active Credit Rating Calculation-NOT USED"
        Me.colActiveRating.FieldName = "ActiveRatingCalculation"
        Me.colActiveRating.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colActiveRating.Name = "colActiveRating"
        Me.colActiveRating.Width = 104
        '
        'colValid
        '
        Me.colValid.Caption = "Client Status"
        Me.colValid.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colValid.FieldName = "Valid"
        Me.colValid.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colValid.Name = "colValid"
        Me.colValid.OptionsColumn.ReadOnly = True
        Me.colValid.Visible = True
        Me.colValid.VisibleIndex = 2
        Me.colValid.Width = 87
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "N", 8)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'RatesRepositoryItemTextEdit1
        '
        Me.RatesRepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RatesRepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RatesRepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RatesRepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RatesRepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RatesRepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RatesRepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.RatesRepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RatesRepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RatesRepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RatesRepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RatesRepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RatesRepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RatesRepositoryItemTextEdit1.AutoHeight = False
        Me.RatesRepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RatesRepositoryItemTextEdit1.DisplayFormat.FormatString = "p2"
        Me.RatesRepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RatesRepositoryItemTextEdit1.EditFormat.FormatString = "n5"
        Me.RatesRepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RatesRepositoryItemTextEdit1.Mask.EditMask = "n5"
        Me.RatesRepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RatesRepositoryItemTextEdit1.Name = "RatesRepositoryItemTextEdit1"
        '
        'RepositoryItemPopupContainerEdit1
        '
        Me.RepositoryItemPopupContainerEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemPopupContainerEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemPopupContainerEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemPopupContainerEdit1.AutoHeight = False
        Me.RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        '
        'ER1_RepositoryItemTextEdit
        '
        Me.ER1_RepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ER1_RepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ER1_RepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ER1_RepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.ER1_RepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.ER1_RepositoryItemTextEdit.AutoHeight = False
        Me.ER1_RepositoryItemTextEdit.DisplayFormat.FormatString = "p2"
        Me.ER1_RepositoryItemTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ER1_RepositoryItemTextEdit.EditFormat.FormatString = "n2"
        Me.ER1_RepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ER1_RepositoryItemTextEdit.Mask.EditMask = "n2"
        Me.ER1_RepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ER1_RepositoryItemTextEdit.Name = "ER1_RepositoryItemTextEdit"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "ACTIVE"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "DEACTIVATED"
        Me.RepositoryItemCheckEdit1.ImageOptions.ImageIndexChecked = 4
        Me.RepositoryItemCheckEdit1.ImageOptions.ImageIndexUnchecked = 3
        Me.RepositoryItemCheckEdit1.ImageOptions.Images = Me.ImageCollection1
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ExternalRatingRepositoryItemGridLookUpEdit
        '
        Me.ExternalRatingRepositoryItemGridLookUpEdit.AutoHeight = False
        Me.ExternalRatingRepositoryItemGridLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExternalRatingRepositoryItemGridLookUpEdit.Name = "ExternalRatingRepositoryItemGridLookUpEdit"
        Me.ExternalRatingRepositoryItemGridLookUpEdit.NullText = ""
        Me.ExternalRatingRepositoryItemGridLookUpEdit.PopupFormSize = New System.Drawing.Size(0, 500)
        Me.ExternalRatingRepositoryItemGridLookUpEdit.PopupView = Me.ExternalRatingRepositoryItemGridLookUpEdit1View
        '
        'ExternalRatingRepositoryItemGridLookUpEdit1View
        '
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colExternalRating1, Me.colStufe1, Me.colCentralGov1, Me.colInstitutOver, Me.colInstitutLess, Me.colCorporates1})
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.Name = "ExternalRatingRepositoryItemGridLookUpEdit1View"
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsFind.AlwaysVisible = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = False
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExternalRatingRepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colExternalRating1
        '
        Me.colExternalRating1.AppearanceCell.Options.UseTextOptions = True
        Me.colExternalRating1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colExternalRating1.Caption = "Ratings"
        Me.colExternalRating1.FieldName = "Rating"
        Me.colExternalRating1.Name = "colExternalRating1"
        Me.colExternalRating1.OptionsColumn.AllowEdit = False
        Me.colExternalRating1.OptionsColumn.ReadOnly = True
        Me.colExternalRating1.Visible = True
        Me.colExternalRating1.VisibleIndex = 0
        Me.colExternalRating1.Width = 88
        '
        'colStufe1
        '
        Me.colStufe1.Caption = "Stufe"
        Me.colStufe1.FieldName = "Stufe"
        Me.colStufe1.Name = "colStufe1"
        Me.colStufe1.OptionsColumn.AllowEdit = False
        Me.colStufe1.OptionsColumn.ReadOnly = True
        '
        'colCentralGov1
        '
        Me.colCentralGov1.Caption = "Central Coverment"
        Me.colCentralGov1.DisplayFormat.FormatString = "p2"
        Me.colCentralGov1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCentralGov1.FieldName = "CentralGov"
        Me.colCentralGov1.Name = "colCentralGov1"
        Me.colCentralGov1.OptionsColumn.AllowEdit = False
        Me.colCentralGov1.OptionsColumn.ReadOnly = True
        Me.colCentralGov1.Width = 108
        '
        'colInstitutOver
        '
        Me.colInstitutOver.Caption = "Institutions (> 3 Months)"
        Me.colInstitutOver.DisplayFormat.FormatString = "p2"
        Me.colInstitutOver.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInstitutOver.FieldName = "InstiOver3M"
        Me.colInstitutOver.Name = "colInstitutOver"
        Me.colInstitutOver.OptionsColumn.AllowEdit = False
        Me.colInstitutOver.OptionsColumn.ReadOnly = True
        Me.colInstitutOver.Width = 135
        '
        'colInstitutLess
        '
        Me.colInstitutLess.Caption = "Institutions (< 3 Months)"
        Me.colInstitutLess.DisplayFormat.FormatString = "p2"
        Me.colInstitutLess.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colInstitutLess.FieldName = "InstiLess3M"
        Me.colInstitutLess.Name = "colInstitutLess"
        Me.colInstitutLess.OptionsColumn.AllowEdit = False
        Me.colInstitutLess.OptionsColumn.ReadOnly = True
        Me.colInstitutLess.Width = 139
        '
        'colCorporates1
        '
        Me.colCorporates1.Caption = "Corporates"
        Me.colCorporates1.DisplayFormat.FormatString = "p2"
        Me.colCorporates1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCorporates1.FieldName = "Corporates"
        Me.colCorporates1.Name = "colCorporates1"
        Me.colCorporates1.OptionsColumn.AllowEdit = False
        Me.colCorporates1.OptionsColumn.ReadOnly = True
        '
        'colRating2
        '
        Me.colRating2.AppearanceCell.Options.UseTextOptions = True
        Me.colRating2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRating2.ColumnEdit = Me.RepositoryItemPopupContainerEdit2
        Me.colRating2.FieldName = "Rating"
        Me.colRating2.Name = "colRating2"
        Me.colRating2.Visible = True
        Me.colRating2.VisibleIndex = 0
        Me.colRating2.Width = 124
        '
        'RepositoryItemPopupContainerEdit2
        '
        Me.RepositoryItemPopupContainerEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemPopupContainerEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemPopupContainerEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemPopupContainerEdit2.AutoHeight = False
        Me.RepositoryItemPopupContainerEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemPopupContainerEdit2.Name = "RepositoryItemPopupContainerEdit2"
        Me.RepositoryItemPopupContainerEdit2.PopupControl = Me.PopupContainerControl2
        '
        'PopupContainerControl2
        '
        Me.PopupContainerControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl9)
        Me.PopupContainerControl2.Controls.Add(Me.TextEdit3)
        Me.PopupContainerControl2.Controls.Add(Me.DeleteRatingDetails_btn)
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl8)
        Me.PopupContainerControl2.Controls.Add(Me.RATING_GridLookUpEdit)
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl7)
        Me.PopupContainerControl2.Controls.Add(Me.CancelRatingDetails_btn)
        Me.PopupContainerControl2.Controls.Add(Me.SaveRatingDetails_btn)
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl21)
        Me.PopupContainerControl2.Controls.Add(Me.TextEdit8)
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl22)
        Me.PopupContainerControl2.Controls.Add(Me.TextEdit12)
        Me.PopupContainerControl2.Controls.Add(Me.LabelControl26)
        Me.PopupContainerControl2.Controls.Add(Me.ValidFrom_TextEdit)
        Me.PopupContainerControl2.Controls.Add(Me.ValidTill_TextEdit)
        Me.PopupContainerControl2.Controls.Add(Me.IDNr_lbl)
        Me.PopupContainerControl2.Location = New System.Drawing.Point(538, 247)
        Me.PopupContainerControl2.Name = "PopupContainerControl2"
        Me.PopupContainerControl2.Size = New System.Drawing.Size(610, 96)
        Me.PopupContainerControl2.TabIndex = 14
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(313, 13)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl9.TabIndex = 6
        Me.LabelControl9.Text = "LGD"
        '
        'TextEdit3
        '
        Me.TextEdit3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATING_DETAILSBindingSource, "LGD", True))
        Me.TextEdit3.Location = New System.Drawing.Point(313, 28)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEdit3.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit3.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit3.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit3.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit3.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit3.Properties.DisplayFormat.FormatString = "p2"
        Me.TextEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit3.Properties.ReadOnly = True
        Me.TextEdit3.Size = New System.Drawing.Size(77, 20)
        Me.TextEdit3.TabIndex = 7
        Me.TextEdit3.TabStop = False
        '
        'CUSTOMER_RATING_DETAILSBindingSource
        '
        Me.CUSTOMER_RATING_DETAILSBindingSource.DataMember = "FK_CUSTOMER_RATING_DETAILS_CUSTOMER_RATING_DETAILS"
        Me.CUSTOMER_RATING_DETAILSBindingSource.DataSource = Me.CUSTOMER_RATINGBindingSource
        '
        'DeleteRatingDetails_btn
        '
        Me.DeleteRatingDetails_btn.ImageOptions.ImageIndex = 12
        Me.DeleteRatingDetails_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.DeleteRatingDetails_btn.Location = New System.Drawing.Point(233, 65)
        Me.DeleteRatingDetails_btn.Name = "DeleteRatingDetails_btn"
        Me.DeleteRatingDetails_btn.Size = New System.Drawing.Size(157, 23)
        Me.DeleteRatingDetails_btn.TabIndex = 13
        Me.DeleteRatingDetails_btn.TabStop = False
        Me.DeleteRatingDetails_btn.Text = "Delete current Rating"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Options.UseTextOptions = True
        Me.LabelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl8.Location = New System.Drawing.Point(508, 13)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl8.TabIndex = 10
        Me.LabelControl8.Text = "Valid Till"
        Me.LabelControl8.Visible = False
        '
        'RATING_GridLookUpEdit
        '
        Me.RATING_GridLookUpEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CUSTOMER_RATING_DETAILSBindingSource, "Rating", True))
        Me.RATING_GridLookUpEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATING_DETAILSBindingSource, "Rating", True))
        Me.RATING_GridLookUpEdit.EditValue = ""
        Me.RATING_GridLookUpEdit.Location = New System.Drawing.Point(6, 28)
        Me.RATING_GridLookUpEdit.Name = "RATING_GridLookUpEdit"
        Me.RATING_GridLookUpEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.RATING_GridLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RATING_GridLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RATING_GridLookUpEdit.Properties.PopupView = Me.GridView2
        Me.RATING_GridLookUpEdit.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        Me.RATING_GridLookUpEdit.Size = New System.Drawing.Size(118, 20)
        Me.RATING_GridLookUpEdit.TabIndex = 1
        '
        'GridView2
        '
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "Ratings"
        Me.GridColumn7.FieldName = "Rating"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 88
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Stufe"
        Me.GridColumn8.FieldName = "Stufe"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Central Coverment"
        Me.GridColumn9.DisplayFormat.FormatString = "p2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "CentralGov"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Width = 108
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Institutions (> 3 Months)"
        Me.GridColumn10.DisplayFormat.FormatString = "p2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "InstiOver3M"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Width = 135
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Institutions (< 3 Months)"
        Me.GridColumn11.DisplayFormat.FormatString = "p2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "InstiLess3M"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Width = 139
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Corporates"
        Me.GridColumn12.DisplayFormat.FormatString = "p2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "Corporates"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.Location = New System.Drawing.Point(9, 12)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl7.TabIndex = 0
        Me.LabelControl7.Text = "Rating"
        '
        'CancelRatingDetails_btn
        '
        Me.CancelRatingDetails_btn.ImageOptions.ImageIndex = 8
        Me.CancelRatingDetails_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.CancelRatingDetails_btn.Location = New System.Drawing.Point(510, 65)
        Me.CancelRatingDetails_btn.Name = "CancelRatingDetails_btn"
        Me.CancelRatingDetails_btn.Size = New System.Drawing.Size(88, 23)
        Me.CancelRatingDetails_btn.TabIndex = 14
        Me.CancelRatingDetails_btn.Text = "Cancel"
        '
        'SaveRatingDetails_btn
        '
        Me.SaveRatingDetails_btn.ImageOptions.ImageIndex = 6
        Me.SaveRatingDetails_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SaveRatingDetails_btn.Location = New System.Drawing.Point(6, 65)
        Me.SaveRatingDetails_btn.Name = "SaveRatingDetails_btn"
        Me.SaveRatingDetails_btn.Size = New System.Drawing.Size(143, 23)
        Me.SaveRatingDetails_btn.TabIndex = 12
        Me.SaveRatingDetails_btn.Text = "Save Changes"
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Options.UseTextOptions = True
        Me.LabelControl21.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl21.Location = New System.Drawing.Point(412, 13)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl21.TabIndex = 8
        Me.LabelControl21.Text = "Valid From"
        Me.LabelControl21.Visible = False
        '
        'TextEdit8
        '
        Me.TextEdit8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATING_DETAILSBindingSource, "PD", True))
        Me.TextEdit8.Location = New System.Drawing.Point(225, 28)
        Me.TextEdit8.Name = "TextEdit8"
        Me.TextEdit8.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit8.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEdit8.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit8.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit8.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit8.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit8.Properties.DisplayFormat.FormatString = "p3"
        Me.TextEdit8.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit8.Properties.ReadOnly = True
        Me.TextEdit8.Size = New System.Drawing.Size(77, 20)
        Me.TextEdit8.TabIndex = 5
        Me.TextEdit8.TabStop = False
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(228, 13)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl22.TabIndex = 4
        Me.LabelControl22.Text = "PD"
        '
        'TextEdit12
        '
        Me.TextEdit12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATING_DETAILSBindingSource, "RatingType", True))
        Me.TextEdit12.Location = New System.Drawing.Point(130, 28)
        Me.TextEdit12.Name = "TextEdit12"
        Me.TextEdit12.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit12.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit12.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit12.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit12.Properties.ReadOnly = True
        Me.TextEdit12.Size = New System.Drawing.Size(84, 20)
        Me.TextEdit12.TabIndex = 3
        Me.TextEdit12.TabStop = False
        '
        'LabelControl26
        '
        Me.LabelControl26.Location = New System.Drawing.Point(132, 13)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl26.TabIndex = 2
        Me.LabelControl26.Text = "Rating Type"
        '
        'ValidFrom_TextEdit
        '
        Me.ValidFrom_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CUSTOMER_RATING_DETAILSBindingSource, "Valid_From", True))
        Me.ValidFrom_TextEdit.EditValue = Nothing
        Me.ValidFrom_TextEdit.Location = New System.Drawing.Point(412, 28)
        Me.ValidFrom_TextEdit.Name = "ValidFrom_TextEdit"
        Me.ValidFrom_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ValidFrom_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ValidFrom_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidFrom_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidFrom_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidFrom_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ValidFrom_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ValidFrom_TextEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidFrom_TextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidFrom_TextEdit.Size = New System.Drawing.Size(90, 20)
        Me.ValidFrom_TextEdit.TabIndex = 9
        '
        'ValidTill_TextEdit
        '
        Me.ValidTill_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CUSTOMER_RATING_DETAILSBindingSource, "Valid_Till", True))
        Me.ValidTill_TextEdit.EditValue = Nothing
        Me.ValidTill_TextEdit.Location = New System.Drawing.Point(508, 28)
        Me.ValidTill_TextEdit.Name = "ValidTill_TextEdit"
        Me.ValidTill_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ValidTill_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ValidTill_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ValidTill_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ValidTill_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ValidTill_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ValidTill_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ValidTill_TextEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidTill_TextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidTill_TextEdit.Size = New System.Drawing.Size(90, 20)
        Me.ValidTill_TextEdit.TabIndex = 11
        '
        'IDNr_lbl
        '
        Me.IDNr_lbl.Appearance.ForeColor = System.Drawing.SystemColors.Control
        Me.IDNr_lbl.Appearance.Options.UseForeColor = True
        Me.IDNr_lbl.Appearance.Options.UseTextOptions = True
        Me.IDNr_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.IDNr_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATING_DETAILSBindingSource, "ID", True))
        Me.IDNr_lbl.Location = New System.Drawing.Point(11, 71)
        Me.IDNr_lbl.Name = "IDNr_lbl"
        Me.IDNr_lbl.Size = New System.Drawing.Size(25, 13)
        Me.IDNr_lbl.TabIndex = 29
        Me.IDNr_lbl.Text = "IDNR"
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.AppearanceHeader.Options.UseFont = True
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.Caption = "Customer Status"
        Me.GridColumn27.ColumnEdit = Me.RepositoryItemImageComboBox4
        Me.GridColumn27.FieldName = "Valid"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 2
        Me.GridColumn27.Width = 102
        '
        'RepositoryItemImageComboBox4
        '
        Me.RepositoryItemImageComboBox4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox4.AutoHeight = False
        Me.RepositoryItemImageComboBox4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemImageComboBox4.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "N", 8)})
        Me.RepositoryItemImageComboBox4.Name = "RepositoryItemImageComboBox4"
        Me.RepositoryItemImageComboBox4.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemImageComboBox3
        '
        Me.RepositoryItemImageComboBox3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox3.AutoHeight = False
        Me.RepositoryItemImageComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNDEFINED", "U", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEFINED", "Y", 7)})
        Me.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3"
        Me.RepositoryItemImageComboBox3.SmallImages = Me.ImageCollection1
        '
        'PDBindingSource
        '
        Me.PDBindingSource.DataMember = "PD"
        Me.PDBindingSource.DataSource = Me.RiskControllingBasicsDataSet
        '
        'RepositoryItemGridLookUpEdit1
        '
        Me.RepositoryItemGridLookUpEdit1.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit1.Name = "RepositoryItemGridLookUpEdit1"
        Me.RepositoryItemGridLookUpEdit1.NullText = ""
        Me.RepositoryItemGridLookUpEdit1.PopupFormSize = New System.Drawing.Size(0, 500)
        Me.RepositoryItemGridLookUpEdit1.PopupView = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Ratings"
        Me.GridColumn13.FieldName = "Rating"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 88
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Stufe"
        Me.GridColumn14.FieldName = "Stufe"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Central Coverment"
        Me.GridColumn15.DisplayFormat.FormatString = "p2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "CentralGov"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Width = 108
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Institutions (> 3 Months)"
        Me.GridColumn16.DisplayFormat.FormatString = "p2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "InstiOver3M"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Width = 135
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Institutions (< 3 Months)"
        Me.GridColumn17.DisplayFormat.FormatString = "p2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "InstiLess3M"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        Me.GridColumn17.Width = 139
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Corporates"
        Me.GridColumn18.DisplayFormat.FormatString = "p2"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn18.FieldName = "Corporates"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'CUSTOMER_RATINGTableAdapter
        '
        Me.CUSTOMER_RATINGTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CREDIT_RISK_CASH_PLEDGETableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_RATING_DETAILSTableAdapter = Me.CUSTOMER_RATING_DETAILSTableAdapter
        Me.TableAdapterManager.CUSTOMER_RATINGTableAdapter = Me.CUSTOMER_RATINGTableAdapter
        Me.TableAdapterManager.Daily_Art13_Kwg_ChineseBanksTableAdapter = Nothing
        Me.TableAdapterManager.NEW_CREDIT_BUSINESSTableAdapter = Nothing
        Me.TableAdapterManager.PD_EXTERNALTableAdapter = Nothing
        Me.TableAdapterManager.PDTableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_BC_WF1TableAdapter = Nothing
        Me.TableAdapterManager.RATERISK_BC_WFTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.YIELD_CURVESTableAdapter = Nothing
        '
        'CUSTOMER_RATING_DETAILSTableAdapter
        '
        Me.CUSTOMER_RATING_DETAILSTableAdapter.ClearBeforeFill = True
        '
        'PDTableAdapter
        '
        Me.PDTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl4)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.CustomerRating_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(376, 149, 712, 596)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1544, 747)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl4
        '
        Me.GridControl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl4.Location = New System.Drawing.Point(24, 71)
        Me.GridControl4.MainView = Me.Ratings_All_GridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox4, Me.RepositoryItemTextEdit3, Me.RepositoryItemPopupContainerEdit3, Me.RepositoryItemTextEdit4, Me.RepositoryItemCheckEdit3, Me.RepositoryItemGridLookUpEdit2, Me.RepositoryItemImageComboBox3})
        Me.GridControl4.Size = New System.Drawing.Size(1496, 652)
        Me.GridControl4.TabIndex = 14
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Ratings_All_GridView, Me.GridView4})
        '
        'Ratings_All_GridView
        '
        Me.Ratings_All_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Ratings_All_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Ratings_All_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Ratings_All_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Ratings_All_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Ratings_All_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Ratings_All_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Ratings_All_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn22, Me.GridColumn23, Me.GridColumn25, Me.GridColumn24, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32})
        Me.Ratings_All_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Ratings_All_GridView.GridControl = Me.GridControl4
        Me.Ratings_All_GridView.Name = "Ratings_All_GridView"
        Me.Ratings_All_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Ratings_All_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Ratings_All_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Ratings_All_GridView.OptionsCustomization.AllowRowSizing = True
        Me.Ratings_All_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Ratings_All_GridView.OptionsFind.AlwaysVisible = True
        Me.Ratings_All_GridView.OptionsPrint.PrintDetails = True
        Me.Ratings_All_GridView.OptionsSelection.MultiSelect = True
        Me.Ratings_All_GridView.OptionsView.ColumnAutoWidth = False
        Me.Ratings_All_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Ratings_All_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Ratings_All_GridView.OptionsView.ShowAutoFilterRow = True
        Me.Ratings_All_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Ratings_All_GridView.OptionsView.ShowFooter = True
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "ID"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn23.FieldName = "ClientNo"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 0
        Me.GridColumn23.Width = 199
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Client Type"
        Me.GridColumn25.FieldName = "ClientType"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 1
        Me.GridColumn25.Width = 102
        '
        'GridColumn24
        '
        Me.GridColumn24.FieldName = "ClientName"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 3
        Me.GridColumn24.Width = 403
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Rating Type"
        Me.GridColumn26.FieldName = "RatingType"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 4
        Me.GridColumn26.Width = 91
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Rating"
        Me.GridColumn28.FieldName = "Rating"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        Me.GridColumn28.Width = 116
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Core Definition"
        Me.GridColumn29.FieldName = "CoreDefinition"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 6
        Me.GridColumn29.Width = 107
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Valid From"
        Me.GridColumn30.DisplayFormat.FormatString = "d"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn30.FieldName = "Valid_From"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 7
        Me.GridColumn30.Width = 90
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Valid Till"
        Me.GridColumn31.DisplayFormat.FormatString = "d"
        Me.GridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn31.FieldName = "Valid_Till"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 8
        Me.GridColumn31.Width = 85
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "IDNr"
        Me.GridColumn32.FieldName = "IDNr"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        Me.GridColumn32.Width = 63
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.EditFormat.FormatString = "n5"
        Me.RepositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.Mask.EditMask = "n5"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'RepositoryItemPopupContainerEdit3
        '
        Me.RepositoryItemPopupContainerEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemPopupContainerEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemPopupContainerEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemPopupContainerEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemPopupContainerEdit3.AutoHeight = False
        Me.RepositoryItemPopupContainerEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemPopupContainerEdit3.Name = "RepositoryItemPopupContainerEdit3"
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit4.EditFormat.FormatString = "n2"
        Me.RepositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit4.Mask.EditMask = "n2"
        Me.RepositoryItemTextEdit4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemCheckEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.DisplayValueChecked = "ACTIVE"
        Me.RepositoryItemCheckEdit3.DisplayValueUnchecked = "DEACTIVATED"
        Me.RepositoryItemCheckEdit3.ImageOptions.ImageIndexChecked = 4
        Me.RepositoryItemCheckEdit3.ImageOptions.ImageIndexUnchecked = 3
        Me.RepositoryItemCheckEdit3.ImageOptions.Images = Me.ImageCollection1
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'RepositoryItemGridLookUpEdit2
        '
        Me.RepositoryItemGridLookUpEdit2.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit2.Name = "RepositoryItemGridLookUpEdit2"
        Me.RepositoryItemGridLookUpEdit2.NullText = ""
        Me.RepositoryItemGridLookUpEdit2.PopupFormSize = New System.Drawing.Size(0, 500)
        Me.RepositoryItemGridLookUpEdit2.PopupView = Me.GridView6
        '
        'GridView6
        '
        Me.GridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView6.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView6.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView6.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView6.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView6.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView6.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView6.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView6.OptionsFind.AlwaysVisible = True
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.ShowAutoFilterRow = True
        Me.GridView6.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn40
        '
        Me.GridColumn40.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn40.Caption = "Ratings"
        Me.GridColumn40.FieldName = "Rating"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.OptionsColumn.ReadOnly = True
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 0
        Me.GridColumn40.Width = 88
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Stufe"
        Me.GridColumn41.FieldName = "Stufe"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Central Coverment"
        Me.GridColumn42.DisplayFormat.FormatString = "p2"
        Me.GridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn42.FieldName = "CentralGov"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        Me.GridColumn42.Width = 108
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Institutions (> 3 Months)"
        Me.GridColumn43.DisplayFormat.FormatString = "p2"
        Me.GridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn43.FieldName = "InstiOver3M"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        Me.GridColumn43.Width = 135
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Institutions (< 3 Months)"
        Me.GridColumn44.DisplayFormat.FormatString = "p2"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "InstiLess3M"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        Me.GridColumn44.Width = 139
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Corporates"
        Me.GridColumn45.DisplayFormat.FormatString = "p2"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "Corporates"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        '
        'GridView4
        '
        Me.GridView4.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView4.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView4.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.GridView4.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView4.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.GridView4.GridControl = Me.GridControl4
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowIncrementalSearch = True
        Me.GridView4.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView4.OptionsBehavior.Editable = False
        Me.GridView4.OptionsFind.AlwaysVisible = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView4.ViewCaption = "Customers Rating Details"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Client Nr."
        Me.GridColumn2.FieldName = "ClientNo"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Rating Type"
        Me.GridColumn3.FieldName = "RatingType"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 110
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Rating"
        Me.GridColumn4.FieldName = "Rating"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 91
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Core Definition"
        Me.GridColumn5.FieldName = "CoreDefinition"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "PD"
        Me.GridColumn6.DisplayFormat.FormatString = "p3"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "PD"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn19.Caption = "Valid from"
        Me.GridColumn19.FieldName = "Valid_From"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 3
        Me.GridColumn19.Width = 94
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn20.Caption = "Valid till"
        Me.GridColumn20.FieldName = "Valid_Till"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 4
        Me.GridColumn20.Width = 98
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "IDNr"
        Me.GridColumn21.Name = "GridColumn21"
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
        'CustomerRating_Print_Export_btn
        '
        Me.CustomerRating_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CustomerRating_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.CustomerRating_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.CustomerRating_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.CustomerRating_Print_Export_btn.Name = "CustomerRating_Print_Export_btn"
        Me.CustomerRating_Print_Export_btn.Size = New System.Drawing.Size(167, 22)
        Me.CustomerRating_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.CustomerRating_Print_Export_btn.TabIndex = 9
        Me.CustomerRating_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.TabbedControlGroup1})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1544, 747)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(380, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1000, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CustomerRating_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(171, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(209, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1380, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(144, 26)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.TabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = True
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 26)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(1524, 701)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1500, 656)
        Me.LayoutControlGroup2.Text = "RATINGS BY CLIENT NR."
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1500, 656)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1500, 656)
        Me.LayoutControlGroup3.Text = "ALL RATINGS"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridControl4
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1500, 656)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl2
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'PrintableComponentLink2
        '
        Me.PrintableComponentLink2.Component = Me.GridControl4
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'GridControl3
        '
        Me.GridControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.CUSTOMER_RATING_DETAILSBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, True, True, "Add new INTERNAL Rating", "AddInternalRating"), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 11, True, True, "Add new EXTERNAL Rating", "AddExternalRating")})
        Me.GridControl3.Location = New System.Drawing.Point(5, 61)
        Me.GridControl3.MainView = Me.CustomerRatingDetailsView
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.RepositoryItemPopupContainerEdit2, Me.RepositoryItemTextEdit2, Me.RepositoryItemCheckEdit2, Me.RepositoryItemGridLookUpEdit1})
        Me.GridControl3.Size = New System.Drawing.Size(1499, 516)
        Me.GridControl3.TabIndex = 12
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CustomerRatingDetailsView})
        '
        'CustomerRatingDetailsView
        '
        Me.CustomerRatingDetailsView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CustomerRatingDetailsView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerRatingDetailsView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CustomerRatingDetailsView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CustomerRatingDetailsView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CustomerRatingDetailsView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerRatingDetailsView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CustomerRatingDetailsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colClientNo2, Me.colRatingType1, Me.colRating2, Me.colPD2, Me.colLGD, Me.colValid_From1, Me.colValid_Till1, Me.colIDNr1, Me.colCoreDefinition2})
        Me.CustomerRatingDetailsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule4.Column = Me.colRating2
        GridFormatRule4.Name = "Format0"
        FormatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.Red
        FormatConditionRuleValue4.Appearance.BackColor2 = System.Drawing.Color.Red
        FormatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleValue4.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue4.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = "U"
        GridFormatRule4.Rule = FormatConditionRuleValue4
        GridFormatRule5.Column = Me.colRating2
        GridFormatRule5.Name = "Format1"
        FormatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.Yellow
        FormatConditionRuleValue5.Appearance.BackColor2 = System.Drawing.Color.Yellow
        FormatConditionRuleValue5.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue5.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue5.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue5.Value1 = "No Rating"
        GridFormatRule5.Rule = FormatConditionRuleValue5
        GridFormatRule6.Name = "Format2"
        FormatConditionRuleValue6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        FormatConditionRuleValue6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        FormatConditionRuleValue6.Appearance.Options.UseFont = True
        FormatConditionRuleValue6.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue6.Value1 = "No Rating"
        GridFormatRule6.Rule = FormatConditionRuleValue6
        Me.CustomerRatingDetailsView.FormatRules.Add(GridFormatRule4)
        Me.CustomerRatingDetailsView.FormatRules.Add(GridFormatRule5)
        Me.CustomerRatingDetailsView.FormatRules.Add(GridFormatRule6)
        Me.CustomerRatingDetailsView.GridControl = Me.GridControl3
        Me.CustomerRatingDetailsView.GroupCount = 1
        Me.CustomerRatingDetailsView.Name = "CustomerRatingDetailsView"
        Me.CustomerRatingDetailsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CustomerRatingDetailsView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CustomerRatingDetailsView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CustomerRatingDetailsView.OptionsCustomization.AllowRowSizing = True
        Me.CustomerRatingDetailsView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CustomerRatingDetailsView.OptionsFind.AlwaysVisible = True
        Me.CustomerRatingDetailsView.OptionsSelection.MultiSelect = True
        Me.CustomerRatingDetailsView.OptionsView.ColumnAutoWidth = False
        Me.CustomerRatingDetailsView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CustomerRatingDetailsView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CustomerRatingDetailsView.OptionsView.ShowAutoFilterRow = True
        Me.CustomerRatingDetailsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CustomerRatingDetailsView.OptionsView.ShowFooter = True
        Me.CustomerRatingDetailsView.OptionsView.ShowViewCaption = True
        Me.CustomerRatingDetailsView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colRatingType1, DevExpress.Data.ColumnSortOrder.Descending)})
        Me.CustomerRatingDetailsView.ViewCaption = "C U S T O M E R    R A T I N G S"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colClientNo2
        '
        Me.colClientNo2.FieldName = "ClientNo"
        Me.colClientNo2.Name = "colClientNo2"
        Me.colClientNo2.OptionsColumn.AllowEdit = False
        Me.colClientNo2.OptionsColumn.ReadOnly = True
        '
        'colRatingType1
        '
        Me.colRatingType1.FieldName = "RatingType"
        Me.colRatingType1.Name = "colRatingType1"
        Me.colRatingType1.OptionsColumn.AllowEdit = False
        Me.colRatingType1.OptionsColumn.ReadOnly = True
        Me.colRatingType1.Visible = True
        Me.colRatingType1.VisibleIndex = 0
        Me.colRatingType1.Width = 98
        '
        'colPD2
        '
        Me.colPD2.DisplayFormat.FormatString = "p3"
        Me.colPD2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPD2.FieldName = "PD"
        Me.colPD2.Name = "colPD2"
        Me.colPD2.OptionsColumn.AllowEdit = False
        Me.colPD2.OptionsColumn.ReadOnly = True
        Me.colPD2.Visible = True
        Me.colPD2.VisibleIndex = 2
        Me.colPD2.Width = 92
        '
        'colLGD
        '
        Me.colLGD.DisplayFormat.FormatString = "p2"
        Me.colLGD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colLGD.FieldName = "LGD"
        Me.colLGD.Name = "colLGD"
        Me.colLGD.OptionsColumn.AllowEdit = False
        Me.colLGD.OptionsColumn.ReadOnly = True
        '
        'colValid_From1
        '
        Me.colValid_From1.AppearanceCell.Options.UseTextOptions = True
        Me.colValid_From1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValid_From1.Caption = "Valid from"
        Me.colValid_From1.ColumnEdit = Me.RepositoryItemPopupContainerEdit2
        Me.colValid_From1.DisplayFormat.FormatString = "d"
        Me.colValid_From1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colValid_From1.FieldName = "Valid_From"
        Me.colValid_From1.Name = "colValid_From1"
        Me.colValid_From1.Visible = True
        Me.colValid_From1.VisibleIndex = 3
        Me.colValid_From1.Width = 100
        '
        'colValid_Till1
        '
        Me.colValid_Till1.AppearanceCell.Options.UseTextOptions = True
        Me.colValid_Till1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colValid_Till1.Caption = "Valid till"
        Me.colValid_Till1.ColumnEdit = Me.RepositoryItemPopupContainerEdit2
        Me.colValid_Till1.DisplayFormat.FormatString = "d"
        Me.colValid_Till1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colValid_Till1.FieldName = "Valid_Till"
        Me.colValid_Till1.Name = "colValid_Till1"
        Me.colValid_Till1.Visible = True
        Me.colValid_Till1.VisibleIndex = 4
        Me.colValid_Till1.Width = 100
        '
        'colIDNr1
        '
        Me.colIDNr1.FieldName = "IDNr"
        Me.colIDNr1.Name = "colIDNr1"
        Me.colIDNr1.OptionsColumn.AllowEdit = False
        Me.colIDNr1.OptionsColumn.ReadOnly = True
        '
        'colCoreDefinition2
        '
        Me.colCoreDefinition2.FieldName = "CoreDefinition"
        Me.colCoreDefinition2.Name = "colCoreDefinition2"
        Me.colCoreDefinition2.OptionsColumn.AllowEdit = False
        Me.colCoreDefinition2.OptionsColumn.ReadOnly = True
        Me.colCoreDefinition2.Visible = True
        Me.colCoreDefinition2.VisibleIndex = 1
        Me.colCoreDefinition2.Width = 129
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "N", 8)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
        Me.RepositoryItemImageComboBox2.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatString = "n5"
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "n5"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatString = "p2"
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatString = "n2"
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Mask.EditMask = "n2"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemCheckEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.DisplayValueChecked = "ACTIVE"
        Me.RepositoryItemCheckEdit2.DisplayValueUnchecked = "DEACTIVATED"
        Me.RepositoryItemCheckEdit2.ImageOptions.ImageIndexChecked = 4
        Me.RepositoryItemCheckEdit2.ImageOptions.ImageIndexUnchecked = 3
        Me.RepositoryItemCheckEdit2.ImageOptions.Images = Me.ImageCollection1
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.Controls.Add(Me.ImageComboBoxEdit1)
        Me.PanelControl1.Controls.Add(Me.PopupContainerControl2)
        Me.PanelControl1.Controls.Add(Me.DisplayAllCustomers_btn)
        Me.PanelControl1.Controls.Add(Me.TextEdit2)
        Me.PanelControl1.Controls.Add(Label13)
        Me.PanelControl1.Controls.Add(Me.ClientName_TextEdit)
        Me.PanelControl1.Controls.Add(Label11)
        Me.PanelControl1.Controls.Add(Label3)
        Me.PanelControl1.Controls.Add(Me.RatingClientNr_TextEdit)
        Me.PanelControl1.Controls.Add(Me.GridControl3)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 52)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1509, 582)
        Me.PanelControl1.TabIndex = 13
        '
        'ImageComboBoxEdit1
        '
        Me.ImageComboBoxEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ImageComboBoxEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.CUSTOMER_RATINGBindingSource, "Valid", True))
        Me.ImageComboBoxEdit1.Location = New System.Drawing.Point(561, 5)
        Me.ImageComboBoxEdit1.Name = "ImageComboBoxEdit1"
        Me.ImageComboBoxEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImageComboBoxEdit1.Properties.Appearance.Options.UseFont = True
        Me.ImageComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageComboBoxEdit1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("DEAVTIVATED", "N", 8)})
        Me.ImageComboBoxEdit1.Properties.ReadOnly = True
        Me.ImageComboBoxEdit1.Properties.SmallImages = Me.ImageCollection1
        Me.ImageComboBoxEdit1.Properties.UseReadOnlyAppearance = False
        Me.ImageComboBoxEdit1.Size = New System.Drawing.Size(162, 22)
        Me.ImageComboBoxEdit1.TabIndex = 57
        '
        'DisplayAllCustomers_btn
        '
        Me.DisplayAllCustomers_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisplayAllCustomers_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DisplayAllCustomers_btn.ImageOptions.ImageIndex = 13
        Me.DisplayAllCustomers_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.DisplayAllCustomers_btn.Location = New System.Drawing.Point(1307, 31)
        Me.DisplayAllCustomers_btn.Name = "DisplayAllCustomers_btn"
        Me.DisplayAllCustomers_btn.Size = New System.Drawing.Size(196, 22)
        Me.DisplayAllCustomers_btn.TabIndex = 55
        Me.DisplayAllCustomers_btn.Text = "Display all Customers"
        '
        'TextEdit2
        '
        Me.TextEdit2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextEdit2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATINGBindingSource, "ClientType", True))
        Me.TextEdit2.Location = New System.Drawing.Point(404, 5)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.TextEdit2.Properties.Appearance.Options.UseFont = True
        Me.TextEdit2.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.TextEdit2.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.TextEdit2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TextEdit2.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.TextEdit2.Properties.ReadOnly = True
        Me.TextEdit2.Size = New System.Drawing.Size(152, 22)
        Me.TextEdit2.TabIndex = 53
        Me.TextEdit2.TabStop = False
        '
        'ClientName_TextEdit
        '
        Me.ClientName_TextEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ClientName_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATINGBindingSource, "ClientName", True))
        Me.ClientName_TextEdit.Location = New System.Drawing.Point(100, 33)
        Me.ClientName_TextEdit.Name = "ClientName_TextEdit"
        Me.ClientName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientName_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.ClientName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.ClientName_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.ClientName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ClientName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ClientName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ClientName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ClientName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ClientName_TextEdit.Properties.ReadOnly = True
        Me.ClientName_TextEdit.Size = New System.Drawing.Size(740, 22)
        Me.ClientName_TextEdit.TabIndex = 51
        Me.ClientName_TextEdit.TabStop = False
        '
        'RatingClientNr_TextEdit
        '
        Me.RatingClientNr_TextEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RatingClientNr_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUSTOMER_RATINGBindingSource, "ClientNo", True))
        Me.RatingClientNr_TextEdit.Location = New System.Drawing.Point(102, 5)
        Me.RatingClientNr_TextEdit.Name = "RatingClientNr_TextEdit"
        Me.RatingClientNr_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RatingClientNr_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Cyan
        Me.RatingClientNr_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.RatingClientNr_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.RatingClientNr_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RatingClientNr_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RatingClientNr_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RatingClientNr_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.RatingClientNr_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.RatingClientNr_TextEdit.Properties.ReadOnly = True
        Me.RatingClientNr_TextEdit.Size = New System.Drawing.Size(221, 22)
        Me.RatingClientNr_TextEdit.TabIndex = 14
        Me.RatingClientNr_TextEdit.TabStop = False
        '
        'CustomerRating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1544, 747)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("CustomerRating.IconOptions.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "CustomerRating"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Customer Rating"
        CType(Me.CustomerRating_DetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMER_RATINGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskControllingBasicsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerRating_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RatingStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RatesRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ER1_RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExternalRatingRepositoryItemGridLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExternalRatingRepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupContainerControl2.ResumeLayout(False)
        Me.PopupContainerControl2.PerformLayout()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMER_RATING_DETAILSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RATING_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidFrom_TextEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidFrom_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidTill_TextEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidTill_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ratings_All_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerRatingDetailsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.ImageComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RatingClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RiskControllingBasicsDataSet As PS_TOOL_DX.RiskControllingBasicsDataSet
    Friend WithEvents CUSTOMER_RATINGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUSTOMER_RATINGTableAdapter As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CUSTOMER_RATINGTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PDTableAdapter As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.PDTableAdapter
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CustomerRating_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RatesRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CustomerRating_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCoreDefinition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStandardPoorsRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colER_25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colER_45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents ColMainlandBranchRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colMoodysRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFitchRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ER1_RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colActiveRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colClientType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExternalRating As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExternalRatingRepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents ExternalRatingRepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colExternalRating1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStufe1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCentralGov1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInstitutOver As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInstitutLess As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCorporates1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CustomerRatingDetailsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemPopupContainerEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents RatingClientNr_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ClientName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CUSTOMER_RATING_DETAILSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUSTOMER_RATING_DETAILSTableAdapter As PS_TOOL_DX.RiskControllingBasicsDataSetTableAdapters.CUSTOMER_RATING_DETAILSTableAdapter
    Friend WithEvents CustomerRating_DetailView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRatingType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRating1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid_From As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid_Till As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIDNr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCoreDefinition1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colClientNo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRatingType1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRating2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid_From1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValid_Till1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIDNr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCoreDefinition2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PopupContainerControl2 As DevExpress.XtraEditors.PopupContainerControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RATING_GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CancelRatingDetails_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SaveRatingDetails_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit8 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit12 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DisplayAllCustomers_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ValidFrom_TextEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ValidTill_TextEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ImageComboBoxEdit1 As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents DeleteRatingDetails_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents IDNr_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colLGD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RatingStatus_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Ratings_All_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemPopupContainerEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemGridLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
End Class
