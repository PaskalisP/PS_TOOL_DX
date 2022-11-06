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
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.Data
Imports DevExpress.Utils

Public Class AllPostingsNGS_Search

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

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

    Dim OCBSaccountNamelbl As String = Nothing
    Dim OCBSaccountlbl As String = Nothing
    Dim OCBSaccountCurlbl As String = Nothing
    Dim OCBSDatefromlbl As String = Nothing
    Dim OCBSDatetilllbl As String = Nothing

    Private BS_AllContractsAccounts As BindingSource

    Dim dtSelected As New DataTable

    Dim SelectedDates As String = Nothing
    Dim commaSeparatedDates As String = Nothing
    Dim SelectedAccounts As String = Nothing
    Dim commaSeparatedSelectedAccounts As String = Nothing

    Dim query As New CustomSqlQuery()

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

    Private Sub GL_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GL_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub AllPostingsNGS_Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GL_Accounts_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GL_Accounts_GridControl_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.GL_ACCOUNTS_NEWGTableAdapter.Fill(Me.BalancesNEWGDataset.GL_ACCOUNTS_NEWG)

        dtSelected.Columns.Add("NEWG_GL_ACC_Nr", GetType(String))

        'Bind Combobox Currencies
        Me.ComboBoxEdit1.Properties.Items.Clear()
        Me.QueryText = "SELECT '***' as 'CURRENCY CODE' UNION ALL SELECT [CURRENCY CODE] FROM [OWN_CURRENCIES]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ComboBoxEdit1.Properties.Items.Add(row("CURRENCY CODE"))
            End If
        Next
        Me.ComboBoxEdit1.EditValue = "***"

        Me.QueryText = "Select CONVERT(VARCHAR(10),CalendarDate,104) as 'RLDC Date' from Calendar where   CalendarDate BETWEEN '20171209' AND DATEADD(Day,-1,GETDATE())  ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        With CheckedListBoxControl1
            .DataSource = dt
            .DisplayMember = "RLDC Date"
        End With

    End Sub

    Private Sub GL_Accounts_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "ClearSelection" Then
            Me.GL_Accounts_BaseView.ClearSelection()

            'For Each i As Integer In GL_Accounts_BaseView.GetSelectedRows()
            '    Dim row_Selected As DataRow = GL_Accounts_BaseView.GetDataRow(i)
            'Next i
        End If
    End Sub

    Private Sub FILL_Specific_GL_ACCOUNT_BOOKINGS_ALL_CURRENCIES_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM   ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") AND [Value Date] in (" & SelectedDates & ") AND GL_AC_No<>0  AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = All_Postings_Balances_All_GridView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
        If Me.All_Postings_Balances_All_GridView.RowCount = 0 Then
            XtraMessageBox.Show("There are no Postings with the selected criteria!", "No Postings fund", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub

    Private Sub FILL_Specific_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM  ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") AND [Value Date] in (" & SelectedDates & ") AND GL_AC_No<>0 AND (CCY = '" & Me.ComboBoxEdit1.Text & "') AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = All_Postings_Balances_All_GridView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
        If Me.All_Postings_Balances_All_GridView.RowCount = 0 Then
            XtraMessageBox.Show("There are no Postings with the selected criteria!", "No Postings fund", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub


    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click

        If Me.Selected_GL_Accounts_ListBoxControl.ItemCount > 0 AndAlso Me.ListBoxControl1.Items.Count > 0 Then
            'Selected GL Accounts
            If Me.Selected_GL_Accounts_ListBoxControl.ItemCount = 1 Then

                Dim ac As String = Me.Selected_GL_Accounts_ListBoxControl.GetItemText(0).ToString
                SelectedAccounts = "'" & ac & "'"


            ElseIf Me.Selected_GL_Accounts_ListBoxControl.ItemCount > 1 Then
                Dim arr As String() = New String(Me.Selected_GL_Accounts_ListBoxControl.ItemCount) {}
                Dim AccArr As String() = New String(Me.Selected_GL_Accounts_ListBoxControl.ItemCount) {}
                For i = 0 To Me.Selected_GL_Accounts_ListBoxControl.ItemCount
                    Dim ac As String = Me.Selected_GL_Accounts_ListBoxControl.GetItemText(i).ToString

                    AccArr(i) = ac
                    arr(i) = "'" & ac & "'"
                Next
                SelectedAccounts = String.Join(",", arr)
                commaSeparatedSelectedAccounts = String.Join(",", AccArr)
            End If

            'Selected Dates
            If Me.ListBoxControl1.Items.Count = 1 Then
                For i = 0 To Me.ListBoxControl1.Items.Count - 1
                    Dim d As Date = Me.ListBoxControl1.Items(i).ToString
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    SelectedDates = "'" & dsql & "'"
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
                SelectedDates = String.Join(",", arr)
                commaSeparatedDates = String.Join(",", DateArr)
            End If

            'MsgBox(SelectedAccounts)
            'MsgBox(SelectedDates)

            Try


                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                If Me.ComboBoxEdit1.Text = "***" OrElse Me.ComboBoxEdit1.Text = "" Then

                    SplashScreenManager.Default.SetWaitFormCaption("Load Postings for the selected criteria (All Currencies)")
                    FILL_Specific_GL_ACCOUNT_BOOKINGS_ALL_CURRENCIES_DATATABLE()

                ElseIf Me.ComboBoxEdit1.Text <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Load Postings for the selected criteria (Specified Currency)")
                    FILL_Specific_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()

                End If
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        Else

            XtraMessageBox.Show("Please check your selections" & vbNewLine & "At least 1 Parameter is not selected! ", "Search criteria not defined", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try



    End Sub



    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea

        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        'Dim reportfooter As String = Me.LabelControl14.Text & " from " & OCBSDatefromlbl & " till " & OCBSDatetilllbl
        'e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        'e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20)
        'e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)


        'Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        'Try
        'iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
        'r = New RectangleF(New PointF(0, 0), iSize)
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        'pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)
        'Catch ex As Exception
        'End Try

    End Sub

#Region "GRIDVIEW STYLES"

    Private Sub GL_Accounts_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GL_Accounts_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GL_Accounts_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles GL_Accounts_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub
    Private Sub AllPostings_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllPostings_BasicView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView4_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GridView4_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub All_Postings_Balances_All_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Postings_Balances_All_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub All_Postings_Balances_All_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Postings_Balances_All_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub All_Postings_Balances_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub All_Postings_Balances_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AllContractsAccounts_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllContractsAccounts_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

#End Region



    Private Sub GL_Accounts_BaseView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GL_Accounts_BaseView.SelectionChanged
        Dim view As GridView = GL_Accounts_BaseView
        'Fill ID to Datatable
        dtSelected.Clear()
        Me.Selected_GL_Accounts_ListBoxControl.Items.Clear()
        GetSelectedRows(view)
        Me.Selected_GL_Accounts_ListBoxControl.DataSource = dtSelected
        Me.Selected_GL_Accounts_ListBoxControl.DisplayMember = "NEWG_GL_ACC_Nr"
    End Sub

    Private Sub Selected_GL_Accounts_ListBoxControl_DrawItem(sender As Object, e As ListBoxDrawItemEventArgs) Handles Selected_GL_Accounts_ListBoxControl.DrawItem
        e.Appearance.ForeColor = Color.Yellow

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
        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Dim d As Date = Convert.ToDateTime(ListBoxControl1.GetItemText(e.Index.ToString))
        Dim s As String = d.ToString("dd.MM.yyyy")
        e.Appearance.DrawBackground(e.Cache, e.Bounds)
        e.Graphics.DrawString(s, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds.Location)
        e.Handled = True
    End Sub

    Private Sub CheckedListBoxControl1_ContextButtonClick(sender As Object, e As ContextItemClickEventArgs) Handles CheckedListBoxControl1.ContextButtonClick

    End Sub

    Private Function GetSelectedRows(ByVal view As GridView) As String
        Dim ret As String = ""

        Dim rowIndex As Integer = -1

        For Each i As Integer In GL_Accounts_BaseView.GetSelectedRows()
            Dim row_Selected As DataRow = GL_Accounts_BaseView.GetDataRow(i)

            If ret <> "" Then
                ret &= ControlChars.CrLf
            End If


            ret &= row_Selected(0)
            dtSelected.Rows.Add(row_Selected("NEWG_GL_ACC_Nr"))


        Next i
        Return ret

    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.CheckedListBoxControl1.CheckAll()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.CheckedListBoxControl1.UnCheckAll()
    End Sub
End Class