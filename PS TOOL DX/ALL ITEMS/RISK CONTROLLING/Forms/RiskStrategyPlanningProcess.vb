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
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Globalization
Imports DevExpress.Spreadsheet

Public Class RiskStrategyPlanningProcess

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim BusinessTypeClientGroup As String = Nothing
    Private BS_BusinessDates As BindingSource
    Friend WithEvents BgwExcelLoad As BackgroundWorker
    Dim currentSqlcommandNr As Integer = 0

    Dim ID_Totals As Integer = 0


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

    Private Sub RiskStrategyPlanningProcess_DateBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RiskStrategyPlanningProcess_DateBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskStrategyPlanningProcessDataset)

    End Sub

    Private Sub RiskStrategyPlanningProcess_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.LayoutControl3.Visible = True
            'Me.RiskStrategyPlanningProcess_DetailsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details)
            'Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails)
            'Me.RiskStrategyPlanningProcess_TotalsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals)
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load all dates")
            Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

   

    Private Sub RiskStrategyPlanningProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        CloseSqlConnections()
        '***********************************************************************
        'Bind Combobox

        'Me.AnalysisDate_Comboedit.Properties.Items.Clear()
        'QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RiskDate' from [UNEXPECTED_LOSS_DATE] ORDER BY [ID] desc"
        'da = New SqlDataAdapter(QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'For Each row As DataRow In dt.Rows
        '    If dt.Rows.Count > 0 Then
        '        Me.AnalysisDate_Comboedit.Properties.Items.Add(row("RiskDate"))
        '    End If
        'Next

        'Bind Business Types lookUpEdit
        Dim bs_BusinessTypes As BindingSource
        Dim ds As DataSet = New DataSet()
        Dim db_BusinessTypesParam As SqlDataAdapter = New SqlDataAdapter("Select [PARAMETER1] as 'Business Type',[PARAMETER2] as 'Client Group' from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RISK_STRATEGY_PLANNING_GROUPS' and [PARAMETER STATUS]='Y' Order by [ID] asc", conn)
        db_BusinessTypesParam.Fill(ds, "PARAMETER")
        bs_BusinessTypes = New BindingSource(ds, "PARAMETER")
        Me.BusinessType_LookUpEdit.Properties.DataSource = bs_BusinessTypes
        Me.BusinessType_LookUpEdit.Properties.DisplayMember = "Business Type"
        Me.BusinessType_LookUpEdit.Properties.ValueMember = "Business Type"
        Me.BusinessType_LookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        Me.BusinessType_LookUpEdit.Properties.SearchMode = SearchMode.AutoComplete

        'Bind obligor Rate LookUpEdit
        Dim bs_ObligorRate As BindingSource
        Dim ds1 As DataSet = New DataSet()
        Dim db_ObligorRate As SqlDataAdapter = New SqlDataAdapter("Select [Obligor Grade] as 'Obligor Rate',[PD] as 'PD' , [CoreDefinition] as 'Core Definition', [StandardPoorsRating] as ' S & P Ratting', [MoodysRating] as 'Moodys Ratting', [FitchRating] as 'Fitch Ratting' from [PD]  Order by [ID] asc", conn)
        db_ObligorRate.Fill(ds1, "PD")
        bs_ObligorRate = New BindingSource(ds1, "PD")
        Me.ObligorRate_LookUpEdit.Properties.DataSource = bs_ObligorRate
        Me.ObligorRate_LookUpEdit.Properties.DisplayMember = "Obligor Rate"
        Me.ObligorRate_LookUpEdit.Properties.ValueMember = "Obligor Rate"
        Me.ObligorRate_LookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        Me.ObligorRate_LookUpEdit.Properties.SearchMode = SearchMode.AutoComplete

        Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)

    End Sub

    Private Sub BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RiskDate],104) as 'BusinessDate' from [UNEXPECTED_LOSS_DATE] ORDER BY [RiskDate] desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "BusinessDate")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_BusinessDates = New BindingSource(ds, "BusinessDate")
    End Sub


    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "AddNewBTG" Then
            Me.XtraTabControl1.Visible = False
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        cd = Me.CreationDate_lbl.Text
        cdsql = cd.ToString("yyyyMMdd")

        If e.Button.Tag = "AddNewBTG" Then
            Me.XtraTabControl1.Visible = False
        End If
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.RiskStrategyPlanningProcess_AllDetailsBindingSource.EndEdit()
                If Me.RiskStrategyPlanningProcessDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskStrategyPlanningProcessDataset)
                        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                    Else
                        e.Handled = True
                    End If
                End If

            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.RiskStrategyPlanningProcess_AllDetailsBindingSource.CancelEdit()
                RiskStrategyPlanningProcessDataset.RejectChanges()
                Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                Exit Sub
            End Try
        End If

        'Delete Row
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Me.RiskStrategyPlanningProcess_AllDetailsBindingSource.CancelEdit()
            Dim row As System.Data.DataRow = CreditRisk_AllDetailsView.GetDataRow(CreditRisk_AllDetailsView.FocusedRowHandle)
            Dim InputType As String = Me.CreditRisk_AllDetailsView.GetRowCellValue(Me.CreditRisk_AllDetailsView.FocusedRowHandle, colInputType)
            Dim ID_ProcName As String = row(0)

            If InputType = "M" Then
                If XtraMessageBox.Show("Should the selected row ID: " & ID_ProcName & " be deleted?", "DELETE MANUAL INPUTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim ProcNameDelete As RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetailsRow
                    ProcNameDelete = RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails.FindByID(ID_ProcName)
                    ProcNameDelete.Delete()
                    CreditRisk_AllDetailsView.DeleteSelectedRows()
                    Me.TableAdapterManager.UpdateAll(Me.RiskStrategyPlanningProcessDataset)
                    'Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)

                    'Try
                    'If cmd.Connection.State = ConnectionState.Closed Then
                    'cmd.Connection.Open()
                    'End If
                    'cmd.CommandText = "DELETE FROM [RiskStrategyPlanningProcess_Details] where [ID]='" & ID_ProcName & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.Connection.Close()
                    'Catch ex As Exception
                    'MessageBox.Show(ex.Message, "UNABLE TO DELETE MANUAL INPUTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'e.Handled = True
                    'Exit Sub
                    'End Try

                    'Remove Row from grid
                    'row.Delete()


                    'Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                Else
                    e.Handled = True
                End If
            Else
                XtraMessageBox.Show("Unable to delete selected row! Inputy Type is not Manual (M)", "UNABLE TO DELETE MANUAL INPUTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                e.Handled = True
                Exit Sub

            End If
        End If



        'Cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.RiskStrategyPlanningProcess_AllDetailsBindingSource.CancelEdit()
            RiskStrategyPlanningProcessDataset.RejectChanges()
            Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
        End If
    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub
    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)

        If e.Button.Tag = "CreateNewRSPP" Then
            ' initialize a new XtraInputBoxArgs instance
            Dim args As New XtraInputBoxArgs()
            ' set required Input Box options
            args.Caption = "Create new Risk Strategy Planning"
            args.Prompt = "Select Business Date data"
            args.DefaultButtonIndex = 0

            AddHandler args.Showing, AddressOf Args_Showing
            ' initialize a DateEdit editor with custom settings
            Dim BusinessDate_SearchLookUpEdit As New SearchLookUpEdit()
            BusinessDate_SearchLookUpEdit.Properties.PopupFormSize = New Size(200, 400)
            BusinessDate_SearchLookUpEdit.Properties.ShowClearButton = False
            Dim BusinessDate As GridColumn = BusinessDate_SearchLookUpEdit.Properties.View.Columns.AddField("Business Dates")
            BusinessDate.FieldName = "BusinessDate"
            BusinessDate.Width = 100
            BusinessDate.Visible = True

            BusinessDate_SearchLookUpEdit.Properties.View.OptionsView.ColumnAutoWidth = False
            BusinessDate_SearchLookUpEdit.Properties.View.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True
            BusinessDate_SearchLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = True
            BusinessDate_SearchLookUpEdit.Properties.View.BestFitColumns()

            BUSINESS_DATES_initData()

            BusinessDate_SearchLookUpEdit.Properties.DataSource = BS_BusinessDates
            BusinessDate_SearchLookUpEdit.Properties.DisplayMember = "BusinessDate"
            BusinessDate_SearchLookUpEdit.Properties.ValueMember = "BusinessDate"
            args.Editor = BusinessDate_SearchLookUpEdit

            Dim result As Object = XtraInputBox.Show(args)
            If result IsNot Nothing Then
                'MsgBox(AnaCreditContractsList.EditValue.ToString)
                If XtraMessageBox.Show("Should a new Risk Strategy planning Process be inserted with basic data Date: " & BusinessDate_SearchLookUpEdit.EditValue.ToString & vbNewLine _
                                       & "ATTENTION! DATA WITH SAME CREATION DATE WILL BE DELETED!", "CREATION OF A NEW RISK STRATEGY PLANNING PROCESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Me.LayoutControl3.Visible = False
                        rd = CDate(BusinessDate_SearchLookUpEdit.EditValue.ToString)
                        rdsql = rd.ToString("yyyyMMdd")
                        cd = Today
                        cdsql = cd.ToString("yyyyMMdd")

                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Create new Risk strategy planning")
                        QueryText = "SELECT A.* from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B on A.Id_SQL_Parameters_Details=B.ID
                                INNER JOIN SQL_PARAMETER_DETAILS C on B.Id_SQL_Parameters_Details=C.ID
                                where B.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS_CREATE_NEW') and C.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS')
                                and A.Status in ('Y') order by A.SQL_Float_1 asc"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            OpenSqlConnections()
                            For s = 0 To dt.Rows.Count - 1
                                SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(s).Item("SQL_Name_1").ToString)
                                ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).ToString.Replace("<CreationDate>", cdsql)
                                    currentSqlcommandNr = CInt(dt.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.CommandText = SqlCommandText
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<cd>", cd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<cdsql>", cdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    engine.Run()
                                End If
                            Next
                            SplashScreenManager.CloseForm(False)
                            CloseSqlConnections()
                        Else
                            SplashScreenManager.CloseForm(False)
                            XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/RISK_STRATEGY_PLANNING_PROCESS/RISK_STRATEGY_PLANNING_PROCESS_RELOAD_DATA", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        'Load all data
                        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                        Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
                        Me.RiskStrategyPlanningProcess_TotalsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals, cd)
                        Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
                        Me.CreditRisk_AllDetailsView.ClearColumnsFilter()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        CloseSqlConnections()

                        Exit Sub
                    End Try

                End If
            End If
        End If

        If e.Button.Tag = "DeleteRSPP" Then
            If RiskStrategyPlanningProcessAllDates_GridView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                If XtraMessageBox.Show("Should the selected creation Date: " & cd & " with Business Date: " & rd & " be deleted ?", "DELETE SELECTED STRATEGY DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Risk strategy planning process data")
                        OpenSqlConnections()
                        cmd.CommandText = "DECLARE @RISKDATE Datetime='" & rdsql & "'
                                           DECLARE @CREATIONDATE Datetime='" & cdsql & "'
                                           DELETE FROM [RiskStrategyPlanningProcess_Details] where CreationDate=@CREATIONDATE
                                           DELETE FROM [RiskStrategyPlanningProcess_Totals] where CreationDate=@CREATIONDATE
                                           DELETE FROM [RiskStrategyPlanningProcess_Date] where CreationDate=@CREATIONDATE"
                        cmd.ExecuteNonQuery()
                        CloseSqlConnections()
                        Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        CloseSqlConnections()

                        Return
                    End Try

                End If
            End If
        End If

    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click

        If XtraMessageBox.Show("Should the Basic Data for " & Me.RiskDate_lbl.Text & " and for Creation Date " & Me.CreationDate_lbl.Text & " be re-loaded?" & vbNewLine & vbNewLine & "ATTENTION! ALL CURRENT DATA WILL BE DELETED!", "DATA LOAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                rd = Me.RiskDate_lbl.Text
                rdsql = rd.ToString("yyyyMMdd")
                cd = Me.CreationDate_lbl.Text
                cdsql = cd.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Reload Risk strategy planning process data")
                QueryText = "SELECT A.* from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B on A.Id_SQL_Parameters_Details=B.ID
                                INNER JOIN SQL_PARAMETER_DETAILS C on B.Id_SQL_Parameters_Details=C.ID
                                where B.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS_RELOAD_DATA') and C.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS')
                                and A.Status in ('Y') order by A.SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    OpenSqlConnections()
                    For s = 0 To dt.Rows.Count - 1
                        ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(s).Item("SQL_Name_1").ToString)
                        If ScriptType = "SQL" Then
                            SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).ToString.Replace("<CreationDate>", cdsql)
                            currentSqlcommandNr = CInt(dt.Rows.Item(s).Item("SQL_Float_1").ToString)
                            cmd.CommandText = SqlCommandText
                            cmd.ExecuteNonQuery()
                        ElseIf ScriptType = "VB" Then
                            Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<cd>", cd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<cdsql>", cdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                            Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                            Dim entry As String = "VB_ScriptForExecution"
                            If code = "" Then Return
                            If entry = "" Then entry = "VB_ScriptForExecution"
                            Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                            engine.Run()
                        End If
                    Next
                    SplashScreenManager.CloseForm(False)
                    CloseSqlConnections()
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/RISK_STRATEGY_PLANNING_PROCESS/RISK_STRATEGY_PLANNING_PROCESS_RELOAD_DATA", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'Load all data
                Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
                Me.RiskStrategyPlanningProcess_TotalsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals, cd)
                Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
                Me.CreditRisk_AllDetailsView.ClearColumnsFilter()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CloseSqlConnections()

                Exit Sub
            End Try
        End If

    End Sub

    Private Sub DisplayAllDates_btn_Click(sender As Object, e As EventArgs) Handles DisplayAllDates_btn.Click
        Me.LayoutControl3.Visible = True
        'Me.RiskStrategyPlanningProcess_DetailsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details)
        'Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails)
        'Me.RiskStrategyPlanningProcess_TotalsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals)
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load all dates")
        Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BusinessType_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessType_LookUpEdit.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = row("Client Group")
        BusinessTypeClientGroup = value.ToString

    End Sub

    Private Sub AddNewT2Participant_btn_Click(sender As Object, e As EventArgs) Handles AddNewT2Participant_btn.Click
        Dim Amount As Double = Me.Amount_TextEdit.Text
        Dim CounterBorrower As Double = Me.SubBorrowerCount_SpinEdit.Text
        Dim ProjectionYear As Double = Me.ProjectionYear_SpinEdit.Text

        If IsNothing(Me.BusinessType_LookUpEdit.Text) = False AndAlso IsNothing(Me.ObligorRate_LookUpEdit.Text) = False AndAlso Amount <> 0 AndAlso CounterBorrower >= 1 AndAlso IsDate(Me.MaturityDate_DateEdit.Text) = True Then
            Try
                rd = Me.RiskDate_lbl.Text
                rdsql = rd.ToString("yyyyMMdd")
                cd = Me.CreationDate_lbl.Text
                cdsql = cd.ToString("yyyyMMdd")

                Dim md As Date = Me.MaturityDate_DateEdit.Text
                Dim mdsql As String = md.ToString("yyyyMMdd")
                Dim RelatedAmount As Double = Math.Round(Amount / CounterBorrower, 2)

                OpenSqlConnections()
                cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Details]
                                    ([BusinessType]
                                    ,[Obligor Rate]
                                    ,[Counterparty/Issuer/Collateral Name]
                                    ,[ClientGroupName]
                                    ,[Maturity Date]
                                    ,[Credit Outstanding (EUR Equ)]
                                    ,[NetCreditOutstandingAmountEUR]
                                    ,[InputType]
                                    ,[ProjectionYear]
                                    ,[RiskDate]
                                    ,[CreationDate]) 
                                Select TOP " & Str(CounterBorrower) & " '" & Me.BusinessType_LookUpEdit.Text & "'
                                    ,'" & Me.ObligorRate_LookUpEdit.Text & "'
                                    ,'" & Me.BusinessType_LookUpEdit.Text & "'
                                    ,'" & Me.BusinessType_LookUpEdit.Text & "'
                                    ,'" & mdsql & "'
                                    ," & Str(RelatedAmount) & "
                                    ," & Str(RelatedAmount) & "
                                    ,'M'
                                    ," & Str(ProjectionYear) & "
                                    ,'" & rdsql & "'
                                    ,'" & cdsql & "' 
                                    from [RiskStrategyPlanningProcess_Details]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[(1-ER_45)]=B.[ER_45],A.[CoreDefinition]=B.[CoreDefinition] 
                                   FROM [RiskStrategyPlanningProcess_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade] 
                                   WHERE A.[PD]=0 and [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] SET [Client No]=[ID]+90000000,[ClientGroup]=[ID]+90000000 
                                   where [InputType]='M' and [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()
                XtraMessageBox.Show("Data have being inserted to Table", "NEW DATA INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Amount_TextEdit.Text = "0,00"
                Me.SubBorrowerCount_SpinEdit.Text = "1"
                Me.MaturityDate_DateEdit.Text = ""


            Catch ex As Exception
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try


        End If
    End Sub

    Private Sub LoadAllData_btn_Click(sender As Object, e As EventArgs) Handles LoadAllData_btn.Click
        cd = Me.CreationDate_lbl.Text
        cdsql = cd.ToString("yyyyMMdd")

        Me.XtraTabControl1.Visible = True
        'Load all data
        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
        Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
    End Sub

    Private Sub RecalculateEL_UL_GA_btn_Click(sender As Object, e As EventArgs) Handles RecalculateEL_UL_GA_btn.Click
        If XtraMessageBox.Show("Should the Expected Loss, Unexpected Loss and Granularity adjustment be recalculated based on the current Data?", "RECALCULATION IN RISK STRATEGY PLANNING PROCESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            rd = Me.RiskDate_lbl.Text
            rdsql = rd.ToString("yyyyMMdd")
            cd = Me.CreationDate_lbl.Text
            cdsql = cd.ToString("yyyyMMdd")
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Update Parameters")
                OpenSqlConnections()
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Date] SET 
                                      [LevelOfConfidence]=@LevelOfConfidence
                                     ,[p_alpha_Value]=@p_alpha_Value
                                     ,[nu_Value]=@nu_Value
                                     ,b_beta_value=@b_beta_value
                                     where CreationDate='" & cdsql & "'"
                cmd.Parameters.Add("@LevelOfConfidence", SqlDbType.Float).Value = Me.LevelOfConfidence_SpinEdit.EditValue
                cmd.Parameters.Add("@p_alpha_Value", SqlDbType.Float).Value = Me.p_alpha_value_SpinEdit.EditValue
                cmd.Parameters.Add("@nu_Value", SqlDbType.Float).Value = Me.nu_Value_SpinEdit.EditValue
                cmd.Parameters.Add("@b_beta_value", SqlDbType.Float).Value = Me.b_beta_value_SpinEdit.EditValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                CloseSqlConnections()
                SplashScreenManager.Default.SetWaitFormCaption("Recalculating Expected Loss, Unexpected Loss and Granularity Approach" & vbNewLine & "for the Risk Strategy Processing Date: " & rd)
                QueryText = "SELECT A.* from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B on A.Id_SQL_Parameters_Details=B.ID
                                INNER JOIN SQL_PARAMETER_DETAILS C on B.Id_SQL_Parameters_Details=C.ID
                                where B.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS_CALCULATE') and C.SQL_Name_1 in ('RISK_STRATEGY_PLANNING_PROCESS')
                                and A.Status in ('Y') order by A.SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    OpenSqlConnections()
                    For s = 0 To dt.Rows.Count - 1
                        ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                        SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(s).Item("SQL_Name_1").ToString)
                        If ScriptType = "SQL" Then
                            SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).ToString.Replace("<CreationDate>", cdsql)
                            currentSqlcommandNr = CInt(dt.Rows.Item(s).Item("SQL_Float_1").ToString)
                            cmd.CommandText = SqlCommandText
                            cmd.ExecuteNonQuery()
                        ElseIf ScriptType = "VB" Then
                            Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<cd>", cd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<cdsql>", cdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                            Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                            Dim entry As String = "VB_ScriptForExecution"
                            If code = "" Then Return
                            If entry = "" Then entry = "VB_ScriptForExecution"
                            Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                            engine.Run()
                        End If
                    Next
                    'Load All Data
                    Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
                    Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                    Me.RiskStrategyPlanningProcess_TotalsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals, cd)
                    Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
                    SplashScreenManager.CloseForm(False)
                    CloseSqlConnections()
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/RISK_STRATEGY_PLANNING_PROCESS/RISK_STRATEGY_PLANNING_PROCESS_CALCULATE", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try






        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
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
        Dim reportfooter As String = "RISK STRATEGY PLANNING PROCESS DATA - TOTALS for Business Date data: " & Me.RiskDate_lbl.Text & " Creation Date: " & Me.CreationDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintExport_DetailsView_btn_Click(sender As Object, e As EventArgs) Handles PrintExport_DetailsView_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "RISK STRATEGY PLANNING PROCESS DATA - DETAILS for Business Date data: " & Me.RiskDate_lbl.Text & " Creation Date: " & Me.CreationDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub CreditRisk_AllDetailsView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CreditRisk_AllDetailsView.CellValueChanged
        Dim row As System.Data.DataRow = CreditRisk_AllDetailsView.GetDataRow(CreditRisk_AllDetailsView.FocusedRowHandle)
        Dim Amount As Double = row(6)
        row(7) = Amount
        row(9) = 0
        row(10) = 0
        row(11) = 0
        row(16) = DBNull.Value
    End Sub

    Private Sub CreditRisk_AllDetailsView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles CreditRisk_AllDetailsView.FocusedRowChanged
        'If CreditRisk_AllDetailsView.IsFilterRow(Me.CreditRisk_AllDetailsView.FocusedRowHandle) = False Then
        'Dim rowHandle As Integer = CreditRisk_AllDetailsView.FocusedRowHandle
        'Dim INPUT_TYPE As String = CreditRisk_AllDetailsView.GetRowCellValue(rowHandle, "InputType").ToString

        'If INPUT_TYPE = "M" Then
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = False
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = True
        'Else
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = True
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = False
        'End If
        'End If

    End Sub

    Private Sub CreditRisk_AllDetailsView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles CreditRisk_AllDetailsView.RowCellClick
        'Dim view As GridView = DirectCast(sender, GridView)
        'If view.GetFocusedRowCellValue("InputType").ToString = "M" Then
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = False
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = True
        'Else
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = True
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = False
        'End If
    End Sub

    Private Sub CreditRisk_AllDetailsView_RowClick(sender As Object, e As RowClickEventArgs) Handles CreditRisk_AllDetailsView.RowClick
        'Dim view As GridView = DirectCast(sender, GridView)
        'If view.GetFocusedRowCellValue("InputType").ToString = "M" Then
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = False
        'Me.CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = True
        'Else
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.ReadOnly = True
        'CreditRisk_AllDetailsView.Columns.ColumnByFieldName("Credit Outstanding (EUR Equ)").OptionsColumn.AllowEdit = False
        'End If
    End Sub

    Private Sub CreditRisk_AllDetailsView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles CreditRisk_AllDetailsView.ShowingEditor
        Dim view As GridView = DirectCast(sender, GridView)
        If view.GetFocusedRowCellValue("InputType").ToString <> "M" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub XtraTabControl1_VisibleChanged(sender As Object, e As EventArgs) Handles XtraTabControl1.VisibleChanged
        If Me.XtraTabControl1.Visible = False Then
            Me.RecalculateEL_UL_GA_btn.Visible = False
        Else
            Me.RecalculateEL_UL_GA_btn.Visible = True
        End If
    End Sub

