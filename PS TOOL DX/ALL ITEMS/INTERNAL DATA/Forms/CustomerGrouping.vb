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
Imports System.Linq
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraTreeList


Public Class CustomerGrouping

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing

    Dim GridViewCaption As String = Nothing

    Dim PrintGrid As Integer = 1

    Dim ResidenceCountryEU_Member As String = Nothing
    Dim GroupType As String = Nothing
    Dim GROUP_ID As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Private BS_All_Groups As BindingSource
    Private BS_National_Identifiers As BindingSource
    Private BS_Legal_Codes As BindingSource




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

    Private Sub CustomerGrouping_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Me.LayoutControl1.Visible = False Then
            If e.KeyCode = Keys.Escape Then
                Me.Cancel_btn.PerformClick()

            End If
        End If

    End Sub



    Private Sub CustomerGrouping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl1.Dock = DockStyle.Fill

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.GROUP_CLIENT_DETAILSTableAdapter.Fill(Me.CustomerGroups.GROUP_CLIENT_DETAILS)
        Me.GROUP_CLIENTTableAdapter.Fill(Me.CustomerGroups.GROUP_CLIENT)
        Me.GROUP_INTERTableAdapter.Fill(Me.CustomerGroups.GROUP_INTER)
        Me.GROUP_MASTERTableAdapter.Fill(Me.CustomerGroups.GROUP_MASTER)
        LOAD_ALL_MASTER_INTERGROUP()
        LOAD_ALL_GROUP_DETAILS()
        'TreeList1.DataSource = CreateTable(30)
        'TREELIST_FILL()
        If SUPER_USER = "Y" OrElse EDP_USER = "Y" Then
            Me.LoadFromBAIS_btn.Visible = True
        Else
            Me.LoadFromBAIS_btn.Visible = False
        End If

    End Sub

    Private Sub LoadFromBAIS_btn_Click(sender As Object, e As EventArgs) Handles LoadFromBAIS_btn.Click
        Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            'cmd.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
            'cmd.ExecuteNonQuery()
            If MessageBox.Show("Should all Client Groups Data be reloaded from the BAIS Database?" & vbNewLine & "--Current Data will be deleted--", "Load Client Groups Data from the BAIS Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Client Groups Data from the BAIS Database")
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('BAIS_LOADS_ALL_CLIENT_DATA') and [Id_SQL_Parameters] in ('BAIS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BAIS_LOADS_ALL_CLIENT_DATA')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString
                        cmd.CommandText = SqlCommandText
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("All Client Groups are loaded from BAIS")
                    Me.GROUP_CLIENT_DETAILSTableAdapter.Fill(Me.CustomerGroups.GROUP_CLIENT_DETAILS)
                    Me.GROUP_CLIENTTableAdapter.Fill(Me.CustomerGroups.GROUP_CLIENT)
                    Me.GROUP_INTERTableAdapter.Fill(Me.CustomerGroups.GROUP_INTER)
                    Me.GROUP_MASTERTableAdapter.Fill(Me.CustomerGroups.GROUP_MASTER)
                    LOAD_ALL_MASTER_INTERGROUP()
                    LOAD_ALL_GROUP_DETAILS()
                    SplashScreenManager.CloseForm(False)
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Parameter:BAIS_LOADS_ALL_CLIENT_DATA is invalid", "Parameter Status:INVALID")
                    Return

                End If
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error")
            Return
        End Try

    End Sub

    Private Function CreateTable(RowCount As Integer) As DataTable
        Me.QueryText = "SELECT  A.[GroupMasterName] as 'GroupIDName',A.[GroupMasterID] as 'ID',A.[GroupMasterID] as 'GroupID', 0 as 'ParentID',A.GroupStatus FROM [GROUP_MASTER] A UNION ALL SELECT A.InterGroupName as 'GroupIDName',A.InterGroupID as 'ID',A.InterGroupID as 'GroupID',B.[GroupMasterID] as 'ParentID',A.GroupStatus FROM [GROUP_INTER] A INNER JOIN GROUP_MASTER B on A.Id_Master_Group=B.GroupMasterID UNION ALL SELECT A.ClientName as 'GroupIDName',A.ID as 'ID',A.ClientNr as 'GroupID',b.InterGroupID as 'ParentID',A.InterGroupStatus FROM [GROUP_CLIENT] A INNER JOIN GROUP_INTER B on A.Id_Inter_Group=b.InterGroupID"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)

        Dim tbl As New DataTable()
        tbl.Columns.Add("GroupIDName", GetType(String))
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("GroupID", GetType(Integer))
        tbl.Columns.Add("ParentID", GetType(Integer))
        tbl.Columns.Add("GroupStatus", GetType(String))

        For Each dr As DataRow In dt.Rows
            tbl.Rows.Add(New Object() {dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4)})
        Next


        Return tbl
    End Function

    Private Sub TREELIST_FILL()
        Me.QueryText = "SELECT  A.[GroupMasterName] as 'GroupIDName',A.[GroupMasterID] as 'ID',A.[GroupMasterID] as 'GroupID', 0 as 'ParentID',A.GroupStatus FROM [GROUP_MASTER] A UNION ALL SELECT A.InterGroupName as 'GroupIDName',A.InterGroupID as 'ID',A.InterGroupID as 'GroupID',B.[GroupMasterID] as 'ParentID',A.GroupStatus FROM [GROUP_INTER] A INNER JOIN GROUP_MASTER B on A.Id_Master_Group=B.GroupMasterID UNION ALL SELECT A.ClientName as 'GroupIDName',A.ID as 'ID',A.ClientNr as 'GroupID',b.InterGroupID as 'ParentID',A.InterGroupStatus FROM [GROUP_CLIENT] A INNER JOIN GROUP_INTER B on A.Id_Inter_Group=b.InterGroupID"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)

        Dim tbl As New DataTable()
        tbl.Columns.Add("GroupIDName", GetType(String))
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("GroupID", GetType(Integer))
        tbl.Columns.Add("ParentID", GetType(Integer))
        tbl.Columns.Add("GroupStatus", GetType(String))

        For Each dr As DataRow In dt.Rows
            tbl.Rows.Add(New Object() {dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4)})
        Next

        Me.TreeList1.DataSource = tbl


    End Sub

    Private Sub ALL_GROUPS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT 'MASTERGROUP' as 'GroupType',[GroupMasterID] as 'GROUP_ID',[GroupMasterName] as 'GROUP_ID_NAME',GroupStatus FROM [GROUP_MASTER] UNION ALL SELECT 'INTERGROUP' as 'GroupType',[InterGroupID] as 'GROUP_ID',[InterGroupName] as 'GROUP_ID_NAME',GroupStatus FROM [GROUP_INTER]", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAllCustomers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbAllCustomers.Fill(ds, "ALL_CUSTOMERS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_Groups = New BindingSource(ds, "ALL_CUSTOMERS")
    End Sub

    Private Sub ALL_GROUPS_InitLookUp()
        Me.ClientSearch_GridLookUpEdit.Properties.DataSource = BS_All_Groups
        Me.ClientSearch_GridLookUpEdit.Properties.DisplayMember = "GROUP_ID"
        Me.ClientSearch_GridLookUpEdit.Properties.ValueMember = "GROUP_ID"
    End Sub

    Private Sub LOAD_ALL_MASTER_INTERGROUP()
        Me.ALL_MASTER_INTERGROUP_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT 'MASTERGROUP' as 'GroupType',[GroupStatus],[GroupMasterID] as 'GROUP_ID',[GroupMasterName] as 'GROUP_ID_NAME',[ClientName],[ClientStrasse],[ClientPLZ_Ort],[ClientPLZ_Nr],[ClientCountryResidence],[EU_COUNTRY],[ClientCountryRisk],[ClientBranch],[ClientBranchName],[SectorKWG],[SectorKWG_Description],[Sector_CRR],[Sector_CRR_Description],[Sector_BISTA],[Sector_BISTA_Description],[Sector_FINREP],[Sector_FINREP_Description],[BIC11],[BIC11_NAME],[LEI_CODE],[Int_Organ],[Tax_Identification_Nr],[National_Identifier_Type],[National_Identifier_Type_Description],[National_Identifier_Type_Value],[RIAD_Nr],[NUTS_3_Region],[Institutional_Sector],[Institutional_Sector_Description],[NACE_Branch_Code],[NACE_Branch_Code_Description],[Legal_Form],[Legal_Form_Description],[Legal_Form_Other],[AnaCredit_Customer],[AnaCredit_Valid] FROM [GROUP_MASTER] UNION ALL SELECT 'INTERGROUP' as 'GroupType',[GroupStatus],[InterGroupID] as 'GROUP_ID',[InterGroupName] as 'GROUP_ID_NAME',[ClientName],[ClientStrasse],[ClientPLZ_Ort],[ClientPLZ_Nr],[ClientCountryResidence],[EU_COUNTRY],[ClientCountryRisk],[ClientBranch],[ClientBranchName],[SectorKWG],[SectorKWG_Description],[Sector_CRR],[Sector_CRR_Description],[Sector_BISTA],[Sector_BISTA_Description],[Sector_FINREP],[Sector_FINREP_Description],[BIC11],[BIC11_NAME],[LEI_CODE],[Int_Organ],[Tax_Identification_Nr],[National_Identifier_Type],[National_Identifier_Type_Description],[National_Identifier_Type_Value],[RIAD_Nr],[NUTS_3_Region],[Institutional_Sector],[Institutional_Sector_Description],[NACE_Branch_Code],[NACE_Branch_Code_Description],[Legal_Form],[Legal_Form_Description],[Legal_Form_Other],[AnaCredit_Customer],[AnaCredit_Valid] FROM [GROUP_INTER]"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.ALL_MASTER_INTERGROUP_GridControl.DataSource = Nothing
                    Me.ALL_MASTER_INTERGROUP_GridControl.DataSource = objDataTable
                    Me.ALL_MASTER_INTERGROUP_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub LOAD_ALL_GROUP_DETAILS()
        Me.All_Groups_Details_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [GROUP_CLIENT_DETAILS] order by [ClientNr] asc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.All_Groups_Details_GridControl.DataSource = Nothing
                    Me.All_Groups_Details_GridControl.DataSource = objDataTable
                    Me.All_Groups_Details_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub NATIONAL_IDENTIFIERS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('" & Me.CountryOfResidence_TextEdit.Text & "','*','OTHER','Any') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('NATIONAL_IDENTIFIERS')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbNationalIdentifiers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbNationalIdentifiers.Fill(ds, "NATIONAL_IDENTIFIERS") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_National_Identifiers = New BindingSource(ds, "NATIONAL_IDENTIFIERS") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub NATIONAL_IDENTIFIERS_InitLookUp()
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.DataSource = BS_National_Identifiers
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_3"
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_3"
    End Sub

    Private Sub LEGAL_CODES_initData()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select 'EU_MEMBER_STATE'=Case when (Select '" & Me.CountryOfResidence_TextEdit.Text & "') in (Select [COUNTRY CODE] from COUNTRIES where [EU EEA] in ('EU')) then 'Y' else 'N' end"
        ResidenceCountryEU_Member = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        If ResidenceCountryEU_Member = "Y" Then
            Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_3] in ('" & Me.CountryOfResidence_TextEdit.Text & "','*','any EU country') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LEGAL_FORMS')) and [Status] in ('Y') order by ID asc", conn)
            objCMD1.CommandTimeout = 5000
            Dim dbLegal_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

            Dim ds As DataSet = New DataSet()
            'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
            Try

                dbLegal_Codes.Fill(ds, "LEGAL_CODES")

            Catch ex As System.Exception
                MsgBox(ex.Message)

            End Try
            BS_Legal_Codes = New BindingSource(ds, "LEGAL_CODES")
        ElseIf ResidenceCountryEU_Member = "N" Then
            Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_3] in ('any extra EU country','*') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LEGAL_FORMS')) and [Status] in ('Y') order by ID asc", conn)
            objCMD1.CommandTimeout = 5000
            Dim dbLegal_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

            Dim ds As DataSet = New DataSet()
            'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
            Try

                dbLegal_Codes.Fill(ds, "LEGAL_CODES")

            Catch ex As System.Exception
                MsgBox(ex.Message)

            End Try
            BS_Legal_Codes = New BindingSource(ds, "LEGAL_CODES")
        End If

    End Sub

    Private Sub LEGAL_CODES_InitLookUp()
        Me.LegalForm_SearchLookUpEdit.Properties.DataSource = BS_Legal_Codes
        Me.LegalForm_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.LegalForm_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub NationalIdentifiers_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NationalIdentifiers_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                'Dim view As GridView = NationalIdentifiers_SearchLookUpEdit.Properties.View
                'Dim rowHandle As Integer = view.FocusedRowHandle
                'Me.National_Identifier_Type_Description_lbl.Text = view.GetRowCellValue(rowHandle, "SQL_Name_4")

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim NationalIdentifiersRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.National_Identifier_Type_Description_lbl.Text = NationalIdentifiersRow("SQL_Name_4").ToString
                Me.NationalIdentifier_TextEdit.ReadOnly = False
                'If Me.NationalIdentifier_TextEdit.Text = "" Then
                '    Me.NationalIdentifier_TextEdit.Focus()
                'End If
                'Me.NationalIdentifierType_Other_TextEdit.Text = NationalIdentifiersRow("SQL_Name_3").ToString


                If Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("GEN_") = True Then
                    '    Me.NationalIdentifierType_Other_TextEdit.ReadOnly = False
                    'Else
                    '    Me.NationalIdentifierType_Other_TextEdit.Text = ""
                    '    Me.NationalIdentifierType_Other_TextEdit.ReadOnly = True
                End If
                'ElseIf Me.NationalIdentifiers_SearchLookUpEdit.Text = "" Then
                'Me.National_Identifier_Type_Description_lbl.Text = ""
                'End If
            Else
                Me.National_Identifier_Type_Description_lbl.Text = ""
                'Me.NationalIdentifierType_Other_TextEdit.Text = ""
                Me.NationalIdentifier_TextEdit.Text = ""
                'Me.NationalIdentifierType_Other_TextEdit.ReadOnly = True
                Me.NationalIdentifier_TextEdit.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub NationalIdentifier_TextEdit_GotFocus(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.GotFocus
        If Me.LayoutControl1.Visible = False Then
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                'SET MASK FOR GERMAN IDENTIFIER
                Dim GermanIdentifier As String = Me.NationalIdentifiers_SearchLookUpEdit.Text.ToString
                Select Case GermanIdentifier
                    Case "DE_HRA_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(HRA)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_HRB_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(HRB)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_PR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(PR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_VR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(VR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_GNR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(GnR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case Else
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
                End Select
            Else
                Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
                Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
            End If
        End If
    End Sub

    Private Sub NationalIdentifier_TextEdit_Leave(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.Leave
        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
    End Sub

    Private Sub NationalIdentifier_TextEdit_LostFocus(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.LostFocus
        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
    End Sub

    Private Sub NationalIdentifier_TextEdit_TextChanged(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.TextChanged
       
    End Sub

    Private Sub LegalForm_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LegalForm_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.LegalForm_SearchLookUpEdit.Text <> "" Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim LEGAL_FORM_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.LegalFormDescription_lbl.Text = LEGAL_FORM_Row("SQL_Name_4").ToString
                '    Me.LegalFormOther_TextEdit.Text = ""
                '    Me.LegalFormOther_TextEdit.ReadOnly = True
                'ElseIf Me.LegalForm_SearchLookUpEdit.Text = "" Or Me.LegalForm_SearchLookUpEdit.Text.StartsWith("-").ToString = True Then
                '    Me.LegalFormDescription_lbl.Text = ""
                '    Me.LegalFormOther_TextEdit.ReadOnly = False
            Else
                Me.LegalFormDescription_lbl.Text = ""
            End If
        End If

    End Sub

    Private Sub GL_Accounts_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles GL_Accounts_Print_Export_btn.Click
        If PrintGrid = 0 Then
            If Not GridControl3.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
           
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        'If PrintGrid = 1 Then
        '    If MessageBox.Show("Should also all the Nodes of the Customer Grouping be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
        '        Me.TreeList1.OptionsPrint.PrintAllNodes = True
        '    Else
        '        Me.TreeList1.OptionsPrint.PrintAllNodes = False
        '    End If

        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '    PrintableComponentLink2.CreateDocument()
        '    PrintableComponentLink2.ShowPreview()
        '    SplashScreenManager.CloseForm(False)
        'End If
        If PrintGrid = 1 Then
            If Not ALL_MASTER_INTERGROUP_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink3.CreateDocument()
            PrintableComponentLink3.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If PrintGrid = 3 Then
            If Not All_Groups_Details_GridControl.IsPrintingAvailable Then
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
        Dim reportfooter As String = "CUSTOMER GROUPING (Master/Detail View)"
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
        Dim reportfooter As String = "ALL CUSTOMER GROUPS (Treeview)"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "ALL MASTER + INTERGROUPS DATA"
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

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "CUSTOMER GROUPING (All Details)"
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


    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "CUSTOMER GROUPING (Master/Detail View)" Then
            PrintGrid = 0
            'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL CUSTOMER GROUPS (Treeview)" Then
            '    PrintGrid = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "ALL MASTER + INTERGROUPS" Then
            PrintGrid = 1
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "CUSTOMER GROUPING (All Details)" Then
            PrintGrid = 3
        End If
    End Sub

    Private Sub CustomerGroupingBASE_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles CustomerGroupingBASE_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingBASE_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "Intergroups on Master Group :" & view.GetFocusedRowCellValue("GroupMasterID").ToString & " - " & view.GetFocusedRowCellValue("GroupMasterName").ToString
            CustomerGroupingINTER_GridView.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingBASE_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles CustomerGroupingBASE_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingBASE_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "Intergroups on Master Group :" & view.GetFocusedRowCellValue("GroupMasterID").ToString & " - " & view.GetFocusedRowCellValue("GroupMasterName").ToString
            CustomerGroupingINTER_GridView.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingBASE_GridView_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles CustomerGroupingBASE_GridView.PrintInitialize
        If MessageBox.Show("Should also all the details of the Customer Grouping be printed?", "Print Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
            Me.CustomerGroupingBASE_GridView.OptionsPrint.ExpandAllDetails = True
            Me.CustomerGroupingINTER_GridView.OptionsPrint.ExpandAllDetails = True
            Me.CustomerGroupingCLIENT_Gridview.OptionsPrint.ExpandAllDetails = True
            Me.CustomerGroupingCLIENT_DETAIL_Gridview.OptionsPrint.ExpandAllDetails = True
            Me.CustomerGroupingBASE_GridView.OptionsPrint.PrintDetails = True
            Me.CustomerGroupingINTER_GridView.OptionsPrint.PrintDetails = True
            Me.CustomerGroupingCLIENT_Gridview.OptionsPrint.PrintDetails = True
            Me.CustomerGroupingCLIENT_DETAIL_Gridview.OptionsPrint.PrintDetails = True
        Else
            Me.CustomerGroupingBASE_GridView.OptionsPrint.ExpandAllDetails = False
            Me.CustomerGroupingINTER_GridView.OptionsPrint.ExpandAllDetails = False
            Me.CustomerGroupingCLIENT_Gridview.OptionsPrint.ExpandAllDetails = False
            Me.CustomerGroupingCLIENT_DETAIL_Gridview.OptionsPrint.ExpandAllDetails = False
            Me.CustomerGroupingBASE_GridView.OptionsPrint.PrintDetails = False
            Me.CustomerGroupingINTER_GridView.OptionsPrint.PrintDetails = False
            Me.CustomerGroupingCLIENT_Gridview.OptionsPrint.PrintDetails = False
            Me.CustomerGroupingCLIENT_DETAIL_Gridview.OptionsPrint.PrintDetails = False

        End If
    End Sub

    Private Sub CustomerGroupingBASE_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerGroupingBASE_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CustomerGroupingBASE_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerGroupingBASE_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub


    Private Sub CustomerGroupingCLIENT_DETAIL_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerGroupingCLIENT_DETAIL_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CustomerGroupingCLIENT_DETAIL_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles CustomerGroupingCLIENT_DETAIL_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub All_Groups_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles All_Groups_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub All_Groups_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles All_Groups_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CustomerGroupingCLIENT_Gridview_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles CustomerGroupingCLIENT_Gridview.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingCLIENT_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "All Grouping Details for Client :" & view.GetFocusedRowCellValue("ClientNr").ToString & " - " & view.GetFocusedRowCellValue("ClientName").ToString
            CustomerGroupingCLIENT_DETAIL_Gridview.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingCLIENT_Gridview_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles CustomerGroupingCLIENT_Gridview.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingCLIENT_Gridview" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "All Grouping Details for Client :" & view.GetFocusedRowCellValue("ClientNr").ToString & " - " & view.GetFocusedRowCellValue("ClientName").ToString
            CustomerGroupingCLIENT_DETAIL_Gridview.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingCLIENT_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerGroupingCLIENT_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CustomerGroupingCLIENT_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles CustomerGroupingCLIENT_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CustomerGroupingINTER_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles CustomerGroupingINTER_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingINTER_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "Clients on Inter Group :" & view.GetFocusedRowCellValue("InterGroupID").ToString & " - " & view.GetFocusedRowCellValue("InterGroupName").ToString
            CustomerGroupingCLIENT_Gridview.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingINTER_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles CustomerGroupingINTER_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "CustomerGroupingINTER_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GridViewCaption = "Clients on Inter Group :" & view.GetFocusedRowCellValue("InterGroupID").ToString & " - " & view.GetFocusedRowCellValue("InterGroupName").ToString
            CustomerGroupingCLIENT_Gridview.ViewCaption = GridViewCaption
        End If
    End Sub

    Private Sub CustomerGroupingINTER_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerGroupingINTER_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub CustomerGroupingINTER_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerGroupingINTER_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ALL_MASTER_INTERGROUP_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ALL_MASTER_INTERGROUP_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ALL_MASTER_INTERGROUP_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ALL_MASTER_INTERGROUP_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SearchLookUpEdit1View.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles SearchLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

   

    Private Sub TreeList1_CustomDrawNodeButton(sender As Object, e As DevExpress.XtraTreeList.CustomDrawNodeButtonEventArgs) Handles TreeList1.CustomDrawNodeButton
        Dim rect As Rectangle = Rectangle.Inflate(e.Bounds, 0, -2)
        ' painting background
        Dim BackBrush As New LinearGradientBrush(rect, Color.Blue, Color.LightSkyBlue, _
          LinearGradientMode.ForwardDiagonal)
        e.Graphics.FillRectangle(BackBrush, rect)
        ' painting 3D borders
        ControlPaint.DrawBorder3D(e.Graphics, rect, Border3DStyle.RaisedOuter)

        ' determining the character to display
        Dim DisplayCharacter As String = "+"
        If e.Expanded Then DisplayCharacter = "-"
        ' formatting the output character
        Dim OutCharacterFormat As New StringFormat()
        OutCharacterFormat.Alignment = StringAlignment.Center
        OutCharacterFormat.LineAlignment = StringAlignment.Center

        ' painting the character
        Dim CharacterRect As New RectangleF(rect.X, rect.Y, rect.Width, _
          rect.Height)
        e.Graphics.DrawString(DisplayCharacter, New Font("Verdana", 10), _
          New SolidBrush(Color.White), CharacterRect, OutCharacterFormat)

        ' prohibiting default painting
        e.Handled = True

    End Sub

    Private Sub TreeList1_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles TreeList1.CustomDrawNodeCell
        'Backcolor filter cell
        If e.CellText = "" Then
            e.Appearance.BackColor = System.Drawing.Color.DimGray
            e.Appearance.BackColor2 = System.Drawing.Color.DimGray
        End If
    End Sub

    Private Sub TreeList1_GetSelectImage(sender As Object, e As DevExpress.XtraTreeList.GetSelectImageEventArgs) Handles TreeList1.GetSelectImage
        'If e.FocusedNode Then
        '    e.NodeImageIndex = 13
        '    'e.Node.StateImageIndex = 11
        'Else
        '    e.NodeImageIndex = 14
        '    'e.Node.StateImageIndex = 12
        'End If

    End Sub

    Private Sub TreeList1_GetStateImage(sender As Object, e As DevExpress.XtraTreeList.GetStateImageEventArgs) Handles TreeList1.GetStateImage
        'e.Node.StateImageIndex=11 
    End Sub

    Private fExtendedTreeMode As Boolean = False
    Private strExtendedTree As String = "Extend Tree"
    Private strCollapsedTree As String = "Collapse Tree"

    Private Sub TreeExpandCollapse_btn_Click(sender As Object, e As EventArgs) Handles TreeExpandCollapse_btn.Click
        If fExtendedTreeMode = False Then
            ExtendTree()
        ElseIf fExtendedTreeMode = True Then
            CollapseTree()
        End If
    End Sub

    Private Sub ExtendTree()
        Me.TreeExpandCollapse_btn.ImageOptions.ImageIndex = 16
        Me.TreeExpandCollapse_btn.Text = strCollapsedTree
        fExtendedTreeMode = True
        Me.TreeList1.ExpandAll()
    End Sub

    Private Sub CollapseTree()
        Me.TreeExpandCollapse_btn.ImageOptions.ImageIndex = 15
        Me.TreeExpandCollapse_btn.Text = strExtendedTree
        fExtendedTreeMode = False
        Me.TreeList1.CollapseAll()
    End Sub

    Private Sub ALL_MASTER_INTERGROUP_GridView_DoubleClick(sender As Object, e As EventArgs) Handles ALL_MASTER_INTERGROUP_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            GroupType = Nothing
            GROUP_ID = Nothing
            GroupType = view.GetFocusedRowCellValue("GroupType").ToString
            GROUP_ID = view.GetFocusedRowCellValue("GROUP_ID").ToString

            Me.ID_lbl.DataBindings.Clear()
            Me.GroupStatus_ImageComboBoxEdit.DataBindings.Clear()
            Me.GroupNr_TextEdit.DataBindings.Clear()
            Me.GroupNameShort_TextEdit.DataBindings.Clear()
            Me.GroupName_TextEdit.DataBindings.Clear()
            Me.InternOrganComboBoxEdit.DataBindings.Clear()
            Me.Strasse_TextEdit.DataBindings.Clear()
            Me.PLZ_Ort_TextEdit.DataBindings.Clear()
            Me.PLZ_Nr_TextEdit.DataBindings.Clear()
            Me.NUTS_3_Code_TextEdit.DataBindings.Clear()
            Me.LEI_Code_TextEdit.DataBindings.Clear()
            Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Clear()
            Me.National_Identifier_Type_Description_lbl.DataBindings.Clear()
            Me.NationalIdentifier_TextEdit.DataBindings.Clear()
            Me.LegalForm_SearchLookUpEdit.DataBindings.Clear()
            Me.LegalFormDescription_lbl.DataBindings.Clear()
            Me.LegalFormOther_TextEdit.DataBindings.Clear()
            Me.CountryOfRisk_TextEdit.DataBindings.Clear()
            Me.CountryOfResidence_TextEdit.DataBindings.Clear()
            Me.EU_Country_ImageComboBoxEdit.DataBindings.Clear()
            Me.IndustrialClassLocal_TextEdit5.DataBindings.Clear()
            Me.IndClassLocalDescription_lbl.DataBindings.Clear()
            Me.SectorBISTA_TextEdit.DataBindings.Clear()
            Me.SectorBISTA_Description_lbl.DataBindings.Clear()
            Me.SectorCRR_TextEdit.DataBindings.Clear()
            Me.SectorCRR_Description_lbl.DataBindings.Clear()
            Me.SectorKWG_TextEdit.DataBindings.Clear()
            Me.SectorKWG_Description_lbl.DataBindings.Clear()
            Me.SectorFINREP_TextEdit.DataBindings.Clear()
            Me.SectorFINREP_Description_lbl.DataBindings.Clear()
            Me.NACE_Branch_TextEdit.DataBindings.Clear()
            Me.NACE_Branch_Description_lbl.DataBindings.Clear()



            If GroupType = "MASTERGROUP" Then

                Me.GROUP_MASTER_ALLTableAdapter.FillByGroupID(Me.CustomerGroups.GROUP_MASTER_ALL, GROUP_ID)

                Me.ID_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ID")
                Me.GroupStatus_ImageComboBoxEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupStatus")
                Me.GroupNr_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupMasterID")
                Me.GroupNameShort_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupMasterNameShort")
                Me.GroupName_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientName")
                Me.InternOrganComboBoxEdit.DataBindings.Add("EditValue", GROUP_MASTER_ALLBindingSource, "Int_Organ")
                Me.Strasse_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientStrasse")
                Me.PLZ_Ort_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientPLZ_Ort")
                Me.PLZ_Nr_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientPLZ_Nr")
                Me.NUTS_3_Code_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NUTS_3_Region")
                Me.LEI_Code_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "LEI_CODE")
                Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type")
                Me.National_Identifier_Type_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type_Description")
                Me.NationalIdentifier_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type_Value")
                Me.LegalForm_SearchLookUpEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form")
                Me.LegalFormDescription_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form_Description")
                Me.LegalFormOther_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form_Other")
                Me.CountryOfRisk_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientCountryRisk")
                Me.CountryOfResidence_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientCountryResidence")
                Me.EU_Country_ImageComboBoxEdit.DataBindings.Add("EditValue", GROUP_MASTER_ALLBindingSource, "EU_COUNTRY")
                Me.IndustrialClassLocal_TextEdit5.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientBranch")
                Me.IndClassLocalDescription_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientBranchName")
                Me.SectorBISTA_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_BISTA")
                Me.SectorBISTA_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_BISTA_Description")
                Me.SectorCRR_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_CRR")
                Me.SectorCRR_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_CRR_Description")
                Me.SectorKWG_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "SectorKWG")
                Me.SectorKWG_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "SectorKWG_Description")
                Me.SectorFINREP_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_FINREP")
                Me.SectorFINREP_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_FINREP_Description")
                Me.NACE_Branch_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NACE_Branch_Code")
                Me.NACE_Branch_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NACE_Branch_Code_Description")


                Me.LayoutControl1.Visible = False
                Me.GroupType_TextEdit.Text = GroupType
            End If

            If GroupType = "INTERGROUP" Then

                Me.GROUP_INTER_ALLTableAdapter.FillByGroupID(Me.CustomerGroups.GROUP_INTER_ALL, GROUP_ID)

                Me.ID_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ID")
                Me.GroupStatus_ImageComboBoxEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "GroupStatus")
                Me.GroupNr_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "InterGroupID")
                Me.GroupNameShort_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "InterGroupNameShort")
                Me.GroupName_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientName")
                Me.InternOrganComboBoxEdit.DataBindings.Add("EditValue", GROUP_INTER_ALLBindingSource, "Int_Organ")
                Me.Strasse_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientStrasse")
                Me.PLZ_Ort_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientPLZ_Ort")
                Me.PLZ_Nr_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientPLZ_Nr")
                Me.NUTS_3_Code_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NUTS_3_Region")
                Me.LEI_Code_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "LEI_CODE")
                Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type")
                Me.National_Identifier_Type_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type_Description")
                Me.NationalIdentifier_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type_Value")
                Me.LegalForm_SearchLookUpEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form")
                Me.LegalFormDescription_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form_Description")
                Me.LegalFormOther_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form_Other")
                Me.CountryOfRisk_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientCountryRisk")
                Me.CountryOfResidence_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientCountryResidence")
                Me.EU_Country_ImageComboBoxEdit.DataBindings.Add("EditValue", GROUP_INTER_ALLBindingSource, "EU_COUNTRY")
                Me.IndustrialClassLocal_TextEdit5.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientBranch")
                Me.IndClassLocalDescription_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientBranchName")
                Me.SectorBISTA_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_BISTA")
                Me.SectorBISTA_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_BISTA_Description")
                Me.SectorCRR_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_CRR")
                Me.SectorCRR_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_CRR_Description")
                Me.SectorKWG_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "SectorKWG")
                Me.SectorKWG_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "SectorKWG_Description")
                Me.SectorFINREP_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_FINREP")
                Me.SectorFINREP_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_FINREP_Description")
                Me.NACE_Branch_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NACE_Branch_Code")
                Me.NACE_Branch_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NACE_Branch_Code_Description")


                Me.LayoutControl1.Visible = False
                Me.GroupType_TextEdit.Text = GroupType
            End If

            NATIONAL_IDENTIFIERS_initData()
            NATIONAL_IDENTIFIERS_InitLookUp()
            LEGAL_CODES_initData()
            LEGAL_CODES_InitLookUp()
            ALL_GROUPS_initData()
            ALL_GROUPS_InitLookUp()
            Me.ClientSearch_GridLookUpEdit.Text = Me.GroupNr_TextEdit.Text
        End If
    End Sub

    Private Sub ClientSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.EditValueChanged
        If Me.ClientSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ClientSearch_GridLookUpEdit.Text) = True Then
            Me.GROUP_MASTER_ALLBindingSource.CancelEdit()
            Me.GROUP_INTER_ALLBindingSource.CancelEdit()
            GroupType = Nothing
            GROUP_ID = Nothing
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim CustomerGroupRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)


            GroupType = CustomerGroupRow("GroupType").ToString
            GROUP_ID = CustomerGroupRow("GROUP_ID").ToString
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for Group Nr.: " & GROUP_ID)

            Me.ID_lbl.DataBindings.Clear()
            Me.GroupStatus_ImageComboBoxEdit.DataBindings.Clear()
            Me.GroupNr_TextEdit.DataBindings.Clear()
            Me.GroupNameShort_TextEdit.DataBindings.Clear()
            Me.GroupName_TextEdit.DataBindings.Clear()
            Me.InternOrganComboBoxEdit.DataBindings.Clear()
            Me.Strasse_TextEdit.DataBindings.Clear()
            Me.PLZ_Ort_TextEdit.DataBindings.Clear()
            Me.PLZ_Nr_TextEdit.DataBindings.Clear()
            Me.NUTS_3_Code_TextEdit.DataBindings.Clear()
            Me.LEI_Code_TextEdit.DataBindings.Clear()
            Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Clear()
            Me.National_Identifier_Type_Description_lbl.DataBindings.Clear()
            Me.NationalIdentifier_TextEdit.DataBindings.Clear()
            Me.LegalForm_SearchLookUpEdit.DataBindings.Clear()
            Me.LegalFormDescription_lbl.DataBindings.Clear()
            Me.LegalFormOther_TextEdit.DataBindings.Clear()
            Me.CountryOfRisk_TextEdit.DataBindings.Clear()
            Me.CountryOfResidence_TextEdit.DataBindings.Clear()
            Me.EU_Country_ImageComboBoxEdit.DataBindings.Clear()
            Me.IndustrialClassLocal_TextEdit5.DataBindings.Clear()
            Me.IndClassLocalDescription_lbl.DataBindings.Clear()
            Me.SectorBISTA_TextEdit.DataBindings.Clear()
            Me.SectorBISTA_Description_lbl.DataBindings.Clear()
            Me.SectorCRR_TextEdit.DataBindings.Clear()
            Me.SectorCRR_Description_lbl.DataBindings.Clear()
            Me.SectorKWG_TextEdit.DataBindings.Clear()
            Me.SectorKWG_Description_lbl.DataBindings.Clear()
            Me.SectorFINREP_TextEdit.DataBindings.Clear()
            Me.SectorFINREP_Description_lbl.DataBindings.Clear()
            Me.NACE_Branch_TextEdit.DataBindings.Clear()
            Me.NACE_Branch_Description_lbl.DataBindings.Clear()



            If GroupType = "MASTERGROUP" Then

                Me.GROUP_MASTER_ALLTableAdapter.FillByGroupID(Me.CustomerGroups.GROUP_MASTER_ALL, GROUP_ID)

                Me.ID_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ID")
                Me.GroupStatus_ImageComboBoxEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupStatus")
                Me.GroupNr_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupMasterID")
                Me.GroupNameShort_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "GroupMasterNameShort")
                Me.GroupName_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientName")
                Me.InternOrganComboBoxEdit.DataBindings.Add("EditValue", GROUP_MASTER_ALLBindingSource, "Int_Organ")
                Me.Strasse_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientStrasse")
                Me.PLZ_Ort_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientPLZ_Ort")
                Me.PLZ_Nr_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientPLZ_Nr")
                Me.NUTS_3_Code_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NUTS_3_Region")
                Me.LEI_Code_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "LEI_CODE")
                Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type")
                Me.National_Identifier_Type_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type_Description")
                Me.NationalIdentifier_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "National_Identifier_Type_Value")
                Me.LegalForm_SearchLookUpEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form")
                Me.LegalFormDescription_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form_Description")
                Me.LegalFormOther_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Legal_Form_Other")
                Me.CountryOfRisk_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientCountryRisk")
                Me.CountryOfResidence_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientCountryResidence")
                Me.EU_Country_ImageComboBoxEdit.DataBindings.Add("EditValue", GROUP_MASTER_ALLBindingSource, "EU_COUNTRY")
                Me.IndustrialClassLocal_TextEdit5.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientBranch")
                Me.IndClassLocalDescription_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "ClientBranchName")
                Me.SectorBISTA_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_BISTA")
                Me.SectorBISTA_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_BISTA_Description")
                Me.SectorCRR_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_CRR")
                Me.SectorCRR_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_CRR_Description")
                Me.SectorKWG_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "SectorKWG")
                Me.SectorKWG_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "SectorKWG_Description")
                Me.SectorFINREP_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_FINREP")
                Me.SectorFINREP_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "Sector_FINREP_Description")
                Me.NACE_Branch_TextEdit.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NACE_Branch_Code")
                Me.NACE_Branch_Description_lbl.DataBindings.Add("Text", GROUP_MASTER_ALLBindingSource, "NACE_Branch_Code_Description")


                Me.LayoutControl1.Visible = False
                Me.GroupType_TextEdit.Text = GroupType
            End If

            If GroupType = "INTERGROUP" Then

                Me.GROUP_INTER_ALLTableAdapter.FillByGroupID(Me.CustomerGroups.GROUP_INTER_ALL, GROUP_ID)

                Me.ID_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ID")
                Me.GroupStatus_ImageComboBoxEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "GroupStatus")
                Me.GroupNr_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "InterGroupID")
                Me.GroupNameShort_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "InterGroupNameShort")
                Me.GroupName_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientName")
                Me.InternOrganComboBoxEdit.DataBindings.Add("EditValue", GROUP_INTER_ALLBindingSource, "Int_Organ")
                Me.Strasse_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientStrasse")
                Me.PLZ_Ort_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientPLZ_Ort")
                Me.PLZ_Nr_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientPLZ_Nr")
                Me.NUTS_3_Code_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NUTS_3_Region")
                Me.LEI_Code_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "LEI_CODE")
                Me.NationalIdentifiers_SearchLookUpEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type")
                Me.National_Identifier_Type_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type_Description")
                Me.NationalIdentifier_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "National_Identifier_Type_Value")
                Me.LegalForm_SearchLookUpEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form")
                Me.LegalFormDescription_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form_Description")
                Me.LegalFormOther_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Legal_Form_Other")
                Me.CountryOfRisk_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientCountryRisk")
                Me.CountryOfResidence_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientCountryResidence")
                Me.EU_Country_ImageComboBoxEdit.DataBindings.Add("EditValue", GROUP_INTER_ALLBindingSource, "EU_COUNTRY")
                Me.IndustrialClassLocal_TextEdit5.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientBranch")
                Me.IndClassLocalDescription_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "ClientBranchName")
                Me.SectorBISTA_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_BISTA")
                Me.SectorBISTA_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_BISTA_Description")
                Me.SectorCRR_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_CRR")
                Me.SectorCRR_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_CRR_Description")
                Me.SectorKWG_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "SectorKWG")
                Me.SectorKWG_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "SectorKWG_Description")
                Me.SectorFINREP_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_FINREP")
                Me.SectorFINREP_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "Sector_FINREP_Description")
                Me.NACE_Branch_TextEdit.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NACE_Branch_Code")
                Me.NACE_Branch_Description_lbl.DataBindings.Add("Text", GROUP_INTER_ALLBindingSource, "NACE_Branch_Code_Description")


                Me.LayoutControl1.Visible = False
                Me.GroupType_TextEdit.Text = GroupType
            End If

            NATIONAL_IDENTIFIERS_initData()
            NATIONAL_IDENTIFIERS_InitLookUp()
            LEGAL_CODES_initData()
            LEGAL_CODES_InitLookUp()
            Me.ClientSearch_GridLookUpEdit.Text = Me.GroupNr_TextEdit.Text
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                Me.NationalIdentifier_TextEdit.ReadOnly = False
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Me.GROUP_MASTER_ALLBindingSource.CancelEdit()
        Me.GROUP_INTER_ALLBindingSource.CancelEdit()
        LOAD_ALL_MASTER_INTERGROUP()
        Me.LayoutControl1.Visible = True
    End Sub

    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
        Try
            If GroupType = "MASTERGROUP" Then
                Me.GROUP_MASTER_ALLBindingSource.EndEdit()
                Me.GROUP_MASTER_ALLTableAdapter.Update(Me.CustomerGroups.GROUP_MASTER_ALL)
            End If
            If GroupType = "INTERGROUP" Then
                Me.GROUP_INTER_ALLBindingSource.EndEdit()
                Me.GROUP_INTER_ALLTableAdapter.Update(Me.CustomerGroups.GROUP_INTER_ALL)
            End If
            LOAD_ALL_MASTER_INTERGROUP()
            Me.LayoutControl1.Visible = True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

   
    
    Private Sub LayoutControl1_VisibleChanged(sender As Object, e As EventArgs) Handles LayoutControl1.VisibleChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                Me.NationalIdentifier_TextEdit.ReadOnly = False
            End If
        End If
    End Sub


End Class