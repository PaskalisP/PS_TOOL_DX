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

Public Class LcExportMT7

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
    Dim LAST_LC_REST_AMOUNT As Double = 0

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

    Private Sub EXPORT_LC_MT700BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXPORT_LC_MT700BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.LcDataset)

    End Sub

    Private Sub LcExportMT7_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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

        AddHandler GridControl3.EmbeddedNavigator.ButtonClick, AddressOf GridControl3_EmbeddedNavigator_ButtonClick
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl5.EmbeddedNavigator.ButtonClick, AddressOf GridControl5_EmbeddedNavigator_ButtonClick

        Me.TreeList1.OptionsDragAndDrop.DragNodesMode = True
        Me.LayoutControl1.Dock = DockStyle.Fill

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
        If e.Button.Tag = "AddNewSettlement" Then
            If Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
                If MessageBox.Show("Should a new Settlement be added for the current Export LC? ", "NEW SETTLEMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Add new Settlement...")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "DECLARE @LC_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                                            DECLARE @SETTLEMENT_NR_NEW float=(Select Count(ID)+1 from [EXPORT_LC_MT700_Settlements] where [Id_OurReference]='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "')
                                            DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))
                                            DECLARE @LC_CURRENCY nvarchar(max)='" & Me.LcCurrency_TextEdit.Text & "'

                                            IF @SETTLEMENT_NR_NEW=1
                                            BEGIN
                                            INSERT INTO [EXPORT_LC_MT700_Settlements]
                                           ([SettlementNr]
                                            ,[SettlementReference]
                                            ,[SettlementDate]
                                            ,[InvoiceCCY]
                                            ,[Id_OurReference])
                                            VALUES 
                                            (@SETTLEMENT_NR_NEW
                                            ,@LC_REFERENCE + '-' + CONVERT(nvarchar,@SETTLEMENT_NR_NEW)
                                            ,@RISKDATE
                                            ,@LC_CURRENCY
											,@LC_REFERENCE)
                                            END                                            

                                            IF @SETTLEMENT_NR_NEW>1
                                            BEGIN
                                            INSERT INTO [EXPORT_LC_MT700_Settlements]
                                           ([SettlementNr]
                                            ,[SettlementReference]
                                            ,[SettlementDate]
                                            ,SettlementType
                                            ,CustomerAccountCCY
											,CustomerAccountNr
											,CustomerBankName
                                            ,InvoiceCCY
                                            ,LcRestAmount
											,DiscontCustomerLetterDate
											,DiscontCustomerLetterReference
											,DiscontCustomerLetterContact
                                            ,[Id_OurReference])
                                            SELECT 
                                            @SETTLEMENT_NR_NEW
                                            ,@LC_REFERENCE + '-' + CONVERT(nvarchar,@SETTLEMENT_NR_NEW)
                                            ,@RISKDATE
                                            ,SettlementType
                                            ,CustomerAccountCCY
											,CustomerAccountNr
											,CustomerBankName
                                            ,InvoiceCCY
                                            ,LcRestAmount
											,@RISKDATE
											,DiscontCustomerLetterReference
											,DiscontCustomerLetterContact
                                            ,@LC_REFERENCE
											FROM [EXPORT_LC_MT700_Settlements] where ID in 
											(Select Max(ID) from [EXPORT_LC_MT700_Settlements] where Id_OurReference=@LC_REFERENCE)
                                            END"
                        cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Me.LayoutControl1.Visible = False
                        Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillBySettlementMax(Me.LcDataset.EXPORT_LC_MT700_Settlements, Me.OurReferenceSearch_GridLookUpEdit.Text)
                        DISCOUNT_CHECK_STATUS()
                        SETTLEMENT_LC_CHECK_STATUS()
                        GET_LAST_REST_LC_AMOUNT()
                        SplashScreenManager.CloseForm(False)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try

                End If
            Else
                MessageBox.Show("Unable to add new Settlement for this LC!" & vbNewLine & "LC Status: Done!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        End If

        'Delete Settlement
        'Allways the last settlement
        If e.Button.Tag = "DeleteSettlement" Then
            If Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
                If Me.ExportLc_Settlements_BaseView.RowCount > 0 Then
                    If MessageBox.Show("Should the selected Settlement Nr.: " & Me.SettlementNr_lbl.Text & " be deleted for the current Export LC? ", "DELETE SETTLEMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        Try
                            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                            SplashScreenManager.Default.SetWaitFormCaption("Try to delete Settlement...")
                            Dim CurrentSettlementNr As Double = Me.SettlementNr_lbl.Text
                            Dim MaxSettlementNr As Double = 0
                            Me.QueryText = "Select Count(ID) As 'MaxSettlementNr' from [EXPORT_LC_MT700_Settlements] where Id_OurReference='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'"
                            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                MaxSettlementNr = dt.Rows.Item(0).Item("MaxSettlementNr")
                            End If
                            If CurrentSettlementNr = MaxSettlementNr Then
                                Me.ExportLc_Settlements_BaseView.DeleteRow(ExportLc_Settlements_BaseView.FocusedRowHandle)
                                Me.EXPORT_LC_MT700_SettlementsTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements)
                                Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements, OurReferenceSearch)
                                SplashScreenManager.CloseForm(False)
                                MessageBox.Show("The selected Settlement Nr.: " & CurrentSettlementNr & " is deleted! ", "SETTLEMENT DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            ElseIf CurrentSettlementNr < MaxSettlementNr Then
                                SplashScreenManager.CloseForm(False)
                                MessageBox.Show("Unable to delete Settlement Nr." & CurrentSettlementNr & vbNewLine & "Only the last settlement can be deleted", "UNABLE TO DELETE SETTLEMENT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                Return
                            End If
                        Catch ex As Exception
                            SplashScreenManager.CloseForm(False)
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End Try

                    End If

                End If
            Else
                MessageBox.Show("Unable to delete any Settlements!" & vbNewLine & "LC Status: Done!", "UNABLE TO DELETE SETTLEMENT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        End If

    End Sub

    Private Sub GridControl5_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
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
                        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements_Charges)
                        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByID(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, Me.SettlementID_lbl.Text)
                        Me.SettlementSave_btn.PerformClick()
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
                If MessageBox.Show("Should the Charges  be calculated automatically?" & vbNewLine & "Attention:After automatic calculation is started all present charges for this settlement will be deleted!", "CALCULATE CHARGES AUTOMATICALLY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Calculate Charges...")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "DECLARE @LC_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                                           DECLARE @SETTLEMENT_ID int=" & CInt(Me.SettlementID_lbl.Text) & "
                                           DECLARE @SETTLEMENT_NR float=" & CDbl(Me.SettlementNr_lbl.Text) & "
                                           DECLARE @CUSTOMER_ID int=" & CInt(RelatedCustomerID) & "
                                           DECLARE @LC_AMOUNT float=(Select [LC_Amount] from [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "')
                                           DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))

                                           DELETE FROM  [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]=@SETTLEMENT_ID

                                     INSERT INTO [EXPORT_LC_MT700_Settlements_Charges]
                                           ([ConditionName]
                                           ,[ConditionCyclus]
                                           ,[ConditionType]
                                           ,[ConditionPercent]
                                           ,[ConditionMin]
                                           ,[ConditionMax]
                                           ,[Notes]
                                           ,[IdExportLcSettlement])
                                     SELECT 
                                         [ConditionName]
                                        ,[ConditionCyclus]
                                        ,[ConditionType]
                                        ,[ConditionPercent]
                                        ,[ConditionMin]
                                        ,[ConditionMax]
                                        ,[Notes]
                                        ,@SETTLEMENT_ID
                                    FROM [EXPORT_LC_CUSTOMERS_Conditions] where [IdExportLcCustomers]=@CUSTOMER_ID and @SETTLEMENT_NR=1

                                    INSERT INTO [EXPORT_LC_MT700_Settlements_Charges]
                                           ([ConditionName]
                                           ,[ConditionCyclus]
                                           ,[ConditionType]
                                           ,[ConditionPercent]
                                           ,[ConditionMin]
                                           ,[ConditionMax]
                                           ,[Notes]
                                           ,[IdExportLcSettlement])
                                        SELECT 
                                         [ConditionName]
                                        ,[ConditionCyclus]
                                        ,[ConditionType]
                                        ,[ConditionPercent]
                                        ,[ConditionMin]
                                        ,[ConditionMax]
                                        ,[Notes]
                                        ,@SETTLEMENT_ID
                                    FROM [EXPORT_LC_CUSTOMERS_Conditions] where [IdExportLcCustomers]=@CUSTOMER_ID and [ConditionCyclus] in ('R') and @SETTLEMENT_NR>1"
                        cmd.ExecuteNonQuery()
                        'Calculate charges
                        cmd.CommandText = "DECLARE @LC_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                                           DECLARE @SETTLEMENT_ID int=" & CInt(Me.SettlementID_lbl.Text) & "
                                           DECLARE @SETTLEMENT_NR float=" & CDbl(Me.SettlementNr_lbl.Text) & "
                                           DECLARE @CUSTOMER_ID int=" & CInt(RelatedCustomerID) & "
                                           DECLARE @LC_AMOUNT float=(Select [LC_Amount] from [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "')
                                           DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))

                                            UPDATE [EXPORT_LC_MT700_Settlements_Charges] SET [ChargesOrigAmount]=ROUND([ConditionPercent]*@LC_AMOUNT,2) where [IdExportLcSettlement]=@SETTLEMENT_ID
  
                                            UPDATE [EXPORT_LC_MT700_Settlements_Charges] SET [ChargesOrigAmount]=Case when [ChargesOrigAmount]<[ConditionMin] then [ConditionMin] 
                                            when [ChargesOrigAmount]>[ConditionMax] then [ConditionMax] else [ChargesOrigAmount] end
                                            where [IdExportLcSettlement]=@SETTLEMENT_ID

                                           UPDATE [EXPORT_LC_MT700_Settlements_Charges] SET [ChargesOrigAmount]=0 where [ChargesOrigAmount] is NULL and [IdExportLcSettlement]=@SETTLEMENT_ID
"
                        cmd.ExecuteNonQuery()

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements_Charges)
                        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByID(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, Me.SettlementID_lbl.Text)
                        Me.SettlementSave_btn.PerformClick()
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

    Private Sub ApplyCustomFormatting(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
        For Each paragraph As Paragraph In document.Paragraphs
            Dim parRange As DocumentRange = paragraph.Range

            If document.GetText(parRange).TrimStart().StartsWith(":") Then
                Dim cp As CharacterProperties = document.BeginUpdateCharacters(parRange)
                cp.ForeColor = Color.White
                cp.BackColor = Color.DarkCyan
                document.EndUpdateCharacters(cp)
            End If
        Next
    End Sub

    Public Shared Sub ChangeTextcolor(textToMark As String, color As Color, richTextBox As RichTextBox, startIndex As Integer)
        If startIndex < 0 OrElse startIndex > textToMark.Length - 1 Then
            startIndex = 0
        End If

        Dim newFont As System.Drawing.Font = New Font("Verdana", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, False)
        Try
            For Each line As String In richTextBox.Lines
                If line.StartsWith(textToMark) Then
                    richTextBox.[Select](startIndex, line.Length)
                    richTextBox.SelectionBackColor = color

                End If
                startIndex += line.Length + 1
            Next
        Catch
        End Try
    End Sub

    Private Sub SETTLEMENT_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT  * FROM [EXPORT_LC_CUSTOMERS_BankDetails] where [IdExportLcCustomers]='" & Me.RelatedCustomerID_lbl.Text & "' and [Status] in ('Y')", connSQL)
        objCMD1.CommandTimeout = 5000
        Dim dbSettlementTypes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbSettlementTypes.Fill(ds, "EXPORT_LC_CUSTOMERS_BankDetails") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SettlementType = New BindingSource(ds, "EXPORT_LC_CUSTOMERS_BankDetails") 'NOSTRO_ACC_RECONCILIATIONS
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

    Private Sub SAVE_ALL_CHANGES()
        Try
            Me.Validate()
            Me.EXPORT_LC_MT700BindingSource.EndEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.EndEdit()
            Me.FKEXPORTLCMT700SettlementsApplNameAddressEXPORTLCMT700BindingSource.EndEdit()
            Me.FKEXPORTLCMT700SettlementsEXPORTLCMT700BindingSource.EndEdit()
            Me.FKEXPORTLCMT700SettlementsChargesEXPORTLCMT700SettlementsBindingSource.EndEdit()
            'Me.EXPORT_LC_MT700_RMTableAdapter.Update(Me.LcDataset)
            Me.TableAdapterManager.UpdateAll(Me.LcDataset)
            'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
            'Me.SwiftMessageFormated_RichTextBox.Clear()
            'Me.SwiftMessageFormated_RichTextBox.Text = s
            'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
            ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
            ApplyCustomFormatting(Me.RichEditControl1.Document)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub FILL_ALL_DATA_BY_OUR_REFERENCE()

        Try
            Me.EXPORT_LC_MT700TableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700, OurReferenceSearch)
            Me.EXPORT_LC_MT700_RMTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_RM, OurReferenceSearch)
            Me.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements_ApplNameAddress, OurReferenceSearch)
            Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements, OurReferenceSearch)
            Me.EXPORT_LC_MT700_ApplNameAddressTableAdapter.Fill(Me.LcDataset.EXPORT_LC_MT700_ApplNameAddress)
            Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByAllSettlementsCharges(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, OurReferenceSearch)
            Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)
            SETTLEMENT_TYPE_initData()
            SETTLEMENT_TYPES_InitLookUp()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Temporary Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub VALIDATIONS_REMOVE()
        DxValidationProvider1.SetValidationRule(Me.SettlementType_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.InvoiceCCY_GridLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Me.InvoiceAmount_SpinEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.InterestDateFrom_DateEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.InterestDateTill_DateEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.InterestRate_SpinEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.Marge_SpinEdit, Nothing)
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
        DxValidationProvider1.SetValidationRule(Me.SettlementType_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.InvoiceCCY_GridLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Me.InvoiceAmount_SpinEdit, higherZeroValidationRule)

    End Sub

    Private Sub VALIDATIONS_DISCOUNT_ADD()
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
        'Validations for Discount
        If Me.Discount_CheckEdit.CheckState = CheckState.Checked Then
            DxValidationProvider2.SetValidationRule(Me.InterestDateFrom_DateEdit, notEmptyValidationRule)
            DxValidationProvider2.SetValidationRule(Me.InterestDateTill_DateEdit, notEmptyValidationRule)
            DxValidationProvider2.SetValidationRule(Me.InterestRate_SpinEdit, higherZeroValidationRule)
            DxValidationProvider2.SetValidationRule(Me.Marge_SpinEdit, higherZeroValidationRule)
        Else
            DxValidationProvider2.SetValidationRule(Me.InterestDateFrom_DateEdit, Nothing)
            DxValidationProvider2.SetValidationRule(Me.InterestDateTill_DateEdit, Nothing)
            DxValidationProvider2.SetValidationRule(Me.InterestRate_SpinEdit, Nothing)
            DxValidationProvider2.SetValidationRule(Me.Marge_SpinEdit, Nothing)
        End If
    End Sub

    Private Sub VALIDATIONS_DISCOUNT_REMOVE()
        DxValidationProvider2.SetValidationRule(Me.InterestDateFrom_DateEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.InterestDateTill_DateEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.InterestRate_SpinEdit, Nothing)
        DxValidationProvider2.SetValidationRule(Me.Marge_SpinEdit, Nothing)
    End Sub

#Region "OUR REFERENCE SEARCH"

    Private Sub OurReferenceSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.EditValueChanged
        If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" AndAlso Me.OurReferenceSearch_GridLookUpEdit.Text.ToString.StartsWith("DEFF") = True Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text

            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = True
            LC_RELATED_DATAXtraTabPage.PageVisible = True
            LC_SETTLEXtraTabPage.PageVisible = True
            Me.LayoutControl1.Visible = True
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
            LC_LIST_XtraTabPage.PageVisible = False
            Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
            Me.XtraTabControl2.Focus()
            FILL_ALL_DATA_BY_OUR_REFERENCE()
            'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
            'Me.SwiftMessageFormated_RichTextBox.Clear()
            'Me.SwiftMessageFormated_RichTextBox.Text = s
            'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
            ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
            ApplyCustomFormatting(Me.RichEditControl1.Document)
            RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

            If Me.AdvicedStatus_CheckEdit.EditValue = True Then

                ADVICE_STATUS_DISABLED()
            Else
                ADVICE_STATUS_ENABLED()
            End If
        End If
    End Sub
    Private Sub OurReferenceSearch_GridLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles OurReferenceSearch_GridLookUpEdit.ButtonClick
        If e.Button.Caption = "Search" Then
            If Me.OurReferenceSearch_GridLookUpEdit.Text <> "" Then
                Me.EXPORT_LC_MT700BindingSource.CancelEdit()
                Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
                OurReferenceSearch = Me.OurReferenceSearch_GridLookUpEdit.Text

                Me.XtraTabControl2.Visible = True
                LC_BASIC_DATAXtraTabPage.PageVisible = True
                LC_RELATED_DATAXtraTabPage.PageVisible = True
                LC_SETTLEXtraTabPage.PageVisible = True
                Me.LayoutControl1.Visible = True
                LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
                LC_LIST_XtraTabPage.PageVisible = False
                Me.OurReferenceSearch_GridLookUpEdit.Text = OurReferenceSearch
                Me.XtraTabControl2.Focus()
                FILL_ALL_DATA_BY_OUR_REFERENCE()
                'Dim s As String = Me.SwiftMessageFormated_RichTextBox.Text
                'Me.SwiftMessageFormated_RichTextBox.Clear()
                'Me.SwiftMessageFormated_RichTextBox.Text = s
                'ChangeTextcolor(":", Color.DarkCyan, Me.SwiftMessageFormated_RichTextBox, 0)
                ApplyCustomFormatting(Me.SwiftMessageFormated_RichTextBox.Document)
                ApplyCustomFormatting(Me.RichEditControl1.Document)
                RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

                If Me.AdvicedStatus_CheckEdit.EditValue = True Then
                    ADVICE_STATUS_DISABLED()
                Else
                    ADVICE_STATUS_ENABLED()
                End If
            End If
        End If
        If e.Button.Caption = "Add" Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = True
            LC_BASIC_DATAXtraTabPage.PageVisible = False
            LC_RELATED_DATAXtraTabPage.PageVisible = False
            LC_SETTLEXtraTabPage.PageVisible = False
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = True
            LC_LIST_XtraTabPage.PageVisible = False
            '*************************************************************
            'Fill Currency Codes in LC Currency Combo
            Me.M_LC_Currency_TextEdit.Properties.Items.Clear()
            Me.QueryText = "Select [CURRENCY CODE] from [OWN_CURRENCIES] where [VALID]='Y' order by [CURRENCY CODE] asc "
            daSql = New SqlDataAdapter(Me.QueryText.Trim(), connSQL)
            dtSql = New System.Data.DataTable()
            daSql.Fill(dtSql)
            For Each row As DataRow In dtSql.Rows
                If dtSql.Rows.Count > 0 Then
                    Me.M_LC_Currency_TextEdit.Properties.Items.Add(row("CURRENCY CODE"))
                End If
            Next
            ADVICE_STATUS_ENABLED()
            'If dt.Rows.Count > 0 Then
            'M_LC_Currency_TextEdit.Text = dt.Rows.Item(0).Item("CURRENCY CODE")
            'End If
            '***********************************************************
        End If
        If e.Button.Caption = "Load Export LC List" Then
            Me.EXPORT_LC_MT700BindingSource.CancelEdit()
            Me.EXPORT_LC_MT700_RMBindingSource.CancelEdit()
            Me.OurReferenceSearch_GridLookUpEdit.Text = ""
            Me.XtraTabControl2.Visible = False
            '+++++++++++++++++++++++++++++++++++++++++++
            Me.ExportLC_List_GridControl.DataSource = Nothing
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading all Export LC's")
            Try
                Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using sqlCmd As New SqlCommand()
                        sqlCmd.CommandText = "SELECT [ID],[SwiftFileName],[LfdNr],[OurReference],[MessageType],[MessageTypeName],[SenderBIC],[SenderName],[SenderBranch],[ReceivedDate],[OSN],[LC_Form],[LC_Nr],[DateOfIssue],[IssuingBank],[M31D_Date],[M31D_Country],UPPER(SUBSTRING([Applicant], 0,CHARINDEX(CHAR(13),[Applicant]))) as 'Applicant',UPPER(SUBSTRING([Beneficiary], 0,CHARINDEX(CHAR(13),[Beneficiary]))) as 'Beneficiary',[LC_Currency],[LC_Amount],[Available_With],[Available_By],[AdvicedConfirmation],[Adviced],[AdvicedOn],[AdviceChargesCurrency],[AdviceCharges],[Done],[DoneOn],[RelatedCustomerID],[RelatedCustomerName],[CustomersReference] FROM [EXPORT_LC_MT700] order by [LfdNr] desc"
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
            LC_RELATED_DATAXtraTabPage.PageVisible = False
            LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
            LC_SETTLEXtraTabPage.PageVisible = False
            LC_LIST_XtraTabPage.PageVisible = True
        End If

    End Sub

    Private Sub OurReferenceSearch_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles OurReferenceSearch_GridLookUpEdit.Click
        Me.XtraTabControl2.Visible = False
        Me.EXPORT_LC_MT700_BD_TableAdapter.FillByCustomerSearchStoredProcedure(Me.LcDataset.EXPORT_LC_MT700_BD)
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



