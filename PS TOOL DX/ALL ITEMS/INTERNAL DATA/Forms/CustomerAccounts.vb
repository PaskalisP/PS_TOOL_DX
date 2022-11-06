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
Public Class CustomerAccounts

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

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

    Private Sub CUSTOMER_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CUSTOMER_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub CustomerAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'TODO: This line of code loads data into the 'PSTOOLDataset.CUSTOMER_ACCOUNTS' table. You can move, or remove it, as needed.
        Me.CUSTOMER_ACCOUNTSTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_ACCOUNTS)

        'Gridcontrol2 - CUSTOMERS
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = CustomerAccountsBaseView
        CustomerAccountsBaseView.ForceDoubleClick = True
        AddHandler CustomerAccountsBaseView.DoubleClick, AddressOf CustomerAccountsBaseView_DoubleClick
        AddHandler CustomerAccountsDetailView.MouseDown, AddressOf CustomerAccountsDetailView_MouseDown
        AddHandler CustomerAccountsViews_btn.Click, AddressOf CustomerAccountsViews_btn_Click
        CustomerAccountsDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        CustomerAccountsDetailView.OptionsBehavior.AllowSwitchViewModes = False

        If SUPER_USER = "N" Then
            Me.CustomerAccountsBaseView.OptionsBehavior.Editable = False
            Me.CustomerAccountsDetailView.OptionsBehavior.Editable = False
        End If

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Update Online Banking
        If e.Button.ButtonType = NavigatorButtonType.Custom Then
            If MessageBox.Show("Should the Online Status be updated for all Customer Accounts?", "ONLINE STATUS UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    cmd.CommandText = "UPDATE [CUSTOMER_ACCOUNTS] SET [Online]='N' where [Account Status]='C - CLOSE' and [Online]='Y'"
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[Online]=B.[Online] from [CLIENTS_ACCOUNTS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account]"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.CUSTOMER_ACCOUNTSTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_ACCOUNTS)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error on updating Online Banking Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        End If


    End Sub

#Region "CUSTOMER_ACCOUNTS_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "View List"
    Private strShowExtendedMode As String = "View Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = CustomerAccountsDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CustomerAccountsBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CustomerAccountsViews_btn.Text = strShowExtendedMode
        CustomerAccountsViews_btn.ImageIndex = 1
        fExtendedEditMode = (GridControl2.MainView Is CustomerAccountsDetailView)
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = CustomerAccountsBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CustomerAccountsDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CustomerAccountsViews_btn.Text = strHideExtendedMode
        CustomerAccountsViews_btn.ImageIndex = 0
        fExtendedEditMode = (GridControl2.MainView Is CustomerAccountsDetailView)

    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CustomerAccountsBaseView.GetRowHandle(dataSourceRowIndex)
        CustomerAccountsBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CustomerAccountsDetailView.GetRowHandle(dataSourceRowIndex)
        CustomerAccountsDetailView.VisibleRecordIndex = CustomerAccountsDetailView.GetVisibleIndex(rowHandle)
        CustomerAccountsDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub CustomerAccountsBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)

        Dim hi As GridHitInfo = CustomerAccountsBaseView.CalcHitInfo(ea.Location)
        If hi.InRow Then
            ShowDetail(hi.RowHandle)
        End If
    End Sub
    Protected Sub CustomerAccountsDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = CustomerAccountsDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                HideDetail(hi.RowHandle)
            End If
        End If
    End Sub
    Protected Sub CustomerAccountsViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If fExtendedEditMode Then
            HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        Else
            ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
        End If
    End Sub