#Region "PARAMETER MODIFICATIONS"

    Private Sub LevelOfConfidence_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelOfConfidence_SpinEdit.ButtonClick
        'Level Of Confidence
        If e.Button.Tag = "ChangeStandardValue" Then
            If XtraMessageBox.Show("Should the LEVEL OF CONFIDENCE default value be changed to " & Me.LevelOfConfidence_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_LevelOfConfidence] default (" & Str(DefaultValueLevelOfConfidence) & ") for [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("LEVEL OF CONFIDENCE default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If


    End Sub

    Private Sub nu_Value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles nu_Value_SpinEdit.ButtonClick
        If e.Button.Tag = "nuChangeStandardValue" Then
            If XtraMessageBox.Show("Should the nu default value be changed to " & Me.nu_Value_SpinEdit.Text, "CHANGE NU DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueNU As Double = Me.nu_Value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_nu_Value] default (" & Str(DefaultValueNU) & ") for [nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("NU default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub p_alpha_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles p_alpha_value_SpinEdit.ButtonClick
        If e.Button.Tag = "pAlphaChangeStandardValue" Then
            If XtraMessageBox.Show("Should the p Alpha default value be changed to " & Me.p_alpha_value_SpinEdit.Text, "CHANGE P ALPHA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuepAlpha As Double = Me.p_alpha_value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_p_alpha_Value] default (" & Str(DefaultValuepAlpha) & ") for [p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("p Alpha default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub b_beta_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles b_beta_value_SpinEdit.ButtonClick
        If e.Button.Tag = "bBetaChangeStandardValue" Then
            If XtraMessageBox.Show("Should the b Beta default value be changed to " & Me.b_beta_value_SpinEdit.Text, "CHANGE B BETA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuebBeta As Double = Me.b_beta_value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_b_beta_value] default (" & Str(DefaultValuebBeta) & ") for [b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("b Beta default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub


#End Region



    Private Sub RiskStrategyPlanningProcessAllDates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles RiskStrategyPlanningProcessAllDates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Me.LayoutControl3.Visible = False
            cd = Me.CreationDate_lbl.Text
            cdsql = cd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Risk strategy planning data for " & cd)
            'Load all data
            Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
            Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
            Me.RiskStrategyPlanningProcess_TotalsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals, cd)
            Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
            Me.CreditRisk_AllDetailsView.ClearColumnsFilter()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RiskStrategyPlanningProcessAllDates_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles RiskStrategyPlanningProcessAllDates_GridView.RowCellClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            rdsql = rd.ToString("yyyyMMdd")
            cd = view.GetFocusedRowCellValue("CreationDate")
            cdsql = cd.ToString("yyyyMMdd")
        End If
    End Sub

    Private Sub RiskStrategyPlanningProcessAllDates_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles RiskStrategyPlanningProcessAllDates_GridView.FocusedRowChanged
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            cd = view.GetFocusedRowCellValue("CreationDate")
        End If
    End Sub

    Private Sub LoadExcelFile_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelFile_btn.Click
        XtraMessageBox.SmartTextWrap = True
        If XtraMessageBox.Show("Should the current Risk strategy planning process data be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for Risk planning Process Creation Date" & Me.CreationDate_lbl.Text)

                BgwExcelLoad = New BackgroundWorker
                BgwExcelLoad.WorkerReportsProgress = True
                BgwExcelLoad.RunWorkerAsync()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If

    End Sub

    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork
        rd = Me.RiskDate_lbl.Text
        rdsql = rd.ToString("yyyyMMdd")
        cd = Me.CreationDate_lbl.Text
        cdsql = cd.ToString("yyyyMMdd")

        Try


            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_EL_UL_GA_RSPP' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RiskStrategyPlanningProcess_ExcelFile_creation') 
                    and  Id_SQL_Parameters in ('EXCEL_FILES_CREATION'))"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                OpenSqlConnections()
                For s = 0 To dt.Rows.Count - 1
                    ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                    If ScriptType = "SQL" Then
                        SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql).ToString.Replace("<CreationDate>", cdsql)
                        currentSqlcommandNr = CInt(dt.Rows.Item(s).Item("SQL_Float_1").ToString)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    ElseIf ScriptType = "VB" Then
                        Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<cd>", cd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<cdsql>", cdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                        Dim entry As String = "VB_ScriptForExecution"
                        If code = "" Then Return
                        If entry = "" Then entry = "VB_ScriptForExecution"
                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                        engine.Run()
                    End If
                Next
                CloseSqlConnections()
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/RiskStrategyPlanningProcess_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcelLoad.CancelAsync()
        End Try



    End Sub

    Private Sub BgwExcelLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Risk Strategy Planning Process - Excel File calculation"
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.Xlsx)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl.Name = GridControl1.Name Then
            Dim view As GridView = TryCast(GridControl1.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(14)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "SubBorrowersCounter"
                        args.Contents.Text = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
                    Case Is = "FinalEadTotalSum"
                        args.Contents.Text = "Sum of Net credit outstanding amount for each Client Group"
                    Case Is = "LGD"
                        args.Contents.Text = "from (ER1)"
                    Case Is = "PD_EaD_weighted"
                        args.Contents.Text = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credit outstanding Amount for each Client Group"
                    Case Is = "PD_3bps_floor"
                        args.Contents.Text = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)"
                    Case Is = "IndicatorOfFloor"
                        args.Contents.Text = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
                    Case Is = "MaturityEADweigthed"
                        args.Contents.Text = "Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and Variable 2"
                    Case Is = "R_CoefficientOfColleration"
                        args.Contents.Text = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))" & vbNewLine & _
                            "+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where EXP=e=2.71828182845904"
                    Case Is = "b_MaturityAdjustment"
                        args.Contents.Text = "b=(0,11852-0,05478*Log(PD))^2"
                    Case Is = "RW_RiskWeightedExposure"
                        args.Contents.Text = "(LGD* NORMDIST((1/(1-R))^0,5*NORMINV(PD;0;1)+(R/(1-R))^0,5" & vbNewLine _
                                             & "* NORMINV(Level of confidence;0;1);0;1;TRUE)- LGD*PD)*((1+(Maturity(EaD weigthed)-2,5)*b) / (1-1,5*b))*12,5*1,06) " & vbNewLine _
                                             & "where NORMDIST=cumulative distribution function for a standard normal random variable x  and " & vbNewLine _
                                             & "NORMINV=inverse cumulative distribution function for a standard normal random variable "
                    Case Is = "UL_UnexpectedLoss"
                        args.Contents.Text = "RW*Final EaD*8,00%"
                    Case Is = "s_i"
                        args.Contents.Text = "Final EAD/Sum Final EaD"
                    Case Is = "K_i"
                        args.Contents.Text = "Unexpected Loss/Final EaD"
                    Case Is = "R_i"
                        args.Contents.Text = "LGD * PD"
                    Case Is = "VLGD_i"
                        args.Contents.Text = "(γ) nü value * LGD * (1 - LGD)"
                    Case Is = "C_i"
                        args.Contents.Text = "Power(LGD,2) + VLGD/LGD"
                    Case Is = "GA_n"
                        args.Contents.Text = "S_i^2*((Delta*C_i*(K_i+R_i) +Delta*(K_i+R_i)^2 * (VLGD^2)/(LGD^2) ) -K_i*(C_i+2* (K_i+R_i)*(VLGD^2)/(LGD^2))"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


        If e.SelectedControl.Name = GridControl2.Name Then
            Dim view As GridView = TryCast(GridControl2.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(14)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "NetCreditOutstandingAmountEUR"
                        args.Contents.Text = "CASHPLEDGE Consideration"
                    Case Is = "MaturityWithoutCapFloor"
                        args.Contents.Text = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & vbNewLine _
                                             & "else Maturity Date-RiskDate/365,25"
                    Case Is = "EaDweigthedMaturityWithoutCapFloor"
                        args.Contents.Text = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
                    Case Is = "PDxFinalEaD"
                        args.Contents.Text = "PD * Net Credit outstanding Amount EUR"
                    Case Is = "LGDfinalEaDweighted"
                        args.Contents.Text = "(ER2) * Net Credit Outstanding Amount EUR"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


    End Sub


End Class