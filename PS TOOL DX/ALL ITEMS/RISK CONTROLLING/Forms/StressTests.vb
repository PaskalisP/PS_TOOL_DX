Imports System
Imports System.IO
Imports System.Data.OleDb
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
Public Class StressTests

    Dim conn As New OleDbConnection
    Dim cmd As New OleDbCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New OleDbDataAdapter
    Private dt As New DataTable
    Private da1 As New OleDbDataAdapter
    Private dt1 As New DataTable
    Private da2 As New OleDbDataAdapter
    Private dt2 As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date


    Sub New()
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")
    End Sub

    Private Sub MAK_CR_TOTALSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MAK_CR_TOTALSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub StressTests_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PSTOOLConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        'Get Max Interest Rate Risk Date
        cmd.CommandText = "SELECT MAX([RiskDate]) FROM [MAK CR TOTALS] "
        Dim MaxStressDate As Date = cmd.ExecuteScalar
        Me.BusinessTypeDateEdit.Text = MaxStressDate
        cmd.Connection.Close()

        Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, MaxStressDate)
        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, MaxStressDate)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, MaxStressDate)

    End Sub
    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim d As Date = Me.BusinessTypeDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.StressTestsLiveBindingSource.EndEdit()
                If Me.RiskControllingDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Set DateMakCRTotals date
                        cmd.CommandText = "UPDATE [StressTestsLive] Set [DateMakCrTotals]='" & dsql & "' where [DateMakCrTotals] is NULL"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, Me.BusinessTypeDateEdit.Text)
                        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, Me.BusinessTypeDateEdit.Text)
                        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, Me.BusinessTypeDateEdit.Text)
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
                'Remove 
                If Me.GridControl1.FocusedView.Name = "BT_ST_Totals_GridView" Then
                    Dim row As System.Data.DataRow = BT_ST_Totals_GridView.GetDataRow(BT_ST_Totals_GridView.FocusedRowHandle)
                    Dim BusinessType As String = row(1)
                    Dim IDBusinessType As String = row(0)
                    If MessageBox.Show("Should the Business Type: " & BusinessType & " and all his details be deleted?", "DELETE BUSINESS TYPE-STRESS TEST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim BusinessTypeDelete As RiskControllingDataSet.StressTestsLiveRow
                        BusinessTypeDelete = RiskControllingDataSet.StressTestsLive.FindByID(IDBusinessType)
                        BusinessTypeDelete.Delete()
                        BT_ST_Totals_GridView.DeleteSelectedRows()
                        GridControl1.Update()
                        Me.StressTestsLiveTableAdapter.Update(Me.RiskControllingDataSet.StressTestsLive)
                        'Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Delete BusinessTypes Details
                        cmd.CommandText = "DELETE FROM [StressTestsLiveDetails] where [IdBusinessTypeLive]='" & IDBusinessType & "'"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, Me.BusinessTypeDateEdit.Text)
                        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, Me.BusinessTypeDateEdit.Text)
                        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, Me.BusinessTypeDateEdit.Text)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.StressTestsTempBindingSource.EndEdit()
                If Me.RiskControllingDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.StressTestsTempTableAdapter.Update(Me.RiskControllingDataSet.StressTestsTemp)
                        Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
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
                'Remove 
                If Me.GridControl2.FocusedView.Name = "BT_ST_Temp_GridView" Then
                    Dim row As System.Data.DataRow = BT_ST_Temp_GridView.GetDataRow(BT_ST_Temp_GridView.FocusedRowHandle)
                    Dim BusinessType As String = row(1)
                    Dim IDBusinessType As String = row(0)
                    If MessageBox.Show("Should the Business Type: " & BusinessType & " be deleted?", "DELETE BUSINESS TYPE-STRESS TESTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim BusinessTypeDelete As RiskControllingDataSet.StressTestsTempRow
                        BusinessTypeDelete = RiskControllingDataSet.StressTestsTemp.FindByID(IDBusinessType)
                        BusinessTypeDelete.Delete()
                        BT_ST_Temp_GridView.DeleteSelectedRows()
                        GridControl2.Update()
                        Me.StressTestsTempTableAdapter.Update(Me.RiskControllingDataSet.StressTestsTemp)
                        'Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)
                        'Delete BusinessTypes Details
                        Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
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

    Private Sub LoadBusinessTypes_btn_Click(sender As Object, e As EventArgs) Handles LoadBusinessTypes_btn.Click
        Me.GridControl1.DataSource = Me.StressTestsLiveBindingSource
        Me.GridControl2.DataSource = Me.StressTestsTempBindingSource

        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            cmd.CommandText = "Select [RiskDate] from [MAK CR TOTALS] where [RiskDate]='" & dsql & "' "
            cmd.Connection.Open()
            If IsDate(cmd.ExecuteScalar) = True Then
                'Load BusinessTypes Data
                Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
                Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, d)
                Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, d)
                Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)
                Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            Else
                MessageBox.Show("There's no Data for the indicated Date!", "NO DATA FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Get Max BusinessTypesDate
                cmd.CommandText = "SELECT MAX([RiskDate]) FROM [MAK CR TOTALS] "
                Dim MaxStressDate As Date = cmd.ExecuteScalar
                Me.BusinessTypeDateEdit.Text = MaxStressDate
                Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
                Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, MaxStressDate)
                Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, MaxStressDate)
                Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, MaxStressDate)
                Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            End If
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub StressTests_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Me.BT_ST_Totals_GridView.IsFindPanelVisible Then
            'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
            Dim find As FindControl = TryCast(BT_ST_Totals_GridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        Else
            BT_ST_Totals_GridView.ShowFindPanel()
        End If
    End Sub

    Private Sub BT_ST_Totals_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles BT_ST_Totals_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_ST_Totals_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles BT_ST_Totals_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_ST_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_ST_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BT_ST_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_ST_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_Click(sender As Object, e As EventArgs) Handles BusinessTypeDateEdit.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub BusinessTypeDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles BusinessTypeDateEdit.KeyDown
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub BT_ST_Temp_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles BT_ST_Temp_GridView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_ST_Temp_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles BT_ST_Temp_GridView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub BT_ST_Temp_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_ST_Temp_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BT_ST_Temp_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_ST_Temp_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BT_ST_Totals_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles BT_ST_Totals_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BUSINESS_TYPE As GridColumn = View.Columns("BusinesType")
        Dim PD_STRESS As GridColumn = View.Columns("PDunderStress")
        Dim SQL_TYPE_DEFINITION As GridColumn = View.Columns("SQLBusinessTypeDefinition")
        Dim SQL_BUSINESS_TYPE_AMOUNT As GridColumn = View.Columns("SQLBusinessTypeAmount")

        Dim BusinessTypeName As String = View.GetRowCellValue(e.RowHandle, colBusinesType).ToString
        Dim PDStressPercent As String = View.GetRowCellValue(e.RowHandle, colPDunderStress).ToString
        Dim SQLtypeDefinition As String = View.GetRowCellValue(e.RowHandle, colSQLBusinessTypeDefinition).ToString
        Dim SQLtypeAmount As String = View.GetRowCellValue(e.RowHandle, colSQLBusinessTypeAmount).ToString

        If BusinessTypeName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BUSINESS_TYPE, "The Business Type Name must not be empty")
            e.ErrorText = "The Business Type Name must not be empty"
        End If
        If PDStressPercent = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PD_STRESS, "The PDunderStress must not be empty")
            e.ErrorText = "The PDunderStress must not be empty"
        End If
        If SQLtypeDefinition = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SQL_TYPE_DEFINITION, "The SQL Business Type defrinition must not be empty")
            e.ErrorText = "The SQL Business Type defrinition must not be empty"
        End If
        If SQLtypeAmount = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SQL_BUSINESS_TYPE_AMOUNT, "The SQL Business Type Amount must not be empty")
            e.ErrorText = "The SQL Business Type Amount must not be empty"
        End If
    End Sub

    Private Sub BT_ST_Temp_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles BT_ST_Temp_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim BUSINESS_TYPE As GridColumn = View.Columns("BusinesType")
        Dim SQL_BUSINESS_TYPE_DEFINITION As GridColumn = View.Columns("SQLBusinessTypeDefinition")
        Dim SQL_BUSINESS_TYPE_AMOUNT As GridColumn = View.Columns("SQLBusinessTypeAmount")

        Dim BusinessTypeName As String = View.GetRowCellValue(e.RowHandle, colBusinesType1).ToString
        Dim SQLBusinessTypeDefinition As String = View.GetRowCellValue(e.RowHandle, colSQLBusinessTypeDefinition1).ToString
        Dim SQLBusinessTypeAmount As String = View.GetRowCellValue(e.RowHandle, colSQLBusinessTypeAmount1).ToString

        If BusinessTypeName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(BUSINESS_TYPE, "The Business Type Name must not be empty")
            e.ErrorText = "The Business Type Name must not be empty"
        End If
        If SQLBusinessTypeDefinition = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SQL_BUSINESS_TYPE_DEFINITION, "The SQL Command for Business Type Definition  must not be empty")
            e.ErrorText = "The SQL Command for Business Type Definition  must not be empty"
        End If
        If SQLBusinessTypeAmount = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SQL_BUSINESS_TYPE_AMOUNT, "The SQL Command for Business Type Amount  must not be empty")
            e.ErrorText = "The SQL Command for Business Type Amount  must not be empty"
        End If
    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for the current Day be executed again?", "SQL COMMANDS (Current day) EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_Run.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Commands for current Day-Stress Tests")
                Me.BgwSQL_Run.RunWorkerAsync()

            End If
        End If
    End Sub

    Private Sub BgwSQL_Run_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_Run.DoWork
        Try
            cmd.Connection.Open()
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Delete Current Data in Details Table and Insert MAK Report for specific Date
            cmd.CommandText = "DELETE from [StressTestsLiveDetails] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")
                    cmd.ExecuteNonQuery()
                End If
            Next
            '****************************************************************************************************
            'Set StressNewAmount=EuroEquivalent in StressTestsLive Details
            cmd.CommandText = "UPDATE [StressTestsLiveDetails]  SET [StressNewAmount]=[Euro Equivalent] Where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '***************************************************************************************************
            'INTERNAL GUARANTESS DEFINIEREN
            Me.QueryText = "select * from [INTERNAL GUARANTEES]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='INTERNAL GUARANTEE',[StressNewAmount]=0 Where [RiskDate]='" & rdsql & "'  and [Contract Collateral ID]='" & dt.Rows.Item(i).Item("ContractCollateralID") & "'"
                cmd.ExecuteNonQuery()
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'CASH PLEDGE DEFINIEREN-SQL
            Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='CASHCOVER' Where [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                cmd.ExecuteNonQuery()
                Me.QueryText = "select * from [StressTestsLiveDetails]  Where [RiskDate]='" & rdsql & "' and [InternalCode]='CASHCOVER' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                da1 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                For y = 0 To dt1.Rows.Count - 1
                    Dim EuroEquivalent As Double = dt1.Rows.Item(y).Item("Euro Equivalent")
                    If EuroEquivalent < CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                    ElseIf EuroEquivalent > CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]='" & Str(EuroEquivalent - CashPledgeAmount) & "' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                    ElseIf EuroEquivalent = CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = 0
                    End If
                Next
            Next
            '*******************************************************************************************************
            'Update PDAmount
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [PDAmount]=[StressNewAmount]*[StressPercent] Where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeAmount")
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next
            cmd.Connection.Close()
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
        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, d)
        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, d)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for the current Day be deleted and executed again?", "SQL COMMANDS (Current day) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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
            cmd.Connection.Open()
            cmd.CommandText = "DELETE from [StressTestsLiveDetails] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE  FROM [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Neuanlage in StressTestsLive
            cmd.CommandText = "INSERT INTO [StressTestsLive]([BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],[DateMakCrTotals])Select [BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],'" & rdsql & "' FROM [StressTestsTemp]"
            cmd.ExecuteNonQuery()
            'Ersetzen der <Risk Date> mit gültigen Risk Datum
            cmd.CommandText = "UPDATE [StressTestsLive] SET [SQLBusinessTypeDefinition]= REPLACE([SQLBusinessTypeDefinition],'<RiskDate>','" & rdsql & "'),[SQLBusinessTypeAmount]=REPLACE([SQLBusinessTypeAmount],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Details
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")
                    cmd.ExecuteNonQuery()
                End If
            Next
            '****************************************************************************************************
            'Set StressNewAmount=EuroEquivalent in StressTestsLive Details
            cmd.CommandText = "UPDATE [StressTestsLiveDetails]  SET [StressNewAmount]=[Euro Equivalent] Where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '***************************************************************************************************
            'INTERNAL GUARANTESS DEFINIEREN
            Me.QueryText = "select * from [INTERNAL GUARANTEES]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='INTERNAL GUARANTEE',[StressNewAmount]=0 Where [RiskDate]='" & rdsql & "'  and [Contract Collateral ID]='" & dt.Rows.Item(i).Item("ContractCollateralID") & "'"
                cmd.ExecuteNonQuery()
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'CASH PLEDGE DEFINIEREN-SQL
            Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='CASHCOVER' Where [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                cmd.ExecuteNonQuery()
                Me.QueryText = "select * from [StressTestsLiveDetails]  Where [RiskDate]='" & rdsql & "' and [InternalCode]='CASHCOVER' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                da1 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                For y = 0 To dt1.Rows.Count - 1
                    Dim EuroEquivalent As Double = dt1.Rows.Item(y).Item("Euro Equivalent")
                    If EuroEquivalent < CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                    ElseIf EuroEquivalent > CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]='" & Str(EuroEquivalent - CashPledgeAmount) & "' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                    ElseIf EuroEquivalent = CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = 0
                    End If
                Next
            Next
            '*******************************************************************************************************
            'Update PDAmount
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [PDAmount]=[StressNewAmount]*[StressPercent] Where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeAmount")
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next
            cmd.Connection.Close()
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
        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, d)
        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, d)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_AllDays_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_AllDays_BarButtonItem.ItemClick
        If MessageBox.Show("Should the SQL Commands for all Days be deleted and executed again?", "SQL COMMANDS (ALL DAYS) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLiveDetails ")
            cmd.CommandText = "DELETE from [StressTestsLiveDetails]"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLive")
            cmd.CommandText = "DELETE  FROM [StressTestsLive]"
            cmd.ExecuteNonQuery()
            'Select Riskdate CREDIT RISK
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from MAK Report")
            Me.QueryText = "SELECT distinct[RiskDate] FROM [MAK CR TOTALS] ORDER BY [RiskDate] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim d As Date = dt.Rows.Item(i).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                SplashScreenManager.Default.SetWaitFormCaption("Insert Business Types Names and SQL Commands (Stress Tests) for " & d)
                'Neuanlage in StressTestsLive
                cmd.CommandText = "INSERT INTO [StressTestsLive]([BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],[DateMakCrTotals])Select [BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],'" & rdsql & "' FROM [StressTestsTemp]"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [StressTestsLive] SET [SQLBusinessTypeDefinition]= REPLACE([SQLBusinessTypeDefinition],'<RiskDate>','" & rdsql & "'),[SQLBusinessTypeAmount]=REPLACE([SQLBusinessTypeAmount],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next

            'Execute SQL Commands for Details
            Me.QueryText = "select * from [StressTestsLive] ORDER BY [DateMakCrTotals] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Commands for StressTestsLiveDetails  " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")
                    cmd.ExecuteNonQuery()
                End If
            Next

            '****************************************************************************************************
            'Set StressNewAmount=EuroEquivalent in StressTestsLive Details
            cmd.CommandText = "UPDATE [StressTestsLiveDetails]  SET [StressNewAmount]=[Euro Equivalent]"
            cmd.ExecuteNonQuery()
            '***************************************************************************************************
            'INTERNAL GUARANTESS DEFINIEREN
            Me.QueryText = "select * from [INTERNAL GUARANTEES]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='INTERNAL GUARANTEE',[StressNewAmount]=0 Where  [Contract Collateral ID]='" & dt.Rows.Item(i).Item("ContractCollateralID") & "'"
                cmd.ExecuteNonQuery()
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'CASH PLEDGE DEFINIEREN-SQL
            'Definiere den Zeitarum
            Me.QueryText = "select distinct[RiskDate] from [StressTestsLiveDetails]   ORDER BY [RiskDate] asc"
            da2 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt2 = New DataTable()
            da2.Fill(dt2)
            For r = 0 To dt2.Rows.Count - 1
                Dim d As Date = dt2.Rows.Item(r).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SplashScreenManager.Default.SetWaitFormCaption("Define and calculate Cash pledge for  " & dt2.Rows.Item(r).Item("RiskDate"))
                    Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                    cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='CASHCOVER' Where  [Contract Type]<>'LIMIT' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "' and  [RiskDate]='" & rdsql & "'  "
                    cmd.ExecuteNonQuery()
                    Me.QueryText = "select * from [StressTestsLiveDetails]  Where  [InternalCode]='CASHCOVER' and  [RiskDate]='" & rdsql & "'  and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                    da1 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    For y = 0 To dt1.Rows.Count - 1
                        Dim EuroEquivalent As Double = dt1.Rows.Item(y).Item("Euro Equivalent")
                        If EuroEquivalent < CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                        ElseIf EuroEquivalent > CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]='" & Str(EuroEquivalent - CashPledgeAmount) & "' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                        ElseIf EuroEquivalent = CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = 0
                        End If
                    Next
                Next
            Next
            '*******************************************************************************************************
            'Update PDAmount
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [PDAmount]=[StressNewAmount]*[StressPercent]"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [StressTestsLive] ORDER BY [DateMakCrTotals] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Select Sum from StressTestsLiveDetails for " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeAmount")
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next
            cmd.Connection.Close()
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
        cmd.CommandText = "SELECT MAX([RiskDate]) FROM [MAK CR TOTALS] "
        cmd.Connection.Open()
        Dim MaxStressDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.BusinessTypeDateEdit.Text = MaxStressDate


        Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, MaxStressDate)
        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, MaxStressDate)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, MaxStressDate)
        SplashScreenManager.CloseForm(False)
    End Sub

 
    Private Sub SQL_ReRun_Period_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_Period_BarButtonItem.ItemClick
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
        DATES_FORM.Text = "Stress Tests- SQL Commands Execution"
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
            If FDate <= FDate Then
                If Me.BgwSQL_ReRun_SpecificPeriod.IsBusy = False Then
                    DATES_FORM.Cancel_btn.PerformClick()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Re-executing SQL Commands for the specified Period")
                    Me.BgwSQL_ReRun_SpecificPeriod.RunWorkerAsync()

                End If
            Else
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
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLiveDetails for specific Period ")
            cmd.CommandText = "DELETE from [StressTestsLiveDetails] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLive for specific period")
            cmd.CommandText = "DELETE  FROM [StressTestsLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "'"
            cmd.ExecuteNonQuery()
            'Select Riskdate CREDIT RISK
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from MAK Report")
            Me.QueryText = "SELECT distinct[RiskDate] FROM [MAK CR TOTALS] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "' ORDER BY [RiskDate] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim d As Date = dt.Rows.Item(i).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                SplashScreenManager.Default.SetWaitFormCaption("Insert Business Types Names and SQL Commands (Stress Tests) for " & d)
                'Neuanlage in StressTestsLive
                cmd.CommandText = "INSERT INTO [StressTestsLive]([BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],[DateMakCrTotals])Select [BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount],'" & rdsql & "' FROM [StressTestsTemp]"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [StressTestsLive] SET [SQLBusinessTypeDefinition]= REPLACE([SQLBusinessTypeDefinition],'<RiskDate>','" & rdsql & "'),[SQLBusinessTypeAmount]=REPLACE([SQLBusinessTypeAmount],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next

            'Execute SQL Commands for Details
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "' ORDER BY [DateMakCrTotals] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Commands for StressTestsLiveDetails  " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")
                    cmd.ExecuteNonQuery()
                End If
            Next

            '****************************************************************************************************
            'Set StressNewAmount=EuroEquivalent in StressTestsLive Details
            cmd.CommandText = "UPDATE [StressTestsLiveDetails]  SET [StressNewAmount]=[Euro Equivalent] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'"
            cmd.ExecuteNonQuery()
            '***************************************************************************************************
            'INTERNAL GUARANTESS DEFINIEREN
            Me.QueryText = "select * from [INTERNAL GUARANTEES]  where [Valid]='Y'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='INTERNAL GUARANTEE',[StressNewAmount]=0 Where  [Contract Collateral ID]='" & dt.Rows.Item(i).Item("ContractCollateralID") & "' and [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'"
                cmd.ExecuteNonQuery()
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'CASH PLEDGE DEFINIEREN-SQL
            'Definiere den Zeitarum
            Me.QueryText = "select distinct[RiskDate] from [StressTestsLiveDetails]  Where  [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'  ORDER BY [RiskDate] asc"
            da2 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt2 = New DataTable()
            da2.Fill(dt2)
            For r = 0 To dt2.Rows.Count - 1
                Dim d As Date = dt2.Rows.Item(r).Item("RiskDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SplashScreenManager.Default.SetWaitFormCaption("Define and calculate Cash pledge for  " & dt2.Rows.Item(r).Item("RiskDate"))
                    Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                    cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='CASHCOVER' Where  [Contract Type]<>'LIMIT' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "' and  [RiskDate]='" & rdsql & "'  "
                    cmd.ExecuteNonQuery()
                    Me.QueryText = "select * from [StressTestsLiveDetails]  Where  [InternalCode]='CASHCOVER' and  [RiskDate]='" & rdsql & "'  and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                    da1 = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    For y = 0 To dt1.Rows.Count - 1
                        Dim EuroEquivalent As Double = dt1.Rows.Item(y).Item("Euro Equivalent")
                        If EuroEquivalent < CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                        ElseIf EuroEquivalent > CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]='" & Str(EuroEquivalent - CashPledgeAmount) & "' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                        ElseIf EuroEquivalent = CashPledgeAmount Then
                            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            CashPledgeAmount = 0
                        End If
                    Next
                Next
            Next

            '*******************************************************************************************************
            '*******************************************************************************************************
            'Update PDAmount
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [PDAmount]=[StressNewAmount]*[StressPercent] where [RiskDate]>='" & rdsql1 & "' and [RiskDate]<='" & rdsql2 & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'Execute SQL Commands for Sum
            Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]>='" & rdsql1 & "' and [DateMakCrTotals]<='" & rdsql2 & "'ORDER BY [DateMakCrTotals] asc"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("Select Sum from StressTestsLiveDetails for " & dt.Rows.Item(i).Item("DateMakCrTotals"))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeAmount")
                    Dim BusinessTypeAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        BusinessTypeAmount = cmd.ExecuteScalar * 1
                    Else
                        BusinessTypeAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next
            cmd.Connection.Close()
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
        cmd.CommandText = "SELECT MAX([RiskDate]) FROM [MAK CR TOTALS] "
        cmd.Connection.Open()
        Dim MaxStressDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.BusinessTypeDateEdit.Text = MaxStressDate


        Me.StressTestsTempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestsTemp)
        Me.StressTestsLiveDetailsTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLiveDetails, MaxStressDate)
        Me.StressTestsLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.StressTestsLive, MaxStressDate)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, MaxStressDate)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BT_ST_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BT_ST_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
            e.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BT_ST_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles BT_ST_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_BT_ST_Totals_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_ST_Totals_Gridview_btn.Click
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
        Dim reportfooter As String = "BUSINESS TYPES - STRESS TESTS " & vbNewLine & "on: " & Me.BusinessTypeDateEdit.Text

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

    Private Sub Print_Export_BT_ST_Temp_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_BT_ST_Temp_Gridview_btn.Click
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
        Dim reportfooter As String = "BUSINESS TYPES - STRESS TESTS PARAMETERS"

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

    Private Sub StressTestsBusinessTyperReport_btn_Click(sender As Object, e As EventArgs) Handles StressTestsBusinessTyperReport_btn.Click
        If IsDate(Me.BusinessTypeDateEdit.Text) = True Then
            Dim d As Date = Me.BusinessTypeDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Stress Test-Business Types Report for " & Me.BusinessTypeDateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\STRESS_TESTS_CALC.rpt")
            'Dim r As New STRESS_TESTS_CALC
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "TestDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Stress Test - Business Types Report from " & d
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
End Class