#Region "LC MT700 ADVICES"

    Private Sub Advice_MT700_DTAEA_New_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_DTAEA_New_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
            'ElseIf MsgType_lbl.Text <> "700" Then
            '    MessageBox.Show("Unable to create DTAEA File - Message Type is not 700", "WRONG MESSAGE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar

            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Dim MessageType As String = MsgType_lbl.Text
                Select Case MessageType
                    Case = "700"
                        DTAEA_MT700_NEW_ADVICE()
                    Case = "710"
                        DTAEA_MT710_ADVICE()
                    Case = "720"
                        DTAEA_MT720_ADVICE()
                    Case Else
                        MessageBox.Show("Unable to create DTAEA File - Message Type is not specified for DTAEA Advice", "WRONG MESSAGE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                End Select

            End If
            cmd.Connection.Close()

        End If
    End Sub


    Private Sub Advice_MT700_DTAEA_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_DTAEA_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
            'ElseIf MsgType_lbl.Text <> "700" Then
            '    MessageBox.Show("Unable to create DTAEA File - Message Type is not 700", "WRONG MESSAGE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar

            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Dim MessageType As String = MsgType_lbl.Text
                Select Case MessageType
                    Case = "700"
                        DTAEA_MT700_NEW_ADVICE()
                    Case = "710"
                        DTAEA_MT710_ADVICE()
                    Case = "720"
                        DTAEA_MT720_ADVICE()
                    Case Else
                        MessageBox.Show("Unable to create DTAEA File - Message Type is not specified for DTAEA Advice", "WRONG MESSAGE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                End Select

            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Normal_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Normal_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE()
                End If

            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Variation1_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Variation1_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE_VARIATION1()
                End If
            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_Fax_Variation2_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_Fax_Variation2_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Fax Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL"
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim CheckResult As String = cmd.ExecuteScalar
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
                Dim CheckResultSecond As String = cmd.ExecuteScalar
                If CheckResultSecond = "" Then
                    MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    FAX_MT700_ADVICE_VARIATION2()
                End If

            End If
            cmd.Connection.Close()

        End If
    End Sub

    Private Sub Advice_MT700_CL_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Advice_MT700_CL_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Advice Cover Form - LC allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Advice again!", "LC ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "SELECT [ContactPerson1] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [ContactPerson1] is not NULL"
            Dim CheckResultSecond As String = cmd.ExecuteScalar
            If CheckResultSecond = "" Then
                MessageBox.Show("Unable to create LC Advice Form - No Contact Person has being indicated for this Customer" & vbNewLine & "Please indicate Contact Person for this Customer!", "CONTACT PERSON IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                ANSCHREIBEN_LC_MT700_ADVICE()
            End If

            cmd.Connection.Close()

        End If
    End Sub

    Private Sub CoverSheet_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CoverSheet_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            LC_COVER_SHEET()
        End If
    End Sub
#End Region

    Private Sub DTAEA_MT700_NEW_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            Dim ErstellungsDatum As String = d.ToString("yyyyMMdd")
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing 'Message Type
            Dim M13 As String = Nothing 'BIC Advising Bank
            Dim M14 As String = Nothing 'BIC Name Asdvising Bank
            Dim M04 As String = Nothing 'Reference Advising Bank
            Dim M12 As String = Nothing 'Contact Details Advising Bank
            Dim M91 As String = Nothing 'LC Confirmation Sign
            Dim M40 As String = Nothing 'Informations for LC Confirmation
            Dim M41 As String = Nothing 'Info Text from Advising Bank
            Dim M42 As String = Nothing 'Charges Advising Bank
            Dim M15 As String = Nothing 'BIC Issuing Bank
            Dim M16 As String = Nothing 'BIC Name Issuing Bank
            Dim M02 As String = Nothing 'LC Reference
            Dim M01 As String = Nothing ' Customer Reference
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M12 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M41 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & ErstellungsDatum & DateTime.Now.ToString("HHMM")
            MT = ":MT:" & MsgType_lbl.Text
            M13 = ":M13:" & OUR_BIC
            M14 = ":M14:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M04 = ":M04:" & Me.OurReference_TextEdit.Text
            M12 = ":M12:" & M12
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M91 = ":M91:2"
            Else
                M91 = ":M91:1"
            End If
            M41 = M41.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M41 = M41.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M41 = ":M41:" & M41
            M42 = ":M42:" & CustomerLcAdviceCharges_DTAEA_M8
            M15 = ":M15:" & Me.IssuingBIC_TextEdit.Text
            M16 = ":M16:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M02 = ":M02:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            'M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            'M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M01 = ":M01:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"


            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("HHMM") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("HHMM") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M13)
            Writer.WriteLine(M14)
            Writer.WriteLine(M04)
            Writer.WriteLine(M12)
            Writer.WriteLine(M91)
            Writer.WriteLine(M41)
            If CustomerLcAdviceCharges_DTAEA_M8 <> "" Then
                Writer.WriteLine(M42)
            End If
            Writer.WriteLine(M15)
            Writer.WriteLine(M16)
            Writer.WriteLine(M02)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M01)
            End If
            Writer.WriteLine(Mid(SwiftNachricht, 8)) 'without Field 27-Sequence of Total
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Avisierung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Das Akkreditiv wurde von der Bank:" & vbNewLine _
                & ISSOUING_BANK_NAME & vbNewLine _
                & ISSOUING_BANK_CITY & vbNewLine _
                & ISSOUING_BANK_COUNTRY & vbNewLine _
                & "Im auftrag von " & vbNewLine _
                & Me.Applicant_MemoEdit.Text & vbNewLine _
                & "unter der LC Nr." & LC_Nr_TextEdit.Text & " am " & Me.IssuingDate_TextEdit.Text & " erröfnet." & vbNewLine & vbNewLine _
                & "Akkreditivbetrag: " & Me.LcCurrency_TextEdit.Text & "  " & Me.LcAmount_Textedit.Text & vbNewLine _
                & "Verfallsdatum / Verfallsort: " & Me.DateOfExpiry_DateEdit.Text & "  " & Me.PlaceOfExpiry_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT710_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            Dim ErstellungsDatum As String = d.ToString("yyyyMMdd")
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing 'Message Type
            Dim M13 As String = Nothing 'BIC Advising Bank
            Dim M14 As String = Nothing 'BIC Name Asdvising Bank
            Dim M04 As String = Nothing 'Reference Advising Bank
            Dim M12 As String = Nothing 'Contact Details Advising Bank
            Dim M91 As String = Nothing 'LC Confirmation Sign
            Dim M40 As String = Nothing 'Informations for LC Confirmation
            Dim M41 As String = Nothing 'Info Text from Advising Bank
            Dim M42 As String = Nothing 'Charges Advising Bank
            Dim M15 As String = Nothing 'BIC Issuing Bank
            Dim M16 As String = Nothing 'BIC Name Issuing Bank
            Dim M17 As String = Nothing 'BIC Third Bank
            Dim M18 As String = Nothing 'BIC Name Third Bank
            Dim M06 As String = Nothing 'Reference Field 20 Third bank
            Dim M02 As String = Nothing 'LC Reference
            Dim M01 As String = Nothing ' Customer Reference
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            'Get Issuing BIC from File
            Dim TextLines52A() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines52A
                If line.StartsWith(":52A:") = True Then
                    Me.IssuingBIC_TextEdit.Text = Microsoft.VisualBasic.Mid(line.Trim, 6, 11)
                End If
            Next
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M12 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M41 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & ErstellungsDatum & DateTime.Now.ToString("HHMM")
            MT = ":MT:" & MsgType_lbl.Text
            M13 = ":M13:" & OUR_BIC
            M14 = ":M14:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M04 = ":M04:" & Me.OurReference_TextEdit.Text
            M12 = ":M12:" & M12
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M91 = ":M91:2"
            Else
                M91 = ":M91:1"
            End If
            M41 = M41.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M41 = M41.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M41 = ":M41:" & M41
            M42 = ":M42:" & CustomerLcAdviceCharges_DTAEA_M8
            M15 = ":M15:" & Me.IssuingBIC_TextEdit.Text
            M16 = ":M16:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M02 = ":M02:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M17 = ":M17:" & Me.SenderBIC_lbl.Text
            M18 = ":M18:" & Me.SenderBicName_lbl.Text & vbNewLine & Me.SenderBicBranch_lbl.Text
            'Get Reference Field 20
            Dim TextLinesRef20() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLinesRef20
                If line.StartsWith(":20:") = True Then
                    M06 = "M06:" & Microsoft.VisualBasic.Mid(line.Trim, 5, 16)
                End If
            Next
            'M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            'M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M01 = ":M01:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"


            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M13)
            Writer.WriteLine(M14)
            Writer.WriteLine(M04)
            Writer.WriteLine(M12)
            Writer.WriteLine(M91)
            Writer.WriteLine(M41)
            If CustomerLcAdviceCharges_DTAEA_M8 <> "" Then
                Writer.WriteLine(M42)
            End If
            Writer.WriteLine(M15)
            Writer.WriteLine(M16)
            Writer.WriteLine(M02)
            Writer.WriteLine(M17)
            Writer.WriteLine(M18)
            Writer.WriteLine(M06)
            Writer.WriteLine(M01)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M01)
            End If
            Writer.WriteLine(Mid(SwiftNachricht, 8)) 'without Field 27-Sequence of Total
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Avisierung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Das Akkreditiv wurde von der Bank:" & vbNewLine _
                & ISSOUING_BANK_NAME & vbNewLine _
                & ISSOUING_BANK_CITY & vbNewLine _
                & ISSOUING_BANK_COUNTRY & vbNewLine _
                & "Im auftrag von " & vbNewLine _
                & Me.Applicant_MemoEdit.Text & vbNewLine _
                & "unter der LC Nr." & LC_Nr_TextEdit.Text & " am " & Me.IssuingDate_TextEdit.Text & " erröfnet." & vbNewLine & vbNewLine _
                & "Akkreditivbetrag: " & Me.LcCurrency_TextEdit.Text & "  " & Me.LcAmount_Textedit.Text & vbNewLine _
                & "Verfallsdatum / Verfallsort: " & Me.DateOfExpiry_DateEdit.Text & "  " & Me.PlaceOfExpiry_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT720_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            Dim ErstellungsDatum As String = d.ToString("yyyyMMdd")
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing 'Message Type
            Dim M13 As String = Nothing 'BIC Advising Bank
            Dim M14 As String = Nothing 'BIC Name Asdvising Bank
            Dim M04 As String = Nothing 'Reference Advising Bank
            Dim M12 As String = Nothing 'Contact Details Advising Bank
            Dim M91 As String = Nothing 'LC Confirmation Sign
            Dim M40 As String = Nothing 'Informations for LC Confirmation
            Dim M41 As String = Nothing 'Info Text from Advising Bank
            Dim M42 As String = Nothing 'Charges Advising Bank
            Dim M15 As String = Nothing 'BIC Issuing Bank
            Dim M16 As String = Nothing 'BIC Name Issuing Bank
            Dim M19 As String = Nothing 'BIC Third Bank
            Dim M20 As String = Nothing 'BIC Name Third Bank
            Dim M07 As String = Nothing 'Reference Field 20 Third bank
            Dim M02 As String = Nothing 'LC Reference
            Dim M01 As String = Nothing ' Customer Reference
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            'Get Issuing BIC from File
            Dim TextLines52A() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines52A
                If line.StartsWith(":52A:") = True Then
                    Me.IssuingBIC_TextEdit.Text = Microsoft.VisualBasic.Mid(line.Trim, 6, 11)
                End If
            Next
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M12 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M41 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & ErstellungsDatum & DateTime.Now.ToString("HHMM")
            MT = ":MT:" & MsgType_lbl.Text
            M13 = ":M13:" & OUR_BIC
            M14 = ":M14:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M04 = ":M04:" & Me.OurReference_TextEdit.Text
            M12 = ":M12:" & M12
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M91 = ":M91:2"
            Else
                M91 = ":M91:1"
            End If
            M41 = M41.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M41 = M41.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M41 = ":M41:" & M41
            M42 = ":M42:" & CustomerLcAdviceCharges_DTAEA_M8
            M15 = ":M15:" & Me.IssuingBIC_TextEdit.Text
            M16 = ":M16:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M02 = ":M02:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M19 = ":M19:" & Me.SenderBIC_lbl.Text
            M20 = ":M20:" & Me.SenderBicName_lbl.Text & vbNewLine & Me.SenderBicBranch_lbl.Text
            'Get Reference Field 20
            Dim TempString As String = Nothing
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":20:") = True Then
                    M07 = "M07:" & Microsoft.VisualBasic.Mid(line.Trim, 5, 16)
                End If
            Next
            'M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            'M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M01 = ":M01:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"


            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M13)
            Writer.WriteLine(M14)
            Writer.WriteLine(M04)
            Writer.WriteLine(M12)
            Writer.WriteLine(M91)
            Writer.WriteLine(M41)
            If CustomerLcAdviceCharges_DTAEA_M8 <> "" Then
                Writer.WriteLine(M42)
            End If
            Writer.WriteLine(M15)
            Writer.WriteLine(M16)
            Writer.WriteLine(M02)
            Writer.WriteLine(M19)
            Writer.WriteLine(M20)
            Writer.WriteLine(M07)
            Writer.WriteLine(M01)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M01)
            End If
            Writer.WriteLine(Mid(SwiftNachricht, 8)) 'without Field 27-Sequence of Total
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Avisierung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Das Akkreditiv wurde von der Bank:" & vbNewLine _
                & ISSOUING_BANK_NAME & vbNewLine _
                & ISSOUING_BANK_CITY & vbNewLine _
                & ISSOUING_BANK_COUNTRY & vbNewLine _
                & "Im auftrag von " & vbNewLine _
                & Me.Applicant_MemoEdit.Text & vbNewLine _
                & "unter der LC Nr." & LC_Nr_TextEdit.Text & " am " & Me.IssuingDate_TextEdit.Text & " erröfnet." & vbNewLine & vbNewLine _
                & "Akkreditivbetrag: " & Me.LcCurrency_TextEdit.Text & "  " & Me.LcAmount_Textedit.Text & vbNewLine _
                & "Verfallsdatum / Verfallsort: " & Me.DateOfExpiry_DateEdit.Text & "  " & Me.PlaceOfExpiry_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT700_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M7 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & MsgType_lbl.Text
            M1 = ":M1:" & OUR_BIC
            M2 = ":M2:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M4 = ":M4:" & M4
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M5 = ":M5:2"
            Else
                M5 = ":M5:1"
            End If
            M7 = M7.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M7 = M7.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M7 = ":M7:" & M7
            M8 = ":M8:" & CustomerLcAdviceCharges_DTAEA_M8
            M9 = ":M9:" & Me.IssuingBIC_TextEdit.Text
            M10 = ":M10:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"
            Z3 = ":Z3:000"
            Z4 = ":Z4:000"
            Dim LcAmount As Double = Me.LcAmount_Textedit.Text
            Z5 = ":Z5:" & String.Format("{0:000000000000000}", LcAmount)

            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M1)
            Writer.WriteLine(M2)
            Writer.WriteLine(M3)
            Writer.WriteLine(M4)
            Writer.WriteLine(M5)
            Writer.WriteLine(M7)
            If CustomerLcAdviceCharges_DTAEA_M8 <> "" Then
                Writer.WriteLine(M8)
            End If
            Writer.WriteLine(M9)
            Writer.WriteLine(M10)
            Writer.WriteLine(M11)
            Writer.WriteLine(M12)
            Writer.WriteLine(M19)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Avisierung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Das Akkreditiv wurde von der Bank:" & vbNewLine _
                & ISSOUING_BANK_NAME & vbNewLine _
                & ISSOUING_BANK_CITY & vbNewLine _
                & ISSOUING_BANK_COUNTRY & vbNewLine _
                & "Im auftrag von " & vbNewLine _
                & Me.Applicant_MemoEdit.Text & vbNewLine _
                & "unter der LC Nr." & LC_Nr_TextEdit.Text & " am " & Me.IssuingDate_TextEdit.Text & " erröfnet." & vbNewLine & vbNewLine _
                & "Akkreditivbetrag: " & Me.LcCurrency_TextEdit.Text & "  " & Me.LcAmount_Textedit.Text & vbNewLine _
                & "Verfallsdatum / Verfallsort: " & Me.DateOfExpiry_DateEdit.Text & "  " & Me.PlaceOfExpiry_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub

    Private Sub FAX_MT700_ADVICE()
        Try

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")

            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If



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


            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                If dt.Rows.Item(0).Item("BRANCH INFORMATION") IsNot DBNull.Value Then
                    ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                End If
                If dt.Rows.Item(0).Item("CITY HEADING") IsNot DBNull.Value Then
                    ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                End If
                If dt.Rows.Item(0).Item("COUNTRY NAME") IsNot DBNull.Value Then
                    ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
                End If
            Else
                    MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If



            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")



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



            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next



            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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



            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Normal"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim AdviceChargesCurPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceChargesCurrency").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesCurPos, Me.AdviceChargesCur_GridLookUpEdit.Text)
            Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub FAX_MT700_ADVICE_VARIATION1()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

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

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                If dt.Rows.Item(0).Item("BRANCH INFORMATION") IsNot DBNull.Value Then
                    ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                End If
                If dt.Rows.Item(0).Item("CITY HEADING") IsNot DBNull.Value Then
                    ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                End If
                If dt.Rows.Item(0).Item("COUNTRY NAME") IsNot DBNull.Value Then
                    ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
                End If
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

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


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX_VARIATION1" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Variation 1"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim AdviceChargesCurPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceChargesCurrency").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesCurPos, Me.AdviceChargesCur_GridLookUpEdit.Text)
            Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            Dim AdviceCharges As Double = Me.AdviceCharges_SpinEdit.Text
            Dim TotalAdviceCharges As Double = AdviceCharges + 30
            Dim TotalAdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TotalAdviceCharges").Range.End
            c.RichEditControl1.Document.InsertText(TotalAdviceChargesPos, FormatNumber(TotalAdviceCharges, , TriState.UseDefault))
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub FAX_MT700_ADVICE_VARIATION2()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.SwiftMessageFormated_RichTextBox.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

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

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                If dt.Rows.Item(0).Item("BRANCH INFORMATION") IsNot DBNull.Value Then
                    ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                End If
                If dt.Rows.Item(0).Item("CITY HEADING") IsNot DBNull.Value Then
                    ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                End If
                If dt.Rows.Item(0).Item("COUNTRY NAME") IsNot DBNull.Value Then
                    ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
                End If
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

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


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_FAX_VARIATION2" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Form - Variation 2"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PlaceOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            'Dim AdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdviceCharges").Range.End
            'c.RichEditControl1.Document.InsertText(AdviceChargesPos, Me.AdviceCharges_SpinEdit.Text)
            'Dim AdviceCharges As Double = Me.AdviceCharges_SpinEdit.Text
            'Dim TotalAdviceCharges As Double = AdviceCharges + 30
            'Dim TotalAdviceChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TotalAdviceCharges").Range.End
            'c.RichEditControl1.Document.InsertText(TotalAdviceChargesPos, TotalAdviceCharges)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub

    Private Sub ANSCHREIBEN_LC_MT700_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

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

            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                If dt.Rows.Item(0).Item("BRANCH INFORMATION") IsNot DBNull.Value Then
                    ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                End If
                If dt.Rows.Item(0).Item("CITY HEADING") IsNot DBNull.Value Then
                    ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                End If
                If dt.Rows.Item(0).Item("COUNTRY NAME") IsNot DBNull.Value Then
                    ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
                End If
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

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


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ADVICE_ANSCHREIBEN_KUNDE" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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


            SplashScreenManager.Default.SetWaitFormCaption("Create Cover Letter Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Cover Letter Advice Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Address").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Address_2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_ZipCode").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_City").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_ExpiryDate").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_ExpiryPlace").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)
            'Confirmation
            Dim Not_Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Not_Confirmed").Range.End
            Dim Confirmed_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Confirmed").Range.End
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "X")
                c.RichEditControl1.Document.InsertText(Confirmed_Pos, "")
            Else
                c.RichEditControl1.Document.InsertText(Not_Confirmed_Pos, "")
                c.RichEditControl1.Document.InsertText(Confirmed_Pos, "X")
            End If
            SplashScreenManager.CloseForm(False)


            Dim message, title, defaultValue As String
            Dim myValue As Object
            message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
                & "Charges for Applicant   = 1" & vbNewLine _
                & "Charges for Beneficiary = 2" & vbNewLine _
                & "Charges Shared          = 0"

            title = "ADVICE COMMISSION SHARING"   ' Set title.
            defaultValue = "1"   ' Set default value.
            ' Display message, title, and default value.
            myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            If myValue = "1" Then
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            ElseIf myValue = "2" Then
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            ElseIf myValue = "0" Then
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            Else
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            End If


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub LC_COVER_SHEET()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Cover Sheet creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing


            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "WITHOUT CONFIRMATION"
            Else
                OurConfirmation = "CONFIRMED"
            End If


            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_COVER_SHEET" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next


            'Get Latest Date of Shipment
            'Dim TempString As String = Nothing
            Dim LatestDateOfShipment As Date
            'Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            'For Each line As String In TextLines
            '    If line.StartsWith(":44C:") = True Then
            '        TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
            '        LatestDateOfShipment = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))

            '    End If
            'Next

            'Latest Date of Shipment
            If IsDate(Me.LatestDateOfShipment_DateEdit.Text) = True Then
                LatestDateOfShipment = Me.LatestDateOfShipment_DateEdit.Text
            End If


            SplashScreenManager.Default.SetWaitFormCaption("Create LC Cover Sheet")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Cover Sheet"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, Me.Beneficiary_MemoEdit.Text)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim IssuingDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingDate").Range.End
            c.RichEditControl1.Document.InsertText(IssuingDatePos, Me.IssuingDate_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            Dim LcCurrencyRemPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency_Rem").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyRemPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountRemPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount_Rem").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountRemPos, Me.LcAmount_Textedit.Text)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfExpiry").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim OurConfirmationPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Confirmation").Range.End
            c.RichEditControl1.Document.InsertText(OurConfirmationPos, OurConfirmation)
            Dim LatestDateOfShipmentPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ShipmentDatePeriod").Range.End
            c.RichEditControl1.Document.InsertText(LatestDateOfShipmentPos, LatestDateOfShipment)
            SplashScreenManager.CloseForm(False)


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

