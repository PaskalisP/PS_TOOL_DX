﻿Imports System
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
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

'*****************************************
'Class Name: BaisExportAlphaV134
'Version: V1.0.0.0
'Version Explanation:
'Author: CCBFF
'Email: info@ccbff.de
'Creation Time:
'Content:
'Function:
'Description:
'Modify log:  
'    1. Add by Papas; Time:24.05.2023; Content: BAIS system version is updated to Version 1.37. Add the BaisExportAlphaV136 class for Bais Version 1.37

'******************************************
Public Class BaisExportAlphaV137

    'Private QueryText As String = ""
    'Private conndt As New SqlConnection
    'Private da As New SqlDataAdapter
    'Private dt As New DataTable
    'Private da1 As New SqlDataAdapter
    'Private dt1 As New DataTable

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
    Dim SCNTIF_Result As String = Nothing
    Dim SCDRIF_Result As String = Nothing

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

    Private Sub BaisExportAlphaV137_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwBaisFilesCreation.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub BaisExportAlphaV137_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.BusinessDate_SearchLookUpEdit.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString
        'Bind Combobox
        'Me.BusinessDate_Comboedit.Properties.Items.Clear()
        'QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' and [PL Result] is not NULL ORDER BY [ID] desc"
        'da = New SqlDataAdapter(QueryText.Trim(), conn)
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

        RichEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas"
        RichEditControl1.Document.DefaultCharacterProperties.FontSize = 9

    End Sub

    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'Business Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20171209' 
                                                    and [PL Result] is not NULL ORDER BY [ID] desc", conn)
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
        Me.SCNTIF_Result_lbl.Text = ""
        Me.SCDRIF_Result_lbl.Text = ""
        Me.StartFileCreation_btn.Enabled = False
        Me.CheckAll_btn.Enabled = False
        Me.OpenFolder_btn.Enabled = False
        Me.BusinessDate_SearchLookUpEdit.Enabled = False
        Me.GroupControl1.Enabled = False
        Me.RichEditControl1.Document.Delete(Me.RichEditControl1.Document.Range)
        Me.RichEditControl1.Enabled = False
    End Sub

    Private Sub ENABLE_FINISH_CREATION()

        StartFileCreation_btn.Enabled = True
        Me.CheckAll_btn.Enabled = True
        Me.OpenFolder_btn.Enabled = True
        Me.BusinessDate_SearchLookUpEdit.Enabled = True
        Me.GroupControl1.Enabled = True
        Me.RichEditControl1.Enabled = True
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
        Me.SCNTIF_Result_lbl.Text = SCNTIF_Result
        Me.SCDRIF_Result_lbl.Text = SCDRIF_Result
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
        If Me.SCNTIF_Result_lbl.Text = "Not Created" Then
            Me.SCNTIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.SCNTIF_Result_lbl.ForeColor = Color.Lime
        End If
        If Me.SCDRIF_Result_lbl.Text = "Not Created" Then
            Me.SCDRIF_Result_lbl.ForeColor = Color.Red
        Else
            Me.SCDRIF_Result_lbl.ForeColor = Color.Lime
        End If

        'NEW
        If DVTIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.DVTIFF_Result_lbl.Text = ""
        End If
        If GSTIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            GSTIFF_Result_lbl.Text = ""
        End If
        If GSTSLF_CheckEdit.CheckState = CheckState.Unchecked Then
            GSTSLF_Result_lbl.Text = ""
        End If
        If BILIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            BILIFF_Result_lbl.Text = ""
        End If
        If KGCIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            KGCIFF_Result_lbl.Text = ""
        End If
        If KNEIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            KNEIFF_Result_lbl.Text = ""
        End If
        If KNVIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            KNVIFF_Result_lbl.Text = ""
        End If
        If KRKIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            KRKIFF_Result_lbl.Text = ""
        End If
        If KSRIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            KSRIFF_Result_lbl.Text = ""
        End If
        If LQGIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            LQGIFF_Result_lbl.Text = ""
        End If
        If MKUIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            MKUIFF_Result_lbl.Text = ""
        End If
        If ZUSIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            ZUSIFF_Result_lbl.Text = ""
        End If
        If GAKIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            GAKIFF_Result_lbl.Text = ""
        End If
        If GAGIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            GAGIFF_Result_lbl.Text = ""
        End If
        If LQKIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            LQKIFF_Result_lbl.Text = ""
        End If
        If DESIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            DESIFF_Result_lbl.Text = ""
        End If
        If WHGIFF_CheckEdit.CheckState = CheckState.Unchecked Then
            WHGIFF_Result_lbl.Text = ""
        End If
        If GSVGAF_CheckEdit.CheckState = CheckState.Unchecked Then
            GSVGAF_Result_lbl.Text = ""
        End If
        If GSWBIF_CheckEdit.CheckState = CheckState.Unchecked Then
            GSWBIF_Result_lbl.Text = ""
        End If
        If SCNTIF_CheckEdit.CheckState = CheckState.Unchecked Then
            SCNTIF_Result_lbl.Text = ""
        End If
        If SCDRIF_CheckEdit.CheckState = CheckState.Unchecked Then
            SCDRIF_Result_lbl.Text = ""
        End If
    End Sub
