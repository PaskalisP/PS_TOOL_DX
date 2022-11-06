Imports System
Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports Microsoft.VisualBasic
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports System.Drawing
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System.Web.Mail
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.Data
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Text.RegularExpressions

Public Class ExportCollection

    Dim conn As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim connSQL As New SqlConnection
    Dim cmdSQL As New SqlCommand

    Private QueryText As String = ""
    Private da As New OleDbDataAdapter
    Private dt As New DataTable
    Private da1 As New OleDbDataAdapter
    Private dt1 As New DataTable

    Private daSql As New SqlDataAdapter
    Private dtSql As New DataTable

    Dim CrystalRepDir As String = ""
    Dim OUR_REFERENCE As String = Nothing
    Dim OurReferenceSearch As String = Nothing
    Dim RelatedCustomerID As String = Nothing

    Dim CHARGES_CALCULATED As Double = 0
    Dim DISCONT_CALCULATED As Double = 0
    Dim NET_AMOUNT_CUSTOMER As Double = 0

    Private BS_SettlementType As BindingSource
    Private BS_AllCollections As BindingSource
    Dim LAST_LC_REST_AMOUNT As Double = 0
    Dim ID_COLLECTION As Integer = 0

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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ExportCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        conn.ConnectionString = My.Settings.PSTOOLConnectionString_OLEDB
        cmd.Connection = conn

        connSQL.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdSQL.Connection = connSQL

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        Me.OWN_CURRENCIESTableAdapter.Fill(Me.PSTOOLDataset.OWN_CURRENCIES)
        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
        ALL_COLLECTIONS_initData()
        ALL_COLLECTIONS_InitLookUp()

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick
        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl6.EmbeddedNavigator.ButtonClick, AddressOf GridControl6_EmbeddedNavigator_ButtonClick





    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Tag = "DeleteAmount" Then
            If AmountsCheck_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Amount be deleted? ", "DELETE AMOUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Amount...")
                        Me.AmountsCheck_GridView.DeleteRow(AmountsCheck_GridView.FocusedRowHandle)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If

        If e.Button.Tag = "PrintOrExport" Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub GridControl3_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)

        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.ApplicantAddresses_GridView.ShowEditForm))
        End If


        If e.Button.Tag = "DeleteAddress" Then
            If ApplicantAddresses_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Address be deleted? ", "DELETE ADDRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Address...")
                        Me.ApplicantAddresses_GridView.DeleteRow(ApplicantAddresses_GridView.FocusedRowHandle)
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If
    End Sub



    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.SettlementCharges_GridView.ShowEditForm))
        End If


        If e.Button.Tag = "DeleteCharges" Then
            If ApplicantAddresses_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Charges be deleted? ", "DELETE CHARGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Charges...")
                        Me.SettlementCharges_GridView.DeleteRow(SettlementCharges_GridView.FocusedRowHandle)
                        Me.EXPORT_COLLECTIONS_ChargesTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_Charges)
                        Me.EXPORT_COLLECTIONS_ChargesTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_Charges, ID_COLLECTION)
                        Me.SaveChanges_btn.PerformClick()
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If

        If e.Button.Tag = "CalculateCharges" Then
            If ApplicantAddresses_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the Charges  be calculated automatically?" & vbNewLine & "Attention:After automatic calculation is started all present charges for this collection settlement will be deleted!", "CALCULATE CHARGES AUTOMATICALLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Calculate Charges...")
                        If cmdSQL.Connection.State = ConnectionState.Closed Then
                            cmdSQL.Connection.Open()
                        End If
                        cmdSQL.CommandText = "DECLARE @COLLECTION_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                                                   DECLARE @CUSTOMER_ID int=" & CInt(RelatedCustomerID) & "
                                                   DECLARE @COLLECTION_ID int=" & CInt(ID_COLLECTION) & "
                                                   DECLARE @COLLECTION_AMOUNT float=(Select [InvoiceAmount] from [EXPORT_COLLECTIONS] where [OurReference]='" & OurReferenceSearch & "')
                                                   DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))

                                                   DELETE FROM  [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=@COLLECTION_ID

                                             INSERT INTO [EXPORT_COLLECTIONS_Charges]
                                                   ([ConditionName]
                                                   ,[ConditionCyclus]
                                                   ,[ConditionType]
                                                   ,[ConditionPercent]
                                                   ,[ConditionMin]
                                                   ,[ConditionMax]
                                                   ,[Notes]
                                                   ,[IdOurReference])
                                             SELECT 
                                                 [ConditionName]
                                                ,[ConditionCyclus]
                                                ,[ConditionType]
                                                ,[ConditionPercent]
                                                ,[ConditionMin]
                                                ,[ConditionMax]
                                                ,[Notes]
                                                ,@COLLECTION_ID
                                            FROM [EXPORT_LC_CUSTOMERS_CollectionConditions] where [IdExportLcCustomers]=@CUSTOMER_ID"
                        cmdSQL.ExecuteNonQuery()
                        'Calculate charges
                        cmdSQL.CommandText = "DECLARE @COLLECTION_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                                                   DECLARE @CUSTOMER_ID int=" & CInt(RelatedCustomerID) & "
                                                   DECLARE @COLLECTION_ID int=" & CInt(ID_COLLECTION) & "
                                                   DECLARE @COLLECTION_AMOUNT float=(Select [InvoiceAmount] from [EXPORT_COLLECTIONS] where [OurReference]='" & OurReferenceSearch & "')
                                                   DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))


                                                    UPDATE [EXPORT_COLLECTIONS_Charges] SET [ChargesOrigAmount]=ROUND([ConditionPercent]*@COLLECTION_AMOUNT,2) where [IdOurReference]=@COLLECTION_ID

                                                    UPDATE [EXPORT_COLLECTIONS_Charges] SET [ChargesOrigAmount]=Case when [ChargesOrigAmount]<[ConditionMin] then [ConditionMin] 
                                                    when [ChargesOrigAmount]>[ConditionMax] then [ConditionMax] else [ChargesOrigAmount] end
                                                    where [IdOurReference]=@COLLECTION_ID

                                                   UPDATE [EXPORT_COLLECTIONS_Charges] SET [ChargesOrigAmount]=0 where [ChargesOrigAmount] is NULL and [IdOurReference]=@COLLECTION_ID
        "
                        cmdSQL.ExecuteNonQuery()

                        If cmdSQL.Connection.State = ConnectionState.Open Then
                            cmdSQL.Connection.Close()
                        End If
                        NET_AMOUNT_CUSTOMER_CALCULATE()
                        Me.SaveChanges_btn.PerformClick()

                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If

    End Sub

    Private Sub GridControl6_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim navigator As ControlNavigator = TryCast(sender, ControlNavigator)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(navigator.NavigatableControl, DevExpress.XtraGrid.GridControl)
        Dim view As GridView = TryCast(grid.FocusedView, GridView)
        If e.Button.ButtonType = NavigatorButtonType.Append Then
            grid.BeginInvoke(New Action(AddressOf Me.Documents_GridView.ShowEditForm))
        End If

        If e.Button.Tag = "DeleteDocument" Then
            If ApplicantAddresses_GridView.RowCount > 0 Then
                If MessageBox.Show("Should the selected Document be deleted? ", "DELETE DOCUMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Delete Document...")
                        Me.Documents_GridView.DeleteRow(Documents_GridView.FocusedRowHandle)
                        Me.EXPORT_COLLECTIONS_DocumentsTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_Documents)
                        Me.EXPORT_COLLECTIONS_DocumentsTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_Documents, ID_COLLECTION)
                        Me.SaveChanges_btn.PerformClick()
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            End If
        End If


    End Sub

    Private Sub SETTLEMENT_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT  * FROM [EXPORT_LC_CUSTOMERS_BankDetails] where [IdExportLcCustomers]='" & RelatedCustomerID & "' and [Status] in ('Y')", connSQL)
        objCMD1.CommandTimeout = 5000
        Dim dbSettlementTypes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbSettlementTypes.Fill(ds, "EXPORT_LC_CUSTOMERS_BankDetails")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SettlementType = New BindingSource(ds, "EXPORT_LC_CUSTOMERS_BankDetails")
    End Sub

    Private Sub SETTLEMENT_TYPES_InitLookUp()

        Me.SettlementType_SearchLookUpEdit.Properties.DataSource = BS_SettlementType
        Me.SettlementType_SearchLookUpEdit.Properties.DisplayMember = "AccountConnection"
        Me.SettlementType_SearchLookUpEdit.Properties.ValueMember = "AccountConnection"


    End Sub

    Private Sub SETTLEMENT_TYPES_InitLookUp_Focus()

        Me.SettlementType_SearchLookUpEdit.Properties.DataSource = BS_SettlementType
        Me.SettlementType_SearchLookUpEdit.Properties.DisplayMember = "AccountConnection"
        Me.SettlementType_SearchLookUpEdit.Properties.ValueMember = "ID"


    End Sub

    Private Sub ALL_COLLECTIONS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT  A.ID,[LfdNr] ,[OurReference] ,[CustomerName],[InvoiceCCY] ,[InvoiceAmount],B.Name as 'Drawee',C.Name as 'BankDrawee',[MaturityDate],[Done],[DoneOn] FROM [EXPORT_COLLECTIONS] A FULL OUTER JOIN [EXPORT_COLLECTIONS_DraweeNameAddress] B on A.ID=B.Id_OurReference and B.NameType in ('A') FULL OUTER JOIN [EXPORT_COLLECTIONS_DraweeNameAddress] C on A.ID=C.Id_OurReference and C.NameType in ('B') where [LfdNr]  is not NULL ORDER BY [LfdNr] desc", connSQL)
        objCMD1.CommandTimeout = 5000
        Dim dbAllCollections As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbAllCollections.Fill(ds, "EXPORT_COLLECTIONS_ALL") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_AllCollections = New BindingSource(ds, "EXPORT_COLLECTIONS_ALL") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub ALL_COLLECTIONS_InitLookUp()

        Me.OurReferenceSearch_GridLookUpEdit.Properties.DataSource = BS_AllCollections
        Me.OurReferenceSearch_GridLookUpEdit.Properties.DisplayMember = "OurReference"
        Me.OurReferenceSearch_GridLookUpEdit.Properties.ValueMember = "OurReference"


    End Sub

    Private Sub SAVE_ALL_CHANGES()

        VALIDATIONS_SETTLEMENT_ADD()

        If Me.DxValidationProvider1.Validate() = True Then
            Me.Validate()
            OurReferenceSearch = Me.OurReference_TextEdit.Text
            NET_AMOUNT_CUSTOMER_CALCULATE()
            Try
                If LC_BASIC_DATAXtraTabPage.Text = "New Export Collection" Then
                    'Get Related Customer ID
                    Me.QueryText = "Select [OurReference] from [EXPORT_COLLECTIONS] where [OurReference]='" & OurReferenceSearch & "'"
                    daSql = New SqlDataAdapter(Me.QueryText.Trim(), connSQL)
                    dtSql = New System.Data.DataTable()
                    daSql.Fill(dtSql)
                    If dtSql.Rows.Count = 0 Then
                        Me.EXPORT_COLLECTIONSBindingSource.EndEdit()
                        Me.EXPORT_COLLECTIONS_ChargesBindingSource.EndEdit()
                        Me.EXPORT_COLLECTIONS_DocumentsBindingSource.EndEdit()
                        Me.EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.EndEdit()
                        Me.EXPORT_COLLECTIONS_AmountsCheckBindingSource.EndEdit()
                        Me.EXPORT_COLLECTIONSTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS)
                        Me.TableAdapterManager.UpdateAll(Me.LcDataset)
                        Me.TableAdapterManager1.UpdateAll(Me.CollectionDataSet)
                        FILL_ALL_DATA_BY_OUR_REFERENCE()
                        ALL_COLLECTIONS_initData()
                        ALL_COLLECTIONS_InitLookUp()
                        Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
                        Me.DoneDateEdit.Visible = True
                        Me.DoneStatus_CheckEdit.Visible = True
                        Me.GridControl3.Visible = True
                        Me.GridControl1.Visible = True
                        Me.GridControl6.Visible = True
                        Me.GridControl2.Visible = True
                        Me.GroupControl12.Visible = True
                        Me.GroupControl13.Visible = True
                        Me.OurReference_TextEdit.ReadOnly = True
                        Me.LC_BASIC_DATAXtraTabPage.Text = "EXPORT COLLECTION SETTLEMENT"
                    ElseIf dtSql.Rows.Count > 0 Then
                        MessageBox.Show("Unable to add new Export Collection with the same reference!" & vbNewLine & "Collection Reference: " & OurReferenceSearch & " exists in the Collections Table!" & vbNewLine & vbNewLine & "Please enter another Reference!", "DUPLICATE REFERENCE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End If

                Else
                    Me.Validate()
                    Me.EXPORT_COLLECTIONSBindingSource.EndEdit()
                    Me.EXPORT_COLLECTIONS_ChargesBindingSource.EndEdit()
                    Me.EXPORT_COLLECTIONS_DocumentsBindingSource.EndEdit()
                    Me.EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.EndEdit()
                    Me.EXPORT_COLLECTIONS_AmountsCheckBindingSource.EndEdit()
                    Me.EXPORT_COLLECTIONSTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS)
                    Me.TableAdapterManager.UpdateAll(Me.LcDataset)
                    Me.TableAdapterManager1.UpdateAll(Me.CollectionDataSet)
                    FILL_ALL_DATA_BY_OUR_REFERENCE()
                    Me.DoneDateEdit.Visible = True
                    Me.DoneStatus_CheckEdit.Visible = True
                    Me.GridControl3.Visible = True
                    Me.GridControl1.Visible = True
                    Me.GridControl6.Visible = True
                    Me.GridControl2.Visible = True
                    Me.GroupControl12.Visible = True
                    Me.GroupControl13.Visible = True
                    Me.OurReference_TextEdit.ReadOnly = True

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End Try
            NET_AMOUNT_CUSTOMER_CALCULATE()
        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If


    End Sub

    Private Sub VALIDATIONS_REMOVE()
        DxValidationProvider1.SetValidationRule(Me.OurReference_TextEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.CollectionDate_DateEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.SettlementType_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.AdviceToCustomer_GridLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.InvoiceCCY_GridLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.InvoiceAmount_SpinEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.CustomerLetterDate_DateEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.CustomerLetterReference_TextEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.CustomerContactName_TextEdit, Nothing)
    End Sub

    Private Sub VALIDATIONS_SETTLEMENT_ADD()
        'Set no empty Validation rule
        Dim notEmptyValidationRule As New ConditionValidationRule()
        notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
        notEmptyValidationRule.ErrorText = "Field is mandatory!"
        notEmptyValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
        'Set higher then Zero Validation Rule
        Dim higherZeroValidationRule As New ConditionValidationRule()
        higherZeroValidationRule.ConditionOperator = ConditionOperator.Greater
        higherZeroValidationRule.Value1 = 0
        higherZeroValidationRule.ErrorText = "Field is mandatory!" & vbNewLine & "Must be higher than zero!"
        higherZeroValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
        'Set Validations to controls
        DxValidationProvider1.SetValidationRule(Me.OurReference_TextEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.CollectionDate_DateEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.SettlementType_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.AdviceToCustomer_GridLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.InvoiceCCY_GridLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.InvoiceAmount_SpinEdit, higherZeroValidationRule)
        DxValidationProvider1.SetValidationRule(Me.CustomerLetterDate_DateEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.CustomerLetterReference_TextEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.CustomerContactName_TextEdit, notEmptyValidationRule)
    End Sub

    Private Sub DONE_STATUS_CHECK()
        If Me.DoneStatus_CheckEdit.CheckState = CheckState.Checked Then
            Me.OurReference_TextEdit.ReadOnly = True
            Me.OurReferenceNISS_TextEdit.ReadOnly = True
            Me.CollectionDate_DateEdit.ReadOnly = True
            Me.AdviceToCustomer_GridLookUpEdit.ReadOnly = True
            Me.SettlementType_SearchLookUpEdit.ReadOnly = True
            Me.InvoiceCCY_GridLookUpEdit.ReadOnly = True
            Me.InvoiceAmount_SpinEdit.ReadOnly = True
            Me.CustomerLetterDate_DateEdit.ReadOnly = True
            Me.CustomerLetterReference_TextEdit.ReadOnly = True
            Me.CustomerContactName_TextEdit.ReadOnly = True
            Me.GroupControl12.Enabled = False
            Me.GroupControl13.Enabled = False
            Me.ApplicantAddresses_GridView.OptionsBehavior.Editable = False
            Me.ApplicantAddresses_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl3.UseEmbeddedNavigator = False
            Me.SettlementCharges_GridView.OptionsBehavior.Editable = False
            Me.SettlementCharges_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl1.UseEmbeddedNavigator = False
            Me.Documents_GridView.OptionsBehavior.Editable = False
            Me.Documents_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl6.UseEmbeddedNavigator = False
            Me.AmountsCheck_GridView.OptionsBehavior.Editable = False
            Me.AmountsCheck_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl2.UseEmbeddedNavigator = False
        End If
        If Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.OurReference_TextEdit.ReadOnly = True
            Me.OurReferenceNISS_TextEdit.ReadOnly = True
            Me.CollectionDate_DateEdit.ReadOnly = False
            Me.AdviceToCustomer_GridLookUpEdit.ReadOnly = False
            Me.SettlementType_SearchLookUpEdit.ReadOnly = False
            Me.InvoiceCCY_GridLookUpEdit.ReadOnly = False
            Me.InvoiceAmount_SpinEdit.ReadOnly = False
            Me.CustomerLetterDate_DateEdit.ReadOnly = False
            Me.CustomerLetterReference_TextEdit.ReadOnly = False
            Me.CustomerContactName_TextEdit.ReadOnly = False
            Me.GroupControl12.Enabled = True
            Me.GroupControl13.Enabled = True
            Me.ApplicantAddresses_GridView.OptionsBehavior.Editable = True
            Me.ApplicantAddresses_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl3.UseEmbeddedNavigator = True
            Me.SettlementCharges_GridView.OptionsBehavior.Editable = True
            Me.SettlementCharges_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl1.UseEmbeddedNavigator = True
            Me.Documents_GridView.OptionsBehavior.Editable = True
            Me.Documents_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl6.UseEmbeddedNavigator = True
            Me.AmountsCheck_GridView.OptionsBehavior.Editable = True
            Me.AmountsCheck_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl2.UseEmbeddedNavigator = True
        End If
    End Sub


