<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LayoutTemplates
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LayoutTemplates))
        Me.EurRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.Files_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFilename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilepath = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilename_Full = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ContractStatus_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.Relevant_RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.NummericRepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.FileName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ReportingDate_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.FileFullPath_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.EurRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Files_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Relevant_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NummericRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileFullPath_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EurRepositoryItemTextEdit1
        '
        Me.EurRepositoryItemTextEdit1.AutoHeight = False
        Me.EurRepositoryItemTextEdit1.DisplayFormat.FormatString = "c2"
        Me.EurRepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.EurRepositoryItemTextEdit1.Name = "EurRepositoryItemTextEdit1"
        '
        'AbacusFilesRecreationLayoutControl1ConvertedLayout
        '
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.GridControl1)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.FileName_TextEdit)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.FileFullPath_TextEdit)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Name = "AbacusFilesRecreationLayoutControl1ConvertedLayout"
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Size = New System.Drawing.Size(610, 450)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.TabIndex = 1
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(12, 22)
        Me.GridControl1.MainView = Me.Files_GridView
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemMemoEdit1, Me.ContractStatus_RepositoryItemImageComboBox, Me.Relevant_RepositoryItemImageComboBox, Me.NummericRepositoryItemTextEdit1, Me.EurRepositoryItemTextEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(586, 352)
        Me.GridControl1.TabIndex = 9
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Files_GridView})
        '
        'Files_GridView
        '
        Me.Files_GridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Files_GridView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Files_GridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.Files_GridView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.Files_GridView.Appearance.FocusedCell.Options.UseForeColor = True
        Me.Files_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Files_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Files_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Files_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Files_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Files_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFilename, Me.colFilepath, Me.colFilename_Full})
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue1.Value1 = 0R
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue2.Value1 = 0R
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.Files_GridView.FormatRules.Add(GridFormatRule1)
        Me.Files_GridView.FormatRules.Add(GridFormatRule2)
        Me.Files_GridView.GridControl = Me.GridControl1
        Me.Files_GridView.Name = "Files_GridView"
        Me.Files_GridView.NewItemRowText = "Add new Temp Client"
        Me.Files_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Files_GridView.OptionsBehavior.Editable = False
        Me.Files_GridView.OptionsBehavior.ReadOnly = True
        Me.Files_GridView.OptionsCustomization.AllowGroup = False
        Me.Files_GridView.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.Files_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Files_GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.Files_GridView.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.[True]
        Me.Files_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Files_GridView.OptionsFind.AlwaysVisible = True
        Me.Files_GridView.OptionsMenu.EnableColumnMenu = False
        Me.Files_GridView.OptionsMenu.EnableFooterMenu = False
        Me.Files_GridView.OptionsMenu.EnableGroupPanelMenu = False
        Me.Files_GridView.OptionsPrint.PrintDetails = True
        Me.Files_GridView.OptionsSelection.MultiSelect = True
        Me.Files_GridView.OptionsView.ColumnAutoWidth = False
        Me.Files_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Files_GridView.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Text
        Me.Files_GridView.OptionsView.ShowColumnHeaders = False
        Me.Files_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Files_GridView.OptionsView.ShowGroupPanel = False
        Me.Files_GridView.OptionsView.ShowIndicator = False
        Me.Files_GridView.OptionsView.ShowViewCaption = True
        '
        'colFilename
        '
        Me.colFilename.AppearanceCell.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.colFilename.AppearanceCell.Options.UseFont = True
        Me.colFilename.Caption = "Report Template"
        Me.colFilename.FieldName = "Filename"
        Me.colFilename.Name = "colFilename"
        Me.colFilename.OptionsColumn.ReadOnly = True
        Me.colFilename.Visible = True
        Me.colFilename.VisibleIndex = 0
        Me.colFilename.Width = 548
        '
        'colFilepath
        '
        Me.colFilepath.AppearanceCell.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.colFilepath.AppearanceCell.Options.UseFont = True
        Me.colFilepath.AppearanceHeader.Options.UseTextOptions = True
        Me.colFilepath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFilepath.Caption = "Filepath"
        Me.colFilepath.FieldName = "Filepath"
        Me.colFilepath.Name = "colFilepath"
        Me.colFilepath.OptionsColumn.ReadOnly = True
        Me.colFilepath.Width = 464
        '
        'colFilename_Full
        '
        Me.colFilename_Full.Caption = "Filename_Full"
        Me.colFilename_Full.FieldName = "Filename_Full"
        Me.colFilename_Full.Name = "colFilename_Full"
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "ACTIV", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "CLOSE", 6)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ContractStatus_RepositoryItemImageComboBox
        '
        Me.ContractStatus_RepositoryItemImageComboBox.AutoHeight = False
        Me.ContractStatus_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractStatus_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "A", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("MATURED", "M", 6)})
        Me.ContractStatus_RepositoryItemImageComboBox.Name = "ContractStatus_RepositoryItemImageComboBox"
        '
        'Relevant_RepositoryItemImageComboBox
        '
        Me.Relevant_RepositoryItemImageComboBox.AutoHeight = False
        Me.Relevant_RepositoryItemImageComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Relevant_RepositoryItemImageComboBox.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 5), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNDEFINED", "U", 12)})
        Me.Relevant_RepositoryItemImageComboBox.Name = "Relevant_RepositoryItemImageComboBox"
        '
        'NummericRepositoryItemTextEdit1
        '
        Me.NummericRepositoryItemTextEdit1.AutoHeight = False
        Me.NummericRepositoryItemTextEdit1.DisplayFormat.FormatString = "n2"
        Me.NummericRepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NummericRepositoryItemTextEdit1.Name = "NummericRepositoryItemTextEdit1"
        '
        'FileName_TextEdit
        '
        Me.FileName_TextEdit.Location = New System.Drawing.Point(12, 378)
        Me.FileName_TextEdit.Name = "FileName_TextEdit"
        Me.FileName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.FileName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.FileName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.FileName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.FileName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.FileName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.FileName_TextEdit.Size = New System.Drawing.Size(586, 24)
        Me.FileName_TextEdit.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.FileName_TextEdit.TabIndex = 10
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(610, 450)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 10)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(590, 356)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 420)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(590, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.EmptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(590, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.FileName_TextEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 366)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(590, 28)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'ReportingDate_BarEditItem
        '
        Me.ReportingDate_BarEditItem.Caption = "Reporting Date"
        Me.ReportingDate_BarEditItem.Edit = Nothing
        Me.ReportingDate_BarEditItem.EditWidth = 160
        Me.ReportingDate_BarEditItem.Id = 4
        Me.ReportingDate_BarEditItem.ImageOptions.Image = CType(resources.GetObject("ReportingDate_BarEditItem.ImageOptions.Image"), System.Drawing.Image)
        Me.ReportingDate_BarEditItem.ImageOptions.LargeImage = CType(resources.GetObject("ReportingDate_BarEditItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ReportingDate_BarEditItem.ItemAppearance.Normal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportingDate_BarEditItem.ItemAppearance.Normal.Options.UseFont = True
        Me.ReportingDate_BarEditItem.Name = "ReportingDate_BarEditItem"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "Reporting Date"
        Me.BarEditItem1.Edit = Nothing
        Me.BarEditItem1.EditWidth = 160
        Me.BarEditItem1.Id = 4
        Me.BarEditItem1.ImageOptions.Image = CType(resources.GetObject("BarEditItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarEditItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarEditItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarEditItem1.ItemAppearance.Normal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEditItem1.ItemAppearance.Normal.Options.UseFont = True
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'FileFullPath_TextEdit
        '
        Me.FileFullPath_TextEdit.Location = New System.Drawing.Point(12, 406)
        Me.FileFullPath_TextEdit.Name = "FileFullPath_TextEdit"
        Me.FileFullPath_TextEdit.Size = New System.Drawing.Size(586, 22)
        Me.FileFullPath_TextEdit.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.FileFullPath_TextEdit.TabIndex = 11
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.FileFullPath_TextEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 394)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(590, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout)
        Me.Name = "LayoutTemplates"
        Me.Size = New System.Drawing.Size(610, 450)
        CType(Me.EurRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Files_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractStatus_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Relevant_RepositoryItemImageComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NummericRepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileFullPath_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportingDate_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents AbacusFilesRecreationLayoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Files_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colFilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilepath As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EurRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ContractStatus_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents Relevant_RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents NummericRepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents FileName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFilename_Full As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FileFullPath_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
