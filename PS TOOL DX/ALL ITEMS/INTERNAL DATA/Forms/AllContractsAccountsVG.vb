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
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Public Class AllContractsAccountsVG

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim CrystalRepDir As String = Nothing

    Private BS_National_Identifiers As BindingSource
    Private BS_NACE_Branch_Codes As BindingSource
    Private BS_Instutional_Sector_Codes As BindingSource
    Private BS_Legal_Codes As BindingSource
    Private BS_Legal_Proceedings As BindingSource
    Private BS_Enterprise_Size As BindingSource
    Private BS_All_Customers As BindingSource

    Dim Details_Default_View As String = Nothing
    Dim ClientNrSearch As String = Nothing
    Dim ResidenceCountryEU_Member As String = Nothing

    Private Sub AllContractsAccountsVG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS' table. You can move, or remove it, as needed.
        'Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
        Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.FillByContractNr(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS, GLOBAL_CONTRACT_NR)
        ''Load Customer Info
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & GLOBAL_CLIENT_NR & "'"
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.Customer_VGridControl.DataSource = Nothing
                Me.Customer_VGridControl.DataSource = objDataTable
                Me.Customer_VGridControl.ForceInitialize()
                sqlConn.Close()
            End Using
        End Using
        'Load Accrued Interest Analysis
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT A.* FROM [ACCRUED INTEREST ANALYSIS] A INNER JOIN (Select contract,Max(Datadate) as 'MaxDate',[Current Interest Coupon Period End Date] from [ACCRUED INTEREST ANALYSIS] where [Contract]='" & GLOBAL_CONTRACT_NR & "' GROUP BY Contract,[Current Interest Coupon Period End Date]) B on A.Contract=B.Contract and A.[Current Interest Coupon Period End Date]=B.[Current Interest Coupon Period End Date] and A.Datadate=B.MaxDate order by A.Datadate desc"
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.AccruedInterest_GridControl.DataSource = Nothing
                Me.AccruedInterest_GridControl.DataSource = objDataTable
                Me.AccruedInterest_GridControl.ForceInitialize()
                sqlConn.Close()
            End Using
        End Using
        'Load Cash flows
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT A.* FROM [CASH_FLOWS_FINRECON] A INNER JOIN (Select [Contract_Nr_Clear],EventDate,Max(RiskDate) as 'MaxDate' from [CASH_FLOWS_FINRECON] where Contract_Nr_Clear='" & GLOBAL_CONTRACT_NR & "' GROUP BY [Contract_Nr_Clear],EventDate)B on A.Contract_Nr_Clear=B.Contract_Nr_Clear and A.RiskDate=B.MaxDate and A.EventDate=B.EventDate order by A.RiskDate desc"
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.CashFlow_GridControl.DataSource = Nothing
                Me.CashFlow_GridControl.DataSource = objDataTable
                Me.CashFlow_GridControl.ForceInitialize()
                sqlConn.Close()
            End Using
        End Using
        'Load Value Adjustments
        Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using sqlCmd As New SqlCommand()
                sqlCmd.CommandText = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST] where [ContractNr]='" & GLOBAL_CONTRACT_NR & "' order by [ID] desc "
                sqlCmd.Connection = sqlConn
                sqlConn.Open()
                Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                Dim objDataTable As New DataTable()
                objDataTable.Load(objDataReader)
                Me.ValueAdjustments_GridControl.DataSource = Nothing
                Me.ValueAdjustments_GridControl.DataSource = objDataTable
                Me.ValueAdjustments_GridControl.ForceInitialize()
                sqlConn.Close()
            End Using
        End Using
    End Sub


End Class