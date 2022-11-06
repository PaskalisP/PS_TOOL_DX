Imports System
Imports System.IO
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



Public Class Client

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim RenameBox As New InputBox

    Private rootPath As String


    Private BS_AccountSigner As BindingSource
    Dim AccountSignerSurname As String = Nothing
    Dim AccountSignerID As String = Nothing
    Dim AccountSignerValidity As String = Nothing

    Dim ClientNrSearch As String = Nothing

    Dim FilePathInfo As FileSystemInfo
    Dim FilePath As String = Nothing
    Dim FileFromNameInfo As String = Nothing
    Dim FileFromNameNoExtension As String = Nothing
    Dim FileFromNameExtension As String = Nothing
    Dim FileDirectoryName As String = Nothing
    Dim NewFileName As String = Nothing

    Dim AccountVolumesGridviewCaption As String = Nothing
    Dim ClientsAccountsSignerGridviewCaption As String = Nothing



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

    Private Sub Client_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        'Me.WebBrowser1.Stop()
        If Me.WebBrowser1.Visible = True Then
            Me.WebBrowser1.Visible = False
        End If

        AddHandler ClientAccSigner_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClientAccSigner_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler ClientAccSignerAll_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClientAccSignerAll_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler ClientAllClientAccSigner_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClientAllClientAccSigner_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler Shareholder_GridControl.EmbeddedNavigator.ButtonClick, AddressOf Shareholder_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler GeneralManager_GridControl.EmbeddedNavigator.ButtonClick, AddressOf GeneralManager_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler ClientsContactPersons_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClientsContactPersons_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler ClientsContactsNotes_GridControl.EmbeddedNavigator.ButtonClick, AddressOf ClientsContactsNotes_GridControl_EmbeddedNavigator_ButtonClick
        AddHandler AML_CLASSIFIC_GridControl.EmbeddedNavigator.ButtonClick, AddressOf AML_CLASSIFIC_GridControl_EmbeddedNavigator_ButtonClick

        'Me.AML_CLASSIFIC_GridControl
       
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

        
        'Me.CLIENTSTableAdapter.Fill(Me.ClientsDataSet.CLIENTS)
        Me.XtraTabControl2.Visible = False
        Me.ClientName_lbl.Visible = False
        Me.Label10.Visible = False
        Me.TreeList1.OptionsDragAndDrop.DragNodesMode = True
        Me.CLIENTSTableAdapter.Fill(Me.ClientsDataSet.CLIENTS)
    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.Hint = "Print" Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
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
        Dim reportfooter As String = "Accounts Volumes for Customer: " & Me.ClientName_TextEdit.Text & " Client Nr.: " & Me.ClientNr_TextEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CLIENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CLIENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)

    End Sub

#Region "CLIENTS ACCOUNT SIGNER"
    Private Sub CLIENTS_ACCOUNT_SIGNER_initData()
        Dim ds As DataSet = New DataSet()
        Dim dbAccountSigner As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM [CLIENTS_ACCOUNT_SIGNER] where [Id_ClientNo]='" & Me.ClientSearch_GridLookUpEdit.Text & "' and [Signer_Valid]='Y'", conn) '
        Try

            dbAccountSigner.Fill(ds, "CLIENTS_ACCOUNT_SIGNER")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_AccountSigner = New BindingSource(ds, "CLIENTS_ACCOUNT_SIGNER")

    End Sub
    Private Sub CLIENTS_ACCOUNT_SIGNER_InitLookUp()
        Me.AccSignerRepositoryItemGridLookUpEdit.DataSource = BS_AccountSigner
        Me.AccSignerRepositoryItemGridLookUpEdit.DisplayMember = "Name"
        Me.AccSignerRepositoryItemGridLookUpEdit.ValueMember = "Name"
    End Sub
#End Region

#Region "FILL DATA BY CLIENT NR"
    Private Sub FILL_ALL_DATA_BY_CLIENT_NR()
        Me.CLIENTS_ACCOUNTS_VOLUMESTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_ACCOUNTS_VOLUMES, ClientNrSearch)
        Me.CLIENTS_CONTACT_PERSONSTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_CONTACT_PERSONS, ClientNrSearch)
        Me.CLIENTS_CONTACT_NOTESTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_CONTACT_NOTES, ClientNrSearch)
        Me.CLIENTS_SHAREHOLDERTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_SHAREHOLDER, ClientNrSearch)
        Me.CLIENTS_GENERAL_MANAGERTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_GENERAL_MANAGER, ClientNrSearch)
        Me.CLIENTS_ACCOUNT_SIGNERTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_ACCOUNT_SIGNER, ClientNrSearch)
        Me.CLIENTS_ACCOUNT_AUTHORIZED_PERSONSTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_ACCOUNT_AUTHORIZED_PERSONS, ClientNrSearch)
        Me.ClientS_ACCOUNT_AUTHORIZED_PERSONS1TableAdapter1.FillByClientNr(Me.ClientsDataSet.CLIENTS_ACCOUNT_AUTHORIZED_PERSONS1, ClientNrSearch)
        Me.CLIENTS_ACCOUNTSTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_ACCOUNTS, ClientNrSearch)
        Me.CLIENTSTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS, ClientNrSearch)
        Me.CLIENTS_AML_CLASSIFICTableAdapter.FillByClientNr(Me.ClientsDataSet.CLIENTS_AML_CLASSIFIC, ClientNrSearch)
        'Me.WebBrowser1.Stop()
        If Me.WebBrowser1.Visible = True Then
            Me.WebBrowser1.Visible = False
        End If
    End Sub
#End Region

