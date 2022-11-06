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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql


Public Class FinRecon

    Dim CrystalRepDir As String = ""
    Dim ActiveTabGroup As Double = 0
    Dim ActiveTabGroupQueries As Double = 0

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Private objDataTable As New DataTable

    Dim d As Date
    Dim dsql As String = Nothing

    Dim SqlCommandText As String = Nothing

    Dim ds As New SqlDataSource
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

   

    Private Sub FinRecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn


        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),A.[RLDC Date],104) as 'RiskDate' from (Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date]>='20170526' UNION ALL Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date] in ('20161231','20170331'))A ORDER BY A.[RLDC Date] desc"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        For Each row As DataRow In dt1.Rows
            If dt1.Rows.Count > 0 Then
                Me.FromDateEdit.Properties.Items.Add(row("RiskDate"))
            End If
        Next
        If dt1.Rows.Count > 0 Then
            Me.FromDateEdit.Text = dt1.Rows.Item(0).Item("RiskDate")
        End If

        d = Me.FromDateEdit.Text
        dsql = d.ToString("yyyyMMdd")
        
        FILL_FINRECON_DATATABLE()

        'Fill FINRECON Details
        'Dim da As SqlDataAdapter
        'Dim objCMD As SqlCommand = New SqlCommand("Select * from [FINRECON_NG] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
        'objCMD.CommandTimeout = 5000
        'da = New SqlDataAdapter(objCMD)
        'dt = New DataTable()
        'da.Fill(dt)
        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '    Me.GridControl2.DataSource = Nothing
        '    Me.GridControl2.DataSource = dt
        '    Me.GridControl2.ForceInitialize()
        'End If

        GridControl2.MainView = FinRecon_BaseView
        FinRecon_BaseView.ForceDoubleClick = True
        AddHandler FinRecon_BaseView.DoubleClick, AddressOf FinRecon_BaseView_DoubleClick
        AddHandler FinRecon_LayoutView.MouseDown, AddressOf FinRecon_LayoutView_MouseDown
        AddHandler BICViews_btn.Click, AddressOf BICViews_btn_Click
        FinRecon_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        FinRecon_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

    Private Sub FILL_FINRECON_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM [FINRECON_NG] where [RiskDate]=' " & dsql & "' order by [ID] asc"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl2.DataSource = Nothing
        Me.GridControl2.DataSource = ds
        Me.GridControl2.DataMember = "customQuery1"
        Me.GridControl2.ForceInitialize()
    End Sub


