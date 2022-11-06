<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PSTOOL_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PSTOOL_Login))
        Me.UserNameLogin_txt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.UserPasswordLogin_txt = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Cancel1_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ConfirmInsertNewUser_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.Login_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.InsertNewUser_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.NewUserPassword_txt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.NewUserName_txt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.UserNameLogin_txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserPasswordLogin_txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.NewUserPassword_txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewUserName_txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserNameLogin_txt
        '
        Me.UserNameLogin_txt.Location = New System.Drawing.Point(102, 28)
        Me.UserNameLogin_txt.Name = "UserNameLogin_txt"
        Me.UserNameLogin_txt.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.UserNameLogin_txt.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.UserNameLogin_txt.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.UserNameLogin_txt.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.UserNameLogin_txt.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.UserNameLogin_txt.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.UserNameLogin_txt.Properties.Mask.EditMask = "[a-zA-Z]+"
        Me.UserNameLogin_txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.UserNameLogin_txt.Size = New System.Drawing.Size(155, 20)
        Me.UserNameLogin_txt.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(30, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "User Name"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(30, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Password"
        '
        'UserPasswordLogin_txt
        '
        Me.UserPasswordLogin_txt.Location = New System.Drawing.Point(102, 57)
        Me.UserPasswordLogin_txt.Name = "UserPasswordLogin_txt"
        Me.UserPasswordLogin_txt.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.UserPasswordLogin_txt.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.UserPasswordLogin_txt.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.UserPasswordLogin_txt.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.UserPasswordLogin_txt.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.UserPasswordLogin_txt.Properties.Mask.EditMask = ".+"
        Me.UserPasswordLogin_txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.UserPasswordLogin_txt.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPasswordLogin_txt.Size = New System.Drawing.Size(155, 20)
        Me.UserPasswordLogin_txt.TabIndex = 3
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Cancel1_btn)
        Me.GroupControl1.Controls.Add(Me.ConfirmInsertNewUser_btn)
        Me.GroupControl1.Controls.Add(Me.Login_btn)
        Me.GroupControl1.Controls.Add(Me.UserPasswordLogin_txt)
        Me.GroupControl1.Controls.Add(Me.UserNameLogin_txt)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(306, 123)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Login in Configuration"
        '
        'Cancel1_btn
        '
        Me.Cancel1_btn.ImageOptions.Image = CType(resources.GetObject("Cancel1_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.Cancel1_btn.Location = New System.Drawing.Point(226, 93)
        Me.Cancel1_btn.Name = "Cancel1_btn"
        Me.Cancel1_btn.Size = New System.Drawing.Size(75, 23)
        Me.Cancel1_btn.TabIndex = 6
        Me.Cancel1_btn.Text = "Cancel"
        '
        'ConfirmInsertNewUser_btn
        '
        Me.ConfirmInsertNewUser_btn.ImageOptions.Image = CType(resources.GetObject("ConfirmInsertNewUser_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.ConfirmInsertNewUser_btn.Location = New System.Drawing.Point(86, 93)
        Me.ConfirmInsertNewUser_btn.Name = "ConfirmInsertNewUser_btn"
        Me.ConfirmInsertNewUser_btn.Size = New System.Drawing.Size(134, 23)
        Me.ConfirmInsertNewUser_btn.TabIndex = 5
        Me.ConfirmInsertNewUser_btn.Text = "Insert New User"
        '
        'Login_btn
        '
        Me.Login_btn.ImageOptions.Image = CType(resources.GetObject("Login_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.Login_btn.Location = New System.Drawing.Point(5, 93)
        Me.Login_btn.Name = "Login_btn"
        Me.Login_btn.Size = New System.Drawing.Size(75, 23)
        Me.Login_btn.TabIndex = 4
        Me.Login_btn.Text = "Login"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl2.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl2.Controls.Add(Me.InsertNewUser_btn)
        Me.GroupControl2.Controls.Add(Me.NewUserPassword_txt)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.NewUserName_txt)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 141)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(306, 123)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Insert New Configuration User"
        '
        'InsertNewUser_btn
        '
        Me.InsertNewUser_btn.Enabled = False
        Me.InsertNewUser_btn.ImageOptions.Image = CType(resources.GetObject("InsertNewUser_btn.ImageOptions.Image"), System.Drawing.Image)
        Me.InsertNewUser_btn.Location = New System.Drawing.Point(102, 95)
        Me.InsertNewUser_btn.Name = "InsertNewUser_btn"
        Me.InsertNewUser_btn.Size = New System.Drawing.Size(155, 23)
        Me.InsertNewUser_btn.TabIndex = 19
        Me.InsertNewUser_btn.Text = "Confirm"
        '
        'NewUserPassword_txt
        '
        Me.NewUserPassword_txt.Enabled = False
        Me.NewUserPassword_txt.Location = New System.Drawing.Point(102, 63)
        Me.NewUserPassword_txt.Name = "NewUserPassword_txt"
        Me.NewUserPassword_txt.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NewUserPassword_txt.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NewUserPassword_txt.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NewUserPassword_txt.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.NewUserPassword_txt.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.NewUserPassword_txt.Properties.Mask.EditMask = ".+"
        Me.NewUserPassword_txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.NewUserPassword_txt.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NewUserPassword_txt.Size = New System.Drawing.Size(155, 20)
        Me.NewUserPassword_txt.TabIndex = 11
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 37)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "New User Name"
        '
        'NewUserName_txt
        '
        Me.NewUserName_txt.Enabled = False
        Me.NewUserName_txt.Location = New System.Drawing.Point(102, 34)
        Me.NewUserName_txt.Name = "NewUserName_txt"
        Me.NewUserName_txt.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NewUserName_txt.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NewUserName_txt.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NewUserName_txt.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.NewUserName_txt.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.NewUserName_txt.Properties.Mask.EditMask = "[a-zA-Z]+"
        Me.NewUserName_txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.NewUserName_txt.Size = New System.Drawing.Size(155, 20)
        Me.NewUserName_txt.TabIndex = 9
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 66)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "New Password"
        '
        'PSTOOL_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 269)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PSTOOL_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parameter Configuration Login"
        CType(Me.UserNameLogin_txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserPasswordLogin_txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.NewUserPassword_txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewUserName_txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UserNameLogin_txt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UserPasswordLogin_txt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Cancel1_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Login_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents InsertNewUser_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NewUserPassword_txt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NewUserName_txt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ConfirmInsertNewUser_btn As DevExpress.XtraEditors.SimpleButton
End Class
