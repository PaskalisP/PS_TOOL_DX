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

Public Class MAK
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
    Private Sub MAK_REPORTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MAK_REPORTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub MAK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Bind Combobox
        Me.MAKDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [MAK CR TOTALS] where [RiskDate]<='20171208'  Order by [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.MAKDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.MAKDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxMAKDate As Date = Me.MAKDateEdit.Text
        
        Me.MAK_REPORTTableAdapter.FillByMakDate(Me.PSTOOLDataset.MAK_REPORT, MaxMAKDate)

        'Gridcontrol2 
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = MAKBaseView
        MAKBaseView.ForceDoubleClick = True
        AddHandler MAKBaseView.DoubleClick, AddressOf MAKBaseView_DoubleClick
        AddHandler MAKDetailView.MouseDown, AddressOf MAKDetailView_MouseDown
        AddHandler MAKViewDetail_btn.Click, AddressOf MAKViewDetail_btn_Click
        MAKDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        MAKDetailView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "MAK_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = MAKDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = MAKBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        MAKViewDetail_btn.Text = strShowExtendedMode
        MAKViewDetail_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is MAKDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = MAKBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = MAKDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        MAKViewDetail_btn.Text = strHideExtendedMode
        MAKViewDetail_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is MAKDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = MAKBaseView.GetRowHandle(dataSourceRowIndex)
        MAKBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = MAKDetailView.GetRowHandle(dataSourceRowIndex)
        MAKDetailView.VisibleRecordIndex = MAKDetailView.GetVisibleIndex(rowHandle)
        MAKDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub MAKBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = MAKBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub MAKDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = MAKDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub MAKViewDetail_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub MAKBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MAKBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub MAKDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles MAKDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl2.DataSource = Me.MAK_REPORTBindingSource

            If IsDate(Me.MAKDateEdit.Text) = True Then
                Dim d As Date = Me.MAKDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load MAK Report (Original Data) for " & d)
                'Load Fristen Data
                Me.MAK_REPORTTableAdapter.FillByMakDate(Me.PSTOOLDataset.MAK_REPORT, d)
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub MAKDateEdit_Click(sender As Object, e As EventArgs) Handles MAKDateEdit.Click
        If IsDate(Me.MAKDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub MAKDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles MAKDateEdit.KeyDown
        If IsDate(Me.MAKDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadMAK_btn_Click(sender As Object, e As EventArgs) Handles LoadMAK_btn.Click
       
    End Sub

    Private Sub MAKBaseView_ShownEditor(sender As Object, e As EventArgs) Handles MAKBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub MAK_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles MAK_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        If Me.MAKViewDetail_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.MAKDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.MAKDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.MAKDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.MAKDetailView.OptionsPrint.PrintCardCaption = True
            Me.MAKDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.MAKDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.MAKDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.MAKDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.MAKDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
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
        Dim reportfooter As String = "MAK Report " & "   " & "on: " & Me.MAKDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub MAKDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MAKDateEdit.SelectedIndexChanged
        Me.GridControl2.DataSource = Me.MAK_REPORTBindingSource

        If IsDate(Me.MAKDateEdit.Text) = True Then
            Dim d As Date = Me.MAKDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load MAK Report (Original Data) for " & d)
                'Load Fristen Data
                Me.MAK_REPORTTableAdapter.FillByMakDate(Me.PSTOOLDataset.MAK_REPORT, d)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
End Class