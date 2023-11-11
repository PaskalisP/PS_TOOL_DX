Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mail
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
Imports CrystalDecisions.CrystalReports.Engine
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Reflection

Public Class DailyEmail

    Dim CrystalRepDir As String = ""
    Dim EmailVersion As String = Nothing
    Dim ReportExpFile As String = "" 'Directory for the report creation REFINANCING_MATURITY_LIST
    Dim ReportExpRefiFile As String = ""

    Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem

    Dim newCulture As System.Globalization.CultureInfo
    Dim OldCulture As System.Globalization.CultureInfo

    'Dim pkg As New Microsoft.SqlServer.Dts.Runtime.Package
    'Dim app As New Microsoft.SqlServer.Dts.Runtime.Application
    'Dim pkgResults As Microsoft.SqlServer.Dts.Runtime.DTSExecResult
    Dim SSISDirectory As String = Nothing


    Dim CBAIF As Double = Nothing 'CurrentImportBAISFile
    Dim LBAIF As Double = Nothing ' LastImportedBAISFile
    Dim COIFN As String = ""
    Dim CURRENT_PROC As String = Nothing
    Dim ACTIVE_PROC As String = ""

    Delegate Sub ChangeText()

    Private BS_All_BusinessDates As BindingSource

    Dim MaxProcDate As Date

    Const TabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
    Const TabelleEnde As String = "</TABLE></BODY></HTML>"
    Const ZelleStart As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"">"
    Const ZelleStartBackgroundBlue As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"" bgcolor=""#2B3856"">"
    Const ZelleStartZahl As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
    Const ZelleStartResult As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
    Const ZelleEnde As String = "</TD>"

    Const ZweiteTabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
    Const ZweiteTabelleEnde As String = "</TABLE></BODY></HTML>"



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
    Private Sub IMPORT_EVENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.IMPORT_EVENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

#Region "GRIDVIEWS_DEFAULT_SETTINGS"

    Private Sub Print_Export_EmailEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_EmailEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
        Dim reportfooter As String = "DAILY EMAIL CREATION EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
