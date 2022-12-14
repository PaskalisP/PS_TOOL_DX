<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterestCalculator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterestCalculator))
        Me.DateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.InterestDaysCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.InterestAmount_SpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.InterestCalculatedAmount_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.InterestMethod_cmb = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Interest_SpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.Calculate_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.MonthsCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.WeeksCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DaysCount_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.InterestAmount_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InterestCalculatedAmount_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InterestMethod_cmb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Interest_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateNavigator1
        '
        Me.DateNavigator1.AllowAnimatedContentChange = True
        Me.DateNavigator1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.DateNavigator1.Size = New System.Drawing.Size(789, 6)
        Me.DateNavigator1.TabIndex = 0
        Me.DateNavigator1.Visible = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.InterestDaysCount_lbl)
        Me.GroupControl1.Controls.Add(Me.InterestAmount_SpinEdit)
        Me.GroupControl1.Controls.Add(Me.InterestCalculatedAmount_TextEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.InterestMethod_cmb)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.Interest_SpinEdit)
        Me.GroupControl1.Controls.Add(Me.Calculate_btn)
        Me.GroupControl1.Controls.Add(Me.MonthsCount_lbl)
        Me.GroupControl1.Controls.Add(Me.WeeksCount_lbl)
        Me.GroupControl1.Controls.Add(Me.DaysCount_lbl)
        Me.GroupControl1.Controls.Add(Me.DateEdit2)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.DateEdit1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(813, 404)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Interest Calculations"
        '
        'InterestDaysCount_lbl
        '
        Me.InterestDaysCount_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.InterestDaysCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.InterestDaysCount_lbl.Appearance.Options.UseFont = True
        Me.InterestDaysCount_lbl.Location = New System.Drawing.Point(232, 347)
        Me.InterestDaysCount_lbl.Name = "InterestDaysCount_lbl"
        Me.InterestDaysCount_lbl.Size = New System.Drawing.Size(90, 16)
        Me.InterestDaysCount_lbl.TabIndex = 17
        Me.InterestDaysCount_lbl.Text = "Interest Days"
        '
        'InterestAmount_SpinEdit
        '
        Me.InterestAmount_SpinEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.InterestAmount_SpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.InterestAmount_SpinEdit.Location = New System.Drawing.Point(301, 263)
        Me.InterestAmount_SpinEdit.Name = "InterestAmount_SpinEdit"
        Me.InterestAmount_SpinEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.InterestAmount_SpinEdit.Properties.Appearance.Options.UseFont = True
        Me.InterestAmount_SpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.InterestAmount_SpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.InterestAmount_SpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.InterestAmount_SpinEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.InterestAmount_SpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.InterestAmount_SpinEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.InterestAmount_SpinEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.InterestAmount_SpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.InterestAmount_SpinEdit.Properties.DisplayFormat.FormatString = "n2"
        Me.InterestAmount_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.InterestAmount_SpinEdit.Properties.EditFormat.FormatString = "n2"
        Me.InterestAmount_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.InterestAmount_SpinEdit.Properties.Mask.EditMask = "n2"
        Me.InterestAmount_SpinEdit.Properties.MaxValue = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.InterestAmount_SpinEdit.Size = New System.Drawing.Size(227, 22)
        Me.InterestAmount_SpinEdit.TabIndex = 14
        '
        'InterestCalculatedAmount_TextEdit
        '
        Me.InterestCalculatedAmount_TextEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.InterestCalculatedAmount_TextEdit.Location = New System.Drawing.Point(232, 320)
        Me.InterestCalculatedAmount_TextEdit.Name = "InterestCalculatedAmount_TextEdit"
        Me.InterestCalculatedAmount_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.InterestCalculatedAmount_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.InterestCalculatedAmount_TextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.InterestCalculatedAmount_TextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Black
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.Black
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Cyan
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.InterestCalculatedAmount_TextEdit.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.InterestCalculatedAmount_TextEdit.Properties.DisplayFormat.FormatString = "n2"
        Me.InterestCalculatedAmount_TextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.InterestCalculatedAmount_TextEdit.Properties.EditFormat.FormatString = "n2"
        Me.InterestCalculatedAmount_TextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.InterestCalculatedAmount_TextEdit.Properties.Mask.EditMask = "n2"
        Me.InterestCalculatedAmount_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.InterestCalculatedAmount_TextEdit.Properties.ReadOnly = True
        Me.InterestCalculatedAmount_TextEdit.Size = New System.Drawing.Size(357, 24)
        Me.InterestCalculatedAmount_TextEdit.TabIndex = 16
        '
        'LabelControl5
        '
        Me.LabelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl5.Location = New System.Drawing.Point(389, 248)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "Amount"
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl4.Location = New System.Drawing.Point(364, 207)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Calculation Method"
        '
        'InterestMethod_cmb
        '
        Me.InterestMethod_cmb.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.InterestMethod_cmb.Location = New System.Drawing.Point(301, 222)
        Me.InterestMethod_cmb.Name = "InterestMethod_cmb"
        Me.InterestMethod_cmb.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.InterestMethod_cmb.Properties.Appearance.Options.UseFont = True
        Me.InterestMethod_cmb.Properties.Appearance.Options.UseTextOptions = True
        Me.InterestMethod_cmb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.InterestMethod_cmb.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.InterestMethod_cmb.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.InterestMethod_cmb.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.InterestMethod_cmb.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.InterestMethod_cmb.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.InterestMethod_cmb.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InterestMethod_cmb.Properties.Items.AddRange(New Object() {"ACT/360 EURO", "ACT/365 ENGLISH", "ACT/ACT", "30/360     GERMAN"})
        Me.InterestMethod_cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.InterestMethod_cmb.Size = New System.Drawing.Size(227, 22)
        Me.InterestMethod_cmb.TabIndex = 12
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl3.Location = New System.Drawing.Point(379, 155)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Interest Rate"
        '
        'Interest_SpinEdit
        '
        Me.Interest_SpinEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Interest_SpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Interest_SpinEdit.Location = New System.Drawing.Point(364, 172)
        Me.Interest_SpinEdit.Name = "Interest_SpinEdit"
        Me.Interest_SpinEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Interest_SpinEdit.Properties.Appearance.Options.UseFont = True
        Me.Interest_SpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.Interest_SpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Interest_SpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Interest_SpinEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Interest_SpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Interest_SpinEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Interest_SpinEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Interest_SpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Interest_SpinEdit.Properties.DisplayFormat.FormatString = "n5"
        Me.Interest_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Interest_SpinEdit.Properties.EditFormat.FormatString = "n5"
        Me.Interest_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Interest_SpinEdit.Properties.Mask.EditMask = "n5"
        Me.Interest_SpinEdit.Properties.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.Interest_SpinEdit.Size = New System.Drawing.Size(100, 22)
        Me.Interest_SpinEdit.TabIndex = 10
        '
        'Calculate_btn
        '
        Me.Calculate_btn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Calculate_btn.Location = New System.Drawing.Point(364, 291)
        Me.Calculate_btn.Name = "Calculate_btn"
        Me.Calculate_btn.Size = New System.Drawing.Size(100, 23)
        Me.Calculate_btn.TabIndex = 15
        Me.Calculate_btn.Text = "Calculate"
        '
        'MonthsCount_lbl
        '
        Me.MonthsCount_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MonthsCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MonthsCount_lbl.Appearance.Options.UseFont = True
        Me.MonthsCount_lbl.Location = New System.Drawing.Point(362, 126)
        Me.MonthsCount_lbl.Name = "MonthsCount_lbl"
        Me.MonthsCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.MonthsCount_lbl.TabIndex = 8
        Me.MonthsCount_lbl.Text = "Date till"
        '
        'WeeksCount_lbl
        '
        Me.WeeksCount_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.WeeksCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.WeeksCount_lbl.Appearance.Options.UseFont = True
        Me.WeeksCount_lbl.Location = New System.Drawing.Point(362, 104)
        Me.WeeksCount_lbl.Name = "WeeksCount_lbl"
        Me.WeeksCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.WeeksCount_lbl.TabIndex = 7
        Me.WeeksCount_lbl.Text = "Date till"
        '
        'DaysCount_lbl
        '
        Me.DaysCount_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DaysCount_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DaysCount_lbl.Appearance.Options.UseFont = True
        Me.DaysCount_lbl.Location = New System.Drawing.Point(362, 82)
        Me.DaysCount_lbl.Name = "DaysCount_lbl"
        Me.DaysCount_lbl.Size = New System.Drawing.Size(50, 16)
        Me.DaysCount_lbl.TabIndex = 6
        Me.DaysCount_lbl.Text = "Date till"
        '
        'DateEdit2
        '
        Me.DateEdit2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DateEdit2.EditValue = New Date(2013, 12, 17, 14, 57, 1, 0)
        Me.DateEdit2.Location = New System.Drawing.Point(428, 50)
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
        Me.DateEdit2.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl2.Location = New System.Drawing.Point(428, 31)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Date till"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl1.Location = New System.Drawing.Point(301, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Date from"
        '
        'DateEdit1
        '
        Me.DateEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DateEdit1.EditValue = New Date(2013, 12, 17, 14, 50, 35, 0)
        Me.DateEdit1.Location = New System.Drawing.Point(301, 50)
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
        Me.DateEdit1.TabIndex = 3
        '
        'InterestCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 404)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.DateNavigator1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InterestCalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Interests Calculator"
        CType(Me.DateNavigator1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.InterestAmount_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InterestCalculatedAmount_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InterestMethod_cmb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Interest_SpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Calculate_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MonthsCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WeeksCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DaysCount_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents InterestMethod_cmb As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Interest_SpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents InterestCalculatedAmount_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents InterestAmount_SpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents InterestDaysCount_lbl As DevExpress.XtraEditors.LabelControl
End Class
