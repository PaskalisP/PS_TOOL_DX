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
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports DevExpress.XtraRichEdit.Services

Public Class Audit

    Dim d1 As Date
    Dim d2 As Date
    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing

    Dim Table_Name As String = Nothing
    Dim Related_ID As Integer = 0

    Private BS_All_OperationDates As BindingSource
    Friend WithEvents BgwLoad_Data As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()


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

    Private Sub AuditBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AuditBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AuditDataSet)

    End Sub

    Private Sub Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ALL_OPERATIONS_DATES_initData()
            ALL_OPERATIONS_DATES_InitLookUp()

            If BS_All_OperationDates.Count > 0 Then
                Me.AuditDateFrom_Comboedit.EditValue = CType(BS_All_OperationDates.Current, DataRowView).Item(0).ToString
                Me.AuditDateTill_Comboedit.EditValue = CType(BS_All_OperationDates.Current, DataRowView).Item(0).ToString
            End If

            d1 = Me.AuditDateFrom_Comboedit.Text
            d2 = Me.AuditDateTill_Comboedit.Text
            rdsql1 = d1.ToString("yyyyMMdd")
            rdsql2 = d2.ToString("yyyyMMdd")

            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = "SELECT * FROM [Audit] 
                                          where [OperationDate] BETWEEN '" & rdsql1 & "' AND '" & rdsql2 & "' order by ID desc"
                    Sqlcmd.Connection = Sqlconn
                    Sqlconn.Open()
                    daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)
                    Sqlconn.Close()
                    If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
                        Me.GridControl2.DataSource = Nothing
                        Me.GridControl2.DataSource = dtSqlQueries
                        Me.GridControl2.ForceInitialize()
                        Me.GridControl2.RefreshDataSource()
                    Else
                        XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                End Using
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub ALL_OPERATIONS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @SELECTION_TABLE Table([ID] int IDENTITY(1,1) Not NULL, [OPERATION_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'OPERATION_DATE'=CONVERT(varchar(10),[OperationDate],104) from Audit
                                                    group by OperationDate order by OperationDate asc
                                                    SELECT OPERATION_DATE  from @SELECTION_TABLE 
                                                    order by ID desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbOperationDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbOperationDates.Fill(ds, "OPERATION_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_OperationDates = New BindingSource(ds, "OPERATION_DATE")
    End Sub
    Private Sub ALL_OPERATIONS_DATES_InitLookUp()
        Me.AuditDateFrom_Comboedit.Properties.DataSource = BS_All_OperationDates
        Me.AuditDateFrom_Comboedit.Properties.DisplayMember = "OPERATION_DATE"
        Me.AuditDateFrom_Comboedit.Properties.ValueMember = "OPERATION_DATE"
        Me.AuditDateTill_Comboedit.Properties.DataSource = BS_All_OperationDates
        Me.AuditDateTill_Comboedit.Properties.DisplayMember = "OPERATION_DATE"
        Me.AuditDateTill_Comboedit.Properties.ValueMember = "OPERATION_DATE"

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.AuditDateFrom_Comboedit.Enabled = False
        Me.AuditDateTill_Comboedit.Enabled = False
        Me.LoadAudit_btn.Enabled = False
        Me.Print_Export_AuditEvents_Gridview_btn.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.AuditDateFrom_Comboedit.Enabled = True
        Me.AuditDateTill_Comboedit.Enabled = True
        Me.LoadAudit_btn.Enabled = True
        Me.Print_Export_AuditEvents_Gridview_btn.Enabled = True
    End Sub

    Private Sub AuditEvents_BasicView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles AuditEvents_BasicView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)
        If HitInfo.InRow Then
            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)
        End If
    End Sub

    Private Sub AuditEvents_BasicView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AuditEvents_BasicView.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        Table_Name = view.GetRowCellValue(e.RowHandle, colTable_Name).ToString
        Related_ID = CInt(view.GetRowCellValue(e.RowHandle, colRelated_IdNr).ToString)


    End Sub

    Private Sub AuditEvents_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles AuditEvents_BasicView.RowClick
        Dim view As GridView = CType(sender, GridView)
        Table_Name = view.GetRowCellValue(e.RowHandle, colTable_Name).ToString
        Related_ID = CInt(view.GetRowCellValue(e.RowHandle, colRelated_IdNr).ToString)

    End Sub



    Private Sub Print_Export_AuditEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_AuditEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "AUDIT EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub LoadAudit_btn_Click(sender As Object, e As EventArgs) Handles LoadAudit_btn.Click
        If Me.AuditDateFrom_Comboedit.Text <> "" And Me.AuditDateTill_Comboedit.Text <> "" Then
            d1 = Me.AuditDateFrom_Comboedit.Text
            d2 = Me.AuditDateTill_Comboedit.Text
            rdsql1 = d1.ToString("yyyyMMdd")
            rdsql2 = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then
                DISABLE_BUTTONS()
                Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
                BgwLoad_Data = New BackgroundWorker
                bgws.Add(BgwLoad_Data)
                BgwLoad_Data.WorkerReportsProgress = True
                BgwLoad_Data.RunWorkerAsync()
            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        End If

    End Sub

    Private Sub BgwLoad_Data_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoad_Data.DoWork
        Try
            Me.BgwLoad_Data.ReportProgress(10, "Load all Audit data from: " & d1 & " till " & d2)

            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = "SELECT * FROM [Audit] 
                                          where [OperationDate] BETWEEN '" & rdsql1 & "' AND '" & rdsql2 & "' order by ID desc"
                    Sqlcmd.Connection = Sqlconn
                    Sqlconn.Open()
                    daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)
                    Sqlconn.Close()
                End Using
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoad_Data.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoad_Data_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoad_Data.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadContractPostings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoad_Data.RunWorkerCompleted
        Workers_Complete(BgwLoad_Data, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
        Me.GridControl2.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl2.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl2.DataSource = dtSqlQueries
            Me.GridControl2.ForceInitialize()
            Me.GridControl2.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub SeeDetails_Form_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeDetails_Form_ToolStripMenuItem.Click
        Dim c As New SqlServerQueries
        c.MdiParent = Me.MdiParent

        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.RichEditControl1.Text = "Select * from [" & Table_Name & "] where ID=" & Related_ID & ""
        c.BbiExecuteSqlCommand.PerformClick()
        c.TreeList1.Visible = False
        c.RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(c.RichEditControl1.Document))
        c.Text = "Audit for Table: [" & Table_Name & "] and ID: " & Related_ID
        c.RichEditControl1.ReadOnly = True
        c.RichEditControl1.Enabled = False
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Audit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class