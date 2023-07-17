Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
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
'Imports Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet
Imports System.Diagnostics
Imports System.Collections.Generic
Imports DevExpress.Compression
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Tar
Imports ICSharpCode.SharpZipLib.Core


Public Class RunClient


    'Dim excel As Microsoft.Office.Interop.Excel.Application
    'Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem


    Dim RunClient_btn_clicked As Boolean = False 'Button for Start Client
    Dim RunClientManual_btn_clicked As Boolean = False 'Button for Manual Start Client

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

    Dim PSTOOL_Client_FileImport_NewDirectory As String = Nothing 'NEW DIRECTORY FOR PSTOOL CLIENT IMPORTS
    Dim CURRENT_PROC As String = Nothing
    Private BS_All_BusinessDates As BindingSource
    Dim CurDate As Date = Today
    Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")
    Dim ID_Selected As Integer = 0
    Dim GetFocusedRow As Integer = 0
    Private ConvertWorkbook As IWorkbook


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


    Private Sub RunClient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwClientRun.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub RunClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.ClientDateFrom_Comboedit.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString
        Me.ClientDateTill_Comboedit.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString

        'Get Max Date
        OpenSqlConnections()
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [CLIENT EVENTS]"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            MaxProcDate = cmd.ExecuteScalar
        Else
            MaxProcDate = DateSerial(2014, 9, 30)
        End If
        CloseSqlConnections()

        Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
        Me.CLIENT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.CLIENT_EVENTS, MaxProcDate)

    End Sub

    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT Convert(varchar(10),[RLDC Date],104)
                                                    FROM    [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' and [PL Result] is not NULL and [Client_Lock]=0 ORDER BY [RLDC Date] desc
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
        Me.ClientDateFrom_Comboedit.Properties.DataSource = BS_All_BusinessDates
        Me.ClientDateFrom_Comboedit.Properties.DisplayMember = "BUSINESS_DATE"
        Me.ClientDateFrom_Comboedit.Properties.ValueMember = "BUSINESS_DATE"

        Me.ClientDateTill_Comboedit.Properties.DataSource = BS_All_BusinessDates
        Me.ClientDateTill_Comboedit.Properties.DisplayMember = "BUSINESS_DATE"
        Me.ClientDateTill_Comboedit.Properties.ValueMember = "BUSINESS_DATE"

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        'Add new Procedure
        If e.Button.Tag = "AddProc" Then
            Try
                Me.PSTOOLCLIENTPROCEDURESBindingSource.EndEdit()
                Me.OcbsImportProcedures_BasicView.AddNewRow()
                Me.OcbsImportProcedures_BasicView.ShowEditForm()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on add new Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Add delete Procedure
        If e.Button.Tag = "DeleteProc" Then
            If XtraMessageBox.Show(CType("Should the Procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be deleted? ", String), "DELETE PROCEDURE", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete Procedure")
                    OpenSqlConnections()
                    cmd.CommandText = "DELETE FROM [PSTOOL_CLIENT_PROCEDURES] where ID=" & ID_Selected & ""
                    cmd.ExecuteNonQuery()
                    'Reset LfdNr
                    cmd.CommandText = "UPDATE A SET A.LfdNr=B.rn from [PSTOOL_CLIENT_PROCEDURES] A INNER JOIN 
                                       (SELECT row_number() over (order by LfdNr asc) as rn,ID
                                       from  [PSTOOL_CLIENT_PROCEDURES])B On A.ID=B.ID"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
        End If

        'Add delete Procedure
        If e.Button.Tag = "Reload" Then

            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Reload procedures")
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try

        End If


        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.PSTOOLCLIENTPROCEDURESBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.PSTOOLCLIENTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Activate all Procedures
        If e.Button.Tag = "ActivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current mandatory Procedures be activated", "ACTIVATE CURRENT MANDATORY PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [PSTOOL_CLIENT_PROCEDURES] SET [Valid]='Y' where [Importance] in ('MANDATORY')"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Activate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.PSTOOLCLIENTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Deactivate all Procedures
        If e.Button.Tag = "DeactivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current Procedures be Deactivated", "DEACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [PSTOOL_CLIENT_PROCEDURES] SET [Valid]='N'"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Deactivate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.PSTOOLCLIENTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                Exit Sub
            End Try
        End If
        'Terminate Client Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwClientRun.IsBusy = True Then
                If XtraMessageBox.Show("Should the executed PS TOOL Client procedures be terminated?", "TERMINATE CLIENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwClientRun.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("PS TOOL Client procedures termination is requested..." & vbNewLine & "Please wait until the current procedure operations are finished!")
                End If
            End If
        End If

    End Sub

    Public Sub ExtractTGZ(ByVal gzArchiveName As String, ByVal destFolder As String)

        Dim inStream As Stream = File.OpenRead(gzArchiveName)
        Dim gzipStream As Stream = New GZipInputStream(inStream)

        Dim tarArchive As TarArchive = tarArchive.CreateInputTarArchive(gzipStream)
        tarArchive.ExtractContents(destFolder)
        tarArchive.Close()

        gzipStream.Close()
        inStream.Close()
    End Sub

    Private Sub RunClient_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
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
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
            ' Check whether the GridControl can be previewed. 
            If Not Me.GridControl1.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
                Return
            End If
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 1 Then
            ' Check whether the GridControl can be previewed. 
            If Not Me.GridControl2.IsPrintingAvailable Then
                XtraMessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
                Return
            End If
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink2.CreateDocument()
                PrintableComponentLink2.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
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
        Dim reportfooter As String = "PS TOOL CLIENT PROCEDURES"
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
        Dim reportfooter As String = "CLIENT EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub StartClient_btn_Click(sender As Object, e As EventArgs) Handles StartClient_btn.Click

        If OutstandingNewCustomerAlert = 0 AndAlso OutstandingRatingAlert = 0 Then
            If IsDate(Me.ClientDateFrom_Comboedit.Text) = True Then
                If XtraMessageBox.Show("Should the PS TOOL Client be started?", "START PS TOOL Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    RunClient_btn_clicked = True
                    RunClientManual_btn_clicked = False
                    DISABLE_START_IMPORT()
                    If Me.BgwClientRun.IsBusy = False Then
                        Me.BgwClientRun.RunWorkerAsync()
                    End If
                End If
            End If
        Else
            XtraMessageBox.Show("Unable to proceed with the PS TOOL Client execution" & vbNewLine & "since Alert messages are displayed!" & vbNewLine & "Please respond to the displayed Alert messages!!", "PS TOOL Client stopped!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
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
        CurrentSystemExecuting = "PS TOOL CLIENT"
        If RunClient_btn_clicked = True Then
            Try
                CURRENT_PROC = "PS_TOOL_CLIENT_ACTIONS"
                'Get  temporary directory
                Me.BgwClientRun.ReportProgress(10, "Locate the PS TOOL Client import Temp Directory")
                OpenSqlConnections()
                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                CloseSqlConnections()

                If Me.ClientDateFrom_Comboedit.Text <> "" And Me.ClientDateTill_Comboedit.Text <> "" Then
                    Dim d1 As Date = Me.ClientDateFrom_Comboedit.Text
                    Dim sqld1 As String = d1.ToString("yyyyMMdd")
                    Dim d2 As Date = Me.ClientDateTill_Comboedit.Text
                    Dim sqld2 As String = d2.ToString("yyyyMMdd")
                    If d2 >= d1 Then

                        Try
                            OpenSqlConnections()
                            'Select all requested Dates
                            Me.BgwClientRun.ReportProgress(1, "Select all required Business Dates to run the Client")
                            QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where [RLDC Date] BETWEEN '" & sqld1 & "' and '" & sqld2 & "' and [Client_Lock]=0 ORDER BY [RLDC Date] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                rd = row("RLDC Date")
                                rdsql = rd.ToString("yyyyMMdd")
                                If Me.BgwClientRun.CancellationPending = False Then

                                    Me.BgwClientRun.ReportProgress(50, "Starting PS TOOL Client for Business Date: " & rd.ToString("dd.MM.yyyy"))

                                    PSTOOL_CLIENT_PROCEDURES_EXECUTION()

                                    Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for Business Date: " & rd.ToString("dd.MM.yyyy") & " is finished!")

                                ElseIf Me.BgwClientRun.CancellationPending = True Then
                                    Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for Business Date: " & rd.ToString("dd.MM.yyyy") & " is terminated after user request!")
                                    e.Cancel = True

                                    'MessageBox.Show("PS TOOL Client is terminated!", "PS TOOL Client termination", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                End If


                            Next

                            CloseSqlConnections()


                        Catch ex As Exception
                            Me.BgwClientRun.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
                            CloseSqlConnections()
                        End Try

                    End If
                End If
            Catch ex As System.Exception
                Me.BgwClientRun.ReportProgress(0, "ERROR +++PS TOOL Client Procedures for Business Date:" & " " & rd.ToString("dd.MM.yyyy") & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwClientRun.CancelAsync()
                If Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) = True Then
                    Directory.Delete(PSTOOL_Client_FileImport_NewDirectory, True)
                End If
            End Try
        End If

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        If RunClientManual_btn_clicked = True Then
            Try
                CURRENT_PROC = "PS_TOOL_CLIENT_ACTIONS"
                'Get  temporary directory
                Me.BgwClientRun.ReportProgress(10, "Locate the PS TOOL Client import Temp Directory")
                OpenSqlConnections()
                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                CloseSqlConnections()

                Try
                    OpenSqlConnections()
                    'Select all requested Dates
                    Me.BgwClientRun.ReportProgress(1, "Select the required Business Date to run the Client")
                    QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]= '" & rdsql & "' and [Client_Lock]=0"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        If Me.BgwClientRun.CancellationPending = False Then
                            Me.BgwClientRun.ReportProgress(50, "Starting PS TOOL Client for Business Date: " & rd.ToString("dd.MM.yyyy"))

                            PSTOOL_CLIENT_PROCEDURES_EXECUTION_MANUAL()

                            Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for Business Date: " & rd.ToString("dd.MM.yyyy") & " is finished!")

                        ElseIf Me.BgwClientRun.CancellationPending = True Then
                            Me.BgwClientRun.ReportProgress(100, "PS TOOL Client run for Business Date: " & rd.ToString("dd.MM.yyyy") & " is terminated after user request!")
                            e.Cancel = True



                        End If
                    Else
                        XtraMessageBox.Show("The selected Business Date: " & rd & " not fund in RISK LIMIT DAILY CONTROL Table!", "PS TOOL Client is terminated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If


                    CloseSqlConnections()


                Catch ex As Exception
                    Me.BgwClientRun.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
                    CloseSqlConnections()
                End Try

            Catch ex As System.Exception
                Me.BgwClientRun.ReportProgress(0, "ERROR +++PS TOOL Client Procedures for Business Date:" & " " & rd.ToString("dd.MM.yyyy") & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwClientRun.CancelAsync()
                If Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) = True Then
                    Directory.Delete(PSTOOL_Client_FileImport_NewDirectory, True)
                End If
            End Try
        End If



    End Sub

    Private Sub BgwClientRun_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwClientRun.ProgressChanged
        Dim ClientEvent As String = e.UserState
        Me.ClientProgressBar.Value = e.ProgressPercentage

        Dim stackFrame As New Diagnostics.StackFrame()
        Dim rtnName As String = stackFrame.GetMethod.Name.ToString()
        rtnName = rtnName & stackFrame.GetMethod.DeclaringType.FullName.ToString()

        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName])
                                    Values('" & ClientEvent & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName])
                                    Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [CLIENT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        CloseEVENT_SqlConnection()
        'See events
        Me.CLIENT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.CLIENT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwClientRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwClientRun.RunWorkerCompleted
        CurrentSystemExecuting = Nothing
        Me.LayoutControlGroup2.Visibility = LayoutVisibility.Always
        ENABLE_FINISH_IMPORT()

        'Set Button Click as default to False
        RunClient_btn_clicked = False
        RunClientManual_btn_clicked = False

        CloseSqlConnections()



    End Sub


#Region "MANUAL IMPORTS FROM BUTTON"

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
        'e.Form.CancelButton.DialogResult = DialogResult.None
        e.Form.CloseBox = False
        If e.Form.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        If e.Form.DialogResult = DialogResult.OK Then
            Exit Sub
        End If
    End Sub

    Private Sub StartImport_RepositoryItemButtonEdit_Click(sender As Object, e As EventArgs) Handles StartImport_RepositoryItemButtonEdit.Click

        If OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colValid) = "Y" Then
            If OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colRequestBusinessDate) = "Y" Then
                ' initialize a new XtraInputBoxArgs instance
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the Business Date for the procedure execution"
                args.Prompt = "Business Date"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim editor As New DateEdit()
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
                editor.Properties.Mask.EditMask = "dd.MM.yyyy"
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rd = CDate(obj)
                    rdsql = rd.ToString("yyyyMMdd")

                    If OutstandingNewCustomerAlert = 0 AndAlso OutstandingRatingAlert = 0 Then
                        If XtraMessageBox.Show("Should the client procedure: " & OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) & " be executed for Business Date: " & rd & " ?" & vbNewLine & vbNewLine & "ATTENTION: IT IS HIGHLY RECOMENDED NOT TO EXECUTE A SINGLE CLIENT PROCEDURE!", "Start manual client procedure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            RunClient_btn_clicked = False
                            RunClientManual_btn_clicked = True
                            Me.LayoutControlGroup2.Visibility = LayoutVisibility.Never
                            DISABLE_START_IMPORT()
                            If Me.BgwClientRun.IsBusy = False Then
                                Me.BgwClientRun.RunWorkerAsync()
                            End If
                        End If

                    Else
                        XtraMessageBox.Show("Unable to proceed with the PS TOOL Client execution" & vbNewLine & "since Alert messages are displayed!" & vbNewLine & "Please respond to the displayed Alert messages!!", "PS TOOL Client stopped!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return

                    End If


                End If
            Else
                Return
            End If

        Else
            XtraMessageBox.Show("The selected procedure is not valid!" & vbNewLine & "Please change the Status of this procedure!", "PROCEDURE NOT VALID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return

        End If ' Request Business Date



    End Sub


#End Region

    Private Sub PSTOOL_CLIENT_PROCEDURES_EXECUTION()
        Me.BgwClientRun.ReportProgress(50, "Select all valid Client procedures with execution plan: ALWAYS and ONLY IN APP")
        QueryText = "SELECT * FROM [PSTOOL_CLIENT_PROCEDURES] where [Valid] in ('Y') and ExecutionPlan in ('ALWAYS','ONLY_IN_APP') ORDER BY [LfdNr] asc"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for Business date: " & rd.ToString("dd.MM.yyyy")
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwClientRun.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/PS TOOL CLIENT PROCEDURES")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwClientRun.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/PS TOOL CLIENT PROCEDURES")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        If Not Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) Then
                            Directory.CreateDirectory(PSTOOL_Client_FileImport_NewDirectory)
                        ElseIf Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) Then
                            Directory.Delete(PSTOOL_Client_FileImport_NewDirectory, True)
                            Directory.CreateDirectory(PSTOOL_Client_FileImport_NewDirectory)
                        End If
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", rdsql.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", rdsql.ToString)
                        Me.BgwClientRun.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwClientRun.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(PSTOOL_Client_FileImport_NewDirectory, True)
                                                Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & PSTOOL_Client_FileImport_NewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a tar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, PSTOOL_Client_FileImport_NewDirectory)
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & PSTOOL_Client_FileImport_NewDirectory)
                                Else
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            Else
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an recognited as archive file")
                                Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            PSTOOL_Client_FileImport_NewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                            PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                            Me.BgwClientRun.ReportProgress(50, "Set Import directory to:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                            Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                            File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(PSTOOL_Client_FileImport_NewDirectory & "\", FileNameImport), True)

                        End If
                        'Set correct directory format for the imported files
                        PSTOOL_Client_FileImport_NewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                        Me.BgwClientRun.ReportProgress(50, "Set Import directory to:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                        PSTOOL_Client_FileImport_NewDirectory = PSTOOL_Client_FileImport_NewDirectory & "\"


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            Select Case FileConvertion
                                Case = "XLS_TO_XLSX"
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                        Me.BgwClientRun.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(PSTOOL_Client_FileImport_NewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                        Me.BgwClientRun.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                                Case = "CSV_TO_XLSX"
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                        Me.BgwClientRun.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(PSTOOL_Client_FileImport_NewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                        Me.BgwClientRun.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                            End Select
                        End If

                        'Start checking and executing SQL Parameters
                        Me.BgwClientRun.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwClientRun.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = PSTOOL_Client_FileImport_NewDirectory & FileNameImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwClientRun.ReportProgress(50, "No valid parameters found from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwClientRun.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwClientRun.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwClientRun.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwClientRun.ReportProgress(50, "No valid parameters found from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwClientRun.ReportProgress(50, "Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/NGS_IMPORTS")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "PS_TOOL_CLIENT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            Next
        End If
    End Sub

    Private Sub PSTOOL_CLIENT_PROCEDURES_EXECUTION_MANUAL()
        Me.BgwClientRun.ReportProgress(50, "Select the relevant procedure")
        QueryText = "SELECT * FROM [PSTOOL_CLIENT_PROCEDURES] where ID=" & ID_Selected & " and [Valid] in ('Y')"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for Business date: " & rd.ToString("dd.MM.yyyy")
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwClientRun.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/PS TOOL CLIENT PROCEDURES")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwClientRun.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/PS TOOL CLIENT PROCEDURES")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        If Not Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) Then
                            Directory.CreateDirectory(PSTOOL_Client_FileImport_NewDirectory)
                        ElseIf Directory.Exists(PSTOOL_Client_FileImport_NewDirectory) Then
                            Directory.Delete(PSTOOL_Client_FileImport_NewDirectory, True)
                            Directory.CreateDirectory(PSTOOL_Client_FileImport_NewDirectory)
                        End If
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", rdsql.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", rdsql.ToString)
                        Me.BgwClientRun.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwClientRun.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(PSTOOL_Client_FileImport_NewDirectory, True)
                                                Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & PSTOOL_Client_FileImport_NewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a tar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, PSTOOL_Client_FileImport_NewDirectory)
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & PSTOOL_Client_FileImport_NewDirectory)
                                Else
                                    Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            Else
                                Me.BgwClientRun.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an recognited as archive file")
                                Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            PSTOOL_Client_FileImport_NewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                            PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                            Me.BgwClientRun.ReportProgress(50, "Set Import directory to:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                            Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                            File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(PSTOOL_Client_FileImport_NewDirectory & "\", FileNameImport), True)

                        End If
                        'Set correct directory format for the imported files
                        PSTOOL_Client_FileImport_NewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='PSTOOL_CLIENT_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        PSTOOL_Client_FileImport_NewDirectory = cmd.ExecuteScalar()
                        Me.BgwClientRun.ReportProgress(50, "Set Import directory to:" & PSTOOL_Client_FileImport_NewDirectory & "\")
                        PSTOOL_Client_FileImport_NewDirectory = PSTOOL_Client_FileImport_NewDirectory & "\"


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            Select Case FileConvertion
                                Case = "XLS_TO_XLSX"
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                        Me.BgwClientRun.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(PSTOOL_Client_FileImport_NewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                        Me.BgwClientRun.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                                Case = "CSV_TO_XLSX"
                                    Me.BgwClientRun.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                        Me.BgwClientRun.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(PSTOOL_Client_FileImport_NewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(PSTOOL_Client_FileImport_NewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                        Me.BgwClientRun.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                            End Select
                        End If

                        'Start checking and executing SQL Parameters
                        Me.BgwClientRun.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwClientRun.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = PSTOOL_Client_FileImport_NewDirectory & FileNameImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwClientRun.ReportProgress(50, "No valid parameters found from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwClientRun.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwClientRun.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwClientRun.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwClientRun.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwClientRun.ReportProgress(50, "No valid parameters found from SQL PARAMETERS/PS TOOL CLIENT PROCEDURES/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwClientRun.ReportProgress(50, "Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/NGS_IMPORTS")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "PS_TOOL_CLIENT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            Next
        End If
    End Sub

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

    Private Sub OcbsImportProcedures_BasicView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles OcbsImportProcedures_BasicView.EditFormPrepared
        'Dim view As GridView = TryCast(sender, GridView)
        'CurrentImportProcedureTextEdit = TryCast(e.BindableControls(colProcName), TextEdit)

        If e.BindableControls(OcbsImportProcedures_BasicView.FocusedColumn) IsNot Nothing Then
            e.FocusField(OcbsImportProcedures_BasicView.FocusedColumn)
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles OcbsImportProcedures_BasicView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        Me.GridControl1.EmbeddedNavigator.Buttons.DoClick(Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit)
    End Sub

    Private Sub OcbsImportProcedures_BasicView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles OcbsImportProcedures_BasicView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ExectutionType"), "SCRIPT")
        view.SetRowCellValue(e.RowHandle, view.Columns("ExecutionPlan"), "ALWAYS")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileExtraction"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("RequestBusinessDate"), "Y")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileConvertion"), "N")
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles OcbsImportProcedures_BasicView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentDataView As DataView = TryCast((TryCast(sender, GridView)).DataSource, DataView)
            If view.FocusedColumn.FieldName = "LfdNr" Then
                Dim currentCode As String = e.Value.ToString()
                For i As Integer = 0 To OcbsImportProcedures_BasicView.DataRowCount - 1
                    If i <> view.FocusedRowHandle Then
                        If currentCode.Equals(view.GetRowCellValue(i, colLfdNr).ToString) = True Then
                            e.ErrorText = "Duplicate Parameter Value detected in Field:LfdNr."
                            e.Valid = False
                            Exit For
                        End If
                    End If

                Next
            End If
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles OcbsImportProcedures_BasicView.RowCellClick
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles OcbsImportProcedures_BasicView.FocusedRowChanged
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles OcbsImportProcedures_BasicView.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.ProceduresGridviewPopupMenu.ShowPopup(GridControl1.PointToScreen(e.Point))
            End If
        End If
    End Sub


    Private Sub ProcedureDuplicateNextPosition_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ProcedureDuplicateNextPosition_bbi.ItemClick
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show("Should the current procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be duplicated in the next row?", "DUPLICATE PROCEDURE - NEXT ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Starting procedure duplication in the next row")

                OpenSqlConnections()
                cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                   DECLARE @CURRENT_USER Nvarchar(50)='<CurrentUser>'
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [PSTOOL_CLIENT_PROCEDURES] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
												DECLARE @DUBLICATE_ID int=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                              
                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                
                                                INSERT INTO [PSTOOL_CLIENT_PROCEDURES]
                                                           ([LfdNr]
                                                           ,[ProcName]
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[ExecutionPlan]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,[LastAction]
                                                           ,[LastUpdateUser]
                                                           ,[LastUpdateDate])
                                                SELECT		[LfdNr]+1
														   ,@Procedure_Name_New
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[ExecutionPlan]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                           ,GETDATE()
                                                FROM [PSTOOL_CLIENT_PROCEDURES] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [LfdNr] from [PSTOOL_CLIENT_PROCEDURES]
                                                where ID not in (Select Min(ID) from [PSTOOL_CLIENT_PROCEDURES] 
												group by [LfdNr]))

												
                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR

                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[LfdNr] from [PSTOOL_CLIENT_PROCEDURES] 
                                                where ID in (Select Min(ID) from [PSTOOL_CLIENT_PROCEDURES] 
												where [LfdNr]=@DUBLICATE_NR)

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[LfdNr]+@NEW_RUNNING_NR from [PSTOOL_CLIENT_PROCEDURES]
                                                where ID in (Select Min(ID) from [PSTOOL_CLIENT_PROCEDURES] 
												where [LfdNr] >=@DUBLICATE_NR
                                                group by [LfdNr]) order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[LfdNr]=B.Number from [PSTOOL_CLIENT_PROCEDURES] A INNER JOIN @ID_4 B on A.ID=B.ID "
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub ProcedureDuplicateNewPosition_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ProcedureDuplicateNewPosition_bbi.ItemClick
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show("Should the current procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be duplicated in a new row?", "DUPLICATE PROCEDURE - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Starting procedure duplication in a new row")

                OpenSqlConnections()
                cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                   DECLARE @CURRENT_USER Nvarchar(50)='<CurrentUser>'
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [PSTOOL_CLIENT_PROCEDURES] where ID=@ID_A)
                                                DECLARE @MAX_LFD_NR float=(Select MAX(LfdNr) from [PSTOOL_CLIENT_PROCEDURES])
												
                                                INSERT INTO [PSTOOL_CLIENT_PROCEDURES]
                                                           ([LfdNr]
                                                           ,[ProcName]
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[ExecutionPlan]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,[LastAction]
                                                           ,[LastUpdateUser]
                                                           ,[LastUpdateDate])
                                                SELECT		@MAX_LFD_NR+1
														   ,@Procedure_Name_New
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[ExecutionPlan]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                           ,GETDATE()
                                                FROM [PSTOOL_CLIENT_PROCEDURES] where ID=@ID_A"
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.PSTOOL_CLIENT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.PSTOOL_CLIENT_PROCEDURES)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClientEvents_BasicView_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles ClientEvents_BasicView.CustomDrawCell
        Dim AlertImage As Image = Me.ImageCollection1.Images.Item(21)
        Dim OkImage As Image = Me.ImageCollection1.Images.Item(14)
        Dim ErrorImage As Image = Me.ImageCollection1.Images.Item(20)
        If e.Column.FieldName = "Event" And e.RowHandle >= 0 Then
            'e.Cache.DrawImage(If(Convert.ToString(e.CellValue).StartsWith("ERROR") = True, Image1, Image2), e.Bounds.Location)
            'e.Handled = True

            e.DefaultDraw()

            Dim xPos As Integer = (((e.Bounds.Location.X + e.Bounds.Width) - AlertImage.Width) - 2)
            Dim yPos As Integer = (e.Bounds.Location.Y + 1)
            Dim imagePoint As Point = New Point(xPos, yPos)

            If Convert.ToString(e.CellValue).StartsWith("Unable") Then
                e.Cache.DrawImage(AlertImage, imagePoint)
            ElseIf Convert.ToString(e.CellValue).StartsWith("WARNING") Then
                e.Cache.DrawImage(AlertImage, imagePoint)
            ElseIf Convert.ToString(e.CellValue).StartsWith("ERROR") Then
                e.Cache.DrawImage(ErrorImage, imagePoint)
            Else
                e.Cache.DrawImage(OkImage, imagePoint)
            End If
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OcbsImportProcedures_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim LFD_NR As GridColumn = View.Columns("LfdNr")
        Dim PROC_NAME As GridColumn = View.Columns("ProcName")
        Dim FOLDER_NAME_IMPORT As GridColumn = View.Columns("FolderNameImport")
        Dim FILE_NAME_IMPORT As GridColumn = View.Columns("FileNameImport")
        Dim PROC_VALIDITY As GridColumn = View.Columns("Valid")
        Dim IMPORTANCE_STATUS As GridColumn = View.Columns("Importance")
        Dim EXECUTION_TYPE As GridColumn = View.Columns("ExectutionType")
        Dim EXECUTION_PLAN As GridColumn = View.Columns("ExectutionPlan")
        Dim FILE_EXTRACTION As GridColumn = View.Columns("FileExtraction")
        Dim REQUEST_BUSINESS_DATE As GridColumn = View.Columns("RequestBusinessDate")
        Dim FILE_CONVERTION As GridColumn = View.Columns("FileConvertion")

        Dim LfdNr As String = View.GetRowCellValue(e.RowHandle, colLfdNr).ToString
        Dim ProcName As String = View.GetRowCellValue(e.RowHandle, colProcName).ToString
        Dim FolderNameImport As String = View.GetRowCellValue(e.RowHandle, colFolderNameImport).ToString
        Dim FileNameImport As String = View.GetRowCellValue(e.RowHandle, colFileNameImport).ToString
        Dim ProcValidity As String = View.GetRowCellValue(e.RowHandle, colValid).ToString
        Dim ImportanceStatus As String = View.GetRowCellValue(e.RowHandle, colImportance).ToString
        Dim ExecutionType As String = View.GetRowCellValue(e.RowHandle, colExectutionType).ToString
        Dim ExecutionPlan As String = View.GetRowCellValue(e.RowHandle, colExecutionPlan).ToString
        Dim FileExtraction As String = View.GetRowCellValue(e.RowHandle, colFileExtraction).ToString
        Dim RequestBusinessDate As String = View.GetRowCellValue(e.RowHandle, colRequestBusinessDate).ToString
        Dim FileConvertion As String = View.GetRowCellValue(e.RowHandle, colFileConvertion).ToString

        If LfdNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LFD_NR, "The Procedure Nr. must not be empty")
            e.ErrorText = "The Procedure Nr. must not be empty"
        End If
        If ProcName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_NAME, "The Procedure Name must not be empty")
            e.ErrorText = "The Procedure Name must not be empty"
        End If
        If ExecutionType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(EXECUTION_TYPE, "The Execution Type must not be empty")
            e.ErrorText = "The Execution Type must not be empty"
        End If
        If ExecutionPlan = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(EXECUTION_PLAN, "The Execution plan must not be empty")
            e.ErrorText = "The Execution plan must not be empty"
        End If
        If FolderNameImport = "" And ExecutionType = "IMPORT" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FOLDER_NAME_IMPORT, "The Folder Name for import must not be empty if the Execution Type is IMPORT")
            e.ErrorText = "The Folder Name for import must not be empty if the Execution Type is IMPORT"
        End If
        If FileNameImport = "" And ExecutionType = "IMPORT" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_NAME_IMPORT, "The File Name for import must not be empty if the Execution Type is IMPORT")
            e.ErrorText = "The File Name for import must not be empty if the Execution Type is IMPORT"
        End If
        If ProcValidity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_VALIDITY, "The Validity  must not be empty")
            e.ErrorText = "The Validity  must not be empty"
        End If
        If ImportanceStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IMPORTANCE_STATUS, "The Importance Status  must not be empty")
            e.ErrorText = "The Importance Status  must not be empty"
        End If
    End Sub
End Class