#Region "FINRECON_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = FinRecon_LayoutView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = FinRecon_BaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BICViews_btn.Text = strShowExtendedMode
        BICViews_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is FinRecon_LayoutView)
        Me.GridControl2.ToolTipController = ToolTipController1
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Me.GridControl2.ToolTipController = Nothing
        Dim datasourceRowIndex As Integer = FinRecon_BaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = FinRecon_LayoutView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        BICViews_btn.Text = strHideExtendedMode
        BICViews_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is FinRecon_LayoutView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FinRecon_BaseView.GetRowHandle(dataSourceRowIndex)
        FinRecon_BaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FinRecon_LayoutView.GetRowHandle(dataSourceRowIndex)
        FinRecon_LayoutView.VisibleRecordIndex = FinRecon_LayoutView.GetVisibleIndex(rowHandle)
        FinRecon_LayoutView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub FinRecon_BaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hi As GridHitInfo = FinRecon_BaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub FinRecon_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = FinRecon_LayoutView.CalcHitInfo(e.Location)
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

    Private Sub LoadDailyBalanceSheets_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing

            Me.GridControl4.DataSource = Nothing

            If IsDate(Me.FromDateEdit.Text) = True Then
                d = Me.FromDateEdit.Text
                dsql = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Financial Reconciliation Details for " & d)
                'Load Balance Sheet
                FILL_FINRECON_DATATABLE()

                ''Fill Balance Sheet 2 details
                'Dim da As SqlDataAdapter
                'Dim objCMD As SqlCommand = New SqlCommand("Select * from [FINRECON_NG] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
                'objCMD.CommandTimeout = 5000
                'da = New SqlDataAdapter(objCMD)
                'dt = New DataTable()
                'da.Fill(dt)
                'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                '    Me.GridControl2.DataSource = Nothing
                '    Me.GridControl2.DataSource = dt
                '    Me.GridControl2.ForceInitialize()

                'End If

                FINRECON_BS_COMPARE()

                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FromDateEdit.KeyDown
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
        End If
    End Sub

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            If BICViews_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else
                Me.FinRecon_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.FinRecon_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.FinRecon_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.FinRecon_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.FinRecon_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.FinRecon_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                'Me.BICLayoutView.ShowPrintPreview()
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                Me.FinRecon_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.FinRecon_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
            End If

        End If
        If ActiveTabGroup = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            If Not GridControl3.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Financial Reconciliation" & "   " & "Date: " & Me.FromDateEdit.Text
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
        Dim reportfooter As String = "Financial Recon. - Balance Sheet Compare" & "  " & "Date: " & Me.FromDateEdit.Text
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
        Dim reportfooter As String = "Balance Sheet 1 + 2 Details - Compared" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Financial Reconciliation" Then
            ActiveTabGroup = 0
            Me.LayoutControlItem10.Visibility = LayoutVisibility.Always
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Financ.Reconc. - Balance Sheet compared" Then
            ActiveTabGroup = 2
            Me.LayoutControlItem10.Visibility = LayoutVisibility.Never
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Balance Sheet 1-2 Compared" Then
            ActiveTabGroup = 1
            Me.LayoutControlItem10.Visibility = LayoutVisibility.Never
        End If

    End Sub

    Private Sub TabbedControlGroup2_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup2.SelectedPageChanged
        If Me.TabbedControlGroup2.SelectedTabPage.Text = "Search for Accounts not included in the Balance Sheet" Then
            ActiveTabGroupQueries = 0

        End If
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalHeaderArea
        Dim reportfooter As String = "Accounts not included in the Balance Sheet" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BalanceSheetDetails_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FinRecon_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BalanceSheetDetails_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles FinRecon_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs) Handles GridView3.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Nothing
        Me.GridControl2.DataSource = Nothing

        Me.GridControl4.DataSource = Nothing

        If IsDate(Me.FromDateEdit.Text) = True Then
            d = Me.FromDateEdit.Text
            dsql = d.ToString("yyyyMMdd")
           
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Financial Reconciliation for " & d)
            'Load Balance Sheet
            FILL_FINRECON_DATATABLE()

            ''Fill Balance Sheet 2 details
            'Dim da As SqlDataAdapter
            'Dim objCMD As SqlCommand = New SqlCommand("Select * from [FINRECON_NG] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
            'objCMD.CommandTimeout = 5000
            'da = New SqlDataAdapter(objCMD)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            '    Me.GridControl2.DataSource = Nothing
            '    Me.GridControl2.DataSource = dt
            '    Me.GridControl2.ForceInitialize()

            'End If

            FINRECON_BS_COMPARE()

                SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub TrialBalanceBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TrialBalanceBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TrialBalanceBaseView_ShownEditor(sender As Object, e As EventArgs) Handles TrialBalanceBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub NoAccountsDBSExecutedQuery_btn_Click(sender As Object, e As EventArgs) Handles NoAccountsDBSExecutedQuery_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
           d = Me.FromDateEdit.Text
            dsql = d.ToString("yyyyMMdd")
            Try

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Accounts not in Daily Balance Sheet" & vbNewLine & "(SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/ACCOUNTS_NOT_IN_DBS) for: " & d)

                Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('ACCOUNTS_NOT_IN_DBS') and Status in ('Y')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", dsql)


                    'Data reader
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandText = SqlCommandText
                            sqlCmd.Connection = sqlConn
                            sqlCmd.CommandTimeout = 5000
                            If sqlConn.State = ConnectionState.Closed Then
                                sqlConn.Open()
                            End If

                            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                            objDataTable.Clear()
                            objDataTable.Load(objDataReader)

                            If sqlConn.State = ConnectionState.Open Then
                                sqlConn.Close()
                            End If

                        End Using
                    End Using

                    'Results Datareader
                    If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                        'Me.GridControl4.BeginUpdate()
                        Me.GridControl4.DataSource = Nothing
                        'Me.GridControl1.Refresh()
                        Me.GridControl4.DataSource = objDataTable
                        Me.GridControl4.ForceInitialize()
                        'Me.LCR_Details_GridView.PopulateColumns()
                        'Me.LCR_Details_GridView.BestFitColumns()
                        'Me.GridControl4.RefreshDataSource()
                        SplashScreenManager.CloseForm(False)
                    Else
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("The SQL Command:SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/ACCOUNTS_NOT_IN_DBS is either deactivated or not present!", "NO SQL COMMAND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If


            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

        End If

    End Sub

   
    Private Sub PrintExportQueries_btn_Click(sender As Object, e As EventArgs) Handles PrintExportQueries_btn.Click
        If ActiveTabGroupQueries = 0 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink6.CreateDocument()
            PrintableComponentLink6.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FINRECON_BS_COMPARE()
        'Compare FINRECON-BS
        If IsDate(Me.FromDateEdit.Text) = True Then
            d = Me.FromDateEdit.Text
            dsql = d.ToString("yyyyMMdd")
            Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('FINRECON_BALANCE_COMPARE') and Status in ('Y')"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", dsql)
                'Data reader
                Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using sqlCmd As New SqlCommand()
                        sqlCmd.CommandText = SqlCommandText
                        sqlCmd.Connection = sqlConn
                        sqlCmd.CommandTimeout = 5000
                        If sqlConn.State = ConnectionState.Closed Then
                            sqlConn.Open()
                        End If

                        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        objDataTable.Clear()
                        objDataTable.Load(objDataReader)

                        If sqlConn.State = ConnectionState.Open Then
                            sqlConn.Close()
                        End If

                    End Using
                End Using
                'Results Datareader
                If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                    Me.GridControl3.DataSource = Nothing
                    Me.GridControl3.DataSource = objDataTable
                    Me.GridControl3.ForceInitialize()
                End If
            End If
        End If

    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl.Name = GridControl2.Name AndAlso Me.GridControl2.MainView Is FinRecon_BaseView Then
            Dim view As GridView = FinRecon_BaseView
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(8)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"

                Select Case ColumnFieldName
                    Case Is = "Entity"
                        args.Contents.Text = "The branch name of the subject record" & vbNewLine & "(e.g. CCB Frankfurt)"
                    Case Is = "Source_System"
                        args.Contents.Text = "The system that booked the contracts or account (e.g. NEWG/ Opics)  "
                    Case Is = "Contract_Nr"
                        args.Contents.Text = "Contract Nr."
                    Case Is = "Contract_Nr_Clear"
                        args.Contents.Text = "Contract Nr. without Alphabetical Letter"
                    Case Is = "Class"
                        args.Contents.Text = "This is the class of contracts and accounts.  The possible values are Assets, Liabilities," & vbNewLine & "Off-balance Long Positions, Off-balance Short Positions and Others. Contracts and accounts" & vbNewLine & "are classified into the following classes:" & vbNewLine & _
                        "                    Assets: - Money market loans - Commercial loans - Debt securities purchased - Nostro Account (Credit Balance) - Vostro Account (Overdraft) - DDA (Client Account Overdraft) - IRS-Loan Side interest - CCS-Loan Side Interest - Overdue loans - Classified loans and debt securities " & vbNewLine & _
                        "Off-balance Long Positions: - Undrawn Commitment - FX bank buy amount (exclude NDF) - FX Swap bank buy near leg - FX Swap bank buy far leg - CCS-Loan Side Principal - Unstarted money market deposits (start event) - Unstarted time deposits (start event) - Unstarted money market loans (future events other than start event) - Unstarted commercial loans (future events other than start event)" & vbNewLine & _
                        "               Liabilities: - Money market deposits - Time deposits - CD issued - IRS-Deposit Side interest - CCS-Deposit Side Interest - Nostro Account (Debt Balance) - Vostro Account (Credit Balance) - DDA (Client Account Credit Balance) - REPO" & vbNewLine & _
                        "Off-balance Long Positions: - FX bank sell amount (exclude NDF) - FX Swap bank sell near leg - FX Swap bank sell far leg - CCS-Deposit Side Principal - Unstarted money market loans (Start Event) - Unstarted commercial loans (Start event) - Unstarted money market deposits (future events other than start event) - Unstarted time deposit (future events other than start event)" & vbNewLine & _
                        "                    Others: - Contracts or accounts not covered above"
                    Case Is = "Serial_Nr"
                        args.Contents.Text = "Applicable to FX Swap and MMDP only" & vbNewLine & "FX Swap : Far Leg = 2 , Near Leg =  1" & vbNewLine & "MMDP : Serial number for rollover contracts "
                    Case Is = "GL_Number"
                        args.Contents.Text = "The GL account that have been used for the posting of the transaction amount. For " & vbNewLine & _
                            "example, there will be separate GL posting records to display the principal and " & vbNewLine & _
                            "accrued interest amount of a loan contract, differentiated by the amount ID column."
                    Case Is = "NG_GL_Nr"
                        args.Contents.Text = "The New Generation GL Account Nr."
                    Case Is = "GL_Acc_Name"
                        args.Contents.Text = "Name of the GL account "
                    Case Is = "GL_Groups"
                        args.Contents.Text = "Show the below category according to the first digit of the GL number" & vbNewLine & _
                            "GL number with prefix of 1 : show Asset" & vbNewLine & _
                            "GL number with prefix of 2 : show Liabilities & capital" & vbNewLine & _
                            "GL number with prefix of 3 or 4 : show Off-balance" & vbNewLine & _
                            "GL number with prefix of 5 or 6 or 7 or 8 : show P&L"
                    Case Is = "Group_Client_Nr"
                        args.Contents.Text = "The credit group leader’s client number (if exist) of the subject client"
                    Case Is = "Group_Client_Name"
                        args.Contents.Text = "Client name of the credit group leader (if exist)"
                    Case Is = "Consolidated_Group_Client_Nr"
                        args.Contents.Text = "The consolidated credit group leader’s client number (if exist) of the subject client"
                    Case Is = "Consolidated_Group_Client_Name"
                        args.Contents.Text = "Client name of the consolidated credit group leader (if exist)"
                    Case Is = "Client_Nr"
                        args.Contents.Text = "Client number of the counterparty/ issuer"
                    Case Is = "Client_Name"
                        args.Contents.Text = "Client name of the counterparty/ issuer"
                    Case Is = "ContractType"
                        args.Contents.Text = "Contract type mentioned in the reporting criteria section (e.g. CLDD)"
                    Case Is = "ProductType"
                        args.Contents.Text = "Sub product type under the contract type (e.g. SYFTDD) "
                    Case Is = "ContractType_Definition"
                        args.Contents.Text = "Show the contract type definition according to the contract type"
                    Case Is = "Master_Nr"
                        args.Contents.Text = "GL Master number (e.g. 131)"
                    Case Is = "Accounting_Centre"
                        args.Contents.Text = "The accounting centre of the contract/ account"
                    Case Is = "InputDate"
                        args.Contents.Text = ""
                    Case Is = "OriginalStartDate"
                        args.Contents.Text = ""
                    Case Is = "StartDate"
                        args.Contents.Text = ""
                    Case Is = "MaturityDate"
                        args.Contents.Text = ""
                    Case Is = "FinalMaturityDate"
                        args.Contents.Text = ""
                    Case Is = "LastCouponDate"
                        args.Contents.Text = ""
                    Case Is = "NextCouponDate"
                        args.Contents.Text = ""
                    Case Is = "InterestRate"
                        args.Contents.Text = ""
                    Case Is = "Amount_ID"
                        args.Contents.Text = ""
                    Case Is = "Amount_ID_Description"
                        args.Contents.Text = ""
                    Case Is = "CCY"
                        args.Contents.Text = "Transaction currency"
                    Case Is = "Amount"
                        args.Contents.Text = "Transaction amount For example, there will be separate GL posting records to display the principal and accrued interest amount of a loan contract, differentiated by the amount ID column"
                    Case Is = "Amount_Equ"
                        args.Contents.Text = "Amount in base currency equivalent"
                    Case Is = "Accrued_Interest"
                        args.Contents.Text = "Applicable to loan / deposit/ CAAC/ debt securities/ IRS only" & vbNewLine & _
                            "Accrued interest of the subject contract/ account. It expects to show under the " & vbNewLine & _
                            "principal (PA) record of the subject contract "
                    Case Is = "Accrued_Interest_EUR"
                        args.Contents.Text = "Applicable to loan / deposit/ CAAC/ debt securities/ IRS only" & vbNewLine & _
                           "Accrued interest (Base currency equivalent) of the subject contract/account. It expects " & vbNewLine & _
                           "to show under the principal (PA) record of the subject contract"
                    Case Is = "Dr_Cr_Indicator"
                        args.Contents.Text = "Debit/ credit indicator of the GL posting "
                    Case Is = "IS_code"
                        args.Contents.Text = "Institutional sector code of the client/ issuer in CI module"
                    Case Is = "Connected_Status"
                        args.Contents.Text = "Show the connected party information of the client." & vbNewLine & _
                           "Show N if there is no connected party information. " & vbNewLine & _
                           "Show the description of the connected party type in case connected party information " & vbNewLine & _
                           "is available. Show the most recent un-expired record (with effective date closest to " & vbNewLine & _
                           "reporting date) in case there are more than one connected party records. " & vbNewLine & _
                           "CONNECTED PARTY TYPES:" & vbNewLine & _
                           "- HEAD OFFICE" & vbNewLine & _
                           "- INTERBRANCH" & vbNewLine & _
                           "- SUBSIDIARY" & vbNewLine & _
                           "- INTER GROUP" & vbNewLine & _
                           "- OTHERS" & vbNewLine & _
                           "- ASSOCIATES"
                    Case Is = "ResidenceCountry"
                        args.Contents.Text = "Country of residence of the client/ issuer in CI module "
                    Case Is = "OriginalCountry"
                        args.Contents.Text = "Country of origin of the client/ issuer in CI module "
                    Case Is = "RiskCountry"
                        args.Contents.Text = "Country of risk of the client/ issuer in CI module "
                    Case Is = "CountryRating_RiskCountry"
                        args.Contents.Text = "Country credit rating of the country of risk of the counterparty/ issuer" & vbNewLine & _
                          "User is required to input country credit rating in NEWG. System will show the S&P " & vbNewLine & _
                          "long term credit rating, in case both long and short term rating also exist.  "
                    Case Is = "RegistrationCountry"
                        args.Contents.Text = "Country of registration of the client/ issuer in CI module "
                    Case Is = "CityCode"
                        args.Contents.Text = ""
                    Case Is = "ClientType"
                        args.Contents.Text = "C = Company, P = Personal,  F = Financial institution"
                    Case Is = "InternalClientType"
                        args.Contents.Text = "Internal client type of the client/ issuer in CI module "
                    Case Is = "FI_Client_Type"
                        args.Contents.Text = "FI client type of the client/ issuer in CI module"
                    Case Is = "ID_Nr_Type2"
                        args.Contents.Text = "ID number Type 2 of the client. This field reflects the type of ID number 2.  "
                    Case Is = "ID_Nr_2"
                        args.Contents.Text = "LEI Number of the client "
                    Case Is = "Industrial_Classification_Local"
                        args.Contents.Text = "Industrial Classification local of the client/ issuer in CI module (Code: CIHIN). FRS Econ Sector Code (LKPN_ECON_SECTOR) "
                    Case Is = "Industrial_Classification_Others"
                        args.Contents.Text = "Industrial Classification others of the client/ issuer in CI module (Code : CIOIN). FRS NACE code (TYP_NACE2) "
                    Case Is = "Purpose_of_loan"
                        args.Contents.Text = "Applicable to NEWG loan contract/ commitment only"
                    Case Is = "Industrial_Classification_HO"
                        args.Contents.Text = "Industrial Classification China of the client/ issuer in CI module "
                    Case Is = "Client_Credit_Rating_Agency_1"
                        args.Contents.Text = "Credit agency "
                    Case Is = "Client_Credit_Rating1"
                        args.Contents.Text = "Credit rating of the rating agency (1) "
                    Case Is = "Client_Credit_Rating_Agency2"
                        args.Contents.Text = "Credit agency "
                    Case Is = "Client_Credit_Rating2"
                        args.Contents.Text = "Credit rating of the rating agency (2) "
                    Case Is = "Loan_Credit_Rating_Long"
                        args.Contents.Text = "Loan credit rating (long term)"
                    Case Is = "Loan_Credit_Rating_Short"
                        args.Contents.Text = "Loan credit rating (short term)"
                    Case Is = "Pay_Receive_Indicator"
                        args.Contents.Text = "Applicable to IRS deals & fee contract only. IRS/ CCS deal (Contract type = SWAP/ SWPS) : Pay / Receive leg. Fee: Receivable/ Payable"
                    Case Is = "Payment_Method"
                        args.Contents.Text = "Applicable to Fee contract only. Prepay / Accrual of the fee contract"
                    Case Is = "Far_Near_Indicator"
                        args.Contents.Text = "Applicable to FX Swap deal only. Near / Far leg indicator of the FX Swap contract"
                    Case Is = "Purchase_Sale"
                        args.Contents.Text = "Applicable to debt securities deal only. Buy / Sale indicator of FX , Securities contract"
                    Case Is = "Investment_Type"
                        args.Contents.Text = "Applicable to debt securities deal only. Investment Type of the debt securities deal (A: Available for sale, H: Hold to maturity, I: investment)"
                    Case Is = "Interest_Plan"
                        args.Contents.Text = "0 = Fixed 1= Floating "
                    Case Is = "FacilityType"
                        args.Contents.Text = "Applicable to loan facility only Revolving/ Non-revolving"
                    Case Is = "DrawStartDate"
                        args.Contents.Text = "Applicable to loan commitment only. Drawdown start date of the loan commitment"
                    Case Is = "DrawEndDate"
                        args.Contents.Text = "Applicable to loan commitment only. Drawdown end date of the loan commitment"
                    Case Is = "Tenor"
                        args.Contents.Text = "Tenor of the deal. Show S for FX spot contract (FXD) and show F for FX forward contract (FXD)"
                    Case Is = "IS_Code_Description"
                        args.Contents.Text = "The description of IS code, e.g. 101 = CCB Head office, 102 = CCB Inter-branch, etc"
                    Case Is = "Limit_Nr"
                        args.Contents.Text = "Applicable to credit limit record only. The 4 digit NEWG credit limit number that links with the contract/ account"
                    Case Is = "Limit_Code"
                        args.Contents.Text = "Applicable to credit limit record only.The limit code of the credit limit record, it represents the product type of the subject credit limit record (e.g. BLFTL, TRADEFIN, TRPM, etc) "
                    Case Is = "Limit_Type"
                        args.Contents.Text = "Applicable to credit limit record only. Revolving/ Non-revolving"
                    Case Is = "Swap_Market_Value"
                        args.Contents.Text = "Relevant to IRS/ CCS only" & vbNewLine & _
                            "The mark-to-market (i.e. Revaluation result) of the IRS/ CCS deals in original " & vbNewLine & _
                            "currency. It shows two records for receive side and pay side. "
                    Case Is = "FI_Market_Value"
                        args.Contents.Text = "The mark-to-market (i.e. Revaluation result) of the debt securities deals in original currency."
                    Case Is = "FI_Market_Value_EUR"
                        args.Contents.Text = "The mark-to-market (i.e. Revaluation result) of the debt securities deals in base currency equivalent."
                    Case Is = "Interest_Rate_Type"
                        args.Contents.Text = "1 – Fixed , 2 Floating, 3 – Float by period"
                    Case Is = "RateCode"
                        args.Contents.Text = "Rate code of the deal (e.g. FIXED, LIBOR, etc) "
                    Case Is = "Spread_Rate"
                        args.Contents.Text = ""
                    Case Is = "Exchange_Rate"
                        args.Contents.Text = ""
                    Case Is = "Original_Maturity"
                        args.Contents.Text = "Contract maturity date minus contract start date.The result is the days difference"
                    Case Is = "Remaining_Maturity"
                        args.Contents.Text = "Contract maturity date minus reporting date.The result is the days difference"
                    Case Is = "RemainingMonthsToMaturity"
                        args.Contents.Text = "Remaining_Maturity/30. If result is <1 then 1 else result"
                    Case Is = "RemainingYearsToMaturity"
                        args.Contents.Text = "RemainingMonthsToMaturity/12. If result is <1 then 1 else result"
                    Case Is = "Collective_Impairment_Amount"
                        args.Contents.Text = "Applicable to CLDD/ CLDL contract only.Collective Impairment Amount (Col_Impair_Amt) "
                    Case Is = "Individual_Impairment_Amount"
                        args.Contents.Text = "Applicable to CLDD/ CLDL contract only. Individual Impairment Amount (Ind_Impair_Amt) "
                    Case Is = "Total_Interest_Amount_OrgCCY"
                        args.Contents.Text = "Total Interest amount of the contract (Org currency)" & vbNewLine & _
                            "Calculation logic as below, same result as ODASH TS_D_1048 report " & vbNewLine & _
                            "Principal	   Int Rate	  Start date	End date 	Days	 Total Interest " & vbNewLine & _
                            "39.000.000,00	10%	      25/8/2015	   11/9/2015	17	       184.166,67 "
                    Case Is = "Total_Interest_AmountEUR"
                        args.Contents.Text = "Total Interest amount of the contract (Eur equivalent)"
                    Case Else
                        args.Contents.Text = "No Info"
                End Select
                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip
            End If
        End If


        'LAYOUT VIEW
        If e.SelectedControl.Name = GridControl2.Name AndAlso Me.GridControl2.MainView Is FinRecon_LayoutView Then

            Dim view As DevExpress.XtraGrid.Views.Layout.LayoutView = TryCast(GridControl2.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Layout.LayoutView)
            Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing

            Dim hi As LayoutViewHitInfo = view.CalcHitInfo(e.ControlMousePosition)

            If hi.InFieldValue Then
                Dim o As Object = hi.HitTest.ToString() + hi.HitField.ToString()
                Dim text As String = String.Format("EditValue is {0}", view.GetRowCellValue(hi.RowHandle, hi.Column))
                info = New DevExpress.Utils.ToolTipControlInfo(o, text)

            End If
            e.Info = info


        End If
    End Sub

End Class