#Region "OUR REFERENCE SEARCH"

    Private Sub OurReferenceSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.EditValueChanged
        If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" AndAlso Me.OurReferenceSearch_GridLookUpEdit.Text.ToString.StartsWith("DEFF") = True Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim Collection_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            ID_COLLECTION = CInt(Collection_Row("ID").ToString)
            OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Loading Export Collection Ref.: " & OurReferenceSearch)
            'Get Related Customer ID
            Me.QueryText = "Select [RelatedCustomerID] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
            daSql = New SqlDataAdapter(Me.QueryText.Trim(), connSQL)
            dtSql = New System.Data.DataTable()
            daSql.Fill(dtSql)
            RelatedCustomerID = dtSql.Rows.Item(0).Item("RelatedCustomerID")

            Me.EXPORT_COLLECTIONSBindingSource.CancelEdit()
            Me.EXPORT_COLLECTIONS_ChargesBindingSource.CancelEdit()
            Me.EXPORT_COLLECTIONS_DocumentsBindingSource.CancelEdit()
            Me.EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.CancelEdit()
            Me.EXPORT_COLLECTIONS_AmountsCheckBindingSource.CancelEdit()



            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = True
            LC_LIST_XtraTabPage.PageVisible = False
            Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
            Me.XtraTabControl2.Focus()
            FILL_ALL_DATA_BY_OUR_REFERENCE()
            FILL_ALL_DATA_BY_OUR_REFERENCE()
            Me.DoneDateEdit.Visible = True
            Me.DoneStatus_CheckEdit.Visible = True
            Me.GridControl3.Visible = True
            Me.GridControl1.Visible = True
            Me.GridControl6.Visible = True
            Me.GroupControl12.Visible = True
            Me.GroupControl13.Visible = True
            Me.GridControl2.Visible = True
            Me.OurReference_TextEdit.ReadOnly = True
            Me.LC_BASIC_DATAXtraTabPage.Text = "EXPORT COLLECTION SETTLEMENT"
            VALIDATIONS_REMOVE()
            DONE_STATUS_CHECK()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
    Private Sub OurReferenceSearch_GridLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles OurReferenceSearch_GridLookUpEdit.ButtonClick
        If e.Button.Caption = "Search" Then
            If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" Then
                Me.EXPORT_COLLECTIONSBindingSource.CancelEdit()
                Me.EXPORT_COLLECTIONS_ChargesBindingSource.CancelEdit()
                Me.EXPORT_COLLECTIONS_DocumentsBindingSource.CancelEdit()
                Me.EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.CancelEdit()
                Me.EXPORT_COLLECTIONS_AmountsCheckBindingSource.CancelEdit()

                OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Loading Export Collection Ref.: " & OurReferenceSearch)
                'Get Related Customer ID
                Me.QueryText = "Select [RelatedCustomerID] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
                daSql = New SqlDataAdapter(Me.QueryText.Trim(), connSQL)
                dtSql = New System.Data.DataTable()
                daSql.Fill(dtSql)
                RelatedCustomerID = dtSql.Rows.Item(0).Item("RelatedCustomerID")

                Me.XtraTabControl2.Visible = True
                LC_BASIC_DATAXtraTabPage.PageVisible = True
                LC_LIST_XtraTabPage.PageVisible = False
                Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
                Me.XtraTabControl2.Focus()
                FILL_ALL_DATA_BY_OUR_REFERENCE()
                Me.DoneDateEdit.Visible = True
                Me.DoneStatus_CheckEdit.Visible = True
                Me.GridControl3.Visible = True
                Me.GridControl1.Visible = True
                Me.GridControl6.Visible = True
                Me.GroupControl12.Visible = True
                Me.GroupControl13.Visible = True
                Me.GridControl2.Visible = True
                Me.OurReference_TextEdit.ReadOnly = True
                Me.LC_BASIC_DATAXtraTabPage.Text = "EXPORT COLLECTION SETTLEMENT"
                VALIDATIONS_REMOVE()
                DONE_STATUS_CHECK()
                SplashScreenManager.CloseForm(False)
            End If
        End If
        If e.Button.Caption = "Add new Export Collection" Then
            EXPORT_COLLECTIONSBindingSource.CancelEdit()
            EXPORT_COLLECTIONS_ChargesBindingSource.CancelEdit()
            EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.CancelEdit()
            EXPORTLCMT700ApplNameAddressBindingSource.CancelEdit()
            EXPORT_COLLECTIONS_AmountsCheckBindingSource.CancelEdit()

            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = True
            LC_BASIC_DATAXtraTabPage.Text = "New Export Collection"
            EXPORT_COLLECTIONSBindingSource.AddNew()
            Me.DoneDateEdit.Visible = False
            Me.DoneStatus_CheckEdit.Visible = False
            Me.GridControl3.Visible = False
            Me.GridControl1.Visible = False
            Me.GridControl6.Visible = False
            Me.GridControl2.Visible = False
            Me.GroupControl12.Visible = False
            Me.GroupControl13.Visible = False
            LC_LIST_XtraTabPage.PageVisible = False
            '*************************************************************
            SETTLEMENT_TYPE_initData()
            SETTLEMENT_TYPES_InitLookUp()
            Me.CollectionDate_DateEdit.EditValue = Today
            Me.OurReference_TextEdit.ReadOnly = False
            Me.OurReference_TextEdit.Focus()
            '***********************************************************
        End If
        If e.Button.Caption = "Load Export Collection List" Then
            'Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            'Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = False
            '+++++++++++++++++++++++++++++++++++++++++++
            Me.ExportLC_List_GridControl.DataSource = Nothing
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading all Export Collections")
            Try
                Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using sqlCmd As New SqlCommand()
                        sqlCmd.CommandText = "SELECT  A.ID,[LfdNr] ,[OurReference] ,[CustomerName],[InvoiceCCY] ,[InvoiceAmount],B.Name as 'Drawee',C.Name as 'BankDrawee','MaturityDate'=Case when [MaturityDate] is not NULL then CONVERT(VARCHAR(10), [MaturityDate], 104) else 'at Sight' end ,[Done],[DoneOn] FROM [EXPORT_COLLECTIONS] A FULL OUTER JOIN [EXPORT_COLLECTIONS_DraweeNameAddress] B on A.ID=B.Id_OurReference and B.NameType in ('A') FULL OUTER JOIN [EXPORT_COLLECTIONS_DraweeNameAddress] C on A.ID=C.Id_OurReference and C.NameType in ('B') where [LfdNr]  is not NULL ORDER BY [LfdNr] desc"
                        sqlCmd.Connection = sqlConn
                        sqlConn.Open()
                        Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                        Dim objDataTable As New DataTable()
                        objDataTable.Load(objDataReader)
                        Me.ExportLC_List_GridControl.DataSource = Nothing
                        Me.ExportLC_List_GridControl.DataSource = objDataTable
                        Me.ExportLC_List_GridControl.ForceInitialize()
                        sqlConn.Close()
                    End Using
                End Using
            Catch
            End Try
            SplashScreenManager.CloseForm(False)
            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = False
            LC_LIST_XtraTabPage.PageVisible = True
        End If

    End Sub

    Private Sub OurReferenceSearch_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.Click
        Me.XtraTabControl2.Visible = False
        ALL_COLLECTIONS_initData()
        'ALL_COLLECTIONS_InitLookUp()
    End Sub

    Private Sub FILL_ALL_DATA_BY_OUR_REFERENCE()
        Try
            Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)
            Me.EXPORT_COLLECTIONSTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS, OurReferenceSearch)
            Me.EXPORT_COLLECTIONS_ChargesTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_Charges, ID_COLLECTION)
            Me.EXPORT_COLLECTIONS_DocumentsTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_Documents, ID_COLLECTION)
            Me.EXPORT_COLLECTIONS_DraweeNameAddressTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_DraweeNameAddress, ID_COLLECTION)
            Me.EXPORT_COLLECTIONS_AmountsCheckTableAdapter.FillByOurReference(Me.CollectionDataSet.EXPORT_COLLECTIONS_AmountsCheck, ID_COLLECTION)
            SETTLEMENT_TYPE_initData()
            SETTLEMENT_TYPES_InitLookUp()
            SETTLEMENT_TYPE_initData()
            SETTLEMENT_TYPES_InitLookUp()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Temporary Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub OurReferenceSearch_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub OurReferenceSearch_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
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

