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
Public Class BLZ_DIRECTORY

    Private conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private QueryText1 As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    'BLZ Directory Data
    <VBFixedString(8)> Dim BANKLEITZAHL As String = Nothing
    <VBFixedString(1)> Dim MERKMAL As String = Nothing
    <VBFixedString(58)> Dim BEZEICHNUNG As String = Nothing
    <VBFixedString(5)> Dim POSTLEITZAHL As String = Nothing
    <VBFixedString(35)> Dim ORT As String = Nothing
    <VBFixedString(27)> Dim KURZBEZEICHNUNG As String = Nothing
    <VBFixedString(5)> Dim PAN_NR As String = Nothing
    <VBFixedString(11)> Dim BIC As String = Nothing
    <VBFixedString(2)> Dim PRUEFZIFFER_KZ As String = Nothing
    <VBFixedString(6)> Dim DATENSATZ_NR As String = Nothing
    <VBFixedString(1)> Dim AENDERUNG_KZ As String = Nothing
    <VBFixedString(1)> Dim BLZ_LOESCHUNG As String = Nothing
    <VBFixedString(8)> Dim NACHFOLGE_BLZ As String = Nothing

    Dim BLZ_ROW As String = Nothing

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

    Private Sub BLZ_DIRECTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.BLZTableAdapter.Fill(Me.EXTERNALDataset.BLZ)

        'Gridcontrol2 - BIC DIRECTORY
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = BLZGridView
        BLZGridView.ForceDoubleClick = True
        AddHandler BLZGridView.DoubleClick, AddressOf BLZGridView_DoubleClick
        AddHandler BLZLayoutView.MouseDown, AddressOf BLZLayoutView_MouseDown
        AddHandler BLZViews_btn.Click, AddressOf BLZViews_btn_Click
        BLZLayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        BLZLayoutView.OptionsBehavior.AllowSwitchViewModes = False
    End Sub

#Region "BLZ_DIRECTORY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = BLZLayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BLZGridView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BLZViews_btn.Text = strShowExtendedMode
        BLZViews_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is BLZLayoutView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = BLZGridView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BLZLayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BLZViews_btn.Text = strHideExtendedMode
        BLZViews_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is BLZLayoutView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BLZGridView.GetRowHandle(dataSourceRowIndex)
        BLZGridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BLZLayoutView.GetRowHandle(dataSourceRowIndex)
        BLZLayoutView.VisibleRecordIndex = BLZLayoutView.GetVisibleIndex(rowHandle)
        BLZLayoutView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub BLZGridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BLZGridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub BLZLayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = BLZLayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub BLZViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub BLZGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BLZGridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BLZGridView_ShownEditor(sender As Object, e As EventArgs) Handles BLZGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BLZPrint_Export_btn_Click(sender As Object, e As EventArgs) Handles BLZPrint_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If BLZViews_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.BLZLayoutView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.BLZLayoutView.OptionsPrint.PrintCardCaption = True
            Me.BLZLayoutView.OptionsPrint.AllowCancelPrintExport = True
            Me.BLZLayoutView.OptionsPrint.ShowPrintExportProgress = True
            'Me.BLZLayoutView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.BLZLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True


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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "BLZ DIRECTORY" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BLZ_Dir_Create_btn_Click(sender As Object, e As EventArgs) Handles BLZ_Dir_Create_btn.Click
        If MessageBox.Show("Should the BLZ Directory (BLZ plus BIC) be re-created?" & vbNewLine & vbNewLine & "Existing File will be deleted!", "BLZplusBIC Directory creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Select only Institutions from BLZ Directory with BIC")
                If File.Exists("C:\BLZ_plus_BIC_from_PSTOOL.txt") = True Then
                    File.Delete("C:\BLZ_plus_BIC_from_PSTOOL.txt")
                End If
                Me.QueryText = "SELECT  * FROM  [BLZ] where [BIC]<>'' and [Änderungs-kennzeichen] not in ('D') ORDER BY [Bankleitzahl] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SplashScreenManager.Default.SetWaitFormCaption("Create Datarow in BLZ Directory for BLZ: " & dt.Rows.Item(i).Item("Bankleitzahl") & vbNewLine & dt.Rows.Item(i).Item("Bezeichnung"))
                    BANKLEITZAHL = dt.Rows.Item(i).Item("Bankleitzahl")
                    MERKMAL = dt.Rows.Item(i).Item("Merkmal")
                    BEZEICHNUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Bezeichnung"), 58)
                    POSTLEITZAHL = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("PLZ"), 5)
                    ORT = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Ort"), 35)
                    KURZBEZEICHNUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Kurzbezeichnung"), 27)
                    PAN_NR = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("PAN"), 5)
                    BIC = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("BIC"), 11)
                    PRUEFZIFFER_KZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Prüfziffer-berechnungs-methode"), 2)
                    DATENSATZ_NR = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Datensatz-nummer"), 6)
                    AENDERUNG_KZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Änderungs-kennzeichen"), 1)
                    BLZ_LOESCHUNG = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Bankleitzahl-löschung"), 1)
                    NACHFOLGE_BLZ = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("Nachfolge-Bankleitzahl"), 8)


                    BLZ_ROW = BANKLEITZAHL & MERKMAL & BEZEICHNUNG & POSTLEITZAHL & ORT & KURZBEZEICHNUNG & PAN_NR & BIC & PRUEFZIFFER_KZ & DATENSATZ_NR & AENDERUNG_KZ & BLZ_LOESCHUNG & NACHFOLGE_BLZ

                    System.IO.File.AppendAllText("C:\BLZ_plus_BIC_from_PSTOOL.txt", BLZ_ROW & vbCrLf)
                Next

                SplashScreenManager.CloseForm(False)
                MessageBox.Show("The following BLZ Directory file has being created: C:\BLZ_plus_BIC_from_PSTOOL.txt", "NEW BLZ DIRECTORY FILE", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Catch ex As System.Exception
                SplashScreenManager.CloseForm(False)

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If
    End Sub
End Class