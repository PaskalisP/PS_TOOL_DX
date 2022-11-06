Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Data
Imports DevExpress.XtraGrid


Public Class FxDailyRevaluationNew

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim ActiveTabGroup As String = "1"

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim ExcelFileName As String = Nothing


    Dim ContractNr As String = Nothing

    Dim customSum As Decimal = 0
    Dim customSum1 As Decimal = 0

    Dim MaxFxDailyRevaluationDate As Date
    Dim SqlMaxFxDailyRevaluationDate As String = Nothing

    Dim dtID As New DataTable

    Dim ResetPairNr As Double = 0
    Dim IDW_Zinsertrag As Double = 0
    Dim IDW_Zinsaufwand As Double = 0
    Dim IDW_Forderung As Double = 0
    Dim IDW_Forderung_BuyAmount As Double = 0
    Dim IDW_Forderung_SellAmount As Double = 0
    Dim IDW_Verbindlichkeit As Double = 0
    Dim IDW_Verbindlichkeit_BuyAmount As Double = 0
    Dim IDW_Verbindlichkeit_SellAmount As Double = 0

    Dim OpenPairs_Drohverlust As Double = 0
    Dim OpenPairs_Drohverlust_FX_Pairs = 0
    Dim OpenPairsUNEF_Drohverlust As Double = 0
    Dim OpenPairsUNEF_DrohverlustVJ As Double = 0
    Dim OpenPairsUNEF_DrohverlustTOTAL As Double = 0
    Dim OpenUnpaired_Drohverlust As Double = 0

    Dim ClosedSwaps_Zinsaufwand As Double = 0
    Dim ClosedSwaps_Zinsertrag As Double = 0

    Dim CheckFieldAmount_AmortizationToRiskDate As Double = 0
    Dim CheckFieldAmount_Buy2Buy1Amount As Double = 0
    Dim CheckFieldAmount_Sell2Sell1Amount As Double = 0
    Dim CheckFieldAmount_IDW_Amount As Double = 0
    Dim CheckFieldAmount_OpenPairs_Drohverlust As Double = 0
    Dim CheckFieldAmount_OpenPairs_DrohverlustFX_Pairs As Double = 0
    Dim CheckFieldAmount_OpenPairsUNEF_Drohverlust As Double = 0
    Dim CheckFieldAmount_OpenPairsUNEF_DrohverlustVJ As Double = 0
    Dim CheckFieldAmount_OpenUnpaired_Drohverlust As Double = 0
    Dim CheckFieldAmount_ClosedSwaps As Double = 0

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

    Private Sub FX_ALL_LOAD()
        Dim objCMD As SqlCommand = New SqlCommand("Select * from [FX ALL] order by [Input Date] desc", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        'Results
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            'Me.GridControl4.DataSource = Nothing
            Me.FX_Deals_All_GridControl.DataSource = dt
            Me.FX_Deals_All_GridControl.ForceInitialize()
        Else
            Me.FX_Deals_All_GridControl.DataSource = Nothing
        End If

       
    End Sub

    Private Sub FX_ALLBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FX_ALLBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.FxDailyRevaluationDataSet)

    End Sub

    Private Sub FxDailyRevaluationNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl5.EmbeddedNavigator.ButtonClick, AddressOf GridControl5_EmbeddedNavigator_ButtonClick
        AddHandler Me.FX_Deals_All_GridControl.EmbeddedNavigator.ButtonClick, AddressOf FX_Deals_All_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.FX_DailyRevaluation_GridControl.EmbeddedNavigator.ButtonClick, AddressOf FX_DailyRevaluation_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.FX_OwnDeals_GridControl.EmbeddedNavigator.ButtonClick, AddressOf FX_OwnDeals_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.FX_Evaluation_Results_GridControl.EmbeddedNavigator.ButtonClick, AddressOf FX_Evaluation_Results_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.OpenPairs_GridControl.EmbeddedNavigator.ButtonClick, AddressOf OpenPairs_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.OpenPairsUNEF_GridControl.EmbeddedNavigator.ButtonClick, AddressOf OpenPairsUNEF_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.OpenUnpaired_GridControl.EmbeddedNavigator.ButtonClick, AddressOf OpenUnpaired_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.OpenSwaps_BD_Part1_GridControl.EmbeddedNavigator.ButtonClick, AddressOf OpenSwaps_BD_Part1_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.OpenSwaps_BD_Part2_GridControl.EmbeddedNavigator.ButtonClick, AddressOf OpenSwaps_BD_Part2_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Me.ClosedSwaps_BD_Part3_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClosedSwaps_BD_Part3_GridControl_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='FX_EVALUATION_ExcelFile_Directory' and [IdABTEILUNGSPARAMETER]='FX_EVALUATION' and [PARAMETER STATUS]='Y'"
        ExcelFileName = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

        'Bind Combobox
        Me.FxDailyRevaluationDateEdit.Properties.Items.Clear()
        'Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [FX DAILY REVALUATION] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [FX_BEWERTUNGEN_GENERAL] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FxDailyRevaluationDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FxDailyRevaluationDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        MaxFxDailyRevaluationDate = Me.FxDailyRevaluationDateEdit.Text
        SqlMaxFxDailyRevaluationDate = MaxFxDailyRevaluationDate.ToString("yyyyMMdd")

        Me.FX_Evaluation_Results_GridView.Columns(5).Caption = MaxFxDailyRevaluationDate

        Dim LastYear As Integer = (MaxFxDailyRevaluationDate.Year) - 1
        Me.ClosedSwaps_Part3_GridView.Columns(13).Caption = "Days from 31.12." & LastYear.ToString & " till Maturity Date"


        Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
        Me.FX_DAILY_REVALUATION_ALL_CONTRACTSTableAdapter.Fill(Me.FxDailyRevaluationDataSet.FX_DAILY_REVALUATION_ALL_CONTRACTS)
        Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_DAILY_REVALUATION, MaxFxDailyRevaluationDate)
        Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.RISK_LIMIT_DAILY_CONTROL, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_BUCHUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_BUCHUNGEN_DETAILS, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_TOTALS, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_UNEF_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_UNEF_TOTALS, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_DETAILS_ALL_TableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS_ALL, MaxFxDailyRevaluationDate)
        Me.FX_BEWERTUNGEN_CLOSED_SWAPSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_CLOSED_SWAPS, MaxFxDailyRevaluationDate)

        'Show LIST-DETAILS in FX ALL
        FX_Deals_All_GridControl.MainView = FX_All_BaseView
        FX_All_BaseView.ForceDoubleClick = True
        AddHandler FX_All_BaseView.DoubleClick, AddressOf FX_All_BaseView_DoubleClick
        AddHandler FX_All_LayoutView1.MouseDown, AddressOf FX_All_LayoutView1_MouseDown
        'AddHandler View_Details_btn.Click, AddressOf View_Details_btn_Click
        FX_All_LayoutView1.OptionsBehavior.AutoFocusCardOnScrolling = True
        FX_All_LayoutView1.OptionsBehavior.AllowSwitchViewModes = False


        'dtPairs = New DataTable
        dtID.Columns.Add("ID", GetType(Integer))
        dtID.Columns.Add("OCBS_CI_NO", GetType(String))
        dtID.Columns.Add("ContractNo", GetType(String))
        dtID.Columns.Add("ClientName ", GetType(String))
        dtID.Columns.Add("B/S", GetType(String))
        dtID.Columns.Add("Input Date", GetType(Date))
        dtID.Columns.Add("Start Date", GetType(Date))
        dtID.Columns.Add("End Date", GetType(Date))
        dtID.Columns.Add("Deal Currency", GetType(String))
        dtID.Columns.Add("Deal Amount", GetType(Double))
        dtID.Columns.Add("CCY_B", GetType(String))
        dtID.Columns.Add("AMT_B", GetType(Double))
        dtID.Columns.Add("CCY_S", GetType(String))
        dtID.Columns.Add("AMT_S", GetType(Double))
        dtID.Columns.Add("Status", GetType(String))
    End Sub

