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
Imports DevExpress.XtraPrinting.Links
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.Spreadsheet
Public Class OPICS_MM_FX

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""
    Dim DealStatusChangeEnable As String = Nothing

    Dim ActiveTabGroup As Double = 0

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim ExcelFileName As String = Nothing

    Dim MM_ValidityCheck As String = Nothing
    Dim FX_ValidityCheck As String = Nothing


    Private QueryText As String = ""
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

    Private Sub OPICS_MMBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OPICS_MMBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)

    End Sub

    Private Sub OPICS_MM_FX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.OPICS_FX_SWAPSTableAdapter.FillbyFX_TradeDate(Me.MM_Statistic_Dataset.OPICS_FX_SWAPS)
        Me.OPICS_FXTableAdapter.Fill(Me.MM_Statistic_Dataset.OPICS_FX)
        Me.OPICS_MMTableAdapter.FillOpicsMM_Deals(Me.MM_Statistic_Dataset.OPICS_MM)

        '***********************************************************************
        '*******PARAMETERS************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='DealsStatusChangeEnable' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [IdABTEILUNGSCODE_NAME]='MELDEWESEN' and [PARAMETER STATUS]='Y' "
        DealStatusChangeEnable = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '***********************************************************************

        'Enable / Disable the Deals Meldepflicht Status to Change
        If DealStatusChangeEnable = "N" Then
            MM_All_BaseView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.ReadOnly = True
            MM_All_BaseView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.AllowEdit = False
            OPICS_FX_SW_Deals_BandedGridView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.ReadOnly = True
            OPICS_FX_SW_Deals_BandedGridView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.AllowEdit = False
        ElseIf DealStatusChangeEnable = "Y" Then
            MM_All_BaseView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.ReadOnly = False
            MM_All_BaseView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.AllowEdit = True
            OPICS_FX_SW_Deals_BandedGridView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.ReadOnly = False
            OPICS_FX_SW_Deals_BandedGridView.Columns.ColumnByFieldName("Meldepflicht").OptionsColumn.AllowEdit = True
        End If


        'MM DEALS
        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl1.MainView = MM_All_BaseView
        MM_All_BaseView.ForceDoubleClick = True
        AddHandler MM_All_BaseView.DoubleClick, AddressOf MM_All_BaseView_DoubleClick
        AddHandler MM_All_LayoutView.MouseDown, AddressOf MM_All_LayoutView_MouseDown
        AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        MM_All_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        MM_All_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'FX DEALS
        GridControl2.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = OPICS_FX_Deals_GridView
        OPICS_FX_Deals_GridView.ForceDoubleClick = True
        AddHandler OPICS_FX_Deals_GridView.DoubleClick, AddressOf OPICS_FX_Deals_GridView_DoubleClick
        AddHandler OPICS_FX_Deals_LayoutView.MouseDown, AddressOf OPICS_FX_Deals_LayoutView_MouseDown
        'AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        OPICS_FX_Deals_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        OPICS_FX_Deals_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'FX SWAP
        GridControl3.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl3.MainView = OPICS_FX_SW_Deals_BandedGridView
        OPICS_FX_SW_Deals_BandedGridView.ForceDoubleClick = True
        AddHandler OPICS_FX_SW_Deals_BandedGridView.DoubleClick, AddressOf OPICS_FX_SW_Deals_BandedGridView_DoubleClick
        AddHandler OPICS_FX_SW_LayoutView.MouseDown, AddressOf OPICS_FX_SW_LayoutView_MouseDown
        'AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        OPICS_FX_SW_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        OPICS_FX_SW_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            GridControl1.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = MM_All_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl1.MainView = MM_All_BaseView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl1.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl1.MainView Is MM_All_LayoutView)
        ElseIf ActiveTabGroup = 1 Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = OPICS_FX_Deals_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = OPICS_FX_Deals_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl2.MainView Is OPICS_FX_Deals_LayoutView)
        ElseIf ActiveTabGroup = 2 Then
            GridControl3.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = OPICS_FX_SW_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = OPICS_FX_SW_Deals_BandedGridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl3.MainView Is OPICS_FX_SW_LayoutView)
        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            Dim datasourceRowIndex As Integer = MM_All_BaseView.GetDataSourceRowIndex(rowHandle)
            GridControl1.MainView = MM_All_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl1.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl1.MainView Is MM_All_LayoutView)
        ElseIf ActiveTabGroup = 1 Then
            Dim datasourceRowIndex As Integer = OPICS_FX_Deals_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = OPICS_FX_Deals_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl2.MainView Is OPICS_FX_Deals_LayoutView)
        ElseIf ActiveTabGroup = 2 Then
            Dim datasourceRowIndex As Integer = OPICS_FX_SW_Deals_BandedGridView.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = OPICS_FX_SW_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl3.MainView Is OPICS_FX_SW_LayoutView)
        End If


    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = MM_All_BaseView.GetRowHandle(dataSourceRowIndex)
            MM_All_BaseView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = OPICS_FX_Deals_GridView.GetRowHandle(dataSourceRowIndex)
            OPICS_FX_Deals_GridView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 2 Then
            Dim rowHandle As Integer = OPICS_FX_SW_Deals_BandedGridView.GetRowHandle(dataSourceRowIndex)
            OPICS_FX_SW_Deals_BandedGridView.FocusedRowHandle = rowHandle
        End If

    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = MM_All_LayoutView.GetRowHandle(dataSourceRowIndex)
            MM_All_LayoutView.VisibleRecordIndex = MM_All_LayoutView.GetVisibleIndex(rowHandle)
            MM_All_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = OPICS_FX_Deals_LayoutView.GetRowHandle(dataSourceRowIndex)
            OPICS_FX_Deals_LayoutView.VisibleRecordIndex = OPICS_FX_Deals_LayoutView.GetVisibleIndex(rowHandle)
            OPICS_FX_Deals_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 2 Then
            Dim rowHandle As Integer = OPICS_FX_SW_LayoutView.GetRowHandle(dataSourceRowIndex)
            OPICS_FX_SW_LayoutView.VisibleRecordIndex = OPICS_FX_SW_LayoutView.GetVisibleIndex(rowHandle)
            OPICS_FX_SW_LayoutView.FocusedRowHandle = dataSourceRowIndex
        End If

    End Sub


    Protected Sub MM_All_BaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = MM_All_BaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub OPICS_FX_Deals_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = OPICS_FX_Deals_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub OPICS_FX_SW_Deals_BandedGridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = OPICS_FX_SW_Deals_BandedGridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub


    Protected Sub MM_All_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = MM_All_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub OPICS_FX_Deals_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = OPICS_FX_Deals_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub OPICS_FX_SW_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = OPICS_FX_SW_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub



    Protected Sub View_Details_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If ActiveTabGroup = 0 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
            End If
        ElseIf ActiveTabGroup = 1 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            End If
        ElseIf ActiveTabGroup = 2 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
            End If
        End If

    End Sub
