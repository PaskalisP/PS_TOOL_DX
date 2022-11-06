﻿Imports System
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

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim FDateSql As String = Nothing
    Dim LDateSql As String = Nothing

    Dim MessageType As String = Nothing

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

    Private Sub GMPS_PAYMENTS_OUTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GMPS_PAYMENTS_OUTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClearingDataSet)

    End Sub

    Private Sub GmpsPaymentsOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        'cmd.CommandText = "SELECT Max(RegisterDate) from [GMPS PAYMENTS OUT]"
        cmd.CommandText = "Select DPARAMETER1 from PARAMETER where PARAMETER1 in ('GMPS_PAYMENTS_OUT') and IdABTEILUNGSPARAMETER in ('MAX_DATES') and IdABTEILUNGSCODE_NAME in ('CLEARING')"
        Dim d As Date = cmd.ExecuteScalar
        'Dim d As Date = DateSerial(2018, 12, 14)
        cmd.Connection.Close()
        '***********************************************************************


        Me.PaymentFromDateEdit.Text = d
        Me.PaymentTillDateEdit.Text = d

        'Me.GMPS_PAYMENTS_OUTTableAdapter.SetCommandTimeOut(120000)
        'Me.GMPS_PAYMENTS_OUTTableAdapter.FillByGMPS_OUT_FILL(Me.ClearingDataSet.GMPS_PAYMENTS_OUT, d, d)

        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = PaymentsOut_GridView
        PaymentsOut_GridView.ForceDoubleClick = True
        AddHandler PaymentsOut_GridView.DoubleClick, AddressOf PaymentsOut_GridView_DoubleClick
        AddHandler PaymentsOut_MT103_LayoutView.MouseDown, AddressOf PaymentsOut_MT103_LayoutView_MouseDown
        AddHandler PaymentsOut_SEPA_DD_LayoutView.MouseDown, AddressOf PaymentsOut_SEPA_DD_LayoutView_MouseDown
        AddHandler PaymentsOut_MT202_LayoutView.MouseDown, AddressOf PaymentsOut_MT202_LayoutView_MouseDown
        AddHandler LayoutViews_btn.Click, AddressOf LayoutViews_btn_Click
        PaymentsOut_MT103_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_MT103_LayoutView.OptionsBehavior.AllowSwitchViewModes = False
        PaymentsOut_SEPA_DD_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_SEPA_DD_LayoutView.OptionsBehavior.AllowSwitchViewModes = False
        PaymentsOut_MT202_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        PaymentsOut_MT202_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "PAYMENTS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        If MessageType.ToString = "103"  Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_MT103_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strShowExtendedMode
            LayoutViews_btn.ImageIndex = 1
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT103_LayoutView)
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_SEPA_DD_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strShowExtendedMode
            LayoutViews_btn.ImageIndex = 1
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_SEPA_DD_LayoutView)
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = PaymentsOut_MT202_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strShowExtendedMode
            LayoutViews_btn.ImageIndex = 1
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT202_LayoutView)

        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        If MessageType.ToString = "103" Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_MT103_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strHideExtendedMode
            LayoutViews_btn.ImageIndex = 0
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT103_LayoutView)
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_SEPA_DD_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strHideExtendedMode
            LayoutViews_btn.ImageIndex = 0
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_SEPA_DD_LayoutView)
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" Then
            Dim datasourceRowIndex As Integer = PaymentsOut_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = PaymentsOut_MT202_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
            LayoutViews_btn.Text = strHideExtendedMode
            LayoutViews_btn.ImageIndex = 0
            fExtendedEditMode = (GridControl2.MainView Is PaymentsOut_MT202_LayoutView)
        End If

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = PaymentsOut_GridView.GetRowHandle(dataSourceRowIndex)
        PaymentsOut_GridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        If MessageType.ToString = "103" Then
            Dim rowHandle As Integer = PaymentsOut_MT103_LayoutView.GetRowHandle(dataSourceRowIndex)
            PaymentsOut_MT103_LayoutView.VisibleRecordIndex = PaymentsOut_MT103_LayoutView.GetVisibleIndex(rowHandle)
            PaymentsOut_MT103_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf MessageType.ToString = "103-DD-SEPA" Then
            Dim rowHandle As Integer = PaymentsOut_SEPA_DD_LayoutView.GetRowHandle(dataSourceRowIndex)
            PaymentsOut_SEPA_DD_LayoutView.VisibleRecordIndex = PaymentsOut_SEPA_DD_LayoutView.GetVisibleIndex(rowHandle)
            PaymentsOut_SEPA_DD_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" Then
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
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub PaymentsOut_MT103_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_MT103_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub PaymentsOut_MT202_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_MT202_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub PaymentsOut_SEPA_DD_LayoutView_MouseWheel(sender As Object, e As MouseEventArgs) Handles PaymentsOut_SEPA_DD_LayoutView.MouseWheel
        DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub LoadPaymentsData_btn_Click(sender As Object, e As EventArgs) Handles LoadPaymentsData_btn.Click
        If IsDate(Me.PaymentFromDateEdit.Text) = True AndAlso IsDate(Me.PaymentTillDateEdit.Text) = True Then
            FDate = Me.PaymentFromDateEdit.Text
            LDate = Me.PaymentTillDateEdit.Text
            If LDate >= FDate Then
                Dim FDateSql As String = FDate.ToString("yyyyMMdd")
                Dim LDateSql As String = LDate.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Outgoing Payment Orders from " & FDate & " till " & LDate)

                'Dim objCMD As SqlCommand = New SqlCommand("execute [GMPS_OUT_FILL]  @FROMDATE='" & FDateSql & "', @TILLDATE='" & LDateSql & "'  ", conn)
                'objCMD.CommandTimeout = 5000
                'da = New SqlDataAdapter(objCMD)
                'dt = New DataTable()
                'da.Fill(dt)
                'Results
                'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'Me.GridControl2.DataSource = Nothing
                'Me.GridControl2.DataSource = dt
                'Me.GridControl2.ForceInitialize()
                'Else
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Exit Sub
                'End If

                'Data reader
                Try
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandTimeout = 50000
                            sqlCmd.CommandText = "SELECT * FROM [GMPS PAYMENTS OUT] where [RegisterDate]>='" & FDateSql & "' and [RegisterDate]<='" & LDateSql & "'"
                            sqlCmd.Connection = sqlConn
                            If sqlConn.State = ConnectionState.Closed Then
                                sqlConn.Open()
                            End If

                            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                            Dim objDataTable As New DataTable()
                            objDataTable.Load(objDataReader)
                            If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                                Me.GridControl2.DataSource = Nothing
                                Me.GridControl2.DataSource = objDataTable
                                Me.GridControl2.ForceInitialize()

                            Else
                                SplashScreenManager.CloseForm(False)
                                MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Return
                            End If
                            If sqlConn.State = ConnectionState.Open Then
                                sqlConn.Close()
                            End If

                        End Using
                    End Using
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try



                SplashScreenManager.CloseForm(False)
            Else
                MessageBox.Show("Date From is higher than Date Till", "WRONG DATE INPUT", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub PaymentsOut_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PaymentsOut_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PaymentsOut_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PaymentsOut_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If LayoutViews_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            If MessageType.ToString = "103" Then
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
            ElseIf MessageType.ToString = "200" OrElse MessageType.ToString = "202" OrElse MessageType.ToString = "202COV" Then
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

        Dim reportfooter As String = "OUTGOING PAYMENT ORDERS"
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


End Class