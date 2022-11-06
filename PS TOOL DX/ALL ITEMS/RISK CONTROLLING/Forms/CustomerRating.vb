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
Public Class CustomerRating

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Private BS_ExternalRating As BindingSource
    Private BS_InternalRating As BindingSource

    Dim RATING_MAIN As String = Nothing
    Dim PrintGrid As Integer = 0

    Dim NewPD As Double = 0
    Dim NewER As Double = 0
    Dim NewER45 As Double = 0
    Dim CoreDefinition As String = ""
    Dim StandardPoorsRating As String = ""
    Dim MainlandBranchRating As String = ""
    Dim MoodysRating As String = ""
    Dim FitchRating As String = ""

    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()


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

    Private Sub CUSTOMER_RATINGBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CUSTOMER_RATINGBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingBasicsDataSet)

    End Sub

    Private Sub CustomerRating_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If LayoutControl1.Visible = False Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.CUSTOMER_RATING_DETAILSBindingSource.CancelEdit()
                Me.LayoutControl1.Visible = True
                Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
                Me.CUSTOMER_RATING_DETAILSTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS)
                LOAD_ALL_RATINGS()
                SplashScreenManager.CloseForm(False)
            End If
        End If
        If e.KeyCode = Keys.F5 Then
            If LayoutControl1.Visible = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
                Me.CUSTOMER_RATING_DETAILSTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS)
                LOAD_ALL_RATINGS()
                SplashScreenManager.CloseForm(False)
            End If
        End If
    End Sub

    Private Sub CustomerRating_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Me.LayoutControl1.Dock = DockStyle.Fill

        'Me.PDTableAdapter.Fill(Me.RiskControllingBasicsDataSet.PD)
        Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        Me.CUSTOMER_RATING_DETAILSTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS)
        LOAD_ALL_RATINGS()

        EXTERNAL_RATING_initData()
        EXTERNAL_RATING_InitLookUp()
        INTERNAL_RATING_initData()
        INTERNAL_RATING_InitLookUp()

    End Sub

    Private Sub LOAD_ALL_RATINGS()
        Me.GridControl4.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT  A.[ID],A.[ClientNo],B.ClientType,B.Valid,B.[ClientName],A.[RatingType],A.[Rating],A.[CoreDefinition],A.[Valid_From],A.[Valid_Till],A.[IDNr] FROM [CUSTOMER_RATING_DETAILS] A INNER JOIN [CUSTOMER_RATING] B on A.[IDNr]=B.[ID] order by A.ClientNo  asc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.GridControl4.DataSource = Nothing
                    Me.GridControl4.DataSource = objDataTable
                    Me.GridControl4.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Try
            If e.Button.ButtonType = NavigatorButtonType.Custom Then
                If e.Button.Tag.ToString = "AddInternalRating" Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select Count(ID) from [CUSTOMER_RATING_DETAILS] where [ClientNo]='" & RatingClientNr_TextEdit.Text & "' and [RatingType]='INTERNAL' and [Valid_Till]='99991231'"
                    Dim Result As Double = cmd.ExecuteScalar
                    If Result = 0 Then
                        cmd.CommandText = "INSERT INTO [CUSTOMER_RATING_DETAILS]([ClientNo],[ClientName],[RatingType],[Rating],[CoreDefinition],[PD],[Valid_From],[Valid_Till],[IDNr]) SELECT [ClientNo],[ClientName],'INTERNAL' as 'RatingType','U',NULL,0 as 'PD',DATEADD(d,DATEDIFF(d,0,GETDATE()),0) as 'Valid_From','99991231' as 'Valid_Till',[ID] FROM [CUSTOMER_RATING] where [ClientNo]='" & RatingClientNr_TextEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Me.CUSTOMER_RATING_DETAILSTableAdapter.FillByClientNr(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS, RatingClientNr_TextEdit.Text)

                    ElseIf Result <> 0 Then
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show("There's an Internal Rating for current customer with validity till 31.12.9999!" & vbNewLine & "Please modify the validity of current internal Rating first!", "UNABLE TO ADD NEW CUSTOMER INTERNAL RATING", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If

                If e.Button.Tag.ToString = "AddExternalRating" Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "Select Count(ID) from [CUSTOMER_RATING_DETAILS] where [ClientNo]='" & RatingClientNr_TextEdit.Text & "' and [RatingType]='EXTERNAL'  and [Valid_Till]='99991231'"
                    Dim Result As Double = cmd.ExecuteScalar
                    If Result = 0 Then
                        cmd.CommandText = "INSERT INTO [CUSTOMER_RATING_DETAILS]([ClientNo],[ClientName],[RatingType],[Rating],[CoreDefinition],[PD],[Valid_From],[Valid_Till],[IDNr]) SELECT [ClientNo],[ClientName],'EXTERNAL' as 'RatingType','No Rating',NULL,0 as 'PD',DATEADD(d,DATEDIFF(d,0,GETDATE()),0) as 'Valid_From','99991231' as 'Valid_Till',[ID] FROM [CUSTOMER_RATING] where [ClientNo]='" & RatingClientNr_TextEdit.Text & "'"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Me.CUSTOMER_RATING_DETAILSTableAdapter.FillByClientNr(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS, RatingClientNr_TextEdit.Text)

                    ElseIf Result <> 0 Then
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show("There's an External Rating for current customer with validity till 31.12.9999!" & vbNewLine & "Please modify the validity of current external Rating first!", "UNABLE TO ADD NEW CUSTOMER EXTERNAL RATING", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                    End If
                End If

            End If
        Catch ex As Exception
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try


    End Sub

    Private Sub EXTERNAL_RATING_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbExternalRating As SqlDataAdapter = New SqlDataAdapter("SELECT [Rating],[Stufe],[CentralGov],[InstiOver3M],[InstiLess3M],[Corporates] FROM [PD_EXTERNAL] order by Stufe asc,rating asc", conn) '
        Try

            dbExternalRating.Fill(ds, "PD_EXTERNAL")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ExternalRating = New BindingSource(ds, "PD_EXTERNAL")

    End Sub

    Private Sub EXTERNAL_RATING_InitLookUp()
        Me.ExternalRatingRepositoryItemGridLookUpEdit.DataSource = BS_ExternalRating
        Me.ExternalRatingRepositoryItemGridLookUpEdit.DisplayMember = "Rating"
        Me.ExternalRatingRepositoryItemGridLookUpEdit.ValueMember = "Rating"

        'Me.ExternalRating_GridLookUpEdit.Properties.DataSource = BS_ExternalRating
        'Me.ExternalRating_GridLookUpEdit.Properties.DisplayMember = "Rating"
        'Me.ExternalRating_GridLookUpEdit.Properties.ValueMember = "Rating"

        Me.RATING_GridLookUpEdit.Properties.DataSource = BS_ExternalRating
        Me.RATING_GridLookUpEdit.Properties.DisplayMember = "Rating"
        Me.RATING_GridLookUpEdit.Properties.ValueMember = "Rating"

    End Sub

    Private Sub INTERNAL_RATING_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbInternalRating As SqlDataAdapter = New SqlDataAdapter("SELECT [Obligor Grade] as 'Rating' from [PD] UNION ALL SELECT 'No Rating' as 'Rating' ", conn) '
        Try

            dbInternalRating.Fill(ds, "PD")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_InternalRating = New BindingSource(ds, "PD")

    End Sub

    Private Sub INTERNAL_RATING_InitLookUp()
        Me.RATING_GridLookUpEdit.Properties.DataSource = BS_InternalRating
        Me.RATING_GridLookUpEdit.Properties.DisplayMember = "Rating"
        Me.RATING_GridLookUpEdit.Properties.ValueMember = "Rating"
    End Sub

    Private Sub ACTIVE_CREDIT_RATING()
        'If Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Checked Then
        'Me.ActiveCreditRatingCalculation_CheckEdit.Text = "Active Credit Rating Calculation"
        'Me.ActiveCreditRatingCalculation_CheckEdit.BackColor = Color.Green
        'Me.ActiveCreditRatingCalculation_CheckEdit.ForeColor = Color.White
        'ElseIf Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Unchecked Then
        'Me.ActiveCreditRatingCalculation_CheckEdit.Text = "Deactivated Credit Rating Calculation"
        'Me.ActiveCreditRatingCalculation_CheckEdit.BackColor = Color.Red
        'Me.ActiveCreditRatingCalculation_CheckEdit.ForeColor = Color.White
        'End If
    End Sub

    Private Sub Rating_LookUpEdit_EditValueChanged(sender As Object, e As EventArgs)
        'If Me.Rating_LookUpEdit.Text <> "" Then

        'Dim NewObligorGrate As String = Me.Rating_LookUpEdit.Text
        'Me.QueryText = "SELECT * FROM [PD] WHERE [Obligor Grade]='" & NewObligorGrate & "'"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New DataTable()
        'da.Fill(dt)
        'If dt.Rows.Count > 0 Then
        'NewPD = Convert.ToDouble(dt.Rows.Item(0).Item("PD"))
        'NewER = Convert.ToDouble(dt.Rows.Item(0).Item("ER_25")) 'Get the standard Value
        'NewER45 = Convert.ToDouble(dt.Rows.Item(0).Item("ER_45"))
        'CoreDefinition = dt.Rows.Item(0).Item("CoreDefinition")
        'StandardPoorsRating = dt.Rows.Item(0).Item("StandardPoorsRating")
        'If IsDBNull(dt.Rows.Item(0).Item("MainlandBranchRating")) = False Then
        'MainlandBranchRating = dt.Rows.Item(0).Item("MainlandBranchRating")
        'Else
        'MainlandBranchRating = ""
        'End If
        'MoodysRating = dt.Rows.Item(0).Item("MoodysRating")
        'FitchRating = dt.Rows.Item(0).Item("FitchRating")
        'End If

        'Me.PD_TextEdit.Text = NewPD
        'Me.ER25_txtEdit.Text = NewER
        'Me.ER45_TextEdit.Text = NewER45
        'Me.Rating_TextEdit.Text = Me.Rating_LookUpEdit.Text
        'Me.CoreDefinition_TextEdit.Text = CoreDefinition
        'Me.StandardPoors_TextEdit.Text = StandardPoorsRating
        'Me.MainlandRating_TextEdit.Text = MainlandBranchRating
        'Me.MoodysRating_TextEdit.Text = MoodysRating
        'Me.FitchRating_TextEdit.Text = FitchRating
        'End If
    End Sub

    Private Sub Rating_LookUpEdit_Popup(sender As Object, e As EventArgs)

        'Dim row As System.Data.DataRow = CustomerRating_BaseView.GetDataRow(CustomerRating_BaseView.FocusedRowHandle)
        'Me.Rating_LookUpEdit.EditValue = row(3)

        'Me.PD_TextEdit.Text = row(15)
        'Me.ER25_txtEdit.Text = row(16)

    End Sub

    Private Sub PopUpContainer_Cancel_btn_Click(sender As Object, e As EventArgs)
        'Dim edit As PopupContainerControl = PopupContainerControl1
        'edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub ConfirmNewObligorGrate_btn_Click(sender As Object, e As EventArgs)

        'If Me.Rating_LookUpEdit.Text <> "" Then
        'Try
        'Me.PD_TextEdit.Text = NewPD
        'Me.ER25_txtEdit.Text = NewER
        'Me.ER45_TextEdit.Text = NewER45
        'Me.Rating_TextEdit.Text = Me.Rating_LookUpEdit.Text
        'Me.CoreDefinition_TextEdit.Text = CoreDefinition
        'Me.StandardPoors_TextEdit.Text = StandardPoorsRating
        'Me.MainlandRating_TextEdit.Text = MainlandBranchRating
        'Me.MoodysRating_TextEdit.Text = MoodysRating
        'Me.FitchRating_TextEdit.Text = FitchRating

        'Set Fields to accept new Data
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("CoreDefinition").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("CoreDefinition").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("StandardPoorsRating").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("StandardPoorsRating").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MainlandBranchRating").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MainlandBranchRating").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MoodysRating").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MoodysRating").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("FitchRating").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("FitchRating").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = True

        'With CustomerRating_BaseView
        '.SetRowCellValue(.FocusedRowHandle, colRating, Me.Rating_LookUpEdit.Text)
        '.SetRowCellValue(.FocusedRowHandle, colPD, NewPD)
        '.SetRowCellValue(.FocusedRowHandle, colCoreDefinition, CoreDefinition)
        '.SetRowCellValue(.FocusedRowHandle, colStandardPoorsRating, StandardPoorsRating)
        '.SetRowCellValue(.FocusedRowHandle, ColMainlandBranchRating, MainlandBranchRating)
        '.SetRowCellValue(.FocusedRowHandle, colMoodysRating, MoodysRating)
        '.SetRowCellValue(.FocusedRowHandle, colFitchRating, FitchRating)
        '.SetRowCellValue(.FocusedRowHandle, colER_25, NewER) 'Field allows modification
        '.SetRowCellValue(.FocusedRowHandle, colER_45, NewER45)
        '.SetRowCellValue(.FocusedRowHandle, colActiveRating, 1)
        'End With

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'ACTIVE RATING CALCULATION
        'Dim row As System.Data.DataRow = CustomerRating_BaseView.GetDataRow(CustomerRating_BaseView.FocusedRowHandle)
        'Dim CurrentObligorGrate As String = row(3)

        'If Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Unchecked Then
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = True
        'With CustomerRating_BaseView
        '.SetRowCellValue(.FocusedRowHandle, colPD, 0)
        '.SetRowCellValue(.FocusedRowHandle, colER_25, 0) 'Field allows modification
        '.SetRowCellValue(.FocusedRowHandle, colER_45, 0)
        '.SetRowCellValue(.FocusedRowHandle, colActiveRating, 0)
        'End With
        'Me.GridControl2.Update()
        'Me.CUSTOMER_RATINGBindingSource.EndEdit()
        'Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = False
        'ElseIf Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Checked Then
        'Me.QueryText = "SELECT * FROM [PD] WHERE [Obligor Grade]='" & CurrentObligorGrate & "'"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'dt = New DataTable()
        'da.Fill(dt)
        'If dt.Rows.Count > 0 Then
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = True
        'With CustomerRating_BaseView
        '.SetRowCellValue(.FocusedRowHandle, colPD, dt.Rows.Item(0).Item("PD"))
        '.SetRowCellValue(.FocusedRowHandle, colER_25, dt.Rows.Item(0).Item("ER_25")) 'Field allows modification
        '.SetRowCellValue(.FocusedRowHandle, colER_45, dt.Rows.Item(0).Item("ER_45"))
        '.SetRowCellValue(.FocusedRowHandle, colActiveRating, 1)
        'End With
        'Me.GridControl2.Update()
        'Me.CUSTOMER_RATINGBindingSource.EndEdit()
        'Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = False
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = True
        'Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = False
        'End If
        'End If
        '********************************************************************************************************



        'Set Fields to read only
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("CoreDefinition").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("CoreDefinition").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("StandardPoorsRating").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("StandardPoorsRating").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MainlandBranchRating").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MainlandBranchRating").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MoodysRating").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("MoodysRating").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("FitchRating").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("FitchRating").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = False
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = True
        Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = False

        Me.CUSTOMER_RATINGBindingSource.EndEdit()
        Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        'Update all Ratings
        cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MainlandBranchRating]=B.[MainlandBranchRating],A.[MoodysRating]=B.[MoodysRating],A.[FitchRating]=B.[FitchRating] FROM [CUSTOMER_RATING] A INNER JOIN [PD] B ON A.[Rating]=B.[Obligor Grade]"
        cmd.ExecuteNonQuery()
        'UPDATE CCB_GroupOwnID in CUSTOMER INFO
        cmd.CommandText = "UPDATE A SET A.[CCB_Group_OwnID]='Y' from [CUSTOMER_INFO] A INNER JOIN [CUSTOMER_RATING] B on A.ClientNo=B.ClientNo where A.[CCB_Group]='Y' and [CCB_Group_OwnID]='N' and B.ActiveRatingCalculation=1"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[CCB_Group_OwnID]='N' from [CUSTOMER_INFO] A INNER JOIN [CUSTOMER_RATING] B on A.ClientNo=B.ClientNo where A.[CCB_Group]='Y' and [CCB_Group_OwnID]='Y' and B.ActiveRatingCalculation=0"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        'Catch ex As Exception
        'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Exit Sub
        'End Try
        'End If
    End Sub

    Private Sub CustomerRating_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles CustomerRating_Print_Export_btn.Click
        If PrintGrid = 0 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 1 Then
            If Not GridControl4.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
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
        Dim reportfooter As String = "CUSTOMER RATINGS BY CLIENT NR."
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
        Dim reportfooter As String = "ALL CUSTOMER RATINGS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

   

    Private Sub CustomerRating_BaseView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles CustomerRating_BaseView.CellValueChanging
        Try
            Dim view As GridView = CType(sender, GridView)

            If Me.CustomerRating_BaseView.IsFilterRow(e.RowHandle) = False Then 'Wenn Kein Filter Row ist
                If e.Column.FieldName = "ActiveRatingCalculation" Then
                    Dim row As System.Data.DataRow = CustomerRating_BaseView.GetDataRow(CustomerRating_BaseView.FocusedRowHandle)
                    Dim PD As String = row(6)
                    'Dim ER1 As String = row(7)
                    Dim ER2 As String = row(8)
                    Dim CHECK As String = Me.CustomerRating_BaseView.GetFocusedRowCellValue(colActiveRating)

                    Dim CurrentObligorGrate As String = row(3)
                    If CurrentObligorGrate <> "U" Then
                        If CHECK = "True" Then
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = False
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = True
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = False
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = True
                            With CustomerRating_BaseView
                                .SetRowCellValue(.FocusedRowHandle, colPD, 0)
                                .SetRowCellValue(.FocusedRowHandle, colER_25, 0) 'Field allows modification
                                .SetRowCellValue(.FocusedRowHandle, colER_45, 0)
                                .SetRowCellValue(.FocusedRowHandle, colActiveRating, 0)
                            End With
                            Me.GridControl2.Update()
                            Me.CUSTOMER_RATINGBindingSource.EndEdit()
                            Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = True
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = False
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = True
                            Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = False
                        ElseIf CHECK = "False" Then
                            Me.QueryText = "SELECT * FROM [PD] WHERE [Obligor Grade]='" & CurrentObligorGrate & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = False
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = True
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = False
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = True
                                With CustomerRating_BaseView
                                    .SetRowCellValue(.FocusedRowHandle, colPD, dt.Rows.Item(0).Item("PD"))
                                    .SetRowCellValue(.FocusedRowHandle, colER_25, dt.Rows.Item(0).Item("ER_25")) 'Field allows modification
                                    .SetRowCellValue(.FocusedRowHandle, colER_45, dt.Rows.Item(0).Item("ER_45"))
                                    .SetRowCellValue(.FocusedRowHandle, colActiveRating, 1)
                                End With
                                Me.GridControl2.Update()
                                Me.CUSTOMER_RATINGBindingSource.EndEdit()
                                Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.ReadOnly = True
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_25").OptionsColumn.AllowEdit = False
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.ReadOnly = True
                                Me.CustomerRating_BaseView.Columns.ColumnByFieldName("ER_45").OptionsColumn.AllowEdit = False
                            End If
                        End If
                        'UPDATE CCB_GroupOwnID in CUSTOMER INFO
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "UPDATE A SET A.[CCB_Group_OwnID]='Y' from [CUSTOMER_INFO] A INNER JOIN [CUSTOMER_RATING] B on A.ClientNo=B.ClientNo where A.[CCB_Group]='Y' and [CCB_Group_OwnID]='N' and B.ActiveRatingCalculation=1"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[CCB_Group_OwnID]='N' from [CUSTOMER_INFO] A INNER JOIN [CUSTOMER_RATING] B on A.ClientNo=B.ClientNo where A.[CCB_Group]='Y' and [CCB_Group_OwnID]='Y' and B.ActiveRatingCalculation=0"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                    Else
                        MessageBox.Show("Please define first the Obligor Grate for the Customer!", "NO OBLIGOR GRATE DEFINED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub CustomerRating_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerRating_BaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerRating_BaseView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles CustomerRating_BaseView.ShowingEditor
        ACTIVE_CREDIT_RATING()
    End Sub

    Private Sub CustomerRating_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerRating_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

   
    Private Sub RepositoryItemPopupContainerEdit1_Popup(sender As Object, e As EventArgs) Handles RepositoryItemPopupContainerEdit1.Popup
        Dim row As System.Data.DataRow = CustomerRating_BaseView.GetDataRow(CustomerRating_BaseView.FocusedRowHandle)
        'Me.Rating_LookUpEdit.EditValue = row(3)
    End Sub

    Private Sub ER25_txtEdit_EditValueChanged(sender As Object, e As EventArgs)
        'If IsNumeric(ER25_txtEdit.Text) = True Then
        'NewER = Me.ER25_txtEdit.Text
        'End If
    End Sub

    
    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        If Me.RepositoryItemCheckEdit1.ValueChecked = 1 Then
            MsgBox("Checked")
        Else
            MsgBox("Unchecked")
        End If
    End Sub

    Private Sub DefineAsNormalCustomer_btn_Click(sender As Object, e As EventArgs)
        Try
            Dim row As System.Data.DataRow = CustomerRating_BaseView.GetDataRow(CustomerRating_BaseView.FocusedRowHandle)
            Dim ClientNr As String = row(1)
            Dim test As String = Me.CustomerRating_BaseView.GetRowCellValue(Me.CustomerRating_BaseView.FocusedRowHandle, colClientNo)
            'MsgBox(ClientNr & "  " & test)

            'Update all Ratings
            cmd.CommandText = "UPDATE [CUSTOMER_RATING] SET [Rating]='CA',[ActiveRatingCalculation]=0, [CoreDefinition]=NULL,[StandardPoorsRating]=NULL,[MoodysRating]=NULL,[FitchRating]=NULL,[MainlandBranchRating]=NULL,[PD]=NULL,[ER_25]=NULL,[ER_45]=NULL,[RatingExceptions]=NULL where [ClientNo]='" & ClientNr & "'"
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()


            Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub ER45_TextEdit_EditValueChanged(sender As Object, e As EventArgs)
        'If IsNumeric(ER45_TextEdit.Text) = True Then
        'NewER45 = Me.ER45_TextEdit.Text
        'End If
    End Sub

    Private Sub ExternalRatingRepositoryItemGridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExternalRatingRepositoryItemGridLookUpEdit.EditValueChanged
        Try
            CustomerRating_BaseView.PostEditor()
            Me.CUSTOMER_RATINGBindingSource.EndEdit()
            Me.CUSTOMER_RATINGTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.CUSTOMER_RATINGBindingSource.CancelEdit()
            CustomerRating_BaseView.HideEditor()

        End Try
    End Sub

    Private Sub ExternalRatingRepositoryItemGridLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExternalRatingRepositoryItemGridLookUpEdit1View.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExternalRatingRepositoryItemGridLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles ExternalRatingRepositoryItemGridLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ExternalRating_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExternalRating_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ActiveCreditRatingCalculation_CheckEdit_CheckedChanged(sender As Object, e As EventArgs)
        Try
            ACTIVE_CREDIT_RATING()
            'If Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Unchecked Then
            'Me.PD_TextEdit.Text = "0"
            'Me.ER25_txtEdit.Text = "0"
            'Me.ER45_TextEdit.Text = "0"

            'ElseIf Me.ActiveCreditRatingCalculation_CheckEdit.CheckState = CheckState.Checked Then
            'Me.QueryText = "SELECT * FROM [PD] WHERE [Obligor Grade]='" & Me.Rating_TextEdit.Text & "'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            'Me.PD_TextEdit.Text = dt.Rows.Item(0).Item("PD")
            'Me.ER25_txtEdit.Text = dt.Rows.Item(0).Item("ER_25") 'Field allows modification
            'Me.ER45_TextEdit.Text = dt.Rows.Item(0).Item("ER_45")
            'End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Me.LayoutControl1.Visible = False
    End Sub

    Private Sub CustomerRatingDetailsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerRatingDetailsView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerRatingDetailsView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles CustomerRatingDetailsView.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        RATING_MAIN = Nothing
        RATING_MAIN = view.GetRowCellValue(rowHandle, colRatingType1)

        If RATING_MAIN = "INTERNAL" Then
            Me.RATING_GridLookUpEdit.Properties.DataSource = Nothing
            Me.RATING_GridLookUpEdit.Properties.DataSource = BS_InternalRating
        ElseIf RATING_MAIN = "EXTERNAL" Then
            Me.RATING_GridLookUpEdit.Properties.DataSource = Nothing
            Me.RATING_GridLookUpEdit.Properties.DataSource = BS_ExternalRating
        End If
    End Sub

    Private Sub RepositoryItemPopupContainerEdit2_Popup(sender As Object, e As EventArgs) Handles RepositoryItemPopupContainerEdit2.Popup

    End Sub

    
    Private Sub SaveRatingDetails_btn_Click(sender As Object, e As EventArgs) Handles SaveRatingDetails_btn.Click
        If Me.RATING_GridLookUpEdit.Text <> "" Then
            Dim Date_From As Date = Me.ValidFrom_TextEdit.Text
            Dim Date_Till As Date = Me.ValidTill_TextEdit.Text

            If Date_Till >= Date_From Then
                Try
                    'CustomerRatingDetailsView.PostEditor()
                    CustomerRatingDetailsView.CloseEditor()
                    Me.CUSTOMER_RATING_DETAILSBindingSource.EndEdit()
                    Me.CUSTOMER_RATING_DETAILSTableAdapter.Update(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "UPDATE A SET A.[Rating]='U' FROM [CUSTOMER_RATING] A where EXISTS(Select * from [CUSTOMER_RATING_DETAILS] B where A.ClientNo=B.ClientNo and B.Rating in ('U'))"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[Rating]='Y' FROM [CUSTOMER_RATING] A where NOT EXISTS(Select * from [CUSTOMER_RATING_DETAILS] B where A.ClientNo=B.ClientNo and B.Rating in ('U'))"
                    cmd.ExecuteNonQuery()
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Me.CUSTOMER_RATING_DETAILSTableAdapter.FillByClientNr(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS, RatingClientNr_TextEdit.Text)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.CUSTOMER_RATING_DETAILSBindingSource.CancelEdit()
                    CustomerRatingDetailsView.HideEditor()

                End Try
            Else
                MessageBox.Show("Valid from is higher than Valid till Date!" & vbNewLine & "Please correct the rating validity!!", "UNABLE TO SAVE CURRENT RATING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            MessageBox.Show("There's no indicated rating for customer" & vbNewLine & "Please set customer Rating first!", "UNABLE TO SAVE CURRENT RATING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return

        End If

    End Sub

    Private Sub CancelRatingDetails_btn_Click(sender As Object, e As EventArgs) Handles CancelRatingDetails_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl2
        edit.OwnerEdit.CancelPopup()
    End Sub

    Private Sub DisplayAllCustomers_btn_Click(sender As Object, e As EventArgs) Handles DisplayAllCustomers_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        Me.LayoutControl1.Visible = True
        Me.CUSTOMER_RATINGTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING)
        Me.CUSTOMER_RATING_DETAILSTableAdapter.Fill(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS)
        LOAD_ALL_RATINGS()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub DeleteRatingDetails_btn_Click(sender As Object, e As EventArgs) Handles DeleteRatingDetails_btn.Click
        Try
            If MessageBox.Show("Should the current Rating be deleted?", "RATING DELETION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "DELETE FROM [CUSTOMER_RATING_DETAILS] where [ID]='" & IDNr_lbl.Text & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[Rating]='U' FROM [CUSTOMER_RATING] A where EXISTS(Select * from [CUSTOMER_RATING_DETAILS] B where A.ClientNo=B.ClientNo and B.Rating in ('U'))"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[Rating]='Y' FROM [CUSTOMER_RATING] A where NOT EXISTS(Select * from [CUSTOMER_RATING_DETAILS] B where A.ClientNo=B.ClientNo and B.Rating in ('U'))"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                Me.CUSTOMER_RATING_DETAILSTableAdapter.FillByClientNr(Me.RiskControllingBasicsDataSet.CUSTOMER_RATING_DETAILS, RatingClientNr_TextEdit.Text)
            End If
        Catch ex As Exception
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub RepositoryItemImageComboBox1_DoubleClick(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox1.DoubleClick
        Me.LayoutControl1.Visible = False
    End Sub

    Private Sub RepositoryItemImageComboBox2_DoubleClick(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox2.DoubleClick
        Me.LayoutControl1.Visible = False
    End Sub

    Private Sub RatingStatus_RepositoryItemImageComboBox_DoubleClick(sender As Object, e As EventArgs) Handles RatingStatus_RepositoryItemImageComboBox.DoubleClick
        Me.LayoutControl1.Visible = False
    End Sub

    Private Sub CustomerRating_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerRating_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerRating_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerRating_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CustomerRatingDetailsView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerRatingDetailsView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "RATINGS BY CLIENT NR." Then
            PrintGrid = 0
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL RATINGS" Then
            PrintGrid = 1
        End If
    End Sub

    Private Sub Ratings_All_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Ratings_All_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Ratings_All_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Ratings_All_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Ratings_All_GridView_DoubleClick(sender As Object, e As EventArgs) Handles Ratings_All_GridView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "ClientNo" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "ClientNo").ToString
                If IsNothing(ClientNr) = False And IsNumeric(ClientNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub RatingClientNr_TextEdit_DoubleClick(sender As Object, e As EventArgs) Handles RatingClientNr_TextEdit.DoubleClick
        If Me.LayoutControl1.Visible = False Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                GLOBAL_CLIENT_NR = RatingClientNr_TextEdit.EditValue
                SplashScreenManager.CloseForm(False)
                Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & RatingClientNr_TextEdit.EditValue
                Me.CustomersVerticalGrid.ShowDialog()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try



        End If
    End Sub
End Class