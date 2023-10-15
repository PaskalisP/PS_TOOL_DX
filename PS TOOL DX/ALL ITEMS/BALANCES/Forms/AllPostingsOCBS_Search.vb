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

Public Class AllPostingsOCBS_Search

    Dim d1 As Date
    Dim d2 As Date
    Dim rdsql1 As String
    Dim rdsql2 As String

    Private BS_AllContractsAccounts As BindingSource

    Dim dtSelected As New DataTable

    Dim SelectedDates As String = Nothing
    Dim commaSeparatedDates As String = Nothing
    Dim SelectedAccounts As String = Nothing
    Dim commaSeparatedSelectedAccounts As String = Nothing

    Friend WithEvents BgwLoadPostings As BackgroundWorker

    Private bgws As New List(Of BackgroundWorker)()

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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub GL_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GL_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.GL_Accounts_GridControl.Enabled = False
        Me.CheckedListBoxControl1.Enabled = False
        Me.LoadData_btn.Enabled = False
        Me.ComboBoxEdit1.Enabled = False
        Me.Print_Export_Gridview_btn.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.GL_Accounts_GridControl.Enabled = True
        Me.CheckedListBoxControl1.Enabled = True
        Me.LoadData_btn.Enabled = True
        Me.ComboBoxEdit1.Enabled = True
        Me.Print_Export_Gridview_btn.Enabled = True
    End Sub

    Private Sub AllPostingsOCBS_Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GL_Accounts_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GL_Accounts_GridControl_EmbeddedNavigator_ButtonClick

        Me.GL_ACCOUNTSTableAdapter.Fill(Me.BalancesDataset.GL_ACCOUNTS)

        dtSelected.Columns.Add("GL_AC_No", GetType(String))

        'Bind Combobox Currencies
        Me.ComboBoxEdit1.Properties.Items.Clear()
        QueryText = "SELECT '***' as 'CURRENCY CODE' UNION ALL SELECT [CURRENCY CODE] FROM [OWN_CURRENCIES]"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ComboBoxEdit1.Properties.Items.Add(row("CURRENCY CODE"))
            End If
        Next
        Me.ComboBoxEdit1.EditValue = "***"

        QueryText = "Select CONVERT(VARCHAR(10),CalendarDate,104) as 'RLDC Date' from Calendar where   CalendarDate BETWEEN '20111121' AND '20171209'   ORDER BY [ID] desc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
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
        query.Sql = "SELECT * FROM   ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") AND [Value Date] in (" & SelectedDates & ") AND GL_AC_No<>0  AND [System] in ('OCBS') ORDER BY IdNr"
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
        query.Sql = "SELECT * FROM  ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") AND [Value Date] in (" & SelectedDates & ") AND GL_AC_No<>0 AND (CCY = '" & Me.ComboBoxEdit1.Text & "') AND [System] in ('OCBS') ORDER BY IdNr"
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
            DISABLE_BUTTONS()
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
            BgwLoadPostings = New BackgroundWorker
            bgws.Add(BgwLoadPostings)
            BgwLoadPostings.WorkerReportsProgress = True
            BgwLoadPostings.RunWorkerAsync()
            'MsgBox(SelectedAccounts)
            'MsgBox(SelectedDates)
        Else

            XtraMessageBox.Show("Please check your selections" & vbNewLine & "At least 1 Parameter is not selected! ", "Search criteria not defined", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub BgwLoadPostings_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadPostings.DoWork
        Try
            If Me.ComboBoxEdit1.Text = "***" OrElse Me.ComboBoxEdit1.Text = "" Then

                Me.BgwLoadPostings.ReportProgress(10, "Load Postings for the selected criteria (All Currencies)")
                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") 
                                              AND [Value Date] in (" & SelectedDates & ") 
                                              AND GL_AC_No<>0  
                                              AND [System] in ('OCBS') ORDER BY IdNr"
                        Sqlcmd.Connection = Sqlconn
                        Sqlconn.Open()
                        daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)
                        Sqlconn.Close()

                    End Using
                End Using
            ElseIf Me.ComboBoxEdit1.Text <> "***" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                Me.BgwLoadPostings.ReportProgress(10, "Load Postings for the selected criteria (Specified Currency)")
                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES WHERE  GL_AC_No in (" & SelectedAccounts & ") 
                                              AND [Value Date] in (" & SelectedDates & ") 
                                              AND GL_AC_No<>0 
                                              AND CCY = '" & Me.ComboBoxEdit1.Text & "'
                                              AND [System] in ('OCBS') ORDER BY IdNr"
                        Sqlcmd.Connection = Sqlconn
                        Sqlconn.Open()
                        daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)
                        Sqlconn.Close()

                    End Using
                End Using

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadPostings.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoadPostings_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadPostings.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadPostings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadPostings.RunWorkerCompleted
        Workers_Complete(BgwLoadPostings, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
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


    Private Sub GL_Accounts_BaseView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GL_Accounts_BaseView.SelectionChanged
        Dim view As GridView = GL_Accounts_BaseView
        'Fill ID to Datatable
        dtSelected.Clear()
        Me.Selected_GL_Accounts_ListBoxControl.Items.Clear()
        GetSelectedRows(view)
        Me.Selected_GL_Accounts_ListBoxControl.DataSource = dtSelected
        Me.Selected_GL_Accounts_ListBoxControl.DisplayMember = "GL_AC_No"
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




    Private Function GetSelectedRows(ByVal view As GridView) As String
        Dim ret As String = ""

        Dim rowIndex As Integer = -1

        For Each i As Integer In GL_Accounts_BaseView.GetSelectedRows()
            Dim row_Selected As DataRow = GL_Accounts_BaseView.GetDataRow(i)

            If ret <> "" Then
                ret &= ControlChars.CrLf
            End If


            ret &= row_Selected(0)
            dtSelected.Rows.Add(row_Selected("GL_AC_No"))


        Next i
        Return ret

    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.CheckedListBoxControl1.CheckAll()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.CheckedListBoxControl1.UnCheckAll()
    End Sub

    Private Sub AllPostingsOCBS_Search_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class