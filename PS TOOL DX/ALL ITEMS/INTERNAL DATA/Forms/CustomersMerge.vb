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
Public Class CustomersMerge

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEVENT As New SqlConnection
    Dim cmdEVENT As New SqlCommand
    Dim SqlCommandText1 As String = Nothing
    Dim SqlCommandText2 As String = Nothing
    Dim SqlCommandText3 As String = Nothing

    Private QueryText As String = Nothing
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing

    Friend WithEvents BgwClientMerge As BackgroundWorker

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

    Private Sub CustomersMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT

        Me.Merge_DateEdit.EditValue = Today

    End Sub

    Private Sub CustomersMerge_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If Me.BgwClientMerge.IsBusy = True Then
        '    e.Cancel = True
        'Else
        '    e.Cancel = False
        'End If
    End Sub

    Private Sub OldClientNr_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OldClientNr_TextEdit.EditValueChanged
        If Me.OldClientNr_TextEdit.EditValue <> "" AndAlso Len(Me.OldClientNr_TextEdit.EditValue) = 18 Then
            Me.QueryText = "Select [English Name] from [CUSTOMER_INFO] where [ClientNo]='" & Me.OldClientNr_TextEdit.EditValue & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.OldClientName_lbl.Text = dt.Rows.Item(0).Item("English Name")
            Else
                XtraMessageBox.Show("The inputed Client Nr. not exists or closed!", "OLD CLIENT NR. NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            Me.OldClientNr_TextEdit.EditValue = ""
        End If
    End Sub

    Private Sub NewClientNr_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NewClientNr_TextEdit.EditValueChanged
        If Me.NewClientNr_TextEdit.EditValue <> "" AndAlso Len(Me.NewClientNr_TextEdit.EditValue) = 18 Then
            Me.QueryText = "Select [English Name] from [CUSTOMER_INFO] where [ClientNo]='" & Me.NewClientNr_TextEdit.EditValue & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.NewClientName_lbl.Text = dt.Rows.Item(0).Item("English Name")
            Else
                XtraMessageBox.Show("The inputed Client Nr. not exists or closed!", "NEW CLIENT NR. NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            Me.NewClientNr_TextEdit.EditValue = ""
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click

        Me.Close()


    End Sub

    Private Sub OK_btn_Click(sender As Object, e As EventArgs) Handles OK_btn.Click
        If Me.OldClientName_lbl.Text <> "" And Me.NewClientName_lbl.Text <> "" Then
            If XtraMessageBox.Show("Should the old Client Nr.:" & vbNewLine & Me.OldClientNr_TextEdit.EditValue & vbNewLine & " be merged with the new Client Nr.:" & vbNewLine & Me.NewClientNr_TextEdit.EditValue & vbNewLine & vbNewLine & "!!! ATTENTION: This Operation can not be revoked !!!", "CLIENT NR. MERGING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.Cancel_btn.Enabled = False
                BgwClientMerge = New BackgroundWorker
                BgwClientMerge.WorkerReportsProgress = True
                BgwClientMerge.RunWorkerAsync()
            End If
        Else
            XtraMessageBox.Show("The Client Name is missing!", "CLIENT NAME MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub

    Private Sub BgwClientMerge_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwClientMerge.DoWork
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Try
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('CLIENT_MERGE') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                rd = Me.Merge_DateEdit.EditValue
                rdsql = rd.ToString("yyyyMMdd")

                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('CLIENT_MERGE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    SqlCommandText2 = SqlCommandText1.ToString.Replace("<OldClientNr>", Me.OldClientNr_TextEdit.EditValue)
                    SqlCommandText3 = SqlCommandText2.ToString.Replace("<NewClientNr>", Me.NewClientNr_TextEdit.EditValue)
                    cmd.CommandText = SqlCommandText3
                    If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                        Threading.Thread.Sleep(500)
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1"))
                        Me.BgwClientMerge.ReportProgress(3, "Execute Client Merging: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next

                SplashScreenManager.Default.SetWaitFormCaption("CLIENT MERGE finished for: " & rd)
                Me.BgwClientMerge.ReportProgress(16, "CLIENT MERGE finished for: " & rd)
            Else
                SplashScreenManager.Default.SetWaitFormCaption("CLIENT MERGE finished for: " & rd)
                Me.BgwClientMerge.ReportProgress(5, "CLIENT_MERGE STATUS is Deactivated")
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwClientMerge.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwClientMerge_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwClientMerge.ProgressChanged
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','CLIENT MERGING','INTERNAL OPERATION')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CLIENT MERGING" & "  " & e.UserState & "  " & "INTERNAL OPERATION"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','CLIENT MERGING','INTERNAL OPERATION')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CLIENT MERGING" & "  " & e.UserState & "  " & "INTERNAL OPERATION"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
        cmdEVENT.Connection.Close()
    End Sub

    Private Sub BgwClientMerge_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwClientMerge.RunWorkerCompleted
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        SplashScreenManager.CloseForm(False)
        XtraMessageBox.Show("The old Client Nr.:" & vbNewLine & Me.OldClientNr_TextEdit.EditValue & vbNewLine & " merged sucessfully with the new Client Nr.:" & vbNewLine & Me.NewClientNr_TextEdit.EditValue, "CLIENT NR. MERGED SUCESSFULLY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Me.OldClientNr_TextEdit.EditValue = ""
        Me.NewClientNr_TextEdit.EditValue = ""
        Me.OldClientName_lbl.Text = ""
        Me.NewClientName_lbl.Text = ""
        Me.Cancel_btn.Enabled = True
    End Sub


End Class