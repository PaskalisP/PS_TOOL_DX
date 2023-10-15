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
Public Class OdasRemmitances

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim FDateSql As String = Nothing
    Dim LDateSql As String = Nothing

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

    Private Sub ODAS_REMMITANCESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ODAS_REMMITANCESBindingSource.EndEdit()
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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub OdasRemmitances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        'cmd.CommandText = "Select Max(TRANSACTIONDATE) from [ODAS REMMITANCES]"
        cmd.CommandText = "Select DPARAMETER1 from PARAMETER where PARAMETER1 in ('ODAS_REMMITANCES') and IdABTEILUNGSPARAMETER in ('MAX_DATES') and IdABTEILUNGSCODE_NAME in ('CLEARING')"
        Dim d As Date = cmd.ExecuteScalar
        CloseSqlConnections()

        '***********************************************************************
        Me.DateFrom_BarEditItem.EditValue = d
        Me.DateTill_BarEditItem.EditValue = d

        'Gridcontrol2 - CUSTOMERS
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = ODASBaseView
        ODASBaseView.ForceDoubleClick = True
        AddHandler ODASBaseView.DoubleClick, AddressOf ODASBaseView_DoubleClick
        AddHandler ODASDetailView.MouseDown, AddressOf ODASDetailView_MouseDown
        ODASDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        ODASDetailView.OptionsBehavior.AllowSwitchViewModes = False
    

    End Sub



#Region "ODAS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)

        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = ODASDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = ODASBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strShowExtendedMode
        DisplayListDetails_bbi.ImageIndex = 8
        fExtendedEditMode = (GridControl2.MainView Is ODASDetailView)

        '****************************************
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = ODASBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = ODASDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strHideExtendedMode
        DisplayListDetails_bbi.ImageIndex = 9
        fExtendedEditMode = (GridControl2.MainView Is ODASDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ODASBaseView.GetRowHandle(dataSourceRowIndex)
        ODASBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = ODASDetailView.GetRowHandle(dataSourceRowIndex)
        ODASDetailView.VisibleRecordIndex = ODASDetailView.GetVisibleIndex(rowHandle)
        ODASDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub ODASBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = ODASBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub ODASDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = ODASDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub ViewEdit_btn_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
#End Region

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
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

            Me.BgwLoadPayments.ReportProgress(10, "Load all ODAS Remmitances from: " & FDate & " till " & LDate)
            FDateSql = FDate.ToString("yyyyMMdd")
            LDateSql = LDate.ToString("yyyyMMdd")

            SqlCommandText = "SELECT * FROM [ODAS REMMITANCES] where [TRANSACTIONDATE] BETWEEN '" & FDateSql & "' and '" & LDateSql & "'"
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
            Me.LayoutControlGroup2.Text = "ODAS Remittances from: " & FDate & " till " & LDate
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
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.ODASDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.ODASDetailView.OptionsPrint.PrintCardCaption = True
            Me.ODASDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.ODASDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.ODASDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.ODASDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


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
        Dim reportfooter As String = "ODAS REMITTANCES FROM" & FDate & " TILL " & LDate
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()

    End Sub

    Private Sub OdasRemmitances_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class