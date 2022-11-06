<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaisExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaisExport))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.BgwBaisFilesCreation = New System.ComponentModel.BackgroundWorker()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BusinessDate_Comboedit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.BILIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.BILIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GSTSLF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GSTIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DVTIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GSTSLF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GSTIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.DVTIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.StartFileCreation_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.BaisExportEvents_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.CheckAll_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.OpenFolder_btn = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessDate_Comboedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.BILIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSTSLF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DVTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ImageCollection1.Images.SetKeyName(5, "Report.ico")
        Me.ImageCollection1.Images.SetKeyName(6, "Load.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "CrystalReport.jpg")
        Me.ImageCollection1.Images.SetKeyName(8, "save.ico")
        Me.ImageCollection1.InsertGalleryImage("exporttocsv_16x16.png", "images/export/exporttocsv_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttocsv_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "exporttocsv_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("checkbox_16x16.png", "images/content/checkbox_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/checkbox_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "checkbox_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "open_16x16.png")
        '
        'BgwBaisFilesCreation
        '
        Me.BgwBaisFilesCreation.WorkerReportsProgress = True
        Me.BgwBaisFilesCreation.WorkerSupportsCancellation = True
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl4.Location = New System.Drawing.Point(235, 23)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Business Date"
        '
        'BusinessDate_Comboedit
        '
        Me.BusinessDate_Comboedit.Location = New System.Drawing.Point(198, 42)
        Me.BusinessDate_Comboedit.Name = "BusinessDate_Comboedit"
        Me.BusinessDate_Comboedit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BusinessDate_Comboedit.Properties.Appearance.Options.UseFont = True
        Me.BusinessDate_Comboedit.Properties.Appearance.Options.UseTextOptions = True
        Me.BusinessDate_Comboedit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.BusinessDate_Comboedit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BusinessDate_Comboedit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BusinessDate_Comboedit.Properties.DisplayFormat.FormatString = "d"
        Me.BusinessDate_Comboedit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BusinessDate_Comboedit.Properties.MaxLength = 8
        Me.BusinessDate_Comboedit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.BusinessDate_Comboedit.Size = New System.Drawing.Size(136, 26)
        Me.BusinessDate_Comboedit.TabIndex = 6
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.BILIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.BILIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GSTSLF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GSTIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.DVTIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GSTSLF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GSTIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.DVTIFF_CheckEdit)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 81)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(545, 134)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "BAIS Files for creation - Creation Path:"
        '
        'BILIFF_Result_lbl
        '
        Me.BILIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.BILIFF_Result_lbl.Location = New System.Drawing.Point(284, 40)
        Me.BILIFF_Result_lbl.Name = "BILIFF_Result_lbl"
        Me.BILIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.BILIFF_Result_lbl.TabIndex = 10
        '
        'BILIFF_CheckEdit
        '
        Me.BILIFF_CheckEdit.Location = New System.Drawing.Point(177, 35)
        Me.BILIFF_CheckEdit.Name = "BILIFF_CheckEdit"
        Me.BILIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BILIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.BILIFF_CheckEdit.Properties.Caption = "BILIFF File"
        Me.BILIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.BILIFF_CheckEdit.TabIndex = 9
        '
        'GSTSLF_Result_lbl
        '
        Me.GSTSLF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GSTSLF_Result_lbl.Location = New System.Drawing.Point(126, 97)
        Me.GSTSLF_Result_lbl.Name = "GSTSLF_Result_lbl"
        Me.GSTSLF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GSTSLF_Result_lbl.TabIndex = 8
        '
        'GSTIFF_Result_lbl
        '
        Me.GSTIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GSTIFF_Result_lbl.Location = New System.Drawing.Point(126, 69)
        Me.GSTIFF_Result_lbl.Name = "GSTIFF_Result_lbl"
        Me.GSTIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GSTIFF_Result_lbl.TabIndex = 7
        '
        'DVTIFF_Result_lbl
        '
        Me.DVTIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.DVTIFF_Result_lbl.Location = New System.Drawing.Point(126, 41)
        Me.DVTIFF_Result_lbl.Name = "DVTIFF_Result_lbl"
        Me.DVTIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.DVTIFF_Result_lbl.TabIndex = 6
        '
        'GSTSLF_CheckEdit
        '
        Me.GSTSLF_CheckEdit.Location = New System.Drawing.Point(16, 91)
        Me.GSTSLF_CheckEdit.Name = "GSTSLF_CheckEdit"
        Me.GSTSLF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GSTSLF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.GSTSLF_CheckEdit.Properties.Caption = "GSTSLF File"
        Me.GSTSLF_CheckEdit.Size = New System.Drawing.Size(102, 22)
        Me.GSTSLF_CheckEdit.TabIndex = 2
        '
        'GSTIFF_CheckEdit
        '
        Me.GSTIFF_CheckEdit.Location = New System.Drawing.Point(16, 63)
        Me.GSTIFF_CheckEdit.Name = "GSTIFF_CheckEdit"
        Me.GSTIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GSTIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.GSTIFF_CheckEdit.Properties.Caption = "GSTIFF File"
        Me.GSTIFF_CheckEdit.Size = New System.Drawing.Size(102, 22)
        Me.GSTIFF_CheckEdit.TabIndex = 1
        '
        'DVTIFF_CheckEdit
        '
        Me.DVTIFF_CheckEdit.Location = New System.Drawing.Point(16, 35)
        Me.DVTIFF_CheckEdit.Name = "DVTIFF_CheckEdit"
        Me.DVTIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DVTIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.DVTIFF_CheckEdit.Properties.Caption = "DVTIFF File"
        Me.DVTIFF_CheckEdit.Size = New System.Drawing.Size(102, 22)
        Me.DVTIFF_CheckEdit.TabIndex = 0
        '
        'StartFileCreation_btn
        '
        Me.StartFileCreation_btn.ImageIndex = 9
        Me.StartFileCreation_btn.ImageList = Me.ImageCollection1
        Me.StartFileCreation_btn.Location = New System.Drawing.Point(182, 479)
        Me.StartFileCreation_btn.Name = "StartFileCreation_btn"
        Me.StartFileCreation_btn.Size = New System.Drawing.Size(158, 23)
        Me.StartFileCreation_btn.TabIndex = 11
        Me.StartFileCreation_btn.Text = "Create selected BAIS Files"
        '
        'BaisExportEvents_RichTextBox
        '
        Me.BaisExportEvents_RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BaisExportEvents_RichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BaisExportEvents_RichTextBox.DetectUrls = False
        Me.BaisExportEvents_RichTextBox.Location = New System.Drawing.Point(12, 221)
        Me.BaisExportEvents_RichTextBox.Name = "BaisExportEvents_RichTextBox"
        Me.BaisExportEvents_RichTextBox.ReadOnly = True
        Me.BaisExportEvents_RichTextBox.Size = New System.Drawing.Size(545, 252)
        Me.BaisExportEvents_RichTextBox.TabIndex = 9
        Me.BaisExportEvents_RichTextBox.Text = ""
        '
        'CheckAll_btn
        '
        Me.CheckAll_btn.ImageIndex = 10
        Me.CheckAll_btn.ImageList = Me.ImageCollection1
        Me.CheckAll_btn.Location = New System.Drawing.Point(12, 479)
        Me.CheckAll_btn.Name = "CheckAll_btn"
        Me.CheckAll_btn.Size = New System.Drawing.Size(104, 23)
        Me.CheckAll_btn.TabIndex = 10
        Me.CheckAll_btn.Text = "Check All"
        '
        'OpenFolder_btn
        '
        Me.OpenFolder_btn.ImageIndex = 11
        Me.OpenFolder_btn.ImageList = Me.ImageCollection1
        Me.OpenFolder_btn.Location = New System.Drawing.Point(406, 479)
        Me.OpenFolder_btn.Name = "OpenFolder_btn"
        Me.OpenFolder_btn.Size = New System.Drawing.Size(151, 23)
        Me.OpenFolder_btn.TabIndex = 12
        Me.OpenFolder_btn.Text = "Open creation Folder"
        '
        'BaisExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 514)
        Me.Controls.Add(Me.OpenFolder_btn)
        Me.Controls.Add(Me.CheckAll_btn)
        Me.Controls.Add(Me.BaisExportEvents_RichTextBox)
        Me.Controls.Add(Me.StartFileCreation_btn)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.BusinessDate_Comboedit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "BaisExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bais Export (Version 1.19)"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessDate_Comboedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.BILIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSTSLF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DVTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BgwBaisFilesCreation As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BusinessDate_Comboedit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GSTIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DVTIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents StartFileCreation_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GSTSLF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GSTSLF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GSTIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DVTIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BILIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BILIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BaisExportEvents_RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents CheckAll_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents OpenFolder_btn As DevExpress.XtraEditors.SimpleButton
End Class
