Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
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
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.Drawing
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraEditors.Repository

Public Class ChinesseReporting

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim ExcelFileName As String = Nothing
    Private BS_BusinessDates As BindingSource

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private daR As New SqlDataAdapter
    Private dtR As New DataTable

    Dim d As Date
    Dim rdsql As String = Nothing
    Dim BD_RepositoryString As String = Nothing
    Dim workbook As IWorkbook
    Dim SqlCommandText As String = Nothing

    Dim n As Double = 0
    Dim LastDayLastMonth As Date
    Dim LastDayCurrentMonthLastYear As Date




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

    Private Sub ChinesseReporting_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.QueryText = "SELECT [PARAMETER1] as 'Current Report',[PARAMETER2] as 'Report Directory' FROM [PARAMETER] where  [IdABTEILUNGSPARAMETER]='CHINESSE_REPORTS_DIRECTORY' and [PARAMETER STATUS]='Y' ORDER BY ID Asc "
        daR = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dtR = New System.Data.DataTable()
        daR.Fill(dtR)
        For Each row As DataRow In dtR.Rows
            If dtR.Rows.Count > 0 Then
                Me.RepositoryItemComboBox2.Items.Add(row("Current Report"))
            End If
        Next
        If dtR.Rows.Count > 0 Then
            Me.CurrentReportFile_BarEditItem.EditValue = dtR.Rows.Item(0).Item("Current Report")
            'ExcelFileName = dtR.Rows.Item(0).Item("Report Directory")
            
        End If



        'Bind Business Date Lookup edit
        BusinessDates_initData()
        BusinessDates_InitLookUp()

      
    End Sub
    Private Sub CurrentReportFile_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles CurrentReportFile_BarEditItem.EditValueChanged

        If Me.CurrentReportFile_BarEditItem.EditValue.ToString <> "" Then
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='" & Me.CurrentReportFile_BarEditItem.EditValue.ToString & "' and [IdABTEILUNGSPARAMETER]='CHINESSE_REPORTS_DIRECTORY' and [PARAMETER STATUS]='Y' "
            cmd.Connection.Open()
            ExcelFileName = cmd.ExecuteScalar
            cmd.Connection.Close()

            workbook = SpreadsheetControl1.Document
            Using stream As New FileStream(ExcelFileName, FileMode.Open)
                workbook.LoadDocument(stream, DocumentFormat.OpenXml)
            End Using
        End If

    End Sub
    Private Sub BusinessDates_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter("Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'Business Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL ORDER BY [ID] desc", conn) '
        Try

            dbBusinessDates.Fill(ds, "RISK LIMIT DAILY CONTROL")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_BusinessDates = New BindingSource(ds, "RISK LIMIT DAILY CONTROL")

    End Sub
    Private Sub BusinessDates_InitLookUp()
        Me.RepositoryItemLookUpEdit1.DataSource = BS_BusinessDates
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Business Date"
        Me.RepositoryItemLookUpEdit1.ValueMember = "Business Date"
    End Sub

    Private Sub LoadData_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadData_BarButtonItem.ItemClick
        If BD_RepositoryString <> "" Then
            d = BD_RepositoryString
            rdsql = d.ToString("yyyyMMdd")
            If Me.CurrentReportFile_BarEditItem.EditValue = "SEVERAL CHINESSE REPORTS" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                    GET_DATA_INTERMEDIATE_BUSINESS_INCOME()
                    GET_DATA_PL_REPORT_FORECAST()
                    GET_DATA_BALANCE_REPORT_FORECAST()
                    GET_DATA_AVERAGE_BALANCE_REPORT_FORECAST()
                    workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End Try
            ElseIf Me.CurrentReportFile_BarEditItem.EditValue = "ASSETS-LIABILITIES MATURITIES SUBTOTALS" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                    GET_DATA_ASSETS_LIABILITIES_MATURITIES()
                    workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End Try
            ElseIf Me.CurrentReportFile_BarEditItem.EditValue = "MONATSBERICHT" Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Data for " & d)
                    GET_DATA_MONATSBERICHT_ASSETS_AND_LIABILITIES()
                    GET_DATA_MONATSBERICHT_PROFIT_LOSS()
                    GET_DATA_MONATSBERICHT_INTEREST_RECEIVED_PAID()
                    workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End Try
            End If
       

        Else
            MessageBox.Show("Please select a Business Date!", "NO SELECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If

    End Sub

    Private Sub RepositoryItemLookUpEdit1_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles RepositoryItemLookUpEdit1.EditValueChanging
        Dim edit As DevExpress.XtraEditors.LookUpEdit
        edit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        BD_RepositoryString = edit.Properties.GetDisplayValueByKeyValue(e.NewValue).ToString()

    End Sub

    Private Sub SaveAs_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SaveAs_BarButtonItem.ItemClick
        Using myFileDialog As New SaveFileDialog()
            myFileDialog.Filter = "Excel File (*.xlsx)|.xlsx" '"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            myFileDialog.FilterIndex = 1
            myFileDialog.InitialDirectory = "C:\"
            myFileDialog.CheckFileExists = False
            myFileDialog.RestoreDirectory = False

            Dim result As DialogResult = myFileDialog.ShowDialog
            'Dim workbook As New Workbook()

            If result = DialogResult.OK Then

                'workbook.SaveDocument(myFileDialog.FileName, DocumentFormat.OpenXml)
                Me.SpreadsheetControl1.Document.SaveDocument(myFileDialog.FileName, DocumentFormat.OpenXml)

            End If
        End Using
    End Sub


    Private Sub GET_DATA_INTERMEDIATE_BUSINESS_INCOME()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - INTERMEDIATE BUSINESS INCOME'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            cmd.CommandText = "Select DATEADD(MONTH, DATEDIFF(MONTH, -1, '" & rdsql & "')-1, -1)"
            LastDayLastMonth = cmd.ExecuteScalar

            cmd.CommandText = "Select DATEADD(YEAR,-1,DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0, '" & rdsql & "')+1,0)))"
            LastDayCurrentMonthLastYear = cmd.ExecuteScalar

            workbook.Worksheets(0).Cells("E5").Value = d
            workbook.Worksheets(0).Cells("G6").Value = LastDayLastMonth
            workbook.Worksheets(0).Cells("I6").Value = LastDayCurrentMonthLastYear

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - INTERMEDIATE BUSINESS INCOME') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(0).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(0).Cells(ExcelCell).Value = 0
                End If
            Next
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - INTERMEDIATE BUSINESS INCOME') and [SQL_Command_2] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_2").ToString
                'Next Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(0).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(0).Cells(ExcelCell).Value = 0
                End If
            Next
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - INTERMEDIATE BUSINESS INCOME') and [SQL_Command_3] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_3").ToString
                'last Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(0).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(0).Cells(ExcelCell).Value = 0
                End If
            Next

        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_PL_REPORT_FORECAST()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - PL REPORT FOR FORECAST'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'cmd.CommandText = "Select DATEADD(MONTH, DATEDIFF(MONTH, -1, '" & rdsql & "')-1, -1)"
            'LastDayLastMonth = cmd.ExecuteScalar

            'cmd.CommandText = "Select DATEADD(YEAR,-1,DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0, '" & rdsql & "')+1,0)))"
            cmd.CommandText = "select DATEADD(YEAR,-1,'" & rdsql & "')"
            LastDayCurrentMonthLastYear = cmd.ExecuteScalar

            workbook.Worksheets(1).Cells("C4").Value = d
            'workbook.Worksheets(1).Cells("G6").Value = LastDayLastMonth
            workbook.Worksheets(1).Cells("D4").Value = LastDayCurrentMonthLastYear

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - PL REPORT FOR FORECAST') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(1).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(1).Cells(ExcelCell).Value = 0
                End If
            Next

            'Same date last year
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - PL REPORT FOR FORECAST') and [SQL_Command_3] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_2").ToString
                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(1).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(1).Cells(ExcelCell).Value = 0
                End If
            Next
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_BALANCE_REPORT_FORECAST()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - BALANCE REPORT FOR FORECAST'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'cmd.CommandText = "Select DATEADD(MONTH, DATEDIFF(MONTH, -1, '" & rdsql & "')-1, -1)"
            'LastDayLastMonth = cmd.ExecuteScalar

            'cmd.CommandText = "Select DATEADD(YEAR,-1,DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0, '" & rdsql & "')+1,0)))"
            cmd.CommandText = "select DATEADD(YEAR,-1,'" & rdsql & "')"
            LastDayCurrentMonthLastYear = cmd.ExecuteScalar

            workbook.Worksheets(2).Cells("C5").Value = d
            'workbook.Worksheets(1).Cells("G6").Value = LastDayLastMonth
            workbook.Worksheets(2).Cells("D5").Value = LastDayCurrentMonthLastYear

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - BALANCE REPORT FOR FORECAST') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(2).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(2).Cells(ExcelCell).Value = 0
                End If
            Next

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - BALANCE REPORT FOR FORECAST') and [SQL_Command_3] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_3").ToString
                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(2).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(2).Cells(ExcelCell).Value = 0
                End If
            Next
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_AVERAGE_BALANCE_REPORT_FORECAST()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT -AVERAGE BALANCE REPORT FOR FORECAST'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            'cmd.CommandText = "Select DATEADD(MONTH, DATEDIFF(MONTH, -1, '" & rdsql & "')-1, -1)"
            'LastDayLastMonth = cmd.ExecuteScalar

            'cmd.CommandText = "Select DATEADD(YEAR,-1,DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0, '" & rdsql & "')+1,0)))"
            cmd.CommandText = "select DATEADD(YEAR,-1,'" & rdsql & "')"
            LastDayCurrentMonthLastYear = cmd.ExecuteScalar

            workbook.Worksheets(3).Cells("C5").Value = d
            'workbook.Worksheets(1).Cells("G6").Value = LastDayLastMonth
            workbook.Worksheets(3).Cells("D5").Value = LastDayCurrentMonthLastYear

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT -AVERAGE BALANCE REPORT FOR FORECAST')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "1100" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C8").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C8").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D8").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D8").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "1200" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C9").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C9").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D9").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D9").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "1300" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C10").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C10").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D10").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D10").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "1310" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C11").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C11").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D11").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D11").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "2000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C13").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C13").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D13").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D13").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "3000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C14").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C14").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D14").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D14").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "4000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C15").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C15").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D15").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D15").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "5000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C16").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C16").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D16").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D16").Value = 0
                    End If
                End If

                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "9000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C20").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C20").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D20").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D20").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "a1100" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C24").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C24").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D24").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D24").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "a1200" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C25").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C25").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D25").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D25").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "a3000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C27").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C27").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D27").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D27").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "a4000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C28").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C28").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D28").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D28").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "a8000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C32").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C32").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D32").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D32").Value = 0
                    End If
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1").ToString = "b2000" Then
                    'Current Date
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("C35").Value = n
                    Else
                        workbook.Worksheets(3).Cells("C35").Value = 0
                    End If
                    'Last Day same Month last year
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_3").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        n = cmd.ExecuteScalar
                        workbook.Worksheets(3).Cells("D35").Value = n
                    Else
                        workbook.Worksheets(3).Cells("D35").Value = 0
                    End If
                End If
            Next
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_ASSETS_LIABILITIES_MATURITIES()
        'Execute storred Procedure to get Data
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "EXECUTE [ASSETS_LIABILITIES_MATURITIES_QUERY] @RISKDATE='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()


        workbook.Worksheets(0).Cells("K1").Value = d
        workbook.Worksheets(1).Cells("K1").Value = d

        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)
        Dim worksheet2 As Worksheet = workbook.Worksheets(2)

        worksheet.ClearContents(worksheet("A5:J5000"))
        worksheet1.ClearContents(worksheet1("A5:J5000"))
        worksheet2.ClearContents(worksheet2("A2:P5000"))

        'Sums in Assets-Subtotals Worksheet
        Me.QueryText = "Select 'S1'=Sum(CASE when [MaturityPeriod]='Next Day' then [Principal Amount EUR] else 0 END),'S2'=Sum(CASE when [MaturityPeriod]='2 to 7 Days' then [Principal Amount EUR] else 0 END),'S3'=Sum(CASE when [MaturityPeriod]='8 to 30 Days' then [Principal Amount EUR] else 0 END),'S4'=Sum(CASE when [MaturityPeriod]='1 Month to 3 Months' then [Principal Amount EUR] else 0 END),'S5'=Sum(CASE when [MaturityPeriod]='3 Months to 6 Months' then [Principal Amount EUR] else 0 END),'S6'=Sum(CASE when [MaturityPeriod]='6 Months to 1 Year' then [Principal Amount EUR] else 0 END),'S7'=Sum(CASE when [MaturityPeriod]='Over 1 Year' then [Principal Amount EUR] else 0 END) from [ASSETS_LIABILITIES_MATURITIES] where [Class]='Assets'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, False, 3, 2)
        'Subtotals Data
        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [SQL_Name_1] in ('ASSETS_SUBTOTALS_MATURITIES_QUERY') and [SQL_Command_1] is not NULL and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS') and [Status] in ('Y')"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
            'cmd.CommandText = SqlCommandText
        Next
        'Me.QueryText = "EXECUTE [ASSETS_SUBTOTALS_MATURITIES_QUERY]"
        Me.QueryText = SqlCommandText
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, False, 4, 0)
        'Dim range As Range = worksheet.Range("A5:I1000")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Nothing
        'rangeFormatting.Fill.BackgroundColor = Nothing
        'range.EndUpdateFormatting(rangeFormatting)

        'Sums in Liabilities-Subtotals Worksheet
        Me.QueryText = "Select 'S1'=Sum(CASE when [MaturityPeriod]='Next Day' then [Principal Amount EUR] else 0 END),'S2'=Sum(CASE when [MaturityPeriod]='2 to 7 Days' then [Principal Amount EUR] else 0 END),'S3'=Sum(CASE when [MaturityPeriod]='8 to 30 Days' then [Principal Amount EUR] else 0 END),'S4'=Sum(CASE when [MaturityPeriod]='1 Month to 3 Months' then [Principal Amount EUR] else 0 END),'S5'=Sum(CASE when [MaturityPeriod]='3 Months to 6 Months' then [Principal Amount EUR] else 0 END),'S6'=Sum(CASE when [MaturityPeriod]='6 Months to 1 Year' then [Principal Amount EUR] else 0 END),'S7'=Sum(CASE when [MaturityPeriod]='Over 1 Year' then [Principal Amount EUR] else 0 END) from [ASSETS_LIABILITIES_MATURITIES] where [Class]='Liabilities'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet1.Import(dt, False, 3, 2)
        'Subtotals Data
        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [SQL_Name_1] in ('LIABILITIES_SUBTOTALS_MATURITIES_QUERY') and [SQL_Command_1] is not NULL and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS') and [Status] in ('Y')"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
            'cmd.CommandText = SqlCommandText
        Next
        'Me.QueryText = "EXECUTE [LIABILITIES_SUBTOTALS_MATURITIES_QUERY]"
        Me.QueryText = SqlCommandText
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet1.Import(dt, False, 4, 0)
        'Dim range1 As Range = worksheet1.Range("A5:I1000")
        'Dim rangeFormatting1 As DevExpress.Spreadsheet.Formatting = range1.BeginUpdateFormatting()
        'rangeFormatting1.Font.Color = Nothing
        'rangeFormatting1.Fill.BackgroundColor = Nothing
        'range1.EndUpdateFormatting(rangeFormatting1)

        Me.QueryText = "Select [Class],[GL Master / Account Type],[ContractNr],[Customer Name],[GL_Account_Nr],[GL_Account_Name],[GL_Item],[GL_Item_Name],[Contract Type],[Product Type],[Start Date],[Final Maturity Date],CUR,PrincipalOriginalAmount,[Principal Amount EUR],[RiskDate],[DaysToMaturity],[MaturityPeriod] from  [ASSETS_LIABILITIES_MATURITIES] ORDER BY [GL_Account_Nr] Asc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet2.Import(dt, False, 1, 0)
        'Dim range2 As Range = worksheet2.Range("A2:P5000")
        'Dim rangeFormatting2 As DevExpress.Spreadsheet.Formatting = range2.BeginUpdateFormatting()
        'rangeFormatting2.Font.Color = Nothing
        'rangeFormatting2.Fill.BackgroundColor = Nothing
        'range2.EndUpdateFormatting(rangeFormatting2)

    End Sub

    Private Sub GET_DATA_MONATSBERICHT_ASSETS_AND_LIABILITIES()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - MONATSBERICHT - ASSETS AND LIABILITIES'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
           
            workbook.Worksheets(0).Cells("G1").Value = d
            
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - MONATSBERICHT - ASSETS AND LIABILITIES') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString

                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                n = cmd.ExecuteScalar
                workbook.Worksheets(0).Cells(ExcelCell).Value = n
               
            Next
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_MONATSBERICHT_PROFIT_LOSS()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - MONATSBERICHT - PROFIT AND LOSS'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then

            workbook.Worksheets(1).Cells("D2").Value = "Y-T-D Total von 218"
            workbook.Worksheets(1).Cells("L2").Value = d

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - MONATSBERICHT - PROFIT AND LOSS') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString

                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                n = cmd.ExecuteScalar
                workbook.Worksheets(1).Cells(ExcelCell).Value = n

            Next
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub GET_DATA_MONATSBERICHT_INTEREST_RECEIVED_PAID()
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CHINESSE REPORT - MONATSBERICHT - INTEREST RECEIVED AND PAID'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then

            workbook.Worksheets(2).Cells("J1").Value = d

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - MONATSBERICHT - INTEREST RECEIVED AND PAID') and [SQL_Command_1] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString

                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(2).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(2).Cells(ExcelCell).Value = 0
                End If
                
            Next

            '+++++++++++++++++++++++++++++++++++++++++++++
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CHINESSE REPORT - MONATSBERICHT - INTEREST RECEIVED AND PAID') and [SQL_Command_2] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_2").ToString

                'Current Date
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_2").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    n = cmd.ExecuteScalar
                    workbook.Worksheets(2).Cells(ExcelCell).Value = n
                Else
                    workbook.Worksheets(2).Cells(ExcelCell).Value = 0
                End If

            Next

        End If
        cmd.Connection.Close()
    End Sub

   
    Private Sub SpreadsheetControl1_InvalidFormatException(sender As Object, e As SpreadsheetInvalidFormatExceptionEventArgs) Handles SpreadsheetControl1.InvalidFormatException
        'Set first throwException on TRUE in Options.Import
        XtraMessageBox.Show(e.Exception.Message.ToString, "ERROR ON LOADED EXCEL FILE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    End Sub
End Class