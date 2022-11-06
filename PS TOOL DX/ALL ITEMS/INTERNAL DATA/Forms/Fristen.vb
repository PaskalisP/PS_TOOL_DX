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
Imports DevExpress.XtraEditors.Controls
Public Class Fristen

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim QueryText As String
    Private da As SqlDataAdapter
    Private dt As DataTable

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
    Private Sub FRISTENBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FRISTENBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub Fristen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Bind Combobox
        Me.FristenDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [FRISTEN]  GROUP BY [RiskDate] Order by [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FristenDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FristenDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        Dim MaxFristenDate As Date = Me.FristenDateEdit.Text
        

        'TODO: This line of code loads data into the 'PSTOOLDataset.FRISTEN' table. You can move, or remove it, as needed.
        Me.FRISTENTableAdapter.FillByFristenDate(Me.PSTOOLDataset.FRISTEN, MaxFristenDate)

        'Gridcontrol2 
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = FristenBaseView
        FristenBaseView.ForceDoubleClick = True
        AddHandler FristenBaseView.DoubleClick, AddressOf FristenBaseView_DoubleClick
        AddHandler FristenDetailView.MouseDown, AddressOf FristenDetailView_MouseDown
        AddHandler FristenViewDetails_btn.Click, AddressOf FristenViewDetails_btn_Click
        FristenDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        FristenDetailView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "FRISTEN_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = FristenDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = FristenBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        FristenViewDetails_btn.Text = strShowExtendedMode
        FristenViewDetails_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is FristenDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = FristenBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = FristenDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        FristenViewDetails_btn.Text = strHideExtendedMode
        FristenViewDetails_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is FristenDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FristenBaseView.GetRowHandle(dataSourceRowIndex)
        FristenBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FristenDetailView.GetRowHandle(dataSourceRowIndex)
        FristenDetailView.VisibleRecordIndex = FristenDetailView.GetVisibleIndex(rowHandle)
        FristenDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub FristenBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = FristenBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub FristenDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = FristenDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub FristenViewDetails_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region


    Private Sub FristenBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FristenBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FristenDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FristenDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl2.DataSource = Me.FRISTENBindingSource

            If IsDate(Me.FristenDateEdit.Text) = True Then
                Dim d As Date = Me.FristenDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Fristen Report Data for " & d)
                'Load Fristen Data
                Me.FRISTENTableAdapter.FillByFristenDate(Me.PSTOOLDataset.FRISTEN, d)
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub FristenDateEdit_Click(sender As Object, e As EventArgs) Handles FristenDateEdit.Click
        If IsDate(Me.FristenDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub FristenDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FristenDateEdit.KeyDown
        If IsDate(Me.FristenDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadFristen_btn_Click(sender As Object, e As EventArgs) Handles LoadFristen_btn.Click
        
    End Sub

    Private Sub Fristen_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Fristen_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        If Me.FristenViewDetails_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.FristenDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.FristenDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.FristenDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.FristenDetailView.OptionsPrint.PrintCardCaption = True
            Me.FristenDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.FristenDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.FristenDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.FristenDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.FristenDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
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
        Dim reportfooter As String = "FRISTEN Report " & "   " & "on: " & Me.FristenDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub FristenDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles FristenDateEdit.EditValueChanged
       
    End Sub

    Private Sub FristenBaseView_ShownEditor(sender As Object, e As EventArgs) Handles FristenBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FristenDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FristenDateEdit.SelectedIndexChanged
        Me.GridControl2.DataSource = Me.FRISTENBindingSource

        If IsDate(Me.FristenDateEdit.Text) = True Then
            Dim d As Date = Me.FristenDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Fristen Report Data for " & d)
            'Load Fristen Data
            Me.FRISTENTableAdapter.FillByFristenDate(Me.PSTOOLDataset.FRISTEN, d)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
End Class