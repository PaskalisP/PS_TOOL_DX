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
Public Class StressTestsHO
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

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
        UserLookAndFeel.Default.SetSkinStyle(CurrentSkinName)
    End Sub

    Private Sub StressTestsLiquidHOBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.StressTestsLiquidHOBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub StressTestsHO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Me.StressTestHODateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[StressDate],104) as 'RLDC Date' from [StressTestsLiquidHO] ORDER BY [StressDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.StressTestHODateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.StressTestHODateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If


        'Get 
        Dim MaxStressDate As Date = Me.StressTestHODateEdit.Text
        
        Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
        Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, MaxStressDate)

        Me.CashPlacementBUBA_AB_ButtonEdit.Focus()


    End Sub

   
    Private Sub LoadLiquidityStressTests_btn_Click(sender As Object, e As EventArgs) Handles LoadLiquidityStressTests_btn.Click
        
    End Sub

    Private Sub CashPlacementBUBA_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CashPlacementBUBA_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True
       
        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [CashPlacementBUBA_ACCD_SQL] FROM [StressTestsLiquidHO] where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Cash Placement DEUTSCHE BUNDEBANK Account Balance"
    End Sub

   
    Private Sub CashPlacmentBUBA_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CashPlacmentBUBA_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [CashPlacementBUBA_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Cash Placement DEUTSCHE BUNDEBANK within next Month"
    End Sub

    Private Sub PlacementToBanks_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles PlacementToBanks_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [PlacementToBanksInclIC_ACCD_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Placements to Banks (incl.IC Branch)-Account Balance"
    End Sub

    Private Sub PlacementsToBank_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles PlacementsToBank_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [PlacementsToBanksInclIC_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Placements to Banks (incl.IC Branch)-within next Month"
    End Sub

    Private Sub DebtClaimToCustomers_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DebtClaimToCustomers_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DebtClaimToCustomersInclCCB_ACCD_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Debt Claim to customers-Account Balance"
    End Sub

    Private Sub DebtClaimToCustomers_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DebtClaimToCustomers_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DebtClaimToCustomersInclCCB_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Debt Claim to customers-within next Month"
    End Sub

    Private Sub Investments_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Investments_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [Investments_Securities_ACCD_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Investments (Securities)-Account Balance"
    End Sub

    Private Sub Investments_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Investments_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [Investments_Securities_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Investments (Securities)-within next Month"
    End Sub

    Private Sub OtherAssets_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles OtherAssets_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [OtherAssets_ACCD_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Other Assets-Account Balance"
    End Sub

    Private Sub OtherAssets_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles OtherAssets_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [OtherAssets_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Other Assets-within next Month"
    End Sub

    Private Sub BorrowBUBA_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BorrowBUBA_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [BorrowFromBUBA_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Borrow from DEUTSCHE BUNDESBANK-Account Balance"
    End Sub

    Private Sub BorrowBUBA_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BorrowBUBA_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [BorrowFromBUBA_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Borrow from DEUTSCHE BUNDESBANK-within next Month"
    End Sub

    Private Sub DepositsBanks_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DepositsBanks_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DepositFromBanksInclIC_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Deposits from Banks (incl.IC Branch/H.O.)-Account Balance"
    End Sub

  
    Private Sub DepositsBanks_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DepositsBanks_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DepositFromBanksInclIC_CFNM_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Deposits from Banks (incl.IC Branch/H.O.)-within next Month"
    End Sub

    Private Sub DepositsCustomers_AB_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DepositsCustomers_AB_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DepositFromCustomers_SQL] FROM [StressTestsLiquidHO]  where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Deposits from customers-Account Balance"
    End Sub

    Private Sub DepositsCustomers_CM_ButtonEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles DepositsCustomers_CM_ButtonEdit.ButtonClick
        Me.SQL_Command_Description_lbl.Visible = True
        Me.SQL_Command_MemoEdit.Visible = True

        Dim rd As Date = Me.StressTestHODateEdit.Text
        Dim dsql As String = rd.ToString("yyyyMMdd")

        cmd.CommandText = "SELECT [DepositFromCustomers_CFNM_SQL] FROM [StressTestsLiquidHO] where [StressDate]='" & dsql & "'"
        cmd.Connection.Open()
        Me.SQL_Command_MemoEdit.Text = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SQL_Command_Description_lbl.Text = "Deposits from customers-within next Month"
    End Sub

    Private Sub SaveChangesStressTestsHO_Live_btn_Click(sender As Object, e As EventArgs) Handles SaveChangesStressTestsHO_Live_btn.Click
        Me.SQL_Command_Description_lbl.Visible = False
        Me.SQL_Command_MemoEdit.Visible = False
        Try
            Me.Validate()
            Me.StressTestsLiquidHOBindingSource.EndEdit()
            If Me.RiskControllingDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.StressTestsLiquidHOTableAdapter.Update(Me.RiskControllingDataSet.StressTestsLiquidHO)

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub SaveChangesStressTestsHO_Temp_btn_Click(sender As Object, e As EventArgs) Handles SaveChangesStressTestsHO_Temp_btn.Click
        Try
            Me.Validate()
            Me.StressTestLiquid_TempBindingSource.EndEdit()
            If Me.RiskControllingDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.StressTestLiquid_TempTableAdapter.Update(Me.RiskControllingDataSet.StressTestLiquid_Temp)
                    Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub SQL_Run_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_Run_BarButtonItem.ItemClick
        If XtraMessageBox.Show("Should the Stress Test H.O. scenario for the current Day be executed again?", "Stress Test H.O. scenario (Current day) EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_Run.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Executing Stress Test H.O. scenario for current Day")
                Me.BgwSQL_Run.RunWorkerAsync()

            End If
        End If
    End Sub

    Private Sub BgwSQL_Run_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_Run.DoWork
        Try
            cmd.Connection.Open()
            Dim d As Date = Me.StressTestHODateEdit.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Execute Commands
            Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next


            'Summen erstellen
            'CASH INFLOW-ACCOUNT BALANCE
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-ACCOUNT BALANCE
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'ADDITIONAL CASH FLOW UNDER STRESS
            '1
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '2
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '3
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '4
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '5
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '6
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '7
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '8
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()


            'Restliche Summen Berechnen
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'TOTAL LIQUIDITY
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSQL_Run_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_Run.RunWorkerCompleted
        Dim d As Date = Me.StressTestHODateEdit.Text
        'Stress Test Data
        Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
        Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_BarButtonItem.ItemClick
        If XtraMessageBox.Show("Should the Stress Test H.O. scenario be executed again?", "Stress Test H.O. scenario (Current day) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_ReRun.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Re-executing Stress Test H.O. scenario for current Day")
                Me.BgwSQL_ReRun.RunWorkerAsync()

            End If
        End If
    End Sub

    Private Sub BgwSQL_ReRun_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun.DoWork
        Try
            cmd.Connection.Open()
            Dim d As Date = Me.StressTestHODateEdit.Text
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Checking Date definieren
            Dim CheckingDate As Date = DateAdd("m", 1, d)
            Dim CheckingDateSql As String
            CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
            CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

            SplashScreenManager.Default.SetWaitFormCaption("Delete all results and commands for current Date")
            cmd.CommandText = "DELETE  FROM [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Re-insert current Date in StressTestsLiquidHO Table")
            cmd.CommandText = "INSERT INTO [StressTestsLiquidHO] ([StressDate]) Values ('" & rdsql & "')"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("re-insert SQL Commands in current Date")
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=B.[CashPlacementBUBA_ACCD_SQL],[CashPlacementBUBA_CFNM_SQL]=B.[CashPlacementBUBA_CFNM_SQL],[LossUnderStressCashPlacementBUBA]=B.[LossUnderStressCashPlacementBUBA],[PlacementToBanksInclIC_ACCD_SQL]=B.[PlacementToBanksInclIC_ACCD_SQL],[PlacementsToBanksInclIC_CFNM_SQL]=B.[PlacementsToBanksInclIC_CFNM_SQL],[LossUnderStressPlacementsToBanksInclIC]=B.[LossUnderStressPlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD_SQL]=B.[DebtClaimToCustomersInclCCB_ACCD_SQL],[DebtClaimToCustomersInclCCB_CFNM_SQL]=B.[DebtClaimToCustomersInclCCB_CFNM_SQL],[LossUnderStressDebtClaimToCustomersInclCCB]=B.[LossUnderStressDebtClaimToCustomersInclCCB],[Investments_Securities_ACCD_SQL]=B.[Investments_Securities_ACCD_SQL],[Investments_Securities_CFNM_SQL]=B.[Investments_Securities_CFNM_SQL],[LossUnderStressInvestments_Securities]=B.[LossUnderStressInvestments_Securities],[OtherAssets_ACCD_SQL]=B.[OtherAssets_ACCD_SQL],[OtherAssets_CFNM_SQL]=B.[OtherAssets_CFNM_SQL],[LossUnderStressInvestments_OtherAssets]=B.[LossUnderStressInvestments_OtherAssets],[BorrowFromBUBA_SQL]=B.[BorrowFromBUBA_SQL],[BorrowFromBUBA_CFNM_SQL]=B.[BorrowFromBUBA_CFNM_SQL],[LossUnderStressInvestments_BorrowFromBUBA]=B.[LossUnderStressInvestments_BorrowFromBUBA],[DepositFromBanksInclIC_SQL]=B.[DepositFromBanksInclIC_SQL],[DepositFromBanksInclIC_CFNM_SQL]=B.[DepositFromBanksInclIC_CFNM_SQL],[LossUnderStressInvestments_DepositFromBanksInclIC]=B.[LossUnderStressInvestments_DepositFromBanksInclIC],[DepositFromCustomers_SQL]=B.[DepositFromCustomers_SQL],[DepositFromCustomers_CFNM_SQL]=B.[DepositFromCustomers_CFNM_SQL],[LossUnderStressInvestments_DepositFromCustomers]=B.[LossUnderStressInvestments_DepositFromCustomers] from [StressTestsLiquidHO] A,[StressTestLiquid_Temp] B where A.[StressDate]='" & rdsql & "' and B.[ID]=1"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Replace <RiskDate> and <CheckingDate> with valid Date")
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]= REPLACE([CashPlacementBUBA_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=REPLACE([CashPlacementBUBA_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]= REPLACE([CashPlacementBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]=REPLACE([CashPlacementBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]= REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]=REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]= REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]=REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]= REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]=REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]= REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]=REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]= REPLACE([Investments_Securities_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]=REPLACE([Investments_Securities_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]= REPLACE([Investments_Securities_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]=REPLACE([Investments_Securities_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]= REPLACE([OtherAssets_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]=REPLACE([OtherAssets_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]= REPLACE([OtherAssets_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]=REPLACE([OtherAssets_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]= REPLACE([BorrowFromBUBA_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]=REPLACE([BorrowFromBUBA_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]= REPLACE([BorrowFromBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]=REPLACE([BorrowFromBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]= REPLACE([DepositFromBanksInclIC_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]=REPLACE([DepositFromBanksInclIC_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]= REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]=REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]= REPLACE([DepositFromCustomers_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]=REPLACE([DepositFromCustomers_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]= REPLACE([DepositFromCustomers_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]=REPLACE([DepositFromCustomers_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            SplashScreenManager.Default.SetWaitFormCaption("re-execute all commands for current Day again")
            'Execute Commands
            Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next


            'Summen erstellen
            'CASH INFLOW-ACCOUNT BALANCE
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-ACCOUNT BALANCE
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'ADDITIONAL CASH FLOW UNDER STRESS
            '1
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '2
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '3
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '4
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '5
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '6
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '7
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '8
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()


            'Restliche Summen Berechnen
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'TOTAL LIQUIDITY
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub BgwSQL_ReRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun.RunWorkerCompleted
        Dim d As Date = Me.StressTestHODateEdit.Text
        'Stress Test Data
        Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
        Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, d)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_AllDays_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_AllDays_BarButtonItem.ItemClick
        If XtraMessageBox.Show("Should the Stress Test H.O. scenario for all Days be deleted and executed again?", "Stress Test H.O. scenario (ALL DAYS) RE-EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If Me.BgwSQL_ReRun_All_Days.IsBusy = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Re-executing Stress Test H.O. scenario for all Days")
                Me.BgwSQL_ReRun_All_Days.RunWorkerAsync()


            End If
        End If
    End Sub

    Private Sub BgwSQL_ReRun_All_Days_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun_All_Days.DoWork
        Try
            cmd.Connection.Open()

            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLiquidHO Table")
            cmd.CommandText = "DELETE  FROM [StressTestsLiquidHO]"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from Daily Balance Sheets")
            Me.QueryText = "SELECT distinct[BSDate] FROM [DailyBalanceSheets] ORDER BY [BSDate] asc"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt1 = New DataTable()
            da1.Fill(dt1)
            For y = 0 To dt1.Rows.Count - 1
                Dim d As Date = dt1.Rows.Item(y).Item("BSDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                'Checking Date definieren
                Dim CheckingDate As Date = DateAdd("m", 1, d)
                Dim CheckingDateSql As String
                CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
                CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

                SplashScreenManager.Default.SetWaitFormCaption("Insert Stress Date and SQL Commands for " & d & " and execute")
                cmd.CommandText = "INSERT INTO [StressTestsLiquidHO] ([StressDate]) Values ('" & rdsql & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=B.[CashPlacementBUBA_ACCD_SQL],[CashPlacementBUBA_CFNM_SQL]=B.[CashPlacementBUBA_CFNM_SQL],[LossUnderStressCashPlacementBUBA]=B.[LossUnderStressCashPlacementBUBA],[PlacementToBanksInclIC_ACCD_SQL]=B.[PlacementToBanksInclIC_ACCD_SQL],[PlacementsToBanksInclIC_CFNM_SQL]=B.[PlacementsToBanksInclIC_CFNM_SQL],[LossUnderStressPlacementsToBanksInclIC]=B.[LossUnderStressPlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD_SQL]=B.[DebtClaimToCustomersInclCCB_ACCD_SQL],[DebtClaimToCustomersInclCCB_CFNM_SQL]=B.[DebtClaimToCustomersInclCCB_CFNM_SQL],[LossUnderStressDebtClaimToCustomersInclCCB]=B.[LossUnderStressDebtClaimToCustomersInclCCB],[Investments_Securities_ACCD_SQL]=B.[Investments_Securities_ACCD_SQL],[Investments_Securities_CFNM_SQL]=B.[Investments_Securities_CFNM_SQL],[LossUnderStressInvestments_Securities]=B.[LossUnderStressInvestments_Securities],[OtherAssets_ACCD_SQL]=B.[OtherAssets_ACCD_SQL],[OtherAssets_CFNM_SQL]=B.[OtherAssets_CFNM_SQL],[LossUnderStressInvestments_OtherAssets]=B.[LossUnderStressInvestments_OtherAssets],[BorrowFromBUBA_SQL]=B.[BorrowFromBUBA_SQL],[BorrowFromBUBA_CFNM_SQL]=B.[BorrowFromBUBA_CFNM_SQL],[LossUnderStressInvestments_BorrowFromBUBA]=B.[LossUnderStressInvestments_BorrowFromBUBA],[DepositFromBanksInclIC_SQL]=B.[DepositFromBanksInclIC_SQL],[DepositFromBanksInclIC_CFNM_SQL]=B.[DepositFromBanksInclIC_CFNM_SQL],[LossUnderStressInvestments_DepositFromBanksInclIC]=B.[LossUnderStressInvestments_DepositFromBanksInclIC],[DepositFromCustomers_SQL]=B.[DepositFromCustomers_SQL],[DepositFromCustomers_CFNM_SQL]=B.[DepositFromCustomers_CFNM_SQL],[LossUnderStressInvestments_DepositFromCustomers]=B.[LossUnderStressInvestments_DepositFromCustomers] from [StressTestsLiquidHO] A,[StressTestLiquid_Temp] B where A.[StressDate]='" & rdsql & "' and B.[ID]=1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]= REPLACE([CashPlacementBUBA_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=REPLACE([CashPlacementBUBA_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]= REPLACE([CashPlacementBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]=REPLACE([CashPlacementBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]= REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]=REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]= REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]=REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]= REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]=REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]= REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]=REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]= REPLACE([Investments_Securities_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]=REPLACE([Investments_Securities_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]= REPLACE([Investments_Securities_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]=REPLACE([Investments_Securities_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]= REPLACE([OtherAssets_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]=REPLACE([OtherAssets_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]= REPLACE([OtherAssets_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]=REPLACE([OtherAssets_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]= REPLACE([BorrowFromBUBA_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]=REPLACE([BorrowFromBUBA_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]= REPLACE([BorrowFromBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]=REPLACE([BorrowFromBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]= REPLACE([DepositFromBanksInclIC_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]=REPLACE([DepositFromBanksInclIC_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]= REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]=REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]= REPLACE([DepositFromCustomers_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]=REPLACE([DepositFromCustomers_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]= REPLACE([DepositFromCustomers_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]=REPLACE([DepositFromCustomers_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Execute Commands
                Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next

                'Summen erstellen
                'CASH INFLOW-ACCOUNT BALANCE
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-ACCOUNT BALANCE
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'ADDITIONAL CASH FLOW UNDER STRESS
                '1
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '2
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '3
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '4
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '5
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '6
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '7
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '8
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                'Restliche Summen Berechnen
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'TOTAL LIQUIDITY
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next


            cmd.Connection.Close()

        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSQL_ReRun_All_Days_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun_All_Days.RunWorkerCompleted
        'Get Max Interest Rate Risk Date
        cmd.CommandText = "SELECT MAX([StressDate]) FROM [StressTestsLiquidHO] "
        cmd.Connection.Open()
        Dim MaxStressDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.StressTestHODateEdit.Text = MaxStressDate

        Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
        Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, MaxStressDate)

        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SQL_ReRun_Period_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SQL_ReRun_Period_BarButtonItem.ItemClick
        Dim dxOK As New DevExpress.XtraEditors.SimpleButton

        With dxOK
            .Text = "Start execution"
            .Height = 23
            .Width = 105
            .Location = New System.Drawing.Point(29, 134)
            .ImageList = DATES_FORM.ImageCollection1
            .ImageIndex = 5
        End With

        DATES_FORM.Controls.Add(dxOK)
        DATES_FORM.OK_btn.Visible = False

        AddHandler dxOK.Click, AddressOf dxOK_click

        DATES_FORM.Show()
        DATES_FORM.Text = "Stress Tests Liquidity HO- Execution"
        DATES_FORM.Text_lbl.Text = "Please input the Period for the Stress Test H.O. scenario execution"
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
                If XtraMessageBox.Show("Should the H.O. Stress Test scenario for the indicated Period:" & vbNewLine & FDate & " till " & LDate & vbNewLine & "be executed?", "H.O. STRESS TEST SCENARIO EXECUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    If Me.BgwSQL_ReRun_SpecificPeriod.IsBusy = False Then
                        DATES_FORM.Cancel_btn.PerformClick()
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Re-executing Stress Test H.O. scenario for the specified Period")
                        Me.BgwSQL_ReRun_SpecificPeriod.RunWorkerAsync()
                    End If
                Else
                    Return
                End If
            Else
                XtraMessageBox.Show("From Date should be less or equal to Till Date" & vbNewLine & "Please check your input!", "WRONG DATES INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub BgwSQL_ReRun_SpecificPeriod_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSQL_ReRun_SpecificPeriod.DoWork
        Try
            Dim rdsql1 As String = FDate.ToString("yyyy-MM-dd")
            Dim rdsql2 As String = LDate.ToString("yyyy-MM-dd")

            cmd.Connection.Open()

            SplashScreenManager.Default.SetWaitFormCaption("Delete all Data in StressTestsLiquidHO Table")
            cmd.CommandText = "DELETE  FROM [StressTestsLiquidHO] where [StressDate]>='" & rdsql1 & "' and [StressDate]<='" & rdsql2 & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Select all Days from Daily Balance Sheets")
            Me.QueryText = "SELECT distinct[BSDate] FROM [DailyBalanceSheets] where [BSDate]>='" & rdsql1 & "' and [BSDate]<='" & rdsql2 & "'ORDER BY [BSDate] asc"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt1 = New DataTable()
            da1.Fill(dt1)
            For y = 0 To dt1.Rows.Count - 1
                Dim d As Date = dt1.Rows.Item(y).Item("BSDate")
                Dim rdsql As String = d.ToString("yyyy-MM-dd")
                'Checking Date definieren
                Dim CheckingDate As Date = DateAdd("m", 1, d)
                Dim CheckingDateSql As String
                CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
                CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

                SplashScreenManager.Default.SetWaitFormCaption("Insert Stress Date and SQL Commands for " & d & " and execute")
                cmd.CommandText = "INSERT INTO [StressTestsLiquidHO] ([StressDate]) Values ('" & rdsql & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=B.[CashPlacementBUBA_ACCD_SQL],[CashPlacementBUBA_CFNM_SQL]=B.[CashPlacementBUBA_CFNM_SQL],[LossUnderStressCashPlacementBUBA]=B.[LossUnderStressCashPlacementBUBA],[PlacementToBanksInclIC_ACCD_SQL]=B.[PlacementToBanksInclIC_ACCD_SQL],[PlacementsToBanksInclIC_CFNM_SQL]=B.[PlacementsToBanksInclIC_CFNM_SQL],[LossUnderStressPlacementsToBanksInclIC]=B.[LossUnderStressPlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD_SQL]=B.[DebtClaimToCustomersInclCCB_ACCD_SQL],[DebtClaimToCustomersInclCCB_CFNM_SQL]=B.[DebtClaimToCustomersInclCCB_CFNM_SQL],[LossUnderStressDebtClaimToCustomersInclCCB]=B.[LossUnderStressDebtClaimToCustomersInclCCB],[Investments_Securities_ACCD_SQL]=B.[Investments_Securities_ACCD_SQL],[Investments_Securities_CFNM_SQL]=B.[Investments_Securities_CFNM_SQL],[LossUnderStressInvestments_Securities]=B.[LossUnderStressInvestments_Securities],[OtherAssets_ACCD_SQL]=B.[OtherAssets_ACCD_SQL],[OtherAssets_CFNM_SQL]=B.[OtherAssets_CFNM_SQL],[LossUnderStressInvestments_OtherAssets]=B.[LossUnderStressInvestments_OtherAssets],[BorrowFromBUBA_SQL]=B.[BorrowFromBUBA_SQL],[BorrowFromBUBA_CFNM_SQL]=B.[BorrowFromBUBA_CFNM_SQL],[LossUnderStressInvestments_BorrowFromBUBA]=B.[LossUnderStressInvestments_BorrowFromBUBA],[DepositFromBanksInclIC_SQL]=B.[DepositFromBanksInclIC_SQL],[DepositFromBanksInclIC_CFNM_SQL]=B.[DepositFromBanksInclIC_CFNM_SQL],[LossUnderStressInvestments_DepositFromBanksInclIC]=B.[LossUnderStressInvestments_DepositFromBanksInclIC],[DepositFromCustomers_SQL]=B.[DepositFromCustomers_SQL],[DepositFromCustomers_CFNM_SQL]=B.[DepositFromCustomers_CFNM_SQL],[LossUnderStressInvestments_DepositFromCustomers]=B.[LossUnderStressInvestments_DepositFromCustomers] from [StressTestsLiquidHO] A,[StressTestLiquid_Temp] B where A.[StressDate]='" & rdsql & "' and B.[ID]=1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]= REPLACE([CashPlacementBUBA_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=REPLACE([CashPlacementBUBA_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]= REPLACE([CashPlacementBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]=REPLACE([CashPlacementBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]= REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]=REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]= REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]=REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]= REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]=REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]= REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]=REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]= REPLACE([Investments_Securities_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]=REPLACE([Investments_Securities_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]= REPLACE([Investments_Securities_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]=REPLACE([Investments_Securities_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]= REPLACE([OtherAssets_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]=REPLACE([OtherAssets_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]= REPLACE([OtherAssets_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]=REPLACE([OtherAssets_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]= REPLACE([BorrowFromBUBA_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]=REPLACE([BorrowFromBUBA_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]= REPLACE([BorrowFromBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]=REPLACE([BorrowFromBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]= REPLACE([DepositFromBanksInclIC_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]=REPLACE([DepositFromBanksInclIC_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]= REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]=REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]= REPLACE([DepositFromCustomers_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]=REPLACE([DepositFromCustomers_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]= REPLACE([DepositFromCustomers_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]=REPLACE([DepositFromCustomers_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Execute Commands
                Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                        Dim SqlAmount As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            SqlAmount = cmd.ExecuteScalar * 1
                        Else
                            SqlAmount = 0
                        End If
                        cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next

                'Summen erstellen
                'CASH INFLOW-ACCOUNT BALANCE
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-ACCOUNT BALANCE
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'ADDITIONAL CASH FLOW UNDER STRESS
                '1
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '2
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '3
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '4
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                '5
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '6
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '7
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '8
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                'Restliche Summen Berechnen
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'TOTAL LIQUIDITY
                cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            Next
            cmd.Connection.Close()
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSQL_ReRun_SpecificPeriod_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSQL_ReRun_SpecificPeriod.RunWorkerCompleted
        'Bind Combobox
        Me.StressTestHODateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[StressDate],104) as 'RLDC Date' from [StressTestsLiquidHO] ORDER BY [StressDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.StressTestHODateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.StressTestHODateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        'Get 
        Dim MaxStressDate As Date = Me.StressTestHODateEdit.Text

        Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
        Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, MaxStressDate)

        Me.CashPlacementBUBA_AB_ButtonEdit.Focus()

        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub StressTestsLiquidityHOReport_btn_Click(sender As Object, e As EventArgs) Handles StressTestsLiquidityHOReport_btn.Click
        If IsDate(Me.StressTestHODateEdit.Text) = True Then
            Dim d As Date = Me.StressTestHODateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Stress Test Liquidity HO scenario Report for " & Me.StressTestHODateEdit.Text)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\StressTestsLiquidityHOscenario.rpt")
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "StressTestDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Stress Test Liquidity HO scenario Report from " & d
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

    Private Sub StressTestHODateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StressTestHODateEdit.SelectedIndexChanged
        Me.SQL_Command_Description_lbl.Visible = False
        Me.SQL_Command_MemoEdit.Visible = False

        If IsDate(Me.StressTestHODateEdit.Text) = True Then
            Dim d As Date = Me.StressTestHODateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for " & d)
                'Load BusinessTypes Data
                Me.StressTestLiquid_TempTableAdapter.Fill(Me.RiskControllingDataSet.StressTestLiquid_Temp)
                Me.StressTestsLiquidHOTableAdapter.FillByStressDate(Me.RiskControllingDataSet.StressTestsLiquidHO, d)
                Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
                SplashScreenManager.CloseForm(False)
           
        End If
    End Sub
End Class