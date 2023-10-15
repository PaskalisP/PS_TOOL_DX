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
Imports DevExpress.Utils
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
Public Class GmpsPaymentsOut

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim FDateSql As String = Nothing
    Dim LDateSql As String = Nothing

    Dim MessageType As String = Nothing

    Dim CustPayOrders_MyStringCollection As New System.Collections.Specialized.StringCollection
    Dim BankPayOrders_MyStringCollection As New System.Collections.Specialized.StringCollection

    Friend WithEvents BgwLoadPayments As BackgroundWorker

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

    Private Sub GMPS_PAYMENTS_OUTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GMPS_PAYMENTS_OUTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClearingDataSet)

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.DateFrom_BarEditItem.Enabled = False
        Me.DateTill_BarEditItem.Enabled = False
        Me.bbi_Load.Enabled = False
        Me.DisplayListDetails_bbi.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.DateFrom_BarEditItem.Enabled = True
        Me.DateTill_BarEditItem.Enabled = True
        Me.bbi_Load.Enabled = True
        Me.DisplayListDetails_bbi.Enabled = True
    End Sub

    Private Sub GmpsPaymentsOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustPayOrders_MyStringCollection.AddRange(New String() {"2", "31", "35", "43"})
        BankPayOrders_MyStringCollection.AddRange(New String() {"3", "32", "34"})


        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        'cmd.CommandText = "SELECT Max(RegisterDate) from [GMPS PAYMENTS OUT]"
        cmd.CommandText = "Select DPARAMETER1 from PARAMETER where PARAMETER1 in ('GMPS_PAYMENTS_OUT') and IdABTEILUNGSPARAMETER in ('MAX_DATES') and IdABTEILUNGSCODE_NAME in ('CLEARING')"
        Dim d As Date = cmd.ExecuteScalar
        'Dim d As Date = DateSerial(2018, 12, 14)
        CloseSqlConnections()
        '***********************************************************************


        Me.DateFrom_BarEditItem.EditValue = d
        Me.DateTill_BarEditItem.EditValue = d


        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = PaymentsOut_GridView
        PaymentsOut_GridView.ForceDoubleClick = True
        AddHandler PaymentsOut_GridView.DoubleClick, AddressOf PaymentsOut_GridView_DoubleClick
        AddHandler PaymentsOut_MT103_LayoutView.MouseDown, AddressOf PaymentsOut_MT103_LayoutView_MouseDown
        AddHandler PaymentsOut_SEPA_DD_LayoutView.MouseDown, AddressOf PaymentsOut_SEPA_DD_LayoutView_MouseDown
        AddHandler PaymentsOut_MT202_LayoutView.MouseDown, AddressOf PaymentsOut_MT202_LayoutView_MouseDown
        PaymentsOut_MT103_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_MT103_LayoutView.OptionsBehavior.AllowSwitchViewModes = False
        PaymentsOut_SEPA_DD_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_SEPA_DD_LayoutView.OptionsBehavior.AllowSwitchViewModes = False
        PaymentsOut_MT202_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_MT202_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "PAYMENTS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        If MessageType.ToString = "103" OrElse CustPayOrders_MyStringCollection.Contains(MessageType.ToString.Trim()) OrElse MessageType.ToString.StartsWith("pacs.008") Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_MT103_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strShowExtendedMode
            DisplayListDetails_bbi.ImageIndex = 9
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT103_LayoutView)
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_SEPA_DD_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strShowExtendedMode
            DisplayListDetails_bbi.ImageIndex = 9
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_SEPA_DD_LayoutView)
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" OrElse BankPayOrders_MyStringCollection.Contains(MessageType.ToString.Trim()) _
            OrElse MessageType.ToString.StartsWith("pacs.009") Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_MT202_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strShowExtendedMode
            DisplayListDetails_bbi.ImageIndex = 9
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT202_LayoutView)

        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)

        If MessageType.ToString = "103" OrElse CustPayOrders_MyStringCollection.Contains(MessageType.ToString.Trim()) OrElse MessageType.ToString.StartsWith("pacs.008") Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_MT103_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strHideExtendedMode
            DisplayListDetails_bbi.ImageIndex = 10
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT103_LayoutView)
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_SEPA_DD_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strHideExtendedMode
            DisplayListDetails_bbi.ImageIndex = 10
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_SEPA_DD_LayoutView)
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" OrElse BankPayOrders_MyStringCollection.Contains(MessageType.ToString.Trim()) _
            OrElse MessageType.ToString.StartsWith("pacs.009") Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_MT202_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            DisplayListDetails_bbi.Caption = strHideExtendedMode
            DisplayListDetails_bbi.ImageIndex = 10
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT202_LayoutView)
        End If

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = PaymentsOut_GridView.GetRowHandle(dataSourceRowIndex)
        PaymentsOut_GridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)

        If MessageType.ToString = "103" OrElse CustPayOrders_MyStringCollection.Contains(MessageType.ToString) OrElse MessageType.ToString.StartsWith("pacs.008") Then
            Dim rowHandle As Integer = PaymentsOut_MT103_LayoutView.GetRowHandle(dataSourceRowIndex)
            PaymentsOut_MT103_LayoutView.VisibleRecordIndex = PaymentsOut_MT103_LayoutView.GetVisibleIndex(rowHandle)
            PaymentsOut_MT103_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            Dim rowHandle As Integer = PaymentsOut_SEPA_DD_LayoutView.GetRowHandle(dataSourceRowIndex)
            PaymentsOut_SEPA_DD_LayoutView.VisibleRecordIndex = PaymentsOut_SEPA_DD_LayoutView.GetVisibleIndex(rowHandle)
            PaymentsOut_SEPA_DD_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" OrElse BankPayOrders_MyStringCollection.Contains(MessageType.ToString) _
            OrElse MessageType.ToString.StartsWith("pacs.009") Then
            Dim rowHandle As Integer = PaymentsOut_MT202_LayoutView.GetRowHandle(dataSourceRowIndex)
            PaymentsOut_MT202_LayoutView.VisibleRecordIndex = PaymentsOut_MT202_LayoutView.GetVisibleIndex(rowHandle)
            PaymentsOut_MT202_LayoutView.FocusedRowHandle = dataSourceRowIndex
        End If

    End Sub

    Protected Sub PaymentsOut_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim View As GridView = sender
        MessageType = View.GetRowCellValue(View.FocusedRowHandle, colMTTYPE).ToString()

        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = PaymentsOut_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub PaymentsOut_MT103_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = PaymentsOut_MT103_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

    Protected Sub PaymentsOut_SEPA_DD_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = PaymentsOut_SEPA_DD_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

    Protected Sub PaymentsOut_MT202_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = PaymentsOut_MT202_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

    Protected Sub LayoutViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub



