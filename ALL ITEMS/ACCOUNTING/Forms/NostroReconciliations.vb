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
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing

Public Class NostroReconciliations

    Dim CrystalRepDir As String = ""
    Dim CREATE_DUMMY_BOOKINGS As String = Nothing
    Dim ActiveTabGroup As Double = 0
    Dim ActiveTabGroupQueries As Double = 0

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim d As Date
    Dim dsql As String = Nothing
    Dim rd As Date
    Dim rdsql As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Dim dtID As New DataTable

    Dim LastRecDate As Date
    Dim LastRecDate_ALL_NOSTROS As Date
    Dim NostroAccount As String = Nothing
    Dim Currency As String = Nothing
    Dim NostroName As String = Nothing
    Dim NostroAccountExternal As String = Nothing
    Private BS_OutstandingBookings As BindingSource
    Private BS_LastReconciliations As BindingSource
    Dim ID_OUTSTANDING_BOOKING As String = Nothing

    Dim NostroAccount_LastReconcile As String = Nothing
    Dim NostroAccountName_LastReconcile As String = Nothing
    Dim NostroAccountCCY_LastReconcile As String = Nothing
    Dim rdlr As Date
    Dim rdlrsql As String = Nothing

    Dim Balance_IB As Double = 0
    Dim Balance_EB As Double = 0

    Dim ID_MAIN As Integer = 0
    Dim BOOKING_ROUTE_MAIN As String = Nothing
    Dim BOOKING_ID_MAIN As String = Nothing
    Dim DESCRIPTION_MAIN As String = Nothing
    Dim BOOKING_DATE_MAIN As Date
    Dim VALUE_DATE_MAIN As Date
    Dim CUR_MAIN As String = Nothing
    Dim AMOUNT_MAIN As Double = 0
    Dim POSTING_TYPE_MAIN As String = Nothing
    Dim USER_MEMO_MAIN As String = Nothing

    Dim d1 As Date
    Dim d2 As Date
    Dim sqld1 As String = Nothing
    Dim sqld2 As String = Nothing
    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing

    'Strings for Contextmenu Reset Bookings
    Dim RESET_ID As String = Nothing
    Dim RESET_RECONCILIATION_NR As Integer = 0
    Dim RESET_RECONCILITION_DATE As Date
    Dim RESET_RECONCILE_STATUS As String = Nothing
    Dim RESET_BookingRoute_IB As String = Nothing
    Dim RESET_ID_IB As String = Nothing
    Dim RESET_BookingRoute_EB As String = Nothing
    Dim RESET_ID_EB As String = Nothing
    Dim RESET_NOSTRO_ACC As String = Nothing

    'Balance Outstanding
    Dim CheckFieldValueDate As Date
    Dim CheckFieldBookingRoute As String = Nothing
    Dim SumBalanceOutstandingINTERNAL As Double = 0
    Dim SumBalanceOutstandingEXTERNAL As Double = 0
    Dim SelectedSum As Double = 0
    Dim InternalBookingSelected As Boolean = False

    Dim SUM_AMT_SELECTED As Double = 0
    Dim NewDP As New NostroReconciliationManItems()

    


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

    Private Sub NostroReconciliations_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Get connection
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 50000
        'Me.External_BaseView.ActiveFilterString = "[SwiftTagName] NOT LIKE 'Intermed%'"

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='NostroReconcileCreateDummyBookings' and [IdABTEILUNGSPARAMETER]='NOSTRO_RECONCILIATION' and [PARAMETER STATUS]='Y' "
        CREATE_DUMMY_BOOKINGS = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        AddHandler GridControl_OutstandingBookings.EmbeddedNavigator.ButtonClick, AddressOf GridControl_OutstandingBookings_EmbeddedNavigator_ButtonClick

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),Max([ReconcileDate]),104) as 'RLDC Date' from [NOSTRO_ACC_RECONCILIATIONS]"
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

        LastRecDate_ALL_NOSTROS = Me.FromDateEdit.Text
        CreateMissingRecon_FromDateEdit.Text = LastRecDate_ALL_NOSTROS

        'Load Nostro Accounts with their Reconciliation Date
        Dim objCMD As SqlCommand = New SqlCommand("Select C.[ReconcileDate],C.[CCY_IB],C.[AccountNr_Internal],C.[AccountName_Internal],C.AccountIdentifierStatement from (Select A.[ReconcileDate] as 'ReconcileDate',A.[CCY_IB] as 'CCY_IB',A.[AccountNr_Internal] as 'AccountNr_Internal',A.[AccountName_Internal] as 'AccountName_Internal',B.AccountIdentifierStatement as 'AccountIdentifierStatement' from [NOSTRO_ACC_RECONCILIATIONS] A INNER JOIN SSIS B on A.[AccountNr_Internal]=B.[INTERNAL ACCOUNT] GROUP BY A.[ReconcileDate],A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement UNION ALL Select A.[ReconcileDate] as 'ReconcileDate',A.[CCY_IB] as 'CCY_IB',A.[AccountNr_Internal] as 'AccountNr_Internal',A.[AccountName_Internal] as 'AccountName_Internal',B.AccountIdentifierStatement as 'AccountIdentifierStatement' from [NOSTRO_ACC_RECONCILIATIONS_OPEN] A INNER JOIN SSIS B on A.[AccountNr_Internal]=B.[INTERNAL ACCOUNT] GROUP BY A.[ReconcileDate],A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement)C where C.[CCY_IB] is not NULL GROUP BY C.[ReconcileDate],C.[CCY_IB],C.[AccountNr_Internal],C.[AccountName_Internal],C.AccountIdentifierStatement ORDER BY C.[ReconcileDate] desc", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.NostroAcc_SearchLookUpEdit.Properties.DataSource = Nothing
            Me.NostroAcc_SearchLookUpEdit.Properties.DataSource = dt
        End If
       

        'Load all Nostro Accounts which are set for reconciliation
        Dim objCMD1 As SqlCommand = New SqlCommand("Select A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement from [NOSTRO_ACC_RECONCILIATIONS] A INNER JOIN SSIS B on A.[AccountNr_Internal]=B.[INTERNAL ACCOUNT] GROUP BY A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement order by AccountNr_Internal asc", conn)
        objCMD1.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD1)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.OCBS_LookUpEdit.Properties.DataSource = Nothing
            Me.OCBS_LookUpEdit.Properties.DataSource = dt
            Me.NostrosForMissingRecon_SearchLookUpEdit.Properties.DataSource = Nothing
            Me.NostrosForMissingRecon_SearchLookUpEdit.Properties.DataSource = dt
        End If

        'Me.LayoutControlGroup8.Visibility = LayoutVisibility.Never

        'Add column to Datatable for ID's
        dtID.Columns.Add("ID", GetType(Integer))
        dtID.Columns.Add("BookingRoute_IB", GetType(String))
        dtID.Columns.Add("BookingDate_IB", GetType(Date))
        dtID.Columns.Add("ValueDate_IB", GetType(Date))
        dtID.Columns.Add("CCY_IB", GetType(String))
        dtID.Columns.Add("Amount_IB", GetType(Double))
        dtID.Columns.Add("Description_IB", GetType(String))
        dtID.Columns.Add("Reference_AccountOwner_IB_First", GetType(String))
        dtID.Columns.Add("Reference_AccountOwner_IB_Second", GetType(String))
        dtID.Columns.Add("PostingType", GetType(String))
    End Sub

    Private Sub GridControl_OutstandingBookings_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "Reconcile" Then
            MANUAL_RECONCILIATION()
        End If
    End Sub


    Private Sub NOSTRO_RECONCILIATIONS_FILL()
        'Dim objCMD1 As SqlCommand = New SqlCommand("exec [NOSTRO_REC_FILL] @RISKDATE='" & rdsql & "',@NOSTRO_ACCOUNT='" & Me.NostroAcc_SearchLookUpEdit.Text & "'", conn)
        Dim objCMD1 As SqlCommand = New SqlCommand("Select [BalanceDate] as 'BookingDate_IB',[Value Balance] as 'Amount_IB' from [NOSTRO BALANCES] where [BalanceDate]= CASE WHEN exists(Select [BalanceDate] from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]='" & rdsql & "') THEN  (Select [BalanceDate] from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]='" & rdsql & "') ELSE (SELECT MAX([BalanceDate]) AS second FROM   [NOSTRO BALANCES] WHERE  [BalanceDate] <= '" & rdsql & "' and [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "') END and [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "'", conn)
        objCMD1.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD1)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.InternalValueBalanceDate_TextEdit.Text = dt.Rows.Item(0).Item("BookingDate_IB")
            Me.InternalValueBalanceAmount_TextEdit.Text = FormatNumber(dt.Rows.Item(0).Item("Amount_IB"), 2)
            'Me.GridControl_Internal.DataSource = Nothing
            'Me.GridControl_Internal.DataSource = dt
            'Me.GridControl_Internal.ForceInitialize()
        End If
    End Sub

    Private Sub SWIFT_ACC_BALANCES_FILL()

        'FILL SWIFT ACC BALANCES
        'Dim objCMD2 As SqlCommand = New SqlCommand("exec [SWIFT_ACCOUNT_STATEMENTS_BOOKING_DATE] @FROMDATE='" & rdsql & "', @TILLDATE='" & rdsql & "',@ACCOUNT_NR='" & NostroAccount & "'", conn)
        Dim objCMD2 As SqlCommand = New SqlCommand("SELECT [BookingDate],[Amount] FROM  [SWIFT_ACC_STATEMENTS] WHERE  [InternalAccount]= '" & Me.NostroAcc_SearchLookUpEdit.Text & "' AND [BookingDate] ='" & rdsql & "' and SwiftTag in ('62F') ", conn)
        objCMD2.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD2)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.ExternalBookedBalanceDate_TextEdit.Text = dt.Rows.Item(0).Item("BookingDate")
            Me.ExternalBookedBalanceAmount_TextEdit.Text = FormatNumber(dt.Rows.Item(0).Item("Amount"), 2)

        Else
            'Dim objCMD3 As SqlCommand = New SqlCommand("exec [SWIFT_ACCOUNT_STATEMENTS_BOOKING_DATE_LastBalance] @RISKDATE='" & rdsql & "',@ACCOUNT_NR='" & NostroAccount & "'", conn)
            Dim objCMD3 As SqlCommand = New SqlCommand("SELECT [BookingDate],[Amount] FROM  [SWIFT_ACC_STATEMENTS] WHERE  ([InternalAccount]= '" & Me.NostroAcc_SearchLookUpEdit.Text & "') AND [SwiftTag] in ('62F') AND ([BookingDate] = (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and SwiftTag in ('62F') and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM  [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "' and SwiftTag in ('62F'))))", conn)
            objCMD3.CommandTimeout = 5000
            da1 = New SqlDataAdapter(objCMD3)
            dt1 = New DataTable()
            da1.Fill(dt1)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                Me.ExternalBookedBalanceDate_TextEdit.Text = dt1.Rows.Item(0).Item("BookingDate")
                Me.ExternalBookedBalanceAmount_TextEdit.Text = FormatNumber(dt1.Rows.Item(0).Item("Amount"), 2)
            Else
                Me.ExternalBookedBalanceDate_TextEdit.Text = ""
                Me.ExternalBookedBalanceAmount_TextEdit.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub NostroAcc_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles NostroAcc_SearchLookUpEdit.ButtonClick
        NostroOutstandingBookings_GridView.ClearSelection()
        dtID.Clear()

        If e.Button.Caption = "Reload" Then
            'Load Nostro Accounts with their Reconciliation Date
            Dim objCMD As SqlCommand = New SqlCommand("Select C.[ReconcileDate],C.[CCY_IB],C.[AccountNr_Internal],C.[AccountName_Internal],C.AccountIdentifierStatement from (Select A.[ReconcileDate] as 'ReconcileDate',A.[CCY_IB] as 'CCY_IB',A.[AccountNr_Internal] as 'AccountNr_Internal',A.[AccountName_Internal] as 'AccountName_Internal',B.AccountIdentifierStatement as 'AccountIdentifierStatement' from [NOSTRO_ACC_RECONCILIATIONS] A INNER JOIN SSIS B on A.[AccountNr_Internal]=B.[INTERNAL ACCOUNT] GROUP BY A.[ReconcileDate],A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement UNION ALL Select A.[ReconcileDate] as 'ReconcileDate',A.[CCY_IB] as 'CCY_IB',A.[AccountNr_Internal] as 'AccountNr_Internal',A.[AccountName_Internal] as 'AccountName_Internal',B.AccountIdentifierStatement as 'AccountIdentifierStatement' from [NOSTRO_ACC_RECONCILIATIONS_OPEN] A INNER JOIN SSIS B on A.[AccountNr_Internal]=B.[INTERNAL ACCOUNT] GROUP BY A.[ReconcileDate],A.[CCY_IB],A.[AccountNr_Internal],A.[AccountName_Internal],B.AccountIdentifierStatement)C where C.[CCY_IB] is not NULL GROUP BY C.[ReconcileDate],C.[CCY_IB],C.[AccountNr_Internal],C.[AccountName_Internal],C.AccountIdentifierStatement ORDER BY C.[ReconcileDate] desc", conn)
            objCMD.CommandTimeout = 5000
            da = New SqlDataAdapter(objCMD)
            dt = New DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.NostroAcc_SearchLookUpEdit.Properties.DataSource = Nothing
                Me.NostroAcc_SearchLookUpEdit.Properties.DataSource = dt
            End If
        End If
        If e.Button.Caption = "Restart" Then
            If Me.NostroAcc_SearchLookUpEdit.Text <> "" Then
                If XtraMessageBox.Show("Should the Reconciliation for Nostro Account: " & NostroAccount & " be re-executed for the last outstanding Bookings?", "MANUAL RECONCILIATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Restart Reconciliation for Nostro Account: " & NostroAccount & "  on " & rd)
                        Dim objCMD As SqlCommand = New SqlCommand("exec [RECONCILE_NOSTRO_ACCOUNTS_MANUAL] @RISKDATE='" & rdsql & "',@INTERNAL_NOSTRO_ACCOUNT='" & NostroAccount & "'", conn)
                        objCMD.CommandTimeout = 50000
                        If objCMD.Connection.State = ConnectionState.Closed Then
                            objCMD.Connection.Open()
                        End If
                        objCMD.ExecuteNonQuery()
                        objCMD = New SqlCommand("UPDATE PARAMETER SET PARAMETER2='N' where PARAMETER1='NostroReconciliationTaskStatus' and IdABTEILUNGSPARAMETER='NOSTRO_RECONCILIATION'", conn)
                        objCMD.ExecuteNonQuery()
                       
                        NOSTRO_RECONCILIATIONS_FILL()
                        SWIFT_ACC_BALANCES_FILL()

                        'Balance difference (Internal-External)
                        Balance_IB = Me.InternalValueBalanceAmount_TextEdit.Text
                        Balance_EB = Me.ExternalBookedBalanceAmount_TextEdit.Text
                        Dim InternalExternalDifference As Double = 0
                        InternalExternalDifference = Balance_IB - Balance_EB
                        Me.InternalExternalDifferenceTextEdit.Text = Balance_IB - Balance_EB

                        'Get Totals Difference
                        Dim Outstandings_Credits As Double = 0
                        Dim Outstandings_Debits As Double = 0
                        Dim Outstandings_Difference As Double = 0
                        Dim ALL_DIFFERENCE As Double = 0
                        If LastRecDate = rd Then
                            objCMD.CommandText = "SELECT 'SUM_INTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ValueDate_IB]<='" & rdsql & "') is not NULL then (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ValueDate_IB]<='" & rdsql & "') else 0 end"
                            Outstandings_Credits = objCMD.ExecuteScalar
                            objCMD.CommandText = "SELECT 'SUM_ALL_EXTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL')) is not NULL then (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL')) else 0 end"
                            Outstandings_Debits = objCMD.ExecuteScalar
                            Outstandings_Difference = Outstandings_Credits + Outstandings_Debits
                            ALL_DIFFERENCE = InternalExternalDifference + Outstandings_Difference
                            Me.TotalsDifference_TextEdit.Text = FormatNumber(ALL_DIFFERENCE, 2)
                        End If
                        If objCMD.Connection.State = ConnectionState.Open Then
                            objCMD.Connection.Close()
                        End If

                        Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, NostroAccount, rd)


                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try

                End If

            End If
        End If

    End Sub




    Private Sub NostroAcc_SearchLookUpEdit_Click(sender As Object, e As EventArgs) Handles NostroAcc_SearchLookUpEdit.Click

        If Me.NostroAcc_SearchLookUpEdit.Text = "" Then
            Me.NostroAcc_SearchLookUpEdit.Text = ""
            Me.NostroInfo_MemoEdit.Text = ""
            Me.InternalValueBalanceDate_TextEdit.Text = ""
            Me.InternalValueBalanceAmount_TextEdit.Text = ""
            Me.ExternalBookedBalanceDate_TextEdit.Text = ""
            Me.ExternalBookedBalanceAmount_TextEdit.Text = ""
            Me.InternalExternalDifferenceTextEdit.Text = ""
            Me.TotalsDifference_TextEdit.Text = ""
            Me.ReconciliationDate_TextEdit.Text = ""
            Me.GridControl_Internal.DataSource = Nothing
            Me.GridControl_External.DataSource = Nothing
            Me.GridControl3.DataSource = Nothing
            Me.GridControl4.DataSource = Nothing
            Me.GridControl_OutstandingBookings.DataSource = Nothing
        End If



    End Sub

    Private Sub NostroAcc_SearchLookUpEditView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles NostroAcc_SearchLookUpEditView.FocusedRowChanged
        'Do not select grouped row
        Dim view As GridView = DirectCast(sender, GridView)
        If e.FocusedRowHandle < 0 Then
            view.FocusedRowHandle = If(e.PrevFocusedRowHandle = GridControl.InvalidRowHandle, 0, e.PrevFocusedRowHandle)
        End If

        Me.NostroAcc_SearchLookUpEdit.Text = ""
        Me.NostroInfo_MemoEdit.Text = ""
        Me.InternalValueBalanceDate_TextEdit.Text = ""
        Me.InternalValueBalanceAmount_TextEdit.Text = ""
        Me.ExternalBookedBalanceDate_TextEdit.Text = ""
        Me.ExternalBookedBalanceAmount_TextEdit.Text = ""
        Me.InternalExternalDifferenceTextEdit.Text = ""
        Me.TotalsDifference_TextEdit.Text = ""
        Me.ReconciliationDate_TextEdit.Text = ""
        Me.GridControl_Internal.DataSource = Nothing
        Me.GridControl_External.DataSource = Nothing
        Me.GridControl3.DataSource = Nothing
        Me.GridControl4.DataSource = Nothing
        Me.GridControl_OutstandingBookings.DataSource = Nothing
    End Sub

    Private Sub NostroAcc_SearchLookUpEdit_TextChanged(sender As Object, e As EventArgs) Handles NostroAcc_SearchLookUpEdit.TextChanged
        If Me.NostroAcc_SearchLookUpEdit.Text <> Nothing Then
            Me.ReconciliationReportsCurrent_BarSubItem.Visibility = BarItemVisibility.Always
        Else
            Me.ReconciliationReportsCurrent_BarSubItem.Visibility = BarItemVisibility.Never
        End If
    End Sub


    Private Sub NostroAcc_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NostroAcc_SearchLookUpEdit.EditValueChanged
        If NostroAcc_SearchLookUpEdit.Text <> "" Then
            Dim view As GridView = NostroAcc_SearchLookUpEdit.Properties.View
            Dim rowHandle As Integer = view.FocusedRowHandle
            NostroAccount = view.GetRowCellValue(rowHandle, "AccountNr_Internal")
            NostroAccountExternal = view.GetRowCellValue(rowHandle, "AccountIdentifierStatement")
            Currency = view.GetRowCellValue(rowHandle, "CCY_IB")
            Dim NostroName As String = view.GetRowCellValue(rowHandle, "AccountName_Internal")
            rd = view.GetRowCellValue(rowHandle, "ReconcileDate")
            rdsql = rd.ToString("yyyyMMdd")
            Me.NostroInfo_MemoEdit.Text = "(" & Currency & ")" & "  " & NostroName & "  Extern: " & NostroAccountExternal
            Me.ReconciliationDate_TextEdit.Text = rd

            'Get Edit Values
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            NostroAccount = editor.Properties.GetDisplayValueByKeyValue(editor.EditValue)
            Dim NostroAccountsRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            NostroAccountExternal = NostroAccountsRow("AccountIdentifierStatement")
            Currency = NostroAccountsRow("CCY_IB")
            NostroName = NostroAccountsRow("AccountName_Internal")
            'rd = NostroAccountsRow("ReconcileDate")
            'rdsql = rd.ToString("yyyyMMdd")
            Me.NostroInfo_MemoEdit.Text = "(" & Currency & ")" & "  " & NostroName & "  Extern: " & NostroAccountExternal
            'Me.ReconciliationDate_TextEdit.Text = rd

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Reconciliation Data for " & rd & "  Account:" & NostroAcc_SearchLookUpEdit.Text)


            NOSTRO_RECONCILIATIONS_FILL()
            SWIFT_ACC_BALANCES_FILL()

            'Bind Combobox with the latest reconcile date of the Nostro Account
            Me.FromDateEdit.Properties.Items.Clear()
            Me.QueryText = "Select Max(A.[RLDC Date]) as 'RLDC Date' from (Select Max([ReconcileDate]) as 'RLDC Date' from [NOSTRO_ACC_RECONCILIATIONS] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' UNION ALL Select Max([ReconcileDate]) as 'RLDC Date' from [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "')A" 'GROUP BY [ReconcileDate] ORDER BY [ReconcileDate] desc"
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



            'FILL OUTSTANDING BOOKINGS
            LastRecDate = Me.FromDateEdit.Text
            If LastRecDate = rd Then
                'Me.LayoutControlGroup8.Visibility = LayoutVisibility.Always
                Me.GridControl_Internal.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                Me.GridControl_External.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                Me.GridControl3.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                Me.GridControl4.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                Me.GridControl_OutstandingBookings.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                Me.GridControl_OutstandingBookings.UseEmbeddedNavigator = True
                Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, Me.NostroAcc_SearchLookUpEdit.Text, rd)
                Me.NostroAcc_SearchLookUpEdit.Properties.Buttons(2).Visible = True

            Else
                'Me.LayoutControlGroup8.Visibility = LayoutVisibility.Always
                Me.GridControl_Internal.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYBindingSource
                Me.GridControl_External.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYBindingSource
                Me.GridControl3.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYBindingSource
                Me.GridControl4.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYBindingSource
                Me.GridControl_OutstandingBookings.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYBindingSource
                Me.GridControl_OutstandingBookings.UseEmbeddedNavigator = False
                Me.NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORYTableAdapter.FillByRecAccOpenHistory(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY, Me.NostroAcc_SearchLookUpEdit.Text, rd)
                Me.NostroAcc_SearchLookUpEdit.Properties.Buttons(2).Visible = False

            End If

            'Calculating balance differences between Internal and External booked balances
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            'In the old Code after Else 0
            'cmd.CommandText = "Select 'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]='" & rdsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]='" & rdsql & "') else (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]=(Select Max([BalanceDate]) from [NOSTRO BALANCES] where [Nostro Code]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BalanceDate]<='" & rdsql & "'))  end"
            'Balance_IB = cmd.ExecuteScalar

            'cmd.CommandText = " Select '62F'=Case when exists(Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else 0 end"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'Balance_EB = cmd.ExecuteScalar
            'Else
            'cmd.CommandText = "Select '62F'=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') is not NULL then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [SwiftTag] in ('62F') and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "' and [SwiftTag] in ('62F'))))  end"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'Balance_EB = cmd.ExecuteScalar
            'Else
            'Balance_EB = 0
            'End If
            'End If

            'Balance difference (Internal-External)
            Balance_IB = Me.InternalValueBalanceAmount_TextEdit.Text
            Balance_EB = Me.ExternalBookedBalanceAmount_TextEdit.Text
            Dim InternalExternalDifference As Double = 0
            InternalExternalDifference = Balance_IB - Balance_EB
            Me.InternalExternalDifferenceTextEdit.Text = Balance_IB - Balance_EB

            'Get Totals Difference
            Dim Outstandings_Credits As Double = 0
            Dim Outstandings_Debits As Double = 0
            Dim Outstandings_Difference As Double = 0
            Dim ALL_DIFFERENCE As Double = 0
            If LastRecDate = rd Then
                cmd.CommandText = "SELECT 'SUM_INTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ValueDate_IB]<='" & rdsql & "') is not NULL then (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ValueDate_IB]<='" & rdsql & "') else 0 end"
                Outstandings_Credits = cmd.ExecuteScalar
                cmd.CommandText = "SELECT 'SUM_ALL_EXTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL') and [BookingDate_EB]<='" & rdsql & "') is not NULL then (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL') and [BookingDate_EB]<='" & rdsql & "') else 0 end"
                Outstandings_Debits = cmd.ExecuteScalar
                Outstandings_Difference = Outstandings_Credits + Outstandings_Debits
                ALL_DIFFERENCE = InternalExternalDifference + Outstandings_Difference
                Me.TotalsDifference_TextEdit.Text = FormatNumber(ALL_DIFFERENCE, 2)
            Else
                cmd.CommandText = "SELECT 'SUM_INTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ReconcileDate]='" & rdsql & "' and [ValueDate_IB]<='" & rdsql & "') is not NULL then (Select Sum([Amount_IB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_IB] in ('INTERNAL') and [ReconcileDate]='" & rdsql & "' and [ValueDate_IB]<='" & rdsql & "') else 0 end"
                Outstandings_Credits = cmd.ExecuteScalar
                cmd.CommandText = "SELECT 'SUM_ALL_EXTERNAL_OUTSTANDINGS'=Case when (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL') and [ReconcileDate]='" & rdsql & "' and [BookingDate_EB]<='" & rdsql & "') is not NULL then (Select Sum([Amount_EB]) FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where AccountNr_Internal='" & Me.NostroAcc_SearchLookUpEdit.Text & "' and [BookingRoute_EB] in ('EXTERNAL') and [ReconcileDate]='" & rdsql & "' and [BookingDate_EB]<='" & rdsql & "') else 0 end"
                Outstandings_Debits = cmd.ExecuteScalar
                Outstandings_Difference = Outstandings_Credits + Outstandings_Debits
                ALL_DIFFERENCE = InternalExternalDifference + Outstandings_Difference
                Me.TotalsDifference_TextEdit.Text = FormatNumber(ALL_DIFFERENCE, 2)
            End If


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            SplashScreenManager.CloseForm(False)
        Else
            Me.InternalExternalDifferenceTextEdit.Text = ""
            Me.NostroInfo_MemoEdit.Text = ""
            Me.ReconciliationDate_TextEdit.Text = ""
            Me.GridControl_Internal.DataSource = Nothing
            Me.GridControl_External.DataSource = Nothing
            Me.GridControl_OutstandingBookings.DataSource = Nothing

            NostroOutstandingBookings_GridView.ClearSelection()
            dtID.Clear()

        End If

    End Sub

   

    Private Sub GridControl_OutstandingBookings_Paint(sender As Object, e As PaintEventArgs) Handles GridControl_OutstandingBookings.Paint
        Dim viewInfo As GridViewInfo = CType(Me.NostroOutstandingBookings_GridView.GetViewInfo(), GridViewInfo)
        Dim r As Rectangle = viewInfo.ViewCaptionBounds
        Dim f As Font = New Font(Me.NostroOutstandingBookings_GridView.Appearance.ViewCaption.Font.FontFamily, 9.0F, FontStyle.Bold)

        Dim backColor As Color = Me.NostroOutstandingBookings_GridView.PaintAppearance.ViewCaption.BackColor
        Dim foreColor As Color = Color.White

        If Me.ReconciliationDate_TextEdit.Text <> "" Then
            e.Graphics.FillRectangle(Brushes.Red, r)
            e.Graphics.DrawString("A L L   O U T S T A N D I N G    B O O K I N G S  on " & rd & "  for Nostro Account: " & Me.NostroAcc_SearchLookUpEdit.Text & "  " & Me.NostroInfo_MemoEdit.Text, f, New SolidBrush(foreColor), r, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            e.Graphics.FillRectangle(Brushes.Red, r)
            e.Graphics.DrawString("A L L   O U T S T A N D I N G    B O O K I N G S", f, New SolidBrush(foreColor), r, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If

    End Sub


    Private Sub NostroOutstandingBookings_GridView_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles NostroOutstandingBookings_GridView.CustomDrawFooterCell
        e.Appearance.ForeColor = Color.Cyan
    End Sub

    Private Sub NostroOutstandingBookings_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles NostroOutstandingBookings_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            SumBalanceOutstandingINTERNAL = 0
            SumBalanceOutstandingEXTERNAL = 0
            SelectedSum = 0
        End If
        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            CheckFieldValueDate = View.GetRowCellValue(e.RowHandle, colUB_ValueDate)
            CheckFieldBookingRoute = View.GetRowCellValue(e.RowHandle, colUB_BookingRoute)
            If summaryID = 0 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colUB_Amount))
                If CheckFieldValueDate <= rd And CheckFieldBookingRoute = "INTERNAL" Then
                    SumBalanceOutstandingINTERNAL += Convert.ToDecimal(e.FieldValue)
                End If
                If CheckFieldBookingRoute = "EXTERNAL" Then
                    SumBalanceOutstandingEXTERNAL += Convert.ToDecimal(e.FieldValue)
                End If
            End If
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, colUB_Amount))
                If View.IsRowSelected(e.RowHandle) Then
                    SelectedSum += Convert.ToDecimal(e.FieldValue)
                End If

            End If
        End If
        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 0 Then
                e.TotalValue = SumBalanceOutstandingINTERNAL + SumBalanceOutstandingEXTERNAL
            End If
            If summaryID = 1 Then
                e.TotalValue = SelectedSum
            End If
        End If

    End Sub

    Private Sub NostroOutstandingBookings_GridView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles NostroOutstandingBookings_GridView.SelectionChanged
        Dim view As GridView = Me.NostroOutstandingBookings_GridView
        dtID.Clear()
        GetSelectedRows(view)
        GetSelectedRowsSum(view)
        NostroOutstandingBookings_GridView.UpdateSummary()

    End Sub



    Private Sub NostroOutstandingBookings_GridView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles NostroOutstandingBookings_GridView.ShowingEditor

        If LastRecDate <> rd Then
            e.Cancel = True
        ElseIf LastRecDate = rd Then
            Dim view As GridView = TryCast(sender, GridView)
            Dim rowHandle As Integer = view.FocusedRowHandle
            BOOKING_ROUTE_MAIN = view.GetRowCellValue(rowHandle, colUB_BookingRoute)
            BOOKING_ID_MAIN = view.GetRowCellValue(rowHandle, colID1)
            DESCRIPTION_MAIN = If(IsDBNull(view.GetRowCellValue(rowHandle, colUB_Description)), "", view.GetRowCellValue(rowHandle, colUB_Description))
            BOOKING_DATE_MAIN = view.GetRowCellValue(rowHandle, colUB_BookingDate)
            VALUE_DATE_MAIN = view.GetRowCellValue(rowHandle, colUB_ValueDate)
            CUR_MAIN = view.GetRowCellValue(rowHandle, colUB_CCY)
            AMOUNT_MAIN = view.GetRowCellValue(rowHandle, colUB_Amount)
            POSTING_TYPE_MAIN = If(IsDBNull(view.GetRowCellValue(rowHandle, colPostingType)), "", view.GetRowCellValue(rowHandle, colPostingType))
            USER_MEMO_MAIN = If(IsDBNull(view.GetRowCellValue(rowHandle, colUserMemo)), "", view.GetRowCellValue(rowHandle, colUserMemo))


            Me.BOOKING_ROUTE_ALL_TextEdit.Text = BOOKING_ROUTE_MAIN
            Me.ID_NOSTRO_REC_Textedit.Text = BOOKING_ID_MAIN
            Me.Description_IB_TextEdit.Text = DESCRIPTION_MAIN
            Me.Bookingdate_IB_TextEdit.Text = BOOKING_DATE_MAIN
            Me.Valuedate_IB_TextEdit1.Text = VALUE_DATE_MAIN
            Me.CCY_IB_TextEdit.Text = CUR_MAIN
            Me.Amount_IB_TextEdit.Text = Format(AMOUNT_MAIN, "#,##0.00")
            Me.PostingType_IB_TextEdit.Text = POSTING_TYPE_MAIN
            Me.UserMemo_MemoEdit.Text = USER_MEMO_MAIN

        End If


    End Sub



    Private Sub OUTSTANDING_BOOKINGS_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbOutstandingBooking As SqlDataAdapter = New SqlDataAdapter("Select * from [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [AccountNr_Internal]='" & NostroAccount & "' and [ID]<> '" & ID_OUTSTANDING_BOOKING & "' and [ReconcileDate]='" & rdsql & "' and [Reconciled] in ('N')", conn) '
        Try

            dbOutstandingBooking.Fill(ds, "NOSTRO_ACC_RECONCILIATIONS_OPEN")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_OutstandingBookings = New BindingSource(ds, "NOSTRO_ACC_RECONCILIATIONS_OPEN")

    End Sub

    Private Sub OUTSTANDING_BOOKINGS_InitLookUp()
        ' Me.OutstandingBookings_LookUpEdit.Properties.DataSource = BS_OutstandingBookings
        'Me.OutstandingBookings_LookUpEdit.Properties.DisplayMember = "ID"
        'Me.OutstandingBookings_LookUpEdit.Properties.ValueMember = "ID"
    End Sub

    Private Sub LAST_RECONCILIATIONS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("exec [NOSTRO_LAST_RECONCILIATIONS]", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbLastReconciliations.Fill(ds, "NOSTRO_LAST_RECONCILIATIONS") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_LastReconciliations = New BindingSource(ds, "NOSTRO_LAST_RECONCILIATIONS") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub LAST_RECONCILIATIONS_InitLookUp()
        Me.RepositoryItemGridLookUpEdit2.DataSource = BS_LastReconciliations
        Me.RepositoryItemGridLookUpEdit2.DisplayMember = "Nostro Account"
        Me.RepositoryItemGridLookUpEdit2.ValueMember = "Nostro Account"
    End Sub


#Region "RECONCILIATION MANUAL"

    Private Sub MANUAL_RECONCILIATION()
        'Test
        If dtID.Rows.Count > 0 Then
            'Dim strQuery As String = "Forename ='" & forename & "' and Surname = '" & surname & "'"

            Dim result() As DataRow = dtID.Select("ValueDate_IB >'" & rd & "'")
            If result.Length <> 0 Then
                XtraMessageBox.Show("There's at least 1 Posting Item with Value Date higher than the Current Date" & vbNewLine & "+++ RECONCILIATIONS FOR POSTINGS WITH FUTURE VALUE ARE NOT ALLOWED +++", "MANUAL RECONCILIATION ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return

            End If
           
        End If
        If dtID.Rows.Count > 0 Then
            Dim SumResult As Double = 0
            SumResult = dtID.Compute("SUM(Amount_IB)", "")
            If FormatNumber(SelectedSum, 2) = 0 Then
                Dim OutstandingsForReconciliation As String = Nothing
                For i = 0 To dtID.Rows.Count - 1
                    OutstandingsForReconciliation += dtID.Rows.Item(i).Item("BookingRoute_IB") & "  Booking Date:" & dtID.Rows.Item(i).Item("BookingDate_IB") & "  Value Date:" & dtID.Rows.Item(i).Item("ValueDate_IB") & "  Amount: " & dtID.Rows.Item(i).Item("CCY_IB") & "  " & FormatNumber(dtID.Rows.Item(i).Item("Amount_IB"), 2) & vbNewLine & "Posting Reference:" & vbNewLine & dtID.Rows.Item(i).Item("Description_IB") & vbNewLine & dtID.Rows.Item(i).Item("Reference_AccountOwner_IB_First") & vbNewLine & dtID.Rows.Item(i).Item("Reference_AccountOwner_IB_First") & vbNewLine & dtID.Rows.Item(i).Item("PostingType") & vbNewLine & vbNewLine
                Next
                Try

                    Dim dxOK_NewDP As New DevExpress.XtraEditors.SimpleButton
                    With dxOK_NewDP
                        .Text = NewDP.Reconcile_btn.Text
                        .Height = 22
                        .Width = 155
                        .ImageList = NewDP.ImageCollection1
                        .ImageIndex = 10
                        .Location = New System.Drawing.Point(5, 617)
                    End With

                    NewDP.Controls.Add(dxOK_NewDP)
                    NewDP.Reconcile_btn.Visible = False


                    NewDP.GridControl1.DataSource = Nothing
                    NewDP.GridControl1.DataSource = dtID
                    NewDP.GridControl1.ForceInitialize()


                    AddHandler dxOK_NewDP.Click, AddressOf dxOK_NewDP_click

                    NewDP.ShowDialog()



                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            Else
                XtraMessageBox.Show("Unable to proceed with the reconciliation!!" & vbNewLine & "The Sum of the selected outstanding booking postings is not 0", "UNABLE TO RECONCILE - SELECTED SUM <> 0", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            XtraMessageBox.Show("Unable to proceed with the reconciliation!!" & vbNewLine & "Please select at least 2 outstanding booking postings for recconciliation", "UNABLE TO RECONCILE - NO SELECTION", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub dxOK_NewDP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start Manual Reconciliation for Nostro Account: " & NostroAccount & "  on " & rd)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select 'MAX_RECON_NR'=Case when (SELECT Max([Reconciled_Nr])+1 from [NOSTRO_ACC_RECONCILIATIONS] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "') is NULL then 1 Else (SELECT Max([Reconciled_Nr])+1 from [NOSTRO_ACC_RECONCILIATIONS] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "') end"
            Dim NextReconciliationNr As Integer = cmd.ExecuteScalar
            For i = 0 To dtID.Rows.Count - 1
                cmd.CommandText = "UPDATE [NOSTRO_ACC_RECONCILIATIONS_OPEN] SET [Reconciled]='Y',[Reconciled_Tag]='M',[Reconciled_Nr]=" & Str(NextReconciliationNr) & ",[ReconcileInfo] = Case when [ReconcileInfo] is NULL then 'Reconciled from ' + SUSER_SNAME() + ' on ' + (SELECT CONVERT(VARCHAR(10), GETDATE(), 104) AS [DD.MM.YYYY]) + '  ' + (Select convert(varchar(8),getdate(),108)) else [ReconcileInfo]  + CHAR(13)+CHAR(10) + 'Reconciled from ' + SUSER_SNAME() + ' on ' + (SELECT CONVERT(VARCHAR(10), GETDATE(), 104) AS [DD.MM.YYYY]) + '  ' + (Select convert(varchar(8),getdate(),108)) end where [ID]='" & dtID.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
            Next
            cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECONCILIATIONS]([BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],[Reconciled],[Reconciled_Tag],[Reconciled_Nr],[ReconcileDate],[ReconcileInfo],[UserMemo]) Select [BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],[Reconciled],[Reconciled_Tag],[Reconciled_Nr],[ReconcileDate],[ReconcileInfo],[UserMemo] from NOSTRO_ACC_RECONCILIATIONS_OPEN where ReconcileDate='" & rdsql & "' and AccountNr_Internal='" & NostroAccount & "' and Reconciled in ('Y')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where AccountNr_Internal='" & NostroAccount & "' and Reconciled in ('Y')"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            dtID.Clear()
            Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, NostroAccount, rd)
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show("Selected outstanding postings where reconciled under the Reconciliation Nr.: " & NextReconciliationNr, "MANUAL RECONCILIATION STATUS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            NewDP.Close()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return

        End Try


    End Sub



    Private Function GetSelectedRows(ByVal view As GridView) As String
        Dim ret As String = ""

        Dim rowIndex As Integer = -1

        For Each i As Integer In NostroOutstandingBookings_GridView.GetSelectedRows()
            Dim row_Renamed As DataRow = NostroOutstandingBookings_GridView.GetDataRow(i)

            If ret <> "" Then
                ret &= ControlChars.CrLf
            End If
            If IsDBNull(row_Renamed("ID")) = False Then

                dtID.Rows.Add(row_Renamed("ID"), row_Renamed("BookingRoute_IB"), row_Renamed("BookingDate_IB"), row_Renamed("ValueDate_IB"), row_Renamed("CCY_IB"), row_Renamed("Amount_IB"), row_Renamed("Description_IB"), row_Renamed("Reference_AccountOwner_IB_First"), row_Renamed("Reference_AccountOwner_IB_Second"), row_Renamed("PostingType"))
                'MsgBox(row_Renamed("ID"))
            End If


        Next i
        Return ret

    End Function

    Private Function GetSelectedRowsSum(ByVal view As GridView) As Double
        SUM_AMT_SELECTED = 0

        For Each i As Integer In NostroOutstandingBookings_GridView.GetSelectedRows()
            Dim row_Renamed As DataRow = NostroOutstandingBookings_GridView.GetDataRow(i)
            SUM_AMT_SELECTED += row_Renamed("Amount_IB")

        Next i
        Return FormatNumber(SUM_AMT_SELECTED, 2)
    End Function





#End Region


#Region "RECONCILIATION DETAILS DISPLAY"
    Private Sub OCBS_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OCBS_LookUpEdit.EditValueChanged
        If Me.OCBS_LookUpEdit.Text <> "" Then
            Dim view As GridView = OCBS_LookUpEdit.Properties.View
            Dim rowHandle As Integer = view.FocusedRowHandle
            NostroAccount = view.GetRowCellValue(rowHandle, "AccountNr_Internal")
            NostroAccountExternal = view.GetRowCellValue(rowHandle, "AccountIdentifierStatement")
            Dim Currency As String = view.GetRowCellValue(rowHandle, "CCY_IB")
            NostroName = view.GetRowCellValue(rowHandle, "AccountName_Internal")

            'Get Edit Values
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            NostroAccount = editor.Properties.GetDisplayValueByKeyValue(editor.EditValue)
            Dim NostroAccountsRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            NostroAccountExternal = NostroAccountsRow("AccountIdentifierStatement")
            Currency = NostroAccountsRow("CCY_IB")
            NostroName = NostroAccountsRow("AccountName_Internal")

            Me.CURlbl.Text = Currency
            Me.NostroAccountNamelbl.Text = NostroName
        Else
            Me.CURlbl.Text = ""
            Me.NostroAccountNamelbl.Text = ""

        End If
    End Sub

    Private Sub LoadReconDetails_btn_Click(sender As Object, e As EventArgs) Handles LoadReconDetails_btn.Click
        If IsDate(Me.OCBS_BookingDate_From.Text) = True AndAlso IsDate(Me.OCBS_BookingDate_Till.Text) = True Then

            d1 = Me.OCBS_BookingDate_From.Text
            d2 = Me.OCBS_BookingDate_Till.Text
            'MsgBox(d1 & "  " & d2)
            If d2 >= d1 Then
                rdsql1 = d1.ToString("yyyyMMdd")
                rdsql2 = d2.ToString("yyyyMMdd")
                'ALL SEARCH ITEMS
                If IsNothing(Me.OCBS_LookUpEdit.Text) = False AndAlso IsNumeric(Me.OCBS_LookUpEdit.Text) = True Then
                    Try

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load  Reconciliation Details for Nostro Account: " & Me.OCBS_LookUpEdit.Text & " from: " & d1 & " till " & d2)


                        Dim objCMD As SqlCommand = New SqlCommand("execute [NOSTRO_REC_DETAILS_FILL]  @FROMDATE='" & rdsql1 & "', @TILLDATE='" & rdsql2 & "',@NOSTRO_ACCOUNT='" & Me.OCBS_LookUpEdit.Text & "'  ", conn)
                        objCMD.CommandTimeout = 5000
                        da = New SqlDataAdapter(objCMD)
                        dt = New DataTable()
                        da.Fill(dt)
                        'Results
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Me.GridControl_ReconciliationDetails.DataSource = Nothing
                            Me.GridControl_ReconciliationDetails.DataSource = dt
                            Me.GridControl_ReconciliationDetails.ForceInitialize()
                            SplashScreenManager.CloseForm(False)

                        Else
                            SplashScreenManager.CloseForm(False)
                            Me.GridControl_ReconciliationDetails.DataSource = Nothing
                            Me.NostroRecDetailsSearch_GridView.ViewCaption = "RECONCILIATION DETAILS"
                            XtraMessageBox.Show("There are no Data for the specified Period", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

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

#End Region



#Region "SET TO OUTSTANDING"

    Private Sub NostroReconciliationDetails_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles NostroReconciliationDetails_GridView.FocusedRowChanged
        'Do not select grouped row
        Dim view As GridView = DirectCast(sender, GridView)
        If e.FocusedRowHandle < 0 Then
            view.FocusedRowHandle = If(e.PrevFocusedRowHandle = GridControl.InvalidRowHandle, 0, e.PrevFocusedRowHandle)
        End If

    End Sub



    Private Sub NostroReconciliationDetails_GridView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles NostroReconciliationDetails_GridView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

        If HitInfo.InRow AndAlso RESET_RECONCILE_STATUS = "Y" AndAlso LastRecDate = rd Then

            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)

        End If
    End Sub

    Private Sub NostroReconciliationDetails_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles NostroReconciliationDetails_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            RESET_ID = view.GetFocusedRowCellValue("ID").ToString
            RESET_RECONCILE_STATUS = view.GetFocusedRowCellValue("Reconciled").ToString
            RESET_RECONCILIATION_NR = view.GetFocusedRowCellValue("Reconciled_Nr").ToString
            RESET_RECONCILITION_DATE = view.GetFocusedRowCellValue("ReconcileDate").ToString
            RESET_NOSTRO_ACC = view.GetFocusedRowCellValue("AccountNr_Internal").ToString

            'RESET_BookingRoute_IB = view.GetFocusedRowCellValue("BookingRoute_IB").ToString
            'RESET_ID_IB = view.GetFocusedRowCellValue("ID_IB").ToString
            'RESET_BookingRoute_EB = view.GetFocusedRowCellValue("BookingRoute_EB").ToString
            'RESET_ID_EB = view.GetFocusedRowCellValue("ID_EB").ToString

        End If
    End Sub


    Private Sub SetOutstanding_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetOutstanding_ToolStripMenuItem.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        cmd.CommandText = "SELECT CONVERT(VARCHAR(10),Max([ReconcileDate]),104) from NOSTRO_ACC_RECONCILIATIONS where  AccountNr_Internal='" & RESET_NOSTRO_ACC & "'"
        Dim Last_rd As Date = cmd.ExecuteScalar
        Dim Lastrdsql As String = Last_rd.ToString("yyyyMMdd")


        If Last_rd = RESET_RECONCILITION_DATE Then

            If XtraMessageBox.Show("Should the Reconciliation Status of the Bookings" & vbNewLine & "with Reconciliation Nr.: " & RESET_RECONCILIATION_NR & " be changed to Outstanding ?", "RECONCILIATION STATUS CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Reset Status in NOSTRO RECONCILIATIONS
                Try
                    cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECONCILIATIONS_OPEN]([BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],[Reconciled],[Reconciled_Tag],[Reconciled_Nr],[ReconcileDate],[ReconcileInfo],[UserMemo]) Select [BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],'N','N',0,'" & Lastrdsql & "',[ReconcileInfo] + CHAR(13)+CHAR(10) + 'Changed Status to OUTSTANDING from ' + SUSER_SNAME() + ' on ' + (SELECT CONVERT(VARCHAR(10), GETDATE(), 104) AS [DD.MM.YYYY]) + '  ' + (Select convert(varchar(8),getdate(),108)),[UserMemo] from NOSTRO_ACC_RECONCILIATIONS where ReconcileDate='" & Lastrdsql & "' and AccountNr_Internal='" & RESET_NOSTRO_ACC & "' and [Reconciled_Nr]='" & RESET_RECONCILIATION_NR & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM NOSTRO_ACC_RECONCILIATIONS where ReconcileDate='" & Lastrdsql & "' and AccountNr_Internal='" & RESET_NOSTRO_ACC & "' and [Reconciled_Nr]='" & RESET_RECONCILIATION_NR & "'"
                    cmd.ExecuteNonQuery()

                    Me.LoadReconDetails_btn.PerformClick()
                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If


        Else
            XtraMessageBox.Show("Reconciliation Date of the relevant Bookings is less than the last Reconciliation Date: " & LastRecDate, "Unable to change the Reconciliation Status to Outstanding", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return

        End If

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

    End Sub

    Private Sub SetAllReconciledPostingsAsOutstandingBookingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAllReconciledPostingsAsOutstandingBookingsToolStripMenuItem.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        cmd.CommandText = "SELECT CONVERT(VARCHAR(10),Max([ReconcileDate]),104) from NOSTRO_ACC_RECONCILIATIONS where  AccountNr_Internal='" & RESET_NOSTRO_ACC & "'"
        Dim Last_rd As Date = cmd.ExecuteScalar
        Dim Lastrdsql As String = Last_rd.ToString("yyyyMMdd")


        If Last_rd = RESET_RECONCILITION_DATE Then

            If XtraMessageBox.Show("Should the Reconciliation Status of all Bookings" & vbNewLine & "on: " & RESET_RECONCILITION_DATE & " be changed to Outstanding ?", "RECONCILIATION STATUS CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Reset Status in NOSTRO RECONCILIATIONS
                Try
                    cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECONCILIATIONS_OPEN]([BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],[Reconciled],[Reconciled_Tag],[Reconciled_Nr],[ReconcileDate],[ReconcileInfo],[UserMemo]) Select [BookingRoute_IB],[ID_IB],[AccountNr_Internal],[AccountName_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[Reference_AccountOwner_IB_First],[Reference_AccountOwner_IB_Second],[BookingRoute_EB],[ID_EB],[AccountNr_External],[BookingDate_EB],[ValueDate_EB],[CCY_EB],[Amount_EB],[TransactionTypeID_EB],[Reference_AccountOwner_EB],[ReferenceServiInstitution_EB],[SupplementaryDetails_EB],'N','N',0,'" & Lastrdsql & "',[ReconcileInfo] + CHAR(13)+CHAR(10) + 'Changed Status to OUTSTANDING from ' + SUSER_SNAME() + ' on ' + (SELECT CONVERT(VARCHAR(10), GETDATE(), 104) AS [DD.MM.YYYY]) + '  ' + (Select convert(varchar(8),getdate(),108)),[UserMemo] from NOSTRO_ACC_RECONCILIATIONS where ReconcileDate='" & Lastrdsql & "' and AccountNr_Internal='" & RESET_NOSTRO_ACC & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM NOSTRO_ACC_RECONCILIATIONS where ReconcileDate='" & Lastrdsql & "' and AccountNr_Internal='" & RESET_NOSTRO_ACC & "'"
                    cmd.ExecuteNonQuery()

                    Me.LoadReconDetails_btn.PerformClick()
                Catch ex As Exception
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try



            End If


        Else
            XtraMessageBox.Show("Reconciliation Date of the relevant Bookings is less than the last Reconciliation Date: " & LastRecDate, "Unable to change the Reconciliation Status to Outstanding", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return

        End If

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub
#End Region

#Region "CREATE INTERNAL DUMMY BOOKING for RECONCILIATION EXTERNAL BOOKING"

    Private Sub NostroOutstandingBookings_GridView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles NostroOutstandingBookings_GridView.PopupMenuShowing

        If CREATE_DUMMY_BOOKINGS = "Y" Then
            Dim View As GridView = CType(sender, GridView)

            Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

            If HitInfo.InRow AndAlso BOOKING_ROUTE_MAIN = "EXTERNAL" Then

                View.FocusedRowHandle = HitInfo.RowHandle
                Me.ContextMenuStrip2.Show(View.GridControl, e.Point)
            Else
                Return

            End If
        End If



    End Sub

    Private Sub NostroOutstandingBookings_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles NostroOutstandingBookings_GridView.RowCellClick


    End Sub

    Private Sub NostroOutstandingBookings_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles NostroOutstandingBookings_GridView.RowClick
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_MAIN = view.GetRowCellValue(rowHandle, colID1)
            BOOKING_ROUTE_MAIN = view.GetRowCellValue(rowHandle, colUB_BookingRoute)
            BOOKING_ID_MAIN = view.GetRowCellValue(rowHandle, col_UB_ID_IB_EB)
            DESCRIPTION_MAIN = view.GetRowCellValue(rowHandle, colUB_Description)
            BOOKING_DATE_MAIN = view.GetRowCellValue(rowHandle, colUB_BookingDate)
            VALUE_DATE_MAIN = view.GetRowCellValue(rowHandle, colUB_ValueDate)
            CUR_MAIN = view.GetRowCellValue(rowHandle, colUB_CCY)
            AMOUNT_MAIN = view.GetRowCellValue(rowHandle, colUB_Amount)

        End If
    End Sub

    Private Sub CreateDummyBooking_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDummyBooking_ToolStripMenuItem.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

        Dim Lastrdsql As String = LastRecDate.ToString("yyyyMMdd")

        If BOOKING_ROUTE_MAIN = "EXTERNAL" Then
            If LastRecDate = rd Then
                If XtraMessageBox.Show("Should for this External Booking a dummy Internal booking be created in order to reconcile?", "RECONCILIATION - CREATE INTERNAL DUMMY BOOKING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim DUMMY_BOOKING_AMOUNT As Double = AMOUNT_MAIN * (-1)
                    cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECONCILIATIONS_OPEN]([BookingRoute_IB],[ID_IB],[AccountNr_Internal],[BookingDate_IB],[ValueDate_IB],[CCY_IB],[Amount_IB],[Description_IB],[ReconcileDate])VALUES ('INTERNAL',0,'" & Me.NostroAcc_SearchLookUpEdit.Text & "','" & Lastrdsql & "','" & Lastrdsql & "','" & CUR_MAIN & "'," & Str(DUMMY_BOOKING_AMOUNT) & ",'INTERNAL DUMMY BOOKING CREATED FOR RECONCILIATION','" & Lastrdsql & "')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[AccountName_Internal]=B.NOSTRO_NAME from [NOSTRO_ACC_RECONCILIATIONS_OPEN] A INNER JOIN SSIS B on A.AccountNr_Internal=B.[INTERNAL ACCOUNT] where A.AccountName_Internal is NULL"
                    cmd.ExecuteNonQuery()
                    Me.GridControl_OutstandingBookings.DataSource = Nothing
                    Me.GridControl_OutstandingBookings.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
                    Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, Me.NostroAcc_SearchLookUpEdit.Text, rd)
                End If
            Else
                XtraMessageBox.Show("Unable to create a Internal Dummy Booking for reconciliation", "RECONCILIATION DATE IS IN THE PAST", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Unable to create a Internal Dummy Booking for reconciliation", "SELECTED BOOKING IS AN INTERNAL BOOKING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If


        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub



#End Region

#Region "REPORTS CREATION"

    Private Sub RR_DefaultFormat_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RR_DefaultFormat_BarButtonItem.ItemClick
        If NostroAcc_SearchLookUpEdit.Text <> "" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Reconciliation Report for " & NostroAccount & " CUR:" & Currency & vbNewLine & NostroName & " on " & rd)
            'load data to NOSTRO_ACC_RECON_DATA
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Delete from [NOSTRO_ACC_RECON_DATA]"
            cmd.ExecuteNonQuery()
            'OLD CODE
            'cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[NostroAccount_Extern],[CUR],[AccountName_Internal],[BalanceDate_Internal],[BalanceAmount_Internal],[ReconcileDate])Select distinct(A.[Nostro Code]),B.AccountIdentifierStatement,A.Currency,B.NOSTRO_NAME,'ValueDate'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select BalanceDate from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else NULL end,'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else 0 end,'" & rdsql & "' from [NOSTRO BALANCES] A INNER JOIN SSIS B on A.[Nostro Code]=B.[INTERNAL ACCOUNT] where A.[Nostro Code]='" & NostroAccount & "'"
            'cmd.ExecuteNonQuery()
            'NEW CODE
            'cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[NostroAccount_Extern],[CUR],[AccountName_Internal],[BalanceDate_Internal],[BalanceAmount_Internal],[ReconcileDate])Select distinct(A.[Nostro Code]),B.AccountIdentifierStatement,A.Currency,B.NOSTRO_NAME,'ValueDate'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select BalanceDate from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else (SELECT MAX([BalanceDate]) AS second FROM   [NOSTRO BALANCES] WHERE  [BalanceDate] <= '" & rdsql & "' and [Nostro Code]='" & NostroAccount & "') end,'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]=(SELECT MAX([BalanceDate]) AS second FROM   [NOSTRO BALANCES] WHERE  [BalanceDate] <= '" & rdsql & "' and [Nostro Code]='" & NostroAccount & "')) end,'" & rdsql & "' from [NOSTRO BALANCES] A INNER JOIN SSIS B on A.[Nostro Code]=B.[INTERNAL ACCOUNT] where A.[Nostro Code]='" & NostroAccount & "'"
            'cmd.ExecuteNonQuery()

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim InternalValueBalance_Date As Date = Me.InternalValueBalanceDate_TextEdit.Text
            Dim InternalValueBalance_Amount As Double = Me.InternalValueBalanceAmount_TextEdit.Text
            Dim ExternalBookedBalance_Date As Date = Me.ExternalBookedBalanceDate_TextEdit.Text
            Dim ExternalBookedBalance_Amount As Double = Me.ExternalBookedBalanceAmount_TextEdit.Text

            cmd.CommandText = "INSERT INTO [dbo].[NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[CUR],[BalanceDate_Internal],[BalanceAmount_Internal],[BalanceDate_External],[BalanceAmount_External],[ReconcileDate])VALUES(@NostroAccount,@NostroCurrency,@InternalValueBalanceDate,@InternalValueBalanceAmount,@ExternalBookedBalanceDate,@ExternalBookedBalanceAmount,@ReconciliationDate)"
            cmd.Parameters.Add("@NostroAccount", SqlDbType.NVarChar).Value = NostroAccount
            cmd.Parameters.Add("@NostroCurrency", SqlDbType.NVarChar).Value = Currency
            cmd.Parameters.Add("@InternalValueBalanceDate", SqlDbType.DateTime).Value = InternalValueBalance_Date
            cmd.Parameters.Add("@InternalValueBalanceAmount", SqlDbType.Float).Value = InternalValueBalance_Amount
            cmd.Parameters.Add("@ExternalBookedBalanceDate", SqlDbType.DateTime).Value = ExternalBookedBalance_Date
            cmd.Parameters.Add("@ExternalBookedBalanceAmount", SqlDbType.Float).Value = ExternalBookedBalance_Amount
            cmd.Parameters.Add("@ReconciliationDate", SqlDbType.DateTime).Value = rd
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'UPDATE
            cmd.CommandText = "UPDATE A SET A.[NostroAccount_Extern]=B.AccountIdentifierStatement,A.AccountName_Internal=B.NOSTRO_NAME from [NOSTRO_ACC_RECON_DATA] A INNER JOIN SSIS B on A.NostroAccount_Intern=B.[INTERNAL ACCOUNT]"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'cmd.CommandText = "Select '62F'=Case when exists(Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else 0 end"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'Balance_EB = cmd.ExecuteScalar
            'cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'Else
            'cmd.CommandText = "Select '62F'=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') is not NULL then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "' and [SwiftTag] in ('62F'))))  end"
            'Balance_EB = cmd.ExecuteScalar
            'cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') is not NULL then (Select [BookingDate] from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else (Select [BookingDate] from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "')))  end"
            'cmd.ExecuteNonQuery()
            'End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            'Select from Last Reconcile Date
            If LastRecDate_ALL_NOSTROS = rd OrElse LastRecDate = rd Then
                Dim RefiDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECON_DATA]", conn)
                Dim BankDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                REPORTINGdataset.Clear()
                BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                BankDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                Dim BankDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECONCILIATIONS_OPEN")
                RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECON_DATA")
                RefiDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECON_DATA")
                Dim RefiDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECON_DATA")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\NostroReconciliationRep.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = rd
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams1 As ParameterField = New ParameterField
                myValue1.Value = NostroAccount
                myParams1.ParameterFieldName = "NostroAccount"
                myParams1.CurrentValues.Add(myValue1)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Reconciliation Report for " & NostroAccount & " CUR:" & Currency & " on " & rd
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(100)
            ElseIf LastRecDate_ALL_NOSTROS <> rd Then
                Dim RefiDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECON_DATA]", conn)
                Dim BankDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                REPORTINGdataset.Clear()
                BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                BankDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                Dim BankDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECON_DATA")
                RefiDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECON_DATA")
                Dim RefiDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECON_DATA")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\NostroReconciliationRepHistory.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = rd
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams1 As ParameterField = New ParameterField
                myValue1.Value = NostroAccount
                myParams1.ParameterFieldName = "NostroAccount"
                myParams1.CurrentValues.Add(myValue1)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Reconciliation Report for " & NostroAccount & " CUR:" & Currency & " on " & rd
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(100)
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RR_NewFormat_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RR_NewFormat_BarButtonItem.ItemClick
        If NostroAcc_SearchLookUpEdit.Text <> "" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Reconciliation Report for " & NostroAccount & " CUR:" & Currency & vbNewLine & NostroName & " on " & rd)
            'load data to NOSTRO_ACC_RECON_DATA
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Delete from [NOSTRO_ACC_RECON_DATA]"
            cmd.ExecuteNonQuery()
            'OLD CODE
            'cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[NostroAccount_Extern],[CUR],[AccountName_Internal],[BalanceDate_Internal],[BalanceAmount_Internal],[ReconcileDate])Select distinct(A.[Nostro Code]),B.AccountIdentifierStatement,A.Currency,B.NOSTRO_NAME,'ValueDate'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select BalanceDate from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else NULL end,'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else 0 end,'" & rdsql & "' from [NOSTRO BALANCES] A INNER JOIN SSIS B on A.[Nostro Code]=B.[INTERNAL ACCOUNT] where A.[Nostro Code]='" & NostroAccount & "'"
            'cmd.ExecuteNonQuery()
            'NEW CODE
            'cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[NostroAccount_Extern],[CUR],[AccountName_Internal],[BalanceDate_Internal],[BalanceAmount_Internal],[ReconcileDate])Select distinct(A.[Nostro Code]),B.AccountIdentifierStatement,A.Currency,B.NOSTRO_NAME,'ValueDate'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select BalanceDate from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else (SELECT MAX([BalanceDate]) AS second FROM   [NOSTRO BALANCES] WHERE  [BalanceDate] <= '" & rdsql & "' and [Nostro Code]='" & NostroAccount & "') end,'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]='" & rdsql & "') else (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount & "' and [BalanceDate]=(SELECT MAX([BalanceDate]) AS second FROM   [NOSTRO BALANCES] WHERE  [BalanceDate] <= '" & rdsql & "' and [Nostro Code]='" & NostroAccount & "')) end,'" & rdsql & "' from [NOSTRO BALANCES] A INNER JOIN SSIS B on A.[Nostro Code]=B.[INTERNAL ACCOUNT] where A.[Nostro Code]='" & NostroAccount & "'"
            'cmd.ExecuteNonQuery()

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim InternalValueBalance_Date As Date = Me.InternalValueBalanceDate_TextEdit.Text
            Dim InternalValueBalance_Amount As Double = Me.InternalValueBalanceAmount_TextEdit.Text
            Dim ExternalBookedBalance_Date As Date = Me.ExternalBookedBalanceDate_TextEdit.Text
            Dim ExternalBookedBalance_Amount As Double = Me.ExternalBookedBalanceAmount_TextEdit.Text

            cmd.CommandText = "INSERT INTO [dbo].[NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[CUR],[BalanceDate_Internal],[BalanceAmount_Internal],[BalanceDate_External],[BalanceAmount_External],[ReconcileDate])VALUES(@NostroAccount,@NostroCurrency,@InternalValueBalanceDate,@InternalValueBalanceAmount,@ExternalBookedBalanceDate,@ExternalBookedBalanceAmount,@ReconciliationDate)"
            cmd.Parameters.Add("@NostroAccount", SqlDbType.NVarChar).Value = NostroAccount
            cmd.Parameters.Add("@NostroCurrency", SqlDbType.NVarChar).Value = Currency
            cmd.Parameters.Add("@InternalValueBalanceDate", SqlDbType.DateTime).Value = InternalValueBalance_Date
            cmd.Parameters.Add("@InternalValueBalanceAmount", SqlDbType.Float).Value = InternalValueBalance_Amount
            cmd.Parameters.Add("@ExternalBookedBalanceDate", SqlDbType.DateTime).Value = ExternalBookedBalance_Date
            cmd.Parameters.Add("@ExternalBookedBalanceAmount", SqlDbType.Float).Value = ExternalBookedBalance_Amount
            cmd.Parameters.Add("@ReconciliationDate", SqlDbType.DateTime).Value = rd
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'UPDATE
            cmd.CommandText = "UPDATE A SET A.[NostroAccount_Extern]=B.AccountIdentifierStatement,A.AccountName_Internal=B.NOSTRO_NAME from [NOSTRO_ACC_RECON_DATA] A INNER JOIN SSIS B on A.NostroAccount_Intern=B.[INTERNAL ACCOUNT]"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'cmd.CommandText = "Select '62F'=Case when exists(Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else 0 end"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'Balance_EB = cmd.ExecuteScalar
            'cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'Else
            'cmd.CommandText = "Select '62F'=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') is not NULL then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "' and [SwiftTag] in ('62F'))))  end"
            'Balance_EB = cmd.ExecuteScalar
            'cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') is not NULL then (Select [BookingDate] from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdsql & "') else (Select [BookingDate] from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount & "' and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdsql & "')))  end"
            '
            'cmd.ExecuteNonQuery()
            'End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            'Select from Last Reconcile Date
            If LastRecDate_ALL_NOSTROS = rd OrElse LastRecDate = rd Then
                Dim RefiDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECON_DATA]", conn)
                Dim BankDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                REPORTINGdataset.Clear()
                BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                BankDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                Dim BankDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECONCILIATIONS_OPEN")
                RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECON_DATA")
                RefiDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECON_DATA")
                Dim RefiDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECON_DATA")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\NostroReconciliationRepNew.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = rd
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams1 As ParameterField = New ParameterField
                myValue1.Value = NostroAccount
                myParams1.ParameterFieldName = "NostroAccount"
                myParams1.CurrentValues.Add(myValue1)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Reconciliation Report for " & NostroAccount & " CUR:" & Currency & " on " & rd
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(100)
            ElseIf LastRecDate_ALL_NOSTROS <> rd Then
                Dim RefiDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECON_DATA]", conn)
                Dim BankDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY] where [AccountNr_Internal]='" & NostroAccount & "' and [ReconcileDate]='" & rdsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                REPORTINGdataset.Clear()
                BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                BankDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                Dim BankDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECONCILIATIONS_OPEN_HISTORY")
                RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECON_DATA")
                RefiDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECON_DATA")
                Dim RefiDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECON_DATA")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\NostroReconciliationRepHistoryNew.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = rd
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams1 As ParameterField = New ParameterField
                myValue1.Value = NostroAccount
                myParams1.ParameterFieldName = "NostroAccount"
                myParams1.CurrentValues.Add(myValue1)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Reconciliation Report for " & NostroAccount & " CUR:" & Currency & " on " & rd
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(100)
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RR_AllOutstandings_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RR_AllOutstandings_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Outstanding Bookings for all Nostro Accounts Report on " & Today)
        'Dim OutAll_Da As New SqlDataAdapter("Select C.* from [NOSTRO_ACC_RECONCILIATIONS_OPEN] C INNER JOIN (Select max([ReconcileDate])as 'RecDate',AccountNr_Internal as 'Account' from [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [ReconcileDate] in (Select Max(ReconcileDate) from [NOSTRO_ACC_RECONCILIATIONS_OPEN] GROUP BY AccountNr_Internal) GROUP BY AccountNr_Internal)A on C.ReconcileDate=A.RecDate and C.AccountNr_Internal=A.Account ", conn)
        Dim OutAll_Da As New SqlDataAdapter("Select * from [NOSTRO_ACC_RECONCILIATIONS_OPEN]", conn)
        Dim OutAll_Dataset As New DataSet("NOSTRO_ACC_RECONCILIATIONS_OPEN")
        OutAll_Da.Fill(OutAll_Dataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\NostroReconciliationAllOutBookings_Rep.rpt")
        CrRep.SetDataSource(OutAll_Dataset)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Outstanding Bookings for all Nostro Accounts Report on " & Today.ToShortDateString
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(100)

        SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "LAST RECONCILIATIONS REPORT"

    Private Sub Reports_Dropdownbutton_Click(sender As Object, e As EventArgs) Handles Reports_Dropdownbutton.Click

        LAST_RECONCILIATIONS_initData()
        LAST_RECONCILIATIONS_InitLookUp()

    End Sub

    Private Sub RepositoryItemGridLookUpEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemGridLookUpEdit2.ButtonClick
        If e.Button.Caption = "Load" Then
            If NostroAccount_LastReconcile <> Nothing And IsDate(rdlr) = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Creating Last Reconciliation Report for " & NostroAccount_LastReconcile & " CUR: " & NostroAccountCCY_LastReconcile & vbNewLine & NostroAccountName_LastReconcile & " on " & rdlr)
                'load data to NOSTRO_ACC_RECON_DATA
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "Delete from [NOSTRO_ACC_RECON_DATA]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [NOSTRO_ACC_RECON_DATA]([NostroAccount_Intern],[NostroAccount_Extern],[CUR],[AccountName_Internal],[BalanceDate_Internal],[BalanceAmount_Internal],[ReconcileDate])Select distinct(A.[Nostro Code]),B.AccountIdentifierStatement,A.Currency,B.NOSTRO_NAME,'ValueDate'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount_LastReconcile & "' and [BalanceDate]='" & rdlrsql & "') then (Select BalanceDate from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount_LastReconcile & "' and [BalanceDate]='" & rdlrsql & "') else NULL end,'ValueBalance'=Case when exists(Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount_LastReconcile & "' and [BalanceDate]='" & rdlrsql & "') then (Select [Value Balance] from [NOSTRO BALANCES] where [Nostro Code]='" & NostroAccount_LastReconcile & "' and [BalanceDate]='" & rdlrsql & "') else 0 end,'" & rdlrsql & "' from [NOSTRO BALANCES] A INNER JOIN SSIS B on A.[Nostro Code]=B.[INTERNAL ACCOUNT] where A.[Nostro Code]='" & NostroAccount_LastReconcile & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "Select '62F'=Case when exists(Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') else 0 end"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    Balance_EB = cmd.ExecuteScalar
                    cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]='" & rdlrsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    cmd.CommandText = "Select '62F'=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') is not NULL then (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') else (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdlrsql & "' and [SwiftTag] in ('62F'))))  end"
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        Balance_EB = cmd.ExecuteScalar
                    Else
                        Balance_EB = 0
                    End If

                    cmd.CommandText = "UPDATE [NOSTRO_ACC_RECON_DATA] set [BalanceAmount_External]=" & Str(Balance_EB) & ",[BalanceDate_External]=Case when (Select Sum([Amount]) from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') is not NULL then (Select [BookingDate] from [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and [BookingDate]='" & rdlrsql & "') else (Select [BookingDate] from [SWIFT_ACC_STATEMENTS]  where [InternalAccount]='" & NostroAccount_LastReconcile & "' and [SwiftTag] in ('62F') and  [BookingDate]= (SELECT MAX([BookingDate]) AS second FROM   [SWIFT_ACC_STATEMENTS] where [InternalAccount]='" & NostroAccount_LastReconcile & "' and  [BookingDate] < (SELECT MAX([BookingDate]) AS first FROM   [SWIFT_ACC_STATEMENTS] where [BookingDate]='" & rdlrsql & "')))  end"
                    cmd.ExecuteNonQuery()
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If


                Dim RefiDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECON_DATA]", conn)
                Dim BankDa As New SqlDataAdapter("SELECT * FROM [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [AccountNr_Internal]='" & NostroAccount_LastReconcile & "' and [ReconcileDate]='" & rdlrsql & "'", conn)
                Dim REPORTINGdataset As New DataSet("REPORTING")
                REPORTINGdataset.Clear()
                BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                BankDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECONCILIATIONS_OPEN")
                Dim BankDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECONCILIATIONS_OPEN")
                RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "NOSTRO_ACC_RECON_DATA")
                RefiDa.Fill(REPORTINGdataset, "NOSTRO_ACC_RECON_DATA")
                Dim RefiDt As DataTable = REPORTINGdataset.Tables("NOSTRO_ACC_RECON_DATA")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\NostroReconciliationRep.rpt")
                CrRep.SetDataSource(REPORTINGdataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = rdlr
                myParams.ParameterFieldName = "RiskDate"
                myParams.CurrentValues.Add(myValue)
                Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams1 As ParameterField = New ParameterField
                myValue1.Value = NostroAccount_LastReconcile
                myParams1.ParameterFieldName = "NostroAccount"
                myParams1.CurrentValues.Add(myValue1)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Reconciliation Report for " & NostroAccount_LastReconcile & " CUR:" & NostroAccountCCY_LastReconcile & " on " & rdlr
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(100)
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub RepositoryItemGridLookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit2.EditValueChanged
        Dim edit As DevExpress.XtraEditors.GridLookUpEdit = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)
        Dim row As DataRow = edit.Properties.View.GetDataRow(edit.Properties.View.FocusedRowHandle)
        NostroAccount_LastReconcile = row("Nostro Account")
        NostroAccountName_LastReconcile = row("Nostro Account Name")
        NostroAccountCCY_LastReconcile = row("Currency")
        rdlr = row("Last Reconcile Date")
        rdlrsql = rdlr.ToString("yyyyMMdd")
    End Sub

