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
    Dim sqld1 As String = Nothing
    Dim sqld2 As String = Nothing
    Dim rdsql1 As String
    Dim rdsql2 As String

    Dim OCBSaccountNamelbl As String = Nothing
    Dim OCBSaccountlbl As String = Nothing
    Dim OCBSaccountCurlbl As String = Nothing
    Dim OCBSaccountStatuslbl As String = Nothing
    Dim OCBSDatefromlbl As String = Nothing
    Dim OCBSDatetilllbl As String = Nothing
    Dim OCBSstartingBalancelbl As String = Nothing
    Dim OCBSclosingBalancelbl As String = Nothing

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
    Private Sub CUSTOMER_VOLUMESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CUSTOMER_VOLUMESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub CustomerVostroBalancesNEWG_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.CUSTOMER_ACCOUNTSTableAdapter.FillByVostroAccounts(Me.PSTOOLDataset.CUSTOMER_ACCOUNTS)

        'Get Forelast Date and fill DateEdits
        Dim d As Date = DateAdd(DateInterval.Day, -1, Today)
        OCBS_BookingDate_From.EditValue = d
        OCBS_BookingDate_Till.EditValue = d

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
                'ALL SEARCH ITEMS
                If Me.Account_LookUpEdit.Text <> "" Then ' AndAlso IsNumeric(Me.Account_LookUpEdit.Text) = True Then
                    Try
                        'Account Name finden
                        Me.QueryText = "SELECT * from [CUSTOMER_ACCOUNTS] where [Client Account]='" & Me.Account_LookUpEdit.Text & "'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)

                        OCBSaccountCurlbl = dt.Rows.Item(0).Item("Deal Currency")
                        OCBSaccountNamelbl = dt.Rows.Item(0).Item("English Name")
                        Me.CustomerAccountNamelbl.Text = dt.Rows.Item(0).Item("English Name")
                        OCBSaccountlbl = Me.Account_LookUpEdit.Text

                        Me.AccountStatusLbl.Text = dt.Rows.Item(0).Item("Account Status") _
                           & vbNewLine & "Opened on: " & dt.Rows.Item(0).Item("OPEN_DATE") _
                           & vbNewLine & "Closed on :" & dt.Rows.Item(0).Item("CLOSE_DATE")
                        OCBSaccountStatuslbl = Me.AccountStatusLbl.Text


                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load  Balances for Vostro Account: " & Me.Account_LookUpEdit.Text & " from: " & d1 & " till " & d2)

                        FILL_ONE_ACCOUNT_DATATABLE()

                        'Dim objCMD As SqlCommand = New SqlCommand("execute [CUSTOMER_VOLUMES_ACCOUNT_NR]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "',@ACCOUNT_NR='" & Me.Account_LookUpEdit.Text & "'  ", conn)
                        'objCMD.CommandTimeout = 5000
                        'da = New SqlDataAdapter(objCMD)

                        'Data reader
                        'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        '    Using sqlCmd As New SqlCommand()
                        '        sqlCmd.CommandText = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] WHERE  (AccountNo = '" & Me.Account_LookUpEdit.Text & "') AND ([BalanceDate] >= '" & rdsql1 & "') AND ([BalanceDate] <= '" & rdsql2 & "') and [AccountType] in ('Current account') ORDER BY [BalanceDate] asc"
                        '        sqlCmd.Connection = sqlConn
                        '        sqlCmd.CommandTimeout = 5000
                        '        If sqlConn.State = ConnectionState.Closed Then
                        '            sqlConn.Open()
                        '        End If

                        '        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        '        objDataTable.Clear()
                        '        objDataTable.Load(objDataReader)

                        '        If sqlConn.State = ConnectionState.Open Then
                        '            sqlConn.Close()
                        '        End If

                        '    End Using
                        'End Using

                        Me.SearchText_lbl.Text = "Balances for Vostro Account: " & Me.Account_LookUpEdit.Text & " -Currency: " & OCBSaccountCurlbl & " from " & d1 & " till " & d2 & "  - Account Status: " & dt.Rows.Item(0).Item("Account Status")

                        'dt = New DataTable()
                        'da.Fill(dt)
                        'Results
                        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        'Me.GridControl1.DataSource = Nothing
                        'Me.GridControl1.DataSource = dt
                        'Me.GridControl1.ForceInitialize()
                        'SplashScreenManager.CloseForm(False)
                        'Else
                        'SplashScreenManager.CloseForm(False)
                        'Me.GridControl1.DataSource = Nothing
                        'XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        'Exit Sub
                        'End If

                        'Results Datareader
                        'If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                        '    Me.GridControl1.DataSource = Nothing
                        '    Me.GridControl1.DataSource = objDataTable
                        '    Me.GridControl1.ForceInitialize()
                        '    Me.GridControl1.RefreshDataSource()
                        '    SplashScreenManager.CloseForm(False)
                        'Else
                        '    SplashScreenManager.CloseForm(False)
                        '    XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Return
                        'End If

                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        SplashScreenManager.CloseForm(False)
                    End Try

                Else
                    Try

                        OCBSaccountCurlbl = ""
                        OCBSaccountNamelbl = ""
                        Me.CustomerAccountNamelbl.Text = ""
                        OCBSaccountlbl = ""

                        Me.AccountStatusLbl.Text = ""
                        OCBSaccountStatuslbl = ""

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load  Balances for all Vostro Accounts from: " & d1 & " till " & d2)

                        FILL_ALL_ACCOUNTS_DATATABLE()

                        'Dim objCMD As SqlCommand = New SqlCommand("execute [CUSTOMER_VOLUMES_BALANCES]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "' ", conn)
                        'objCMD.CommandTimeout = 5000
                        'da = New SqlDataAdapter(objCMD)

                        'Data reader
                        'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        '    Using sqlCmd As New SqlCommand()
                        '        sqlCmd.CommandText = "SELECT * FROM   [CUSTOMER_ACC_BALANCES] WHERE   ([BalanceDate] >= '" & rdsql1 & "') AND ([BalanceDate] <= '" & rdsql2 & "') ORDER BY [BalanceDate] asc"
                        '        sqlCmd.Connection = sqlConn
                        '        sqlCmd.CommandTimeout = 5000
                        '        If sqlConn.State = ConnectionState.Closed Then
                        '            sqlConn.Open()
                        '        End If

                        '        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        '        objDataTable.Clear()
                        '        objDataTable.Load(objDataReader)

                        '        If sqlConn.State = ConnectionState.Open Then
                        '            sqlConn.Close()
                        '        End If

                        '    End Using
                        'End Using

                        Me.SearchText_lbl.Text = "Closing Balances for all Vostro Accounts  from " & d1 & " till " & d2

                        'dt = New DataTable()
                        'da.Fill(dt)
                        'Results
                        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        'Me.GridControl1.DataSource = Nothing
                        'Me.GridControl1.DataSource = dt
                        'Me.GridControl1.ForceInitialize()
                        'SplashScreenManager.CloseForm(False)
                        'Else
                        'SplashScreenManager.CloseForm(False)
                        'Me.GridControl1.DataSource = Nothing
                        'XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        'Exit Sub
                        'End If

                        'Results Datareader
                        'If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                        '    Me.GridControl1.DataSource = Nothing
                        '    Me.GridControl1.DataSource = objDataTable
                        '    Me.GridControl1.ForceInitialize()
                        '    Me.GridControl1.RefreshDataSource()
                        '    SplashScreenManager.CloseForm(False)
                        'Else
                        '    SplashScreenManager.CloseForm(False)
                        '    XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Return
                        'End If

                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        SplashScreenManager.CloseForm(False)
                    End Try
                End If
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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

    Private Sub Customer_Balances_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Customer_Balances_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Customer_Balances_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles Customer_Balances_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub
End Class