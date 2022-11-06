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
Public Class AuditDDL

    Dim conn As New SqlClient.SqlConnection
    Dim cmd As New SqlCommand


    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim MaxProcDate As Date

    Dim Table_Name As String = Nothing
    Dim Related_ID As Integer = 0

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


    Private Sub DDLEventsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.DDLEventsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AuditDataSet)

    End Sub

    Private Sub AuditDDL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.GridControl2.MainView = Audit_DDLEvents_BasicView

        Try

            'Get Max Date
            cmd.CommandText = "SELECT MAX([EventDate]) FROM [DDLEvents]"
            cmd.Connection.Open()
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                MaxProcDate = cmd.ExecuteScalar
            Else
                MaxProcDate = DateSerial(2014, 9, 30)
            End If
            cmd.Connection.Close()

            'Bind Combobox
            Me.AuditDateFrom_Comboedit.Properties.Items.Clear()
            Me.AuditDateTill_Comboedit.Properties.Items.Clear()
            Me.QueryText = "Select [EventDate] from [DDLEvents] GROUP BY [EventDate]  ORDER BY [EventDate] desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    Me.AuditDateFrom_Comboedit.Properties.Items.Add(row("EventDate"))
                    Me.AuditDateTill_Comboedit.Properties.Items.Add(row("EventDate"))
                End If
            Next
            If dt.Rows.Count > 0 Then
                Me.AuditDateFrom_Comboedit.Text = dt.Rows.Item(0).Item("EventDate")
                Me.AuditDateTill_Comboedit.Text = dt.Rows.Item(0).Item("EventDate")
            End If
           
            Dim d1 As Date = Me.AuditDateFrom_Comboedit.Text
            Dim d2 As Date = Me.AuditDateTill_Comboedit.Text
            Dim rdsql1 As String = d1.ToString("yyyyMMdd")
            Dim rdsql2 As String = d2.ToString("yyyyMMdd")

            Dim objCMD As SqlCommand = New SqlCommand("Select * from [DDLEvents] where [EventDate]>='" & rdsql1 & "' and [EventDate]<='" & rdsql2 & "' ORDER BY ID desc", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)

            dt = New DataTable()
            da.Fill(dt)
            'Results
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.GridControl2.DataSource = Nothing
                Me.GridControl2.DataSource = dt
                Me.GridControl2.ForceInitialize()
            Else
                MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

    End Sub

    Private Sub LoadAudit_btn_Click(sender As Object, e As EventArgs) Handles LoadAudit_btn.Click
        If Me.AuditDateFrom_Comboedit.Text <> "" And Me.AuditDateTill_Comboedit.Text <> "" Then
            Dim d1 As Date = Me.AuditDateFrom_Comboedit.Text
            Dim sqld1 As String = d1.ToString("yyyyMMdd")
            Dim d2 As Date = Me.AuditDateTill_Comboedit.Text
            Dim sqld2 As String = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Loading DDL Events  from " & d1 & " till " & d2)
                    Me.GridControl2.MainView = Audit_DDLEvents_BasicView
                    Me.GridControl2.DataSource = Nothing
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandText = "Select * from [DDLEvents] where [EventDate]>='" & sqld1 & "' and [EventDate]<='" & sqld2 & "' ORDER BY ID desc"
                            sqlCmd.Connection = sqlConn
                            If sqlConn.State = ConnectionState.Closed Then
                                sqlConn.Open()
                            End If
                            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                            Dim objDataTable As New DataTable()
                            objDataTable.Load(objDataReader)
                            Me.GridControl2.DataSource = Nothing
                            Me.GridControl2.DataSource = objDataTable
                            Me.GridControl2.ForceInitialize()
                            If sqlConn.State = ConnectionState.Open Then
                                sqlConn.Close()
                            End If

                        End Using
                    End Using
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub Audit_DDLEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Audit_DDLEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Audit_DDLEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Audit_DDLEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_AuditEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_AuditEvents_Gridview_btn.Click
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
        Dim reportfooter As String = "AUDIT DATABASE CHANGES EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub DisplayObjectCodeChanges_btn_Click(sender As Object, e As EventArgs) Handles DisplayObjectCodeChanges_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Loading Objects Code Changes")
            Me.GridControl2.MainView = Audit_OLD_NEW_CODE_CHANGES_GridView
            Me.GridControl2.DataSource = Nothing
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "WITH [Events] AS (SELECT EventDate,DatabaseName,SchemaName,ObjectName,EventDDL,rnLatest = ROW_NUMBER() OVER (PARTITION BY DatabaseName, SchemaName, ObjectName ORDER BY EventDate DESC),rnEarliest = ROW_NUMBER() OVER (PARTITION BY DatabaseName, SchemaName, ObjectName ORDER BY EventDate) FROM dbo.DDLEvents) SELECT Original.DatabaseName,Original.SchemaName,Original.ObjectName,OriginalCode = Original.EventDDL,NewestCode   = COALESCE(Newest.EventDDL, ''),LastModified = COALESCE(Newest.EventDate, Original.EventDate) FROM [Events] AS Original LEFT OUTER JOIN [Events] AS Newest ON  Original.DatabaseName = Newest.DatabaseName AND Original.SchemaName   = Newest.SchemaName AND Original.ObjectName   = Newest.ObjectName AND Newest.rnEarliest = Original.rnLatest AND Newest.rnLatest = Original.rnEarliest AND Newest.rnEarliest > 1 WHERE Original.rnEarliest = 1"
                    sqlCmd.Connection = sqlConn
                    If sqlConn.State = ConnectionState.Closed Then
                        sqlConn.Open()
                    End If
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.GridControl2.DataSource = Nothing
                    Me.GridControl2.DataSource = objDataTable
                    Me.GridControl2.ForceInitialize()
                    If sqlConn.State = ConnectionState.Open Then
                        sqlConn.Close()
                    End If

                End Using
            End Using
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub Audit_OLD_NEW_CODE_CHANGES_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Audit_OLD_NEW_CODE_CHANGES_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Audit_OLD_NEW_CODE_CHANGES_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Audit_OLD_NEW_CODE_CHANGES_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
End Class