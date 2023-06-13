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
Imports Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet



Public Class RunClient

    Dim conn As New SqlClient.SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing
    Dim connEVENT As New SqlClient.SqlConnection
    Dim cmdEVENT As New SqlCommand

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem


    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable

    Dim RunClient_btn_clicked As Boolean = False 'Button for Start Client

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim MaxProcDate As Date
    Dim CheckingDate As Date
    Dim CheckingDateSql As String = Nothing
    Dim LastDayCurrentMonth As Date
    Dim FirstDayOverNextMonth As Date
    Dim HasDataResult As String = Nothing

    Dim CurrentClientProcedure As String = Nothing

    Dim wck As Double = 0
    Dim summeAM1 As Double = 0
    Dim summeAM2 As Double = 0

    Dim sumCreditRiskAmountEUR As Double = 0
    Dim sumCreditOutstandingEURequ As Double = 0
    Dim sumMAKEuroEquivalent As Double = 0
    Dim sumdifference As Double = 0
    Dim sumNetCreditRiskAmountEUR As Double = 0
    Dim sumNetCreditRiskAmountEUR45 As Double = 0
    Dim BadRefinaceSoldFounded As Double = 0
    Dim SumPledgedVariableDepositsCustomer As Double = 0




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

    Private Sub CLIENT_EVENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CLIENT_EVENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

    Private Sub RunClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwClientRun.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub RunClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT
        cmdEVENT.CommandTimeout = 60000

        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [CLIENT EVENTS]"
        cmd.Connection.Open()
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            MaxProcDate = cmd.ExecuteScalar
        Else
            MaxProcDate = DateSerial(2014, 9, 30)
        End If
        cmd.Connection.Close()

        'Bind Combobox
        Me.ClientDateFrom_Comboedit.Properties.Items.Clear()
        Me.ClientDateTill_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' and [PL Result] is not NULL and [Client_Lock]=0 ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ClientDateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))
                Me.ClientDateTill_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.ClientDateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
            Me.ClientDateTill_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If


        Me.CLIENT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.CLIENT_EVENTS, MaxProcDate)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwClientRun.IsBusy = True Then
                If MessageBox.Show("Should the PS TOOL Client be terminated?", "TERMINATE PS TOOL CLIENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwClientRun.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("PS TOOL Client termination is requested..." & vbNewLine & "Please wait until the current Client operations are finished!")
                End If
            End If
        End If
    End Sub

    Private Sub RunClient_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.CLIENT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.CLIENT_EVENTS, MaxProcDate)
        End If
    End Sub

    Private Sub ClientEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ClientEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ClientEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_ClientEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ClientEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "CLIENT EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub StartClient_btn_Click(sender As Object, e As EventArgs) Handles StartClient_btn.Click
        RunClient_btn_clicked = True
        If OutstandingNewCustomerAlert = 0 AndAlso OutstandingRatingAlert = 0 Then
            If IsDate(Me.ClientDateFrom_Comboedit.Text) = True Then
                If MessageBox.Show("Should the PS TOOL Client be started?", "START PS TOOL Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_IMPORT()
                    If Me.BgwClientRun.IsBusy = False Then
                        Me.BgwClientRun.RunWorkerAsync()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Unable to proceed with the PS TOOL Client execution" & vbNewLine & "since Alert messages are displayed!" & vbNewLine & "Please respond to the displayed Alert messages!!", "PS TOOL Client stopped!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return

        End If

    End Sub

#Region "ENABLE_DISABLE_CONTROLS_BY_CLIENT_RUN"
    Private Sub DISABLE_START_IMPORT()
        Me.ClientProgressBar.Visible = True
        StartClient_btn.Enabled = False
        Me.ClientDateFrom_Comboedit.Enabled = False
        Me.ClientDateTill_Comboedit.Enabled = False
    End Sub

    Private Sub ENABLE_FINISH_IMPORT()
        Me.ClientProgressBar.Value = 0
        Me.ClientProgressBar.Visible = False
        StartClient_btn.Enabled = True
        Me.ClientDateFrom_Comboedit.Enabled = True
        Me.ClientDateTill_Comboedit.Enabled = True
    End Sub
#End Region

    Private Sub BgwClientRun_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwClientRun.DoWork
        If Me.ClientDateFrom_Comboedit.Text <> "" And Me.ClientDateTill_Comboedit.Text <> "" Then
            Dim d1 As Date = Me.ClientDateFrom_Comboedit.Text
            Dim sqld1 As String = d1.ToString("yyyyMMdd")
            Dim d2 As Date = Me.ClientDateTill_Comboedit.Text
            Dim sqld2 As String = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then

                Try
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Connection.Open()
                    cmd.CommandTimeout = 50000


                    'Select all requested Dates
                    Me.BgwClientRun.ReportProgress(1, "Select all requested Dates to run the Client")
                    Me.QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='" & sqld1 & "' and [RLDC Date]<='" & sqld2 & "' and [Client_Lock]=0 ORDER BY [RLDC Date] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For Each row As DataRow In dt.Rows
                        rd = row("RLDC Date")
                        rdsql = rd.ToString("yyyyMMdd")
                        If Me.BgwClientRun.CancellationPending = False Then

                            Me.BgwClientRun.ReportProgress(50, "Starting PS TOOL Client for " & rd)
                            'PROCEDURES
                            LIQUIDITY_RESERVE_CALCULATION()
                            KEST_SOLI_CALCULATION()
                            CASH_FLOWS()
                            INTEREST_RATE_RISK_CALCULATION()
                            CREDIT_RISK_MAK_CALCULATION()
                            NEW_CREDIT_BUSINESS()
                            FX_CREDIT_EQUIV_CALCULATION()
                            FX_EVALUATION()
                            IRS_CREDIT_EQUIV_CALCULATION()
                            'IRS_CREDIT_EQUIV_CALCULATION_FINRECON()
                            'CREDIT_RISK_MAK_CALCULATION_FINRECON()

                            CREDIT_RISK_MAK_UPDATE()
                            UNEXPECTED_LOSS_CALCULATION()

                            BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION()
                            'BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION_FINRECON()

                            BUSINESS_TYPE_LIABILITIES_CALCULATION()
                            'BUSINESS_TYPE_LIABILITIES_CALCULATION_FINRECON()
                            STRESS_TESTS_HEAD_OFFICE_CALCULATION()
                            FORMBLATT_BALANCE_CALCULATION()
                            CURRENCY_RISK_CALCULATION()
                            CAR_CALCULATION()
                            ANTICYCLIC_CALCULATION()
                            LiqV_CALCULATION()
                            HGB_GV_CALCULATION()
                            HGB_BS_CALCULATION()
                            RLDC_UPDATE()
                            RISK_BEARING_CAPACITY_CALCULATION()
                            MINDESTRESERVE_CALCULATION()
                            LOAN_EXPOSURE_CORPORATES()
                            DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION()
                            DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION()
                            DAILY_ART13_KWG_CENTRAL_GOVERMENT()
                            LIQUIDITY_OVERVIEW_DATA_COLLECTION()
                            ANACREDIT_DATA_COLLECT()
                            GENERAL_INFO_DATA_COLLECT()

                            'TEST()

                            'UPDATE_AWVz14z15() 'Only on Scedule Task
                            'LOAD_LOANS_TRANSACTIONS() 'Only on Scedule Task
                            'NOSTRO_RECONCILIATION() ' Sceduled Task


                            Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for " & rd & " is finished!")

                        ElseIf Me.BgwClientRun.CancellationPending = True Then
                            Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for " & rd & " is terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                            'MessageBox.Show("PS TOOL Client is terminated!", "PS TOOL Client termination", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        End If


                    Next

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                Catch ex As Exception
                    Me.BgwClientRun.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End Try

            End If
        End If
    End Sub

    Private Sub BgwClientRun_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwClientRun.ProgressChanged
        Dim ClientEvent As String = e.UserState
        Me.ClientProgressBar.Value = e.ProgressPercentage

        Dim stackFrame As New Diagnostics.StackFrame()
        Dim rtnName As String = stackFrame.GetMethod.Name.ToString()
        rtnName = rtnName & stackFrame.GetMethod.DeclaringType.FullName.ToString()

        cmdEVENT.Connection.Open()
        cmdEVENT.CommandTimeout = 500
        Try
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & ClientEvent & "','" & CurrentClientProcedure & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & CurrentClientProcedure & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [CLIENT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.CLIENT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.CLIENT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwClientRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwClientRun.RunWorkerCompleted
        ENABLE_FINISH_IMPORT()

        'Set Button Click as default to False
        RunClient_btn_clicked = False

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If



    End Sub

    Private Sub LIQUIDITY_RESERVE_CALCULATION()
        'LIQUIDITY_RESERVE
        CurrentClientProcedure = "LIQUIDITY RESERVE"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_RESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(2, "Current Date for Client execution: " & rd)
            cmd.CommandText = "SELECT [Date] FROM [SECURITIES_DailyPrice] WHERE [Date]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute LIQUIDITY RESERVE calculation for: " & rd)
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute LIQUIDITY RESERVE Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next


            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "No Securities Market Prices indicated for Risk Date: " & rd)
            End If


            Me.BgwClientRun.ReportProgress(16, "LIQUIDITY RESERVE calculation finished for: " & rd)
        Else
            Me.BgwClientRun.ReportProgress(5, "LIQUIDITY_RESERVE STATUS is Deactivated")
        End If
    End Sub

    Private Sub KEST_SOLI_CALCULATION()
        'KAPITALERTRAGSTEUER-SOLI CALCULATION
        CurrentClientProcedure = "KEST_SOLI_CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('KEST_SOLI_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute LIQUIDITY RESERVE calculation for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('KEST_SOLI_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute KEST_SOLI_CALCULATION Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next

            Me.BgwClientRun.ReportProgress(16, "KEST_SOLI_CALCULATION  finished for: " & rd)
        Else
            Me.BgwClientRun.ReportProgress(5, "KEST_SOLI_CALCULATION STATUS is Deactivated")
        End If
    End Sub

    Private Sub CASH_FLOWS()
        CurrentClientProcedure = "CASH FLOWS"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CASH_FLOWS') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute CASH_FLOWS for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CASH_FLOWS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.BgwClientRun.ReportProgress(8, "CASH_FLOWS finished ")
        Else
            Me.BgwClientRun.ReportProgress(5, "CASH_FLOWS is Invalid")
        End If
    End Sub

    Private Sub INTEREST_RATE_RISK_CALCULATION()
        'INTEREST RATE RISK
        CurrentClientProcedure = "INTEREST RATE RISK"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('INTEREST_RATE_RISK_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(2, "Current Date for Client execution: " & rd)
            cmd.CommandText = "SELECT [RISK DATE] FROM [RATERISK DETAILS ALL DATA] WHERE [RISK DATE]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute INTEREST RATE RISK calculation for: " & rd)
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('INTEREST_RATE_RISK_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute IRR Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

                
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If


            Me.BgwClientRun.ReportProgress(16, "INTEREST RATE RISK calculation finished for: " & rd)
        Else
            Me.BgwClientRun.ReportProgress(5, "INTEREST_RATE_RISK_CALCULATION STATUS is Deactivated")
        End If
    End Sub

    Private Sub CREDIT_RISK_MAK_CALCULATION()
        'CREDIT RISK + MAK
        CurrentClientProcedure = "CREDIT RISK and MAK"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CREDIT_RISK_MAK_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'Daten mit dem aktuellen rd datum löschen
            cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute CREDIT RISK + MAK Calculations for: " & rd)
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CREDIT_RISK_MAK_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute CREDIT RISK + MAK Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next


                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'CASH PLEDGE - CREDIT RISK
                'Me.BgwClientRun.ReportProgress(18, "Define Cashpledge in CREDIT RISK")
                'Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y' and [ValidTill]>= '" & rdsql & "'"
                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                'dt = New System.Data.DataTable()
                'da.Fill(dt)
                'For i = 0 To dt.Rows.Count - 1
                '    Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                '    Me.QueryText = "select * from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                '    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                '    dt1 = New System.Data.DataTable()
                '    da1.Fill(dt1)
                '    For y = 0 To dt1.Rows.Count - 1
                '        Dim CreditOutstandingEURequ As Double = dt1.Rows.Item(y).Item("Credit Outstanding (EUR Equ)")
                '        If CreditOutstandingEURequ < CashPledgeAmount Then
                '            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                '            cmd.ExecuteNonQuery()
                '            CashPledgeAmount = CashPledgeAmount - CreditOutstandingEURequ
                '        ElseIf CreditOutstandingEURequ > CashPledgeAmount Then
                '            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]='" & Str(CreditOutstandingEURequ - CashPledgeAmount) & "',[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                '            cmd.ExecuteNonQuery()
                '            CashPledgeAmount = 0
                '        ElseIf CreditOutstandingEURequ = CashPledgeAmount Then
                '            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                '            cmd.ExecuteNonQuery()
                '            CashPledgeAmount = 0
                '        End If
                '    Next
                'Next
               


            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "CREDIT_RISK_MAK_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub CREDIT_RISK_MAK_CALCULATION_FINRECON()
        'CREDIT RISK + MAK
        CurrentClientProcedure = "CREDIT RISK and MAK"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_BT_CREDIT_RISK') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'Daten mit dem aktuellen rd datum löschen
            cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(1, "Delete all Data from CREDIT RISK for " & rd)
                cmd.CommandText = "DELETE  FROM [CREDIT RISK] where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(1, "Delete all Data from MAK REPORT for " & rd)
                cmd.CommandText = "DELETE  FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(1, "Delete all Data from MAK CR TOTALS for " & rd)
                cmd.CommandText = "DELETE FROM [MAK CR TOTALS] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Neuanlage in MAK CREDIT RISK DATES
                Me.BgwClientRun.ReportProgress(2, "Insert new Risk Date in MAK CR TOTALS")
                cmd.CommandText = "INSERT INTO [MAK CR TOTALS]([RiskDate],[USER],[IdBank]) Values('" & rdsql & "','" & "imported from " & " " & SystemInformation.UserName & " on " & " " & Today & "','3') "
                cmd.ExecuteNonQuery()
                'Neuanlage in CREDIT RISK
                Me.BgwClientRun.ReportProgress(16, "SQL PARAMETER: CREDIT_RISK_MAK_CALCULATION - Execute Steps")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CREDIT_RISK_MAK_CALCULATION')) and [Status] in ('Y') ORDER BY [SQL_Float_1] asc"
                da2 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt2 = New System.Data.DataTable()
                da2.Fill(dt2)
                For i = 0 To dt2.Rows.Count - 1
                    Dim SqlCommandText As String = dt2.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt2.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types - CREDIT RISK: " & dt2.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If

                Next

                cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Outstanding (Org Ccy)]=[PrincipalAmount_OrigCUR]+[AccruedAmount_OrigCUR],[Credit Outstanding (EUR Equ)]=[PrincipalAmount_EUR]+[AccruedAmount_EUR] where [Credit Outstanding (Org Ccy)]=0 and RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[Contract Type]=B.ContractType,A.[Product Type]=B.ProductType,A.[GL Master / Account Type]=B.Master_Nr, A.StartDate=B.StartDate ,A.[Maturity Date]=B.MaturityDate from [CREDIT RISK] A INNER JOIN FINRECON_NG B on A.[Contract Collateral ID]=B.Contract_Nr_Clear and A.RiskDate=B.RiskDate where A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[Remaining Year(s) to Maturity]=CASE when B.Remaining_Maturity is not NULL then CEILING(Remaining_Maturity/365) else 1 end from [CREDIT RISK] A INNER JOIN FINRECON_NG B on A.[Contract Collateral ID]=B.Contract_Nr_Clear and A.RiskDate=B.RiskDate where A.[Remaining Year(s) to Maturity] is NULL and B.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [Remaining Year(s) to Maturity]=1 where [Remaining Year(s) to Maturity]=0 and RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                'Neuanlage in MAK REPORT
                Me.BgwClientRun.ReportProgress(4, "Insert Data in MAK REPORT for " & rd)
                cmd.CommandText = "INSERT INTO [MAK REPORT]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[DateMakCrTotals])Select [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[RiskDate] FROM [MAK REPORT ALL DATA] where [DateMakCrTotals]='" & rdsql & "' and [Contract Type] not in ('FXD','FXMK','SWAP','LIMIT')"
                cmd.ExecuteNonQuery()
               
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.BgwClientRun.ReportProgress(5, "Update INDUSTRIAL CLASS LOCAL in MAK REPORT for " & rd)
                cmd.CommandText = "Update A set A.[IndustrialClassLocalCode]=B.[INDUSTRIAL_CLASS_LOCAL],A.[IndustrialClassLocalCodeName]=B.[INDUSTRIAL_CLASS_LOCAL_NAME] FROM [MAK REPORT] A INNER JOIN [CUSTOMER_INFO] B ON A.[Client No]=B.[ClientNo] where A.[IndustrialClassLocalCode] is NULL and A.[DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Einfügen des WORKING CAPITALS von RATERISK DATE
                Me.BgwClientRun.ReportProgress(6, "Insert Working Capital from RATERISK DATE in MAK CR TOTALS for " & rd)
                cmd.CommandText = "UPDATE[MAK CR TOTALS] SET [WorkingCapital]=(Select [Working Capital] from [RATERISK DATE]  WHERE [RateRiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.BgwClientRun.ReportProgress(7, "Define SPCODE=Industry(HO), LBCODE=Counterparty/Issuer/Collateral Provider in MAK REPORT for " & rd)
                'Anfrage des SPCODES,LBCODES und SPCODES
                cmd.CommandText = "UPDATE[MAK REPORT] SET [SPCODE]=[Industry(HO)],[LBCODE]=[Counterparty/Issuer/Collateral Provider] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(7, "Define SPCODE from Parameter:MAKREPSPCODE")
                'cmd.CommandText = "UPDATE A SET A.[SPCODE]=B.S from [MAK REPORT] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='MAKREPSPCODE' and [PARAMETER STATUS] ='Y')B ON A.[Counterparty/Issuer/Collateral Provider] like B.[PARAMETER1] where A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(7, "Define SPCODE=CCBG based on CUSTOMER_INFO-CCB Group-Y")
                cmd.CommandText = "UPDATE A SET A.[SPCODE]='CCBG' from [MAK REPORT] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo  where  B.CCB_Group='Y' and  A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(7, "Define SPCODE=BUBA based on CUSTOMER_INFO-Central Bank-Y")
                cmd.CommandText = "UPDATE A SET A.[SPCODE]='BUBA' from [MAK REPORT] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo  where  B.Central_Bank='Y' and  A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Me.BgwClientRun.ReportProgress(7, "Define LBCODE from Parameter:MAKREPLBCODE")
                'cmd.CommandText = "UPDATE A SET A.[LBCODE]=B.S from [MAK REPORT] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='MAKREPLBCODE' and [PARAMETER STATUS] ='Y')B ON A.[Counterparty/Issuer/Collateral Provider] like B.[PARAMETER1] where A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(7, "Define LBCODE=CHINA INVESTMENT CO. LTD based on CUSTOMER_INFO-CIC Group-Y")
                cmd.CommandText = "UPDATE A SET A.[LBCODE]='CHINA INVESTMENT CO. LTD' from [MAK REPORT] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo  where  B.CIC_Group='Y' and  A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(7, "Define LBCODE=DEUTSCHE BUNDESBANK based on CUSTOMER_INFO-Central Bank-Y")
                cmd.CommandText = "UPDATE A SET A.[LBCODE]='DEUTSCHE BUNDESBANK' from [MAK REPORT] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo  where  B.Central_Bank='Y' and  A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwClientRun.ReportProgress(7, "Calculate the USD Equivalent based on the EURO Equivalent in MAK REPORT for " & rd)
                cmd.CommandText = "UPDATE A Set A.USD_Equivalent=ROUND(A.[Euro Equivalent]*B.[MIDDLE RATE],2) from [MAK REPORT] A INNER JOIN [EXCHANGE RATES OCBS] B on A.RiskDate=B.[EXCHANGE RATE DATE] where A.RiskDate='" & rdsql & "' and B.[CURRENCY CODE]='USD'"
                cmd.ExecuteNonQuery()


                'CUSTOMER TYPE IN MAK REPORT DEFINIEREN
                Me.BgwClientRun.ReportProgress(8, "Define CUSTOMER TYPE in MAK REPORT for " & rd)
                cmd.CommandText = "UPDATE [MAK REPORT] set [CUSTOMER TYPE]=B.[ClientType] from [MAK REPORT] A INNER JOIN [CUSTOMER_INFO] B ON A.[Client No]=B.[ClientNo] where A.[CUSTOMER TYPE] is NULL and  A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.BgwClientRun.ReportProgress(9, "Define CLIENT GROUP NAME from Parameter REPORT/CLIENT_GROUP_DEFINE")
                cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.S from [CUSTOMER_RATING] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='CLIENT_GROUP_DEFINE' and [PARAMETER STATUS] ='Y')B ON A.[ClientGroup]=B.[PARAMETER1]"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(10, "Define SUB CLIENT GROUP NAME from Parameter REPORT/SUB_CLIENT_GROUP_DEFINE")
                cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.NewClientGroup, A.[ClientGroupName]=B.ClientGroupName from [CUSTOMER_RATING] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as ClientGroupName , [PARAMETER INFO] as NewClientGroup from [PARAMETER] where [IdABTEILUNGSPARAMETER]='SUB_CLIENT_GROUP_DEFINE' and [PARAMETER STATUS] ='Y')B ON A.[ClientNo]=B.[PARAMETER1]"
                cmd.ExecuteNonQuery()



                Me.BgwClientRun.ReportProgress(11, "Set CLIENT GROUP=0 if CLIENT GROUP is Null")
                cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]='0' where [ClientGroup] is NULL "
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(11, "Set CLIENT GROUP=CLIENT NO if CLIENT GROUP=0")
                cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=[ClientNo]  where [ClientGroup]='0'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(11, "Define CLIENT GROUP NAME if is NULL")
                cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroupName]=[ClientName] where [ClientGroupName] is NULL "
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(11, "Modify CLIENT GROUP in MAK REPORT based on CUSTOMER RATING")
                cmd.CommandText = "UPDATE A SET A.[Client Group]=B.[ClientGroup] from [MAK REPORT] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()



                'Update Obligor Grates from Customer Ratings
                Me.BgwClientRun.ReportProgress(13, "Update Obligor Grates,PD,ER,CLIENT GROUP,CLIENT GROUP NAME and all relevant ratings from CUSTOMER RATING Tables")
                cmd.CommandText = "UPDATE A SET A.[Obligor Rate]=B.[Rating],A.[PD]=B.[PD],A.[(1-ER_45)]=B.[LGD],A.[CoreDefinition]=B.[CoreDefinition] FROM [CREDIT RISK] A INNER JOIN [CUSTOMER_RATING_DETAILS] B ON A.[Client No]=B.[ClientNo] WHERE A.[RiskDate]='" & rdsql & "' and A.[RiskDate] BETWEEN B.[Valid_From] and B.[Valid_Till] and B.[RatingType] in ('INTERNAL')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(13, "Set PD,LGD to 0 for CENTRAL BANK")
                cmd.CommandText = "UPDATE A SET A.PD=0,A.[(1-ER_45)]=0,A.InternalInfo='CENTRAL BANK' from [CREDIT RISK] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo where B.Central_Bank in ('Y') and A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(13, "Set PD,LGD to 0 for CCB Branches")
                cmd.CommandText = "UPDATE A SET A.PD=0,A.[(1-ER_45)]=0,A.InternalInfo='CCB BRANCH' from [CREDIT RISK] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo where B.CCB_Group in ('Y') and B.CCB_Group_OwnID in ('N')  and A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] FROM [CREDIT RISK] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] WHERE A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'SPECIAL FALL LGD 20 % in specific Product and Business Types
                Me.BgwClientRun.ReportProgress(16, "Check SQL PARAMETER STATUS for SQL PARAMETER:CREDIT_RISK_LGD_20_SPECIAL")
                cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CREDIT_RISK_LGD_20_SPECIAL'"
                Dim CreditRiskLGD20_Special_Result As String = cmd.ExecuteScalar
                If CreditRiskLGD20_Special_Result = "Y" Then
                    Me.BgwClientRun.ReportProgress(16, "SQL PARAMETER: CREDIT_RISK_LGD_20_SPECIAL is VALID - Execute SQL Commands for CREDIT_RISK_LGD_20_SPECIAL")
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CREDIT_RISK_LGD_20_SPECIAL')"
                    da2 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt2 = New System.Data.DataTable()
                    da2.Fill(dt2)
                    For i = 0 To dt2.Rows.Count - 1
                        Dim SqlCommandText As String = dt2.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    Next
                Else
                    Me.BgwClientRun.ReportProgress(16, "SQL PARAMETER: CREDIT_RISK_LGD_20_SPECIAL is INVALID - No Further Action")
                End If


                'Calculating CreditRiskAmount again
                Me.BgwClientRun.ReportProgress(17, "Calculating Credit Risk Amount (Expected Loss)  based on the new PD,ER for defined Obligor Grates (No Rating)")
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('No Rating')"
                cmd.ExecuteNonQuery()


                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'CASH PLEDGE - CREDIT RISK
                Me.BgwClientRun.ReportProgress(18, "Define Cashpledge in CREDIT RISK")
                Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y' and [ValidTill]>= '" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                    Me.QueryText = "select * from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New System.Data.DataTable()
                    da1.Fill(dt1)
                    For y = 0 To dt1.Rows.Count - 1
                        Dim CreditOutstandingEURequ As Double = dt1.Rows.Item(y).Item("Credit Outstanding (EUR Equ)")
                        If CreditOutstandingEURequ < CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = CashPledgeAmount - CreditOutstandingEURequ
                        ElseIf CreditOutstandingEURequ > CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]='" & Str(CreditOutstandingEURequ - CashPledgeAmount) & "',[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = 0
                        ElseIf CreditOutstandingEURequ = CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('No Rating')"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = 0
                        End If
                    Next
                Next
                'Credit Risk Outstanding Amount auf NetCreditRiskOutstandingAmount stellen wenn InternalInfo<>CASHPLEDGE
                Me.BgwClientRun.ReportProgress(19, "Set NetCreditOutstandingAmountEUR=Credit Risk Amount(EUR Equ) where InternalInfo not CASHPLEDGE")
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] Where [RiskDate]='" & rdsql & "' and [InternalInfo] not in ('CASHPLEDGE')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(20, "Recalculating Credit Risk Amount (Expected Loss) again based on the new PD,ER for defined Obligor Grates (No Rating)")
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('No Rating')"
                cmd.ExecuteNonQuery()

                Me.BgwClientRun.ReportProgress(25, "Calculating the Credit Outstanding (EUR Equ) SUM from CREDIT RISK Table,the Euro Equivalent SUM from MAK REPORT Table and Inserting of the Credit Outstanding (EUR Equ) SUM,Euro Equivalent SUM and their calculated difference in MAK CR TOTALS Table")
                cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditOutstandingEURequ]=(SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'),[SumEuroEquivalent]=(SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "'),[SumsDifference]=(SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "')- (SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "') WHERE [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                Me.BgwClientRun.ReportProgress(28, "Calculating the NetCredit Risk Amount(EUR Equ) SUM from CREDIT RISK Table ,the NetCreditRiskAmountEUREquER45 SUM from CREDIT RISK Table and Inserting of the NetCredit Risk Amount(EUR Equ) and  NetCreditRiskAmountEUREquER45 SUM in MAK CR TOTALS Table")
                cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRiskCashpledge45]=(SELECT Sum([NetCreditRiskAmountEUREquER45]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "') WHERE [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "CREDIT_RISK_MAK_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub NEW_CREDIT_BUSINESS()
        CurrentClientProcedure = "NEW CREDIT BUSINESS"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('NEW_CREDIT_BUSINESS') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\NEW CREDIT BUSINESS")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('NEW_CREDIT_BUSINESS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute NEW CREDIT BUSINESS Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "NEW_CREDIT_BUSINESS STATUS is Invalid")
        End If
    End Sub

    Private Sub FX_CREDIT_EQUIV_CALCULATION()
        CurrentClientProcedure = "FX CREDIT EQUIVALENT CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FX_CREDIT_EQUIV_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start the FX CREDIT EQUIVELANT CALCULATION for " & rd)
            cmd.CommandText = "SELECT [RiskDate] FROM [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\FX_CREDIT_EQUIV_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FX_CREDIT_EQUIV_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute FX CREDIT EQUIVALENT Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(16, "The daily FX CREDIT EQUIVALENT CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "FX_CREDIT_EQUIV_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub FX_EVALUATION()
        CurrentClientProcedure = "FX EVALUATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FX EVALUATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute FX EVALUATION for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FX EVALUATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute FX EVALUATION: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next



            '***********************************
            '+++++ONLY IN APPLICATION+++++++++
            Me.BgwClientRun.ReportProgress(8, "Check if ECB Rates exists for: " & rd)
            cmd.CommandText = "Select Count(*) from (Select CCY_B,TradeDate from [FX_BEWERTUNGEN_CLOSED_SWAPS] where [RiskDate]='" & rdsql & "' and [SpotBuyRate_ECB]=1 and [CCY_B] not in ('EUR') GROUP BY CCY_B,TradeDate)A"
            Dim Result_BUY As Double = cmd.ExecuteScalar
            If Result_BUY > 0 Then
                Me.QueryText = "Select CCY_B,TradeDate from [FX_BEWERTUNGEN_CLOSED_SWAPS] where [RiskDate]='" & rdsql & "' and [SpotBuyRate_ECB]=1 and [CCY_B] not in ('EUR') GROUP BY CCY_B,TradeDate"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim INFO_BUY As String = Nothing

                    For i = 0 To dt.Rows.Count - 1
                        Dim TradeDate As Date = dt.Rows.Item(i).Item("TradeDate")
                        INFO_BUY += dt.Rows.Item(i).Item("CCY_B") & "  " & TradeDate & vbNewLine
                    Next
                    MessageBox.Show("There are no ECB Exchange Rates for the following BUY Currencies/Trade Dates:" & vbNewLine & INFO_BUY & vbNewLine & vbNewLine & "Please insert the missing ECB Exchange Rates and restart PS TOOL Client again!!", "ECB EXCHANGE RATES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.BgwClientRun.ReportProgress(8, "ERROR - There are no ECB Exchange Rates for the following BUY Currencies/Trade Dates:" & vbNewLine & INFO_BUY)
                    Return
                End If
            End If
            cmd.CommandText = "Select Count(*) from (Select CCY_S,TradeDate from [FX_BEWERTUNGEN_CLOSED_SWAPS] where [RiskDate]='" & rdsql & "' and [SpotSellRate_ECB]=1 and [CCY_S] not in ('EUR') GROUP BY CCY_S,TradeDate)A"
            Dim Result_SELL As Double = cmd.ExecuteScalar
            If Result_SELL > 0 Then
                Me.QueryText = "Select CCY_S,TradeDate from [FX_BEWERTUNGEN_CLOSED_SWAPS] where [RiskDate]='" & rdsql & "' and [SpotSellRate_ECB]=1 and [CCY_S] not in ('EUR') GROUP BY CCY_S,TradeDate"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim INFO_SELL As String = Nothing

                    For i = 0 To dt.Rows.Count - 1
                        Dim TradeDate As Date = dt.Rows.Item(i).Item("TradeDate")
                        INFO_SELL += dt.Rows.Item(i).Item("CCY_S") & "  " & TradeDate & vbNewLine
                    Next
                    MessageBox.Show("There are no ECB Exchange Rates for the following SELL Currencies/Trade Dates:" & vbNewLine & INFO_SELL & vbNewLine & vbNewLine & "Please insert the missing ECB Exchange Rates and restart PS TOOL Client again!!", "ECB EXCHANGE RATES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.BgwClientRun.ReportProgress(8, "ERROR - There are no ECB Exchange Rates for the following SELL Currencies/Trade Dates:" & vbNewLine & INFO_SELL)
                    Return
                End If
            End If

            Me.BgwClientRun.ReportProgress(8, "FX EVALUATION finished ")
        Else
            Me.BgwClientRun.ReportProgress(5, "FX EVALUATION STATUS is Invalid")
        End If
    End Sub

    Private Sub IRS_CREDIT_EQUIV_CALCULATION()
        CurrentClientProcedure = "IRS CREDIT EQUIVALENT CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IRS_CREDIT_EQUIV_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then

            Me.BgwClientRun.ReportProgress(1, "Start the IRS CREDIT EQUIVELANT CALCULATION for " & rd)
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\IRS_CREDIT_EQUIV_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IRS_CREDIT_EQUIV_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute IRS CREDIT EQUIVALENT Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If

            Me.BgwClientRun.ReportProgress(16, "The daily IRS CREDIT EQUIVELANT CALCULATION is finished")
        Else

            Me.BgwClientRun.ReportProgress(5, "IRS_CREDIT_EQUIV_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub IRS_CREDIT_EQUIV_CALCULATION_FINRECON()
        'If rd > DateSerial(2017, 5, 25) Then
        CurrentClientProcedure = "IRS CREDIT EQUIVALENT CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IRS_CREDIT_EQUIV_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then

            Me.BgwClientRun.ReportProgress(1, "Start the IRS CREDIT EQUIVELANT CALCULATION for " & rd)
            cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE  FROM [IRS CREDIT EQUIVALENT Basic] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Import Data in details
                Me.BgwClientRun.ReportProgress(2, "Insert Data in IRS CREDIT EQUIVALENT Details from FINRECON_NG where Contract Type in (SWAP,SWPS) and MaturityDate > RiskDate for " & rd)
                cmd.CommandText = "INSERT INTO [IRS CREDIT EQUIVALENT Details]([Class],[ContractType],[ProductType],[GL_Master_Account_Type],[Contract],[Counterparty_Name],[Counterparty_No],[StartDate],[Final_Maturity_Date],[OrgCcy],[OrgCcyAmount],[RiskDate]) SELECT 'IRS',[ContractType],[ProductType],Master_Nr,Contract_Nr_Clear,Client_Name,Client_Nr,StartDate,MaturityDate,CCY,ABS(Amount_Equ),[RiskDate]from [FINRECON_NG]   where [ContractType] in ('SWAP','SWPS') and [MaturityDate]>[RiskDate] and ProductType in ('IR') and GL_Groups in ('Off-balance') and NG_GL_Nr is not NULL and Amount_ID in ('PA') and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Update Client Group in Details
                Me.BgwClientRun.ReportProgress(3, "Update Client Group Nr. and client Group Name in IRS CREDIT EQUIVALENT Details from CUSTOMER_RATING")
                cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] from [IRS CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update Client Group in Details
                Me.BgwClientRun.ReportProgress(4, "Set Client Group and Name to UNDEFINED if Client Nr is NULL")
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] SET [ClientGroup]=999999,[ClientGroupName]='UNDEFINED GROUP' where [Counterparty_No] is NULL and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(5, "Set Client Group=Client Nr in IRS CREDIT EQUIVALENT Details where Client Group is NULL")
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] SET [ClientGroup]=[Counterparty_No],[ClientGroupName]=[Counterparty_Name]  where [ClientGroup] is NULL and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update OCBS Exchange Rates-Last working day
                Me.BgwClientRun.ReportProgress(6, "Update Exchange Rates in IRS CREDIT EQUIVALENT Details")
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] set [ExchangeRate]=1 where [OrgCcy]='EUR' and [ExchangeRate] is NULL and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] from [IRS CREDIT EQUIVALENT Details] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[ExchangeRate] is NULL and B.[EXCHANGE RATE DATE]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Calculate EuroEquivelant
                Me.BgwClientRun.ReportProgress(7, "Calculate Euro Equivalent nominal amount in IRS CREDIT EQUIVALENT Details")
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] set [EURequ]=Round([OrgCcyAmount]/[ExchangeRate],2) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteScalar()
                'Import Data in Basic
                Me.BgwClientRun.ReportProgress(8, "Import Data in IRS CREDIT EQUIVALENT Basic")
                cmd.CommandText = "INSERT INTO [IRS CREDIT EQUIVALENT Basic]([RiskDate],[ClientGroup])select [RiskDate],[ClientGroup] from [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [RiskDate],[ClientGroup]"
                cmd.ExecuteNonQuery()
                'Update Client Group Name
                Me.BgwClientRun.ReportProgress(9, "Update Client Group Name in IRS CREDIT EQUIVALENT Basic")
                cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN [IRS CREDIT EQUIVALENT Details] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate] and A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details
                Me.BgwClientRun.ReportProgress(10, "Update Id_IRS_CRED_EQU_BASIC in IRS CREDIT EQUIVALENT Details")
                cmd.CommandText = "UPDATE A set A.[Id_IRS_CRED_EQU_BASIC]=B.[ID] from [IRS CREDIT EQUIVALENT Details] A INNER JOIN [IRS CREDIT EQUIVALENT Basic] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate] and A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update PD,LGD,Obligor Rate in FX CREDIT EQUIVALENT Details
                Me.BgwClientRun.ReportProgress(11, "Update PD,LGD,Obligor Rate in IRS CREDIT EQUIVALENT Details")
                cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[LGD]=B.[LGD],A.[Obligor Rate]=B.[Rating] from [IRS CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING_DETAILS] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "' and A.[RiskDate] between B.[Valid_From] and B.[Valid_Till] and B.[RatingType] in ('INTERNAL')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(13, "Set PD,LGD to 0 for CENTRAL BANK")
                cmd.CommandText = "UPDATE A SET A.PD=0,A.[LGD]=0 from [IRS CREDIT EQUIVALENT Details] A INNER JOIN CUSTOMER_INFO B on A.[Counterparty_No]=B.ClientNo where B.Central_Bank in ('Y') and A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(13, "Set PD,LGD to 0 for CCB Branches")
                cmd.CommandText = "UPDATE A SET A.PD=0,A.[LGD]=0 from [IRS CREDIT EQUIVALENT Details] A INNER JOIN CUSTOMER_INFO B on A.[Counterparty_No]=B.ClientNo where B.CCB_Group in ('Y') and B.CCB_Group_OwnID in ('N')  and A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate=Start Date and [Modified_Final_Maturity_Date]=[Final_Maturity_Date]")
                cmd.CommandText = "Update [IRS CREDIT EQUIVALENT Details] set [ModifiedStartDate]=[StartDate] , [Modified_Final_Maturity_Date]=[Final_Maturity_Date] where  [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(12, "Update MonthToEventStartDate to Years(NOT CONSIDERING LEAP YEARS)")
                cmd.CommandText = "Update [IRS CREDIT EQUIVALENT Details] set [MonthToEventStartDate]=dbo.yearDiff([Modified_Final_Maturity_Date],[ModifiedStartDate]) where  [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Update Percent Calculation in FX CREDIT EQUIVALENT Details (NEW)
                Me.BgwClientRun.ReportProgress(13, "Update Percent Calculation in IRS CREDIT EQUIVALENT Details")
                cmd.CommandText = "SELECT * FROM [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' begin update [IRS CREDIT EQUIVALENT Details] set [PercentCalculation]=0.005 where [MonthToEventStartDate]<=1 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [IRS CREDIT EQUIVALENT Details] set [PercentCalculation]=0.01 where [MonthToEventStartDate]>1 and [MonthToEventStartDate]<=2 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "'end begin update [IRS CREDIT EQUIVALENT Details] set [PercentCalculation]=[MonthToEventStartDate]*0.01-0.01 where [MonthToEventStartDate]>2 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end"
                cmd.ExecuteNonQuery()
                'Update EURequCalculated in FX CREDIT EQUIVALENT Details and CreditRiskAmountER
                Me.BgwClientRun.ReportProgress(14, "Update EURequCalculated  and CreditRiskAmountER in FX CREDIT EQUIVALENT Details")
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] set [EURequCalculated]=[EURequ]*[PercentCalculation] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [IRS CREDIT EQUIVALENT Details] SET [CreditRiskAmountER]=[EURequCalculated]*[PD]*[LGD] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Update Sum Fields in FX CREDIT EQUIVALENT Basic
                Me.BgwClientRun.ReportProgress(15, "Update Sum Fields in IRS CREDIT EQUIVALENT Basic")
                cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([EURequ]) as S from [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [IRS CREDIT EQUIVALENT Details] where [PercentCalculation]=0.005 and [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [IRS CREDIT EQUIVALENT Details] where [PercentCalculation]=0.01 and [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [IRS CREDIT EQUIVALENT Details] where [PercentCalculation]>0.01 and [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditRiskAmountSUM]=B.S from [IRS CREDIT EQUIVALENT Basic] A INNER JOIN (Select [Id_IRS_CRED_EQU_BASIC],Sum([CreditRiskAmountER]) as S from [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [Id_IRS_CRED_EQU_BASIC]) B on A.[ID]=B.[Id_IRS_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '+++++++++INSERT DATA TO CREDIT RISK++++++++++++++++++++
                cmd.CommandText = "INSERT INTO [CREDIT RISK]([Obligor Rate],[Contract Type],[Product Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[RiskDate],[RepDate],[DateMakCrTotals],[ClientGroup],[ClientGroupName]) Select [Obligor Rate],[ContractType],[ProductType],[Counterparty_Name],[Counterparty_No],[Contract],[Modified_Final_Maturity_Date],[OrgCcy],[OrgCcyAmount],[EURequ],[EURequCalculated],'SWAP',[PD],[LGD],[CreditRiskAmountER],[CreditRiskAmountER],[RiskDate],[RepDate],[RiskDate],[ClientGroup],[ClientGroupName] from [IRS CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [MAK REPORT]([Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Euro Equivalent],[Client Group],[RiskDate],[DateMakCrTotals]) Select [ContractType],[ProductType],[Counterparty_Name],[Counterparty_No],[Contract],[ModifiedStartDate],[Modified_Final_Maturity_Date],[OrgCcy],[OrgCcyAmount],[EURequCalculated],[ClientGroup],[RiskDate],[RiskDate] from [IRS CREDIT EQUIVALENT Details] where RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "IRS_CREDIT_EQUIV_CALCULATION STATUS is Invalid")
        End If
        'End If
    End Sub

    Private Sub CREDIT_RISK_MAK_UPDATE()
        CurrentClientProcedure = "CREDIT RISK + MAK UPDATE"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CREDIT_RISK_MAK_UPDATE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start CREDIT RISK + MAK UPDATE for " & rd)
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\CREDIT_RISK_MAK_UPDATE")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CREDIT_RISK_MAK_UPDATE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute CREDIT RISK + MAK UPDATE: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "CREDIT_RISK_MAK_UPDATE SQL PARAMETER STATUS is Invalid")
        End If
    End Sub

    Private Sub UNEXPECTED_LOSS_CALCULATION()
        CurrentClientProcedure = "UNEXPECTED LOSS CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('UNEXPECTED_LOSS_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start UNEXPECTED LOSS Calculation for " & rd)
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then

                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\UNEXPECTED_LOSS_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('UNEXPECTED_LOSS_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute UNEXPECTED LOSS Calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next


                ''++++++++++OLD CODE++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''*******SPLITING CCB GROUP**********
                'Me.BgwClientRun.ReportProgress(10, "Update ClientGroupN and ClientGroupNameN (Parameter:REPORTS/CCB_INDIVIDUAL_GROUP) in CREDIT RISK")
                'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('CCB_INDIVIDUAL_GROUP') and [PARAMETER STATUS]='Y'"
                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                'dt = New System.Data.DataTable()
                'da.Fill(dt)
                'For i = 0 To dt.Rows.Count - 1
                '    Dim sr As String = dt.Rows.Item(i).Item("PARAMETER1") & "%"
                '    cmd.CommandText = "UPDATE [CREDIT RISK] SET [ClientGroupN]='" & dt.Rows.Item(i).Item("PARAMETER2") & "',[ClientGroupNameN]='" & dt.Rows.Item(i).Item("PARAMETER INFO") & "' where [RiskDate]='" & rdsql & "' and [Counterparty/Issuer/Collateral Name] like '" & sr & "'"
                '    cmd.ExecuteNonQuery()
                'Next
                'Me.BgwClientRun.ReportProgress(80, "Set defaults in Individual Client Group")
                'cmd.CommandText = "UPDATE [CREDIT RISK] SET [ClientGroupN]=[ClientGroup],[ClientGroupNameN]=[ClientGroupName] where [RiskDate]='" & rdsql & "' and [ClientGroupN] is NULL "
                'cmd.ExecuteNonQuery()
                ''#######################################################################################


                'Calculation in CREDIT RISK
                'Define MaturityWithoutCapFloor in CREDIT RISK
                Me.BgwClientRun.ReportProgress(16, "Define MaturityWithoutCapFloor in CREDIT RISK")
                Dim NextHalfYearDate As Date = DateAdd(DateInterval.Month, 6, rd)
                Me.QueryText = "select [ID],'Maturity Date'=CASE when [Maturity Date] is NULL then '99991231' else [Maturity Date] end  from [CREDIT RISK] where [RiskDate]='" & rdsql & "' " 'and [Maturity Date] is not NULL"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ID As String = dt.Rows.Item(i).Item("ID")
                    Dim MaturityDate As Date = dt.Rows.Item(i).Item("Maturity Date")
                    Dim DiffernceRiskDateMaturityDate As Double = 0
                    If MaturityDate = DateSerial(9999, 12, 31) Then
                        DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, NextHalfYearDate) / 365.25, 2)
                        cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                        cmd.ExecuteNonQuery()
                    Else
                        DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, MaturityDate) / 365.25, 2)
                        cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next


                Me.BgwClientRun.ReportProgress(2, "Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted in CREDIT RISK for " & rd)
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2) where  [RiskDate]='" & rdsql & "' and [PD]<>0"
                cmd.ExecuteNonQuery()
                'UNEXPECTED LOSS
                Me.BgwClientRun.ReportProgress(3, "Insert Risk Date in UNEXPECTED_LOSS_DATE Table for " & rd)
                cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_DATE](RiskDate) Values('" & rdsql & "')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(4, "Insert Client Group,Risk Date from CREDIT RISK in UNEXPECTED LOSS Table grouped by Client Group and RiskDate for " & rd)
                cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS]([ClientGroup],[RiskDate]) SELECT [ClientGroupN],[RiskDate] from [CREDIT RISK] where [RiskDate]='" & rdsql & "' GROUP BY [ClientGroupN],[RiskDate]"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(5, "Update Client Group Name in UNEXPECTED LOSS Table")
                cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupNameN] from [UNEXPECTED_LOSS] A INNER JOIN [CREDIT RISK] B ON A.[ClientGroup]=B.[ClientGroupN] where A.[RiskDate]='" & rdsql & "' and B.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(6, "Insert relevant Data to UNEXPECTED_LOSS_Details")
                Me.QueryText = "Select [ID],[ClientGroup] from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "' "
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ID As Double = dt.Rows.Item(i).Item("ID")
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                    cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[EaDweigthedMaturityWithoutCapFloor],[PDxFinalEaD],[LGDfinalEaDweighted],[RiskDate],[IdClientGroup]) SELECT B.[Obligor Rate],B.[Contract Type],B.[Product Type],B.[GL Master / Account Type],B.[Counterparty/Issuer/Collateral Name],B.[Client No],B.[Contract Collateral ID],B.[Maturity Date],B.[Remaining Year(s) to Maturity],B.[Org Ccy],B.[Credit Outstanding (Org Ccy)],B.[Credit Outstanding (EUR Equ)],B.[NetCreditOutstandingAmountEUR],B.[InternalInfo],B.[PD],B.[(1-ER)],B.[Credit Risk Amount(EUR Equ)],B.[NetCredit Risk Amount(EUR Equ)],B.[(1-ER_45)],B.[CreditRiskAmountEUREquER45],B.[NetCreditRiskAmountEUREquER45],B.[CoreDefinition],B.[ClientGroupN],B.[ClientGroupNameN],B.[MaturityWithoutCapFloor],B.[EaDweigthedMaturityWithoutCapFloor],B.[PDxFinalEaD],B.[LGDfinalEaDweighted],B.[RiskDate]," & Str(ID) & " from [CREDIT RISK] B where B.[ClientGroupN]='" & ClientGroup & "' and B.[RiskDate]='" & rdsql & "' and B.[PD]<>0"
                    cmd.ExecuteNonQuery()
                Next


                Me.BgwClientRun.ReportProgress(7, "Update SubBorrowersCounter in UNEXPECTED LOSS Table from CREDIT RISK where PD<>0")
                Me.QueryText = "Select Count([ClientGroupN]) as SubBorrowerCount,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                    Dim SubBorrowerCount As Double = dt.Rows.Item(i).Item("SubBorrowerCount")
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [SubBorrowersCounter]=" & Str(SubBorrowerCount) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                Next
                Me.BgwClientRun.ReportProgress(8, "Update FinalEadTotalSum,LGD,PD_EaD_weigthed in UNEXPECTED LOSS Table from CREDIT RISK  where PD<>0 and Contract Type <>LIMIT")
                Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                    Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
                    If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                    End If
                    Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
                    cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                    Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
                    Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
                    If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                        Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                    End If
                Next
                Me.BgwClientRun.ReportProgress(9, "Update PD_3bps_floor in UNEXPECTED LOSS Table")
                Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' GROUP BY [ClientGroup],[PD_EaD_weighted]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                    Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
                    Dim CheckNumber As Double = 0.0003
                    Dim MaxNumber As Double = 0
                    'Get PD_3bps_floor
                    If PD_EaD_weighted > CheckNumber Then
                        MaxNumber = PD_EaD_weighted
                        'MsgBox("Greater" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                    Else
                        MaxNumber = CheckNumber
                        'MsgBox("Less" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                    End If
                    Dim SecondNumber As Double = 0
                    If PD_EaD_weighted = 0 Then
                        SecondNumber = 0
                        'MsgBox("Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                    Else
                        SecondNumber = 1
                        'MsgBox("Not Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                    End If
                    Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
                    'MsgBox("PD_3bpsfloor " & PD_3bps_floor)
                    'Get IndicatorOfFloor
                    Dim IndicatorOfFloor As Double = 0
                    Dim difference As Double = PD_3bps_floor - PD_EaD_weighted
                    'MsgBox(difference)
                    If difference > 0 Then
                        IndicatorOfFloor = 1
                    Else
                        IndicatorOfFloor = 0
                    End If
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "'"
                    cmd.ExecuteNonQuery()
                Next
                Me.BgwClientRun.ReportProgress(10, "Update MaturityEADweigthed in UNEXPECTED LOSS Table")
                Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                    Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
                    cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                    Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
                    Dim CheckNumber As Double = 5
                    Dim Variable2 As Double = 0
                    If Variable1 > 5 Then
                        Variable2 = 5
                    Else
                        Variable2 = Variable1
                    End If
                    Dim Variable3 As Double = 0
                    If Variable2 > 1 Then
                        Variable3 = Variable2
                    Else
                        Variable3 = 1
                    End If
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                Next
                Me.BgwClientRun.ReportProgress(11, "Update R_CoefficientOfColleration and b_MaturityAdjustment in UNEXPECTED LOSS Table")
                Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "'  GROUP BY [ClientGroup],[PD_3bps_floor]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                    Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                    Dim PDminus As Double = PD * (-50)
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                    cmd.ExecuteNonQuery()
                    'Set b_MaturityAdjustment to 0 if NULL
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=0 where  [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment] is NULL"
                    cmd.ExecuteNonQuery()
                Next
                'Get LevelOfConfidence from UNEXPTECTED_LOSS_DATE
                Me.BgwClientRun.ReportProgress(12, "Get LEVEL OF CONFIDENCE from UNEXPECTED LOSS DATE Table")
                cmd.CommandText = "Select [LevelOfConfidence] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                Dim LevelOfConfidence As Double = cmd.ExecuteScalar

                Me.BgwClientRun.ReportProgress(13, "Update RW_RiskWeightedExposure and UL_UnexpectedLoss in UNEXPECTED LOSS Table")
                Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment]<>0"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ID As String = dt.Rows.Item(i).Item("ID")
                    Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
                    Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
                    Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                    Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
                    Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
                    'Get First Part of Formula
                    cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "' "
                    Dim FirstPartFormulaRW = cmd.ExecuteScalar
                    'Get Second Part of Formula
                    cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "'"
                    Dim SecondPartFormulaRW = cmd.ExecuteScalar
                    Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [RW_RiskWeightedExposure]=0 where [RW_RiskWeightedExposure]<0 and [ID]='" & ID & "' "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
                    cmd.ExecuteNonQuery()
                Next
                Me.BgwClientRun.ReportProgress(14, "Update Sum Unexpected Loss in UNEXPECTED LOSS DATE Table")
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'cmd.CommandText = "DELETE FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [InternalInfo]='FX DEAL'"
                'cmd.ExecuteNonQuery()


                'GRANULARITY APPROACH
                CurrentClientProcedure = "GRANULARITY APPROACH CALCULATION"
                Me.BgwClientRun.ReportProgress(1, "Start GRANULARITY APPROACH Calculation for " & rd)
                Me.BgwClientRun.ReportProgress(2, "Calculate s_i Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'),10) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Calculate K_i Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(4, "Calculate R_i Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS] set [R_i]=Round([LGD]*[PD_3bps_floor],10) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(5, "Calculate VLGD_i Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS] set [VLGD_i]=Round((select nu_Value from UNEXPECTED_LOSS_DATE where [RiskDate]='" & rdsql & "')*[LGD]*(1-[LGD]),10) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(6, "Calculate C_i Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [RiskDate]='" & rdsql & "' and [LGD]<>0"
                cmd.ExecuteNonQuery()

                Me.BgwClientRun.ReportProgress(7, "Calculate GAMMAINV for " & rd)
                Me.QueryText = "Select * from [UNEXPECTED_LOSS_DATE]  Where [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
                Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
                Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
                Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

                'excel = New Microsoft.Office.Interop.Excel.Application
                'instance = excel.WorksheetFunction

                'Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

                'Excel Instanz beenden
                'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                'Dim i1 As Short
                'i1 = 0
                'For i1 = 0 To (procs.Length - 1)
                'procs(i1).Kill()
                'Next i1

                Dim workbook As New DevExpress.Spreadsheet.Workbook()
                Dim worksheets As WorksheetCollection = workbook.Worksheets
                Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)

                worksheet.Range("A1").NumberFormat = "#0.00"
                worksheet.Range("A2").NumberFormat = "#0.00"
                worksheet.Range("A3").NumberFormat = "#0.00"
                worksheet.Range("A4").NumberFormat = "#0.0000000000"
                worksheet.Range("A1").Value = ConfidenceLevelUL
                worksheet.Range("A2").Value = p_alpha_Value
                worksheet.Range("A3").Value = b_beta_Value_Calculated
                worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
                Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue



                Me.BgwClientRun.ReportProgress(8, "Calculate DELTA Value for " & rd)
                Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
                Me.BgwClientRun.ReportProgress(9, "Update DELTA Value and GAMMAINV for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & " where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(10, "Calculate and Insert K_Value for " & rd)
                cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Dim s_i As Decimal = 0
                Dim C_i As Decimal = 0
                Dim K_i As Decimal = 0
                Dim R_i As Decimal = 0
                Dim LGD_i As Decimal = 0
                Dim VLGD_i As Decimal = 0
                Dim CALCULATION_1 As Decimal = 0
                Dim CALCULATION_2 As Decimal = 0
                Dim CALCULATION_3 As Decimal = 0
                Dim TOTAL_CALCULATION As Decimal = 0

                Me.BgwClientRun.ReportProgress(10, "Calculate GA_n Value for " & rd)
                Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [LGD]<>0"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
                    s_i = dt.Rows.Item(i).Item("s_i")
                    C_i = dt.Rows.Item(i).Item("C_i")
                    K_i = dt.Rows.Item(i).Item("K_i")
                    R_i = dt.Rows.Item(i).Item("R_i")
                    LGD_i = dt.Rows.Item(i).Item("LGD")
                    VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
                    Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

                    Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
                    Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
                    Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
                    Dim PowerVLGD As Decimal = VLGD_i ^ 2
                    Dim PowerLGD As Decimal = LGD_i ^ 2
                    Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
                    Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

                    CALCULATION_1 = Math.Round(Calculation_D, 12)
                    CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
                    CALCULATION_3 = CALCULATION_1 - CALCULATION_2

                    TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
                    cmd.ExecuteNonQuery()

                Next
                Me.BgwClientRun.ReportProgress(10, "Calculate and Insert Sum GA_rel Value for " & rd)
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwClientRun.ReportProgress(10, "Calculate and Insert Sum GA_Total Value for " & rd)
                cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
                Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
                cmd.CommandText = "Select [SumGA_rel] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                Dim SummeGArel As Double = cmd.ExecuteScalar
                Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_Total]='" & Str(SummeGA_Total) & "' where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "UNEXPECTED_LOSS_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION()
        CurrentClientProcedure = "ART.13 KWG CHINESE BANKS CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Artikel 13 KWG for Chinesse Banks calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute ART.13 KWG CHINESE BANKS CALCULATION: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(90, "Artikel 13 KWG for Chinesse Banks calculation finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION is Invalid")
        End If
    End Sub

    Private Sub DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION()
        CurrentClientProcedure = "ART.13 KWG NONE CHINESE BANKS CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Artikel 13 KWG for Chinesse Banks calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute ART.13 KWG NONE CHINESE BANKS CALCULATION: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(90, "Artikel 13 KWG for None Chinesse Banks calculation finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "DAILY_ART13_KWG_NONE_CHINESE_BANKS_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub DAILY_ART13_KWG_CENTRAL_GOVERMENT()
        CurrentClientProcedure = "ART.13 KWG CENTRAL GOVERMENT CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('DAILY_ART13_KWG_CENTRAL_GOVERMENT_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Artikel 13 KWG for Central Goverment calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\DAILY_ART13_KWG_CENTRAL_GOVERMENT_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DAILY_ART13_KWG_CENTRAL_GOVERMENT_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute ART.13 KWG CENTRAL GOVERMENT CALCULATION: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(90, "Artikel 13 KWG for Central Goverment calculation finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "DAILY_ART13_KWG_CENTRAL_GOVERMENT_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION()
        CurrentClientProcedure = "BUSINESS TYPES-CREDIT PORTFOLIO CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Business Types-Credit Portfolio calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Select SQL Commands in BusinessTypesCreditPortfolioLive from SQL PARAMETER:BUSINESS TYPES - CREDIT PORTFOLIO")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'BUSINESS TYPES - Einfügen der SQL Befehle am neuen Tag
                'Neuanlage in BusinessTypesCreditPortfolioLive
                'cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [BusinesType],[SQLBusinessTypeDetails],'" & rdsql & "' FROM [BusinessTypesCreditPortfolioTemp]"
                'cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[DateMakCrTotals])Select [SQL_Name_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('BusinessType')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                cmd.ExecuteNonQuery()

                'BUSINESS TYPES - Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Credit Portfolio")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('BusinessType')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types - Credit Portfolio: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'BUSINESS TYPES UPDATES - Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Credit Portfolio")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('Update')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute Update SQL Commands in Business Types - Credit Portfolio: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
                ''Execute SQL Commands for Sum
                'Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, NetCreditRiskAmountER1 and NetCreditRiskAmountER2")
                'cmd.CommandText = "UPDATE A SET A.[AmountBusinessType]=B.ABT, A.[NetCreditRiskAmountER1]=B.NCR1, A.[NetCreditRiskAmountER2]=B.NCR2 from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Sum([Credit Outstanding (EUR Equ)]) as ABT,Sum([NetCredit Risk Amount(EUR Equ)]) as NCR1, Sum([NetCreditRiskAmountEUREquER45]) as NCR2 FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive])B on A.[ID]=B.[IdBusinessTypeLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''Execute SQL Commands for Clients Count
                'Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
                'cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(10, "Update Client Group and Glient Group Name in BusinessTypesCreditPortfolioDetails from CUSTOMER RATING")
                'cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup], A.[ClientGroupName]=B.[ClientGroupName] from [BusinessTypesCreditPortfolioDetails] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update Expected Loss Value in UNEXPECTED_LOSS_DATE Table")
                'cmd.CommandText = "UPDATE A SET A.[SumEL]=B.S from [UNEXPECTED_LOSS_DATE] A INNER JOIN  (SELECT [DateMakCrTotals],Sum([NetCreditRiskAmountER2]) as S FROM [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals])B on A.[RiskDate]=B.[DateMakCrTotals]  WHERE A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Set Business Type in CREDIT RISK and MAK REPORT to NULL")
                'cmd.CommandText = "Update [CREDIT RISK] SET [BusinessType]=NULL where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update [MAK REPORT] SET [BusinessType]=NULL where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update Business Type in CREDIT RISK and MAK REPORT based on BusinessTypesCreditPortfolioDetails")
                'cmd.CommandText = "Update A SET A.[BusinessType]=B.[BusinessTypeName] from [CREDIT RISK] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[RiskDate]=B.[RiskDate] where A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.[Client No]=B.[Client No] and A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update A SET A.[BusinessType]=B.[BusinessTypeName] from [MAK REPORT] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[RiskDate]=B.[RiskDate] where A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.[Client No]=B.[Client No] and A.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "BUSINESS TYPES-CREDIT PORTFOLIO CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION_FINRECON()
        CurrentClientProcedure = "BUSINESS TYPES-CREDIT PORTFOLIO CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Business Types-Credit Portfolio calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Insert BUSINESS TYPES from CREDIT RISK")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[DateMakCrTotals]) Select BusinessType,'" & rdsql & "' FROM [CREDIT RISK]  where RiskDate='" & rdsql & "' GROUP BY BusinessType "
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Insert all details from CREDIT RISK")
                cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioDetails]([BusinessTypeName],[Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[RiskDate])SELECT BusinessType,[Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[RiskDate] from [CREDIT RISK] where RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Connect ID with Master Table")
                cmd.CommandText = "UPDATE A SET A.IdBusinessTypeLive=B.ID from BusinessTypesCreditPortfolioDetails A INNER JOIN BusinessTypesCreditPortfolioLive B on A.BusinessTypeName=B.BusinesType and A.RiskDate=B.DateMakCrTotals where A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Execute SQL Commands for Sum
                Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, NetCreditRiskAmountER1 and NetCreditRiskAmountER2")
                cmd.CommandText = "UPDATE A SET A.[AmountBusinessType]=B.ABT, A.[NetCreditRiskAmountER1]=B.NCR1, A.[NetCreditRiskAmountER2]=B.NCR2 from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Sum([Credit Outstanding (EUR Equ)]) as ABT,Sum([NetCredit Risk Amount(EUR Equ)]) as NCR1, Sum([NetCreditRiskAmountEUREquER45]) as NCR2 FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive])B on A.[ID]=B.[IdBusinessTypeLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Execute SQL Commands for Clients Count
                Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
                cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(10, "Update Client Group and Glient Group Name in BusinessTypesCreditPortfolioDetails from CUSTOMER RATING")
                cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup], A.[ClientGroupName]=B.[ClientGroupName] from [BusinessTypesCreditPortfolioDetails] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Update Expected Loss Value in UNEXPECTED_LOSS_DATE Table")
                cmd.CommandText = "UPDATE A SET A.[SumEL]=B.S from [UNEXPECTED_LOSS_DATE] A INNER JOIN  (SELECT [DateMakCrTotals],Sum([NetCreditRiskAmountER2]) as S FROM [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals])B on A.[RiskDate]=B.[DateMakCrTotals]  WHERE A.[RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "BUSINESS TYPES-CREDIT PORTFOLIO CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub BUSINESS_TYPE_LIABILITIES_CALCULATION()
        CurrentClientProcedure = "BUSINESS TYPES-LIABILITIES CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BUSINESS_TYPE_LIABILITIES_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Business Types-Liabilities calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [BusinessTypesLiabilitiesLive] where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Select SQL Commands in BusinessTypesLiabilitiesLive from SQL PARAMETER:BUSINESS TYPES - LIABILITIES")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                cmd.CommandText = "INSERT INTO [BusinessTypesLiabilitiesLive]([BusinesType],[DateMakCrTotals])Select [SQL_Name_1],'" & rdsql & "'  from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('BusinessType')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                cmd.ExecuteNonQuery()
               
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                'cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesLive] SET [SQLBusinessType]= REPLACE([SQLBusinessType],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle
                If rd <= DateSerial(2015, 12, 15) Then 'Vostro accounts not in Daily Balance Sheet Details
                    Me.BgwClientRun.ReportProgress(3, "Business Date <= 15.12.2015 - Vostro Accounts not in Daily Balance Sheet - Use SQL_Command_1")
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('BusinessType')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Liabilities: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                ElseIf rd > DateSerial(2015, 12, 15) AndAlso rd <= DateSerial(2017, 12, 8) Then
                    Me.BgwClientRun.ReportProgress(3, "Business Date > 15.12.2015 - Vostro Accounts in Daily Balance Sheet - Use SQL_Command_2")
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_2] is not NULL and [SQL_Name_2] in ('BusinessType')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Liabilities: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                ElseIf rd > DateSerial(2017, 12, 8) Then
                    Me.BgwClientRun.ReportProgress(3, "Business Date > 08.12.2017 - NEWG Core System - Use SQL_Command_3")
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_2] is not NULL and [SQL_Name_2] in ('BusinessType') and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Liabilities: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                'Updates
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_1] is not NULL and [SQL_Name_2] in ('Update')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute Update SQL Commands in Business Types Liabilities: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

                ''Delete Duplicates
                'Me.BgwClientRun.ReportProgress(3, "Delete Duplicates")
                'cmd.CommandText = "DELETE FROM [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "' and [ID] not in (Select Min([ID]) from [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "' group by [Contract Collateral ID])"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Set Contract Type SUSPENCE ACCOUNT if Product Type is DDPSUP01")
                'cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesDetails] set [Contract Type]='SUSPENCE ACCOUNT' where [Product Type] in ('DDPSUP01') and [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''Execute SQL Commands for Clients Count
                'Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
                'cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update OrgTotalAmount")
                'cmd.CommandText = "Update 	[BusinessTypesLiabilitiesDetails] set [OrgTotalAmount]=[OrgPrincipalAmount]+[OrgInterestAmount] where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update Exchange Rates")
                'cmd.CommandText = "Update A set A.[ExchangeRate]=B.[MIDDLE RATE] from [BusinessTypesLiabilitiesDetails] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[RiskDate]='" & rdsql & "' and A.[RiskDate]=B.[EXCHANGE RATE DATE]"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update all amounts in EURO")
                'cmd.CommandText = "Update [BusinessTypesLiabilitiesDetails] set [PrincipalAmountEUR]=Round([OrgPrincipalAmount]/[ExchangeRate],2),[InterestAmountEUR]=Round([OrgInterestAmount]/[ExchangeRate],2) where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update all TOTALS")
                'cmd.CommandText = "Update [BusinessTypesLiabilitiesDetails] set [TotalAmountEUR]=[PrincipalAmountEUR]+[InterestAmountEUR] where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''Execute SQL Commands for Sum
                'Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, Interests and TOTALS")
                'cmd.CommandText = "UPDATE A SET A.[AmountBusinessTypePrincipalEUR]=B.ABT, A.[AmountBusinessTypeInterestEUR]=B.NCR1, A.[AmountBusinessTypeTOTAL_EUR]=B.NCR2 from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Sum([PrincipalAmountEUR]) as ABT,Sum([InterestAmountEUR]) as NCR1, Sum([TotalAmountEUR]) as NCR2 FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Me.BgwClientRun.ReportProgress(3, "Update Contract Collateral ID -RTRIM-LTRIM-Delete Blancks")
                'cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesDetails] set [Contract Collateral ID]=RTRIM(LTRIM([Contract Collateral ID])) where [RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "BUSINESS TYPES-LIABILITIES CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "BUSINESS_TYPE_LIABILITIES_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub BUSINESS_TYPE_LIABILITIES_CALCULATION_FINRECON()
        CurrentClientProcedure = "BUSINESS TYPES-LIABILITIES CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BUSINESS_TYPE_LIABILITIES_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Business Types-Liabilities calculation")
            cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [BusinessTypesLiabilitiesLive] where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Select SQL Commands in BusinessTypesLiabilitiesLive from SQL PARAMETER:BUSINESS TYPES - LIABILITIES")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                cmd.CommandText = "INSERT INTO [BusinessTypesLiabilitiesLive]([BusinesType],[DateMakCrTotals])Select [SQL_Name_1],'" & rdsql & "'  from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                cmd.ExecuteNonQuery()

                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                'cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesLive] SET [SQLBusinessType]= REPLACE([SQLBusinessType],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle

                Me.BgwClientRun.ReportProgress(3, "FINRECON - Use SQL_Command_3")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BUSINESS_TYPE_LIABILITIES_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y')"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Liabilities: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            

                'UPDATES
                Me.BgwClientRun.ReportProgress(3, "Update StartDate,MaturityDate and ExchangeRate in BusinessTypesLiabilities")
                cmd.CommandText = "UPDATE A SET A.StartDate=B.StartDate,A.[Maturity Date]=B.MaturityDate,A.ExchangeRate=B.Exchange_Rate from BusinessTypesLiabilitiesDetails A INNER JOIN FINRECON_NG B on A.[Contract Collateral ID]=B.Contract_Nr_Clear and A.RiskDate=B.RiskDate where A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Update Totals in BusinessTypesLiabilities")
                cmd.CommandText = "UPDATE  BusinessTypesLiabilitiesDetails SET [OrgTotalAmount]=[OrgPrincipalAmount]+[OrgInterestAmount],[TotalAmountEUR]=[PrincipalAmountEUR]+[InterestAmountEUR]  where RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Update IdBusinessTypeLiabilitiesLive in BusinessTypesLiabilities")
                cmd.CommandText = " UPDATE A SET A.IdBusinessTypeLiabilitiesLive=B.ID from BusinessTypesLiabilitiesDetails A INNER JOIN BusinessTypesLiabilitiesLive B on A.BusinessTypeName=B.BusinesType and A.RiskDate=B.DateMakCrTotals where A.RiskDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Set Contract Type SUSPENCE ACCOUNT if Product Type is DDPSUP01")
                cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesDetails] set [Contract Type]='SUSPENCE ACCOUNT' where [Product Type] in ('DDPSUP01') and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Execute SQL Commands for Clients Count
                Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
                cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Execute SQL Commands for Sum
                Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, Interests and TOTALS")
                cmd.CommandText = "UPDATE A SET A.[AmountBusinessTypePrincipalEUR]=B.ABT, A.[AmountBusinessTypeInterestEUR]=B.NCR1, A.[AmountBusinessTypeTOTAL_EUR]=B.NCR2 from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Sum([PrincipalAmountEUR]) as ABT,Sum([InterestAmountEUR]) as NCR1, Sum([TotalAmountEUR]) as NCR2 FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
            Me.BgwClientRun.ReportProgress(5, "BUSINESS TYPES-LIABILITIES CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "BUSINESS_TYPE_LIABILITIES_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub HGB_GV_CALCULATION()
        CurrentClientProcedure = "HGB-GEWINN + VERLUST RECHNUNG CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('HGB_GV_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start HGB - Gewinn + Verlust Rechnung calculation")
            cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in in HGB - Gewinn + Verlust Rechnung")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_GV_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in HGB - Gewinn + Verlust Rechnung: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
                dt.Clear()

                'Anwenden der Summen SQL Befehle
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_GV_TEMPLATE')) and [SQL_Command_1] is not NULL and [SQL_Name_3] in ('SA2')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText

                    Me.BgwClientRun.ReportProgress(3, "Calculate Sums in Amount2 for HGB - Gewinn + Verlust Rechnung: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                Next
                dt.Clear()

                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_GV_TEMPLATE')) and [SQL_Command_1] is not NULL and [SQL_Name_3] in ('SA3')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    Me.BgwClientRun.ReportProgress(3, "Calculate Sums in Amount3 for HGB - Gewinn + Verlust Rechnung: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                Next
                dt.Clear()

                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_GV_TEMPLATE')) and [SQL_Command_1] is not NULL and [SQL_Name_3] in ('T3')  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    Me.BgwClientRun.ReportProgress(3, "Calculate Totals Sums in Amount3 for HGB - Gewinn + Verlust Rechnung: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                Next

                Me.BgwClientRun.ReportProgress(3, "Update HGB Position Names in [HGB_GL_Items]")
                cmd.CommandText = "UPDATE A SET A.[HGB_Position_Name]=B.SQL_Name_1 from [HGB_GL_Items] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B ON A.HGB_GV_MatchCode = B.SQL_Name_2 WHERE  B.Id_SQL_Parameters_Details = 720  AND [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'SET Amounts=0 to NULL
                Me.BgwClientRun.ReportProgress(3, "Set all Amount Columns to NULL in [HGB_GL_Items]")
                cmd.CommandText = "UPDATE [HGB_GV] SET [Amount1]=NULL where [Amount1]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [HGB_GV] SET [Amount2]=NULL where [Amount2]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [HGB_GV] SET [Amount3]=NULL where [Amount3]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "HGB-GEWINN + VERLUST RECHNUNG CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "HGB-GEWINN + VERLUST RECHNUNG CALCULATION is Invalid")
        End If
    End Sub 'ONLY IN APP

    Private Sub HGB_BS_CALCULATION()
        CurrentClientProcedure = "HGB-BILANZ CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('HGB_BS_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start HGB - Bilanz Rechnung calculation")
            cmd.CommandText = "SELECT [BSDate] FROM [HGB_GL_Items] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in in HGB - Gewinn + Verlust Rechnung")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_BS_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in HGB - Bilanz: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
                dt.Clear()

                'Anwenden der Summen SQL Befehle
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_BILANZ_TEMPLATE')) and [SQL_Command_3] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText

                    Me.BgwClientRun.ReportProgress(3, "Calculate Sums in Amount2 for HGB - Bilanz: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                Next
                dt.Clear()

                'Anwenden der Summen SQL Befehle
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('HGB_BILANZ_TEMPLATE')) and [SQL_Command_4] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_4").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText

                    Me.BgwClientRun.ReportProgress(3, "Calculate Sums in Amount3 for HGB - Bilanz: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                Next
                dt.Clear()

                Me.BgwClientRun.ReportProgress(3, "Update HGB Position Names in [HGB_GL_Items]")
                cmd.CommandText = "UPDATE A SET A.[HGB_Position_Name]=B.SQL_Name_1 from [HGB_GL_Items] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B ON A.[HGB_BS_MatchCode] = B.SQL_Name_3 WHERE  B.Id_SQL_Parameters_Details = 719  AND [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'SET Amounts=0 to NULL
                Me.BgwClientRun.ReportProgress(3, "Set all Amount Columns to NULL in [HGB_GL_Items]")
                cmd.CommandText = "UPDATE [HGB_BS] SET [Amount1]=NULL where [Amount1]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [HGB_BS] SET [Amount2]=NULL where [Amount2]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [HGB_BS] SET [Amount3]=NULL where [Amount3]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

               

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "HGB-BILANZ CALCULATION is finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "HGB-BILANZ CALCULATION is Invalid")
        End If
    End Sub 'ONLY IN APP

    Private Sub RLDC_UPDATE()
        CurrentClientProcedure = "UPDATE RLDC"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('RLDC_UPDATE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'ÜBERNAHME IN RISK LIMIT DAILY CONTROL
            Me.BgwClientRun.ReportProgress(50, "Start Updating RISK LIMIT DAILY CONTROL with the calculated values for " & rd)
            cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\RLDC_UPDATE")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RLDC_UPDATE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute RLDC_UPDATE: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

        Else
            Me.BgwClientRun.ReportProgress(70, "Unable to Update - Key Data (Currency Risk) are missing for Risk Date: " & rd)
        End If

            Me.BgwClientRun.ReportProgress(100, "UPDATE RLDC finished for " & rd)
        Else
        Me.BgwClientRun.ReportProgress(5, "RLDC_UPDATE STATUS is Invalid")
        End If

    End Sub

    Private Sub RISK_BEARING_CAPACITY_CALCULATION()
        CurrentClientProcedure = "UPDATE RLDC"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('RISK_BEARING_CAPACITY_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'RECALCULATING RISK BEARING CAPACITY
            Me.BgwClientRun.ReportProgress(8, "Recalculating RISK BEARING CAPACITY for " & rd)
            Dim s1 As Double = 0
            Dim s2 As Double = 0
            Dim RBC As Double = 0
            Dim MaxOperationalRisk As Double = 0
            If rd < DateSerial(2014, 1, 1) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement]+round([PL Result]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]="
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()

                End If
            ElseIf rd >= DateSerial(2014, 1, 1) AndAlso rd <= DateSerial(2014, 6, 30) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement]+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2014, 6, 30) AndAlso rd <= DateSerial(2014, 12, 4) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement]+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2014, 12, 4) AndAlso rd <= DateSerial(2015, 9, 29) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement] - ([Minimum capital requirement]*0.3)+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2015, 9, 29) AndAlso rd <= DateSerial(2016, 3, 30) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] * 1.2 + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement] - ([Minimum capital requirement]*0.3)+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2016, 3, 30) AndAlso rd <= DateSerial(2016, 7, 11) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] * 1.2 + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement] - ([Minimum capital requirement]*0.3) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2016, 7, 11) AndAlso rd <= DateSerial(2016, 8, 7) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([OwnCapitalBAIS]/1000,0)-[Minimum capital requirement] - ([Minimum capital requirement]*0.3) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2016, 8, 7) AndAlso rd <= DateSerial(2016, 10, 26) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([CapitalForSolvV]/1000,0)+(Round((Round([RiskWeigthedAmount_Total]/1000,0)*0.1165*(1-0.0905/0.1165)),0))-[Minimum capital requirement] - ([Minimum capital requirement]*0.3) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2016, 10, 26) AndAlso rd <= DateSerial(2016, 11, 14) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([CapitalForSolvV]/1000,0)+(Round((Round([RiskWeigthedAmount_Total]/1000,0)*0.1165*(1-0.0905/0.1165)),0))-[Minimum capital requirement] - ([Minimum capital requirement]*0.15) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2016, 11, 14) AndAlso rd <= DateSerial(2016, 12, 31) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([CapitalForSolvV]/1000,0)+(Round((Round([RiskWeigthedAmount_Total]/1000,0)*0.1045*(1-0.0815/0.1045)),0))-[Minimum capital requirement] - ([Minimum capital requirement]*0.15) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(s1) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(s2) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd >= DateSerial(2017, 1, 1) AndAlso rd <= DateSerial(2016, 12, 31) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk] + " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(Round([CapitalForSolvV]/1000,0)+(Round((Round([RiskWeigthedAmount_Total]/1000,0)*0.1170*(1-0.0940/0.1170)),0))-[Minimum capital requirement] - ([Minimum capital requirement]*0.15) - Round([KapitalerhaltungsPuffer]/1000,0) - Round([AntizyklischerKapitalPuffer]/1000,0) +round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(Math.Round(s1, 0)) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(Math.Round(s2, 0)) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd >= DateSerial(2017, 1, 1) Then
                'RISK BEARING CAPACITY CALCULATION PARAMETERS
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    Me.BgwClientRun.ReportProgress(30, "Delete Data in Table:RISK_BEARING_CAPACITY_CALCULATIONS for " & rd)
                    cmd.CommandText = "DELETE  FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwClientRun.ReportProgress(30, "Insert calculation Parameters from SQL PARAMETER DETAILS for RISK BEARING CAPACITY")
                    cmd.CommandText = "INSERT INTO [RISK_BEARING_CAPACITY_CALCULATIONS]([RBC_Row_Nr],[RBC_Row_Rep],[Pilar],[RiskType],[RiskTypeAdditionalInfo],[RiskTypeCalcInfo],[RiskDate])SELECT [SQL_Float_1],[SQL_Name_2],[SQL_Name_1],[SQL_Name_3],[SQL_Name_4],[SQL_Command_2],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RISK_BEARING_CAPACITY_CALCULATION')) and '" & rdsql & "' BETWEEN [SQL_Date1] and [SQL_Date2] order By [SQL_Float_1] asc"
                    cmd.ExecuteNonQuery()
                    Me.BgwClientRun.ReportProgress(3, "Execute SQL Calculations - Use SQL_Command_1")
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RISK_BEARING_CAPACITY_CALCULATION')) and [SQL_Command_1] is not NULL and '" & rdsql & "' BETWEEN [SQL_Date1] and [SQL_Date2] and [Status] in ('Y')"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for Risk Type: " & dt.Rows.Item(i).Item("SQL_Name_3"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    cmd.CommandText = "Select Sum([RiskTypeAmount]) FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [Pilar] in ('Pilar2') and  [RiskDate]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select Sum([RiskTypeAmount]) FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [Pilar] in ('Pilar1') and  [RiskDate]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "',[PilarII_RiskPotential_Amount]='" & Str(Math.Round(s1, 0)) & "',[PilarI_RiskCoverPotential_Amount]='" & Str(Math.Round(s2, 0)) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            End If

            'TRAFFIC LIGHT SYSTEM
            cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.BgwClientRun.ReportProgress(8, "Recalculating TRAFFIC LIGHT SYSTEM for " & rd)
                cmd.CommandText = "Delete from [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate] ='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [RBC_TRAFFIC_LIGHT_SYSTEM]([RiskCategory],[RelativeAllocationPercent],[SQLCommand],[RiskDate])Select [SQL_Name_1],[SQL_Float_1],[SQL_Command_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='TRAFFIC LIGHTS SYSTEM'"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [SQLCommand]= REPLACE([SQLCommand],'<RiskDate>','" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in RBC_TRAFFIC_LIGHT_SYSTEM")
                Me.QueryText = "select * from [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate] ='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLCommand")
                    Dim Amount As Double = cmd.ExecuteScalar
                    cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [RiskCategoryFullAmount]=' " & Str(Amount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                Next

                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [PilarIamount]=(Select [PilarI_RiskCoverPotential_Amount] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [RelativeAllocationAmount]=Round([PilarIamount]*[RelativeAllocationPercent],0) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Less' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]<=0.8 and [RiskDate]='" & rdsql & "' END BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Middle' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]>0.8 and [RiskCategoryFullAmount]/[RelativeAllocationAmount]<=1  and [RiskDate]='" & rdsql & "' END BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Over' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]>1 and [RiskDate]='" & rdsql & "' END"
                cmd.ExecuteNonQuery()
            End If
        End If
    End Sub

    Private Sub STRESS_TESTS_HEAD_OFFICE_CALCULATION()

        CurrentClientProcedure = "STRESS TEST HEAD OFFICE CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('STRESS_TESTS_HEAD_OFFICE_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                cmd.CommandText = "DELETE  FROM [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Checking Date definieren
                CheckingDate = DateAdd("m", 1, rd)

                CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
                CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

                LastDayCurrentMonth = DateSerial(rd.Year, rd.Month, 1).AddMonths(1).AddDays(-1)
                FirstDayOverNextMonth = rd.AddDays((rd.Day - 1) * -1).AddMonths(2) ' Übernächstzer Monat
                'Wenn Tagesdatum gleich datum des letzten Monatstages
                If rd = LastDayCurrentMonth Then
                    CheckingDate = FirstDayOverNextMonth
                End If

                'STRESS TEST LIQUIDITY HEAD OFFICE SCENARIO
                'Erstellen des Risk datums
                Me.BgwClientRun.ReportProgress(6, "Insert new Risk Date")
                cmd.CommandText = "INSERT INTO [StressTestsLiquidHO] ([StressDate]) Values ('" & rdsql & "')"
                cmd.ExecuteNonQuery()

                'Einfügen der Temp daten in die Live Tabelle
                Me.BgwClientRun.ReportProgress(7, "Insert Temp SQL Commands in the Live Table")
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=B.[CashPlacementBUBA_ACCD_SQL],[CashPlacementBUBA_CFNM_SQL]=B.[CashPlacementBUBA_CFNM_SQL],[LossUnderStressCashPlacementBUBA]=B.[LossUnderStressCashPlacementBUBA],[PlacementToBanksInclIC_ACCD_SQL]=B.[PlacementToBanksInclIC_ACCD_SQL],[PlacementsToBanksInclIC_CFNM_SQL]=B.[PlacementsToBanksInclIC_CFNM_SQL],[LossUnderStressPlacementsToBanksInclIC]=B.[LossUnderStressPlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD_SQL]=B.[DebtClaimToCustomersInclCCB_ACCD_SQL],[DebtClaimToCustomersInclCCB_CFNM_SQL]=B.[DebtClaimToCustomersInclCCB_CFNM_SQL],[LossUnderStressDebtClaimToCustomersInclCCB]=B.[LossUnderStressDebtClaimToCustomersInclCCB],[Investments_Securities_ACCD_SQL]=B.[Investments_Securities_ACCD_SQL],[Investments_Securities_CFNM_SQL]=B.[Investments_Securities_CFNM_SQL],[LossUnderStressInvestments_Securities]=B.[LossUnderStressInvestments_Securities],[OtherAssets_ACCD_SQL]=B.[OtherAssets_ACCD_SQL],[OtherAssets_CFNM_SQL]=B.[OtherAssets_CFNM_SQL],[LossUnderStressInvestments_OtherAssets]=B.[LossUnderStressInvestments_OtherAssets],[BorrowFromBUBA_SQL]=B.[BorrowFromBUBA_SQL],[BorrowFromBUBA_CFNM_SQL]=B.[BorrowFromBUBA_CFNM_SQL],[LossUnderStressInvestments_BorrowFromBUBA]=B.[LossUnderStressInvestments_BorrowFromBUBA],[DepositFromBanksInclIC_SQL]=B.[DepositFromBanksInclIC_SQL],[DepositFromBanksInclIC_CFNM_SQL]=B.[DepositFromBanksInclIC_CFNM_SQL],[LossUnderStressInvestments_DepositFromBanksInclIC]=B.[LossUnderStressInvestments_DepositFromBanksInclIC],[DepositFromCustomers_SQL]=B.[DepositFromCustomers_SQL],[DepositFromCustomers_CFNM_SQL]=B.[DepositFromCustomers_CFNM_SQL],[LossUnderStressInvestments_DepositFromCustomers]=B.[LossUnderStressInvestments_DepositFromCustomers] from [StressTestsLiquidHO] A,[StressTestLiquid_Temp] B where A.[StressDate]='" & rdsql & "' and B.[ID]=1"
                cmd.ExecuteNonQuery()

                'Replace RiskDate and CheckingDate with Valid sql Date
                Me.BgwClientRun.ReportProgress(8, "Replace <RiskDate> and <CheckingDate> with the current Risk date in the Live Table")
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]= REPLACE([CashPlacementBUBA_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=REPLACE([CashPlacementBUBA_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]= REPLACE([CashPlacementBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]=REPLACE([CashPlacementBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]= REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]=REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]= REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]=REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]= REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]=REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]= REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]=REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]= REPLACE([Investments_Securities_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]=REPLACE([Investments_Securities_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]= REPLACE([Investments_Securities_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]=REPLACE([Investments_Securities_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]= REPLACE([OtherAssets_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]=REPLACE([OtherAssets_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]= REPLACE([OtherAssets_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]=REPLACE([OtherAssets_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]= REPLACE([BorrowFromBUBA_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]=REPLACE([BorrowFromBUBA_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]= REPLACE([BorrowFromBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]=REPLACE([BorrowFromBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]= REPLACE([DepositFromBanksInclIC_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]=REPLACE([DepositFromBanksInclIC_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]= REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]=REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]= REPLACE([DepositFromCustomers_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]=REPLACE([DepositFromCustomers_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]= REPLACE([DepositFromCustomers_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]=REPLACE([DepositFromCustomers_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'SQL Befehle ausführen
                Me.BgwClientRun.ReportProgress(9, "Execute SQL Commands in the Live Table")
                Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute CashPlacementBUBA_ACCD_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute CashPlacementBUBA_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute PlacementToBanksInclIC_ACCD_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute PlacementsToBanksInclIC_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DebtClaimToCustomersInclCCB_ACCD_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DebtClaimToCustomersInclCCB_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute Investments_Securities_ACCD_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute Investments_Securities_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute OtherAssets_ACCD_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute OtherAssets_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute BorrowFromBUBA_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute BorrowFromBUBA_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DepositFromBanksInclIC_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DepositFromBanksInclIC_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DepositFromCustomers_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                        Me.BgwClientRun.ReportProgress(9, "Execute DepositFromCustomers_CFNM_SQL in the Live Table")
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next


                'Summen erstellen
                'CASH INFLOW-ACCOUNT BALANCE
                Me.BgwClientRun.ReportProgress(10, "Update CASH INFLOW-ACCOUNT BALANCE  in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
                Me.BgwClientRun.ReportProgress(11, "Update CASH INFLOW-CASH FLOW WITHIN NEXT MONTH  in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-ACCOUNT BALANCE
                Me.BgwClientRun.ReportProgress(12, "Update CASH OUTFLOW-ACCOUNT BALANCE  in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
                Me.BgwClientRun.ReportProgress(13, "Update CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'ADDITIONAL CASH FLOW UNDER STRESS
                Me.BgwClientRun.ReportProgress(14, "Update AddCashOutflowunderStress_CashPlacementBUBA in the Live Table")
                '1
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '2
                Me.BgwClientRun.ReportProgress(15, "Update AddCashOutflowunderStress_PlacementsToBanksInclIC in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '3
                Me.BgwClientRun.ReportProgress(16, "Update AddCashOutflowunderStress_DebtClaimToCustomersInclCCB in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '4
                Me.BgwClientRun.ReportProgress(17, "Update AddCashOutflowunderStress_Investments_Securities in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '5
                Me.BgwClientRun.ReportProgress(18, "Update AddCashOutflowunderStress_OtherAssets in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '6
                Me.BgwClientRun.ReportProgress(19, "Update AddCashOutflowunderStress_BorrowFromBUBA in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '7
                Me.BgwClientRun.ReportProgress(20, "Update AddCashOutflowunderStress_DepositFromBanksInclIC in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '8
                Me.BgwClientRun.ReportProgress(21, "Update AddCashOutflowunderStress_DepositFromCustomers in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                'Restliche Summen Berechnen
                Me.BgwClientRun.ReportProgress(22, "Update LIQUIDITY_DEMAND_OVERPLUS_CFNM in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
                Me.BgwClientRun.ReportProgress(23, "Update LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'TOTAL LIQUIDITY
                Me.BgwClientRun.ReportProgress(24, "Update TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS in the Live Table")
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "STRESS_TESTS_HEAD_OFFICE_CALCULATION STATUS is Invalid")
        End If

    End Sub

    Private Sub LOAN_EXPOSURE_CORPORATES()
        CurrentClientProcedure = "LOAN EXPOSURE CORPORATES"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LOAN_EXPOSURE_CORPORATES') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(50, "Start calculate the Loan Exposures for Corporate Customers on " & rd)
            cmd.CommandText = "SELECT [CapitalForSolvV] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            Dim CapitalForSolv As Double = cmd.ExecuteScalar
            If CapitalForSolv <> 0 Then
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands for PS TOOL CLIENT\LOAN_EXPOSURE_CORPORATES")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LOAN_EXPOSURE_CORPORATES')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute LOAN_EXPOSURE_CORPORATES: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

            Else
                Me.BgwClientRun.ReportProgress(70, "Unable to calculate the Loan Exposures for Corporate Customers - Key Data (CapitalForSolvV) are missing for Risk Date: " & rd)
            End If
        Else
            Me.BgwClientRun.ReportProgress(5, "LOAN_EXPOSURE_CORPORATES STATUS is Invalid")
        End If
    End Sub

    Private Sub FORMBLATT_BALANCE_CALCULATION()
        CurrentClientProcedure = "FORMBLATT BILANZ CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FORMBLATT_BALANCE_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Formblatt Bilanz Calculation")
            cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                'UPDATE RILIBI CODES AND NAMES
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Codes in DailyBalanceSheets")
                cmd.CommandText = "UPDATE A set A.[RilibiCode]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_MATCHING' and [PARAMETER STATUS] ='Y')B ON A.[GL_Item_Number]=B.[PARAMETER1]  where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Names DailyBalanceSheets")
                cmd.CommandText = "UPDATE A set A.[RilibiName]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_CODES' and [PARAMETER STATUS] ='Y')B ON A.[RilibiCode]=B.[PARAMETER1] where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Codes and Names DailyBalanceDetailSheet")
                cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Delete Current Data from Formblatt_BILANZ_Details ")
                cmd.CommandText = "DELETE  FROM [Formblatt_BILANZ_Details] where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Delete Current Data from Formblatt_BILANZ_TOTALS ")
                cmd.CommandText = "DELETE FROM [Formblatt_BILANZ_TOTALS] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Insert SQL Commands in Formblatt_BILANZ_TOTALS")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'FORMBLATT BILANZ - Einfügen der SQL Befehle am neuen Tag
                cmd.CommandText = "INSERT INTO [Formblatt_BILANZ_TOTALS]([Bilanzposition],[Bilanzposition_ID],[BilanzpositionArt],[SQLcommandCurrentDate],[SQLcommandLastYear],[RiskDate])Select [SQL_Name_1],[SQL_Float_1],[SQL_Name_2],[SQL_Command_1],[SQL_Command_2],'" & rdsql & "' from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FORMBLATT_BALANCE_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') ORDER BY [SQL_Float_1] asc"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [SQLcommandCurrentDate]= REPLACE([SQLcommandCurrentDate],'<RiskDate>','" & rdsql & "'),[SQLcommandLastYear]= REPLACE([SQLcommandLastYear],'<RiskDate>','" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Formblatt_BILANZ_TOTALS")
                Me.QueryText = "select * from [Formblatt_BILANZ_TOTALS] where [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQLcommandCurrentDate")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("SQLcommandCurrentDate")
                        cmd.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQLcommandLastYear")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("SQLcommandLastYear")
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'Execute SQL Commands for Sum
                Me.BgwClientRun.ReportProgress(3, "Update Summary Unterpositionen")
                cmd.CommandText = "UPDATE A SET A.[AmountCurrentDate_UP]=B.ABT from [Formblatt_BILANZ_TOTALS] A INNER JOIN  (SELECT [IdFormblattBALANCE_TOTALS],Sum([Total_Balance]) as ABT  FROM [Formblatt_BILANZ_Details] GROUP BY [IdFormblattBALANCE_TOTALS])B on A.[ID]=B.[IdFormblattBALANCE_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "' and A.[BilanzpositionArt] not in ('AKTIVA','PASSIVA')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Update Summary Gesamtpositionen")
                cmd.CommandText = "UPDATE A SET A.[AmountCurrentDate]=B.ABT from [Formblatt_BILANZ_TOTALS] A INNER JOIN  (SELECT [IdFormblattBALANCE_TOTALS],Sum([Total_Balance]) as ABT  FROM [Formblatt_BILANZ_Details] GROUP BY [IdFormblattBALANCE_TOTALS])B on A.[ID]=B.[IdFormblattBALANCE_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "' and A.[BilanzpositionArt] in ('AKTIVA','PASSIVA')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [AmountCurrentDate_UP]=NULL where [AmountCurrentDate_UP]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [AmountCurrentDate]=NULL where [AmountCurrentDate]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "FORMBLATT BILANZ CALCULATION finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "FORMBLATT_BALANCE_CALCULATION STATUS is Invalid")
        End If

    End Sub

    Private Sub CURRENCY_RISK_CALCULATION()
        CurrentClientProcedure = "CURRENCY RISK CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CURRENCY_RISK_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Check if related Data are present")
            cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                Me.BgwClientRun.ReportProgress(3, "Execute CURRENCY RISK calculation for: " & rd)
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CURRENCY_RISK_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute Currency Risk calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
                
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "CURRENCY RISK CALCULATION finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "CURRENCY_RISK_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub CAR_CALCULATION()
        CurrentClientProcedure = "CAR-Solva CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CAR_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Check if related Data are present")
            cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
           If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.BgwClientRun.ReportProgress(3, "Execute CAR-Solva calculation for: " & rd)
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CAR_CALCULATION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Me.BgwClientRun.ReportProgress(3, "Execute CAR-Solva calculation: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

            Else
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "CAR CALCULATION finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "CAR_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub ANTICYCLIC_CALCULATION()
        CurrentClientProcedure = "ANTICYCLICAL CAPITALBUFFER CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('ANTICYCLIC_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Check if RiskWeigthedAmount_Total in Table:RISK LIMIT DAILY CONTROL is present")
            cmd.CommandText = "SELECT [RiskWeigthedAmount_Total] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then

                Me.BgwClientRun.ReportProgress(8, "Start Anticyclical Capitalbuffer calculation for " & rd)
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Calculations - Use command in SQL PROCEDURES PARAMETER\PS TOOL CLIENT PROCEDURES\ANTICYCLIC_CALCULATION")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where SQL_Name_1 in ('ANTICYCLIC_CALCULATION') and [SQL_Command_1] is not NULL  and [Status] in ('Y')"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                cmd.ExecuteNonQuery()
            
            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "ANTICYCLICAL CAPITALBUFFER CALCULATION is finished")
        Else
        Me.BgwClientRun.ReportProgress(5, "ANTICYCLICAL CAPITALBUFFER CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub LiqV_CALCULATION()
        CurrentClientProcedure = "LIQUIDITY RATIO CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LiqV_CALCULATION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Check if related Data are present")
            cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                'UPDATE RILIBI CODES AND NAMES
                Me.BgwClientRun.ReportProgress(8, "Calculate Liquidity Ratio (Stored procedure:LiqV_CALCULATION) for " & rd)
                cmd.CommandText = "Exec [LiqV_CALCULATION] @RISKDATE='" & rdsql & "'"
                cmd.ExecuteNonQuery()

            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "LIQUIDITY RATIO CALCULATION finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "LiqV_CALCULATION STATUS is Invalid")
        End If
    End Sub

    Private Sub MINDESTRESERVE_CALCULATION()
        CurrentClientProcedure = "MINDESTRESERVE CALCULATION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('MINDESTRESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(8, "Check if MINIMUM RESERVE END DATE which are greater than " & rd & " is defined!")
            cmd.CommandText = "With CTE as (Select Max([CalendarDate]) as 'MaxDate' from [Calendar] where MinReserveBUBA in ('Y')) Select Count(*) from CTE where GETDATE()>CTE.MaxDate"
            Dim Result As Double = cmd.ExecuteScalar
            If Result = "0" Then
                Me.BgwClientRun.ReportProgress(8, "Execute Stored Procedure MINDESTRESERVE_CALCULATION for " & rd)
                cmd.CommandText = "exec [MINDESTRESERVE_CALCULATION] @RISKDATE='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "MINDESTRESERVE_CALCULATION finished ")
            Else
                Me.BgwClientRun.ReportProgress(8, "+++There is no defined MINIMUM RESERVE END DATE which are greater than " & rd & vbNewLine & "MINDESTRESERVE_CALCULATION will be not executed!")
            End If
            Me.BgwClientRun.ReportProgress(3, "Update BUBA Interest in RLDC if no MINDESTRESERVE has being calculated for " & rd)
            Me.QueryText = "Select * FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('MINDESTRESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    cmd.ExecuteNonQuery()
                End If
            Next
        Else
            Me.BgwClientRun.ReportProgress(5, "MINDESTRESERVE_CALCULATION STATUS is Invalid")
        End If
    End Sub 'ONLY IN APP

    Private Sub LIQUIDITY_OVERVIEW_DATA_COLLECTION()
        CurrentClientProcedure = "LIQUIDITY OVERVIEW DATA COLLECTION"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_OVERVIEW_DATA_COLLECTION') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute LIQUIDITY OVERVIEW DATA COLLECTION for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_OVERVIEW_DATA_COLLECTION')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.BgwClientRun.ReportProgress(8, "LIQUIDITY OVERVIEW DATA COLLECTION finished ")
        Else
            Me.BgwClientRun.ReportProgress(5, "LIQUIDITY_OVERVIEW_DATA_COLLECTION STATUS is Invalid")
        End If
    End Sub

    Private Sub ANACREDIT_DATA_COLLECT()
        CurrentClientProcedure = "ANACREDIT_DATA_COLLECT"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('ANACREDIT_DATA_COLLECT') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute ANACREDIT_DATA_COLLECT for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ANACREDIT_DATA_COLLECT')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.BgwClientRun.ReportProgress(8, "ANACREDIT DATA COLLECT finished ")
        Else
            Me.BgwClientRun.ReportProgress(5, "ANACREDIT DATA COLLECT is Invalid")
        End If
    End Sub

    Private Sub GENERAL_INFO_DATA_COLLECT()
        CurrentClientProcedure = "GENERAL INFO DATA COLLECT"
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('GENERAL_INFO_DATA_COLLECT') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(3, "Execute GENERAL_INFO_DATA_COLLECT for: " & rd)
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('GENERAL_INFO_DATA_COLLECT')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.BgwClientRun.ReportProgress(8, "GENERAL_INFO_DATA_COLLECT finished ")
        Else
            Me.BgwClientRun.ReportProgress(5, "LIQUIDITY_OVERVIEW_DATA_COLLECTION STATUS is Invalid")
        End If
    End Sub

    '---------------------------------------------
    '--------------------------------------------

    Private Sub UPDATE_AWVz14z15() 'ONLY IN SCHEDULE TASK
        CurrentClientProcedure = "UPDATE AWVz14z15 RELEVANT DATA"

        Me.BgwClientRun.ReportProgress(8, "Update Exhange Rates in AWVz1415Relevant Data - Exchange Rate Data = Current Interest Coupon Period End Date ")
        cmd.CommandText = "Update A set A.[ExchangeRate]=B.[MIDDLE RATE] from [AWVz1415RelevantData] A INNER JOIN [EXCHANGE RATES OCBS] B on A.[OrigCCY]=B.[CURRENCY CODE] and A.[Current Interest Coupon Period End Date]=B.[EXCHANGE RATE DATE] where  A.[IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0) "
        cmd.ExecuteNonQuery()
        Me.BgwClientRun.ReportProgress(8, "Update Interest Amounts in AWVz1415RelevantData only for Foreign Currencies Contracts")
        cmd.CommandText = "Update [AWVz1415RelevantData] set [Interest Coupon Amount EUR Equ]=Round([Interest Coupon Amount OrigCCY]/[ExchangeRate],2) where [OrigCCY] not in ('EUR') and [Interest Coupon Amount OrigCCY]<>0 and [ExchangeRate]<>1 and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0) "
        cmd.ExecuteNonQuery()
        'Summen für AZW Z14 und Z15 auf NULL Stellen
        Me.BgwClientRun.ReportProgress(12, "Set CountrySumAmount to zero")
        cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0) "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
        cmd.ExecuteNonQuery()
        Me.BgwClientRun.ReportProgress(12, "Recalculate Country Sums for AWVz14")
        cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz14] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Assets' and [IdZ14Z15Meldemonat]= DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0) GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [AWVz14] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
        cmd.ExecuteNonQuery()
        Me.BgwClientRun.ReportProgress(12, "Recalculate Country Sums for AWVz15")
        cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz15] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0) GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [AWVz15] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
        cmd.ExecuteNonQuery()
        'Handling of Negative Interest at the last day of month
        cmd.CommandText = "SELECT DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0,'" & rdsql & "')+1,0))"
        Dim MeldeMonatLastDay As Date = cmd.ExecuteScalar
        If IsLastDay(rd) = True Then
            Me.BgwClientRun.ReportProgress(15, "Handling Negative Interests - If Country Sum <0 then insert country to Z4 and delete negative amount in AWV Z14 and AWV Z15")
            cmd.CommandText = "INSERT INTO [AWVz4DIKAPPOSTEN]([DIKA_BELEGART],[DIKA_KENNZAHL],[DIKA_ZAHLUNGSZWECK],[DIKA_ISOLAND],[DIKA_ISOLAND_NAME],[DIKA_VERRKZ],[DIKA_BETRAG],[DIKA_MeldeMonat]) Select '2','181','NEGATIV ZINSEN',[COUNTRY CODE],[COUNTRY NAME],'V',ABS([CountrySumAmount]),[IdZ14Z15Meldemonat] from [AWVz14] where [CountrySumAmount]<0 and [COUNTRY CODE] not in ('DE') and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [AWVz4DIKAPPOSTEN]([DIKA_BELEGART],[DIKA_KENNZAHL],[DIKA_ZAHLUNGSZWECK],[DIKA_ISOLAND],[DIKA_ISOLAND_NAME],[DIKA_VERRKZ],[DIKA_BETRAG],[DIKA_MeldeMonat]) Select '1','181','NEGATIV ZINSEN',[COUNTRY CODE],[COUNTRY NAME],'V',ABS([CountrySumAmount]),[IdZ14Z15Meldemonat] from [AWVz15] where [CountrySumAmount]<0 and [COUNTRY CODE] not in ('DE') and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE from [AWVz14]  where [CountrySumAmount]<0 and [COUNTRY CODE] not in ('DE') and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE from [AWVz15]  where [CountrySumAmount]<0 and [COUNTRY CODE] not in ('DE') and [IdZ14Z15Meldemonat]=DATEADD(m, DATEDIFF(m, 0, '" & rdsql & "'), 0)"
            cmd.ExecuteNonQuery()
        End If
        If MeldeMonatLastDay = rd Then
        End If
        Me.BgwClientRun.ReportProgress(5, "UPDATE AWVz14z15 RELEVANT DATA finished")

    End Sub 'ONLY IN SCHEDULE TASK

    Private Sub LOAD_LOANS_TRANSACTIONS()
        CurrentClientProcedure = "LOAD ALL LOANS TRANSACTIONS"
        Me.BgwClientRun.ReportProgress(8, "Run SQL Stored Procedure:LOANS_TRANSACTIONS_ALL ")
        cmd.CommandText = "exec [LOANS_TRANSACTIONS_ALL] "
        cmd.ExecuteNonQuery()
        Me.BgwClientRun.ReportProgress(8, "LOAD ALL LOANS TRANSACTIONS finished ")
    End Sub 'ONLY IN SCHEDULE TASK

    Private Sub NOSTRO_RECONCILIATION()
        CurrentClientProcedure = "NOSTRO ACCOUNT RECONCILIATION"
        Me.BgwClientRun.ReportProgress(10, "Starting Nostro reconciliation")
        'cmd.CommandText = "exec [RECONCILE_NOSTRO_ACCOUNTS_CREATE_TEMP_TABLES]"
        'cmd.ExecuteNonQuery()
        Me.QueryText = "Select [INTERNAL ACCOUNT] from [SSIS] where [INTERNAL ACCOUNT] is not NULL and [VALID]='Y' ORDER BY ID asc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows.Count > 0 Then
                Dim InternalNostroAccount As String = dt.Rows.Item(i).Item("INTERNAL ACCOUNT")
                Me.BgwClientRun.ReportProgress(20 + i, "Starting Nostro reconciliation for Internal Account: " & InternalNostroAccount)
                cmd.CommandText = "exec [RECONCILE_NOSTRO_ACCOUNTS] @RISKDATE='" & rdsql & "', @INTERNAL_NOSTRO_ACCOUNT='" & InternalNostroAccount & "' "
                cmd.ExecuteNonQuery()
            End If
        Next

    End Sub 'ONLY IN SCHEDULE TASK

    



    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Function IsLastDay(ByVal myDate As Date) As Boolean
        Return myDate.Day = Date.DaysInMonth(myDate.Year, myDate.Month)
    End Function

    Private Sub TEST()
        Me.BgwClientRun.ReportProgress(1, "Start the FX INTERNAL IDW CALCULATION for " & rd)
        cmd.CommandText = "SELECT [RiskDate] FROM [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            'Berechnung Intern - NEW IDW
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [CUR_BUY_FX_ALL]=NULL,[AMT_BUY_FX_ALL]=0,[CUR_SELL_FX_ALL]=NULL,[AMT_SELL_FX_ALL]=0,[END_DATE_FX_ALL]=NULL,[DATEDIFF_END_DATE]=0,[DATEDIFF_MAT_DATE]=0,[IDW_AMOUNT_INTERN]=0  where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CUR_BUY_FX_ALL]=B.CCY_B ,A.AMT_BUY_FX_ALL=B.AMT_B,A.[CUR_SELL_FX_ALL]=B.CCY_S,A.AMT_SELL_FX_ALL=B.AMT_S,A.END_DATE_FX_ALL=B.[End Date] from [FX DAILY REVALUATION] A INNER JOIN [FX ALL] B on A.ContractNr=B.ContractNo  where A.RiskDate='" & rdsql & "' and A.OwnDeal in ('Y') and A.DealStatus in ('U')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET IDW_AMOUNT_INTERN=(PL_inEUR_Equ * (-1))  where [RiskDate]<[END_DATE_FX_ALL] and RiskDate='" & rdsql & "' and DealStatus in ('U') and OwnDeal in ('Y')"
            cmd.ExecuteNonQuery()
            'DATEDIFF_END_DATE-->Next Working Date:If Next Wotking Date in Current Month then Next working Date
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [DATEDIFF_END_DATE]=DATEDIFF(DAY,END_DATE_FX_ALL,dbo.GetNextTARGETWorkingDay(RiskDate)),[DATEDIFF_MAT_DATE]=DATEDIFF(day,END_DATE_FX_ALL,MaturityDate) where [RiskDate]>=[END_DATE_FX_ALL] and RiskDate='" & rdsql & "' and DealStatus in ('U') and OwnDeal in ('Y') and dbo.GetNextTARGETWorkingDay(RiskDate)<DATEADD(m, DATEDIFF(m, -1, RiskDate), 0)"
            cmd.ExecuteNonQuery()
            'DATEDIFF_END_DATE-->Next Working Date:If Next Wotking Date in Next Month then Take First Day of next Month
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [DATEDIFF_END_DATE]=DATEDIFF(DAY,END_DATE_FX_ALL,DATEADD(m, DATEDIFF(m, -1, RiskDate), 0)),[DATEDIFF_MAT_DATE]=DATEDIFF(day,END_DATE_FX_ALL,MaturityDate) where [RiskDate]>=[END_DATE_FX_ALL] and RiskDate='" & rdsql & "' and DealStatus in ('U') and OwnDeal in ('Y') and dbo.GetNextTARGETWorkingDay(RiskDate)>=DATEADD(m, DATEDIFF(m, -1, RiskDate), 0)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET IDW_AMOUNT_INTERN=((BuyAmount-AMT_SELL_FX_ALL)/TradeBuyRate-(SellAmount-AMT_BUY_FX_ALL)/TradeSellRate)*([DATEDIFF_END_DATE]/[DATEDIFF_MAT_DATE])+((BuyAmount/SpotBuyRate)-(SellAmount/SpotSellRate))-((BuyAmount-AMT_SELL_FX_ALL)/TradeBuyRate-(SellAmount-AMT_BUY_FX_ALL)/TradeSellRate)-[PL_inEUR_Equ] where [RiskDate]>=[END_DATE_FX_ALL] and RiskDate='" & rdsql & "' and DealStatus in ('U') and OwnDeal in ('Y') and [DATEDIFF_END_DATE]<>0"
            cmd.ExecuteNonQuery()
            'Fx Revaluation Difference between OCBS and IDW (Internal Method)
            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PLdifferenceOCBS_IDW_INTERN]=(SELECT Sum([IDW_AMOUNT_INTERN]) FROM [FX DAILY REVALUATION] WHERE [RiskDate]='" & rdsql & "' and [OwnDeal]='Y' and DealStatus in ('U')) WHERE [RLDC Date]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        End If
    End Sub


End Class