#End Region

    Private Sub StartFileCreation_btn_Click(sender As Object, e As EventArgs) Handles StartFileCreation_btn.Click
        StartFileCreation_btn_clicked = True

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
        Me.GSVGAF_Result_lbl.Text = ""
        Me.GSWBIF_Result_lbl.Text = ""
        Me.SCNTIF_Result_lbl.Text = ""
        Me.SCDRIF_Result_lbl.Text = ""

        If IsDate(Me.BusinessDate_SearchLookUpEdit.Text) = True Then
            If DVTIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                GSTIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                GSTSLF_CheckEdit.CheckState = CheckState.Checked OrElse
                KGCIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                KNEIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                KNVIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                KRKIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                KSRIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                LQGIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                MKUIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                ZUSIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                GAKIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                GAGIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                LQKIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                DESIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                WHGIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                GSVGAF_CheckEdit.CheckState = CheckState.Checked OrElse
                GSWBIF_CheckEdit.CheckState = CheckState.Checked OrElse
                BILIFF_CheckEdit.CheckState = CheckState.Checked OrElse
                SCNTIF_CheckEdit.CheckState = CheckState.Checked OrElse
                SCDRIF_CheckEdit.CheckState = CheckState.Checked Then
                If XtraMessageBox.Show("Should the BAIS Interface ALPHA Files creation be started?", "START BAIS INTERFACE ALPHA FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_CREATION()
                    rd = Me.BusinessDate_SearchLookUpEdit.Text
                    rdsql = rd.ToString("yyyyMMdd")
                    'Check if latest BAIS Files Nr is equal with ODAS and OCBS
                    QueryText = "Select 'Result'=Case when (Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('ODAS'))=(Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('OCBS')) and (Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('OCBS'))=(Select [FileName] from [FILES_IMPORT] where SYSTEM_NAME in ('BAIS')) then 'OK' else 'NO' END"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Item(0).Item("Result").ToString = "OK" Then
                        If Me.BgwBaisFilesCreation.IsBusy = False Then
                            Me.BgwBaisFilesCreation.RunWorkerAsync()
                        End If
                    ElseIf dt.Rows.Item(0).Item("Result").ToString = "NO" Then
                        XtraMessageBox.Show("The Last BAIS Interface File is not equal with ODAS and/or NGS File" & vbNewLine & "The BAIS Interface Files creation is canceled!", "Please check the latest Import data files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
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
            rd = Me.BusinessDate_SearchLookUpEdit.Text
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
            If SCNTIF_CheckEdit.CheckState = CheckState.Checked Then
                SCNTIF_CREATION()
            End If
            If SCDRIF_CheckEdit.CheckState = CheckState.Checked Then
                SCDRIF_CREATION()
            End If
        Catch ex As Exception
            Me.BgwBaisFilesCreation.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub BgwBaisFilesCreation_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBaisFilesCreation.ProgressChanged
        If Me.RichEditControl1.Text = Nothing Then
            Me.RichEditControl1.Text = e.UserState
        Else
            Me.RichEditControl1.Text = RichEditControl1.Text & vbNewLine & e.UserState
        End If

        RichEditControl1.Document.CaretPosition = RichEditControl1.Document.Range.[End]
        RichEditControl1.ScrollToCaret()

        ApplyCustomFormatting(Me.RichEditControl1.Document)

    End Sub

    Private Sub ApplyCustomFormatting(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
        For Each paragraph As Paragraph In document.Paragraphs
            Dim parRange As DocumentRange = paragraph.Range

            If document.GetText(parRange).TrimStart().Contains("created successfully") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.DarkGreen
                document.EndUpdateCharacters(cp)
            ElseIf document.GetText(parRange).TrimStart().Contains("NOT CREATED") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.DarkRed
                document.EndUpdateCharacters(cp)
            ElseIf document.GetText(parRange).TrimStart().StartsWith("ERROR") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.Red
                document.EndUpdateCharacters(cp)
            ElseIf document.GetText(parRange).TrimStart().StartsWith("File(s) zipped in BAIS_Files") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.Navy
                document.EndUpdateCharacters(cp)

            End If
        Next
    End Sub

    Private Sub BgwBaisFilesCreation_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBaisFilesCreation.RunWorkerCompleted
        ENABLE_FINISH_CREATION()
        'ALPHA
        If Me.DVTIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "DVTIAF File created successfully - " & BaisFilesCreationPath & "DVTIAF_CCB.csv"
        ElseIf Me.DVTIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++DVTIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GSTIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GSTIAF File created successfully - " & BaisFilesCreationPath & "GSTIAF_CCB.csv"
        ElseIf Me.GSTIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GSTIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GSTSLF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GSTSAF File created successfully - " & BaisFilesCreationPath & "GSTSAF_CCB.csv"
        ElseIf Me.GSTSLF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GSTSAF File NOT CREATED+++"
        End If
        If Me.BILIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "BILIFF File created successfully - " & BaisFilesCreationPath & "BILIFF_CCB.csv"
        ElseIf Me.BILIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++BILIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KGCIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "KGCIAF File created successfully - " & BaisFilesCreationPath & "KGCIAF_CCB.csv"
        ElseIf Me.KGCIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++KGCIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KNEIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "KNEIAF File created successfully - " & BaisFilesCreationPath & "KNEIAF_CCB.csv"
        ElseIf Me.KNEIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++KNEIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KNVIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "KNVIAF File created successfully - " & BaisFilesCreationPath & "KNVIAF_CCB.csv"
        ElseIf Me.KNVIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++KNVIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.KRKIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "KRKIAF File created successfully - " & BaisFilesCreationPath & "KRKIAF_CCB.csv"
        ElseIf Me.KRKIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++KRKIAF File NOT CREATED+++"
        End If
        If Me.KSRIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "KSRIFF File created successfully - " & BaisFilesCreationPath & "KSRIFF_CCB.csv"
        ElseIf Me.KSRIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++KSRIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.LQGIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "LQGIAF File created successfully - " & BaisFilesCreationPath & "LQGIAF_CCB.csv"
        ElseIf Me.LQGIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++LQGIAF File NOT CREATED+++"
        End If
        If Me.MKUIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "MKUIFF File created successfully - " & BaisFilesCreationPath & "MKUIFF_CCB.csv"
        ElseIf Me.MKUIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++MKUIFF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.ZUSIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "ZUSIAF File created successfully - " & BaisFilesCreationPath & "ZUSIAF_CCB.csv"
        ElseIf Me.ZUSIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++ZUSIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GAKIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GAKIAF File created successfully - " & BaisFilesCreationPath & "GAKIAF_CCB.csv"
        ElseIf Me.GAKIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GAKIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.GAGIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GAGIAF File created successfully - " & BaisFilesCreationPath & "GAGIAF_CCB.csv"
        ElseIf Me.GAGIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GAGIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.LQKIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "LQKIAF File created successfully - " & BaisFilesCreationPath & "LQKIAF_CCB.csv"
        ElseIf Me.LQKIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++LQKIAF File NOT CREATED+++"
        End If
        'ALPHA
        If Me.DESIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "DESIAF File created successfully - " & BaisFilesCreationPath & "DESIAF_CCB.csv"
        ElseIf Me.DESIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++DESIAF File NOT CREATED+++"
        End If
        If Me.WHGIFF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "WHGIFF File created successfully - " & BaisFilesCreationPath & "WHGIFF_CCB.csv"
        ElseIf Me.WHGIFF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++WHGIFF File NOT CREATED+++"
        End If
        If Me.GSVGAF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GSVGAF File created successfully - " & BaisFilesCreationPath & "GSVGAF_CCB.csv"
        ElseIf Me.GSVGAF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GSVGAF File NOT CREATED+++"
        End If
        If Me.GSWBIF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "GSWAIF File created successfully - " & BaisFilesCreationPath & "GSWAIF_CCB.csv"
        ElseIf Me.GSWBIF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++GSWAIF File NOT CREATED+++"
        End If
        If Me.SCNTIF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "SCNTIF File created successfully - " & BaisFilesCreationPath & "SCNTIF_CCB.csv"
        ElseIf Me.SCNTIF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++SCNTIF File NOT CREATED+++"
        End If
        If Me.SCDRIF_Result_lbl.Text = "Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "SCDRIF File created successfully - " & BaisFilesCreationPath & "SCDRIF_CCB.csv"
        ElseIf Me.SCDRIF_Result_lbl.Text = "Not Created" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "+++SCDRIF File NOT CREATED+++"
        End If

        'ChangeTextcolor("File created with success", Color.DarkGreen, Me.RicheditControl1, 0)

        Try
            Using zip As ZipFile = New ZipFile
                For Each File In Directory.GetFiles(BaisFilesCreationPath, "*.CSV", SearchOption.TopDirectoryOnly)
                    zip.AddFile(File, "")
                Next
                zip.Save(BaisFilesCreationPath & "BAIS_Files_ALPHA_v1.37_from_PSTOOL_" & rdsql & ".rar")
                Dim BaisFilesList As String() = Directory.GetFiles(BaisFilesCreationPath, "*.CSV")
                For Each f In BaisFilesList
                    File.Delete(f)
                Next
            End Using
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & vbNewLine & "File(s) zipped in " & "BAIS_Files_ALPHA_v1.37_from_PSTOOL_" & rdsql & ".rar"
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Unable to zip the created BAIS Files", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try


        TextImportFileRow = Now & "  " & "PS TOOL BAIS EXPORT" & "  " & Me.RichEditControl1.Text & "  " & "PS TOOL BAIS EXPORT"
        System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)


        ApplyCustomFormatting(Me.RichEditControl1.Document)

        RichEditControl1.Document.CaretPosition = RichEditControl1.Document.Range.[End]
        RichEditControl1.ScrollToCaret()

    End Sub

    Private Sub DVTIFF_CREATION()
        OpenSqlConnections()
        Dim CountFxDeals As Double = 0
        Dim Count As Double = 0
        'Check if FX Deals present
        cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
        CountFxDeals = cmd.ExecuteScalar
        'New Code
        Dim CSV_HEADER As String =
                        "DVTIAF_MDANT" &
                        "|DVTIAF_GSREF" &
                        "|DVTIAF_FILNR" &
                        "|DVTIAF_KDNRH" &
                        "|DVTIAF_DXABD" &
                        "|DVTIAF_GSKLA" &
                        "|DVTIAF_SUKLA" &
                        "|DVTIAF_DVART" &
                        "|DVTIAF_DXVAL" &
                        "|DVTIAF_DANWC" &
                        "|DVTIAF_DANBT" &
                        "|DVTIAF_DVKWC" &
                        "|DVTIAF_DVKBT" &
                        "|DVTIAF_HBKZN" &
                        "|DVTIAF_ZWRIS" &
                        "|DVTIAF_KBTRG" &
                        "|DVTIAF_PTEIN" &
                        "|DVTIAF_WHGKP" &
                        "|DVTIAF_BCHSW" &
                        "|DVTIAF_BWVNS" &
                        "|DVTIAF_WHGBU" &
                        "|DVTIAF_URDEA" &
                        "|DVTIAF_NETKR" &
                        "|DVTIAF_KZCVA" &
                        "|DVTIAF_GSARE" &
                        "|DVTIAF_FAIRV" &
                        "|DVTIAF_WHGFV" &
                        "|DVTIAF_DXVKT" &
                        "|DVTIAF_HFZGP" &
                        "|DVTIAF_KZZGP" &
                        "|DVTIAF_KZSEG" &
                        "|DVTIAF_AFREF" &
                        "|DVTIAF_POOLI" &
                        "|DVTIAF_AEIDF" &
                        "|DVTIAF_BESVB" &
                        "|DVTIAF_DRKNZ" &
                        "|DVTIAF_MARAG" &
                        "|DVTIAF_DXNVB" &
                        "|DVTIAF_RESE1" &
                        "|DVTIAF_RESE2" &
                        "|DVTIAF_FREI1" &
                        "|DVTIAF_FREI2" &
                        "|DVTIAF_FREI3" &
                        "|DVTIAF_LOEKZ" &
                        "|DVTIAF_IFNAM" &
                        "|DVTIAF_DXIFD"

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
        Dim DVTIFF_BWVNS As String = Nothing 'New 1.23
        Dim DVTIFF_WHGBU As String = Nothing
        Dim DVTIFF_URDEA As String = Nothing
        Dim DVTIFF_NETKR As String = Nothing
        Dim DVTIFF_KZCVA As String = Nothing
        Dim DVTIFF_GSARE As String = Nothing
        Dim DVTIFF_FAIRV As String = Nothing
        Dim DVTIFF_WHGFV As String = Nothing 'New Version 1.27
        Dim DVTIFF_DXVKT As String = Nothing
        Dim DVTIFF_HFZGP As String = Nothing
        Dim DVTIFF_KZZGP As String = Nothing 'New 1.31
        Dim DVTIFF_KZSEG As String = Nothing 'New 1.31
        Dim DVTIFF_AFREF As String = Nothing
        Dim DVTIFF_POOLI As String = Nothing 'New
        Dim DVTIFF_AEIDF As String = Nothing 'New
        Dim DVTIFF_BESVB As String = Nothing 'New
        Dim DVTIFF_DRKNZ As String = Nothing 'New 1.30
        Dim DVTIFF_MARAG As String = Nothing 'New 1.30
        Dim DVTIFF_DXNVB As String = Nothing 'New 1.30
        Dim DVTIFF_RESE1 As String = Nothing
        Dim DVTIFF_RESE2 As String = Nothing
        Dim DVTIFF_FREI1 As String = Nothing
        Dim DVTIFF_FREI2 As String = Nothing
        Dim DVTIFF_FREI3 As String = Nothing
        Dim DVTIFF_LOEKZ As String = Nothing
        Dim DVTIFF_IFNAM As String = Nothing
        Dim DVTIFF_DXIFD As String = Nothing

        If CountFxDeals > 0 Then
            'Check if are FX Deals with no Client Nr. indicated
            cmd.CommandText = "Select Count([ID]) from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "' and [ClientNo] is  NULL"
            Count = cmd.ExecuteScalar

            If Count = 0 Then
                Try

                    BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_DVTIFF File for: " & rd)
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_DVTIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText
                            If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End If

                    BgwBaisFilesCreation.ReportProgress(2, "Generating File: DVTIAF_CCB.csv .... Please wait...")



                    If File.Exists(BaisFilesCreationPath & "DVTIAF_CCB.csv") = True Then
                        File.Delete(BaisFilesCreationPath & "DVTIAF_CCB.csv")
                    End If
                    'Create Header
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_HEADER & vbCrLf)
                    '++++++++++++++
                    QueryText = "SELECT  * FROM  [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "'"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                        DVTIFF_BWVNS = dt.Rows.Item(i).Item("DVTIFF_BWVNS") & "|" ' New 1.23
                        DVTIFF_WHGBU = dt.Rows.Item(i).Item("DVTIFF_WHGBU") & "|"
                        DVTIFF_URDEA = dt.Rows.Item(i).Item("DVTIFF_URDEA") & "|"
                        DVTIFF_NETKR = dt.Rows.Item(i).Item("DVTIFF_NETKR") & "|"
                        DVTIFF_KZCVA = dt.Rows.Item(i).Item("DVTIFF_KZCVA") & "|"
                        DVTIFF_GSARE = dt.Rows.Item(i).Item("DVTIFF_GSARE") & "|"
                        DVTIFF_FAIRV = dt.Rows.Item(i).Item("DVTIFF_FAIRV") & "|"
                        DVTIFF_WHGFV = dt.Rows.Item(i).Item("DVTIFF_WHGFV") & "|" 'New Version 1.27
                        DVTIFF_DXVKT = dt.Rows.Item(i).Item("DVTIFF_DXVKT") & "|"
                        DVTIFF_HFZGP = dt.Rows.Item(i).Item("DVTIFF_HFZGP") & "|"
                        DVTIFF_KZZGP = dt.Rows.Item(i).Item("DVTIFF_KZZGP") & "|"
                        DVTIFF_KZSEG = dt.Rows.Item(i).Item("DVTIFF_KZSEG") & "|"
                        DVTIFF_AFREF = dt.Rows.Item(i).Item("DVTIFF_AFREF") & "|"
                        DVTIFF_POOLI = dt.Rows.Item(i).Item("DVTIFF_POOLI") & "|"
                        DVTIFF_AEIDF = dt.Rows.Item(i).Item("DVTIFF_AEIDF") & "|"
                        DVTIFF_BESVB = dt.Rows.Item(i).Item("DVTIFF_BESVB") & "|"
                        DVTIFF_DRKNZ = dt.Rows.Item(i).Item("DVTIFF_DRKNZ") & "|"
                        DVTIFF_MARAG = dt.Rows.Item(i).Item("DVTIFF_MARAG") & "|"
                        If IsDBNull(dt.Rows.Item(i).Item("DVTIFF_DXNVB")) = False Then
                            Dim DXNVB_Date As Date = dt.Rows.Item(i).Item("DVTIFF_DXNVB")
                            DVTIFF_DXNVB = DXNVB_Date.ToString("yyyyMMdd") & "|"
                        Else
                            DVTIFF_DXNVB = "0" & "|"
                        End If
                        DVTIFF_RESE1 = dt.Rows.Item(i).Item("DVTIFF_RESE1") & "|"
                        DVTIFF_RESE2 = dt.Rows.Item(i).Item("DVTIFF_RESE2") & "|"
                        DVTIFF_FREI1 = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_FREI1")) & "|"
                        DVTIFF_FREI2 = dt.Rows.Item(i).Item("DVTIFF_FREI2") & "|"
                        DVTIFF_FREI3 = dt.Rows.Item(i).Item("DVTIFF_FREI3") & "|"
                        DVTIFF_LOEKZ = dt.Rows.Item(i).Item("DVTIFF_LOEKZ") & "|"
                        DVTIFF_IFNAM = "DVTIAF" & "|"
                        DVTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DVTIFF_DXIFD"))

                        CSV_ROW =
                            DVTIFF_MDANT &
                            DVTIFF_GSREF &
                            DVTIFF_FILNR &
                            DVTIFF_KDNRH &
                            DVTIFF_DXABD &
                            DVTIFF_GSKLA &
                            DVTIFF_SUKLA &
                            DVTIFF_DVART &
                            DVTIFF_DXVAL &
                            DVTIFF_DANWC &
                            DVTIFF_DANBT &
                            DVTIFF_DVKWC &
                            DVTIFF_DVKBT &
                            DVTIFF_HBKZN &
                            DVTIFF_ZWRIS &
                            DVTIFF_KBTRG &
                            DVTIFF_PTEIN &
                            DVTIFF_WHGKP &
                            DVTIFF_BCHSW &
                            DVTIFF_BWVNS &
                            DVTIFF_WHGBU &
                            DVTIFF_URDEA &
                            DVTIFF_NETKR &
                            DVTIFF_KZCVA &
                            DVTIFF_GSARE &
                            DVTIFF_FAIRV &
                            DVTIFF_WHGFV &
                            DVTIFF_DXVKT &
                            DVTIFF_HFZGP &
                            DVTIFF_KZZGP &
                            DVTIFF_KZSEG &
                            DVTIFF_AFREF &
                            DVTIFF_POOLI &
                            DVTIFF_AEIDF &
                            DVTIFF_BESVB &
                            DVTIFF_DRKNZ &
                            DVTIFF_MARAG &
                            DVTIFF_DXNVB &
                            DVTIFF_RESE1 &
                            DVTIFF_RESE2 &
                            DVTIFF_FREI1 &
                            DVTIFF_FREI2 &
                            DVTIFF_FREI3 &
                            DVTIFF_LOEKZ &
                            DVTIFF_IFNAM &
                            DVTIFF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_ROW & vbCrLf)
                    Next

                    'cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                    'cmd.ExecuteNonQuery()

                    CloseSqlConnections()
                    'SplashScreenManager.CloseForm(False)
                    'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.DVTIFF_Result = "Created"

                Catch ex As System.Exception
                    'SplashScreenManager.CloseForm(False)
                    CloseSqlConnections()
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            Else
                CloseSqlConnections()
                Me.DVTIFF_Result = "Not Created"
                'Dim CSV_ROW As String = Nothing
                If File.Exists(BaisFilesCreationPath & "DVTIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DVTIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DVTIAF_CCB.csv", CSV_HEADER & vbCrLf)
                XtraMessageBox.Show("Unable to create File DVTIAF_CCB.csv for " & rd & vbNewLine & "There are FX Deals with no Client Nr. in the Database for this Date" & vbNewLine & " Please update Client Nr for all FX Deals in order to create the requested csv file!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If
        Else
            CloseSqlConnections()
            Me.DVTIFF_Result = "Not Created"
            XtraMessageBox.Show("Unable to create File DVTIFF_CCB.csv for " & rd & vbNewLine & "There are no FX Deals in the Database for this Date", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        CloseSqlConnections()
    End Sub

    Private Sub GSTIFF_CREATION()
        OpenSqlConnections()
        cmd.CommandText = "Select Count([ID]) from [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        'New Code
        Dim CSV_HEADER As String =
            "GSTIAF_MDANT" &
            "|GSTIAF_FILNR" &
            "|GSTIAF_MODUL" &
            "|GSTIAF_KDREA" &
            "|GSTIAF_KTONR" &
            "|GSTIAF_GSREF" &
            "|GSTIAF_BEZNG" &
            "|GSTIAF_KOART" &
            "|GSTIAF_BILKT" &
            "|GSTIAF_GSKLA" &
            "|GSTIAF_SUKLA" &
            "|GSTIAF_GSART" &
            "|GSTIAF_ULFZT" &
            "|GSTIAF_WHISO" &
            "|GSTIAF_VERKZ" &
            "|GSTIAF_SLDKZ" &
            "|GSTIAF_KZREV" &
            "|GSTIAF_WPKNZ" &
            "|GSTIAF_WPBFN" &
            "|GSTIAF_HBKZN" &
            "|GSTIAF_ZWRIS" &
            "|GSTIAF_KZLST" &
            "|GSTIAF_HAFIN" &
            "|GSTIAF_WESTA" &
            "|GSTIAF_BEREA" &
            "|GSTIAF_DXVND" &
            "|GSTIAF_DXBSD" &
            "|GSTIAF_MRLFZ" &
            "|GSTIAF_AUSFL" &
            "|GSTIAF_DXAUD" &
            "|GSTIAF_RANGF" &
            "|GSTIAF_KZUEV" &
            "|GSTIAF_KFRIS" &
            "|GSTIAF_DXZAP" &
            "|GSTIAF_KZVSG" &
            "|GSTIAF_KZKRU" &
            "|GSTIAF_KONSB" &
            "|GSTIAF_RISGR" &
            "|GSTIAF_KONSK" &
            "|GSTIAF_WPKNR" &
            "|GSTIAF_KENNR" &
            "|GSTIAF_GSARE" &
            "|GSTIAF_PRDKT" &
            "|GSTIAF_WHIFX" &
            "|GSTIAF_HFZGP" &
            "|GSTIAF_KZZGP" &
            "|GSTIAF_KZSEG" &
            "|GSTIAF_AFREF" &
            "|GSTIAF_KZAKL" &
            "|GSTIAF_KONSR" &
            "|GSTIAF_RLVID" &
            "|GSTIAF_NOTBF" &
            "|GSTIAF_POOLI" &
            "|GSTIAF_AEIDF" &
            "|GSTIAF_BAILV" &
            "|GSTIAF_MRELV" &
            "|GSTIAF_ZINSS" &
            "|GSTIAF_INSRK" &
            "|GSTIAF_KRFUN" &
            "|GSTIAF_TRDCO" &
            "|GSTIAF_APKNZ" &
            "|GSTIAF_DXVBE" &
            "|GSTIAF_DXPO1" &
            "|GSTIAF_DXPO2" &
            "|GSTIAF_DXNPE" &
            "|GSTIAF_DXFBE" & '|GSTIAF_PBDFA" (Deleted on version 1.35) &
            "|GSTIAF_DXPBD" &
            "|GSTIAF_CSPID" &
            "|GSTIAF_CSPTY" &
            "|GSTIAF_IPRKZ" &
            "|GSTIAF_ARTSP" &
            "|GSTIAF_WLKKZ" &
            "|GSTIAF_PSINV" &
            "|GSTIAF_SPKRF" &
            "|GSTIAF_KWAER" &
            "|GSTIAF_CKEKZ" &
            "|GSTIAF_AKEKZ" &
            "|GSTIAF_NHTFI" &
            "|GSTIAF_AGTRK" &
            "|GSTIAF_AGPRK" &
            "|GSTIAF_EELEV" &
            "|GSTIAF_EESCO" &
            "|GSTIAF_ONANT" &
            "|GSTIAF_ONART" &
            "|GSTIAF_I9WBS" &
            "|GSTIAF_NUKGK" &
            "|GSTIAF_DXNAV" &
            "|GSTIAF_TAXEL" & 'v.137
            "|GSTIAF_RESE1" &
            "|GSTIAF_RESE2" &
            "|GSTIAF_RESE3" &
            "|GSTIAF_FREI1" &
            "|GSTIAF_FREI2" &
            "|GSTIAF_FREI3" &
            "|GSTIAF_FREI4" &
            "|GSTIAF_FREI5" &
            "|GSTIAF_FREI6" &
            "|GSTIAF_FREI7" &
            "|GSTIAF_LOEKZ" &
            "|GSTIAF_IFNAM" &
            "|GSTIAF_DXIFD"

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
        Dim GSTIFF_BEREA As String = Nothing
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
        Dim GSTIFF_KENNR As String = Nothing
        Dim GSTIFF_GSARE As String = Nothing
        Dim GSTIFF_PRDKT As String = Nothing
        Dim GSTIFF_WHIFX As String = Nothing
        Dim GSTIFF_HFZGP As String = Nothing
        Dim GSTIFF_KZZGP As String = Nothing 'New 1.31
        Dim GSTIFF_KZSEG As String = Nothing 'New 1.31
        Dim GSTIFF_AFREF As String = Nothing
        Dim GSTIFF_KZAKL As String = Nothing
        Dim GSTIFF_KONSR As String = Nothing
        Dim GSTIFF_RLVID As String = Nothing ' New 1.31
        Dim GSTIFF_NOTBF As String = Nothing
        Dim GSTIFF_POOLI As String = Nothing
        Dim GSTIFF_AEIDF As String = Nothing
        Dim GSTIFF_BAILV As String = Nothing
        Dim GSTIFF_MRELV As String = Nothing
        Dim GSTIFF_ZINSS As String = Nothing
        Dim GSTIFF_INSRK As String = Nothing
        Dim GSTIFF_KRFUN As String = Nothing
        Dim GSTIFF_TRDCO As String = Nothing
        Dim GSTIFF_APKNZ As String = Nothing
        Dim GSTIFF_DXVBE As String = Nothing
        Dim GSTIFF_DXPO1 As String = Nothing 'New Version 1.31
        Dim GSTIFF_DXPO2 As String = Nothing 'New Version 1.31
        Dim GSTIFF_DXNPE As String = Nothing 'New Version 1.31
        Dim GSTIFF_DXFBE As String = Nothing 'New Version 1.31
        'Dim GSTIFF_PBDFA As String = Nothing 'New Version 1.31 (DELETED IN VESRION 1.35)
        Dim GSTIFF_DXPBD As String = Nothing 'New Version 1.31
        Dim GSTIFF_CSPID As String = Nothing 'New Version 1.31
        Dim GSTIFF_CSPTY As String = Nothing 'New Version 1.31
        Dim GSTIFF_IPRKZ As String = Nothing 'New Version 1.31
        Dim GSTIFF_ARTSP As String = Nothing 'New Version 1.31
        Dim GSTIFF_WLKKZ As String = Nothing
        Dim GSTIFF_PSINV As String = Nothing
        Dim GSTIFF_SPKRF As String = Nothing
        Dim GSTIFF_KWAER As String = Nothing 'New Version 1.35
        Dim GSTIFF_CKEKZ As String = Nothing 'New Version 1.35
        Dim GSTIFF_AKEKZ As String = Nothing 'New Version 1.35
        Dim GSTIFF_NHTFI As String = Nothing 'New Version 1.35
        Dim GSTIFF_AGTRK As String = Nothing 'New Version 1.35
        Dim GSTIFF_AGPRK As String = Nothing 'New Version 1.35
        Dim GSTIFF_EELEV As String = Nothing 'New Version 1.35
        Dim GSTIFF_EESCO As String = Nothing 'New Version 1.35
        Dim GSTIFF_ONANT As String = Nothing 'New Version 1.35
        Dim GSTIFF_ONART As String = Nothing 'New Version 1.35
        Dim GSTIFF_I9WBS As String = Nothing 'New Version 1.35
        Dim GSTIFF_NUKGK As String = Nothing 'New Version 1.35
        Dim GSTIFF_DXNAV As String = Nothing 'New Version 1.36
        Dim GSTIFF_TAXEL As String = Nothing 'New Version 1.37
        Dim GSTIFF_RESE1 As String = Nothing
        Dim GSTIFF_RESE2 As String = Nothing
        Dim GSTIFF_RESE3 As String = Nothing
        Dim GSTIFF_FREI1 As String = Nothing
        Dim GSTIFF_FREI2 As String = Nothing
        Dim GSTIFF_FREI3 As String = Nothing
        Dim GSTIFF_FREI4 As String = Nothing
        Dim GSTIFF_FREI5 As String = Nothing
        Dim GSTIFF_FREI6 As String = Nothing 'New Version 1.35
        Dim GSTIFF_FREI7 As String = Nothing 'New Version 1.35
        Dim GSTIFF_LOEKZ As String = Nothing
        Dim GSTIFF_IFNAM As String = Nothing
        Dim GSTIFF_DXIFD As String = Nothing

        If Count > 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSTIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSTIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTIFF_CCB.csv...Please wait...")



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

                QueryText = "SELECT * FROM  [BAIS_GSTIFF] where [GSTIFF_DXIFD]='" & rdsql & "' and [GSTIFF_DXVND]<= '" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    GSTIFF_BEREA = dt.Rows.Item(i).Item("GSTIFF_BEREA") & "|" ' In V.1.31
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
                    GSTIFF_KENNR = dt.Rows.Item(i).Item("GSTIFF_KENNR") & "|" 'New Version 1.27
                    GSTIFF_GSARE = dt.Rows.Item(i).Item("GSTIFF_GSARE") & "|"
                    GSTIFF_PRDKT = dt.Rows.Item(i).Item("GSTIFF_PRDKT") & "|"
                    GSTIFF_WHIFX = dt.Rows.Item(i).Item("GSTIFF_WHIFX") & "|"
                    GSTIFF_HFZGP = dt.Rows.Item(i).Item("GSTIFF_HFZGP") & "|"
                    GSTIFF_KZZGP = dt.Rows.Item(i).Item("GSTIFF_KZZGP") & "|"
                    GSTIFF_KZSEG = dt.Rows.Item(i).Item("GSTIFF_KZSEG") & "|"
                    GSTIFF_AFREF = dt.Rows.Item(i).Item("GSTIFF_AFREF") & "|"
                    GSTIFF_KZAKL = dt.Rows.Item(i).Item("GSTIFF_KZAKL") & "|"
                    GSTIFF_KONSR = dt.Rows.Item(i).Item("GSTIFF_KONSR") & "|"
                    GSTIFF_RLVID = dt.Rows.Item(i).Item("GSTIFF_RLVID") & "|" ' New 1.31
                    GSTIFF_NOTBF = dt.Rows.Item(i).Item("GSTIFF_NOTBF") & "|" 'New
                    GSTIFF_POOLI = dt.Rows.Item(i).Item("GSTIFF_POOLI") & "|" 'New
                    GSTIFF_AEIDF = dt.Rows.Item(i).Item("GSTIFF_AEIDF") & "|" 'New
                    GSTIFF_BAILV = dt.Rows.Item(i).Item("GSTIFF_BAILV") & "|"
                    GSTIFF_MRELV = dt.Rows.Item(i).Item("GSTIFF_MRELV") & "|" 'New 1.23
                    GSTIFF_ZINSS = dt.Rows.Item(i).Item("GSTIFF_ZINSS").ToString.Replace(",", ".") & "|" 'New Version 1.27
                    GSTIFF_INSRK = dt.Rows.Item(i).Item("GSTIFF_INSRK") & "|" 'New Version 1.27
                    GSTIFF_KRFUN = dt.Rows.Item(i).Item("GSTIFF_KRFUN") & "|" 'New Version 1.27
                    GSTIFF_TRDCO = dt.Rows.Item(i).Item("GSTIFF_TRDCO") & "|" 'New Version 1.27
                    GSTIFF_APKNZ = dt.Rows.Item(i).Item("GSTIFF_APKNZ") & "|" 'New 1.23
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXVBE")) = False Then 'New Version 1.27
                        Dim DXVBE_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXVBE")
                        GSTIFF_DXVBE = DXVBE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXVBE = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXPO1")) = False Then 'New Version 1.31
                        Dim DXPO1_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXPO1")
                        GSTIFF_DXPO1 = DXPO1_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXPO1 = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXPO2")) = False Then 'New Version 1.31
                        Dim DXPO2_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXPO2")
                        GSTIFF_DXPO2 = DXPO2_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXPO2 = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXNPE")) = False Then 'New Version 1.31
                        Dim DXNPE_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXNPE")
                        GSTIFF_DXNPE = DXNPE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXNPE = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXFBE")) = False Then 'New Version 1.31
                        Dim DXFBE_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXFBE")
                        GSTIFF_DXFBE = DXFBE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXFBE = "0" & "|"
                    End If

                    'GSTIFF_PBDFA = dt.Rows.Item(i).Item("GSTIFF_PBDFA") & "|" 'New 1.31 (DELETED IN VESRION 1.35)

                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXPBD")) = False Then 'New Version 1.31
                        Dim DXPBD_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXPBD")
                        GSTIFF_DXPBD = DXPBD_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXPBD = "0" & "|"
                    End If

                    GSTIFF_CSPID = dt.Rows.Item(i).Item("GSTIFF_CSPID") & "|" 'New 1.31
                    GSTIFF_CSPTY = dt.Rows.Item(i).Item("GSTIFF_CSPTY") & "|" 'New 1.31
                    GSTIFF_IPRKZ = dt.Rows.Item(i).Item("GSTIFF_IPRKZ") & "|" 'New 1.31
                    GSTIFF_ARTSP = dt.Rows.Item(i).Item("GSTIFF_ARTSP") & "|" 'New 1.31
                    GSTIFF_WLKKZ = dt.Rows.Item(i).Item("GSTIFF_WLKKZ") & "|" 'New Version 1.33
                    GSTIFF_PSINV = dt.Rows.Item(i).Item("GSTIFF_PSINV") & "|" 'New Version 1.33
                    GSTIFF_SPKRF = dt.Rows.Item(i).Item("GSTIFF_SPKRF") & "|" 'New Version 1.33
                    GSTIFF_KWAER = dt.Rows.Item(i).Item("GSTIFF_KWAER") & "|" 'New Version 1.35
                    GSTIFF_CKEKZ = dt.Rows.Item(i).Item("GSTIFF_CKEKZ") & "|" 'New Version 1.35
                    GSTIFF_AKEKZ = dt.Rows.Item(i).Item("GSTIFF_AKEKZ") & "|" 'New Version 1.35
                    GSTIFF_NHTFI = dt.Rows.Item(i).Item("GSTIFF_NHTFI") & "|" 'New Version 1.35
                    GSTIFF_AGTRK = dt.Rows.Item(i).Item("GSTIFF_AGTRK") & "|" 'New Version 1.35
                    GSTIFF_AGPRK = dt.Rows.Item(i).Item("GSTIFF_AGPRK") & "|" 'New Version 1.35
                    GSTIFF_EELEV = dt.Rows.Item(i).Item("GSTIFF_EELEV") & "|" 'New Version 1.35
                    GSTIFF_EESCO = dt.Rows.Item(i).Item("GSTIFF_EESCO").ToString.Replace(",", ".") & "|"  'New Version 1.35
                    GSTIFF_ONANT = dt.Rows.Item(i).Item("GSTIFF_ONANT").ToString.Replace(",", ".") & "|"  'New Version 1.35
                    GSTIFF_ONART = dt.Rows.Item(i).Item("GSTIFF_ONART") & "|" 'New Version 1.35
                    GSTIFF_I9WBS = dt.Rows.Item(i).Item("GSTIFF_I9WBS") & "|" 'New Version 1.35
                    GSTIFF_NUKGK = dt.Rows.Item(i).Item("GSTIFF_NUKGK") & "|" 'New Version 1.35
                    If IsDBNull(dt.Rows.Item(i).Item("GSTIFF_DXNAV")) = False Then 'New Version 1.36
                        Dim DXNAV_Date As Date = dt.Rows.Item(i).Item("GSTIFF_DXNAV")
                        GSTIFF_DXNAV = DXNAV_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTIFF_DXNAV = "0" & "|"
                    End If
                    GSTIFF_TAXEL = dt.Rows.Item(i).Item("GSTIFF_TAXEL") & "|" 'New Version 1.37
                    GSTIFF_RESE1 = dt.Rows.Item(i).Item("GSTIFF_RESE1") & "|" 'New Version 1.27
                    GSTIFF_RESE2 = dt.Rows.Item(i).Item("GSTIFF_RESE2") & "|" 'New Version 1.27
                    GSTIFF_RESE3 = dt.Rows.Item(i).Item("GSTIFF_RESE3") & "|" 'New Version 1.27
                    GSTIFF_FREI1 = dt.Rows.Item(i).Item("GSTIFF_FREI1") & "|"
                    GSTIFF_FREI2 = dt.Rows.Item(i).Item("GSTIFF_FREI2") & "|"
                    GSTIFF_FREI3 = dt.Rows.Item(i).Item("GSTIFF_FREI3") & "|"
                    GSTIFF_FREI4 = dt.Rows.Item(i).Item("GSTIFF_FREI4") & "|"
                    GSTIFF_FREI5 = dt.Rows.Item(i).Item("GSTIFF_FREI5") & "|"
                    GSTIFF_FREI6 = dt.Rows.Item(i).Item("GSTIFF_FREI6") & "|"
                    GSTIFF_FREI7 = dt.Rows.Item(i).Item("GSTIFF_FREI7") & "|"
                    GSTIFF_LOEKZ = dt.Rows.Item(i).Item("GSTIFF_LOEKZ") & "|"
                    GSTIFF_IFNAM = "GSTIAF" & "|"
                    GSTIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTIFF_DXIFD"))

                    CSV_ROW =
                        GSTIFF_MDANT &
                        GSTIFF_FILNR &
                        GSTIFF_MODUL &
                        GSTIFF_KDREA &
                        GSTIFF_KTONR &
                        GSTIFF_GSREF &
                        GSTIFF_BEZNG &
                        GSTIFF_KOART &
                        GSTIFF_BILKT &
                        GSTIFF_GSKLA &
                        GSTIFF_SUKLA &
                        GSTIFF_GSART &
                        GSTIFF_ULFZT &
                        GSTIFF_WHISO &
                        GSTIFF_VERKZ &
                        GSTIFF_SLDKZ &
                        GSTIFF_KZREV &
                        GSTIFF_WPKNZ &
                        GSTIFF_WPBFN &
                        GSTIFF_HBKZN &
                        GSTIFF_ZWRIS &
                        GSTIFF_KZLST &
                        GSTIFF_HAFIN &
                        GSTIFF_WESTA &
                        GSTIFF_BEREA &
                        GSTIFF_DXVND &
                        GSTIFF_DXBSD &
                        GSTIFF_MRLFZ &
                        GSTIFF_AUSFL &
                        GSTIFF_DXAUD &
                        GSTIFF_RANGF &
                        GSTIFF_KZUEV &
                        GSTIFF_KFRIS &
                        GSTIFF_DXZAP &
                        GSTIFF_KZVSG &
                        GSTIFF_KZKRU &
                        GSTIFF_KONSB &
                        GSTIFF_RISGR &
                        GSTIFF_KONSK &
                        GSTIFF_WPKNR &
                        GSTIFF_KENNR &
                        GSTIFF_GSARE &
                        GSTIFF_PRDKT &
                        GSTIFF_WHIFX &
                        GSTIFF_HFZGP &
                        GSTIFF_KZZGP &
                        GSTIFF_KZSEG &
                        GSTIFF_AFREF &
                        GSTIFF_KZAKL &
                        GSTIFF_KONSR &
                        GSTIFF_RLVID &
                        GSTIFF_NOTBF &
                        GSTIFF_POOLI &
                        GSTIFF_AEIDF &
                        GSTIFF_BAILV &
                        GSTIFF_MRELV &
                        GSTIFF_ZINSS &
                        GSTIFF_INSRK &
                        GSTIFF_KRFUN &
                        GSTIFF_TRDCO &
                        GSTIFF_APKNZ &
                        GSTIFF_DXVBE &
                        GSTIFF_DXPO1 &
                        GSTIFF_DXPO2 &
                        GSTIFF_DXNPE &
                        GSTIFF_DXFBE & 'GSTIFF_PBDFA & (Deleted in Version 1.35)
                        GSTIFF_DXPBD &
                        GSTIFF_CSPID &
                        GSTIFF_CSPTY &
                        GSTIFF_IPRKZ &
                        GSTIFF_ARTSP &
                        GSTIFF_WLKKZ &
                        GSTIFF_PSINV &
                        GSTIFF_SPKRF &
                        GSTIFF_KWAER &
                        GSTIFF_CKEKZ &
                        GSTIFF_AKEKZ &
                        GSTIFF_NHTFI &
                        GSTIFF_AGTRK &
                        GSTIFF_AGPRK &
                        GSTIFF_EELEV &
                        GSTIFF_EESCO &
                        GSTIFF_ONANT &
                        GSTIFF_ONART &
                        GSTIFF_I9WBS &
                        GSTIFF_NUKGK &
                        GSTIFF_DXNAV &
                        GSTIFF_TAXEL & 'v.137
                        GSTIFF_RESE1 &
                        GSTIFF_RESE2 &
                        GSTIFF_RESE3 &
                        GSTIFF_FREI1 &
                        GSTIFF_FREI2 &
                        GSTIFF_FREI3 &
                        GSTIFF_FREI4 &
                        GSTIFF_FREI5 &
                        GSTIFF_FREI6 &
                        GSTIFF_FREI7 &
                        GSTIFF_LOEKZ &
                        GSTIFF_IFNAM &
                        GSTIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                CloseSqlConnections()
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\GSTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTIFF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            Me.GSTIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "GSTIAF_MDANT|GSTIAF_FILNR|GSTIAF_MODUL|GSTIAF_KDREA|GSTIAF_KTONR|GSTIAF_GSREF|GSTIAF_BEZNG|GSTIAF_KOART|GSTIAF_BILKT|GSTIAF_GSKLA|GSTIAF_SUKLA|GSTIAF_GSART|GSTIAF_ULFZT|GSTIAF_WHISO|GSTIAF_VERKZ|GSTIAF_SLDKZ|GSTIAF_KZREV|GSTIAF_WPKNZ|GSTIAF_WPBFN|GSTIAF_HBKZN|GSTIAF_ZWRIS|GSTIAF_KZLST|GSTIAF_HAFIN|GSTIAF_WESTA|GSTIAF_BEREA|GSTIAF_DXVND|GSTIAF_DXBSD|GSTIAF_MRLFZ|GSTIAF_AUSFL|GSTIAF_DXAUD|GSTIAF_RANGF|GSTIAF_KZUEV|GSTIAF_KFRIS|GSTIAF_DXZAP|GSTIAF_KZVSG|GSTIAF_KZKRU|GSTIAF_KONSB|GSTIAF_RISGR|GSTIAF_KONSK|GSTIAF_WPKNR|GSTIAF_KENNR|GSTIAF_GSARE|GSTIAF_PRDKT|GSTIAF_WHIFX|GSTIAF_HFZGP|GSTIAF_KZZGP|GSTIAF_KZSEG|GSTIAF_AFREF|GSTIAF_KZAKL|GSTIAF_KONSR|GSTIAF_RLVID|GSTIAF_NOTBF|GSTIAF_POOLI|GSTIAF_AEIDF|GSTIAF_BAILV|GSTIAF_MRELV|GSTIAF_ZINSS|GSTIAF_INSRK|GSTIAF_KRFUN|GSTIAF_TRDCO|GSTIAF_APKNZ|GSTIAF_DXVBE|GSTIAF_DXPO1|GSTIAF_DXPO2|GSTIAF_DXNPE|GSTIAF_DXFBE|GSTIAF_PBDFA|GSTIAF_DXPBD|GSTIAF_CSPID|GSTIAF_CSPTY|GSTIAF_IPRKZ|GSTIAF_ARTSP|GSTIAF_WLKKZ|GSTIAF_PSINV|GSTIAF_SPKRF|GSTIAF_RESE1|GSTIAF_RESE2|GSTIAF_RESE3|GSTIAF_FREI1|GSTIAF_FREI2|GSTIAF_FREI3|GSTIAF_FREI4|GSTIAF_FREI5|GSTIAF_LOEKZ|GSTIAF_IFNAM|GSTIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSTIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSTIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSTIAF_CCB.csv for " & rd & vbNewLine & "There are no data in Table BAIS_GSTIFF for this Date" & vbNewLine & "Please check original BAIS File for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If
        CloseSqlConnections()
    End Sub

    Private Sub GSTSLF_CREATION()
        OpenSqlConnections()
        cmd.CommandText = "Select Count([ID]) from [BAIS_GSTSLF] where [GSTSLF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        'New Code
        Dim CSV_HEADER As String =
            "GSTSAF_MDANT" &
            "|GSTSAF_MODUL" &
            "|GSTSAF_KDREA" &
            "|GSTSAF_KTONR" &
            "|GSTSAF_GSREF" &
            "|GSTSAF_SLDUB" &
            "|GSTSAF_DISPO" &
            "|GSTSAF_DXDVD" &
            "|GSTSAF_DXDBD" &
            "|GSTSAF_ABGBT" &
            "|GSTSAF_GKBTR" &
            "|GSTSAF_DXFGB" &
            "|GSTSAF_FAIRV" &
            "|GSTSAF_ERFBT" &
            "|GSTSAF_BETNF" &
            "|GSTSAF_DAGIO" &
            "|GSTSAF_AOBSA" &
            "|GSTSAF_CSPBV" &
            "|GSTSAF_PRVBT" &
            "|GSTSAF_CO2ET" &
            "|GSTSAF_CO2S3" &
            "|GSTSAF_CO2RC" &
            "|GSTSAF_BSBTR" &
            "|GSTSAF_IFNAM" &
            "|GSTSAF_DXIFD"

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
        Dim GSTSLF_DXFGB As String = Nothing 'New 1.31
        Dim GSTSLF_FAIRV As String = Nothing
        Dim GSTSLF_ERFBT As String = Nothing 'New
        Dim GSTSLF_BETNF As String = Nothing 'New 1.25
        Dim GSTSLF_DAGIO As String = Nothing 'New 1.25
        Dim GSTSLF_AOBSA As String = Nothing 'New 1.31
        Dim GSTSLF_CSPBV As String = Nothing 'New 1.31
        Dim GSTSLF_PRVBT As String = Nothing 'New 1.31
        Dim GSTSLF_CO2ET As String = Nothing 'New 1.35
        Dim GSTSLF_CO2S3 As String = Nothing 'New 1.35
        Dim GSTSLF_CO2RC As String = Nothing 'New 1.35
        Dim GSTSLF_BSBTR As String = Nothing 'New 1.37
        Dim GSTSLF_IFNAM As String = Nothing
        Dim GSTSLF_DXIFD As String = Nothing

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSTSLF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSTSLF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSTSAF_CCB.csv...Please wait...")



                If File.Exists(BaisFilesCreationPath & "GSTSAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSTSAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_GSTSLF] where [GSTSLF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    If IsDBNull(dt.Rows.Item(i).Item("GSTSLF_DXFGB")) = False Then 'New Version 1.27
                        Dim DXFGB_Date As Date = dt.Rows.Item(i).Item("GSTSLF_DXFGB")
                        GSTSLF_DXFGB = DXFGB_Date.ToString("yyyyMMdd") & "|"
                    Else
                        GSTSLF_DXFGB = "0" & "|"
                    End If
                    GSTSLF_FAIRV = dt.Rows.Item(i).Item("GSTSLF_FAIRV") & "|"
                    GSTSLF_ERFBT = dt.Rows.Item(i).Item("GSTSLF_ERFBT").ToString.Replace(",", ".") & "|"
                    GSTSLF_BETNF = dt.Rows.Item(i).Item("GSTSLF_BETNF").ToString.Replace(",", ".") & "|"
                    GSTSLF_DAGIO = dt.Rows.Item(i).Item("GSTSLF_DAGIO").ToString.Replace(",", ".") & "|"
                    GSTSLF_AOBSA = dt.Rows.Item(i).Item("GSTSLF_AOBSA").ToString.Replace(",", ".") & "|" 'New Version 1.31
                    GSTSLF_CSPBV = dt.Rows.Item(i).Item("GSTSLF_CSPBV").ToString.Replace(",", ".") & "|" 'New Version 1.31
                    GSTSLF_PRVBT = dt.Rows.Item(i).Item("GSTSLF_PRVBT").ToString.Replace(",", ".") & "|" 'New Version 1.31
                    GSTSLF_CO2ET = dt.Rows.Item(i).Item("GSTSLF_CO2ET").ToString.Replace(",", ".") & "|" 'New Version 1.35
                    GSTSLF_CO2S3 = dt.Rows.Item(i).Item("GSTSLF_CO2S3").ToString.Replace(",", ".") & "|" 'New Version 1.35
                    GSTSLF_CO2RC = dt.Rows.Item(i).Item("GSTSLF_CO2RC") & "|" 'New Version 1.35
                    GSTSLF_BSBTR = dt.Rows.Item(i).Item("GSTSLF_BSBTR").ToString.Replace(",", ".") & "|" 'New Version 1.37
                    GSTSLF_IFNAM = "GSTSAF" & "|"
                    GSTSLF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSTSLF_DXIFD"))

                    CSV_ROW =
                        GSTSLF_MDANT &
                        GSTSLF_MODUL &
                        GSTSLF_KDREA &
                        GSTSLF_KTONR &
                        GSTSLF_GSREF &
                        GSTSLF_SLDUB &
                        GSTSLF_DISPO &
                        GSTSLF_DXDVD &
                        GSTSLF_DXDBD &
                        GSTSLF_ABGBT &
                        GSTSLF_GKBTR &
                        GSTSLF_DXFGB &
                        GSTSLF_FAIRV &
                        GSTSLF_ERFBT &
                        GSTSLF_BETNF &
                        GSTSLF_DAGIO &
                        GSTSLF_AOBSA &
                        GSTSLF_CSPBV &
                        GSTSLF_PRVBT &
                        GSTSLF_CO2ET &
                        GSTSLF_CO2S3 &
                        GSTSLF_CO2RC &
                        GSTSLF_BSBTR &
                        GSTSLF_IFNAM &
                        GSTSLF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                CloseSqlConnections()
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\GSTSLF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.GSTSLF_Result = "Created"
            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.GSTSLF_Result = "Not Created"
            'Dim CSV_HEADER As String = "GSTSAF_MDANT|GSTSAF_MODUL|GSTSAF_KDREA|GSTSAF_KTONR|GSTSAF_GSREF|GSTSAF_SLDUB|GSTSAF_DISPO|GSTSAF_DXDVD|GSTSAF_DXDBD|GSTSAF_ABGBT|GSTSAF_GKBTR|GSTSAF_DXFGB|GSTSAF_FAIRV|GSTSAF_ERFBT|GSTSAF_BETNF|GSTSAF_DAGIO|GSTSAF_AOBSA|GSTSAF_CSPBV|GSTSAF_PRVBT|GSTSAF_IFNAM|GSTSAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSTSAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSTSAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSTSAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSTSAF_CCB.csv for " & rd & vbNewLine & "Please check original BAIS File GSTSLF for Data!" & vbNewLine & "If File contains Data , import the related file for the requested Date!", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Exit Sub

        End If
        CloseSqlConnections()
    End Sub 'OK

    Private Sub BILIFF_CREATION()
        OpenSqlConnections()
        cmd.CommandText = "Select Count([ID]) from [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        'New Code
        Dim CSV_HEADER As String =
            "BILIFF_MDANT" &
            "|BILIFF_BILKT" &
            "|BILIFF_BILBZ" &
            "|BILIFF_SLDKZ" &
            "|BILIFF_IFNAM" &
            "|BILIFF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim BILIFF_MDANT As String = Nothing
        Dim BILIFF_BILKT As String = Nothing
        Dim BILIFF_BILBZ As String = Nothing
        Dim BILIFF_SLDKZ As String = Nothing
        Dim BILIFF_IFNAM As String = Nothing
        Dim BILIFF_DXIFD As String = Nothing

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_BILIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_BILIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: BILIFF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "BILIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "BILIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BILIFF_CCB] ORDER BY [BILIFF_BILKT] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                    CSV_ROW =
                        BILIFF_MDANT &
                        BILIFF_BILKT &
                        BILIFF_BILBZ &
                        BILIFF_SLDKZ &
                        BILIFF_IFNAM &
                        BILIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                cmd.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DROP TABLE [BILIFF_CCB]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.BILIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.BILIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "BILIFF_MDANT|BILIFF_BILKT|BILIFF_BILBZ|BILIFF_SLDKZ|BILIFF_IFNAM|BILIFF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "BILIFF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "BILIFF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "BILIFF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File BILIFF_CCB.csv for " & rd & vbNewLine & "There are no Balance Sheet Data for this Date" & vbNewLine & " Please update Balance Sheet Data", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        End If
        CloseSqlConnections()
    End Sub

    Private Sub KGCIFF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "KGCIAF_MDANT" &
            "|KGCIAF_MODUL" &
            "|KGCIAF_KDREA" &
            "|KGCIAF_KTONR" &
            "|KGCIAF_GSREF" &
            "|KGCIAF_ACCNR" &
            "|KGCIAF_PTYPI" &
            "|KGCIAF_CURCD" &
            "|KGCIAF_DXBEW" &
            "|KGCIAF_ERART" &
            "|KGCIAF_HOEHE" &
            "|KGCIAF_SALDO" &
            "|KGCIAF_TILGA" &
            "|KGCIAF_ZINSA" &
            "|KGCIAF_WHISO" &
            "|KGCIAF_KZABL" &
            "|KGCIAF_POOLI" &
            "|KGCIAF_CFTYP" &
            "|KGCIAF_IFNAM" &
            "|KGCIAF_DXIFD"

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
        Dim KGCIFF_CFTYP As String = Nothing
        Dim KGCIFF_IFNAM As String = Nothing
        Dim KGCIFF_DXIFD As String = Nothing

        BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KGCIFF File for: " & rd)
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KGCIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If

        cmd.CommandText = "Select Count([ID]) from [BAIS_KGCIFF] where [KGCIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KGCIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "KGCIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KGCIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KGCIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_KGCIFF] where [KGCIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    KGCIFF_CFTYP = dt.Rows.Item(i).Item("KGCIFF_CFTYP") & "|" 'New
                    KGCIFF_IFNAM = "KGCIAF" & "|"
                    KGCIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KGCIFF_DXIFD"))

                    CSV_ROW =
                        KGCIFF_MDANT &
                        KGCIFF_MODUL &
                        KGCIFF_KDREA &
                        KGCIFF_KTONR &
                        KGCIFF_GSREF &
                        KGCIFF_ACCNR &
                        KGCIFF_PTYPI &
                        KGCIFF_CURCD &
                        KGCIFF_DXBEW &
                        KGCIFF_ERART &
                        KGCIFF_HOEHE &
                        KGCIFF_SALDO &
                        KGCIFF_TILGA &
                        KGCIFF_ZINSA &
                        KGCIFF_WHISO &
                        KGCIFF_KZABL &
                        KGCIFF_POOLI &
                        KGCIFF_CFTYP &
                        KGCIFF_IFNAM &
                        KGCIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KGCIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KGCIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()
                Me.KGCIFF_Result = "Not Created"
                'Dim CSV_HEADER As String = "KGCIAF_MDANT|KGCIAF_MODUL|KGCIAF_KDREA|KGCIAF_KTONR|KGCIAF_GSREF|KGCIAF_ACCNR|KGCIAF_PTYPI|KGCIAF_CURCD|KGCIAF_DXBEW|KGCIAF_ERART|KGCIAF_HOEHE|KGCIAF_SALDO|KGCIAF_TILGA|KGCIAF_ZINSA|KGCIAF_WHISO|KGCIAF_KZABL|KGCIAF_POOLI|KGCIAF_CFTYP|KGCIAF_IFNAM|KGCIAF_DXIFD"
                'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KNEIAF File for: " & rd)
        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
        ParameterStatus = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KNEIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
        End If

        'New Code
        Dim CSV_HEADER As String =
            "KNEIAF_MDANT" &
            "|KNEIAF_FILNR" &
            "|KNEIAF_KDREA" &
            "|KNEIAF_KURZN" &
            "|KNEIAF_NAME1" &
            "|KNEIAF_NAME2" &
            "|KNEIAF_NAME3" &
            "|KNEIAF_PLZOR" &
            "|KNEIAF_PLZNR" &
            "|KNEIAF_STRAS" &
            "|KNEIAF_DXGEB" &
            "|KNEIAF_WSGSI" &
            "|KNEIAF_BRNCH" &
            "|KNEIAF_WSBIS" &
            "|KNEIAF_BRNZU" &
            "|KNEIAF_SLDSL" &
            "|KNEIAF_RLDSL" &
            "|KNEIAF_LDRIS" &
            "|KNEIAF_VSDSL" &
            "|KNEIAF_BONIT" &
            "|KNEIAF_GRPKZ" &
            "|KNEIAF_KZLST" &
            "|KNEIAF_KZPER" &
            "|KNEIAF_UMMIO" &
            "|KNEIAF_BILSU" &
            "|KNEIAF_UNTGR" &
            "|KNEIAF_DXNSI" &
            "|KNEIAF_AUSFL" &
            "|KNEIAF_DXAUD" &
            "|KNEIAF_ORGSL" &
            "|KNEIAF_RISGR" &
            "|KNEIAF_KGBID" &
            "|KNEIAF_ANRKZ" &
            "|KNEIAF_ASLGR" &
            "|KNEIAF_KDKLA" &
            "|KNEIAF_KUKON" &
            "|KNEIAF_NACES" &
            "|KNEIAF_LENID" &
            "|KNEIAF_WSCRR" &
            "|KNEIAF_WSFIN" &
            "|KNEIAF_CPYCT" & 'v.137
            "|KNEIAF_WSCVA" & 'v.137
            "|KNEIAF_AVCKZ" &
            "|KNEIAF_RECHF" &
            "|KNEIAF_KNBOG" &
            "|KNEIAF_MITAR" &
            "|KNEIAF_PDMEM" &
            "|KNEIAF_LGDAV" &
            "|KNEIAF_RSKAV" &
            "|KNEIAF_DXNPE" &
            "|KNEIAF_DXFBE" &
            "|KNEIAF_EXPVA" &
            "|KNEIAF_NUKGK" &
            "|KNEIAF_AUSPB" &
            "|KNEIAF_ONANT" &
            "|KNEIAF_ONART" &
            "|KNEIAF_BSGRP" &
            "|KNEIAF_ARIAD" &
            "|KNEIAF_TAXEL" & 'v.137
            "|KNEIAF_ESGOP" & 'v.137
            "|KNEIAF_ONFRD" & 'v.137
            "|KNEIAF_UMKPI" & 'v.137
            "|KNEIAF_CEKPI" & 'v.137
            "|KNEIAF_AMEKZ" & 'v.137
            "|KNEIAF_MEVAL" & 'v.137
            "|KNEIAF_REFJA" & 'v.137
            "|KNEIAF_DSIEA" & 'v.137
            "|KNEIAF_TARDS" & 'v.137
            "|KNEIAF_KZAWE" & 'v.137
            "|KNEIAF_RESE1" & 'v.137
            "|KNEIAF_RESE2" & 'v.137
            "|KNEIAF_RESE3" & 'v.137
            "|KNEIAF_FREI1" &
            "|KNEIAF_FREI2" &
            "|KNEIAF_FREI3" &
            "|KNEIAF_FREI4" &
            "|KNEIAF_FREI5" &
            "|KNEIAF_LOEKZ" &
            "|KNEIAF_IFNAM" &
            "|KNEIAF_DXIFD"

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
        Dim KNEIFF_VSDSL As String = Nothing 'New 1.31
        Dim KNEIFF_BONIT As String = Nothing
        Dim KNEIFF_GRPKZ As String = Nothing
        Dim KNEIFF_KZLST As String = Nothing
        Dim KNEIFF_KZPER As String = Nothing
        Dim KNEIFF_UMMIO As String = Nothing
        Dim KNEIFF_BILSU As String = Nothing 'New 1.25
        Dim KNEIFF_UNTGR As String = Nothing 'New 1.33
        Dim KNEIFF_DXNSI As String = Nothing 'New 1.25
        Dim KNEIFF_AUSFL As String = Nothing
        Dim KNEIFF_DXAUD As String = Nothing
        Dim KNEIFF_ORGSL As String = Nothing
        Dim KNEIFF_RISGR As String = Nothing
        Dim KNEIFF_KGBID As String = Nothing
        Dim KNEIFF_ANRKZ As String = Nothing
        Dim KNEIFF_ASLGR As String = Nothing
        Dim KNEIFF_KDKLA As String = Nothing 'New
        Dim KNEIFF_KUKON As String = Nothing 'New
        Dim KNEIFF_NACES As String = Nothing
        Dim KNEIFF_LENID As String = Nothing
        Dim KNEIFF_WSCRR As String = Nothing
        Dim KNEIFF_WSFIN As String = Nothing 'New
        Dim KNEIFF_CPYCT As String = Nothing 'v.137
        Dim KNEIFF_WSCVA As String = Nothing 'v.137
        Dim KNEIFF_AVCKZ As String = Nothing
        Dim KNEIFF_RECHF As String = Nothing 'New
        Dim KNEIFF_KNBOG As String = Nothing 'New
        Dim KNEIFF_MITAR As String = Nothing 'New
        Dim KNEIFF_PDMEM As String = Nothing 'New 1.25
        Dim KNEIFF_LGDAV As String = Nothing 'New
        Dim KNEIFF_RSKAV As String = Nothing 'New
        Dim KNEIFF_DXNPE As String = Nothing 'new 1.31
        Dim KNEIFF_DXFBE As String = Nothing 'new 1.31
        Dim KNEIFF_EXPVA As String = Nothing 'new 1.31
        Dim KNEIFF_NUKGK As String = Nothing 'new 1.35
        Dim KNEIFF_AUSPB As String = Nothing 'new 1.35
        Dim KNEIFF_ONANT As String = Nothing 'new 1.35
        Dim KNEIFF_ONART As String = Nothing 'new 1.35
        Dim KNEIFF_BSGRP As String = Nothing 'new 1.36
        Dim KNEIFF_ARIAD As String = Nothing 'new 1.36
        Dim KNEIFF_TAXEL As String = Nothing 'v.137
        Dim KNEIFF_ESGOP As String = Nothing 'v.137
        Dim KNEIFF_ONFRD As String = Nothing 'v.137
        Dim KNEIFF_UMKPI As String = Nothing 'v.137
        Dim KNEIFF_CEKPI As String = Nothing 'v.137
        Dim KNEIFF_AMEKZ As String = Nothing 'v.137
        Dim KNEIFF_MEVAL As String = Nothing 'v.137
        Dim KNEIFF_REFJA As String = Nothing 'v.137
        Dim KNEIFF_DSIEA As String = Nothing 'v.137
        Dim KNEIFF_TARDS As String = Nothing 'v.137
        Dim KNEIFF_KZAWE As String = Nothing 'v.137
        Dim KNEIFF_RESE1 As String = Nothing 'v.137
        Dim KNEIFF_RESE2 As String = Nothing 'v.137
        Dim KNEIFF_RESE3 As String = Nothing 'v.137
        Dim KNEIFF_FREI1 As String = Nothing
        Dim KNEIFF_FREI2 As String = Nothing
        Dim KNEIFF_FREI3 As String = Nothing
        Dim KNEIFF_FREI4 As String = Nothing
        Dim KNEIFF_FREI5 As String = Nothing
        Dim KNEIFF_LOEKZ As String = Nothing
        Dim KNEIFF_IFNAM As String = Nothing
        Dim KNEIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KNEIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "KNEIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KNEIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KNEIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                'Only Data with KDNRH<>0 and no duplicates
                QueryText = "SELECT * FROM  [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "' and [KNEIFF_KDNRH] not in ('0') and [ID] in (Select Min(ID) from [BAIS_KNEIFF] where [KNEIFF_DXIFD]='" & rdsql & "' GROUP BY [KNEIFF_KDNRH])"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    KNEIFF_VSDSL = dt.Rows.Item(i).Item("KNEIFF_VSDSL") & "|" '1.31
                    KNEIFF_BONIT = dt.Rows.Item(i).Item("KNEIFF_BONIT") & "|"
                    KNEIFF_GRPKZ = dt.Rows.Item(i).Item("KNEIFF_GRPKZ") & "|"
                    KNEIFF_KZLST = dt.Rows.Item(i).Item("KNEIFF_KZLST") & "|"
                    KNEIFF_KZPER = dt.Rows.Item(i).Item("KNEIFF_KZPER") & "|"
                    KNEIFF_UMMIO = dt.Rows.Item(i).Item("KNEIFF_UMMIO").ToString.Replace(",", ".") & "|"
                    KNEIFF_BILSU = dt.Rows.Item(i).Item("KNEIFF_BILSU").ToString.Replace(",", ".") & "|" 'New 1.25
                    KNEIFF_UNTGR = dt.Rows.Item(i).Item("KNEIFF_UNTGR") & "|"
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
                    If IsDBNull(dt.Rows.Item(i).Item("KNEIFF_ASLGR")) = False Then 'New Version 1.27
                        KNEIFF_ASLGR = "'" & dt.Rows.Item(i).Item("KNEIFF_ASLGR") & "'" & "|"
                    Else
                        KNEIFF_ASLGR = dt.Rows.Item(i).Item("KNEIFF_ASLGR") & "|"
                    End If
                    KNEIFF_KDKLA = dt.Rows.Item(i).Item("KNEIFF_KDKLA") & "|" 'New
                    KNEIFF_KUKON = dt.Rows.Item(i).Item("KNEIFF_KUKON") & "|" 'New
                    KNEIFF_NACES = dt.Rows.Item(i).Item("KNEIFF_NACES") & "|"
                    KNEIFF_LENID = dt.Rows.Item(i).Item("KNEIFF_LENID") & "|"
                    KNEIFF_WSCRR = dt.Rows.Item(i).Item("KNEIFF_WSCRR") & "|"
                    KNEIFF_WSFIN = dt.Rows.Item(i).Item("KNEIFF_WSFIN") & "|" 'New
                    KNEIFF_CPYCT = dt.Rows.Item(i).Item("KNEIFF_CPYCT") & "|" 'v.137
                    KNEIFF_WSCVA = dt.Rows.Item(i).Item("KNEIFF_WSCVA") & "|" 'v.137
                    KNEIFF_AVCKZ = dt.Rows.Item(i).Item("KNEIFF_AVCKZ") & "|"
                    KNEIFF_RECHF = dt.Rows.Item(i).Item("KNEIFF_RECHF") & "|" 'New
                    KNEIFF_KNBOG = dt.Rows.Item(i).Item("KNEIFF_KNBOG") & "|" 'New
                    KNEIFF_MITAR = dt.Rows.Item(i).Item("KNEIFF_MITAR") & "|" 'New
                    KNEIFF_PDMEM = dt.Rows.Item(i).Item("KNEIFF_PDMEM").ToString.Replace(",", ".") & "|" 'New 1.25
                    KNEIFF_LGDAV = dt.Rows.Item(i).Item("KNEIFF_LGDAV").ToString.Replace(",", ".") & "|" 'New Version 1.27
                    KNEIFF_RSKAV = dt.Rows.Item(i).Item("KNEIFF_RSKAV").ToString.Replace(",", ".") & "|" 'New Version 1.27
                    If IsDBNull(dt.Rows.Item(i).Item("KNEIFF_DXNPE")) = False Then 'New 1.31
                        Dim DXNPE_Date As Date = dt.Rows.Item(i).Item("KNEIFF_DXNPE")
                        KNEIFF_DXNPE = DXNPE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        KNEIFF_DXNPE = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("KNEIFF_DXFBE")) = False Then 'New 1.31
                        Dim DXFBE_Date As Date = dt.Rows.Item(i).Item("KNEIFF_DXFBE")
                        KNEIFF_DXFBE = DXFBE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        KNEIFF_DXFBE = "0" & "|"
                    End If
                    KNEIFF_EXPVA = dt.Rows.Item(i).Item("KNEIFF_EXPVA") & "|" 'New 1.31
                    KNEIFF_NUKGK = dt.Rows.Item(i).Item("KNEIFF_NUKGK") & "|" 'new 1.35
                    KNEIFF_AUSPB = dt.Rows.Item(i).Item("KNEIFF_AUSPB") & "|" 'new 1.35
                    KNEIFF_ONANT = dt.Rows.Item(i).Item("KNEIFF_ONANT").ToString.Replace(",", ".") & "|" 'new 1.35
                    KNEIFF_ONART = dt.Rows.Item(i).Item("KNEIFF_ONART") & "|" 'new 1.35
                    KNEIFF_BSGRP = dt.Rows.Item(i).Item("KNEIFF_BSGRP") & "|" 'new 1.36
                    KNEIFF_ARIAD = dt.Rows.Item(i).Item("KNEIFF_ARIAD") & "|" 'new 1.36
                    KNEIFF_TAXEL = dt.Rows.Item(i).Item("KNEIFF_TAXEL") & "|" 'v.137
                    KNEIFF_ESGOP = dt.Rows.Item(i).Item("KNEIFF_ESGOP") & "|" 'v.137
                    KNEIFF_ONFRD = dt.Rows.Item(i).Item("KNEIFF_ONFRD") & "|" 'v.137
                    KNEIFF_UMKPI = dt.Rows.Item(i).Item("KNEIFF_UMKPI") & "|" 'v.137
                    KNEIFF_CEKPI = dt.Rows.Item(i).Item("KNEIFF_CEKPI") & "|" 'v.137
                    KNEIFF_AMEKZ = dt.Rows.Item(i).Item("KNEIFF_AMEKZ") & "|" 'v.137
                    KNEIFF_MEVAL = dt.Rows.Item(i).Item("KNEIFF_MEVAL") & "|" 'v.137
                    KNEIFF_REFJA = dt.Rows.Item(i).Item("KNEIFF_REFJA") & "|" 'v.137
                    KNEIFF_DSIEA = dt.Rows.Item(i).Item("KNEIFF_DSIEA") & "|" 'v.137
                    KNEIFF_TARDS = dt.Rows.Item(i).Item("KNEIFF_TARDS") & "|" 'v.137
                    KNEIFF_KZAWE = dt.Rows.Item(i).Item("KNEIFF_KZAWE") & "|" 'v.137
                    KNEIFF_RESE1 = dt.Rows.Item(i).Item("KNEIFF_RESE1") & "|" 'v.137
                    KNEIFF_RESE2 = dt.Rows.Item(i).Item("KNEIFF_RESE2") & "|" 'v.137
                    KNEIFF_RESE3 = dt.Rows.Item(i).Item("KNEIFF_RESE3") & "|" 'v.137
                    KNEIFF_FREI1 = dt.Rows.Item(i).Item("KNEIFF_FREI1") & "|"
                    KNEIFF_FREI2 = dt.Rows.Item(i).Item("KNEIFF_FREI2") & "|"
                    KNEIFF_FREI3 = dt.Rows.Item(i).Item("KNEIFF_FREI3") & "|"
                    KNEIFF_FREI4 = dt.Rows.Item(i).Item("KNEIFF_FREI4") & "|"
                    KNEIFF_FREI5 = dt.Rows.Item(i).Item("KNEIFF_FREI5") & "|"
                    KNEIFF_LOEKZ = dt.Rows.Item(i).Item("KNEIFF_LOEKZ") & "|"
                    KNEIFF_IFNAM = "KNEIAF" & "|"
                    KNEIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("KNEIFF_DXIFD"))

                    CSV_ROW =
                        KNEIFF_MDANT &
                        KNEIFF_FILNR &
                        KNEIFF_KDREA &
                        KNEIFF_KURZN &
                        KNEIFF_NAME1 &
                        KNEIFF_NAME2 &
                        KNEIFF_NAME3 &
                        KNEIFF_PLZOR &
                        KNEIFF_PLZNR &
                        KNEIFF_STRAS &
                        KNEIFF_DXGEB &
                        KNEIFF_WSGSI &
                        KNEIFF_BRNCH &
                        KNEIFF_WSBIS &
                        KNEIFF_BRNZU &
                        KNEIFF_SLDSL &
                        KNEIFF_RLDSL &
                        KNEIFF_LDRIS &
                        KNEIFF_VSDSL &
                        KNEIFF_BONIT &
                        KNEIFF_GRPKZ &
                        KNEIFF_KZLST &
                        KNEIFF_KZPER &
                        KNEIFF_UMMIO &
                        KNEIFF_BILSU &
                        KNEIFF_UNTGR &
                        KNEIFF_DXNSI &
                        KNEIFF_AUSFL &
                        KNEIFF_DXAUD &
                        KNEIFF_ORGSL &
                        KNEIFF_RISGR &
                        KNEIFF_KGBID &
                        KNEIFF_ANRKZ &
                        KNEIFF_ASLGR &
                        KNEIFF_KDKLA &
                        KNEIFF_KUKON &
                        KNEIFF_NACES &
                        KNEIFF_LENID &
                        KNEIFF_WSCRR &
                        KNEIFF_WSFIN &
                        KNEIFF_CPYCT &  'v.137
                        KNEIFF_WSCVA &  'v.137
                        KNEIFF_AVCKZ &
                        KNEIFF_RECHF &
                        KNEIFF_KNBOG &
                        KNEIFF_MITAR &
                        KNEIFF_PDMEM &
                        KNEIFF_LGDAV &
                        KNEIFF_RSKAV &
                        KNEIFF_DXNPE &
                        KNEIFF_DXFBE &
                        KNEIFF_EXPVA &
                        KNEIFF_NUKGK &
                        KNEIFF_AUSPB &
                        KNEIFF_ONANT &
                        KNEIFF_ONART &
                        KNEIFF_BSGRP &
                        KNEIFF_ARIAD &
                        KNEIFF_TAXEL &  'v.137
                        KNEIFF_ESGOP &  'v.137
                        KNEIFF_ONFRD &  'v.137
                        KNEIFF_UMKPI &  'v.137
                        KNEIFF_CEKPI &  'v.137
                        KNEIFF_AMEKZ &  'v.137
                        KNEIFF_MEVAL &  'v.137
                        KNEIFF_REFJA & 'v.137
                        KNEIFF_DSIEA & 'v.137
                        KNEIFF_TARDS &  'v.137
                        KNEIFF_KZAWE &  'v.137
                        KNEIFF_RESE1 &  'v.137
                        KNEIFF_RESE2 &  'v.137
                        KNEIFF_RESE3 &  'v.137
                        KNEIFF_FREI1 &
                        KNEIFF_FREI2 &
                        KNEIFF_FREI3 &
                        KNEIFF_FREI4 &
                        KNEIFF_FREI5 &
                        KNEIFF_LOEKZ &
                        KNEIFF_IFNAM &
                        KNEIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KNEIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KNEIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()
                Me.KNEIFF_Result = "Not Created"
                'Dim CSV_HEADER As String = "KNEIAF_MDANT|KNEIAF_FILNR|KNEIAF_KDREA|KNEIAF_KURZN|KNEIAF_NAME1|KNEIAF_NAME2|KNEIAF_NAME3|KNEIAF_PLZOR|KNEIAF_PLZNR|KNEIAF_STRAS|KNEIAF_DXGEB|KNEIAF_WSGSI|KNEIAF_BRNCH|KNEIAF_WSBIS|KNEIAF_BRNZU|KNEIAF_SLDSL|KNEIAF_RLDSL|KNEIAF_LDRIS|KNEIAF_VSDSL|KNEIAF_BONIT|KNEIAF_GRPKZ|KNEIAF_KZLST|KNEIAF_KZPER|KNEIAF_UMMIO|KNEIAF_BILSU|KNEIAF_UNTGR|KNEIAF_DXNSI|KNEIAF_AUSFL|KNEIAF_DXAUD|KNEIAF_ORGSL|KNEIAF_RISGR|KNEIAF_KGBID|KNEIAF_ANRKZ|KNEIAF_ASLGR|KNEIAF_KDKLA|KNEIAF_KUKON|KNEIAF_NACES|KNEIAF_LENID|KNEIAF_WSCRR|KNEIAF_WSFIN|KNEIAF_AVCKZ|KNEIAF_RECHF|KNEIAF_KNBOG|KNEIAF_MITAR|KNEIAF_PDMEM|KNEIAF_LGDAV|KNEIAF_RSKAV|KNEIAF_DXNPE|KNEIAF_DXFBE|KNEIAF_EXPVA|KNEIAF_FREI1|KNEIAF_FREI2|KNEIAF_FREI3|KNEIAF_FREI4|KNEIAF_FREI5|KNEIAF_LOEKZ|KNEIAF_IFNAM|KNEIAF_DXIFD"
                'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        Try
            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KNVIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KNVIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            BgwBaisFilesCreation.ReportProgress(2, "Generating File: KNVIAF_CCB.csv...Please wait...")
            'New Code
            Dim CSV_HEADER As String =
                "KNVIAF_MDANK" &
                "|KNVIAF_MDANT" &
                "|KNVIAF_KNZNR" &
                "|KNVIAF_MDAN2" &
                "|KNVIAF_KDREA" &
                "|KNVIAF_KNEKZ" &
                "|KNVIAF_GRDZF" &
                "|KNVIAF_ZUSKZ" &
                "|KNVIAF_GBRKZ" &
                "|KNVIAF_GEKTO" &
                "|KNVIAF_MEANT" &
                "|KNVIAF_HFBES" &
                "|KNVIAF_ANERL" &
                "|KNVIAF_BETXT" &
                "|KNVIAF_FREI1" &
                "|KNVIAF_FREI2" &
                "|KNVIAF_FREI3" &
                "|KNVIAF_LOEKZ" &
                "|KNVIAF_IFNAM" &
                "|KNVIAF_DXIFD"

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
            QueryText = "SELECT * FROM  [BAIS_KNVIFF] where [KNVIFF_DXIFD]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                CSV_ROW =
                    KNVIFF_MDANK &
                    KNVIFF_MDANT &
                    KNVIFF_KNZNR &
                    KNVIFF_MDAN2 &
                    KNVIFF_KDREA &
                    KNVIFF_KNEKZ &
                    KNVIFF_GRDZF &
                    KNVIFF_ZUSKZ &
                    KNVIFF_GBRKZ &
                    KNVIFF_GEKTO &
                    KNVIFF_MEANT &
                    KNVIFF_HFBES &
                    KNVIFF_ANERL &
                    KNVIFF_BETXT &
                    KNVIFF_FREI1 &
                    KNVIFF_FREI2 &
                    KNVIFF_FREI3 &
                    KNVIFF_LOEKZ &
                    KNVIFF_IFNAM &
                    KNVIFF_DXIFD

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
            CloseSqlConnections()
            Me.KNVIFF_Result = "Not Created"
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CloseSqlConnections()
    End Sub

    Private Sub KRKIFF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
                    "KRKIAF_MDANT" &
                    "|KRKIAF_KDREA" &
                    "|KRKIAF_RAGEN" &
                    "|KRKIAF_RKLIF" &
                    "|KRKIAF_FREI1" &
                    "|KRKIAF_FREI2" &
                    "|KRKIAF_FREI3" &
                    "|KRKIAF_IFNAM" &
                    "|KRKIAF_DXIFD"

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

        cmd.CommandText = "Select Count([ID]) from [CUSTOMER_RATING_DETAILS]"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KRKIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KRKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KRKIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "KRKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KRKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KRKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++

                QueryText = "SELECT * FROM  [BAIS_KRKIFF] where [KRKIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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


                    CSV_ROW =
                        KRKIFF_MDANT &
                        KRKIFF_KDREA &
                        KRKIFF_RAGEN &
                        KRKIFF_RKLIF &
                        KRKIFF_FREI1 &
                        KRKIFF_FREI2 &
                        KRKIFF_FREI3 &
                        KRKIFF_IFNAM &
                        KRKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KRKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KRKIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.KRKIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "KRKIAF_MDANT|KRKIAF_KDREA|KRKIAF_RAGEN|KRKIAF_RKLIF|KRKIAF_FREI1|KRKIAF_FREI2|KRKIAF_FREI3|KRKIAF_IFNAM|KRKIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "KSRIFF_MDANT" &
            "|KSRIFF_RKLIF" &
            "|KSRIFF_RAGEN" &
            "|KSRIFF_RATYP" &
            "|KSRIFF_KZHFW" &
            "|KSRIFF_RATEX" &
            "|KSRIFF_DXRAT" &
            "|KSRIFF_LDISO" &
            "|KSRIFF_IFNAM" &
            "|KSRIFF_DXIFD"

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

        cmd.CommandText = "Select Count([ID]) from [BAIS_KSRIFF] where [KSRIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_KSRIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_KSRIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: KSRIFF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "KSRIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "KSRIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "KSRIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++




                QueryText = "SELECT * FROM  [BAIS_KSRIFF] where [KSRIFF_DXIFD]='" & rdsql & "' and ([KSRIFF_RKLIF] not in ('0') or [KSRIFF_RKLIF] is not NULL)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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



                    CSV_ROW =
                        KSRIFF_MDANT &
                        KSRIFF_RKLIF &
                        KSRIFF_RAGEN &
                        KSRIFF_RATYP &
                        KSRIFF_KZHFW &
                        KSRIFF_RATEX &
                        KSRIFF_DXRAT &
                        KSRIFF_LDISO &
                        KSRIFF_IFNAM &
                        KSRIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "KSRIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.KSRIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()
                Me.KSRIFF_Result = "Not Created"
                'Dim CSV_HEADER As String = "KSRIFF_MDANT|KSRIFF_RKLIF|KSRIFF_RAGEN|KSRIFF_RATYP|KSRIFF_KZHFW|KSRIFF_RATEX|KSRIFF_DXRAT|KSRIFF_LDISO|KSRIFF_IFNAM|KSRIFF_DXIFD"
                'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "LQGIAF_MDANT" &
            "|LQGIAF_MODUL" &
            "|LQGIAF_KDREA" &
            "|LQGIAF_KTONR" &
            "|LQGIAF_GSREF" &
            "|LQGIAF_EINLS" &
            "|LQGIAF_KUNDG" &
            "|LQGIAF_KUNBT" &
            "|LQGIAF_EINTY" &
            "|LQGIAF_BESFI" &
            "|LQGIAF_DXBES" &
            "|LQGIAF_MWSIC" &
            "|LQGIAF_WHMWS" &
            "|LQGIAF_KZABL" &
            "|LQGIAF_DXBEL" &
            "|LQGIAF_HOEBL" &
            "|LQGIAF_WHGBL" &
            "|LQGIAF_NOMBT" &
            "|LQGIAF_HAWHG" &
            "|LQGIAF_KUDIV" &
            "|LQGIAF_QKRLA" &
            "|LQGIAF_LIQQU" &
            "|LQGIAF_LQAST" &
            "|LQGIAF_KZLCI" &
            "|LQGIAF_UEBSI" &
            "|LQGIAF_UEBSG" &
            "|LQGIAF_KZFAZ" &
            "|LQGIAF_LCRK1" &
            "|LQGIAF_LCRK2" &
            "|LQGIAF_LCRK3" &
            "|LQGIAF_LCRK4" &
            "|LQGIAF_NSFRK" &
            "|LQGIAF_NSFK2" &
            "|LQGIAF_CTKAT" &
            "|LQGIAF_CAPIF" &
            "|LQGIAF_SPREA" &
            "|LQGIAF_AMMPR" &
            "|LQGIAF_RZFKI" &
            "|LQGIAF_ZNKAP" &
            "|LQGIAF_KFRTG" &
            "|LQGIAF_C70BT" &
            "|LQGIAF_DXOPR" &
            "|LQGIAF_RGK6M" &
            "|LQGIAF_RGK1J" &
            "|LQGIAF_RGG1J" &
            "|LQGIAF_AGK6M" &
            "|LQGIAF_AGK1J" &
            "|LQGIAF_AGG1J" &
            "|LQGIAF_LZBNS" &
            "|LQGIAF_INLIM" &
            "|LQGIAF_EXLIM" &
            "|LQGIAF_AZEZU" &
            "|LQGIAF_RSCD1" &
            "|LQGIAF_RSCD2" &
            "|LQGIAF_RSTX1" &
            "|LQGIAF_RSTX2" &
            "|LQGIAF_RSDX1" &
            "|LQGIAF_RSPR1" &
            "|LQGIAF_RSBT1" &
            "|LQGIAF_RSBT2" &
            "|LQGIAF_IFNAM" &
            "|LQGIAF_DXIFD"

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
        Dim LQGIFF_DXBES As String = Nothing
        Dim LQGIFF_MWSIC As String = Nothing
        Dim LQGIFF_WHMWS As String = Nothing
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
        Dim LQGIFF_UEBSG As String = Nothing 'New 1.35
        Dim LQGIFF_KZFAZ As String = Nothing
        Dim LQGIFF_LCRK1 As String = Nothing
        Dim LQGIFF_LCRK2 As String = Nothing
        Dim LQGIFF_LCRK3 As String = Nothing 'New
        Dim LQGIFF_LCRK4 As String = Nothing 'New 1.23
        Dim LQGIFF_NSFRK As String = Nothing
        Dim LQGIFF_NSFK2 As String = Nothing ' new 1.31
        Dim LQGIFF_CTKAT As String = Nothing 'New
        Dim LQGIFF_CAPIF As String = Nothing
        Dim LQGIFF_SPREA As String = Nothing 'New
        Dim LQGIFF_AMMPR As String = Nothing 'New
        Dim LQGIFF_RZFKI As String = Nothing 'New 1.23
        Dim LQGIFF_ZNKAP As String = Nothing 'New 1.23
        Dim LQGIFF_KFRTG As String = Nothing 'New Version 1.27
        Dim LQGIFF_C70BT As String = Nothing ' New 1.25
        Dim LQGIFF_DXOPR As String = Nothing 'New 1.31
        Dim LQGIFF_RGK6M As String = Nothing 'New 1.31
        Dim LQGIFF_RGK1J As String = Nothing 'New 1.31
        Dim LQGIFF_RGG1J As String = Nothing 'New 1.31
        Dim LQGIFF_AGK6M As String = Nothing 'New 1.31
        Dim LQGIFF_AGK1J As String = Nothing 'New 1.31
        Dim LQGIFF_AGG1J As String = Nothing 'New 1.31
        Dim LQGIFF_LZBNS As String = Nothing 'New 1.31
        Dim LQGIFF_INLIM As String = Nothing ' New 1.35
        Dim LQGIFF_EXLIM As String = Nothing ' New 1.35
        Dim LQGIFF_AZEZU As String = Nothing ' New 1.35
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

        cmd.CommandText = "Select Count([ID]) from [BAIS_LQGIFF] where [LQGIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_LQGIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_LQGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: LQGIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "LQGIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "LQGIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "LQGIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_LQGIFF] where [LQGIFF_DXIFD]='" & rdsql & "' and ID  in (Select min(ID) from BAIS_LQGIFF where LQGIFF_DXIFD='" & rdsql & "' GROUP BY LQGIFF_GSREF)"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    LQGIFF_DXBES = dt.Rows.Item(i).Item("LQGIFF_DXBES") & "|"
                    LQGIFF_MWSIC = dt.Rows.Item(i).Item("LQGIFF_MWSIC") & "|"
                    LQGIFF_WHMWS = dt.Rows.Item(i).Item("LQGIFF_WHMWS") & "|"
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
                    LQGIFF_UEBSG = dt.Rows.Item(i).Item("LQGIFF_UEBSG").ToString.Replace(",", ".") & "|" 'New
                    LQGIFF_KZFAZ = dt.Rows.Item(i).Item("LQGIFF_KZFAZ") & "|"
                    LQGIFF_LCRK1 = dt.Rows.Item(i).Item("LQGIFF_LCRK1") & "|"
                    LQGIFF_LCRK2 = dt.Rows.Item(i).Item("LQGIFF_LCRK2") & "|"
                    LQGIFF_LCRK3 = dt.Rows.Item(i).Item("LQGIFF_LCRK3") & "|" 'New
                    LQGIFF_LCRK4 = dt.Rows.Item(i).Item("LQGIFF_LCRK4") & "|" 'New 1.23
                    LQGIFF_NSFRK = dt.Rows.Item(i).Item("LQGIFF_NSFRK") & "|"
                    LQGIFF_NSFK2 = dt.Rows.Item(i).Item("LQGIFF_NSFK2") & "|"
                    LQGIFF_CTKAT = dt.Rows.Item(i).Item("LQGIFF_CTKAT") & "|" 'New
                    LQGIFF_CAPIF = dt.Rows.Item(i).Item("LQGIFF_CAPIF") & "|"
                    LQGIFF_SPREA = dt.Rows.Item(i).Item("LQGIFF_SPREA").ToString.Replace(",", ".") & "|" 'New
                    LQGIFF_AMMPR = dt.Rows.Item(i).Item("LQGIFF_AMMPR") & "|" 'New
                    LQGIFF_RZFKI = dt.Rows.Item(i).Item("LQGIFF_RZFKI") & "|" 'New 1.23
                    LQGIFF_ZNKAP = dt.Rows.Item(i).Item("LQGIFF_ZNKAP") & "|" 'New 1.23
                    LQGIFF_KFRTG = dt.Rows.Item(i).Item("LQGIFF_KFRTG").ToString.Replace(",", ".") & "|" 'New Version 1.27
                    LQGIFF_C70BT = dt.Rows.Item(i).Item("LQGIFF_C70BT") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("LQGIFF_DXOPR")) = False Then 'New 1.25
                        Dim DXOPR_Date As Date = dt.Rows.Item(i).Item("LQGIFF_DXOPR")
                        LQGIFF_DXOPR = DXOPR_Date.ToString("yyyyMMdd") & "|"
                    Else
                        LQGIFF_DXOPR = "0" & "|"
                    End If
                    LQGIFF_RGK6M = dt.Rows.Item(i).Item("LQGIFF_RGK6M").ToString.Replace(",", ".") & "|"
                    LQGIFF_RGK1J = dt.Rows.Item(i).Item("LQGIFF_RGK1J").ToString.Replace(",", ".") & "|"
                    LQGIFF_RGG1J = dt.Rows.Item(i).Item("LQGIFF_RGG1J").ToString.Replace(",", ".") & "|"
                    LQGIFF_AGK6M = dt.Rows.Item(i).Item("LQGIFF_AGK6M").ToString.Replace(",", ".") & "|"
                    LQGIFF_AGK1J = dt.Rows.Item(i).Item("LQGIFF_AGK1J").ToString.Replace(",", ".") & "|"
                    LQGIFF_AGG1J = dt.Rows.Item(i).Item("LQGIFF_AGG1J").ToString.Replace(",", ".") & "|"
                    LQGIFF_LZBNS = dt.Rows.Item(i).Item("LQGIFF_LZBNS") & "|"
                    LQGIFF_INLIM = dt.Rows.Item(i).Item("LQGIFF_INLIM") & "|"
                    LQGIFF_EXLIM = dt.Rows.Item(i).Item("LQGIFF_EXLIM") & "|"
                    LQGIFF_AZEZU = dt.Rows.Item(i).Item("LQGIFF_AZEZU") & "|"
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


                    CSV_ROW =
                        LQGIFF_MDANT &
                        LQGIFF_MODUL &
                        LQGIFF_KDREA &
                        LQGIFF_KTONR &
                        LQGIFF_GSREF &
                        LQGIFF_EINLS &
                        LQGIFF_KUNDG &
                        LQGIFF_KUNBT &
                        LQGIFF_EINTY &
                        LQGIFF_BESFI &
                        LQGIFF_DXBES &
                        LQGIFF_MWSIC &
                        LQGIFF_WHMWS &
                        LQGIFF_KZABL &
                        LQGIFF_DXBEL &
                        LQGIFF_HOEBL &
                        LQGIFF_WHGBL &
                        LQGIFF_NOMBT &
                        LQGIFF_HAWHG &
                        LQGIFF_KUDIV &
                        LQGIFF_QKRLA &
                        LQGIFF_LIQQU &
                        LQGIFF_LQAST &
                        LQGIFF_KZLCI &
                        LQGIFF_UEBSI &
                        LQGIFF_UEBSG &
                        LQGIFF_KZFAZ &
                        LQGIFF_LCRK1 &
                        LQGIFF_LCRK2 &
                        LQGIFF_LCRK3 &
                        LQGIFF_LCRK4 &
                        LQGIFF_NSFRK &
                        LQGIFF_NSFK2 &
                        LQGIFF_CTKAT &
                        LQGIFF_CAPIF &
                        LQGIFF_SPREA &
                        LQGIFF_AMMPR &
                        LQGIFF_RZFKI &
                        LQGIFF_ZNKAP &
                        LQGIFF_KFRTG &
                        LQGIFF_C70BT &
                        LQGIFF_DXOPR &
                        LQGIFF_RGK6M &
                        LQGIFF_RGK1J &
                        LQGIFF_RGG1J &
                        LQGIFF_AGK6M &
                        LQGIFF_AGK1J &
                        LQGIFF_AGG1J &
                        LQGIFF_LZBNS &
                        LQGIFF_INLIM &
                        LQGIFF_EXLIM &
                        LQGIFF_AZEZU &
                        LQGIFF_RSCD1 &
                        LQGIFF_RSCD2 &
                        LQGIFF_RSTX1 &
                        LQGIFF_RSTX2 &
                        LQGIFF_RSDX1 &
                        LQGIFF_RSPR1 &
                        LQGIFF_RSBT1 &
                        LQGIFF_RSBT2 &
                        LQGIFF_IFNAM &
                        LQGIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "LQGIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.LQGIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.LQGIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "LQGIAF_MDANT|LQGIAF_MODUL|LQGIAF_KDREA|LQGIAF_KTONR|LQGIAF_GSREF|LQGIAF_EINLS|LQGIAF_KUNDG|LQGIAF_KUNBT|LQGIAF_EINTY|LQGIAF_BESFI|LQGIAF_DXBES|LQGIAF_MWSIC|LQGIAF_WHMWS|LQGIAF_KZABL|LQGIAF_DXBEL|LQGIAF_HOEBL|LQGIAF_WHGBL|LQGIAF_NOMBT|LQGIAF_HAWHG|LQGIAF_KUDIV|LQGIAF_QKRLA|LQGIAF_LIQQU|LQGIAF_LQAST|LQGIAF_KZLCI|LQGIAF_UEBSI|LQGIAF_KZFAZ|LQGIAF_LCRK1|LQGIAF_LCRK2|LQGIAF_LCRK3|LQGIAF_LCRK4|LQGIAF_NSFRK|LQGIAF_NSFK2|LQGIAF_CTKAT|LQGIAF_CAPIF|LQGIAF_SPREA|LQGIAF_AMMPR|LQGIAF_RZFKI|LQGIAF_ZNKAP|LQGIAF_KFRTG|LQGIAF_C70BT|LQGIAF_DXOPR|LQGIAF_RGK6M|LQGIAF_RGK1J|LQGIAF_RGG1J|LQGIAF_AGK6M|LQGIAF_AGK1J|LQGIAF_AGG1J|LQGIAF_LZBNS|LQGIAF_INLIM|LQGIAF_EXLIM|LQGIAF_AZEZU|LQGIAF_RSCD1|LQGIAF_RSCD2|LQGIAF_RSTX1|LQGIAF_RSTX2|LQGIAF_RSDX1|LQGIAF_RSPR1|LQGIAF_RSBT1|LQGIAF_RSBT2|LQGIAF_IFNAM|LQGIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "MKUIFF_MDANT" &
            "|MKUIFF_WPKNR" &
            "|MKUIFF_HAWHG" &
            "|MKUIFF_PREIS" &
            "|MKUIFF_PREI2" &
            "|MKUIFF_PREID" &
            "|MKUIFF_STRKU" &
            "|MKUIFF_BEWAB" &
            "|MKUIFF_BWALA" &
            "|MKUIFF_POOLF" &
            "|MKUIFF_FREI1" &
            "|MKUIFF_IFNAM" &
            "|MKUIFF_DXIFD"

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
        Dim MKUIFF_IFNAM As String = Nothing
        Dim MKUIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_MKUIFF] where [MKUIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_MKUIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_MKUIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If



                BgwBaisFilesCreation.ReportProgress(2, "Generating File: MKUIFF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "MKUIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "MKUIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "MKUIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_MKUIFF] where [MKUIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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


                    CSV_ROW =
                        MKUIFF_MDANT &
                        MKUIFF_WPKNR &
                        MKUIFF_HAWHG &
                        MKUIFF_PREIS &
                        MKUIFF_PREI2 &
                        MKUIFF_PREID &
                        MKUIFF_STRKU &
                        MKUIFF_BEWAB &
                        MKUIFF_BWALA &
                        MKUIFF_POOLF &
                        MKUIFF_FREI1 &
                        MKUIFF_IFNAM &
                        MKUIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "MKUIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.MKUIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()
                Me.MKUIFF_Result = "Not Created"
                'Dim CSV_HEADER As String = "MKUIFF_MDANT|MKUIFF_WPKNR|MKUIFF_HAWHG|MKUIFF_PREIS|MKUIFF_PREI2|MKUIFF_PREID|MKUIFF_STRKU|MKUIFF_BEWAB|MKUIFF_BWALA|MKUIFF_POOLF|MKUIFF_FREI1|MKUIFF_IFNAM|MKUIFF_DXIFD"
                'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "ZUSIAF_MDANT" &
            "|ZUSIAF_FILNR" &
            "|ZUSIAF_KDREA" &
            "|ZUSIAF_ZUREF" &
            "|ZUSIAF_ZUART" &
            "|ZUSIAF_KRART" &
            "|ZUSIAF_MODUL" &
            "|ZUSIAF_KTONR" &
            "|ZUSIAF_GSREF" &
            "|ZUSIAF_ZUEXU" &
            "|ZUSIAF_WHRGE" &
            "|ZUSIAF_DXZGA" &
            "|ZUSIAF_DXVNE" &
            "|ZUSIAF_DXBSE" &
            "|ZUSIAF_KZREV" &
            "|ZUSIAF_KZUNW" &
            "|ZUSIAF_KZABR" &
            "|ZUSIAF_WLKKZ" &
            "|ZUSIAF_KNZZU" &
            "|ZUSIAF_ZOEKZ" &
            "|ZUSIAF_KGZUO" &
            "|ZUSIAF_BUEZU" &
            "|ZUSIAF_BEREA" &
            "|ZUSIAF_ZUTYP" &
            "|ZUSIAF_AUSFL" &
            "|ZUSIAF_DXAUD" &
            "|ZUSIAF_KOART" &
            "|ZUSIAF_GSART" &
            "|ZUSIAF_RISGR" &
            "|ZUSIAF_KZUKU" &
            "|ZUSIAF_ERHGE" &
            "|ZUSIAF_GSARE" &
            "|ZUSIAF_HAFIN" &
            "|ZUSIAF_PRDKT" &
            "|ZUSIAF_INABU" &
            "|ZUSIAF_KZAKL" &
            "|ZUSIAF_POOLI" &
            "|ZUSIAF_AEIDF" &
            "|ZUSIAF_HFZGP" &
            "|ZUSIAF_ZUSTS" &
            "|ZUSIAF_DXNPE" &
            "|ZUSIAF_DXFBE" & ' Deleted on version 1.35"|ZUSIAF_PBDFA" &
            "|ZUSIAF_DXPBD" &
            "|ZUSIAF_IPRKZ" &
            "|ZUSIAF_ARTSP" &
            "|ZUSIAF_FREI1" &
            "|ZUSIAF_FREI2" &
            "|ZUSIAF_FREI3" &
            "|ZUSIAF_FREI4" &
            "|ZUSIAF_FREI5" &
            "|ZUSIAF_FREI6" &
            "|ZUSIAF_FREI7" &
            "|ZUSIAF_LOEKZ" &
            "|ZUSIAF_IFNAM" &
            "|ZUSIAF_DXIFD"

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
        Dim ZUSIFF_BUEZU As String = Nothing 'New 1.30
        Dim ZUSIFF_BEREA As String = Nothing 'New 1.30
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
        Dim ZUSIFF_HFZGP As String = Nothing 'New
        Dim ZUSIFF_ZUSTS As String = Nothing 'New 1.30
        Dim ZUSIFF_DXNPE As String = Nothing 'New 1.31
        Dim ZUSIFF_DXFBE As String = Nothing 'New 1.31
        'Dim ZUSIFF_PBDFA As String = Nothing 'New 1.31 (Deleted on Version 1.35)
        Dim ZUSIFF_DXPBD As String = Nothing 'New 1.31
        Dim ZUSIFF_IPRKZ As String = Nothing 'New 1.31
        Dim ZUSIFF_ARTSP As String = Nothing 'New 1.31
        Dim ZUSIFF_FREI1 As String = Nothing
        Dim ZUSIFF_FREI2 As String = Nothing
        Dim ZUSIFF_FREI3 As String = Nothing
        Dim ZUSIFF_FREI4 As String = Nothing
        Dim ZUSIFF_FREI5 As String = Nothing
        Dim ZUSIFF_FREI6 As String = Nothing
        Dim ZUSIFF_FREI7 As String = Nothing
        Dim ZUSIFF_LOEKZ As String = Nothing
        Dim ZUSIFF_IFNAM As String = Nothing
        Dim ZUSIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_ZUSIFF] where [ZUSIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_ZUSIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_ZUSIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: ZUSIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "ZUSIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "ZUSIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "ZUSIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_ZUSIFF] where [ZUSIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    ZUSIFF_BUEZU = dt.Rows.Item(i).Item("ZUSIFF_BUEZU") & "|"
                    ZUSIFF_BEREA = dt.Rows.Item(i).Item("ZUSIFF_BEREA") & "|"
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
                    ZUSIFF_HFZGP = dt.Rows.Item(i).Item("ZUSIFF_HFZGP") & "|" 'New
                    ZUSIFF_ZUSTS = dt.Rows.Item(i).Item("ZUSIFF_ZUSTS") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("ZUSIFF_DXNPE")) = False Then 'New 1.31
                        Dim DXNPE_Date As Date = dt.Rows.Item(i).Item("ZUSIFF_DXNPE")
                        ZUSIFF_DXNPE = DXNPE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ZUSIFF_DXNPE = "0" & "|"
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("ZUSIFF_DXFBE")) = False Then 'New 1.31
                        Dim DXFBE_Date As Date = dt.Rows.Item(i).Item("ZUSIFF_DXFBE")
                        ZUSIFF_DXFBE = DXFBE_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ZUSIFF_DXFBE = "0" & "|"
                    End If

                    'ZUSIFF_PBDFA = dt.Rows.Item(i).Item("ZUSIFF_PBDFA").ToString.Replace(",", ".") & "|" 'New 1.31 (Deletd on Version 1.35)

                    If IsDBNull(dt.Rows.Item(i).Item("ZUSIFF_DXPBD")) = False Then 'New 1.31
                        Dim DXPBD_Date As Date = dt.Rows.Item(i).Item("ZUSIFF_DXPBD")
                        ZUSIFF_DXPBD = DXPBD_Date.ToString("yyyyMMdd") & "|"
                    Else
                        ZUSIFF_DXPBD = "0" & "|"
                    End If
                    ZUSIFF_IPRKZ = dt.Rows.Item(i).Item("ZUSIFF_IPRKZ") & "|" 'New 1.31
                    ZUSIFF_ARTSP = dt.Rows.Item(i).Item("ZUSIFF_ARTSP") & "|" 'New 1.31
                    ZUSIFF_FREI1 = dt.Rows.Item(i).Item("ZUSIFF_FREI1") & "|"
                    ZUSIFF_FREI2 = dt.Rows.Item(i).Item("ZUSIFF_FREI2") & "|"
                    ZUSIFF_FREI3 = dt.Rows.Item(i).Item("ZUSIFF_FREI3") & "|"
                    ZUSIFF_FREI4 = dt.Rows.Item(i).Item("ZUSIFF_FREI4") & "|"
                    ZUSIFF_FREI5 = dt.Rows.Item(i).Item("ZUSIFF_FREI5") & "|"
                    ZUSIFF_FREI6 = dt.Rows.Item(i).Item("ZUSIFF_FREI6") & "|"
                    ZUSIFF_FREI7 = dt.Rows.Item(i).Item("ZUSIFF_FREI7") & "|"
                    ZUSIFF_LOEKZ = dt.Rows.Item(i).Item("ZUSIFF_LOEKZ") & "|"
                    ZUSIFF_IFNAM = "ZUSIAF" & "|"
                    ZUSIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("ZUSIFF_DXIFD"))

                    CSV_ROW =
                        ZUSIFF_MDANT &
                        ZUSIFF_FILNR &
                        ZUSIFF_KDREA &
                        ZUSIFF_ZUREF &
                        ZUSIFF_ZUART &
                        ZUSIFF_KRART &
                        ZUSIFF_MODUL &
                        ZUSIFF_KTONR &
                        ZUSIFF_GSREF &
                        ZUSIFF_ZUEXU &
                        ZUSIFF_WHRGE &
                        ZUSIFF_DXZGA &
                        ZUSIFF_DXVNE &
                        ZUSIFF_DXBSE &
                        ZUSIFF_KZREV &
                        ZUSIFF_KZUNW &
                        ZUSIFF_KZABR &
                        ZUSIFF_WLKKZ &
                        ZUSIFF_KNZZU &
                        ZUSIFF_ZOEKZ &
                        ZUSIFF_KGZUO &
                        ZUSIFF_BUEZU &
                        ZUSIFF_BEREA &
                        ZUSIFF_ZUTYP &
                        ZUSIFF_AUSFL &
                        ZUSIFF_DXAUD &
                        ZUSIFF_KOART &
                        ZUSIFF_GSART &
                        ZUSIFF_RISGR &
                        ZUSIFF_KZUKU &
                        ZUSIFF_ERHGE &
                        ZUSIFF_GSARE &
                        ZUSIFF_HAFIN &
                        ZUSIFF_PRDKT &
                        ZUSIFF_INABU &
                        ZUSIFF_KZAKL &
                        ZUSIFF_POOLI &
                        ZUSIFF_AEIDF &
                        ZUSIFF_HFZGP &
                        ZUSIFF_ZUSTS &
                        ZUSIFF_DXNPE &
                        ZUSIFF_DXFBE &
                        ZUSIFF_DXPBD &
                        ZUSIFF_IPRKZ &
                        ZUSIFF_ARTSP &
                        ZUSIFF_FREI1 &
                        ZUSIFF_FREI2 &
                        ZUSIFF_FREI3 &
                        ZUSIFF_FREI4 &
                        ZUSIFF_FREI5 &
                        ZUSIFF_FREI6 &
                        ZUSIFF_FREI7 &
                        ZUSIFF_LOEKZ &
                        ZUSIFF_IFNAM &
                        ZUSIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "ZUSIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.ZUSIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.ZUSIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "ZUSIAF_MDANT|ZUSIAF_FILNR|ZUSIAF_KDREA|ZUSIAF_ZUREF|ZUSIAF_ZUART|ZUSIAF_KRART|ZUSIAF_MODUL|ZUSIAF_KTONR|ZUSIAF_GSREF|ZUSIAF_ZUEXU|ZUSIAF_WHRGE|ZUSIAF_DXZGA|ZUSIAF_DXVNE|ZUSIAF_DXBSE|ZUSIAF_KZREV|ZUSIAF_KZUNW|ZUSIAF_KZABR|ZUSIAF_WLKKZ|ZUSIAF_KNZZU|ZUSIAF_ZOEKZ|ZUSIAF_KGZUO|ZUSIAF_BUEZU|ZUSIAF_BEREA|ZUSIAF_ZUTYP|ZUSIAF_AUSFL|ZUSIAF_DXAUD|ZUSIAF_KOART|ZUSIAF_GSART|ZUSIAF_RISGR|ZUSIAF_KZUKU|ZUSIAF_ERHGE|ZUSIAF_GSARE|ZUSIAF_HAFIN|ZUSIAF_PRDKT|ZUSIAF_INABU|ZUSIAF_KZAKL|ZUSIAF_POOLI|ZUSIAF_AEIDF|ZUSIAF_HFZGP|ZUSIAF_ZUSTS|ZUSIAF_DXNPE|ZUSIAF_DXFBE|ZUSIAF_PBDFA|ZUSIAF_DXPBD|ZUSIAF_IPRKZ|ZUSIAF_ARTSP|ZUSIAF_FREI1|ZUSIAF_FREI2|ZUSIAF_FREI3|ZUSIAF_FREI4|ZUSIAF_FREI5|ZUSIAF_LOEKZ|ZUSIAF_IFNAM|ZUSIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "GAKIAF_MDANT" &
            "|GAKIAF_GARFN" &
            "|GAKIAF_FILNR" &
            "|GAKIAF_GARTG" &
            "|GAKIAF_GARTI" &
            "|GAKIAF_HBKZN" &
            "|GAKIAF_DXVND" &
            "|GAKIAF_DXBSD" &
            "|GAKIAF_GABTR" &
            "|GAKIAF_DXGBT" &
            "|GAKIAF_APRVA" &
            "|GAKIAF_ATOPV" &
            "|GAKIAF_APROV" &
            "|GAKIAF_DXPRO" &
            "|GAKIAF_APVAP" &
            "|GAKIAF_VWTER" &
            "|GAKIAF_WHISO" &
            "|GAKIAF_GSPRZ" &
            "|GAKIAF_SIPRZ" &
            "|GAKIAF_MODUL" &
            "|GAKIAF_KDREA" &
            "|GAKIAF_SICGA" &
            "|GAKIAF_KTONR" &
            "|GAKIAF_GSREF" &
            "|GAKIAF_DEPNR" &
            "|GAKIAF_KZBVK" &
            "|GAKIAF_BEBTR" &
            "|GAKIAF_WHBEB" &
            "|GAKIAF_DXBWE" &
            "|GAKIAF_VEBTR" &
            "|GAKIAF_WHVEB" &
            "|GAKIAF_DXVWE" &
            "|GAKIAF_VORBT" &
            "|GAKIAF_WHVOR" &
            "|GAKIAF_OLDSL" &
            "|GAKIAF_PLZNR" &
            "|GAKIAF_SIGAR" &
            "|GAKIAF_KRRFN" &
            "|GAKIAF_HCMPV" &
            "|GAKIAF_HCWHG" &
            "|GAKIAF_LIQUD" &
            "|GAKIAF_RSKFZ" &
            "|GAKIAF_RGWKZ" &
            "|GAKIAF_KZA14" &
            "|GAKIAF_KZABI" &
            "|GAKIAF_KZAFI" &
            "|GAKIAF_KZAAC" &
            "|GAKIAF_KZAAE" &
            "|GAKIAF_KZALE" &
            "|GAKIAF_KZACR" &
            "|GAKIAF_KZAPB" &
            "|GAKIAF_KZSUB" &
            "|GAKIAF_KZZWB" &
            "|GAKIAF_KZECA" &
            "|GAKIAF_LFDGS" &
            "|GAKIAF_FREI1" &
            "|GAKIAF_FREI2" &
            "|GAKIAF_FREI3" &
            "|GAKIAF_FREI4" &
            "|GAKIAF_FREI5" &
            "|GAKIAF_LOEKZ" &
            "|GAKIAF_IFNAM" &
            "|GAKIAF_DXIFD"

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
        Dim GAKIFF_APRVA As String = Nothing 'New Version 1.27
        Dim GAKIFF_ATOPV As String = Nothing 'New 1.25
        Dim GAKIFF_APROV As String = Nothing 'New 1.25
        Dim GAKIFF_DXPRO As String = Nothing 'New 1.25
        Dim GAKIFF_APVAP As String = Nothing 'New Version 1.27
        Dim GAKIFF_VWTER As String = Nothing
        Dim GAKIFF_WHISO As String = Nothing
        Dim GAKIFF_GSPRZ As String = Nothing
        Dim GAKIFF_SIPRZ As String = Nothing 'New Version 1.35
        Dim GAKIFF_MODUL As String = Nothing
        Dim GAKIFF_KDREA As String = Nothing
        Dim GAKIFF_SICGA As String = Nothing 'New 1.25
        Dim GAKIFF_KTONR As String = Nothing
        Dim GAKIFF_GSREF As String = Nothing
        Dim GAKIFF_DEPNR As String = Nothing
        Dim GAKIFF_KZBVK As String = Nothing
        Dim GAKIFF_BEBTR As String = Nothing
        Dim GAKIFF_WHBEB As String = Nothing 'New Version 1.29
        Dim GAKIFF_DXBWE As String = Nothing 'New 1.25
        Dim GAKIFF_VEBTR As String = Nothing
        Dim GAKIFF_WHVEB As String = Nothing 'New Version 1.29
        Dim GAKIFF_DXVWE As String = Nothing 'New 1.25
        Dim GAKIFF_VORBT As String = Nothing
        Dim GAKIFF_WHVOR As String = Nothing 'New Version 1.29
        Dim GAKIFF_OLDSL As String = Nothing
        Dim GAKIFF_PLZNR As String = Nothing 'New 1.25
        Dim GAKIFF_SIGAR As String = Nothing
        Dim GAKIFF_KRRFN As String = Nothing
        Dim GAKIFF_HCMPV As String = Nothing
        Dim GAKIFF_HCWHG As String = Nothing
        Dim GAKIFF_LIQUD As String = Nothing
        Dim GAKIFF_RSKFZ As String = Nothing
        Dim GAKIFF_RGWKZ As String = Nothing
        Dim GAKIFF_KZA14 As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZABI As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZAFI As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZAAC As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZAAE As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZALE As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZACR As String = Nothing 'New Version 1.27
        Dim GAKIFF_KZAPB As String = Nothing 'new 1.31
        Dim GAKIFF_KZSUB As String = Nothing
        Dim GAKIFF_KZZWB As String = Nothing
        Dim GAKIFF_KZECA As String = Nothing 'New 1.34
        Dim GAKIFF_LFDGS As String = Nothing 'New 1.25
        Dim GAKIFF_EELEV As String = Nothing 'New 1.35
        Dim GAKIFF_EESCO As String = Nothing 'New 1.35
        Dim GAKIFF_NUKGK As String = Nothing 'New 1.35
        Dim GAKIFF_FREI1 As String = Nothing
        Dim GAKIFF_FREI2 As String = Nothing
        Dim GAKIFF_FREI3 As String = Nothing
        Dim GAKIFF_FREI4 As String = Nothing
        Dim GAKIFF_FREI5 As String = Nothing
        Dim GAKIFF_LOEKZ As String = Nothing
        Dim GAKIFF_IFNAM As String = Nothing
        Dim GAKIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_GAKIFF] where [GAKIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GAKIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GAKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If



                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GAKIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "GAKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GAKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GAKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_GAKIFF] where [GAKIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    GAKIFF_APRVA = dt.Rows.Item(i).Item("GAKIFF_APRVA").ToString.Replace(",", ".") & "|" 'New Version 1.27
                    GAKIFF_ATOPV = dt.Rows.Item(i).Item("GAKIFF_ATOPV") & "|"
                    GAKIFF_APROV = dt.Rows.Item(i).Item("GAKIFF_APROV") & "|"
                    GAKIFF_DXPRO = dt.Rows.Item(i).Item("GAKIFF_DXPRO") & "|"
                    GAKIFF_APVAP = dt.Rows.Item(i).Item("GAKIFF_APVAP") & "|" 'New Version 1.27
                    GAKIFF_VWTER = dt.Rows.Item(i).Item("GAKIFF_VWTER") & "|"
                    GAKIFF_WHISO = dt.Rows.Item(i).Item("GAKIFF_WHISO") & "|"
                    GAKIFF_GSPRZ = dt.Rows.Item(i).Item("GAKIFF_GSPRZ").ToString.Replace(",", ".") & "|"
                    GAKIFF_SIPRZ = dt.Rows.Item(i).Item("GAKIFF_SIPRZ").ToString.Replace(",", ".") & "|" 'New Version 1.35
                    GAKIFF_MODUL = dt.Rows.Item(i).Item("GAKIFF_MODUL") & "|"
                    GAKIFF_KDREA = dt.Rows.Item(i).Item("GAKIFF_KDNRG") & "|"
                    GAKIFF_SICGA = dt.Rows.Item(i).Item("GAKIFF_SICGA") & "|"
                    GAKIFF_KTONR = dt.Rows.Item(i).Item("GAKIFF_KTONR") & "|"
                    GAKIFF_GSREF = dt.Rows.Item(i).Item("GAKIFF_GSREF") & "|"
                    GAKIFF_DEPNR = dt.Rows.Item(i).Item("GAKIFF_DEPNR") & "|"
                    GAKIFF_KZBVK = dt.Rows.Item(i).Item("GAKIFF_KZBVK") & "|"
                    GAKIFF_BEBTR = dt.Rows.Item(i).Item("GAKIFF_BEBTR") & "|"
                    GAKIFF_WHBEB = dt.Rows.Item(i).Item("GAKIFF_WHBEB") & "|"
                    GAKIFF_DXBWE = dt.Rows.Item(i).Item("GAKIFF_DXBWE") & "|"
                    GAKIFF_VEBTR = dt.Rows.Item(i).Item("GAKIFF_VEBTR") & "|"
                    GAKIFF_WHVEB = dt.Rows.Item(i).Item("GAKIFF_WHVEB") & "|"
                    GAKIFF_DXVWE = dt.Rows.Item(i).Item("GAKIFF_DXVWE") & "|"
                    GAKIFF_VORBT = dt.Rows.Item(i).Item("GAKIFF_VORBT") & "|"
                    GAKIFF_WHVOR = dt.Rows.Item(i).Item("GAKIFF_WHVOR") & "|"
                    GAKIFF_OLDSL = dt.Rows.Item(i).Item("GAKIFF_OLDSL") & "|"
                    GAKIFF_PLZNR = dt.Rows.Item(i).Item("GAKIFF_PLZNR") & "|"
                    GAKIFF_SIGAR = dt.Rows.Item(i).Item("GAKIFF_SIGAR") & "|"
                    GAKIFF_KRRFN = dt.Rows.Item(i).Item("GAKIFF_KRRFN") & "|"
                    GAKIFF_HCMPV = dt.Rows.Item(i).Item("GAKIFF_HCMPV") & "|"
                    GAKIFF_HCWHG = dt.Rows.Item(i).Item("GAKIFF_HCWHG") & "|"
                    GAKIFF_LIQUD = dt.Rows.Item(i).Item("GAKIFF_LIQUD") & "|"
                    GAKIFF_RSKFZ = dt.Rows.Item(i).Item("GAKIFF_RSKFZ") & "|"
                    GAKIFF_RGWKZ = dt.Rows.Item(i).Item("GAKIFF_RGWKZ") & "|"
                    GAKIFF_KZA14 = dt.Rows.Item(i).Item("GAKIFF_KZA14") & "|" 'New Version 1.27
                    GAKIFF_KZABI = dt.Rows.Item(i).Item("GAKIFF_KZABI") & "|" 'New Version 1.27
                    GAKIFF_KZAFI = dt.Rows.Item(i).Item("GAKIFF_KZAFI") & "|" 'New Version 1.27
                    GAKIFF_KZAAC = dt.Rows.Item(i).Item("GAKIFF_KZAAC") & "|" 'New Version 1.27
                    GAKIFF_KZAAE = dt.Rows.Item(i).Item("GAKIFF_KZAAE") & "|" 'New Version 1.27
                    GAKIFF_KZALE = dt.Rows.Item(i).Item("GAKIFF_KZALE") & "|" 'New Version 1.27
                    GAKIFF_KZACR = dt.Rows.Item(i).Item("GAKIFF_KZACR") & "|" 'New Version 1.27
                    GAKIFF_KZAPB = dt.Rows.Item(i).Item("GAKIFF_KZAPB") & "|" 'New Version 1.31
                    GAKIFF_KZSUB = dt.Rows.Item(i).Item("GAKIFF_KZSUB") & "|"
                    GAKIFF_KZZWB = dt.Rows.Item(i).Item("GAKIFF_KZZWB") & "|"
                    GAKIFF_KZECA = dt.Rows.Item(i).Item("GAKIFF_KZECA") & "|" 'New Version 1.34
                    GAKIFF_LFDGS = dt.Rows.Item(i).Item("GAKIFF_LFDGS") & "|"
                    GAKIFF_EELEV = dt.Rows.Item(i).Item("GAKIFF_EELEV") & "|" 'New Version 1.34
                    GAKIFF_EESCO = dt.Rows.Item(i).Item("GAKIFF_EESCO") & "|" 'New Version 1.34
                    GAKIFF_NUKGK = dt.Rows.Item(i).Item("GAKIFF_NUKGK") & "|" 'New Version 1.34
                    GAKIFF_FREI1 = dt.Rows.Item(i).Item("GAKIFF_FREI1") & "|"
                    GAKIFF_FREI2 = dt.Rows.Item(i).Item("GAKIFF_FREI2") & "|"
                    GAKIFF_FREI3 = dt.Rows.Item(i).Item("GAKIFF_FREI3") & "|"
                    GAKIFF_FREI4 = dt.Rows.Item(i).Item("GAKIFF_FREI4") & "|"
                    GAKIFF_FREI5 = dt.Rows.Item(i).Item("GAKIFF_FREI5") & "|"
                    GAKIFF_LOEKZ = dt.Rows.Item(i).Item("GAKIFF_LOEKZ") & "|"
                    GAKIFF_IFNAM = "GAKIAF" & "|"
                    GAKIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GAKIFF_DXIFD"))


                    CSV_ROW =
                        GAKIFF_MDANT &
                        GAKIFF_GARFN &
                        GAKIFF_FILNR &
                        GAKIFF_GARTG &
                        GAKIFF_GARTI &
                        GAKIFF_HBKZN &
                        GAKIFF_DXVND &
                        GAKIFF_DXBSD &
                        GAKIFF_GABTR &
                        GAKIFF_DXGBT &
                        GAKIFF_APRVA &
                        GAKIFF_ATOPV &
                        GAKIFF_APROV &
                        GAKIFF_DXPRO &
                        GAKIFF_APVAP &
                        GAKIFF_VWTER &
                        GAKIFF_WHISO &
                        GAKIFF_GSPRZ &
                        GAKIFF_SIPRZ &
                        GAKIFF_MODUL &
                        GAKIFF_KDREA &
                        GAKIFF_SICGA &
                        GAKIFF_KTONR &
                        GAKIFF_GSREF &
                        GAKIFF_DEPNR &
                        GAKIFF_KZBVK &
                        GAKIFF_BEBTR &
                        GAKIFF_WHBEB &
                        GAKIFF_DXBWE &
                        GAKIFF_VEBTR &
                        GAKIFF_WHVEB &
                        GAKIFF_DXVWE &
                        GAKIFF_VORBT &
                        GAKIFF_WHVOR &
                        GAKIFF_OLDSL &
                        GAKIFF_PLZNR &
                        GAKIFF_SIGAR &
                        GAKIFF_KRRFN &
                        GAKIFF_HCMPV &
                        GAKIFF_HCWHG &
                        GAKIFF_LIQUD &
                        GAKIFF_RSKFZ &
                        GAKIFF_RGWKZ &
                        GAKIFF_KZA14 &
                        GAKIFF_KZABI &
                        GAKIFF_KZAFI &
                        GAKIFF_KZAAC &
                        GAKIFF_KZAAE &
                        GAKIFF_KZALE &
                        GAKIFF_KZACR &
                        GAKIFF_KZAPB &
                        GAKIFF_KZSUB &
                        GAKIFF_KZZWB &
                        GAKIFF_KZECA &
                        GAKIFF_LFDGS &
                        GAKIFF_EELEV &
                        GAKIFF_EESCO &
                        GAKIFF_NUKGK &
                        GAKIFF_FREI1 &
                        GAKIFF_FREI2 &
                        GAKIFF_FREI3 &
                        GAKIFF_FREI4 &
                        GAKIFF_FREI5 &
                        GAKIFF_LOEKZ &
                        GAKIFF_IFNAM &
                        GAKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GAKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.GAKIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.GAKIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "GAKIAF_MDANT|GAKIAF_GARFN|GAKIAF_FILNR|GAKIAF_GARTG|GAKIAF_GARTI|GAKIAF_HBKZN|GAKIAF_DXVND|GAKIAF_DXBSD|GAKIAF_GABTR|GAKIAF_DXGBT|GAKIAF_APRVA|GAKIAF_ATOPV|GAKIAF_APROV|GAKIAF_DXPRO|GAKIAF_APVAP|GAKIAF_VWTER|GAKIAF_WHISO|GAKIAF_GSPRZ|GAKIAF_MODUL|GAKIAF_KDREA|GAKIAF_SICGA|GAKIAF_KTONR|GAKIAF_GSREF|GAKIAF_DEPNR|GAKIAF_KZBVK|GAKIAF_BEBTR|GAKIAF_WHBEB|GAKIAF_DXBWE|GAKIAF_VEBTR|GAKIAF_WHVEB|GAKIAF_DXVWE|GAKIAF_VORBT|GAKIAF_WHVOR|GAKIAF_OLDSL|GAKIAF_PLZNR|GAKIAF_SIGAR|GAKIAF_KRRFN|GAKIAF_HCMPV|GAKIAF_HCWHG|GAKIAF_LIQUD|GAKIAF_RSKFZ|GAKIAF_RGWKZ|GAKIAF_KZA14|GAKIAF_KZABI|GAKIAF_KZAFI|GAKIAF_KZAAC|GAKIAF_KZAAE|GAKIAF_KZALE|GAKIAF_KZACR|GAKIAF_KZAPB|GAKIAF_KZSUB|GAKIAF_KZZWB|GAKIAF_KZECA|GAKIAF_LFDGS|GAKIAF_FREI1|GAKIAF_FREI2|GAKIAF_FREI3|GAKIAF_FREI4|GAKIAF_FREI5|GAKIAF_LOEKZ|GAKIAF_IFNAM|GAKIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "GAGIAF_MDANT" &
            "|GAGIAF_GARFN" &
            "|GAGIAF_MODUL" &
            "|GAGIAF_KDREA" &
            "|GAGIAF_GKRKT" &
            "|GAGIAF_GSREF" &
            "|GAGIAF_GLFDN" &
            "|GAGIAF_GSPRZ" &
            "|GAGIAF_SIMAX" &
            "|GAGIAF_SIMWH" &
            "|GAGIAF_SBLGD" &
            "|GAGIAF_GSBLG" &
            "|GAGIAF_WHSBL" &
            "|GAGIAF_HCKRA" &
            "|GAGIAF_KZSUB" &
            "|GAGIAF_KZZWB" &
            "|GAGIAF_FREI1" &
            "|GAGIAF_FREI2" &
            "|GAGIAF_FREI3" &
            "|GAGIAF_LOEKZ" &
            "|GAGIAF_IFNAM" &
            "|GAGIAF_DXIFD"

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
        Dim GAGIFF_SBLGD As String = Nothing 'New 1.35
        Dim GAGIFF_GSBLG As String = Nothing 'New 1.35
        Dim GAGIFF_WHSBL As String = Nothing 'New 1.35
        Dim GAGIFF_HCKRA As String = Nothing
        Dim GAGIFF_KZSUB As String = Nothing
        Dim GAGIFF_KZZWB As String = Nothing
        Dim GAGIFF_FREI1 As String = Nothing
        Dim GAGIFF_FREI2 As String = Nothing
        Dim GAGIFF_FREI3 As String = Nothing
        Dim GAGIFF_LOEKZ As String = Nothing
        Dim GAGIFF_IFNAM As String = Nothing
        Dim GAGIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_GAGIFF] where [GAGIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GAGIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GAGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GAGIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "GAGIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GAGIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GAGIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_GAGIFF] where [GAGIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    GAGIFF_SBLGD = dt.Rows.Item(i).Item("GAGIFF_SBLGD").ToString.Replace(",", ".") & "|"
                    GAGIFF_GSBLG = dt.Rows.Item(i).Item("GAGIFF_GSBLG").ToString.Replace(",", ".") & "|"
                    GAGIFF_WHSBL = dt.Rows.Item(i).Item("GAGIFF_WHSBL") & "|"
                    GAGIFF_HCKRA = dt.Rows.Item(i).Item("GAGIFF_HCKRA") & "|"
                    GAGIFF_KZSUB = dt.Rows.Item(i).Item("GAGIFF_KZSUB") & "|"
                    GAGIFF_KZZWB = dt.Rows.Item(i).Item("GAGIFF_KZZWB") & "|"
                    GAGIFF_FREI1 = dt.Rows.Item(i).Item("GAGIFF_FREI1") & "|"
                    GAGIFF_FREI2 = dt.Rows.Item(i).Item("GAGIFF_FREI2") & "|"
                    GAGIFF_FREI3 = dt.Rows.Item(i).Item("GAGIFF_FREI3") & "|"
                    GAGIFF_LOEKZ = dt.Rows.Item(i).Item("GAGIFF_LOEKZ") & "|"
                    GAGIFF_IFNAM = "GAGIAF" & "|"
                    GAGIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GAGIFF_DXIFD"))


                    CSV_ROW =
                        GAGIFF_MDANT &
                        GAGIFF_GARFN &
                        GAGIFF_MODUL &
                        GAGIFF_KDREA &
                        GAGIFF_GKRKT &
                        GAGIFF_GSREF &
                        GAGIFF_GLFDN &
                        GAGIFF_GSPRZ &
                        GAGIFF_SIMAX &
                        GAGIFF_SIMWH &
                        GAGIFF_SBLGD &
                        GAGIFF_GSBLG &
                        GAGIFF_WHSBL &
                        GAGIFF_HCKRA &
                        GAGIFF_KZSUB &
                        GAGIFF_KZZWB &
                        GAGIFF_FREI1 &
                        GAGIFF_FREI2 &
                        GAGIFF_FREI3 &
                        GAGIFF_LOEKZ &
                        GAGIFF_IFNAM &
                        GAGIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GAGIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.GAGIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.GAGIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "GAGIAF_MDANT|GAGIAF_GARFN|GAGIAF_MODUL|GAGIAF_KDREA|GAGIAF_GKRKT|GAGIAF_GSREF|GAGIAF_GLFDN|GAGIAF_GSPRZ|GAGIAF_SIMAX|GAGIAF_SIMWH|GAGIAF_HCKRA|GAGIAF_KZSUB|GAGIAF_KZZWB|GAGIAF_FREI1|GAGIAF_FREI2|GAGIAF_FREI3|GAGIAF_LOEKZ|GAGIAF_IFNAM|GAGIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "LQKIAF_MDANT" &
            "|LQKIAF_KDREA" &
            "|LQKIAF_LQSEK" &
            "|LQKIAF_OBBTG" &
            "|LQKIAF_KZGBZ" &
            "|LQKIAF_LQBRZ" &
            "|LQKIAF_IFNAM" &
            "|LQKIAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim LQKIFF_MDANT As String = Nothing
        Dim LQKIFF_KDREA As String = Nothing
        Dim LQKIFF_LQSEK As String = Nothing
        Dim LQKIFF_OBBTG As String = Nothing
        Dim LQKIFF_KZGBZ As String = Nothing
        Dim LQKIFF_LQBRZ As String = Nothing 'New 1.31
        Dim LQKIFF_IFNAM As String = Nothing
        Dim LQKIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count <> 0 Then

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_LQKIAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_LQKIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If



            Try
                BgwBaisFilesCreation.ReportProgress(2, "Generating File: LQKIAF_CCB.csv...Please wait...")


                If File.Exists(BaisFilesCreationPath & "LQKIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "LQKIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "LQKIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT * FROM  [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "' and [ID] in (Select Min([ID]) from [BAIS_LQKIFF] where [LQKIFF_DXIFD]='" & rdsql & "' GROUP BY [LQKIFF_KDNRH])"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    LQKIFF_MDANT = dt.Rows.Item(i).Item("LQKIFF_MDANT") & "|"
                    LQKIFF_KDREA = dt.Rows.Item(i).Item("LQKIFF_KDNRH") & "|"
                    LQKIFF_LQSEK = dt.Rows.Item(i).Item("LQKIFF_LQSEK") & "|"
                    LQKIFF_OBBTG = dt.Rows.Item(i).Item("LQKIFF_OBBTG") & "|"
                    LQKIFF_KZGBZ = dt.Rows.Item(i).Item("LQKIFF_KZGBZ") & "|"
                    LQKIFF_LQBRZ = dt.Rows.Item(i).Item("LQKIFF_LQBRZ") & "|"
                    LQKIFF_IFNAM = "LQKIAF" & "|"
                    LQKIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("LQKIFF_DXIFD"))


                    CSV_ROW =
                        LQKIFF_MDANT &
                        LQKIFF_KDREA &
                        LQKIFF_LQSEK &
                        LQKIFF_OBBTG &
                        LQKIFF_KZGBZ &
                        LQKIFF_LQBRZ &
                        LQKIFF_IFNAM &
                        LQKIFF_DXIFD
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "LQKIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next
                Me.LQKIFF_Result = "Created"
            Catch ex As Exception
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            CloseSqlConnections()
            Me.LQKIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "LQKIAF_MDANT|LQKIAF_KDREA|LQKIAF_LQSEK|LQKIAF_OBBTG|LQKIAF_KZGBZ|LQKIAF_LQBRZ|LQKIAF_IFNAM|LQKIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing
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
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "DESIAF_MDANT" &
            "|DESIAF_FILNR" &
            "|DESIAF_MODUL" &
            "|DESIAF_DEART" &
            "|DESIAF_GSREF" &
            "|DESIAF_KDREA" &
            "|DESIAF_GSKLA" &
            "|DESIAF_SUKLA" &
            "|DESIAF_KRART" &
            "|DESIAF_WHISO" &
            "|DESIAF_DXVND" &
            "|DESIAF_DXBSD" &
            "|DESIAF_DXVNU" &
            "|DESIAF_DXBSU" &
            "|DESIAF_ZWRIS" &
            "|DESIAF_ZINSS" &
            "|DESIAF_ZINS2" &
            "|DESIAF_KZZS1" &
            "|DESIAF_KZZS2" &
            "|DESIAF_VZIN1" &
            "|DESIAF_VZIN2" &
            "|DESIAF_KZKON" &
            "|DESIAF_KZBAN" &
            "|DESIAF_EBTRG" &
            "|DESIAF_GBTRG" &
            "|DESIAF_GWISO" &
            "|DESIAF_HBKZN" &
            "|DESIAF_KZOTC" &
            "|DESIAF_KBTRG" &
            "|DESIAF_PTEIN" &
            "|DESIAF_WHGKP" &
            "|DESIAF_BCHSW" &
            "|DESIAF_BWVNS" &
            "|DESIAF_ABGBT" &
            "|DESIAF_GABGB" &
            "|DESIAF_WHGBU" &
            "|DESIAF_URDEA" &
            "|DESIAF_NETKR" &
            "|DESIAF_KZCVA" &
            "|DESIAF_GSARE" &
            "|DESIAF_FAIRV" &
            "|DESIAF_WHGFV" &
            "|DESIAF_DXVKT" &
            "|DESIAF_HFZGP" &
            "|DESIAF_KZZGP" &
            "|DESIAF_KZSEG" &
            "|DESIAF_AFREF" &
            "|DESIAF_POOLI" &
            "|DESIAF_AEIDF" &
            "|DESIAF_BESVB" &
            "|DESIAF_GEBAB" &
            "|DESIAF_WHGGA" &
            "|DESIAF_DRKNZ" &
            "|DESIAF_MARAG" &
            "|DESIAF_DXNVB" &
            "|DESIAF_RESE1" &
            "|DESIAF_RESE2" &
            "|DESIAF_FREI1" &
            "|DESIAF_FREI2" &
            "|DESIAF_FREI3" &
            "|DESIAF_LOEKZ" &
            "|DESIAF_IFNAM" &
            "|DESIAF_DXIFD"

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
        Dim DESIFF_WHGFV As String = Nothing 'New Version 1.27
        Dim DESIFF_DXVKT As String = Nothing
        Dim DESIFF_HFZGP As String = Nothing
        Dim DESIFF_KZZGP As String = Nothing 'New 1.31
        Dim DESIFF_KZSEG As String = Nothing 'New 1.31
        Dim DESIFF_AFREF As String = Nothing
        Dim DESIFF_POOLI As String = Nothing
        Dim DESIFF_AEIDF As String = Nothing
        Dim DESIFF_BESVB As String = Nothing
        Dim DESIFF_GEBAB As String = Nothing ' New Version 1.29
        Dim DESIFF_WHGGA As String = Nothing ' New Version 1.29
        Dim DESIFF_DRKNZ As String = Nothing 'New 1.30
        Dim DESIFF_MARAG As String = Nothing 'New 1.30
        Dim DESIFF_DXNVB As String = Nothing 'New 1.30
        Dim DESIFF_RESE1 As String = Nothing
        Dim DESIFF_RESE2 As String = Nothing
        Dim DESIFF_FREI1 As String = Nothing
        Dim DESIFF_FREI2 As String = Nothing
        Dim DESIFF_FREI3 As String = Nothing
        Dim DESIFF_LOEKZ As String = Nothing
        Dim DESIFF_IFNAM As String = Nothing
        Dim DESIFF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then
            Try
                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_DESIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_DESIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: DESIAF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "DESIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "DESIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_DESIFF] where [DESIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                    DESIFF_WHGFV = dt.Rows.Item(i).Item("DESIFF_WHGFV") & "|" 'New Version 1.27
                    DESIFF_DXVKT = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXVKT")) & "|"
                    DESIFF_HFZGP = dt.Rows.Item(i).Item("DESIFF_HFZGP") & "|"
                    DESIFF_KZZGP = dt.Rows.Item(i).Item("DESIFF_KZZGP") & "|"
                    DESIFF_KZSEG = dt.Rows.Item(i).Item("DESIFF_KZSEG") & "|"
                    DESIFF_AFREF = dt.Rows.Item(i).Item("DESIFF_AFREF") & "|"
                    DESIFF_POOLI = dt.Rows.Item(i).Item("DESIFF_POOLI") & "|"
                    DESIFF_AEIDF = dt.Rows.Item(i).Item("DESIFF_AEIDF") & "|"
                    DESIFF_BESVB = dt.Rows.Item(i).Item("DESIFF_BESVB") & "|"
                    DESIFF_GEBAB = dt.Rows.Item(i).Item("DESIFF_GEBAB").ToString.Replace(",", ".") & "|"
                    DESIFF_WHGGA = dt.Rows.Item(i).Item("DESIFF_WHGGA") & "|"
                    DESIFF_DRKNZ = dt.Rows.Item(i).Item("DESIFF_DRKNZ") & "|"
                    DESIFF_MARAG = dt.Rows.Item(i).Item("DESIFF_MARAG") & "|"
                    If IsDBNull(dt.Rows.Item(i).Item("DESIFF_DXNVB")) = False Then
                        Dim DXNVB_Date As Date = dt.Rows.Item(i).Item("DESIFF_DXNVB")
                        DESIFF_DXNVB = DXNVB_Date.ToString("yyyyMMdd") & "|"
                    Else
                        DESIFF_DXNVB = "0" & "|"
                    End If
                    DESIFF_RESE1 = dt.Rows.Item(i).Item("DESIFF_RESE1") & "|"
                    DESIFF_RESE2 = dt.Rows.Item(i).Item("DESIFF_RESE2") & "|"
                    DESIFF_FREI1 = dt.Rows.Item(i).Item("DESIFF_FREI1") & "|"
                    DESIFF_FREI2 = dt.Rows.Item(i).Item("DESIFF_FREI2") & "|"
                    DESIFF_FREI3 = dt.Rows.Item(i).Item("DESIFF_FREI3") & "|"
                    DESIFF_LOEKZ = dt.Rows.Item(i).Item("DESIFF_LOEKZ") & "|"
                    DESIFF_IFNAM = "DESIAF" & "|"
                    DESIFF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("DESIFF_DXIFD"))

                    CSV_ROW =
                        DESIFF_MDANT &
                        DESIFF_FILNR &
                        DESIFF_MODUL &
                        DESIFF_DEART &
                        DESIFF_GSREF &
                        DESIFF_KDREA &
                        DESIFF_GSKLA &
                        DESIFF_SUKLA &
                        DESIFF_KRART &
                        DESIFF_WHISO &
                        DESIFF_DXVND &
                        DESIFF_DXBSD &
                        DESIFF_DXVNU &
                        DESIFF_DXBSU &
                        DESIFF_ZWRIS &
                        DESIFF_ZINSS &
                        DESIFF_ZINS2 &
                        DESIFF_KZZS1 &
                        DESIFF_KZZS2 &
                        DESIFF_VZIN1 &
                        DESIFF_VZIN2 &
                        DESIFF_KZKON &
                        DESIFF_KZBAN &
                        DESIFF_EBTRG &
                        DESIFF_GBTRG &
                        DESIFF_GWISO &
                        DESIFF_HBKZN &
                        DESIFF_KZOTC &
                        DESIFF_KBTRG &
                        DESIFF_PTEIN &
                        DESIFF_WHGKP &
                        DESIFF_BCHSW &
                        DESIFF_BWVNS &
                        DESIFF_ABGBT &
                        DESIFF_GABGB &
                        DESIFF_WHGBU &
                        DESIFF_URDEA &
                        DESIFF_NETKR &
                        DESIFF_KZCVA &
                        DESIFF_GSARE &
                        DESIFF_FAIRV &
                        DESIFF_WHGFV &
                        DESIFF_DXVKT &
                        DESIFF_HFZGP &
                        DESIFF_KZZGP &
                        DESIFF_KZSEG &
                        DESIFF_AFREF &
                        DESIFF_POOLI &
                        DESIFF_AEIDF &
                        DESIFF_BESVB &
                        DESIFF_GEBAB &
                        DESIFF_WHGGA &
                        DESIFF_DRKNZ &
                        DESIFF_MARAG &
                        DESIFF_DXNVB &
                        DESIFF_RESE1 &
                        DESIFF_RESE2 &
                        DESIFF_FREI1 &
                        DESIFF_FREI2 &
                        DESIFF_FREI3 &
                        DESIFF_LOEKZ &
                        DESIFF_IFNAM &
                        DESIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_ROW & vbCrLf)
                Next

                'cmd.CommandText = "DROP TABLE [DVTIFF_CCB]"
                'cmd.ExecuteNonQuery()

                CloseSqlConnections()
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.DESIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.DESIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "DESIAF_MDANT|DESIAF_FILNR|DESIAF_MODUL|DESIAF_DEART|DESIAF_GSREF|DESIAF_KDREA|DESIAF_GSKLA|DESIAF_SUKLA|DESIAF_KRART|DESIAF_WHISO|DESIAF_DXVND|DESIAF_DXBSD|DESIAF_DXVNU|DESIAF_DXBSU|DESIAF_ZWRIS|DESIAF_ZINSS|DESIAF_ZINS2|DESIAF_KZZS1|DESIAF_KZZS2|DESIAF_VZIN1|DESIAF_VZIN2|DESIAF_KZKON|DESIAF_KZBAN|DESIAF_EBTRG|DESIAF_GBTRG|DESIAF_GWISO|DESIAF_HBKZN|DESIAF_KZOTC|DESIAF_KBTRG|DESIAF_PTEIN|DESIAF_WHGKP|DESIAF_BCHSW|DESIAF_BWVNS|DESIAF_ABGBT|DESIAF_GABGB|DESIAF_WHGBU|DESIAF_URDEA|DESIAF_NETKR|DESIAF_KZCVA|DESIAF_GSARE|DESIAF_FAIRV|DESIAF_WHGFV|DESIAF_DXVKT|DESIAF_HFZGP|DESIAF_KZZGP|DESIAF_KZSEG|DESIAF_AFREF|DESIAF_POOLI|DESIAF_AEIDF|DESIAF_BESVB|DESIAF_GEBAB|DESIAF_WHGGA|DESIAF_DRKNZ|DESIAF_MARAG|DESIAF_DXNVB|DESIAF_RESE1|DESIAF_RESE2|DESIAF_FREI1|DESIAF_FREI2|DESIAF_FREI3|DESIAF_LOEKZ|DESIAF_IFNAM|DESIAF_DXIFD"
            'Dim CSV_ROW As String = Nothing

            If File.Exists(BaisFilesCreationPath & "DESIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "DESIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "DESIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File DESIAF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please update CREDIT RISK Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        CloseSqlConnections()
    End Sub 'OK

    Private Sub WHGIFF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "WHGIFF_MDANT" &
            "|WHGIFF_WHISO" &
            "|WHGIFF_WNAME" &
            "|WHGIFF_WSLZB" &
            "|WHGIFF_WEINH" &
            "|WHGIFF_WKLEH" &
            "|WHGIFF_WNKST" &
            "|WHGIFF_WSTAT" &
            "|WHGIFF_MKURS" &
            "|WHGIFF_DXEGK" &
            "|WHGIFF_IFNAM" &
            "|WHGIFF_DXIFD"

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

        cmd.CommandText = "Select Count([ID]) from [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count > 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_WHGIFF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_WHGIFF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: WHGIFF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "WHGIFF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "WHGIFF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_WHGIFF] where [WHGIFF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                    CSV_ROW =
                        WHGIFF_MDANT &
                        WHGIFF_WHISO &
                        WHGIFF_WNAME &
                        WHGIFF_WSLZB &
                        WHGIFF_WEINH &
                        WHGIFF_WKLEH &
                        WHGIFF_WNKST &
                        WHGIFF_WSTAT &
                        WHGIFF_MKURS &
                        WHGIFF_DXEGK &
                        WHGIFF_IFNAM &
                        WHGIFF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_ROW & vbCrLf)
                Next



                CloseSqlConnections()
                'SplashScreenManager.CloseForm(False)
                'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.WHGIFF_Result = "Created"

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.WHGIFF_Result = "Not Created"
            'Dim CSV_HEADER As String = "WHGIFF_MDANT|WHGIFF_WHISO|WHGIFF_WNAME|WHGIFF_WSLZB|WHGIFF_WEINH|WHGIFF_WKLEH|WHGIFF_WNKST|WHGIFF_WSTAT|WHGIFF_MKURS|WHGIFF_DXEGK|WHGIFF_IFNAM|WHGIFF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "WHGIFF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "WHGIFF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "WHGIFF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File WHGIFF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:EXCHANGE RATES OCBS for this Date" & vbNewLine & " Please update EXCHANGE RATES OCBS Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        CloseSqlConnections()

    End Sub

    Private Sub GSVGAF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "GSVGAF_MDANT" &
            "|GSVGAF_MODUL" &
            "|GSVGAF_KDREA" &
            "|GSVGAF_KTONR" &
            "|GSVGAF_GSREF" &
            "|GSVGAF_VGLFN" &
            "|GSVGAF_VGMOD" &
            "|GSVGAF_VGKDA" &
            "|GSVGAF_VGKTO" &
            "|GSVGAF_VGREF" &
            "|GSVGAF_SLDAV" &
            "|GSVGAF_AKTYP" &
            "|GSVGAF_RSCD1" &
            "|GSVGAF_RSCD2" &
            "|GSVGAF_RSTX1" &
            "|GSVGAF_RSTX2" &
            "|GSVGAF_RSDX1" &
            "|GSVGAF_RSPR1" &
            "|GSVGAF_RSBT1" &
            "|GSVGAF_IFNAM" &
            "|GSVGAF_DXIFD"

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

        Try

            BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSVGAF File for: " & rd)
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
            ParameterStatus = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSVGAF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSVGAF_CCB.csv .... Please wait...")



            If File.Exists(BaisFilesCreationPath & "GSVGAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSVGAF_CCB.csv")
            End If

            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSVGAF_CCB.csv", CSV_HEADER & vbCrLf)

            QueryText = "SELECT  * FROM  [BAIS_GSVGAF] where [GSVGAF_DXIFD]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
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

                    CSV_ROW =
                        GSVGAF_MDANT &
                        GSVGAF_MODUL &
                        GSVGAF_KDREA &
                        GSVGAF_KTONR &
                        GSVGAF_GSREF &
                        GSVGAF_VGLFN &
                        GSVGAF_VGMOD &
                        GSVGAF_VGKDA &
                        GSVGAF_VGKTO &
                        GSVGAF_VGREF &
                        GSVGAF_SLDAV &
                        GSVGAF_AKTYP &
                        GSVGAF_RSCD1 &
                        GSVGAF_RSCD2 &
                        GSVGAF_RSTX1 &
                        GSVGAF_RSTX2 &
                        GSVGAF_RSDX1 &
                        GSVGAF_RSPR1 &
                        GSVGAF_RSBT1 &
                        GSVGAF_IFNAM &
                        GSVGAF_DXIFD

                    System.IO.File.AppendAllText(BaisFilesCreationPath & "GSVGAF_CCB.csv", CSV_ROW & vbCrLf)
                Next


                CloseSqlConnections()

                Me.GSVGAF_Result = "Created"
            Else
                CloseSqlConnections()
                Me.GSVGAF_Result = "Not Created"

                XtraMessageBox.Show("Unable to create File GSVGAF_CCB.csv for " & rd & vbNewLine & "There are no Data in the Table:GSVGAF for this Date" & vbNewLine & " Please check", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As System.Exception

            CloseSqlConnections()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        CloseSqlConnections()
    End Sub 'OK

    Private Sub GSWBIF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
            "GSWAIF_MDANT" &
            "|GSWAIF_MODUL" &
            "|GSWAIF_KDREA" &
            "|GSWAIF_KTONR" &
            "|GSWAIF_GSREF" &
            "|GSWAIF_PWBBT" &
            "|GSWAIF_PWBWH" &
            "|GSWAIF_EWBBT" &
            "|GSWAIF_EWBWH" &
            "|GSWAIF_EWBBP" &
            "|GSWAIF_EWBWP" &
            "|GSWAIF_ABSBT" &
            "|GSWAIF_ABSWH" &
            "|GSWAIF_PBABS" &
            "|GSWAIF_ABTYP" &
            "|GSWAIF_EWBBS" &
            "|GSWAIF_EWBWS" &
            "|GSWAIF_PWBBS" &
            "|GSWAIF_PWBWS" &
            "|GSWAIF_EWBLR" &
            "|GSWAIF_EWBWL" &
            "|GSWAIF_ZWBB1" &
            "|GSWAIF_ZB1WH" &
            "|GSWAIF_ZWBB2" &
            "|GSWAIF_ZB2WH" &
            "|GSWAIF_STIRE" &
            "|GSWAIF_STIRF" &
            "|GSWAIF_R340G" &
            "|GSWAIF_R340F" &
            "|GSWAIF_STIWH" &
            "|GSWAIF_RSTBT" &
            "|GSWAIF_RSTWH" &
            "|GSWAIF_PBZWB" &
            "|GSWAIF_PBZWH" &
            "|GSWAIF_HDGAD" &
            "|GSWAIF_HGDWH" &
            "|GSWAIF_IFNAM" &
            "|GSWAIF_DXIFD"

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
        Dim GSWBIF_PBABS As String = Nothing 'New 1.33
        Dim GSWBIF_ABTYP As String = Nothing
        Dim GSWBIF_EWBBS As String = Nothing
        Dim GSWBIF_EWBWS As String = Nothing
        Dim GSWBIF_PWBBS As String = Nothing
        Dim GSWBIF_PWBWS As String = Nothing
        Dim GSWBIF_EWBLR As String = Nothing
        Dim GSWBIF_EWBWL As String = Nothing
        Dim GSWBIF_ZWBB1 As String = Nothing 'New 1.33
        Dim GSWBIF_ZB1WH As String = Nothing 'New 1.33
        Dim GSWBIF_ZWBB2 As String = Nothing 'New 1.33
        Dim GSWBIF_ZB2WH As String = Nothing 'New 1.33
        Dim GSWBIF_STIRE As String = Nothing
        Dim GSWBIF_STIRF As String = Nothing 'New 1.31
        Dim GSWBIF_R340G As String = Nothing
        Dim GSWBIF_R340F As String = Nothing 'New 1.31
        Dim GSWBIF_STIWH As String = Nothing
        Dim GSWBIF_RSTBT As String = Nothing
        Dim GSWBIF_RSTWH As String = Nothing
        Dim GSWBIF_PBZWB As String = Nothing 'New 1.31
        Dim GSWBIF_PBZWH As String = Nothing 'New 1.31
        Dim GSWBIF_HDGAD As String = Nothing 'New 1.31
        Dim GSWBIF_HGDWH As String = Nothing 'New 1.31
        Dim GSWBIF_IFNAM As String = Nothing
        Dim GSWBIF_DXIFD As String = Nothing

        cmd.CommandText = "Select Count([ID]) from [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        Dim Count As Double = cmd.ExecuteScalar


        If Count > 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_GSWAIF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_GSWBIF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: GSWAIF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "GSWAIF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "GSWAIF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_GSWBIF] where [GSWBIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
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
                        GSWBIF_PBABS = dt.Rows.Item(i).Item("GSWBIF_PBABS").ToString.Replace(",", ".") & "|"
                        GSWBIF_ABTYP = dt.Rows.Item(i).Item("GSWBIF_ABTYP") & "|"
                        GSWBIF_EWBBS = dt.Rows.Item(i).Item("GSWBIF_EWBBS").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWS = dt.Rows.Item(i).Item("GSWBIF_EWBWS") & "|"
                        GSWBIF_PWBBS = dt.Rows.Item(i).Item("GSWBIF_PWBBS").ToString.Replace(",", ".") & "|"
                        GSWBIF_PWBWS = dt.Rows.Item(i).Item("GSWBIF_PWBWS") & "|"
                        GSWBIF_EWBLR = dt.Rows.Item(i).Item("GSWBIF_EWBLR").ToString.Replace(",", ".") & "|"
                        GSWBIF_EWBWL = dt.Rows.Item(i).Item("GSWBIF_EWBWL") & "|"
                        GSWBIF_ZWBB1 = dt.Rows.Item(i).Item("GSWBIF_ZWBB1").ToString.Replace(",", ".") & "|"
                        GSWBIF_ZB1WH = dt.Rows.Item(i).Item("GSWBIF_ZB1WH") & "|"
                        GSWBIF_ZWBB2 = dt.Rows.Item(i).Item("GSWBIF_ZWBB2").ToString.Replace(",", ".") & "|"
                        GSWBIF_ZB2WH = dt.Rows.Item(i).Item("GSWBIF_ZB2WH") & "|"
                        GSWBIF_STIRE = dt.Rows.Item(i).Item("GSWBIF_STIRE").ToString.Replace(",", ".") & "|"
                        GSWBIF_STIRF = dt.Rows.Item(i).Item("GSWBIF_STIRF").ToString.Replace(",", ".") & "|" 'New 1.31
                        GSWBIF_R340G = dt.Rows.Item(i).Item("GSWBIF_R340G").ToString.Replace(",", ".") & "|"
                        GSWBIF_R340F = dt.Rows.Item(i).Item("GSWBIF_R340F").ToString.Replace(",", ".") & "|" 'New 1.31
                        GSWBIF_STIWH = dt.Rows.Item(i).Item("GSWBIF_STIWH") & "|"
                        GSWBIF_RSTBT = dt.Rows.Item(i).Item("GSWBIF_RSTBT").ToString.Replace(",", ".") & "|"
                        GSWBIF_RSTWH = dt.Rows.Item(i).Item("GSWBIF_RSTWH") & "|"
                        GSWBIF_PBZWB = dt.Rows.Item(i).Item("GSWBIF_PBZWB").ToString.Replace(",", ".") & "|" 'New 1.31
                        GSWBIF_PBZWH = dt.Rows.Item(i).Item("GSWBIF_PBZWH") & "|" 'New 1.31
                        GSWBIF_HDGAD = dt.Rows.Item(i).Item("GSWBIF_HDGAD").ToString.Replace(",", ".") & "|" 'New 1.31
                        GSWBIF_HGDWH = dt.Rows.Item(i).Item("GSWBIF_HGDWH") & "|" 'New 1.31
                        GSWBIF_IFNAM = dt.Rows.Item(i).Item("GSWBIF_IFNAM") & "|"
                        GSWBIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("GSWBIF_DXIFD"))

                        CSV_ROW =
                            GSWBIF_MDANT &
                            GSWBIF_MODUL &
                            GSWBIF_KDNRH &
                            GSWBIF_KTONR &
                            GSWBIF_GSREF &
                            GSWBIF_PWBBT &
                            GSWBIF_PWBWH &
                            GSWBIF_EWBBT &
                            GSWBIF_EWBWH &
                            GSWBIF_EWBBP &
                            GSWBIF_EWBWP &
                            GSWBIF_ABSBT &
                            GSWBIF_ABSWH &
                            GSWBIF_PBABS &
                            GSWBIF_ABTYP &
                            GSWBIF_EWBBS &
                            GSWBIF_EWBWS &
                            GSWBIF_PWBBS &
                            GSWBIF_PWBWS &
                            GSWBIF_EWBLR &
                            GSWBIF_EWBWL &
                            GSWBIF_ZWBB1 &
                            GSWBIF_ZB1WH &
                            GSWBIF_ZWBB2 &
                            GSWBIF_ZB2WH &
                            GSWBIF_STIRE &
                            GSWBIF_STIRF &
                            GSWBIF_R340G &
                            GSWBIF_R340F &
                            GSWBIF_STIWH &
                            GSWBIF_RSTBT &
                            GSWBIF_RSTWH &
                            GSWBIF_PBZWB &
                            GSWBIF_PBZWH &
                            GSWBIF_HDGAD &
                            GSWBIF_HGDWH &
                            GSWBIF_IFNAM &
                            GSWBIF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_ROW & vbCrLf)
                    Next



                    CloseSqlConnections()
                    'SplashScreenManager.CloseForm(False)
                    'XtraMessageBox.Show("The following File has being created C:\DVTIFF_CCB.csv with data from " & rd, "FILE CREATION RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.GSWBIF_Result = "Created"
                Else
                    CloseSqlConnections()
                    Me.GSWBIF_Result = "Not Created"
                    XtraMessageBox.Show("Unable to create File GSWAIF_CCB.csv for " & rd & vbNewLine & "There are no relevant Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.GSWBIF_Result = "Not Created"
            'Dim CSV_HEADER As String = "GSWAIF_MDANT|GSWAIF_MODUL|GSWAIF_KDREA|GSWAIF_KTONR|GSWAIF_GSREF|GSWAIF_PWBBT|GSWAIF_PWBWH|GSWAIF_EWBBT|GSWAIF_EWBWH|GSWAIF_EWBBP|GSWAIF_EWBWP|GSWAIF_ABSBT|GSWAIF_ABSWH|GSWAIF_ABTYP|GSWAIF_EWBBS|GSWAIF_EWBWS|GSWAIF_PWBBS|GSWAIF_PWBWS|GSWAIF_EWBLR|GSWAIF_EWBWL|GSWAIF_STIRE|GSWAIF_STIRF|GSWAIF_R340G|GSWAIF_R340F|GSWAIF_STIWH|GSWAIF_RSTBT|GSWAIF_RSTWH|GSWAIF_PBZWB|GSWAIF_PBZWH|GSWAIF_HDGAD|GSWAIF_HGDWH|GSWAIF_IFNAM|GSWAIF_DXIFD"
            'Dim CSV_ROW As String = Nothing
            If File.Exists(BaisFilesCreationPath & "GSWAIF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "GSWAIF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "GSWAIF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File GSWAIF_CCB.csv for " & rd & vbNewLine & "There are no relevant Data in the Table:CREDIT RISK for this Date" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        CloseSqlConnections()
    End Sub 'OK

    Private Sub SCNTIF_CREATION()
        OpenSqlConnections()

        'New Code
        Dim CSV_HEADER As String =
             "SCNIAF_MDANT" &
            "|SCNIAF_KDREA" &
            "|SCNIAF_MODUL" &
            "|SCNIAF_IDNGR" &
            "|SCNIAF_MARAG" &
            "|SCNIAF_NICMP" &
            "|SCNIAF_NICMR" &
            "|SCNIAF_NICUP" &
            "|SCNIAF_NICUR" &
            "|SCNIAF_ISCCP" &
            "|SCNIAF_AFREF" &
            "|SCNIAF_AEIDF" &
            "|SCNIAF_HFZGP" &
            "|SCNIAF_GSARE" &
            "|SCNIAF_KZZGP" &
            "|SCNIAF_KZCVA" &
            "|SCNIAF_KZOTC" &
            "|SCNIAF_WHSET" &
            "|SCNIAF_FREI1" &
            "|SCNIAF_FREI2" &
            "|SCNIAF_FREI3" &
            "|SCNIAF_EX1TY" &
            "|SCNIAF_EX1WE" &
            "|SCNIAF_EX2TY" &
            "|SCNIAF_EX2WE" &
            "|SCNIAF_EX3TY" &
            "|SCNIAF_EX3WE" &
            "|SCNIAF_EX4TY" &
            "|SCNIAF_EX4WE" &
            "|SCNIAF_IFNAM" &
            "|SCNIAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim SCNTIF_MDANT As String = Nothing
        Dim SCNTIF_KDNRH As String = Nothing
        Dim SCNTIF_MODUL As String = Nothing
        Dim SCNTIF_IDNGR As String = Nothing
        Dim SCNTIF_MARAG As String = Nothing
        Dim SCNTIF_NICMP As String = Nothing
        Dim SCNTIF_NICMR As String = Nothing
        Dim SCNTIF_NICUP As String = Nothing
        Dim SCNTIF_NICUR As String = Nothing
        Dim SCNTIF_ISCCP As String = Nothing
        Dim SCNTIF_AFREF As String = Nothing
        Dim SCNTIF_AEIDF As String = Nothing
        Dim SCNTIF_HFZGP As String = Nothing
        Dim SCNTIF_GSARE As String = Nothing
        Dim SCNTIF_KZZGP As String = Nothing
        Dim SCNTIF_KZCVA As String = Nothing
        Dim SCNTIF_KZOTC As String = Nothing
        Dim SCNTIF_WHSET As String = Nothing
        Dim SCNTIF_FREI1 As String = Nothing
        Dim SCNTIF_FREI2 As String = Nothing
        Dim SCNTIF_FREI3 As String = Nothing
        Dim SCNTIF_EX1TY As String = Nothing
        Dim SCNTIF_EX1WE As String = Nothing
        Dim SCNTIF_EX2TY As String = Nothing
        Dim SCNTIF_EX2WE As String = Nothing
        Dim SCNTIF_EX3TY As String = Nothing
        Dim SCNTIF_EX3WE As String = Nothing
        Dim SCNTIF_EX4TY As String = Nothing
        Dim SCNTIF_EX4WE As String = Nothing
        Dim SCNTIF_IFNAM As String = Nothing
        Dim SCNTIF_DXIFD As String = Nothing

        'Check if related transactions are loaded in BAIS Tables:BAIS_DESIFF and/or BAIS_DVTIFF
        cmd.CommandText = "Select Sum(A.CountTransactions) from 
                           (Select Count(ID) as CountTransactions from [BAIS_DESIFF] where [DESIFF_DXIFD]='" & rdsql & "'
                           UNION ALL
                           Select Count(ID) as CountTransactions from [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "')A"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating SCNTIF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_SCNTIF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: SCNTIF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "SCNIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "SCNIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "SCNIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_SCNTIF] where [SCNTIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1

                        SCNTIF_MDANT = dt.Rows.Item(i).Item("SCNTIF_MDANT") & "|"
                        SCNTIF_KDNRH = dt.Rows.Item(i).Item("SCNTIF_EX1WE") & "|" 'special treatment for Alpha Interface
                        SCNTIF_MODUL = dt.Rows.Item(i).Item("SCNTIF_MODUL") & "|"
                        SCNTIF_IDNGR = dt.Rows.Item(i).Item("SCNTIF_IDNGR") & "|"
                        SCNTIF_MARAG = dt.Rows.Item(i).Item("SCNTIF_MARAG") & "|"
                        SCNTIF_NICMP = dt.Rows.Item(i).Item("SCNTIF_NICMP").ToString.Replace(",", ".") & "|"
                        SCNTIF_NICMR = dt.Rows.Item(i).Item("SCNTIF_NICMR").ToString.Replace(",", ".") & "|"
                        SCNTIF_NICUP = dt.Rows.Item(i).Item("SCNTIF_NICUP").ToString.Replace(",", ".") & "|"
                        SCNTIF_NICUR = dt.Rows.Item(i).Item("SCNTIF_NICUR").ToString.Replace(",", ".") & "|"
                        SCNTIF_ISCCP = dt.Rows.Item(i).Item("SCNTIF_ISCCP") & "|"
                        SCNTIF_AFREF = dt.Rows.Item(i).Item("SCNTIF_AFREF") & "|"
                        SCNTIF_AEIDF = dt.Rows.Item(i).Item("SCNTIF_AEIDF") & "|"
                        SCNTIF_HFZGP = dt.Rows.Item(i).Item("SCNTIF_HFZGP") & "|"
                        SCNTIF_GSARE = dt.Rows.Item(i).Item("SCNTIF_GSARE") & "|"
                        SCNTIF_KZZGP = dt.Rows.Item(i).Item("SCNTIF_KZZGP") & "|"
                        SCNTIF_KZCVA = dt.Rows.Item(i).Item("SCNTIF_KZCVA") & "|"
                        SCNTIF_KZOTC = dt.Rows.Item(i).Item("SCNTIF_KZOTC") & "|"
                        SCNTIF_WHSET = dt.Rows.Item(i).Item("SCNTIF_WHSET") & "|"
                        SCNTIF_FREI1 = dt.Rows.Item(i).Item("SCNTIF_FREI1") & "|"
                        SCNTIF_FREI2 = dt.Rows.Item(i).Item("SCNTIF_FREI2") & "|"
                        SCNTIF_FREI3 = dt.Rows.Item(i).Item("SCNTIF_FREI3") & "|"
                        SCNTIF_EX1TY = dt.Rows.Item(i).Item("SCNTIF_EX1TY") & "|"
                        SCNTIF_EX1WE = dt.Rows.Item(i).Item("SCNTIF_KDNRH") & "|"  'special treatment for Alpha Interface
                        SCNTIF_EX2TY = dt.Rows.Item(i).Item("SCNTIF_EX2TY") & "|"
                        SCNTIF_EX2WE = dt.Rows.Item(i).Item("SCNTIF_EX2WE") & "|"
                        SCNTIF_EX3TY = dt.Rows.Item(i).Item("SCNTIF_EX3TY") & "|"
                        SCNTIF_EX3WE = dt.Rows.Item(i).Item("SCNTIF_EX3WE") & "|"
                        SCNTIF_EX4TY = dt.Rows.Item(i).Item("SCNTIF_EX4TY") & "|"
                        SCNTIF_EX4WE = dt.Rows.Item(i).Item("SCNTIF_EX4WE") & "|"
                        SCNTIF_IFNAM = dt.Rows.Item(i).Item("SCNTIF_IFNAM") & "|"
                        SCNTIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("SCNTIF_DXIFD"))

                        CSV_ROW =
                             SCNTIF_MDANT &
                             SCNTIF_KDNRH &
                             SCNTIF_MODUL &
                             SCNTIF_IDNGR &
                             SCNTIF_MARAG &
                             SCNTIF_NICMP &
                             SCNTIF_NICMR &
                             SCNTIF_NICUP &
                             SCNTIF_NICUR &
                             SCNTIF_ISCCP &
                             SCNTIF_AFREF &
                             SCNTIF_AEIDF &
                             SCNTIF_HFZGP &
                             SCNTIF_GSARE &
                             SCNTIF_KZZGP &
                             SCNTIF_KZCVA &
                             SCNTIF_KZOTC &
                             SCNTIF_WHSET &
                             SCNTIF_FREI1 &
                             SCNTIF_FREI2 &
                             SCNTIF_FREI3 &
                             SCNTIF_EX1TY &
                             SCNTIF_EX1WE &
                             SCNTIF_EX2TY &
                             SCNTIF_EX2WE &
                             SCNTIF_EX3TY &
                             SCNTIF_EX3WE &
                             SCNTIF_EX4TY &
                             SCNTIF_EX4WE &
                             SCNTIF_IFNAM &
                             SCNTIF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "SCNIAF_CCB.csv", CSV_ROW & vbCrLf)
                    Next



                    CloseSqlConnections()

                    Me.SCNTIF_Result = "Created"
                Else
                    CloseSqlConnections()
                    Me.SCNTIF_Result = "Created"
                    If File.Exists(BaisFilesCreationPath & "SCNIAF_CCB.csv") = True Then
                        File.Delete(BaisFilesCreationPath & "SCNIAF_CCB.csv")
                    End If
                    'Create Header
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "SCNIAF_CCB.csv", CSV_HEADER & vbCrLf)
                    Exit Sub
                End If

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.SCNTIF_Result = "Not Created"
            If File.Exists(BaisFilesCreationPath & "SCNIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "SCNIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "SCNIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File SCNIAF_CCB.csv for " & rd & vbNewLine & "No related transactions are loaded in BAIS Tables:BAIS_DESIFF and/or BAIS_DVTIFF" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        CloseSqlConnections()
    End Sub

    Private Sub SCDRIF_CREATION()
        OpenSqlConnections()


        'New Code
        Dim CSV_HEADER As String =
            "SCDIAF_MDANT" &
            "|SCDIAF_MODUL" &
            "|SCDIAF_KDREA" &
            "|SCDIAF_GSREF" &
            "|SCDIAF_FILNR" &
            "|SCDIAF_TRDID" &
            "|SCDIAF_NTSET" &
            "|SCDIAF_MARAG" &
            "|SCDIAF_RSCAT" &
            "|SCDIAF_HSPRI" &
            "|SCDIAF_HSSEC" &
            "|SCDIAF_HSTYP" &
            "|SCDIAF_BUPRI" &
            "|SCDIAF_SVTYP" &
            "|SCDIAF_SUPFA" &
            "|SCDIAF_CMVAL" &
            "|SCDIAF_WHGMV" &
            "|SCDIAF_NOTNL" &
            "|SCDIAF_WHISO" &
            "|SCDIAF_NOMB2" &
            "|SCDIAF_WHIS2" &
            "|SCDIAF_FAIRV" &
            "|SCDIAF_WHGFV" &
            "|SCDIAF_MDATE" &
            "|SCDIAF_SDATE" &
            "|SCDIAF_EDATE" &
            "|SCDIAF_ODATE" &
            "|SCDIAF_DXVKT" &
            "|SCDIAF_DXNVB" &
            "|SCDIAF_MYEAR" &
            "|SCDIAF_SYEAR" &
            "|SCDIAF_EYEAR" &
            "|SCDIAF_OYEAR" &
            "|SCDIAF_TYEAR" &
            "|SCDIAF_RYEAR" &
            "|SCDIAF_BUSYD" &
            "|SCDIAF_INCAT" &
            "|SCDIAF_SIGND" &
            "|SCDIAF_TYPED" &
            "|SCDIAF_ULPRC" &
            "|SCDIAF_WHGUP" &
            "|SCDIAF_STRKE" &
            "|SCDIAF_WHGSP" &
            "|SCDIAF_ATTPT" &
            "|SCDIAF_DETPT" &
            "|SCDIAF_HBKZN" &
            "|SCDIAF_KZOPE" &
            "|SCDIAF_FREI1" &
            "|SCDIAF_FREI2" &
            "|SCDIAF_FREI3" &
            "|SCDIAF_EX1TY" &
            "|SCDIAF_EX1WE" &
            "|SCDIAF_EX2TY" &
            "|SCDIAF_EX2WE" &
            "|SCDIAF_EX3TY" &
            "|SCDIAF_EX3WE" &
            "|SCDIAF_EX4TY" &
            "|SCDIAF_EX4WE" &
            "|SCDIAF_IFNAM" &
            "|SCDIAF_DXIFD"

        Dim CSV_ROW As String = Nothing

        Dim SCDRIF_MDANT As String = Nothing
        Dim SCDRIF_MODUL As String = Nothing
        Dim SCDRIF_KDNRH As String = Nothing
        Dim SCDRIF_GSREF As String = Nothing
        Dim SCDRIF_FILNR As String = Nothing
        Dim SCDRIF_TRDID As String = Nothing
        Dim SCDRIF_NTSET As String = Nothing
        Dim SCDRIF_MARAG As String = Nothing
        Dim SCDRIF_RSCAT As String = Nothing
        Dim SCDRIF_HSPRI As String = Nothing
        Dim SCDRIF_HSSEC As String = Nothing
        Dim SCDRIF_HSTYP As String = Nothing
        Dim SCDRIF_BUPRI As String = Nothing
        Dim SCDRIF_SVTYP As String = Nothing
        Dim SCDRIF_SUPFA As String = Nothing
        Dim SCDRIF_CMVAL As String = Nothing
        Dim SCDRIF_WHGMV As String = Nothing
        Dim SCDRIF_NOTNL As String = Nothing
        Dim SCDRIF_WHISO As String = Nothing
        Dim SCDRIF_NOMB2 As String = Nothing
        Dim SCDRIF_WHIS2 As String = Nothing
        Dim SCDRIF_FAIRV As String = Nothing
        Dim SCDRIF_WHGFV As String = Nothing
        Dim SCDRIF_MDATE As String = Nothing
        Dim SCDRIF_SDATE As String = Nothing
        Dim SCDRIF_EDATE As String = Nothing
        Dim SCDRIF_ODATE As String = Nothing
        Dim SCDRIF_DXVKT As String = Nothing
        Dim SCDRIF_DXNVB As String = Nothing
        Dim SCDRIF_MYEAR As String = Nothing
        Dim SCDRIF_SYEAR As String = Nothing
        Dim SCDRIF_EYEAR As String = Nothing
        Dim SCDRIF_OYEAR As String = Nothing
        Dim SCDRIF_TYEAR As String = Nothing
        Dim SCDRIF_RYEAR As String = Nothing
        Dim SCDRIF_BUSYD As String = Nothing
        Dim SCDRIF_INCAT As String = Nothing
        Dim SCDRIF_SIGND As String = Nothing
        Dim SCDRIF_TYPED As String = Nothing
        Dim SCDRIF_ULPRC As String = Nothing
        Dim SCDRIF_WHGUP As String = Nothing
        Dim SCDRIF_STRKE As String = Nothing
        Dim SCDRIF_WHGSP As String = Nothing
        Dim SCDRIF_ATTPT As String = Nothing
        Dim SCDRIF_DETPT As String = Nothing
        Dim SCDRIF_HBKZN As String = Nothing
        Dim SCDRIF_KZOPE As String = Nothing
        Dim SCDRIF_FREI1 As String = Nothing
        Dim SCDRIF_FREI2 As String = Nothing
        Dim SCDRIF_FREI3 As String = Nothing
        Dim SCDRIF_EX1TY As String = Nothing
        Dim SCDRIF_EX1WE As String = Nothing
        Dim SCDRIF_EX2TY As String = Nothing
        Dim SCDRIF_EX2WE As String = Nothing
        Dim SCDRIF_EX3TY As String = Nothing
        Dim SCDRIF_EX3WE As String = Nothing
        Dim SCDRIF_EX4TY As String = Nothing
        Dim SCDRIF_EX4WE As String = Nothing
        Dim SCDRIF_IFNAM As String = Nothing
        Dim SCDRIF_DXIFD As String = Nothing

        'Check if related transactions are loaded in BAIS Tables:BAIS_DESIFF and/or BAIS_DVTIFF
        cmd.CommandText = "Select Sum(A.CountTransactions) from 
                           (Select Count(ID) as CountTransactions from [BAIS_DESIFF] where [DESIFF_DXIFD]='" & rdsql & "'
                           UNION ALL
                           Select Count(ID) as CountTransactions from [BAIS_DVTIFF] where [DVTIFF_DXIFD]='" & rdsql & "')A"
        Dim Count As Double = cmd.ExecuteScalar

        If Count > 0 Then
            Try

                BgwBaisFilesCreation.ReportProgress(2, "Start creating BAIS_SCDIAF File for: " & rd)
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37') and [Id_SQL_Parameters] in ('BAIS')"
                ParameterStatus = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('BAIS_SCDRIF') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_COMMON_INTERFACE_FILES_V1.37'))) and Status in ('Y') order by SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            BgwBaisFilesCreation.ReportProgress(2, "Execute SQL Commands in BAIS_COMMON_INTERFACE_FILES_V1.37/" & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                BgwBaisFilesCreation.ReportProgress(2, "Generating File: SCDIAF_CCB.csv .... Please wait...")


                If File.Exists(BaisFilesCreationPath & "SCDIAF_CCB.csv") = True Then
                    File.Delete(BaisFilesCreationPath & "SCDIAF_CCB.csv")
                End If
                'Create Header
                System.IO.File.AppendAllText(BaisFilesCreationPath & "SCDIAF_CCB.csv", CSV_HEADER & vbCrLf)
                '++++++++++++++
                QueryText = "SELECT  * FROM  [BAIS_SCDRIF] where [SCDRIF_DXIFD]='" & rdsql & "'"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1

                        SCDRIF_MDANT = dt.Rows.Item(i).Item("SCDRIF_MDANT") & "|"
                        SCDRIF_MODUL = dt.Rows.Item(i).Item("SCDRIF_MODUL") & "|"
                        SCDRIF_KDNRH = dt.Rows.Item(i).Item("SCDRIF_EX1WE") & "|"  'special treatment for Alpha Interface
                        SCDRIF_GSREF = dt.Rows.Item(i).Item("SCDRIF_GSREF") & "|"
                        SCDRIF_FILNR = dt.Rows.Item(i).Item("SCDRIF_FILNR") & "|"
                        SCDRIF_TRDID = dt.Rows.Item(i).Item("SCDRIF_TRDID") & "|"
                        SCDRIF_NTSET = dt.Rows.Item(i).Item("SCDRIF_NTSET") & "|"
                        SCDRIF_MARAG = dt.Rows.Item(i).Item("SCDRIF_MARAG") & "|"
                        SCDRIF_RSCAT = dt.Rows.Item(i).Item("SCDRIF_RSCAT") & "|"
                        SCDRIF_HSPRI = dt.Rows.Item(i).Item("SCDRIF_HSPRI") & "|"
                        SCDRIF_HSSEC = dt.Rows.Item(i).Item("SCDRIF_HSSEC") & "|"
                        SCDRIF_HSTYP = dt.Rows.Item(i).Item("SCDRIF_HSTYP") & "|"
                        SCDRIF_BUPRI = dt.Rows.Item(i).Item("SCDRIF_BUPRI") & "|"
                        SCDRIF_SVTYP = dt.Rows.Item(i).Item("SCDRIF_SVTYP") & "|"
                        SCDRIF_SUPFA = dt.Rows.Item(i).Item("SCDRIF_SUPFA") & "|"
                        SCDRIF_CMVAL = dt.Rows.Item(i).Item("SCDRIF_CMVAL").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHGMV = dt.Rows.Item(i).Item("SCDRIF_WHGMV") & "|"
                        SCDRIF_NOTNL = dt.Rows.Item(i).Item("SCDRIF_NOTNL").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHISO = dt.Rows.Item(i).Item("SCDRIF_WHISO") & "|"
                        SCDRIF_NOMB2 = dt.Rows.Item(i).Item("SCDRIF_NOMB2").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHIS2 = dt.Rows.Item(i).Item("SCDRIF_WHIS2") & "|"
                        SCDRIF_FAIRV = dt.Rows.Item(i).Item("SCDRIF_FAIRV").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHGFV = dt.Rows.Item(i).Item("SCDRIF_WHGFV") & "|"
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_MDATE")) = False Then
                            Dim MDATE_Date As Date = dt.Rows.Item(i).Item("SCDRIF_MDATE")
                            SCDRIF_MDATE = MDATE_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_MDATE = "0" & "|"
                        End If
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_SDATE")) = False Then
                            Dim SDATE_Date As Date = dt.Rows.Item(i).Item("SCDRIF_SDATE")
                            SCDRIF_SDATE = SDATE_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_SDATE = "0" & "|"
                        End If
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_EDATE")) = False Then
                            Dim EDATE_Date As Date = dt.Rows.Item(i).Item("SCDRIF_EDATE")
                            SCDRIF_EDATE = EDATE_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_EDATE = "0" & "|"
                        End If
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_ODATE")) = False Then
                            Dim ODATE_Date As Date = dt.Rows.Item(i).Item("SCDRIF_ODATE")
                            SCDRIF_ODATE = ODATE_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_ODATE = "0" & "|"
                        End If
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_DXVKT")) = False Then
                            Dim DXVKT_Date As Date = dt.Rows.Item(i).Item("SCDRIF_DXVKT")
                            SCDRIF_DXVKT = DXVKT_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_DXVKT = "0" & "|"
                        End If
                        If IsDBNull(dt.Rows.Item(i).Item("SCDRIF_DXNVB")) = False Then
                            Dim DXNVB_Date As Date = dt.Rows.Item(i).Item("SCDRIF_DXNVB")
                            SCDRIF_DXNVB = DXNVB_Date.ToString("yyyyMMdd") & "|"
                        Else
                            SCDRIF_DXNVB = "0" & "|"
                        End If
                        SCDRIF_MYEAR = dt.Rows.Item(i).Item("SCDRIF_MYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_SYEAR = dt.Rows.Item(i).Item("SCDRIF_SYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_EYEAR = dt.Rows.Item(i).Item("SCDRIF_EYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_OYEAR = dt.Rows.Item(i).Item("SCDRIF_OYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_TYEAR = dt.Rows.Item(i).Item("SCDRIF_TYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_RYEAR = dt.Rows.Item(i).Item("SCDRIF_RYEAR").ToString.Replace(",", ".") & "|"
                        SCDRIF_BUSYD = dt.Rows.Item(i).Item("SCDRIF_BUSYD").ToString.Replace(",", ".") & "|"
                        SCDRIF_INCAT = dt.Rows.Item(i).Item("SCDRIF_INCAT") & "|"
                        SCDRIF_SIGND = dt.Rows.Item(i).Item("SCDRIF_SIGND") & "|"
                        SCDRIF_TYPED = dt.Rows.Item(i).Item("SCDRIF_TYPED") & "|"
                        SCDRIF_ULPRC = dt.Rows.Item(i).Item("SCDRIF_ULPRC").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHGUP = dt.Rows.Item(i).Item("SCDRIF_WHGUP") & "|"
                        SCDRIF_STRKE = dt.Rows.Item(i).Item("SCDRIF_STRKE").ToString.Replace(",", ".") & "|"
                        SCDRIF_WHGSP = dt.Rows.Item(i).Item("SCDRIF_WHGSP") & "|"
                        SCDRIF_ATTPT = dt.Rows.Item(i).Item("SCDRIF_ATTPT").ToString.Replace(",", ".") & "|"
                        SCDRIF_DETPT = dt.Rows.Item(i).Item("SCDRIF_DETPT").ToString.Replace(",", ".") & "|"
                        SCDRIF_HBKZN = dt.Rows.Item(i).Item("SCDRIF_HBKZN") & "|"
                        SCDRIF_KZOPE = dt.Rows.Item(i).Item("SCDRIF_KZOPE") & "|"
                        SCDRIF_FREI1 = dt.Rows.Item(i).Item("SCDRIF_FREI1") & "|"
                        SCDRIF_FREI2 = dt.Rows.Item(i).Item("SCDRIF_FREI2") & "|"
                        SCDRIF_FREI3 = dt.Rows.Item(i).Item("SCDRIF_FREI3") & "|"
                        SCDRIF_EX1TY = dt.Rows.Item(i).Item("SCDRIF_EX1TY") & "|"
                        SCDRIF_EX1WE = dt.Rows.Item(i).Item("SCDRIF_KDNRH") & "|" 'special treatment for Alpha Interface
                        SCDRIF_EX2TY = dt.Rows.Item(i).Item("SCDRIF_EX2TY") & "|"
                        SCDRIF_EX2WE = dt.Rows.Item(i).Item("SCDRIF_EX2WE") & "|"
                        SCDRIF_EX3TY = dt.Rows.Item(i).Item("SCDRIF_EX3TY") & "|"
                        SCDRIF_EX3WE = dt.Rows.Item(i).Item("SCDRIF_EX3WE") & "|"
                        SCDRIF_EX4TY = dt.Rows.Item(i).Item("SCDRIF_EX4TY") & "|"
                        SCDRIF_EX4WE = dt.Rows.Item(i).Item("SCDRIF_EX4WE") & "|"
                        SCDRIF_IFNAM = dt.Rows.Item(i).Item("SCDRIF_IFNAM") & "|"
                        SCDRIF_DXIFD = String.Format("{0:yyyyMMdd}", dt.Rows.Item(i).Item("SCDRIF_DXIFD"))

                        CSV_ROW =
                            SCDRIF_MDANT &
                            SCDRIF_MODUL &
                            SCDRIF_KDNRH &
                            SCDRIF_GSREF &
                            SCDRIF_FILNR &
                            SCDRIF_TRDID &
                            SCDRIF_NTSET &
                            SCDRIF_MARAG &
                            SCDRIF_RSCAT &
                            SCDRIF_HSPRI &
                            SCDRIF_HSSEC &
                            SCDRIF_HSTYP &
                            SCDRIF_BUPRI &
                            SCDRIF_SVTYP &
                            SCDRIF_SUPFA &
                            SCDRIF_CMVAL &
                            SCDRIF_WHGMV &
                            SCDRIF_NOTNL &
                            SCDRIF_WHISO &
                            SCDRIF_NOMB2 &
                            SCDRIF_WHIS2 &
                            SCDRIF_FAIRV &
                            SCDRIF_WHGFV &
                            SCDRIF_MDATE &
                            SCDRIF_SDATE &
                            SCDRIF_EDATE &
                            SCDRIF_ODATE &
                            SCDRIF_DXVKT &
                            SCDRIF_DXNVB &
                            SCDRIF_MYEAR &
                            SCDRIF_SYEAR &
                            SCDRIF_EYEAR &
                            SCDRIF_OYEAR &
                            SCDRIF_TYEAR &
                            SCDRIF_RYEAR &
                            SCDRIF_BUSYD &
                            SCDRIF_INCAT &
                            SCDRIF_SIGND &
                            SCDRIF_TYPED &
                            SCDRIF_ULPRC &
                            SCDRIF_WHGUP &
                            SCDRIF_STRKE &
                            SCDRIF_WHGSP &
                            SCDRIF_ATTPT &
                            SCDRIF_DETPT &
                            SCDRIF_HBKZN &
                            SCDRIF_KZOPE &
                            SCDRIF_FREI1 &
                            SCDRIF_FREI2 &
                            SCDRIF_FREI3 &
                            SCDRIF_EX1TY &
                            SCDRIF_EX1WE &
                            SCDRIF_EX2TY &
                            SCDRIF_EX2WE &
                            SCDRIF_EX3TY &
                            SCDRIF_EX3WE &
                            SCDRIF_EX4TY &
                            SCDRIF_EX4WE &
                            SCDRIF_IFNAM &
                            SCDRIF_DXIFD

                        System.IO.File.AppendAllText(BaisFilesCreationPath & "SCDIAF_CCB.csv", CSV_ROW & vbCrLf)
                    Next



                    CloseSqlConnections()


                    Me.SCDRIF_Result = "Created"
                Else
                    CloseSqlConnections()

                    Me.SCDRIF_Result = "Not Created"
                    If File.Exists(BaisFilesCreationPath & "SCDIAF_CCB.csv") = True Then
                        File.Delete(BaisFilesCreationPath & "SCDIAF_CCB.csv")
                    End If
                    'Create Header
                    System.IO.File.AppendAllText(BaisFilesCreationPath & "SCDIAF_CCB.csv", CSV_HEADER & vbCrLf)
                    Exit Sub
                End If

            Catch ex As System.Exception
                'SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        Else
            CloseSqlConnections()
            Me.SCDRIF_Result = "Created"
            If File.Exists(BaisFilesCreationPath & "SCDIAF_CCB.csv") = True Then
                File.Delete(BaisFilesCreationPath & "SCDIAF_CCB.csv")
            End If
            'Create Header
            System.IO.File.AppendAllText(BaisFilesCreationPath & "SCDIAF_CCB.csv", CSV_HEADER & vbCrLf)
            XtraMessageBox.Show("Unable to create File SCDIAF_CCB.csv for " & rd & vbNewLine & "No related transactions are loaded in BAIS Tables:BAIS_DESIFF and/or BAIS_DVTIFF" & vbNewLine & " Please Check!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        CloseSqlConnections()
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

        <System.Runtime.InteropServices.DllImport("user32")>
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

    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl1.TextChanged
        RichEditControl1.Document.DefaultCharacterProperties.FontName = "Consolas"
        RichEditControl1.Document.DefaultCharacterProperties.FontSize = 9

    End Sub
End Class