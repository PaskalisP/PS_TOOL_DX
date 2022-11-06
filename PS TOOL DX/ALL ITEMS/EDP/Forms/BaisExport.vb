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

Public Class BaisExport

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim StartFileCreation_btn_clicked As Boolean = False 'Button for Start Client
    Dim BaisFilesCreationPath As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim DVTIFF_Result As String = Nothing
    Dim GSTIFF_Result As String = Nothing
    Dim GSTSLF_Result As String = Nothing
    Dim BILIFF_Result As String = Nothing

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

    Private Sub BaisExport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwBaisFilesCreation.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub BaisExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
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
        Me.GroupControl1.Text = "BAIS Files for creation - Creation Path:" & BaisFilesCreationPath

        'Bind Combobox
        Me.BusinessDate_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20140101' and [PL Result] is not NULL ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessDate_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessDate_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
    End Sub

#Region "ENABLE_DISABLE_CONTROLS_BY_FILE CREATION"
    Private Sub DISABLE_START_CREATION()
        Me.DVTIFF_Result_lbl.Text = ""
        Me.GSTIFF_Result_lbl.Text = ""
        Me.GSTSLF_Result_lbl.Text = ""
        Me.BILIFF_Result_lbl.Text = ""
        Me.StartFileCreation_btn.Enabled = False
        Me.CheckAll_btn.Enabled = False
        Me.OpenFolder_btn.Enabled = False
        Me.BusinessDate_Comboedit.Enabled = False
        Me.GroupControl1.Enabled = False

    End Sub

    Private Sub ENABLE_FINISH_CREATION()
       
        StartFileCreation_btn.Enabled = True
        Me.CheckAll_btn.Enabled = True
        Me.OpenFolder_btn.Enabled = True
        Me.BusinessDate_Comboedit.Enabled = True
        Me.GroupControl1.Enabled = True
        Me.DVTIFF_Result_lbl.Text = Me.DVTIFF_Result
        Me.GSTIFF_Result_lbl.Text = Me.GSTIFF_Result
        Me.GSTSLF_Result_lbl.Text = Me.GSTSLF_Result
        Me.BILIFF_Result_lbl.Text = Me.BILIFF_Result
    End Sub
