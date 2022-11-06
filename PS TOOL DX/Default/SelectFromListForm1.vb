Imports System
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports Ionic.Zip
Public Class SelectFromListForm1

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEvent As New SqlConnection
    Dim cmdEvent As New SqlCommand

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

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

    Private Sub SelectFromListForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckedListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxControl1.SelectedIndexChanged

        'Dim valMember As String = CheckedListBoxControl1.ValueMember
        'Dim dispMember As String = CheckedListBoxControl1.DisplayMember
        'For Each item As DataRowView In CheckedListBoxControl1.CheckedItems
        '    Dim value As Object = item.Row(valMember)
        '    Dim display As Object = item.Row(dispMember)
        '    MessageBox.Show(value.ToString() & "; " & display.ToString())
        'Next item

    End Sub

    Private Sub CheckedListBoxControl1_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles CheckedListBoxControl1.ItemCheck
        If e.State = CheckState.Checked Then
            'MsgBox(e.Index.ToString)
            Dim test As Date = CheckedListBoxControl1.GetItemText(e.Index.ToString)
            'MsgBox(test)
            Me.ListBoxControl1.Items.Add(test)
            Me.ListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Descending

        End If
        If e.State = CheckState.Unchecked Then
            'MsgBox(e.Index.ToString)
            Dim test As Date = CheckedListBoxControl1.GetItemText(e.Index.ToString)
            'MsgBox(test)
            Me.ListBoxControl1.Items.Remove(test)
            Me.ListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Descending
        End If

        'For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In CheckedListBoxControl1.CheckedItems

        '    Me.ListBoxControl1.Items.Add(item.Value.ToString)
        'Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click


    End Sub

    Private Sub CheckedListBoxControl1_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles CheckedListBoxControl1.DrawItem
        If (e.State And DrawItemState.Selected) <> 0 Then
            e.Appearance.ForeColor = Color.Yellow
        End If

        If e.State <> 0 Then
            e.Appearance.ForeColor = Color.Cyan
        End If

    End Sub

    Private Sub ListBoxControl1_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles ListBoxControl1.DrawItem
        e.Appearance.ForeColor = Color.Yellow
        Dim d As Date = Convert.ToDateTime(ListBoxControl1.GetItemText(e.Index.ToString))
        Dim s As String = d.ToString("dd.MM.yyyy")
        e.Appearance.DrawBackground(e.Cache, e.Bounds)
        e.Graphics.DrawString(s, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds.Location)
        e.Handled = True


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.CheckedListBoxControl1.CheckAll()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.CheckedListBoxControl1.UnCheckAll()
    End Sub
End Class