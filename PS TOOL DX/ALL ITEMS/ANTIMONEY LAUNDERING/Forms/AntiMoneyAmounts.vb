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
Public Class AntiMoneyAmounts

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private objDataTable As New DataTable

    Dim d1 As Date
    Dim d2 As Date
    Dim Frdsql As String = ""
    Dim Tdsql As String = ""

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


    Private Sub ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        'Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.AntiMoneyLaunderingDataset)

    End Sub

    Private Sub AntiMoneyAmounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Get Max  Date
        cmd.CommandText = "SELECT MAX([TRANSACTIONDATE]) FROM [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS]"
        cmd.Connection.Open()
        Dim MaxTransactionDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.TransactionDate_From.Text = MaxTransactionDate
        Me.TransactionDate_Till.Text = MaxTransactionDate
        Frdsql = MaxTransactionDate.ToString("yyyyMMdd")
        'Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSTableAdapter.FillByTransactionDate(Me.AntiMoneyLaunderingDataset.ANTIMONEY_LAUND_PAYMENTS_AMOUNTS, MaxTransactionDate, MaxTransactionDate)

        'Dim da As SqlDataAdapter
        'Dim objCMD As SqlCommand = New SqlCommand("execute [AML_CUSTOMER_AMOUNTS_TRANSACTION_DATE]  @FROMDATE='" & Frdsql & "', @TILLDATE='" & Frdsql & "' ", conn)
        'objCMD.CommandTimeout = 5000
        'da = New SqlDataAdapter(objCMD)
        'dt = New DataTable()
        'da.Fill(dt)

        'Data reader
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS] where [TRANSACTIONDATE]>='" & Frdsql & "' and [TRANSACTIONDATE]<='" & Frdsql & "'"
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 5000
                If sqlConn.State = ConnectionState.Closed Then
                    sqlConn.Open()
                End If

                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                objDataTable.Clear()
                objDataTable.Load(objDataReader)

                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                End If

            End Using
        End Using


        'Results Datareader
        If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl1.DataSource = objDataTable
            Me.GridControl1.ForceInitialize()
            SplashScreenManager.CloseForm(False)
        Else
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Me.AntiMoney_PaymentsAmounts_BasicView.ExpandAllGroups()

    End Sub

    Private Sub AntiMoneyAmounts_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Me.AntiMoney_PaymentsAmounts_BasicView.IsFindPanelVisible Then
            Dim find As FindControl = TryCast(AntiMoney_PaymentsAmounts_BasicView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        Else
            AntiMoney_PaymentsAmounts_BasicView.ShowFindPanel()
        End If
    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
        Me.GridControl1.DataSource = Me.ANTIMONEY_LAUND_PAYMENTS_AMOUNTSBindingSource


        If IsDate(TransactionDate_From.Text) = True And IsDate(TransactionDate_Till.Text) = True Then
            d1 = Me.TransactionDate_From.Text
            d2 = Me.TransactionDate_Till.Text
            Frdsql = d1.ToString("yyyyMMdd")
            Tdsql = d2.ToString("yyyyMMdd")
            If d2 >= d1 Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Loading Data from: " & d1 & " till " & d2)

                Try
                    'Dim da As SqlDataAdapter
                    'Dim objCMD As SqlCommand = New SqlCommand("execute [AML_CUSTOMER_AMOUNTS_TRANSACTION_DATE]  @FROMDATE='" & Frdsql & "', @TILLDATE='" & Tdsql & "' ", conn)
                    'objCMD.CommandTimeout = 5000
                    'da = New SqlDataAdapter(objCMD)
                    'dt = New DataTable()
                    'da.Fill(dt)

                    'Data reader
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandText = "SELECT * FROM [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS] where [TRANSACTIONDATE]>='" & Frdsql & "' and [TRANSACTIONDATE]<='" & Tdsql & "'"
                            sqlCmd.Connection = sqlConn
                            sqlCmd.CommandTimeout = 5000
                            If sqlConn.State = ConnectionState.Closed Then
                                sqlConn.Open()
                            End If

                            Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                            objDataTable.Clear()
                            objDataTable.Load(objDataReader)

                            If sqlConn.State = ConnectionState.Open Then
                                sqlConn.Close()
                            End If

                        End Using
                    End Using



                    'Results Datareader
                    If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                        Me.GridControl1.DataSource = Nothing
                        Me.GridControl1.DataSource = objDataTable
                        Me.GridControl1.ForceInitialize()
                        SplashScreenManager.CloseForm(False)
                    Else
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
                SplashScreenManager.CloseForm(False)
            Else
                XtraMessageBox.Show("Date Till is less than Date From", "WRONG DATES INPUT", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        Me.AntiMoney_PaymentsAmounts_BasicView.ExpandAllGroups()

    End Sub

    Private Sub TransactionDate_From_Click(sender As Object, e As EventArgs) Handles TransactionDate_From.Click
        If IsDate(Me.TransactionDate_From.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub TransactionDate_From_KeyDown(sender As Object, e As KeyEventArgs) Handles TransactionDate_From.KeyDown
        If IsDate(Me.TransactionDate_From.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub TransactionDate_Till_Click(sender As Object, e As EventArgs) Handles TransactionDate_Till.Click
        If IsDate(Me.TransactionDate_Till.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub TransactionDate_Till_KeyDown(sender As Object, e As KeyEventArgs) Handles TransactionDate_Till.KeyDown
        If IsDate(Me.TransactionDate_Till.Text) = True Then
            Me.GridControl1.DataSource = Nothing
        End If
    End Sub


    Private Sub AntiMoney_PaymentsAmounts_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AntiMoney_PaymentsAmounts_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AntiMoney_PaymentsAmounts_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles AntiMoney_PaymentsAmounts_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        Dim reportfooter As String = "ABFRAGE" & vbNewLine & "Zahlungsaufträge pro Kunde und Tag komuliert ab EUR 10.000,00" & "  " & "von: " & Me.TransactionDate_From.Text & "  bis: " & Me.TransactionDate_Till.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

   
End Class