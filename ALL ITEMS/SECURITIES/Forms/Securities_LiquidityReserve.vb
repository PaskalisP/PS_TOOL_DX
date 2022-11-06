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
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.Utils

Public Class Securities_LiquidityReserve

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
   

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

    Private Sub SECURITIES_LIQUIDITYRESERVEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SECURITIES_LIQUIDITYRESERVEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)

    End Sub

    Private Sub Securities_LiquidityReserve_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
            Me.SecuritiesLiquidBaseView.ExpandAllGroups()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub Securities_LiquidityReserve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE' table. You can move, or remove it, as needed.
        Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
        Me.SecuritiesLiquidBaseView.ExpandAllGroups()

        'Gridcontrol2 - SECURITIES
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = SecuritiesLiquidBaseView
        SecuritiesLiquidBaseView.ForceDoubleClick = True
        AddHandler SecuritiesLiquidBaseView.DoubleClick, AddressOf SecuritiesLiquidBaseView_DoubleClick
        AddHandler SecuritiesLiquidDetailView.MouseDown, AddressOf SecuritiesLiquidDetailView_MouseDown
        AddHandler SecuritiesLiquidDetailView_btn.Click, AddressOf SecuritiesLiquidDetailView_btn_Click
        SecuritiesLiquidDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        SecuritiesLiquidDetailView.OptionsBehavior.AllowSwitchViewModes = False
    End Sub

