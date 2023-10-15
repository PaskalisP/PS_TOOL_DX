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
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Public Class AllPostingsNEWG

    Dim d1 As Date
    Dim d2 As Date
    Dim rdsql1 As String
    Dim rdsql2 As String

    Private BS_AllContractsAccounts As BindingSource
    Friend WithEvents BgwLoadPostings As BackgroundWorker
    Friend WithEvents BgwLoadContractPostings As BackgroundWorker
    Friend WithEvents BgwLoad_GL_ACC_Postings As BackgroundWorker

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

    Private Sub GL_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GL_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub AllPostingsNEWG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.GL_ACCOUNTS_NEWGTableAdapter.Fill(Me.BalancesNEWGDataset.GL_ACCOUNTS_NEWG)
        ALL_CONTRACTS_ACCOUNTS_initData()
        ALL_CONTRACTS_ACCOUNTS_InitLookUp()

        'Bind Combobox Currencies
        Me.ComboBoxEdit1.Properties.Items.Clear()
        QueryText = "SELECT '***' as 'CURRENCY CODE' UNION ALL SELECT [CURRENCY CODE] FROM [OWN_CURRENCIES]"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ComboBoxEdit1.Properties.Items.Add(row("CURRENCY CODE"))
            End If
        Next
        Me.ComboBoxEdit1.Text = "***"

        'Get Forelast Date and fill DateEdits
        Dim d As Date = DateAdd(DateInterval.Day, -1, Today)
        BookingDate_From.EditValue = d
        BookingDate_Till.EditValue = d
        BookingDateContractFrom_DateEdit.EditValue = d
        BookingDateContractTill_DateEdit.EditValue = d
        FromDateEdit.EditValue = d
        TillDateEdit.EditValue = d
    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.BookingDate_From.Enabled = False
        Me.BookingDate_Till.Enabled = False
        Me.BookingDateContractFrom_DateEdit.Enabled = False
        Me.BookingDateContractTill_DateEdit.Enabled = False
        Me.FromDateEdit.Enabled = False
        Me.TillDateEdit.Enabled = False
        Me.LoadData_btn.Enabled = False
        Me.LoadDataContract_btn.Enabled = False
        Me.Load_PB_Data_btn.Enabled = False
        Me.LookUpEdit2.Enabled = False
        Me.ContractLookUpEdit.Enabled = False
        Me.SearchLookUpEdit1.Enabled = False
        Me.ComboBoxEdit1.Enabled = False
        Me.Print_Export_Gridview_btn.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.BookingDate_From.Enabled = True
        Me.BookingDate_Till.Enabled = True
        Me.BookingDateContractFrom_DateEdit.Enabled = True
        Me.BookingDateContractTill_DateEdit.Enabled = True
        Me.FromDateEdit.Enabled = True
        Me.TillDateEdit.Enabled = True
        Me.LoadData_btn.Enabled = True
        Me.LoadDataContract_btn.Enabled = True
        Me.Load_PB_Data_btn.Enabled = True
        Me.LookUpEdit2.Enabled = True
        Me.ContractLookUpEdit.Enabled = True
        Me.SearchLookUpEdit1.Enabled = True
        Me.ComboBoxEdit1.Enabled = True
        Me.Print_Export_Gridview_btn.Enabled = True
    End Sub

    Private Sub FILL_Specific_GL_ACCOUNT_BOOKINGS_ALL_CURRENCIES_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM   ALL_VOLUMES WHERE  (GL_AC_No = '" & Me.LookUpEdit2.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = AllPostings_BasicView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FILL_Specific_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM  ALL_VOLUMES WHERE  (GL_AC_No = '" & Me.LookUpEdit2.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND (CCY = '" & Me.ComboBoxEdit1.Text & "') AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = AllPostings_BasicView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FILL_ALL_GL_ACCOUNT_BOOKINGS_ALL_CURRENCY_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM  ALL_VOLUMES WHERE   ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND [System] in ('NEWG')  ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = AllPostings_BasicView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FILL_ALL_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM  ALL_VOLUMES WHERE   ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND (CCY = '" & Me.ComboBoxEdit1.Text & "') AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = AllPostings_BasicView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FILL_CONTRACT_DATA_DATATABLE()
        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
        Dim ds As New SqlDataSource(connectionParameters)
        query.Name = "customQuery1"
        query.Sql = "SELECT * FROM   ALL_VOLUMES WHERE  ([AccountNo] = '" & Me.ContractLookUpEdit.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND [System] in ('NEWG') ORDER BY IdNr"
        ds.Queries.Add(query)
        ds.Fill()
        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = ds
        Me.GridControl1.DataMember = "customQuery1"
        Me.GridControl1.MainView = AllPostings_BasicView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()
        SplashScreenManager.CloseForm(False)
    End Sub


#Region "ALL CONTRACTS LOAD"
    Private Sub ALL_CONTRACTS_ACCOUNTS_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbAllContractsAccounts As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]<>'0' order by [ID] desc", conn) '
        Try

            dbAllContractsAccounts.Fill(ds, "ALL_CONTRACTS_ACCOUNTS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_AllContractsAccounts = New BindingSource(ds, "ALL_CONTRACTS_ACCOUNTS")
    End Sub
    Private Sub ALL_CONTRACTS_ACCOUNTS_InitLookUp()
        Me.ContractLookUpEdit.Properties.DataSource = BS_AllContractsAccounts
        Me.ContractLookUpEdit.Properties.DisplayMember = "Contract_Account"
        Me.ContractLookUpEdit.Properties.ValueMember = "Contract_Account"
    End Sub
#End Region

    Private Sub LookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit2.EditValueChanged
        If Me.LookUpEdit2.Text <> "" Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim GL_ACC_NAME_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.LabelControl8.Text = GL_ACC_NAME_Row("GL_AC_Name").ToString

        Else
            Me.LabelControl8.Text = ""
        End If
    End Sub

    Private Sub ContractLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ContractLookUpEdit.EditValueChanged
        If Me.ContractLookUpEdit.Text <> "" Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim CLIENT_NAME_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.ContractName_lbl.Text = CLIENT_NAME_Row("ClientName").ToString.Trim
        Else
            Me.ContractName_lbl.Text = ""
        End If
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        If Me.SearchLookUpEdit1.Text <> "" Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim GL_ACC_NAME_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.LabelControl3.Text = GL_ACC_NAME_Row("NEWG_GL_ACC_Name").ToString

        Else
            Me.LabelControl3.Text = ""
        End If
    End Sub
    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
        If IsDate(Me.BookingDate_From.Text) = True AndAlso IsDate(Me.BookingDate_Till.Text) = True Then
            d1 = Me.BookingDate_From.Text
            d2 = Me.BookingDate_Till.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                Me.GridControl1.MainView = Nothing
                Me.GridControl1.DataSource = Nothing
                'ALL SEARCH ITEMS
                If Me.LookUpEdit2.Text <> "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                    If Me.ComboBoxEdit1.Text = "***" Then
                        Me.LabelControl14.Text = "Postings for GL NGS Account (" & Me.LookUpEdit2.Text & ")-" & Me.LabelControl8.Text & " - ALL CURRENCIES " & " from " & d1 & " till " & d2
                    ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                        Me.LabelControl14.Text = "Postings for GL NGS Account (" & Me.LookUpEdit2.Text & ")-" & Me.LabelControl8.Text & " -Currency: " & Me.ComboBoxEdit1.Text & " from " & d1 & " till " & d2
                    End If
                    'ONLY CURRENCY
                ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                    If Me.ComboBoxEdit1.Text = "***" Then
                        Me.LabelControl14.Text = "Postings for all GL NGS Accounts " & " - ALL CURRENCIES" & " from " & d1 & " till " & d2
                    ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                        Me.LabelControl14.Text = "Postings for all GL NGS Accounts " & " - Currency:" & Me.ComboBoxEdit1.Text & " from " & d1 & " till " & d2
                    End If
                    'ONLY DATES
                ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text = "" Then
                    Me.LabelControl14.Text = "Postings for all GL NGS Accounts " & " - ALL CURRENCIES" & " from " & d1 & " till " & d2
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
            If Me.LookUpEdit2.Text <> "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                If Me.ComboBoxEdit1.Text = "***" Then
                    Me.BgwLoadPostings.ReportProgress(10, "Load Postings for GL Account: " & Me.LookUpEdit2.Text & vbNewLine & "for all currencies from: " & d1 & " till " & d2)

                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  GL_AC_No = '" & Me.LookUpEdit2.Text & "'
                                                    AND [Value Date] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "'
                                                    AND [System] in ('NEWG') ORDER BY IdNr"
                            Sqlcmd.Connection = Sqlconn
                            Sqlconn.Open()
                            daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                            daSqlQueries.SelectCommand.CommandTimeout = 50000
                            dtSqlQueries = New DataTable()
                            daSqlQueries.Fill(dtSqlQueries)
                            Sqlconn.Close()

                        End Using
                    End Using

                ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                    Me.BgwLoadPostings.ReportProgress(10, "Load Postings for GL Account: " & Me.LookUpEdit2.Text & vbNewLine & "Currency:" & Me.ComboBoxEdit1.Text & " from: " & d1 & " till " & d2)

                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES WHERE  GL_AC_No = '" & Me.LookUpEdit2.Text & "'
                                                    AND [Value Date] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "'
                                                    AND CCY = '" & Me.ComboBoxEdit1.Text & "'
                                                    AND [System] in ('NEWG') ORDER BY IdNr"
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

                'ONLY CURRENCY
            ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                If Me.ComboBoxEdit1.Text = "***" Then
                    Me.BgwLoadPostings.ReportProgress(10, "Load all Postings from: " & d1 & " till " & d2)

                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES WHERE   
                                                [Value Date] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "'
                                                AND [System] in ('NEWG')  ORDER BY IdNr"
                            Sqlcmd.Connection = Sqlconn
                            Sqlconn.Open()
                            daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                            daSqlQueries.SelectCommand.CommandTimeout = 50000
                            dtSqlQueries = New DataTable()
                            daSqlQueries.Fill(dtSqlQueries)
                            Sqlconn.Close()
                        End Using
                    End Using
                ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                    Me.BgwLoadPostings.ReportProgress(10, "Load all Postings for Currency:" & Me.ComboBoxEdit1.Text & vbNewLine & "from: " & d1 & " till " & d2)

                    Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using Sqlcmd As New SqlCommand()
                            Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES 
                                                  WHERE  [Value Date] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "' 
                                                  AND CCY = '" & Me.ComboBoxEdit1.Text & "' 
                                                  AND [System] in ('NEWG') ORDER BY IdNr"
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

                'ONLY DATES
            ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text = "" Then
                Me.BgwLoadPostings.ReportProgress(10, "Load all Postings from: " & d1 & " till " & d2)

                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES WHERE   
                                            [Value Date] BETWEEN '" & rdsql1 & "' AND  '" & rdsql2 & "'
                                            AND [System] in ('NEWG')  ORDER BY IdNr"
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
            Me.GridControl1.MainView = AllPostings_BasicView
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub LoadDataContract_btn_Click(sender As Object, e As EventArgs) Handles LoadDataContract_btn.Click
        If IsDate(Me.BookingDateContractFrom_DateEdit.Text) = True AndAlso IsDate(Me.BookingDateContractTill_DateEdit.Text) = True Then
            d1 = Me.BookingDateContractFrom_DateEdit.Text
            d2 = Me.BookingDateContractTill_DateEdit.Text
            If d2 >= d1 Then
                'ALL SEARCH ITEMS
                If Me.ContractLookUpEdit.Text <> "" Then
                    rdsql1 = d1.ToString("yyyyMMdd")
                    rdsql2 = d2.ToString("yyyyMMdd")
                    Me.GridControl1.MainView = Nothing
                    Me.GridControl1.DataSource = Nothing

                    Me.LabelControl14.Text = "Postings for Contract/Account (" & Me.ContractLookUpEdit.Text & ")- " & Me.ContractName_lbl.Text & " - ALL CURRENCIES"

                    DISABLE_BUTTONS()
                    Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                    BgwLoadContractPostings = New BackgroundWorker
                    bgws.Add(BgwLoadContractPostings)
                    BgwLoadContractPostings.WorkerReportsProgress = True
                    BgwLoadContractPostings.RunWorkerAsync()
                Else
                    XtraMessageBox.Show("Please enter Contract/Account", "Contract/Account is missing", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Exit Sub
        End If

    End Sub

    Private Sub BgwLoadContractPostings_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadContractPostings.DoWork
        Try
            Me.BgwLoadContractPostings.ReportProgress(10, "Load Postings for Contract/Account: " & Me.ContractLookUpEdit.Text & vbNewLine & "for all currencies from: " & d1 & " till " & d2)

            Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using Sqlcmd As New SqlCommand()
                    Sqlcmd.CommandText = "SELECT * FROM  ALL_VOLUMES 
                                        WHERE  [AccountNo] = '" & Me.ContractLookUpEdit.Text & "' 
                                        AND [Value Date] BETWEEN '" & rdsql1 & "' AND '" & rdsql2 & "'
                                        AND [System] in ('NEWG') ORDER BY IdNr"
                    Sqlcmd.Connection = Sqlconn
                    Sqlconn.Open()
                    daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                    daSqlQueries.SelectCommand.CommandTimeout = 50000
                    dtSqlQueries = New DataTable()
                    daSqlQueries.Fill(dtSqlQueries)
                    Sqlconn.Close()
                End Using
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadContractPostings.CancelAsync()

        End Try
    End Sub

    Private Sub BgwLoadContractPostings_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadContractPostings.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadContractPostings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadContractPostings.RunWorkerCompleted
        Workers_Complete(BgwLoadContractPostings, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.GridControl1.MainView = AllPostings_BasicView
            Me.GridControl1.ForceInitialize()
            Me.GridControl1.RefreshDataSource()
        Else
            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub Load_PB_Data_btn_Click(sender As Object, e As EventArgs) Handles Load_PB_Data_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True AndAlso IsDate(Me.TillDateEdit.Text) = True Then
            d1 = Me.FromDateEdit.Text
            d2 = Me.TillDateEdit.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                Me.GridControl1.DataSource = Nothing
                Me.GridControl1.MainView = Nothing
                'ALL SEARCH ITEMS
                If Me.SearchLookUpEdit1.Text <> "" Then
                    Me.LabelControl14.Text = "Postings + Balances for GL NGS Account (" & Me.SearchLookUpEdit1.Text & ")-" & Me.LabelControl3.Text & " - CURRENCY:EURO"
                    'ALL
                ElseIf Me.SearchLookUpEdit1.Text = "" Then
                    Me.GridControl1.MainView = All_Postings_Balances_All_GridView
                    Me.LabelControl14.Text = "Postings + Balances for all GL NGS Accounts " & " - CURRENCY:EURO"
                End If
                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                BgwLoad_GL_ACC_Postings = New BackgroundWorker
                bgws.Add(BgwLoad_GL_ACC_Postings)
                BgwLoad_GL_ACC_Postings.WorkerReportsProgress = True
                BgwLoad_GL_ACC_Postings.RunWorkerAsync()

            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Exit Sub
        End If
    End Sub

    Private Sub BgwLoad_GL_ACC_Postings_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoad_GL_ACC_Postings.DoWork
        Try
            If Me.SearchLookUpEdit1.Text <> "" Then
                Me.BgwLoad_GL_ACC_Postings.ReportProgress(10, "Load Postings + Balances for GL Account: " & Me.SearchLookUpEdit1.Text & " from: " & d1 & " till " & d2)

                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "execute [ALL_BALANCES_POSTINGS_SEARCH]  
                                      @FROMDATE='" & rdsql1 & "'
                                     ,@TILLDATE='" & rdsql2 & "'
                                     ,@GL_ACCOUNT_NR='" & Me.SearchLookUpEdit1.Text & "'"
                        Sqlcmd.Connection = Sqlconn
                        Sqlconn.Open()
                        daSqlQueries = New SqlDataAdapter(Sqlcmd.CommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)
                        Sqlconn.Close()
                    End Using
                End Using
            ElseIf Me.SearchLookUpEdit1.Text = "" Then
                Me.BgwLoad_GL_ACC_Postings.ReportProgress(10, "Load Postings + Balances for all GL Accounts from: " & d1 & " till " & d2)
                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = "execute [ALL_BALANCES_POSTINGS_ALL_SEARCH]  
                                            @FROMDATE='" & rdsql1 & "'
                                            ,@TILLDATE='" & rdsql2 & "'"
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
            BgwLoad_GL_ACC_Postings.CancelAsync()

        End Try


    End Sub

    Private Sub BgwLoad_GL_ACC_Postings_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoad_GL_ACC_Postings.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoad_GL_ACC_Postings_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoad_GL_ACC_Postings.RunWorkerCompleted
        Workers_Complete(BgwLoad_GL_ACC_Postings, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.GridControl1.DataSource = Nothing
        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            If Me.SearchLookUpEdit1.Text <> "" Then
                Me.GridControl1.MainView = All_Postings_Balances_GridView
            ElseIf Me.SearchLookUpEdit1.Text = "" Then
                Me.GridControl1.MainView = All_Postings_Balances_All_GridView
            End If
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
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try



    End Sub



    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea

        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = Me.LabelControl14.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        'e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20)
        'e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)


        'Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        'Try
        'iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
        'r = New RectangleF(New PointF(0, 0), iSize)
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
        'pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub AllPostingsNEWG_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class