Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraLayout.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports System.Security
Imports System.Security.Cryptography

Public Class PSTOOL_Login
    Public pc As New PSTOOL_MAIN_Form
    Dim connLOGIN As New SqlConnection
    Dim cmdLOGIN As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim QueryText As String
    Dim Cryptokey As String = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

   

    Private Sub PSTOOL_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connLOGIN.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdLOGIN.Connection = connLOGIN
    End Sub

    Sub New()
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(CurrentSkinName)
    End Sub

    Private Function GetKeyByteArray(ByVal sPassword As String) As Byte()
        Dim byteTemp(7) As Byte
        sPassword = sPassword.PadRight(8)   ' make sure we have 8 chars 
        Dim iCharIndex As Integer
        For iCharIndex = 0 To 7
            byteTemp(iCharIndex) = Asc(Mid$(sPassword, iCharIndex + 1, 1))
        Next
        Return byteTemp
    End Function



    Private Sub InsertNewUser_btn_Click(sender As Object, e As EventArgs) Handles InsertNewUser_btn.Click
        If IsNumeric(Me.NewUserName_txt.Text) = False And Len(Me.NewUserPassword_txt.Text) > 5 Then
            Dim UserName As String = Me.NewUserName_txt.Text
            Dim UserPassword As String = Me.NewUserPassword_txt.Text
            Try
                UserPassword = Crypto.Encrypt(UserPassword, Cryptokey)
                cmdLOGIN.CommandText = "INSERT INTO [LOGIN]([UserName],[Password]) VALUES('" & UserName & "','" & UserPassword & "')"
                cmdLOGIN.Connection.Open()
                cmdLOGIN.ExecuteNonQuery()
                cmdLOGIN.Connection.Close()
                MessageBox.Show("The User: " & UserName & " has being inserted", "NEW CONFIGURATIONS USER", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.NewUserName_txt.Text = ""
                Me.NewUserPassword_txt.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If


    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click
        Try
            If IsNumeric(Me.UserNameLogin_txt.Text) = False And Len(Me.UserPasswordLogin_txt.Text) > 5 Then
                Dim UserPassword As String = Me.UserPasswordLogin_txt.Text
                Dim SavedUserPassword As String = ""

                Me.QueryText = "Select * from [LOGIN]  where [UserName]='" & Me.UserNameLogin_txt.Text & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), connLOGIN)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        SavedUserPassword = dt.Rows.Item(0).Item("Password").ToString
                        SavedUserPassword = Crypto.Decrypt(SavedUserPassword, Cryptokey)
                    Next
                    If UserPassword = SavedUserPassword Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("CONFIGURATION")

                        Dim c As New Configuration
                        My.Forms.Configuration.MdiParent = My.Forms.PSTOOL_MAIN_Form
                        My.Forms.Configuration.Show()
                        My.Forms.Configuration.Focus()
                        My.Forms.Configuration.TopMost = True


                        SplashScreenManager.CloseForm(False)
                        Me.Hide()

                        My.Forms.PSTOOL_MAIN_Form.Tile_Vertical_BarButtonItem.PerformClick()


                    Else
                        MessageBox.Show("The Password is wrong!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("The User: " & Me.UserNameLogin_txt.Text & " is unknown!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Cancel1_btn_Click(sender As Object, e As EventArgs) Handles Cancel1_btn.Click
        Me.Close()

    End Sub

   
    Private Sub ConfirmInsertNewUser_btn_Click(sender As Object, e As EventArgs) Handles ConfirmInsertNewUser_btn.Click
        Try
            If IsNumeric(Me.UserNameLogin_txt.Text) = False And Len(Me.UserPasswordLogin_txt.Text) > 5 Then
                Dim UserPassword As String = Me.UserPasswordLogin_txt.Text
                Dim SavedUserPassword As String = ""

                Me.QueryText = "Select * from [LOGIN]  where [UserName]='" & Me.UserNameLogin_txt.Text & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), connLOGIN)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        SavedUserPassword = dt.Rows.Item(0).Item("Password").ToString
                        SavedUserPassword = Crypto.Decrypt(SavedUserPassword, Cryptokey)
                    Next
                    If UserPassword = SavedUserPassword Then
                        Me.NewUserName_txt.Enabled = True
                        Me.NewUserPassword_txt.Enabled = True
                        Me.InsertNewUser_btn.Enabled = True
                        Me.NewUserName_txt.Focus()

                    Else
                        MessageBox.Show("The Password is wrong!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("The User: " & Me.UserNameLogin_txt.Text & " is unknown!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class