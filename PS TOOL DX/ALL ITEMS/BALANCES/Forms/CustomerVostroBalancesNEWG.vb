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
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class CustomerVostroBalancesNEWG
    Dim d1 As Date
    Dim d2 As Date
    Dim sqld1 As String = Nothing
    Dim sqld2 As String = Nothing
    Dim rdsql1 As String
    Dim rdsql2 As String

    Dim AccCCY As String = Nothing
    Dim AccName As String = Nothing
    Dim AccStatus As String = Nothing
    Dim AccOpenDate As String = Nothing
    Dim AccClosedDate As String = Nothing

    Friend WithEvents BgwLoadPostings As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Dim query As New CustomSqlQuery()

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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub CUSTOMER_VOLUMESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CUSTOMER_VOLUMESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.OCBS_BookingDate_From.Enabled = False
        Me.OCBS_BookingDate_Till.Enabled = False
        Me.Account_LookUpEdit.Enabled = False
        Me.LoadOCBS_btn.Enabled = False
        Me.Print_Export_Gridview_btn.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.OCBS_BookingDate_From.Enabled = True
        Me.OCBS_BookingDate_Till.Enabled = True
        Me.Account_LookUpEdit.Enabled = True
        Me.LoadOCBS_btn.Enabled = True
        Me.Print_Export_Gridview_btn.Enabled = True
    End Sub

    Private Sub CustomerVostroBalancesNEWG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CUSTOMER_ACCOUNTSTableAdapter.FillByVostroAccounts(Me.PSTOOLDataset.CUSTOMER_ACCOUNTS)

        'Get Forelast Date and fill DateEdits
        Dim d As Date = DateAdd(DateInterval.Day, -1, Today)
        OCBS_BookingDate_From.EditValue = d
        OCBS_BookingDate_Till.EditValue = d

    End Sub

    Private Sub Account_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Account_LookUpEdit.EditValueChanged
        If Me.Account_LookUpEdit.Text <> "" Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim CUSTOMER_NAME_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Dim ACC_CURRENCY_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Dim ACC_STATUS_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Dim ACC_OPEN_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Dim ACC_CLOSED_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.CustomerAccountNamelbl.Text = CUSTOMER_NAME_Row("English Name").ToString.Trim
            AccCCY = ACC_CURRENCY_Row("Deal Currency").ToString
            AccStatus = ACC_STATUS_Row("Account Status").ToString
            AccOpenDate = ACC_STATUS_Row("OPEN_DATE").ToString
            AccClosedDate = ACC_STATUS_Row("CLOSE_DATE").ToString
            If AccClosedDate <> Nothing Then
                AccClosedDate = CDate(AccClosedDate)
            End If
            Me.AccountStatusLbl.Text = "Currency: " & AccCCY & " - Status: " & AccStatus _
                           & vbNewLine & "Opened on: " & CDate(AccOpenDate) _
                           & vbNewLine & "Closed on :" & AccClosedDate
        Else
            Me.CustomerAccountNamelbl.Text = Nothing
            AccCCY = Nothing
            AccStatus = Nothing
            AccOpenDate = Nothing
            AccClosedDate = Nothing
            Me.AccountStatusLbl.Text = Nothing
        End If
    End Sub

    Private Sub FILL_ONE_ACCOUNT_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] WHERE  (AccountNo = '" & Me.Account_LookUpEdit.Text & "') AND ([BalanceDate] >= '" & rdsql1 & "') AND ([BalanceDate] <= '" & rdsql2 & "') and [AccountType] in ('Vostro account') ORDER BY [BalanceDate] asc"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = Customer_Balances_BasicView
        Me.GridControl1.ForceInitialize()
        'Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FILL_ALL_ACCOUNTS_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds1 As New SqlDataSource(connectionParameters)
        query.Name = "customQuery2"
        query.Sql = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] WHERE   ([BalanceDate] >= '" & rdsql1 & "') AND ([BalanceDate] <= '" & rdsql2 & "') and [AccountType] in ('Vostro account') ORDER BY [BalanceDate] asc"
        ds1.Queries.Add(query)
        ds1.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds1
        Me.GridControl1.DataMember = "customQuery2"
        Me.GridControl1.MainView = Customer_Balances_BasicView
        Me.GridControl1.ForceInitialize()
        'Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub LoadOCBS_btn_Click(sender As Object, e As EventArgs) Handles LoadOCBS_btn.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then

            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")

                If IsNothing(Me.Account_LookUpEdit.Text) = False AndAlso IsNumeric(Me.Account_LookUpEdit.Text) = True Then
                    Me.SearchText_lbl.Text = "Balances for Vostro Account: " & Me.Account_LookUpEdit.Text & " -Currency: " & AccCCY & " - Name: " & Me.CustomerAccountNamelbl.Text & " from " & d1 & " till " & d2 & "  - Account Status: " & AccStatus
                ElseIf Me.Account_LookUpEdit.Text = "" Then
                    Me.SearchText_lbl.Text = "Balances for all Vostro Accounts  from " & d1 & " till " & d2
                End If
                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                BgwLoadPostings = New BackgroundWorker
                bgws.Add(BgwLoadPostings)
                BgwLoadPostings.WorkerReportsProgress = True
                BgwLoadPostings.RunWorkerAsync()
            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub BgwLoadPostings_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadPostings.DoWork
        Try
            If IsNothing(Me.Account_LookUpEdit.Text) = False AndAlso IsNumeric(Me.Account_LookUpEdit.Text) = True Then
                Me.BgwLoadPostings.ReportProgress(10, "Load  Balances for Vostro Account: " & Me.Account_LookUpEdit.Text & " from: " & d1 & " till " & d2)

                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] 
                                                WHERE  AccountNo = '" & Me.Account_LookUpEdit.Text & "'
                                                AND [BalanceDate] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "' 
                                                and [AccountType] in ('Vostro account') 
                                                ORDER BY [BalanceDate] asc"
                        Sqlcmd.Connection = Sqlconn
                        Sqlconn.Open()
                        daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)
                        Sqlconn.Close()

                    End Using
                End Using

            ElseIf Me.Account_LookUpEdit.Text = "" Then
                Me.BgwLoadPostings.ReportProgress(10, "Load Balances for all Vostro Accounts from: " & d1 & " till " & d2)

                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] 
                                                WHERE   [BalanceDate] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "' 
                                                and [AccountType] in ('Vostro account') 
                                                ORDER BY [BalanceDate] asc"
                        Sqlcmd.Connection = Sqlconn
                        Sqlconn.Open()
                        daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)
                        Sqlconn.Close()
                    End Using
                End Using
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadPostings.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoadPostings_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadPostings.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadPostings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadPostings.RunWorkerCompleted
        Workers_Complete(BgwLoadPostings, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        'Dim reportfooter As String = "UMSATZABFRAGE für " & OCBSaccountNamelbl & " Kundenkonto " & OCBSaccountlbl & " (" & OCBSaccountCurlbl & ")" & "von " & d1 & " bis " & d2 & " Account Status: " & OCBSaccountStatuslbl
        Dim reportfooter As String = Me.SearchText_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))


 'Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        'Try
        'iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
        'r = New RectangleF(New PointF(0, 0), iSize)
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        'pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub CustomerVostroBalancesNEWG_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class