#Region "CLIENT SEARCH"

    Private Sub ClientSearch_GridLookUpEdit_DoubleClick(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.DoubleClick

        
    End Sub

    Private Sub ClientSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.EditValueChanged
        If Me.ClientSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ClientSearch_GridLookUpEdit.Text) = True Then
            ClientNrSearch = Me.ClientSearch_GridLookUpEdit.Text
            FILL_ALL_DATA_BY_CLIENT_NR()
            'Me.Bar2.Visible = True
            Me.XtraTabControl2.Visible = True
            Me.ClientName_lbl.Visible = True
            Me.Label10.Visible = True
            Me.ClientSearch_GridLookUpEdit.Text = ClientNrSearch
            'Me.WebBrowser1.Stop()
            Me.WebBrowser1.Visible = False
            Me.XtraTabControl2.Focus()
            If IsDate(Me.DateEdit1.Text) = True Then
                Me.ClientStatus_lbl.Text = "CLOSED"
                Me.ClientStatus_lbl.BackColor = Color.Red
                Me.ClientStatus_lbl.ForeColor = Color.White
            ElseIf IsDate(Me.DateEdit1.Text) = False Then
                Me.ClientStatus_lbl.Text = "ACTIVE"
                Me.ClientStatus_lbl.BackColor = Color.Green
                Me.ClientStatus_lbl.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub ClientSearch_GridLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ClientSearch_GridLookUpEdit.ButtonClick
        If e.Button.Caption = "Load" Then
             Me.Bar2.Visible = False
            Me.XtraTabControl2.Visible = False
            Me.ClientName_lbl.Visible = False
            Me.Label10.Visible = False
            Me.CLIENTSTableAdapter.Fill(Me.ClientsDataSet.CLIENTS)
            Me.ClientSearch_GridLookUpEdit.Text = ""
        End If
        If e.Button.Caption = "Report" AndAlso Me.XtraTabControl2.Visible = True Then
            Me.PopupMenu1.ShowPopup(Control.MousePosition)

        End If
    End Sub

    Private Sub ClientSearch_GridLookUpEdit_Click(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.Click

       

    End Sub




    Private Sub ClientName_lbl_TextChanged(sender As Object, e As EventArgs) Handles ClientName_lbl.TextChanged
        If Me.ClientName_lbl.Text <> "" Then
            CLIENTS_ACCOUNT_SIGNER_initData()
            CLIENTS_ACCOUNT_SIGNER_InitLookUp()
            InitTreelistData()

        End If
    End Sub


    Private Sub ClientSearch_GridLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientSearch_GridLookUpEditView_ShownEditor(sender As Object, e As EventArgs)
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
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

#End Region

#Region "CLIENT ACCOUNTS VOLUMES"

    Private Sub ClientsAccountsVolumes_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ClientsAccountsVolumes_GridView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "ClientsAccountsVolumes_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            AccountVolumesGridviewCaption = "Volumes for Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientVolumes_GridView.ViewCaption = AccountVolumesGridviewCaption
        End If
    End Sub

    Private Sub ClientsAccountsVolumes_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ClientsAccountsVolumes_GridView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "ClientsAccountsVolumes_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            AccountVolumesGridviewCaption = "Volumes for Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientVolumes_GridView.ViewCaption = AccountVolumesGridviewCaption
        End If
    End Sub

    Private Sub ClientsAccountsVolumes_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ClientsAccountsVolumes_GridView.RowClick
        If Me.GridControl2.FocusedView.Name = "ClientsAccountsVolumes_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            AccountVolumesGridviewCaption = "Volumes for Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientVolumes_GridView.ViewCaption = AccountVolumesGridviewCaption
        End If
    End Sub
    Private Sub ClientsAccountsVolumes_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientsAccountsVolumes_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientsAccountsVolumes_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientsAccountsVolumes_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ClientVolumes_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientVolumes_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientVolumes_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientVolumes_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
#End Region

#Region "CLIENT ACCOUNTS AND SIGNER"

    Private Sub ClientAccSigner_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_ACCOUNTSBindingSource1.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub ClientAccSignerAll_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_ACCOUNT_SIGNERBindingSource1.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    'Update Status of all Signer
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE A SET A.[Signer_Valid]=B.[Signer_Valid] from [CLIENTS_ACCOUNT_AUTHORIZED_PERSONS] A INNER JOIN [CLIENTS_ACCOUNT_SIGNER] B ON A.[Id_Signer]=B.[ID]"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    '+++++++++++++++++++++++++++++
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Me.CLIENTS_ACCOUNT_SIGNERBindingSource1.CancelEdit()
                'e.Handled = True
                'Me.ClientsDataSet.RejectChanges()
                'FILL_ALL_DATA_BY_CLIENT_NR()
                Exit Sub

            End Try
        End If
    End Sub

    Private Sub ClientAllClientAccSigner_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_ACCOUNTSBindingSource1.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub AccSignerRepositoryItemGridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccSignerRepositoryItemGridLookUpEdit.EditValueChanged

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(ClientAccSigner_GridControl.FocusedView, GridView)

        view.SetRowCellValue(view.FocusedRowHandle, "Surname", AccountSignerSurname)
        view.SetRowCellValue(view.FocusedRowHandle, "Id_Signer", AccountSignerID)
        view.SetRowCellValue(view.FocusedRowHandle, "Signer_Valid", AccountSignerValidity)

    End Sub



    Private Sub RepositoryItemGridLookUpEdit1View_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles RepositoryItemGridLookUpEdit1View.RowClick
        Dim view As GridView = CType(sender, GridView)

        AccountSignerSurname = view.GetRowCellValue(view.FocusedRowHandle, "Surname").ToString
        AccountSignerID = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString
        AccountSignerValidity = view.GetRowCellValue(view.FocusedRowHandle, "Signer_Valid").ToString

        'MsgBox(AccountSignerSurname & "  " & AccountSignerID)

    End Sub





    Private Sub ClientAccountsSigner_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ClientAccountsSigner_GridView.FocusedRowChanged
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.Columns.ColumnByFieldName("Name").ColumnEdit = AccSignerRepositoryItemGridLookUpEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If


    End Sub

    Private Sub ClientAccountsSigner_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ClientAccountsSigner_GridView.RowClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

            view.Columns.ColumnByFieldName("Name").ColumnEdit = AccSignerRepositoryItemGridLookUpEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False

        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If

    End Sub



    Private Sub ClientAccountsSigner_GridView_ShowingEditor(sender As Object, e As CancelEventArgs) Handles ClientAccountsSigner_GridView.ShowingEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            AccountSignerValidity = view.GetRowCellValue(view.FocusedRowHandle, "Signer_Valid").ToString
            If AccountSignerValidity = "N" Then
                e.Cancel = True
                view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
                view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = False
                view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = True
            Else
                e.Cancel = False
                view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
                view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
                view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
            End If
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            e.Cancel = False
            view.Columns.ColumnByFieldName("Name").ColumnEdit = AccSignerRepositoryItemGridLookUpEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Cancel = False
            view.Columns.ColumnByFieldName("Name").ColumnEdit = Default_RepositoryItemTextEdit
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
        End If


    End Sub

    Private Sub ClientAccountsSigner_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientAccountsSigner_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientAccountsSigner_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientAccountsSigner_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ClientAccounts_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ClientAccounts_GridView.MasterRowExpanded
        If Me.ClientAccSigner_GridControl.FocusedView.Name = "ClientAccounts_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ClientsAccountsSignerGridviewCaption = "Authorized Persons to Sign on Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientAccountsSigner_GridView.ViewCaption = ClientsAccountsSignerGridviewCaption
        End If
    End Sub

    Private Sub ClientAccounts_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ClientAccounts_GridView.MasterRowExpanding
        If Me.ClientAccSigner_GridControl.FocusedView.Name = "ClientAccounts_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ClientsAccountsSignerGridviewCaption = "Authorized Persons to Sign on Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientAccountsSigner_GridView.ViewCaption = ClientsAccountsSignerGridviewCaption
        End If
    End Sub

    Private Sub ClientAccounts_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ClientAccounts_GridView.RowClick
        If Me.ClientAccSigner_GridControl.FocusedView.Name = "ClientAccounts_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ClientsAccountsSignerGridviewCaption = "Authorized Persons to Sign on Account: " & view.GetFocusedRowCellValue("Client Account").ToString & "  (" & view.GetFocusedRowCellValue("Deal Currency").ToString & ")"
            Me.ClientAccountsSigner_GridView.ViewCaption = ClientsAccountsSignerGridviewCaption
        End If
    End Sub

    Private Sub ClientAccounts_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientAccounts_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientAccounts_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientAccounts_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ClientAccountsSignerAll_GridView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ClientAccountsSignerAll_GridView.FocusedRowChanged
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle OrElse view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            'view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = False
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = True
            'view.Columns.ColumnByFieldName("Surname").OptionsColumn.AllowEdit = False
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.ReadOnly = True
            'Me.ClientAccSignerAll_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = True
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.ReadOnly = False
            'Me.ClientAccSignerAll_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        End If


    End Sub



    Private Sub ClientAccountsSignerAll_GridView_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles ClientAccountsSignerAll_GridView.RowClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle OrElse view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = False
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = True
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.AllowEdit = False
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.ReadOnly = True
            'Me.ClientAccSignerAll_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = True
        End If

        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.Columns.ColumnByFieldName("Name").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Name").OptionsColumn.ReadOnly = False
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.AllowEdit = True
            view.Columns.ColumnByFieldName("Surname").OptionsColumn.ReadOnly = False
            'Me.ClientAccSignerAll_GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        End If
    End Sub

    Private Sub ClientAccountsSignerAll_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientAccountsSignerAll_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientAccountsSignerAll_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientAccountsSignerAll_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AllClientAccountsIndicatedSigner_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllClientAccountsIndicatedSigner_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllClientAccountsIndicatedSigner_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AllClientAccountsIndicatedSigner_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub


    Private Sub ClientAccountsSignerAll_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ClientAccountsSignerAll_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim NAME_SIGNER As GridColumn = View.Columns("Name")
        Dim SURNAME_SIGNER As GridColumn = View.Columns("Surname")
        Dim ID_TYPE As GridColumn = View.Columns("ID_Type")
        Dim ID_NR As GridColumn = View.Columns("ID_Nr")
        Dim ID_VALID_TILL As GridColumn = View.Columns("ID_Valid_Till")
        Dim SIGNER_VALID As GridColumn = View.Columns("Signer_Valid")

        Dim NameSigner As String = View.GetRowCellValue(e.RowHandle, colName2).ToString
        Dim SurnameSigner As String = View.GetRowCellValue(e.RowHandle, colSurname2).ToString
        Dim IdType As String = View.GetRowCellValue(e.RowHandle, colID_Type).ToString
        Dim IdNr As String = View.GetRowCellValue(e.RowHandle, colID_Nr).ToString
        Dim IdValidTill As String = View.GetRowCellValue(e.RowHandle, colID_Valid_Till).ToString
        Dim SignerValid As String = View.GetRowCellValue(e.RowHandle, colSigner_Valid2).ToString

        If NameSigner = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(NAME_SIGNER, "The Name of the Signer must not be empty")
            e.ErrorText = "The Name of the Signer must not be empty"
            View.FocusedColumn = View.VisibleColumns(1)

        End If

        If SurnameSigner = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SURNAME_SIGNER, "The Surname of the Signer must not be empty")
            e.ErrorText = "The Surname of the Signer must not be empty"
        End If

        If IdType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ID_TYPE, "The ID Type must not be empty")
            e.ErrorText = "The ID Type must not be empty"
        End If

        If IdNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ID_NR, "The ID Nr. must not be empty")
            e.ErrorText = "The ID Nr. not be empty"
        End If

        If IdValidTill = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ID_VALID_TILL, "The ID Valid Date must not be empty")
            e.ErrorText = "The ID Valid Date must not be empty"
        End If

        If SignerValid = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SIGNER_VALID, "The Signer Status must not be empty")
            e.ErrorText = "The Signer Status must not be empty"
        End If
    End Sub

    Private Sub ClientAccountsSignerAll_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ClientAccountsSignerAll_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ClientAccountsSignerAll_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles ClientAccountsSignerAll_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ClientAccountsSigner_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ClientAccountsSigner_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim SYGN_TYPE As GridColumn = View.Columns("Sign_Type")

        Dim SygnType As String = View.GetRowCellValue(e.RowHandle, colSign_Type).ToString

        If SygnType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SYGN_TYPE, "The Sign Type must not be empty")
            e.ErrorText = "The Sign Type must not be empty"
        End If


    End Sub

    Private Sub ClientAccountsSigner_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ClientAccountsSigner_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ClientAccountsSigner_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles ClientAccountsSigner_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region

