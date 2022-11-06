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
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing



Public Class ObligoLiabilitySurplus

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

    Dim SqlCommandText As String = Nothing

    Dim SumAssets As Double = 0
    Dim SumAssets_Sold As Double = 0
    Dim SumLiabilities_Fix As Double = 0
    Dim SumLiabilities_Non_Fix As Double = 0

    Dim SumAssets_T As Double = 0
    Dim SumAssets_Sold_T As Double = 0
    Dim SumLiabilities_Fix_T As Double = 0
    Dim SumLiabilities_Non_Fix_T As Double = 0

    Dim ObligoLiabilityPrincipal As Double = 0
    Dim ObligoLIabilityTotal As Double = 0


    Dim CheckField1 As String = Nothing
    Dim CheckField2 As String = Nothing


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

   

    Private Sub ObligoLiabilitySurplus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
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

        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")

        Dim da2 As SqlDataAdapter
        Dim objCMD2 As SqlCommand = New SqlCommand("Select [Class], Sum([OrgCurAmount]) as 'SumPrincipalCCY',Sum([AccruedInterestOrg]) as 'SumAccruedCCY',Sum([TotalAmountOrg]) as 'TotalCCY',Sum([OrgEurAmount]) as 'SumPrincipalEUR',Sum([AccruedInterestEUR]) as 'SumAccruedEUR',Sum([TotalAmountEUR]) as 'TotalEUR' FROM [OBLIGO_SURPLUS_DETAILS] where RiskDate='" & dsql & "' GROUP BY [Class] UNION ALL Select 'OBLIGO LIABILITY SURPLUS',0,0,0,(Select ABS(Sum(B.S)) from (Select Sum([OrgEurAmount]) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets-Sold') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Fix-Liabilities') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Nonfix-Liabilities') and RiskDate='" & dsql & "')B),0,(Select [CCBINFO Obligo Liability surplus] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & dsql & "')", conn)
        objCMD2.CommandTimeout = 5000
        da2 = New SqlDataAdapter(objCMD2)
        dt2 = New DataTable()
        da2.Fill(dt2)
        If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
            Me.GridControl3.DataSource = Nothing
            Me.GridControl3.DataSource = dt2
            Me.GridControl3.ForceInitialize()
        End If

        'Fill FINRECON Details
        Dim da As SqlDataAdapter
        Dim objCMD As SqlCommand = New SqlCommand("Select * from [OBLIGO_SURPLUS_DETAILS] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl2.DataSource = dt
            Me.GridControl2.ForceInitialize()
        End If

        GridControl2.MainView = FinRecon_BaseView
        FinRecon_BaseView.ForceDoubleClick = True
        AddHandler FinRecon_BaseView.DoubleClick, AddressOf FinRecon_BaseView_DoubleClick
        AddHandler FinRecon_LayoutView.MouseDown, AddressOf FinRecon_LayoutView_MouseDown
        AddHandler BICViews_btn.Click, AddressOf BICViews_btn_Click
        FinRecon_LayoutView.OptionsBehavior.AutoFocusCardOnScrolling = True
        FinRecon_LayoutView.OptionsBehavior.AllowSwitchViewModes = False

        ActiveTabGroup = 0

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

    Private Sub FinRecon_BaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles FinRecon_BaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub


    Private Sub FinRecon_BaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles FinRecon_BaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            SumAssets = 0
            SumAssets_Sold = 0
            SumLiabilities_Fix = 0
            SumLiabilities_Non_Fix = 0
            SumAssets_T = 0
            SumAssets_Sold_T = 0
            SumLiabilities_Fix_T = 0
            SumLiabilities_Non_Fix_T = 0

        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "OrgCur").ToString) <> "" Then
                CheckField1 = CStr(View.GetRowCellValue(e.RowHandle, "Class"))
               
                If summaryID = 2 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "OrgEurAmount"))
                    If CheckField1.ToString = "Assets" Then
                        SumAssets += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Assets-Sold" Then
                        SumAssets_Sold += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Fix-Liabilities" Then
                        SumLiabilities_Fix += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Nonfix-Liabilities" Then
                        SumLiabilities_Non_Fix += Convert.ToDecimal(e.FieldValue)
                    End If
                   

                End If
                
                'Calculation Totals
                If summaryID = 3 Then
                    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "TotalAmountEUR"))
                   If CheckField1.ToString = "Assets" Then
                        SumAssets_T += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Assets-Sold" Then
                        SumAssets_Sold_T += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Fix-Liabilities" Then
                        SumLiabilities_Fix_T += Convert.ToDecimal(e.FieldValue)
                    End If
                    If CheckField1.ToString = "Nonfix-Liabilities" Then
                        SumLiabilities_Non_Fix_T += Convert.ToDecimal(e.FieldValue)
                    End If

                End If

                'If summaryID = 4 Then
                '    Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "AM2"))
                '    OldSum_AM2 += Convert.ToDecimal(e.FieldValue)
                'End If

            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            ObligoLiabilityPrincipal = SumAssets - SumAssets_Sold - SumLiabilities_Fix - SumLiabilities_Non_Fix
            ObligoLIabilityTotal = SumAssets_T - SumAssets_Sold_T - SumLiabilities_Fix_T - SumLiabilities_Non_Fix_T
            If summaryID = 2 Then
                e.TotalValue = Math.Abs(ObligoLiabilityPrincipal)
            End If
            If summaryID = 3 Then
                e.TotalValue = Math.Abs(ObligoLIabilityTotal)
            End If
            
        End If
    End Sub

    Private Sub LoadDailyBalanceSheets_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing

            Me.GridControl3.DataSource = Nothing

            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Details for " & d)
                'Load Balance Sheet
                'Fill  Totals
                Dim da1 As SqlDataAdapter
                Dim objCMD1 As SqlCommand = New SqlCommand("Select [Class], Sum([OrgCurAmount]) as 'SumPrincipalCCY',Sum([AccruedInterestOrg]) as 'SumAccruedCCY',Sum([TotalAmountOrg]) as 'TotalCCY',Sum([OrgEurAmount]) as 'SumPrincipalEUR',Sum([AccruedInterestEUR]) as 'SumAccruedEUR',Sum([TotalAmountEUR]) as 'TotalEUR' FROM [OBLIGO_SURPLUS_DETAILS] where RiskDate='" & dsql & "' GROUP BY [Class] UNION ALL Select 'OBLIGO LIABILITY SURPLUS',0,0,0,(Select ABS(Sum(B.S)) from (Select Sum([OrgEurAmount]) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets-Sold') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Fix-Liabilities') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Nonfix-Liabilities') and RiskDate='" & dsql & "')B),0,(Select [CCBINFO Obligo Liability surplus] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & dsql & "')", conn)
                objCMD1.CommandTimeout = 5000
                da1 = New SqlDataAdapter(objCMD1)
                dt1 = New DataTable()
                da1.Fill(dt1)
                If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                    Me.GridControl3.DataSource = Nothing
                    Me.GridControl3.DataSource = dt1
                    Me.GridControl3.ForceInitialize()
                End If
               
                'Fill Balance Sheet 2 details
                Dim da As SqlDataAdapter
                Dim objCMD As SqlCommand = New SqlCommand("Select * from [OBLIGO_SURPLUS_DETAILS] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                dt = New DataTable()
                da.Fill(dt)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Me.GridControl2.DataSource = Nothing
                    Me.GridControl2.DataSource = dt
                    Me.GridControl2.ForceInitialize()

                End If



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
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If


            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()

            SplashScreenManager.CloseForm(False)



        End If
        If ActiveTabGroup = 1 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            If BICViews_btn.Text = "View Detail" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink2.CreateDocument()
                PrintableComponentLink2.ShowPreview()
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
       

    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = System.Drawing.Printing.PaperKind.A4, _
            .Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20) _
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
        Dim reportfooter As String = "Obligo Liabilities Details" & "   " & "Date: " & Me.FromDateEdit.Text
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
        Dim reportfooter As String = "Obligo Liabilities Totals" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Obligo Liabilities Totals" Then
            ActiveTabGroup = 0
            Me.LayoutControlItem10.Visibility = LayoutVisibility.Never
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Obligo Liabilities Details" Then
            ActiveTabGroup = 1
            Me.LayoutControlItem10.Visibility = LayoutVisibility.Always
       
        End If

    End Sub

    Private Sub TabbedControlGroup2_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup2.SelectedPageChanged
        If Me.TabbedControlGroup2.SelectedTabPage.Text = "Search for Accounts not included in the Balance Sheet" Then
            ActiveTabGroupQueries = 0

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
    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ObligoLiabilityTotals_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs) Handles ObligoLiabilityTotals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Nothing
        Me.GridControl2.DataSource = Nothing
        Me.GridControl3.DataSource = Nothing

        Me.GridControl4.DataSource = Nothing

        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Obligo Liabilities for " & d)

            'Fill  Totals
            Dim da1 As SqlDataAdapter
            Dim objCMD1 As SqlCommand = New SqlCommand("Select [Class], Sum([OrgCurAmount]) as 'SumPrincipalCCY',Sum([AccruedInterestOrg]) as 'SumAccruedCCY',Sum([TotalAmountOrg]) as 'TotalCCY',Sum([OrgEurAmount]) as 'SumPrincipalEUR',Sum([AccruedInterestEUR]) as 'SumAccruedEUR',Sum([TotalAmountEUR]) as 'TotalEUR' FROM [OBLIGO_SURPLUS_DETAILS] where RiskDate='" & dsql & "' GROUP BY [Class] UNION ALL Select 'OBLIGO LIABILITY SURPLUS',0,0,0,(Select ABS(Sum(B.S)) from (Select Sum([OrgEurAmount]) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Assets-Sold') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Fix-Liabilities') and RiskDate='" & dsql & "' UNION ALL Select Sum([OrgEurAmount])*(-1) as S from [OBLIGO_SURPLUS_DETAILS] where Class in ('Nonfix-Liabilities') and RiskDate='" & dsql & "')B),0,(Select [CCBINFO Obligo Liability surplus] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & dsql & "')", conn)
            objCMD1.CommandTimeout = 5000
            da1 = New SqlDataAdapter(objCMD1)
            dt1 = New DataTable()
            da1.Fill(dt1)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                Me.GridControl3.DataSource = Nothing
                Me.GridControl3.DataSource = dt1
                Me.GridControl3.ForceInitialize()
            End If

            'Fill  details
            Dim da As SqlDataAdapter
            Dim objCMD As SqlCommand = New SqlCommand("Select * from [OBLIGO_SURPLUS_DETAILS] where [RiskDate]=' " & dsql & "' order by [ID] asc", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)
            dt = New DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.GridControl2.DataSource = Nothing
                Me.GridControl2.DataSource = dt
                Me.GridControl2.ForceInitialize()
            End If



            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    
    Private Sub ObligoLiabilitySurplusCR_btn_Click(sender As Object, e As EventArgs) Handles ObligoLiabilitySurplusCR_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating OBLIGO LIABILITIES SURPLUS Report for " & Me.FromDateEdit.Text)

            Dim ObligoLiabilitiesDa As New SqlDataAdapter("SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            ObligoLiabilitiesDa.Fill(REPORTINGdataset, "OBLIGO_SURPLUS_DETAILS")


            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\ObligoLiabilitySurplusNew.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "OBLIGO LIABILITIES SURPLUS from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(75)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl2 Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing
        Dim view As GridView = TryCast(GridControl2.GetViewAt(e.ControlMousePosition), GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing AndAlso hi.Column.SummaryItem.SummaryType = SummaryItemType.Custom Then

            If hi.Column.FieldName = "OrgEurAmount" OrElse hi.Column.FieldName = "TotalAmountEUR" Then
                Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                Dim text As String = "Obligo Liability Surplus calculated as follows:" & _
                    vbNewLine & "[Assets] - [Assets Sold] - [Fix-Liabilities] - [Non-Fix Liabilities]"

                info = New ToolTipControlInfo(o, text)

            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
        End If
    End Sub
End Class