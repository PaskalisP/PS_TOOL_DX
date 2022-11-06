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
Imports DevExpress.XtraEditors.ImageComboBoxEdit
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
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Public Class CustomersAdd

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable


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

    Private Sub CustomersAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
    End Sub

    Private Sub BIC_CODE_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BIC_CODE_TextEdit.EditValueChanged
        If Len(BIC_CODE_TextEdit.Text) = 11 Then
            Dim BICCODE As String = BIC_CODE_TextEdit.Text
            cmd.CommandText = "SELECT LTRIM(RTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',LTRIM(RTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.BIC_CODE_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
                'Get LEI CODE
                cmd.CommandText = "SELECT [ISO_LEI_CODE] from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and [ISO_LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    Me.LEI_Code_TextEdit.Text = dt1.Rows.Item(0).Item("ISO_LEI_CODE")
                End If
            Else
                MessageBox.Show("BIC CODE:" & BICCODE & " not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                BIC_CODE_TextEdit.Text = Nothing
                Me.BIC_CODE_lbl.Text = Nothing
                Me.LEI_Code_TextEdit.Text = Nothing
            End If
        Else
            Me.BIC_CODE_lbl.Text = Nothing
            Me.LEI_Code_TextEdit.Text = Nothing
        End If
    End Sub

    Private Sub BIC_CODE_TextEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles BIC_CODE_TextEdit.EditValueChanging
        If Len(BIC_CODE_TextEdit.Text) = 11 Then
            Dim BICCODE As String = BIC_CODE_TextEdit.Text
            cmd.CommandText = "SELECT LTRIM(RTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',LTRIM(RTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.BIC_CODE_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
                'Get LEI CODE
                cmd.CommandText = "SELECT [ISO_LEI_CODE] from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and [ISO_LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    Me.LEI_Code_TextEdit.Text = dt1.Rows.Item(0).Item("ISO_LEI_CODE")
                End If
            Else
                MessageBox.Show("BIC CODE:" & BICCODE & " not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                BIC_CODE_TextEdit.Text = Nothing
                Me.BIC_CODE_lbl.Text = Nothing
                Me.LEI_Code_TextEdit.Text = Nothing
            End If
        Else
            Me.BIC_CODE_lbl.Text = Nothing
            Me.LEI_Code_TextEdit.Text = Nothing
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.Close()

    End Sub

   
    Private Sub CCB_Group_ImageComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CCB_Group_ImageComboBoxEdit.SelectedIndexChanged
        CCB_Group = Me.CCB_Group_ImageComboBoxEdit.EditValue.ToString
    End Sub

    Private Sub CCB_Group_OwnID_ImageComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CCB_Group_OwnID_ImageComboBoxEdit.SelectedIndexChanged
        CCB_Group_Own_ID = Me.CCB_Group_OwnID_ImageComboBoxEdit.EditValue.ToString
    End Sub

    Private Sub CIC_Group_ImageComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CIC_Group_ImageComboBoxEdit.SelectedIndexChanged
        CIC_Group = Me.CIC_Group_ImageComboBoxEdit.EditValue.ToString
    End Sub
End Class