#End Region

#Region "PRINT GRIDVIEWS"
    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Reconciliations - Outstanding Bookings" Then
            ActiveTabGroup = 0
            Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Nostro Reconciliations Details" Then
            ActiveTabGroup = 1
            Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Create missing Reconciliation" Then
            ActiveTabGroup = 2
            Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
        End If

    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then

            Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
            AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
            Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink3 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink4 As PrintableComponentLink = New PrintableComponentLink()
            Dim pcLink11 As PrintableComponentLink = New PrintableComponentLink()

            Dim linkMainReport As Link = New Link()
            AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
            Dim linkGrid1Report As Link = New Link()
            AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
            Dim linkGrid2Report As Link = New Link()
            AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea
            Dim linkGrid3Report As Link = New Link()
            AddHandler linkGrid3Report.CreateDetailArea, AddressOf linkGrid3Report_CreateDetailArea
            Dim linkGrid4Report As Link = New Link()
            AddHandler linkGrid4Report.CreateDetailArea, AddressOf linkGrid4Report_CreateDetailArea
            Dim linkGrid11Report As Link = New Link()
            AddHandler linkGrid11Report.CreateDetailArea, AddressOf linkGrid11Report_CreateDetailArea

            ' Assign the controls to the printing links.
            pcLink1.Component = Me.GridControl_Internal
            pcLink2.Component = Me.GridControl_External
            pcLink3.Component = Me.GridControl3
            pcLink4.Component = Me.GridControl4
            pcLink11.Component = Me.GridControl_OutstandingBookings

            ' Populate the collection of links in the composite link.
            ' The order of operations corresponds to the document structure.
            composLink.Links.Add(linkGrid1Report)
            composLink.Links.Add(pcLink1)

            composLink.Links.Add(linkMainReport)

            composLink.Links.Add(linkGrid2Report)
            composLink.Links.Add(pcLink2)

            composLink.Links.Add(linkGrid3Report)
            composLink.Links.Add(pcLink3)

            composLink.Links.Add(linkGrid4Report)
            composLink.Links.Add(pcLink4)

            composLink.Links.Add(linkGrid11Report)
            composLink.Links.Add(pcLink11)

            composLink.Landscape = True
            composLink.PaperKind = System.Drawing.Printing.PaperKind.A3


            ' Create the report and show the preview window.
            composLink.ShowPreviewDialog()


        ElseIf ActiveTabGroup = 1 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
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
        Dim reportfooter As String = "Reconciliation Details for Nostro Account Nr.:" & OCBS_LookUpEdit.Text & "   " & Me.NostroAccountNamelbl.Text & "from: " & Me.OCBS_BookingDate_From.Text & "  till: " & Me.OCBS_BookingDate_Till.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "All reconciliation Details for Nostro Account: " & NostroAccount & "  " & "on" & rd & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        'tb.Text = "EXTERNAL OUTSTANDINGS (Credits)"
        tb.Font = New Font("Arial", 10)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid11Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        'tb.Text = "ALL OUTSTANDING BOOKINGS"
        tb.Font = New Font("Arial", 10)
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
        'tb.Text = "EXTERNAL OUTSTANDINGS (Debits)"
        tb.Font = New Font("Arial", 10)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid3Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        'tb.Text = "INTERNAL OUTSTANDINGS (Credits)"
        tb.Font = New Font("Arial", 10)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub linkGrid4Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        'tb.Text = "INTERNAL OUTSTANDINGS (Debits)"
        tb.Font = New Font("Arial", 10)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

