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
    Dim rdsql1 As String
    Dim rdsql2 As String

    Dim OCBSaccountNamelbl As String = Nothing
    Dim OCBSaccountlbl As String = Nothing
    Dim OCBSaccountCurlbl As String = Nothing
    Dim OCBSDatefromlbl As String = Nothing
    Dim OCBSDatetilllbl As String = Nothing

    Private BS_AllContractsAccounts As BindingSource

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

    Private Sub GL_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.GL_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BalancesDataset)

    End Sub

    Private Sub AllPostingsNEWG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.GL_ACCOUNTS_NEWGTableAdapter.Fill(Me.BalancesNEWGDataset.GL_ACCOUNTS_NEWG)
        ALL_CONTRACTS_ACCOUNTS_initData()
        ALL_CONTRACTS_ACCOUNTS_InitLookUp()

        'Bind Combobox Currencies
        Me.ComboBoxEdit1.Properties.Items.Clear()
        Me.QueryText = "SELECT '***' as 'CURRENCY CODE' UNION ALL SELECT [CURRENCY CODE] FROM [OWN_CURRENCIES]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.ComboBoxEdit1.Properties.Items.Add(row("CURRENCY CODE"))
            End If
        Next

        'Get Forelast Date and fill DateEdits
        Dim d As Date = DateAdd(DateInterval.Day, -1, Today)
        BookingDate_From.EditValue = d
        BookingDate_Till.EditValue = d
        BookingDateContractFrom_DateEdit.EditValue = d
        BookingDateContractTill_DateEdit.EditValue = d
        FromDateEdit.EditValue = d
        TillDateEdit.EditValue = d
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
                'If IsNothing(Me.LookUpEdit2.Text) = False AndAlso IsNumeric(Me.LookUpEdit2.Text) = True AndAlso IsNothing(Me.ComboBoxEdit1.Text) = False Then
                If Me.LookUpEdit2.Text <> "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                    Try

                        'Account Name finden
                        cmd.CommandTimeout = 120
                        cmd.CommandText = "SELECT [NEWG_GL_ACC_Name] from [GL_ACCOUNTS_NEWG] where [NEWG_GL_ACC_Nr]='" & Me.LookUpEdit2.Text & "'"
                        cmd.Connection.Open()
                        Me.LabelControl8.Text = cmd.ExecuteScalar
                        OCBSaccountNamelbl = Me.LabelControl8.Text
                        OCBSaccountlbl = Me.LookUpEdit2.Text
                        OCBSaccountCurlbl = Me.ComboBoxEdit1.Text
                        OCBSDatefromlbl = Me.BookingDate_From.Text
                        OCBSDatetilllbl = Me.BookingDate_Till.Text
                        cmd.Connection.Close()

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        If Me.ComboBoxEdit1.Text = "***" Then
                            SplashScreenManager.Default.SetWaitFormCaption("Load Postings for GL Account: " & Me.LookUpEdit2.Text & vbNewLine & "for all currencies from: " & d1 & " till " & d2)
                            FILL_Specific_GL_ACCOUNT_BOOKINGS_ALL_CURRENCIES_DATATABLE()
                            'Data reader
                            'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            '    Using sqlCmd As New SqlCommand()
                            '        sqlCmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  (GL_AC_No = '" & Me.LookUpEdit2.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') ORDER BY IdNr"
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


                            Me.LabelControl14.Text = "Postings for GL NEWG Account (" & Me.LookUpEdit2.Text & ")-" & Me.LabelControl8.Text & " - ALL CURRENCIES"

                        ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                            SplashScreenManager.Default.SetWaitFormCaption("Load Postings for GL Account: " & Me.LookUpEdit2.Text & vbNewLine & "Currency:" & Me.ComboBoxEdit1.Text & " from: " & d1 & " till " & d2)
                            FILL_Specific_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()
                            'Data reader
                            'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            '    Using sqlCmd As New SqlCommand()
                            '        sqlCmd.CommandText = "SELECT * FROM  ALL_VOLUMES WHERE  (GL_AC_No = '" & Me.LookUpEdit2.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND (CCY = '" & Me.ComboBoxEdit1.Text & "') ORDER BY IdNr"
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

                            Me.LabelControl14.Text = "Postings for GL NEWG Account (" & Me.LookUpEdit2.Text & ")-" & Me.LabelControl8.Text & " -Currency: " & Me.ComboBoxEdit1.Text

                        End If
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try

                    'ONLY CURRENCY
                ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text <> "" Then
                    Try
                        OCBSaccountCurlbl = Me.ComboBoxEdit1.Text
                        OCBSDatefromlbl = Me.BookingDate_From.Text
                        OCBSDatetilllbl = Me.BookingDate_Till.Text
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        If Me.ComboBoxEdit1.Text = "***" Then
                            SplashScreenManager.Default.SetWaitFormCaption("Load all Postings from: " & d1 & " till " & d2)
                            FILL_ALL_GL_ACCOUNT_BOOKINGS_ALL_CURRENCY_DATATABLE()

                            'Data reader
                            'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            '    Using sqlCmd As New SqlCommand()
                            '        sqlCmd.CommandText = "SELECT  * FROM   ALL_VOLUMES WHERE  ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') ORDER BY IdNr"
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

                            Me.LabelControl14.Text = "Postings for all GL NEWG Accounts " & " - ALL CURRENCIES"

                        ElseIf Me.ComboBoxEdit1.Text <> "***" Then
                            SplashScreenManager.Default.SetWaitFormCaption("Load all Postings for Currency:" & Me.ComboBoxEdit1.Text & vbNewLine & "from: " & d1 & " till " & d2)
                            FILL_ALL_GL_ACCOUNT_BOOKINGS_Specific_CURRENCY_DATATABLE()

                            'Data reader
                            'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            '    Using sqlCmd As New SqlCommand()
                            '        sqlCmd.CommandText = "SELECT  * FROM   ALL_VOLUMES WHERE  ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') AND (CCY = '" & Me.ComboBoxEdit1.Text & "') ORDER BY IdNr"
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

                            Me.LabelControl14.Text = "Postings for all GL NEWG Accounts " & " - Currency:" & Me.ComboBoxEdit1.Text

                        End If
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                    End Try

                    'ONLY DATES
                ElseIf Me.LookUpEdit2.Text = "" AndAlso Me.ComboBoxEdit1.Text = "" Then
                    Try
                        OCBSDatefromlbl = Me.BookingDate_From.Text
                        OCBSDatetilllbl = Me.BookingDate_Till.Text
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load all Postings from: " & d1 & " till " & d2)
                        FILL_ALL_GL_ACCOUNT_BOOKINGS_ALL_CURRENCY_DATATABLE()

                        'Data reader
                        'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        '    Using sqlCmd As New SqlCommand()
                        '        sqlCmd.CommandText = "SELECT  * FROM   ALL_VOLUMES WHERE  ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') ORDER BY IdNr"
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


                        Me.LabelControl14.Text = "Postings for all GL NEWG Accounts " & " - ALL CURRENCIES"


                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                    End Try
                End If

                'Results Datareader
                'If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                '    Me.GridControl1.DataSource = Nothing
                '    Me.GridControl1.DataSource = objDataTable
                '    Me.GridControl1.MainView = AllPostings_BasicView
                '    Me.GridControl1.ForceInitialize()
                '    Me.GridControl1.RefreshDataSource()
                '    SplashScreenManager.CloseForm(False)
                'Else
                '    SplashScreenManager.CloseForm(False)
                '    XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Return
                'End If

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
        Dim reportfooter As String = Me.LabelControl14.Text & " from " & OCBSDatefromlbl & " till " & OCBSDatetilllbl
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

