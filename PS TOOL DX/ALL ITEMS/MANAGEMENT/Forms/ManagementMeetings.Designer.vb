<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManagementMeetings
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
        Dim TaskIDLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManagementMeetings))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition4 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim OptionsSpelling1 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim OptionsSpelling2 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim OptionsSpelling3 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim OptionsSpelling4 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim OptionsSpelling5 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim CompareAgainstControlValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule = New DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule()
        Dim OptionsSpelling6 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim OptionsSpelling7 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim SpellCheckerISpellDictionary1 As DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary = New DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary()
        Dim SpellCheckerCustomDictionary1 As DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary = New DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary()
        Me.ManagementMeetings_LayoutView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMeetingDate1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMeetingDate2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTaskID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTaskID2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPriority1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPriority2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTaskTopic1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.GeneralRepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.layoutViewField_colTaskTopic2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colTaskDescription1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colTaskDescription2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colParticipants1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colParticipants2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colFollowUp1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colFollowUp2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colResponsibleDepartment1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colResponsibleDepartment2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colResponsibleStaffMember1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colResponsibleStaffMember2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colBeginning1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colBeginning2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colExpectedTermination1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colExpectedTermination2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStatus2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colStatusText1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colStatusText2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrentUser1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrentUser2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.MANAGEMENT_COMITEE_MEETINGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ManagementDataset = New PS_TOOL_DX.ManagementDataset()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ManagementMeetings_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeetingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTaskID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPriority = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTaskTopic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TaskTopicRepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colTaskDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TaskDescriptionRepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colParticipants = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ParticipantsRepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colFollowUp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colResponsibleDepartment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colResponsibleStaffMember = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colBeginning = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colExpectedTermination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colStatusText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrentUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColDaysRemain = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.item5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.item6 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.item8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.item7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.item9 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.item10 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.PriorityComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter = New PS_TOOL_DX.ManagementDatasetTableAdapters.MANAGEMENT_COMITEE_MEETINGTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.ManagementDatasetTableAdapters.TableAdapterManager()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MeetingDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.TaskIDLabel1 = New System.Windows.Forms.Label()
        Me.IDLabel1 = New System.Windows.Forms.Label()
        Me.StatusComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.StatusTextlbl = New System.Windows.Forms.Label()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SingleTaskReport_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TASKTOPICXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.TaskTopicMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.TASKDESCRIPTIONXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.TaskDescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.PARTICIPANTSXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.ParticipantsMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.TASKSCHEDULEXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.ResponsibleStaffMemberMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.ResponsibleDepartmentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ExpectedTerminationDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BeginningDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.FOLLOWUPXtraTabPage = New DevExpress.XtraTab.XtraTabPage()
        Me.UpdateFollowUp_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.FollowUpUpdateMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.FollowUpMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.PopupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.Save_Changes_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ShowAllMeetings_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.PrintableComponentLink2 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.Statuslbl = New System.Windows.Forms.Label()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
        TaskIDLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        CType(Me.ManagementMeetings_LayoutView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMeetingDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTaskID2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPriority2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GeneralRepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTaskTopic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colTaskDescription2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colParticipants2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colFollowUp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colResponsibleDepartment2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colResponsibleStaffMember2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colBeginning2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colExpectedTermination2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStatus2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colStatusText2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrentUser2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANAGEMENT_COMITEE_MEETINGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManagementDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManagementMeetings_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaskTopicRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaskDescriptionRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParticipantsRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResponsibleDepartmentRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResponsibleStaffMemberRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PriorityComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeetingDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeetingDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TASKTOPICXtraTabPage.SuspendLayout()
        CType(Me.TaskTopicMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TASKDESCRIPTIONXtraTabPage.SuspendLayout()
        CType(Me.TaskDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PARTICIPANTSXtraTabPage.SuspendLayout()
        CType(Me.ParticipantsMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TASKSCHEDULEXtraTabPage.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.ResponsibleStaffMemberMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ResponsibleDepartmentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpectedTerminationDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpectedTerminationDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeginningDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeginningDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FOLLOWUPXtraTabPage.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.FollowUpUpdateMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.FollowUpMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TaskIDLabel
        '
        TaskIDLabel.AutoSize = True
        TaskIDLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TaskIDLabel.Location = New System.Drawing.Point(35, 18)
        TaskIDLabel.Name = "TaskIDLabel"
        TaskIDLabel.Size = New System.Drawing.Size(53, 13)
        TaskIDLabel.TabIndex = 21
        TaskIDLabel.Text = "Task ID:"
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(44, 41)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(41, 13)
        IDLabel.TabIndex = 22
        IDLabel.Text = "ID NR:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(220, 41)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(49, 13)
        Label1.TabIndex = 25
        Label1.Text = "Priority"
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(1199, 20)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(44, 13)
        Label2.TabIndex = 26
        Label2.Text = "Status"
        '
        'ManagementMeetings_LayoutView
        '
        Me.ManagementMeetings_LayoutView.CardMinSize = New System.Drawing.Size(957, 566)
        Me.ManagementMeetings_LayoutView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colMeetingDate1, Me.colTaskID1, Me.colPriority1, Me.colTaskTopic1, Me.colTaskDescription1, Me.colParticipants1, Me.colFollowUp1, Me.colResponsibleDepartment1, Me.colResponsibleStaffMember1, Me.colBeginning1, Me.colExpectedTermination1, Me.colStatus1, Me.colStatusText1, Me.colCurrentUser1})
        Me.ManagementMeetings_LayoutView.GridControl = Me.GridControl1
        Me.ManagementMeetings_LayoutView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colCurrentUser2})
        Me.ManagementMeetings_LayoutView.Name = "ManagementMeetings_LayoutView"
        Me.ManagementMeetings_LayoutView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ManagementMeetings_LayoutView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ManagementMeetings_LayoutView.OptionsBehavior.AllowExpandCollapse = False
        Me.ManagementMeetings_LayoutView.OptionsBehavior.AllowPanCards = False
        Me.ManagementMeetings_LayoutView.OptionsBehavior.AllowSwitchViewModes = False
        Me.ManagementMeetings_LayoutView.OptionsBehavior.Editable = False
        Me.ManagementMeetings_LayoutView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.ManagementMeetings_LayoutView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.ManagementMeetings_LayoutView.OptionsCustomization.AllowFilter = False
        Me.ManagementMeetings_LayoutView.OptionsCustomization.AllowSort = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.AllowFilterEditor = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.AllowMRUFilterList = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = False
        Me.ManagementMeetings_LayoutView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.ManagementMeetings_LayoutView.OptionsFind.AllowFindPanel = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnablePanButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowPanButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.ManagementMeetings_LayoutView.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.ManagementMeetings_LayoutView.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.ManagementMeetings_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
        Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.ManagementMeetings_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.ManagementMeetings_LayoutView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colResponsibleStaffMember1, DevExpress.Data.ColumnSortOrder.Descending)})
        Me.ManagementMeetings_LayoutView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID2
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID2
        '
        Me.layoutViewField_colID2.EditorPreferredWidth = 108
        Me.layoutViewField_colID2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID2.Name = "layoutViewField_colID2"
        Me.layoutViewField_colID2.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colID2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colMeetingDate1
        '
        Me.colMeetingDate1.AppearanceCell.Options.UseTextOptions = True
        Me.colMeetingDate1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colMeetingDate1.FieldName = "MeetingDate"
        Me.colMeetingDate1.LayoutViewField = Me.layoutViewField_colMeetingDate2
        Me.colMeetingDate1.Name = "colMeetingDate1"
        Me.colMeetingDate1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colMeetingDate2
        '
        Me.layoutViewField_colMeetingDate2.EditorPreferredWidth = 147
        Me.layoutViewField_colMeetingDate2.Location = New System.Drawing.Point(487, 0)
        Me.layoutViewField_colMeetingDate2.Name = "layoutViewField_colMeetingDate2"
        Me.layoutViewField_colMeetingDate2.Size = New System.Drawing.Size(264, 20)
        Me.layoutViewField_colMeetingDate2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colTaskID1
        '
        Me.colTaskID1.AppearanceCell.Options.UseTextOptions = True
        Me.colTaskID1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colTaskID1.FieldName = "TaskID"
        Me.colTaskID1.LayoutViewField = Me.layoutViewField_colTaskID2
        Me.colTaskID1.Name = "colTaskID1"
        Me.colTaskID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colTaskID2
        '
        Me.layoutViewField_colTaskID2.EditorPreferredWidth = 145
        Me.layoutViewField_colTaskID2.Location = New System.Drawing.Point(225, 0)
        Me.layoutViewField_colTaskID2.Name = "layoutViewField_colTaskID2"
        Me.layoutViewField_colTaskID2.Size = New System.Drawing.Size(262, 20)
        Me.layoutViewField_colTaskID2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colPriority1
        '
        Me.colPriority1.AppearanceCell.Options.UseTextOptions = True
        Me.colPriority1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colPriority1.FieldName = "Priority"
        Me.colPriority1.LayoutViewField = Me.layoutViewField_colPriority2
        Me.colPriority1.Name = "colPriority1"
        Me.colPriority1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPriority2
        '
        Me.layoutViewField_colPriority2.EditorPreferredWidth = 108
        Me.layoutViewField_colPriority2.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colPriority2.Name = "layoutViewField_colPriority2"
        Me.layoutViewField_colPriority2.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colPriority2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colTaskTopic1
        '
        Me.colTaskTopic1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colTaskTopic1.AppearanceCell.Options.UseFont = True
        Me.colTaskTopic1.AppearanceCell.Options.UseTextOptions = True
        Me.colTaskTopic1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colTaskTopic1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colTaskTopic1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colTaskTopic1.FieldName = "TaskTopic"
        Me.colTaskTopic1.LayoutViewField = Me.layoutViewField_colTaskTopic2
        Me.colTaskTopic1.Name = "colTaskTopic1"
        Me.colTaskTopic1.OptionsColumn.ReadOnly = True
        '
        'GeneralRepositoryItemMemoEdit1
        '
        Me.GeneralRepositoryItemMemoEdit1.Name = "GeneralRepositoryItemMemoEdit1"
        '
        'layoutViewField_colTaskTopic2
        '
        Me.layoutViewField_colTaskTopic2.EditorPreferredWidth = 444
        Me.layoutViewField_colTaskTopic2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colTaskTopic2.Name = "layoutViewField_colTaskTopic2"
        Me.layoutViewField_colTaskTopic2.Size = New System.Drawing.Size(448, 421)
        Me.layoutViewField_colTaskTopic2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colTaskTopic2.TextSize = New System.Drawing.Size(82, 13)
        '
        'colTaskDescription1
        '
        Me.colTaskDescription1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colTaskDescription1.AppearanceCell.Options.UseFont = True
        Me.colTaskDescription1.AppearanceCell.Options.UseTextOptions = True
        Me.colTaskDescription1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colTaskDescription1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colTaskDescription1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colTaskDescription1.FieldName = "TaskDescription"
        Me.colTaskDescription1.LayoutViewField = Me.layoutViewField_colTaskDescription2
        Me.colTaskDescription1.Name = "colTaskDescription1"
        Me.colTaskDescription1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colTaskDescription2
        '
        Me.layoutViewField_colTaskDescription2.EditorPreferredWidth = 461
        Me.layoutViewField_colTaskDescription2.Location = New System.Drawing.Point(448, 0)
        Me.layoutViewField_colTaskDescription2.Name = "layoutViewField_colTaskDescription2"
        Me.layoutViewField_colTaskDescription2.Size = New System.Drawing.Size(465, 421)
        Me.layoutViewField_colTaskDescription2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colTaskDescription2.TextSize = New System.Drawing.Size(82, 13)
        '
        'colParticipants1
        '
        Me.colParticipants1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colParticipants1.AppearanceCell.Options.UseFont = True
        Me.colParticipants1.AppearanceCell.Options.UseTextOptions = True
        Me.colParticipants1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colParticipants1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colParticipants1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colParticipants1.FieldName = "Participants"
        Me.colParticipants1.LayoutViewField = Me.layoutViewField_colParticipants2
        Me.colParticipants1.Name = "colParticipants1"
        Me.colParticipants1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colParticipants2
        '
        Me.layoutViewField_colParticipants2.EditorPreferredWidth = 909
        Me.layoutViewField_colParticipants2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colParticipants2.Name = "layoutViewField_colParticipants2"
        Me.layoutViewField_colParticipants2.Size = New System.Drawing.Size(913, 421)
        Me.layoutViewField_colParticipants2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colParticipants2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colParticipants2.TextVisible = False
        '
        'colFollowUp1
        '
        Me.colFollowUp1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colFollowUp1.AppearanceCell.Options.UseFont = True
        Me.colFollowUp1.AppearanceCell.Options.UseTextOptions = True
        Me.colFollowUp1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colFollowUp1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colFollowUp1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colFollowUp1.FieldName = "FollowUp"
        Me.colFollowUp1.LayoutViewField = Me.layoutViewField_colFollowUp2
        Me.colFollowUp1.Name = "colFollowUp1"
        Me.colFollowUp1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colFollowUp2
        '
        Me.layoutViewField_colFollowUp2.EditorPreferredWidth = 909
        Me.layoutViewField_colFollowUp2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colFollowUp2.Name = "layoutViewField_colFollowUp2"
        Me.layoutViewField_colFollowUp2.Size = New System.Drawing.Size(913, 421)
        Me.layoutViewField_colFollowUp2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colFollowUp2.TextVisible = False
        '
        'colResponsibleDepartment1
        '
        Me.colResponsibleDepartment1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colResponsibleDepartment1.AppearanceCell.Options.UseFont = True
        Me.colResponsibleDepartment1.AppearanceCell.Options.UseTextOptions = True
        Me.colResponsibleDepartment1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colResponsibleDepartment1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colResponsibleDepartment1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colResponsibleDepartment1.FieldName = "ResponsibleDepartment"
        Me.colResponsibleDepartment1.LayoutViewField = Me.layoutViewField_colResponsibleDepartment2
        Me.colResponsibleDepartment1.Name = "colResponsibleDepartment1"
        Me.colResponsibleDepartment1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colResponsibleDepartment2
        '
        Me.layoutViewField_colResponsibleDepartment2.EditorPreferredWidth = 442
        Me.layoutViewField_colResponsibleDepartment2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colResponsibleDepartment2.Name = "layoutViewField_colResponsibleDepartment2"
        Me.layoutViewField_colResponsibleDepartment2.Size = New System.Drawing.Size(446, 421)
        Me.layoutViewField_colResponsibleDepartment2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colResponsibleDepartment2.TextSize = New System.Drawing.Size(129, 13)
        '
        'colResponsibleStaffMember1
        '
        Me.colResponsibleStaffMember1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.colResponsibleStaffMember1.AppearanceCell.Options.UseFont = True
        Me.colResponsibleStaffMember1.AppearanceCell.Options.UseTextOptions = True
        Me.colResponsibleStaffMember1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colResponsibleStaffMember1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.colResponsibleStaffMember1.ColumnEdit = Me.GeneralRepositoryItemMemoEdit1
        Me.colResponsibleStaffMember1.FieldName = "ResponsibleStaffMember"
        Me.colResponsibleStaffMember1.LayoutViewField = Me.layoutViewField_colResponsibleStaffMember2
        Me.colResponsibleStaffMember1.Name = "colResponsibleStaffMember1"
        Me.colResponsibleStaffMember1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colResponsibleStaffMember2
        '
        Me.layoutViewField_colResponsibleStaffMember2.EditorPreferredWidth = 463
        Me.layoutViewField_colResponsibleStaffMember2.Location = New System.Drawing.Point(446, 0)
        Me.layoutViewField_colResponsibleStaffMember2.Name = "layoutViewField_colResponsibleStaffMember2"
        Me.layoutViewField_colResponsibleStaffMember2.Size = New System.Drawing.Size(467, 421)
        Me.layoutViewField_colResponsibleStaffMember2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colResponsibleStaffMember2.TextSize = New System.Drawing.Size(129, 13)
        '
        'colBeginning1
        '
        Me.colBeginning1.AppearanceCell.Options.UseTextOptions = True
        Me.colBeginning1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colBeginning1.FieldName = "Beginning"
        Me.colBeginning1.LayoutViewField = Me.layoutViewField_colBeginning2
        Me.colBeginning1.Name = "colBeginning1"
        Me.colBeginning1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colBeginning2
        '
        Me.layoutViewField_colBeginning2.EditorPreferredWidth = 145
        Me.layoutViewField_colBeginning2.Location = New System.Drawing.Point(225, 20)
        Me.layoutViewField_colBeginning2.Name = "layoutViewField_colBeginning2"
        Me.layoutViewField_colBeginning2.Size = New System.Drawing.Size(262, 20)
        Me.layoutViewField_colBeginning2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colExpectedTermination1
        '
        Me.colExpectedTermination1.AppearanceCell.Options.UseTextOptions = True
        Me.colExpectedTermination1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colExpectedTermination1.FieldName = "ExpectedTermination"
        Me.colExpectedTermination1.LayoutViewField = Me.layoutViewField_colExpectedTermination2
        Me.colExpectedTermination1.Name = "colExpectedTermination1"
        Me.colExpectedTermination1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colExpectedTermination2
        '
        Me.layoutViewField_colExpectedTermination2.EditorPreferredWidth = 147
        Me.layoutViewField_colExpectedTermination2.Location = New System.Drawing.Point(487, 20)
        Me.layoutViewField_colExpectedTermination2.Name = "layoutViewField_colExpectedTermination2"
        Me.layoutViewField_colExpectedTermination2.Size = New System.Drawing.Size(264, 20)
        Me.layoutViewField_colExpectedTermination2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colStatus1
        '
        Me.colStatus1.AppearanceCell.Options.UseTextOptions = True
        Me.colStatus1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colStatus1.FieldName = "Status"
        Me.colStatus1.LayoutViewField = Me.layoutViewField_colStatus2
        Me.colStatus1.Name = "colStatus1"
        Me.colStatus1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colStatus2
        '
        Me.layoutViewField_colStatus2.EditorPreferredWidth = 171
        Me.layoutViewField_colStatus2.Location = New System.Drawing.Point(751, 0)
        Me.layoutViewField_colStatus2.Name = "layoutViewField_colStatus2"
        Me.layoutViewField_colStatus2.Size = New System.Drawing.Size(175, 40)
        Me.layoutViewField_colStatus2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutViewField_colStatus2.TextSize = New System.Drawing.Size(108, 13)
        '
        'colStatusText1
        '
        Me.colStatusText1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.colStatusText1.AppearanceCell.Options.UseFont = True
        Me.colStatusText1.FieldName = "StatusText"
        Me.colStatusText1.LayoutViewField = Me.layoutViewField_colStatusText2
        Me.colStatusText1.Name = "colStatusText1"
        Me.colStatusText1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colStatusText2
        '
        Me.layoutViewField_colStatusText2.EditorPreferredWidth = 933
        Me.layoutViewField_colStatusText2.Location = New System.Drawing.Point(0, 507)
        Me.layoutViewField_colStatusText2.Name = "layoutViewField_colStatusText2"
        Me.layoutViewField_colStatusText2.Size = New System.Drawing.Size(937, 20)
        Me.layoutViewField_colStatusText2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_colStatusText2.TextVisible = False
        '
        'colCurrentUser1
        '
        Me.colCurrentUser1.FieldName = "CurrentUser"
        Me.colCurrentUser1.LayoutViewField = Me.layoutViewField_colCurrentUser2
        Me.colCurrentUser1.Name = "colCurrentUser1"
        Me.colCurrentUser1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrentUser2
        '
        Me.layoutViewField_colCurrentUser2.EditorPreferredWidth = 20
        Me.layoutViewField_colCurrentUser2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colCurrentUser2.Name = "layoutViewField_colCurrentUser2"
        Me.layoutViewField_colCurrentUser2.Size = New System.Drawing.Size(937, 146)
        Me.layoutViewField_colCurrentUser2.TextSize = New System.Drawing.Size(129, 13)
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.DataSource = Me.MANAGEMENT_COMITEE_MEETINGBindingSource
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.ImageIndex = 14
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 7, True, True, "Generate Management Commitee Meetings Report", "ManagementCommiteeMeetingsReport"), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 2, True, True, "Print or Export", "PrintExport")})
        GridLevelNode1.LevelTemplate = Me.ManagementMeetings_LayoutView
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(0, 454)
        Me.GridControl1.MainView = Me.ManagementMeetings_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.ParticipantsRepositoryItemMemoExEdit, Me.ResponsibleDepartmentRepositoryItemMemoExEdit, Me.ResponsibleStaffMemberRepositoryItemMemoExEdit, Me.TaskTopicRepositoryItemMemoExEdit, Me.TaskDescriptionRepositoryItemMemoExEdit, Me.GeneralRepositoryItemMemoEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1385, 339)
        Me.GridControl1.TabIndex = 30
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ManagementMeetings_GridView, Me.ManagementMeetings_LayoutView})
        '
        'MANAGEMENT_COMITEE_MEETINGBindingSource
        '
        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.DataMember = "MANAGEMENT COMITEE MEETING"
        Me.MANAGEMENT_COMITEE_MEETINGBindingSource.DataSource = Me.ManagementDataset
        '
        'ManagementDataset
        '
        Me.ManagementDataset.DataSetName = "ManagementDataset"
        Me.ManagementDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.ImageCollection1.Images.SetKeyName(8, "Calculator.ico")
        Me.ImageCollection1.Images.SetKeyName(9, "Pending.ico")
        Me.ImageCollection1.Images.SetKeyName(10, "Still Pending.ico")
        Me.ImageCollection1.Images.SetKeyName(11, "Info.ico")
        Me.ImageCollection1.Images.SetKeyName(12, "Refresh.ico")
        Me.ImageCollection1.Images.SetKeyName(13, "save.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "apply_16x16.png")
        '
        'ManagementMeetings_GridView
        '
        Me.ManagementMeetings_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ManagementMeetings_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ManagementMeetings_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ManagementMeetings_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ManagementMeetings_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ManagementMeetings_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colMeetingDate, Me.colTaskID, Me.colPriority, Me.colTaskTopic, Me.colTaskDescription, Me.colParticipants, Me.colFollowUp, Me.colResponsibleDepartment, Me.colResponsibleStaffMember, Me.colBeginning, Me.colExpectedTermination, Me.colStatus, Me.colStatusText, Me.colCurrentUser, Me.GridColDaysRemain})
        Me.ManagementMeetings_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition1.Expression = "[Obligor Rate] != ?"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition2.Expression = "[Client No] != ?"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition3.Expression = "[Counterparty/Issuer/Collateral Name] != ?"
        StyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition4.Appearance.Options.UseBackColor = True
        StyleFormatCondition4.Appearance.Options.UseForeColor = True
        StyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression
        StyleFormatCondition4.Expression = "[Contract Collateral ID] != ?"
        Me.ManagementMeetings_GridView.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3, StyleFormatCondition4})
        Me.ManagementMeetings_GridView.GridControl = Me.GridControl1
        Me.ManagementMeetings_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Outstanding (EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditOutstandingAmountEUR", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCredit Risk Amount(EUR Equ)", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditRiskAmountEUREquER45", Nothing, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetCreditRiskAmountEUREquER45", Nothing, "{0:n2}")})
        Me.ManagementMeetings_GridView.Name = "ManagementMeetings_GridView"
        Me.ManagementMeetings_GridView.OptionsCustomization.AllowRowSizing = True
        Me.ManagementMeetings_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ManagementMeetings_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.ManagementMeetings_GridView.OptionsFind.AlwaysVisible = True
        Me.ManagementMeetings_GridView.OptionsSelection.MultiSelect = True
        Me.ManagementMeetings_GridView.OptionsView.ColumnAutoWidth = False
        Me.ManagementMeetings_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.ManagementMeetings_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ManagementMeetings_GridView.OptionsView.ShowAutoFilterRow = True
        Me.ManagementMeetings_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ManagementMeetings_GridView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.Caption = "Id Nr"
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'colMeetingDate
        '
        Me.colMeetingDate.FieldName = "MeetingDate"
        Me.colMeetingDate.Name = "colMeetingDate"
        Me.colMeetingDate.OptionsColumn.AllowEdit = False
        Me.colMeetingDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colMeetingDate.OptionsColumn.ReadOnly = True
        Me.colMeetingDate.Visible = True
        Me.colMeetingDate.VisibleIndex = 2
        Me.colMeetingDate.Width = 81
        '
        'colTaskID
        '
        Me.colTaskID.FieldName = "TaskID"
        Me.colTaskID.Name = "colTaskID"
        Me.colTaskID.OptionsColumn.AllowEdit = False
        Me.colTaskID.OptionsColumn.ReadOnly = True
        Me.colTaskID.Visible = True
        Me.colTaskID.VisibleIndex = 1
        '
        'colPriority
        '
        Me.colPriority.AppearanceCell.Options.UseTextOptions = True
        Me.colPriority.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPriority.FieldName = "Priority"
        Me.colPriority.Name = "colPriority"
        Me.colPriority.OptionsColumn.AllowEdit = False
        Me.colPriority.OptionsColumn.ReadOnly = True
        Me.colPriority.Visible = True
        Me.colPriority.VisibleIndex = 5
        Me.colPriority.Width = 45
        '
        'colTaskTopic
        '
        Me.colTaskTopic.ColumnEdit = Me.TaskTopicRepositoryItemMemoExEdit
        Me.colTaskTopic.FieldName = "TaskTopic"
        Me.colTaskTopic.Name = "colTaskTopic"
        Me.colTaskTopic.OptionsColumn.ReadOnly = True
        Me.colTaskTopic.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.[Like]
        Me.colTaskTopic.Visible = True
        Me.colTaskTopic.VisibleIndex = 9
        Me.colTaskTopic.Width = 272
        '
        'TaskTopicRepositoryItemMemoExEdit
        '
        Me.TaskTopicRepositoryItemMemoExEdit.AutoHeight = False
        Me.TaskTopicRepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TaskTopicRepositoryItemMemoExEdit.Name = "TaskTopicRepositoryItemMemoExEdit"
        Me.TaskTopicRepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.TaskTopicRepositoryItemMemoExEdit.ShowIcon = False
        '
        'colTaskDescription
        '
        Me.colTaskDescription.ColumnEdit = Me.TaskDescriptionRepositoryItemMemoExEdit
        Me.colTaskDescription.FieldName = "TaskDescription"
        Me.colTaskDescription.Name = "colTaskDescription"
        Me.colTaskDescription.OptionsColumn.ReadOnly = True
        Me.colTaskDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.[Like]
        Me.colTaskDescription.Visible = True
        Me.colTaskDescription.VisibleIndex = 10
        Me.colTaskDescription.Width = 382
        '
        'TaskDescriptionRepositoryItemMemoExEdit
        '
        Me.TaskDescriptionRepositoryItemMemoExEdit.AutoHeight = False
        Me.TaskDescriptionRepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TaskDescriptionRepositoryItemMemoExEdit.Name = "TaskDescriptionRepositoryItemMemoExEdit"
        Me.TaskDescriptionRepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.TaskDescriptionRepositoryItemMemoExEdit.ShowIcon = False
        '
        'colParticipants
        '
        Me.colParticipants.ColumnEdit = Me.ParticipantsRepositoryItemMemoExEdit
        Me.colParticipants.FieldName = "Participants"
        Me.colParticipants.Name = "colParticipants"
        Me.colParticipants.OptionsColumn.ReadOnly = True
        Me.colParticipants.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.colParticipants.Visible = True
        Me.colParticipants.VisibleIndex = 3
        Me.colParticipants.Width = 167
        '
        'ParticipantsRepositoryItemMemoExEdit
        '
        Me.ParticipantsRepositoryItemMemoExEdit.AutoHeight = False
        Me.ParticipantsRepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ParticipantsRepositoryItemMemoExEdit.Name = "ParticipantsRepositoryItemMemoExEdit"
        Me.ParticipantsRepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.ParticipantsRepositoryItemMemoExEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ParticipantsRepositoryItemMemoExEdit.ShowIcon = False
        '
        'colFollowUp
        '
        Me.colFollowUp.FieldName = "FollowUp"
        Me.colFollowUp.Name = "colFollowUp"
        Me.colFollowUp.OptionsColumn.ReadOnly = True
        '
        'colResponsibleDepartment
        '
        Me.colResponsibleDepartment.ColumnEdit = Me.ResponsibleDepartmentRepositoryItemMemoExEdit
        Me.colResponsibleDepartment.FieldName = "ResponsibleDepartment"
        Me.colResponsibleDepartment.Name = "colResponsibleDepartment"
        Me.colResponsibleDepartment.OptionsColumn.ReadOnly = True
        Me.colResponsibleDepartment.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.[Like]
        Me.colResponsibleDepartment.Visible = True
        Me.colResponsibleDepartment.VisibleIndex = 7
        Me.colResponsibleDepartment.Width = 166
        '
        'ResponsibleDepartmentRepositoryItemMemoExEdit
        '
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit.AutoHeight = False
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit.Name = "ResponsibleDepartmentRepositoryItemMemoExEdit"
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.ResponsibleDepartmentRepositoryItemMemoExEdit.ShowIcon = False
        '
        'colResponsibleStaffMember
        '
        Me.colResponsibleStaffMember.ColumnEdit = Me.ResponsibleStaffMemberRepositoryItemMemoExEdit
        Me.colResponsibleStaffMember.FieldName = "ResponsibleStaffMember"
        Me.colResponsibleStaffMember.Name = "colResponsibleStaffMember"
        Me.colResponsibleStaffMember.OptionsColumn.ReadOnly = True
        Me.colResponsibleStaffMember.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.[Like]
        Me.colResponsibleStaffMember.Visible = True
        Me.colResponsibleStaffMember.VisibleIndex = 8
        Me.colResponsibleStaffMember.Width = 139
        '
        'ResponsibleStaffMemberRepositoryItemMemoExEdit
        '
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit.AutoHeight = False
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit.Name = "ResponsibleStaffMemberRepositoryItemMemoExEdit"
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 300)
        Me.ResponsibleStaffMemberRepositoryItemMemoExEdit.ShowIcon = False
        '
        'colBeginning
        '
        Me.colBeginning.FieldName = "Beginning"
        Me.colBeginning.Name = "colBeginning"
        Me.colBeginning.OptionsColumn.AllowEdit = False
        Me.colBeginning.OptionsColumn.ReadOnly = True
        Me.colBeginning.Visible = True
        Me.colBeginning.VisibleIndex = 11
        '
        'colExpectedTermination
        '
        Me.colExpectedTermination.FieldName = "ExpectedTermination"
        Me.colExpectedTermination.Name = "colExpectedTermination"
        Me.colExpectedTermination.OptionsColumn.AllowEdit = False
        Me.colExpectedTermination.OptionsColumn.ReadOnly = True
        Me.colExpectedTermination.Visible = True
        Me.colExpectedTermination.VisibleIndex = 12
        Me.colExpectedTermination.Width = 120
        '
        'colStatus
        '
        Me.colStatus.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colStatus.FieldName = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.OptionsColumn.ReadOnly = True
        Me.colStatus.Visible = True
        Me.colStatus.VisibleIndex = 4
        Me.colStatus.Width = 119
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSED", 15), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PENDING", "PENDING", 9), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("STILL PENDING", "STILL PENDING", 10), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ONGOING", "ONGOING", 12), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INFO", "INFO", 11)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colStatusText
        '
        Me.colStatusText.FieldName = "StatusText"
        Me.colStatusText.Name = "colStatusText"
        Me.colStatusText.OptionsColumn.ReadOnly = True
        '
        'colCurrentUser
        '
        Me.colCurrentUser.FieldName = "CurrentUser"
        Me.colCurrentUser.Name = "colCurrentUser"
        Me.colCurrentUser.OptionsColumn.ReadOnly = True
        '
        'GridColDaysRemain
        '
        Me.GridColDaysRemain.AppearanceCell.Options.UseTextOptions = True
        Me.GridColDaysRemain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColDaysRemain.Caption = "Days remain till expected termination"
        Me.GridColDaysRemain.FieldName = "GridColDaysRemain"
        Me.GridColDaysRemain.Name = "GridColDaysRemain"
        Me.GridColDaysRemain.OptionsColumn.AllowEdit = False
        Me.GridColDaysRemain.OptionsColumn.ReadOnly = True
        Me.GridColDaysRemain.UnboundExpression = "Iif([Status]  In ('CLOSED','INFO','ONGOING'),[Status],DateDiffDay(Today(),[Expect" & _
    "edTermination] )  )"
        Me.GridColDaysRemain.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColDaysRemain.Visible = True
        Me.GridColDaysRemain.VisibleIndex = 6
        Me.GridColDaysRemain.Width = 185
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID2, Me.layoutViewField_colStatusText2, Me.item5, Me.layoutViewField_colTaskID2, Me.layoutViewField_colMeetingDate2, Me.layoutViewField_colPriority2, Me.item6, Me.layoutViewField_colBeginning2, Me.layoutViewField_colExpectedTermination2, Me.layoutViewField_colStatus2})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'item5
        '
        Me.item5.AllowHotTrack = False
        Me.item5.CustomizationFormText = "item1"
        Me.item5.Location = New System.Drawing.Point(926, 0)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(11, 40)
        Me.item5.Text = "item1"
        Me.item5.TextSize = New System.Drawing.Size(0, 0)
        '
        'item6
        '
        Me.item6.CustomizationFormText = "item2"
        Me.item6.Location = New System.Drawing.Point(0, 40)
        Me.item6.Name = "item6"
        Me.item6.SelectedTabPage = Me.item8
        Me.item6.SelectedTabPageIndex = 0
        Me.item6.Size = New System.Drawing.Size(937, 467)
        Me.item6.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.item8, Me.item7, Me.item9, Me.item10})
        Me.item6.Text = "item2"
        '
        'item8
        '
        Me.item8.CustomizationFormText = "TASK TOPIC and DESCRIPTION"
        Me.item8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colTaskTopic2, Me.layoutViewField_colTaskDescription2})
        Me.item8.Location = New System.Drawing.Point(0, 0)
        Me.item8.Name = "item8"
        Me.item8.Size = New System.Drawing.Size(913, 421)
        Me.item8.Text = "TASK TOPIC and DESCRIPTION"
        '
        'item7
        '
        Me.item7.CustomizationFormText = "PARTICIPANTS"
        Me.item7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colParticipants2})
        Me.item7.Location = New System.Drawing.Point(0, 0)
        Me.item7.Name = "item7"
        Me.item7.Size = New System.Drawing.Size(913, 421)
        Me.item7.Text = "PARTICIPANTS"
        '
        'item9
        '
        Me.item9.CustomizationFormText = "RESPONSIBILITIES"
        Me.item9.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colResponsibleDepartment2, Me.layoutViewField_colResponsibleStaffMember2})
        Me.item9.Location = New System.Drawing.Point(0, 0)
        Me.item9.Name = "item9"
        Me.item9.Size = New System.Drawing.Size(913, 421)
        Me.item9.Text = "RESPONSIBILITIES"
        '
        'item10
        '
        Me.item10.CustomizationFormText = "FOLLOW-UP"
        Me.item10.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colFollowUp2})
        Me.item10.Location = New System.Drawing.Point(0, 0)
        Me.item10.Name = "item10"
        Me.item10.Size = New System.Drawing.Size(913, 421)
        Me.item10.Text = "FOLLOW-UP"
        '
        'PriorityComboBoxEdit
        '
        Me.PriorityComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Priority", True))
        Me.PriorityComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Priority", True))
        Me.PriorityComboBoxEdit.Location = New System.Drawing.Point(275, 38)
        Me.PriorityComboBoxEdit.Name = "PriorityComboBoxEdit"
        Me.PriorityComboBoxEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.PriorityComboBoxEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PriorityComboBoxEdit.Properties.Appearance.Options.UseFont = True
        Me.PriorityComboBoxEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.PriorityComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PriorityComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PriorityComboBoxEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PriorityComboBoxEdit.Properties.Items.AddRange(New Object() {"A", "B", "C", "INFO"})
        Me.PriorityComboBoxEdit.Properties.Sorted = True
        Me.PriorityComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.PriorityComboBoxEdit.Size = New System.Drawing.Size(69, 20)
        Me.PriorityComboBoxEdit.TabIndex = 24
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Please enter the Priority for the Meeting"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.PriorityComboBoxEdit, ConditionValidationRule1)
        '
        'MANAGEMENT_COMITEE_MEETINGTableAdapter
        '
        Me.MANAGEMENT_COMITEE_MEETINGTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.MANAGEMENT_COMITEE_MEETINGTableAdapter = Me.MANAGEMENT_COMITEE_MEETINGTableAdapter
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.ManagementDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(193, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Meeting Date"
        '
        'MeetingDateEdit
        '
        Me.MeetingDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "MeetingDate", True))
        Me.MeetingDateEdit.EditValue = New Date(2014, 6, 5, 13, 48, 34, 201)
        Me.MeetingDateEdit.Location = New System.Drawing.Point(275, 13)
        Me.MeetingDateEdit.Name = "MeetingDateEdit"
        Me.MeetingDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.MeetingDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MeetingDateEdit.Properties.Appearance.Options.UseFont = True
        Me.MeetingDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.MeetingDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MeetingDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.MeetingDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.MeetingDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.MeetingDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.MeetingDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.MeetingDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.MeetingDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MeetingDateEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.MeetingDateEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White
        Me.MeetingDateEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Navy
        Me.MeetingDateEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MeetingDateEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.MeetingDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MeetingDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.MeetingDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.MeetingDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.MeetingDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.MeetingDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.MeetingDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.MeetingDateEdit.Size = New System.Drawing.Size(107, 22)
        Me.MeetingDateEdit.TabIndex = 20
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Please enter the Meeting Date"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.MeetingDateEdit, ConditionValidationRule2)
        '
        'TaskIDLabel1
        '
        Me.TaskIDLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "TaskID", True))
        Me.TaskIDLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskIDLabel1.Location = New System.Drawing.Point(91, 18)
        Me.TaskIDLabel1.Name = "TaskIDLabel1"
        Me.TaskIDLabel1.Size = New System.Drawing.Size(100, 23)
        Me.TaskIDLabel1.TabIndex = 22
        Me.TaskIDLabel1.Text = "Label1"
        '
        'IDLabel1
        '
        Me.IDLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ID", True))
        Me.IDLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDLabel1.Location = New System.Drawing.Point(91, 41)
        Me.IDLabel1.Name = "IDLabel1"
        Me.IDLabel1.Size = New System.Drawing.Size(100, 23)
        Me.IDLabel1.TabIndex = 23
        Me.IDLabel1.Text = "Label1"
        '
        'StatusComboBoxEdit
        '
        Me.StatusComboBoxEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Status", True))
        Me.StatusComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Status", True))
        Me.StatusComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Status", True))
        Me.StatusComboBoxEdit.Location = New System.Drawing.Point(1249, 15)
        Me.StatusComboBoxEdit.Name = "StatusComboBoxEdit"
        Me.StatusComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StatusComboBoxEdit.Properties.Items.AddRange(New Object() {"PENDING", "STILL PENDING", "CLOSED"})
        Me.StatusComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.StatusComboBoxEdit.Size = New System.Drawing.Size(124, 20)
        Me.StatusComboBoxEdit.TabIndex = 27
        '
        'StatusTextlbl
        '
        Me.StatusTextlbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusTextlbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "StatusText", True))
        Me.StatusTextlbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.StatusTextlbl.ForeColor = System.Drawing.Color.Yellow
        Me.StatusTextlbl.Location = New System.Drawing.Point(1035, 41)
        Me.StatusTextlbl.Name = "StatusTextlbl"
        Me.StatusTextlbl.Size = New System.Drawing.Size(338, 23)
        Me.StatusTextlbl.TabIndex = 28
        Me.StatusTextlbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.SingleTaskReport_btn)
        Me.LayoutControl1.Controls.Add(Me.XtraTabControl1)
        Me.LayoutControl1.Controls.Add(Me.PopupContainerEdit1)
        Me.LayoutControl1.Controls.Add(Me.Save_Changes_btn)
        Me.LayoutControl1.Controls.Add(Me.ShowAllMeetings_btn)
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(12, 67)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(420, 102, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1375, 678)
        Me.LayoutControl1.TabIndex = 29
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SingleTaskReport_btn
        '
        Me.SingleTaskReport_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SingleTaskReport_btn.ImageOptions.ImageIndex = 7
        Me.SingleTaskReport_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.SingleTaskReport_btn.Location = New System.Drawing.Point(108, 24)
        Me.SingleTaskReport_btn.Name = "SingleTaskReport_btn"
        Me.SingleTaskReport_btn.Size = New System.Drawing.Size(155, 22)
        Me.SingleTaskReport_btn.StyleController = Me.LayoutControl1
        Me.SingleTaskReport_btn.TabIndex = 32
        Me.SingleTaskReport_btn.Text = "Create Single Task Report"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(24, 50)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.TASKTOPICXtraTabPage
        Me.XtraTabControl1.Size = New System.Drawing.Size(1327, 604)
        Me.XtraTabControl1.TabIndex = 10
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TASKTOPICXtraTabPage, Me.TASKDESCRIPTIONXtraTabPage, Me.PARTICIPANTSXtraTabPage, Me.TASKSCHEDULEXtraTabPage, Me.FOLLOWUPXtraTabPage})
        '
        'TASKTOPICXtraTabPage
        '
        Me.TASKTOPICXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TASKTOPICXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.TASKTOPICXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.TASKTOPICXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.TASKTOPICXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.TASKTOPICXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.TASKTOPICXtraTabPage.Controls.Add(Me.TaskTopicMemoEdit)
        Me.TASKTOPICXtraTabPage.Name = "TASKTOPICXtraTabPage"
        Me.TASKTOPICXtraTabPage.Size = New System.Drawing.Size(1321, 576)
        Me.TASKTOPICXtraTabPage.Text = "TASK TOPIC"
        '
        'TaskTopicMemoEdit
        '
        Me.TaskTopicMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "TaskTopic", True))
        Me.TaskTopicMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "TaskTopic", True))
        Me.TaskTopicMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskTopicMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.TaskTopicMemoEdit.Name = "TaskTopicMemoEdit"
        Me.TaskTopicMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskTopicMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.TaskTopicMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TaskTopicMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TaskTopicMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TaskTopicMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TaskTopicMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.TaskTopicMemoEdit, True)
        Me.TaskTopicMemoEdit.Size = New System.Drawing.Size(1321, 576)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.TaskTopicMemoEdit, OptionsSpelling1)
        Me.TaskTopicMemoEdit.TabIndex = 0
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Please enter the Task Topic"
        ConditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.TaskTopicMemoEdit, ConditionValidationRule3)
        '
        'TASKDESCRIPTIONXtraTabPage
        '
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.TASKDESCRIPTIONXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.TASKDESCRIPTIONXtraTabPage.Controls.Add(Me.TaskDescriptionMemoEdit)
        Me.TASKDESCRIPTIONXtraTabPage.Name = "TASKDESCRIPTIONXtraTabPage"
        Me.TASKDESCRIPTIONXtraTabPage.Size = New System.Drawing.Size(1321, 576)
        Me.TASKDESCRIPTIONXtraTabPage.Text = "TASK DESCRIPTION"
        '
        'TaskDescriptionMemoEdit
        '
        Me.TaskDescriptionMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "TaskDescription", True))
        Me.TaskDescriptionMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "TaskDescription", True))
        Me.TaskDescriptionMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskDescriptionMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.TaskDescriptionMemoEdit.Name = "TaskDescriptionMemoEdit"
        Me.TaskDescriptionMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescriptionMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.TaskDescriptionMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TaskDescriptionMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TaskDescriptionMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.TaskDescriptionMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.TaskDescriptionMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.TaskDescriptionMemoEdit, True)
        Me.TaskDescriptionMemoEdit.Size = New System.Drawing.Size(1321, 576)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.TaskDescriptionMemoEdit, OptionsSpelling2)
        Me.TaskDescriptionMemoEdit.TabIndex = 1
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule4.ErrorText = "Please enter the Task description"
        ConditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.TaskDescriptionMemoEdit, ConditionValidationRule4)
        '
        'PARTICIPANTSXtraTabPage
        '
        Me.PARTICIPANTSXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTICIPANTSXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.PARTICIPANTSXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.PARTICIPANTSXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.PARTICIPANTSXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.PARTICIPANTSXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.PARTICIPANTSXtraTabPage.Controls.Add(Me.ParticipantsMemoEdit)
        Me.PARTICIPANTSXtraTabPage.Name = "PARTICIPANTSXtraTabPage"
        Me.PARTICIPANTSXtraTabPage.Size = New System.Drawing.Size(1321, 576)
        Me.PARTICIPANTSXtraTabPage.Text = "PARTICIPANTS"
        '
        'ParticipantsMemoEdit
        '
        Me.ParticipantsMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Participants", True))
        Me.ParticipantsMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Participants", True))
        Me.ParticipantsMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParticipantsMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.ParticipantsMemoEdit.Name = "ParticipantsMemoEdit"
        Me.ParticipantsMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParticipantsMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.ParticipantsMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ParticipantsMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ParticipantsMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ParticipantsMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ParticipantsMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.ParticipantsMemoEdit, True)
        Me.ParticipantsMemoEdit.Size = New System.Drawing.Size(1321, 576)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.ParticipantsMemoEdit, OptionsSpelling3)
        Me.ParticipantsMemoEdit.TabIndex = 1
        '
        'TASKSCHEDULEXtraTabPage
        '
        Me.TASKSCHEDULEXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TASKSCHEDULEXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.TASKSCHEDULEXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.TASKSCHEDULEXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.TASKSCHEDULEXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.TASKSCHEDULEXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.GroupControl2)
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.GroupControl1)
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.LabelControl3)
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.ExpectedTerminationDateEdit)
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.LabelControl2)
        Me.TASKSCHEDULEXtraTabPage.Controls.Add(Me.BeginningDateEdit)
        Me.TASKSCHEDULEXtraTabPage.Name = "TASKSCHEDULEXtraTabPage"
        Me.TASKSCHEDULEXtraTabPage.Size = New System.Drawing.Size(1321, 576)
        Me.TASKSCHEDULEXtraTabPage.Text = "TASK SCHEDULE and RESPONSIBLES"
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl2.Controls.Add(Me.ResponsibleStaffMemberMemoEdit)
        Me.GroupControl2.Location = New System.Drawing.Point(684, 71)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(624, 502)
        Me.GroupControl2.TabIndex = 27
        Me.GroupControl2.Text = "Responsible Staff Member"
        '
        'ResponsibleStaffMemberMemoEdit
        '
        Me.ResponsibleStaffMemberMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ResponsibleStaffMember", True))
        Me.ResponsibleStaffMemberMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ResponsibleStaffMember", True))
        Me.ResponsibleStaffMemberMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResponsibleStaffMemberMemoEdit.Location = New System.Drawing.Point(2, 20)
        Me.ResponsibleStaffMemberMemoEdit.Name = "ResponsibleStaffMemberMemoEdit"
        Me.ResponsibleStaffMemberMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResponsibleStaffMemberMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.ResponsibleStaffMemberMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ResponsibleStaffMemberMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ResponsibleStaffMemberMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ResponsibleStaffMemberMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ResponsibleStaffMemberMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.ResponsibleStaffMemberMemoEdit, True)
        Me.ResponsibleStaffMemberMemoEdit.Size = New System.Drawing.Size(620, 480)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.ResponsibleStaffMemberMemoEdit, OptionsSpelling4)
        Me.ResponsibleStaffMemberMemoEdit.TabIndex = 2
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.ResponsibleDepartmentMemoEdit)
        Me.GroupControl1.Location = New System.Drawing.Point(11, 71)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(617, 502)
        Me.GroupControl1.TabIndex = 26
        Me.GroupControl1.Text = "Responsible Department"
        '
        'ResponsibleDepartmentMemoEdit
        '
        Me.ResponsibleDepartmentMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ResponsibleDepartment", True))
        Me.ResponsibleDepartmentMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ResponsibleDepartment", True))
        Me.ResponsibleDepartmentMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResponsibleDepartmentMemoEdit.Location = New System.Drawing.Point(2, 20)
        Me.ResponsibleDepartmentMemoEdit.Name = "ResponsibleDepartmentMemoEdit"
        Me.ResponsibleDepartmentMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResponsibleDepartmentMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.ResponsibleDepartmentMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ResponsibleDepartmentMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ResponsibleDepartmentMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ResponsibleDepartmentMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ResponsibleDepartmentMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.ResponsibleDepartmentMemoEdit, True)
        Me.ResponsibleDepartmentMemoEdit.Size = New System.Drawing.Size(613, 480)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.ResponsibleDepartmentMemoEdit, OptionsSpelling5)
        Me.ResponsibleDepartmentMemoEdit.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(446, 50)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(154, 13)
        Me.LabelControl3.TabIndex = 25
        Me.LabelControl3.Text = "Expected Termination Date"
        '
        'ExpectedTerminationDateEdit
        '
        Me.ExpectedTerminationDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ExpectedTerminationDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "ExpectedTermination", True))
        Me.ExpectedTerminationDateEdit.EditValue = Nothing
        Me.ExpectedTerminationDateEdit.Location = New System.Drawing.Point(606, 45)
        Me.ExpectedTerminationDateEdit.Name = "ExpectedTerminationDateEdit"
        Me.ExpectedTerminationDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExpectedTerminationDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ExpectedTerminationDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ExpectedTerminationDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ExpectedTerminationDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.ExpectedTerminationDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExpectedTerminationDateEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.ExpectedTerminationDateEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White
        Me.ExpectedTerminationDateEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Navy
        Me.ExpectedTerminationDateEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.ExpectedTerminationDateEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.ExpectedTerminationDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExpectedTerminationDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ExpectedTerminationDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.ExpectedTerminationDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ExpectedTerminationDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.ExpectedTerminationDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ExpectedTerminationDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.ExpectedTerminationDateEdit.Size = New System.Drawing.Size(107, 22)
        Me.ExpectedTerminationDateEdit.TabIndex = 24
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(515, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "Beginning Date"
        '
        'BeginningDateEdit
        '
        Me.BeginningDateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BeginningDateEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "Beginning", True))
        Me.BeginningDateEdit.EditValue = Nothing
        Me.BeginningDateEdit.Location = New System.Drawing.Point(606, 17)
        Me.BeginningDateEdit.Name = "BeginningDateEdit"
        Me.BeginningDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BeginningDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BeginningDateEdit.Properties.Appearance.Options.UseFont = True
        Me.BeginningDateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.BeginningDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BeginningDateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BeginningDateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BeginningDateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BeginningDateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.BeginningDateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.BeginningDateEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.BeginningDateEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BeginningDateEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.BeginningDateEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White
        Me.BeginningDateEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Navy
        Me.BeginningDateEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.BeginningDateEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.BeginningDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BeginningDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BeginningDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.BeginningDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BeginningDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy"
        Me.BeginningDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BeginningDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy"
        Me.BeginningDateEdit.Size = New System.Drawing.Size(107, 22)
        Me.BeginningDateEdit.TabIndex = 22
        CompareAgainstControlValidationRule1.CaseSensitive = True
        CompareAgainstControlValidationRule1.Control = Me.PriorityComboBoxEdit
        CompareAgainstControlValidationRule1.ErrorText = "Please enter the Beginning Date"
        CompareAgainstControlValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.BeginningDateEdit, CompareAgainstControlValidationRule1)
        '
        'FOLLOWUPXtraTabPage
        '
        Me.FOLLOWUPXtraTabPage.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOLLOWUPXtraTabPage.Appearance.Header.Options.UseFont = True
        Me.FOLLOWUPXtraTabPage.Appearance.HeaderActive.BackColor = System.Drawing.Color.Yellow
        Me.FOLLOWUPXtraTabPage.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Yellow
        Me.FOLLOWUPXtraTabPage.Appearance.HeaderActive.Options.UseBackColor = True
        Me.FOLLOWUPXtraTabPage.Appearance.HeaderActive.Options.UseForeColor = True
        Me.FOLLOWUPXtraTabPage.Controls.Add(Me.UpdateFollowUp_btn)
        Me.FOLLOWUPXtraTabPage.Controls.Add(Me.GroupControl4)
        Me.FOLLOWUPXtraTabPage.Controls.Add(Me.GroupControl3)
        Me.FOLLOWUPXtraTabPage.Name = "FOLLOWUPXtraTabPage"
        Me.FOLLOWUPXtraTabPage.Size = New System.Drawing.Size(1321, 576)
        Me.FOLLOWUPXtraTabPage.Text = "FOLLOW UP"
        '
        'UpdateFollowUp_btn
        '
        Me.UpdateFollowUp_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdateFollowUp_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateFollowUp_btn.ImageOptions.ImageIndex = 5
        Me.UpdateFollowUp_btn.Location = New System.Drawing.Point(1147, 549)
        Me.UpdateFollowUp_btn.Name = "UpdateFollowUp_btn"
        Me.UpdateFollowUp_btn.Size = New System.Drawing.Size(169, 22)
        Me.UpdateFollowUp_btn.StyleController = Me.LayoutControl1
        Me.UpdateFollowUp_btn.TabIndex = 29
        Me.UpdateFollowUp_btn.Text = "Update Follow-Up"
        '
        'GroupControl4
        '
        Me.GroupControl4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl4.Controls.Add(Me.FollowUpUpdateMemoEdit)
        Me.GroupControl4.Location = New System.Drawing.Point(647, 18)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(671, 525)
        Me.GroupControl4.TabIndex = 28
        Me.GroupControl4.Text = "Follow-up Update"
        '
        'FollowUpUpdateMemoEdit
        '
        Me.FollowUpUpdateMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FollowUpUpdateMemoEdit.Location = New System.Drawing.Point(2, 20)
        Me.FollowUpUpdateMemoEdit.Name = "FollowUpUpdateMemoEdit"
        Me.FollowUpUpdateMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FollowUpUpdateMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.FollowUpUpdateMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FollowUpUpdateMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FollowUpUpdateMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FollowUpUpdateMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FollowUpUpdateMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.FollowUpUpdateMemoEdit, True)
        Me.FollowUpUpdateMemoEdit.Size = New System.Drawing.Size(667, 503)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.FollowUpUpdateMemoEdit, OptionsSpelling6)
        Me.FollowUpUpdateMemoEdit.TabIndex = 2
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.FollowUpMemoEdit)
        Me.GroupControl3.Location = New System.Drawing.Point(3, 18)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(638, 555)
        Me.GroupControl3.TabIndex = 27
        Me.GroupControl3.Text = "Follow-Up"
        '
        'FollowUpMemoEdit
        '
        Me.FollowUpMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "FollowUp", True))
        Me.FollowUpMemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MANAGEMENT_COMITEE_MEETINGBindingSource, "FollowUp", True))
        Me.FollowUpMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FollowUpMemoEdit.Location = New System.Drawing.Point(2, 20)
        Me.FollowUpMemoEdit.Name = "FollowUpMemoEdit"
        Me.FollowUpMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FollowUpMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.FollowUpMemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FollowUpMemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FollowUpMemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FollowUpMemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FollowUpMemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FollowUpMemoEdit.Properties.ReadOnly = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.FollowUpMemoEdit, True)
        Me.FollowUpMemoEdit.Size = New System.Drawing.Size(634, 533)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.FollowUpMemoEdit, OptionsSpelling7)
        Me.FollowUpMemoEdit.TabIndex = 2
        '
        'PopupContainerEdit1
        '
        Me.PopupContainerEdit1.Location = New System.Drawing.Point(111, 62)
        Me.PopupContainerEdit1.Name = "PopupContainerEdit1"
        Me.PopupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit1.Size = New System.Drawing.Size(50, 20)
        Me.PopupContainerEdit1.StyleController = Me.LayoutControl1
        Me.PopupContainerEdit1.TabIndex = 8
        '
        'Save_Changes_btn
        '
        Me.Save_Changes_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_Changes_btn.ImageOptions.ImageIndex = 13
        Me.Save_Changes_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Save_Changes_btn.Location = New System.Drawing.Point(24, 24)
        Me.Save_Changes_btn.Name = "Save_Changes_btn"
        Me.Save_Changes_btn.Size = New System.Drawing.Size(80, 22)
        Me.Save_Changes_btn.StyleController = Me.LayoutControl1
        Me.Save_Changes_btn.TabIndex = 6
        Me.Save_Changes_btn.Text = "Save"
        '
        'ShowAllMeetings_btn
        '
        Me.ShowAllMeetings_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowAllMeetings_btn.ImageOptions.ImageIndex = 0
        Me.ShowAllMeetings_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.ShowAllMeetings_btn.Location = New System.Drawing.Point(1190, 24)
        Me.ShowAllMeetings_btn.Name = "ShowAllMeetings_btn"
        Me.ShowAllMeetings_btn.Size = New System.Drawing.Size(161, 22)
        Me.ShowAllMeetings_btn.StyleController = Me.LayoutControl1
        Me.ShowAllMeetings_btn.TabIndex = 4
        Me.ShowAllMeetings_btn.Text = "Back to all Meetings"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PopupContainerEdit1
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(153, 649)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1375, 678)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1355, 658)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ShowAllMeetings_btn
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1166, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(165, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(243, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(923, 26)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Save_Changes_btn
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(84, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.XtraTabControl1
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1331, 608)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SingleTaskReport_btn
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(84, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(159, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1, Me.PrintableComponentLink2})
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
        Me.PrintableComponentLink2.Component = Me.LayoutControl1
        Me.PrintableComponentLink2.Landscape = True
        Me.PrintableComponentLink2.PaperKind = System.Drawing.Printing.PaperKind.A3
        Me.PrintableComponentLink2.PrintingSystemBase = Me.PrintingSystem1
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'Statuslbl
        '
        Me.Statuslbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Statuslbl.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Statuslbl.ForeColor = System.Drawing.Color.Yellow
        Me.Statuslbl.Location = New System.Drawing.Point(451, 12)
        Me.Statuslbl.Name = "Statuslbl"
        Me.Statuslbl.Size = New System.Drawing.Size(556, 23)
        Me.Statuslbl.TabIndex = 31
        Me.Statuslbl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SpellChecker1
        '
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerISpellDictionary1.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
        SpellCheckerISpellDictionary1.CacheKey = Nothing
        SpellCheckerISpellDictionary1.Culture = New System.Globalization.CultureInfo("en-US")
        SpellCheckerISpellDictionary1.DictionaryPath = "Dictionaries\american.xlg"
        SpellCheckerISpellDictionary1.Encoding = System.Text.Encoding.GetEncoding(850)
        SpellCheckerISpellDictionary1.GrammarPath = "Dictionaries\english.aff"
        SpellCheckerCustomDictionary1.AlphabetPath = "Dictionaries\EnglishAlphabet.txt"
        SpellCheckerCustomDictionary1.CacheKey = Nothing
        SpellCheckerCustomDictionary1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerCustomDictionary1.DictionaryPath = "Dictionaries\CustomEnglish.dic"
        SpellCheckerCustomDictionary1.Encoding = System.Text.Encoding.GetEncoding(850)
        Me.SpellChecker1.Dictionaries.Add(SpellCheckerISpellDictionary1)
        Me.SpellChecker1.Dictionaries.Add(SpellCheckerCustomDictionary1)
        Me.SpellChecker1.ParentContainer = Nothing
        Me.SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        '
        'ManagementMeetings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1385, 793)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.StatusTextlbl)
        Me.Controls.Add(Me.StatusComboBoxEdit)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.PriorityComboBoxEdit)
        Me.Controls.Add(IDLabel)
        Me.Controls.Add(Me.IDLabel1)
        Me.Controls.Add(TaskIDLabel)
        Me.Controls.Add(Me.TaskIDLabel1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MeetingDateEdit)
        Me.Controls.Add(Me.Statuslbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ManagementMeetings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Management Commitee Meetings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ManagementMeetings_LayoutView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMeetingDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTaskID2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPriority2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GeneralRepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTaskTopic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colTaskDescription2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colParticipants2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colFollowUp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colResponsibleDepartment2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colResponsibleStaffMember2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colBeginning2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colExpectedTermination2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStatus2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colStatusText2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrentUser2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANAGEMENT_COMITEE_MEETINGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManagementDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManagementMeetings_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaskTopicRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaskDescriptionRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParticipantsRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResponsibleDepartmentRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResponsibleStaffMemberRepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PriorityComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeetingDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeetingDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TASKTOPICXtraTabPage.ResumeLayout(False)
        CType(Me.TaskTopicMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TASKDESCRIPTIONXtraTabPage.ResumeLayout(False)
        CType(Me.TaskDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PARTICIPANTSXtraTabPage.ResumeLayout(False)
        CType(Me.ParticipantsMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TASKSCHEDULEXtraTabPage.ResumeLayout(False)
        Me.TASKSCHEDULEXtraTabPage.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.ResponsibleStaffMemberMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.ResponsibleDepartmentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpectedTerminationDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpectedTerminationDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeginningDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeginningDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FOLLOWUPXtraTabPage.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.FollowUpUpdateMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.FollowUpMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ManagementDataset As PS_TOOL_DX.ManagementDataset
    Friend WithEvents MANAGEMENT_COMITEE_MEETINGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MANAGEMENT_COMITEE_MEETINGTableAdapter As PS_TOOL_DX.ManagementDatasetTableAdapters.MANAGEMENT_COMITEE_MEETINGTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.ManagementDatasetTableAdapters.TableAdapterManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MeetingDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TaskIDLabel1 As System.Windows.Forms.Label
    Friend WithEvents IDLabel1 As System.Windows.Forms.Label
    Friend WithEvents PriorityComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents StatusComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents StatusTextlbl As System.Windows.Forms.Label
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PopupContainerEdit1 As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents Save_Changes_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ShowAllMeetings_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ManagementMeetings_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TASKTOPICXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TaskTopicMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TASKDESCRIPTIONXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TaskDescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PARTICIPANTSXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ParticipantsMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TASKSCHEDULEXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents FOLLOWUPXtraTabPage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ResponsibleStaffMemberMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ResponsibleDepartmentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ExpectedTerminationDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BeginningDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents UpdateFollowUp_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents FollowUpUpdateMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents FollowUpMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeetingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTaskID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPriority As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTaskTopic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTaskDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colParticipants As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFollowUp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colResponsibleDepartment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colResponsibleStaffMember As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBeginning As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colExpectedTermination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrentUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents GridColDaysRemain As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TaskTopicRepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents TaskDescriptionRepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ParticipantsRepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ResponsibleDepartmentRepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ResponsibleStaffMemberRepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents ManagementMeetings_LayoutView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colMeetingDate1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTaskID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colPriority1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTaskTopic1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colTaskDescription1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colParticipants1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colFollowUp1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colResponsibleDepartment1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colResponsibleStaffMember1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colBeginning1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colExpectedTermination1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colStatusText1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colCurrentUser1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents GeneralRepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PrintableComponentLink2 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents Statuslbl As System.Windows.Forms.Label
    Friend WithEvents layoutViewField_colID2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colMeetingDate2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTaskID2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colPriority2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTaskTopic2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colTaskDescription2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colParticipants2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colFollowUp2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colResponsibleDepartment2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colResponsibleStaffMember2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colBeginning2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colExpectedTermination2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStatus2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colStatusText2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_colCurrentUser2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents item5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents item6 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents item8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents item7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents item9 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents item10 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SingleTaskReport_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
End Class
