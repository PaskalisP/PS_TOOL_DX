﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue5 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calendar))
        Me.DateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.YearsCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Calculate_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.MonthsCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.WeeksCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DaysCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.CalculatedDay_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.CalculatedDate_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Day_SpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit3 = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.IndustryDate_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit4 = New DevExpress.XtraEditors.DateEdit()
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.CalendarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CalendarTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.CalendarTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.Calendar_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCalendarDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCalendarDay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTargetHoliday = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colMinReserveBUBA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemTextEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMemoExEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.LayoutViewField66 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn91 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField67 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn92 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField68 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn93 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField69 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn94 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField70 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn95 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField71 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn96 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField72 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn97 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField73 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn98 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField74 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn99 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField75 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn100 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.LayoutViewField76 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
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
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.Day_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalendarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Calendar_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateNavigator1
        '
        Me.DateNavigator1.AllowAnimatedContentChange = True
        Me.DateNavigator1.CalendarAppearance.WeekNumber.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DateNavigator1.CalendarAppearance.WeekNumber.Options.UseFont = True
        Me.DateNavigator1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateNavigator1.CellPadding = New System.Windows.Forms.Padding(2)
        Me.DateNavigator1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateNavigator1.DateTime = New Date(CType(0, Long))
        Me.DateNavigator1.EditValue = New Date(CType(0, Long))
        Me.DateNavigator1.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.DateNavigator1.Location = New System.Drawing.Point(12, 12)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(255, 244)
        Me.DateNavigator1.TabIndex = 0
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.YearsCount_lbl)
        Me.GroupControl1.Controls.Add(Me.Calculate_btn)
        Me.GroupControl1.Controls.Add(Me.MonthsCount_lbl)
        Me.GroupControl1.Controls.Add(Me.WeeksCount_lbl)
        Me.GroupControl1.Controls.Add(Me.DaysCount_lbl)
        Me.GroupControl1.Controls.Add(Me.DateEdit2)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.DateEdit1)
        Me.GroupControl1.Location = New System.Drawing.Point(287, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(329, 244)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Calculations between two Dates"
        '
        'YearsCount_lbl
        '
        Me.YearsCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.YearsCount_lbl.Appearance.Options.UseFont = True
        Me.YearsCount_lbl.Location = New System.Drawing.Point(110, 208)
        Me.YearsCount_lbl.Name = "YearsCount_lbl"
        Me.YearsCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.YearsCount_lbl.TabIndex = 9
        Me.YearsCount_lbl.Text = "Date till"
        '
        'Calculate_btn
        '
        Me.Calculate_btn.Location = New System.Drawing.Point(140, 106)
        Me.Calculate_btn.Name = "Calculate_btn"
        Me.Calculate_btn.Size = New System.Drawing.Size(100, 23)
        Me.Calculate_btn.TabIndex = 8
        Me.Calculate_btn.Text = "Calculate"
        '
        'MonthsCount_lbl
        '
        Me.MonthsCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MonthsCount_lbl.Appearance.Options.UseFont = True
        Me.MonthsCount_lbl.Location = New System.Drawing.Point(110, 186)
        Me.MonthsCount_lbl.Name = "MonthsCount_lbl"
        Me.MonthsCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.MonthsCount_lbl.TabIndex = 7
        Me.MonthsCount_lbl.Text = "Date till"
        '
        'WeeksCount_lbl
        '
        Me.WeeksCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.WeeksCount_lbl.Appearance.Options.UseFont = True
        Me.WeeksCount_lbl.Location = New System.Drawing.Point(110, 164)
        Me.WeeksCount_lbl.Name = "WeeksCount_lbl"
        Me.WeeksCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.WeeksCount_lbl.TabIndex = 6
        Me.WeeksCount_lbl.Text = "Date till"
        '
        'DaysCount_lbl
        '
        Me.DaysCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DaysCount_lbl.Appearance.Options.UseFont = True
        Me.DaysCount_lbl.Location = New System.Drawing.Point(110, 142)
        Me.DaysCount_lbl.Name = "DaysCount_lbl"
        Me.DaysCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.DaysCount_lbl.TabIndex = 5
        Me.DaysCount_lbl.Text = "Date till"
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = New Date(2013, 12, 17, 14, 57, 1, 0)
        Me.DateEdit2.Location = New System.Drawing.Point(140, 77)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateEdit2.Properties.Appearance.Options.UseFont = True
        Me.DateEdit2.Properties.Appearance.Options.UseTextOptions = True
        Me.DateEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit2.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit2.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit2.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit2.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(68, 85)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Date till"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(68, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Date from"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = New Date(2013, 12, 17, 14, 50, 35, 0)
        Me.DateEdit1.Location = New System.Drawing.Point(140, 41)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateEdit1.Properties.Appearance.Options.UseFont = True
        Me.DateEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.DateEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit1.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit1.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit1.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.CalculatedDay_lbl)
        Me.GroupControl2.Controls.Add(Me.CalculatedDate_lbl)
        Me.GroupControl2.Controls.Add(Me.Day_SpinEdit)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.DateEdit3)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 262)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(255, 177)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Calculate Date "
        '
        'CalculatedDay_lbl
        '
        Me.CalculatedDay_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CalculatedDay_lbl.Appearance.Options.UseFont = True
        Me.CalculatedDay_lbl.Location = New System.Drawing.Point(5, 144)
        Me.CalculatedDay_lbl.Name = "CalculatedDay_lbl"
        Me.CalculatedDay_lbl.Size = New System.Drawing.Size(0, 16)
        Me.CalculatedDay_lbl.TabIndex = 7
        '
        'CalculatedDate_lbl
        '
        Me.CalculatedDate_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CalculatedDate_lbl.Appearance.Options.UseFont = True
        Me.CalculatedDate_lbl.Location = New System.Drawing.Point(5, 122)
        Me.CalculatedDate_lbl.Name = "CalculatedDate_lbl"
        Me.CalculatedDate_lbl.Size = New System.Drawing.Size(0, 16)
        Me.CalculatedDate_lbl.TabIndex = 6
        '
        'Day_SpinEdit
        '
        Me.Day_SpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Day_SpinEdit.Location = New System.Drawing.Point(75, 84)
        Me.Day_SpinEdit.Name = "Day_SpinEdit"
        Me.Day_SpinEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Day_SpinEdit.Properties.Appearance.Options.UseFont = True
        Me.Day_SpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.Day_SpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Day_SpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Day_SpinEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Day_SpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Day_SpinEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Day_SpinEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Day_SpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Day_SpinEdit.Properties.DisplayFormat.FormatString = "n0"
        Me.Day_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Day_SpinEdit.Properties.EditFormat.FormatString = "n0"
        Me.Day_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Day_SpinEdit.Properties.Mask.EditMask = "n0"
        Me.Day_SpinEdit.Properties.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.Day_SpinEdit.Size = New System.Drawing.Size(100, 22)
        Me.Day_SpinEdit.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(116, 65)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(8, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "+"
        '
        'DateEdit3
        '
        Me.DateEdit3.EditValue = New Date(2013, 12, 17, 16, 0, 54, 0)
        Me.DateEdit3.Location = New System.Drawing.Point(75, 37)
        Me.DateEdit3.Name = "DateEdit3"
        Me.DateEdit3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateEdit3.Properties.Appearance.Options.UseFont = True
        Me.DateEdit3.Properties.Appearance.Options.UseTextOptions = True
        Me.DateEdit3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateEdit3.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit3.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit3.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit3.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit3.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit3.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit3.TabIndex = 0
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.IndustryDate_lbl)
        Me.GroupControl3.Controls.Add(Me.DateEdit4)
        Me.GroupControl3.Location = New System.Drawing.Point(287, 262)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(329, 177)
        Me.GroupControl3.TabIndex = 3
        Me.GroupControl3.Text = "Industry Date "
        '
        'IndustryDate_lbl
        '
        Me.IndustryDate_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.IndustryDate_lbl.Appearance.Options.UseFont = True
        Me.IndustryDate_lbl.Appearance.Options.UseTextOptions = True
        Me.IndustryDate_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.IndustryDate_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.IndustryDate_lbl.Location = New System.Drawing.Point(5, 77)
        Me.IndustryDate_lbl.Name = "IndustryDate_lbl"
        Me.IndustryDate_lbl.Size = New System.Drawing.Size(319, 36)
        Me.IndustryDate_lbl.TabIndex = 6
        '
        'DateEdit4
        '
        Me.DateEdit4.EditValue = New Date(2013, 12, 17, 16, 24, 45, 0)
        Me.DateEdit4.Location = New System.Drawing.Point(110, 37)
        Me.DateEdit4.Name = "DateEdit4"
        Me.DateEdit4.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DateEdit4.Properties.Appearance.Options.UseFont = True
        Me.DateEdit4.Properties.Appearance.Options.UseTextOptions = True
        Me.DateEdit4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DateEdit4.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit4.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit4.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit4.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit4.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit4.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit4.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit4.TabIndex = 0
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalendarBindingSource
        '
        Me.CalendarBindingSource.DataMember = "Calendar"
        Me.CalendarBindingSource.DataSource = Me.PSTOOLDataset
        '
        'CalendarTableAdapter
        '
        Me.CalendarTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.CalendarTableAdapter = Me.CalendarTableAdapter
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GridControl4
        '
        Me.GridControl4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl4.DataSource = Me.CalendarBindingSource
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl4.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Neues Inventar einfügen", "AddNewInventar")})
        Me.GridControl4.Location = New System.Drawing.Point(622, 12)
        Me.GridControl4.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.GridControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl4.MainView = Me.Calendar_GridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox4, Me.RepositoryItemTextEdit7, Me.RepositoryItemTextEdit8, Me.RepositoryItemTextEdit9, Me.RepositoryItemMemoExEdit4, Me.RepositoryItemImageComboBox3, Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2, Me.RepositoryItemImageComboBox1})
        Me.GridControl4.Size = New System.Drawing.Size(699, 427)
        Me.GridControl4.TabIndex = 130
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Calendar_GridView, Me.LayoutView4, Me.GridView4})
        '
        'Calendar_GridView
        '
        Me.Calendar_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Calendar_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Calendar_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Calendar_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Calendar_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Calendar_GridView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Aqua
        Me.Calendar_GridView.Appearance.GroupFooter.Options.UseForeColor = True
        Me.Calendar_GridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Aqua
        Me.Calendar_GridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.Calendar_GridView.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Calendar_GridView.AppearancePrint.FilterPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Calendar_GridView.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.Calendar_GridView.AppearancePrint.FilterPanel.Options.UseForeColor = True
        Me.Calendar_GridView.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Calendar_GridView.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.Calendar_GridView.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.Calendar_GridView.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.Calendar_GridView.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Calendar_GridView.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.Calendar_GridView.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.Calendar_GridView.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.Calendar_GridView.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.Calendar_GridView.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.Calendar_GridView.AppearancePrint.Row.Options.UseBackColor = True
        Me.Calendar_GridView.AppearancePrint.Row.Options.UseForeColor = True
        Me.Calendar_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCalendarDate, Me.colCalendarDay, Me.colTargetHoliday, Me.colMinReserveBUBA})
        Me.Calendar_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue1.Value1 = 0.0R
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Appearance.Options.UseTextOptions = True
        FormatConditionRuleValue2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Less
        FormatConditionRuleValue2.Value1 = 0.0R
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Cyan
        FormatConditionRuleValue3.Appearance.BackColor2 = System.Drawing.Color.Cyan
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue3.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Appearance.Options.UseTextOptions = True
        FormatConditionRuleValue3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = "Repayment"
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.Name = "Format3"
        FormatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        FormatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue4.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue4.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = "Matured"
        GridFormatRule4.Rule = FormatConditionRuleValue4
        GridFormatRule5.ApplyToRow = True
        GridFormatRule5.Name = "Format4"
        FormatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue5.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleValue5.Appearance.ForeColor = System.Drawing.Color.Black
        FormatConditionRuleValue5.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue5.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue5.Value1 = True
        GridFormatRule5.Rule = FormatConditionRuleValue5
        Me.Calendar_GridView.FormatRules.Add(GridFormatRule1)
        Me.Calendar_GridView.FormatRules.Add(GridFormatRule2)
        Me.Calendar_GridView.FormatRules.Add(GridFormatRule3)
        Me.Calendar_GridView.FormatRules.Add(GridFormatRule4)
        Me.Calendar_GridView.FormatRules.Add(GridFormatRule5)
        Me.Calendar_GridView.GridControl = Me.GridControl4
        Me.Calendar_GridView.Name = "Calendar_GridView"
        Me.Calendar_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Calendar_GridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.Calendar_GridView.OptionsCustomization.AllowRowSizing = True
        Me.Calendar_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Calendar_GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.Calendar_GridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.Calendar_GridView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.Calendar_GridView.OptionsFind.AlwaysVisible = True
        Me.Calendar_GridView.OptionsFind.SearchInPreview = True
        Me.Calendar_GridView.OptionsLayout.StoreAllOptions = True
        Me.Calendar_GridView.OptionsLayout.StoreAppearance = True
        Me.Calendar_GridView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.Calendar_GridView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.Calendar_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Calendar_GridView.OptionsSelection.MultiSelect = True
        Me.Calendar_GridView.OptionsView.ColumnAutoWidth = False
        Me.Calendar_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Calendar_GridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.Calendar_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Calendar_GridView.OptionsView.ShowAutoFilterRow = True
        Me.Calendar_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.Calendar_GridView.OptionsView.ShowGroupedColumns = True
        Me.Calendar_GridView.OptionsView.ShowGroupPanel = False
        Me.Calendar_GridView.OptionsView.ShowViewCaption = True
        Me.Calendar_GridView.PaintStyleName = "Skin"
        Me.Calendar_GridView.ViewCaption = "Calendar for BUNDESBANK Minimum Reserves End Dates and TARGET Holidays"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colCalendarDate
        '
        Me.colCalendarDate.Caption = "Date"
        Me.colCalendarDate.FieldName = "CalendarDate"
        Me.colCalendarDate.Name = "colCalendarDate"
        Me.colCalendarDate.OptionsColumn.AllowEdit = False
        Me.colCalendarDate.OptionsColumn.ReadOnly = True
        Me.colCalendarDate.Visible = True
        Me.colCalendarDate.VisibleIndex = 0
        Me.colCalendarDate.Width = 113
        '
        'colCalendarDay
        '
        Me.colCalendarDay.Caption = "Day"
        Me.colCalendarDay.FieldName = "CalendarDay"
        Me.colCalendarDay.Name = "colCalendarDay"
        Me.colCalendarDay.OptionsColumn.AllowEdit = False
        Me.colCalendarDay.OptionsColumn.ReadOnly = True
        Me.colCalendarDay.Visible = True
        Me.colCalendarDay.VisibleIndex = 1
        Me.colCalendarDay.Width = 112
        '
        'colTargetHoliday
        '
        Me.colTargetHoliday.Caption = "TARGET Holiday"
        Me.colTargetHoliday.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colTargetHoliday.FieldName = "TargetHoliday"
        Me.colTargetHoliday.Name = "colTargetHoliday"
        Me.colTargetHoliday.Visible = True
        Me.colTargetHoliday.VisibleIndex = 2
        Me.colTargetHoliday.Width = 127
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("HOLIDAY", "H", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 15)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
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
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("remove_16x16.png", "images/actions/remove_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "remove_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("exporttoxlsx_16x16.png", "images/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxlsx_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "exporttoxlsx_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "cancel_16x16.png")
        '
        'colMinReserveBUBA
        '
        Me.colMinReserveBUBA.Caption = "End of Minimum Reserve (BUNDESBANK)"
        Me.colMinReserveBUBA.ColumnEdit = Me.RepositoryItemImageComboBox3
        Me.colMinReserveBUBA.FieldName = "MinReserveBUBA"
        Me.colMinReserveBUBA.Name = "colMinReserveBUBA"
        Me.colMinReserveBUBA.Visible = True
        Me.colMinReserveBUBA.VisibleIndex = 3
        Me.colMinReserveBUBA.Width = 107
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
        Me.RepositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 15)})
        Me.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3"
        Me.RepositoryItemImageComboBox3.SmallImages = Me.ImageCollection1
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
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemCheckEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'LayoutView4
        '
        Me.LayoutView4.CardMinSize = New System.Drawing.Size(547, 549)
        Me.LayoutView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.LayoutViewColumn76, Me.LayoutViewColumn77, Me.LayoutViewColumn78, Me.LayoutViewColumn79, Me.LayoutViewColumn80, Me.LayoutViewColumn81, Me.LayoutViewColumn82, Me.LayoutViewColumn83, Me.LayoutViewColumn84, Me.LayoutViewColumn85, Me.LayoutViewColumn86, Me.LayoutViewColumn87, Me.LayoutViewColumn88, Me.LayoutViewColumn89, Me.LayoutViewColumn90, Me.LayoutViewColumn91, Me.LayoutViewColumn92, Me.LayoutViewColumn93, Me.LayoutViewColumn94, Me.LayoutViewColumn95, Me.LayoutViewColumn96, Me.LayoutViewColumn97, Me.LayoutViewColumn98, Me.LayoutViewColumn99, Me.LayoutViewColumn100})
        Me.LayoutView4.GridControl = Me.GridControl4
        Me.LayoutView4.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutViewField73, Me.LayoutViewField72, Me.LayoutViewField70})
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
        Me.LayoutViewColumn90.LayoutViewField = Me.LayoutViewField66
        Me.LayoutViewColumn90.Name = "LayoutViewColumn90"
        '
        'LayoutViewField66
        '
        Me.LayoutViewField66.EditorPreferredWidth = 384
        Me.LayoutViewField66.Location = New System.Drawing.Point(0, 80)
        Me.LayoutViewField66.Name = "LayoutViewField66"
        Me.LayoutViewField66.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField66.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn91
        '
        Me.LayoutViewColumn91.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn91.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn91.FieldName = "POB NUMBER"
        Me.LayoutViewColumn91.LayoutViewField = Me.LayoutViewField67
        Me.LayoutViewColumn91.Name = "LayoutViewColumn91"
        '
        'LayoutViewField67
        '
        Me.LayoutViewField67.EditorPreferredWidth = 384
        Me.LayoutViewField67.Location = New System.Drawing.Point(0, 140)
        Me.LayoutViewField67.Name = "LayoutViewField67"
        Me.LayoutViewField67.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField67.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn92
        '
        Me.LayoutViewColumn92.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn92.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn92.FieldName = "POB LOCATION"
        Me.LayoutViewColumn92.LayoutViewField = Me.LayoutViewField68
        Me.LayoutViewColumn92.Name = "LayoutViewColumn92"
        '
        'LayoutViewField68
        '
        Me.LayoutViewField68.EditorPreferredWidth = 384
        Me.LayoutViewField68.Location = New System.Drawing.Point(0, 160)
        Me.LayoutViewField68.Name = "LayoutViewField68"
        Me.LayoutViewField68.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField68.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn93
        '
        Me.LayoutViewColumn93.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn93.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn93.FieldName = "POB COUNTRY NAME"
        Me.LayoutViewColumn93.LayoutViewField = Me.LayoutViewField69
        Me.LayoutViewColumn93.Name = "LayoutViewColumn93"
        '
        'LayoutViewField69
        '
        Me.LayoutViewField69.EditorPreferredWidth = 384
        Me.LayoutViewField69.Location = New System.Drawing.Point(0, 180)
        Me.LayoutViewField69.Name = "LayoutViewField69"
        Me.LayoutViewField69.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField69.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewColumn94
        '
        Me.LayoutViewColumn94.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn94.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn94.CustomizationCaption = "USER"
        Me.LayoutViewColumn94.FieldName = "USER"
        Me.LayoutViewColumn94.LayoutViewField = Me.LayoutViewField70
        Me.LayoutViewColumn94.Name = "LayoutViewColumn94"
        Me.LayoutViewColumn94.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField70
        '
        Me.LayoutViewField70.EditorPreferredWidth = 20
        Me.LayoutViewField70.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField70.Name = "LayoutViewField70"
        Me.LayoutViewField70.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField70.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn95
        '
        Me.LayoutViewColumn95.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn95.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn95.ColumnEdit = Me.RepositoryItemComboBox4
        Me.LayoutViewColumn95.FieldName = "VALID"
        Me.LayoutViewColumn95.LayoutViewField = Me.LayoutViewField71
        Me.LayoutViewColumn95.Name = "LayoutViewColumn95"
        '
        'LayoutViewField71
        '
        Me.LayoutViewField71.EditorPreferredWidth = 30
        Me.LayoutViewField71.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField71.Name = "LayoutViewField71"
        Me.LayoutViewField71.Size = New System.Drawing.Size(162, 20)
        Me.LayoutViewField71.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn96
        '
        Me.LayoutViewColumn96.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn96.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn96.CustomizationCaption = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.FieldName = "UNTER BEARBEITUNG VON"
        Me.LayoutViewColumn96.LayoutViewField = Me.LayoutViewField72
        Me.LayoutViewColumn96.Name = "LayoutViewColumn96"
        Me.LayoutViewColumn96.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField72
        '
        Me.LayoutViewField72.EditorPreferredWidth = 20
        Me.LayoutViewField72.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField72.Name = "LayoutViewField72"
        Me.LayoutViewField72.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField72.TextSize = New System.Drawing.Size(133, 20)
        '
        'LayoutViewColumn97
        '
        Me.LayoutViewColumn97.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn97.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn97.CustomizationCaption = "BIC11"
        Me.LayoutViewColumn97.FieldName = "BIC11"
        Me.LayoutViewColumn97.LayoutViewField = Me.LayoutViewField73
        Me.LayoutViewColumn97.Name = "LayoutViewColumn97"
        Me.LayoutViewColumn97.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField73
        '
        Me.LayoutViewField73.EditorPreferredWidth = 20
        Me.LayoutViewField73.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField73.Name = "LayoutViewField73"
        Me.LayoutViewField73.Size = New System.Drawing.Size(527, 612)
        Me.LayoutViewField73.TextSize = New System.Drawing.Size(133, 20)
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
        Me.LayoutViewColumn98.ImageIndex = 0
        Me.LayoutViewColumn98.LayoutViewField = Me.LayoutViewField74
        Me.LayoutViewColumn98.Name = "LayoutViewColumn98"
        '
        'LayoutViewField74
        '
        Me.LayoutViewField74.EditorPreferredWidth = 93
        Me.LayoutViewField74.ImageIndex = 0
        Me.LayoutViewField74.Location = New System.Drawing.Point(0, 0)
        Me.LayoutViewField74.Name = "LayoutViewField74"
        Me.LayoutViewField74.Size = New System.Drawing.Size(225, 20)
        Me.LayoutViewField74.TextSize = New System.Drawing.Size(123, 16)
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
        Me.LayoutViewColumn99.LayoutViewField = Me.LayoutViewField75
        Me.LayoutViewColumn99.Name = "LayoutViewColumn99"
        '
        'LayoutViewField75
        '
        Me.LayoutViewField75.EditorPreferredWidth = 51
        Me.LayoutViewField75.Location = New System.Drawing.Point(0, 20)
        Me.LayoutViewField75.Name = "LayoutViewField75"
        Me.LayoutViewField75.Size = New System.Drawing.Size(183, 20)
        Me.LayoutViewField75.TextSize = New System.Drawing.Size(123, 13)
        '
        'LayoutViewColumn100
        '
        Me.LayoutViewColumn100.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutViewColumn100.AppearanceCell.Options.UseFont = True
        Me.LayoutViewColumn100.Caption = "COUNTRY CODE"
        Me.LayoutViewColumn100.FieldName = "COUNTRY"
        Me.LayoutViewColumn100.LayoutViewField = Me.LayoutViewField76
        Me.LayoutViewColumn100.Name = "LayoutViewColumn100"
        Me.LayoutViewColumn100.OptionsColumn.ReadOnly = True
        '
        'LayoutViewField76
        '
        Me.LayoutViewField76.EditorPreferredWidth = 384
        Me.LayoutViewField76.Location = New System.Drawing.Point(0, 100)
        Me.LayoutViewField76.Name = "LayoutViewField76"
        Me.LayoutViewField76.Size = New System.Drawing.Size(503, 20)
        Me.LayoutViewField76.TextSize = New System.Drawing.Size(110, 13)
        '
        'LayoutViewCard4
        '
        Me.LayoutViewCard4.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText
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
        Me.GridColumn121.ToolTip = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & _
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
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1333, 459)
        Me.Controls.Add(Me.GridControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.DateNavigator1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Calendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calendar"
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.Day_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.DateEdit4.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalendarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Calendar_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MonthsCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WeeksCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DaysCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Calculate_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit3 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CalculatedDay_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CalculatedDate_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Day_SpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents IndustryDate_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit4 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents YearsCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents CalendarBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CalendarTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.CalendarTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Calendar_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCalendarDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCalendarDay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMinReserveBUBA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
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
    Friend WithEvents LayoutViewField66 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn91 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField67 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn92 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField68 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn93 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField69 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn94 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField70 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn95 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField71 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn96 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField72 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn97 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField73 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn98 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField74 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn99 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField75 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewColumn100 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents LayoutViewField76 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
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
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents colTargetHoliday As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
End Class
