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
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Utils

Public Class InterestRateRisk_Parameters

    Private BS_All_BUSINESS_DATE As BindingSource
    Private BS_All_SHOCK_BUSINESS_DATE As BindingSource
    Private BS_Currencies As BindingSource

    Friend WithEvents Bgw_IRR_ShockTypesValues_Calculation As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()


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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub InterestRateRisk_Parameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.RateRisk_StandardTimeBucketsTableAdapter.Fill(Me.InterestRateRiskDataSet.RateRisk_StandardTimeBuckets)
        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        'AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        ALL_SHOCK_BUSINESS_DATES_initData()
        ALL_SHOCK_BUSINESS_DATES_InitLookUp()
        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        If BS_All_BUSINESS_DATE.Count > 0 Then
            Me.RiskDate_SearchLookUpEdit.EditValue = CType(BS_All_BUSINESS_DATE.Current, DataRowView).Item(0).ToString
            rd = CDate(Me.RiskDate_SearchLookUpEdit.EditValue.ToString)
            Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
        End If
        If BS_All_SHOCK_BUSINESS_DATE.Count > 0 Then
            Me.ShockRiskDate_SearchLookUpEdit.EditValue = CType(BS_All_SHOCK_BUSINESS_DATE.Current, DataRowView).Item(0).ToString
            rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
            Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
            GET_STEEPENER_FLATTENER_A_B_VALUES()
        End If


        Me.TabbedControlGroup1.SelectedTabPageIndex = 0


    End Sub


    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    Select CONVERT(VARCHAR(10),[RiskDate],104) from [RateRisk_InterestRateSchocks] 
													GROUP BY [RiskDate] ORDER BY [RiskDate] desc
                                                    SELECT BUSINESS_DATE  from @SELECTION_TABLE 
                                                    order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBUSINESS_DATE As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBUSINESS_DATE.Fill(ds, "BUSINESS_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_BUSINESS_DATE = New BindingSource(ds, "BUSINESS_DATE")
    End Sub
    Private Sub ALL_BUSINESS_DATES_InitLookUp()
        Me.RiskDate_SearchLookUpEdit.Properties.DataSource = BS_All_BUSINESS_DATE
        Me.RiskDate_SearchLookUpEdit.Properties.DisplayMember = "BUSINESS_DATE"
        Me.RiskDate_SearchLookUpEdit.Properties.ValueMember = "BUSINESS_DATE"
    End Sub

    Private Sub ALL_SHOCK_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    Select CONVERT(VARCHAR(10),[RiskDate],104) from [RateRisk_ShockTypesValues] 
													GROUP BY [RiskDate] ORDER BY [RiskDate] desc
                                                    SELECT BUSINESS_DATE  from @SELECTION_TABLE 
                                                    order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbSHOCK_BUSINESS_DATE As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbSHOCK_BUSINESS_DATE.Fill(ds, "BUSINESS_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_SHOCK_BUSINESS_DATE = New BindingSource(ds, "BUSINESS_DATE")
    End Sub
    Private Sub ALL_SHOCK_BUSINESS_DATES_InitLookUp()
        Me.ShockRiskDate_SearchLookUpEdit.Properties.DataSource = BS_All_SHOCK_BUSINESS_DATE
        Me.ShockRiskDate_SearchLookUpEdit.Properties.DisplayMember = "BUSINESS_DATE"
        Me.ShockRiskDate_SearchLookUpEdit.Properties.ValueMember = "BUSINESS_DATE"
    End Sub

    Private Sub CURRENCIES_LIST_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT 
                                                    [CURRENCY CODE] as 'CurrencyCode'
                                                    ,[CURRENCY NAME] as 'CurrencyName'
                                                    FROM [OWN_CURRENCIES] where [VALID] in ('Y')", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCurrencies As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbCurrencies.Fill(ds, "OWN_CURRENCIES")

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
        BS_Currencies = New BindingSource(ds, "OWN_CURRENCIES")
    End Sub

    Private Sub GET_STEEPENER_FLATTENER_A_B_VALUES()
        rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
        rdsql1 = rd1.ToString("yyyyMMdd")
        QueryText = "Select top 1 B.ShockType as 'Steepener'
                     ,B.Value_A as 'Steepener_Value_A'
                     ,B.Value_B as 'Steepener_Value_B'
                     ,C.ShockType as 'Flattener'
                     ,C.Value_A as 'Flattener_Value_A'
                     ,C.Value_B as 'Flattener_Value_B' 
                     from RateRisk_ShockTypesValues A INNER JOIN RateRisk_ShockTypesValues B 
                     on A.RiskDate=B.RiskDate and B.ShockType in ('RotationShockSteepener_Plus')
                     INNER JOIN RateRisk_ShockTypesValues C 
                     on A.RiskDate=C.RiskDate and C.ShockType in ('RotationShockFlattener_Plus')
                     where A.RiskDate='" & rdsql1 & "' 
                     and A.ShockType in ('RotationShockSteepener_Plus','RotationShockFlattener_Plus')"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            RSS_A_SpinEdit.EditValue = dt.Rows.Item(0).Item("Steepener_Value_A").ToString
            RSS_B_SpinEdit.EditValue = dt.Rows.Item(0).Item("Steepener_Value_B").ToString
            RSF_A_SpinEdit.EditValue = dt.Rows.Item(0).Item("Flattener_Value_A").ToString
            RSF_B_SpinEdit.EditValue = dt.Rows.Item(0).Item("Flattener_Value_B").ToString
        End If

    End Sub

    Private Sub UPDATE_STEEPENER_FLATTENER_A_B_VALUES()
        rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
        rdsql1 = rd1.ToString("yyyyMMdd")
        OpenSqlConnections()
        cmd.CommandText = "DECLARE @RISKDATE Datetime='" & rdsql1 & "'
                           DECLARE @Steepener_Value_A float='" & Str(CDbl(RSS_A_SpinEdit.EditValue.ToString)) & "'
                           DECLARE @Steepener_Value_B float='" & Str(CDbl(RSS_B_SpinEdit.EditValue.ToString)) & "'
                           DECLARE @Flattener_Value_A float='" & Str(CDbl(RSF_A_SpinEdit.EditValue.ToString)) & "'
                           DECLARE @Flattener_Value_B float='" & Str(CDbl(RSF_B_SpinEdit.EditValue.ToString)) & "'

                           UPDATE RateRisk_ShockTypesValues 
                           SET Value_A=@Steepener_Value_A ,Value_B=@Steepener_Value_B 
                           where ShockType in ('RotationShockSteepener_Plus') and RiskDate=@RISKDATE

                           UPDATE RateRisk_ShockTypesValues 
                           SET Value_A=@Flattener_Value_A ,Value_B=@Flattener_Value_B 
                           where ShockType in ('RotationShockFlattener_Plus') and RiskDate=@RISKDATE"
        cmd.ExecuteNonQuery()

    End Sub
    Private Sub ShockRiskDate_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ShockRiskDate_SearchLookUpEdit.EditValueChanged
        If Me.ShockRiskDate_SearchLookUpEdit.Text <> "" AndAlso BS_All_BUSINESS_DATE.Count > 0 Then
            rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
            'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("Load interest rate shocks values for Business Date: " & rd)
            Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
            GET_STEEPENER_FLATTENER_A_B_VALUES()
            'SplashScreenManager.CloseForm(False)
        End If
    End Sub
    Private Sub RiskDate_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RiskDate_SearchLookUpEdit.EditValueChanged
        If Me.RiskDate_SearchLookUpEdit.Text <> "" AndAlso BS_All_BUSINESS_DATE.Count > 0 Then
            rd = CDate(Me.RiskDate_SearchLookUpEdit.EditValue.ToString)
            'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("Load interest rate shocks sizes for Business Date: " & rd)
            Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
            'SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ShockRiskDate_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ShockRiskDate_SearchLookUpEdit.ButtonClick
        'Add new Business Date
        If e.Button.Tag = 2 Then
            Try
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the new Business Date for the interest rate shock types"
                args.Prompt = "Business Date"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim editor As New DateEdit()
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
                editor.Properties.CalendarView = Repository.CalendarView.Vista
                editor.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
                editor.Properties.ShowClear = False
                editor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                editor.Properties.MinValue = DateSerial(2020, 1, 1)
                editor.Properties.MaxValue = DateSerial(9999, 12, 31)
                editor.Properties.NullDateCalendarValue = Today
                'editor.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rd1 = CDate(obj)
                    rdsql1 = rd1.ToString("yyyyMMdd")
                    OpenSqlConnections()
                    cmd.CommandText = "Select Count(ID) from [RateRisk_ShockTypesValues] where RiskDate='" & rdsql1 & "'"
                    If CInt(cmd.ExecuteScalar) = 0 Then
                        If XtraMessageBox.Show("Should the Business Date: " & rd1 & " be added into Table?", "ADD NEW BUSINESS DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            cmd.CommandText = "DECLARE @MAX_RISK_DATE Datetime
                                       SET @MAX_RISK_DATE=(Select Max(RiskDate) from RateRisk_ShockTypesValues)

                                        INSERT INTO [RateRisk_ShockTypesValues]
                                                   ([ShockType]
                                                   ,[CCY]
                                                   ,[1D]
                                                   ,[1M]
                                                   ,[3M]
                                                   ,[6M]
                                                   ,[9M]
                                                   ,[1Y]
                                                   ,[2Y]
                                                   ,[3Y]
                                                   ,[4Y]
                                                   ,[5Y]
                                                   ,[6Y]
                                                   ,[7Y]
                                                   ,[8Y]
                                                   ,[9Y]
                                                   ,[10Y]
                                                   ,[15Y]
                                                   ,[20Y]
                                                   ,[30Y]
                                                   ,[40Y]
                                                   ,[50Y]
                                                   ,[Value_A]
                                                   ,[Value_B]
                                                   ,[LastAction]
                                                   ,[LastUpdateUser]
                                                   ,[LastUpdateDate]
                                                   ,[RiskDate])
                                        SELECT 
                                                    [ShockType]
                                                   ,[CCY]
                                                   ,[1D]
                                                   ,[1M]
                                                   ,[3M]
                                                   ,[6M]
                                                   ,[9M]
                                                   ,[1Y]
                                                   ,[2Y]
                                                   ,[3Y]
                                                   ,[4Y]
                                                   ,[5Y]
                                                   ,[6Y]
                                                   ,[7Y]
                                                   ,[8Y]
                                                   ,[9Y]
                                                   ,[10Y]
                                                   ,[15Y]
                                                   ,[20Y]
                                                   ,[30Y]
                                                   ,[40Y]
                                                   ,[50Y]
                                                   ,[Value_A]
                                                   ,[Value_B]
                                                   ,'ADD'
                                                   ,'" & CurrentUserWindowsID & "'
                                                   ,GETDATE()
                                                    ,'" & rdsql1 & "'
                                                   from RateRisk_ShockTypesValues
                                                   where RiskDate=@MAX_RISK_DATE"
                            cmd.ExecuteNonQuery()
                            ALL_SHOCK_BUSINESS_DATES_initData()
                            ALL_SHOCK_BUSINESS_DATES_InitLookUp()

                            'Get all values from BindingSource
                            'For i As Integer = 0 To BS_All_BUSINESS_DATE.Count - 1
                            '    MsgBox(CType(BS_All_BUSINESS_DATE.List(i), DataRowView).Item(0).ToString)
                            'Next

                            Dim NewID As Integer = BS_All_SHOCK_BUSINESS_DATE.Find("BUSINESS_DATE", rd1.ToString("dd.MM.yyyy"))
                            Me.ShockRiskDate_SearchLookUpEdit.EditValue = CType(BS_All_SHOCK_BUSINESS_DATE.List(NewID), DataRowView).Item(0).ToString
                            CloseSqlConnections()
                            XtraMessageBox.Show("Business Date: " & rd1 & " added successfull in the Interest Rate Shocks types Table", "NEW BUSINESS DATE ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If


                    ElseIf CInt(cmd.ExecuteScalar) <> 0 Then
                        XtraMessageBox.Show("Business Date: " & rd1 & " already included in the Interest Rate Shocks types Table", "UNABLE TO ADD NEW BUSINESS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    CloseSqlConnections()
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete BusinessDate
        If e.Button.Tag = 4 Then
            Try
                rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
                rdsql1 = rd1.ToString("yyyyMMdd")
                OpenSqlConnections()
                cmd.CommandText = "Select COUNT(A.BusinessDates) from (Select RiskDate as BusinessDates from [RateRisk_ShockTypesValues] GROUP BY RiskDate)A"
                If CInt(cmd.ExecuteScalar) > 1 Then
                    If XtraMessageBox.Show("Should the Business Date: " & rd1 & " be deleted from the Table?", "DELETE BUSINESS DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        cmd.CommandText = "DECLARE @RISKDATE Datetime='" & rdsql1 & "'
                                           DELETE FROM [RateRisk_ShockTypesValues] where [RiskDate]=@RISKDATE"
                        cmd.ExecuteNonQuery()
                        ALL_SHOCK_BUSINESS_DATES_initData()
                        ALL_SHOCK_BUSINESS_DATES_InitLookUp()
                        If BS_All_SHOCK_BUSINESS_DATE.Count > 0 Then
                            Me.ShockRiskDate_SearchLookUpEdit.EditValue = CType(BS_All_SHOCK_BUSINESS_DATE.Current, DataRowView).Item(0).ToString
                        End If
                        CloseSqlConnections()
                        XtraMessageBox.Show("Business Date: " & rd1 & " was deleted from the Interest Rate Shocks types Table", "BUSINESS DATE DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                ElseIf CInt(cmd.ExecuteScalar) = 1 Then
                    XtraMessageBox.Show("Unable to delete Business Date: " & rd1 & vbNewLine & "At least one Business Date must pe present for the Interest Rate risk calculation (EVE Method)!", "UNABLE TO DELETE BUSINESS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If
                CloseSqlConnections()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        If e.Button.Tag = 6 Then
            If XtraMessageBox.Show("Should the Changes be saved and all shock types recalculated for Business Date: " & rd1 & " ?", "SAVE CHANGES - RECALCULATE SHOCK TYPES VALUES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
                rdsql1 = rd.ToString("yyyyMMdd")
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Save changes and recalculate shock types values for " & rd1)
                    UPDATE_STEEPENER_FLATTENER_A_B_VALUES()
                    Bgw_IRR_ShockTypesValues_Calculation = New BackgroundWorker
                    Bgw_IRR_ShockTypesValues_Calculation.WorkerReportsProgress = True
                    Bgw_IRR_ShockTypesValues_Calculation.RunWorkerAsync()

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Else
                Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
                GET_STEEPENER_FLATTENER_A_B_VALUES()
            End If

        End If

    End Sub

    Private Sub Bgw_IRR_ShockTypesValues_Calculation_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bgw_IRR_ShockTypesValues_Calculation.DoWork
        Try
            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                         in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('INTEREST_RATE_RISK_SHOCK_TYPE_VALUES_CALCULATION') 
                         and  Id_SQL_Parameters in ('SEVERAL SELECTIONS'))"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For s = 0 To dt.Rows.Count - 1
                    ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                    If ScriptType = "SQL" Then
                        SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql1)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    ElseIf ScriptType = "VB" Then
                        Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd1).ToString.Replace("<rdsql>", rdsql1).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                        Dim entry As String = "VB_ScriptForExecution"
                        If code = "" Then Return
                        If entry = "" Then entry = "VB_ScriptForExecution"
                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                        engine.Run()
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/INTEREST_RATE_RISK_SHOCK_TYPE_VALUES_CALCULATION", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            Bgw_IRR_ShockTypesValues_Calculation.CancelAsync()
        End Try

    End Sub

    Private Sub Bgw_IRR_ShockTypesValues_Calculation_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Bgw_IRR_ShockTypesValues_Calculation.RunWorkerCompleted
        If e.Cancelled = False Then
            Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
            GET_STEEPENER_FLATTENER_A_B_VALUES()
            SplashScreenManager.CloseForm(False)
        Else
            Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
            GET_STEEPENER_FLATTENER_A_B_VALUES()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub RiskDate_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RiskDate_SearchLookUpEdit.ButtonClick
        'Add new Business Date
        If e.Button.Tag = 2 Then
            Try
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the new Business Date for the interest rate shock sizes"
                args.Prompt = "Business Date"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim editor As New DateEdit()
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
                editor.Properties.CalendarView = Repository.CalendarView.Vista
                editor.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
                editor.Properties.ShowClear = False
                editor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                editor.Properties.MinValue = DateSerial(2020, 1, 1)
                editor.Properties.MaxValue = DateSerial(9999, 12, 31)
                editor.Properties.NullDateCalendarValue = Today
                'editor.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rd = CDate(obj)
                    rdsql = rd.ToString("yyyyMMdd")
                    OpenSqlConnections()
                    cmd.CommandText = "Select Count(ID) from [RateRisk_InterestRateSchocks] where RiskDate='" & rdsql & "' GROUP BY RiskDate"
                    If CInt(cmd.ExecuteScalar) = 0 Then
                        If XtraMessageBox.Show("Should the Business Date: " & rd & " be added into Table?", "ADD NEW BUSINESS DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            cmd.CommandText = "DECLARE @MAX_RISK_DATE Datetime
                                       SET @MAX_RISK_DATE=(Select Max(RiskDate) from RateRisk_InterestRateSchocks)

                                        INSERT INTO [RateRisk_InterestRateSchocks]
                                           ([CCY]
                                           ,[IRS_Type]
                                           ,[IRS_Value]
                                           ,[RiskDate]
                                           ,[LastAction]
                                           ,[LastUpdateUser]
                                           ,[LastUpdateDate])
                                        SELECT 
                                            [CCY]
                                           ,[IRS_Type]
                                           ,[IRS_Value]
                                           ,'" & rdsql & "'
                                           ,'ADD'
                                           ,'" & CurrentUserWindowsID & "'
                                           ,GETDATE()
                                           from RateRisk_InterestRateSchocks
                                           where RiskDate=@MAX_RISK_DATE"
                            cmd.ExecuteNonQuery()
                            ALL_BUSINESS_DATES_initData()
                            ALL_BUSINESS_DATES_InitLookUp()

                            'Get all values from BindingSource
                            'For i As Integer = 0 To BS_All_BUSINESS_DATE.Count - 1
                            '    MsgBox(CType(BS_All_BUSINESS_DATE.List(i), DataRowView).Item(0).ToString)
                            'Next

                            Dim NewID As Integer = BS_All_BUSINESS_DATE.Find("BUSINESS_DATE", rd.ToString("dd.MM.yyyy"))
                            Me.RiskDate_SearchLookUpEdit.EditValue = CType(BS_All_BUSINESS_DATE.List(NewID), DataRowView).Item(0).ToString
                            CloseSqlConnections()
                            XtraMessageBox.Show("Business Date: " & rd & " added successfull in the Interest Rate Shocks Table", "NEW BUSINESS DATE ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If


                    ElseIf CInt(cmd.ExecuteScalar) <> 0 Then
                        XtraMessageBox.Show("Business Date: " & rd & " already included in the Interest Rate Shocks Table", "UNABLE TO ADD NEW BUSINESS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    CloseSqlConnections()
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete BusinessDate
        If e.Button.Tag = 4 Then
            Try
                rd = CDate(Me.RiskDate_SearchLookUpEdit.EditValue.ToString)
                rdsql = rd.ToString("yyyyMMdd")
                OpenSqlConnections()
                cmd.CommandText = "Select COUNT(A.BusinessDates) from (Select RiskDate as BusinessDates from [RateRisk_InterestRateSchocks] GROUP BY RiskDate)A"
                If CInt(cmd.ExecuteScalar) > 1 Then
                    If XtraMessageBox.Show("Should the Business Date: " & rd & " be deleted from the Table?", "DELETE BUSINESS DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        cmd.CommandText = "DECLARE @RISKDATE Datetime='" & rdsql & "'
                                           DELETE FROM [RateRisk_InterestRateSchocks] where [RiskDate]=@RISKDATE"
                        cmd.ExecuteNonQuery()
                        ALL_BUSINESS_DATES_initData()
                        ALL_BUSINESS_DATES_InitLookUp()
                        If BS_All_BUSINESS_DATE.Count > 0 Then
                            Me.RiskDate_SearchLookUpEdit.EditValue = CType(BS_All_BUSINESS_DATE.Current, DataRowView).Item(0).ToString
                        End If
                        CloseSqlConnections()
                        XtraMessageBox.Show("Business Date: " & rd & " was deleted from the Interest Rate Shocks Table", "BUSINESS DATE DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                ElseIf CInt(cmd.ExecuteScalar) = 1 Then
                    XtraMessageBox.Show("Unable to delete Business Date: " & rd & vbNewLine & "At least one Business Date must pe present for the Interest Rate risk calculation (EVE Method)!", "UNABLE TO DELETE BUSINESS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If
                CloseSqlConnections()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Add new CCY
        If e.Button.Tag = 6 Then
            Try
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the new currency into the interest rate shock sizes"
                args.Prompt = "Currency"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim CurrenciesList As New SearchLookUpEdit()
                CurrenciesList.Properties.PopupFormSize = New Size(500, 200)
                Dim CurrencyCode As GridColumn = CurrenciesList.Properties.View.Columns.AddField("CurrencyCode")
                CurrencyCode.FieldName = "CurrencyCode"
                CurrencyCode.Width = 100
                CurrencyCode.Visible = True
                Dim CurrencyName As GridColumn = CurrenciesList.Properties.View.Columns.AddField("CurrencyName")
                CurrencyName.FieldName = "CurrencyName"
                CurrencyName.Width = 300
                CurrencyName.Visible = True
                CurrenciesList.Properties.ShowClearButton = False
                CurrenciesList.Properties.View.OptionsView.ColumnAutoWidth = False
                CurrenciesList.Properties.View.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True
                CurrenciesList.Properties.View.OptionsView.ShowAutoFilterRow = True
                CurrenciesList.Properties.View.BestFitColumns()

                CURRENCIES_LIST_initData()

                CurrenciesList.Properties.DataSource = BS_Currencies
                CurrenciesList.Properties.DisplayMember = "CurrencyCode"
                CurrenciesList.Properties.ValueMember = "CurrencyCode"
                args.Editor = CurrenciesList

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                Else
                    Dim CCY As String = CurrenciesList.EditValue.ToString
                    rd = CDate(Me.RiskDate_SearchLookUpEdit.EditValue.ToString)
                    rdsql = rd.ToString("yyyyMMdd")
                    OpenSqlConnections()
                    cmd.CommandText = "Select Count(ID) from [RateRisk_InterestRateSchocks] where RiskDate='" & rdsql & "' and CCY='" & CCY & "'"
                    If CInt(cmd.ExecuteScalar) = 0 Then
                        If XtraMessageBox.Show("Should the currency code: " & CCY & " be added for Business Date: " & rd & " into Table?", "ADD NEW CURRENCY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            cmd.CommandText = "DECLARE @RISKDATE Datetime='" & rdsql & "'
                                               DECLARE @CCY Nvarchar(50)='" & CCY & "'

                                            INSERT INTO [RateRisk_InterestRateSchocks]
                                               ([CCY]
                                               ,[IRS_Type]
                                               ,[IRS_Value]
                                               ,[RiskDate]
                                               ,[LastAction]
                                               ,[LastUpdateUser]
                                               ,[LastUpdateDate])
                                            SELECT 
                                                DISTINCT
                                                @CCY
                                               ,IRS_Type
                                               ,0
                                               ,@RISKDATE
                                               ,'ADD'
                                               ,'" & CurrentUserWindowsID & "'
                                               ,GETDATE()
                                               from RateRisk_InterestRateSchocks
                                               where RiskDate=@RISKDATE"
                            cmd.ExecuteNonQuery()
                            CloseSqlConnections()
                            Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
                            XtraMessageBox.Show("Currency code: " & CCY & " for Business Date: " & rd & " added successfull in the Interest Rate Shocks Table", "NEW CURRENCY ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If


                    ElseIf CInt(cmd.ExecuteScalar) <> 0 Then
                        XtraMessageBox.Show("Currency code: " & CCY & " for Business Date: " & rd & " already included in the Interest Rate Shocks Table", "UNABLE TO ADD CURRENCY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                    CloseSqlConnections()
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        If e.Button.Tag = 8 Then
            If Me.InterestRateRiskDataSet.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Me.RateRisk_InterestRateSchocksBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.InterestRateRiskDataSet)
                        Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    Me.RateRisk_InterestRateSchocksBindingSource.CancelEdit()
                    Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
                End If

            End If

        End If

    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
        'e.Form.CancelButton.DialogResult = DialogResult.None
        e.Form.CloseBox = False
        If e.Form.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        If e.Form.DialogResult = DialogResult.OK Then
            Exit Sub
        End If
    End Sub

    Private Sub bbi_Reload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Reload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Reload Data")

        ALL_SHOCK_BUSINESS_DATES_initData()
        ALL_SHOCK_BUSINESS_DATES_InitLookUp()
        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        If Me.RiskDate_SearchLookUpEdit.Text <> "" AndAlso BS_All_BUSINESS_DATE.Count > 0 Then
            rd = CDate(Me.RiskDate_SearchLookUpEdit.EditValue.ToString)
            Me.RateRisk_InterestRateSchocksTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_InterestRateSchocks, rd)
            Me.RateRisk_StandardTimeBucketsTableAdapter.Fill(Me.InterestRateRiskDataSet.RateRisk_StandardTimeBuckets)
        End If
        If Me.ShockRiskDate_SearchLookUpEdit.Text <> "" AndAlso BS_All_SHOCK_BUSINESS_DATE.Count > 0 Then
            rd1 = CDate(Me.ShockRiskDate_SearchLookUpEdit.EditValue.ToString)
            Me.RateRisk_ShockTypesValuesTableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RateRisk_ShockTypesValues, rd1)
            GET_STEEPENER_FLATTENER_A_B_VALUES()
        End If
        SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub bbi_PrintOrExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintOrExport.ItemClick
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 0 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 1 Then
            If Not Me.PivotGridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If Me.TabbedControlGroup1.SelectedTabPageIndex = 2 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink4.CreateDocument()
            PrintableComponentLink4.ShowPreview()
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
        Dim reportfooter As String = "Interest Rate Risk - Shock types and values on " & Me.ShockRiskDate_SearchLookUpEdit.Text
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
        Dim reportfooter As String = "Size of interest rate shocks on " & Me.RiskDate_SearchLookUpEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "Standard Time Buckets (acc. to SRP 31.96)"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

    Private Sub pivotGridControl1_EditValueChanged(ByVal sender As Object,
                                                           ByVal e As EditValueChangedEventArgs) _
                                                       Handles PivotGridControl1.EditValueChanged
        Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
        ds.SetValue(0, "IRS_Value", e.Editor.EditValue)
    End Sub

    Private Sub RateShockTypesValues_BandedGridView_CustomColumnSort(sender As Object, e As CustomColumnSortEventArgs) Handles RateShockTypesValues_BandedGridView.CustomColumnSort
        If e.Column.FieldName = "ShockType" Then
            Dim ShockType1 As String = e.Value1.ToString
            Dim ShockType2 As String = e.Value2.ToString

            If ShockType1 = "ParallelShock_PlusMinus" Then
                e.Result = 0
            ElseIf ShockType1 = "ShortRateShock_PlusMinus" Then
                e.Result = 1
            ElseIf ShockType1 = "LongRateShock" Then
                e.Result = 2
            ElseIf ShockType1 = "RotationShockSteepener_Plus" Then
                e.Result = 3
            ElseIf ShockType1 = "RotationShockFlattener_Plus" Then
                e.Result = 4
            Else
                e.Result = Comparer.Default.Compare(ShockType1, ShockType2)
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub RateShockTypesValues_BandedGridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles RateShockTypesValues_BandedGridView.EditFormPrepared
        If e.BindableControls(RateShockTypesValues_BandedGridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(RateShockTypesValues_BandedGridView.FocusedColumn)
        End If
    End Sub

    Private Sub StandardTimeBuckets_BandedGridView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles StandardTimeBuckets_BandedGridView.EditFormPrepared
        If e.BindableControls(StandardTimeBuckets_BandedGridView.FocusedColumn) IsNot Nothing Then
            e.FocusField(StandardTimeBuckets_BandedGridView.FocusedColumn)
        End If
    End Sub
End Class