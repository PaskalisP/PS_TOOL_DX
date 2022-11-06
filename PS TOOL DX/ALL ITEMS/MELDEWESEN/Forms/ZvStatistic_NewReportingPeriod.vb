Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Helpers
Imports System.ComponentModel.DataAnnotations
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraReports.Parameters
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Data
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports Ionic.Zip
Public Class ZvStatistic_NewReportingPeriod
    Dim rd As Date = Nothing
    Dim rdsql As String = rd.ToString("yyyyMMdd")
    Dim SqlLfdNr As String = Nothing

    Dim ReportDay As String = rd.ToString("dd")
    Dim ReportMonth As String = rd.ToString("MM")
    Dim ReportYear As String = rd.ToString("yyyy")

    Dim CurrDate As Date = Now
    Dim CurrDateYear As String = Now.ToString("yy")
    Dim CurrDateMonth As String = Now.ToString("MM")
    Dim CurrDateDay As String = Now.ToString("dd")
    Dim CurrDateHour As String = Now.ToString("HH")
    Dim CurrDateMinute As String = Now.ToString("mm")
    Dim CurrDateSecond As String = Now.ToString("ss")


    Dim Abacus930XmlFileName As String = Nothing
    Dim Abacus907XmlFileName As String = Nothing
    Dim Abacus966XmlFileName As String = Nothing

    Dim MyWriter As System.Xml.XmlWriter
    Dim MySettings As New System.Xml.XmlWriterSettings

    Private BS_All_ZvMeldeschemas As BindingSource
    Public ZvReporting As New ZvStatistikReporting




    Public Sub ZvStatistic_NewReportingPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load
        ALL_ZV_MELDESCHEMAS_initData()
        ALL_ZV_MELDESCHEMAS_InitLookUp()

        Me.ZvMeldeschemas_SearchLookUpEdit.EditValue = CType(BS_All_ZvMeldeschemas.Current, DataRowView).Item(0).ToString
        Me.LayoutControlItem1.Visibility = LayoutVisibility.Never

    End Sub

    Private Sub ALL_ZV_MELDESCHEMAS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table
                                                ([ID] int IDENTITY(1,1) NOT NULL
                                                ,[ZV_MELDESCHEMA] nvarchar(50) NULL
                                                ,[ZV_MELDESCHEMA_DESCRIPTION] nvarchar(100) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT [ZVSTA_Schema],
                                                    'ZV_MELDESCHEMA_DESCRIPTION'=CASE when [ZVSTA_Schema] like '%Q' then 'QUARTERLY' 
                                                                                      when [ZVSTA_Schema] like '%H' then 'HALFYEARLY' 
                                                                                      else 'YEARLY' end
                                                    FROM    [ZVSTAT_Parameters_from2014] 
													--WHERE [dbo].[fn_StripCharacters]([ZVSTA_Schema],'^0-9')>2020
													GROUP BY [ZVSTA_Schema] ORDER BY [ZVSTA_Schema] asc
                                                    SELECT [ZV_MELDESCHEMA],[ZV_MELDESCHEMA_DESCRIPTION]  from @SELECTION_TABLE 
                                                    order by ID desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbZvMeldeschemas As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbZvMeldeschemas.Fill(ds, "ZV_MELDESCHEMAS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_ZvMeldeschemas = New BindingSource(ds, "ZV_MELDESCHEMAS")
    End Sub
    Private Sub ALL_ZV_MELDESCHEMAS_InitLookUp()
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.DataSource = BS_All_ZvMeldeschemas
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.DisplayMember = "ZV_MELDESCHEMA"
        Me.ZvMeldeschemas_SearchLookUpEdit.Properties.ValueMember = "ZV_MELDESCHEMA"


    End Sub

    Private Sub ZvMeldeschemas_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ZvMeldeschemas_SearchLookUpEdit.EditValueChanged
        Dim ZVM As String = Me.ZvMeldeschemas_SearchLookUpEdit.EditValue.ToString
        If ZVM.EndsWith("Q") Then
            Me.ZvMeldeperiod_ComboboxEdit.EditValue = Nothing
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Clear()
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("1.Quartal")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("2.Quartal")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("3.Quartal")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("4.Quartal")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.ReadOnly = False
        ElseIf ZVM.EndsWith("H") Then
            Me.ZvMeldeperiod_ComboboxEdit.EditValue = Nothing
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Clear()
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("1.Halbjahr")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("2.Halbjahr")
            Me.ZvMeldeperiod_ComboboxEdit.Properties.ReadOnly = False
        Else
            Me.ZvMeldeperiod_ComboboxEdit.EditValue = Nothing
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Clear()
            Me.ZvMeldeperiod_ComboboxEdit.Properties.Items.Add("1.Jährlich")
            Me.ZvMeldeperiod_ComboboxEdit.SelectedIndex = 0
            'Me.ZvMeldeperiod_ComboboxEdit.Properties.EditValue.ToString = Me.ZvMeldeperiod_ComboboxEdit.Properties.Items(0).ToString
            Me.ZvMeldeperiod_ComboboxEdit.Properties.ReadOnly = True
        End If
    End Sub


    Public Sub ZVSTA_QUARTERLY_CREATE(ByVal ZVSTA_MELDESCHEMA As String, ByVal ZVSTA_MELDEPERIODE As String)
        Try

            SplashScreenManager.ShowForm(Me.ZvReporting, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
            SplashScreenManager.Default.SetWaitFormCaption("Start adding new ZVSTA Report with Schema " & ZVSTA_MELDESCHEMA & " and reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)

            SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Parameter: ZV_STAT\ZVSTAT_QUARTERLY_REPORTING_SCHEME")
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_QUARTERLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
            Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_QUARTERLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_MELDESCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_MELDEPERIODE)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                        System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                        SqlLfdNr = CStr(dt.Rows.Item(i).Item("SQL_Float_1").ToString)
                        cmd.ExecuteNonQuery()
                        'Add to Events
                        cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_QUARTERLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
                        cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = "Command Nr. " & SqlLfdNr & " executed successful"
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next

            End If

            SplashScreenManager.CloseForm(False)



        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Add to Events
            OpenSqlConnections()
            cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_QUARTERLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
            cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = ex.Message & vbNewLine & "Command Nr. " & SqlLfdNr & " failed"
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            CloseSqlConnections()

            Return
        End Try
    End Sub

    Public Sub ZVSTA_HALFYEARLY_CREATE(ByVal ZVSTA_MELDESCHEMA As String, ByVal ZVSTA_MELDEPERIODE As String)
        Try

            SplashScreenManager.ShowForm(Me.ZvReporting, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
            SplashScreenManager.Default.SetWaitFormCaption("Start adding new ZVSTA Report with Schema " & ZVSTA_MELDESCHEMA & " and reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)

            SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Parameter: ZV_STAT\ZVSTAT_HALFYEARLY_REPORTING_SCHEME")
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_HALFYEARLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
            Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_HALFYEARLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_MELDESCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_MELDEPERIODE)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                        System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                        SqlLfdNr = CStr(dt.Rows.Item(i).Item("SQL_Float_1").ToString)
                        cmd.ExecuteNonQuery()
                        'Add to Events
                        cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_HALFYEARLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
                        cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = "Command Nr. " & SqlLfdNr & " executed successful"
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next

            End If

            SplashScreenManager.CloseForm(False)



        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Add to Events
            OpenSqlConnections()
            cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_HALFYEARLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
            cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = ex.Message & vbNewLine & "Command Nr. " & SqlLfdNr & " failed"
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            CloseSqlConnections()
            Return
        End Try
    End Sub

    Public Sub ZVSTA_2014_YEARLY_CREATE(ByVal ZVSTA_MELDESCHEMA As String, ByVal ZVSTA_MELDEPERIODE As String)
        Try

            SplashScreenManager.ShowForm(Me.ZvReporting, GetType(WaitForm1), False, False, True, SplashFormStartPosition.Default)
            SplashScreenManager.Default.SetWaitFormCaption("Start adding new ZVSTA Report with Schema " & ZVSTA_MELDESCHEMA & " and reporting Period: " & ZVSTA_MELDEPERIODE)
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)

            SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Parameter: ZV_STAT\ZVSTAT_2014_YEARLY_REPORTING_SCHEME")
            System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
            cmd.CommandText = "Select [Status] FROM SQL_PARAMETER_DETAILS where  [SQL_Name_1] In ('ZVSTAT_2014_YEARLY_REPORTING_SCHEME') and [Id_SQL_Parameters] in ('ZV_STAT')"
            Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
            If ParameterStatus = "Y" Then
                QueryText = "Select * from SQL_PARAMETER_DETAILS_SECOND  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ZVSTAT_2014_YEARLY_REPORTING_SCHEME')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<ZV_MELDESCHEMA>", ZVSTA_MELDESCHEMA).ToString.Replace("<ZV_MELDEPERIODE>", ZVSTA_MELDEPERIODE)
                    cmd.CommandText = SqlCommandText
                    If dt.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                        System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1").ToString)
                        SqlLfdNr = CStr(dt.Rows.Item(i).Item("SQL_Float_1").ToString)
                        cmd.ExecuteNonQuery()
                        'Add to Events
                        cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_2014_YEARLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
                        cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = "Command Nr. " & SqlLfdNr & " executed successful"
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next

            End If

            SplashScreenManager.CloseForm(False)



        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.SmartTextWrap = True
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Add to Events
            OpenSqlConnections()
            cmd.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) Values(GETDATE(),@Event,'ZVSTAT_HALFYEARLY_REPORTING_SCHEME','ZV_STATISTIK','" & CurrentUserWindowsID & "')"
            cmd.Parameters.Add("@Event", SqlDbType.NVarChar).Value = ex.Message & vbNewLine & "Command Nr. " & SqlLfdNr & " failed"
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            CloseSqlConnections()

            Return
        End Try
    End Sub

End Class
