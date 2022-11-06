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
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class OnlineBanking

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim ClientNrGlobal As String = Nothing
    Dim ClientNameGlobal As String = Nothing
    Dim OnlineBankingCustomersTokensViewCaption As String = Nothing

    Dim TokenNrGlobal As String = Nothing
    Dim TokenTypeGlobal As String = Nothing
    Dim TokenOperatorGlobal As String = Nothing

    Private BS_Customers As BindingSource



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

    Private Sub ONLINE_BANKING_CUSTOMERSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ONLINE_BANKING_CUSTOMERSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.OnlineBankingDataSet)

    End Sub

    Private Sub LOAD_DATA()
        Me.ONLINE_BANKING_TOKEN_ITEMSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ITEMS)
        Me.ONLINE_BANKING_TOKEN_ALL_TableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ALL)
        Me.ONLINE_BANKING_TOKENTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN)
        Me.ONLINE_BANKING_CUSTOMERSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_CUSTOMERS)
        ALL_CUSTOMERS_initData()
        ALL_CUSTOMERS_InitLookUp()
    End Sub

    Private Sub OnlineBanking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        '***********************************************************************
        cmd.Connection.Close()

        LOAD_DATA()
        Me.XtraTabControl1.Focus()


    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ONLINE_BANKING_CUSTOMERSBindingSource.EndEdit()
                Me.ONLINE_BANKING_TOKENBindingSource.EndEdit()
                'If Me.OnlineBankingDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.OnlineBankingDataSet)
                    cmd.Connection.Open()
                    'Update client Name in ONLINE BANKING TOKEN
                    cmd.CommandText = "Update A Set A.[Customer_Name]=B.[ClientName] from [ONLINE_BANKING_TOKEN] A INNER JOIN [ONLINE_BANKING_CUSTOMERS] B ON A.[IdClientNo]=B.[ClientNo] where A.[Customer_Name] is NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Update A set A.[Online]=B.[OnlineBankingStatus] from [CUSTOMER_ACCOUNTS] A INNER JOIN [ONLINE_BANKING_CUSTOMERS] B ON A.[ClientNo]=B.[ClientNo] where B.[OnlineBankingStatus]='N'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[OnlineBanking]=B.[OnlineBankingStatus] FROM [CLIENTS] A INNER JOIN [ONLINE_BANKING_CUSTOMERS] B ON A.[ClientNo]=B.[ClientNo]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[Online]=B.[OnlineBankingStatus] FROM [CLIENTS_ACCOUNTS] A INNER JOIN [ONLINE_BANKING_CUSTOMERS] B ON A.[ClientNo]=B.[ClientNo] where B.[OnlineBankingStatus]='N'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    '********************************************
                    Me.ONLINE_BANKING_TOKEN_ALL_TableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ALL)
                    Me.ONLINE_BANKING_TOKENTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN)
                    Me.ONLINE_BANKING_CUSTOMERSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_CUSTOMERS)

                Else
                    e.Handled = True
                End If
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ONLINE_BANKING_CUSTOMERSBindingSource.CancelEdit()
                Me.ONLINE_BANKING_TOKENBindingSource.CancelEdit()
                Me.OnlineBankingDataSet.RejectChanges()
                Me.ONLINE_BANKING_TOKEN_ALL_TableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ALL)
                Me.ONLINE_BANKING_TOKENTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN)
                Me.ONLINE_BANKING_CUSTOMERSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_CUSTOMERS)
                Exit Sub
            End Try
        End If

        'Cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.ONLINE_BANKING_CUSTOMERSBindingSource.CancelEdit()
            Me.ONLINE_BANKING_TOKENBindingSource.CancelEdit()
            Me.OnlineBankingDataSet.RejectChanges()
            Me.ONLINE_BANKING_TOKEN_ALL_TableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ALL)
            Me.ONLINE_BANKING_TOKENTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN)
            Me.ONLINE_BANKING_CUSTOMERSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_CUSTOMERS)
        End If
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ONLINE_BANKING_TOKEN_ITEMSBindingSource.EndEdit()
                'If Me.OnlineBankingDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.OnlineBankingDataSet)
                    Me.ONLINE_BANKING_TOKEN_ITEMSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ITEMS)
                Else
                    e.Handled = True
                End If
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ONLINE_BANKING_TOKEN_ITEMSBindingSource.CancelEdit()
                Me.OnlineBankingDataSet.RejectChanges()
                Me.ONLINE_BANKING_TOKEN_ITEMSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ITEMS)
                Exit Sub
            End Try
        End If

        'Cancel edit
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.CancelEdit Then
            Me.ONLINE_BANKING_TOKEN_ITEMSBindingSource.CancelEdit()
            Me.OnlineBankingDataSet.RejectChanges()
            Me.ONLINE_BANKING_TOKEN_ITEMSTableAdapter.Fill(Me.OnlineBankingDataSet.ONLINE_BANKING_TOKEN_ITEMS)
        End If


    End Sub

    Private Sub ALL_CUSTOMERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [ClientNo],[ClientType],[English Name] FROM [CUSTOMER_INFO] where  ClientType in ('C - COMPANY') UNION ALL Select '11000' as 'ClientNo','C - COMPANY' as 'ClientType','TEST CUSTOMER' as 'English Name'", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCustomers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbCustomers.Fill(ds, "ALL_CUSTOMERS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Customers = New BindingSource(ds, "ALL_CUSTOMERS")
    End Sub

    Private Sub ALL_CUSTOMERS_InitLookUp()
        Me.Customers_RepositoryItemSearchLookUpEdit.DataSource = BS_Customers
        Me.Customers_RepositoryItemSearchLookUpEdit.DisplayMember = "ClientNo"
        Me.Customers_RepositoryItemSearchLookUpEdit.ValueMember = "ClientNo"
    End Sub

    Private Sub ALL_VALID_CUSTOMERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [ClientNo],[ClientType],[English Name] FROM [CUSTOMER_INFO] where CLOSE_DATE is null and ClientType in ('C - COMPANY') and ClientNo not in (Select ClientNo from ONLINE_BANKING_CUSTOMERS)", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCustomers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbCustomers.Fill(ds, "ALL_CUSTOMERS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Customers = New BindingSource(ds, "ALL_CUSTOMERS")
    End Sub

    Private Sub ALL_VALID_CUSTOMERS_InitLookUp()
        Me.Customers_RepositoryItemSearchLookUpEdit.DataSource = BS_Customers
        Me.Customers_RepositoryItemSearchLookUpEdit.DisplayMember = "ClientNo"
        Me.Customers_RepositoryItemSearchLookUpEdit.ValueMember = "ClientNo"
    End Sub

