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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.Utils

Public Class Securities_LiquidityReserve

    Private BS_All_LiquidityDates As BindingSource
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

    Private Sub Securities_LiquidityReserve_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.DisplayListDetails_bbi.Caption = "Display List" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.DisplayListDetails_bbi.PerformClick()
                SplashScreenManager.CloseForm(False)
            End If

        End If
    End Sub

    Private Sub Securities_LiquidityReserve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ALL_LIQUIDITY_DATES_initData()
        ALL_LIQUIDITY_DATES_InitLookUp()

        If BS_All_LiquidityDates.Count > 0 Then
            Me.LiquidityDate_BarEditItem.EditValue = CType(BS_All_LiquidityDates.Current, DataRowView).Item(0).ToString
        End If

        'Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
        'Me.SecuritiesLiquidBaseView.ExpandAllGroups()
        'Me.SecuritiesLiquidBaseView.BestFitColumns()


        'Gridcontrol2 - SECURITIES
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = SecuritiesLiquidBaseView
        SecuritiesLiquidBaseView.ForceDoubleClick = True
        AddHandler SecuritiesLiquidBaseView.DoubleClick, AddressOf SecuritiesLiquidBaseView_DoubleClick
        AddHandler SecuritiesLiquidDetailView.MouseDown, AddressOf SecuritiesLiquidDetailView_MouseDown
        SecuritiesLiquidDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        SecuritiesLiquidDetailView.OptionsBehavior.AllowSwitchViewModes = False
    End Sub

    Private Sub ALL_LIQUIDITY_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @SELECTION_TABLE Table([ID] int IDENTITY(1,1) Not NULL, [REPORTING_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
													SELECT 'ALL'
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'REPORTING_DATE'=CONVERT(varchar(10),[LiquidityDate],104) from SECURITIES_LIQUIDITYRESERVE
                                                    group by LiquidityDate order by LiquidityDate asc
                                                    SELECT REPORTING_DATE  from @SELECTION_TABLE 
                                                    order by ID desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbLiquidityDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbLiquidityDates.Fill(ds, "LIQUIDITY_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_LiquidityDates = New BindingSource(ds, "LIQUIDITY_DATE")
    End Sub
    Private Sub ALL_LIQUIDITY_DATES_InitLookUp()
        Me.LiquidityDates_SearchLookUpEdit.DataSource = BS_All_LiquidityDates
        Me.LiquidityDates_SearchLookUpEdit.DisplayMember = "REPORTING_DATE"
        Me.LiquidityDates_SearchLookUpEdit.ValueMember = "REPORTING_DATE"
    End Sub

    Private Sub LiquidityDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles LiquidityDate_BarEditItem.EditValueChanged
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If Me.LiquidityDate_BarEditItem.EditValue.ToString = "ALL" Then
            SplashScreenManager.Default.SetWaitFormCaption("Load all Liquidity reserves for all Business dates")
            Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
            colLiquidityDate.GroupIndex = 0
            colLiquidityDate.Visible = True
            Me.SecuritiesLiquidBaseView.OptionsView.ShowGroupPanel = True
            Me.SecuritiesLiquidBaseView.ExpandAllGroups()
        ElseIf Me.LiquidityDate_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_LiquidityDates.Count > 0 Then
            rd = CDate(Me.LiquidityDate_BarEditItem.EditValue.ToString)
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity reserve for Business date: " & rd)
            Me.SECURITIES_LIQUIDITYRESERVETableAdapter.FillByLiquidityDate(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE, rd)
            colLiquidityDate.GroupIndex = -1
            colLiquidityDate.Visible = False
            colLiquidityDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            Me.SecuritiesLiquidBaseView.OptionsView.ShowGroupPanel = False
        End If
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub LiquidityDates_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LiquidityDates_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If Me.LiquidityDate_BarEditItem.EditValue.ToString = "ALL" Then
                SplashScreenManager.Default.SetWaitFormCaption("Load all Liquidity reserves for all Business dates")
                Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
                colLiquidityDate.GroupIndex = 0
                colLiquidityDate.Visible = True
                Me.SecuritiesLiquidBaseView.OptionsView.ShowGroupPanel = True
                Me.SecuritiesLiquidBaseView.ExpandAllGroups()
            ElseIf Me.LiquidityDate_BarEditItem.EditValue.ToString <> "ALL" AndAlso BS_All_LiquidityDates.Count > 0 Then
                rd = CDate(Me.LiquidityDate_BarEditItem.EditValue.ToString)
                rdsql = rd.ToString("yyyyMMdd")
                SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity reserve for Business date: " & rd)
                Me.SECURITIES_LIQUIDITYRESERVETableAdapter.FillByLiquidityDate(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE, rd)
                colLiquidityDate.GroupIndex = -1
                colLiquidityDate.Visible = False
                colLiquidityDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                Me.SecuritiesLiquidBaseView.OptionsView.ShowGroupPanel = False
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#Region "SECURITIES_LIQUIDITY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Display List"
    Private strShowExtendedMode As String = "Display Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        'Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = SecuritiesLiquidDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesLiquidBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strShowExtendedMode
        DisplayListDetails_bbi.ImageIndex = 9
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesLiquidDetailView)
        Me.RibbonPageGroup1.Visible = True
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        'Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        Dim datasourceRowIndex As Integer = SecuritiesLiquidBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesLiquidDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        DisplayListDetails_bbi.Caption = strHideExtendedMode
        DisplayListDetails_bbi.ImageIndex = 10
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesLiquidDetailView)
        Me.RibbonPageGroup1.Visible = False
    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesLiquidBaseView.GetRowHandle(dataSourceRowIndex)
        SecuritiesLiquidBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesLiquidDetailView.GetRowHandle(dataSourceRowIndex)
        SecuritiesLiquidDetailView.VisibleRecordIndex = SecuritiesLiquidDetailView.GetVisibleIndex(rowHandle)
        SecuritiesLiquidDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub SecuritiesLiquidBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = SecuritiesLiquidBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub SecuritiesLiquidDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = SecuritiesLiquidDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub

    Private Sub DisplayListDetails_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DisplayListDetails_bbi.ItemClick
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region


    Private Sub PrintOrExport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintOrExport_bbi.ItemClick
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If Me.DisplayListDetails_bbi.Caption = "Display Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.SecuritiesLiquidDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.PrintCardCaption = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.SecuritiesLiquidDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
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
            iSize = e.Graph.MeasureString(String.Format("SECURITIES LIQUIDITY RESERVE" & vbNewLine & "Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "SECURITIES LIQUIDITY RESERVE" & vbNewLine & "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "SECURITIES LIQUIDITY RESERVE for Business Date: " & LiquidityDate_BarEditItem.EditValue.ToString & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        'e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        'e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub


    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl2 Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing
        Dim view As GridView = TryCast(GridControl2.GetViewAt(e.ControlMousePosition), GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Column AndAlso hi.Column IsNot Nothing Then
            If hi.Column.FieldName = "Actual_Depreciation" Then
                Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                Dim text As String = "The Actual Depreciation is calculated as follows:" & vbNewLine & "FOR CURRENT ASSETS:" & vbNewLine & "If Purchase Amount (EUR)>Current Market Value (EUR) then Actual Depreciation=Purchase Amount (EUR) - Current Market Value (EUR)" & vbNewLine _
                                     & "else the Actual Depreciation=0" & vbNewLine & vbNewLine _
                                     & "FOR FIXED ASSETS:" & vbNewLine _
                                     & "The Depreciation is calculated as follows:" & vbNewLine _
                                     & "- If Current Market Price < Purchase Price and Current Market Price>=100 then Depreciation:Current Market Value (EUR) - Purchase Amount (EUR)" & vbNewLine _
                                     & "- If Current Market Price < Purchase Price and Current Market Price<100 then Depreciation:Principal Amount (EUR) - Purchase Amount (EUR)" & vbNewLine _
                                     & "Else Purchase Amount (EUR) - Current Market Value (EUR)"
                info = New ToolTipControlInfo(o, text)

                'ElseIf hi.Column.FieldName = "OCBS_Booked_Later" Then
                '    Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                '    Dim text As String = "OCBS Booked Later is calculated as follows:" & vbNewLine & "FOR CURRENT ASSETS:" & vbNewLine & "OCBS Booked before+Appreciation-Depreciation" & vbNewLine & vbNewLine _
                '                         & "FOR FIXED ASSETS:" & vbNewLine _
                '                         & "OCBS Booked later=OCBS booked before"
                '    info = New ToolTipControlInfo(o, text)

                'ElseIf hi.Column.FieldName = "Depreciation" OrElse hi.Column.FieldName = "Apreciation" Then
                '    Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                '    Dim text As String = "The Apreciation and Depreciation is calculated as follows:" & vbNewLine & "ONLY FOR CURRENT ASSETS:" & vbNewLine & "If Booked_Depreciation<Actual_Depreciation then Depreciation=Actual_Depreciation-Booked_Depreciation,Apreciation=0" & vbNewLine _
                '                         & "If Booked Depreciation>Actual Depreciation] then Depreciation=0,Apreciation=Booked_Depreciation-Actual_Depreciation" & vbNewLine & vbNewLine _
                '                         & "FOR FIXED ASSETS:" & vbNewLine _
                '                         & "Apreciation and Depreciation are 0"
                '    info = New ToolTipControlInfo(o, text)

            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
        End If
    End Sub

    Private Sub LiquidtyReserveReport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LiquidtyReserveReport_bbi.ItemClick
        'Get the max Date in Liquidity reserve
        OpenSqlConnections()
        cmd.CommandText = "Select Max([LiquidityDate]) from [SECURITIES_LIQUIDITYRESERVE]"
        Dim LiqDate As Date = cmd.ExecuteScalar
        CloseSqlConnections()

        ' Create a report instance.
        Dim report As New LiquidityReserveXtraReport


        ' Create a parameter and specify its name.
        Dim param1 As New Parameter()
        param1.Name = "LiquidityReserveDate"

        ' Specify other parameter properties.
        param1.Type = GetType(System.DateTime)
        param1.Value = LiqDate
        param1.Description = "Liquidity Reserve Date: "
        param1.Visible = True

        ' Add the parameter to the report.
        report.Parameters.Add(param1)
        report.Parameters("LiquidityReserveDate").Value = LiqDate

        ' Specify the report's filter string.
        report.FilterString = "[LiquidityDate] = [Parameters.LiquidityReserveDate]"

        ' Force the report creation without previously 
        ' requesting the parameter value from end-users.
        report.RequestParameters = False


        ' Show the parameter's value on a Report Header band.
        'Dim label As New XRLabel()
        'label.DataBindings.Add(New XRBinding(param1, "Text", "Exchange Rate Date: {0}"))
        'Dim reportHeader As New ReportHeaderBand()
        'reportHeader.Controls.Add(label)
        'report.Bands.Add(reportHeader)

        ' Assign the report to a ReportPrintTool,
        ' to hide the Parameters panel,
        ' and show the report's print preview.
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = True
        pt.ShowRibbonPreview(UserLookAndFeel.Default)
    End Sub

    Private Sub Close_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Close_bbi.ItemClick
        Me.Close()
    End Sub
End Class