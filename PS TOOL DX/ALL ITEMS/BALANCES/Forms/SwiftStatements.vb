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
Public Class SwiftStatements

    Dim d1 As Date
    Dim d2 As Date
    Dim sqld1 As String = Nothing
    Dim sqld2 As String = Nothing
    Dim rdsql1 As String
    Dim rdsql2 As String

    Dim AccCCY As String = Nothing
    Dim AccName As String = Nothing
    Dim AccStatus As String = Nothing
    Dim AccOpenDate As String = Nothing
    Dim AccClosedDate As String = Nothing

    Friend WithEvents BgwLoadPostings As BackgroundWorker
    Friend WithEvents BgwLoadBalances As BackgroundWorker
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

    Private Sub SWIFT_ACC_STATEMENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SWIFT_ACC_STATEMENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.OCBS_BookingDate_From.Enabled = False
        Me.OCBS_BookingDate_Till.Enabled = False
        Me.OCBS_LookUpEdit.Enabled = False
        Me.LoadOCBS_btn.Enabled = False
        Me.LoadAllLastBalances_btn.Enabled = False
        Me.Print_Export_Gridview_btn.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.OCBS_BookingDate_From.Enabled = True
        Me.OCBS_BookingDate_Till.Enabled = True
        Me.OCBS_LookUpEdit.Enabled = True
        Me.LoadOCBS_btn.Enabled = True
        Me.LoadAllLastBalances_btn.Enabled = True
        Me.Print_Export_Gridview_btn.Enabled = True
    End Sub

    Private Sub SwiftStatements_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SSISTableAdapter.FillBySwiftStatements(Me.PSTOOLDataset.SSIS)
        Me.CURlbl.Text = ""

        Me.Nostro_Balances_BasicView.ActiveFilterString = "[SwiftTagName] NOT LIKE 'Intermed%'"

        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl1.MainView = Me.Nostro_Balances_BasicView
        Nostro_Balances_BasicView.ForceDoubleClick = True
        AddHandler Nostro_Balances_BasicView.DoubleClick, AddressOf Nostro_Balances_BasicView_DoubleClick
        AddHandler Nostro_Balances_DetailView.MouseDown, AddressOf Nostro_Balances_DetailView_MouseDown
        AddHandler Edit_BICDIR_Details_btn.Click, AddressOf Edit_BICDIR_Details_btn_Click
        Nostro_Balances_DetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        Nostro_Balances_DetailView.OptionsBehavior.AllowSwitchViewModes = False

        'Get Forelast Date and fill DateEdits
        Dim d1 As Date = DateAdd(DateInterval.Day, -1, Today)
        Dim d2 As Date = Today
        OCBS_BookingDate_From.EditValue = d1
        OCBS_BookingDate_Till.EditValue = d2

    End Sub

    Private Sub OCBS_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OCBS_LookUpEdit.EditValueChanged
        If Me.OCBS_LookUpEdit.Text <> "" Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim NOSTRO_NAME_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Dim ACC_CURRENCY_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.CURlbl.Text = ACC_CURRENCY_Row("CURRENCY CODE").ToString
            Me.NostroAccountNamelbl.Text = NOSTRO_NAME_Row("NOSTRO_NAME").ToString.Trim
        Else
            Me.CURlbl.Text = Nothing
            Me.NostroAccountNamelbl.Text = Nothing
        End If
    End Sub