#Region "FX DEALS ALL CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        FX_Deals_All_GridControl.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = FX_All_LayoutView1.GetDataSourceRowIndex(rowHandle)
        FX_Deals_All_GridControl.MainView = FX_All_BaseView
        SynchronizeOrdersView(datasourceRowIndex)
        FX_Deals_All_GridControl.UseEmbeddedNavigator = True
        Me.FX_Deals_All_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
        'Me.FX_Deals_All_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
        'View_Details_btn.Text = strShowExtendedMode
        'BICViews_btn.ImageIndex = 1
        fExtendedEditMode = (FX_Deals_All_GridControl.MainView Is FX_All_LayoutView1)
        Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        'LayoutControlItem3 includes Gridcontrol5
        Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
        Dim datasourceRowIndex As Integer = FX_All_BaseView.GetDataSourceRowIndex(rowHandle)
        FX_Deals_All_GridControl.MainView = FX_All_LayoutView1
        SynchronizeOrdersDetailView(datasourceRowIndex)
        FX_Deals_All_GridControl.UseEmbeddedNavigator = True
        Me.FX_Deals_All_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
        'Me.FX_Deals_All_GridControl.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
        'View_Details_btn.Text = strHideExtendedMode
        'BICViews_btn.ImageIndex = 0
        fExtendedEditMode = (FX_Deals_All_GridControl.MainView Is FX_All_LayoutView1)


    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FX_All_BaseView.GetRowHandle(dataSourceRowIndex)
        FX_All_BaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = FX_All_LayoutView1.GetRowHandle(dataSourceRowIndex)
        FX_All_LayoutView1.VisibleRecordIndex = FX_All_LayoutView1.GetVisibleIndex(rowHandle)
        FX_All_LayoutView1.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub FX_All_BaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = FX_All_BaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub FX_All_LayoutView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = FX_All_LayoutView1.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub View_Details_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        'If fExtendedEditMode Then
        'HideDetail((TryCast(FX_Deals_All_GridControl.MainView, ColumnView)).FocusedRowHandle)
        'Else
        'ShowDetail((TryCast(FX_Deals_All_GridControl.MainView, ColumnView)).FocusedRowHandle)
        'End If
    End Sub
