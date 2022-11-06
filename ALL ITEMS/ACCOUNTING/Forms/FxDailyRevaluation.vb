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



Public Class FxDailyRevaluation
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
    Dim PL_ExcelFileName As String = Nothing

    Dim ContractNr As String = Nothing

    Dim customSum As Decimal = 0
    Dim customSum1 As Decimal = 0

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


    Private Sub FX_DAILY_REVALUATIONBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FX_DAILY_REVALUATIONBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub FxDailyRevaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='IDW_OCBS_Revaluation_Difference_ExcelFile_Directory' and [IdABTEILUNGSPARAMETER]='IDW_OCBS_REVALUATION_DIFF' and [PARAMETER STATUS]='Y'"
        ExcelFileName = cmd.ExecuteScalar
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='PL_Revaluation_Methods_Directory' and [IdABTEILUNGSPARAMETER]='IDW_OCBS_REVALUATION_DIFF' and [PARAMETER STATUS]='Y'"
        PL_ExcelFileName = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

        'Bind Combobox
        Me.FxDailyRevaluationDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [FX DAILY REVALUATION] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
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
        Dim MaxFxDailyRevaluationDate As Date = Me.FxDailyRevaluationDateEdit.Text
       
        'Get the dates from RISK LIMIT DAILY CONTROL where Risk Bearing Capacity<>0
        'Me.QueryText = "select Distinct([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS] ORDER BY [EXCHANGE RATE DATE] desc  "
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New DataTable()
        'da.Fill(dt)
        'For Each row As DataRow In dt.Rows
        'Dim ExchangeDate As Date = Row("EXCHANGE RATE DATE")
        'Dim FormatedExchangeDate As String = ExchangeDate.ToString("dd.MM.yyyy")
        'Me.SpotRateDate.Properties.Items.Add(FormatedExchangeDate)
        'Next
        'Me.SpotRateDate.Text = dt.Rows.Item(0).Item("EXCHANGE RATE DATE")


        Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_DAILY_REVALUATION, MaxFxDailyRevaluationDate)
        Me.FX_DAILY_REVALUATION_ALL_CONTRACTS_TableAdapter.Fill(Me.AccountingDataSet.FX_DAILY_REVALUATION_ALL_CONTRACTS)

        Me.FxDailyRevaluation_BasicView.ExpandAllGroups()


    End Sub

    Private Sub FxDailyRevaluation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If Me.FxDailyRevaluation_AdvBandedGridView.IsFindPanelVisible Then
        'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        'Dim find As FindControl = TryCast(FxDailyRevaluation_AdvBandedGridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        'find.FindEdit.Focus()
        'Else
        'FxDailyRevaluation_AdvBandedGridView.ShowFindPanel()
        'End If
    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.FX_DAILY_REVALUATIONBindingSource.EndEdit()
                If Me.AccountingDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                        Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_DAILY_REVALUATION, Me.FxDailyRevaluationDateEdit.Text)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

       
    End Sub

    Private Sub LoadFxDailyRevaluation_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FxDailyRevaluationDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FxDailyRevaluationDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.FX_DAILY_REVALUATIONBindingSource

            If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
                Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                'Load Data
                Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_DAILY_REVALUATION, d)
                SplashScreenManager.CloseForm(False)

            End If


            Me.FxDailyRevaluation_BasicView.ExpandAllGroups()
        End If
    End Sub

    Private Sub FxDailyRevaluationDateEdit_Click(sender As Object, e As EventArgs) Handles FxDailyRevaluationDateEdit.Click
        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

   
    Private Sub FxDailyRevaluationDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FxDailyRevaluationDateEdit.KeyDown
        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub Print_Export_FxDailyRevaluation_AdvancedGridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_FxDailyRevaluation_AdvancedGridview_btn.Click
        If ActiveTabGroup = "1" Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = "2" Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = "3" Then
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
        Dim reportfooter As String = "FX DAILY REVALUATION on " & Me.FxDailyRevaluationDateEdit.Text
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
        Dim reportfooter As String = "IDW + OCBS FX Revaluation Differences on " & Me.FxDailyRevaluationDateEdit.Text
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
        Dim reportfooter As String = "ALL FX DEALS (TRADING SWAP OWN DEALS) definition on " & Me.FxDailyRevaluationDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub SpotRateDate_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles SpotRateDate.ButtonClick
        If e.Button.Caption = "Calculate Capital Adequacy" Then
            If IsDate(Me.SpotRateDate.Text) = True Then
                'Default Date
                Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                'Selected Exchange Date
                Dim SpotDate As Date = Me.SpotRateDate.Text
                Dim SqlSpotDate As String = SpotDate.ToString("yyyyMMdd")
                'Set all relevant Data to NULL or 0
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [SpotRateDate]=NULL,[SpotRate]=0,[CapitalAdequancy]=0,[MatchingSpotRate]=0,[MatchingCapitalAdequancy]=0  where [RiskDate]='" & dsql & "'"
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [SpotRateDate]='" & SqlSpotDate & "'where [RiskDate]='" & dsql & "'"
                cmd.ExecuteNonQuery()
                'Set first Spot Rate
                cmd.CommandText = "UPDATE A SET A.[SpotRateDate]=B.[EXCHANGE RATE DATE],A.[SpotRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON B.[EXCHANGE RATE DATE]='" & SqlSpotDate & "' where [RiskDate]='" & dsql & "' and A.[BuyCCY]=B.[CURRENCY CODE]"
                cmd.ExecuteNonQuery()
                'set matching Rate
                cmd.CommandText = "UPDATE A SET A.[MatchingSpotRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON B.[EXCHANGE RATE DATE]='" & SqlSpotDate & "' where [RiskDate]='" & dsql & "' and A.[MatchingBuyCCY]=B.[CURRENCY CODE]"
                cmd.ExecuteNonQuery()
                'Set 1 if Currency =EUR
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [SpotRate]=1  where [RiskDate]='" & dsql & "' and [BuyCCY]='EUR'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [MatchingSpotRate]=1  where [RiskDate]='" & dsql & "' and [MatchingBuyCCY]='EUR'"
                cmd.ExecuteNonQuery()
                'Calculate Capital Adequancy
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [CapitalAdequancy]=Round([BuyAmount]/[SpotRate],2),[MatchingCapitalAdequancy]=Round([MatchingBuyAmount]/[MatchingSpotRate],2) where [RiskDate]='" & dsql & "'"
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
                'Me.LoadFxDailyRevaluation_btn.PerformClick()
                Me.SpotRateDate.Text = ""
            End If

        End If
    End Sub

    Private Sub FxDailyRevaluation_AdvBandedGridView_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs)
        'If e.Column.Caption = "Count" Then
        'Dim count As Double = CDbl(e.RowHandle.ToString) + 1
        'e.DisplayText = count
        'End If
    End Sub

    Private Sub FxDailyRevaluation_AdvBandedGridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs)
        'e.Info.DisplayText = e.RowHandle.ToString

    End Sub

    Private Sub FxDailyRevaluation_AdvBandedGridView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs)
        Dim View As GridView = CType(sender, GridView)
        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            customSum = 0
            customSum1 = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim CheckField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "PL_inEUR_Equ"))
            If CheckField > 0 Then
                customSum += Convert.ToDecimal(e.FieldValue)
            End If
            'Dim CheckField1 As Double = CDbl(View.GetRowCellValue(e.RowHandle, "Matching_PL_inEUR_Equ"))
            'If CheckField1 > 0 Then
            'customSum1 += Convert.ToDecimal(e.FieldValue)
            'End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            e.TotalValue = customSum + customSum1
        End If

    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl1 Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing
        Dim view As GridView = TryCast(GridControl1.GetViewAt(e.ControlMousePosition), GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing AndAlso hi.Column.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then
            If hi.Column.FieldName = "PL_inEUR_Equ" Then
                Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                info = New ToolTipControlInfo(o, text)
            Else
                Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
                Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                info = New ToolTipControlInfo(o, text)
            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
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

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "FX DEALS - DAILY REVALUATION" Then
            ActiveTabGroup = "1"
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "IDW + OCBS FX Revaluation Differences" Then
            ActiveTabGroup = "2"
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "FX TRADING SWAPS (OWN DEALS)" Then
            ActiveTabGroup = "3"
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

    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
       
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

    Private Sub FxDailyRevaluationDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FxDailyRevaluationDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.FX_DAILY_REVALUATIONBindingSource

        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Dim d As Date = Me.FxDailyRevaluationDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
            'Load Data
            Me.FX_DAILY_REVALUATIONTableAdapter.FillByRiskDate(Me.AccountingDataSet.FX_DAILY_REVALUATION, d)

            SplashScreenManager.CloseForm(False)
          
        End If


        Me.FxDailyRevaluation_BasicView.ExpandAllGroups()
    End Sub

    Private Sub RepositoryItemImageComboBox2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox2.EditValueChanged
        ContractNr = Me.GridView3.GetFocusedRowCellDisplayText(colContractNr2)
        If ContractNr <> "" Then
            Try
                Me.GridView3.PostEditor()

                Dim OwnDealValueStatus As String = Me.GridView3.GetFocusedRowCellValue(colOwnDeal1).ToString
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET OwnDeal='" & OwnDealValueStatus & "' where ContractNr='" & ContractNr & "' and DealStatus in ('U')"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.FX_DAILY_REVALUATION_ALL_CONTRACTS_TableAdapter.Fill(Me.AccountingDataSet.FX_DAILY_REVALUATION_ALL_CONTRACTS)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End Try
        End If


    End Sub

    

    Private Sub IDW_To_Excel_btn_Click(sender As Object, e As EventArgs) Handles IDW_To_Excel_btn.Click
        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.FxDailyRevaluationDateEdit.Text)
                Dim rd As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim rdsql As String = rd.ToString("yyyyMMdd")

               
                '******Get Next Target working Date***********
                Me.QueryText = "IF (Select dbo.GetNextTARGETWorkingDay('" & rdsql & "'))<(Select DATEADD(m, DATEDIFF(m, -1, '" & rdsql & "'), 0)) begin Select dbo.GetNextTARGETWorkingDay('" & rdsql & "') as 'Date','Next Working Date' as 'Day' end else begin Select DATEADD(m, DATEDIFF(m, -1, '" & rdsql & "'), 0) as 'Date','First Day of Next Month' as 'Day' end"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                Dim NextWorkingDate As Date = dt.Rows.Item(0).Item("Date")
                Dim Description As String = dt.Rows.Item(0).Item("Day")
               
                '**********DATA LOAD***********
                '******************************
                Me.QueryText = "SELECT [ContractNr],[ClientNo],[ClientName],[InputDate],[ValueDate],[MaturityDate],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[PL_EUR],[PL_inEUR_Equ],[SpotBuyRate],[SpotSellRate],[TradeBuyRate],[TradeSellRate],0 as 'Trade Date Buy Sell Amount',0 as 'Amortization To Risk Date',0 as 'Buy2Buy1Amount',0 as 'Sell2Sell1Amount',0 as 'IDW_Amount',0 as 'Difference OCBS P/L and IDW Amount (Standard Method)',[DealStatus],[OwnDeal],[CUR_BUY_FX_ALL],[AMT_BUY_FX_ALL],[CUR_SELL_FX_ALL],[AMT_SELL_FX_ALL],[END_DATE_FX_ALL],[DATEDIFF_END_DATE],[DATEDIFF_MAT_DATE] FROM [FX DAILY REVALUATION] where [OwnDeal]='Y' and [DealStatus]='U' and [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)


                SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                workbook.Worksheets(0).Cells("D1").Value = rd
                workbook.Worksheets(0).Cells("AC1").Value = Description
                workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate
                workbook.Worksheets(0).Cells("AD2").Value = "Days Count (End Date - " & Description & ")"

                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A3:AF5000"))

                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 2, 0)

                Dim IDW_LastDtRow As Integer = dt.Rows.Count + 2
                Dim RangeIDW_Q As Range = worksheet.Range("Q3:Q" & IDW_LastDtRow) 'Trade Date Buy Sell Amount
                RangeIDW_Q.Formula = "=(H3/O3)-(J3/P3)"
                Dim RangeIDW_R As Range = worksheet.Range("R3:R" & IDW_LastDtRow) 'Amortization to Risk Date
                RangeIDW_R.Formula = "=(Q3/(F3-D3))*(($D$1-D3)+1)"
                Dim RangeIDW_S As Range = worksheet.Range("S3:S" & IDW_LastDtRow) 'Buy2Buy1Amount
                RangeIDW_S.Formula = "=(H3/M3)-(H3/O3)"
                Dim RangeIDW_T As Range = worksheet.Range("T3:T" & IDW_LastDtRow) 'Sell2Sell1Amount
                RangeIDW_T.Formula = "=(J3/N3)-(J3/P3)"
                Dim RangeIDW_U As Range = worksheet.Range("U3:U" & IDW_LastDtRow) 'IDW_Amount (Standard)
                RangeIDW_U.Formula = "=S3-T3"
                Dim RangeIDW_V As Range = worksheet.Range("V3:V" & IDW_LastDtRow) 'Difference IDW_Amount (Standard)
                RangeIDW_V.Formula = "=R3+U3-L3"
                Dim RangeIDW_AD As Range = worksheet.Range("AD3:AD" & IDW_LastDtRow) 'Datediff End Date - Next Woprking Date or First Date Next Month
                RangeIDW_AD.Formula = "=IF($D$1>=AC3;$AD$1-AC3;0)"
                Dim RangeIDW_AE As Range = worksheet.Range("AE3:AE" & IDW_LastDtRow) 'Datediff End Date - Maturity Date
                RangeIDW_AE.Formula = "=IF($D$1>=AC3;F3-AC3;0)"
                Dim RangeIDW_AF As Range = worksheet.Range("AF3:AF" & IDW_LastDtRow) 'Difference IDW_Amount (Internal)
                RangeIDW_AF.Formula = "=IF(AD3<>0;(((H3-AB3)/O3)-((J3-Z3)/P3))*(AD3/AE3)+((H3/M3)-(J3/N3))-(((H3-AB3)/O3)-((J3-Z3)/P3))-L3;L3*(-1))"

                Dim SumRow As Integer = IDW_LastDtRow + 1
                worksheet.Cells("U" & SumRow).Formula = "=SUM(U3:U" & IDW_LastDtRow & ")"
                worksheet.Cells("V" & SumRow).Formula = "=SUM(V3:V" & IDW_LastDtRow & ")"
                worksheet.Cells("AF" & SumRow).Formula = "=SUM(AF3:AF" & IDW_LastDtRow & ")"

                'Save Excel File
                workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)

                'Load Excel Form
                Dim c As New ExcelForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "IDW - OCBS Daily Revaluation difference on " & rd
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

    Private Sub PL_Results_To_Excel_btn_Click(sender As Object, e As EventArgs) Handles PL_Results_To_Excel_btn.Click
        If IsDate(Me.FxDailyRevaluationDateEdit.Text) = True Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.FxDailyRevaluationDateEdit.Text)
                Dim rd As Date = Me.FxDailyRevaluationDateEdit.Text
                Dim rdsql As String = rd.ToString("yyyyMMdd")

                '**********DATA LOAD***********
                '******************************
                Me.QueryText = "SELECT [RLDC Date],[PL Result],[BUBA_InterestAmount],0 as 'Profit_after_NagativeInterest',[PLdifferenceOCBS_IDW],0 as 'Profit_after_IDW',[PLdifferenceOCBS_IDW_INTERN] FROM [RISK LIMIT DAILY CONTROL] where [PLdifferenceOCBS_IDW_INTERN] <>0 and [RLDC Date]>=DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) and [RLDC Date]<=DATEADD (dd, -1, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) +1, 0)) and Client_Lock=0 order by [RLDC Date] desc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)


                SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(PL_ExcelFileName, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                'workbook.Worksheets(0).Cells("D1").Value = rd
                'workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate

                SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
                worksheet.ClearContents(worksheet("A2:H5000"))

                SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
                worksheet.Import(dt, False, 1, 0)

                Dim PL_IDW_LastDtRow As Integer = dt.Rows.Count + 1
                Dim RangePL_IDW_D As Range = worksheet.Range("D2:D" & PL_IDW_LastDtRow) 'Trade Date Buy Sell Amount
                RangePL_IDW_D.Formula = "=B2+C2"
                Dim RangePL_IDW_F As Range = worksheet.Range("F2:F" & PL_IDW_LastDtRow) 'Amortization to Risk Date
                RangePL_IDW_F.Formula = "=D2+E2"
                Dim RangePL_IDW_H As Range = worksheet.Range("H2:H" & PL_IDW_LastDtRow) 'Buy2Buy1Amount
                RangePL_IDW_H.Formula = "=D2+G2"
                

                'Save Excel File
                workbook.SaveDocument(PL_ExcelFileName, DocumentFormat.OpenXml)

                'Load Excel Form
                Dim c As New ExcelForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "Profit/Loss results on " & rd
                c.SpreadsheetControl1.ReadOnly = True

                workbookN = c.SpreadsheetControl1.Document
                Using stream As New FileStream(PL_ExcelFileName, FileMode.Open)
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
End Class