#End Region

#Region "GRIDVIEWS STYLES"

    Private Sub NostroAcc_SearchLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NostroAcc_SearchLookUpEditView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NostroAcc_SearchLookUpEditView_ShownEditor(sender As Object, e As EventArgs) Handles NostroAcc_SearchLookUpEditView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub InternalBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles InternalBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub InternalBaseView_ShownEditor(sender As Object, e As EventArgs) Handles InternalBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub External_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles External_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub External_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles External_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub NostroOutstandingBookings_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NostroOutstandingBookings_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NostroOutstandingBookings_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NostroOutstandingBookings_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
            view.ClearSelection()
            dtID.Clear()
        End If
    End Sub

    Private Sub NostroRecDetailsSearch_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NostroRecDetailsSearch_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NostroRecDetailsSearch_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NostroRecDetailsSearch_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub NostroReconciliationDetails_AdvancedGridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NostroReconciliationDetails_AdvancedGridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub BookingsForRec_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BookingsForRec_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub All_Nostro_Last_Reconciliations_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Nostro_Last_Reconciliations_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub All_Nostro_Last_Reconciliations_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Nostro_Last_Reconciliations_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
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
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GridView5_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView5.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GridView5_ShownEditor(sender As Object, e As EventArgs) Handles GridView5.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub



    Private Sub NostroReconciliationDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NostroReconciliationDetails_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub NostroReconciliationDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NostroReconciliationDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub
