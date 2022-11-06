<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZvStatistic_NewReportingPeriod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZvStatistic_NewReportingPeriod))
        Me.ZvMeldeschemas_SearchLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ZvMeldeschema_GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ZvMeldeschemaDescription_GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.ZvMeldejahr_DateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.ZvMeldeperiod_ComboboxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SearchLookUpEdit1item = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ReportingDate_BarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        CType(Me.ZvMeldeschemas_SearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvMeldejahr_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvMeldejahr_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZvMeldeperiod_ComboboxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1item, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ZvMeldeschemas_SearchLookUpEdit
        '
        Me.ZvMeldeschemas_SearchLookUpEdit.EditValue = ""
        Me.ZvMeldeschemas_SearchLookUpEdit.Location = New System.Drawing.Point(12, 226)
        Me.ZvMeldeschemas_SearchLookUpEdit.Name = "ZvMeldeschemas_SearchLookUpEdit"
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(300, 250)
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.ShowClearButton = False
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.ShowFooter = False
        Me.ZvMeldeschemas_SearchLookUpEdit.Size = New System.Drawing.Size(151, 20)
        Me.ZvMeldeschemas_SearchLookUpEdit.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.ZvMeldeschemas_SearchLookUpEdit.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ZvMeldeschema_GridColumn, Me.ZvMeldeschemaDescription_GridColumn})
        Me.SearchLookUpEdit1View.DetailHeight = 150
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsFind.ShowClearButton = False
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ColumnAutoWidth = False
        Me.SearchLookUpEdit1View.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'ZvMeldeschema_GridColumn
        '
        Me.ZvMeldeschema_GridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.ZvMeldeschema_GridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ZvMeldeschema_GridColumn.AppearanceHeader.Options.UseTextOptions = True
        Me.ZvMeldeschema_GridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ZvMeldeschema_GridColumn.Caption = "ZV Meldeschema"
        Me.ZvMeldeschema_GridColumn.FieldName = "ZV_MELDESCHEMA"
        Me.ZvMeldeschema_GridColumn.MinWidth = 17
        Me.ZvMeldeschema_GridColumn.Name = "ZvMeldeschema_GridColumn"
        Me.ZvMeldeschema_GridColumn.Visible = True
        Me.ZvMeldeschema_GridColumn.VisibleIndex = 0
        Me.ZvMeldeschema_GridColumn.Width = 147
        '
        'ZvMeldeschemaDescription_GridColumn
        '
        Me.ZvMeldeschemaDescription_GridColumn.Caption = "Period"
        Me.ZvMeldeschemaDescription_GridColumn.FieldName = "ZV_MELDESCHEMA_DESCRIPTION"
        Me.ZvMeldeschemaDescription_GridColumn.Name = "ZvMeldeschemaDescription_GridColumn"
        Me.ZvMeldeschemaDescription_GridColumn.Visible = True
        Me.ZvMeldeschemaDescription_GridColumn.VisibleIndex = 1
        '
        'AbacusFilesRecreationLayoutControl1ConvertedLayout
        '
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.PictureEdit1)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.ProgressPanel1)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.ZvMeldeschemas_SearchLookUpEdit)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.ZvMeldejahr_DateEdit)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Controls.Add(Me.ZvMeldeperiod_ComboboxEdit)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Location = New System.Drawing.Point(0, 0)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Name = "AbacusFilesRecreationLayoutControl1ConvertedLayout"
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(454, 0, 650, 400)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Root = Me.LayoutControlGroup1
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.Size = New System.Drawing.Size(407, 278)
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.TabIndex = 1
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(12, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(383, 192)
        Me.PictureEdit1.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.PictureEdit1.TabIndex = 8
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.Navy
        Me.ProgressPanel1.AppearanceCaption.Options.UseFont = True
        Me.ProgressPanel1.AppearanceCaption.Options.UseForeColor = True
        Me.ProgressPanel1.Location = New System.Drawing.Point(12, 250)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(383, 16)
        Me.ProgressPanel1.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.ProgressPanel1.TabIndex = 7
        Me.ProgressPanel1.Text = "ProgressPanel1"
        Me.ProgressPanel1.Visible = False
        '
        'ZvMeldejahr_DateEdit
        '
        Me.ZvMeldejahr_DateEdit.EditValue = Nothing
        Me.ZvMeldejahr_DateEdit.Location = New System.Drawing.Point(304, 226)
        Me.ZvMeldejahr_DateEdit.Name = "ZvMeldejahr_DateEdit"
        Me.ZvMeldejahr_DateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.ZvMeldejahr_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ZvMeldejahr_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ZvMeldejahr_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZvMeldejahr_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZvMeldejahr_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZvMeldejahr_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ZvMeldejahr_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ZvMeldejahr_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ZvMeldejahr_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ZvMeldejahr_DateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.ZvMeldejahr_DateEdit.Properties.DisplayFormat.FormatString = "yyyy"
        Me.ZvMeldejahr_DateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ZvMeldejahr_DateEdit.Properties.EditFormat.FormatString = "yyyy"
        Me.ZvMeldejahr_DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ZvMeldejahr_DateEdit.Properties.Mask.EditMask = "\d{4}"
        Me.ZvMeldejahr_DateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.ZvMeldejahr_DateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ZvMeldejahr_DateEdit.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.ZvMeldejahr_DateEdit.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.ZvMeldejahr_DateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.ZvMeldejahr_DateEdit.Size = New System.Drawing.Size(91, 20)
        Me.ZvMeldejahr_DateEdit.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.ZvMeldejahr_DateEdit.TabIndex = 10
        '
        'ZvMeldeperiod_ComboboxEdit
        '
        Me.ZvMeldeperiod_ComboboxEdit.Location = New System.Drawing.Point(167, 226)
        Me.ZvMeldeperiod_ComboboxEdit.Name = "ZvMeldeperiod_ComboboxEdit"
        Me.ZvMeldeperiod_ComboboxEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ZvMeldeperiod_ComboboxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ZvMeldeperiod_ComboboxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZvMeldeperiod_ComboboxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZvMeldeperiod_ComboboxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZvMeldeperiod_ComboboxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ZvMeldeperiod_ComboboxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ZvMeldeperiod_ComboboxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ZvMeldeperiod_ComboboxEdit.Properties.DisplayFormat.FormatString = "d"
        Me.ZvMeldeperiod_ComboboxEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ZvMeldeperiod_ComboboxEdit.Properties.EditFormat.FormatString = "d"
        Me.ZvMeldeperiod_ComboboxEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ZvMeldeperiod_ComboboxEdit.Properties.ReadOnly = True
        Me.ZvMeldeperiod_ComboboxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ZvMeldeperiod_ComboboxEdit.Properties.UseReadOnlyAppearance = False
        Me.ZvMeldeperiod_ComboboxEdit.Size = New System.Drawing.Size(133, 20)
        Me.ZvMeldeperiod_ComboboxEdit.StyleController = Me.AbacusFilesRecreationLayoutControl1ConvertedLayout
        Me.ZvMeldeperiod_ComboboxEdit.TabIndex = 9
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.SearchLookUpEdit1item, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(407, 278)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'SearchLookUpEdit1item
        '
        Me.SearchLookUpEdit1item.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchLookUpEdit1item.AppearanceItemCaption.Options.UseFont = True
        Me.SearchLookUpEdit1item.AppearanceItemCaption.Options.UseTextOptions = True
        Me.SearchLookUpEdit1item.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SearchLookUpEdit1item.Control = Me.ZvMeldeschemas_SearchLookUpEdit
        Me.SearchLookUpEdit1item.Location = New System.Drawing.Point(0, 196)
        Me.SearchLookUpEdit1item.Name = "SearchLookUpEdit1item"
        Me.SearchLookUpEdit1item.Size = New System.Drawing.Size(155, 42)
        Me.SearchLookUpEdit1item.Text = "ZV Statistik Schema"
        Me.SearchLookUpEdit1item.TextLocation = DevExpress.Utils.Locations.Top
        Me.SearchLookUpEdit1item.TextSize = New System.Drawing.Size(106, 15)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ProgressPanel1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 238)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(387, 20)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.PictureEdit1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(387, 196)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem4.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem4.Control = Me.ZvMeldejahr_DateEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(292, 196)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(95, 42)
        Me.LayoutControlItem4.Text = "Meldejahr"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(57, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem3.Control = Me.ZvMeldeperiod_ComboboxEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(155, 196)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(137, 42)
        Me.LayoutControlItem3.Text = "Meldeperiode"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(77, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
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
        'ZvStatistic_NewReportingPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout)
        Me.Name = "ZvStatistic_NewReportingPeriod"
        Me.Size = New System.Drawing.Size(407, 278)
        CType(Me.ZvMeldeschemas_SearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AbacusFilesRecreationLayoutControl1ConvertedLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AbacusFilesRecreationLayoutControl1ConvertedLayout.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvMeldejahr_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvMeldejahr_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZvMeldeperiod_ComboboxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1item, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportingDate_BarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ZvMeldeschemas_SearchLookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AbacusFilesRecreationLayoutControl1ConvertedLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SearchLookUpEdit1item As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZvMeldeschema_GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZvMeldejahr_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ZvMeldeschemaDescription_GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ZvMeldeperiod_ComboboxEdit As DevExpress.XtraEditors.ComboBoxEdit
End Class
