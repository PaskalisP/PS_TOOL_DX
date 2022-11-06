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
Imports System.Drawing
Public Class Securities_AddNewDailyPrice

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Public SDP As Securities_Dailyprice

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

    Private Sub Securities_AddNewDailyPrice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Securities_AddNewDailyPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        'cmd.Connection = conn
        'Dim objCMD As SqlCommand = New SqlCommand("Select *,0.000000 as 'Market_Price' from [SECURITIES_OUR] where [STATUS] in ('ACTIVE')", conn)
        'objCMD.CommandTimeout = 5000
        'da = New SqlDataAdapter(objCMD)
        'dt = New DataTable()
        'da.Fill(dt)
        'Results
        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        'Me.GridControl2.DataSource = Nothing
        'Me.GridControl2.DataSource = dt
        'Me.GridControl2.ForceInitialize()
        'End If

    End Sub

   
    Private Sub DailyPrice_import_btn_Click(sender As Object, e As EventArgs) Handles DailyPrice_import_btn.Click
        If IsDate(Me.LiquidityDateEdit.Text) = True Then
            Dim Datadate As Date = Me.LiquidityDateEdit.Text
            Dim DatadateSql As String = Datadate.ToString("yyyyMMdd")

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            cmd.CommandText = "Select distinct [Date] from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
            Dim result As String = cmd.ExecuteScalar
            If result <> "" Then
                If MessageBox.Show("Daily Price Date: " & Datadate & " allready inserted to the Daily Price Table!" & vbNewLine & "Should the current Data be overwritten with the current Market Prices?", "DAILY PRICE DATE ALLREADY INSERTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'lösche alte daten
                    cmd.CommandText = "Delete from [SECURITIES_DailyPrice] where [Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()

                    Dim dt As New DataTable
                    dt.Rows.Clear()
                    Dim r As DataRow

                    For i = 0 To SecuritiesDailyPriceBaseView.RowCount - 1
                        If SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price) = 0 Then
                            MessageBox.Show("Please enter the Market Price for each Security/Bond", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    Next

                    dt.Columns.Add("Date", GetType(Date))
                    dt.Columns.Add("Name", GetType(String))
                    dt.Columns.Add("ISIN_Code", GetType(String))
                    dt.Columns.Add("Market_Price", GetType(Double))
                    dt.Columns.Add("ContractNrOCBS", GetType(Double))

                    For i = 0 To SecuritiesDailyPriceBaseView.RowCount - 1
                        r = dt.NewRow
                        r("Date") = Me.LiquidityDateEdit.Text
                        r("Name") = SecuritiesDailyPriceBaseView.GetRowCellValue(i, colName)
                        r("ISIN_Code") = SecuritiesDailyPriceBaseView.GetRowCellValue(i, colISIN_Code)
                        r("Market_Price") = SecuritiesDailyPriceBaseView.GetRowCellValue(i, colMarket_Price)
                        r("ContractNrOCBS") = SecuritiesDailyPriceBaseView.GetRowCellValue(i, SecuritiesDailyPriceBaseView.Columns.ColumnByFieldName("ContractNrOCBS"))
                        dt.Rows.Add(r)

                    Next

                    For Each dr As DataRow In dt.Rows
                        Dim sc As New SqlCommand("INSERT INTO [SECURITIES_DailyPrice] ([Date],[Name],[ISIN_Code],[Market_Price],[ContractNrOCBS])" &
                                                  " VALUES (@column1, @column2, @column3, @column4, @column5)", conn)
                        sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.Parameters.AddWithValue("@column5", dr.Item(4))
                        sc.ExecuteNonQuery()
                    Next
                    cmd.CommandText = "UPDATE A SET A.[Ccy]=B.[Currency],A.[Purchase_price]=B.[Purchase_Price],A.[RIC]=B.[RIC]
                                       ,A.[Swap_Price]=B.[Swap_Price],A.[industry]=B.[industry],A.[Fixed rate coupon]=B.[Fixed rate coupon]
                                       ,A.[Floating(leg) spread ]=B.[Floating(leg) spread ],A.[purchasing yield]=B.[purchasing yield]
                                       ,A.[bond type]=B.[bond type],A.[with swap or not]=B.[with swap or not],A.[Moody-Rating]=B.[Moody-Rating]
                                       ,A.[S & P]=B.[S & P],A.[Fitch-Rating]=B.[Fitch-Rating] 
                                        FROM [SECURITIES_DailyPrice] A INNER JOIN [SECURITIES_OUR] B 
                                        on A.ISIN_Code=B.ISIN and A.[Date]='" & DatadateSql & "'"
                    cmd.ExecuteNonQuery()


                    'Execute LIQUIDITY RESERVE
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Execute PS TOOL CLIENT PROCEDURE:LIQUIDITY_RESERVE")
                    Dim HasDataResult As String = Nothing
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('LIQUIDITY_RESERVE') and [Id_SQL_Parameters] in ('PS TOOL CLIENT PROCEDURES')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        cmd.CommandText = "SELECT [Date] FROM [SECURITIES_DailyPrice] WHERE [Date]='" & DatadateSql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('LIQUIDITY_RESERVE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", DatadateSql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    Else
                    End If
                    SplashScreenManager.CloseForm(False)


                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If



                    Me.Close()

                    My.Forms.Securities_Dailyprice.SECURITIES_DailyPriceTableAdapter.Fill(SDP.SECURITIESDataset.SECURITIES_DailyPrice)
                    My.Forms.Securities_Dailyprice.SecuritiesDailyPriceBaseView.ExpandAllGroups()

                Else
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                   

                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Else
            MessageBox.Show("Please enter the Market Price Date!", "MARKET PRICE DATE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.LiquidityDateEdit.Focus()
            Return


        End If


    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()

    End Sub

   

    Private Sub LiquidityDateEdit_LostFocus(sender As Object, e As EventArgs) Handles LiquidityDateEdit.LostFocus
        SecuritiesDailyPriceBaseView.FocusedColumn = SecuritiesDailyPriceBaseView.VisibleColumns(7)

        SecuritiesDailyPriceBaseView.ShowEditor()
    End Sub

End Class