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
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class Fx_Deals_ALL

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim ActiveTabGroup As Double = 0

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim ExcelFileName As String = Nothing
    

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Private Sub FX_ALLBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FX_ALLBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TreasuryDataSet)

    End Sub

    Private Sub Fx_Deals_ALL_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)

            Me.FX_Pairs_TableAdapter.Fill_FX_Pairs(Me.TreasuryDataSet.FX_Pairs)
            Me.FX_ALLTableAdapter.FillByAllFX(Me.TreasuryDataSet.FX_ALL)

            'Get Last Update
            cmd.CommandText = "SELECT [LastImportTime] from [MANUAL IMPORTS] where [ProcName]='ODAS FX DEALS'"
            cmd.Connection.Open()
            Dim d As DateTime = cmd.ExecuteScalar
            Me.LastUpdate_txt.Text = d
            cmd.Connection.Close()

            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub Fx_Deals_ALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get connection
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 50000

        Me.FX_Pairs_TableAdapter.Fill_FX_Pairs(Me.TreasuryDataSet.FX_Pairs)
        Me.FX_ALLTableAdapter.FillByAllFX(Me.TreasuryDataSet.FX_ALL)

        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl1.MainView = FX_All_BaseView
        FX_All_BaseView.ForceDoubleClick = True
        AddHandler FX_All_BaseView.DoubleClick, AddressOf FX_All_BaseView_DoubleClick
        AddHandler FX_All_LayoutView1.MouseDown, AddressOf FX_All_LayoutView1_MouseDown
        AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        FX_All_LayoutView1.OptionsBehavior.AutoFocusCardOnScrolling = True
        FX_All_LayoutView1.OptionsBehavior.AllowSwitchViewModes = False

        'Get Last Update
        cmd.CommandText = "SELECT [LastImportTime] from [MANUAL IMPORTS] where [ProcName]='ODAS FX DEALS'"
        cmd.Connection.Open()
        Dim d As DateTime = cmd.ExecuteScalar
        Me.LastUpdate_txt.Text = d
        cmd.Connection.Close()



    End Sub

#Region "FX DEALS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl1.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = FX_All_LayoutView1.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = FX_All_BaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        View_Details_btn.Text = strShowExtendedMode
        'BICViews_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl1.MainView Is FX_All_LayoutView1)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = FX_All_BaseView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = FX_All_LayoutView1
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        'Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        'Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        View_Details_btn.Text = strHideExtendedMode
        'BICViews_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl1.MainView Is FX_All_LayoutView1)


    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FX_All_BaseView.GetRowHandle(dataSourceRowIndex)
        FX_All_BaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FX_All_LayoutView1.GetRowHandle(dataSourceRowIndex)
        FX_All_LayoutView1.VisibleRecordIndex = FX_All_LayoutView1.GetVisibleIndex(rowHandle)
        FX_All_LayoutView1.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub FX_All_BaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = FX_All_BaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub FX_All_LayoutView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = FX_All_LayoutView1.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub View_Details_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub FX_All_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_All_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_All_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles FX_All_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub



    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.FX_All_LayoutView1.OptionsPrint.PrintSelectedCardsOnly = True
                Me.FX_All_LayoutView1.OptionsPrint.PrintCardCaption = True
                Me.FX_All_LayoutView1.OptionsPrint.AllowCancelPrintExport = True
                Me.FX_All_LayoutView1.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If

        If ActiveTabGroup = 1 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A3, _
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
        Dim reportfooter As String = "ALL FX DEALS" & "   " & "on: " & Today
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
        Dim reportfooter As String = "FX PAIRS" & "   " & "on: " & Today
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

   
    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "FX DEALS - ALL" Then
            ActiveTabGroup = 0
            Me.LayoutControlItem2.Visibility = LayoutVisibility.Always
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "FX PAIRS" Then
            ActiveTabGroup = 1
            Me.LayoutControlItem2.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub FX_Pairs_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_Pairs_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_Pairs_GridView_ShownEditor(sender As Object, e As EventArgs) Handles FX_Pairs_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
End Class