#Region "SECURITIES_LIQUIDITY_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = SecuritiesLiquidDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesLiquidBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        SecuritiesLiquidDetailView_btn.Text = strShowExtendedMode
        SecuritiesLiquidDetailView_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesLiquidDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        Dim datasourceRowIndex As Integer = SecuritiesLiquidBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = SecuritiesLiquidDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        SecuritiesLiquidDetailView_btn.Text = strHideExtendedMode
        SecuritiesLiquidDetailView_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is SecuritiesLiquidDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesLiquidBaseView.GetRowHandle(dataSourceRowIndex)
        SecuritiesLiquidBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = SecuritiesLiquidDetailView.GetRowHandle(dataSourceRowIndex)
        SecuritiesLiquidDetailView.VisibleRecordIndex = SecuritiesLiquidDetailView.GetVisibleIndex(rowHandle)
        SecuritiesLiquidDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub SecuritiesLiquidBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = SecuritiesLiquidBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub SecuritiesLiquidDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = SecuritiesLiquidDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub SecuritiesLiquidDetailView_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub SecuritiesLiquidBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SecuritiesLiquidBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SecuritiesLiquidBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SecuritiesLiquidBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CreateNewLiquidity_btn_Click(sender As Object, e As EventArgs) Handles CreateNewLiquidity_btn.Click
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='LIQUIDITY_RESERVE_USERS' and [PARAMETER STATUS]='Y' "
        Dim LiquidityReserveUserFind As String = cmd.ExecuteScalar
        If LiquidityReserveUserFind <> "" Then
            Try
                If IsDate(Me.LiquidityDateEdit.Text) = True Then
                    'Date to SQL String
                    Dim d As Date = Today
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    Dim Liqdate As Date = Me.LiquidityDateEdit.Text
                    Dim DateSql As String = Liqdate.ToString("yyyyMMdd")
                    Dim DateYearSql As String = Liqdate.ToString("yyyy")
                    'Check if LiquidityDate allready exists
                    cmd.CommandText = "Select distinct [LiquidityDate] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                    Dim resultLD As String = cmd.ExecuteScalar
                    'Liquidity Date not exists
                    If resultLD = "" Then
                        'Check if DailyPrice exists with the same liquidity date
                        cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DateSql & "' "
                        Dim resultDP As String = cmd.ExecuteScalar
                        'DailyPrice Date exists
                        If resultDP <> "" Then
                            'Define Securities Validity based on the expiry Date and Liquidity Reserve creation Date
                            cmd.CommandText = "SELECT [MaturityDate] from [SECURITIES_OUR] Begin UPDATE [SECURITIES_OUR] set [STATUS]='ACTIVE' where [MaturityDate]>'" & DateSql & "' end Begin UPDATE [SECURITIES_OUR] set [STATUS]='EXPIRED' where [MaturityDate]<='" & DateSql & "' end "
                            cmd.ExecuteNonQuery()
                            'Insert to Liquidity Reserve the Securities from Table SECURITIES_OUR
                            cmd.CommandText = "INSERT INTO [SECURITIES_LIQUIDITYRESERVE]([ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[Purchase_price],[Amt_Paid],[ContractNrOCBS],[TradeDate],[StartDate],[MaturityDate],[Sektor],[SektorCountry],[AssetType]) SELECT [ISIN],[SecurityName],[Currency],[PrincipalEuroAmt],[Purchase_Price],[Amt_Paid_Eur],[ContractNrOCBS],[TradeDate],[StartDate],[MaturityDate],[Sektor],[SektorCountry],[AssetType] from [SECURITIES_OUR] where [STATUS]='ACTIVE'"
                            cmd.ExecuteNonQuery()
                            'Update [LiquidityCreationDate] and [LiquidityDate]
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [LiquidityCreationDate]=' " & dsql & "',[LiquidityDate]=' " & DateSql & "' where [LiquidityCreationDate] is NULL "
                            cmd.ExecuteNonQuery()
                            '****************************************************************
                            '************SONDERFALL*****3 BUBA BONDS*****Amount Paid=Nominal
                            'cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Amt_Paid]=[PrincipalEuroAmt]  where [ISIN_Code] in ('DE0001119931A','DE0001119931B','DE0001119956') and [LiquidityDate]=' " & DateSql & "' "
                            'cmd.ExecuteNonQuery()
                            '****************************************************************
                            '****************************************************************
                            'Update Data from DailyPrice
                            cmd.CommandText = "UPDATE A SET A.[RIC]=B.[RIC],A.[Market_Price]=B.[Market_Price],A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon],A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield],A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating],A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DailyPrice] B ON A.[ISIN_Code]=B.[ISIN_Code] where A.[LiquidityDate]=B.[Date] and A.[Market_Price] is NULL "
                            cmd.ExecuteNonQuery()
                            'Update Start of Year Price
                            'Get Min Date in current year
                            cmd.CommandText = "Select Min([Date]) from [SECURITIES_DailyPrice] where Datepart(year,[Date])='" & DateYearSql & "'"
                            Dim MinDateDailyPrice As Date = cmd.ExecuteScalar
                            Dim SqlMinDateDailyPrice As String = MinDateDailyPrice.ToString("yyyyMMdd")
                            'Select Minimum DailyPrice Date in the specified year
                            Me.QueryText = "Select * from [SECURITIES_DailyPrice] where [Date]='" & SqlMinDateDailyPrice & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                Dim MinDate As Date = dt.Rows.Item(i).Item("Date")
                                Dim SqlDate As String = MinDate.ToString("yyyyMMdd")
                                cmd.CommandText = "UPDATE A SET A.[StartofYear_price]=B.[Market_Price] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DailyPrice] B ON A.[ISIN_Code]=B.[ISIN_Code] where A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[StartofYear_price] is NULL "
                                cmd.ExecuteNonQuery()
                            Next
                            'Calculate and Update AmtValueAsOfDate
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [ValueAsOfDate]=Round([PrincipalEuroAmt]*[Market_Price]/100,2) where [LiquidityDate]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            'Update Data from Accrued Interest Analysis
                            cmd.CommandText = "UPDATE A SET A.[Current Interest Rate]=B.[Current Interest Rate],A.[Current Interest Coupon Period Start Date]=B.[Current Interest Coupon Period Start Date],A.[Current Interest Coupon Period End Date]=B.[Current Interest Coupon Period End Date],A.[Accrued Interest Coupon Org Ccy]=B.[Accrued Interest Coupon Org Ccy],A.[Accrued Interest Coupon EUR Equ]=B.[Accrued Interest Coupon EUR Equ],A.[Interest Coupon amount Org Ccy]=B.[Interest Coupon amount Org Ccy],A.[Interest Coupon Amount EUR Equ]=B.[Interest Coupon Amount EUR Equ] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[ContractNrOCBS]=B.[Contract] where A.[LiquidityDate]=B.[Datadate] and A.[LiquidityDate]='" & DateSql & "' and B.[Class] in ('Assets') and A.[Current Interest Rate] is NULL "
                            cmd.ExecuteNonQuery()
                            'Get Depreciations from Depreciations Table
                            'Get Max Date from Depreciations Table
                            cmd.CommandText = "Select Max([Date]) as MaxDate from [SECURITIES_DEPRECIATIONS]"
                            Dim MaxDateSecuritiesDepreciation As Date = cmd.ExecuteScalar
                            Dim SqlMaxDateSecuritiesDepreciation As String = MaxDateSecuritiesDepreciation.ToString("yyyyMMdd")
                            'Fixed Assets
                            Me.QueryText = "Select * from [SECURITIES_DEPRECIATIONS] where [Depreciation_Type]='FIXED' and [Date]='" & SqlMaxDateSecuritiesDepreciation & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                Dim MaxDate As Date = dt.Rows.Item(i).Item("Date")
                                Dim SqlDate As String = MaxDate.ToString("yyyyMMdd")

                                cmd.CommandText = "UPDATE A  SET A.[Booked_Depreciation]=B.[Booked_Depreciation],A.[OCBS_Booked_Before]=B.[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DEPRECIATIONS] B ON A.[ISIN_Code]=B.[ISIN_Code] and A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[Booked_Depreciation] is NULL "
                                cmd.ExecuteNonQuery()
                            Next
                            'Current Assets
                            Me.QueryText = "Select * from [SECURITIES_DEPRECIATIONS] where [Depreciation_Type]='CURRENT' and [Date]='" & SqlMaxDateSecuritiesDepreciation & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                Dim MaxDate As Date = dt.Rows.Item(i).Item("Date")
                                Dim SqlDate As String = MaxDate.ToString("yyyyMMdd")

                                cmd.CommandText = "UPDATE A  SET A.[Booked_Depreciation]=B.[Booked_Depreciation],A.[OCBS_Booked_Before]=B.[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DEPRECIATIONS] B ON A.[ISIN_Code]=B.[ISIN_Code] and A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[Booked_Depreciation] is NULL "
                                cmd.ExecuteNonQuery()
                            Next
                            'Set all others to Zero
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Booked_Depreciation]=0 where [Booked_Depreciation] is NULL "
                            cmd.ExecuteNonQuery()
                            'Get the OCBS Booked before if is NULL
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Before]=[Amt_Paid]-[Booked_Depreciation] where [OCBS_Booked_Before] is NULL "
                            cmd.ExecuteNonQuery()
                            'Get the actual Depreciations
                            cmd.CommandText = "SELECT [Amt_Paid],[ValueAsOfDate] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Actual_Depreciation]=[Amt_Paid]-[ValueAsOfDate] where [Amt_Paid]>[ValueAsOfDate] and [LiquidityDate]='" & DateSql & "' end Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Actual_Depreciation]=0 where [Amt_Paid]<=[ValueAsOfDate] and [LiquidityDate]='" & DateSql & "' end "
                            cmd.ExecuteNonQuery()
                            'Update Depreciation/Appreciation Field only for Current Assets
                            cmd.CommandText = "SELECT [Booked_Depreciation],[Actual_Depreciation] from [SECURITIES_LIQUIDITYRESERVE] where [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "' Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Depreciation]=[Actual_Depreciation]-[Booked_Depreciation],[Apreciation]=0 where [Booked_Depreciation]<[Actual_Depreciation] and [AssetType]='CURRENT'and [LiquidityDate]='" & DateSql & "' end Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Apreciation]=[Booked_Depreciation]-[Actual_Depreciation],[Depreciation]=0 where [Booked_Depreciation]>[Actual_Depreciation] and [AssetType]='CURRENT'and [LiquidityDate]='" & DateSql & "' end "
                            cmd.ExecuteNonQuery()
                            '********************************************************************
                            'CORRECTED DEPRECIATION
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Depreciation]=[OCBS_Booked_Before]-[ValueAsOfDate] where [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            '********************************************************************
                            'Update OCBSbooked Later for FIXED Assets
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[OCBS_Booked_Before] where [AssetType]='FIXED' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            'Update OCBSbooked Later for CURRENT Assets
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[OCBS_Booked_Before]+[Apreciation]-[Depreciation] where [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            '********************************************************************
                            'CORRECTED OCBS BOOKED LATER and APPRECIATION/DEPRECIATION
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[ValueAsOfDate] where [OCBS_Booked_Later]< [ValueAsOfDate] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Apreciation]=0,[Depreciation]=[OCBS_Booked_Before]-[OCBS_Booked_Later] where [OCBS_Booked_Before]> [OCBS_Booked_Later] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Apreciation]=[OCBS_Booked_Later]-[OCBS_Booked_Before],[Depreciation]=0 where [OCBS_Booked_Before] <= [OCBS_Booked_Later] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()
                            '********************************************************************
                            'Insert to SECURITIES Bookings with Appreciations and Depreciations - DELETE if Data are present
                            cmd.CommandText = "DELETE FROM [SECURITIES_BOOKINGS] where [BookingDate]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            'Appreciations
                            Me.QueryText = "Select * from [SECURITIES_LIQUIDITYRESERVE] where [Apreciation]<>0 and [LiquidityDate]='" & DateSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    Dim BookingText As String = "Appreciation for Security ISIN Code: " & dt.Rows.Item(i).Item("ISIN_Code") & " - " & dt.Rows.Item(i).Item("SecurityName")
                                    cmd.CommandText = "INSERT INTO [SECURITIES_BOOKINGS] ([BookingDate],[ValueDate],[Reference],[Ccy],[Debit-Appreciation],[Credit-Depreciation],[BookingText]) Values ('" & DateSql & "',' " & DateSql & "','" & dt.Rows.Item(i).Item("ISIN_Code") & "','EUR'," & Str(dt.Rows.Item(i).Item("Apreciation")) & "," & Str(dt.Rows.Item(i).Item("Depreciation")) & ",' " & BookingText & "')"
                                    cmd.ExecuteNonQuery()
                                Next
                            End If
                            'Depreciations
                            Me.QueryText = "Select * from [SECURITIES_LIQUIDITYRESERVE] where [Depreciation]<>0 and [LiquidityDate]='" & DateSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    Dim BookingText As String = "Depreciation for Security ISIN Code: " & dt.Rows.Item(i).Item("ISIN_Code") & " - " & dt.Rows.Item(i).Item("SecurityName")
                                    cmd.CommandText = "INSERT INTO [SECURITIES_BOOKINGS] ([BookingDate],[ValueDate],[Reference],[Ccy],[Debit-Appreciation],[Credit-Depreciation],[BookingText]) Values ('" & DateSql & "',' " & DateSql & "','" & dt.Rows.Item(i).Item("ISIN_Code") & "','EUR'," & Str(dt.Rows.Item(i).Item("Apreciation")) & "," & Str(dt.Rows.Item(i).Item("Depreciation")) & ",' " & BookingText & "')"
                                    cmd.ExecuteNonQuery()
                                Next
                            End If
                            'Insert to SECURITIES DEPRECIATIONS Table with the new Data - DELETE DATA if Present
                            cmd.CommandText = "DELETE FROM [SECURITIES_DEPRECIATIONS] where [Date]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "INSERT INTO [SECURITIES_DEPRECIATIONS]([Date],[ISIN_Code],[Name],[Ccy],[Depreciation_Type],[Booked_Depreciation],[Actual_Depreciation],[Depreciation],[Appreciation],[OCBS_Booked_Before],[OCBS_Booked_Later]) Select [LiquidityDate],[ISIN_Code],[SecurityName],[Ccy],[AssetType],[Booked_Depreciation],[Actual_Depreciation],[Depreciation],[Apreciation],[OCBS_Booked_Before],[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                            cmd.ExecuteNonQuery()
                            'Update Client Nr.
                            cmd.CommandText = "UPDATE A SET A.[ClientNr]=B.[ClientNr] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_OUR] B on A.[ContractNrOCBS]=B.[ContractNrOCBS] where [LiquidityDate]='" & DateSql & "'"
                            cmd.ExecuteNonQuery()

                        Else 'DailyPrice Date not exists
                            MessageBox.Show("Unable to proceed with the creation of the Liquidity reserve for the given Date!" & vbNewLine & "Unable to find the Dailyprice Sheet for the given Date" & vbNewLine & "Please import the DailyPrice Sheet for the requested Date!", "DAILYPRICE SHEET NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Else 'Liquidity Date exists
                        If MessageBox.Show("The Liquidity reserve Date is present in the current Table" & vbNewLine & "Should the Liquidity reserve be re-created for the given Date?", "LIQUIDITY RESERVE PRESENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            'Check if DailyPrice exists with the same liquidity date
                            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DateSql & "' "
                            Dim resultDP As String = cmd.ExecuteScalar
                            'DailyPrice Date exists
                            If resultDP <> "" Then
                                '*******************************************************************************************************
                                'Delete Previus Data
                                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                                SplashScreenManager.Default.SetWaitFormCaption("Delete Previus Data")
                                cmd.CommandText = "DELETE FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "DELETE [SECURITIES_DEPRECIATIONS] where [Date]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                '*******************************************************************************************************
                                'Define Securities Validity based on the expiry Date and Liquidity Reserve creation Date
                                SplashScreenManager.Default.SetWaitFormCaption("Define Securities Validity based on the expiry Date and Liquidity Reserve creation Date")
                                cmd.CommandText = "SELECT [MaturityDate] from [SECURITIES_OUR] Begin UPDATE [SECURITIES_OUR] set [STATUS]='ACTIVE' where [MaturityDate]>'" & DateSql & "' end Begin UPDATE [SECURITIES_OUR] set [STATUS]='EXPIRED' where [MaturityDate]<='" & DateSql & "' end "
                                cmd.ExecuteNonQuery()
                                'Insert to Liquidity Reserve the Securities from Table SECURITIES_OUR
                                SplashScreenManager.Default.SetWaitFormCaption("Insert to Liquidity Reserve the Securities from Table SECURITIES_OUR")
                                cmd.CommandText = "INSERT INTO [SECURITIES_LIQUIDITYRESERVE]([ISIN_Code],[SecurityName],[Ccy],[PrincipalEuroAmt],[Purchase_price],[Amt_Paid],[ContractNrOCBS],[TradeDate],[StartDate],[MaturityDate],[Sektor],[SektorCountry],[AssetType]) SELECT [ISIN],[SecurityName],[Currency],[PrincipalEuroAmt],[Purchase_Price],[Amt_Paid_Eur],[ContractNrOCBS],[TradeDate],[StartDate],[MaturityDate],[Sektor],[SektorCountry],[AssetType] from [SECURITIES_OUR] where [STATUS]='ACTIVE'"
                                cmd.ExecuteNonQuery()
                                'Update [LiquidityCreationDate] and [LiquidityDate]
                                SplashScreenManager.Default.SetWaitFormCaption("Update [LiquidityCreationDate] and [LiquidityDate]")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [LiquidityCreationDate]=' " & dsql & "',[LiquidityDate]=' " & DateSql & "' where [LiquidityCreationDate] is NULL "
                                cmd.ExecuteNonQuery()
                                '****************************************************************
                                '************SONDERFALL*****3 BUBA BONDS*****Amount Paid=Nominal
                                'cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Amt_Paid]=[PrincipalEuroAmt]  where [ISIN_Code] in ('DE0001119931A','DE0001119931B','DE0001119956') and [LiquidityDate]=' " & DateSql & "' "
                                'cmd.ExecuteNonQuery()
                                '****************************************************************
                                '****************************************************************
                                'Update Data from DailyPrice
                                SplashScreenManager.Default.SetWaitFormCaption("Update Data from DailyPrice")
                                cmd.CommandText = "UPDATE A SET A.[RIC]=B.[RIC],A.[Market_Price]=B.[Market_Price],A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon],A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield],A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating],A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DailyPrice] B ON A.[ISIN_Code]=B.[ISIN_Code] where A.[LiquidityDate]=B.[Date] and A.[Market_Price] is NULL "
                                cmd.ExecuteNonQuery()
                                'Update Start of Year Price
                                'Get Min Date in current year
                                SplashScreenManager.Default.SetWaitFormCaption("Update Start of Year Price-Get Min Date in current year")
                                cmd.CommandText = "Select Min([Date]) from [SECURITIES_DailyPrice] where Datepart(year,[Date])='" & DateYearSql & "'"
                                Dim MinDateDailyPrice As Date = cmd.ExecuteScalar
                                Dim SqlMinDateDailyPrice As String = MinDateDailyPrice.ToString("yyyyMMdd")
                                'Select Minimum DailyPrice Date in the specified year
                                SplashScreenManager.Default.SetWaitFormCaption("Select Minimum DailyPrice Date in the specified year")
                                Me.QueryText = "Select * from [SECURITIES_DailyPrice] where [Date]='" & SqlMinDateDailyPrice & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    Dim MinDate As Date = dt.Rows.Item(i).Item("Date")
                                    Dim SqlDate As String = MinDate.ToString("yyyyMMdd")
                                    cmd.CommandText = "UPDATE A SET A.[StartofYear_price]=B.[Market_Price] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DailyPrice] B ON A.[ISIN_Code]=B.[ISIN_Code] where A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[StartofYear_price] is NULL "
                                    cmd.ExecuteNonQuery()
                                Next
                                'Calculate and Update AmtValueAsOfDate
                                SplashScreenManager.Default.SetWaitFormCaption("Calculate and Update AmtValueAsOfDate")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [ValueAsOfDate]=Round([PrincipalEuroAmt]*[Market_Price]/100,2) where [LiquidityDate]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                'Update Data from Accrued Interest Analysis
                                SplashScreenManager.Default.SetWaitFormCaption("Update Data from Accrued Interest Analysis")
                                cmd.CommandText = "UPDATE A SET A.[Current Interest Rate]=B.[Current Interest Rate],A.[Current Interest Coupon Period Start Date]=B.[Current Interest Coupon Period Start Date],A.[Current Interest Coupon Period End Date]=B.[Current Interest Coupon Period End Date],A.[Accrued Interest Coupon Org Ccy]=B.[Accrued Interest Coupon Org Ccy],A.[Accrued Interest Coupon EUR Equ]=B.[Accrued Interest Coupon EUR Equ],A.[Interest Coupon amount Org Ccy]=B.[Interest Coupon amount Org Ccy],A.[Interest Coupon Amount EUR Equ]=B.[Interest Coupon Amount EUR Equ] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[ContractNrOCBS]=B.[Contract] where A.[LiquidityDate]=B.[Datadate] and A.[LiquidityDate]='" & DateSql & "' and B.[Class] in ('Assets') and A.[Current Interest Rate] is NULL "
                                cmd.ExecuteNonQuery()
                                'Get Depreciations from Depreciations Table
                                'Get Max Date from Depreciations Table
                                SplashScreenManager.Default.SetWaitFormCaption("Get Depreciations from Depreciations Table-Get Max Date from Depreciations Table")
                                cmd.CommandText = "Select Max([Date]) as MaxDate from [SECURITIES_DEPRECIATIONS]"
                                Dim MaxDateSecuritiesDepreciation As Date = cmd.ExecuteScalar
                                Dim SqlMaxDateSecuritiesDepreciation As String = MaxDateSecuritiesDepreciation.ToString("yyyyMMdd")
                                'Fixed Assets
                                SplashScreenManager.Default.SetWaitFormCaption("Fixed Assets")
                                Me.QueryText = "Select * from [SECURITIES_DEPRECIATIONS] where [Depreciation_Type]='FIXED' and [Date]='" & SqlMaxDateSecuritiesDepreciation & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    Dim MaxDate As Date = dt.Rows.Item(i).Item("Date")
                                    Dim SqlDate As String = MaxDate.ToString("yyyyMMdd")

                                    cmd.CommandText = "UPDATE A  SET A.[Booked_Depreciation]=B.[Booked_Depreciation],A.[OCBS_Booked_Before]=B.[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DEPRECIATIONS] B ON A.[ISIN_Code]=B.[ISIN_Code] and A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[Booked_Depreciation] is NULL "
                                    cmd.ExecuteNonQuery()
                                Next
                                'Current Assets
                                SplashScreenManager.Default.SetWaitFormCaption("Current Assets")
                                Me.QueryText = "Select * from [SECURITIES_DEPRECIATIONS] where [Depreciation_Type]='CURRENT' and [Date]='" & SqlMaxDateSecuritiesDepreciation & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                For i = 0 To dt.Rows.Count - 1
                                    Dim MaxDate As Date = dt.Rows.Item(i).Item("Date")
                                    Dim SqlDate As String = MaxDate.ToString("yyyyMMdd")

                                    cmd.CommandText = "UPDATE A  SET A.[Booked_Depreciation]=B.[Booked_Depreciation],A.[OCBS_Booked_Before]=B.[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_DEPRECIATIONS] B ON A.[ISIN_Code]=B.[ISIN_Code] and A.[LiquidityDate]='" & DateSql & "' and B.[Date]='" & SqlDate & "' and A.[Booked_Depreciation] is NULL "
                                    cmd.ExecuteNonQuery()
                                Next
                                'Set all others to Zero
                                SplashScreenManager.Default.SetWaitFormCaption("Set all others to Zero")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Booked_Depreciation]=0 where [Booked_Depreciation] is NULL "
                                cmd.ExecuteNonQuery()
                                'Get the OCBS Booked before if is NULL
                                SplashScreenManager.Default.SetWaitFormCaption("Get the OCBS Booked before if is NULL")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Before]=[Amt_Paid]-[Booked_Depreciation] where [OCBS_Booked_Before] is NULL "
                                cmd.ExecuteNonQuery()
                                'Get the actual Depreciations
                                SplashScreenManager.Default.SetWaitFormCaption("Get the actual Depreciations")
                                cmd.CommandText = "SELECT [Amt_Paid],[ValueAsOfDate] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Actual_Depreciation]=[Amt_Paid]-[ValueAsOfDate] where [Amt_Paid]>[ValueAsOfDate] and [LiquidityDate]='" & DateSql & "' end Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Actual_Depreciation]=0 where [Amt_Paid]<=[ValueAsOfDate] and [LiquidityDate]='" & DateSql & "' end "
                                cmd.ExecuteNonQuery()
                                'Update Depreciation/Appreciation Field only for Current Assets
                                SplashScreenManager.Default.SetWaitFormCaption("Update Depreciation/Appreciation Field only for Current Assets")
                                cmd.CommandText = "SELECT [Booked_Depreciation],[Actual_Depreciation] from [SECURITIES_LIQUIDITYRESERVE] where [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "' Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Depreciation]=[Actual_Depreciation]-[Booked_Depreciation],[Apreciation]=0 where [Booked_Depreciation]<[Actual_Depreciation] and [AssetType]='CURRENT'and [LiquidityDate]='" & DateSql & "' end Begin UPDATE [SECURITIES_LIQUIDITYRESERVE] set [Apreciation]=[Booked_Depreciation]-[Actual_Depreciation],[Depreciation]=0 where [Booked_Depreciation]>[Actual_Depreciation] and [AssetType]='CURRENT'and [LiquidityDate]='" & DateSql & "' end "
                                cmd.ExecuteNonQuery()
                                'Update OCBSbooked Later for FIXED Assets
                                SplashScreenManager.Default.SetWaitFormCaption("Update OCBSbooked Later for FIXED Assets")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[OCBS_Booked_Before] where [AssetType]='FIXED' and [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                'Update OCBSbooked Later for CURRENT Assets
                                SplashScreenManager.Default.SetWaitFormCaption("Update OCBSbooked Later for CURRENT Assets")
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[OCBS_Booked_Before]+[Apreciation]-[Depreciation] where [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                '********************************************************************
                                'CORRECTED OCBS BOOKED LATER and APPRECIATION/DEPRECIATION
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [OCBS_Booked_Later]=[ValueAsOfDate] where [OCBS_Booked_Later]< [ValueAsOfDate] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Apreciation]=0,[Depreciation]=[OCBS_Booked_Before]-[OCBS_Booked_Later] where [OCBS_Booked_Before]> [OCBS_Booked_Later] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [SECURITIES_LIQUIDITYRESERVE] SET [Apreciation]=[OCBS_Booked_Later]-[OCBS_Booked_Before],[Depreciation]=0 where [OCBS_Booked_Before] <= [OCBS_Booked_Later] and [AssetType]='CURRENT' and [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                '********************************************************************
                                'Insert to SECURITIES Bookings with Appreciations and Depreciations - DELETE if Data are present
                                SplashScreenManager.Default.SetWaitFormCaption("Insert to SECURITIES Bookings with Appreciations and Depreciations - DELETE if Data are present")
                                cmd.CommandText = "DELETE FROM [SECURITIES_BOOKINGS] where [BookingDate]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                'Appreciations
                                SplashScreenManager.Default.SetWaitFormCaption("Appreciations")
                                Me.QueryText = "Select * from [SECURITIES_LIQUIDITYRESERVE] where [Apreciation]<>0 and [LiquidityDate]='" & DateSql & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                If dt.Rows.Count > 0 Then
                                    For i = 0 To dt.Rows.Count - 1
                                        Dim BookingText As String = "Appreciation for Security ISIN Code: " & dt.Rows.Item(i).Item("ISIN_Code") & " - " & dt.Rows.Item(i).Item("SecurityName")
                                        cmd.CommandText = "INSERT INTO [SECURITIES_BOOKINGS] ([BookingDate],[ValueDate],[Reference],[Ccy],[Debit-Appreciation],[Credit-Depreciation],[BookingText]) Values ('" & DateSql & "',' " & DateSql & "','" & dt.Rows.Item(i).Item("ISIN_Code") & "','EUR'," & Str(dt.Rows.Item(i).Item("Apreciation")) & "," & Str(dt.Rows.Item(i).Item("Depreciation")) & ",'" & BookingText & "')"
                                        cmd.ExecuteNonQuery()
                                    Next
                                End If
                                'Depreciations
                                SplashScreenManager.Default.SetWaitFormCaption("Depreciations")
                                Me.QueryText = "Select * from [SECURITIES_LIQUIDITYRESERVE] where [Depreciation]<>0 and [LiquidityDate]='" & DateSql & "'"
                                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                dt = New DataTable()
                                da.Fill(dt)
                                If dt.Rows.Count > 0 Then
                                    For i = 0 To dt.Rows.Count - 1
                                        Dim BookingText As String = "Depreciation for Security ISIN Code: " & dt.Rows.Item(i).Item("ISIN_Code") & " - " & dt.Rows.Item(i).Item("SecurityName")
                                        cmd.CommandText = "INSERT INTO [SECURITIES_BOOKINGS] ([BookingDate],[ValueDate],[Reference],[Ccy],[Debit-Appreciation],[Credit-Depreciation],[BookingText]) Values ('" & DateSql & "',' " & DateSql & "','" & dt.Rows.Item(i).Item("ISIN_Code") & "','EUR'," & Str(dt.Rows.Item(i).Item("Apreciation")) & "," & Str(dt.Rows.Item(i).Item("Depreciation")) & ",'" & BookingText & "')"
                                        cmd.ExecuteNonQuery()
                                    Next
                                End If
                                'Insert to SECURITIES DEPRECIATIONS Table with the new Data - DELETE DATA if Present
                                SplashScreenManager.Default.SetWaitFormCaption("Insert to SECURITIES DEPRECIATIONS Table with the new Data - DELETE DATA if Present")
                                cmd.CommandText = "DELETE FROM [SECURITIES_DEPRECIATIONS] where [Date]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "INSERT INTO [SECURITIES_DEPRECIATIONS]([Date],[ISIN_Code],[Name],[Ccy],[Depreciation_Type],[Booked_Depreciation],[Actual_Depreciation],[Depreciation],[Appreciation],[OCBS_Booked_Before],[OCBS_Booked_Later]) Select [LiquidityDate],[ISIN_Code],[SecurityName],[Ccy],[AssetType],[Booked_Depreciation],[Actual_Depreciation],[Depreciation],[Apreciation],[OCBS_Booked_Before],[OCBS_Booked_Later] from [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & DateSql & "' "
                                cmd.ExecuteNonQuery()
                                'Update Client Nr.
                                cmd.CommandText = "UPDATE A SET A.[ClientNr]=B.[ClientNr] from [SECURITIES_LIQUIDITYRESERVE] A INNER JOIN [SECURITIES_OUR] B on A.[ContractNrOCBS]=B.[ContractNrOCBS] where [LiquidityDate]='" & DateSql & "'"
                                cmd.ExecuteNonQuery()
                                SplashScreenManager.CloseForm(False)
                            Else 'DailyPrice Date not exists
                                MessageBox.Show("Unable to proceed with the creation of the Liquidity reserve for the given Date!" & vbNewLine & "Unable to find the Dailyprice Sheet for the given Date" & vbNewLine & "Please import the DailyPrice Sheet for the requested Date!", "DAILYPRICE SHEET NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            End If

                        End If
                    End If
                    'Connection close
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
                    Me.SecuritiesLiquidBaseView.ExpandAllGroups()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                SplashScreenManager.CloseForm(False)
                Me.SECURITIES_LIQUIDITYRESERVETableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_LIQUIDITYRESERVE)
                Me.SecuritiesLiquidBaseView.ExpandAllGroups()
            End Try
        Else
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show("Unable to create Securities Liquidity Reserve", "ERROR - USER IS NOT AUTHORIZED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If

    End Sub

    Private Sub Securities_LiquidityReserve_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Securities_LiquidityReserve_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If Me.SecuritiesLiquidDetailView_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.SecuritiesLiquidDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.PrintCardCaption = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.SecuritiesLiquidDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.SecuritiesLiquidDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.SecuritiesLiquidDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        End If

    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("CCB Frankfurt - SECURITIES LIQUIDITY RESERVE" & vbNewLine & "Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "CCB Frankfurt - SECURITIES LIQUIDITY RESERVE" & vbNewLine & "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "CCB Frankfurt - SECURITIES LIQUIDITY RESERVE"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        'e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        'Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        'e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

    Private Sub SecuritiesReport_btn_Click(sender As Object, e As EventArgs) Handles SecuritiesReport_btn.Click
        'Get the max Date in Liquidity reserve
        cmd.CommandText = "Select Max([LiquidityDate]) from [SECURITIES_LIQUIDITYRESERVE]"
        cmd.Connection.Open()
        Dim LiqDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()

        ' Create a report instance.
        Dim report As New LiquidityReserveXtraReport


        ' Create a parameter and specify its name.
        Dim param1 As New Parameter()
        param1.Name = "LiquidityReserveDate"

        ' Specify other parameter properties.
        param1.Type = GetType(System.DateTime)
        param1.Value = LiqDate
        param1.Description = "Liquidity Reserve Date: "
        param1.Visible = True

        ' Add the parameter to the report.
        report.Parameters.Add(param1)
        report.Parameters("LiquidityReserveDate").Value = LiqDate

        ' Specify the report's filter string.
        report.FilterString = "[LiquidityDate] = [Parameters.LiquidityReserveDate]"

        ' Force the report creation without previously 
        ' requesting the parameter value from end-users.
        report.RequestParameters = False


        ' Show the parameter's value on a Report Header band.
        'Dim label As New XRLabel()
        'label.DataBindings.Add(New XRBinding(param1, "Text", "Exchange Rate Date: {0}"))
        'Dim reportHeader As New ReportHeaderBand()
        'reportHeader.Controls.Add(label)
        'report.Bands.Add(reportHeader)

        ' Assign the report to a ReportPrintTool,
        ' to hide the Parameters panel,
        ' and show the report's print preview.
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = True
        pt.ShowRibbonPreview(UserLookAndFeel.Default)

    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl IsNot GridControl2 Then
            Return
        End If

        Dim info As ToolTipControlInfo = Nothing
        Dim view As GridView = TryCast(GridControl2.GetViewAt(e.ControlMousePosition), GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        If hi.HitTest = GridHitTest.Column AndAlso hi.Column IsNot Nothing Then
            If hi.Column.FieldName = "Actual_Depreciation" Then
                Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                Dim text As String = "The Actual Depreciation is calculated as follows:" & vbNewLine & "FOR CURRENT ASSETS:" & vbNewLine & "If Amount_Paid>ValueAsOfDate then Actual Depreciation=Amount_Paid - ValueAsOfDate" & vbNewLine _
                                     & "If Amount_Paid<ValueAsOfDate the Actual Depreciation=0" & vbNewLine & vbNewLine _
                                     & "FOR FIXED ASSETS:" & vbNewLine _
                                     & "The Depreciation is fixed and therefore no calculation will occur"
                info = New ToolTipControlInfo(o, text)

            ElseIf hi.Column.FieldName = "OCBS_Booked_Later" Then
                Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                Dim text As String = "OCBS Booked Later is calculated as follows:" & vbNewLine & "FOR CURRENT ASSETS:" & vbNewLine & "OCBS Booked before+Appreciation-Depreciation" & vbNewLine & vbNewLine _
                                     & "FOR FIXED ASSETS:" & vbNewLine _
                                     & "OCBS Booked later=OCBS booked before"
                info = New ToolTipControlInfo(o, text)

            ElseIf hi.Column.FieldName = "Depreciation" OrElse hi.Column.FieldName = "Apreciation" Then
                Dim o As Object = hi.Column.FieldName + hi.Column.ToString()
                Dim text As String = "The Apreciation and Depreciation is calculated as follows:" & vbNewLine & "ONLY FOR CURRENT ASSETS:" & vbNewLine & "If Booked_Depreciation<Actual_Depreciation then Depreciation=Actual_Depreciation-Booked_Depreciation,Apreciation=0" & vbNewLine _
                                     & "If Booked Depreciation>Actual Depreciation] then Depreciation=0,Apreciation=Booked_Depreciation-Actual_Depreciation" & vbNewLine & vbNewLine _
                                     & "FOR FIXED ASSETS:" & vbNewLine _
                                     & "Apreciation and Depreciation are 0"
                info = New ToolTipControlInfo(o, text)

            End If

        End If
        If info IsNot Nothing Then
            e.Info = info
        End If
    End Sub

    

   
End Class