#Region "ADVICE STATUS"
    Private Sub AdviceToCustomer_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.Click
        Me.EXPORT_LC_CUSTOMERSTableAdapter.Fill(Me.LcDataset.EXPORT_LC_CUSTOMERS)

    End Sub

    Private Sub AdviceToCustomer_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.EditValueChanged
        If Me.AdviceToCustomer_GridLookUpEdit.Focused = True Then
            If Me.XtraTabControl2.Visible = True AndAlso DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).EditValue IsNot Nothing Then
                MsgBox(Convert.ToString(DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).EditValue))
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim Customer_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.RelatedCustomerID_lbl.Text = Customer_Row("ID").ToString
                RelatedCustomerID = Customer_Row("ID").ToString
            End If
        End If


    End Sub

    Private Sub AdviceToCustomer_GridLookUpEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEdit.LostFocus
        Me.SaveChanges_btn.PerformClick()

        'Me.EXPORT_LC_MT700BindingSource.EndEdit()
        'Me.EXPORT_LC_MT700TableAdapter.Update(Me.LcDataset.EXPORT_LC_MT700)
    End Sub

    Private Sub LcCustomers_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub

    Private Sub LcCustomers_GridView_Click(sender As Object, e As EventArgs)
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub


    Private Sub LcCustomers_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEditView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdviceToCustomer_GridLookUpEditView.CellValueChanged
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEditView_Click(sender As Object, e As EventArgs) Handles AdviceToCustomer_GridLookUpEditView.Click
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub

    Private Sub AdviceToCustomer_GridLookUpEditView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles AdviceToCustomer_GridLookUpEditView.RowClick
        'Dim view As GridView = DirectCast(sender, GridView)
        'Me.RelatedCustomerID_lbl.Text = view.GetFocusedRowCellValue("ID").ToString
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
    End Sub

    Private Sub AdvicedStatus_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles AdvicedStatus_CheckEdit.CheckedChanged
        If Me.AdvicedStatus_CheckEdit.Focused = True Then
            If Me.AdviceToCustomer_GridLookUpEdit.Text <> "" AndAlso Me.OurConfirmation_ComboEdit.Text <> "" Then
                If Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Checked Then
                    Dim d As Date = Today
                    Me.AdvicedOn_DateEdit.Text = d
                    ADVICE_STATUS_DISABLED()
                ElseIf Me.AdvicedStatus_CheckEdit.CheckState = CheckState.Unchecked Then
                    Me.AdvicedOn_DateEdit.Text = Nothing
                    ADVICE_STATUS_ENABLED()
                End If
                SAVE_ALL_CHANGES()
            Else
                MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.EXPORT_LC_MT700BindingSource.CancelEdit()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ADVICE_STATUS_ENABLED()
        Me.CustomersReference_TextEdit.ReadOnly = False
        Me.AdviceToCustomer_GridLookUpEdit.Properties.ReadOnly = False
        Me.OurConfirmation_ComboEdit.Properties.ReadOnly = False
        Me.AdviceCharges_SpinEdit.ReadOnly = False
        Me.AdviceChargesCur_GridLookUpEdit.Properties.ReadOnly = False
    End Sub

    Private Sub ADVICE_STATUS_DISABLED()
        Me.CustomersReference_TextEdit.ReadOnly = True
        Me.AdviceToCustomer_GridLookUpEdit.Properties.ReadOnly = True
        Me.OurConfirmation_ComboEdit.Properties.ReadOnly = True
        Me.AdviceCharges_SpinEdit.ReadOnly = True
        Me.AdviceChargesCur_GridLookUpEdit.Properties.ReadOnly = True
    End Sub

#End Region




    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        SAVE_ALL_CHANGES()

    End Sub



    Private Sub RelatedCustomerID_lbl_TextChanged(sender As Object, e As EventArgs) Handles RelatedCustomerID_lbl.TextChanged
        RelatedCustomerID = Me.RelatedCustomerID_lbl.Text

        'SAVE_ALL_CHANGES()
    End Sub

    Private Sub OurConfirmation_ComboEdit_SelectedValueChanged(sender As Object, e As EventArgs) Handles OurConfirmation_ComboEdit.SelectedValueChanged
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub AdviceCharges_SpinEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceCharges_SpinEdit.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    'Private Sub AdviceToCustomer_GridLookUpEdit_LostFocus(sender As Object, e As EventArgs)
    '    SAVE_ALL_CHANGES()
    'End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click
        'Dim s As String = Me.RichTextBox1.Text
        'Me.RichTextBox1.Clear()
        'Me.RichTextBox1.Text = s
        'ChangeTextcolor(":", Color.DarkCyan, Me.RichTextBox1, 0)
        ApplyCustomFormatting(Me.RichEditControl1.Document)
    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Me.LayoutControl5.Visible = False
        ApplyCustomFormatting(Me.RichEditControl1.Document)
        'Dim s As String = Me.RichTextBox1.Text
        'Me.RichTextBox1.Clear()
        'Me.RichTextBox1.Text = s
        'ChangeTextcolor(":", Color.DarkCyan, Me.RichTextBox1, 0)
    End Sub

    Private Sub ShowAllRelatedMsg_btn_Click(sender As Object, e As EventArgs) Handles ShowAllRelatedMsg_btn.Click
        Me.LayoutControl5.Visible = True
    End Sub



