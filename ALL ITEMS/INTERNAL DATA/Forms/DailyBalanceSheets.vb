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



Public Class DailyBalanceSheets

    Dim CrystalRepDir As String = ""

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

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

    Dim LenghtGL_Account As Integer = 0

    Dim PrintDetails As Boolean = False

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

    Private Sub DailyBalanceSheetsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.DailyBalanceSheetsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub DailyBalanceSheets_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = False
        End If
    End Sub

    Private Sub DailyBalanceSheets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
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
        '***********************************************************************

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[BSDate],104) as 'RLDC Date' from [DailyBalanceSheets] GROUP BY [BSDate] ORDER BY [BSDate] desc"
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

        'cmd.CommandText = "Select Max(BSDate) from DailyBalanceSheets"
        'cmd.Connection.Open()
        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        'cmd.Connection.Close()
        'Input MaxDate in control
        'Me.FromDateEdit.Text = d

        'Load Balance Sheet
        'ACTIVA
        Me.DailyBalanceSheets2TableAdapter.FillByActivaDate(Me.PSTOOLDataset.DailyBalanceSheets2, d)
        'Off-Balance
        Me.ActivaOffBalance_DailyBalanceSheetsTableAdapter.FillByActiva_OffBalanceDate(Me.PSTOOLDataset.ActivaOffBalance_DailyBalanceSheets, d)
        'PASSIVA
        Me.DailyBalanceSheets1TableAdapter.FillByPassivaDate(Me.PSTOOLDataset.DailyBalanceSheets1, d)
        'Off-Balance
        Me.PassivaOffBalance_DailyBalanceSheetsTableAdapter.FillByPassiva_OffBalanceDate(Me.PSTOOLDataset.PassivaOffBalance_DailyBalanceSheets, d)
        'Details
        Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
        'Sum Activa
        cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=2999"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Dim SumActiva As Double = cmd.ExecuteScalar
        Me.SumActivaTextEdit.Text = SumActiva
        'Sum Passiva
        cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=4999"
        Dim SumPassiva As Double = cmd.ExecuteScalar
        Me.SumPassivaTextEdit.Text = SumPassiva
        'difference
        Me.ActivaPassivaDifferenceTextEdit.Text = SumActiva + SumPassiva
        '++++++++++++++++++++++++++++++++++++
        'Lenght GL Account
        cmd.CommandText = "SELECT TOP 1 LEN([GL_Account_Nr]) FROM [DailyBalanceDetailsSheets] where [BSDate]='" & dsql & "'"
        LenghtGL_Account = cmd.ExecuteScalar

        If EDP_USER = "Y" Or ACCOUNTING_USER = "Y" Then
            Me.FromDateEdit.Properties.Buttons.Item(2).Visible = True
            GL_ITEMS_initData()
            GL_ITEMS_InitLookUp()

            GL_ACCOUNTS_initData()
            GL_ACCOUNTS_InitLookUp()

            CURRENCIES_initData()
            CURRENCIES_InitLookUp()

        End If

        '++++++++++++++++++++++++++++++++++++++
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

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
        If LenghtGL_Account = 6 Then
            Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [NEWG_GL_ACC_Nr] as 'GL_AC_No',[NEWG_GL_ACC_Name] as 'GL_AC_Name',[NEWG_GL_Nr_First_Name] as 'Description' from [GL_ACCOUNTS_NEWG]  order by [NEWG_GL_ACC_Nr] asc", conn)
            objCMD1.CommandTimeout = 5000
            Dim dbGL_Accounts As SqlDataAdapter = New SqlDataAdapter(objCMD1)

            Dim ds As DataSet = New DataSet()

            Try

                dbGL_Accounts.Fill(ds, "GL_ACCOUNTS")

            Catch ex As System.Exception
                MsgBox(ex.Message)

            End Try
            BS_GL_Accounts = New BindingSource(ds, "GL_ACCOUNTS")
        End If
        If LenghtGL_Account = 8 Then
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
        End If
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

    Private Sub ActivaBaseView_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles ActivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            ActivaSum = 0

        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "RilibiCode").ToString) <> "" Then
                If summaryID = 0 Then
                    ActivaSum += Convert.ToDecimal(e.FieldValue)
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
            ActivaDetailViewCaption = "Activa details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ActivaBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Activa details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub

    Private Sub ActivaBaseView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles ActivaBaseView.PrintInitialize
        If MessageBox.Show("Should also all the details be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
            PrintDetails = True
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = True
            Me.ActivaBaseView.OptionsPrint.PrintDetails = True
        Else
            Me.ActivaBaseView.OptionsPrint.ExpandAllDetails = False
            Me.ActivaBaseView.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub ActivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "ActivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaDetailViewCaption = "Activa details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ActivaDetailView.ViewCaption = ActivaDetailViewCaption
        End If
    End Sub


    Private Sub ActivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaBaseView.RowStyle

        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            'Dim GLITEMNAME As String = ActivaBaseView.GetRowCellValue(e.RowHandle, colGL_Item_Name)
            'If IsNumeric(Microsoft.VisualBasic.Right(GLITEMNAME, 2)) = True Then
            'e.Appearance.BackColor = Color.Orange
            'e.Appearance.BackColor2 = Color.Orange
            'e.Appearance.ForeColor = Color.Black
            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            'End If
            
            Dim RILIBI_CODE_NR As String = CStr(ActivaBaseView.GetRowCellValue(e.RowHandle, colRilibiCodeAktiva).ToString)
            If RILIBI_CODE_NR = "" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If


        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaBaseView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles PassivaBaseView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            PassivaSum = 0
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If CStr(View.GetRowCellValue(e.RowHandle, "RilibiCode").ToString) <> "" Then
                If summaryID = 0 Then
                    PassivaSum += Convert.ToDecimal(e.FieldValue)
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
            PassivaDetailsViewCaption = "Passiva details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles PassivaBaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

    Private Sub PassivaBaseView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles PassivaBaseView.PrintInitialize
        If PrintDetails = True Then
            Me.PassivaBaseView.OptionsPrint.ExpandAllDetails = True
            Me.PassivaBaseView.OptionsPrint.PrintDetails = True
        Else
            Me.PassivaBaseView.OptionsPrint.ExpandAllDetails = False
            Me.PassivaBaseView.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub PassivaBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaBaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "PassivaBaseView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaDetailsViewCaption = "Passiva details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.PassivaDetailView.ViewCaption = PassivaDetailsViewCaption
        End If
    End Sub

   

    Private Sub PassivaBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaBaseView.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            'Dim GLITEMNAME As String = PassivaBaseView.GetRowCellValue(e.RowHandle, colGL_Item_Name)
            'If IsNumeric(Microsoft.VisualBasic.Right(GLITEMNAME, 2)) = True Then
            'e.Appearance.BackColor = Color.Orange
            'e.Appearance.BackColor2 = Color.Orange
            'e.Appearance.ForeColor = Color.Black
            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            Dim RILIBI_CODE_NR As String = CStr(PassivaBaseView.GetRowCellValue(e.RowHandle, colRilibiCodePassiva).ToString)
            If RILIBI_CODE_NR = "" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If


        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.DailyBalanceSheets1BindingSource
            Me.GridControl2.DataSource = Me.DailyBalanceSheets2BindingSource
            Me.GridControl3.DataSource = Me.ActivaOffBalance_DailyBalanceSheetsBindingSource
            Me.GridControl4.DataSource = Me.PassivaOffBalance_DailyBalanceSheetsBindingSource

            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Data for " & d)
                'Load Balance Sheet
                'ACTIVA
                Me.DailyBalanceSheets2TableAdapter.FillByActivaDate(Me.PSTOOLDataset.DailyBalanceSheets2, d)
                Me.ActivaOffBalance_DailyBalanceSheetsTableAdapter.FillByActiva_OffBalanceDate(Me.PSTOOLDataset.ActivaOffBalance_DailyBalanceSheets, d)
                'PASSIVA
                Me.DailyBalanceSheets1TableAdapter.FillByPassivaDate(Me.PSTOOLDataset.DailyBalanceSheets1, d)
                Me.PassivaOffBalance_DailyBalanceSheetsTableAdapter.FillByPassiva_OffBalanceDate(Me.PSTOOLDataset.PassivaOffBalance_DailyBalanceSheets, d)
                'Details
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                'Sum Activa
                'cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]<=2850 and ISNUMERIC(Right([GL_Item_Name],2))=0"
                cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=2999"
                Dim SumActiva As Double = cmd.ExecuteScalar
                Me.SumActivaTextEdit.Text = SumActiva
                'Sum Passiva
                'cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=3000 and [GL_Item_Number]<=4998 and ISNUMERIC(Right([GL_Item_Name],2))=0"
                cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=4999"
                Dim SumPassiva As Double = cmd.ExecuteScalar
                Me.SumPassivaTextEdit.Text = SumPassiva
                'difference
                Me.ActivaPassivaDifferenceTextEdit.Text = SumActiva + SumPassiva
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
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
            Me.SumActivaTextEdit.Text = 0
            Me.SumPassivaTextEdit.Text = 0
            Me.ActivaPassivaDifferenceTextEdit.Text = 0
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.DailyBalanceSheets1BindingSource
        Me.GridControl2.DataSource = Me.DailyBalanceSheets2BindingSource
        Me.GridControl3.DataSource = Me.ActivaOffBalance_DailyBalanceSheetsBindingSource
        Me.GridControl4.DataSource = Me.PassivaOffBalance_DailyBalanceSheetsBindingSource

        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Data for " & d)
                'Load Balance Sheet
                'ACTIVA
            Me.DailyBalanceSheets2TableAdapter.FillByActivaDate(Me.PSTOOLDataset.DailyBalanceSheets2, d)
            Me.ActivaOffBalance_DailyBalanceSheetsTableAdapter.FillByActiva_OffBalanceDate(Me.PSTOOLDataset.ActivaOffBalance_DailyBalanceSheets, d)
                'PASSIVA
            Me.DailyBalanceSheets1TableAdapter.FillByPassivaDate(Me.PSTOOLDataset.DailyBalanceSheets1, d)
            Me.PassivaOffBalance_DailyBalanceSheetsTableAdapter.FillByPassiva_OffBalanceDate(Me.PSTOOLDataset.PassivaOffBalance_DailyBalanceSheets, d)
                'Details
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                'Sum Activa
                'cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]<=2850 and ISNUMERIC(Right([GL_Item_Name],2))=0"
            cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=2999"
                Dim SumActiva As Double = cmd.ExecuteScalar
                Me.SumActivaTextEdit.Text = SumActiva
                'Sum Passiva
                'cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=3000 and [GL_Item_Number]<=4998 and ISNUMERIC(Right([GL_Item_Name],2))=0"
            cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]=4999"
                Dim SumPassiva As Double = cmd.ExecuteScalar
                Me.SumPassivaTextEdit.Text = SumPassiva
                'difference
                Me.ActivaPassivaDifferenceTextEdit.Text = SumActiva + SumPassiva
                SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub FromDateEdit_TextChanged(sender As Object, e As EventArgs) Handles FromDateEdit.TextChanged

    End Sub

    Private Sub DailyBalanceSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyBalanceSheet_Print_Export_btn.Click
        ' Create objects and define event handlers.
        Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
        AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
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
        pcLink11.Component = Me.GridControl3
        pcLink2.Component = Me.GridControl1
        pcLink22.Component = Me.GridControl4
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
        composLink.Links.Add(pcLink22)

        composLink.Landscape = True
        composLink.PaperKind = System.Drawing.Printing.PaperKind.A4

        ' Create the report and show the preview window.
        composLink.ShowPreviewDialog()
        PrintDetails = False
    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "BALANCE SHEET" & "  " & "from " & Me.FromDateEdit.Text & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "ACTIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid11Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "ACTIVA- Off Balance Items"
        tb.Font = New Font("Arial", 15)
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
        tb.Text = "PASSIVA"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid22Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "PASSIVA- Off Balance"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub


    Private Sub BalanceSheetCR_btn_Click(sender As Object, e As EventArgs) Handles BalanceSheetCR_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating BALANCE SHEET REPORT for " & Me.FromDateEdit.Text)
            Me.DailyBalanceSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceSheets, d)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\Balance Sheet Daily.rpt")
            CrRep.SetDataSource(PSTOOLDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "FDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Balance Sheet Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(75)
            SplashScreenManager.CloseForm(False)
           
        End If

    End Sub

    Private Sub ActivaBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ReconciliationBS_btn_Click(sender As Object, e As EventArgs) Handles ReconciliationBS_btn.Click
        Dim dxOK_BalanceSheetReconciliation As New DevExpress.XtraEditors.SimpleButton
        With dxOK_BalanceSheetReconciliation
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
        End With
        DF_BalanceSheetReconciliation.Controls.Add(dxOK_BalanceSheetReconciliation)
        DF_BalanceSheetReconciliation.OK_btn.Visible = False

        AddHandler dxOK_BalanceSheetReconciliation.Click, AddressOf dxOK_BalanceSheetReconciliation_click

        DF_BalanceSheetReconciliation.Show()
        DF_BalanceSheetReconciliation.Text = "BALANCE SHEET RECONCILIATION"
        DF_BalanceSheetReconciliation.Text_lbl.Text = "Please input the Period for report creation"
        With DF_BalanceSheetReconciliation.DateEdit1
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
        With DF_BalanceSheetReconciliation.DateEdit2
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
    End Sub

    Private Sub dxOK_BalanceSheetReconciliation_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_BalanceSheetReconciliation.DateEdit1.Text
        Dim d2 As Date = DF_BalanceSheetReconciliation.DateEdit2.Text

        DF_BalanceSheetReconciliation.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Balance Sheet reconciliation on " & d1 & " to " & d2)


        Dim f As New DailyBalanceSheets
        f.DailyBalanceSheetsTableAdapter.FillByBSDateFromTill(f.PSTOOLDataset.DailyBalanceSheets, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Balance Sheets Reconciliation.rpt")
        CrRep.SetDataSource(f.PSTOOLDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Balance Sheet reconciliation on " & d1 & " to " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ActivaDetailView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles ActivaDetailView.PopupMenuShowing
        If EDP_USER = "Y" Then
            Dim View As GridView = CType(sender, GridView)

            Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

            If HitInfo.InRow AndAlso Insert_Status = "M" Then

                View.FocusedRowHandle = HitInfo.RowHandle
                Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

            End If
        End If
    End Sub

    Private Sub ActivaDetailView_RowClick(sender As Object, e As RowClickEventArgs) Handles ActivaDetailView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.IsGroupRow(view.FocusedRowHandle) = False Then
            ID_toDELETE = view.GetFocusedRowCellValue("ID").ToString
            Insert_Status = view.GetFocusedRowCellValue("InsertStatus").ToString
        End If
    End Sub

    Private Sub ActivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ActivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ActivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ActivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PassivaDetailView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles PassivaDetailView.PopupMenuShowing
        If EDP_USER = "Y" Then
            Dim View As GridView = CType(sender, GridView)

            Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

            If HitInfo.InRow AndAlso Insert_Status = "M" Then

                View.FocusedRowHandle = HitInfo.RowHandle
                Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

            End If
        End If
    End Sub

    Private Sub PassivaDetailView_RowClick(sender As Object, e As RowClickEventArgs) Handles PassivaDetailView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.IsGroupRow(view.FocusedRowHandle) = False Then
            ID_toDELETE = view.GetFocusedRowCellValue("ID").ToString
            Insert_Status = view.GetFocusedRowCellValue("InsertStatus").ToString
        End If
    End Sub


    Private Sub PassivaDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PassivaDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PassivaDetailView_ShownEditor(sender As Object, e As EventArgs) Handles PassivaDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView1_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView1.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "GridView1" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaOffBalanceDetailViewCaption = "Activa - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView3.ViewCaption = ActivaOffBalanceDetailViewCaption
        End If
    End Sub

    Private Sub GridView1_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles GridView1.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "GridView1" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaOffBalanceDetailViewCaption = "Activa - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView3.ViewCaption = ActivaOffBalanceDetailViewCaption
        End If
    End Sub

    Private Sub GridView1_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        If PrintDetails = True Then
            Me.GridView1.OptionsPrint.ExpandAllDetails = True
            Me.GridView1.OptionsPrint.PrintDetails = True
        Else
            Me.GridView1.OptionsPrint.ExpandAllDetails = False
            Me.GridView1.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        If Me.GridControl3.FocusedView.Name = "GridView1" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ActivaOffBalanceDetailViewCaption = "Activa - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView3.ViewCaption = ActivaOffBalanceDetailViewCaption
        End If
    End Sub

    Private Sub GridView2_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView2.MasterRowExpanded
        If Me.GridControl4.FocusedView.Name = "GridView2" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView4.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub

    Private Sub GridView2_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles GridView2.MasterRowExpanding
        If Me.GridControl4.FocusedView.Name = "GridView2" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView4.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub

    Private Sub GridView2_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles GridView2.PrintInitialize
        If PrintDetails = True Then
            Me.GridView2.OptionsPrint.ExpandAllDetails = True
            Me.GridView2.OptionsPrint.PrintDetails = True
        Else
            Me.GridView2.OptionsPrint.ExpandAllDetails = False
            Me.GridView2.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView2.RowClick
        If Me.GridControl4.FocusedView.Name = "GridView2" Then

            Dim view As GridView = DirectCast(sender, GridView)
            PassivaOffBalanceDetailsViewCaption = "Passiva - Off Balance details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.GridView4.ViewCaption = PassivaOffBalanceDetailsViewCaption
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            'Dim GLITEMNAME As String = ActivaBaseView.GetRowCellValue(e.RowHandle, colGL_Item_Name)
            'If IsNumeric(Microsoft.VisualBasic.Right(GLITEMNAME, 2)) = True Then
            'e.Appearance.BackColor = Color.Orange
            'e.Appearance.BackColor2 = Color.Orange
            'e.Appearance.ForeColor = Color.Black
            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            'End If

            Dim GL_ITEM_NAME As String = CStr(GridView1.GetRowCellValue(e.RowHandle, colGL_Item_Name).ToString)
            If GL_ITEM_NAME = "Total" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If


        End If
        'Set Backcolor to Filter row
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

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If EDP_USER = "Y" Then
            Dim View As GridView = CType(sender, GridView)

            Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

            If HitInfo.InRow AndAlso Insert_Status = "M" Then

                View.FocusedRowHandle = HitInfo.RowHandle
                Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

            End If
        End If
    End Sub

    Private Sub GridView3_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView3.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.IsGroupRow(view.FocusedRowHandle) = False Then
            ID_toDELETE = view.GetFocusedRowCellValue("ID").ToString
            Insert_Status = view.GetFocusedRowCellValue("InsertStatus").ToString
        End If
    End Sub

    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        'Set Backcolor to Filter row
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

    Private Sub GridView2_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView2.RowStyle
        'Set backcolor fur Subtotal Fields
        If (e.RowHandle >= 0) Then
            'Dim GLITEMNAME As String = ActivaBaseView.GetRowCellValue(e.RowHandle, colGL_Item_Name)
            'If IsNumeric(Microsoft.VisualBasic.Right(GLITEMNAME, 2)) = True Then
            'e.Appearance.BackColor = Color.Orange
            'e.Appearance.BackColor2 = Color.Orange
            'e.Appearance.ForeColor = Color.Black
            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            'End If

            Dim GL_ITEM_NAME As String = CStr(GridView2.GetRowCellValue(e.RowHandle, colGL_Item_Name).ToString)
            If GL_ITEM_NAME = "Total" Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.BackColor2 = Color.Orange
                e.Appearance.ForeColor = Color.Black
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If


        End If
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView2_ShownEditor(sender As Object, e As EventArgs) Handles GridView2.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView4_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView4.PopupMenuShowing
        If EDP_USER = "Y" Then
            Dim View As GridView = CType(sender, GridView)

            Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

            If HitInfo.InRow AndAlso Insert_Status = "M" Then

                View.FocusedRowHandle = HitInfo.RowHandle
                Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

            End If
        End If

    End Sub

    Private Sub GridView4_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView4.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.IsGroupRow(view.FocusedRowHandle) = False Then
            ID_toDELETE = view.GetFocusedRowCellValue("ID").ToString
            Insert_Status = view.GetFocusedRowCellValue("InsertStatus").ToString
        End If
    End Sub

    Private Sub GridView4_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView4.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView4_ShownEditor(sender As Object, e As EventArgs) Handles GridView4.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GL_Item_GridlookupEdit_EditValueChanged(sender As Object, e As EventArgs) Handles GL_Item_GridlookupEdit.EditValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.GL_Item_GridlookupEdit.Properties.View, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim GL_ITEM_NAME As Object = view.GetRowCellValue(view.FocusedRowHandle, "GL_Item_Name")
        Me.GL_Item_Text_lbl.Text = GL_ITEM_NAME
    End Sub

    

    Private Sub GL_Account_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles GL_Account_LookUpEdit.EditValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.GL_Account_LookUpEdit.Properties.View, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim GL_ACCOUNT_NAME As Object = view.GetRowCellValue(view.FocusedRowHandle, "GL_AC_Name")
        Dim GL_ACCOUNT_DESCRIPTION As Object = view.GetRowCellValue(view.FocusedRowHandle, "Description")
        Me.GL_AccountName_lbl.Text = GL_ACCOUNT_NAME
        Me.GL_Account_Description_lbl.Text = GL_ACCOUNT_DESCRIPTION
    End Sub

    Private Sub BALANCES_CALCULATE()
        If IsNumeric(Me.BalanceAmount_TextEdit.Text) = True AndAlso Me.Currency_GridLookUpEdit.Text <> "" Then

            Dim BalanceAmount As Double = Me.BalanceAmount_TextEdit.Text
            Dim BalanceCurrency As String = Me.Currency_GridLookUpEdit.Text

            If BalanceAmount <> 0 Then
                If BalanceCurrency = "EUR" Then
                    If BalanceAmount > 0 Then
                        Me.DebitBalance_TextEdit.Text = "0"
                        Me.CreditBalance_TextEdit.Text = BalanceAmount
                        Me.TotalBalance_TextEdit.Text = BalanceAmount
                    ElseIf BalanceAmount < 0 Then
                        Me.DebitBalance_TextEdit.Text = BalanceAmount
                        Me.CreditBalance_TextEdit.Text = "0"
                        Me.TotalBalance_TextEdit.Text = BalanceAmount
                    End If
                ElseIf BalanceCurrency <> "EUR" Then
                    cmd.Connection.Open()
                    cmd.CommandText = "SELECT [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [CURRENCY CODE]='" & BalanceCurrency & "' and [EXCHANGE RATE DATE]='" & rdsql & "'"
                    Dim ExchangeRate As Double = cmd.ExecuteScalar
                    cmd.Connection.Close()
                    Dim BalanceEUR As Double = Math.Round(BalanceAmount / ExchangeRate, 2)
                    If BalanceAmount > 0 Then
                        Me.DebitBalance_TextEdit.Text = "0"
                        Me.CreditBalance_TextEdit.Text = BalanceEUR
                        Me.TotalBalance_TextEdit.Text = BalanceEUR
                    ElseIf BalanceAmount < 0 Then
                        Me.DebitBalance_TextEdit.Text = BalanceEUR
                        Me.CreditBalance_TextEdit.Text = "0"
                        Me.TotalBalance_TextEdit.Text = BalanceEUR
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub BalanceAmount_TextEdit_TextChanged(sender As Object, e As EventArgs) Handles BalanceAmount_TextEdit.TextChanged
        BALANCES_CALCULATE()
    End Sub

    Private Sub Currency_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Currency_GridLookUpEdit.EditValueChanged
        BALANCES_CALCULATE()
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click

        Me.Currency_GridLookUpEdit.Properties.NullText = Nothing
        Me.GL_Item_GridlookupEdit.Properties.NullText = Nothing
        Me.GL_Account_LookUpEdit.Properties.NullText = Nothing
        Me.BalanceAmount_TextEdit.Text = "0"
        Me.DebitBalance_TextEdit.Text = "0"
        Me.CreditBalance_TextEdit.Text = "0"
        Me.TotalBalance_TextEdit.Text = "0"
        Me.LayoutControl1.Visible = True
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If Me.DxValidationProvider1.Validate() = True Then

            
            Me.QueryText = "SELECT [GL_Item_Name] from [DailyBalanceSheets] where [BSDate]='" & rdsql & "'and [GL_Item]='" & Me.GL_Item_GridlookupEdit.Text & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.GL_Item_Text_lbl.Text = dt.Rows.Item(0).Item("GL_Item_Name")
            End If

            Me.QueryText = "SELECT [GL_AC_Name],[Description] from [GL_ACCOUNTS]  where [GL_AC_No]='" & Me.GL_Account_LookUpEdit.Text & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.GL_AccountName_lbl.Text = dt.Rows.Item(0).Item("GL_AC_Name")
                Me.GL_Account_Description_lbl.Text = dt.Rows.Item(0).Item("Description")
            End If
            

            If XtraMessageBox.Show("Should the Data be inserted to the Balance Sheet?" & vbNewLine & "All GL Item Sums will be recalculated!!", "INSERT GL ACCOUNT DATA TO BALANCE SHEET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Insert Data in Balance Sheet Details for " & rd)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets] ([GL_Item],[ReleatedAccountNr],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate],[InsertStatus]) VALUES(@GL_Item,@RelatedAccount,@GL_Account_Nr,@GL_ACCOUNT_Name,@OrigCUR,@OrigBalance,@BalanceEUR_CR,@BalanceEUR_DR,@TotalBalance,@BSDate,@RepDate,@InsertStatus)"
                    cmd.Parameters.Add("@GL_Item", SqlDbType.NVarChar).Value = Me.GL_Item_GridlookupEdit.Text
                    Dim RelAcc As String = Nothing
                    If IsNumeric(Me.RelatedAccount_Textedit.Text) = True Then
                        RelAcc = Me.RelatedAccount_Textedit.Text
                    Else
                        RelAcc = DBNull.Value.ToString
                    End If
                    Dim Balance_Amount As Double = Me.BalanceAmount_TextEdit.Text
                    Dim Balance_Credit As Double = Me.CreditBalance_TextEdit.Text
                    Dim Balance_Debit As Double = Me.DebitBalance_TextEdit.Text
                    Dim Balance_TOTAL As Double = Me.TotalBalance_TextEdit.Text
                    cmd.Parameters.Add("@RelatedAccount", SqlDbType.NVarChar).Value = Me.RelatedAccount_Textedit.Text
                    cmd.Parameters.Add("@GL_Account_Nr", SqlDbType.NVarChar).Value = Me.GL_Account_LookUpEdit.Text
                    cmd.Parameters.Add("@GL_ACCOUNT_Name", SqlDbType.NVarChar).Value = Me.GL_AccountName_lbl.Text
                    cmd.Parameters.Add("@OrigCUR", SqlDbType.NVarChar).Value = Me.Currency_GridLookUpEdit.Text
                    cmd.Parameters.Add("@OrigBalance", SqlDbType.Float).Value = Balance_Amount
                    cmd.Parameters.Add("@BalanceEUR_CR", SqlDbType.Float).Value = Balance_Credit
                    cmd.Parameters.Add("@BalanceEUR_DR", SqlDbType.Float).Value = Balance_Debit
                    cmd.Parameters.Add("@TotalBalance", SqlDbType.Float).Value = Balance_TOTAL
                    cmd.Parameters.Add("@BSDate", SqlDbType.DateTime).Value = rd
                    cmd.Parameters.Add("@RepDate", SqlDbType.DateTime).Value = DateAdd(DateInterval.Day, 1, rd)
                    cmd.Parameters.Add("@InsertStatus", SqlDbType.NVarChar).Value = "M"
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "Update [DailyBalanceDetailsSheets] set [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "' and [GL_Item_Number]=0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select * from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa' where [GL_Item_Number]<=2998 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa - Off Balance' where [GL_Item_Number]>=8000 and [GL_Item_Number]<=8999 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva' where [GL_Item_Number]>=3000 and [GL_Item_Number]<=4998 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva - Off Balance' where [GL_Item_Number]>=9000 and [GL_Item_Number]<=9999 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Income' where [GL_Item_Number]>=5000 and [GL_Item_Number]<=6998 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Expenses' where [GL_Item_Number]>=7000 and [GL_Item_Number]<=7998 and [BSDate]='" & rdsql & "' and [GL_Art] is NULL end"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [IdBalanceSheets] is NULL and [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Calculate Sums for DAILY BALANCE SHEET
                    cmd.CommandText = "UPDATE A SET A.[BalanceEUREqu]=B.S from [DailyBalanceSheets] A INNER JOIN (Select [GL_Item],Sum([Total_Balance]) as S,[BSDate] from [DailyBalanceDetailsSheets] where BSDate='" & rdsql & "' GROUP BY [GL_Item],[BSDate])B on A.BSDate=B.BSDate and A.GL_Item=B.GL_Item where A.BSDate='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '499
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]<499 and BSDate='" & rdsql & "') where [GL_Item_Number]=499 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '699
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>499 and [GL_Item_Number]<699 and BSDate='" & rdsql & "') where [GL_Item_Number]=699 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '1199
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>699 and [GL_Item_Number]<1199 and BSDate='" & rdsql & "') where [GL_Item_Number]=1199 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2049
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>1199 and [GL_Item_Number]<2049 and BSDate='" & rdsql & "') where [GL_Item_Number]=2049 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2099
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>2049 and [GL_Item_Number]<2099 and BSDate='" & rdsql & "') where [GL_Item_Number]=2099 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2999 (TOTAL ASSETS)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (499,699,1199,2049,2099) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>2099 and [GL_Item_Number]<2999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=2999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3199
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>2999 and [GL_Item_Number]<3199 and BSDate='" & rdsql & "') where [GL_Item_Number]=3199 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3699
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>3199 and [GL_Item_Number]<3699 and BSDate='" & rdsql & "') where [GL_Item_Number]=3699 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3899
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>3699 and [GL_Item_Number]<3899 and BSDate='" & rdsql & "') where [GL_Item_Number]=3899 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '4999 (TOTAL LIABILITIES)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (3199,3699,3899) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>3899 and [GL_Item_Number]<4999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=4999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '6999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>4999 and [GL_Item_Number]<6999 and BSDate='" & rdsql & "') where [GL_Item_Number]=6999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '7999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>6999 and [GL_Item_Number]<7999 and BSDate='" & rdsql & "') where [GL_Item_Number]=7999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '8999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>7999 and [GL_Item_Number]<8999 and BSDate='" & rdsql & "') where [GL_Item_Number]=8999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '9999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>8999 and [GL_Item_Number]<9999 and BSDate='" & rdsql & "') where [GL_Item_Number]=9999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '++++++++++++++++++++++++++++++++++++++++++++
                    'Recalculate PROFIT + LOSS
                    'Sum Expences
                    cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998"
                    Dim SumExpenses As Double = cmd.ExecuteScalar
                    'Sum Income
                    cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                    Dim SumIncome As Double = cmd.ExecuteScalar
                    '+++++++
                    Dim PROFIT_LOSS As Double = SumIncome + SumExpenses
                    If PROFIT_LOSS >= 0 Then
                        cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=" & Str(PROFIT_LOSS) & " where [GL_Item_Number]=4998 and BSDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    ElseIf PROFIT_LOSS < 0 Then
                        cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=" & Str(PROFIT_LOSS) & " where [GL_Item_Number]=2998 and BSDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    '2999 (TOTAL ASSETS)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (499,699,1199,2049,2099) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>2099 and [GL_Item_Number]<2999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=2999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '4999 (TOTAL LIABILITIES)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (3199,3699,3899) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>3899 and [GL_Item_Number]<4999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=4999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '********************************************
                    Me.LayoutControl1.Visible = True

                    '********************************************
                    'UPDATE GENERAL INFO TILES
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Sum([BalanceEUREqu]) from DailyBalanceSheets where  [GL_Item_Number]=2999 and [BSDate]='" & rdsql & "') where [Description1] in ('Sum_Activa') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Sum([BalanceEUREqu]) from DailyBalanceSheets where  [GL_Item_Number]=4999 and [BSDate]='" & rdsql & "') where [Description1] in ('Sum_Passiva') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Round(Sum([BalanceEUREqu]),2)  from DailyBalanceSheets where  [GL_Item_Number] in ('2999','4999') and [BSDate]='" & rdsql & "') where [Description1] in ('BS_Difference') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '********************************************
                    'Load Balance Sheet
                    'ACTIVA
                    Me.DailyBalanceSheets2TableAdapter.FillByActivaDate(Me.PSTOOLDataset.DailyBalanceSheets2, rd)
                    'Off-Balance
                    Me.ActivaOffBalance_DailyBalanceSheetsTableAdapter.FillByActiva_OffBalanceDate(Me.PSTOOLDataset.ActivaOffBalance_DailyBalanceSheets, rd)
                    'PASSIVA
                    Me.DailyBalanceSheets1TableAdapter.FillByPassivaDate(Me.PSTOOLDataset.DailyBalanceSheets1, rd)
                    'Off-Balance
                    Me.PassivaOffBalance_DailyBalanceSheetsTableAdapter.FillByPassiva_OffBalanceDate(Me.PSTOOLDataset.PassivaOffBalance_DailyBalanceSheets, rd)
                    'Details
                    Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, rd)
                    'Sum Activa
                    cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=2999"
                    Dim SumActiva As Double = cmd.ExecuteScalar
                    Me.SumActivaTextEdit.Text = SumActiva
                    'Sum Passiva
                    cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=4999"
                    Dim SumPassiva As Double = cmd.ExecuteScalar
                    Me.SumPassivaTextEdit.Text = SumPassiva
                    'difference
                    Me.ActivaPassivaDifferenceTextEdit.Text = SumActiva + SumPassiva

                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try



            End If
        Else
            XtraMessageBox.Show("Please check your entries!", "VALIDATION FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub


    Private Sub DeleteManual_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteManual_ToolStripMenuItem.Click
        If IsNothing(ID_toDELETE) = False AndAlso Insert_Status = "M" Then
            rd = Me.FromDateEdit.Text
            rdsql = rd.ToString("yyyyMMdd")
            If XtraMessageBox.Show("Should the current selected manual Inserted GL Item with the ID: " & ID_toDELETE & vbNewLine & "be deleted?" & vbNewLine & "All GL Item Sums will be reclaculated!!", "DELETE MANUANL INSERTED GL ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete manual inserted Data in Balance Sheet Details for " & rd)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where ID='" & ID_toDELETE & "'"
                    cmd.ExecuteNonQuery()
                    'Set all Balances in Daily Balance Sheet to 0
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] set [BalanceEUREqu]=0 where BSDate='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Calculate Sums for DAILY BALANCE SHEET
                    cmd.CommandText = "UPDATE A SET A.[BalanceEUREqu]=B.S from [DailyBalanceSheets] A INNER JOIN (Select [GL_Item],Sum([Total_Balance]) as S,[BSDate] from [DailyBalanceDetailsSheets] where BSDate='" & rdsql & "' GROUP BY [GL_Item],[BSDate])B on A.BSDate=B.BSDate and A.GL_Item=B.GL_Item where A.BSDate='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '499
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]<499 and BSDate='" & rdsql & "') where [GL_Item_Number]=499 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '699
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>499 and [GL_Item_Number]<699 and BSDate='" & rdsql & "') where [GL_Item_Number]=699 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '1199
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>699 and [GL_Item_Number]<1199 and BSDate='" & rdsql & "') where [GL_Item_Number]=1199 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2049
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>1199 and [GL_Item_Number]<2049 and BSDate='" & rdsql & "') where [GL_Item_Number]=2049 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2099
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>2049 and [GL_Item_Number]<2099 and BSDate='" & rdsql & "') where [GL_Item_Number]=2099 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '2999 (TOTAL ASSETS)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (499,699,1199,2049,2099) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>2099 and [GL_Item_Number]<2999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=2999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3199
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>2999 and [GL_Item_Number]<3199 and BSDate='" & rdsql & "') where [GL_Item_Number]=3199 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3699
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>3199 and [GL_Item_Number]<3699 and BSDate='" & rdsql & "') where [GL_Item_Number]=3699 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '3899
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>3699 and [GL_Item_Number]<3899 and BSDate='" & rdsql & "') where [GL_Item_Number]=3899 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '4999 (TOTAL LIABILITIES)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (3199,3699,3899) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>3899 and [GL_Item_Number]<4999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=4999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '6999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>4999 and [GL_Item_Number]<6999 and BSDate='" & rdsql & "') where [GL_Item_Number]=6999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '7999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>6999 and [GL_Item_Number]<7999 and BSDate='" & rdsql & "') where [GL_Item_Number]=7999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '8999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>7999 and [GL_Item_Number]<8999 and BSDate='" & rdsql & "') where [GL_Item_Number]=8999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '9999
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum([BalanceEUREqu]) from [DailyBalanceSheets] where [GL_Item_Number]>8999 and [GL_Item_Number]<9999 and BSDate='" & rdsql & "') where [GL_Item_Number]=9999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '++++++++++++++++++++++++++++++++++++++++++++
                    'Recalculate PROFIT + LOSS
                    'Sum Expences
                    cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998"
                    Dim SumExpenses As Double = cmd.ExecuteScalar
                    'Sum Income
                    cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                    Dim SumIncome As Double = cmd.ExecuteScalar
                    '+++++++
                    Dim PROFIT_LOSS As Double = SumIncome + SumExpenses
                    If PROFIT_LOSS >= 0 Then
                        cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=[BalanceEUREqu]+" & Str(PROFIT_LOSS) & " where [GL_Item_Number]=4998 and BSDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    ElseIf PROFIT_LOSS < 0 Then
                        cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=[BalanceEUREqu]+" & Str(PROFIT_LOSS) & " where [GL_Item_Number]=2998 and BSDate='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    '2999 (TOTAL ASSETS)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (499,699,1199,2049,2099) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>2099 and [GL_Item_Number]<2999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=2999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '4999 (TOTAL LIABILITIES)
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [BalanceEUREqu]=(Select Sum(A.S) from (Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number] in (3199,3699,3899) and BSDate='" & rdsql & "' UNION ALL Select Sum([BalanceEUREqu]) as S from [DailyBalanceSheets] where [GL_Item_Number]>3899 and [GL_Item_Number]<4999 and BSDate='" & rdsql & "')A) where [GL_Item_Number]=4999 and BSDate='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    '********************************************
                    'UPDATE GENERAL INFO TILES
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Sum([BalanceEUREqu]) from DailyBalanceSheets where  [GL_Item_Number]=2999 and [BSDate]='" & rdsql & "') where [Description1] in ('Sum_Activa') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Sum([BalanceEUREqu]) from DailyBalanceSheets where  [GL_Item_Number]=4999 and [BSDate]='" & rdsql & "') where [Description1] in ('Sum_Passiva') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [GeneralDataInfo] SET [Amount1]=(Select Round(Sum([BalanceEUREqu]),2)  from DailyBalanceSheets where  [GL_Item_Number] in ('2999','4999') and [BSDate]='" & rdsql & "') where [Description1] in ('BS_Difference') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '********************************************

                    'Load Balance Sheet
                    'ACTIVA
                    Me.DailyBalanceSheets2TableAdapter.FillByActivaDate(Me.PSTOOLDataset.DailyBalanceSheets2, rd)
                    'Off-Balance
                    Me.ActivaOffBalance_DailyBalanceSheetsTableAdapter.FillByActiva_OffBalanceDate(Me.PSTOOLDataset.ActivaOffBalance_DailyBalanceSheets, rd)
                    'PASSIVA
                    Me.DailyBalanceSheets1TableAdapter.FillByPassivaDate(Me.PSTOOLDataset.DailyBalanceSheets1, rd)
                    'Off-Balance
                    Me.PassivaOffBalance_DailyBalanceSheetsTableAdapter.FillByPassiva_OffBalanceDate(Me.PSTOOLDataset.PassivaOffBalance_DailyBalanceSheets, rd)
                    'Details
                    Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, rd)
                    'Sum Activa
                    cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=2999"
                    Dim SumActiva As Double = cmd.ExecuteScalar
                    Me.SumActivaTextEdit.Text = SumActiva
                    'Sum Passiva
                    cmd.CommandText = "Select ROUND(Sum([BalanceEUREqu]),2) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=4999"
                    Dim SumPassiva As Double = cmd.ExecuteScalar
                    Me.SumPassivaTextEdit.Text = SumPassiva
                    'difference
                    Me.ActivaPassivaDifferenceTextEdit.Text = SumActiva + SumPassiva

                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If

        End If
    End Sub

    Private Sub GL_Account_LookUpEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles GL_Account_LookUpEdit.KeyDown
        Me.GL_Account_LookUpEdit.ShowPopup()

    End Sub

    Private Sub GL_Item_GridlookupEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles GL_Item_GridlookupEdit.KeyDown
        Me.GL_Item_GridlookupEdit.ShowPopup()

    End Sub
End Class