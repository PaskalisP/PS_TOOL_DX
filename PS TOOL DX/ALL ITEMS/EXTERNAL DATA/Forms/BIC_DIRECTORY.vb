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
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Public Class BIC_DIRECTORY
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
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

    Private Sub BIC_DIRECTORYBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BIC_DIRECTORYBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EXTERNALDataset)

    End Sub

    Private Sub FILL_BIC_DIRECTORY_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM [BIC DIRECTORY] order by [BIC11] asc"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl2.DataSource = Nothing
        Me.GridControl2.DataSource = ds
        Me.GridControl2.DataMember = "customQuery1"
        Me.GridControl2.MainView = BICGridView
        Me.GridControl2.ForceInitialize()
        Me.GridControl2.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BIC_DIRECTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        FILL_BIC_DIRECTORY_DATATABLE()
        'Me.GridControl2.DataSource = Nothing
        'Try
        '    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
        '        Using sqlCmd As New SqlCommand()
        '            sqlCmd.CommandText = "SELECT * FROM [BIC DIRECTORY] order by [BIC11] asc"
        '            sqlCmd.Connection = sqlConn
        '            sqlConn.Open()
        '            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
        '            Dim objDataTable As New DataTable()
        '            objDataTable.Load(objDataReader)
        '            Me.GridControl2.DataSource = Nothing
        '            Me.GridControl2.DataSource = objDataTable
        '            Me.GridControl2.ForceInitialize()
        '            sqlConn.Close()
        '        End Using
        '    End Using
        'Catch
        'End Try


        'TODO: This line of code loads data into the 'EXTERNALDataset.BIC_DIRECTORY' table. You can move, or remove it, as needed.
        'Me.BIC_DIRECTORYTableAdapter.FillByBICDIR_FILL(Me.EXTERNALDataset.BIC_DIRECTORY)


        'Gridcontrol2 - BIC DIRECTORY
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = BICGridView
        BICGridView.ForceDoubleClick = True
        AddHandler BICGridView.DoubleClick, AddressOf BICGridView_DoubleClick
        AddHandler BICLayoutView.MouseDown, AddressOf BICLayoutView_MouseDown
        AddHandler BICViews_btn.Click, AddressOf BICViews_btn_Click
        BICLayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        BICLayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'Get Last Update
        cmd.CommandText = "SELECT [LastImportTime] from [MANUAL IMPORTS] where [ProcName]='BIC DIRECTORY'"
        cmd.Connection.Open()
        Dim d As DateTime = cmd.ExecuteScalar
        Me.LastUpdate_txt.Text = d
        cmd.Connection.Close()

    End Sub
#Region "BIC_DIRECTORY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = BICLayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BICGridView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BICViews_btn.Text = strShowExtendedMode
        BICViews_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is BICLayoutView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = BICGridView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BICLayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BICViews_btn.Text = strHideExtendedMode
        BICViews_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is BICLayoutView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BICGridView.GetRowHandle(dataSourceRowIndex)
        BICGridView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = BICLayoutView.GetRowHandle(dataSourceRowIndex)
        BICLayoutView.VisibleRecordIndex = BICLayoutView.GetVisibleIndex(rowHandle)
        BICLayoutView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub BICGridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BICGridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub BICLayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = BICLayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub BICViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    '************DISABLE MOUSE SCROLL IN LAYOUTVIEW MODUS***************
    'Public Sub LayoutView1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LayoutView1.MouseWheel
    'Kein Mauswheel benuzung bei Details
    'TryCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    'End Sub
    '*********************************************************************

    '****** FilteRow Backcolor defined*************************************
    Private Sub BICGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BICGridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub
    '************ForeColor if Autofiltercell got focus**********************
    Private Sub BICGridView_ShownEditor(sender As Object, e As EventArgs) Handles BICGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BICPrint_Export_btn_Click(sender As Object, e As EventArgs) Handles BICPrint_Export_btn.Click

        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If BICViews_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.BICLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.BICLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.BICLayoutView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.BICLayoutView.OptionsPrint.PrintCardCaption = True
            Me.BICLayoutView.OptionsPrint.AllowCancelPrintExport = True
            Me.BICLayoutView.OptionsPrint.ShowPrintExportProgress = True
            'Me.BICLayoutView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.BICLayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.BICLayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True


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
        Dim reportfooter As String = "BIC DIRECTORY" & "  " & "Printed on: " & Now
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class