#End Region





#Region "ADVICE STATUS"
    Private Sub AdviceToCustomer_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.Click
        'Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)

    End Sub

    Private Sub AdviceToCustomer_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.EditValueChanged
        If Me.XtraTabControl2.Visible = True AndAlso AdviceToCustomer_GridLookUpEdit.Focused = True Then
            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim Customer_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.RelatedCustomerID_lbl.Text = Customer_Row("ID").ToString
            RelatedCustomerID = Customer_Row("ID").ToString
            Me.SettlementType_lbl.Text = ""
            Me.SettlementAccountCCY_lbl.Text = ""
            Me.SettlementAccountNr_lbl.Text = ""
            Me.SettlementBank_lbl.Text = ""
            Me.SettlementAccountCCY1_lbl.Text = Me.SettlementAccountCCY_lbl.Text
            Me.SettlementAccountNr1_lbl.Text = Me.SettlementAccountNr_lbl.Text
            Me.SettlementBank1_lbl.Text = Me.SettlementBank_lbl.Text
            SETTLEMENT_TYPE_initData()

        End If

    End Sub



#End Region

    Private Sub SettlementType_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SettlementType_SearchLookUpEdit.EditValueChanged
        If Me.XtraTabControl2.Visible = True Then

            If Me.OurReference_TextEdit.Text.StartsWith("DEFF") = True AndAlso Me.SettlementType_SearchLookUpEdit.Text <> "" Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim SettlementType_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)

                Me.SettlementType_lbl.Text = SettlementType_Row("AccountConnection").ToString
                Me.SettlementAccountCCY_lbl.Text = SettlementType_Row("IBAN_CCY").ToString
                Me.SettlementAccountNr_lbl.Text = SettlementType_Row("IBAN_NR").ToString
                Me.SettlementBank_lbl.Text = SettlementType_Row("BankName").ToString & " (BIC:" & SettlementType_Row("BIC").ToString & ")"
                Me.SettlementAccountCCY1_lbl.Text = Me.SettlementAccountCCY_lbl.Text
                Me.SettlementAccountNr1_lbl.Text = Me.SettlementAccountNr_lbl.Text
                Me.SettlementBank1_lbl.Text = Me.SettlementBank_lbl.Text
            ElseIf Me.SettlementType_SearchLookUpEdit.Text = "" Then
                Me.SettlementType_lbl.Text = ""
                Me.SettlementAccountCCY_lbl.Text = ""
                Me.SettlementAccountNr_lbl.Text = ""
                Me.SettlementBank_lbl.Text = ""
                Me.SettlementAccountCCY1_lbl.Text = Me.SettlementAccountCCY_lbl.Text
                Me.SettlementAccountNr1_lbl.Text = Me.SettlementAccountNr_lbl.Text
                Me.SettlementBank1_lbl.Text = Me.SettlementBank_lbl.Text

            End If
        End If


    End Sub



    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        SAVE_ALL_CHANGES()
        DONE_STATUS_CHECK()
    End Sub

    Private Sub DoneStatus_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles DoneStatus_CheckEdit.CheckedChanged
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
        If DoneStatus_CheckEdit.Focused = True Then
            If Me.DoneStatus_CheckEdit.CheckState = CheckState.Checked Then
                Dim d As Date = Today
                Me.DoneDateEdit.Text = d
                Me.EXPORT_COLLECTIONSBindingSource.EndEdit()
                Me.EXPORT_COLLECTIONSTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS)
                DONE_STATUS_CHECK()
            ElseIf Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
                Me.DoneDateEdit.Text = Nothing
                Me.EXPORT_COLLECTIONSBindingSource.EndEdit()
                Me.EXPORT_COLLECTIONSTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS)
                DONE_STATUS_CHECK()
            End If
        End If



        'SAVE_ALL_CHANGES()
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AdviceToCustomer_GridLookUpEditView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEditView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ApplicantData_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ApplicantData_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ApplicantData_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ApplicantData_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AllApplicants_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllApplicants_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllApplicants_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AllApplicants_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ExportLc_Settlements_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLc_Settlements_BaseView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Documents_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Documents_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Documents_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Documents_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ExportLC_List_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLC_List_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLC_List_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLC_List_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
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
        Dim reportfooter As String = "ALL EXPORT COLLECTIONS"
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
        Dim reportfooter As String = "ALL INVOICE AMOUNTS FOR EXPORT COLLECTION " & OurReferenceSearch
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub PrinOrExport_LC_List_btn_Click(sender As Object, e As EventArgs) Handles PrinOrExport_LC_List_btn.Click
        If Not ExportLC_List_GridControl.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub ApplicantAddresses_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ApplicantAddresses_GridView.RowUpdated
        SAVE_ALL_CHANGES()
        'Me.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements_ApplNameAddress, OurReferenceSearch)
    End Sub

    Private Sub ApplicantAddresses_GridView_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles ApplicantAddresses_GridView.RowDeleted
        SAVE_ALL_CHANGES()
        'Me.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements_ApplNameAddress, OurReferenceSearch)
    End Sub

    Private Sub AmountsCheck_GridView_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles AmountsCheck_GridView.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            Dim RowNr As Integer = e.RowHandle + 1
            e.Info.DisplayText = RowNr.ToString
        End If
    End Sub

    Private Sub AmountsCheck_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AmountsCheck_GridView.RowUpdated
        Me.EXPORT_COLLECTIONS_AmountsCheckTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_AmountsCheck)
    End Sub

    Private Sub AmountsCheck_GridView_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles AmountsCheck_GridView.RowDeleted
        Me.EXPORT_COLLECTIONS_AmountsCheckTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_AmountsCheck)
    End Sub

    Private Sub AmountsCheck_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AmountsCheck_GridView.CellValueChanged
        Me.EXPORT_COLLECTIONS_AmountsCheckTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_AmountsCheck)
    End Sub

    Private Sub ApplicantAddresses_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ApplicantAddresses_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim NAME_TYPE As GridColumn = View.Columns("NameType")
        Dim APPL_NAME As GridColumn = View.Columns("Name")
        Dim APPL_ADDRESS As GridColumn = View.Columns("Address")
        Dim APPL_ZIP_CITY As GridColumn = View.Columns("ZipCode_City")
        Dim APPL_COUNTRY_NAME As GridColumn = View.Columns("CountryName")

        Dim NameType As String = View.GetRowCellValue(e.RowHandle, colNameType).ToString
        Dim ApplName As String = View.GetRowCellValue(e.RowHandle, colName).ToString
        Dim ApplAddress As String = View.GetRowCellValue(e.RowHandle, colAddress).ToString
        Dim ApplZipCity As String = View.GetRowCellValue(e.RowHandle, colZipCode_City).ToString
        Dim ApplCountryName As String = View.GetRowCellValue(e.RowHandle, colCountryName).ToString

        If NameType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NAME_TYPE, "The Name Type must not be empty")
            e.ErrorText = "The Name Type must not be empty"
        End If
        If ApplName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_NAME, "The Name must not be empty")
            e.ErrorText = "The Name must not be empty"
        End If
        If ApplAddress = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ADDRESS, "The Address must not be empty")
            e.ErrorText = "The Address must not be empty"
        End If
        If ApplZipCity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ZIP_CITY, "The Postal Code/ City must not be empty")
            e.ErrorText = "The Postal Code/ City must not be empty"
        End If
        If ApplCountryName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_COUNTRY_NAME, "The Country Name must not be empty")
            e.ErrorText = "The Country Name must not be empty"
        End If

    End Sub

    Private Sub ApplicantData_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ApplicantData_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim NAME_TYPE As GridColumn = View.Columns("NameType")
        Dim APPL_NAME As GridColumn = View.Columns("Name")
        Dim APPL_ADDRESS As GridColumn = View.Columns("Address")
        Dim APPL_ZIP_CITY As GridColumn = View.Columns("ZipCode_City")
        Dim APPL_COUNTRY_NAME As GridColumn = View.Columns("CountryName")

        Dim NameType As String = View.GetRowCellValue(e.RowHandle, colNameType1).ToString
        Dim ApplName As String = View.GetRowCellValue(e.RowHandle, colName1).ToString
        Dim ApplAddress As String = View.GetRowCellValue(e.RowHandle, colAddress1).ToString
        Dim ApplZipCity As String = View.GetRowCellValue(e.RowHandle, colZipCode_City1).ToString
        Dim ApplCountryName As String = View.GetRowCellValue(e.RowHandle, colCountryName1).ToString

        If NameType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NAME_TYPE, "The Name Type must not be empty")
            e.ErrorText = "The Name Type must not be empty"
        End If
        If ApplName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_NAME, "The Name must not be empty")
            e.ErrorText = "The Name must not be empty"
        End If
        If ApplAddress = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ADDRESS, "The Address must not be empty")
            e.ErrorText = "The Address must not be empty"
        End If
        If ApplZipCity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ZIP_CITY, "The Postal Code/ City must not be empty")
            e.ErrorText = "The Postal Code/ City must not be empty"
        End If
        If ApplCountryName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_COUNTRY_NAME, "The Country Name must not be empty")
            e.ErrorText = "The Country Name must not be empty"
        End If
    End Sub


    Private Sub ApplicantRepositoryItemGridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ApplicantRepositoryItemGridLookUpEdit.EditValueChanged
        Dim editor As DevExpress.XtraEditors.GridLookUpEdit = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = (TryCast(sender, GridLookUpEdit)).EditValue
        If value <> Nothing Then
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("NameType"), EditRow("NameType").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("Address"), EditRow("Address").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("ZipCode_City"), EditRow("ZipCode_City").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("CountryName"), EditRow("CountryName").ToString)
        Else
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("Address"), "")
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("ZipCode_City"), "")
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("CountryName"), "")
        End If

    End Sub

    Private Sub ApplicantData_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ApplicantData_GridView.RowUpdated
        Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Update(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)

    End Sub

    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As Object = (TryCast(sender, SearchLookUpEdit)).EditValue
        If value <> Nothing Then
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("NameType"), EditRow("NameType").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("Address"), EditRow("Address").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("ZipCode_City"), EditRow("ZipCode_City").ToString)
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("CountryName"), EditRow("CountryName").ToString)
        Else
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("Address"), "")
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("ZipCode_City"), "")
            Me.ApplicantAddresses_GridView.SetRowCellValue(Me.ApplicantAddresses_GridView.FocusedRowHandle, Me.ApplicantAddresses_GridView.Columns("CountryName"), "")
        End If


    End Sub

    Private Sub AllApplicants_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles AllApplicants_GridView.RowUpdated
        Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Update(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)

    End Sub

    Private Sub AllApplicants_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AllApplicants_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim NAME_TYPE As GridColumn = View.Columns("NameType")
        Dim APPL_NAME As GridColumn = View.Columns("Name")
        Dim APPL_ADDRESS As GridColumn = View.Columns("Address")
        Dim APPL_ZIP_CITY As GridColumn = View.Columns("ZipCode_City")
        Dim APPL_COUNTRY_NAME As GridColumn = View.Columns("CountryName")

        Dim NameType As String = View.GetRowCellValue(e.RowHandle, colNameType1).ToString
        Dim ApplName As String = View.GetRowCellValue(e.RowHandle, colName1).ToString
        Dim ApplAddress As String = View.GetRowCellValue(e.RowHandle, colAddress1).ToString
        Dim ApplZipCity As String = View.GetRowCellValue(e.RowHandle, colZipCode_City1).ToString
        Dim ApplCountryName As String = View.GetRowCellValue(e.RowHandle, colCountryName1).ToString

        If NameType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NAME_TYPE, "The Name Type must not be empty")
            e.ErrorText = "The Name Type must not be empty"
        End If
        If ApplName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_NAME, "The Name must not be empty")
            e.ErrorText = "The Name must not be empty"
        End If
        If ApplAddress = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ADDRESS, "The Address must not be empty")
            e.ErrorText = "The Address must not be empty"
        End If
        If ApplZipCity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_ZIP_CITY, "The Postal Code/ City must not be empty")
            e.ErrorText = "The Postal Code/ City must not be empty"
        End If
        If ApplCountryName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(APPL_COUNTRY_NAME, "The Country Name must not be empty")
            e.ErrorText = "The Country Name must not be empty"
        End If
    End Sub





    Private Sub SettlementType_SearchLookUpEdit_GotFocus(sender As Object, e As EventArgs) Handles SettlementType_SearchLookUpEdit.GotFocus
        If Me.XtraTabControl2.Visible = True Then
            'SETTLEMENT_TYPE_initData()
            SETTLEMENT_TYPES_InitLookUp_Focus()
        End If

    End Sub



    Private Sub SettlementCharges_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Dim view As GridView = DirectCast(sender, GridView)

        If view.UpdateCurrentRow() Then
            Me.EXPORT_COLLECTIONS_ChargesBindingSource.EndEdit()
            Me.EXPORT_COLLECTIONS_ChargesTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_Charges)
        End If
        NET_AMOUNT_CUSTOMER_CALCULATE()
        Me.SaveChanges_btn.PerformClick()
    End Sub

    Private Sub SettlementCharges_GridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        NET_AMOUNT_CUSTOMER_CALCULATE()
        Me.SaveChanges_btn.PerformClick()
    End Sub

    Private Sub SettlementCharges_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs)
        Me.GridControl1.ForceInitialize()

        NET_AMOUNT_CUSTOMER_CALCULATE()
        Me.SaveChanges_btn.PerformClick()

    End Sub

    Private Sub Documents_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles Documents_GridView.RowUpdated
        NET_AMOUNT_CUSTOMER_CALCULATE()
        Me.SaveChanges_btn.PerformClick()
    End Sub

    Private Sub Documents_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Documents_GridView.CellValueChanged
        'Dim view As GridView = DirectCast(sender, GridView)

        'If view.UpdateCurrentRow() Then
        '    Me.EXPORT_COLLECTIONS_DocumentsBindingSource.EndEdit()
        '    Me.EXPORT_COLLECTIONS_DocumentsTableAdapter.Update(Me.CollectionDataSet.EXPORT_COLLECTIONS_Documents)
        'End If
        'NET_AMOUNT_CUSTOMER_CALCULATE()
        'Me.SaveChanges_btn.PerformClick()
    End Sub

    Private Sub Documents_GridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Documents_GridView.CellValueChanging
        'NET_AMOUNT_CUSTOMER_CALCULATE()
        'Me.SaveChanges_btn.PerformClick()
    End Sub

    Private Sub SettlementCharges_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs)
        Dim View As GridView = CType(sender, GridView)
        Dim CONDITION_NAME As GridColumn = View.Columns("ConditionName")
        Dim CHARGES_CCY As GridColumn = View.Columns("ChargesCCY")
        Dim CHARGES_AMOUNT As GridColumn = View.Columns("ChargesOrigAmount")

        Dim ConditionName As String = View.GetRowCellValue(e.RowHandle, colConditionName1).ToString
        Dim ChargesCCY As String = View.GetRowCellValue(e.RowHandle, colChargesCCY1).ToString
        'Dim ChargesAmount As Double = CDbl(View.GetRowCellValue(e.RowHandle, colChargesOrigAmount1).ToString)

        If ConditionName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONDITION_NAME, "The Condition Name must not be empty")
            e.ErrorText = "The Condition Name must not be empty"
        End If

        If ChargesCCY = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHARGES_CCY, "The Charges Currency must not be empty")
            e.ErrorText = "The Charges Currency must not be empty"
        End If

        'If ChargesAmount = 0 Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    View.SetColumnError(CHARGES_AMOUNT, "The Charges Amount must not be zero")
        '    e.ErrorText = "The Charges Amount must not be zero"
        'End If

    End Sub

    Private Sub SettlementCharges_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs)
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ChargesCCY"), "EUR")
        view.SetRowCellValue(e.RowHandle, view.Columns("ChargesOrigAmount"), 0)
    End Sub

    Private Sub AmountsCheck_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles AmountsCheck_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim INVOICE_AMOUNT As GridColumn = View.Columns("InvoiceAmount")

        Dim InvoiceAmount As Double = CDbl(View.GetRowCellValue(e.RowHandle, colInvoiceAmount1))

        If InvoiceAmount <= 0 Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(INVOICE_AMOUNT, "The Invoice Amount must be higher than Zero!")
            e.ErrorText = "The Invoice Amount must be higher than Zero!"
        End If
    End Sub

    Private Sub Documents_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Documents_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim DOCUMENT_NAME As GridColumn = View.Columns("DocumentName")
        Dim DOCUMENTS_COUNT As GridColumn = View.Columns("DocumentsCount")

        Dim DocumentName As String = View.GetRowCellValue(e.RowHandle, colDocumentName).ToString
        Dim DocumentsCount As String = View.GetRowCellValue(e.RowHandle, colDocumentsCount).ToString


        If DocumentName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DOCUMENT_NAME, "The Document Name must not be empty")
            e.ErrorText = "The Document Name must not be empty"
        End If

        If DocumentsCount = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DOCUMENTS_COUNT, "The Documents count must not be empty")
            e.ErrorText = "The Documents count must not be empty"
        End If


    End Sub

    Private Sub Documents_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles Documents_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("DocumentName"), Nothing)
        view.SetRowCellValue(e.RowHandle, view.Columns("DocumentsCount"), Nothing)
    End Sub

    Private Sub SettlementApplBank_RadioGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SettlementApplBank_RadioGroup.EditValueChanged
        If SettlementApplBank_RadioGroup.Focused = True Then
            Dim Edit As RadioGroup = CType(sender, RadioGroup)
            Dim InvoiceCCY As String = Me.InvoiceCCY_GridLookUpEdit.EditValue
            If InvoiceCCY IsNot Nothing Then
                If (Edit.SelectedIndex = 0) Then
                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "Please authorize us by MT202 to debit the account of CCB, Head Office, acc. no. 1500100007 with our Bank for the amount of " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB, Frankfurt Branch, SWIFT advise to CCB, H.O. quoting our Reference: " & OurReferenceSearch
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "Please authorize us by MT202 to debit the account of CCB, Head Office, acc. no. 1500100007 with our Bank for the amount of " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB, Frankfurt Branch, SWIFT advise to CCB, H.O. quoting our Reference: " & OurReferenceSearch
                        End If
                    End If

                ElseIf (Edit.SelectedIndex = 1) Then
                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "Please credit our Account Nr.: with  for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & OurReferenceSearch
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "Please credit our Account Nr.: with  for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & OurReferenceSearch
                        End If
                    End If

                ElseIf (Edit.SelectedIndex = 2) Then

                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "We have reimbursed ourselves on: " & vbNewLine & "for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & OurReferenceSearch
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "We have reimbursed ourselves on: " & vbNewLine & "for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & OurReferenceSearch
                        End If
                    End If
                ElseIf (Edit.SelectedIndex = 3) Then

                    If Me.SettlementApplBankText_TextEdit.Text = "" Then

                        Select Case InvoiceCCY
                            Case = "EUR"
                                Me.SettlementApplBankText_TextEdit.Text = "Please remit proceeds through your EURO clearing for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & OurReferenceSearch
                            Case <> "EUR"
                                cmdSQL.CommandText = "SELECT * from [SSIS] where [CURRENCY CODE]='" & InvoiceCCY & "' and [LcSettlement]=1"
                                Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
                                Dim dt As New DataTable
                                daSql.Fill(dt)
                                If dt.Rows.Count > 0 Then
                                    Me.SettlementApplBankText_TextEdit.Text = "Credit our Accounty by " & dt.Rows.Item(0).Item("CORRESPONDENT NAME") & " (BIC:" & dt.Rows.Item(0).Item("CORRESPONDENT BIC") & ") for " & InvoiceCCY & " " & Me.InvoiceAmount_SpinEdit.EditValue.ToString & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & OurReferenceSearch
                                End If
                        End Select
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Select Case InvoiceCCY
                                Case = "EUR"
                                    Me.SettlementApplBankText_TextEdit.Text = "Please remit proceeds through your EURO clearing for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & OurReferenceSearch
                                Case <> "EUR"
                                    cmdSQL.CommandText = "SELECT * from [SSIS] where [CURRENCY CODE]='" & InvoiceCCY & "' and [LcSettlement]=1"
                                    Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
                                    Dim dt As New DataTable
                                    daSql.Fill(dt)
                                    If dt.Rows.Count > 0 Then
                                        Me.SettlementApplBankText_TextEdit.Text = "Credit our Accounty by " & dt.Rows.Item(0).Item("CORRESPONDENT NAME") & " (BIC:" & dt.Rows.Item(0).Item("CORRESPONDENT BIC") & ") for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & OurReferenceSearch
                                    End If
                            End Select
                        End If
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub OurReference_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OurReference_TextEdit.EditValueChanged
        If LC_BASIC_DATAXtraTabPage.Text = "New Export Collection" Then
            Dim x As String = Me.OurReference_TextEdit.EditValue
            If Len(x) >= 5 Then
                Me.LfdNrLabel1.Text = Int64.Parse(Regex.Replace(x, "[^\d]", ""))
            End If
        End If

    End Sub

    Private Sub SettlementCancel_btn_Click(sender As Object, e As EventArgs) Handles SettlementCancel_btn.Click
        VALIDATIONS_REMOVE()
        EXPORT_COLLECTIONSBindingSource.CancelEdit()
        EXPORT_COLLECTIONS_ChargesBindingSource.CancelEdit()
        EXPORT_COLLECTIONS_DraweeNameAddressBindingSource.CancelEdit()
        EXPORTLCMT700ApplNameAddressBindingSource.CancelEdit()
        Me.OurReferenceSearch_GridLookUpEdit.Text = ""
        Me.XtraTabControl2.Visible = False
    End Sub




    Private Sub NET_AMOUNT_CUSTOMER_CALCULATE()
        Dim summaryValue = SettlementCharges_GridView.Columns("ChargesOrigAmount").SummaryItem.SummaryValue
        CHARGES_CALCULATED = summaryValue
        Dim INVOICE_AMOUNT As Double = Me.InvoiceAmount_SpinEdit.EditValue
        NET_AMOUNT_CUSTOMER = INVOICE_AMOUNT - CHARGES_CALCULATED
        Me.NetAmountForCustomer_SpinEdit.EditValue = NET_AMOUNT_CUSTOMER
    End Sub

    Private Sub CollectionBankFormCreation_btn_Click(sender As Object, e As EventArgs) Handles CollectionBankFormCreation_btn.Click
        Try
            Me.SaveChanges_btn.PerformClick()
            EXPORT_COLLECTION_BANK_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub CollectionCustomerFormCreation_btn_Click(sender As Object, e As EventArgs) Handles CollectionCustomerFormCreation_btn.Click
        Try
            Me.SaveChanges_btn.PerformClick()
            EXPORT_COLLECTION_CUSTOMER_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub PaymentAdvice_btn_Click(sender As Object, e As EventArgs) Handles PaymentAdvice_btn.Click
        If IsDate(Me.SettlementDate_DateEdit.EditValue) = True Then
            Me.SaveChanges_btn.PerformClick()
            EXPORT_COLLECTION_PAYMENT_ADVICE_CUSTOMER_DOCUMENT()
        Else
            MessageBox.Show("Settlement Date is empty!" & vbNewLine & "Please enter the Collections Settlement Date for the Customer!", "SETTLEMENT DATE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub EXPORT_COLLECTION_BANK_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the creation of Bank Collection Instruction")
            Dim EXPORT_COLLECTION_BANK_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "EXPORT_COLLECTION_BANK" Then
                    EXPORT_COLLECTION_BANK_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANK_NAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANK_STRASSE As String = Nothing
            Dim OUR_BANK_PLZ As String = Nothing
            Dim OUR_BANK_ORT As String = Nothing

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANK_NAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANK_STRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANK_PLZ = dt.Rows.Item(0).Item("PLZ Bank")
            OUR_BANK_ORT = dt.Rows.Item(0).Item("Ort Bank")

            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next



            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Drawer Parameters
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CustomerID = dt.Rows.Item(i).Item("CustomerID")
                    CustomerName = dt.Rows.Item(i).Item("CustomerName")
                    If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                        CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                    End If
                    If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                        CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                    End If
                    CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                    CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                    If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                        CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                    End If
                    If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                        CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                    End If
                    If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                        CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                        CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                        CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                    End If
                    If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                        CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Customer not fund in the Foreign Dept. Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Drawee Parameters
            Dim DraweeName As String = Nothing
            Dim DraweeAddress As String = Nothing
            Dim DraweeZipCodeCity As String = Nothing
            Dim DraweeCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('A') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeName = dt.Rows.Item(i).Item("Name")
                    DraweeAddress = dt.Rows.Item(i).Item("Address")
                    DraweeZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee details for this Export Collection!", "DRAWEE DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Drawee Bank Parameters
            Dim DraweeBankName As String = Nothing
            Dim DraweeBankAddress As String = Nothing
            Dim DraweeBankZipCodeCity As String = Nothing
            Dim DraweeBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('B') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeBankName = dt.Rows.Item(i).Item("Name")
                    DraweeBankAddress = dt.Rows.Item(i).Item("Address")
                    DraweeBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Bank Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee Bank details for this Export Collection!", "DRAWEE BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Dim CHARGES_NAMES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & " and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                    CHARGES_NAMES += dt.Rows.Item(i).Item("ConditionName") & ","
                Next
            End If


            SplashScreenManager.Default.SetWaitFormCaption("Create Collection Instruction to Drawee Bank")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Drawee Bank Collection Instruction"
            c.RichEditControl1.LoadDocument(EXPORT_COLLECTION_BANK_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            Dim OurBankStreetPos As DocumentPosition = myHeader.Bookmarks("OurBankStreet").Range.End
            myHeader.InsertText(OurBankStreetPos, OUR_BANK_STRASSE)
            Dim OurBankPLZPos As DocumentPosition = myHeader.Bookmarks("OurBankPLZ").Range.End
            myHeader.InsertText(OurBankPLZPos, OUR_BANK_PLZ)
            Dim OurBankCityPos As DocumentPosition = myHeader.Bookmarks("OurBankCity").Range.End
            myHeader.InsertText(OurBankCityPos, OUR_BANK_ORT)
            Dim OurBankBicPos As DocumentPosition = myHeader.Bookmarks("OurBankBic").Range.End
            myHeader.InsertText(OurBankBicPos, "BIC: " & OUR_BIC)
            myHeader.Fields.Update()
            firstSection.EndUpdateHeader(myHeader)

            'Documents Details
            Dim DocumentsDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DocumentsTable").Range.End
            Dim tbl As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(DocumentsDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl(0, 0).Range.Start, "Documents:")
            'c.RichEditControl1.Document.InsertText(tbl(0, 1).Range.Start, "Count")
            'c.RichEditControl1.Document.InsertText(tbl(0, 2).Range.Start, "Betrag")
            Try
                tbl.BeginUpdate()
                'Get Documents
                Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Documents] where [IdOurReference]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                        Dim cell As TableCell = row.FirstCell
                        Dim DocumentName As String = dt.Rows.Item(i).Item("DocumentName")
                        Dim DocumentsCount As String = dt.Rows.Item(i).Item("DocumentsCount")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, DocumentName)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, "  ")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, DocumentsCount)
                    Next
                End If

                ' table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Right
                    p.BackColor = Color.White
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = False
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                'All other rows
                For i As Integer = 0 To tbl.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next

                'Create Table Style
                Dim tStyleNormal As DevExpress.XtraRichEdit.API.Native.TableStyle = c.RichEditControl1.Document.TableStyles.CreateNew()
                tStyleNormal.LineSpacingType = ParagraphLineSpacing.Single
                'tStyleNormal.FontName = "Verdana"
                tStyleNormal.Alignment = ParagraphAlignment.Left
                Dim borders As TableBorders = tStyleNormal.TableBorders
                borders.Bottom.LineColor = Color.DarkBlue
                borders.Left.LineColor = Color.DarkBlue
                borders.Right.LineColor = Color.DarkBlue
                borders.Top.LineColor = Color.DarkBlue
                borders.InsideVerticalBorder.LineColor = Color.DarkBlue
                borders.InsideHorizontalBorder.LineColor = Color.DarkBlue
                tStyleNormal.CellBackgroundColor = Color.Transparent
                tStyleNormal.Name = "MyTableGridNormal"

                c.RichEditControl1.Document.TableStyles.Add(tStyleNormal)
                tbl.Style = c.RichEditControl1.Document.TableStyles("MyTableGridNormal")


            Finally
                tbl.EndUpdate()
            End Try

            Dim CollectionDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CollectionDate").Range.End
            c.RichEditControl1.Document.InsertText(CollectionDatePos, Me.CollectionDate_DateEdit.Text)

            Dim DraweeBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankNamePos, DraweeBankName)
            Dim DraweeBankStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankStreetPos, DraweeBankAddress)
            Dim DraweeBankZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankZipCityPos, DraweeBankZipCodeCity)
            Dim ApplicantBankCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankCountryPos, DraweeBankCountry)

            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, Me.CustomerContactName_TextEdit.Text)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerStreet").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerPLZ").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerCity").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            'Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            'c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, OurReferenceSearch)
            Dim MaturityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            If IsDate(Me.MaturityDate_DateEdit.Text) = True Then
                c.RichEditControl1.Document.InsertText(MaturityPos, Me.MaturityDate_DateEdit.Text)
            Else
                c.RichEditControl1.Document.InsertText(MaturityPos, "at sight")
            End If
            Dim AmountCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCCY").Range.End
            c.RichEditControl1.Document.InsertText(AmountCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim AmountCollectionPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCollection").Range.End
            c.RichEditControl1.Document.InsertText(AmountCollectionPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))

            Dim DraweeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeNamePos, DraweeName)
            Dim DraweeStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeStreetPos, DraweeAddress)
            Dim DraweeZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeZipCityPos, DraweeBankZipCodeCity)
            Dim DraweeCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeCountry").Range.End
            c.RichEditControl1.Document.InsertText(DraweeCountryPos, DraweeCountry)

            Dim PayInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PaymentInstructions").Range.End
            c.RichEditControl1.Document.InsertText(PayInstructionsPos, Me.SettlementApplBankText_TextEdit.Text)



            ''Confirmation
            'Dim Not_Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Not_Confirmed").Range.End
            'Dim Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Confirmed").Range.End
            'If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "X")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "")
            'Else
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "X")
            'End If
            SplashScreenManager.CloseForm(False)


            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
            '    & "Charges for Applicant   = 1" & vbNewLine _
            '    & "Charges for Beneficiary = 2" & vbNewLine _
            '    & "Charges Shared          = 0"

            'title = "ADVICE COMMISSION SHARING"   ' Set title.
            'defaultValue = "1"   ' Set default value.
            '' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            'Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            'Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            'If myValue = "1" Then
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            'ElseIf myValue = "2" Then
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            'ElseIf myValue = "0" Then
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            'Else
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            'End If


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub EXPORT_COLLECTION_CUSTOMER_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the creation of Customer Collection Document")
            Dim EXPORT_COLLECTION_CUSTOMER_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "EXPORT_COLLECTION_CUSTOMER" Then
                    EXPORT_COLLECTION_CUSTOMER_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANK_NAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANK_STRASSE As String = Nothing
            Dim OUR_BANK_PLZ As String = Nothing
            Dim OUR_BANK_ORT As String = Nothing

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANK_NAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANK_STRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANK_PLZ = dt.Rows.Item(0).Item("PLZ Bank")
            OUR_BANK_ORT = dt.Rows.Item(0).Item("Ort Bank")

            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next



            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Drawer Parameters
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CustomerID = dt.Rows.Item(i).Item("CustomerID")
                    CustomerName = dt.Rows.Item(i).Item("CustomerName")
                    If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                        CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                    End If
                    If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                        CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                    End If
                    CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                    CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                    If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                        CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                    End If
                    If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                        CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                    End If
                    If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                        CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                        CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                        CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                    End If
                    If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                        CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Customer not fund in the Foreign Dept. Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Drawee Parameters
            Dim DraweeName As String = Nothing
            Dim DraweeAddress As String = Nothing
            Dim DraweeZipCodeCity As String = Nothing
            Dim DraweeCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('A') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeName = dt.Rows.Item(i).Item("Name")
                    DraweeAddress = dt.Rows.Item(i).Item("Address")
                    DraweeZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee details for this Export Collection!", "DRAWEE DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Drawee Bank Parameters
            Dim DraweeBankName As String = Nothing
            Dim DraweeBankAddress As String = Nothing
            Dim DraweeBankZipCodeCity As String = Nothing
            Dim DraweeBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('B') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeBankName = dt.Rows.Item(i).Item("Name")
                    DraweeBankAddress = dt.Rows.Item(i).Item("Address")
                    DraweeBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Bank Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee Bank details for this Export Collection!", "DRAWEE BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Dim CHARGES_NAMES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & " and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                    CHARGES_NAMES += dt.Rows.Item(i).Item("ConditionName") & ","
                Next
            End If

            'Get Charges Sum
            Dim CHARGES_SUM As String = Nothing
            Me.QueryText = "Select 'SumCharges'=Case when Sum([ChargesOrigAmount]) is not NULL then Sum([ChargesOrigAmount]) else 0 end from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            CHARGES_SUM = FormatNumber(dt.Rows.Item(0).Item("SumCharges"), 2)

            SplashScreenManager.Default.SetWaitFormCaption("Create Collection Instruction to customer")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Customer Collection Document"
            c.RichEditControl1.LoadDocument(EXPORT_COLLECTION_CUSTOMER_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            Dim OurBankStreetPos As DocumentPosition = myHeader.Bookmarks("OurBankStreet").Range.End
            myHeader.InsertText(OurBankStreetPos, OUR_BANK_STRASSE)
            Dim OurBankPLZPos As DocumentPosition = myHeader.Bookmarks("OurBankPLZ").Range.End
            myHeader.InsertText(OurBankPLZPos, OUR_BANK_PLZ)
            Dim OurBankCityPos As DocumentPosition = myHeader.Bookmarks("OurBankCity").Range.End
            myHeader.InsertText(OurBankCityPos, OUR_BANK_ORT)
            Dim OurBankBicPos As DocumentPosition = myHeader.Bookmarks("OurBankBic").Range.End
            myHeader.InsertText(OurBankBicPos, "BIC: " & OUR_BIC)
            myHeader.Fields.Update()
            firstSection.EndUpdateHeader(myHeader)

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Charges Details
            Dim ChargesDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesTable").Range.End
            Dim tbl_chgs As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(ChargesDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 0).Range.Start, "Abrechnungsdetails")
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 1).Range.Start, "Währung")
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 2).Range.Start, "Betrag")
            Try
                tbl_chgs.BeginUpdate()
                'Get Invoice details
                Me.QueryText = "Select [InvoiceCCY],[InvoiceAmount] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Rechnungsbetrag:"
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("InvoiceAmount"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If

                'Get other Charges
                Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & " and [ChargesOrigAmount]<>0"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                        Dim cell As TableCell = row.FirstCell
                        Dim BetragName As String = "abzgl. " & dt.Rows.Item(i).Item("ConditionName")
                        Dim CCY As String = dt.Rows.Item(i).Item("ChargesCCY")
                        Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(i).Item("ChargesOrigAmount"))
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                    Next
                End If
                'Get Net Amount for Customer
                Me.QueryText = "Select [InvoiceCCY],[NettoAmountCustomer] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Nettoerlös."
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("NettoAmountCustomer"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If


                ' Center the table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl_chgs.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl_chgs.LastRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                For i As Integer = 0 To tbl_chgs.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(2).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next
            Finally
                tbl_chgs.EndUpdate()
            End Try


            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Documents Details
            Dim DocumentsDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DocumentsTable").Range.End
            Dim tbl As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(DocumentsDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl(0, 0).Range.Start, "Documents:")
            'c.RichEditControl1.Document.InsertText(tbl(0, 1).Range.Start, "Count")
            'c.RichEditControl1.Document.InsertText(tbl(0, 2).Range.Start, "Betrag")
            Try
                tbl.BeginUpdate()
                'Get Documents
                Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Documents] where [IdOurReference]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                        Dim cell As TableCell = row.FirstCell
                        Dim DocumentName As String = dt.Rows.Item(i).Item("DocumentName")
                        Dim DocumentsCount As String = dt.Rows.Item(i).Item("DocumentsCount")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, DocumentName)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, "  ")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, DocumentsCount)
                    Next
                End If

                ' table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Right
                    p.BackColor = Color.White
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = False
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                'All other rows
                For i As Integer = 0 To tbl.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next

                'Create Table Style
                Dim tStyleNormal As DevExpress.XtraRichEdit.API.Native.TableStyle = c.RichEditControl1.Document.TableStyles.CreateNew()
                tStyleNormal.LineSpacingType = ParagraphLineSpacing.Single
                'tStyleNormal.FontName = "Verdana"
                tStyleNormal.Alignment = ParagraphAlignment.Left
                Dim borders As TableBorders = tStyleNormal.TableBorders
                borders.Bottom.LineColor = Color.DarkBlue
                borders.Left.LineColor = Color.DarkBlue
                borders.Right.LineColor = Color.DarkBlue
                borders.Top.LineColor = Color.DarkBlue
                borders.InsideVerticalBorder.LineColor = Color.DarkBlue
                borders.InsideHorizontalBorder.LineColor = Color.DarkBlue
                tStyleNormal.CellBackgroundColor = Color.Transparent
                tStyleNormal.Name = "MyTableGridNormal"

                c.RichEditControl1.Document.TableStyles.Add(tStyleNormal)
                tbl.Style = c.RichEditControl1.Document.TableStyles("MyTableGridNormal")


            Finally
                tbl.EndUpdate()
            End Try

            Dim CollectionDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CollectionDate").Range.End
            c.RichEditControl1.Document.InsertText(CollectionDatePos, Me.CollectionDate_DateEdit.Text)

            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, Me.CustomerContactName_TextEdit.Text)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerStreet").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerPLZ").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerCity").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)

            Dim DraweeBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankNamePos, DraweeBankName)
            Dim DraweeBankStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankStreetPos, DraweeBankAddress)
            Dim DraweeBankZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankZipCityPos, DraweeBankZipCodeCity)
            Dim ApplicantBankCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankCountryPos, DraweeBankCountry)

            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)
            Dim CustomerLetterDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerLetterDate").Range.End
            c.RichEditControl1.Document.InsertText(CustomerLetterDatePos, Me.CustomerLetterDate_DateEdit.Text)
            Dim CustomerContactPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos1, Me.CustomerContactName_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, OurReferenceSearch)
            Dim MaturityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            If IsDate(Me.MaturityDate_DateEdit.Text) = True Then
                c.RichEditControl1.Document.InsertText(MaturityPos, Me.MaturityDate_DateEdit.Text)
            Else
                c.RichEditControl1.Document.InsertText(MaturityPos, "at sight")
            End If
            'Dim AmountCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCCY").Range.End
            'c.RichEditControl1.Document.InsertText(AmountCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            'Dim AmountCollectionPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCollection").Range.End
            'c.RichEditControl1.Document.InsertText(AmountCollectionPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))

            Dim DraweeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeNamePos, DraweeName)
            Dim DraweeStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeStreetPos, DraweeAddress)
            Dim DraweeZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeZipCityPos, DraweeBankZipCodeCity)
            Dim DraweeCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeCountry").Range.End
            c.RichEditControl1.Document.InsertText(DraweeCountryPos, DraweeCountry)

            Dim ChargesCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesCCY").Range.End
            c.RichEditControl1.Document.InsertText(ChargesCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text & "  ")
            Dim ChargesAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesAmount").Range.End
            c.RichEditControl1.Document.InsertText(ChargesCCYPos, CHARGES_SUM)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PaymentInstructions").Range.End
            c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text)




            ''Confirmation
            'Dim Not_Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Not_Confirmed").Range.End
            'Dim Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Confirmed").Range.End
            'If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "X")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "")
            'Else
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "X")
            'End If
            SplashScreenManager.CloseForm(False)


            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
            '    & "Charges for Applicant   = 1" & vbNewLine _
            '    & "Charges for Beneficiary = 2" & vbNewLine _
            '    & "Charges Shared          = 0"

            'title = "ADVICE COMMISSION SHARING"   ' Set title.
            'defaultValue = "1"   ' Set default value.
            '' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            'Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            'Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            'If myValue = "1" Then
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            'ElseIf myValue = "2" Then
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            'ElseIf myValue = "0" Then
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            'Else
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            'End If


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub EXPORT_COLLECTION_PAYMENT_ADVICE_CUSTOMER_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the creation of Customer Payment Advice Document")
            Dim EXPORT_COLLECTION_PAYMENT_ADVICE_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "EXPORT_COLLECTION_PAYMENT_ADVICE_CUSTOMER" Then
                    EXPORT_COLLECTION_PAYMENT_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANK_NAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANK_STRASSE As String = Nothing
            Dim OUR_BANK_PLZ As String = Nothing
            Dim OUR_BANK_ORT As String = Nothing

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANK_NAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANK_STRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANK_PLZ = dt.Rows.Item(0).Item("PLZ Bank")
            OUR_BANK_ORT = dt.Rows.Item(0).Item("Ort Bank")

            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            'Get Current User Contact details
            Me.QueryText = "SELECT * FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = SystemInformation.UserName Then
                    CURRENT_USER_CONTACT_DETAILS = dt.Rows.Item(i).Item("PARAMETER INFO")
                End If
            Next



            'Customer Parameters
            Dim CustomerID As String = Nothing
            Dim CustomerName As String = Nothing
            Dim CustomerNameAddress As String = Nothing
            Dim CustomerAddress As String = Nothing
            Dim CustomerZipCode As String = Nothing
            Dim CustomerCity As String = Nothing
            Dim CustomerFon As String = Nothing
            Dim CustomerFax As String = Nothing
            Dim CustomerEmail As String = Nothing
            Dim CustomerContact1 As String = Nothing
            Dim CustomerContact2 As String = Nothing
            Dim CustomerLcAdviceEmail As String = Nothing

            'Drawer Parameters
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CustomerID = dt.Rows.Item(i).Item("CustomerID")
                    CustomerName = dt.Rows.Item(i).Item("CustomerName")
                    If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
                        CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
                    End If
                    If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
                        CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
                    End If
                    CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
                    CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
                    If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
                        CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
                    End If
                    If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
                        CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
                    End If
                    If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
                        CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
                        CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
                    End If
                    If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
                        CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
                    End If
                    If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
                        CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Customer not fund in the Foreign Dept. Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Drawee Parameters
            Dim DraweeName As String = Nothing
            Dim DraweeAddress As String = Nothing
            Dim DraweeZipCodeCity As String = Nothing
            Dim DraweeCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('A') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeName = dt.Rows.Item(i).Item("Name")
                    DraweeAddress = dt.Rows.Item(i).Item("Address")
                    DraweeZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee details for this Export Collection!", "DRAWEE DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Drawee Bank Parameters
            Dim DraweeBankName As String = Nothing
            Dim DraweeBankAddress As String = Nothing
            Dim DraweeBankZipCodeCity As String = Nothing
            Dim DraweeBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_COLLECTIONS_DraweeNameAddress] where [NameType] in ('B') and  [Id_OurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    DraweeBankName = dt.Rows.Item(i).Item("Name")
                    DraweeBankAddress = dt.Rows.Item(i).Item("Address")
                    DraweeBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    DraweeBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("Drawee Bank Details are not fund for this Export Collection!" & vbNewLine & "Please add and link Drawee Bank details for this Export Collection!", "DRAWEE BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Dim CHARGES_NAMES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & " and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                    CHARGES_NAMES += dt.Rows.Item(i).Item("ConditionName") & ","
                Next
            End If

            'Get Charges Sum
            Dim CHARGES_SUM As String = Nothing
            Me.QueryText = "Select 'SumCharges'=Case when Sum([ChargesOrigAmount]) is not NULL then Sum([ChargesOrigAmount]) else 0 end from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            CHARGES_SUM = FormatNumber(dt.Rows.Item(0).Item("SumCharges"), 2)

            SplashScreenManager.Default.SetWaitFormCaption("Create Payment Advice to customer")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Customer Collection Document"
            c.RichEditControl1.LoadDocument(EXPORT_COLLECTION_PAYMENT_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            Dim OurBankStreetPos As DocumentPosition = myHeader.Bookmarks("OurBankStreet").Range.End
            myHeader.InsertText(OurBankStreetPos, OUR_BANK_STRASSE)
            Dim OurBankPLZPos As DocumentPosition = myHeader.Bookmarks("OurBankPLZ").Range.End
            myHeader.InsertText(OurBankPLZPos, OUR_BANK_PLZ)
            Dim OurBankCityPos As DocumentPosition = myHeader.Bookmarks("OurBankCity").Range.End
            myHeader.InsertText(OurBankCityPos, OUR_BANK_ORT)
            Dim OurBankBicPos As DocumentPosition = myHeader.Bookmarks("OurBankBic").Range.End
            myHeader.InsertText(OurBankBicPos, "BIC: " & OUR_BIC)
            myHeader.Fields.Update()
            firstSection.EndUpdateHeader(myHeader)

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Charges Details
            Dim ChargesDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesTable").Range.End
            Dim tbl_chgs As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(ChargesDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 0).Range.Start, "Abrechnungsdetails")
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 1).Range.Start, "Währung")
            c.RichEditControl1.Document.InsertText(tbl_chgs(0, 2).Range.Start, "Betrag")
            Try
                tbl_chgs.BeginUpdate()
                'Get Invoice details
                Me.QueryText = "Select [InvoiceCCY],[InvoiceAmount] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Rechnungsbetrag:"
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("InvoiceAmount"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If

                'Get other Charges
                Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Charges] where [IdOurReference]=" & ID_COLLECTION & " and [ChargesOrigAmount]<>0"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                        Dim cell As TableCell = row.FirstCell
                        Dim BetragName As String = "abzgl. " & dt.Rows.Item(i).Item("ConditionName")
                        Dim CCY As String = dt.Rows.Item(i).Item("ChargesCCY")
                        Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(i).Item("ChargesOrigAmount"))
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                    Next
                End If
                'Get Net Amount for Customer
                Me.QueryText = "Select [InvoiceCCY],[NettoAmountCustomer] from [EXPORT_COLLECTIONS] where [ID]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl_chgs.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Nettoerlös."
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("NettoAmountCustomer"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If


                ' Center the table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl_chgs.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl_chgs.LastRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                For i As Integer = 0 To tbl_chgs.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl_chgs.Rows(i).Cells(2).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next
            Finally
                tbl_chgs.EndUpdate()
            End Try


            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Documents Details
            Dim DocumentsDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DocumentsTable").Range.End
            Dim tbl As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(DocumentsDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl(0, 0).Range.Start, "Documents:")
            'c.RichEditControl1.Document.InsertText(tbl(0, 1).Range.Start, "Count")
            'c.RichEditControl1.Document.InsertText(tbl(0, 2).Range.Start, "Betrag")
            Try
                tbl.BeginUpdate()
                'Get Documents
                Me.QueryText = "Select * from [EXPORT_COLLECTIONS_Documents] where [IdOurReference]=" & ID_COLLECTION & ""
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                        Dim cell As TableCell = row.FirstCell
                        Dim DocumentName As String = dt.Rows.Item(i).Item("DocumentName")
                        Dim DocumentsCount As String = dt.Rows.Item(i).Item("DocumentsCount")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, DocumentName)
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, "  ")
                        c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, DocumentsCount)
                    Next
                End If

                ' table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Right
                    p.BackColor = Color.White
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 10
                    titleFormatting.Bold = False
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                'All other rows
                For i As Integer = 0 To tbl.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next

                'Create Table Style
                Dim tStyleNormal As DevExpress.XtraRichEdit.API.Native.TableStyle = c.RichEditControl1.Document.TableStyles.CreateNew()
                tStyleNormal.LineSpacingType = ParagraphLineSpacing.Single
                'tStyleNormal.FontName = "Verdana"
                tStyleNormal.Alignment = ParagraphAlignment.Left
                Dim borders As TableBorders = tStyleNormal.TableBorders
                borders.Bottom.LineColor = Color.DarkBlue
                borders.Left.LineColor = Color.DarkBlue
                borders.Right.LineColor = Color.DarkBlue
                borders.Top.LineColor = Color.DarkBlue
                borders.InsideVerticalBorder.LineColor = Color.DarkBlue
                borders.InsideHorizontalBorder.LineColor = Color.DarkBlue
                tStyleNormal.CellBackgroundColor = Color.Transparent
                tStyleNormal.Name = "MyTableGridNormal"

                c.RichEditControl1.Document.TableStyles.Add(tStyleNormal)
                tbl.Style = c.RichEditControl1.Document.TableStyles("MyTableGridNormal")


            Finally
                tbl.EndUpdate()
            End Try

            Dim CollectionDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CollectionDate").Range.End
            c.RichEditControl1.Document.InsertText(CollectionDatePos, Today)

            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, Me.CustomerContactName_TextEdit.Text)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerStreet").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerPLZ").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerCity").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)

            Dim DraweeBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankNamePos, DraweeBankName)
            Dim DraweeBankStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankStreetPos, DraweeBankAddress)
            Dim DraweeBankZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeBankZipCityPos, DraweeBankZipCodeCity)
            Dim ApplicantBankCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeBankCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankCountryPos, DraweeBankCountry)

            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)
            Dim CustomerLetterDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerLetterDate").Range.End
            c.RichEditControl1.Document.InsertText(CustomerLetterDatePos, Me.CustomerLetterDate_DateEdit.Text)
            Dim CustomerContactPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos1, Me.CustomerContactName_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, OurReferenceSearch)
            Dim MaturityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            If IsDate(Me.MaturityDate_DateEdit.Text) = True Then
                c.RichEditControl1.Document.InsertText(MaturityPos, Me.MaturityDate_DateEdit.Text)
            Else
                c.RichEditControl1.Document.InsertText(MaturityPos, "at sight")
            End If
            'Dim AmountCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCCY").Range.End
            'c.RichEditControl1.Document.InsertText(AmountCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            'Dim AmountCollectionPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmountCollection").Range.End
            'c.RichEditControl1.Document.InsertText(AmountCollectionPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))

            Dim DraweeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeName").Range.End
            c.RichEditControl1.Document.InsertText(DraweeNamePos, DraweeName)
            Dim DraweeStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeStreet").Range.End
            c.RichEditControl1.Document.InsertText(DraweeStreetPos, DraweeAddress)
            Dim DraweeZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeZipCity").Range.End
            c.RichEditControl1.Document.InsertText(DraweeZipCityPos, DraweeBankZipCodeCity)
            Dim DraweeCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DraweeCountry").Range.End
            c.RichEditControl1.Document.InsertText(DraweeCountryPos, DraweeCountry)


            Dim SettlementDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ValueDate").Range.End
            c.RichEditControl1.Document.InsertText(SettlementDatePos, Me.SettlementDate_DateEdit.Text)
            'Dim ChargesCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesCCY").Range.End
            'c.RichEditControl1.Document.InsertText(ChargesCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text & "  ")
            'Dim ChargesAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesAmount").Range.End
            'c.RichEditControl1.Document.InsertText(ChargesCCYPos, CHARGES_SUM)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PaymentInstructions").Range.End
            c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text)




            ''Confirmation
            'Dim Not_Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Not_Confirmed").Range.End
            'Dim Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Confirmed").Range.End
            'If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "X")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "")
            'Else
            '    c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "")
            '    c.RichEditControl1.Document.InsertText(Confirmed_Pos, "X")
            'End If
            SplashScreenManager.CloseForm(False)


            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
            '    & "Charges for Applicant   = 1" & vbNewLine _
            '    & "Charges for Beneficiary = 2" & vbNewLine _
            '    & "Charges Shared          = 0"

            'title = "ADVICE COMMISSION SHARING"   ' Set title.
            'defaultValue = "1"   ' Set default value.
            '' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            'Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            'Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            'If myValue = "1" Then
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            'ElseIf myValue = "2" Then
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            'ElseIf myValue = "0" Then
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            'Else
            '    c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
            '    c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            'End If


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub SettlementApplBank_RadioGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SettlementApplBank_RadioGroup.SelectedIndexChanged

    End Sub
End Class