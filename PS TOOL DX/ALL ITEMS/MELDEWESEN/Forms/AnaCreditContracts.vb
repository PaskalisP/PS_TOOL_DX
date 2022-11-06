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
Imports DevExpress.XtraEditors.Controls
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports DevExpress.Compression

Public Class AnaCreditContracts

    Dim CrystalRepDir As String = ""
    Dim ActiveTabGroup As Double = 0
    Dim ActiveTabGroupQueries As Double = 0
    Dim AnaCredit_XML_Files_Directory As String = Nothing
    Dim ID_AnaCreditContract As Integer = 0

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
    Private BS_All_BusinessDates As BindingSource

    Dim SqlCommandText As String = Nothing
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


    Private Sub AnaCreditContracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='AnaCredit_XmlFiles_Directory' 
                                  and [IdABTEILUNGSPARAMETER]='ANACREDIT' and [IdABTEILUNGSCODE_NAME]='MELDEWESEN' and [PARAMETER STATUS]='Y'"
        If IsDBNull(cmd.ExecuteScalar) = False Then
            AnaCredit_XML_Files_Directory = CType(cmd.ExecuteScalar, String)
        End If
        'Create Layout Save Folder directory (if not present)
        If IsDBNull(AnaCredit_XML_Files_Directory) = False AndAlso AnaCredit_XML_Files_Directory <> "" Then
            Try
                If Not Directory.Exists(AnaCredit_XML_Files_Directory) Then
                    Directory.CreateDirectory(AnaCredit_XML_Files_Directory)
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "UNABLE TO CREATE ANACREDIT XML FILES DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        Else

        End If

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        '***********************************************************************
        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.Date_BarEditItem.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString

        'Bind Combobox
        'Me.FromDateEdit.Properties.Items.Clear()
        'Me.QueryText = "Declare @MAXRISKDATE Datetime=(Select Max(RiskDate) from ANACREDIT_CONTRACTS Where DAY(DATEADD(day, 1, RiskDate)) = 1)Select CONVERT(VARCHAR(10),B.R,104) as 'RLDC Date' from (Select RiskDate as R from ANACREDIT_CONTRACTS Where (DAY(DATEADD(day, 1, RiskDate)) = 1) UNION ALL Select Max(RiskDate) as R from ANACREDIT_CONTRACTS Where RiskDate>@MAXRISKDATE)B GROUP BY B.R Order by B.R desc"
        'da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt1 = New System.Data.DataTable()
        'da1.Fill(dt1)
        'For Each row As DataRow In dt1.Rows
        '    If dt1.Rows.Count > 0 Then
        '        Me.FromDateEdit.Properties.Items.Add(row("RLDC Date"))
        '    End If
        'Next
        'If dt1.Rows.Count > 0 Then
        '    Me.FromDateEdit.Text = dt1.Rows.Item(0).Item("RLDC Date")
        'End If

        Dim d As Date = CDate(Me.Date_BarEditItem.EditValue.ToString)
        Dim dsql As String = d.ToString("yyyyMMdd")


        'Fill Anacredit Contracts
        Dim da As SqlDataAdapter
        Dim objCMD As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select * from [ANACREDIT_CONTRACTS] where [RiskDate]=@RISKDATE and (MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or MaturityDate is NULL) ORDER BY CASE [ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl2.DataSource = dt
            Me.GridControl2.ForceInitialize()
        End If

        'Fill Monthly
        'Dim da2 As SqlDataAdapter
        'Dim objCMD2 As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select B.ContractInput,A.ClientNr,A.ClientName,A.CCY,A.Contract_Account,A.StartDate,A.MaturityDate,A.BusinessType,A.Valid from ALL_CONTRACTS_ACCOUNTS A INNER JOIN (Select ContractInput, Contract_Account  from ANACREDIT_CONTRACTS where ID in (Select Min(ID) from ANACREDIT_CONTRACTS where [RiskDate] BETWEEN DATEADD(dd,-(DAY(@RISKDATE)-1),@RISKDATE) and DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) group by Contract_Account) and [RiskDate] BETWEEN DATEADD(dd,-(DAY(@RISKDATE)-1),@RISKDATE) and DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) GROUP BY ContractInput,Contract_Account)B on A.Contract_Account=B.Contract_Account where (A.MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or A.MaturityDate is NULL) ORDER BY CASE B.[ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
        'objCMD2.CommandTimeout = 5000
        'da2 = New SqlDataAdapter(objCMD2)
        'dt2 = New DataTable()
        'da2.Fill(dt2)
        'If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then

        '    Me.GridControl3.DataSource = Nothing
        '    Me.GridControl3.DataSource = dt2
        '    Me.GridControl3.ForceInitialize()
        '    Me.AnaCreditContractsMonthly_GridView.ViewCaption = "AnaCredit Contracts for:" & MonthName(d.Month, True) & " " & Year(d)

        'End If



    End Sub

    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Declare @MAXRISKDATE Datetime=(Select Max(RiskDate) from ANACREDIT_CONTRACTS 
                                                    Where DAY(DATEADD(day, 1, RiskDate)) = 1)Select CONVERT(VARCHAR(10),B.R,104) as 'RLDC Date' 
                                                    from (Select RiskDate as R from ANACREDIT_CONTRACTS 
                                                    Where (DAY(DATEADD(day, 1, RiskDate)) = 1) UNION ALL Select Max(RiskDate) as R 
                                                    from ANACREDIT_CONTRACTS Where RiskDate>@MAXRISKDATE)B GROUP BY B.R Order by B.R desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "RLDC Date")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_BusinessDates = New BindingSource(ds, "RLDC Date")
    End Sub
    Private Sub ALL_BUSINESS_DATES_InitLookUp()
        Me.Dates_RepositoryItemSearchLookUpEdit.DataSource = BS_All_BusinessDates
        Me.Dates_RepositoryItemSearchLookUpEdit.DisplayMember = "RLDC Date"
        Me.Dates_RepositoryItemSearchLookUpEdit.ValueMember = "RLDC Date"
    End Sub

    Private Sub Dates_RepositoryItemSearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Dates_RepositoryItemSearchLookUpEdit.ButtonClick
        If e.Button.Caption = "Reload Data" Then
            AnaCreditContracts_BaseView.ClearColumnsFilter()

            If IsDate(Me.Date_BarEditItem.EditValue.ToString) = True Then

                Dim d As Date = CDate(Me.Date_BarEditItem.EditValue.ToString)
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load AnaCredit Contracts + Customers for " & d)

                'Fill Daily
                Dim da As SqlDataAdapter
                Dim objCMD As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select * from [ANACREDIT_CONTRACTS] where [RiskDate]=@RISKDATE and (MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or MaturityDate is NULL) ORDER BY CASE [ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
                objCMD.CommandTimeout = 5000
                da = New SqlDataAdapter(objCMD)
                dt = New DataTable()
                da.Fill(dt)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Me.GridControl2.DataSource = Nothing
                    Me.GridControl2.DataSource = dt
                    Me.GridControl2.ForceInitialize()

                End If

                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub Dates_RepositoryItemSearchLookUpEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles Dates_RepositoryItemSearchLookUpEdit.KeyDown


        Dim d As Date = CDate(Me.Date_BarEditItem.EditValue.ToString)
        Dim dsql As String = d.ToString("yyyyMMdd")

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load AnaCredit Contracts + Customers for " & d)
        Dim OldValue As String = Me.Date_BarEditItem.EditValue.ToString
        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()
        Me.Date_BarEditItem.EditValue = OldValue

        Dim da As SqlDataAdapter
        Dim objCMD As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select * from [ANACREDIT_CONTRACTS] where [RiskDate]=@RISKDATE and (MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or MaturityDate is NULL) ORDER BY CASE [ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl2.DataSource = dt
            Me.GridControl2.ForceInitialize()
        End If

        'Fill Monthly
        'Dim da2 As SqlDataAdapter
        'Dim objCMD2 As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select B.ContractInput,A.ClientNr,A.ClientName,A.CCY,A.Contract_Account,A.StartDate,A.MaturityDate,A.BusinessType,A.Valid from ALL_CONTRACTS_ACCOUNTS A INNER JOIN (Select ContractInput, Contract_Account  from ANACREDIT_CONTRACTS where ID in (Select Min(ID) from ANACREDIT_CONTRACTS where [RiskDate] BETWEEN DATEADD(dd,-(DAY(@RISKDATE)-1),@RISKDATE) and DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) group by Contract_Account) and [RiskDate] BETWEEN DATEADD(dd,-(DAY(@RISKDATE)-1),@RISKDATE) and DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) GROUP BY ContractInput,Contract_Account)B on A.Contract_Account=B.Contract_Account where (A.MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or A.MaturityDate is NULL) ORDER BY CASE B.[ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
        'objCMD2.CommandTimeout = 5000
        'da2 = New SqlDataAdapter(objCMD2)
        'dt2 = New DataTable()
        'da2.Fill(dt2)
        'If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then

        '    Me.GridControl3.DataSource = Nothing
        '    Me.GridControl3.DataSource = dt2
        '    Me.GridControl3.ForceInitialize()
        '    Me.AnaCreditContractsMonthly_GridView.ViewCaption = "AnaCredit Contracts for:" & MonthName(d.Month, True) & " " & Year(d)

        'End If

        SplashScreenManager.CloseForm(False)


    End Sub

    Private Sub Date_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles Date_BarEditItem.EditValueChanged
        Dim d As Date = CDate(Me.Date_BarEditItem.EditValue.ToString)
        Dim dsql As String = d.ToString("yyyyMMdd")

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load AnaCredit Contracts + Customers for " & d)
        Dim OldValue As String = Me.Date_BarEditItem.EditValue.ToString
        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()
        Me.Date_BarEditItem.EditValue = OldValue

        Dim da As SqlDataAdapter
        Dim objCMD As SqlCommand = New SqlCommand("Declare @RISKDATE Datetime Set @RISKDATE='" & dsql & "' Select * from [ANACREDIT_CONTRACTS] where [RiskDate]=@RISKDATE and (MaturityDate>=DATEADD(dd,-(DAY(DATEADD(mm,1,@RISKDATE))),DATEADD(mm,1,@RISKDATE)) or MaturityDate is NULL) ORDER BY CASE [ContractInput] when 'NEW' then 1 when 'CURRENT' then 2 END", conn)
        objCMD.CommandTimeout = 5000
        da = New SqlDataAdapter(objCMD)
        dt = New DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl2.DataSource = dt
            Me.GridControl2.ForceInitialize()
        End If

        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub AnaCreditContracts_BaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles AnaCreditContracts_BaseView.CellValueChanged
        Dim View As GridView = CType(sender, GridView)
        Dim ChangedValue As String = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("MarkedForConfirmation"))
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Select Case ChangedValue
            Case "True"
                cmd.CommandText = "UPDATE [ANACREDIT_CONTRACTS] SET MarkedForConfirmation=1 where ID=" & ID_AnaCreditContract & ""
                cmd.ExecuteNonQuery()
            Case "False"
                cmd.CommandText = "UPDATE [ANACREDIT_CONTRACTS] SET MarkedForConfirmation=0 where ID=" & ID_AnaCreditContract & ""
                cmd.ExecuteNonQuery()
        End Select
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        AnaCreditContracts_BaseView.PostEditor()

    End Sub

    Private Sub AnaCreditContracts_BaseView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AnaCreditContracts_BaseView.RowCellClick
        ID_AnaCreditContract = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_AnaCreditContract = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub AnaCreditContracts_BaseView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles AnaCreditContracts_BaseView.FocusedRowChanged
        ID_AnaCreditContract = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ID_AnaCreditContract = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
    End Sub

    Private Sub Print_Export_btn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Print_Export_btn.ItemClick
        'If ActiveTabGroup = 0 Then
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
        'End If
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
        Dim reportfooter As String = "AnaCredit Contracts + Customers" & "   " & "Date: " & CDate(Me.Date_BarEditItem.EditValue.ToString)
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs)
        'If Me.TabbedControlGroup1.SelectedTabPage.Text = "AnaCredit Contracts + Customers" Then
        '    ActiveTabGroup = 0
        '    'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "AnaCredit Contracts/Customers (Monthly)" Then
        '    '    ActiveTabGroup = 2
        '    'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Balance Sheet 1-2 Compared" Then
        '    '    ActiveTabGroup = 1
        'End If

    End Sub

    Private Sub AnaCreditContracts_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AnaCreditContracts_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AnaCreditContracts_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles AnaCreditContracts_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub AnaCreditContracts_BaseView_DoubleClick(sender As Object, e As EventArgs) Handles AnaCreditContracts_BaseView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "ClientNr" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "ClientNr").ToString
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
            If view.FocusedColumn.FieldName = "Contract_Account" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract_Account").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "ClientNr").ToString
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

    Private Sub AnaCredit_Monthly_XML_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AnaCredit_Monthly_XML_BarButtonItem.ItemClick
        rd = CDate(Me.Date_BarEditItem.EditValue.ToString)
        rdsql = rd.ToString("yyyyMMdd")
        Dim MeldeMonat As String = rd.ToString("yyyyMM")

        If XtraMessageBox.Show("Should the AnaCredit Monthly Confirmation XML File for Reporting Date: " & rd & " be created?", "ANACREDIT MONTHLY CONFIRMATION FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            QueryText = "Select * from [ANACREDIT_CONTRACTS] where MarkedForConfirmation=1 and [RiskDate]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dt.Clear()
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
                    SplashScreenManager.Default.SetWaitFormCaption("Start creating the AnaCredit Monthly Confirmation Report File for reporting Period: " & MeldeMonat)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)

                    'Bank Data load
                    Dim FIRMENNUMMER As String = Nothing
                    Dim BANKNAME As String = Nothing
                    Dim BANKSTRASSE As String = Nothing
                    Dim BANKPLZ As String = Nothing
                    Dim BANKORT As String = Nothing
                    Dim MFI_CODE As String = Nothing
                    Dim BLZ As String = Nothing

                    SplashScreenManager.Default.SetWaitFormCaption("Select Bank Data for reporting Period: ")
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    QueryText = "Select * from [BANK]"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        FIRMENNUMMER = dt.Rows.Item(i).Item("BLZ Bank")
                        BANKNAME = dt.Rows.Item(i).Item("Name Bank").ToString & " , " & dt.Rows.Item(i).Item("Branch Bank").ToString
                        BANKSTRASSE = dt.Rows.Item(i).Item("Strasse Bank")
                        BANKPLZ = dt.Rows.Item(i).Item("PLZ Bank")
                        BANKORT = dt.Rows.Item(i).Item("Ort Bank")
                        MFI_CODE = dt.Rows.Item(i).Item("MFI_Code")
                        BLZ = dt.Rows.Item(i).Item("BLZ Bank")
                    Next

                    Dim XMLSAVEFILE As String = Nothing
                    Dim MELDETERMIN As String = Nothing
                    Dim XMLMESSAGEID As String = Nothing
                    Dim XMLMELDETERMIN As String = Nothing

                    SplashScreenManager.Default.SetWaitFormCaption("Select AnaCredit Confirmation Parameters")
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    QueryText = "Select * from [PARAMETER] where  [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ANACREDIT' and [IdABTEILUNGSCODE_NAME] in ('MELDEWESEN')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            If dt.Rows.Item(i).Item("PARAMETER1").ToString = "AnaCredit_XmlFiles_Directory" Then
                                XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
                            End If
                        Next
                    End If
                    dt.Clear()

                    SplashScreenManager.Default.SetWaitFormCaption("Start creating XML File for reporting Period: " & MeldeMonat)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    'XML DATEI erstellungsdatum un Zeitdefinieren
                    Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
                    Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "HH:mm:ss")
                    XMLMESSAGEID = rdsql & DateTime.Now.ToString("yyyyMMdd") & ERSTELLUNGSZEIT.ToString("HHmmss")
                    'MELDETERMIN
                    MELDETERMIN = MeldeMonat
                    XMLMELDETERMIN = MELDETERMIN

                    Dim MyWriter As System.Xml.XmlWriter
                    Dim MySettings As New System.Xml.XmlWriterSettings
                    MySettings.Indent = True
                    MySettings.OmitXmlDeclaration = True ' No XML Declaration
                    MySettings.Encoding = New UTF8Encoding(False) ' Sets the UTF encoding to False
                    MySettings.ConformanceLevel = ConformanceLevel.Document
                    MySettings.IndentChars = "    "

                    MySettings.NewLineOnAttributes = False
                    'MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")

                    Dim AnaCredit_Confirmation_XML_File As String = "accf_" & BLZ & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml"
                    MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & AnaCredit_Confirmation_XML_File, MySettings)

                    With MyWriter
                        'XML HEADER
                        .WriteStartDocument()
                        .WriteStartElement("ns8", "StructureSpecificData", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                        .WriteAttributeString("xmlns", "ns6", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/metadata/generic")
                        .WriteAttributeString("xmlns", "ns5", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")
                        .WriteAttributeString("xmlns", "ns8", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                        .WriteAttributeString("xmlns", "ns7", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/metadata/structurespecific")
                        .WriteAttributeString("xmlns", "ns9", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message/footer")
                        .WriteAttributeString("xmlns", "ns2", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")
                        .WriteAttributeString("xmlns", "ns4", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/structure")
                        .WriteAttributeString("xmlns", "ns3", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/structurespecific")


                        'ELEMENT-HEADER
                        .WriteStartElement("ns8", "Header", Nothing)
                        .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                        .WriteAttributeString("xsi", "type", Nothing, "ns8:StructureSpecificDataHeaderType")
                        .WriteElementString("ns8", "ID", Nothing, XMLMESSAGEID)
                        .WriteElementString("ns8", "Test", Nothing, "false")
                        .WriteElementString("ns8", "Prepared", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "+02:00")
                        'Element-Sender
                        .WriteStartElement("ns8", "Sender", Nothing)
                        .WriteAttributeString("id", BLZ)
                        .WriteEndElement() 'Sender - FullElement
                        '##############################
                        'Structure BBK_ANCRDT_CNFRMTN_HDR_C
                        .WriteStartElement("ns8", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:StructureSpecificDataStructureType")
                        .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                        .WriteAttributeString("namespace", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("structureID", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteStartElement("ns2", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:DataStructureReferenceType")
                        .WriteStartElement(Nothing, "Ref", Nothing)
                        .WriteAttributeString("agencyID", "BBK")
                        .WriteAttributeString("id", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteEndElement() 'Ref - FullElement
                        .WriteEndElement() 'ns2 structure
                        .WriteEndElement() 'ns8 Structure
                        '##############################
                        'BBK_ANCRDT_CNFRMTN_C
                        .WriteStartElement("ns8", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:StructureSpecificDataStructureType")
                        .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                        .WriteAttributeString("namespace", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteAttributeString("structureID", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteStartElement("ns2", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:DataStructureReferenceType")
                        .WriteStartElement(Nothing, "Ref", Nothing)
                        .WriteAttributeString("agencyID", "BBK")
                        .WriteAttributeString("id", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteEndElement() 'Ref-FullElement
                        .WriteEndElement() 'ns2 structure
                        .WriteEndElement() 'ns8 Structure
                        '##############################
                        .WriteEndElement() 'End ELEMENT HEADER
                        '##############################
                        'Dataset BBK_ANCRDT_CNFRMTN_HDR_C
                        .WriteStartElement("ns8", "DataSet", Nothing)
                        .WriteAttributeString("xmlns", "ns11", Nothing, "http://www.bundesbank.de/statistik/anacredit/cnfrmtn/v2")
                        .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                        .WriteAttributeString("xsi", "type", Nothing, "ns11:BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("ns3", "structureRef", Nothing, "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("ns3", "dataScope", Nothing, "DataStructure")
                        .WriteStartElement(Nothing, "Obs", Nothing)
                        .WriteAttributeString("SRVY_ID", "CNFRMTN")
                        .WriteAttributeString("APPLCTN", "AC")
                        .WriteAttributeString("xsi", "type", Nothing, "ns11:ObsBBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("RPRTNG_AGNT_CD", BLZ)
                        .WriteAttributeString("DT_RFRNC", MELDETERMIN)
                        .WriteAttributeString("OBSRVD_AGNT_CD", BLZ)
                        .WriteEndElement() 'obs-FullElement
                        .WriteEndElement() 'message DataSet
                        '##############################


                        QueryText = "Select * from [ANACREDIT_CONTRACTS] where MarkedForConfirmation=1 and [RiskDate]='" & rdsql & "'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement("ns8", "DataSet", Nothing)
                            .WriteAttributeString("xmlns", "ns11", Nothing, "http://www.bundesbank.de/statistik/anacredit/cnfrmtn/v2")
                            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                            .WriteAttributeString("ns3", "action", Nothing, "Replace")
                            .WriteAttributeString("xsi", "type", Nothing, "ns11:BBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("ns3", "structureRef", Nothing, "BBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("ns3", "dataScope", Nothing, "DataStructure")
                            'This should be replaced with each rows.count
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("INSTRMNT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("xsi", "type", Nothing, "ns11:ObsBBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("CNTRCT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("ATTRBT_VL", dt.Rows.Item(i).Item("Amt_EUR").ToString.Replace(",", "."))
                            .WriteAttributeString("CNFRMTN_TYP", "VL_CNFRMD")
                            .WriteAttributeString("VLDTN_ID", "GCMA_TH_H_OTSTNDNG_NMNL_AMNT_INSTRMNT")
                            .WriteEndElement() 'obs-FullElement
                            .WriteEndElement() 'Dataset
                        Next

                        '++++++++++++++++++++++++++++++++++
                        .WriteEndDocument()
                        .Close()

                    End With

                    'adding only XML Declaration:<?xml version="1.0"?>
                    Dim doc As XmlDocument = New XmlDocument()
                    doc.Load(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)
                    Dim xmldecl As XmlDeclaration
                    xmldecl = doc.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    Dim root As XmlElement = doc.DocumentElement
                    doc.InsertBefore(xmldecl, root)
                    doc.Save(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)

                    Dim zipFileName As String = XMLSAVEFILE & AnaCredit_Confirmation_XML_File.Replace(".xml", ".zip")
                    Using archive As New ZipArchive()
                        archive.AddFile(XMLSAVEFILE & AnaCredit_Confirmation_XML_File, "/")
                        archive.Save(zipFileName)
                    End Using
                    If System.IO.File.Exists(XMLSAVEFILE & AnaCredit_Confirmation_XML_File) = True Then
                        System.IO.File.Delete(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)
                    End If

                    SplashScreenManager.CloseForm(False)


                    If MessageBox.Show("Following AnaCredit Confirmation XML file has being generated: " & vbNewLine & "accf_" & BLZ & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml" & vbNewLine _
                        & "and saved under the following directory:" & vbNewLine _
                        & XMLSAVEFILE & vbNewLine & vbNewLine _
                        & "Should the directory be opened?", "AnaCredit File succesfully generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                        System.Diagnostics.Process.Start(XMLSAVEFILE)

                    End If



                    Exit Sub

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try
            Else
                XtraMessageBox.Show("Unable to create the Monthly AnaCredit confirmation File!" & vbNewLine & "There are no selected contracts for confirmation!", "UNABLE TO CREATE XML FILE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub AnaCredit_Quarterly_XML_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AnaCredit_Quarterly_XML_BarButtonItem.ItemClick
        rd = CDate(Me.Date_BarEditItem.EditValue.ToString)
        rdsql = rd.ToString("yyyyMMdd")
        Dim MeldeMonat As String = rd.ToString("yyyyMM")

        If XtraMessageBox.Show("Should the AnaCredit Quarterly Confirmation XML File for Reporting Date: " & rd & " be created?", "ANACREDIT QUARTERLY CONFIRMATION FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            QueryText = "Select * from [ANACREDIT_CONTRACTS] where MarkedForConfirmation=1 and [RiskDate]='" & rdsql & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dt.Clear()
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
                    SplashScreenManager.Default.SetWaitFormCaption("Start creating the AnaCredit Quarterly Confirmation Report File for reporting Period: " & MeldeMonat)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)

                    'Bank Data load
                    Dim FIRMENNUMMER As String = Nothing
                    Dim BANKNAME As String = Nothing
                    Dim BANKSTRASSE As String = Nothing
                    Dim BANKPLZ As String = Nothing
                    Dim BANKORT As String = Nothing
                    Dim MFI_CODE As String = Nothing
                    Dim BLZ As String = Nothing

                    SplashScreenManager.Default.SetWaitFormCaption("Select Bank Data for reporting Period: ")
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    QueryText = "Select * from [BANK]"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        FIRMENNUMMER = dt.Rows.Item(i).Item("BLZ Bank")
                        BANKNAME = dt.Rows.Item(i).Item("Name Bank").ToString & " , " & dt.Rows.Item(i).Item("Branch Bank").ToString
                        BANKSTRASSE = dt.Rows.Item(i).Item("Strasse Bank")
                        BANKPLZ = dt.Rows.Item(i).Item("PLZ Bank")
                        BANKORT = dt.Rows.Item(i).Item("Ort Bank")
                        MFI_CODE = dt.Rows.Item(i).Item("MFI_Code")
                        BLZ = dt.Rows.Item(i).Item("BLZ Bank")
                    Next

                    Dim XMLSAVEFILE As String = Nothing
                    Dim MELDETERMIN As String = Nothing
                    Dim XMLMESSAGEID As String = Nothing
                    Dim XMLMELDETERMIN As String = Nothing

                    SplashScreenManager.Default.SetWaitFormCaption("Select AnaCredit Confirmation Parameters")
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    QueryText = "Select * from [PARAMETER] where  [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ANACREDIT' and [IdABTEILUNGSCODE_NAME] in ('MELDEWESEN')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            If dt.Rows.Item(i).Item("PARAMETER1").ToString = "AnaCredit_XmlFiles_Directory" Then
                                XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
                            End If
                        Next
                    End If
                    dt.Clear()

                    SplashScreenManager.Default.SetWaitFormCaption("Start creating XML File for reporting Period: " & MeldeMonat)
                    System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                    'XML DATEI erstellungsdatum un Zeitdefinieren
                    Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
                    Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "HH:mm:ss")
                    XMLMESSAGEID = rdsql & DateTime.Now.ToString("yyyyMMdd") & ERSTELLUNGSZEIT.ToString("HHmmss")
                    'MELDETERMIN
                    MELDETERMIN = MeldeMonat
                    XMLMELDETERMIN = MELDETERMIN

                    Dim MyWriter As System.Xml.XmlWriter
                    Dim MySettings As New System.Xml.XmlWriterSettings
                    MySettings.Indent = True
                    MySettings.OmitXmlDeclaration = True ' No XML Declaration
                    MySettings.Encoding = New UTF8Encoding(False) ' Sets the UTF encoding to False
                    MySettings.ConformanceLevel = ConformanceLevel.Document
                    MySettings.IndentChars = "    "

                    MySettings.NewLineOnAttributes = False
                    'MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")

                    Dim AnaCredit_Confirmation_XML_File As String = "accf_" & BLZ & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml"
                    MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & AnaCredit_Confirmation_XML_File, MySettings)

                    With MyWriter
                        'XML HEADER
                        .WriteStartDocument()
                        .WriteStartElement("ns8", "StructureSpecificData", "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                        .WriteAttributeString("xmlns", "ns6", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/metadata/generic")
                        .WriteAttributeString("xmlns", "ns5", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")
                        .WriteAttributeString("xmlns", "ns8", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")
                        .WriteAttributeString("xmlns", "ns7", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/metadata/structurespecific")
                        .WriteAttributeString("xmlns", "ns9", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message/footer")
                        .WriteAttributeString("xmlns", "ns2", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")
                        .WriteAttributeString("xmlns", "ns4", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/structure")
                        .WriteAttributeString("xmlns", "ns3", Nothing, "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/structurespecific")


                        'ELEMENT-HEADER
                        .WriteStartElement("ns8", "Header", Nothing)
                        .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                        .WriteAttributeString("xsi", "type", Nothing, "ns8:StructureSpecificDataHeaderType")
                        .WriteElementString("ns8", "ID", Nothing, XMLMESSAGEID)
                        .WriteElementString("ns8", "Test", Nothing, "false")
                        .WriteElementString("ns8", "Prepared", Nothing, ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "+02:00")
                        'Element-Sender
                        .WriteStartElement("ns8", "Sender", Nothing)
                        .WriteAttributeString("id", BLZ)
                        .WriteEndElement() 'Sender- FullElement
                        '##############################
                        'Structure BBK_ANCRDT_CNFRMTN_HDR_C
                        .WriteStartElement("ns8", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:StructureSpecificDataStructureType")
                        .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                        .WriteAttributeString("namespace", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("structureID", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteStartElement("ns2", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:DataStructureReferenceType")
                        .WriteStartElement(Nothing, "Ref", Nothing)
                        .WriteAttributeString("agencyID", "BBK")
                        .WriteAttributeString("id", "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteEndElement() 'Ref- FullElement
                        .WriteEndElement() 'ns2 structure
                        .WriteEndElement() 'ns8 Structure
                        '##############################
                        'BBK_ANCRDT_CNFRMTN_C
                        .WriteStartElement("ns8", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:StructureSpecificDataStructureType")
                        .WriteAttributeString("dimensionAtObservation", "AllDimensions")
                        .WriteAttributeString("namespace", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteAttributeString("structureID", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteStartElement("ns2", "Structure", Nothing)
                        .WriteAttributeString("xsi", "type", Nothing, "ns2:DataStructureReferenceType")
                        .WriteStartElement(Nothing, "Ref", Nothing)
                        .WriteAttributeString("agencyID", "BBK")
                        .WriteAttributeString("id", "BBK_ANCRDT_CNFRMTN_C")
                        .WriteEndElement() 'Ref- FullElement
                        .WriteEndElement() 'ns2 structure
                        .WriteEndElement() 'ns8 Structure
                        '##############################
                        .WriteEndElement() 'End ELEMENT HEADER
                        '##############################
                        'Dataset BBK_ANCRDT_CNFRMTN_HDR_C
                        .WriteStartElement("ns8", "DataSet", Nothing)
                        .WriteAttributeString("xmlns", "ns11", Nothing, "http://www.bundesbank.de/statistik/anacredit/cnfrmtn/v2")
                        .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                        .WriteAttributeString("xsi", "type", Nothing, "ns11:BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("ns3", "structureRef", Nothing, "BBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("ns3", "dataScope", Nothing, "DataStructure")
                        .WriteStartElement(Nothing, "Obs", Nothing)
                        .WriteAttributeString("SRVY_ID", "CNFRMTN")
                        .WriteAttributeString("APPLCTN", "AC")
                        .WriteAttributeString("xsi", "type", Nothing, "ns11:ObsBBK_ANCRDT_CNFRMTN_HDR_C")
                        .WriteAttributeString("RPRTNG_AGNT_CD", BLZ)
                        .WriteAttributeString("DT_RFRNC", MELDETERMIN)
                        .WriteAttributeString("OBSRVD_AGNT_CD", BLZ)
                        .WriteEndElement() 'obs- FullElement
                        .WriteEndElement() 'message DataSet
                        '##############################


                        QueryText = "Select * from [ANACREDIT_CONTRACTS] where MarkedForConfirmation=1 and [RiskDate]='" & rdsql & "'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            .WriteStartElement("ns8", "DataSet", Nothing)
                            .WriteAttributeString("xmlns", "ns11", Nothing, "http://www.bundesbank.de/statistik/anacredit/cnfrmtn/v2")
                            .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                            .WriteAttributeString("ns3", "action", Nothing, "Replace")
                            .WriteAttributeString("xsi", "type", Nothing, "ns11:BBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("ns3", "structureRef", Nothing, "BBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("ns3", "dataScope", Nothing, "DataStructure")
                            'Für Quartalsbestätigung
                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("INSTRMNT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("xsi", "type", Nothing, "ns11:ObsBBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("CNTRCT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("ATTRBT_VL", dt.Rows.Item(i).Item("Amt_EUR").ToString.Replace(",", "."))
                            .WriteAttributeString("CNFRMTN_TYP", "VL_CNFRMD")
                            .WriteAttributeString("VLDTN_ID", "GCMA_TH_H_CRRYNG_AMNT_INSTRMNT")
                            .WriteEndElement() 'obs- FullElement

                            .WriteStartElement(Nothing, "Obs", Nothing)
                            .WriteAttributeString("INSTRMNT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("xsi", "type", Nothing, "ns11:ObsBBK_ANCRDT_CNFRMTN_C")
                            .WriteAttributeString("CNTRCT_ID", dt.Rows.Item(i).Item("Contract_Account").ToString)
                            .WriteAttributeString("ATTRBT_VL", dt.Rows.Item(i).Item("Amt_EUR").ToString.Replace(",", "."))
                            .WriteAttributeString("CNFRMTN_TYP", "VL_CNFRMD")
                            .WriteAttributeString("VLDTN_ID", "GCMA_TH_H_OTSTNDNG_NMNL_AMNT_INSTRMNT")
                            .WriteEndElement() 'obs- FullElement

                            .WriteEndElement() 'Dataset
                        Next

                        '++++++++++++++++++++++++++++++++++
                        .WriteEndDocument()
                        .Close()

                    End With

                    'adding only XML Declaration:<?xml version="1.0"?>
                    Dim doc As XmlDocument = New XmlDocument()
                    doc.Load(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)
                    Dim xmldecl As XmlDeclaration
                    xmldecl = doc.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    Dim root As XmlElement = doc.DocumentElement
                    doc.InsertBefore(xmldecl, root)
                    doc.Save(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)

                    Dim zipFileName As String = XMLSAVEFILE & AnaCredit_Confirmation_XML_File.Replace(".xml", ".zip")
                    Using archive As New ZipArchive()
                        archive.AddFile(XMLSAVEFILE & AnaCredit_Confirmation_XML_File, "/")
                        archive.Save(zipFileName)
                    End Using
                    If System.IO.File.Exists(XMLSAVEFILE & AnaCredit_Confirmation_XML_File) = True Then
                        System.IO.File.Delete(XMLSAVEFILE & AnaCredit_Confirmation_XML_File)
                    End If

                    SplashScreenManager.CloseForm(False)


                    If MessageBox.Show("Following AnaCredit Confirmation XML file has being generated: " & vbNewLine & "accf_" & BLZ & "_" & XMLMELDETERMIN & "_" & XMLMESSAGEID & ".xml" & vbNewLine _
                        & "and saved under the following directory:" & vbNewLine _
                        & XMLSAVEFILE & vbNewLine & vbNewLine _
                        & "Should the directory be opened?", "AnaCredit File succesfully generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                        System.Diagnostics.Process.Start(XMLSAVEFILE)

                    End If



                    Exit Sub

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try
            Else
                XtraMessageBox.Show("Unable to create the Quarterly AnaCredit confirmation File!" & vbNewLine & "There are no selected contracts for confirmation!", "UNABLE TO CREATE XML FILE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End If

    End Sub


    Private Sub OpenXmlCreationFolder_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OpenXmlCreationFolder_BarButtonItem.ItemClick

        Dim XMLSAVEFILE As String = Nothing

        QueryText = "Select * from [PARAMETER] where  [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ANACREDIT' and [IdABTEILUNGSCODE_NAME] in ('MELDEWESEN')"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1").ToString = "AnaCredit_XmlFiles_Directory" Then
                    XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2").ToString
                End If
            Next
        End If
        dt.Clear()

        System.Diagnostics.Process.Start(XMLSAVEFILE)
    End Sub


End Class