<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomersMerge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomersMerge))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Cancel_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.OK_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Merge_DateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.OldClientNr_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.OldClientName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.NewClientNr_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.NewClientName_lbl = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Merge_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Merge_DateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Cancel_btn
        '
        Me.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_btn.ImageOptions.ImageIndex = 6
        Me.Cancel_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Cancel_btn.Location = New System.Drawing.Point(508, 185)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_btn.TabIndex = 10
        Me.Cancel_btn.Text = "Cancel"
        '
        'OK_btn
        '
        Me.OK_btn.ImageOptions.ImageIndex = 5
        Me.OK_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.OK_btn.Location = New System.Drawing.Point(12, 185)
        Me.OK_btn.Name = "OK_btn"
        Me.OK_btn.Size = New System.Drawing.Size(105, 23)
        Me.OK_btn.TabIndex = 9
        Me.OK_btn.Text = "Start Merging"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(180, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "Merge Date"
        '
        'Merge_DateEdit
        '
        Me.Merge_DateEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Merge_DateEdit.EditValue = New Date(2019, 1, 8, 0, 0, 0, 0)
        Me.Merge_DateEdit.Location = New System.Drawing.Point(249, 16)
        Me.Merge_DateEdit.Name = "Merge_DateEdit"
        Me.Merge_DateEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Merge_DateEdit.Properties.Appearance.Options.UseFont = True
        Me.Merge_DateEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.Merge_DateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Merge_DateEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Merge_DateEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Merge_DateEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Merge_DateEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Merge_DateEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Merge_DateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Merge_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Merge_DateEdit.Size = New System.Drawing.Size(100, 22)
        Me.Merge_DateEdit.TabIndex = 12
        '
        'OldClientNr_TextEdit
        '
        Me.OldClientNr_TextEdit.Location = New System.Drawing.Point(190, 56)
        Me.OldClientNr_TextEdit.Name = "OldClientNr_TextEdit"
        Me.OldClientNr_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OldClientNr_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.OldClientNr_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.OldClientNr_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.OldClientNr_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.OldClientNr_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.OldClientNr_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.OldClientNr_TextEdit.Properties.Mask.EditMask = "\d{18,18}"
        Me.OldClientNr_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.OldClientNr_TextEdit.Size = New System.Drawing.Size(229, 22)
        Me.OldClientNr_TextEdit.TabIndex = 13
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(104, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(80, 14)
        Me.LabelControl2.TabIndex = 14
        Me.LabelControl2.Text = "Old Client Nr."
        '
        'OldClientName_lbl
        '
        Me.OldClientName_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OldClientName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OldClientName_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.OldClientName_lbl.Appearance.Options.UseFont = True
        Me.OldClientName_lbl.Appearance.Options.UseForeColor = True
        Me.OldClientName_lbl.Location = New System.Drawing.Point(194, 84)
        Me.OldClientName_lbl.Name = "OldClientName_lbl"
        Me.OldClientName_lbl.Size = New System.Drawing.Size(0, 14)
        Me.OldClientName_lbl.TabIndex = 15
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(104, 132)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(86, 14)
        Me.LabelControl3.TabIndex = 16
        Me.LabelControl3.Text = "New Client Nr."
        '
        'NewClientNr_TextEdit
        '
        Me.NewClientNr_TextEdit.Location = New System.Drawing.Point(190, 129)
        Me.NewClientNr_TextEdit.Name = "NewClientNr_TextEdit"
        Me.NewClientNr_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewClientNr_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.NewClientNr_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NewClientNr_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NewClientNr_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NewClientNr_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.NewClientNr_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.NewClientNr_TextEdit.Properties.Mask.EditMask = "\d{18,18}"
        Me.NewClientNr_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.NewClientNr_TextEdit.Size = New System.Drawing.Size(229, 22)
        Me.NewClientNr_TextEdit.TabIndex = 17
        '
        'NewClientName_lbl
        '
        Me.NewClientName_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.NewClientName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewClientName_lbl.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.NewClientName_lbl.Appearance.Options.UseFont = True
        Me.NewClientName_lbl.Appearance.Options.UseForeColor = True
        Me.NewClientName_lbl.Location = New System.Drawing.Point(193, 157)
        Me.NewClientName_lbl.Name = "NewClientName_lbl"
        Me.NewClientName_lbl.Size = New System.Drawing.Size(0, 14)
        Me.NewClientName_lbl.TabIndex = 18
        '
        'CustomersMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 230)
        Me.Controls.Add(Me.NewClientName_lbl)
        Me.Controls.Add(Me.NewClientNr_TextEdit)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.OldClientName_lbl)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.OldClientNr_TextEdit)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Merge_DateEdit)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.OK_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomersMerge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Client Merging"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Merge_DateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Merge_DateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewClientNr_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents Cancel_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OK_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Merge_DateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OldClientNr_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OldClientName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents NewClientNr_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NewClientName_lbl As DevExpress.XtraEditors.LabelControl
End Class
