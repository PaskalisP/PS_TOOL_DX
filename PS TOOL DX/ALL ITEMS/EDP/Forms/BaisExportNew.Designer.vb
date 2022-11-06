<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaisExportNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaisExportNew))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.BgwBaisFilesCreation = New System.ComponentModel.BackgroundWorker()
        Me.OpenFolder_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckAll_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.BaisExportEvents_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.StartFileCreation_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.WHGIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.WHGIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.DESIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DESIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.KRKIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.KRKIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.LQKIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LQKIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GAGIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GAGIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GAKIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GAKIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.ZUSIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.MKUIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.ZUSIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.MKUIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.LQGIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.KSRIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.KNVIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.LQGIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.KSRIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.KNEIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.KGCIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.KNVIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.KNEIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.KGCIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.BILIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.BILIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GSTSLF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GSTIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.DVTIFF_Result_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.GSTSLF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.GSTIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.DVTIFF_CheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BusinessDate_Comboedit = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.WHGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KRKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LQKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZUSIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MKUIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LQGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KSRIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KNVIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KNEIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KGCIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BILIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSTSLF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GSTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DVTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BusinessDate_Comboedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'OpenFolder_btn
        '
        Me.OpenFolder_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFolder_btn.ImageIndex = 11
        Me.OpenFolder_btn.ImageList = Me.ImageCollection1
        Me.OpenFolder_btn.Location = New System.Drawing.Point(624, 574)
        Me.OpenFolder_btn.Name = "OpenFolder_btn"
        Me.OpenFolder_btn.Size = New System.Drawing.Size(151, 23)
        Me.OpenFolder_btn.TabIndex = 17
        Me.OpenFolder_btn.Text = "Open creation Folder"
        '
        'CheckAll_btn
        '
        Me.CheckAll_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckAll_btn.ImageIndex = 10
        Me.CheckAll_btn.ImageList = Me.ImageCollection1
        Me.CheckAll_btn.Location = New System.Drawing.Point(25, 574)
        Me.CheckAll_btn.Name = "CheckAll_btn"
        Me.CheckAll_btn.Size = New System.Drawing.Size(104, 23)
        Me.CheckAll_btn.TabIndex = 15
        Me.CheckAll_btn.Text = "Check All"
        '
        'BaisExportEvents_RichTextBox
        '
        Me.BaisExportEvents_RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BaisExportEvents_RichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BaisExportEvents_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BaisExportEvents_RichTextBox.DetectUrls = False
        Me.BaisExportEvents_RichTextBox.Location = New System.Drawing.Point(33, 253)
        Me.BaisExportEvents_RichTextBox.Name = "BaisExportEvents_RichTextBox"
        Me.BaisExportEvents_RichTextBox.ReadOnly = True
        Me.BaisExportEvents_RichTextBox.Size = New System.Drawing.Size(742, 315)
        Me.BaisExportEvents_RichTextBox.TabIndex = 14
        Me.BaisExportEvents_RichTextBox.TabStop = False
        Me.BaisExportEvents_RichTextBox.Text = ""
        '
        'StartFileCreation_btn
        '
        Me.StartFileCreation_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.StartFileCreation_btn.ImageIndex = 9
        Me.StartFileCreation_btn.ImageList = Me.ImageCollection1
        Me.StartFileCreation_btn.Location = New System.Drawing.Point(296, 574)
        Me.StartFileCreation_btn.Name = "StartFileCreation_btn"
        Me.StartFileCreation_btn.Size = New System.Drawing.Size(175, 23)
        Me.StartFileCreation_btn.TabIndex = 16
        Me.StartFileCreation_btn.Text = "Create selected BAIS Files"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.WHGIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.WHGIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.DESIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.DESIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.KRKIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.KRKIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.LQKIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.LQKIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GAGIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GAGIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GAKIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GAKIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.ZUSIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.MKUIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.ZUSIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.MKUIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.LQGIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.KSRIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.KNVIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.LQGIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.KSRIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.KNEIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.KGCIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.KNVIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.KNEIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.KGCIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.BILIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.BILIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GSTSLF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GSTIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.DVTIFF_Result_lbl)
        Me.GroupControl1.Controls.Add(Me.GSTSLF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.GSTIFF_CheckEdit)
        Me.GroupControl1.Controls.Add(Me.DVTIFF_CheckEdit)
        Me.GroupControl1.Location = New System.Drawing.Point(33, 65)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(742, 182)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "BAIS Files for creation - Creation Path:"
        '
        'WHGIFF_Result_lbl
        '
        Me.WHGIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.WHGIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.WHGIFF_Result_lbl.Location = New System.Drawing.Point(674, 73)
        Me.WHGIFF_Result_lbl.Name = "WHGIFF_Result_lbl"
        Me.WHGIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.WHGIFF_Result_lbl.TabIndex = 36
        '
        'WHGIFF_CheckEdit
        '
        Me.WHGIFF_CheckEdit.Location = New System.Drawing.Point(564, 68)
        Me.WHGIFF_CheckEdit.Name = "WHGIFF_CheckEdit"
        Me.WHGIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WHGIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.WHGIFF_CheckEdit.Properties.Caption = "WHGIFF File"
        Me.WHGIFF_CheckEdit.Size = New System.Drawing.Size(104, 22)
        Me.WHGIFF_CheckEdit.TabIndex = 35
        '
        'DESIFF_Result_lbl
        '
        Me.DESIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.DESIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.DESIFF_Result_lbl.Location = New System.Drawing.Point(674, 44)
        Me.DESIFF_Result_lbl.Name = "DESIFF_Result_lbl"
        Me.DESIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.DESIFF_Result_lbl.TabIndex = 34
        '
        'DESIFF_CheckEdit
        '
        Me.DESIFF_CheckEdit.Location = New System.Drawing.Point(564, 39)
        Me.DESIFF_CheckEdit.Name = "DESIFF_CheckEdit"
        Me.DESIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DESIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.DESIFF_CheckEdit.Properties.Caption = "DESIFF File"
        Me.DESIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.DESIFF_CheckEdit.TabIndex = 33
        '
        'KRKIFF_Result_lbl
        '
        Me.KRKIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.KRKIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.KRKIFF_Result_lbl.Location = New System.Drawing.Point(295, 97)
        Me.KRKIFF_Result_lbl.Name = "KRKIFF_Result_lbl"
        Me.KRKIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.KRKIFF_Result_lbl.TabIndex = 32
        '
        'KRKIFF_CheckEdit
        '
        Me.KRKIFF_CheckEdit.Location = New System.Drawing.Point(186, 92)
        Me.KRKIFF_CheckEdit.Name = "KRKIFF_CheckEdit"
        Me.KRKIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KRKIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.KRKIFF_CheckEdit.Properties.Caption = "KRKIFF File"
        Me.KRKIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.KRKIFF_CheckEdit.TabIndex = 10
        '
        'LQKIFF_Result_lbl
        '
        Me.LQKIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.LQKIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.LQKIFF_Result_lbl.Location = New System.Drawing.Point(493, 152)
        Me.LQKIFF_Result_lbl.Name = "LQKIFF_Result_lbl"
        Me.LQKIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.LQKIFF_Result_lbl.TabIndex = 30
        '
        'LQKIFF_CheckEdit
        '
        Me.LQKIFF_CheckEdit.Location = New System.Drawing.Point(377, 146)
        Me.LQKIFF_CheckEdit.Name = "LQKIFF_CheckEdit"
        Me.LQKIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LQKIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.LQKIFF_CheckEdit.Properties.Caption = "LQKIFF File"
        Me.LQKIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.LQKIFF_CheckEdit.TabIndex = 17
        '
        'GAGIFF_Result_lbl
        '
        Me.GAGIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GAGIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.GAGIFF_Result_lbl.Location = New System.Drawing.Point(493, 126)
        Me.GAGIFF_Result_lbl.Name = "GAGIFF_Result_lbl"
        Me.GAGIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GAGIFF_Result_lbl.TabIndex = 28
        '
        'GAGIFF_CheckEdit
        '
        Me.GAGIFF_CheckEdit.Location = New System.Drawing.Point(377, 118)
        Me.GAGIFF_CheckEdit.Name = "GAGIFF_CheckEdit"
        Me.GAGIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GAGIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.GAGIFF_CheckEdit.Properties.Caption = "GAGIFF File"
        Me.GAGIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.GAGIFF_CheckEdit.TabIndex = 16
        '
        'GAKIFF_Result_lbl
        '
        Me.GAKIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GAKIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.GAKIFF_Result_lbl.Location = New System.Drawing.Point(493, 99)
        Me.GAKIFF_Result_lbl.Name = "GAKIFF_Result_lbl"
        Me.GAKIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GAKIFF_Result_lbl.TabIndex = 26
        '
        'GAKIFF_CheckEdit
        '
        Me.GAKIFF_CheckEdit.Location = New System.Drawing.Point(377, 91)
        Me.GAKIFF_CheckEdit.Name = "GAKIFF_CheckEdit"
        Me.GAKIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GAKIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.GAKIFF_CheckEdit.Properties.Caption = "GAKIFF File"
        Me.GAKIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.GAKIFF_CheckEdit.TabIndex = 15
        '
        'ZUSIFF_Result_lbl
        '
        Me.ZUSIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.ZUSIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.ZUSIFF_Result_lbl.Location = New System.Drawing.Point(493, 70)
        Me.ZUSIFF_Result_lbl.Name = "ZUSIFF_Result_lbl"
        Me.ZUSIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.ZUSIFF_Result_lbl.TabIndex = 24
        '
        'MKUIFF_Result_lbl
        '
        Me.MKUIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.MKUIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.MKUIFF_Result_lbl.Location = New System.Drawing.Point(492, 41)
        Me.MKUIFF_Result_lbl.Name = "MKUIFF_Result_lbl"
        Me.MKUIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.MKUIFF_Result_lbl.TabIndex = 23
        '
        'ZUSIFF_CheckEdit
        '
        Me.ZUSIFF_CheckEdit.Location = New System.Drawing.Point(377, 62)
        Me.ZUSIFF_CheckEdit.Name = "ZUSIFF_CheckEdit"
        Me.ZUSIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZUSIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.ZUSIFF_CheckEdit.Properties.Caption = "ZUSIFF File"
        Me.ZUSIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.ZUSIFF_CheckEdit.TabIndex = 14
        '
        'MKUIFF_CheckEdit
        '
        Me.MKUIFF_CheckEdit.Location = New System.Drawing.Point(377, 37)
        Me.MKUIFF_CheckEdit.Name = "MKUIFF_CheckEdit"
        Me.MKUIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MKUIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.MKUIFF_CheckEdit.Properties.Caption = "MKUIFF File"
        Me.MKUIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.MKUIFF_CheckEdit.TabIndex = 13
        '
        'LQGIFF_Result_lbl
        '
        Me.LQGIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.LQGIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.LQGIFF_Result_lbl.Location = New System.Drawing.Point(295, 151)
        Me.LQGIFF_Result_lbl.Name = "LQGIFF_Result_lbl"
        Me.LQGIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.LQGIFF_Result_lbl.TabIndex = 20
        '
        'KSRIFF_Result_lbl
        '
        Me.KSRIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.KSRIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.KSRIFF_Result_lbl.Location = New System.Drawing.Point(295, 126)
        Me.KSRIFF_Result_lbl.Name = "KSRIFF_Result_lbl"
        Me.KSRIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.KSRIFF_Result_lbl.TabIndex = 19
        '
        'KNVIFF_Result_lbl
        '
        Me.KNVIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.KNVIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.KNVIFF_Result_lbl.Location = New System.Drawing.Point(295, 70)
        Me.KNVIFF_Result_lbl.Name = "KNVIFF_Result_lbl"
        Me.KNVIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.KNVIFF_Result_lbl.TabIndex = 18
        '
        'LQGIFF_CheckEdit
        '
        Me.LQGIFF_CheckEdit.Location = New System.Drawing.Point(186, 146)
        Me.LQGIFF_CheckEdit.Name = "LQGIFF_CheckEdit"
        Me.LQGIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LQGIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.LQGIFF_CheckEdit.Properties.Caption = "LQGIFF File"
        Me.LQGIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.LQGIFF_CheckEdit.TabIndex = 12
        '
        'KSRIFF_CheckEdit
        '
        Me.KSRIFF_CheckEdit.Location = New System.Drawing.Point(186, 120)
        Me.KSRIFF_CheckEdit.Name = "KSRIFF_CheckEdit"
        Me.KSRIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KSRIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.KSRIFF_CheckEdit.Properties.Caption = "KSRIFF File"
        Me.KSRIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.KSRIFF_CheckEdit.TabIndex = 11
        '
        'KNEIFF_Result_lbl
        '
        Me.KNEIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.KNEIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.KNEIFF_Result_lbl.Location = New System.Drawing.Point(295, 41)
        Me.KNEIFF_Result_lbl.Name = "KNEIFF_Result_lbl"
        Me.KNEIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.KNEIFF_Result_lbl.TabIndex = 15
        '
        'KGCIFF_Result_lbl
        '
        Me.KGCIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.KGCIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.KGCIFF_Result_lbl.Location = New System.Drawing.Point(126, 152)
        Me.KGCIFF_Result_lbl.Name = "KGCIFF_Result_lbl"
        Me.KGCIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.KGCIFF_Result_lbl.TabIndex = 14
        '
        'KNVIFF_CheckEdit
        '
        Me.KNVIFF_CheckEdit.Location = New System.Drawing.Point(186, 65)
        Me.KNVIFF_CheckEdit.Name = "KNVIFF_CheckEdit"
        Me.KNVIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KNVIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.KNVIFF_CheckEdit.Properties.Caption = "KNVIFF File"
        Me.KNVIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.KNVIFF_CheckEdit.TabIndex = 9
        '
        'KNEIFF_CheckEdit
        '
        Me.KNEIFF_CheckEdit.Location = New System.Drawing.Point(186, 37)
        Me.KNEIFF_CheckEdit.Name = "KNEIFF_CheckEdit"
        Me.KNEIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KNEIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.KNEIFF_CheckEdit.Properties.Caption = "KNEIFF File"
        Me.KNEIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.KNEIFF_CheckEdit.TabIndex = 8
        '
        'KGCIFF_CheckEdit
        '
        Me.KGCIFF_CheckEdit.Location = New System.Drawing.Point(16, 147)
        Me.KGCIFF_CheckEdit.Name = "KGCIFF_CheckEdit"
        Me.KGCIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KGCIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.KGCIFF_CheckEdit.Properties.Caption = "KGCIFF File"
        Me.KGCIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.KGCIFF_CheckEdit.TabIndex = 7
        '
        'BILIFF_Result_lbl
        '
        Me.BILIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.BILIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.BILIFF_Result_lbl.Location = New System.Drawing.Point(126, 124)
        Me.BILIFF_Result_lbl.Name = "BILIFF_Result_lbl"
        Me.BILIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.BILIFF_Result_lbl.TabIndex = 10
        '
        'BILIFF_CheckEdit
        '
        Me.BILIFF_CheckEdit.Location = New System.Drawing.Point(16, 119)
        Me.BILIFF_CheckEdit.Name = "BILIFF_CheckEdit"
        Me.BILIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BILIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.BILIFF_CheckEdit.Properties.Caption = "BILIFF File"
        Me.BILIFF_CheckEdit.Size = New System.Drawing.Size(97, 22)
        Me.BILIFF_CheckEdit.TabIndex = 6
        '
        'GSTSLF_Result_lbl
        '
        Me.GSTSLF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GSTSLF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.GSTSLF_Result_lbl.Location = New System.Drawing.Point(126, 97)
        Me.GSTSLF_Result_lbl.Name = "GSTSLF_Result_lbl"
        Me.GSTSLF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GSTSLF_Result_lbl.TabIndex = 8
        '
        'GSTIFF_Result_lbl
        '
        Me.GSTIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.GSTIFF_Result_lbl.Appearance.Options.UseForeColor = True
        Me.GSTIFF_Result_lbl.Location = New System.Drawing.Point(126, 69)
        Me.GSTIFF_Result_lbl.Name = "GSTIFF_Result_lbl"
        Me.GSTIFF_Result_lbl.Size = New System.Drawing.Size(0, 13)
        Me.GSTIFF_Result_lbl.TabIndex = 7
        '
        'DVTIFF_Result_lbl
        '
        Me.DVTIFF_Result_lbl.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.DVTIFF_Result_lbl.Appearance.Options.UseForeColor = True
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
        Me.GSTSLF_CheckEdit.TabIndex = 5
        '
        'GSTIFF_CheckEdit
        '
        Me.GSTIFF_CheckEdit.Location = New System.Drawing.Point(16, 63)
        Me.GSTIFF_CheckEdit.Name = "GSTIFF_CheckEdit"
        Me.GSTIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GSTIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.GSTIFF_CheckEdit.Properties.Caption = "GSTIFF File"
        Me.GSTIFF_CheckEdit.Size = New System.Drawing.Size(102, 22)
        Me.GSTIFF_CheckEdit.TabIndex = 4
        '
        'DVTIFF_CheckEdit
        '
        Me.DVTIFF_CheckEdit.Location = New System.Drawing.Point(16, 35)
        Me.DVTIFF_CheckEdit.Name = "DVTIFF_CheckEdit"
        Me.DVTIFF_CheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DVTIFF_CheckEdit.Properties.Appearance.Options.UseFont = True
        Me.DVTIFF_CheckEdit.Properties.Caption = "DVTIFF File"
        Me.DVTIFF_CheckEdit.Size = New System.Drawing.Size(102, 22)
        Me.DVTIFF_CheckEdit.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl4.Location = New System.Drawing.Point(396, 5)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl4.TabIndex = 0
        Me.LabelControl4.Text = "Business Date"
        '
        'BusinessDate_Comboedit
        '
        Me.BusinessDate_Comboedit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BusinessDate_Comboedit.Location = New System.Drawing.Point(359, 24)
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
        Me.BusinessDate_Comboedit.TabIndex = 1
        '
        'BaisExportNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 609)
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
        Me.Name = "BaisExportNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bais Export (Version 1.21 - 1.22)"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.WHGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KRKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LQKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAKIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZUSIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MKUIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LQGIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KSRIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KNVIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KNEIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KGCIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BILIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSTSLF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GSTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DVTIFF_CheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BusinessDate_Comboedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents BgwBaisFilesCreation As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFolder_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckAll_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BaisExportEvents_RichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents StartFileCreation_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BILIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BILIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GSTSLF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GSTIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DVTIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GSTSLF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GSTIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DVTIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BusinessDate_Comboedit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LQGIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KSRIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KNEIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents KGCIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents KNVIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KNEIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KGCIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KSRIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents KNVIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ZUSIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MKUIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ZUSIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents MKUIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LQGIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GAGIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GAGIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GAKIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GAKIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LQKIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LQKIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents KRKIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents KRKIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DESIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents WHGIFF_Result_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WHGIFF_CheckEdit As DevExpress.XtraEditors.CheckEdit
End Class
