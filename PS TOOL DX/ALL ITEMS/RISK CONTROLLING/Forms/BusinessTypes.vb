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
Public Class BusinessTypes

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()



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

    Private Sub BusinessTypesCreditPortfolioLiveBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BusinessTypesCreditPortfolioLiveBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub BusinessTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll' table. You can move, or remove it, as needed.

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************

        'Bind Combobox
        Me.BusinessTypeDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[DateMakCrTotals],104) as 'RLDC Date' from [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals] Order by [DateMakCrTotals] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessTypeDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessTypeDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxBusinessTypesDate As Date = Me.BusinessTypeDateEdit.Text
        

        'Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, MaxBusinessTypesDate)
        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByBT_DETAILS(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, MaxBusinessTypesDate)
        'Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, MaxBusinessTypesDate)
        Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByBT_DETAILS(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, MaxBusinessTypesDate)
        'Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, MaxBusinessTypesDate)
        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByBT_ALL(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, MaxBusinessTypesDate)

        Me.XtraTabControl1.Focus()



    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim d As Date = Me.BusinessTypeDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.BusinessTypesCreditPortfolioLiveBindingSource.EndEdit()
                If Me.RiskControllingDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Set DateMakCRTotals date
                        cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] Set [DateMakCrTotals]='" & dsql & "' where [DateMakCrTotals] is NULL"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, Me.BusinessTypeDateEdit.Text)
                        Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, Me.BusinessTypeDateEdit.Text)
                        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, Me.BusinessTypeDateEdit.Text)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                'Remove PARAMETER NAMES
                If Me.GridControl1.FocusedView.Name = "BT_CP_Totals_GridView" Then
                    Dim row As System.Data.DataRow = BT_CP_Totals_GridView.GetDataRow(BT_CP_Totals_GridView.FocusedRowHandle)
                    Dim BusinessType As String = row(1)
                    Dim IDBusinessType As String = row(0)
                    If MessageBox.Show("Should the Business Type: " & BusinessType & " and all his details be deleted?", "DELETE BUSINESS TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        Dim BusinessTypeDelete As RiskControllingDataSet.BusinessTypesCreditPortfolioLiveRow
                        BusinessTypeDelete = RiskControllingDataSet.BusinessTypesCreditPortfolioLive.FindByID(IDBusinessType)
                        BusinessTypeDelete.Delete()
                        BT_CP_Totals_GridView.DeleteSelectedRows()
                        GridControl1.Update()
                        Me.BusinessTypesCreditPortfolioLiveTableAdapter.Update(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive)
                        'Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Delete BusinessTypes Details
                        cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & IDBusinessType & "'"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, Me.BusinessTypeDateEdit.Text)
                        Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, Me.BusinessTypeDateEdit.Text)
                        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, Me.BusinessTypeDateEdit.Text)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)


    End Sub

    Private Sub LoadBusinessTypes_btn_Click(sender As Object, e As EventArgs) Handles LoadBusinessTypes_btn.Click

    End Sub

    Private Sub BT_CP_Totals_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles BT_CP_Totals_GridView.FocusedRowChanged

    End Sub

    Private Sub BT_CP_Totals_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles BT_CP_Totals_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_CP_Totals_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles BT_CP_Totals_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_CP_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BT_CP_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessTypeDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.BusinessTypesCreditPortfolioLiveBindingSource


            If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

                Dim d As Date = Me.BusinessTypeDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Business Types for " & d)
                Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, d)
                Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, d)
                Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
                Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)

            End If
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_Click(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
        End If
    End Sub


    Private Sub BusinessTypeDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BusinessTypeDateEdit.KeyDown
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem3.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub BT_CP_Temp_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles BT_CP_Temp_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_CP_Temp_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles BT_CP_Temp_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_CP_Temp_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Temp_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BT_CP_Temp_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Temp_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BT_CP_Totals_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles BT_CP_Totals_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BUSINESS_TYPE As GridColumn = View.Columns("BusinesType")

        Dim BusinessTypeName As String = View.GetRowCellValue(e.RowHandle, colBusinesType).ToString

        If BusinessTypeName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BUSINESS_TYPE, "The Business Type Name must not be empty")
            e.ErrorText = "The Business Type Name must not be empty"
        End If

    End Sub

    Private Sub BT_CP_Temp_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles BT_CP_Temp_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BUSINESS_TYPE As GridColumn = View.Columns("BusinesType")
        Dim SQL_BUSINESS_TYPE_DETAILS As GridColumn = View.Columns("SQLBusinessTypeDetails")

        Dim BusinessTypeName As String = View.GetRowCellValue(e.RowHandle, colBusinesType1).ToString
        Dim SQLBusinessTypeDetails As String = View.GetRowCellValue(e.RowHandle, colSQLBusinessTypeDetails1).ToString

        If BusinessTypeName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BUSINESS_TYPE, "The Business Type Name must not be empty")
            e.ErrorText = "The Business Type Name must not be empty"
        End If
        If SQLBusinessTypeDetails = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SQL_BUSINESS_TYPE_DETAILS, "The SQL Command for Business Type Details  must not be empty")
            e.ErrorText = "The SQL Command for Business Type Details  must not be empty"
        End If

    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for the current Day be executed again?", "SQL COMMANDS (Current day) EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_Run.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands for current Day")
                Me.BgwSQL_Run.RunWorkerAsync()

            End If
        End If
    End Sub

    Private Sub BgwSQL_Run_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_Run.DoWork
        Try
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Delete Current Data in Details Table
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
            'Execute SQL Commands for Sum
            cmd.CommandText = "UPDATE A SET A.[AmountBusinessType]=B.ABT, A.[NetCreditRiskAmountER1]=B.NCR1, A.[NetCreditRiskAmountER2]=B.NCR2 from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Sum([Credit Outstanding (EUR Equ)]) as ABT,Sum([NetCredit Risk Amount(EUR Equ)]) as NCR1, Sum([NetCreditRiskAmountEUREquER45]) as NCR2 FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive])B on A.[ID]=B.[IdBusinessTypeLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(3, "Execute Summary SQL Commands in Business Types Credit Portfolio")
            'Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'If dt.Rows.Item(i).Item("BusinesType") <> "" Then
            'Sum Credit Risk Amount
            'cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim BusinessTypeAmount As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'BusinessTypeAmount = cmd.ExecuteScalar * 1
            'Else
            'BusinessTypeAmount = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER1
            'cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER1 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER1 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER2
            'cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER2 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER2 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'End If
            'Next
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub BgwSQL_Run_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_Run.RunWorkerCompleted
        Dim d As Date = Me.BusinessTypeDateEdit.Text
        'Load BusinessTypes Data
        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, d)
        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for the current Day be deleted and executed again?", "SQL COMMANDS (Current day) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_ReRun.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Re-executing SQL Commands for current Day")
                Me.BgwSQL_ReRun.RunWorkerAsync()

            End If
        End If
    End Sub

    Private Sub BgwSQL_ReRun_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun.DoWork
        Try
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim rdsql As String = d.ToString("yyyy-MM-dd")
            'Delete Current Data in Details Table
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Neuanlage in BusinessTypesCreditPortfolioLive
            cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [SQL_Name_1],[SQL_Command_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='BUSINESS TYPES - CREDIT PORTFOLIO'"
            cmd.ExecuteNonQuery()
            'Ersetzen der <Risk Date> mit gültigen Risk Datum
            cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [SQLBusinessTypeDetails]= REPLACE([SQLBusinessTypeDetails],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
            'Execute SQL Commands for Sum
            cmd.CommandText = "UPDATE A SET A.[AmountBusinessType]=B.ABT, A.[NetCreditRiskAmountER1]=B.NCR1, A.[NetCreditRiskAmountER2]=B.NCR2 from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Sum([Credit Outstanding (EUR Equ)]) as ABT,Sum([NetCredit Risk Amount(EUR Equ)]) as NCR1, Sum([NetCreditRiskAmountEUREquER45]) as NCR2 FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive])B on A.[ID]=B.[IdBusinessTypeLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(3, "Execute Summary SQL Commands in Business Types Credit Portfolio")
            'Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'If dt.Rows.Item(i).Item("BusinesType") <> "" Then
            'Sum Credit Risk Amount
            'cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim BusinessTypeAmount As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'BusinessTypeAmount = cmd.ExecuteScalar * 1
            'Else
            'BusinessTypeAmount = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER1
            'cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER1 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER1 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER2
            'cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER2 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER2 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'End If
            'Next
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSQL_ReRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun.RunWorkerCompleted
        Dim d As Date = Me.BusinessTypeDateEdit.Text
        'Load BusinessTypes Data
        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, d)
        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_AllDays_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_AllDays_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for all Days be deleted and executed again?", "SQL COMMANDS (ALL DAYS) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_ReRun_All_Days.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Re-executing SQL Commands for all Days")
                Me.BgwSQL_ReRun_All_Days.RunWorkerAsync()


            End If
        End If
    End Sub

    Private Sub BgwSQL_ReRun_All_Days_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun_All_Days.DoWork
        Try
            'Delete Current Data in Details Table
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in BusinessTypesCreditPortfolioDetails ")
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioDetails]"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in BusinessTypesCreditPortfolioLive")
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioLive]"
            cmd.ExecuteNonQuery()
            'Select Riskdate CREDIT RISK
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from CREDIT RISK Report")
            Me.QueryText = "SELECT distinct[RiskDate] FROM [MAK CR TOTALS] ORDER BY [RiskDate] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim d As Date = dt.Rows.Item(i).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                SplashScreenManager.Default.SetWaitFormCaption("Insert Business Types Names and SQL Commands for " & d)
                'Neuanlage in BusinessTypesCreditPortfolioLive
                cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [BusinesType],[SQLBusinessTypeDetails],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='BUSINESS TYPES - CREDIT PORTFOLIO'"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [SQLBusinessTypeDetails]= REPLACE([SQLBusinessTypeDetails],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next
            cmd.Connection.Close()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] ORDER BY [DateMakCrTotals] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Commands for BusinessTypesCreditPortfolioDetails " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] ORDER BY [DateMakCrTotals] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Select Sum from BusinessTypesCreditPortfolioDetails for " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.Connection.Open()
                    cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    'Sume Net Credit Risk Amount ER1
                    cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim NetCreditRiskAmountER1 As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
                    Else
                        NetCreditRiskAmountER1 = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    'Sume Net Credit Risk Amount ER2
                    cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim NetCreditRiskAmountER2 As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
                    Else
                        NetCreditRiskAmountER2 = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub BgwSQL_ReRun_All_Days_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun_All_Days.RunWorkerCompleted
        'Get Max Interest Rate Risk Date
        cmd.CommandText = "SELECT MAX([DateMakCrTotals]) FROM [BusinessTypesCreditPortfolioLive] "
        cmd.Connection.Open()
        Dim MaxBusinessTypesDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.BusinessTypeDateEdit.Text = MaxBusinessTypesDate


        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, MaxBusinessTypesDate)
        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, MaxBusinessTypesDate)

        Me.BT_CP_Totals_GridView.Focus()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Print_Export_BT_CP_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_Totals_Gridview_btn.Click
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
        Dim reportfooter As String = "BUSINESS TYPES - CREDIT PORTFOLIO " & vbNewLine & "on: " & Me.BusinessTypeDateEdit.Text

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

    Private Sub BusinessTypes_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If Me.BT_CP_Totals_GridView.IsFindPanelVisible Then
        '    'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        '    Dim find As FindControl = TryCast(BT_CP_Totals_GridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        '    find.FindEdit.Focus()
        'Else
        '    BT_CP_Totals_GridView.ShowFindPanel()
        'End If

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
       
        Dim dxOK As New DevExpress.XtraEditors.SimpleButton

        With dxOK
            .Text = "Start SQL"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
        End With

        DATES_FORM.Controls.Add(dxOK)
        DATES_FORM.OK_btn.Visible = False

        AddHandler dxOK.Click, AddressOf dxOK_click
       
        DATES_FORM.Show()
        DATES_FORM.Text = "Business Types - SQL Commands Execution"
        DATES_FORM.Text_lbl.Text = "Please input the Period for the SQL Commands execution"
        With DATES_FORM.DateEdit1
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With

        With DATES_FORM.DateEdit2
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
    End Sub

    Private Sub dxOK_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DATES_FORM.DateEdit1.Text) = True And IsDate(DATES_FORM.DateEdit2.Text) = True Then
            FDate = DATES_FORM.DateEdit1.Text
            LDate = DATES_FORM.DateEdit2.Text
            If FDate <= LDate Then
                If Me.BgwSQL_ReRun_SpecificPeriod.IsBusy = False Then
                    DATES_FORM.Cancel_btn.PerformClick()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Re-executing SQL Commands for the specified Period")
                    Me.BgwSQL_ReRun_SpecificPeriod.RunWorkerAsync()

                End If
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("From Date should be less or equal to Till Date" & vbNewLine & "Please check your input!", "WRONG DATES INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub BgwSQL_ReRun_SpecificPeriod_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun_SpecificPeriod.DoWork
        Try
            Dim rdsql1 As String = FDate.ToString("yyyy-MM-dd")
            Dim rdsql2 As String = LDate.ToString("yyyy-MM-dd")
            'Delete Current Data in Details Table
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in BusinessTypesCreditPortfolioDetails for Specific Period ")
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioDetails] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in BusinessTypesCreditPortfolioLive for Specific Period")
            cmd.CommandText = "DELETE from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "'"
            cmd.ExecuteNonQuery()
            'Select Riskdate CREDIT RISK
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from CREDIT RISK Report")
            Me.QueryText = "SELECT distinct[RiskDate] FROM [MAK CR TOTALS] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "' ORDER BY [RiskDate] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim d As Date = dt.Rows.Item(i).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                SplashScreenManager.Default.SetWaitFormCaption("Insert Business Types Names and SQL Commands for " & d)
                'Neuanlage in BusinessTypesCreditPortfolioLive
                cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [BusinesType],[SQLBusinessTypeDetails],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='BUSINESS TYPES - CREDIT PORTFOLIO'"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [SQLBusinessTypeDetails]= REPLACE([SQLBusinessTypeDetails],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next
            cmd.Connection.Close()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "' ORDER BY [DateMakCrTotals] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Commands for BusinessTypesCreditPortfolioDetails " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "' ORDER BY [DateMakCrTotals] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Select Sum from BusinessTypesCreditPortfolioDetails for " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.Connection.Open()
                    cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    'Sume Net Credit Risk Amount ER1
                    cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim NetCreditRiskAmountER1 As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
                    Else
                        NetCreditRiskAmountER1 = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    'Sume Net Credit Risk Amount ER2
                    cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                    Dim NetCreditRiskAmountER2 As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
                    Else
                        NetCreditRiskAmountER2 = 0
                    End If
                    cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSQL_ReRun_SpecificPeriod_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun_SpecificPeriod.RunWorkerCompleted
        'Get Max Interest Rate Risk Date
       
        cmd.CommandText = "SELECT MAX([DateMakCrTotals]) FROM [BusinessTypesCreditPortfolioLive] "
        cmd.Connection.Open()
        Dim MaxBusinessTypesDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.BusinessTypeDateEdit.Text = MaxBusinessTypesDate


        Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, MaxBusinessTypesDate)
        Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, MaxBusinessTypesDate)

        Me.BT_CP_Totals_GridView.Focus()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Print_Export_BT_CP_Temp_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_Temp_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "BUSINESS TYPES - CREDIT PORTFOLIO TOTALS " & "  " & "on: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BT_CP_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_Details_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BT_CP_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BusinessTyperReport_btn_Click(sender As Object, e As EventArgs) Handles BusinessTyperReport_btn.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types - Credit Portfolio Report for " & Me.BusinessTypeDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolio.rpt")
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Business Types - Credit Portfolio Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub Print_Export_BT_CP_DetailsAll_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_CP_DetailsAll_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "BUSINESS TYPES - CREDIT PORTFOLIO (ALL DETAILS) " & "   " & "on: " & Me.BusinessTypeDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_CP_DetailsAll_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles BT_CP_DetailsAll_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.BusinessTypesCreditPortfolioLiveBindingSource


        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then

            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
                'Load BusinessTypes Data
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Business Types - Credit Portfolio for " & d)
                Me.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, d)
                Me.BusinessTypesCreditPortfolioDetailsAllTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioDetailsAll, d)
                Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
                Me.LayoutControlItem3.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)
            
        End If
    End Sub

    Private Sub BT_CP_DetailsAll_Gridview_DoubleClick(sender As Object, e As EventArgs) Handles BT_CP_DetailsAll_Gridview.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "Client No" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ClientNr) = False Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
            If view.FocusedColumn.FieldName = "Contract Collateral ID" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract Collateral ID").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        GLOBAL_CONTRACT_NR = ContractNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomerContractVG.Text = "Details for Contract Nr. " & ContractNr
                        Me.CustomerContractVG.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub
End Class