#End Region



    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl_OutstandingBookings Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing

        Dim view As GridView = TryCast(GridControl_OutstandingBookings.GetViewAt(e.ControlMousePosition), GridView)
        'Dim view As GridView = GridControl_OutstandingBookings.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then

            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing Then 'AndAlso hi.Column.SummaryItem.SummaryType = SummaryItemType.Custom Then


            If hi.Column.Caption = "Amount" Then

                Dim o As Object = hi.Column.Name + hi.FooterCell.ToString()

                'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
                Dim text As String = "Balance Outst. is calculated as follows:" & vbNewLine & "Sum of all Internal Postings till " & rd & vbNewLine & "+ Sum of all External Postings" & vbNewLine & vbNewLine _
                                     & "Selected Sum is calculated based on the selected rows"
                info = New ToolTipControlInfo(o, text)
            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
        End If
    End Sub



    Private Sub NostroOutstandingBookings_GridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles NostroOutstandingBookings_GridView.CustomDrawRowIndicator
        e.Info.DisplayText = e.RowHandle.ToString
    End Sub


    Private Sub TotalsDifference_TextEdit_TextChanged(sender As Object, e As EventArgs) Handles TotalsDifference_TextEdit.TextChanged
        If IsNumeric(Me.TotalsDifference_TextEdit.Text) = True Then
            Dim n As Double = Me.TotalsDifference_TextEdit.Text
            If n <> 0 Then
                Me.TotalsDifference_TextEdit.Properties.Appearance.BackColor = Color.Red
                Me.TotalsDifference_TextEdit.Properties.Appearance.ForeColor = Color.White
            ElseIf n = 0 Then
                Me.TotalsDifference_TextEdit.Properties.Appearance.BackColor = Color.Green
                Me.TotalsDifference_TextEdit.Properties.Appearance.ForeColor = Color.White
            End If
        Else
            Me.TotalsDifference_TextEdit.Properties.Appearance.BackColor = Nothing
            Me.TotalsDifference_TextEdit.Properties.Appearance.ForeColor = Nothing
        End If
    End Sub


    Private Sub Match_Rec_btn_Click(sender As Object, e As EventArgs) Handles Match_Rec_btn.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        If Me.UserMemo_MemoEdit.Text <> "" Then
            cmd.CommandText = "UPDATE [NOSTRO_ACC_RECONCILIATIONS_OPEN] set [UserMemo]='" & Me.UserMemo_MemoEdit.Text & "' where [ID]='" & Me.ID_NOSTRO_REC_Textedit.Text & " ' and [ReconcileDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "UPDATE [NOSTRO_ACC_RECONCILIATIONS_OPEN] set [UserMemo]=NULL where [ID]='" & Me.ID_NOSTRO_REC_Textedit.Text & " ' and [ReconcileDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        Me.UserMemo_MemoEdit.Text = ""
        Me.NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource.EndEdit()
        'FILL NOSTRO OPEN DATA
        Me.GridControl_OutstandingBookings.DataSource = Nothing
        Me.GridControl_OutstandingBookings.DataSource = NOSTRO_ACC_RECONCILIATIONS_OPENBindingSource
        Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, NostroAccount, rd)

    End Sub

    Private Sub Cancel_Rec_btn_Click(sender As Object, e As EventArgs) Handles Cancel_Rec_btn.Click

        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub NostroOutstandingBookings_GridView_FilterEditorCreated(sender As Object, e As FilterControlEventArgs) Handles NostroOutstandingBookings_GridView.FilterEditorCreated
        Dim view As GridView = Me.NostroOutstandingBookings_GridView
        view.ClearSelection()
        dtID.Clear()
    End Sub

    Private Sub NostroOutstandingBookings_GridView_ColumnFilterChanged(sender As Object, e As EventArgs) Handles NostroOutstandingBookings_GridView.ColumnFilterChanged
        Dim view As GridView = Me.NostroOutstandingBookings_GridView
        view.ClearSelection()
        dtID.Clear()
    End Sub



    Private Sub NostrosForMissingRecon_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NostrosForMissingRecon_SearchLookUpEdit.EditValueChanged
        If Me.NostrosForMissingRecon_SearchLookUpEdit.Text <> "" Then
            Dim view As GridView = NostrosForMissingRecon_SearchLookUpEdit.Properties.View
            Dim rowHandle As Integer = view.FocusedRowHandle
            Dim Currency As String = view.GetRowCellValue(rowHandle, "CCY_IB")
            Dim MissingRecon_NostroName = view.GetRowCellValue(rowHandle, "AccountName_Internal")

            'Get Edit Values
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            NostroAccount = editor.Properties.GetDisplayValueByKeyValue(editor.EditValue)
            Dim NostroAccountsRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            NostroAccountExternal = NostroAccountsRow("AccountIdentifierStatement")
            Currency = NostroAccountsRow("CCY_IB")
            MissingRecon_NostroName = NostroAccountsRow("AccountName_Internal")

            Me.LabelControl7.Text = Currency
            Me.LabelControl6.Text = MissingRecon_NostroName
        Else
            Me.LabelControl7.Text = ""
            Me.LabelControl6.Text = ""

        End If
    End Sub

    Private Sub CreateMissingRecon_btn_Click(sender As Object, e As EventArgs) Handles CreateMissingRecon_btn.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        If IsNothing(Me.NostrosForMissingRecon_SearchLookUpEdit.Text) = False AndAlso IsNumeric(Me.NostrosForMissingRecon_SearchLookUpEdit.Text) = True Then
            Dim mrd As Date = Me.CreateMissingRecon_FromDateEdit.Text
            Dim mrdsql As String = mrd.ToString("yyyyMMdd")
            cmd.CommandText = "Select Sum(A.S) from (Select Count(ID) as S from [NOSTRO_ACC_RECONCILIATIONS] where [AccountNr_Internal]='" & Me.NostrosForMissingRecon_SearchLookUpEdit.Text & "'and [ReconcileDate]='" & mrdsql & "' UNION ALL Select Count(ID) as S from [NOSTRO_ACC_RECONCILIATIONS_OPEN] where [AccountNr_Internal]='" & Me.NostrosForMissingRecon_SearchLookUpEdit.Text & "' and [ReconcileDate]=' " & mrdsql & "')A"
            Dim ReconCount As Integer = cmd.ExecuteScalar

            If ReconCount = 0 Then
                If XtraMessageBox.Show("Should the missing Reconciliation for Nostro Account: " & Me.NostrosForMissingRecon_SearchLookUpEdit.Text & " be executed?", "CREATION OF MISSING RECONCILIATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Restart Reconciliation for Nostro Account: " & Me.NostrosForMissingRecon_SearchLookUpEdit.Text & "  on " & mrd)
                        Dim objCMD As SqlCommand = New SqlCommand("exec [RECONCILE_NOSTRO_ACCOUNTS] @RISKDATE='" & mrdsql & "',@INTERNAL_NOSTRO_ACCOUNT='" & Me.NostrosForMissingRecon_SearchLookUpEdit.Text & "'", conn)
                        objCMD.CommandTimeout = 5000
                        If objCMD.Connection.State = ConnectionState.Closed Then
                            objCMD.Connection.Open()
                        End If
                        objCMD.ExecuteNonQuery()
                        objCMD = New SqlCommand("UPDATE PARAMETER SET PARAMETER2='N' where PARAMETER1='NostroReconciliationTaskStatus' and IdABTEILUNGSPARAMETER='NOSTRO_RECONCILIATION'", conn)
                        objCMD.ExecuteNonQuery()
                        If objCMD.Connection.State = ConnectionState.Open Then
                            objCMD.Connection.Close()
                        End If
                        'NOSTRO_RECONCILIATIONS_FILL()
                        'SWIFT_ACC_BALANCES_FILL()
                        'Me.NOSTRO_ACC_RECONCILIATIONS_OPENTableAdapter.FillByRecAccOpenFromLastRecDay(Me.AccountsReconciliationsDataSet.NOSTRO_ACC_RECONCILIATIONS_OPEN, NostroAccount, rd)

                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try

                End If
            ElseIf ReconCount <> 0 Then
                XtraMessageBox.Show("Unable to create the missing reconciliation!" & vbNewLine & "There is a reconciliation for the defined Nostro Account on " & mrd, "UNABLE TO RECONCILE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If
        Else
            XtraMessageBox.Show("Please select first a Nostro Account for the missing reconciliation", "UNABLE TO RECONCILE - NOSTRO ACCOUNT NOT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    
   
    
End Class