#End Region




    Private Sub MM_All_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MM_All_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub MM_All_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles MM_All_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OPICS_FX_Deals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OPICS_FX_Deals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OPICS_FX_Deals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OPICS_FX_Deals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OPICS_FX_SW_Deals_BandedGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OPICS_FX_SW_Deals_BandedGridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OPICS_FX_SW_Deals_BandedGridView_ShownEditor(sender As Object, e As EventArgs) Handles OPICS_FX_SW_Deals_BandedGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "OPICS MM Deals" Then
            ActiveTabGroup = 0

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "OPICS FX Deals" Then
            ActiveTabGroup = 1

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "OPICS SWAP FX DEALS (Near and Far Leg)" Then
            ActiveTabGroup = 2
        End If
    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl1.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.MM_All_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.MM_All_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.MM_All_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.MM_All_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.MM_All_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.MM_All_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.MM_All_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.MM_All_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If

        If ActiveTabGroup = 1 Then
            If Not GridControl2.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink2.CreateDocument()
                PrintableComponentLink2.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.OPICS_FX_Deals_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.OPICS_FX_Deals_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.OPICS_FX_Deals_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.OPICS_FX_Deals_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.OPICS_FX_Deals_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.OPICS_FX_Deals_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.OPICS_FX_Deals_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.OPICS_FX_Deals_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If


        If ActiveTabGroup = 2 Then
            If Not GridControl3.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink3.CreateDocument()
                PrintableComponentLink3.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.OPICS_FX_SW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.OPICS_FX_SW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.OPICS_FX_SW_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.OPICS_FX_SW_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.OPICS_FX_SW_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.OPICS_FX_SW_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl3, GridControl3.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.OPICS_FX_SW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.OPICS_FX_SW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

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
        Dim reportfooter As String = "OPICS MM Deals"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPICS FX Deals"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPICS FX SWAP Deals"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub MM_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles MM_RepositoryItemImageComboBox.EditValueChanged
        Dim gv As GridView = Me.MM_All_BaseView
        If gv.IsFilterRow(gv.FocusedRowHandle) = False Then
            Dim Meldepflicht As String = gv.GetFocusedRowCellValue("Meldepflicht").ToString
            Dim CCY As String = gv.GetFocusedRowCellValue("CCY").ToString
            Dim DaysToMaturity As Double = gv.GetFocusedRowCellValue("DaysToMaturity").ToString
            If Meldepflicht = "N" And CCY <> "EUR" Or DaysToMaturity > 397 Then
                XtraMessageBox.Show("Unable to change the Meldepflicht (Reporting Status) of the MM Deal" & vbNewLine & "One of the following two basic arguments are not present:" & vbNewLine & vbNewLine & "1. Currency (CCY) must be allways in EURO" & vbNewLine & "2. The Days count to Maturity should be equal or less 397", "ERROR ON REPORTING STATUS CHANGE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MM_ValidityCheck = "N"
            Else
                MM_ValidityCheck = "Y"

            End If

            If MM_ValidityCheck = "Y" Then
                Try
                    MM_All_BaseView.PostEditor()
                    Me.Validate()
                    Me.OPICS_MMBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)
                    '***********************************************************************
                Catch ex As Exception
                    MM_All_BaseView.HideEditor()
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            ElseIf MM_ValidityCheck = "N" Then
                MM_All_BaseView.HideEditor()
            End If
        End If


    End Sub

    Private Sub FX_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles FX_RepositoryItemImageComboBox.EditValueChanged

        Dim gv As GridView = Me.OPICS_FX_SW_Deals_BandedGridView
        If gv.IsFilterRow(gv.FocusedRowHandle) = False Then
            Dim Meldepflicht As String = gv.GetFocusedRowCellValue("Meldepflicht").ToString
            Dim CCY As String = gv.GetFocusedRowCellValue("NearLeg_CCY").ToString
            Dim CTR As String = gv.GetFocusedRowCellValue("NearLeg_CTR").ToString
            Dim DaysToMaturity As Double = gv.GetFocusedRowCellValue("DaysToMaturity").ToString
            If Meldepflicht = "N" And CCY <> "EUR" And CTR <> "EUR" Or DaysToMaturity > 397 Then
                XtraMessageBox.Show("Unable to change the Meldepflicht (Reporting Status) of the SWAP FX Deal" & vbNewLine & "One of the following two basic arguments are not present:" & vbNewLine & vbNewLine & "1. Currency (CCY and CTR) must be allways in EURO" & vbNewLine & "2. The Days count to Maturity should be equal or less 397", "ERROR ON REPORTING STATUS CHANGE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                FX_ValidityCheck = "N"
            Else
                FX_ValidityCheck = "Y"

            End If

            If FX_ValidityCheck = "Y" Then
                Try
                    OPICS_FX_SW_Deals_BandedGridView.PostEditor()
                    Me.Validate()
                    Me.OPICS_FX_SWAPSBindingSource.EndEdit()
                    Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)
                    '***********************************************************************
                Catch ex As Exception
                    OPICS_FX_SW_Deals_BandedGridView.HideEditor()
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            ElseIf FX_ValidityCheck = "N" Then
                OPICS_FX_SW_Deals_BandedGridView.HideEditor()
            End If
        End If

    End Sub

    Private Sub UpdateMissingData_btn_Click(sender As Object, e As EventArgs) Handles UpdateMissingData_btn.Click
        'OLD CODE
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'SplashScreenManager.Default.SetWaitFormCaption("Update missing Customers Data in Tables:OPICS_MM, OPICS_FX and OPICS_FX_SWAPS")
        'If cmd.Connection.State = ConnectionState.Closed Then
        '   cmd.Connection.Open()
        'End If
        'cmd.CommandText = "Update A set A.[OCBS_Cust_Nr]=B.ClientNo, A.[OCBS_Cust_Name]=B.[English Name] ,A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_MM A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where A.[OCBS_Cust_Nr] is NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "Update A set A.[OCBS_Customer_Name]=B.[English Name] ,A.[OCBS_Cust_Nr]=B.ClientNo, A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_FX A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where A.[OCBS_Cust_Nr] is NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.[OCBS_Cust_Nr],A.[OCBS_Customer_Name]=B.[OCBS_Customer_Name],A.[BIC_CODE]=B.[BIC_CODE],A.[LEI_CODE]=B.LEI_CODE from OPICS_FX_SWAPS A INNER JOIN OPICS_FX B on A.CUSTOMER=B.CUSTOMER where A.[OCBS_Cust_Nr] is NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "Update A set A.[OCBS_Cust_Nr]=B.ClientNo, A.[OCBS_Cust_Name]=B.[English Name] ,A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_MM A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where (A.[BIC_CODE] is NULL or Len(A.[BIC_CODE])=0)"
        'cmd.ExecuteNonQuery()
        'If cmd.Connection.State = ConnectionState.Open Then
        '   cmd.Connection.Close()
        'End If
        'Me.OPICS_FX_SWAPSTableAdapter.FillbyFX_TradeDate(Me.MM_Statistic_Dataset.OPICS_FX_SWAPS)
        'Me.OPICS_FXTableAdapter.Fill(Me.MM_Statistic_Dataset.OPICS_FX)
        'Me.OPICS_MMTableAdapter.FillOpicsMM_Deals(Me.MM_Statistic_Dataset.OPICS_MM)
        'SplashScreenManager.CloseForm(False)

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Update missing Customers Data in Tables:OPICS_MM, OPICS_FX and OPICS_FX_SWAPS")
        Me.QueryText = "Select [ID] from [OPICS_MM] where [OCBS_Cust_Nr] is NULL"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Update A set A.[OCBS_Cust_Nr]=B.ClientNo, A.[OCBS_Cust_Name]=B.[English Name],A.[ClientType]=B.[ClientType] ,A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_MM A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where A.[OCBS_Cust_Nr] is NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update A set A.[OCBS_Cust_Nr]=B.ClientNo, A.[OCBS_Cust_Name]=B.[English Name],A.[ClientType]=B.[ClientType] ,A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_MM A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where (A.[BIC_CODE] is NULL or Len(A.[BIC_CODE])=0)"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update OPICS_MM set Meldepflicht='Y' where DaysToMaturity<=397 and CCY in ('EUR') and [ID]='" & dt.Rows.Item(i).Item("ID") & "' and OCBS_Cust_Nr not in (Select ClientNo from [CUSTOMER_INFO] where ([CCB_Group] in ('Y') or [CCB_Group_OwnID] in ('Y')))"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update OPICS_MM set Meldepflicht='N' where [REVERSAL_REASON] is not NULL and [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update OPICS_MM set Meldepflicht='N' where [ClientType] in ('C - COMPANY') and [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            Next
        End If
        Me.QueryText = "Select [ID] from [OPICS_FX_SWAPS] where [OCBS_Cust_Nr] is NULL"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For i = 0 To dt1.Rows.Count - 1
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Update A set A.[OCBS_Customer_Name]=B.[English Name] ,A.[OCBS_Cust_Nr]=B.ClientNo,A.[ClientType]=B.[ClientType] A.[BIC_CODE]=b.BIC11, A.LEI_CODE=B.LEI_CODE from OPICS_FX A INNER JOIN CUSTOMER_INFO B on A.CUSTOMER=B.OpicsCustomerCode where A.[OCBS_Cust_Nr] is NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.[OCBS_Cust_Nr],A.[OCBS_Customer_Name]=B.[OCBS_Customer_Name],A.[ClientType]=B.[ClientType],A.[BIC_CODE]=B.[BIC_CODE],A.[LEI_CODE]=B.LEI_CODE from OPICS_FX_SWAPS A INNER JOIN OPICS_FX B on A.CUSTOMER=B.CUSTOMER where A.[OCBS_Cust_Nr] is NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [OPICS_FX_SWAPS] set Meldepflicht='Y' where DaysToMaturity<=397 and (NearLeg_CCY in ('EUR') or NearLeg_CTR in ('EUR')) and OCBS_Cust_Nr not in (Select ClientNo from [CUSTOMER_INFO] where ([CCB_Group] in ('Y') or [CCB_Group_OwnID] in ('Y'))) and [ID]='" & dt1.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [OPICS_FX_SWAPS] set Meldepflicht='N' where [ClientType] in ('C - COMPANY') and [ID]='" & dt1.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            Next
        End If

        Me.OPICS_FX_SWAPSTableAdapter.FillbyFX_TradeDate(Me.MM_Statistic_Dataset.OPICS_FX_SWAPS)
        Me.OPICS_FXTableAdapter.Fill(Me.MM_Statistic_Dataset.OPICS_FX)
        Me.OPICS_MMTableAdapter.FillOpicsMM_Deals(Me.MM_Statistic_Dataset.OPICS_MM)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class