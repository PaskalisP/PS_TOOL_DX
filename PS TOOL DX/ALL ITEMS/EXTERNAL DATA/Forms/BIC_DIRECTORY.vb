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
Imports DevExpress.XtraEditors.Controls

Public Class BIC_DIRECTORY

    Dim query As New CustomSqlQuery()

    Dim SearchButtonClicked As Integer = 0
    Dim SearchText As String = Nothing
    Friend WithEvents BgwSearchDirectory As BackgroundWorker
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

    Private Sub DISABLE_BUTTONS()
        Me.DisplayListDetails_bbi.Enabled = False
        Me.SearchField_BarEditItem.Enabled = False

    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.DisplayListDetails_bbi.Enabled = True
        Me.SearchField_BarEditItem.Enabled = True
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


        'FILL_BIC_DIRECTORY_DATATABLE()

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
        'AddHandler BICViews_btn.Click, AddressOf BICViews_btn_Click
        BICLayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        BICLayoutView.OptionsBehavior.AllowSwitchViewModes = False



    End Sub
#Region "BIC_DIRECTORY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = BICLayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BICGridView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strShowExtendedMode
        DisplayListDetails_bbi.ImageIndex = 9
        fExtendedEditMode = (GridControl2.MainView Is BICLayoutView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = BICGridView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = BICLayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strHideExtendedMode
        DisplayListDetails_bbi.ImageIndex = 10
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

    End Sub
#End Region

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            If Me.BICGridView.RowCount > 0 Then
                ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            End If
        End If
    End Sub

    Private Sub Search_RepositoryItemButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Search_RepositoryItemButtonEdit.ButtonClick
        Dim edit As ButtonEdit = TryCast(sender, ButtonEdit)
        SearchButtonClicked = e.Button.Tag
        If e.Button.Tag = 5 Then
            edit.EditValue = Nothing
            'Me.SearchText_TextEdit.EditValue = ""
            'Me.SearchText_TextEdit.Text = ""
            'Me.SearchField_BarEditItem.EditValue = ""
            'Me.SearchField_BarEditItem.Links(0).Focus()
        End If
        If e.Button.Tag = 0 OrElse e.Button.Tag = 2 Then
            If edit.EditValue <> Nothing Then
                SearchText = edit.EditValue
                'SearchText = "%" & edit.EditValue & "%"
                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                BgwSearchDirectory = New BackgroundWorker
                bgws.Add(BgwSearchDirectory)
                BgwSearchDirectory.WorkerReportsProgress = True
                BgwSearchDirectory.RunWorkerAsync()
            End If
        End If
        If e.Button.Tag = 4 Then

            edit.EditValue = Nothing
            'SearchText = "%" & edit.EditValue & "%"
            DISABLE_BUTTONS()
            Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
            BgwSearchDirectory = New BackgroundWorker
            bgws.Add(BgwSearchDirectory)
            BgwSearchDirectory.WorkerReportsProgress = True
            BgwSearchDirectory.RunWorkerAsync()


        End If
    End Sub

    Private Sub BgwSearchDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSearchDirectory.DoWork
        Try
            Me.BgwSearchDirectory.ReportProgress(10, "Start searching...")
            Select Case SearchButtonClicked
                Case = 0
                    Me.BgwSearchDirectory.ReportProgress(10, "Start searching for BIC Code like: " & SearchText)
                    'Data reader
                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM [BIC DIRECTORY] where [BIC11] LIKE LTRIM(RTRIM('%" & SearchText & "%')) ORDER BY [BIC11] asc"
                            'Sqlcmd.Parameters.Add("@BANKNAME", SqlDbType.NVarChar)
                            'Sqlcmd.Parameters("@BANKNAME").Value = SearchText
                            Sqlcmd.Connection = Sqlconn
                            'Sqlcmd.CommandTimeout = 5000
                            Sqlconn.Open()

                            daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                            daSqlQueries.SelectCommand.CommandTimeout = 50000
                            dtSqlQueries = New DataTable()
                            daSqlQueries.Fill(dtSqlQueries)

                            'Dim objDataReader As SqlDataReader = Sqlcmd.ExecuteReader()
                            'objDataTable.Clear()
                            'objDataTable.Load(objDataReader)

                            Sqlconn.Close()

                        End Using
                    End Using

                Case = 2
                    Me.BgwSearchDirectory.ReportProgress(10, "Start searching for Institution Name like: " & SearchText)
                    'Data reader
                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM [BIC DIRECTORY] where [INSTITUTION NAME] LIKE LTRIM(RTRIM('%" & SearchText & "%')) ORDER BY [INSTITUTION NAME] asc"
                            'Sqlcmd.Parameters.AddWithValue("@CITY_HEADING", SearchText)
                            Sqlcmd.Connection = Sqlconn
                            'Sqlcmd.CommandTimeout = 5000
                            Sqlconn.Open()

                            daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                            daSqlQueries.SelectCommand.CommandTimeout = 50000
                            dtSqlQueries = New DataTable()
                            daSqlQueries.Fill(dtSqlQueries)

                            'Dim objDataReader As SqlDataReader = Sqlcmd.ExecuteReader()
                            'objDataTable.Clear()
                            'objDataTable.Load(objDataReader)

                            Sqlconn.Close()

                        End Using
                    End Using

                Case = 4
                    Me.BgwSearchDirectory.ReportProgress(10, "Start loading all BIC DIRECTORY data")
                    'Data reader
                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM [BIC DIRECTORY]  ORDER BY [BIC11] asc"
                            'Sqlcmd.Parameters.AddWithValue("@COUNTRY_NAME", SearchText)
                            Sqlcmd.Connection = Sqlconn
                            'Sqlcmd.CommandTimeout = 5000
                            Sqlconn.Open()

                            daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                            daSqlQueries.SelectCommand.CommandTimeout = 50000
                            dtSqlQueries = New DataTable()
                            daSqlQueries.Fill(dtSqlQueries)

                            'Dim objDataReader As SqlDataReader = Sqlcmd.ExecuteReader()
                            'objDataTable.Clear()
                            'objDataTable.Load(objDataReader)

                            Sqlconn.Close()

                        End Using
                    End Using

            End Select

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwSearchDirectory.CancelAsync()
        End Try
    End Sub

    Private Sub BgwSearchDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSearchDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwSearchDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSearchDirectory.RunWorkerCompleted
        Workers_Complete(BgwSearchDirectory, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never

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
        Else
            XtraMessageBox.Show("No Data fund for the specified search text", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
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

    '************DISABLE MOUSE SCROLL IN LAYOUTVIEW MODUS***************
    'Public Sub LayoutView1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LayoutView1.MouseWheel
    'Kein Mauswheel benuzung bei Details
    'TryCast(e, DevExpress.Utils.DXMouseEventArgs).Handled = True
    'End Sub
    '*********************************************************************

    '****** FilteRow Backcolor defined*************************************
    'Private Sub BICGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BICGridView.RowStyle
    '    If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        e.Appearance.BackColor = SystemColors.InactiveCaptionText
    '    End If
    'End Sub
    ''************ForeColor if Autofiltercell got focus**********************
    'Private Sub BICGridView_ShownEditor(sender As Object, e As EventArgs) Handles BICGridView.ShownEditor
    '    Dim view As GridView = CType(sender, GridView)
    '    If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
    '    End If
    'End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With {
            .PrintingSystemBase = New PrintingSystem(),
            .Component = component,
            .Landscape = True,
            .PaperKind = Printing.PaperKind.A4,
            .Margins = New Printing.Margins(20, 90, 20, 20)
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
        Dim reportfooter As String = "BIC DIRECTORY" & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()

    End Sub


End Class