#Region "GRIDVIEW STYLES"
    Private Sub AllPostings_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllPostings_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllPostings_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles AllPostings_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView4_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView4.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GridView4_ShownEditor(sender As Object, e As EventArgs) Handles GridView4.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub All_Postings_Balances_All_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Postings_Balances_All_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub All_Postings_Balances_All_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Postings_Balances_All_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub All_Postings_Balances_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Postings_Balances_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub All_Postings_Balances_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Postings_Balances_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AllContractsAccounts_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllContractsAccounts_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllContractsAccounts_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AllContractsAccounts_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

#End Region


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
                'If IsNothing(Me.LookUpEdit2.Text) = False AndAlso IsNumeric(Me.LookUpEdit2.Text) = True AndAlso IsNothing(Me.ComboBoxEdit1.Text) = False Then
                If Me.SearchLookUpEdit1.Text <> "" Then

                    Try

                        'Account Name finden
                        cmd.CommandTimeout = 120
                        cmd.CommandText = "SELECT [NEWG_GL_ACC_Name] from [GL_ACCOUNTS_NEWG] where [NEWG_GL_ACC_Nr]='" & Me.SearchLookUpEdit1.Text & "'"
                        cmd.Connection.Open()
                        Me.LabelControl3.Text = cmd.ExecuteScalar
                        OCBSaccountNamelbl = Me.LabelControl3.Text
                        OCBSaccountlbl = Me.SearchLookUpEdit1.Text
                        OCBSaccountCurlbl = "EUR"
                        OCBSDatefromlbl = Me.FromDateEdit.Text
                        OCBSDatetilllbl = Me.TillDateEdit.Text
                        cmd.Connection.Close()

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Postings + Balances for GL Account: " & Me.SearchLookUpEdit1.Text & vbNewLine & "from: " & d1 & " till " & d2)

                        'Data reader
                        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            Using sqlCmd As New SqlCommand()
                                sqlCmd.CommandText = "execute [ALL_BALANCES_POSTINGS_SEARCH]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "',@GL_ACCOUNT_NR='" & Me.SearchLookUpEdit1.Text & "'"
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


                        Me.LabelControl14.Text = "Postings + Balances for GL NEWG Account (" & Me.SearchLookUpEdit1.Text & ")-" & Me.LabelControl3.Text & " - CURRENCY:EURO"


                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)


                    End Try


                    'ONLY CURRENCY
                ElseIf Me.SearchLookUpEdit1.Text = "" Then
                    Me.GridControl1.MainView = All_Postings_Balances_All_GridView
                    Try
                        OCBSaccountCurlbl = "EUR"
                        OCBSDatefromlbl = Me.FromDateEdit.Text
                        OCBSDatetilllbl = Me.TillDateEdit.Text
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Postings + Balances from: " & d1 & " till " & d2)



                        'Data reader
                        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                            Using sqlCmd As New SqlCommand()
                                sqlCmd.CommandText = "execute [ALL_BALANCES_POSTINGS_ALL_SEARCH]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "'"
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

                        Me.LabelControl14.Text = "Postings + Balances for all GL NEWG Accounts " & " - CURRENCY:EURO"


                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)


                    End Try

                End If

                'Results Datareader
                If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                    Me.GridControl1.DataSource = Nothing
                    Me.GridControl1.DataSource = objDataTable
                    Me.GridControl1.MainView = All_Postings_Balances_GridView
                    Me.GridControl1.ForceInitialize()
                    Me.GridControl1.RefreshDataSource()
                    SplashScreenManager.CloseForm(False)
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If


            Else
                SplashScreenManager.CloseForm(False)
                MsgBox("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", MsgBoxStyle.Exclamation, "Wrong Search criteria")
            End If

        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Exit Sub
        End If
    End Sub


    Private Sub LookUpEdit2_TextChanged(sender As Object, e As EventArgs) Handles LookUpEdit2.TextChanged
        If Me.LookUpEdit2.Text = "" Then
            Me.LabelControl8.Text = ""
        End If
    End Sub

    Private Sub SearchLookUpEdit1_TextChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.TextChanged
        If Me.SearchLookUpEdit1.Text = "" Then
            Me.LabelControl3.Text = ""
        End If

    End Sub

    Private Sub ContractLookUpEdit_TextChanged(sender As Object, e As EventArgs) Handles ContractLookUpEdit.TextChanged
        If Me.ContractLookUpEdit.Text = "" Then
            Me.ContractName_lbl.Text = ""
        End If
    End Sub


    Private Sub LoadDataContract_btn_Click(sender As Object, e As EventArgs) Handles LoadDataContract_btn.Click
        If IsDate(Me.BookingDateContractFrom_DateEdit.Text) = True AndAlso IsDate(Me.BookingDateContractTill_DateEdit.Text) = True Then
            d1 = Me.BookingDateContractFrom_DateEdit.Text
            d2 = Me.BookingDateContractTill_DateEdit.Text
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                Me.GridControl1.MainView = Nothing
                Me.GridControl1.DataSource = Nothing

                'ALL SEARCH ITEMS
                If Me.ContractLookUpEdit.Text <> "" Then
                    Try

                        'Account Name finden
                        cmd.CommandTimeout = 120
                        cmd.CommandText = "SELECT [ClientName] from [ALL_CONTRACTS_ACCOUNTS] where [Contract_Account]='" & Me.ContractLookUpEdit.Text & "'"
                        cmd.Connection.Open()
                        Me.ContractName_lbl.Text = cmd.ExecuteScalar
                        OCBSaccountNamelbl = Me.ContractName_lbl.Text
                        OCBSaccountlbl = Me.ContractLookUpEdit.Text
                        OCBSaccountCurlbl = Nothing
                        OCBSDatefromlbl = Me.BookingDateContractFrom_DateEdit.Text
                        OCBSDatetilllbl = Me.BookingDateContractTill_DateEdit.Text
                        cmd.Connection.Close()

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Postings for Contract/Account: " & Me.ContractLookUpEdit.Text & vbNewLine & "for all currencies from: " & d1 & " till " & d2)

                        FILL_CONTRACT_DATA_DATATABLE()

                        'Data reader
                        'Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        '    Using sqlCmd As New SqlCommand()
                        '        sqlCmd.CommandText = "SELECT * FROM   ALL_VOLUMES WHERE  ([AccountNo] = '" & Me.ContractLookUpEdit.Text & "') AND ([Value Date] >= '" & rdsql1 & "') AND ([Value Date] <= '" & rdsql2 & "') ORDER BY IdNr"
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


                        Me.LabelControl14.Text = "Postings for Contract/Account (" & Me.ContractLookUpEdit.Text & ")- " & Me.ContractName_lbl.Text & " - ALL CURRENCIES"


                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                    End Try



                    ''Results Datareader
                    'If objDataTable IsNot Nothing AndAlso objDataTable.Rows.Count > 0 Then
                    '    Me.GridControl1.DataSource = Nothing
                    '    Me.GridControl1.DataSource = objDataTable
                    '    Me.GridControl1.MainView = AllPostings_BasicView
                    '    Me.GridControl1.ForceInitialize()
                    '    Me.GridControl1.RefreshDataSource()
                    '    SplashScreenManager.CloseForm(False)
                    'Else
                    '    SplashScreenManager.CloseForm(False)
                    '    XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    Return
                    'End If

                End If
            Else
                SplashScreenManager.CloseForm(False)
                MsgBox("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", MsgBoxStyle.Exclamation, "Wrong Search criteria")
            End If

        Else
            XtraMessageBox.Show("Missing Data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Exit Sub
        End If



    End Sub


End Class