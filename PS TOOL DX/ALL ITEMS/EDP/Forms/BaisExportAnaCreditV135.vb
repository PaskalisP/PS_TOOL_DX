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
Imports Ionic.Zip



'*****************************************
'Class Name: BaisExportAnaCreditV134
'Version: V1.0.0.0
'Version Explanation:
'Author: CCBFF
'Email: info@ccbff.de
'Creation Time:
'Content:
'Function:
'Description:
'Modify log:  
'    1. Add by WYQ; Time:10.06.2022; Content: BAIS system version is updated to Version 1.35. Add the BaisExportAnaCreditV134 class for Bais Version 1.35

'******************************************

Public Class BaisExportAnaCreditV135

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEvent As New SqlConnection
    Dim cmdEvent As New SqlCommand

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Private BS_AnaCreditDataCheck As BindingSource

    Dim ParameterStatus As String = Nothing
    Dim HasDataResult As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim StartFileCreation_btn_clicked As Boolean = False 'Button for Start Client
    Dim BaisFilesCreationPath As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim ACCPIF_Result As String = Nothing
    Dim ACFDIF_Result As String = Nothing
    Dim ACFAIF_Result As String = Nothing
    Dim ACIPIF_Result As String = Nothing
    Dim ACCFIF_Result As String = Nothing
    Dim ACIFIF_Result As String = Nothing
    Dim ACPCIF_Result As String = Nothing
    Dim ACPDIF_Result As String = Nothing

    Dim KSRIFF_Result As String = Nothing
    Dim LQGIFF_Result As String = Nothing
    Dim MKUIFF_Result As String = Nothing
    Dim ZUSIFF_Result As String = Nothing
    Dim GAKIFF_Result As String = Nothing
    Dim GAGIFF_Result As String = Nothing
    Dim LQKIFF_Result As String = Nothing
    Dim DESIFF_Result As String = Nothing
    Dim WHGIFF_Result As String = Nothing

    Private BS_All_BusinessDates As BindingSource

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

    Private Sub BaisExportAnaCreditV134_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwBaisFilesCreation.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub BaisExportAnaCreditV135_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        connEvent.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEvent.Connection = connEvent

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='BaisFilesCreationDirectory' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='BAIS_EXPORT'"
        BaisFilesCreationPath = cmd.ExecuteScalar
        cmd.Connection.Close()
        'Create directory if not exists
        If Not Directory.Exists(BaisFilesCreationPath) Then
            Directory.CreateDirectory(BaisFilesCreationPath)
        End If
        'Change Text in Groupbox
        Me.GroupControl1.Text = "BAIS AnaCredit Interface Files - Creation Path:" & BaisFilesCreationPath

        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.BusinessDate_SearchLookUpEdit.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString

        'Bind Combobox
        'Me.BusinessDate_Comboedit.Properties.Items.Clear()
        ''Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' and [PL Result] is not NULL ORDER BY [ID] desc"
        'Me.QueryText = "Declare @MAXRISKDATE Datetime=(Select Max(RiskDate) from ANACREDIT_CONTRACTS Where DAY(DATEADD(day, 1, RiskDate)) = 1)Select CONVERT(VARCHAR(10),B.R,104) as 'RLDC Date' from (Select RiskDate as R from ANACREDIT_CONTRACTS Where (DAY(DATEADD(day, 1, RiskDate)) = 1) UNION ALL Select Max(RiskDate) as R from ANACREDIT_CONTRACTS Where RiskDate>@MAXRISKDATE)B where B.R is not NULL GROUP BY B.R Order by B.R desc"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'For Each row As DataRow In dt.Rows
        '    If dt.Rows.Count > 0 Then
        '        Me.BusinessDate_Comboedit.Properties.Items.Add(row("RLDC Date"))
        '    End If
        'Next
        'If dt.Rows.Count > 0 Then
        '    Me.BusinessDate_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        'End If
    End Sub


    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @MAXRISKDATE Datetime=(Select Max(RiskDate) from ANACREDIT_CONTRACTS Where DAY(DATEADD(day, 1, RiskDate)) = 1)
                                                    Select CONVERT(VARCHAR(10),B.R,104) as 'Business Date' from (Select RiskDate as R from ANACREDIT_CONTRACTS Where (DAY(DATEADD(day, 1, RiskDate)) = 1) 
                                                    UNION ALL Select Max(RiskDate) as R from ANACREDIT_CONTRACTS Where RiskDate>@MAXRISKDATE)B where B.R is not NULL GROUP BY B.R Order by B.R desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "Business Date")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_BusinessDates = New BindingSource(ds, "Business Date")
    End Sub
    Private Sub ALL_BUSINESS_DATES_InitLookUp()
        Me.BusinessDate_SearchLookUpEdit.Properties.DataSource = BS_All_BusinessDates
        Me.BusinessDate_SearchLookUpEdit.Properties.DisplayMember = "Business Date"
        Me.BusinessDate_SearchLookUpEdit.Properties.ValueMember = "Business Date"
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Print Grid
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Custom Then
            If e.Button.Hint.Contains("Print") = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "AnaCredit Customers Data Check" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#Region "ENABLE_DISABLE_CONTROLS_BY_FILE CREATION"
    Private Sub DISABLE_START_CREATION()
        Me.ACCPIF_Result_lbl.Text = ""
        Me.ACFDIF_Result_lbl.Text = ""
        Me.ACFAIF_Result_lbl.Text = ""
        Me.ACIPIF_Result_lbl.Text = ""
        Me.ACCFIF_Result_lbl.Text = ""
        Me.ACIFIF_Result_lbl.Text = ""
        Me.ACPCIF_Result_lbl.Text = ""
        Me.ACPDIF_Result_lbl.Text = ""

        Me.StartFileCreation_btn.Enabled = False
        Me.CheckAll_btn.Enabled = False
        Me.OpenFolder_btn.Enabled = False
        Me.BusinessDate_SearchLookUpEdit.Enabled = False
        Me.GroupControl1.Enabled = False
        Me.BaisExportEvents_RichTextBox.Clear()

    End Sub

    Private Sub ENABLE_FINISH_CREATION()

        StartFileCreation_btn.Enabled = True
        Me.CheckAll_btn.Enabled = True
        Me.OpenFolder_btn.Enabled = True
        Me.BusinessDate_SearchLookUpEdit.Enabled = True
        Me.GroupControl1.Enabled = True
        Me.ACCPIF_Result_lbl.Text = ACCPIF_Result
        Me.ACFDIF_Result_lbl.Text = ACFDIF_Result
        Me.ACFAIF_Result_lbl.Text = ACFAIF_Result
        Me.ACIPIF_Result_lbl.Text = ACIPIF_Result
        Me.ACCFIF_Result_lbl.Text = ACCFIF_Result
        Me.ACIFIF_Result_lbl.Text = ACIFIF_Result
        Me.ACPCIF_Result_lbl.Text = ACPCIF_Result
        Me.ACPDIF_Result_lbl.Text = ACPDIF_Result


        'Fore Color in Result Labels
        If Me.ACCPIF_Result_lbl.Text = "Not Created" Then
            Me.ACCPIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACCPIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACFDIF_Result_lbl.Text = "Not Created" Then
            Me.ACFDIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACFDIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACFAIF_Result_lbl.Text = "Not Created" Then
            Me.ACFAIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACFAIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACIPIF_Result_lbl.Text = "Not Created" Then
            Me.ACIPIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACIPIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACCFIF_Result_lbl.Text = "Not Created" Then
            Me.ACCFIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACCFIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACIFIF_Result_lbl.Text = "Not Created" Then
            Me.ACIFIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACIFIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACPCIF_Result_lbl.Text = "Not Created" Then
            Me.ACPCIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACPCIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ACPDIF_Result_lbl.Text = "Not Created" Then
            Me.ACPDIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ACPDIF_Result_lbl.ForeColor = Color.Lime
        End If

        'NEW
        If ACCPIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACCPIF_Result_lbl.Text = ""
        End If
        If ACFDIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACFDIF_Result_lbl.Text = ""
        End If
        If ACFAIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACFAIF_Result_lbl.Text = ""
        End If
        If ACIPIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACIPIF_Result_lbl.Text = ""
        End If
        If ACCFIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACCFIF_Result_lbl.Text = ""
        End If
        If ACIFIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACIFIF_Result_lbl.Text = ""
        End If
        If ACPCIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACPCIF_Result_lbl.Text = ""
        End If
        If ACPDIF_CheckEdit.CheckState = CheckState.Unchecked Then
            ACPDIF_Result_lbl.Text = ""
        End If

    End Sub
