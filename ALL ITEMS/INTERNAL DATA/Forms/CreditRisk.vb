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
Public Class CreditRisk

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

    Private Sub CREDIT_RISKBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CREDIT_RISKBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub CreditRisk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Bind Combobox
        Me.CreditRiskDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [MAK CR TOTALS] where [RiskDate]<='20171208'  Order by [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.CreditRiskDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.CreditRiskDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If


        'Get
        Dim MaxCreditRiskDate As Date = Me.CreditRiskDateEdit.Text
       
        Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.PSTOOLDataset.CREDIT_RISK, MaxCreditRiskDate)

        'Gridcontrol2 
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = CreditRiskBaseView
        CreditRiskBaseView.ForceDoubleClick = True
        AddHandler CreditRiskBaseView.DoubleClick, AddressOf CreditRiskBaseView_DoubleClick
        AddHandler CreditRiskDetailView.MouseDown, AddressOf CreditRiskDetailView_MouseDown
        AddHandler CreditRiskViewDetails_btn.Click, AddressOf CreditRiskViewDetails_btn_Click
        CreditRiskDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        CreditRiskDetailView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "CREDIT_RISK_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = CreditRiskDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CreditRiskBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CreditRiskViewDetails_btn.Text = strShowExtendedMode
        CreditRiskViewDetails_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is CreditRiskDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = CreditRiskBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CreditRiskDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CreditRiskViewDetails_btn.Text = strHideExtendedMode
        CreditRiskViewDetails_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is CreditRiskDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CreditRiskBaseView.GetRowHandle(dataSourceRowIndex)
        CreditRiskBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CreditRiskDetailView.GetRowHandle(dataSourceRowIndex)
        CreditRiskDetailView.VisibleRecordIndex = CreditRiskDetailView.GetVisibleIndex(rowHandle)
        CreditRiskDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub CreditRiskBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = CreditRiskBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub CreditRiskDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = CreditRiskDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub CreditRiskViewDetails_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region



    Private Sub CreditRiskBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CreditRiskBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CreditRiskBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CreditRiskBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CreditRiskDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CreditRiskDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl2.DataSource = Me.CREDIT_RISKBindingSource

            If IsDate(Me.CreditRiskDateEdit.Text) = True Then
                Dim d As Date = Me.CreditRiskDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Credit Risk Report (Original Data) for " & d)

                Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.PSTOOLDataset.CREDIT_RISK, d)

                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub CreditRiskDateEdit_Click(sender As Object, e As EventArgs) Handles CreditRiskDateEdit.Click
        If IsDate(Me.CreditRiskDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub CreditRiskDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles CreditRiskDateEdit.KeyDown
        If IsDate(Me.CreditRiskDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadCreditRisk_btn_Click(sender As Object, e As EventArgs) Handles LoadCreditRisk_btn.Click
       
    End Sub

    Private Sub CreditRisk_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles CreditRisk_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        If Me.CreditRiskViewDetails_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.CreditRiskDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.CreditRiskDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.CreditRiskDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.CreditRiskDetailView.OptionsPrint.PrintCardCaption = True
            Me.CreditRiskDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.CreditRiskDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.CreditRiskDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.CreditRiskDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.CreditRiskDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
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
        Dim reportfooter As String = "Credit Risk Report " & "   " & "on: " & Me.CreditRiskDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CreditRiskDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CreditRiskDateEdit.SelectedIndexChanged
        Me.GridControl2.DataSource = Me.CREDIT_RISKBindingSource

        If IsDate(Me.CreditRiskDateEdit.Text) = True Then
            Dim d As Date = Me.CreditRiskDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Credit Risk Report (Original Data) for " & d)

                Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.PSTOOLDataset.CREDIT_RISK, d)
           
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
End Class