#End Region

    Private Sub StartFileCreation_btn_Click(sender As Object, e As EventArgs) Handles StartFileCreation_btn.Click
        StartFileCreation_btn_clicked = True
        If IsDate(Me.BusinessDate_Comboedit.Text) = True Then
            If DVTIFF_CheckEdit.CheckState = CheckState.Checked OrElse GSTIFF_CheckEdit.CheckState = CheckState.Checked OrElse GSTSLF_CheckEdit.CheckState = CheckState.Checked _
                OrElse BILIFF_CheckEdit.CheckState = CheckState.Checked Then
                If MessageBox.Show("Should the BAIS Files creation be started?", "START BAIS FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_CREATION()
                    If Me.BgwBaisFilesCreation.IsBusy = False Then

                        Me.BgwBaisFilesCreation.RunWorkerAsync()
                    End If
                End If
            Else
                MessageBox.Show("Please check at least one File for creation", "NO FILE SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub

    Private Sub BgwBaisFilesCreation_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBaisFilesCreation.DoWork
        Try
            rd = Me.BusinessDate_Comboedit.Text
            rdsql = rd.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandTimeout = 500

            If DVTIFF_CheckEdit.CheckState = CheckState.Checked Then
                DVTIFF_CREATION()
            End If
            If GSTIFF_CheckEdit.CheckState = CheckState.Checked Then
                GSTIFF_CREATION()
            End If
            If GSTSLF_CheckEdit.CheckState = CheckState.Checked Then
                GSTSLF_CREATION()
            End If
            If BILIFF_CheckEdit.CheckState = CheckState.Checked Then
                BILIFF_CREATION()
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

        'Dim EndLine As Long = Len(Me.BaisExportEvents_RichTextBox.Text)
        'Me.BaisExportEvents_RichTextBox.SelectionStart = EndLine
        'Me.BaisExportEvents_RichTextBox.Focus()

        'Me.BaisExportEvents_RichTextBox.Select(Me.BaisExportEvents_RichTextBox.TextLength - 1, 1)
        'Me.BaisExportEvents_RichTextBox.HideSelection = True
        'If Not ScrollBarInfo.IsAtBottom(Me.BaisExportEvents_RichTextBox) Then
        'Me.BaisExportEvents_RichTextBox.ScrollToCaret()
        'End If

    End Sub

    Private Sub BgwBaisFilesCreation_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBaisFilesCreation.RunWorkerCompleted
        ENABLE_FINISH_CREATION()
        If Me.DVTIFF_Result_lbl.Text <> "" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "DVTIFF File created with success - " & BaisFilesCreationPath & "DVTIFF_CCB.csv"
        End If
        If Me.GSTIFF_Result_lbl.Text <> "" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSTIFF File created with success - " & BaisFilesCreationPath & "GSTIFF_CCB.csv"
        End If
        If Me.GSTSLF_Result_lbl.Text <> "" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSTSLF File created with success - " & BaisFilesCreationPath & "GSTSLF_CCB.csv"
        End If
        If Me.BILIFF_Result_lbl.Text <> "" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "BILIFF File created with success - " & BaisFilesCreationPath & "BILIFF_CCB.csv"
        End If

        ChangeTextcolor("File created with success", Color.DarkCyan, Me.BaisExportEvents_RichTextBox, 0)

        Try
            Using zip As ZipFile = New ZipFile
                For Each File In Directory.GetFiles(BaisFilesCreationPath, "*.CSV", SearchOption.TopDirectoryOnly)
                    zip.AddFile(File, "")
                Next
                zip.Save(BaisFilesCreationPath & "BAIS_Files_v1.19_from_PSTOOL_" & rdsql & ".rar")
                Dim BaisFilesList As String() = Directory.GetFiles(BaisFilesCreationPath, "*.CSV")
                For Each f In BaisFilesList
                    File.Delete(f)
                Next
            End Using
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "File(s) zipped in " & "BAIS_Files_v1.19_from_PSTOOL_" & rdsql & ".rar"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Unable to zip the created BAIS Files", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
        Me.BaisExportEvents_RichTextBox.HideSelection = True
    End Sub

    Private Sub DVTIFF_CREATION_OLD_CODE()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "' and [ClientNo] is  NULL"
        Dim Count As Double = cmd.ExecuteScalar


        If Count = 0 Then
            Try
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:DVTIFF_CCB.csv")
                BgwBaisFilesCreation.ReportProgress(2, "Create temporary table:DVTIFF_CCB")
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DVTIFF_CCB' AND xtype='U') CREATE TABLE [dbo].[DVTIFF_CCB]([ID] [int] IDENTITY(1,1) NOT NULL,[DVTIFF_MDANT] [nvarchar](50) NULL,[DVTIFF_GSREF] [nvarchar](50) NULL,[DVTIFF_FILNR] [nvarchar](50) NULL,[DVTIFF_KDNRH] [nvarchar](50) NULL,[DVTIFF_DXABD] [nvarchar](50) NULL,[DVTIFF_GSKLA] [nvarchar](50) NULL,[DVTIFF_SUKLA] [nvarchar](50) NULL,[DVTIFF_DVART] [nvarchar](50) NULL,[DVTIFF_DXVAL] [nvarchar](50) NULL,[DVTIFF_DANWC] [nvarchar](50) NULL,[DVTIFF_DANBT] [nvarchar](50) NULL,[DVTIFF_DVKWC] [nvarchar](50) NULL,[DVTIFF_DVKBT] [nvarchar](50) NULL,[DVTIFF_HBKZN] [nvarchar](50) NULL,[DVTIFF_ZWRIS] [nvarchar](50) NULL,[DVTIFF_KBTRG] [nvarchar](50) NULL,[DVTIFF_PTEIN] [nvarchar](50) NULL,[DVTIFF_WHGKP] [nvarchar](50) NULL,[DVTIFF_BCHSW] [nvarchar](50) NULL,[DVTIFF_WHGBU] [nvarchar](50) NULL,[DVTIFF_URDEA] [nvarchar](50) NULL,[DVTIFF_NETKR] [nvarchar](50) NULL,[DVTIFF_KZCVA] [nvarchar](50) NULL,[DVTIFF_GSARE] [nvarchar](50) NULL,[DVTIFF_FAIRV] [nvarchar](50) NULL,[DVTIFF_DXVKT] [nvarchar](50) NULL,[DVTIFF_HFZGP] [nvarchar](50) NULL,[DVTIFF_AFREF] [nvarchar](50) NULL,[DVTIFF_RESE1] [nvarchar](50) NULL,[DVTIFF_RESE2] [nvarchar](50) NULL,[DVTIFF_FREI1] [nvarchar](50) NULL,[DVTIFF_FREI2] [nvarchar](50) NULL,[DVTIFF_FREI3] [nvarchar](50) NULL,[DVTIFF_LOEKZ] [nvarchar](50) NULL,[DVTIFF_IFNAM] [nvarchar](50) NULL,[DVTIFF_DXIFD] [nvarchar](50) NULL) ELSE DELETE FROM [DVTIFF_CCB]"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Insert data to temporary table:DVTIFF_CCB")
                cmd.CommandText = "INSERT INTO [DVTIFF_CCB] ([DVTIFF_MDANT],[DVTIFF_GSREF],[DVTIFF_FILNR],[DVTIFF_KDNRH],[DVTIFF_DXABD],[DVTIFF_GSKLA],[DVTIFF_SUKLA],[DVTIFF_DVART],[DVTIFF_DXVAL],[DVTIFF_DANWC],[DVTIFF_DANBT],[DVTIFF_DVKWC],[DVTIFF_DVKBT],[DVTIFF_HBKZN],[DVTIFF_ZWRIS],[DVTIFF_KBTRG],[DVTIFF_PTEIN],[DVTIFF_WHGKP],[DVTIFF_BCHSW],[DVTIFF_WHGBU],[DVTIFF_URDEA],[DVTIFF_NETKR],[DVTIFF_KZCVA],[DVTIFF_GSARE],[DVTIFF_FAIRV],[DVTIFF_DXVKT],[DVTIFF_HFZGP],[DVTIFF_AFREF],[DVTIFF_RESE1],[DVTIFF_RESE2],[DVTIFF_FREI1],[DVTIFF_FREI2],[DVTIFF_FREI3],[DVTIFF_LOEKZ],[DVTIFF_IFNAM],[DVTIFF_DXIFD]) Select 'CCB',[ContractNr],'***',[ClientNo],CONVERT(nvarchar(50), [InputDate], 112),'DV','00',[DealType],CONVERT(nvarchar(50), [MaturityDate], 112),[BuyCCY],STR([BuyAmount],10,2),[SellCCY],STR([SellAmount],10,2),'A','W','0','0','','0','','','','J','','','','','','','',CONVERT(nvarchar(50), [ValueDate], 112),'','','','DVTIFF',CONVERT(nvarchar(50), [RiskDate], 112) from [FX DAILY REVALUATION] where [DealType] in ('FW','SW','SP') and [RiskDate]='" & rdsql & "' and [MaturityDate]>[RiskDate] order by ID asc"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Update DVTIFF_CCB Set Column DVTIFF_DVART to 1 if SP otherwise 2")
                cmd.CommandText = "UPDATE [DVTIFF_CCB] SET [DVTIFF_DVART]= CASE WHEN [DVTIFF_DVART]='SP' then '1' ELSE '2' END where [DVTIFF_DVART] is not NULL"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set unique reference in Field DVTIFF_GSREF")
                cmd.CommandText = "UPDATE [DVTIFF_CCB]  SET [DVTIFF_GSREF]=[DVTIFF_GSREF] + '-1' where [ID] not in (Select Min([ID]) from [DVTIFF_CCB] group by  [DVTIFF_GSREF])"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Delete ID Column from DVTIFF_CCB")
                cmd.CommandText = "ALTER TABLE [DVTIFF_CCB]  DROP COLUMN [ID]"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: DVTIFF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "DVTIFF_MDANT|DVTIFF_GSREF|DVTIFF_FILNR|DVTIFF_KDNRH|DVTIFF_DXABD|DVTIFF_GSKLA|DVTIFF_SUKLA|DVTIFF_DVART|DVTIFF_DXVAL|DVTIFF_DANWC|DVTIFF_DANBT|DVTIFF_DVKWC|DVTIFF_DVKBT|DVTIFF_HBKZN|DVTIFF_ZWRIS|DVTIFF_KBTRG|DVTIFF_PTEIN|DVTIFF_WHGKP|DVTIFF_BCHSW|DVTIFF_WHGBU|DVTIFF_URDEA|DVTIFF_NETKR|DVTIFF_KZCVA|DVTIFF_GSARE|DVTIFF_FAIRV|DVTIFF_DXVKT|DVTIFF_HFZGP|DVTIFF_AFREF|DVTIFF_RESE1|DVTIFF_RESE2|DVTIFF_FREI1|DVTIFF_FREI2|DVTIFF_FREI3|DVTIFF_LOEKZ|DVTIFF_IFNAM|DVTIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim DVTIFF_MDANT As String = Nothing
                Dim DVTIFF_GSREF As String = Nothing
                Dim DVTIFF_FILNR As String = Nothing
                Dim DVTIFF_KDNRH As String = Nothing
                Dim DVTIFF_DXABD As String = Nothing
                Dim DVTIFF_GSKLA As String = Nothing
                Dim DVTIFF_SUKLA As String = Nothing
                Dim DVTIFF_DVART As String = Nothing
                Dim DVTIFF_DXVAL As String = Nothing
                Dim DVTIFF_DANWC As String = Nothing
                Dim DVTIFF_DANBT As String = Nothing
                Dim DVTIFF_DVKWC As String = Nothing
                Dim DVTIFF_DVKBT As String = Nothing
                Dim DVTIFF_HBKZN As String = Nothing
                Dim DVTIFF_ZWRIS As String = Nothing
                Dim DVTIFF_KBTRG As String = Nothing
                Dim DVTIFF_PTEIN As String = Nothing
                Dim DVTIFF_WHGKP As String = Nothing
                Dim DVTIFF_BCHSW As String = Nothing
                Dim DVTIFF_WHGBU As String = Nothing
                Dim DVTIFF_URDEA As String = Nothing
                Dim DVTIFF_NETKR As String = Nothing
                Dim DVTIFF_KZCVA As String = Nothing
                Dim DVTIFF_GSARE As String = Nothing
                Dim DVTIFF_FAIRV As String = Nothing
                Dim DVTIFF_DXVKT As String = Nothing
                Dim DVTIFF_HFZGP As String = Nothing
                Dim DVTIFF_AFREF As String = Nothing
                Dim DVTIFF_RESE1 As String = Nothing
                Dim DVTIFF_RESE2 As String = Nothing
                Dim DVTIFF_FREI1 As String = Nothing
                Dim DVTIFF_FREI2 As String = Nothing
                Dim DVTIFF_FREI3 As String = Nothing
                Dim DVTIFF_LOEKZ As String = Nothing
                Dim DVTIFF_IFNAM As String = Nothing
                Dim DVTIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "DVTIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DVTIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [DVTIFF_CCB]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in DVTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("DVTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("DVTIFF_KDNRH"))
                    DVTIFF_MDANT = dt.Rows.Item(i).Item("DVTIFF_MDANT") & "|"
                    DVTIFF_GSREF = dt.Rows.Item(i).Item("DVTIFF_GSREF") & "|"
                    DVTIFF_FILNR = dt.Rows.Item(i).Item("DVTIFF_FILNR") & "|"
                    DVTIFF_KDNRH = dt.Rows.Item(i).Item("DVTIFF_KDNRH") & "|"
                    DVTIFF_DXABD = dt.Rows.Item(i).Item("DVTIFF_DXABD") & "|"
                    DVTIFF_GSKLA = dt.Rows.Item(i).Item("DVTIFF_GSKLA") & "|"
                    DVTIFF_SUKLA = dt.Rows.Item(i).Item("DVTIFF_SUKLA") & "|"
                    DVTIFF_DVART = dt.Rows.Item(i).Item("DVTIFF_DVART") & "|"
                    DVTIFF_DXVAL = dt.Rows.Item(i).Item("DVTIFF_DXVAL") & "|"
                    DVTIFF_DANWC = dt.Rows.Item(i).Item("DVTIFF_DANWC") & "|"
                    DVTIFF_DANBT = dt.Rows.Item(i).Item("DVTIFF_DANBT") & "|"
                    DVTIFF_DVKWC = dt.Rows.Item(i).Item("DVTIFF_DVKWC") & "|"
                    DVTIFF_DVKBT = dt.Rows.Item(i).Item("DVTIFF_DVKBT") & "|"
                    DVTIFF_HBKZN = dt.Rows.Item(i).Item("DVTIFF_HBKZN") & "|"
                    DVTIFF_ZWRIS = dt.Rows.Item(i).Item("DVTIFF_ZWRIS") & "|"
                    DVTIFF_KBTRG = dt.Rows.Item(i).Item("DVTIFF_KBTRG") & "|"
                    DVTIFF_PTEIN = dt.Rows.Item(i).Item("DVTIFF_PTEIN") & "|"
                    DVTIFF_WHGKP = dt.Rows.Item(i).Item("DVTIFF_WHGKP") & "|"
                    DVTIFF_BCHSW = dt.Rows.Item(i).Item("DVTIFF_BCHSW") & "|"
                    DVTIFF_WHGBU = dt.Rows.Item(i).Item("DVTIFF_WHGBU") & "|"
                    DVTIFF_URDEA = dt.Rows.Item(i).Item("DVTIFF_URDEA") & "|"
                    DVTIFF_NETKR = dt.Rows.Item(i).Item("DVTIFF_NETKR") & "|"
                    DVTIFF_KZCVA = dt.Rows.Item(i).Item("DVTIFF_KZCVA") & "|"
                    DVTIFF_GSARE = dt.Rows.Item(i).Item("DVTIFF_GSARE") & "|"
                    DVTIFF_FAIRV = dt.Rows.Item(i).Item("DVTIFF_FAIRV") & "|"
                    DVTIFF_DXVKT = dt.Rows.Item(i).Item("DVTIFF_DXVKT") & "|"
                    DVTIFF_HFZGP = dt.Rows.Item(i).Item("DVTIFF_HFZGP") & "|"
                    DVTIFF_AFREF = dt.Rows.Item(i).Item("DVTIFF_AFREF") & "|"
                    DVTIFF_RESE1 = dt.Rows.Item(i).Item("DVTIFF_RESE1") & "|"
                    DVTIFF_RESE2 = dt.Rows.Item(i).Item("DVTIFF_RESE2") & "|"
                    DVTIFF_FREI1 = dt.Rows.Item(i).Item("DVTIFF_FREI1") & "|"
                    DVTIFF_FREI2 = dt.Rows.Item(i).Item("DVTIFF_FREI2") & "|"
                    DVTIFF_FREI3 = dt.Rows.Item(i).Item("DVTIFF_FREI3") & "|"
                    DVTIFF_LOEKZ = dt.Rows.Item(i).Item("DVTIFF_LOEKZ") & "|"
                    DVTIFF_IFNAM = dt.Rows.Item(i).Item("DVTIFF_IFNAM") & "|"
                    DVTIFF_DXIFD = dt.Rows.Item(i).Item("DVTIFF_DXIFD")

                    CSV_ROW = DVTIFF_MDANT & DVTIFF_GSREF & DVTIFF_FILNR & DVTIFF_KDNRH & DVTIFF_DXABD & DVTIFF_GSKLA & DVTIFF_SUKLA & DVTIFF_DVART & DVTIFF_DXVAL & DVTIFF_DANWC & DVTIFF_DANBT & DVTIFF_DVKWC & DVTIFF_DVKBT & DVTIFF_HBKZN & DVTIFF_ZWRIS & DVTIFF_KBTRG & DVTIFF_PTEIN & DVTIFF_WHGKP & DVTIFF_BCHSW & DVTIFF_WHGBU & DVTIFF_URDEA & DVTIFF_NETKR & DVTIFF_KZCVA & DVTIFF_GSARE & DVTIFF_FAIRV & DVTIFF_DXVKT & DVTIFF_HFZGP & DVTIFF_AFREF & DVTIFF_RESE1 & DVTIFF_RESE2 & DVTIFF_FREI1 & DVTIFF_FREI2 & DVTIFF_FREI3 & DVTIFF_LOEKZ & DVTIFF_IFNAM & DVTIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.DVTIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show("Unable to create File DVTIFF_CCB.csv for " & rd & vbNewLine & "There are FX Deals with no Client Nr. in the Database for this Date" & vbNewLine & " Please update Client Nr for all FX Deals in order to create the requested csv file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub DVTIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "' and [ClientNo] is  NULL"
        Dim Count As Double = cmd.ExecuteScalar


        If Count = 0 Then
            Try
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_DVTIFF Table with DVTIFF_DXIFD: " & rd)
                BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_DVTIFF Table with DVTIFF_DXIFD: " & rd)
                cmd.CommandText = "DELETE FROM [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Insert data to temporary table:DVTIFF_CCB")
                cmd.CommandText = "INSERT INTO [BAIS_DVTIFF] ([DVTIFF_MDANT],[DVTIFF_GSREF],[DVTIFF_FILNR],[DVTIFF_KDNRH],[DVTIFF_DXABD],[DVTIFF_GSKLA],[DVTIFF_SUKLA],[DVTIFF_DVART],[DVTIFF_DXVAL],[DVTIFF_DANWC],[DVTIFF_DANBT],[DVTIFF_DVKWC],[DVTIFF_DVKBT],[DVTIFF_HBKZN],[DVTIFF_ZWRIS],[DVTIFF_KBTRG],[DVTIFF_PTEIN],[DVTIFF_WHGKP],[DVTIFF_BCHSW],[DVTIFF_WHGBU],[DVTIFF_URDEA],[DVTIFF_NETKR],[DVTIFF_KZCVA],[DVTIFF_GSARE],[DVTIFF_FAIRV],[DVTIFF_DXVKT],[DVTIFF_HFZGP],[DVTIFF_AFREF],[DVTIFF_RESE1],[DVTIFF_RESE2],[DVTIFF_FREI1],[DVTIFF_FREI2],[DVTIFF_FREI3],[DVTIFF_LOEKZ],[DVTIFF_IFNAM],[DVTIFF_DXIFD]) Select 'CCB',[ContractNr],'***',[ClientNo],[InputDate],'DV','00',[DealType],[MaturityDate],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],'A','W','0','0','','0','','','','J','','','','','','','',[ValueDate],'','','','DVTIFF',[RiskDate] from [FX DAILY REVALUATION] where [DealType] in ('FW','SW','SP') and [RiskDate]='" & rdsql & "' and [MaturityDate]>[RiskDate] order by ID asc"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Update DVTIFF_CCB Set Column DVTIFF_DVART to 1 if SP otherwise 2")
                cmd.CommandText = "UPDATE [BAIS_DVTIFF] SET [DVTIFF_DVART]= CASE WHEN [DVTIFF_DVART]='SP' then '1' ELSE '2' END where [DVTIFF_DVART] is not NULL and [DVTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set unique reference in Field DVTIFF_GSREF")
                cmd.CommandText = "UPDATE [BAIS_DVTIFF]  SET [DVTIFF_GSREF]=[DVTIFF_GSREF] + '-1' where [ID] not in (Select Min([ID]) from [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "' group by  [DVTIFF_GSREF]) and [DVTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Delete ID Column from DVTIFF_CCB")
                'cmd.CommandText = "ALTER TABLE [DVTIFF_CCB]  DROP COLUMN [ID]"
                'cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: DVTIFF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "DVTIFF_MDANT|DVTIFF_GSREF|DVTIFF_FILNR|DVTIFF_KDNRH|DVTIFF_DXABD|DVTIFF_GSKLA|DVTIFF_SUKLA|DVTIFF_DVART|DVTIFF_DXVAL|DVTIFF_DANWC|DVTIFF_DANBT|DVTIFF_DVKWC|DVTIFF_DVKBT|DVTIFF_HBKZN|DVTIFF_ZWRIS|DVTIFF_KBTRG|DVTIFF_PTEIN|DVTIFF_WHGKP|DVTIFF_BCHSW|DVTIFF_WHGBU|DVTIFF_URDEA|DVTIFF_NETKR|DVTIFF_KZCVA|DVTIFF_GSARE|DVTIFF_FAIRV|DVTIFF_DXVKT|DVTIFF_HFZGP|DVTIFF_AFREF|DVTIFF_RESE1|DVTIFF_RESE2|DVTIFF_FREI1|DVTIFF_FREI2|DVTIFF_FREI3|DVTIFF_LOEKZ|DVTIFF_IFNAM|DVTIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim DVTIFF_MDANT As String = Nothing
                Dim DVTIFF_GSREF As String = Nothing
                Dim DVTIFF_FILNR As String = Nothing
                Dim DVTIFF_KDNRH As String = Nothing
                Dim DVTIFF_DXABD As String = Nothing
                Dim DVTIFF_GSKLA As String = Nothing
                Dim DVTIFF_SUKLA As String = Nothing
                Dim DVTIFF_DVART As String = Nothing
                Dim DVTIFF_DXVAL As String = Nothing
                Dim DVTIFF_DANWC As String = Nothing
                Dim DVTIFF_DANBT As String = Nothing
                Dim DVTIFF_DVKWC As String = Nothing
                Dim DVTIFF_DVKBT As String = Nothing
                Dim DVTIFF_HBKZN As String = Nothing
                Dim DVTIFF_ZWRIS As String = Nothing
                Dim DVTIFF_KBTRG As String = Nothing
                Dim DVTIFF_PTEIN As String = Nothing
                Dim DVTIFF_WHGKP As String = Nothing
                Dim DVTIFF_BCHSW As String = Nothing
                Dim DVTIFF_WHGBU As String = Nothing
                Dim DVTIFF_URDEA As String = Nothing
                Dim DVTIFF_NETKR As String = Nothing
                Dim DVTIFF_KZCVA As String = Nothing
                Dim DVTIFF_GSARE As String = Nothing
                Dim DVTIFF_FAIRV As String = Nothing
                Dim DVTIFF_DXVKT As String = Nothing
                Dim DVTIFF_HFZGP As String = Nothing
                Dim DVTIFF_AFREF As String = Nothing
                Dim DVTIFF_RESE1 As String = Nothing
                Dim DVTIFF_RESE2 As String = Nothing
                Dim DVTIFF_FREI1 As String = Nothing
                Dim DVTIFF_FREI2 As String = Nothing
                Dim DVTIFF_FREI3 As String = Nothing
                Dim DVTIFF_LOEKZ As String = Nothing
                Dim DVTIFF_IFNAM As String = Nothing
                Dim DVTIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "DVTIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DVTIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in DVTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("DVTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("DVTIFF_KDNRH"))
                    DVTIFF_MDANT = dt.Rows.Item(i).Item("DVTIFF_MDANT") & "|"
                    DVTIFF_GSREF = dt.Rows.Item(i).Item("DVTIFF_GSREF") & "|"
                    DVTIFF_FILNR = dt.Rows.Item(i).Item("DVTIFF_FILNR") & "|"
                    DVTIFF_KDNRH = dt.Rows.Item(i).Item("DVTIFF_KDNRH") & "|"
                    DVTIFF_DXABD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_DXABD")) & "|"
                    DVTIFF_GSKLA = dt.Rows.Item(i).Item("DVTIFF_GSKLA") & "|"
                    DVTIFF_SUKLA = dt.Rows.Item(i).Item("DVTIFF_SUKLA") & "|"
                    DVTIFF_DVART = dt.Rows.Item(i).Item("DVTIFF_DVART") & "|"
                    DVTIFF_DXVAL = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_DXVAL")) & "|"
                    DVTIFF_DANWC = dt.Rows.Item(i).Item("DVTIFF_DANWC") & "|"
                    DVTIFF_DANBT = dt.Rows.Item(i).Item("DVTIFF_DANBT").ToString.Replace(",", ".") & "|"
                    DVTIFF_DVKWC = dt.Rows.Item(i).Item("DVTIFF_DVKWC") & "|"
                    DVTIFF_DVKBT = dt.Rows.Item(i).Item("DVTIFF_DVKBT").ToString.Replace(",", ".") & "|"
                    DVTIFF_HBKZN = dt.Rows.Item(i).Item("DVTIFF_HBKZN") & "|"
                    DVTIFF_ZWRIS = dt.Rows.Item(i).Item("DVTIFF_ZWRIS") & "|"
                    DVTIFF_KBTRG = dt.Rows.Item(i).Item("DVTIFF_KBTRG") & "|"
                    DVTIFF_PTEIN = dt.Rows.Item(i).Item("DVTIFF_PTEIN") & "|"
                    DVTIFF_WHGKP = dt.Rows.Item(i).Item("DVTIFF_WHGKP") & "|"
                    DVTIFF_BCHSW = dt.Rows.Item(i).Item("DVTIFF_BCHSW") & "|"
                    DVTIFF_WHGBU = dt.Rows.Item(i).Item("DVTIFF_WHGBU") & "|"
                    DVTIFF_URDEA = dt.Rows.Item(i).Item("DVTIFF_URDEA") & "|"
                    DVTIFF_NETKR = dt.Rows.Item(i).Item("DVTIFF_NETKR") & "|"
                    DVTIFF_KZCVA = dt.Rows.Item(i).Item("DVTIFF_KZCVA") & "|"
                    DVTIFF_GSARE = dt.Rows.Item(i).Item("DVTIFF_GSARE") & "|"
                    DVTIFF_FAIRV = dt.Rows.Item(i).Item("DVTIFF_FAIRV") & "|"
                    DVTIFF_DXVKT = dt.Rows.Item(i).Item("DVTIFF_DXVKT") & "|"
                    DVTIFF_HFZGP = dt.Rows.Item(i).Item("DVTIFF_HFZGP") & "|"
                    DVTIFF_AFREF = dt.Rows.Item(i).Item("DVTIFF_AFREF") & "|"
                    DVTIFF_RESE1 = dt.Rows.Item(i).Item("DVTIFF_RESE1") & "|"
                    DVTIFF_RESE2 = dt.Rows.Item(i).Item("DVTIFF_RESE2") & "|"
                    DVTIFF_FREI1 = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_FREI1")) & "|"
                    DVTIFF_FREI2 = dt.Rows.Item(i).Item("DVTIFF_FREI2") & "|"
                    DVTIFF_FREI3 = dt.Rows.Item(i).Item("DVTIFF_FREI3") & "|"
                    DVTIFF_LOEKZ = dt.Rows.Item(i).Item("DVTIFF_LOEKZ") & "|"
                    DVTIFF_IFNAM = dt.Rows.Item(i).Item("DVTIFF_IFNAM") & "|"
                    DVTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_DXIFD"))

                    CSV_ROW = DVTIFF_MDANT & DVTIFF_GSREF & DVTIFF_FILNR & DVTIFF_KDNRH & DVTIFF_DXABD & DVTIFF_GSKLA & DVTIFF_SUKLA & DVTIFF_DVART & DVTIFF_DXVAL & DVTIFF_DANWC & DVTIFF_DANBT & DVTIFF_DVKWC & DVTIFF_DVKBT & DVTIFF_HBKZN & DVTIFF_ZWRIS & DVTIFF_KBTRG & DVTIFF_PTEIN & DVTIFF_WHGKP & DVTIFF_BCHSW & DVTIFF_WHGBU & DVTIFF_URDEA & DVTIFF_NETKR & DVTIFF_KZCVA & DVTIFF_GSARE & DVTIFF_FAIRV & DVTIFF_DXVKT & DVTIFF_HFZGP & DVTIFF_AFREF & DVTIFF_RESE1 & DVTIFF_RESE2 & DVTIFF_FREI1 & DVTIFF_FREI2 & DVTIFF_FREI3 & DVTIFF_LOEKZ & DVTIFF_IFNAM & DVTIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                'cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                'cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.DVTIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show("Unable to create File DVTIFF_CCB.csv for " & rd & vbNewLine & "There are FX Deals with no Client Nr. in the Database for this Date" & vbNewLine & " Please update Client Nr for all FX Deals in order to create the requested csv file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub GSTIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count <> 0 Then
            Try
                
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:GSTIFF_CCB.csv")
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='100',[GSTIFF_BILKT]='100',[ReferenceClear]=NULL where [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Extract Reference in Reference Clear")
                cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=dbo.fn_StripCharacters([GSTIFF_GSREF],'^0-9') where [GSTIFF_MODUL] not in ('SK') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=LEFT([GSTIFF_GSREF],8) where [GSTIFF_MODUL] in ('SK') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Update GL Item from DailyBalanceDetailsSheet")
                cmd.CommandText = "Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[ReleatedAccountNr] and A.[GSTIFF_WHISO]=B.[Orig_CUR] and A.[GSTIFF_DXIFD]=B.[BSDate] and B.[GL_Item] not like '%I' and A.[GSTIFF_MODUL] not in ('SK','CA') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[ReleatedAccountNr] and A.[GSTIFF_WHISO]=B.[Orig_CUR] and A.[GSTIFF_DXIFD]=B.[BSDate] and B.[GL_Item] not like '%I' and A.[GSTIFF_MODUL] in ('CA','LN') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='3500' where [GSTIFF_MODUL] in ('CA') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='500' where [GSTIFF_KOART] in ('NOSTRO') and [GSTIFF_MODUL] in ('IB') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='2010' where [GSTIFF_KOART] in ('SECUR') and [GSTIFF_MODUL] in ('FI') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = " Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[GL_Account_Nr] and A.[GSTIFF_DXIFD]=B.[BSDate] and A.[GSTIFF_MODUL] in ('SK') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set all Acrued Interest with +01 otherwise +00")
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]=[GL_Item_Basic]+'00' where [GL_Item_Basic] not like '%I' and [GL_Item_Basic] not in ('100') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]=REPLACE([GL_Item_Basic],'I','01') where [GL_Item_Basic] like '%I' and [GL_Item_Basic] not in ('100') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set BAIS Specific GL Item Nr.to 50000 for GL Items 51900,50000")
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]='50000' where [GSTIFF_BILKT] in ('51900','50000') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set BAIS Specific GL Item Nr.to 350000 for GL Items 300000,301900 and 350000")
                cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]='350000' where [GSTIFF_BILKT] in ('300000','301900','350000') and [GSTIFF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTIFF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GSTIFF_MDANT|GSTIFF_FILNR|GSTIFF_MODUL|GSTIFF_KDNRH|GSTIFF_KTONR|GSTIFF_GSREF|GSTIFF_BEZNG|GSTIFF_KOART|GSTIFF_BILKT|GSTIFF_GSKLA|GSTIFF_SUKLA|GSTIFF_GSART|GSTIFF_ULFZT|GSTIFF_WHISO|GSTIFF_VERKZ|GSTIFF_SLDKZ|GSTIFF_KZREV|GSTIFF_WPKNZ|GSTIFF_WPBFN|GSTIFF_HBKZN|GSTIFF_ZWRIS|GSTIFF_KZLST|GSTIFF_HAFIN|GSTIFF_WESTA|GSTIFF_BEZNR|GSTIFF_DXVND|GSTIFF_DXBSD|GSTIFF_MRLFZ|GSTIFF_AUSFL|GSTIFF_DXAUD|GSTIFF_RANGF|GSTIFF_KZUEV|GSTIFF_KFRIS|GSTIFF_DXZAP|GSTIFF_KZVSG|GSTIFF_KZKRU|GSTIFF_KONSB|GSTIFF_RISGR|GSTIFF_KONSK|GSTIFF_WPKNR|GSTIFF_GSARE|GSTIFF_PRDKT|GSTIFF_WHIFX|GSTIFF_HFZGP|GSTIFF_AFREF|GSTIFF_KZAKL|GSTIFF_KONSR|GSTIFF_FREI1|GSTIFF_FREI2|GSTIFF_FREI3|GSTIFF_FREI4|GSTIFF_FREI5|GSTIFF_LOEKZ|GSTIFF_IFNAM|GSTIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim GSTIFF_MDANT As String = Nothing
                Dim GSTIFF_FILNR As String = Nothing
                Dim GSTIFF_MODUL As String = Nothing
                Dim GSTIFF_KDNRH As String = Nothing
                Dim GSTIFF_KTONR As String = Nothing
                Dim GSTIFF_GSREF As String = Nothing
                Dim GSTIFF_BEZNG As String = Nothing
                Dim GSTIFF_KOART As String = Nothing
                Dim GSTIFF_BILKT As String = Nothing
                Dim GSTIFF_GSKLA As String = Nothing
                Dim GSTIFF_SUKLA As String = Nothing
                Dim GSTIFF_GSART As String = Nothing
                Dim GSTIFF_ULFZT As String = Nothing
                Dim GSTIFF_WHISO As String = Nothing
                Dim GSTIFF_VERKZ As String = Nothing
                Dim GSTIFF_SLDKZ As String = Nothing
                Dim GSTIFF_KZREV As String = Nothing
                Dim GSTIFF_WPKNZ As String = Nothing
                Dim GSTIFF_WPBFN As String = Nothing
                Dim GSTIFF_HBKZN As String = Nothing
                Dim GSTIFF_ZWRIS As String = Nothing
                Dim GSTIFF_KZLST As String = Nothing
                Dim GSTIFF_HAFIN As String = Nothing
                Dim GSTIFF_WESTA As String = Nothing
                Dim GSTIFF_BEZNR As String = Nothing
                Dim GSTIFF_DXVND As String = Nothing
                Dim GSTIFF_DXBSD As String = Nothing
                Dim GSTIFF_MRLFZ As String = Nothing
                Dim GSTIFF_AUSFL As String = Nothing
                Dim GSTIFF_DXAUD As String = Nothing
                Dim GSTIFF_RANGF As String = Nothing
                Dim GSTIFF_KZUEV As String = Nothing
                Dim GSTIFF_KFRIS As String = Nothing
                Dim GSTIFF_DXZAP As String = Nothing
                Dim GSTIFF_KZVSG As String = Nothing
                Dim GSTIFF_KZKRU As String = Nothing
                Dim GSTIFF_KONSB As String = Nothing
                Dim GSTIFF_RISGR As String = Nothing
                Dim GSTIFF_KONSK As String = Nothing
                Dim GSTIFF_WPKNR As String = Nothing
                Dim GSTIFF_GSARE As String = Nothing
                Dim GSTIFF_PRDKT As String = Nothing
                Dim GSTIFF_WHIFX As String = Nothing
                Dim GSTIFF_HFZGP As String = Nothing
                Dim GSTIFF_AFREF As String = Nothing
                Dim GSTIFF_KZAKL As String = Nothing
                Dim GSTIFF_KONSR As String = Nothing
                Dim GSTIFF_FREI1 As String = Nothing
                Dim GSTIFF_FREI2 As String = Nothing
                Dim GSTIFF_FREI3 As String = Nothing
                Dim GSTIFF_FREI4 As String = Nothing
                Dim GSTIFF_FREI5 As String = Nothing
                Dim GSTIFF_LOEKZ As String = Nothing
                Dim GSTIFF_IFNAM As String = Nothing
                Dim GSTIFF_DXIFD As String = Nothing


                If File.Exists(BaisFilesCreationPath & "GSTIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSTIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  [GSTIFF_MDANT],[GSTIFF_FILNR],[GSTIFF_MODUL],[GSTIFF_KDNRH],[GSTIFF_KTONR],[GSTIFF_GSREF],[GSTIFF_BEZNG],[GSTIFF_KOART],[GSTIFF_BILKT],[GSTIFF_GSKLA],[GSTIFF_SUKLA],[GSTIFF_GSART],[GSTIFF_ULFZT],[GSTIFF_WHISO],[GSTIFF_VERKZ],[GSTIFF_SLDKZ],[GSTIFF_KZREV],[GSTIFF_WPKNZ],[GSTIFF_WPBFN],[GSTIFF_HBKZN],[GSTIFF_ZWRIS],[GSTIFF_KZLST],[GSTIFF_HAFIN],[GSTIFF_WESTA],[GSTIFF_BEZNR],[GSTIFF_DXVND],[GSTIFF_DXBSD],[GSTIFF_MRLFZ],[GSTIFF_AUSFL],[GSTIFF_DXAUD],[GSTIFF_RANGF],[GSTIFF_KZUEV],[GSTIFF_KFRIS],[GSTIFF_DXZAP],[GSTIFF_KZVSG],[GSTIFF_KZKRU],[GSTIFF_KONSB],[GSTIFF_RISGR],[GSTIFF_KONSK],[GSTIFF_WPKNR],[GSTIFF_GSARE],[GSTIFF_PRDKT],[GSTIFF_WHIFX],[GSTIFF_HFZGP],[GSTIFF_AFREF],[GSTIFF_KZAKL],[GSTIFF_KONSR],[GSTIFF_FREI1],[GSTIFF_FREI2],[GSTIFF_FREI3],[GSTIFF_FREI4],[GSTIFF_FREI5],[GSTIFF_LOEKZ],[GSTIFF_IFNAM],[GSTIFF_DXIFD] FROM  [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in GSTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("GSTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("GSTIFF_KDNRH"))
                    GSTIFF_MDANT = dt.Rows.Item(i).Item("GSTIFF_MDANT") & "|"
                    GSTIFF_FILNR = dt.Rows.Item(i).Item("GSTIFF_FILNR") & "|"
                    GSTIFF_MODUL = dt.Rows.Item(i).Item("GSTIFF_MODUL") & "|"
                    GSTIFF_KDNRH = dt.Rows.Item(i).Item("GSTIFF_KDNRH") & "|"
                    GSTIFF_KTONR = dt.Rows.Item(i).Item("GSTIFF_KTONR") & "|"
                    GSTIFF_GSREF = dt.Rows.Item(i).Item("GSTIFF_GSREF") & "|"
                    GSTIFF_BEZNG = dt.Rows.Item(i).Item("GSTIFF_BEZNG") & "|"
                    GSTIFF_KOART = dt.Rows.Item(i).Item("GSTIFF_KOART") & "|"
                    GSTIFF_BILKT = dt.Rows.Item(i).Item("GSTIFF_BILKT") & "|"
                    GSTIFF_GSKLA = dt.Rows.Item(i).Item("GSTIFF_GSKLA") & "|"
                    GSTIFF_SUKLA = dt.Rows.Item(i).Item("GSTIFF_SUKLA") & "|"
                    GSTIFF_GSART = dt.Rows.Item(i).Item("GSTIFF_GSART") & "|"
                    GSTIFF_ULFZT = dt.Rows.Item(i).Item("GSTIFF_ULFZT") & "|"
                    GSTIFF_WHISO = dt.Rows.Item(i).Item("GSTIFF_WHISO") & "|"
                    GSTIFF_VERKZ = dt.Rows.Item(i).Item("GSTIFF_VERKZ") & "|"
                    GSTIFF_SLDKZ = dt.Rows.Item(i).Item("GSTIFF_SLDKZ") & "|"
                    GSTIFF_KZREV = dt.Rows.Item(i).Item("GSTIFF_KZREV") & "|"
                    GSTIFF_WPKNZ = dt.Rows.Item(i).Item("GSTIFF_WPKNZ") & "|"
                    GSTIFF_WPBFN = dt.Rows.Item(i).Item("GSTIFF_WPBFN") & "|"
                    GSTIFF_HBKZN = dt.Rows.Item(i).Item("GSTIFF_HBKZN") & "|"
                    GSTIFF_ZWRIS = dt.Rows.Item(i).Item("GSTIFF_ZWRIS") & "|"
                    GSTIFF_KZLST = dt.Rows.Item(i).Item("GSTIFF_KZLST") & "|"
                    GSTIFF_HAFIN = dt.Rows.Item(i).Item("GSTIFF_HAFIN") & "|"
                    GSTIFF_WESTA = dt.Rows.Item(i).Item("GSTIFF_WESTA") & "|"
                    GSTIFF_BEZNR = dt.Rows.Item(i).Item("GSTIFF_BEZNR") & "|"
                    GSTIFF_DXVND = dt.Rows.Item(i).Item("GSTIFF_DXVND") & "|"
                    GSTIFF_DXBSD = dt.Rows.Item(i).Item("GSTIFF_DXBSD") & "|"
                    GSTIFF_MRLFZ = dt.Rows.Item(i).Item("GSTIFF_MRLFZ") & "|"
                    GSTIFF_AUSFL = dt.Rows.Item(i).Item("GSTIFF_AUSFL") & "|"
                    GSTIFF_DXAUD = dt.Rows.Item(i).Item("GSTIFF_DXAUD") & "|"
                    GSTIFF_RANGF = dt.Rows.Item(i).Item("GSTIFF_RANGF") & "|"
                    GSTIFF_KZUEV = dt.Rows.Item(i).Item("GSTIFF_KZUEV") & "|"
                    GSTIFF_KFRIS = dt.Rows.Item(i).Item("GSTIFF_KFRIS") & "|"
                    GSTIFF_DXZAP = dt.Rows.Item(i).Item("GSTIFF_DXZAP") & "|"
                    GSTIFF_KZVSG = dt.Rows.Item(i).Item("GSTIFF_KZVSG") & "|"
                    GSTIFF_KZKRU = dt.Rows.Item(i).Item("GSTIFF_KZKRU") & "|"
                    GSTIFF_KONSB = dt.Rows.Item(i).Item("GSTIFF_KONSB") & "|"
                    GSTIFF_RISGR = dt.Rows.Item(i).Item("GSTIFF_RISGR") & "|"
                    GSTIFF_KONSK = dt.Rows.Item(i).Item("GSTIFF_KONSK") & "|"
                    GSTIFF_WPKNR = dt.Rows.Item(i).Item("GSTIFF_WPKNR") & "|"
                    GSTIFF_GSARE = dt.Rows.Item(i).Item("GSTIFF_GSARE") & "|"
                    GSTIFF_PRDKT = dt.Rows.Item(i).Item("GSTIFF_PRDKT") & "|"
                    GSTIFF_WHIFX = dt.Rows.Item(i).Item("GSTIFF_WHIFX") & "|"
                    GSTIFF_HFZGP = dt.Rows.Item(i).Item("GSTIFF_HFZGP") & "|"
                    GSTIFF_AFREF = dt.Rows.Item(i).Item("GSTIFF_AFREF") & "|"
                    GSTIFF_KZAKL = dt.Rows.Item(i).Item("GSTIFF_KZAKL") & "|"
                    GSTIFF_KONSR = dt.Rows.Item(i).Item("GSTIFF_KONSR") & "|"
                    GSTIFF_FREI1 = dt.Rows.Item(i).Item("GSTIFF_FREI1") & "|"
                    GSTIFF_FREI2 = dt.Rows.Item(i).Item("GSTIFF_FREI2") & "|"
                    GSTIFF_FREI3 = dt.Rows.Item(i).Item("GSTIFF_FREI3") & "|"
                    GSTIFF_FREI4 = dt.Rows.Item(i).Item("GSTIFF_FREI4") & "|"
                    GSTIFF_FREI5 = dt.Rows.Item(i).Item("GSTIFF_FREI5") & "|"
                    GSTIFF_LOEKZ = dt.Rows.Item(i).Item("GSTIFF_LOEKZ") & "|"
                    GSTIFF_IFNAM = dt.Rows.Item(i).Item("GSTIFF_IFNAM") & "|"
                    GSTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTIFF_DXIFD"))

                    CSV_ROW = GSTIFF_MDANT & GSTIFF_FILNR & GSTIFF_MODUL & GSTIFF_KDNRH & GSTIFF_KTONR & GSTIFF_GSREF & GSTIFF_BEZNG & GSTIFF_KOART & GSTIFF_BILKT & GSTIFF_GSKLA & GSTIFF_SUKLA & GSTIFF_GSART & GSTIFF_ULFZT & GSTIFF_WHISO & GSTIFF_VERKZ & GSTIFF_SLDKZ & GSTIFF_KZREV & GSTIFF_WPKNZ & GSTIFF_WPBFN & GSTIFF_HBKZN & GSTIFF_ZWRIS & GSTIFF_KZLST & GSTIFF_HAFIN & GSTIFF_WESTA & GSTIFF_BEZNR & GSTIFF_DXVND & GSTIFF_DXBSD & GSTIFF_MRLFZ & GSTIFF_AUSFL & GSTIFF_DXAUD & GSTIFF_RANGF & GSTIFF_KZUEV & GSTIFF_KFRIS & GSTIFF_DXZAP & GSTIFF_KZVSG & GSTIFF_KZKRU & GSTIFF_KONSB & GSTIFF_RISGR & GSTIFF_KONSK & GSTIFF_WPKNR & GSTIFF_GSARE & GSTIFF_PRDKT & GSTIFF_WHIFX & GSTIFF_HFZGP & GSTIFF_AFREF & GSTIFF_KZAKL & GSTIFF_KONSR & GSTIFF_FREI1 & GSTIFF_FREI2 & GSTIFF_FREI3 & GSTIFF_FREI4 & GSTIFF_FREI5 & GSTIFF_LOEKZ & GSTIFF_IFNAM & GSTIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next

               

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("The following File has being created C:\GSTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTIFF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            MessageBox.Show("Unable to create File GSTIFF_CCB.csv for " & rd & vbNewLine & "There are no data in Table BAIS_GSTIFF for this Date" & vbNewLine & " Please import the related GSTIFF_CCB.csv file for the requested Date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub GSTSLF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_GSTSLF] where [GSTSLF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count <> 0 Then
            Try

                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:GSTSLF_CCB.csv")
                BgwBaisFilesCreation.ReportProgress(2, "Extract Reference in Reference Clear")
                cmd.CommandText = "Update [BAIS_GSTSLF] set [ReferenceClear]=dbo.fn_StripCharacters([GSTSLF_GSREF],'^0-9') where [GSTSLF_MODUL] not in ('SK') and [GSTSLF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Update [BAIS_GSTSLF] set [ReferenceClear]=LEFT([GSTSLF_GSREF],8) where [GSTSLF_MODUL] in ('SK') and [GSTSLF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Set Field GSTSLF_ABGB=0 only for those Contracts with Contract Type=CLDL in CREDIT RISK Report")
                cmd.CommandText = "Update [BAIS_GSTSLF] set [GSTSLF_ABGBT]=0 where [ReferenceClear] in (select [Contract Collateral ID] from [CREDIT RISK] where [Contract Type] in ('CLDL') and [RiskDate]='" & rdsql & "') and [GSTSLF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Update Field GSTSLF_ABGB with accrued Interest from Daily Balance Sheet Details only for those Contracts with Contract Type=CLDL in CREDIT RISK Report")
                cmd.CommandText = "Update A SET A.[GSTSLF_ABGBT]=B.[Orig_Balance] from [BAIS_GSTSLF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]=B.[ReleatedAccountNr] and A.[GSTSLF_DXIFD]=B.[BSDate] where A.[ReferenceClear] in (select [Contract Collateral ID] from [CREDIT RISK] where [Contract Type] in ('CLDL') and [RiskDate]='" & rdsql & "') and RIGHT(B.[GL_Item],1)='I' and A.[GSTSLF_DXIFD]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTSLF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GSTSLF_MDANT|GSTSLF_MODUL|GSTSLF_KDNRH|GSTSLF_KTONR|GSTSLF_GSREF|GSTSLF_SLDUB|GSTSLF_DISPO|GSTSLF_DXDVD|GSTSLF_DXDBD|GSTSLF_ABGBT|GSTSLF_GKBTR|GSTSLF_FAIRV|GSTSLF_IFNAM|GSTSLF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim GSTSLF_MDANT As String = Nothing
                Dim GSTSLF_MODUL As String = Nothing
                Dim GSTSLF_KDNRH As String = Nothing
                Dim GSTSLF_KTONR As String = Nothing
                Dim GSTSLF_GSREF As String = Nothing
                Dim GSTSLF_SLDUB As String = Nothing
                Dim GSTSLF_DISPO As String = Nothing
                Dim GSTSLF_DXDVD As String = Nothing
                Dim GSTSLF_DXDBD As String = Nothing
                Dim GSTSLF_ABGBT As String = Nothing
                Dim GSTSLF_GKBTR As String = Nothing
                Dim GSTSLF_FAIRV As String = Nothing
                Dim GSTSLF_IFNAM As String = Nothing
                Dim GSTSLF_DXIFD As String = Nothing


                If File.Exists(BaisFilesCreationPath & "GSTSLF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSTSLF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSLF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  [GSTSLF_MDANT],[GSTSLF_MODUL],[GSTSLF_KDNRH],[GSTSLF_KTONR],[GSTSLF_GSREF],[GSTSLF_SLDUB],[GSTSLF_DISPO],[GSTSLF_DXDVD],[GSTSLF_DXDBD],[GSTSLF_ABGBT],[GSTSLF_GKBTR],[GSTSLF_FAIRV],[GSTSLF_IFNAM],[GSTSLF_DXIFD] FROM  [BAIS_GSTSLF] where [GSTSLF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in GSTSLF_CCB.csv File: " & dt.Rows.Item(i).Item("GSTSLF_GSREF") & "  " & dt.Rows.Item(i).Item("GSTSLF_KDNRH"))
                    GSTSLF_MDANT = dt.Rows.Item(i).Item("GSTSLF_MDANT") & "|"
                    GSTSLF_MODUL = dt.Rows.Item(i).Item("GSTSLF_MODUL") & "|"
                    GSTSLF_KDNRH = dt.Rows.Item(i).Item("GSTSLF_KDNRH") & "|"
                    GSTSLF_KTONR = dt.Rows.Item(i).Item("GSTSLF_KTONR") & "|"
                    GSTSLF_GSREF = dt.Rows.Item(i).Item("GSTSLF_GSREF") & "|"
                    GSTSLF_SLDUB = dt.Rows.Item(i).Item("GSTSLF_SLDUB").ToString.Replace(",", ".") & "|"
                    GSTSLF_DISPO = dt.Rows.Item(i).Item("GSTSLF_DISPO") & "|"
                    GSTSLF_DXDVD = dt.Rows.Item(i).Item("GSTSLF_DXDVD") & "|"
                    GSTSLF_DXDBD = dt.Rows.Item(i).Item("GSTSLF_DXDBD") & "|"
                    GSTSLF_ABGBT = dt.Rows.Item(i).Item("GSTSLF_ABGBT").ToString.Replace(",", ".") & "|"
                    GSTSLF_GKBTR = dt.Rows.Item(i).Item("GSTSLF_GKBTR") & "|"
                    GSTSLF_FAIRV = dt.Rows.Item(i).Item("GSTSLF_FAIRV") & "|"
                    GSTSLF_IFNAM = dt.Rows.Item(i).Item("GSTSLF_IFNAM") & "|"
                    GSTSLF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTSLF_DXIFD"))

                    CSV_ROW = GSTSLF_MDANT & GSTSLF_MODUL & GSTSLF_KDNRH & GSTSLF_KTONR & GSTSLF_GSREF & GSTSLF_SLDUB & GSTSLF_DISPO & GSTSLF_DXDVD & GSTSLF_DXDBD & GSTSLF_ABGBT & GSTSLF_GKBTR & GSTSLF_FAIRV & GSTSLF_IFNAM & GSTSLF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSLF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("The following File has being created C:\GSTSLF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTSLF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            MessageBox.Show("Unable to create File GSTSLF_CCB.csv for " & rd & vbNewLine & "There are no data in Table BAIS_GSTSLF for this Date" & vbNewLine & " Please import the related GSTSLF_CCB.csv file for the requested Date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub BILIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count <> 0 Then
            Try
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:BILIFF_CCB.csv")
                BgwBaisFilesCreation.ReportProgress(2, "Create temporary table:BILIFF_CCB")
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BILIFF_CCB' AND xtype='U') CREATE TABLE [BILIFF_CCB]([BILIFF_MDANT] [nchar](3) NULL,[GL_Item_Raw] [nvarchar](255) NULL,[BILIFF_BILKT] [float] NULL,[BILIFF_BILBZ] [nvarchar](40) NULL,[BILIFF_SLDKZ] [float] NULL,[BILIFF_IFNAM] [char](10) NULL,[BILIFF_DXIFD] [datetime] NULL)  ELSE DELETE FROM [BILIFF_CCB]"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Insert data to temporary table:BILIFF_CCB")
                cmd.CommandText = "INSERT INTO [BILIFF_CCB]([BILIFF_MDANT],[BILIFF_BILBZ],[GL_Item_Raw],[BILIFF_SLDKZ],[BILIFF_DXIFD]) select 'CCB',LEFT([GL_Item_Name],40) ,[GL_Item],0,'" & rdsql & "'  from   [DailyBalanceSheets] where   [RilibiCode] is not NULL GROUP BY [GL_Item_Name],[GL_Item]"
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Update BILIFF_CCB Set Column BILIFF_BILKT to +01 for Accrued Interest otherwise +00")
                cmd.CommandText = "UPDATE [BILIFF_CCB] set [BILIFF_BILKT]=CASE WHEN RIGHT([GL_Item_Raw],1)='I' then REPLACE([GL_Item_Raw],'I','01') else [GL_Item_Raw]+'00' END "
                cmd.ExecuteNonQuery()
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: BILIFF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "BILIFF_MDANT|BILIFF_BILKT|BILIFF_BILBZ|BILIFF_SLDKZ|BILIFF_IFNAM|BILIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim BILIFF_MDANT As String = Nothing
                Dim BILIFF_BILKT As String = Nothing
                Dim BILIFF_BILBZ As String = Nothing
                Dim BILIFF_SLDKZ As String = Nothing
                Dim BILIFF_IFNAM As String = Nothing
                Dim BILIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "BILIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "BILIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BILIFF_CCB]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in BILIFF_CCB.csv File: " & dt.Rows.Item(i).Item("BILIFF_BILKT") & "  " & dt.Rows.Item(i).Item("BILIFF_BILBZ"))
                    BILIFF_MDANT = dt.Rows.Item(i).Item("BILIFF_MDANT") & "|"
                    BILIFF_BILKT = dt.Rows.Item(i).Item("BILIFF_BILKT") & "|"
                    BILIFF_BILBZ = dt.Rows.Item(i).Item("BILIFF_BILBZ") & "|"
                    BILIFF_SLDKZ = dt.Rows.Item(i).Item("BILIFF_SLDKZ") & "|"
                    BILIFF_IFNAM = dt.Rows.Item(i).Item("BILIFF_IFNAM") & "|"
                    Dim DXIFD_Date As Date = dt.Rows.Item(i).Item("BILIFF_DXIFD")
                    BILIFF_DXIFD = DXIFD_Date.ToString("yyyyMMdd")

                    CSV_ROW = BILIFF_MDANT & BILIFF_BILKT & BILIFF_BILBZ & BILIFF_SLDKZ & BILIFF_IFNAM & BILIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                cmd.CommandText = "DROP TABLE [BILIFF_CCB]"
                cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.BILIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show("Unable to create File BILIFF_CCB.csv for " & rd & vbNewLine & "There are no Balance Sheet Data for this Date" & vbNewLine & " Please update Balance Sheet Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

   

    Private Sub CheckAll_btn_Click(sender As Object, e As EventArgs) Handles CheckAll_btn.Click
        For Each ctrl As Control In Me.GroupControl1.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.CheckEdit Then
                DirectCast(ctrl, DevExpress.XtraEditors.CheckEdit).CheckState = CheckState.Checked
            End If
        Next
    End Sub

    Private Sub BaisExportEvents_RichTextBox_TextChanged(sender As Object, e As EventArgs) Handles BaisExportEvents_RichTextBox.TextChanged
        'Me.BaisExportEvents_RichTextBox.SelectionStart = Me.BaisExportEvents_RichTextBox.Text.Length
        'Me.BaisExportEvents_RichTextBox.ScrollToCaret()

        'Dim EndLine As Long = Len(Me.BaisExportEvents_RichTextBox.Text)
        'Me.BaisExportEvents_RichTextBox.SelectionStart = EndLine
        'Me.BaisExportEvents_RichTextBox.Focus()
       

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

#Region "Example-Change Richedit Line color after selection of each line"
    Private Function ColorForLine(Line As String) As Color
        If Line.Contains("File created with success") Then
            Return Color.Green
        End If
    End Function

    Private Sub Select_Richtextbox_Change_Forecolor_Each_Line()
        Dim i As Integer
        For i = 0 To BaisExportEvents_RichTextBox.Lines.Length - 1

            Dim Text As String = BaisExportEvents_RichTextBox.Lines(i)
            BaisExportEvents_RichTextBox.Select(BaisExportEvents_RichTextBox.GetFirstCharIndexFromLine(i), Text.Length)
            BaisExportEvents_RichTextBox.SelectionColor = ColorForLine(Text)
        Next
    End Sub
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
            MessageBox.Show("Unable to open creation Folder!", "CREATION FOLDER DOES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub
End Class