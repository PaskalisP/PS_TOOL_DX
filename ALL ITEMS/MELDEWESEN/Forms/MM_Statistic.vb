Imports System
Imports System.IO
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
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
Imports Ionic.Zip
Public Class MM_Statistic

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim ActiveTabGroup As Double = 2
    Dim MaxRepDate As Date

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim ExcelFileName As String = Nothing
    Dim AdditionalDataChecks As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim XML_CREATE As String = Nothing
    Dim XML_CREATION_FOLDER_FILE As String = Nothing
    Dim XML_LEI_SENDER As String = Nothing
    Dim XML_LEI_RECEIVER As String = Nothing
    Dim XML_BUSINESS_SERVICE As String = Nothing

    Dim BGMM_XML_file As String = Nothing
    Dim UGMM_XML_file As String = Nothing
    Dim FXSW_XML_file As String = Nothing
    Dim EORW_XML_file As String = Nothing

    Dim dir As New List(Of String)


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

    Private Function CheckElement(ByVal Xdoc As XDocument, ByVal name As XName) As Boolean
        'Return Xdoc.Descendants(name).Any()
        Return Xdoc.Descendants(XName.Get("Sts", "ns2")).FirstOrDefault
    End Function

    Private Sub MM_STATISTIC_DATEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MM_STATISTIC_DATEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)

    End Sub

    Private Sub MM_Statistic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl4.EmbeddedNavigator.ButtonClick, AddressOf GridControl4_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Get Max Date
        cmd.CommandText = "SELECT MAX([MM_Statistic_Date]) FROM [MM_STATISTIC_DATE]"
        cmd.Connection.Open()
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            MaxRepDate = cmd.ExecuteScalar
            Me.MM_STATISTIC_EORWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_EORW, MaxRepDate)
            Me.MM_STATISTIC_BGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_BGMM, MaxRepDate)
            Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, MaxRepDate)
            Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, MaxRepDate)
            Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, MaxRepDate)
            Me.ReportDateEdit.Text = MaxRepDate
        End If

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        '*******XML CREATION DIRECTORY FOLDERS************
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_CreationFolder_Directory' and  [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
        XML_CREATION_FOLDER_FILE = cmd.ExecuteScalar
        cmd.Connection.Close()

        'BG MM DEALS
        GridControl4.UseEmbeddedNavigator = True
        GridControl4.MainView = BGMM_GridView
        BGMM_GridView.ForceDoubleClick = True
        AddHandler BGMM_GridView.DoubleClick, AddressOf BGMM_GridView_DoubleClick
        AddHandler BGMM_LayoutView.MouseDown, AddressOf BGMM_LayoutView_MouseDown
        AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        BGMM_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        BGMM_LayoutView.OptionsBehavior.AllowSwitchViewModes = False


        'UG MM DEALS
        GridControl2.UseEmbeddedNavigator = True
        GridControl2.MainView = UGMM_GridView
        UGMM_GridView.ForceDoubleClick = True
        AddHandler UGMM_GridView.DoubleClick, AddressOf UGMM_GridView_DoubleClick
        AddHandler UGMM_LayoutView.MouseDown, AddressOf UGMM_LayoutView_MouseDown
        AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        UGMM_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        UGMM_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'FX SWAP
        GridControl3.UseEmbeddedNavigator = True
        GridControl3.MainView = FXSW_GridView
        FXSW_GridView.ForceDoubleClick = True
        AddHandler FXSW_GridView.DoubleClick, AddressOf FXSW_GridView_DoubleClick
        AddHandler FXSW_LayoutView.MouseDown, AddressOf FXSW_LayoutView_MouseDown
        FXSW_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        FXSW_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        'EONIA SWAP
        GridControl5.UseEmbeddedNavigator = True
        GridControl5.MainView = EORW_GridView
        EORW_GridView.ForceDoubleClick = True
        AddHandler EORW_GridView.DoubleClick, AddressOf EORW_GridView_DoubleClick
        AddHandler EORW_LayoutView.MouseDown, AddressOf EORW_LayoutView_MouseDown
        EORW_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        EORW_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        REPORT_LOCK_UNLOCK()


    End Sub

    Private Sub GridControl4_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Dim RM As Date = Me.ReportDateEdit.Text
        'If e.Button.Tag = "AddNewBG_Deal" Then
        'Try
        'Me.MM_STATISTIC_BGMMBindingSource.EndEdit()
        'GridControl4.MainView = BGMM_LayoutView
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = True
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(3).Visible = True
        'Me.MM_STATISTIC_BGMMBindingSource.AddNew()
        'Catch ex As Exception
        'XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Me.MM_STATISTIC_BGMMBindingSource.CancelEdit()
        'Me.MM_Statistic_Dataset.RejectChanges()
        'GridControl4.MainView = BGMM_GridView
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Visible = False
        'Me.GridControl4.EmbeddedNavigator.Buttons.CustomButtons.Item(3).Visible = False
        'Me.MM_STATISTIC_BGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_BGMM, RM)
        'Exit Sub
        'End Try
        'End If

    End Sub


#Region "CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            GridControl2.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = UGMM_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = UGMM_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl2.MainView Is UGMM_LayoutView)
        ElseIf ActiveTabGroup = 1 Then
            GridControl3.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = FXSW_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = FXSW_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl3.MainView Is FXSW_LayoutView)
        ElseIf ActiveTabGroup = 2 Then
            GridControl4.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = BGMM_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl4.MainView = BGMM_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl4.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl4.MainView Is BGMM_LayoutView)
        ElseIf ActiveTabGroup = 3 Then
            GridControl5.MainView.PostEditor()
            Dim datasourceRowIndex As Integer = EORW_LayoutView.GetDataSourceRowIndex(rowHandle)
            GridControl5.MainView = EORW_GridView
            SynchronizeOrdersView(datasourceRowIndex)
            GridControl5.UseEmbeddedNavigator = True
            View_Details_btn.Text = strShowExtendedMode
            fExtendedEditMode = (GridControl5.MainView Is EORW_LayoutView)
        End If

    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        If ActiveTabGroup = 0 Then
            Dim datasourceRowIndex As Integer = UGMM_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl2.MainView = UGMM_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl2.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl2.MainView Is UGMM_LayoutView)
        ElseIf ActiveTabGroup = 1 Then
            Dim datasourceRowIndex As Integer = FXSW_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl3.MainView = FXSW_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl3.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl3.MainView Is FXSW_LayoutView)
        ElseIf ActiveTabGroup = 2 Then
            Dim datasourceRowIndex As Integer = BGMM_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl4.MainView = BGMM_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl4.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl4.MainView Is BGMM_LayoutView)
        ElseIf ActiveTabGroup = 3 Then
            Dim datasourceRowIndex As Integer = EORW_GridView.GetDataSourceRowIndex(rowHandle)
            GridControl5.MainView = EORW_LayoutView
            SynchronizeOrdersDetailView(datasourceRowIndex)
            GridControl5.UseEmbeddedNavigator = True
            View_Details_btn.Text = strHideExtendedMode
            fExtendedEditMode = (GridControl5.MainView Is EORW_LayoutView)
        End If


    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = UGMM_GridView.GetRowHandle(dataSourceRowIndex)
            UGMM_GridView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = FXSW_GridView.GetRowHandle(dataSourceRowIndex)
            FXSW_GridView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 2 Then
            Dim rowHandle As Integer = BGMM_GridView.GetRowHandle(dataSourceRowIndex)
            BGMM_GridView.FocusedRowHandle = rowHandle
        ElseIf ActiveTabGroup = 3 Then
            Dim rowHandle As Integer = EORW_GridView.GetRowHandle(dataSourceRowIndex)
            EORW_GridView.FocusedRowHandle = rowHandle
        End If

    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        If ActiveTabGroup = 0 Then
            Dim rowHandle As Integer = UGMM_LayoutView.GetRowHandle(dataSourceRowIndex)
            UGMM_LayoutView.VisibleRecordIndex = UGMM_LayoutView.GetVisibleIndex(rowHandle)
            UGMM_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 1 Then
            Dim rowHandle As Integer = FXSW_LayoutView.GetRowHandle(dataSourceRowIndex)
            FXSW_LayoutView.VisibleRecordIndex = FXSW_LayoutView.GetVisibleIndex(rowHandle)
            FXSW_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 2 Then
            Dim rowHandle As Integer = BGMM_LayoutView.GetRowHandle(dataSourceRowIndex)
            BGMM_LayoutView.VisibleRecordIndex = BGMM_LayoutView.GetVisibleIndex(rowHandle)
            BGMM_LayoutView.FocusedRowHandle = dataSourceRowIndex
        ElseIf ActiveTabGroup = 3 Then
            Dim rowHandle As Integer = EORW_LayoutView.GetRowHandle(dataSourceRowIndex)
            EORW_LayoutView.VisibleRecordIndex = EORW_LayoutView.GetVisibleIndex(rowHandle)
            EORW_LayoutView.FocusedRowHandle = dataSourceRowIndex
        End If

    End Sub


    Protected Sub UGMM_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = UGMM_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub FXSW_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = FXSW_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub BGMM_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = BGMM_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub EORW_GridView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = EORW_GridView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub

    Protected Sub UGMM_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = UGMM_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub FXSW_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = FXSW_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub BGMM_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = BGMM_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub EORW_LayoutView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = EORW_LayoutView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

    Private Sub View_Details_btn_Click(sender As Object, e As EventArgs) Handles View_Details_btn.Click
        If ActiveTabGroup = 0 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            End If
        ElseIf ActiveTabGroup = 1 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl3.MainView, ColumnView)).FocusedRowHandle)
            End If
        ElseIf ActiveTabGroup = 2 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl4.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl4.MainView, ColumnView)).FocusedRowHandle)
            End If
        ElseIf ActiveTabGroup = 3 Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl5.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl5.MainView, ColumnView)).FocusedRowHandle)
            End If
        End If
    End Sub


#End Region