#Region "DOCUMENT TREELIST"
    '*********DOCUMENTS TREELIST****************
    Private Sub InitTreelistData()
        Me.TreeList1.ClearNodes()

        rootPath = Me.ClientDocsDirectoryLabel1.Text
        InitTreelistFolders(rootPath, Nothing)

        Me.TreeList1.ExpandAll()

    End Sub

    Private Sub InitTreelistFolders(ByVal path As String, ByVal pNode As TreeListNode)
        TreeList1.BeginUnboundLoad()
        Dim node As TreeListNode
        Dim di As DirectoryInfo
        Try
            Dim root() As String = Directory.GetDirectories(path)
            For Each s As String In root
                Try
                    di = New DirectoryInfo(s)
                    node = TreeList1.AppendNode(New Object() {s, di.Name, "Folder", Nothing, di}, pNode)
                    node.StateImageIndex = 0
                    node.HasChildren = HasFiles(s)
                    If node.HasChildren Then
                        node.Tag = True
                    End If
                Catch
                End Try
            Next s
        Catch
        End Try
        InitTreelistFiles(path, pNode)
        TreeList1.EndUnboundLoad()
    End Sub

    Private Sub InitTreelistFiles(ByVal path As String, ByVal pNode As TreeListNode)
        Dim node As TreeListNode
        Dim fi As FileInfo
        Try
            Dim root() As String = Directory.GetFiles(path)
            For Each s As String In root
                fi = New FileInfo(s)
                node = TreeList1.AppendNode(New Object() {s, fi.Name, "File", fi.Length, fi}, pNode)
                node.StateImageIndex = 2
                node.HasChildren = False
            Next s
        Catch
        End Try
    End Sub

    Private Function HasFiles(ByVal path As String) As Boolean
        Dim root() As String = Directory.GetFiles(path)
        If root.Length > 0 Then
            Return True
        End If
        root = Directory.GetDirectories(path)
        If root.Length > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub TreeList1_AfterCollapse(sender As Object, e As NodeEventArgs) Handles TreeList1.AfterCollapse
        If e.Node.StateImageIndex <> 2 Then
            e.Node.StateImageIndex = 0
        End If

    End Sub

    Private Sub TreeList1_AfterExpand(sender As Object, e As NodeEventArgs) Handles TreeList1.AfterExpand
        If e.Node.StateImageIndex <> 2 Then
            e.Node.StateImageIndex = 1
        End If

    End Sub

    Private Sub TreeList1_BeforeDragNode(sender As Object, e As BeforeDragNodeEventArgs) Handles TreeList1.BeforeDragNode
        Me.WebBrowser1.Stop()
        If Me.WebBrowser1.Visible = True Then
            Me.WebBrowser1.Visible = False
        End If
    End Sub


    Private Sub TreeList1_BeforeExpand(sender As Object, e As BeforeExpandEventArgs) Handles TreeList1.BeforeExpand
        If e.Node.Tag IsNot Nothing Then
            Dim currentCursor As Cursor = Cursor.Current
            Cursor.Current = Cursors.WaitCursor
            InitTreelistFolders(e.Node.GetDisplayText("FullName"), e.Node)
            e.Node.Tag = Nothing
            Cursor.Current = currentCursor
        End If

    End Sub

    Private Sub TreeList1_CalcNodeDragImageIndex(sender As Object, e As CalcNodeDragImageIndexEventArgs) Handles TreeList1.CalcNodeDragImageIndex
        If e.Node(TreeListColumn3).ToString() = "Folder" Then
            e.ImageIndex = 0
        End If
        If e.Node(TreeListColumn3).ToString() = "File" Then
            If e.Node.ParentNode Is TreeList1.FocusedNode.ParentNode Then
                e.ImageIndex = -1
                Return
            End If
            If e.ImageIndex = 0 Then
                If e.Node.Id > TreeList1.FocusedNode.Id Then
                    e.ImageIndex = 2
                Else
                    e.ImageIndex = 1
                End If
            End If
        End If

    End Sub

    Private Sub TreeList1_Click(sender As Object, e As EventArgs) Handles TreeList1.Click
        Me.TreeListColumn2.OptionsColumn.AllowEdit = False
        TreeList1.OptionsBehavior.Editable = False
        TreeList1.HideEditor()

        If (TryCast(sender, TreeList)).FocusedNode(TreeListColumn3).ToString() = "File" Then
            'Process.Start((TryCast((TryCast(sender, TreeList)).FocusedNode(TreeListColumn5), FileSystemInfo)).FullName, Nothing)
            Dim NodeDisplayText As String = Me.TreeList1.FocusedNode.GetDisplayText(1).ToString

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Document:" & NodeDisplayText)
            If Me.WebBrowser1.Visible = False Then
                Me.WebBrowser1.Visible = True
            End If
            Me.WebBrowser1.Navigate((TryCast((TryCast(sender, TreeList)).FocusedNode(TreeListColumn5), FileSystemInfo)).FullName, False)
            SplashScreenManager.CloseForm(False)
        ElseIf (TryCast(sender, TreeList)).FocusedNode(TreeListColumn3).ToString() <> "File" Then
            'Me.WebBrowser1.Stop()
            If Me.WebBrowser1.Visible = True Then
                Me.WebBrowser1.Visible = False
            End If
        End If
    End Sub

    Private Sub TreeList1_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles TreeList1.CustomDrawNodeCell
        'Backcolor filter cell
        If e.CellText = "" Then
            e.Appearance.BackColor = System.Drawing.Color.DimGray
            e.Appearance.BackColor2 = System.Drawing.Color.DimGray

        End If
    End Sub


    Private Sub TreeList1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeList1.DragDrop

        Dim draggedNode As TreeListNode = TryCast(e.Data.GetData(GetType(TreeListNode)), TreeListNode)
        Dim tagretNode As TreeListNode = TreeList1.ViewInfo.GetHitTest(TreeList1.PointToClient(New Point(e.X, e.Y))).Node
        If tagretNode Is Nothing OrElse draggedNode Is Nothing Then
            Return
        End If
        If tagretNode(TreeListColumn3).ToString() = "File" Then
            If tagretNode.ParentNode IsNot draggedNode.ParentNode Then
                MoveInFolder(draggedNode, tagretNode.ParentNode)
            End If

        Else
            MoveInFolder(draggedNode, tagretNode)
        End If
        e.Effect = DragDropEffects.None

    End Sub

    Private Sub MoveInFolder(ByVal sourceNode As TreeListNode, ByVal destNode As TreeListNode)
        'Move only File Nodes - NOT FOLDERS
        If Me.TreeList1.FocusedNode.GetDisplayText(2).ToString = "File" Then

            TreeList1.MoveNode(sourceNode, destNode)
            If sourceNode Is Nothing Then
                Return
            End If
            Dim sourceInfo As FileSystemInfo = TryCast(sourceNode(TreeListColumn5), FileSystemInfo)
            Dim sourcePath As String = sourceInfo.FullName

            Dim FileFromName As String = sourceInfo.Name.ToString

            Dim destInfoFile As FileSystemInfo = Nothing
            Dim destPath As String
            If destNode Is Nothing Then
                destPath = rootPath & sourceInfo.Name
            Else
                destInfoFile = TryCast(destNode(TreeListColumn5), FileSystemInfo)
                Dim destInfo As DirectoryInfo = TryCast(destNode(TreeListColumn5), DirectoryInfo)
                destPath = destInfo.FullName & "\" & sourceInfo.Name
            End If

            Dim destInfoFileName As String = destInfoFile.Name.ToString


            If TypeOf sourceInfo Is DirectoryInfo Then
                Directory.Move(sourcePath, destPath) 'IS DEACTIVATED-NO DIRECTORY FOLDER MOVE ALLOWED
            Else
                If File.Exists(destPath) Then
                    If MessageBox.Show("The current file exists allready in the destination Folder!" & vbNewLine & vbNewLine & "Should the file be replaced in the destination Folder?", "FILE EXISTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        File.Delete(destPath)
                        File.Move(sourcePath, destPath)
                        InitTreelistData()
                    Else
                        InitTreelistData()
                        Return
                        InitTreelistData()
                    End If

                Else
                    File.Move(sourcePath, destPath)

                End If


            End If

            sourceNode(TreeListColumn5) = New DirectoryInfo(destPath)
        End If

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating

    End Sub

    Private Sub AddNewCustomerFile_btn_Click(sender As Object, e As EventArgs) Handles AddNewCustomerFile_btn.Click

        Dim FileCopyDirectory As String = Me.ClientDocsDirectoryLabel1.Text & "\X_DOCUMENTS"

        With OpenFileDialog1

            '.InitialDirectory = "C:\"
            .Filter = "PDF(*.pdf)|*.pdf|Text(*.txt)|*.txt|Image(*.tif,*.tiff,*.jpg,*.gif)|*.tif;*.tiff;*.jpg;*.gif"
            .FileName = ""
            .Title = "Import Files"
            .RestoreDirectory = False
            .Multiselect = True

            If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                For Each file As String In OpenFileDialog1.FileNames
                    SplashScreenManager.Default.SetWaitFormCaption("Import File:" & file)
                    System.IO.File.Copy(file, FileCopyDirectory & "\" & IO.Path.GetFileName(file), True)
                Next
                InitTreelistData()
                SplashScreenManager.CloseForm(False)
            End If

        End With

    End Sub



    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.WebBrowser1.Stop()
        If Me.WebBrowser1.Visible = True Then
            Me.WebBrowser1.Visible = False
        End If
    End Sub

    Private Sub TreeList1_HiddenEditor(sender As Object, e As EventArgs) Handles TreeList1.HiddenEditor
        Me.TreeListColumn2.OptionsColumn.AllowEdit = False
        TreeList1.OptionsBehavior.Editable = False

    End Sub


    Private Sub bbEdit_ItemClick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.TreeList1.FocusedNode.GetDisplayText(2).ToString = "File" Then

            Me.WebBrowser1.Stop()
            If Me.WebBrowser1.Visible = True Then
                Me.WebBrowser1.Visible = False
            End If

            FilePathInfo = TryCast(Me.TreeList1.FocusedNode(TreeListColumn5), FileSystemInfo)
            FilePath = FilePathInfo.FullName
            FileFromNameInfo = FilePathInfo.Name.ToString

            FileFromNameNoExtension = Path.GetFileNameWithoutExtension(FilePath)
            FileFromNameExtension = Path.GetExtension(FilePath)
            FileDirectoryName = Path.GetDirectoryName(FilePath).ToString & "\"


            Dim dxOK_Rename As New DevExpress.XtraEditors.SimpleButton
            With dxOK_Rename
                .Text = "OK"
                .Height = 23
                .Width = 130
                .Location = New System.Drawing.Point(13, 113)
            End With
            RenameBox.Controls.Add(dxOK_Rename)
            RenameBox.LabelControl1.Text = "Current Name of the File:"
            RenameBox.LabelControl2.Text = FileFromNameNoExtension
            RenameBox.LabelControl3.Text = "New File Name:"
            RenameBox.TextEdit1.Focus()
            RenameBox.TextEdit1.Text = ""


            AddHandler dxOK_Rename.Click, AddressOf dxOK_Rename_click

            RenameBox.ShowDialog()

            RenameBox.Text = "CUSTOMER FILE NAME EDIT"

        Else
            Me.TreeListColumn2.OptionsColumn.AllowEdit = False
            TreeList1.OptionsBehavior.Editable = False
            TreeList1.HideEditor()

        End If

    End Sub

    Private Sub dxOK_Rename_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RenameBox.TextEdit1.Text <> "" AndAlso Len(RenameBox.TextEdit1.Text) > 1 Then
            NewFileName = RenameBox.TextEdit1.Text & FileFromNameExtension
            If File.Exists(FileDirectoryName & NewFileName) = False Then
                Me.RenameBox.Close()
                My.Computer.FileSystem.RenameFile(FilePath, NewFileName)
                InitTreelistData()
            Else
                MessageBox.Show("File allready exists with the same Name!" & vbNewLine & "Please input a different Name for the File", "FILENAME ALLREADY EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If
        End If


    End Sub


    Private Sub bbDelete_ItemClick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.TreeList1.FocusedNode.GetDisplayText(2).ToString = "File" Then

            Me.WebBrowser1.Stop()
            If Me.WebBrowser1.Visible = True Then
                Me.WebBrowser1.Visible = False
            End If

            FilePathInfo = TryCast(Me.TreeList1.FocusedNode(TreeListColumn5), FileSystemInfo)
            FilePath = FilePathInfo.FullName
            FileFromNameInfo = FilePathInfo.Name.ToString

            FileFromNameNoExtension = Path.GetFileNameWithoutExtension(FilePath)

            If MessageBox.Show("Should the File: " & FileFromNameInfo & " be deleted from the Client Documents ?", "CLIENT FILE DELETION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                My.Computer.FileSystem.RenameFile(FilePath, FileFromNameInfo & "_Deleted_from_" & Environment.UserName & "_on_" & Today.ToString("yyyyMMdd") & "_" & Now.ToString("HHmmss") & ".bak")

            Else
                Return

                'TreeList1.DeleteNode(TreeList1.FocusedNode)
            End If
            InitTreelistData()
        End If

    End Sub

    Private Sub TreeList1_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles TreeList1.PopupMenuShowing
        If Me.TreeList1.FocusedNode.GetDisplayText(2).ToString = "File" Then
            If TypeOf e.Menu Is DevExpress.XtraTreeList.Menu.TreeListNodeMenu Then
                TreeList1.FocusedNode = (CType(e.Menu, DevExpress.XtraTreeList.Menu.TreeListNodeMenu)).Node
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Edit", AddressOf bbEdit_ItemClick, ImageCollection1.Images(25)))
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Delete", AddressOf bbDelete_ItemClick, ImageCollection1.Images(26)))
            End If

        End If
    End Sub


    Private Sub TreeList1_SelectionChanged(sender As Object, e As EventArgs) Handles TreeList1.SelectionChanged
        Me.TreeListColumn2.OptionsColumn.AllowEdit = False
        TreeList1.OptionsBehavior.Editable = False
        TreeList1.HideEditor()
    End Sub
#End Region

#Region "KYC DATA"
    Private Sub Shareholder_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_SHAREHOLDERBindingSource.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Me.CLIENTS_SHAREHOLDERBindingSource.CancelEdit()
                Dim row As System.Data.DataRow = Shareholder_GridView.GetDataRow(Shareholder_GridView.FocusedRowHandle)
                Dim ShareholderName As String = row(2)
                Dim Shareholder_ID As String = row(0)
                If MessageBox.Show("Should the Shareholder: " & ShareholderName & " be deleted?", "DELETE SHAREHOLDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim ShareholderNameDelete As ClientsDataSet.CLIENTS_SHAREHOLDERRow
                    ShareholderNameDelete = ClientsDataSet.CLIENTS_SHAREHOLDER.FindByID(Shareholder_ID)
                    ShareholderNameDelete.Delete()
                    Shareholder_GridView.DeleteSelectedRows()
                    'Shareholder_GridControl.Update()
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub GeneralManager_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_GENERAL_MANAGERBindingSource.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Me.CLIENTS_GENERAL_MANAGERBindingSource.CancelEdit()
                Dim row As System.Data.DataRow = GeneralManager_GridView.GetDataRow(GeneralManager_GridView.FocusedRowHandle)
                Dim GeneralManagerName As String = row(1)
                Dim GeneralManager_ID As String = row(0)
                If MessageBox.Show("Should the General Manager: " & GeneralManagerName & " be deleted?", "DELETE GENERAL MANAGER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim GeneralManagerNameDelete As ClientsDataSet.CLIENTS_GENERAL_MANAGERRow
                    GeneralManagerNameDelete = ClientsDataSet.CLIENTS_GENERAL_MANAGER.FindByID(GeneralManager_ID)
                    GeneralManagerNameDelete.Delete()
                    GeneralManager_GridView.DeleteSelectedRows()
                    'GeneralManager_GridControl.Update()
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub






    Private Sub Shareholder_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Shareholder_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Shareholder_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Shareholder_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Shareholder_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles Shareholder_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim SHAREHOLDER_TYPE As GridColumn = View.Columns("Shareholder_Type")
        Dim SHAREHOLDE_NAME As GridColumn = View.Columns("Shareholder_Name")
        Dim SHARE_PERCENT As GridColumn = View.Columns("Share_Percent")


        Dim ShareholderType As String = View.GetRowCellValue(e.RowHandle, colShareholder_Type).ToString
        Dim ShareholderName As String = View.GetRowCellValue(e.RowHandle, colShareholder_Name).ToString
        Dim SharePercent As String = View.GetRowCellValue(e.RowHandle, colShare_Percent).ToString


        If ShareholderType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SHAREHOLDER_TYPE, "The Shareholder Type must not be empty")
            e.ErrorText = "The Shareholder Type must not be empty"
            View.FocusedColumn = View.VisibleColumns(1)

        End If

        If ShareholderName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SHAREHOLDE_NAME, "The Shareholder Name must not be empty")
            e.ErrorText = "The Shareholder Name must not be empty"
        End If

        If SharePercent = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SHARE_PERCENT, "The Share Percent must not be empty")
            e.ErrorText = "The Share Percent must not be empty"
        End If


    End Sub

    Private Sub Shareholder_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles Shareholder_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub Shareholder_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles Shareholder_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub GeneralManager_GridView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles GeneralManager_GridView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    Private Sub GeneralManager_GridView_ShownEditor(sender As Object, e As EventArgs) Handles GeneralManager_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GeneralManager_GridView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GeneralManager_GridView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim GENERAL_MANAGER_NAME As GridColumn = View.Columns("GeneralManagerName")

        Dim GeneralManagerName As String = View.GetRowCellValue(e.RowHandle, colGeneralManagerName).ToString

        If GeneralManagerName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(GENERAL_MANAGER_NAME, "The General Manager Name must not be empty")
            e.ErrorText = "The General Manager Name must not be empty"
            View.FocusedColumn = View.VisibleColumns(1)

        End If

    End Sub

    Private Sub GeneralManager_GridView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles GeneralManager_GridView.InvalidValueException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    Private Sub GeneralManager_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GeneralManager_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SaveKYCdata_btn_Click(sender As Object, e As EventArgs) Handles SaveKYCdata_btn.Click
        Try
            Me.Validate()
            Me.CLIENTSBindingSource.EndEdit()
            'If Me.ClientsDataSet.HasChanges = True Then
            If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                FILL_ALL_DATA_BY_CLIENT_NR()
            Else
                Return
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub TurnoverEuro_TextEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TurnoverEuro_TextEdit.ButtonClick

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        If e.Button.Caption = "Last 3M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverEuro]=(Select sum(I)+sum(O) from (Select TOP 3 [ID],[AverageIncomingMonth] as I,[AverageOutgoingMonth] as O, [MonthDate] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "'  order by id asc) M),[TurnoverDescription]='Average In- and Outgoings for the last 3 Months' where [ClientNo]='" & ClientNrSearch & "' "
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 3 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++
            'Deactivated on 21.11.2016
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 3 Months"
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([IncomingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuro_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescription_lbl.Text = "Sum Incomings for the last 3 Months"
        End If
        If e.Button.Caption = "Last 6M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 6 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 6 Months"
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([IncomingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuro_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescription_lbl.Text = "Sum Incomings for the last 6 Months"
        End If
        If e.Button.Caption = "Last 12M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 12 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 12 Months"
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([IncomingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuro_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescription_lbl.Text = "Sum Incomings for the last 12 Months"
        End If
        cmd.Connection.Close()
        'FILL_ALL_DATA_BY_CLIENT_NR()
    End Sub

    Private Sub TurnoverEuroOutgoings_TextEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TurnoverEuroOutgoings_TextEdit.ButtonClick
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        If e.Button.Caption = "Last 3M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverEuro]=(Select sum(I)+sum(O) from (Select TOP 3 [ID],[AverageIncomingMonth] as I,[AverageOutgoingMonth] as O, [MonthDate] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "'  order by id asc) M),[TurnoverDescription]='Average In- and Outgoings for the last 3 Months' where [ClientNo]='" & ClientNrSearch & "' "
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 3 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++
            'Deactivated on 21.11.2016
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 3 Months"
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([OutgoingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuroOutgoings_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescriptionOutgoings_lbl.Text = "Sum Outgoings for the last 3 Months"
        End If
        If e.Button.Caption = "Last 6M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 6 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 6 Months"
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([OutgoingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -6, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuroOutgoings_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescriptionOutgoings_lbl.Text = "Sum Outgoings for the last 6 Months"
        End If
        If e.Button.Caption = "Last 12M" Then
            'cmd.CommandText = "Update [CLIENTS] set [TurnoverDescription]='Average In- and Outgoings for the last 12 Months , calculated on ' + CONVERT(VARCHAR(10), GETDATE(), 104), [TurnoverEuro]= Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -3, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end where  [ClientNo]='" & ClientNrSearch & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([AverageIncomingMonth]+[AverageOutgoingMonth])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>=DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            'Me.TurnoverEuro_TextEdit.Text = cmd.ExecuteScalar
            'Me.TurnoverDescription_lbl.Text = "Average In- and Outgoings for the last 12 Months"
            cmd.CommandText = "Select Case when EXISTS (Select [ID] from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0)))  then (Select ABS(sum([OutgoingSum])) from [CLIENTS_ACCOUNTS_VOLUMES] where [ClientNo]='" & ClientNrSearch & "' and [DateOnFirstMonth]>DATEADD(MONTH, -12, DATEADD(mm, DATEDIFF(mm,0,GETDATE()), 0))) else 0 end" 'where  [ClientNo]='" & ClientNrSearch & "'"
            Me.TurnoverEuroOutgoings_TextEdit.Text = FormatNumber(cmd.ExecuteScalar, 2)
            Me.TurnoverDescriptionOutgoings_lbl.Text = "Sum Outgoings for the last 12 Months"
        End If
        cmd.Connection.Close()
    End Sub

#End Region

#Region "AML CLASSIFICATION"
    Private Sub AML_CLASSIFIC_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_AML_CLASSIFICBindingSource.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    'Update AML RISK
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Connection.Open()
                    cmd.CommandText = "UPDATE [CLIENTS] SET [AML_SCORES_RESULT]=(Select Sum([Classification_Score]) from [CLIENTS_AML_CLASSIFIC] where [Classification_Score] is not NULL and [Id_ClientNo]='" & ClientNrSearch & "') where [ClientNo]='" & ClientNrSearch & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select [AML_SCORES_RESULT] from [CLIENTS] where [ClientNo]='" & ClientNrSearch & "' begin update [CLIENTS] set [AML_RISK_RESULT]='LOW' where [AML_SCORES_RESULT]>=60 and [AML_SCORES_RESULT]<=190 end begin update [CLIENTS] set [AML_RISK_RESULT]='MIDDLE' where [AML_SCORES_RESULT]>=200 and [AML_SCORES_RESULT]<=330 end begin update [CLIENTS] set [AML_RISK_RESULT]='HIGH' where [AML_SCORES_RESULT]>=340 and [AML_SCORES_RESULT]<=460 end "
                    cmd.ExecuteNonQuery()
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub AML_Classification_GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles AML_Classification_GridView.CustomRowCellEditForEditing
        If e.Column.FieldName <> "Classification_Score" Then Return
        Dim Gv As GridView = sender
        'Dim FieldName As String = Gv.GetRowCellValue(e.RowHandle, Gv.Columns("Classification_Type")).ToString()
        Dim FieldName As String = Me.AML_Classification_GridView.GetRowCellValue(Me.AML_Classification_GridView.FocusedRowHandle, colClassification_Type)
        Select Case (FieldName)
            Case "1. PEP"
                e.RepositoryItem = Me.PEP_RepositoryItemImageComboBox
            Case "2. Personal Presence for Account opening "
                e.RepositoryItem = Me.PersonalPresence_RepositoryItemImageComboBox
            Case "3a. Country client"
                e.RepositoryItem = Me.CountryClientShareHold_RepositoryItemImageComboBox
            Case "3b. Country shareholder"
                e.RepositoryItem = Me.CountryClientShareHold_RepositoryItemImageComboBox
            Case "4a. Legal status Client"
                e.RepositoryItem = Me.LegalStatus_RepositoryItemImageComboBox
            Case "4b. Legal status shareholder"
                e.RepositoryItem = Me.LegalStatus_RepositoryItemImageComboBox
            Case "5. Turnover in Euro per Month"
                e.RepositoryItem = Me.TurnoverEUR_RepositoryItemImageComboBox
            Case "6. Internet Banking"
                e.RepositoryItem = Me.InternetBanking_RepositoryItemImageComboBox
            Case "7. Kind of business"
                e.RepositoryItem = Me.KindOfBusiness_RepositoryItemImageComboBox
            Case "8. Legal or tax problems/ order of attachment (Pfändungsbeschluss)"
                e.RepositoryItem = Me.LegalProblems_RepositoryItemImageComboBox
            Case "9. others"
                e.RepositoryItem = Me.Other_RepositoryItemTextEdit

        End Select
    End Sub


    Private Sub AML_Classification_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AML_Classification_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
        'If e.RowHandle Mod 2 = 1 Then
        'e.Appearance.BackColor = Color.Tomato
        'End If
    End Sub

    Private Sub AML_Classification_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AML_Classification_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

#End Region

#Region "CLIENT CONTACTS"
    Private Sub ClientsContactPersons_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_CONTACT_PERSONSBindingSource.EndEdit()
                'If Me.ClientsDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Me.CLIENTS_CONTACT_PERSONSBindingSource.CancelEdit()
                Dim row As System.Data.DataRow = ClientContactPersons_GridView.GetDataRow(ClientContactPersons_GridView.FocusedRowHandle)
                Dim ContactName As String = row(1)
                Dim ContactName_ID As String = row(0)
                If MessageBox.Show("Should the Contact: " & ContactName & " be deleted?", "DELETE CONTACT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim ContactNameNameDelete As ClientsDataSet.CLIENTS_CONTACT_PERSONSRow
                    ContactNameNameDelete = ClientsDataSet.CLIENTS_CONTACT_PERSONS.FindByID(ContactName_ID)
                    ContactNameNameDelete.Delete()
                    ClientContactPersons_GridView.DeleteSelectedRows()
                    'ClientsContactPersons_GridControl.Update()
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub ClientsContactsNotes_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.CLIENTS_CONTACT_NOTESBindingSource.EndEdit()
                If Me.ClientsDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                        cmd.CommandText = "UPDATE [CLIENTS_CONTACT_NOTES] SET [ContactDate]=GETDATE(),[ContactTime]=GETDATE() WHERE [ContactDate] is NULL "
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        FILL_ALL_DATA_BY_CLIENT_NR()
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Me.CLIENTS_CONTACT_NOTESBindingSource.CancelEdit()
                Dim row As System.Data.DataRow = ClientsContactsNotes_GridView.GetDataRow(ClientsContactsNotes_GridView.FocusedRowHandle)

                Dim ContactNode_ID As String = row(0)
                If MessageBox.Show("Should the Contact Note ID: " & ContactNode_ID & " be deleted?", "DELETE CONTACT NOTES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim ContactNoteDelete As ClientsDataSet.CLIENTS_CONTACT_NOTESRow
                    ContactNoteDelete = ClientsDataSet.CLIENTS_CONTACT_NOTES.FindByID(ContactNode_ID)
                    ContactNoteDelete.Delete()
                    ClientsContactsNotes_GridView.DeleteSelectedRows()
                    'ClientsContactsNotes_GridControl.Update()
                    Me.TableAdapterManager.UpdateAll(Me.ClientsDataSet)
                    FILL_ALL_DATA_BY_CLIENT_NR()
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub ClientContactPersons_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientContactPersons_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientContactPersons_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientContactPersons_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ClientsContactsNotes_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ClientsContactsNotes_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ClientsContactsNotes_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ClientsContactsNotes_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If

    End Sub
#End Region

#Region "REPORTS"
    Private Sub AllData_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AllData_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Client Data report for Client Nr. " & ClientNrSearch)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CLIENT_ALL_DATA.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(ClientsDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ClientNrSearch
        myParams.ParameterFieldName = "ClientNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Client Data for Client Nr. " & ClientNrSearch
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub KYC_Form_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles KYC_Form_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating KYC report for Client Nr. " & ClientNrSearch)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CLIENT_KYC_FORM.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(ClientsDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ClientNrSearch
        myParams.ParameterFieldName = "ClientNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "KYC Report for Client Nr. " & ClientNrSearch
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

#End Region



    Private Sub XtraTabControl2_SelectedPageChanging(sender As Object, e As TabPageChangingEventArgs) Handles XtraTabControl2.SelectedPageChanging
        If e.Page.Text = "CLIENT DOCUMENTS" Then

        End If


    End Sub




    
    Private Sub AllDataNew_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AllDataNew_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Client Data report for Client Nr. " & ClientNrSearch)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CLIENT_ALL_DATA.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(ClientsDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ClientNrSearch
        myParams.ParameterFieldName = "ClientNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Client Data for Client Nr. " & ClientNrSearch
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub KYC_FormNew_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles KYC_FormNew_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating KYC report for Client Nr. " & ClientNrSearch)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CLIENT_KYC_FORM.rpt")
        'Dim r As New ObligoLiabilitySurplus
        CrRep.SetDataSource(ClientsDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ClientNrSearch
        myParams.ParameterFieldName = "ClientNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "KYC Report for Client Nr. " & ClientNrSearch
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    
End Class