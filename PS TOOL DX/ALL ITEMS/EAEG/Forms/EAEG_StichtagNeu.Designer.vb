<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EAEG_StichtagNeu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EAEG_StichtagNeu))
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Stichtag_Comboedit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.StichtagNeu_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Cancel_btn = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Stichtag_Comboedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ImageCollection1.InsertGalleryImage("play_16x16.png", "images/arrows/play_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/play_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "play_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("stop_16x16.png", "images/arrows/stop_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/stop_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "stop_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "cancel_16x16.png")
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl4.Appearance.Options.UseTextOptions = True
        Me.LabelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.Location = New System.Drawing.Point(114, 18)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(298, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Stichtag"
        '
        'Stichtag_Comboedit
        '
        Me.Stichtag_Comboedit.Location = New System.Drawing.Point(191, 37)
        Me.Stichtag_Comboedit.Name = "Stichtag_Comboedit"
        Me.Stichtag_Comboedit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Stichtag_Comboedit.Properties.Appearance.Options.UseFont = True
        Me.Stichtag_Comboedit.Properties.Appearance.Options.UseTextOptions = True
        Me.Stichtag_Comboedit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.Stichtag_Comboedit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Stichtag_Comboedit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Stichtag_Comboedit.Properties.DisplayFormat.FormatString = "d"
        Me.Stichtag_Comboedit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Stichtag_Comboedit.Properties.MaxLength = 8
        Me.Stichtag_Comboedit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.Stichtag_Comboedit.Size = New System.Drawing.Size(136, 26)
        Me.Stichtag_Comboedit.TabIndex = 3
        '
        'StichtagNeu_btn
        '
        Me.StichtagNeu_btn.ImageOptions.ImageIndex = 9
        Me.StichtagNeu_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.StichtagNeu_btn.Location = New System.Drawing.Point(12, 98)
        Me.StichtagNeu_btn.Name = "StichtagNeu_btn"
        Me.StichtagNeu_btn.Size = New System.Drawing.Size(283, 23)
        Me.StichtagNeu_btn.TabIndex = 5
        Me.StichtagNeu_btn.Text = "EAEG Stichtag erstellung (ERWEITERTE VERSION)"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.ImageOptions.ImageIndex = 11
        Me.Cancel_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Cancel_btn.Location = New System.Drawing.Point(347, 98)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(129, 23)
        Me.Cancel_btn.TabIndex = 6
        Me.Cancel_btn.Text = "Abrechen"
        '
        'EAEG_StichtagNeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 142)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.Cancel_btn)
        Me.Controls.Add(Me.StichtagNeu_btn)
        Me.Controls.Add(Me.Stichtag_Comboedit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "EAEG_StichtagNeu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EAEG - Daten erstellung"
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Stichtag_Comboedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Stichtag_Comboedit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents StichtagNeu_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cancel_btn As DevExpress.XtraEditors.SimpleButton
End Class
