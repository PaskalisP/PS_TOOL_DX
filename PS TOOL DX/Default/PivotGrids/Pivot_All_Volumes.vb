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
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet
Public Class Pivot_All_Volumes

    Dim conn As New SqlClient.SqlConnection
    Dim cmd As New SqlCommand

    Dim ActiveTabGroup As Double = 0

    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing
    Dim rd1 As Date
    Dim rd2 As Date
    Dim flrd As Date
    Dim flrdsql As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable
    Private objDataTable As New System.Data.DataTable


    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    Private bgws As New List(Of BackgroundWorker)()
    Friend WithEvents BgwAllVolumesLOAD As BackgroundWorker
    Friend WithEvents BgwAllVolumesSelectionDatesLOAD As BackgroundWorker

    Dim SelectList As New SelectFromListForm1()

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

    Private Sub Pivot_All_Volumes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub

    Private Sub Pivot_All_Volumes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        Me.BS_DateTill_Comboedit.Properties.Items.Clear()
        'Me.QueryText = "SELECT CONVERT(VARCHAR(10),[GL_Rep_Date],104) as 'RLDC Date' FROM [ALL_VOLUMES] GROUP BY GL_Rep_Date order by GL_Rep_Date desc"
        Me.QueryText = "SELECT CONVERT(VARCHAR(10),[CalendarDate],104) as 'RLDC Date' FROM [Calendar] where [CalendarDate]>='20111121' and [CalendarDate] in (Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where [Currency risk] is not NULL) order by [CalendarDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))
                Me.BS_DateTill_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
            Me.BS_DateTill_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")

        'Me.QueryText = "execute [ALL_VOLUMES_DATES_ONLY]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "' "
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        'Me.PivotGridControl1.DataSource = Nothing
        'Me.PivotGridControl1.DataSource = dt
        'Me.PivotGridControl1.ForceInitialize()
        'Me.PivotGridControl1.BestFit()
        'End If


    End Sub

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "All Postings" 'from " & "   " & rd1 & " till  " & rd2
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub LoadData_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadData_BarButtonItem.ItemClick
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load all Postings - Volumes  from " & rd1 & " till " & rd2)

            BgwAllVolumesLOAD = New BackgroundWorker
            bgws.Clear()
            bgws.Add(BgwAllVolumesLOAD)
            BgwAllVolumesLOAD.WorkerReportsProgress = True
            BgwAllVolumesLOAD.RunWorkerAsync()


        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub


    Private Sub BgwAllVolumesLOAD_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAllVolumesLOAD.DoWork
        Try
            'Me.QueryText = "execute [ALL_VOLUMES_DATES_ONLY]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "' "
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)

            'Data reader
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandTimeout = 50000
                    sqlCmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') ORDER BY IdNr"
                    sqlCmd.Connection = sqlConn
                    sqlCmd.CommandTimeout = 60000
                    If sqlConn.State = ConnectionState.Closed Then
                        sqlConn.Open()
                    End If

                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    objDataTable.Clear()
                    objDataTable.Load(objDataReader)

                    If sqlConn.State = ConnectionState.Open Then
                        sqlConn.Close()
                    End If

                End Using
            End Using

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BgwAllVolumesLOAD_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAllVolumesLOAD.RunWorkerCompleted
        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = objDataTable
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()


        End If
        SplashScreenManager.CloseForm(False)
        Workers_Complete(BgwAllVolumesLOAD, e)

    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load all Postings Data from " & rd1 & " till " & rd2)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PivotGridControl1_CellDoubleClick(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()

            For Each col As GridColumn In c.PivotDetailsBaseView.Columns
                If col.FieldName.StartsWith("Amount") Or col.Name.Contains("Sum") Or col.FieldName.Contains("Amount") _
                    Or col.FieldName.Contains("Interest") Or col.FieldName.Contains("Equivalent") _
                    Or col.FieldName.Contains("Credit Exposure") Or col.FieldName.Contains("Org Ccy") _
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"

                ElseIf col.FieldName.StartsWith("Time") Or col.FieldName.StartsWith("Transaction Time") Or col.FieldName.EndsWith("Time") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    col.DisplayFormat.FormatString = "HH:mm:ss"
                End If
            Next

            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try


        '++++++++OLD CODE+++++++
        ' Create a new form.
        'Dim form As Form = New Form
        'form.Text = "Records"

        ' Place a DataGrid control on the form.
        'Dim grid As DataGrid = New DataGrid
        'grid.Parent = form
        'grid.Dock = DockStyle.Fill
        'Get the recrd set associated with the current cell and bind it to the grid.
        'grid.DataSource = e.CreateDrillDownDataSource()

        'New Code
        'detailsDataGridView.Parent = form
        'detailsDataGridView.Dock = DockStyle.Fill
        'detailsBindingSource.DataSource = e.CreateDrillDownDataSource()
        'detailsDataGridView.DataSource = detailsBindingSource
        'detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'detailsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        'detailsDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        'form.SetBounds(1000, 1000, 1500, 700)
        'form.StartPosition = FormStartPosition.CenterScreen
        ' Display the form.
        'form.ShowDialog()

        'form.Dispose()

        'detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'detailsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    End Sub

    Private Sub PivotGridControl1_CustomDrawFieldHeader(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventArgs) Handles PivotGridControl1.CustomDrawFieldHeader
        If (Not e.Field.FilterValues.IsEmpty) AndAlso e.Info.State = DevExpress.Utils.Drawing.ObjectState.Normal Then
            e.Info.State = DevExpress.Utils.Drawing.ObjectState.Hot
        End If
    End Sub

    Private Sub LoadDataFromList_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_BarButtonItem.ItemClick
        Try
            Me.QueryText = "Select CONVERT(VARCHAR(10),CalendarDate,104) as 'RLDC Date' from Calendar where   CalendarDate BETWEEN '20111121' AND DATEADD(Day,-1,GETDATE()) ORDER BY ID desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            With SelectList.CheckedListBoxControl1
                .DataSource = dt
                .DisplayMember = "RLDC Date"
            End With

            Dim dxOK_SelectList As New DevExpress.XtraEditors.SimpleButton
            With dxOK_SelectList
                .Text = "Load Data from selected Dates"
                .Height = 23
                .Width = 185
                .ImageList = SelectList.ImageCollection1
                .ImageIndex = 10
                .Location = New System.Drawing.Point(211, 358)
            End With


            Me.SelectList.SimpleButton1.Visible = False
            Me.SelectList.Controls.Add(dxOK_SelectList)

            AddHandler dxOK_SelectList.Click, AddressOf dxOK_SelectList_click

            Me.SelectList.ListBoxControl1.Items.Clear()
            Me.SelectList.Text = "AVAILABLE POSTINGS DATES"
            Me.SelectList.ShowDialog()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Dim SelectedDates As String = Nothing
    Dim commaSeparatedDates As String = Nothing
    Private Sub dxOK_SelectList_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SelectList.ListBoxControl1.Items.Count > 0 Then

            If SelectList.ListBoxControl1.Items.Count = 1 Then
                For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
                    Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    SelectedDates = "'" & dsql & "'"
                Next
                'MsgBox(SelectedDates)
            ElseIf SelectList.ListBoxControl1.Items.Count > 1 Then
                Dim arr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
                Dim DateArr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
                For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
                    Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    DateArr(i) = d
                    arr(i) = "'" & dsql & "'"
                Next
                SelectedDates = String.Join(",", arr)
                commaSeparatedDates = String.Join(",", DateArr)
                'MsgBox(SelectedDates)

            End If

            SelectList.Close()



            BgwAllVolumesSelectionDatesLOAD = New BackgroundWorker
            bgws.Clear()
            bgws.Add(BgwAllVolumesSelectionDatesLOAD)
            BgwAllVolumesSelectionDatesLOAD.WorkerReportsProgress = True
            BgwAllVolumesSelectionDatesLOAD.RunWorkerAsync()

        End If

    End Sub

    Private Sub BgwAllVolumesSelectionDatesLOAD_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAllVolumesSelectionDatesLOAD.DoWork
        Try
            'Me.QueryText = "execute [ALL_VOLUMES_DATES_ONLY]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "' "
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load all Postings - Volumes  for " & commaSeparatedDates)
            'Data reader
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandTimeout = 50000
                    sqlCmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  [Value Date] in (" & SelectedDates & ")  ORDER BY IdNr"
                    sqlCmd.Connection = sqlConn
                    sqlCmd.CommandTimeout = 60000
                    If sqlConn.State = ConnectionState.Closed Then
                        sqlConn.Open()
                    End If

                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    objDataTable.Clear()
                    objDataTable.Load(objDataReader)

                    If sqlConn.State = ConnectionState.Open Then
                        sqlConn.Close()
                    End If

                End Using
            End Using

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BgwAllVolumesSelectionDatesLOAD_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAllVolumesSelectionDatesLOAD.RunWorkerCompleted
        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = objDataTable
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()


        End If
        SplashScreenManager.CloseForm(False)
        Workers_Complete(BgwAllVolumesSelectionDatesLOAD, e)

    End Sub

End Class