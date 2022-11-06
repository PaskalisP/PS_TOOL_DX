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
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim BusinessTypeClientGroup As String = Nothing
    Friend WithEvents BgwExcelLoad As BackgroundWorker


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
            Me.RiskStrategyPlanningProcess_DetailsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details)
            Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails)
            Me.RiskStrategyPlanningProcess_TotalsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals)
            Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)
        End If
    End Sub

   

    Private Sub RiskStrategyPlanningProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick


        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************
        'Bind Combobox

        Me.AnalysisDate_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RiskDate' from [UNEXPECTED_LOSS_DATE] ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.AnalysisDate_Comboedit.Properties.Items.Add(row("RiskDate"))
            End If
        Next

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



        Me.RiskStrategyPlanningProcess_DetailsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details)
        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails)
        Me.RiskStrategyPlanningProcess_TotalsTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals)
        Me.RiskStrategyPlanningProcess_DateTableAdapter.Fill(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date)

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
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.RiskStrategyPlanningProcessDataset)

                        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)

                    Else
                        e.Handled = True
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                If MessageBox.Show("Should the row ID: " & ID_ProcName & " be deleted?", "DELETE MANUAL INPUTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
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
                MessageBox.Show("Unable to delete row! Inputy Type is not M", "UNABLE TO DELETE MANUAL INPUTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click

        If MessageBox.Show("Should the Basic Data for " & Me.RiskDate_lbl.Text & " and for Creation Date " & Me.CreationDate_lbl.Text & " be re-loaded?" & vbNewLine & vbNewLine & "ATTENTION! ALL CURRENT DATA WILL BE DELETED!", "DATA LOAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                rd = Me.RiskDate_lbl.Text
                rdsql = rd.ToString("yyyyMMdd")
                cd = Me.CreationDate_lbl.Text
                cdsql = cd.ToString("yyyyMMdd")

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandTimeout = 500
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Delete all current Data in Risk Strategy Planning Process")

                cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                SplashScreenManager.Default.SetWaitFormCaption("Import Data from UNEXPECTED LOSS Table")
                cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Details]([Obligor Rate],[Counterparty/Issuer/Collateral Name],[Client No],[Maturity Date],[Remaining Year(s) to Maturity],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate],[CreationDate]) Select [Obligor Rate],[Counterparty/Issuer/Collateral Name],[Client No],[Maturity Date],[Remaining Year(s) to Maturity],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate],'" & cdsql & "' from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                SplashScreenManager.Default.SetWaitFormCaption("Update Business Types from BusinessTypesCreditPortfolioDetails")
                cmd.CommandText = "UPDATE A SET A.[BusinessType]=B.[BusinessTypeName] from [RiskStrategyPlanningProcess_Details] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[Client No]=B.[Client No] where B.[RiskDate]='" & rdsql & "' and  A.[CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                '
                SplashScreenManager.Default.SetWaitFormCaption("Set as Risk Strategy Planning Process date " & rd)
                cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Date]([RiskDate],[CreationDate])VALUES('" & rdsql & "','" & cdsql & "')"
                cmd.ExecuteNonQuery()
                SplashScreenManager.Default.SetWaitFormCaption("Load Risk Strategy Planning Process details for Creation date " & cd)
                'Load all data
                Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
                Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
                Me.CreditRisk_AllDetailsView.ClearColumnsFilter()

                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                Exit Sub
            End Try
        End If

    End Sub

    Private Sub CreateNewRiskStrategy_btn_Click(sender As Object, e As EventArgs) Handles CreateNewRiskStrategy_btn.Click
        If IsDate(Me.AnalysisDate_Comboedit.Text) = True Then
            If MessageBox.Show("Should a new Risk Strategy planning Process be inserted with basic data Date " & Me.AnalysisDate_Comboedit.Text & " ?" & vbNewLine & vbNewLine & "ATTENTION! DATA WITH SAME CREATION DATE WILL BE DELETED!", "CREATION OF A NEW RISK STRATEGY PLANNING PROCESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    rd = Me.AnalysisDate_Comboedit.Text
                    rdsql = rd.ToString("yyyyMMdd")
                    cd = Today
                    cdsql = cd.ToString("yyyyMMdd")

                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Connection.Open()
                    cmd.CommandTimeout = 500
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete all current Data in Risk Strategy Planning Process")

                    cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Import Data from UNEXPECTED LOSS Table")
                    cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Details]([Obligor Rate],[Counterparty/Issuer/Collateral Name],[Client No],[Maturity Date],[Remaining Year(s) to Maturity],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate],[CreationDate]) Select [Obligor Rate],[Counterparty/Issuer/Collateral Name],[Client No],[Maturity Date],[Remaining Year(s) to Maturity],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate],'" & cdsql & "' from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update Business Types from BusinessTypesCreditPortfolioDetails")
                    cmd.CommandText = "UPDATE A SET A.[BusinessType]=B.[BusinessTypeName] from [RiskStrategyPlanningProcess_Details] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[Client No]=B.[Client No] where B.[RiskDate]='" & rdsql & "' and  A.[CreationDate]='" & cdsql & "'"
                    cmd.ExecuteNonQuery()
                    '
                    SplashScreenManager.Default.SetWaitFormCaption("Set as Risk Strategy Planning Process date " & rd)
                    cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Date]([RiskDate],[CreationDate])VALUES('" & rdsql & "','" & cdsql & "')"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Load Risk Strategy Planning Process details for Creation date " & cd)
                    'Load all data
                    Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
                    Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
                    Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
                    Me.CreditRisk_AllDetailsView.ClearColumnsFilter()

                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SplashScreenManager.CloseForm(False)
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If

                    Exit Sub
                End Try
            End If
        End If
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

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Details]([BusinessType],[Obligor Rate],[Counterparty/Issuer/Collateral Name],[ClientGroupName],[Maturity Date],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InputType],[ProjectionYear],[RiskDate],[CreationDate]) Select TOP " & Str(CounterBorrower) & " '" & Me.BusinessType_LookUpEdit.Text & "','" & Me.ObligorRate_LookUpEdit.Text & "','" & Me.BusinessType_LookUpEdit.Text & "','" & Me.BusinessType_LookUpEdit.Text & "','" & mdsql & "'," & Str(RelatedAmount) & "," & Str(RelatedAmount) & ",'M'," & Str(ProjectionYear) & ",'" & rdsql & "','" & cdsql & "' from [RiskStrategyPlanningProcess_Details]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[(1-ER_45)]=B.[ER_45],A.[CoreDefinition]=B.[CoreDefinition] FROM [RiskStrategyPlanningProcess_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade] WHERE A.[PD]=0 and [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] SET [Client No]=[ID]+90000000,[ClientGroup]=[ID]+90000000 where [InputType]='M' and [CreationDate]='" & cdsql & "'"
                cmd.ExecuteNonQuery()

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show("Data have being inserted to Table", "NEW DATA INSERTED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Amount_TextEdit.Text = "0,00"
                Me.SubBorrowerCount_SpinEdit.Text = "1"
                Me.MaturityDate_DateEdit.Text = ""


            Catch ex As Exception
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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
        If MessageBox.Show("Should the Expected Loss, Unexpected Loss and Granularity approach be recalculated based on the current Data?", "RECALCULATION IN RISK STRATEGY PLANNING PROCESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            rd = Me.RiskDate_lbl.Text
            rdsql = rd.ToString("yyyyMMdd")
            cd = Me.CreationDate_lbl.Text
            cdsql = cd.ToString("yyyyMMdd")


            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Recalculating Expected Loss, Unexpected Loss and Granularity Approach")
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.Connection.Open()

            'Update basic Parameter Values
            Dim LevelOfConfidenceNr As Double = Me.LevelOfConfidence_SpinEdit.Text
            Dim pAlphaNr As Double = Me.p_alpha_value_SpinEdit.Text
            Dim nuNr As Double = Me.nu_Value_SpinEdit.Text
            Dim bNr As Double = Me.b_beta_value_SpinEdit.Text
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Date] Set [LevelOfConfidence]=" & Str(LevelOfConfidenceNr) & ",[p_alpha_Value]=" & Str(pAlphaNr) & ",[nu_Value]=" & Str(nuNr) & ",[b_beta_value]=" & Str(bNr) & " where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            SplashScreenManager.Default.SetWaitFormCaption("Delete all data from RiskStrategyPlanningProcess_Totals ")
            cmd.CommandText = "DELETE from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            '*****ONLY FOR TEST REASONS-GROUPING ACCORDING TO BUSINESS TYPES
            'cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] SET [ClientGroupName]=[BusinessType]"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[PARAMETER2] from [RiskStrategyPlanningProcess_Details] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RISK_STRATEGY_PLANNING_GROUPS')B ON A.[BusinessType]=B.[PARAMETER1]"
            'cmd.ExecuteNonQuery()
            '*****************************************************************
            SplashScreenManager.Default.SetWaitFormCaption("Update PD and LGD in RiskStrategyPlanningProcess_Details ")
            cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[(1-ER_45)]=B.[ER_45],A.[CoreDefinition]=B.[CoreDefinition] FROM [RiskStrategyPlanningProcess_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade] WHERE A.[PD]=0 and [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            '++++SPECIAL FALL FX DEALS++++
            SplashScreenManager.Default.SetWaitFormCaption("For manual inputed FX TRANSACTIONS calculate the Remaining Years to Maturity")
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Details] set [Remaining Year(s) to Maturity]=dbo.yearDiff([Maturity Date],[RiskDate]) where [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("For manual inputed FX TRANSACTIONS calculate the NetCreditOutstandingAmountEUR")
            cmd.CommandText = "SELECT * FROM [RiskStrategyPlanningProcess_Details] where [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.02 where [Remaining Year(s) to Maturity]<=1 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.05 where [Remaining Year(s) to Maturity]>1 and [Remaining Year(s) to Maturity]<=2 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.08 where [Remaining Year(s) to Maturity]>2 and [Remaining Year(s) to Maturity]<=3 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.11 where [Remaining Year(s) to Maturity]>3 and [Remaining Year(s) to Maturity]<=4 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.14 where [Remaining Year(s) to Maturity]>4 and [Remaining Year(s) to Maturity]<=5 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.17 where [Remaining Year(s) to Maturity]>5 and [Remaining Year(s) to Maturity]<=6 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end begin update [RiskStrategyPlanningProcess_Details] set [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] * 0.20 where [Remaining Year(s) to Maturity]>6 and [Remaining Year(s) to Maturity]<=7 and [BusinessType]='FX TRANSACTIONS' and [InputType]='M' and [CreationDate]='" & cdsql & "' end"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++++++++

            SplashScreenManager.Default.SetWaitFormCaption("Calculate the CreditRiskAmountEUREquER45 and NetCreditRiskAmountEUREquER45 for all Details")
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) where [CreationDate]='" & cdsql & "' and [Obligor Rate] not in ('U','CA')"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate the Expected Loss Sum for all details")
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Date] set [SumEL]=(SELECT Sum([NetCreditRiskAmountEUREquER45]) FROM [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "') where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            SplashScreenManager.Default.SetWaitFormCaption("Define MaturityWithoutCapFloor in RiskStrategyPlanningProcess_Details")
            Dim NextHalfYearDate As Date = DateAdd(DateInterval.Month, 6, rd)
            Me.QueryText = "select [ID],'Maturity Date'=CASE when [Maturity Date] is NULL then '99991231' else [Maturity Date] end from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "' and [MaturityWithoutCapFloor] is NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ID As String = dt.Rows.Item(i).Item("ID")
                Dim MaturityDate As Date = dt.Rows.Item(i).Item("Maturity Date")
                Dim DiffernceRiskDateMaturityDate As Double = 0
                If MaturityDate = DateSerial(9999, 12, 31) Then
                    DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, NextHalfYearDate) / 365.25, 2)
                    cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                    cmd.ExecuteNonQuery()
                Else
                    DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, MaturityDate) / 365.25, 2)
                    cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted in RiskStrategyPlanningProcess_Details for " & rd)
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Details] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2) where [CreationDate]='" & cdsql & "' and [PD]<>0"
            cmd.ExecuteNonQuery()
            'UNEXPECTED LOSS
            SplashScreenManager.Default.SetWaitFormCaption("Insert Client Group,Risk Date from RiskStrategyPlanningProcess_Details in RiskStrategyPlanningProcess_Totals Table grouped by Client Group and RiskDate for " & rd)
            cmd.CommandText = "INSERT INTO [RiskStrategyPlanningProcess_Totals]([ClientGroup],[RiskDate],[CreationDate]) SELECT [ClientGroup],[RiskDate],[CreationDate] from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "' GROUP BY [ClientGroup],[RiskDate],[CreationDate]"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Name in RiskStrategyPlanningProcess_Totals Table")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [RiskStrategyPlanningProcess_Totals] A INNER JOIN [RiskStrategyPlanningProcess_Details] B ON A.[ClientGroup]=B.[ClientGroup] where A.[CreationDate]='" & cdsql & "' and B.[CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Update IdClientGroup in RiskStrategyPlanningProcess_Details ")
            cmd.CommandText = "UPDATE A set A.[IdClientGroup]=B.[ID] from [RiskStrategyPlanningProcess_Details] A INNER JOIN [RiskStrategyPlanningProcess_Totals] B ON A.[ClientGroup]=B.[ClientGroup] where A.[CreationDate]=B.[CreationDate]"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Update SubBorrowersCounter in RiskStrategyPlanningProcess_Totals")
            cmd.CommandText = "UPDATE A SET A.[SubBorrowersCounter]=B.S from [RiskStrategyPlanningProcess_Totals] A INNER JOIN (Select [ClientGroup],Count([IdClientGroup]) as S from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "' GROUP BY [ClientGroup]) B on A.[ClientGroup]=B.[ClientGroup] where A.[CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Update IdDate in RiskStrategyPlanningProcess_Totals")
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] Set [IdDate]=(Select [ID] from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "') where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Update FinalEadTotalSum,LGD,PD_EaD_weigthed in RiskStrategyPlanningProcess_Details")
            Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroup] from [RiskStrategyPlanningProcess_Details]  Where [CreationDate]='" & cdsql & "' and [PD]<>0  GROUP BY [ClientGroup]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
                If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                    cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "' and [CreationDate]='" & cdsql & "' "
                    cmd.ExecuteNonQuery()
                End If
                Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
                cmd.CommandText = "Select [FinalEadTotalSum] from [RiskStrategyPlanningProcess_Totals] where [ClientGroup]='" & ClientGroup & "' and [CreationDate]='" & cdsql & "' "
                Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
                Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
                If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                    Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                    cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "' and [CreationDate]='" & cdsql & "' "
                    cmd.ExecuteNonQuery()
                End If
            Next
            SplashScreenManager.Default.SetWaitFormCaption("Update PD_3bps_floor in RiskStrategyPlanningProcess_Totals")
            Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [RiskStrategyPlanningProcess_Totals]  Where [CreationDate]='" & cdsql & "' GROUP BY [ClientGroup],[PD_EaD_weighted]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
                Dim CheckNumber As Double = 0.0003
                Dim MaxNumber As Double = 0
                'Get PD_3bps_floor
                If PD_EaD_weighted > CheckNumber Then
                    MaxNumber = PD_EaD_weighted
                    'MsgBox("Greater" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                Else
                    MaxNumber = CheckNumber
                    'MsgBox("Less" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                End If
                Dim SecondNumber As Double = 0
                If PD_EaD_weighted = 0 Then
                    SecondNumber = 0
                    'MsgBox("Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                Else
                    SecondNumber = 1
                    'MsgBox("Not Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                End If
                Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
                'MsgBox("PD_3bpsfloor " & PD_3bps_floor)
                'Get IndicatorOfFloor
                Dim IndicatorOfFloor As Double = 0
                Dim difference As Double = PD_3bps_floor - PD_EaD_weighted
                'MsgBox(difference)
                If difference > 0 Then
                    IndicatorOfFloor = 1
                Else
                    IndicatorOfFloor = 0
                End If
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where [CreationDate]='" & cdsql & "' and [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            Next
            SplashScreenManager.Default.SetWaitFormCaption("Update MaturityEADweigthed in RiskStrategyPlanningProcess_Totals")
            Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroup] from [RiskStrategyPlanningProcess_Details]  Where [CreationDate]='" & cdsql & "' and [PD]<>0  GROUP BY [ClientGroup]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
                cmd.CommandText = "Select [FinalEadTotalSum] from [RiskStrategyPlanningProcess_Totals] where [ClientGroup]='" & ClientGroup & "' and [CreationDate]='" & cdsql & "' "
                Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
                Dim CheckNumber As Double = 5
                Dim Variable2 As Double = 0
                If Variable1 > 5 Then
                    Variable2 = 5
                Else
                    Variable2 = Variable1
                End If
                Dim Variable3 As Double = 0
                If Variable2 > 1 Then
                    Variable3 = Variable2
                Else
                    Variable3 = 1
                End If
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "' and [CreationDate]='" & cdsql & "' "
                cmd.ExecuteNonQuery()
            Next
            SplashScreenManager.Default.SetWaitFormCaption("Update R_CoefficientOfColleration and b_MaturityAdjustment in RiskStrategyPlanningProcess_Totals Table")
            Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [RiskStrategyPlanningProcess_Totals]  Where [CreationDate]='" & cdsql & "'  GROUP BY [ClientGroup],[PD_3bps_floor]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                Dim PDminus As Double = PD * (-50)
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where  [CreationDate]='" & cdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [CreationDate]='" & cdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                cmd.ExecuteNonQuery()
                'Set b_MaturityAdjustment to 0 if NULL
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [b_MaturityAdjustment]=0 where  [CreationDate]='" & cdsql & "' and [b_MaturityAdjustment] is NULL"
                cmd.ExecuteNonQuery()
            Next
            'Get LevelOfConfidence from UNEXPTECTED_LOSS_DATE
            SplashScreenManager.Default.SetWaitFormCaption("Get LEVEL OF CONFIDENCE from RiskStrategyPlanningProcess_Date Table")
            cmd.CommandText = "Select [LevelOfConfidence] from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "'"
            Dim LevelOfConfidence As Double = cmd.ExecuteScalar

            SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in RiskStrategyPlanningProcess_Totals Table")
            Me.QueryText = "Select * from [RiskStrategyPlanningProcess_Totals]  Where [CreationDate]='" & cdsql & "' and [b_MaturityAdjustment]<>0"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ID As String = dt.Rows.Item(i).Item("ID")
                Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
                Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
                Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
                Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
                'Get First Part of Formula
                cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [RiskStrategyPlanningProcess_Totals] where [ID]='" & ID & "' "
                Dim FirstPartFormulaRW = cmd.ExecuteScalar
                'Get Second Part of Formula
                cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [RiskStrategyPlanningProcess_Totals] where [ID]='" & ID & "'"
                Dim SecondPartFormulaRW = cmd.ExecuteScalar
                Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            Next
            SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in UNEXPECTED LOSS DATE Table")
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Date] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "') where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            'GRANULARITY APPROACH
            SplashScreenManager.Default.SetWaitFormCaption("Start GRANULARITY APPROACH Calculation for " & rd)
            SplashScreenManager.Default.SetWaitFormCaption("Calculate s_i Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Totals] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "'),10) where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate K_i Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Totals] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end) where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate R_i Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Totals] set [R_i]=Round([LGD]*[PD_3bps_floor],10) where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate VLGD_i Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Totals] set [VLGD_i]=Round((select nu_Value from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "')*[LGD]*(1-[LGD]),10) where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate C_i Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Totals] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [CreationDate]='" & cdsql & "' and [LGD]<>0"
            cmd.ExecuteNonQuery()

            SplashScreenManager.Default.SetWaitFormCaption("Calculate GAMMAINV for " & rd)
            Me.QueryText = "Select * from [RiskStrategyPlanningProcess_Date]  Where [CreationDate]='" & cdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
            Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
            Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
            Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

            'excel = New Microsoft.Office.Interop.Excel.Application
            'instance = excel.WorksheetFunction

            'Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1

            Dim workbook As New DevExpress.Spreadsheet.Workbook()
            Dim worksheets As WorksheetCollection = workbook.Worksheets
            Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)

            worksheet.Range("A1").NumberFormat = "#0.00"
            worksheet.Range("A2").NumberFormat = "#0.00"
            worksheet.Range("A3").NumberFormat = "#0.00"
            worksheet.Range("A4").NumberFormat = "#0.0000000000"
            worksheet.Range("A1").Value = ConfidenceLevelUL
            worksheet.Range("A2").Value = p_alpha_Value
            worksheet.Range("A3").Value = b_beta_Value_Calculated
            worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
            Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue

            SplashScreenManager.Default.SetWaitFormCaption("Calculate DELTA Value for " & rd)
            Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
            SplashScreenManager.Default.SetWaitFormCaption("Update DELTA Value and GAMMAINV for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Date] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & " where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()
            SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert K_Value for " & rd)
            cmd.CommandText = "Update [RiskStrategyPlanningProcess_Date] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "') where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            Dim s_i As Decimal = 0
            Dim C_i As Decimal = 0
            Dim K_i As Decimal = 0
            Dim R_i As Decimal = 0
            Dim LGD_i As Decimal = 0
            Dim VLGD_i As Decimal = 0
            Dim CALCULATION_1 As Decimal = 0
            Dim CALCULATION_2 As Decimal = 0
            Dim CALCULATION_3 As Decimal = 0
            Dim TOTAL_CALCULATION As Decimal = 0

            SplashScreenManager.Default.SetWaitFormCaption("Calculate GA_n Value for " & rd)
            Me.QueryText = "Select * from [RiskStrategyPlanningProcess_Totals]  Where [CreationDate]='" & cdsql & "' and [LGD]<>0"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
                s_i = dt.Rows.Item(i).Item("s_i")
                C_i = dt.Rows.Item(i).Item("C_i")
                K_i = dt.Rows.Item(i).Item("K_i")
                R_i = dt.Rows.Item(i).Item("R_i")
                LGD_i = dt.Rows.Item(i).Item("LGD")
                VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
                Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

                Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
                Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
                Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
                Dim PowerVLGD As Decimal = VLGD_i ^ 2
                Dim PowerLGD As Decimal = LGD_i ^ 2
                Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
                Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

                CALCULATION_1 = Math.Round(Calculation_D, 12)
                CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
                CALCULATION_3 = CALCULATION_1 - CALCULATION_2

                TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

                cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Totals] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
                cmd.ExecuteNonQuery()
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_rel Value for " & rd)
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Date] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "'),10) from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "') where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()

            SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_Total Value for " & rd)
            cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "'"
            Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
            cmd.CommandText = "Select [SumGA_rel] from [RiskStrategyPlanningProcess_Date] where [CreationDate]='" & cdsql & "'"
            Dim SummeGArel As Double = cmd.ExecuteScalar
            Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
            cmd.CommandText = "UPDATE [RiskStrategyPlanningProcess_Date] SET [SumGA_Total]='" & Str(SummeGA_Total) & "' where [CreationDate]='" & cdsql & "'"
            cmd.ExecuteNonQuery()


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            'Load All Data
            Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
            Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
            Me.RiskStrategyPlanningProcess_TotalsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Totals, cd)
            Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
            SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "RISK STRATEGY PLANNING PROCESS" & "   " & "UNEXPECTED LOSS (TOTALS) " & "   " & "on: " & Me.RiskDate_lbl.Text & " Creation Date: " & Me.CreationDate_lbl.Text
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
        Dim reportfooter As String = "RISK STRATEGY PLANNING PROCESS" & "  " & "UNEXPECTED LOSS (ALL DETAILS) " & "   " & "on: " & Me.RiskDate_lbl.Text & " Creation Date: " & Me.CreationDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub UnexpectedLoss_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UnexpectedLoss_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub UnexpectedLoss_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles UnexpectedLoss_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub UnexpectedLoss_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles UnexpectedLoss_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub UnexpectedLoss_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles UnexpectedLoss_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
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

    Private Sub CreditRisk_AllDetailsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CreditRisk_AllDetailsView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CreditRisk_AllDetailsView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles CreditRisk_AllDetailsView.ShowingEditor
        Dim view As GridView = DirectCast(sender, GridView)
        If view.GetFocusedRowCellValue("InputType").ToString <> "M" Then
            e.Cancel = True

        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub CreditRisk_AllDetailsView_ShownEditor(sender As Object, e As EventArgs) Handles CreditRisk_AllDetailsView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub XtraTabControl1_VisibleChanged(sender As Object, e As EventArgs) Handles XtraTabControl1.VisibleChanged
        If Me.XtraTabControl1.Visible = False Then
            Me.RecalculateEL_UL_GA_btn.Visible = False
        Else
            Me.RecalculateEL_UL_GA_btn.Visible = True
        End If
    End Sub

    Private Sub LevelOfConfidence_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelOfConfidence_SpinEdit.ButtonClick
        'Level Of Confidence
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the LEVEL OF CONFIDENCE default value be changed to " & Me.LevelOfConfidence_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_LevelOfConfidence] default (" & Str(DefaultValueLevelOfConfidence) & ") for [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("LEVEL OF CONFIDENCE default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If


    End Sub

    Private Sub nu_Value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles nu_Value_SpinEdit.ButtonClick
        If e.Button.Tag = "nuChangeStandardValue" Then
            If MessageBox.Show("Should the nu default value be changed to " & Me.nu_Value_SpinEdit.Text, "CHANGE NU DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueNU As Double = Me.nu_Value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_nu_Value] default (" & Str(DefaultValueNU) & ") for [nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("NU default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub p_alpha_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles p_alpha_value_SpinEdit.ButtonClick
        If e.Button.Tag = "pAlphaChangeStandardValue" Then
            If MessageBox.Show("Should the p Alpha default value be changed to " & Me.p_alpha_value_SpinEdit.Text, "CHANGE P ALPHA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuepAlpha As Double = Me.p_alpha_value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_p_alpha_Value] default (" & Str(DefaultValuepAlpha) & ") for [p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("p Alpha default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub b_beta_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles b_beta_value_SpinEdit.ButtonClick
        If e.Button.Tag = "bBetaChangeStandardValue" Then
            If MessageBox.Show("Should the b Beta default value be changed to " & Me.b_beta_value_SpinEdit.Text, "CHANGE B BETA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuebBeta As Double = Me.b_beta_value_SpinEdit.Text
                    cmd.Connection.Open()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] drop constraint [DF_RiskStrategyPlanningProcess_Date_b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [RiskStrategyPlanningProcess_Date] add constraint [DF_RiskStrategyPlanningProcess_Date_b_beta_value] default (" & Str(DefaultValuebBeta) & ") for [b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    MessageBox.Show("b Beta default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    
   

    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Me.LayoutControl3.Visible = False
        cd = Me.CreationDate_lbl.Text
        cdsql = cd.ToString("yyyyMMdd")


        'Load all data
        Me.RiskStrategyPlanningProcess_AllDetails_TableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_AllDetails, cd)
        Me.RiskStrategyPlanningProcess_DetailsTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Details, cd)
        Me.RiskStrategyPlanningProcess_DateTableAdapter.FillByRiskDate(Me.RiskStrategyPlanningProcessDataset.RiskStrategyPlanningProcess_Date, cd)
        Me.CreditRisk_AllDetailsView.ClearColumnsFilter()
    End Sub

    Private Sub RiskStrategyPlanningProcessAllDates_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles RiskStrategyPlanningProcessAllDates_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub RiskStrategyPlanningProcessAllDates_GridView_ShownEditor(sender As Object, e As EventArgs) Handles RiskStrategyPlanningProcessAllDates_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LoadExcelFile_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelFile_btn.Click
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
    End Sub

    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork
        rd = Me.RiskDate_lbl.Text
        rdsql = rd.ToString("yyyyMMdd")
        Dim cd As Date = Me.CreationDate_lbl.Text
        Dim cdsql As String = cd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_EL_UL_GA_RSPP' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        '**********DATA LOAD***********
        '******************************
        Me.QueryText = "SELECT [ClientGroup],[ClientGroupName],[SubBorrowersCounter],[FinalEadTotalSum],[LGD],[PD_EaD_weighted],[PD_3bps_floor],[IndicatorOfFloor],[MaturityEADweigthed] FROM  [RiskStrategyPlanningProcess_Totals] where [CreationDate]='" & cdsql & "' order by ClientGroup *1 asc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        '+++++++++++++++++++++++++++++
        Me.QueryText = "SELECT [BusinessType],[Obligor Rate],[Counterparty/Issuer/Collateral Name],[Client No],[Maturity Date],[Remaining Year(s) to Maturity],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[EaDweigthedMaturityWithoutCapFloor],[PDxFinalEaD],[LGDfinalEaDweighted],[InputType],[ProjectionYear],[RiskDate],[CreationDate] from [RiskStrategyPlanningProcess_Details] where [CreationDate]='" & cdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)

        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with basic Parameters for the Calculation")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)
        workbook.Worksheets(0).Cells("A2").Value = "Calculation Expected/Unexpected Loss and Granularity approach for Risk Planning Creation Date:"
        workbook.Worksheets(0).Cells("D2").Value = cd
        workbook.Worksheets(0).Cells("F2").Value = rd
        Dim Nu_Value As Double = Me.nu_Value_SpinEdit.Text
        workbook.Worksheets(0).Cells("E5").Value = Nu_Value
        Dim LevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
        workbook.Worksheets(0).Cells("F5").Value = LevelOfConfidence
        Dim AlphaValue As Double = Me.p_alpha_value_SpinEdit.Text
        workbook.Worksheets(0).Cells("I4").Value = AlphaValue
        Dim BetaValue As Double = Me.b_beta_value_SpinEdit.Text
        workbook.Worksheets(0).Cells("I5").Value = BetaValue
        workbook.Worksheets(1).Cells("A1").Value = "Details - Calculation Expected/Unexpected Loss and Granularity approach for Risk Planning Creation Date:"
        workbook.Worksheets(1).Cells("D1").Value = cd
        workbook.Worksheets(1).Cells("F1").Value = rd

        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A12:W10000"))
        worksheet1.ClearContents(worksheet1("A3:X10000"))

        'LOAD in DETAILS Sheet
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - DETAILS WORKSHEET")
        worksheet1.Import(dt1, False, 2, 0)
        Dim DETAILS_LastRow As Integer = 0
        If dt1.Rows.Count > 0 Then
            DETAILS_LastRow = dt1.Rows.Count + 2

            Dim RangeDETAILS_L As CellRange = worksheet1.Range("L3:L" & DETAILS_LastRow)
            RangeDETAILS_L.Formula = "=G3*J3*K3"
            Dim RangeDETAILS_M As CellRange = worksheet1.Range("M3:M" & DETAILS_LastRow)
            RangeDETAILS_M.Formula = "=H3*J3*K3"
            Dim RangeDETAILS_Q As CellRange = worksheet1.Range("Q3:Q" & DETAILS_LastRow)
            RangeDETAILS_Q.Formula = "=ROUND((IF(OR(EXACT(E3;DATE(9999;12;31));ISBLANK(E3));DATEDIF($F$1;DATE(YEAR($F$1);MONTH($F$1)+6;DAY($F$1));""d"");DATEDIF($F$1;E3;""d"")))/365,25;2)"
            Dim RangeDETAILS_R As CellRange = worksheet1.Range("R3:R" & DETAILS_LastRow)
            RangeDETAILS_R.Formula = "=H3*Q3"
            Dim RangeDETAILS_S As CellRange = worksheet1.Range("S3:S" & DETAILS_LastRow)
            RangeDETAILS_S.Formula = "=H3*J3"
            Dim RangeDETAILS_T As CellRange = worksheet1.Range("T3:T" & DETAILS_LastRow)
            RangeDETAILS_T.Formula = "=H3*K3"
        End If

        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - TOTALS WORKSHEET")
        worksheet.Import(dt, False, 11, 0)

        Dim UL_Totals_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then

            UL_Totals_LastRow = dt.Rows.Count + 11

            Dim RangeUL_Totals_C As CellRange = worksheet.Range("C12:C" & UL_Totals_LastRow)
            RangeUL_Totals_C.Formula = "=COUNTIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12)"

            Dim RangeUL_Totals_D As CellRange = worksheet.Range("D12:D" & UL_Totals_LastRow)
            RangeUL_Totals_D.Formula = "=SUMIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12;Details!$H$3:$H$" & DETAILS_LastRow & ")"

            Dim RangeUL_Totals_F As CellRange = worksheet.Range("F12:F" & UL_Totals_LastRow)
            RangeUL_Totals_F.Formula = "=IF(ISERROR((SUMIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12;Details!$S$3:$S$" & DETAILS_LastRow & "))/D12);0;(SUMIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12;Details!$S$3:$S$" & DETAILS_LastRow & "))/D12)"

            Dim RangeUL_Totals_G As CellRange = worksheet.Range("G12:G" & UL_Totals_LastRow)
            RangeUL_Totals_G.Formula = "=MAX(F12;0,0003)*IF(EXACT(0;F12);0;1)"

            Dim RangeUL_Totals_H As CellRange = worksheet.Range("H12:H" & UL_Totals_LastRow)
            RangeUL_Totals_H.Formula = "=IF(G12-F12>0;1;0)"

            Dim RangeUL_Totals_I As CellRange = worksheet.Range("I12:I" & UL_Totals_LastRow)
            RangeUL_Totals_I.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12;Details!$R$3:$R$" & DETAILS_LastRow & "))/D12)));""n.a."";" & "MAX(1;MIN(5;(SUMIF(Details!$O$3:$O$" & DETAILS_LastRow & ";A12;Details!$R$3:$R$" & DETAILS_LastRow & "))/D12)))"

            Dim RangeUL_Totals_J As CellRange = worksheet.Range("J12:J" & UL_Totals_LastRow)
            RangeUL_Totals_J.Formula = "=0,12*((1-EXP(-50*G12))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*G12))/(1-EXP(-50))))"

            Dim RangeUL_Totals_K As CellRange = worksheet.Range("K12:K" & UL_Totals_LastRow)
            RangeUL_Totals_K.Formula = "=I12"

            Dim RangeUL_Totals_L As CellRange = worksheet.Range("L12:L" & UL_Totals_LastRow)
            RangeUL_Totals_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(G12))^2);""n.a."";" & "(0,11852-0,05478*LN(G12))^2)"
            'Original Formula:=IF(ISERROR((0,11852-0,05478*LN(G12))^2);"n.a.";(0,11852-0,05478*LN(G12))^2)

            Dim RangeUL_Totals_M As CellRange = worksheet.Range("M12:M" & UL_Totals_LastRow)
            RangeUL_Totals_M.Formula = "=IF(ISERROR((E12*NORMDIST(  (1/(1-J12))^0,5    *   NORMINV(G12;0;1)    +    (J12/(1-J12))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E12*G12   )*( (1+(K12-2,5)*L12) / (1-1,5*L12)  )*12,5*1,06);""n.a."";" & "(E12*NORMDIST(  (1/(1-J12))^0,5    *   NORMINV(G12;0;1)    +    (J12/(1-J12))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E12*G12   )*( (1+(K12-2,5)*L12) / (1-1,5*L12)  )*12,5*1,06)"
            'Original Formula:=IF(ISERROR((E13*NORMDIST(  (1/(1-J13))^0,5    *   NORMINV(G13;0;1)    +    (J13/(1-J13))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E13*G13   )*( (1+(K13-2,5)*L13) / (1-1,5*L13)  )*12,5*1,06);"n.a.";(E13*NORMDIST(  (1/(1-J13))^0,5    *   NORMINV(G13;0;1)    +    (J13/(1-J13))^0,5  *  NORMINV($F$5;0;1);0;1;TRUE)   - E13*G13   )*( (1+(K13-2,5)*L13) / (1-1,5*L13)  )*12,5*1,06)

            Dim RangeUL_Totals_N As CellRange = worksheet.Range("N12:N" & UL_Totals_LastRow)
            RangeUL_Totals_N.Formula = "=IF(ISERROR(M12*D12*0,08);0;M12*D12*0,08)"

            Dim RangeUL_Totals_O As CellRange = worksheet.Range("O12:O" & UL_Totals_LastRow)
            RangeUL_Totals_O.Formula = "=D12*E12*F12"

            Dim RangeUL_Totals_P As CellRange = worksheet.Range("P12:P" & UL_Totals_LastRow)
            RangeUL_Totals_P.Formula = "=D12*F12*0,45"

            Dim RangeUL_Totals_Q As CellRange = worksheet.Range("Q12:Q" & UL_Totals_LastRow)
            RangeUL_Totals_Q.Formula = "=D12/SUM($D$12:$D$" & UL_Totals_LastRow & ")"

            Dim RangeUL_Totals_R As CellRange = worksheet.Range("R12:R" & UL_Totals_LastRow)
            RangeUL_Totals_R.Formula = "=IF(ISERROR(N12/D12);0;N12/D12)"

            Dim RangeUL_Totals_S As CellRange = worksheet.Range("S12:S" & UL_Totals_LastRow)
            RangeUL_Totals_S.Formula = "=E12*G12"

            Dim RangeUL_Totals_T As CellRange = worksheet.Range("T12:T" & UL_Totals_LastRow)
            RangeUL_Totals_T.Formula = "=E12"

            Dim RangeUL_Totals_U As CellRange = worksheet.Range("U12:U" & UL_Totals_LastRow)
            RangeUL_Totals_U.Formula = "=$E$5*T12*(1-T12)"

            Dim RangeUL_Totals_V As CellRange = worksheet.Range("V12:V" & UL_Totals_LastRow)
            RangeUL_Totals_V.Formula = "=IF(ISERROR((T12^2+U12)/T12);0;(T12^2+U12)/T12)"

            Dim RangeUL_Totals_W As CellRange = worksheet.Range("W12:W" & UL_Totals_LastRow)
            RangeUL_Totals_W.Formula = "=IF(ISERROR(Q12^2*(($D$5*V12*(R12+S12) +$D$5*(R12+S12)^2 *(U12^2)/(T12^2))-R12*(V12+2*(R12+S12)*(U12^2)/(T12^2))));0;Q12^2*(($D$5*V12*(R12+S12)+$D$5*(R12+S12)^2*(U12^2)/(T12^2))-R12*(V12+2*(R12+S12)*(U12^2)/(T12^2))))"


            worksheet.Cells("C5").Formula = "=SUMPRODUCT(Q12:Q" & UL_Totals_LastRow & ";R12:R" & UL_Totals_LastRow & ")"
            worksheet.Cells("O10").Formula = "=SUM(O12:O" & UL_Totals_LastRow & ")"
            worksheet.Cells("P10").Formula = "=SUM(P12:P" & UL_Totals_LastRow & ")"
            worksheet.Cells("W11").Formula = "=SUM(W12:W" & UL_Totals_LastRow & ")/(2*$C$5)"

            'Expected Loss
            'worksheet.Cells("C8").Formula = "=O10"
            'Unexpected Loss
            worksheet.Cells("D8").Formula = "=SUM(N12:N" & UL_Totals_LastRow & ")"
            'Granularity Approach
            worksheet.Cells("E8").Formula = "=W11*SUM(D12:D" & UL_Totals_LastRow & ")"

        End If




        'Dim range As CellRange = worksheet1.Range("A:AC")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Color.Black
        'rangeFormatting.Fill.BackgroundColor = Color.White
        'range.EndUpdateFormatting(rangeFormatting)

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
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