#End Region


    Private Sub DailyEmail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwDailyRiskEmail.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub DailyEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.EmailCreationDate_SearchLookUpEdit.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        'Get EMAIL Current Version
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='EMAIL_GM' and PARAMETER1 in ('EMAIL_GM_CURRENT_VERSION') and [PARAMETER STATUS]='Y'"
        EmailVersion = cmd.ExecuteScalar
        EmailVersion_TextEdit.Text = EmailVersion
        'Me.EmailCreationDate_SearchLookUpEdit.Properties.Buttons.Item(1).Caption = "Create Email - " & EmailVersion
        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        MaxProcDate = cmd.ExecuteScalar
        CloseSqlConnections()
        '***********************************************************************

        Me.To_MemoEdit.Properties.ReadOnly = True
        Me.CC_MemoEdit.Properties.ReadOnly = True
        Me.BCC_MemoEdit.Properties.ReadOnly = True

        'GET THE EMAIL RECEIVERS_TO
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_TO As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_TO += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.To_MemoEdit.Text = EMAIL_TO
        dt.Reset()

        'GET THE EMAIL RECEIVERS_CC
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_CC'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_CC As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.CC_MemoEdit.Text = EMAIL_CC
        dt.Reset()

        'GET THE EMAIL RECEIVERS_BCC
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_BCC'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_BCC As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_BCC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.BCC_MemoEdit.Text = EMAIL_BCC
        dt.Reset()

        Me.IMPORT_EVENTSTableAdapter.FillByDAILYRISKEMAILDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT Convert(varchar(10),[RLDC Date],104)
                                                    FROM    [RISK LIMIT DAILY CONTROL] where [RiskBearingCapacityCashPledge]<>0 ORDER BY [RLDC Date] desc
                                                    SELECT BUSINESS_DATE  from @SELECTION_TABLE 
                                                    order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "BUSINESS_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_BusinessDates = New BindingSource(ds, "BUSINESS_DATE")
    End Sub
    Private Sub ALL_BUSINESS_DATES_InitLookUp()
        Me.EmailCreationDate_SearchLookUpEdit.Properties.DataSource = BS_All_BusinessDates
        Me.EmailCreationDate_SearchLookUpEdit.Properties.DisplayMember = "BUSINESS_DATE"
        Me.EmailCreationDate_SearchLookUpEdit.Properties.ValueMember = "BUSINESS_DATE"
    End Sub


    Private Sub EmailCreationDate_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles EmailCreationDate_SearchLookUpEdit.EditValueChanged
        If EmailCreationDate_SearchLookUpEdit.Text <> "" Then
            Me.Subject_TextEdit.Text = "DAILY RISK CONTROL OVERVIEW on " & Me.EmailCreationDate_SearchLookUpEdit.Text
        End If
    End Sub

    Private Sub EmailCreationDate_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EmailCreationDate_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 1 Then
            rd = Me.EmailCreationDate_SearchLookUpEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            OpenSqlConnections()
            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_GM' and [IdABTEILUNGSCODE]='REPORT'"
            Dim EMAIL_STATUS As String = cmd.ExecuteScalar
            If EMAIL_STATUS = "Y" Then
                If XtraMessageBox.Show("Should the daily Risk Overview E-Mail for Business date: " & Me.EmailCreationDate_SearchLookUpEdit.Text & " be generated?", "DAILY RISK OVERVIEW EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('OCBS')"
                    Dim CheckText As String = cmd.ExecuteScalar

                    Dim CheckDate As Date = DateSerial(Microsoft.VisualBasic.Left(CheckText, 4), Microsoft.VisualBasic.Mid(CheckText, 5, 2), Microsoft.VisualBasic.Right(CheckText, 2))
                    Dim CheckEmailCreationDate As Date = Me.EmailCreationDate_SearchLookUpEdit.Text

                    If CheckDate <> CheckEmailCreationDate Then
                        If XtraMessageBox.Show("The Email Creation Date differs from the last NGS import Date!" & vbNewLine & " Should the daily Risk Overview E-Mail be generated?", "DAILY RISK OVERVIEW EMAIL - DATES ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            If Me.BgwDailyRiskEmail.IsBusy = False Then
                                Me.Subject_TextEdit.Text = "DAILY RISK CONTROL OVERVIEW on " & Me.EmailCreationDate_SearchLookUpEdit.Text
                                Me.EMAILProgressBar.Visible = True
                                Me.EMAILProgressBar.Value = 0
                                Me.EmailCreationDate_SearchLookUpEdit.Enabled = False
                                Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
                                Me.BgwDailyRiskEmail.RunWorkerAsync()
                            End If
                        Else
                            Exit Sub
                        End If
                    ElseIf CheckDate = CheckEmailCreationDate Then
                        If Me.BgwDailyRiskEmail.IsBusy = False Then
                            Me.Subject_TextEdit.Text = "DAILY RISK CONTROL OVERVIEW on " & Me.EmailCreationDate_SearchLookUpEdit.Text
                            Me.EMAILProgressBar.Visible = True
                            Me.EMAILProgressBar.Value = 0
                            Me.EmailCreationDate_SearchLookUpEdit.Enabled = False
                            Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
                            Me.BgwDailyRiskEmail.RunWorkerAsync()
                        End If
                    End If

                Else
                    Exit Sub

                End If

            Else
                XtraMessageBox.Show("The generation of the daily Risk E-mail is set to INVALID", "EMAIL GENERATION NOT POSSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub


    Private Sub BgwDailyRiskEmail_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwDailyRiskEmail.DoWork
        Try
            CurrentSystemExecuting = "DAILY RISK EMAIL"
            CurrentProcedureName = EmailVersion
            OpenSqlConnections()
            Me.BgwDailyRiskEmail.ReportProgress(1, "Start Daily Risk Control E-Mail creation for Business Date " & Me.EmailCreationDate_SearchLookUpEdit.Text)
            Me.BgwDailyRiskEmail.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/EMAIL_GM_VERSIONS/" & EmailVersion)
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and [Id_SQL_Parameters_Details] 
                                in (Select ID from [SQL_PARAMETER_DETAILS] where SQL_Name_1 in ('" & EmailVersion & "')) order by SQL_Float_1 asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.BgwDailyRiskEmail.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/EMAIL_GM_VERSIONS/" & EmailVersion)
                For i = 0 To dt.Rows.Count - 1
                    If Me.BgwDailyRiskEmail.CancellationPending = False Then
                        FlushMemory()
                        ScriptType = dt.Rows.Item(i).Item("SQL_ScriptType_1").ToString
                        If ScriptType = "SQL" Then
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText
                            Me.BgwDailyRiskEmail.ReportProgress(i, dt.Rows.Item(i).Item("SQL_Name_1") & " - Nr.: " & dt.Rows.Item(i).Item("SQL_Float_1").ToString)
                            cmd.ExecuteNonQuery()
                        ElseIf ScriptType = "VB" Then
                            Dim code As String = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                            Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                            Dim entry As String = "VB_ScriptForExecution"
                            If code = "" Then Return
                            If entry = "" Then entry = "VB_ScriptForExecution"
                            Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                            Me.BgwDailyRiskEmail.ReportProgress(i, dt.Rows.Item(i).Item("SQL_Name_1") & " - Nr.: " & dt.Rows.Item(i).Item("SQL_Float_1").ToString)
                            engine.Run()
                        End If
                    ElseIf Me.BgwDailyRiskEmail.CancellationPending = True Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
            Else
                Me.BgwDailyRiskEmail.ReportProgress(50, "No valid parameters found from SQL PARAMETERS/EMAIL_GM_VERSIONS/" & EmailVersion)
                Exit Sub
            End If

        Catch ex As TargetInvocationException
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(ex.Message & vbNewLine & ex.InnerException.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwDailyRiskEmail.CancelAsync()
            CloseSqlConnections()

        Catch ex As System.Exception
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.BgwDailyRiskEmail.CancelAsync()
            CloseSqlConnections()
        Finally
            Me.BgwDailyRiskEmail.CancelAsync()
        End Try



    End Sub

    Private Sub BgwDailyRiskEmail_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwDailyRiskEmail.ProgressChanged

        Me.EMAILProgressBar.Value = e.ProgressPercentage
        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('" & e.UserState & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & EmailVersion & "','DAILY RISK EMAIL')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & EmailVersion & "','DAILY RISK EMAIL')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        CloseEVENT_SqlConnection()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByDAILYRISKEMAILDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwDailyRiskEmail_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwDailyRiskEmail.RunWorkerCompleted
        CloseSqlConnections()
        Me.EMAILProgressBar.Visible = False
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
        Me.EmailCreationDate_SearchLookUpEdit.Enabled = True

    End Sub


End Class