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

Public Class BaisExportAlphaV125

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim ParameterStatus As String = Nothing
    Dim HasDataResult As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim StartFileCreation_btn_clicked As Boolean = False 'Button for Start Client
    Dim BaisFilesCreationPath As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim DVTIFF_Result As String = Nothing
    Dim GSTIFF_Result As String = Nothing
    Dim GSTSLF_Result As String = Nothing
    Dim BILIFF_Result As String = Nothing
    Dim KGCIFF_Result As String = Nothing
    Dim KNEIFF_Result As String = Nothing
    Dim KNVIFF_Result As String = Nothing
    Dim KRKIFF_Result As String = Nothing
    Dim KSRIFF_Result As String = Nothing
    Dim LQGIFF_Result As String = Nothing
    Dim MKUIFF_Result As String = Nothing
    Dim ZUSIFF_Result As String = Nothing
    Dim GAKIFF_Result As String = Nothing
    Dim GAGIFF_Result As String = Nothing
    Dim LQKIFF_Result As String = Nothing
    Dim DESIFF_Result As String = Nothing
    Dim WHGIFF_Result As String = Nothing
    Dim GSVGAF_Result As String = Nothing
    Dim GSWBIF_Result As String = Nothing

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

    Private Sub BaisExportAlphaV125_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwBaisFilesCreation.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub BaisExportAlphaV125_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Me.GroupControl1.Text = "BAIS Interface Files - Creation Path:" & BaisFilesCreationPath

        'Bind Combobox
        Me.BusinessDate_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' and [PL Result] is not NULL ORDER BY [ID] desc"
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
        Me.KGCIFF_Result_lbl.Text = ""
        Me.KNEIFF_Result_lbl.Text = ""
        Me.KNVIFF_Result_lbl.Text = ""
        Me.KRKIFF_Result_lbl.Text = ""
        Me.KSRIFF_Result_lbl.Text = ""
        Me.LQGIFF_Result_lbl.Text = ""
        Me.MKUIFF_Result_lbl.Text = ""
        Me.ZUSIFF_Result_lbl.Text = ""
        Me.GAKIFF_Result_lbl.Text = ""
        Me.GAGIFF_Result_lbl.Text = ""
        Me.LQKIFF_Result_lbl.Text = ""
        Me.DESIFF_Result_lbl.Text = ""
        Me.WHGIFF_Result_lbl.Text = ""
        Me.GSWBIF_Result_lbl.Text = ""
        Me.StartFileCreation_btn.Enabled = False
        Me.CheckAll_btn.Enabled = False
        Me.OpenFolder_btn.Enabled = False
        Me.BusinessDate_Comboedit.Enabled = False
        Me.GroupControl1.Enabled = False
        Me.BaisExportEvents_RichTextBox.Clear()

    End Sub

    Private Sub ENABLE_FINISH_CREATION()

        StartFileCreation_btn.Enabled = True
        Me.CheckAll_btn.Enabled = True
        Me.OpenFolder_btn.Enabled = True
        Me.BusinessDate_Comboedit.Enabled = True
        Me.GroupControl1.Enabled = True
        Me.DVTIFF_Result_lbl.Text = DVTIFF_Result
        Me.GSTIFF_Result_lbl.Text = GSTIFF_Result
        Me.GSTSLF_Result_lbl.Text = GSTSLF_Result
        Me.BILIFF_Result_lbl.Text = BILIFF_Result
        Me.KGCIFF_Result_lbl.Text = KGCIFF_Result
        Me.KNEIFF_Result_lbl.Text = KNEIFF_Result
        Me.KNVIFF_Result_lbl.Text = KNVIFF_Result
        Me.KRKIFF_Result_lbl.Text = KRKIFF_Result
        Me.KSRIFF_Result_lbl.Text = KSRIFF_Result
        Me.LQGIFF_Result_lbl.Text = LQGIFF_Result
        Me.MKUIFF_Result_lbl.Text = MKUIFF_Result
        Me.ZUSIFF_Result_lbl.Text = ZUSIFF_Result
        Me.GAKIFF_Result_lbl.Text = GAKIFF_Result
        Me.GAGIFF_Result_lbl.Text = GAGIFF_Result
        Me.LQKIFF_Result_lbl.Text = LQKIFF_Result
        Me.DESIFF_Result_lbl.Text = DESIFF_Result
        Me.WHGIFF_Result_lbl.Text = WHGIFF_Result
        Me.GSWBIF_Result_lbl.Text = GSWBIF_Result
        Me.GSVGAF_Result_lbl.Text = GSVGAF_Result
        'Fore Color in Result Labels
        If Me.DVTIFF_Result_lbl.Text = "Not Created" Then
            Me.DVTIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.DVTIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GSTIFF_Result_lbl.Text = "Not Created" Then
            Me.GSTIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GSTIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GSTSLF_Result_lbl.Text = "Not Created" Then
            Me.GSTSLF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GSTSLF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.BILIFF_Result_lbl.Text = "Not Created" Then
            Me.BILIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.BILIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.KGCIFF_Result_lbl.Text = "Not Created" Then
            Me.KGCIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.KGCIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.KNEIFF_Result_lbl.Text = "Not Created" Then
            Me.KNEIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.KNEIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.KNVIFF_Result_lbl.Text = "Not Created" Then
            Me.KNVIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.KNVIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.KRKIFF_Result_lbl.Text = "Not Created" Then
            Me.KRKIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.KRKIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.KSRIFF_Result_lbl.Text = "Not Created" Then
            Me.KSRIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.KSRIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.LQGIFF_Result_lbl.Text = "Not Created" Then
            Me.LQGIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.LQGIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.MKUIFF_Result_lbl.Text = "Not Created" Then
            Me.MKUIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.MKUIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.ZUSIFF_Result_lbl.Text = "Not Created" Then
            Me.ZUSIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.ZUSIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GAKIFF_Result_lbl.Text = "Not Created" Then
            Me.GAKIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GAKIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GAGIFF_Result_lbl.Text = "Not Created" Then
            Me.GAGIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GAGIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.LQKIFF_Result_lbl.Text = "Not Created" Then
            Me.LQKIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.LQKIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.DESIFF_Result_lbl.Text = "Not Created" Then
            Me.DESIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.DESIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.WHGIFF_Result_lbl.Text = "Not Created" Then
            Me.WHGIFF_Result_lbl.ForeColor = Color.Red
        Else
            Me.WHGIFF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GSWBIF_Result_lbl.Text = "Not Created" Then
            Me.GSWBIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GSWBIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.GSVGAF_Result_lbl.Text = "Not Created" Then
            Me.GSVGAF_Result_lbl.ForeColor = Color.Red
        Else
            Me.GSVGAF_Result_lbl.ForeColor = Color.Lime
        End If
    End Sub
