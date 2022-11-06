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
Public Class CurrencyConverterOCBS

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim QueryText As String
    Private da As SqlDataAdapter
    Private dt As DataTable

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

    Private Sub CurrencyConverterOCBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'PSTOOLDataset.OWN_CURRENCIES' table. You can move, or remove it, as needed.
        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        'TODO: This line of code loads data into the 'PSTOOLDataset.EXCHANGE_RATES_OCBS' table. You can move, or remove it, as needed.
        Me.EXCHANGE_RATES_OCBSTableAdapter.FillByLastExchangeDate(Me.PSTOOLDataset.EXCHANGE_RATES_OCBS)

        'Get Max Exchange Date
        cmd.CommandText = "SELECT MAX([EXCHANGE RATE DATE]) FROM [EXCHANGE RATES OCBS] "
        cmd.Connection.Open()
        Dim MaxExchangeDate As Date = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.ExchangeRateDateEdit.Text = MaxExchangeDate

        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never

    End Sub

    Private Sub EXCHANGE_RATES_OCBSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXCHANGE_RATES_OCBSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub ExchangeRateDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangeRateDateEdit.EditValueChanged
        If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
            Dim d As Date = Me.ExchangeRateDateEdit.Text
            Me.EXCHANGE_RATES_OCBSTableAdapter.FillByExchangeDates(Me.PSTOOLDataset.EXCHANGE_RATES_OCBS, d, d)
            '******************************
            Me.ConvertedCurrency_lbl.Text = ""
            Me.ConvertedAmount_lbl.Text = ""
            Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
            '************************************************
            'Change EditMask in AmountToConvert
            cmd.CommandText = "SELECT [ACCEPTS DECIMALS]  FROM [OWN_CURRENCIES] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "'"
            cmd.Connection.Open()
            Dim AcceptDecimal As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If AcceptDecimal = "Y" Then
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n2"
            Else
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n0"
            End If
            'Get Exchange Rates
            Dim dsql As String = d.ToString("yyyy-MM-dd")
            If Me.CurrencyFromComboBoxEdit.Text <> "EUR" Then
                QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                    Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                    Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                    Dim Rate_Art As String = Me.RateFirstCurrencyComboBoxEdit.Text
                    Select Case Rate_Art
                        Case Is = "MIDDLE"
                            Me.RateFirstCurrencyTextEdit.Text = Midle_Rate
                        Case Is = "OFFERED"
                            Me.RateFirstCurrencyTextEdit.Text = Offered_Rate
                        Case Is = "MONEY"
                            Me.RateFirstCurrencyTextEdit.Text = Money_Rate
                        Case Else
                            Me.RateFirstCurrencyTextEdit.Text = 0
                    End Select
                End If
            Else
                Me.RateFirstCurrencyTextEdit.Text = 1
            End If

            '***************************************************************
            'GetExchange Rates
            If Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyToComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                    Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                    Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                    Dim Rate_Art As String = Me.RateSecondCurrencyComboBoxEdit.Text
                    Select Case Rate_Art
                        Case Is = "MIDDLE"
                            Me.RateSecondCurrencyTextEdit.Text = Midle_Rate
                        Case Is = "OFFERED"
                            Me.RateSecondCurrencyTextEdit.Text = Offered_Rate
                        Case Is = "MONEY"
                            Me.RateSecondCurrencyTextEdit.Text = Money_Rate
                        Case Else
                            Me.RateSecondCurrencyTextEdit.Text = 0
                    End Select
                End If
            Else
                Me.RateSecondCurrencyTextEdit.Text = 1
            End If

            '************************************************
            If Me.RateSecondCurrencyComboBoxEdit.Text = "Custom" Then
                Me.RateSecondCurrencyTextEdit.Properties.ReadOnly = False
            Else
                Me.RateSecondCurrencyTextEdit.Properties.ReadOnly = True
                If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
                    'GetExchange Rates
                    If Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                        QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyToComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                            Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                            Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                            Dim Rate_Art As String = Me.RateSecondCurrencyComboBoxEdit.Text
                            Select Case Rate_Art
                                Case Is = "MIDDLE"
                                    Me.RateSecondCurrencyTextEdit.Text = Midle_Rate
                                Case Is = "OFFERED"
                                    Me.RateSecondCurrencyTextEdit.Text = Offered_Rate
                                Case Is = "MONEY"
                                    Me.RateSecondCurrencyTextEdit.Text = Money_Rate
                                Case Else
                                    Me.RateSecondCurrencyTextEdit.Text = 0
                            End Select
                        End If
                    Else
                        Me.RateSecondCurrencyTextEdit.Text = 1
                    End If
                End If
            End If

            '*********************************************************

            If Me.RateFirstCurrencyComboBoxEdit.Text = "Custom" Then
                Me.RateFirstCurrencyTextEdit.Properties.ReadOnly = False
            Else
                Me.RateFirstCurrencyTextEdit.Properties.ReadOnly = True
                'Get Exchange Rates
                If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
                    If Me.CurrencyFromComboBoxEdit.Text <> "EUR" Then
                        QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                            Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                            Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                            Dim Rate_Art As String = Me.RateFirstCurrencyComboBoxEdit.Text
                            Select Case Rate_Art
                                Case Is = "MIDDLE"
                                    Me.RateFirstCurrencyTextEdit.Text = Midle_Rate
                                Case Is = "OFFERED"
                                    Me.RateFirstCurrencyTextEdit.Text = Offered_Rate
                                Case Is = "MONEY"
                                    Me.RateFirstCurrencyTextEdit.Text = Money_Rate
                                Case Else
                                    Me.RateFirstCurrencyTextEdit.Text = 0
                            End Select
                        End If
                    Else
                        Me.RateFirstCurrencyTextEdit.Text = 1
                    End If
                End If
            End If

        End If


    End Sub

    Private Sub CurrencyFromComboBoxEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CurrencyFromComboBoxEdit.EditValueChanged
        '******************************
        Me.ConvertedCurrency_lbl.Text = ""
        Me.ConvertedAmount_lbl.Text = ""
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
        '************************************************
        If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
            'Change EditMask in AmountToConvert
            cmd.CommandText = "SELECT [ACCEPTS DECIMALS]  FROM [OWN_CURRENCIES] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "'"
            cmd.Connection.Open()
            Dim AcceptDecimal As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If AcceptDecimal = "Y" Then
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n2"
            Else
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n0"
            End If
            'Get Exchange Rates
            Dim d As Date = Me.ExchangeRateDateEdit.Text
            Dim dsql As String = d.ToString("yyyy-MM-dd")
            If Me.CurrencyFromComboBoxEdit.Text <> "EUR" Then
                QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                    Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                    Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                    Dim Rate_Art As String = Me.RateFirstCurrencyComboBoxEdit.Text
                    Select Case Rate_Art
                        Case Is = "MIDDLE"
                            Me.RateFirstCurrencyTextEdit.Text = Midle_Rate
                        Case Is = "OFFERED"
                            Me.RateFirstCurrencyTextEdit.Text = Offered_Rate
                        Case Is = "MONEY"
                            Me.RateFirstCurrencyTextEdit.Text = Money_Rate
                        Case Else
                            Me.RateFirstCurrencyTextEdit.Text = 0
                    End Select
                End If
            Else
                Me.RateFirstCurrencyTextEdit.Text = 1
            End If

        End If
        'Get Selected CurrencyName
        Dim c As String = Me.CurrencyFromComboBoxEdit.GetColumnValue("CURRENCY NAME").ToString
        Me.FirstCurrencyName_lbl.Text = c
    End Sub

    Private Sub CurrencyToComboBoxEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CurrencyToComboBoxEdit.EditValueChanged
        '******************************
        Me.ConvertedCurrency_lbl.Text = ""
        Me.ConvertedAmount_lbl.Text = ""
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
        '************************************************
        If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
            'GetExchange Rates
            Dim d As Date = Me.ExchangeRateDateEdit.Text
            Dim dsql As String = d.ToString("yyyy-MM-dd")
            If Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyToComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                    Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                    Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                    Dim Rate_Art As String = Me.RateSecondCurrencyComboBoxEdit.Text
                    Select Case Rate_Art
                        Case Is = "MIDDLE"
                            Me.RateSecondCurrencyTextEdit.Text = Midle_Rate
                        Case Is = "OFFERED"
                            Me.RateSecondCurrencyTextEdit.Text = Offered_Rate
                        Case Is = "MONEY"
                            Me.RateSecondCurrencyTextEdit.Text = Money_Rate
                        Case Else
                            Me.RateSecondCurrencyTextEdit.Text = 0
                    End Select
                End If
            Else
                Me.RateSecondCurrencyTextEdit.Text = 1
            End If
        End If
        'Get Selected CurrencyName
        Dim c As String = Me.CurrencyToComboBoxEdit.GetColumnValue("CURRENCY NAME").ToString
        Me.SecondCurrencyName_lbl.Text = c
    End Sub

    Private Sub AmountToConvertTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AmountToConvertTextEdit.EditValueChanged
        '******************************
        Me.ConvertedCurrency_lbl.Text = ""
        Me.ConvertedAmount_lbl.Text = ""
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
        '************************************************
    End Sub

    Private Sub AmountToConvertTextEdit_GotFocus(sender As Object, e As EventArgs) Handles AmountToConvertTextEdit.GotFocus
        If Me.CurrencyFromComboBoxEdit.Text <> "" Then
            cmd.CommandText = "SELECT [ACCEPTS DECIMALS]  FROM [OWN_CURRENCIES] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "'"
            cmd.Connection.Open()
            Dim AcceptDecimal As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If AcceptDecimal = "Y" Then
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n2"
            Else
                Me.AmountToConvertTextEdit.Properties.Mask.EditMask = "n0"
            End If
        End If

    End Sub

    Private Sub AmountToConvertTextEdit_LostFocus(sender As Object, e As EventArgs) Handles AmountToConvertTextEdit.LostFocus
        If IsNumeric(Me.AmountToConvertTextEdit.Text) = True Then
            Me.AmountToConvertTextEdit.Text = FormatNumber(Me.AmountToConvertTextEdit.Text, 2)
        Else
            Me.AmountToConvertTextEdit.Text = FormatNumber(0, 2)

        End If
    End Sub

   
   
    Private Sub RateSecondCurrencyComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RateSecondCurrencyComboBoxEdit.SelectedIndexChanged
        '******************************
        Me.ConvertedCurrency_lbl.Text = ""
        Me.ConvertedAmount_lbl.Text = ""
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
        '************************************************
        If Me.RateSecondCurrencyComboBoxEdit.Text = "Custom" Then
            Me.RateSecondCurrencyTextEdit.Properties.ReadOnly = False
        Else
            Me.RateSecondCurrencyTextEdit.Properties.ReadOnly = True
            If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
                'GetExchange Rates
                Dim d As Date = Me.ExchangeRateDateEdit.Text
                Dim dsql As String = d.ToString("yyyy-MM-dd")
                If Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                    QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyToComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                        Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                        Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                        Dim Rate_Art As String = Me.RateSecondCurrencyComboBoxEdit.Text
                        Select Case Rate_Art
                            Case Is = "MIDDLE"
                                Me.RateSecondCurrencyTextEdit.Text = Midle_Rate
                            Case Is = "OFFERED"
                                Me.RateSecondCurrencyTextEdit.Text = Offered_Rate
                            Case Is = "MONEY"
                                Me.RateSecondCurrencyTextEdit.Text = Money_Rate
                            Case Else
                                Me.RateSecondCurrencyTextEdit.Text = 0
                        End Select
                    End If
                Else
                    Me.RateSecondCurrencyTextEdit.Text = 1
                End If
            End If
        End If
    End Sub

    Private Sub RateFirstCurrencyComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RateFirstCurrencyComboBoxEdit.SelectedIndexChanged
        '******************************
        Me.ConvertedCurrency_lbl.Text = ""
        Me.ConvertedAmount_lbl.Text = ""
        Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
        '************************************************

        If Me.RateFirstCurrencyComboBoxEdit.Text = "Custom" Then
            Me.RateFirstCurrencyTextEdit.Properties.ReadOnly = False
        Else
            Me.RateFirstCurrencyTextEdit.Properties.ReadOnly = True
            'Get Exchange Rates
            If IsDate(Me.ExchangeRateDateEdit.Text) = True Then
                Dim d As Date = Me.ExchangeRateDateEdit.Text
                Dim dsql As String = d.ToString("yyyy-MM-dd")
                If Me.CurrencyFromComboBoxEdit.Text <> "EUR" Then
                    QueryText = "SELECT [MIDDLE RATE],[OFFERED RATE],[MONEY RATE],[SPREAD]  FROM [EXCHANGE RATES OCBS] WHERE [CURRENCY CODE]='" & Me.CurrencyFromComboBoxEdit.Text & "' AND [EXCHANGE RATE DATE]='" & dsql & "'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim Midle_Rate As Double = dt.Rows.Item(0).Item("MIDDLE RATE")
                        Dim Offered_Rate As Double = dt.Rows.Item(0).Item("OFFERED RATE")
                        Dim Money_Rate As Double = dt.Rows.Item(0).Item("MONEY RATE")
                        Dim Rate_Art As String = Me.RateFirstCurrencyComboBoxEdit.Text
                        Select Case Rate_Art
                            Case Is = "MIDDLE"
                                Me.RateFirstCurrencyTextEdit.Text = Midle_Rate
                            Case Is = "OFFERED"
                                Me.RateFirstCurrencyTextEdit.Text = Offered_Rate
                            Case Is = "MONEY"
                                Me.RateFirstCurrencyTextEdit.Text = Money_Rate
                            Case Else
                                Me.RateFirstCurrencyTextEdit.Text = 0
                        End Select
                    End If
                Else
                    Me.RateFirstCurrencyTextEdit.Text = 1
                End If
            End If
        End If
    End Sub

    Private Sub Convert_btn_Click(sender As Object, e As EventArgs) Handles Convert_btn.Click
        If Me.CurrencyFromComboBoxEdit.Text <> "" AndAlso Me.CurrencyToComboBoxEdit.Text <> "" AndAlso IsNumeric(Me.RateFirstCurrencyTextEdit.Text) = True AndAlso IsNumeric(Me.RateSecondCurrencyTextEdit.Text) = True Then
            'EURO to ForeignCurrency
            If Me.CurrencyFromComboBoxEdit.Text = "EUR" AndAlso Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                Dim ToConvertAmount As Double = Me.AmountToConvertTextEdit.Text
                Dim ExchangeRate As Double = Me.RateSecondCurrencyTextEdit.Text
                Dim ConvertedAmount As Double = Math.Round(ToConvertAmount * ExchangeRate, 2)
                Me.ConvertedCurrency_lbl.Text = Me.CurrencyToComboBoxEdit.Text
                Me.ConvertedAmount_lbl.Text = FormatNumber(ConvertedAmount, 2)
                Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
                'ForeignCurrency to EURO
            ElseIf Me.CurrencyFromComboBoxEdit.Text <> "EUR" AndAlso Me.CurrencyToComboBoxEdit.Text = "EUR" Then
                Dim ToConvertAmount As Double = Me.AmountToConvertTextEdit.Text
                Dim ExchangeRate As Double = Me.RateFirstCurrencyTextEdit.Text
                Dim ConvertedAmount As Double = Math.Round(ToConvertAmount / ExchangeRate, 2)
                Me.ConvertedCurrency_lbl.Text = Me.CurrencyToComboBoxEdit.Text
                Me.ConvertedAmount_lbl.Text = FormatNumber(ConvertedAmount, 2)
                Me.LayoutControlItem17.Visibility = LayoutVisibility.Never
            ElseIf Me.CurrencyFromComboBoxEdit.Text <> "EUR" AndAlso Me.CurrencyToComboBoxEdit.Text <> "EUR" Then
                Dim ToConvertAmount As Double = Me.AmountToConvertTextEdit.Text
                Dim ExchangeRate1 As Double = Math.Round(1 / Me.RateFirstCurrencyTextEdit.Text, 5)
                Dim ExchangeRate2 As Double = Math.Round(1 / Me.RateSecondCurrencyTextEdit.Text, 5)
                Dim CrossRate As Double = Math.Round(ExchangeRate1 / ExchangeRate2, 5)
                Dim ConvertedAmount As Double = Math.Round(ToConvertAmount * CrossRate, 2)
                Me.ConvertedCurrency_lbl.Text = Me.CurrencyToComboBoxEdit.Text
                Me.ConvertedAmount_lbl.Text = FormatNumber(ConvertedAmount, 2)
                'Daten Übergeben
                Me.FirstCurrencyToEUR_lbl.Text = "EUR/" & Me.CurrencyFromComboBoxEdit.Text
                Me.FirstCurrencyToEURrate_lbl.Text = ExchangeRate1
                Me.SecondCurrencyToEUR_lbl.Text = "EUR/" & Me.CurrencyToComboBoxEdit.Text
                Me.SecondCurrencyToEURrate_lbl.Text = ExchangeRate2
                Me.CrossCurrencies_lbl.Text = Me.CurrencyFromComboBoxEdit.Text & " /" & Me.CurrencyToComboBoxEdit.Text
                Me.CrossRateCurrencies_lbl.Text = CrossRate
                Me.LayoutControlItem17.Visibility = LayoutVisibility.Always
            End If
        End If
        'Check if Currency accepts decimals
        If Me.ConvertedAmount_lbl.Text <> "" Then
            Dim ConvertedAmount As Double = Me.ConvertedAmount_lbl.Text
            cmd.CommandText = "SELECT [ACCEPTS DECIMALS]  FROM [OWN_CURRENCIES] WHERE [CURRENCY CODE]='" & Me.ConvertedCurrency_lbl.Text & "'"
            cmd.Connection.Open()
            Dim AcceptDecimal As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If AcceptDecimal = "Y" Then
                Me.ConvertedAmount_lbl.Text = FormatNumber(Me.ConvertedAmount_lbl.Text, 2)
            Else
                Me.ConvertedAmount_lbl.Text = FormatNumber(Math.Round(ConvertedAmount, 0), 2)
            End If
        End If
    End Sub

    Private Sub CurrenciesConvert_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles CurrenciesConvert_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never
        'ÄMe.LayoutControlItem15.Visibility = LayoutVisibility.Never
        Me.ConvertedCurrency_lbl.ForeColor = Color.Black
        Me.ConvertedAmount_lbl.ForeColor = Color.Black
        Me.LayoutControlItem5.AppearanceItemCaption.ForeColor = Color.Black
        Me.LayoutControlItem8.AppearanceItemCaption.ForeColor = Color.Black
        Me.LayoutControlItem9.AppearanceItemCaption.ForeColor = Color.Black
        Me.LayoutControlItem10.AppearanceItemCaption.ForeColor = Color.Black
        Me.LayoutControlItem11.AppearanceItemCaption.ForeColor = Color.Black
        Me.LayoutControlItem14.AppearanceItemCaption.ForeColor = Color.Black
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Always
        'Me.LayoutControlItem15.Visibility = LayoutVisibility.Always
        Me.ConvertedCurrency_lbl.ForeColor = Color.Yellow
        Me.ConvertedAmount_lbl.ForeColor = Color.Yellow
        Me.LayoutControlItem5.AppearanceItemCaption.ForeColor = Nothing
        Me.LayoutControlItem8.AppearanceItemCaption.ForeColor = Nothing
        Me.LayoutControlItem9.AppearanceItemCaption.ForeColor = Nothing
        Me.LayoutControlItem10.AppearanceItemCaption.ForeColor = Nothing
        Me.LayoutControlItem11.AppearanceItemCaption.ForeColor = Nothing
        Me.LayoutControlItem14.AppearanceItemCaption.ForeColor = Nothing
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
        Dim reportfooter As String = "OCBS CURRENCY CONVERTION" & vbNewLine & "Printed on: " & Now

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub
End Class