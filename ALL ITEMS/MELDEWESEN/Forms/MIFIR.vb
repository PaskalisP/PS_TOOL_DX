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
Imports CrystalDecisions.CrystalReports.Engine
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Linq
Public Class MIFIR

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing

    Dim CrystalRepDir As String = ""

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem
    Dim EMAIL_TO As String = Nothing
    Dim EMAIL_CC As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Dim rd As Date
    Dim rdsql As String

    Dim LEI_CODE As String = Nothing
    Dim CSV_Environment As String = Nothing
    Dim CSV_CreationFolderDirectory As String = Nothing
    Dim CSV_InterfaceVersion As String = Nothing
    Dim CSV_RegulationFileType As String = Nothing

    Dim ActiveTabGroup As Double = 0



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



    Private Sub MIFIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EXTERNALDataset.COUNTRIES' table. You can move, or remove it, as needed.
        Me.COUNTRIESTableAdapter.Fill(Me.EXTERNALDataset.COUNTRIES)
        'TODO: This line of code loads data into the 'RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll' table. You can move, or remove it, as needed.

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        '***********OUR LEI CODE**************************
        cmd.CommandText = "select LEI_Code from BANK"
        LEI_CODE = cmd.ExecuteScalar
        '***********************************************************************
        cmd.CommandText = "SELECT PARAMETER2 FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN') and PARAMETER1 in ('CSV_Environment') and [PARAMETER STATUS]='Y'"
        CSV_Environment = cmd.ExecuteScalar
        cmd.CommandText = "SELECT PARAMETER2 FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN') and PARAMETER1 in ('CSV_RegulationFileType') and [PARAMETER STATUS]='Y'"
        CSV_RegulationFileType = cmd.ExecuteScalar
        cmd.CommandText = "SELECT PARAMETER2 FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN') and PARAMETER1 in ('CSV_InterfaceVersion') and [PARAMETER STATUS]='Y'"
        CSV_InterfaceVersion = cmd.ExecuteScalar
        cmd.CommandText = "SELECT PARAMETER2 FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN') and PARAMETER1 in ('CSV_CreationFolderDirectory') and [PARAMETER STATUS]='Y'"
        CSV_CreationFolderDirectory = cmd.ExecuteScalar
        'Get Email receiver
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and PARAMETER1 in ('Email_MIFIR_CSV_Receiver') and [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN')"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            EMAIL_TO += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        dt.Clear()
        'Get Email receiver CC
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and PARAMETER1 in ('Email_MIFIR_CSV_CC') and [IdABTEILUNGSPARAMETER]='MIFIR_REPORTING' and IdABTEILUNGSCODE_NAME in ('MELDEWESEN')"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            EMAIL_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        dt.Clear()

        'Bind Combobox
        Me.BusinessTypeDateEdit.Properties.Items.Clear()
        Me.QueryText = " Select CONVERT(VARCHAR(10),[TradeDate],104) as 'RLDC Date' from [MIFIR] GROUP BY [TradeDate] Order by [TradeDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessTypeDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessTypeDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        'Get 
        rd = Me.BusinessTypeDateEdit.Text
        rdsql = rd.ToString("yyyyMMdd")

        Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
        CHECK_EXISTING_CSV_FILE()

        Me.XtraTabControl1.Focus()

        'TREASURY DEALS
        GridControl1.UseEmbeddedNavigator = True
        GridControl1.MainView = BT_CP_Totals_GridView
        BT_CP_Totals_GridView.ForceDoubleClick = True
        AddHandler BT_CP_Totals_GridView.DoubleClick, AddressOf BT_CP_Totals_GridView_DoubleClick
        AddHandler MIFID_Treasury_Data_LayoutView.MouseDown, AddressOf MIFID_Treasury_Data_LayoutView_MouseDown
        AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        MIFID_Treasury_Data_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        MIFID_Treasury_Data_LayoutView.OptionsBehavior.AllowSwitchViewModes = False


        'CSV DATA
        GridControl3.UseEmbeddedNavigator = True
        GridControl3.MainView = BT_CP_DetailsAll_Gridview
        BT_CP_DetailsAll_Gridview.ForceDoubleClick = True
        AddHandler BT_CP_DetailsAll_Gridview.DoubleClick, AddressOf BT_CP_DetailsAll_Gridview_DoubleClick
        AddHandler Csv_Data_LayoutView.MouseDown, AddressOf Csv_Data_LayoutView_MouseDown
        AddHandler View1_Details_btn.Click, AddressOf View1_Details_btn_Click
        Csv_Data_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        Csv_Data_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Private fExtendedEditModeCSV As Boolean = False
    Private strHideExtendedModeCSV As String = "View List"
    Private strShowExtendedModeCSV As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            GridControl1.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = MIFID_Treasury_Data_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl1.MainView = BT_CP_Totals_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl1.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl1.MainView Is MIFID_Treasury_Data_LayoutView)

        End If

    End Sub
    Protected Sub HideDetailCSV(ByVal rowHandle As Integer)
        If ActiveTabGroup = 1 Then
            GridControl3.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = Csv_Data_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = BT_CP_DetailsAll_Gridview
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View1_Details_btn.Text = strShowExtendedModeCSV
            fExtendedEditModeCSV = (GridControl3.MainView Is Csv_Data_LayoutView)
        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            Dim datasourceRowIndex As Integer = BT_CP_Totals_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl1.MainView = MIFID_Treasury_Data_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl1.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl1.MainView Is MIFID_Treasury_Data_LayoutView)
        End If

    End Sub

    Protected Sub ShowDetailCSV(ByVal rowHandle As Integer)
        If ActiveTabGroup = 1 Then
            Dim datasourceRowIndex As Integer = BT_CP_DetailsAll_Gridview.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = Csv_Data_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View1_Details_btn.Text = strHideExtendedModeCSV
            fExtendedEditModeCSV = (GridControl3.MainView Is Csv_Data_LayoutView)
        End If
    End Sub

    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = BT_CP_Totals_GridView.GetRowHandle(dataSourceRowIndex)
            BT_CP_Totals_GridView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = BT_CP_DetailsAll_Gridview.GetRowHandle(dataSourceRowIndex)
            BT_CP_DetailsAll_Gridview.FocusedRowHandle = rowHandle
        End If

    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = MIFID_Treasury_Data_LayoutView.GetRowHandle(dataSourceRowIndex)
            MIFID_Treasury_Data_LayoutView.VisibleRecordIndex = MIFID_Treasury_Data_LayoutView.GetVisibleIndex(rowHandle)
            MIFID_Treasury_Data_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = Csv_Data_LayoutView.GetRowHandle(dataSourceRowIndex)
            Csv_Data_LayoutView.VisibleRecordIndex = Csv_Data_LayoutView.GetVisibleIndex(rowHandle)
            Csv_Data_LayoutView.FocusedRowHandle = dataSourceRowIndex
        End If

    End Sub


    Protected Sub BT_CP_Totals_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BT_CP_Totals_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub BT_CP_DetailsAll_Gridview_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BT_CP_DetailsAll_Gridview.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetailCSV(hi.RowHandle)
        End If
    End Sub

    Protected Sub MIFID_Treasury_Data_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = MIFID_Treasury_Data_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub Csv_Data_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = Csv_Data_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetailCSV(hi.RowHandle)
            End If
        End If
    End Sub

    Private Sub View_Details_btn_Click(sender As Object, e As EventArgs) Handles View_Details_btn.Click

        If fExtendedEditMode Then
                HideDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl1.MainView, ColumnView)).FocusedRowHandle)
            End If


    End Sub

    Private Sub View1_Details_btn_Click(sender As Object, e As EventArgs) Handles View1_Details_btn.Click

        If fExtendedEditModeCSV Then
            HideDetailCSV((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetailCSV((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
        End If

    End Sub

#End Region


    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        rd = Me.BusinessTypeDateEdit.Text
        rdsql = rd.ToString("yyyyMMdd")
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then

        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then

        End If

    End Sub

#Region "Default Row Styles and Print"
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

    Private Sub BT_CP_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BT_CP_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_BT_CP_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_Totals_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        If GridControl1.MainView Is BT_CP_Totals_GridView Then
            'If View_Details_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else

            Me.MIFID_Treasury_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.MIFID_Treasury_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.MIFID_Treasury_Data_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.MIFID_Treasury_Data_LayoutView.OptionsPrint.PrintCardCaption = True
            Me.MIFID_Treasury_Data_LayoutView.OptionsPrint.AllowCancelPrintExport = True
            Me.MIFID_Treasury_Data_LayoutView.OptionsPrint.ShowPrintExportProgress = True
            PreviewPrintableComponent(GridControl1, GridControl1.LookAndFeel)
            Me.MIFID_Treasury_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.MIFID_Treasury_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        End If

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
        Dim reportfooter As String = "MIFID Data from Treasury " & vbNewLine & "Trade Date: " & Me.BusinessTypeDateEdit.Text

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub




    Private Sub BT_CP_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_DetailsAll_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_BT_CP_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_DetailsAll_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        If GridControl3.MainView Is BT_CP_DetailsAll_Gridview Then
            'If View1_Details_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.Csv_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.Csv_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.Csv_Data_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.Csv_Data_LayoutView.OptionsPrint.PrintCardCaption = True
            Me.Csv_Data_LayoutView.OptionsPrint.AllowCancelPrintExport = True
            Me.Csv_Data_LayoutView.OptionsPrint.ShowPrintExportProgress = True
            PreviewPrintableComponent(GridControl3, GridControl3.LookAndFeel)
            'Me.FX_All_LayoutView1.ShowPrintPreview()
            Me.Csv_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.Csv_Data_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        End If

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
        Dim reportfooter As String = "MIFID CSV Data " & "   " & "Trade Date: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region



    Private Sub BusinessTypeDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessTypeDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Or e.Button.Caption = "Trade Date" Then
            Me.GridControl1.DataSource = Me.MIFIRBindingSource
            Me.GridControl3.DataSource = Me.MIFIRBindingSource

            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                rd = Me.BusinessTypeDateEdit.Text
                rdsql = rd.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load MIFIR Data for Trade Date: " & rd)
                Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
                CHECK_EXISTING_CSV_FILE()
                SplashScreenManager.CloseForm(False)

            End If
        End If
        If e.Button.Caption = "Create CSV File" Then
            Me.GridControl1.DataSource = Me.MIFIRBindingSource
            Me.GridControl3.DataSource = Me.MIFIRBindingSource

            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                rd = Me.BusinessTypeDateEdit.Text
                rdsql = rd.ToString("yyyyMMdd")

                If rd < Today Then
                    'Load BusinessTypes Data
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load MIFIR Data for Trade Date: " & rd)
                    Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
                    SplashScreenManager.CloseForm(False)

                    Try
                        If MessageBox.Show("Should the MIFIR CSV File for " & rd & " be created?" & vbNewLine & vbNewLine & "Info:If the CSV File has been already created for this Trade Date, it will be automatically deleted!", "MIFIR CSV FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                            SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands:SEVERAL SELECTIONS/MIFIR_REPORTING for " & rd)

                            If cmd.Connection.State = ConnectionState.Closed Then
                                cmd.Connection.Open()
                            End If
                            cmd.CommandTimeout = 50000


                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('MIFIR_REPORTING')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Threading.Thread.Sleep(500)
                                    SplashScreenManager.Default.SetWaitFormCaption("MIFIR Reporting: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                            Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)

                            'Check if are cutomers not recognized
                            cmd.CommandText = "Select COUNT(ID) from MIFIR where TRADE_DATE='" & rdsql & "' and ClientNr is NULL"
                            Dim UndefinedCustomersCount As Double = cmd.ExecuteScalar
                            If UndefinedCustomersCount > 0 Then
                                If MessageBox.Show("There are " & UndefinedCustomersCount & " FX Swaps with Client Nr./Name empty!!" & vbNewLine & "Should these FX Swap deals considered as CANCELLED ?" & vbNewLine & vbNewLine & "All Cancelled FX Deals will be not included in the MIFIR csv File!", "UNRECOGNIZED SWAP DEALS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                                    cmd.CommandText = "Update MIFIR set ClientNr='CANCELLED',ClientName='CANCELLED',CountryOfResidence='DE' where TRADE_DATE='" & rdsql & "' and ClientNr is NULL"
                                    cmd.ExecuteNonQuery()
                                    MIFIR_CSV_FILE_CREATION()
                                    CHECK_EXISTING_CSV_FILE()
                                    Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
                                Else
                                    MessageBox.Show("The MIFIR csv file not created !!" & vbNewLine & "Unable to create csv File with missing Client Data!", "MIFIR CSV FILE NOT CREATED", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Return
                                End If
                            ElseIf UndefinedCustomersCount = 0 Then
                                MIFIR_CSV_FILE_CREATION()
                                CHECK_EXISTING_CSV_FILE()
                            End If



                            If cmd.Connection.State = ConnectionState.Open Then
                                cmd.Connection.Close()
                            End If


                        End If
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    MessageBox.Show("Unable to create the MIFIR CSV File for Trade Date: " & rd & vbNewLine & "The selected Trade Date is equal with the current Date!" & vbNewLine & "Please select allways Trade Date < Current Date" & vbNewLine & "for the MIFIR CSV File Creation", "TRADE DATE = CURRENT DATE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            End If
            End If

        If e.Button.Caption = "Send CSV File via EMAIL" Then
            CSV_VIA_EMAIL()
        End If

        If e.Button.Caption = "Open CSV Files Folder" Then

            If Directory.Exists(CSV_CreationFolderDirectory) Then

                System.Diagnostics.Process.Start(CSV_CreationFolderDirectory)
            Else
                MessageBox.Show("Unable to open creation Folder!", "CREATION FOLDER DOES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub

    Private Sub MIFIR_CSV_FILE_CREATION()
        'Dim CountFxDeals As Double = 0
        'Dim Count As Double = 0
        ''Check Country of Residence
        'cmd.CommandText = "Select Count([ID]) from [MIFIR] where [TradeDate]='" & rdsql & "' and [CountryOfResidence] is NULL"
        'CountFxDeals = cmd.ExecuteScalar
        'If CountFxDeals = 0 Then
        Dim CSV_FILE_NAME As String = CSV_Environment & "_" & LEI_CODE & "_" & rdsql & "T" & Now.ToString("hhmmssfff") & "_" & CSV_RegulationFileType & ".CSV"
            SplashScreenManager.Default.SetWaitFormCaption("Generating File:" & CSV_FILE_NAME & vbNewLine & "Please wait...")
            Dim CSV_HEADER_FIRST As String = LEI_CODE & vbNewLine _
                & rd.ToString("yyyy-MM-dd") & "T" & Now.ToString("hh:mm:ss") & "Z" & vbNewLine _
                & CSV_Environment & vbNewLine _
                & CSV_RegulationFileType & vbNewLine _
                & CSV_InterfaceVersion & vbNewLine

            Dim CSV_HEADER As String = "TRADE-DATE;CUSTOMER-TRANSACTION-ID;ACTION-TYPE;BUSINESS-UNIT;USER-ID;MIFIR-REPORTING;COMMENT;TRADE-REPORT-ID;SOURCE-SYSTEM;RECORD-MODE;USER-FIELD1;USER-FIELD2;USER-FIELD3;USER-FIELD4;USER-FIELD5;USER-FIELD6;USER-FIELD7;USER-FIELD8;USER-FIELD9;PARTIAL-ASSISTANCE-FLAG;PARTIAL-ASSISTANCE-SUBMITTER-ID;PAIRING-ID;EXECUTING-ENTITY-ID-TYPE;EXECUTING-ENTITY-ID;MIFID-INVESTMENT-FIRM;BRANCH-MEMBERSHIP-COUNTRY;BUYER-ID-TYPE;BUYER-ID;BUYER-BRANCH-COUNTRY;BUYER-FIRSTNAME;BUYER-SURNAME;BUYER-BIRTHDATE;BUYER-DECISION-MAKER-ID-TYPE;BUYER-DECISION-MAKER-ID;BUYER-DECISION-FIRSTNAME;BUYER-DECISION-SURNAME;BUYER-DECISION-BIRTHDATE;SELLER-ID-TYPE;SELLER-ID;SELLER-BRANCH-COUNTRY;SELLER-FIRSTNAME;SELLER-SURNAME;SELLER-BIRTHDATE;SELLER-DECISION-MAKER-ID-TYPE;SELLER-DECISION-MAKER-ID;SELLER-DECISION-FIRST-NAME;SELLER-DECISION-SURNAME;SELLER-DECISION-BIRTHDATE;TRANSMISSION-IND;TRANSMITTING-ENTITY-BUYER-ID-TYPE;TRANSMITTING-ENTITY-BUYER-ID;TRANSMITTING-ENTITY-SELLER-ID-TYPE;TRANSMITTING-ENTITY-SELLER-ID;TRN-REF-NUMBER;TRADING-VENUE-TRN-ID-CODE;VENUE;TRADE-TIME;MIFIR-TRADING-CAPACITY;QUANTITY-NOTATION;QUANTITY;QUANTITY-CURRENCY;NOTIONAL-INCREASE-DECREASE;PRICE-NOTATION;PRICE;PRICE-CURRENCY;NET-AMOUNT;UPFRONT-PAYMENT;UPFRONT-PAYMENT-CURRENCY;COMPLEX-TRADE-COMPONENT-ID;INSTRUMENT-ID-TYPE;INSTRUMENT-ID;INSTRUMENT-NAME;INSTRUMENT-CLASS;NOTIONAL-CURRENCY-1;NOTIONAL-CURRENCY-2;PRICE-MULTIPLIER;UNDERLYING-INSTRUMENT-DIRECTION;UNDERLYING-INSTRUMENT-CODE;UNDERLYING-INDEX-DIRECTION;UNDERLYING-INDEX-CODE;UNDERLYING-INDEX-NAME;UNDERLYING-INDEX-TERM;UNDERLYING-INDEX-TERM-UNIT;OPTION-TYPE;STRIKE-PRICE-NOTATION;STRIKE-PRICE;STRIKE-PRICE-CURRENCY;OPTION-EXERCISE-STYLE;MATURITY-DATE-INSTRUMENT;EXPIRY-DATE;DELIVERY-TYPE;INVESTMENT-DECISION-ID-TYPE;INVESTMENT-DECISION-ID;INVESTMENT-DECISION-BRANCH-COUNTRY;EXECUTION-ID-TYPE;EXECUTION-ID;SUPERVISING-BRANCH-COUNTRY;WAIVER-INDICATOR;SHORT-SELLING-INDICATOR;OTC-POST-TRADE-INDICATOR;COMMODITY-DERIVATIVE-INDICATOR;SFTR-INDICATOR;CLIENT-TYPE;ORDER-TYPE;DIRECTED-ORDER-FLAG;LIQP-FLAG;ORDER-GROUP-ID;TOAX-FLAG"
            Dim CSV_ROW As String = Nothing

            Dim TRADE_DATE As String = Nothing
            Dim CUSTOMER_TRANSACTION_ID As String = Nothing
            Dim ACTION_TYPE As String = Nothing
            Dim BUSINESS_UNIT As String = Nothing
            Dim USER_ID As String = Nothing
            Dim MIFIR_REPORTING As String = Nothing
            Dim COMMENT As String = Nothing
            Dim TRADE_REPORT_ID As String = Nothing
            Dim SOURCE_SYSTEM As String = Nothing
            Dim RECORD_MODE As String = Nothing
            Dim USER_FIELD1 As String = Nothing
            Dim USER_FIELD2 As String = Nothing
            Dim USER_FIELD3 As String = Nothing
            Dim USER_FIELD4 As String = Nothing
            Dim USER_FIELD5 As String = Nothing
            Dim USER_FIELD6 As String = Nothing
            Dim USER_FIELD7 As String = Nothing
            Dim USER_FIELD8 As String = Nothing
            Dim USER_FIELD9 As String = Nothing
            Dim PARTIAL_ASSISTANCE_FLAG As String = Nothing
            Dim PARTIAL_ASSISTANCE_SUBMITTER_ID As String = Nothing
            Dim PAIRING_ID As String = Nothing
            Dim EXECUTING_ENTITY_ID_TYPE As String = Nothing
            Dim EXECUTING_ENTITY_ID As String = Nothing
            Dim MIFID_INVESTMENT_FIRM As String = Nothing
            Dim BRANCH_MEMBERSHIP_COUNTRY As String = Nothing
            Dim BUYER_ID_TYPE As String = Nothing
            Dim BUYER_ID As String = Nothing
            Dim BUYER_BRANCH_COUNTRY As String = Nothing
            Dim BUYER_FIRSTNAME As String = Nothing
            Dim BUYER_SURNAME As String = Nothing
            Dim BUYER_BIRTHDATE As String = Nothing
            Dim BUYER_DECISION_MAKER_ID_TYPE As String = Nothing
            Dim BUYER_DECISION_MAKER_ID As String = Nothing
            Dim BUYER_DECISION_FIRSTNAME As String = Nothing
            Dim BUYER_DECISION_SURNAME As String = Nothing
            Dim BUYER_DECISION_BIRTHDATE As String = Nothing
            Dim SELLER_ID_TYPE As String = Nothing
            Dim SELLER_ID As String = Nothing
            Dim SELLER_BRANCH_COUNTRY As String = Nothing
            Dim SELLER_FIRSTNAME As String = Nothing
            Dim SELLER_SURNAME As String = Nothing
            Dim SELLER_BIRTHDATE As String = Nothing
            Dim SELLER_DECISION_MAKER_ID_TYPE As String = Nothing
            Dim SELLER_DECISION_MAKER_ID As String = Nothing
            Dim SELLER_DECISION_FIRST_NAME As String = Nothing
            Dim SELLER_DECISION_SURNAME As String = Nothing
            Dim SELLER_DECISION_BIRTHDATE As String = Nothing
            Dim TRANSMISSION_IND As String = Nothing
            Dim TRANSMITTING_ENTITY_BUYER_ID_TYPE As String = Nothing
            Dim TRANSMITTING_ENTITY_BUYER_ID As String = Nothing
            Dim TRANSMITTING_ENTITY_SELLER_ID_TYPE As String = Nothing
            Dim TRANSMITTING_ENTITY_SELLER_ID As String = Nothing
            Dim TRN_REF_NUMBER As String = Nothing
            Dim TRADING_VENUE_TRN_ID_CODE As String = Nothing
            Dim VENUE As String = Nothing
            Dim TRADE_TIME As String = Nothing
            Dim MIFIR_TRADING_CAPACITY As String = Nothing
            Dim QUANTITY_NOTATION As String = Nothing
            Dim QUANTITY As String = Nothing
            Dim QUANTITY_CURRENCY As String = Nothing
            Dim NOTIONAL_INCREASE_DECREASE As String = Nothing
            Dim PRICE_NOTATION As String = Nothing
            Dim PRICE As String = Nothing
            Dim PRICE_CURRENCY As String = Nothing
            Dim NET_AMOUNT As String = Nothing
            Dim UPFRONT_PAYMENT As String = Nothing
            Dim UPFRONT_PAYMENT_CURRENCY As String = Nothing
            Dim COMPLEX_TRADE_COMPONENT_ID As String = Nothing
            Dim INSTRUMENT_ID_TYPE As String = Nothing
            Dim INSTRUMENT_ID As String = Nothing
            Dim INSTRUMENT_NAME As String = Nothing
            Dim INSTRUMENT_CLASS As String = Nothing
            Dim NOTIONAL_CURRENCY_1 As String = Nothing
            Dim NOTIONAL_CURRENCY_2 As String = Nothing
            Dim PRICE_MULTIPLIER As String = Nothing
            Dim UNDERLYING_INSTRUMENT_DIRECTION As String = Nothing
            Dim UNDERLYING_INSTRUMENT_CODE As String = Nothing
            Dim UNDERLYING_INDEX_DIRECTION As String = Nothing
            Dim UNDERLYING_INDEX_CODE As String = Nothing
            Dim UNDERLYING_INDEX_NAME As String = Nothing
            Dim UNDERLYING_INDEX_TERM As String = Nothing
            Dim UNDERLYING_INDEX_TERM_UNIT As String = Nothing
            Dim OPTION_TYPE As String = Nothing
            Dim STRIKE_PRICE_NOTATION As String = Nothing
            Dim STRIKE_PRICE As String = Nothing
            Dim STRIKE_PRICE_CURRENCY As String = Nothing
            Dim OPTION_EXERCISE_STYLE As String = Nothing
            Dim MATURITY_DATE_INSTRUMENT As String = Nothing
            Dim EXPIRY_DATE As String = Nothing
            Dim DELIVERY_TYPE As String = Nothing
            Dim INVESTMENT_DECISION_ID_TYPE As String = Nothing
            Dim INVESTMENT_DECISION_ID As String = Nothing
            Dim INVESTMENT_DECISION_BRANCH_COUNTRY As String = Nothing
            Dim EXECUTION_ID_TYPE As String = Nothing
            Dim EXECUTION_ID As String = Nothing
            Dim SUPERVISING_BRANCH_COUNTRY As String = Nothing
            Dim WAIVER_INDICATOR As String = Nothing
            Dim SHORT_SELLING_INDICATOR As String = Nothing
            Dim OTC_POST_TRADE_INDICATOR As String = Nothing
            Dim COMMODITY_DERIVATIVE_INDICATOR As String = Nothing
            Dim SFTR_INDICATOR As String = Nothing
            Dim CLIENT_TYPE As String = Nothing
            Dim ORDER_TYPE As String = Nothing
            Dim DIRECTED_ORDER_FLAG As String = Nothing
            Dim LIQP_FLAG As String = Nothing
            Dim ORDER_GROUP_ID As String = Nothing
            Dim TOAX_FLAG As String = Nothing

            If Not System.IO.Directory.Exists(CSV_CreationFolderDirectory & rdsql) Then
                System.IO.Directory.CreateDirectory(CSV_CreationFolderDirectory & rdsql)
            Else
                My.Computer.FileSystem.DeleteDirectory(CSV_CreationFolderDirectory & rdsql, FileIO.DeleteDirectoryOption.DeleteAllContents)
                System.IO.Directory.CreateDirectory(CSV_CreationFolderDirectory & rdsql)
            End If


            If File.Exists(CSV_CreationFolderDirectory & rdsql & "\" & CSV_FILE_NAME) = True Then
                File.Delete(CSV_CreationFolderDirectory & rdsql & "\" & CSV_FILE_NAME)
            End If
            'Create Header
            System.IO.File.AppendAllText(CSV_CreationFolderDirectory & rdsql & "\" & CSV_FILE_NAME, CSV_HEADER_FIRST & CSV_HEADER & vbCrLf)

        Me.QueryText = "SELECT  * FROM  [MIFIR] where [TradeDate]='" & rdsql & "' and ClientNr not in ('CANCELLED')"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Threading.Thread.Sleep(300)
                SplashScreenManager.Default.SetWaitFormCaption("MIFIR Transaction Record: " & dt.Rows.Item(i).Item("TradingVenueTransactionIdentificationCode"))

                TRADE_DATE = String.Format("{0:yyyy-MM-dd}", dt.Rows.Item(i).Item("TRADE_DATE")) & ";"
                CUSTOMER_TRANSACTION_ID = dt.Rows.Item(i).Item("CUSTOMER_TRANSACTION_ID") & ";"
                ACTION_TYPE = dt.Rows.Item(i).Item("ACTION_TYPE") & ";"
                BUSINESS_UNIT = dt.Rows.Item(i).Item("BUSINESS_UNIT") & ";"
                USER_ID = dt.Rows.Item(i).Item("USER_ID") & ";"
                MIFIR_REPORTING = dt.Rows.Item(i).Item("MIFIR_REPORTING") & ";"
                COMMENT = dt.Rows.Item(i).Item("COMMENT") & ";"
                TRADE_REPORT_ID = dt.Rows.Item(i).Item("TRADE_REPORT_ID") & ";"
                SOURCE_SYSTEM = dt.Rows.Item(i).Item("SOURCE_SYSTEM") & ";"
                RECORD_MODE = dt.Rows.Item(i).Item("RECORD_MODE") & ";"
                USER_FIELD1 = dt.Rows.Item(i).Item("USER_FIELD1") & ";"
                USER_FIELD2 = dt.Rows.Item(i).Item("USER_FIELD2") & ";"
                USER_FIELD3 = dt.Rows.Item(i).Item("USER_FIELD3") & ";"
                USER_FIELD4 = dt.Rows.Item(i).Item("USER_FIELD4") & ";"
                USER_FIELD5 = dt.Rows.Item(i).Item("USER_FIELD5") & ";"
                USER_FIELD6 = dt.Rows.Item(i).Item("USER_FIELD6") & ";"
                USER_FIELD7 = dt.Rows.Item(i).Item("USER_FIELD7") & ";"
                USER_FIELD8 = dt.Rows.Item(i).Item("USER_FIELD8") & ";"
                USER_FIELD9 = dt.Rows.Item(i).Item("USER_FIELD9") & ";"
                PARTIAL_ASSISTANCE_FLAG = dt.Rows.Item(i).Item("PARTIAL_ASSISTANCE_FLAG") & ";"
                PARTIAL_ASSISTANCE_SUBMITTER_ID = dt.Rows.Item(i).Item("PARTIAL_ASSISTANCE_SUBMITTER_ID") & ";"
                PAIRING_ID = dt.Rows.Item(i).Item("PAIRING_ID") & ";"
                EXECUTING_ENTITY_ID_TYPE = dt.Rows.Item(i).Item("EXECUTING_ENTITY_ID_TYPE") & ";"
                EXECUTING_ENTITY_ID = dt.Rows.Item(i).Item("EXECUTING_ENTITY_ID") & ";"
                MIFID_INVESTMENT_FIRM = dt.Rows.Item(i).Item("MIFID_INVESTMENT_FIRM") & ";"
                BRANCH_MEMBERSHIP_COUNTRY = dt.Rows.Item(i).Item("BRANCH_MEMBERSHIP_COUNTRY") & ";"
                BUYER_ID_TYPE = dt.Rows.Item(i).Item("BUYER_ID_TYPE") & ";"
                BUYER_ID = dt.Rows.Item(i).Item("BUYER_ID") & ";"
                BUYER_BRANCH_COUNTRY = dt.Rows.Item(i).Item("BUYER_BRANCH_COUNTRY") & ";"
                BUYER_FIRSTNAME = dt.Rows.Item(i).Item("BUYER_FIRSTNAME") & ";"
                BUYER_SURNAME = dt.Rows.Item(i).Item("BUYER_SURNAME") & ";"
                If IsDBNull(dt.Rows.Item(i).Item("BUYER_BIRTHDATE")) = False Then
                    Dim BUYER_BIRTHDATE_Date As Date = dt.Rows.Item(i).Item("BUYER_BIRTHDATE")
                    BUYER_BIRTHDATE = BUYER_BIRTHDATE_Date.ToString("yyyy-MM-dd") & ";"
                Else
                    BUYER_BIRTHDATE = ";"
                End If
                BUYER_DECISION_MAKER_ID_TYPE = dt.Rows.Item(i).Item("BUYER_DECISION_MAKER_ID_TYPE") & ";"
                BUYER_DECISION_MAKER_ID = dt.Rows.Item(i).Item("BUYER_DECISION_MAKER_ID") & ";"
                BUYER_DECISION_FIRSTNAME = dt.Rows.Item(i).Item("BUYER_DECISION_FIRSTNAME") & ";"
                BUYER_DECISION_SURNAME = dt.Rows.Item(i).Item("BUYER_DECISION_SURNAME") & ";"
                BUYER_DECISION_BIRTHDATE = dt.Rows.Item(i).Item("BUYER_DECISION_BIRTHDATE") & ";"
                SELLER_ID_TYPE = dt.Rows.Item(i).Item("SELLER_ID_TYPE") & ";"
                SELLER_ID = dt.Rows.Item(i).Item("SELLER_ID") & ";"
                SELLER_BRANCH_COUNTRY = dt.Rows.Item(i).Item("SELLER_BRANCH_COUNTRY") & ";"
                SELLER_FIRSTNAME = dt.Rows.Item(i).Item("SELLER_FIRSTNAME") & ";"
                SELLER_SURNAME = dt.Rows.Item(i).Item("SELLER_SURNAME") & ";"
                If IsDBNull(dt.Rows.Item(i).Item("SELLER_BIRTHDATE")) = False Then
                    Dim SELLER_BIRTHDATE_Date As Date = dt.Rows.Item(i).Item("SELLER_BIRTHDATE")
                    SELLER_BIRTHDATE = SELLER_BIRTHDATE_Date.ToString("yyyy-MM-dd") & ";"
                Else
                    SELLER_BIRTHDATE = ";"
                End If
                SELLER_DECISION_MAKER_ID_TYPE = dt.Rows.Item(i).Item("SELLER_DECISION_MAKER_ID_TYPE") & ";"
                SELLER_DECISION_MAKER_ID = dt.Rows.Item(i).Item("SELLER_DECISION_MAKER_ID") & ";"
                SELLER_DECISION_FIRST_NAME = dt.Rows.Item(i).Item("SELLER_DECISION_FIRST_NAME") & ";"
                SELLER_DECISION_SURNAME = dt.Rows.Item(i).Item("SELLER_DECISION_SURNAME") & ";"
                If IsDBNull(dt.Rows.Item(i).Item("SELLER_DECISION_BIRTHDATE")) = False Then
                    Dim SELLER_DECISION_BIRTHDATE_Date As Date = dt.Rows.Item(i).Item("SELLER_DECISION_BIRTHDATE")
                    SELLER_DECISION_BIRTHDATE = SELLER_DECISION_BIRTHDATE_Date.ToString("yyyy-MM-dd") & ";"
                Else
                    SELLER_DECISION_BIRTHDATE = ";"
                End If
                TRANSMISSION_IND = dt.Rows.Item(i).Item("TRANSMISSION_IND") & ";"
                TRANSMITTING_ENTITY_BUYER_ID_TYPE = dt.Rows.Item(i).Item("TRANSMITTING_ENTITY_BUYER_ID_TYPE") & ";"
                TRANSMITTING_ENTITY_BUYER_ID = dt.Rows.Item(i).Item("TRANSMITTING_ENTITY_BUYER_ID") & ";"
                TRANSMITTING_ENTITY_SELLER_ID_TYPE = dt.Rows.Item(i).Item("TRANSMITTING_ENTITY_SELLER_ID_TYPE") & ";"
                TRANSMITTING_ENTITY_SELLER_ID = dt.Rows.Item(i).Item("TRANSMITTING_ENTITY_SELLER_ID") & ";"
                TRN_REF_NUMBER = dt.Rows.Item(i).Item("TRN_REF_NUMBER") & ";"
                TRADING_VENUE_TRN_ID_CODE = dt.Rows.Item(i).Item("TRADING_VENUE_TRN_ID_CODE") & ";"
                VENUE = dt.Rows.Item(i).Item("VENUE") & ";"
                TRADE_TIME = String.Format("{0:hh:mm:ss.ffffff}", dt.Rows.Item(i).Item("TRADE_TIME")) & "Z" & ";"
                MIFIR_TRADING_CAPACITY = dt.Rows.Item(i).Item("MIFIR_TRADING_CAPACITY") & ";"
                QUANTITY_NOTATION = dt.Rows.Item(i).Item("QUANTITY_NOTATION") & ";"
                QUANTITY = dt.Rows.Item(i).Item("QUANTITY").ToString.Replace(",", ".") & ";"
                QUANTITY_CURRENCY = dt.Rows.Item(i).Item("QUANTITY_CURRENCY") & ";"
                NOTIONAL_INCREASE_DECREASE = dt.Rows.Item(i).Item("NOTIONAL_INCREASE_DECREASE") & ";"
                PRICE_NOTATION = dt.Rows.Item(i).Item("PRICE_NOTATION") & ";"
                PRICE = dt.Rows.Item(i).Item("PRICE").ToString.Replace(",", ".") & ";"
                PRICE_CURRENCY = dt.Rows.Item(i).Item("PRICE_CURRENCY") & ";"
                NET_AMOUNT = dt.Rows.Item(i).Item("NET_AMOUNT").ToString.Replace(",", ".") & ";"
                UPFRONT_PAYMENT = dt.Rows.Item(i).Item("UPFRONT_PAYMENT").ToString.Replace(",", ".") & ";"
                UPFRONT_PAYMENT_CURRENCY = dt.Rows.Item(i).Item("UPFRONT_PAYMENT_CURRENCY") & ";"
                COMPLEX_TRADE_COMPONENT_ID = dt.Rows.Item(i).Item("COMPLEX_TRADE_COMPONENT_ID") & ";"
                INSTRUMENT_ID_TYPE = dt.Rows.Item(i).Item("INSTRUMENT_ID_TYPE") & ";"
                INSTRUMENT_ID = dt.Rows.Item(i).Item("INSTRUMENT_ID") & ";"
                INSTRUMENT_NAME = dt.Rows.Item(i).Item("INSTRUMENT_NAME") & ";"
                INSTRUMENT_CLASS = dt.Rows.Item(i).Item("INSTRUMENT_CLASS") & ";"
                NOTIONAL_CURRENCY_1 = dt.Rows.Item(i).Item("NOTIONAL_CURRENCY_1") & ";"
                NOTIONAL_CURRENCY_2 = dt.Rows.Item(i).Item("NOTIONAL_CURRENCY_2") & ";"
                PRICE_MULTIPLIER = dt.Rows.Item(i).Item("PRICE_MULTIPLIER").ToString.Replace(",", ".") & ";"
                UNDERLYING_INSTRUMENT_DIRECTION = dt.Rows.Item(i).Item("UNDERLYING_INSTRUMENT_DIRECTION") & ";"
                UNDERLYING_INSTRUMENT_CODE = dt.Rows.Item(i).Item("UNDERLYING_INSTRUMENT_CODE") & ";"
                UNDERLYING_INDEX_DIRECTION = dt.Rows.Item(i).Item("UNDERLYING_INDEX_DIRECTION") & ";"
                UNDERLYING_INDEX_CODE = dt.Rows.Item(i).Item("UNDERLYING_INDEX_CODE") & ";"
                UNDERLYING_INDEX_NAME = dt.Rows.Item(i).Item("UNDERLYING_INDEX_NAME") & ";"
                UNDERLYING_INDEX_TERM = dt.Rows.Item(i).Item("UNDERLYING_INDEX_TERM") & ";"
                UNDERLYING_INDEX_TERM_UNIT = dt.Rows.Item(i).Item("UNDERLYING_INDEX_TERM_UNIT") & ";"
                OPTION_TYPE = dt.Rows.Item(i).Item("OPTION_TYPE") & ";"
                STRIKE_PRICE_NOTATION = dt.Rows.Item(i).Item("STRIKE_PRICE_NOTATION") & ";"
                STRIKE_PRICE = dt.Rows.Item(i).Item("STRIKE_PRICE").ToString.Replace(",", ".") & ";"
                STRIKE_PRICE_CURRENCY = dt.Rows.Item(i).Item("STRIKE_PRICE_CURRENCY") & ";"
                OPTION_EXERCISE_STYLE = dt.Rows.Item(i).Item("OPTION_EXERCISE_STYLE") & ";"
                If IsDBNull(dt.Rows.Item(i).Item("MATURITY_DATE_INSTRUMENT")) = False Then
                    Dim MATURITY_DATE_INSTRUMENT_Date As Date = dt.Rows.Item(i).Item("MATURITY_DATE_INSTRUMENT")
                    MATURITY_DATE_INSTRUMENT = MATURITY_DATE_INSTRUMENT_Date.ToString("yyyy-MM-dd") & ";"
                Else
                    MATURITY_DATE_INSTRUMENT = ";"
                End If

                If IsDBNull(dt.Rows.Item(i).Item("EXPIRY_DATE")) = False Then
                    Dim EXPIRY_DATE_Date As Date = dt.Rows.Item(i).Item("EXPIRY_DATE")
                    EXPIRY_DATE = EXPIRY_DATE_Date.ToString("yyyy-MM-dd") & ";"
                Else
                    EXPIRY_DATE = ";"
                End If
                DELIVERY_TYPE = dt.Rows.Item(i).Item("DELIVERY_TYPE") & ";"
                INVESTMENT_DECISION_ID_TYPE = dt.Rows.Item(i).Item("INVESTMENT_DECISION_ID_TYPE") & ";"
                INVESTMENT_DECISION_ID = dt.Rows.Item(i).Item("INVESTMENT_DECISION_ID") & ";"
                INVESTMENT_DECISION_BRANCH_COUNTRY = dt.Rows.Item(i).Item("INVESTMENT_DECISION_BRANCH_COUNTRY") & ";"
                EXECUTION_ID_TYPE = dt.Rows.Item(i).Item("EXECUTION_ID_TYPE") & ";"
                EXECUTION_ID = dt.Rows.Item(i).Item("EXECUTION_ID") & ";"
                SUPERVISING_BRANCH_COUNTRY = dt.Rows.Item(i).Item("SUPERVISING_BRANCH_COUNTRY") & ";"
                WAIVER_INDICATOR = dt.Rows.Item(i).Item("WAIVER_INDICATOR") & ";"
                SHORT_SELLING_INDICATOR = dt.Rows.Item(i).Item("SHORT_SELLING_INDICATOR") & ";"
                OTC_POST_TRADE_INDICATOR = dt.Rows.Item(i).Item("OTC_POST_TRADE_INDICATOR") & ";"
                COMMODITY_DERIVATIVE_INDICATOR = dt.Rows.Item(i).Item("COMMODITY_DERIVATIVE_INDICATOR") & ";"
                SFTR_INDICATOR = dt.Rows.Item(i).Item("SFTR_INDICATOR") & ";"
                CLIENT_TYPE = dt.Rows.Item(i).Item("CLIENT_TYPE") & ";"
                ORDER_TYPE = dt.Rows.Item(i).Item("ORDER_TYPE") & ";"
                DIRECTED_ORDER_FLAG = dt.Rows.Item(i).Item("DIRECTED_ORDER_FLAG") & ";"
                LIQP_FLAG = dt.Rows.Item(i).Item("LIQP_FLAG") & ";"
                ORDER_GROUP_ID = dt.Rows.Item(i).Item("ORDER_GROUP_ID") & ";"
                If IsDBNull(dt.Rows.Item(i).Item("TOAX_FLAG")) = False Then
                    TOAX_FLAG = dt.Rows.Item(i).Item("TOAX_FLAG") & ";"
                Else
                    TOAX_FLAG = ""
                End If

                CSV_ROW = TRADE_DATE & CUSTOMER_TRANSACTION_ID & ACTION_TYPE & BUSINESS_UNIT & USER_ID & MIFIR_REPORTING & COMMENT & TRADE_REPORT_ID & SOURCE_SYSTEM & RECORD_MODE & USER_FIELD1 & USER_FIELD2 & USER_FIELD3 & USER_FIELD4 & USER_FIELD5 & USER_FIELD6 & USER_FIELD7 & USER_FIELD8 & USER_FIELD9 & PARTIAL_ASSISTANCE_FLAG & PARTIAL_ASSISTANCE_SUBMITTER_ID & PAIRING_ID & EXECUTING_ENTITY_ID_TYPE & EXECUTING_ENTITY_ID & MIFID_INVESTMENT_FIRM & BRANCH_MEMBERSHIP_COUNTRY & BUYER_ID_TYPE & BUYER_ID & BUYER_BRANCH_COUNTRY & BUYER_FIRSTNAME & BUYER_SURNAME & BUYER_BIRTHDATE & BUYER_DECISION_MAKER_ID_TYPE & BUYER_DECISION_MAKER_ID & BUYER_DECISION_FIRSTNAME & BUYER_DECISION_SURNAME & BUYER_DECISION_BIRTHDATE & SELLER_ID_TYPE & SELLER_ID & SELLER_BRANCH_COUNTRY & SELLER_FIRSTNAME & SELLER_SURNAME & SELLER_BIRTHDATE & SELLER_DECISION_MAKER_ID_TYPE & SELLER_DECISION_MAKER_ID & SELLER_DECISION_FIRST_NAME & SELLER_DECISION_SURNAME & SELLER_DECISION_BIRTHDATE & TRANSMISSION_IND & TRANSMITTING_ENTITY_BUYER_ID_TYPE & TRANSMITTING_ENTITY_BUYER_ID & TRANSMITTING_ENTITY_SELLER_ID_TYPE & TRANSMITTING_ENTITY_SELLER_ID & TRN_REF_NUMBER & TRADING_VENUE_TRN_ID_CODE & VENUE & TRADE_TIME & MIFIR_TRADING_CAPACITY & QUANTITY_NOTATION & QUANTITY & QUANTITY_CURRENCY & NOTIONAL_INCREASE_DECREASE & PRICE_NOTATION & PRICE & PRICE_CURRENCY & NET_AMOUNT & UPFRONT_PAYMENT & UPFRONT_PAYMENT_CURRENCY & COMPLEX_TRADE_COMPONENT_ID & INSTRUMENT_ID_TYPE & INSTRUMENT_ID & INSTRUMENT_NAME & INSTRUMENT_CLASS & NOTIONAL_CURRENCY_1 & NOTIONAL_CURRENCY_2 & PRICE_MULTIPLIER & UNDERLYING_INSTRUMENT_DIRECTION & UNDERLYING_INSTRUMENT_CODE & UNDERLYING_INDEX_DIRECTION & UNDERLYING_INDEX_CODE & UNDERLYING_INDEX_NAME & UNDERLYING_INDEX_TERM & UNDERLYING_INDEX_TERM_UNIT & OPTION_TYPE & STRIKE_PRICE_NOTATION & STRIKE_PRICE & STRIKE_PRICE_CURRENCY & OPTION_EXERCISE_STYLE & MATURITY_DATE_INSTRUMENT & EXPIRY_DATE & DELIVERY_TYPE & INVESTMENT_DECISION_ID_TYPE & INVESTMENT_DECISION_ID & INVESTMENT_DECISION_BRANCH_COUNTRY & EXECUTION_ID_TYPE & EXECUTION_ID & SUPERVISING_BRANCH_COUNTRY & WAIVER_INDICATOR & SHORT_SELLING_INDICATOR & OTC_POST_TRADE_INDICATOR & COMMODITY_DERIVATIVE_INDICATOR & SFTR_INDICATOR & CLIENT_TYPE & ORDER_TYPE & DIRECTED_ORDER_FLAG & LIQP_FLAG & ORDER_GROUP_ID & TOAX_FLAG
                System.IO.File.AppendAllText(CSV_CreationFolderDirectory & rdsql & "\" & CSV_FILE_NAME, CSV_ROW & vbCrLf)
            Next

        'Create Footer
        Dim CountDeals As Double = 0
        cmd.CommandText = "Select Count([ID]) from [MIFIR] where [TradeDate]='" & rdsql & "' and ClientNr not in ('CANCELLED')"
        CountDeals = cmd.ExecuteScalar + 7
            Dim CSV_FOOTER As String = Nothing
            CSV_FOOTER = "NOL;" & CountDeals.ToString
            System.IO.File.AppendAllText(CSV_CreationFolderDirectory & rdsql & "\" & CSV_FILE_NAME, CSV_FOOTER)
            SplashScreenManager.CloseForm(False)
            If MessageBox.Show("The MiFIR Reporting CSV File for Trade date " & rd & " is created in the directory" & vbNewLine _
                & CSV_CreationFolderDirectory & rdsql & vbNewLine & "CSV FILE NAME: " & CSV_FILE_NAME & vbNewLine & "Should the directory be oppened?", "MIFIR CSV FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(CSV_CreationFolderDirectory & rdsql)
            End If

        'Else
        '    cmd.CommandText = "Select ProviderLEI from MIFIR where CountryOfResidence is null and [TradeDate]='" & rdsql & "' group by ProviderLEI"
        '    Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
        '    Dim dt2 As New DataTable
        '    da2.Fill(dt2)
        '    Dim MissingCustomers As String = Nothing
        '    If dt2.Rows.Count > 0 Then 'MM DEALS NO VALID
        '        For i = 0 To dt2.Rows.Count - 1
        '            MissingCustomers += " Client LEI: " & dt2.Rows.Item(i).Item("ProviderLEI") & vbNewLine
        '        Next
        '    End If
        '    SplashScreenManager.CloseForm(False)
        '    MessageBox.Show("Unable to create the MIFIR CSV File" & vbNewLine & "For the following Client LEI Codes the Residence Country is missing!" & vbNewLine & MissingCustomers & vbNewLine & vbNewLine & "Please consult the PS TOOL User Guide/MIFIR Reporting/MIFIR - Country of Residence is missing" & vbNewLine & "for further actions!", "COUNTRY OF RESIDENCE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Return
        'End If


    End Sub

    Private Sub CHECK_EXISTING_CSV_FILE()
        If System.IO.Directory.Exists(CSV_CreationFolderDirectory & rdsql) Then
            Me.CsvFileExistsCheck_lbl.Text = "MiFIR Csv File created"
            Me.CsvFileExistsCheck_lbl.ForeColor = Color.White
            Me.CsvFileExistsCheck_lbl.BackColor = Color.Green
        Else
            Me.CsvFileExistsCheck_lbl.Text = "MiFIR Csv File not created!"
            Me.CsvFileExistsCheck_lbl.ForeColor = Color.White
            Me.CsvFileExistsCheck_lbl.BackColor = Color.Red
        End If
    End Sub

    Private Sub CSV_VIA_EMAIL()
        rd = Me.BusinessTypeDateEdit.Text
        rdsql = rd.ToString("yyyyMMdd")

        If System.IO.Directory.Exists(CSV_CreationFolderDirectory & rdsql) Then
            If MessageBox.Show("Should the MIFIR CSV File for Trade Date: " & rd & " be send to the responsible Persons via Email?", "MIFIR CSV FILE EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim OutlookMessage As Outlook.MailItem
                    Dim AppOutlook As New Outlook.Application
                    OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
                    Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
                    Dim objNS As Outlook._NameSpace = AppOutlook.Session
                    Dim objFolder As Outlook.MAPIFolder
                    objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)

                    OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
                    OutlookMessage.To = EMAIL_TO
                    OutlookMessage.CC = EMAIL_CC
                    Dim fileEntries As String() = Directory.GetFiles(CSV_CreationFolderDirectory & rdsql, "*.csv")
                    Dim sOnlyFileName As String = Nothing
                    For Each sFileName In fileEntries
                        sOnlyFileName = System.IO.Path.GetFileName(sFileName)
                    Next sFileName

                    OutlookMessage.Subject = "CSV MIFIR File: " & sOnlyFileName & " for Trade Date:" & rd
                    'Attach all files in Email
                    For Each File In System.IO.Directory.GetFiles(CSV_CreationFolderDirectory & rdsql)
                        'EItem.Attachments.Add(File)
                        OutlookMessage.Attachments.Add(File)
                    Next File

                    OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML

                    Dim absatz As String = "<html><body><br><br></font></body></html>"

                    Dim StrBody1 As String = "<html><body><font size=2>******This is an automated E-Mail, generated from the PS TOOL Application!******<br><br>"
                    Dim StrBody2 As String = "<html><body><b><font color=""Blue"" size=4>Dear Colleagues,<br><br>" _
                                                                    + " <font color=""Blue"">see attached the automatically created MIFIR CSV File with Trade Date: " _
                                                                    & rd & "<br>for further upload to DEUTSCHE BÖRSE Regulatory Reporting HUB<br>" _
                                                                    + "with following FX SWAP Deals:<br><br></font></body></html>"
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select COUNT(ID) from [MIFIR] where [TradeDate]='" & rdsql & "' and ClientNr not in ('CANCELLED')"
                    Dim StrBody3 As String = "FX Deals Count: " & cmd.ExecuteScalar
                    Dim StrBody3_HTML As String = "<html><body><b><font color=""Blue"" size=4>" & StrBody3 & "<br></font></body></html>"
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                    Dim payOuts =
<html>
    <body>
        <TABLE BORDER='1' CELLSPACING='2' CELLPADDING='2'>
            <tr>
                <th>Transaction reference number</th>
                <th>Client Name</th>
                <th>Client Nr.</th>
                <th>Buyer</th>
                <th>Seller</th>
                <th>Instrument ID (ISIN)</th>
                <th>Venue</th>
                <th>Value Date</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Net Amount</th>
            </tr>
            <%= From paidOut In Me.MeldewesenDataSet.MIFIR.AsEnumerable Where paidOut.TradeDate = rd And paidOut.ClientNr <> "CANCELLED"
                Select <tr>
                           <td><%= paidOut.TRN_REF_NUMBER %></td>
                           <td><%= paidOut.ClientName %></td>
                           <td><%= paidOut.ClientNr %></td>
                           <td><%= paidOut.Buyer %></td>
                           <td><%= paidOut.Seller %></td>
                           <td><%= paidOut.ISIN %></td>
                           <td><%= paidOut.VENUE %></td>
                           <td><%= String.Format("{0:dd.MM.yyyy}", paidOut.ValueDate) %></td>
                           <td><%= paidOut.QUANTITY_CURRENCY & "  " & String.Format("{0:#,##0.00}", paidOut.QUANTITY) %></td>
                           <td><%= paidOut.PRICE_CURRENCY & "  " & paidOut.PRICE %></td>
                           <td><%= String.Format("{0:#,##0.00}", paidOut.NET_AMOUNT) %></td>
                       </tr> %>

        </TABLE>
    </body>
</html>



                    OutlookMessage.HTMLBody = StrBody1 & StrBody2 & payOuts.ToString & StrBody3_HTML

                    OutlookMessage.Display()



                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        Else
            MessageBox.Show("Unable to send the MIFIR CSV File" & vbNewLine & "The File Is Not present", "MIFIR CSV FILE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If


    End Sub

    Private Sub BusinessTypeDateEdit_Click(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.Click
        'If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
        '    Me.GridControl1.DataSource = Nothing
        '    Me.GridControl3.DataSource = Nothing

        'End If
    End Sub

  
    Private Sub BusinessTypeDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BusinessTypeDateEdit.KeyDown
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Me.MIFIRBindingSource
            Me.GridControl3.DataSource = Me.MIFIRBindingSource

            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                rd = Me.BusinessTypeDateEdit.Text
                rdsql = rd.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load MIFIR Data for Trade Date: " & rd)
                Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
                CHECK_EXISTING_CSV_FILE()
                SplashScreenManager.CloseForm(False)

            End If

        End If
    End Sub



    Private Sub BT_CP_Temp_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Temp_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BT_CP_Temp_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Temp_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub




    Private Sub BusinessTypes_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Me.BT_CP_Totals_GridView.IsFindPanelVisible Then
            'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
            Dim find As FindControl = TryCast(BT_CP_Totals_GridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        Else
            BT_CP_Totals_GridView.ShowFindPanel()
        End If

    End Sub



    Private Sub Print_Export_BT_CP_Temp_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_Temp_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "MIFID Data from Treasury " & vbNewLine & "Trade Date: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



    'Private Sub BusinessTyperReport_btn_Click(sender As Object, e As EventArgs) Handles BusinessTyperReport_btn.Click
    '    If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
    '        Dim d As Date = Me.BusinessTypeDateEdit.Text
    '        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '        SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types - Credit Portfolio Report for " & Me.BusinessTypeDateEdit.Text)

    '        Dim CrRep As New ReportDocument
    '        CrRep.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolio.rpt")
    '        CrRep.SetDataSource(RiskControllingDataSet)
    '        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
    '        Dim myParams As ParameterField = New ParameterField
    '        myValue.Value = d
    '        myParams.ParameterFieldName = "RDate"
    '        myParams.CurrentValues.Add(myValue)
    '        Dim c As New CrystalReportsForm
    '        c.MdiParent = Me.MdiParent
    '        c.Show()
    '        c.WindowState = FormWindowState.Maximized
    '        c.Text = "Business Types - Credit Portfolio Report from " & d
    '        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
    '        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
    '        c.CrystalReportViewer1.ReportSource = CrRep
    '        c.CrystalReportViewer1.ShowParameterPanelButton = False
    '        c.CrystalReportViewer1.ShowRefreshButton = False
    '        c.CrystalReportViewer1.ShowGroupTreeButton = False
    '        c.CrystalReportViewer1.Zoom(85)
    '        SplashScreenManager.CloseForm(False)

    '    End If
    'End Sub



    Private Sub BusinessTypeDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.MIFIRBindingSource
        Me.GridControl3.DataSource = Me.MIFIRBindingSource

        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

            rd = Me.BusinessTypeDateEdit.Text
            rdsql = rd.ToString("yyyyMMdd")

            'Load BusinessTypes Data
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load MIFIR Data for Trade Date: " & rd)
            Me.MIFIRTableAdapter.FillByTradeDate(Me.MeldewesenDataSet.MIFIR, rd)
            CHECK_EXISTING_CSV_FILE()
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If Me.XtraTabControl1.SelectedTabPage.Equals(BT_CP_XtraTabPage) Then
            ActiveTabGroup = 0
        ElseIf Me.XtraTabControl1.SelectedTabPage.Equals(BT_CP_DetailsAll_XtraTabPage) Then
            ActiveTabGroup = 1
        End If
    End Sub



    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Try
            MIFID_Treasury_Data_LayoutView.PostEditor()
            Me.Validate()
            Me.MIFIRBindingSource.EndEdit()
            Me.MIFIRTableAdapter.Update(Me.MeldewesenDataSet.MIFIR)
            '***********************************************************************
        Catch ex As Exception
            MIFID_Treasury_Data_LayoutView.HideEditor()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub
End Class