#End Region

    Private Sub CustomerAccountsBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CustomerAccountsBaseView.CellValueChanged


    End Sub

    Private Sub RepositoryItemImageComboBox2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemImageComboBox2.EditValueChanged

        If Me.GridControl2.MainView Is CustomerAccountsBaseView AndAlso CustomerAccountsBaseView.IsFilterRow(CustomerAccountsBaseView.FocusedRowHandle) = False Then
            If Me.CustomerAccountsBaseView.GetFocusedRowCellValue("Account Status").ToString.StartsWith("A") = True Then
                If MessageBox.Show("Should the Online Status be saved?", "NEW ONLINE STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        CustomerAccountsBaseView.PostEditor()
                        Me.Validate()
                        Me.CUSTOMER_ACCOUNTSBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                        '***********************************************************************
                        'Update Client Accounts
                        cmd.CommandText = "UPDATE A SET A.[Online]=B.[Online] from [CLIENTS_ACCOUNTS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account]"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        '***********************************************************************

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
                    CustomerAccountsBaseView.HideEditor()


                    Exit Sub
                End If

            Else
                MessageBox.Show("Not allowed to change the Online Status of the Account: " & Me.CustomerAccountsBaseView.GetFocusedRowCellValue("Client Account").ToString, "ACCOUNT IS NOT ACTIVE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
                CustomerAccountsBaseView.HideEditor()

                Exit Sub
            End If
        ElseIf Me.GridControl2.MainView Is CustomerAccountsDetailView Then
            If CustomerAccountsDetailView.GetFocusedRowCellValue("Account Status").ToString.StartsWith("A") = True Then
                If MessageBox.Show("Should the Online Status be saved?", "NEW ONLINE STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        CustomerAccountsBaseView.PostEditor()
                        Me.Validate()
                        Me.CUSTOMER_ACCOUNTSBindingSource.EndEdit()
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                        '***********************************************************************
                        'Update Client Accounts
                        cmd.CommandText = "UPDATE A SET A.[Online]=B.[Online] from [CLIENTS_ACCOUNTS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account]"
                        cmd.Connection.Open()
                        cmd.ExecuteNonQuery()
                        cmd.Connection.Close()
                        '***********************************************************************

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
                    CustomerAccountsDetailView.HideEditor()

                    Exit Sub
                End If

            Else
                MessageBox.Show("Not allowed to change the Online Status of the Account: " & Me.CustomerAccountsDetailView.GetFocusedRowCellValue("Client Account").ToString, "ACCOUNT IS NOT ACTIVE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
                CustomerAccountsDetailView.HideEditor()
                Exit Sub
            End If

        End If

    End Sub

    Private Sub CustomerAccountsDetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CustomerAccountsDetailView.CellValueChanged
        'If Me.CustomerAccountsDetailView.GetFocusedRowCellValue("Account Status").ToString.StartsWith("A") = True Then
        'If MessageBox.Show("Should the Online Status be saved?", "NEW ONLINE STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        'Try
        'Me.Validate()
        'Me.CUSTOMER_ACCOUNTSBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Update Client Accounts
        'cmd.CommandText = "UPDATE A SET A.[Online]=B.[Online] from [CLIENTS_ACCOUNTS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account]"
        'cmd.Connection.Open()
        'cmd.ExecuteNonQuery()
        'cmd.Connection.Close()
        '***********************************************************************
        'Catch ex As Exception
        'MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
        'Else
        'Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
        'Exit Sub
        'End If

        'Else
        'MessageBox.Show("Not allowed to change the Online Status of the Account: " & Me.CustomerAccountsDetailView.GetFocusedRowCellValue("Client Account").ToString, "ACCOUNT IS NOT ACTIVE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Me.CUSTOMER_ACCOUNTSBindingSource.CancelEdit()
        'Exit Sub
        'End If
    End Sub

    Private Sub CustomerAccountsBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerAccountsBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerAccountsBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerAccountsBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CustomerAccounts_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles CustomerAccounts_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If CustomerAccountsViews_btn.Text = "View Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.CustomerAccountsDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.CustomerAccountsDetailView.OptionsPrint.PrintCardCaption = True
            Me.CustomerAccountsDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.CustomerAccountsDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.CustomerAccountsDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If

    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "CUSTOMER ACCOUNTS" & "  " & "Printed on: " & Now
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

  
   
End Class