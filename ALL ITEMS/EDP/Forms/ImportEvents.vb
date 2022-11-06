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
Public Class ImportEvents

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Private Sub ImportEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Get Max Date
        'cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        'cmd.Connection.Open()
        'Dim MaxProcDate As Date = cmd.ExecuteScalar
        'cmd.Connection.Close()
        'Me.ImportEventsDateEdit.Text = MaxProcDate
        'Me.IMPORT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)

        Me.IMPORT_EVENTSTableAdapter.Fill(Me.EDPDataSet.IMPORT_EVENTS)

    End Sub

    Private Sub ImportEventsDateEdit_Click(sender As Object, e As EventArgs) Handles ImportEventsDateEdit.Click
        If IsDate(Me.ImportEventsDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub


    Private Sub ImportEventsDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles ImportEventsDateEdit.KeyDown
        If IsDate(Me.ImportEventsDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadImportEvents_btn_Click(sender As Object, e As EventArgs) Handles LoadImportEvents_btn.Click
        Me.GridControl1.DataSource = Me.IMPORT_EVENTSBindingSource


        If IsDate(Me.ImportEventsDateEdit.Text) = True Then
            Dim d As Date = Me.ImportEventsDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            cmd.CommandText = "Select [ProcDate] from [IMPORT EVENTS] where [ProcDate]='" & dsql & "' "
            cmd.Connection.Open()
            If IsDate(cmd.ExecuteScalar) = True Then
                'Load Import Events
                Me.IMPORT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.IMPORT_EVENTS, d)
            Else
                MessageBox.Show("There's no Data for the indicated Date!", "NO DATA FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Get Max Date
                cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
                Dim MaxProcDate As Date = cmd.ExecuteScalar
                Me.ImportEventsDateEdit.Text = MaxProcDate
                Me.IMPORT_EVENTSTableAdapter.FillByProcDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
            End If
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub ImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ImportEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_ImportEvents_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ImportEvents_GridView_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        Dim reportfooter As String = "IMPORT EVENTS" 'on " & vbNewLine & "on: " & Me.ImportEventsDateEdit.Text
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub LoadEvents_btn_Click(sender As Object, e As EventArgs) Handles LoadEvents_btn.Click
        Me.IMPORT_EVENTSTableAdapter.Fill(Me.EDPDataSet.IMPORT_EVENTS)
    End Sub
   
End Class