#Region "LC AMENDMENT ADVICES"
    Private Sub LcAmendmentAdviceDTAEA_New_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceDTAEA_New_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File for LC Amendment - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            cmd.Connection.Open()
            Dim CheckResult As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA Amendment File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If Me.MsgType_TextEdit.Text = "707" Then
                    DTAEA_MT707_AMENDMENT_NEW_ADVICE()
                ElseIf Me.MsgType_TextEdit.Text = "799" Then
                    DTAEA_MT799_AMENDMENT_NEW_ADVICE()
                End If
            End If


        End If
    End Sub

    Private Sub LcAmendmentAdviceDTAEA_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceDTAEA_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create DTAEA File for LC Amendment - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [LcAdviceEmail] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [LcAdviceEmail] is not NULL"
            cmd.Connection.Open()
            Dim CheckResult As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If CheckResult = "" Then
                MessageBox.Show("Unable to create DTAEA Amendment File - No LC Advice Email receiver has being indicated for this Customer" & vbNewLine & "Please indicate LC Advice email for this Customer!", "LC ADVICE EMAIL IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If Me.MsgType_TextEdit.Text = "707" Then
                    DTAEA_MT707_AMENDMENT_ADVICE()
                ElseIf Me.MsgType_TextEdit.Text = "799" Then
                    DTAEA_MT799_AMENDMENT_ADVICE()
                End If
            End If


        End If
    End Sub

    Private Sub LcAmendmentAdviceFAX_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceFAX_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Amendment Advice Cover Letter Form - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            cmd.CommandText = "SELECT [CustomerFax] FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & " and [CustomerFax] is not NULL "
            cmd.Connection.Open()
            Dim CheckResult As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If CheckResult = "" Then
                MessageBox.Show("Unable to create LC Cover Letter Advice Form - No Fax receiver has being indicated for this Customer" & vbNewLine & "Please indicate the Fax Nr. for this Customer!", "FAX NR. IS MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                LC_AMENDMENT_ADVICE_FAX()
            End If
        End If
    End Sub

    Private Sub LcAmendmentAdviceCOVER_LETTER_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LcAmendmentAdviceCOVER_LETTER_BarButtonItem.ItemClick
        SAVE_ALL_CHANGES()
        'Checkings
        If Me.AdviceToCustomer_GridLookUpEdit.Text = "" OrElse Me.OurConfirmation_ComboEdit.Text = "" Then
            MessageBox.Show("Please input Advising Customers Name and/or the Confirmation Instruction!", "ADVISING DETAILS ARE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
            MessageBox.Show("Unable to create LC Amendment Advice Cover Letter Form - LC Amendment allready adviced!" & vbNewLine & "Please uncheck the Advice Status in order to create the LC Amendment Advice again!", "LC AMENDMENT ALLREADY ADVICED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            LC_AMENDMENT_ADVICE_COVER_LETTER()
        End If
    End Sub
#End Region

    Private Sub DTAEA_MT707_AMENDMENT_NEW_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            Dim ErstellungsDatum As String = d.ToString("yyyyMMdd")
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing 'Message Type
            Dim M13 As String = Nothing 'BIC Advising Bank
            Dim M14 As String = Nothing 'BIC Name Asdvising Bank
            Dim M04 As String = Nothing 'Reference Advising Bank
            Dim M12 As String = Nothing 'Contact Details Advising Bank
            Dim M91 As String = Nothing 'LC Confirmation Sign
            Dim M40 As String = Nothing 'Informations for LC Confirmation
            Dim M41 As String = Nothing 'Info Text from Advising Bank
            Dim M42 As String = Nothing 'Charges Advising Bank
            Dim M15 As String = Nothing 'BIC Issuing Bank
            Dim M16 As String = Nothing 'BIC Name Issuing Bank
            Dim M17 As String = Nothing 'BIC Sending Bank
            Dim M18 As String = Nothing 'BIC Name Sending Bank
            Dim M06 As String = Nothing 'Reference Sending Bank
            Dim M02 As String = Nothing 'LC Reference
            Dim M01 As String = Nothing ' Customer Reference
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            Dim CustomerLcAdviceCharges_DTAEA_M8 As String = Nothing
            'Get Issuing Bank details
            'Check if Issuing Bank BIC is BIC8
            Dim ISSUING_BIC As String = Nothing
            Dim ISSOUING_BANK_NAME As String = Nothing
            Dim ISSOUING_BANK_BRANCH As String = Nothing
            Dim ISSOUING_BANK_CITY As String = Nothing
            Dim ISSOUING_BANK_COUNTRY As String = Nothing
            If Len(Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)) = 8 Then
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "XXX"
            Else
                ISSUING_BIC = Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11)
            End If
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & ISSUING_BIC & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ISSOUING_BANK_NAME = dt.Rows.Item(0).Item("INSTITUTION NAME")
                ISSOUING_BANK_BRANCH = dt.Rows.Item(0).Item("BRANCH INFORMATION")
                ISSOUING_BANK_CITY = dt.Rows.Item(0).Item("CITY HEADING")
                ISSOUING_BANK_COUNTRY = dt.Rows.Item(0).Item("COUNTRY NAME")
            Else
                MessageBox.Show("Unable to identify Issuing Bank BIC: " & ISSUING_BIC, "BIC not in the BIC Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M12 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M41 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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
                If dt.Rows.Item(i).Item("LcAdviceChargesDTAEA") IsNot DBNull.Value Then
                    CustomerLcAdviceCharges_DTAEA_M8 = dt.Rows.Item(i).Item("LcAdviceChargesDTAEA")
                End If
            Next

            'Get Swift Message Text special for Amendment Message
            Dim SwiftMessageAmendmentText As String = Nothing
            Me.QueryText = "DECLARE @SWIFTTEXT nvarchar(max) SET @SWIFTTEXT=(SELECT Swift_Message FROM [EXPORT_LC_MT700_RM] where [ID]=" & ID_RelatedMessage_lbl.Text & ")  SELECT LTRIM(RTRIM(SUBSTRING(@SWIFTTEXT,CHARINDEX(':52',@SWIFTTEXT)+0,LEN(@SWIFTTEXT)))) as 'AmendmentText'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SwiftMessageAmendmentText = dt.Rows.Item(0).Item("AmendmentText")
            End If


            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & ErstellungsDatum & DateTime.Now.ToString("HHMM")
            MT = ":MT:" & MsgType_TextEdit.Text
            M13 = ":M13:" & OUR_BIC
            M14 = ":M14:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M04 = ":M04:" & Me.OurReference_TextEdit.Text
            M12 = ":M12:" & M12
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M91 = ":M91:2"
            Else
                M91 = ":M91:1"
            End If
            M41 = M41.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M41 = M41.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M41 = ":M41:" & M41
            'M42 = ":M42:" & CustomerLcAdviceCharges_DTAEA_M8
            M15 = ":M15:" & Me.IssuingBIC_TextEdit.Text
            M16 = ":M16:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M02 = ":M02:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M17 = ":M17:" & Me.SenderBIC_TextEdit.Text
            M18 = ":M18:" & Me.SenderBicName_TextEdit.Text & vbNewLine & Me.SenderBranchName_textedit.Text
            'Get Reference Field 20
            Dim TextLinesRef20() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLinesRef20
                If line.StartsWith(":20:") = True Then
                    M06 = ":M06:" & Microsoft.VisualBasic.Mid(line.Trim, 5, 16)
                End If
            Next

            'M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            'M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M01 = ":M01:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            Z1 = ":Z1:Z"
            Z2 = ":Z2:001"



            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to

            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M13)
            Writer.WriteLine(M14)
            Writer.WriteLine(M04)
            Writer.WriteLine(M12)
            Writer.WriteLine(M91)
            Writer.WriteLine(M40)
            Writer.WriteLine(M41)
            Writer.WriteLine(M15)
            Writer.WriteLine(M16)
            Writer.WriteLine(M02)
            Writer.WriteLine(M17)
            Writer.WriteLine(M18)
            Writer.WriteLine(M06)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M01)
            End If
            Writer.WriteLine(SwiftMessageAmendmentText)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Akkreditivänderung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT707_AMENDMENT_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M21 As String = Nothing
            Dim M22 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M7 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & Me.MsgType_TextEdit.Text
            M1 = ":M1:" & OUR_BIC
            M2 = ":M2:" & OUR_BANKNAME & vbNewLine & OUR_BANK_BRANCH & vbNewLine & OUR_BANKSTRASSE & vbNewLine & OUR_BANKPLZ_ORT
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M4 = ":M4:" & M4
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                M5 = ":M5:2"
            Else
                M5 = ":M5:1"
            End If
            M7 = ":M7:" & M7.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M7 = ":M7:" & M7.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M9 = ":M9:" & Me.IssuingBIC_TextEdit.Text
            M10 = ":M10:" & ISSOUING_BANK_NAME & vbNewLine & ISSOUING_BANK_CITY & vbNewLine & ISSOUING_BANK_COUNTRY
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            Dim IssouingDate As Date = Me.IssuingDate_TextEdit.Text
            M12 = ":M12:" & IssouingDate.ToString("yyyyMMdd")
            M19 = ":M19:" & d.ToString("yyyyMMdd")
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            '
            ' MT707 - Zeilen auslessen 
            Dim TempString As String = Nothing
            Dim TempDate As Date
            Dim DateOfAmendment As String = Nothing
            Dim NewDateOfExpiry As String = Nothing
            Dim NrOfAmendment As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":30:") = True Then
                    TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDate = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))
                    DateOfAmendment = TempDate.ToString("yyyyMMdd")
                    M21 = ":M21:" & DateOfAmendment
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                    M22 = ":M22:" & NrOfAmendment
                End If
                If line.StartsWith(":31E:") = True Then
                    TempString = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDate = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDate
                    NewDateOfExpiry = TempDate.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 5, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempString = Microsoft.VisualBasic.Mid(line.Trim, 8, 15)
                    If TempString.Trim.EndsWith(",") = True Then
                        TempString = TempString.Replace(",", "")
                    End If
                    NewLcAmount = TempString
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
            Next


            Z1 = ":Z1:Z"
            Z2 = ":Z2:000"
            Z3 = ":Z3:001"
            Z4 = ":Z4:000"
            If NewLcAmount > 0 Then
                Z5 = ":Z5:" & String.Format("{0:000000000000000}", NewLcAmount)
            Else
                Z5 = ":Z5:" & String.Format("{0:000000000000000}", 707)
            End If


            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M1)
            Writer.WriteLine(M2)
            Writer.WriteLine(M3)
            Writer.WriteLine(M4)
            Writer.WriteLine(M5)
            Writer.WriteLine(M7)
            Writer.WriteLine(M9)
            Writer.WriteLine(M10)
            Writer.WriteLine(M11)
            Writer.WriteLine(M12)
            Writer.WriteLine(M19)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(M21)
            If IsNothing(M22) = False Then
                Writer.WriteLine(M22)
            End If
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Akkreditivänderung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT799_AMENDMENT_NEW_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            Dim ErstellungsDatum As String = d.ToString("yyyyMMdd")
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M04 As String = Nothing
            Dim M12 As String = Nothing
            Dim M02 As String = Nothing
            Dim M01 As String = Nothing
            Dim M41 As String = Nothing
            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M12 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M41 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next


            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & ErstellungsDatum & DateTime.Now.ToString("HHMM")
            MT = ":MT:" & Me.MsgType_TextEdit.Text
            M04 = ":M04:" & Me.OurReference_TextEdit.Text
            M12 = ":M12:" & M12
            M02 = ":M02:" & Me.LC_Nr_TextEdit.Text
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M01 = ":M01:" & Me.CustomersReference_TextEdit.Text
            End If
            M41 = M41.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M41 = M41.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M41 = ":M41:" & M41
            '
            SwiftNachricht = SwiftNachricht.Replace(":20:", "")
            SwiftNachricht = SwiftNachricht.Replace(":21:", "")
            SwiftNachricht = SwiftNachricht.Replace(":79:", "")
            SwiftNachricht = ":79:" & SwiftNachricht

            Z1 = ":Z1:Z"
            Z2 = ":Z2:000"




            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M04)
            Writer.WriteLine(M12)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M01)
            End If
            Writer.WriteLine(M41)
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Freiformat Nachricht unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub DTAEA_MT799_AMENDMENT_ADVICE()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the DTAEA File creation")
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select DTAEA Parameters
            Dim DTAEA_Directory As String = Nothing
            Dim A1 As String = ":A1:EAB"
            Dim A2 As String = Nothing
            Dim A3 As String = Nothing
            Dim A4 As String = Nothing
            Dim A5 As String = Nothing
            Dim Satzendekennung As String = "-"
            Dim MT As String = Nothing
            Dim M1 As String = Nothing
            Dim M2 As String = Nothing
            Dim M3 As String = Nothing
            Dim M4 As String = Nothing
            Dim M5 As String = Nothing
            Dim M6 As String = Nothing
            Dim M7 As String = Nothing
            Dim M8 As String = Nothing
            Dim M9 As String = Nothing
            Dim M10 As String = Nothing
            Dim M11 As String = Nothing
            Dim M12 As String = Nothing
            Dim M13 As String = Nothing
            Dim M14 As String = Nothing
            Dim M15 As String = Nothing
            Dim M16 As String = Nothing
            Dim M17 As String = Nothing
            Dim M18 As String = Nothing
            Dim M19 As String = Nothing
            Dim M20 As String = Nothing
            Dim M21 As String = Nothing
            Dim M22 As String = Nothing
            Dim M23 As String = Nothing
            Dim M24 As String = "Unverbindliche Kopie"
            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim Z1 As String = Nothing
            Dim Z2 As String = Nothing
            Dim Z3 As String = Nothing
            Dim Z4 As String = Nothing
            Dim Z5 As String = Nothing
            Dim DTAEA_Filename As String = Nothing
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
            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "DTAEA_FILE_DIRECTORY" Then
                    DTAEA_Directory = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next
            Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='LC_MT700_ADVICE_DTAEA'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M4" Then
                    M4 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
                If dt.Rows.Item(i).Item("SQL_Name_1") = "M7" Then
                    M23 = dt.Rows.Item(i).Item("SQL_Command_1")
                End If
            Next
            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            'Set Data in Fields
            A2 = ":A2:" & OUR_BIC
            A3 = ":A3:" & CustomerID
            A4 = ":A4:" & CustomerName & vbNewLine & CustomerNameAddress & vbNewLine & CustomerAddress & vbNewLine & CustomerZipCode & "  " & CustomerCity
            A5 = ":A5:" & IndustrieDatum & ":" & t.ToString("hhmm")
            MT = ":MT:" & Me.MsgType_TextEdit.Text
            M3 = ":M3:" & Me.OurReference_TextEdit.Text
            M11 = ":M11:" & Me.LC_Nr_TextEdit.Text
            If Me.CustomersReference_TextEdit.Text <> "" Then
                M20 = ":M20:" & Me.CustomersReference_TextEdit.Text
            End If
            M23 = M23.Replace("<BANK>", Trim(ISSOUING_BANK_NAME) & vbNewLine & Trim(ISSOUING_BANK_CITY) & vbNewLine & Trim(ISSOUING_BANK_COUNTRY))
            M23 = M23.Replace("<LC_REFERENCE>", Me.LC_Nr_TextEdit.Text)
            M23 = ":M23:" & M23
            '
            SwiftNachricht = SwiftNachricht.Replace(":20:", "")
            SwiftNachricht = SwiftNachricht.Replace(":21:", "")
            SwiftNachricht = SwiftNachricht.Replace(":79:", "")
            SwiftNachricht = ":79:" & SwiftNachricht

            Z1 = ":Z1:Z"
            Z2 = ":Z2:000"
            Z3 = ":Z3:000"
            Z4 = ":Z4:001"
            Z5 = ":Z5:" & String.Format("{0:000000000000000}", 799)



            Dim TestDTAEA_Filename As String = "Test-C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"
            DTAEA_Filename = "C" & IndustrieDatum & t.ToString("hhmm") & ".EAB"

            SplashScreenManager.Default.SetWaitFormCaption("Start DTAEA File creation")
            Dim Writer As System.IO.StreamWriter
            Writer = New System.IO.StreamWriter(DTAEA_Directory & TestDTAEA_Filename) '<-- Where to create/write to
            Writer.WriteLine(A1)
            Writer.WriteLine(A2)
            Writer.WriteLine(A3)
            Writer.WriteLine(A4)
            Writer.WriteLine(A5)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(MT)
            Writer.WriteLine(M3)
            Writer.WriteLine(M11)
            If Me.CustomersReference_TextEdit.Text <> "" Then
                Writer.WriteLine(M20)
            End If
            Writer.WriteLine(M23)
            Writer.WriteLine(SwiftNachricht)
            Writer.WriteLine(Satzendekennung)
            Writer.WriteLine(Z1)
            Writer.WriteLine(Z2)
            Writer.WriteLine(Z3)
            Writer.WriteLine(Z4)
            Writer.WriteLine(Z5)
            Writer.WriteLine(Satzendekennung)
            Writer.Close()

            Dim Testfilepath As String = DTAEA_Directory & TestDTAEA_Filename
            Dim OrigFilePath As String = DTAEA_Directory & DTAEA_Filename

            'Read test File, delete empty lines and create new File
            Dim sr As New System.IO.StreamReader(Testfilepath)
            Dim sw As New System.IO.StreamWriter(DTAEA_Directory + DTAEA_Filename, False)
            Dim s As String
            While sr.Peek >= 0
                s = sr.ReadLine
                If s.Trim <> "" Then
                    sw.WriteLine(s)
                End If
            End While
            sr.Close()
            sw.Close()
            'Delete the TestFile
            If File.Exists(Testfilepath) = True Then
                File.Delete(Testfilepath)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Start creating E-mail to customer")
            'Create Email
            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)
            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh
            OutlookMessage.To = CustomerLcAdviceEmail
            OutlookMessage.Subject = "Documentary Credit amendment advice DTAEA File: " & DTAEA_Filename
            OutlookMessage.Attachments.Add(OrigFilePath)
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
            OutlookMessage.Body = "Sehr geehrte Damen und Herren, " & vbNewLine _
                & "wir übermitteln Ihnen per EAB Datei die Akkreditivänderung unter Exportakkreditiv " & Me.OurReference_TextEdit.Text & vbNewLine & vbNewLine _
                & "Mit freundlichen Grüßen" & vbNewLine & vbNewLine _
                & OUR_BANKNAME & vbNewLine _
                & OUR_BANK_BRANCH & vbNewLine _
                & OUR_BANKSTRASSE & vbNewLine _
                & OUR_BANKPLZ_ORT


            OutlookMessage.Display()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub LC_AMENDMENT_ADVICE_COVER_LETTER()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Cover Letter Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

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

            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")

            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

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


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_AMENDMENT_ADVICE_COVER_LETTER" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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

            ' MT707 - Zeilen auslessen 
            Dim NrOfAmendment As String = Nothing

            Dim TempStringDateIssue As String = Nothing
            Dim TempDateIssue As Date

            Dim TempStringDateAmendment As String = Nothing
            Dim TempDateAmendment As Date
            Dim DateOfAmendment As String = Nothing

            Dim TempStringDateExpiry As String = Nothing
            Dim TempDateExpiry As Date
            Dim NewDateOfExpiry As String = Nothing

            Dim TempStringNewLcAmount As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0

            Dim TempStringLatestDateShipment As String = Nothing
            Dim TempLatestDateShipment As Date

            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":31C:") = True Then
                    TempStringDateIssue = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateIssue = DateSerial(Microsoft.VisualBasic.Left(TempStringDateIssue, 2), Microsoft.VisualBasic.Mid(TempStringDateIssue, 3, 2), Microsoft.VisualBasic.Right(TempStringDateIssue, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateIssue, TempDateIssue.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":30:") = True Then
                    TempStringDateAmendment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateAmendment = DateSerial(Microsoft.VisualBasic.Left(TempStringDateAmendment, 2), Microsoft.VisualBasic.Mid(TempStringDateAmendment, 3, 2), Microsoft.VisualBasic.Right(TempStringDateAmendment, 2))
                    DateOfAmendment = TempDateAmendment.ToString("yyyyMMdd")
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateAmendment, TempDateAmendment.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                End If
                If line.StartsWith(":31E:") = True Then
                    TempStringDateExpiry = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringDateExpiry, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDateExpiry
                    NewDateOfExpiry = TempDateExpiry.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateExpiry, TempDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":31D:") = True Then
                    TempStringDateExpiry = Microsoft.VisualBasic.Mid(line.Trim, 6, 6)
                    TempDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringDateExpiry, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDateExpiry
                    NewDateOfExpiry = TempDateExpiry.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateExpiry, TempDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 6, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempStringNewLcAmount = Microsoft.VisualBasic.Mid(line.Trim, 9, 15)
                    If TempStringNewLcAmount.Trim.EndsWith(",") = True Then
                        TempStringNewLcAmount = TempStringNewLcAmount.Replace(",", "")
                    End If
                    NewLcAmount = TempStringNewLcAmount
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":44C:") = True Then
                    TempStringLatestDateShipment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempLatestDateShipment = DateSerial(Microsoft.VisualBasic.Left(TempStringLatestDateShipment, 2), Microsoft.VisualBasic.Mid(TempStringLatestDateShipment, 3, 2), Microsoft.VisualBasic.Right(TempStringLatestDateShipment, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringLatestDateShipment, TempLatestDateShipment.ToString("dd.MM.yyyy"))
                End If
            Next

            'Reformat SWIFT Message
            SwiftNachricht = SwiftNachricht.Replace(":27:", ":27:Sequence of Total" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":20:", ":20:Sender's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":21:", ":21:Receiver's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23:", ":23:Issuing Bank's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52A:", ":52A:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52D:", ":52D:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":50B:", ":50B:Non-Bank Issuer" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31C:", ":31C:Date of Issue" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":30:", ":30:Date of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":26E:", ":26E:Number of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":22A:", ":22A:Purpose of Message" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23S:", ":23S:Cancellation Request" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":40A:", ":40A:Form of Documentary Credit" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":40E:", ":40E:Applicable Rules" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":50:", ":50:Changed Applicant Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":59:", ":59:Beneficiary" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31D:", ":31D:Date and Place of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31E:", ":31E:New Date of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":32B:", ":32B:Increase of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":33B:", ":33B:Decrease of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":34B:", ":34B:New Documentary Credit Amount After Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39A:", ":39A:Percentage Credit Amount Tolerance" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39B:", ":39B:Maximum Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39C:", ":39C:Additional Amounts Covered" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":41A:", ":41A:Available With ... By ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":41D:", ":41D:Available With ... By ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42C:", ":42C:Drafts at ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42A:", ":42A:Drawee" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42D:", ":42D:Drawee" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42M:", ":42M:Mixed Payment Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42P:", ":42P:Negotiation/Deferred Payment Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":43P:", ":43P:Partial Shipments" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":43T:", ":43T:Transhipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44A:", ":44A:Place of Taking in Charge/Dispatch from .../Place of Receipt" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44E:", ":44E:Port of Loading/Airport of Departure" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44F:", ":44F:Port of Discharge/Airport of Destination" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44B:", ":44B:Place of Final Destination/For Transportation to .../Place of Delivery" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44C:", ":44C:Latest Date of Shipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44D:", ":44D:Shipment Period" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":45B:", ":45B:Description of Goods and/or Services" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":46B:", ":46B:Documents Required" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":47B:", ":47B:Additional Conditions" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49M:", ":49M:Special Payment Conditions for Beneficiary" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49N:", ":49N:Special Payment Conditions for Receiving Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":71D:", ":71D:Charges" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":71N:", ":71N:Amendment Charge Payable By" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":48:", ":48:Period for Presentation in Days" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49:", ":49:Confirmation Instructions" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":58A:", ":58A:Requested Confirmation Party" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":58D:", ":58D:Requested Confirmation Party" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":53A:", ":53A:Reimbursing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":53D:", ":53D:Reimbursing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":78:", ":78:Instructions to the Paying/Accepting/Negotiating Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":79:", ":79:Narrative" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57A:", ":57A:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57B:", ":57B:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57D:", ":57D:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72:", ":72:Sender to Receiver Information" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72Z:", ":72Z:Sender to Receiver Information" & vbNewLine)
            '


            SplashScreenManager.Default.SetWaitFormCaption("Create Cover Letter Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Amendment Advice Cover Letter Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryAddresse1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerNameAddress)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryAddresse2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryZipCode").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("BeneficiaryCity").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim IssuingBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("IssuingBank").Range.End
            c.RichEditControl1.Document.InsertText(IssuingBankPos, ISSOUING_BANK_NAME.Trim & " , " & ISSOUING_BANK_CITY.Trim & " , " & ISSOUING_BANK_COUNTRY.Trim)
            Dim ApplicantPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Applicant").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantPos, Me.Applicant_MemoEdit.Text)
            Dim LcNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Nr").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Currency").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Amount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, Me.LcAmount_Textedit.Text)
            'Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            'c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim AmendmentDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DateOfAmendment").Range.End
            If TempDateAmendment > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(AmendmentDatePos, TempDateAmendment)
            Else
                c.RichEditControl1.Document.InsertText(AmendmentDatePos, Nothing)
            End If

            Dim AmendmentNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NrOfAmendment").Range.End
            c.RichEditControl1.Document.InsertText(AmendmentNrPos, NrOfAmendment)
            Dim NewExpiryDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewDateOfExpiry").Range.End
            If TempDateExpiry > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(NewExpiryDatePos, TempDateExpiry)
            Else
                c.RichEditControl1.Document.InsertText(NewExpiryDatePos, Nothing)
            End If

            Dim NewShipmentDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLatestDateOfShipment").Range.End
            If TempLatestDateShipment > DateSerial(1800, 1, 1) Then
                c.RichEditControl1.Document.InsertText(NewShipmentDatePos, TempLatestDateShipment)
            Else
                c.RichEditControl1.Document.InsertText(NewShipmentDatePos, Nothing)
            End If

            Dim NewLcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLcCurrency").Range.End
            c.RichEditControl1.Document.InsertText(NewLcCurrencyPos, NewLcCurrency)
            Dim NewLcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NewLcAmount").Range.End
            If NewLcAmount <> 0 Then
                c.RichEditControl1.Document.InsertText(NewLcAmountPos, NewLcAmount)
            Else
                c.RichEditControl1.Document.InsertText(NewLcAmountPos, Nothing)
            End If

            SplashScreenManager.CloseForm(False)

            'Add Signatures
            Dim message, title, defaultValue As String
            Dim myValue As Object
            message = "Please input the Advice Commission sharing" & vbNewLine & vbNewLine _
                & "Charges for Applicant   = 1" & vbNewLine _
                & "Charges for Beneficiary = 2" & vbNewLine _
                & "Charges Shared          = 0"

            title = "ADVICE COMMISSION SHARING"   ' Set title.
            defaultValue = "1"   ' Set default value.
            ' Display message, title, and default value.
            myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            Dim ChargesOUR_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_OUR").Range.End
            Dim ChargesBEN_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_BEN").Range.End
            Dim ChargesSHA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges_SHA").Range.End
            If myValue = "1" Then
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "X")
            ElseIf myValue = "2" Then
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "X")
            ElseIf myValue = "0" Then
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "X")
            Else
                c.RichEditControl1.Document.InsertText(ChargesOUR_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesBEN_Pos, "")
                c.RichEditControl1.Document.InsertText(ChargesSHA_Pos, "")
            End If


            Dim message1, title1, defaultValue1 As String
            Dim myValue1 As Object
            message1 = "Please input where the Applicant must confirm the Amendment" & vbNewLine & vbNewLine _
                & "Confirmation    = Y" & vbNewLine _
                & "No Confirmation = N"
            title1 = "APPLICANTS AMENDMENT CONFIRMATION"   ' Set title.
            defaultValue1 = "N"   ' Set default value.
            ' Display message, title, and default value.
            myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)
            Dim ApplicantsConfirmation_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantsConfirmation").Range.End

            If myValue1 = "Y" Then
                c.RichEditControl1.Document.InsertText(ApplicantsConfirmation_Pos, "Wir bitten um Ihre Einverständniserklärung zur Annahme der o.a. Änderung")
            Else
                c.RichEditControl1.Document.InsertText(ApplicantsConfirmation_Pos, "")
            End If



        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub LC_AMENDMENT_ADVICE_FAX()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Fax Advice creation")
            Dim LC_FAX_ADVICE_FORM As String = Nothing
            'Dates and times
            Dim d As Date = Today
            Dim t As Date = Now
            Dim IndustrieDatum As String = String.Format("{0:000}", DatePart(DateInterval.DayOfYear, d))
            'Select BANK Parameters
            Dim OUR_BIC As String = Nothing
            Dim OUR_BANKNAME As String = Nothing
            Dim OUR_BANK_BRANCH As String = Nothing
            Dim OUR_BANKSTRASSE As String = Nothing
            Dim OUR_BANKPLZ_ORT As String = Nothing
            'Select CurrentUserContact Details
            Dim CURRENT_USER_CONTACT_DETAILS As String = Nothing

            Dim SwiftNachricht As String = Me.Swift_Message_Amendment_lbl.Text
            Dim OurConfirmation As String = Nothing
            If Me.OurConfirmation_ComboEdit.Text = "WITHOUT OUR CONFIRMATION" Then
                OurConfirmation = "OHNE BESTÄTIGUNG"
            Else
                OurConfirmation = "BESTÄTIGT"
            End If

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

            'Get Issuing Bank details
            Me.QueryText = "Select * from [BIC DIRECTORY] where [BIC11]='" & Microsoft.VisualBasic.Left(Me.IssuingBIC_TextEdit.Text, 11) & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Dim ISSOUING_BANK_NAME As String = dt.Rows.Item(0).Item("INSTITUTION NAME")
            Dim ISSOUING_BANK_BRANCH As String = dt.Rows.Item(0).Item("BRANCH INFORMATION")
            Dim ISSOUING_BANK_CITY As String = dt.Rows.Item(0).Item("CITY HEADING")
            Dim ISSOUING_BANK_COUNTRY As String = dt.Rows.Item(0).Item("COUNTRY NAME")


            'Get Our Bank Details
            Me.QueryText = "Select * from [BANK]"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            OUR_BIC = dt.Rows.Item(0).Item("BIC Bank")
            OUR_BANKNAME = dt.Rows.Item(0).Item("Name Bank")
            OUR_BANK_BRANCH = dt.Rows.Item(0).Item("Branch Bank")
            OUR_BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
            OUR_BANKPLZ_ORT = dt.Rows.Item(0).Item("PLZ Bank") & "  " & dt.Rows.Item(0).Item("Ort Bank")

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


            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_AMENDMENT_ADVICE_FAX" Then
                    LC_FAX_ADVICE_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next



            Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
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



            ' MT707 - Zeilen auslessen 
            Dim NrOfAmendment As String = Nothing

            Dim TempStringDateIssue As String = Nothing
            Dim TempDateIssue As Date

            Dim TempStringDateAmendment As String = Nothing
            Dim TempDateAmendment As Date
            Dim DateOfAmendment As String = Nothing

            Dim TempStringDateExpiry As String = Nothing
            Dim TempDateExpiry As Date
            Dim NewDateOfExpiry As String = Nothing

            Dim TempStringNewLcAmount As String = Nothing
            Dim NewLcCurrency As String = Nothing
            Dim NewLcAmount As Double = 0

            Dim TempStringLatestDateShipment As String = Nothing
            Dim TempLatestDateShipment As Date

            Dim TempStringOldDateExpiry As String = Nothing
            Dim TempOldDateExpiry As Date

            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":31C:") = True Then
                    TempStringDateIssue = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateIssue = DateSerial(Microsoft.VisualBasic.Left(TempStringDateIssue, 2), Microsoft.VisualBasic.Mid(TempStringDateIssue, 3, 2), Microsoft.VisualBasic.Right(TempStringDateIssue, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateIssue, TempDateIssue.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":30:") = True Then
                    TempStringDateAmendment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateAmendment = DateSerial(Microsoft.VisualBasic.Left(TempStringDateAmendment, 2), Microsoft.VisualBasic.Mid(TempStringDateAmendment, 3, 2), Microsoft.VisualBasic.Right(TempStringDateAmendment, 2))
                    DateOfAmendment = TempDateAmendment.ToString("yyyyMMdd")
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateAmendment, TempDateAmendment.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":26E:") = True Then
                    NrOfAmendment = Microsoft.VisualBasic.Right(line.Trim, 2)
                End If
                If line.StartsWith(":31D:") = True Then
                    TempStringOldDateExpiry = Microsoft.VisualBasic.Mid(line.Trim, 6, 6)
                    TempOldDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringOldDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringOldDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringOldDateExpiry, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringOldDateExpiry, TempOldDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":31E:") = True Then
                    TempStringDateExpiry = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempDateExpiry = DateSerial(Microsoft.VisualBasic.Left(TempStringDateExpiry, 2), Microsoft.VisualBasic.Mid(TempStringDateExpiry, 3, 2), Microsoft.VisualBasic.Right(TempStringDateExpiry, 2))
                    Me.DateOfExpiry_DateEdit.Text = TempDateExpiry
                    NewDateOfExpiry = TempDateExpiry.ToString("yyyyMMdd")
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [M31D_Date]='" & NewDateOfExpiry & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    SwiftNachricht = SwiftNachricht.Replace(TempStringDateExpiry, TempDateExpiry.ToString("dd.MM.yyyy"))
                End If
                If line.StartsWith(":34B:") = True Then
                    NewLcCurrency = Microsoft.VisualBasic.Mid(line.Trim, 6, 3)
                    Me.LcCurrency_TextEdit.Text = NewLcCurrency
                    TempStringNewLcAmount = Microsoft.VisualBasic.Mid(line.Trim, 9, 15)
                    If TempStringNewLcAmount.Trim.EndsWith(",") = True Then
                        TempStringNewLcAmount = TempStringNewLcAmount.Replace(",", "")
                    End If
                    NewLcAmount = TempStringNewLcAmount
                    Me.LcAmount_Textedit.Text = NewLcAmount
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [EXPORT_LC_MT700] SET [LC_Currency]='" & NewLcCurrency & "', [LC_Amount]='" & Str(NewLcAmount) & "' where [OurReference]='" & Me.OurReference_TextEdit.Text & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                End If
                If line.StartsWith(":44C:") = True Then
                    TempStringLatestDateShipment = Microsoft.VisualBasic.Right(line.Trim, 6)
                    TempLatestDateShipment = DateSerial(Microsoft.VisualBasic.Left(TempStringLatestDateShipment, 2), Microsoft.VisualBasic.Mid(TempStringLatestDateShipment, 3, 2), Microsoft.VisualBasic.Right(TempStringLatestDateShipment, 2))
                    SwiftNachricht = SwiftNachricht.Replace(TempStringLatestDateShipment, TempLatestDateShipment.ToString("dd.MM.yyyy"))
                End If
            Next

            'Reformat SWIFT Message
            SwiftNachricht = SwiftNachricht.Replace(":27:", ":27:Sequence of Total" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":20:", ":20:Sender's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":21:", ":21:Receiver's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23:", ":23:Issuing Bank's Reference" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52A:", ":52A:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":52D:", ":52D:Issuing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":50B:", ":50B:Non-Bank Issuer" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31C:", ":31C:Date of Issue" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":30:", ":30:Date of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":26E:", ":26E:Number of Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":22A:", ":22A:Purpose of Message" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":23S:", ":23S:Cancellation Request" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":40A:", ":40A:Form of Documentary Credit" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":40E:", ":40E:Applicable Rules" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":50:", ":50:Changed Applicant Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":59:", ":59:Beneficiary" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31D:", ":31D:Date and Place of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":31E:", ":31E:New Date of Expiry" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":32B:", ":32B:Increase of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":33B:", ":33B:Decrease of Documentary Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":34B:", ":34B:New Documentary Credit Amount After Amendment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39A:", ":39A:Percentage Credit Amount Tolerance" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39B:", ":39B:Maximum Credit Amount" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":39C:", ":39C:Additional Amounts Covered" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":41A:", ":41A:Available With ... By ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":41D:", ":41D:Available With ... By ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42C:", ":42C:Drafts at ..." & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42A:", ":42A:Drawee" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42D:", ":42D:Drawee" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42M:", ":42M:Mixed Payment Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":42P:", ":42P:Negotiation/Deferred Payment Details" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":43P:", ":43P:Partial Shipments" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":43T:", ":43T:Transhipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44A:", ":44A:Place of Taking in Charge/Dispatch from .../Place of Receipt" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44E:", ":44E:Port of Loading/Airport of Departure" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44F:", ":44F:Port of Discharge/Airport of Destination" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44B:", ":44B:Place of Final Destination/For Transportation to .../Place of Delivery" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44C:", ":44C:Latest Date of Shipment" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":44D:", ":44D:Shipment Period" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":45B:", ":45B:Description of Goods and/or Services" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":46B:", ":46B:Documents Required" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":47B:", ":47B:Additional Conditions" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49M:", ":49M:Special Payment Conditions for Beneficiary" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49N:", ":49N:Special Payment Conditions for Receiving Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":71D:", ":71D:Charges" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":71N:", ":71N:Amendment Charge Payable By" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":48:", ":48:Period for Presentation in Days" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":49:", ":49:Confirmation Instructions" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":58A:", ":58A:Requested Confirmation Party" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":58D:", ":58D:Requested Confirmation Party" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":53A:", ":53A:Reimbursing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":53D:", ":53D:Reimbursing Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":78:", ":78:Instructions to the Paying/Accepting/Negotiating Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":79:", ":79:Narrative" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57A:", ":57A:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57B:", ":57B:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":57D:", ":57D:Advise Through' Bank" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72:", ":72:Sender to Receiver Information" & vbNewLine)
            SwiftNachricht = SwiftNachricht.Replace(":72Z:", ":72Z:Sender to Receiver Information" & vbNewLine)
            '

            SplashScreenManager.Default.SetWaitFormCaption("Create Fax Amendment Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Advice Amendment Fax Form"
            c.RichEditControl1.LoadDocument(LC_FAX_ADVICE_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_Contact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, CustomerContact1)
            Dim FaxNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Beneficiary_FaxNr").Range.End
            c.RichEditControl1.Document.InsertText(FaxNrPos, CustomerFax)
            Dim CurrentUserContactDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("OurContactDetails").Range.End
            c.RichEditControl1.Document.InsertText(CurrentUserContactDetailsPos, CURRENT_USER_CONTACT_DETAILS)
            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.OurReference_TextEdit.Text)
            Dim AmendmentNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AmendmentNr").Range.End
            c.RichEditControl1.Document.InsertText(AmendmentNrPos, NrOfAmendment)
            Dim LC_Text_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LC_Text").Range.End
            c.RichEditControl1.Document.InsertText(LC_Text_Pos, SwiftNachricht)
            Dim PageCount As Integer = DirectCast(c.RichEditControl1.ActiveView, DevExpress.XtraRichEdit.PrintLayoutView).PageCount
            Dim PageCount_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PageNr").Range.End
            c.RichEditControl1.Document.InsertText(PageCount_Pos, PageCount)
            SplashScreenManager.CloseForm(False)

            'Add Signatures
            'Dim message, title, defaultValue As String
            'Dim myValue As Object
            'message = "Please input the Name of the A Signature"   ' Set prompt.
            'title = "SIGNATURES"   ' Set title.
            'defaultValue = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue = Microsoft.VisualBasic.InputBox(message, title, defaultValue)

            'Dim SignatureA_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureA").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureA_Pos, myValue)

            'Dim message1, title1, defaultValue1 As String
            'Dim myValue1 As Object
            'message1 = "Please input the Name of the B Signature"   ' Set prompt.
            'title1 = "SIGNATURES"   ' Set title.
            'defaultValue1 = ""   ' Set default value.
            ' Display message, title, and default value.
            'myValue1 = Microsoft.VisualBasic.InputBox(message1, title1, defaultValue1)

            'Dim SignatureB_Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SignatureB").Range.End
            'c.RichEditControl1.Document.InsertText(SignatureB_Pos, myValue1)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub


    Private Sub AdvicedAmendment_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles AdvicedAmendment_CheckEdit.CheckedChanged
        If Me.AdvicedAmendment_CheckEdit.Focused = True Then
            If Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Checked Then
                Dim d As Date = Today
                Me.AdvicedAmendment_DateEdit.Text = d
            ElseIf Me.AdvicedAmendment_CheckEdit.CheckState = CheckState.Unchecked Then
                Me.AdvicedAmendment_DateEdit.Text = Nothing
            End If
            SAVE_ALL_CHANGES()
        End If

    End Sub





    Private Sub DoneStatus_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles DoneStatus_CheckEdit.CheckedChanged
        If Me.DoneStatus_CheckEdit.CheckState = CheckState.Checked Then
            Dim d As Date = Today
            Me.DoneDateEdit.Text = d
            Me.GroupControl1.Enabled = False
            Me.GroupControl6.Enabled = False
            Me.GroupControl10.Enabled = False
            Me.ApplicantAddresses_GridView.OptionsBehavior.Editable = False
            Me.ApplicantAddresses_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
        ElseIf Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.DoneDateEdit.Text = Nothing
            Me.GroupControl1.Enabled = True
            Me.GroupControl6.Enabled = True
            Me.GroupControl10.Enabled = False
            Me.ApplicantAddresses_GridView.OptionsBehavior.Editable = True
            Me.ApplicantAddresses_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl3.EmbeddedNavigator.Buttons.Append.Visible = True
            Me.GridControl3.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
        End If

        SAVE_ALL_CHANGES()
    End Sub



    Private Sub SwiftMsgPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgPrint_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Export LC Ref. " & Me.OurReference_TextEdit.Text)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EXPORT_LC_MT700.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(LcDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Me.IDLabel1.Text
        myParams.ParameterFieldName = "ID"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "EXPORT LC Reference" & Me.OurReference_TextEdit.Text
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SwiftMsgRelatedPrint_btn_Click(sender As Object, e As EventArgs) Handles SwiftMsgRelatedPrint_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Printform for Message Ref. " & Me.Ref20_TextEdit.Text)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\EXPORT_LC_MT700_RelatedMsg.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(LcDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Me.ID_RelatedMessage_lbl.Text
        myParams.ParameterFieldName = "ID"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "SWIFT MESSAGE Reference " & Me.Ref20_TextEdit.Text
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ExportLcRelatedMessages_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLcRelatedMessages_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLcRelatedMessages_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLcRelatedMessages_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AdviceChargesCur_GridLookUpEdit_LostFocus(sender As Object, e As EventArgs) Handles AdviceChargesCur_GridLookUpEdit.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub AmendAdviceCur_GridLookUpEdit1_LostFocus(sender As Object, e As EventArgs) Handles AmendAdviceCur_GridLookUpEdit1.LostFocus
        SAVE_ALL_CHANGES()
    End Sub

    Private Sub EXPORT_LC_IMPORT_MANUAL()
        Dim result As DialogResult = XtraMessageBox.Show("Should the LC Nr. " & Me.M_LC_Nr_TextEdit.Text & " be imported ?", "EXPORT LC - MANUAL IMPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = System.Windows.Forms.DialogResult.Yes Then

            Using ConnSqlM As New SqlConnection(connSQL.ConnectionString)

                Dim cmdConnSqlM As New SqlCommand
                cmdConnSqlM.Connection = ConnSqlM
                ConnSqlM.Open()

                cmdConnSqlM.CommandText = "Select Max([LfdNr])+1 from [EXPORT_LC_MT700]"
                Dim lfdNr As Double = cmdConnSqlM.ExecuteScalar
                Dim OurReference As String = "DEFF" & lfdNr
                Dim ReceiptDate As Date = Me.M_ReceivedDate_DateEdit.Text
                Dim ReceiptDateSql As String = ReceiptDate.ToString("yyyyMMdd")
                Dim SenderBIC As String = Me.M_SenderBIC_TextEdit.Text
                Dim LCF40A As String = Me.M_LC_Form_TextEdit.Text
                Dim DateOfIssue As Date = Me.M_Issuing_Date_DateEdit.Text
                Dim LCF31C As String = DateOfIssue.ToString("yyyyMMdd")
                Dim DateOfExpiry As Date = Me.M_DateOfExpiry_DateEdit.Text
                Dim LCF31D_Date As String = DateOfExpiry.ToString("yyyyMMdd")
                Dim LCF32B_CUR As String = Me.M_LC_Currency_TextEdit.Text
                Dim LCF32B_AMT As Double = Me.M_LC_Amount_TextEdit.Text
                Dim LCF41_BY As String = Me.M_LC_Available_By_TextEdit.Text


                'Insert in EXPORT_LC_MT700
                cmdConnSqlM.Parameters.Clear()
                cmdConnSqlM.CommandText = "INSERT INTO [EXPORT_LC_MT700]([SwiftFileName],[LfdNr],[OurReference],[MessageType],[SenderBIC],[ReceivedDate],[OSN],[LC_Form],[LC_Nr],[DateOfIssue],[M31D_Date],[M31D_Country],[IssuingBank],[Applicant],[Beneficiary],[LC_Currency],[LC_Amount],[Available_With],[Available_By],[Swift_Message],[Swift_Message_Formated]) Values ('MANUAL','" & Str(lfdNr) & "','" & OurReference & "','700','" & SenderBIC & "','" & ReceiptDateSql & "','0','" & LCF40A & "',@ReferenceLC,'" & LCF31C & "','" & LCF31D_Date & "',@PlaceOfExpiry, @IssuingOrApplicantsBank, @Applicant, @Beneficiary,'" & LCF32B_CUR & "','" & Str(LCF32B_AMT) & "',@AvailableWith,'" & LCF41_BY & "',@SwiftMessageTextAll,@SwiftMessageFormatedTextAll)"
                cmdConnSqlM.Parameters.Add("@ReferenceLC", SqlDbType.NVarChar).Value = Me.M_LC_Nr_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@SwiftMessageTextAll", SqlDbType.NText).Value = Me.M_SwiftMessageBlock_RichTextBox.Text
                cmdConnSqlM.Parameters.Add("@SwiftMessageFormatedTextAll", SqlDbType.NText).Value = Me.M_SwiftMessageBlock_RichTextBox.Text
                cmdConnSqlM.Parameters.Add("@PlaceOfExpiry", SqlDbType.NVarChar).Value = Me.M_PlaceOfExiry_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@IssuingOrApplicantsBank", SqlDbType.NVarChar).Value = Me.M_Issuing_BIC_TextEdit.Text
                cmdConnSqlM.Parameters.Add("@Applicant", SqlDbType.NVarChar).Value = Me.M_Applicant_MemoEdit.Text
                cmdConnSqlM.Parameters.Add("@Beneficiary", SqlDbType.NVarChar).Value = Me.M_Beneficiary_MemoEdit.Text
                cmdConnSqlM.Parameters.Add("@AvailableWith", SqlDbType.NVarChar).Value = Me.AvailableWith_TextEdit.Text
                cmdConnSqlM.ExecuteNonQuery()
                cmdConnSqlM.Parameters.Clear() 'Allways to Use otherwise ERROR EXCEPTION:The Vaiables must be unique
                'Updates in EXPORT_LC_MT700
                cmdConnSqlM.CommandText = "UPDATE A SET A.[SenderName]= B.[INSTITUTION NAME],A.[SenderBranch]=B.[CITY HEADING] FROM [EXPORT_LC_MT700] A INNER JOIN [BIC DIRECTORY] B ON A.[SenderBIC]=B.[BIC CODE]+ B.[BRANCH CODE] where A.[OurReference]='" & OurReference & "'"
                cmdConnSqlM.ExecuteNonQuery()
                cmdConnSqlM.CommandText = "UPDATE A set A.[MessageTypeName]=B.S from  [EXPORT_LC_MT700] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='SWIFT_MESSAGE_NAMES' and [PARAMETER STATUS] ='Y')B ON A.[MessageType]=B.[PARAMETER1] where A.[MessageTypeName] is NULL and A.[OurReference]='" & OurReference & "'"
                cmdConnSqlM.ExecuteNonQuery()
                ConnSqlM.Close()

                XtraMessageBox.Show("EXPORT LC Nr. " & Me.M_LC_Nr_TextEdit.Text & " has being imported with Reference Nr. " & OurReference, "IMPORT FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Set default values
                Me.M_ReceivedDate_DateEdit.EditValue = DBNull.Value
                Me.M_SenderBIC_TextEdit.Text = ""
                Me.M_LC_Nr_TextEdit.Text = ""
                Me.M_LC_Form_TextEdit.Text = ""
                Me.M_Issuing_BIC_TextEdit.Text = ""
                Me.M_Issuing_Date_DateEdit.EditValue = DBNull.Value
                Me.M_DateOfExpiry_DateEdit.EditValue = DBNull.Value
                Me.M_PlaceOfExiry_TextEdit.Text = ""
                Me.M_Applicant_MemoEdit.EditValue = DBNull.Value
                Me.M_Beneficiary_MemoEdit.EditValue = DBNull.Value
                Me.M_LC_Currency_TextEdit.EditValue = DBNull.Value
                Me.M_LC_Amount_TextEdit.EditValue = DBNull.Value
                Me.AvailableWith_TextEdit.Text = ""
                Me.AvailableWith_TextEdit.Text = ""
                Me.M_LC_Available_By_TextEdit.EditValue = DBNull.Value
                Me.M_SwiftMessageBlock_RichTextBox.Text = ""

            End Using
        Else
            Exit Sub
        End If

    End Sub


    Private Sub M_AddManualLC_btn_Click(sender As Object, e As EventArgs) Handles M_AddManualLC_btn.Click
        If Me.DxValidationProvider1.Validate() = True Then
            'Check if issuing bank BIC exists
            If cmdSQL.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "Select Count([Idnr]) from [BIC DIRECTORY] where [BIC11]='" & Me.M_SenderBIC_TextEdit.Text & "'"
            Dim r As Double = cmd.ExecuteScalar
            If r > 0 Then
                cmd.CommandText = "Select Count([Idnr]) from [BIC DIRECTORY] where [BIC11]='" & Me.M_Issuing_BIC_TextEdit.Text & "'"
                r = cmd.ExecuteScalar
                If r > 0 Then
                    cmd.Connection.Close()
                    Try
                        EXPORT_LC_IMPORT_MANUAL()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    cmd.Connection.Close()
                    MessageBox.Show("Issuing Bank BIC not fund in BIC DIRECTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                cmd.Connection.Close()
                MessageBox.Show("Sender Bank BIC not fund in BIC DIRECTORY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


        Else
            MessageBox.Show("Validation failed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub LC_MANUAL_INPUT_XtraTabPage_VisibleChanged(sender As Object, e As EventArgs) Handles LC_MANUAL_INPUT_XtraTabPage.VisibleChanged
        If LC_MANUAL_INPUT_XtraTabPage.PageVisible = True Then
            Me.Label6.Visible = False
            Me.OurReferenceSearch_GridLookUpEdit.Visible = False
        ElseIf LC_MANUAL_INPUT_XtraTabPage.PageVisible = False Then
            'Set default values
            Me.M_ReceivedDate_DateEdit.EditValue = DBNull.Value
            Me.M_SenderBIC_TextEdit.Text = ""
            Me.M_LC_Nr_TextEdit.Text = ""
            Me.M_LC_Form_TextEdit.Text = ""
            Me.M_Issuing_BIC_TextEdit.Text = ""
            Me.M_Issuing_Date_DateEdit.EditValue = DBNull.Value
            Me.M_DateOfExpiry_DateEdit.EditValue = DBNull.Value
            Me.M_PlaceOfExiry_TextEdit.Text = ""
            Me.M_Applicant_MemoEdit.EditValue = DBNull.Value
            Me.M_Beneficiary_MemoEdit.EditValue = DBNull.Value
            Me.M_LC_Currency_TextEdit.EditValue = DBNull.Value
            Me.M_LC_Amount_TextEdit.EditValue = DBNull.Value
            Me.AvailableWith_TextEdit.Text = ""
            Me.AvailableWith_TextEdit.Text = ""
            Me.M_LC_Available_By_TextEdit.EditValue = DBNull.Value
            Me.M_SwiftMessageBlock_RichTextBox.Text = ""
            Me.XtraTabControl2.Visible = False
            Me.Label6.Visible = True
            Me.OurReferenceSearch_GridLookUpEdit.Visible = True
            Me.OurReferenceSearch_GridLookUpEdit.Focus()

        End If
    End Sub

    Private Sub M_Cancel_btn_Click(sender As Object, e As EventArgs) Handles M_Cancel_btn.Click
        LC_MANUAL_INPUT_XtraTabPage.PageVisible = False
    End Sub


    Private Sub ExportLC_List_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLC_List_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLC_List_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLC_List_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
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

    Private Sub ExportLc_Settlements_BaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExportLc_Settlements_BaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExportLc_Settlements_BaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExportLc_Settlements_BaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
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
        Dim reportfooter As String = "EXPORT LETTER OF CREDITS till " & Now
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
        Dim reportfooter As String = "Settlements for LC Nr. " & Me.LC_Nr_TextEdit.Text & " Our reference: " & Me.OurReferenceSearch_GridLookUpEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridView_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ApplicantAddresses_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ApplicantAddresses_GridView.RowUpdated
        SAVE_ALL_CHANGES()
        Me.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements_ApplNameAddress, OurReferenceSearch)
    End Sub

    Private Sub ApplicantAddresses_GridView_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles ApplicantAddresses_GridView.RowDeleted
        SAVE_ALL_CHANGES()
        Me.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements_ApplNameAddress, OurReferenceSearch)
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
        If value IsNot Nothing Then
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
        'MsgBox(value)
        If value IsNot Nothing Then
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

    Private Sub SettlementType_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SettlementType_SearchLookUpEdit.EditValueChanged
        If LC_SETTLEXtraTabPage.PageVisible = True Then
            If Me.LayoutControl1.Visible = False Then
                Dim SettleID As Integer
                If Me.SettlementType_SearchLookUpEdit.Text <> "" Then
                    Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                    Dim SettlementType_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                    SettleID = CInt(SettlementType_Row("ID").ToString)
                    Me.SettlementType_lbl.Text = SettlementType_Row("AccountConnection").ToString
                    Me.SettlementAccountCCY_lbl.Text = SettlementType_Row("IBAN_CCY").ToString
                    Me.SettlementAccountNr_lbl.Text = SettlementType_Row("IBAN_NR").ToString
                    Me.SettlementBank_lbl.Text = SettlementType_Row("BankName").ToString & " (BIC:" & SettlementType_Row("BIC").ToString & ")"
                    Me.SettlementAccountCCY1_lbl.Text = Me.SettlementAccountCCY_lbl.Text
                    Me.SettlementAccountNr1_lbl.Text = Me.SettlementAccountNr_lbl.Text
                    Me.SettlementBank1_lbl.Text = Me.SettlementBank_lbl.Text
                    'MsgBox(SettleID)
                    'If cmdSQL.Connection.State = ConnectionState.Closed Then
                    '    cmdSQL.Connection.Open()
                    'End If
                    'cmdSQL.CommandText = "UPDATE [EXPORT_LC_MT700_Settlements] 
                    'SET [SettlementType]='" & Me.SettlementType_lbl.Text & "',
                    '[CustomerAccountCCY] ='" & Me.SettlementAccountCCY_lbl.Text & "',
                    '[CustomerAccountNr] ='" & Me.SettlementAccountNr_lbl.Text & "',
                    '[CustomerBankName] ='" & Me.SettlementBank_lbl.Text & "' WHERE ID='" & SettleID & "'"
                    'cmdSQL.ExecuteNonQuery()
                    'If cmdSQL.Connection.State = ConnectionState.Open Then
                    '    cmdSQL.Connection.Close()
                    'End If
                Else
                    Me.SettlementType_lbl.Text = ""
                    Me.SettlementAccountCCY_lbl.Text = ""
                    Me.SettlementAccountNr_lbl.Text = ""
                    Me.SettlementBank_lbl.Text = ""
                    Me.SettlementAccountCCY1_lbl.Text = Me.SettlementAccountCCY_lbl.Text
                    Me.SettlementAccountNr1_lbl.Text = Me.SettlementAccountNr_lbl.Text
                    Me.SettlementBank1_lbl.Text = Me.SettlementBank_lbl.Text

                End If
            End If
        End If

    End Sub

    Private Sub SettlementType_SearchLookUpEdit_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles SettlementType_SearchLookUpEdit.EditValueChanging

    End Sub

    Private Sub SettlementCancel_btn_Click(sender As Object, e As EventArgs) Handles SettlementCancel_btn.Click
        VALIDATIONS_REMOVE()
        Me.FKEXPORTLCMT700SettlementsEXPORTLCMT700BindingSource.EndEdit()
        Me.FKEXPORTLCMT700SettlementsChargesEXPORTLCMT700SettlementsBindingSource.EndEdit()
        Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillBySettlementID(Me.LcDataset.EXPORT_LC_MT700_Settlements, OurReferenceSearch, Me.SettlementID_lbl.Text)
        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByID(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, Me.SettlementID_lbl.Text)
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()
        SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp()

    End Sub

    Private Sub SettlementSave_btn_Click(sender As Object, e As EventArgs) Handles SettlementSave_btn.Click
        VALIDATIONS_SETTLEMENT_ADD()
        Try
            Me.Validate()
            If Me.DxValidationProvider1.Validate() = True Then
                NET_AMOUNT_CUSTOMER_CALCULATE()
                Me.FKEXPORTLCMT700SettlementsEXPORTLCMT700BindingSource.EndEdit()
                Me.EXPORT_LC_MT700_SettlementsTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements)
                Me.FKEXPORTLCMT700SettlementsChargesEXPORTLCMT700SettlementsBindingSource.EndEdit()
                Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements_Charges)
                SAVE_ALL_CHANGES()
                'Me.LayoutControl1.Visible = True
                'FILL_ALL_DATA_BY_OUR_REFERENCE()
                'Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillBySettlementID(LcDataset.EXPORT_LC_MT700_Settlements, our)
                Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillBySettlementID(Me.LcDataset.EXPORT_LC_MT700_Settlements, OurReferenceSearch, Me.SettlementID_lbl.Text)
                Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByID(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, Me.SettlementID_lbl.Text)
                SETTLEMENT_TYPE_initData()
                SETTLEMENT_TYPES_InitLookUp()
                SETTLEMENT_TYPE_initData()
                SETTLEMENT_TYPES_InitLookUp()
            Else
                MessageBox.Show("Validation Failed!", "VALIDATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

    End Sub

    Private Sub NET_AMOUNT_CUSTOMER_CALCULATE()
        Dim summaryValue = SettlementCharges_GridView.Columns("ChargesOrigAmount").SummaryItem.SummaryValue
        CHARGES_CALCULATED = summaryValue
        DISCONT_CALCULATED = Me.DiscountAmount_SpinEdit.EditValue
        Dim INVOICE_AMOUNT As Double = Me.InvoiceAmount_SpinEdit.EditValue
        NET_AMOUNT_CUSTOMER = INVOICE_AMOUNT - DISCONT_CALCULATED - CHARGES_CALCULATED
        Me.NetAmountForCustomer_SpinEdit.EditValue = NET_AMOUNT_CUSTOMER
    End Sub

    Private Sub ExportLc_Settlements_BaseView_DoubleClick(sender As Object, e As EventArgs) Handles ExportLc_Settlements_BaseView.DoubleClick
        If Me.ExportLc_Settlements_BaseView.IsFilterRow(Me.ExportLc_Settlements_BaseView.FocusedRowHandle) = True OrElse Me.ExportLc_Settlements_BaseView.RowCount = 0 Then
            Return
        Else
            Me.LayoutControl1.Visible = False
            DISCOUNT_CHECK_STATUS()
            SETTLEMENT_LC_CHECK_STATUS()
            GET_LAST_REST_LC_AMOUNT()
        End If
        'SETTLEMENT_TYPE_initData()
        'SETTLEMENT_TYPES_InitLookUp()

    End Sub

    Private Sub GET_LAST_REST_LC_AMOUNT()
        If Me.ExportLc_Settlements_BaseView.RowCount > 0 Then
            Dim SettlementNr As Double = Me.SettlementNr_lbl.Text
            If SettlementNr > 1 Then
                LAST_LC_REST_AMOUNT = Me.LcRemainingAmount_CalcEdit.EditValue
            End If
        End If

    End Sub

    Private Sub SETTLEMENT_LC_CHECK_STATUS()
        If Me.DoneStatus_CheckEdit.CheckState = CheckState.Checked Then
            Me.SettlementDate_DateEdit.ReadOnly = True
            Me.SettlementType_SearchLookUpEdit.ReadOnly = True
            Me.InvoiceCCY_GridLookUpEdit.ReadOnly = True
            Me.InvoiceAmount_SpinEdit.ReadOnly = True
            'Me.LcRemainingAmount_CalcEdit.ReadOnly = True
            Me.CustomerLetterDate_DateEdit.ReadOnly = True
            Me.CustomerLetterReference_TextEdit.ReadOnly = True
            Me.CustomerContactName_TextEdit.ReadOnly = True
            Me.Discount_CheckEdit.ReadOnly = True
            Me.SettlementCharges_GridView.OptionsBehavior.Editable = False
            Me.SettlementCharges_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            Me.GridControl5.EmbeddedNavigator.Buttons.Append.Visible = False
            Me.GridControl5.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = False
            Me.GridControl5.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = False
            Me.Discount_GroupControl.Enabled = False
            Me.GroupControl12.Enabled = False
            Me.GroupControl13.Enabled = False
        ElseIf Me.DoneStatus_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.SettlementDate_DateEdit.ReadOnly = False
            Me.SettlementType_SearchLookUpEdit.ReadOnly = False
            Me.InvoiceCCY_GridLookUpEdit.ReadOnly = False
            Me.InvoiceAmount_SpinEdit.ReadOnly = False
            'Me.LcRemainingAmount_CalcEdit.ReadOnly = False
            Me.CustomerLetterDate_DateEdit.ReadOnly = False
            Me.CustomerLetterReference_TextEdit.ReadOnly = False
            Me.CustomerContactName_TextEdit.ReadOnly = False
            Me.Discount_CheckEdit.ReadOnly = False
            Me.SettlementCharges_GridView.OptionsBehavior.Editable = True
            Me.SettlementCharges_GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            Me.GridControl5.EmbeddedNavigator.Buttons.Append.Visible = True
            Me.GridControl5.EmbeddedNavigator.Buttons.CustomButtons.Item(0).Visible = True
            Me.GridControl5.EmbeddedNavigator.Buttons.CustomButtons.Item(1).Visible = True
            Me.Discount_GroupControl.Enabled = True
            Me.GroupControl12.Enabled = True
            Me.GroupControl13.Enabled = True
        End If
    End Sub

    Private Sub SettlementType_SearchLookUpEdit_GotFocus(sender As Object, e As EventArgs) Handles SettlementType_SearchLookUpEdit.GotFocus
        'SETTLEMENT_TYPE_initData()
        SETTLEMENT_TYPES_InitLookUp_Focus()
    End Sub

    Private Sub DISCOUNT_CHECK_STATUS()
        If Discount_CheckEdit.CheckState = CheckState.Checked Then
            Me.Discount_GroupControl.Visible = True
        ElseIf Discount_CheckEdit.CheckState = CheckState.Unchecked Then
            Me.Discount_GroupControl.Visible = False
        End If
    End Sub

    Private Sub Discount_CheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles Discount_CheckEdit.CheckedChanged
        If Me.LayoutControl1.Visible = False Then

            If Discount_CheckEdit.CheckState = CheckState.Checked Then
                Me.Discount_GroupControl.Visible = True
                'cmdSQL.CommandText = "SELECT [DiscontConditionsText],[DiscontMaturityCalculated],[DiscontContractDate] from [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "'"
                'Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
                'Dim dt As New DataTable
                'daSql.Fill(dt)
                'If dt.Rows.Count > 0 Then
                '    Me.DiscountConditions_MemoEdit.Text = dt.Rows.Item(0).Item("DiscontConditionsText")
                '    Me.DiscountMaturity_MemoEdit.Text = dt.Rows.Item(0).Item("DiscontMaturityCalculated")
                '    Me.DiscountContractDate_DateEdit.Text = dt.Rows.Item(0).Item("DiscontContractDate")
                'End If
            ElseIf Discount_CheckEdit.CheckState = CheckState.Checked Then
                Me.Discount_GroupControl.Visible = True
            End If
            If Discount_CheckEdit.CheckState = CheckState.Unchecked Then
                VALIDATIONS_DISCOUNT_REMOVE()
                Me.Discount_GroupControl.Visible = False
            End If
        End If

    End Sub

    Private Sub SettlementCharges_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles SettlementCharges_GridView.RowUpdated
        NET_AMOUNT_CUSTOMER_CALCULATE()
        Me.SettlementSave_btn.PerformClick()

    End Sub

    Private Sub SettlementCharges_GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles SettlementCharges_GridView.CellValueChanged
        Dim view As GridView = DirectCast(sender, GridView)

        If view.UpdateCurrentRow() Then
            Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.Update(LcDataset.EXPORT_LC_MT700_Settlements_Charges)
        End If

    End Sub

    Private Sub SettlementCharges_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles SettlementCharges_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CONDITION_NAME As GridColumn = View.Columns("ConditionName")
        Dim CHARGES_CCY As GridColumn = View.Columns("ChargesCCY")
        Dim CHARGES_AMOUNT As GridColumn = View.Columns("ChargesOrigAmount")

        Dim ConditionName As String = View.GetRowCellValue(e.RowHandle, colConditionName1).ToString
        Dim ChargesCCY As String = View.GetRowCellValue(e.RowHandle, colChargesCCY1).ToString
        Dim ChargesAmount As Double = CDbl(View.GetRowCellValue(e.RowHandle, colChargesOrigAmount1).ToString)

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

        If ChargesAmount = 0 Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CHARGES_AMOUNT, "The Charges Amount must not be zero")
            e.ErrorText = "The Charges Amount must not be zero"
        End If

    End Sub

    Private Sub SettlementCharges_GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles SettlementCharges_GridView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ConditionName"), "Condition Name")
        view.SetRowCellValue(e.RowHandle, view.Columns("ChargesCCY"), "EUR")
        view.SetRowCellValue(e.RowHandle, view.Columns("ChargesOrigAmount"), 1)
    End Sub

    Private Sub DiscountCalculation_btn_Click(sender As Object, e As EventArgs) Handles DiscountCalculation_btn.Click
        VALIDATIONS_DISCOUNT_ADD()
        Try
            Dim InvoiceAmount As Double = 0
            Dim d1 As Date
            Dim d2 As Date
            Dim InterestDays As Double = 0
            Dim InterestRate As Double = 0
            Dim Marge As Double = 0
            Dim DiscountInterestRate As Double = 0
            Dim DiscountAmount As Double = 0

            If Me.DxValidationProvider2.Validate() = True Then
                d1 = Me.InterestDateFrom_DateEdit.EditValue
                d2 = Me.InterestDateTill_DateEdit.EditValue
                If d2 > d1 Then
                    InvoiceAmount = Me.InvoiceAmount_SpinEdit.EditValue
                    InterestDays = DateDiff(DateInterval.Day, d1, d2)
                    InterestRate = Me.InterestRate_SpinEdit.EditValue
                    Marge = Me.Marge_SpinEdit.EditValue
                    DiscountInterestRate = InterestRate + Marge
                    Dim InterestMethod As String = Me.InterestMethod_ComboEdit.EditValue
                    Select Case InterestMethod
                        Case = "ACT/360"
                            DiscountAmount = InvoiceAmount * InterestDays * DiscountInterestRate / 360
                        Case = "ACT/365"
                            DiscountAmount = InvoiceAmount * InterestDays * DiscountInterestRate / 365
                    End Select
                    Me.DiscountInterestRate_SpinEdit.EditValue = DiscountInterestRate
                    Me.InterestDaysCount_SpinEdit.EditValue = InterestDays
                    Me.DiscountAmount_SpinEdit.EditValue = DiscountAmount
                    SettlementSave_btn.PerformClick()
                    DiscountCalculation_btn.Focus()

                Else
                    MessageBox.Show("The Date till must be higher than Date from!", "DATES ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Else
                MessageBox.Show("Validation Failed!", "VALIDATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

    End Sub

    Private Sub DiscountResetCalculation_btn_Click(sender As Object, e As EventArgs) Handles DiscountResetCalculation_btn.Click
        VALIDATIONS_DISCOUNT_REMOVE()
        Me.InterestDateFrom_DateEdit.EditValue = DBNull.Value
        Me.InterestDateTill_DateEdit.EditValue = DBNull.Value
        Me.InterestRate_SpinEdit.EditValue = 0
        Me.Marge_SpinEdit.EditValue = 0
        Me.DiscountInterestRate_SpinEdit.EditValue = 0
        Me.InterestDaysCount_SpinEdit.EditValue = 0
        Me.DiscountAmount_SpinEdit.EditValue = 0
        SettlementSave_btn.PerformClick()
        DiscountResetCalculation_btn.Focus()

    End Sub



    Private Sub SettlementApplBank_RadioGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SettlementApplBank_RadioGroup.EditValueChanged
        If Me.LayoutControl1.Visible = False AndAlso SettlementApplBank_RadioGroup.Focused = True Then
            Dim Edit As RadioGroup = CType(sender, RadioGroup)
            Dim InvoiceCCY As String = Me.InvoiceCCY_GridLookUpEdit.EditValue
            If InvoiceCCY IsNot Nothing Then
                If (Edit.SelectedIndex = 0) Then
                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "We will debit your Internal Account:  with us for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & Me.SettelemntReference_lbl.Text
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "We will debit your Internal Account:  with us."
                        End If
                    End If

                ElseIf (Edit.SelectedIndex = 1) Then
                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "Please credit our Account Nr.: with  for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & Me.SettelemntReference_lbl.Text
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "Please credit our Account Nr.: with "
                        End If
                    End If

                ElseIf (Edit.SelectedIndex = 2) Then

                    If Me.SettlementApplBankText_TextEdit.Text = "" Then
                        Me.SettlementApplBankText_TextEdit.Text = "We have reimbursed ourselves on: " & vbNewLine & "for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & Me.SettelemntReference_lbl.Text
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.SettlementApplBankText_TextEdit.Text = "We have reimbursed ourselves on: " & vbNewLine & "for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "quoting our Reference: " & Me.SettelemntReference_lbl.Text
                        End If
                    End If
                ElseIf (Edit.SelectedIndex = 3) Then

                    If Me.SettlementApplBankText_TextEdit.Text = "" Then

                        Select Case InvoiceCCY
                            Case = "EUR"
                                Me.SettlementApplBankText_TextEdit.Text = "Please remit proceeds through your EURO clearing for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & Me.SettelemntReference_lbl.Text
                            Case <> "EUR"
                                cmdSQL.CommandText = "SELECT * from [SSIS] where [CURRENCY CODE]='" & InvoiceCCY & "' and [LcSettlement]=1"
                                Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
                                Dim dt As New DataTable
                                daSql.Fill(dt)
                                If dt.Rows.Count > 0 Then
                                    Me.SettlementApplBankText_TextEdit.Text = "Credit our Accounty by " & dt.Rows.Item(0).Item("CORRESPONDENT NAME") & " (BIC:" & dt.Rows.Item(0).Item("CORRESPONDENT BIC") & ") for " & InvoiceCCY & " " & Me.InvoiceAmount_SpinEdit.EditValue.ToString & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & Me.SettelemntReference_lbl.Text
                                End If
                        End Select
                    Else
                        If MessageBox.Show("Should the current Settlement text be deleted?", "SETTLEMENT TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Select Case InvoiceCCY
                                Case = "EUR"
                                    Me.SettlementApplBankText_TextEdit.Text = "Please remit proceeds through your EURO clearing for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & Me.SettelemntReference_lbl.Text
                                Case <> "EUR"
                                    cmdSQL.CommandText = "SELECT * from [SSIS] where [CURRENCY CODE]='" & InvoiceCCY & "' and [LcSettlement]=1"
                                    Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
                                    Dim dt As New DataTable
                                    daSql.Fill(dt)
                                    If dt.Rows.Count > 0 Then
                                        Me.SettlementApplBankText_TextEdit.Text = "Credit our Accounty by " & dt.Rows.Item(0).Item("CORRESPONDENT NAME") & " (BIC:" & dt.Rows.Item(0).Item("CORRESPONDENT BIC") & ") for " & InvoiceCCY & " " & FormatNumber(Me.InvoiceAmount_SpinEdit.EditValue, 2) & vbNewLine & "favoring CCB Frankfurt Branch, BIC:PCBCDEFF, quoting our Reference: " & Me.SettelemntReference_lbl.Text
                                    End If
                            End Select
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub FORFAITING_CONTRACT_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Forfaiting Contract creation")

            Dim FORFAITING_CONTRACT_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_FORFAITING_CONTRACT" Then
                    FORFAITING_CONTRACT_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            Dim PercentageTollerance As String = Nothing
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim TempString As String = Nothing
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":39A:") = True Then
                    TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
                    Dim i As Integer = TempString.IndexOf("/")
                    Dim Percentage As String() = TempString.Split("/")
                    If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
                        PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
                    End If

                    'LatestDateOfShipment = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))

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
                MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "DECLARE @LC_REFERENCE nvarchar(max)='" & Me.OurReferenceSearch_GridLookUpEdit.Text & "'
                            DECLARE @CUSTOMER_ID int=" & CInt(RelatedCustomerID) & "
                            DECLARE @LC_AMOUNT float=(Select [LC_Amount] from [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "')
                            DECLARE @RISKDATE Datetime=(select cast(convert(varchar(10), getdate(), 110) as datetime))

                            CREATE TABLE [#Temp_EXPORT_LC_MT700_Settlements_Charges](
	                            [ID] [int] IDENTITY(1,1) NOT NULL,
	                            [ConditionName] [nvarchar](100) NOT NULL,
	                            [ConditionCyclus] [nvarchar](10) NULL,
	                            [ConditionType] [nvarchar](10) NULL,
	                            [ConditionPercent] [float] NULL,
	                            [ConditionMin] [float] NULL,
	                            [ConditionMax] [float] NULL,
	                            [ChargesCCY] [nvarchar](50) NULL,
	                            [ChargesOrigAmount] [float] NULL,
	                            [ExchangeRate] [float] NULL,
	                            [ChargesEUR] [float] NULL,
	                            [Notes] [ntext] NULL,
	                            [IdExportLcSettlement] [int] NULL) 

                            INSERT INTO [#Temp_EXPORT_LC_MT700_Settlements_Charges]
                            ([ConditionName]
                            ,[ConditionCyclus]
                            ,[ConditionType]
							,[ChargesCCY]
                            ,[ConditionPercent]
                            ,[ConditionMin]
                            ,[ConditionMax]
                            ,[Notes])
                            SELECT 
                             [ConditionName]
                            ,[ConditionCyclus]
                            ,[ConditionType]
							,'EUR'
                            ,[ConditionPercent]
                            ,[ConditionMin]
                            ,[ConditionMax]
                            ,[Notes]
                            FROM [EXPORT_LC_CUSTOMERS_Conditions] where [IdExportLcCustomers]=@CUSTOMER_ID

                            UPDATE [#Temp_EXPORT_LC_MT700_Settlements_Charges] SET [ChargesOrigAmount]=ROUND([ConditionPercent]*@LC_AMOUNT,2) 
  
                            UPDATE [#Temp_EXPORT_LC_MT700_Settlements_Charges] 
                            SET [ChargesOrigAmount]=Case when [ChargesOrigAmount]<[ConditionMin] then [ConditionMin] 
                            when [ChargesOrigAmount]>[ConditionMax] then [ConditionMax] else [ChargesOrigAmount] end


                            UPDATE [#Temp_EXPORT_LC_MT700_Settlements_Charges] SET [ChargesOrigAmount]=0 where [ChargesOrigAmount] is NULL"
            cmd.ExecuteNonQuery()
            Me.QueryText = "Select * from #Temp_EXPORT_LC_MT700_Settlements_Charges"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                Next
            End If
            cmd.CommandText = "DROP TABLE #Temp_EXPORT_LC_MT700_Settlements_Charges"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If



            SplashScreenManager.Default.SetWaitFormCaption("Create Forfaiting Contract form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Forfaiting contract Form"
            c.RichEditControl1.LoadDocument(FORFAITING_CONTRACT_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            Dim OurReferencePos As DocumentPosition = myHeader.Bookmarks("OurReference").Range.End
            myHeader.InsertText(OurReferencePos, OurReferenceSearch)
            Dim LcNrPos As DocumentPosition = myHeader.Bookmarks("LcReference").Range.End
            myHeader.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            myHeader.Fields.Update()
            firstSection.EndUpdateHeader(myHeader)

            Dim DiscontContractDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DiscontContractDate").Range.End
            c.RichEditControl1.Document.InsertText(DiscontContractDatePos, Me.ForfaitingContractDate_DateEdit.EditValue)

            Dim OurReferencePos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference1").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos1, OurReferenceSearch)

            Dim LcNrPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcReference1").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos1, Me.LC_Nr_TextEdit.Text)
            Dim LcNrPos2 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcReference2").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos2, Me.LC_Nr_TextEdit.Text)

            Dim OurBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankName").Range.End
            c.RichEditControl1.Document.InsertText(OurBankNamePos, OUR_BANK_NAME)
            Dim OurBankBranchPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankBranch").Range.End
            c.RichEditControl1.Document.InsertText(OurBankBranchPos, OUR_BANK_BRANCH)
            Dim OurBankAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankStrasse").Range.End
            c.RichEditControl1.Document.InsertText(OurBankAddressPos, OUR_BANK_STRASSE)
            Dim OurBankZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankPLZ").Range.End
            c.RichEditControl1.Document.InsertText(OurBankZipCodePos, OUR_BANK_PLZ)
            Dim OurBankCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankOrt").Range.End
            c.RichEditControl1.Document.InsertText(OurBankCityPos, OUR_BANK_ORT)
            Dim OurBankALLPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankALL").Range.End
            c.RichEditControl1.Document.InsertText(OurBankALLPos, OUR_BANK_NAME & ", " & OUR_BANK_BRANCH & ", " & OUR_BANK_STRASSE & ", " & OUR_BANK_PLZ & " " & OUR_BANK_ORT)


            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerNamePos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos1, CustomerName)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerStrasse").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerPLZ").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerOrt").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)

            Dim ApplicantNameALLPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantALL").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantNameALLPos, ApplicantName & ", " & ApplicantAddress & ", " & ApplicantZipCodeCity & ", " & ApplicantCountry)

            Dim ApplicantBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBank").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankPos, ApplicantBankName)
            Dim ApplicantBankPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBank1").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankPos1, ApplicantBankName)

            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcCCY").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcAmount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, FormatNumber(Me.LcAmount_Textedit.Text, 2))
            Dim PercentageTollerancePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PercentageTollerance").Range.End
            c.RichEditControl1.Document.InsertText(PercentageTollerancePos, PercentageTollerance)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcValidDate").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcValidCountry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)

            Dim DiscountConditionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DiscountConditions").Range.End
            c.RichEditControl1.Document.InsertText(DiscountConditionsPos, Me.ForfaitingConditions_MemoEdit.Text)
            Dim MaturityDiscountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDiscount").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDiscountPos, Me.ForfaitingMaturityDetails_MemoEdit.Text)

            Dim ChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Charges").Range.End
            c.RichEditControl1.Document.InsertText(ChargesPos, CHARGES)

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

    Private Sub NEGO_BANK_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Nego Bank document creation")
            Dim NEGO_BANK_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_NEGO_BANK" Then
                    NEGO_BANK_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            'Dim PercentageTollerance As String = Nothing
            'Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            'Dim TempString As String = Nothing
            'Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            'For Each line As String In TextLines
            '    If line.StartsWith(":39A:") = True Then
            '        TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
            '        Dim i As Integer = TempString.IndexOf("/")
            '        Dim Percentage As String() = TempString.Split("/")
            '        If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
            '            PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
            '        End If
            '    End If
            'Next

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

            'Me.QueryText = "SELECT * FROM [EXPORT_LC_CUSTOMERS] where [ID]=" & RelatedCustomerID & ""
            'da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        CustomerID = dt.Rows.Item(i).Item("CustomerID")
            '        CustomerName = dt.Rows.Item(i).Item("CustomerName")
            '        If dt.Rows.Item(i).Item("CustomerAddress1") IsNot DBNull.Value Then
            '            CustomerNameAddress = dt.Rows.Item(i).Item("CustomerAddress1")
            '        End If
            '        If dt.Rows.Item(i).Item("CustomerAddress2") IsNot DBNull.Value Then
            '            CustomerAddress = dt.Rows.Item(i).Item("CustomerAddress2")
            '        End If
            '        CustomerZipCode = dt.Rows.Item(i).Item("CustomerZipCode")
            '        CustomerCity = dt.Rows.Item(i).Item("CustomerCity")
            '        If dt.Rows.Item(i).Item("CustomerFon") IsNot DBNull.Value Then
            '            CustomerFon = dt.Rows.Item(i).Item("CustomerFon")
            '        End If
            '        If dt.Rows.Item(i).Item("CustomerFax") IsNot DBNull.Value Then
            '            CustomerFax = dt.Rows.Item(i).Item("CustomerFax")
            '        End If
            '        If dt.Rows.Item(i).Item("CustomerEmail") IsNot DBNull.Value Then
            '            CustomerEmail = dt.Rows.Item(i).Item("CustomerEmail")
            '        End If
            '        If dt.Rows.Item(i).Item("ContactPerson1") IsNot DBNull.Value Then
            '            CustomerContact1 = dt.Rows.Item(i).Item("ContactPerson1")
            '        End If
            '        If dt.Rows.Item(i).Item("ContactPerson2") IsNot DBNull.Value Then
            '            CustomerContact2 = dt.Rows.Item(i).Item("ContactPerson2")
            '        End If
            '        If dt.Rows.Item(i).Item("LcAdviceEmail") IsNot DBNull.Value Then
            '            CustomerLcAdviceEmail = dt.Rows.Item(i).Item("LcAdviceEmail")
            '        End If
            '    Next
            'Else
            '    MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            '    Return
            'End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Discount Parameters
            Dim DiscontMaturityCalculated As String = Nothing
            Dim DiscontConditionsText As String = Nothing
            Dim DiscontContractDate As Date = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "' and [DiscontMaturityCalculated] is not NULL and [DiscontConditionsText] is not NULL and [DiscontContractDate] is not NULL"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                DiscontMaturityCalculated = dt.Rows.Item(0).Item("DiscontMaturityCalculated")
                DiscontConditionsText = dt.Rows.Item(0).Item("DiscontConditionsText")
                If IsDBNull(dt.Rows.Item(0).Item("DiscontContractDate")) = False Then
                    DiscontContractDate = dt.Rows.Item(0).Item("DiscontContractDate")
                End If
            End If

            'Get Charges details
            'Dim CHARGES As String = Nothing
            'Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "'"
            'da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New DataTable()
            'da.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
            '    Next
            'End If


            SplashScreenManager.Default.SetWaitFormCaption("Create Nego Bank form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Nego Bank Form"
            c.RichEditControl1.LoadDocument(NEGO_BANK_FORM)
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

            Dim OurReferencePos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos1, Me.SettelemntReference_lbl.Text)

            Dim LcNrPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcReference").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos1, Me.LC_Nr_TextEdit.Text)


            Dim ApplicantBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBankName").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankNamePos, ApplicantBankName)
            Dim ApplicantBankStreetPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBankStreet").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankStreetPos, ApplicantBankAddress)
            Dim ApplicantBankZipCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBankZipCity").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankZipCityPos, ApplicantBankZipCodeCity)
            Dim ApplicantBankCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBankCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankCountryPos, ApplicantBankCountry)

            Dim InvoiceCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCurrencyPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))

            Dim InvoiceCurrencyPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY1").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCurrencyPos1, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount1").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos1, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))

            Dim PayInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PayInstructions").Range.End
            c.RichEditControl1.Document.InsertText(PayInstructionsPos, Me.SettlementApplBankText_TextEdit.Text)
            Dim AdditionalInfoPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AdditionalInfo").Range.End
            c.RichEditControl1.Document.InsertText(AdditionalInfoPos, Me.SettlementApplBankInfo_MemoEdit.Text)

            Dim MaturityDiscountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDiscount").Range.End
            If DiscontMaturityCalculated <> "" Then
                c.RichEditControl1.Document.InsertText(MaturityDiscountPos, "( " & DiscontMaturityCalculated & " )")
            End If
            Dim MaturityDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos, Me.MaturityDate_DateEdit.Text)


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

    Private Sub NEGO_CUSTOMER_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Nego customer document creation")
            Dim NEGO_CUSTOMER_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_NEGO_CUSTOMER" Then
                    NEGO_CUSTOMER_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            'Dim PercentageTollerance As String = Nothing
            'Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            'Dim TempString As String = Nothing
            'Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            'For Each line As String In TextLines
            '    If line.StartsWith(":39A:") = True Then
            '        TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
            '        Dim i As Integer = TempString.IndexOf("/")
            '        Dim Percentage As String() = TempString.Split("/")
            '        If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
            '            PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
            '        End If
            '    End If
            'Next

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
                MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Discount Parameters
            Dim DiscontMaturityCalculated As String = Nothing
            Dim DiscontConditionsText As String = Nothing
            Dim DiscontContractDate As Date = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "' and [DiscontMaturityCalculated] is not NULL and [DiscontConditionsText] is not NULL and [DiscontContractDate] is not NULL"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                DiscontMaturityCalculated = dt.Rows.Item(0).Item("DiscontMaturityCalculated")
                DiscontConditionsText = dt.Rows.Item(0).Item("DiscontConditionsText")
                If IsDBNull(dt.Rows.Item(0).Item("DiscontContractDate")) = False Then
                    DiscontContractDate = dt.Rows.Item(0).Item("DiscontContractDate")
                End If
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "' and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                Next
            End If
            Dim CHARGES_Amount As Double = 0
            Dim NETTO_Amount As Double = 0
            Dim INVOICE_Amount As Double = Me.InvoiceAmount_SpinEdit.EditValue
            Me.QueryText = "Select 'SumCharges'=Case when Sum(ChargesOrigAmount) is not NULL then Sum(ChargesOrigAmount) else 0 end  from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                CHARGES_Amount = dt.Rows.Item(0).Item("SumCharges")
            End If
            NETTO_Amount = INVOICE_Amount - CHARGES_Amount


            SplashScreenManager.Default.SetWaitFormCaption("Create Nego Customer form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Nego Customer Form"
            c.RichEditControl1.LoadDocument(NEGO_CUSTOMER_FORM)
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

            Dim SchreibenKundeDatumPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeDatum").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeDatumPos, Me.CustomerLetterDate_DateEdit.Text)
            Dim SchreibenKundeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeName").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeNamePos, Me.CustomerContactName_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)

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

            Dim ApplicantNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantName").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantNamePos, ApplicantName)
            Dim ApplicantAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantAddress").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantAddressPos, ApplicantAddress)
            Dim ApplicantZipCodeCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantZipCodeCity").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantZipCodeCityPos, ApplicantZipCodeCity)
            Dim ApplicantCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantCountryPos, ApplicantCountry)

            Dim InvoiceCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCurrencyPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))


            Dim ChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CHARGES").Range.End
            c.RichEditControl1.Document.InsertText(ChargesPos, CHARGES)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PayInstructions").Range.End
            If Me.SettlementType_lbl.Text = "I" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir werden nach Eingang von der Akkreditivbank zu unserer freien Verfügung den Betrag auf Ihr Konto: (" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei uns gutschreiben. Fremde Spesen werden in Abzug gebracht.")
            ElseIf Me.SettlementType_lbl.Text = "E" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir überweisen Ihnen auf Ihr Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text & " " & " nach  Eingang des Betrages von der Akkreditivbank zu unserer freien Verfügung. Fremde Spesen werden in Abzug gebracht.")
            End If


            Dim NettoCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoCCY").Range.End
            c.RichEditControl1.Document.InsertText(NettoCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim NettoAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoAmount").Range.End
            c.RichEditControl1.Document.InsertText(NettoAmountPos, FormatNumber(NETTO_Amount, 2))

            Dim MaturityDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos, Me.MaturityDate_DateEdit.Text)
            Dim MaturityDiscountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDiscount").Range.End
            If DiscontMaturityCalculated <> "" Then
                c.RichEditControl1.Document.InsertText(MaturityDiscountPos, "( " & DiscontMaturityCalculated & " )")
            End If

            Dim ApplicantBankInfoPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBankInfo").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankInfoPos, Me.SettlementInstructionsCustomer_MemoEdit.Text)
            Dim CustomerInfoPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerInfo").Range.End
            c.RichEditControl1.Document.InsertText(CustomerInfoPos, Me.AdditionalInfoToCustomer_MemoEdit.Text)




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

    Private Sub MIITEILUNG__FAELLIGKEIT_CUSTOMER_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Maturity Advice document creation")
            Dim LC_MITTEILUNG_FAELLIGKEIT_CUSTOMER_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_MITTEILUNG_FAELLIGKEIT_CUSTOMER" Then
                    LC_MITTEILUNG_FAELLIGKEIT_CUSTOMER_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            'Dim PercentageTollerance As String = Nothing
            'Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            'Dim TempString As String = Nothing
            'Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            'For Each line As String In TextLines
            '    If line.StartsWith(":39A:") = True Then
            '        TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
            '        Dim i As Integer = TempString.IndexOf("/")
            '        Dim Percentage As String() = TempString.Split("/")
            '        If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
            '            PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
            '        End If
            '    End If
            'Next

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
                MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "' and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                Next
            End If
            Dim CHARGES_Amount As Double = 0
            Dim NETTO_Amount As Double = 0
            Dim INVOICE_Amount As Double = Me.InvoiceAmount_SpinEdit.EditValue
            Me.QueryText = "Select 'SumCharges'=Case when Sum(ChargesOrigAmount) is not NULL then Sum(ChargesOrigAmount) else 0 end  from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                CHARGES_Amount = dt.Rows.Item(0).Item("SumCharges")
            End If
            NETTO_Amount = INVOICE_Amount - CHARGES_Amount


            SplashScreenManager.Default.SetWaitFormCaption("Create Maturity Advice to Customer form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Maturity Advice to Customer Form"
            c.RichEditControl1.LoadDocument(LC_MITTEILUNG_FAELLIGKEIT_CUSTOMER_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            'Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            'Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            'Dim OurReferencePos As DocumentPosition = myHeader.Bookmarks("OurReference").Range.End
            'myHeader.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            'Dim LcNrPos As DocumentPosition = myHeader.Bookmarks("LcReference").Range.End
            'myHeader.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            'myHeader.Fields.Update()
            'firstSection.EndUpdateHeader(myHeader)

            Dim SchreibenKundeDatumPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeDatum").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeDatumPos, Me.CustomerLetterDate_DateEdit.Text)
            Dim SchreibenKundeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeName").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeNamePos, Me.CustomerContactName_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)

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

            Dim ApplicantNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantName").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantNamePos, ApplicantName)
            Dim ApplicantAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantAddress").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantAddressPos, ApplicantAddress)
            Dim ApplicantZipCodeCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantZipCodeCity").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantZipCodeCityPos, ApplicantZipCodeCity)
            Dim ApplicantCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantCountryPos, ApplicantCountry)

            Dim InvoiceCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCurrencyPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))


            Dim ChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CHARGES").Range.End
            c.RichEditControl1.Document.InsertText(ChargesPos, CHARGES)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PayInstructions").Range.End
            If Me.SettlementType_lbl.Text = "I" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir werden nach Eingang von der Akkreditivbank zu unserer freien Verfügung den Betrag auf Ihr Konto: (" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei uns gutschreiben. Fremde Spesen werden in Abzug gebracht.")
            ElseIf Me.SettlementType_lbl.Text = "E" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir überweisen Ihnen auf Ihr Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text & " " & " nach  Eingang des Betrages von der Akkreditivbank zu unserer freien Verfügung. Fremde Spesen werden in Abzug gebracht.")
            End If


            Dim NettoCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoCCY").Range.End
            c.RichEditControl1.Document.InsertText(NettoCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim NettoAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoAmount").Range.End
            c.RichEditControl1.Document.InsertText(NettoAmountPos, FormatNumber(NETTO_Amount, 2))

            Dim MaturityDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos, Me.MaturityDate_DateEdit.Text)
            Dim MaturityDatePos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate1").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos1, Me.MaturityDate_DateEdit.Text)
            Dim MaturityDatePos2 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate2").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos2, Me.MaturityDate_DateEdit.Text)

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

    Private Sub PAYMENT_ADVICE_CUSTOMER_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Payment Advice document creation")
            Dim LC_PAYMENT_ADVICE_CUSTOMER_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_ZAHLUNGAVIS_CUSTOMER" Then
                    LC_PAYMENT_ADVICE_CUSTOMER_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            'Dim PercentageTollerance As String = Nothing
            'Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            'Dim TempString As String = Nothing
            'Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            'For Each line As String In TextLines
            '    If line.StartsWith(":39A:") = True Then
            '        TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
            '        Dim i As Integer = TempString.IndexOf("/")
            '        Dim Percentage As String() = TempString.Split("/")
            '        If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
            '            PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
            '        End If
            '    End If
            'Next

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
                MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "' and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                Next
            End If
            Dim CHARGES_Amount As Double = 0
            Dim NETTO_Amount As Double = 0
            Dim INVOICE_Amount As Double = Me.InvoiceAmount_SpinEdit.EditValue
            Me.QueryText = "Select 'SumCharges'=Case when Sum(ChargesOrigAmount) is not NULL then Sum(ChargesOrigAmount) else 0 end  from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                CHARGES_Amount = dt.Rows.Item(0).Item("SumCharges")
            End If
            NETTO_Amount = INVOICE_Amount - CHARGES_Amount


            SplashScreenManager.Default.SetWaitFormCaption("Create Payment Advice form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Payment Advice to Customer Form"
            c.RichEditControl1.LoadDocument(LC_PAYMENT_ADVICE_CUSTOMER_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            'Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            'Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            'Dim OurReferencePos As DocumentPosition = myHeader.Bookmarks("OurReference").Range.End
            'myHeader.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            'Dim LcNrPos As DocumentPosition = myHeader.Bookmarks("LcReference").Range.End
            'myHeader.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            'myHeader.Fields.Update()
            'firstSection.EndUpdateHeader(myHeader)

            Dim SchreibenKundeDatumPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeDatum").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeDatumPos, Me.CustomerLetterDate_DateEdit.Text)
            Dim SchreibenKundeNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("SchreibenKundeName").Range.End
            c.RichEditControl1.Document.InsertText(SchreibenKundeNamePos, Me.CustomerContactName_TextEdit.Text)

            Dim OurReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)

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

            Dim ApplicantNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantName").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantNamePos, ApplicantName)
            Dim ApplicantAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantAddress").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantAddressPos, ApplicantAddress)
            Dim ApplicantZipCodeCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantZipCodeCity").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantZipCodeCityPos, ApplicantZipCodeCity)
            Dim ApplicantCountryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantCountry").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantCountryPos, ApplicantCountry)

            Dim InvoiceCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCurrencyPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))


            Dim ChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CHARGES").Range.End
            c.RichEditControl1.Document.InsertText(ChargesPos, CHARGES)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PayInstructions").Range.End
            If Me.SettlementType_lbl.Text = "I" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir haben den Betrag auf Ihr Konto: (" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei uns gutgeschrieben. Fremde Spesen wurden in Abzug gebracht.")
            ElseIf Me.SettlementType_lbl.Text = "E" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir haben auf Ihr Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text & " " & " den Betrag überwiesen. Fremde Spesen wurden in Abzug gebracht.")
            End If


            Dim NettoCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoCCY").Range.End
            c.RichEditControl1.Document.InsertText(NettoCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim NettoAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("NettoAmount").Range.End
            c.RichEditControl1.Document.InsertText(NettoAmountPos, FormatNumber(NETTO_Amount, 2))

            Dim MaturityDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos, Me.MaturityDate_DateEdit.Text)

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

    Private Sub FORFAITING_CONFIRMATION_DOCUMENT()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Forfaiting Contract creation")
            Dim FORFAITING_CONFIRMATION_FORM As String = Nothing
            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='FOREIGN_DOCS'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "LC_FORFAITING_CONFIRMATION" Then
                    FORFAITING_CONFIRMATION_FORM = dt.Rows.Item(i).Item("PARAMETER2")
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

            'Get Percentage Tolerance
            Dim PercentageTollerance As String = Nothing
            Dim SwiftNachricht As String = Me.Swift_MessageLabel1.Text
            Dim TempString As String = Nothing
            Dim TextLines() As String = SwiftNachricht.Split(Environment.NewLine.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
            For Each line As String In TextLines
                If line.StartsWith(":39A:") = True Then
                    TempString = Microsoft.VisualBasic.Mid(line.Trim, 6, 10)
                    Dim i As Integer = TempString.IndexOf("/")
                    Dim Percentage As String() = TempString.Split("/")
                    If Percentage(0) <> "0" Or Percentage(1) <> "0" Then
                        PercentageTollerance = "-" & Percentage(0) & "% / " & "+" & Percentage(1) & "%"
                    End If

                    'LatestDateOfShipment = DateSerial(Microsoft.VisualBasic.Left(TempString, 2), Microsoft.VisualBasic.Mid(TempString, 3, 2), Microsoft.VisualBasic.Right(TempString, 2))

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
                MessageBox.Show("Customer not fund in the LC EXPORT Customers Table!" & vbNewLine & "Please check!", "CUSTOMER NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Applicant Parameters
            Dim ApplicantName As String = Nothing
            Dim ApplicantAddress As String = Nothing
            Dim ApplicantZipCodeCity As String = Nothing
            Dim ApplicantCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('A') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantName = dt.Rows.Item(i).Item("Name")
                    ApplicantAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant details for this LC!", "APPLICANT DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If


            'Applicant Bank Parameters
            Dim ApplicantBankName As String = Nothing
            Dim ApplicantBankAddress As String = Nothing
            Dim ApplicantBankZipCodeCity As String = Nothing
            Dim ApplicantBankCountry As String = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700_Settlements_ApplNameAddress] where [NameType] in ('B') and  [Id_OurReference]='" & OurReferenceSearch & "'"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ApplicantBankName = dt.Rows.Item(i).Item("Name")
                    ApplicantBankAddress = dt.Rows.Item(i).Item("Address")
                    ApplicantBankZipCodeCity = dt.Rows.Item(i).Item("ZipCode_City")
                    ApplicantBankCountry = dt.Rows.Item(i).Item("CountryName")
                Next
            Else
                MessageBox.Show("Applicant Bank Details are not fund for this LC!" & vbNewLine & "Please add and link Applicant Bank details for this LC!", "APPLICANT BANK DETAILS LINKAGE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return
            End If

            'Discount Parameters
            Dim DiscontMaturityCalculated As String = Nothing
            Dim DiscontConditionsText As String = Nothing
            Dim DiscontContractDate As Date = Nothing
            Me.QueryText = "SELECT * FROM [EXPORT_LC_MT700] where [OurReference]='" & OurReferenceSearch & "' and [DiscontMaturityCalculated] is not NULL and [DiscontConditionsText] is not NULL and [DiscontContractDate] is not NULL"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                DiscontMaturityCalculated = dt.Rows.Item(0).Item("DiscontMaturityCalculated")
                DiscontConditionsText = dt.Rows.Item(0).Item("DiscontConditionsText")
                If IsDBNull(dt.Rows.Item(0).Item("DiscontContractDate")) = False Then
                    DiscontContractDate = dt.Rows.Item(0).Item("DiscontContractDate")
                End If
            End If

            'Get Charges details
            Dim CHARGES As String = Nothing
            Dim CHARGES_NAMES As String = Nothing
            Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "' and [ChargesOrigAmount]<>0"
            da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    CHARGES += dt.Rows.Item(i).Item("ConditionName") & ": " & dt.Rows.Item(i).Item("ChargesCCY") & " " & FormatNumber(dt.Rows.Item(i).Item("ChargesOrigAmount"), 2) & vbNewLine
                    CHARGES_NAMES += dt.Rows.Item(i).Item("ConditionName") & ","
                Next
            End If


            SplashScreenManager.Default.SetWaitFormCaption("Create Forfaiting Confirmation form")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "LC Forfaiting Confirmation Form"
            c.RichEditControl1.LoadDocument(FORFAITING_CONFIRMATION_FORM)
            'c.RichEditControl1.ReadOnly = True
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            'Dim newText As String = "New text"
            'Dim length As Integer = newText.Length

            'Access Document Header
            'Dim firstSection As DevExpress.XtraRichEdit.API.Native.Section = c.RichEditControl1.Document.Sections(0)
            'Dim myHeader As SubDocument = firstSection.BeginUpdateHeader()
            'Dim OurReferencePos As DocumentPosition = myHeader.Bookmarks("OurReference").Range.End
            'myHeader.InsertText(OurReferencePos, Me.SettelemntReference_lbl.Text)
            'Dim LcNrPos As DocumentPosition = myHeader.Bookmarks("LcReference").Range.End
            'myHeader.InsertText(LcNrPos, Me.LC_Nr_TextEdit.Text)
            'myHeader.Fields.Update()
            'firstSection.EndUpdateHeader(myHeader)

            'Charges Details
            Dim ChargesDetailsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ChargesTable").Range.End
            Dim tbl As DevExpress.XtraRichEdit.API.Native.Table = c.RichEditControl1.Document.Tables.Create(ChargesDetailsPos, 1, 3, AutoFitBehaviorType.AutoFitToContents)
            c.RichEditControl1.Document.InsertText(tbl(0, 0).Range.Start, "Abrechnungsdetails")
            c.RichEditControl1.Document.InsertText(tbl(0, 1).Range.Start, "Währung")
            c.RichEditControl1.Document.InsertText(tbl(0, 2).Range.Start, "Betrag")
            Try
                tbl.BeginUpdate()
                'Get Invoice details
                Me.QueryText = "Select [InvoiceCCY],[InvoiceAmount] from [EXPORT_LC_MT700_Settlements] where [SettlementNr]='" & Me.SettlementNr_lbl.Text & "' and  [Id_OurReference]='" & OurReferenceSearch & "'"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Rechnungsbetrag:"
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("InvoiceAmount"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If

                'Get Discount
                Me.QueryText = "Select [InvoiceCCY],[DiscountCalcAmount] from [EXPORT_LC_MT700_Settlements] where [SettlementNr]='" & Me.SettlementNr_lbl.Text & "' and  [Id_OurReference]='" & OurReferenceSearch & "'"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "abzgl. Diskont"
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("DiscountCalcAmount"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If
                'Get other Charges
                Me.QueryText = "Select * from [EXPORT_LC_MT700_Settlements_Charges] where [IdExportLcSettlement]='" & Me.SettlementID_lbl.Text & "' and [ChargesOrigAmount]<>0"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
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
                Me.QueryText = "Select [InvoiceCCY],[NettoAmountCustomer] from [EXPORT_LC_MT700_Settlements] where [SettlementNr]='" & Me.SettlementNr_lbl.Text & "' and  [Id_OurReference]='" & OurReferenceSearch & "'"
                da = New OleDbDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                    Dim cell As TableCell = row.FirstCell
                    Dim BetragName As String = "Nettoerlös."
                    Dim CCY As String = dt.Rows.Item(0).Item("InvoiceCCY")
                    Dim Amount As String = String.Format("{0:N2}", dt.Rows.Item(0).Item("NettoAmountCustomer"))
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Range.Start, BetragName)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Range.Start, CCY)
                    c.RichEditControl1.Document.InsertSingleLineText(cell.Next.Next.Range.Start, Amount)
                End If

                'For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.Range)
                '    p.Alignment = ParagraphAlignment.Right
                '    Dim range As DocumentRange = p.Range
                '    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                '    titleFormatting.FontSize = 11
                '    titleFormatting.Bold = True
                '    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                'Next p
                ' Center the table header.
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.FirstRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 11
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p
                For Each p As Paragraph In c.RichEditControl1.Document.Paragraphs.Get(tbl.LastRow.Range)
                    p.Alignment = ParagraphAlignment.Left
                    p.BackColor = Color.LightGray
                    Dim range As DocumentRange = p.Range
                    Dim titleFormatting As CharacterProperties = c.RichEditControl1.Document.BeginUpdateCharacters(range)
                    titleFormatting.FontSize = 11
                    titleFormatting.Bold = True
                    c.RichEditControl1.Document.EndUpdateCharacters(titleFormatting)
                Next p

                For i As Integer = 0 To tbl.Rows.Count() - 1
                    Dim props As ParagraphProperties = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(0).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(1).Range)
                    props.Alignment = ParagraphAlignment.Center
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                    props = c.RichEditControl1.Document.BeginUpdateParagraphs(tbl.Rows(i).Cells(2).Range)
                    props.Alignment = ParagraphAlignment.Right
                    c.RichEditControl1.Document.EndUpdateParagraphs(props)
                Next
            Finally
                tbl.EndUpdate()
            End Try




            Dim OurReferencePos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference1").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos1, Me.SettelemntReference_lbl.Text)
            Dim OurReferencePos2 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference2").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos2, Me.SettelemntReference_lbl.Text)
            Dim OurReferencePos3 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurReference3").Range.End
            c.RichEditControl1.Document.InsertText(OurReferencePos3, Me.SettelemntReference_lbl.Text)

            Dim LcNrPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcReference1").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos1, Me.LC_Nr_TextEdit.Text)
            Dim LcNrPos2 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcReference2").Range.End
            c.RichEditControl1.Document.InsertText(LcNrPos2, Me.LC_Nr_TextEdit.Text)

            'Dim OurBankNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankName").Range.End
            'c.RichEditControl1.Document.InsertText(OurBankNamePos, OUR_BANK_NAME)
            ''Dim OurBankBranchPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankBranch").Range.End
            ''c.RichEditControl1.Document.InsertText(OurBankBranchPos, OUR_BANK_BRANCH)
            'Dim OurBankAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankStrasse").Range.End
            'c.RichEditControl1.Document.InsertText(OurBankAddressPos, OUR_BANK_STRASSE)
            'Dim OurBankZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankPLZ").Range.End
            'c.RichEditControl1.Document.InsertText(OurBankZipCodePos, OUR_BANK_PLZ)
            'Dim OurBankCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankOrt").Range.End
            'c.RichEditControl1.Document.InsertText(OurBankCityPos, OUR_BANK_ORT)
            'Dim OurBankALLPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("OurBankALL").Range.End
            'c.RichEditControl1.Document.InsertText(OurBankALLPos, OUR_BANK_NAME & ", " & OUR_BANK_BRANCH & ", " & OUR_BANK_STRASSE & ", " & OUR_BANK_PLZ & " " & OUR_BANK_ORT)


            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerContactPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerContact").Range.End
            c.RichEditControl1.Document.InsertText(CustomerContactPos, Me.CustomerContactName_TextEdit.Text)
            Dim CustomerAddressPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerStrasse").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddressPos, CustomerNameAddress)
            Dim CustomerZipCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerPLZ").Range.End
            c.RichEditControl1.Document.InsertText(CustomerZipCodePos, CustomerZipCode)
            Dim CustomerCityPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerOrt").Range.End
            c.RichEditControl1.Document.InsertText(CustomerCityPos, CustomerCity)
            Dim CustomerReferencePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerReference").Range.End
            c.RichEditControl1.Document.InsertText(CustomerReferencePos, Me.CustomerLetterReference_TextEdit.Text)

            Dim ApplicantNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantName").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantNamePos, ApplicantName)

            Dim ApplicantBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBank").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankPos, ApplicantBankName)
            Dim ApplicantBankPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ApplicantBank1").Range.End
            c.RichEditControl1.Document.InsertText(ApplicantBankPos1, ApplicantBankName)


            Dim LcCurrencyPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcCCY").Range.End
            c.RichEditControl1.Document.InsertText(LcCurrencyPos, Me.LcCurrency_TextEdit.Text)
            Dim LcAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcAmount").Range.End
            c.RichEditControl1.Document.InsertText(LcAmountPos, FormatNumber(Me.LcAmount_Textedit.Text, 2))
            'Dim PercentageTollerancePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PercentageTollerance").Range.End
            'c.RichEditControl1.Document.InsertText(PercentageTollerancePos, PercentageTollerance)
            Dim LcDateExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcValidDate").Range.End
            c.RichEditControl1.Document.InsertText(LcDateExpiryPos, Me.DateOfExpiry_DateEdit.Text)
            Dim LcPlaceExpiryPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcValidCountry").Range.End
            c.RichEditControl1.Document.InsertText(LcPlaceExpiryPos, Me.PlaceOfExpiry_TextEdit.Text)

            Dim DiscountContractDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DiscountContractDate").Range.End
            c.RichEditControl1.Document.InsertText(DiscountContractDatePos, DiscontContractDate)
            Dim MaturityDiscountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDiscount").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDiscountPos, DiscontMaturityCalculated)

            Dim InvoiceCCYPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCCYPos, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceCCYPos1 As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceCCY1").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceCCYPos1, Me.InvoiceCCY_GridLookUpEdit.Text)
            Dim InvoiceAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("InvoiceAmount").Range.End
            c.RichEditControl1.Document.InsertText(InvoiceAmountPos, FormatNumber(Me.InvoiceAmount_SpinEdit.Text, 2))
            Dim DiskontAmountPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("DiskontAmount").Range.End
            c.RichEditControl1.Document.InsertText(DiskontAmountPos, FormatNumber(Me.DiscountAmount_SpinEdit.Text, 2))

            Dim ZinstagePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Zinstage").Range.End
            c.RichEditControl1.Document.InsertText(ZinstagePos, Me.InterestDaysCount_SpinEdit.Text)
            Dim ZeitraumVonPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ZeitraumVon").Range.End
            c.RichEditControl1.Document.InsertText(ZeitraumVonPos, Me.InterestDateFrom_DateEdit.Text)
            Dim ZeitraumBisPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ZeitraumBis").Range.End
            c.RichEditControl1.Document.InsertText(ZeitraumBisPos, Me.InterestDateTill_DateEdit.Text)
            Dim MaturityDatePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("MaturityDate").Range.End
            c.RichEditControl1.Document.InsertText(MaturityDatePos, Me.MaturityDate_DateEdit.Text)

            Dim DiskontsatzPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Diskontsatz").Range.End
            c.RichEditControl1.Document.InsertText(DiskontsatzPos, Me.DiscountInterestRate_SpinEdit.Text)

            Dim ZinsBasisPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ZinsBasis").Range.End
            c.RichEditControl1.Document.InsertText(ZinsBasisPos, Me.InterestRate_SpinEdit.Text)
            Dim ZinsMargePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("ZinsMarge").Range.End
            c.RichEditControl1.Document.InsertText(ZinsMargePos, Me.Marge_SpinEdit.Text)
            Dim ZinsmethodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Zinsmethode").Range.End
            c.RichEditControl1.Document.InsertText(ZinsmethodePos, Me.InterestMethod_ComboEdit.Text)

            Dim PaymentInstructionsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("PayInstructions").Range.End
            If Me.SettlementType_lbl.Text = "I" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir haben den Nettoerlös auf Ihr Konto: (" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei uns gutgeschrieben.")
            ElseIf Me.SettlementType_lbl.Text = "E" Then
                c.RichEditControl1.Document.InsertText(PaymentInstructionsPos, "Wir haben den Nettoerlös auf Ihr Konto:(" & Me.SettlementAccountCCY_lbl.Text & ")  " & Me.SettlementAccountNr_lbl.Text & " bei der " & Me.SettlementBank_lbl.Text & " " & " überwiesen.")
            End If

            Dim LcChargesPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("LcCharges").Range.End
            If CHARGES_CALCULATED > 0 AndAlso Me.SettlementType_lbl.Text = "I" Then
                c.RichEditControl1.Document.InsertText(LcChargesPos, "Die " & CHARGES_NAMES & " in Höhe von " & Me.InvoiceCCY_GridLookUpEdit.Text & " " & FormatNumber(CHARGES_CALCULATED, 2) & " werden Ihrem Konto mit separater Aufgabe belastet.")
            Else
                c.RichEditControl1.Document.InsertText(LcChargesPos, "")
            End If

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

    Private Sub ForfaitingContract_btn_Click(sender As Object, e As EventArgs) Handles ForfaitingContract_btn.Click
        If IsDate(Me.ForfaitingContractDate_DateEdit.EditValue) = True AndAlso Me.ForfaitingConditions_MemoEdit.EditValue <> "" And Me.ForfaitingMaturityDetails_MemoEdit.EditValue <> "" Then
            Try
                'SettlementSave_btn.PerformClick()
                Me.SaveChanges_btn.PerformClick()
                FORFAITING_CONTRACT_DOCUMENT()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        Else
            MessageBox.Show("MISSING FIELD VALUES" & vbNewLine & "One of the following Fields are empty:" & vbNewLine & "- Contract Date" & vbNewLine & "- Discount Conditions" & vbNewLine & "- Maturity Details" & vbNewLine & vbNewLine & "Please fill the empty Fields!", "UNABLE TO CREATE FORFAITING CONTRACT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub NegoBankFormCreation_btn_Click(sender As Object, e As EventArgs) Handles NegoBankFormCreation_btn.Click
        Try
            SettlementSave_btn.PerformClick()
            NEGO_BANK_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

    End Sub

    Private Sub NegoCustomer_btn_Click(sender As Object, e As EventArgs) Handles NegoCustomer_btn.Click
        Try
            SettlementSave_btn.PerformClick()
            NEGO_CUSTOMER_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub InfoMaturity_btn_Click(sender As Object, e As EventArgs) Handles InfoMaturity_btn.Click
        Try
            SettlementSave_btn.PerformClick()
            MIITEILUNG__FAELLIGKEIT_CUSTOMER_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub PaymentAdvice_btn_Click(sender As Object, e As EventArgs) Handles PaymentAdvice_btn.Click
        Try
            SettlementSave_btn.PerformClick()
            PAYMENT_ADVICE_CUSTOMER_DOCUMENT()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub ForfaitingConfirmation_btn_Click(sender As Object, e As EventArgs) Handles ForfaitingConfirmation_btn.Click
        If Me.Discount_CheckEdit.CheckState = CheckState.Checked Then
            Try
                SettlementSave_btn.PerformClick()
                FORFAITING_CONFIRMATION_DOCUMENT()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        Else
            MessageBox.Show("There's no Discount indicated for this Settlement!" & vbNewLine & "Please set discount!", "NO DISCOUNT FOR SETTLEMENT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub SettlementsAll_Load_btn_Click(sender As Object, e As EventArgs) Handles SettlementsAll_Load_btn.Click
        VALIDATIONS_REMOVE()
        Me.LayoutControl1.Visible = True
        Me.EXPORT_LC_MT700_SettlementsTableAdapter.FillByOurReference(Me.LcDataset.EXPORT_LC_MT700_Settlements, OurReferenceSearch)
        Me.EXPORT_LC_MT700_Settlements_ChargesTableAdapter.FillByAllSettlementsCharges(Me.LcDataset.EXPORT_LC_MT700_Settlements_Charges, OurReferenceSearch)
    End Sub

    Private Sub LoadForfaitConditions_btn_Click(sender As Object, e As EventArgs) Handles LoadForfaitConditions_btn.Click
        Dim ForfaitingConditionText As String = Nothing
        cmdSQL.CommandText = "SELECT [DiscontConditions] from [EXPORT_LC_CUSTOMERS] where [ID]='" & Me.RelatedCustomerID_lbl.Text & "'"
        Dim daSql As New SqlDataAdapter(cmdSQL.CommandText, connSQL)
        Dim dt As New DataTable
        daSql.Fill(dt)
        If dt.Rows.Count > 0 Then
            ForfaitingConditionText = dt.Rows.Item(0).Item("DiscontConditions")
        End If

        If Me.ForfaitingConditions_MemoEdit.Text = "" Then
            Me.ForfaitingConditions_MemoEdit.Text = ForfaitingConditionText
        Else
            If MessageBox.Show("Should the current Discount Conditions text be deleted?", "DISCOUNT CONDITIONS TEXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.ForfaitingConditions_MemoEdit.Text = ForfaitingConditionText
            End If
        End If

    End Sub

    Private Sub InvoiceAmount_SpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles InvoiceAmount_SpinEdit.EditValueChanged
        If Me.InvoiceAmount_SpinEdit.Focused = True Then
            If CDbl(Me.InvoiceAmount_SpinEdit.EditValue) <> 0 Then
                Dim INVOICE_AMOUNT As Double = Me.InvoiceAmount_SpinEdit.EditValue
                Dim LC_AMOUNT As Double = Me.LcAmount_Textedit.EditValue
                Dim REST_LC_AMOUNT As Double = 0
                Dim SettlementNr As Double = Me.SettlementNr_lbl.Text
                If SettlementNr = 1 Then
                    REST_LC_AMOUNT = LC_AMOUNT - INVOICE_AMOUNT
                    Me.LcRemainingAmount_CalcEdit.EditValue = REST_LC_AMOUNT
                ElseIf SettlementNr > 1 Then
                    REST_LC_AMOUNT = LAST_LC_REST_AMOUNT - INVOICE_AMOUNT
                    Me.LcRemainingAmount_CalcEdit.EditValue = REST_LC_AMOUNT
                End If
            End If
        End If


    End Sub

    Private Sub InvoiceAmount_SpinEdit_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles InvoiceAmount_SpinEdit.EditValueChanging
        If CDbl(Me.InvoiceAmount_SpinEdit.EditValue) <> 0 Then
            Dim INVOICE_AMOUNT As Double = Me.InvoiceAmount_SpinEdit.EditValue
            Dim LC_AMOUNT As Double = Me.LcAmount_Textedit.EditValue
            Dim REST_LC_AMOUNT As Double = 0
            Dim SettlementNr As Double = Me.SettlementNr_lbl.Text
            If SettlementNr = 1 Then
                REST_LC_AMOUNT = LC_AMOUNT - INVOICE_AMOUNT
                Me.LcRemainingAmount_CalcEdit.EditValue = REST_LC_AMOUNT
            ElseIf SettlementNr > 1 Then
                REST_LC_AMOUNT = LAST_LC_REST_AMOUNT - INVOICE_AMOUNT
                Me.LcRemainingAmount_CalcEdit.EditValue = REST_LC_AMOUNT
            End If
        End If

    End Sub



    Private Sub LcRemainingAmount_CalcEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LcRemainingAmount_CalcEdit.ButtonClick
        If e.Button.Tag.ToString = "SetToZero" Then
            Me.LcRemainingAmount_CalcEdit.EditValue = 0
        End If
    End Sub


End Class