#End Region

    Private Sub GridControl5_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "FxPairing" Then
            Dim FxDealsToPaired As String = Nothing
            For i = 0 To dtID.Rows.Count - 1
                If dtID.Rows.Count > 0 Then
                    FxDealsToPaired += dtID.Rows.Item(i).Item("ContractNo") & "  Input Date:" & dtID.Rows.Item(i).Item("Input Date") & "  Start Date:" & dtID.Rows.Item(i).Item("Start Date") & "  End Date:" & dtID.Rows.Item(i).Item("End Date") & vbNewLine & "Client Name:" & dtID.Rows.Item(i).Item("ClientName ") & " BUY: " & dtID.Rows.Item(i).Item("CCY_B") & "  " & FormatNumber(dtID.Rows.Item(i).Item("AMT_B"), 2) & " SELL: " & dtID.Rows.Item(i).Item("CCY_S") & "  " & FormatNumber(dtID.Rows.Item(i).Item("AMT_S"), 2) & vbNewLine & vbNewLine
                End If
            Next
            If dtID.Rows.Count > 1 Then
                If XtraMessageBox.Show("Should the following FX Deals: " & vbNewLine & vbNewLine & FxDealsToPaired & vbNewLine & "be paired?", "FX DEALS - PAIRING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    'Set as paired
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select Max([PairNr]) from [FX ALL]"
                    Dim MaxPairNr As Double = cmd.ExecuteScalar + 1
                    'MsgBox(MaxPairNr)
                    For i = 0 To dtID.Rows.Count - 1
                        cmd.CommandText = "UPDATE [FX ALL] SET [IsPair]=1,[PairNr]=" & Str(MaxPairNr) & " where [ID]='" & dtID.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    'Mark as effective or uneffective
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_BUY') Is Not Null) Drop Table #tempFX_BUY"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_SELL') Is Not Null) Drop Table #tempFX_SELL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_RESULT') Is Not Null) Drop Table #tempFX_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_ENDDATE_RESULT') Is Not Null) Drop Table #tempFX_ENDDATE_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_BUY (ID int IDENTITY(1,1) NOT NULL,CCY_B nvarchar(50),AMT_B float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_SELL (ID int IDENTITY(1,1) NOT NULL,CCY_S nvarchar(50),AMT_S float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_RESULT (ID int IDENTITY(1,1) NOT NULL,CCY_B nvarchar(50),AMT_DIF float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_ENDDATE_RESULT (ID int IDENTITY(1,1) NOT NULL,END_DATE Datetime)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_BUY Select [CCY_B] as 'CCY_B',Sum([AMT_B]) as 'AMT_B' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_B]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_SELL Select [CCY_S] as 'CCY_S',Sum([AMT_S]) as 'AMT_S' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_S]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_RESULT Select [CCY_B] as 'CCY_B',0 as 'AMT_DIF' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_B]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_ENDDATE_RESULT Select [End Date] from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & ""
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.AMT_DIF=B.AMT_B - C.AMT_S from #tempFX_RESULT A INNER JOIN #tempFX_BUY B on A.[CCY_B]=B.[CCY_B] INNER JOIN #tempFX_SELL C on A.[CCY_B]=C.[CCY_S]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF (SELECT Count(ID) from #tempFX_RESULT where AMT_DIF=0)>0 AND (SELECT COUNT(DISTINCT END_DATE) from #tempFX_ENDDATE_RESULT)=1 BEGIN UPDATE [FX ALL] SET [PairDescription]='EFFECTIVE' where [PairNr]=" & Str(MaxPairNr) & " END ELSE BEGIN UPDATE [FX ALL] SET [PairDescription]='UNEFFECTIVE' where [PairNr]=" & Str(MaxPairNr) & " END"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_BUY') Is Not Null) Drop Table #tempFX_BUY"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_SELL') Is Not Null) Drop Table #tempFX_SELL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_RESULT') Is Not Null) Drop Table #tempFX_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_ENDDATE_RESULT') Is Not Null) Drop Table #tempFX_ENDDATE_RESULT"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Dim view As GridView = Me.FX_All_BaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.FX_Deals_All_GridControl.BeginUpdate()
                    Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
                    Me.FX_All_BaseView.RefreshData()
                    Me.FX_Deals_All_GridControl.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                    dtID.Clear()
                    Me.GridControl5.DataSource = Nothing
                End If
            End If

        End If
    End Sub

    Private Sub FX_Deals_All_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "FxPairing" Then
            Dim FxDealsToPaired As String = Nothing
            For i = 0 To dtID.Rows.Count - 1
                If dtID.Rows.Count > 0 Then
                    FxDealsToPaired += dtID.Rows.Item(i).Item("ContractNo") & "  Input Date:" & dtID.Rows.Item(i).Item("Input Date") & "  Start Date:" & dtID.Rows.Item(i).Item("Start Date") & "  End Date:" & dtID.Rows.Item(i).Item("End Date") & vbNewLine & "Client Name:" & dtID.Rows.Item(i).Item("ClientName ") & " BUY: " & dtID.Rows.Item(i).Item("CCY_B") & "  " & FormatNumber(dtID.Rows.Item(i).Item("AMT_B"), 2) & " SELL: " & dtID.Rows.Item(i).Item("CCY_S") & "  " & FormatNumber(dtID.Rows.Item(i).Item("AMT_S"), 2) & vbNewLine & vbNewLine
                End If
            Next
            If dtID.Rows.Count > 1 Then
                If XtraMessageBox.Show("Should the following FX Deals: " & vbNewLine & vbNewLine & FxDealsToPaired & vbNewLine & "be paired?", "FX DEALS - PAIRING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    'Set as paired
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select Max([PairNr]) from [FX ALL]"
                    Dim MaxPairNr As Double = cmd.ExecuteScalar + 1
                    'MsgBox(MaxPairNr)
                    For i = 0 To dtID.Rows.Count - 1
                        cmd.CommandText = "UPDATE [FX ALL] SET [IsPair]=1,[PairNr]=" & Str(MaxPairNr) & " where [ID]='" & dtID.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    'Mark as effective or uneffective
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_BUY') Is Not Null) Drop Table #tempFX_BUY"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_SELL') Is Not Null) Drop Table #tempFX_SELL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_RESULT') Is Not Null) Drop Table #tempFX_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_ENDDATE_RESULT') Is Not Null) Drop Table #tempFX_ENDDATE_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_BUY (ID int IDENTITY(1,1) NOT NULL,CCY_B nvarchar(50),AMT_B float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_SELL (ID int IDENTITY(1,1) NOT NULL,CCY_S nvarchar(50),AMT_S float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_RESULT (ID int IDENTITY(1,1) NOT NULL,CCY_B nvarchar(50),AMT_DIF float)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "create table #tempFX_ENDDATE_RESULT (ID int IDENTITY(1,1) NOT NULL,END_DATE Datetime)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_BUY Select [CCY_B] as 'CCY_B',Sum([AMT_B]) as 'AMT_B' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_B]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_SELL Select [CCY_S] as 'CCY_S',Sum([AMT_S]) as 'AMT_S' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_S]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_RESULT Select [CCY_B] as 'CCY_B',0 as 'AMT_DIF' from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & " GROUP BY [CCY_B]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Insert Into #tempFX_ENDDATE_RESULT Select [End Date] from [FX ALL] where [PairNr]=" & Str(MaxPairNr) & ""
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.AMT_DIF=B.AMT_B - C.AMT_S from #tempFX_RESULT A INNER JOIN #tempFX_BUY B on A.[CCY_B]=B.[CCY_B] INNER JOIN #tempFX_SELL C on A.[CCY_B]=C.[CCY_S]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF (SELECT Count(ID) from #tempFX_RESULT where AMT_DIF=0)>0 AND (SELECT COUNT(DISTINCT END_DATE) from #tempFX_ENDDATE_RESULT)=1 BEGIN UPDATE [FX ALL] SET [PairDescription]='EFFECTIVE' where [PairNr]=" & Str(MaxPairNr) & " END ELSE BEGIN UPDATE [FX ALL] SET [PairDescription]='UNEFFECTIVE' where [PairNr]=" & Str(MaxPairNr) & " END"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_BUY') Is Not Null) Drop Table #tempFX_BUY"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_SELL') Is Not Null) Drop Table #tempFX_SELL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_RESULT') Is Not Null) Drop Table #tempFX_RESULT"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "If(OBJECT_ID('tempdb..#tempFX_ENDDATE_RESULT') Is Not Null) Drop Table #tempFX_ENDDATE_RESULT"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Dim view As GridView = Me.FX_All_BaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.FX_Deals_All_GridControl.BeginUpdate()
                    Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
                    Me.FX_All_BaseView.RefreshData()
                    Me.FX_Deals_All_GridControl.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                    dtID.Clear()
                    Me.GridControl5.DataSource = Nothing
                End If
            End If

        End If

        If e.Button.Tag = "Print" Then
            If FX_Deals_All_GridControl.MainView Is FX_All_BaseView Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            ElseIf FX_Deals_All_GridControl.MainView Is FX_All_LayoutView1 Then
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = False
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = False
                Me.FX_All_LayoutView1.OptionsPrint.PrintSelectedCardsOnly = True
                Me.FX_All_LayoutView1.OptionsPrint.PrintCardCaption = True
                Me.FX_All_LayoutView1.OptionsPrint.AllowCancelPrintExport = True
                Me.FX_All_LayoutView1.OptionsPrint.ShowPrintExportProgress = True
                PreviewPrintableComponent(FX_Deals_All_GridControl, FX_Deals_All_GridControl.LookAndFeel)
                'Me.FX_All_LayoutView1.ShowPrintPreview()
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewHeight = True
                Me.FX_All_LayoutView1.OptionsSingleRecordMode.StretchCardToViewWidth = True
            End If

        End If
    End Sub

    Private Sub FX_DailyRevaluation_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FX_OwnDeals_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FX_Evaluation_Results_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink4.CreateDocument()
            PrintableComponentLink4.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OpenPairs_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink5.CreateDocument()
            PrintableComponentLink5.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OpenPairsUNEF_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink6.CreateDocument()
            PrintableComponentLink6.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OpenUnpaired_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink7.CreateDocument()
            PrintableComponentLink7.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OpenSwaps_BD_Part1_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink8.CreateDocument()
            PrintableComponentLink8.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub OpenSwaps_BD_Part2_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.IDW_GridView.Columns.Item("colDifference").AppearanceCell.ForeColor = Color.Black
            PrintableComponentLink9.CreateDocument()
            PrintableComponentLink9.ShowPreview()
            Me.IDW_GridView.Columns.Item("colDifference").AppearanceCell.ForeColor = Color.Aqua
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ClosedSwaps_BD_Part3_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink10.CreateDocument()
            PrintableComponentLink10.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#Region "PRINTABLE COMPONENT LINKS"

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With {
            .PrintingSystemBase = New PrintingSystem(),
            .Component = component,
            .Landscape = True,
            .PaperKind = System.Drawing.Printing.PaperKind.A4,
            .Margins = New System.Drawing.Printing.Margins(20, 90, 20, 20)
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
        Dim reportfooter As String = "ALL FX DEALS till " & Me.FxDailyRevaluationDateEdit.Text
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
        Dim reportfooter As String = "FX DEALS DAILY REVALUATION REPORT on " & Me.FxDailyRevaluationDateEdit.Text
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
        Dim reportfooter As String = "FORWARD TRADING SWAPS (OWN DEALS) till " & Me.FxDailyRevaluationDateEdit.Text
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
        Dim reportfooter As String = "FX EVALUATION RESULTS ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPEN FX PAIRS (All) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
        Dim reportfooter As String = "OPEN FX PAIRS (Uneffective) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink7_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink7_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink7.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPEN FX DEALS UNPAIRED (NO SWAPS) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink8_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink8.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPEN SWAPS - BESONDERE DECKUNG (Part 1) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink9_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink9.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink9_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink9.CreateMarginalHeaderArea
        Dim reportfooter As String = "OPEN SWAPS - BESONDERE DECKUNG (Part 2) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink10_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink10.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink10_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink10.CreateMarginalHeaderArea
        Dim reportfooter As String = "CLOSED SWAPS - BESONDERE DECKUNG (Part 3) ON " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#End Region

#Region "GRIDVIEWS STYLES"

    Private Sub FX_All_BaseView_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_All_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FX_All_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles FX_All_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub FxDailyRevaluation_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FxDailyRevaluation_BasicView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FxDailyRevaluation_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles FxDailyRevaluation_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub FxTradingSwapsOwnDeals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FxTradingSwapsOwnDeals_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FxTradingSwapsOwnDeals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles FxTradingSwapsOwnDeals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub FX_Evaluation_Results_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles FX_Evaluation_Results_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub FX_Evaluation_Results_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_Evaluation_Results_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FX_Evaluation_Results_GridView_ShownEditor(sender As Object, e As EventArgs) Handles FX_Evaluation_Results_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub OpenPairs_Totals_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenPairs_Totals_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub OpenPairs_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenPairs_Totals_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OpenPairs_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenPairs_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OpenPairs_Details_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenPairs_Details_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub OpenPairs_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenPairs_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OpenPairs_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenPairs_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub OpenPaired_UNEF_Totals_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenPaired_UNEF_Totals_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub OpenPaired_UNEF_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenPaired_UNEF_Totals_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OpenPaired_UNEF_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenPaired_UNEF_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OpenPaired_UNEF_Details_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenPaired_UNEF_Details_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub OpenPaired_UNEF_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenPaired_UNEF_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OpenPaired_UNEF_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenPaired_UNEF_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub OpenUnpaired_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenUnpaired_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub OpenUnpaired_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenUnpaired_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OpenUnpaired_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenUnpaired_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub OpenSwaps_Part1_AdvBandedGridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles OpenSwaps_Part1_AdvBandedGridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub OpenSwaps_Part1_AdvBandedGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OpenSwaps_Part1_AdvBandedGridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub OpenSwaps_Part1_AdvBandedGridView_ShownEditor(sender As Object, e As EventArgs) Handles OpenSwaps_Part1_AdvBandedGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.Control
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Blue
        End If
    End Sub


    Private Sub IDW_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles IDW_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub IDW_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IDW_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub IDW_GridView_ShownEditor(sender As Object, e As EventArgs) Handles IDW_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ClosedSwaps_Part3_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ClosedSwaps_Part3_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub ClosedSwaps_Part3_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClosedSwaps_Part3_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClosedSwaps_Part3_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClosedSwaps_Part3_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

#End Region

    Private Function GetSelectedRows(ByVal view As GridView) As String
        Dim ret As String = ""

        Dim rowIndex As Integer = -1

        For Each i As Integer In FX_All_BaseView.GetSelectedRows()
            Dim row_Renamed As DataRow = FX_All_BaseView.GetDataRow(i)

            If ret <> "" Then
                ret &= ControlChars.CrLf
            End If

            If row_Renamed("IsPair") = 0 Then
                If row_Renamed("Status") <> "D" Then
                    ret &= row_Renamed(0)
                    dtID.Rows.Add(row_Renamed(0), row_Renamed("OCBS_CI_NO"), row_Renamed("ContractNo"), row_Renamed("ClientName "), row_Renamed("B/S"), row_Renamed("Input Date"), row_Renamed("Start Date"), row_Renamed("End Date"), row_Renamed("Deal Currency"), row_Renamed("Deal Amount"), row_Renamed("CCY_B"), row_Renamed("AMT_B"), row_Renamed("CCY_S"), row_Renamed("AMT_S"), row_Renamed("Status"))
                Else
                    XtraMessageBox.Show("The selected FX Deal is DELETED", "NO PAIRING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    FX_All_BaseView.ClearSelection()

                    Exit For
                End If

            End If

        Next i
        Return ret

    End Function

    Private Sub RemoveDuplicates(dt As DataTable)

        If dt.Rows.Count > 0 Then
            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                If i = 0 Then
                    Exit For
                End If
                For j As Integer = i - 1 To 0 Step -1
                    If Convert.ToInt32(dt.Rows(i)("ID")) = Convert.ToInt32(dt.Rows(j)("ID")) Then
                        dt.Rows(i).Delete()
                        Exit For
                    End If
                Next
            Next
            dt.AcceptChanges()
        End If
    End Sub

    Private Sub FX_All_BaseView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles FX_All_BaseView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

        If HitInfo.InRow AndAlso ResetPairNr > 0 Then

            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

        End If
    End Sub

    Private Sub FX_All_BaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles FX_All_BaseView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ResetPairNr = view.GetFocusedRowCellValue("PairNr")

        End If
    End Sub

    Private Sub FX_All_BaseView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles FX_All_BaseView.SelectionChanged
        Dim view As GridView = FX_All_BaseView
        'Fill ID to Datatable
        dtID.Clear()

        GetSelectedRows(view)

        Me.GridControl5.DataSource = Nothing
        Me.GridControl5.DataSource = dtID
        Me.GridControl5.ForceInitialize()
    End Sub

    Private Sub GridControl5_Paint(sender As Object, e As PaintEventArgs) Handles GridControl5.Paint
        Dim viewInfo As GridViewInfo = CType(Me.FX_Deals_Pairing_GridView.GetViewInfo(), GridViewInfo)
        Dim r As Rectangle = viewInfo.ViewCaptionBounds
        Dim f As Font = New Font(Me.FX_Deals_Pairing_GridView.Appearance.ViewCaption.Font.FontFamily, 9.0F, FontStyle.Bold)

        Dim backColor As Color = Me.FX_Deals_Pairing_GridView.PaintAppearance.ViewCaption.BackColor
        Dim foreColor As Color = Color.White

        e.Graphics.FillRectangle(Brushes.Navy, r)
        e.Graphics.DrawString("FX DEALS PAIRING", f, New SolidBrush(foreColor), r, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
    End Sub

    Private Sub UnpairFX_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnpairFX_ToolStripMenuItem.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Me.QueryText = "Select * from [FX ALL] where [PairNr]=" & Str(ResetPairNr) & ""
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Dim RelatedFX_Deals As String = Nothing
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows.Count > 0 Then
                RelatedFX_Deals += dt.Rows.Item(i).Item("ContractNo") & "  Input Date:" & dt.Rows.Item(i).Item("Input Date") & "  Start Date:" & dt.Rows.Item(i).Item("Start Date") & "  End Date:" & dt.Rows.Item(i).Item("End Date") & vbNewLine & "Client Name:" & dt.Rows.Item(i).Item("ClientName ") & " BUY: " & dt.Rows.Item(i).Item("CCY_B") & "  " & FormatNumber(dt.Rows.Item(i).Item("AMT_B"), 2) & " SELL: " & dt.Rows.Item(i).Item("CCY_S") & "  " & FormatNumber(dt.Rows.Item(i).Item("AMT_S"), 2) & vbNewLine & vbNewLine
            End If
        Next
        dt.Clear()

        If XtraMessageBox.Show("Should the paired FX Deals:" & vbNewLine & vbNewLine & RelatedFX_Deals & "be changed to unpaired ?", "FX DEALS - UNPAIRING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            cmd.CommandText = "UPDATE [FX ALL] SET [IsPair]=0,[PairNr]=0,[PairDescription]=NULL where [PairNr]=" & Str(ResetPairNr) & ""
            cmd.ExecuteNonQuery()
            Dim view As GridView = Me.FX_All_BaseView
            Dim focusedRow As Integer = view.FocusedRowHandle
            Me.FX_Deals_All_GridControl.BeginUpdate()
            Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
            Me.FX_All_BaseView.RefreshData()
            Me.FX_Deals_All_GridControl.EndUpdate()
            view.FocusedRowHandle = focusedRow
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

    End Sub

    Private Sub FxDailyRevaluationDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FxDailyRevaluationDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.FX_DailyRevaluation_GridControl.DataSource = Me.FX_DAILY_REVALUATIONBindingSource

            If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
                Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                'Load Data
                Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
                Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_DAILY_REVALUATION, d)
                Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.RISK_LIMIT_DAILY_CONTROL, d)
                Me.FX_BEWERTUNGEN_BUCHUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_BUCHUNGEN_DETAILS, d)
                Me.FX_BEWERTUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS, d)
                Me.FX_BEWERTUNGEN_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_TOTALS, d)
                Me.FX_BEWERTUNGEN_UNEF_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_UNEF_TOTALS, d)
                Me.FX_BEWERTUNGEN_DETAILS_ALL_TableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS_ALL, d)
                Me.FX_BEWERTUNGEN_CLOSED_SWAPSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_CLOSED_SWAPS, d)
                Me.FX_Evaluation_Results_GridView.Columns(5).Caption = d
                Dim LastYear As Integer = (d.Year) - 1
                Me.ClosedSwaps_Part3_GridView.Columns(13).Caption = "Days from 31.12." & LastYear.ToString & " till Maturity Date"
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub FxDailyRevaluationDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FxDailyRevaluationDateEdit.SelectedIndexChanged
        Me.FX_DailyRevaluation_GridControl.DataSource = Me.FX_DAILY_REVALUATIONBindingSource

        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
            'Load Data
            Me.FX_ALLTableAdapter.FillByAllFX(Me.FxDailyRevaluationDataSet.FX_ALL)
            Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_DAILY_REVALUATION, d)
            Me.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.RISK_LIMIT_DAILY_CONTROL, d)
            Me.FX_BEWERTUNGEN_BUCHUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_BUCHUNGEN_DETAILS, d)
            Me.FX_BEWERTUNGEN_DETAILSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS, d)
            Me.FX_BEWERTUNGEN_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_TOTALS, d)
            Me.FX_BEWERTUNGEN_UNEF_TOTALSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_UNEF_TOTALS, d)
            Me.FX_BEWERTUNGEN_DETAILS_ALL_TableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_DETAILS_ALL, d)
            Me.FX_BEWERTUNGEN_CLOSED_SWAPSTableAdapter.FillByRiskDate(Me.FxDailyRevaluationDataSet.FX_BEWERTUNGEN_CLOSED_SWAPS, d)

            Me.FX_Evaluation_Results_GridView.Columns(5).Caption = d
            Dim LastYear As Integer = (d.Year) - 1
            Me.ClosedSwaps_Part3_GridView.Columns(13).Caption = "Days from 31.12." & LastYear.ToString & " till Maturity Date"

            SplashScreenManager.CloseForm(False)

        End If


    End Sub

    Private Sub RepositoryItemImageComboBox2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox2.EditValueChanged
        ContractNr = Me.FxTradingSwapsOwnDeals_GridView.GetFocusedRowCellDisplayText(colContractNr2)
        If ContractNr <> "" Then
            Try
                Me.FxTradingSwapsOwnDeals_GridView.PostEditor()

                Dim OwnDealValueStatus As String = Me.FxTradingSwapsOwnDeals_GridView.GetFocusedRowCellValue(colOwnDeal1).ToString
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET OwnDeal='" & OwnDealValueStatus & "' where ContractNr='" & ContractNr & "' and DealStatus in ('U')"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Dim view As GridView = Me.FxTradingSwapsOwnDeals_GridView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.FX_OwnDeals_GridControl.BeginUpdate()
                Me.FX_DAILY_REVALUATION_ALL_CONTRACTSTableAdapter.Fill(Me.FxDailyRevaluationDataSet.FX_DAILY_REVALUATION_ALL_CONTRACTS)
                view.RefreshData()
                Me.FX_OwnDeals_GridControl.EndUpdate()
                view.FocusedRowHandle = focusedRow
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End Try
        End If


    End Sub

    Private Sub IDW_GridView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles IDW_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            IDW_Zinsaufwand = 0
            IDW_Zinsertrag = 0
            IDW_Forderung_BuyAmount = 0
            IDW_Forderung_SellAmount = 0
            IDW_Verbindlichkeit = 0
            IDW_Verbindlichkeit_BuyAmount = 0
            IDW_Verbindlichkeit_SellAmount = 0
            IDW_Forderung = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldAmount_AmortizationToRiskDate = View.GetRowCellValue(e.RowHandle, colAmortizationToRiskDate_Part11)
            CheckFieldAmount_IDW_Amount = View.GetRowCellValue(e.RowHandle, colIDW_Amount)
            CheckFieldAmount_Buy2Buy1Amount = View.GetRowCellValue(e.RowHandle, colBuy2Buy1Amount)
            CheckFieldAmount_Sell2Sell1Amount = View.GetRowCellValue(e.RowHandle, colSell2Sell1Amount)
            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colAmortizationToRiskDate_Part11))
                If CheckFieldAmount_AmortizationToRiskDate > 0 Then
                    IDW_Zinsertrag += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colAmortizationToRiskDate_Part11))
                If CheckFieldAmount_AmortizationToRiskDate < 0 Then
                    IDW_Zinsaufwand += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            If summaryID = 2 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colBuy2Buy1Amount))
                If CheckFieldAmount_Buy2Buy1Amount > 0 Then
                    IDW_Forderung_BuyAmount += Convert.ToDecimal(SumField)
                End If
                Dim SumField1 As Double = CDbl(View.GetRowCellValue(e.RowHandle, colSell2Sell1Amount))
                If CheckFieldAmount_Sell2Sell1Amount < 0 Then
                    IDW_Forderung_SellAmount += Convert.ToDecimal(SumField1)
                End If

                IDW_Forderung = IDW_Forderung_BuyAmount - IDW_Forderung_SellAmount
            End If
            If summaryID = 3 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colBuy2Buy1Amount))
                If CheckFieldAmount_Buy2Buy1Amount < 0 Then
                    IDW_Verbindlichkeit_BuyAmount += Convert.ToDecimal(SumField)
                End If
                Dim SumField1 As Double = CDbl(View.GetRowCellValue(e.RowHandle, colSell2Sell1Amount))
                If CheckFieldAmount_Sell2Sell1Amount > 0 Then
                    IDW_Verbindlichkeit_SellAmount += Convert.ToDecimal(SumField1)
                End If
                IDW_Verbindlichkeit = IDW_Verbindlichkeit_BuyAmount - IDW_Verbindlichkeit_SellAmount
            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = IDW_Zinsertrag
            End If
            If summaryID = 1 Then
                e.TotalValue = IDW_Zinsaufwand
            End If
            If summaryID = 2 Then
                e.TotalValue = IDW_Forderung
            End If
            If summaryID = 3 Then
                e.TotalValue = IDW_Verbindlichkeit
            End If
        End If
    End Sub

    Private Sub OpenPairs_Totals_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles OpenPairs_Totals_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            OpenPairs_Drohverlust = 0
            OpenPairs_Drohverlust_FX_Pairs = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldAmount_OpenPairs_Drohverlust = View.GetRowCellValue(e.RowHandle, colFV_Bewertungseinheit_Calc)
            CheckFieldAmount_OpenPairs_DrohverlustFX_Pairs = View.GetRowCellValue(e.RowHandle, colDrohverlustruckstellung_FX_Pairs)
            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colFV_Bewertungseinheit_Calc))
                If CheckFieldAmount_OpenPairs_Drohverlust < 0 Then
                    OpenPairs_Drohverlust += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colDrohverlustruckstellung_FX_Pairs))
                If CheckFieldAmount_OpenPairs_DrohverlustFX_Pairs < 0 Then
                    OpenPairs_Drohverlust_FX_Pairs += Convert.ToDecimal(e.FieldValue)
                End If
            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = OpenPairs_Drohverlust
            End If
            If summaryID = 1 Then
                e.TotalValue = OpenPairs_Drohverlust_FX_Pairs
            End If
        End If
    End Sub

    Private Sub OpenPaired_UNEF_Totals_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles OpenPaired_UNEF_Totals_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            OpenPairsUNEF_Drohverlust = 0
            OpenPairsUNEF_DrohverlustVJ = 0
            OpenPairsUNEF_DrohverlustTOTAL = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldAmount_OpenPairsUNEF_Drohverlust = View.GetRowCellValue(e.RowHandle, colKURSBEWERTUNG1)
            CheckFieldAmount_OpenPairsUNEF_DrohverlustVJ = View.GetRowCellValue(e.RowHandle, colDrohverlustRuckstellung_Vorjahr)
            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colKURSBEWERTUNG1))
                If CheckFieldAmount_OpenPairsUNEF_Drohverlust < 0 Then
                    OpenPairsUNEF_Drohverlust += Convert.ToDecimal(SumField)
                End If
                Dim SumField1 As Double = CDbl(View.GetRowCellValue(e.RowHandle, colDrohverlustRuckstellung_Vorjahr))
                If CheckFieldAmount_OpenPairsUNEF_DrohverlustVJ < 0 Then
                    OpenPairsUNEF_DrohverlustVJ += Convert.ToDecimal(SumField1)
                End If
                OpenPairsUNEF_DrohverlustTOTAL = OpenPairsUNEF_Drohverlust - OpenPairsUNEF_DrohverlustVJ
            End If
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colDrohverlustRuckstellung_Vorjahr))
                If CheckFieldAmount_OpenPairsUNEF_DrohverlustVJ < 0 Then
                    OpenPairsUNEF_DrohverlustVJ += Convert.ToDecimal(e.FieldValue)
                End If

            End If

        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 1 Then
                e.TotalValue = OpenPairsUNEF_DrohverlustVJ
            End If
            If summaryID = 0 Then
                e.TotalValue = OpenPairsUNEF_DrohverlustTOTAL
            End If
        End If
    End Sub

    Private Sub OpenUnpaired_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles OpenUnpaired_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            OpenUnpaired_Drohverlust = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldAmount_OpenUnpaired_Drohverlust = View.GetRowCellValue(e.RowHandle, GridColumn252)
            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, GridColumn252))
                If CheckFieldAmount_OpenUnpaired_Drohverlust < 0 Then
                    OpenUnpaired_Drohverlust += Convert.ToDecimal(e.FieldValue)
                End If
            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = OpenUnpaired_Drohverlust
            End If
        End If
    End Sub

    Private Sub ClosedSwaps_Part3_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles ClosedSwaps_Part3_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            ClosedSwaps_Zinsaufwand = 0
            ClosedSwaps_Zinsertrag = 0
            
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldAmount_ClosedSwaps = View.GetRowCellValue(e.RowHandle, colNET_AMT)

            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colNET_AMT))
                If CheckFieldAmount_ClosedSwaps < 0 Then
                    ClosedSwaps_Zinsaufwand += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colNET_AMT))
                If CheckFieldAmount_ClosedSwaps > 0 Then
                    ClosedSwaps_Zinsertrag += Convert.ToDecimal(e.FieldValue)
                End If
            End If
           
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = ClosedSwaps_Zinsaufwand
            End If
            If summaryID = 1 Then
                e.TotalValue = ClosedSwaps_Zinsertrag
            End If
          
        End If
    End Sub