#End Region

    Private Sub StartFileCreation_btn_Click(sender As Object, e As EventArgs) Handles StartFileCreation_btn.Click
        StartFileCreation_btn_clicked = True
        If IsDate(Me.BusinessDate_SearchLookUpEdit.Text) = True Then
            'ACIFIF_CheckEdit.CheckState = CheckState.Checked OrElse _
            'ACPCIF_CheckEdit.CheckState = CheckState.Checked OrElse _
            'ACIPIF_CheckEdit.CheckState = CheckState.Checked
            If ACCPIF_CheckEdit.CheckState = CheckState.Checked OrElse
                ACFDIF_CheckEdit.CheckState = CheckState.Checked OrElse
                ACFAIF_CheckEdit.CheckState = CheckState.Checked OrElse
                ACCFIF_CheckEdit.CheckState = CheckState.Checked OrElse
                ACPDIF_CheckEdit.CheckState = CheckState.Checked Then
                If XtraMessageBox.Show("Should the BAIS AnaCredit Interface Files creation be started?", "START BAIS ANACREDIT INTERFACE FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_CREATION()
                    If Me.BgwAnaCreditDataCheck.IsBusy = False Then
                        Me.LayoutControlItem8.Visibility = LayoutVisibility.Always

                        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'SplashScreenManager.Default.SetWaitFormCaption("Start AnaCredit Data check!")
                        Me.ProgressPanel1.Caption = "Start AnaCredit Data check!"
                        Threading.Thread.Sleep(500)
                        Me.BgwAnaCreditDataCheck.RunWorkerAsync()
                    End If
                End If
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("Please check at least one File for creation", "NO FILE SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub

    Private Sub BgwAnaCreditDataCheck_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAnaCreditDataCheck.DoWork
        Try
            rd = Me.BusinessDate_SearchLookUpEdit.Text
            rdsql = rd.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandTimeout = 500

            Me.BgwAnaCreditDataCheck.ReportProgress(3, "Execute AnaCredit Data Check for: " & rd)

            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BAIS_ANACREDIT_DATA_CHECK')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    Me.BgwAnaCreditDataCheck.ReportProgress(3, "Execute AnaCredit Data Check: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    'SplashScreenManager.Default.SetWaitFormCaption("Execute AnaCredit Data Check: " & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_1"))
                    Threading.Thread.Sleep(500)
                    cmd.ExecuteNonQuery()
                End If
            Next

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub BgwAnaCreditDataCheck_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwAnaCreditDataCheck.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString

        Try
            If cmdEvent.Connection.State = ConnectionState.Closed Then
                cmdEvent.Connection.Open()
            End If
            Dim AnaCreditCheck_Da As New SqlDataAdapter("SELECT * from [AnaCreditCheckResults] order by ID desc", connEvent)
            Dim AnaCreditCheck_Dataset As New DataSet("AnaCreditData_Check")
            AnaCreditCheck_Da.Fill(AnaCreditCheck_Dataset, "AnaCreditCheckResults")
            BS_AnaCreditDataCheck = New BindingSource(AnaCreditCheck_Dataset, "AnaCreditCheckResults")

            Me.GridControl2.DataSource = BS_AnaCreditDataCheck
            Me.GridControl2.Update()

            If cmdEvent.Connection.State = ConnectionState.Open Then
                cmdEvent.Connection.Close()
            End If

        Catch
        End Try
    End Sub

    Private Sub BgwAnaCreditDataCheck_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAnaCreditDataCheck.RunWorkerCompleted
        'SplashScreenManager.CloseForm(False)
        Me.LayoutControlItem8.Visibility = LayoutVisibility.Never

        'Last Fill
        Me.GridControl2.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * from [AnaCreditCheckResults] order by ID desc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.GridControl2.DataSource = Nothing
                    Me.GridControl2.DataSource = objDataTable
                    Me.GridControl2.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try

        Me.QueryText = "Select 'Result'=Case when (Select Count(ID) from AnaCreditCheckResults where CheckResult in ('N'))=0 then 'OK' else 'NO' END"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt.Rows.Item(0).Item("Result").ToString = "OK" Then
            If Me.BgwBaisFilesCreation.IsBusy = False Then
                Me.BgwBaisFilesCreation.RunWorkerAsync()
            End If
        ElseIf dt.Rows.Item(0).Item("Result").ToString = "NO" Then
            If XtraMessageBox.Show("The AnaCredit Customer Data have errors!" & vbNewLine & "Should the BAIS AnaCredit Interface Files be created despite the errors?", "BAIS ANACREDIT INTERFACE FILE CREATION - DATA ERRORS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                If Me.BgwBaisFilesCreation.IsBusy = False Then
                    Me.BgwBaisFilesCreation.RunWorkerAsync()
                End If
            Else
                ENABLE_FINISH_CREATION()
                Return
            End If

        End If
    End Sub


    Private Sub BgwBaisFilesCreation_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBaisFilesCreation.DoWork
        Try
            rd = Me.BusinessDate_SearchLookUpEdit.Text
            rdsql = rd.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandTimeout = 500

            If ACCPIF_CheckEdit.CheckState = CheckState.Checked Then
                ACCPIF_CREATION()
            End If
            If ACFDIF_CheckEdit.CheckState = CheckState.Checked Then
                ACFDIF_CREATION()
            End If
            If ACFAIF_CheckEdit.CheckState = CheckState.Checked Then
                ACFAIF_CREATION()
            End If
            'If ACIPIF_CheckEdit.CheckState = CheckState.Checked Then
            '    ACIPIF_CREATION()
            'End If
            If ACCFIF_CheckEdit.CheckState = CheckState.Checked Then
                ACCFIF_CREATION()
            End If
            'If ACIFIF_CheckEdit.CheckState = CheckState.Checked Then
            '    ACIFIF_CREATION()
            'End If
            'If ACPCIF_CheckEdit.CheckState = CheckState.Checked Then
            '    ACPCIF_CREATION()
            'End If
            If ACPDIF_CheckEdit.CheckState = CheckState.Checked Then
                ACPDIF_CREATION()
            End If
        Catch ex As Exception
            Me.BgwBaisFilesCreation.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub BgwBaisFilesCreation_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBaisFilesCreation.ProgressChanged
        If Me.BaisExportEvents_RichTextBox.Text = Nothing Then
            Me.BaisExportEvents_RichTextBox.Text = e.UserState
        Else
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & e.UserState
        End If
        Me.BaisExportEvents_RichTextBox.SelectionStart = Me.BaisExportEvents_RichTextBox.Text.Length
        Me.BaisExportEvents_RichTextBox.ScrollToCaret()


    End Sub

    Private Sub BgwBaisFilesCreation_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBaisFilesCreation.RunWorkerCompleted
        ENABLE_FINISH_CREATION()
        If Me.ACCPIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACCPIF File created successfully - " & BaisFilesCreationPath & "ACCPIF_CCB.csv"
        ElseIf Me.ACCPIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACCPIF File NOT CREATED+++"
        End If
        If Me.ACFDIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACFDIF File created successfully - " & BaisFilesCreationPath & "ACFDIF_CCB.csv"
        ElseIf Me.ACFDIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACFDIF File NOT CREATED+++"
        End If
        If Me.ACFAIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACFAIF File created successfully - " & BaisFilesCreationPath & "ACFAIF_CCB.csv"
        ElseIf Me.ACFAIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACFAIF File NOT CREATED+++"
        End If
        'If Me.ACIPIF_Result_lbl.Text = "Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACIPIF File created successfully - " & BaisFilesCreationPath & "ACIPIF_CCB.csv"
        'ElseIf Me.ACIPIF_Result_lbl.Text = "Not Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACIPIF File NOT CREATED+++"
        'End If
        If Me.ACCFIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACCFIF File created successfully - " & BaisFilesCreationPath & "ACCFIF_CCB.csv"
        ElseIf Me.ACCFIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACCFIF File NOT CREATED+++"
        End If
        'If Me.ACIFIF_Result_lbl.Text = "Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACIFIF File created successfully - " & BaisFilesCreationPath & "ACIFIF_CCB.csv"
        'ElseIf Me.ACIFIF_Result_lbl.Text = "Not Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACIFIF File NOT CREATED+++"
        'End If
        'If Me.ACPCIF_Result_lbl.Text = "Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACPCIF File created successfully - " & BaisFilesCreationPath & "ACPCIF_CCB.csv"
        'ElseIf Me.ACPCIF_Result_lbl.Text = "Not Created" Then
        '    Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACPCIF File NOT CREATED+++"
        'End If
        If Me.ACPDIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ACPDIF File created successfully - " & BaisFilesCreationPath & "ACPDIF_CCB.csv"
        ElseIf Me.ACPDIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ACPDIF File NOT CREATED+++"
        End If

        ChangeTextcolor("File created with success", Color.DarkCyan, Me.BaisExportEvents_RichTextBox, 0)

        Try
            Using zip As ZipFile = New ZipFile
                For Each File In Directory.GetFiles(BaisFilesCreationPath, "*.CSV", SearchOption.TopDirectoryOnly)
                    zip.AddFile(File, "")
                Next
                zip.Save(BaisFilesCreationPath & "BAIS_Files_ALPHA_AnaCredit_v1.35_from_PSTOOL_" & rdsql & ".rar")
                Dim BaisFilesList As String() = Directory.GetFiles(BaisFilesCreationPath, "*.CSV")
                For Each f In BaisFilesList
                    File.Delete(f)
                Next
            End Using
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "File(s) zipped in " & "BAIS_Files_ALPHA_AnaCredit_v1.35_from_PSTOOL_" & rdsql & ".rar"
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Unable to zip the created BAIS Files", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try

        Me.BaisExportEvents_RichTextBox.SelectionStart = Me.BaisExportEvents_RichTextBox.Text.Length
        Me.BaisExportEvents_RichTextBox.ScrollToCaret()

        For i As Integer = 0 To Me.BaisExportEvents_RichTextBox.Lines.Length - 1

            Dim Text As String = Me.BaisExportEvents_RichTextBox.Lines(i)
            Me.BaisExportEvents_RichTextBox.Select(Me.BaisExportEvents_RichTextBox.GetFirstCharIndexFromLine(i), Text.Length)
            Me.BaisExportEvents_RichTextBox.SelectionColor = ColorForRichTextBoxLine(Text)
            If Text.Contains("created successfully") OrElse Text.Contains("NOT CREATED") OrElse Text.StartsWith("File(s) zipped in BAIS_Files") Then
                BaisExportEvents_RichTextBox.SelectionStart = BaisExportEvents_RichTextBox.GetFirstCharIndexFromLine(i)
                BaisExportEvents_RichTextBox.SelectionLength = Text.Length
                BaisExportEvents_RichTextBox.SelectionFont = New System.Drawing.Font("Consolas", 9, FontStyle.Bold)
            End If


        Next


        Me.BaisExportEvents_RichTextBox.HideSelection = True

        TextImportFileRow = Now & "  " & "PS TOOL BAIS EXPORT" & "  " & Me.BaisExportEvents_RichTextBox.Text & "  " & "PS TOOL BAIS EXPORT"
        System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

    End Sub

    Private Sub ACCPIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        'New Code
        Dim CSV_HEADER As String =
                    "ACCPAF_MDANT" &
                    "|ACCPAF_ARAID" &
                    "|ACCPAF_ACPTP" &
                    "|ACCPAF_ACPID" &
                    "|ACCPAF_MDPTP" &
                    "|ACCPAF_MDPID" &
                    "|ACCPAF_KDREA" &
                    "|ACCPAF_FILNR" &
                    "|ACCPAF_DUBID" &
                    "|ACCPAF_DUBST" &
                    "|ACCPAF_LENID" &
                    "|ACCPAF_LENST" &
                    "|ACCPAF_ANATP" &
                    "|ACCPAF_ANATS" &
                    "|ACCPAF_ANAID" &
                    "|ACCPAF_ANAST" &
                    "|ACCPAF_ARIAD" &
                    "|ACCPAF_RIAST" &
                    "|ACCPAF_ACBLZ" &
                    "|ACCPAF_BLZST" &
                    "|ACCPAF_KGBID" &
                    "|ACCPAF_KGBST" &
                    "|ACCPAF_KNMID" &
                    "|ACCPAF_KNMST" &
                    "|ACCPAF_ISINR" &
                    "|ACCPAF_ISIST" &
                    "|ACCPAF_ACBAK" &
                    "|ACCPAF_BAKST" &
                    "|ACCPAF_ACFVC" &
                    "|ACCPAF_FVCST" &
                    "|ACCPAF_ACIFS" &
                    "|ACCPAF_IFSST" &
                    "|ACCPIF_AVOID" &
                    "|ACCPIF_AVOST" &
                    "|ACCPIF_BLOTC" &
                    "|ACCPIF_BLOST" &
                    "|ACCPIF_BVDCD" &
                    "|ACCPIF_BVDST" &
                    "|ACCPIF_DESTA" &
                    "|ACCPIF_DESST" &
                    "|ACCPIF_DUNID" &
                    "|ACCPIF_DUNST" &
                    "|ACCPIF_EIOID" &
                    "|ACCPIF_EIOST" &
                    "|ACCPIF_ELEID" &
                    "|ACCPIF_ELEST" &
                    "|ACCPAF_HOUTP" &
                    "|ACCPAF_HOTST" &
                    "|ACCPAF_HOUID" &
                    "|ACCPAF_HOUST" &
                    "|ACCPAF_IPUTP" &
                    "|ACCPAF_IPTST" &
                    "|ACCPAF_IPUID" &
                    "|ACCPAF_IPUST" &
                    "|ACCPAF_AUPTP" &
                    "|ACCPAF_AUTST" &
                    "|ACCPAF_AUPID" &
                    "|ACCPAF_AUPST" &
                    "|ACCPAF_KNAME" &
                    "|ACCPAF_KNAST" &
                    "|ACCPAF_STRAS" &
                    "|ACCPAF_STRST" &
                    "|ACCPAF_PLZOR" &
                    "|ACCPAF_PLZST" &
                    "|ACCPAF_KREIS" &
                    "|ACCPAF_KREST" &
                    "|ACCPAF_PLZNR" &
                    "|ACCPAF_PLNST" &
                    "|ACCPAF_LDISO" &
                    "|ACCPAF_LDIST" &
                    "|ACCPAF_ARECH" &
                    "|ACCPAF_RECST" &
                    "|ACCPAF_AINSE" &
                    "|ACCPAF_AINST" &
                    "|ACCPAF_BRNCH" &
                    "|ACCPAF_BRNST" &
                    "|ACCPAF_NACES" &
                    "|ACCPAF_NACST" &
                    "|ACCPAF_ASOLP" &
                    "|ACCPAF_ASOST" &
                    "|ACCPAF_DXOLP" &
                    "|ACCPAF_DXOST" &
                    "|ACCPAF_AENSI" &
                    "|ACCPAF_AENST" &
                    "|ACCPAF_DXNSI" &
                    "|ACCPAF_DXNST" &
                    "|ACCPAF_MITAR" &
                    "|ACCPAF_MITST" &
                    "|ACCPAF_BILSU" &
                    "|ACCPAF_BILST" &
                    "|ACCPAF_UMMIO" &
                    "|ACCPAF_UMMST" &
                    "|ACCPAF_BILAR" &
                    "|ACCPAF_BIAST" &
                    "|ACCPAF_RESE1" &
                    "|ACCPAF_RESE2" &
                    "|ACCPAF_RESE3" &
                    "|ACCPAF_FREI1" &
                    "|ACCPAF_FREI2" &
                    "|ACCPAF_FREI3" &
                    "|ACCPAF_FREI4" &
                    "|ACCPAF_FREI5" &
                    "|ACCPAF_LOEKZ" &
                    "|ACCPAF_IFNAM" &
                    "|ACCPAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACCPIF_MDANT As String = Nothing
        Dim ACCPIF_ARAID As String = Nothing
        Dim ACCPIF_ACPTP As String = Nothing
        Dim ACCPIF_ACPID As String = Nothing
        Dim ACCPIF_MDPTP As String = Nothing
        Dim ACCPIF_MDPID As String = Nothing
        Dim ACCPIF_KDNMD As String = Nothing
        Dim ACCPIF_FILNR As String = Nothing
        Dim ACCPIF_DUBID As String = Nothing
        Dim ACCPIF_DUBST As String = Nothing
        Dim ACCPIF_LENID As String = Nothing
        Dim ACCPIF_LENST As String = Nothing
        Dim ACCPIF_ANATP As String = Nothing
        Dim ACCPIF_ANATS As String = Nothing
        Dim ACCPIF_ANAID As String = Nothing
        Dim ACCPIF_ANAST As String = Nothing
        Dim ACCPIF_ARIAD As String = Nothing
        Dim ACCPIF_RIAST As String = Nothing
        Dim ACCPIF_ACBLZ As String = Nothing
        Dim ACCPIF_BLZST As String = Nothing
        Dim ACCPIF_KGBID As String = Nothing
        Dim ACCPIF_KGBST As String = Nothing
        Dim ACCPIF_KNMID As String = Nothing
        Dim ACCPIF_KNMST As String = Nothing
        Dim ACCPIF_ISINR As String = Nothing
        Dim ACCPIF_ISIST As String = Nothing
        Dim ACCPIF_ACBAK As String = Nothing
        Dim ACCPIF_BAKST As String = Nothing
        Dim ACCPIF_ACFVC As String = Nothing
        Dim ACCPIF_FVCST As String = Nothing
        Dim ACCPIF_ACIFS As String = Nothing
        Dim ACCPIF_IFSST As String = Nothing
        Dim ACCPIF_AVOID As String = Nothing 'New Version 1.27
        Dim ACCPIF_AVOST As String = Nothing 'New Version 1.27
        Dim ACCPIF_BLOTC As String = Nothing 'New Version 1.27
        Dim ACCPIF_BLOST As String = Nothing 'New Version 1.27
        Dim ACCPIF_BVDCD As String = Nothing 'New Version 1.27
        Dim ACCPIF_BVDST As String = Nothing 'New Version 1.27
        Dim ACCPIF_DESTA As String = Nothing 'New Version 1.27
        Dim ACCPIF_DESST As String = Nothing 'New Version 1.27
        Dim ACCPIF_DUNID As String = Nothing 'New Version 1.27
        Dim ACCPIF_DUNST As String = Nothing 'New Version 1.27
        Dim ACCPIF_EIOID As String = Nothing 'New Version 1.27
        Dim ACCPIF_EIOST As String = Nothing 'New Version 1.27
        Dim ACCPIF_ELEID As String = Nothing 'New Version 1.27
        Dim ACCPIF_ELEST As String = Nothing 'New Version 1.27
        Dim ACCPIF_HOUTP As String = Nothing
        Dim ACCPIF_HOTST As String = Nothing
        Dim ACCPIF_HOUID As String = Nothing
        Dim ACCPIF_HOUST As String = Nothing
        Dim ACCPIF_IPUTP As String = Nothing
        Dim ACCPIF_IPTST As String = Nothing
        Dim ACCPIF_IPUID As String = Nothing
        Dim ACCPIF_IPUST As String = Nothing
        Dim ACCPIF_AUPTP As String = Nothing
        Dim ACCPIF_AUTST As String = Nothing
        Dim ACCPIF_AUPID As String = Nothing
        Dim ACCPIF_AUPST As String = Nothing
        Dim ACCPIF_KNAME As String = Nothing
        Dim ACCPIF_KNAST As String = Nothing
        Dim ACCPIF_STRAS As String = Nothing
        Dim ACCPIF_STRST As String = Nothing
        Dim ACCPIF_PLZOR As String = Nothing
        Dim ACCPIF_PLZST As String = Nothing
        Dim ACCPIF_KREIS As String = Nothing
        Dim ACCPIF_KREST As String = Nothing
        Dim ACCPIF_PLZNR As String = Nothing
        Dim ACCPIF_PLNST As String = Nothing
        Dim ACCPIF_LDISO As String = Nothing
        Dim ACCPIF_LDIST As String = Nothing
        Dim ACCPIF_ARECH As String = Nothing
        Dim ACCPIF_RECST As String = Nothing
        Dim ACCPIF_AINSE As String = Nothing
        Dim ACCPIF_AINST As String = Nothing
        Dim ACCPIF_BRNCH As String = Nothing
        Dim ACCPIF_BRNST As String = Nothing 'New
        Dim ACCPIF_NACES As String = Nothing 'New
        Dim ACCPIF_NACST As String = Nothing
        Dim ACCPIF_ASOLP As String = Nothing
        Dim ACCPIF_ASOST As String = Nothing
        Dim ACCPIF_DXOLP As String = Nothing
        Dim ACCPIF_DXOST As String = Nothing
        Dim ACCPIF_AENSI As String = Nothing
        Dim ACCPIF_AENST As String = Nothing
        Dim ACCPIF_DXNSI As String = Nothing
        Dim ACCPIF_DXNST As String = Nothing
        Dim ACCPIF_MITAR As String = Nothing
        Dim ACCPIF_MITST As String = Nothing
        Dim ACCPIF_BILSU As String = Nothing
        Dim ACCPIF_BILST As String = Nothing
        Dim ACCPIF_UMMIO As String = Nothing
        Dim ACCPIF_UMMST As String = Nothing
        Dim ACCPIF_BILAR As String = Nothing
        Dim ACCPIF_BIAST As String = Nothing
        Dim ACCPIF_RESE1 As String = Nothing
        Dim ACCPIF_RESE2 As String = Nothing
        Dim ACCPIF_RESE3 As String = Nothing
        Dim ACCPIF_FREI1 As String = Nothing
        Dim ACCPIF_FREI2 As String = Nothing
        Dim ACCPIF_FREI3 As String = Nothing
        Dim ACCPIF_FREI4 As String = Nothing
        Dim ACCPIF_FREI5 As String = Nothing
        Dim ACCPIF_LOEKZ As String = Nothing
        Dim ACCPIF_IFNAM As String = Nothing
        Dim ACCPIF_DXIFD As String = Nothing

        Dim CountAnaCreditCustomers As Double = 0

        'Check if Anacredit Clients are present
        cmd.CommandText = "Select Count([ID]) from [CUSTOMER_INFO] where [AnaCredit_Customer] in ('Y')"
        CountAnaCreditCustomers = cmd.ExecuteScalar
        If CountAnaCreditCustomers > 0 Then

            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACCPAF_CCB.csv")
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACCPIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACCPIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACCPAF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "ACCPAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "ACCPAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "ACCPAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_ACCPIF] where [ACCPIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in DVTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("DVTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("DVTIFF_KDNRH"))
                    ACCPIF_MDANT = dt.Rows.Item(i).Item("ACCPIF_MDANT") & "|"
                    ACCPIF_ARAID = dt.Rows.Item(i).Item("ACCPIF_ARAID") & "|"
                    ACCPIF_ACPTP = dt.Rows.Item(i).Item("ACCPIF_ACPTP") & "|"
                    ACCPIF_ACPID = dt.Rows.Item(i).Item("ACCPIF_ACPID") & "|"
                    ACCPIF_MDPTP = dt.Rows.Item(i).Item("ACCPIF_MDPTP") & "|" 'New
                    ACCPIF_MDPID = dt.Rows.Item(i).Item("ACCPIF_MDPID") & "|" 'New
                    ACCPIF_KDNMD = dt.Rows.Item(i).Item("ACCPIF_KDNMD") & "|"
                    ACCPIF_FILNR = dt.Rows.Item(i).Item("ACCPIF_FILNR") & "|"
                    ACCPIF_DUBID = dt.Rows.Item(i).Item("ACCPIF_DUBID") & "|"
                    ACCPIF_DUBST = dt.Rows.Item(i).Item("ACCPIF_DUBST") & "|"
                    ACCPIF_LENID = dt.Rows.Item(i).Item("ACCPIF_LENID") & "|"
                    ACCPIF_LENST = dt.Rows.Item(i).Item("ACCPIF_LENST") & "|"
                    ACCPIF_ANATP = dt.Rows.Item(i).Item("ACCPIF_ANATP") & "|"
                    ACCPIF_ANATS = dt.Rows.Item(i).Item("ACCPIF_ANATS") & "|"
                    ACCPIF_ANAID = dt.Rows.Item(i).Item("ACCPIF_ANAID") & "|"
                    ACCPIF_ANAST = dt.Rows.Item(i).Item("ACCPIF_ANAST") & "|"
                    ACCPIF_ARIAD = dt.Rows.Item(i).Item("ACCPIF_ARIAD") & "|"
                    ACCPIF_RIAST = dt.Rows.Item(i).Item("ACCPIF_RIAST") & "|"
                    ACCPIF_ACBLZ = dt.Rows.Item(i).Item("ACCPIF_ACBLZ") & "|"
                    ACCPIF_BLZST = dt.Rows.Item(i).Item("ACCPIF_BLZST") & "|"
                    ACCPIF_KGBID = dt.Rows.Item(i).Item("ACCPIF_KGBID") & "|"
                    ACCPIF_KGBST = dt.Rows.Item(i).Item("ACCPIF_KGBST") & "|"
                    ACCPIF_KNMID = dt.Rows.Item(i).Item("ACCPIF_KNMID") & "|"
                    ACCPIF_KNMST = dt.Rows.Item(i).Item("ACCPIF_KNMST") & "|"
                    ACCPIF_ISINR = dt.Rows.Item(i).Item("ACCPIF_ISINR") & "|"
                    ACCPIF_ISIST = dt.Rows.Item(i).Item("ACCPIF_ISIST") & "|"
                    ACCPIF_ACBAK = dt.Rows.Item(i).Item("ACCPIF_ACBAK") & "|"
                    ACCPIF_BAKST = dt.Rows.Item(i).Item("ACCPIF_BAKST") & "|"
                    ACCPIF_ACFVC = dt.Rows.Item(i).Item("ACCPIF_ACFVC") & "|"
                    ACCPIF_FVCST = dt.Rows.Item(i).Item("ACCPIF_FVCST") & "|"
                    ACCPIF_ACIFS = dt.Rows.Item(i).Item("ACCPIF_ACIFS") & "|"
                    ACCPIF_IFSST = dt.Rows.Item(i).Item("ACCPIF_IFSST") & "|"
                    ACCPIF_AVOID = dt.Rows.Item(i).Item("ACCPIF_AVOID") & "|"
                    ACCPIF_AVOST = dt.Rows.Item(i).Item("ACCPIF_AVOST") & "|"
                    ACCPIF_BLOTC = dt.Rows.Item(i).Item("ACCPIF_BLOTC") & "|"
                    ACCPIF_BLOST = dt.Rows.Item(i).Item("ACCPIF_BLOST") & "|"
                    ACCPIF_BVDCD = dt.Rows.Item(i).Item("ACCPIF_BVDCD") & "|"
                    ACCPIF_BVDST = dt.Rows.Item(i).Item("ACCPIF_BVDST") & "|"
                    ACCPIF_DESTA = dt.Rows.Item(i).Item("ACCPIF_DESTA") & "|"
                    ACCPIF_DESST = dt.Rows.Item(i).Item("ACCPIF_DESST") & "|"
                    ACCPIF_DUNID = dt.Rows.Item(i).Item("ACCPIF_DUNID") & "|"
                    ACCPIF_DUNST = dt.Rows.Item(i).Item("ACCPIF_DUNST") & "|"
                    ACCPIF_EIOID = dt.Rows.Item(i).Item("ACCPIF_EIOID") & "|"
                    ACCPIF_EIOST = dt.Rows.Item(i).Item("ACCPIF_EIOST") & "|"
                    ACCPIF_ELEID = dt.Rows.Item(i).Item("ACCPIF_ELEID") & "|"
                    ACCPIF_ELEST = dt.Rows.Item(i).Item("ACCPIF_ELEST") & "|"
                    ACCPIF_HOUTP = dt.Rows.Item(i).Item("ACCPIF_HOUTP") & "|"
                    ACCPIF_HOTST = dt.Rows.Item(i).Item("ACCPIF_HOTST") & "|"
                    ACCPIF_HOUID = dt.Rows.Item(i).Item("ACCPIF_HOUID") & "|"
                    ACCPIF_HOUST = dt.Rows.Item(i).Item("ACCPIF_HOUST") & "|"
                    ACCPIF_IPUTP = dt.Rows.Item(i).Item("ACCPIF_IPUTP") & "|"
                    ACCPIF_IPTST = dt.Rows.Item(i).Item("ACCPIF_IPTST") & "|"
                    ACCPIF_IPUID = dt.Rows.Item(i).Item("ACCPIF_IPUID") & "|"
                    ACCPIF_IPUST = dt.Rows.Item(i).Item("ACCPIF_IPUST") & "|"
                    ACCPIF_AUPTP = dt.Rows.Item(i).Item("ACCPIF_AUPTP") & "|"
                    ACCPIF_AUTST = dt.Rows.Item(i).Item("ACCPIF_AUTST") & "|"
                    ACCPIF_AUPID = dt.Rows.Item(i).Item("ACCPIF_AUPID") & "|"
                    ACCPIF_AUPST = dt.Rows.Item(i).Item("ACCPIF_AUPST") & "|"
                    ACCPIF_KNAME = dt.Rows.Item(i).Item("ACCPIF_KNAME") & "|"
                    ACCPIF_KNAST = dt.Rows.Item(i).Item("ACCPIF_KNAST") & "|"
                    ACCPIF_STRAS = dt.Rows.Item(i).Item("ACCPIF_STRAS") & "|"
                    ACCPIF_STRST = dt.Rows.Item(i).Item("ACCPIF_STRST") & "|"
                    ACCPIF_PLZOR = dt.Rows.Item(i).Item("ACCPIF_PLZOR") & "|"
                    ACCPIF_PLZST = dt.Rows.Item(i).Item("ACCPIF_PLZST") & "|"
                    ACCPIF_KREIS = dt.Rows.Item(i).Item("ACCPIF_KREIS") & "|"
                    ACCPIF_KREST = dt.Rows.Item(i).Item("ACCPIF_KREST") & "|"
                    ACCPIF_PLZNR = dt.Rows.Item(i).Item("ACCPIF_PLZNR") & "|"
                    ACCPIF_PLNST = dt.Rows.Item(i).Item("ACCPIF_PLNST") & "|"
                    ACCPIF_LDISO = dt.Rows.Item(i).Item("ACCPIF_LDISO") & "|"
                    ACCPIF_LDIST = dt.Rows.Item(i).Item("ACCPIF_LDIST") & "|"
                    ACCPIF_ARECH = dt.Rows.Item(i).Item("ACCPIF_ARECH") & "|"
                    ACCPIF_RECST = dt.Rows.Item(i).Item("ACCPIF_RECST") & "|"
                    ACCPIF_AINSE = dt.Rows.Item(i).Item("ACCPIF_AINSE") & "|"
                    ACCPIF_AINST = dt.Rows.Item(i).Item("ACCPIF_AINST") & "|"
                    ACCPIF_BRNCH = dt.Rows.Item(i).Item("ACCPIF_BRNCH") & "|"
                    ACCPIF_BRNST = dt.Rows.Item(i).Item("ACCPIF_BRNST") & "|"
                    ACCPIF_NACES = dt.Rows.Item(i).Item("ACCPIF_NACES") & "|"
                    ACCPIF_NACST = dt.Rows.Item(i).Item("ACCPIF_NACST") & "|"
                    ACCPIF_ASOLP = dt.Rows.Item(i).Item("ACCPIF_ASOLP") & "|"
                    ACCPIF_ASOST = dt.Rows.Item(i).Item("ACCPIF_ASOST") & "|"
                    ACCPIF_DXOLP = dt.Rows.Item(i).Item("ACCPIF_DXOLP") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACCPIF_DXOLP")) = False Then
                        Dim DXOLP_Date As Date = dt.Rows.Item(i).Item("ACCPIF_DXOLP")
                        ACCPIF_DXOLP = DXOLP_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACCPIF_DXOLP = "0" & "|"
                    End If
                    ACCPIF_DXOST = dt.Rows.Item(i).Item("ACCPIF_DXOST") & "|"
                    ACCPIF_AENSI = dt.Rows.Item(i).Item("ACCPIF_AENSI") & "|"
                    ACCPIF_AENST = dt.Rows.Item(i).Item("ACCPIF_AENST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACCPIF_DXNSI")) = False Then
                        Dim DXNSI_Date As Date = dt.Rows.Item(i).Item("ACCPIF_DXNSI")
                        ACCPIF_DXNSI = DXNSI_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACCPIF_DXNSI = "0" & "|"
                    End If
                    ACCPIF_DXNST = dt.Rows.Item(i).Item("ACCPIF_DXNST") & "|"
                    ACCPIF_MITAR = dt.Rows.Item(i).Item("ACCPIF_MITAR") & "|"
                    ACCPIF_MITST = dt.Rows.Item(i).Item("ACCPIF_MITST") & "|"
                    ACCPIF_BILSU = dt.Rows.Item(i).Item("ACCPIF_BILSU").ToString.Replace(",", ".") & "|"
                    ACCPIF_BILST = dt.Rows.Item(i).Item("ACCPIF_BILST") & "|"
                    ACCPIF_UMMIO = dt.Rows.Item(i).Item("ACCPIF_UMMIO").ToString.Replace(",", ".") & "|"
                    ACCPIF_UMMST = dt.Rows.Item(i).Item("ACCPIF_UMMST") & "|"
                    ACCPIF_BILAR = dt.Rows.Item(i).Item("ACCPIF_BILAR") & "|"
                    ACCPIF_BIAST = dt.Rows.Item(i).Item("ACCPIF_BIAST") & "|"
                    ACCPIF_RESE1 = dt.Rows.Item(i).Item("ACCPIF_RESE1") & "|"
                    ACCPIF_RESE2 = dt.Rows.Item(i).Item("ACCPIF_RESE2") & "|"
                    ACCPIF_RESE3 = dt.Rows.Item(i).Item("ACCPIF_RESE3") & "|"
                    ACCPIF_FREI1 = dt.Rows.Item(i).Item("ACCPIF_FREI1") & "|"
                    ACCPIF_FREI2 = dt.Rows.Item(i).Item("ACCPIF_FREI2") & "|"
                    ACCPIF_FREI3 = dt.Rows.Item(i).Item("ACCPIF_FREI3") & "|"
                    ACCPIF_FREI4 = dt.Rows.Item(i).Item("ACCPIF_FREI4") & "|"
                    ACCPIF_FREI5 = dt.Rows.Item(i).Item("ACCPIF_FREI5") & "|"
                    ACCPIF_LOEKZ = dt.Rows.Item(i).Item("ACCPIF_LOEKZ") & "|"
                    ACCPIF_IFNAM = dt.Rows.Item(i).Item("ACCPIF_IFNAM") & "|"
                    ACCPIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACCPIF_DXIFD"))



                    CSV_ROW =
                        ACCPIF_MDANT &
                        ACCPIF_ARAID &
                        ACCPIF_ACPTP &
                        ACCPIF_ACPID &
                        ACCPIF_MDPTP &
                        ACCPIF_MDPID &
                        ACCPIF_KDNMD &
                        ACCPIF_FILNR &
                        ACCPIF_DUBID &
                        ACCPIF_DUBST &
                        ACCPIF_LENID &
                        ACCPIF_LENST &
                        ACCPIF_ANATP &
                        ACCPIF_ANATS &
                        ACCPIF_ANAID &
                        ACCPIF_ANAST &
                        ACCPIF_ARIAD &
                        ACCPIF_RIAST &
                        ACCPIF_ACBLZ &
                        ACCPIF_BLZST &
                        ACCPIF_KGBID &
                        ACCPIF_KGBST &
                        ACCPIF_KNMID &
                        ACCPIF_KNMST &
                        ACCPIF_ISINR &
                        ACCPIF_ISIST &
                        ACCPIF_ACBAK &
                        ACCPIF_BAKST &
                        ACCPIF_ACFVC &
                        ACCPIF_FVCST &
                        ACCPIF_ACIFS &
                        ACCPIF_IFSST &
                        ACCPIF_AVOID &
                        ACCPIF_AVOST &
                        ACCPIF_BLOTC &
                        ACCPIF_BLOST &
                        ACCPIF_BVDCD &
                        ACCPIF_BVDST &
                        ACCPIF_DESTA &
                        ACCPIF_DESST &
                        ACCPIF_DUNID &
                        ACCPIF_DUNST &
                        ACCPIF_EIOID &
                        ACCPIF_EIOST &
                        ACCPIF_ELEID &
                        ACCPIF_ELEST &
                        ACCPIF_HOUTP &
                        ACCPIF_HOTST &
                        ACCPIF_HOUID &
                        ACCPIF_HOUST &
                        ACCPIF_IPUTP &
                        ACCPIF_IPTST &
                        ACCPIF_IPUID &
                        ACCPIF_IPUST &
                        ACCPIF_AUPTP &
                        ACCPIF_AUTST &
                        ACCPIF_AUPID &
                        ACCPIF_AUPST &
                        ACCPIF_KNAME &
                        ACCPIF_KNAST &
                        ACCPIF_STRAS &
                        ACCPIF_STRST &
                        ACCPIF_PLZOR &
                        ACCPIF_PLZST &
                        ACCPIF_KREIS &
                        ACCPIF_KREST &
                        ACCPIF_PLZNR &
                        ACCPIF_PLNST &
                        ACCPIF_LDISO &
                        ACCPIF_LDIST &
                        ACCPIF_ARECH &
                        ACCPIF_RECST &
                        ACCPIF_AINSE &
                        ACCPIF_AINST &
                        ACCPIF_BRNCH &
                        ACCPIF_BRNST &
                        ACCPIF_NACES &
                        ACCPIF_NACST &
                        ACCPIF_ASOLP &
                        ACCPIF_ASOST &
                        ACCPIF_DXOLP &
                        ACCPIF_DXOST &
                        ACCPIF_AENSI &
                        ACCPIF_AENST &
                        ACCPIF_DXNSI &
                        ACCPIF_DXNST &
                        ACCPIF_MITAR &
                        ACCPIF_MITST &
                        ACCPIF_BILSU &
                        ACCPIF_BILST &
                        ACCPIF_UMMIO &
                        ACCPIF_UMMST &
                        ACCPIF_BILAR &
                        ACCPIF_BIAST &
                        ACCPIF_RESE1 &
                        ACCPIF_RESE2 &
                        ACCPIF_RESE3 &
                        ACCPIF_FREI1 &
                        ACCPIF_FREI2 &
                        ACCPIF_FREI3 &
                        ACCPIF_FREI4 &
                        ACCPIF_FREI5 &
                        ACCPIF_LOEKZ &
                        ACCPIF_IFNAM &
                        ACCPIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACCPAF_CCB.csv", CSV_ROW & vbCrLf)
                Next


                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ACCPIF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ACCPIF_Result = "Not Created"
            End Try

        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.ACCPIF_Result = "Not Created"
            'Dim CSV_HEADER As String = "ACCPAF_MDANT|ACCPAF_ARAID|ACCPAF_ACPTP|ACCPAF_ACPID|ACCPAF_MDPTP|ACCPAF_MDPID|ACCPAF_KDREA|ACCPAF_FILNR|ACCPAF_DUBID|ACCPAF_DUBST|ACCPAF_LENID|ACCPAF_LENST|ACCPAF_ANATP|ACCPAF_ANATS|ACCPAF_ANAID|ACCPAF_ANAST|ACCPIF_DETAX|ACCPIF_DETST|ACCPIF_DEVAT|ACCPIF_DEVST|ACCPAF_ARIAD|ACCPAF_RIAST|ACCPAF_ACBLZ|ACCPAF_BLZST|ACCPAF_KGBID|ACCPAF_KGBST|ACCPAF_KNMID|ACCPAF_KNMST|ACCPAF_ISINR|ACCPAF_ISIST|ACCPAF_BKBIC|ACCPAF_BICST|ACCPAF_ACBAK|ACCPAF_BAKST|ACCPAF_ACFVC|ACCPAF_FVCST|ACCPAF_ACIFS|ACCPAF_IFSST|ACCPIF_AVOID|ACCPIF_AVOST|ACCPIF_BLOTC|ACCPIF_BLOST|ACCPIF_BVDCD|ACCPIF_BVDST|ACCPIF_DESTA|ACCPIF_DESST|ACCPIF_DUNID|ACCPIF_DUNST|ACCPIF_EIOID|ACCPIF_EIOST|ACCPIF_ELEID|ACCPIF_ELEST|ACCPAF_HOUTP|ACCPAF_HOTST|ACCPAF_HOUID|ACCPAF_HOUST|ACCPAF_IPUTP|ACCPAF_IPTST|ACCPAF_IPUID|ACCPAF_IPUST|ACCPAF_AUPTP|ACCPAF_AUTST|ACCPAF_AUPID|ACCPAF_AUPST|ACCPAF_KNAME|ACCPAF_KNAST|ACCPAF_STRAS|ACCPAF_STRST|ACCPAF_PLZOR|ACCPAF_PLZST|ACCPAF_KREIS|ACCPAF_KREST|ACCPAF_PLZNR|ACCPAF_PLNST|ACCPAF_LDISO|ACCPAF_LDIST|ACCPAF_ARECH|ACCPAF_RECST|ACCPAF_AINSE|ACCPAF_AINST|ACCPAF_BRNCH|ACCPAF_BRNST|ACCPAF_NACES|ACCPAF_NACST|ACCPAF_ASOLP|ACCPAF_ASOST|ACCPAF_DXOLP|ACCPAF_DXOST|ACCPAF_AENSI|ACCPAF_AENST|ACCPAF_DXNSI|ACCPAF_DXNST|ACCPAF_MITAR|ACCPAF_MITST|ACCPAF_BILSU|ACCPAF_BILST|ACCPAF_UMMIO|ACCPAF_UMMST|ACCPAF_BILAR|ACCPAF_BIAST|ACCPAF_RESE1|ACCPAF_RESE2|ACCPAF_RESE3|ACCPAF_FREI1|ACCPAF_FREI2|ACCPAF_FREI3|ACCPAF_FREI4|ACCPAF_FREI5|ACCPAF_LOEKZ|ACCPAF_IFNAM|ACCPAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "ACCPAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "ACCPAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "ACCPAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File ACCPAF_CCB.csv for " & rd & vbNewLine & "There are no more AnaCredit Clients in the Database", "NO ANACREDIT CLIENTS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ACFDIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        Dim CSV_HEADER As String =
                "ACFDAF_MDANT" &
                "|ACFDAF_ARAID" &
                "|ACFDAF_AOAID" &
                "|ACFDAF_ACTID" &
                "|ACFDAF_AINID" &
                "|ACFDAF_MODUL" &
                "|ACFDAF_KDREA" &
                "|ACFDAF_KTONR" &
                "|ACFDAF_GSREF" &
                "|ACFDAF_WPKNR" &
                "|ACFDAF_DEPNR" &
                "|ACFDAF_HAWHG" &
                "|ACFDAF_FILNR" &
                "|ACFDAF_KZICL" &
                "|ACFDAF_ATYOI" &
                "|ACFDAF_ATYST" &
                "|ACFDAF_AAMTY" &
                "|ACFDAF_AAMST" &
                "|ACFDAF_WHISO" &
                "|ACFDAF_WHIST" &
                "|ACFDAF_AFIIN" &
                "|ACFDAF_AFIST" &
                "|ACFDAF_DXVBE" &
                "|ACFDAF_DXVST" &
                "|ACFDAF_DXIOP" &
                "|ACFDAF_DXIST" &
                "|ACFDAF_AINRC" &
                "|ACFDAF_AINST" &
                "|ACFDAF_AINRF" &
                "|ACFDAF_AIRST" &
                "|ACFDAF_AIRRF" &
                "|ACFDAF_ARRST" &
                "|ACFDAF_AIRSM" &
                "|ACFDAF_AIMST" &
                "|ACFDAF_AINRT" &
                "|ACFDAF_AISST" &
                "|ACFDAF_DXMAT" &
                "|ACFDAF_DXMST" &
                "|ACFDAF_ATCAI" &
                "|ACFDAF_ATCST" &
                "|ACFDAF_APAFR" &
                "|ACFDAF_APAST" &
                "|ACFDAF_APRLL" &
                "|ACFDAF_APRST" &
                "|ACFDAF_APURP" &
                "|ACFDAF_APUST" &
                "|ACFDAF_ARECC" &
                "|ACFDAF_AREST" &
                "|ACFDAF_AZIRE" &
                "|ACFDAF_AZIST" &
                "|ACFDAF_DXSET" &
                "|ACFDAF_DXSST" &
                "|ACFDAF_ASUDE" &
                "|ACFDAF_ASUST" &
                "|ACFDAF_SCOID" &
                "|ACFDAF_SCOST" &
                "|ACFDAF_ARERI" &
                "|ACFDAF_ARIST" &
                "|ACFDAF_ABFVC" &
                "|ACFDAF_ABFST" &
                "|ACFDAF_AINRA" &
                "|ACFDAF_ANRST" &
                "|ACFDAF_DXNIR" &
                "|ACFDAF_DXNST" &
                "|ACFDAF_ADFST" &
                "|ACFDAF_AFSST" &
                "|ACFDAF_DXFST" &
                "|ACFDAF_DFSST" &
                "|ACFDAF_ATRAM" &
                "|ACFDAF_ATRST" &
                "|ACFDAF_AARIN" &
                "|ACFDAF_AARST" &
                "|ACFDAF_DXPDI" &
                "|ACFDAF_DXPST" &
                "|ACFDAF_ATYOS" &
                "|ACFDAF_ATOST" &
                "|ACFDAF_AOUNA" &
                "|ACFDAF_AOUST" &
                "|ACFDAF_AACIN" &
                "|ACFDAF_AACST" &
                "|ACFDAF_AOBSA" &
                "|ACFDAF_AOBST" &
                "|ACFDAF_RESE1" &
                "|ACFDAF_RESE2" &
                "|ACFDAF_RESE3" &
                "|ACFDAF_FREI1" &
                "|ACFDAF_FREI2" &
                "|ACFDAF_FREI3" &
                "|ACFDAF_FREI4" &
                "|ACFDAF_FREI5" &
                "|ACFDAF_LOEKZ" &
                "|ACFDAF_IFNAM" &
                "|ACFDAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACFDIF_MDANT As String = Nothing
        Dim ACFDIF_ARAID As String = Nothing
        Dim ACFDIF_AOAID As String = Nothing
        Dim ACFDIF_ACTID As String = Nothing
        Dim ACFDIF_AINID As String = Nothing
        Dim ACFDIF_MODUL As String = Nothing
        Dim ACFDIF_KDNRH As String = Nothing
        Dim ACFDIF_KTONR As String = Nothing
        Dim ACFDIF_GSREF As String = Nothing
        Dim ACFDIF_WPKNR As String = Nothing
        Dim ACFDIF_DEPNR As String = Nothing
        Dim ACFDIF_HAWHG As String = Nothing
        Dim ACFDIF_FILNR As String = Nothing
        Dim ACFDIF_KZICL As String = Nothing
        Dim ACFDIF_ATYOI As String = Nothing
        Dim ACFDIF_ATYST As String = Nothing
        Dim ACFDIF_AAMTY As String = Nothing
        Dim ACFDIF_AAMST As String = Nothing
        Dim ACFDIF_WHISO As String = Nothing
        Dim ACFDIF_WHIST As String = Nothing
        Dim ACFDIF_AFIIN As String = Nothing
        Dim ACFDIF_AFIST As String = Nothing
        Dim ACFDIF_DXVBE As String = Nothing
        Dim ACFDIF_DXVST As String = Nothing
        Dim ACFDIF_DXIOP As String = Nothing
        Dim ACFDIF_DXIST As String = Nothing
        Dim ACFDIF_AINRC As String = Nothing
        Dim ACFDIF_AINST As String = Nothing
        Dim ACFDIF_AINRF As String = Nothing
        Dim ACFDIF_AIRST As String = Nothing
        Dim ACFDIF_AIRRF As String = Nothing
        Dim ACFDIF_ARRST As String = Nothing
        Dim ACFDIF_AIRSM As String = Nothing
        Dim ACFDIF_AIMST As String = Nothing
        Dim ACFDIF_AINRT As String = Nothing
        Dim ACFDIF_AISST As String = Nothing
        Dim ACFDIF_DXMAT As String = Nothing
        Dim ACFDIF_DXMST As String = Nothing
        Dim ACFDIF_ATCAI As String = Nothing
        Dim ACFDIF_ATCST As String = Nothing
        Dim ACFDIF_APAFR As String = Nothing
        Dim ACFDIF_APAST As String = Nothing
        Dim ACFDIF_APRLL As String = Nothing
        Dim ACFDIF_APRST As String = Nothing
        Dim ACFDIF_APURP As String = Nothing
        Dim ACFDIF_APUST As String = Nothing
        Dim ACFDIF_ARECC As String = Nothing
        Dim ACFDIF_AREST As String = Nothing
        Dim ACFDIF_AZIRE As String = Nothing
        Dim ACFDIF_AZIST As String = Nothing
        Dim ACFDIF_DXSET As String = Nothing
        Dim ACFDIF_DXSST As String = Nothing
        Dim ACFDIF_ASUDE As String = Nothing
        Dim ACFDIF_ASUST As String = Nothing
        Dim ACFDIF_SCOID As String = Nothing
        Dim ACFDIF_SCOST As String = Nothing
        Dim ACFDIF_ARERI As String = Nothing
        Dim ACFDIF_ARIST As String = Nothing
        Dim ACFDIF_ABFVC As String = Nothing
        Dim ACFDIF_ABFST As String = Nothing
        Dim ACFDIF_AINRA As String = Nothing
        Dim ACFDIF_ANRST As String = Nothing
        Dim ACFDIF_DXNIR As String = Nothing
        Dim ACFDIF_DXNST As String = Nothing
        Dim ACFDIF_ADFST As String = Nothing
        Dim ACFDIF_AFSST As String = Nothing
        Dim ACFDIF_DXFST As String = Nothing
        Dim ACFDIF_DFSST As String = Nothing
        Dim ACFDIF_ATRAM As String = Nothing
        Dim ACFDIF_ATRST As String = Nothing
        Dim ACFDIF_AARIN As String = Nothing
        Dim ACFDIF_AARST As String = Nothing
        Dim ACFDIF_DXPDI As String = Nothing
        Dim ACFDIF_DXPST As String = Nothing
        Dim ACFDIF_ATYOS As String = Nothing
        Dim ACFDIF_ATOST As String = Nothing
        Dim ACFDIF_AOUNA As String = Nothing
        Dim ACFDIF_AOUST As String = Nothing
        Dim ACFDIF_AACIN As String = Nothing
        Dim ACFDIF_AACST As String = Nothing
        Dim ACFDIF_AOBSA As String = Nothing
        Dim ACFDIF_AOBST As String = Nothing
        Dim ACFDIF_RESE1 As String = Nothing
        Dim ACFDIF_RESE2 As String = Nothing
        Dim ACFDIF_RESE3 As String = Nothing
        Dim ACFDIF_FREI1 As String = Nothing
        Dim ACFDIF_FREI2 As String = Nothing
        Dim ACFDIF_FREI3 As String = Nothing
        Dim ACFDIF_FREI4 As String = Nothing
        Dim ACFDIF_FREI5 As String = Nothing
        Dim ACFDIF_LOEKZ As String = Nothing
        Dim ACFDIF_IFNAM As String = Nothing
        Dim ACFDIF_DXIFD As String = Nothing


        Try
            'BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACFDIF_CCB.csv")
            'cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='100',[GSTIFF_BILKT]='100',[ReferenceClear]=NULL where [GSTIFF_DXIFD]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()

            BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACFDAF_CCB.csv")
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACFDIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACFDIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If



            If File.Exists(BaisFilesCreationPath & "ACFDAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "ACFDAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "ACFDAF_CCB.csv", CSV_HEADER & vbCrLf)
            '++++++++++++++
            cmd.CommandText = "Select Count([ID]) from [BAIS_ACFDIF] where [ACFDIF_DXIFD]='" & rdsql & "'"
            Dim Count As Double = cmd.ExecuteScalar
            If Count > 0 Then

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACFDAF_CCB.csv...Please wait...")


                Me.QueryText = "SELECT * FROM  [BAIS_ACFDIF] where [ACFDIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in GSTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("GSTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("GSTIFF_KDNRH"))
                    ACFDIF_MDANT = dt.Rows.Item(i).Item("ACFDIF_MDANT") & "|"
                    ACFDIF_ARAID = dt.Rows.Item(i).Item("ACFDIF_ARAID") & "|"
                    ACFDIF_AOAID = dt.Rows.Item(i).Item("ACFDIF_AOAID") & "|"
                    ACFDIF_ACTID = dt.Rows.Item(i).Item("ACFDIF_ACTID") & "|"
                    ACFDIF_AINID = dt.Rows.Item(i).Item("ACFDIF_AINID") & "|"
                    ACFDIF_MODUL = dt.Rows.Item(i).Item("ACFDIF_MODUL") & "|"
                    ACFDIF_KDNRH = dt.Rows.Item(i).Item("ACFDIF_KDNRH") & "|"
                    ACFDIF_KTONR = dt.Rows.Item(i).Item("ACFDIF_KTONR") & "|"
                    ACFDIF_GSREF = dt.Rows.Item(i).Item("ACFDIF_GSREF") & "|"
                    ACFDIF_WPKNR = dt.Rows.Item(i).Item("ACFDIF_WPKNR") & "|"
                    ACFDIF_DEPNR = dt.Rows.Item(i).Item("ACFDIF_DEPNR") & "|"
                    ACFDIF_HAWHG = dt.Rows.Item(i).Item("ACFDIF_HAWHG") & "|"
                    ACFDIF_FILNR = dt.Rows.Item(i).Item("ACFDIF_FILNR") & "|"
                    ACFDIF_KZICL = dt.Rows.Item(i).Item("ACFDIF_KZICL") & "|"
                    ACFDIF_ATYOI = dt.Rows.Item(i).Item("ACFDIF_ATYOI") & "|"
                    ACFDIF_ATYST = dt.Rows.Item(i).Item("ACFDIF_ATYST") & "|"
                    ACFDIF_AAMTY = dt.Rows.Item(i).Item("ACFDIF_AAMTY") & "|"
                    ACFDIF_AAMST = dt.Rows.Item(i).Item("ACFDIF_AAMST") & "|"
                    ACFDIF_WHISO = dt.Rows.Item(i).Item("ACFDIF_WHISO") & "|"
                    ACFDIF_WHIST = dt.Rows.Item(i).Item("ACFDIF_WHIST") & "|"
                    ACFDIF_AFIIN = dt.Rows.Item(i).Item("ACFDIF_AFIIN") & "|"
                    ACFDIF_AFIST = dt.Rows.Item(i).Item("ACFDIF_AFIST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXVBE")) = False Then
                        Dim ACFDIF_DXVBE_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXVBE")
                        ACFDIF_DXVBE = ACFDIF_DXVBE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXVBE = "0" & "|"
                    End If
                    ACFDIF_DXVST = dt.Rows.Item(i).Item("ACFDIF_DXVST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXIOP")) = False Then
                        Dim ACFDIF_DXIOP_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXIOP")
                        ACFDIF_DXIOP = ACFDIF_DXIOP_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXIOP = "0" & "|"
                    End If
                    ACFDIF_DXIST = dt.Rows.Item(i).Item("ACFDIF_DXIST") & "|"
                    ACFDIF_AINRC = dt.Rows.Item(i).Item("ACFDIF_AINRC").ToString.Replace(",", ".") & "|"
                    ACFDIF_AINST = dt.Rows.Item(i).Item("ACFDIF_AINST") & "|"
                    ACFDIF_AINRF = dt.Rows.Item(i).Item("ACFDIF_AINRF").ToString.Replace(",", ".") & "|"
                    ACFDIF_AIRST = dt.Rows.Item(i).Item("ACFDIF_AIRST") & "|"
                    ACFDIF_AIRRF = dt.Rows.Item(i).Item("ACFDIF_AIRRF") & "|"
                    ACFDIF_ARRST = dt.Rows.Item(i).Item("ACFDIF_ARRST") & "|"
                    ACFDIF_AIRSM = dt.Rows.Item(i).Item("ACFDIF_AIRSM").ToString.Replace(",", ".") & "|"
                    ACFDIF_AIMST = dt.Rows.Item(i).Item("ACFDIF_AIMST") & "|"
                    ACFDIF_AINRT = dt.Rows.Item(i).Item("ACFDIF_AINRT") & "|"
                    ACFDIF_AISST = dt.Rows.Item(i).Item("ACFDIF_AISST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXMAT")) = False Then
                        Dim ACFDIF_DXMAT_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXMAT")
                        ACFDIF_DXMAT = ACFDIF_DXMAT_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXMAT = "0" & "|"
                    End If
                    ACFDIF_DXMST = dt.Rows.Item(i).Item("ACFDIF_DXMST") & "|"
                    ACFDIF_ATCAI = dt.Rows.Item(i).Item("ACFDIF_ATCAI").ToString.Replace(",", ".") & "|"
                    ACFDIF_ATCST = dt.Rows.Item(i).Item("ACFDIF_ATCST") & "|"
                    ACFDIF_APAFR = dt.Rows.Item(i).Item("ACFDIF_APAFR") & "|"
                    ACFDIF_APAST = dt.Rows.Item(i).Item("ACFDIF_APAST") & "|"
                    ACFDIF_APRLL = dt.Rows.Item(i).Item("ACFDIF_APRLL") & "|"
                    ACFDIF_APRST = dt.Rows.Item(i).Item("ACFDIF_APRST") & "|"
                    ACFDIF_APURP = dt.Rows.Item(i).Item("ACFDIF_APURP") & "|"
                    ACFDIF_APUST = dt.Rows.Item(i).Item("ACFDIF_APUST") & "|"
                    ACFDIF_ARECC = dt.Rows.Item(i).Item("ACFDIF_ARECC") & "|"
                    ACFDIF_AREST = dt.Rows.Item(i).Item("ACFDIF_AREST") & "|"
                    ACFDIF_AZIRE = dt.Rows.Item(i).Item("ACFDIF_AZIRE") & "|"
                    ACFDIF_AZIST = dt.Rows.Item(i).Item("ACFDIF_AZIST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXSET")) = False Then
                        Dim ACFDIF_DXSET_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXSET")
                        ACFDIF_DXSET = ACFDIF_DXSET_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXSET = "0" & "|"
                    End If
                    ACFDIF_DXSST = dt.Rows.Item(i).Item("ACFDIF_DXSST") & "|"
                    ACFDIF_ASUDE = dt.Rows.Item(i).Item("ACFDIF_ASUDE") & "|"
                    ACFDIF_ASUST = dt.Rows.Item(i).Item("ACFDIF_ASUST") & "|"
                    ACFDIF_SCOID = dt.Rows.Item(i).Item("ACFDIF_SCOID") & "|"
                    ACFDIF_SCOST = dt.Rows.Item(i).Item("ACFDIF_SCOST") & "|"
                    ACFDIF_ARERI = dt.Rows.Item(i).Item("ACFDIF_ARERI") & "|"
                    ACFDIF_ARIST = dt.Rows.Item(i).Item("ACFDIF_ARIST") & "|"
                    ACFDIF_ABFVC = dt.Rows.Item(i).Item("ACFDIF_ABFVC").ToString.Replace(",", ".") & "|"
                    ACFDIF_ABFST = dt.Rows.Item(i).Item("ACFDIF_ABFST") & "|"
                    ACFDIF_AINRA = dt.Rows.Item(i).Item("ACFDIF_AINRA").ToString.Replace(",", ".") & "|"
                    ACFDIF_ANRST = dt.Rows.Item(i).Item("ACFDIF_ANRST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXNIR")) = False Then
                        Dim ACFDIF_DXNIR_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXNIR")
                        ACFDIF_DXNIR = ACFDIF_DXNIR_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXNIR = "0" & "|"
                    End If
                    ACFDIF_DXNST = dt.Rows.Item(i).Item("ACFDIF_DXNST") & "|"
                    ACFDIF_ADFST = dt.Rows.Item(i).Item("ACFDIF_ADFST") & "|"
                    ACFDIF_AFSST = dt.Rows.Item(i).Item("ACFDIF_AFSST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXFST")) = False Then
                        Dim ACFDIF_DXFST_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXFST")
                        ACFDIF_DXFST = ACFDIF_DXFST_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXFST = "0" & "|"
                    End If
                    ACFDIF_DFSST = dt.Rows.Item(i).Item("ACFDIF_DFSST") & "|"
                    ACFDIF_ATRAM = dt.Rows.Item(i).Item("ACFDIF_ATRAM").ToString.Replace(",", ".") & "|"
                    ACFDIF_ATRST = dt.Rows.Item(i).Item("ACFDIF_ATRST") & "|"
                    ACFDIF_AARIN = dt.Rows.Item(i).Item("ACFDIF_AARIN").ToString.Replace(",", ".") & "|"
                    ACFDIF_AARST = dt.Rows.Item(i).Item("ACFDIF_AARST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFDIF_DXPDI")) = False Then
                        Dim ACFDIF_DXPDI_Date As Date = dt.Rows.Item(i).Item("ACFDIF_DXPDI")
                        ACFDIF_DXPDI = ACFDIF_DXPDI_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFDIF_DXPDI = "0" & "|"
                    End If
                    ACFDIF_DXPST = dt.Rows.Item(i).Item("ACFDIF_DXPST") & "|"
                    ACFDIF_ATYOS = dt.Rows.Item(i).Item("ACFDIF_ATYOS") & "|"
                    ACFDIF_ATOST = dt.Rows.Item(i).Item("ACFDIF_ATOST") & "|"
                    ACFDIF_AOUNA = dt.Rows.Item(i).Item("ACFDIF_AOUNA").ToString.Replace(",", ".") & "|"
                    ACFDIF_AOUST = dt.Rows.Item(i).Item("ACFDIF_AOUST") & "|"
                    ACFDIF_AACIN = dt.Rows.Item(i).Item("ACFDIF_AACIN").ToString.Replace(",", ".") & "|"
                    ACFDIF_AACST = dt.Rows.Item(i).Item("ACFDIF_AACST") & "|"
                    ACFDIF_AOBSA = dt.Rows.Item(i).Item("ACFDIF_AOBSA").ToString.Replace(",", ".") & "|"
                    ACFDIF_AOBST = dt.Rows.Item(i).Item("ACFDIF_AOBST") & "|"
                    ACFDIF_RESE1 = dt.Rows.Item(i).Item("ACFDIF_RESE1") & "|"
                    ACFDIF_RESE2 = dt.Rows.Item(i).Item("ACFDIF_RESE2") & "|"
                    ACFDIF_RESE3 = dt.Rows.Item(i).Item("ACFDIF_RESE3") & "|"
                    ACFDIF_FREI1 = dt.Rows.Item(i).Item("ACFDIF_FREI1") & "|"
                    ACFDIF_FREI2 = dt.Rows.Item(i).Item("ACFDIF_FREI2") & "|"
                    ACFDIF_FREI3 = dt.Rows.Item(i).Item("ACFDIF_FREI3") & "|"
                    ACFDIF_FREI4 = dt.Rows.Item(i).Item("ACFDIF_FREI4") & "|"
                    ACFDIF_FREI5 = dt.Rows.Item(i).Item("ACFDIF_FREI5") & "|"
                    ACFDIF_LOEKZ = dt.Rows.Item(i).Item("ACFDIF_LOEKZ") & "|"
                    ACFDIF_IFNAM = dt.Rows.Item(i).Item("ACFDIF_IFNAM") & "|"
                    ACFDIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACFDIF_DXIFD"))


                    CSV_ROW =
                        ACFDIF_MDANT &
                        ACFDIF_ARAID &
                        ACFDIF_AOAID &
                        ACFDIF_ACTID &
                        ACFDIF_AINID &
                        ACFDIF_MODUL &
                        ACFDIF_KDNRH &
                        ACFDIF_KTONR &
                        ACFDIF_GSREF &
                        ACFDIF_WPKNR &
                        ACFDIF_DEPNR &
                        ACFDIF_HAWHG &
                        ACFDIF_FILNR &
                        ACFDIF_KZICL &
                        ACFDIF_ATYOI &
                        ACFDIF_ATYST &
                        ACFDIF_AAMTY &
                        ACFDIF_AAMST &
                        ACFDIF_WHISO &
                        ACFDIF_WHIST &
                        ACFDIF_AFIIN &
                        ACFDIF_AFIST &
                        ACFDIF_DXVBE &
                        ACFDIF_DXVST &
                        ACFDIF_DXIOP &
                        ACFDIF_DXIST &
                        ACFDIF_AINRC &
                        ACFDIF_AINST &
                        ACFDIF_AINRF &
                        ACFDIF_AIRST &
                        ACFDIF_AIRRF &
                        ACFDIF_ARRST &
                        ACFDIF_AIRSM &
                        ACFDIF_AIMST &
                        ACFDIF_AINRT &
                        ACFDIF_AISST &
                        ACFDIF_DXMAT &
                        ACFDIF_DXMST &
                        ACFDIF_ATCAI &
                        ACFDIF_ATCST &
                        ACFDIF_APAFR &
                        ACFDIF_APAST &
                        ACFDIF_APRLL &
                        ACFDIF_APRST &
                        ACFDIF_APURP &
                        ACFDIF_APUST &
                        ACFDIF_ARECC &
                        ACFDIF_AREST &
                        ACFDIF_AZIRE &
                        ACFDIF_AZIST &
                        ACFDIF_DXSET &
                        ACFDIF_DXSST &
                        ACFDIF_ASUDE &
                        ACFDIF_ASUST &
                        ACFDIF_SCOID &
                        ACFDIF_SCOST &
                        ACFDIF_ARERI &
                        ACFDIF_ARIST &
                        ACFDIF_ABFVC &
                        ACFDIF_ABFST &
                        ACFDIF_AINRA &
                        ACFDIF_ANRST &
                        ACFDIF_DXNIR &
                        ACFDIF_DXNST &
                        ACFDIF_ADFST &
                        ACFDIF_AFSST &
                        ACFDIF_DXFST &
                        ACFDIF_DFSST &
                        ACFDIF_ATRAM &
                        ACFDIF_ATRST &
                        ACFDIF_AARIN &
                        ACFDIF_AARST &
                        ACFDIF_DXPDI &
                        ACFDIF_DXPST &
                        ACFDIF_ATYOS &
                        ACFDIF_ATOST &
                        ACFDIF_AOUNA &
                        ACFDIF_AOUST &
                        ACFDIF_AACIN &
                        ACFDIF_AACST &
                        ACFDIF_AOBSA &
                        ACFDIF_AOBST &
                        ACFDIF_RESE1 &
                        ACFDIF_RESE2 &
                        ACFDIF_RESE3 &
                        ACFDIF_FREI1 &
                        ACFDIF_FREI2 &
                        ACFDIF_FREI3 &
                        ACFDIF_FREI4 &
                        ACFDIF_FREI5 &
                        ACFDIF_LOEKZ &
                        ACFDIF_IFNAM &
                        ACFDIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACFDAF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\GSTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ACFDIF_Result = "Created"
            Else
                Me.ACFDIF_Result = "Not Created"
                XtraMessageBox.Show("Unable to create File ACFDAF.csv for " & rd & vbNewLine & "There are no data in Table BAIS_ACFDAF for this Date", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If
        Catch ex As System.Exception
            'SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ACFDIF_Result = "Not Created"
        End Try

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ACFAIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        Dim CSV_HEADER As String =
                "ACFAAF_MDANT" &
                "|ACFAAF_ARAID" &
                "|ACFAAF_AOAID" &
                "|ACFAAF_ACTID" &
                "|ACFAAF_AINID" &
                "|ACFAAF_MODUL" &
                "|ACFAAF_KDREA" &
                "|ACFAAF_KTONR" &
                "|ACFAAF_GSREF" &
                "|ACFAAF_WPKNR" &
                "|ACFAAF_DEPNR" &
                "|ACFAAF_HAWHG" &
                "|ACFAAF_FILNR" &
                "|ACFAAF_AACOF" &
                "|ACFAAF_AAOST" &
                "|ACFAAF_ABASR" &
                "|ACFAAF_ABAST" &
                "|ACFAAF_AACWO" &
                "|ACFAAF_AAWST" &
                "|ACFAAF_AACIA" &
                "|ACFAAF_AAIST" &
                "|ACFAAF_ATYIM" &
                "|ACFAAF_ATIST" &
                "|ACFAAF_AIMAM" &
                "|ACFAAF_AIAST" &
                "|ACFAAF_ASOOE" &
                "|ACFAAF_ASOST" &
                "|ACFAAF_AAFVC" &
                "|ACFAAF_AAFST" &
                "|ACFAAF_APSIN" &
                "|ACFAAF_APSST" &
                "|ACFAAF_DXPSI" &
                "|ACFAAF_XPSST" &
                "|ACFAAF_APAOF" &
                "|ACFAAF_APOST" &
                "|ACFAAF_ASOFR" &
                "|ACFAAF_ASFST" &
                "|ACFAAF_DXSFR" &
                "|ACFAAF_DXOST" &
                "|ACFAAF_ACRSD" &
                "|ACFAAF_ACRST" &
                "|ACFAAF_HBKZN" &
                "|ACFAAF_HBKST" &
                "|ACFAAF_ACAAM" &
                "|ACFAAF_ACAST" &
                "|ACFAAF_RESE1" &
                "|ACFAAF_RESE2" &
                "|ACFAAF_RESE3" &
                "|ACFAAF_FREI1" &
                "|ACFAAF_FREI2" &
                "|ACFAAF_FREI3" &
                "|ACFAAF_FREI4" &
                "|ACFAAF_FREI5" &
                "|ACFAAF_LOEKZ" &
                "|ACFAAF_IFNAM" &
                "|ACFAAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACFAIF_MDANT As String = Nothing
        Dim ACFAIF_ARAID As String = Nothing
        Dim ACFAIF_AOAID As String = Nothing
        Dim ACFAIF_ACTID As String = Nothing
        Dim ACFAIF_AINID As String = Nothing
        Dim ACFAIF_MODUL As String = Nothing
        Dim ACFAIF_KDNRH As String = Nothing
        Dim ACFAIF_KTONR As String = Nothing
        Dim ACFAIF_GSREF As String = Nothing
        Dim ACFAIF_WPKNR As String = Nothing
        Dim ACFAIF_DEPNR As String = Nothing
        Dim ACFAIF_HAWHG As String = Nothing
        Dim ACFAIF_FILNR As String = Nothing
        Dim ACFAIF_AACOF As String = Nothing
        Dim ACFAIF_AAOST As String = Nothing
        Dim ACFAIF_ABASR As String = Nothing
        Dim ACFAIF_ABAST As String = Nothing
        Dim ACFAIF_AACWO As String = Nothing
        Dim ACFAIF_AAWST As String = Nothing
        Dim ACFAIF_AACIA As String = Nothing
        Dim ACFAIF_AAIST As String = Nothing
        Dim ACFAIF_ATYIM As String = Nothing
        Dim ACFAIF_ATIST As String = Nothing
        Dim ACFAIF_AIMAM As String = Nothing
        Dim ACFAIF_AIAST As String = Nothing
        Dim ACFAIF_ASOOE As String = Nothing
        Dim ACFAIF_ASOST As String = Nothing
        Dim ACFAIF_AAFVC As String = Nothing
        Dim ACFAIF_AAFST As String = Nothing
        Dim ACFAIF_APSIN As String = Nothing
        Dim ACFAIF_APSST As String = Nothing
        Dim ACFAIF_DXPSI As String = Nothing
        Dim ACFAIF_XPSST As String = Nothing
        Dim ACFAIF_APAOF As String = Nothing
        Dim ACFAIF_APOST As String = Nothing
        Dim ACFAIF_ASOFR As String = Nothing
        Dim ACFAIF_ASFST As String = Nothing
        Dim ACFAIF_DXSFR As String = Nothing
        Dim ACFAIF_DXOST As String = Nothing
        Dim ACFAIF_ACRSD As String = Nothing
        Dim ACFAIF_ACRST As String = Nothing
        Dim ACFAIF_HBKZN As String = Nothing
        Dim ACFAIF_HBKST As String = Nothing
        Dim ACFAIF_ACAAM As String = Nothing
        Dim ACFAIF_ACAST As String = Nothing
        Dim ACFAIF_RESE1 As String = Nothing
        Dim ACFAIF_RESE2 As String = Nothing
        Dim ACFAIF_RESE3 As String = Nothing
        Dim ACFAIF_FREI1 As String = Nothing
        Dim ACFAIF_FREI2 As String = Nothing
        Dim ACFAIF_FREI3 As String = Nothing
        Dim ACFAIF_FREI4 As String = Nothing
        Dim ACFAIF_FREI5 As String = Nothing
        Dim ACFAIF_LOEKZ As String = Nothing
        Dim ACFAIF_IFNAM As String = Nothing
        Dim ACFAIF_DXIFD As String = Nothing

        Try

            BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACFAAF_CCB.csv")
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACFAIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACFAIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If



            If File.Exists(BaisFilesCreationPath & "ACFAAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "ACFAAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "ACFAAF_CCB.csv", CSV_HEADER & vbCrLf)

            cmd.CommandText = "Select Count([ID]) from [BAIS_ACFAIF] where [ACFAIF_DXIFD]='" & rdsql & "'"
            Dim Count As Double = cmd.ExecuteScalar
            If Count <> 0 Then

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACFAAF_CCB.csv...Please wait...")
                'New Code


                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_ACFAIF] where [ACFAIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    ACFAIF_MDANT = dt.Rows.Item(i).Item("ACFAIF_MDANT") & "|"
                    ACFAIF_ARAID = dt.Rows.Item(i).Item("ACFAIF_ARAID") & "|"
                    ACFAIF_AOAID = dt.Rows.Item(i).Item("ACFAIF_AOAID") & "|"
                    ACFAIF_ACTID = dt.Rows.Item(i).Item("ACFAIF_ACTID") & "|"
                    ACFAIF_AINID = dt.Rows.Item(i).Item("ACFAIF_AINID") & "|"
                    ACFAIF_MODUL = dt.Rows.Item(i).Item("ACFAIF_MODUL") & "|"
                    ACFAIF_KDNRH = dt.Rows.Item(i).Item("ACFAIF_KDNRH") & "|"
                    ACFAIF_KTONR = dt.Rows.Item(i).Item("ACFAIF_KTONR") & "|"
                    ACFAIF_GSREF = dt.Rows.Item(i).Item("ACFAIF_GSREF") & "|"
                    ACFAIF_WPKNR = dt.Rows.Item(i).Item("ACFAIF_WPKNR") & "|"
                    ACFAIF_DEPNR = dt.Rows.Item(i).Item("ACFAIF_DEPNR") & "|"
                    ACFAIF_HAWHG = dt.Rows.Item(i).Item("ACFAIF_HAWHG") & "|"
                    ACFAIF_FILNR = dt.Rows.Item(i).Item("ACFAIF_FILNR") & "|"
                    ACFAIF_AACOF = dt.Rows.Item(i).Item("ACFAIF_AACOF") & "|"
                    ACFAIF_AAOST = dt.Rows.Item(i).Item("ACFAIF_AAOST") & "|"
                    ACFAIF_ABASR = dt.Rows.Item(i).Item("ACFAIF_ABASR") & "|"
                    ACFAIF_ABAST = dt.Rows.Item(i).Item("ACFAIF_ABAST") & "|"
                    ACFAIF_AACWO = dt.Rows.Item(i).Item("ACFAIF_AACWO").ToString.Replace(",", ".") & "|"
                    ACFAIF_AAWST = dt.Rows.Item(i).Item("ACFAIF_AAWST") & "|"
                    ACFAIF_AACIA = dt.Rows.Item(i).Item("ACFAIF_AACIA").ToString.Replace(",", ".") & "|"
                    ACFAIF_AAIST = dt.Rows.Item(i).Item("ACFAIF_AAIST") & "|"
                    ACFAIF_ATYIM = dt.Rows.Item(i).Item("ACFAIF_ATYIM") & "|"
                    ACFAIF_ATIST = dt.Rows.Item(i).Item("ACFAIF_ATIST") & "|"
                    ACFAIF_AIMAM = dt.Rows.Item(i).Item("ACFAIF_AIMAM") & "|"
                    ACFAIF_AIAST = dt.Rows.Item(i).Item("ACFAIF_AIAST") & "|"
                    ACFAIF_ASOOE = dt.Rows.Item(i).Item("ACFAIF_ASOOE") & "|"
                    ACFAIF_ASOST = dt.Rows.Item(i).Item("ACFAIF_ASOST") & "|"
                    ACFAIF_AAFVC = dt.Rows.Item(i).Item("ACFAIF_AAFVC").ToString.Replace(",", ".") & "|"
                    ACFAIF_AAFST = dt.Rows.Item(i).Item("ACFAIF_AAFST") & "|"
                    ACFAIF_APSIN = dt.Rows.Item(i).Item("ACFAIF_APSIN") & "|"
                    ACFAIF_APSST = dt.Rows.Item(i).Item("ACFAIF_APSST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFAIF_DXPSI")) = False Then
                        Dim ACFAIF_DXPSI_Date As Date = dt.Rows.Item(i).Item("ACFAIF_DXPSI")
                        ACFAIF_DXPSI = ACFAIF_DXPSI_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFAIF_DXPSI = "0" & "|"
                    End If
                    ACFAIF_XPSST = dt.Rows.Item(i).Item("ACFAIF_XPSST") & "|"
                    ACFAIF_APAOF = dt.Rows.Item(i).Item("ACFAIF_APAOF").ToString.Replace(",", ".") & "|"
                    ACFAIF_APOST = dt.Rows.Item(i).Item("ACFAIF_APOST") & "|"
                    ACFAIF_ASOFR = dt.Rows.Item(i).Item("ACFAIF_ASOFR") & "|"
                    ACFAIF_ASFST = dt.Rows.Item(i).Item("ACFAIF_ASFST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACFAIF_DXSFR")) = False Then
                        Dim ACFAIF_DXSFR_Date As Date = dt.Rows.Item(i).Item("ACFAIF_DXSFR")
                        ACFAIF_DXSFR = ACFAIF_DXSFR_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACFAIF_DXSFR = "0" & "|"
                    End If
                    ACFAIF_DXOST = dt.Rows.Item(i).Item("ACFAIF_DXOST") & "|"
                    ACFAIF_ACRSD = dt.Rows.Item(i).Item("ACFAIF_ACRSD").ToString.Replace(",", ".") & "|"
                    ACFAIF_ACRST = dt.Rows.Item(i).Item("ACFAIF_ACRST") & "|"
                    ACFAIF_HBKZN = dt.Rows.Item(i).Item("ACFAIF_HBKZN") & "|"
                    ACFAIF_HBKST = dt.Rows.Item(i).Item("ACFAIF_HBKST") & "|"
                    ACFAIF_ACAAM = dt.Rows.Item(i).Item("ACFAIF_ACAAM").ToString.Replace(",", ".") & "|"
                    ACFAIF_ACAST = dt.Rows.Item(i).Item("ACFAIF_ACAST") & "|"
                    ACFAIF_RESE1 = dt.Rows.Item(i).Item("ACFAIF_RESE1") & "|"
                    ACFAIF_RESE2 = dt.Rows.Item(i).Item("ACFAIF_RESE2") & "|"
                    ACFAIF_RESE3 = dt.Rows.Item(i).Item("ACFAIF_RESE3") & "|"
                    ACFAIF_FREI1 = dt.Rows.Item(i).Item("ACFAIF_FREI1") & "|"
                    ACFAIF_FREI2 = dt.Rows.Item(i).Item("ACFAIF_FREI2") & "|"
                    ACFAIF_FREI3 = dt.Rows.Item(i).Item("ACFAIF_FREI3") & "|"
                    ACFAIF_FREI4 = dt.Rows.Item(i).Item("ACFAIF_FREI4") & "|"
                    ACFAIF_FREI5 = dt.Rows.Item(i).Item("ACFAIF_FREI5") & "|"
                    ACFAIF_LOEKZ = dt.Rows.Item(i).Item("ACFAIF_LOEKZ") & "|"
                    ACFAIF_IFNAM = dt.Rows.Item(i).Item("ACFAIF_IFNAM") & "|"
                    ACFAIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACFAIF_DXIFD")) & "|"

                    CSV_ROW =
                        ACFAIF_MDANT &
                        ACFAIF_ARAID &
                        ACFAIF_AOAID &
                        ACFAIF_ACTID &
                        ACFAIF_AINID &
                        ACFAIF_MODUL &
                        ACFAIF_KDNRH &
                        ACFAIF_KTONR &
                        ACFAIF_GSREF &
                        ACFAIF_WPKNR &
                        ACFAIF_DEPNR &
                        ACFAIF_HAWHG &
                        ACFAIF_FILNR &
                        ACFAIF_AACOF &
                        ACFAIF_AAOST &
                        ACFAIF_ABASR &
                        ACFAIF_ABAST &
                        ACFAIF_AACWO &
                        ACFAIF_AAWST &
                        ACFAIF_AACIA &
                        ACFAIF_AAIST &
                        ACFAIF_ATYIM &
                        ACFAIF_ATIST &
                        ACFAIF_AIMAM &
                        ACFAIF_AIAST &
                        ACFAIF_ASOOE &
                        ACFAIF_ASOST &
                        ACFAIF_AAFVC &
                        ACFAIF_AAFST &
                        ACFAIF_APSIN &
                        ACFAIF_APSST &
                        ACFAIF_DXPSI &
                        ACFAIF_XPSST &
                        ACFAIF_APAOF &
                        ACFAIF_APOST &
                        ACFAIF_ASOFR &
                        ACFAIF_ASFST &
                        ACFAIF_DXSFR &
                        ACFAIF_DXOST &
                        ACFAIF_ACRSD &
                        ACFAIF_ACRST &
                        ACFAIF_HBKZN &
                        ACFAIF_HBKST &
                        ACFAIF_ACAAM &
                        ACFAIF_ACAST &
                        ACFAIF_RESE1 &
                        ACFAIF_RESE2 &
                        ACFAIF_RESE3 &
                        ACFAIF_FREI1 &
                        ACFAIF_FREI2 &
                        ACFAIF_FREI3 &
                        ACFAIF_FREI4 &
                        ACFAIF_FREI5 &
                        ACFAIF_LOEKZ &
                        ACFAIF_IFNAM &
                        ACFAIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACFAAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.ACFAIF_Result = "Created"
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            Else
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACFAIF_Result = "Not Created"
                XtraMessageBox.Show("Unable to create File ACFAAF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub

            End If

        Catch ex As System.Exception
            'SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ACFAIF_Result = "Not Created"
        End Try

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ACIPIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        Dim CSV_HEADER As String =
                "ACIPIF_MDANT" &
                "|ACIPIF_ARAID" &
                "|ACIPIF_AOAID" &
                "|ACIPIF_APRID" &
                "|ACIPIF_GARFN" &
                "|ACIPIF_ATYOP" &
                "|ACIPIF_ATYST" &
                "|ACIPIF_APRVA" &
                "|ACIPIF_APRST" &
                "|ACIPIF_ATOPV" &
                "|ACIPIF_ATOST" &
                "|ACIPIF_APVAP" &
                "|ACIPIF_APVST" &
                "|ACIPIF_LDISO" &
                "|ACIPIF_LDIST" &
                "|ACIPIF_KREIS" &
                "|ACIPIF_KREST" &
                "|ACIPIF_PLZNR" &
                "|ACIPIF_PLNST" &
                "|ACIPIF_DXPRV" &
                "|ACIPIF_DXPST" &
                "|ACIPIF_DXMAT" &
                "|ACIPIF_DXMST" &
                "|ACIPIF_APROV" &
                "|ACIPIF_APOST" &
                "|ACIPIF_DXPRO" &
                "|ACIPIF_DXOST" &
                "|ACIPIF_RESE1" &
                "|ACIPIF_RESE2" &
                "|ACIPIF_RESE3" &
                "|ACIPIF_FREI1" &
                "|ACIPIF_FREI2" &
                "|ACIPIF_FREI3" &
                "|ACIPIF_FREI4" &
                "|ACIPIF_FREI5" &
                "|ACIPIF_LOEKZ" &
                "|ACIPIF_IFNAM" &
                "|ACIPIF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACIPIF_MDANT As String = Nothing
        Dim ACIPIF_ARAID As String = Nothing
        Dim ACIPIF_AOAID As String = Nothing
        Dim ACIPIF_APRID As String = Nothing
        Dim ACIPIF_GARFN As String = Nothing
        Dim ACIPIF_ATYOP As String = Nothing
        Dim ACIPIF_ATYST As String = Nothing
        Dim ACIPIF_APRVA As String = Nothing
        Dim ACIPIF_APRST As String = Nothing
        Dim ACIPIF_ATOPV As String = Nothing
        Dim ACIPIF_ATOST As String = Nothing
        Dim ACIPIF_APVAP As String = Nothing
        Dim ACIPIF_APVST As String = Nothing
        Dim ACIPIF_LDISO As String = Nothing
        Dim ACIPIF_LDIST As String = Nothing
        Dim ACIPIF_KREIS As String = Nothing
        Dim ACIPIF_KREST As String = Nothing
        Dim ACIPIF_PLZNR As String = Nothing
        Dim ACIPIF_PLNST As String = Nothing
        Dim ACIPIF_DXPRV As String = Nothing
        Dim ACIPIF_DXPST As String = Nothing
        Dim ACIPIF_DXMAT As String = Nothing
        Dim ACIPIF_DXMST As String = Nothing
        Dim ACIPIF_APROV As String = Nothing
        Dim ACIPIF_APOST As String = Nothing
        Dim ACIPIF_DXPRO As String = Nothing
        Dim ACIPIF_DXOST As String = Nothing
        Dim ACIPIF_RESE1 As String = Nothing
        Dim ACIPIF_RESE2 As String = Nothing
        Dim ACIPIF_RESE3 As String = Nothing
        Dim ACIPIF_FREI1 As String = Nothing
        Dim ACIPIF_FREI2 As String = Nothing
        Dim ACIPIF_FREI3 As String = Nothing
        Dim ACIPIF_FREI4 As String = Nothing
        Dim ACIPIF_FREI5 As String = Nothing
        Dim ACIPIF_LOEKZ As String = Nothing
        Dim ACIPIF_IFNAM As String = Nothing
        Dim ACIPIF_DXIFD As String = Nothing

        Try
            BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACIPIF_CCB.csv")
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACIPIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACIPIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If



            If File.Exists(BaisFilesCreationPath & "ACIPIF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "ACIPIF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "ACIPIF_CCB.csv", CSV_HEADER & vbCrLf)

            cmd.CommandText = "Select Count([ID]) from [BAIS_ACIPIF] where [ACIPIF_DXIFD]='" & rdsql & "'"
            Dim Count As Double = cmd.ExecuteScalar
            If Count <> 0 Then

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACIPIF_CCB.csv .... Please wait...")

                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_ACIPIF] where [ACFAIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    ACIPIF_MDANT = dt.Rows.Item(i).Item("ACIPIF_MDANT") & "|"
                    ACIPIF_ARAID = dt.Rows.Item(i).Item("ACIPIF_ARAID") & "|"
                    ACIPIF_AOAID = dt.Rows.Item(i).Item("ACIPIF_AOAID") & "|"
                    ACIPIF_APRID = dt.Rows.Item(i).Item("ACIPIF_APRID") & "|"
                    ACIPIF_GARFN = dt.Rows.Item(i).Item("ACIPIF_GARFN") & "|"
                    ACIPIF_ATYOP = dt.Rows.Item(i).Item("ACIPIF_ATYOP") & "|"
                    ACIPIF_ATYST = dt.Rows.Item(i).Item("ACIPIF_ATYST") & "|"
                    ACIPIF_APRVA = dt.Rows.Item(i).Item("ACIPIF_APRVA").ToString.Replace(",", ".") & "|"
                    ACIPIF_APRST = dt.Rows.Item(i).Item("ACIPIF_APRST") & "|"
                    ACIPIF_ATOPV = dt.Rows.Item(i).Item("ACIPIF_ATOPV") & "|"
                    ACIPIF_ATOST = dt.Rows.Item(i).Item("ACIPIF_ATOST") & "|"
                    ACIPIF_APVAP = dt.Rows.Item(i).Item("ACIPIF_APVAP") & "|"
                    ACIPIF_APVST = dt.Rows.Item(i).Item("ACIPIF_APVST") & "|"
                    ACIPIF_LDISO = dt.Rows.Item(i).Item("ACIPIF_LDISO") & "|"
                    ACIPIF_LDIST = dt.Rows.Item(i).Item("ACIPIF_LDIST") & "|"
                    ACIPIF_KREIS = dt.Rows.Item(i).Item("ACIPIF_KREIS") & "|"
                    ACIPIF_KREST = dt.Rows.Item(i).Item("ACIPIF_KREST") & "|"
                    ACIPIF_PLZNR = dt.Rows.Item(i).Item("ACIPIF_PLZNR") & "|"
                    ACIPIF_PLNST = dt.Rows.Item(i).Item("ACIPIF_PLNST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACIPIF_DXPRV")) = False Then
                        Dim ACIPIF_DXPRV_Date As Date = dt.Rows.Item(i).Item("ACIPIF_DXPRV")
                        ACIPIF_DXPRV = ACIPIF_DXPRV_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACIPIF_DXPRV = "0" & "|"
                    End If
                    ACIPIF_DXPST = dt.Rows.Item(i).Item("ACIPIF_DXPST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACIPIF_DXMAT")) = False Then
                        Dim ACIPIF_DXMAT_Date As Date = dt.Rows.Item(i).Item("ACIPIF_DXMAT")
                        ACIPIF_DXMAT = ACIPIF_DXMAT_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACIPIF_DXMAT = "0" & "|"
                    End If
                    ACIPIF_DXMST = dt.Rows.Item(i).Item("ACIPIF_DXMST") & "|"
                    ACIPIF_APROV = dt.Rows.Item(i).Item("ACIPIF_APROV").ToString.Replace(",", ".") & "|"
                    ACIPIF_APOST = dt.Rows.Item(i).Item("ACIPIF_APOST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACIPIF_DXPRO")) = False Then
                        Dim ACIPIF_DXPRO_Date As Date = dt.Rows.Item(i).Item("ACIPIF_DXPRO")
                        ACIPIF_DXPRO = ACIPIF_DXPRO_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACIPIF_DXPRO = "0" & "|"
                    End If
                    ACIPIF_DXPRO = dt.Rows.Item(i).Item("ACIPIF_DXPRO") & "|"
                    ACIPIF_DXOST = dt.Rows.Item(i).Item("ACIPIF_DXOST") & "|"
                    ACIPIF_RESE1 = dt.Rows.Item(i).Item("ACIPIF_RESE1") & "|"
                    ACIPIF_RESE2 = dt.Rows.Item(i).Item("ACIPIF_RESE2") & "|"
                    ACIPIF_RESE3 = dt.Rows.Item(i).Item("ACIPIF_RESE3") & "|"
                    ACIPIF_FREI1 = dt.Rows.Item(i).Item("ACIPIF_FREI1") & "|"
                    ACIPIF_FREI2 = dt.Rows.Item(i).Item("ACIPIF_FREI2") & "|"
                    ACIPIF_FREI3 = dt.Rows.Item(i).Item("ACIPIF_FREI3") & "|"
                    ACIPIF_FREI4 = dt.Rows.Item(i).Item("ACIPIF_FREI4") & "|"
                    ACIPIF_FREI5 = dt.Rows.Item(i).Item("ACIPIF_FREI5") & "|"
                    ACIPIF_LOEKZ = dt.Rows.Item(i).Item("ACIPIF_LOEKZ") & "|"
                    ACIPIF_IFNAM = dt.Rows.Item(i).Item("ACIPIF_IFNAM") & "|"
                    ACIPIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACIPIF_DXIFD")) & "|"

                    CSV_ROW =
                        ACIPIF_MDANT &
                        ACIPIF_ARAID &
                        ACIPIF_AOAID &
                        ACIPIF_APRID &
                        ACIPIF_GARFN &
                        ACIPIF_ATYOP &
                        ACIPIF_ATYST &
                        ACIPIF_APRVA &
                        ACIPIF_APRST &
                        ACIPIF_ATOPV &
                        ACIPIF_ATOST &
                        ACIPIF_APVAP &
                        ACIPIF_APVST &
                        ACIPIF_LDISO &
                        ACIPIF_LDIST &
                        ACIPIF_KREIS &
                        ACIPIF_KREST &
                        ACIPIF_PLZNR &
                        ACIPIF_PLNST &
                        ACIPIF_DXPRV &
                        ACIPIF_DXPST &
                        ACIPIF_DXMAT &
                        ACIPIF_DXMST &
                        ACIPIF_APROV &
                        ACIPIF_APOST &
                        ACIPIF_DXPRO &
                        ACIPIF_DXOST &
                        ACIPIF_RESE1 &
                        ACIPIF_RESE2 &
                        ACIPIF_RESE3 &
                        ACIPIF_FREI1 &
                        ACIPIF_FREI2 &
                        ACIPIF_FREI3 &
                        ACIPIF_FREI4 &
                        ACIPIF_FREI5 &
                        ACIPIF_LOEKZ &
                        ACIPIF_IFNAM &
                        ACIPIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACIPIF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACIPIF_Result = "Created"

            Else
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show("Unable to create File ACIPIF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ACIPIF_Result = "Not Created"
                Exit Sub

            End If


        Catch ex As System.Exception

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.ACIPIF_Result = "Not Created"
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ACCFIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACCFIF_CCB.csv")
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACCFIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACCFIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If

        Dim CSV_HEADER As String =
            "ACCFIF_MDANT" &
            "|ACCFIF_ARAID" &
            "|ACCFIF_AOAID" &
            "|ACCFIF_ACPTP" &
            "|ACCFIF_ACPID" &
            "|ACCFIF_ACTID" &
            "|ACCFIF_AINID" &
            "|ACCFIF_ACPRO" &
            "|ACCFIF_JLIAM" &
            "|ACCFIF_JLIST" &
            "|ACCFIF_FREI1" &
            "|ACCFIF_FREI2" &
            "|ACCFIF_FREI3" &
            "|ACCFIF_FREI4" &
            "|ACCFIF_FREI5" &
            "|ACCFIF_LOEKZ" &
            "|ACCFIF_IFNAM" &
            "|ACCFIF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACCFIF_MDANT As String = Nothing
        Dim ACCFIF_ARAID As String = Nothing
        Dim ACCFIF_AOAID As String = Nothing
        Dim ACCFIF_ACPTP As String = Nothing
        Dim ACCFIF_ACPID As String = Nothing
        Dim ACCFIF_ACTID As String = Nothing
        Dim ACCFIF_AINID As String = Nothing
        Dim ACCFIF_ACPRO As String = Nothing
        Dim ACCFIF_JLIAM As String = Nothing
        Dim ACCFIF_JLIST As String = Nothing
        Dim ACCFIF_FREI1 As String = Nothing
        Dim ACCFIF_FREI2 As String = Nothing
        Dim ACCFIF_FREI3 As String = Nothing
        Dim ACCFIF_FREI4 As String = Nothing
        Dim ACCFIF_FREI5 As String = Nothing
        Dim ACCFIF_LOEKZ As String = Nothing
        Dim ACCFIF_IFNAM As String = Nothing
        Dim ACCFIF_DXIFD As String = Nothing


        If File.Exists(BaisFilesCreationPath & "ACCFIF_CCB.csv") = True Then
            File.Delete(BaisFilesCreationPath & "ACCFIF_CCB.csv")
        End If
        'Create Header
        System.IO.File.AppendAllText(BaisFilesCreationPath & "ACCFIF_CCB.csv", CSV_HEADER & vbCrLf)

        cmd.CommandText = "Select Count([ID]) from [BAIS_ACCFIF] where [ACCFIF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACCFIF_CCB.csv...Please wait...")

                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_ACCFIF] where [ACCFIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    ACCFIF_MDANT = dt.Rows.Item(i).Item("ACCFIF_MDANT") & "|"
                    ACCFIF_ARAID = dt.Rows.Item(i).Item("ACCFIF_ARAID") & "|"
                    ACCFIF_AOAID = dt.Rows.Item(i).Item("ACCFIF_AOAID") & "|"
                    ACCFIF_ACPTP = dt.Rows.Item(i).Item("ACCFIF_ACPTP") & "|"
                    ACCFIF_ACPID = dt.Rows.Item(i).Item("ACCFIF_ACPID") & "|"
                    ACCFIF_ACTID = dt.Rows.Item(i).Item("ACCFIF_ACTID") & "|"
                    ACCFIF_AINID = dt.Rows.Item(i).Item("ACCFIF_AINID") & "|"
                    ACCFIF_ACPRO = dt.Rows.Item(i).Item("ACCFIF_ACPRO") & "|"
                    ACCFIF_JLIAM = dt.Rows.Item(i).Item("ACCFIF_JLIAM").ToString.Replace(",", ".") & "|"
                    ACCFIF_JLIST = dt.Rows.Item(i).Item("ACCFIF_JLIST") & "|"
                    ACCFIF_FREI1 = dt.Rows.Item(i).Item("ACCFIF_FREI1") & "|"
                    ACCFIF_FREI2 = dt.Rows.Item(i).Item("ACCFIF_FREI2") & "|"
                    ACCFIF_FREI3 = dt.Rows.Item(i).Item("ACCFIF_FREI3") & "|"
                    ACCFIF_FREI4 = dt.Rows.Item(i).Item("ACCFIF_FREI4") & "|"
                    ACCFIF_FREI5 = dt.Rows.Item(i).Item("ACCFIF_FREI5") & "|"
                    ACCFIF_LOEKZ = dt.Rows.Item(i).Item("ACCFIF_LOEKZ") & "|"
                    ACCFIF_IFNAM = dt.Rows.Item(i).Item("ACCFIF_IFNAM") & "|"
                    ACCFIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACCFIF_DXIFD")) & "|"


                    CSV_ROW =
                        ACCFIF_MDANT &
                        ACCFIF_ARAID &
                        ACCFIF_AOAID &
                        ACCFIF_ACPTP &
                        ACCFIF_ACPID &
                        ACCFIF_ACTID &
                        ACCFIF_AINID &
                        ACCFIF_ACPRO &
                        ACCFIF_JLIAM &
                        ACCFIF_JLIST &
                        ACCFIF_FREI1 &
                        ACCFIF_FREI2 &
                        ACCFIF_FREI3 &
                        ACCFIF_FREI4 &
                        ACCFIF_FREI5 &
                        ACCFIF_LOEKZ &
                        ACCFIF_IFNAM &
                        ACCFIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACCFIF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACCFIF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACCFIF_Result = "Not Created"
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            Me.ACCFIF_Result = "Not Created"
            XtraMessageBox.Show("Unable to create File ACCFIF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ACIFIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        'New Code
        Dim CSV_HEADER As String =
            "ACIFIF_MDANT" &
            "|ACIFIF_ARAID" &
            "|ACIFIF_AOAID" &
            "|ACIFIF_APRID" &
            "|ACIFIF_ACTID" &
            "|ACIFIF_AINID" &
            "|ACIFIF_APAVA" &
            "|ACIFIF_APAST" &
            "|ACIFIF_ASCPS" &
            "|ACIFIF_ASCST" &
            "|ACIFIF_FREI1" &
            "|ACIFIF_FREI2" &
            "|ACIFIF_FREI3" &
            "|ACIFIF_FREI4" &
            "|ACIFIF_FREI5" &
            "|ACIFIF_LOEKZ" &
            "|ACIFIF_IFNAM" &
            "|ACIFIF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACIFIF_MDANT As String = Nothing
        Dim ACIFIF_ARAID As String = Nothing
        Dim ACIFIF_AOAID As String = Nothing
        Dim ACIFIF_APRID As String = Nothing
        Dim ACIFIF_ACTID As String = Nothing
        Dim ACIFIF_AINID As String = Nothing
        Dim ACIFIF_APAVA As String = Nothing
        Dim ACIFIF_APAST As String = Nothing
        Dim ACIFIF_ASCPS As String = Nothing
        Dim ACIFIF_ASCST As String = Nothing
        Dim ACIFIF_FREI1 As String = Nothing
        Dim ACIFIF_FREI2 As String = Nothing
        Dim ACIFIF_FREI3 As String = Nothing
        Dim ACIFIF_FREI4 As String = Nothing
        Dim ACIFIF_FREI5 As String = Nothing
        Dim ACIFIF_LOEKZ As String = Nothing
        Dim ACIFIF_IFNAM As String = Nothing
        Dim ACIFIF_DXIFD As String = Nothing

        BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACIFIF_CCB.csv")
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACIFIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACIFIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If


        If File.Exists(BaisFilesCreationPath & "ACIFIF_CCB.csv") = True Then
            File.Delete(BaisFilesCreationPath & "ACIFIF_CCB.csv")
        End If
        'Create Header
        System.IO.File.AppendAllText(BaisFilesCreationPath & "ACIFIF_CCB.csv", CSV_HEADER & vbCrLf)

        cmd.CommandText = "Select Count([ID]) from [BAIS_ACIFIF] where [ACIFIF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACIFIF_CCB.csv...Please wait...")

                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_ACIFIF] where [ACIFIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    ACIFIF_MDANT = dt.Rows.Item(i).Item("ACIFIF_MDANT") & "|"
                    ACIFIF_ARAID = dt.Rows.Item(i).Item("ACIFIF_ARAID") & "|"
                    ACIFIF_AOAID = dt.Rows.Item(i).Item("ACIFIF_AOAID") & "|"
                    ACIFIF_APRID = dt.Rows.Item(i).Item("ACIFIF_APRID") & "|"
                    ACIFIF_ACTID = dt.Rows.Item(i).Item("ACIFIF_ACTID") & "|"
                    ACIFIF_AINID = dt.Rows.Item(i).Item("ACIFIF_AINID") & "|"
                    ACIFIF_APAVA = dt.Rows.Item(i).Item("ACIFIF_APAVA").ToString.Replace(",", ".") & "|"
                    ACIFIF_APAST = dt.Rows.Item(i).Item("ACIFIF_APAST") & "|"
                    ACIFIF_ASCPS = dt.Rows.Item(i).Item("ACIFIF_ASCPS").ToString.Replace(",", ".") & "|"
                    ACIFIF_ASCST = dt.Rows.Item(i).Item("ACIFIF_ASCST") & "|"
                    ACIFIF_FREI1 = dt.Rows.Item(i).Item("ACIFIF_FREI1") & "|"
                    ACIFIF_FREI2 = dt.Rows.Item(i).Item("ACIFIF_FREI2") & "|"
                    ACIFIF_FREI3 = dt.Rows.Item(i).Item("ACIFIF_FREI3") & "|"
                    ACIFIF_FREI4 = dt.Rows.Item(i).Item("ACIFIF_FREI4") & "|"
                    ACIFIF_FREI5 = dt.Rows.Item(i).Item("ACIFIF_FREI5") & "|"
                    ACIFIF_LOEKZ = dt.Rows.Item(i).Item("ACIFIF_LOEKZ") & "|"
                    ACIFIF_IFNAM = dt.Rows.Item(i).Item("ACIFIF_IFNAM") & "|"
                    ACIFIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACIFIF_DXIFD")) & "|"


                    CSV_ROW =
                        ACIFIF_MDANT &
                        ACIFIF_ARAID &
                        ACIFIF_AOAID &
                        ACIFIF_APRID &
                        ACIFIF_ACTID &
                        ACIFIF_AINID &
                        ACIFIF_APAVA &
                        ACIFIF_APAST &
                        ACIFIF_ASCPS &
                        ACIFIF_ASCST &
                        ACIFIF_FREI1 &
                        ACIFIF_FREI2 &
                        ACIFIF_FREI3 &
                        ACIFIF_FREI4 &
                        ACIFIF_FREI5 &
                        ACIFIF_LOEKZ &
                        ACIFIF_IFNAM &
                        ACIFIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACIFIF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACIFIF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACIFIF_Result = "Not Created"
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File ACIFIF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ACIFIF_Result = "Not Created"
            Exit Sub
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

    End Sub

    Private Sub ACPCIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        'New Code
        Dim CSV_HEADER As String =
            "ACPCIF_MDANT" &
            "|ACPCIF_ARAID" &
            "|ACPCIF_AOAID" &
            "|ACPCIF_APPTP" &
            "|ACPCIF_APPID" &
            "|ACPCIF_APRID" &
            "|ACPCIF_FREI1" &
            "|ACPCIF_FREI2" &
            "|ACPCIF_FREI3" &
            "|ACPCIF_FREI4" &
            "|ACPCIF_FREI5" &
            "|ACPCIF_LOEKZ" &
            "|ACPCIF_IFNAM" &
            "|ACPCIF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACPCIF_MDANT As String = Nothing
        Dim ACPCIF_ARAID As String = Nothing
        Dim ACPCIF_AOAID As String = Nothing
        Dim ACPCIF_APPTP As String = Nothing
        Dim ACPCIF_APPID As String = Nothing
        Dim ACPCIF_APRID As String = Nothing
        Dim ACPCIF_FREI1 As String = Nothing
        Dim ACPCIF_FREI2 As String = Nothing
        Dim ACPCIF_FREI3 As String = Nothing
        Dim ACPCIF_FREI4 As String = Nothing
        Dim ACPCIF_FREI5 As String = Nothing
        Dim ACPCIF_LOEKZ As String = Nothing
        Dim ACPCIF_IFNAM As String = Nothing
        Dim ACPCIF_DXIFD As String = Nothing

        BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACPCIF_CCB.csv")
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACPCIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACPCIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If


        If File.Exists(BaisFilesCreationPath & "ACPCIF_CCB.csv") = True Then
            File.Delete(BaisFilesCreationPath & "ACPCIF_CCB.csv")
        End If
        'Create Header
        System.IO.File.AppendAllText(BaisFilesCreationPath & "ACPCIF_CCB.csv", CSV_HEADER & vbCrLf)

        cmd.CommandText = "Select Count([ID]) from [BAIS_ACPCIF] where [ACPCIF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACPCIF_CCB.csv...Please wait...")

                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_ACPCIF] where [ACPCIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    ACPCIF_MDANT = dt.Rows.Item(i).Item("ACPCIF_MDANT") & "|"
                    ACPCIF_ARAID = dt.Rows.Item(i).Item("ACPCIF_ARAID") & "|"
                    ACPCIF_AOAID = dt.Rows.Item(i).Item("ACPCIF_AOAID") & "|"
                    ACPCIF_APPTP = dt.Rows.Item(i).Item("ACPCIF_APPTP") & "|"
                    ACPCIF_APPID = dt.Rows.Item(i).Item("ACPCIF_APPID") & "|"
                    ACPCIF_APRID = dt.Rows.Item(i).Item("ACPCIF_APRID") & "|"
                    ACPCIF_FREI1 = dt.Rows.Item(i).Item("ACPCIF_FREI1") & "|"
                    ACPCIF_FREI2 = dt.Rows.Item(i).Item("ACPCIF_FREI2") & "|"
                    ACPCIF_FREI3 = dt.Rows.Item(i).Item("ACPCIF_FREI3") & "|"
                    ACPCIF_FREI4 = dt.Rows.Item(i).Item("ACPCIF_FREI4") & "|"
                    ACPCIF_FREI5 = dt.Rows.Item(i).Item("ACPCIF_FREI5") & "|"
                    ACPCIF_LOEKZ = dt.Rows.Item(i).Item("ACPCIF_LOEKZ") & "|"
                    ACPCIF_IFNAM = dt.Rows.Item(i).Item("ACPCIF_IFNAM") & "|"
                    ACPCIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACPCIF_DXIFD")) & "|"


                    CSV_ROW =
                        ACPCIF_MDANT &
                        ACPCIF_ARAID &
                        ACPCIF_AOAID &
                        ACPCIF_APPTP &
                        ACPCIF_APPID &
                        ACPCIF_APRID &
                        ACPCIF_FREI1 &
                        ACPCIF_FREI2 &
                        ACPCIF_FREI3 &
                        ACPCIF_FREI4 &
                        ACPCIF_FREI5 &
                        ACPCIF_LOEKZ &
                        ACPCIF_IFNAM &
                        ACPCIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACPCIF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.ACPCIF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACPCIF_Result = "Not Created"
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File ACPCIF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ACPCIF_Result = "Not Created"
            Exit Sub
        End If

    End Sub

    Private Sub ACPDIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        'New Code
        Dim CSV_HEADER As String =
            "ACPDIF_MDANT" &
            "|ACPDIF_ARAID" &
            "|ACPDIF_AOAID" &
            "|ACPDIF_ACPTP" &
            "|ACPDIF_ACPID" &
            "|ACPDIF_PDPRZ" &
            "|ACPDIF_PDPST" &
            "|ACPDIF_ADFST" &
            "|ACPDIF_AFSST" &
            "|ACPDIF_DXFST" &
            "|ACPDIF_DFSST" &
            "|ACPDIF_FREI1" &
            "|ACPDIF_FREI2" &
            "|ACPDIF_FREI3" &
            "|ACPDIF_FREI4" &
            "|ACPDIF_FREI5" &
            "|ACPDIF_LOEKZ" &
            "|ACPDIF_IFNAM" &
            "|ACPDIF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim ACPDIF_MDANT As String = Nothing
        Dim ACPDIF_ARAID As String = Nothing
        Dim ACPDIF_AOAID As String = Nothing
        Dim ACPDIF_ACPTP As String = Nothing
        Dim ACPDIF_ACPID As String = Nothing
        Dim ACPDIF_PDPRZ As String = Nothing
        Dim ACPDIF_PDPST As String = Nothing
        Dim ACPDIF_ADFST As String = Nothing
        Dim ACPDIF_AFSST As String = Nothing
        Dim ACPDIF_DXFST As String = Nothing
        Dim ACPDIF_DFSST As String = Nothing
        Dim ACPDIF_FREI1 As String = Nothing
        Dim ACPDIF_FREI2 As String = Nothing
        Dim ACPDIF_FREI3 As String = Nothing
        Dim ACPDIF_FREI4 As String = Nothing
        Dim ACPDIF_FREI5 As String = Nothing
        Dim ACPDIF_LOEKZ As String = Nothing
        Dim ACPDIF_IFNAM As String = Nothing
        Dim ACPDIF_DXIFD As String = Nothing

        BgwBaisFilesCreation.ReportProgress(2, "Start creating AnaCredit BAIS File:ACPDIF_CCB.csv")
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD] where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ACPDIF') and [Status] in ('Y') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_ANACREDIT_FILES_V1.35'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_ANACREDIT_FILES_V1.35/ACPDIF/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If



        If File.Exists(BaisFilesCreationPath & "ACPDIF_CCB.csv") = True Then
            File.Delete(BaisFilesCreationPath & "ACPDIF_CCB.csv")
        End If
        'Create Header
        System.IO.File.AppendAllText(BaisFilesCreationPath & "ACPDIF_CCB.csv", CSV_HEADER & vbCrLf)
        '++++++++++++++

        cmd.CommandText = "Select Count([ID]) FROM  [BAIS_ACPDIF] where [ACPDIF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then

            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ACPDIF_CCB.csv...Please wait...")

                Me.QueryText = "SELECT * FROM  [BAIS_ACPDIF] where [ACPDIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    ACPDIF_MDANT = dt.Rows.Item(i).Item("ACPDIF_MDANT") & "|"
                    ACPDIF_ARAID = dt.Rows.Item(i).Item("ACPDIF_ARAID") & "|"
                    ACPDIF_AOAID = dt.Rows.Item(i).Item("ACPDIF_AOAID") & "|"
                    ACPDIF_ACPTP = dt.Rows.Item(i).Item("ACPDIF_ACPTP") & "|"
                    ACPDIF_ACPID = dt.Rows.Item(i).Item("ACPDIF_ACPID") & "|"
                    ACPDIF_PDPRZ = dt.Rows.Item(i).Item("ACPDIF_PDPRZ").ToString.Replace(",", ".") & "|"
                    ACPDIF_PDPST = dt.Rows.Item(i).Item("ACPDIF_PDPST") & "|"
                    ACPDIF_ADFST = dt.Rows.Item(i).Item("ACPDIF_ADFST") & "|"
                    ACPDIF_AFSST = dt.Rows.Item(i).Item("ACPDIF_AFSST") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ACPDIF_DXFST")) = False Then
                        Dim ACPDIF_DXFST_Date As Date = dt.Rows.Item(i).Item("ACPDIF_DXFST")
                        ACPDIF_DXFST = ACPDIF_DXFST_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ACPDIF_DXFST = "0" & "|"
                    End If
                    ACPDIF_DFSST = dt.Rows.Item(i).Item("ACPDIF_DFSST") & "|"
                    ACPDIF_FREI1 = dt.Rows.Item(i).Item("ACPDIF_FREI1") & "|"
                    ACPDIF_FREI2 = dt.Rows.Item(i).Item("ACPDIF_FREI2") & "|"
                    ACPDIF_FREI3 = dt.Rows.Item(i).Item("ACPDIF_FREI3") & "|"
                    ACPDIF_FREI4 = dt.Rows.Item(i).Item("ACPDIF_FREI4") & "|"
                    ACPDIF_FREI5 = dt.Rows.Item(i).Item("ACPDIF_FREI5") & "|"
                    ACPDIF_LOEKZ = dt.Rows.Item(i).Item("ACPDIF_LOEKZ") & "|"
                    ACPDIF_IFNAM = dt.Rows.Item(i).Item("ACPDIF_IFNAM") & "|"
                    ACPDIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ACPDIF_DXIFD")) & "|"



                    CSV_ROW =
                        ACPDIF_MDANT &
                        ACPDIF_ARAID &
                        ACPDIF_AOAID &
                        ACPDIF_ACPTP &
                        ACPDIF_ACPID &
                        ACPDIF_PDPRZ &
                        ACPDIF_PDPST &
                        ACPDIF_ADFST &
                        ACPDIF_AFSST &
                        ACPDIF_DXFST &
                        ACPDIF_DFSST &
                        ACPDIF_FREI1 &
                        ACPDIF_FREI2 &
                        ACPDIF_FREI3 &
                        ACPDIF_FREI4 &
                        ACPDIF_FREI5 &
                        ACPDIF_LOEKZ &
                        ACPDIF_IFNAM &
                        ACPDIF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ACPDIF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACPDIF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.ACPDIF_Result = "Not Created"
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.ACPDIF_Result = "Not Created"
            XtraMessageBox.Show("Unable to create File ACPDIF_CCB.csv for " & rd, "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


    End Sub


    Private Function ColorForRichTextBoxLine(Line As String) As Color
        If Line.Contains("created successfully") Then
            Return Color.DarkGreen
        End If
        If Line.Contains("NOT CREATED") Then
            Return Color.DarkRed
        End If
        If Line.StartsWith("File(s) zipped in BAIS_Files") Then
            Return Color.Navy
        End If
    End Function




    Private Sub CheckAll_btn_Click(sender As Object, e As EventArgs) Handles CheckAll_btn.Click
        For Each ctrl As Control In Me.GroupControl1.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit Then
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Checked
            End If
        Next
    End Sub

#Region " Scrollbar Info "

    Public Class ScrollBarInfo

        <System.Runtime.InteropServices.DllImport("user32")> _
        Private Shared Function GetScrollInfo(hwnd As IntPtr, nBar As Integer, ByRef scrollInfo As SCROLLINFO) As Integer
        End Function

        Private Shared scrollInf As New SCROLLINFO

        Private Structure SCROLLINFO
            Public cbSize As Integer
            Public fMask As Integer
            Public min As Integer
            Public max As Integer
            Public nPage As Integer
            Public nPos As Integer
            Public nTrackPos As Integer
        End Structure

        Private Shared Sub Get_ScrollInfo(control As Control)
            scrollInf = New SCROLLINFO()
            scrollInf.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(scrollInf)
            scrollInf.fMask = &H10 Or &H1 Or &H2 'SIF_RANGE = &H1, SIF_PAGE= &H2, SIF_TRACKPOS = &H10
            GetScrollInfo(control.Handle, 1, scrollInf)
        End Sub

        ' IsAtBottom
        Public Shared Function IsAtBottom(control As Control) As Boolean
            Get_ScrollInfo(control)
            Return scrollInf.max = (scrollInf.nTrackPos + scrollInf.nPage) - 1
        End Function

        ' IsAtTop
        Public Shared Function IsAtTop(control As Control) As Boolean
            Get_ScrollInfo(control)
            Return scrollInf.nTrackPos = 0
        End Function

        ' ReachedBottom
        Public Shared Function ReachedBottom(control As Control) As Boolean
            Get_ScrollInfo(control)
            Return scrollInf.max = scrollInf.nTrackPos + scrollInf.nPage
        End Function

        ' ReachedTop
        Public Shared Function ReachedTop(control As Control) As Boolean
            Get_ScrollInfo(control)
            Return scrollInf.nTrackPos < 0
        End Function

    End Class

#End Region



    Public Shared Sub ChangeTextcolor(textToMark As String, color As Color, richTextBox As RichTextBox, startIndex As Integer)
        If startIndex < 0 OrElse startIndex > textToMark.Length - 1 Then
            startIndex = 0
        End If

        Dim newFont As System.Drawing.Font = New Font("Verdana", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, False)
        Try
            For Each line As String In richTextBox.Lines
                If line.Contains(textToMark) Then
                    richTextBox.[Select](startIndex, line.Length)
                    richTextBox.SelectionColor = color
                End If
                startIndex += line.Length + 1
            Next
        Catch
        End Try
    End Sub

    Private Sub OpenFolder_btn_Click(sender As Object, e As EventArgs) Handles OpenFolder_btn.Click
        If Directory.Exists(BaisFilesCreationPath) Then
            System.Diagnostics.Process.Start(BaisFilesCreationPath)
        Else
            XtraMessageBox.Show("Unable to open creation Folder!", "CREATION FOLDER DOES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

  
    Private Sub AnaCreditChecks_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AnaCreditChecks_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub AnaCreditChecks_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AnaCreditChecks_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
End Class