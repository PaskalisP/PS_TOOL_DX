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
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Globalization
Imports DevExpress.Spreadsheet
Public Class LCR_Details
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

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



    Private Sub LCR_Details_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.LCR_Date_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20140101' and [PL Result] is not NULL ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.LCR_Date_Comboedit.Properties.Items.Add(row("RLDC Date"))

            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.LCR_Date_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        'Define if the calculation is on delegated act
        rd = Me.LCR_Date_Comboedit.Text
        If rd <= DateSerial(2016, 9, 29) Then
            Me.LayoutControlItem6.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Always
        ElseIf rd >= DateSerial(2016, 9, 30) Then
            Me.LayoutControlItem6.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub Load_LCR_Details_btn_Click(sender As Object, e As EventArgs) Handles Load_LCR_Details_btn.Click
        If Me.LCR_Date_Comboedit.Text <> "" Then
            rd = Me.LCR_Date_Comboedit.Text
            rdsql = rd.ToString("yyyyMMdd")

            'IS NOT DELEGATED ACT
            If rd <= DateSerial(2016, 9, 29) Then
                Me.LayoutControlItem6.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem8.Visibility = LayoutVisibility.Always
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "SELECT Count([ID]) FROM [LCR_LA_BAIS] where  [RiskDate]='" & rdsql & "'"
                Dim n As Double = cmd.ExecuteScalar
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                If n > 0 Then
                    Try

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Calculate LCR Details (Stored Procedure:LCR_DETAILS)" & vbNewLine & "for Business Date: " & rd)

                        Dim da As SqlDataAdapter
                        Dim objCMD As SqlCommand = New SqlCommand("execute LCR_DETAILS  @RISKDATE='" & rdsql & "' ", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)
                        'da.SelectCommand = objCMD
                        '*******************************************************************
                        dt = New DataTable()
                        da.Fill(dt)

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            'Me.GridControl4.BeginUpdate()
                            Me.GridControl4.DataSource = Nothing
                            'Me.GridControl1.Refresh()
                            Me.GridControl4.DataSource = dt
                            Me.GridControl4.ForceInitialize()
                            'Me.LCR_Details_GridView.PopulateColumns()
                            'Me.LCR_Details_GridView.BestFitColumns()
                            'Me.GridControl4.RefreshDataSource()

                            'Calculate LCR
                            If cmd.Connection.State = ConnectionState.Closed Then
                                cmd.Connection.Open()
                            End If

                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCR_LA_Amount') and Id_SQL_Parameters_Details=685"
                            'cmd.CommandText = "SELECT Sum(Inflow) FROM [LCR_LA_BAIS] where  [RiskDate]='" & rdsql & "'"
                            Dim LCR_LA As Double = cmd.ExecuteScalar
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCR_IN_Amount') and Id_SQL_Parameters_Details=685"
                            'cmd.CommandText = "SELECT Sum(Inflow) FROM [LCR_IN_BAIS] where  [RiskDate]='" & rdsql & "'"
                            Dim LCR_IN As Double = cmd.ExecuteScalar
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCR_OUT_Amount') and Id_SQL_Parameters_Details=685"
                            'cmd.CommandText = "SELECT Sum(Outflow) FROM [LCR_OUT_BAIS] where  [RiskDate]='" & rdsql & "'"
                            Dim LCR_OUT As Double = cmd.ExecuteScalar
                            Me.TextEdit1.Text = LCR_LA
                            Me.TextEdit2.Text = LCR_IN
                            Me.TextEdit3.Text = LCR_OUT
                            cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS_SECOND] SET [SQL_Float_1]=0 where Id_SQL_Parameters_Details=685"
                            cmd.ExecuteNonQuery()
                            If cmd.Connection.State = ConnectionState.Open Then
                                cmd.Connection.Close()
                            End If
                            Dim IN_OUT_RATIO As Double = Math.Round(LCR_IN / LCR_OUT, 2)
                            Me.TextEdit4.Text = IN_OUT_RATIO
                            Dim CAP As Double = Math.Round(LCR_OUT * 0.75, 2)
                            Me.TextEdit5.Text = CAP
                            Dim LCR_RATIO As Double = 0
                            If LCR_IN > CAP Then
                                LCR_RATIO = Math.Round(LCR_LA / (LCR_OUT - CAP), 2)
                            Else
                                LCR_RATIO = Math.Round(LCR_LA / (LCR_OUT - LCR_IN), 2)
                            End If
                            Me.TextEdit6.Text = LCR_RATIO
                            SplashScreenManager.CloseForm(False)

                            'Dim n As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(0))
                            'Dim totalSum As Double = Convert.ToDouble(LCR_Details_GridView.Columns("Reportname").SummaryItem.SummaryValue)
                            'Dim m As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(String.Format("GroupSum: {0}; TotalSum: {1}", n, totalSum))
                            'n = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(0))
                            'm = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(n & "   " & m)
                        Else
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show("There are no Data for the LCR Details", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    MessageBox.Show("There are no Data for the LCR Details", "Data in LCR_LA_BAIS are missing for " & rd, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'IS DELEGATED ACT
            If rd >= DateSerial(2016, 9, 30) And rd <= DateSerial(2017, 12, 7) Then
                Me.LayoutControlItem6.Visibility = LayoutVisibility.Never
                Me.LayoutControlItem8.Visibility = LayoutVisibility.Never
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "SELECT Count([ID]) FROM [LCR_LA_BAIS] where  [RiskDate]='" & rdsql & "'"
                Dim n As Double = cmd.ExecuteScalar
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                If n > 0 Then
                    Try

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Calculate LCRDR Details (Stored Procedure:LCRDR_DETAILS) " & vbNewLine & "for Business Date: " & rd)


                        Dim da As SqlDataAdapter
                        Dim objCMD As SqlCommand = New SqlCommand("execute LCRDR_DETAILS  @RISKDATE='" & rdsql & "' ", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)
                        'da.SelectCommand = objCMD
                        '*******************************************************************
                        dt = New DataTable()
                        da.Fill(dt)

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            'Me.GridControl4.BeginUpdate()
                            Me.GridControl4.DataSource = Nothing
                            'Me.GridControl1.Refresh()
                            Me.GridControl4.DataSource = dt
                            Me.GridControl4.ForceInitialize()
                            'Me.LCR_Details_GridView.PopulateColumns()
                            'Me.LCR_Details_GridView.BestFitColumns()
                            'Me.GridControl4.RefreshDataSource()

                            'Calculate LCR
                            If cmd.Connection.State = ConnectionState.Closed Then
                                cmd.Connection.Open()
                            End If
                            'cmd.CommandText = "Select [Inflow] from [LCR_LA_BAIS] where [RowNr] in ('010') and [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_LA_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_LA As Double = cmd.ExecuteScalar
                            'cmd.CommandText = "Select [LCRDR_LiquidityBuffer] from [LCR_Overview] where [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_IN_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_IN As Double = cmd.ExecuteScalar
                            'cmd.CommandText = "Select [LCRDR_NetLiquidityOutflow] from [LCR_Overview] where [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_OUT_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_OUT As Double = cmd.ExecuteScalar
                            Me.TextEdit1.Text = LCRDR_LA
                            Me.TextEdit2.Text = LCRDR_IN
                            Me.TextEdit3.Text = LCRDR_OUT
                            cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS_SECOND] SET [SQL_Float_1]=0 where Id_SQL_Parameters_Details=686"
                            cmd.ExecuteNonQuery()

                            If cmd.Connection.State = ConnectionState.Open Then
                                cmd.Connection.Close()
                            End If

                            Dim LCRDR_RATIO As Double = 0
                            Dim LCRDR_NetLiquidityOutflow = Math.Round(LCRDR_OUT - LCRDR_IN, 2)

                            LCRDR_RATIO = Math.Round(LCRDR_LA / LCRDR_NetLiquidityOutflow, 2)

                            Me.TextEdit6.Text = LCRDR_RATIO
                            SplashScreenManager.CloseForm(False)

                            'Dim n As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(0))
                            'Dim totalSum As Double = Convert.ToDouble(LCR_Details_GridView.Columns("Reportname").SummaryItem.SummaryValue)
                            'Dim m As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(String.Format("GroupSum: {0}; TotalSum: {1}", n, totalSum))
                            'n = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(0))
                            'm = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(n & "   " & m)
                        Else
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show("There are no Data for the LCR Details", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    MessageBox.Show("There are no Data for the LCR Details", "Data in LCR_LA_BAIS are missing for " & rd, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'NEWG
            If rd >= DateSerial(2017, 12, 8) Then
                Me.LayoutControlItem6.Visibility = LayoutVisibility.Never
                Me.LayoutControlItem8.Visibility = LayoutVisibility.Never
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "SELECT Count([ID]) FROM [LCR_LA_BAIS] where  [RiskDate]='" & rdsql & "'"
                Dim n As Double = cmd.ExecuteScalar
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                If n > 0 Then
                    Try

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Calculate LCRDR Details (Stored Procedure:LCRDR_DETAILS_NEWG) " & vbNewLine & "for Business Date: " & rd)


                        Dim da As SqlDataAdapter
                        Dim objCMD As SqlCommand = New SqlCommand("execute LCRDR_DETAILS_NEWG  @RISKDATE='" & rdsql & "' ", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)
                        'da.SelectCommand = objCMD
                        '*******************************************************************
                        dt = New DataTable()
                        da.Fill(dt)

                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            'Me.GridControl4.BeginUpdate()
                            Me.GridControl4.DataSource = Nothing
                            'Me.GridControl1.Refresh()
                            Me.GridControl4.DataSource = dt
                            Me.GridControl4.ForceInitialize()
                            'Me.LCR_Details_GridView.PopulateColumns()
                            'Me.LCR_Details_GridView.BestFitColumns()
                            'Me.GridControl4.RefreshDataSource()

                            'Calculate LCR
                            If cmd.Connection.State = ConnectionState.Closed Then
                                cmd.Connection.Open()
                            End If
                            'cmd.CommandText = "Select [Inflow] from [LCR_LA_BAIS] where [RowNr] in ('010') and [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_LA_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_LA As Double = cmd.ExecuteScalar
                            'cmd.CommandText = "Select [LCRDR_LiquidityBuffer] from [LCR_Overview] where [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_IN_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_IN As Double = cmd.ExecuteScalar
                            'cmd.CommandText = "Select [LCRDR_NetLiquidityOutflow] from [LCR_Overview] where [RiskDate]='" & rdsql & "'"
                            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('LCRDR_OUT_Amount') and Id_SQL_Parameters_Details=686"
                            Dim LCRDR_OUT As Double = cmd.ExecuteScalar
                            Me.TextEdit1.Text = LCRDR_LA
                            Me.TextEdit2.Text = LCRDR_IN
                            Me.TextEdit3.Text = LCRDR_OUT
                            cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS_SECOND] SET [SQL_Float_1]=0 where Id_SQL_Parameters_Details=686"
                            cmd.ExecuteNonQuery()

                            If cmd.Connection.State = ConnectionState.Open Then
                                cmd.Connection.Close()
                            End If

                            Dim LCRDR_RATIO As Double = 0
                            Dim LCRDR_NetLiquidityOutflow = Math.Round(LCRDR_OUT - LCRDR_IN, 2)

                            LCRDR_RATIO = Math.Round(LCRDR_LA / LCRDR_NetLiquidityOutflow, 2)

                            Me.TextEdit6.Text = LCRDR_RATIO
                            SplashScreenManager.CloseForm(False)

                            'Dim n As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(0))
                            'Dim totalSum As Double = Convert.ToDouble(LCR_Details_GridView.Columns("Reportname").SummaryItem.SummaryValue)
                            'Dim m As Double = LCR_Details_GridView.GetGroupSummaryValue(-1, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(String.Format("GroupSum: {0}; TotalSum: {1}", n, totalSum))
                            'n = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(0))
                            'm = LCR_Details_GridView.GetGroupSummaryValue(-2, LCR_Details_GridView.GroupSummary(1))
                            'MsgBox(n & "   " & m)
                        Else
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show("There are no Data for the LCR Details", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    MessageBox.Show("There are no Data for the LCR Details", "Data in LCR_LA_BAIS are missing for " & rd, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

        End If
    End Sub

    Private Sub LCR_Details_GridView_CustomColumnGroup(sender As Object, e As CustomColumnSortEventArgs) Handles LCR_Details_GridView.CustomColumnGroup
        If rd <= DateSerial(2016, 9, 29) Then
            If e.Column.FieldName = "Reportname" Then
                ' If compared field values are the same return 0
                If e.Value1 = e.Value2 Then
                    e.Result = 0
                Else
                    ' Check on first field value
                    Select Case e.Value1.ToString()

                        Case "LCR_IN"
                            ' "LCR_IN" is lowest status value, so always return -1
                            e.Result = -1
                        Case "LCR_LA"
                            ' "LCR_LA is highest status value, so always return 1
                            e.Result = 1
                        Case "LCR_OUT"
                            ' "LCR_OUT" is middle status, so result depends on second row's field value
                            If e.Value2.ToString() = "LCR_IN" Then
                                ' "LCR_IN" is lowest status, so the current field value will always be higher
                                e.Result = 1
                            Else
                                ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                                e.Result = -1
                            End If
                    End Select
                End If
                e.Handled = True
            End If
        End If

        If rd >= DateSerial(2016, 9, 30) Then
            If e.Column.FieldName = "Reportname" Then
                ' If compared field values are the same return 0
                If e.Value1 = e.Value2 Then
                    e.Result = 0
                Else
                    ' Check on first field value
                    Select Case e.Value1.ToString()

                        Case "LCRDR_IN"
                            ' "LCR_IN" is lowest status value, so always return -1
                            e.Result = -1
                        Case "LCRDR_LA"
                            ' "LCR_LA is highest status value, so always return 1
                            e.Result = 1
                        Case "LCRDR_OUT"
                            ' "LCR_OUT" is middle status, so result depends on second row's field value
                            If e.Value2.ToString() = "LCRDR_IN" Then
                                ' "LCR_IN" is lowest status, so the current field value will always be higher
                                e.Result = 1
                            Else
                                ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                                e.Result = -1
                            End If
                    End Select
                End If
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub LCR_Details_GridView_CustomColumnSort(sender As Object, e As CustomColumnSortEventArgs) Handles LCR_Details_GridView.CustomColumnSort
        If rd <= DateSerial(2016, 9, 29) Then
            If e.Column.FieldName = "Reportname" Then
                ' If compared field values are the same return 0
                If e.Value1 = e.Value2 Then
                    e.Result = 0
                Else
                    ' Check on first field value
                    Select Case e.Value1.ToString()

                        Case "LCR_IN"
                            ' "LCR_IN" is lowest status value, so always return -1
                            e.Result = -1
                        Case "LCR_LA"
                            ' "LCR_LA is highest status value, so always return 1
                            e.Result = 1
                        Case "LCR_OUT"
                            ' "LCR_OUT" is middle status, so result depends on second row's field value
                            If e.Value2.ToString() = "LCR_IN" Then
                                ' "LCR_IN" is lowest status, so the current field value will always be higher
                                e.Result = 1
                            Else
                                ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                                e.Result = -1
                            End If
                    End Select
                End If
                e.Handled = True
            End If
        End If

        If rd >= DateSerial(2016, 9, 30) Then
            If e.Column.FieldName = "Reportname" Then
                ' If compared field values are the same return 0
                If e.Value1 = e.Value2 Then
                    e.Result = 0
                Else
                    ' Check on first field value
                    Select Case e.Value1.ToString()

                        Case "LCRDR_IN"
                            ' "LCR_IN" is lowest status value, so always return -1
                            e.Result = -1
                        Case "LCRDR_LA"
                            ' "LCR_LA is highest status value, so always return 1
                            e.Result = 1
                        Case "LCRDR_OUT"
                            ' "LCR_OUT" is middle status, so result depends on second row's field value
                            If e.Value2.ToString() = "LCRDR_IN" Then
                                ' "LCR_IN" is lowest status, so the current field value will always be higher
                                e.Result = 1
                            Else
                                ' If value 2 is not 'LCR_IN' it must be 'LCR_OUT', so current field value is lower
                                e.Result = -1
                            End If
                    End Select
                End If
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub LCR_Details_GridView_CustomDrawGroupRow(sender As Object, e As RowObjectCustomDrawEventArgs) Handles LCR_Details_GridView.CustomDrawGroupRow
        Dim rowInfo As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
        If rowInfo.Column.FieldName = "Reportname" Then
            Dim caption As String = String.Format("{0}:", rowInfo.Column.GetCaption())
            rowInfo.GroupText = rowInfo.GroupText.Replace(caption, "")
        End If
    End Sub

    Private Sub LCR_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LCR_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LCR_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles LCR_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        Dim result As Integer = MessageBox.Show("Should only the LCR Details be printed/Exported?", "Print-Export LCR Details", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result = DialogResult.Yes Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)

        ElseIf result = DialogResult.No Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem4.Visibility = LayoutVisibility.Never
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem4.Visibility = LayoutVisibility.Always
            SplashScreenManager.CloseForm(False)
        ElseIf result = DialogResult.Cancel Then
            Exit Sub
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
        Dim reportfooter As String = "LCR DETAILS" & "    " & "Business Date: " & rd
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub LCR_Date_Comboedit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LCR_Date_Comboedit.SelectedIndexChanged
        Me.GridControl4.DataSource = Nothing
        Me.TextEdit1.Text = 0
        Me.TextEdit2.Text = 0
        Me.TextEdit3.Text = 0
        Me.TextEdit4.Text = 0
        Me.TextEdit5.Text = 0
        Me.TextEdit6.Text = 0
        'Define if the calculation is on delegated act
        rd = Me.LCR_Date_Comboedit.Text
        If rd <= DateSerial(2016, 9, 29) Then
            Me.LayoutControlItem6.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Always
        ElseIf rd >= DateSerial(2016, 9, 30) Then
            Me.LayoutControlItem6.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem8.Visibility = LayoutVisibility.Never
        End If
    End Sub
End Class