#Region "LOAD TO EXCEL FILE"
    Private Sub FxEvaluationExcelFile_btn_Click(sender As Object, e As EventArgs) Handles FxEvaluationExcelFile_btn.Click
        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.FxDailyRevaluationDateEdit.Text)
                Dim rd As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim rdsql As String = rd.ToString("yyyyMMdd")


                '**********DATA LOAD***********
                '******************************
                Me.QueryText = "SELECT [DetailName],[DetailAmountBasicDate],[DetailAmountCurrentDate],[Result],[TotalResult] FROM [FX_BEWERTUNGEN_BUCHUNGEN_DETAILS] where  [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)


                SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                workbook.Worksheets(0).Cells("A1").Value = "FX EVALUATION RESULTS on: " & rd
                workbook.Worksheets(0).Cells("D6").Value = rd
                Dim OCBS_PL As Double = Me.PL_OCBS_TextEdit.Text
                Dim OCBS_TaxPay As Double = Me.TaxPayments_TextEdit.Text
                workbook.Worksheets(0).Cells("F2").Value = OCBS_PL
                workbook.Worksheets(0).Cells("F3").Value = OCBS_TaxPay
                workbook.Worksheets(0).Cells("F4").Formula = "=SUM(F2:F3)"


                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("B7:F1000"))

                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                'worksheet.Import(dt, False, 2, 0)
                worksheet.Import(dt, False, 6, 1)

                If dt.Rows.Count > 0 Then
                    'Adding Formulas at Runtime
                    Dim AddSumFormula As Integer = 0
                    Dim LastDtRow As Integer = dt.Rows.Count + 6
                    Dim ExcelCell As String = Nothing
                    Dim cell As Cell = Nothing

                    AddSumFormula = dt.Rows.Count + 7
                    ExcelCell = "F" & AddSumFormula
                    workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(F7:F" & LastDtRow & ")"
                    ExcelCell = "E" & AddSumFormula
                    workbook.Worksheets(0).Cells(ExcelCell).Value = "Summe"
                    ExcelCell = "E" & AddSumFormula + 1
                    workbook.Worksheets(0).Cells(ExcelCell).Value = "FX Effect on P/L"
                    ExcelCell = "F" & AddSumFormula + 1
                    LastDtRow = dt.Rows.Count + 6
                    workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(F4+F" & LastDtRow + 1 & ")"
                End If


                'Loading Open Pairs details
                Me.QueryText = "SELECT [PairNr],[CalculationArt],[OCBS_CI_NO],[ClientName ],[Client Type],[Bank Ind],[ContractNo],[Contract Type],[SPOT_FWD_SW_FLG],[AccountingCenter],[B/S],[Input Date],[Start Date],[End Date],[FAR_START_DATE],[FAR_END_DATE],[Deal Currency],[Deal Amount],[CCY_B],[AMT_B],[Status],[CCY_S],[AMT_S],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ] FROM [FX_BEWERTUNGEN_DETAILS] where [RiskDate]='" & rdsql & "' and [IdBewertungenTotals] is not NULL"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(2)
                workbook.Worksheets(2).Cells("A1").Value = "OPEN PAIRS EVALUATION DETAILS on: " & rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:AG5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                Dim OP_ALL_LastDtRow As Integer = 0
                If dt.Rows.Count > 0 Then
                    OP_ALL_LastDtRow = dt.Rows.Count + 2
                    Dim RangeOP_ALL_PL As CellRange = worksheet.Range("AD3:AD" & OP_ALL_LastDtRow)
                    RangeOP_ALL_PL.Formula = "=T3/X3-W3/Y3"
                    Dim RangeOP_DIFFERENCES As CellRange = worksheet.Range("AE3:AE" & OP_ALL_LastDtRow)
                    RangeOP_DIFFERENCES.Formula = "=AC3-AD3"
                    'Range for Formating Calculation
                    Dim RangeOP_ALL_FORMAT As CellRange = worksheet.Range("AF3:AF" & OP_ALL_LastDtRow)
                    RangeOP_ALL_FORMAT.Formula = "=IF(A3=A2;AF2;AF2+1)"
                    'Range for Sum Differences
                    Dim RangeOP_SUM_DIFFERENCES As CellRange = worksheet.Range("AG3:AG" & OP_ALL_LastDtRow)
                    RangeOP_SUM_DIFFERENCES.Formula = "=IF(A2=A3;"""";SUMIF(A3:A5000;A3;AE3:AE5000))"
                End If



                'Loading Open Pairs ALL TOTALS
                Me.QueryText = "SELECT [PAIR_NR],[Description] FROM [FX_BEWERTUNGEN_TOTALS] where RiskDate='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(1)
                workbook.Worksheets(1).Cells("A1").Value = "OPEN PAIRS EVALUATION TOTALS on: " & rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A4:F5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 3, 0)

                Dim OP_ALL_TOTALS_LastDtRow As Integer = 0
                If dt.Rows.Count > 0 Then
                    OP_ALL_TOTALS_LastDtRow = dt.Rows.Count + 3

                    Dim RangeOP_ALL_TOTALS_PL As CellRange = worksheet.Range("C4:C" & OP_ALL_TOTALS_LastDtRow)
                    RangeOP_ALL_TOTALS_PL.Formula = "=SUMIF('Open Pairs Evaluation (DETAILS)'!$A$3:$A$" & OP_ALL_LastDtRow & ";A4;'Open Pairs Evaluation (DETAILS)'!$AB$3:$AB$" & OP_ALL_LastDtRow & ")"

                    Dim RangeOP_ALL_TOTALS_FV_BW_1 As CellRange = worksheet.Range("D4:D" & OP_ALL_TOTALS_LastDtRow)
                    RangeOP_ALL_TOTALS_FV_BW_1.Formula = "=SUMIF('Open Pairs Evaluation (DETAILS)'!$A$3:$A$" & OP_ALL_LastDtRow & ";A4;'Open Pairs Evaluation (DETAILS)'!$AC$3:$AC$" & OP_ALL_LastDtRow & ")"

                    Dim RangeOP_ALL_TOTALS_FV_BW_2 As CellRange = worksheet.Range("E4:E" & OP_ALL_TOTALS_LastDtRow)
                    RangeOP_ALL_TOTALS_FV_BW_2.Formula = "=SUMIF('Open Pairs Evaluation (DETAILS)'!$A$3:$A$" & OP_ALL_LastDtRow & ";A4;'Open Pairs Evaluation (DETAILS)'!$AD$3:$AD$" & OP_ALL_LastDtRow & ")"

                    Dim RangeOP_ALL_TOTALS_SUM_DIFEFRENCE_PL As CellRange = worksheet.Range("F4:F" & OP_ALL_TOTALS_LastDtRow)
                    RangeOP_ALL_TOTALS_SUM_DIFEFRENCE_PL.Formula = "=IF(A3=A4;"""";SUMIF('Open Pairs Evaluation (DETAILS)'!$A$3:$A$" & OP_ALL_LastDtRow & ";A4;'Open Pairs Evaluation (DETAILS)'!$AE$3:$AE$" & OP_ALL_LastDtRow & "))"

                    Dim OP_ALL_TOTALS_SumDefault = OP_ALL_TOTALS_LastDtRow + 2
                    workbook.Worksheets(1).Cells("C" & OP_ALL_TOTALS_SumDefault).Formula = "=SUM(C4:C" & OP_ALL_TOTALS_LastDtRow & ")"
                    workbook.Worksheets(1).Cells("D" & OP_ALL_TOTALS_SumDefault).Formula = "=SUM(D4:D" & OP_ALL_TOTALS_LastDtRow & ")"
                    workbook.Worksheets(1).Cells("E" & OP_ALL_TOTALS_SumDefault).Formula = "=SUM(E4:E" & OP_ALL_TOTALS_LastDtRow & ")"

                    Dim OP_ALL_TOTALS_SumNew = OP_ALL_TOTALS_SumDefault + 1
                    workbook.Worksheets(1).Cells("E" & OP_ALL_TOTALS_SumNew).Formula = "=SUMIF(E4:E" & OP_ALL_TOTALS_LastDtRow & ";"">0"";" & "E4:E" & OP_ALL_TOTALS_LastDtRow & ")"

                    workbook.Worksheets(1).Cells("D" & OP_ALL_TOTALS_SumNew + 1).Value = "Drohverlustrückstellung aus Pärchenbildung (§254 HGB)"
                    workbook.Worksheets(1).Cells("E" & OP_ALL_TOTALS_SumNew + 1).Formula = "=SUMIF(E4:E" & OP_ALL_TOTALS_LastDtRow & ";""<0"";" & "E4:E" & OP_ALL_TOTALS_LastDtRow & ")"

                    workbook.Worksheets(1).Cells("D" & OP_ALL_TOTALS_SumNew + 2).Value = "Drohverlustrückstellung FX-Pärchen"
                    workbook.Worksheets(1).Cells("E" & OP_ALL_TOTALS_SumNew + 2).Formula = "=SUMIF(F4:F" & OP_ALL_TOTALS_LastDtRow & ";""<0"";" & "F4:F" & OP_ALL_TOTALS_LastDtRow & ")"

                End If



                'Loading Open Uneffective Pairs TOTALS
                Me.QueryText = "SELECT [PairNr],[Description],[CCY],[AMT_B],[AMT_S],0,[REVAL_RATE_DESCR],[REVAL_RATE],0,0,[DrohverlustRuckstellung_Vorjahr] FROM [FX_BEWERTUNGEN_UNEF_TOTALS] where [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(3)
                workbook.Worksheets(3).Cells("A1").Value = "OPEN UNEFFECTIVE PAIRS EVALUATION TOTALS on: " & rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A4:L5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 3, 0)

                Dim OP_UNEF_TOTALS_LastDtRow As Integer = 0
                If dt.Rows.Count > 0 Then
                    OP_UNEF_TOTALS_LastDtRow = dt.Rows.Count + 3

                    Dim RangeOP_UNEF_DIFF As CellRange = worksheet.Range("F4:F" & OP_UNEF_TOTALS_LastDtRow)
                    RangeOP_UNEF_DIFF.Formula = "=D4-E4"

                    Dim RangeOP_UNEF_KURSBEWERTUNG As CellRange = worksheet.Range("I4:I" & OP_UNEF_TOTALS_LastDtRow)
                    RangeOP_UNEF_KURSBEWERTUNG.Formula = "=F4/H4"

                    'Range for Formating Calculation
                    Dim RangeOP_UNEF_TOTALS_FORMAT As CellRange = worksheet.Range("J4:J" & OP_UNEF_TOTALS_LastDtRow)
                    RangeOP_UNEF_TOTALS_FORMAT.Formula = "=IF(A4=A3;J3;J3+1)"

                    'Range for Differenz Kurbewertung - Existierende Drohverlustrückstellung Vorjahr
                    Dim RangeOP_DIFFERENZ_KURSBEWERTUNG As CellRange = worksheet.Range("L4:L" & OP_UNEF_TOTALS_LastDtRow)
                    RangeOP_DIFFERENZ_KURSBEWERTUNG.Formula = "=IF(AND(I4<0;K4<0);I4-K4;0)"

                    Dim OP_UNEF_TOTALS_SumDefault = OP_UNEF_TOTALS_LastDtRow + 2
                    workbook.Worksheets(3).Cells("H" & OP_UNEF_TOTALS_SumDefault).Value = "Summe"
                    workbook.Worksheets(3).Cells("I" & OP_UNEF_TOTALS_SumDefault).Formula = "=SUM(I4:I" & OP_UNEF_TOTALS_LastDtRow & ")"
                    workbook.Worksheets(3).Cells("H" & OP_UNEF_TOTALS_SumDefault + 1).Value = "Drohverluste aus ineffektiven Pärchen"
                    workbook.Worksheets(3).Cells("I" & OP_UNEF_TOTALS_SumDefault + 1).Formula = "=SUMIF(I4:I" & OP_UNEF_TOTALS_LastDtRow & ";""<0"";" & "I4:I" & OP_UNEF_TOTALS_LastDtRow & ")-SUM(K4:K" & OP_UNEF_TOTALS_LastDtRow & ")"
                End If



                'Loading Unpaired (NO SWAPS) Details
                Me.QueryText = "SELECT [OCBS_CI_NO],[ClientName ],[Client Type],[Bank Ind],[ContractNo],[Contract Type],[SPOT_FWD_SW_FLG],[AccountingCenter],[B/S],[Input Date],[Start Date],[End Date],[FAR_START_DATE],[FAR_END_DATE],[Deal Currency],[Deal Amount],[CCY_B],[AMT_B],[Status],[CCY_S],[AMT_S],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate] FROM [FX_BEWERTUNGEN_DETAILS] where [RiskDate]='" & rdsql & "' and [CalculationArt] in ('UNPAIRED_NO_SWAP')"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(4)
                workbook.Worksheets(4).Cells("A1").Value = "OPEN UNPAIRED - NO SWAPS  on: " & rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:AC5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                Dim UP_ALL_LastDtRow As Integer = 0
                If dt.Rows.Count > 0 Then
                    UP_ALL_LastDtRow = dt.Rows.Count + 2
                    Dim UP_TOTALS_SumDefault = UP_ALL_LastDtRow + 2
                    workbook.Worksheets(4).Cells("Z" & UP_TOTALS_SumDefault).Value = "Drohverluste aus einzelnen FX-Geschäften"
                    workbook.Worksheets(4).Cells("AA" & UP_TOTALS_SumDefault).Formula = "=SUMIF(AA4:AA" & UP_ALL_LastDtRow & ";""<0"";" & "AA4:AA" & UP_ALL_LastDtRow & ")"
                Else
                    workbook.Worksheets(4).Cells("Z4").Value = "Drohverluste aus einzelnen FX-Geschäften"
                    workbook.Worksheets(4).Cells("AA4").Value = 0
                End If



                'Loading OPEN SWAPS (Own Deals) Besondere Deckung Teil 1
                Me.QueryText = "SELECT [ClientNo],[ClientName],[ContractNr],[DealType],[DealStatus],[DealSellBuy],[InputDate],[ValueDate],[MaturityDate],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[PL_inEUR_Equ],[SpotBuyRate],[SpotSellRate],[RevalBuyRate_1],[RevalSellRate_1],[TradeBuyRate],[TradeSellRate] FROM [FX DAILY REVALUATION] where OwnDeal in ('Y') and [DealStatus]='U' and [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(5)
                worksheet.Cells("C1").Value = rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:AK5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                Dim OW_BD1_LastDtRow As Integer = 0
                If dt.Rows.Count > 0 Then
                    OW_BD1_LastDtRow = dt.Rows.Count + 2
                    Dim RangeOW_BD1_U As CellRange = worksheet.Range("U3:U" & OW_BD1_LastDtRow)
                    RangeOW_BD1_U.Formula = "=(K3/S3)-(M3/T3)"
                    Dim RangeOW_BD1_V As CellRange = worksheet.Range("V3:V" & OW_BD1_LastDtRow)
                    RangeOW_BD1_V.Formula = "=(U3/(I3-H3))*(($C$1-H3))"
                    Dim RangeOW_BD1_W As CellRange = worksheet.Range("W3:W" & OW_BD1_LastDtRow)
                    RangeOW_BD1_W.Formula = "=(K3/Q3)-(K3/S3)"
                    Dim RangeOW_BD1_X As CellRange = worksheet.Range("X3:X" & OW_BD1_LastDtRow)
                    RangeOW_BD1_X.Formula = "=(M3/R3)-(M3/T3)"
                    Dim RangeOW_BD1_Y As CellRange = worksheet.Range("Y3:Y" & OW_BD1_LastDtRow)
                    RangeOW_BD1_Y.Formula = "=W3-X3"
                    Dim RangeOW_BD1_Z As CellRange = worksheet.Range("Z3:Z" & OW_BD1_LastDtRow)
                    RangeOW_BD1_Z.Formula = "=V3+Y3-N3"
                    Dim RangeOW_BD1_AA As CellRange = worksheet.Range("AA3:AA" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AA.Formula = "=K3/S3"
                    Dim RangeOW_BD1_AB As CellRange = worksheet.Range("AB3:AB" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AB.Formula = "=M3/T3"
                    Dim RangeOW_BD1_AC As CellRange = worksheet.Range("AC3:AC" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AC.Formula = "=AA3-AB3"
                    Dim RangeOW_BD1_AD As CellRange = worksheet.Range("AD3:AD" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AD.Formula = "=K3/O3"
                    Dim RangeOW_BD1_AE As CellRange = worksheet.Range("AE3:AE" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AE.Formula = "=M3/P3"
                    Dim RangeOW_BD1_AF As CellRange = worksheet.Range("AF3:AF" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AF.Formula = "=AD3-AE3"

                    Dim RangeOW_BD1_AG As CellRange = worksheet.Range("AG3:AG" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AG.Formula = "=K3/Q3"
                    Dim RangeOW_BD1_AH As CellRange = worksheet.Range("AH3:AH" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AH.Formula = "=M3/R3"
                    Dim RangeOW_BD1_AI As CellRange = worksheet.Range("AI3:AI" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AI.Formula = "=AG3-AH3"

                    Dim RangeOW_BD1_AJ As CellRange = worksheet.Range("AJ3:AJ" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AJ.Formula = "=AC3-(AF3-AI3)"

                    Dim RangeOW_BD1_AK As CellRange = worksheet.Range("AK3:AK" & OW_BD1_LastDtRow)
                    RangeOW_BD1_AK.Formula = "=IF(AJ3-V3>0;AJ3-V3;0)"

                    'Sums
                    Dim OW_BD1_SUMS As Integer = OW_BD1_LastDtRow + 1
                    worksheet.Cells("V" & OW_BD1_SUMS).Formula = "=SUM(V3:V" & OW_BD1_LastDtRow & ")"
                    worksheet.Cells("Y" & OW_BD1_SUMS).Formula = "=SUM(Y3:Y" & OW_BD1_LastDtRow & ")"
                    worksheet.Cells("Z" & OW_BD1_SUMS).Formula = "=SUM(Z3:Z" & OW_BD1_LastDtRow & ")"
                    worksheet.Cells("AJ" & OW_BD1_SUMS).Formula = "=SUM(AJ3:AJ" & OW_BD1_LastDtRow & ")"
                    worksheet.Cells("AK" & OW_BD1_SUMS).Formula = "=SUM(AK3:AK" & OW_BD1_LastDtRow & ")"
                End If



                'Loading OPEN SWAPS (Own Deals) Besondere Deckung Teil 2
                Me.QueryText = "SELECT [ClientNo],[ClientName],[ContractNr],[InputDate],[ValueDate],[MaturityDate],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[PL_EUR],[PL_inEUR_Equ],[SpotBuyRate],[SpotSellRate],[TradeBuyRate],[TradeSellRate] FROM [FX DAILY REVALUATION] where [OwnDeal]='Y' and [DealStatus]='U' and [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(6)
                worksheet.Cells("C1").Value = rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:V5000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                If dt.Rows.Count > 0 Then
                    Dim OW_BD2_LastDtRow As Integer = dt.Rows.Count + 2
                    Dim RangeOW_BD2_Q As CellRange = worksheet.Range("Q3:Q" & OW_BD2_LastDtRow)
                    RangeOW_BD2_Q.Formula = "=(H3/O3)-(J3/P3)"
                    Dim RangeOW_BD2_R As CellRange = worksheet.Range("R3:R" & OW_BD2_LastDtRow)
                    RangeOW_BD2_R.Formula = "=(Q3/(F3-D3))*(($C$1-D3))"
                    Dim RangeOW_BD2_S As CellRange = worksheet.Range("S3:S" & OW_BD2_LastDtRow)
                    RangeOW_BD2_S.Formula = "=(H3/M3)-(H3/O3)"
                    Dim RangeOW_BD2_T As CellRange = worksheet.Range("T3:T" & OW_BD2_LastDtRow)
                    RangeOW_BD2_T.Formula = "=(J3/N3)-(J3/P3)"
                    Dim RangeOW_BD2_U As CellRange = worksheet.Range("U3:U" & OW_BD2_LastDtRow)
                    RangeOW_BD2_U.Formula = "=S3-T3"
                    Dim RangeOW_BD2_V As CellRange = worksheet.Range("V3:V" & OW_BD2_LastDtRow)
                    RangeOW_BD2_V.Formula = "=R3+U3-L3"

                    Dim OW_BD2_SUMS As Integer = OW_BD2_LastDtRow + 1
                    worksheet.Cells("R" & OW_BD2_SUMS).Formula = "=SUM(R3:R" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("S" & OW_BD2_SUMS).Formula = "=SUM(S3:S" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("T" & OW_BD2_SUMS).Formula = "=SUM(T3:T" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("U" & OW_BD2_SUMS).Formula = "=SUM(U3:U" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("V" & OW_BD2_SUMS).Formula = "=SUM(V3:V" & OW_BD2_LastDtRow & ")"

                    Dim OW_BD2_SUMS_Ertrag_Forderung As Integer = OW_BD2_SUMS + 3
                    Dim OW_BD2_SUMS_Aufwand_Verbindlichkeit As Integer = OW_BD2_SUMS + 4

                    worksheet.Cells("Q" & OW_BD2_SUMS_Ertrag_Forderung).Value = "Zinsertrag"
                    worksheet.Cells("R" & OW_BD2_SUMS_Ertrag_Forderung).Formula = "=SUMIF(R3:R" & OW_BD2_LastDtRow & ";"">0"";" & "R3:R" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("T" & OW_BD2_SUMS_Ertrag_Forderung).Value = "Forderung"
                    worksheet.Cells("U" & OW_BD2_SUMS_Ertrag_Forderung).Formula = "=SUMIF(S3:S" & OW_BD2_LastDtRow & ";"">0"";" & "S3:S" & OW_BD2_LastDtRow & ")-SUMIF(T3:T" & OW_BD2_LastDtRow & ";""<0"";" & "T3:T" & OW_BD2_LastDtRow & ")"

                    worksheet.Cells("Q" & OW_BD2_SUMS_Aufwand_Verbindlichkeit).Value = "Zinsaufwand"
                    worksheet.Cells("R" & OW_BD2_SUMS_Aufwand_Verbindlichkeit).Formula = "=SUMIF(R3:R" & OW_BD2_LastDtRow & ";""<0"";" & "R3:R" & OW_BD2_LastDtRow & ")"
                    worksheet.Cells("T" & OW_BD2_SUMS_Aufwand_Verbindlichkeit).Value = "Verbindlichkeit"
                    worksheet.Cells("U" & OW_BD2_SUMS_Aufwand_Verbindlichkeit).Formula = "=SUMIF(S3:S" & OW_BD2_LastDtRow & ";""<0"";" & "S3:S" & OW_BD2_LastDtRow & ")-SUMIF(T3:T" & OW_BD2_LastDtRow & ";"">0"";" & "T3:T" & OW_BD2_LastDtRow & ")"

                End If


                'Loading CLOSED SWAPS  Besondere Deckung Teil 3
                Me.QueryText = "SELECT [ClientNr],[ClientName],[ContractNr],[TradeDate],[ValueDate],[MaturityDate],[CCY_B],[AMT_B],[CCY_S],[AMT_S],[SpotBuyRate_ECB],[SpotSellRate_ECB] FROM [FX_BEWERTUNGEN_CLOSED_SWAPS] where RiskDate='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                '+++++++++++++++++++++++
                'Find Last Day Last Year
                Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim LastYear As Integer = (d.Year) - 1
                '++++++++++++++++++
                worksheet = workbook.Worksheets(7)
                worksheet.Cells("C1").Value = rd
                Dim LastSayLastYear As Date = DateSerial(LastYear, 12, 31)
                worksheet.Cells("M1").Value = LastSayLastYear
                worksheet.Cells("M2").Value = "Days Count from 31.12." & LastYear.ToString & " till Maturity Date (Last Years Deals)"
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:Q10000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                If dt.Rows.Count > 0 Then
                    Dim OW_BD3_LastDtRow As Integer = dt.Rows.Count + 2
                    Dim RangeOW_BD3_M As CellRange = worksheet.Range("M3:M" & OW_BD3_LastDtRow)
                    RangeOW_BD3_M.Formula = "=IF(E3<=$M$1;F3-$M$1;0)"
                    Dim RangeOW_BD3_N As CellRange = worksheet.Range("N3:N" & OW_BD3_LastDtRow)
                    RangeOW_BD3_N.Formula = "=IF(M3<>0;F3-E3;0)"
                    Dim RangeOW_BD3_O As CellRange = worksheet.Range("O3:O" & OW_BD3_LastDtRow)
                    RangeOW_BD3_O.Formula = "=H3/K3"
                    Dim RangeOW_BD3_P As CellRange = worksheet.Range("P3:P" & OW_BD3_LastDtRow)
                    RangeOW_BD3_P.Formula = "=-J3/L3"
                    Dim RangeOW_BD3_Q As CellRange = worksheet.Range("Q3:Q" & OW_BD3_LastDtRow)
                    RangeOW_BD3_Q.Formula = "=IF(AND(N3<>0;D3<=$M$1);((O3+P3)/N3)*M3;IF(AND(N3<>0;D3>$M$1);((O3+P3)/M3)*N3;IF(N3=0;O3+P3)))"

                    'Set Conditional formating only for FX Deals with Value Date<=Last Day Last Year
                    'Dim RangeOW_BD3_AllData As CellRange = worksheet.Range("A3:A" & OW_BD3_LastDtRow)
                    'Dim cfRule As FormulaExpressionConditionalFormatting = worksheet.ConditionalFormattings.AddFormulaExpressionConditionalFormatting(RangeOW_BD3_AllData, "MOD(ROW(),2)=1")
                    'cfRule.Formatting.Fill.BackgroundColor = Color.FromArgb(255, &HBC, &HDA, &HF7)


                    Dim OW_BD3_SUMS As Integer = OW_BD3_LastDtRow + 1
                    worksheet.Cells("Q" & OW_BD3_SUMS).Formula = "=SUM(Q3:R" & OW_BD3_LastDtRow & ")"

                    Dim OW_BD3_SUMS_Zinsaufwand As Integer = OW_BD3_SUMS + 2
                    Dim OW_BD3_SUMS_Zinsertrag As Integer = OW_BD3_SUMS + 3
                    worksheet.Cells("P" & OW_BD3_SUMS_Zinsaufwand).Value = "Zinsaufwand"
                    worksheet.Cells("Q" & OW_BD3_SUMS_Zinsaufwand).Formula = "=SUMIF(Q3:Q" & OW_BD3_LastDtRow & ";""<0"";" & "Q3:Q" & OW_BD3_LastDtRow & ")"
                    worksheet.Cells("P" & OW_BD3_SUMS_Zinsertrag).Value = "Zinsertrag"
                    worksheet.Cells("Q" & OW_BD3_SUMS_Zinsertrag).Formula = "=SUMIF(Q3:Q" & OW_BD3_LastDtRow & ";"">0"";" & "Q3:Q" & OW_BD3_LastDtRow & ")"
                End If


                'Loading FX DAILY REVALUATION - Only Valid Deals
                Me.QueryText = "SELECT [ClientNo],[ClientName],[ContractNr],[DealType],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[DealStatus],[NPV],[DiscountRate] FROM  [FX DAILY REVALUATION] where MaturityDate>='" & rdsql & "' and RiskDate='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                worksheet = workbook.Worksheets(8)
                worksheet.Cells("A1").Value = "FX DAILY REVALUATION REPORT (Only Valid Deals)  on: " & rd
                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:X10000"))
                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)


                'Save Excel File
                workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)

                'Load Excel Form
                Dim c As New ExcelForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "FX EVALUATION on " & rd
                c.SpreadsheetControl1.ReadOnly = True

                workbookN = c.SpreadsheetControl1.Document
                Using stream As New FileStream(ExcelFileName, FileMode.Open)
                    workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
                End Using


                SplashScreenManager.CloseForm(False)

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try

        End If
    End Sub
#End Region

End Class