#End Region

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub

    Private Sub PaymentsOut_MT103_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_MT103_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub PaymentsOut_MT202_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_MT202_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub PaymentsOut_SEPA_DD_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_SEPA_DD_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub bbi_Load_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Load.ItemClick
        If Me.DateFrom_BarEditItem.EditValue.ToString <> "" And Me.DateTill_BarEditItem.EditValue.ToString <> "" Then
            FDate = Me.DateFrom_BarEditItem.EditValue
            LDate = Me.DateTill_BarEditItem.EditValue
            If LDate >= FDate Then

                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                BgwLoadPayments = New BackgroundWorker
                bgws.Add(BgwLoadPayments)
                BgwLoadPayments.WorkerReportsProgress = True
                BgwLoadPayments.RunWorkerAsync()

            Else
                XtraMessageBox.Show("Date From is higher than Date Till", "WRONG DATE INPUT", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BgwLoadPayments_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadPayments.DoWork
        Try

            Me.BgwLoadPayments.ReportProgress(10, "Load all outgoing Payments from: " & FDate & " till " & LDate)
            FDateSql = FDate.ToString("yyyyMMdd")
            LDateSql = LDate.ToString("yyyyMMdd")

            SqlCommandText = "SELECT * FROM [GMPS PAYMENTS OUT] where [RegisterDate] BETWEEN '" & FDateSql & "' and '" & LDateSql & "'"
            'Data reader
            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = SqlCommandText
                    Sqlcmd.Connection = Sqlconn
                    'Sqlcmd.CommandTimeout = 5000
                    Sqlconn.Open()

                    daSqlQueries = New SqlDataAdapter(SqlCommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)

                    'Dim objDataReader As SqlDataReader = Sqlcmd.ExecuteReader()
                    'objDataTable.Clear()
                    'objDataTable.Load(objDataReader)

                    Sqlconn.Close()

                End Using
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadPayments.CancelAsync()

        End Try
    End Sub


    Private Sub BgwLoadPayments_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadPayments.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadPayments_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadPayments.RunWorkerCompleted
        Workers_Complete(BgwLoadPayments, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.GridControl2.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl2.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl2.DataSource = dtSqlQueries
            Me.GridControl2.ForceInitialize()
            'Me.LCR_Details_GridView.PopulateColumns()
            'Me.LCR_Details_GridView.BestFitColumns()
            'Me.GridControl4.RefreshDataSource()
            Me.LayoutControlGroup2.Text = "Outgoing Payments  from: " & FDate & " till " & LDate
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub bbi_PrintOrExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintOrExport.ItemClick
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If DisplayListDetails_bbi.Caption = "Display Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else

            If MessageType.ToString = "103" OrElse CustPayOrders_MyStringCollection.Contains(MessageType.ToString) OrElse MessageType.ToString.StartsWith("pacs.008") Then
                Me.PaymentsOut_MT103_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_MT103_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
                Me.PaymentsOut_MT103_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.PaymentsOut_MT103_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.PaymentsOut_MT103_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.PaymentsOut_MT103_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                Me.PaymentsOut_MT103_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_MT103_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
            ElseIf MessageType.ToString = "103-DD-SEPA" Then
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_SEPA_DD_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
            ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" OrElse BankPayOrders_MyStringCollection.Contains(MessageType.ToString) _
            OrElse MessageType.ToString.StartsWith("pacs.009") Then
                Me.PaymentsOut_MT202_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_MT202_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
                Me.PaymentsOut_MT202_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.PaymentsOut_MT202_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.PaymentsOut_MT202_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.PaymentsOut_MT202_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                Me.PaymentsOut_MT202_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.PaymentsOut_MT202_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
            End If

        End If
    End Sub


    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

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

        Dim reportfooter As String = "OUTGOING PAYMENTS FROM " & FDate & " TILL " & LDate
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New System.Drawing.Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, System.Drawing.Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)


        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size

        Try
            iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
            r = New RectangleF(New PointF(0, 0), iSize)
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Far)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GmpsPaymentsOut_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub
End Class