#Region "Default Row Styles and Print"

    Private Sub UGMM_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UGMM_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub UGMM_GridView_ShownEditor(sender As Object, e As EventArgs) Handles UGMM_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FXSW_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FXSW_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FXSW_GridView_ShownEditor(sender As Object, e As EventArgs) Handles FXSW_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BGMM_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BGMM_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BGMM_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BGMM_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub EORW_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EORW_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub EORW_GridView_ShownEditor(sender As Object, e As EventArgs) Handles EORW_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Unbesicherte Geldmarkttransaktionen" Then
            ActiveTabGroup = 0

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Devisenswaps" Then
            ActiveTabGroup = 1

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Besicherte Geldmarkttransaktionen" Then
            ActiveTabGroup = 2

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "EONIA Swaps" Then
            ActiveTabGroup = 3

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

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.UGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.UGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.UGMM_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.UGMM_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.UGMM_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.UGMM_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.UGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.UGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If


        If ActiveTabGroup = 1 Then
            If Not GridControl3.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink2.CreateDocument()
                PrintableComponentLink2.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.FXSW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.FXSW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.FXSW_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.FXSW_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.FXSW_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.FXSW_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl3, GridControl3.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.FXSW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.FXSW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If

        If ActiveTabGroup = 2 Then
            If Not GridControl4.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink3.CreateDocument()
                PrintableComponentLink3.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.BGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.BGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.BGMM_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.BGMM_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.BGMM_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.BGMM_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl4, GridControl4.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.BGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.BGMM_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
        End If

        If ActiveTabGroup = 3 Then
            If Not GridControl5.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            If View_Details_btn.Text = "View Details" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink4.CreateDocument()
                PrintableComponentLink4.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Else

                Me.EORW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.EORW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.EORW_LayoutView.OptionsPrint.PrintSelectedCardsOnly = True
                Me.EORW_LayoutView.OptionsPrint.PrintCardCaption = True
                Me.EORW_LayoutView.OptionsPrint.AllowCancelPrintExport = True
                Me.EORW_LayoutView.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(GridControl5, GridControl5.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.EORW_LayoutView.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.EORW_LayoutView.OptionsSingleRecordMode.StretchCardToViewWidth = True

            End If
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
        Dim reportfooter As String = "Unbesicherte Geldmarkttransaktionen am " & Me.ReportDateEdit.Text
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
        Dim reportfooter As String = "Devisenswaps am " & Me.ReportDateEdit.Text
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
        Dim reportfooter As String = "Besicherte Geldmarkttransaktionen am " & Me.ReportDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "EONIA Swap am " & Me.ReportDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#End Region

    Private Sub REPORT_LOCK_UNLOCK()
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
            Me.ReportLocked_CheckEdit.Text = "Report is locked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Red
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
            Me.UGMM_GridView.OptionsBehavior.Editable = False
            Me.UGMM_GridView.OptionsBehavior.ReadOnly = True
            Me.UGMM_LayoutView.OptionsBehavior.Editable = False
            Me.UGMM_LayoutView.OptionsBehavior.ReadOnly = True
            Me.FXSW_GridView.OptionsBehavior.Editable = False
            Me.FXSW_GridView.OptionsBehavior.ReadOnly = True
            Me.FXSW_LayoutView.OptionsBehavior.Editable = False
            Me.FXSW_LayoutView.OptionsBehavior.ReadOnly = True
            Me.BGMM_LayoutView.OptionsBehavior.Editable = False
            Me.BGMM_LayoutView.OptionsBehavior.ReadOnly = True
            Me.EORW_LayoutView.OptionsBehavior.Editable = False
            Me.EORW_LayoutView.OptionsBehavior.ReadOnly = True
        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.ReportLocked_CheckEdit.Text = "Report is unlocked"
            Me.ReportLocked_CheckEdit.BackColor = Color.Green
            Me.ReportLocked_CheckEdit.ForeColor = Color.White
            Me.UGMM_GridView.OptionsBehavior.Editable = True
            Me.UGMM_GridView.OptionsBehavior.ReadOnly = False
            Me.UGMM_LayoutView.OptionsBehavior.Editable = True
            Me.UGMM_LayoutView.OptionsBehavior.ReadOnly = False
            Me.FXSW_GridView.OptionsBehavior.Editable = True
            Me.FXSW_GridView.OptionsBehavior.ReadOnly = False
            Me.FXSW_LayoutView.OptionsBehavior.Editable = True
            Me.FXSW_LayoutView.OptionsBehavior.ReadOnly = False
            Me.BGMM_LayoutView.OptionsBehavior.Editable = True
            Me.BGMM_LayoutView.OptionsBehavior.ReadOnly = False
            Me.EORW_LayoutView.OptionsBehavior.Editable = True
            Me.EORW_LayoutView.OptionsBehavior.ReadOnly = False
        End If
    End Sub

#Region "MARKSEGMENTS RESULTS FORE BACK COLOR"
    Private Sub UGMM_Result_lbl_TextChanged(sender As Object, e As EventArgs) Handles UGMM_Result_lbl.TextChanged
        If Me.UGMM_Result_lbl.Text <> "0" AndAlso Me.UGMM_Result_lbl.Text <> "" Then
            Me.UGMM_Result_lbl.BackColor = Color.Green
            Me.UGMM_Result_lbl.ForeColor = Color.White
        Else
            Me.UGMM_Result_lbl.BackColor = Color.Cyan
            Me.UGMM_Result_lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BGMM_Result_lbl_TextChanged(sender As Object, e As EventArgs) Handles BGMM_Result_lbl.TextChanged
        If Me.BGMM_Result_lbl.Text <> "0" AndAlso Me.BGMM_Result_lbl.Text <> "" Then
            Me.BGMM_Result_lbl.BackColor = Color.Green
            Me.BGMM_Result_lbl.ForeColor = Color.White
        Else
            Me.BGMM_Result_lbl.BackColor = Color.Cyan
            Me.BGMM_Result_lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub FXSW_Result_lbl_TextChanged(sender As Object, e As EventArgs) Handles FXSW_Result_lbl.TextChanged
        If Me.FXSW_Result_lbl.Text <> "0" AndAlso Me.FXSW_Result_lbl.Text <> "" Then
            Me.FXSW_Result_lbl.BackColor = Color.Green
            Me.FXSW_Result_lbl.ForeColor = Color.White
        Else
            Me.FXSW_Result_lbl.BackColor = Color.Cyan
            Me.FXSW_Result_lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub EORW_Result_lbl_TextChanged(sender As Object, e As EventArgs) Handles EORW_Result_lbl.TextChanged
        If Me.EORW_Result_lbl.Text <> "0" AndAlso Me.EORW_Result_lbl.Text <> "" Then
            Me.EORW_Result_lbl.BackColor = Color.Green
            Me.EORW_Result_lbl.ForeColor = Color.White
        Else
            Me.EORW_Result_lbl.BackColor = Color.Cyan
            Me.EORW_Result_lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub UGMM_Result_Check_lbl_TextChanged(sender As Object, e As EventArgs) Handles UGMM_Result_Check_lbl.TextChanged
        If Me.UGMM_Result_Check_lbl.Text = "ACCEPTED" Then
            Me.UGMM_Result_Check_lbl.BackColor = Color.Green
            Me.UGMM_Result_Check_lbl.ForeColor = Color.White
            Me.UMS_Recreate_XML_btn.Visible = False
        ElseIf Me.UGMM_Result_Check_lbl.Text = "ACCEPTED-WARN" Then
            Me.UGMM_Result_Check_lbl.BackColor = Color.LightGreen
            Me.UGMM_Result_Check_lbl.ForeColor = Color.Black
            Me.UMS_Recreate_XML_btn.Visible = False
        ElseIf Me.UGMM_Result_Check_lbl.Text = "NOT ACCEPTED" Then
            Me.UGMM_Result_Check_lbl.BackColor = Color.Red
            Me.UGMM_Result_Check_lbl.ForeColor = Color.White
            Me.UMS_Recreate_XML_btn.Visible = True
        ElseIf Me.UGMM_Result_Check_lbl.Text = "MISSING FILE" Then
            Me.UGMM_Result_Check_lbl.BackColor = Color.Red
            Me.UGMM_Result_Check_lbl.ForeColor = Color.White
            Me.UMS_Recreate_XML_btn.Visible = False
        Else
            Me.UGMM_Result_Check_lbl.BackColor = Color.Cyan
            Me.UGMM_Result_Check_lbl.ForeColor = Color.Black
            Me.UMS_Recreate_XML_btn.Visible = False
        End If
    End Sub

    Private Sub BGMM_Result_Check_lbl_TextChanged(sender As Object, e As EventArgs) Handles BGMM_Result_Check_lbl.TextChanged
        If Me.BGMM_Result_Check_lbl.Text = "ACCEPTED" Then
            Me.BGMM_Result_Check_lbl.BackColor = Color.Green
            Me.BGMM_Result_Check_lbl.ForeColor = Color.White
        ElseIf Me.BGMM_Result_Check_lbl.Text = "ACCEPTED-WARN" Then
            Me.BGMM_Result_Check_lbl.BackColor = Color.LightGreen
            Me.BGMM_Result_Check_lbl.ForeColor = Color.Black
        ElseIf Me.BGMM_Result_Check_lbl.Text = "NOT ACCEPTED" Or Me.BGMM_Result_Check_lbl.Text = "MISSING FILE" Then
            Me.BGMM_Result_Check_lbl.BackColor = Color.Red
            Me.BGMM_Result_Check_lbl.ForeColor = Color.White
        Else
            Me.BGMM_Result_Check_lbl.BackColor = Color.Cyan
            Me.BGMM_Result_Check_lbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub FXSW_Result_Check_lbl_TextChanged(sender As Object, e As EventArgs) Handles FXSW_Result_Check_lbl.TextChanged
        If Me.FXSW_Result_Check_lbl.Text = "ACCEPTED" Then
            Me.FXSW_Result_Check_lbl.BackColor = Color.Green
            Me.FXSW_Result_Check_lbl.ForeColor = Color.White
            Me.FXS_Recreate_XML_btn.Visible = False
        ElseIf Me.FXSW_Result_Check_lbl.Text = "ACCEPTED-WARN" Then
            Me.FXSW_Result_Check_lbl.BackColor = Color.LightGreen
            Me.FXSW_Result_Check_lbl.ForeColor = Color.Black
            Me.FXS_Recreate_XML_btn.Visible = False
        ElseIf Me.FXSW_Result_Check_lbl.Text = "NOT ACCEPTED" Then
            Me.FXSW_Result_Check_lbl.BackColor = Color.Red
            Me.FXSW_Result_Check_lbl.ForeColor = Color.White
            Me.FXS_Recreate_XML_btn.Visible = True
        ElseIf Me.FXSW_Result_Check_lbl.Text = "MISSING FILE" Then
            Me.FXSW_Result_Check_lbl.BackColor = Color.Red
            Me.FXSW_Result_Check_lbl.ForeColor = Color.White
            Me.FXS_Recreate_XML_btn.Visible = False
        Else
            Me.FXSW_Result_Check_lbl.BackColor = Color.Cyan
            Me.FXSW_Result_Check_lbl.ForeColor = Color.Black
            Me.FXS_Recreate_XML_btn.Visible = False
        End If
    End Sub

    Private Sub EORW_Result_Check_lbl_TextChanged(sender As Object, e As EventArgs) Handles EORW_Result_Check_lbl.TextChanged
        If Me.EORW_Result_Check_lbl.Text = "ACCEPTED" Then
            Me.EORW_Result_Check_lbl.BackColor = Color.Green
            Me.EORW_Result_Check_lbl.ForeColor = Color.White
        ElseIf Me.EORW_Result_Check_lbl.Text = "ACCEPTED-WARN" Then
            Me.EORW_Result_Check_lbl.BackColor = Color.LightGreen
            Me.EORW_Result_Check_lbl.ForeColor = Color.Black
        ElseIf Me.EORW_Result_Check_lbl.Text = "NOT ACCEPTED" Or Me.EORW_Result_Check_lbl.Text = "MISSING FILE" Then
            Me.EORW_Result_Check_lbl.BackColor = Color.Red
            Me.EORW_Result_Check_lbl.ForeColor = Color.White
        Else
            Me.EORW_Result_Check_lbl.BackColor = Color.Cyan
            Me.EORW_Result_Check_lbl.ForeColor = Color.Black
        End If
    End Sub

#End Region

    Private Sub LoadStatisticData_btn_Click(sender As Object, e As EventArgs) Handles LoadStatisticData_btn.Click
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            'Check for missing Customer Data
            cmd.CommandText = "SELECT [DEAL_NO],[CUSTOMER],'MM DEAL' as 'Deal' FROM [OPICS_MM] where OCBS_Cust_Nr is NULL Union All SELECT [DEAL_NO],[CUSTOMER],'FX DEAL' as 'Deal' FROM OPICS_FX where OCBS_Cust_Nr is NULL"
            Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            If dt2.Rows.Count > 0 Then 'MM DEALS NO VALID
                Dim MissingCustomers As String = Nothing
                For i = 0 To dt2.Rows.Count - 1
                    MissingCustomers += dt2.Rows.Item(i).Item("DEAL_NO") & " Deal Type: " & dt2.Rows.Item(i).Item("Deal") & vbNewLine
                Next
                XtraMessageBox.Show("In the following Deals the Customer Data are missing: " & vbNewLine & vbNewLine & MissingCustomers & vbNewLine & vbNewLine & "Please first insert the missing Customer Data!!", "MISSING CUSTOMER DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading data for the MM Statistic creation")
                If IsDate(Me.ReportDateEdit.Text) = True AndAlso Weekday(Me.ReportDateEdit.Text) <> 1 AndAlso Weekday(Me.ReportDateEdit.Text) <> 7 Then
                    Dim rd As Date = Me.ReportDateEdit.Text
                    Dim rdsql As String = rd.ToString("yyyyMMdd")
                    Dim MldID As String = rd.ToString("yyMMdd")
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select Count([MM_Statistic_Date]) from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "'"
                    Dim Result As Double = cmd.ExecuteScalar
                    If Result > 0 Then
                        cmd.CommandText = "DELETE FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Cust_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from [OPICS_MM] A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Customer_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from OPICS_FX A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Customer_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from OPICS_FX_SWAPS A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [MM_STATISTIC_UGMM]([Meldepflicht],[TransactionStatus],[TransactionType],[InstrumentType],[PTI_Deal_Nr],[TradeDate],[SettlementDate],[MaturityDate],[CCY],[CCY_AMOUNT],[RateType],[DealRate],[FUNDING_RATE],[OCBS_Cust_Nr],[OCBS_Cust_Name],[ClientType],[BIC_CODE],[LEI_CODE],[Id_MM_Statistic_Date]) Select [Meldepflicht],[TransactionStatus],[TransactionType],[InstrumentType],[DEAL_NO],[TradeDate],[VALUE_DATE],[MAT_DATE],[CCY],ABS([CCY_AMOUNT]),Case when [RATE_CODE]='FIXED' then 'FIXE' else 'VARI' END,[Interest_rate],[FUNDING_RATE],[OCBS_Cust_Nr],[OCBS_Cust_Name],[ClientType],[BIC_CODE],[LEI_CODE],(Select ID from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "') FROM [OPICS_MM] where [TradeDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [MM_STATISTIC_FXSW]([Meldepflicht],[TransactionType],[TransactionStatus],[PTI_Swap_Deal_No],[TransactionCurrencyCodeEUR],[TransactionNominalAmount],[TransactionForeignCurrencyCode],[SpotRate],[SwapRate],[TradeDate],[Value_date],[MaturityDate],[SwapPoints],[OCBS_Cust_Nr],[OCBS_Customer_Name],[ClientType],[BIC_CODE],[LEI_CODE],[Id_MM_Statistic_Date])SELECT [Meldepflicht],[TransactionType],[TransactionStatus],[Swap_Deal_No],'EUR',Case when [NearLeg_CCY] in ('EUR') then ABS([NearLeg_CCY_Amount]) when [NearLeg_CTR] in ('EUR') then ABS([NearLeg_CTR_Amount]) end,Case when [NearLeg_CCY] not in ('EUR') then [NearLeg_CCY] when [NearLeg_CTR] not in ('EUR') then [NearLeg_CTR] end,[SpotRate],[SwapRate],[TradeDate],[Value_date],[MaturityDate],[SwapPoints],[OCBS_Cust_Nr],[OCBS_Customer_Name],[ClientType],[BIC_CODE],[LEI_CODE],(Select ID from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "') from [OPICS_FX_SWAPS] where TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Lösche alle nicht relevanten deals - Amount NULL
                        'cmd.CommandText = "DELETE FROM [MM_STATISTIC_FXSW] where [TransactionNominalAmount] is NULL and [TradeDate]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] set [UGMM_Result]=(Select Count(ID) from [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'),[FXSW_Result]=(Select Count(ID) from [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y') where [MM_Statistic_Date]= '" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
                        Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
                        Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)


                    Else
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Cust_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from [OPICS_MM] A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Customer_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from OPICS_FX A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A set A.[OCBS_Cust_Nr]=B.ClientNo,A.[OCBS_Customer_Name]=B.[English Name],A.[BIC_CODE]=B.BIC11,A.[LEI_CODE]=B.LEI_CODE from OPICS_FX_SWAPS A INNER JOIN CUSTOMER_INFO B on A.[OCBS_Cust_Nr]=B.ClientNo where A.TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "IF NOT EXISTS (Select [MM_Statistic_Date] from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "') INSERT INTO [MM_STATISTIC_DATE]([MM_Statistic_Date]) Values ('" & rdsql & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE]  set [BGMM_RepID]='BGMM'+ '" & MldID & "', [UGMM_RepID]='UGMM'+ '" & MldID & "',[FXSW_RepID]='FXSW'+ '" & MldID & "',[EORW_RepID]='EORW'+ '" & MldID & "' where [MM_Statistic_Date]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [MM_STATISTIC_UGMM]([Meldepflicht],[TransactionStatus],[TransactionType],[InstrumentType],[PTI_Deal_Nr],[TradeDate],[SettlementDate],[MaturityDate],[CCY],[CCY_AMOUNT],[RateType],[DealRate],[FUNDING_RATE],[OCBS_Cust_Nr],[OCBS_Cust_Name],[ClientType],[BIC_CODE],[LEI_CODE],[Id_MM_Statistic_Date]) Select [Meldepflicht],[TransactionStatus],[TransactionType],[InstrumentType],[DEAL_NO],[TradeDate],[VALUE_DATE],[MAT_DATE],[CCY],ABS([CCY_AMOUNT]),Case when [RATE_CODE]='FIXED' then 'FIXE' else 'VARI' END,[Interest_rate],[FUNDING_RATE],[OCBS_Cust_Nr],[OCBS_Cust_Name],[ClientType],[BIC_CODE],[LEI_CODE],(Select ID from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "') FROM [OPICS_MM] where [TradeDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [MM_STATISTIC_FXSW]([Meldepflicht],[TransactionType],[TransactionStatus],[PTI_Swap_Deal_No],[TransactionCurrencyCodeEUR],[TransactionNominalAmount],[TransactionForeignCurrencyCode],[SpotRate],[SwapRate],[TradeDate],[Value_date],[MaturityDate],[SwapPoints],[OCBS_Cust_Nr],[OCBS_Customer_Name],[ClientType],[BIC_CODE],[LEI_CODE],[Id_MM_Statistic_Date])SELECT [Meldepflicht],[TransactionType],[TransactionStatus],[Swap_Deal_No],'EUR',Case when [NearLeg_CCY] in ('EUR') then ABS([NearLeg_CCY_Amount]) when [NearLeg_CTR] in ('EUR') then ABS([NearLeg_CTR_Amount]) end,Case when [NearLeg_CCY] not in ('EUR') then [NearLeg_CCY] when [NearLeg_CTR] not in ('EUR') then [NearLeg_CTR] end,[SpotRate],[SwapRate],[TradeDate],[Value_date],[MaturityDate],[SwapPoints],[OCBS_Cust_Nr],[OCBS_Customer_Name],[ClientType],[BIC_CODE],[LEI_CODE],(Select ID from [MM_STATISTIC_DATE] where [MM_Statistic_Date]='" & rdsql & "') from [OPICS_FX_SWAPS] where TradeDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Lösche alle nicht relevanten deals - Amount NULL
                        'cmd.CommandText = "DELETE FROM [MM_STATISTIC_FXSW] where [TransactionNominalAmount] is NULL and [TradeDate]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] set [UGMM_Result]=(Select Count(ID) from [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'),[FXSW_Result]=(Select Count(ID) from [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y') where [MM_Statistic_Date]= '" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
                        Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
                        Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)

                    End If
                    SplashScreenManager.CloseForm(False)

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()

                    End If
                Else
                    XtraMessageBox.Show("The selected reported Date is either Sunday or Saturday!" & vbNewLine & "There's no reporting for Saturday or Sunday! ", "Wrong Date selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If
            End If

        Else

            XtraMessageBox.Show("Please unlock first the Report State!", "REPORT IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub

#Region "REPORT DATE CLICK EVENTS"
    Private Sub ReportDateEdit_Click(sender As Object, e As EventArgs) Handles ReportDateEdit.Click
        If IsDate(Me.ReportDateEdit.Text) = True Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
            Me.GridControl5.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem15.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem16.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem20.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub ReportDateEdit_Leave(sender As Object, e As EventArgs) Handles ReportDateEdit.Leave
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem15.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem16.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem20.Visibility = LayoutVisibility.Always
        Me.GridControl4.DataSource = Me.MM_STATISTIC_BGMMBindingSource
        Me.GridControl2.DataSource = Me.MM_STATISTIC_UGMMBindingSource
        Me.GridControl3.DataSource = Me.MM_STATISTIC_FXSWBindingSource
        Me.GridControl5.DataSource = Me.MM_STATISTIC_EORWBindingSource
    End Sub

    Private Sub ReportDateEdit_LostFocus(sender As Object, e As EventArgs) Handles ReportDateEdit.LostFocus
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem15.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem16.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem20.Visibility = LayoutVisibility.Always
        Me.GridControl4.DataSource = Me.MM_STATISTIC_BGMMBindingSource
        Me.GridControl2.DataSource = Me.MM_STATISTIC_UGMMBindingSource
        Me.GridControl3.DataSource = Me.MM_STATISTIC_FXSWBindingSource
        Me.GridControl5.DataSource = Me.MM_STATISTIC_EORWBindingSource
    End Sub

    Private Sub ReportDateEdit_TextChanged(sender As Object, e As EventArgs) Handles ReportDateEdit.TextChanged
        If IsDate(Me.ReportDateEdit.Text) = True Then
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem15.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem16.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem17.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem20.Visibility = LayoutVisibility.Always
            Dim rd As Date = Me.ReportDateEdit.Text
            Me.MM_STATISTIC_EORWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_EORW, rd)
            Me.MM_STATISTIC_BGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_BGMM, rd)
            Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
            Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
            Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)
            Me.GridControl2.DataSource = Me.MM_STATISTIC_UGMMBindingSource
            Me.GridControl3.DataSource = Me.MM_STATISTIC_FXSWBindingSource
            REPORT_LOCK_UNLOCK()
        End If

    End Sub