#Region "NOSTRO_STATEMENTS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl1.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = Nostro_Balances_DetailView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = Nostro_Balances_BasicView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Edit_BICDIR_Details_btn.Text = strShowExtendedMode
        Edit_BICDIR_Details_btn.ImageIndex = 10
        fExtendedEditMode = (GridControl1.MainView Is Nostro_Balances_DetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = Nostro_Balances_BasicView.GetDataSourceRowIndex(rowHandle)
        GridControl1.MainView = Nostro_Balances_DetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Edit_BICDIR_Details_btn.Text = strHideExtendedMode
        Edit_BICDIR_Details_btn.ImageIndex = 11
        fExtendedEditMode = (GridControl1.MainView Is Nostro_Balances_DetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = Nostro_Balances_BasicView.GetRowHandle(dataSourceRowIndex)
        Nostro_Balances_BasicView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = Nostro_Balances_DetailView.GetRowHandle(dataSourceRowIndex)
        Nostro_Balances_DetailView.VisibleRecordIndex = Nostro_Balances_DetailView.GetVisibleIndex(rowHandle)
        Nostro_Balances_DetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub Nostro_Balances_BasicView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = Nostro_Balances_BasicView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub Nostro_Balances_DetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = Nostro_Balances_DetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub Edit_BICDIR_Details_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region


    Private Sub LoadOCBS_btn_Click(sender As Object, e As EventArgs) Handles LoadOCBS_btn.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then
            If IsNothing(Me.OCBS_LookUpEdit.Text) = False AndAlso IsNumeric(Me.OCBS_LookUpEdit.Text) = True Then
                d1 = Me.OCBS_BookingDate_From.Text
                d2 = Me.OCBS_BookingDate_Till.Text
                If d2 >= d1 Then
                    rdsql1 = d1.ToString("yyyyMMdd")
                    rdsql2 = d2.ToString("yyyyMMdd")
                    If IsNothing(Me.OCBS_LookUpEdit.Text) = False AndAlso IsNumeric(Me.OCBS_LookUpEdit.Text) = True Then
                        Me.SearchText_lbl.Text = "External postings and Balances for Nostro Account: " & Me.OCBS_LookUpEdit.Text & " -Currency: " & Me.CURlbl.Text & " - Name: " & Me.NostroAccountNamelbl.Text & " from " & d1 & " till " & d2
                    End If
                    DISABLE_BUTTONS()
                    Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                    'Me.ProgressPanel1.Visible = True
                    BgwLoadPostings = New BackgroundWorker
                    bgws.Add(BgwLoadPostings)
                    BgwLoadPostings.WorkerReportsProgress = True
                    BgwLoadPostings.RunWorkerAsync()
                Else
                    XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Else
                XtraMessageBox.Show("Please enter Nostro Account Nr.", "Missing Nostro Account", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
                XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub BgwLoadPostings_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadPostings.DoWork
        Try

            Me.BgwLoadPostings.ReportProgress(10, "Load External postings and Balances for Nostro Account: " & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2)

            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = "SELECT * FROM [SWIFT_ACC_STATEMENTS] 
                                        WHERE [InternalAccount]= '" & Me.OCBS_LookUpEdit.Text & "' 
                                        AND [ReceivedDate] BETWEEN '" & rdsql1 & "' AND '" & rdsql2 & "'
                                        ORDER BY  PageNr asc,
                                        Case SwiftTag when '60F' then 1 
                                        when '60M' then 2 
                                        when '61' then 3 
                                        when '62M' then 4 
                                        when '62F' then 5 
                                        when '64' then 6 
                                        when '65' then 7 end, 
                                        StatementNr asc"
                    Sqlcmd.Connection = Sqlconn
                    Sqlconn.Open()
                    daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)
                    Sqlconn.Close()

                End Using
            End Using


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadPostings.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoadPostings_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadPostings.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadPostings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadPostings.RunWorkerCompleted
        Workers_Complete(BgwLoadPostings, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        'Me.ProgressPanel1.Visible = False
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Nostro_Name").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("TransactionTypeID").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceAccountOwner").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceServiInstitution").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("SupplementaryDetails").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled_IB").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("TransactionTypeID").VisibleIndex = 13
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceAccountOwner").VisibleIndex = 14
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceServiInstitution").VisibleIndex = 15
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("SupplementaryDetails").VisibleIndex = 16
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled").VisibleIndex = 17
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled_IB").VisibleIndex = 18
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub LoadAllLastBalances_btn_Click(sender As Object, e As EventArgs) Handles LoadAllLastBalances_btn.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then

            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                If IsNothing(Me.OCBS_LookUpEdit.Text) = False AndAlso IsNumeric(Me.OCBS_LookUpEdit.Text) = True Then
                    Me.SearchText_lbl.Text = "Closing Internal Balances for all Nostro Accounts" & " from " & d1 & " till " & d2
                End If
                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                'Me.ProgressPanel1.Visible = True
                BgwLoadBalances = New BackgroundWorker
                bgws.Add(BgwLoadBalances)
                BgwLoadBalances.WorkerReportsProgress = True
                BgwLoadBalances.RunWorkerAsync()

            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

    End Sub

    Private Sub BgwLoadBalances_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadBalances.DoWork
        Try
            Me.BgwLoadBalances.ReportProgress(10, "Closing External Balances for Nostro Account: " & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2)

            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = "Select * from [SWIFT_ACC_STATEMENTS] 
                                          where ID in (select max(ID) from [SWIFT_ACC_STATEMENTS]  
                                          where  [SwiftTag] in ('62F','64') group by [InternalAccount]) 
                                          Order by [InternalAccount],
                                          Case[SwiftTag] when '62F' then 1 
                                          when '64' then 2 end"
                    Sqlcmd.Connection = Sqlconn
                    Sqlconn.Open()
                    daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)
                    Sqlconn.Close()

                End Using
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadBalances.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoadBalances_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadBalances.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadBalances_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadBalances.RunWorkerCompleted
        Workers_Complete(BgwLoadBalances, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        'Me.ProgressPanel1.Visible = False
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Nostro_Name").Visible = True
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("TransactionTypeID").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceAccountOwner").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("ReferenceServiInstitution").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("SupplementaryDetails").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Reconciled_IB").Visible = False
            Me.Nostro_Balances_BasicView.Columns.ColumnByFieldName("Nostro_Name").VisibleIndex = 3
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If Edit_BICDIR_Details_btn.Text = "Display Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.Nostro_Balances_DetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.Nostro_Balances_DetailView.OptionsPrint.PrintCardCaption = True
            Me.Nostro_Balances_DetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.Nostro_Balances_DetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.BICLayoutView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.Nostro_Balances_DetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True

        End If

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
        Dim reportfooter As String = Me.SearchText_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        'Try
        'iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
        'r = New RectangleF(New PointF(0, 0), iSize)
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        'pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)
        'Catch ex As Exception
        'End Try

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

    Private Sub SwiftStatements_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class