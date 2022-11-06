<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatesForm))
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.OK_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Cancel_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Text_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(29, 74)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit1.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit1.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit1.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 5
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(228, 74)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DateEdit2.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DateEdit2.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DateEdit2.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DateEdit2.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit2.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit2.TabIndex = 6
        '
        'OK_btn
        '
        Me.OK_btn.ImageIndex = 5
        Me.OK_btn.ImageList = Me.ImageCollection1
        Me.OK_btn.Location = New System.Drawing.Point(29, 134)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(75, 23)
        Me.OK_btn.TabIndex = 7
        Me.OK_btn.Text = "OK"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.ImageIndex = 6
        Me.Cancel_btn.ImageList = Me.ImageCollection1
        Me.Cancel_btn.Location = New System.Drawing.Point(253, 134)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_btn.TabIndex = 8
        Me.Cancel_btn.Text = "Cancel"
        '
        'Text_lbl
        '
        Me.Text_lbl.Appearance.Options.UseTextOptions = True
        Me.Text_lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Text_lbl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.Text_lbl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.Text_lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.Text_lbl.Location = New System.Drawing.Point(29, 13)
        Me.Text_lbl.Name = "Text_lbl"
        Me.Text_lbl.Size = New System.Drawing.Size(299, 39)
        Me.Text_lbl.TabIndex = 9
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(31, 58)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 10
        Me.LabelControl1.Text = "From"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(231, 58)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Till"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Valid.ico")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("bodetails_16x16.png", "images/business%20objects/bodetails_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bodetails_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "bodetails_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("table_16x16.png", "grayscaleimages/other/table_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/other/table_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "table_16x16.png")
        '
        'DatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 184)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Text_lbl)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.Controls.Add(Me.DateEdit2)
        Me.Controls.Add(Me.DateEdit1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DatesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DatesForm"
        Me.TopMost = True
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OK_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cancel_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Text_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
End Class
