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
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Globalization
Imports DevExpress.Spreadsheet

'*****************************************
'Class Name: Mindestreserve
'Version: V1.0.0.0
'Version Explanation:
'Author: CCBFF
'Email: info@ccbff.de
'Creation Time:
'Content:
'Function:
'Description:
'Modify log:  
'    1. Add by WYQ; Time: 06.10.2022; Content: Because of EURO interest rate +1.25%(reserver), +0.75%(Overnight), add booking Accrued

'******************************************
Public Class Mindestreserve

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Double = 0

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

    Private Sub Mindestreserve_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Me.GridControl4.DataSource = Nothing
        'Try
        'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
        'Using sqlCmd As New SqlCommand()
        'sqlCmd.CommandText = "SELECT * FROM [MINDESTRESERVE] order by [ID] asc"
        'sqlCmd.Connection = sqlConn
        'sqlConn.Open()
        'Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
        'Dim objDataTable As New DataTable()
        'objDataTable.Load(objDataReader)
        'Me.GridControl4.DataSource = Nothing
        'Me.GridControl4.DataSource = objDataTable
        'Me.GridControl4.ForceInitialize()
        'sqlConn.Close()
        'End Using
        'End Using
        'Catch
        'End Try

        Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)

    End Sub

    Private Sub Mindestreserve_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles Mindestreserve_GridView.CellValueChanged
       
    End Sub


    Private Sub Mindestreserve_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Mindestreserve_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Mindestreserve_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Mindestreserve_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
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
        Dim reportfooter As String = "MINIMAL RESERVE (DEUTSCHE BUNDESBANK) - Reserve and Interests"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub MINDESTRESERVEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MINDESTRESERVEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim view As GridView = Me.Mindestreserve_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Recalculating Negative Interests running Totals")
                Dim focusedRow As Integer = view.FocusedRowHandle
                view.PostEditor()
                Me.Validate()
                Me.MINDESTRESERVEBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "exec [MINDESTRESERVE_RUNNING_TOTALS]"
                cmd.CommandTimeout = 600
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GridControl4.BeginUpdate()
                Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
                Me.Mindestreserve_GridView.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        Dim view As GridView = Me.Mindestreserve_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Recalculating Negative Interests running Totals")
                Dim focusedRow As Integer = view.FocusedRowHandle
                Dim rd As Date = view.GetFocusedRowCellValue(colRiskDate)
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                view.PostEditor()
                Me.Validate()
                Me.MINDESTRESERVEBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                'cmd.CommandText = "WITH CTE AS (SELECT " & _
                '    " rownum = ROW_NUMBER() OVER (ORDER BY p.ID)," & _
                '    " p.[RiskDate],p.RuningTotalMinusInterestAmount" & _
                '    " FROM [MINDESTRESERVE] p)" & _
                '    " UPDATE A SET A.RuningTotalMinusInterestAmount=Case when A.BookedAccounting=1" & _
                '    " then A.RuningTotalMinusInterestAmount + B.PreviousValue else A.TotalInterest end" & _
                '    " from [MINDESTRESERVE] A INNER JOIN" & _
                '    " (SELECT prev.RuningTotalMinusInterestAmount PreviousValue," & _
                '    " CTE.[RiskDate],CTE.RuningTotalMinusInterestAmount," & _
                '    " nex.RuningTotalMinusInterestAmount NextValue" & _
                '    " FROM CTE" & _
                '    " LEFT JOIN CTE prev ON prev.rownum = CTE.rownum - 1" & _
                '    " LEFT JOIN CTE nex ON nex.rownum = CTE.rownum + 1" & _
                '    " where CTE.[RiskDate]='" & rdsql & "' )B on A.RiskDate=B.RiskDate"
                cmd.CommandText = "exec MINDESTRESERVE_RUNNING_TOTALS"
                cmd.CommandTimeout = 600
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GridControl4.BeginUpdate()
                Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
                Me.Mindestreserve_GridView.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub RepositoryItemImageComboBox3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox3.EditValueChanged
        Dim view As GridView = Me.Mindestreserve_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Recalculating Negative Total Interests")
                Dim focusedRow As Integer = view.FocusedRowHandle
                Dim rd As Date = view.GetFocusedRowCellValue(colRiskDate)
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                view.PostEditor()
                Me.Validate()
                Me.MINDESTRESERVEBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "exec [MINDESTRESERVE_BOOKED_TOTALS] @RISKDATE='" & rdsql & "'"
                cmd.CommandTimeout = 600
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GridControl4.BeginUpdate()
                Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
                Me.Mindestreserve_GridView.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    'Add the RepositoryItemCheckEditReserver_EditValueChanged function
    'Add by WYQ; Time: 06.10.2022; Content: Because of EURO interest rate +1.25%(reserver), +0.75%(Overnight), add booking Accrued
    Private Sub RepositoryItemCheckEditReserver_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEditReserver.EditValueChanged
        Dim view As GridView = Me.Mindestreserve_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Booking reserver Interests running Totals")
                Dim focusedRow As Integer = view.FocusedRowHandle
                Dim rd As Date = view.GetFocusedRowCellValue(colRiskDate)
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                view.PostEditor()
                Me.Validate()
                Me.MINDESTRESERVEBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                cmd.CommandText = "exec MINDESTRESERVE_RUNNING_TOTALS_Reserver"
                cmd.CommandTimeout = 600
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GridControl4.BeginUpdate()
                Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
                Me.Mindestreserve_GridView.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    'Add the RepositoryItemCheckEditOvernight_EditValueChanged function
    'Add by WYQ; Time: 06.10.2022; Content: Because of EURO interest rate +1.25%(reserver), +0.75%(Overnight), add booking Accrued
    Private Sub RepositoryItemCheckEditOvernight_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEditOvernight.EditValueChanged
        Dim view As GridView = Me.Mindestreserve_GridView
        Try


            If view.IsFilterRow(view.FocusedRowHandle) = False Then 'Wenn Kein Filter Row ist

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Booking Overnight Interests running Totals")
                Dim focusedRow As Integer = view.FocusedRowHandle
                Dim rd As Date = view.GetFocusedRowCellValue(colRiskDate)
                Dim rdsql As String = rd.ToString("yyyyMMdd")
                view.PostEditor()
                Me.Validate()
                Me.MINDESTRESERVEBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                cmd.CommandText = "exec MINDESTRESERVE_RUNNING_TOTALS_Overnight"
                cmd.CommandTimeout = 600
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Me.GridControl4.BeginUpdate()
                Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
                Me.Mindestreserve_GridView.RefreshData()
                Me.GridControl4.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)

            End If
        Catch ex As Exception
            view.HideEditor()

            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub ReloadMultibank_btn_Click(sender As Object, e As EventArgs) Handles ReloadMultibank_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload BUNDESBANK MINDESTRESERVE....")
        Me.MINDESTRESERVETableAdapter.Fill(Me.AccountingDataSet.MINDESTRESERVE)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs) Handles GridControl4.Click

    End Sub
End Class