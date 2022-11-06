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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class DailyBalanceSheetsDetails

    Dim CrystalRepDir As String = ""
    Dim ActiveTabGroup As Double = 0
    Dim ActiveTabGroupQueries As Double = 0

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Private objDataTable As New DataTable

    Dim SqlCommandText As String = Nothing


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

    Private Sub DailyBalanceDetailsSheetsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.DailyBalanceDetailsSheetsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub DailyBalanceSheetsDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[BSDate],104) as 'RLDC Date' from [DailyBalanceSheets] GROUP BY [BSDate] ORDER BY [BSDate] desc"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        For Each row As DataRow In dt1.Rows
            If dt1.Rows.Count > 0 Then
                Me.FromDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt1.Rows.Count > 0 Then
            Me.FromDateEdit.Text = dt1.Rows.Item(0).Item("RLDC Date")
        End If

        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        

        Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
        Me.DailyBalanceDetailsSheets2TableAdapter.FillByBS_Compare(Me.PSTOOLDataset.DailyBalanceDetailsSheets2, d)

        'Fill Balance Sheet 2 details
        Dim da As SqlDataAdapter
        Dim objCMD As SqlCommand = New SqlCommand("Select * from [DailyBalanceDetailsSheets2] where [BSDate]=' " & dsql & "' order by [ID] asc", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl3.DataSource = Nothing
            Me.GridControl3.DataSource = dt
            Me.GridControl3.ForceInitialize()
        End If

        LayoutControlGroup4.Visibility = LayoutVisibility.Never
        LayoutControlGroup3.Visibility = LayoutVisibility.Never

    End Sub

    Private Sub LoadDailyBalanceSheets_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.DailyBalanceDetailsSheets2BindingSource
            Me.GridControl2.DataSource = Me.DailyBalanceDetailsSheetsBindingSource

            Me.GridControl4.DataSource = Nothing

            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Details for " & d)
                'Load Balance Sheet
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                Me.DailyBalanceDetailsSheets2TableAdapter.FillByBS_Compare(Me.PSTOOLDataset.DailyBalanceDetailsSheets2, d)
                'Fill Balance Sheet 2 details
                Dim da As SqlDataAdapter
                Dim objCMD As SqlCommand = New SqlCommand("Select * from [DailyBalanceDetailsSheets2] where [BSDate]=' " & dsql & "' order by [ID] asc", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                dt = New DataTable()
                da.Fill(dt)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Me.GridControl3.DataSource = Nothing
                    Me.GridControl3.DataSource = dt
                    Me.GridControl3.ForceInitialize()

                End If

                If d <= DateSerial(2017, 12, 8) Then
                    LayoutControlGroup4.Visibility = LayoutVisibility.Always
                    LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Else
                    LayoutControlGroup4.Visibility = LayoutVisibility.Never
                    LayoutControlGroup3.Visibility = LayoutVisibility.Never
                End If

                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FromDateEdit.KeyDown
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
        End If
    End Sub

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 1 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        
        
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
        Dim reportfooter As String = "Balance Sheet 1 Details" & "   " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "Balance Sheet 2 Details" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "Balance Sheet 1 + 2 Details - Compared" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Balance Sheet 1 - Details" Then
            ActiveTabGroup = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Balance Sheet 2 - Details" Then
            ActiveTabGroup = 2
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Balance Sheet 1-2 Compared" Then
            ActiveTabGroup = 1
        End If

    End Sub

    Private Sub TabbedControlGroup2_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup2.SelectedPageChanged
        If Me.TabbedControlGroup2.SelectedTabPage.Text = "Search for Accounts not included in the Balance Sheet" Then
            ActiveTabGroupQueries = 0

        End If
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalHeaderArea
        Dim reportfooter As String = "Accounts not included in the Balance Sheet" & "  " & "Date: " & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BalanceSheetDetails_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BalanceSheetDetails_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BalanceSheetDetails_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles BalanceSheetDetails_BaseView.ShownEditor
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
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs) Handles GridView3.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.DailyBalanceDetailsSheets2BindingSource
        Me.GridControl2.DataSource = Me.DailyBalanceDetailsSheetsBindingSource

        Me.GridControl4.DataSource = Nothing

        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Details for " & d)
                'Load Balance Sheet
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                Me.DailyBalanceDetailsSheets2TableAdapter.FillByBS_Compare(Me.PSTOOLDataset.DailyBalanceDetailsSheets2, d)
                'Fill Balance Sheet 2 details
                Dim da As SqlDataAdapter
                Dim objCMD As SqlCommand = New SqlCommand("Select * from [DailyBalanceDetailsSheets2] where [BSDate]=' " & dsql & "' order by [ID] asc", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                dt = New DataTable()
                da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                Me.GridControl3.DataSource = Nothing
                Me.GridControl3.DataSource = dt
                Me.GridControl3.ForceInitialize()

            End If
            If d <= DateSerial(2017, 12, 8) Then
                LayoutControlGroup4.Visibility = LayoutVisibility.Always
                LayoutControlGroup3.Visibility = LayoutVisibility.Always
            Else
                LayoutControlGroup4.Visibility = LayoutVisibility.Never
                LayoutControlGroup3.Visibility = LayoutVisibility.Never
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub TrialBalanceBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TrialBalanceBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TrialBalanceBaseView_ShownEditor(sender As Object, e As EventArgs) Handles TrialBalanceBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub NoAccountsDBSExecutedQuery_btn_Click(sender As Object, e As EventArgs) Handles NoAccountsDBSExecutedQuery_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")

            'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("execute stored procedure ACCOUNTS_NOT_IN_DBS for " & d)
            'Fill not included GL Accounts in Daily Balance Sheet
            'Dim da2 As SqlDataAdapter
            'Dim objCMD2 As SqlCommand = New SqlCommand("exec [ACCOUNTS_NOT_IN_DBS] @RISKDATE=' " & dsql & "'", conn)
            'objCMD2.CommandTimeout = 5000
            'da2 = New SqlDataAdapter(objCMD2)
            'dt2 = New DataTable()
            'da2.Fill(dt2)
            'If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
            'Me.GridControl4.DataSource = Nothing
            'Me.GridControl4.DataSource = dt2
            'Me.GridControl4.ForceInitialize()
            'End If
            'SplashScreenManager.CloseForm(False)


            Try

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Accounts not in Daily Balance Sheet" & vbNewLine & "(SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/ACCOUNTS_NOT_IN_DBS) for: " & d)

                Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('ACCOUNTS_NOT_IN_DBS') and Status in ('Y')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", dsql)


                    'Data reader
                    Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                        Using sqlCmd As New SqlCommand()
                            sqlCmd.CommandText = SqlCommandText
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
                        'Me.GridControl4.BeginUpdate()
                        Me.GridControl4.DataSource = Nothing
                        'Me.GridControl1.Refresh()
                        Me.GridControl4.DataSource = objDataTable
                        Me.GridControl4.ForceInitialize()
                        'Me.LCR_Details_GridView.PopulateColumns()
                        'Me.LCR_Details_GridView.BestFitColumns()
                        'Me.GridControl4.RefreshDataSource()
                        SplashScreenManager.CloseForm(False)
                    Else
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("The SQL Command:SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/ACCOUNTS_NOT_IN_DBS is either deactivated or not present!", "NO SQL COMMAND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If


            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try

        End If

    End Sub

   
    Private Sub PrintExportQueries_btn_Click(sender As Object, e As EventArgs) Handles PrintExportQueries_btn.Click
        If ActiveTabGroupQueries = 0 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink6.CreateDocument()
            PrintableComponentLink6.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
End Class