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
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports DevExpress.XtraRichEdit.Services

Public Class Audit

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

    Private Sub AuditBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AuditBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AuditDataSet)

    End Sub

    Private Sub Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Try

            'Get Max Date
            cmd.CommandText = "SELECT MAX([OperationDate]) FROM [Audit]"
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
            Me.QueryText = "Select [OperationDate] from [Audit] GROUP BY [OperationDate]  ORDER BY [OperationDate] desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    Me.AuditDateFrom_Comboedit.Properties.Items.Add(row("OperationDate"))
                    Me.AuditDateTill_Comboedit.Properties.Items.Add(row("OperationDate"))
                End If
            Next
            If dt.Rows.Count > 0 Then
                Me.AuditDateFrom_Comboedit.Text = dt.Rows.Item(0).Item("OperationDate")
                Me.AuditDateTill_Comboedit.Text = dt.Rows.Item(0).Item("OperationDate")
            End If
            Me.AuditTableAdapter.SetCommandTimeOut(120000)

            Dim d1 As Date = Me.AuditDateFrom_Comboedit.Text
            Dim d2 As Date = Me.AuditDateTill_Comboedit.Text
            Dim rdsql1 As String = d1.ToString("yyyyMMdd")
            Dim rdsql2 As String = d2.ToString("yyyyMMdd")

            'Dim objCMD As SqlCommand = New SqlCommand("execute [AUDIT_FILL_SEARCH]  @MINRISKDATE='" & rdsql1 & "', @MAXRISKDATE='" & rdsql2 & "'  ", conn)
            'objCMD.CommandTimeout = 5000
            'da = New SqlDataAdapter(objCMD)
            'dt = New DataTable()
            'da.Fill(dt)
            'Results
            'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            'Me.GridControl2.DataSource = Nothing
            'Me.GridControl2.DataSource = dt
            'Me.GridControl2.ForceInitialize()
            'Else
            'MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            'Exit Sub
            'End If


            'Data reader
            Try
                Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using sqlCmd As New SqlCommand()
                        sqlCmd.CommandText = "SELECT * FROM [Audit] where [OperationDate]>='" & rdsql1 & "' and [OperationDate]<='" & rdsql2 & "' order by ID desc"
                        sqlCmd.Connection = sqlConn
                        If sqlConn.State = ConnectionState.Closed Then
                            sqlConn.Open()
                        End If

                        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        Dim objDataTable As New DataTable()
                        objDataTable.Load(objDataReader)
                        If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                            Me.GridControl2.DataSource = Nothing
                            Me.GridControl2.DataSource = objDataTable
                            Me.GridControl2.ForceInitialize()

                        Else
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                        If sqlConn.State = ConnectionState.Open Then
                            sqlConn.Close()
                        End If

                    End Using
                End Using
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub



    Private Sub AuditEvents_BasicView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles AuditEvents_BasicView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)
        If HitInfo.InRow Then
            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)
        End If
    End Sub

    Private Sub AuditEvents_BasicView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AuditEvents_BasicView.RowCellClick
        Dim view As GridView = CType(sender, GridView)
        Table_Name = view.GetRowCellValue(e.RowHandle, colTable_Name).ToString
        Related_ID = CInt(view.GetRowCellValue(e.RowHandle, colRelated_IdNr).ToString)


    End Sub

    Private Sub AuditEvents_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles AuditEvents_BasicView.RowClick
        Dim view As GridView = CType(sender, GridView)
        Table_Name = view.GetRowCellValue(e.RowHandle, colTable_Name).ToString
        Related_ID = CInt(view.GetRowCellValue(e.RowHandle, colRelated_IdNr).ToString)

    End Sub

    Private Sub AuditEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AuditEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub AuditEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles AuditEvents_BasicView.ShownEditor
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
        Dim reportfooter As String = "AUDIT EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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
                    SplashScreenManager.Default.SetWaitFormCaption("Loading Audit Items for " & d1 & " till " & d2)

                    'Dim objCMD As SqlCommand = New SqlCommand("execute [AUDIT_FILL_SEARCH]  @MINRISKDATE='" & sqld1 & "', @MAXRISKDATE='" & sqld2 & "'  ", conn)
                    'objCMD.CommandTimeout = 5000
                    'da = New SqlDataAdapter(objCMD)
                    'dt = New DataTable()
                    'da.Fill(dt)
                    'Results
                    'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    'Me.GridControl2.DataSource = Nothing
                    'Me.GridControl2.DataSource = dt
                    'Me.GridControl2.ForceInitialize()
                    'Else
                    'MessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'Exit Sub
                    'End If

                    'Data reader
                    Try
                        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            Using sqlCmd As New SqlCommand()
                                sqlCmd.CommandText = "SELECT * FROM [Audit] where [OperationDate]>='" & sqld1 & "' and [OperationDate]<='" & sqld2 & "' order by ID desc"
                                sqlCmd.Connection = sqlConn
                                If sqlConn.State = ConnectionState.Closed Then
                                    sqlConn.Open()
                                End If

                                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                                Dim objDataTable As New DataTable()
                                objDataTable.Load(objDataReader)
                                If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                                    Me.GridControl2.DataSource = Nothing
                                    Me.GridControl2.DataSource = objDataTable
                                    Me.GridControl2.ForceInitialize()

                                Else
                                    SplashScreenManager.CloseForm(False)
                                    MessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Return
                                End If
                                If sqlConn.State = ConnectionState.Open Then
                                    sqlConn.Close()
                                End If

                            End Using
                        End Using
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If

    End Sub

    Private Sub SeeDetails_Form_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeDetails_Form_ToolStripMenuItem.Click
        Dim c As New SqlServerQueries
        c.MdiParent = Me.MdiParent

        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.RichEditControl1.Text = "Select * from [" & Table_Name & "] where ID=" & Related_ID & ""
        c.BbiExecuteSqlCommand.PerformClick()
        c.TreeList1.Visible = False
        c.RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(c.RichEditControl1.Document))
        c.Text = "Audit for Table: [" & Table_Name & "] and ID: " & Related_ID
        c.RichEditControl1.ReadOnly = True
        c.RichEditControl1.Enabled = False
        SplashScreenManager.CloseForm(False)
    End Sub
End Class