#Region "ONLINE BANKING CUSTOMERS ACTIONS"

    Private Sub OnlineBanking_Customers_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles OnlineBanking_Customers_GridView.CellValueChanged
        'Base View
        If Me.OnlineBanking_Customers_GridView.IsNewItemRow(Me.OnlineBanking_Customers_GridView.FocusedRowHandle) = True Then
            If e.Column.Caption = "Client No" Then
                Dim row As System.Data.DataRow = OnlineBanking_Customers_GridView.GetDataRow(OnlineBanking_Customers_GridView.FocusedRowHandle)
                Dim ClientNr As String = row(1)
                Dim ClientName As String = Nothing
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandText = "SELECT [English Name] from [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "' and [CLOSE_DATE] is NULL"
                If IsNothing(cmd.ExecuteScalar) = False Then
                    ClientName = cmd.ExecuteScalar
                    cmd.CommandText = "Select Count(ID) from [CUSTOMER_ACCOUNTS] where [Online]='Y' and [ClientNo]='" & ClientNr & "'"
                    If cmd.ExecuteScalar > 0 Then
                        cmd.CommandText = "SELECT [ClientNo] from [ONLINE_BANKING_CUSTOMERS] where [ClientNo]='" & ClientNr & "'"
                        If IsNothing(cmd.ExecuteScalar) = True Then
                            row(2) = ClientName
                        Else
                            MessageBox.Show("Client Nr. " & row(1) & " allready inserted as Online Banking Customer", "CLIENT NR. PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            row(1) = ""
                            If cmd.Connection.State = ConnectionState.Open Then
                                cmd.Connection.Close()
                            End If
                            Exit Sub

                        End If
                    Else
                        MessageBox.Show("There are no Online Banking Accounts indicated for Client Nr. " & ClientNr & vbNewLine & "Please indicate first the customers Online Banking Accounts in CUSTOMER ACCOUNTS Form!", "NO ONLINE BANKING ACCOUNT FOR CLIENT NR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.GridControl1.EmbeddedNavigator.Buttons.DoClick(Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit)
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        Exit Sub
                    End If

                Else
                    MessageBox.Show("Client Nr. " & row(1) & " not found or deleted", "CLIENT NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    row(1) = ""
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    Exit Sub
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If
        End If



    End Sub

    Private Sub OnlineBanking_Customers_GridView_PopupMenuShowing1(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles OnlineBanking_Customers_GridView.PopupMenuShowing

        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

        If HitInfo.InRow And ClientNrGlobal <> "" Then

            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)
            Me.TokenWithoutActivation_ToolStripMenuItem.Visible = True
            Me.TokenLabelsToolStripMenuItem.Visible = True
            Me.OnlineBankigPasswordsForCustomerToolStripMenuItem.Visible = True
            Me.InternetBankingVereinbarungToolStripMenuItem.Visible = True
            Me.TokenActivationFormToolStripMenuItem.Visible = False
        End If
    End Sub

   

    Private Sub OnlineBanking_Customers_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles OnlineBanking_Customers_GridView.FocusedRowChanged
        If Me.OnlineBanking_Customers_GridView.IsNewItemRow(Me.OnlineBanking_Customers_GridView.FocusedRowHandle) = True Then
            Me.OnlineBanking_Customers_GridView.Columns.ColumnByFieldName("ClientNo").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_Customers_GridView.Columns.ColumnByFieldName("ClientNo").OptionsColumn.AllowEdit = True

        Else

            Me.OnlineBanking_Customers_GridView.Columns.ColumnByFieldName("ClientNo").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_Customers_GridView.Columns.ColumnByFieldName("ClientNo").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub OnlineBanking_Customers_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OnlineBanking_Customers_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_Customers_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OnlineBanking_Customers_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_Customers_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles OnlineBanking_Customers_GridView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "OnlineBanking_Customers_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            OnlineBankingCustomersTokensViewCaption = "Online Banking Tokens details for Customer: " & view.GetFocusedRowCellValue("ClientName").ToString & "  (" & view.GetFocusedRowCellValue("ClientNo").ToString & ")"
            ClientNrGlobal = view.GetFocusedRowCellValue("ClientNo").ToString
            ClientNameGlobal = view.GetFocusedRowCellValue("ClientName").ToString
            Me.OnlineBanking_CustomerTokens_GridView.ViewCaption = OnlineBankingCustomersTokensViewCaption
        End If
    End Sub

    Private Sub OnlineBanking_Customers_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles OnlineBanking_Customers_GridView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "OnlineBanking_Customers_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            OnlineBankingCustomersTokensViewCaption = "Online Banking Tokens details for Customer: " & view.GetFocusedRowCellValue("ClientName").ToString & "  (" & view.GetFocusedRowCellValue("ClientNo").ToString & ")"
            ClientNrGlobal = view.GetFocusedRowCellValue("ClientNo").ToString
            ClientNameGlobal = view.GetFocusedRowCellValue("ClientName").ToString
            Me.OnlineBanking_CustomerTokens_GridView.ViewCaption = OnlineBankingCustomersTokensViewCaption
        End If
    End Sub

   

    Private Sub OnlineBanking_Customers_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles OnlineBanking_Customers_GridView.RowClick
        If Me.GridControl1.FocusedView.Name = "OnlineBanking_Customers_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                OnlineBankingCustomersTokensViewCaption = "Online Banking Tokens details for Customer: " & view.GetFocusedRowCellValue("ClientName").ToString & "  (" & view.GetFocusedRowCellValue("ClientNo").ToString & ")"
                ClientNrGlobal = view.GetFocusedRowCellValue("ClientNo").ToString
                ClientNameGlobal = view.GetFocusedRowCellValue("ClientName").ToString
                Me.OnlineBanking_CustomerTokens_GridView.ViewCaption = OnlineBankingCustomersTokensViewCaption
            End If
        End If
    End Sub

    Private Sub OnlineBanking_Customers_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OnlineBanking_Customers_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OnlineBanking_Customers_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OnlineBanking_Customers_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OnlineBanking_Customers_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OnlineBanking_Customers_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim CLIENT_NR As GridColumn = View.Columns("ClientNo")
        Dim ONLINE_BANKING_STATUS As GridColumn = View.Columns("OnlineBankingStatus")

        Dim ClientNr As String = View.GetRowCellValue(e.RowHandle, colClientNo).ToString
        Dim OnlineBankingStatus As String = View.GetRowCellValue(e.RowHandle, colOnlineBankingStatus).ToString

        If ClientNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CLIENT_NR, "Client Nr. must not be empty")
            e.ErrorText = "Client Nr. must not be empty"
        End If

        If OnlineBankingStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ONLINE_BANKING_STATUS, "Online Banking Status must not be empty")
            e.ErrorText = "Online Banking Status must not be empty"
        End If

    End Sub

    Private Sub Print_Export_OnlineBanking_Customers_GridView_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_OnlineBanking_Customers_GridView_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea

        Dim reportfooter As String = "ONLINE BANKING CUSTOMERS"
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New System.Drawing.Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, System.Drawing.Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)


        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size

        Try
            iSize = e.Graph.MeasureString(String.Format("Page {0} of {1}", 100, 100)).ToSize
            r = New RectangleF(New PointF(0, 0), iSize)
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Far)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub OnlineBanking_CustomerTokens_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles OnlineBanking_CustomerTokens_GridView.CellValueChanged
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsNewItemRow(view.FocusedRowHandle) = True Then
            Dim row As System.Data.DataRow = view.GetDataRow(view.FocusedRowHandle)
            Dim cellValue As Object = view.GetRowCellValue(e.RowHandle, OnlineBanking_CustomerTokens_GridView.Columns(2))
            'MessageBox.Show(cellValue.ToString())
            Dim TOKEN_ID As String = cellValue.ToString()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.Connection.Open()
            cmd.CommandText = "SELECT [Token_ID] from [ONLINE_BANKING_TOKEN] where [Token_ID]='" & TOKEN_ID & "'"
            If IsNothing(cmd.ExecuteScalar) = False Then
                MessageBox.Show("Token ID " & TOKEN_ID & " allready exists !", "TOKEN ID PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn, "")
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If

    End Sub

    

    Private Sub OnlineBanking_CustomerTokens_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles OnlineBanking_CustomerTokens_GridView.FocusedRowChanged
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.AllowEdit = True

            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_ID").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_ID").OptionsColumn.AllowEdit = True

            'Not edit for new Items
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Deleted_On").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Deleted_On").OptionsColumn.AllowEdit = False

        Else
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.AllowEdit = False

            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_ID").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Token_ID").OptionsColumn.AllowEdit = False

            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Deleted_On").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_CustomerTokens_GridView.Columns.ColumnByFieldName("Deleted_On").OptionsColumn.AllowEdit = True
        End If
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OnlineBanking_CustomerTokens_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OnlineBanking_CustomerTokens_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles OnlineBanking_CustomerTokens_GridView.PopupMenuShowing
        Dim View As GridView = CType(sender, GridView)

        Dim HitInfo As GridHitInfo = View.CalcHitInfo(e.Point)

        If HitInfo.InRow And ClientNrGlobal <> "" And TokenTypeGlobal = "Other" Then

            View.FocusedRowHandle = HitInfo.RowHandle
            Me.ContextMenuStrip1.Show(View.GridControl, e.Point)
            Me.TokenWithoutActivation_ToolStripMenuItem.Visible = False
            Me.TokenLabelsToolStripMenuItem.Visible = False
            Me.OnlineBankigPasswordsForCustomerToolStripMenuItem.Visible = False
            Me.InternetBankingVereinbarungToolStripMenuItem.Visible = False
            Me.TokenActivationFormToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles OnlineBanking_CustomerTokens_GridView.RowClick
        If Me.GridControl1.FocusedView.Name = "OnlineBanking_CustomerTokens_GridView" Then
            Dim view As GridView = DirectCast(sender, GridView)
            If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                TokenNrGlobal = view.GetFocusedRowCellValue("Token_ID").ToString
                TokenTypeGlobal = view.GetFocusedRowCellValue("Token_Type").ToString
                TokenOperatorGlobal = view.GetFocusedRowCellValue("Token_binded_to").ToString
            End If
        End If
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OnlineBanking_CustomerTokens_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OnlineBanking_CustomerTokens_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OnlineBanking_CustomerTokens_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OnlineBanking_CustomerTokens_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim TOKEN_TYPE As GridColumn = View.Columns("Token_Type")
        Dim TOKEN_ID As GridColumn = View.Columns("Token_ID")
        Dim TOKEN_VALIDITY As GridColumn = View.Columns("Token_Valid")
        Dim TOKEN_LEVEL As GridColumn = View.Columns("Token_Level")
        Dim TOKEN_BINDED_TO As GridColumn = View.Columns("Token_binded_to")

        Dim TokenType As String = View.GetRowCellValue(e.RowHandle, colToken_Type).ToString
        Dim TokenID As String = View.GetRowCellValue(e.RowHandle, colToken_ID).ToString
        Dim TokenValidity As String = View.GetRowCellValue(e.RowHandle, colToken_Valid).ToString
        Dim TokenLevel As String = View.GetRowCellValue(e.RowHandle, colTokenLevel).ToString
        Dim TokenBindedTo As String = View.GetRowCellValue(e.RowHandle, colTokenbindedTo).ToString

        If TokenType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_TYPE, "Token type must not be empty")
            e.ErrorText = "Token type must not be empty"
        End If

        If TokenID = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_ID, "Token ID must not be empty")
            e.ErrorText = "Token ID must not be empty"
        End If

        If TokenValidity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_VALIDITY, "Token Validity must not be empty")
            e.ErrorText = "Token Validity must not be empty"
        End If

        If TokenLevel = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_LEVEL, "Token Level must not be empty")
            e.ErrorText = "Token Level must not be empty"
        End If

        If TokenBindedTo = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_BINDED_TO, "Token binded must not be empty")
            e.ErrorText = "Token binded must not be empty"
        End If

    End Sub



    Private Sub Print_Export_All_Token_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_All_Token_Gridview_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea

        Dim reportfooter As String = "ONLINE BANKING TOKENS"
       e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub OnlineBanking_Tokens_All_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OnlineBanking_Tokens_All_Gridview.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OnlineBanking_Tokens_All_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles OnlineBanking_Tokens_All_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles OnlineBanking_Token_Items_GridView.CellValueChanged
        If Me.OnlineBanking_Token_Items_GridView.IsNewItemRow(Me.OnlineBanking_Token_Items_GridView.FocusedRowHandle) = True Then
            If e.Column.FieldName = "Token_ID_from" OrElse e.Column.FieldName = "Token_ID_Till" Then
                Dim row As System.Data.DataRow = OnlineBanking_Token_Items_GridView.GetDataRow(OnlineBanking_Token_Items_GridView.FocusedRowHandle)
                Dim TokenIDfrom As Double = 0
                Dim TokenIDtill As Double = 0
                Dim TokenCount As Double = 0
                If IsNumeric(row(1)) = True AndAlso IsNumeric(row(2)) = True Then
                    TokenIDfrom = row(1)
                    TokenIDtill = row(2)
                    If TokenIDtill > TokenIDfrom Then
                        TokenCount = TokenIDtill - TokenIDfrom
                        row(3) = TokenCount
                    Else
                        MessageBox.Show("-Token ID from- is higher than -Token ID till-", "WRONG TOKEN ID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        row(1) = ""
                        row(2) = ""
                        row(3) = ""
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles OnlineBanking_Token_Items_GridView.FocusedRowChanged
        If Me.OnlineBanking_Token_Items_GridView.IsNewItemRow(Me.OnlineBanking_Token_Items_GridView.FocusedRowHandle) = True Then
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.AllowEdit = True
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_from").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_from").OptionsColumn.AllowEdit = True
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_Till").OptionsColumn.ReadOnly = False
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_Till").OptionsColumn.AllowEdit = True
        Else
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_Type").OptionsColumn.AllowEdit = False
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_from").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_from").OptionsColumn.AllowEdit = False
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_Till").OptionsColumn.ReadOnly = True
            Me.OnlineBanking_Token_Items_GridView.Columns.ColumnByFieldName("Token_ID_Till").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OnlineBanking_Token_Items_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OnlineBanking_Token_Items_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OnlineBanking_Token_Items_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_ShownEditor(sender As Object, e As EventArgs) Handles OnlineBanking_Token_Items_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = SystemColors.InactiveCaptionText
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_TokenCount_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_TokenCount_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea

        Dim reportfooter As String = "ONLINE BANKING TOKEN ID's and Items"
       e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub OnlineBankingReport_btn_Click(sender As Object, e As EventArgs) Handles OnlineBankingReport_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Online Banking Report")

        Dim OnlineCustomers_Da As New SqlDataAdapter("SELECT * FROM [ONLINE_BANKING_CUSTOMERS]", conn)
        Dim OnlineTokens_Da As New SqlDataAdapter("SELECT * FROM [ONLINE_BANKING_TOKEN]", conn)
        Dim CustomerAccounts_Da As New SqlDataAdapter("SELECT * FROM [CUSTOMER_ACCOUNTS]", conn)
        Dim OnlineALL_Dataset As New DataSet("OnlineALL")
        OnlineCustomers_Da.Fill(OnlineALL_Dataset, "ONLINE_BANKING_CUSTOMERS")
        OnlineTokens_Da.Fill(OnlineALL_Dataset, "ONLINE_BANKING_TOKEN")
        CustomerAccounts_Da.Fill(OnlineALL_Dataset, "CUSTOMER_ACCOUNTS")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Online_Banking_Token_Status.rpt")
        'Dim da As New OnlineBankingDataSetTableAdapters.CUSTOMER_ACCOUNTSTableAdapter
        'da.Fill(Me.OnlineBankingDataSet.CUSTOMER_ACCOUNTS)
        'CrRep.SetDataSource(Me.OnlineBankingDataSet)
        CrRep.SetDataSource(OnlineALL_Dataset)

        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Online Banking Report "
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = True
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OnlineBanking_Token_Items_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OnlineBanking_Token_Items_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim TOKEN_TYPE As GridColumn = View.Columns("Token_Type")
        Dim TOKEN_ID_FROM As GridColumn = View.Columns("Token_ID_from")
        Dim TOKEN_ID_TILL As GridColumn = View.Columns("Token_ID_Till")

        Dim TokenType As String = View.GetRowCellValue(e.RowHandle, colToken_Type2).ToString
        Dim TokenIDfrom As String = View.GetRowCellValue(e.RowHandle, colToken_ID_from).ToString
        Dim TokenIDtill As String = View.GetRowCellValue(e.RowHandle, colToken_ID_Till).ToString

        If TokenType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_TYPE, "Token type must not be empty")
            e.ErrorText = "Token type must not be empty"
        End If

        If TokenIDfrom = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_ID_FROM, "Token ID from must not be empty")
            e.ErrorText = "Token ID from must not be empty"
        End If

        If TokenIDtill = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TOKEN_ID_TILL, "Token Validity must not be empty")
            e.ErrorText = "Token Validity must not be empty"
        End If
    End Sub

    
    Private Sub TokenWithoutActivation_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TokenWithoutActivation_ToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Form creation")
            Dim TOKEN_WITHOUT_ACTIVATION_FORM As String = Nothing
            'Customer Parameters
            Dim CustomerName As String = Nothing
            Dim CustomerAddress1 As String = Nothing
            Dim CustomerAddress2 As String = Nothing
            Dim CustomerAddress3 As String = Nothing
            Dim CustomerAddress4 As String = Nothing

            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "Form_Without_Activation" Then
                    TOKEN_WITHOUT_ACTIVATION_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNrGlobal & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                CustomerName = dt.Rows.Item(i).Item("English Name")
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS1")) Then
                    CustomerAddress1 = dt.Rows.Item(i).Item("ADDRESS1")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS2")) Then
                    CustomerAddress2 = dt.Rows.Item(i).Item("ADDRESS2")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS3")) Then
                    CustomerAddress3 = dt.Rows.Item(i).Item("ADDRESS3")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS4")) Then
                    CustomerAddress4 = dt.Rows.Item(i).Item("ADDRESS4")
                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Form: Tokens without Activation")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Tokens without Activation Form"
            c.RichEditControl1.LoadDocument(TOKEN_WITHOUT_ACTIVATION_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            Dim CustomerNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerNr").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNrPos, ClientNrGlobal)
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerAddress1)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress2)
            Dim CustomerAddress3Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("Address3").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress3Pos, CustomerAddress3)
            Dim CustomerAddress4Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address4").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress4Pos, CustomerAddress4)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub TokenActivationFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TokenActivationFormToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Form creation")
            Dim TOKEN_ACTIVATION_FORM As String = Nothing
            'Customer Parameters
            Dim CustomerName As String = Nothing
            Dim CustomerAddress1 As String = Nothing
            Dim CustomerAddress2 As String = Nothing
            Dim CustomerAddress3 As String = Nothing
            Dim CustomerAddress4 As String = Nothing

            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "Form_Token_Activation" Then
                    TOKEN_ACTIVATION_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNrGlobal & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                CustomerName = dt.Rows.Item(i).Item("English Name")
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS1")) Then
                    CustomerAddress1 = dt.Rows.Item(i).Item("ADDRESS1")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS2")) Then
                    CustomerAddress2 = dt.Rows.Item(i).Item("ADDRESS2")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS3")) Then
                    CustomerAddress3 = dt.Rows.Item(i).Item("ADDRESS3")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS4")) Then
                    CustomerAddress4 = dt.Rows.Item(i).Item("ADDRESS4")
                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Form: Token Activation")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Token Activation Form"
            c.RichEditControl1.LoadDocument(TOKEN_ACTIVATION_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

            Dim CustomerNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerNr").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNrPos, ClientNrGlobal)
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerAddress1)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress2)
            Dim CustomerAddress3Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("Address3").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress3Pos, CustomerAddress3)
            Dim CustomerAddress4Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address4").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress4Pos, CustomerAddress4)
            Dim OperatorCodePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TokenOperator").Range.End
            c.RichEditControl1.Document.InsertText(OperatorCodePos, TokenOperatorGlobal)
            Dim TokenNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("TokenNr").Range.End
            c.RichEditControl1.Document.InsertText(TokenNrPos, TokenNrGlobal)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub TokenLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TokenLabelsToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Display Token Labels Form")
            Dim TOKEN_LABELS_FORM As String = Nothing
            'Customer Parameters
            Dim CustomerName As String = Nothing
            Dim CustomerAddress1 As String = Nothing
            Dim CustomerAddress2 As String = Nothing
            Dim CustomerAddress3 As String = Nothing
            Dim CustomerAddress4 As String = Nothing

            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "Form_Token_Labels" Then
                    TOKEN_LABELS_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Token Activation Form"
            c.RichEditControl1.LoadDocument(TOKEN_LABELS_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Enabled
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden

           
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub OnlineBankigPasswordsForCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlineBankigPasswordsForCustomerToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Form creation")
            Dim ONLINE_BANKING_PASSWORDS_FORM As String = Nothing
            'Customer Parameters
            Dim CustomerName As String = Nothing
            Dim CustomerAddress1 As String = Nothing
            Dim CustomerAddress2 As String = Nothing
            Dim CustomerAddress3 As String = Nothing
            Dim CustomerAddress4 As String = Nothing

            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "Form_OnlineBanking_Password_NewCustomer" Then
                    ONLINE_BANKING_PASSWORDS_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNrGlobal & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                CustomerName = dt.Rows.Item(i).Item("English Name")
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS1")) Then
                    CustomerAddress1 = dt.Rows.Item(i).Item("ADDRESS1")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS2")) Then
                    CustomerAddress2 = dt.Rows.Item(i).Item("ADDRESS2")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS3")) Then
                    CustomerAddress3 = dt.Rows.Item(i).Item("ADDRESS3")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS4")) Then
                    CustomerAddress4 = dt.Rows.Item(i).Item("ADDRESS4")
                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Form: Online Banking Passwords for Customer")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Online Banking Passwords Form"
            c.RichEditControl1.LoadDocument(ONLINE_BANKING_PASSWORDS_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden
            Dim CustomerNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerNr").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNrPos, ClientNrGlobal)
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerAddress1)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress2)
            Dim CustomerAddress3Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("Address3").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress3Pos, CustomerAddress3)
            Dim CustomerAddress4Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address4").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress4Pos, CustomerAddress4)

            'Insert Tokens
            'Operator Token
            Dim Token1KundePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token1_Kunde").Range.End
            Me.QueryText = "SELECT '0' +[Token_ID] as 'Token_ID' FROM [ONLINE_BANKING_TOKEN] where [IdClientNo]='" & ClientNrGlobal & "' and [Token_Valid]='Y' and [Token_Level] in ('OPERATOR') and [Token_Type] in ('Other')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                c.RichEditControl1.Document.InsertText(Token1KundePos, dt.Rows.Item(0).Item("Token_ID"))
            Else
                c.RichEditControl1.Document.InsertText(Token1KundePos, "")
            End If
            'Master Token
            Dim Token2KundePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token2_Kunde").Range.End
            Me.QueryText = "SELECT '0' +[Token_ID] as 'Token_ID' FROM [ONLINE_BANKING_TOKEN] where [IdClientNo]='" & ClientNrGlobal & "' and [Token_Valid]='Y' and [Token_Level] in ('MASTER') and [Token_Type] in ('Other')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                c.RichEditControl1.Document.InsertText(Token2KundePos, dt.Rows.Item(0).Item("Token_ID"))
            Else
                c.RichEditControl1.Document.InsertText(Token2KundePos, "")
            End If


            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub InternetBankingVereinbarungToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InternetBankingVereinbarungToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Select related data for the Form creation")
            Dim INTERNET_BANKING_VEREINBARUNG_FORM As String = Nothing
            'Customer Parameters
            Dim CustomerName As String = Nothing
            Dim CustomerAddress1 As String = Nothing
            Dim CustomerAddress2 As String = Nothing
            Dim CustomerAddress3 As String = Nothing
            Dim CustomerAddress4 As String = Nothing

            'Directory of the Word Form
            Me.QueryText = "SELECT * FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Item(i).Item("PARAMETER1") = "Form_Internet_Banking_Vereinbarung" Then
                    INTERNET_BANKING_VEREINBARUNG_FORM = dt.Rows.Item(i).Item("PARAMETER2")
                End If
            Next

            Me.QueryText = "SELECT * FROM [CUSTOMER_INFO] where [ClientNo]='" & ClientNrGlobal & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1

                CustomerName = dt.Rows.Item(i).Item("English Name")
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS1")) Then
                    CustomerAddress1 = dt.Rows.Item(i).Item("ADDRESS1")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS2")) Then
                    CustomerAddress2 = dt.Rows.Item(i).Item("ADDRESS2")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS3")) Then
                    CustomerAddress3 = dt.Rows.Item(i).Item("ADDRESS3")
                End If
                If Not DBNull.Value.Equals(dt.Rows.Item(i).Item("ADDRESS4")) Then
                    CustomerAddress4 = dt.Rows.Item(i).Item("ADDRESS4")
                End If
            Next

            SplashScreenManager.Default.SetWaitFormCaption("Create Form: Internet Banking Vereinbarung")
            'Generate Word Form
            Dim c As New WordForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.Text = "Internet Banking Vereinbarung Form"
            c.RichEditControl1.LoadDocument(INTERNET_BANKING_VEREINBARUNG_FORM)
            c.RichEditControl1.ReadOnly = False
            'c.RibbonControl1.Pages(1).Visible = False
            c.RichEditControl1.Options.Behavior.Save = DocumentCapability.Hidden
            c.RichEditControl1.Options.Behavior.SaveAs = DocumentCapability.Hidden
            Dim CustomerNrPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerNr").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNrPos, ClientNrGlobal)
            Dim CustomerNrBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerNr_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNrBankPos, ClientNrGlobal)
            Dim CustomerNamePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNamePos, CustomerName)
            Dim CustomerNameBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("CustomerName_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerNameBankPos, CustomerName)
            Dim CustomerAddress1Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address1").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1Pos, CustomerAddress1)
            Dim CustomerAddress1BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address1_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress1BankPos, CustomerAddress1)
            Dim CustomerAddress2Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address2").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2Pos, CustomerAddress2)
            Dim CustomerAddress2BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address2_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress2BankPos, CustomerAddress2)
            Dim CustomerAddress3Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("Address3").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress3Pos, CustomerAddress3)
            Dim CustomerAddress3BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks.Item("Address3_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress3BankPos, CustomerAddress3)
            Dim CustomerAddress4Pos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address4").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress4Pos, CustomerAddress4)
            Dim CustomerAddress4BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Address4_Bank").Range.End
            c.RichEditControl1.Document.InsertText(CustomerAddress4BankPos, CustomerAddress4)
            'Insert Accounts
            Dim ClientAccountsPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AlleKontenKUNDE").Range.End
            Dim ClientAccountsBankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("AlleKontenBANK").Range.End
            Me.QueryText = "SELECT [ClientAccountDomestic],[Deal Currency] FROM [CUSTOMER_ACCOUNTS] where [ClientNo]='" & ClientNrGlobal & "' and [CLOSE_DATE] is NULL and [Online]='Y'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows.Count > 0 Then
                    c.RichEditControl1.Document.InsertText(ClientAccountsPos, dt.Rows.Item(i).Item("ClientAccountDomestic") & "  (" & dt.Rows.Item(i).Item("Deal Currency") & ")" & vbNewLine)
                    c.RichEditControl1.Document.InsertText(ClientAccountsBankPos, dt.Rows.Item(i).Item("ClientAccountDomestic") & "  (" & dt.Rows.Item(i).Item("Deal Currency") & ")" & vbNewLine)
                Else
                    c.RichEditControl1.Document.InsertText(ClientAccountsPos, "")
                    c.RichEditControl1.Document.InsertText(ClientAccountsBankPos, "")
                End If
            Next
            'Insert Tokens
            'Operator Token
            Dim Token1KundePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token1_Kunde").Range.End
            Dim Token1BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token1_Bank").Range.End
            Me.QueryText = "SELECT [Token_ID] FROM [ONLINE_BANKING_TOKEN] where [IdClientNo]='" & ClientNrGlobal & "' and [Token_Valid]='Y' and [Token_Level] in ('OPERATOR') and [Token_Type] in ('Other')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                c.RichEditControl1.Document.InsertText(Token1KundePos, dt.Rows.Item(0).Item("Token_ID"))
                c.RichEditControl1.Document.InsertText(Token1BankPos, dt.Rows.Item(0).Item("Token_ID"))
            Else
                c.RichEditControl1.Document.InsertText(Token1KundePos, "")
                c.RichEditControl1.Document.InsertText(Token1BankPos, "")
            End If
            'Master Token
            Dim Token2KundePos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token2_Kunde").Range.End
            Dim Token2BankPos As DocumentPosition = c.RichEditControl1.Document.Bookmarks("Token2_Bank").Range.End
            Me.QueryText = "SELECT [Token_ID] FROM [ONLINE_BANKING_TOKEN] where [IdClientNo]='" & ClientNrGlobal & "' and [Token_Valid]='Y' and [Token_Level] in ('MASTER') and [Token_Type] in ('Other')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                c.RichEditControl1.Document.InsertText(Token2KundePos, dt.Rows.Item(0).Item("Token_ID"))
                c.RichEditControl1.Document.InsertText(Token2BankPos, dt.Rows.Item(0).Item("Token_ID"))
            Else
                c.RichEditControl1.Document.InsertText(Token2KundePos, "")
                c.RichEditControl1.Document.InsertText(Token2BankPos, "")
            End If
            'Master Token
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    
    Private Sub OnlineBankingUserGuideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlineBankingUserGuideToolStripMenuItem.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Online Banking User Guide")
        Try
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='Online_Banking_User_Guide' and [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ONLINE_BANKING_DOCS_DIR ' "
            cmd.Connection.Open()
            Dim OnlineBankingUserGuideDir As String = cmd.ExecuteScalar
            cmd.Connection.Close()

            If File.Exists(OnlineBankingUserGuideDir) = True Then
                Process.Start(OnlineBankingUserGuideDir)
                SplashScreenManager.CloseForm(False)
            Else
                SplashScreenManager.CloseForm(False)
                MessageBox.Show("The Online Banking User Guide could not be fund!", "ONLINE BANKING USER GUIDE DIRECTORY FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As OleDb.OleDbException
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR ON LOADING ONLINE BANKING USER GUIDE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub
End Class