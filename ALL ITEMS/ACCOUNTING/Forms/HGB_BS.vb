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
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing



Public Class HGB_BS

    Dim CrystalRepDir As String = ""

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable


    Dim ActiveTabGroup As Double = 0

    Dim ActivaSum As Double = 0
    Dim TotalActivaSum As Double = 0
    Dim PassivaSum As Double = 0
    Dim TotalPassivaSum As Double = 0
    Dim BilanzDifferenz As Double = 0
    Dim CheckField As String = Nothing

    Dim DF_BalanceSheetReconciliation As New DatesForm

    Dim ActivaDetailViewCaption As String = Nothing
    Dim ActivaOffBalanceDetailViewCaption As String = Nothing
    Dim PassivaDetailsViewCaption As String = Nothing
    Dim PassivaOffBalanceDetailsViewCaption As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing

    Private BS_GL_Items As BindingSource
    Private BS_GL_Accounts As BindingSource
    Private BS_Currency As BindingSource

    Dim ID_toDELETE As Integer = 0
    Dim Insert_Status As String = Nothing

    Public PSTOOL_Mainform As PSTOOL_MAIN_Form

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

   

    Private Sub HGB_BS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = False
        End If
    End Sub

    Private Sub HGB_BS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Get connection
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        CrystalRepDir = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '***********************************************************************

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [HGB_BS] GROUP BY [RiskDate] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FromDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FromDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

       
        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
       
        'Load Balance Sheet
        Me.HGB_BS_Passiva_Off_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_PassivaOff, d)
        Me.HGB_BS_Passiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Passiva, d)
        Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
        Me.HGB_BS_Aktiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Aktiva, d)
        Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
        Me.HGB_GL_ItemsBS_ALL_TableAdapter.FillByBS_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsBS_ALL, d)

        'Sum Activa
        cmd.CommandText = "Select 'SumAktiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) else 0 END "
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim SumActiva As Double = cmd.ExecuteScalar
        Me.SumActivaTextEdit.Text = SumActiva
        'Sum Passiva
        cmd.CommandText = "Select 'SumPassiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) else 0 END"
        Dim SumPassiva As Double = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        Me.SumPassivaTextEdit.Text = SumPassiva
        'difference
        Me.ActivaPassivaDifferenceTextEdit.Text = Math.Round(SumActiva, 2) - Math.Round(SumPassiva, 2)
        '++++++++++++++++++++++++++++++++++++
        'If EDP_USER = "Y" Then
        '    Me.FromDateEdit.Properties.Buttons.Item(2).Visible = True
        '    GL_ITEMS_initData()
        '    GL_ITEMS_InitLookUp()

        '    GL_ACCOUNTS_initData()
        '    GL_ACCOUNTS_InitLookUp()

        '    CURRENCIES_initData()
        '    CURRENCIES_InitLookUp()

        'End If

        '++++++++++++++++++++++++++++++++++++++

    End Sub

    Private Sub GL_ITEMS_initData()
        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [GL_Item],[GL_Item_Name] from [DailyBalanceSheets] where [BSDate]='" & dsql & "'and [RilibiCode] is not NULL order by [GL_Item_Number] asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbGL_Items As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbGL_Items.Fill(ds, "DailyBalanceSheets")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_GL_Items = New BindingSource(ds, "DailyBalanceSheets")
    End Sub

    Private Sub GL_ITEMS_InitLookUp()
        Me.GL_Item_GridlookupEdit.Properties.DataSource = BS_GL_Items
        Me.GL_Item_GridlookupEdit.Properties.DisplayMember = "GL_Item"
        Me.GL_Item_GridlookupEdit.Properties.ValueMember = "GL_Item"
    End Sub

    Private Sub GL_ACCOUNTS_initData()
       
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [GL_AC_No],[GL_AC_Name],[Description] from [GL_ACCOUNTS]  order by [GL_AC_No] asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbGL_Accounts As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbGL_Accounts.Fill(ds, "GL_ACCOUNTS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_GL_Accounts = New BindingSource(ds, "GL_ACCOUNTS")
    End Sub

    Private Sub GL_ACCOUNTS_InitLookUp()
        Me.GL_Account_LookUpEdit.Properties.DataSource = BS_GL_Accounts
        Me.GL_Account_LookUpEdit.Properties.DisplayMember = "GL_AC_No"
        Me.GL_Account_LookUpEdit.Properties.ValueMember = "GL_AC_No"
    End Sub

    Private Sub CURRENCIES_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [CURRENCY CODE],[CURRENCY NAME] from [OWN_CURRENCIES]", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbOwnCurrencies As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbOwnCurrencies.Fill(ds, "OWN_CURRENCIES")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Currency = New BindingSource(ds, "OWN_CURRENCIES")
    End Sub

    Private Sub CURRENCIES_InitLookUp()
        Me.Currency_GridLookUpEdit.Properties.DataSource = BS_Currency
        Me.Currency_GridLookUpEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.Currency_GridLookUpEdit.Properties.ValueMember = "CURRENCY CODE"
    End Sub


    Private Sub LoadDailyBalanceSheets_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ActivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ActivaBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub ActivaBaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles ActivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            ActivaSum = 0

        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName)) Then
                If IsNumeric(Mid(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName), 1, 1)) = True Then
                    If summaryID = 0 Then
                        ActivaSum += Convert.ToDecimal(e.FieldValue)
                    End If
                End If

            End If

        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = ActivaSum
                TotalActivaSum = e.TotalValue
            End If
            'If summaryID = 1 Then
            'e.TotalValue = TotalActivaSum + TotalPassivaSum
            'End If

        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ActivaBaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva detail:" & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ActivaBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva detail:" & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ActivaBaseView.PrintInitialize
        If MessageBox.Show("Should also all the details of the HGB Balance Sheet be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = True
            Me.PassivaBaseView.OptionsPrint.ExpandAllDetails = True
            Me.PassivaOut_GridView.OptionsPrint.ExpandAllDetails = True
        Else
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = False
            Me.PassivaBaseView.OptionsPrint.ExpandAllDetails = False
            Me.PassivaOut_GridView.OptionsPrint.ExpandAllDetails = False
        End If
    End Sub


    Private Sub ActivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Aktiva detail:" & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub


    Private Sub ActivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaBaseView.RowStyle

        If (e.RowHandle >= 0) Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName)) Then
                If IsNumeric(Mid(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName), 1, 1)) = True Then
                    e.Appearance.BackColor = Color.LightCyan
                    e.Appearance.BackColor2 = Color.WhiteSmoke
                    e.Appearance.ForeColor = Color.Black
                    'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub PassivaBaseView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles PassivaBaseView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub PassivaBaseView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles PassivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            PassivaSum = 0
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, GridColumn3)) Then
                If IsNumeric(Mid(PassivaBaseView.GetRowCellValue(e.RowHandle, GridColumn3), 1, 1)) = True Then
                    If summaryID = 0 Then
                        PassivaSum += Convert.ToDecimal(e.FieldValue)
                    End If
                End If
            End If

        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = PassivaSum
                TotalPassivaSum = e.TotalValue
            End If

        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles PassivaBaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva detail: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PassivaBaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva detail: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaBaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva detail: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

   

    Private Sub PassivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaBaseView.RowStyle
        'Set backcolor fur Subtotal Fields
       If (e.RowHandle >= 0) Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName)) Then
                If IsNumeric(Mid(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName), 1, 1)) = True Then
                    e.Appearance.BackColor = Color.LightCyan
                    e.Appearance.BackColor2 = Color.WhiteSmoke
                    e.Appearance.ForeColor = Color.Black
                    'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl2.DataSource = HGB_BS_AktivaBindingSource
            Me.GridControl1.DataSource = HGB_BS_PassivaBindingSource
            Me.GridControl4.DataSource = HGB_BS_PassivaOffBindingSource
            Me.GridControl5.DataSource = HGB_GL_ItemsBS_ALLBindingSource
            Me.GridControl6.DataSource = HGB_GL_Items_Bookings_ALLBindingSource

            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load HGB Balance Sheet for " & d)
                'Load Balance Sheet
                Me.HGB_BS_Passiva_Off_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_PassivaOff, d)
                Me.HGB_BS_Passiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Passiva, d)
                Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
                Me.HGB_BS_Aktiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Aktiva, d)
                Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
                Me.HGB_GL_ItemsBS_ALL_TableAdapter.FillByBS_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsBS_ALL, d)

                cmd.CommandText = "Select 'SumAktiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) else 0 END "
                Dim SumActiva As Double = cmd.ExecuteScalar
                Me.SumActivaTextEdit.Text = SumActiva
                'Sum Passiva
                cmd.CommandText = "Select 'SumPassiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) else 0 END"
                Dim SumPassiva As Double = cmd.ExecuteScalar
                Me.SumPassivaTextEdit.Text = SumPassiva
                'difference
                Me.ActivaPassivaDifferenceTextEdit.Text = Math.Round(SumActiva, 2) - Math.Round(SumPassiva, 2)
                SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            End If
        End If

        If e.Button.Caption = "Adjust" Then
            rd = Me.FromDateEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            Me.LayoutControl1.Visible = False
            Me.GroupControl3.Text = "Add new GL Account in Balance Sheet for " & rd
            Me.Currency_GridLookUpEdit.Properties.NullText = "EUR"
        End If
    End Sub

    Private Sub FromDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles FromDateEdit.EditValueChanged

    End Sub

    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FromDateEdit.KeyDown
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
            Me.GridControl5.DataSource = Nothing
            Me.GridControl6.DataSource = Nothing
            Me.SumActivaTextEdit.Text = 0
            Me.SumPassivaTextEdit.Text = 0
            Me.ActivaPassivaDifferenceTextEdit.Text = 0
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl2.DataSource = HGB_BS_AktivaBindingSource
        Me.GridControl1.DataSource = HGB_BS_PassivaBindingSource
        Me.GridControl4.DataSource = HGB_BS_PassivaOffBindingSource
        Me.GridControl5.DataSource = HGB_GL_ItemsBS_ALLBindingSource
        Me.GridControl6.DataSource = HGB_GL_Items_Bookings_ALLBindingSource

        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load HGB Balance Sheet for " & d)
            'Load Balance Sheet
            Me.HGB_BS_Passiva_Off_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_PassivaOff, d)
            Me.HGB_BS_Passiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Passiva, d)
            Me.HGB_GL_ItemsTableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items, d)
            Me.HGB_BS_Aktiva_TableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS_Aktiva, d)
            Me.HGB_GL_Items_Bookings_ALL_TableAdapter.FillByBSDate(Me.FormblattBalanceDataset.HGB_GL_Items_Bookings_ALL, d)
            Me.HGB_GL_ItemsBS_ALL_TableAdapter.FillByBS_BSDate(Me.FormblattBalanceDataset.HGB_GL_ItemsBS_ALL, d)

            cmd.CommandText = "Select 'SumAktiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr]<=49) else 0 END "
            Dim SumActiva As Double = cmd.ExecuteScalar
            Me.SumActivaTextEdit.Text = SumActiva
            'Sum Passiva
            cmd.CommandText = "Select 'SumPassiva'=Case when (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) is not NULL then (Select Sum([Amount3]) from [HGB_BS] where [RiskDate]='" & dsql & "' and [HGB_BS_ItemNr] BETWEEN 50 and 88) else 0 END"
            Dim SumPassiva As Double = cmd.ExecuteScalar
            Me.SumPassivaTextEdit.Text = SumPassiva
            'difference
            Me.ActivaPassivaDifferenceTextEdit.Text = Math.Round(SumActiva, 2) - Math.Round(SumPassiva, 2)

            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub FromDateEdit_TextChanged(sender As Object, e As EventArgs) Handles FromDateEdit.TextChanged

    End Sub

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        If ActiveTabGroup = 0 Then

            ' Create objects and define event handlers.
            Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
            AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
            AddHandler composLink.CreateMarginalFooterArea, AddressOf composLink_CreateMarginalFooterArea
            Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink11 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink22 As PrintableComponentLink = New PrintableComponentLink()
            Dim linkMainReport As Link = New Link()
            AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
            Dim linkGrid1Report As Link = New Link()
            AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
            Dim linkGrid11Report As Link = New Link()
            AddHandler linkGrid11Report.CreateDetailArea, AddressOf linkGrid11Report_CreateDetailArea
            Dim linkGrid2Report As Link = New Link()
            AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea
            Dim linkGrid22Report As Link = New Link()
            AddHandler linkGrid22Report.CreateDetailArea, AddressOf linkGrid22Report_CreateDetailArea

            ' Assign the controls to the printing links.
            pcLink1.Component = Me.GridControl2
            pcLink11.Component = Me.GridControl1
            pcLink2.Component = Me.GridControl4
            'pcLink22.Component = Me.GridControl3
            ' Populate the collection of links in the composite link.
            ' The order of operations corresponds to the document structure.
            composLink.Links.Add(linkGrid1Report)
            composLink.Links.Add(pcLink1)
            composLink.Links.Add(linkGrid11Report)
            composLink.Links.Add(pcLink11)

            composLink.Links.Add(linkMainReport)
            composLink.Links.Add(linkGrid2Report)
            composLink.Links.Add(pcLink2)
            composLink.Links.Add(linkGrid22Report)
            'composLink.Links.Add(pcLink22)

            composLink.Landscape = True
            composLink.PaperKind = System.Drawing.Printing.PaperKind.A4

            ' Create the report and show the preview window.
            composLink.ShowPreviewDialog()
        End If
        If ActiveTabGroup = 1 Then
            If Not GridControl5.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            If Not GridControl6.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "Vermögensübersicht* zum " & Me.FromDateEdit.Text & "der China Construction Bank Corporation Niederlassung Frankfurt"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub composLink_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. ungebuchte Bundesbank negativzinsen - Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "*Beinhaltet nicht die vollständige Steuerbelastung und ggfs. Bundesbank negativzinsen - Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "Aktivseite"
        tb.Font = New Font("Arial", 12)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid11Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "Passivseite"
        tb.Font = New Font("Arial", 12)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates an interval between the grids and fills it with color.
    Private Sub linkMainReport_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Rect = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        tb.BackColor = Color.Gray
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates a text header for the second grid.
    Private Sub linkGrid2Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "Passivseite - Außerbilanziel"
        tb.Font = New Font("Arial", 12)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid22Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        'Dim tb As TextBrick = New TextBrick()
        'tb.Text = "PASSIVA- Off Balance"
        'tb.Font = New Font("Arial", 12)
        'tb.Rect = New RectangleF(0, 0, 300, 25)
        'tb.BorderWidth = 0
        'tb.BackColor = Color.Transparent
        'tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        'e.Graph.DrawBrick(tb)
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
        Dim reportfooter As String = "Vermögensübersicht  - HGB GL Items and Positions on" & Me.FromDateEdit.Text
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
        Dim reportfooter As String = "All GL Items and Manual Bookings on" & Me.FromDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub BalanceSheetCR_btn_Click(sender As Object, e As EventArgs) Handles BalanceSheetCR_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating HGB - BILANZ REPORT for " & Me.FromDateEdit.Text)
            'Load Data
            Me.HGB_BSTableAdapter.FillByRiskDate(Me.FormblattBalanceDataset.HGB_BS, d)
           
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\HGB_BILANZ_Daily.rpt")
            CrRep.SetDataSource(Me.FormblattBalanceDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "FDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "HGB - BILANZ Report from " & d
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

    Private Sub ActivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub ReconciliationBS_btn_Click(sender As Object, e As EventArgs)
        'Dim dxOK_BalanceSheetReconciliation As New DevExpress.XtraEditors.SimpleButton
        'With dxOK_BalanceSheetReconciliation
        '    .Text = "OK"
        '    .Height = 23
        '    .Width = 75
        '    .Location = New System.Drawing.Point(29, 134)
        'End With
        'DF_BalanceSheetReconciliation.Controls.Add(dxOK_BalanceSheetReconciliation)
        'DF_BalanceSheetReconciliation.OK_btn.Visible = False

        'AddHandler dxOK_BalanceSheetReconciliation.Click, AddressOf dxOK_BalanceSheetReconciliation_click

        'DF_BalanceSheetReconciliation.Show()
        'DF_BalanceSheetReconciliation.Text = "BALANCE SHEET RECONCILIATION"
        'DF_BalanceSheetReconciliation.Text_lbl.Text = "Please input the Period for report creation"
        'With DF_BalanceSheetReconciliation.DateEdit1
        '    .Properties.EditMask = "dd.MM.yyyy"
        '    .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        '    .Properties.EditFormat.FormatString = "dd.MM.yyyy"
        '    .Properties.Appearance.Options.UseTextOptions = True
        '    .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        '    .Text = Today.ToString("dd.MM.yyyy")
        'End With
        'With DF_BalanceSheetReconciliation.DateEdit2
        '    .Properties.EditMask = "dd.MM.yyyy"
        '    .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
        '    .Properties.EditFormat.FormatString = "dd.MM.yyyy"
        '    .Properties.Appearance.Options.UseTextOptions = True
        '    .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        '    .Text = Today.ToString("dd.MM.yyyy")
        'End With
    End Sub

    Private Sub dxOK_BalanceSheetReconciliation_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim d1 As Date = DF_BalanceSheetReconciliation.DateEdit1.Text
        'Dim d2 As Date = DF_BalanceSheetReconciliation.DateEdit2.Text

        'DF_BalanceSheetReconciliation.Close()
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'SplashScreenManager.Default.SetWaitFormCaption("Creating Balance Sheet reconciliation on " & d1 & " to " & d2)


        'Dim f As New DailyBalanceSheets
        'f.DailyBalanceSheetsTableAdapter.FillByBSDateFromTill(f.PSTOOLDataset.DailyBalanceSheets, d1, d2)

        'Dim CrRep As New ReportDocument
        'CrRep.Load(CrystalRepDir & "\Balance Sheets Reconciliation.rpt")
        'CrRep.SetDataSource(f.PSTOOLDataset)
        'Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        'Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        'Dim myParams As ParameterField = New ParameterField
        'Dim myParams1 As ParameterField = New ParameterField
        'myValue.Value = d1
        'myParams.ParameterFieldName = "FDate"
        'myValue1.Value = d2
        'myParams1.ParameterFieldName = "LDate"
        'myParams.CurrentValues.Add(myValue)
        'myParams1.CurrentValues.Add(myValue1)
        'Dim c As New CrystalReportsForm
        'c.MdiParent = Me.MdiParent
        'c.Show()
        'c.WindowState = FormWindowState.Maximized
        'c.Text = "Balance Sheet reconciliation on " & d1 & " to " & d2
        'c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        'c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        'c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        'c.CrystalReportViewer1.ReportSource = CrRep
        'c.CrystalReportViewer1.ShowParameterPanelButton = False
        'c.CrystalReportViewer1.ShowRefreshButton = False
        'c.CrystalReportViewer1.ShowGroupTreeButton = False
        'c.CrystalReportViewer1.Zoom(85)
        'SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ActivaDetailView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles ActivaDetailView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

  

    Private Sub ActivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub ActivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PassivaDetailView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles PassivaDetailView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

   


    Private Sub PassivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub PassivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

   



    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub GridView3_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub PassivaOut_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles PassivaOut_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub PassivaOut_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles PassivaOut_GridView.MasterRowExpanded
        If Me.GridControl4.FocusedView.Name = "PassivaOut_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva Detail - Außerbilanziel: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaOutDetail_GridView.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaOut_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PassivaOut_GridView.MasterRowExpanding
        If Me.GridControl4.FocusedView.Name = "PassivaOut_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva Detail - Außerbilanziel: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaOutDetail_GridView.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaOut_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaOut_GridView.RowClick
        If Me.GridControl4.FocusedView.Name = "PassivaOut_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva Detail - Außerbilanziel: " & view.GetFocusedRowCellValue("HGB_BS_ItemName").ToString
            Me.PassivaOutDetail_GridView.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub



    Private Sub PassivaOut_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaOut_GridView.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            If Not DBNull.Value.Equals(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName)) Then
                If IsNumeric(Mid(ActivaBaseView.GetRowCellValue(e.RowHandle, colHGB_BS_ItemName), 1, 1)) = True Then
                    e.Appearance.BackColor = Color.LightCyan
                    e.Appearance.BackColor2 = Color.WhiteSmoke
                    e.Appearance.ForeColor = Color.Black
                    'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

            End If
        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub PassivaOut_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaOut_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub



    Private Sub PassivaOutDetail_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaOutDetail_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub PassivaOutDetail_ShownEditor(sender As Object, e As EventArgs) Handles PassivaOutDetail_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

   
   

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "HGB BILANZ - TOTALS" Then
            ActiveTabGroup = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "HGB BILANZ - DETAILS" Then
            ActiveTabGroup = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL GL ITEMS + MANUAL BOOKINGS" Then
            ActiveTabGroup = 2

        End If
    End Sub

    Private Sub HGB_Bilanz_Details_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles HGB_Bilanz_Details_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub HGB_Bilanz_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles HGB_Bilanz_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub HGB_Bilanz_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles HGB_Bilanz_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub

    Private Sub All_Details_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles All_Details_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Navy
    End Sub

    Private Sub All_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub All_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Navy
        End If
    End Sub
End Class