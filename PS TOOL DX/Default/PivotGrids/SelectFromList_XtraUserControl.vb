Imports System
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
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
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.Spreadsheet
Imports Ionic.Zip

Public Class SelectFromList_XtraUserControl

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private objDataTable As New DataTable

    Dim d1 As Date
    Dim d2 As Date
    Dim rdsql1 As String
    Dim rdsql2 As String

    Private Sub SelectFromList_XtraUserControl_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Me.Name = "Liquidity Overview - Pivot" Then
            Me.QueryText = "DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    Select CONVERT(VARCHAR(10),[RLDC Date],104) from [RISK LIMIT DAILY CONTROL] 
                                                    where  [PL Result] is not NULL  ORDER BY [ID] desc
                                                    SELECT BUSINESS_DATE  from @SELECTION_TABLE 
                                                    order by ID asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            With CheckedListBoxControl1
                .DataSource = dt
                .DisplayMember = "BUSINESS_DATE"
            End With
        End If



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

        'Selected Dates
        If Me.ListBoxControl1.Items.Count = 1 Then
            For i = 0 To Me.ListBoxControl1.Items.Count - 1
                Dim d As Date = Me.ListBoxControl1.Items(i).ToString
                Dim dsql As String = d.ToString("yyyyMMdd")
                SELECTED_DATES = "'" & dsql & "'"
            Next
        ElseIf Me.ListBoxControl1.Items.Count > 1 Then
            Dim arr As String() = New String(Me.ListBoxControl1.Items.Count - 1) {}
            Dim DateArr As String() = New String(Me.ListBoxControl1.Items.Count - 1) {}
            For i = 0 To Me.ListBoxControl1.Items.Count - 1
                Dim d As Date = Me.ListBoxControl1.Items(i).ToString
                Dim dsql As String = d.ToString("yyyyMMdd")
                DateArr(i) = d
                arr(i) = "'" & dsql & "'"
            Next
            SELECTED_DATES = String.Join(",", arr)

        End If
    End Sub

    Private Sub CheckedListBoxControl1_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles CheckedListBoxControl1.DrawItem
        If (e.State And DrawItemState.Selected) <> 0 Then
            e.Appearance.ForeColor = Color.White
        End If

        If e.State <> 0 Then
            e.Appearance.ForeColor = Color.Cyan
        End If

    End Sub

    Private Sub ListBoxControl1_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles ListBoxControl1.DrawItem
        e.Appearance.ForeColor = Color.Cyan
        Dim d As Date = Convert.ToDateTime(ListBoxControl1.GetItemText(e.Index.ToString))
        Dim s As String = d.ToString("dd.MM.yyyy")
        e.Appearance.DrawBackground(e.Cache, e.Bounds)
        e.Graphics.DrawString(s, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds.Location)
        e.Handled = True


    End Sub

    Private Sub SelectAll_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SelectAll_Bbi.ItemClick
        Me.CheckedListBoxControl1.CheckAll()
    End Sub

    Private Sub UnselectAll_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UnselectAll_Bbi.ItemClick
        Me.CheckedListBoxControl1.UnCheckAll()
    End Sub


End Class
