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
Public Class FxCreditEquivalentCalculationRealTime
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date
    Dim NominalAmount As Double = 0
    Dim td As Date = Today
    Dim tdsql As String = td.ToString("yyyyMMdd")
    Dim MaxCCBguaranteesDate As Date = Today
    Dim SqlMaxCCBguaranteesDate As String = MaxCCBguaranteesDate.ToString("yyyyMMdd")

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

    Private Sub FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TreasuryDataSet)

    End Sub

    Private Sub FxCreditEquivalentCalculationRealTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************

        'Get Max Risk Date
        'cmd.CommandText = "SELECT MAX([RiskDate]) FROM [FX CREDIT EQUIVALENT Basic REAL TIME] "
        'Dim MaxFxDate As Date = cmd.ExecuteScalar
        'Dim SqlMaxFxDate As String = MaxFxDate.ToString("yyyyMMdd")
        Me.FxDateEdit.Text = Today
        'cmd.CommandText = "SELECT MAX([RiskDate]) FROM [GUARANTEE_EXPOSURE]"
        'MaxCCBguaranteesDate = cmd.ExecuteScalar
        'SqlMaxCCBguaranteesDate = MaxCCBguaranteesDate.ToString("yyyyMMdd")

        'cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "'"
        'Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
        'cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic REAL TIME] where [ClientGroup]='1000' and [RiskDate]='" & SqlMaxFxDate & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "') QUERY"
        'Me.CCB_Fx_Credit_Equiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
        cmd.Connection.Close()
        
        'Me.OWN_CURRENCIESTableAdapter.Fill(Me.TreasuryDataSet.OWN_CURRENCIES)
        'Me.CUSTOMER_RATINGTableAdapter.Fill(Me.TreasuryDataSet.CUSTOMER_RATING)
        'Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.Fill(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Details_REAL_TIME)
        'Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.Fill(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Basic_REAL_TIME)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Add new FX Deal
       
        If e.Button.ButtonType = NavigatorButtonType.Custom Then
            If e.Button.Hint = "Add new FX Deal" Then
                Me.LoadCurrentDateData_btn.PerformClick()
                Me.LayoutControl1.Visible = False
                Me.StartDate_DateEdit.Text = Today

            End If
        End If
    End Sub

    Private Sub ClientGroup_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientGroup_LookUpEdit.EditValueChanged
        Me.ClientName_lbl.Text = Me.ClientGroup_LookUpEdit.GetColumnValue("ClientName").ToString
        Me.ClientGroupNr_lbl.Text = Me.ClientGroup_LookUpEdit.GetColumnValue("ClientGroup").ToString
        Me.ClientGroupName_lbl.Text = Me.ClientGroup_LookUpEdit.GetColumnValue("ClientGroupName").ToString
    End Sub

    Private Sub Currencies_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Currencies_LookUpEdit.EditValueChanged
        Me.CurrencyName_lbl.Text = Me.Currencies_LookUpEdit.GetColumnValue("CURRENCY NAME").ToString
    End Sub

    Private Sub AddNewFxDeal_btn_Click(sender As Object, e As EventArgs) Handles AddNewFxDeal_btn.Click
        If Me.ClientGroupNr_lbl.Text <> "" AndAlso Me.CurrencyName_lbl.Text <> "" AndAlso NominalAmount > 0 AndAlso IsDate(Me.StartDate_DateEdit.Text) = True AndAlso IsDate(Me.FinalMaturityDate_DateEdit.Text) = True Then
            Dim sd As Date = Me.StartDate_DateEdit.Text
            Dim sdsql As String = sd.ToString("yyyyMMdd")
            Dim fd As Date = Me.FinalMaturityDate_DateEdit.Text
            Dim fdsql As String = fd.ToString("yyyyMMdd")


            If fd > sd Then
                Dim ClientNr As String = Me.ClientGroup_LookUpEdit.Text
                Dim ClientName As String = Me.ClientName_lbl.Text
                Dim ClientGroupNr As Double = Me.ClientGroupNr_lbl.Text
                Dim ClientGroupName As String = Me.ClientGroupName_lbl.Text
                Dim OrigCur As String = Me.Currencies_LookUpEdit.Text
                'Mounth to event calculation
                'Dim MonthToEvent As Double = Math.Round(DateDiff(DateInterval.Day, td, fd) / 30, 1)
                'Calculating only days
                Dim MonthToEvent As Double = DateDiff(DateInterval.Day, td, fd)
                Try
                    cmd.Connection.Open()
                    cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details REAL TIME]([Client_No],[Client_Name],[ClientGroup],[ClientGroupName],[StartDate],[Final_Maturity_Date],[MonthToEvent],[OrgCcy],[OrgCcyAmount],[RiskDate],[InputType]) Values( ' " & ClientNr & "','" & ClientName & "',' " & Str(ClientGroupNr) & " ','" & ClientGroupName & "',' " & sdsql & " ','" & fdsql & " ',' " & Str(MonthToEvent) & " ','" & OrigCur & " ',' " & Str(NominalAmount) & "','" & tdsql & " ','M') "
                    cmd.ExecuteNonQuery()
                    'Get Exchange Rates
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [ExchangeRate]=1 where [OrgCcy]='EUR' and [ExchangeRate] is NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select Max([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS]"
                    Dim ed As Date = cmd.ExecuteScalar
                    Dim edsql As String = ed.ToString("yyyyMMdd")
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[ExchangeRate] is NULL and B.[EXCHANGE RATE DATE]='" & edsql & "' and A.[InputType]='M' "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [EURequ]=Round([OrgCcyAmount]/[ExchangeRate],2) where [RiskDate]='" & tdsql & "' and [InputType]='M'"
                    cmd.ExecuteScalar()
                    'cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & tdsql & "' begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.02 where [MonthToEvent]<=12 and [RiskDate]='" & tdsql & "' and [InputType]='M' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.05 where [MonthToEvent]>12 and [MonthToEvent]<=24 and [RiskDate]='" & tdsql & "' and [InputType]='M'end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.08 where [MonthToEvent]>24 and [RiskDate]='" & tdsql & "'and [InputType]='M' end "
                    'cmd.ExecuteNonQuery()

                    'Set correct MonthToEvent=Days
                    cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [MonthToEvent]=(Case when DATENAME(dw,[Final_Maturity_Date]) in ('Monday') then [MonthToEvent]-2 else [MonthToEvent])end) where  [RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Set correct percentage
                    cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & tdsql & "' begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.02 where [MonthToEvent]<=365 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "' and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.05 where [MonthToEvent]>365 and [MonthToEvent]<=730 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "' and [RiskDate]='" & tdsql & "'end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.08 where [MonthToEvent]>730 and [MonthToEvent]<=1095 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "' and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.11 where [MonthToEvent]>1095 and [MonthToEvent]<=1460 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "' and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.14 where [MonthToEvent]>1460 and [MonthToEvent]<=1825 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "' and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.17 where [MonthToEvent]>1825 and [MonthToEvent]<=2190 and [Final_Maturity_Date]<> '" & tdsql & "' and [StartDate]<= '" & tdsql & "' and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.20 where [MonthToEvent]>2190 and [MonthToEvent]<=2555 and [StartDate]<= '" & tdsql & "' and [Final_Maturity_Date]<> '" & tdsql & "'  and [RiskDate]='" & tdsql & "' end"
                    cmd.ExecuteNonQuery()

                    'cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & tdsql & "' begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.02 where [MonthToEvent]<=371 and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.05 where [MonthToEvent]>371 and [MonthToEvent]<=742 and [RiskDate]='" & tdsql & "'end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.08 where [MonthToEvent]>742 and [MonthToEvent]<=1113 and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.11 where [MonthToEvent]>1113 and [MonthToEvent]<=1484 and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.14 where [MonthToEvent]>1484 and [MonthToEvent]<=1855 and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.17 where [MonthToEvent]>1855 and [MonthToEvent]<=2226 and [RiskDate]='" & tdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.20 where [MonthToEvent]>2226 and [MonthToEvent]<=2597 and [RiskDate]='" & tdsql & "' end"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [EURequCalculated]=[EURequ]*[PercentCalculation] where [RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A set A.[IdFX_CRED_EQU_BASIC]=B.[ID] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [FX CREDIT EQUIVALENT Basic REAL TIME] B ON A.[ClientGroup]=B.[ClientGroup] where  A.[RiskDate]='" & tdsql & "' and B.[RiskDate]='" & tdsql & "' and A.[InputType]='M'"
                    cmd.ExecuteNonQuery()
                    'Update Sum Fields
                    cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequ]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & tdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & tdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.02 and [RiskDate]='" & tdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.05 and [RiskDate]='" & tdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.08 and [RiskDate]='" & tdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & tdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()

                    MessageBox.Show("New FX Deal inserted!", "NEW FX DEAL SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    ClientGroupNr = Nothing
                    ClientGroupName = Nothing
                    OrigCur = Nothing
                    Me.NominalAmount_TextEdit.Text = 0
                    NominalAmount = 0
                    'Me.StartDate_DateEdit.EditValue = Nothing
                    Me.FinalMaturityDate_DateEdit.EditValue = Nothing

                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Exit Try
                End Try
            Else
                MessageBox.Show("The final Maturity date must be higher than the Start Date", "Wrong Dates", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.StartDate_DateEdit.EditValue = Nothing
                Me.FinalMaturityDate_DateEdit.EditValue = Nothing
            End If
        End If
    End Sub

   
    Private Sub NominalAmount_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NominalAmount_TextEdit.EditValueChanged
        Me.NominalAmount = Me.NominalAmount_TextEdit.Text
    End Sub

    Private Sub LoadCurrentDateData_btn_Click(sender As Object, e As EventArgs) Handles LoadCurrentDateData_btn.Click

        Try
            Me.GridControl1.DataSource = Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandTimeout = 50000
            'cmd.CommandText = "Select [RiskDate] from [FX CREDIT EQUIVALENT Basic REAL TIME] where [RiskDate]='" & tdsql & "'"
            'Dim t As String = cmd.ExecuteScalar()
            'If IsNothing(t) = False Then
            'Me.FxDateEdit.Text = Today
            'Me.LoadData_btn.PerformClick()
            'SplashScreenManager.CloseForm(False)
            'Else
            cmd.CommandText = "Select Max([RiskDate]) from [FX CREDIT EQUIVALENT Basic]"
            Dim md As Date = cmd.ExecuteScalar
            Dim mdsql As String = md.ToString("yyyyMMdd")
            Dim sd As Date = Me.FxDateEdit.Text
            Dim sdsql As String = sd.ToString("yyyyMMdd")
            'cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Basic REAL TIME]([RiskDate],[ClientGroup],[ClientGroupName],[SumEURequ],[CreditEquivelantAmount],[CreditEquivelantAmountTill1Jear],[CreditEquivelantAmountOver1Till2Years],[CreditEquivelantAmountOver2Years])select '" & tdsql & "',[ClientGroup],[ClientGroupName],[SumEURequ],[CreditEquivelantAmount],[CreditEquivelantAmountTill1Jear],[CreditEquivelantAmountOver1Till2Years],[CreditEquivelantAmountOver2Years] from [FX CREDIT EQUIVALENT Basic] where [RiskDate]='" & mdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Basic REAL TIME] set [RiskDate]='" & tdsql & "' where [RiskDate]='" & mdsql & "' "
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details REAL TIME]([Client_No],[Client_Name],[ClientGroup],[ClientGroupName],[StartDate],[Final_Maturity_Date],[MonthToEvent],[YearToEvent],[OrgCcy],[OrgCcyAmount],[EURequ],[PercentCalculation],[EURequCalculated],[RiskDate])SELECT [Counterparty_No],[Counterparty_Name],[ClientGroup],[ClientGroupName],[StartDate],[Final_Maturity_Date],[MonthToEventStartDate],[YearToEvent],[OrgCcy],[OrgCcyAmount],[EURequ],[PercentCalculation],[EURequCalculated],'" & tdsql & "' from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & mdsql & "' "
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [RiskDate]='" & tdsql & "' where [RiskDate]='" & mdsql & "' "
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE A set A.[IdFX_CRED_EQU_BASIC]=B.[ID] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [FX CREDIT EQUIVALENT Basic REAL TIME] B ON A.[ClientGroup]=B.[ClientGroup] where  A.[RiskDate]='" & tdsql & "' and B.[RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'NEW
            cmd.CommandText = "Delete from [FX CREDIT EQUIVALENT Details REAL TIME]"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [FX CREDIT EQUIVALENT Basic REAL TIME]"
            cmd.ExecuteNonQuery()

            'Import Data in details
            'SplashScreenManager.Default.SetWaitFormCaption("Insert Data in FX CREDIT EQUIVALENT Details REAL TIME from FX DAILY REVALUATION where DealType in (FW,SW) and MaturityDate > RiskDate for " & md)
            SplashScreenManager.Default.SetWaitFormCaption("Calculate FX CREDIT EQUIVALENT Projection for " & sd)
            'cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details REAL TIME]([ContractType],[Contract],[Client_Name],[Client_No],[TradeDate],[StartDate],[Final_Maturity_Date],[AmountType],[OrgCcy],[OrgCcyAmount],[RiskDate])SELECT [ContractType],[ContractNr],[ClientName],[ClientNo],[InputDate],[ValueDate],[MaturityDate],'Bank Buy Amount',[BuyCCY],[BuyAmount],'" & tdsql & "' from [FX DAILY REVALUATION] where [DealType] in ('FW','SW') and [MaturityDate]>[RiskDate] and [RiskDate]='" & mdsql & "'"
            'cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details REAL TIME]([Contract],[ContractType],[Client_No],[Client_Name],[ClientGroup],[ClientGroupName],[TradeDate],[StartDate],[ModifiedStartDate],[Final_Maturity_Date],[Modified_Final_Maturity_Date],[AmountType],[MonthToEventStartDate],[MonthToEvent],[YearToEvent],[OrgCcy],[OrgCcyAmount],[ExchangeRate],[EURequ],[RiskDate])Select [Contract],[ContractType],[Counterparty_No],[Counterparty_Name],[ClientGroup],[ClientGroupName],[TradeDate],[StartDate],[ModifiedStartDate],[Final_Maturity_Date],[Modified_Final_Maturity_Date],[AmountType],[MonthToEventStartDate],[MonthToEvent],[YearToEvent],[OrgCcy],[OrgCcyAmount],[ExchangeRate],[EURequ],'" & sdsql & "' FROM [FX CREDIT EQUIVALENT Details] where [Final_Maturity_Date]>[RiskDate] and [RiskDate]='" & mdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [FX CREDIT EQUIVALENT Details REAL TIME] where [Modified_Final_Maturity_Date]<=[RiskDate]"
            cmd.ExecuteScalar()

            'Update Client Group in Details
            'SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Nr. and client Group Name in FX CREDIT EQUIVALENT Details REAL TIME from CUSTOMER_RATING")
            'cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client_No]=B.[ClientNo] where A.[RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'Update Client Group in Details
            'SplashScreenManager.Default.SetWaitFormCaption("Set Client Group and Name to UNDEFINED if Client Nr is NULL")
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] SET [ClientGroup]=999999,[ClientGroupName]='UNDEFINED GROUP' where [Client_No] is NULL and [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Set Client Group=Client Nr in FX CREDIT EQUIVALENT Details REAL TIME where Client Group is NULL")
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] SET [ClientGroup]=[Client_No],[ClientGroupName]=[Client_Name]  where [ClientGroup] is NULL and [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "Select Max([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS]"
            'Dim ed As Date = cmd.ExecuteScalar
            'Dim edsql As String = ed.ToString("yyyyMMdd")
            'Update OCBS Exchange Rates-Last working day
            'SplashScreenManager.Default.SetWaitFormCaption("Update Exchange Rates in FX CREDIT EQUIVALENT Details REAL TIME")
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [ExchangeRate]=1 where [OrgCcy]='EUR' and [ExchangeRate] is NULL and [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[ExchangeRate] is NULL and B.[EXCHANGE RATE DATE]='" & edsql & "'"
            'cmd.ExecuteNonQuery()
            'Calculate EuroEquivelant
            'SplashScreenManager.Default.SetWaitFormCaption("Calculate Euro Equivalent nominal amount in FX CREDIT EQUIVALENT Details REAL TIME")
            'cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [EURequ]=Round([OrgCcyAmount]/[ExchangeRate],2) where [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteScalar()
            'Import Data in Basic
            'SplashScreenManager.Default.SetWaitFormCaption("Import Data in FX CREDIT EQUIVALENT Basic")
            cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Basic REAL TIME]([RiskDate],[ClientGroup])select [RiskDate],[ClientGroup] from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & sdsql & "' group by [RiskDate],[ClientGroup]"
            cmd.ExecuteNonQuery()
            'Update Client Group Name
            'SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Name in FX CREDIT EQUIVALENT Basic REAL TIME")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN [FX CREDIT EQUIVALENT Details REAL TIME] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            'Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details
            'SplashScreenManager.Default.SetWaitFormCaption("Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details REAL TIME")
            cmd.CommandText = "UPDATE A set A.[IdFX_CRED_EQU_BASIC]=B.[ID] from [FX CREDIT EQUIVALENT Details REAL TIME] A INNER JOIN [FX CREDIT EQUIVALENT Basic REAL TIME] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate] and A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Update ModifiedStartDate= If Trade Date=Start Date then StartDate + Next Business Day (SQL Function=GetNextWorkingDate) + 1 ELSE StartDate")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [ModifiedStartDate]=(Case when [TradeDate]=[StartDate] then dbo.GetNextWorkingDay([StartDate])+1 else [StartDate] end) where  [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Modify ModifiedStartDate= If Saturday then + 2 Days and If Sunday then + 1")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [ModifiedStartDate]=(Case when DATENAME(dw,[ModifiedStartDate]) in ('Sunday') then DATEADD(day,1,[ModifiedStartDate])when DATENAME(dw,[ModifiedStartDate]) in ('Saturday') then DATEADD(day,2,[ModifiedStartDate])else [ModifiedStartDate]end) where  [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Update ModifiedStartDate= If Modified Start Date is HOLIDAY then GetNextWorkingDate ELSE ModifiedStartDate")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [ModifiedStartDate]=dbo.GetNextWorkingDay([ModifiedStartDate]) where  [RiskDate]='" & tdsql & "' and [ModifiedStartDate] in (Select [CalendarDate] from [Calendar] where [HolidayType] in ('H'))"
            'cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Update Modified_FinalMaturityDate=If Final_Maturity_Date is MONDAY then - 3 Days else Final_Maturity_Date")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [Modified_Final_Maturity_Date]=(Case when DATENAME(dw,[Final_Maturity_Date]) in ('Monday') then [Final_Maturity_Date]-3 else [Final_Maturity_Date] end)  where  [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            'SplashScreenManager.Default.SetWaitFormCaption("Update MonthToEventStartDate to Years(NOT CONSIDERING LEAP YEARS)")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details REAL TIME] set [MonthToEventStartDate]=dbo.yearDiff([Modified_Final_Maturity_Date],[ModifiedStartDate]) where  [RiskDate]='" & tdsql & "'"
            'cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & sdsql & "' begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.02 where [MonthToEventStartDate]<=1 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [RiskDate]='" & sdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.05 where [MonthToEventStartDate]>1 and [MonthToEventStartDate]<=2 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [RiskDate]='" & sdsql & "'end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.08 where [MonthToEventStartDate]>2 and [MonthToEventStartDate]<=3 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [RiskDate]='" & sdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.11 where [MonthToEventStartDate]>3 and [MonthToEventStartDate]<=4 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [RiskDate]='" & sdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.14 where [MonthToEventStartDate]>4 and [MonthToEventStartDate]<=5 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [RiskDate]='" & sdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.17 where [MonthToEventStartDate]>5 and [MonthToEventStartDate]<=6 and [Modified_Final_Maturity_Date]<> '" & sdsql & "' and [ModifiedStartDate]<= '" & sdsql & "' and [RiskDate]='" & sdsql & "' end begin update [FX CREDIT EQUIVALENT Details REAL TIME] set [PercentCalculation]=0.20 where [MonthToEventStartDate]>6 and [MonthToEventStartDate]<=7 and [ModifiedStartDate]<= '" & sdsql & "' and [Modified_Final_Maturity_Date]<> '" & sdsql & "'  and [RiskDate]='" & sdsql & "' end"
            cmd.ExecuteNonQuery()
            'Update EURequCalculated in FX CREDIT EQUIVALENT Details and CreditRiskAmountER
            'SplashScreenManager.Default.SetWaitFormCaption("Update EURequCalculated  and CreditRiskAmountER in FX CREDIT EQUIVALENT Details REAL TIME")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details REAL TIME] set [EURequCalculated]=[EURequ]*[PercentCalculation] where [RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            'Update Sum Fields in FX CREDIT EQUIVALENT Basic
            'SplashScreenManager.Default.SetWaitFormCaption("Update Sum Fields in FX CREDIT EQUIVALENT Basic REAL TIME")
            cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequ]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & sdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & sdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.02 and [RiskDate]='" & sdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.05 and [RiskDate]='" & sdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.08 and [RiskDate]='" & sdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & sdsql & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & mdsql & "'"
            Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
            cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic REAL TIME] where [ClientGroup]='1000'  Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & mdsql & "') QUERY"
            Me.CCB_Fx_Credit_Equiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)

            'Me.FxDateEdit.Text = Today
            'Me.LoadData_btn.PerformClick()
            Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.Fill(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Details_REAL_TIME)
            Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.Fill(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Basic_REAL_TIME)
            SplashScreenManager.CloseForm(False)
            'End If
            cmd.Connection.Close()

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub ReloadList_btn_Click(sender As Object, e As EventArgs) Handles ReloadList_btn.Click
        'Get Max Date
        Me.LayoutControl1.Visible = True
        cmd.Connection.Open()
        cmd.CommandText = "SELECT MAX([RiskDate]) FROM [FX CREDIT EQUIVALENT Basic REAL TIME]"
        Dim MaxFxDate As Date = cmd.ExecuteScalar
        Me.FxDateEdit.Text = MaxFxDate
        Dim SqlMaxFxDate As String = MaxFxDate.ToString("yyyyMMdd")
        cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "'"
        Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
        cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequ]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & SqlMaxFxDate & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & SqlMaxFxDate & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [RiskDate]='" & SqlMaxFxDate & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & SqlMaxFxDate & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.02 and [RiskDate]='" & SqlMaxFxDate & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & SqlMaxFxDate & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.05 and [RiskDate]='" & SqlMaxFxDate & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & SqlMaxFxDate & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [FX CREDIT EQUIVALENT Basic REAL TIME] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details REAL TIME] where [PercentCalculation]=0.08 and [RiskDate]='" & SqlMaxFxDate & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & SqlMaxFxDate & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic REAL TIME] where [ClientGroup]='1000' and [RiskDate]='" & SqlMaxFxDate & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "') QUERY"
        Me.CCB_Fx_Credit_Equiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.TreasuryDataSet.OWN_CURRENCIES)
        Me.CUSTOMER_RATINGTableAdapter.Fill(Me.TreasuryDataSet.CUSTOMER_RATING)
        Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Details_REAL_TIME, MaxFxDate)
        Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Basic_REAL_TIME, MaxFxDate)
        cmd.Connection.Close()

    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
        Me.GridControl1.DataSource = Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMEBindingSource

        If IsDate(Me.FxDateEdit.Text) = True Then
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Dim d As Date = Me.FxDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            cmd.CommandText = "Select [RiskDate] from [FX CREDIT EQUIVALENT Basic REAL TIME] where [RiskDate]='" & dsql & "' "
            cmd.Connection.Open()
            If IsDate(cmd.ExecuteScalar) = True Then
                cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "'"
                Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic REAL TIME] where [ClientGroup]='1000' and [RiskDate]='" & dsql & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "') QUERY"
                Me.CCB_Fx_Credit_Equiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                'Load  Data
                Me.OWN_CURRENCIESTableAdapter.Fill(Me.TreasuryDataSet.OWN_CURRENCIES)
                Me.CUSTOMER_RATINGTableAdapter.Fill(Me.TreasuryDataSet.CUSTOMER_RATING)
                Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Details_REAL_TIME, d)
                Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Basic_REAL_TIME, d)
                'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            Else
                MessageBox.Show("There's no Data for the indicated Date!", "NO DATA FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'Get Max Date
                cmd.CommandText = "SELECT MAX([RiskDate]) FROM [FX CREDIT EQUIVALENT Basic REAL TIME]"
                Dim MaxFxDate As Date = cmd.ExecuteScalar
                Dim SqlMaxFxDate As String = MaxFxDate.ToString("yyyyMMdd")
                Me.FxDateEdit.Text = MaxFxDate
                cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "'"
                Me.CCB_Guarantees_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)
                cmd.CommandText = "Select Sum(s) from (SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic REAL TIME] where [ClientGroup]='1000' and [RiskDate]='" & SqlMaxFxDate & "' Union SELECT Sum([LC_Amount]) as s FROM [GUARANTEE_EXPOSURE]  where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlMaxCCBguaranteesDate & "') QUERY"
                Me.CCB_Fx_Credit_Equiv_lbl.Text = FormatNumber(cmd.ExecuteScalar, 2)

                Me.OWN_CURRENCIESTableAdapter.Fill(Me.TreasuryDataSet.OWN_CURRENCIES)
                Me.CUSTOMER_RATINGTableAdapter.Fill(Me.TreasuryDataSet.CUSTOMER_RATING)
                Me.FX_CREDIT_EQUIVALENT_Details_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Details_REAL_TIME, MaxFxDate)
                Me.FX_CREDIT_EQUIVALENT_Basic_REAL_TIMETableAdapter.FillByRiskDate(Me.TreasuryDataSet.FX_CREDIT_EQUIVALENT_Basic_REAL_TIME, MaxFxDate)
                'Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If
    End Sub

    Private Sub FxDateEdit_Click(sender As Object, e As EventArgs) Handles FxDateEdit.Click
        If IsDate(Me.FxDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.CCB_Guarantees_lbl.Text = ""
            Me.CCB_Fx_Credit_Equiv_lbl.Text = ""
            Me.Status_lbl.Text = ""
        End If
    End Sub

  
    Private Sub FxDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FxDateEdit.KeyDown
        If IsDate(Me.FxDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.CCB_Guarantees_lbl.Text = ""
            Me.CCB_Fx_Credit_Equiv_lbl.Text = ""
            Me.Status_lbl.Text = ""
            'Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub FxCreditEquivalentCalculationRealTime_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Me.FX_BaseView.IsFindPanelVisible Then
            'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
            Dim find As FindControl = TryCast(FX_BaseView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        Else
            FX_BaseView.ShowFindPanel()
        End If
    End Sub

  
    Private Sub FX_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles FX_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FX_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FX_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub FX_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles FX_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
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
        Dim reportfooter As String = "FX - CREDIT EQUIVALENT PROJECTION (based on FX Start Date) " & "  " & "on: " & Me.FxDateEdit.Text
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CCB_Fx_Credit_Equiv_lbl_TextChanged(sender As Object, e As EventArgs) Handles CCB_Fx_Credit_Equiv_lbl.TextChanged
        If CCB_Fx_Credit_Equiv_lbl.Text <> "" AndAlso IsDate(Me.FxDateEdit.Text) = True Then
            Dim d As Date = Me.FxDateEdit.Text
            Dim N As Double = Me.CCB_Fx_Credit_Equiv_lbl.Text
            If d <= DateSerial(2017, 6, 20) Then
                If N <= 75000000 Then
                    Me.Status_lbl.Text = "NO MEASURES"
                ElseIf N > 75000000 And N <= 90000000 Then
                    Me.Status_lbl.Text = "EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM"
                ElseIf N > 85000000 Then
                    Me.Status_lbl.Text = "NO TRANSACTIONS"
                End If
            ElseIf d > DateSerial(2017, 6, 20) Then
                If N <= 130000000 Then
                    Me.Status_lbl.Text = "NO MEASURES"
                ElseIf N > 130000000 And N <= 140000000 Then
                    Me.Status_lbl.Text = "EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM"
                ElseIf N > 140000000 Then
                    Me.Status_lbl.Text = "NO TRANSACTIONS"
                End If
            End If

        End If
    End Sub
End Class