#End Region

    Private Sub ReportLocked_CheckEdit_CheckStateChanged(sender As Object, e As EventArgs) Handles ReportLocked_CheckEdit.CheckStateChanged

        Try
            REPORT_LOCK_UNLOCK()
            Me.Validate()
            Me.MM_STATISTIC_DATEBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)
            '***********************************************************************
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

#Region "UGMM Layoutview Cell Values"
    Private Sub UGMM_LayoutView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles UGMM_LayoutView.CellValueChanged
        If UGMM_LayoutView.FocusedColumn.FieldName = "CounterpartySector" Then
            'Get the currently edited value 
            Dim row As System.Data.DataRow = UGMM_LayoutView.GetDataRow(UGMM_LayoutView.FocusedRowHandle)
            Dim ID As Integer = row(0)
            Dim ClientNr As String = row(19)
            'Specify validation criteria 
            cmd.Connection.Open()
            cmd.CommandText = "UPDATE [MM_STATISTIC_UGMM] SET [CounterpartyCountryCode]=(SELECT [COUNTRY_OF_RESIDENCE] FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "') where ID='" & ID & "' "
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

        End If

    End Sub

    Private Sub UGMM_LayoutView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles UGMM_LayoutView.CellValueChanging
        If UGMM_LayoutView.FocusedColumn.FieldName = "CounterpartySector" Then
            'Get the currently edited value 
            Dim row As System.Data.DataRow = UGMM_LayoutView.GetDataRow(UGMM_LayoutView.FocusedRowHandle)
            Dim ClientNr As String = row(19)

            'Specify validation criteria 
            If ClientNr <> "" Then
                cmd.CommandText = "SELECT [COUNTRY_OF_RESIDENCE] FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    UGMM_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartyCountryCode3, dt.Rows.Item(0).Item("COUNTRY_OF_RESIDENCE"))
                Else
                    XtraMessageBox.Show("Client Nr.not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    UGMM_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartySector3, "")
                    UGMM_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartyCountryCode3, "")
                End If
            End If
        End If
    End Sub

    Private Sub CounterpartySector_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles CounterpartySector_RepositoryItemImageComboBox.EditValueChanged
        Try
            UGMM_LayoutView.PostEditor()
            Me.Validate()
            Me.MM_STATISTIC_UGMMBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)
            '***********************************************************************
        Catch ex As Exception
            UGMM_LayoutView.HideEditor()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "FXSW Layoutview Cell Values"

    Private Sub FXSW_Sector_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles FXSW_Sector_RepositoryItemImageComboBox.EditValueChanged
        Try
            FXSW_LayoutView.PostEditor()
            Me.Validate()
            Me.MM_STATISTIC_FXSWBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MM_Statistic_Dataset)
            '***********************************************************************
        Catch ex As Exception
            FXSW_LayoutView.HideEditor()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub FXSW_LayoutView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles FXSW_LayoutView.CellValueChanged
        If FXSW_LayoutView.FocusedColumn.FieldName = "CounterpartySector" Then
            'Get the currently edited value 
            Dim row As System.Data.DataRow = FXSW_LayoutView.GetDataRow(FXSW_LayoutView.FocusedRowHandle)
            Dim ID As Integer = row(0)
            Dim ClientNr As String = row(14)
            'Specify validation criteria 
            cmd.Connection.Open()
            cmd.CommandText = "UPDATE [MM_STATISTIC_FXSW] SET [CounterpartyCountryCode]=(SELECT [COUNTRY_OF_RESIDENCE] FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "') where ID='" & ID & "' "
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub FXSW_LayoutView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles FXSW_LayoutView.CellValueChanging
        If FXSW_LayoutView.FocusedColumn.FieldName = "CounterpartySector" Then
            'Get the currently edited value 
            Dim row As System.Data.DataRow = FXSW_LayoutView.GetDataRow(FXSW_LayoutView.FocusedRowHandle)
            Dim ClientNr As String = row(14)

            'Specify validation criteria 
            If ClientNr <> "" Then
                cmd.CommandText = "SELECT [COUNTRY_OF_RESIDENCE] FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    FXSW_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartyCountryCode2, dt.Rows.Item(0).Item("COUNTRY_OF_RESIDENCE"))
                Else
                    XtraMessageBox.Show("Client Nr.not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    FXSW_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartySector2, "")
                    FXSW_LayoutView.SetRowCellValue(e.RowHandle, colCounterpartyCountryCode2, "")
                End If
            End If
        End If
    End Sub

#End Region

#Region "CREATE MM STATISTIC"
    Private Sub MM_Statistic_XML_btn_Click(sender As Object, e As EventArgs) Handles MM_Statistic_XML_btn.Click
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        If Not System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) Then
            'Check for missing Customer Data
            cmd.CommandText = "SELECT [DEAL_NO],[CUSTOMER],'MM DEAL' as 'Deal' FROM [OPICS_MM] where OCBS_Cust_Nr is NULL Union All SELECT [DEAL_NO],[CUSTOMER],'FX DEAL' as 'Deal' FROM OPICS_FX where OCBS_Cust_Nr is NULL"
            Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            If dt2.Rows.Count > 0 Then 'MM DEALS NO VALID
                Dim MissingCustomers As String = Nothing
                For i = 0 To dt2.Rows.Count - 1
                    MissingCustomers += dt2.Rows.Item(i).Item("DEAL_NO") & " Deal Type: " & dt2.Rows.Item(i).Item("Deal") & vbNewLine
                Next
                XtraMessageBox.Show("In the following Deals the Customer Data are missing: " & vbNewLine & vbNewLine & MissingCustomers & vbNewLine & vbNewLine & "Please first insert the missing Customer Data!!", "MISSING CUSTOMER DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                Try
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Get the XML Creator Status
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_Creator' and [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim Result As String = cmd.ExecuteScalar
                    If Result <> "" Then
                        XML_CREATE = "Y"
                    Else
                        XML_CREATE = "N"
                    End If
                    'Get the XSD Version
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XSD_Version'  and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim XSD_VERSION As String = cmd.ExecuteScalar

                    'GET ALL OTHER PARAMETERS
                    cmd.CommandText = " SELECT [LEI_Code] from [BANK]"
                    XML_LEI_SENDER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='LEI_Receiver' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_LEI_RECEIVER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_CreationFolder_Directory' and  [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_CREATION_FOLDER_FILE = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Business_Service' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_BUSINESS_SERVICE = cmd.ExecuteScalar

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If


                    If XML_CREATE = "Y" Or SUPER_USER = "Y" Then
                        'Check if Report is unlocked
                        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
                            'Check if Markedsegments are present
                            If Me.BGMM_RepID_lbl.Text <> "" AndAlso Me.UGMM_RepID_lbl.Text <> "" AndAlso Me.FXSW_RepID_lbl.Text <> "" AndAlso Me.EORW_RepID_lbl.Text <> "" Then
                                'Check Merkedsegment results are present
                                If Me.BGMM_Result_lbl.Text <> "" AndAlso Me.UGMM_Result_lbl.Text <> "" AndAlso Me.FXSW_Result_lbl.Text <> "" AndAlso Me.EORW_Result_lbl.Text <> "" Then

                                   
                                    'Load Data for the Report Date
                                    Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
                                    Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
                                    Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)
                                    'Check Datavalidity in UNSECURED MM
                                    cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                    Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                                    Dim dt As New DataTable
                                    da.Fill(dt)
                                    If dt.Rows.Count > 0 Then 'MM DEALS NO VALID
                                        Dim NoValidMMDeals As String = Nothing
                                        For i = 0 To dt.Rows.Count - 1
                                            NoValidMMDeals += dt.Rows.Item(i).Item("PTI_Deal_Nr") & vbNewLine
                                        Next
                                        XtraMessageBox.Show("In the following MM Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidMMDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID MM DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    Else
                                        cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                        Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                                        Dim dt1 As New DataTable
                                        da1.Fill(dt1)
                                        If dt1.Rows.Count > 0 Then 'FX SWAP NO VALID
                                            Dim NoValidFXDeals As String = Nothing
                                            For i = 0 To dt1.Rows.Count - 1
                                                NoValidFXDeals += dt1.Rows.Item(i).Item("PTI_Swap_Deal_No") & vbNewLine
                                            Next
                                            XtraMessageBox.Show("In the following FX SWAP Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidFXDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID FX SWAP DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                            Exit Sub
                                        Else 'VALIDITY OK
                                            If XtraMessageBox.Show("Should the 4 XML Files for the Money Market Statistic (Geldmarktstatistik) on " & rd & " be created?", "XML GELDMARKTSTATISTIK FILES CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                'XML Folder creation
                                                Try
                                                    XML_FOLDER_CREATION()
                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_BGMM_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_BGMM_1_CREATION()
                                                    End If
                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_UGMM_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_UGMM_1_CREATION()
                                                    End If

                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_FXSW_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_FXSW_1_CREATION()
                                                    End If

                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_EORW_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_EORW_1_CREATION()
                                                    End If

                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try

                                                If XtraMessageBox.Show("The MM Statistic XML Files for reporting date " & rd & " are created in the directory" & vbNewLine _
                                                    & XML_CREATION_FOLDER_FILE & rdsql & vbNewLine & vbNewLine & "Should the directory be oppened?", "XML FILES CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                    System.Diagnostics.Process.Start(XML_CREATION_FOLDER_FILE & rdsql)
                                                End If


                                            Else
                                                Exit Sub


                                            End If
                                        End If

                                    End If

                                Else 'Markedsegements results not present
                                    XtraMessageBox.Show("Unable to create XML Files! At least one Message ID Result is not present!", "MESSAGE ID RESULTS NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If

                            Else 'Markedsegements ID not present
                                XtraMessageBox.Show("Unable to create XML Files! At least one Message ID is not present!", "MESSAGE ID NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub

                            End If
                        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
                            XtraMessageBox.Show("Unable to create XML Files! Report is locked!", "REPORT STATUS IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf XML_CREATE = "N" AndAlso SUPER_USER = "N" Then
                        XtraMessageBox.Show("User is not authorized to create the XML Files for the Geldmarktstatistik", "NO AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Else
            XtraMessageBox.Show("Unable to re-create XML Files!The related folder with the 4 XML Files are allready created!" & vbNewLine & "First delete Folder manually and then recreate Files!" & vbNewLine & vbNewLine & "ATTENTION:For any NOT ACCEPTED File please use the related button on the Segment to create a new File!!!!!!", "UNABLE TO RE-CREATE FILES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


    End Sub




    Private Sub XML_FOLDER_CREATION()

        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        If Not System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) Then
            System.IO.Directory.CreateDirectory(XML_CREATION_FOLDER_FILE & rdsql)
            'Else
            '    Directory.Delete(XML_CREATION_FOLDER_FILE & rdsql, True)
            '    System.IO.Directory.CreateDirectory(XML_CREATION_FOLDER_FILE & rdsql)
        End If

    End Sub

    Private Sub XML_BGMM_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.UTF8
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE


        'Name of the BGMM XML File
        BGMM_XML_file = "auth.012.001.01." & XML_LEI_SENDER & "." & rdsql & ".0001"

        If File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file) = True Then
            File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file)
        End If

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.BGMM_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.012.001.01")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            .WriteStartElement("message", "MnyMktScrdMktSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement()
            .WriteEndElement()
            .WriteStartElement("message", "ScrdMktRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT11auth.012.001.01")
            .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_BGMM_1_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.UTF8
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE


        'Name of the BGMM XML File
        BGMM_XML_file = "auth.012.001.02." & XML_LEI_SENDER & "." & rdsql & ".0001"

        If File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file) = True Then
            File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file)
        End If

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.BGMM_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.012.001.02")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            .WriteStartElement("message", "MnyMktScrdMktSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement()
            .WriteEndElement()
            .WriteStartElement("message", "ScrdMktRpt", "urn:iso:std:iso:20022:tech:xsd:auth.012.001.02")
            .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_UGMM_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '##### DEFINE XML FILE NAME FOR SEGMENT###########################
        Dim NextXMLnr As Integer = 0
        Dim FormatedNextXMLnr As String = Nothing
        Dim formatedNextIDnr As String = Nothing
        dir.Clear()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(XML_CREATION_FOLDER_FILE & rdsql, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "auth.013.001*")
            dir.Add(Path.GetExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & foundFile))
        Next
        If dir.Count > 0 Then
            NextXMLnr = dir.Count + 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            formatedNextIDnr = NextXMLnr.ToString("00")
            Me.UGMM_RepID_lbl.Text = "UGXX" & rd.ToString("MMdd") & formatedNextIDnr
        Else
            NextXMLnr = 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            Me.UGMM_RepID_lbl.Text = "UGMM" & rd.ToString("yyMMdd")
        End If
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_RepID]='" & Me.UGMM_RepID_lbl.Text & "' where [MM_Statistic_Date]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '###########################################################################

        'Name of the BGMM XML File
        UGMM_XML_file = "auth.013.001.01." & XML_LEI_SENDER & "." & rdsql & "." & FormatedNextXMLnr

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & UGMM_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.UGMM_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.013.001.01")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:Document>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01")
            .WriteStartElement("message", "MnyMktUscrdMktSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:MnyMktUscrdMktSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End <Message:RefPrd>
            .WriteEndElement() 'End <Message:RptHdr>
            .WriteStartElement("message", "UscrdMktRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:UscrdMktRpt>
            'Prüfung ob daten vorhanden
            cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then 'MM DEALS PRESENT
                'LEI CODE PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt1.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt1.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "PrtryTxId", Nothing, dt1.Rows.Item(i).Item("PTI_Deal_Nr"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:CtrPtyId>
                        .WriteElementString("message", "LEI", Nothing, dt1.Rows.Item(i).Item("LEI_CODE"))
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SttlmDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("SettlementDate")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt1.Rows.Item(i).Item("TransactionType"))
                        .WriteElementString("message", "InstrmTp", Nothing, dt1.Rows.Item(i).Item("InstrumentType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt1.Rows.Item(i).Item("CCY"))
                        .WriteValue(dt1.Rows.Item(i).Item("CCY_AMOUNT"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteElementString("message", "DealPric", Nothing, dt1.Rows.Item(i).Item("TransactionDealPrice"))
                        .WriteElementString("message", "RateTp", Nothing, dt1.Rows.Item(i).Item("RateType"))
                        If dt1.Rows.Item(i).Item("RateType").ToString = "FIXE" Then
                            .WriteStartElement("message", "DealRate", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:DealRate>
                            If CDbl(dt1.Rows.Item(i).Item("DealRate")) > 0 Then
                                .WriteElementString("message", "Sgn", Nothing, "true")
                            ElseIf CDbl(dt1.Rows.Item(i).Item("DealRate")) < 0 Then
                                .WriteElementString("message", "Sgn", Nothing, "false")
                            End If
                            .WriteElementString("message", "Rate", Nothing, Math.Abs(dt1.Rows.Item(i).Item("DealRate")).ToString.Replace(",", "."))
                            .WriteEndElement() 'End <Message:DealRate>
                        ElseIf dt1.Rows.Item(i).Item("RateType").ToString = "VARI" Then
                            .WriteStartElement("message", "FltgRateNote", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:FltgRateNote>
                            .WriteElementString("message", "RefRateIndx", Nothing, dt1.Rows.Item(i).Item("ReferenceRateIndex"))
                            .WriteElementString("message", "BsisPtSprd", Nothing, String.Format("{0:#0}", dt1.Rows.Item(i).Item("BasisPointSpread").ToString.Replace(",", ".")))
                            .WriteEndElement() 'End <Message:FltgRateNote>
                        End If
                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

                'LEI CODE NOT PRESENT - COUNTERPARTY SECTOR PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is not NULL"
                Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt2 As New DataTable
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt2.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt2.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "PrtryTxId", Nothing, dt2.Rows.Item(i).Item("PTI_Deal_Nr"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:CtrPtyId>
                        .WriteStartElement("message", "Othr", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:Othr>
                        .WriteElementString("message", "Sctr", Nothing, dt2.Rows.Item(i).Item("CounterpartySector"))
                        .WriteElementString("message", "Lctn", Nothing, LTrim(RTrim(dt2.Rows.Item(i).Item("CounterpartyCountryCode"))))
                        .WriteEndElement() 'End <Message:Othr>
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SttlmDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("SettlementDate")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt2.Rows.Item(i).Item("TransactionType"))
                        .WriteElementString("message", "InstrmTp", Nothing, dt2.Rows.Item(i).Item("InstrumentType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt2.Rows.Item(i).Item("CCY"))
                        .WriteValue(dt2.Rows.Item(i).Item("CCY_AMOUNT"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteElementString("message", "DealPric", Nothing, dt2.Rows.Item(i).Item("TransactionDealPrice"))
                        .WriteElementString("message", "RateTp", Nothing, dt2.Rows.Item(i).Item("RateType"))
                        If dt2.Rows.Item(i).Item("RateType").ToString = "FIXE" Then
                            .WriteStartElement("message", "DealRate", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:DealRate>
                            If CDbl(dt2.Rows.Item(i).Item("DealRate")) > 0 Then
                                .WriteElementString("message", "Sgn", Nothing, "true")
                            ElseIf CDbl(dt2.Rows.Item(i).Item("DealRate")) < 0 Then
                                .WriteElementString("message", "Sgn", Nothing, "false")
                            End If
                            .WriteElementString("message", "Rate", Nothing, Math.Abs(dt2.Rows.Item(i).Item("DealRate")).ToString.Replace(",", "."))
                            .WriteEndElement() 'End <Message:DealRate>
                        ElseIf dt2.Rows.Item(i).Item("RateType").ToString = "VARI" Then
                            .WriteStartElement("message", "FltgRateNote", "urn:iso:std:iso:20022:tech:xsd:DRAFT10auth.013.001.01") 'Start <Message:FltgRateNote>
                            .WriteElementString("message", "RefRateIndx", Nothing, dt2.Rows.Item(i).Item("ReferenceRateIndex"))
                            .WriteElementString("message", "BsisPtSprd", Nothing, String.Format("{0:#0}", dt2.Rows.Item(i).Item("BasisPointSpread").ToString.Replace(",", ".")))
                            .WriteEndElement() 'End <Message:FltgRateNote>
                        End If
                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

            Else 'NO MM DEALS FOR REPORTING
                .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            End If


            '##############################
            .WriteEndElement() 'End <Message:UscrdMktRpt>
            .WriteEndElement() 'End <Message:MnyMktUscrdMktSttstclRpt>
            .WriteEndElement() 'End <Message:Document>
            .WriteEndElement() 'End <WRAPPER>
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_UGMM_1_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '##### DEFINE XML FILE NAME FOR SEGMENT###########################
        Dim NextXMLnr As Integer = 0
        Dim FormatedNextXMLnr As String = Nothing
        Dim formatedNextIDnr As String = Nothing
        dir.Clear()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(XML_CREATION_FOLDER_FILE & rdsql, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "auth.013.001*")
            dir.Add(Path.GetExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & foundFile))
        Next
        If dir.Count > 0 Then
            NextXMLnr = dir.Count + 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            formatedNextIDnr = NextXMLnr.ToString("00")
            Me.UGMM_RepID_lbl.Text = "UGXX" & rd.ToString("MMdd") & formatedNextIDnr
        Else
            NextXMLnr = 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            Me.UGMM_RepID_lbl.Text = "UGMM" & rd.ToString("yyMMdd")
        End If
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_RepID]='" & Me.UGMM_RepID_lbl.Text & "' where [MM_Statistic_Date]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '###########################################################################

        'Name of the BGMM XML File
        UGMM_XML_file = "auth.013.001.02." & XML_LEI_SENDER & "." & rdsql & "." & FormatedNextXMLnr

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & UGMM_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.UGMM_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.013.001.02")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:Document>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02")
            .WriteStartElement("message", "MnyMktUscrdMktSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:MnyMktUscrdMktSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End <Message:RefPrd>
            .WriteEndElement() 'End <Message:RptHdr>
            .WriteStartElement("message", "UscrdMktRpt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:UscrdMktRpt>
            'Prüfung ob daten vorhanden
            cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then 'MM DEALS PRESENT
                'LEI CODE PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt1.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt1.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "NvtnSts", Nothing, "NONO") 'NOVATION STATUS
                        .WriteElementString("message", "PrtryTxId", Nothing, dt1.Rows.Item(i).Item("PTI_Deal_Nr"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:CtrPtyId>
                        .WriteElementString("message", "LEI", Nothing, dt1.Rows.Item(i).Item("LEI_CODE"))
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SttlmDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("SettlementDate")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt1.Rows.Item(i).Item("TransactionType"))
                        .WriteElementString("message", "InstrmTp", Nothing, dt1.Rows.Item(i).Item("InstrumentType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt1.Rows.Item(i).Item("CCY"))
                        .WriteValue(dt1.Rows.Item(i).Item("CCY_AMOUNT"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteElementString("message", "DealPric", Nothing, dt1.Rows.Item(i).Item("TransactionDealPrice"))
                        .WriteElementString("message", "RateTp", Nothing, dt1.Rows.Item(i).Item("RateType"))
                        If dt1.Rows.Item(i).Item("RateType").ToString = "FIXE" Then
                            .WriteElementString("message", "DealRate", Nothing, Math.Abs(dt1.Rows.Item(i).Item("DealRate")).ToString.Replace(",", "."))
                        ElseIf dt1.Rows.Item(i).Item("RateType").ToString = "VARI" Then
                            .WriteStartElement("message", "FltgRateNote", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:FltgRateNote>
                            .WriteElementString("message", "RefRateIndx", Nothing, dt1.Rows.Item(i).Item("ReferenceRateIndex"))
                            .WriteElementString("message", "BsisPtSprd", Nothing, String.Format("{0:#0}", dt1.Rows.Item(i).Item("BasisPointSpread").ToString.Replace(",", ".")))
                            .WriteEndElement() 'End <Message:FltgRateNote>
                        End If
                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

                'LEI CODE NOT PRESENT - COUNTERPARTY SECTOR PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is not NULL"
                Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt2 As New DataTable
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt2.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt2.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "NvtnSts", Nothing, "NONO") 'NOVATION STATUS
                        .WriteElementString("message", "PrtryTxId", Nothing, dt2.Rows.Item(i).Item("PTI_Deal_Nr"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:CtrPtyId>
                        .WriteStartElement("message", "SctrAndLctn", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:SctrAndLctn>
                        .WriteElementString("message", "Sctr", Nothing, dt2.Rows.Item(i).Item("CounterpartySector"))
                        .WriteElementString("message", "Lctn", Nothing, LTrim(RTrim(dt2.Rows.Item(i).Item("CounterpartyCountryCode"))))
                        .WriteEndElement() 'End <Message:Othr>
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SttlmDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("SettlementDate")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt2.Rows.Item(i).Item("TransactionType"))
                        .WriteElementString("message", "InstrmTp", Nothing, dt2.Rows.Item(i).Item("InstrumentType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt2.Rows.Item(i).Item("CCY"))
                        .WriteValue(dt2.Rows.Item(i).Item("CCY_AMOUNT"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteElementString("message", "DealPric", Nothing, dt2.Rows.Item(i).Item("TransactionDealPrice"))
                        .WriteElementString("message", "RateTp", Nothing, dt2.Rows.Item(i).Item("RateType"))
                        If dt2.Rows.Item(i).Item("RateType").ToString = "FIXE" Then
                            .WriteElementString("message", "DealRate", Nothing, Math.Abs(dt1.Rows.Item(i).Item("DealRate")).ToString.Replace(",", "."))
                        ElseIf dt2.Rows.Item(i).Item("RateType").ToString = "VARI" Then
                            .WriteStartElement("message", "FltgRateNote", "urn:iso:std:iso:20022:tech:xsd:auth.013.001.02") 'Start <Message:FltgRateNote>
                            .WriteElementString("message", "RefRateIndx", Nothing, dt2.Rows.Item(i).Item("ReferenceRateIndex"))
                            .WriteElementString("message", "BsisPtSprd", Nothing, String.Format("{0:#0}", dt2.Rows.Item(i).Item("BasisPointSpread").ToString.Replace(",", ".")))
                            .WriteEndElement() 'End <Message:FltgRateNote>
                        End If
                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

            Else 'NO MM DEALS FOR REPORTING
                .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            End If


            '##############################
            .WriteEndElement() 'End <Message:UscrdMktRpt>
            .WriteEndElement() 'End <Message:MnyMktUscrdMktSttstclRpt>
            .WriteEndElement() 'End <Message:Document>
            .WriteEndElement() 'End <WRAPPER>
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_FXSW_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '##### DEFINE XML FILE NAME FOR SEGMENT###########################
        Dim NextXMLnr As Integer = 0
        Dim FormatedNextXMLnr As String = Nothing
        Dim formatedNextIDnr As String = Nothing
        dir.Clear()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(XML_CREATION_FOLDER_FILE & rdsql, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "auth.014.001*")
            dir.Add(Path.GetExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & foundFile))
        Next
        If dir.Count > 0 Then
            NextXMLnr = dir.Count + 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            formatedNextIDnr = NextXMLnr.ToString("00")
            Me.FXSW_RepID_lbl.Text = "FXWS" & rd.ToString("MMdd") & formatedNextIDnr
        Else
            NextXMLnr = 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            Me.FXSW_RepID_lbl.Text = "FXSW" & rd.ToString("yyMMdd")
        End If
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_RepID]='" & Me.FXSW_RepID_lbl.Text & "' where [MM_Statistic_Date]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '###########################################################################

        'Name of the BGMM XML File
        FXSW_XML_file = "auth.014.001.01." & XML_LEI_SENDER & "." & rdsql & "." & FormatedNextXMLnr

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & FXSW_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.FXSW_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.014.001.01")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:Document>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01")
            .WriteStartElement("message", "MnyMktFXSwpsSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:MnyMktFXSwpsSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End <Message:RefPrd>
            .WriteEndElement() 'End <Message:RptHdr>
            .WriteStartElement("message", "FXSwpsRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:FXSwpsRpt>
            'Prüfung ob daten vorhanden
            cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then 'MM DEALS PRESENT
                'LEI CODE PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt1.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt1.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "PrtryTxId", Nothing, dt1.Rows.Item(i).Item("PTI_Swap_Deal_No"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:CtrPtyId>
                        .WriteElementString("message", "LEI", Nothing, dt1.Rows.Item(i).Item("LEI_CODE"))
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SpotValDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("Value_date")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt1.Rows.Item(i).Item("TransactionType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt1.Rows.Item(i).Item("TransactionCurrencyCodeEUR"))
                        .WriteValue(dt1.Rows.Item(i).Item("TransactionNominalAmount"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteStartElement("message", "FX", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:FX>
                        .WriteElementString("message", "FrgnCcy", Nothing, dt1.Rows.Item(i).Item("TransactionForeignCurrencyCode"))
                        .WriteElementString("message", "XchgSpotRate", Nothing, dt1.Rows.Item(i).Item("SpotRate").ToString.Replace(",", "."))
                        .WriteElementString("message", "XchgFwdPt", Nothing, dt1.Rows.Item(i).Item("SwapPoints").ToString.Replace(",", "."))
                        .WriteEndElement() 'End <Message:FX>

                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

                'LEI CODE NOT PRESENT - COUNTERPARTY SECTOR PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is not NULL"
                Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt2 As New DataTable
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt2.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt2.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "PrtryTxId", Nothing, dt2.Rows.Item(i).Item("PTI_Swap_Deal_No"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:CtrPtyId>
                        .WriteStartElement("message", "Othr", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:Othr>
                        .WriteElementString("message", "Sctr", Nothing, dt2.Rows.Item(i).Item("CounterpartySector"))
                        .WriteElementString("message", "Lctn", Nothing, LTrim(RTrim(dt2.Rows.Item(i).Item("CounterpartyCountryCode"))))
                        .WriteEndElement() 'End <Message:Othr>
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SpotValDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("Value_date")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt2.Rows.Item(i).Item("TransactionType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt2.Rows.Item(i).Item("TransactionCurrencyCodeEUR"))
                        .WriteValue(dt2.Rows.Item(i).Item("TransactionNominalAmount"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteStartElement("message", "FX", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.014.001.01") 'Start <Message:FX>
                        .WriteElementString("message", "FrgnCcy", Nothing, dt2.Rows.Item(i).Item("TransactionForeignCurrencyCode"))
                        .WriteElementString("message", "XchgSpotRate", Nothing, dt2.Rows.Item(i).Item("SpotRate").ToString.Replace(",", "."))
                        .WriteElementString("message", "XchgFwdPt", Nothing, dt2.Rows.Item(i).Item("SwapPoints").ToString.Replace(",", "."))
                        .WriteEndElement() 'End <Message:FX>

                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

            Else 'NO MM DEALS FOR REPORTING
                .WriteElementString("message", "DataSetActn", Nothing, "NOTX")

            End If

            '##############################
            .WriteEndElement() 'End <Message:FXSwpsRpt>
            .WriteEndElement() 'End <Message:MnyMktFXSwpsSttstclRpt>
            .WriteEndElement() 'End <Message:Document>
            .WriteEndElement() 'End <WRAPPER>
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_FXSW_1_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '##### DEFINE XML FILE NAME FOR SEGMENT###########################
        Dim NextXMLnr As Integer = 0
        Dim FormatedNextXMLnr As String = Nothing
        Dim formatedNextIDnr As String = Nothing
        dir.Clear()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(XML_CREATION_FOLDER_FILE & rdsql, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "auth.014.001*")
            dir.Add(Path.GetExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & foundFile))
        Next
        If dir.Count > 0 Then
            NextXMLnr = dir.Count + 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            formatedNextIDnr = NextXMLnr.ToString("00")
            Me.FXSW_RepID_lbl.Text = "FXWS" & rd.ToString("MMdd") & formatedNextIDnr
        Else
            NextXMLnr = 1
            FormatedNextXMLnr = NextXMLnr.ToString("0000")
            Me.FXSW_RepID_lbl.Text = "FXSW" & rd.ToString("yyMMdd")
        End If
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_RepID]='" & Me.FXSW_RepID_lbl.Text & "' where [MM_Statistic_Date]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '###########################################################################

        'Name of the BGMM XML File
        FXSW_XML_file = "auth.014.001.02." & XML_LEI_SENDER & "." & rdsql & "." & FormatedNextXMLnr

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & FXSW_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.FXSW_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.014.001.02")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:Document>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02")
            .WriteStartElement("message", "MnyMktFXSwpsSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:MnyMktFXSwpsSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End <Message:RefPrd>
            .WriteEndElement() 'End <Message:RptHdr>
            .WriteStartElement("message", "FXSwpsRpt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:FXSwpsRpt>
            'Prüfung ob daten vorhanden
            cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then 'MM DEALS PRESENT
                'LEI CODE PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is not NULL"
                Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt1 As New DataTable
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt1.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt1.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "NvtnSts", Nothing, "NONO") 'NOVATION STATUS
                        .WriteElementString("message", "PrtryTxId", Nothing, dt1.Rows.Item(i).Item("PTI_Swap_Deal_No"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:CtrPtyId>
                        .WriteElementString("message", "LEI", Nothing, dt1.Rows.Item(i).Item("LEI_CODE"))
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SpotValDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("Value_date")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt1.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt1.Rows.Item(i).Item("TransactionType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt1.Rows.Item(i).Item("TransactionCurrencyCodeEUR"))
                        .WriteValue(dt1.Rows.Item(i).Item("TransactionNominalAmount"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteStartElement("message", "FX", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:FX>
                        .WriteElementString("message", "FrgnCcy", Nothing, dt1.Rows.Item(i).Item("TransactionForeignCurrencyCode"))
                        .WriteElementString("message", "XchgSpotRate", Nothing, dt1.Rows.Item(i).Item("SpotRate").ToString.Replace(",", "."))
                        .WriteElementString("message", "XchgFwdPt", Nothing, dt1.Rows.Item(i).Item("SwapPoints").ToString.Replace(",", "."))
                        .WriteEndElement() 'End <Message:FX>

                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

                'LEI CODE NOT PRESENT - COUNTERPARTY SECTOR PRESENT
                cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is not NULL"
                Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt2 As New DataTable
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then 'LEI CODE PRESENT
                    For i = 0 To dt2.Rows.Count - 1
                        .WriteStartElement("message", "Tx", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:Tx>
                        .WriteElementString("message", "RptdTxSts", Nothing, dt2.Rows.Item(i).Item("TransactionStatus"))
                        .WriteElementString("message", "NvtnSts", Nothing, "NONO") 'NOVATION STATUS
                        .WriteElementString("message", "PrtryTxId", Nothing, dt2.Rows.Item(i).Item("PTI_Swap_Deal_No"))
                        .WriteStartElement("message", "CtrPtyId", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:CtrPtyId>
                        .WriteStartElement("message", "SctrAndLctn", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:SctrAndLctn>
                        .WriteElementString("message", "Sctr", Nothing, dt2.Rows.Item(i).Item("CounterpartySector"))
                        .WriteElementString("message", "Lctn", Nothing, LTrim(RTrim(dt2.Rows.Item(i).Item("CounterpartyCountryCode"))))
                        .WriteEndElement() 'End <Message:Othr>
                        .WriteEndElement() 'End <Message:CtrPtyId>
                        .WriteStartElement("message", "TradDt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:TradDt>
                        .WriteElementString("message", "Dt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("TradeDate")))
                        .WriteEndElement() 'End <Message:TradDt>
                        .WriteElementString("message", "SpotValDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("Value_date")))
                        .WriteElementString("message", "MtrtyDt", Nothing, String.Format("{0:yyyy-MM-dd}", dt2.Rows.Item(i).Item("MaturityDate")))
                        .WriteElementString("message", "TxTp", Nothing, dt2.Rows.Item(i).Item("TransactionType"))
                        .WriteStartElement("message", "TxNmnlAmt", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:TxNmnlAmt>
                        .WriteAttributeString("Ccy", dt2.Rows.Item(i).Item("TransactionCurrencyCodeEUR"))
                        .WriteValue(dt2.Rows.Item(i).Item("TransactionNominalAmount"))
                        .WriteEndElement() 'End <Message:TxNmnlAmt>
                        .WriteStartElement("message", "FX", "urn:iso:std:iso:20022:tech:xsd:auth.014.001.02") 'Start <Message:FX>
                        .WriteElementString("message", "FrgnCcy", Nothing, dt2.Rows.Item(i).Item("TransactionForeignCurrencyCode"))
                        .WriteElementString("message", "XchgSpotRate", Nothing, dt2.Rows.Item(i).Item("SpotRate").ToString.Replace(",", "."))
                        .WriteElementString("message", "XchgFwdPt", Nothing, dt2.Rows.Item(i).Item("SwapPoints").ToString.Replace(",", "."))
                        .WriteEndElement() 'End <Message:FX>

                        .WriteEndElement() 'End <Message:Tx>
                    Next
                End If

            Else 'NO MM DEALS FOR REPORTING
                .WriteElementString("message", "DataSetActn", Nothing, "NOTX")

            End If

            '##############################
            .WriteEndElement() 'End <Message:FXSwpsRpt>
            .WriteEndElement() 'End <Message:MnyMktFXSwpsSttstclRpt>
            .WriteEndElement() 'End <Message:Document>
            .WriteEndElement() 'End <WRAPPER>
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_EORW_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        'Name of the BGMM XML File
        EORW_XML_file = "auth.015.001.01." & XML_LEI_SENDER & "." & rdsql & ".0001"

        If File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file) = True Then
            File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file)
        End If

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.EORW_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.015.001.01")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01") 'Start <Message:Documents>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01")
            .WriteStartElement("message", "MnyMktOvrnghtIndxSwpsSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01") 'Start <Message:MnyMktOvrnghtIndxSwpsSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End Element <Message:RefPrd>
            .WriteEndElement() 'End Element <Message:RptHdr>
            .WriteStartElement("message", "OvrnghtIndxSwpsRpt", "urn:iso:std:iso:20022:tech:xsd:DRAFT9auth.015.001.01") 'Start <Message:OvrnghtIndxSwpsRpt>
            .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            .WriteEndElement() 'End Element <Message:OvrnghtIndxSwpsRpt>
            .WriteEndElement() 'End Element <Message:MnyMktOvrnghtIndxSwpsSttstclRpt>
            .WriteEndElement() 'End Element <Message:Documents>
            .WriteEndElement() ' End Element WRAPPER
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

    Private Sub XML_EORW_1_CREATION()
        'XML DATEI erstellungsdatum un Zeitdefinieren
        Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        Dim rdsqlXML As String = rd.ToString("yyyy-MM-dd")
        'MELDETERMIN
        'Dim MeldeIddatm As Date = DateSerial(Me.ZvStatMeldejahr_Comboboxedit.Text, 12, 31)
        'Dim MELDETERMIN As String = Me.ZvStatMeldejahr_Comboboxedit.Text & "-12"
        'Dim XMLMELDETERMIN As String = MeldeIddatm.ToString("yy") & "12"

        Dim MyWriter As System.Xml.XmlWriter
        Dim MySettings As New System.Xml.XmlWriterSettings
        MySettings.Indent = True
        MySettings.ConformanceLevel = Xml.ConformanceLevel.Auto
        MySettings.IndentChars = "    "

        MySettings.NewLineOnAttributes = False
        MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")
        MySettings.Encoding = New UpperCaseUTF8Encoding ' UTF-8 in UPPER CASE

        'Name of the BGMM XML File
        EORW_XML_file = "auth.015.001.02." & XML_LEI_SENDER & "." & rdsql & ".0001"

        If File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file) = True Then
            File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file)
        End If

        MyWriter = System.Xml.XmlWriter.Create(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_XML_file, MySettings)

        With MyWriter
            'urn:iso:std:iso:20022:tech:xsd:head.003.001.01
            .WriteStartDocument()
            .WriteStartElement("wrapper", "MMSRMessage", "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "wrapper", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01")
            .WriteAttributeString("xsi", "schemaLocation", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.003.001.01 MMSR_head.003.001.01_Wrapper.xsd")

            'ELEMENT-Header
            .WriteStartElement("header", "AppHdr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "header", Nothing, "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Fr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_SENDER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            'Header to
            .WriteStartElement("header", "To", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Id", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "OrgId", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteStartElement("header", "Othr", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Id", Nothing, XML_LEI_RECEIVER)
            .WriteStartElement("header", "SchmeNm", "urn:iso:std:iso:20022:tech:xsd:head.001.001.01")
            .WriteElementString("header", "Cd", Nothing, "LEI")
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()
            .WriteEndElement()

            .WriteElementString("header", "BizMsgIdr", Nothing, Me.EORW_RepID_lbl.Text) 'Fortlaufende Nr
            .WriteElementString("header", "MsgDefIdr", Nothing, "auth.015.001.02")
            .WriteElementString("header", "BizSvc", Nothing, XML_BUSINESS_SERVICE)
            .WriteElementString("header", "CreDt", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "Z")

            .WriteEndElement() 'End Element Header

            .WriteStartElement("message", "Document", "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02") 'Start <Message:Documents>
            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xmlns", "message", Nothing, "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02")
            .WriteStartElement("message", "MnyMktOvrnghtIndxSwpsSttstclRpt", "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02") 'Start <Message:MnyMktOvrnghtIndxSwpsSttstclRpt>
            .WriteStartElement("message", "RptHdr", "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02") 'Start <Message:RptHdr>
            .WriteElementString("message", "RptgAgt", Nothing, XML_LEI_SENDER)
            .WriteStartElement("message", "RefPrd", "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02") 'Start <Message:RefPrd>
            If GMTDiff(rd) = 2 Then 'SOMMERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+02:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+02:00")
            Else 'WINTERZEIT
                .WriteElementString("message", "FrDtTm", Nothing, rdsqlXML & "T00:00:00+01:00")
                .WriteElementString("message", "ToDtTm", Nothing, rdsqlXML & "T04:00:00+01:00")
            End If
            .WriteEndElement() 'End Element <Message:RefPrd>
            .WriteEndElement() 'End Element <Message:RptHdr>
            .WriteStartElement("message", "OvrnghtIndxSwpsRpt", "urn:iso:std:iso:20022:tech:xsd:auth.015.001.02") 'Start <Message:OvrnghtIndxSwpsRpt>
            .WriteElementString("message", "DataSetActn", Nothing, "NOTX")
            .WriteEndElement() 'End Element <Message:OvrnghtIndxSwpsRpt>
            .WriteEndElement() 'End Element <Message:MnyMktOvrnghtIndxSwpsSttstclRpt>
            .WriteEndElement() 'End Element <Message:Documents>
            .WriteEndElement() ' End Element WRAPPER
            '##############################


            '++++++++++++++++++++++++++++++++++
            .WriteEndDocument()
            .Close()

        End With
    End Sub

#End Region

    Private Sub MM_Statistic_CrystalRep_btn_Click(sender As Object, e As EventArgs) Handles MM_Statistic_CrystalRep_btn.Click
        Dim RM As Date = Me.ReportDateEdit.Text
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Money Market Statistic Report for " & RM)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\MM_STATISTIC.rpt")
        CrRep.SetDataSource(MM_Statistic_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = RM
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Money Market Statistic Report " & RM
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub OpenFilesFolder_btn_Click(sender As Object, e As EventArgs) Handles OpenFilesFolder_btn.Click
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        If Not System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) Then
            XtraMessageBox.Show("The Folder: " & XML_CREATION_FOLDER_FILE & rdsql & " does not exist!!" & vbNewLine & "Please first create the XML Files!", "FOLDER NOT EXISTING", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            System.Diagnostics.Process.Start(XML_CREATION_FOLDER_FILE & rdsql)
        End If
    End Sub



    Private Sub AdditionalDataChecks_btn_Click(sender As Object, e As EventArgs) Handles AdditionalDataChecks_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='ADDITIONAL_DATA_QUALITY_CHECKS_FORM' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
            AdditionalDataChecks = cmd.ExecuteScalar
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            System.Diagnostics.Process.Start(AdditionalDataChecks)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try


    End Sub

    Private Sub ReportResultscheck_btn_Click(sender As Object, e As EventArgs) Handles ReportResultscheck_btn.Click
        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim rd As Date = Me.ReportDateEdit.Text
            Dim rdsql As String = rd.ToString("yyyyMMdd")

            'files to be checked
            Dim BGMM_Result_Check As String = Nothing
            Dim UGMM_Result_Check As String = Nothing
            Dim FXSW_Result_Check As String = Nothing
            Dim EORW_Result_Check As String = Nothing

            dir.Clear()
            If System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) = True Then
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(XML_CREATION_FOLDER_FILE & rdsql, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.zip")
                    dir.Add(Path.GetFileNameWithoutExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & foundFile))
                Next
                If dir.Count > 0 Then
                    For i = 0 To dir.Count - 1
                        BGMM_Result_Check = dir.Find(Function(p) p.Contains("auth.012.001"))
                        UGMM_Result_Check = dir.Find(Function(p) p.Contains("auth.013.001"))
                        FXSW_Result_Check = dir.Find(Function(p) p.Contains("auth.014.001"))
                        EORW_Result_Check = dir.Find(Function(p) p.Contains("auth.015.001"))
                    Next
                End If
            End If

            'MsgBox(BGMM_Result_Check & vbNewLine & UGMM_Result_Check & vbNewLine & FXSW_Result_Check & vbNewLine & EORW_Result_Check)

            'If rd < DateSerial(2018, 6, 29) Then
            '    BGMM_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.012.001.01"
            '    UGMM_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.013.001.01"
            '    FXSW_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.014.001.01"
            '    EORW_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.015.001.01"
            'ElseIf rd >= DateSerial(2018, 6, 29) Then
            '    BGMM_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.012.001.02"
            '    UGMM_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.013.001.02"
            '    FXSW_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.014.001.02"
            '    EORW_Result_Check = "auth.028.001.01.5493001KQW6DM7KEDR62." & rdsql & ".0001.auth.015.001.02"
            'End If



            If System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) = True Then
                Dim di As New DirectoryInfo(XML_CREATION_FOLDER_FILE & rdsql)
                Dim fiArr As FileInfo() = di.GetFiles()
                Dim fri As FileInfo
                For Each fri In fiArr

                    If fri.Name.StartsWith("auth.028.001") = True And fri.Extension = ".zip" Then
                        'MsgBox(fri.FullName)
                        Using zip As ZipFile = ZipFile.Read(XML_CREATION_FOLDER_FILE & rdsql & "\" & fri.Name)
                            Dim z As ZipEntry
                            For Each z In zip
                                z.Extract(XML_CREATION_FOLDER_FILE & rdsql, ExtractExistingFileAction.OverwriteSilently)
                            Next
                        End Using
                    End If

                    Dim FileResult As String = Path.GetFileNameWithoutExtension(XML_CREATION_FOLDER_FILE & rdsql & "\" & fri.Name)

                    'MsgBox(FileResult & vbNewLine & BGMM_Result_Check)

                    If FileResult = BGMM_Result_Check Then

                        Dim doc As XmlDocument = New XmlDocument()
                        doc.Load(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_Result_Check)
                        'MsgBox(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_Result_Check)
                        Dim elemList As XmlNodeList = doc.GetElementsByTagName("ns2:RptSts")
                        Dim i As Integer
                        For i = 0 To elemList.Count - 1
                            'MsgBox(elemList(i).InnerXml)
                        Next i

                        Dim REPORT_RESULT As String = elemList(0).InnerXml
                        Dim WARNING_RESULT As String = Nothing

                        If REPORT_RESULT = "ACPT" Then
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [BGMM_Result_Check]='ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Dim alltext As String = doc.InnerXml
                            If alltext.Contains("<ns2:Sts>WARN</ns2:Sts>") = True Then
                                cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [BGMM_Result_Check]='ACCEPTED-WARN' where [MM_Statistic_Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [BGMM_Result_Check]='NOT ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                        End If

                    ElseIf FileResult = UGMM_Result_Check Then
                        Dim doc As XmlDocument = New XmlDocument()
                        doc.Load(XML_CREATION_FOLDER_FILE & rdsql & "\" & UGMM_Result_Check)
                        Dim elemList As XmlNodeList = doc.GetElementsByTagName("ns2:RptSts")

                        Dim i As Integer
                        For i = 0 To elemList.Count - 1
                            'MsgBox(elemList(i).InnerXml)
                        Next i
                        Dim REPORT_RESULT As String = elemList(0).InnerXml
                        Dim WARNING_RESULT As String = Nothing

                        If REPORT_RESULT = "ACPT" Then
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_Result_Check]='ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Dim alltext As String = doc.InnerXml
                            If alltext.Contains("<ns2:Sts>WARN</ns2:Sts>") = True Then
                                cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_Result_Check]='ACCEPTED-WARN' where [MM_Statistic_Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_Result_Check]='NOT ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                        End If


                    ElseIf FileResult = FXSW_Result_Check Then
                        Dim doc As XmlDocument = New XmlDocument()
                        doc.Load(XML_CREATION_FOLDER_FILE & rdsql & "\" & FXSW_Result_Check)
                        Dim elemList As XmlNodeList = doc.GetElementsByTagName("ns2:RptSts")

                        Dim i As Integer
                        For i = 0 To elemList.Count - 1
                            'MsgBox(elemList(i).InnerXml)
                        Next i
                        Dim REPORT_RESULT As String = elemList(0).InnerXml
                        Dim WARNING_RESULT As String = Nothing

                        If REPORT_RESULT = "ACPT" Then
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_Result_Check]='ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Dim alltext As String = doc.InnerXml
                            If alltext.Contains("<ns2:Sts>WARN</ns2:Sts>") = True Then
                                cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_Result_Check]='ACCEPTED-WARN' where [MM_Statistic_Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_Result_Check]='NOT ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                        End If

                    ElseIf FileResult = EORW_Result_Check Then

                        Dim doc As XmlDocument = New XmlDocument()
                        doc.Load(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_Result_Check)
                        Dim elemList As XmlNodeList = doc.GetElementsByTagName("ns2:RptSts")
                        Dim i As Integer
                        For i = 0 To elemList.Count - 1
                            'MsgBox(elemList(i).InnerXml)
                        Next i
                        Dim REPORT_RESULT As String = elemList(0).InnerXml
                        Dim WARNING_RESULT As String = Nothing

                        If REPORT_RESULT = "ACPT" Then
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [EORW_Result_Check]='ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Dim alltext As String = doc.InnerXml
                            If alltext.Contains("<ns2:Sts>WARN</ns2:Sts>") = True Then
                                cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [EORW_Result_Check]='ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                        Else
                            cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [EORW_Result_Check]='NOT ACCEPTED' where [MM_Statistic_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                        End If

                    End If

                    'SET REPORT automatically to LOCKED if all Reports are ACCEPTED
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET ReportLocked=0 where  [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET ReportLocked=1 where [BGMM_Result_Check] in ('ACCEPTED') and [UGMM_Result_Check] in ('ACCEPTED')  and [FXSW_Result_Check] in ('ACCEPTED')  and [EORW_Result_Check] in ('ACCEPTED')   and  [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                Next fri

                'Check if Files exist
                If Not File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_Result_Check) Then
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [BGMM_Result_Check]='MISSING FILE' where [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & BGMM_Result_Check)
                End If
                If Not File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & UGMM_Result_Check) Then
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [UGMM_Result_Check]='MISSING FILE' where [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & UGMM_Result_Check)
                End If
                If Not File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & FXSW_Result_Check) Then
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [FXSW_Result_Check]='MISSING FILE' where [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & FXSW_Result_Check)
                End If
                If Not File.Exists(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_Result_Check) Then
                    cmd.CommandText = "UPDATE [MM_STATISTIC_DATE] SET [EORW_Result_Check]='MISSING FILE' where [MM_Statistic_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    File.Delete(XML_CREATION_FOLDER_FILE & rdsql & "\" & EORW_Result_Check)
                End If

            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("The Folder: " & XML_CREATION_FOLDER_FILE & rdsql & " does not exist!!" & vbNewLine & "Please first create the XML Files!", "FOLDER NOT EXISTING", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)
            SplashScreenManager.CloseForm(False)
        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
            XtraMessageBox.Show("Unable to load the Report results! Report is locked!", "REPORT STATUS IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    
   
    Private Sub UMS_Recreate_XML_btn_Click(sender As Object, e As EventArgs) Handles UMS_Recreate_XML_btn.Click
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        If System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) Then
            'Check for missing Customer Data
            cmd.CommandText = "SELECT [DEAL_NO],[CUSTOMER],'MM DEAL' as 'Deal' FROM [OPICS_MM] where OCBS_Cust_Nr is NULL Union All SELECT [DEAL_NO],[CUSTOMER],'FX DEAL' as 'Deal' FROM OPICS_FX where OCBS_Cust_Nr is NULL"
            Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            If dt2.Rows.Count > 0 Then 'MM DEALS NO VALID
                Dim MissingCustomers As String = Nothing
                For i = 0 To dt2.Rows.Count - 1
                    MissingCustomers += dt2.Rows.Item(i).Item("DEAL_NO") & " Deal Type: " & dt2.Rows.Item(i).Item("Deal") & vbNewLine
                Next
                XtraMessageBox.Show("In the following Deals the Customer Data are missing: " & vbNewLine & vbNewLine & MissingCustomers & vbNewLine & vbNewLine & "Please first insert the missing Customer Data!!", "MISSING CUSTOMER DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                Try
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Get the XML Creator Status
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_Creator' and [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim Result As String = cmd.ExecuteScalar
                    If Result <> "" Then
                        XML_CREATE = "Y"
                    Else
                        XML_CREATE = "N"
                    End If
                    'Get the XSD Version
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XSD_Version'  and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim XSD_VERSION As String = cmd.ExecuteScalar

                    'GET ALL OTHER PARAMETERS
                    cmd.CommandText = " SELECT [LEI_Code] from [BANK]"
                    XML_LEI_SENDER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='LEI_Receiver' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_LEI_RECEIVER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_CreationFolder_Directory' and  [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_CREATION_FOLDER_FILE = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Business_Service' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_BUSINESS_SERVICE = cmd.ExecuteScalar

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If


                    If XML_CREATE = "Y" Or SUPER_USER = "Y" Then
                        'Check if Report is unlocked
                        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
                            'Check if Markedsegments are present
                            If Me.BGMM_RepID_lbl.Text <> "" AndAlso Me.UGMM_RepID_lbl.Text <> "" AndAlso Me.FXSW_RepID_lbl.Text <> "" AndAlso Me.EORW_RepID_lbl.Text <> "" Then
                                'Check Merkedsegment results are present
                                If Me.BGMM_Result_lbl.Text <> "" AndAlso Me.UGMM_Result_lbl.Text <> "" AndAlso Me.FXSW_Result_lbl.Text <> "" AndAlso Me.EORW_Result_lbl.Text <> "" Then


                                    'Load Data for the Report Date
                                    Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
                                    Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
                                    Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)
                                    'Check Datavalidity in UNSECURED MM
                                    cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                    Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                                    Dim dt As New DataTable
                                    da.Fill(dt)
                                    If dt.Rows.Count > 0 Then 'MM DEALS NO VALID
                                        Dim NoValidMMDeals As String = Nothing
                                        For i = 0 To dt.Rows.Count - 1
                                            NoValidMMDeals += dt.Rows.Item(i).Item("PTI_Deal_Nr") & vbNewLine
                                        Next
                                        XtraMessageBox.Show("In the following MM Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidMMDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID MM DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    Else
                                        cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                        Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                                        Dim dt1 As New DataTable
                                        da1.Fill(dt1)
                                        If dt1.Rows.Count > 0 Then 'FX SWAP NO VALID
                                            Dim NoValidFXDeals As String = Nothing
                                            For i = 0 To dt1.Rows.Count - 1
                                                NoValidFXDeals += dt1.Rows.Item(i).Item("PTI_Swap_Deal_No") & vbNewLine
                                            Next
                                            XtraMessageBox.Show("In the following FX SWAP Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidFXDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID FX SWAP DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                            Exit Sub
                                        Else 'VALIDITY OK
                                            If XtraMessageBox.Show("Should a new XML File for the Money Market Statistic (Geldmarktstatistik) - Unsecured Transactions on " & rd & " be created?", "XML GELDMARKTSTATISTIK NEW FILE CREATION FOR UNSECURED TRANSACTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_UGMM_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_UGMM_1_CREATION()
                                                    End If

                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                If XtraMessageBox.Show("The New MM Statistic XML File for Unsecured Transactions with reporting date " & rd & " are created in the directory" & vbNewLine _
                                                    & XML_CREATION_FOLDER_FILE & rdsql & vbNewLine & vbNewLine & "File Name for Upload via Extranet:" & UGMM_XML_file & vbNewLine & vbNewLine & "Should the directory be oppened?", "XML FILES CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                    System.Diagnostics.Process.Start(XML_CREATION_FOLDER_FILE & rdsql)
                                                End If


                                            Else
                                                Exit Sub


                                            End If
                                        End If

                                    End If

                                Else 'Markedsegements results not present
                                    XtraMessageBox.Show("Unable to create XML Files! At least one Message ID Result is not present!", "MESSAGE ID RESULTS NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If

                            Else 'Markedsegements ID not present
                                XtraMessageBox.Show("Unable to create XML Files! At least one Message ID is not present!", "MESSAGE ID NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub

                            End If
                        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
                            XtraMessageBox.Show("Unable to create XML Files! Report is locked!", "REPORT STATUS IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf XML_CREATE = "N" AndAlso SUPER_USER = "N" Then
                        XtraMessageBox.Show("User is not authorized to create the XML Files for the Geldmarktstatistik", "NO AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Else
            XtraMessageBox.Show("Unable to re-create XML Files!The related folder is not created yet!" & vbNewLine & "Please click on button:Create XML Files!", "UNABLE TO RE-CREATE FILES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub FXS_Recreate_XML_btn_Click(sender As Object, e As EventArgs) Handles FXS_Recreate_XML_btn.Click
        Dim rd As Date = Me.ReportDateEdit.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        If System.IO.Directory.Exists(XML_CREATION_FOLDER_FILE & rdsql) Then
            'Check for missing Customer Data
            cmd.CommandText = "SELECT [DEAL_NO],[CUSTOMER],'MM DEAL' as 'Deal' FROM [OPICS_MM] where OCBS_Cust_Nr is NULL Union All SELECT [DEAL_NO],[CUSTOMER],'FX DEAL' as 'Deal' FROM OPICS_FX where OCBS_Cust_Nr is NULL"
            Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            If dt2.Rows.Count > 0 Then 'MM DEALS NO VALID
                Dim MissingCustomers As String = Nothing
                For i = 0 To dt2.Rows.Count - 1
                    MissingCustomers += dt2.Rows.Item(i).Item("DEAL_NO") & " Deal Type: " & dt2.Rows.Item(i).Item("Deal") & vbNewLine
                Next
                XtraMessageBox.Show("In the following Deals the Customer Data are missing: " & vbNewLine & vbNewLine & MissingCustomers & vbNewLine & vbNewLine & "Please first insert the missing Customer Data!!", "MISSING CUSTOMER DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                Try
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Get the XML Creator Status
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_Creator' and [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim Result As String = cmd.ExecuteScalar
                    If Result <> "" Then
                        XML_CREATE = "Y"
                    Else
                        XML_CREATE = "N"
                    End If
                    'Get the XSD Version
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XSD_Version'  and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim XSD_VERSION As String = cmd.ExecuteScalar

                    'GET ALL OTHER PARAMETERS
                    cmd.CommandText = " SELECT [LEI_Code] from [BANK]"
                    XML_LEI_SENDER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='LEI_Receiver' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_LEI_RECEIVER = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='XML_CreationFolder_Directory' and  [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_CREATION_FOLDER_FILE = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Business_Service' and [IdABTEILUNGSPARAMETER]='GELDMARKTSTATISTIK' and [PARAMETER STATUS]='Y' "
                    XML_BUSINESS_SERVICE = cmd.ExecuteScalar

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If


                    If XML_CREATE = "Y" Or SUPER_USER = "Y" Then
                        'Check if Report is unlocked
                        If Me.ReportLocked_CheckEdit.CheckState = CheckState.Unchecked Then
                            'Check if Markedsegments are present
                            If Me.BGMM_RepID_lbl.Text <> "" AndAlso Me.UGMM_RepID_lbl.Text <> "" AndAlso Me.FXSW_RepID_lbl.Text <> "" AndAlso Me.EORW_RepID_lbl.Text <> "" Then
                                'Check Merkedsegment results are present
                                If Me.BGMM_Result_lbl.Text <> "" AndAlso Me.UGMM_Result_lbl.Text <> "" AndAlso Me.FXSW_Result_lbl.Text <> "" AndAlso Me.EORW_Result_lbl.Text <> "" Then


                                    'Load Data for the Report Date
                                    Me.MM_STATISTIC_UGMMTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_UGMM, rd)
                                    Me.MM_STATISTIC_FXSWTableAdapter.FillByTradeDate(Me.MM_Statistic_Dataset.MM_STATISTIC_FXSW, rd)
                                    Me.MM_STATISTIC_DATETableAdapter.FillByStatisticDate(Me.MM_Statistic_Dataset.MM_STATISTIC_DATE, rd)
                                    'Check Datavalidity in UNSECURED MM
                                    cmd.CommandText = "SELECT * FROM [MM_STATISTIC_UGMM] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                    Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                                    Dim dt As New DataTable
                                    da.Fill(dt)
                                    If dt.Rows.Count > 0 Then 'MM DEALS NO VALID
                                        Dim NoValidMMDeals As String = Nothing
                                        For i = 0 To dt.Rows.Count - 1
                                            NoValidMMDeals += dt.Rows.Item(i).Item("PTI_Deal_Nr") & vbNewLine
                                        Next
                                        XtraMessageBox.Show("In the following MM Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidMMDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID MM DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    Else
                                        cmd.CommandText = "SELECT * FROM [MM_STATISTIC_FXSW] where [TradeDate]='" & rdsql & "' and [Meldepflicht]='Y' and [LEI_CODE] is NULL and [CounterpartySector] is NULL"
                                        Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                                        Dim dt1 As New DataTable
                                        da1.Fill(dt1)
                                        If dt1.Rows.Count > 0 Then 'FX SWAP NO VALID
                                            Dim NoValidFXDeals As String = Nothing
                                            For i = 0 To dt1.Rows.Count - 1
                                                NoValidFXDeals += dt1.Rows.Item(i).Item("PTI_Swap_Deal_No") & vbNewLine
                                            Next
                                            XtraMessageBox.Show("In the following FX SWAP Deal Nr. the LEI Code of the counterparty is missing: " & vbNewLine & NoValidFXDeals & vbNewLine & vbNewLine & "Please insert the LEI CODE of the relevant Counterparty " & vbNewLine & "or input a value in field:Counterparty Sector", "NO VALID FX SWAP DEALS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                            Exit Sub
                                        Else 'VALIDITY OK
                                            If XtraMessageBox.Show("Should a new XML File for the Money Market Statistic (Geldmarktstatistik) - FX Swaps Transactions on " & rd & " be created?", "XML GELDMARKTSTATISTIK NEW FILE CREATION FOR FX SWAPS TRANSACTIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                Try
                                                    If XSD_VERSION = "01" Then
                                                        XML_FXSW_CREATION()
                                                    ElseIf XSD_VERSION = "02" Then
                                                        XML_FXSW_1_CREATION()
                                                    End If

                                                Catch ex As Exception
                                                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    Exit Sub
                                                End Try
                                                If XtraMessageBox.Show("The New MM Statistic XML File for FX Swaps Transactions with reporting date " & rd & " are created in the directory" & vbNewLine _
                                                    & XML_CREATION_FOLDER_FILE & rdsql & vbNewLine & vbNewLine & "File Name for Upload via Extranet:" & FXSW_XML_file & vbNewLine & vbNewLine & "Should the directory be oppened?", "XML FILES CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                    System.Diagnostics.Process.Start(XML_CREATION_FOLDER_FILE & rdsql)
                                                End If


                                            Else
                                                Exit Sub


                                            End If
                                        End If

                                    End If

                                Else 'Markedsegements results not present
                                    XtraMessageBox.Show("Unable to create XML Files! At least one Message ID Result is not present!", "MESSAGE ID RESULTS NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If

                            Else 'Markedsegements ID not present
                                XtraMessageBox.Show("Unable to create XML Files! At least one Message ID is not present!", "MESSAGE ID NOT PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub

                            End If
                        ElseIf Me.ReportLocked_CheckEdit.CheckState = CheckState.Checked Then
                            XtraMessageBox.Show("Unable to create XML Files! Report is locked!", "REPORT STATUS IS LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf XML_CREATE = "N" AndAlso SUPER_USER = "N" Then
                        XtraMessageBox.Show("User is not authorized to create the XML Files for the Geldmarktstatistik", "NO AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Else
            XtraMessageBox.Show("Unable to re-create XML Files!The related folder is not created yet!" & vbNewLine & "Please click on button:Create XML Files!", "UNABLE TO RE-CREATE FILES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub BGMM_Result_Check_lbl_Click(sender As Object, e As EventArgs) Handles BGMM_Result_Check_lbl.Click

    End Sub
End Class