#End Region

    Private Sub StartFileCreation_btn_Click(sender As Object, e As EventArgs) Handles StartFileCreation_btn.Click
        StartFileCreation_btn_clicked = True
        If IsDate(Me.BusinessDate_Comboedit.Text) = True Then
            If DVTIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GSTIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GSTSLF_CheckEdit.CheckState = CheckState.Checked OrElse _
                KGCIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                KNEIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                KNVIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                KRKIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                KSRIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                LQGIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                MKUIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                ZUSIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GAKIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GAGIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                LQKIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                DESIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                WHGIFF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GSVGAF_CheckEdit.CheckState = CheckState.Checked OrElse _
                GSWBIF_CheckEdit.CheckState = CheckState.Checked OrElse _
                BILIFF_CheckEdit.CheckState = CheckState.Checked Then
                If XtraMessageBox.Show("Should the BAIS Interface ALPHA Files creation be started?", "START BAIS INTERFACE ALPHA FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_CREATION()
                    rd = Me.BusinessDate_Comboedit.Text
                    rdsql = rd.ToString("yyyyMMdd")
                    'Check if latest BAIS Files Nr is equal with ODAS and OCBS
                    Me.QueryText = "Select 'Result'=Case when (Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('ODAS'))=(Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('OCBS')) and (Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('OCBS'))=(Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('BAIS')) then 'OK' else 'NO' END"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Item(0).Item("Result").ToString = "OK" Then
                        If Me.BgwBaisFilesCreation.IsBusy = False Then
                            Me.BgwBaisFilesCreation.RunWorkerAsync()
                        End If
                    ElseIf dt.Rows.Item(0).Item("Result").ToString = "NO" Then
                        XtraMessageBox.Show("The Last BAIS Interface File is not equal with ODAS and/or OCBS File" & vbNewLine & "The BAIS Interface Files creation is canceled!", "Please check the latest Import data files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ENABLE_FINISH_CREATION()
                        Return

                    End If

                End If
            Else
                XtraMessageBox.Show("Please check at least one File for creation", "NO FILE SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            If KGCIFF_CheckEdit.CheckState = CheckState.Checked Then
                KGCIFF_CREATION()
            End If
            If KNEIFF_CheckEdit.CheckState = CheckState.Checked Then
                KNEIFF_CREATION()
            End If
            If KNVIFF_CheckEdit.CheckState = CheckState.Checked Then
                KNVIFF_CREATION()
            End If
            If KRKIFF_CheckEdit.CheckState = CheckState.Checked Then
                KRKIFF_CREATION()
            End If
            If KSRIFF_CheckEdit.CheckState = CheckState.Checked Then
                KSRIFF_CREATION()
            End If
            If LQGIFF_CheckEdit.CheckState = CheckState.Checked Then
                LQGIFF_CREATION()
            End If
            If MKUIFF_CheckEdit.CheckState = CheckState.Checked Then
                MKUIFF_CREATION()
            End If
            If ZUSIFF_CheckEdit.CheckState = CheckState.Checked Then
                ZUSIFF_CREATION()
            End If
            If GAKIFF_CheckEdit.CheckState = CheckState.Checked Then
                GAKIFF_CREATION()
            End If
            If GAGIFF_CheckEdit.CheckState = CheckState.Checked Then
                GAGIFF_CREATION()
            End If
            If LQKIFF_CheckEdit.CheckState = CheckState.Checked Then
                LQKIFF_CREATION()
            End If
            If DESIFF_CheckEdit.CheckState = CheckState.Checked Then
                DESIFF_CREATION()
            End If
            If WHGIFF_CheckEdit.CheckState = CheckState.Checked Then
                WHGIFF_CREATION()
            End If
            If GSVGAF_CheckEdit.CheckState = CheckState.Checked Then
                GSVGAF_CREATION()
            End If
            If GSWBIF_CheckEdit.CheckState = CheckState.Checked Then
                GSWBIF_CREATION()
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
        'ALPHA
        If Me.DVTIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "DVTIAF File created successfully - " & BaisFilesCreationPath & "DVTIAF_CCB.csv"
        ElseIf Me.DVTIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++DVTIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GSTIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSTIAF File created successfully - " & BaisFilesCreationPath & "GSTIAF_CCB.csv"
        ElseIf Me.GSTIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GSTIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GSTSLF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSTSAF File created successfully - " & BaisFilesCreationPath & "GSTSAF_CCB.csv"
        ElseIf Me.GSTSLF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GSTSAF File NOT CREATED+++"
        End If
        If Me.BILIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "BILIFF File created successfully - " & BaisFilesCreationPath & "BILIFF_CCB.csv"
        ElseIf Me.BILIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++BILIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KGCIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "KGCIAF File created successfully - " & BaisFilesCreationPath & "KGCIAF_CCB.csv"
        ElseIf Me.KGCIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++KGCIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KNEIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "KNEIAF File created successfully - " & BaisFilesCreationPath & "KNEIAF_CCB.csv"
        ElseIf Me.KNEIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++KNEIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KNVIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "KNVIAF File created successfully - " & BaisFilesCreationPath & "KNVIAF_CCB.csv"
        ElseIf Me.KNVIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++KNVIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KRKIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "KRKIAF File created successfully - " & BaisFilesCreationPath & "KRKIAF_CCB.csv"
        ElseIf Me.KRKIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++KRKIAF File NOT CREATED+++"
        End If
        If Me.KSRIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "KSRIFF File created successfully - " & BaisFilesCreationPath & "KSRIFF_CCB.csv"
        ElseIf Me.KSRIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++KSRIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.LQGIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "LQGIAF File created successfully - " & BaisFilesCreationPath & "LQGIAF_CCB.csv"
        ElseIf Me.LQGIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++LQGIAF File NOT CREATED+++"
        End If
        If Me.MKUIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "MKUIFF File created successfully - " & BaisFilesCreationPath & "MKUIFF_CCB.csv"
        ElseIf Me.MKUIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++MKUIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.ZUSIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "ZUSIAF File created successfully - " & BaisFilesCreationPath & "ZUSIAF_CCB.csv"
        ElseIf Me.ZUSIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++ZUSIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GAKIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GAKIAF File created successfully - " & BaisFilesCreationPath & "GAKIAF_CCB.csv"
        ElseIf Me.GAKIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GAKIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GAGIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GAGIAF File created successfully - " & BaisFilesCreationPath & "GAGIAF_CCB.csv"
        ElseIf Me.GAGIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GAGIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.LQKIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "LQKIAF File created successfully - " & BaisFilesCreationPath & "LQKIAF_CCB.csv"
        ElseIf Me.LQKIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++LQKIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.DESIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "DESIAF File created successfully - " & BaisFilesCreationPath & "DESIAF_CCB.csv"
        ElseIf Me.DESIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++DESIAF File NOT CREATED+++"
        End If
        If Me.WHGIFF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "WHGIFF File created successfully - " & BaisFilesCreationPath & "WHGIFF_CCB.csv"
        ElseIf Me.WHGIFF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++WHGIFF File NOT CREATED+++"
        End If
        If Me.GSVGAF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSVGAF File created successfully - " & BaisFilesCreationPath & "GSVGAF_CCB.csv"
        ElseIf Me.GSVGAF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GSVGAF File NOT CREATED+++"
        End If
        If Me.GSWBIF_Result_lbl.Text = "Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "GSWAIF File created successfully - " & BaisFilesCreationPath & "GSWAIF_CCB.csv"
        ElseIf Me.GSWBIF_Result_lbl.Text = "Not Created" Then
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "+++GSWAIF File NOT CREATED+++"
        End If
        ChangeTextcolor("File created with success", Color.DarkCyan, Me.BaisExportEvents_RichTextBox, 0)

        Try
            Using zip As ZipFile = New ZipFile
                For Each File In Directory.GetFiles(BaisFilesCreationPath, "*.CSV", SearchOption.TopDirectoryOnly)
                    zip.AddFile(File, "")
                Next
                zip.Save(BaisFilesCreationPath & "BAIS_Files_ALPHA_v1.25_from_PSTOOL_" & rdsql & ".rar")
                Dim BaisFilesList As String() = Directory.GetFiles(BaisFilesCreationPath, "*.CSV")
                For Each f In BaisFilesList
                    File.Delete(f)
                Next
            End Using
            Me.BaisExportEvents_RichTextBox.Text = Me.BaisExportEvents_RichTextBox.Text & vbNewLine & "File(s) zipped in " & "BAIS_Files_ALPHA_v1.25_from_PSTOOL_" & rdsql & ".rar"
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Unable to zip the created BAIS Files", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
        Me.BaisExportEvents_RichTextBox.HideSelection = True

        TextImportFileRow = Now & "  " & "PS TOOL BAIS EXPORT" & "  " & Me.BaisExportEvents_RichTextBox.Text & "  " & "PS TOOL BAIS EXPORT"
        System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

    End Sub

    Private Sub DVTIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim CountFxDeals As Double = 0
        Dim Count As Double = 0
        'Check if FX Deals present
        cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
        CountFxDeals = cmd.ExecuteScalar
        If CountFxDeals > 0 Then
            'Check if are FX Deals with no Client Nr. indicated
            cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "' and [ClientNo] is  NULL"
            Count = cmd.ExecuteScalar

            If Count = 0 Then
                Try
                    ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    ''SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                    'BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_DVTIFF Table with DVTIFF_DXIFD: " & rd)
                    'cmd.CommandText = "DELETE FROM [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'BgwBaisFilesCreation.ReportProgress(2, "Insert data to temporary table:DVTIFF_CCB")
                    'cmd.CommandText = "INSERT INTO [BAIS_DVTIFF] ([DVTIFF_MDANT],[DVTIFF_GSREF],[DVTIFF_FILNR],[DVTIFF_KDNRH],[DVTIFF_DXABD],[DVTIFF_GSKLA],[DVTIFF_SUKLA],[DVTIFF_DVART],[DVTIFF_DXVAL],[DVTIFF_DANWC],[DVTIFF_DANBT],[DVTIFF_DVKWC],[DVTIFF_DVKBT],[DVTIFF_HBKZN],[DVTIFF_ZWRIS],[DVTIFF_KBTRG],[DVTIFF_PTEIN],[DVTIFF_WHGKP],[DVTIFF_BCHSW],[DVTIFF_BWVNS],[DVTIFF_WHGBU],[DVTIFF_URDEA],[DVTIFF_NETKR],[DVTIFF_KZCVA],[DVTIFF_GSARE],[DVTIFF_FAIRV],[DVTIFF_DXVKT],[DVTIFF_HFZGP],[DVTIFF_AFREF],[DVTIFF_RESE1],[DVTIFF_RESE2],[DVTIFF_FREI1],[DVTIFF_FREI2],[DVTIFF_FREI3],[DVTIFF_LOEKZ],[DVTIFF_IFNAM],[DVTIFF_DXIFD]) Select 'CCB',[ContractNr],'***',[ClientNo],[InputDate],'DV','00',[DealType],[MaturityDate],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],'A','W','0','0','','0','0','','','','J','','','','','','','',[ValueDate],'','','','DVTIFF',[RiskDate] from [FX DAILY REVALUATION] where [DealType] in ('FW','SW','SP') and [RiskDate]='" & rdsql & "' and [MaturityDate]>[RiskDate] order by ID asc"
                    'cmd.ExecuteNonQuery()
                    'BgwBaisFilesCreation.ReportProgress(2, "Update DVTIFF_CCB Set Column DVTIFF_DVART to 1 if SP otherwise 2")
                    'cmd.CommandText = "UPDATE [BAIS_DVTIFF] SET [DVTIFF_DVART]= CASE WHEN [DVTIFF_DVART]='SP' then '1' ELSE '2' END where [DVTIFF_DVART] is not NULL and [DVTIFF_DXIFD]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'BgwBaisFilesCreation.ReportProgress(2, "Set unique reference in Field DVTIFF_GSREF")
                    'cmd.CommandText = "UPDATE [BAIS_DVTIFF]  SET [DVTIFF_GSREF]=[DVTIFF_GSREF] + '-1' where [ID] not in (Select Min([ID]) from [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "' group by  [DVTIFF_GSREF]) and [DVTIFF_DXIFD]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()

                    BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_DVTIFF File for: " & rd)
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_DVTIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText
                            If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End If

                    BgwBaisFilesCreation.ReportProgress(2, "Generating File: DVTIAF_CCB.csv .... Please wait...")
                    'New Code
                    Dim CSV_HEADER As String = "DVTIAF_MDANT|DVTIAF_GSREF|DVTIAF_FILNR|DVTIAF_KDREA|DVTIAF_DXABD|DVTIAF_GSKLA|DVTIAF_SUKLA|DVTIAF_DVART|DVTIAF_DXVAL|DVTIAF_DANWC|DVTIAF_DANBT|DVTIAF_DVKWC|DVTIAF_DVKBT|DVTIAF_HBKZN|DVTIAF_ZWRIS|DVTIAF_KBTRG|DVTIAF_PTEIN|DVTIAF_WHGKP|DVTIAF_BCHSW|DVTIAF_BWVNS|DVTIAF_WHGBU|DVTIAF_URDEA|DVTIAF_NETKR|DVTIAF_KZCVA|DVTIAF_GSARE|DVTIAF_FAIRV|DVTIAF_DXVKT|DVTIAF_HFZGP|DVTIAF_AFREF|DVTIAF_POOLI|DVTIAF_AEIDF|DVTIAF_BESVB|DVTIAF_RESE1|DVTIAF_RESE2|DVTIAF_FREI1|DVTIAF_FREI2|DVTIAF_FREI3|DVTIAF_LOEKZ|DVTIAF_IFNAM|DVTIAF_DXIFD"
                    Dim CSV_ROW As String = Nothing
                    Dim DVTIFF_MDANT As String = Nothing
                    Dim DVTIFF_GSREF As String = Nothing
                    Dim DVTIFF_FILNR As String = Nothing
                    Dim DVTIFF_KDREA As String = Nothing
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
                    Dim DVTIFF_BWVNS As String = Nothing 'New 1.23
                    Dim DVTIFF_WHGBU As String = Nothing
                    Dim DVTIFF_URDEA As String = Nothing
                    Dim DVTIFF_NETKR As String = Nothing
                    Dim DVTIFF_KZCVA As String = Nothing
                    Dim DVTIFF_GSARE As String = Nothing
                    Dim DVTIFF_FAIRV As String = Nothing
                    Dim DVTIFF_DXVKT As String = Nothing
                    Dim DVTIFF_HFZGP As String = Nothing
                    Dim DVTIFF_AFREF As String = Nothing
                    Dim DVTIFF_POOLI As String = Nothing 'New
                    Dim DVTIFF_AEIDF As String = Nothing 'New
                    Dim DVTIFF_BESVB As String = Nothing 'New
                    Dim DVTIFF_RESE1 As String = Nothing
                    Dim DVTIFF_RESE2 As String = Nothing
                    Dim DVTIFF_FREI1 As String = Nothing
                    Dim DVTIFF_FREI2 As String = Nothing
                    Dim DVTIFF_FREI3 As String = Nothing
                    Dim DVTIFF_LOEKZ As String = Nothing
                    Dim DVTIFF_IFNAM As String = Nothing
                    Dim DVTIFF_DXIFD As String = Nothing

                    If File.Exists(BaisFilesCreationPath & "DVTIAF_CCB.csv") = True Then
                        File.Delete(BaisFilesCreationPath & "DVTIAF_CCB.csv")
                    End If
                    'Create Header
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_HEADER & vbCrLf)
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
                        DVTIFF_KDREA = dt.Rows.Item(i).Item("DVTIFF_KDNRH") & "|"
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
                        DVTIFF_BWVNS = dt.Rows.Item(i).Item("DVTIFF_BWVNS") & "|" ' New 1.23
                        DVTIFF_WHGBU = dt.Rows.Item(i).Item("DVTIFF_WHGBU") & "|"
                        DVTIFF_URDEA = dt.Rows.Item(i).Item("DVTIFF_URDEA") & "|"
                        DVTIFF_NETKR = dt.Rows.Item(i).Item("DVTIFF_NETKR") & "|"
                        DVTIFF_KZCVA = dt.Rows.Item(i).Item("DVTIFF_KZCVA") & "|"
                        DVTIFF_GSARE = dt.Rows.Item(i).Item("DVTIFF_GSARE") & "|"
                        DVTIFF_FAIRV = dt.Rows.Item(i).Item("DVTIFF_FAIRV") & "|"
                        DVTIFF_DXVKT = dt.Rows.Item(i).Item("DVTIFF_DXVKT") & "|"
                        DVTIFF_HFZGP = dt.Rows.Item(i).Item("DVTIFF_HFZGP") & "|"
                        DVTIFF_AFREF = dt.Rows.Item(i).Item("DVTIFF_AFREF") & "|"
                        DVTIFF_POOLI = dt.Rows.Item(i).Item("DVTIFF_POOLI") & "|"
                        DVTIFF_AEIDF = dt.Rows.Item(i).Item("DVTIFF_AEIDF") & "|"
                        DVTIFF_BESVB = dt.Rows.Item(i).Item("DVTIFF_BESVB") & "|"
                        DVTIFF_RESE1 = dt.Rows.Item(i).Item("DVTIFF_RESE1") & "|"
                        DVTIFF_RESE2 = dt.Rows.Item(i).Item("DVTIFF_RESE2") & "|"
                        DVTIFF_FREI1 = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_FREI1")) & "|"
                        DVTIFF_FREI2 = dt.Rows.Item(i).Item("DVTIFF_FREI2") & "|"
                        DVTIFF_FREI3 = dt.Rows.Item(i).Item("DVTIFF_FREI3") & "|"
                        DVTIFF_LOEKZ = dt.Rows.Item(i).Item("DVTIFF_LOEKZ") & "|"
                        DVTIFF_IFNAM = "DVTIAF" & "|"
                        DVTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_DXIFD"))

                        CSV_ROW = DVTIFF_MDANT & DVTIFF_GSREF & DVTIFF_FILNR & DVTIFF_KDREA & DVTIFF_DXABD & DVTIFF_GSKLA & DVTIFF_SUKLA & DVTIFF_DVART & DVTIFF_DXVAL & DVTIFF_DANWC & DVTIFF_DANBT & DVTIFF_DVKWC & DVTIFF_DVKBT & DVTIFF_HBKZN & DVTIFF_ZWRIS & DVTIFF_KBTRG & DVTIFF_PTEIN & DVTIFF_WHGKP & DVTIFF_BCHSW & DVTIFF_BWVNS & DVTIFF_WHGBU & DVTIFF_URDEA & DVTIFF_NETKR & DVTIFF_KZCVA & DVTIFF_GSARE & DVTIFF_FAIRV & DVTIFF_DXVKT & DVTIFF_HFZGP & DVTIFF_AFREF & DVTIFF_POOLI & DVTIFF_AEIDF & DVTIFF_BESVB & DVTIFF_RESE1 & DVTIFF_RESE2 & DVTIFF_FREI1 & DVTIFF_FREI2 & DVTIFF_FREI3 & DVTIFF_LOEKZ & DVTIFF_IFNAM & DVTIFF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_ROW & vbCrLf)
                    Next

                    'cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                    'cmd.ExecuteNonQuery()

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    'SplashScreenManager.CloseForm(False)
                    'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.DVTIFF_Result = "Created"

                Catch ex As System.Exception
                    'SplashScreenManager.CloseForm(False)
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            Else
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.DVTIFF_Result = "Not Created"
                Dim CSV_HEADER As String = "DVTIAF_MDANT|DVTIAF_GSREF|DVTIAF_FILNR|DVTIAF_KDREA|DVTIAF_DXABD|DVTIAF_GSKLA|DVTIAF_SUKLA|DVTIAF_DVART|DVTIAF_DXVAL|DVTIAF_DANWC|DVTIAF_DANBT|DVTIAF_DVKWC|DVTIAF_DVKBT|DVTIAF_HBKZN|DVTIAF_ZWRIS|DVTIAF_KBTRG|DVTIAF_PTEIN|DVTIAF_WHGKP|DVTIAF_BCHSW|DVTIAF_BWVNS|DVTIAF_WHGBU|DVTIAF_URDEA|DVTIAF_NETKR|DVTIAF_KZCVA|DVTIAF_GSARE|DVTIAF_FAIRV|DVTIAF_DXVKT|DVTIAF_HFZGP|DVTIAF_AFREF|DVTIAF_POOLI|DVTIAF_AEIDF|DVTIAF_BESVB|DVTIAF_RESE1|DVTIAF_RESE2|DVTIAF_FREI1|DVTIAF_FREI2|DVTIAF_FREI3|DVTIAF_LOEKZ|DVTIAF_IFNAM|DVTIAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "DVTIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DVTIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show("Unable to create File DVTIAF_CCB.csv for " & rd & vbNewLine & "There are FX Deals with no Client Nr. in the Database for this Date" & vbNewLine & " Please update Client Nr for all FX Deals in order to create the requested csv file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.DVTIFF_Result = "Not Created"
            XtraMessageBox.Show("Unable to create File DVTIFF_CCB.csv for " & rd & vbNewLine & "There are no FX Deals in the Database for this Date", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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


        If Count > 0 Then
            Try

                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:GSTIFF_CCB.csv")
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='100',[GSTIFF_BILKT]='100',[ReferenceClear]=NULL where [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Extract Reference in Reference Clear")
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=dbo.fn_StripCharacters(dbo.GetStringPartByDelimeter([GSTIFF_GSREF],'-',1),'^0-9') where  [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=dbo.fn_StripCharacters([GSTIFF_GSREF],'^0-9') where [GSTIFF_MODUL] not in ('SK') and [GSTIFF_DXIFD]='" & rdsql & "'"
                ''cmd.ExecuteNonQuery()
                ''cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=LEFT([GSTIFF_GSREF],8) where [GSTIFF_MODUL] in ('SK') and [GSTIFF_DXIFD]='" & rdsql & "'"
                ''cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update GL Item from DailyBalanceDetailsSheet")
                'cmd.CommandText = "Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[ReleatedAccountNr] and A.[GSTIFF_WHISO]=B.[Orig_CUR] and A.[GSTIFF_DXIFD]=B.[BSDate] and B.[GL_Item] not like '%I' and A.[GSTIFF_MODUL] not in ('SK','CA') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[ReleatedAccountNr] and A.[GSTIFF_WHISO]=B.[Orig_CUR] and A.[GSTIFF_DXIFD]=B.[BSDate] and B.[GL_Item] not like '%I' and A.[GSTIFF_MODUL] in ('CA','LN') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='3500' where [GSTIFF_MODUL] in ('CA') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='500' where [GSTIFF_KOART] in ('NOSTRO') and [GSTIFF_MODUL] in ('IB') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GL_Item_Basic]='2010' where [GSTIFF_KOART] in ('SECUR') and [GSTIFF_MODUL] in ('FI') and [GL_Item_Basic]='100' and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update A set A.[GL_Item_Basic]=B.[GL_Item] from [BAIS_GSTIFF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]= B.[GL_Account_Nr] and A.[GSTIFF_DXIFD]=B.[BSDate] and A.[GSTIFF_MODUL] in ('SK') where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Set all Acrued Interest with +01 otherwise +00")
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]=[GL_Item_Basic]+'00' where [GL_Item_Basic] not like '%I' and [GL_Item_Basic] not in ('100') and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]=REPLACE([GL_Item_Basic],'I','01') where [GL_Item_Basic] like '%I' and [GL_Item_Basic] not in ('100') and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Set BAIS Specific GL Item Nr.to 50000 for GL Items 51900,50000")
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]='50000' where [GSTIFF_BILKT] in ('51900','50000') and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Set BAIS Specific GL Item Nr.to 350000 for GL Items 300000,301900 and 350000")
                'cmd.CommandText = "Update [BAIS_GSTIFF] set [GSTIFF_BILKT]='350000' where [GSTIFF_BILKT] in ('300000','301900','350000') and [GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''Set GSTIFF_GSART=FO where Product Type is FORFTIB
                'BgwBaisFilesCreation.ReportProgress(2, "Set GSTIFF_GSART=FO and GSTIFF_HAFIN=J where Product Type is FORFTIB")
                'cmd.CommandText = "Update A set A.[GSTIFF_GSART]='FO',A.[GSTIFF_HAFIN]='J' from [BAIS_GSTIFF] A INNER JOIN [MAK REPORT] B ON A.[ReferenceClear]= B.[Contract Collateral ID] and A.[GSTIFF_DXIFD]=B.[RiskDate] where B.[Product Type] in ('FORFTIB') and A.[GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''SET ISIN Code for SECURITIES
                'cmd.CommandText = "UPDATE A SET A.GSTIFF_WPKNR=B.ISIN from BAIS_GSTIFF A INNER JOIN SECURITIES_OUR B on A.ReferenceClear=B.ContractNrOCBS where A.[GSTIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSTIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSTIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.24'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTIFF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GSTIAF_MDANT|GSTIAF_FILNR|GSTIAF_MODUL|GSTIAF_KDREA|GSTIAF_KTONR|GSTIAF_GSREF|GSTIAF_BEZNG|GSTIAF_KOART|GSTIAF_BILKT|GSTIAF_GSKLA|GSTIAF_SUKLA|GSTIAF_GSART|GSTIAF_ULFZT|GSTIAF_WHISO|GSTIAF_VERKZ|GSTIAF_SLDKZ|GSTIAF_KZREV|GSTIAF_WPKNZ|GSTIAF_WPBFN|GSTIAF_HBKZN|GSTIAF_ZWRIS|GSTIAF_KZLST|GSTIAF_HAFIN|GSTIAF_WESTA|GSTIAF_BEZNR|GSTIAF_DXVND|GSTIAF_DXBSD|GSTIAF_MRLFZ|GSTIAF_AUSFL|GSTIAF_DXAUD|GSTIAF_RANGF|GSTIAF_KZUEV|GSTIAF_KFRIS|GSTIAF_DXZAP|GSTIAF_KZVSG|GSTIAF_KZKRU|GSTIAF_KONSB|GSTIAF_RISGR|GSTIAF_KONSK|GSTIAF_WPKNR|GSTIAF_GSARE|GSTIAF_PRDKT|GSTIAF_WHIFX|GSTIAF_HFZGP|GSTIAF_AFREF|GSTIAF_KZAKL|GSTIAF_KONSR|GSTIAF_NOTBF|GSTIAF_POOLI|GSTIAF_AEIDF|GSTIAF_KZGSV|GSTIAF_MRELV|GSTIAF_APKNZ|GSTIAF_FREI1|GSTIAF_FREI2|GSTIAF_FREI3|GSTIAF_FREI4|GSTIAF_FREI5|GSTIAF_LOEKZ|GSTIAF_IFNAM|GSTIAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim GSTIFF_MDANT As String = Nothing
                Dim GSTIFF_FILNR As String = Nothing
                Dim GSTIFF_MODUL As String = Nothing
                Dim GSTIFF_KDREA As String = Nothing
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
                Dim GSTIFF_NOTBF As String = Nothing 'New
                Dim GSTIFF_POOLI As String = Nothing 'New
                Dim GSTIFF_AEIDF As String = Nothing 'New
                Dim GSTIFF_KZGSV As String = Nothing 'New 1.23
                Dim GSTIFF_MRELV As String = Nothing 'New 1.23
                Dim GSTIFF_APKNZ As String = Nothing 'New 1.23
                Dim GSTIFF_FREI1 As String = Nothing
                Dim GSTIFF_FREI2 As String = Nothing
                Dim GSTIFF_FREI3 As String = Nothing
                Dim GSTIFF_FREI4 As String = Nothing
                Dim GSTIFF_FREI5 As String = Nothing
                Dim GSTIFF_LOEKZ As String = Nothing
                Dim GSTIFF_IFNAM As String = Nothing
                Dim GSTIFF_DXIFD As String = Nothing


                If File.Exists(BaisFilesCreationPath & "GSTIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSTIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                BgwBaisFilesCreation.ReportProgress(2, "Exclude Data from BAIS_GSTIAF where GSTIFF_DXVND > " & rd)
                cmd.CommandText = "Select Count([ID]) from [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "' and [GSTIFF_DXVND]> '" & rdsql & "'"
                Dim ExcludeCount As Double = cmd.ExecuteScalar
                BgwBaisFilesCreation.ReportProgress(2, "Excluded Datarows: " & ExcludeCount)

                Me.QueryText = "SELECT * FROM  [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "' and [GSTIFF_DXVND]<= '" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in GSTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("GSTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("GSTIFF_KDNRH"))
                    GSTIFF_MDANT = dt.Rows.Item(i).Item("GSTIFF_MDANT") & "|"
                    GSTIFF_FILNR = dt.Rows.Item(i).Item("GSTIFF_FILNR") & "|"
                    GSTIFF_MODUL = dt.Rows.Item(i).Item("GSTIFF_MODUL") & "|"
                    GSTIFF_KDREA = dt.Rows.Item(i).Item("GSTIFF_KDNRH") & "|"
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
                    GSTIFF_NOTBF = dt.Rows.Item(i).Item("GSTIFF_NOTBF") & "|" 'New
                    GSTIFF_POOLI = dt.Rows.Item(i).Item("GSTIFF_POOLI") & "|" 'New
                    GSTIFF_AEIDF = dt.Rows.Item(i).Item("GSTIFF_AEIDF") & "|" 'New
                    GSTIFF_KZGSV = dt.Rows.Item(i).Item("GSTIFF_KZGSV") & "|" 'New 1.23
                    GSTIFF_MRELV = dt.Rows.Item(i).Item("GSTIFF_MRELV") & "|" 'New 1.23
                    GSTIFF_APKNZ = dt.Rows.Item(i).Item("GSTIFF_APKNZ") & "|" 'New 1.23
                    GSTIFF_FREI1 = dt.Rows.Item(i).Item("GSTIFF_FREI1") & "|"
                    GSTIFF_FREI2 = dt.Rows.Item(i).Item("GSTIFF_FREI2") & "|"
                    GSTIFF_FREI3 = dt.Rows.Item(i).Item("GSTIFF_FREI3") & "|"
                    GSTIFF_FREI4 = dt.Rows.Item(i).Item("GSTIFF_FREI4") & "|"
                    GSTIFF_FREI5 = dt.Rows.Item(i).Item("GSTIFF_FREI5") & "|"
                    GSTIFF_LOEKZ = dt.Rows.Item(i).Item("GSTIFF_LOEKZ") & "|"
                    GSTIFF_IFNAM = "GSTIAF" & "|"
                    GSTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTIFF_DXIFD"))

                    CSV_ROW = GSTIFF_MDANT & GSTIFF_FILNR & GSTIFF_MODUL & GSTIFF_KDREA & GSTIFF_KTONR & GSTIFF_GSREF & GSTIFF_BEZNG & GSTIFF_KOART & GSTIFF_BILKT & GSTIFF_GSKLA & GSTIFF_SUKLA & GSTIFF_GSART & GSTIFF_ULFZT & GSTIFF_WHISO & GSTIFF_VERKZ & GSTIFF_SLDKZ & GSTIFF_KZREV & GSTIFF_WPKNZ & GSTIFF_WPBFN & GSTIFF_HBKZN & GSTIFF_ZWRIS & GSTIFF_KZLST & GSTIFF_HAFIN & GSTIFF_WESTA & GSTIFF_BEZNR & GSTIFF_DXVND & GSTIFF_DXBSD & GSTIFF_MRLFZ & GSTIFF_AUSFL & GSTIFF_DXAUD & GSTIFF_RANGF & GSTIFF_KZUEV & GSTIFF_KFRIS & GSTIFF_DXZAP & GSTIFF_KZVSG & GSTIFF_KZKRU & GSTIFF_KONSB & GSTIFF_RISGR & GSTIFF_KONSK & GSTIFF_WPKNR & GSTIFF_GSARE & GSTIFF_PRDKT & GSTIFF_WHIFX & GSTIFF_HFZGP & GSTIFF_AFREF & GSTIFF_KZAKL & GSTIFF_KONSR & GSTIFF_NOTBF & GSTIFF_POOLI & GSTIFF_AEIDF & GSTIFF_KZGSV & GSTIFF_MRELV & GSTIFF_APKNZ & GSTIFF_FREI1 & GSTIFF_FREI2 & GSTIFF_FREI3 & GSTIFF_FREI4 & GSTIFF_FREI5 & GSTIFF_LOEKZ & GSTIFF_IFNAM & GSTIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\GSTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTIFF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            Me.GSTIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "GSTIAF_MDANT|GSTIAF_FILNR|GSTIAF_MODUL|GSTIAF_KDREA|GSTIAF_KTONR|GSTIAF_GSREF|GSTIAF_BEZNG|GSTIAF_KOART|GSTIAF_BILKT|GSTIAF_GSKLA|GSTIAF_SUKLA|GSTIAF_GSART|GSTIAF_ULFZT|GSTIAF_WHISO|GSTIAF_VERKZ|GSTIAF_SLDKZ|GSTIAF_KZREV|GSTIAF_WPKNZ|GSTIAF_WPBFN|GSTIAF_HBKZN|GSTIAF_ZWRIS|GSTIAF_KZLST|GSTIAF_HAFIN|GSTIAF_WESTA|GSTIAF_BEZNR|GSTIAF_DXVND|GSTIAF_DXBSD|GSTIAF_MRLFZ|GSTIAF_AUSFL|GSTIAF_DXAUD|GSTIAF_RANGF|GSTIAF_KZUEV|GSTIAF_KFRIS|GSTIAF_DXZAP|GSTIAF_KZVSG|GSTIAF_KZKRU|GSTIAF_KONSB|GSTIAF_RISGR|GSTIAF_KONSK|GSTIAF_WPKNR|GSTIAF_GSARE|GSTIAF_PRDKT|GSTIAF_WHIFX|GSTIAF_HFZGP|GSTIAF_AFREF|GSTIAF_KZAKL|GSTIAF_KONSR|GSTIAF_NOTBF|GSTIAF_POOLI|GSTIAF_AEIDF|GSTIAF_KZGSV|GSTIAF_MRELV|GSTIAF_APKNZ|GSTIAF_FREI1|GSTIAF_FREI2|GSTIAF_FREI3|GSTIAF_FREI4|GSTIAF_FREI5|GSTIAF_LOEKZ|GSTIAF_IFNAM|GSTIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSTIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSTIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSTIAF_CCB.csv for " & rd & vbNewLine & "There are no data in Table BAIS_GSTIFF for this Date" & vbNewLine & "Please check original BAIS File for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:GSTSLF_CCB.csv")
                'BgwBaisFilesCreation.ReportProgress(2, "Extract Reference in Reference Clear")
                'cmd.CommandText = "Update [BAIS_GSTSLF] set [ReferenceClear]=dbo.fn_StripCharacters(dbo.GetStringPartByDelimeter([GSTSLF_GSREF],'-',1),'^0-9') where  [GSTSLF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Set Field GSTSLF_ABGB=0 only for those Contracts with Contract Type=CLDL in CREDIT RISK Report")
                'cmd.CommandText = "Update [BAIS_GSTSLF] set [GSTSLF_ABGBT]=0 where [ReferenceClear] in (select [Contract Collateral ID] from [CREDIT RISK] where [Contract Type] in ('CLDL') and [RiskDate]='" & rdsql & "') and [GSTSLF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update Field GSTSLF_ABGB with accrued Interest from Daily Balance Sheet Details only for those Contracts with Contract Type=CLDL in CREDIT RISK Report")
                'cmd.CommandText = "Update A SET A.[GSTSLF_ABGBT]=B.[Orig_Balance] from [BAIS_GSTSLF] A INNER JOIN [DailyBalanceDetailsSheets] B ON A.[ReferenceClear]=B.[ReleatedAccountNr] and A.[GSTSLF_DXIFD]=B.[BSDate] where A.[ReferenceClear] in (select [Contract Collateral ID] from [CREDIT RISK] where [Contract Type] in ('CLDL') and [RiskDate]='" & rdsql & "') and RIGHT(B.[GL_Item],1)='I' and A.[GSTSLF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSTSLF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSTSLF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTSAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GSTSAF_MDANT|GSTSAF_MODUL|GSTSAF_KDREA|GSTSAF_KTONR|GSTSAF_GSREF|GSTSAF_SLDUB|GSTSAF_DISPO|GSTSAF_DXDVD|GSTSAF_DXDBD|GSTSAF_ABGBT|GSTSAF_GKBTR|GSTSAF_FAIRV|GSTSAF_ERFBT|GSTSAF_BETNF|GSTSAF_DAGIO|GSTSAF_IFNAM|GSTSAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim GSTSLF_MDANT As String = Nothing
                Dim GSTSLF_MODUL As String = Nothing
                Dim GSTSLF_KDREA As String = Nothing
                Dim GSTSLF_KTONR As String = Nothing
                Dim GSTSLF_GSREF As String = Nothing
                Dim GSTSLF_SLDUB As String = Nothing
                Dim GSTSLF_DISPO As String = Nothing
                Dim GSTSLF_DXDVD As String = Nothing
                Dim GSTSLF_DXDBD As String = Nothing
                Dim GSTSLF_ABGBT As String = Nothing
                Dim GSTSLF_GKBTR As String = Nothing
                Dim GSTSLF_FAIRV As String = Nothing
                Dim GSTSLF_ERFBT As String = Nothing 'New
                Dim GSTSLF_BETNF As String = Nothing 'New 1.25
                Dim GSTSLF_DAGIO As String = Nothing 'New 1.25
                Dim GSTSLF_IFNAM As String = Nothing
                Dim GSTSLF_DXIFD As String = Nothing


                If File.Exists(BaisFilesCreationPath & "GSTSAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSTSAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_GSTSLF] where [GSTSLF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in GSTSLF_CCB.csv File: " & dt.Rows.Item(i).Item("GSTSLF_GSREF") & "  " & dt.Rows.Item(i).Item("GSTSLF_KDNRH"))
                    GSTSLF_MDANT = dt.Rows.Item(i).Item("GSTSLF_MDANT") & "|"
                    GSTSLF_MODUL = dt.Rows.Item(i).Item("GSTSLF_MODUL") & "|"
                    GSTSLF_KDREA = dt.Rows.Item(i).Item("GSTSLF_KDNRH") & "|"
                    GSTSLF_KTONR = dt.Rows.Item(i).Item("GSTSLF_KTONR") & "|"
                    GSTSLF_GSREF = dt.Rows.Item(i).Item("GSTSLF_GSREF") & "|"
                    GSTSLF_SLDUB = dt.Rows.Item(i).Item("GSTSLF_SLDUB").ToString.Replace(",", ".") & "|"
                    GSTSLF_DISPO = dt.Rows.Item(i).Item("GSTSLF_DISPO") & "|"
                    GSTSLF_DXDVD = dt.Rows.Item(i).Item("GSTSLF_DXDVD") & "|"
                    GSTSLF_DXDBD = dt.Rows.Item(i).Item("GSTSLF_DXDBD") & "|"
                    GSTSLF_ABGBT = dt.Rows.Item(i).Item("GSTSLF_ABGBT").ToString.Replace(",", ".") & "|"
                    GSTSLF_GKBTR = dt.Rows.Item(i).Item("GSTSLF_GKBTR") & "|"
                    GSTSLF_FAIRV = dt.Rows.Item(i).Item("GSTSLF_FAIRV") & "|"
                    GSTSLF_ERFBT = dt.Rows.Item(i).Item("GSTSLF_ERFBT").ToString.Replace(",", ".") & "|"
                    GSTSLF_BETNF = dt.Rows.Item(i).Item("GSTSLF_BETNF").ToString.Replace(",", ".") & "|"
                    GSTSLF_DAGIO = dt.Rows.Item(i).Item("GSTSLF_DAGIO").ToString.Replace(",", ".") & "|"
                    GSTSLF_IFNAM = "GSTSAF" & "|"
                    GSTSLF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTSLF_DXIFD"))

                    CSV_ROW = GSTSLF_MDANT & GSTSLF_MODUL & GSTSLF_KDREA & GSTSLF_KTONR & GSTSLF_GSREF & GSTSLF_SLDUB & GSTSLF_DISPO & GSTSLF_DXDVD & GSTSLF_DXDBD & GSTSLF_ABGBT & GSTSLF_GKBTR & GSTSLF_FAIRV & GSTSLF_ERFBT & GSTSLF_BETNF & GSTSLF_DAGIO & GSTSLF_IFNAM & GSTSLF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\GSTSLF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTSLF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.GSTSLF_Result = "Not Created"
            Dim CSV_HEADER As String = "GSTSAF_MDANT|GSTSAF_MODUL|GSTSAF_KDREA|GSTSAF_KTONR|GSTSAF_GSREF|GSTSAF_SLDUB|GSTSAF_DISPO|GSTSAF_DXDVD|GSTSAF_DXDBD|GSTSAF_ABGBT|GSTSAF_GKBTR|GSTSAF_FAIRV|GSTSAF_ERFBT|GSTSAF_BETNF|GSTSAF_DAGIO|GSTSAF_IFNAM|GSTSAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSTSAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSTSAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSTSAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File GSTSLF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub 'OK

    Private Sub BILIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count <> 0 Then
            Try
                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS File:BILIFF_CCB.csv")
                'BgwBaisFilesCreation.ReportProgress(2, "Create temporary table:BILIFF_CCB")
                'cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BILIFF_CCB' AND xtype='U') CREATE TABLE [BILIFF_CCB]([ID] [int] IDENTITY(1,1) NOT NULL,[BILIFF_MDANT] [nchar](3) NULL,[GL_Item_Raw] [nvarchar](255) NULL,[BILIFF_BILKT] [float] NULL,[BILIFF_BILBZ] [nvarchar](40) NULL,[BILIFF_SLDKZ] [float] NULL,[BILIFF_IFNAM] [char](10) NULL,[BILIFF_DXIFD] [datetime] NULL)  ELSE DELETE FROM [BILIFF_CCB]"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Insert data to temporary table:BILIFF_CCB")
                'cmd.CommandText = "INSERT INTO [BILIFF_CCB]([BILIFF_MDANT],[BILIFF_BILBZ],[GL_Item_Raw],[BILIFF_SLDKZ],[BILIFF_DXIFD]) select 'CCB',LEFT([GL_Item_Name],40) ,[GL_Item],0,'" & rdsql & "'  from   [DailyBalanceSheets] where   [RilibiCode] is not NULL  and ISNUMERIC([GL_Item_Name])=0 and [GL_Item_Name] is not NULL and [GL_Item] is not NULL GROUP BY [GL_Item_Name],[GL_Item]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [BILIFF_CCB]([BILIFF_MDANT],[BILIFF_BILBZ],[GL_Item_Raw],[BILIFF_SLDKZ],[BILIFF_DXIFD]) select 'CCB',LEFT([GL_Item_Name],40) ,[GL_Item],0,'" & rdsql & "'  from   [DailyBalanceSheets] where   [RilibiCode] is NULL  and ISNUMERIC([GL_Item_Name])=0 and [GL_Item_Name] is not NULL and [GL_Item] is not NULL and [GL_Item] not in (Select [GL_Item_Raw] from [BILIFF_CCB])  GROUP BY [GL_Item_Name],[GL_Item]"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BILIFF_CCB Set Column BILIFF_BILKT to +01 for Accrued Interest otherwise +00")
                'cmd.CommandText = "UPDATE [BILIFF_CCB] set [BILIFF_BILKT]=CASE WHEN RIGHT([GL_Item_Raw],1)='I' then REPLACE([GL_Item_Raw],'I','01') else [GL_Item_Raw]+'00' END "
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Delete Duplicates in BILIFF based on Field:BILIFF_BILKT")
                'cmd.CommandText = "DELETE  FROM [BILIFF_CCB] where [ID] not in (Select Min([ID]) from [BILIFF_CCB] group by [BILIFF_BILKT])"
                'cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_BILIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_BILIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

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
                Me.QueryText = "SELECT  * FROM  [BILIFF_CCB] ORDER BY [BILIFF_BILKT] asc"
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
                cmd.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DROP TABLE [BILIFF_CCB]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.BILIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.BILIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "BILIFF_MDANT|BILIFF_BILKT|BILIFF_BILBZ|BILIFF_SLDKZ|BILIFF_IFNAM|BILIFF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "BILIFF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "BILIFF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File BILIFF_CCB.csv for " & rd & vbNewLine & "There are no Balance Sheet Data for this Date" & vbNewLine & " Please update Balance Sheet Data", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub KGCIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        'BgwBaisFilesCreation.ReportProgress(1, "Executing SQL Procedure BAIS_KGCIFF_Update - Insert correct data from FRISTEN...Please wait...")
        'cmd.CommandText = "EXEC [BAIS_KGCIFF_Update] @RISKDATE='" & rdsql & "'"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Mortgage Loans correction...")
        'BgwBaisFilesCreation.ReportProgress(1, "Delete from BAIS_KGCIFF all Data on which GSREF is PHML...")
        'BgwBaisFilesCreation.ReportProgress(1, "Insert into BAIS_KGCIFF from FRISTEN only Data with Product Type:PHML...")
        'BgwBaisFilesCreation.ReportProgress(1, "Commercial and Syndicated Loans correction...")
        'BgwBaisFilesCreation.ReportProgress(1, "Delete from BAIS_KGCIFF all Data on which GSREF is SYFTDD and BLFTDD...")
        'BgwBaisFilesCreation.ReportProgress(1, "Insert into BAIS_KGCIFF from FRISTEN only Data with Product Type:SYFTDD and BLFTDD ...")
        'BgwBaisFilesCreation.ReportProgress(1, "Insert Interest Swaps in BAIS_KGCIFF...")
        'BgwBaisFilesCreation.ReportProgress(1, "Insert into BAIS_KGCIFF from FRISTEN only Data with Contract Type:SWAP , Product Type:IR , Amount Type:Interest ...")

        BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KGCIFF File for: " & rd)
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KGCIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If

        cmd.CommandText = "Select Count([ID]) from [BAIS_KGCIFF] where [KGCIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KGCIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "KGCIAF_MDANT|KGCIAF_MODUL|KGCIAF_KDREA|KGCIAF_KTONR|KGCIAF_GSREF|KGCIAF_ACCNR|KGCIAF_PTYPI|KGCIAF_CURCD|KGCIAF_DXBEW|KGCIAF_ERART|KGCIAF_HOEHE|KGCIAF_SALDO|KGCIAF_TILGA|KGCIAF_ZINSA|KGCIAF_WHISO|KGCIAF_KZABL|KGCIAF_POOLI|KGCIAF_IFNAM|KGCIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim KGCIFF_MDANT As String = Nothing
                Dim KGCIFF_MODUL As String = Nothing
                Dim KGCIFF_KDREA As String = Nothing
                Dim KGCIFF_KTONR As String = Nothing
                Dim KGCIFF_GSREF As String = Nothing
                Dim KGCIFF_ACCNR As String = Nothing
                Dim KGCIFF_PTYPI As String = Nothing
                Dim KGCIFF_CURCD As String = Nothing
                Dim KGCIFF_DXBEW As String = Nothing
                Dim KGCIFF_ERART As String = Nothing
                Dim KGCIFF_HOEHE As String = Nothing
                Dim KGCIFF_SALDO As String = Nothing
                Dim KGCIFF_TILGA As String = Nothing
                Dim KGCIFF_ZINSA As String = Nothing
                Dim KGCIFF_WHISO As String = Nothing
                Dim KGCIFF_KZABL As String = Nothing 'New
                Dim KGCIFF_POOLI As String = Nothing 'New
                Dim KGCIFF_IFNAM As String = Nothing
                Dim KGCIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "KGCIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KGCIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KGCIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_KGCIFF] where [KGCIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    KGCIFF_MDANT = dt.Rows.Item(i).Item("KGCIFF_MDANT") & "|"
                    KGCIFF_MODUL = dt.Rows.Item(i).Item("KGCIFF_MODUL") & "|"
                    KGCIFF_KDREA = dt.Rows.Item(i).Item("KGCIFF_KDNRH") & "|"
                    KGCIFF_KTONR = dt.Rows.Item(i).Item("KGCIFF_KTONR") & "|"
                    KGCIFF_GSREF = dt.Rows.Item(i).Item("KGCIFF_GSREF") & "|"
                    KGCIFF_ACCNR = dt.Rows.Item(i).Item("KGCIFF_ACCNR") & "|"
                    KGCIFF_PTYPI = dt.Rows.Item(i).Item("KGCIFF_PTYPI") & "|"
                    KGCIFF_CURCD = dt.Rows.Item(i).Item("KGCIFF_CURCD") & "|"
                    KGCIFF_DXBEW = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KGCIFF_DXBEW")) & "|"
                    KGCIFF_ERART = dt.Rows.Item(i).Item("KGCIFF_ERART") & "|"
                    KGCIFF_HOEHE = dt.Rows.Item(i).Item("KGCIFF_HOEHE").ToString.Replace(",", ".") & "|"
                    KGCIFF_SALDO = dt.Rows.Item(i).Item("KGCIFF_SALDO").ToString.Replace(",", ".") & "|"
                    KGCIFF_TILGA = dt.Rows.Item(i).Item("KGCIFF_TILGA").ToString.Replace(",", ".") & "|"
                    KGCIFF_ZINSA = dt.Rows.Item(i).Item("KGCIFF_ZINSA").ToString.Replace(",", ".") & "|"
                    KGCIFF_WHISO = dt.Rows.Item(i).Item("KGCIFF_WHISO") & "|"
                    KGCIFF_KZABL = dt.Rows.Item(i).Item("KGCIFF_KZABL") & "|" 'New
                    KGCIFF_POOLI = dt.Rows.Item(i).Item("KGCIFF_POOLI") & "|" 'New
                    KGCIFF_IFNAM = "KGCIAF" & "|"
                    KGCIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KGCIFF_DXIFD"))

                    CSV_ROW = KGCIFF_MDANT & KGCIFF_MODUL & KGCIFF_KDREA & KGCIFF_KTONR & KGCIFF_GSREF & KGCIFF_ACCNR & KGCIFF_PTYPI & KGCIFF_CURCD & KGCIFF_DXBEW & KGCIFF_ERART & KGCIFF_HOEHE & KGCIFF_SALDO & KGCIFF_TILGA & KGCIFF_ZINSA & KGCIFF_WHISO & KGCIFF_KZABL & KGCIFF_POOLI & KGCIFF_IFNAM & KGCIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KGCIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KGCIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.KGCIFF_Result = "Not Created"
                Dim CSV_HEADER As String = "KGCIAF_MDANT|KGCIAF_MODUL|KGCIAF_KDREA|KGCIAF_KTONR|KGCIAF_GSREF|KGCIAF_ACCNR|KGCIAF_PTYPI|KGCIAF_CURCD|KGCIAF_DXBEW|KGCIAF_ERART|KGCIAF_HOEHE|KGCIAF_SALDO|KGCIAF_TILGA|KGCIAF_ZINSA|KGCIAF_WHISO|KGCIAF_KZABL|KGCIAF_POOLI|KGCIAF_IFNAM|KGCIAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "KGCIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KGCIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KGCIAF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File KGCIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File KGCIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub KNEIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        'BgwBaisFilesCreation.ReportProgress(1, "Start updating Table:BAIS_KNEIFF...")
        'BgwBaisFilesCreation.ReportProgress(1, "Set Field:[KNEIFF_GRPKZ]=NULL - Related to CCB Group")
        'cmd.CommandText = "UPDATE [BAIS_KNEIFF] SET [KNEIFF_GRPKZ]=NULL where [KNEIFF_DXIFD]='" & rdsql & "'"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Set Field:[KNEIFF_GRPKZ]=S only if Customer Code in Table:CUSTOMER_INFO with Field:CCB_Group=Y(BRANCH) or CCB_Group_OwnID=Y (SUBSIDIARY)")
        'cmd.CommandText = "UPDATE [BAIS_KNEIFF] SET [KNEIFF_GRPKZ]='S' where [KNEIFF_DXIFD]='" & rdsql & "' and  [KNEIFF_KDNRH] in (Select ClientNo from CUSTOMER_INFO where (CCB_Group in ('Y') or [CCB_Group_OwnID] in ('Y')))"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Address Fields in BAIS_KNEIFF...")
        'cmd.CommandText = "UPDATE BAIS_KNEIFF SET KNEIFF_PLZOR=NULL,KNEIFF_PLZNR=NULL,KNEIFF_STRAS=NULL,KNEIFF_LENID=NULL,KNEIFF_UMMIO=0,KNEIFF_BILSU=0,KNEIFF_DXNSI=NULL,KNEIFF_MITAR='0',KNEIFF_PDMEM=999.9999 where KNEIFF_DXIFD='" & rdsql & "'"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_PLZOR=B.ADDRESS3,A.KNEIFF_PLZNR=dbo.fn_StripCharacters(B.ADDRESS3, '^0-9') from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.ADDRESS3 is not NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_STRAS=LEFT(CASE when B.ADDRESS2 is NULL then B.ADDRESS1 when B.ADDRESS2 is not NULL then B.ADDRESS1 + '  ' + B.ADDRESS2 END,30) from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.ADDRESS1 is not NULL"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update LEI Code in BAIS_KNEIFF_LENID...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_LENID=B.LEI_CODE from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD ='" & rdsql & "' and B.LEI_CODE is not NULL"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Annual Turnover in BAIS_KNEIFF_UMMIO...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_UMMIO=B.Annual_Turnover_in_EUR_Mio from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.Annual_Turnover_in_EUR_Mio is not NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE BAIS_KNEIFF SET KNEIFF_UMMIO=CASE when KNEIFF_UMMIO<1000 then 0.001 else ROUND(KNEIFF_UMMIO/1000000,3) end where KNEIFF_DXIFD='" & rdsql & "'"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Balance Sheet Sum in BAIS_KNEIFF_BILSU...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_BILSU=B.Balance_Sheet_Total from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.Balance_Sheet_Total is not NULL"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE BAIS_KNEIFF SET KNEIFF_BILSU=CASE when KNEIFF_BILSU<1000 then 0.001 else ROUND(KNEIFF_BILSU/1000000,3) end where KNEIFF_DXIFD='" & rdsql & "'"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Balance Sheet Date from Enterprice Size Date in BAIS_KNEIFF_DXNSI...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_DXNSI=B.Enterprice_Size_Date from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.Enterprice_Size_Date is not NULL"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Employes Nr. in BAIS_KNEIFF_MITAR...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_MITAR=B.Employees_Nr from BAIS_KNEIFF A INNER JOIN CUSTOMER_INFO B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.Employees_Nr is not NULL"
        'cmd.ExecuteNonQuery()
        'BgwBaisFilesCreation.ReportProgress(1, "Update Probability of Default(PD)-percentage in BAIS_KNEIFF_PDMEM...")
        'cmd.CommandText = "UPDATE A SET A.KNEIFF_PDMEM=ROUND(B.PD*100,3) from BAIS_KNEIFF A INNER JOIN CUSTOMER_RATING_DETAILS B on A.KNEIFF_KDNRH=B.ClientNo where A.KNEIFF_DXIFD='" & rdsql & "' and B.RatingType in ('INTERNAL') and A.KNEIFF_DXIFD BETWEEN B.Valid_From and B.Valid_Till"
        'cmd.ExecuteNonQuery()

        BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KNEIAF File for: " & rd)
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KNEIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If

        cmd.CommandText = "Select Count([ID]) from [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KNEIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "KNEIAF_MDANT|KNEIAF_FILNR|KNEIAF_KDREA|KNEIAF_KURZN|KNEIAF_NAME1|KNEIAF_NAME2|KNEIAF_NAME3|KNEIAF_PLZOR|KNEIAF_PLZNR|KNEIAF_STRAS|KNEIAF_DXGEB|KNEIAF_WSGSI|KNEIAF_BRNCH|KNEIAF_WSBIS|KNEIAF_BRNZU|KNEIAF_SLDSL|KNEIAF_RLDSL|KNEIAF_LDRIS|KNEIAF_BONIT|KNEIAF_GRPKZ|KNEIAF_KZLST|KNEIAF_KZPER|KNEIAF_UMMIO|KNEIAF_BILSU|KNEIAF_DXNSI|KNEIAF_AUSFL|KNEIAF_DXAUD|KNEIAF_ORGSL|KNEIAF_RISGR|KNEIAF_KGBID|KNEIAF_ANRKZ|KNEIAF_ESAKZ|KNEIAF_ESAK2|KNEIAF_ESAK3|KNEIAF_KUKON|KNEIAF_NACES|KNEIAF_LENID|KNEIAF_WSCRR|KNEIAF_WSFIN|KNEIAF_AVCKZ|KNEIAF_RECHF|KNEIAF_KNBOG|KNEIAF_MITAR|KNEIAF_PDMEM|KNEIAF_FREI1|KNEIAF_FREI2|KNEIAF_FREI3|KNEIAF_FREI4|KNEIAF_FREI5|KNEIAF_LOEKZ|KNEIAF_IFNAM|KNEIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim KNEIFF_MDANT As String = Nothing
                Dim KNEIFF_FILNR As String = Nothing
                Dim KNEIFF_KDREA As String = Nothing
                Dim KNEIFF_KURZN As String = Nothing
                Dim KNEIFF_NAME1 As String = Nothing
                Dim KNEIFF_NAME2 As String = Nothing
                Dim KNEIFF_NAME3 As String = Nothing
                Dim KNEIFF_PLZOR As String = Nothing
                Dim KNEIFF_PLZNR As String = Nothing
                Dim KNEIFF_STRAS As String = Nothing
                Dim KNEIFF_DXGEB As String = Nothing
                Dim KNEIFF_WSGSI As String = Nothing
                Dim KNEIFF_BRNCH As String = Nothing
                Dim KNEIFF_WSBIS As String = Nothing
                Dim KNEIFF_BRNZU As String = Nothing
                Dim KNEIFF_SLDSL As String = Nothing
                Dim KNEIFF_RLDSL As String = Nothing
                Dim KNEIFF_LDRIS As String = Nothing
                Dim KNEIFF_BONIT As String = Nothing
                Dim KNEIFF_GRPKZ As String = Nothing
                Dim KNEIFF_KZLST As String = Nothing
                Dim KNEIFF_KZPER As String = Nothing
                Dim KNEIFF_UMMIO As String = Nothing
                Dim KNEIFF_BILSU As String = Nothing 'New 1.25
                Dim KNEIFF_DXNSI As String = Nothing 'New 1.25
                Dim KNEIFF_AUSFL As String = Nothing
                Dim KNEIFF_DXAUD As String = Nothing
                Dim KNEIFF_ORGSL As String = Nothing
                Dim KNEIFF_RISGR As String = Nothing
                Dim KNEIFF_KGBID As String = Nothing
                Dim KNEIFF_ANRKZ As String = Nothing
                Dim KNEIFF_ESAKZ As String = Nothing
                Dim KNEIFF_ESAK2 As String = Nothing 'New
                Dim KNEIFF_ESAK3 As String = Nothing 'New
                Dim KNEIFF_KUKON As String = Nothing 'New
                Dim KNEIFF_NACES As String = Nothing
                Dim KNEIFF_LENID As String = Nothing
                Dim KNEIFF_WSCRR As String = Nothing
                Dim KNEIFF_WSFIN As String = Nothing 'New
                Dim KNEIFF_AVCKZ As String = Nothing
                Dim KNEIFF_RECHF As String = Nothing 'New
                Dim KNEIFF_KNBOG As String = Nothing 'New
                Dim KNEIFF_MITAR As String = Nothing 'New
                Dim KNEIFF_PDMEM As String = Nothing 'New 1.25
                Dim KNEIFF_FREI1 As String = Nothing
                Dim KNEIFF_FREI2 As String = Nothing
                Dim KNEIFF_FREI3 As String = Nothing
                Dim KNEIFF_FREI4 As String = Nothing
                Dim KNEIFF_FREI5 As String = Nothing
                Dim KNEIFF_LOEKZ As String = Nothing
                Dim KNEIFF_IFNAM As String = Nothing
                Dim KNEIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "KNEIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KNEIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KNEIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                'Only Data with KDNRH<>0 and no duplicates
                Me.QueryText = "SELECT * FROM  [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "' and [KNEIFF_KDNRH] not in ('0') and [ID] in (Select Min(ID) from [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "' GROUP BY [KNEIFF_KDNRH])"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    KNEIFF_MDANT = dt.Rows.Item(i).Item("KNEIFF_MDANT") & "|"
                    KNEIFF_FILNR = dt.Rows.Item(i).Item("KNEIFF_FILNR") & "|"
                    KNEIFF_KDREA = dt.Rows.Item(i).Item("KNEIFF_KDNRH") & "|"
                    KNEIFF_KURZN = dt.Rows.Item(i).Item("KNEIFF_KURZN") & "|"
                    KNEIFF_NAME1 = dt.Rows.Item(i).Item("KNEIFF_NAME1") & "|"
                    KNEIFF_NAME2 = dt.Rows.Item(i).Item("KNEIFF_NAME2") & "|"
                    KNEIFF_NAME3 = dt.Rows.Item(i).Item("KNEIFF_NAME3") & "|"
                    KNEIFF_PLZOR = dt.Rows.Item(i).Item("KNEIFF_PLZOR") & "|"
                    KNEIFF_PLZNR = dt.Rows.Item(i).Item("KNEIFF_PLZNR") & "|"
                    KNEIFF_STRAS = dt.Rows.Item(i).Item("KNEIFF_STRAS") & "|"
                    KNEIFF_DXGEB = dt.Rows.Item(i).Item("KNEIFF_DXGEB") & "|"
                    KNEIFF_WSGSI = dt.Rows.Item(i).Item("KNEIFF_WSGSI") & "|"
                    KNEIFF_BRNCH = dt.Rows.Item(i).Item("KNEIFF_BRNCH") & "|"
                    KNEIFF_WSBIS = dt.Rows.Item(i).Item("KNEIFF_WSBIS") & "|"
                    KNEIFF_BRNZU = dt.Rows.Item(i).Item("KNEIFF_BRNZU") & "|"
                    KNEIFF_SLDSL = dt.Rows.Item(i).Item("KNEIFF_SLDSL") & "|"
                    KNEIFF_RLDSL = dt.Rows.Item(i).Item("KNEIFF_RLDSL") & "|"
                    KNEIFF_LDRIS = dt.Rows.Item(i).Item("KNEIFF_LDRIS") & "|"
                    KNEIFF_BONIT = dt.Rows.Item(i).Item("KNEIFF_BONIT") & "|"
                    KNEIFF_GRPKZ = dt.Rows.Item(i).Item("KNEIFF_GRPKZ") & "|"
                    KNEIFF_KZLST = dt.Rows.Item(i).Item("KNEIFF_KZLST") & "|"
                    KNEIFF_KZPER = dt.Rows.Item(i).Item("KNEIFF_KZPER") & "|"
                    KNEIFF_UMMIO = dt.Rows.Item(i).Item("KNEIFF_UMMIO").ToString.Replace(",", ".") & "|"
                    KNEIFF_BILSU = dt.Rows.Item(i).Item("KNEIFF_BILSU").ToString.Replace(",", ".") & "|" 'New 1.25
                    If IsDBNull(dt.Rows.Item(i).Item("KNEIFF_DXNSI")) = False Then 'New 1.25
                        Dim DXNSI_Date As Date = dt.Rows.Item(i).Item("KNEIFF_DXNSI")
                        KNEIFF_DXNSI = DXNSI_Date.ToString("yyyyMMdd") & "|"
                    Else
                        KNEIFF_DXNSI = "0" & "|"
                    End If
                    KNEIFF_AUSFL = dt.Rows.Item(i).Item("KNEIFF_AUSFL") & "|"
                    KNEIFF_DXAUD = dt.Rows.Item(i).Item("KNEIFF_DXAUD") & "|"
                    KNEIFF_ORGSL = dt.Rows.Item(i).Item("KNEIFF_ORGSL") & "|"
                    KNEIFF_RISGR = dt.Rows.Item(i).Item("KNEIFF_RISGR") & "|"
                    KNEIFF_KGBID = dt.Rows.Item(i).Item("KNEIFF_KGBID") & "|"
                    KNEIFF_ANRKZ = dt.Rows.Item(i).Item("KNEIFF_ANRKZ") & "|"
                    KNEIFF_ESAKZ = dt.Rows.Item(i).Item("KNEIFF_ESAKZ") & "|"
                    KNEIFF_ESAK2 = dt.Rows.Item(i).Item("KNEIFF_ESAK2") & "|" 'New
                    KNEIFF_ESAK3 = dt.Rows.Item(i).Item("KNEIFF_ESAK3") & "|" 'New
                    KNEIFF_KUKON = dt.Rows.Item(i).Item("KNEIFF_KUKON") & "|" 'New
                    KNEIFF_NACES = dt.Rows.Item(i).Item("KNEIFF_NACES") & "|"
                    KNEIFF_LENID = dt.Rows.Item(i).Item("KNEIFF_LENID") & "|"
                    KNEIFF_WSCRR = dt.Rows.Item(i).Item("KNEIFF_WSCRR") & "|"
                    KNEIFF_WSFIN = dt.Rows.Item(i).Item("KNEIFF_WSFIN") & "|" 'New
                    KNEIFF_AVCKZ = dt.Rows.Item(i).Item("KNEIFF_AVCKZ") & "|"
                    KNEIFF_RECHF = dt.Rows.Item(i).Item("KNEIFF_RECHF") & "|" 'New
                    KNEIFF_KNBOG = dt.Rows.Item(i).Item("KNEIFF_KNBOG") & "|" 'New
                    KNEIFF_MITAR = dt.Rows.Item(i).Item("KNEIFF_MITAR") & "|" 'New
                    KNEIFF_PDMEM = dt.Rows.Item(i).Item("KNEIFF_PDMEM").ToString.Replace(",", ".") & "|" 'New 1.25
                    KNEIFF_FREI1 = dt.Rows.Item(i).Item("KNEIFF_FREI1") & "|"
                    KNEIFF_FREI2 = dt.Rows.Item(i).Item("KNEIFF_FREI2") & "|"
                    KNEIFF_FREI3 = dt.Rows.Item(i).Item("KNEIFF_FREI3") & "|"
                    KNEIFF_FREI4 = dt.Rows.Item(i).Item("KNEIFF_FREI4") & "|"
                    KNEIFF_FREI5 = dt.Rows.Item(i).Item("KNEIFF_FREI5") & "|"
                    KNEIFF_LOEKZ = dt.Rows.Item(i).Item("KNEIFF_LOEKZ") & "|"
                    KNEIFF_IFNAM = "KNEIAF" & "|"
                    KNEIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KNEIFF_DXIFD"))

                    CSV_ROW = KNEIFF_MDANT & KNEIFF_FILNR & KNEIFF_KDREA & KNEIFF_KURZN & KNEIFF_NAME1 & KNEIFF_NAME2 & KNEIFF_NAME3 & KNEIFF_PLZOR & KNEIFF_PLZNR & KNEIFF_STRAS & KNEIFF_DXGEB & KNEIFF_WSGSI & KNEIFF_BRNCH & KNEIFF_WSBIS & KNEIFF_BRNZU & KNEIFF_SLDSL & KNEIFF_RLDSL & KNEIFF_LDRIS & KNEIFF_BONIT & KNEIFF_GRPKZ & KNEIFF_KZLST & KNEIFF_KZPER & KNEIFF_UMMIO & KNEIFF_BILSU & KNEIFF_DXNSI & KNEIFF_AUSFL & KNEIFF_DXAUD & KNEIFF_ORGSL & KNEIFF_RISGR & KNEIFF_KGBID & KNEIFF_ANRKZ & KNEIFF_ESAKZ & KNEIFF_ESAK2 & KNEIFF_ESAK3 & KNEIFF_KUKON & KNEIFF_NACES & KNEIFF_LENID & KNEIFF_WSCRR & KNEIFF_WSFIN & KNEIFF_AVCKZ & KNEIFF_RECHF & KNEIFF_KNBOG & KNEIFF_MITAR & KNEIFF_PDMEM & KNEIFF_FREI1 & KNEIFF_FREI2 & KNEIFF_FREI3 & KNEIFF_FREI4 & KNEIFF_FREI5 & KNEIFF_LOEKZ & KNEIFF_IFNAM & KNEIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KNEIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KNEIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.KNEIFF_Result = "Not Created"
                Dim CSV_HEADER As String = "KNEIAF_MDANT|KNEIAF_FILNR|KNEIAF_KDREA|KNEIAF_KURZN|KNEIAF_NAME1|KNEIAF_NAME2|KNEIAF_NAME3|KNEIAF_PLZOR|KNEIAF_PLZNR|KNEIAF_STRAS|KNEIAF_DXGEB|KNEIAF_WSGSI|KNEIAF_BRNCH|KNEIAF_WSBIS|KNEIAF_BRNZU|KNEIAF_SLDSL|KNEIAF_RLDSL|KNEIAF_LDRIS|KNEIAF_BONIT|KNEIAF_GRPKZ|KNEIAF_KZLST|KNEIAF_KZPER|KNEIAF_UMMIO|KNEIAF_BILSU|KNEIAF_DXNSI|KNEIAF_AUSFL|KNEIAF_DXAUD|KNEIAF_ORGSL|KNEIAF_RISGR|KNEIAF_KGBID|KNEIAF_ANRKZ|KNEIAF_ESAKZ|KNEIAF_ESAK2|KNEIAF_ESAK3|KNEIAF_KUKON|KNEIAF_NACES|KNEIAF_LENID|KNEIAF_WSCRR|KNEIAF_WSFIN|KNEIAF_AVCKZ|KNEIAF_RECHF|KNEIAF_KNBOG|KNEIAF_MITAR|KNEIAF_PDMEM|KNEIAF_FREI1|KNEIAF_FREI2|KNEIAF_FREI3|KNEIAF_FREI4|KNEIAF_FREI5|KNEIAF_LOEKZ|KNEIAF_IFNAM|KNEIAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "KNEIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KNEIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KNEIAF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File KNEIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File KNEIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub 'OK

    Private Sub KNVIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
       
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KNVIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KNVIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KNVIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "KNVIAF_MDANK|KNVIAF_MDANT|KNVIAF_KNZNR|KNVIAF_MDAN2|KNVIAF_KDREA|KNVIAF_KNEKZ|KNVIAF_GRDZF|KNVIAF_ZUSKZ|KNVIAF_GBRKZ|KNVIAF_GEKTO|KNVIAF_MEANT|KNVIAF_HFBES|KNVIAF_ANERL|KNVIAF_BETXT|KNVIAF_FREI1|KNVIAF_FREI2|KNVIAF_FREI3|KNVIAF_LOEKZ|KNVIAF_IFNAM|KNVIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim KNVIFF_MDANK As String = Nothing
                Dim KNVIFF_MDANT As String = Nothing
                Dim KNVIFF_KNZNR As String = Nothing
                Dim KNVIFF_MDAN2 As String = Nothing
                Dim KNVIFF_KDREA As String = Nothing
                Dim KNVIFF_KNEKZ As String = Nothing
                Dim KNVIFF_GRDZF As String = Nothing
                Dim KNVIFF_ZUSKZ As String = Nothing
                Dim KNVIFF_GBRKZ As String = Nothing
                Dim KNVIFF_GEKTO As String = Nothing 'New
                Dim KNVIFF_MEANT As String = Nothing
                Dim KNVIFF_HFBES As String = Nothing
                Dim KNVIFF_ANERL As String = Nothing
                Dim KNVIFF_BETXT As String = Nothing
                Dim KNVIFF_FREI1 As String = Nothing
                Dim KNVIFF_FREI2 As String = Nothing
                Dim KNVIFF_FREI3 As String = Nothing
                Dim KNVIFF_LOEKZ As String = Nothing
                Dim KNVIFF_IFNAM As String = Nothing
                Dim KNVIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "KNVIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KNVIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KNVIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_KNVIFF] where [KNVIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    KNVIFF_MDANK = dt.Rows.Item(i).Item("KNVIFF_MDANK") & "|"
                    KNVIFF_MDANT = dt.Rows.Item(i).Item("KNVIFF_MDANT") & "|"
                    KNVIFF_KNZNR = dt.Rows.Item(i).Item("KNVIFF_KNZNR") & "|"
                    KNVIFF_MDAN2 = dt.Rows.Item(i).Item("KNVIFF_MDAN2") & "|"
                    KNVIFF_KDREA = dt.Rows.Item(i).Item("KNVIFF_KDNRH") & "|"
                    KNVIFF_KNEKZ = dt.Rows.Item(i).Item("KNVIFF_KNEKZ") & "|"
                    KNVIFF_GRDZF = dt.Rows.Item(i).Item("KNVIFF_GRDZF") & "|"
                    KNVIFF_ZUSKZ = dt.Rows.Item(i).Item("KNVIFF_ZUSKZ") & "|"
                    KNVIFF_GBRKZ = dt.Rows.Item(i).Item("KNVIFF_GBRKZ") & "|"
                    KNVIFF_GEKTO = dt.Rows.Item(i).Item("KNVIFF_GEKTO") & "|" ' New
                    KNVIFF_MEANT = dt.Rows.Item(i).Item("KNVIFF_MEANT") & "|"
                    KNVIFF_HFBES = dt.Rows.Item(i).Item("KNVIFF_HFBES") & "|"
                    KNVIFF_ANERL = dt.Rows.Item(i).Item("KNVIFF_ANERL") & "|"
                    KNVIFF_BETXT = dt.Rows.Item(i).Item("KNVIFF_BETXT") & "|"
                    KNVIFF_FREI1 = dt.Rows.Item(i).Item("KNVIFF_FREI1") & "|"
                    KNVIFF_FREI2 = dt.Rows.Item(i).Item("KNVIFF_FREI2") & "|"
                    KNVIFF_FREI3 = dt.Rows.Item(i).Item("KNVIFF_FREI3") & "|"
                    KNVIFF_LOEKZ = dt.Rows.Item(i).Item("KNVIFF_LOEKZ") & "|"
                    KNVIFF_IFNAM = "KNVIAF" & "|"
                    KNVIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KNVIFF_DXIFD"))

                    CSV_ROW = KNVIFF_MDANK & KNVIFF_MDANT & KNVIFF_KNZNR & KNVIFF_MDAN2 & KNVIFF_KDREA & KNVIFF_KNEKZ & KNVIFF_GRDZF & KNVIFF_ZUSKZ & KNVIFF_GBRKZ & KNVIFF_GEKTO & KNVIFF_MEANT & KNVIFF_HFBES & KNVIFF_ANERL & KNVIFF_BETXT & KNVIFF_FREI1 & KNVIFF_FREI2 & KNVIFF_FREI3 & KNVIFF_LOEKZ & KNVIFF_IFNAM & KNVIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KNVIAF_CCB.csv", CSV_ROW & vbCrLf)
            Next

            cmd.CommandText = "Select Count([ID]) from [BAIS_KNVIFF] where [KNVIFF_DXIFD]='" & rdsql & "'"
            Dim Count As Double = cmd.ExecuteScalar

            If Count <> 0 Then
                Me.KNVIFF_Result = "Created"
            Else
                Me.KNVIFF_Result = "Not Created"

                XtraMessageBox.Show("Unable to create File KNVIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File KNVIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.KNVIFF_Result = "Not Created"
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

    End Sub

    Private Sub KRKIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [CUSTOMER_RATING_DETAILS]"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then

            'cmd.CommandText = "DELETE from [BAIS_KRKIFF] where [KRKIFF_DXIFD]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "INSERT INTO [BAIS_KRKIFF]([KRKIFF_KDNRH],[KRKIFF_RKLIF],[KRKIFF_DXIFD]) Select  [ClientNo],[ClientNo],'" & rdsql & "' FROM [CUSTOMER_RATING_DETAILS] where [Rating] not in ('No Rating') and '" & rdsql & "' between [Valid_From] and [Valid_Till] and [RatingType] in ('EXTERNAL')"
            'cmd.ExecuteNonQuery()

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KRKIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KRKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KRKIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "KRKIAF_MDANT|KRKIAF_KDREA|KRKIAF_RAGEN|KRKIAF_RKLIF|KRKIAF_FREI1|KRKIAF_FREI2|KRKIAF_FREI3|KRKIAF_IFNAM|KRKIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim KRKIFF_MDANT As String = Nothing 'New
                Dim KRKIFF_KDREA As String = Nothing
                Dim KRKIFF_RAGEN As String = Nothing
                Dim KRKIFF_RKLIF As String = Nothing
                Dim KRKIFF_FREI1 As String = Nothing
                Dim KRKIFF_FREI2 As String = Nothing
                Dim KRKIFF_FREI3 As String = Nothing
                Dim KRKIFF_IFNAM As String = Nothing
                Dim KRKIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "KRKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KRKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KRKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++

                Me.QueryText = "SELECT * FROM  [BAIS_KRKIFF] where [KRKIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    KRKIFF_MDANT = dt.Rows.Item(i).Item("KRKIFF_MDANT") & "|" 'New
                    KRKIFF_KDREA = dt.Rows.Item(i).Item("KRKIFF_KDNRH") & "|"
                    KRKIFF_RAGEN = dt.Rows.Item(i).Item("KRKIFF_RAGEN") & "|"
                    KRKIFF_RKLIF = dt.Rows.Item(i).Item("KRKIFF_RKLIF") & "|"
                    KRKIFF_FREI1 = "|"
                    KRKIFF_FREI2 = "|"
                    KRKIFF_FREI3 = "|"
                    KRKIFF_IFNAM = "KRKIAF" & "|"
                    KRKIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KRKIFF_DXIFD"))


                    CSV_ROW = KRKIFF_MDANT & KRKIFF_KDREA & KRKIFF_RAGEN & KRKIFF_RKLIF & KRKIFF_FREI1 & KRKIFF_FREI2 & KRKIFF_FREI3 & KRKIFF_IFNAM & KRKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KRKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KRKIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.KRKIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "KRKIAF_MDANT|KRKIAF_KDREA|KRKIAF_RAGEN|KRKIAF_RKLIF|KRKIAF_FREI1|KRKIAF_FREI2|KRKIAF_FREI3|KRKIAF_IFNAM|KRKIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "KRKIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "KRKIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "KRKIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File KRKIAF_CCB.csv for " & rd & vbNewLine & "There are no Data in Table:CUSTOMER_RATING_DETAILS", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


    End Sub

    Private Sub KSRIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_KSRIFF] where [KSRIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                'cmd.CommandText = "DELETE from [BAIS_KSRIFF] where [KSRIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [BAIS_KSRIFF]([KSRIFF_RKLIF],[KSRIFF_RATEX],[KSRIFF_DXRAT],[KSRIFF_DXIFD]) Select  [ClientNo],[Rating],'" & rdsql & "','" & rdsql & "' FROM [CUSTOMER_RATING_DETAILS] where [Rating] not in ('No Rating') and '" & rdsql & "' between [Valid_From] and [Valid_Till] and [RatingType] in ('EXTERNAL')"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [BAIS_KSRIFF]([KSRIFF_RKLIF],[KSRIFF_RATEX],[KSRIFF_LDISO],[KSRIFF_DXRAT],[KSRIFF_DXIFD]) Select  LEFT([COUNTRY NAME],20),[CountryRating],[COUNTRY CODE],[CountryRatingDate],'" & rdsql & "' FROM [COUNTRIES] where [CountryRating] not in ('No Rating') "
                'cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KSRIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KSRIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KSRIFF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "KSRIFF_MDANT|KSRIFF_RKLIF|KSRIFF_RAGEN|KSRIFF_RATYP|KSRIFF_KZHFW|KSRIFF_RATEX|KSRIFF_DXRAT|KSRIFF_LDISO|KSRIFF_IFNAM|KSRIFF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim KSRIFF_MDANT As String = Nothing 'New
                Dim KSRIFF_RKLIF As String = Nothing
                Dim KSRIFF_RAGEN As String = Nothing
                Dim KSRIFF_RATYP As String = Nothing
                Dim KSRIFF_KZHFW As String = Nothing
                Dim KSRIFF_RATEX As String = Nothing
                Dim KSRIFF_DXRAT As String = Nothing
                Dim KSRIFF_LDISO As String = Nothing
                Dim KSRIFF_IFNAM As String = Nothing
                Dim KSRIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "KSRIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KSRIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KSRIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++




                Me.QueryText = "SELECT * FROM  [BAIS_KSRIFF] where [KSRIFF_DXIFD]='" & rdsql & "' and ([KSRIFF_RKLIF] not in ('0') or [KSRIFF_RKLIF] is not NULL)"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    KSRIFF_MDANT = dt.Rows.Item(i).Item("KSRIFF_MDANT") & "|" 'New
                    KSRIFF_RKLIF = dt.Rows.Item(i).Item("KSRIFF_RKLIF") & "|"
                    KSRIFF_RAGEN = dt.Rows.Item(i).Item("KSRIFF_RAGEN") & "|"
                    KSRIFF_RATYP = dt.Rows.Item(i).Item("KSRIFF_RATYP") & "|"
                    KSRIFF_KZHFW = dt.Rows.Item(i).Item("KSRIFF_KZHFW") & "|"
                    KSRIFF_RATEX = dt.Rows.Item(i).Item("KSRIFF_RATEX") & "|"
                    KSRIFF_DXRAT = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KSRIFF_DXRAT")) & "|"
                    KSRIFF_LDISO = dt.Rows.Item(i).Item("KSRIFF_LDISO") & "|"
                    KSRIFF_IFNAM = dt.Rows.Item(i).Item("KSRIFF_IFNAM") & "|"
                    KSRIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KSRIFF_DXIFD"))



                    CSV_ROW = KSRIFF_MDANT & KSRIFF_RKLIF & KSRIFF_RAGEN & KSRIFF_RATYP & KSRIFF_KZHFW & KSRIFF_RATEX & KSRIFF_DXRAT & KSRIFF_LDISO & KSRIFF_IFNAM & KSRIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KSRIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KSRIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.KSRIFF_Result = "Not Created"
                Dim CSV_HEADER As String = "KSRIFF_MDANT|KSRIFF_RKLIF|KSRIFF_RAGEN|KSRIFF_RATYP|KSRIFF_KZHFW|KSRIFF_RATEX|KSRIFF_DXRAT|KSRIFF_LDISO|KSRIFF_IFNAM|KSRIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "KSRIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KSRIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KSRIFF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File KSRIFF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub LQGIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_LQGIFF] where [LQGIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            'BgwBaisFilesCreation.ReportProgress(1, "Start updating Table:BAIS_LQGIFF...")
            'BgwBaisFilesCreation.ReportProgress(1, "Set Field:LQGIFF_EINTY=NULL,[LQGIFF_EINLS]=NULL")
            'cmd.CommandText = "UPDATE [BAIS_LQGIFF] set [LQGIFF_EINTY]=NULL,[LQGIFF_EINLS]=NULL where [LQGIFF_DXIFD]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'BgwBaisFilesCreation.ReportProgress(1, "Set Field:[LQGIFF_EINTY]='O' and [LQGIFF_EINLS]='0' only if [LQGIFF_MODUL]='CA' and [LQGIFF_GSREF]=([GSTIFF_GSREF] where GSTIFF_GSART='NL') and [LQGIFF_KDNRH]=([KNEIFF_KDNRH] where [KNEIFF_GRPKZ] is not NULL)")
            'cmd.CommandText = "UPDATE [BAIS_LQGIFF] set [LQGIFF_EINTY]='O',[LQGIFF_EINLS]='0' where [LQGIFF_DXIFD]='" & rdsql & "' and [LQGIFF_MODUL]='CA' and [LQGIFF_GSREF] in (Select [GSTIFF_GSREF] from BAIS_GSTIFF where GSTIFF_DXIFD='" & rdsql & "' and GSTIFF_GSART='NL') and [LQGIFF_KDNRH] in (Select [KNEIFF_KDNRH] from BAIS_KNEIFF where KNEIFF_DXIFD='" & rdsql & "' and [KNEIFF_GRPKZ] is not NULL)"
            'cmd.ExecuteNonQuery()
            'BgwBaisFilesCreation.ReportProgress(1, "Set Field:LQGIFF_EINLS=1 where LQGIFF_EINTY is NULL and LQGIFF_MODUL]=CA ")
            'cmd.CommandText = "UPDATE [BAIS_LQGIFF] set [LQGIFF_EINLS]='1' where [LQGIFF_EINTY] is NULL and [LQGIFF_MODUL] in ('CA') and [LQGIFF_DXIFD]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_LQGIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_LQGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: LQGIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "LQGIAF_MDANT|LQGIAF_MODUL|LQGIAF_KDREA|LQGIAF_KTONR|LQGIAF_GSREF|LQGIAF_EINLS|LQGIAF_KUNDG|LQGIAF_KUNBT|LQGIAF_EINTY|LQGIAF_BESFI|LQGIAF_RSFFK|LQGIAF_DXBES|LQGIAF_MWSIC|LQGIAF_WHMWS|LQGIAF_ANZKI|LQGIAF_KZABL|LQGIAF_DXBEL|LQGIAF_HOEBL|LQGIAF_WHGBL|LQGIAF_NOMBT|LQGIAF_HAWHG|LQGIAF_KUDIV|LQGIAF_QKRLA|LQGIAF_LIQQU|LQGIAF_LQAST|LQGIAF_KZLCI|LQGIAF_UEBSI|LQGIAF_KZFAZ|LQGIAF_LCRK1|LQGIAF_LCRK2|LQGIAF_LCRK3|LQGIAF_LCRK4|LQGIAF_NSFRK|LQGIAF_CTKAT|LQGIAF_CAPIF|LQGIAF_SPREA|LQGIAF_AMMPR|LQGIAF_RZFKI|LQGIAF_ZNKAP|LQGIAF_NGTYP|LQGIAF_C70BT|LQGIAF_RSCD1|LQGIAF_RSCD2|LQGIAF_RSTX1|LQGIAF_RSTX2|LQGIAF_RSDX1|LQGIAF_RSPR1|LQGIAF_RSBT1|LQGIAF_RSBT2|LQGIAF_IFNAM|LQGIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim LQGIFF_MDANT As String = Nothing
                Dim LQGIFF_MODUL As String = Nothing
                Dim LQGIFF_KDREA As String = Nothing
                Dim LQGIFF_KTONR As String = Nothing
                Dim LQGIFF_GSREF As String = Nothing
                Dim LQGIFF_EINLS As String = Nothing
                Dim LQGIFF_KUNDG As String = Nothing
                Dim LQGIFF_KUNBT As String = Nothing
                Dim LQGIFF_EINTY As String = Nothing
                Dim LQGIFF_BESFI As String = Nothing
                Dim LQGIFF_RSFFK As String = Nothing
                Dim LQGIFF_DXBES As String = Nothing
                Dim LQGIFF_MWSIC As String = Nothing
                Dim LQGIFF_WHMWS As String = Nothing
                Dim LQGIFF_ANZKI As String = Nothing
                Dim LQGIFF_KZABL As String = Nothing
                Dim LQGIFF_DXBEL As String = Nothing
                Dim LQGIFF_HOEBL As String = Nothing
                Dim LQGIFF_WHGBL As String = Nothing
                Dim LQGIFF_NOMBT As String = Nothing
                Dim LQGIFF_HAWHG As String = Nothing
                Dim LQGIFF_KUDIV As String = Nothing
                Dim LQGIFF_QKRLA As String = Nothing
                Dim LQGIFF_LIQQU As String = Nothing
                Dim LQGIFF_LQAST As String = Nothing 'New
                Dim LQGIFF_KZLCI As String = Nothing
                Dim LQGIFF_UEBSI As String = Nothing 'New
                Dim LQGIFF_KZFAZ As String = Nothing
                Dim LQGIFF_LCRK1 As String = Nothing
                Dim LQGIFF_LCRK2 As String = Nothing
                Dim LQGIFF_LCRK3 As String = Nothing 'New
                Dim LQGIFF_LCRK4 As String = Nothing 'New 1.23
                Dim LQGIFF_NSFRK As String = Nothing
                Dim LQGIFF_CTKAT As String = Nothing 'New
                Dim LQGIFF_CAPIF As String = Nothing
                Dim LQGIFF_SPREA As String = Nothing 'New
                Dim LQGIFF_AMMPR As String = Nothing 'New
                Dim LQGIFF_RZFKI As String = Nothing 'New 1.23
                Dim LQGIFF_ZNKAP As String = Nothing 'New 1.23
                Dim LQGIFF_NGTYP As String = Nothing 'New 1.23
                Dim LQGIFF_C70BT As String = Nothing ' New 1.25
                Dim LQGIFF_RSCD1 As String = Nothing ' New 1.25
                Dim LQGIFF_RSCD2 As String = Nothing ' New 1.25
                Dim LQGIFF_RSTX1 As String = Nothing ' New 1.25
                Dim LQGIFF_RSTX2 As String = Nothing ' New 1.25
                Dim LQGIFF_RSDX1 As String = Nothing ' New 1.25
                Dim LQGIFF_RSPR1 As String = Nothing ' New 1.25
                Dim LQGIFF_RSBT1 As String = Nothing ' New 1.25
                Dim LQGIFF_RSBT2 As String = Nothing ' New 1.25
                Dim LQGIFF_IFNAM As String = Nothing
                Dim LQGIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "LQGIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "LQGIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "LQGIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_LQGIFF] where [LQGIFF_DXIFD]='" & rdsql & "' and ID  in (Select min(ID) from BAIS_LQGIFF where LQGIFF_DXIFD='" & rdsql & "' GROUP BY LQGIFF_GSREF)"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    LQGIFF_MDANT = dt.Rows.Item(i).Item("LQGIFF_MDANT") & "|"
                    LQGIFF_MODUL = dt.Rows.Item(i).Item("LQGIFF_MODUL") & "|"
                    LQGIFF_KDREA = dt.Rows.Item(i).Item("LQGIFF_KDNRH") & "|"
                    LQGIFF_KTONR = dt.Rows.Item(i).Item("LQGIFF_KTONR") & "|"
                    LQGIFF_GSREF = dt.Rows.Item(i).Item("LQGIFF_GSREF") & "|"
                    LQGIFF_EINLS = dt.Rows.Item(i).Item("LQGIFF_EINLS") & "|"
                    LQGIFF_KUNDG = dt.Rows.Item(i).Item("LQGIFF_KUNDG") & "|"
                    LQGIFF_KUNBT = dt.Rows.Item(i).Item("LQGIFF_KUNBT") & "|"
                    LQGIFF_EINTY = dt.Rows.Item(i).Item("LQGIFF_EINTY") & "|"
                    LQGIFF_BESFI = dt.Rows.Item(i).Item("LQGIFF_BESFI") & "|"
                    LQGIFF_RSFFK = dt.Rows.Item(i).Item("LQGIFF_RSFFK") & "|"
                    LQGIFF_DXBES = dt.Rows.Item(i).Item("LQGIFF_DXBES") & "|"
                    LQGIFF_MWSIC = dt.Rows.Item(i).Item("LQGIFF_MWSIC") & "|"
                    LQGIFF_WHMWS = dt.Rows.Item(i).Item("LQGIFF_WHMWS") & "|"
                    LQGIFF_ANZKI = dt.Rows.Item(i).Item("LQGIFF_ANZKI") & "|"
                    LQGIFF_KZABL = dt.Rows.Item(i).Item("LQGIFF_KZABL") & "|"
                    LQGIFF_DXBEL = dt.Rows.Item(i).Item("LQGIFF_DXBEL") & "|"
                    LQGIFF_HOEBL = dt.Rows.Item(i).Item("LQGIFF_HOEBL") & "|"
                    LQGIFF_WHGBL = dt.Rows.Item(i).Item("LQGIFF_WHGBL") & "|"
                    LQGIFF_NOMBT = dt.Rows.Item(i).Item("LQGIFF_NOMBT") & "|"
                    LQGIFF_HAWHG = dt.Rows.Item(i).Item("LQGIFF_HAWHG") & "|"
                    LQGIFF_KUDIV = dt.Rows.Item(i).Item("LQGIFF_KUDIV") & "|"
                    LQGIFF_QKRLA = dt.Rows.Item(i).Item("LQGIFF_QKRLA") & "|"
                    LQGIFF_LIQQU = dt.Rows.Item(i).Item("LQGIFF_LIQQU") & "|"
                    LQGIFF_LQAST = dt.Rows.Item(i).Item("LQGIFF_LQAST") & "|" 'New
                    LQGIFF_KZLCI = dt.Rows.Item(i).Item("LQGIFF_KZLCI") & "|"
                    LQGIFF_UEBSI = dt.Rows.Item(i).Item("LQGIFF_UEBSI") & "|" 'New
                    LQGIFF_KZFAZ = dt.Rows.Item(i).Item("LQGIFF_KZFAZ") & "|"
                    LQGIFF_LCRK1 = dt.Rows.Item(i).Item("LQGIFF_LCRK1") & "|"
                    LQGIFF_LCRK2 = dt.Rows.Item(i).Item("LQGIFF_LCRK2") & "|"
                    LQGIFF_LCRK3 = dt.Rows.Item(i).Item("LQGIFF_LCRK3") & "|" 'New
                    LQGIFF_LCRK4 = dt.Rows.Item(i).Item("LQGIFF_LCRK4") & "|" 'New 1.23
                    LQGIFF_NSFRK = dt.Rows.Item(i).Item("LQGIFF_NSFRK") & "|"
                    LQGIFF_CTKAT = dt.Rows.Item(i).Item("LQGIFF_CTKAT") & "|" 'New
                    LQGIFF_CAPIF = dt.Rows.Item(i).Item("LQGIFF_CAPIF") & "|"
                    LQGIFF_SPREA = dt.Rows.Item(i).Item("LQGIFF_SPREA").ToString.Replace(",", ".") & "|" 'New
                    LQGIFF_AMMPR = dt.Rows.Item(i).Item("LQGIFF_AMMPR") & "|" 'New
                    LQGIFF_RZFKI = dt.Rows.Item(i).Item("LQGIFF_RZFKI") & "|" 'New 1.23
                    LQGIFF_ZNKAP = dt.Rows.Item(i).Item("LQGIFF_ZNKAP") & "|" 'New 1.23
                    LQGIFF_NGTYP = dt.Rows.Item(i).Item("LQGIFF_NGTYP") & "|" 'New 1.23
                    LQGIFF_C70BT = dt.Rows.Item(i).Item("LQGIFF_C70BT") & "|"
                    LQGIFF_RSCD1 = dt.Rows.Item(i).Item("LQGIFF_RSCD1") & "|"
                    LQGIFF_RSCD2 = dt.Rows.Item(i).Item("LQGIFF_RSCD2") & "|"
                    LQGIFF_RSTX1 = dt.Rows.Item(i).Item("LQGIFF_RSTX1") & "|"
                    LQGIFF_RSTX2 = dt.Rows.Item(i).Item("LQGIFF_RSTX2") & "|"
                    LQGIFF_RSDX1 = dt.Rows.Item(i).Item("LQGIFF_RSDX1") & "|"
                    LQGIFF_RSPR1 = dt.Rows.Item(i).Item("LQGIFF_RSPR1") & "|"
                    LQGIFF_RSBT1 = dt.Rows.Item(i).Item("LQGIFF_RSBT1") & "|"
                    LQGIFF_RSBT2 = dt.Rows.Item(i).Item("LQGIFF_RSBT2") & "|"
                    LQGIFF_IFNAM = "LQGIAF" & "|"
                    LQGIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("LQGIFF_DXIFD"))



                    CSV_ROW = LQGIFF_MDANT & LQGIFF_MODUL & LQGIFF_KDREA & LQGIFF_KTONR & LQGIFF_GSREF & LQGIFF_EINLS & LQGIFF_KUNDG & LQGIFF_KUNBT & LQGIFF_EINTY & LQGIFF_BESFI & LQGIFF_RSFFK & LQGIFF_DXBES & LQGIFF_MWSIC & LQGIFF_WHMWS & LQGIFF_ANZKI & LQGIFF_KZABL & LQGIFF_DXBEL & LQGIFF_HOEBL & LQGIFF_WHGBL & LQGIFF_NOMBT & LQGIFF_HAWHG & LQGIFF_KUDIV & LQGIFF_QKRLA & LQGIFF_LIQQU & LQGIFF_LQAST & LQGIFF_KZLCI & LQGIFF_UEBSI & LQGIFF_KZFAZ & LQGIFF_LCRK1 & LQGIFF_LCRK2 & LQGIFF_LCRK3 & LQGIFF_LCRK4 & LQGIFF_NSFRK & LQGIFF_CTKAT & LQGIFF_CAPIF & LQGIFF_SPREA & LQGIFF_AMMPR & LQGIFF_RZFKI & LQGIFF_ZNKAP & LQGIFF_NGTYP & LQGIFF_C70BT & LQGIFF_RSCD1 & LQGIFF_RSCD2 & LQGIFF_RSTX1 & LQGIFF_RSTX2 & LQGIFF_RSDX1 & LQGIFF_RSPR1 & LQGIFF_RSBT1 & LQGIFF_RSBT2 & LQGIFF_IFNAM & LQGIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "LQGIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.LQGIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.LQGIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "LQGIAF_MDANT|LQGIAF_MODUL|LQGIAF_KDREA|LQGIAF_KTONR|LQGIAF_GSREF|LQGIAF_EINLS|LQGIAF_KUNDG|LQGIAF_KUNBT|LQGIAF_EINTY|LQGIAF_BESFI|LQGIAF_RSFFK|LQGIAF_DXBES|LQGIAF_MWSIC|LQGIAF_WHMWS|LQGIAF_ANZKI|LQGIAF_KZABL|LQGIAF_DXBEL|LQGIAF_HOEBL|LQGIAF_WHGBL|LQGIAF_NOMBT|LQGIAF_HAWHG|LQGIAF_KUDIV|LQGIAF_QKRLA|LQGIAF_LIQQU|LQGIAF_LQAST|LQGIAF_KZLCI|LQGIAF_UEBSI|LQGIAF_KZFAZ|LQGIAF_LCRK1|LQGIAF_LCRK2|LQGIAF_LCRK3|LQGIAF_LCRK4|LQGIAF_NSFRK|LQGIAF_CTKAT|LQGIAF_CAPIF|LQGIAF_SPREA|LQGIAF_AMMPR|LQGIAF_RZFKI|LQGIAF_ZNKAP|LQGIAF_NGTYP|LQGIAF_C70BT|LQGIAF_RSCD1|LQGIAF_RSCD2|LQGIAF_RSTX1|LQGIAF_RSTX2|LQGIAF_RSDX1|LQGIAF_RSPR1|LQGIAF_RSBT1|LQGIAF_RSBT2|LQGIAF_IFNAM|LQGIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "LQGIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "LQGIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "LQGIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File LQGIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File LQGIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub 'OK

    Private Sub MKUIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_MKUIFF] where [MKUIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                ''+++++GET ISIN CODE++++++++++++++++
                'cmd.CommandText = "UPDATE A SET A.ISIN_Code=B.ISIN from [BAIS_MKUIFF] A INNER JOIN SECURITIES_OUR B on A.MKUIFF_WPKNR=B.ContractNrOCBS where [MKUIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                ''+++++++++SET MARKET PRICE+++++++++
                'cmd.CommandText = "UPDATE A SET A.[MKUIFF_PREIS]=C.Market_Price FROM [BAIS_MKUIFF] A INNER JOIN SECURITIES_OUR B on A.MKUIFF_WPKNR=B.ContractNrOCBS INNER JOIN SECURITIES_DailyPrice C On B.ISIN=C.ISIN_Code where [MKUIFF_DXIFD]='" & rdsql & "' and [MKUIFF_DXIFD]=C.Date"
                'cmd.ExecuteNonQuery()
                ''+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_MKUIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_MKUIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If



                BgwBaisFilesCreation.ReportProgress(2, "Generating File: MKUIFF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "MKUIFF_MDANT|MKUIFF_WPKNR|MKUIFF_HAWHG|MKUIFF_PREIS|MKUIFF_PREI2|MKUIFF_PREID|MKUIFF_STRKU|MKUIFF_BEWAB|MKUIFF_BWALA|MKUIFF_POOLF|MKUIFF_FREI1|MKUIFF_IFNAM|MKUIFF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim MKUIFF_MDANT As String = Nothing
                Dim MKUIFF_WPKNR As String = Nothing
                Dim MKUIFF_HAWHG As String = Nothing
                Dim MKUIFF_PREIS As String = Nothing
                Dim MKUIFF_PREI2 As String = Nothing
                Dim MKUIFF_PREID As String = Nothing 'New 1.25
                Dim MKUIFF_STRKU As String = Nothing 'New
                Dim MKUIFF_BEWAB As String = Nothing
                Dim MKUIFF_BWALA As String = Nothing
                Dim MKUIFF_POOLF As String = Nothing 'New
                Dim MKUIFF_FREI1 As String = Nothing 'New
                'Dim MKUIFF_CLEAN As String = Nothing--DELETED in 1.25
                Dim MKUIFF_IFNAM As String = Nothing
                Dim MKUIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "MKUIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "MKUIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "MKUIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_MKUIFF] where [MKUIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1

                    MKUIFF_MDANT = dt.Rows.Item(i).Item("MKUIFF_MDANT") & "|"
                    MKUIFF_WPKNR = dt.Rows.Item(i).Item("MKUIFF_WPKNR") & "|"   'Normal MKUIFF_WPKNR - Field:--ISIN_Code--
                    MKUIFF_HAWHG = dt.Rows.Item(i).Item("MKUIFF_HAWHG") & "|"
                    MKUIFF_PREIS = dt.Rows.Item(i).Item("MKUIFF_PREIS") & "|"
                    MKUIFF_PREI2 = dt.Rows.Item(i).Item("MKUIFF_PREI2") & "|"
                    MKUIFF_PREID = dt.Rows.Item(i).Item("MKUIFF_PREID") & "|"
                    MKUIFF_STRKU = dt.Rows.Item(i).Item("MKUIFF_STRKU") & "|" 'New
                    MKUIFF_BEWAB = dt.Rows.Item(i).Item("MKUIFF_BEWAB") & "|"
                    MKUIFF_BWALA = dt.Rows.Item(i).Item("MKUIFF_BWALA") & "|"
                    MKUIFF_POOLF = dt.Rows.Item(i).Item("MKUIFF_POOLF") & "|" 'New
                    MKUIFF_FREI1 = dt.Rows.Item(i).Item("MKUIFF_FREI1") & "|" 'New

                    MKUIFF_IFNAM = dt.Rows.Item(i).Item("MKUIFF_IFNAM") & "|"
                    MKUIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("MKUIFF_DXIFD"))


                    CSV_ROW = MKUIFF_MDANT & MKUIFF_WPKNR & MKUIFF_HAWHG & MKUIFF_PREIS & MKUIFF_PREI2 & MKUIFF_PREID & MKUIFF_STRKU & MKUIFF_BEWAB & MKUIFF_BWALA & MKUIFF_POOLF & MKUIFF_FREI1 & MKUIFF_IFNAM & MKUIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "MKUIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.MKUIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.MKUIFF_Result = "Not Created"
                Dim CSV_HEADER As String = "MKUIFF_MDANT|MKUIFF_WPKNR|MKUIFF_HAWHG|MKUIFF_PREIS|MKUIFF_PREI2|MKUIFF_PREID|MKUIFF_STRKU|MKUIFF_BEWAB|MKUIFF_BWALA|MKUIFF_POOLF|MKUIFF_FREI1|MKUIFF_IFNAM|MKUIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "MKUIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "MKUIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "MKUIFF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            XtraMessageBox.Show("Unable to create File MKUIFF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub 'OK

    Private Sub ZUSIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_ZUSIFF] where [ZUSIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_ZUSIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ZUSIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ZUSIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "ZUSIAF_MDANT|ZUSIAF_FILNR|ZUSIAF_KDREA|ZUSIAF_ZUREF|ZUSIAF_ZUART|ZUSIAF_KRART|ZUSIAF_MODUL|ZUSIAF_KTONR|ZUSIAF_GSREF|ZUSIAF_ZUEXU|ZUSIAF_WHRGE|ZUSIAF_DXZGA|ZUSIAF_DXVNE|ZUSIAF_DXBSE|ZUSIAF_KZREV|ZUSIAF_KZUNW|ZUSIAF_KZABR|ZUSIAF_WLKKZ|ZUSIAF_KNZZU|ZUSIAF_ZOEKZ|ZUSIAF_KGZUO|ZUSIAF_ZUTYP|ZUSIAF_AUSFL|ZUSIAF_DXAUD|ZUSIAF_KOART|ZUSIAF_GSART|ZUSIAF_RISGR|ZUSIAF_KZUKU|ZUSIAF_ERHGE|ZUSIAF_GSARE|ZUSIAF_HAFIN|ZUSIAF_PRDKT|ZUSIAF_INABU|ZUSIAF_KZAKL|ZUSIAF_POOLI|ZUSIAF_AEIDF|ZUSIAF_FREI1|ZUSIAF_FREI2|ZUSIAF_FREI3|ZUSIAF_FREI4|ZUSIAF_FREI5|ZUSIAF_LOEKZ|ZUSIAF_IFNAM|ZUSIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim ZUSIFF_MDANT As String = Nothing
                Dim ZUSIFF_FILNR As String = Nothing
                Dim ZUSIFF_KDREA As String = Nothing
                Dim ZUSIFF_ZUREF As String = Nothing
                Dim ZUSIFF_ZUART As String = Nothing
                Dim ZUSIFF_KRART As String = Nothing
                Dim ZUSIFF_MODUL As String = Nothing
                Dim ZUSIFF_KTONR As String = Nothing
                Dim ZUSIFF_GSREF As String = Nothing
                Dim ZUSIFF_ZUEXU As String = Nothing
                Dim ZUSIFF_WHRGE As String = Nothing
                Dim ZUSIFF_DXZGA As String = Nothing
                Dim ZUSIFF_DXVNE As String = Nothing
                Dim ZUSIFF_DXBSE As String = Nothing
                Dim ZUSIFF_KZREV As String = Nothing
                Dim ZUSIFF_KZUNW As String = Nothing
                Dim ZUSIFF_KZABR As String = Nothing
                Dim ZUSIFF_WLKKZ As String = Nothing
                Dim ZUSIFF_KNZZU As String = Nothing
                Dim ZUSIFF_ZOEKZ As String = Nothing
                Dim ZUSIFF_KGZUO As String = Nothing
                Dim ZUSIFF_ZUTYP As String = Nothing
                Dim ZUSIFF_AUSFL As String = Nothing
                Dim ZUSIFF_DXAUD As String = Nothing
                Dim ZUSIFF_KOART As String = Nothing
                Dim ZUSIFF_GSART As String = Nothing
                Dim ZUSIFF_RISGR As String = Nothing
                Dim ZUSIFF_KZUKU As String = Nothing
                Dim ZUSIFF_ERHGE As String = Nothing
                Dim ZUSIFF_GSARE As String = Nothing
                Dim ZUSIFF_HAFIN As String = Nothing
                Dim ZUSIFF_PRDKT As String = Nothing
                Dim ZUSIFF_INABU As String = Nothing
                Dim ZUSIFF_KZAKL As String = Nothing
                Dim ZUSIFF_POOLI As String = Nothing 'New
                Dim ZUSIFF_AEIDF As String = Nothing 'New
                Dim ZUSIFF_FREI1 As String = Nothing
                Dim ZUSIFF_FREI2 As String = Nothing
                Dim ZUSIFF_FREI3 As String = Nothing
                Dim ZUSIFF_FREI4 As String = Nothing
                Dim ZUSIFF_FREI5 As String = Nothing
                Dim ZUSIFF_LOEKZ As String = Nothing
                Dim ZUSIFF_IFNAM As String = Nothing
                Dim ZUSIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "ZUSIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "ZUSIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "ZUSIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_ZUSIFF] where [ZUSIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    ZUSIFF_MDANT = dt.Rows.Item(i).Item("ZUSIFF_MDANT") & "|"
                    ZUSIFF_FILNR = dt.Rows.Item(i).Item("ZUSIFF_FILNR") & "|"
                    ZUSIFF_KDREA = dt.Rows.Item(i).Item("ZUSIFF_KDNRH") & "|"
                    ZUSIFF_ZUREF = dt.Rows.Item(i).Item("ZUSIFF_ZUREF") & "|"
                    ZUSIFF_ZUART = dt.Rows.Item(i).Item("ZUSIFF_ZUART") & "|"
                    ZUSIFF_KRART = dt.Rows.Item(i).Item("ZUSIFF_KRART") & "|"
                    ZUSIFF_MODUL = dt.Rows.Item(i).Item("ZUSIFF_MODUL") & "|"
                    ZUSIFF_KTONR = dt.Rows.Item(i).Item("ZUSIFF_KTONR") & "|"
                    ZUSIFF_GSREF = dt.Rows.Item(i).Item("ZUSIFF_GSREF") & "|"
                    ZUSIFF_ZUEXU = dt.Rows.Item(i).Item("ZUSIFF_ZUEXU").ToString.Replace(",", ".") & "|"
                    ZUSIFF_WHRGE = dt.Rows.Item(i).Item("ZUSIFF_WHRGE") & "|"
                    ZUSIFF_DXZGA = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ZUSIFF_DXZGA")) & "|"
                    ZUSIFF_DXVNE = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ZUSIFF_DXVNE")) & "|"
                    ZUSIFF_DXBSE = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ZUSIFF_DXBSE")) & "|"
                    ZUSIFF_KZREV = dt.Rows.Item(i).Item("ZUSIFF_KZREV") & "|"
                    ZUSIFF_KZUNW = dt.Rows.Item(i).Item("ZUSIFF_KZUNW") & "|"
                    ZUSIFF_KZABR = dt.Rows.Item(i).Item("ZUSIFF_KZABR") & "|"
                    ZUSIFF_WLKKZ = dt.Rows.Item(i).Item("ZUSIFF_WLKKZ") & "|"
                    ZUSIFF_KNZZU = dt.Rows.Item(i).Item("ZUSIFF_KNZZU") & "|"
                    ZUSIFF_ZOEKZ = dt.Rows.Item(i).Item("ZUSIFF_ZOEKZ") & "|"
                    ZUSIFF_KGZUO = dt.Rows.Item(i).Item("ZUSIFF_KGZUO") & "|"
                    ZUSIFF_ZUTYP = dt.Rows.Item(i).Item("ZUSIFF_ZUTYP") & "|"
                    ZUSIFF_AUSFL = dt.Rows.Item(i).Item("ZUSIFF_AUSFL") & "|"
                    ZUSIFF_DXAUD = dt.Rows.Item(i).Item("ZUSIFF_DXAUD") & "|"
                    ZUSIFF_KOART = dt.Rows.Item(i).Item("ZUSIFF_KOART") & "|"
                    ZUSIFF_GSART = dt.Rows.Item(i).Item("ZUSIFF_GSART") & "|"
                    ZUSIFF_RISGR = dt.Rows.Item(i).Item("ZUSIFF_RISGR") & "|"
                    ZUSIFF_KZUKU = dt.Rows.Item(i).Item("ZUSIFF_KZUKU") & "|"
                    ZUSIFF_ERHGE = dt.Rows.Item(i).Item("ZUSIFF_ERHGE") & "|"
                    ZUSIFF_GSARE = dt.Rows.Item(i).Item("ZUSIFF_GSARE") & "|"
                    ZUSIFF_HAFIN = dt.Rows.Item(i).Item("ZUSIFF_HAFIN") & "|"
                    ZUSIFF_PRDKT = dt.Rows.Item(i).Item("ZUSIFF_PRDKT") & "|"
                    ZUSIFF_INABU = dt.Rows.Item(i).Item("ZUSIFF_INABU").ToString.Replace(",", ".") & "|"
                    ZUSIFF_KZAKL = dt.Rows.Item(i).Item("ZUSIFF_KZAKL") & "|"
                    ZUSIFF_POOLI = dt.Rows.Item(i).Item("ZUSIFF_POOLI") & "|" 'New
                    ZUSIFF_AEIDF = dt.Rows.Item(i).Item("ZUSIFF_AEIDF") & "|" 'New
                    ZUSIFF_FREI1 = dt.Rows.Item(i).Item("ZUSIFF_FREI1") & "|"
                    ZUSIFF_FREI2 = dt.Rows.Item(i).Item("ZUSIFF_FREI2") & "|"
                    ZUSIFF_FREI3 = dt.Rows.Item(i).Item("ZUSIFF_FREI3") & "|"
                    ZUSIFF_FREI4 = dt.Rows.Item(i).Item("ZUSIFF_FREI4") & "|"
                    ZUSIFF_FREI5 = dt.Rows.Item(i).Item("ZUSIFF_FREI5") & "|"
                    ZUSIFF_LOEKZ = dt.Rows.Item(i).Item("ZUSIFF_LOEKZ") & "|"
                    ZUSIFF_IFNAM = "ZUSIAF" & "|"
                    ZUSIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ZUSIFF_DXIFD"))

                    CSV_ROW = ZUSIFF_MDANT & ZUSIFF_FILNR & ZUSIFF_KDREA & ZUSIFF_ZUREF & ZUSIFF_ZUART & ZUSIFF_KRART & ZUSIFF_MODUL & ZUSIFF_KTONR & ZUSIFF_GSREF & ZUSIFF_ZUEXU & ZUSIFF_WHRGE & ZUSIFF_DXZGA & ZUSIFF_DXVNE & ZUSIFF_DXBSE & ZUSIFF_KZREV & ZUSIFF_KZUNW & ZUSIFF_KZABR & ZUSIFF_WLKKZ & ZUSIFF_KNZZU & ZUSIFF_ZOEKZ & ZUSIFF_KGZUO & ZUSIFF_ZUTYP & ZUSIFF_AUSFL & ZUSIFF_DXAUD & ZUSIFF_KOART & ZUSIFF_GSART & ZUSIFF_RISGR & ZUSIFF_KZUKU & ZUSIFF_ERHGE & ZUSIFF_GSARE & ZUSIFF_HAFIN & ZUSIFF_PRDKT & ZUSIFF_INABU & ZUSIFF_KZAKL & ZUSIFF_POOLI & ZUSIFF_AEIDF & ZUSIFF_FREI1 & ZUSIFF_FREI2 & ZUSIFF_FREI3 & ZUSIFF_FREI4 & ZUSIFF_FREI5 & ZUSIFF_LOEKZ & ZUSIFF_IFNAM & ZUSIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ZUSIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.ZUSIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.ZUSIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "ZUSIAF_MDANT|ZUSIAF_FILNR|ZUSIAF_KDREA|ZUSIAF_ZUREF|ZUSIAF_ZUART|ZUSIAF_KRART|ZUSIAF_MODUL|ZUSIAF_KTONR|ZUSIAF_GSREF|ZUSIAF_ZUEXU|ZUSIAF_WHRGE|ZUSIAF_DXZGA|ZUSIAF_DXVNE|ZUSIAF_DXBSE|ZUSIAF_KZREV|ZUSIAF_KZUNW|ZUSIAF_KZABR|ZUSIAF_WLKKZ|ZUSIAF_KNZZU|ZUSIAF_ZOEKZ|ZUSIAF_KGZUO|ZUSIAF_ZUTYP|ZUSIAF_AUSFL|ZUSIAF_DXAUD|ZUSIAF_KOART|ZUSIAF_GSART|ZUSIAF_RISGR|ZUSIAF_KZUKU|ZUSIAF_ERHGE|ZUSIAF_GSARE|ZUSIAF_HAFIN|ZUSIAF_PRDKT|ZUSIAF_INABU|ZUSIAF_KZAKL|ZUSIAF_POOLI|ZUSIAF_AEIDF|ZUSIAF_FREI1|ZUSIAF_FREI2|ZUSIAF_FREI3|ZUSIAF_FREI4|ZUSIAF_FREI5|ZUSIAF_LOEKZ|ZUSIAF_IFNAM|ZUSIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "ZUSIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "ZUSIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "ZUSIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File ZUSIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File ZUSIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub GAKIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_GAKIFF] where [GAKIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GAKIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GAKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If



                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GAKIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GAKIAF_MDANT|GAKIAF_GARFN|GAKIAF_FILNR|GAKIAF_GARTG|GAKIAF_GARTI|GAKIAF_HBKZN|GAKIAF_DXVND|GAKIAF_DXBSD|GAKIAF_GABTR|GAKIAF_DXGBT|GAKIAF_ATOPV|GAKIAF_APROV|GAKIAF_DXPRO|GAKIAF_VWTER|GAKIAF_WHISO|GAKIAF_GSPRZ|GAKIAF_MODUL|GAKIAF_KDREA|GAKIAF_SICGB|GAKIAF_KTONR|GAKIAF_GSREF|GAKIAF_DEPNR|GAKIAF_KZBVK|GAKIAF_BEBTR|GAKIAF_DXBWE|GAKIAF_VEBTR|GAKIAF_DXVWE|GAKIAF_VORBT|GAKIAF_OLDSL|GAKIAF_PLZNR|GAKIAF_SIGAR|GAKIAF_KRRFN|GAKIAF_HCMPV|GAKIAF_HCWHG|GAKIAF_LIQUD|GAKIAF_RSKFZ|GAKIAF_KZANR|GAKIAF_KZSUB|GAKIAF_KZZWB|GAKIAF_LFDGS|GAKIAF_FREI1|GAKIAF_FREI2|GAKIAF_FREI3|GAKIAF_FREI4|GAKIAF_FREI5|GAKIAF_LOEKZ|GAKIAF_IFNAM|GAKIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim GAKIFF_MDANT As String = Nothing
                Dim GAKIFF_GARFN As String = Nothing
                Dim GAKIFF_FILNR As String = Nothing
                Dim GAKIFF_GARTG As String = Nothing
                Dim GAKIFF_GARTI As String = Nothing
                Dim GAKIFF_HBKZN As String = Nothing
                Dim GAKIFF_DXVND As String = Nothing
                Dim GAKIFF_DXBSD As String = Nothing
                Dim GAKIFF_GABTR As String = Nothing
                Dim GAKIFF_DXGBT As String = Nothing 'New 1.25
                Dim GAKIFF_ATOPV As String = Nothing 'New 1.25
                Dim GAKIFF_APROV As String = Nothing 'New 1.25
                Dim GAKIFF_DXPRO As String = Nothing 'New 1.25
                Dim GAKIFF_VWTER As String = Nothing
                Dim GAKIFF_WHISO As String = Nothing
                Dim GAKIFF_GSPRZ As String = Nothing
                Dim GAKIFF_MODUL As String = Nothing
                Dim GAKIFF_KDREA As String = Nothing
                Dim GAKIFF_SICGB As String = Nothing 'New 1.25
                Dim GAKIFF_KTONR As String = Nothing
                Dim GAKIFF_GSREF As String = Nothing
                Dim GAKIFF_DEPNR As String = Nothing
                Dim GAKIFF_KZBVK As String = Nothing
                Dim GAKIFF_BEBTR As String = Nothing
                Dim GAKIFF_DXBWE As String = Nothing 'New 1.25
                Dim GAKIFF_VEBTR As String = Nothing
                Dim GAKIFF_DXVWE As String = Nothing 'New 1.25
                Dim GAKIFF_VORBT As String = Nothing
                Dim GAKIFF_OLDSL As String = Nothing
                Dim GAKIFF_PLZNR As String = Nothing 'New 1.25
                Dim GAKIFF_SIGAR As String = Nothing
                Dim GAKIFF_KRRFN As String = Nothing
                Dim GAKIFF_HCMPV As String = Nothing
                Dim GAKIFF_HCWHG As String = Nothing
                Dim GAKIFF_LIQUD As String = Nothing
                Dim GAKIFF_RSKFZ As String = Nothing
                Dim GAKIFF_KZANR As String = Nothing
                Dim GAKIFF_KZSUB As String = Nothing
                Dim GAKIFF_KZZWB As String = Nothing
                Dim GAKIFF_LFDGS As String = Nothing 'New 1.25
                Dim GAKIFF_FREI1 As String = Nothing
                Dim GAKIFF_FREI2 As String = Nothing
                Dim GAKIFF_FREI3 As String = Nothing
                Dim GAKIFF_FREI4 As String = Nothing
                Dim GAKIFF_FREI5 As String = Nothing
                Dim GAKIFF_LOEKZ As String = Nothing
                Dim GAKIFF_IFNAM As String = Nothing
                Dim GAKIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "GAKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GAKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GAKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_GAKIFF] where [GAKIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    GAKIFF_MDANT = dt.Rows.Item(i).Item("GAKIFF_MDANT") & "|"
                    GAKIFF_GARFN = dt.Rows.Item(i).Item("GAKIFF_GARFN") & "|"
                    GAKIFF_FILNR = dt.Rows.Item(i).Item("GAKIFF_FILNR") & "|"
                    GAKIFF_GARTG = dt.Rows.Item(i).Item("GAKIFF_GARTG") & "|"
                    GAKIFF_GARTI = dt.Rows.Item(i).Item("GAKIFF_GARTI") & "|"
                    GAKIFF_HBKZN = dt.Rows.Item(i).Item("GAKIFF_HBKZN") & "|"
                    GAKIFF_DXVND = dt.Rows.Item(i).Item("GAKIFF_DXVND") & "|"
                    GAKIFF_DXBSD = dt.Rows.Item(i).Item("GAKIFF_DXBSD") & "|"
                    GAKIFF_GABTR = dt.Rows.Item(i).Item("GAKIFF_GABTR") & "|"
                    GAKIFF_DXGBT = dt.Rows.Item(i).Item("GAKIFF_DXGBT") & "|"
                    GAKIFF_ATOPV = dt.Rows.Item(i).Item("GAKIFF_ATOPV") & "|"
                    GAKIFF_APROV = dt.Rows.Item(i).Item("GAKIFF_APROV") & "|"
                    GAKIFF_DXPRO = dt.Rows.Item(i).Item("GAKIFF_DXPRO") & "|"
                    GAKIFF_VWTER = dt.Rows.Item(i).Item("GAKIFF_VWTER") & "|"
                    GAKIFF_WHISO = dt.Rows.Item(i).Item("GAKIFF_WHISO") & "|"
                    GAKIFF_GSPRZ = dt.Rows.Item(i).Item("GAKIFF_GSPRZ") & "|"
                    GAKIFF_MODUL = dt.Rows.Item(i).Item("GAKIFF_MODUL") & "|"
                    GAKIFF_KDREA = dt.Rows.Item(i).Item("GAKIFF_KDNRG") & "|"
                    GAKIFF_SICGB = dt.Rows.Item(i).Item("GAKIFF_SICGB") & "|"
                    GAKIFF_KTONR = dt.Rows.Item(i).Item("GAKIFF_KTONR") & "|"
                    GAKIFF_GSREF = dt.Rows.Item(i).Item("GAKIFF_GSREF") & "|"
                    GAKIFF_DEPNR = dt.Rows.Item(i).Item("GAKIFF_DEPNR") & "|"
                    GAKIFF_KZBVK = dt.Rows.Item(i).Item("GAKIFF_KZBVK") & "|"
                    GAKIFF_BEBTR = dt.Rows.Item(i).Item("GAKIFF_BEBTR") & "|"
                    GAKIFF_DXBWE = dt.Rows.Item(i).Item("GAKIFF_DXBWE") & "|"
                    GAKIFF_VEBTR = dt.Rows.Item(i).Item("GAKIFF_VEBTR") & "|"
                    GAKIFF_DXVWE = dt.Rows.Item(i).Item("GAKIFF_DXVWE") & "|"
                    GAKIFF_VORBT = dt.Rows.Item(i).Item("GAKIFF_VORBT") & "|"
                    GAKIFF_OLDSL = dt.Rows.Item(i).Item("GAKIFF_OLDSL") & "|"
                    GAKIFF_PLZNR = dt.Rows.Item(i).Item("GAKIFF_PLZNR") & "|"
                    GAKIFF_SIGAR = dt.Rows.Item(i).Item("GAKIFF_SIGAR") & "|"
                    GAKIFF_KRRFN = dt.Rows.Item(i).Item("GAKIFF_KRRFN") & "|"
                    GAKIFF_HCMPV = dt.Rows.Item(i).Item("GAKIFF_HCMPV") & "|"
                    GAKIFF_HCWHG = dt.Rows.Item(i).Item("GAKIFF_HCWHG") & "|"
                    GAKIFF_LIQUD = dt.Rows.Item(i).Item("GAKIFF_LIQUD") & "|"
                    GAKIFF_RSKFZ = dt.Rows.Item(i).Item("GAKIFF_RSKFZ") & "|"
                    GAKIFF_KZANR = dt.Rows.Item(i).Item("GAKIFF_KZANR") & "|"
                    GAKIFF_KZSUB = dt.Rows.Item(i).Item("GAKIFF_KZSUB") & "|"
                    GAKIFF_KZZWB = dt.Rows.Item(i).Item("GAKIFF_KZZWB") & "|"
                    GAKIFF_LFDGS = dt.Rows.Item(i).Item("GAKIFF_LFDGS") & "|"
                    GAKIFF_FREI1 = dt.Rows.Item(i).Item("GAKIFF_FREI1") & "|"
                    GAKIFF_FREI2 = dt.Rows.Item(i).Item("GAKIFF_FREI2") & "|"
                    GAKIFF_FREI3 = dt.Rows.Item(i).Item("GAKIFF_FREI3") & "|"
                    GAKIFF_FREI4 = dt.Rows.Item(i).Item("GAKIFF_FREI4") & "|"
                    GAKIFF_FREI5 = dt.Rows.Item(i).Item("GAKIFF_FREI5") & "|"
                    GAKIFF_LOEKZ = dt.Rows.Item(i).Item("GAKIFF_LOEKZ") & "|"
                    GAKIFF_IFNAM = "GAKIAF" & "|"
                    GAKIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GAKIFF_DXIFD"))


                    CSV_ROW = GAKIFF_MDANT & GAKIFF_GARFN & GAKIFF_FILNR & GAKIFF_GARTG & GAKIFF_GARTI & GAKIFF_HBKZN & GAKIFF_DXVND & GAKIFF_DXBSD & GAKIFF_GABTR & GAKIFF_DXGBT & GAKIFF_ATOPV & GAKIFF_APROV & GAKIFF_DXPRO & GAKIFF_VWTER & GAKIFF_WHISO & GAKIFF_GSPRZ & GAKIFF_MODUL & GAKIFF_KDREA & GAKIFF_SICGB & GAKIFF_KTONR & GAKIFF_GSREF & GAKIFF_DEPNR & GAKIFF_KZBVK & GAKIFF_BEBTR & GAKIFF_DXBWE & GAKIFF_VEBTR & GAKIFF_DXVWE & GAKIFF_VORBT & GAKIFF_OLDSL & GAKIFF_PLZNR & GAKIFF_SIGAR & GAKIFF_KRRFN & GAKIFF_HCMPV & GAKIFF_HCWHG & GAKIFF_LIQUD & GAKIFF_RSKFZ & GAKIFF_KZANR & GAKIFF_KZSUB & GAKIFF_KZZWB & GAKIFF_LFDGS & GAKIFF_FREI1 & GAKIFF_FREI2 & GAKIFF_FREI3 & GAKIFF_FREI4 & GAKIFF_FREI5 & GAKIFF_LOEKZ & GAKIFF_IFNAM & GAKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GAKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.GAKIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.GAKIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "GAKIAF_MDANT|GAKIAF_GARFN|GAKIAF_FILNR|GAKIAF_GARTG|GAKIAF_GARTI|GAKIAF_HBKZN|GAKIAF_DXVND|GAKIAF_DXBSD|GAKIAF_GABTR|GAKIAF_DXGBT|GAKIAF_ATOPV|GAKIAF_APROV|GAKIAF_DXPRO|GAKIAF_VWTER|GAKIAF_WHISO|GAKIAF_GSPRZ|GAKIAF_MODUL|GAKIAF_KDREA|GAKIAF_SICGB|GAKIAF_KTONR|GAKIAF_GSREF|GAKIAF_DEPNR|GAKIAF_KZBVK|GAKIAF_BEBTR|GAKIAF_DXBWE|GAKIAF_VEBTR|GAKIAF_DXVWE|GAKIAF_VORBT|GAKIAF_OLDSL|GAKIAF_PLZNR|GAKIAF_SIGAR|GAKIAF_KRRFN|GAKIAF_HCMPV|GAKIAF_HCWHG|GAKIAF_LIQUD|GAKIAF_RSKFZ|GAKIAF_KZANR|GAKIAF_KZSUB|GAKIAF_KZZWB|GAKIAF_LFDGS|GAKIAF_FREI1|GAKIAF_FREI2|GAKIAF_FREI3|GAKIAF_FREI4|GAKIAF_FREI5|GAKIAF_LOEKZ|GAKIAF_IFNAM|GAKIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GAKIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GAKIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GAKIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GAKIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File GAKIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub 'OK

    Private Sub GAGIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_GAGIFF] where [GAGIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GAGIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GAGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GAGIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GAGIAF_MDANT|GAGIAF_GARFN|GAGIAF_MODUL|GAGIAF_KDREA|GAGIAF_GKRKT|GAGIAF_GSREF|GAGIAF_GLFDN|GAGIAF_GSPRZ|GAGIAF_SIMAX|GAGIAF_SIMWH|GAGIAF_HCKRA|GAGIAF_KZSUB|GAGIAF_KZZWB|GAGIAF_FREI1|GAGIAF_FREI2|GAGIAF_FREI3|GAGIAF_LOEKZ|GAGIAF_IFNAM|GAGIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim GAGIFF_MDANT As String = Nothing
                Dim GAGIFF_GARFN As String = Nothing
                Dim GAGIFF_MODUL As String = Nothing
                Dim GAGIFF_KDREA As String = Nothing
                Dim GAGIFF_GKRKT As String = Nothing
                Dim GAGIFF_GSREF As String = Nothing
                Dim GAGIFF_GLFDN As String = Nothing
                Dim GAGIFF_GSPRZ As String = Nothing 'New 1.25
                Dim GAGIFF_SIMAX As String = Nothing 'New 1.25
                Dim GAGIFF_SIMWH As String = Nothing 'New 1.25
                Dim GAGIFF_HCKRA As String = Nothing
                Dim GAGIFF_KZSUB As String = Nothing
                Dim GAGIFF_KZZWB As String = Nothing
                Dim GAGIFF_FREI1 As String = Nothing
                Dim GAGIFF_FREI2 As String = Nothing
                Dim GAGIFF_FREI3 As String = Nothing
                Dim GAGIFF_LOEKZ As String = Nothing
                Dim GAGIFF_IFNAM As String = Nothing
                Dim GAGIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "GAGIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GAGIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GAGIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_GAGIFF] where [GAGIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    GAGIFF_MDANT = dt.Rows.Item(i).Item("GAGIFF_MDANT") & "|"
                    GAGIFF_GARFN = dt.Rows.Item(i).Item("GAGIFF_GARFN") & "|"
                    GAGIFF_MODUL = dt.Rows.Item(i).Item("GAGIFF_MODUL") & "|"
                    GAGIFF_KDREA = dt.Rows.Item(i).Item("GAGIFF_KDNRH") & "|"
                    GAGIFF_GKRKT = dt.Rows.Item(i).Item("GAGIFF_GKRKT") & "|"
                    GAGIFF_GSREF = dt.Rows.Item(i).Item("GAGIFF_GSREF") & "|"
                    GAGIFF_GLFDN = dt.Rows.Item(i).Item("GAGIFF_GLFDN") & "|"
                    GAGIFF_GSPRZ = dt.Rows.Item(i).Item("GAGIFF_GSPRZ") & "|"
                    GAGIFF_SIMAX = dt.Rows.Item(i).Item("GAGIFF_SIMAX") & "|"
                    GAGIFF_SIMWH = dt.Rows.Item(i).Item("GAGIFF_SIMWH") & "|"
                    GAGIFF_HCKRA = dt.Rows.Item(i).Item("GAGIFF_HCKRA") & "|"
                    GAGIFF_KZSUB = dt.Rows.Item(i).Item("GAGIFF_KZSUB") & "|"
                    GAGIFF_KZZWB = dt.Rows.Item(i).Item("GAGIFF_KZZWB") & "|"
                    GAGIFF_FREI1 = dt.Rows.Item(i).Item("GAGIFF_FREI1") & "|"
                    GAGIFF_FREI2 = dt.Rows.Item(i).Item("GAGIFF_FREI2") & "|"
                    GAGIFF_FREI3 = dt.Rows.Item(i).Item("GAGIFF_FREI3") & "|"
                    GAGIFF_LOEKZ = dt.Rows.Item(i).Item("GAGIFF_LOEKZ") & "|"
                    GAGIFF_IFNAM = "GAGIAF" & "|"
                    GAGIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GAGIFF_DXIFD"))


                    CSV_ROW = GAGIFF_MDANT & GAGIFF_GARFN & GAGIFF_MODUL & GAGIFF_KDREA & GAGIFF_GKRKT & GAGIFF_GSREF & GAGIFF_GLFDN & GAGIFF_GSPRZ & GAGIFF_SIMAX & GAGIFF_SIMWH & GAGIFF_HCKRA & GAGIFF_KZSUB & GAGIFF_KZZWB & GAGIFF_FREI1 & GAGIFF_FREI2 & GAGIFF_FREI3 & GAGIFF_LOEKZ & GAGIFF_IFNAM & GAGIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GAGIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.GAGIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.GAGIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "GAGIAF_MDANT|GAGIAF_GARFN|GAGIAF_MODUL|GAGIAF_KDREA|GAGIAF_GKRKT|GAGIAF_GSREF|GAGIAF_GLFDN|GAGIAF_GSPRZ|GAGIAF_SIMAX|GAGIAF_SIMWH|GAGIAF_HCKRA|GAGIAF_KZSUB|GAGIAF_KZZWB|GAGIAF_FREI1|GAGIAF_FREI2|GAGIAF_FREI3|GAGIAF_LOEKZ|GAGIAF_IFNAM|GAGIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GAGIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GAGIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GAGIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GAGIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File GAGIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub 'OK

    Private Sub LQKIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then

            'BgwBaisFilesCreation.ReportProgress(1, "Start updating Table:BAIS_LQKIFF...")
            'BgwBaisFilesCreation.ReportProgress(1, "Set Field:LQKIFF_KZGBZ=0")
            'cmd.CommandText = "UPDATE [BAIS_LQKIFF] set [LQKIFF_KZGBZ]='0' where [LQKIFF_DXIFD]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'BgwBaisFilesCreation.ReportProgress(1, "Set Field:[LQKIFF_KZGBZ]='1' only if [LQKIFF_KDNRH]=([KNEIFF_KDNRH] where [KNEIFF_GRPKZ] is not NULL)")
            'cmd.CommandText = "UPDATE [BAIS_LQKIFF] set [LQKIFF_KZGBZ]='1' where [LQKIFF_DXIFD]='" & rdsql & "'  and [LQKIFF_KDNRH] in (Select [KNEIFF_KDNRH] from BAIS_KNEIFF where KNEIFF_DXIFD='" & rdsql & "' and [KNEIFF_GRPKZ] is not NULL)"
            'cmd.ExecuteNonQuery()

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_LQKIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_LQKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If



            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: LQKIAF_CCB.csv...Please wait...")
                'New Code
                Dim CSV_HEADER As String = "LQKIAF_MDANT|LQKIAF_KDREA|LQKIAF_LQSEK|LQKIAF_OBBTG|LQKIAF_KZGBZ|LQKIAF_IFNAM|LQKIAF_DXIFD"
                Dim CSV_ROW As String = Nothing

                Dim LQKIFF_MDANT As String = Nothing
                Dim LQKIFF_KDREA As String = Nothing
                Dim LQKIFF_LQSEK As String = Nothing
                Dim LQKIFF_OBBTG As String = Nothing
                Dim LQKIFF_KZGBZ As String = Nothing
                Dim LQKIFF_IFNAM As String = Nothing
                Dim LQKIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "LQKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "LQKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "LQKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT * FROM  [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "' and [ID] in (Select Min([ID]) from [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "' GROUP BY [LQKIFF_KDNRH])"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    LQKIFF_MDANT = dt.Rows.Item(i).Item("LQKIFF_MDANT") & "|"
                    LQKIFF_KDREA = dt.Rows.Item(i).Item("LQKIFF_KDNRH") & "|"
                    LQKIFF_LQSEK = dt.Rows.Item(i).Item("LQKIFF_LQSEK") & "|"
                    LQKIFF_OBBTG = dt.Rows.Item(i).Item("LQKIFF_OBBTG") & "|"
                    LQKIFF_KZGBZ = dt.Rows.Item(i).Item("LQKIFF_KZGBZ") & "|"
                    LQKIFF_IFNAM = "LQKIAF" & "|"
                    LQKIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("LQKIFF_DXIFD"))


                    CSV_ROW = LQKIFF_MDANT & LQKIFF_KDREA & LQKIFF_LQSEK & LQKIFF_OBBTG & LQKIFF_KZGBZ & LQKIFF_IFNAM & LQKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "LQKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.LQKIFF_Result = "Created"
            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.LQKIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "LQKIAF_MDANT|LQKIAF_KDREA|LQKIAF_LQSEK|LQKIAF_OBBTG|LQKIAF_KZGBZ|LQKIAF_IFNAM|LQKIAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "LQKIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "LQKIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "LQKIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File LQKIAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File LQKIFF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub DESIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count > 0 Then
            Try
                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                ''SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                'BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_DESIFF Table with DESIFF_DXIFD: " & rd)
                'cmd.CommandText = "DELETE FROM [BAIS_DESIFF] where [DESIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Insert SWAP data to table:DESIFF_CCB")
                'cmd.CommandText = "INSERT INTO [BAIS_DESIFF] ([DESIFF_GSREF],[DESIFF_KDNRH],[DESIFF_WHISO],[DESIFF_DXIFD]) Select distinct [Contract Collateral ID],[Client No],[Org Ccy],[RiskDate] from [CREDIT RISK] where [Contract Type] in ('SWAP') and [RiskDate]='" & rdsql & "' and [Maturity Date]>[RiskDate]"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update DESIFF_CCB with relevant Data from MAK REPORT - Start Date and Maturity Date")
                'cmd.CommandText = "UPDATE A SET A.[DESIFF_DXVND]=B.[Start Date], A.[DESIFF_DXBSD]=B.[Maturity Date] from [BAIS_DESIFF] A INNER JOIN [MAK REPORT] B on A.[DESIFF_GSREF]=B.[Contract Collateral ID] where B.[RiskDate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update DESIFF_CCB with relevant Data from ACCRUED INTEREST ANALYSIS Report")
                'cmd.CommandText = "UPDATE A SET A.[DESIFF_ZINSS]=B.[Current Interest Rate]from [BAIS_DESIFF] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B on A.[DESIFF_GSREF]=B.[Contract] where [Class] in ('Assets') and B.[Datadate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE A SET A.[DESIFF_ZINS2]=B.[Current Interest Rate]from [BAIS_DESIFF] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B on A.[DESIFF_GSREF]=B.[Contract] where [Class] in ('Liabilities') and B.[Datadate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE A SET A.[DESIFF_KBTRG]=ABS(B.[Principal (Org  Ccy)]),A.[DESIFF_EBTRG]=ABS(B.[Principal (Org  Ccy)]), A.[DESIFF_WHGKP]=B.[Org Ccy] from [BAIS_DESIFF] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B on A.[DESIFF_GSREF]=B.[Contract] where [Class] in ('Assets') and B.[Datadate]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_DESIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_DESIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: DESIAF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "DESIAF_MDANT|DESIAF_FILNR|DESIAF_MODUL|DESIAF_DEART|DESIAF_GSREF|DESIAF_KDREA|DESIAF_GSKLA|DESIAF_SUKLA|DESIAF_KRART|DESIAF_WHISO|DESIAF_DXVND|DESIAF_DXBSD|DESIAF_DXVNU|DESIAF_DXBSU|DESIAF_ZWRIS|DESIAF_ZINSS|DESIAF_ZINS2|DESIAF_KZZS1|DESIAF_KZZS2|DESIAF_VZIN1|DESIAF_VZIN2|DESIAF_KZKON|DESIAF_KZBAN|DESIAF_EBTRG|DESIAF_GBTRG|DESIAF_GWISO|DESIAF_HBKZN|DESIAF_KZOTC|DESIAF_KBTRG|DESIAF_PTEIN|DESIAF_WHGKP|DESIAF_BCHSW|DESIAF_BWVNS|DESIAF_ABGBT|DESIAF_GABGB|DESIAF_WHGBU|DESIAF_URDEA|DESIAF_NETKR|DESIAF_KZCVA|DESIAF_GSARE|DESIAF_FAIRV|DESIAF_DXVKT|DESIAF_HFZGP|DESIAF_AFREF|DESIAF_POOLI|DESIAF_AEIDF|DESIAF_BESVB|DESIAF_RESE1|DESIAF_RESE2|DESIAF_FREI1|DESIAF_FREI2|DESIAF_FREI3|DESIAF_LOEKZ|DESIAF_IFNAM|DESIAF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim DESIFF_MDANT As String = Nothing
                Dim DESIFF_FILNR As String = Nothing
                Dim DESIFF_MODUL As String = Nothing
                Dim DESIFF_DEART As String = Nothing
                Dim DESIFF_GSREF As String = Nothing
                Dim DESIFF_KDREA As String = Nothing
                Dim DESIFF_GSKLA As String = Nothing
                Dim DESIFF_SUKLA As String = Nothing
                Dim DESIFF_KRART As String = Nothing
                Dim DESIFF_WHISO As String = Nothing
                Dim DESIFF_DXVND As String = Nothing
                Dim DESIFF_DXBSD As String = Nothing
                Dim DESIFF_DXVNU As String = Nothing
                Dim DESIFF_DXBSU As String = Nothing
                Dim DESIFF_ZWRIS As String = Nothing
                Dim DESIFF_ZINSS As String = Nothing
                Dim DESIFF_ZINS2 As String = Nothing
                Dim DESIFF_KZZS1 As String = Nothing
                Dim DESIFF_KZZS2 As String = Nothing
                Dim DESIFF_VZIN1 As String = Nothing
                Dim DESIFF_VZIN2 As String = Nothing
                Dim DESIFF_KZKON As String = Nothing
                Dim DESIFF_KZBAN As String = Nothing
                Dim DESIFF_EBTRG As String = Nothing
                Dim DESIFF_GBTRG As String = Nothing
                Dim DESIFF_GWISO As String = Nothing
                Dim DESIFF_HBKZN As String = Nothing
                Dim DESIFF_KZOTC As String = Nothing
                Dim DESIFF_KBTRG As String = Nothing
                Dim DESIFF_PTEIN As String = Nothing
                Dim DESIFF_WHGKP As String = Nothing
                Dim DESIFF_BCHSW As String = Nothing
                Dim DESIFF_BWVNS As String = Nothing 'New 1.23
                Dim DESIFF_ABGBT As String = Nothing
                Dim DESIFF_GABGB As String = Nothing 'New 1.25
                Dim DESIFF_WHGBU As String = Nothing
                Dim DESIFF_URDEA As String = Nothing
                Dim DESIFF_NETKR As String = Nothing
                Dim DESIFF_KZCVA As String = Nothing
                Dim DESIFF_GSARE As String = Nothing
                Dim DESIFF_FAIRV As String = Nothing
                Dim DESIFF_DXVKT As String = Nothing
                Dim DESIFF_HFZGP As String = Nothing
                Dim DESIFF_AFREF As String = Nothing
                Dim DESIFF_POOLI As String = Nothing
                Dim DESIFF_AEIDF As String = Nothing
                Dim DESIFF_BESVB As String = Nothing
                Dim DESIFF_RESE1 As String = Nothing
                Dim DESIFF_RESE2 As String = Nothing
                Dim DESIFF_FREI1 As String = Nothing
                Dim DESIFF_FREI2 As String = Nothing
                Dim DESIFF_FREI3 As String = Nothing
                Dim DESIFF_LOEKZ As String = Nothing
                Dim DESIFF_IFNAM As String = Nothing
                Dim DESIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "DESIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DESIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_DESIFF] where [DESIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in DVTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("DVTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("DVTIFF_KDNRH"))
                    DESIFF_MDANT = dt.Rows.Item(i).Item("DESIFF_MDANT") & "|"
                    DESIFF_FILNR = dt.Rows.Item(i).Item("DESIFF_FILNR") & "|"
                    DESIFF_MODUL = dt.Rows.Item(i).Item("DESIFF_MODUL") & "|"
                    DESIFF_DEART = dt.Rows.Item(i).Item("DESIFF_DEART") & "|"
                    DESIFF_GSREF = dt.Rows.Item(i).Item("DESIFF_GSREF") & "|"
                    DESIFF_KDREA = dt.Rows.Item(i).Item("DESIFF_KDNRH") & "|"
                    DESIFF_GSKLA = dt.Rows.Item(i).Item("DESIFF_GSKLA") & "|"
                    DESIFF_SUKLA = dt.Rows.Item(i).Item("DESIFF_SUKLA") & "|"
                    DESIFF_KRART = dt.Rows.Item(i).Item("DESIFF_KRART") & "|"
                    DESIFF_WHISO = dt.Rows.Item(i).Item("DESIFF_WHISO") & "|"
                    DESIFF_DXVND = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXVND")) & "|"
                    DESIFF_DXBSD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXBSD")) & "|"
                    DESIFF_DXVNU = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXVNU")) & "|"
                    DESIFF_DXBSU = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXBSU")) & "|"
                    DESIFF_ZWRIS = dt.Rows.Item(i).Item("DESIFF_ZWRIS") & "|"
                    DESIFF_ZINSS = dt.Rows.Item(i).Item("DESIFF_ZINSS").ToString.Replace(",", ".") & "|"
                    DESIFF_ZINS2 = dt.Rows.Item(i).Item("DESIFF_ZINS2").ToString.Replace(",", ".") & "|"
                    DESIFF_KZZS1 = dt.Rows.Item(i).Item("DESIFF_KZZS1") & "|"
                    DESIFF_KZZS2 = dt.Rows.Item(i).Item("DESIFF_KZZS2") & "|"
                    DESIFF_VZIN1 = dt.Rows.Item(i).Item("DESIFF_VZIN1") & "|"
                    DESIFF_VZIN2 = dt.Rows.Item(i).Item("DESIFF_VZIN2") & "|"
                    DESIFF_KZKON = dt.Rows.Item(i).Item("DESIFF_KZKON") & "|"
                    DESIFF_KZBAN = dt.Rows.Item(i).Item("DESIFF_KZBAN") & "|"
                    DESIFF_EBTRG = dt.Rows.Item(i).Item("DESIFF_EBTRG").ToString.Replace(",", ".") & "|"
                    DESIFF_GBTRG = dt.Rows.Item(i).Item("DESIFF_GBTRG").ToString.Replace(",", ".") & "|"
                    DESIFF_GWISO = dt.Rows.Item(i).Item("DESIFF_GWISO") & "|"
                    DESIFF_HBKZN = dt.Rows.Item(i).Item("DESIFF_HBKZN") & "|"
                    DESIFF_KZOTC = dt.Rows.Item(i).Item("DESIFF_KZOTC") & "|"
                    DESIFF_KBTRG = dt.Rows.Item(i).Item("DESIFF_KBTRG").ToString.Replace(",", ".") & "|"
                    DESIFF_PTEIN = dt.Rows.Item(i).Item("DESIFF_PTEIN").ToString.Replace(",", ".") & "|"
                    DESIFF_WHGKP = dt.Rows.Item(i).Item("DESIFF_WHGKP") & "|"
                    DESIFF_BCHSW = dt.Rows.Item(i).Item("DESIFF_BCHSW").ToString.Replace(",", ".") & "|"
                    DESIFF_BWVNS = dt.Rows.Item(i).Item("DESIFF_BWVNS").ToString.Replace(",", ".") & "|" 'New 1.23
                    DESIFF_ABGBT = dt.Rows.Item(i).Item("DESIFF_ABGBT").ToString.Replace(",", ".") & "|"
                    DESIFF_GABGB = dt.Rows.Item(i).Item("DESIFF_GABGB").ToString.Replace(",", ".") & "|" 'New 1.25
                    DESIFF_WHGBU = dt.Rows.Item(i).Item("DESIFF_WHGBU") & "|"
                    DESIFF_URDEA = dt.Rows.Item(i).Item("DESIFF_URDEA") & "|"
                    DESIFF_NETKR = dt.Rows.Item(i).Item("DESIFF_NETKR") & "|"
                    DESIFF_KZCVA = dt.Rows.Item(i).Item("DESIFF_KZCVA") & "|"
                    DESIFF_GSARE = dt.Rows.Item(i).Item("DESIFF_GSARE") & "|"
                    DESIFF_FAIRV = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_FAIRV")) & "|"
                    DESIFF_DXVKT = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXVKT")) & "|"
                    DESIFF_HFZGP = dt.Rows.Item(i).Item("DESIFF_HFZGP") & "|"
                    DESIFF_AFREF = dt.Rows.Item(i).Item("DESIFF_AFREF") & "|"
                    DESIFF_POOLI = dt.Rows.Item(i).Item("DESIFF_POOLI") & "|"
                    DESIFF_AEIDF = dt.Rows.Item(i).Item("DESIFF_AEIDF") & "|"
                    DESIFF_BESVB = dt.Rows.Item(i).Item("DESIFF_BESVB") & "|"
                    DESIFF_RESE1 = dt.Rows.Item(i).Item("DESIFF_RESE1") & "|"
                    DESIFF_RESE2 = dt.Rows.Item(i).Item("DESIFF_RESE2") & "|"
                    DESIFF_FREI1 = dt.Rows.Item(i).Item("DESIFF_FREI1") & "|"
                    DESIFF_FREI2 = dt.Rows.Item(i).Item("DESIFF_FREI2") & "|"
                    DESIFF_FREI3 = dt.Rows.Item(i).Item("DESIFF_FREI3") & "|"
                    DESIFF_LOEKZ = dt.Rows.Item(i).Item("DESIFF_LOEKZ") & "|"
                    DESIFF_IFNAM = "DESIAF" & "|"
                    DESIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXIFD"))

                    CSV_ROW = DESIFF_MDANT & DESIFF_FILNR & DESIFF_MODUL & DESIFF_DEART & DESIFF_GSREF & DESIFF_KDREA & DESIFF_GSKLA & DESIFF_SUKLA & DESIFF_KRART & DESIFF_WHISO & DESIFF_DXVND & DESIFF_DXBSD & DESIFF_DXVNU & DESIFF_DXBSU & DESIFF_ZWRIS & DESIFF_ZINSS & DESIFF_ZINS2 & DESIFF_KZZS1 & DESIFF_KZZS2 & DESIFF_VZIN1 & DESIFF_VZIN2 & DESIFF_KZKON & DESIFF_KZBAN & DESIFF_EBTRG & DESIFF_GBTRG & DESIFF_GWISO & DESIFF_HBKZN & DESIFF_KZOTC & DESIFF_KBTRG & DESIFF_PTEIN & DESIFF_WHGKP & DESIFF_BCHSW & DESIFF_BWVNS & DESIFF_ABGBT & DESIFF_GABGB & DESIFF_WHGBU & DESIFF_URDEA & DESIFF_NETKR & DESIFF_KZCVA & DESIFF_GSARE & DESIFF_FAIRV & DESIFF_DXVKT & DESIFF_HFZGP & DESIFF_AFREF & DESIFF_POOLI & DESIFF_AEIDF & DESIFF_BESVB & DESIFF_RESE1 & DESIFF_RESE2 & DESIFF_FREI1 & DESIFF_FREI2 & DESIFF_FREI3 & DESIFF_LOEKZ & DESIFF_IFNAM & DESIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                'cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                'cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.DESIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.DESIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "DESIAF_MDANT|DESIAF_FILNR|DESIAF_MODUL|DESIAF_DEART|DESIAF_GSREF|DESIAF_KDREA|DESIAF_GSKLA|DESIAF_SUKLA|DESIAF_KRART|DESIAF_WHISO|DESIAF_DXVND|DESIAF_DXBSD|DESIAF_DXVNU|DESIAF_DXBSU|DESIAF_ZWRIS|DESIAF_ZINSS|DESIAF_ZINS2|DESIAF_KZZS1|DESIAF_KZZS2|DESIAF_VZIN1|DESIAF_VZIN2|DESIAF_KZKON|DESIAF_KZBAN|DESIAF_EBTRG|DESIAF_GBTRG|DESIAF_GWISO|DESIAF_HBKZN|DESIAF_KZOTC|DESIAF_KBTRG|DESIAF_PTEIN|DESIAF_WHGKP|DESIAF_BCHSW|DESIAF_BWVNS|DESIAF_ABGBT|DESIAF_GABGB|DESIAF_WHGBU|DESIAF_URDEA|DESIAF_NETKR|DESIAF_KZCVA|DESIAF_GSARE|DESIAF_FAIRV|DESIAF_DXVKT|DESIAF_HFZGP|DESIAF_AFREF|DESIAF_POOLI|DESIAF_AEIDF|DESIAF_BESVB|DESIAF_RESE1|DESIAF_RESE2|DESIAF_FREI1|DESIAF_FREI2|DESIAF_FREI3|DESIAF_LOEKZ|DESIAF_IFNAM|DESIAF_DXIFD"
            Dim CSV_ROW As String = Nothing

            If File.Exists(BaisFilesCreationPath & "DESIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "DESIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File DESIAF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please update CREDIT RISK Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub 'OK

    Private Sub WHGIFF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count > 0 Then
            Try
                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                ''SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                'BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_WHGIFF Table with WHGIFF_DXIFD: " & rd)
                'cmd.CommandText = "DELETE FROM [BAIS_WHGIFF] where [WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Insert new data to table:BAIS_WHGIFF")
                'cmd.CommandText = "INSERT INTO [BAIS_WHGIFF] ([WHGIFF_WHISO],[WHGIFF_WNAME],[WHGIFF_WSLZB],[WHGIFF_DXEGK],[WHGIFF_DXIFD]) Select [CURRENCY CODE],[CURRENCY NAME],[LZB_CurrencyCode],'" & rdsql & "','" & rdsql & "' from [OWN_CURRENCIES] where [VALID] in ('Y')"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF with relevant Data from EXCHANGE RATES OCBS")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_MKURS]=B.[MIDDLE RATE] from [BAIS_WHGIFF] A INNER JOIN [EXCHANGE RATES OCBS] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] and A.[WHGIFF_DXIFD]=B.[EXCHANGE RATE DATE] where B.[EXCHANGE RATE DATE]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF regarding WHGIFF_WKLEH, WHGIFF_WNKST and WHGIFF_WSTAT")
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF Set WHGIFF_WKLEH=1 and WHGIFF_WNKST=0 where CURRENCY CODE does not accept decimals in OWN CURRENCIES")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_WKLEH]='1', A.WHGIFF_WNKST=0 from [BAIS_WHGIFF] A INNER JOIN [OWN_CURRENCIES] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] where B.[ACCEPTS DECIMALS] in ('N') and A.[WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF Set WHGIFF_WSTAT=I where CURRENCY CODE is NATIONAL CURRENCY in OWN CURRENCIES")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_WSTAT]='I' from [BAIS_WHGIFF] A INNER JOIN [OWN_CURRENCIES] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] where B.[OWN CURRENCY] in ('Y') and A.[WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()


                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_WHGIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_WHGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: WHGIFF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "WHGIFF_MDANT|WHGIFF_WHISO|WHGIFF_WNAME|WHGIFF_WSLZB|WHGIFF_WEINH|WHGIFF_WKLEH|WHGIFF_WNKST|WHGIFF_WSTAT|WHGIFF_MKURS|WHGIFF_DXEGK|WHGIFF_IFNAM|WHGIFF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim WHGIFF_MDANT As String = Nothing
                Dim WHGIFF_WHISO As String = Nothing
                Dim WHGIFF_WNAME As String = Nothing
                Dim WHGIFF_WSLZB As String = Nothing
                Dim WHGIFF_WEINH As String = Nothing
                Dim WHGIFF_WKLEH As String = Nothing
                Dim WHGIFF_WNKST As String = Nothing
                Dim WHGIFF_WSTAT As String = Nothing
                Dim WHGIFF_MKURS As String = Nothing
                Dim WHGIFF_DXEGK As String = Nothing
                Dim WHGIFF_IFNAM As String = Nothing
                Dim WHGIFF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "WHGIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "WHGIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_WHGIFF] where [WHGIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim Kurs As Double = dt.Rows.Item(i).Item("WHGIFF_MKURS")
                    Dim KursString As String = String.Format("{0:N6}", Double.Parse(Kurs))
                    'BgwBaisFilesCreation.ReportProgress(2, "Create Datarow in DVTIFF_CCB.csv File: " & dt.Rows.Item(i).Item("DVTIFF_GSREF") & "  " & dt.Rows.Item(i).Item("DVTIFF_KDNRH"))
                    WHGIFF_MDANT = dt.Rows.Item(i).Item("WHGIFF_MDANT") & "|"
                    WHGIFF_WHISO = dt.Rows.Item(i).Item("WHGIFF_WHISO") & "|"
                    WHGIFF_WNAME = dt.Rows.Item(i).Item("WHGIFF_WNAME") & "|"
                    WHGIFF_WSLZB = dt.Rows.Item(i).Item("WHGIFF_WSLZB") & "|"
                    WHGIFF_WEINH = dt.Rows.Item(i).Item("WHGIFF_WEINH") & "|"
                    WHGIFF_WKLEH = dt.Rows.Item(i).Item("WHGIFF_WKLEH") & "|"
                    WHGIFF_WNKST = dt.Rows.Item(i).Item("WHGIFF_WNKST") & "|"
                    WHGIFF_WSTAT = dt.Rows.Item(i).Item("WHGIFF_WSTAT") & "|"
                    WHGIFF_MKURS = KursString.ToString.Replace(",", ".") & "|"
                    WHGIFF_DXEGK = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("WHGIFF_DXEGK")) & "|"
                    WHGIFF_IFNAM = dt.Rows.Item(i).Item("WHGIFF_IFNAM") & "|"
                    WHGIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("WHGIFF_DXIFD"))

                    CSV_ROW = WHGIFF_MDANT & WHGIFF_WHISO & WHGIFF_WNAME & WHGIFF_WSLZB & WHGIFF_WEINH & WHGIFF_WKLEH & WHGIFF_WNKST & WHGIFF_WSTAT & WHGIFF_MKURS & WHGIFF_DXEGK & WHGIFF_IFNAM & WHGIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.WHGIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.WHGIFF_Result = "Not Created"
            Dim CSV_HEADER As String = "WHGIFF_MDANT|WHGIFF_WHISO|WHGIFF_WNAME|WHGIFF_WSLZB|WHGIFF_WEINH|WHGIFF_WKLEH|WHGIFF_WNKST|WHGIFF_WSTAT|WHGIFF_MKURS|WHGIFF_DXEGK|WHGIFF_IFNAM|WHGIFF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "WHGIFF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "WHGIFF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File WHGIFF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:EXCHANGE RATES OCBS for this Date" & vbNewLine & " Please update EXCHANGE RATES OCBS Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub GSVGAF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        
            Try
                

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_DESIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSVGAF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSVGAF_CCB.csv .... Please wait...")
                'New Code
            Dim CSV_HEADER As String = "GSVGAF_MDANT|GSVGAF_MODUL|GSVGAF_KDREA|GSVGAF_KTONR|GSVGAF_GSREF|GSVGAF_VGLFN|GSVGAF_VGMOD|GSVGAF_VGKDA|GSVGAF_VGKTO|GSVGAF_VGREF|GSVGAF_SLDAV|GSVGAF_AKTYP|GSVGAF_RSCD1|GSVGAF_RSCD2|GSVGAF_RSTX1|GSVGAF_RSTX2|GSVGAF_RSDX1|GSVGAF_RSPR1|GSVGAF_RSBT1|GSVGAF_IFNAM|GSVGAF_DXIFD"
            Dim CSV_ROW As String = Nothing
            Dim GSVGAF_MDANT As String = Nothing
            Dim GSVGAF_MODUL As String = Nothing
            Dim GSVGAF_KDREA As String = Nothing
            Dim GSVGAF_KTONR As String = Nothing
            Dim GSVGAF_GSREF As String = Nothing
            Dim GSVGAF_VGLFN As String = Nothing
            Dim GSVGAF_VGMOD As String = Nothing
            Dim GSVGAF_VGKDA As String = Nothing
            Dim GSVGAF_VGKTO As String = Nothing
            Dim GSVGAF_VGREF As String = Nothing
            Dim GSVGAF_SLDAV As String = Nothing
            Dim GSVGAF_AKTYP As String = Nothing
            Dim GSVGAF_RSCD1 As String = Nothing
            Dim GSVGAF_RSCD2 As String = Nothing
            Dim GSVGAF_RSTX1 As String = Nothing
            Dim GSVGAF_RSTX2 As String = Nothing
            Dim GSVGAF_RSDX1 As String = Nothing
            Dim GSVGAF_RSPR1 As String = Nothing
            Dim GSVGAF_RSBT1 As String = Nothing
            Dim GSVGAF_IFNAM As String = Nothing
            Dim GSVGAF_DXIFD As String = Nothing
               

            If File.Exists(BaisFilesCreationPath & "GSVGAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSVGAF_CCB.csv")
            End If

            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSVGAF_CCB.csv", CSV_HEADER & vbCrLf)
                
            Me.QueryText = "SELECT  * FROM  [BAIS_GSVGAF] where [GSVGAF_DXIFD]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                '+++++++++++++
                For i = 0 To dt.Rows.Count - 1
                    GSVGAF_MDANT = dt.Rows.Item(i).Item("GSVGAF_MDANT") & "|"
                    GSVGAF_MODUL = dt.Rows.Item(i).Item("GSVGAF_MODUL") & "|"
                    GSVGAF_KDREA = dt.Rows.Item(i).Item("GSVGAF_KDREA") & "|"
                    GSVGAF_KTONR = dt.Rows.Item(i).Item("GSVGAF_KTONR") & "|"
                    GSVGAF_GSREF = dt.Rows.Item(i).Item("GSVGAF_GSREF") & "|"
                    GSVGAF_VGLFN = dt.Rows.Item(i).Item("GSVGAF_VGLFN") & "|"
                    GSVGAF_VGMOD = dt.Rows.Item(i).Item("GSVGAF_VGMOD") & "|"
                    GSVGAF_VGKDA = dt.Rows.Item(i).Item("GSVGAF_VGKDA") & "|"
                    GSVGAF_VGKTO = dt.Rows.Item(i).Item("GSVGAF_VGKTO") & "|"
                    GSVGAF_VGREF = dt.Rows.Item(i).Item("GSVGAF_VGREF") & "|"
                    GSVGAF_SLDAV = dt.Rows.Item(i).Item("GSVGAF_SLDAV").ToString.Replace(",", ".") & "|"
                    GSVGAF_AKTYP = dt.Rows.Item(i).Item("GSVGAF_AKTYP") & "|"
                    GSVGAF_RSCD1 = dt.Rows.Item(i).Item("GSVGAF_RSCD1") & "|"
                    GSVGAF_RSCD2 = dt.Rows.Item(i).Item("GSVGAF_RSCD2") & "|"
                    GSVGAF_RSTX1 = dt.Rows.Item(i).Item("GSVGAF_RSTX1") & "|"
                    GSVGAF_RSTX2 = dt.Rows.Item(i).Item("GSVGAF_RSTX2") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("GSVGAF_RSDX1")) = False Then
                        Dim RSXD1_Date As Date = dt.Rows.Item(i).Item("GSVGAF_RSDX1")
                        GSVGAF_RSDX1 = RSXD1_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSVGAF_RSDX1 = "0" & "|"
                    End If
                    GSVGAF_RSBT1 = dt.Rows.Item(i).Item("GSVGAF_RSBT1") & "|"
                    GSVGAF_RSPR1 = dt.Rows.Item(i).Item("GSVGAF_RSPR1") & "|"
                    GSVGAF_IFNAM = dt.Rows.Item(i).Item("GSVGAF_IFNAM") & "|"
                    GSVGAF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSVGAF_DXIFD"))

                    CSV_ROW = GSVGAF_MDANT & GSVGAF_MODUL & GSVGAF_KDREA & GSVGAF_KTONR & GSVGAF_GSREF & GSVGAF_VGLFN & GSVGAF_VGMOD & GSVGAF_VGKDA & GSVGAF_VGKTO & GSVGAF_VGREF & GSVGAF_SLDAV & GSVGAF_AKTYP & GSVGAF_RSCD1 & GSVGAF_RSCD2 & GSVGAF_RSTX1 & GSVGAF_RSTX2 & GSVGAF_RSDX1 & GSVGAF_RSPR1 & GSVGAF_RSBT1 & GSVGAF_IFNAM & GSVGAF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSVGAF_CCB.csv", CSV_ROW & vbCrLf)
                Next


                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GSVGAF_Result = "Created"
            Else
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.GSVGAF_Result = "Not Created"
                
                XtraMessageBox.Show("Unable to create File GSVGAF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:GSVGAF for this Date" & vbNewLine & " Please check", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Catch ex As System.Exception

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
       
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub 'OK

    Private Sub GSWBIF_CREATION()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select Count([ID]) from [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count > 0 Then
            Try
                ''SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                ''SplashScreenManager.Default.SetWaitFormCaption("Start creating BAIS File:DVTIFF_CCB.csv")
                'BgwBaisFilesCreation.ReportProgress(2, "Delete Current Date in BAIS_WHGIFF Table with WHGIFF_DXIFD: " & rd)
                'cmd.CommandText = "DELETE FROM [BAIS_WHGIFF] where [WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Insert new data to table:BAIS_WHGIFF")
                'cmd.CommandText = "INSERT INTO [BAIS_WHGIFF] ([WHGIFF_WHISO],[WHGIFF_WNAME],[WHGIFF_WSLZB],[WHGIFF_DXEGK],[WHGIFF_DXIFD]) Select [CURRENCY CODE],[CURRENCY NAME],[LZB_CurrencyCode],'" & rdsql & "','" & rdsql & "' from [OWN_CURRENCIES] where [VALID] in ('Y')"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF with relevant Data from EXCHANGE RATES OCBS")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_MKURS]=B.[MIDDLE RATE] from [BAIS_WHGIFF] A INNER JOIN [EXCHANGE RATES OCBS] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] and A.[WHGIFF_DXIFD]=B.[EXCHANGE RATE DATE] where B.[EXCHANGE RATE DATE]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF regarding WHGIFF_WKLEH, WHGIFF_WNKST and WHGIFF_WSTAT")
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF Set WHGIFF_WKLEH=1 and WHGIFF_WNKST=0 where CURRENCY CODE does not accept decimals in OWN CURRENCIES")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_WKLEH]='1', A.WHGIFF_WNKST=0 from [BAIS_WHGIFF] A INNER JOIN [OWN_CURRENCIES] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] where B.[ACCEPTS DECIMALS] in ('N') and A.[WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()
                'BgwBaisFilesCreation.ReportProgress(2, "Update BAIS_WHGIFF Set WHGIFF_WSTAT=I where CURRENCY CODE is NATIONAL CURRENCY in OWN CURRENCIES")
                'cmd.CommandText = "UPDATE A SET A.[WHGIFF_WSTAT]='I' from [BAIS_WHGIFF] A INNER JOIN [OWN_CURRENCIES] B on A.[WHGIFF_WHISO]=B.[CURRENCY CODE] where B.[OWN CURRENCY] in ('Y') and A.[WHGIFF_DXIFD]='" & rdsql & "'"
                'cmd.ExecuteNonQuery()


                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSWAIF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSWBIF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.25'))"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.25/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSWAIF_CCB.csv .... Please wait...")
                'New Code
                Dim CSV_HEADER As String = "GSWAIF_MDANT|GSWAIF_MODUL|GSWAIF_KDNRH|GSWAIF_KTONR|GSWAIF_GSREF|GSWAIF_PWBBT|GSWAIF_PWBWH|GSWAIF_EWBBT|GSWAIF_EWBWH|GSWAIF_EWBBP|GSWAIF_EWBWP|GSWAIF_ABSBT|GSWAIF_ABSWH|GSWAIF_ABTYP|GSWAIF_EWBBS|GSWAIF_EWBWS|GSWAIF_PWBBS|GSWAIF_PWBWS|GSWAIF_EWBLR|GSWAIF_EWBWL|GSWAIF_STIRE|GSWAIF_STIWH|GSWAIF_RSTBT|GSWAIF_RSTWH|GSWAIF_IFNAM|GSWAIF_DXIFD"
                Dim CSV_ROW As String = Nothing
                Dim GSWBIF_MDANT As String = Nothing
                Dim GSWBIF_MODUL As String = Nothing
                Dim GSWBIF_KDNRH As String = Nothing
                Dim GSWBIF_KTONR As String = Nothing
                Dim GSWBIF_GSREF As String = Nothing
                Dim GSWBIF_PWBBT As String = Nothing
                Dim GSWBIF_PWBWH As String = Nothing
                Dim GSWBIF_EWBBT As String = Nothing
                Dim GSWBIF_EWBWH As String = Nothing
                Dim GSWBIF_EWBBP As String = Nothing
                Dim GSWBIF_EWBWP As String = Nothing
                Dim GSWBIF_ABSBT As String = Nothing
                Dim GSWBIF_ABSWH As String = Nothing
                Dim GSWBIF_ABTYP As String = Nothing
                Dim GSWBIF_EWBBS As String = Nothing
                Dim GSWBIF_EWBWS As String = Nothing
                Dim GSWBIF_PWBBS As String = Nothing
                Dim GSWBIF_PWBWS As String = Nothing
                Dim GSWBIF_EWBLR As String = Nothing
                Dim GSWBIF_EWBWL As String = Nothing
                Dim GSWBIF_STIRE As String = Nothing
                Dim GSWBIF_STIWH As String = Nothing
                Dim GSWBIF_RSTBT As String = Nothing
                Dim GSWBIF_RSTWH As String = Nothing
                Dim GSWBIF_IFNAM As String = Nothing
                Dim GSWBIF_DXIFD As String = Nothing

                If File.Exists(BaisFilesCreationPath & "GSWAIF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSWAIF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                Me.QueryText = "SELECT  * FROM  [BAIS_GSWBIF] where [GSWBIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1

                        GSWBIF_MDANT = dt.Rows.Item(i).Item("GSWBIF_MDANT") & "|"
                        GSWBIF_MODUL = dt.Rows.Item(i).Item("GSWBIF_MODUL") & "|"
                        GSWBIF_KDNRH = dt.Rows.Item(i).Item("GSWBIF_KDNRH") & "|"
                        GSWBIF_KTONR = dt.Rows.Item(i).Item("GSWBIF_KTONR") & "|"
                        GSWBIF_GSREF = dt.Rows.Item(i).Item("GSWBIF_GSREF") & "|"
                        GSWBIF_PWBBT = dt.Rows.Item(i).Item("GSWBIF_PWBBT").ToString.Replace(",", ".") & "|"
                        GSWBIF_PWBWH = dt.Rows.Item(i).Item("GSWBIF_PWBWH") & "|"
                        GSWBIF_EWBBT = dt.Rows.Item(i).Item("GSWBIF_EWBBT").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWH = dt.Rows.Item(i).Item("GSWBIF_EWBWH") & "|"
                        GSWBIF_EWBBP = dt.Rows.Item(i).Item("GSWBIF_EWBBP").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWP = dt.Rows.Item(i).Item("GSWBIF_EWBWP") & "|"
                        GSWBIF_ABSBT = dt.Rows.Item(i).Item("GSWBIF_ABSBT").ToString.Replace(",", ".") & "|"
                        GSWBIF_ABSWH = dt.Rows.Item(i).Item("GSWBIF_ABSWH") & "|"
                        GSWBIF_ABTYP = dt.Rows.Item(i).Item("GSWBIF_ABTYP") & "|"
                        GSWBIF_EWBBS = dt.Rows.Item(i).Item("GSWBIF_EWBBS").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWS = dt.Rows.Item(i).Item("GSWBIF_EWBWS") & "|"
                        GSWBIF_PWBBS = dt.Rows.Item(i).Item("GSWBIF_PWBBS").ToString.Replace(",", ".") & "|"
                        GSWBIF_PWBWS = dt.Rows.Item(i).Item("GSWBIF_PWBWS") & "|"
                        GSWBIF_EWBLR = dt.Rows.Item(i).Item("GSWBIF_EWBLR").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWL = dt.Rows.Item(i).Item("GSWBIF_EWBWL") & "|"
                        GSWBIF_STIRE = dt.Rows.Item(i).Item("GSWBIF_STIRE").ToString.Replace(",", ".") & "|"
                        GSWBIF_STIWH = dt.Rows.Item(i).Item("GSWBIF_STIWH") & "|"
                        GSWBIF_RSTBT = dt.Rows.Item(i).Item("GSWBIF_RSTBT").ToString.Replace(",", ".") & "|"
                        GSWBIF_RSTWH = dt.Rows.Item(i).Item("GSWBIF_RSTWH") & "|"
                        GSWBIF_IFNAM = dt.Rows.Item(i).Item("GSWBIF_IFNAM") & "|"
                        GSWBIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSWBIF_DXIFD"))

                        CSV_ROW = GSWBIF_MDANT & GSWBIF_MODUL & GSWBIF_KDNRH & GSWBIF_KTONR & GSWBIF_GSREF & GSWBIF_PWBBT & GSWBIF_PWBWH & GSWBIF_EWBBT & GSWBIF_EWBWH & GSWBIF_EWBBP & GSWBIF_EWBWP & GSWBIF_ABSBT & GSWBIF_ABSWH & GSWBIF_ABTYP & GSWBIF_EWBBS & GSWBIF_EWBWS & GSWBIF_PWBBS & GSWBIF_PWBWS & GSWBIF_EWBLR & GSWBIF_EWBWL & GSWBIF_STIRE & GSWBIF_STIWH & GSWBIF_RSTBT & GSWBIF_RSTWH & GSWBIF_IFNAM & GSWBIF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_ROW & vbCrLf)
                    Next



                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    'SplashScreenManager.CloseForm(False)
                    'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.GSWBIF_Result = "Created"
                Else
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Me.GSWBIF_Result = "Not Created"
                    XtraMessageBox.Show("Unable to create File GSWAIF_CCB.csv for " & rd & vbNewLine & "There are no relevant Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Me.GSWBIF_Result = "Not Created"
            Dim CSV_HEADER As String = "GSWAIF_MDANT|GSWAIF_MODUL|GSWAIF_KDNRH|GSWAIF_KTONR|GSWAIF_GSREF|GSWAIF_PWBBT|GSWAIF_PWBWH|GSWAIF_EWBBT|GSWAIF_EWBWH|GSWAIF_EWBBP|GSWAIF_EWBWP|GSWAIF_ABSBT|GSWAIF_ABSWH|GSWAIF_ABTYP|GSWAIF_EWBBS|GSWAIF_EWBWS|GSWAIF_PWBBS|GSWAIF_PWBWS|GSWAIF_EWBLR|GSWAIF_EWBWL|GSWAIF_STIRE|GSWAIF_STIWH|GSWAIF_RSTBT|GSWAIF_RSTWH|GSWAIF_IFNAM|GSWAIF_DXIFD"
            Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSWAIF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSWAIF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSWAIF_CCB.csv for " & rd & vbNewLine & "There are no relevant Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub 'OK

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
            XtraMessageBox.Show("Unable to open creation Folder!", "CREATION FOLDER DOES NOT EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

End Class