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
Imports Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraPivotGrid
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class Pivot_VerlustfreieBewertung

    Dim conn As New SqlClient.SqlConnection
    Dim cmd As New SqlCommand

    Dim ActiveTabGroup As Double = 0

    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing
    Dim rd1 As Date
    Dim rd2 As Date
    Dim flrd As Date
    Dim flrdsql As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private dtM As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable

    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    Dim RowHeaderText As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim query As New CustomSqlQuery()
    Private font_Renamed As New System.Drawing.Font("Calibri", 10, FontStyle.Bold)


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

    Private Sub Pivot_VerlustfreieBewertung_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        Me.LayoutControlGroup2.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup4.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup8.Visibility = LayoutVisibility.Never

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()

        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] Where DAY(DATEADD(day, 1, [RLDC Date])) = 1 and  [PL Result] is not NULL order by [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))

            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")

        End If
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")




        'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
        Me.QueryText = "  Select * from SQL_PARAMETER_DETAILS_SECOND where Id_SQL_Parameters_Details in (Select [ID] from SQL_PARAMETER_DETAILS where [SQL_Name_1] in ('ZinsatzVerlustfreieBewertung')) and Status in ('Y') order by ID asc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl2.DataSource = Nothing
            Me.GridControl2.DataSource = dt
            Me.GridControl2.ForceInitialize()
        End If

        'Get Data for Refi Zinssatz
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RefiSatz') and Status in ('Y')"
        Dim RefiSatz As Double = cmd.ExecuteScalar
        Me.RefiZins_TextEdit.EditValue = RefiSatz
        'Get Data RisikokostenErwartererVerlustRestjahr
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RisikokostenErwartererVerlustRestjahr') and Status in ('Y')"
        Dim Risikokosten As Double = cmd.ExecuteScalar
        Me.Risikokosten_SpinEdit.EditValue = Risikokosten
        'Get Data VerwaltungskostenVorjahr
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahr') and Status in ('Y')"
        Dim VerwaltungskostenVorjahr As Double = cmd.ExecuteScalar
        Me.VerwaltungskostenNetto_SpinEdit.EditValue = VerwaltungskostenVorjahr
        'Get Data VerwaltungskostenVorjahrPercent
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrPercent') and Status in ('Y')"
        Dim VerwaltungskostenVorjahrPercent As Double = cmd.ExecuteScalar
        Me.VerwaltungskostenPercent_SpinEdit.EditValue = VerwaltungskostenVorjahrPercent
        'Get Data VerwaltungskostenVorjahrTotal
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrTotal') and Status in ('Y')"
        Dim VerwaltungskostenVorjahrTotal As Double = cmd.ExecuteScalar
        Me.VerwaltungskostenTotal_SpinEdit.EditValue = VerwaltungskostenVorjahrTotal
        'Get Data VerwaltungskostenErstesJahr
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenErstesJahr') and Status in ('Y')"
        Dim VerwaltungskostenErstesJahr As Double = cmd.ExecuteScalar
        Me.VerwaltungskostenErstesJahr_SpinEdit.EditValue = VerwaltungskostenErstesJahr
        'Get Data SchwellenwertMinimumbetragVerwaltungskosten
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('SchwellenwertMinimumbetragVerwaltungskosten') and Status in ('Y')"
        Dim SchwellenwertMinimumbetragVerwaltungskosten As Double = cmd.ExecuteScalar
        Me.Schwellenwert_SpinEdit.EditValue = SchwellenwertMinimumbetragVerwaltungskosten
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If

        'Forelast Date for Daily Balance Sheet
        'Me.QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL and [RLDC Date]= (SELECT MAX([RLDC Date]) AS second FROM  [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date] < (SELECT MAX([RLDC Date]) AS first FROM  [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql1 & "'))"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)

        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '    flrd = dt.Rows.Item(0).Item("RLDC Date")
        '    flrdsql = flrd.ToString("yyyyMMdd")
        'End If

        Try

            LOAD_DATA()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try



    End Sub

    Private Sub BS_DateFrom_Comboedit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BS_DateFrom_Comboedit.ButtonClick
        If e.Button.Tag = "Calculation" Then
            If XtraMessageBox.Show("Should the calculations for the Verlustfreie Bewertung be started with these Parameters?", "VERLUSTFREIE BEWERTUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
                Try
                    rd1 = Me.BS_DateFrom_Comboedit.Text
                    rdsql1 = rd1.ToString("yyyyMMdd")

                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Update manual inputed parameters")

                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Save Manual Inputs
                    Dim dtM As New System.Data.DataTable
                    dtM.Rows.Clear()
                    Dim r As DataRow

                    'For i = 0 To PDBaseView.RowCount - 1
                    '    If PDBaseView.GetRowCellValue(i, colZuschlagZins) = 0 OrElse PDBaseView.GetRowCellValue(i, colAbzinsungssatzBUBA) = 0 Then
                    '        MessageBox.Show("Please enter the Market Price for each Security/Bond", "SECURITY MARKET PRICE IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    '        Return
                    '    End If
                    'Next

                    dtM.Columns.Add("ID", GetType(Integer))
                    dtM.Columns.Add("SQL_Name_1", GetType(String))
                    dtM.Columns.Add("SQL_Float_1", GetType(Double))
                    dtM.Columns.Add("SQL_Float_2", GetType(Double))

                    For i = 0 To PDBaseView.RowCount - 1
                        r = dtM.NewRow
                        r("ID") = PDBaseView.GetRowCellValue(i, colID)
                        r("SQL_Name_1") = PDBaseView.GetRowCellValue(i, colJahr)
                        r("SQL_Float_1") = PDBaseView.GetRowCellValue(i, colZuschlagZins)
                        r("SQL_Float_2") = PDBaseView.GetRowCellValue(i, colAbzinsungssatzBUBA)
                        dtM.Rows.Add(r)
                    Next

                    For Each dr As DataRow In dtM.Rows
                        Dim sc As New SqlCommand("UPDATE [SQL_PARAMETER_DETAILS_SECOND] SET [SQL_Float_1]=@column3,[SQL_Float_2]=@column4 where [ID]=" & dr.Item(0) & " and [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where [SQL_Name_1] in ('ZinsatzVerlustfreieBewertung'))", conn)
                        'sc.Parameters.AddWithValue("@column1", dr.Item(0))
                        'sc.Parameters.AddWithValue("@column2", dr.Item(1))
                        sc.Parameters.AddWithValue("@column3", dr.Item(2))
                        sc.Parameters.AddWithValue("@column4", dr.Item(3))
                        sc.ExecuteNonQuery()
                    Next

                    'Update editvalues
                    Dim RefiSatz As Double = Me.RefiZins_TextEdit.EditValue
                    Dim RisikokostenErwartererVerlustRestjahr As Double = Me.Risikokosten_SpinEdit.EditValue
                    Dim VerwaltungskostenVorjahr As Double = Me.VerwaltungskostenNetto_SpinEdit.EditValue
                    Dim VerwaltungskostenVorjahrPercent As Double = Me.VerwaltungskostenPercent_SpinEdit.EditValue
                    Dim VerwaltungskostenVorjahrTotal As Double = Me.VerwaltungskostenTotal_SpinEdit.EditValue
                    Dim VerwaltungskostenErstesJahr As Double = Me.VerwaltungskostenErstesJahr_SpinEdit.EditValue
                    Dim SchwellenwertMinimumbetragVerwaltungskosten As Double = Me.Schwellenwert_SpinEdit.EditValue

                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@RefiSatz where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RefiSatz') and Status in ('Y') "
                    cmd.Parameters.Add("@RefiSatz", SqlDbType.Float).Value = RefiSatz
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@RisikokostenErwartererVerlustRestjahr where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RisikokostenErwartererVerlustRestjahr') and Status in ('Y') "
                    cmd.Parameters.Add("@RisikokostenErwartererVerlustRestjahr", SqlDbType.Float).Value = RisikokostenErwartererVerlustRestjahr
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@VerwaltungskostenVorjahr where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahr') and Status in ('Y') "
                    cmd.Parameters.Add("@VerwaltungskostenVorjahr", SqlDbType.Float).Value = VerwaltungskostenVorjahr
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@VerwaltungskostenVorjahrPercent where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrPercent') and Status in ('Y') "
                    cmd.Parameters.Add("@VerwaltungskostenVorjahrPercent", SqlDbType.Float).Value = VerwaltungskostenVorjahrPercent
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@VerwaltungskostenVorjahrTotal where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrTotal') and Status in ('Y') "
                    cmd.Parameters.Add("@VerwaltungskostenVorjahrTotal", SqlDbType.Float).Value = VerwaltungskostenVorjahrTotal
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@VerwaltungskostenErstesJahr where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenErstesJahr') and Status in ('Y') "
                    cmd.Parameters.Add("@VerwaltungskostenErstesJahr", SqlDbType.Float).Value = VerwaltungskostenErstesJahr
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandText = "UPDATE [SQL_PARAMETER_DETAILS] SET [SQL_Float_1]=@SchwellenwertMinimumbetragVerwaltungskosten where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('SchwellenwertMinimumbetragVerwaltungskosten') and Status in ('Y') "
                    cmd.Parameters.Add("@SchwellenwertMinimumbetragVerwaltungskosten", SqlDbType.Float).Value = SchwellenwertMinimumbetragVerwaltungskosten
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    Me.QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND where Id_SQL_Parameters_Details in (Select [ID] from SQL_PARAMETER_DETAILS where [SQL_Name_1] in ('ZinsatzVerlustfreieBewertung')) and Status in ('Y') order by ID asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Me.GridControl2.DataSource = Nothing
                        Me.GridControl2.DataSource = dt
                        Me.GridControl2.ForceInitialize()
                    End If

                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RefiSatz') and Status in ('Y')"
                    RefiSatz = cmd.ExecuteScalar
                    Me.RefiZins_TextEdit.EditValue = RefiSatz
                    'Get Data RisikokostenErwartererVerlustRestjahr
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RisikokostenErwartererVerlustRestjahr') and Status in ('Y')"
                    RisikokostenErwartererVerlustRestjahr = cmd.ExecuteScalar
                    Me.Risikokosten_SpinEdit.EditValue = RisikokostenErwartererVerlustRestjahr
                    'Get Data VerwaltungskostenVorjahr
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahr') and Status in ('Y')"
                    VerwaltungskostenVorjahr = cmd.ExecuteScalar
                    Me.VerwaltungskostenNetto_SpinEdit.EditValue = VerwaltungskostenVorjahr
                    'Get Data VerwaltungskostenVorjahrPercent
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrPercent') and Status in ('Y')"
                    VerwaltungskostenVorjahrPercent = cmd.ExecuteScalar
                    Me.VerwaltungskostenPercent_SpinEdit.EditValue = VerwaltungskostenVorjahrPercent
                    'Get Data VerwaltungskostenVorjahrTotal
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrTotal') and Status in ('Y')"
                    VerwaltungskostenVorjahrTotal = cmd.ExecuteScalar
                    Me.VerwaltungskostenTotal_SpinEdit.EditValue = VerwaltungskostenVorjahrTotal
                    'Get Data VerwaltungskostenErstesJahr
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenErstesJahr') and Status in ('Y')"
                    VerwaltungskostenErstesJahr = cmd.ExecuteScalar
                    Me.VerwaltungskostenErstesJahr_SpinEdit.EditValue = VerwaltungskostenErstesJahr
                    'Get Data SchwellenwertMinimumbetragVerwaltungskosten
                    cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('SchwellenwertMinimumbetragVerwaltungskosten') and Status in ('Y')"
                    SchwellenwertMinimumbetragVerwaltungskosten = cmd.ExecuteScalar
                    Me.Schwellenwert_SpinEdit.EditValue = SchwellenwertMinimumbetragVerwaltungskosten

                    Me.BS_DateFrom_Comboedit.Properties.Buttons.Item(2).Visible = False
                    Me.BS_DateFrom_Comboedit.Properties.Buttons.Item(4).Visible = True

                    SplashScreenManager.Default.SetWaitFormCaption("Execute calculation for Business Date: " & rd1)
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('VerlustfreieBewertung_Calculations')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql1)
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            Threading.Thread.Sleep(500)
                            SplashScreenManager.Default.SetWaitFormCaption("Verlustfreie Bewertung calculation for " & rd1 & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()

                        End If
                    Next

                    'Visibility Layoutgroups
                    Me.LayoutControlGroup5.Visibility = LayoutVisibility.Never
                    Me.LayoutControlGroup2.Visibility = LayoutVisibility.Always
                    Me.LayoutControlGroup4.Visibility = LayoutVisibility.Always
                    Me.LayoutControlGroup8.Visibility = LayoutVisibility.Always
                    ActiveTabGroup = 1
                    'Lock BusinessDate
                    Me.BS_DateFrom_Comboedit.ReadOnly = True

                    'Load Data
                    SplashScreenManager.Default.SetWaitFormCaption("Load calculation results for Business Date: " & rd1)
                    LOAD_DATA()

                    SplashScreenManager.CloseForm(False)

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return

                End Try
            Else
                Return
            End If

        End If


        If e.Button.Tag = "Reset" Then

            Try
                rd1 = Me.BS_DateFrom_Comboedit.Text
                rdsql1 = rd1.ToString("yyyyMMdd")

                'Visibility Layoutgroups
                Me.LayoutControlGroup5.Visibility = LayoutVisibility.Always
                Me.LayoutControlGroup2.Visibility = LayoutVisibility.Never
                Me.LayoutControlGroup4.Visibility = LayoutVisibility.Never
                Me.LayoutControlGroup8.Visibility = LayoutVisibility.Never
                'UnLock BusinessDate
                Me.BS_DateFrom_Comboedit.ReadOnly = False

                Me.BS_DateFrom_Comboedit.Properties.Buttons.Item(2).Visible = True
                Me.BS_DateFrom_Comboedit.Properties.Buttons.Item(4).Visible = False
                ActiveTabGroup = 0
            Catch ex As Exception

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End Try

        End If


    End Sub

    Private Sub LOAD_DATA()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        'Data
        Me.QueryText = "Select * from [VerlustfreieBewertung_Data]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = dt
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()
        End If

        'Surplus
        Me.QueryText = "Select * from [VerlustfreieBewertung_DataTotals]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl1.DataSource = dt
            Me.GridControl1.ForceInitialize()
        End If
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RefiSatz') and Status in ('Y')"
        Dim RefiSatz As Double = cmd.ExecuteScalar
        Me.RefiZinsLive_SpinEdit.EditValue = RefiSatz

        'Overview
        Me.QueryText = "Select * from [VerlustfreieBewertung_Overview]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.GridControl3.DataSource = Nothing
            Me.GridControl3.DataSource = dt
            Me.GridControl3.ForceInitialize()
        End If

        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('RisikokostenErwartererVerlustRestjahr') and Status in ('Y')"
        Dim RisikokostenErwartererVerlustRestjahr As Double = cmd.ExecuteScalar
        Me.RisikokostenLive_SpinEdit.EditValue = RisikokostenErwartererVerlustRestjahr
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('VerwaltungskostenVorjahrTotal') and Status in ('Y')"
        Dim VerwaltungskostenVorjahrTotal As Double = cmd.ExecuteScalar
        Me.VerwaltungskostenTotalLive_SpinEdit.EditValue = VerwaltungskostenVorjahrTotal
        cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters] in ('VERLUSTFREIE_BEWERTUNG') and [SQL_Name_1] in ('SchwellenwertMinimumbetragVerwaltungskosten') and Status in ('Y')"
        Dim SchwellenwertMinimumbetragVerwaltungskosten As Double = cmd.ExecuteScalar
        Me.SchwellenwertLive_SpinEdit.EditValue = SchwellenwertMinimumbetragVerwaltungskosten

        'Get Ergebniss
        cmd.CommandText = "Select Sum(Barwert) from VerlustfreieBewertung_Overview"
        Dim Ergebniss As Double = cmd.ExecuteScalar
        If Ergebniss >= 0 Then
            Me.Ergebnis_SimpleLabelItem1.Text = "KEINE DROHVERLUSTRÜCKSTELLUNG"
        ElseIf Ergebniss < 0 Then
            Me.Ergebnis_SimpleLabelItem1.Text = "DROHVERLUSTRÜCKSTELLUNG"
        End If

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
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
        Dim reportfooter As String = "Verlustfreie Bewertung - Data Projection on " & rd1
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
        Dim reportfooter As String = "Verlustfreie Bewertung - Surplus on  " & rd1
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "Verlustfreie Bewertung - Overview on  " & rd1
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 1 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Verlustfreie Bewertung - Data Projection on  " & rd1)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 2 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Verlustfreie Bewertung - Surplus on  " & rd1)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 3 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Verlustfreie Bewertung - Overview on  " & rd1)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "Manuelle Eingaben" Then
            ActiveTabGroup = 0

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Projection" Then
            ActiveTabGroup = 1

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Surplus" Then
            ActiveTabGroup = 2

        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Overview" Then
            ActiveTabGroup = 3

        End If
    End Sub

    Private Sub PivotGridControl1_CellDoubleClick(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        'MsgBox(RowHeaderText)
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()


            For Each col As GridColumn In c.PivotDetailsBaseView.Columns
                If col.FieldName.StartsWith("Amount") Or col.Name.Contains("Sum") Or col.FieldName.Contains("Amount") Or col.FieldName = "Zinseretrag" _
                     Or col.FieldName.Contains("Equivalent") _
                    Or col.FieldName.Contains("Credit Exposure") Or col.FieldName.Contains("Org Ccy") _
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName.StartsWith("Sum Principal") Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"

                ElseIf col.FieldName.StartsWith("Time") Or col.FieldName.StartsWith("Transaction Time") Or col.FieldName.EndsWith("Time") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    col.DisplayFormat.FormatString = "HH:mm:ss"
                End If
            Next

            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try




    End Sub

    Private Sub PivotGridControl1_CustomDrawFieldHeader(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventArgs) Handles PivotGridControl1.CustomDrawFieldHeader
        If (Not e.Field.FilterValues.IsEmpty) AndAlso e.Info.State = DevExpress.Utils.Drawing.ObjectState.Normal Then
            e.Info.State = DevExpress.Utils.Drawing.ObjectState.Hot
        End If

    End Sub

    Private Sub PivotGridControl1_CustomDrawFieldValue(sender As Object, e As PivotCustomDrawFieldValueEventArgs) Handles PivotGridControl1.CustomDrawFieldValue
        'RowHeaderText = e.Field.ToString


    End Sub

    Private Sub PivotGridControl1_CustomFieldSort(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs) Handles PivotGridControl1.CustomFieldSort
        If e.Field.FieldName = "PERIOD" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumn"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumn")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
        If e.Field.FieldName = "PERIOD_MaturityDate" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumnMaturity"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumnMaturity")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
    End Sub

    Private Sub PivotGridControl2_CustomFieldSort(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)
        If e.Field.FieldName = "Period" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumn"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumn")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
    End Sub


    Private Sub VerwaltungskostenNetto_SpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles VerwaltungskostenNetto_SpinEdit.EditValueChanged
        Dim n As Double = Me.VerwaltungskostenNetto_SpinEdit.EditValue
        Dim p As Double = Me.VerwaltungskostenPercent_SpinEdit.EditValue
        Dim t As Double = Math.Round(n * p, 2)
        Me.VerwaltungskostenTotal_SpinEdit.EditValue = t
    End Sub

    Private Sub VerwaltungskostenPercent_SpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles VerwaltungskostenPercent_SpinEdit.EditValueChanged
        Dim n As Double = Me.VerwaltungskostenNetto_SpinEdit.EditValue
        Dim p As Double = Me.VerwaltungskostenPercent_SpinEdit.EditValue
        Dim t As Double = Math.Round(n * p, 2)
        Me.VerwaltungskostenTotal_SpinEdit.EditValue = t
    End Sub

    Private Sub PivotGridControl1_FieldValueDisplayText(sender As Object, e As PivotFieldDisplayTextEventArgs) Handles PivotGridControl1.FieldValueDisplayText
        'If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total Then
        '    If e.IsColumn Then
        '        e.DisplayText = e.DisplayText.ToString.Replace("Total", "-") & "Zinsertrag"

        '    End If
        'End If

    End Sub

    Private Sub Ergebnis_SimpleLabelItem1_TextChanged(sender As Object, e As EventArgs) Handles Ergebnis_SimpleLabelItem1.TextChanged
        If Me.Ergebnis_SimpleLabelItem1.Text = "KEINE DROHVERLUSTRÜCKSTELLUNG" Then
            Me.Ergebnis_SimpleLabelItem1.AppearanceItemCaption.BackColor = Color.Green
            Me.Ergebnis_SimpleLabelItem1.AppearanceItemCaption.ForeColor = Color.White
        ElseIf Me.Ergebnis_SimpleLabelItem1.Text = "DROHVERLUSTRÜCKSTELLUNG" Then
            Me.Ergebnis_SimpleLabelItem1.AppearanceItemCaption.BackColor = Color.Red
            Me.Ergebnis_SimpleLabelItem1.AppearanceItemCaption.ForeColor = Color.White

        End If
    End Sub

    Private Sub GridView2_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView2.CustomDrawFooterCell
        Select Case e.Column.FieldName
            Case = "Barwert"
                Dim summary As DevExpress.XtraGrid.GridSummaryItem = e.Info.SummaryItem
                Dim summaryValue As Double = Convert.ToDouble(summary.SummaryValue)
                If summaryValue > 0 Then
                    e.Graphics.FillRectangle(Brushes.Green, e.Bounds)
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.Font = New System.Drawing.Font("Calibri", 10, FontStyle.Bold)


                ElseIf summaryValue < 0 Then
                    e.Graphics.FillRectangle(Brushes.Red, e.Bounds)
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.Font = New System.Drawing.Font("Calibri", 10, FontStyle.Bold)


                End If
        End Select

        'Dim summaryText As String = String.Format("{0} {1} = {2:c2}", summary.SummaryType, e.Column.GetCaption(), summaryValue)
        'e.Info.DisplayText = summaryText

    End Sub


End Class